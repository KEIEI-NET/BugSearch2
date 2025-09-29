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
// 作 成 日  2009/07/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNSの劉立
// 作 成 日  2011/08/10  修正内容 : 自動回答対応、SCMセットマスタ送信できるため
//　　　　　　　　　　　　　　　　　カスタムコンストラクタを追加する
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// 売伝リモートパラメータの伝票項目のラッパークラス
    /// </summary>
    public sealed class SalesSlipWriterItem
    {
        #region <売上伝票項目リスト>

        /// <summary>売上伝票項目リスト</summary>
        private readonly CustomSerializeArrayList _salesSlipItemList;
        /// <summary>売上伝票項目リストを取得します。</summary>
        private CustomSerializeArrayList SalesSlipItemList { get { return _salesSlipItemList; } }

        #endregion // </売上伝票項目リスト>

        #region <売上データ>

        /// <summary>売上データ</summary>
        private SalesSlipWork _salesSlip;
        /// <summary>売上データを取得します。</summary>
        private SalesSlipWork SalesSlip
        {
            get
            {
                if (_salesSlip == null)
                {
                    _salesSlip = ListUtil.FindFirstFrom<SalesSlipWork>(SalesSlipItemList);
                }
                return _salesSlip;
            }
        }

        #endregion // </売上データ>

        #region <SCM受注データ>

        /// <summary>SCM受注データ</summary>
        private SCMAcOdrDataWork _scmOrderData;
        /// <summary>SCM受注データを取得します。</summary>
        public SCMAcOdrDataWork SCMOrderData
        {
            get
            {
                if (_scmOrderData == null)
                {
                    _scmOrderData = ListUtil.FindFirstFrom<SCMAcOdrDataWork>(SalesSlipItemList);
                }
                return _scmOrderData;
            }
        }

        #endregion // </SCM受注データ>

        #region <SCM受注データ(車両情報)>

        /// <summary>SCM受注データ(車両情報)</summary>
        private SCMAcOdrDtCarWork _scmOrderCarData;
        /// <summary>SCM受注データ(車両情報)を取得します。</summary>
        public SCMAcOdrDtCarWork SCMOrderCarData
        {
            get
            {
                if (_scmOrderCarData == null)
                {
                    _scmOrderCarData = ListUtil.FindFirstFrom<SCMAcOdrDtCarWork>(SalesSlipItemList);
                }
                return _scmOrderCarData;
            }
        }

        #endregion // </SCM受注データ(車両情報)>

        #region <SCM受注明細データ(問合せ・発注)>

        /// <summary>SCM受注明細データ(問合せ・発注)のリスト</summary>
        private IList<SCMAcOdrDtlIqWork> _scmOrderDataDetailList;
        /// <summary>SCM受注明細データ(問合せ・発注)のリストを取得します。</summary>
        public IList<SCMAcOdrDtlIqWork> SCMOrderDataDetailList
        {
            get
            {
                if (_scmOrderDataDetailList == null)
                {
                    _scmOrderDataDetailList = GetChildList<SCMAcOdrDtlIqWork>(SalesSlipItemList);
                }
                return _scmOrderDataDetailList;
            }
        }

        #endregion // </SCM受注明細データ(問合せ・発注)>

        #region <SCM受注明細データ(回答)>

        /// <summary>SCM受注明細データ(回答)のリスト</summary>
        private IList<SCMAcOdrDtlAsWork> _scmOrderDataAnswerList;
        /// <summary>SCM受注明細データ(回答)のリストを取得します。</summary>
        public IList<SCMAcOdrDtlAsWork> ScmOrderDataAnswerList
        {
            get
            {
                if (_scmOrderDataAnswerList == null)
                {
                    _scmOrderDataAnswerList = GetChildList<SCMAcOdrDtlAsWork>(SalesSlipItemList);
                }
                return _scmOrderDataAnswerList;
            }
        }

        #endregion // </SCM受注明細データ(回答)>

        // -- ADD 2011/08/10   ------ >>>>>>
        #region <SCMセット部品データ>

        /// <summary>
        /// SCMセット部品データのリスト
        /// </summary>
        private IList<SCMAcOdSetDtWork> _scmOrderDataSetDtList;

        /// <summary>
        /// SCMセット部品データのリストを取得します。
        /// </summary>
        public IList<SCMAcOdSetDtWork> ScmOrderDataSetDtList
        {
            get
            {
                if (_scmOrderDataSetDtList == null)
                {
                    _scmOrderDataSetDtList = GetChildList<SCMAcOdSetDtWork>(SalesSlipItemList);
                }
                return _scmOrderDataSetDtList;
            }
        }

        #endregion // </SCMセット部品データ>
        // -- ADD 2011/08/10   ------ <<<<<<
        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="slipItemList">伝票項目リスト</param>
        public SalesSlipWriterItem(CustomSerializeArrayList slipItemList)
        {
            _salesSlipItemList = slipItemList;
        }

        #endregion // </Constructor>

        /// <summary>
        /// 明細系サブデータリストを取得します。
        /// </summary>
        /// <typeparam name="T">明細系サブデータの型</typeparam>
        /// <param name="parentList">親リスト</param>
        /// <returns>明細系サブデータリスト</returns>
        private static IList<T> GetChildList<T>(ArrayList parentList) where T : class
        {
            IList<T> foundList = null;
            {
                foreach (object item in parentList)
                {
                    if (item is ArrayList)
                    {
                        if (ListUtil.IsNullOrEmpty((ArrayList)item)) continue;

                        if (((ArrayList)item)[0] is T)
                        {
                            foundList = ListUtil.FindFrom<T>((ArrayList)item);
                            break;
                        }
                    }
                }
            }
            return foundList ?? new List<T>();
        }
    }
}
