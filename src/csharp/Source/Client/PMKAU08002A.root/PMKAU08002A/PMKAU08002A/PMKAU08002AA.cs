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
    /// <br>Programmer   : 22018 鈴木 正臣</br>
    /// <br>Date         : 2008.06.16</br>
    /// <br></br>
    /// <br>Update Note  : 2010.02.15  22018 鈴木 正臣</br>
    /// <br>             : 請求書(総括)対応</br>
    /// <br></br>
    /// <br>Update Note  : 2010/07/22  22018 鈴木 正臣</br>
    /// <br>             : アウトオブメモリエラー対応</br>
    /// <br>Update Note  : 2012/02/06  許培珠</br>
    /// <br>管理番号　　 : 10707327-00 2012/03/28配信分</br>
    /// <br>             : Redmine#28258 請求書／ログ出力の追加</br>
    /// <br>Update Note  : 2022/10/18 田村顕成</br>
    /// <br>管理番号     : 11870141-00 インボイス残対応（軽減税率対応）</br>
    /// </remarks>
	public class FrePBillAcs
	{
        #region [private static フィールド]
        //private static Employee stc_Employee;
        //private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
        //private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス

        //private static SecInfoAcs stc_SecInfoAcs;               // 拠点アクセスクラス
        //private static Dictionary<string,SecInfoSet> stc_SectionDic;   // 拠点Dictionary
        #endregion

        #region [private フィールド]
        private IFrePBillDB _iFrePBillDB;   // リモートインタフェース

        //private DataTable _printListDt;			// 印刷DataTable
        //private DataView _printListDataView;	// 印刷DataView
        private DataSet _printDataSet;  // 印刷DataSet
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
        private bool _extractCancel;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
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
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public FrePBillAcs()
		{
            // リモートオブジェクト取得
            this._iFrePBillDB = (IFrePBillDB)MediationFrePBillDB.GetFrePBillDB();
		}
		#endregion

		#region [public メソッド]
		/// <summary>
		/// データ取得
		/// </summary>
        /// <param name="cndtn"></param>
        /// <param name="cndtnView">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
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
        /// <param name="cndtn"></param>
        /// <param name="cndtnView"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する請求書データを取得する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2008.06.16</br>
        /// <br>Note       : 11870141-00 インボイス残対応（軽減税率対応）</br>
        /// <br>Programmer : 田村顕成 </br>
        /// <br>Date       : 2022/10/18</br>
		/// </remarks>
        private int SearchProc ( object cndtn, DataView cndtnView, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

			errMsg = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
            _extractCancel = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
            // --- ADD START 田村顕成 2022/10/18 ----->>>>>
            PMKAU08002AB.TaxRatePrintInfo taxRatePrintInfo = null;
            status = PMKAU08002AB.Deserialize(out taxRatePrintInfo, out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) 
            {
                return status;
            }
            // --- ADD END   田村顕成 2022/10/18 -----<<<<<

            // データセット・データテーブル生成
            _printDataSet = new DataSet();
            _printDataSet.Tables.Add( PMKAU08002AB.CreateBillListTable() );

			try
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                if ( _extractCancel ) return SetReturnCancel();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD

                // 抽出条件展開  --------------------------------------------------------------
                FrePBillParaWork billCndtn;
                status = this.DevFrePBillCndtn( cndtn, cndtnView, out billCndtn, out errMsg );
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                if ( _extractCancel ) return SetReturnCancel();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD

				// データ取得  ----------------------------------------------------------------
				object retList = null;
                object retMList = null;
                bool msgDiv;
                status = this._iFrePBillDB.Search( XmlByteSerializer.Serialize( billCndtn ), out retList, out retMList, out msgDiv, out errMsg );

				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
                        if ( _extractCancel ) return SetReturnCancel();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
                        // ----- ADD 2012/02/06 xupz for redmine#28258---------->>>>>
                        if (errMsg != null && errMsg != "" ) { MessageBox.Show(errMsg); }
                        // ----- ADD 2012/02/06 xupz for redmine#28258----------<<<<<
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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
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
            _printDataSet.Tables.Add( PMKAU08002AB.CreateBillListTable() );

            DataRow row = _printDataSet.Tables[0].NewRow();
            // フラグを立てる→Pでチェック
            row[PMKAU08002AB.CT_BillList_ExtractCancel] = true;
            _printDataSet.Tables[0].Rows.Add( row );
            # endregion

            // 戻り値はNORMALで返す
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
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
		/// <returns>Status</returns>
        private int DevFrePBillCndtn( object cndtn, DataView cndtnView, out FrePBillParaWork frePBillParaWork, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
			errMsg = string.Empty;

            frePBillParaWork = null;
            List<FrePBillParaWork.FrePBillParaKey> billKeyList = new List<FrePBillParaWork.FrePBillParaKey>();

            // --- ADD m.suzuki 2010/07/22 ---------->>>>>
            Dictionary<string, string> sectionDic = new Dictionary<string, string>();
            // --- ADD m.suzuki 2010/07/22 ----------<<<<<

            try
			{
                //-----------------------------------------------------
                // 通常の請求書処理がセットしたDataViewの内容から、
                // 請求書キーリストを生成します。
                //-----------------------------------------------------

                // --- UPD m.suzuki 2010/02/18 ---------->>>>>
                # region // DEL
                //foreach ( DataRowView rowView in cndtnView )
                //{
                //    if ( (bool)rowView[PMKAU08002AB.CT_CsDmd_PrintFlag] == true )
                //    {
                //        FrePBillParaWork.FrePBillParaKey key = new FrePBillParaWork.FrePBillParaKey();

                //        key.SetAddUpDateLongDate( (int)rowView[PMKAU08002AB.CT_CsDmd_AddUpDateInt] );
                //        key.AddUpSecCode = (string)rowView[PMKAU08002AB.CT_CsDmd_AddUpSecCode];
                //        key.ClaimCode = (int)rowView[PMKAU08002AB.CT_CsDmd_ClaimCode];

                //        if ( (bool)rowView[PMKAU08002AB.CT_BillList_DataType] == true )
                //        {
                //            // 拠点コード
                //            key.ResultsSectCd = "00";
                //            // 請求先レコード
                //            key.CustomerCode = 0;
                //        }
                //        else
                //        {
                //            // 拠点コード
                //            key.ResultsSectCd = (string)rowView[PMKAU08002AB.CT_CsDmd_ResultsSectCd];
                //            // 得意先レコード
                //            key.CustomerCode = (int)rowView[PMKAU08002AB.CT_CsDmd_CustomerCode];
                //        }

                //        billKeyList.Add( key );
                //    }
                //}

                //if ( billKeyList.Count > 0 )
                //{
                //    // リモート抽出条件生成
                //    frePBillParaWork = new FrePBillParaWork();
                //    frePBillParaWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                //    frePBillParaWork.FrePBillParaKeyList = billKeyList;
                    
                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                //    if ( cndtn is ExtrInfo_DemandTotal )
                //    {
                //        // 請求書タイプを設定
                //        frePBillParaWork.SlipPrtKind = (cndtn as ExtrInfo_DemandTotal).SlipPrtKind;
                //    }
                //    else
                //    {
                //        errMsg = "自由帳票(請求書)の抽出条件が正しく設定されていません。";
                //        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                //        return status;
                //    }
                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
                //    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                //}
                # endregion

                if ( cndtn is ExtrInfo_DemandTotal )
                {
                    // --- ADD m.suzuki 2010/07/22 ---------->>>>>
                    foreach ( string sec in (cndtn as ExtrInfo_DemandTotal).ResultsAddUpSecList )
                    {
                        string sectionCode = sec.Trim();

                        if ( !sectionDic.ContainsKey( sectionCode ) )
                        {
                            sectionDic.Add( sectionCode, string.Empty );
                        }
                    }
                    // --- ADD m.suzuki 2010/07/22 ----------<<<<<

                    //--------------------------------------------------------------
                    // 請求書
                    //--------------------------------------------------------------
                    # region [請求書]
                    foreach ( DataRowView rowView in cndtnView )
                    {
                        // --- UPD m.suzuki 2010/07/22 ---------->>>>>
                        //if ( (bool)rowView[PMKAU08002AB.CT_CsDmd_PrintFlag] == true )
                        if ( (bool)rowView[PMKAU08002AB.CT_CsDmd_PrintFlag] == true &&
                             sectionDic.ContainsKey( ((string)rowView[PMKAU08002AB.CT_CsDmd_AddUpSecCode]).Trim() ) )
                        // --- UPD m.suzuki 2010/07/22 ----------<<<<<
                        {
                            FrePBillParaWork.FrePBillParaKey key = new FrePBillParaWork.FrePBillParaKey();

                            key.SetAddUpDateLongDate( (int)rowView[PMKAU08002AB.CT_CsDmd_AddUpDateInt] );
                            key.AddUpSecCode = (string)rowView[PMKAU08002AB.CT_CsDmd_AddUpSecCode];
                            key.ClaimCode = (int)rowView[PMKAU08002AB.CT_CsDmd_ClaimCode];

                            if ( (bool)rowView[PMKAU08002AB.CT_BillList_DataType] == true )
                            {
                                // 拠点コード
                                key.ResultsSectCd = "00";
                                // 請求先レコード
                                key.CustomerCode = 0;
                            }
                            else
                            {
                                // 拠点コード
                                key.ResultsSectCd = (string)rowView[PMKAU08002AB.CT_CsDmd_ResultsSectCd];
                                // 得意先レコード
                                key.CustomerCode = (int)rowView[PMKAU08002AB.CT_CsDmd_CustomerCode];
                            }

                            billKeyList.Add( key );
                        }
                    }

                    if ( billKeyList.Count > 0 )
                    {
                        // リモート抽出条件生成
                        frePBillParaWork = new FrePBillParaWork();
                        frePBillParaWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        frePBillParaWork.FrePBillParaKeyList = billKeyList;

                        // 請求書タイプを設定
                        frePBillParaWork.SlipPrtKind = (cndtn as ExtrInfo_DemandTotal).SlipPrtKind;
                        frePBillParaWork.UseSumCust = false;

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    # endregion
                }
                else if ( cndtn is SumExtrInfo_DemandTotal )
                {
                    // --- ADD m.suzuki 2010/07/22 ---------->>>>>
                    foreach ( string sec in (cndtn as SumExtrInfo_DemandTotal).ResultsAddUpSecList )
                    {
                        string sectionCode = sec.Trim();

                        if ( !sectionDic.ContainsKey( sectionCode ) )
                        {
                            sectionDic.Add( sectionCode, string.Empty );
                        }
                    }
                    // --- ADD m.suzuki 2010/07/22 ----------<<<<<

                    //--------------------------------------------------------------
                    // 請求書（総括）
                    //--------------------------------------------------------------
                    # region [請求書(総括)]
                    foreach ( DataRowView rowView in cndtnView )
                    {
                        // --- UPD m.suzuki 2010/07/22 ---------->>>>>
                        //if ( (bool)rowView[PMKAU08002AB.CT_CsDmd_PrintFlag] == true && (bool)rowView[PMKAU08002AB.CT_CsDmd_DataType] == true )
                        if ( (bool)rowView[PMKAU08002AB.CT_CsDmd_PrintFlag] == true &&
                             (bool)rowView[PMKAU08002AB.CT_CsDmd_DataType] == true &&
                             sectionDic.ContainsKey( ((string)rowView[PMKAU08002AB.CT_CsDmd_AddUpSecCode]).Trim() ) )
                        // --- UPD m.suzuki 2010/07/22 ----------<<<<<
                        {
                            FrePBillParaWork.FrePBillParaKey key = new FrePBillParaWork.FrePBillParaKey();

                            key.SetAddUpDateLongDate( (int)rowView[PMKAU08002AB.CT_CsDmd_AddUpDateInt] );
                            key.AddUpSecCode = (string)rowView[PMKAU08002AB.CT_CsDmd_AddUpSecCode];

                            // 請求先コード ← 総括得意先をセットする
                            key.ClaimCode = (int)rowView[PMKAU08002AB.CT_CsDmd_SumClaimCustCode];

                            // 拠点コード
                            key.ResultsSectCd = "00";
                            // 得意先コード
                            key.CustomerCode = 0;

                            billKeyList.Add( key );
                        }
                    }

                    if ( billKeyList.Count > 0 )
                    {
                        // リモート抽出条件生成
                        frePBillParaWork = new FrePBillParaWork();
                        frePBillParaWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        frePBillParaWork.FrePBillParaKeyList = billKeyList;
                        
                        // 請求書タイプを設定
                        frePBillParaWork.SlipPrtKind = (cndtn as SumExtrInfo_DemandTotal).SlipPrtKind;
                        frePBillParaWork.UseSumCust = true;

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
                // --- UPD m.suzuki 2010/02/18 ----------<<<<<
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
        /// <param name="cndtn"></param>
        /// <param name="billCndtn">UI抽出条件クラス</param>
        /// <param name="printList">取得データ</param>
        /// <param name="masterList">マスタ配列リスト</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取得データを展開する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
        /// <br>Note       : 11870141-00 インボイス残対応（軽減税率対応）</br>
        /// <br>Programmer : 田村顕成 </br>
        /// <br>Date       : 2022/10/18</br>
		/// </remarks>
        private void DevPrintData( object cndtn, FrePBillParaWork billCndtn, ArrayList printList, ArrayList masterList )
		{
            DataTable table = _printDataSet.Tables[PMKAU08002AB.CT_Tbl_BillList];

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

            // --- DEL START 田村顕成 2022/10/18 ----->>>>>
            //// コピー処理
            //PMKAU08002AB.CopyToBillListTable( ref table, cndtn, billCndtn, printList,
            //                                    custDmdSetList, slipOutputSetList, dmdPrtPtnList, frePrtPSetList, prtManageList, billAllStList, billPrtStList, allDefSetList,
            //                                    regNo, sectionCode );
            // --- DEL END   田村顕成 2022/10/18 -----<<<<<
            // --- ADD START 田村顕成 2022/10/18 ----->>>>>
            // コピー処理
            PMKAU08002AB.CopyToBillListTable(ref table, cndtn, billCndtn, printList,
                                                custDmdSetList, slipOutputSetList, dmdPrtPtnList, frePrtPSetList, prtManageList, billAllStList, billPrtStList, allDefSetList,
                                                regNo, sectionCode, salesProcMoneyWorkList);
            // --- ADD END   田村顕成 2022/10/18 -----<<<<<
		}
		#endregion

        # region [プリンタ設定取得]
        /// <summary>
        /// プリンタ設定　全取得
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        /// <remarks>※プリンタ管理設定はローカルＸＭＬを読み込みます。</remarks>
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
        /// <returns></returns>
        private int GetPosTerminalMg( out PosTerminalMg posTerminalMg, string enterpriseCode )
        {
            PosTerminalMgAcs acs = new PosTerminalMgAcs();
            return acs.Search( out posTerminalMg, enterpriseCode );

            //..debug
            //posTerminalMg = new PosTerminalMg();
            //posTerminalMg.CashRegisterNo = 1;
            //posTerminalMg.EnterpriseCode = enterpriseCode;
            //posTerminalMg.PosPCTermCd = 0;
            //return 0;
            //..debug
        }
        # endregion

		#endregion

		#endregion
	}
}
