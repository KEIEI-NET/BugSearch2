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
// 管理番号  10902931-00 作成担当 : 鄧潘ハン
// 作 成 日  2013/08/15  修正内容 : 卸商受信処理(手動)処理の追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using StockDB = SingletonPolicy<StockDBAgent>;
    using Broadleaf.Application.Resources;
    using Broadleaf.Application.Common;
    using System.Threading;

    /// <summary>
    /// 回答表示Controllerクラス
    /// </summary>
    /// <br>Update Note: 2013/08/15 鄧潘ハン</br>
    /// <br>             卸商受信処理(手動)処理の追加</br>
    public sealed class ShowAnswerAcs : OroshishoStockReceptionController
    {
        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        public ShowAnswerAcs(UOESupplierHelper uoeSupplier) : base(uoeSupplier) { }

        #endregion  // <Constructor/>

        #region <Override/>

        // 2009/10/09 Add >>>
        public override Result.ProcessID ProcessID { get { return Result.ProcessID.ShowAnswer; } }
        // 2009/10/09 Add <<<



        // ---- ADD 2013/08/15 譚洪 ---- >>>>>
        //Thread中、回答表示関係
        private const string ORDERSNDRCVJNLLISTTRD = "ORDERSNDRCVJNLLIST";
        private LocalDataStoreSlot orderSndRcvJnlListTrd = null;
        //Thread中、メッセージ関係
        private const string MSGSHOWSOLT = "MSGSHOWSOLT";
        private LocalDataStoreSlot msgShowSolt = null;

        #region ■列挙体
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効ユーザ</summary>
            OFF = 0,
            /// <summary>有効ユーザ</summary>
            ON = 1,
        }
        #endregion

        /// <summary>テキスト出力オプション情報</summary>
        private int _opt_FuTaBa;//OPT-CPM0110：フタバUOEオプション（個別）

        //専用USB用
        Broadleaf.Application.Remoting.ParamData.PurchaseStatus fuTaBaPs;
        // ---- ADD 2013/08/15 譚洪 ---- <<<<<

        /// <summary>
        /// 処理を実行します。
        /// </summary>
        /// <returns>結果コード</returns>
        /// <see cref="OroshishoStockReceptionController"/>
        public override int Execute()
        {
            try
            {
                List<OrderSndRcvJnl> orderSndRcvJnlList = StockDB.Instance.Policy.OrderSndRcvJnlList;

                // ---- ADD 2013/08/15 譚洪 ---- >>>>>
                //OPT-CPM0110：フタバUOEオプション（個別）
                fuTaBaPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
                if (fuTaBaPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                {
                    this._opt_FuTaBa = (int)Option.ON;
                }
                else
                {
                    this._opt_FuTaBa = (int)Option.OFF;
                }
                //フタバUSB専用
                if (this._opt_FuTaBa == (int)Option.ON)
                {
                    msgShowSolt = Thread.GetNamedDataSlot(MSGSHOWSOLT);

                    //卸商受信処理(手動)である場合
                    if (Thread.GetData(msgShowSolt) != null && (Int32)Thread.GetData(msgShowSolt) == 4)
                    {
                        Thread.FreeNamedDataSlot(ORDERSNDRCVJNLLISTTRD);
                        orderSndRcvJnlListTrd = Thread.AllocateNamedDataSlot(ORDERSNDRCVJNLLISTTRD);
                        Thread.SetData(orderSndRcvJnlListTrd, orderSndRcvJnlList);
                    }
                    else
                    {
                        Broadleaf.Windows.Forms.PMUOE01351UA answerView = new Broadleaf.Windows.Forms.PMUOE01351UA(
                            orderSndRcvJnlList
                        );
                        {
                            answerView.ShowDialog();    // モーダルで表示
                        }
                    }
                }
                else
                {
                    Broadleaf.Windows.Forms.PMUOE01351UA answerView = new Broadleaf.Windows.Forms.PMUOE01351UA(
                      orderSndRcvJnlList
                    );
                    {
                        answerView.ShowDialog();    // モーダルで表示
                    }
                }
                // ---- ADD 2013/08/15 譚洪 ---- <<<<<
                // ---- DEL 2013/08/15 譚洪 ---- >>>>>
                //Broadleaf.Windows.Forms.PMUOE01351UA answerView = new Broadleaf.Windows.Forms.PMUOE01351UA(
                //    orderSndRcvJnlList
                //);
                //{
                //    answerView.ShowDialog();    // モーダルで表示
                //}
                // ---- DEL 2013/08/15 譚洪 ---- <<<<<

                return (int)Result.Code.Normal;
            }
            catch (Exception e)
            {
                Debug.Assert(false, e.ToString());
                return (int)Result.Code.Error;
            }
        }

        #endregion  // <Override/>
    }
}
