//****************************************************************************//
// システム         : 卸商仕入受信処理
// プログラム名称   : 卸商仕入受信処理View
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/11/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2009/10/09  修正内容 : 受信の該当データ無し対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024  佐々木 健 
// 作 成 日  2010/10/19  修正内容 : 在庫仕入データ作成処理の文字が切れないように修正(MANTIS[0016443])
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 32470  小原　卓也 
// 作 成 日  2021/07/09  修正内容 : 受信処理例外発生時のログ出力追加
//----------------------------------------------------------------------------//
// 管理番号  11601223-00  作成担当 : 陳艶丹
// 作 成 日  K2021/09/22  修正内容 : PMKOBETSU-4189 ログ追加
//----------------------------------------------------------------------------//
// 管理番号  11770181-00  作成担当 : 譚洪
// 作 成 日  2021/12/08   修正内容 : PMKOBETSU-4202 卸商仕入受信処理 データ読込改善対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Exception;
using System.IO;//ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応

namespace Broadleaf.Windows.Forms
{
    using LoginWorkerAcs        = SingletonPolicy<LoginWorker>;
    using UOESupplierUIItemType = CodeNamePair<int>;

    /// <summary>
    /// 卸商仕入受信処理Viewクラス
    /// </summary>
    /// <remarks>
    /// <br>Update Note: PMKOBETSU-4189　ログ追加</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : K2021/09/22</br>
    /// </remarks>
    public partial class OroshishoStockReceptionView : UserControl
    {
        // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
        /// <summary>ログ内容</summary>
        private const string CtLogDataMassage = "電文問合せ番号={0};受信件数={1}件;回答データ作成={2}件;仕入データ作成={3}件";
        /// <summary>異常ログ内容</summary>
        private const string CtErrLogDataMassage = "電文問合せ番号={0};受信件数={1}件;回答データ作成={2}件;仕入データ作成={3}件;エラー内容={4}";
        /// <summary>電文問合せ番号</summary>
        private string UOESalesOrderNo = string.Empty;
        /// <summary>操作履歴ログ登録アクセス</summary>
        private UoeOprtnHisLogAcs _uoeOprtnHisLogAcs = null;
        /// <summary>ログ出力PGID</summary>
        private const string CtLogOutputPgid = "PMUOE01301U";
        /// <summary>ログ出力共通部品</summary>
        OutLogCommon LogCommon;
        // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<
        // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------>>>>>
        // 制御XMLファイル
        private const string HISLOGOUTSETTINGFILE = "PMUOE01300U_HisLogOutSetting.xml";
        // 出力制御XML
        private HisLogOutSetting HisLogOutSettingInfo;
        // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------<<<<<

        #region <UOE発注先/>

        /// <summary>
        /// UOE発注先が存在するか判定します。
        /// </summary>
        /// <value>
        /// <c>true </c>:存在する。
        /// <c>false</c>:存在しない。
        /// </value>
        public bool ExistsUOESupplier
        {
            get { return this.uoeSupplierComboBox.Items.Count > 0; }
        }

        /// <summary>UOE発注先のマップ</summary>
        /// <remarks>Key:UOE発注先コード</remarks>
        private readonly IDictionary<int, UOESupplierHelper> _uoeSupplierCodedMap = new Dictionary<int, UOESupplierHelper>();
        /// <summary>
        /// UOE発注先のマップを取得します。
        /// </summary>
        /// <value>UOE発注先のマップ</value>
        private IDictionary<int, UOESupplierHelper> UOESupplierCodedMap { get { return _uoeSupplierCodedMap; } }

