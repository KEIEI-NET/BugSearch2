//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/07/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11870080-00 作成担当 : 陳艶丹
// 作 成 日  2022/05/26  修正内容 : PMKOBETSU-4208 電子帳簿対応
//----------------------------------------------------------------------------//
using System;
using System.Threading;

using Broadleaf.Application.Controller.Other;
using Broadleaf.Application.Controller.Util;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 伝票印刷処理クラス
    /// </summary>
    public sealed class SCMSalesDataPrinter
    {
        #region <売伝リモートの書込み結果>

        /// <summary>売伝リモートの書込み結果</summary>
        private SalesSlipWriterParameter _writedSalesSlipParameter;
        /// <summary>売伝リモートの書込み結果を取得または設定します。</summary>
        public SalesSlipWriterParameter WritedSalesSlipParameter
        {
            get { return _writedSalesSlipParameter; }
            set { _writedSalesSlipParameter = value; }
        }

        #endregion // </売伝リモートの書込み結果>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SCMSalesDataPrinter() { }

        #endregion // </Constructor>

        /// <summary>
        /// 印刷します。
        /// </summary>
        /// <remarks>
        /// MAHNB01012AA.cs SalesSlipInputAcs.SaveDBData() 2315行目より移植
        /// </remarks>
        public void Print()
        {
            if (WritedSalesSlipParameter == null) return;

            SlipPrinter slipPrinter = new SlipPrinter(WritedSalesSlipParameter.ParaList);
            //------------------------------------------------------
            // 伝票印刷処理
            //------------------------------------------------------
        #if DEBUG
            slipPrinter.PrintSlipThread();
            return;
        #else
            Thread printSlipThread = new Thread(slipPrinter.PrintSlipThread);
            printSlipThread.Start();
            // --- ADD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
            //電帳.DXオプション有効の場合のみ(印刷スレッド順次実行)
            if (slipPrinter.Opt_PM_EBooks == (int)SlipPrinter.Option.ON) printSlipThread.Join();
            // --- UPD 陳艶丹 2022/05/26 PMKOBETSU-4208 電子帳簿対応---<<<<<
        #endif
        }
    }
}
