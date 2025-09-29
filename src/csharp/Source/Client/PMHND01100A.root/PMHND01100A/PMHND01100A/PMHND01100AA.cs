//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル在庫仕入（入庫更新）アクセスクラス
// プログラム概要   : ハンディターミナル在庫仕入（入庫更新）アクセスクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 作 成 日  2017/08/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11475093-00 作成担当 : 呉軍
// 作 成 日  2018/09/14  修正内容 : Redmine#49751 検品管理 在庫入庫更新PKG差異対応
//----------------------------------------------------------------------------//
// 管理番号  11570136-00 作成担当 : 岸
// 作 成 日  2019/11/13  修正内容 : ハンディ６次改良
//----------------------------------------------------------------------------//

using System;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ハンディターミナル在庫仕入（入庫更新）アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル在庫仕入（入庫更新）アクセスクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/08/11</br>
    /// <br>Update Note: Redmine#49751 検品管理 在庫入庫更新PKG差異対応</br>
    /// <br>Programmer : 呉軍</br>
    /// <br>Date       : 2018/09/14</br>
    /// </remarks>
    public class HandyStockSupplierAcs
    {
        #region [定数]
        // 情報取得が正常に終了したステータス
        private const int StatusNomal = 0;
        // ﾛｸﾞｲﾝIDが見つからないステータス
        private const int StatusNotFound = 4;
        // 読込時のタイムアウトステータス
        private const int StatusTimeout = 5;
        // DB処理等でエラーが発生したステータス
        private const int StatusError = -1;
        /// <summary>デフォルトエンコード</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>ログパス</summary>
        private const string LogPath = @"\Log\PMHND";
        /// <summary>デフォルトログファイル名称</summary>
        private const string PgId = "PMHND01100A_";
        /// <summary>デフォルトログファイル名称</summary>
        private const string File = ".log";
        /// <summary>デフォルトログファイル名称日期フォーマット</summary>
        private const string DefaultTime = "yyyyMMdd";
        /// <summary>デフォルトログ内容フォーマット</summary>
        private const string DefaultFormat = "{0,-19} {1,-5} {2,-200}";     // yyyy/MM/dd hh:mm:ss
        /// <summary>企業コード</summary>
        private const string EnterpriseCod = "企業コード:";
        /// <summary>従業員コード</summary>
        private const string EmployeeCode = "従業員コード:";
        /// <summary>コンピュータ名</summary>
        private const string MachineName = "コンピュータ名:";
        /// <summary>所属拠点コード</summary>
        private const string BelongSectionCode = "所属拠点コード:";
        
        /// <summary>商品メーカーコード</summary>
        private const string GoodsMakerCd = "商品メーカーコード:";
        /// <summary>商品番号</summary>
        private const string GoodsNo = "商品番号:";
        /// <summary>倉庫コード</summary>
        private const string WarehouseCode = "倉庫コード:";
        /// <summary>検品ステータス</summary>
        private const string InspectStatus = "検品ステータス:";
        /// <summary>検品区分</summary>
        private const string InspectCode = "検品区分:";
        /// <summary>検品数</summary>
        private const string InspectCnt = "検品数:";
        /// <summary>更新区分</summary>
        private const string UpdateDiv = "更新区分:";
        /// <summary>仕入明細通番</summary>
        private const string StockSlipDtlNum = "仕入明細通番:";
        /// <summary>処理区分</summary>
        private const string OpDiv = "処理区分:";
        /// <summary>発注先コード</summary>
        private const string UOESupplierCd = "発注先コード:";
        /// <summary>入庫区分</summary>
        private const string WarehousingDivCd = "入庫区分:";
        /// <summary>オンライン番号</summary>
        private const string OnlineNo = "オンライン番号:";
        /// <summary>UOE発注番号</summary>
        private const string UOESalesOrderNo = "UOE発注番号:";

        /// <summary>パラメータnullメッセージ</summary>
        private const string ConditionsError = "登録条件がnullです。";
        /// <summary>パラメータエラーメッセージ</summary>
        private const string ParametersError = "入力パラメータエラーが発生しました。";

        /// <summary>BO伝票番号1</summary>
        private const string EnterUpdDivBO1SlipNo = "ﾊﾞﾝｺﾞｳﾅｼ BO1";
        /// <summary>BO伝票番号2</summary>
        private const string EnterUpdDivBO2SlipNo = "ﾊﾞﾝｺﾞｳﾅｼ BO2";
        /// <summary>BO伝票番号3</summary>
        private const string EnterUpdDivBO3SlipNo = "ﾊﾞﾝｺﾞｳﾅｼ BO3";
        /// <summary>ﾒｰｶｰ</summary>
        private const string EnterUpdDivMakerSlipNo = "ﾊﾞﾝｺﾞｳﾅｼ ﾒｰｶｰ";
        /// <summary>EO</summary>
        private const string EnterUpdDivEOSlipNo = "ﾊﾞﾝｺﾞｳﾅｼ EO";
        /// <summary>UOE拠点伝票番号</summary>
        private const string EnterUpdDivSecSlipNo = "ﾊﾞﾝｺﾞｳﾅｼ ｷｮﾃﾝ";

        /// <summary>拠点</summary>
        private const int WarehousingSectionDiv = 1;
        /// <summary>BO1</summary>
        private const int WarehousingBo1Div = 2;
        /// <summary>BO2</summary>
        private const int WarehousingBo2Div = 3;
        /// <summary>BO3</summary>
        private const int WarehousingBo3Div = 4;
        /// <summary>メーカー</summary>
        private const int WarehousingMakerDiv = 5;
        /// <summary>EO</summary>
        private const int WarehousingEoDiv = 6;

        /// <summary>重複のBO伝票番号編集用-F</summary>
        private const string DuplicationSlipNoF = "-F";
        /// <summary>重複のBO伝票番号編集用-F2</summary>
        private const string DuplicationSlipNoF2 = "-F2";
        /// <summary>重複のBO伝票番号編集用-F3</summary>
        private const string DuplicationSlipNoF3 = "-F3";
        /// <summary>ディクショナリー用</summary>
        private const string Separator = "|";

        /// <summary>入庫更新区分（拠点）「0:未入庫」</summary>
        private const int EnterUpdDivSecData0 = 0;
        /// <summary>入庫更新区分（BO1）「0:未入庫」</summary>
        private const int EnterUpdDivBO1Data0 = 0;
        /// <summary>入庫更新区分（BO2）「0:未入庫」</summary>
        private const int EnterUpdDivBO2Data0 = 0;
        /// <summary>入庫更新区分（BO3）「0:未入庫」</summary>
        private const int EnterUpdDivBO3Data0 = 0;
        /// <summary>入庫更新区分（ﾒｰｶｰ）「0:未入庫」</summary>
        private const int EnterUpdDivMakerData0 = 0;
        /// <summary>入庫更新区分（EO）「0:未入庫」</summary>
        private const int EnterUpdDivEOData0 = 0;
        #endregion

        #region Static Members
        /// <summary>ログ用ロック</summary>
        static object LogLockObj = null;
        #endregion

        # region [コンストラクタ]
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public HandyStockSupplierAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [ハンディターミナル在庫仕入（入庫更新）_登録]
        /// <summary>
        /// ハンディターミナル在庫仕入（入庫更新）の登録処理
        /// </summary>
        /// <param name="inspectDataAddListObj">登録用パラメータオブジェクト</param>
        /// <returns>ステータス[0: 正常、 0以外: エラー]</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（入庫更新）を登録します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// <br>Update Note: Redmine#49751 検品管理 在庫入庫更新PKG差異対応</br>
        /// <br>Programmer : 呉軍</br>
        /// <br>Date       : 2018/09/14</br>
        /// <br>Update Note: ハンディ６次改良</br>
        /// <br>Programmer : 岸</br>
        /// <br>Date       : 2019/11/13</br>
        /// </remarks>
        public int WriteHandyStockSupplier(ref object inspectDataAddListObj)
        {
            // --- ADD 2019/11/13 ---------->>>>>
            // 処理区分毎のディクショナリ定義
            Dictionary<int, ArrayList> OpDivList = new Dictionary<int, ArrayList>();
            // --- ADD 2019/11/13 ----------<<<<<

            int status = StatusError;

            // 登録用パラメータデータがない場合
            if (inspectDataAddListObj == null)
            {
                // ログ出力します。
                this.WriteLog(null, ConditionsError);
                return status;
            }

            ArrayList inspectDataAddList = inspectDataAddListObj as ArrayList;
            // 更新区分フラグ
            bool updateDivFlg = true;
            foreach (InspectDataAddWork inspectDataAddParamWork in inspectDataAddList)
            {
                // 必須入力項目のチェック
                // コンピュータ名
                if (String.IsNullOrEmpty(inspectDataAddParamWork.MachineName.Trim())
                    // 従業員コード
                  || String.IsNullOrEmpty(inspectDataAddParamWork.EmployeeCode.Trim())
                    // 企業コード
                  || String.IsNullOrEmpty(inspectDataAddParamWork.EnterpriseCode.Trim())
                    // 倉庫コード
                  //|| String.IsNullOrEmpty(inspectDataAddParamWork.WarehouseCode.Trim()) // DEL 呉軍 2018/09/14 Redmine#49751 検品管理 在庫入庫更新PKG差異対応
                    // 引数.処理区分が「1,2」以外の場合、ST_ERR(-1)を返却します。
                  || (inspectDataAddParamWork.OpDiv != 1 && inspectDataAddParamWork.OpDiv != 2)
                    // メーカーコード
                  || (inspectDataAddParamWork.GoodsMakerCd <= 0)
                    // 発注先コード
                  || (inspectDataAddParamWork.UOESupplierCd <= 0)
                    // 仕入明細通番
                  || (inspectDataAddParamWork.StockSlipDtlNum <= 0)
                    // 引数.入庫区分が「1:拠点 2:BO1 3:BO2 4:BO3 5:ﾒｰｶｰ 6：EO」以外の場合、ST_ERR(-1)を返却します。
                  || (inspectDataAddParamWork.WarehousingDivCd != 1 && inspectDataAddParamWork.WarehousingDivCd != 2
                      && inspectDataAddParamWork.WarehousingDivCd != 3 && inspectDataAddParamWork.WarehousingDivCd != 4
                      && inspectDataAddParamWork.WarehousingDivCd != 5 && inspectDataAddParamWork.WarehousingDivCd != 6)
                    // 引数.更新区分が「0,1,2,3,9」以外の場合、ST_ERR(-1)を返却します。
                  || ((inspectDataAddParamWork.UpdateDiv != 0)
                      && (inspectDataAddParamWork.UpdateDiv != 1)
                      && (inspectDataAddParamWork.UpdateDiv != 2)
                      && (inspectDataAddParamWork.UpdateDiv != 3)
                      && (inspectDataAddParamWork.UpdateDiv != 9))
                    // 商品番号
                  || String.IsNullOrEmpty(inspectDataAddParamWork.GoodsNo.Trim()))
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(inspectDataAddParamWork, ParametersError);
                    return status;
                }

                // 桁のチェック
                if (inspectDataAddParamWork.GoodsMakerCd > 999999
                    || inspectDataAddParamWork.GoodsNo.Length > 40
                    // ---UPD 呉軍 2018/09/14 Redmine#49751 検品管理 在庫入庫更新PKG差異対応 ------>>>>>
                    //|| inspectDataAddParamWork.WarehouseCode.Length > 6
                    || ((!String.IsNullOrEmpty(inspectDataAddParamWork.WarehouseCode)) && (inspectDataAddParamWork.WarehouseCode.Length > 6))
                    // ---UPD 呉軍 2018/09/14 Redmine#49751 検品管理 在庫入庫更新PKG差異対応 ------<<<<<
                    || inspectDataAddParamWork.InspectStatus > 99
                    || inspectDataAddParamWork.InspectCode > 99
                    || inspectDataAddParamWork.InspectCnt > 99999999.99
                    || inspectDataAddParamWork.MachineName.Length > 80
                    || inspectDataAddParamWork.EmployeeCode.Length > 9)
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(inspectDataAddParamWork, ParametersError);
                    return status;
                }

                if (inspectDataAddParamWork.UpdateDiv != 2)
                {
                    updateDivFlg = false;
                }

                // --- ADD 2019/11/13 ---------->>>>>
                // OpDivがリストに無い場合は作成
                if (!OpDivList.ContainsKey(inspectDataAddParamWork.OpDiv))
                {
                    ArrayList opDivArrayList = new ArrayList();
                    OpDivList.Add(inspectDataAddParamWork.OpDiv, opDivArrayList);
                }
                // リストに現在の行を追加
                OpDivList[inspectDataAddParamWork.OpDiv].Add(inspectDataAddParamWork);
                // --- ADD 2019/11/13 ----------<<<<<
            }

            // 全てレコード.更新区分が「 2：未入荷」の場合、ST_NFOUND(4)を返却します。
            if (updateDivFlg)
            {
                status = StatusNotFound;
                return status;
            }

            try
            {
                // --- ADD 2019/11/13 ---------->>>>>
                // 複数の処理区分を考慮した形に改良
                ArrayList resultArrayList = new ArrayList();
                foreach(KeyValuePair<int,ArrayList> item in OpDivList){
                    ArrayList targetList = item.Value;
                    // --- ADD 2019/11/13 ----------<<<<<

                    // 検索情報を設定します。
                    UOEStockUpdSearch uoeStockUpdSearch = new UOEStockUpdSearch();
                    // 従業員コード
                    // --- MOD 2019/11/13 ---------->>>>>
                    //uoeStockUpdSearch.EnterpriseCode = ((InspectDataAddWork)inspectDataAddList[0]).EnterpriseCode;
                    uoeStockUpdSearch.EnterpriseCode = ((InspectDataAddWork)targetList[0]).EnterpriseCode;
                    // --- MOD 2019/11/13 ----------<<<<<
                    // 所属拠点コード
                    // --- MOD 2019/11/13 ---------->>>>>
                    //uoeStockUpdSearch.SectionCode = ((InspectDataAddWork)inspectDataAddList[0]).BelongSectionCode;
                    uoeStockUpdSearch.SectionCode = ((InspectDataAddWork)targetList[0]).BelongSectionCode;
                    // --- MOD 2019/11/13 ----------<<<<<

                    // --- MOD 2019/11/13 ---------->>>>>
                    // 処理区分
                    //if (((InspectDataAddWork)inspectDataAddList[0]).OpDiv == 1)
                    //{
                    //    // 引数.処理区分が「1:在庫一括分」の場合
                    //    uoeStockUpdSearch.ProcDiv = 0;
                    //}
                    //else
                    //{
                    //    // 引数.処理区分が「 2:その他」の場合
                    //    uoeStockUpdSearch.ProcDiv = 1;
                    //}
                    if (item.Key == 1)
                    {
                        // 引数.処理区分が「1:在庫一括分」の場合
                        uoeStockUpdSearch.ProcDiv = 0;
                    }
                    else
                    {
                        // 引数.処理区分が「 2:その他」の場合
                        uoeStockUpdSearch.ProcDiv = 1;
                    }
                    // --- MOD 2019/11/13 ----------<<<<<
                    // 発注コード
                    // --- MOD 2019/11/13 ---------->>>>>
                    //uoeStockUpdSearch.UOESupplierCd = ((InspectDataAddWork)inspectDataAddList[0]).UOESupplierCd;
                    uoeStockUpdSearch.UOESupplierCd = ((InspectDataAddWork)targetList[0]).UOESupplierCd;
                    // --- MOD 2019/11/13 ----------<<<<<

                    // 在庫入庫更新アクセス各種データ取り込み
                    PMUOE01203AA pmUOE01203AA = new PMUOE01203AA(uoeStockUpdSearch.EnterpriseCode, uoeStockUpdSearch.SectionCode, out status);

                    // 在庫入庫更新アクセス初期化失敗場合
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }

                    // ---ADD 呉軍 2018/09/14 Redmine#49751 検品管理 在庫入庫更新PKG差異対応 ------>>>>>
                    // 在庫一括品番区分
                    UOESettingAcs uoeSettingAcs = new UOESettingAcs();
                    UOESetting uoeSetting = null;
                    int uoeStatus = uoeSettingAcs.Read(out uoeSetting, uoeStockUpdSearch.EnterpriseCode, uoeStockUpdSearch.SectionCode);
                    if (uoeStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        pmUOE01203AA.StockBlnktPrtNoDiv = uoeSetting.StockBlnktPrtNoDiv;           // 在庫一括品番区分
                    }
                    else
                    {
                        status = StatusError;
                        return status;
                    }
                    // ---ADD 呉軍 2018/09/14 Redmine#49751 検品管理 在庫入庫更新PKG差異対応 ------<<<<<

                    // UOE発注データ情報検索処理
                    status = pmUOE01203AA.SetSearchDataForHandy(uoeStockUpdSearch);

                    // UOE発注データ情報検索処理がタイムアウト場合
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // UOE発注データ情報検索処理がタイムアウト場合
                        if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                        {
                            status = StatusTimeout;
                            return status;
                        }
                        // UOE発注データ情報を取得失敗場合
                        else
                        {
                            status = StatusError;
                            return status;
                        }
                    }


                    // 更新区分を設定します。
                    // --- MOD 2019/11/13 ---------->>>>>
                    //status = pmUOE01203AA.SetUpdateDivForHandy(inspectDataAddList);
                    status = pmUOE01203AA.SetUpdateDivForHandy(targetList);
                    // --- MOD 2019/11/13 ----------<<<<<

                    // 更新区分を設定失敗の場合
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }

                    // 入庫更新用データを準備処理
                    string msg = string.Empty;
                    object uoeStcUpdDataListObj = null;
                    status = pmUOE01203AA.DecisionDataForHandy(out uoeStcUpdDataListObj, out msg);

                    // 入庫更新用データを準備失敗の場合
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }

                    // 入庫更新処理
                    IHandyStockSupplierDB IHandyStockSupplierDBAdapter = MediationHandyStockSupplierDB.GetHandyStockSuppliersDB();
                    // --- MOD 2019/11/13 ---------->>>>>
                    //status = IHandyStockSupplierDBAdapter.WriteStockSupplier(ref inspectDataAddListObj, ref uoeStcUpdDataListObj);
                    object inspectDataAddObj = (object)targetList;
                    status = IHandyStockSupplierDBAdapter.WriteStockSupplier(ref inspectDataAddObj, ref uoeStcUpdDataListObj);
                    // --- MOD 2019/11/13 ----------<<<<<

                    // 入庫更新処理が正常の場合
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusNomal;
                    }
                    // 入庫更新処理がタイムアウト場合
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        status = StatusTimeout;
                    }
                    // 入庫更新失敗場合
                    else
                    {
                        status = StatusError;
                    }
                    // --- ADD 2019/11/13 ---------->>>>>
                    resultArrayList.AddRange(targetList);
                }
                // 元の変数へ再設定
                inspectDataAddListObj = (object)resultArrayList;
                // --- ADD 2019/11/13 ----------<<<<<
            }
            catch (Exception ex)
            {
                // エラーメッセージに引数の名前と値をログ出力します。
                this.WriteLog(null, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 何もしない
            }

            return status;
        }
        # endregion

        # region [ハンディターミナル在庫仕入（入庫更新）_一覧抽出処理]
        /// <summary>
        /// ハンディターミナル在庫仕入（入庫更新）_一覧抽出処理
        /// </summary>
        /// <param name="paraHandyStockSupplierCondObj">ハンディターミナル在庫仕入（入庫更新）_一覧抽出抽出条件リスト</param>
        /// <param name="resultHandyStockSupplierObj">ハンディターミナル在庫仕入（入庫更新）_一覧抽出結果リスト</param>
        /// <returns>ステータス[0: 正常, 4:見つからない、5:タイムアウト -1: エラー]</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（入庫更新）を一覧抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SearchHandyStockSupplierList(ref object paraHandyStockSupplierCondObj, out object resultHandyStockSupplierObj)
        {
            int status = StatusError;
            resultHandyStockSupplierObj = new object();

            HandyUOEOrderListParamWork handyUOEOrderListParamWorkData = paraHandyStockSupplierCondObj as HandyUOEOrderListParamWork;

            // 必須入力項目のチェック
            // コンピュータ名
            if (String.IsNullOrEmpty(handyUOEOrderListParamWorkData.MachineName.Trim())
                // 従業員コード
              || String.IsNullOrEmpty(handyUOEOrderListParamWorkData.EmployeeCode.Trim())
                // 引数.処理区分が「1,2」以外の場合、ST_ERR(-1)を返却します。
              || (handyUOEOrderListParamWorkData.OpDiv != 1 && handyUOEOrderListParamWorkData.OpDiv != 2))
            {
                // エラーメッセージに引数の名前と値をログ出力します。
                this.WriteLog(handyUOEOrderListParamWorkData, ParametersError);
                return status;
            }

            try
            {
                // ハンディターミナル在庫仕入（入庫更新）_一覧抽出リモート呼び出し
                byte[] condByte = XmlByteSerializer.Serialize(handyUOEOrderListParamWorkData);

                object stockSupplierListObj = null;
                IHandyStockSupplierDB iHandyStockSupplierDBAdapter = MediationHandyStockSupplierDB.GetHandyStockSuppliersDB();
                status = iHandyStockSupplierDBAdapter.SearchStockSupplierList(condByte, out stockSupplierListObj);

                // ハンディターミナル在庫仕入（入庫更新）_一覧情報を正常取得する場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList retList = stockSupplierListObj as ArrayList;
                    // ハンディターミナル在庫仕入（入庫更新）_一覧情報を整理します。
                    ArrayList htapRetList = this.CreateHandyStockSupplierList(retList);
                    resultHandyStockSupplierObj = (object)htapRetList;
                }
                // ハンディターミナル在庫仕入（入庫更新）_一覧情報が見つからない場合
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = StatusNotFound;
                }
                // ハンディターミナル在庫仕入（入庫更新）_一覧情報読込時のタイムアウト場合
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    status = StatusTimeout;
                }
                // DB処理等でエラーが発生した場合
                else
                {
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                // エラーメッセージに引数の名前と値をログ出力します。
                this.WriteLog(null, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 何もしない
            }

            return status;
        }
        # endregion

        # region [ハンディターミナル在庫仕入（入庫更新）_明細抽出処理]
        /// <summary>
        /// ハンディターミナル在庫仕入（入庫更新）_明細抽出処理
        /// </summary>
        /// <param name="paraHandyStockSupplierCondObj">ハンディターミナル在庫仕入（入庫更新）_一覧抽出抽出条件リスト</param>
        /// <param name="resultHandyStockSupplierObj">ハンディターミナル在庫仕入（入庫更新）_一覧抽出結果リスト</param>
        /// <returns>ステータス[0: 正常, 4:見つからない、5:タイムアウト -1: エラー]</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（入庫更新）_明細情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SearchHandyStockSupplierSlipNum(ref object paraHandyStockSupplierCondObj, out object resultHandyStockSupplierObj)
        {
            int status = StatusError;
            resultHandyStockSupplierObj = new object();

            HandyUOEOrderDtlParamWork handyUOEOrderDtlParamWorkData = paraHandyStockSupplierCondObj as HandyUOEOrderDtlParamWork;

            // 必須入力項目のチェック
            // コンピュータ名
            if (String.IsNullOrEmpty(handyUOEOrderDtlParamWorkData.MachineName.Trim())
                // 従業員コード
              || String.IsNullOrEmpty(handyUOEOrderDtlParamWorkData.EmployeeCode.Trim())
                // 引数.処理区分が「11」以外の場合、ST_ERR(-1)を返却します。
              || (handyUOEOrderDtlParamWorkData.OpDiv != 11)
                // 引数.入庫区分が「1:拠点 2:BO1 3:BO2 4:BO3 5:ﾒｰｶｰ 6：EO」以外の場合、ST_ERR(-1)を返却します。
              || (handyUOEOrderDtlParamWorkData.WarehousingDivCd != 1 && handyUOEOrderDtlParamWorkData.WarehousingDivCd != 2
                  && handyUOEOrderDtlParamWorkData.WarehousingDivCd != 3 && handyUOEOrderDtlParamWorkData.WarehousingDivCd != 4
                  && handyUOEOrderDtlParamWorkData.WarehousingDivCd != 5 && handyUOEOrderDtlParamWorkData.WarehousingDivCd != 6)
                // オンライン番号
              || (handyUOEOrderDtlParamWorkData.OnlineNo <= 0)
                // UOE発注番号
              || (handyUOEOrderDtlParamWorkData.UOESalesOrderNo <= 0))
            {
                // エラーメッセージに引数の名前と値をログ出力します。
                this.WriteLog(handyUOEOrderDtlParamWorkData, ParametersError);
                return status;
            }

            try
            {
                // ハンディターミナル在庫仕入（入庫更新）_明細抽出リモート呼び出し
                byte[] condByte = XmlByteSerializer.Serialize(handyUOEOrderDtlParamWorkData);

                object stockSupplierDtlObj = null;
                IHandyStockSupplierDB iHandyStockSupplierDBAdapter = MediationHandyStockSupplierDB.GetHandyStockSuppliersDB();
                status = iHandyStockSupplierDBAdapter.SearchHandyStockSupplierSlipNum(condByte, out stockSupplierDtlObj);

                // ハンディターミナル在庫仕入（入庫更新）_明細情報を正常取得する場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    resultHandyStockSupplierObj = stockSupplierDtlObj;
                }
                // ハンディターミナル在庫仕入（入庫更新）_明細情報が見つからない場合
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = StatusNotFound;
                }
                // ハンディターミナル在庫仕入（入庫更新）_明細情報読込時のタイムアウト場合
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    status = StatusTimeout;
                }
                // DB処理等でエラーが発生した場合
                else
                {
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                // エラーメッセージに引数の名前と値をログ出力します。
                this.WriteLog(null, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 何もしない
            }

            return status;
        }
        # endregion

        # region [private Methods]

        /// <summary>
        /// UOE入庫更新メインデータ作成
        /// </summary>
        /// <param name="arrayList">UOE発注データリスト</param>
        /// <remarks>
        /// <returns>UOE入庫更新メインデータ</returns>
        /// <br>Note       : UOE発注データからUOE入庫更新メインデータを取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private ArrayList CreateHandyStockSupplierList(ArrayList arrayList)
        {
            ArrayList retArrayList = new ArrayList();
            HandyUOEOrderListWork handyUOEOrderListWork = null;
            HandyUOEOrderResultListWork handyUOEOrderResultListWork = null;
            Dictionary<string, string> resultWorkDic = new Dictionary<string, string>();
            string dicKey = string.Empty;
 
            for (int index = 0; index <= arrayList.Count - 1; index++)
            {
                handyUOEOrderListWork = (HandyUOEOrderListWork)arrayList[index];

                // 重複のBO伝票番号編集処理
                this.UpdBOSlipNo(ref handyUOEOrderListWork);

                #region UOE拠点伝票番号
                if (handyUOEOrderListWork.EnterUpdDivSec == EnterUpdDivSecData0)
                {
                    handyUOEOrderResultListWork = new HandyUOEOrderResultListWork();
                    handyUOEOrderResultListWork.OnlineNo = handyUOEOrderListWork.OnlineNo;
                    handyUOEOrderResultListWork.UoeRemark1 = handyUOEOrderListWork.UoeRemark1;
                    handyUOEOrderResultListWork.UOESalesOrderNo = handyUOEOrderListWork.UOESalesOrderNo;
                    handyUOEOrderResultListWork.WarehousingDivCd = WarehousingSectionDiv;

                    if (string.IsNullOrEmpty(handyUOEOrderListWork.UOESectionSlipNo.Trim()))
                    {
                        handyUOEOrderResultListWork.SlipNo = EnterUpdDivSecSlipNo;
                    }
                    else
                    {
                        handyUOEOrderResultListWork.SlipNo = handyUOEOrderListWork.UOESectionSlipNo;
                    }

                    dicKey = this.GetDicKey(handyUOEOrderResultListWork.OnlineNo, handyUOEOrderResultListWork.UOESalesOrderNo, handyUOEOrderResultListWork.SlipNo);

                    if (!resultWorkDic.ContainsKey(dicKey))
                    {
                        retArrayList.Add(handyUOEOrderResultListWork);
                        resultWorkDic.Add(dicKey, string.Empty);
                    }
                }
                #endregion

                #region BO伝票番号1
                if (handyUOEOrderListWork.EnterUpdDivBO1 == EnterUpdDivBO1Data0)
                {
                    handyUOEOrderResultListWork = new HandyUOEOrderResultListWork();
                    handyUOEOrderResultListWork.OnlineNo = handyUOEOrderListWork.OnlineNo;
                    handyUOEOrderResultListWork.UoeRemark1 = handyUOEOrderListWork.UoeRemark1;
                    handyUOEOrderResultListWork.UOESalesOrderNo = handyUOEOrderListWork.UOESalesOrderNo;
                    handyUOEOrderResultListWork.WarehousingDivCd = WarehousingBo1Div;

                    if (string.IsNullOrEmpty(handyUOEOrderListWork.BOSlipNo1.Trim()))
                    {
                        handyUOEOrderResultListWork.SlipNo = EnterUpdDivBO1SlipNo;
                    }
                    else
                    {
                        handyUOEOrderResultListWork.SlipNo = handyUOEOrderListWork.BOSlipNo1;
                    }

                    dicKey = this.GetDicKey(handyUOEOrderResultListWork.OnlineNo, handyUOEOrderResultListWork.UOESalesOrderNo, handyUOEOrderResultListWork.SlipNo);

                    if (!resultWorkDic.ContainsKey(dicKey))
                    {
                        retArrayList.Add(handyUOEOrderResultListWork);
                        resultWorkDic.Add(dicKey, string.Empty);
                    }
                }
                #endregion

                #region BO伝票番号2
                if (handyUOEOrderListWork.EnterUpdDivBO2 == EnterUpdDivBO2Data0)
                {
                    handyUOEOrderResultListWork = new HandyUOEOrderResultListWork();
                    handyUOEOrderResultListWork.OnlineNo = handyUOEOrderListWork.OnlineNo;
                    handyUOEOrderResultListWork.UoeRemark1 = handyUOEOrderListWork.UoeRemark1;
                    handyUOEOrderResultListWork.UOESalesOrderNo = handyUOEOrderListWork.UOESalesOrderNo;
                    handyUOEOrderResultListWork.WarehousingDivCd = WarehousingBo2Div;

                    if (string.IsNullOrEmpty(handyUOEOrderListWork.BOSlipNo2.Trim()))
                    {
                        handyUOEOrderResultListWork.SlipNo = EnterUpdDivBO2SlipNo;
                    }
                    else
                    {
                        handyUOEOrderResultListWork.SlipNo = handyUOEOrderListWork.BOSlipNo2;
                    }

                    dicKey = this.GetDicKey(handyUOEOrderResultListWork.OnlineNo, handyUOEOrderResultListWork.UOESalesOrderNo, handyUOEOrderResultListWork.SlipNo);

                    if (!resultWorkDic.ContainsKey(dicKey))
                    {
                        retArrayList.Add(handyUOEOrderResultListWork);
                        resultWorkDic.Add(dicKey, string.Empty);
                    }
                }
                #endregion

                #region BO伝票番号3
                if (handyUOEOrderListWork.EnterUpdDivBO3 == EnterUpdDivBO3Data0)
                {
                    handyUOEOrderResultListWork = new HandyUOEOrderResultListWork();
                    handyUOEOrderResultListWork.OnlineNo = handyUOEOrderListWork.OnlineNo;
                    handyUOEOrderResultListWork.UoeRemark1 = handyUOEOrderListWork.UoeRemark1;
                    handyUOEOrderResultListWork.UOESalesOrderNo = handyUOEOrderListWork.UOESalesOrderNo;
                    handyUOEOrderResultListWork.WarehousingDivCd = WarehousingBo3Div;

                    if (string.IsNullOrEmpty(handyUOEOrderListWork.BOSlipNo3.Trim()))
                    {
                        handyUOEOrderResultListWork.SlipNo = EnterUpdDivBO3SlipNo;
                    }
                    else
                    {
                        handyUOEOrderResultListWork.SlipNo = handyUOEOrderListWork.BOSlipNo3;
                    }

                    dicKey = this.GetDicKey(handyUOEOrderResultListWork.OnlineNo, handyUOEOrderResultListWork.UOESalesOrderNo, handyUOEOrderResultListWork.SlipNo);

                    if (!resultWorkDic.ContainsKey(dicKey))
                    {
                        retArrayList.Add(handyUOEOrderResultListWork);
                        resultWorkDic.Add(dicKey, string.Empty);
                    }
                }
                #endregion

                #region ﾒｰｶｰ
                if (handyUOEOrderListWork.EnterUpdDivMaker == EnterUpdDivMakerData0)
                {
                    handyUOEOrderResultListWork = new HandyUOEOrderResultListWork();
                    handyUOEOrderResultListWork.OnlineNo = handyUOEOrderListWork.OnlineNo;
                    handyUOEOrderResultListWork.UoeRemark1 = handyUOEOrderListWork.UoeRemark1;
                    handyUOEOrderResultListWork.UOESalesOrderNo = handyUOEOrderListWork.UOESalesOrderNo;
                    handyUOEOrderResultListWork.WarehousingDivCd = WarehousingMakerDiv;
                    handyUOEOrderResultListWork.SlipNo = EnterUpdDivMakerSlipNo;

                    dicKey = this.GetDicKey(handyUOEOrderResultListWork.OnlineNo, handyUOEOrderResultListWork.UOESalesOrderNo, handyUOEOrderResultListWork.SlipNo);

                    if (!resultWorkDic.ContainsKey(dicKey))
                    {
                        retArrayList.Add(handyUOEOrderResultListWork);
                        resultWorkDic.Add(dicKey, string.Empty);
                    }
                }
                #endregion

                #region EO
                if (handyUOEOrderListWork.EnterUpdDivEO == EnterUpdDivEOData0)
                {
                    handyUOEOrderResultListWork = new HandyUOEOrderResultListWork();
                    handyUOEOrderResultListWork.OnlineNo = handyUOEOrderListWork.OnlineNo;
                    handyUOEOrderResultListWork.UoeRemark1 = handyUOEOrderListWork.UoeRemark1;
                    handyUOEOrderResultListWork.UOESalesOrderNo = handyUOEOrderListWork.UOESalesOrderNo;
                    handyUOEOrderResultListWork.WarehousingDivCd = WarehousingEoDiv;
                    handyUOEOrderResultListWork.SlipNo = EnterUpdDivEOSlipNo;

                    dicKey = this.GetDicKey(handyUOEOrderResultListWork.OnlineNo, handyUOEOrderResultListWork.UOESalesOrderNo, handyUOEOrderResultListWork.SlipNo);

                    if (!resultWorkDic.ContainsKey(dicKey))
                    {
                        retArrayList.Add(handyUOEOrderResultListWork);
                        resultWorkDic.Add(dicKey, string.Empty);
                    }
                }
                #endregion
            }

            return retArrayList;
        }

        /// <summary>
        /// 重複のBO伝票番号ディクショナリキーの作成処理
        /// </summary>
        /// <param name="onlineNo">オンライン番号</param>
        /// <param name="uoeSalesOrderNo">UOE発注番号</param>
        /// <param name="slipNo">伝票番号</param>
        /// <remarks>
        /// <br>Note       : 重複のBO伝票番号ディクショナリキーの作成処理を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private string GetDicKey(int onlineNo, int uoeSalesOrderNo, string slipNo)
        {
            string dicKey = string.Empty;

            StringBuilder sb = new StringBuilder();
            // オンライン番号
            sb.Append(onlineNo.ToString());
            sb.Append(Separator);
            // UOE発注番号
            sb.Append(uoeSalesOrderNo.ToString());
            sb.Append(Separator);
            // 伝票番号
            sb.Append(slipNo);

            dicKey = sb.ToString();
            return dicKey;
        }

        /// <summary>
        /// 重複のBO伝票番号編集処理
        /// </summary>
        /// <param name="handyUOEOrderListWork">UOE発注データ</param>
        /// <remarks>
        /// <br>Note       : 重複のBO伝票番号によって、通信IDよて、「-F」の編集処理を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private void UpdBOSlipNo(ref HandyUOEOrderListWork handyUOEOrderListWork)
        {
            // UOE伝票番号
            string tempUOESectionSlipNo = handyUOEOrderListWork.UOESectionSlipNo;
            // BO1伝票番号
            string tempBOSlipNo1 = handyUOEOrderListWork.BOSlipNo1;
            // BO2伝票番号
            string tempBOSlipNo2 = handyUOEOrderListWork.BOSlipNo2;
            // BO3伝票番号
            string tempBOSlipNo3 = handyUOEOrderListWork.BOSlipNo3;

            switch (handyUOEOrderListWork.CommAssemblyId.Trim())
            {
                // ホンダ e-Parts「通信ID：0502」の場合
                case EnumUoeConst.ctCommAssemblyId_0502:
                    {
                        // BO1伝票番号がある場合
                        if (!string.IsNullOrEmpty(tempBOSlipNo1) && !string.IsNullOrEmpty(tempBOSlipNo1.Trim()))
                        {
                            handyUOEOrderListWork.BOSlipNo1 = tempBOSlipNo1 + DuplicationSlipNoF;
                        }

                        // BO2伝票番号がある場合
                        if (!string.IsNullOrEmpty(tempBOSlipNo2) && !string.IsNullOrEmpty(tempBOSlipNo2.Trim()))
                        {
                            if (tempBOSlipNo2.Equals(tempUOESectionSlipNo))
                            {
                                handyUOEOrderListWork.BOSlipNo2 = tempBOSlipNo2 + DuplicationSlipNoF2;
                            }
                        }

                        // BO3伝票番号がある場合
                        if (!string.IsNullOrEmpty(tempBOSlipNo3) && !string.IsNullOrEmpty(tempBOSlipNo3.Trim()))
                        {
                            if (tempBOSlipNo3.Equals(tempUOESectionSlipNo) || tempBOSlipNo3.Equals(tempBOSlipNo2))
                            {
                                handyUOEOrderListWork.BOSlipNo3 = tempBOSlipNo3 + DuplicationSlipNoF3;
                            }
                        }

                        break;
                    }
                // ホンダ e-Parts「通信ID：0502」以外の場合
                default:
                    {
                        // BO1伝票番号がある場合
                        if (!string.IsNullOrEmpty(tempBOSlipNo1) && !string.IsNullOrEmpty(tempBOSlipNo1.Trim()))
                        {
                            if (tempBOSlipNo1.Equals(tempUOESectionSlipNo))
                            {
                                handyUOEOrderListWork.BOSlipNo1 = tempBOSlipNo1 + DuplicationSlipNoF;
                            }
                        }

                        // BO2伝票番号がある場合
                        if (!string.IsNullOrEmpty(tempBOSlipNo2) && !string.IsNullOrEmpty(tempBOSlipNo2.Trim()))
                        {
                            if (tempBOSlipNo2.Equals(tempUOESectionSlipNo) ||
                                tempBOSlipNo2.Equals(tempBOSlipNo1))
                            {
                                handyUOEOrderListWork.BOSlipNo2 = tempBOSlipNo2 + DuplicationSlipNoF2;
                            }
                        }

                        // BO3伝票番号がある場合
                        if (!string.IsNullOrEmpty(tempBOSlipNo3) && !string.IsNullOrEmpty(tempBOSlipNo3.Trim()))
                        {
                            if (tempBOSlipNo3.Equals(tempUOESectionSlipNo) ||
                                tempBOSlipNo3.Equals(tempBOSlipNo1) ||
                                tempBOSlipNo3.Equals(tempBOSlipNo2))
                            {
                                handyUOEOrderListWork.BOSlipNo3 = tempBOSlipNo3 + DuplicationSlipNoF3;
                            }
                        }

                        break;
                    }
            }
        }


        /// <summary>
        /// エラーログ出力処理
        /// </summary>
        /// <param name="logObj">検索条件オブジェクト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : エラーログ情報を出力します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private void WriteLog(object logObj, string errMsg)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + LogPath;

            lock (LogLockObj)
            {
                // フォルダが存在しない場合、
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FileStream fileStream = new FileStream(Path.Combine(path, PgId + DateTime.Now.ToString(DefaultTime) + File), FileMode.Append, FileAccess.Write, FileShare.Write);
                StreamWriter writer = new StreamWriter(fileStream, Encoding.GetEncoding(DefaultEncode));
                DateTime writingDateTime = DateTime.Now;
                writer.WriteLine(string.Format(DefaultFormat, writingDateTime, writingDateTime.Millisecond, errMsg));
                // パラメータがnullではない場合、エラーメッセージに引数の名前と値を出力します。
                if (logObj is InspectDataAddWork)
                {
                    InspectDataAddWork inspectDataAddWork = logObj as InspectDataAddWork;
                    // 企業コード
                    writer.WriteLine(EnterpriseCod + inspectDataAddWork.EnterpriseCode);
                    // コンピュータ名
                    writer.WriteLine(MachineName + inspectDataAddWork.MachineName);
                    // 所属拠点コード
                    writer.WriteLine(BelongSectionCode + inspectDataAddWork.BelongSectionCode);
                    // 従業員コード
                    writer.WriteLine(EmployeeCode + inspectDataAddWork.EmployeeCode);
                    // 商品メーカーコード
                    writer.WriteLine(GoodsMakerCd + inspectDataAddWork.GoodsMakerCd);
                    // 商品番号
                    writer.WriteLine(GoodsNo + inspectDataAddWork.GoodsNo);
                    // 倉庫コード
                    writer.WriteLine(WarehouseCode + inspectDataAddWork.WarehouseCode);
                    // 検品ステータス
                    writer.WriteLine(InspectStatus + inspectDataAddWork.InspectStatus);
                    // 検品区分
                    writer.WriteLine(InspectCode + inspectDataAddWork.InspectCode);
                    // 検品数
                    writer.WriteLine(InspectCnt + inspectDataAddWork.InspectCnt);
                    // 更新区分
                    writer.WriteLine(UpdateDiv + inspectDataAddWork.UpdateDiv);
                    // 仕入明細通番
                    writer.WriteLine(StockSlipDtlNum + inspectDataAddWork.StockSlipDtlNum);
                    // 処理区分
                    writer.WriteLine(OpDiv + inspectDataAddWork.OpDiv);
                    // 発注先コード
                    writer.WriteLine(UOESupplierCd + inspectDataAddWork.UOESupplierCd);
                    // 入庫区分
                    writer.WriteLine(WarehousingDivCd + inspectDataAddWork.WarehousingDivCd);
                }
                else if (logObj is HandyUOEOrderListParamWork)
                {
                    HandyUOEOrderListParamWork handyUOEOrderListParamWorkData = logObj as HandyUOEOrderListParamWork;
                    // 企業コード
                    writer.WriteLine(EnterpriseCod + handyUOEOrderListParamWorkData.EnterpriseCode);
                    // 従業員コード
                    writer.WriteLine(EmployeeCode + handyUOEOrderListParamWorkData.EmployeeCode);
                    // コンピュータ名
                    writer.WriteLine(MachineName + handyUOEOrderListParamWorkData.MachineName);
                    // 処理区分
                    writer.WriteLine(OpDiv + handyUOEOrderListParamWorkData.OpDiv);
                    // 発注先コード
                    writer.WriteLine(UOESupplierCd + handyUOEOrderListParamWorkData.SupplierCode);
                }
                else if (logObj is HandyUOEOrderDtlParamWork)
                {
                    HandyUOEOrderDtlParamWork handyUOEOrderDtlParamWorkData = logObj as HandyUOEOrderDtlParamWork;
                    // 企業コード
                    writer.WriteLine(EnterpriseCod + handyUOEOrderDtlParamWorkData.EnterpriseCode);
                    // 従業員コード
                    writer.WriteLine(EmployeeCode + handyUOEOrderDtlParamWorkData.EmployeeCode);
                    // コンピュータ名
                    writer.WriteLine(MachineName + handyUOEOrderDtlParamWorkData.MachineName);
                    // 処理区分
                    writer.WriteLine(OpDiv + handyUOEOrderDtlParamWorkData.OpDiv);
                    // オンライン番号
                    writer.WriteLine(OnlineNo + handyUOEOrderDtlParamWorkData.OnlineNo);
                    // UOE発注番号
                    writer.WriteLine(UOESalesOrderNo + handyUOEOrderDtlParamWorkData.UOESalesOrderNo);
                    // 入庫区分
                    writer.WriteLine(WarehousingDivCd + handyUOEOrderDtlParamWorkData.WarehousingDivCd);
                }

                // ファイルストリームがnullではない場合、
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
        }
        #endregion
    }
}
