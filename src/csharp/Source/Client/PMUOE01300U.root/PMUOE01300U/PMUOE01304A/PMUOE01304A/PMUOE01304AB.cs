//****************************************************************************//
// システム         : 卸商仕入受信処理
// プログラム名称   : 卸商仕入受信処理Controller
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/11/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024  佐々木 健 
// 作 成 日  2010/10/19  修正内容 : 発注番号をまたがった同一仕入伝票の対応(MANTIS[0015563])
//----------------------------------------------------------------------------//
// 管理番号  11601223-00  作成担当 : 陳艶丹
// 作 成 日  K2021/09/22  修正内容 : PMKOBETSU-4189 ログ追加
//----------------------------------------------------------------------------//
// 管理番号  11770181-00  作成担当 : 譚洪
// 作 成 日  2021/12/08   修正内容 : PMKOBETSU-4202 卸商仕入受信処理 データ読込改善対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;// ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応

namespace Broadleaf.Application.Controller
{
    using StockDB       = SingletonPolicy<StockDBAgent>;
    using LoginWorkerAcs= SingletonPolicy<LoginWorker>;

    #region <計上データ/>

    /// <summary>
    /// 計上データ作成処理Controllerクラス
    /// </summary>
    public abstract class MakeSumUpDataController : OroshishoStockReceptionController
    {
        /// <summary>DBへ書込まないフラグ</summary>
        private bool _canNotWriting;
        // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
        /// <summary>ログ内容</summary>
        private const string CtLogDataMassage = "計上データ/在庫調整データ作成処理:一括更新失敗;電文問合せ番号={0}";
        /// <summary>ログ出力PGID</summary>
        private const string CtLogOutputPgid = "PMUOE01304A";
        /// <summary>ログ出力共通部品</summary>
        OutLogCommon LogCommon;
        // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<
        /// <summary>
        /// DBへ書込まないフラグのアクセサ
        /// </summary>
        public bool CanNotWriting
        {
            get { return _canNotWriting; }
            set { _canNotWriting = value; }
        }

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        protected MakeSumUpDataController(UOESupplierHelper uoeSupplier) : base(uoeSupplier) { }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// 処理を実行します。
        /// </summary>
        /// <returns>結果コード</returns>
        /// <see cref="OroshishoStockReceptionController"/>
        /// <remarks>
        /// <br>Update Note: PMKOBETSU-4189　ログ追加</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : K2021/09/22</br>
        /// </remarks>
        public override int Execute()
        {
            // DBにマージ
            MergeToDB();

            // DBへ書込まない場合（仕入データと在庫調整データを同時に書込む場合）
            if (CanNotWriting) return (int)Result.Code.Normal;

            // DBを一括更新
            string message = string.Empty;
            string itemInfo = string.Empty;
            int status = StockDB.Instance.Policy.Write(out message, out itemInfo);

            // 送受信JNL（発注）の更新
            if (status.Equals((int)Result.RemoteStatus.Normal))
            {
                CopyUOEOrderDataToUOESendReceiveJournal();
            }
            // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
            else
            {
                // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------>>>>>
                if (StockDB.Instance.Policy.HisLogOutSettingInfo.OutFlg)
                {
                    // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------<<<<<
                    //操作履歴ログを登録
                    UoeOprtnHisLogAcs uoeOprtnHisLogAcs = new UoeOprtnHisLogAcs();
                    string logMsg = string.Format(CtLogDataMassage, StockDB.Instance.Policy.UOESalesOrderNo);
                    uoeOprtnHisLogAcs.logd_update(this, string.Empty, string.Empty, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, status, logMsg, StockDB.Instance.Policy.UOESupplierCd);
                    WriteClcLogProc(CtLogOutputPgid, logMsg);
                }//ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応
            }
            // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<
            return status;
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

        #endregion  // <Override/>

        /// <summary>
        /// DBにマージします。
        /// </summary>
        protected abstract void MergeToDB();

        /// <summary>
        /// UOE発注データを送受信JNLへコピーします。
        /// </summary>
        protected void CopyUOEOrderDataToUOESendReceiveJournal()
        {
            StockDB.Instance.Policy.CopyUOEOrderDataToUOESendReceiveJournal();
        }
    }

    #endregion  // <計上データ/>

    #region <仕入データ/>

    /// <summary>
    /// 仕入データ作成処理Controllerクラス
    /// </summary>
    public sealed class MakeStockDataAcs : MakeSumUpDataController
    {
        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        public MakeStockDataAcs(UOESupplierHelper uoeSupplier) : base(uoeSupplier) { }

        #endregion  // <Constructor/>

        #region <Override/>

        // 2009/10/09 Add >>>
        public override Result.ProcessID ProcessID { get { return Result.ProcessID.MakeSumUpData; } }
        // 2009/10/09 Add <<<


        /// <summary>
        /// DBにマージします。
        /// </summary>
        /// <see cref="OroshishoStockReceptionController"/>
        protected override void MergeToDB()
        {
            IList<SumUpInformationBuilder> sumUpInfoBuilderList = new List<SumUpInformationBuilder>();
            {
                // 1.仕入明細データ（計上）の作成
                sumUpInfoBuilderList.Add(new SumUpStockDetailDataBuilder(UOESupplier));

                // 2.仕入データ（計上）の作成
                sumUpInfoBuilderList.Add(new SumUpStockDataBuilder(UOESupplier));
            }
            foreach (SumUpInformationBuilder sumUpInfoBuilder in sumUpInfoBuilderList)
            {
                sumUpInfoBuilder.Merge();
            }

            // 仕入データ数
            int stockDataCount = StockDB.Instance.Policy.GetSumUpStockDataCount();
            {
                RaiseUpdateProgressEvent(new UpdateProgressEventArgs(
                    "仕入データ作成処理",   // LITERAL:
                    stockDataCount
                ));
            }
        }

        #endregion  // <Override/>
    }

    #endregion  // <仕入データ/>

    #region <在庫調整データ/>

    /// <summary>
    /// 在庫調整データ作成処理Controllerクラス
    /// </summary>
    public sealed class MakeStockAdjustAcs : MakeSumUpDataController
    {
        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        public MakeStockAdjustAcs(UOESupplierHelper uoeSupplier) : base(uoeSupplier) { }

        #endregion  // <Constructor/>

        #region <Override/>

        // 2009/10/09 Add >>>
        public override Result.ProcessID ProcessID { get { return Result.ProcessID.MakeStockAdjust; } }
        // 2009/10/09 Add <<<

        /// <summary>
        /// DBにマージします。
        /// </summary>
        /// <see cref="OroshishoStockReceptionController"/>
        protected override void MergeToDB()
        {
            IList<SumUpInformationBuilder> sumUpInfoBuilderList = new List<SumUpInformationBuilder>();
            {
                // 1.在庫調整明細データの作成
                sumUpInfoBuilderList.Add(new SumUpStockAdjustDetailBuilder(UOESupplier));

                // 2.在庫調整データの作成
                sumUpInfoBuilderList.Add(new SumUpStockAdjustBuilder(UOESupplier));
            }
            foreach (SumUpInformationBuilder sumUpInfoBuilder in sumUpInfoBuilderList)
            {
                sumUpInfoBuilder.Merge();
            }

            // 在庫調整データ数
            int stockAdjustCount = StockDB.Instance.Policy.GetSumUpStockAdjustCount();
            {
                RaiseUpdateProgressEvent(new UpdateProgressEventArgs(
                    "在庫調整データ作成処理",   // LITERAL:
                    stockAdjustCount
                ));
            }
        }

        #endregion  // <Override/>
    }

    #endregion  // <在庫調整データ/>
}
