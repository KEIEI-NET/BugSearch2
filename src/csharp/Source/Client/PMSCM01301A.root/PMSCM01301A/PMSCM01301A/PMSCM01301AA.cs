//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : BLP自社設定マスタ倉庫移行
// プログラム概要   : BLP自社設定マスタ倉庫移行アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 三戸　伸悟
// 作 成 日  2012/12/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 修 正 日  2013/01/07  修正内容 : 1/16配信システム障害№44、№45 対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using System.Runtime.Remoting;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller.Util;
using System.Configuration;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// BLP自社設定マスタ倉庫移行アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLP自社設定マスタ倉庫移行ＵＩクラス</br>
    /// <br>Programmer : 三戸　伸悟</br>
    /// <br>Date	   : 2012/12/14</br>
    /// </remarks>  
    public class PccCmpnyStAcs
    {
        /// <summary>
        /// リモートオブジェクトインターフェイス
        /// </summary>
        private IPccCmpnyStDB _IPccCmpnyStDB;       // BLP自社設定マスタ
        private CustomerInfoAcs _customerInfoAcs;   // 得意先マスタ
        private PosTerminalMgAcs _posTerminalMgAcs; // POS端末管理マスタ
        private SCMTtlStAcs _scmTtlStAcs;           // SCM全体設定
        private WarehouseAcs _warehouseAcs;         // 倉庫マスタ
        private SecInfoSetAcs _secInfoSetAcs;       // 拠点設定
        private ScmEpScCntAcs _scmEpScCntAcs;	    // SCM企業拠点連結アクセスクラス

        //得意先
        private Hashtable _customerInfoTable;
        private const string CUSTOMEMPTY_BASE = "ベース設定";
        private const string CONFIG_FILE = "PMSCM01300U.exe.config";
        private const string RUN_IKO = "RunIko";

        #region ■ Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// </remarks>
        public PccCmpnyStAcs()
        {
            this._IPccCmpnyStDB = MediationPccCmpnyStDB.GetPccCmpnyStDB();      // BLP自社設定マスタ
            this._customerInfoAcs = new CustomerInfoAcs();                      // 得意先マスタ
            this._posTerminalMgAcs = new PosTerminalMgAcs();                    // POS端末管理マスタ
            this._scmTtlStAcs = new SCMTtlStAcs();                              // SCM全体設定
            this._warehouseAcs = new WarehouseAcs();                            // 倉庫マスタ
            this._secInfoSetAcs = new SecInfoSetAcs();                          // 拠点設定
            this._scmEpScCntAcs = new ScmEpScCntAcs();                          // SCM連結先企業拠点データ

            this._customerInfoTable = new Hashtable();                          // 得意先マスタ
        }
        #endregion ■ Constructor

        /// <summary>
        /// BLP自社設定マスタ倉庫移行検索処理
        /// </summary>
        /// <param name="parsePccCmpnySt">検索パラメータ</param>
        /// <param name="batch">バッチ処理</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : BLP自社設定マスタ倉庫移行検索処理</br>
        /// <br>Programmer : 三戸　伸悟</br>
        /// <br>Date       : 2012/12/14</br>
        /// </remarks>
        public int Search(PccCmpnySt parsePccCmpnySt, bool batch)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            PosTerminalMg _posTerminalMg = null;                            // POS端末管理マスタ
            SCMTtlSt _scmTtlSt = null;                                      // SCM全体設定
            List<CustomerInfo> customerInfoList = null;                     // 得意先マスタ
            PccCmpnyStWork parsePccCmpnyStWork = null;                      // BLP自社設定マスタ
            List<PccCmpnySt> pccCmpnyStList = new List<PccCmpnySt>();       // BLP自社設定マスタ
            Object objPccCmpnyStWorkList = null;                            // BLP自社設定マスタ
            ArrayList pccCmpnyStWorkResultList = null;                      // BLP自社設定マスタ
            ArrayList WarehouseList = null;                                 // 倉庫マスタ
            ArrayList secInfoSets = null;                                   // 拠点設定
            List<ScmEpScCnt> scmEpScCntList;                                // SCM連結先企業拠点データ

            if (parsePccCmpnySt == null) return -1; // パラメータ未設定
            // バッチ処理判定
            if (batch)
            {
                // 自端末の端末番号を取得
                status = this._posTerminalMgAcs.Search(out _posTerminalMg, parsePccCmpnySt.InqOtherEpCd);
                
                // SCM全体設定取得
                this._scmTtlStAcs.Read(out _scmTtlSt, parsePccCmpnySt.InqOtherEpCd, parsePccCmpnySt.InqOtherSecCd.Trim());
                if (_scmTtlSt == null) this._scmTtlStAcs.Read(out _scmTtlSt, parsePccCmpnySt.InqOtherEpCd, "00");
                
                // 受信端末判定
                if (_posTerminalMg.CashRegisterNo != _scmTtlSt.CashRegisterNo) return -2; // 自端末が受信処理端末ではない場合実行しない

                // 最初の１回のみ実行
                if (ConfigurationManager.AppSettings[RUN_IKO] != null)
                {
                    if (ConfigurationManager.AppSettings[RUN_IKO].Equals("1")) return -3; //２回目以降
                }
            }

            try
            {
                EasyLogger.Write(DateTime.Now + "：倉庫移行処理開始↓↓↓↓");

                // 得意先マスタ取得
                if (this._customerInfoAcs.Search(parsePccCmpnySt.InqOtherEpCd, true, true, out customerInfoList) != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return -4; // 得意先マスタ取得失敗
                foreach (CustomerInfo customerInfo in customerInfoList)
                {
                    this._customerInfoTable.Add(customerInfo.CustomerCode, customerInfo.CustomerSnm);
                }

                // BLP自社設定マスタ取得
                pccCmpnyStList.Add(parsePccCmpnySt);
                this.CopyCmpnyStToWork(out pccCmpnyStWorkResultList, pccCmpnyStList);
                parsePccCmpnyStWork = pccCmpnyStWorkResultList[0] as PccCmpnyStWork;
                parsePccCmpnyStWork.InqOtherSecCd = ""; // 全拠点取得
                status = _IPccCmpnyStDB.Search(out objPccCmpnyStWorkList, parsePccCmpnyStWork, 0, ConstantManagement.LogicalMode.GetData01);

                // 結果を戻す
                pccCmpnyStWorkResultList = objPccCmpnyStWorkList as ArrayList;
                if (pccCmpnyStWorkResultList != null) this.CopyWorkToCmpnySt(pccCmpnyStWorkResultList, out pccCmpnyStList);

                // 倉庫マスタ取得
                if (this._warehouseAcs.Search(out WarehouseList, parsePccCmpnySt.InqOtherEpCd) != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return -5; // 倉庫マスタ取得失敗
                
                // 拠点設定取得
                if (this._secInfoSetAcs.Search(out secInfoSets, parsePccCmpnySt.InqOtherEpCd) != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return -6; // 拠点設定取得失敗

                // SCM連結先企業拠点データ取得
                bool msgDiv;
                string errMsg;
                if (this._scmEpScCntAcs.SearchCnectOriginalEpFromSc(parsePccCmpnySt.InqOtherEpCd, ConstantManagement.LogicalMode.GetData0, out scmEpScCntList, out msgDiv, out errMsg) != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return -7; // SCM連結先企業拠点データ取得失敗
                foreach (ScmEpScCnt scmEpScCnt in scmEpScCntList)
                {
                    List<PccCmpnySt> pccCmpnyStWriteList = new List<PccCmpnySt>();
                    bool insertFlg = true;  // BLP自社設定マスタに登録するかの判定フラグ

                    if (pccCmpnyStList != null)
                    {
                        foreach (PccCmpnySt pccCmpnySt in pccCmpnyStList)
                        {
                            // BLP自社設定マスタに登録されているか判定
                            if (pccCmpnySt.InqOtherEpCd == scmEpScCnt.CnectOtherEpCd
                                && pccCmpnySt.InqOtherSecCd == scmEpScCnt.CnectOtherSecCd
                                && pccCmpnySt.InqOriginalEpCd.Trim() == scmEpScCnt.CnectOriginalEpCd.Trim() //@@@@20230303
                                && pccCmpnySt.InqOriginalSecCd == scmEpScCnt.CnectOriginalSecCd)
                            {
                                if (pccCmpnySt.LogicalDeleteCode == 0)
                                {
                                    // 既に登録済
                                    insertFlg = false;
                                    break;
                                }
                                else
                                {
                                    // 論理削除されてる
                                    pccCmpnySt.LogicalDeleteCode = 0;
                                    pccCmpnyStWriteList.Add(pccCmpnySt);
                                    break;
                                }
                            }
                        }
                    }

                    if (!insertFlg) continue;  // 登録済

                    if (pccCmpnyStWriteList.Count == 0)
                    {
                        // 新規登録の場合
                        PccCmpnySt pccCmpnySt = new PccCmpnySt();
                        pccCmpnySt.InqOtherEpCd = scmEpScCnt.CnectOtherEpCd;
                        pccCmpnySt.InqOtherSecCd = scmEpScCnt.CnectOtherSecCd;
                        pccCmpnySt.InqOriginalEpCd = scmEpScCnt.CnectOriginalEpCd.Trim();//@@@@20230303
                        pccCmpnySt.InqOriginalSecCd = scmEpScCnt.CnectOriginalSecCd;
                        // ADD 2013/01/07 T.Yoshioka 2013/01/16配信 システムテスト障害№45 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        pccCmpnySt.StckStComment1 = "在庫あり";
                        pccCmpnySt.StckStComment2 = "在庫なし";
                        pccCmpnySt.StckStComment3 = "在庫不足";
                        // ADD 2013/01/07 T.Yoshioka 2013/01/16配信 システムテスト障害№45 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        pccCmpnyStWriteList.Add(pccCmpnySt);
                    }

                    // 該当得意先を探す
                    foreach (CustomerInfo customerInfo in customerInfoList)
                    {
                        if (pccCmpnyStWriteList[0].InqOtherEpCd == customerInfo.EnterpriseCode
                            // DEL 2013/01/07 T.Yoshioka 2013/01/16配信 システムテスト障害№44 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            // && pccCmpnyStWriteList[0].InqOtherSecCd == customerInfo.MngSectionCode
                            // DEL 2013/01/07 T.Yoshioka 2013/01/16配信 システムテスト障害№44 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                            && pccCmpnyStWriteList[0].InqOriginalEpCd.Trim() == customerInfo.CustomerEpCode.Trim() //@@@@20230303
                            && pccCmpnyStWriteList[0].InqOriginalSecCd == customerInfo.CustomerSecCode)
                        {
                            pccCmpnyStWriteList[0].PccCompanyCode = customerInfo.CustomerCode;

                            // 委託倉庫
                            pccCmpnyStWriteList[0].PccWarehouseCd = "";
                            foreach (Warehouse warehouse in WarehouseList)
                            {
                                if (warehouse.WarehouseCode == customerInfo.CustWarehouseCd
                                    && warehouse.CustomerCode == customerInfo.CustomerCode)
                                {
                                    // 倉庫マスタに存在して、得意先コードが一致する場合、委託倉庫
                                    pccCmpnyStWriteList[0].PccWarehouseCd = warehouse.WarehouseCode;
                                    break;
                                }
                            }

                            // 参照倉庫
                            pccCmpnyStWriteList[0].PccPriWarehouseCd1 = "";
                            pccCmpnyStWriteList[0].PccPriWarehouseCd2 = "";
                            pccCmpnyStWriteList[0].PccPriWarehouseCd3 = "";
                            foreach (SecInfoSet secInfoSet in secInfoSets)
                            {
                                // UPD 2013/01/07 T.Yoshioka 2013/01/16配信 システムテスト障害№44 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                                // if (secInfoSet.SectionCode == customerInfo.MngSectionCode)
                                if (secInfoSet.SectionCode == pccCmpnyStWriteList[0].InqOtherSecCd)
                                // UPD 2013/01/07 T.Yoshioka 2013/01/16配信 システムテスト障害№44 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                                {
                                    pccCmpnyStWriteList[0].PccPriWarehouseCd1 = secInfoSet.SectWarehouseCd1;
                                    pccCmpnyStWriteList[0].PccPriWarehouseCd2 = secInfoSet.SectWarehouseCd2;
                                    pccCmpnyStWriteList[0].PccPriWarehouseCd3 = secInfoSet.SectWarehouseCd3;
                                    break;
                                }
                            }
                            break;
                        }
                    }

                    if (pccCmpnyStWriteList[0].PccCompanyCode == 0) continue; //該当得意先なし

                    // 登録
                    status = this.Write(ref pccCmpnyStWriteList);
                    EasyLogger.Write("status:" + status + " " + LogTextMake(pccCmpnyStWriteList[0]));
                }

            }
            catch (RemotingException)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            finally
            {
                EasyLogger.Write(DateTime.Now + "：倉庫移行処理終了↑↑↑↑");
            }

            // config書き込み
            System.Configuration.ExeConfigurationFileMap file = new System.Configuration.ExeConfigurationFileMap();

            file.ExeConfigFilename = CONFIG_FILE;
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(file, System.Configuration.ConfigurationUserLevel.None);
            System.Configuration.AppSettingsSection appSettingSection = (System.Configuration.AppSettingsSection)config.GetSection("appSettings");
            if (appSettingSection.Settings[RUN_IKO] == null)
            {
                appSettingSection.Settings.Add(RUN_IKO, "1");
            } else 
            {
                appSettingSection.Settings[RUN_IKO].Value = "1";
            }
            config.Save(ConfigurationSaveMode.Modified);

            return status;
        }

        #region Private Method
        /// <summary>
        /// BLP自社設定マスタログ出力用テキスト編集
        /// </summary>
        /// <param name="pccCmpnySt">PCC自社設定データ</param>
        /// <returns>編集後文字列</returns>
        /// <remarks>
        /// <br>Note       : クラスをＣＳＶに編集</br>
        /// <br>Programmer : 三戸　伸悟</br>
        /// <br>Date       : 2012/12/14</br>
        /// </remarks>
        private string LogTextMake(PccCmpnySt pccCmpnySt)
        {
            StringBuilder logText = new System.Text.StringBuilder();
            const String DELIMITER = ",";

            logText.Append(pccCmpnySt.CreateDateTime);          //作成日時
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.UpdateDateTime);          //更新日時
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.LogicalDeleteCode);       //論理削除区分
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.InqOriginalEpCd.Trim());         //問合せ元企業コード//@@@@20230303
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.InqOriginalSecCd);        //問合せ元拠点コード
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.InqOtherEpCd);            //問合せ先企業コード
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.InqOtherSecCd);           //問合せ先拠点コード
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccCompanyCode);          //PCC自社コード
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccCompanyName);          //PCC自社名称
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccWarehouseCd);          //PCC倉庫コード
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccPriWarehouseCd1);      //PCC優先倉庫コード1
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccPriWarehouseCd2);      //PCC優先倉庫コード2
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccPriWarehouseCd3);      //PCC優先倉庫コード3
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.GoodsNoDspDiv);           //品番表示区分
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.GoodsNoDspDivName);       //品番表示名称
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.ListPrcDspDiv);           //標準価格表示区分
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.ListPrcDspDivName);       //標準価格表示名称
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.CostDspDiv);              //仕切価格表示区分
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.CostDspDivName);          //仕切価格表示名称
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.ShelfDspDiv);             //棚番表示区分
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.ShelfDspDivName);         //棚番表示名称
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.StockDspDiv);             //在庫表示区分
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.StockDspDivName);         //在庫表示名称
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.CommentDspDiv);           //コメント表示区分
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.CommentDspDivName);       //コメント表示名称
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.SpmtCntDspDiv);           //出荷数表示区分
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.SpmtCntDspDivName);       //出荷数表示名称
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.AcptCntDspDiv);           //受注数表示区分
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.AcptCntDspDivName);       //受注数表示名称
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PrtSelGdNoDspDiv);        //部品選択品番表示区分
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PrtSelGdNoDspDivName);    //部品選択品番表示名称
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PrtSelLsPrDspDiv);        //部品選択標準価格表示区分
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PrtSelLsPrDspDivName);    //部品選択標準価格表示名称
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PrtSelSelfDspDiv);        //部品選択棚番表示区分
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PrtSelSelfDspDivName);    //部品選択棚番表示名称
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PrtSelStckDspDiv);        //部品選択在庫表示区分
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PrtSelStckDspDivName);    //部品選択在庫表示名称
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.StckStMark1);             //在庫状況マーク1
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.StckStMark2);             //在庫状況マーク2
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.StckStMark3);             //在庫状況マーク3
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplName1);            //PCC発注先名称1
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplName2);            //PCC発注先名称2
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplKana);             //PCC発注先カナ名称
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplSnm);              //PCC発注先略称
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplPostNo);           //PCC発注先郵便番号
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplAddr1);            //PCC発注先住所1
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplAddr2);            //PCC発注先住所2
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplAddr3);            //PCC発注先住所3
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplTelNo1);           //PCC発注先電話番号1
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplTelNo2);           //PCC発注先電話番号2
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplFaxNo);            //PCC発注先FAX番号
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSlipPrtDiv);           //伝票発行区分（PCC）
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSlipPrtDivName);       //伝票発行名称（PCC）
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSlipRePrtDiv);         //伝票再発行区分
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSlipRePrtDivName);     //伝票再発行名称
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PrtSelPrmDspDiv);         //部品選択優良表示区分
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PrtSelPrmDspDivName);     //部品選択優良表示名称
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.StckStDspDiv);            //在庫状況表示区分
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.StckStDspDivName);        //在庫状況表示名称
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.StckStComment1);          //在庫コメント1
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.StckStComment2);          //在庫コメント2
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.StckStComment3);          //在庫コメント3
            return logText.ToString();
        }

        /// <summary>
        /// BLP自社設定マスタ倉庫移行登録、更新処理
        /// </summary>
        /// <param name="pccCmpnyStList">PCC自社設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : BLP自社設定マスタ倉庫移行登録、更新処理。</br>
        /// <br>Programmer : 三戸　伸悟</br>
        /// <br>Date       : 2012/12/14</br>
        /// </remarks>
        private int Write(ref List<PccCmpnySt> pccCmpnyStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccCmpnyStWorkList = null;
            ArrayList pccCmpnyStWorkResultList = null;

            try
            {
                if (pccCmpnyStList != null)
                {
                    this.CopyCmpnyStToWork(out pccCmpnyStWorkResultList, pccCmpnyStList);
                    objPccCmpnyStWorkList = pccCmpnyStWorkResultList as object;
                }

                //BLP自社設定マスタ倉庫移行登録、更新処理
                status = _IPccCmpnyStDB.Write(ref objPccCmpnyStWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //結果を戻す
                pccCmpnyStWorkResultList = objPccCmpnyStWorkList as ArrayList;

                if (pccCmpnyStWorkResultList != null)
                {
                    this.CopyWorkToCmpnySt(pccCmpnyStWorkResultList, out pccCmpnyStList);
                }

            }
            catch (RemotingException)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// BLP自社設定マスタ転換処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">BLP自社設定ワークリスト</param>
        /// <param name="pccCmpnyStList">BLP自社設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : BLP自社設定マスタ転換処理</br>
        /// <br>Programmer : 三戸　伸悟</br>
        /// <br>Date       : 2012/12/14</br>
        /// </remarks>
        private void CopyWorkToCmpnySt(ArrayList pccCmpnyStWorkList, out List<PccCmpnySt> pccCmpnyStList)
        {
            pccCmpnyStList = null;
            if (pccCmpnyStWorkList == null || pccCmpnyStWorkList.Count == 0)
            {
                return;
            }
            else
            {
                pccCmpnyStList = new List<PccCmpnySt>();
                foreach (PccCmpnyStWork wkPccCmpnyStWork in pccCmpnyStWorkList)
                {
                    PccCmpnySt pccCmpnySt = new PccCmpnySt();
                    //作成日時
                    pccCmpnySt.CreateDateTime = wkPccCmpnyStWork.CreateDateTime;
                    //更新日時
                    pccCmpnySt.UpdateDateTime = wkPccCmpnyStWork.UpdateDateTime;
                    //論理削除区分
                    pccCmpnySt.LogicalDeleteCode = wkPccCmpnyStWork.LogicalDeleteCode;
                    //問合せ元企業コード
                    pccCmpnySt.InqOriginalEpCd = wkPccCmpnyStWork.InqOriginalEpCd.Trim();//@@@@20230303
                    //問合せ元拠点コード
                    pccCmpnySt.InqOriginalSecCd = wkPccCmpnyStWork.InqOriginalSecCd;
                    //問合せ先企業コード
                    pccCmpnySt.InqOtherEpCd = wkPccCmpnyStWork.InqOtherEpCd;
                    //問合せ先拠点コード
                    pccCmpnySt.InqOtherSecCd = wkPccCmpnyStWork.InqOtherSecCd;
                    //PCC自社コード
                    pccCmpnySt.PccCompanyCode = wkPccCmpnyStWork.PccCompanyCode;
                    //PCC自社名称
                    string pccCompanyName = string.Empty;
                    if (this._customerInfoTable != null && this._customerInfoTable.ContainsKey(wkPccCmpnyStWork.PccCompanyCode))
                    {
                        pccCompanyName = this._customerInfoTable[wkPccCmpnyStWork.PccCompanyCode] as string;

                    }
                    pccCmpnySt.PccCompanyName = pccCompanyName;
                    //PCC倉庫コード
                    pccCmpnySt.PccWarehouseCd = wkPccCmpnyStWork.PccWarehouseCd;
                    //PCC優先倉庫コード1
                    pccCmpnySt.PccPriWarehouseCd1 = wkPccCmpnyStWork.PccPriWarehouseCd1;
                    //PCC優先倉庫コード2
                    pccCmpnySt.PccPriWarehouseCd2 = wkPccCmpnyStWork.PccPriWarehouseCd2;
                    //PCC優先倉庫コード3
                    pccCmpnySt.PccPriWarehouseCd3 = wkPccCmpnyStWork.PccPriWarehouseCd3;
                    //品番表示区分
                    pccCmpnySt.GoodsNoDspDiv = wkPccCmpnyStWork.GoodsNoDspDiv;
                    //品番表示名称
                    pccCmpnySt.GoodsNoDspDivName = getNameFromDiv(wkPccCmpnyStWork.GoodsNoDspDiv, 0);
                    //標準価格表示区分
                    pccCmpnySt.ListPrcDspDiv = wkPccCmpnyStWork.ListPrcDspDiv;
                    //標準価格表示名称
                    pccCmpnySt.ListPrcDspDivName = getNameFromDiv(wkPccCmpnyStWork.ListPrcDspDiv, 0);
                    //仕切価格表示区分
                    pccCmpnySt.CostDspDiv = wkPccCmpnyStWork.CostDspDiv;
                    //仕切価格表示名称
                    pccCmpnySt.CostDspDivName =  getNameFromDiv(wkPccCmpnyStWork.CostDspDiv, 0);
                    //棚番表示区分
                    pccCmpnySt.ShelfDspDiv = wkPccCmpnyStWork.ShelfDspDiv;
                    //棚番表示名称
                    pccCmpnySt.ShelfDspDivName =  getNameFromDiv(wkPccCmpnyStWork.ShelfDspDiv, 0);
                    //在庫表示区分
                    pccCmpnySt.StockDspDiv = wkPccCmpnyStWork.StockDspDiv;
                    //在庫表示名称
                    pccCmpnySt.StockDspDivName =  getNameFromDiv(wkPccCmpnyStWork.StockDspDiv, 0);
                    //コメント表示区分
                    pccCmpnySt.CommentDspDiv = wkPccCmpnyStWork.CommentDspDiv;
                    //コメント表示名称
                    pccCmpnySt.CommentDspDivName =  getNameFromDiv(wkPccCmpnyStWork.CommentDspDiv, 0);
                    //出荷数表示区分
                    pccCmpnySt.SpmtCntDspDiv = wkPccCmpnyStWork.SpmtCntDspDiv;
                    //出荷数表示名称
                    pccCmpnySt.SpmtCntDspDivName =  getNameFromDiv(wkPccCmpnyStWork.SpmtCntDspDiv, 0);
                    //受注数表示区分
                    pccCmpnySt.AcptCntDspDiv = wkPccCmpnyStWork.AcptCntDspDiv;
                    //受注数表示名称
                    pccCmpnySt.AcptCntDspDivName =  getNameFromDiv(wkPccCmpnyStWork.AcptCntDspDiv, 0);
                    //部品選択品番表示区分
                    pccCmpnySt.PrtSelGdNoDspDiv = wkPccCmpnyStWork.PrtSelGdNoDspDiv;
                    //部品選択品番表示名称
                    pccCmpnySt.PrtSelGdNoDspDivName =  getNameFromDiv(wkPccCmpnyStWork.PrtSelGdNoDspDiv, 0);
                    //部品選択標準価格表示区分
                    pccCmpnySt.PrtSelLsPrDspDiv = wkPccCmpnyStWork.PrtSelLsPrDspDiv;
                    //部品選択標準価格表示名称
                    pccCmpnySt.PrtSelLsPrDspDivName =  getNameFromDiv(wkPccCmpnyStWork.PrtSelLsPrDspDiv, 0);
                    //部品選択棚番表示区分
                    pccCmpnySt.PrtSelSelfDspDiv = wkPccCmpnyStWork.PrtSelSelfDspDiv;
                    //部品選択棚番表示名称
                    pccCmpnySt.PrtSelSelfDspDivName =  getNameFromDiv(wkPccCmpnyStWork.PrtSelSelfDspDiv, 0);
                    //部品選択在庫表示区分
                    pccCmpnySt.PrtSelStckDspDiv = wkPccCmpnyStWork.PrtSelStckDspDiv;
                    //部品選択在庫表示名称
                    pccCmpnySt.PrtSelStckDspDivName = getNameFromDiv(wkPccCmpnyStWork.PrtSelStckDspDiv, 0);
                    //在庫状況マーク1
                    pccCmpnySt.StckStMark1 = wkPccCmpnyStWork.StckStMark1;
                    //在庫状況マーク2
                    pccCmpnySt.StckStMark2 = wkPccCmpnyStWork.StckStMark2;
                    //在庫状況マーク3
                    pccCmpnySt.StckStMark3 = wkPccCmpnyStWork.StckStMark3;
                    //PCC発注先名称1
                    pccCmpnySt.PccSuplName1 = wkPccCmpnyStWork.PccSuplName1;
                    //PCC発注先名称2
                    pccCmpnySt.PccSuplName2 = wkPccCmpnyStWork.PccSuplName2;
                    //PCC発注先カナ名称
                    pccCmpnySt.PccSuplKana = wkPccCmpnyStWork.PccSuplKana;
                    //PCC発注先略称
                    pccCmpnySt.PccSuplSnm = wkPccCmpnyStWork.PccSuplSnm;
                    //PCC発注先郵便番号
                    pccCmpnySt.PccSuplPostNo = wkPccCmpnyStWork.PccSuplPostNo;
                    //PCC発注先住所1
                    pccCmpnySt.PccSuplAddr1 = wkPccCmpnyStWork.PccSuplAddr1;
                    //PCC発注先住所2
                    pccCmpnySt.PccSuplAddr2 = wkPccCmpnyStWork.PccSuplAddr2;
                    //PCC発注先住所3
                    pccCmpnySt.PccSuplAddr3 = wkPccCmpnyStWork.PccSuplAddr3;
                    //PCC発注先電話番号1
                    pccCmpnySt.PccSuplTelNo1 = wkPccCmpnyStWork.PccSuplTelNo1;
                    //PCC発注先電話番号2
                    pccCmpnySt.PccSuplTelNo2 = wkPccCmpnyStWork.PccSuplTelNo2;
                    //PCC発注先FAX番号
                    pccCmpnySt.PccSuplFaxNo = wkPccCmpnyStWork.PccSuplFaxNo;
                    //伝票発行区分（PCC）
                    pccCmpnySt.PccSlipPrtDiv = wkPccCmpnyStWork.PccSlipPrtDiv;
                    //伝票発行名称（PCC）
                    pccCmpnySt.PccSlipPrtDivName = getNameFromDiv(wkPccCmpnyStWork.PccSlipPrtDiv, 1);
                    //伝票再発行区分
                    pccCmpnySt.PccSlipRePrtDiv = wkPccCmpnyStWork.PccSlipRePrtDiv;
                    //伝票再発行名称
                    pccCmpnySt.PccSlipRePrtDivName = getNameFromDiv(wkPccCmpnyStWork.PccSlipRePrtDiv, 4);
                    //部品選択優良表示区分
                    pccCmpnySt.PrtSelPrmDspDiv = wkPccCmpnyStWork.PrtSelPrmDspDiv;
                    //部品選択優良表示名称
                    pccCmpnySt.PrtSelPrmDspDivName = getNameFromDiv(wkPccCmpnyStWork.PrtSelPrmDspDiv, 2);
                    //在庫状況表示区分
                    pccCmpnySt.StckStDspDiv = wkPccCmpnyStWork.StckStDspDiv;
                    //在庫状況表示名称
                    pccCmpnySt.StckStDspDivName = getNameFromDiv(wkPccCmpnyStWork.StckStDspDiv, 3);
                    //在庫コメント1
                    pccCmpnySt.StckStComment1 = wkPccCmpnyStWork.StckStComment1;
                    //在庫コメント2
                    pccCmpnySt.StckStComment2 = wkPccCmpnyStWork.StckStComment2;
                    //在庫コメント3
                    pccCmpnySt.StckStComment3 = wkPccCmpnyStWork.StckStComment3;

                    pccCmpnyStList.Add(pccCmpnySt);
                }
            }
        }

        /// <summary>
        /// BLP自社設定マスタ転換処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">BLP自社設定ワークリスト</param>
        /// <param name="pccCmpnyStList">BLP自社設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : BLP自社設定マスタ転換処理</br>
        /// <br>Programmer : 三戸　伸悟</br>
        /// <br>Date       : 2012/12/14</br>
        /// </remarks>
        private void CopyCmpnyStToWork(out ArrayList pccCmpnyStWorkList, List<PccCmpnySt> pccCmpnyStList)
        {
            pccCmpnyStWorkList = null;
            if (pccCmpnyStList == null || pccCmpnyStList.Count == 0)
            {
                return;
            }
            else
            {
                pccCmpnyStWorkList = new ArrayList();
                foreach (PccCmpnySt pccCmpnySt in pccCmpnyStList)
                {
                    PccCmpnyStWork wkPccCmpnyStWork = new PccCmpnyStWork();
                    //作成日時
                    wkPccCmpnyStWork.CreateDateTime = pccCmpnySt.CreateDateTime;
                    //更新日時
                    wkPccCmpnyStWork.UpdateDateTime = pccCmpnySt.UpdateDateTime;
                    //論理削除区分
                    wkPccCmpnyStWork.LogicalDeleteCode = pccCmpnySt.LogicalDeleteCode;
                    //問合せ元企業コード
                    wkPccCmpnyStWork.InqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
                    //問合せ元拠点コード
                    wkPccCmpnyStWork.InqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
                    //問合せ先企業コード
                    wkPccCmpnyStWork.InqOtherEpCd = pccCmpnySt.InqOtherEpCd;
                    //問合せ先拠点コード
                    wkPccCmpnyStWork.InqOtherSecCd = pccCmpnySt.InqOtherSecCd;
                    //PCC自社コード
                    wkPccCmpnyStWork.PccCompanyCode = pccCmpnySt.PccCompanyCode;
                    //PCC倉庫コード
                    wkPccCmpnyStWork.PccWarehouseCd = pccCmpnySt.PccWarehouseCd;
                    //PCC優先倉庫コード1
                    wkPccCmpnyStWork.PccPriWarehouseCd1 = pccCmpnySt.PccPriWarehouseCd1;
                    //PCC優先倉庫コード2
                    wkPccCmpnyStWork.PccPriWarehouseCd2 = pccCmpnySt.PccPriWarehouseCd2;
                    //PCC優先倉庫コード3
                    wkPccCmpnyStWork.PccPriWarehouseCd3 = pccCmpnySt.PccPriWarehouseCd3;
                    //品番表示区分
                    wkPccCmpnyStWork.GoodsNoDspDiv = pccCmpnySt.GoodsNoDspDiv;
                    //標準価格表示区分
                    wkPccCmpnyStWork.ListPrcDspDiv = pccCmpnySt.ListPrcDspDiv;
                    //仕切価格表示区分
                    wkPccCmpnyStWork.CostDspDiv = pccCmpnySt.CostDspDiv;
                    //棚番表示区分
                    wkPccCmpnyStWork.ShelfDspDiv = pccCmpnySt.ShelfDspDiv;
                    //在庫表示区分
                    wkPccCmpnyStWork.StockDspDiv = pccCmpnySt.StockDspDiv;
                    //コメント表示区分
                    wkPccCmpnyStWork.CommentDspDiv = pccCmpnySt.CommentDspDiv;
                    //出荷数表示区分
                    wkPccCmpnyStWork.SpmtCntDspDiv = pccCmpnySt.SpmtCntDspDiv;
                    //受注数表示区分
                    wkPccCmpnyStWork.AcptCntDspDiv = pccCmpnySt.AcptCntDspDiv;
                    //部品選択品番表示区分
                    wkPccCmpnyStWork.PrtSelGdNoDspDiv = pccCmpnySt.PrtSelGdNoDspDiv;
                    //部品選択標準価格表示区分
                    wkPccCmpnyStWork.PrtSelLsPrDspDiv = pccCmpnySt.PrtSelLsPrDspDiv;
                    //部品選択棚番表示区分
                    wkPccCmpnyStWork.PrtSelSelfDspDiv = pccCmpnySt.PrtSelSelfDspDiv;
                    //部品選択在庫表示区分
                    wkPccCmpnyStWork.PrtSelStckDspDiv = pccCmpnySt.PrtSelStckDspDiv;
                    //在庫状況マーク1
                    wkPccCmpnyStWork.StckStMark1 = pccCmpnySt.StckStMark1;
                    //在庫状況マーク2
                    wkPccCmpnyStWork.StckStMark2 = pccCmpnySt.StckStMark2;
                    //在庫状況マーク3
                    wkPccCmpnyStWork.StckStMark3 = pccCmpnySt.StckStMark3;
                    //PCC発注先名称1
                    wkPccCmpnyStWork.PccSuplName1 = pccCmpnySt.PccSuplName1;
                    //PCC発注先名称2
                    wkPccCmpnyStWork.PccSuplName2 = pccCmpnySt.PccSuplName2;
                    //PCC発注先カナ名称
                    wkPccCmpnyStWork.PccSuplKana = pccCmpnySt.PccSuplKana;
                    //PCC発注先略称
                    wkPccCmpnyStWork.PccSuplSnm = pccCmpnySt.PccSuplSnm;
                    //PCC発注先郵便番号
                    wkPccCmpnyStWork.PccSuplPostNo = pccCmpnySt.PccSuplPostNo;
                    //PCC発注先住所1
                    wkPccCmpnyStWork.PccSuplAddr1 = pccCmpnySt.PccSuplAddr1;
                    //PCC発注先住所2
                    wkPccCmpnyStWork.PccSuplAddr2 = pccCmpnySt.PccSuplAddr2;
                    //PCC発注先住所3
                    wkPccCmpnyStWork.PccSuplAddr3 = pccCmpnySt.PccSuplAddr3;
                    //PCC発注先電話番号1
                    wkPccCmpnyStWork.PccSuplTelNo1 = pccCmpnySt.PccSuplTelNo1;
                    //PCC発注先電話番号2
                    wkPccCmpnyStWork.PccSuplTelNo2 = pccCmpnySt.PccSuplTelNo2;
                    //PCC発注先FAX番号
                    wkPccCmpnyStWork.PccSuplFaxNo = pccCmpnySt.PccSuplFaxNo;
                    //伝票発行区分（PCC）
                    wkPccCmpnyStWork.PccSlipPrtDiv = pccCmpnySt.PccSlipPrtDiv;
                    //伝票再発行区分
                    wkPccCmpnyStWork.PccSlipRePrtDiv = pccCmpnySt.PccSlipRePrtDiv;
                    //部品選択優良表示区分
                    wkPccCmpnyStWork.PrtSelPrmDspDiv = pccCmpnySt.PrtSelPrmDspDiv;
                    //在庫状況表示区分
                    wkPccCmpnyStWork.StckStDspDiv = pccCmpnySt.StckStDspDiv;
                    //在庫コメント1
                    wkPccCmpnyStWork.StckStComment1 = pccCmpnySt.StckStComment1;
                    //在庫コメント2
                    wkPccCmpnyStWork.StckStComment2 = pccCmpnySt.StckStComment2;
                    //在庫コメント3
                    wkPccCmpnyStWork.StckStComment3 = pccCmpnySt.StckStComment3;

                    pccCmpnyStWorkList.Add(wkPccCmpnyStWork);
                }
            }

        }

        /// <summary>
        /// 区分から名称の取得処理
        /// </summary>
        /// <param name="div">区分</param>
        /// <param name="kind">種類(1:伝票発行区分（PCC）;2:部品選択優良表示区分;3:在庫状況表示区分;4:伝票再発行区分0:その他;)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 区分から名称の取得処理を行う。</br>
        /// <br>Programmer : 三戸　伸悟</br>
        /// <br>Date       : 2012/12/14</br>
        /// </remarks>
        private string getNameFromDiv(int div, int kind)
        {
            string name = string.Empty;
            switch (kind)
            {
                case 0:
                    {
                        switch (div)
                        {
                            case 0:
                                {
                                    name = "する";
                                    break;
                                }
                            case 1:
                                {
                                    name = "しない";
                                    break;
                                }
                        }
                      
                        break;
                    }
                //伝票発行区分（PCC）
                case 1:
                    {
                        switch (kind)
                        {
                            case 0:
                                {
                                    name = "しない";
                                    break;
                                }
                            case 1:
                                {
                                    name = "回答";
                                    break;
                                }
                            case 2:
                                {
                                    name = "ﾘﾓｰﾄ";
                                    break;
                                }
                            case 3:
                                {
                                    name = "両方";
                                    break;
                                }
                        }
                        break;
                    }
                //部品選択優良表示区分
                case 2:
                    {
                        switch (kind)
                        {
                            case 0:
                                {
                                    name = "全て";
                                    break;
                                }
                            case 1:
                                {
                                    name = "自社優先在庫";
                                    break;
                                }
                            case 2:
                                {
                                    name = "自社在庫";
                                    break;
                                }
                        }
                        break;
                    }
                case 3:
                    {
                        //在庫状況表示区分
                        switch (div)
                        {
                            case 0:
                                {
                                    name = "マーク";
                                    break;
                                }
                            case 1:
                                {
                                    name = "現在庫数";
                                    break;
                                }
                        }

                        break;
                    }
                case 4:
                    {
                        switch (div)
                        {
                            case 0:
                                {
                                    name = "する";
                                    break;
                                }
                            case 1:
                                {
                                    name = "しない";
                                    break;
                                }
                        }

                        break;
                    }

            }
            return name;
        }
        #endregion

    }

}
