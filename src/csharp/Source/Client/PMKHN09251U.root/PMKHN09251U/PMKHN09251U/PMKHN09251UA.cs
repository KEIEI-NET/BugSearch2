//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 売上目標設定マスタ
// プログラム概要   : 売上目標設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 作 成 日  2008/10/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/20  修正内容 : MANTIS【13308】重複オペレーションエラー対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/29  修正内容 : MANTIS【13352】対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 作 成 日  2010/12/20  修正内容 : 障害改良対応１２月
//----------------------------------------------------------------------------//
// 管理番号 10704766-00  作成担当 : wangf
// 作 成 日  2011/07/18  修正内容 : 障害改良対応連番818
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using System.Collections;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売上目標設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上目標設定フォームクラス</br>
    /// <br>Programmer : 30414 忍 幸史</br>
    /// <br>Date       : 2008/10/08</br>
    /// <br>Update Note: 2010/12/20 曹文傑</br>
    /// <br>             障害改良対応１２月</br>
    /// </remarks>
    public partial class PMKHN09251UA : Form, ISalesTargetMDIChild
    {
        #region ■ Constants

        private const string ASSEMBLY_ID = "PMKHN09251U";

        private const string COLUMN_MONTH = "Month";
        private const string COLUMN_RATIO = "Ratio";
        private const string COLUMN_SALESTARGET = "SalesTarget";
        private const string COLUMN_PROFITTARGET = "ProfitTarget";
        private const string COLUMN_COUNTTARGET = "CountTarget";

        private const string FORMAT_NUM = "###,###";

        private const string INSERT_MODE = "新規";
        private const string UPDATE_MODE = "更新";
        private const string DELETE_MODE = "削除";

        #endregion ■ Constants


        #region ■ Private Members

        private bool _isClose;
        private bool _isSave;
        private bool _isNew;
        private bool _isRevival;
        private bool _isLogicalDelete;
        private bool _isDelete;
        private bool _isUndo;
        private bool _isCalc;
        private bool _isRenewal;

        private string _enterpriseCode;                     // 企業コード

        private bool _cusotmerGuideSelected;                // 得意先ガイド選択フラグ

        private List<DateTime> _startMonthDateList;         // 年月度開始日リスト
        private List<DateTime> _endMonthDateList;           // 年月度終了日リスト
        private List<DateTime> _yearMonthList;              // 年月度リスト
        private int _year;                                  // 会計年度
        private int _thisYear;                              // 当年度

        private SalesTargetAcs _salesTargetAcs;
        private SecInfoAcs _secInfoAcs;
        private SecInfoSetAcs _secInfoSetAcs;
        private SubSectionAcs _subSectionAcs;
        private CustomerInfoAcs _customerInfoAcs;
        private CustomerSearchAcs _customerSearchAcs;
        private EmployeeAcs _employeeAcs;
        private UserGuideAcs _userGuideAcs;
        private DateGetAcs _dateGetAcs;

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, SubSection> _subSectionDic;
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        private Dictionary<string, Employee> _employeeDic;
        private Dictionary<int, string> _salesAreaDic;
        private Dictionary<int, string> _businessTypeDic;
        private Dictionary<int, string> _salesCodeDic;
        private Dictionary<int, string> _enterpriseGanreDic;

        private Dictionary<string, EmpSalesTarget> _empSalesTargetDicClone;
        private Dictionary<string, CustSalesTarget> _custSalesTargetDicClone;
        private Dictionary<string, GcdSalesTarget> _gcdSalesTargetDicClone;

        private bool _searchFlg;

        private int _prevYear;
        private int _prevTargetContrastCd;
        private string _prevSectionCode;
        private int _prevSubSectionCode;
        private int _prevCustomerCode;
        private string _prevEmployeeCode;
        private int _prevSalesAreaCode;
        private int _prevBusinessTypeCode;
        private int _prevSalesCode;
        private int _prevEnterpriseGanreCode;

        #endregion ■ Private Members


        #region ■ Constructor

        /// <summary>
        /// 売上目標設定フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上目標設定フォームクラス</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public PMKHN09251UA()
        {
            InitializeComponent();

            this._isClose = true;
            this._isSave = true;
            this._isNew = true;
            this._isRevival = false;
            this._isLogicalDelete = false;
            this._isDelete = false;
            this._isUndo = true;
            this._isCalc = true;
            this._isRenewal = true;

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 各種アクセスクラスインスタンス生成
            this._salesTargetAcs = new SalesTargetAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._subSectionAcs = new SubSectionAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._employeeAcs = new EmployeeAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._dateGetAcs = DateGetAcs.GetInstance();

            this._empSalesTargetDicClone = new Dictionary<string, EmpSalesTarget>();
            this._custSalesTargetDicClone = new Dictionary<string, CustSalesTarget>();
            this._gcdSalesTargetDicClone = new Dictionary<string, GcdSalesTarget>();

            // 各種マスタ取得
            bool bStatus = ReadMaster();
            if (!bStatus)
            {
                return;
            }

            // 会計年度情報取得
            GetFinancialYearTable(0);
        }

        #endregion ■ Constructor


        #region ■ ISalesTargetMDIChild メンバ

        /// <summary> ツールバーVisible制御イベント </summary>
        public event ParentToolbarSalesTargetEventHandler ParentToolbarSalesTargetEvent;

        /// <summary> 終了ボタンVisibleプロパティ </summary>
        public bool IsClose
        {
            get { return this._isClose; }
        }

        /// <summary> 保存ボタンVisibleプロパティ </summary>
        public bool IsSave
        {
            get { return this._isSave; }
        }

        /// <summary> 新規ボタンVisibleプロパティ </summary>
        public bool IsNew
        {
            get { return this._isNew; }
        }

        /// <summary> 復活ボタンVisibleプロパティ </summary>
        public bool IsRevival
        {
            get { return this._isRevival; }
        }

        /// <summary> 論理削除ボタンVisibleプロパティ </summary>
        public bool IsLogicalDelete
        {
            get { return this._isLogicalDelete; }
        }

        /// <summary> 完全削除ボタンVisibleプロパティ </summary>
        public bool IsDelete
        {
            get { return this._isDelete; }
        }

        /// <summary> 元に戻すボタンVisibleプロパティ </summary>
        public bool IsUndo
        {
            get { return this._isUndo; }
        }

        /// <summary> 比率から計算ボタンVisibleプロパティ </summary>
        public bool IsCalc
        {
            get { return this._isCalc; }
        }

        /// <summary> 最新情報ボタンVisibleプロパティ </summary>
        public bool IsRenewal
        {
            get { return this._isRenewal; }
        }

        /// <summary>
        /// 終了前処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 終了前処理を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int BeforeClose()
        {
            DialogResult result = DialogResult.No;

            // 画面状態変更チェック
            bool bStatus = CompareInputScreen();
            if (!bStatus)
            {
                result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                        "",
                                        0,
                                        MessageBoxButtons.YesNoCancel,
                                        MessageBoxDefaultButton.Button2);
            }

            switch (result)
            {
                case DialogResult.Yes:
                    {
                        // 保存処理
                        int status = SaveProc();
                        if (status != 0)
                        {
                            return (status);
                        }

                        break;
                    }
                case DialogResult.No:
                    {
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        return -1;
                    }
            }

            return 0;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 保存処理を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Save()
        {
            return SaveProc();
        }

        /// <summary>
        /// 新規処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 新規処理を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int New()
        {
            DialogResult result = DialogResult.No;

            // 画面状態変更チェック
            bool bStatus = CompareInputScreen();
            if (!bStatus)
            {
                result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                        "",
                                        0,
                                        MessageBoxButtons.YesNoCancel,
                                        MessageBoxDefaultButton.Button2);
            }

            switch (result)
            {
                case DialogResult.Yes:
                    {
                        // 保存処理
                        int status = SaveProc();
                        if (status != 0)
                        {
                            return (status);
                        }

                        break;
                    }
                case DialogResult.No:
                    {
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        return 0;
                    }
            }

            // 画面初期化処理
            ClearScreen();

            SetControlEnabled(INSERT_MODE);

            // 条件コントロールEnabled制御
            ChangeTargetContrastControl(10);

            // フォーカス設定
            this.tNedit_Year.Focus();

            return 0;
        }

        /// <summary>
        /// 復活処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 復活処理を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Revival()
        {
            int statsu = RevivalProc();
            if (statsu == 0)
            {
                // フォーカス設定
                this.tNedit_SalesTargetSale.Focus();
            }

            return (statsu);
        }

        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 論理削除処理を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int LogicalDelete()
        {
            // 論理削除確認
            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                 "データを論理削除します。\r\nよろしいですか？",
                                                 0,
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Cancel)
            {
                return 0;
            }

            return LogicalDeleteProc();
        }

        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 物理削除処理を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Delete()
        {
            // 完全削除確認
            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                 "データを物理削除します。\r\nよろしいですか？",
                                                 0,
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Cancel)
            {
                return 0;
            }

            return DeleteProc();
        }

        /// <summary>
        /// 元に戻す処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 元に戻す処理を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Undo()
        {
            return UndoProc();
        }

        /// <summary>
        /// 比率から計算処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 比率から計算処理を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Calc()
        {
            return CalcProc();
        }

        /// <summary>
        /// 最新情報取得処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 最新情報を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Renewal()
        {
            return RenewalProc();
        }

        /// <summary>
        /// フォーカス設定処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : フォーカス設定処理を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public void SetFocus()
        {
            this.tNedit_Year.Focus();
        }

        #endregion ■ ISalesTargetMDIChild メンバ


        #region ■ Private Methods

        #region マスタ読込
        /// <summary>
        /// 各種マスタ読込処理
        /// </summary>
        /// <returns>ステータス(True:正常 False:異常)</returns>
        /// <remarks>
        /// <br>Note       : 各種マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private bool ReadMaster()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string errMsg = "";

            try
            {
                // 拠点
                status = ReadSecInfoSet();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "拠点マスタの読込に失敗しました。";
                        return (false);
                }

                // 部門
                status = ReadSubSection();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "部門マスタの読込に失敗しました。";
                        return (false);
                }

                // 得意先
                status = ReadCustomer();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "得意先マスタの読込に失敗しました。";
                        return (false);
                }

                // 従業員
                status = ReadEmployee();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "従業員マスタの読込に失敗しました。";
                        return (false);
                }

                // 地区
                status = ReadSalesArea();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "地区情報の取得に失敗しました。";
                        return (false);
                }

                // 業種
                status = ReadBusinessType();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "業種情報の取得に失敗しました。";
                        return (false);
                }

                // 販売区分
                status = ReadSalesCode();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "販売区分情報の取得に失敗しました。";
                        return (false);
                }

                // 商品区分
                status = ReadEnterpriseGanre();
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "商品区分情報の取得に失敗しました。";
                        return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(this,
                                  emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                  this.Name,
                                  errMsg,
                                  status,
                                  MessageBoxButtons.OK);
                }
            }

            return (true);
        }

        /// <summary>
        /// 拠点マスタ読込処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 拠点マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            this._secInfoAcs.ResetSectionInfo();

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                    }
                }
            }
            catch
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// 部門マスタ読込処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 部門マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int ReadSubSection()
        {
            this._subSectionDic = new Dictionary<int, SubSection>();

            try
            {
                ArrayList retList;

                int status = this._subSectionAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (SubSection subSection in retList)
                    {
                        if (subSection.LogicalDeleteCode == 0)
                        {
                            this._subSectionDic.Add(subSection.SubSectionCode, subSection);
                        }
                    }
                }
            }
            catch
            {
                this._subSectionDic = new Dictionary<int, SubSection>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// 得意先マスタ読込処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int ReadCustomer()
        {
            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

            try
            {
                CustomerSearchPara para = new CustomerSearchPara();
                para.EnterpriseCode = this._enterpriseCode;

                CustomerSearchRet[] retArray;
                
                int status = this._customerSearchAcs.Serch(out retArray, para);
                if (status == 0)
                {
                    foreach (CustomerSearchRet customerSearchRet in retArray)
                    {
                        if (customerSearchRet.LogicalDeleteCode == 0)
                        {
                            this._customerSearchRetDic.Add(customerSearchRet.CustomerCode, customerSearchRet);
                        }
                    }
                }
            }
            catch
            {
                this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// 従業員マスタ読込処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 従業員マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int ReadEmployee()
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
                        if (employee.LogicalDeleteCode == 0)
                        {
                            this._employeeDic.Add(employee.EmployeeCode.Trim(), employee);
                        }
                    }
                }
            }
            catch
            {
                this._employeeDic = new Dictionary<string, Employee>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// 地区マスタ読込処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 地区マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int ReadSalesArea()
        {
            this._salesAreaDic = new Dictionary<int, string>();

            return ReadUserGdBd(21, ref this._salesAreaDic);
        }

        /// <summary>
        /// 業種マスタ読込処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 業種マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int ReadBusinessType()
        {
            this._businessTypeDic = new Dictionary<int, string>();

            return ReadUserGdBd(33, ref this._businessTypeDic);
        }

        /// <summary>
        /// 販売区分マスタ読込処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 販売区分マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int ReadSalesCode()
        {
            this._salesCodeDic = new Dictionary<int, string>();

            return ReadUserGdBd(71, ref this._salesCodeDic);
        }

        /// <summary>
        /// 商品区分マスタ読込処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品区分マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int ReadEnterpriseGanre()
        {
            this._enterpriseGanreDic = new Dictionary<int, string>();

            return ReadUserGdBd(41, ref this._enterpriseGanreDic);
        }

        /// <summary>
        /// ユーザーガイドマスタ読込処理
        /// </summary>
        /// <param name="userGuideDivCd">ガイド区分</param>
        /// <param name="targetDic">対象Dictionary</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ユーザーガイドマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int ReadUserGdBd(int userGuideDivCd, ref Dictionary<int, string> targetDic)
        {
            try
            {
                ArrayList retList;

                int status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode,
                                                                     userGuideDivCd, UserGuideAcsData.UserBodyData);
                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            targetDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                        }
                    }
                }
            }
            catch
            {
                targetDic = new Dictionary<int, string>();
                return -1;
            }

            return 0;
        }
        #endregion マスタ読込

        #region 名称取得
        /// <summary>
        /// 拠点名取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名</returns>
        /// <remarks>
        /// <br>Note       : 拠点名を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()))
            {
                sectionName = this._secInfoSetDic[sectionCode.Trim()].SectionGuideNm.Trim();
            }

            return sectionName;
        }

        /// <summary>
        /// 部門名取得処理
        /// </summary>
        /// <param name="subSectionCode">部門コード</param>
        /// <returns>部門名</returns>
        /// <remarks>
        /// <br>Note       : 部門名を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private string GetSubSectionName(int subSectionCode)
        {
            string subSectionName = "";

            if (this._subSectionDic.ContainsKey(subSectionCode))
            {
                subSectionName = this._subSectionDic[subSectionCode].SubSectionName.Trim();
            }

            return subSectionName;
        }

        /// <summary>
        /// 得意先名取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名</returns>
        /// <remarks>
        /// <br>Note       : 得意先名を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string customerName = "";

            if (this._customerSearchRetDic.ContainsKey(customerCode))
            {
                customerName = this._customerSearchRetDic[customerCode].Snm.Trim();
            }

            return customerName;
        }

        /// <summary>
        /// 従業員名取得処理
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>従業員名</returns>
        /// <remarks>
        /// <br>Note       : 従業員名を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private string GetEmployeeName(string employeeCode)
        {
            string employeeName = "";

            if (this._employeeDic.ContainsKey(employeeCode.Trim()))
            {
                employeeName = this._employeeDic[employeeCode].Name.Trim();
            }

            return employeeName;
        }

        /// <summary>
        /// 地区名取得処理
        /// </summary>
        /// <param name="salesAreaCode">地区コード</param>
        /// <returns>地区名</returns>
        /// <remarks>
        /// <br>Note       : 地区名を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private string GetSalesAreaName(int salesAreaCode)
        {
            string salesAreaName = "";

            if (this._salesAreaDic.ContainsKey(salesAreaCode))
            {
                salesAreaName = this._salesAreaDic[salesAreaCode].Trim();
            }

            return salesAreaName;
        }

        /// <summary>
        /// 業種名取得処理
        /// </summary>
        /// <param name="businessTypeCode">業種コード</param>
        /// <returns>業種名</returns>
        /// <remarks>
        /// <br>Note       : 業種名を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private string GetBusinessTypeName(int businessTypeCode)
        {
            string businessTypeName = "";

            if (this._businessTypeDic.ContainsKey(businessTypeCode))
            {
                businessTypeName = this._businessTypeDic[businessTypeCode].Trim();
            }

            return businessTypeName;
        }

        /// <summary>
        /// 販売区分名取得処理
        /// </summary>
        /// <param name="salesCode">販売区分コード</param>
        /// <returns>販売区分名</returns>
        /// <remarks>
        /// <br>Note       : 販売区分名を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private string GetSalesCodeName(int salesCode)
        {
            string salesCodeName = "";

            if (this._salesCodeDic.ContainsKey(salesCode))
            {
                salesCodeName = this._salesCodeDic[salesCode].Trim();
            }

            return salesCodeName;
        }

        /// <summary>
        /// 商品区分名取得処理
        /// </summary>
        /// <param name="enterpriseGanreCode">商品区分コード</param>
        /// <returns>商品区分名</returns>
        /// <remarks>
        /// <br>Note       : 商品区分名を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private string GetEnterpriseGanreName(int enterpriseGanreCode)
        {
            string enterpriseGanreName = "";

            if (this._enterpriseGanreDic.ContainsKey(enterpriseGanreCode))
            {
                enterpriseGanreName = this._enterpriseGanreDic[enterpriseGanreCode].Trim();
            }

            return enterpriseGanreName;
        }
        #endregion 名称取得

        // ADD 2009/06/29 ------>>>
        #region マスタ存在チェック
        /// <summary>
        /// 得意先存在チェック処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>true：OK、false：NG</returns>
        /// <remarks>
        /// <br>Note       : 得意先が存在するかチェックします。</br>
        /// <br></br>
        /// </remarks>
        private bool CheckCustomer(int customerCode)
        {
            bool check = false;

            try
            {
                if (this._customerSearchRetDic.ContainsKey(customerCode))
                {
                    check = true;
                }
            }
            catch
            {
                check = false;
            }

            return check;
        }
        #endregion マスタ存在チェック
        // ADD 2009/06/29 ------<<<
        
        #region 会計年度テーブル取得
        /// <summary>
        /// 会計年度テーブル取得処理
        /// </summary>
        /// <param name="addYearFromThis">当年からの差分</param>
        /// <remarks>
        /// <br>Note       : 会計年度テーブルを取得し、会計年度情報をバッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void GetFinancialYearTable(int addYearFromThis)
        {
            try
            {
                this._dateGetAcs.GetFinancialYearTable(addYearFromThis,
                                                       out this._startMonthDateList,
                                                       out this._endMonthDateList,
                                                       out this._yearMonthList,
                                                       out this._year);
                if (addYearFromThis == 0)
                {
                    this._thisYear = this._year;
                }
            }
            catch
            {
                this._startMonthDateList = new List<DateTime>();
                this._endMonthDateList = new List<DateTime>();
                this._yearMonthList = new List<DateTime>();
                this._year = 0;
            }
        }
        #endregion 会計年度テーブル取得

        #region 画面初期化
        /// <summary>
        /// 画面情報初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報を初期化します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void ClearScreen()
        {
            this.tNedit_Year.SetInt(this._thisYear);
            this.tComboEditor_TargetContrastCd.Value = 10;
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();
            this.tNedit_SubSectionCode.Clear();
            this.tEdit_SubSectionName.Clear();
            this.tNedit_CustomerCode.Clear();
            this.tEdit_CustomerName.Clear();
            this.tEdit_EmployeeCode.Clear();
            this.tEdit_EmployeeName.Clear();
            this.tNedit_SalesAreaCode.Clear();
            this.tEdit_SalesAreaName.Clear();
            this.tNedit_BusinessTypeCode.Clear();
            this.tEdit_BusinessTypeName.Clear();
            this.tNedit_SalesCode.Clear();
            this.tEdit_SalesCodeName.Clear();
            this.tNedit_EnterpriseGanreCode.Clear();
            this.tEdit_EnterpriseGanreName.Clear();

            ClearGrid();

            this.Mode_Label.Text = INSERT_MODE;

            this._searchFlg = false;

            // 2011.07.18 wangf del start
            // 新規など処理後で前回検索の年分初期化必要はない、フォーカス移動時前回検索の年分が更新してので。
            // ここで、初期化ならば、完全削除後で、新規時、前回検索年分取得できない。
            //this._prevYear = this._thisYear;
            // 2011.07.18 wangf del end
            this._prevTargetContrastCd = 10;
            this._prevSectionCode = "";
            this._prevSubSectionCode = 0;
            this._prevCustomerCode = 0;
            this._prevEmployeeCode = "";
            this._prevSalesAreaCode = 0;
            this._prevBusinessTypeCode = 0;
            this._prevSalesCode = 0;
            this._prevEnterpriseGanreCode = 0;
        }

        /// <summary>
        /// グリッド初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド情報を初期化します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void ClearGrid()
        {
            this.tNedit_SalesTargetSale.Clear();
            this.tNedit_SalesTargetProfit.Clear();
            this.tNedit_SalesTargetCount.Clear();

            for (int index = 0; index < 13; index++)
            {
                if (index != 12)
                {
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_MONTH].Value = this._yearMonthList[index].Month.ToString("00");
                }
                else
                {
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_MONTH].Value = "計";
                }
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_RATIO].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = "";
            }

            this._empSalesTargetDicClone.Clear();
            this._custSalesTargetDicClone.Clear();
            this._gcdSalesTargetDicClone.Clear();
        }
        #endregion 画面初期化

        #region 画面設定
        /// <summary>
        /// コントロールサイズ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コントロールサイズを設定します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tNedit_Year.Size = new Size(51, 24);
            this.tEdit_SectionCode.Size = new Size(74, 24);
            this.tEdit_SectionName.Size = new Size(315, 24);
            this.tNedit_SubSectionCode.Size = new Size(74, 24);
            this.tEdit_SubSectionName.Size = new Size(315, 24);
            this.tNedit_CustomerCode.Size = new Size(74, 24);
            this.tEdit_CustomerName.Size = new Size(315, 24);
            this.tEdit_EmployeeCode.Size = new Size(74, 24);
            this.tEdit_EmployeeName.Size = new Size(315, 24);
            this.tNedit_SalesAreaCode.Size = new Size(74, 24);
            this.tEdit_SalesAreaName.Size = new Size(315, 24);
            this.tNedit_BusinessTypeCode.Size = new Size(74, 24);
            this.tEdit_BusinessTypeName.Size = new Size(315, 24);
            this.tNedit_SalesCode.Size = new Size(74, 24);
            this.tEdit_SalesCodeName.Size = new Size(315, 24);
            this.tNedit_EnterpriseGanreCode.Size = new Size(74, 24);
            this.tEdit_EnterpriseGanreName.Size = new Size(315, 24);
            
            this.tNedit_SalesTargetSale.Size = new Size(139, 24);
            this.tNedit_SalesTargetProfit.Size = new Size(139, 24);
            this.tNedit_SalesTargetCount.Size = new Size(115, 24);

            this.tEdit_TargetContrastCd10.Size = new Size(144, 24);
            this.tEdit_TargetContrastCd20.Size = new Size(144, 24);
            this.tEdit_TargetContrastCd30.Size = new Size(144, 24);
            this.tEdit_TargetContrastCd22_1.Size = new Size(144, 24);
            this.tEdit_TargetContrastCd22_2.Size = new Size(144, 24);
            this.tEdit_TargetContrastCd22_3.Size = new Size(144, 24);
            this.tEdit_TargetContrastCd31.Size = new Size(144, 24);
            this.tEdit_TargetContrastCd32.Size = new Size(144, 24);
            this.tEdit_TargetContrastCd44.Size = new Size(144, 24);
            this.tEdit_TargetContrastCd45.Size = new Size(144, 24);
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報の初期設定を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SetScreenInitialSetting()
        {
            // コントロールサイズ設定
            SetControlSize();

            // -----------------------------
            // ボタンアイコン設定
            // -----------------------------
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SubSectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.CustomerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.EmployeeGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SalesAreaGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BusinessTypeGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SalesCodeGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.EnterpriseGanreGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // -----------------------------
            // グリッド設定
            // -----------------------------
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(COLUMN_MONTH, typeof(string));
            dataTable.Columns.Add(COLUMN_RATIO, typeof(string));
            dataTable.Columns.Add(COLUMN_SALESTARGET, typeof(string));
            dataTable.Columns.Add(COLUMN_PROFITTARGET, typeof(string));
            dataTable.Columns.Add(COLUMN_COUNTTARGET, typeof(string));

            for (int index = 0; index < 13; index++)
            {
                DataRow dataRow;
                dataRow = dataTable.NewRow();

                if (index != 12)
                {
                    dataRow[COLUMN_MONTH] = this._yearMonthList[index].Month.ToString("00");
                }
                else
                {
                    dataRow[COLUMN_MONTH] = "計";
                }
                dataRow[COLUMN_RATIO] = "";
                dataRow[COLUMN_SALESTARGET] = "";
                dataRow[COLUMN_PROFITTARGET] = "";
                dataRow[COLUMN_COUNTTARGET] = "";
                dataTable.Rows.Add(dataRow);
            }

            this.SalesTarget_uGrid.DataSource = dataTable;

            // キャプション
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Header.Caption = "月";
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_RATIO].Header.Caption = "月別比率";
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Header.Caption = "売上目標";
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Header.Caption = "粗利目標";
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Header.Caption = "数量目標";

            // 列幅
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Width = 33;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_RATIO].Width = 73;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Width = 140;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Width = 140;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Width = 110;

            // TextHAlign(ヘッダー)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Header.Appearance.TextHAlign = HAlign.Center;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_RATIO].Header.Appearance.TextHAlign = HAlign.Center;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Header.Appearance.TextHAlign = HAlign.Center;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Header.Appearance.TextHAlign = HAlign.Center;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Header.Appearance.TextHAlign = HAlign.Center;

            // TextHAlign(セル)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.TextHAlign = HAlign.Center;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_RATIO].CellAppearance.TextHAlign = HAlign.Right;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].CellAppearance.TextHAlign = HAlign.Right;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].CellAppearance.TextHAlign = HAlign.Right;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].CellAppearance.TextHAlign = HAlign.Right;

            // TextVAlign(ヘッダー)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Header.Appearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_RATIO].Header.Appearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Header.Appearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Header.Appearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Header.Appearance.TextVAlign = VAlign.Middle;

            // TextVAlign(セル)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_RATIO].CellAppearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].CellAppearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].CellAppearance.TextVAlign = VAlign.Middle;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].CellAppearance.TextVAlign = VAlign.Middle;

            // ForeColor(ヘッダー)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Header.Appearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_RATIO].Header.Appearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Header.Appearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Header.Appearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Header.Appearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].Header.Appearance.ForeColorDisabled = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_RATIO].Header.Appearance.ForeColorDisabled = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].Header.Appearance.ForeColorDisabled = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].Header.Appearance.ForeColorDisabled = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].Header.Appearance.ForeColorDisabled = Color.White;

            // ForeColor(セル)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_RATIO].CellAppearance.ForeColor = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].CellAppearance.ForeColor = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].CellAppearance.ForeColor = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].CellAppearance.ForeColor = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_RATIO].CellAppearance.ForeColorDisabled = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_SALESTARGET].CellAppearance.ForeColorDisabled = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_PROFITTARGET].CellAppearance.ForeColorDisabled = Color.Black;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_COUNTTARGET].CellAppearance.ForeColorDisabled = Color.Black;

            // 列設定(月)
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.ForeColor = Color.White;
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellAppearance.ForeColorDisabled = Color.White;

            // 行設定(計)
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_RATIO].Appearance.BackColor = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_RATIO].Appearance.BackColorDisabled = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_SALESTARGET].Appearance.BackColor = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_SALESTARGET].Appearance.BackColorDisabled = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_PROFITTARGET].Appearance.BackColor = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_PROFITTARGET].Appearance.BackColorDisabled = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_COUNTTARGET].Appearance.BackColor = Color.Gainsboro;
            this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_COUNTTARGET].Appearance.BackColorDisabled = Color.Gainsboro;

            // Activation
            this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COLUMN_MONTH].CellActivation = Activation.Disabled;
            this.SalesTarget_uGrid.Rows[12].Activation = Activation.Disabled;
        }
        #endregion 画面設定

        #region コントロールEnabled制御
        /// <summary>
        /// 設定区分条件コントロールEnabled制御処理
        /// </summary>
        /// <param name="targetContrastCd">設定区分コード</param>
        /// <remarks>
        /// <br>Note       : 設定区分の値によってコントロールの制御を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void ChangeTargetContrastControl(int targetContrastCd)
        {
            this.tEdit_SectionCode.Enabled = false;
            this.SectionGuide_Button.Enabled = false;
            this.tNedit_SubSectionCode.Enabled = false;
            this.SubSectionGuide_Button.Enabled = false;
            this.tNedit_CustomerCode.Enabled = false;
            this.CustomerGuide_Button.Enabled = false;
            this.tEdit_EmployeeCode.Enabled = false;
            this.EmployeeGuide_Button.Enabled = false;
            this.tNedit_SalesAreaCode.Enabled = false;
            this.SalesAreaGuide_Button.Enabled = false;
            this.tNedit_BusinessTypeCode.Enabled = false;
            this.BusinessTypeGuide_Button.Enabled = false;
            this.tNedit_SalesCode.Enabled = false;
            this.SalesCodeGuide_Button.Enabled = false;
            this.tNedit_EnterpriseGanreCode.Enabled = false;
            this.EnterpriseGanreGuide_Button.Enabled = false;
            
            switch (targetContrastCd)
            {
                case 10:    // 拠点
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;

                        this.tNedit_SubSectionCode.Clear();
                        this.tEdit_SubSectionName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BusinessTypeCode.Clear();
                        this.tEdit_BusinessTypeName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_EnterpriseGanreCode.Clear();
                        this.tEdit_EnterpriseGanreName.Clear();

                        break;
                    }
                case 20:    // 拠点＋部門
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_SubSectionCode.Enabled = true;
                        this.SubSectionGuide_Button.Enabled = true;

                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BusinessTypeCode.Clear();
                        this.tEdit_BusinessTypeName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_EnterpriseGanreCode.Clear();
                        this.tEdit_EnterpriseGanreName.Clear();

                        break;
                    }
                case 30:    // 拠点＋得意先
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustomerGuide_Button.Enabled = true;

                        this.tNedit_SubSectionCode.Clear();
                        this.tEdit_SubSectionName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BusinessTypeCode.Clear();
                        this.tEdit_BusinessTypeName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_EnterpriseGanreCode.Clear();
                        this.tEdit_EnterpriseGanreName.Clear();

                        break;
                    }
                case 221:   // 拠点＋担当者
                case 222:   // 拠点＋受注者
                case 223:   // 拠点＋発行者
                    {
                        if (targetContrastCd == 221)
                        {
                            this.uLabel_Employee.Text = "担当者";
                        }
                        else if (targetContrastCd == 222)
                        {
                            this.uLabel_Employee.Text = "受注者";
                        }
                        else
                        {
                            this.uLabel_Employee.Text = "発行者";
                        }
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tEdit_EmployeeCode.Enabled = true;
                        this.EmployeeGuide_Button.Enabled = true;

                        this.tNedit_SubSectionCode.Clear();
                        this.tEdit_SubSectionName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BusinessTypeCode.Clear();
                        this.tEdit_BusinessTypeName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_EnterpriseGanreCode.Clear();
                        this.tEdit_EnterpriseGanreName.Clear();

                        break;
                    }
                case 32:    // 拠点＋地区
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_SalesAreaCode.Enabled = true;
                        this.SalesAreaGuide_Button.Enabled = true;

                        this.tNedit_SubSectionCode.Clear();
                        this.tEdit_SubSectionName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_BusinessTypeCode.Clear();
                        this.tEdit_BusinessTypeName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_EnterpriseGanreCode.Clear();
                        this.tEdit_EnterpriseGanreName.Clear();

                        break;
                    }
                case 31:    // 拠点＋業種
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_BusinessTypeCode.Enabled = true;
                        this.BusinessTypeGuide_Button.Enabled = true;

                        this.tNedit_SubSectionCode.Clear();
                        this.tEdit_SubSectionName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();
                        this.tNedit_EnterpriseGanreCode.Clear();
                        this.tEdit_EnterpriseGanreName.Clear();

                        break;
                    }
                case 44:    // 拠点＋販売区分
                    {
                        this.tEdit_SectionCode.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                        this.tNedit_SalesCode.Enabled = true;
                        this.SalesCodeGuide_Button.Enabled = true;

                        this.tNedit_SubSectionCode.Clear();
                        this.tEdit_SubSectionName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BusinessTypeCode.Clear();
                        this.tEdit_BusinessTypeName.Clear();
                        this.tNedit_EnterpriseGanreCode.Clear();
                        this.tEdit_EnterpriseGanreName.Clear();

                        break;
                    }
                case 45:    // 商品区分
                    {
                        this.tNedit_EnterpriseGanreCode.Enabled = true;
                        this.EnterpriseGanreGuide_Button.Enabled = true;

                        this.tEdit_SectionCode.Clear();
                        this.tEdit_SectionName.Clear();
                        this.tNedit_SubSectionCode.Clear();
                        this.tEdit_SubSectionName.Clear();
                        this.tNedit_CustomerCode.Clear();
                        this.tEdit_CustomerName.Clear();
                        this.tEdit_EmployeeCode.Clear();
                        this.tEdit_EmployeeName.Clear();
                        this.tNedit_SalesAreaCode.Clear();
                        this.tEdit_SalesAreaName.Clear();
                        this.tNedit_BusinessTypeCode.Clear();
                        this.tEdit_BusinessTypeName.Clear();
                        this.tNedit_SalesCode.Clear();
                        this.tEdit_SalesCodeName.Clear();

                        break;
                    }
            }
        }

        /// <summary>
        /// コントロールEnabled制御処理
        /// </summary>
        /// <param name="editMode">編集モード</param>
        /// <remarks>
        /// <br>Note       : コントロールのEnabled制御を行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SetControlEnabled(string editMode)
        {
            // 設定区分
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;

            switch (editMode)
            {
                case INSERT_MODE:
                    {
                        //this.tNedit_Year.Enabled = true;
                        //this.tComboEditor_TargetContrastCd.Enabled = true;

                        //// 条件コントロールEnabled制御
                        //ChangeTargetContrastControl(targetContrastCd);

                        // ADD 2009/05/20 ------>>>
                        // 年度と設定区分を入力
                        this.tNedit_Year.Enabled = true;
                        this.tComboEditor_TargetContrastCd.Enabled = true;
                        // ADD 2009/05/20 ------<<<

                        this.tNedit_SalesTargetSale.Enabled = true;
                        this.tNedit_SalesTargetProfit.Enabled = true;
                        this.tNedit_SalesTargetCount.Enabled = true;

                        this.SalesTarget_uGrid.Enabled = true;

                        this._isClose = true;
                        this._isSave = true;
                        this._isNew = true;
                        this._isRevival = false;
                        this._isLogicalDelete = false;
                        this._isDelete = false;
                        this._isUndo = true;
                        this._isCalc = true;
                        this._isRenewal = true;

                        break;
                    }
                case UPDATE_MODE:
                    {
                        //this.tNedit_Year.Enabled = false;
                        //this.tComboEditor_TargetContrastCd.Enabled = false;

                        //// 条件コントロールEnabled制御
                        //ChangeTargetContrastControl(0);

                        // ADD 2009/05/20 ------>>>
                        // テーブルキー項目は入力不可
                        this.tNedit_Year.Enabled = false;
                        this.tComboEditor_TargetContrastCd.Enabled = false;
                        this.tEdit_SectionCode.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                        this.tNedit_SubSectionCode.Enabled = false;
                        this.SubSectionGuide_Button.Enabled = false;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        this.tEdit_EmployeeCode.Enabled = false;
                        this.EmployeeGuide_Button.Enabled = false;
                        this.tNedit_SalesAreaCode.Enabled = false;
                        this.SalesAreaGuide_Button.Enabled = false;
                        this.tNedit_BusinessTypeCode.Enabled = false;
                        this.BusinessTypeGuide_Button.Enabled = false;
                        this.tNedit_SalesCode.Enabled = false;
                        this.SalesCodeGuide_Button.Enabled = false;
                        this.tNedit_EnterpriseGanreCode.Enabled = false;
                        this.EnterpriseGanreGuide_Button.Enabled = false;
                        // ADD 2009/05/20 ------<<<

                        this.tNedit_SalesTargetSale.Enabled = true;
                        this.tNedit_SalesTargetProfit.Enabled = true;
                        this.tNedit_SalesTargetCount.Enabled = true;

                        this.SalesTarget_uGrid.Enabled = true;

                        this._isClose = true;
                        this._isSave = true;
                        this._isNew = true;
                        this._isRevival = false;
                        this._isLogicalDelete = true;
                        this._isDelete = false;
                        this._isUndo = true;
                        this._isCalc = true;
                        this._isRenewal = true;

                        break;
                    }
                case DELETE_MODE:
                    {
                        //this.tNedit_Year.Enabled = false;
                        //this.tComboEditor_TargetContrastCd.Enabled = false;

                        //// 条件コントロールEnabled制御
                        //ChangeTargetContrastControl(0);

                        // ADD 2009/05/20 ------>>>
                        // テーブルキー項目は入力不可
                        this.tNedit_Year.Enabled = false;
                        this.tComboEditor_TargetContrastCd.Enabled = false;
                        this.tEdit_SectionCode.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                        this.tNedit_SubSectionCode.Enabled = false;
                        this.SubSectionGuide_Button.Enabled = false;
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        this.tEdit_EmployeeCode.Enabled = false;
                        this.EmployeeGuide_Button.Enabled = false;
                        this.tNedit_SalesAreaCode.Enabled = false;
                        this.SalesAreaGuide_Button.Enabled = false;
                        this.tNedit_BusinessTypeCode.Enabled = false;
                        this.BusinessTypeGuide_Button.Enabled = false;
                        this.tNedit_SalesCode.Enabled = false;
                        this.SalesCodeGuide_Button.Enabled = false;
                        this.tNedit_EnterpriseGanreCode.Enabled = false;
                        this.EnterpriseGanreGuide_Button.Enabled = false;
                        // ADD 2009/05/20 ------<<<

                        this.tNedit_SalesTargetSale.Enabled = false;
                        this.tNedit_SalesTargetProfit.Enabled = false;
                        this.tNedit_SalesTargetCount.Enabled = false;

                        this.SalesTarget_uGrid.Enabled = false;

                        this._isClose = true;
                        this._isSave = false;
                        this._isNew = true;
                        this._isRevival = true;
                        this._isLogicalDelete = false;
                        this._isDelete = true;
                        this._isUndo = false;
                        this._isCalc = false;
                        this._isRenewal = false;

                        break;
                    }
            }

            ParentToolbarSalesTargetEvent(this);
        }
        #endregion コントロールEnabled制御

        // ADD 2009/05/20 ------>>>
        #region キーコントロールDisable制御
        /// <summary>
        /// キーコントロールDisable制御処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : キーコントロールのDisable制御を行います。</br>
        /// <br></br>
        /// </remarks>
        private void SetKeyControlDisable()
        {
            // テーブルキー項目は入力不可
            this.tNedit_Year.Enabled = false;
            this.tComboEditor_TargetContrastCd.Enabled = false;
            this.tEdit_SectionCode.Enabled = false;
            this.SectionGuide_Button.Enabled = false;
            this.tNedit_SubSectionCode.Enabled = false;
            this.SubSectionGuide_Button.Enabled = false;
            this.tNedit_CustomerCode.Enabled = false;
            this.CustomerGuide_Button.Enabled = false;
            this.tEdit_EmployeeCode.Enabled = false;
            this.EmployeeGuide_Button.Enabled = false;
            this.tNedit_SalesAreaCode.Enabled = false;
            this.SalesAreaGuide_Button.Enabled = false;
            this.tNedit_BusinessTypeCode.Enabled = false;
            this.BusinessTypeGuide_Button.Enabled = false;
            this.tNedit_SalesCode.Enabled = false;
            this.SalesCodeGuide_Button.Enabled = false;
            this.tNedit_EnterpriseGanreCode.Enabled = false;
            this.EnterpriseGanreGuide_Button.Enabled = false;
            
        }
        #endregion キーコントロールDisable制御
        // ADD 2009/05/20 ------<<<

        #region Focus設定
        /// <summary>
        /// Nextコントロール取得処理
        /// </summary>
        /// <param name="prevControl">現在コントロール</param>
        /// <param name="nextControl">Nextコントロール</param>
        /// <remarks>
        /// <br>Note       : Nextコントロールを取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void GetNextControl(Control prevControl, out Control nextControl)
        {
            nextControl = null;

            if (prevControl == null)
            {
                return;
            }

            // 設定区分
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;

            switch (prevControl.Name)
            {
                case "tEdit_SectionCode":
                case "SectionGuide_Button":
                    {
                        switch (targetContrastCd)
                        {
                            case 10:    // 拠点
                                {
                                    nextControl = this.tNedit_SalesTargetSale;
                                    break;
                                }
                            case 20:    // 拠点＋部門
                                {
                                    nextControl = this.tNedit_SubSectionCode;
                                    break;
                                }
                            case 30:    // 拠点＋得意先
                                {
                                    nextControl = this.tNedit_CustomerCode;
                                    break;
                                }
                            case 221:   // 拠点＋担当者
                            case 222:   // 拠点＋受注者
                            case 223:   // 拠点＋発行者
                                {
                                    nextControl = this.tEdit_EmployeeCode;
                                    break;
                                }
                            case 32:    // 拠点＋地区
                                {
                                    nextControl = this.tNedit_SalesAreaCode;
                                    break;
                                }
                            case 31:    // 拠点＋業種
                                {
                                    nextControl = this.tNedit_BusinessTypeCode;
                                    break;
                                }
                            case 44:    // 拠点＋販売区分
                                {
                                    nextControl = tNedit_SalesCode;
                                    break;
                                }
                        }
                        break;
                    }
                case "tNedit_SubSectionCode":
                case "SubSectionGuide_Button":
                case "tNedit_CustomerCode":
                case "CustomerGuide_Button":
                case "tEdit_EmployeeCode":
                case "EmployeeGuide_Button":
                case "tNedit_SalesAreaCode":
                case "SalesAreaGuide_Button":
                case "tNedit_BusinessTypeCode":
                case "BusinessTypeGuide_Button":
                case "tNedit_SalesCode":
                case "SalesCodeGuide_Button":
                case "tNedit_EnterpriseGanreCode":
                case "EnterpriseGanreGuide_Button":
                    {
                        nextControl = this.tNedit_SalesTargetSale;
                        break;
                    }
            }
        }

        /// <summary>
        /// NextCell設定処理
        /// </summary>
        /// <param name="e">イベントハンドら</param>
        /// <param name="shiftFlg">ShiftKey押下フラグ(True:押下 Flase:押下せず)</param>
        /// <remarks>
        /// <br>Note       : NextCellを設定します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SetNextCell(ref ChangeFocusEventArgs e, bool shiftFlg)
        {
            int rowIndex;
            int columnIndex;

            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                if (this.SalesTarget_uGrid.ActiveRow == null)
                {
                    rowIndex = 0;
                    columnIndex = 1;
                }
                else
                {
                    rowIndex = this.SalesTarget_uGrid.ActiveRow.Index;
                    columnIndex = 1;
                }
            }
            else
            {
                rowIndex = this.SalesTarget_uGrid.ActiveCell.Row.Index;
                columnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;
            }

            e.NextCtrl = null;

            if (shiftFlg == false)
            {
                if (rowIndex < 11)
                {
                    this.SalesTarget_uGrid.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    if (columnIndex < 4)
                    {
                        this.SalesTarget_uGrid.Rows[0].Cells[columnIndex + 1].Activate();
                        this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        if (this.Mode_Label.Text == INSERT_MODE)
                        {
                            this.tNedit_Year.Focus();
                        }
                        else
                        {
                            this.tNedit_SalesTargetSale.Focus();
                        }
                    }
                }
            }
            else
            {
                if (rowIndex > 0)
                {
                    this.SalesTarget_uGrid.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    if (columnIndex > 1)
                    {
                        this.SalesTarget_uGrid.Rows[11].Cells[columnIndex - 1].Activate();
                        this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        this.tNedit_SalesTargetCount.Focus();
                    }
                }
            }
        }
        #endregion Focus設定

        #region 保存処理
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上目標設定を保存します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int SaveProc()
        {
            this.SalesTarget_uGrid.ActiveCell = null;

            // 入力チェック
            bool bStatus = CheckScreenInput(true);
            if (!bStatus)
            {
                return -1;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 設定区分
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 10:    // 拠点
                case 20:    // 拠点＋部門
                case 221:   // 拠点＋担当者
                case 222:   // 拠点＋受注者
                case 223:   // 拠点＋発行者
                    {
                        status = SaveEmpSalesTarget();
                        break;
                    }
                case 30:    // 拠点＋得意先
                case 31:    // 拠点＋業種
                case 32:    // 拠点＋地区
                    {
                        status = SaveCustSalesTarget();
                        break;
                    }
               default:     // 拠点＋販売区分、商品区分
                    {
                        status = SaveGcdSalesTarget();
                        break;
                    }
            }

            return (status);
        }

        /// <summary>
        /// 保存処理(従業員別売上目標)
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上目標設定を保存します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// <br>Update Note: 2010/12/20 曹文傑</br>
        /// <br>             障害改良対応１２月</br>
        /// </remarks>
        private int SaveEmpSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 画面情報取得
            List<EmpSalesTarget> empSalesTargetList = new List<EmpSalesTarget>();
            ScreenToEmpSalesTargetList(ref empSalesTargetList);

            // 削除リスト取得
            List<EmpSalesTarget> deleteList = new List<EmpSalesTarget>();
            foreach (EmpSalesTarget empSalesTarget in this._empSalesTargetDicClone.Values)
            {
                deleteList.Add(empSalesTarget);
            }

            // ---UPD 2010/12/20--------->>>>>
            //// 削除処理
            //if (deleteList.Count > 0)
            //{
            //    status = this._salesTargetAcs.Delete(deleteList);
            //    switch (status)
            //    {
            //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
            //            {
            //                break;
            //            }
            //        default:
            //            {
            //                ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //               "SaveProc",
            //               "保存処理に失敗しました。",
            //               status,
            //               MessageBoxButtons.OK);
            //                return (status);
            //            }
            //    }
            //}

            // 保存処理
            if (deleteList.Count > 0)
            {
                status = this._salesTargetAcs.WriteProc(ref empSalesTargetList, deleteList);
            }
            else
            {
                status = this._salesTargetAcs.Write(ref empSalesTargetList);
            }
            // ---UPD 2010/12/20---------<<<<<

            // ---DEL 2010/12/20--------->>>>>
            //// 保存処理
            //status = this._salesTargetAcs.Write(ref empSalesTargetList);
            // ---DEL 2010/12/20---------<<<<<
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);

                        // 編集モード設定
                        this.Mode_Label.Text = UPDATE_MODE;

                        // コントロールEnabled制御
                        SetControlEnabled(UPDATE_MODE);

                        // バッファ更新
                        this._empSalesTargetDicClone.Clear();
                        foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
                        {
                            this._empSalesTargetDicClone.Add(empSalesTarget.TargetDivideCode.Trim(), empSalesTarget);
                        }

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "SaveProc",
                                       "保存処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }

        /// <summary>
        /// 保存処理(得意先別売上目標)
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上目標設定を保存します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// <br>Update Note: 2010/12/20 曹文傑</br>
        /// <br>             障害改良対応１２月</br>
        /// </remarks>
        private int SaveCustSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 画面情報取得
            List<CustSalesTarget> custSalesTargetList = new List<CustSalesTarget>();
            ScreenToCustSalesTargetList(ref custSalesTargetList);

            // 削除リスト取得
            List<CustSalesTarget> deleteList = new List<CustSalesTarget>();
            foreach (CustSalesTarget custSalesTarget in this._custSalesTargetDicClone.Values)
            {
                deleteList.Add(custSalesTarget);
            }

            // ---UPD 2010/12/20--------->>>>>
            //if (deleteList.Count > 0)
            //{
            //    status = this._salesTargetAcs.Delete(deleteList);
            //    switch (status)
            //    {
            //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
            //            {
            //                break;
            //            }
            //        default:
            //            {
            //                ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //               "SaveProc",
            //               "保存処理に失敗しました。",
            //               status,
            //               MessageBoxButtons.OK);
            //                return (status);
            //            }
            //    }
            //}

            // 保存処理
            if (deleteList.Count > 0)
            {
                status = this._salesTargetAcs.WriteProc(ref custSalesTargetList, deleteList);
            }
            else
            {
                status = this._salesTargetAcs.Write(ref custSalesTargetList);
            }
            // ---UPD 2010/12/20---------<<<<<

            // ---DEL 2010/12/20--------->>>>>
            //// 保存処理
            //status = this._salesTargetAcs.Write(ref custSalesTargetList);
            // ---DEL 2010/12/20---------<<<<<
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);

                        // 編集モード設定
                        this.Mode_Label.Text = UPDATE_MODE;

                        // コントロールEnabled制御
                        SetControlEnabled(UPDATE_MODE);

                        // バッファ更新
                        this._custSalesTargetDicClone.Clear();
                        foreach (CustSalesTarget custSalesTarget in custSalesTargetList)
                        {
                            this._custSalesTargetDicClone.Add(custSalesTarget.TargetDivideCode.Trim(), custSalesTarget);
                        }

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "SaveProc",
                                       "保存処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }

        /// <summary>
        /// 保存処理(商品別売上目標)
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上目標設定を保存します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// <br>Update Note: 2010/12/20 曹文傑</br>
        /// <br>             障害改良対応１２月</br>
        /// </remarks>
        private int SaveGcdSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 画面情報取得
            List<GcdSalesTarget> gcdSalesTargetList = new List<GcdSalesTarget>();
            ScreenToGcdSalesTargetList(ref gcdSalesTargetList);

            // 削除リスト取得
            List<GcdSalesTarget> deleteList = new List<GcdSalesTarget>();
            foreach (GcdSalesTarget gcdSalesTarget in this._gcdSalesTargetDicClone.Values)
            {
                deleteList.Add(gcdSalesTarget);
            }

            // ---UPD 2010/12/20--------->>>>>
            //if (deleteList.Count > 0)
            //{
            //    status = this._salesTargetAcs.Delete(deleteList);
            //    switch (status)
            //    {
            //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
            //            {
            //                break;
            //            }
            //        default:
            //            {
            //                ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //               "SaveProc",
            //               "保存処理に失敗しました。",
            //               status,
            //               MessageBoxButtons.OK);
            //                return (status);
            //            }
            //    }
            //}

            if (deleteList.Count > 0)
            {
                // 保存処理
                status = this._salesTargetAcs.WriteProc(ref gcdSalesTargetList, deleteList);
            }
            else
            {
                // 保存処理
                status = this._salesTargetAcs.Write(ref gcdSalesTargetList);
            }
            // ---UPD 2010/12/20---------<<<<<

            // ---DEL 2010/12/20--------->>>>>
            //// 保存処理
            //status = this._salesTargetAcs.Write(ref gcdSalesTargetList);
            // ---DEL 2010/12/20---------<<<<<
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);

                        // 編集モード設定
                        this.Mode_Label.Text = UPDATE_MODE;

                        // コントロールEnabled制御
                        SetControlEnabled(UPDATE_MODE);

                        // バッファ更新
                        this._gcdSalesTargetDicClone.Clear();
                        foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetList)
                        {
                            this._gcdSalesTargetDicClone.Add(gcdSalesTarget.TargetDivideCode, gcdSalesTarget);
                        }

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "SaveProc",
                                       "保存処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        #endregion 保存処理

        #region 元に戻す処理
        /// <summary>
        /// 元に戻す処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面状態を元に戻します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int UndoProc()
        {
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                // 画面初期化
                ClearScreen();

                // ADD 2009/05/20 ------>>>
                // コントロールEnabled制御
                SetControlEnabled(INSERT_MODE);

                // 設定区分条件コントロールEnabled制御
                ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);
                // ADD 2009/05/20 ------<<<
            }
            else if (this.Mode_Label.Text == UPDATE_MODE)
            {
                // 設定区分
                int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                switch (targetContrastCd)
                {
                    case 10:    // 拠点
                    case 20:    // 拠点＋部門
                    case 221:   // 拠点＋担当者
                    case 222:   // 拠点＋受注者
                    case 223:   // 拠点＋発行者
                        {
                            // 画面展開
                            EmpSalesTargetToScreen(this._empSalesTargetDicClone);
                            break;
                        }
                    case 30:    // 拠点＋得意先
                    case 31:    // 拠点＋業種
                    case 32:    // 拠点＋地区
                        {
                            // 画面展開
                            CustSalesTargetToScreen(this._custSalesTargetDicClone);
                            break;
                        }
                    default:    // 拠点＋販売区分、商品区分
                        {
                            // 画面展開
                            GcdSalesTargetToScreen(this._gcdSalesTargetDicClone);
                            break;
                        }
                }
            }
            return 0;
        }
        #endregion 元に戻す処理

        #region 論理削除処理
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上目標設定を論理削除します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int LogicalDeleteProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 設定区分
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 10:    // 拠点
                case 20:    // 拠点＋部門
                case 221:   // 拠点＋担当者
                case 222:   // 拠点＋受注者
                case 223:   // 拠点＋発行者
                    {
                        status = LogicalDeleteEmpSalesTarget();
                        break;
                    }
                case 30:    // 拠点＋得意先
                case 31:    // 拠点＋業種
                case 32:    // 拠点＋地区
                    {
                        status = LogicalDeleteCustSalesTarget();
                        break;
                    }
                default:    // 拠点＋販売区分、商品区分
                    {
                        status = LogicalDeleteGcdSalesTarget();
                        break;
                    }
            }

            return (status);
        }

        /// <summary>
        /// 論理削除処理(従業員別売上目標)
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上目標設定を論理削除します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int LogicalDeleteEmpSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<EmpSalesTarget> empSalesTargetList = new List<EmpSalesTarget>();
            foreach (EmpSalesTarget empSalesTarget in this._empSalesTargetDicClone.Values)
            {
                empSalesTargetList.Add(empSalesTarget);
            }

            // 論理削除
            status = this._salesTargetAcs.LogicalDelete(ref empSalesTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 編集モード変更
                        this.Mode_Label.Text = DELETE_MODE;

                        // コントロールEnabled制御
                        SetControlEnabled(DELETE_MODE);

                        // バッファ更新
                        this._empSalesTargetDicClone.Clear();
                        foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
                        {
                            this._empSalesTargetDicClone.Add(empSalesTarget.TargetDivideCode.Trim(), empSalesTarget);
                        }

                        // 画面展開
                        EmpSalesTargetToScreen(this._empSalesTargetDicClone);

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "LogicalDeleteProc",
                                       "削除処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }

        /// <summary>
        /// 論理削除処理(得意先別売上目標)
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上目標設定を論理削除します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int LogicalDeleteCustSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<CustSalesTarget> custSalesTargetList = new List<CustSalesTarget>();
            foreach (CustSalesTarget custSalesTarget in this._custSalesTargetDicClone.Values)
            {
                custSalesTargetList.Add(custSalesTarget);
            }

            // 論理削除
            status = this._salesTargetAcs.LogicalDelete(ref custSalesTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 編集モード変更
                        this.Mode_Label.Text = DELETE_MODE;

                        // コントロールEnabled制御
                        SetControlEnabled(DELETE_MODE);

                        // バッファ更新
                        this._custSalesTargetDicClone.Clear();
                        foreach (CustSalesTarget custSalesTarget in custSalesTargetList)
                        {
                            this._custSalesTargetDicClone.Add(custSalesTarget.TargetDivideCode.Trim(), custSalesTarget);
                        }

                        // 画面展開
                        CustSalesTargetToScreen(this._custSalesTargetDicClone);

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "LogicalDeleteProc",
                                       "削除処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }

        /// <summary>
        /// 論理削除処理(商品別売上目標)
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上目標設定を論理削除します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int LogicalDeleteGcdSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<GcdSalesTarget> gcdSalesTargetList = new List<GcdSalesTarget>();
            foreach (GcdSalesTarget gcdSalesTarget in this._gcdSalesTargetDicClone.Values)
            {
                gcdSalesTargetList.Add(gcdSalesTarget);
            }

            // 論理削除
            status = this._salesTargetAcs.LogicalDelete(ref gcdSalesTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 編集モード変更
                        this.Mode_Label.Text = DELETE_MODE;

                        // コントロールEnabled制御
                        SetControlEnabled(DELETE_MODE);

                        // バッファ更新
                        this._gcdSalesTargetDicClone.Clear();
                        foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetList)
                        {
                            this._gcdSalesTargetDicClone.Add(gcdSalesTarget.TargetDivideCode.Trim(), gcdSalesTarget);
                        }

                        // 画面展開
                        GcdSalesTargetToScreen(this._gcdSalesTargetDicClone);

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "LogicalDeleteProc",
                                       "削除処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        #endregion 論理削除処理

        #region 物理削除処理
        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上目標設定を物理削除します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int DeleteProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 設定区分
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 10:    // 拠点
                case 20:    // 拠点＋部門
                case 221:   // 拠点＋担当者
                case 222:   // 拠点＋受注者
                case 223:   // 拠点＋発行者
                    {
                        List<EmpSalesTarget> empSalesTargetList = new List<EmpSalesTarget>();
                        foreach (EmpSalesTarget empSalesTarget in this._empSalesTargetDicClone.Values)
                        {
                            empSalesTargetList.Add(empSalesTarget);
                        }

                        // 物理削除
                        status = this._salesTargetAcs.Delete(empSalesTargetList);
                        break;
                    }
                case 30:    // 拠点＋得意先
                case 31:    // 拠点＋業種
                case 32:    // 拠点＋地区
                    {
                        List<CustSalesTarget> custSalesTargetList = new List<CustSalesTarget>();
                        foreach (CustSalesTarget custSalesTarget in this._custSalesTargetDicClone.Values)
                        {
                            custSalesTargetList.Add(custSalesTarget);
                        }

                        // 物理削除
                        status = this._salesTargetAcs.Delete(custSalesTargetList);
                        break;
                    }
                default:    // 拠点＋販売区分、商品区分
                    {
                        List<GcdSalesTarget> gcdSalesTargetList = new List<GcdSalesTarget>();
                        foreach (GcdSalesTarget gcdSalesTarget in this._gcdSalesTargetDicClone.Values)
                        {
                            gcdSalesTargetList.Add(gcdSalesTarget);
                        }

                        // 物理削除
                        status = this._salesTargetAcs.Delete(gcdSalesTargetList);
                        break;
                    }
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 編集モード変更
                        this.Mode_Label.Text = INSERT_MODE;

                        // コントロールEnabled制御
                        SetControlEnabled(INSERT_MODE);

                        // ADD 2009/05/20 ------>>>
                        // 設定区分条件コントロールEnabled制御
                        ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);
                        // ADD 2009/05/20 ------<<<
                        
                        // 画面クリア
                        ClearScreen();

                        this.tNedit_Year.Focus(); // 2011.07.18 wangf add

                        // バッファ更新
                        this._empSalesTargetDicClone.Clear();
                        this._custSalesTargetDicClone.Clear();
                        this._gcdSalesTargetDicClone.Clear();

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "DeleteProc",
                                       "完全削除処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        #endregion 物理削除処理

        #region 復活処理
        /// <summary>
        /// 復活処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上目標設定を復活します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int RevivalProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 設定区分
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 10:    // 拠点
                case 20:    // 拠点＋部門
                case 221:   // 拠点＋担当者
                case 222:   // 拠点＋受注者
                case 223:   // 拠点＋発行者
                    {
                        status = RevivalEmpSalesTarget();
                        break;
                    }
                case 30:    // 拠点＋得意先
                case 31:    // 拠点＋業種
                case 32:    // 拠点＋地区
                    {
                        status = RevivalCustSalesTarget();
                        break;
                    }
                default:    // 拠点＋販売区分、商品区分
                    {
                        status = RevivalGcdSalesTarget();
                        break;
                    }
            }

            return (status);
        }

        /// <summary>
        /// 復活処理(従業員別売上目標)
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上目標設定を復活します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int RevivalEmpSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<EmpSalesTarget> empSalesTargetList = new List<EmpSalesTarget>();
            foreach (EmpSalesTarget empSalesTarget in this._empSalesTargetDicClone.Values)
            {
                empSalesTargetList.Add(empSalesTarget);
            }

            // 復活
            status = this._salesTargetAcs.Revival(ref empSalesTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 編集モード変更
                        this.Mode_Label.Text = UPDATE_MODE;

                        // コントロールEnabled制御
                        SetControlEnabled(UPDATE_MODE);

                        // バッファ更新
                        this._empSalesTargetDicClone.Clear();
                        foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
                        {
                            this._empSalesTargetDicClone.Add(empSalesTarget.TargetDivideCode.Trim(), empSalesTarget);
                        }

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "RevivalProc",
                                       "復活処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }

        /// <summary>
        /// 復活処理(得意先別売上目標)
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上目標設定を復活します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int RevivalCustSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<CustSalesTarget> custSalesTargetList = new List<CustSalesTarget>();
            foreach (CustSalesTarget custSalesTarget in this._custSalesTargetDicClone.Values)
            {
                custSalesTargetList.Add(custSalesTarget);
            }

            // 復活
            status = this._salesTargetAcs.Revival(ref custSalesTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 編集モード変更
                        this.Mode_Label.Text = UPDATE_MODE;

                        // コントロールEnabled制御
                        SetControlEnabled(UPDATE_MODE);

                        // バッファ更新
                        this._custSalesTargetDicClone.Clear();
                        foreach (CustSalesTarget custSalesTarget in custSalesTargetList)
                        {
                            this._custSalesTargetDicClone.Add(custSalesTarget.TargetDivideCode.Trim(), custSalesTarget);
                        }

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "RevivalProc",
                                       "復活処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }

        /// <summary>
        /// 復活処理(商品別売上目標)
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上目標設定を復活します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int RevivalGcdSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<GcdSalesTarget> gcdSalesTargetList = new List<GcdSalesTarget>();
            foreach (GcdSalesTarget gcdSalesTarget in this._gcdSalesTargetDicClone.Values)
            {
                gcdSalesTargetList.Add(gcdSalesTarget);
            }

            // 復活
            status = this._salesTargetAcs.Revival(ref gcdSalesTargetList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 編集モード変更
                        this.Mode_Label.Text = UPDATE_MODE;

                        // コントロールEnabled制御
                        SetControlEnabled(UPDATE_MODE);

                        // バッファ更新
                        this._gcdSalesTargetDicClone.Clear();
                        foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetList)
                        {
                            this._gcdSalesTargetDicClone.Add(gcdSalesTarget.TargetDivideCode.Trim(), gcdSalesTarget);
                        }

                        return (status);
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "RevivalProc",
                                       "復活処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (status);
                    }
            }
        }
        #endregion 復活処理

        #region 比率から計算処理
        /// <summary>
        /// 比率から計算処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 比率から目標を自動計算します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int CalcProc()
        {
            // 計算前チェック
            bool bStatus = CheckBeforeCalc();
            if (!bStatus)
            {
                return -1;
            }

            // 比率
            double ratio = 0;
            // 比率合計
            double totalRatio = 0;
            // 比率格納配列
            double[] ratioArray = new double[12];

            //-----------------------------------
            // 合計比率取得＋各比率格納
            //-----------------------------------
            for (int index = 0; index < 12; index++)
            {
                // セル値変換
                ratio = ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_RATIO].Value);
                totalRatio += ratio;
                ratioArray[index] = ratio;
            }

            //-----------------------------------
            // グリッドクリア
            //-----------------------------------
            for (int index = 0; index < 13; index++)
            {
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = "";
            }

            long targetValue = 0;

            //-----------------------------------
            // 売上目標値設定
            //-----------------------------------
            if (this.tNedit_SalesTargetSale.GetInt() != 0)
            {
                // 売上目標(年間)
                double salesTarget = this.tNedit_SalesTargetSale.GetInt();
                
                long totalValue = 0;

                for (int index = 0; index < 12; index++)
                {
                    if (ratioArray[index] == 0)
                    {
                        this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = "";
                    }
                    else
                    {
                        targetValue = (long)(salesTarget * ratioArray[index] / totalRatio);
                        totalValue += targetValue;
                        this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = targetValue.ToString(FORMAT_NUM);
                    }
                }
                
                // 年間目標値と整合性をとります
                for (int index = 11; index >= 0; index--)
                {
                    if (ratioArray[index] != 0)
                    {
                        this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = (targetValue + salesTarget - totalValue).ToString(FORMAT_NUM);
                        break;
                    }
                }

                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_SALESTARGET].Value = salesTarget.ToString(FORMAT_NUM);
            }

            //-----------------------------------
            // 粗利目標値設定
            //-----------------------------------
            if (this.tNedit_SalesTargetProfit.GetInt() != 0)
            {
                // 粗利目標(年間)
                double profitTarget = this.tNedit_SalesTargetProfit.GetInt();

                long totalValue = 0;

                for (int index = 0; index < 12; index++)
                {
                    if (ratioArray[index] == 0)
                    {
                        this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = "";
                    }
                    else
                    {
                        targetValue = (long)(profitTarget * ratioArray[index] / totalRatio);
                        totalValue += targetValue;
                        this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = targetValue.ToString(FORMAT_NUM);
                    }
                }

                // 年間目標値と整合性をとります
                for (int index = 11; index >= 0; index--)
                {
                    if (ratioArray[index] != 0)
                    {
                        this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = (targetValue + profitTarget - totalValue).ToString(FORMAT_NUM);
                        break;
                    }
                }

                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_PROFITTARGET].Value = profitTarget.ToString(FORMAT_NUM);
            }

            //-----------------------------------
            // 数量目標値設定
            //-----------------------------------
            if (this.tNedit_SalesTargetCount.GetInt() != 0)
            {
                // 数量目標(年間)
                double countTarget = this.tNedit_SalesTargetCount.GetInt();

                long totalValue = 0;

                for (int index = 0; index < 12; index++)
                {
                    if (ratioArray[index] == 0)
                    {
                        this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = "";
                    }
                    else
                    {
                        targetValue = (long)(countTarget * ratioArray[index] / totalRatio);
                        totalValue += targetValue;
                        this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = targetValue.ToString(FORMAT_NUM);
                    }
                }

                // 年間目標値と整合性をとります
                for (int index = 11; index >= 0; index--)
                {
                    if (ratioArray[index] != 0)
                    {
                        this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = (targetValue + countTarget - totalValue).ToString(FORMAT_NUM);
                        break;
                    }
                }

                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_COUNTTARGET].Value = countTarget.ToString(FORMAT_NUM);
            }

            return 0;
        }
        #endregion 比率から計算処理

        #region 最新情報取得処理
        /// <summary>
        /// 最新情報取得処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 最新情報を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int RenewalProc()
        {
            // 各種マスタ取得
            bool bStatus = ReadMaster();
            if (!bStatus)
            {
                return (-1);
            }

            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "最新情報を取得しました。",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);

            return (0);
        }
        #endregion 最新情報取得処理

        #region チェック処理
        /// <summary>
        /// 計算前チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 比率から計算前に入力チェックを行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private bool CheckBeforeCalc()
        {
            string errMsg = "";

            try
            {
                // 年間目標が未入力の場合
                if ((this.tNedit_SalesTargetSale.GetInt() == 0) &&
                    (this.tNedit_SalesTargetProfit.GetInt() == 0) &&
                    (this.tNedit_SalesTargetCount.GetInt() == 0))
                {
                    errMsg = "年間目標を入力してください。";
                    this.tNedit_SalesTargetSale.Focus();
                    return (false);
                }

                double totalRatio = 0;
                for (int index = 0; index < 12; index++)
                {
                    // セル値変換
                    totalRatio += ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_RATIO].Value);
                }
                // 比率が未入力の場合
                if (totalRatio == 0)
                {
                    errMsg = "月別比率を入力してください。";
                    this.SalesTarget_uGrid.Focus();
                    this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_RATIO].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="beforeSaveFlg">保存前フラグ(True:保存前 False:検索時)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面情報の入力チェックを行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private bool CheckScreenInput(bool beforeSaveFlg)
        {
            bool bStatus;

            // 入力チェック(条件)
            bStatus = CheckCondition(beforeSaveFlg);
            if (!bStatus)
            {
                return (false);
            }

            if (beforeSaveFlg == true)
            {
                // 入力チェック(目標)
                bStatus = CheckSalesTarget();
                if (!bStatus)
                {
                    return (false);
                }
            }

            return (true);
        }

        /// <summary>
        /// 入力チェック処理(条件)
        /// </summary>
        /// <param name="beforeSaveFlg">保存前フラグ(True:保存前 False:検索時)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面情報の入力チェックを行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private bool CheckCondition(bool beforeSaveFlg)
        {
            // 一括ゼロ詰め
            this.uiSetControl1.SettingAllControlsZeroPaddedText();

            string errMsg = "";
            Control control = null;

            try
            {
                if (this.tNedit_Year.GetInt() == 0)
                {
                    errMsg = "年度を入力してください。";
                    control = this.tNedit_Year;
                    return (false);
                }

                // 設定区分
                int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                switch (targetContrastCd)
                {
                    case 45:
                        {
                            if (this.tNedit_EnterpriseGanreCode.GetInt() == 0)
                            {
                                errMsg = "商品区分を入力してください。";
                                control = this.tNedit_EnterpriseGanreCode;
                                return (false);
                            }

                            int enterpriseGanreCode = this.tNedit_EnterpriseGanreCode.GetInt();
                            if (GetEnterpriseGanreName(enterpriseGanreCode) == "")
                            {
                                errMsg = "マスタに登録されていません。";
                                control = this.tNedit_EnterpriseGanreCode;
                                return (false);
                            }
                            break;
                        }
                    default:
                        {
                            if (this.tEdit_SectionCode.DataText.Trim() == "")
                            {
                                errMsg = "拠点を入力してください。";
                                control = this.tEdit_SectionCode;
                                return (false);
                            }

                            string sectionCode = this.tEdit_SectionCode.DataText.Trim();
                            if (GetSectionName(sectionCode) == "")
                            {
                                errMsg = "マスタに登録されていません。";
                                control = this.tEdit_SectionCode;
                                return (false);
                            }

                            if (targetContrastCd == 20)
                            {
                                if (this.tNedit_SubSectionCode.GetInt() == 0)
                                {
                                    errMsg = "部門を入力してください。";
                                    control = this.tNedit_SubSectionCode;
                                    return (false);
                                }

                                int subSectionCode = this.tNedit_SubSectionCode.GetInt();
                                if (GetSubSectionName(subSectionCode) == "")
                                {
                                    errMsg = "マスタに登録されていません。";
                                    control = this.tNedit_SubSectionCode;
                                    return (false);
                                }
                            }
                            else if (targetContrastCd == 30)
                            {
                                if (this.tNedit_CustomerCode.GetInt() == 0)
                                {
                                    errMsg = "得意先を入力してください。";
                                    control = this.tNedit_CustomerCode;
                                    return (false);
                                }

                                int customerCode = this.tNedit_CustomerCode.GetInt();
                                //if (GetCustomerName(customerCode) == "")  // DEL 2009/06/29
                                if (!CheckCustomer(customerCode))   // ADD 2009/06/29
                                {
                                    errMsg = "マスタに登録されていません。";
                                    control = this.tNedit_CustomerCode;
                                    return (false);
                                }
                            }
                            else if ((targetContrastCd == 221) || (targetContrastCd == 222) || (targetContrastCd == 223))
                            {
                                if (this.tEdit_EmployeeCode.DataText.Trim() == "")
                                {
                                    if (targetContrastCd == 221)
                                    {
                                        errMsg = "担当者を入力してください。";
                                    }
                                    else if (targetContrastCd == 222)
                                    {
                                        errMsg = "受注者を入力してください。";
                                    }
                                    else
                                    {
                                        errMsg = "発行者を入力してください。";
                                    }
                                    control = this.tEdit_EmployeeCode;
                                    return (false);
                                }

                                string employeeCode = this.tEdit_EmployeeCode.DataText.Trim();
                                if (GetEmployeeName(employeeCode) == "")
                                {
                                    errMsg = "マスタに登録されていません。";
                                    control = this.tEdit_EmployeeCode;
                                    return (false);
                                }
                            }
                            else if (targetContrastCd == 32)
                            {
                                if (this.tNedit_SalesAreaCode.GetInt() == 0)
                                {
                                    errMsg = "地区を入力してください。";
                                    control = this.tNedit_SalesAreaCode;
                                    return (false);
                                }

                                int salesAreaCode = this.tNedit_SalesAreaCode.GetInt();
                                if (GetSalesAreaName(salesAreaCode) == "")
                                {
                                    errMsg = "マスタに登録されていません。";
                                    control = this.tNedit_SalesAreaCode;
                                    return (false);
                                }
                            }
                            else if (targetContrastCd == 31)
                            {
                                if (this.tNedit_BusinessTypeCode.GetInt() == 0)
                                {
                                    errMsg = "業種を入力してください。";
                                    control = this.tNedit_BusinessTypeCode;
                                    return (false);
                                }

                                int businessTypeCode = this.tNedit_BusinessTypeCode.GetInt();
                                if (GetBusinessTypeName(businessTypeCode) == "")
                                {
                                    errMsg = "マスタに登録されていません。";
                                    control = this.tNedit_BusinessTypeCode;
                                    return (false);
                                }
                            }
                            else if (targetContrastCd == 44)
                            {
                                if (this.tNedit_SalesCode.GetInt() == 0)
                                {
                                    errMsg = "販売区分を入力してください。";
                                    control = this.tNedit_SalesCode;
                                    return (false);
                                }

                                int salesCode = this.tNedit_SalesCode.GetInt();
                                if (GetSalesCodeName(salesCode) == "")
                                {
                                    errMsg = "マスタに登録されていません。";
                                    control = this.tNedit_SalesCode;
                                    return (false);
                                }
                            }

                            break;
                        }
                }
            }
            finally
            {
                if ((errMsg.Length > 0) && (beforeSaveFlg == true))
                {
                    control.Focus();

                    ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// 入力チェック処理(目標)
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面情報の入力チェックを行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private bool CheckSalesTarget()
        {
            string errMsg = "";

            try
            {
                bool inputFlg = false;
                for (int index = 0; index < 12; index++)
                {
                    // セル値変換
                    if ((ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value) == 0) &&
                        (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value) == 0) &&
                        (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value) == 0))
                    {
                        continue;
                    }

                    inputFlg = true;
                }

                if (inputFlg == false)
                {
                    errMsg = "目標を入力してください。";
                    this.SalesTarget_uGrid.Focus();
                    this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_SALESTARGET].Activate();
                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// 画面情報変更チェック処理
        /// </summary>
        /// <returns>ステータス(True:変更なし　False:変更あり)</returns>
        /// <remarks>
        /// <br>Note       : 画面情報が変更されているかどうかチェックします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private bool CompareInputScreen()
        {
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                if (this.tNedit_Year.GetInt() != this._thisYear)
                {
                    return (false);
                }
                if ((int)this.tComboEditor_TargetContrastCd.Value != 10)
                {
                    return (false);
                }
                if (this.tEdit_SectionCode.DataText.Trim() != "")
                {
                    return (false);
                }
                if (this.tNedit_SubSectionCode.GetInt() != 0)
                {
                    return (false);
                }
                if (this.tNedit_CustomerCode.GetInt() != 0)
                {
                    return (false);
                }
                if (this.tEdit_EmployeeCode.DataText.Trim() != "")
                {
                    return (false);
                }
                if (this.tNedit_SalesAreaCode.GetInt() != 0)
                {
                    return (false);
                }
                if (this.tNedit_BusinessTypeCode.GetInt() != 0)
                {
                    return (false);
                }
                if (this.tNedit_SalesCode.GetInt() != 0)
                {
                    return (false);
                }
                if (this.tNedit_EnterpriseGanreCode.GetInt() != 0)
                {
                    return (false);
                }
            }

            return CompareInputGrid();
        }

        /// <summary>
        /// グリッド情報変更チェック処理
        /// </summary>
        /// <returns>ステータス(True:変更なし　False:変更あり)</returns>
        /// <remarks>
        /// <br>Note       : グリッドが変更されているかどうかチェックします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private bool CompareInputGrid()
        {
            // 設定区分
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 10:    // 拠点
                case 20:    // 拠点＋部門
                case 221:   // 拠点＋担当者
                case 222:   // 拠点＋受注者
                case 223:   // 拠点＋発行者
                    {
                        List<EmpSalesTarget> empSalesTargetList = new List<EmpSalesTarget>();
                        ScreenToEmpSalesTargetList(ref empSalesTargetList);

                        if (empSalesTargetList.Count != this._empSalesTargetDicClone.Count)
                        {
                            return (false);
                        }

                        string targetDivideCode;
                        foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
                        {
                            targetDivideCode = empSalesTarget.TargetDivideCode.Trim();
                            if (!this._empSalesTargetDicClone.ContainsKey(targetDivideCode))
                            {
                                return (false);
                            }

                            if (empSalesTarget.SalesTargetMoney != this._empSalesTargetDicClone[targetDivideCode].SalesTargetMoney)
                            {
                                return (false);
                            }

                            if (empSalesTarget.SalesTargetProfit != this._empSalesTargetDicClone[targetDivideCode].SalesTargetProfit)
                            {
                                return (false);
                            }

                            if (empSalesTarget.SalesTargetCount != this._empSalesTargetDicClone[targetDivideCode].SalesTargetCount)
                            {
                                return (false);
                            }
                        }
                        break;
                    }
                case 30:    // 拠点＋得意先
                case 31:    // 拠点＋業種
                case 32:    // 拠点＋地区
                    {
                        List<CustSalesTarget> custSalesTargetList = new List<CustSalesTarget>();
                        ScreenToCustSalesTargetList(ref custSalesTargetList);

                        if (custSalesTargetList.Count != this._custSalesTargetDicClone.Count)
                        {
                            return (false);
                        }

                        string targetDivideCode;
                        foreach (CustSalesTarget custSalesTarget in custSalesTargetList)
                        {
                            targetDivideCode = custSalesTarget.TargetDivideCode.Trim();
                            if (!this._custSalesTargetDicClone.ContainsKey(targetDivideCode))
                            {
                                return (false);
                            }

                            if (custSalesTarget.SalesTargetMoney != this._custSalesTargetDicClone[targetDivideCode].SalesTargetMoney)
                            {
                                return (false);
                            }

                            if (custSalesTarget.SalesTargetProfit != this._custSalesTargetDicClone[targetDivideCode].SalesTargetProfit)
                            {
                                return (false);
                            }

                            if (custSalesTarget.SalesTargetCount != this._custSalesTargetDicClone[targetDivideCode].SalesTargetCount)
                            {
                                return (false);
                            }
                        }
                        break;
                    }
                default:    // 拠点＋販売区分、商品区分
                    {
                        List<GcdSalesTarget> gcdSalesTargetList = new List<GcdSalesTarget>();
                        ScreenToGcdSalesTargetList(ref gcdSalesTargetList);

                        if (gcdSalesTargetList.Count != this._gcdSalesTargetDicClone.Count)
                        {
                            return (false);
                        }

                        string targetDivideCode;
                        foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetList)
                        {
                            targetDivideCode = gcdSalesTarget.TargetDivideCode.Trim();
                            if (!this._gcdSalesTargetDicClone.ContainsKey(targetDivideCode))
                            {
                                return (false);
                            }

                            if (gcdSalesTarget.SalesTargetMoney != this._gcdSalesTargetDicClone[targetDivideCode].SalesTargetMoney)
                            {
                                return (false);
                            }

                            if (gcdSalesTarget.SalesTargetProfit != this._gcdSalesTargetDicClone[targetDivideCode].SalesTargetProfit)
                            {
                                return (false);
                            }

                            if (gcdSalesTarget.SalesTargetCount != this._gcdSalesTargetDicClone[targetDivideCode].SalesTargetCount)
                            {
                                return (false);
                            }
                        }
                        break;
                    }
            }

            return (true);
        }

        private bool CheckSaveConfirm()
        {
            if (this.tNedit_Year.GetInt() == 0)
            {
                return (false);
            }

            // 設定区分
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 45:
                    {
                        if (this.tNedit_EnterpriseGanreCode.GetInt() == 0)
                        {
                            return (false);
                        }

                        int enterpriseGanreCode = this.tNedit_EnterpriseGanreCode.GetInt();
                        if (GetEnterpriseGanreName(enterpriseGanreCode) == "")
                        {
                            return (false);
                        }
                        break;
                    }
                default:
                    {
                        if (this.tEdit_SectionCode.DataText.Trim() == "")
                        {
                            return (false);
                        }

                        string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
                        if (GetSectionName(sectionCode) == "")
                        {
                            return (false);
                        }

                        if (targetContrastCd == 20)
                        {
                            if (this.tNedit_SubSectionCode.GetInt() == 0)
                            {
                                return (false);
                            }

                            int subSectionCode = this.tNedit_SubSectionCode.GetInt();
                            if (GetSubSectionName(subSectionCode) == "")
                            {
                                return (false);
                            }
                        }
                        else if (targetContrastCd == 30)
                        {
                            if (this.tNedit_CustomerCode.GetInt() == 0)
                            {
                                return (false);
                            }

                            int customerCode = this.tNedit_CustomerCode.GetInt();
                            //if (GetCustomerName(customerCode) == "")  // DEL 2009/06/29
                            if (!CheckCustomer(customerCode))   // ADD 2009/06/29
                            {
                                return (false);
                            }
                        }
                        else if ((targetContrastCd == 221) || (targetContrastCd == 222) || (targetContrastCd == 223))
                        {
                            if (this.tEdit_EmployeeCode.DataText.Trim() == "")
                            {
                                return (false);
                            }

                            string employeeCode = this.tEdit_EmployeeCode.DataText.Trim().PadLeft(4, '0');
                            if (GetEmployeeName(employeeCode) == "")
                            {
                                return (false);
                            }
                        }
                        else if (targetContrastCd == 32)
                        {
                            if (this.tNedit_SalesAreaCode.GetInt() == 0)
                            {
                                return (false);
                            }

                            int salesAreaCode = this.tNedit_SalesAreaCode.GetInt();
                            if (GetSalesAreaName(salesAreaCode) == "")
                            {
                                return (false);
                            }
                        }
                        else if (targetContrastCd == 31)
                        {
                            if (this.tNedit_BusinessTypeCode.GetInt() == 0)
                            {
                                return (false);
                            }

                            int businessTypeCode = this.tNedit_BusinessTypeCode.GetInt();
                            if (GetBusinessTypeName(businessTypeCode) == "")
                            {
                                return (false);
                            }
                        }
                        else if (targetContrastCd == 44)
                        {
                            if (this.tNedit_SalesCode.GetInt() == 0)
                            {
                                return (false);
                            }

                            int salesCode = this.tNedit_SalesCode.GetInt();
                            if (GetSalesCodeName(salesCode) == "")
                            {
                                return (false);
                            }
                        }

                        break;
                    }
            }

            // ADD 2009/05/20 ------>>>
            // 新規でキー項目が全て入力OKの場合、キーコントロールのDisable制御
            SetKeyControlDisable();
            // ADD 2009/05/20 ------<<<
            
            return (true);
        }
        #endregion チェック処理

        #region 検索処理
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上目標設定マスタを検索します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int SearchProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            bool bStatus;

            // 検索条件チェック
            bStatus = CheckScreenInput(false);
            if (!bStatus)
            {
                return (-1);
            }

            // 設定区分
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 10:    // 拠点
                case 20:    // 拠点＋部門
                case 221:   // 拠点＋担当者
                case 222:   // 拠点＋受注者
                case 223:   // 拠点＋発行者
                    {
                        status = SearchEmpSalesTarget();
                        break;
                    }
                case 30:    // 拠点＋得意先
                case 31:    // 拠点＋業種
                case 32:    // 拠点＋地区
                    {
                        status = SearchCustSalesTarget();
                        break;
                    }
                default:    // 拠点＋販売区分、商品区分
                    {
                        status = SearchGcdSalesTarget();
                        break;
                    }
            }
            
            return (status);
        }

        /// <summary>
        /// 検索処理(従業員別売上目標設定)
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上目標設定マスタを検索します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int SearchEmpSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // 検索条件設定
            SearchEmpSalesTargetPara searchPara = new SearchEmpSalesTargetPara();
            SetSearchEmpSalesTargetPara(ref searchPara);

            List<EmpSalesTarget> empSalesTargetList;

            // 検索
            status = this._salesTargetAcs.Search(out empSalesTargetList, searchPara, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 編集モード設定
                        if (empSalesTargetList[0].LogicalDeleteCode == 0)
                        {
                            this.Mode_Label.Text = UPDATE_MODE;

                            // コントロールEnabled制御
                            SetControlEnabled(UPDATE_MODE);
                        }
                        else
                        {
                            this.Mode_Label.Text = DELETE_MODE;

                            // コントロールEnabled制御
                            SetControlEnabled(DELETE_MODE);
                        }

                        // バッファ更新
                        this._empSalesTargetDicClone.Clear();
                        foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
                        {
                            this._empSalesTargetDicClone.Add(empSalesTarget.TargetDivideCode.Trim(), empSalesTarget);
                        }

                        // 画面展開
                        EmpSalesTargetToScreen(this._empSalesTargetDicClone);

                        break;
                    }
                default:
                    {
                        this.Mode_Label.Text = INSERT_MODE;
                        break;
                    }
            }

            this._searchFlg = true;

            return (status);
        }

        /// <summary>
        /// 検索処理(得意先別売上目標設定)
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上目標設定マスタを検索します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int SearchCustSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // 検索条件設定
            SearchCustSalesTargetPara searchPara = new SearchCustSalesTargetPara();
            SetSearchCustSalesTargetPara(ref searchPara);

            List<CustSalesTarget> custSalesTargetList;

            // 検索
            status = this._salesTargetAcs.Search(out custSalesTargetList, searchPara, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 編集モード設定
                        if (custSalesTargetList[0].LogicalDeleteCode == 0)
                        {
                            this.Mode_Label.Text = UPDATE_MODE;

                            // コントロールEnabled制御
                            SetControlEnabled(UPDATE_MODE);
                        }
                        else
                        {
                            this.Mode_Label.Text = DELETE_MODE;

                            // コントロールEnabled制御
                            SetControlEnabled(DELETE_MODE);
                        }

                        // バッファ更新
                        this._custSalesTargetDicClone.Clear();
                        foreach (CustSalesTarget custSalesTarget in custSalesTargetList)
                        {
                            this._custSalesTargetDicClone.Add(custSalesTarget.TargetDivideCode.Trim(), custSalesTarget);
                        }

                        // 画面展開
                        CustSalesTargetToScreen(this._custSalesTargetDicClone);

                        break;
                    }
                default:
                    {
                        this.Mode_Label.Text = INSERT_MODE;
                        break;
                    }
            }

            this._searchFlg = true;

            return (status);
        }

        /// <summary>
        /// 検索処理(商品別売上目標設定)
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上目標設定マスタを検索します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private int SearchGcdSalesTarget()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // 検索条件設定
            SearchGcdSalesTargetPara searchPara = new SearchGcdSalesTargetPara();
            SetSearchGcdSalesTargetPara(ref searchPara);

            List<GcdSalesTarget> gcdSalesTargetList;

            // 検索
            status = this._salesTargetAcs.Search(out gcdSalesTargetList, searchPara, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 編集モード設定
                        if (gcdSalesTargetList[0].LogicalDeleteCode == 0)
                        {
                            this.Mode_Label.Text = UPDATE_MODE;

                            // コントロールEnabled制御
                            SetControlEnabled(UPDATE_MODE);
                        }
                        else
                        {
                            this.Mode_Label.Text = DELETE_MODE;

                            // コントロールEnabled制御
                            SetControlEnabled(DELETE_MODE);
                        }

                        // バッファ更新
                        this._gcdSalesTargetDicClone.Clear();
                        foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetList)
                        {
                            this._gcdSalesTargetDicClone.Add(gcdSalesTarget.TargetDivideCode.Trim(), gcdSalesTarget);
                        }

                        // 画面展開
                        GcdSalesTargetToScreen(this._gcdSalesTargetDicClone);

                        break;
                    }
                default:
                    {
                        this.Mode_Label.Text = INSERT_MODE;
                        break;
                    }
            }

            this._searchFlg = true;

            return (status);
        }
        #endregion 検索処理

        #region グリッド関連
        /// <summary>
        /// 合計目標取得処理
        /// </summary>
        /// <param name="columnIndex">列インデックス(2:売上目標 3:粗利目標 4:数量目標)</param>
        /// <returns>合計目標</returns>
        /// <remarks>
        /// <br>Note       : 合計目標を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private double GetTotalTarget(int columnIndex)
        {
            double totalTarget = 0;

            if (columnIndex < 2)
            {
                return totalTarget;
            }

            for (int index = 0; index < 12; index++)
            {
                if ((this.SalesTarget_uGrid.Rows[index].Cells[columnIndex].Value == DBNull.Value) ||
                    ((string)this.SalesTarget_uGrid.Rows[index].Cells[columnIndex].Value == ""))
                {
                    continue;
                }

                totalTarget += double.Parse((string)this.SalesTarget_uGrid.Rows[index].Cells[columnIndex].Value);
            }

            return totalTarget;
        }

        /// <summary>
        /// セル値変換処理(セル値→Double型)
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <returns>セル値</returns>
        /// <remarks>
        /// <br>Note       : セル値をDouble型に変換します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private double ChangeCellValue(object cellValue)
        {
            double target = 0;

            if ((cellValue != DBNull.Value) && (cellValue != null) && ((string)cellValue != ""))
            {
                target = double.Parse((string)cellValue);
            }

            return target;
        }
        #endregion グリッド関連

        #region 検索条件設定
        /// <summary>
        /// 検索条件設定処理(従業員別売上目標)
        /// </summary>
        /// <param name="searchPara">従業員別売上目標検索条件</param>
        /// <remarks>
        /// <br>Note       : 検索条件を設定します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// <br>Update Note: 2010/12/20 曹文傑</br>
        /// <br>             障害改良対応１２月</br>
        /// </remarks>
        private void SetSearchEmpSalesTargetPara(ref SearchEmpSalesTargetPara searchPara)
        {
            // 企業コード
            searchPara.EnterpriseCode = this._enterpriseCode;
            // 拠点コード
            searchPara.SelectSectCd = new string[1];
            searchPara.SelectSectCd[0] = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
            // 目標設定区分
            searchPara.TargetSetCd = 10;
            
            // 設定区分
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 10:
                    {
                        // 目標対比区分
                        searchPara.TargetContrastCd = 10;
                        break;
                    }
                case 20:
                    {
                        // 目標対比区分
                        searchPara.TargetContrastCd = 20;
                        // 部門コード
                        searchPara.SubSectionCode = this.tNedit_SubSectionCode.GetInt();
                        break;
                    }
                case 221:
                    {
                        // 目標対比区分
                        searchPara.TargetContrastCd = 22;
                        // 従業員区分
                        searchPara.EmployeeDivCd = 10;
                        // 従業員コード
                        searchPara.EmployeeCode = this.tEdit_EmployeeCode.DataText.Trim().PadLeft(4, '0');
                        break;
                    }
                case 222:
                    {
                        // 目標対比区分
                        searchPara.TargetContrastCd = 22;
                        // 従業員区分
                        searchPara.EmployeeDivCd = 20;
                        // 従業員コード
                        searchPara.EmployeeCode = this.tEdit_EmployeeCode.DataText.Trim().PadLeft(4, '0');
                        break;
                    }
                case 223:
                    {
                        // 目標対比区分
                        searchPara.TargetContrastCd = 22;
                        // 従業員区分
                        searchPara.EmployeeDivCd = 30;
                        // 従業員コード
                        searchPara.EmployeeCode = this.tEdit_EmployeeCode.DataText.Trim().PadLeft(4, '0');
                        break;
                    }
            }

            // 適用開始日(開始)
            searchPara.StartApplyStaDate = this._startMonthDateList[0];
            // 適用終了日(終了)
            searchPara.EndApplyEndDate = this._endMonthDateList[11];
            // ---ADD 2010/12/20--------->>>>>
            // 目標区分コード
            searchPara.TargetDivideCode = this._yearMonthList[0].Year.ToString("0000") + this._yearMonthList[0].Month.ToString("00");
            // ---ADD 2010/12/20---------<<<<<
        }

        /// <summary>
        /// 検索条件設定処理(得意先別売上目標)
        /// </summary>
        /// <param name="searchPara">得意先別売上目標検索条件</param>
        /// <remarks>
        /// <br>Note       : 検索条件を設定します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// <br>Update Note: 2010/12/20 曹文傑</br>
        /// <br>             障害改良対応１２月</br>
        /// </remarks>
        private void SetSearchCustSalesTargetPara(ref SearchCustSalesTargetPara searchPara)
        {
            // 企業コード
            searchPara.EnterpriseCode = this._enterpriseCode;
            // 拠点コード
            searchPara.SelectSectCd = new string[1];
            searchPara.SelectSectCd[0] = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
            // 目標設定区分
            searchPara.TargetSetCd = 10;

            // 設定区分
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 30:
                    {
                        // 目標対比区分
                        searchPara.TargetContrastCd = 30;
                        // 得意先コード
                        searchPara.CustomerCode = this.tNedit_CustomerCode.GetInt();
                        break;
                    }
                case 31:
                    {
                        // 目標対比区分
                        searchPara.TargetContrastCd = 31;
                        // 業種コード
                        searchPara.BusinessTypeCode = this.tNedit_BusinessTypeCode.GetInt();
                        break;
                    }
                case 32:
                    {
                        // 目標対比区分
                        searchPara.TargetContrastCd = 32;
                        // 地区コード
                        searchPara.SalesAreaCode = this.tNedit_SalesAreaCode.GetInt();
                        break;
                    }
            }

            // 適用開始日(開始)
            searchPara.StartApplyStaDate = this._startMonthDateList[0];
            // 適用終了日(終了)
            searchPara.EndApplyEndDate = this._endMonthDateList[11];
            // ---ADD 2010/12/20--------->>>>>
            // 目標区分コード
            searchPara.TargetDivideCode = this._yearMonthList[0].Year.ToString("0000") + this._yearMonthList[0].Month.ToString("00");
            // ---ADD 2010/12/20---------<<<<<
        }

        /// <summary>
        /// 検索条件設定処理(商品別売上目標)
        /// </summary>
        /// <param name="searchPara">商品別売上目標検索条件</param>
        /// <remarks>
        /// <br>Note       : 検索条件を設定します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// <br>Update Note: 2010/12/20 曹文傑</br>
        /// <br>             障害改良対応１２月</br>
        /// </remarks>
        private void SetSearchGcdSalesTargetPara(ref SearchGcdSalesTargetPara searchPara)
        {
            // 企業コード
            searchPara.EnterpriseCode = this._enterpriseCode;
            // 目標設定区分
            searchPara.TargetSetCd = 10;

            // 設定区分
            int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            switch (targetContrastCd)
            {
                case 44:
                    {
                        // 拠点コード
                        searchPara.SelectSectCd = new string[1];
                        searchPara.SelectSectCd[0] = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
                        // 目標対比区分
                        searchPara.TargetContrastCd = 44;
                        // 販売区分コード
                        searchPara.SalesCode = this.tNedit_SalesCode.GetInt();
                        break;
                    }
                case 45:
                    {
                        // 拠点コード
                        searchPara.SelectSectCd = new string[1];
                        searchPara.SelectSectCd[0] = "";
                        // 目標対比区分
                        searchPara.TargetContrastCd = 45;
                        // 商品区分コード
                        searchPara.EnterpriseGanreCode = this.tNedit_EnterpriseGanreCode.GetInt();
                        break;
                    }
            }

            // 適用開始日(開始)
            searchPara.StartApplyStaDate = this._startMonthDateList[0];
            // 適用終了日(終了)
            searchPara.EndApplyEndDate = this._endMonthDateList[11];
            // ---ADD 2010/12/20--------->>>>>
            // 目標区分コード
            searchPara.TargetDivideCode = this._yearMonthList[0].Year.ToString("0000") + this._yearMonthList[0].Month.ToString("00");
            // ---ADD 2010/12/20---------<<<<<
        }
        #endregion 検索条件設定

        #region 画面情報取得
        /// <summary>
        /// 画面情報取得処理(従業員別売上目標設定マスタ)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void ScreenToEmpSalesTargetList(ref List<EmpSalesTarget> empSalesTargetList)
        {
            for (int index = 0; index < 12; index++)
            {
                // セル値変換
                if ((ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value) == 0) &&
                    (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value) == 0) &&
                    (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value) == 0))
                {
                    continue;
                }

                EmpSalesTarget empSalesTarget = new EmpSalesTarget();

                // 企業コード
                empSalesTarget.EnterpriseCode = this._enterpriseCode;
                // 拠点コード
                empSalesTarget.SectionCode = this.tEdit_SectionCode.DataText.Trim();
                // 目標設定区分
                empSalesTarget.TargetSetCd = 10;

                int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                switch (targetContrastCd)
                {
                    case 10:
                        {
                            // 目標対比区分
                            empSalesTarget.TargetContrastCd = 10;
                            break;
                        }
                    case 20:
                        {
                            // 目標対比区分
                            empSalesTarget.TargetContrastCd = 20;
                            // 部門コード
                            empSalesTarget.SubSectionCode = this.tNedit_SubSectionCode.GetInt();
                            break;
                        }
                    case 221:
                        {
                            // 目標対比区分
                            empSalesTarget.TargetContrastCd = 22;
                            // 従業員区分
                            empSalesTarget.EmployeeDivCd = 10;
                            // 従業員コード
                            empSalesTarget.EmployeeCode = this.tEdit_EmployeeCode.DataText.Trim();
                            break;
                        }
                    case 222:
                        {
                            // 目標対比区分
                            empSalesTarget.TargetContrastCd = 22;
                            // 従業員区分
                            empSalesTarget.EmployeeDivCd = 20;
                            // 従業員コード
                            empSalesTarget.EmployeeCode = this.tEdit_EmployeeCode.DataText.Trim();
                            break;
                        }
                    case 223:
                        {
                            // 目標対比区分
                            empSalesTarget.TargetContrastCd = 22;
                            // 従業員区分
                            empSalesTarget.EmployeeDivCd = 30;
                            // 従業員コード
                            empSalesTarget.EmployeeCode = this.tEdit_EmployeeCode.DataText.Trim();
                            break;
                        }
                }
                // 目標区分コード
                empSalesTarget.TargetDivideCode = this._yearMonthList[index].Year.ToString("0000") + this._yearMonthList[index].Month.ToString("00");
                // 適用開始日
                empSalesTarget.ApplyStaDate = this._startMonthDateList[index];
                // 適用終了日
                empSalesTarget.ApplyEndDate = this._endMonthDateList[index];
                // 売上目標金額
                if (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value) != 0)
                {
                    empSalesTarget.SalesTargetMoney = (long)ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value);
                }
                // 売上目標粗利額
                if (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value) != 0)
                {
                    empSalesTarget.SalesTargetProfit = (long)ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value);
                }
                // 売上目標数量
                if (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value) != 0)
                {
                    empSalesTarget.SalesTargetCount = ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value);
                }

                empSalesTargetList.Add(empSalesTarget);
            }
        }

        /// <summary>
        /// 画面情報取得処理(得意先別売上目標設定マスタ)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void ScreenToCustSalesTargetList(ref List<CustSalesTarget> custSalesTargetList)
        {
            for (int index = 0; index < 12; index++)
            {
                // セル値変換
                if ((ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value) == 0) &&
                    (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value) == 0) &&
                    (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value) == 0))
                {
                    continue;
                }

                CustSalesTarget custSalesTarget = new CustSalesTarget();

                // 企業コード
                custSalesTarget.EnterpriseCode = this._enterpriseCode;
                // 拠点コード
                custSalesTarget.SectionCode = this.tEdit_SectionCode.DataText.Trim();
                // 目標設定区分
                custSalesTarget.TargetSetCd = 10;

                int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                switch (targetContrastCd)
                {
                    case 30:
                        {
                            // 目標対比区分
                            custSalesTarget.TargetContrastCd = 30;
                            // 得意先コード
                            custSalesTarget.CustomerCode = this.tNedit_CustomerCode.GetInt();
                            break;
                        }
                    case 31:
                        {
                            // 目標対比区分
                            custSalesTarget.TargetContrastCd = 31;
                            // 業種コード
                            custSalesTarget.BusinessTypeCode = this.tNedit_BusinessTypeCode.GetInt();
                            break;
                        }
                    case 32:
                        {
                            // 目標対比区分
                            custSalesTarget.TargetContrastCd = 32;
                            // 地区コード
                            custSalesTarget.SalesAreaCode = this.tNedit_SalesAreaCode.GetInt();
                            break;
                        }
                }

                // 目標区分コード
                custSalesTarget.TargetDivideCode = this._yearMonthList[index].Year.ToString("0000") + this._yearMonthList[index].Month.ToString("00");
                // 適用開始日
                custSalesTarget.ApplyStaDate = this._startMonthDateList[index];
                // 適用終了日
                custSalesTarget.ApplyEndDate = this._endMonthDateList[index];
                // 売上目標金額
                if (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value) != 0)
                {
                    custSalesTarget.SalesTargetMoney = (long)ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value);
                }
                // 売上目標粗利額
                if (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value) != 0)
                {
                    custSalesTarget.SalesTargetProfit = (long)ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value);
                }
                // 売上目標数量
                if (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value) != 0)
                {
                    custSalesTarget.SalesTargetCount = ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value);
                }

                custSalesTargetList.Add(custSalesTarget);
            }
        }

        /// <summary>
        /// 画面情報取得処理(商品別売上目標設定マスタ)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void ScreenToGcdSalesTargetList(ref List<GcdSalesTarget> gcdSalesTargetList)
        {
            for (int index = 0; index < 12; index++)
            {
                // セル値変換
                if ((ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value) == 0) &&
                    (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value) == 0) &&
                    (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value) == 0))
                {
                    continue;
                }

                GcdSalesTarget gcdSalesTarget = new GcdSalesTarget();

                // 企業コード
                gcdSalesTarget.EnterpriseCode = this._enterpriseCode;
                // 目標設定区分
                gcdSalesTarget.TargetSetCd = 10;

                int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                switch (targetContrastCd)
                {
                    case 44:
                        {
                            // 拠点コード
                            gcdSalesTarget.SectionCode = this.tEdit_SectionCode.DataText.Trim();
                            // 目標対比区分
                            gcdSalesTarget.TargetContrastCd = 44;
                            // 販売区分コード
                            gcdSalesTarget.SalesCode = this.tNedit_SalesCode.GetInt();
                            break;
                        }
                    case 45:
                        {
                            // 拠点コード
                            gcdSalesTarget.SectionCode = "";
                            // 目標対比区分
                            gcdSalesTarget.TargetContrastCd = 45;
                            // 商品区分コード
                            gcdSalesTarget.EnterpriseGanreCode = this.tNedit_EnterpriseGanreCode.GetInt();
                            break;
                        }
                }

                // 目標区分コード
                gcdSalesTarget.TargetDivideCode = this._yearMonthList[index].Year.ToString("0000") + this._yearMonthList[index].Month.ToString("00");
                // 適用開始日
                gcdSalesTarget.ApplyStaDate = this._startMonthDateList[index];
                // 適用終了日
                gcdSalesTarget.ApplyEndDate = this._endMonthDateList[index];
                // 売上目標金額
                if (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value) != 0)
                {
                    gcdSalesTarget.SalesTargetMoney = (long)ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value);
                }
                // 売上目標粗利額
                if (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value) != 0)
                {
                    gcdSalesTarget.SalesTargetProfit = (long)ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value);
                }
                // 売上目標数量
                if (ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value) != 0)
                {
                    gcdSalesTarget.SalesTargetCount = ChangeCellValue(this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value);
                }

                gcdSalesTargetList.Add(gcdSalesTarget);
            }
        }
        #endregion 画面情報取得

        #region 画面展開
        /// <summary>
        /// 画面展開処理(従業員別売上目標)
        /// </summary>
        /// <param name="empSalesTargetList">従業員別売上目標リスト</param>
        /// <remarks>
        /// <br>Note       : 従業員別売上目標リストを画面展開します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void EmpSalesTargetToScreen(Dictionary<string, EmpSalesTarget> empSalesTargetDic)
        {
            //------------------------------
            // 目標情報初期化
            //------------------------------
            this.tNedit_SalesTargetSale.Clear();
            this.tNedit_SalesTargetProfit.Clear();
            this.tNedit_SalesTargetCount.Clear();

            for (int index = 0; index < 13; index++)
            {
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_RATIO].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = "";
            }

            //------------------------------
            // 目標情報設定
            //------------------------------
            double totalMoney = 0;
            double totalProfit = 0;
            double totalCount = 0;

            for (int index = 0; index < 12; index++)
            {
                string targetDivideCode = this._yearMonthList[index].Year.ToString("0000") + this._yearMonthList[index].Month.ToString("00");

                if (!empSalesTargetDic.ContainsKey(targetDivideCode))
                {
                    continue;
                }

                EmpSalesTarget empSalesTarget = (EmpSalesTarget)empSalesTargetDic[targetDivideCode];

                // 売上目標
                if (empSalesTarget.SalesTargetMoney != 0)
                {
                    totalMoney += empSalesTarget.SalesTargetMoney;
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = empSalesTarget.SalesTargetMoney.ToString(FORMAT_NUM);
                }
                // 粗利目標
                if (empSalesTarget.SalesTargetProfit != 0)
                {
                    totalProfit += empSalesTarget.SalesTargetProfit;
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = empSalesTarget.SalesTargetProfit.ToString(FORMAT_NUM);
                }
                // 数量目標
                if (empSalesTarget.SalesTargetCount != 0)
                {
                    totalCount += empSalesTarget.SalesTargetCount;
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = empSalesTarget.SalesTargetCount.ToString(FORMAT_NUM);
                }
            }

            //------------------------------
            // 合計行設定
            //------------------------------
            if (totalMoney != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_SALESTARGET].Value = totalMoney.ToString(FORMAT_NUM);
            }
            if (totalProfit != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_PROFITTARGET].Value = totalProfit.ToString(FORMAT_NUM);
            }
            if (totalCount != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_COUNTTARGET].Value = totalCount.ToString(FORMAT_NUM);
            }
        }

        /// <summary>
        /// 画面展開処理(得意先別売上目標)
        /// </summary>
        /// <param name="custSalesTargetList">得意先別売上目標リスト</param>
        /// <remarks>
        /// <br>Note       : 得意先別売上目標リストを画面展開します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void CustSalesTargetToScreen(Dictionary<string, CustSalesTarget> custSalesTargetDic)
        {
            //------------------------------
            // 目標情報初期化
            //------------------------------
            this.tNedit_SalesTargetSale.Clear();
            this.tNedit_SalesTargetProfit.Clear();
            this.tNedit_SalesTargetCount.Clear();

            for (int index = 0; index < 13; index++)
            {
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_RATIO].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = "";
            }

            //------------------------------
            // 目標情報設定
            //------------------------------
            double totalMoney = 0;
            double totalProfit = 0;
            double totalCount = 0;

            for (int index = 0; index < 12; index++)
            {
                string targetDivideCode = this._yearMonthList[index].Year.ToString("0000") + this._yearMonthList[index].Month.ToString("00");

                if (!custSalesTargetDic.ContainsKey(targetDivideCode))
                {
                    continue;
                }

                CustSalesTarget custSalesTarget = (CustSalesTarget)custSalesTargetDic[targetDivideCode];

                // 売上目標
                if (custSalesTarget.SalesTargetMoney != 0)
                {
                    totalMoney += custSalesTarget.SalesTargetMoney;
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = custSalesTarget.SalesTargetMoney.ToString(FORMAT_NUM);
                }
                // 粗利目標
                if (custSalesTarget.SalesTargetProfit != 0)
                {
                    totalProfit += custSalesTarget.SalesTargetProfit;
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = custSalesTarget.SalesTargetProfit.ToString(FORMAT_NUM);
                }
                // 数量目標
                if (custSalesTarget.SalesTargetCount != 0)
                {
                    totalCount += custSalesTarget.SalesTargetCount;
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = custSalesTarget.SalesTargetCount.ToString(FORMAT_NUM);
                }
            }

            //------------------------------
            // 合計行設定
            //------------------------------
            if (totalMoney != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_SALESTARGET].Value = totalMoney.ToString(FORMAT_NUM);
            }
            if (totalProfit != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_PROFITTARGET].Value = totalProfit.ToString(FORMAT_NUM);
            }
            if (totalCount != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_COUNTTARGET].Value = totalCount.ToString(FORMAT_NUM);
            }
        }

        /// <summary>
        /// 画面展開処理(商品別売上目標)
        /// </summary>
        /// <param name="gcdSalesTargetList">商品別売上目標リスト</param>
        /// <remarks>
        /// <br>Note       : 商品別売上目標リストを画面展開します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void GcdSalesTargetToScreen(Dictionary<string, GcdSalesTarget> gcdSalesTargetDic)
        {
            //------------------------------
            // 目標情報初期化
            //------------------------------
            this.tNedit_SalesTargetSale.Clear();
            this.tNedit_SalesTargetProfit.Clear();
            this.tNedit_SalesTargetCount.Clear();

            for (int index = 0; index < 13; index++)
            {
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_RATIO].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = "";
                this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = "";
            }

            //------------------------------
            // 目標情報設定
            //------------------------------
            double totalMoney = 0;
            double totalProfit = 0;
            double totalCount = 0;

            for (int index = 0; index < 12; index++)
            {
                string targetDivideCode = this._yearMonthList[index].Year.ToString("0000") + this._yearMonthList[index].Month.ToString("00");

                if (!gcdSalesTargetDic.ContainsKey(targetDivideCode))
                {
                    continue;
                }

                GcdSalesTarget gcdSalesTarget = (GcdSalesTarget)gcdSalesTargetDic[targetDivideCode];

                // 売上目標
                if (gcdSalesTarget.SalesTargetMoney != 0)
                {
                    totalMoney += gcdSalesTarget.SalesTargetMoney;
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_SALESTARGET].Value = gcdSalesTarget.SalesTargetMoney.ToString(FORMAT_NUM);
                }
                // 粗利目標
                if (gcdSalesTarget.SalesTargetProfit != 0)
                {
                    totalProfit += gcdSalesTarget.SalesTargetProfit;
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_PROFITTARGET].Value = gcdSalesTarget.SalesTargetProfit.ToString(FORMAT_NUM);
                }
                // 数量目標
                if (gcdSalesTarget.SalesTargetCount != 0)
                {
                    totalCount += gcdSalesTarget.SalesTargetCount;
                    this.SalesTarget_uGrid.Rows[index].Cells[COLUMN_COUNTTARGET].Value = gcdSalesTarget.SalesTargetCount.ToString(FORMAT_NUM);
                }
            }

            //------------------------------
            // 合計行設定
            //------------------------------
            if (totalMoney != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_SALESTARGET].Value = totalMoney.ToString(FORMAT_NUM);
            }
            if (totalProfit != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_PROFITTARGET].Value = totalProfit.ToString(FORMAT_NUM);
            }
            if (totalCount != 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[COLUMN_COUNTTARGET].Value = totalCount.ToString(FORMAT_NUM);
            }
        }
        #endregion 画面展開

        #region 排他処理
        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : 排他制御を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            string errMsg = "";

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        errMsg = "既に他端末より更新されています。";
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        errMsg = "既に他端末より削除されています。";
                        break;
                    }
            }

            ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           errMsg,
                           status,
                           MessageBoxButtons.OK,
                           MessageBoxDefaultButton.Button1);
        }
        #endregion 排他処理

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
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSEMBLY_ID,                       // アセンブリID
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
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         ASSEMBLY_ID, 		  　　			// アセンブリID
                                         methodName,						// 処理名称
                                         "",					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._salesTargetAcs,				// エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }

        #endregion メッセージボックス表示

        #region 文字列編集処理

        /// <summary>
        /// カンマ・ピリオド削除処理
        /// </summary>
        /// <param name="targetText">カンマ・ピリオド削除前テキスト</param>
        /// <param name="retText">カンマ・ピリオド削除済みテキスト</param>
        /// <param name="periodDelFlg">ピリオド削除フラグ(True:カンマ・ピリオド削除  False:カンマ削除)</param>
        /// <remarks>
        /// <br>Note		: 対象のテキストからカンマ・ピリオドを削除します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/09/25</br>
        /// </remarks>
        private void RemoveCommaPeriod(string targetText, out string retText, bool periodDelFlg)
        {
            retText = "";

            // セル値編集用にカンマ・ピリオド削除
            for (int i = targetText.Length - 1; i >= 0; i--)
            {
                // カンマ・ピリオド削除
                if (periodDelFlg == true)
                {
                    if ((targetText[i].ToString() == ",") || (targetText[i].ToString() == "."))
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
                // カンマのみ削除
                else
                {
                    if (targetText[i].ToString() == ",")
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
            }

            retText = targetText;
        }

        /// <summary>
        /// 小数点取得処理
        /// </summary>
        /// <param name="targetText">チェック対象テキスト</param>
        /// <param name="retText">小数部分テキスト</param>
        /// <remarks>
        /// <br>Note		: 対象のテキストから小数部分のみを返します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/09/25</br>
        /// </remarks>
        private void GetDecimal(string targetText, out string retText)
        {
            retText = "";

            for (int i = targetText.IndexOf(".") + 1; i < targetText.Length; i++)
            {
                retText += targetText[i].ToString();
            }
        }

        #endregion 文字列編集処理

        #endregion ■ Private Methods


        #region ■ Control Events

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : Form_Load時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void PMKHN09251UA_Load(object sender, EventArgs e)
        {
            // 画面初期設定
            SetScreenInitialSetting();

            // 画面初期化処理
            ClearScreen();
        }

        #region ガイドボタン押下
        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;

                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    // 拠点コード設定
                    this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                    // 拠点名設定
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevSectionCode = secInfoSet.SectionCode.Trim();
                        return;
                    }
                    else
                    {
                        if (this._searchFlg)
                        {
                            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                "",
                                                                0,
                                                                MessageBoxButtons.YesNoCancel,
                                                                MessageBoxDefaultButton.Button2);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    {
                                        // 保存処理
                                        status = SaveProc();
                                        if (status != 0)
                                        {
                                            this._prevSectionCode = secInfoSet.SectionCode.Trim();
                                            return;
                                        }

                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        break;
                                    }
                                case DialogResult.Cancel:
                                    {
                                        this.tEdit_SectionCode.DataText = this._prevSectionCode;
                                        this.tEdit_SectionName.DataText = GetSectionName(this._prevSectionCode);
                                        return;
                                    }
                            }
                        }

                        // 検索
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevSectionCode = secInfoSet.SectionCode.Trim();
                        }
                        else
                        {
                            this._prevSectionCode = secInfoSet.SectionCode.Trim();
                        }
                    }

                    // フォーカス設定
                    Control nextControl;
                    GetNextControl(this.SectionGuide_Button, out nextControl);
                    nextControl.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 部門ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SubSectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SubSection subSection;

                int status = this._subSectionAcs.ExecuteGuid(out subSection, this._enterpriseCode);
                if (status == 0)
                {
                    // 部門コード設定
                    this.tNedit_SubSectionCode.SetInt(subSection.SubSectionCode);
                    // 部門名設定
                    this.tEdit_SubSectionName.DataText = subSection.SubSectionName.Trim();

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevSubSectionCode = subSection.SubSectionCode;
                        return;
                    }
                    else
                    {
                        if (this._searchFlg)
                        {
                            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                "",
                                                                0,
                                                                MessageBoxButtons.YesNoCancel,
                                                                MessageBoxDefaultButton.Button2);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    {
                                        // 保存処理
                                        status = SaveProc();
                                        if (status != 0)
                                        {
                                            this._prevSubSectionCode = subSection.SubSectionCode;
                                            return;
                                        }

                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        break;
                                    }
                                case DialogResult.Cancel:
                                    {
                                        this.tNedit_SubSectionCode.SetInt(this._prevSubSectionCode);
                                        this.tEdit_SubSectionName.DataText = GetSubSectionName(this._prevSubSectionCode);
                                        return;
                                    }
                            }
                        }

                        // 検索
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevSubSectionCode = subSection.SubSectionCode;
                        }
                        else
                        {
                            this._prevSubSectionCode = subSection.SubSectionCode;
                        }
                    }

                    // フォーカス設定
                    Control nextControl;
                    GetNextControl(this.SubSectionGuide_Button, out nextControl);
                    nextControl.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._cusotmerGuideSelected = false;

                // 得意先ガイド
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                if (this._cusotmerGuideSelected == true)
                {
                    // フォーカス設定
                    Control nextControl;
                    GetNextControl(this.CustomerGuide_Button, out nextControl);
                    nextControl.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note       : 得意先選択時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            int status;

            // 得意先コード設定
            this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);
            // 得意先名設定
            this.tEdit_CustomerName.DataText = customerSearchRet.Snm.Trim();

            if (CheckSaveConfirm() == false)
            {
                this._prevCustomerCode = customerSearchRet.CustomerCode;
                return;
            }
            else
            {
                if (this._searchFlg)
                {
                    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                        "",
                                                        0,
                                                        MessageBoxButtons.YesNoCancel,
                                                        MessageBoxDefaultButton.Button2);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            {
                                // 保存処理
                                status = SaveProc();
                                if (status != 0)
                                {
                                    this._prevCustomerCode = customerSearchRet.CustomerCode;
                                    return;
                                }

                                break;
                            }
                        case DialogResult.No:
                            {
                                break;
                            }
                        case DialogResult.Cancel:
                            {
                                this.tNedit_CustomerCode.SetInt(this._prevCustomerCode);
                                this.tEdit_CustomerName.DataText = GetCustomerName(this._prevCustomerCode);
                                return;
                            }
                    }
                }

                // 検索
                status = SearchProc();
                if (status != 0)
                {
                    ClearGrid();
                    this._prevCustomerCode = customerSearchRet.CustomerCode;
                }
                else
                {
                    this._prevCustomerCode = customerSearchRet.CustomerCode;
                }
            }

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 従業員ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void EmployeeGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Employee employee;

                int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, false, out employee);
                if (status == 0)
                {
                    // 従業員コード設定
                    this.tEdit_EmployeeCode.DataText = employee.EmployeeCode.Trim();
                    // 従業員名設定
                    this.tEdit_EmployeeName.DataText = employee.Name.Trim();

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevEmployeeCode = employee.EmployeeCode.Trim();
                        return;
                    }
                    else
                    {
                        if (this._searchFlg)
                        {
                            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                "",
                                                                0,
                                                                MessageBoxButtons.YesNoCancel,
                                                                MessageBoxDefaultButton.Button2);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    {
                                        // 保存処理
                                        status = SaveProc();
                                        if (status != 0)
                                        {
                                            this._prevEmployeeCode = employee.EmployeeCode.Trim();
                                            return;
                                        }

                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        break;
                                    }
                                case DialogResult.Cancel:
                                    {
                                        this.tEdit_EmployeeCode.DataText = this._prevEmployeeCode;
                                        this.tEdit_EmployeeName.DataText = GetEmployeeName(this._prevEmployeeCode);
                                        return;
                                    }
                            }
                        }

                        // 検索
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevEmployeeCode = employee.EmployeeCode.Trim();
                        }
                        else
                        {
                            this._prevEmployeeCode = employee.EmployeeCode.Trim();
                        }
                    }

                    // フォーカス設定
                    Control nextControl;
                    GetNextControl(this.EmployeeGuide_Button, out nextControl);
                    nextControl.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 地区ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SalesAreaGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);
                if (status == 0)
                {
                    // 地区コード設定
                    this.tNedit_SalesAreaCode.SetInt(userGdBd.GuideCode);
                    // 地区名設定
                    this.tEdit_SalesAreaName.DataText = userGdBd.GuideName.Trim();

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevSalesAreaCode = userGdBd.GuideCode;
                        return;
                    }
                    else
                    {
                        if (this._searchFlg)
                        {
                            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                "",
                                                                0,
                                                                MessageBoxButtons.YesNoCancel,
                                                                MessageBoxDefaultButton.Button2);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    {
                                        // 保存処理
                                        status = SaveProc();
                                        if (status != 0)
                                        {
                                            this._prevSalesAreaCode = userGdBd.GuideCode;
                                            return;
                                        }

                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        break;
                                    }
                                case DialogResult.Cancel:
                                    {
                                        this.tNedit_SalesAreaCode.SetInt(this._prevSalesAreaCode);
                                        this.tEdit_SalesAreaName.DataText = GetSalesAreaName(this._prevSalesAreaCode);
                                        return;
                                    }
                            }
                        }

                        // 検索
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevSalesAreaCode = userGdBd.GuideCode;
                        }
                        else
                        {
                            this._prevSalesAreaCode = userGdBd.GuideCode;
                        }
                    }

                    // フォーカス設定
                    Control nextControl;
                    GetNextControl(this.SalesAreaGuide_Button, out nextControl);
                    nextControl.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 業種ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void BusinessTypeGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 33);
                if (status == 0)
                {
                    // 業種コード設定
                    this.tNedit_BusinessTypeCode.SetInt(userGdBd.GuideCode);
                    // 業種名設定
                    this.tEdit_BusinessTypeName.DataText = userGdBd.GuideName.Trim();

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevBusinessTypeCode = userGdBd.GuideCode;
                        return;
                    }
                    else
                    {
                        if (this._searchFlg)
                        {
                            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                "",
                                                                0,
                                                                MessageBoxButtons.YesNoCancel,
                                                                MessageBoxDefaultButton.Button2);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    {
                                        // 保存処理
                                        status = SaveProc();
                                        if (status != 0)
                                        {
                                            this._prevBusinessTypeCode = userGdBd.GuideCode;
                                            return;
                                        }

                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        break;
                                    }
                                case DialogResult.Cancel:
                                    {
                                        this.tNedit_BusinessTypeCode.SetInt(this._prevBusinessTypeCode);
                                        this.tEdit_BusinessTypeName.DataText = GetBusinessTypeName(this._prevBusinessTypeCode);
                                        return;
                                    }
                            }
                        }

                        // 検索
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevBusinessTypeCode = userGdBd.GuideCode;
                        }
                        else
                        {
                            this._prevBusinessTypeCode = userGdBd.GuideCode;
                        }
                    }

                    // フォーカス設定
                    Control nextControl;
                    GetNextControl(this.BusinessTypeGuide_Button, out nextControl);
                    nextControl.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 販売区分ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SalesCodeGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 71);
                if (status == 0)
                {
                    // 販売区分コード設定
                    this.tNedit_SalesCode.SetInt(userGdBd.GuideCode);
                    // 販売区分名設定
                    this.tEdit_SalesCodeName.DataText = userGdBd.GuideName.Trim();

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevSalesCode = userGdBd.GuideCode;
                        return;
                    }
                    else
                    {
                        if (this._searchFlg)
                        {
                            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                "",
                                                                0,
                                                                MessageBoxButtons.YesNoCancel,
                                                                MessageBoxDefaultButton.Button2);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    {
                                        // 保存処理
                                        status = SaveProc();
                                        if (status != 0)
                                        {
                                            this._prevSalesCode = userGdBd.GuideCode;
                                            return;
                                        }

                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        break;
                                    }
                                case DialogResult.Cancel:
                                    {
                                        this.tNedit_SalesCode.SetInt(this._prevSalesCode);
                                        this.tEdit_SalesCodeName.DataText = GetSalesCodeName(this._prevSalesCode);
                                        return;
                                    }
                            }
                        }

                        // 検索
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevSalesCode = userGdBd.GuideCode;
                        }
                        else
                        {
                            this._prevSalesCode = userGdBd.GuideCode;
                        }
                    }

                    // フォーカス設定
                    Control nextControl;
                    GetNextControl(this.SalesCodeGuide_Button, out nextControl);
                    nextControl.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 商品区分ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void EnterpriseGanreGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 41);
                if (status == 0)
                {
                    // 商品区分コード設定
                    this.tNedit_EnterpriseGanreCode.SetInt(userGdBd.GuideCode);
                    // 商品区分名設定
                    this.tEdit_EnterpriseGanreName.DataText = userGdBd.GuideName.Trim();

                    if (CheckSaveConfirm() == false)
                    {
                        this._prevEnterpriseGanreCode = userGdBd.GuideCode;
                        return;
                    }
                    else
                    {
                        if (this._searchFlg)
                        {
                            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                "",
                                                                0,
                                                                MessageBoxButtons.YesNoCancel,
                                                                MessageBoxDefaultButton.Button2);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    {
                                        // 保存処理
                                        status = SaveProc();
                                        if (status != 0)
                                        {
                                            this._prevEnterpriseGanreCode = userGdBd.GuideCode;
                                            return;
                                        }

                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        break;
                                    }
                                case DialogResult.Cancel:
                                    {
                                        this.tNedit_EnterpriseGanreCode.SetInt(this._prevEnterpriseGanreCode);
                                        this.tEdit_EnterpriseGanreName.DataText = GetEnterpriseGanreName(this._prevEnterpriseGanreCode);
                                        return;
                                    }
                            }
                        }

                        // 検索
                        status = SearchProc();
                        if (status != 0)
                        {
                            ClearGrid();
                            this._prevEnterpriseGanreCode = userGdBd.GuideCode;
                        }
                        else
                        {
                            this._prevEnterpriseGanreCode = userGdBd.GuideCode;
                        }
                    }

                    // フォーカス設定
                    Control nextControl;
                    GetNextControl(this.EnterpriseGanreGuide_Button, out nextControl);
                    nextControl.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion ガイドボタン押下

        #region グリッド関連

        /// <summary>
        /// AfterEnterEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : セルが編集モードになった時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SalesTarget_uGrid_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                return;
            }

            if ((this.SalesTarget_uGrid.ActiveCell.Value == DBNull.Value) || 
                ((string)this.SalesTarget_uGrid.ActiveCell.Value == ""))
            {
                return;
            }

            string retText;
            string targetText = (string)this.SalesTarget_uGrid.ActiveCell.Value;

            // カンマのみ削除
            RemoveCommaPeriod(targetText, out retText, false);

            this.SalesTarget_uGrid.ActiveCell.Value = retText;
            this.SalesTarget_uGrid.ActiveCell.SelStart = 0;
            this.SalesTarget_uGrid.ActiveCell.SelLength = retText.Length;
        }

        /// <summary>
        /// AfterExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : セルの編集モードが終了した時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SalesTarget_uGrid_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                return;
            }

            int columnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;

            if ((this.SalesTarget_uGrid.ActiveCell.Value != DBNull.Value) &&
                ((string)this.SalesTarget_uGrid.ActiveCell.Value != ""))
            {
                string retText;
                string targetText = (string)this.SalesTarget_uGrid.ActiveCell.Value;

                // カンマのみ削除
                RemoveCommaPeriod(targetText, out retText, false);

                double targetValue = double.Parse(retText);

                // ユーザー定価の場合
                if (columnIndex == 1)
                {
                    this.SalesTarget_uGrid.ActiveCell.Value = targetValue.ToString("N");
                }
                else
                {
                    this.SalesTarget_uGrid.ActiveCell.Value = targetValue.ToString(FORMAT_NUM);
                }
            }

            // 合計目標取得
            double totalTarget = GetTotalTarget(columnIndex);

            if (totalTarget == 0)
            {
                this.SalesTarget_uGrid.Rows[12].Cells[columnIndex].Value = "";
            }
            else
            {
                this.SalesTarget_uGrid.Rows[12].Cells[columnIndex].Value = totalTarget.ToString(FORMAT_NUM);
            }
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドがアクティブ状態でキーが押された時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SalesTarget_uGrid_KeyDown(object sender, KeyEventArgs e)
        {
            int rowIndex;
            int columnIndex;

            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                if (this.SalesTarget_uGrid.ActiveRow == null)
                {
                    rowIndex = 0;
                    columnIndex = 1;
                }
                else
                {
                    rowIndex = this.SalesTarget_uGrid.ActiveRow.Index;
                    columnIndex = 1;
                }
            }
            else
            {
                rowIndex = this.SalesTarget_uGrid.ActiveCell.Row.Index;
                columnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;
            }

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        e.Handled = true;

                        if (rowIndex == 0)
                        {
                            if (columnIndex <= 2)
                            {
                                this.tNedit_SalesTargetSale.Focus();
                            }
                            else if (columnIndex == 3)
                            {
                                this.tNedit_SalesTargetProfit.Focus();
                            }
                            else
                            {
                                this.tNedit_SalesTargetCount.Focus();
                            }
                        }
                        else
                        {
                            this.SalesTarget_uGrid.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        if (rowIndex < 11)
                        {
                            this.SalesTarget_uGrid.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (this.SalesTarget_uGrid.ActiveCell.IsInEditMode)
                        {
                            if (this.SalesTarget_uGrid.ActiveCell.SelStart == 0)
                            {
                                e.Handled = true;

                                if (columnIndex <= 1)
                                {
                                    int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                                    if (targetContrastCd == 45)
                                    {
                                        this.EnterpriseGanreGuide_Button.Focus();
                                    }
                                    else
                                    {
                                        this.SectionGuide_Button.Focus();
                                    }
                                }
                                else
                                {
                                    this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex - 1].Activate();
                                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        if (this.SalesTarget_uGrid.ActiveCell.IsInEditMode)
                        {
                            if (this.SalesTarget_uGrid.ActiveCell.SelStart >= this.SalesTarget_uGrid.ActiveCell.Text.Length)
                            {
                                e.Handled = true;

                                if (columnIndex != 4)
                                {
                                    this.SalesTarget_uGrid.Rows[rowIndex].Cells[columnIndex + 1].Activate();
                                    this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
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
        /// <br>Note       : グリッドがアクティブ状態でキーが押された時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SalesTarget_uGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.SalesTarget_uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.SalesTarget_uGrid.ActiveCell.Row.Index;
            int columnIndex = this.SalesTarget_uGrid.ActiveCell.Column.Index;

            if (columnIndex < 1)
            {
                return;
            }

            // 「Backspace」キーを押された時
            if ((byte)e.KeyChar == (byte)'\b')
            {
                return;
            }

            // 対象セルのテキスト取得
            string retText;
            string targetText = this.SalesTarget_uGrid.ActiveCell.Text;
            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);

            // 各行の入力可能桁数を設定します
            switch (columnIndex)
            {
                // 月別比率
                // 3V2
                case 1:
                    // セルのテキストが選択されている場合
                    if (this.SalesTarget_uGrid.ActiveCell.SelText == targetText)
                    {
                        // 数値のみ入力可
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // カンマ、ピリオド削除
                        RemoveCommaPeriod(targetText, out retText, true);

                        // 文字数が5文字だったら入力不可
                        if (retText.Length == 5)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // 数値以外の時
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // 入力値の1文字目は「,」「.」不可
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    if (targetText.IndexOf(".") >= 0)
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    if (targetText[targetText.Length - 1].ToString() == ",")
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    // カンマ、ピリオド削除
                                    RemoveCommaPeriod(targetText, out retText, true);

                                    if (retText.Length == 3)
                                    {
                                        if ((byte)e.KeyChar != '.')
                                        {
                                            e.KeyChar = '\0';
                                        }
                                    }

                                    // 「,」「.」は入力可
                                    if (((byte)e.KeyChar == ',') || ((byte)e.KeyChar == '.'))
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                            else
                            {
                                if (targetText.IndexOf(".") >= 0)
                                {
                                    // 小数点取得
                                    GetDecimal(targetText, out retText);

                                    if (retText.Length == 2)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                                else
                                {
                                    // カンマ、ピリオド削除
                                    RemoveCommaPeriod(targetText, out retText, true);

                                    if (retText.Length == 3)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                    break;

                // 売上目標、粗利目標
                // 11
                case 2:
                case 3:
                    // セルのテキストが選択されている場合
                    if (this.SalesTarget_uGrid.ActiveCell.SelText == targetText)
                    {
                        // 数値のみ入力可
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // カンマ、ピリオド削除
                        RemoveCommaPeriod(targetText, out retText, true);

                        // 文字数が9文字だったら入力不可
                        if (retText.Length == 11)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // 数値以外の時
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // 入力値の1文字目は「,」不可
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    // 「,」は入力可
                                    if ((byte)e.KeyChar != ',')
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    if (targetText[targetText.Length - 1].ToString() == ",")
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                    break;

                // 数量目標
                // 8
                case 4:
                    // セルのテキストが選択されている場合
                    if (this.SalesTarget_uGrid.ActiveCell.SelText == targetText)
                    {
                        // 数値のみ入力可
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // カンマ、ピリオド削除
                        RemoveCommaPeriod(targetText, out retText, true);

                        // 文字数が9文字だったら入力不可
                        if (retText.Length == 8)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // 数値以外の時
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // 入力値の1文字目は「,」不可
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    // 「,」は入力可
                                    if ((byte)e.KeyChar != ',')
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    if (targetText[targetText.Length - 1].ToString() == ",")
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドからフォーカスが離れた時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void SalesTarget_uGrid_Leave(object sender, EventArgs e)
        {
            this.SalesTarget_uGrid.ActiveCell = null;
            this.SalesTarget_uGrid.ActiveRow = null;
        }
        #endregion グリッド関連

        /// <summary>
        /// SelectionChangeCommitted イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 設定区分の値が変更された時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void tComboEditor_TargetContrastCd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.tComboEditor_TargetContrastCd.Value == null)
            {
                return;
            }

            AfterChangeTargetContrastCd();
        }

        private void AfterChangeTargetContrastCd()
        {
            int status;

            if (this._searchFlg)
            {
                DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                    "",
                                                    0,
                                                    MessageBoxButtons.YesNoCancel,
                                                    MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Yes:
                        {
                            // 保存処理
                            status = SaveProc();
                            if (status != 0)
                            {
                                this._prevTargetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                                return;
                            }

                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            this.tComboEditor_TargetContrastCd.SelectionChangeCommitted -= tComboEditor_TargetContrastCd_SelectionChangeCommitted;
                            this.tComboEditor_TargetContrastCd.Value = this._prevTargetContrastCd;
                            this.tComboEditor_TargetContrastCd.SelectionChangeCommitted += tComboEditor_TargetContrastCd_SelectionChangeCommitted;
                            return;
                        }
                }
            }

            // 検索
            status = SearchProc();
            if (status != 0)
            {
                int prevTargetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
                int year = this.tNedit_Year.GetInt();
                ClearScreen();
                this.tNedit_Year.SetInt(year);
                this._prevTargetContrastCd = prevTargetContrastCd;
                this.tComboEditor_TargetContrastCd.SelectionChangeCommitted -= tComboEditor_TargetContrastCd_SelectionChangeCommitted;
                this.tComboEditor_TargetContrastCd.Value = prevTargetContrastCd;
                this.tComboEditor_TargetContrastCd.SelectionChangeCommitted += tComboEditor_TargetContrastCd_SelectionChangeCommitted;
            }
            else
            {
                this._prevTargetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;
            }

            this.Top_Panel.Focus();
            this.tComboEditor_TargetContrastCd.Focus();

            // 設定区分条件コントロールEnabled制御
            ChangeTargetContrastControl((int)this.tComboEditor_TargetContrastCd.Value);
        }
        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : コントロールのフォーカスが変更された時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            int status;

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_Year":
                    {
                        int year = this.tNedit_Year.GetInt();

                        if (year == this._prevYear)
                        {
                            return;
                        }

                        // 会計年度テーブル取得
                        GetFinancialYearTable(year - this._thisYear);

                        if (CheckSaveConfirm() == false)
                        {
                            this._prevYear = year;
                            return;
                        }
                        else
                        {
                            if (this._searchFlg)
                            {
                                DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                    "",
                                                                    0,
                                                                    MessageBoxButtons.YesNoCancel,
                                                                    MessageBoxDefaultButton.Button2);
                                switch (result)
                                {
                                    case DialogResult.Yes:
                                        {
                                            // 保存処理
                                            status = SaveProc();
                                            if (status != 0)
                                            {
                                                this._prevYear = year;
                                                return;
                                            }

                                            break;
                                        }
                                    case DialogResult.No:
                                        {
                                            break;
                                        }
                                    case DialogResult.Cancel:
                                        {
                                            this.tNedit_Year.SetInt(this._prevYear);

                                            // 会計年度テーブル取得
                                            GetFinancialYearTable(this._prevYear - this._thisYear);
                                            return;
                                        }
                                }
                            }

                            // 検索
                            status = SearchProc();
                            if (status != 0)
                            {
                                ClearScreen();

                                this.tNedit_Year.SetInt(year);
                                this._prevYear = year;
                            }
                            else
                            {
                                this._prevYear = year;
                            }
                        }
                        break;
                    }
                case "tComboEditor_TargetContrastCd":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                AfterChangeTargetContrastCd();
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                AfterChangeTargetContrastCd();
                            }
                        }
                        break;
                    }
                case "tEdit_SectionCode":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 10)
                                {
                                    e.NextCtrl = null;
                                }
                            }
                        }

                        if (this.tEdit_SectionCode.DataText.Trim() == "")
                        {
                            this.tEdit_SectionName.Clear();
                            this._prevSectionCode = "";
                            return;
                        }

                        // 拠点コード取得
                        string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');

                        if (sectionCode != this._prevSectionCode)
                        {
                            // 拠点名取得
                            this.tEdit_SectionName.DataText = GetSectionName(sectionCode);

                            if (CheckSaveConfirm() == false)
                            {
                                this._prevSectionCode = sectionCode;
                            }
                            else
                            {
                                if (this._searchFlg)
                                {
                                    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                        "",
                                                                        0,
                                                                        MessageBoxButtons.YesNoCancel,
                                                                        MessageBoxDefaultButton.Button2);
                                    switch (result)
                                    {
                                        case DialogResult.Yes:
                                            {
                                                // 保存処理
                                                status = SaveProc();
                                                if (status != 0)
                                                {
                                                    this._prevSectionCode = sectionCode;
                                                    return;
                                                }

                                                break;
                                            }
                                        case DialogResult.No:
                                            {
                                                break;
                                            }
                                        case DialogResult.Cancel:
                                            {
                                                this.tEdit_SectionCode.DataText = this._prevSectionCode;
                                                this.tEdit_SectionName.DataText = GetSectionName(this._prevSectionCode);
                                                return;
                                            }
                                    }
                                }

                                // 検索
                                status = SearchProc();
                                if (status != 0)
                                {
                                    ClearGrid();
                                    this._prevSectionCode = sectionCode;
                                }
                                else
                                {
                                    this._prevSectionCode = sectionCode;
                                }
                            }
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tEdit_SectionCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_SubSectionCode":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 20)
                                {
                                    e.NextCtrl = null;
                                }
                            }
                        }

                        if (this.tNedit_SubSectionCode.GetInt() == 0)
                        {
                            this.tEdit_SubSectionName.Clear();
                            this._prevSubSectionCode = 0;
                            return;
                        }

                        // 部門コード取得
                        int subSectionCode = this.tNedit_SubSectionCode.GetInt();

                        if (subSectionCode != this._prevSubSectionCode)
                        {
                            // 部門名取得
                            this.tEdit_SubSectionName.DataText = GetSubSectionName(subSectionCode);

                            if (CheckSaveConfirm() == false)
                            {
                                this._prevSubSectionCode = subSectionCode;
                            }
                            else
                            {
                                if (this._searchFlg)
                                {
                                    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                        "",
                                                                        0,
                                                                        MessageBoxButtons.YesNoCancel,
                                                                        MessageBoxDefaultButton.Button2);
                                    switch (result)
                                    {
                                        case DialogResult.Yes:
                                            {
                                                // 保存処理
                                                status = SaveProc();
                                                if (status != 0)
                                                {
                                                    this._prevSubSectionCode = subSectionCode;
                                                    return;
                                                }

                                                break;
                                            }
                                        case DialogResult.No:
                                            {
                                                break;
                                            }
                                        case DialogResult.Cancel:
                                            {
                                                this.tNedit_SubSectionCode.SetInt(this._prevSubSectionCode);
                                                this.tEdit_SubSectionName.DataText = GetSubSectionName(this._prevSubSectionCode);
                                                return;
                                            }
                                    }
                                }

                                // 検索
                                status = SearchProc();
                                if (status != 0)
                                {
                                    ClearGrid();
                                    this._prevSubSectionCode = subSectionCode;
                                }
                                else
                                {
                                    this._prevSubSectionCode = subSectionCode;
                                }
                            }
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_SubSectionName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_SubSectionCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_CustomerCode":
                    {
                        if (this.tNedit_CustomerCode.GetInt() == 0)
                        {
                            this.tEdit_CustomerName.Clear();
                            this._prevCustomerCode = 0;
                            return;
                        }

                        // 得意先コード取得
                        int customerCode = this.tNedit_CustomerCode.GetInt();

                        if (customerCode != this._prevCustomerCode)
                        {
                            // 得意先名取得
                            this.tEdit_CustomerName.DataText = GetCustomerName(customerCode);

                            if (CheckSaveConfirm() == false)
                            {
                                this._prevCustomerCode = customerCode;
                            }
                            else
                            {
                                if (this._searchFlg)
                                {
                                    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                        "",
                                                                        0,
                                                                        MessageBoxButtons.YesNoCancel,
                                                                        MessageBoxDefaultButton.Button2);
                                    switch (result)
                                    {
                                        case DialogResult.Yes:
                                            {
                                                // 保存処理
                                                status = SaveProc();
                                                if (status != 0)
                                                {
                                                    this._prevCustomerCode = customerCode;
                                                    return;
                                                }

                                                break;
                                            }
                                        case DialogResult.No:
                                            {
                                                break;
                                            }
                                        case DialogResult.Cancel:
                                            {
                                                this.tNedit_CustomerCode.SetInt(this._prevCustomerCode);
                                                this.tEdit_CustomerName.DataText = GetCustomerName(this._prevCustomerCode);
                                                return;
                                            }
                                    }
                                }

                                // 検索
                                status = SearchProc();
                                if (status != 0)
                                {
                                    ClearGrid();
                                    this._prevCustomerCode = customerCode;
                                }
                                else
                                {
                                    this._prevCustomerCode = customerCode;
                                }
                            }
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_CustomerName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_CustomerCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case "tEdit_EmployeeCode":
                    {
                        if (this.tEdit_EmployeeCode.DataText.Trim() == "")
                        {
                            this.tEdit_EmployeeName.Clear();
                            this._prevEmployeeCode = "";
                            return;
                        }

                        // 従業員コード取得
                        string employeeCode = this.tEdit_EmployeeCode.DataText.Trim().PadLeft(4, '0');

                        if (employeeCode != this._prevEmployeeCode)
                        {
                            // 従業員名取得
                            this.tEdit_EmployeeName.DataText = GetEmployeeName(employeeCode);

                            if (CheckSaveConfirm() == false)
                            {
                                this._prevEmployeeCode = employeeCode;
                            }
                            else
                            {
                                if (this._searchFlg)
                                {
                                    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                        "",
                                                                        0,
                                                                        MessageBoxButtons.YesNoCancel,
                                                                        MessageBoxDefaultButton.Button2);
                                    switch (result)
                                    {
                                        case DialogResult.Yes:
                                            {
                                                // 保存処理
                                                status = SaveProc();
                                                if (status != 0)
                                                {
                                                    this._prevEmployeeCode = employeeCode;
                                                    return;
                                                }

                                                break;
                                            }
                                        case DialogResult.No:
                                            {
                                                break;
                                            }
                                        case DialogResult.Cancel:
                                            {
                                                this.tEdit_EmployeeCode.DataText = this._prevEmployeeCode;
                                                this.tEdit_EmployeeName.DataText = GetEmployeeName(this._prevEmployeeCode);
                                                return;
                                            }
                                    }
                                }

                                // 検索
                                status = SearchProc();
                                if (status != 0)
                                {
                                    ClearGrid();
                                    this._prevEmployeeCode = employeeCode;
                                }
                                else
                                {
                                    this._prevEmployeeCode = employeeCode;
                                }
                            }
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_EmployeeName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tEdit_EmployeeCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_SalesAreaCode":
                    {
                        if (this.tNedit_SalesAreaCode.GetInt() == 0)
                        {
                            this.tEdit_SalesAreaName.Clear();
                            this._prevSalesAreaCode = 0;
                            return;
                        }

                        // 地区コード取得
                        int salesAreaCode = this.tNedit_SalesAreaCode.GetInt();

                        if (salesAreaCode != this._prevSalesAreaCode)
                        {
                            // 地区名取得
                            this.tEdit_SalesAreaName.DataText = GetSalesAreaName(salesAreaCode);

                            if (CheckSaveConfirm() == false)
                            {
                                this._prevSalesAreaCode = salesAreaCode;
                            }
                            else
                            {
                                if (this._searchFlg)
                                {
                                    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                        "",
                                                                        0,
                                                                        MessageBoxButtons.YesNoCancel,
                                                                        MessageBoxDefaultButton.Button2);
                                    switch (result)
                                    {
                                        case DialogResult.Yes:
                                            {
                                                // 保存処理
                                                status = SaveProc();
                                                if (status != 0)
                                                {
                                                    this._prevSalesAreaCode = salesAreaCode;
                                                    return;
                                                }

                                                break;
                                            }
                                        case DialogResult.No:
                                            {
                                                break;
                                            }
                                        case DialogResult.Cancel:
                                            {
                                                this.tNedit_SalesAreaCode.SetInt(this._prevSalesAreaCode);
                                                this.tEdit_SalesAreaName.DataText = GetSalesAreaName(this._prevSalesAreaCode);
                                                return;
                                            }
                                    }
                                }

                                // 検索
                                status = SearchProc();
                                if (status != 0)
                                {
                                    ClearGrid();
                                    this._prevSalesAreaCode = salesAreaCode;
                                }
                                else
                                {
                                    this._prevSalesAreaCode = salesAreaCode;
                                }
                            }
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_SalesAreaName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_SalesAreaCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_BusinessTypeCode":
                    {
                        if (this.tNedit_BusinessTypeCode.GetInt() == 0)
                        {
                            this.tEdit_BusinessTypeName.Clear();
                            this._prevBusinessTypeCode = 0;
                            return;
                        }

                        // 業種コード取得
                        int businessTypeCode = this.tNedit_BusinessTypeCode.GetInt();

                        if (businessTypeCode != this._prevBusinessTypeCode)
                        {
                            // 業種名取得
                            this.tEdit_BusinessTypeName.DataText = GetBusinessTypeName(businessTypeCode);

                            if (CheckSaveConfirm() == false)
                            {
                                this._prevBusinessTypeCode = businessTypeCode;
                            }
                            else
                            {
                                if (this._searchFlg)
                                {
                                    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                        "",
                                                                        0,
                                                                        MessageBoxButtons.YesNoCancel,
                                                                        MessageBoxDefaultButton.Button2);
                                    switch (result)
                                    {
                                        case DialogResult.Yes:
                                            {
                                                // 保存処理
                                                status = SaveProc();
                                                if (status != 0)
                                                {
                                                    this._prevBusinessTypeCode = businessTypeCode;
                                                    return;
                                                }

                                                break;
                                            }
                                        case DialogResult.No:
                                            {
                                                break;
                                            }
                                        case DialogResult.Cancel:
                                            {
                                                this.tNedit_BusinessTypeCode.SetInt(this._prevBusinessTypeCode);
                                                this.tEdit_BusinessTypeName.DataText = GetBusinessTypeName(this._prevBusinessTypeCode);
                                                return;
                                            }
                                    }
                                }

                                // 検索
                                status = SearchProc();
                                if (status != 0)
                                {
                                    ClearGrid();
                                    this._prevBusinessTypeCode = businessTypeCode;
                                }
                                else
                                {
                                    this._prevBusinessTypeCode = businessTypeCode;
                                }
                            }
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_BusinessTypeName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_BusinessTypeCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case "SectionGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 10)
                                {
                                    e.NextCtrl = null;
                                }
                            }
                            else if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.tNedit_SalesTargetSale;
                                return;
                            }
                        }
                        break;
                    }
                case "SubSectionGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                if ((int)this.tComboEditor_TargetContrastCd.Value == 20)
                                {
                                    e.NextCtrl = null;
                                }
                            }
                            else if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.tNedit_SalesTargetSale;
                                return;
                            }
                        }
                        break;
                    }
                case "CustomerGuide_Button":
                case "EmployeeGuide_Button":
                case "SalesAreaGuide_Button":
                case "BusinessTypeGuide_Button":
                case "SalesCodeGuide_Button":
                case "EnterpriseGanreGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.tNedit_SalesTargetSale;
                                return;
                            }
                        }
                        break;
                    }
                case "tNedit_SalesCode":
                    {
                        if (tNedit_SalesCode.GetInt() == 0)
                        {
                            this.tEdit_SalesCodeName.Clear();
                            this._prevSalesCode = 0;
                            return;
                        }

                        // 販売区分コード取得
                        int salesCode = this.tNedit_SalesCode.GetInt();

                        if (salesCode != this._prevSalesCode)
                        {
                            // 販売区分名取得
                            this.tEdit_SalesCodeName.DataText = GetSalesCodeName(salesCode);

                            if (CheckSaveConfirm() == false)
                            {
                                this._prevSalesCode = salesCode;
                            }
                            else
                            {
                                if (this._searchFlg)
                                {
                                    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                        "",
                                                                        0,
                                                                        MessageBoxButtons.YesNoCancel,
                                                                        MessageBoxDefaultButton.Button2);
                                    switch (result)
                                    {
                                        case DialogResult.Yes:
                                            {
                                                // 保存処理
                                                status = SaveProc();
                                                if (status != 0)
                                                {
                                                    this._prevSalesCode = salesCode;
                                                    return;
                                                }

                                                break;
                                            }
                                        case DialogResult.No:
                                            {
                                                break;
                                            }
                                        case DialogResult.Cancel:
                                            {
                                                this.tNedit_SalesCode.SetInt(this._prevSalesCode);
                                                this.tEdit_SalesCodeName.DataText = GetSalesCodeName(this._prevSalesCode);
                                                return;
                                            }
                                    }
                                }

                                // 検索
                                status = SearchProc();
                                if (status != 0)
                                {
                                    ClearGrid();
                                    this._prevSalesCode = salesCode;
                                }
                                else
                                {
                                    this._prevSalesCode = salesCode;
                                }
                            }
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_SalesCodeName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_SalesCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCode;
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_EnterpriseGanreCode":
                    {
                        if (this.tNedit_EnterpriseGanreCode.GetInt() == 0)
                        {
                            this.tEdit_EnterpriseGanreName.Clear();
                            this._prevEnterpriseGanreCode = 0;
                            return;
                        }

                        // 商品区分コード取得
                        int enterpriseGanreCode = this.tNedit_EnterpriseGanreCode.GetInt();

                        if (enterpriseGanreCode != this._prevEnterpriseGanreCode)
                        {
                            this._prevEnterpriseGanreCode = enterpriseGanreCode;

                            // 商品区分名取得
                            this.tEdit_EnterpriseGanreName.DataText = GetEnterpriseGanreName(enterpriseGanreCode);

                            if (CheckSaveConfirm() == false)
                            {
                                this._prevEnterpriseGanreCode = enterpriseGanreCode;
                            }
                            else
                            {
                                if (this._searchFlg)
                                {
                                    DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                                        "",
                                                                        0,
                                                                        MessageBoxButtons.YesNoCancel,
                                                                        MessageBoxDefaultButton.Button2);
                                    switch (result)
                                    {
                                        case DialogResult.Yes:
                                            {
                                                // 保存処理
                                                status = SaveProc();
                                                if (status != 0)
                                                {
                                                    this._prevEnterpriseGanreCode = enterpriseGanreCode;
                                                    return;
                                                }

                                                break;
                                            }
                                        case DialogResult.No:
                                            {
                                                break;
                                            }
                                        case DialogResult.Cancel:
                                            {
                                                this.tNedit_EnterpriseGanreCode.SetInt(this._prevEnterpriseGanreCode);
                                                this.tEdit_EnterpriseGanreName.DataText = GetEnterpriseGanreName(this._prevEnterpriseGanreCode);
                                                return;
                                            }
                                    }
                                }

                                // 検索
                                status = SearchProc();
                                if (status != 0)
                                {
                                    ClearGrid();
                                    this._prevEnterpriseGanreCode = enterpriseGanreCode;
                                }
                                else
                                {
                                    this._prevEnterpriseGanreCode = enterpriseGanreCode;
                                }
                            }
                        }

                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (this.tEdit_EnterpriseGanreName.DataText.Trim() != "")
                                {
                                    Control nextControl;
                                    GetNextControl(this.tNedit_EnterpriseGanreCode, out nextControl);
                                    e.NextCtrl = nextControl;
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_SalesTargetSale":
                    {
                        // フォーカス設定
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = null;
                                this.SalesTarget_uGrid.Focus();
                                this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_SALESTARGET].Activate();
                                this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.Mode_Label.Text == INSERT_MODE)
                                {
                                    // 設定区分
                                    int targetContrastCd = (int)this.tComboEditor_TargetContrastCd.Value;

                                    switch (targetContrastCd)
                                    {
                                        case 10:    // 拠点
                                            {
                                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                                {
                                                    e.NextCtrl = this.tEdit_SectionCode;
                                                    return;
                                                }
                                                break;
                                            }
                                        case 20:    // 拠点＋部門
                                            {
                                                if (this.tEdit_SubSectionName.DataText.Trim() != "")
                                                {
                                                    e.NextCtrl = this.tNedit_SubSectionCode;
                                                    return;
                                                }
                                                break;
                                            }
                                        case 30:    // 拠点＋得意先
                                            {
                                                if (this.tEdit_CustomerName.DataText.Trim() != "")
                                                {
                                                    e.NextCtrl = this.tNedit_CustomerCode;
                                                    return;
                                                }
                                                break;
                                            }
                                        case 221:   // 拠点＋担当者
                                        case 222:   // 拠点＋受注者
                                        case 223:   // 拠点＋発行者
                                            {
                                                if (this.tEdit_EmployeeName.DataText.Trim() != "")
                                                {
                                                    e.NextCtrl = this.tEdit_EmployeeCode;
                                                    return;
                                                }
                                                break;
                                            }
                                        case 32:    // 拠点＋地区
                                            {
                                                if (this.tEdit_SalesAreaName.DataText.Trim() != "")
                                                {
                                                    e.NextCtrl = this.tNedit_SalesAreaCode;
                                                    return;
                                                }
                                                break;
                                            }
                                        case 31:    // 拠点＋業種
                                            {
                                                if (this.tEdit_BusinessTypeName.DataText.Trim() != "")
                                                {
                                                    e.NextCtrl = this.tNedit_SalesCode;
                                                    return;
                                                }
                                                break;
                                            }
                                        case 44:    // 拠点＋販売区分
                                            {
                                                if (this.tEdit_BusinessTypeName.DataText.Trim() != "")
                                                {
                                                    e.NextCtrl = this.tNedit_BusinessTypeCode;
                                                    return;
                                                }
                                                break;
                                            }
                                        case 45:    // 商品区分
                                            {
                                                if (this.tEdit_EnterpriseGanreName.DataText.Trim() != "")
                                                {
                                                    e.NextCtrl = this.tNedit_EnterpriseGanreCode;
                                                    return;
                                                }
                                                break;
                                            }
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = this.SalesTarget_uGrid;
                                }
                            }
                        }
                        break;
                    }
                case "tNedit_SalesTargetProfit":
                    {
                        if (e.Key == Keys.Down)
                        {
                            e.NextCtrl = null;
                            this.SalesTarget_uGrid.Focus();
                            this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_PROFITTARGET].Activate();
                            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                        break;
                    }
                case "tNedit_SalesTargetCount":
                    {
                        if (e.Key == Keys.Down)
                        {
                            e.NextCtrl = null;
                            this.SalesTarget_uGrid.Focus();
                            this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_COUNTTARGET].Activate();
                            this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                        break;
                    }
                case "SalesTarget_uGrid":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                SetNextCell(ref e, false);
                                return;
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                SetNextCell(ref e, true);
                                return;
                            }
                        }
                        break;
                    }
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            if (e.NextCtrl == this.SalesTarget_uGrid)
            {
                e.NextCtrl = null;

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        this.SalesTarget_uGrid.Rows[0].Cells[COLUMN_RATIO].Activate();
                    }
                }
                else
                {
                    this.SalesTarget_uGrid.Rows[11].Cells[COLUMN_COUNTTARGET].Activate();
                }
                
                this.SalesTarget_uGrid.PerformAction(UltraGridAction.EnterEditMode);
            }
        }

        #endregion ■ Control Events
    }
}