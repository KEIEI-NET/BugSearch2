using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Threading;

using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
//using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win;
using System.Reflection;
using System.IO;
using Infragistics.Win.UltraWinToolbars;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 半黒作成メインフレーム
    /// </summary>
    /// <remarks>
    /// <br>Note       : 請求準備処理/売上締次更新の各子画面を制御するメインフレームです。</br>
    /// <br>Programer  : 30290</br>
    /// <br>Date       : 2008.09.22</br>
    /// <br>Update Note: 2009/01/26 30414 忍 幸史 障害ID:10498対応</br>
    /// <br>Update Note: 2009/01/30 30414 忍 幸史 障害ID:10741対応</br>
    /// <br>Update Note: 2009/02/26 30414 忍 幸史 障害ID:12049対応</br>
    /// <br>Update Note: 2009/02/27 30414 忍 幸史 障害ID:12043対応</br>
    /// <br>Update Note: 2009/03/02 30414 忍 幸史 障害ID:12051対応</br>
    /// <br>Update Note: 2009/03/23 30414 忍 幸史 障害ID:12532対応</br>
    /// <br>Update Note: 2009/11/17 30517 夏野 駿希 CSV元ファイルがなくてもクリア処理を行うように修正</br>
    /// <br>Update Note: 2011/09/06 李占川 連番991、Redmine#23658の対応</br>
    /// <br>Update Note: 2012/11/09 zhangy3 PM.NSのインポート時に待機モードを追加しPM7SP側の終了ファイルを監視して自動で取り込めるようにします。</br>
    /// <br>Update Note: 2012/11/28 zhangy3 Redmine #33660 コンバート改良の障害修正依頼。</br>
    /// </remarks>
    public partial class PMKHN08000UA : Form
    {
        # region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKHN08000UA()
        {
            InitializeComponent();
            if (LoginInfoAcquisition.EnterpriseCode != null)
            {
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }

            // ツールバーの設定
            this.SettingToolbar();

            uButton_DirGuide.ImageList = IconResourceManagement.ImageList16;
            uButton_DirGuide.Appearance.Image = (int)Size16_Index.STAR1;
            uBtn_DirGuide2.ImageList = IconResourceManagement.ImageList16;
            uBtn_DirGuide2.Appearance.Image = (int)Size16_Index.STAR1;
            Refresh();

            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            ConvertDataList = new ConvertList.ListDataTable();
            _ConvertProcAcs = new ConvertProcAcs();
            configData = new DataSet();

            lstTblNm.Add("SALESSLIP", "売上データ");
            lstTblNm.Add("DEPSITMAIN", "入金マスタ");
            lstTblNm.Add("STOCKSLIP", "仕入データ");
            lstTblNm.Add("PAYMENTSLP", "支払伝票マスタ");
            lstTblNm.Add("STOCKADJUST", "在庫調整データ");

            try
            {
                configData.ReadXml(ctCONFIGFILE);
                ConvertDataList.Merge(configData.Tables[0], false, MissingSchemaAction.Ignore);
                ConvertDataList.AcceptChanges();
                ConvertList.ListRow rowParent = null;
                for (int i = 0; i < ConvertDataList.Count; i++)
                {
                    if (lstInvisible.Contains(ConvertDataList[i].TableId))
                        ConvertDataList[i].Visible = false;

                    rowParent = GetParentRow(ConvertDataList[i].TableId.Replace("RF", ""));
                    //if (ConvertDataList[i].PrevResult >= ConvertDataList[i].CsvCount)
                    //{
                    //    ConvertDataList[i].Result = "コンバート済み";
                    //}
                    //else if (ConvertDataList[i].PrevResult == -1)
                    //{
                    //    ConvertDataList[i].Result = "前回コンバート失敗";
                    //    if (rowParent != null)
                    //    {
                    //        rowParent.Result = ConvertDataList[i].Result;
                    //    }
                    //}
                    //else
                    //{
                    //    if (rowParent != null)
                    //    {
                    //        rowParent.Result = string.Empty;
                    //    }
                    //}

                    // --- CHG 2009/01/30 障害ID:10741対応------------------------------------------------------>>>>>
                    //if (ConvertDataList[i].ConvKind != 2) // 実績以外は[コンバート前削除する]をデフォルトとする。
                    //{
                    //    ConvertDataList[i].TruncateFlg = true;
                    //}
                    ConvertDataList[i].TruncateFlg = true;
                    // --- CHG 2009/01/30 障害ID:10741対応------------------------------------------------------<<<<<
                }
                gridConvData.BeginUpdate();
                gridConvData.DataSource = ConvertDataList.DefaultView;
                ConvertDataList.DefaultView.RowFilter = "Visible = True";
                gridConvData.EndUpdate();

                SetEnabledStockAcPayHist();
            }
            catch
            {
                //MessageBox.Show("コンバート用設定ファイルを用意して下さい。", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                    "コンバート用設定ファイルを用意して下さい。", 0, MessageBoxButtons.OK);
                Close();
            }
            convFilter = ConvKindFilter.All;
        }
        # endregion

        # region プライベイトメンバ
        private int selectedCnt = 0;
        private SFCMN00299CA _progressForm;
        private bool cancelFlg = false;
        private bool isRemoteOnProcess = false;
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        private DataSet configData;
        private ConvertList.ListDataTable ConvertDataList;
        private ConvertProcAcs _ConvertProcAcs;

        // --- ADD 2011/09/06---------->>>>>
        private static readonly string PROGRAM_ID = "PMKHN08000U";
        private static readonly string PROGRAM_NAME = "PM7⇒PM.NSコンバート";
        // --- ADD 2011/09/06----------<<<<<
        //-----Add Start 2012/11/09 zhangy3 ----->>>>>
        private int wait_SelModelType = -1;
        private List<string> wait_FileLst = null;
        private bool IsStartWaitFlg = false;
        //-----Add End   2012/11/09 zhangy3 -----<<<<<
        private Dictionary<List<string>, bool> InfoShowList = new Dictionary<List<string>, bool>();//Add  2012/11/28 zhangy3

        private enum ConvKindFilter
        {
            All = 4,
            Master = 0,
            Data = 1,
            Jisseki = 2
        }
        private ConvKindFilter convFilter;
        # endregion

        # region 定数宣言
        /// <summary>PGID</summary>
        private const string ctPGID = "PMKHN08000U";
        private const string ctCONFIGFILE = "Conv.config";
        /// <summary>非表示項目リスト</summary>
        private List<string> lstInvisible = new List<string>(new string[]{"SALESDETAILRF",
                                                "SALESHISTORYRF",
                                                "SALESHISTDTLRF",
                                                "ACCEPTODRCARRF",
                                                "CNVCARPARTSRF",
                                                "DEPSITDTLRF",
                                                "STOCKDETAILRF",
                                                "STOCKSLIPHISTRF",
                                                "STOCKSLHISTDTLRF",
                                                "PAYMENTDTLRF",
                                                "STOCKADJUSTDTLRF"});

        /// <summary>ヘッダ・明細同時選択制御用リスト</summary>
        private List<string> lstHeaderTbl = new List<string>(new string[]{"SALESSLIPRF",
                                                "DEPSITMAINRF",
                                                "STOCKSLIPRF",
                                                "PAYMENTSLPRF",
                                                "STOCKADJUSTRF"});

        /// <summary>在庫受払処理用チェックリスト</summary>
        private List<string> lstSAPHistInfoChk = new List<string>(new string[]{"SALESSLIPRF",
                                                "SALESDETAILRF",
                                                "SALESHISTORYRF",
                                                "SALESHISTDTLRF",
                                                "STOCKSLIPRF",
                                                "STOCKDETAILRF",
                                                "STOCKSLIPHISTRF",
                                                "STOCKSLHISTDTLRF",
                                                "STOCKMOVERF",
                                                "STOCKADJUSTRF",
                                                "STOCKADJUSTDTLRF" });

        private List<string> listChkExcpt = new List<string>(
                new string[] {
                    "USERGDBDU",      // ユーザーガイド(銀行の支店コードによる重複するケース）
                    "PARTSPOSCODEU",  // 部位（BLコードが例外的に重複するケース）
                    "JOINPARTSU",     // 結合マスタ(ユーザー登録）（表示順位違いで結合先品が重複するケース）
                    "GOODSSET"        // 商品セットマスタ（表示順位違いでセット子が重複するケース）
                });

        private List<string> listLastTbl = new List<string>(
                new string[] {
                    "CNVCARPARTS",      // 車輌部品データ
                    "DEPSITDTL",        // 入金明細データ
                    "STOCKSLHISTDTL",   // 仕入履歴明細データ
                    "PAYMENTDTL",       // 支払明細データ
                    "STOCKADJUSTDTL"    // 在庫調整明細データ
                });

        private string[] lstSAP = new string[] { 
                "売上データ",
                "売上履歴データ",
                "仕入データ",
                "仕入履歴データ",
                "在庫移動データ",
                "在庫調整データ",
            };

        private Dictionary<string, string> lstTblNm = new Dictionary<string, string>();
        # endregion

        # region コントロールイベントハンドラ

        /// <summary>
        /// フォームClose前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームが終了する前に発生します。</br>
        /// <br>Programer  : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        /// </remarks>
        private void PMKHN08000UA_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ツールバーがクリックされた時に発動します。</br>
        /// <br>Programer  : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br>Update Note: PM.NSのインポート時に待機モードを追加しPM7SP側の終了ファイルを監視して自動で取り込めるようにします。</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012.11.09</br>
        /// </remarks>
        private void ToolbarsManager_Main_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    //--------------------------------------------------------------
                    // 終了ボタン
                    //--------------------------------------------------------------
                    // メイン画面のクローズ
                    this.Close();
                    break;

                case "Button_Convert":
                    DialogResult ret = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, Text,
                                "実行しますか？", 0, MessageBoxButtons.OKCancel);
                    if (ret == DialogResult.OK && ValidateInput())
                    {
                        SetCounter();//Add 2012/11/28 zhangy3
                        ConvertData();
                    }
                    break;

                case "Button_Cancel":
                    txtDir.Clear();
                    txtLogDir.Clear();
                    SetDeploy(false);
                    break;

                case "Btn_StockAcPay":
                    // 20081128 ボタン操作はなし
                    //try
                    //{
                    //    _ConvertProcAcs.BeginTransaction();
                    //    int status = _ConvertProcAcs.SetStockAcPayHist(0);
                    //    //status = _ConvertProcAcs.SetStockAcPayHist(1);
                    //    //status = _ConvertProcAcs.SetStockAcPayHist(2);
                    //    //status = _ConvertProcAcs.SetStockAcPayHist(3);
                    //    //status = _ConvertProcAcs.SetStockAcPayHist(4);
                    //    //status = _ConvertProcAcs.SetStockAcPayHist(5);
                    //    if (status == 0)
                    //    {
                    //        _ConvertProcAcs.EndTransaction(true);
                    //        //MessageBox.Show("OK");
                    //        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text,
                    //            "受払処理を終了しました。", 0, MessageBoxButtons.OK);
                    //    }
                    //    else
                    //    {
                    //        _ConvertProcAcs.EndTransaction(false);
                    //        //MessageBox.Show("FAILED");
                    //        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                    //            "受払処理に失敗しました。", 0, MessageBoxButtons.OK);
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    if (!(ex is RemotingException))
                    //    {
                    //        _ConvertProcAcs.EndTransaction(false);
                    //        //MessageBox.Show("FAILED");
                    //        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                    //            "受払処理に失敗しました。", 0, MessageBoxButtons.OK);
                    //    }
                    //}
                    break;
                //-----Add Start 2012/11/09 zhangy3 ----->>>>>
                case "Button_Wait":
                    IsStartWaitFlg = true;
                    if (ValidateInput())
                    {
                        IsStartWaitFlg = false;
                        PMKHN08000UB wait = new PMKHN08000UB(this.txtDir.Text, GetSelectedRows());
                        if (DialogResult.OK == wait.ShowDialog())
                        {
                            
                            this.wait_FileLst = new List<string>();
                            if (wait.FileLst != null)
                            {
                                this.wait_FileLst.AddRange(wait.FileLst);
                            }
                            this.wait_SelModelType = wait.SelModelType;
                            if(ValidateInput())
                            //-----Add Start 2012/11/28 zhangy3 ----->>>>>
                            {
                                SetCounter();
                                ConvertData();
                            }
                            //-----Add End  2012/11/28 zhangy3 -----<<<<<
                                //ConvertData();//Del 2012/11/28 zhangy3
                            ClearDataFromWait();
                        }
                    }
                    break;
                //-----Add End  2012/11/09 zhangy3 -----<<<<<

            }

        }
        //-----Add Start 2012/11/09 zhangy3 ----->>>>>
        /// <summary>
        /// 待機を判断する
        /// </summary>
        /// <returns>FLG</returns>
        /// <remarks>
        /// <br>Note        : 待機の状態を判断する。</br>
        /// <br>Programmer  : zhangy3</br>
        /// <br>Date        : 2012/11/09</br>
        /// </remarks>
        private bool IsFromWait()
        {
            //インポートファイルのモジュッルを判断する[(0,1)はインポートファイルのモジュッル]
            if (wait_SelModelType == -1)
                return false;
            else
                return true;
        }

        /// <summary>
        ///　コンバート対象の取得する
        /// </summary>
        /// <returns>FLG</returns>
        /// <remarks>
        /// <br>Note        : コンバート対象の取得する。</br>
        /// <br>Programmer  : zhangy3</br>
        /// <br>Date        : 2012/11/09</br>
        /// </remarks>
        private bool GetSelectedRows()
        {
            string query = "Deploy = '●' ";
            if (convFilter != ConvKindFilter.All) // フィルタリングされている場合はそのデータのみコンバートする
            {
                query += "AND " + ConvertDataList.DefaultView.RowFilter;
            }
            // コンバート対象のテーブル検索
            ConvertList.ListRow[] rows = (ConvertList.ListRow[])ConvertDataList.Select(query);
            if (rows.Length > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 待機の選択状態を削除する
        /// </summary>
        /// <remarks>
        /// <br>Note        : 待機の選択状態を削除する。</br>
        /// <br>Programmer  : zhangy3</br>
        /// <br>Date        : 2012/11/09</br>
        /// </remarks>
        private void ClearDataFromWait()
        {
            this.wait_SelModelType = -1;
            this.wait_FileLst = null;
            ClearStatus();//Add 2012/11/28 zhangy3 
        }

        /// <summary>
        /// 終了ファイルによってコンバートの対象を選択する
        /// </summary>
        /// <returns>コンバートの対象リスト</returns>
        /// <br>Note        : 終了ファイルによってコンバートの対象を選択する。</br>
        /// <br>Programmer  : zhangy3</br>
        /// <br>Date        : 2012/11/09</br>
        /// </remarks>
        private ConvertList.ListRow[] GetRows()
        {
            // ------ Add Start 2012/11/28 zhangy3 ------>>>>> 
            if (InfoShowList.Count==0)
            {
                InfoShowList.Add(new List<string>(new string[] { "SALESSLIP", "SALESDETAIL", "SALESHISTORY", "SALESHISTDTL", "ACCEPTODRCAR", "CNVCARPARTS" }), false);
                InfoShowList.Add(new List<string>(new string[] { "DEPSITMAIN", "DEPSITDTL" }), false);
                InfoShowList.Add(new List<string>(new string[] { "STOCKSLIP", "STOCKDETAIL", "STOCKSLIPHIST", "STOCKSLHISTDTL" }), false);
                InfoShowList.Add(new List<string>(new string[] { "PAYMENTSLP", "PAYMENTDTL" }), false);
                InfoShowList.Add(new List<string>(new string[] { "STOCKADJUST", "STOCKADJUSTDTL" }), false);
            }
            // ------ Add End   2012/11/28 zhangy3 ------<<<<<
            List<ConvertList.ListRow> rows = new List<ConvertList.ListRow>();
            string tmp = string.Empty;
            Regex reg = null;
            Match mat = null;
            bool flg = false;
            foreach (ConvertList.ListRow row in ConvertDataList)
            {
                flg = false;                
                tmp = row.TableId.Trim().Replace("RF", "").ToUpper();//Add 2012/11/28 zhangy3 
                if (wait_FileLst.Exists(delegate(string x)
                {
                    x = x.ToUpper();
                    //PMNS_**_00.CSV
                    reg = new Regex(@"^PMNS_([a-zA-Z]+)(_\d{1,2})?.CSV$");
                    if (reg.IsMatch(x))
                    {
                        mat = reg.Match(x);
                        //tmp = row.TableId.Trim().Replace("RF", "").ToUpper();//Del 2012/11/28 zhangy3 
                        if (mat.Groups[1].Value.ToUpper().Equals(tmp))
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                  
                }))
                {
                    flg = true;
                    row.Deploy = "●";
                    rows.Add(row);
                    // ------ Add Start 2012/11/28 zhangy3 ------>>>>>
                    SetInfoShowDic(tmp);
                    SetRowSelectByInfoShow(tmp);
                    // ------ Add End   2012/11/28 zhangy3 ------<<<<<
                }
                // ------ Add Start 2012/11/28 zhangy3 ------>>>>>
                else
                {
                    if (!GetCurStatusFromInfoShowDic(tmp))
                    {
                        row.Deploy = "";
                    }
                }
                // ------ Add End  2012/11/28 zhangy3 ------<<<<<

                /* ------ Del Start 2012/11/28 zhangy3 ------>>>>>
                if (mat != null && flg == true)
                {
                    switch (mat.Groups[1].Value.ToUpper())
                    {
                        case "SALESSLIP":
                        case "SALESDETAIL":
                        case "SALESHISTORY":
                        case "SALESHISTDTL":
                        case "ACCEPTODRCAR":
                        case "CNVCARPARTS":
                            {
                                ConvertDataList.FindByTableId("SALESSLIPRF").Deploy = "●"; // 売上データ
                                ConvertDataList.FindByTableId("SALESDETAILRF").Deploy = "●"; // 売上明細データ
                                ConvertDataList.FindByTableId("SALESHISTORYRF").Deploy = "●"; // 売上履歴データ
                                ConvertDataList.FindByTableId("SALESHISTDTLRF").Deploy = "●"; // 売上履歴明細データ
                                ConvertDataList.FindByTableId("ACCEPTODRCARRF").Deploy = "●"; // 受注マスタ（車両）
                                ConvertDataList.FindByTableId("CNVCARPARTSRF").Deploy = "●"; // 車輌部品データ（コンバート）
                            }
                            break;
                        case "DEPSITMAIN":
                        case "DEPSITDTL":
                            {
                                ConvertDataList.FindByTableId("DEPSITMAINRF").Deploy = "●"; // 入金データ
                                ConvertDataList.FindByTableId("DEPSITDTLRF").Deploy = "●"; // 入金明細データ
                            }
                            break;
                        case "STOCKSLIP":
                        case "STOCKDETAIL":
                        case "STOCKSLIPHIST":
                        case "STOCKSLHISTDTL":
                            {
                                ConvertDataList.FindByTableId("STOCKSLIPRF").Deploy = "●"; // 仕入データ
                                ConvertDataList.FindByTableId("STOCKDETAILRF").Deploy = "●"; // 仕入明細データ
                                ConvertDataList.FindByTableId("STOCKSLIPHISTRF").Deploy = "●"; // 仕入履歴データ
                                ConvertDataList.FindByTableId("STOCKSLHISTDTLRF").Deploy = "●"; // 仕入履歴明細データ
                            }
                            break;
                        case "PAYMENTSLP":
                        case "PAYMENTDTL":
                            {
                                ConvertDataList.FindByTableId("PAYMENTSLPRF").Deploy = "●"; // 支払データ
                                ConvertDataList.FindByTableId("PAYMENTDTLRF").Deploy = "●"; // 支払明細データ
                            }
                            break;
                        case "STOCKADJUST":
                        case "STOCKADJUSTDTL":
                            {
                                ConvertDataList.FindByTableId("STOCKADJUSTRF").Deploy = "●"; // 在庫調整データ
                                ConvertDataList.FindByTableId("STOCKADJUSTDTLRF").Deploy = "●"; // 在庫調整明細データ
                            }
                            break;
                    }
                }                
                ------ Del End  2012/11/28 zhangy3 ------<<<<<*/
                
            }
            SetCounter();
            return rows.ToArray();
        }
        //-----Add End  2012/11/09 zhangy3 -----<<<<<
        // ------ Add Start 2012/11/28 zhangy3 ------>>>>>
        /// <summary>
        /// リストの状態によって画面の項を設定する
        /// </summary>
        /// <param name="tmp">テッブル名</param>
        /// <remarks>
        /// <br>Note        : リストの状態によって画面の項を設定する。</br>
        /// <br>Programmer  : zhangy3</br>
        /// <br>Date        : 2012/11/28</br>
        /// </remarks>
        private void SetRowSelectByInfoShow(string tmp)
        {
            foreach (List<string> key in InfoShowList.Keys)
            {
                if (key.Exists(delegate(string x)
                {
                    if (x.Equals(tmp))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }))
                {
                    key.ForEach(delegate(string x)
                    {

                        ConvertDataList.FindByTableId(x + "RF").Deploy = "●";
                    });
                }
            }
        }

        /// <summary>
        /// ファイルの内容によってリストの状態を設定する
        /// </summary>
        /// <param name="tmp">ファイルの内容</param>
        /// <remarks>
        /// <br>Note        : ファイルの内容によってリストの状態を設定する。</br>
        /// <br>Programmer  : zhangy3</br>
        /// <br>Date        : 2012/11/28</br>
        /// </remarks>
        private void SetInfoShowDic(string tmp)
        {
            Dictionary<List<string>, bool> dicTmp = new Dictionary<List<string>, bool>();
            foreach (List<string> key in InfoShowList.Keys)
            {
                if (key.Exists(delegate(string x)
                {
                    if (x.Equals(tmp))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }))
                {
                    dicTmp.Add(key, true);
                }
                else
                {
                    dicTmp.Add(key, InfoShowList[key]);
                }
            }
            InfoShowList = dicTmp;
        }

        /// <summary>
        /// リストの状態を取得する
        /// </summary>
        /// <param name="tmp">ファイルの内容</param>
        /// <remarks>
        /// <br>Note        : ファイルの内容によってリストの状態を設定する。</br>
        /// <br>Programmer  : zhangy3</br>
        /// <br>Date        : 2012/11/28</br>
        /// </remarks>
        private bool GetCurStatusFromInfoShowDic(string tmp)
        {
            foreach (List<string> key in InfoShowList.Keys)
            {
                if (key.Exists(delegate(string x)
                {
                    if (x.Equals(tmp))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }))
                {
                    return InfoShowList[key];
                }
            }
            return false;
        }

        /// <summary>
        /// リストの状態をクリアする
        /// </summary>
        /// <remarks>
        /// <br>Note        : ファイルの内容によってリストの状態を設定する。</br>
        /// <br>Programmer  : zhangy3</br>
        /// <br>Date        : 2012/11/28</br>
        /// </remarks>
        private void ClearStatus()
        {
            Dictionary<List<string>, bool> dicTmp = new Dictionary<List<string>, bool>();
            foreach (List<string> key in InfoShowList.Keys)
            {
                dicTmp.Add(key, false);
            }
            InfoShowList = dicTmp;
        }
        // ------ Add End   2012/11/28 zhangy3 ------<<<<<
       
        /// <summary>
        /// 入力バリデーション処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: PM.NSのインポート時に待機モードを追加しPM7SP側の終了ファイルを監視して自動で取り込めるようにします。</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012.11.09</br>
        /// </remarks>
        private bool ValidateInput()
        {
            #region [ バリデーション処理 ]
            if (txtDir.Text == string.Empty)
            {
                //MessageBox.Show("コンバート元格納フォルダを入力して下さい。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                                "コンバート元格納フォルダを入力して下さい。", 0, MessageBoxButtons.OK);
                txtDir.Focus();
                return false;
            }
            if (Directory.Exists(txtDir.Text) == false)
            {
                //MessageBox.Show("ディレクトリが存在しません。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                                "指定のｺﾝﾊﾞｰﾄ元格納ﾌｫﾙﾀﾞは存在しません。", 0, MessageBoxButtons.OK);
                return false;
            }
            
            if (txtLogDir.Text == string.Empty)
            {
                txtLogDir.Text = Path.Combine(txtDir.Text, "ConvertErrorLog");
            }
            else
            {
                if (txtDir.Text == txtLogDir.Text)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                                    "エラーログ格納ﾌｫﾙﾀﾞはコンバート元CSV格納ﾌｫﾙﾀﾞと違うフォルダにして下さい。", 0, MessageBoxButtons.OK);
                    return false;
                }
                if (txtLogDir.Text != Path.Combine(txtDir.Text, "ConvertErrorLog")
                    && Directory.Exists(txtLogDir.Text) == false)
                {
                    DialogResult ret = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, Text,
                                    "指定のｴﾗｰﾛｸﾞ格納ﾌｫﾙﾀﾞは存在しません。\r\nﾌｫﾙﾀﾞを作成しますか？", 0, MessageBoxButtons.YesNo);
                    if (ret == DialogResult.No)
                    {
                        txtLogDir.Select();
                        return false;
                    }
                    try
                    {
                        Directory.CreateDirectory(txtLogDir.Text);
                    }
                    catch
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                                    "指定のﾌｫﾙﾀﾞの作成に失敗しました。", 0, MessageBoxButtons.OK);
                        return false;
                    }
                }
            }

            //-----Add Start 2012/11/09 zhangy3 ----->>>>>
            //待機初期、コンバート対象をチェックしない
            if (IsStartWaitFlg)
                return true;
            //-----Add End   2012/11/09 zhangy3 -----<<<<<
            string query = "Deploy = '●' ";
            if (convFilter != ConvKindFilter.All) // フィルタリングされている場合はそのデータのみコンバートする
            {
                query += "AND " + ConvertDataList.DefaultView.RowFilter;
            }
            // コンバート対象のテーブル検索
            ConvertList.ListRow[] rows = (ConvertList.ListRow[])ConvertDataList.Select(query);

            //-----Add Start 2012/11/09 zhangy3 ----->>>>>
            //待機時、このチェックの必要がない
            if (!IsFromWait())
            {
            //-----Add End   2012/11/09 zhangy3 -----<<<<<
            if (rows.Length == 0)
            {
                //MessageBox.Show("コンバート対象を選んで下さい。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                                "コンバート対象を選んで下さい。", 0, MessageBoxButtons.OK);
                return false;
            }
            }//Add 2012/11/09 zhangy3

            if ((rows.Length == 1) && (rows[0].TableId == "STOCKACPAYHISTRF"))
            {
            }
            else
            {
                if (Directory.GetFiles(txtDir.Text, "*.csv", SearchOption.TopDirectoryOnly).Length == 0)
                {
                    // 2009/11/17 Add >>>
                    bool truncateFlg = false;
                    for (int i = 0; i < rows.Length; i++)
                    {
                        //-----Add Start 2012/11/09 zhangy3 ----->>>>>
                        //ファイルがない時、コンバート対象を削除する
                        if (IsFromWait())
                            rows[i].Deploy = "";
                        else
                        {
                            if (rows[i].TruncateFlg == true)
                            {
                                // 1つでも削除対象があるなら削除処理を行うか確認する
                                truncateFlg = true;
                                break;
                            }
                        }
                        //-----Add End   2012/11/09 zhangy3 -----<<<<<
                        /*-----Del Start 2012/11/09 zhangy3 ----->>>>>
                        if (rows[i].TruncateFlg == true)
                        {
                            // 1つでも削除対象があるなら削除処理を行うか確認する
                            truncateFlg = true;
                            break;
                        }
                         *-----Del Start 2012/11/09 zhangy3 ----->>>>> */
                    }
                    //-----Add Start 2012/11/09 zhangy3 ----->>>>>
                    //処理がない
                    if (IsFromWait())
                        return false;
                    //-----Add End   2012/11/09 zhangy3 -----<<<<<
                    if (truncateFlg == false)
                    {
                        // 2009/11/17 Add <<<
                        //MessageBox.Show("ディレクトリ内にコンバート元ファイルが存在しません。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                                        "ディレクトリ内にコンバート元ファイルが存在しません。", 0, MessageBoxButtons.OK);
                        return false;
                        // 2009/11/17 Add >>>
                    }
                    else
                    {
                        DialogResult resurt = DialogResult.OK;
                        resurt = TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, Text,
                                        "ディレクトリ内にコンバート元ファイルが存在しません。\n削除対象のデータを削除します。よろしいですか？", 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                        if (resurt == DialogResult.No)
                        {
                            return false;
                        }
                    }
                    // 2009/11/17 Add <<<

                }
            }

            //-----Add Start 2012/11/09 zhangy3 ----->>>>>
            //インポートファイルのモジュッルは1時、コンバート対象を設定する
            if (IsFromWait() && wait_SelModelType == 1)
            {
                rows = GetRows();
                if (rows.Length == 0)
                    return false;
            }
            //-----Add End   2012/11/09 zhangy3 -----<<<<<
            // --- ADD 2009/03/23 障害ID:12532対応------------------------------------------------------>>>>>
            for (int i = 0; i < rows.Length; i++)
            {
                if ((rows[i].TableId == "STOCKMOVERF") || (rows[i].TableId == "STOCKACPAYHISTRF"))
                {
                    string[] files = Directory.GetFiles(txtDir.Text, "PMNS_STOCKMOVE*.csv", SearchOption.TopDirectoryOnly);

                    if (files.Length > 1)
                    {
                        /* -----Del Start 2012/11/09 zhangy3 ----->>>>>
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                                "対象フォルダ内に在庫移動データが複数存在します。" + "\r\n" + 
                                "対象フォルダを空にして、PM7で作成したCSVファイルを再度コピーして下さい。", 0, MessageBoxButtons.OK);
                        return false;
                         * -----Del End   2012/11/09 zhangy3 -----<<<<<*/
                        //-----Add Start 2012/11/09 zhangy3 ----->>>>>
                        //待機時、在庫移動データの対象を選択しないにする
                        if (IsFromWait())
                        {
                            rows[i].Deploy = "";
                        }
                        else
                        {
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                                "対象フォルダ内に在庫移動データが複数存在します。" + "\r\n" +
                                "対象フォルダを空にして、PM7で作成したCSVファイルを再度コピーして下さい。", 0, MessageBoxButtons.OK);
                            return false;
                        }
                        //-----Add End   2012/11/09 zhangy3 -----<<<<<
                    }
                }
            }
            // --- ADD 2009/03/23 障害ID:12532対応------------------------------------------------------<<<<<

            return true;
            #endregion
        }

        /// <summary>
        /// コンバート処理
        /// </summary>
        private void ConvertData()
        {
            // --- ADD 2011/09/06---------->>>>>
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "コンバート処理開始", "");
            // --- ADD 2011/09/06----------<<<<<

            bool noErrorFlg = true;
            string query = "Deploy = '●' ";
            string table = string.Empty;
            ConvertList.ListRow rowParent = null;
            ConvertDataList.AcceptChanges();
            if (convFilter != ConvKindFilter.All) // フィルタリングされている場合はそのデータのみコンバートする
            {
                query = string.Format("{0} AND ConvKind = {1}", query, (int)convFilter);
            }
            // コンバート対象のテーブル検索
            ConvertList.ListRow[] rows = (ConvertList.ListRow[])ConvertDataList.Select(query);
            if (rows.Length == 0)
                return;

            cancelFlg = false;
            _progressForm = new SFCMN00299CA();
            _progressForm.DispCancelButton = true;
            _progressForm.CancelButtonClick += new EventHandler(this.CancelButtonClick);

            _progressForm.Title = "コンバート中";
            _progressForm.Message = "只今、コンバート中です．．．";
            FileStream fs = null;
            try
            {
                for (int ind = 0; ind < rows.Length; ind++)
                {
                    rows[ind].ReadDataCnt = 0; // リードカウンタクリア
                    rows[ind].WriteDataCnt = 0; // ライトカウンタクリア
                    rows[ind].Result = string.Empty; // 処理結果クリア
                    rows[ind].StartTm = string.Empty;
                    rows[ind].EndTm = string.Empty;
                }

                _progressForm.Show(this);
                // 選択されたテーブル分コンバート処理を行う。
                int i = 0;
                int status = 0;
                for (int procCnt = 0; i < rows.Length; i++)
                {
                    // --- ADD 2011/09/06---------->>>>>
                    operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog,
                        PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, rows[i].TableNm + "処理開始", "");
                    // --- ADD 2011/09/06----------<<<<<
                    try
                    {
                        ReDrawGrid();
                        lblCnt.Text = string.Format("処理件数：{0} ／ 選択件数：{1}", procCnt, selectedCnt);
                        Refresh();
                        if (rows[i].TableId == "STOCKACPAYHISTRF") // 在庫受払のコンバートか
                        {
                            // --- CHG 2009/01/26 障害ID:10498対応------------------------------------------------------>>>>>
                            //StockAcPayHistInfoProc(rows[i]);
                            status = StockAcPayHistInfoProc(rows[i]);
                            if (status == 1)
                            {
                                procCnt++;
                                lblCnt.Text = string.Format("処理件数：{0} ／ 選択件数：{1}", procCnt, selectedCnt);
                            }
                            // --- CHG 2009/01/26 障害ID:10498対応------------------------------------------------------<<<<<
                        }
                        else // 一般のCSVからのコンバートか
                        {
                            ArrayList lstData = null;
                            int readCnt = 0;
                            int updateCnt = 0;
                            table = rows[i].TableId.Replace("RF", "");
                            // --- CHG 2009/02/27 障害ID:12043対応------------------------------------------------------>>>>>
                            //string pattern = string.Format("PMNS_{0}*.csv", table);
                            string pattern;
                            if (rows[i].TableId == "ACCEPTODRRF")
                            {
                                pattern = string.Format("PMNS_{0}_*.csv", table);
                            }
                            else
                            {
                                pattern = string.Format("PMNS_{0}*.csv", table);
                            }
                            // --- CHG 2009/02/27 障害ID:12043対応------------------------------------------------------<<<<<
                            string[] files = Directory.GetFiles(txtDir.Text, pattern, SearchOption.TopDirectoryOnly);
                            //string errLogFolder = Path.Combine(txtDir.Text, "ConvertErrorLog");
                            string errMsg = string.Empty;

                            rowParent = GetParentRow(table);
                            if (rowParent != null && noErrorFlg == false) // 纏め処理中エラーがあった場合次の子処理はしない
                            {
                                continue;
                            }

                            if (cancelFlg)
                            {
                                cancelFlg = false;
                                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                break;
                            }
                            if (files.Length > 0)
                            {
                                //rows[i].ReadDataCnt = 0; // リードカウンタクリア
                                //rows[i].WriteDataCnt = 0; // ライトカウンタクリア
                                //rows[i].Result = string.Empty; // 処理結果クリア
                                //rows[i].EndTm = string.Empty;
                                rows[i].StartTm = DateTime.Now.ToString("HH:mm:ss");
                                Refresh();
                                if (lstTblNm.ContainsKey(table)) // 纏め処理の先頭テーブル
                                {
                                    noErrorFlg = true;
                                }
                                status = _ConvertProcAcs.BeginTransaction(); // テーブル毎のトランザクション
                                if (status != 0)
                                {
                                    // --- ADD 2011/09/06---------->>>>>
                                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog,
                                        PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, status, "トランザクション開始に失敗しました。", string.Empty);
                                    // --- ADD 2011/09/06----------<<<<<
                                    rows[i].Result = "展開失敗[トランザクション開始に失敗しました。]";
                                    rows[i].PrevResult = -1;
                                    if (rowParent != null)
                                    {
                                        rowParent.Result = rows[i].Result;
                                        rowParent.PrevResult = rows[i].PrevResult;
                                        noErrorFlg = false;
                                    }
                                    else if (lstTblNm.ContainsKey(table)) // 纏め処理の先頭テーブル
                                    {
                                        noErrorFlg = false;
                                    }
                                    break;
                                    //_ConvertProcAcs.EndTransaction(false);
                                }
                                int j = 0;
                                #region [ テーブルのファイル毎のコンバート処理 ]
                                for (j = 0; j < files.Length; j++)
                                {
                                    #region [ ファイル読み込み ]
                                    // --- ADD 2011/09/06---------->>>>>
                                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog,
                                        PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "ファイル読み込み開始", string.Empty);
                                    // --- ADD 2011/09/06----------<<<<<
                                    if (files[j][files[j].ToUpper().IndexOf(table) + table.Length] != '.'
                                        && files[j][files[j].ToUpper().IndexOf(table) + table.Length] != '_')
                                        continue;
                                    lstData = new ArrayList();
                                    fs = new FileStream(files[j], FileMode.Open, FileAccess.Read, FileShare.Read);
                                    StreamReader sr = new StreamReader(fs, Encoding.Default);
                                    int cnt = 0;
                                    bool truncateFlg = rows[i].TruncateFlg;
                                    if (j > 0) // CSVファイルが複数ある場合は2個目からは削除しないため。
                                        truncateFlg = false;
                                    do
                                    {
                                        string data = sr.ReadLine();
                                        if (string.IsNullOrEmpty(data) == false)
                                            lstData.Add(data);
                                        if (string.IsNullOrEmpty(data) == false && data.Length * lstData.Count >= 50000000) // 読み込んだ文字が50MBを超えると一旦コンバート処理を行って、読み込みを続く。
                                        {
                                            readCnt += lstData.Count;
                                            rows[i].ReadDataCnt = readCnt;
                                            Thread.Sleep(0);
                                            gridConvData.Refresh();
                                            Refresh();

                                            isRemoteOnProcess = true;
                                            status = _ConvertProcAcs.DeployConvertData(rows[i].TableId, truncateFlg, ref lstData, out cnt, out errMsg);
                                            truncateFlg = false; // 一回実行してからは削除フラグをリセットしておく。
                                            isRemoteOnProcess = false;
                                            if (lstData.Count > 0)
                                            {
                                                string errLogFileNm = files[j].Substring(files[j].LastIndexOf('\\') + 1);
                                                errLogFileNm = errLogFileNm.Insert(errLogFileNm.IndexOf('.'), "_FailedData");
                                                WriteErrorLog(lstData, errLogFileNm);
                                                errMsg = string.Format("エラーログ{0}を確認して下さい。", errLogFileNm);
                                            }
                                            if (cancelFlg)
                                            {
                                                cancelFlg = false;
                                                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                                break;
                                            }

                                            updateCnt += cnt;
                                            rows[i].WriteDataCnt = updateCnt;
                                            lstData.Clear();
                                            lstData = new ArrayList();
                                            if (status != 0)
                                                break;

                                        }
                                    } while (sr.EndOfStream == false);
                                    fs.Close();

                                    if (cancelFlg)
                                    {
                                        cancelFlg = false;
                                        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                        break;
                                    }

                                    readCnt += lstData.Count;
                                    rows[i].ReadDataCnt = readCnt;
                                    Refresh();
                                    // --- ADD 2011/09/06---------->>>>>
                                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, 
                                        PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "ファイル読み込み終了", string.Empty);
                                    // --- ADD 2011/09/06----------<<<<<
                                    #endregion

                                    // 2009/11/17 >>>
                                    // 空のファイルもリモートに渡して削除処理を行う
                                    if (lstData.Count != 0 || j == 0)
                                    // 2009/11/17 <<<
                                    {
                                        isRemoteOnProcess = true;
                                        status = _ConvertProcAcs.DeployConvertData(rows[i].TableId, truncateFlg, ref lstData, out cnt, out errMsg);
                                        isRemoteOnProcess = false;
                                        if (lstData.Count > 0)
                                        {
                                            string errLogFileNm = files[j].Substring(files[j].LastIndexOf('\\') + 1);
                                            errLogFileNm = errLogFileNm.Insert(errLogFileNm.IndexOf('.'), "_FailedData");
                                            WriteErrorLog(lstData, errLogFileNm);
                                            errMsg = string.Format("エラーログ{0}を確認して下さい。", errLogFileNm);
                                        }
                                        //if (cancelFlg)
                                        //{
                                        //    cancelFlg = false;
                                        //    status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                        //    break;
                                        //}
                                    }
                                    updateCnt += cnt;
                                    rows[i].WriteDataCnt = updateCnt;
                                    if (status != 0)
                                        break;
                                }
                                #endregion
                                rows[i].EndTm = DateTime.Now.ToString("HH:mm:ss");

                                if (rowParent != null)
                                {
                                    rowParent.EndTm = rows[i].EndTm;
                                }
                                Refresh();
                                rows[i].WriteDataCnt = updateCnt;
                                if (status == 0)
                                {
                                    // --- ADD 2011/09/06---------->>>>>
                                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, 
                                        PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "展開正常終了しました。", string.Empty);
                                    // --- ADD 2011/09/06----------<<<<<

                                    if (lstTblNm.ContainsKey(table)) // 纏め処理の先頭テーブル
                                    {
                                        rows[i].Result = string.Format("OK[{0}]", lstTblNm[table]);
                                    }
                                    else
                                    {
                                        rows[i].Result = "OK";
                                    }

                                    if (listChkExcpt.Contains(table) && errMsg != string.Empty)
                                    {
                                        rows[i].Result += "[" + errMsg + "]";
                                    }

                                    if (rows[i].TruncateFlg) // 削除してからのコンバートの場合
                                    {
                                        // --- CHG 2009/03/23 障害ID:12532対応------------------------------------------------------>>>>>
                                        if (rows[i].TableId == "STOCKMOVERF")
                                        {
                                            if (files.Length > 0)
                                            {
                                                // どちらのCSVからコンバートしたか判断できないため、強制的に値をセット
                                                if (files[0] == txtDir.Text + "\\" + "PMNS_StockMove_Normal.CSV")
                                                {
                                                    rows[i].PrevResult = 10;
                                                }
                                                else
                                                {
                                                    rows[i].PrevResult = 100;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            rows[i].PrevResult = j; // 前回実行カウンタを上書きする
                                        }
                                        // --- CHG 2009/03/23 障害ID:12532対応------------------------------------------------------<<<<<
                                    }
                                    else
                                    {
                                        // --- CHG 2009/03/23 障害ID:12532対応------------------------------------------------------>>>>>
                                        if (rows[i].TableId == "STOCKMOVERF")
                                        {
                                            if (files.Length > 0)
                                            {
                                                // どちらのCSVからコンバートしたか判断できないため、強制的に値をセット
                                                if (files[0] == txtDir.Text + "\\" + "PMNS_StockMove_Normal.CSV")
                                                {
                                                    rows[i].PrevResult = 10;
                                                }
                                                else
                                                {
                                                    rows[i].PrevResult = 100;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            rows[i].PrevResult += j; // 前回実行カウンタに今回のカウンタを足す。
                                        }
                                        // --- CHG 2009/03/23 障害ID:12532対応------------------------------------------------------<<<<<
                                    }

                                    if (rowParent != null && noErrorFlg)
                                    {
                                        //if (table == "CNVCARPARTS" || table == "DEPSITDTL" || table == "STOCKSLHISTDTL"
                                        //     || table == "PAYMENTDTL" || table == "STOCKADJUSTDTL")
                                        if (listLastTbl.Contains(table))
                                        {
                                            rowParent.Result = "OK";
                                        }
                                        else
                                        {
                                            rowParent.Result = string.Format("OK[{0}]", rows[i].TableNm); //rows[i].Result;
                                        }
                                        rowParent.ReadDataCnt += rows[i].ReadDataCnt;
                                        rowParent.WriteDataCnt += rows[i].WriteDataCnt;
                                    }
                                    rows[i].Deploy = string.Empty; // コンバートデータ展開正常終了時　選択状態解除
                                    _ConvertProcAcs.EndTransaction(true);
                                    if (rowParent == null && lstTblNm.ContainsKey(table) == false)
                                        procCnt++;
                                    else if (rowParent != null && listLastTbl.Contains(table))
                                        procCnt++;
                                    lblCnt.Text = string.Format("処理件数：{0} ／ 選択件数：{1}", procCnt, selectedCnt);
                                    Refresh();
                                }
                                else if (status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                                {
                                    // --- ADD 2011/09/06---------->>>>>
                                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog,
                                        PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, status, "展開失敗[キャンセルされました。]", string.Empty);
                                    // --- ADD 2011/09/06----------<<<<<
                                    rows[i].Result = "展開失敗[キャンセルされました。]";
                                    //if (rows[i].TruncateFlg)
                                    //    rows[i].PrevResult = 0;
                                    if (rowParent != null)
                                    {
                                        rowParent.Result = rows[i].Result;
                                        rowParent.EndTm = rows[i].EndTm;
                                        rowParent.Deploy = rows[i].Deploy;
                                    }
                                    _ConvertProcAcs.EndTransaction(false);
                                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text,
                                        "コンバート処理はキャンセルされました。", 0, MessageBoxButtons.OK);
                                    break;
                                }
                                else
                                {
                                    // --- ADD 2011/09/06---------->>>>>
                                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog,
                                        PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, status, string.Format("展開失敗[{0}]", errMsg), string.Empty);
                                    // --- ADD 2011/09/06----------<<<<<
                                    rows[i].Result = string.Format("展開失敗[{0}]", errMsg);
                                    //rows[i].PrevResult = -1;
                                    if (rowParent != null)
                                    {
                                        rowParent.Result = rows[i].Result;
                                        rowParent.EndTm = rows[i].EndTm;
                                        rowParent.PrevResult = rows[i].PrevResult;
                                        rowParent.Deploy = rows[i].Deploy;
                                        noErrorFlg = false;
                                    }
                                    else if (lstTblNm.ContainsKey(table)) // 纏め処理の先頭テーブル
                                    {
                                        noErrorFlg = false;
                                    }
                                    _ConvertProcAcs.EndTransaction(false);
                                }
                            }
                            else
                            {
                                // 2009/11/17 Del >>>
                                // 全てのファイルに対して存在しなくても削除処理を行うように修正
                                //// --- ADD 2009/03/02 障害ID:12051対応------------------------------------------------------>>>>>
                                //// 車輌管理はオプションのため、ファイルが存在しなくてもエラーとしない
                                //if (rows[i].TableId == "CNVCARPARTSRF")
                                //{
                                //    if (lstTblNm.ContainsKey(table)) // 纏め処理の先頭テーブル
                                //    {
                                //        rows[i].Result = string.Format("OK[{0}]", lstTblNm[table]);
                                //    }
                                //    else
                                //    {
                                //        rows[i].Result = "OK";
                                //    }

                                //    if (listChkExcpt.Contains(table) && errMsg != string.Empty)
                                //    {
                                //        rows[i].Result += "[" + errMsg + "]";
                                //    }

                                //    if (rowParent != null && noErrorFlg)
                                //    {
                                //        if (listLastTbl.Contains(table))
                                //        {
                                //            rowParent.Result = "OK";
                                //        }
                                //        else
                                //        {
                                //            rowParent.Result = string.Format("OK[{0}]", rows[i].TableNm);
                                //        }
                                //        rowParent.ReadDataCnt += rows[i].ReadDataCnt;
                                //        rowParent.WriteDataCnt += rows[i].WriteDataCnt;
                                //    }
                                //    rows[i].Deploy = string.Empty; // コンバートデータ展開正常終了時　選択状態解除
                                //    _ConvertProcAcs.EndTransaction(true);
                                //    if (rowParent == null && lstTblNm.ContainsKey(table) == false)
                                //        procCnt++;
                                //    else if (rowParent != null && listLastTbl.Contains(table))
                                //        procCnt++;
                                //    lblCnt.Text = string.Format("処理件数：{0} ／ 選択件数：{1}", procCnt, selectedCnt);
                                //    Refresh();

                                //    continue;
                                //}
                                //// --- ADD 2009/03/02 障害ID:12051対応------------------------------------------------------<<<<<
                                // 2009/11/17 Del <<<

                                // 2009/11/17 Del >>>
                                //rows[i].Result = "展開失敗[コンバート元ファイルが存在しません。]";
                                //if (rowParent != null)
                                //{
                                //    rowParent.Result = rows[i].Result;
                                //    noErrorFlg = false;
                                //}
                                //else if (lstTblNm.ContainsKey(table)) // 纏め処理の先頭テーブル
                                //{
                                //    noErrorFlg = false;
                                //}
                                // 2009/11/17 Del <<<
                                // 2009/11/17 Add >>>
                                rows[i].StartTm = DateTime.Now.ToString("HH:mm:ss");
                                bool truncateFlg = rows[i].TruncateFlg;
                                int cnt = 0;
                                status = _ConvertProcAcs.BeginTransaction(); // テーブル毎のトランザクション
                                if (status != 0)
                                {
                                    // --- ADD 2011/09/06---------->>>>>
                                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog,
                                        PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, status, "展開失敗[トランザクション開始に失敗しました。]", string.Empty);
                                    // --- ADD 2011/09/06----------<<<<<
                                    rows[i].Result = "展開失敗[トランザクション開始に失敗しました。]";
                                    rows[i].PrevResult = -1;
                                    if (rowParent != null)
                                    {
                                        rowParent.Result = rows[i].Result;
                                        rowParent.PrevResult = rows[i].PrevResult;
                                        noErrorFlg = false;
                                    }
                                    else if (lstTblNm.ContainsKey(table)) // 纏め処理の先頭テーブル
                                    {
                                        noErrorFlg = false;
                                    }
                                    break;
                                    //_ConvertProcAcs.EndTransaction(false);
                                }
                                if (truncateFlg == true)
                                {
                                    isRemoteOnProcess = true;
                                    status = _ConvertProcAcs.DeployConvertData(rows[i].TableId, truncateFlg, ref lstData, out cnt, out errMsg);
                                    isRemoteOnProcess = false;
                                }
                                updateCnt += cnt;
                                rows[i].WriteDataCnt = updateCnt;
                                rows[i].EndTm = DateTime.Now.ToString("HH:mm:ss");
                                if (status == 0)
                                {
                                    if (lstTblNm.ContainsKey(table)) // 纏め処理の先頭テーブル
                                    {
                                        rows[i].Result = string.Format("OK[{0}]", lstTblNm[table]);
                                    }
                                    else
                                    {
                                        rows[i].Result = "OK";
                                    }

                                    if (listChkExcpt.Contains(table) && errMsg != string.Empty)
                                    {
                                        rows[i].Result += "[" + errMsg + "]";
                                    }

                                    if (rowParent != null && noErrorFlg)
                                    {
                                        if (listLastTbl.Contains(table))
                                        {
                                            rowParent.Result = "OK";
                                        }
                                        else
                                        {
                                            rowParent.Result = string.Format("OK[{0}]", rows[i].TableNm);
                                        }
                                        rowParent.ReadDataCnt += rows[i].ReadDataCnt;
                                        rowParent.WriteDataCnt += rows[i].WriteDataCnt;
                                    }

                                    rows[i].Deploy = string.Empty; // コンバートデータ展開正常終了時　選択状態解除
                                    _ConvertProcAcs.EndTransaction(true);
                                    if (rowParent == null && lstTblNm.ContainsKey(table) == false)
                                        procCnt++;
                                    else if (rowParent != null && listLastTbl.Contains(table))
                                        procCnt++;
                                    lblCnt.Text = string.Format("処理件数：{0} ／ 選択件数：{1}", procCnt, selectedCnt);
                                    Refresh();
                                }
                                // 2009/11/17 Add <<<
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isRemoteOnProcess = false;
                        rows[i].EndTm = DateTime.Now.ToString("HH:mm:ss");
                        if (ex is RemotingException)
                        {
                            rows[i].Result = "展開失敗[リモート処理中エラーが発生しました。。]";
                        }
                        else if (ex.Message.Contains("CSV") && ex.Message.Contains("アクセス"))
                        {
                            rows[i].Result = ex.Message;
                        }
                        else
                        {
                            rows[i].Result = "展開失敗[処理中クライアント側でエラーが発生しました。]";
                        }
                        //rows[i].PrevResult = -1;
                        if (rowParent != null)
                        {
                            rowParent.Result = rows[i].Result;
                            rowParent.EndTm = rows[i].EndTm;
                            rowParent.PrevResult = rows[i].PrevResult;
                            rowParent.Deploy = rows[i].Deploy;
                            noErrorFlg = false;
                        }
                        else if (lstTblNm.ContainsKey(table)) // 纏め処理の先頭テーブル
                        {
                            noErrorFlg = false;
                        }
                        _ConvertProcAcs.EndTransaction(false);

                        // --- ADD 2011/09/06---------->>>>>
                        operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog,
                            PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, rows[i].Result, string.Empty);
                        // --- ADD 2011/09/06----------<<<<<
                    }

                    // --- ADD 2011/09/06---------->>>>>
                    operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, 
                        PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, rows[i].TableNm + "処理終了", "");
                    // --- ADD 2011/09/06----------<<<<<
                }
                if (status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                {
                    for (; i < rows.Length; i++)
                    {
                        rows[i].RejectChanges();
                    }
                }
                // 纏め処理の子行を親行と同じ状態とさせる。
                for (int ind = 0; ind < lstInvisible.Count; ind++)
                {
                    ConvertList.ListRow rowChild = ConvertDataList.FindByTableId(lstInvisible[ind]);
                    rowParent = GetParentRow(rowChild.TableId.Replace("RF", ""));
                    rowChild.Deploy = rowParent.Deploy;
                }
                operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "コンバート履歴をXMLファイルへ保存開始", ""); // ADD 2011/09/06
                // コンバート履歴をXMLファイルへ保存
                configData.Tables[0].Clear();
                configData.Tables[0].Merge(ConvertDataList, false, MissingSchemaAction.Ignore);
                configData.WriteXml(ctCONFIGFILE);
                operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "コンバート履歴をXMLファイルへ保存終了", ""); // ADD 2011/09/06
            }
            catch { }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
                if (_progressForm != null)
                {
                    _progressForm.Close();
                    //_progressForm.Dispose();
                    _progressForm = null;
                }
            }

            operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "コンバート処理終了", ""); // ADD 2011/09/06
        }

        private void ReDrawGrid()
        {
            int sz = gridConvData.Rows.Count;
            for (int i = 0; i < sz; i++)
            {
                if (gridConvData.Rows[i].Cells[ConvertDataList.DeployColumn.ColumnName].Value.Equals(""))
                    continue;
                if (string.Compare(gridConvData.Rows[i].Cells[ConvertDataList.StartTmColumn.ColumnName].Value.ToString(),
                    DateTime.Now.ToString("HH:mm:ss")) > 0)
                    continue;
                if (!gridConvData.Rows[i].Cells[ConvertDataList.ResultColumn.ColumnName].Value.Equals("")
                    && !gridConvData.Rows[i].Cells[ConvertDataList.ResultColumn.ColumnName].Value.Equals("OK"))
                    continue;

                gridConvData.Rows[i].Activate();
                gridConvData.Rows[i].Selected = true;
                break;

            }
        }

        /// <summary>
        /// 纏めて処理するテーブルならその親テーブルを返す
        /// </summary>
        /// <param name="table">テーブルID</param>
        /// <returns>null:纏め処理対象外</returns>
        private ConvertList.ListRow GetParentRow(string table)
        {
            if (table == "SALESDETAIL" || table == "SALESHISTORY" || table == "SALESHISTDTL"
                                            || table == "ACCEPTODRCAR" || table == "CNVCARPARTS")
            {
                return ConvertDataList.FindByTableId("SALESSLIPRF");
            }
            if (table == "DEPSITDTL")
            {
                return ConvertDataList.FindByTableId("DEPSITMAINRF");
            }
            if (table == "STOCKDETAIL" || table == "STOCKSLIPHIST" || table == "STOCKSLHISTDTL")
            {
                return ConvertDataList.FindByTableId("STOCKSLIPRF");
            }
            if (table == "PAYMENTDTL")
            {
                return ConvertDataList.FindByTableId("PAYMENTSLPRF");
            }
            if (table == "STOCKADJUSTDTL")
            {
                return ConvertDataList.FindByTableId("STOCKADJUSTRF");
            }
            return null;
        }

        #region < CancelButtonClick >

        /// <summary>
        /// CancelButtonClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButtonClick(object sender, EventArgs e)
        {
            cancelFlg = true;

            _progressForm.Close();
            _progressForm = null;

            if (isRemoteOnProcess)
            {
                int status = _ConvertProcAcs.StopProcess();

                //if (status == 1)
                //{
                //    // ここはスレッド問題でTMsgDispは使えない。
                //    MessageBox.Show("処理を中止する前に処理が終了されました。", "<情報>" + Text,
                //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else if (status != 0)
                //{
                //    MessageBox.Show("処理を中止出来ませんでした。", "<注意>" + Text, MessageBoxButtons.OK,
                //        MessageBoxIcon.Error);
                //}
            }
        }

        #endregion

        /// <summary>
        /// 在庫受払データ処理
        /// </summary>
        /// <param name="rowSAP">在庫受払行</param>
        /// <returns>-1:受払設定処理失敗/1:受払設定処理成功/0:受払設定処理なし</returns>
        private int StockAcPayHistInfoProc(ConvertList.ListRow rowSAP)
        {
            // --- ADD 2011/09/06---------->>>>>
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "在庫受払データ処理(StockAcPayHistInfoProc)開始", "");
            // --- ADD 2011/09/06----------<<<<<
            // --- ADD 2009/03/23 障害ID:12532対応------------------------------------------------------>>>>>
            bool stockMoveNormalFlg = true;
            // --- ADD 2009/03/23 障害ID:12532対応------------------------------------------------------<<<<<

            int ret = 0;
            int resultCnt;
            int status = 0;
            bool isComplete = true;
            for (int i = 0; i < lstSAPHistInfoChk.Count; i++)
            {
                ConvertList.ListRow row = ConvertDataList.FindByTableId(lstSAPHistInfoChk[i]);
                // --- CHG 2009/02/26 障害ID:12049対応------------------------------------------------------>>>>>
                //if (row != null && row.PrevResult < row.CsvCount) // 完了でない場合
                //{
                //    isComplete = false;
                //    rowSAP.ReadDataCnt = 0;
                //    rowSAP.WriteDataCnt = 0;
                //    rowSAP.Result = "元になるテーブルが全て正常完了してから再度在庫受払処理を行って下さい。";
                //    rowSAP.PrevResult = -1;
                //    break;
                //}
                if (row != null) // 完了でない場合
                {
                    switch (row.TableId)
                    {
                        case "SALESSLIPRF":
                        case "SALESDETAILRF":
                            {
                                if (row.PrevResult < 2)
                                {
                                    isComplete = false;
                                }
                                break;
                            }
                        case "SALESHISTORYRF":
                        case "SALESHISTDTLRF":
                        case "STOCKSLIPRF":
                        case "STOCKDETAILRF":
                        case "STOCKSLIPHISTRF":
                        case "STOCKSLHISTDTLRF":
                            {
                                if (row.PrevResult < 1)
                                {
                                    isComplete = false;
                                }
                                break;
                            }
                        // --- ADD 2009/03/23 障害ID:12532対応------------------------------------------------------>>>>>
                        case "STOCKMOVERF":
                            {
                                if (row.PrevResult < row.CsvCount)
                                {
                                    isComplete = false;
                                }
                                if (row.PrevResult == 10)
                                {
                                    stockMoveNormalFlg = true;
                                }
                                else if (row.PrevResult == 100)
                                {
                                    stockMoveNormalFlg = false;
                                }
                                break;
                            }
                        // --- ADD 2009/03/23 障害ID:12532対応------------------------------------------------------<<<<<
                        default:
                            {
                                if (row.PrevResult < row.CsvCount)
                                {
                                    isComplete = false;
                                }
                                break;
                            }
                    }
                    if (!isComplete)
                    {
                        rowSAP.ReadDataCnt = 0;
                        rowSAP.WriteDataCnt = 0;
                        rowSAP.Result = "元になるテーブルが全て正常完了してから再度在庫受払処理を行って下さい。";
                        rowSAP.PrevResult = -1;
                        break;
                    }
                }
                // --- CHG 2009/02/26 障害ID:12049対応------------------------------------------------------<<<<<
            }

            if (isComplete == false) // 元になるデータの一部でも完了でない
                return status;

            try
            {
                int i = 0;
                List<int> lstSource = new List<int>();
                rowSAP.StartTm = DateTime.Now.ToString("HH:mm:ss");
                if (rowSAP.TruncateFlg)
                    _ConvertProcAcs.BeginTransaction();
                if (rowSAP.TruncateFlg)
                    lstSource.Add(-1); // 削除処理用フラグを設定する
                for (i = 0; i < 7; i++)
                {
                    if (i == 2) // 仕入データからは在庫受払処理しない。
                        continue;

                    // --- ADD 2009/03/23 障害ID:12532対応------------------------------------------------------>>>>>
                    if (i == 4)
                    {
                        if (!stockMoveNormalFlg)
                        {
                            continue;
                        }
                    }
                    if (i == 6)
                    {
                        if (stockMoveNormalFlg)
                        {
                            continue;
                        }
                    }
                    // --- ADD 2009/03/23 障害ID:12532対応------------------------------------------------------<<<<<
                    lstSource.Add(i);
                }

                status = _ConvertProcAcs.SetStockAcPayHist(LoginInfoAcquisition.EnterpriseCode, lstSource, out resultCnt);
                if (status == 0)
                {
                    _ConvertProcAcs.EndTransaction(true);
                    rowSAP.ReadDataCnt = resultCnt;
                    rowSAP.WriteDataCnt = resultCnt;
                    rowSAP.Result = "OK";
                    rowSAP.PrevResult = 1;
                    rowSAP.Deploy = string.Empty; // コンバートデータ展開正常終了時　選択状態解除
                    ret = 1;
                }
                else
                {
                    if (i < 6)
                        rowSAP.Result = string.Format("{0}からの在庫受払処理中失敗しました。", lstSAP[i]);
                    else
                        rowSAP.Result = "在庫受払処理に失敗しました。";
                    rowSAP.ReadDataCnt = 0;
                    rowSAP.WriteDataCnt = 0;
                    rowSAP.PrevResult = -1;
                    _ConvertProcAcs.EndTransaction(false);
                    ret = -1;
                }
                rowSAP.EndTm = DateTime.Now.ToString("HH:mm:ss");
            }
            catch (Exception ex)
            {
                if (!(ex is RemotingException))
                {
                    _ConvertProcAcs.EndTransaction(false);
                }
                rowSAP.Result = "在庫受払処理に失敗しました。";
                rowSAP.ReadDataCnt = 0;
                rowSAP.WriteDataCnt = 0;
                rowSAP.PrevResult = -1;
                ret = -1;

                operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "在庫受払処理に失敗しました。", ""); // ADD 2011/09/06
            }

            operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "在庫受払データ処理(StockAcPayHistInfoProc)終了", ""); // ADD 2011/09/06

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstData">失敗したデータリスト</param>
        /// <param name="errLogFileNm">作成するログファイル名</param>
        /// <param name="errLogFolder">エラーログ保存フォルダ</param>
        private void WriteErrorLog(ArrayList lstData, string errLogFileNm)
        {
            string errLogFolder = txtLogDir.Text;
            //string errLogFileNm = fileNm.Substring(fileNm.LastIndexOf('\\') + 1);
            //errLogFileNm = errLogFileNm.Insert(errLogFileNm.IndexOf('.'), "_FailedData");
            if (Directory.Exists(errLogFolder) == false)
                Directory.CreateDirectory(errLogFolder);
            StreamWriter writer = new StreamWriter(Path.Combine(errLogFolder, errLogFileNm), false, Encoding.Default);
            for (int i = 0; i < lstData.Count; i++)
            {
                writer.WriteLine(lstData[i]);
            }
            writer.Close();
        }
        # endregion

        # region プライベートメソッド(画面設定関連)

        /// <summary>
        /// ツールバーのアイコン設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : フレームのツールバーの設定を行います。</br>
        /// <br>Programer  : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        /// </remarks>
        private void SettingToolbar()
        {
            //--------------------------------------------------------------
            // メインツールバー
            //--------------------------------------------------------------
            // イメージリストを設定する
            this.ToolbarsManager_Main.ImageListSmall = IconResourceManagement.ImageList16;

            //// 拠点のアイコン設定
            //ToolbarsManager_Main.Tools["LabelTool_SectionTitle"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            //// ログイン担当者のアイコン設定
            //ToolbarsManager_Main.Tools["LabelTool_LoginNameTitle"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            // 終了のアイコン設定
            ToolbarsManager_Main.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // 確定のアイコン設定
            ToolbarsManager_Main.Tools["Button_Convert"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            // キャンセルのアイコン設定
            ToolbarsManager_Main.Tools["Button_Cancel"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;
            //-----Add Start 2012/11/09 zhangy3 ----->>>>>
            // 待機のアイコン設定
            ToolbarsManager_Main.Tools["Button_Wait"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            //-----Add End   2012/11/09 zhangy3 -----<<<<<
            //// 在庫受払のアイコン設定
            //ToolbarsManager_Main.Tools["Btn_StockAcPay"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.MODIFY;
        }

        # endregion

        #region [ ボタンイベント処理 ]
        private void uButton_DirGuide_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            dlg.RootFolder = Environment.SpecialFolder.MyComputer;
            dlg.Description = "コンバートデータのフォルダを指定して下さい。";
            DialogResult ret = dlg.ShowDialog();
            if (ret == DialogResult.OK)
            {
                txtDir.Text = dlg.SelectedPath;
                txtLogDir.Text = Path.Combine(txtDir.Text, "ConvertErrorLog");
                btn_ClearAll.Select();
            }
        }

        private void uBtn_DirGuide2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            dlg.RootFolder = Environment.SpecialFolder.MyComputer;
            dlg.Description = "コンバート時のエラーログを格納するフォルダを指定して下さい。";
            DialogResult ret = dlg.ShowDialog();
            if (ret == DialogResult.OK)
            {
                txtLogDir.Text = dlg.SelectedPath;
                btn_ClearAll.Select();
            }
        }

        /// <summary>
        /// [全て解除]ボタン押下イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ClearAll_Click(object sender, EventArgs e)
        {
            SetDeploy(false);
            lblCnt.Text = string.Empty;
            //SetCounter();
        }

        /// <summary>
        /// [全て選択]ボタン押下イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            SetDeploy(false);
            SetDeploy(true);
            SetCounter();
        }

        private void btn_SelectAll2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ConvertDataList.Count; i++)
            {
                ConvertDataList[i].Deploy = "●";
            }
            SetCounter();
        }

        private void btnDelUnchk_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ConvertDataList.Count; i++)
            {
                if (ConvertDataList[i].TableId != "STOCKACPAYHISTRF")
                {
                    ConvertDataList[i].TruncateFlg = false;
                }
            }
        }

        private void btnDelChk_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ConvertDataList.Count; i++)
            {
                ConvertDataList[i].TruncateFlg = true;
            }
        }

        /// <summary>
        /// 展開区分設定
        /// </summary>
        /// <param name="flg">true: 全選択/false: 全解除</param>
        private void SetDeploy(bool flg)
        {
            for (int i = 0; i < ConvertDataList.Count; i++)
            {
                if (flg)
                {
                    if (ConvertDataList[i].PrevResult < ConvertDataList[i].CsvCount)
                    {
                        ConvertDataList[i].Deploy = "●";
                        switch (ConvertDataList[i].TableId)
                        {
                            case "SALESSLIPRF": // 売上・受注・貸出・車輌データ
                                ConvertDataList.FindByTableId("SALESDETAILRF").Deploy = "●"; // 売上明細データ
                                ConvertDataList.FindByTableId("SALESHISTORYRF").Deploy = "●"; // 売上履歴データ
                                ConvertDataList.FindByTableId("SALESHISTDTLRF").Deploy = "●"; // 売上履歴明細データ
                                ConvertDataList.FindByTableId("ACCEPTODRCARRF").Deploy = "●"; // 受注マスタ（車両）
                                ConvertDataList.FindByTableId("CNVCARPARTSRF").Deploy = "●"; // 車輌部品データ（コンバート）
                                break;
                            case "DEPSITMAINRF": // 入金データ
                                ConvertDataList.FindByTableId("DEPSITDTLRF").Deploy = "●"; // 入金明細データ
                                break;
                            case "STOCKSLIPRF": // 仕入データ
                                ConvertDataList.FindByTableId("STOCKDETAILRF").Deploy = "●"; // 仕入明細データ
                                ConvertDataList.FindByTableId("STOCKSLIPHISTRF").Deploy = "●"; // 仕入履歴データ
                                ConvertDataList.FindByTableId("STOCKSLHISTDTLRF").Deploy = "●"; // 仕入履歴明細データ
                                break;
                            case "PAYMENTSLPRF": // 支払データ
                                ConvertDataList.FindByTableId("PAYMENTDTLRF").Deploy = "●"; // 支払明細データ
                                break;
                            case "STOCKADJUSTRF": // 在庫調整データ
                                ConvertDataList.FindByTableId("STOCKADJUSTDTLRF").Deploy = "●"; // 在庫調整明細データ
                                break;
                        }
                    }
                }
                else
                {
                    ConvertDataList[i].Deploy = string.Empty;
                }
            }
        }

        private void btn_FilterMaster_Click(object sender, EventArgs e)
        {
            ConvertDataList.DefaultView.RowFilter = "ConvKind = 0 AND Visible = True"; // コンバート種別が 0:マスタ
            Mode_Label.Text = "マスタ表示";
            convFilter = ConvKindFilter.Master;
            SetCounter();

            SetEnabledStockAcPayHist();
        }

        private void btn_FilterData_Click(object sender, EventArgs e)
        {
            ConvertDataList.DefaultView.RowFilter = "ConvKind = 1 AND Visible = True"; // コンバート種別が 1:データ
            Mode_Label.Text = "データ表示";
            convFilter = ConvKindFilter.Data;
            SetCounter();

            SetEnabledStockAcPayHist();
        }

        private void btn_FilterJisseki_Click(object sender, EventArgs e)
        {
            ConvertDataList.DefaultView.RowFilter = "ConvKind = 2 AND Visible = True"; // コンバート種別が 2:実績
            Mode_Label.Text = "実績表示";
            convFilter = ConvKindFilter.Jisseki;
            SetCounter();

            SetEnabledStockAcPayHist();
        }

        private void btn_NoFilter_Click(object sender, EventArgs e)
        {
            ConvertDataList.DefaultView.RowFilter = "Visible = True";
            Mode_Label.Text = "全表示";
            convFilter = ConvKindFilter.All;
            SetCounter();

            SetEnabledStockAcPayHist();
        }

        private void SetEnabledStockAcPayHist()
        {
            for (int rowIndex = 0; rowIndex < gridConvData.Rows.Count; rowIndex++)
            {
                if ((string)gridConvData.Rows[rowIndex].Cells["TableId"].Value == "STOCKACPAYHISTRF")
                {
                    gridConvData.Rows[rowIndex].Cells["TruncateFlg"].Activation = Activation.Disabled;
                }
                else
                {
                    gridConvData.Rows[rowIndex].Cells["TruncateFlg"].Activation = Activation.AllowEdit;
                }
            }
        }
        #endregion

        #region [ グリッドイベント処理 ]
        private void gridConvData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.CellAppearance.TextVAlign = VAlign.Middle;
            UltraGridBand band0 = e.Layout.Bands[0];
            //band0.UseRowLayout = true;            
            band0.Columns[ConvertDataList.TableIdColumn.ColumnName].Hidden = true;
            band0.Columns[ConvertDataList.ConvKindColumn.ColumnName].Hidden = true;
            band0.Columns[ConvertDataList.PrevResultColumn.ColumnName].Hidden = true;
            band0.Columns[ConvertDataList.CsvCountColumn.ColumnName].Hidden = true;
            band0.Columns[ConvertDataList.VisibleColumn.ColumnName].Hidden = true;

            //SetColInfo(band0, ConvertDataList.DeployColumn.ColumnName, 2, 0, 30);
            //SetColInfo(band0, ConvertDataList.TableNmColumn.ColumnName, 4, 0, 350);
            //SetColInfo(band0, ConvertDataList.TruncateFlgColumn.ColumnName, 13, 0, 40);
            //SetColInfo(band0, ConvertDataList.StartTmColumn.ColumnName, 15, 0, 100);
            //SetColInfo(band0, ConvertDataList.EndTmColumn.ColumnName, 19, 0, 100);
            //SetColInfo(band0, ConvertDataList.ReadDataCntColumn.ColumnName, 23, 0, 60);
            //SetColInfo(band0, ConvertDataList.WriteDataCntColumn.ColumnName, 26, 0, 60);
            //SetColInfo(band0, ConvertDataList.ResultColumn.ColumnName, 29, 0, 800);

            band0.Columns[ConvertDataList.DeployColumn.ColumnName].Width = 30;
            band0.Columns[ConvertDataList.TableNmColumn.ColumnName].Width = 350;
            band0.Columns[ConvertDataList.TruncateFlgColumn.ColumnName].Width = 40;
            band0.Columns[ConvertDataList.StartTmColumn.ColumnName].Width = 80;
            band0.Columns[ConvertDataList.EndTmColumn.ColumnName].Width = 80;
            band0.Columns[ConvertDataList.ReadDataCntColumn.ColumnName].Width = 80;
            band0.Columns[ConvertDataList.WriteDataCntColumn.ColumnName].Width = 80;
            band0.Columns[ConvertDataList.ResultColumn.ColumnName].Width = 800;
            band0.Columns[ConvertDataList.ResultColumn.ColumnName].Header.Appearance.TextHAlign = HAlign.Left;

            band0.Columns[ConvertDataList.TruncateFlgColumn.ColumnName].CellClickAction = CellClickAction.CellSelect;
            band0.Columns[ConvertDataList.DeployColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Center;
            band0.Columns[ConvertDataList.ReadDataCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            band0.Columns[ConvertDataList.WriteDataCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            band0.Columns[ConvertDataList.ReadDataCntColumn.ColumnName].Format = "###,###,##0";
            band0.Columns[ConvertDataList.WriteDataCntColumn.ColumnName].Format = "###,###,##0";

            //e.Layout.UseFixedHeaders = true;
            band0.Columns[ConvertDataList.DeployColumn.ColumnName].Header.Fixed = true;
            band0.Columns[ConvertDataList.TableNmColumn.ColumnName].Header.Fixed = true;
            //band0.Columns[ConvertDataList.TruncateFlgColumn.ColumnName].Header.Fixed = true;
            band0.Columns[ConvertDataList.ResultColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.VisibleRows;
        }

        private void gridConvData_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            SetValue(e.Row);

            gridConvData.UpdateData();
        }

        private void gridConvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridConvData.ActiveRow != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SetValue(gridConvData.ActiveRow);

                    gridConvData.UpdateData();

                    UltraGridRow ugr = gridConvData.ActiveRow.GetSibling(SiblingRow.Next);
                    if (ugr != null)
                    {
                        ugr.Activate();
                        ugr.Selected = true;
                    }
                }
                // ADD 2009/04/01 不具合対応[12898]：スペースキーでの項目選択機能を実装 ---------->>>>>
                else if (e.KeyCode == Keys.Space)
                {
                    // [削除]カラムの値を設定
                    bool truncateFlag = (bool)this.gridConvData.ActiveRow.Cells[ConvertDataList.TruncateFlgColumn.ColumnName].Value;
                    this.gridConvData.ActiveRow.Cells[ConvertDataList.TruncateFlgColumn.ColumnName].Value = !truncateFlag;
                }
                // ADD 2009/04/01 不具合対応[12898]：スペースキーでの項目選択機能を実装 ----------<<<<<
            }
        }

        /// <summary>
        /// 選択状態更新処理
        /// </summary>
        /// <param name="row"></param>
        private void SetValue(UltraGridRow row)
        {
            UltraGridCell cell = row.Cells[ConvertDataList.DeployColumn.ColumnName];
            string val = string.Empty;
            if (cell.Value.Equals("●"))
            {
                val = "";
            }
            else
            {
                val = "●";
            }
            cell.Value = val;

            // 纏めて処理するテーブルに対する処理
            switch (row.Cells[ConvertDataList.TableIdColumn.ColumnName].Value.ToString())
            {
                case "SALESSLIPRF": // 売上・受注・貸出・車輌データ
                    ConvertDataList.FindByTableId("SALESDETAILRF").Deploy = val; // 売上明細データ
                    ConvertDataList.FindByTableId("SALESHISTORYRF").Deploy = val; // 売上履歴データ
                    ConvertDataList.FindByTableId("SALESHISTDTLRF").Deploy = val; // 売上履歴明細データ
                    ConvertDataList.FindByTableId("ACCEPTODRCARRF").Deploy = val; // 受注マスタ（車両）
                    ConvertDataList.FindByTableId("CNVCARPARTSRF").Deploy = val; // 車輌部品データ（コンバート）
                    break;
                case "DEPSITMAINRF": // 入金データ
                    ConvertDataList.FindByTableId("DEPSITDTLRF").Deploy = val; // 入金明細データ
                    break;
                case "STOCKSLIPRF": // 仕入データ
                    ConvertDataList.FindByTableId("STOCKDETAILRF").Deploy = val; // 仕入明細データ
                    ConvertDataList.FindByTableId("STOCKSLIPHISTRF").Deploy = val; // 仕入履歴データ
                    ConvertDataList.FindByTableId("STOCKSLHISTDTLRF").Deploy = val; // 仕入履歴明細データ
                    break;
                case "PAYMENTSLPRF": // 支払データ
                    ConvertDataList.FindByTableId("PAYMENTDTLRF").Deploy = val; // 支払明細データ
                    break;
                case "STOCKADJUSTRF": // 在庫調整データ
                    ConvertDataList.FindByTableId("STOCKADJUSTDTLRF").Deploy = val; // 在庫調整明細データ
                    break;
            }
            SetCounter();
        }

        private void gridConvData_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            bool val = !((bool)e.Cell.Value);
            e.Cell.Value = val;
            // 纏めて処理するテーブルに対する処理
            switch (e.Cell.Row.Cells[ConvertDataList.TableIdColumn.ColumnName].Value.ToString())
            {
                case "SALESSLIPRF": // 売上・受注・貸出・車輌データ
                    ConvertDataList.FindByTableId("SALESDETAILRF").TruncateFlg = val; // 売上明細データ
                    ConvertDataList.FindByTableId("SALESHISTORYRF").TruncateFlg = val; // 売上履歴データ
                    ConvertDataList.FindByTableId("SALESHISTDTLRF").TruncateFlg = val; // 売上履歴明細データ
                    ConvertDataList.FindByTableId("ACCEPTODRCARRF").TruncateFlg = val; // 受注マスタ（車両）
                    ConvertDataList.FindByTableId("CNVCARPARTSRF").TruncateFlg = val; // 車輌部品データ（コンバート）
                    break;
                case "DEPSITMAINRF": // 入金データ
                    ConvertDataList.FindByTableId("DEPSITDTLRF").TruncateFlg = val; // 入金明細データ
                    break;
                case "STOCKSLIPRF": // 仕入データ
                    ConvertDataList.FindByTableId("STOCKDETAILRF").TruncateFlg = val; // 仕入明細データ
                    ConvertDataList.FindByTableId("STOCKSLIPHISTRF").TruncateFlg = val; // 仕入履歴データ
                    ConvertDataList.FindByTableId("STOCKSLHISTDTLRF").TruncateFlg = val; // 仕入履歴明細データ
                    break;
                case "PAYMENTSLPRF": // 支払データ
                    ConvertDataList.FindByTableId("PAYMENTDTLRF").TruncateFlg = val; // 支払明細データ
                    break;
                case "STOCKADJUSTRF": // 在庫調整データ
                    ConvertDataList.FindByTableId("STOCKADJUSTDTLRF").TruncateFlg = val; // 在庫調整明細データ
                    break;
            }
            if (gridConvData.Selected.Rows.Count == 0 || e.Cell.Row != gridConvData.Selected.Rows[0])
                e.Cell.Row.Selected = true;
            e.Cancel = true;
        }

        private void gridConvData_Enter(object sender, EventArgs e)
        {
            if (gridConvData.Selected.Rows.Count == 0)
            {
                if (gridConvData.ActiveRow != null)
                {
                    gridConvData.ActiveRow.Selected = true;
                }
                else
                {
                    if (gridConvData.Rows.Count > 0)
                    {
                        gridConvData.Rows[0].Activate();
                        gridConvData.Rows[0].Selected = true;
                    }
                }
            }
        }

        private void gridConvData_Leave(object sender, EventArgs e)
        {
            gridConvData.Selected.Rows.Clear();
        }

        private void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int width)
        {
            System.Drawing.Size sizeHeader = new Size();
            System.Drawing.Size sizeCell = new Size();

            Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
            Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

            Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
            Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
            Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;

            sizeCell.Height = 20;
            sizeCell.Width = width;
            Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            sizeHeader.Height = 20;
            sizeHeader.Width = width;
            Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

        }

        /// <summary>
        /// 処理カウンタ表示
        /// </summary>        
        private void SetCounter()
        {
            selectedCnt = 0;
            for (int i = 0; i < ConvertDataList.DefaultView.Count; i++)
            {
                ConvertList.ListRow row = ConvertDataList.DefaultView[i].Row as ConvertList.ListRow;
                //if (ConvertDataList[i].Deploy == "●" && ConvertDataList[i].Visible)
                //if (row.Deploy == "●")
                if (ConvertDataList.DefaultView[i]["Deploy"].Equals("●"))
                {
                    selectedCnt++;
                }
            }
            if (selectedCnt == 0)
            {
                lblCnt.Text = string.Empty;
            }
            else
            {
                lblCnt.Text = string.Format("選択件数：{0}", selectedCnt);
            }
            Refresh();
        }
        #endregion

        #region [ フォーカス制御 ]
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.NextCtrl == uButton_DirGuide)
            {
                if (txtDir.Text != string.Empty)
                {
                    txtLogDir.Text = Path.Combine(txtDir.Text, "ConvertErrorLog");
                    e.NextCtrl = btn_ClearAll;
                }
            }
            else if (e.NextCtrl == uBtn_DirGuide2)
            {
                if (txtLogDir.Text == string.Empty)
                {
                    if (txtDir.Text != string.Empty)
                    {
                        txtLogDir.Text = Path.Combine(txtDir.Text, "ConvertErrorLog");
                        e.NextCtrl = btn_ClearAll;
                    }
                }
                else
                {
                    e.NextCtrl = btn_ClearAll;
                }
            }
            else if (e.PrevCtrl == gridConvData)
            {
                if (gridConvData.ActiveRow != null)
                {
                    SetValue(gridConvData.ActiveRow);
                    gridConvData.UpdateData();

                    UltraGridRow ugr = gridConvData.ActiveRow.GetSibling(SiblingRow.Next);
                    if (ugr != null)
                    {
                        ugr.Activate();
                        ugr.Selected = true;
                    }
                    e.NextCtrl = gridConvData;
                }
            }
        }
        #endregion

    }
}