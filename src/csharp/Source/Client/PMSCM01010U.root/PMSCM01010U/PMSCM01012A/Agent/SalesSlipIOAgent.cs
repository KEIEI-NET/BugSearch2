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
// 作 成 日  2009/06/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/04/05  修正内容 : 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/04/11  修正内容 : 高速化対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Controller.Other;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData.Util;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller.Agent
{
    // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
    using SalesDetailTuple = Tuple<
        List<SalesDetailWork>,  // 売上明細データ
        List<AcceptOdrCarWork>, // 
        List<StockSlipWork>,    // 仕入データ
        List<StockDetailWork>,  // 仕入明細データ
        List<UOEOrderDtlWork>,  // UOE受注データ
        NullObject,
        NullObject,
        NullObject,
        NullObject,
        NullObject
    >;
    // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<

    /// <summary>
    /// 売上伝票入力のI/Oアクセスの代理人クラス
    /// </summary>
    public static class SalesSlipIOAgent
    {
        /// <summary>
        /// 書込みます。
        /// </summary>
        /// <param name="salesData">売上データ</param>
        /// <param name="writeFlg">DB更新フラグ</param>
        /// <returns>Key:結果コード/Value:売伝リモートの書込み結果</returns>
        //>>>2012/04/11
        //public static KeyValuePair<int, object> Write(CustomSerializeArrayList salesData)
        public static KeyValuePair<int, object> Write(CustomSerializeArrayList salesData, bool writeFlg)
        //<<<2012/04/11
        {
            #region <Guard Phrase>

            if (salesData == null || salesData.Count <= 1)
            {
                return new KeyValuePair<int, object>((int)ResultUtil.ResultCode.Normal, null);
            }

            #endregion // </Guard Phrase>

            // 1パラ目
            object paraList = (object)salesData;

            // 2パラ目
            string msg = string.Empty;

            // 3パラ目
            string itemInfo = string.Empty;

            IIOWriteControlDB writer = MediationIOWriteControlDB.GetIOWriteControlDB();

            //>>>2012/04/11
            //int status = writer.Write(
            //    ref paraList,
            //    out msg,
            //    out itemInfo
            //);
            int status = 0;

            if (writeFlg)
            {
                status = writer.Write(
                    ref paraList,
                    out msg,
                    out itemInfo
                );
            }
            //<<<2012/04/11

            if ( !status.Equals( (int)ResultUtil.ResultCode.Normal ) )
            {
                Debug.WriteLine(msg + "[" + itemInfo + "]");
            }

            return new KeyValuePair<int, object>(status, paraList);
        }
    }

    // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
    /// <summary>
    /// 売上明細データアクセスの代理人クラス
    /// </summary>
    public sealed class SalesDetailAgent
    {
        #region 売上明細データのマップ

        /// <summary>売上明細データのマップ</summary>
        private readonly Dictionary<string, SalesDetailTuple> _salesDetailMap = new Dictionary<string, SalesDetailTuple>();
        /// <summary>売上明細データのマップを取得します。</summary>
        /// <remarks>キー：企業コード + 拠点コード + 受注ステータス + 売上伝票番号 + 売上明細行番号</remarks>
        private Dictionary<string, SalesDetailTuple> SalesDetailMap { get { return _salesDetailMap; } }

        /// <summary>
        /// キーを取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="salesRowNo">売上明細行番号</param>
        /// <returns>企業コード + 拠点コード + 受注ステータス + 売上伝票番号 + 売上明細行番号</returns>
        private static string GetKey(
            string enterpriseCode,
            string sectionCode,
            int acptAnOdrStatus,
            string salesSlipNum,
            int salesRowNo
        )
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(SCMEntityUtil.FormatEnterpriseCode(enterpriseCode));
                key.Append(SCMEntityUtil.FormatSectionCode(sectionCode));
                key.Append(acptAnOdrStatus.ToString("00"));
                key.Append(salesSlipNum.PadLeft(9, '0'));
                key.Append(salesRowNo.ToString("000"));
            }
            return key.ToString();
        }

        #endregion // 売上明細データのマップ

        #region Constructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SalesDetailAgent() { }

        #endregion // Constructor

        /// <summary>
        /// 売上明細データを検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="salesRowNo">売上明細行番号</param>
        /// <param name="detailWorkArray">売上明細データ</param>
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）</param>
        /// <returns>該当する売上明細データ配列 ※該当データがない場合、空(サイズ0)の売上明細データ配列を返します</returns>
        // 2011/02/09 >>>
        //public SalesDetailWork[] FindSalesDetails(
        //    string enterpriseCode,
        //    string sectionCode,
        //    int acptAnOdrStatus,
        //    string salesSlipNum,
        //    int salesRowNo
        //)

        public void FindSalesDetailInfo(
            string enterpriseCode,
            string sectionCode,
            int acptAnOdrStatus,
            string salesSlipNum,
            int salesRowNo,
            out SalesDetailWork[] detailWorkArray,
            out AcceptOdrCarWork[] acceptOdrCarWorkArray
        )
        // 2011/02/09 <<<
        {
            // 2011/02/09 Add >>>
            detailWorkArray = null;
            acceptOdrCarWorkArray = null;
            // 2011/02/09 Add <<<

            string key = GetKey(enterpriseCode, sectionCode, acptAnOdrStatus, salesSlipNum, salesRowNo);
            if (SalesDetailMap.ContainsKey(key))
            {
                // 2011/02/09 >>>
                //return SalesDetailMap[key].Member01.ToArray();
                detailWorkArray = SalesDetailMap[key].Member01.ToArray();
                acceptOdrCarWorkArray = SalesDetailMap[key].Member02.ToArray();
                // 2011/02/09 <<<
            }
            // 2011/02/09 >>>
            //OtherAppComponent otherApp = new OtherAppComponent(enterpriseCode, sectionCode);
            //SalesDetailTuple salesDetailTuple = otherApp.SearchSalesDetail(acptAnOdrStatus, salesSlipNum, salesRowNo);
            //SalesDetailMap.Add(key, salesDetailTuple);

            //return salesDetailTuple.Member01.ToArray();
            else
            {
                OtherAppComponent otherApp = new OtherAppComponent(enterpriseCode, sectionCode);
                SalesDetailTuple salesDetailTuple = otherApp.SearchSalesDetail(acptAnOdrStatus, salesSlipNum, salesRowNo);
                SalesDetailMap.Add(key, salesDetailTuple);

                detailWorkArray = salesDetailTuple.Member01.ToArray();
                acceptOdrCarWorkArray = salesDetailTuple.Member02.ToArray();
            }
            // 2011/02/09 <<<
        }
    }
    // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<
}
