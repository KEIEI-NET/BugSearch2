using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 復旧データ一覧表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 復旧データ一覧表で使用するデータを取得する。</br>
    /// <br>Programmer   : 30452 上野 俊治</br>
    /// <br>Date         : 2008.12.02</br>
    /// <br>             : </br>
    /// </remarks>
    public class RecoveryDataOrderAcs
    {
        #region ■ コンストラクタ
		/// <summary>
        /// 復旧データ一覧表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 復旧データ一覧表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.12.02</br>
		/// </remarks>
		public RecoveryDataOrderAcs()
		{
            this._iRecoveryDataOrderWorkDB = (IRecoveryDataOrderWorkDB)MediationRecoveryDataOrderWorkDB.GetRecoveryDataOrderWorkDB();
		}

		/// <summary>
        /// 復旧データ一覧表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 復旧データ一覧表アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30452 上野 俊治</br>
        /// <br>Date       : 2008.12.02</br>
		/// </remarks>
        static RecoveryDataOrderAcs()
		{
            stc_Employee		= null;
			stc_PrtOutSet		= null;					// 帳票出力設定データクラス
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            stc_SecInfoAcs      = new SecInfoAcs(1);    // 拠点アクセスクラス
            stc_SectionDic      = new Dictionary<string,SecInfoSet>();  // 拠点Dictionary

            // ログイン拠点取得
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }

            // 拠点Dictionary生成
            SecInfoSet[] secInfoSetList = stc_SecInfoAcs.SecInfoSetList;

            foreach ( SecInfoSet secInfoSet in secInfoSetList )
            {
                // 既存でなければ
                if ( !stc_SectionDic.ContainsKey( secInfoSet.SectionCode ) )
                {
                    // 追加
                    stc_SectionDic.Add( secInfoSet.SectionCode, secInfoSet );
                }
            }
        }
		#endregion

        #region ■ Static変数
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス

        private static SecInfoAcs stc_SecInfoAcs;               // 拠点アクセスクラス
        private static Dictionary<string, SecInfoSet> stc_SectionDic;   // 拠点Dictionary

        #endregion

        #region ■ Private変数

        IRecoveryDataOrderWorkDB _iRecoveryDataOrderWorkDB;

        private DataTable _recoveryDataOrderDt; // 印刷DataTable
        private DataView _recoveryDataOrderDv; // 印刷DataView

        #endregion

        #region ■ Publicプロパティ
        /// <summary>
        /// 印刷データセット(読み取り専用)
        /// </summary>
        public DataView RecoveryDataOrderDataView
        {
            get { return this._recoveryDataOrderDv; }
        }
        #endregion

        #region ■ Publicメソッド
        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="salesRsltListCndtn">抽出条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.12.02</br>
        /// </remarks>
        public int SearchMain(RecoveryDataOrderCndtn recoveryDataOrderCndtn, out string errMsg)
        {
            return this.SearchProc(recoveryDataOrderCndtn, out errMsg);
        }

        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="retPrtOutSet">帳票出力設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";

            try
            {
                // データは読込済みか？
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "帳票出力設定の読込に失敗しました";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region ■ Privateメソッド
        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="recoveryDataOrderCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.12.02</br>
        /// </remarks>
        private int SearchProc(RecoveryDataOrderCndtn recoveryDataOrderCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMUOE02059EA.CreateDataTable(ref this._recoveryDataOrderDt);

                RecoveryDataOrderCndtnWork recoveryDataOrderCndtnWork = new RecoveryDataOrderCndtnWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevListCndtn(recoveryDataOrderCndtn, out recoveryDataOrderCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retWorkList = null;

                status = this._iRecoveryDataOrderWorkDB.Search(out retWorkList, recoveryDataOrderCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                // テスト用
                //status = this.testproc(out retWorkList);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DevListData(recoveryDataOrderCndtn, (ArrayList)retWorkList);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "復旧データ一覧表データの取得に失敗しました。";
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="salesRsltListCndtn">UI抽出条件クラス</param>
        /// <param name="salesRsltListCndtnWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       　: 画面抽出条件をリモート抽出条件へ展開する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.12.02</br>
        /// </remarks>
        private int DevListCndtn(RecoveryDataOrderCndtn recoveryDataOrderCndtn, out RecoveryDataOrderCndtnWork recoveryDataOrderCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            recoveryDataOrderCndtnWork = new RecoveryDataOrderCndtnWork();
            try
            {
                recoveryDataOrderCndtnWork.EnterpriseCode = recoveryDataOrderCndtn.EnterpriseCode;  // 企業コード

                // 抽出条件パラメータセット
                if (recoveryDataOrderCndtn.SectionCodes.Length != 0)
                {
                    if (recoveryDataOrderCndtn.IsSelectAllSection)
                    {
                        // 全社の時
                        recoveryDataOrderCndtnWork.SectionCodes = null;
                    }
                    else
                    {
                        recoveryDataOrderCndtnWork.SectionCodes = recoveryDataOrderCndtn.SectionCodes;
                    }
                }
                else
                {
                    recoveryDataOrderCndtnWork.SectionCodes = null;
                }

                recoveryDataOrderCndtnWork.SystemDivCd = (int)recoveryDataOrderCndtn.SystemDivCd; // システム区分

                recoveryDataOrderCndtnWork.St_UOESupplierCd = recoveryDataOrderCndtn.St_UOESupplierCd; // 開始UOE発注先コード
                if (recoveryDataOrderCndtn.Ed_UOESupplierCd == 0) recoveryDataOrderCndtnWork.Ed_UOESupplierCd = 999999;
                else recoveryDataOrderCndtnWork.Ed_UOESupplierCd = recoveryDataOrderCndtn.Ed_UOESupplierCd; // 終了UOE発注先コード


                
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// 取得データ展開処理
        /// </summary>
        /// <param name="salesRsltListCndtn">UI抽出条件クラス</param>
        /// <param name="resultWork">取得データ</param>
        /// <remarks>
        /// <br>Note       　: リモート抽出結果を帳票印字用DataTableへ展開する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.12.02</br>
        /// </remarks>
        private void DevListData(RecoveryDataOrderCndtn recoveryDataOrderCndtn, ArrayList resultWork)
        {
            // リモート抽出結果をDataTableに展開
            DataRow dr;

            // 抽出条件の作成
            string extractConditions = this.GetExtractConditions(recoveryDataOrderCndtn);

            foreach (RecoveryDataResultWork recoveryDataResultWork in resultWork)
            {
                dr = this._recoveryDataOrderDt.NewRow();

                dr[PMUOE02059EA.ct_Col_SectionCode] = recoveryDataResultWork.SectionCode; // 拠点コード
                dr[PMUOE02059EA.ct_Col_SectionGuideSnm] = recoveryDataResultWork.SectionGuideSnm; // 拠点ガイド名称
                dr[PMUOE02059EA.ct_Col_UOESupplierCd] = recoveryDataResultWork.UOESupplierCd; // UOE発注先コード
                dr[PMUOE02059EA.ct_Col_UOESupplierName] = recoveryDataResultWork.UOESupplierName; // UOE発注先名称
                dr[PMUOE02059EA.ct_Col_OnlineNo] = recoveryDataResultWork.OnlineNo; // オンラインNo
                dr[PMUOE02059EA.ct_Col_GoodsNo] = recoveryDataResultWork.GoodsNo; // 商品番号
                dr[PMUOE02059EA.ct_Col_GoodsName] = recoveryDataResultWork.GoodsName; // 商品名称
                dr[PMUOE02059EA.ct_Col_GoodsMakerCd] = recoveryDataResultWork.GoodsMakerCd; // 商品メーカーコード
                dr[PMUOE02059EA.ct_Col_AcceptAnOrderCnt] = recoveryDataResultWork.AcceptAnOrderCnt; // 受注数量
                dr[PMUOE02059EA.ct_Col_BoCode] = recoveryDataResultWork.BoCode; // Bo区分
                dr[PMUOE02059EA.ct_Col_UoeRemark1] = recoveryDataResultWork.UoeRemark1; // ＵＯＥリマーク1
                dr[PMUOE02059EA.ct_Col_DataSendCode] = recoveryDataResultWork.DataSendCode; // データ送信区分
                dr[PMUOE02059EA.ct_Col_OnlineRowNo] = recoveryDataResultWork.OnlineRowNo; // オンライン行番号
                dr[PMUOE02059EA.ct_Col_SystemDivCd] = recoveryDataResultWork.SystemDivCd;// システム区分

                // 抽出条件
                dr[PMUOE02059EA.ct_Col_ExtractCondition] = extractConditions;
                // システム区分名称
                dr[PMUOE02059EA.ct_Col_SystemDivName] = this.GetSystemDivName(recoveryDataResultWork.SystemDivCd);
                // エラー内容(データ送信区分名称)
                dr[PMUOE02059EA.ct_Col_DataSendName] = this.GetDataSendName(recoveryDataResultWork.DataSendCode);

                this._recoveryDataOrderDt.Rows.Add(dr);
            }

            // DataView作成
            // 発行タイプによりソート
            this._recoveryDataOrderDv = new DataView(this._recoveryDataOrderDt, "", this.GetSortStr(), DataViewRowState.CurrentRows);
        }

        /// <summary>
        /// 抽出条件取得
        /// </summary>
        /// <param name="recoveryDataOrderCndtn"></param>
        /// <returns>抽出条件文字列</returns>
        /// <remarks>
        /// <br>Note       　: 帳票に印字する抽出条件文字列を取得する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.12.02</br>
        /// </remarks>
        private string GetExtractConditions(RecoveryDataOrderCndtn recoveryDataOrderCndtn)
        {
            StringBuilder extractConditions = new StringBuilder(); ;

            string stCode;
            string edCode;

            // システム区分
            extractConditions.Append(string.Format("システム区分：{0}",
                                                recoveryDataOrderCndtn.SystemDivStateTitle));

            extractConditions.Append("　");

            // 発注先
            if ((recoveryDataOrderCndtn.St_UOESupplierCd != 0) ||
                ((recoveryDataOrderCndtn.Ed_UOESupplierCd != 0) &&
                 (!string.IsNullOrEmpty(recoveryDataOrderCndtn.Ed_UOESupplierCd.ToString()))))
            {
                stCode = recoveryDataOrderCndtn.St_UOESupplierCd.ToString("000000");
                edCode = recoveryDataOrderCndtn.Ed_UOESupplierCd.ToString("000000");
                if (recoveryDataOrderCndtn.St_UOESupplierCd == 0) stCode = "最初から";

                if ((recoveryDataOrderCndtn.Ed_UOESupplierCd == 0) ||
                    (string.IsNullOrEmpty(recoveryDataOrderCndtn.Ed_UOESupplierCd.ToString())))
                {
                    edCode = "最後まで";
                }

                extractConditions.Append(string.Format("発注先：{0} ～ {1}", stCode, edCode));
            }

            return extractConditions.ToString();
        }

        /// <summary>
        /// システム区分名称取得
        /// </summary>
        /// <param name="SystemDivCd"></param>
        /// <returns>システム区分名称</returns>
        /// <remarks>
        /// <br>Note       　: 帳票に印字するシステム区分名称文字列を取得する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.12.02</br>
        /// </remarks>
        private string GetSystemDivName(int SystemDivCd)
        {
            switch ((RecoveryDataOrderCndtn.SystemDivState)SystemDivCd)
            {
                case RecoveryDataOrderCndtn.SystemDivState.Manual:
                    {
                        return RecoveryDataOrderCndtn.ct_SystemDivState_Manual;
                    }
                    case RecoveryDataOrderCndtn.SystemDivState.Slip:
                    {
                        return RecoveryDataOrderCndtn.ct_SystemDivState_Slip;
                    }
                    case RecoveryDataOrderCndtn.SystemDivState.Search:
                    {
                        return RecoveryDataOrderCndtn.ct_SystemDivState_Search;
                    }
                    case RecoveryDataOrderCndtn.SystemDivState.Lump:
                    {
                        return RecoveryDataOrderCndtn.ct_SystemDivState_Lump;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }

        }

        /// <summary>
        /// エラー内容(データ送信区分名称)
        /// </summary>
        /// <param name="SystemDivCd"></param>
        /// <returns>データ送信区分名称</returns>
        /// <remarks>
        /// <br>Note       　: 帳票に印字するデータ送信区分名称文字列を取得する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.12.02</br>
        /// </remarks>
        private string GetDataSendName(int DataSendCd)
        {
            switch ((RecoveryDataOrderCndtn.DataSendCodeState)DataSendCd)
            {
                case RecoveryDataOrderCndtn.DataSendCodeState.SendErr:
                    {
                        return RecoveryDataOrderCndtn.ct_DataSendCode_SendErr;
                    }
                case RecoveryDataOrderCndtn.DataSendCodeState.ReceiveErr:
                    {
                        return RecoveryDataOrderCndtn.ct_DataSendCode_ReceiveErr;
                    }
                case RecoveryDataOrderCndtn.DataSendCodeState.AbnormalErr:
                    {
                        return RecoveryDataOrderCndtn.ct_DataSendCode_AbnormalErr;
                    }
                default:
                    {
                        return string.Empty;
                    }
            }
        }

        /// <summary>
        /// DataView用ソート文字列取得
        /// </summary>
        /// <param name="custFinancialListCndtn">UI抽出条件クラス</param>
        /// <returns>ソート文字列</returns>
        /// <remarks>
        /// <br>Note       　: ソート文字列を取得する</br>
        /// <br>Programmer   : 30452 上野 俊治</br>
        /// <br>Date         : 2008.12.02</br>
        /// </remarks>
        private string GetSortStr()
        {
            // 拠点-システム区分-発注先-オンライン番号(呼出番号)-オンライン行番号-品番順 
            return PMUOE02059EA.ct_Col_SectionCode + ", " + PMUOE02059EA.ct_Col_SystemDivCd + ", "
                 + PMUOE02059EA.ct_Col_UOESupplierCd + ", " + PMUOE02059EA.ct_Col_OnlineNo + ", "
                 + PMUOE02059EA.ct_Col_OnlineRowNo + ", " + PMUOE02059EA.ct_Col_GoodsNo;
        }
        #endregion

        #region テストデータ
        private int testproc(out object retList)
        {
            ArrayList paramlist = new ArrayList();

            RecoveryDataResultWork param1 = new RecoveryDataResultWork();

            param1.SectionCode = "";
            param1.SectionGuideSnm = "";
            param1.UOESupplierCd = 0;
            param1.UOESupplierName = "";
            param1.OnlineNo = 0;
            param1.GoodsNo = "";
            param1.GoodsName = "";
            param1.GoodsMakerCd = 0;
            param1.AcceptAnOrderCnt = 0;
            param1.BoCode = "";
            param1.UoeRemark1 = "";
            param1.DataSendCode = 0;
            param1.OnlineRowNo = 0;
            param1.SystemDivCd = 0;

            paramlist.Add(param1);

            RecoveryDataResultWork param2 = new RecoveryDataResultWork();

            param2.SectionCode = "01";
            param2.SectionGuideSnm = "拠点名称は１０桁です";
            param2.UOESupplierCd = 1;
            param2.UOESupplierName = "発注先コード名は全角１５桁です";
            param2.OnlineNo = 1;
            param2.GoodsNo = "123456789012345678901234";
            param2.GoodsName = "12345678901234567890";
            param2.GoodsMakerCd = 12;
            param2.AcceptAnOrderCnt = 11.1;
            param2.BoCode = "1";
            param2.UoeRemark1 = "12345678901234567890";
            param2.DataSendCode = 3;
            param2.OnlineRowNo = 1;
            param2.SystemDivCd = 1;

            paramlist.Add(param2);

            RecoveryDataResultWork param3 = new RecoveryDataResultWork();

            param3.SectionCode = "01";
            param3.SectionGuideSnm = "拠点名称は１０桁です";
            param3.UOESupplierCd = 1;
            param3.UOESupplierName = "発注先コード名は全角１５桁です";
            param3.OnlineNo = 1;
            param3.GoodsNo = "123456789012345678901234";
            param3.GoodsName = "12345678901234567890";
            param3.GoodsMakerCd = 12;
            param3.AcceptAnOrderCnt = 11.1;
            param3.BoCode = "1";
            param3.UoeRemark1 = "12345678901234567890";
            param3.DataSendCode = 4;
            param3.OnlineRowNo = 1;
            param3.SystemDivCd = 2;

            paramlist.Add(param3);

            RecoveryDataResultWork param4 = new RecoveryDataResultWork();

            param4.SectionCode = "01";
            param4.SectionGuideSnm = "拠点名称は１０桁です";
            param4.UOESupplierCd = 1;
            param4.UOESupplierName = "発注先コード名は全角１５桁です";
            param4.OnlineNo = 1;
            param4.GoodsNo = "123456789012345678901234";
            param4.GoodsName = "12345678901234567890";
            param4.GoodsMakerCd = 12;
            param4.AcceptAnOrderCnt = 11.1;
            param4.BoCode = "1";
            param4.UoeRemark1 = "12345678901234567890";
            param4.DataSendCode = 4;
            param4.OnlineRowNo = 1;
            param4.SystemDivCd = 3;

            paramlist.Add(param4);

            RecoveryDataResultWork param5 = new RecoveryDataResultWork();

            param5.SectionCode = "02";
            param5.SectionGuideSnm = "拠点名称は１０桁です";
            param5.UOESupplierCd = 1;
            param5.UOESupplierName = "発注先コード名は全角１５桁です";
            param5.OnlineNo = 1;
            param5.GoodsNo = "123456789012345678901234";
            param5.GoodsName = "12345678901234567890";
            param5.GoodsMakerCd = 12;
            param5.AcceptAnOrderCnt = 11.1;
            param5.BoCode = "1";
            param5.UoeRemark1 = "12345678901234567890";
            param5.DataSendCode = 4;
            param5.OnlineRowNo = 1;
            param5.SystemDivCd = 4;

            paramlist.Add(param5);

            RecoveryDataResultWork param6 = new RecoveryDataResultWork();

            param6.SectionCode = "02";
            param6.SectionGuideSnm = "拠点名称は１０桁です";
            param6.UOESupplierCd = 1;
            param6.UOESupplierName = "発注先コード名は全角１５桁です";
            param6.OnlineNo = 1;
            param6.GoodsNo = "123456789012345678901234";
            param6.GoodsName = "12345678901234567890";
            param6.GoodsMakerCd = 12;
            param6.AcceptAnOrderCnt = 11.1;
            param6.BoCode = "1";
            param6.UoeRemark1 = "12345678901234567890";
            param6.DataSendCode = 4;
            param6.OnlineRowNo = 1;
            param6.SystemDivCd = 4;

            paramlist.Add(param6);


            retList = (object)paramlist;

            return 0;
        }
        #endregion 
    }
}
