using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上速報表示 アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上速報表示のアクセスクラスです。</br>
    /// <br>Programmer : 30418 徳永</br>
    /// <br>Date       : 2008.11.21</br>
    /// <br></br>
    /// </remarks>
    public partial class SalesReportAcs
    {
        #region プライベート変数

        /// <summary>売上速報表示リモートクラス</summary>
        private ISalesReportOrderWorkDB _salesReportOrderWorkDB = null;

        /// <summary>売上速報表示リモート検索条件ワーククラス</summary>
        private SalesReportOrderCndtnWork _salesReportOrderCndtnWork = null;

        /// <summary>売上速報表示一覧データセット</summary>
        private SalesReportDataSet _dataSet = null;

        #endregion // プライベート変数

        #region 合計行算出用

        /// <summary>純売上合計</summary>
        private Int64 _salesTotalTaxExc_Total = 0;

        /// <summary>売上目標金額合計</summary>
        private Int64 _salesTargetMoney_Total = 0;

        /// <summary>粗利合計</summary>
        private Int64 _grossMargin_Total = 0;

        /// <summary>粗利目標合計</summary>
        private Int64 _salesTargetProfit_Total = 0;


        #endregion // 合計行算出用

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SalesReportAcs()
        {
            // リモートDB取得
            _salesReportOrderWorkDB = MediationSalesReportOrderWorkDB.GetSalesReportOrderWorkDB();

            // 検索条件クラス作成
            _salesReportOrderCndtnWork = new SalesReportOrderCndtnWork();

            // データセット作成
            this._dataSet = new SalesReportDataSet();

            // コンストラクタよりインスタンスを作成した時点で、データセットが有効になる

        }

        #endregion // コンストラクタ

        #region パブリックオブジェクト

        /// <summary>
        /// 得意先過年度実績照会一覧データセット
        /// </summary>
        public SalesReportDataSet DataSet
        {
            get { return this._dataSet; }
            set { this._dataSet = value; }
        }

        #endregion // パブリックオブジェクト

        #region 検索実行

        /// <summary>
        /// 検索実行
        /// </summary>
        public int Search(SalesReportOrderCndtn salesReportOrderCndtn, out int recordCount)
        {
            // 検索条件クラスからリモート検索条件ワーククラスへコピー
            CopyParamater2RemoteParameterWork(salesReportOrderCndtn);

            // ローカル変数を初期化
            this._salesTotalTaxExc_Total = 0;
            this._grossMargin_Total = 0;
            this._salesTargetMoney_Total = 0;
            this._salesTargetProfit_Total = 0;

            // 検索実行
            object result;
            int status = _salesReportOrderWorkDB.Search(out result, (object)this._salesReportOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 件数
                recordCount = ((ArrayList)result).Count;

                // データセットへ読み込んだ情報をセット
                if (result != null && result is ArrayList)
                {
                    int rowNo = 1;
                    foreach (SalesReportResultWork resultWork in (ArrayList)result)
                    {
                        AddRowData(resultWork, salesReportOrderCndtn, rowNo);
                        rowNo++;
                    }

                    // 合計行を作成
                    DataRow row = this._dataSet.SalesReportResult.NewRow();

                    // 小数点以下を処理するためにDouble型で計算
                    Double dParent = 0;
                    Double dChild = 0;

                    row[this._dataSet.SalesReportResult.RowNoColumn.ColumnName] = rowNo;
                    row[this._dataSet.SalesReportResult.EnterpriseCodeColumn.ColumnName] = string.Empty;
                    row[this._dataSet.SalesReportResult.SectionCodeColumn.ColumnName] = string.Empty;
                    row[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName] = "合計";
                    row[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName] = this._salesTotalTaxExc_Total;
                    if (this._salesTargetMoney_Total > 0)
                    {
                        row[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName] = this._salesTargetMoney_Total;
                        dParent = Double.Parse(this._salesTotalTaxExc_Total.ToString());
                        dChild = Double.Parse(this._salesTargetMoney_Total.ToString());
                        row[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName] = dParent / dChild * 100;
                    }
                    row[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName] = this._grossMargin_Total;
                    if (this._salesTargetProfit_Total > 0)
                    {
                        row[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName] = this._salesTargetProfit_Total;
                        dParent = Double.Parse(this._grossMargin_Total.ToString());
                        dChild = Double.Parse(this._salesTargetProfit_Total.ToString());
                        row[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName] = dParent / dChild * 100;
                    }
                    row[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName] = string.Empty;
                    this._dataSet.SalesReportResult.Rows.Add(row);
                }
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
        /// リモート検索条件ワーククラスを元にデータセットに行を作成
        /// </summary>
        /// <param name="customInqOrderCndtnWork">検索結果ワーク</param>
        private void AddRowData(SalesReportResultWork salesReportResultWork, SalesReportOrderCndtn salesReportOrderCndtn, int rowNo)
        {
            DataRow row = this._dataSet.SalesReportResult.NewRow();

            row[this._dataSet.SalesReportResult.RowNoColumn.ColumnName] = rowNo;
            row[this._dataSet.SalesReportResult.EnterpriseCodeColumn.ColumnName] = salesReportResultWork.EnterpriseCode;
            row[this._dataSet.SalesReportResult.SectionCodeColumn.ColumnName] = salesReportResultWork.SectionCode;
            row[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName] = salesReportResultWork.SectionGuideSnm;

            // 純売上
            row[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName] = salesReportResultWork.SalesTotalTaxExc;
            _salesTotalTaxExc_Total += salesReportResultWork.SalesTotalTaxExc;

            // 売上目標, 達成率(空の時は空白)
            if (salesReportResultWork.SalesTargetMoney > 0)
            {
                row[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName] = salesReportResultWork.SalesTargetMoney;
                _salesTargetMoney_Total += salesReportResultWork.SalesTargetMoney;
                row[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName] = salesReportResultWork.AchievementRateNet;
            }
            
            // 粗利
            row[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName] = salesReportResultWork.GrossMargin;
            _grossMargin_Total += salesReportResultWork.GrossMargin;

            // 粗利目標, 達成率(空の時は空白)
            if (salesReportResultWork.SalesTargetProfit > 0)
            {
                row[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName] = salesReportResultWork.SalesTargetProfit;
                _salesTargetProfit_Total += salesReportResultWork.SalesTargetProfit;
                row[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName] = salesReportResultWork.AchievementRateGross;
            }

            // 稼働日
            row[this._dataSet.SalesReportResult.OperationDayColumn.ColumnName] = salesReportResultWork.OperationDay;
            row[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName] = salesReportResultWork.OperationDay.ToString() + "日";

            this._dataSet.SalesReportResult.Rows.Add(row);

        }

        #endregion // データセット行作成

        #region 検索条件クラス→リモート検索条件ワーククラス　データコピー

        /// <summary>
        /// 検索条件クラス→リモート検索条件ワーククラス　データコピー
        /// </summary>
        /// <param name="customInqOrderCndtn"></param>
        private void CopyParamater2RemoteParameterWork(SalesReportOrderCndtn salesReportOrderCndtn)
        {
            this._salesReportOrderCndtnWork.SectionCode = salesReportOrderCndtn.SectionCode;
            this._salesReportOrderCndtnWork.EnterpriseCode = salesReportOrderCndtn.EnterpriseCode;
            this._salesReportOrderCndtnWork.St_SalesDate = TDateTime.LongDateToDateTime(salesReportOrderCndtn.St_SalesDate);
            this._salesReportOrderCndtnWork.Ed_SalesDate = TDateTime.LongDateToDateTime(salesReportOrderCndtn.Ed_SalesDate);
        }

        #endregion // 検索条件クラス→リモート検索条件ワーククラス　データコピー
    }
}
