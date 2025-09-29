using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using System.Data;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{

    /// <summary>
    /// 掛率集計結果返却パラメータ
    /// </summary>
    public class RateAddingUpResultsPara
    {
        /// <summary>カウントフラグ[true:集計した各単価の掛率設定区分が20件以下,false:21件以上]</summary>
        public bool countFlg;
        /// <summary>結果データテーブル</summary>
        public DataTable resultsTbl;
    }

    /// <summary>
    /// 掛率優先設定自動登録　 アクセスクラス 
    /// </summary>
    /// <remarks>
    /// <br>Note        :  掛率マスタを単価掛率設定区分で集計するアクセスクラスです。</br>
    /// <br>Programmer	:  23003 enokida</br>
    /// <br>Date        :  2013.11.21</br>
    /// </remarks>
    public class PMKHN09932AA
    {
        #region --- Private Member ---
        /// <summary>掛率マスタリモートオブジェクト</summary>
        private IRateDB _iRateDB = null;

        /// <summary>拠点</summary>
        private SecInfoSetAcs _secInfoSetAcs = new SecInfoSetAcs();

        /// <summary>掛率マスタデータテーブル</summary>
        private static DataTable _rateTable;

        /// <summary>拠点情報リスト</summary>
        private static ArrayList _secInfoList;

        /// <summary>集計結果リスト</summary>
        private static Dictionary<string, RateAddingUpResultsPara> _addingUpTblList;

        #endregion

        #region --- Public Member ---
        /// <summary>掛率テーブル名</summary>
        public const string RATE_TABLE = "RateTable";

        /// <summary> 拠点コード </summary>
        public const string SECTIONCODE_TITLE = "SectionCode";
        /// <summary> 単価掛率設定区分 </summary>
        public const string UNITRATESETDIVCD_TITLE = "UnitRateSetDivCd";
        /// <summary> 単価種類 </summary>
        public const string UNITPRICEKIND_TITLE = "UnitPriceKind";
        /// <summary> 掛率設定区分 </summary>
        public const string RATESETTINGDIVIDE_TITLE = "RateSettingDivide";

        /// <summary> 商品メーカーコード </summary>
        public const string GOODSMAKERCD_TITLE = "GoodsMakerCd";
        /// <summary> 商品番号 </summary>
        public const string GOODSNO_TITLE = "GoodsNo";
        /// <summary> 商品掛率ランク </summary>
        public const string GOODSRATERANK_TITLE = "GoodsRateRank";
        /// <summary> 商品掛率グループコード </summary>
        public const string GOODSRATEGRPCODE_TITLE = "GoodsRateGrpCode";
        /// <summary> BLグループコード </summary>
        public const string BLGROUPCODE_TITLE = "BLGroupCode";
        /// <summary> BL商品コード </summary>
        public const string BLGOODSCODE_TITLE = "BLGoodsCode";
        /// <summary> 得意先コード </summary>
        public const string CUSTOMERCODE_TITLE = "CustomerCode";
        /// <summary> 得意先掛率グループコード </summary>
        public const string CUSTRATEGRPCODE_TITLE = "CustRateGrpCode";
        /// <summary> 仕入先コード </summary>
        public const string SUPPLIERCD_TITLE = "SupplierCd";
        /// <summary> ロット数 </summary>
        public const string LOTCOUNT_TITLE = "LotCount";

        /// <summary>集計結果テーブル名</summary>
        public const string ADDUP_TABLE = "AddingUpTable";
        /// <summary> 数 </summary>
        public const string COUNT_TITLE = "Count";
        #endregion

        #region --- コンストラクタ ---
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKHN09932AA()
        {
            try
            {
                // リモートオブジェクト取得
                this._iRateDB = (IRateDB)MediationRateDB.GetRateDB();

                // 集計作業用テーブルの作成 データテーブル列情報構築処理
                this.DataTableColumnConstruction();

                if (_addingUpTblList == null)
                    _addingUpTblList = new Dictionary<string, RateAddingUpResultsPara>();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iRateDB = null;
            }
        }
        #endregion

        #region --- Public Methods ---
        /// <summary>
        /// 掛率設定区分集計処理
        /// </summary>
        /// <param name="resultsTblList">集計結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード（全社指定の場合は空欄""）</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス[ConstantManagement.MethodResult]</returns>
        /// <remarks>
        /// <br>Note        :  指定された情報を元に掛率マスタの集計を行い結果を返します。</br>
        /// </remarks>
        public int RateSetDivCdAddingUp(out Dictionary<string, RateAddingUpResultsPara> resultsTblList, string enterpriseCode, string sectionCode, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            resultsTblList = new Dictionary<string, RateAddingUpResultsPara>();
            errMsg = string.Empty;

            DataTable resultsTbl = new DataTable(ADDUP_TABLE);
            List<string> sectionCodeList = new List<string>();
            try
            {
                if (sectionCode.Trim() == string.Empty)
                    status = this.RateSetDivCdAddingUpPro(out resultsTblList, enterpriseCode, out errMsg);
                else
                    status = this.RateSetDivCdAddingUpPro(out resultsTblList, enterpriseCode, sectionCode, out errMsg);
            }
            catch (Exception ex)
            {
                resultsTbl = null;
                this._iRateDB = null;
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// 詳細情報取得処理
        /// </summary>
        /// <param name="resultsTbl">詳細情報</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="unitPriceKind">単価種類</param>
        /// <param name="rateSettingDivide">掛率設定区分</param>
        /// <remarks>
        /// <br>Note        :  指定された情報を元に掛率マスタの情報を返します。</br>
        /// </remarks>
        public void GetDetailInfo(out DataTable resultsTbl, string sectionCode, string unitPriceKind, string rateSettingDivide)
        {
            resultsTbl = new DataTable(RATE_TABLE);

            if (_rateTable == null)
                return;

            DataView dtView = new DataView(_rateTable);
            dtView.RowFilter = SECTIONCODE_TITLE + " = '" + sectionCode + "' and " +
                UNITPRICEKIND_TITLE + " = '" + unitPriceKind + "' and " + RATESETTINGDIVIDE_TITLE + " = '" + rateSettingDivide + "'";

            resultsTbl = dtView.ToTable();
        }



        // TODO: いらないかな
        /// <summary>
        /// 集計結果データセット列情報構築処理
        /// </summary>
        /// <param name="resultsTbl"></param>
        /// <remarks>
        /// <br>Note        : 集計結果用のデータセットの列情報を構築します。</br>
        /// </remarks>
        public void DataTableColumnConstruction(out DataTable resultsTbl)
        {
            resultsTbl = new DataTable(ADDUP_TABLE);

            // Addを行う順番が、列の表示順位となります。
            resultsTbl.Columns.Add(SECTIONCODE_TITLE, typeof(string)); // 拠点コード
            resultsTbl.Columns.Add(UNITRATESETDIVCD_TITLE, typeof(string)); // 単価掛率設定区分
            resultsTbl.Columns.Add(UNITPRICEKIND_TITLE, typeof(string)); // 単価種類
            resultsTbl.Columns.Add(RATESETTINGDIVIDE_TITLE, typeof(string)); // 掛率設定区分
            resultsTbl.Columns.Add(COUNT_TITLE, typeof(Int64)); // 登録数
        }

        // TODO: いらないかな
        /// <summary>
        /// 詳細データセット列情報構築処理
        /// </summary>
        /// <param name="resultsTbl"></param>
        /// <remarks>
        /// <br>Note        : 詳細表示用のデータセットの列情報を構築します。</br>
        /// </remarks>
        public void DataTableDtlColumnConstruction(out DataTable resultsTbl)
        {
            resultsTbl = new DataTable(RATE_TABLE);
            // Addを行う順番が、列の表示順位となります。
            resultsTbl.Columns.Add(SECTIONCODE_TITLE, typeof(string)); // 拠点コード
            resultsTbl.Columns.Add(UNITRATESETDIVCD_TITLE, typeof(string)); // 単価掛率設定区分
            resultsTbl.Columns.Add(UNITPRICEKIND_TITLE, typeof(string)); // 単価種類
            resultsTbl.Columns.Add(RATESETTINGDIVIDE_TITLE, typeof(string)); // 掛率設定区分

            resultsTbl.Columns.Add(GOODSMAKERCD_TITLE, typeof(Int32)); // 商品メーカーコード
            resultsTbl.Columns.Add(GOODSNO_TITLE, typeof(string)); // 商品番号
            resultsTbl.Columns.Add(GOODSRATERANK_TITLE, typeof(string)); // 商品掛率ランク
            resultsTbl.Columns.Add(GOODSRATEGRPCODE_TITLE, typeof(Int32)); // 商品掛率グループコード
            resultsTbl.Columns.Add(BLGROUPCODE_TITLE, typeof(Int32)); // BLグループコード
            resultsTbl.Columns.Add(BLGOODSCODE_TITLE, typeof(Int32)); // BL商品コード
            resultsTbl.Columns.Add(CUSTOMERCODE_TITLE, typeof(Int32)); // 得意先コード
            resultsTbl.Columns.Add(CUSTRATEGRPCODE_TITLE, typeof(Int32)); // 得意先掛率グループコード
            resultsTbl.Columns.Add(SUPPLIERCD_TITLE, typeof(Int32)); // 仕入先コード
        }
        #endregion

        #region --- Private Methods ---

        /// <summary>
        /// 掛率設定区分集計処理（全社）
        /// </summary>
        /// <param name="resultsTblList">集計結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス[ConstantManagement.MethodResult]</returns>
        /// <remarks>
        /// <br>Note        :  指定された企業の掛率マスタの集計を各拠点コード毎に行い結果を返します。</br>
        /// </remarks>
        private int RateSetDivCdAddingUpPro(out Dictionary<string, RateAddingUpResultsPara> resultsTblList, string enterpriseCode, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            resultsTblList = new Dictionary<string, RateAddingUpResultsPara>();
            errMsg = string.Empty;

            // 集計対象拠点コードリスト
            List<string> sectionCodeList = new List<string>();
            bool addingupFlg = false;

            // 既に掛率マスタからデータ取得済みか
            if (_secInfoList == null)
            {
                if (_secInfoSetAcs == null)
                    _secInfoSetAcs = new SecInfoSetAcs();
                // 拠点情報取得
                status = _secInfoSetAcs.SearchAll(out _secInfoList, enterpriseCode);

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    errMsg = "拠点情報の取得に失敗しました。";
                    return status;
                }

                // 拠点コードリストの作成
                sectionCodeList.Add("00");
                foreach (SecInfoSet wk in _secInfoList)
                    sectionCodeList.Add(wk.SectionCode.Trim());

                _rateTable.Clear();

                // 掛率マスタ読込み処理
                status = this.OrgRateDataTableCreate(enterpriseCode, "");

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    errMsg = "掛率マスタの取得に失敗しました。";
                    return status;
                }
            }
            else
            {
                // 拠点コードリストの作成
                sectionCodeList.Add("00");
                foreach (SecInfoSet wk in _secInfoList)
                    sectionCodeList.Add(wk.SectionCode.Trim());

                // 既に集計済みか
                if (_addingUpTblList != null)
                {
                    addingupFlg = true;
                    foreach (string key in sectionCodeList)
                    {
                        if (!_addingUpTblList.ContainsKey(key))
                        {
                            addingupFlg = false;
                            break;
                        }
                        resultsTblList.Add(key, _addingUpTblList[key]);
                    }
                }
            }

            // 集計処理＆返却データ作成
            if (!addingupFlg)
                this.RateSetDivCdAddingUpDataCreate(out resultsTblList, sectionCodeList, 1);

            _addingUpTblList = resultsTblList;
            return status;
        }


        /// <summary>
        /// 掛率設定区分集計処理（拠点）
        /// </summary>
        /// <param name="resultsTblList">集計結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス[ConstantManagement.MethodResult]</returns>
        /// <remarks>
        /// <br>Note        :  指定された拠点の掛率マスタの集計を行い結果を返します。</br>
        /// </remarks>
        private int RateSetDivCdAddingUpPro(out Dictionary<string, RateAddingUpResultsPara> resultsTblList, string enterpriseCode, string sectionCode, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            resultsTblList = new Dictionary<string, RateAddingUpResultsPara>();
            errMsg = string.Empty;

            bool retrievedFlg = true;

            // 掛率マスタに登録していない拠点の場合、1度集計していると取得済みデータ（_rateTable）には無いが、
            // 集計結果（_addingUpTblList）には特定区分のみ集計されている可能性がある為、「集計済みチェック」から行う

            // 既に集計済みか
            if (_addingUpTblList != null && _addingUpTblList.ContainsKey(sectionCode))
            {
                resultsTblList.Add(sectionCode, _addingUpTblList[sectionCode]);
                return status;
            }

            // 既に掛率マスタからデータ取得済みか
            DataRow[] findRows = null;
            if (_rateTable != null)
                findRows = _rateTable.Select(SECTIONCODE_TITLE + " = '" + sectionCode + "'");

            if (findRows == null || findRows.Length <= 0)
                retrievedFlg = false;

            // 掛率マスタ読込み処理
            if (!retrievedFlg)
                status = this.OrgRateDataTableCreate(enterpriseCode, sectionCode);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                errMsg = "掛率マスタの取得に失敗しました。";
                return status;
            }

            List<string> sectionCodeList = new List<string>();
            sectionCodeList.Add(sectionCode);

            // 集計処理＆返却データ作成
            this.RateSetDivCdAddingUpDataCreate(out resultsTblList, sectionCodeList, 2);
            _addingUpTblList.Add(sectionCode.Trim(), resultsTblList[sectionCode]);

            return status;

        }


        /// <summary>
        /// 掛率設定区分集計処理&返却データ作成 
        /// </summary>
        /// <param name="resultsTblList">結果リスト</param>
        /// <param name="sectionCodeList">拠点コードリスト</param>
        /// <param name="mode">モード[1:全社,2:拠点指定]</param>
        /// <remarks>
        /// <br>Note        :  掛率マスタの集計を行い、集計結果件数と合わせて結果を返します。</br>
        /// </remarks>
        private void RateSetDivCdAddingUpDataCreate(out Dictionary<string, RateAddingUpResultsPara> resultsTblList, List<string> sectionCodeList, int mode)
        {
            resultsTblList = new Dictionary<string, RateAddingUpResultsPara>();

            DataTable resultsTbl;
            string sectionCode = string.Empty;
            if (mode == 2)
                sectionCode = sectionCodeList[0];

            // ---------------- 掛率設定区分集計処理 ---------------- //
            // 掛率設定区分集計処理 
            this.RateSetDivCdAddingUp(out resultsTbl, sectionCode, mode);

            // 特定掛率設定区分（"2A","4A","6A"）セット処理
            this.RateSettingDivideSet(ref resultsTbl, sectionCodeList);

            // ----- 返却データ作成 ----- //
            DataView dtView = new DataView(resultsTbl);
            DataTable wkDt = new DataTable();
            RateAddingUpResultsPara para = new RateAddingUpResultsPara();

            // 集計した各単価の掛率設定区分が1つでも21件以上あればtrueをセット
            foreach (string wkSecCd in sectionCodeList)
            {
                para = new RateAddingUpResultsPara();
                dtView.RowFilter = SECTIONCODE_TITLE + " = '" + wkSecCd + "'";
                wkDt = dtView.ToTable();
                para.resultsTbl = wkDt;

                // 対象拠点のデータが無い場合はfalseを返す
                if (para.resultsTbl.Rows.Count == 0)
                    para.countFlg = false;
                else
                {
                    para.countFlg = true;

                    // 対象単価種類（売価または原価）のデータが21件以上又は0件の場合はfalseを返す
                    dtView.RowFilter = SECTIONCODE_TITLE + " = '" + wkSecCd + "' and " + UNITPRICEKIND_TITLE + " = '1'";
                    if (dtView.ToTable().Rows.Count > 20 || dtView.ToTable().Rows.Count == 0)
                        para.countFlg = false;
                    else
                    {
                        dtView.RowFilter = SECTIONCODE_TITLE + " = '" + wkSecCd + "' and " + UNITPRICEKIND_TITLE + " = '2'";
                        if (dtView.ToTable().Rows.Count > 20 || dtView.ToTable().Rows.Count == 0)
                            para.countFlg = false;
                    }
                }
                resultsTblList.Add(wkSecCd.Trim(), para);
            }
        }

        /// <summary>
        /// 集計元テーブル作成処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>ステータス[ConstantManagement.MethodResult]</returns>
        /// <remarks>
        /// <br>Note        :  掛率マスタを読込んで集計元となるデータテーブルを作成します。</br>
        /// </remarks>
        private int OrgRateDataTableCreate(string enterpriseCode, string sectionCode)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            RateWork paraWork = new RateWork(); // 抽出条件パラメータ
            object retList = null; // リモート戻りリスト

            paraWork.EnterpriseCode = enterpriseCode;   // 企業コード
            paraWork.SectionCode = sectionCode;         // 拠点コード
            paraWork.LotCount = 9999999.99;             // ロット数（-1:絞込み無し, -1以外:該当ロット数で絞り込み）数量範囲は複数登録してあっても1カウントとする為「9999999.99」で絞り込む

            // 掛率マスタ読込み処理
        status = _iRateDB.Search(out retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // データテーブルにセット
                foreach (RateWork rateWork in (ArrayList)retList)
                {
                    this.AddDataTableFromRateWork(rateWork);
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            
            return status;
        }

        /// <summary>
        /// 掛率設定区分集計処理
        /// </summary>
        /// <param name="resultsTbl">集計結果テーブル</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="mode">モード[1:全社,2:拠点指定]</param>
        /// <remarks>
        /// <br>Note        : 掛率マスタを単価掛率設定区分で集計します。</br>
        /// </remarks>
        private void RateSetDivCdAddingUp(out DataTable resultsTbl, string sectionCode, int mode)
        {
            // 列情報作成
            DataTableColumnConstruction(out resultsTbl);

            if (_rateTable.Rows.Count == 0)
                return;

            // プライマリキーの設定（拠点コード、単価掛率設定区分）
            resultsTbl.PrimaryKey =
                new DataColumn[] { resultsTbl.Columns[SECTIONCODE_TITLE], resultsTbl.Columns[UNITRATESETDIVCD_TITLE] };

            foreach (DataRow row in _rateTable.Rows)
            {
                if (mode == 2 && (string)row[SECTIONCODE_TITLE] != sectionCode)
                    continue;

                // 単価種類が売価、原価以外の場合は集計不要
                if ((string)row[UNITPRICEKIND_TITLE] != "1" && (string)row[UNITPRICEKIND_TITLE] != "2")
                    continue;

                object[] keys = new object[] { row[SECTIONCODE_TITLE], row[UNITRATESETDIVCD_TITLE] };
                DataRow trgDataRow = resultsTbl.Rows.Find(keys);

                if (trgDataRow == null)
                {
                    trgDataRow = resultsTbl.NewRow();
                    trgDataRow[SECTIONCODE_TITLE] = row[SECTIONCODE_TITLE]; // 拠点コード
                    trgDataRow[UNITRATESETDIVCD_TITLE] = row[UNITRATESETDIVCD_TITLE]; // 単価掛率設定区分
                    trgDataRow[UNITPRICEKIND_TITLE] = row[UNITPRICEKIND_TITLE]; // 単価種類
                    trgDataRow[RATESETTINGDIVIDE_TITLE] = row[RATESETTINGDIVIDE_TITLE]; // 掛率設定区分
                    resultsTbl.Rows.Add(trgDataRow);
                }
            }

            // カウント
            foreach (DataRow row in resultsTbl.Rows)
            {
                int count = (int)_rateTable.Compute("Count(" + UNITRATESETDIVCD_TITLE + ")", UNITRATESETDIVCD_TITLE + " = '" + row[UNITRATESETDIVCD_TITLE] + "' and " + SECTIONCODE_TITLE + " = '" + row[SECTIONCODE_TITLE] + "'");
                row[COUNT_TITLE] = count;
            }

        }


        /// <summary>
        /// 掛率設定区分追加処理
        /// </summary>
        /// <param name="resultsTbl">結果テーブル</param>
        /// <param name="sectionCodeList">拠点コードリスト</param>
        /// <remarks>
        /// <br>Note        : 集計結果に対し、特定の掛率設定区分を追加します。</br>
        /// </remarks>
        private void RateSettingDivideSet(ref DataTable resultsTbl, List<string> sectionCodeList)
        {
            // ----------- 固定データ追加 ----------- //
            // 特定の掛率設定区分（"2A","4A","6A"）がない場合はcount0で用意しておく
            Dictionary<string, string[]> wkDivList = new Dictionary<string, string[]>();
            wkDivList.Add("1", new string[] { "2A", "4A", "6A" });　// 1:売価設定
            wkDivList.Add("2", new string[] { "6A" }); // 2:原価設定

            DataRow dr;
            int count = 0;

            foreach (string sectionCode in sectionCodeList) // 拠点
            {
                foreach (string wkUnitPriceKind in wkDivList.Keys) // 単価種類
                {
                    // 指定の拠点、単価種類の掛率データが無い場合は追加しない
                    count = (int)resultsTbl.Compute("Count(" + RATESETTINGDIVIDE_TITLE + ")",
                        UNITPRICEKIND_TITLE + " = '" + wkUnitPriceKind + "' and " + SECTIONCODE_TITLE + " = '" + sectionCode + "'");
                    if (count == 0)
                        continue;

                    foreach (string wkRateSettingDivide in wkDivList[wkUnitPriceKind]) // 掛率設定区分
                    {
                        count = (int)resultsTbl.Compute("Count(" + RATESETTINGDIVIDE_TITLE + ")",
                            RATESETTINGDIVIDE_TITLE + " = '" + wkRateSettingDivide + "' and " + UNITPRICEKIND_TITLE + " = '" + wkUnitPriceKind + "' and " + SECTIONCODE_TITLE + " = '" + sectionCode + "'");

                        if (count == 0)
                        {
                            // 追加
                            dr = resultsTbl.NewRow();

                            dr[SECTIONCODE_TITLE] = sectionCode; // 拠点コード
                            dr[UNITRATESETDIVCD_TITLE] = wkUnitPriceKind + wkRateSettingDivide; // 単価掛率設定区分
                            dr[UNITPRICEKIND_TITLE] = wkUnitPriceKind; // 単価種類
                            dr[RATESETTINGDIVIDE_TITLE] = wkRateSettingDivide; // 掛率設定区分
                            dr[COUNT_TITLE] = 0;
                            resultsTbl.Rows.Add(dr);
                        }
                    }
                }
            }
        }


        #region データテーブル関連処理
        /// <summary>
        /// データテーブル列情報構築処理（掛率マスタ）
        /// </summary>
        /// <remarks>
        /// <br>Note        : 集計結果用のデータセットの列情報を構築します。</br>
        /// </remarks>
        private void DataTableColumnConstruction()
        {
            if (_rateTable == null)
            {
                _rateTable = new DataTable(RATE_TABLE);
                // Addを行う順番が、列の表示順位となります。
                _rateTable.Columns.Add(SECTIONCODE_TITLE, typeof(string)); // 拠点コード
                _rateTable.Columns.Add(UNITRATESETDIVCD_TITLE, typeof(string)); // 単価掛率設定区分
                _rateTable.Columns.Add(UNITPRICEKIND_TITLE, typeof(string)); // 単価種類
                _rateTable.Columns.Add(RATESETTINGDIVIDE_TITLE, typeof(string)); // 掛率設定区分

                _rateTable.Columns.Add(GOODSMAKERCD_TITLE, typeof(Int32)); // 商品メーカーコード
                _rateTable.Columns.Add(GOODSNO_TITLE, typeof(string)); // 商品番号
                _rateTable.Columns.Add(GOODSRATERANK_TITLE, typeof(string)); // 商品掛率ランク
                _rateTable.Columns.Add(GOODSRATEGRPCODE_TITLE, typeof(Int32)); // 商品掛率グループコード
                _rateTable.Columns.Add(BLGROUPCODE_TITLE, typeof(Int32)); // BLグループコード
                _rateTable.Columns.Add(BLGOODSCODE_TITLE, typeof(Int32)); // BL商品コード
                _rateTable.Columns.Add(CUSTOMERCODE_TITLE, typeof(Int32)); // 得意先コード
                _rateTable.Columns.Add(CUSTRATEGRPCODE_TITLE, typeof(Int32)); // 得意先掛率グループコード
                _rateTable.Columns.Add(SUPPLIERCD_TITLE, typeof(Int32)); // 仕入先コード
            }
        }

        /// <summary>
        /// データテーブルにセット（掛率マスタ）
        /// </summary>
        /// <param name="rateWork"></param>
        private void AddDataTableFromRateWork(RateWork rateWork)
        {
            DataRow dr = _rateTable.NewRow();

            dr[SECTIONCODE_TITLE] = rateWork.SectionCode.Trim(); // 拠点コード
            dr[UNITRATESETDIVCD_TITLE] = rateWork.UnitRateSetDivCd; // 単価掛率設定区分
            dr[UNITPRICEKIND_TITLE] = rateWork.UnitPriceKind; // 単価種類
            dr[RATESETTINGDIVIDE_TITLE] = rateWork.RateSettingDivide; // 掛率設定区分

            dr[GOODSMAKERCD_TITLE] = rateWork.GoodsMakerCd; // 商品メーカーコード
            dr[GOODSNO_TITLE] = rateWork.GoodsNo; // 商品番号
            dr[GOODSRATERANK_TITLE] = rateWork.GoodsRateRank; // 商品掛率ランク
            dr[GOODSRATEGRPCODE_TITLE] = rateWork.GoodsRateGrpCode; // 商品掛率グループコード
            dr[BLGROUPCODE_TITLE] = rateWork.BLGroupCode; // BLグループコード
            dr[BLGOODSCODE_TITLE] = rateWork.BLGoodsCode; // BL商品コード
            dr[CUSTOMERCODE_TITLE] = rateWork.CustomerCode; // 得意先コード
            dr[CUSTRATEGRPCODE_TITLE] = rateWork.CustRateGrpCode; // 得意先掛率グループコード
            dr[SUPPLIERCD_TITLE] = rateWork.SupplierCd; // 仕入先コード


            _rateTable.Rows.Add(dr);
        }


        #endregion

        #endregion

    }
}