        /// <summary>
        /// 仕入受信処理が行えるか判定します。
        /// </summary>
        /// <remarks>
        /// 仕入受信処理が行える場合、発注先マップに登録されます。
        /// </remarks>
        /// <param name="uoeSupplier">UOE発注者</param>
        /// <returns>
        /// <c>true</c> :仕入受信処理が行える<br/>
        /// <c>false</c>:仕入受信処理が行えない
        /// </returns>
        private bool CanReceivingStocking(UOESupplier uoeSupplier)
        {
            if (UOESupplierUtil.HasStockSlipData(uoeSupplier.StockSlipDtRecvDiv))   // 仕入受信区分(=1：あり）
            {
                UOESupplierHelper uoeSupplierItem = UOESupplierUtil.CreateHelper(uoeSupplier, EnterpriseProfile);
                // UOE仕入先がSPK(その他)、明治産業で条件は変化
                if (!uoeSupplierItem.CanReceiveStoking()) return false;

                if (!UOESupplierCodedMap.ContainsKey(uoeSupplier.UOESupplierCd))
                {
                    UOESupplierCodedMap.Add(uoeSupplier.UOESupplierCd, uoeSupplierItem);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// UOE発注先を初期化します。
        /// </summary>
        /// <exception cref="OroshishoStockReceptionException">UOE発注先マスタの検索に失敗しました。</exception>
        private void InitializeUOESupplier()
        {
            // UOE発注先マスタを検索
            UOESupplierAcs uoeSupplierAcs = new UOESupplierAcs();
            ArrayList uoeSupplierList = new ArrayList();

            int status = uoeSupplierAcs.Search(out uoeSupplierList, EnterpriseProfile.Code, SectionProfile.Code);
            if (!status.Equals((int)Result.RemoteStatus.Normal))
            {
                const string ERR_MSG = "UOE発注先マスタの検索に失敗しました。"; // LITERAL:
                Debug.Assert(status.Equals((int)Result.RemoteStatus.Normal), ERR_MSG);
                throw new OroshishoStockReceptionException(ERR_MSG, status);
            }

            // UOE発注先UIを初期化
            UOESupplierCodedMap.Clear();
            this.uoeSupplierComboBox.Items.Clear();
            foreach (UOESupplier uoeSupplier in uoeSupplierList)
            {
                if (CanReceivingStocking(uoeSupplier))
                {
                    this.uoeSupplierComboBox.Items.Add(
                        new UOESupplierUIItemType(uoeSupplier.UOESupplierCd, uoeSupplier.UOESupplierName)
                    );
                }
            }
            if (this.uoeSupplierComboBox.Items.Count > 0)
            {
                this.uoeSupplierComboBox.SelectedIndex = 0;
            }
            else
            {
                this.uoeSupplierComboBox.Enabled = false;
            }
        }

        /// <summary>
        /// 選択されているUOE発注先を取得します。
        /// </summary>
        /// <value>選択されているUOE発注先</value>
        private UOESupplierHelper SelectedUOESupplier
        {
            get
            {
                UOESupplierUIItemType selectedUOESupplierItem = (UOESupplierUIItemType)this.uoeSupplierComboBox.SelectedItem;
                return UOESupplierCodedMap[selectedUOESupplierItem.Code];
            }
        }

        #endregion  // <UOE発注先/>

        #region <仕入データ/>

        #region <UOE自社設定/>

        /// <summary>
        /// UOE自社設定を取得します。
        /// </summary>
        public UOESetting UOESetting { get { return LoginWorkerAcs.Instance.Policy.UOESetting; } }

        #endregion  // <UOE自社設定/>

        /// <summary>
        /// 仕入データを初期化します。
        /// </summary>
        /// <remarks>
        /// UOE自社設定を設定します。
        /// </remarks>
        /// <exception cref="OroshishoStockReceptionException">UOE自社設定マスタの検索に失敗しました。</exception>
        private void InitializeStockData()
        {
            // UOE自社設定マスタを検索
            if (UOESetting == null)
            {
                const string ERR_MSG = "UOE自社設定マスタの検索に失敗しました。";   // LITERAL:
                throw new OroshishoStockReceptionException(ERR_MSG, (int)Result.Code.Error);
            }

            // UOE自社設定マスタの卸商更新区分が手動の場合、仕入データUIは非表示
            if (IsManualThatIsDistEnterDivOfUOESetting())
            {
                this.stockingTitleLabel.Visible= false;
                this.stockingCountLabel.Visible= false;
                this.stockingUnitLabel.Visible = false;

                return;
            }

            // 買掛管理ありの場合、仕入データ作成
            if (LoginWorkerAcs.Instance.Policy.HasStockingPaymentOption)
            {
                this.stockingTitleLabel.Text = "仕入データ作成";    // Literal:
            }
            // 買掛管理なしの場合、在庫仕入データ作成
            else
            {
                this.stockingTitleLabel.Text = "在庫仕入データ作成";// Literal:
            }
        }

        /// <summary>
        /// UOE自社設定マスタの卸商更新区分が手動か判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :手動<br/>
        /// <c>false</c>:それ以外
        /// </returns>
        private bool IsManualThatIsDistEnterDivOfUOESetting()
        {
            return UOESetting.DistEnterDiv.Equals((int)LoginWorker.OroshishoDistEnterDiv.Manual);
        }

        #endregion  // <仕入データ/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public OroshishoStockReceptionView()
        {
            #region <Designer Code/>

            InitializeComponent();

            #endregion  // <Designer Code/>

            UpdateProgress += DebugWriteLine;

            GetControlXmlInfo();//ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応
        }

        /// <summary>
        /// 初期化します。
        /// </summary>
        /// <exception cref="OroshishoStockReceptionException">
        /// <list type="bullet">
        /// <item>
        /// <description>UOE発注先マスタの検索に失敗しました。</description>
        /// </item>
        /// <item>
        /// <description>UOE自社設定マスタの検索に失敗しました。</description>
        /// </item>
        /// </list>
        /// </exception>
        public void Initialize()
        {
            // UOE発注先UIを初期化
            InitializeUOESupplier();

            // 仕入データUIを初期化
            InitializeStockData();

            // 実行結果の表示を初期化
            InitializeResult();
        }

        /// <summary>
        /// 実行結果の表示を初期化します。
        /// </summary>
        private void InitializeResult()
        {
            const string EMPTY_RESULT = "0";

            // 受信処理UIを初期化
            this.receptionCountLabel.Text = EMPTY_RESULT;

            // 回答データUIを初期化
            this.answerCountLabel.Text = EMPTY_RESULT;

            // 仕入データ／在庫仕入データUIを初期化
            this.stockingCountLabel.Text = EMPTY_RESULT;
        }

        #endregion  // <Constructor/>

        /// <summary>進捗を更新するイベント</summary>
        public event UpdateProgressEventHandler UpdateProgress;

        #region <企業プロフィール/>

        /// <summary>
        /// 企業プロフィールを取得します。
        /// </summary>
        /// <value>企業プロフィール</value>
        private CodeNamePair<string> EnterpriseProfile
        {
            get { return LoginWorkerAcs.Instance.Policy.EnterpriseProfile; }
        }

        #endregion  // <企業プロフィール/>

        #region <拠点プロフィール/>

        /// <summary>
        /// 拠点プロフィールを取得します。
        /// </summary>
        /// <value>拠点プロフィール</value>
        private CodeNamePair<string> SectionProfile
        {
            get { return LoginWorkerAcs.Instance.Policy.SectionProfile; }
        }

        #endregion  // <拠点プロフィール/>

        /// <summary>
        /// 処理を実行します。
        /// </summary>
        /// <param name="processID">処理ID</param>
        /// <returns>結果コード</returns>
        // 2009/10/09 >>>
        //public int Execute()
        /// <remarks>
        /// <br>Update Note: PMKOBETSU-4189　ログ追加</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : K2021/09/22</br>
        /// </remarks>
        public int Execute(out Result.ProcessID processID)
        // 2009/10/09 <<<
        {
            // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
            //操作履歴ログアクセス
            _uoeOprtnHisLogAcs = UoeOprtnHisLogAcs.GetInstance();
            string logMsg = string.Empty;
            int uOESupplierCd = SelectedUOESupplier.RealUOESupplier.UOESupplierCd;
            // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<
            processID = Result.ProcessID.None; // 2009/10/09 Add

            InitializeResult();

            IList<OroshishoStockReceptionController> controllerList = new List<OroshishoStockReceptionController>();

            // 1.仕入受信処理
            controllerList.Add(CreateReceiveStockAcs());

            // 2.仕入回答データ作成処理
            controllerList.Add(CreateMakeStockAnswerDataAcs((ReceiveStockAcs)controllerList[0]));

            // 3.計上データ作成処理
            controllerList.Add(CreateMakeSumUpDataAcs());

            // 3.5.在庫調整データ作成処理
            MakeSumUpDataController makeStockAdjustAcs = CreateMakeStockAdjustAcs();
            if (makeStockAdjustAcs != null)
            {
                controllerList.Add(makeStockAdjustAcs);
            }

            // 4.回答表示
            controllerList.Add(CreateShowAnswerAcs());

            int resultCode = (int)Result.Code.Normal;
            try
            {
                foreach (OroshishoStockReceptionController controller in controllerList)
                {
                    resultCode = controller.Execute();
                    processID = controller.ProcessID;   // 2009/10/09 Add
                    if (processID == Result.ProcessID.MakeStockAnswerData) UOESalesOrderNo = ((MakeStockAnswerDataAcs)controller).UOESalesOrderNo;// ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応
                    if (!resultCode.Equals((int)Result.Code.Normal)) break;
                }
                // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------>>>>>
                if (HisLogOutSettingInfo.OutFlg)
                {
                    // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------<<<<<
                    // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
                    //操作履歴ログ登録
                    logMsg = string.Format(CtLogDataMassage, UOESalesOrderNo, this.receptionCountLabel.Text, this.answerCountLabel.Text, this.stockingCountLabel.Text);
                    _uoeOprtnHisLogAcs.logd_update(this, string.Empty, string.Empty, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, resultCode, logMsg, uOESupplierCd);
                    // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<
                }//ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応
                if (resultCode.Equals((int)Result.Code.Normal)) InitializeResult();
            }
            catch (ArgumentException e)
            {
                // --ADD 2021/07/09 例外発生時のログ出力追加 ------>>>>>>
                OutLogCommon outlogCommonObj = new OutLogCommon();
                outlogCommonObj.OutputClientLog("PMUOE01301U", "PMUOE01301U.Execute 例外発生 processID=" + processID.ToString(), EnterpriseProfile.Code, LoginWorkerAcs.Instance.Policy.Detail.EmployeeCode, e);
                // --ADD 2021/07/09 例外発生時のログ出力追加 ------<<<<<<
                Debug.WriteLine(e.ToString());
                resultCode = (int)Result.Code.ExistSlip;
                // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------>>>>>
                if (HisLogOutSettingInfo.OutFlg)
                {
                    // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------<<<<<
                    // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
                    //操作履歴ログ登録
                    logMsg = string.Format(CtErrLogDataMassage, UOESalesOrderNo, this.receptionCountLabel.Text, this.answerCountLabel.Text, this.stockingCountLabel.Text, e.Message);
                    _uoeOprtnHisLogAcs.logd_update(this, string.Empty, string.Empty, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, resultCode, logMsg, uOESupplierCd);
                    WriteClcLogProc(CtLogOutputPgid, logMsg);
                    // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<
                }//ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応
            }
            // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
            catch (Exception e)
            {
                // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------>>>>>
                if (HisLogOutSettingInfo.OutFlg)
                {
                    // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------<<<<<
                    resultCode = (int)Result.Code.Error;
                    //操作履歴ログ登録
                    logMsg = string.Format(CtErrLogDataMassage, UOESalesOrderNo, this.receptionCountLabel.Text, this.answerCountLabel.Text, this.stockingCountLabel.Text, e.Message);
                    _uoeOprtnHisLogAcs.logd_update(this, string.Empty, string.Empty, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, resultCode, logMsg, uOESupplierCd);
                    WriteClcLogProc(CtLogOutputPgid, logMsg);
                }//ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応
                throw;
            }
            // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<
            return resultCode;
        }

        // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
        /// <summary>
        /// CLCログ出力準備メソッド
        /// </summary>
        /// <param name="pgid">呼出元メソッド名</param>
        /// <param name="message">出力メッセージ本文</param>
        /// <remarks>
        /// <br>Note       : CLCログ出力共通メソッドを呼出</br>
        /// <br>Programmer : 田村顕成</br>
        /// <br>Date       : K2021/09/22</br>
        /// </remarks>
        public void WriteClcLogProc(string pgid, string message)
        {
            try
            {
                if (LogCommon == null)
                {
                    LogCommon = new OutLogCommon();
                }
                LogCommon.OutputClientLog(pgid, message, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);
            }
            catch
            {
                // ログ出力処理のため、例外は無視する
            }
        }
        // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<

        // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------>>>>>
        /// <summary>
        /// 出力制御XMLファイル取得
        /// </summary>
        /// <remarks>
        /// <br>Note         : 出力制御XMLファイル取得処理を行う</br>
        /// <br>Programmer   : 譚洪</br>
        /// <br>Date         : 2021/12/08</br>
        /// </remarks>
        public void GetControlXmlInfo()
        {
            try
            {
                HisLogOutSettingInfo = new HisLogOutSetting();
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, HISLOGOUTSETTINGFILE)))
                {
                    // XML情報を取得する
                    HisLogOutSettingInfo = UserSettingController.DeserializeUserSetting<HisLogOutSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, HISLOGOUTSETTINGFILE));
                }
                else
                {
                    HisLogOutSettingInfo.OutFlg = false;
                }
            }
            catch
            {
                if (HisLogOutSettingInfo == null) HisLogOutSettingInfo = new HisLogOutSetting();
                HisLogOutSettingInfo.OutFlg = false;
            }
        }
        // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------<<<<<


        /// <summary>
        /// フォーマット化された件数を取得します。
        /// </summary>
        /// <param name="count">件数</param>
        /// <returns>ZZZ,ZZ9</returns>
        private static string FormatCount(int count)
        {
            return string.Format("{0:N0}", count);
        }

        #region <仕入受信処理/>

        /// <summary>
        /// 仕入受信処理Controllerを生成します。
        /// </summary>
        /// <returns>仕入受信処理Controller</returns>
        private ReceiveStockAcs CreateReceiveStockAcs()
        {
            ReceiveStockAcs receiveStockAcs = new ReceiveStockAcs(SelectedUOESupplier);
            receiveStockAcs.UpdateProgress += this.UpdateProgressOfStockReceive;
            return receiveStockAcs;
        }

        /// <summary>
        /// 仕入受信処理の進捗を更新するイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void UpdateProgressOfStockReceive(
            object sender,
            UpdateProgressEventArgs e
        )
        {
            this.receptionCountLabel.Text = FormatCount(e.Count);
            this.Update();

            UpdateProgress(sender, e);
        }

        #endregion  // <仕入受信処理/>

        #region <仕入回答データ作成処理/>

        /// <summary>
        /// 仕入回答データ作成処理Controllerを生成します。
        /// </summary>
        /// <param name="inputMaker">入力データの作成者</param>
        /// <returns>仕入回答データ作成処理Controller</returns>
        private MakeStockAnswerDataAcs CreateMakeStockAnswerDataAcs(ReceiveStockAcs inputMaker)
        {
            MakeStockAnswerDataAcs makeStockAnswerDataAcs = new MakeStockAnswerDataAcs(SelectedUOESupplier, inputMaker);
            makeStockAnswerDataAcs.UpdateProgress += this.UpdateProgressOfAnswerData;
            return makeStockAnswerDataAcs;
        }

        /// <summary>
        /// 仕入回答データ作成処理の進捗を更新するイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void UpdateProgressOfAnswerData(
            object sender,
            UpdateProgressEventArgs e
        )
        {
            if (!e.IsRunning)
            {
                this.answerCountLabel.Text = FormatCount(e.Count);
                this.Update();
            }

            UpdateProgress(sender, e);
        }

        #endregion  // <仕入回答データ作成処理/>

        #region <計上データ作成処理/>

        /// <summary>
        /// 計上データ作成処理Controllerを生成します。
        /// </summary>
        /// <returns>計上データ作成処理Controller</returns>
        private MakeSumUpDataController CreateMakeSumUpDataAcs()
        {
            MakeSumUpDataController makeSumUpDataAcs = new MakeStockDataAcs(SelectedUOESupplier);
            {
                // 買掛管理ありの場合、仕入データ作成のみ
                if (LoginWorkerAcs.Instance.Policy.HasStockingPaymentOption)
                {
                    makeSumUpDataAcs.CanNotWriting = false;
                }
                // 買掛管理なしの場合、仕入データ作成と在庫仕入データ作成
                else
                {
                    makeSumUpDataAcs.CanNotWriting = true;
                }
                makeSumUpDataAcs.UpdateProgress += this.UpdateProgressOfSumUpData;
            }
            return makeSumUpDataAcs;
        }

        /// <summary>
        /// 在庫調整データ作成処理Controllerを生成します。
        /// </summary>
        /// <returns>在庫調整データ作成処理Controller</returns>
        private MakeSumUpDataController CreateMakeStockAdjustAcs()
        {
            MakeSumUpDataController makeSumUpDataAcs = null;
            {
                // 買掛管理ありの場合、仕入データ作成
                if (LoginWorkerAcs.Instance.Policy.HasStockingPaymentOption)
                {
                    return makeSumUpDataAcs;
                }
                // 買掛管理なしの場合、在庫仕入データ作成
                else
                {
                    makeSumUpDataAcs = new MakeStockAdjustAcs(SelectedUOESupplier);
                }
                makeSumUpDataAcs.UpdateProgress += this.UpdateProgressOfSumUpData;
            }
            return makeSumUpDataAcs;
        }

        /// <summary>
        /// 計上データ作成処理の進捗を更新するイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void UpdateProgressOfSumUpData(
            object sender,
            UpdateProgressEventArgs e
        )
        {
            this.stockingCountLabel.Text = FormatCount(e.Count);
            this.Update();

            UpdateProgress(sender, e);
        }

        #endregion  // <計上データ作成処理/>

        #region <回答表示/>

        /// <summary>
        /// 回答表示Controllerを生成します。
        /// </summary>
        /// <returns>回答表示Controller</returns>
        private ShowAnswerAcs CreateShowAnswerAcs()
        {
            ShowAnswerAcs showAnswerAcs = new ShowAnswerAcs(SelectedUOESupplier);
            showAnswerAcs.UpdateProgress += this.UpdateProgressOfShowingAnswer;
            return showAnswerAcs;
        }

        /// <summary>
        /// 回答表示の進捗を更新するイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void UpdateProgressOfShowingAnswer(
            object sender,
            UpdateProgressEventArgs e
        )
        {
            UpdateProgress(sender, e);
        }

        #endregion  // <回答表示/>

        #region <デバッグ用/>

        /// <summary>
        /// 進捗をDebug.WriteLine()します。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private static void DebugWriteLine(
            object sender,
            UpdateProgressEventArgs e
        )
        {
            Debug.WriteLine(e.ToString());
        }

        #endregion  // <デバッグ用/>
    }

    // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------>>>>>
    /// <summary>
    /// 操作履歴の登録、ログ出力設定
    /// </summary>
    public class HisLogOutSetting
    {
        // 操作履歴の登録、ログ出力区分
        private bool _outFlg;

        /// <summary>
        /// 操作履歴の登録、ログ出力設定クラス
        /// </summary>
        public HisLogOutSetting()
        {

        }

        /// <summary>操作履歴の登録、ログ出力区分</summary>
        public bool OutFlg
        {
            get { return this._outFlg; }
            set { this._outFlg = value; }
        }
    }
    // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------<<<<<
}
