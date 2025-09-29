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
// 作 成 日  2009/10/14  修正内容 : 受信電文で、数値項目にスペースが入ってきた場合の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434　工藤 恵優
// 作 成 日  2010/06/10  修正内容 : 倉庫情報の検索は都度行う
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Text; // 2009/10/14 ADD


namespace Broadleaf.Application.Controller
{
    using GoodsDB = SingletonPolicy<GoodsDBAgent>;

    /// <summary>
    /// 発注情報の構築者クラス
    /// </summary>
    public abstract class OrderInformationBuilder
    {
        #region <簡易オブザーバー/>

        /// <summary>簡易オブザーバー</summary>
        private readonly IProgressUpdatable _observer;
        /// <summary>
        /// 簡易オブザーバーを取得します。
        /// </summary>
        protected IProgressUpdatable Observer { get { return _observer; } }

        #endregion  // <簡易オブザーバー/>

        #region <UOE発注先/>

        /// <summary>UOE発注先</summary>
        private readonly UOESupplierHelper _uoeSupplier;
        /// <summary>
        /// UOE発注先を取得します。
        /// </summary>
        /// <value>UOE発注先</value>
        protected UOESupplierHelper UoeSupplier { get { return _uoeSupplier; } }

        #endregion  // <UOE発注先/>

        #region <受信電文/>

        /// <summary>受信電文の集合体</summary>
        private readonly IAgreegate<ReceivedText> _receivedTelegramAgreegate;
        /// <summary>
        /// 受信電文の集合体を取得します。
        /// </summary>
        /// <value>受信電文の集合体</value>
        protected IAgreegate<ReceivedText> ReceivedTelegramAgreegate { get { return _receivedTelegramAgreegate; } }

        #endregion  // <受信電文/>

        #region <電話発注用行番号/>

        /// <summary>出荷伝票番号別の行番号カウンタマップ（キー：出荷伝票番号）</summary>
        private readonly IDictionary<string, int> _rowNoCounterOfTelOrderMap = new Dictionary<string, int>();
        /// <summary>
        /// 出荷伝票番号別の行番号カウンタマップ（キー：出荷伝票番号）を取得します。
        /// </summary>
        protected IDictionary<string, int> RowNoCounterOfTelOrderMap { get { return _rowNoCounterOfTelOrderMap; } }

        /// <summary>
        /// 行番号を取得します。（電話発注用）
        /// </summary>
        /// <param name="uoeSectionSlipNo">出荷伝票番号</param>
        /// <returns>
        /// 行番号
        /// （本メソッドを呼出し毎にインクリメントされます）
        /// </returns>
        protected int GetRowNoOfTelOrder(string uoeSectionSlipNo)
        {
            if (!RowNoCounterOfTelOrderMap.ContainsKey(uoeSectionSlipNo))
            {
                RowNoCounterOfTelOrderMap.Add(uoeSectionSlipNo.Trim(), 0);
            }
            int nextRowNo = ++RowNoCounterOfTelOrderMap[uoeSectionSlipNo];
            {
                RowNoCounterOfTelOrderMap[uoeSectionSlipNo] = nextRowNo;
            }
            return nextRowNo;
        }

        #endregion  // <電話発注用行番号/>

        /// <summary>
        /// 発注情報に受信電文の内容をマージします。
        /// </summary>
        public abstract void Merge();

        #region <ログイン拠点の倉庫コード(×3)で検索された在庫情報/>

        /// <summary>ログイン拠点の倉庫コード(×3)で検索された在庫情報</summary>
        private Stock _foundStockByFindingWarehouseCode;

        /// <summary>
        /// ログイン拠点の倉庫コード(×3)で在庫情報を検索します。
        /// </summary>
        /// <param name="receivedTelegram">受信電文</param>
        /// <returns>
        /// 以下の条件で検索された在庫情報<br/>
        /// ・ログイン拠点の倉庫コード(×3)<br/>
        /// ・受信電文の出荷部品番号<br/>
        /// ・受信電文のメーカーコード<br/>
        /// なお、倉庫コード1～3の順に検索が行われ、最初に検索された在庫情報を返します。<br/>
        /// また、該当する在庫情報がなかった場合、<c>null</c>を返します。
        /// </returns>
        protected Stock FindStockBy3WarehouseCodes(ReceivedText receivedTelegram)
        {
            // DEL 2010/06/10 倉庫情報の検索は都度行う ---------->>>>>
            //if (_foundStockByFindingWarehouseCode != null) return _foundStockByFindingWarehouseCode;
            // DEL 2010/06/10 倉庫情報の検索は都度行う ----------<<<<<

            _foundStockByFindingWarehouseCode = GoodsDB.Instance.Policy.FindFirstStockByLoginWorkers3WarehouseCodes(
                // 2009/10/14 >>>
                //int.Parse(receivedTelegram.AnswerMakerCode),
                TStrConv.StrToIntDef(receivedTelegram.AnswerMakerCode.Trim(), 0),
                // 2009/10/14 <<<
                receivedTelegram.AnswerPartsNo
            );

            return _foundStockByFindingWarehouseCode;
        }

        #endregion  // <ログイン拠点の倉庫コード(×3)で検索された在庫情報/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        /// <param name="receivedTelegramAgreegate">受信電文の集合体</param>
        /// <param name="observer">簡易オブザーバー</param>
        protected OrderInformationBuilder(
            UOESupplierHelper uoeSupplier,
            IAgreegate<ReceivedText> receivedTelegramAgreegate,
            IProgressUpdatable observer
        )
        {
            _uoeSupplier = uoeSupplier;
            _receivedTelegramAgreegate = receivedTelegramAgreegate;
            _observer = observer;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// 終端文字を削除します。
        /// </summary>
        /// <param name="str">文字列</param>
        /// <returns>終端文字を削除した文字列</returns>
        protected static string TrimEndCode(string str)
        {
            StringBuilder ret = new StringBuilder();
            {
                char[] charArray = str.ToCharArray();
                foreach (char aChar in charArray)
                {
                    if (aChar.Equals('\0')) break;
                    ret.Append(aChar);
                }
            }
            return ret.ToString();
        }
    }
}
