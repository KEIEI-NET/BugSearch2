//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2021/01/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2011/03/07  修正内容 : ＵＳＢのオプション制御を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/09/16  修正内容 : Redmine 25219 PCCUOE PM側／売上伝票入力 UOE発注時の動作不具合の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/08/17  修正内容 : SCM障害№154対応 連結設定のチェックがない時送信しないようにする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本 利明
// 作 成 日  2013/08/09  修正内容 : SCM仕掛一覧 №10557対応
//                                  PMTAB全体設定マスタ(得意先別)・BLP送信区分を参照して送信チェックボックスの初期設定を行う
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/11/26  修正内容 : SCM仕掛一覧№10707対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本 利明
// 作 成 日  2015/06/18  修正内容 : SCM仕掛一覧№10707
//                                  回答送信未実行時の確認メッセージ表示有無をconfig設定に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本 利明
// 作 成 日  2015/06/25  修正内容 : SCM仕掛一覧№10707
//                                  config参照処理にNull判定を追加
//----------------------------------------------------------------------------//
// 管理番号  11570208-00 作成担当 : 譚洪
// 作 成 日  2020/02/24  修正内容 : PMKOBETSU-2912消費税税率機能追加対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Configuration; // ADD 2015/06/18 T.Miyamoto SCM仕掛一覧№10707

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
// 2011/03/07 Add >>>
using Broadleaf.Application.Common;   
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
// 2011/03/07 Add <<<
// --- ADD 2013/08/09 T.Miyamoto ------------------------------>>>>>
using System.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
// --- ADD 2013/08/09 T.Miyamoto ------------------------------<<<<<
using System.IO; // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 送信種別選択ガイドUIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 送信種別選択ガイドの画面表示制御を行います</br>
    /// <br>Programmer : 30517 夏野 駿希</br>
    /// <br>Date       : 2011/01/17</br>
    /// </remarks>
    public class PMKHN05010UA
    {
        #region プライベートメンバ
        /// <summary>送信対象売上データ</summary>
        private SalesSlip _salesSlip = null;
        /// <summary>送信対象売上明細データ</summary>
        private List<SalesDetail> _salesDetailList = null;
        /// <summary>得意先マスタ</summary>
        private CustomerInfo _customerInfo = null;
        //>>>2011/05/17
        /// <summary>指示書番号</summary>
        private string _partySalesSlipNum = string.Empty;
        //<<<2011/05/17
        // --- ADD 2013/08/09 T.Miyamoto ------------------------------>>>>>
        /// <summary>BLP送信区分</summary>
        private int _blpSendDiv = 1;
        /// <summary>PMTAB全体設定マスタリモート</summary>
        private IPmTabTtlStCustDB _iPmTabTtlStCustDB;
        // --- ADD 2013/08/09 T.Miyamoto ------------------------------<<<<<
        // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
        /// <summary>受注ステータス売上</summary>
        private const int ACPTANORDSTATUSSTATE_SALSE = 30;
        // --- DEL 2015/06/18 T.Miyamoto SCM仕掛一覧№10707 -------------------->>>>>
        ///// <summary>福田部品企業コード</summary>
        //private const string ENTERPRISE_CODE_FUKUDA = "0101130064003200";
        // --- DEL 2015/06/18 T.Miyamoto SCM仕掛一覧№10707 --------------------<<<<<
        /// <summary>操作履歴ログ出力ファイル名</summary>
        private const string LOG_FILE_NAME = ".\\Log\\PMKHN05010U_Operation.log";
        // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<<
        // --- ADD 2015/06/18 T.Miyamoto SCM仕掛一覧№10707 -------------------->>>>>
        /// <summary>「config」ファイル</summary>
        private const string Exe_Conf_Filename = "PMKHN05010U.dll.config";
        /// <summary>appSettings</summary>
        private const string App_Set_Section = "appSettings";
        /// <summary>回答送信実行確認設定</summary>
        private const string CT_Conf_SendCheck = "SendCheck";
        // --- ADD 2015/06/18 T.Miyamoto SCM仕掛一覧№10707 --------------------<<<<<

        // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------>>>>>
        /// <summary>軽減税率区分</summary>
        private double _scmTaxRateInput = 0;
        // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------<<<<<

        #endregion

        #region 外部公開プロパティ
        /// <summary>送信対象売上データ</summary>
        public SalesSlip SalesSlip
        {
            get { return _salesSlip; }
            set { _salesSlip = value; }
        }

        /// <summary>送信対象売上明細データ</summary>
        public List<SalesDetail> SalesDetailList
        {
            get { return _salesDetailList; }
            set { _salesDetailList = value; }
        }

        /// <summary>得意先マスタ</summary>
        public CustomerInfo CustomerInfo
        {
            get { return _customerInfo; }
            set { _customerInfo = value; }
        }

        //>>>2011/05/17
        /// <summary>指示書番号</summary>
        public string PartySalesSlipNum
        {
            get { return _partySalesSlipNum; }
            set { _partySalesSlipNum = value; }
        }
        //<<<2011/05/17
        // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------>>>>>
        /// <summary>軽減税率値</summary>
        public double ScmTaxRateInput
        {
            get { return _scmTaxRateInput; }
            set { _scmTaxRateInput = value; }
        }
        // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------<<<<<

        #endregion

        #region enum
        /// <summary>送信対象オプション</summary>
        public enum OptSendTargetDiv : int
        {
            /// <summary>無し</summary>
            None = 0,
            /// <summary>SCM</summary>
            Scm = 10,
            /// <summary>TSP.NS</summary>
            TspNs = 20,
            /// <summary>TSPインライン</summary>
            TspInline = 30,
            /// <summary>TSPメール</summary>
            TspMail = 40,
            //---ADD 2011/09/16 --------->>>>>
            /// <summary>ScmUOE</summary>
            ScmUOE = 50,
            //---ADD 2011/09/16 ---------<<<<<
            // ADD 2012/08/17 SCM障害№154 --------------->>>>>
            /// <summary>ScmUOE</summary>
            ScmNoSend = 60,
            // ADD 2012/08/17 SCM障害№154 --------------->>>>>
        }
        #endregion

        #region 外部公開メソッド
        /// <summary>
        /// 送信種別選択ガイドを表示します。
        /// </summary>
        /// <param name="status"></param>
        /// <param name="msg"></param>
        /// <param name="optSendTarget"></param>
        /// <returns></returns>
        public DialogResult ShowDialog(out int status, out string msg, out OptSendTargetDiv optSendTarget)
        {
            return this.ShowDialog(null, out status, out msg, out optSendTarget); ;
        }

        /// <summary>
        /// 送信種別選択ガイドを表示します。
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="status"></param>
        /// <param name="msg"></param>
        /// <param name="optSendTarget"></param>
        /// <returns></returns>
        public DialogResult ShowDialog(IWin32Window owner, out int status, out string msg, out OptSendTargetDiv optSendTarget)
        {
            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            msg = string.Empty;
            optSendTarget = OptSendTargetDiv.None;
            DialogResult result = DialogResult.Cancel;
            switch (CheckData(out msg))
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    // 画面を表示する
                    // --- UPD 2013/08/09 T.Miyamoto ------------------------------>>>>>
                    //PMKHN05010UB form = new PMKHN05010UB(_salesSlip.CustomerSnm, _customerInfo.OnlineKindDiv, CheckMustSend());
                    PMKHN05010UB form = new PMKHN05010UB(_salesSlip.CustomerSnm, _customerInfo.OnlineKindDiv, CheckMustSend(), _blpSendDiv);
                    // --- UPD 2013/08/09 T.Miyamoto ------------------------------<<<<<
                    //>>>2011/05/17
                    form.PartySalesSlipNum = this._partySalesSlipNum;
                    //<<<2011/05/17
                    // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------>>>>>
                    form.ScmTaxRateInput = this._scmTaxRateInput;
                    // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------<<<<<
                    if (owner == null)
                    {
                        form.ShowDialog();
                    }
                    else
                    {
                        form.ShowDialog(owner);
                    }
                    result = form.Result;
                    // はいを選んだ
                    if (result == DialogResult.Yes)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>>
                        // --- UPD 2015/06/18 T.Miyamoto SCM仕掛一覧№10707 -------------------->>>>>
                        //// 企業コードが福田部品の場合
                        //if (LoginInfoAcquisition.EnterpriseCode.Trim().Equals(ENTERPRISE_CODE_FUKUDA))
                        // config設定で回答送信確認メッセージがオンの場合
                        AppSettingsSection appSettingSection = GetAppSettingsSection();
                        // --- UPD 2015/06/25 T.Miyamoto SCM仕掛一覧№10707 -------------------->>>>>
                        //if (appSettingSection.Settings[CT_Conf_SendCheck].Value.Equals("1"))
                        if ((appSettingSection.Settings[CT_Conf_SendCheck] != null) &&
                            (appSettingSection.Settings[CT_Conf_SendCheck].Value.Equals("1")))
                        // --- ADD 2015/06/25 T.Miyamoto SCM仕掛一覧№10707 --------------------<<<<<
                        // --- UPD 2015/06/18 T.Miyamoto SCM仕掛一覧№10707 --------------------<<<<<
                        {
                            if (!form.OptSendTargetChk &&
                                (_customerInfo.OnlineKindDiv == (int)PMKHN05010UA.OptSendTargetDiv.Scm ||
                                _customerInfo.OnlineKindDiv == (int)PMKHN05010UA.OptSendTargetDiv.ScmUOE) &&
                                _salesSlip.AcptAnOdrStatus == ACPTANORDSTATUSSTATE_SALSE)
                            {
                                // 以下の条件すべてを満たす場合、処理の継続確認メッセージを表示
                                // ・チェックが外れている
                                // ・伝票種別が売上
                                // ・種別がSCMまたはUOE

                                DialogResult dResult = MessageBox.Show(
                                    "得意先に回答を送信しない設定となっていますが\nよろしいですか？",
                                    "確認",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button2);

                                // 操作履歴のログ出力
                                this.WriteLog(dResult);

                                // NOを選択した場合
                                if (dResult == DialogResult.No)
                                {
                                    status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                    result = DialogResult.No;
                                    break;
                                }
                            }
                        }
                        // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<

                        // 送信種別のチェックの状態を確認
                        if (form.OptSendTargetChk)
                        {
                            optSendTarget = (OptSendTargetDiv)_customerInfo.OnlineKindDiv;
                        }
                        else
                        {
                            optSendTarget = OptSendTargetDiv.None;
                        }

                        //>>>2011/05/17
                        // 画面指示書番号を反映
                        this._partySalesSlipNum = form.PartySalesSlipNum;
                        //<<<2011/05/17
                    }
                    // いいえを選んだ
                    else
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    }
                    break;
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    // 送信対象外の場合はDialogResultをYESとする
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                    // 2011/03/04 >>>
                    //result = DialogResult.Yes;
                    result = DialogResult.None;
                    // 2011/03/04 <<<
                    break;
                default:
                    // エラーの為処理を終了
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    result = DialogResult.Cancel;
                    break;
            }
            return result;
        }
        #endregion

        #region プライベートメソッド
        /// <summary>
        /// 送信対象か判断する
        /// </summary>
        /// <returns></returns>
        private int CheckData(out string msg)
        {
            msg = string.Empty;
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // 売上データ・売上明細データリスト　いずれかがNULLなら処理を行わない
            if (_salesSlip == null || _salesDetailList == null)
            {
                msg = "売上データがセットされていません。";
                return status;
            }
            // 得意先マスタがNULLなら取得する
            if (_customerInfo == null)
            {
                // 得意先マスタ取得
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                int readStatus = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, _salesSlip.EnterpriseCode, _salesSlip.CustomerCode, true, false, out _customerInfo);
                if (readStatus != 0 || _customerInfo == null || _customerInfo.LogicalDeleteCode != 0)
                {
                    // エラー
                    msg = "得意先マスタの取得に失敗しました。";
                    return status;
                }
            }
            // --- ADD 2013/08/09 T.Miyamoto ------------------------------>>>>>
            this._iPmTabTtlStCustDB = MediationPmTabTtlStCustDB.GetPmTabTtlStCustDB();
            PmTabTtlStCustWork pmTabTtlStCustWork = new PmTabTtlStCustWork();
            pmTabTtlStCustWork.EnterpriseCode = _customerInfo.EnterpriseCode;
            pmTabTtlStCustWork.CustomerCode = _customerInfo.CustomerCode;

            object objSearchCond = pmTabTtlStCustWork;
            object objRetList;
            int pMTabStatus = this._iPmTabTtlStCustDB.Search(out objRetList, objSearchCond, 0, ConstantManagement.LogicalMode.GetData0);
            if (pMTabStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList resultList = objRetList as ArrayList;
                if (resultList != null && resultList.Count > 0)
                {
                    _blpSendDiv = ((PmTabTtlStCustWork)resultList[0]).BlpSendDiv;
                }
            }
            // --- ADD 2013/08/09 T.Miyamoto ------------------------------<<<<<

            // オンライン種別区分をチェック
            switch (_customerInfo.OnlineKindDiv)
            {
                case (int)OptSendTargetDiv.Scm:
                case (int)OptSendTargetDiv.ScmUOE: // ADD 2011/09/16
                // ADD 2012/08/17 SCM障害№154 --------------->>>>>
                case (int)OptSendTargetDiv.ScmNoSend: 
                // ADD 2012/08/17 SCM障害№154 ---------------<<<<<
                    // 2011/03/07 Add >>>
                    PurchaseStatus purchaseStatus = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);
                    if (!( purchaseStatus == PurchaseStatus.Contract || purchaseStatus == PurchaseStatus.Trial_Contract ))
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    }
                    // 2011/03/07 Add <<<

                    // SCMで売上データなら送信対象
                    if (_salesSlip.AcptAnOdrStatus == 30)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    // SCMで通常見積なら送信対象
                    else if (_salesSlip.AcptAnOdrStatus == 10 && _salesSlip.EstimateDivide == 1)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    else
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                    }
                    break;
                default:
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                    break;
            }
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                msg = "送信対象外です。";
            }
            return status;
        }

        /// <summary>
        /// 送信固定か判断する
        /// </summary>
        /// <returns></returns>
        private bool CheckMustSend()
        {
            // オンライン種別がSCMで売上データに問い合わせ番号がセットされている場合は送信固定
            //if (_customerInfo.OnlineKindDiv == 10  && _salesSlip.InquiryNumber != 0) // DEL 2011/09/16
            if ((_customerInfo.OnlineKindDiv == 10 || _customerInfo.OnlineKindDiv == 50) && _salesSlip.InquiryNumber != 0)// ADD 2011/09/16
            {
                return true;
            }
            return false;
        }

        // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 --->>>>>
        /// <summary>
        /// 処理継続選択結果のログを出力します。
        /// </summary>
        /// <remarks>MAHNB01012AD.cs::SalesSlipInputInitDataAcs.LogWrite()を参考</remarks>
        /// <param name="result">操作結果</param>
        private void WriteLog(DialogResult dResult)
        {
            string operation = string.Empty;
            if (dResult == DialogResult.Yes)
            {
                operation = "はい";
            }
            else if (dResult == DialogResult.No)
            {
                operation = "いいえ";
            }

            FileStream fileStream = new FileStream(LOG_FILE_NAME, FileMode.Append, FileAccess.Write, FileShare.Write);
            if (fileStream != null)
            {
                StreamWriter writer = new StreamWriter(fileStream, Encoding.GetEncoding("shift_jis"));
                DateTime writingDateTime = DateTime.Now;

                if (writer != null)
                {
                    writer.WriteLine(string.Format(
                        "{0,-19} {1,-5} {2} {3}",   // yyyy/MM/dd hh:mm:ss
                        writingDateTime,
                        writingDateTime.Millisecond,
                        _salesSlip.SalesSlipNum,
                        operation
                    ));
                    writer.Close();
                }
                fileStream.Close();
            }
        }
        // ADD 2014/11/26 k.toyosawa SCM仕掛一覧№10707対応 ---<<<<<

        // --- ADD 2015/06/18 T.Miyamoto SCM仕掛一覧№10707 -------------------->>>>>
        /// <summary>
        /// ConfigurationSection取得処理
        /// </summary>
        private AppSettingsSection GetAppSettingsSection()
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();

            file.ExeConfigFilename = Exe_Conf_Filename;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);

            return (AppSettingsSection)config.GetSection(App_Set_Section);
        }
        // --- ADD 2015/06/18 T.Miyamoto SCM仕掛一覧№10707 --------------------<<<<<
        #endregion
    }
}
