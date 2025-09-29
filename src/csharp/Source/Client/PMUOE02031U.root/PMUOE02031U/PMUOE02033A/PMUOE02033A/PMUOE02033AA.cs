//****************************************************************************//
// システム         : 送信前リスト
// プログラム名称   : 送信前リスト テーブルアクセスクラス
// プログラム概要   : 送信前リスト テーブルアクセスクラスを実装します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/09/11  修正内容 : MAHNB02015A：入金確認表を参考に新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.ReportData;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 送信前リスト テーブルアクセスクラス
    /// </summary>
    public sealed class SendBeforeAcs
    {
        #region <ログイン従業員/>

        /// <summary>ログイン従業員</summary>
        private static readonly Employee _loginEmployee;
        /// <summary>
        /// ログイン従業員を取得します。
        /// </summary>
        /// <value>ログイン従業員</value>
        private static Employee LoginEmployee { get { return SendBeforeAcs._loginEmployee; } }

        #endregion  // <ログイン従業員/>

        #region <帳票出力設定/>

        /// <summary>帳票出力設定データ</summary>
        private static PrtOutSet _printtOutSet;

        /// <summary>帳票出力設定アクセス</summary>
        private static readonly PrtOutSetAcs _printOutSetAcs;
        /// <summary>
        /// 帳票出力設定アクセスを取得します。
        /// </summary>
        /// <value>帳票出力設定アクセス</value>
        private static PrtOutSetAcs PrintOutSetAcs { get { return _printOutSetAcs; } }

        #endregion  // <帳票出力設定/>

        #region <送信前リストDBリモート/>

        /// <summary>送信前リストDBリモート</summary>
        private readonly ISendBeforOrdeWorkDB _sendBeforeDBRemote;
        /// <summary>
        /// 送信前リストDBリモートを取得します。
        /// </summary>
        /// <value>送信前リストDBリモート</value>
        private ISendBeforOrdeWorkDB SendBeforeDBRemote { get { return _sendBeforeDBRemote; } }

        #endregion  // <送信前リストDBリモート/>

        #region <検索結果/>

        /// <summary>送信前リストDBの検索結果のデータテーブル名</summary>
        private const string SEARCHED_DATA_TABLE_NAME = "SendBefore";   // TODO:テーブル名を変更した場合、本定数も変更すること
        /// <summary>
        /// 送信前リストDBの検索結果のデータテーブル名を取得します。
        /// </summary>
        /// <value>送信前リストDBの検索結果のデータテーブル名</value>
        public static string SearchedDataTableName { get { return SEARCHED_DATA_TABLE_NAME; } }

        /// <summary>送信前リストDBの検索結果</summary>
        private SendBeforeDataSet _searchedResult;
        /// <summary>
        /// 送信前リストDBの検索結果を取得します。
        /// </summary>
        /// <value>送信前リストDBの検索結果</value>
        public SendBeforeDataSet SearchedResult
        {
            get
            {
                if (_searchedResult == null)
                {
                    _searchedResult = new SendBeforeDataSet();
                }
                return _searchedResult;
            }
        }

        #endregion  // <検索結果/>

        #region <Constructor/>

        /// <summary>
        /// 静的コンストラクタ
        /// </summary>
        static SendBeforeAcs()
        {
            // ログイン従業員
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null) _loginEmployee = loginEmployee;

            // 帳票出力設定データ
            _printtOutSet = null;

            // 帳票出力設定アクセス
            _printOutSetAcs = new PrtOutSetAcs();
        }

		/// <summary>
        /// デフォルトコンストラクタ
		/// </summary>
		public SendBeforeAcs()
		{
            _sendBeforeDBRemote = (ISendBeforOrdeWorkDB)MediationSendBeforOrderWorkDB.GetSendBeforOrderWorkDB();
        }

		#endregion  // <Constructor/>

        #region <帳票設定データ取得/>

        /// <summary>
        /// 自拠点の帳票出力設定の読込を行います。
        /// </summary>
        /// <remarks>
        /// PMUOE02034Pより呼ばれます。
        /// </remarks>
        /// <param name="prtOutSet">帳票出力設定データ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>結果コード</returns>
        public static int ReadPrtOutSet(
            out PrtOutSet prtOutSet,
            out string errMsg
        )
        {
            prtOutSet = new PrtOutSet();
            errMsg = string.Empty;
            try
            {
                // データは読込済みか？
                if (_printtOutSet != null)
                {
                    prtOutSet = _printtOutSet.Clone();
                    return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    int status = PrintOutSetAcs.Read(
                        out _printtOutSet,
                        LoginInfoAcquisition.EnterpriseCode,
                        LoginEmployee.BelongSectionCode
                    );
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            prtOutSet = _printtOutSet.Clone();
                            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        default:
                            errMsg = "帳票出力設定の読込に失敗しました";    // LITERAL:
                            return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                prtOutSet = new PrtOutSet();
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
        }

        #endregion  // <帳票設定データ取得/>

        #region <送信前リスト検索/>

        /// <summary>
        /// 送信前リストを検索します。
        /// </summary>
        /// <param name="extractingCondition">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>結果コード</returns>
        public int SearchSendBeforeList(
            SendBeforeOrderCondition extractingCondition,
            out string errMsg
        )
        {
            return SearchSendBeforeListProc(extractingCondition, out errMsg);
        }

        /// <summary>
        /// 送信前リストを検索します。
        /// </summary>
        /// <param name="extractingCondition">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>結果コード</returns>
        private int SearchSendBeforeListProc(
            SendBeforeOrderCondition extractingCondition,
            out string errMsg
        )
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;

            try
            {
                ArrayList sendBeforeResultWorkList = new ArrayList();
                object objSendBeforeResultWorkList = (object)sendBeforeResultWorkList;
                object objSendBeforeOrderCondition = (object)extractingCondition.CreateSendBeforOrderCndtnWork();
                
                status = SendBeforeDBRemote.Search(
                    out objSendBeforeResultWorkList,
                    objSendBeforeOrderCondition,
                    0,  // HACK:readMode
                    ConstantManagement.LogicalMode.GetData0
                );
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // 検索結果を展開
                        sendBeforeResultWorkList = (ArrayList)objSendBeforeResultWorkList;  // MEMO:リモート側でnewされる
                        InitializeSearchedResult(extractingCondition, sendBeforeResultWorkList);

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "送信前リストデータの取得に失敗しました。";    // LITERAL:
                        break;
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// 検索結果を初期化します。
        /// </summary>
        /// <param name="extractingCondition">抽出条件</param>
        /// <param name="searchedRecordList">検索されたレコードのリスト</param>
        /// <returns>Status</returns>
        private void InitializeSearchedResult(
            SendBeforeOrderCondition extractingCondition,
            ArrayList searchedRecordList
        )
        {
            Debug.WriteLine("検索数：" + searchedRecordList.Count.ToString());

            SendBeforeDataSet searchedDataSet = new SendBeforeDataSet();
            foreach (object searchedRecord in searchedRecordList)
            {
                SendBeforResultWork searchedResult = (SendBeforResultWork)searchedRecord;
                PrintsSearchedResult(searchedResult);

                searchedDataSet.SendBefore.AddSendBeforeRow(
                    searchedResult.SectionCode,
                    searchedResult.SectionGuideSnm,
                    searchedResult.UOESupplierCd,
                    searchedResult.UOESupplierName,
                    searchedResult.OnlineNo,
                    searchedResult.CustomerCode,
                    searchedResult.EmployeeCode,
                    searchedResult.GoodsNo,
                    searchedResult.GoodsName,
                    searchedResult.GoodsMakerCd,
                    searchedResult.AcceptAnOrderCnt,
                    searchedResult.BoCode,
                    searchedResult.UoeRemark1,
                    searchedResult.UoeRemark2,
                    searchedResult.UOEDeliGoodsDiv,
                    searchedResult.FollowDeliGoodsDiv,
                    searchedResult.UOEResvdSection,
                    (int)extractingCondition.PrintOrder
                );
            }

            // テーブルをソート
            StringBuilder orderBy = new StringBuilder(SendBeforeDataSet.ClmIdx.SectionCode.ToString());
            switch (extractingCondition.PrintOrder)
            {
                case SendBeforeOrderCondition.PrintOrderType.ByOnlineNo:        // 注文番号別
                {
                    orderBy.Append(ADOUtil.COMMA);
                    orderBy.Append(SendBeforeDataSet.ClmIdx.OnlineNo.ToString());       // 注文番号
                    orderBy.Append(ADOUtil.COMMA);
                    orderBy.Append(SendBeforeDataSet.ClmIdx.CustomerCode.ToString());   // 得意先
                    orderBy.Append(ADOUtil.COMMA);
                    orderBy.Append(SendBeforeDataSet.ClmIdx.EmployeeCode.ToString());   // 依頼者
                    orderBy.Append(ADOUtil.COMMA);
                    orderBy.Append(SendBeforeDataSet.ClmIdx.UOESupplierCd.ToString());  // 発注先
                    break;
                }
                case SendBeforeOrderCondition.PrintOrderType.ByUOESupplierCode: // 発注先別
                {
                    orderBy.Append(ADOUtil.COMMA);
                    orderBy.Append(SendBeforeDataSet.ClmIdx.UOESupplierCd.ToString());  // 発注先
                    orderBy.Append(ADOUtil.COMMA);
                    orderBy.Append(SendBeforeDataSet.ClmIdx.OnlineNo.ToString());       // 注文番号
                    orderBy.Append(ADOUtil.COMMA);
                    orderBy.Append(SendBeforeDataSet.ClmIdx.CustomerCode.ToString());   // 得意先
                    orderBy.Append(ADOUtil.COMMA);
                    orderBy.Append(SendBeforeDataSet.ClmIdx.EmployeeCode.ToString());   // 依頼者
                    break;
                }
            }
            SendBeforeDataSet.SendBeforeRow[] sortedDataRows = ADOUtil.ConvertAll<SendBeforeDataSet.SendBeforeRow>(
                searchedDataSet.SendBefore.Select(string.Empty, orderBy.ToString())
            );
            Debug.WriteLine("ソート順：" + orderBy.ToString());

            // TODO:検索結果を更新 ※もっと効率のいい実装方法があるのでは？
            SearchedResult.Clear();
            foreach (SendBeforeDataSet.SendBeforeRow searchedDataRow in sortedDataRows)
            {
                SearchedResult.SendBefore.AddSendBeforeRow(
                    searchedDataRow.SectionCode,
                    searchedDataRow.SectionGuideSnm,
                    searchedDataRow.UOESupplierCd,
                    searchedDataRow.UOESupplierName,
                    searchedDataRow.OnlineNo,
                    searchedDataRow.CustomerCode,
                    searchedDataRow.EmployeeCode,
                    searchedDataRow.GoodsNo,
                    searchedDataRow.GoodsName,
                    searchedDataRow.GoodsMakerCd,
                    searchedDataRow.AcceptAnOrderCnt,
                    searchedDataRow.BoCode,
                    searchedDataRow.UoeRemark1,
                    searchedDataRow.UoeRemark2,
                    searchedDataRow.UOEDeliGoodsDiv,
                    searchedDataRow.FollowDeliGoodsDiv,
                    searchedDataRow.UOEResvdSection,
                    searchedDataRow.PrintOrder
                );
                PrintSearchedDataRow(searchedDataRow);
            }
        }

        #endregion  // <送信前リスト検索/>

        #region <Debug/>

        /// <summary>
        /// 検索結果を表示します。
        /// </summary>
        /// <param name="searchedResult">検索結果</param>
        [Conditional("DEBUG")]
        private static void PrintsSearchedResult(SendBeforResultWork searchedResult)
        {
            Debug.Write("拠点コード：" + searchedResult.SectionCode + ",");
            //searchedResult.SectionGuideSnm,
            //Debug.Write("発注先：" + searchedResult.UOESupplierCd + ",");
            //searchedResult.UOESupplierName,
            Debug.Write("発注番号：" + searchedResult.OnlineNo + ",");
            Debug.Write("得意先コード：" + searchedResult.CustomerCode + ",");
            Debug.Write("依頼者：" + searchedResult.EmployeeCode + ",");
            //searchedResult.GoodsNo,
            //searchedResult.GoodsName,
            //searchedResult.GoodsMakerCd,
            //searchedResult.AcceptAnOrderCnt,
            //searchedResult.BoCode,
            //searchedResult.UoeRemark1,
            //searchedResult.UoeRemark2,
            //searchedResult.UOEDeliGoodsDiv,
            //searchedResult.FollowDeliGoodsDiv,
            //searchedResult.UOEResvdSection,
            //(int)extractingCondition.PrintOrder
            Debug.WriteLine("発注先：" + searchedResult.UOESupplierCd + ",");
        }

        /// <summary>
        /// 検索結果を表示します。
        /// </summary>
        /// <param name="searchedDataRow">検索結果</param>
        [Conditional("DEBUG")]
        private static void PrintSearchedDataRow(SendBeforeDataSet.SendBeforeRow searchedDataRow)
        {
            Debug.Write("拠点コード：" + searchedDataRow.SectionCode + ",");
            //searchedDataRow.SectionGuideSnm,
            //Debug.Write("発注先：" + searchedDataRow.UOESupplierCd + ",");
            //searchedDataRow.UOESupplierName,
            Debug.Write("発注番号：" + searchedDataRow.OnlineNo + ",");
            Debug.Write("得意先コード：" + searchedDataRow.CustomerCode + ",");
            Debug.Write("依頼者：" + searchedDataRow.EmployeeCode + ",");
            //searchedDataRow.GoodsNo,
            //searchedDataRow.GoodsName,
            //searchedDataRow.GoodsMakerCd,
            //searchedDataRow.AcceptAnOrderCnt,
            //searchedDataRow.BoCode,
            //searchedDataRow.UoeRemark1,
            //searchedDataRow.UoeRemark2,
            //searchedDataRow.UOEDeliGoodsDiv,
            //searchedDataRow.FollowDeliGoodsDiv,
            //searchedDataRow.UOEResvdSection,
            //(int)extractingCondition.PrintOrder
            Debug.WriteLine("発注先：" + searchedDataRow.UOESupplierCd + ",");
        }

        #endregion  // <Debug/>
    }
}
