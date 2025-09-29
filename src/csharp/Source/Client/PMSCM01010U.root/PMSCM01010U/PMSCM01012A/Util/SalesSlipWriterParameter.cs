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
//#define _ENABLED_DETAIL_    // SCM受注明細データ(問合せ・発注)書込みの有効フラグ

using System;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// 売伝リモートパラメータのラッパークラス
    /// </summary>
    public sealed class SalesSlipWriterParameter
    {
        #region <売伝リモートパラメータ>

        /// <summary>売伝リモートパラメータ</summary>
        private readonly CustomSerializeArrayList _paraList;
        /// <summary>売伝リモートパラメータを取得します。</summary>
        public CustomSerializeArrayList ParaList { get { return _paraList; } }

        #endregion // </売伝リモートパラメータ>

        #region <売上伝票項目>

        /// <summary>売上伝票項目リスト</summary>
        private IList<SalesSlipWriterItem> _salesSlipItemList;
        /// <summary>売上伝票項目リストを取得します。</summary>
        public IList<SalesSlipWriterItem> SalesSlipItemList
        {
            get
            {
                if (_salesSlipItemList == null)
                {
                    _salesSlipItemList = CreateSalesSlipList();
                }
                return _salesSlipItemList;
            }
        }

        /// <summary>
        /// 売上伝票項目リストを生成します。
        /// </summary>
        /// <returns>売上伝票項目リスト</returns>
        private IList<SalesSlipWriterItem> CreateSalesSlipList()
        {
            IList<SalesSlipWriterItem> salesSlipList = new List<SalesSlipWriterItem>();
            {
                foreach (object item in ParaList)
                {
                    if (item is CustomSerializeArrayList)
                    {
                        salesSlipList.Add(new SalesSlipWriterItem((CustomSerializeArrayList)item));
                    }
                }
            }
            return salesSlipList;
        }

        #endregion // </売上伝票項目>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="paraList">売伝リモートパラメータ</param>
        public SalesSlipWriterParameter(CustomSerializeArrayList paraList)
        {
            _paraList = paraList;
        }

        #endregion // </Constructor>

        #region <SCM I/O Writer用パラメータ>

        /// <summary>
        /// SCM I/O Writer用のパラメータに変換します。
        /// </summary>
        /// <returns>SCM I/O Writer用のパラメータ</returns>
        public CustomSerializeArrayList ToSCMIOWriterParameter()
        {
            return ConvertSCMIOWriterParameter(this);
        }

        /// <summary>
        /// SCM I/O Writer用のパラメータに変換します。
        /// </summary>
        /// <param name="salesSlipWriterParameter">売伝リモートパラメータ</param>
        /// <returns>SCM I/O Writer用のパラメータ</returns>
        private static CustomSerializeArrayList ConvertSCMIOWriterParameter(SalesSlipWriterParameter salesSlipWriterParameter)
        {
            CustomSerializeArrayList parameter = new CustomSerializeArrayList();
            {
                foreach (SalesSlipWriterItem salesSlipItem in salesSlipWriterParameter.SalesSlipItemList)
                {
                    if (salesSlipItem.SCMOrderData == null) continue;

                    CustomSerializeArrayList oneSCMOrderList = new CustomSerializeArrayList();
                    {
                        // SCM受注データ
                        oneSCMOrderList.Add(salesSlipItem.SCMOrderData);

                        // SCM受注データ(車両情報)
                        oneSCMOrderList.Add(salesSlipItem.SCMOrderCarData);

                    #if _ENABLED_DETAIL_
                        // SCM受注明細データ(問合せ・発注)
                        ArrayList detailRecordList = new ArrayList();
                        {
                            foreach (SCMAcOdrDtlIqWork detailData in salesSlipItem.SCMOrderDataDetailList)
                            {
                                detailRecordList.Add(detailData);
                            }
                        }
                        oneSCMOrderList.Add(detailRecordList);
                    #endif

                        // SCM受注明細データ(回答)
                        ArrayList answerRecordList = new ArrayList();
                        {
                            foreach (SCMAcOdrDtlAsWork answerData in salesSlipItem.ScmOrderDataAnswerList)
                            {
                                answerRecordList.Add(answerData);
                            }
                        }
                        oneSCMOrderList.Add(answerRecordList);
                    }   // CustomSerializeArrayList oneSCMOrderList = new CustomSerializeArrayList();
                    parameter.Add(oneSCMOrderList);
                }
            }
            return parameter;
        }

        #endregion // </SCM I/O Writer用パラメータ>
    }
}
