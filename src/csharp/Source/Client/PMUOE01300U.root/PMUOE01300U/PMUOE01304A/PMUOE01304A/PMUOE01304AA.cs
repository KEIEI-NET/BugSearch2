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
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2009/10/09  修正内容 : 受信の該当データ無し対応
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
using System.Diagnostics;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using LoginWorkerAcs= SingletonPolicy<LoginWorker>;
    using StockDB       = SingletonPolicy<StockDBAgent>;
    using System.Text;//ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応
    using Broadleaf.Application.Common;//ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応

    /// <summary>
    /// 仕入回答データ作成処理Controllerクラス
    /// </summary>
    public sealed class MakeStockAnswerDataAcs : OroshishoStockReceptionController
    {
        // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
        /// <summary>ログ内容</summary>
        private const string CtLogDataMassage = "仕入回答データ作成失敗:電文問合せ番号={0}";
        // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<

        #region <入力データの作成者/>

        /// <summary>入力データの作成者</summary>
        private readonly ReceiveStockAcs _inputMaker;
        /// <summary>
        /// 入力データの作成者を取得します。
        /// </summary>
        /// <value>入力データの作成者</value>
        private ReceiveStockAcs InputMaker { get { return _inputMaker; } }

        #endregion  // <入力データの作成者/>

        // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
        #region <電文問合せ番号/>

        /// <summary>電文問合せ番号</summary>
        private string _uOESalesOrderNo = string.Empty;
        /// <summary>
        /// 電文問合せ番号を取得します。
        /// </summary>
        /// <value>電文問合せ番号</value>
        public string UOESalesOrderNo { get { return _uOESalesOrderNo; } }

        /// <summary>間隔</summary>
        private const string Str_Space = "/";

        /// <summary>ログ出力PGID</summary>
        private const string CtLogOutputPgid = "PMUOE01304A";
        
        /// <summary>ログ出力共通部品</summary>
        OutLogCommon LogCommon;  

        #endregion  // <電文問合せ番号/>
        // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        /// <param name="inputMaker">入力データの作成者</param>
        public MakeStockAnswerDataAcs(
            UOESupplierHelper uoeSupplier,
            ReceiveStockAcs inputMaker
        ) : base(uoeSupplier)
        {
            _inputMaker = inputMaker;
        }

        #endregion  // <Constructor/>

        #region <Override/>

        // 2009/10/09 Add >>>
        public override Result.ProcessID ProcessID { get { return Result.ProcessID.MakeStockAnswerData; } }
        // 2009/10/09 Add <<<

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
            // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
            StringBuilder str = new StringBuilder();
            string preUOESalesOrderNo = string.Empty;
            // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<
            // 1.発注情報の一括取得
            IIterator<ReceivedText> receivedTextIterator = InputMaker.Product.CreateIterator();
            while (receivedTextIterator.HasNext())
            {
                ReceivedText receivedText = receivedTextIterator.GetNext();
                {
                    StockDB.Instance.Policy.AddSearchingCondition(
                        UOESupplier.RealUOESupplier.UOESupplierCd,  // UIでの指定発注先
                        int.Parse(receivedText.UOESalesOrderNo),    // 電文問合せ番号
                        int.Parse(receivedText.UOESalesOrderRowNo)  // 回答電文対応行
                    );
                    // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
                    //電文問合番号を取得
                    if (string.IsNullOrEmpty(str.ToString()))
                    {
                        str.Append(int.Parse(receivedText.UOESalesOrderNo));
                    }
                    else
                    {
                        // 電文問合番号が複数の場合
                        if (preUOESalesOrderNo != receivedText.UOESalesOrderNo) str.Append(Str_Space + int.Parse(receivedText.UOESalesOrderNo));
                    }
                    preUOESalesOrderNo = receivedText.UOESalesOrderNo;
                    // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<
                }
            }
            // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
            //電文問合番号を記憶（ログに出力用）
            _uOESalesOrderNo = str.ToString();
            StockDB.Instance.Policy.UOESalesOrderNo = _uOESalesOrderNo;
            StockDB.Instance.Policy.UOESupplierCd = UOESupplier.RealUOESupplier.UOESupplierCd;
            // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<
            // 2010/10/19 >>>
            //int result = StockDB.Instance.Policy.Search();
            int result = StockDB.Instance.Policy.Search(InputMaker.Product);
            // 2010/10/19 <<<
            if (!result.Equals((int)Result.Code.Normal))
            {
                // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------>>>>>
                if (StockDB.Instance.Policy.HisLogOutSettingInfo.OutFlg)
                {
                    // ------ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応 ------<<<<<
                    // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------>>>>>
                    //操作履歴ログを登録
                    string logMsg = string.Format(CtLogDataMassage, _uOESalesOrderNo);
                    UoeOprtnHisLogAcs uoeOprtnHisLogAcs = new UoeOprtnHisLogAcs();
                    uoeOprtnHisLogAcs.logd_update(this, string.Empty, string.Empty, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, result, logMsg, UOESupplier.RealUOESupplier.UOESupplierCd);
                    WriteClcLogProc(CtLogOutputPgid, logMsg);
                    // ------ADD K2021/09/22 陳艶丹 PMKOBETSU-4189の対応 ------<<<<<
                }//ADD 2021/12/08 譚洪 卸商仕入受信処理 データ読込改善対応
                return result;
            }

            IList<OrderInformationBuilder> orderInfoBuilderList = new List<OrderInformationBuilder>();
            {
                // 2.UOE発注データの作成
                orderInfoBuilderList.Add(CreateUOEOrderDataBuilder());

                // 3.仕入明細データ（発注）の作成
                orderInfoBuilderList.Add(CreateStockDetailDataBuilder());

                // 4.仕入データ（発注）の作成
                orderInfoBuilderList.Add(CreateStockDataBuilder());
            }
            foreach (OrderInformationBuilder orderInfoBuilder in orderInfoBuilderList)
            {
                orderInfoBuilder.Merge();
            }

            // 仕入回答データ数
            int stockAnswerDataCount = StockDB.Instance.Policy.GetUOEOrderDataCount();
            {
                RaiseUpdateProgressEvent(new UpdateProgressEventArgs(
                    "仕入回答データ作成処理",   // LITERAL:
                    stockAnswerDataCount
                ));
            }

            return (int)Result.Code.Normal;
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

        #region <UOE発注データ/>

        /// <summary>
        /// UOE発注データの構築者を生成します。
        /// </summary>
        /// <returns>UOE発注データの構築者</returns>
        private UOEOrderDataBuilder CreateUOEOrderDataBuilder()
        {
            if (UOESupplier is UOEMeijiDecorator)
            {
                return new MeijiOrderDataBuilder(UOESupplier, InputMaker.Product, this);
            }
            else
            {
                return new SPKOrderDataBuilder(UOESupplier, InputMaker.Product, this);
            }
        }

        #endregion  // <UOE発注データ/>

        #region <仕入明細データ（発注）/>

        /// <summary>
        /// 仕入明細データ（発注）の構築者を生成します。
        /// </summary>
        /// <returns>仕入明細データ（発注）の構築者</returns>
        private OrderStockDetailDataBuilder CreateStockDetailDataBuilder()
        {
            return new OrderStockDetailDataBuilder(UOESupplier, InputMaker.Product, this);
        }

        #endregion  // <仕入明細データ（発注）/>

        #region <仕入データ（発注）/>

        /// <summary>
        /// 仕入データ（発注）の構築者を生成します。
        /// </summary>
        /// <returns>仕入データ（発注）の構築者</returns>
        private OrderStockDataBuilder CreateStockDataBuilder()
        {
            return new OrderStockDataBuilder(UOESupplier, InputMaker.Product, this);
        }

        #endregion  // <仕入データ（発注）/>
    }
}
