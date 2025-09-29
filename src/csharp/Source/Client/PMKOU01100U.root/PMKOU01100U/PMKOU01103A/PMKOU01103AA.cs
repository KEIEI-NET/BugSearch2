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
    /// 仕入チェック処理 アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入チェック処理のアクセスクラスです。</br>
    /// <br>Programmer : 30418 徳永</br>
    /// <br>Date       : 2008.11.25</br>
    /// <br>Update Note: 2009/03/24 30414 忍 障害ID:12789対応</br>
    /// <br></br>
    /// <br>Update Note: 2010/09/14 30517 夏野 駿希</br>
    /// <br>             Mantis.16053 転嫁方式により消費税と仕入金額の表示方法を変更</br>
    /// <br>Update Note: 2010/10/21 李占川</br>
    /// <br>             MANTIS：0016368、0016384 金額、消費税表示内容の変更</br>
    /// <br>Update Note: 2012/08/30 凌小青</br>
    /// <br>             Redmine#31879の対応 UOE仕入データの区分を取得</br>
    /// <br>Update Note: 2012/10/09 朱 猛</br>
    /// <br>             Redmine#31879の対応 赤伝区分を取得</br>
    /// </remarks>
    public partial class SupplierCheckAcs
    {
        #region プライベート変数

        /// <summary>仕入チェック処理リモートクラス</summary>
        private ISupplierCheckOrderWorkDB _supplierCheckOrderWorkDB = null;

        /// <summary>仕入チェック処理リモート検索条件ワーククラス</summary>
        private SupplierCheckOrderCndtnWork _supplierCheckOrderCndtnWork = null;

        /// <summary>仕入チェック処理結果クラス</summary>
        private SupplierCheckResult _supplierCheckResult = null;

        /// <summary>仕入チェック処理一覧データセット</summary>
        private SupplierCheckDataSet _dataSet = null;

        /// <summary>同一伝票チェック用仕入SEQ番号</summary>
        private Int32 _currentSupplierSlipNo = 0;

        /// <summary>同一伝票日次チェック用ステータス 0:未チェック, 1:チェック, 2:不鮮明</summary>
        private Int32 _dailyCheckStatus = 0;

        /// <summary>同一伝票締次チェック用ステータス 0:未チェック, 1:チェック, 2:不鮮明</summary>
        private Int32 _calcCheckStatus = 0;

        /// <summary>同一伝票内税込金額累計</summary>
        private Int64 _totalStockPriceTaxInc = 0;

        /// <summary>同一伝票内金額累計</summary>
        private Int64 _totalStockPriceTaxExc = 0;

        /// <summary>同一伝票内消費税累計</summary>
        private Int64 _totalStockPriceConsTax = 0;

        /// <summary>更新日時</summary>
        private DateTime _updateDateTime;

        /// <summary>更新職員コード</summary>
        private string _updateEmployeeCd = string.Empty;

        /// <summary>UIアセンブリID</summary>
        private string _UIAssemblyId = string.Empty;

        #endregion // プライベート変数

        #region 合計表示用

        /// <summary>金額</summary>
        private Int64 _tAmount = 0;

        /// <summary>消費税</summary>
        private Int64 _tAmountConsumeTax = 0;

        /// <summary>税込金額</summary>
        private Int64 _tAmountTaxInc = 0;

        /// <summary>総税込金額</summary>
        private Int64 _tAmountTaxIncAll = 0;

        /// <summary>返品金額</summary>
        private Int64 _tReturn = 0;

        /// <summary>返品消費税</summary>
        private Int64 _tReturnConsumeTax = 0;

        /// <summary>返品金額</summary>
        private Int64 _tReturnTaxInc = 0;

        /// <summary>伝票枚数</summary>
        private Int32 _tSlipCount = 0;

        /// <summary>明細数</summary>
        private Int32 _tDetailCount = 0;


        /// <summary>画面用合計（総合計）</summary>
        private Int64 _dDisplaySum = 0;

        /// <summary>画面用合計（チェック付き/日次）</summary>
        private Int64 _dCheckSum_Daily = 0;

        /// <summary>画面用合計（チェック付き/締次）</summary>
        private Int64 _dCheckSum_Calc = 0;

        /// <summary>画面用合計（不足）</summary>
        private Int64 _dLackSum = 0;

        #endregion // 合計表示用

        #region 売上全体設定関連

        /// <summary>DCKHN09212A)売上全体設定</summary>
        private SalesTtlStAcs _salesTtlStAcs;

        /// <summary>企業コード</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>拠点コード</summary>
        private string _sectionCode = string.Empty;

        /// <summary>粗利チェック下限値</summary>
        private double _grsProfitCheckLower = 0;

        /// <summary>粗利チェック適正値</summary>
        private double _grsProfitCheckBest = 0;

        /// <summary>粗利チェック上限値</summary>
        private double _grsProfitCheckUpper = 0;

        /// <summary>粗利チェック下限マーク</summary>
        private string _grsProfitChkLowSign = string.Empty;

        /// <summary>粗利チェック適正マーク</summary>
        private string _grsProfitChkBestSign = string.Empty;

        /// <summary>粗利チェック上限マーク</summary>
        private string _grsProfitChkUprSign = string.Empty;

        /// <summary>粗利チェック限界マーク</summary>
        private string _grsProfitChkMaxSign = string.Empty;

        #endregion // 売上全体設定関連

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SupplierCheckAcs()
        {
            // リモートDB取得
            _supplierCheckOrderWorkDB = MediationSupplierCheckOrderWorkDB.GetSupplierCheckOrderWorkDB();

            // 検索条件クラス作成
            _supplierCheckOrderCndtnWork = new SupplierCheckOrderCndtnWork();

            // データセット作成
            this._dataSet = new SupplierCheckDataSet();

            // 検索結果データクラスを作成
            // 伝票データ作成に使用
            this._supplierCheckResult = new SupplierCheckResult();

            // 粗利マークデータを取得
            this._salesTtlStAcs = new SalesTtlStAcs();

            // コンストラクタよりインスタンスを作成した時点で、データセットが有効になる

        }

        #endregion // コンストラクタ

        #region パブリックオブジェクト

        /// <summary>
        /// 仕入チェック処理一覧データセット
        /// </summary>
        public SupplierCheckDataSet DataSet
        {
            get { return this._dataSet; }
            set { this._dataSet = value; }
        }

        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return this._enterpriseCode; }
            set { this._enterpriseCode = value; }
        }

        /// <summary>
        /// 拠点コード
        /// </summary>
        public string SectionCode
        {
            get { return this._sectionCode; }
            set { this._sectionCode = value; }
        }

        /// <summary>
        /// 更新者コード
        /// </summary>
        public string UpdateEmployeeCd
        {
            get { return this._updateEmployeeCd; }
            set { this._updateEmployeeCd = value; }
        }

        /// <summary>
        /// UIアセンブリID
        /// </summary>
        public string UIAssemblyId
        {
            get { return this._UIAssemblyId; }
            set { this._UIAssemblyId = value; }
        }

        #endregion // パブリックオブジェクト

        #region 粗利マーク取得

        /// <summary>
        /// 粗利マーク取得
        /// </summary>
        public void GetProfitMark()
        {
            ArrayList retSalesTtlSt;
            int status = this._salesTtlStAcs.SearchAll(out retSalesTtlSt, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (SalesTtlSt salesTtlSt in retSalesTtlSt)
                {
                    // 自拠点コードと同じものをピックアップ
                    if (salesTtlSt.SectionCode.Trim() == this._sectionCode.Trim())
                    {
                        // しきい値
                        this._grsProfitCheckLower = salesTtlSt.GrsProfitCheckLower;     // 下限値
                        this._grsProfitCheckBest = salesTtlSt.GrsProfitCheckBest;       // 適正値
                        this._grsProfitCheckUpper = salesTtlSt.GrsProfitCheckUpper;     // 上限値

                        // マーク
                        this._grsProfitChkLowSign = salesTtlSt.GrsProfitChkLowSign;     // 　　　～下限値
                        this._grsProfitChkBestSign = salesTtlSt.GrsProfitChkBestSign;   // 下限値～適正値
                        this._grsProfitChkUprSign = salesTtlSt.GrsProfitChkUprSign;     // 適正値～上限値
                        this._grsProfitChkMaxSign = salesTtlSt.GrsProfitChkMaxSign;     // 上限値～
                    }
                }
            }
        }

        #endregion // 粗利マーク取得

        #region 検索実行

        /// <summary>
        /// 検索実行
        /// </summary>
        public int Search(SupplierCheckOrderCndtn supplierCheckOrderCndtn, out int recordCount)
        {
            // 検索条件クラスからリモート検索条件ワーククラスへコピー
            CopyParamater2RemoteParameterWork(supplierCheckOrderCndtn);

            // ローカル変数を初期化
            if (this._supplierCheckResult == null)
            {
                this._supplierCheckResult = new SupplierCheckResult();
            }

            this._currentSupplierSlipNo = 0;
            this._tAmount = 0;
            this._tAmountConsumeTax = 0;
            this._tAmountTaxInc = 0;
            this._tAmountTaxIncAll = 0;
            this._tReturn = 0;
            this._tReturnConsumeTax = 0;
            this._tReturnTaxInc = 0;
            this._dDisplaySum = 0;
            this._dCheckSum_Daily = 0;
            this._dCheckSum_Calc = 0;
            this._dLackSum = 0;
            // 2008.12.10 add start [9030]
            this._tSlipCount = 0;
            this._tDetailCount = 0;
            // 2008.12.10 add end [9030]

            // 検索実行
            object result;
            int status = this._supplierCheckOrderWorkDB.Search(out result, (object)this._supplierCheckOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 件数
                recordCount = ((ArrayList)result).Count;

                // データセットへ読み込んだ情報をセット
                if (result != null && result is ArrayList)
                {
                    int detailRowNo = 1;
                    int slipRowNo = 1;
                    foreach (SupplierCheckResultWork resultWork in (ArrayList)result)
                    {
                        // 2010/09/14 Add >>>
                        // 転嫁方式による消費税の計算
                        if (resultWork.SuppCTaxLayCd >= 2 || resultWork.SuppCTaxLayCd == 0)
                        {
                            resultWork.StockPriceConsTax = 0;
                            resultWork.StockPriceTaxInc = resultWork.StockPriceTaxExc;
                            if (resultWork.SuppCTaxLayCd >= 2)
                            {
                                resultWork.StockTtlPriceConsTax = 0;
                                resultWork.StockTtlPricTaxInc = resultWork.StockTtlPricTaxExc;
                            }

                            // --- ADD 2010/10/21 ---------->>>>>
                            if (resultWork.SuppCTaxLayCd == 9)
                            {
                                resultWork.StockTtlPricTaxInc = resultWork.StockTotalPrice;
                                resultWork.StockTtlPricTaxExc = resultWork.StockSubttlPrice;
                            }
                            // --- ADD 2010/10/21 ----------<<<<<
                        }
                        // 2010/09/14 Add <<<
                        // 伝票番号を保存
                        if (this._currentSupplierSlipNo == 0)   // この部分は最初の一度のみ
                        {
                            this._currentSupplierSlipNo = resultWork.SupplierSlipNo;

                            // 明細に行を作成（仕入日/入力日/仕入SEQ番号/伝票番号：表示）
                            AddDetailRowData(resultWork, supplierCheckOrderCndtn, detailRowNo, true);

                            // 結果クラスにコピーして保存しておく
                            CopyResultwork2Result(resultWork);

                            // 累計リセット
                            if (resultWork.SuppCTaxLayCd == 1)
                            {
                                //this._totalStockPriceTaxInc = resultWork.StockPriceTaxInc;
                                //this._totalStockPriceTaxExc = resultWork.StockPriceTaxExc;
                                this._totalStockPriceConsTax = resultWork.StockPriceConsTax;
                            }
                            else
                            {
                                // 明細単位以外の場合は累計を使用
                                this._totalStockPriceConsTax = resultWork.StockTtlPriceConsTax;
                            }
                            this._totalStockPriceTaxInc = resultWork.StockTtlPricTaxInc;
                            this._totalStockPriceTaxExc = resultWork.StockTtlPricTaxExc;


                            // チェックボックスのステータスを保存
                            this._dailyCheckStatus = resultWork.StockCheckDivDaily;
                            this._calcCheckStatus = resultWork.StockCheckDivCAddUp;

                            if (this._dailyCheckStatus == 1) // 日次チェック
                            {
                                this._dCheckSum_Daily = resultWork.StockPriceTaxExc;
                                this._dCheckSum_Calc = 0;
                            }

                            if (this._calcCheckStatus == 1) // 締次チェック
                            {
                                this._dCheckSum_Daily = 0;
                                this._dCheckSum_Calc = resultWork.StockPriceTaxExc;
                            }

                            // --- ADD 2010/10/21 ---------->>>>>
                            // 仕入
                            if (resultWork.SupplierSlipCd == 10)
                            {
                                this._tAmountConsumeTax += resultWork.StockTtlPriceConsTax;    // 消費税額
                            }
                            else
                            {
                                this._tReturnConsumeTax += resultWork.StockTtlPriceConsTax;    // 消費税額
                            }
                            // --- ADD 2010/10/21 ----------<<<<<
                        }
                        else
                        {
                            // 同一伝票かどうかをチェック、同じであれば累計に加算
                            // 同一伝票チェックは仕入SEQ番号のみ(11/25 加藤L)
                            if (this._currentSupplierSlipNo == resultWork.SupplierSlipNo)
                            {
                                // 仕入先消費税転嫁方式コードが明細単位のときのみ消費税を合算する
                                if (resultWork.SuppCTaxLayCd == 1)
                                {
                                    //this._totalStockPriceTaxInc += resultWork.StockPriceTaxInc;
                                    //this._totalStockPriceTaxExc += resultWork.StockPriceTaxExc;
                                    this._totalStockPriceConsTax += resultWork.StockPriceConsTax;
                                }
                                // 明細単位以外の場合は累計を使用(リセット時に取得済み)

                                // 明細に行を作成（仕入日/入力日/仕入SEQ番号/伝票番号：非表示）
                                AddDetailRowData(resultWork, supplierCheckOrderCndtn, detailRowNo, false);

                                // チェックされているデータがあれば、チェック合計を加算
                                if (resultWork.StockCheckDivDaily == 1) // 日次チェック
                                {
                                    this._dCheckSum_Daily += resultWork.StockPriceTaxExc;
                                }
                                if (resultWork.StockCheckDivCAddUp == 1) // 締次チェック
                                {
                                    this._dCheckSum_Calc += resultWork.StockPriceTaxExc;
                                }

                                // チェックボックスのステータスを計算
                                // 前のデータと一つでも異なれば不鮮明化、一度不鮮明化すれば以降はチェック不要
                                if (this._dailyCheckStatus < 2 && this._dailyCheckStatus != resultWork.StockCheckDivDaily)
                                {
                                    this._dailyCheckStatus = 2;
                                }

                                if (this._calcCheckStatus < 2 && this._calcCheckStatus != resultWork.StockCheckDivCAddUp)
                                {
                                    this._calcCheckStatus = 2;
                                }
                            }
                            else
                            {
                                // 明細に行を作成（仕入日/入力日/仕入SEQ番号/伝票番号：表示）
                                AddDetailRowData(resultWork, supplierCheckOrderCndtn, detailRowNo, true);

                                // チェックされているデータがあれば、チェック合計を加算
                                if (resultWork.StockCheckDivDaily == 1) // 日次チェック
                                {
                                    this._dCheckSum_Daily += resultWork.StockPriceTaxExc;
                                }
                                if (resultWork.StockCheckDivCAddUp == 1) // 締次チェック
                                {
                                    this._dCheckSum_Calc += resultWork.StockPriceTaxExc;
                                }

                                // 同一でなければ伝票テーブルにデータを作成し、累計をリセット
                                AddSlipRowData(this._currentSupplierSlipNo, slipRowNo);
                                slipRowNo++;
                                this._tSlipCount++;      // 伝票枚数 + 1

                                // 結果クラスにコピーして保存しておく
                                CopyResultwork2Result(resultWork);

                                // 累計リセット
                                if (resultWork.SuppCTaxLayCd == 1)
                                {
                                    //this._totalStockPriceTaxInc = resultWork.StockPriceTaxInc;
                                    //this._totalStockPriceTaxExc = resultWork.StockPriceTaxExc;
                                    this._totalStockPriceConsTax = resultWork.StockPriceConsTax;
                                }
                                else
                                {
                                    // 明細単位以外の場合は累計を使用
                                    this._totalStockPriceConsTax = resultWork.StockTtlPriceConsTax;
                                }
                                this._totalStockPriceTaxInc = resultWork.StockTtlPricTaxInc;
                                this._totalStockPriceTaxExc = resultWork.StockTtlPricTaxExc;


                                this._dailyCheckStatus = resultWork.StockCheckDivDaily;
                                this._calcCheckStatus = resultWork.StockCheckDivCAddUp;

                                // 保存している番号を上書き
                                this._currentSupplierSlipNo = resultWork.SupplierSlipNo;

                                // --- ADD 2010/10/21 ---------->>>>>
                                // 仕入
                                if (resultWork.SupplierSlipCd == 10)
                                {
                                    this._tAmountConsumeTax += resultWork.StockTtlPriceConsTax;    // 消費税額
                                }
                                else
                                {
                                    this._tReturnConsumeTax += resultWork.StockTtlPriceConsTax;    // 消費税額
                                }
                                // --- ADD 2010/10/21 ----------<<<<<                                
                            }
                        }

                        // 明細の最後の行では必ず伝票を作成
                        if (detailRowNo == recordCount)
                        {
                            AddSlipRowData(this._currentSupplierSlipNo, slipRowNo);
                            slipRowNo++;
                            this._tSlipCount++;      // 伝票枚数 + 1
                        }

                        // 合計表示を計算
                        // 仕入
                        if (resultWork.SupplierSlipCd == 10)
                        {
                            this._tAmount += resultWork.StockPriceTaxExc;               // 金額
                            //this._tAmountConsumeTax += resultWork.StockPriceConsTax;    // 消費税額  // DEL 2010/10/21
                            this._tAmountTaxInc += resultWork.StockPriceTaxInc;         // 税込金額
                        }
                        else // 返品
                        {
                            this._tReturn += resultWork.StockPriceTaxExc;               // 金額
                            //this._tReturnConsumeTax += resultWork.StockPriceConsTax;    // 消費税額  // DEL 2010/10/21
                            this._tReturnTaxInc += resultWork.StockPriceTaxInc;         // 税込金額
                        }

                        // 合計伝票はカウントしない
                        if (resultWork.StockGoodsCd != 6)
                        {
                            this._tDetailCount++;        // 明細数 + 1
                        }

                        detailRowNo++;
                    }

                    // --- ADD 2010/10/21 ---------->>>>>
                    this._tAmountTaxInc = this._tAmount + this._tAmountConsumeTax;
                    this._tReturnTaxInc = this._tReturn + this._tReturnConsumeTax;
                    // --- ADD 2010/10/21 ----------<<<<<

                    // 合計テーブルへデータ行を作成
                    this._tAmountTaxIncAll = this._tAmountTaxInc + this._tReturnTaxInc;
                    AddTotalRowData();

                    // 画面用合計テーブルへ行を作成
                    AddSumRowData(supplierCheckOrderCndtn.ProcDiv);
                }
            }
            else
            {
                recordCount = 0;
                return status;
            }

            //object parameter = null;
            //status = this._supplierCheckOrderWorkDB.Write(ref parameter);

            // 初期化
            this._currentSupplierSlipNo = 0;
            this._supplierCheckResult = null;
            return status;
        }

        #endregion // 検索実行

        #region データセット行作成

        #region 伝票テーブル行作成

        /// <summary>
        /// リモート検索条件ワーククラスを元に伝票テーブルに行を作成
        /// </summary>
        /// <param name="supplierSlipNo">保存された伝票番号</param>
        /// <param name="slipRowNo">行番号</param>
        private void AddSlipRowData(int supplierSlipNo, int slipRowNo)
        {
            // 対象は[SlipList]テーブル
            DataRow row = this._dataSet.SlipList.NewRow();

            // this._supplierCheckResultに保存された一行目の明細のデータを使用してデータを作成

            // 仕入チェック（日次）
            if (this._dailyCheckStatus == 0) // 未チェック
            {
                row[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName] = false;
                row[this._dataSet.SlipList.CheckBoxDailyExColumn.ColumnName] = false;
            }
            else // 1及び2はチェック
            {
                row[this._dataSet.SlipList.CheckBoxDailyColumn.ColumnName] = true;
                row[this._dataSet.SlipList.CheckBoxDailyExColumn.ColumnName] = true;
            }

            // 仕入チェックステータス（日次） 0:未チェック 1:チェック 2:不鮮明
            row[this._dataSet.SlipList.CheckBoxDailyStatusColumn.ColumnName] = this._dailyCheckStatus;
            row[this._dataSet.SlipList.CheckBoxDailyStatusExColumn.ColumnName] = this._dailyCheckStatus;

            // 仕入チェック（締次）
            if (this._calcCheckStatus == 0) // 未チェック
            {
                row[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName] = false;
                row[this._dataSet.SlipList.CheckBoxCalcExColumn.ColumnName] = false;
            }
            else // 1及び2はチェック
            {
                row[this._dataSet.SlipList.CheckBoxCalcColumn.ColumnName] = true;
                row[this._dataSet.SlipList.CheckBoxCalcExColumn.ColumnName] = true;
            }

            // 仕入チェックステータス（締次） 0:未チェック 1:チェック 2:不鮮明
            row[this._dataSet.SlipList.CheckBoxCalcStatusColumn.ColumnName] = this._calcCheckStatus;
            row[this._dataSet.SlipList.CheckBoxCalcStatusExColumn.ColumnName] = this._calcCheckStatus;


            // 行番号
            row[this._dataSet.SlipList.RowNoColumn.ColumnName] = slipRowNo;

            // 仕入日
            if (this._supplierCheckResult.StockDate != DateTime.MinValue)
            {
                row[this._dataSet.SlipList.StockDateColumn.ColumnName] = this._supplierCheckResult.StockDate;
                row[this._dataSet.SlipList.StockDateStringColumn.ColumnName] = this._supplierCheckResult.StockDate.ToString("yyyy/MM/dd");
            }

            // 入力日
            if (this._supplierCheckResult.InputDay != DateTime.MinValue)
            {
                row[this._dataSet.SlipList.InputDayColumn.ColumnName] = this._supplierCheckResult.InputDay;
                row[this._dataSet.SlipList.InputDayStringColumn.ColumnName] = this._supplierCheckResult.InputDay.ToString("yyyy/MM/dd");
            }

            // 仕入SEQ番号 (Not Null)
            row[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName] = this._supplierCheckResult.SupplierSlipNo;
            //row[this._dataSet.SlipList.SupplierSlipNoColumn.ColumnName] = supplierSlipNo;

            // 伝票番号
            if (!String.IsNullOrEmpty(this._supplierCheckResult.PartySaleSlipNum))
            {
                // --- CHG 2009/03/24 障害ID:12789対応------------------------------------------------------>>>>>
                //row[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName] = this._supplierCheckResult.PartySaleSlipNum.PadLeft(8, '0'); // 2008.12.10 modify [8996]
                row[this._dataSet.SlipList.PartySaleSlipNumColumn.ColumnName] = this._supplierCheckResult.PartySaleSlipNum;
                // --- CHG 2009/03/24 障害ID:12789対応------------------------------------------------------<<<<<
            }

            // 税込金額(明細累計額)マイナスの値もあり
            //if (this._totalStockPriceTaxInc > 0)
            //{
            // --- UPD 2010/10/21 ---------->>>>>
            //row[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName] = this._totalStockPriceTaxInc;
            row[this._dataSet.SlipList.StockPriceTaxIncColumn.ColumnName] = this._totalStockPriceTaxExc + this._totalStockPriceConsTax;
            // --- UPD 2010/10/21 ----------<<<<<
            //}

            // 金額(明細累計額)マイナスの値もあり
            //if (this._totalStockPriceTaxExc > 0)
            //{
            row[this._dataSet.SlipList.StockPriceTaxExcColumn.ColumnName] = this._totalStockPriceTaxExc;
            //}

            // 消費税(明細累計額)マイナスの値もあり
            //if (this._totalStockPriceConsTax > 0)
            //{
            row[this._dataSet.SlipList.StockPriceConsTaxColumn.ColumnName] = this._totalStockPriceConsTax;
            //}

            // 売上日
            if (this._supplierCheckResult.SalesDate != DateTime.MinValue)
            {
                row[this._dataSet.SlipList.SalesDateColumn.ColumnName] = this._supplierCheckResult.SalesDate;
                row[this._dataSet.SlipList.SalesDateStringColumn.ColumnName] = this._supplierCheckResult.SalesDate.ToString("yyyy/MM/dd");
            }
            else
            {
                row[this._dataSet.SlipList.SalesDateStringColumn.ColumnName] = string.Empty;
            }

            // 売上伝票番号 (Not Null)
            row[this._dataSet.SlipList.SalesSlipNumColumn.ColumnName] = this._supplierCheckResult.SalesSlipNum;
            
            // 得意先コード
            if (this._supplierCheckResult.CustomerCode > 0)
            {
                row[this._dataSet.SlipList.CustomerCodeColumn.ColumnName] = this._supplierCheckResult.CustomerCode.ToString().PadLeft(8, '0');
            }

            // 得意先略称
            if (!String.IsNullOrEmpty(this._supplierCheckResult.CustomerSnm))
            {
                row[this._dataSet.SlipList.CustomerSnmColumn.ColumnName] = this._supplierCheckResult.CustomerSnm;
            }

            // 売上金額(マイナスの値もあり
            //if (this._supplierCheckResult.SalesMoneyTaxExc > 0)
            //{
                row[this._dataSet.SlipList.SalesMoneyTaxExcColumn.ColumnName] = this._supplierCheckResult.SalesMoneyTaxExc;
            //}

            // 売上担当者名
            if (!String.IsNullOrEmpty(this._supplierCheckResult.SalesEmployeeNm))
            {
                row[this._dataSet.SlipList.SalesEmployeeNmColumn.ColumnName] = this._supplierCheckResult.SalesEmployeeNm;
            }

            // 売上受注者名
            if (!String.IsNullOrEmpty(this._supplierCheckResult.FrontEmployeeNm))
            {
                row[this._dataSet.SlipList.FrontEmployeeNmColumn.ColumnName] = this._supplierCheckResult.FrontEmployeeNm;
            }

            // 売上発行者名
            if (!String.IsNullOrEmpty(this._supplierCheckResult.SalesInputName))
            {
                row[this._dataSet.SlipList.SalesInputNameColumn.ColumnName] = this._supplierCheckResult.SalesInputName;
            }

            // リマーク1
            if (!String.IsNullOrEmpty(this._supplierCheckResult.UoeRemark1))
            {
                row[this._dataSet.SlipList.UoeRemark1Column.ColumnName] = this._supplierCheckResult.UoeRemark1;
            }

            // リマーク2
            if (!String.IsNullOrEmpty(this._supplierCheckResult.UoeRemark2))
            {
                row[this._dataSet.SlipList.UoeRemark2Column.ColumnName] = this._supplierCheckResult.UoeRemark2;
            }

            // 仕入先コード
            if (this._supplierCheckResult.SupplierCd > 0)
            {
                row[this._dataSet.SlipList.SupplierCdColumn.ColumnName] = this._supplierCheckResult.SupplierCd.ToString().PadLeft(6, '0');
            }

            // 仕入先略称
            if (!String.IsNullOrEmpty(this._supplierCheckResult.SupplierSnm))
            {
                row[this._dataSet.SlipList.SupplierSnmColumn.ColumnName] = this._supplierCheckResult.SupplierSnm;
            }

            // 以下は背景色変更のために必要
            row[this._dataSet.DetailList.SupplierSlipCdColumn.ColumnName] = this._supplierCheckResult.SupplierSlipCd;          // 仕入形式
            row[this._dataSet.SlipList.WayToOrderColumn.ColumnName] = this._supplierCheckResult.WayToOrder; //ADD BY 凌小青 on 2012/08/30 for Redmine#31879
            row[this._dataSet.SlipList.DebitNoteDivColumn.ColumnName] = this._supplierCheckResult.DebitNoteDiv; //ADD BY 朱 猛 on 2012/10/09 for Redmine#31879

            this._dataSet.SlipList.Rows.Add(row);
        }

        #endregion // 伝票テーブル行作成

        #region 明細テーブル行作成

        /// <summary>
        /// リモート検索条件ワーククラスを元に明細テーブルに行を作成
        /// </summary>
        /// <param name="resultWork">検索結果ワーク</param>
        /// <param name="supplierCheckOrderCndtn">検索条件</param>
        /// <param name="detailRowNo">行番号</param>
        /// <param name="firstDetailRow">最初の明細行（詳細を表示する）かどうか</param>
        private void AddDetailRowData(SupplierCheckResultWork resultWork, SupplierCheckOrderCndtn supplierCheckOrderCndtn, int detailRowNo, bool firstDetailRow)
        {
            // 計算用
            Double salesMoney = 0;
            Double stockCount = 0;
            Double profit = 0;
            Double profitRate = 0;

            // 対象は[DetailList]テーブル
            DataRow row = this._dataSet.DetailList.NewRow();


            // 更新用

            // 作成日
            if (resultWork.CreateDateTime != DateTime.MinValue)
            {
                row[this._dataSet.DetailList.CreateDateTimeColumn.ColumnName] = resultWork.CreateDateTime;
            }

            // 更新日
            if (resultWork.UpdateDateTime != DateTime.MinValue)
            {
                row[this._dataSet.DetailList.UpdateDateTimeColumn.ColumnName] = resultWork.UpdateDateTime;
            }

            // 企業コード
            if (!String.IsNullOrEmpty(resultWork.EnterpriseCode))
            {
                row[this._dataSet.DetailList.EnterpriseCodeColumn.ColumnName] = resultWork.EnterpriseCode;
            }

            // GUID
            if (resultWork.FileHeaderGuid != Guid.Empty)
            {
                row[this._dataSet.DetailList.FileHeaderGuidColumn.ColumnName] = resultWork.FileHeaderGuid;
            }



            // 仕入チェック（日次）
            if (resultWork.StockCheckDivDaily == 0) // 未チェック
            {
                row[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName] = false;
                row[this._dataSet.DetailList.CheckBoxDailyExColumn.ColumnName] = false;
            }
            else
            {
                row[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName] = true;
                row[this._dataSet.DetailList.CheckBoxDailyExColumn.ColumnName] = true;
            }

            // 仕入チェック（締次）
            if (resultWork.StockCheckDivCAddUp == 0) // 未チェック
            {
                row[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName] = false;
                row[this._dataSet.DetailList.CheckBoxCalcExColumn.ColumnName] = false;
            }
            else
            {
                row[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName] = true;
                row[this._dataSet.DetailList.CheckBoxCalcExColumn.ColumnName] = true;
            }

            // 行番号
            row[this._dataSet.DetailList.RowNoColumn.ColumnName] = detailRowNo;

            // ----以下から伝票番号までは、最初の明細行以外は非表示

            // 仕入日
            if (firstDetailRow && resultWork.StockDate != DateTime.MinValue)
            {
                row[this._dataSet.DetailList.StockDateColumn.ColumnName] = resultWork.StockDate;
                row[this._dataSet.DetailList.StockDateStringColumn.ColumnName] = resultWork.StockDate.ToString("yyyy/MM/dd");
            }

            // 入力日
            if (firstDetailRow && resultWork.InputDay != DateTime.MinValue)
            {
                row[this._dataSet.DetailList.InputDayColumn.ColumnName] = resultWork.InputDay;
                row[this._dataSet.DetailList.InputDayStringColumn.ColumnName] = resultWork.InputDay.ToString("yyyy/MM/dd");
            }

            // 仕入SEQ番号 (Not Null)
            if (firstDetailRow) // 表示用列には最初の行のみ
            {
                // --- CHG 2009/03/24 障害ID:12789対応------------------------------------------------------>>>>>
                row[this._dataSet.DetailList.SupplierSlipNoColumn.ColumnName] = resultWork.SupplierSlipNo;
                // --- CHG 2009/03/24 障害ID:12789対応------------------------------------------------------<<<<<
            }

            // 仕入SEQ番号(検索用) (Not Null)
            row[this._dataSet.DetailList.SupplierSlipNoKeyColumn.ColumnName] = resultWork.SupplierSlipNo;

            // 伝票番号
            if (firstDetailRow && !String.IsNullOrEmpty(resultWork.PartySaleSlipNum))
            {
                // --- CHG 2009/03/24 障害ID:12789対応------------------------------------------------------>>>>>
                //row[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName] = resultWork.PartySaleSlipNum.PadLeft(8, '0'); // 2008.12.10 modify [8996]
                row[this._dataSet.DetailList.PartySaleSlipNumColumn.ColumnName] = resultWork.PartySaleSlipNum;
                // --- CHG 2009/03/24 障害ID:12789対応------------------------------------------------------<<<<<
            }

            // ----ここまで、最初の明細行以外は非表示

            // 税込金額(明細累計額)
            //if (resultWork.StockPriceTaxInc > 0)
            //{
                row[this._dataSet.DetailList.StockPriceTaxIncColumn.ColumnName] = resultWork.StockPriceTaxInc;
            //}

            //// 金額(明細累計額)
            //if (resultWork.StockPriceTaxExc > 0)
            //{
                row[this._dataSet.DetailList.StockPriceTaxExcColumn.ColumnName] = resultWork.StockPriceTaxExc;
            //}

            //// 消費税(明細累計額)
            //if (resultWork.StockPriceConsTax > 0)
            //{
                row[this._dataSet.DetailList.StockPriceConsTaxColumn.ColumnName] = resultWork.StockPriceConsTax;
            //}

            // 品番
            if (!String.IsNullOrEmpty(resultWork.GoodsNo))
            {
                row[this._dataSet.DetailList.GoodsNoColumn.ColumnName] = resultWork.GoodsNo;
            }

            // 数量
            //if (resultWork.StockCount > 0)
            //{
                row[this._dataSet.DetailList.StockCountColumn.ColumnName] = resultWork.StockCount;
                stockCount = Double.Parse(resultWork.StockCount.ToString());
            //}

            // BLｺｰﾄﾞ
            if (resultWork.BLGoodsCode > 0)
            {
                row[this._dataSet.DetailList.BLGoodsCodeColumn.ColumnName] = resultWork.BLGoodsCode;
            }

            // 品名
            if (!String.IsNullOrEmpty(resultWork.GoodsName))
            {
                row[this._dataSet.DetailList.GoodsNameColumn.ColumnName] = resultWork.GoodsName;
            }

            // 原価単価
            if (resultWork.StockUnitPriceFl > 0)
            {
                row[this._dataSet.DetailList.StockUnitPriceFlColumn.ColumnName] = resultWork.StockUnitPriceFl;
            }

            // 標準価格
            if (resultWork.ListPriceTaxExcFl > 0)
            {
                row[this._dataSet.DetailList.ListPriceTaxExcFlColumn.ColumnName] = resultWork.ListPriceTaxExcFl;
            }

            //// 売価単価
            //if (resultWork.SalesUnPrcTaxExcFl > 0)
            //{
                row[this._dataSet.DetailList.SalesUnPrcTaxExcFlColumn.ColumnName] = resultWork.SalesUnPrcTaxExcFl;
            //}

            // 売上金額
            //if (resultWork.SalesMoneyTaxExc > 0)
            //{
                row[this._dataSet.DetailList.SalesMoneyTaxExcColumn.ColumnName] = resultWork.SalesMoneyTaxExc;
                salesMoney = Double.Parse(resultWork.SalesMoneyTaxExc.ToString());
            //}

            //// 粗利
            //if (stockCount + salesMoney + resultWork.StockUnitPriceFl > 0)
            //{
                profit = salesMoney - (stockCount * resultWork.StockUnitPriceFl);
                row[this._dataSet.DetailList.ProfitColumn.ColumnName] = profit;
            //}

            // 粗利率
            if (profit != 0  && salesMoney != 0)
            {
                profitRate = profit / salesMoney * 100;
                row[this._dataSet.DetailList.ProfitRateColumn.ColumnName] = profitRate;

                // 粗利マークを計算
                row[this._dataSet.DetailList.ProfitMarkColumn.ColumnName] = this.GetProfitMark(profitRate);
            }

            // ***以下は更新に必要な値 (全てNot Null)
            if (resultWork.SalesDate != DateTime.MinValue)
            {
                row[this._dataSet.DetailList.SalesDateColumn.ColumnName] = resultWork.SalesDate;    // 売上日
                row[this._dataSet.DetailList.SalesDateStringColumn.ColumnName] = resultWork.SalesDate.ToString("yyyy/MM/dd");    // 売上日
            }
            else
            {
                row[this._dataSet.DetailList.SalesDateStringColumn.ColumnName] = string.Empty;
            }
            row[this._dataSet.DetailList.LogicalDeleteCodeColumn.ColumnName] = resultWork.LogicalDeleteCode;    // 削除区分
            row[this._dataSet.DetailList.SupplierSlipCdColumn.ColumnName] = resultWork.SupplierSlipCd;          // 伝票区分
            row[this._dataSet.DetailList.SupplierFormalColumn.ColumnName] = resultWork.SupplierFormal;          // 仕入形式
            row[this._dataSet.DetailList.StockSlipDtlNumColumn.ColumnName] = resultWork.StockSlipDtlNum;        // 仕入明細通番
            row[this._dataSet.DetailList.WayToOrderColumn.ColumnName] = resultWork.WayToOrder; //ADD BY 凌小青 on 2012/08/30 for Redmine#31879
            row[this._dataSet.DetailList.DebitNoteDivColumn.ColumnName] = resultWork.DebitNoteDiv; //ADD BY 朱 猛 on 2012/10/09 for Redmine#31879

            this._dataSet.DetailList.Rows.Add(row);
        }

        #endregion // 明細テーブル行作成

        #region 合計テーブル行作成

        /// <summary>
        /// 合計テーブル行作成
        /// </summary>
        private void AddTotalRowData()
        {
            DataRow totalRow = this._dataSet.TotalList.NewRow();

            totalRow[this._dataSet.TotalList.AmountColumn.ColumnName] = this._tAmount;
            totalRow[this._dataSet.TotalList.AmountConsumeTaxColumn.ColumnName] = this._tAmountConsumeTax;
            totalRow[this._dataSet.TotalList.AmountTaxIncColumn.ColumnName] = this._tAmountTaxInc;
            totalRow[this._dataSet.TotalList.AmountTaxIncAllColumn.ColumnName] = this._tAmountTaxIncAll;
            totalRow[this._dataSet.TotalList.ReturnColumn.ColumnName] = this._tReturn;
            totalRow[this._dataSet.TotalList.ReturnConsumeTaxColumn.ColumnName] = this._tReturnConsumeTax;
            totalRow[this._dataSet.TotalList.ReturnTaxIncColumn.ColumnName] = this._tReturnTaxInc;
            totalRow[this._dataSet.TotalList.SlipCountColumn.ColumnName] = this._tSlipCount;
            totalRow[this._dataSet.TotalList.DetailCountColumn.ColumnName] = this._tDetailCount;

            this._dataSet.TotalList.Rows.Add(totalRow);
        }

        #endregion // 合計テーブル行作成

        #region 画面用合計テーブル行作成

        private void AddSumRowData(int procDiv)
        {
            DataRow sumRow = this._dataSet.Sum.NewRow();

            sumRow[this._dataSet.Sum.DisplaySumColumn.ColumnName] = this._tAmountTaxIncAll;
            if (procDiv == 0)
            {
                sumRow[this._dataSet.Sum.CheckSumColumn.ColumnName] = this._dCheckSum_Daily;
                sumRow[this._dataSet.Sum.LackSumColumn.ColumnName] = this._tAmountTaxIncAll - this._dCheckSum_Daily;
            }
            else
            {
                sumRow[this._dataSet.Sum.CheckSumColumn.ColumnName] = _dCheckSum_Calc;
                sumRow[this._dataSet.Sum.LackSumColumn.ColumnName] = this._tAmountTaxIncAll - this._dCheckSum_Calc;
            }

            this._dataSet.Sum.Rows.Add(sumRow);
        }

        #endregion // 画面用合計テーブル行作成

        #region 粗利マーク計算

        /// <summary>
        /// 粗利マーク計算
        /// </summary>
        /// <param name="profileRate">粗利率(%)</param>
        /// <returns>粗利マーク</returns>
        private string GetProfitMark(Double profileRate)
        {
            // 粗利マークは全てしきい値未満
            if (profileRate < this._grsProfitCheckLower)
            {
                return this._grsProfitChkLowSign;
            }
            else if (this._grsProfitCheckLower <= profileRate && profileRate < this._grsProfitCheckBest)
            {
                return this._grsProfitChkBestSign;
            }
            else if (this._grsProfitCheckBest <= profileRate && profileRate < this._grsProfitCheckUpper)
            {
                return this._grsProfitChkUprSign;
            }
            else if (this._grsProfitCheckUpper <= profileRate)
            {
                return this._grsProfitChkMaxSign;
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion // 粗利マーク計算

        #endregion // データセット行作成

        #region データセットから更新データ作成

        /// <summary>
        /// データセットから更新データ作成
        /// </summary>
        /// <param name="checkTargetColumn">更新対象列(0:日次/1:締次)</param>
        /// <param name="count">更新件数を返す</param>
        /// <returns>更新用のデータ</returns>
        private object GetAllUpdateData(int checkTargetColumn, out int count)
        {
            // ワク作成
            StockCheckDtlWork updateData = null;
            ArrayList arrayList = new ArrayList();
            count = 0;

            switch (checkTargetColumn)
            {
                #region 日次
                case 0:
                    {
                        // 明細データの全ての行を検証し、更新データを作成
                        foreach (DataRow row in this._dataSet.DetailList.Rows)
                        {
                            // チェックボックスの初期値が現在値と変わっていた場合は更新対象
                            if ((bool)row[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName] != (bool)row[this._dataSet.DetailList.CheckBoxDailyExColumn.ColumnName])
                            {
                                updateData = new StockCheckDtlWork();

                                updateData.CreateDateTime = (DateTime)row[this._dataSet.DetailList.CreateDateTimeColumn.ColumnName];
                                if (DBNull.Value.Equals(row[this._dataSet.DetailList.UpdateDateTimeColumn.ColumnName]))
                                {
                                    updateData.UpdateDateTime = DateTime.MinValue;
                                }
                                else
                                {
                                    updateData.UpdateDateTime = (DateTime)row[this._dataSet.DetailList.UpdateDateTimeColumn.ColumnName];
                                }
                                updateData.FileHeaderGuid = (Guid)row[this._dataSet.DetailList.FileHeaderGuidColumn.ColumnName];
                                updateData.EnterpriseCode = (string)row[this._dataSet.DetailList.EnterpriseCodeColumn.ColumnName];

                                updateData.LogicalDeleteCode = (Int32)row[this._dataSet.DetailList.LogicalDeleteCodeColumn.ColumnName];
                                updateData.SupplierFormal = (Int32)row[this._dataSet.DetailList.SupplierFormalColumn.ColumnName];
                                updateData.StockSlipDtlNum = (Int64)row[this._dataSet.DetailList.StockSlipDtlNumColumn.ColumnName];

                                // 仕入チェック区分(日次)は現在の値を渡す
                                if ((bool)row[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName])
                                {
                                    updateData.StockCheckDivDaily = 1;
                                }
                                else
                                {
                                    updateData.StockCheckDivDaily = 0;
                                }

                                // 仕入チェック区分(締次)は取得時の値を渡す
                                if ((bool)row[this._dataSet.DetailList.CheckBoxCalcExColumn.ColumnName])
                                {
                                    updateData.StockCheckDivCAddUp = 1;
                                }
                                else
                                {
                                    updateData.StockCheckDivCAddUp = 0;
                                }

                                count++;
                                arrayList.Add((object)updateData);
                            }
                        }
                        break;
                    }
                #endregion // 日次

                #region 締次
                case 1:
                    {
                        // 明細データの全ての行を検証し、更新データを作成
                        foreach (DataRow row in this._dataSet.DetailList.Rows)
                        {
                            // チェックボックスの初期値が現在値と変わっていた場合は更新対象
                            if ((bool)row[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName] != (bool)row[this._dataSet.DetailList.CheckBoxCalcExColumn.ColumnName])
                            {
                                updateData = new StockCheckDtlWork();

                                updateData.CreateDateTime = (DateTime)row[this._dataSet.DetailList.CreateDateTimeColumn.ColumnName];
                                if (DBNull.Value.Equals(row[this._dataSet.DetailList.UpdateDateTimeColumn.ColumnName]))
                                {
                                    updateData.UpdateDateTime = DateTime.MinValue;
                                }
                                else
                                {
                                    updateData.UpdateDateTime = (DateTime)row[this._dataSet.DetailList.UpdateDateTimeColumn.ColumnName];
                                }
                                updateData.FileHeaderGuid = (Guid)row[this._dataSet.DetailList.FileHeaderGuidColumn.ColumnName];
                                updateData.EnterpriseCode = (string)row[this._dataSet.DetailList.EnterpriseCodeColumn.ColumnName];

                                updateData.LogicalDeleteCode = (Int32)row[this._dataSet.DetailList.LogicalDeleteCodeColumn.ColumnName];
                                updateData.SupplierFormal = (Int32)row[this._dataSet.DetailList.SupplierFormalColumn.ColumnName];
                                updateData.StockSlipDtlNum = (Int64)row[this._dataSet.DetailList.StockSlipDtlNumColumn.ColumnName];

                                // 仕入チェック区分(締次)は現在の値を渡す
                                if ((bool)row[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName])
                                {
                                    updateData.StockCheckDivCAddUp = 1;
                                }
                                else
                                {
                                    updateData.StockCheckDivCAddUp = 0;
                                }

                                // 仕入チェック区分(日次)は取得時の値を渡す
                                if ((bool)row[this._dataSet.DetailList.CheckBoxDailyExColumn.ColumnName])
                                {
                                    updateData.StockCheckDivDaily = 1;
                                }
                                else
                                {
                                    updateData.StockCheckDivDaily = 0;
                                }
                                updateData.EnterpriseCode = this.EnterpriseCode;

                                count++;
                                arrayList.Add((object)updateData);
                            }
                        }
                        break;
                    }
                #endregion // 締次
            }

            // 配列をオブジェクトで戻す
            return (object)arrayList;
        }

        #endregion // データセットから更新データ作成

        #region 更新処理

        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="checkTargetColumn">更新対象列(0:日次/1:締次)</param>
        /// <param name="count">更新列数</param>
        /// <returns></returns>
        public int Update(int checkTargetColumn, out int count)
        {
            // 更新日付を取得（一括更新で更新日付を合わせるため）
            this._updateDateTime = DateTime.Now;

            // データセットから更新すべきデータを作成
            object parameter = GetAllUpdateData(checkTargetColumn, out count);

            // 更新実行
            int status = this._supplierCheckOrderWorkDB.Write(ref parameter);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 正常時に、チェックボックスの値をExカラムにコピーする
                //foreach (DataRow row in this._dataSet.DetailList.Rows)
                //{
                //    row[this._dataSet.DetailList.CheckBoxCalcExColumn.ColumnName] = row[this._dataSet.DetailList.CheckBoxCalcColumn.ColumnName];
                //    row[this._dataSet.DetailList.CheckBoxDailyExColumn.ColumnName] = row[this._dataSet.DetailList.CheckBoxDailyColumn.ColumnName];
                //}
            }

            // ステータスを直接戻す
            return status;
        }

        #endregion // 更新処理

        #region 検索条件クラス→リモート検索条件ワーククラス　データコピー

        /// <summary>
        /// 検索条件クラス→リモート検索条件ワーククラス　データコピー
        /// </summary>
        /// <param name="customInqOrderCndtn"></param>
        private void CopyParamater2RemoteParameterWork(SupplierCheckOrderCndtn supplierCheckOrderCndtn)
        {
            this._supplierCheckOrderCndtnWork.EnterpriseCode = supplierCheckOrderCndtn.EnterpriseCode;
            this._supplierCheckOrderCndtnWork.SectionCode = supplierCheckOrderCndtn.SectionCode;
            this._supplierCheckOrderCndtnWork.SupplierCd = supplierCheckOrderCndtn.SupplierCd;
            this._supplierCheckOrderCndtnWork.ProcDiv = supplierCheckOrderCndtn.ProcDiv;
            this._supplierCheckOrderCndtnWork.SlipDiv = supplierCheckOrderCndtn.SlipDiv;
            this._supplierCheckOrderCndtnWork.CheckDiv = supplierCheckOrderCndtn.CheckDiv;
            this._supplierCheckOrderCndtnWork.St_StockDate = supplierCheckOrderCndtn.St_StockDate;
            this._supplierCheckOrderCndtnWork.Ed_StockDate = supplierCheckOrderCndtn.Ed_StockDate;
            this._supplierCheckOrderCndtnWork.St_InputDay = supplierCheckOrderCndtn.St_InputDay;
            this._supplierCheckOrderCndtnWork.Ed_InputDay = supplierCheckOrderCndtn.Ed_InputDay;
            this._supplierCheckOrderCndtnWork.St_SupplierSlipNo = supplierCheckOrderCndtn.St_SupplierSlipNo;
            this._supplierCheckOrderCndtnWork.Ed_SupplierSlipNo = supplierCheckOrderCndtn.Ed_SupplierSlipNo;
            this._supplierCheckOrderCndtnWork.St_PartySaleSlipNum = supplierCheckOrderCndtn.St_PartySaleSlipNum;
            this._supplierCheckOrderCndtnWork.Ed_PartySaleSlipNum = supplierCheckOrderCndtn.Ed_PartySaleSlipNum;

        }

        #endregion // 検索条件クラス→リモート検索条件ワーククラス　データコピー

        #region 検索結果ワーククラス→検索結果クラス　データコピー

        /// <summary>
        /// 検索結果ワーククラス→検索結果クラス　データコピー
        /// </summary>
        /// <param name="supplierCheckResultWork"></param>
        private void CopyResultwork2Result(SupplierCheckResultWork supplierCheckResultWork)
        {
            if (this._supplierCheckResult == null) return;

            this._supplierCheckResult.BfStockUnitPriceFl = supplierCheckResultWork.BfStockUnitPriceFl;
            this._supplierCheckResult.BLGoodsCode = supplierCheckResultWork.BLGoodsCode;
            this._supplierCheckResult.CreateDateTime = supplierCheckResultWork.CreateDateTime;
            this._supplierCheckResult.CustomerCode = supplierCheckResultWork.CustomerCode;
            this._supplierCheckResult.CustomerSnm = supplierCheckResultWork.CustomerSnm;
            this._supplierCheckResult.EnterpriseCode = supplierCheckResultWork.EnterpriseCode;
            this._supplierCheckResult.FileHeaderGuid = supplierCheckResultWork.FileHeaderGuid;
            this._supplierCheckResult.FrontEmployeeNm = supplierCheckResultWork.FrontEmployeeNm;
            this._supplierCheckResult.GoodsName = supplierCheckResultWork.GoodsName;
            this._supplierCheckResult.GoodsNo = supplierCheckResultWork.GoodsNo;
            this._supplierCheckResult.InputDay = supplierCheckResultWork.InputDay;
            this._supplierCheckResult.ListPriceTaxExcFl = supplierCheckResultWork.ListPriceTaxExcFl;
            this._supplierCheckResult.LogicalDeleteCode = supplierCheckResultWork.LogicalDeleteCode;
            this._supplierCheckResult.PartySaleSlipNum = supplierCheckResultWork.PartySaleSlipNum;
            this._supplierCheckResult.SalesDate = supplierCheckResultWork.SalesDate;
            this._supplierCheckResult.SalesEmployeeNm = supplierCheckResultWork.SalesEmployeeNm;
            this._supplierCheckResult.SalesInputName = supplierCheckResultWork.SalesInputName;
            this._supplierCheckResult.SalesMoneyTaxExc = supplierCheckResultWork.SalesMoneyTaxExc;
            this._supplierCheckResult.SalesSlipNum = supplierCheckResultWork.SalesSlipNum;
            this._supplierCheckResult.SalesUnPrcTaxExcFl = supplierCheckResultWork.SalesUnPrcTaxExcFl;
            this._supplierCheckResult.SectionCode = supplierCheckResultWork.SectionCode;
            this._supplierCheckResult.StockCheckDivCAddUp = supplierCheckResultWork.StockCheckDivCAddUp;
            this._supplierCheckResult.StockCheckDivDaily = supplierCheckResultWork.StockCheckDivDaily;
            this._supplierCheckResult.StockCount = supplierCheckResultWork.StockCount;
            this._supplierCheckResult.StockDate = supplierCheckResultWork.StockDate;
            this._supplierCheckResult.StockGoodsCd = supplierCheckResultWork.StockGoodsCd;
            this._supplierCheckResult.StockPriceConsTax = supplierCheckResultWork.StockPriceConsTax;
            this._supplierCheckResult.StockPriceTaxExc = supplierCheckResultWork.StockPriceTaxExc;
            this._supplierCheckResult.StockPriceTaxInc = supplierCheckResultWork.StockPriceTaxInc;
            this._supplierCheckResult.StockSlipDtlNum = supplierCheckResultWork.StockSlipDtlNum;
            this._supplierCheckResult.StockUnitPriceFl = supplierCheckResultWork.StockUnitPriceFl;
            this._supplierCheckResult.SupplierCd = supplierCheckResultWork.SupplierCd;
            this._supplierCheckResult.SupplierFormal = supplierCheckResultWork.SupplierFormal;
            this._supplierCheckResult.SupplierSlipCd = supplierCheckResultWork.SupplierSlipCd;
            this._supplierCheckResult.SupplierSlipNo = supplierCheckResultWork.SupplierSlipNo;
            this._supplierCheckResult.SupplierSnm = supplierCheckResultWork.SupplierSnm;
            this._supplierCheckResult.UoeRemark1 = supplierCheckResultWork.UoeRemark1;
            this._supplierCheckResult.UoeRemark2 = supplierCheckResultWork.UoeRemark2;
            this._supplierCheckResult.UpdAssemblyId1 = supplierCheckResultWork.UpdAssemblyId1;
            this._supplierCheckResult.UpdAssemblyId2 = supplierCheckResultWork.UpdAssemblyId2;
            this._supplierCheckResult.UpdateDateTime = supplierCheckResultWork.UpdateDateTime;
            this._supplierCheckResult.UpdEmployeeCode = supplierCheckResultWork.UpdEmployeeCode;
            this._supplierCheckResult.WayToOrder = supplierCheckResultWork.WayToOrder;  //ADD BY 凌小青 on 2012/08/30 for Redmine#31879
            this._supplierCheckResult.DebitNoteDiv = supplierCheckResultWork.DebitNoteDiv;  //ADD BY 朱 猛 on 2012/10/09 for Redmine#31879

        }
        #endregion // 検索結果ワーククラス→検索結果クラス　データコピー
    }
}
