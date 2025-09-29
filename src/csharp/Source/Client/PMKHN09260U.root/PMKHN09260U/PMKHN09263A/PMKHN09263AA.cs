using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller.Facade;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 与信額設定処理 アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 与信額設定処理のアクセスクラスです。</br>
    /// <br>Programmer : 30418 徳永</br>
    /// <br>Date       : 2008.12.02</br>
    /// <br></br>
    /// </remarks>
    public partial class CustomerCreditAcs
    {

        #region プライベート変数

        /// <summary>与信額設定処理リモートクラス</summary>
        private ICustCreditDB _custCreditDB = null;

        /// <summary>与信額設定処理リモート検索条件ワーククラス</summary>
        private CustCreditCndtnWork _custCreditCndtnWork = null;

        /// <summary>結果保存用データセット</summary>
        private CustomerChangeDataSet _dataSet = null;

        /// <summary>ログ保存用インタフェースオブジェクト</summary>
        OperationHistoryLog _operationLog = null;
        
        #endregion // プライベート変数

        #region ログ更新用

        /// <summary>ログ用フォーマット：処理名「現在売掛残高設定」</summary>
        private const string CT_PROCESS_NAME_SETTINGCURRENT = "現在売上残高設定";

        /// <summary>ログ用フォーマット：処理名「与信額ｸﾘｱ」</summary>
        private const string CT_PROCESS_NAME_CLEARCREDIT = "与信額ｸﾘｱ";

        /// <summary>ログ用フォーマット：現在売掛残高設定</summary>
        private const string CT_LOGFORMAT_SETTINGCURRENT = "得意先:{0}　現在売掛残高:{1}";

        /// <summary>ログ用フォーマット：与信額クリア処理基本</summary>
        private const string CT_LOGFORMAT_CLEARCREDIT_0 = "得意先:{0}　";

        /// <summary>ログ用フォーマット：与信額クリア処理 与信額:0</summary>
        private const string CT_LOGFORMAT_CLEARCREDIT_1 = "与信額:0　";

        /// <summary>ログ用フォーマット：与信額クリア処理 警告与信額:0</summary>
        private const string CT_LOGFORMAT_CLEARCREDIT_2 = "警告与信額:0　";

        /// <summary>ログ用フォーマット：与信額クリア処理 現在売掛残高:0</summary>
        private const string CT_LOGFORMAT_CLEARCREDIT_3 = "現在売掛残高:0";

        #endregion //ログ更新用

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CustomerCreditAcs()
        {
            // リモートDB取得
            this._custCreditDB = MediationCustCreditDB.GetCustCreditDB();

            // 検索条件クラス作成
            this._custCreditCndtnWork = new CustCreditCndtnWork();

            // データセット作成
            // コンストラクタよりインスタンスを作成した時点で、データセットが有効になる
            this._dataSet = new CustomerChangeDataSet();
        }

        #endregion // コンストラクタ

        #region パブリックオブジェクト

        /// <summary>
        /// 与信額設定処理結果一覧データセット
        /// </summary>
        public CustomerChangeDataSet DataSet
        {
            get { return this._dataSet; }
            set { this._dataSet = value; }
        }

        #endregion // パブリックオブジェクト

        #region 検索実行

        /// <summary>
        /// 検索実行
        /// </summary>
        public int Search(CustCreditCndtn custCreditCndtn, out int recordCount)
        {
            // 検索条件クラスからリモート検索条件ワーククラスへコピー
            CopyParamater2RemoteParameterWork(custCreditCndtn);

            // ローカル変数を初期化


            // 検索実行
            object result;
            int status = this._custCreditDB.Write(out result, (object)this._custCreditCndtnWork);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 件数
                recordCount = ((ArrayList)result).Count;

                // データセットへ読み込んだ情報をセット
                if (result != null && result is ArrayList)
                {
                    foreach (CustomerChangeWork resultWork in (ArrayList)result)
                    {
                        // 結果テーブルへ行を作成
                        AddRowData(resultWork);
                    }
                }

                // ログ出力
                OutputLog();
            }
            else
            {
                recordCount = 0;
                return status;
            }

            return status;
        }

        #endregion // 検索実行

        #region データセット行作成

        /// <summary>
        /// データセット行作成
        /// </summary>
        /// <param name="supplierSlipNo">保存された伝票番号</param>
        /// <param name="slipRowNo">行番号</param>
        private void AddRowData(CustomerChangeWork resultWork)
        {
            // 対象は[CustomerChangeWork]テーブル
            DataRow row = this._dataSet.CustomerChange.NewRow();

            // 作成日時
            row[this._dataSet.CustomerChange.CreateDateTimeColumn.ColumnName] = resultWork.CreateDateTime;

            // 更新日時
            row[this._dataSet.CustomerChange.UpdateDateTimeColumn.ColumnName] = resultWork.UpdateDateTime;

            // 企業コード
            row[this._dataSet.CustomerChange.EnterpriseCodeColumn.ColumnName] = resultWork.EnterpriseCode;

            // GUID
            row[this._dataSet.CustomerChange.FileHeaderGuidColumn.ColumnName] = resultWork.FileHeaderGuid;

            // 更新従業員コード
            row[this._dataSet.CustomerChange.UpdEmployeeCodeColumn.ColumnName] = resultWork.UpdEmployeeCode;

            // 更新アセンブリID1
            row[this._dataSet.CustomerChange.UpdAssemblyId1Column.ColumnName] = resultWork.UpdAssemblyId1;

            // 更新アセンブリID2
            row[this._dataSet.CustomerChange.UpdAssemblyId2Column.ColumnName] = resultWork.UpdAssemblyId2;

            // 論理削除区分
            row[this._dataSet.CustomerChange.LogicalDeleteCodeColumn.ColumnName] = resultWork.LogicalDeleteCode;

            // 得意先コード
            row[this._dataSet.CustomerChange.CustomerCodeColumn.ColumnName] = resultWork.CustomerCode;

            // 与信額
            row[this._dataSet.CustomerChange.CreditMoneyColumn.ColumnName] = resultWork.CreditMoney;

            // 警告与信額
            row[this._dataSet.CustomerChange.WarningCreditMoneyColumn.ColumnName] = resultWork.WarningCreditMoney;

            // 現在売掛残高
            row[this._dataSet.CustomerChange.PrsntAccRecBalanceColumn.ColumnName] = resultWork.PrsntAccRecBalance;

            this._dataSet.CustomerChange.Rows.Add(row);
        }

        #endregion // データセット行作成

        #region 検索条件クラス→リモート検索条件ワーククラス　データコピー

        /// <summary>
        /// 検索条件クラス→リモート検索条件ワーククラス　データコピー
        /// </summary>
        /// <param name="customInqOrderCndtn"></param>
        private void CopyParamater2RemoteParameterWork(CustCreditCndtn custCreditCndtn)
        {
            this._custCreditCndtnWork.EnterpriseCode = custCreditCndtn.EnterpriseCode;
            this._custCreditCndtnWork.CustomerCodes = custCreditCndtn.CustomerCodes;

            this._custCreditCndtnWork.St_CustomerCode = custCreditCndtn.St_CustomerCode;
            this._custCreditCndtnWork.Ed_CustomerCode = custCreditCndtn.Ed_CustomerCode;

            this._custCreditCndtnWork.TotalDay = custCreditCndtn.TotalDay;
            this._custCreditCndtnWork.ProcDiv = custCreditCndtn.ProcDiv;

            this._custCreditCndtnWork.CreditMoneyFlg = custCreditCndtn.CreditMoneyFlg;
            this._custCreditCndtnWork.WarningCrdMnyFrg = custCreditCndtn.WarningCrdMnyFrg;
            this._custCreditCndtnWork.AccRecDiv = custCreditCndtn.AccRecDiv;
        }

        #endregion // 検索条件クラス→リモート検索条件ワーククラス　データコピー

        #region ログ出力

        /// <summary>
        /// ログ出力
        /// </summary>
        /// <returns></returns>
        private int OutputLog()
        {
            // ログ保存用クラス作成
            if (this._operationLog == null)
            {
                _operationLog = new OperationHistoryLog();
            }

            foreach (DataRow row in this._dataSet.CustomerChange.Rows)
            {
                string message = string.Empty;
                string logData = string.Empty;

                if (this._custCreditCndtnWork.ProcDiv == 0)
                {
                    message = CT_PROCESS_NAME_SETTINGCURRENT;
                    logData = String.Format(CT_LOGFORMAT_SETTINGCURRENT,
                                ((Int32)row[this._dataSet.CustomerChange.CustomerCodeColumn.ColumnName]).ToString(),
                                ((Int64)row[this._dataSet.CustomerChange.PrsntAccRecBalanceColumn.ColumnName]).ToString());
                }
                else
                {
                    message = CT_PROCESS_NAME_CLEARCREDIT;
                    logData = String.Format(CT_LOGFORMAT_CLEARCREDIT_0,
                                ((Int32)row[this._dataSet.CustomerChange.CustomerCodeColumn.ColumnName]).ToString());
                    if (this._custCreditCndtnWork.CreditMoneyFlg) logData += CT_LOGFORMAT_CLEARCREDIT_1;
                    if (this._custCreditCndtnWork.WarningCrdMnyFrg) logData += CT_LOGFORMAT_CLEARCREDIT_2;
                    if (this._custCreditCndtnWork.AccRecDiv) logData += CT_LOGFORMAT_CLEARCREDIT_3;
                }

                // ログ出力
                _operationLog.WriteOperationLog(this,
                        LogDataKind.SystemLog,
                        "PMKHN09261U",
                        "与信額設定処理",
                        string.Empty,
                        0,
                        0,
                        message,
                        logData);
            }

            return 0;
        }

        #endregion // ログ出力

    }
}
