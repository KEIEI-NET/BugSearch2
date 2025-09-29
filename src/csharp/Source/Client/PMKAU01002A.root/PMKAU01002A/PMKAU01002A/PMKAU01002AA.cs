//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由帳票（請求書）アクセスクラス
// プログラム概要   : 自由帳票（請求書）アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2022 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570183-00   作成担当 : 陳艶丹
// 作 成 日  2022/03/07    修正内容 : 請求書発行(電子帳簿連携)新規作成
//----------------------------------------------------------------------------//
// 管理番号  11870141-00   作成担当 : 田村顕成
// 作 成 日  2022/10/18    修正内容 : インボイス残対応（軽減税率対応）
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;


namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 自由帳票（請求書）アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 自由帳票（請求書）で使用するデータを取得する。</br>
    /// <br>               【抽出(E)からcallします】</br>
    /// <br>Programmer   : 陳艶丹</br>
    /// <br>Date         : 2022/03/07</br>
    /// <br>Update Note  : 2022/10/18 田村顕成</br>
    /// <br>管理番号     : 11870141-00 インボイス残対応（軽減税率対応）</br>
    /// </remarks>
	public class EBooksFrePBillAcs
	{

        #region [private フィールド]
        private IEBooksFrePBillDB _iEBooksFrePBillDB;   // リモートインタフェース
        private DataSet _printDataSet;  // 印刷DataSet
        private bool _extractCancel;
        #endregion

        #region [public プロパティ]
        /// <summary>
        /// 印刷データセット(読み取り専用)
        /// </summary>
        public DataSet PrintDataSet
        {
            get { return this._printDataSet; }
        }
        #endregion

		#region [コンストラクタ]
		/// <summary>
		/// 自由帳票（請求書）アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 自由帳票（請求書）アクセスクラスの初期化を行う。</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2022/03/07</br>
		/// </remarks>
		public EBooksFrePBillAcs()
		{
            // リモートオブジェクト取得
            this._iEBooksFrePBillDB = (IEBooksFrePBillDB)MediationEBooksFrePBillDB.GetEBooksFrePBillDB();
		}
		#endregion

		#region [public メソッド]
		/// <summary>
		/// データ取得
		/// </summary>
        /// <param name="cndtn">抽出条件</param>
        /// <param name="cndtnView">抽出条件View</param>
		/// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
		/// </remarks>
        public int SearchMain ( object cndtn, DataView cndtnView, out string errMsg )
		{
            return this.SearchProc( cndtn, cndtnView, out errMsg );
		}
		#endregion

		#region [private メソッド]
		#region [帳票データ取得]
		/// <summary>
		/// 在庫移動データ取得
		/// </summary>
        /// <param name="cndtn">抽出条件</param>
        /// <param name="cndtnView">抽出条件View</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷する請求書データを取得する。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Note       : 11870141-00 インボイス残対応（軽減税率対応）</br>
        /// <br>Programmer : 田村顕成 </br>
        /// <br>Date       : 2022/10/18</br>
		/// </remarks>
        private int SearchProc ( object cndtn, DataView cndtnView, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

			errMsg = "";

            _extractCancel = false;
            // --- ADD START 田村顕成 2022/10/18 ----->>>>>
            PMKAU01002AB.TaxRatePrintInfo taxRatePrintInfo = null;
            status = PMKAU01002AB.Deserialize(out taxRatePrintInfo, out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) 
            {
                return status;
            }
            // --- ADD END   田村顕成 2022/10/18 -----<<<<<

            // データセット・データテーブル生成
            _printDataSet = new DataSet();
            _printDataSet.Tables.Add( PMKAU01002AB.CreateBillListTable() );

			try
			{
                if ( _extractCancel ) return SetReturnCancel();
                // 抽出条件展開  --------------------------------------------------------------
                EBooksFrePBillParaWork billCndtn;
                status = this.DevFrePBillCndtn( cndtn, cndtnView, out billCndtn, out errMsg );
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

                if ( _extractCancel ) return SetReturnCancel();
				// データ取得  ----------------------------------------------------------------
				object retList = null;
                object retMList = null;
                bool msgDiv;
                status = this._iEBooksFrePBillDB.Search( XmlByteSerializer.Serialize( billCndtn ), out retList, out retMList, out msgDiv, out errMsg );

				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        if ( _extractCancel ) return SetReturnCancel();
                        if (errMsg != null && errMsg != "" ) { MessageBox.Show(errMsg); }
						// データ展開処理
                        DevPrintData( cndtn, billCndtn, (ArrayList)retList, (ArrayList)retMList );
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "請求書データの取得に失敗しました。";
						break;
				}
			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}

        /// <summary>
        /// 抽出キャンセルボタンイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CancelButtonClick( object sender, EventArgs e )
        {
            // キャンセルフラグを立てる
            // 抽出処理の流れでフラグを確認して処理を抜ける
            _extractCancel = true;
        }
        /// <summary>
        /// キャンセル時
        /// </summary>
        /// <returns></returns>
        private int SetReturnCancel()
        {
            // 抽出結果テーブルを編集
            # region [抽出結果テーブルを編集]
            _printDataSet = new DataSet();
            _printDataSet.Tables.Add( PMKAU01002AB.CreateBillListTable() );

            DataRow row = _printDataSet.Tables[0].NewRow();
            // フラグを立てる→Pでチェック
            row[PMKAU01002AB.CT_BillList_ExtractCancel] = true;
            _printDataSet.Tables[0].Rows.Add( row );
            # endregion

            // 戻り値はNORMALで返す
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
		#endregion

		#region [データ展開処理]

		#region [抽出条件展開処理]
		/// <summary>
		/// 抽出条件展開処理
		/// </summary>
        /// <param name="cndtn"></param>
        /// <param name="cndtnView">UI抽出条件クラス</param>
        /// <param name="frePBillParaWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 抽出条件展開処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int DevFrePBillCndtn(object cndtn, DataView cndtnView, out EBooksFrePBillParaWork frePBillParaWork, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
			errMsg = string.Empty;

            frePBillParaWork = null;
            List<EBooksFrePBillParaWork.FrePBillParaKey> billKeyList = new List<EBooksFrePBillParaWork.FrePBillParaKey>();

            Dictionary<string, string> sectionDic = new Dictionary<string, string>();

            try
			{
                //-----------------------------------------------------
                // 通常の請求書処理がセットしたDataViewの内容から、
                // 請求書キーリストを生成します。
                //-----------------------------------------------------

                if ( cndtn is ExtrInfo_EBooksDemandTotal )
                {
                    foreach ( string sec in (cndtn as ExtrInfo_EBooksDemandTotal).ResultsAddUpSecList )
                    {
                        string sectionCode = sec.Trim();

                        if ( !sectionDic.ContainsKey( sectionCode ) )
                        {
                            sectionDic.Add( sectionCode, string.Empty );
                        }
                    }

                    //--------------------------------------------------------------
                    // 請求書
                    //--------------------------------------------------------------
                    # region [請求書]
                    foreach ( DataRowView rowView in cndtnView )
                    {
                        if ( (bool)rowView[PMKAU01002AB.CT_CsDmd_PrintFlag] == true &&
                             sectionDic.ContainsKey( ((string)rowView[PMKAU01002AB.CT_CsDmd_AddUpSecCode]).Trim() ) )
                        {
                            EBooksFrePBillParaWork.FrePBillParaKey key = new EBooksFrePBillParaWork.FrePBillParaKey();

                            key.SetAddUpDateLongDate( (int)rowView[PMKAU01002AB.CT_CsDmd_AddUpDateInt] );
                            key.AddUpSecCode = (string)rowView[PMKAU01002AB.CT_CsDmd_AddUpSecCode];
                            key.ClaimCode = (int)rowView[PMKAU01002AB.CT_CsDmd_ClaimCode];

                            if ( (bool)rowView[PMKAU01002AB.CT_BillList_DataType] == true )
                            {
                                // 拠点コード
                                key.ResultsSectCd = "00";
                                // 請求先レコード
                                key.CustomerCode = 0;
                            }
                            else
                            {
                                // 拠点コード
                                key.ResultsSectCd = (string)rowView[PMKAU01002AB.CT_CsDmd_ResultsSectCd];
                                // 得意先レコード
                                key.CustomerCode = (int)rowView[PMKAU01002AB.CT_CsDmd_CustomerCode];
                            }

                            billKeyList.Add( key );
                        }
                    }

                    if ( billKeyList.Count > 0 )
                    {
                        // リモート抽出条件生成
                        frePBillParaWork = new EBooksFrePBillParaWork();
                        frePBillParaWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        frePBillParaWork.FrePBillParaKeyList = billKeyList;

                        // 請求書タイプを設定
                        frePBillParaWork.SlipPrtKind = 60;
                        frePBillParaWork.UseSumCust = false;

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    # endregion
                }
                else 
                {
                    errMsg = "自由帳票(請求書)の抽出条件が正しく設定されていません。";
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    return status;
                }
			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion

		#region [取得データ展開処理]
		/// <summary>
		/// 取得データ展開処理
		/// </summary>
        /// <param name="cndtn">検索条件</param>
        /// <param name="billCndtn">UI抽出条件クラス</param>
        /// <param name="printList">取得データ</param>
        /// <param name="masterList">マスタ配列リスト</param>
		/// <remarks>
        /// <br>Note  　    : 取得データを展開する。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Note       : 11870141-00 インボイス残対応（軽減税率対応）</br>
        /// <br>Programmer : 田村顕成 </br>
        /// <br>Date       : 2022/10/18</br>
		/// </remarks>
        private void DevPrintData( object cndtn, EBooksFrePBillParaWork billCndtn, ArrayList printList, ArrayList masterList )
		{
            DataTable table = _printDataSet.Tables[PMKAU01002AB.CT_Tbl_BillList];

            int regNo = 0;
            string sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            # region [マスタ展開]
            List<CustDmdSetWork> custDmdSetList = null;
            List<SlipOutputSetWork> slipOutputSetList = null;
            List<DmdPrtPtnWork> dmdPrtPtnList = null;
            List<FrePrtPSetWork> frePrtPSetList = null;
            List<PrtManage> prtManageList = null;
            List<BillAllStWork> billAllStList = null;
            List<BillPrtStWork> billPrtStList = null;
            List<AllDefSetWork> allDefSetList = null;
            // --- ADD START 田村顕成 2022/10/18 ----->>>>>
            // 売上金額処理区分設定
            List<SalesProcMoneyWork> salesProcMoneyWorkList = null;
            // --- ADD END   田村顕成 2022/10/18 -----<<<<<

            // リモート取得したマスタリスト
            foreach ( object obj in masterList )
            {
                if ( obj is CustDmdSetWork[] )
                {
                    custDmdSetList = new List<CustDmdSetWork>( (CustDmdSetWork[])obj );
                }
                else if ( obj is SlipOutputSetWork[] )
                {
                    slipOutputSetList = new List<SlipOutputSetWork>( (SlipOutputSetWork[])obj );
                }
                else if ( obj is DmdPrtPtnWork[] )
                {
                    dmdPrtPtnList = new List<DmdPrtPtnWork>( (DmdPrtPtnWork[])obj );
                }
                else if ( obj is FrePrtPSetWork[] )
                {
                    frePrtPSetList = new List<FrePrtPSetWork>( (FrePrtPSetWork[])obj );
                }
                else if ( obj is BillAllStWork[] )
                {
                    billAllStList = new List<BillAllStWork>( (BillAllStWork[])obj );
                }
                else if ( obj is BillPrtStWork[] )
                {
                    billPrtStList = new List<BillPrtStWork>( (BillPrtStWork[])obj );
                }
                else if ( obj is AllDefSetWork[] )
                {
                    allDefSetList = new List<AllDefSetWork>( (AllDefSetWork[])obj );
                }
                // --- ADD START 田村顕成 2022/10/18 ----->>>>>
                else if (obj is SalesProcMoneyWork[])
                {
                    salesProcMoneyWorkList = new List<SalesProcMoneyWork>((SalesProcMoneyWork[])obj);
                }
                // --- ADD END   田村顕成 2022/10/18 -----<<<<<
            }

            // プリンタ設定リスト
            prtManageList = SearchAllPrtManage( billCndtn.EnterpriseCode );

            // 端末番号（レジ番号）
            PosTerminalMg posTerminalMg;
            if ( GetPosTerminalMg( out posTerminalMg, billCndtn.EnterpriseCode ) == 0)
            {
                regNo = posTerminalMg.CashRegisterNo;
            }
            # endregion

            //// コピー処理
            // --- DEL START 田村顕成 2022/10/18 ----->>>>>
            //PMKAU01002AB.CopyToBillListTable( ref table, cndtn, billCndtn, printList,
            //                                    custDmdSetList, slipOutputSetList, dmdPrtPtnList, frePrtPSetList, prtManageList, billAllStList, billPrtStList, allDefSetList,
            //                                    regNo, sectionCode );
            // --- DEL END   田村顕成 2022/10/18 -----<<<<<
            // --- ADD START 田村顕成 2022/10/18 ----->>>>>
            PMKAU01002AB.CopyToBillListTable(ref table, cndtn, billCndtn, printList,
                                                custDmdSetList, slipOutputSetList, dmdPrtPtnList, frePrtPSetList, prtManageList, billAllStList, billPrtStList, allDefSetList,
                                                regNo, sectionCode, salesProcMoneyWorkList);
            // --- ADD END   田村顕成 2022/10/18 -----<<<<<
		}
		#endregion

        # region [プリンタ設定取得]
        /// <summary>
        /// プリンタ設定　全取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>プリンタ管理設定結果</returns>
        /// <remarks>
        /// <br>Note         : プリンタ管理設定はローカルＸＭＬを読み込みます。</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2022/03/07</br>
        /// </remarks>
        public List<PrtManage> SearchAllPrtManage( string enterpriseCode )
        {
            PrtManageAcs _prtManageAcs = new PrtManageAcs();

            List<PrtManage> prtManageList = new List<PrtManage>();

            ArrayList retList;
            _prtManageAcs.SearchAll( out retList, enterpriseCode );

            foreach ( PrtManage prtManage in retList )
            {
                if ( prtManage.LogicalDeleteCode == 0 )
                {
                    prtManageList.Add( prtManage );
                }
            }

            return prtManageList;
        }
        # endregion

        # region [端末設定取得]
        /// <summary>
        /// 端末設定取得処理
        /// </summary>
        /// <param name="posTerminalMg">POS端末管理設定</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>端末設定</returns>
        /// <remarks>
        /// <br>Note         : 端末設定取得処理</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2022/03/07</br>
        /// </remarks>
        private int GetPosTerminalMg( out PosTerminalMg posTerminalMg, string enterpriseCode )
        {
            PosTerminalMgAcs acs = new PosTerminalMgAcs();
            return acs.Search( out posTerminalMg, enterpriseCode );
        }
        # endregion

		#endregion

		#endregion
	}
}
