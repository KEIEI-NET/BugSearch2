using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections.Generic;

using ar=DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Library.Resources;
//using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using System.Drawing;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 自由帳票(在庫移動伝票)印刷クラス
	/// </summary>
	/// <remarks>
	/// <br>Note         : 自由帳票の印刷ドキュメントを作成します。</br>
	/// <br>Programmer   : 22018 鈴木　正臣</br>
	/// <br>Date         : 2008.06.03</br>
	/// <br></br>
	/// <br>Update Note  : 2009/12/09　30531 大矢　睦美</br>
    /// <br>　　　　　　　　余白設定処理の制御を追加します。</br>
	/// <br></br>
    /// <br>Update Note  : 2010/03/31　30531 大矢　睦美</br>
    /// <br>　　　　　　　: Mantis【14813】和歴・西暦の印字制御の修正</br>
    /// <br></br>
    /// <br>Update Note  : 2010/05/17  22018 鈴木 正臣</br>
    /// <br>             : サブレポート機能の追加。（森川部品個別対応の為）</br>
    /// <br></br>
    /// <br>Update Note  : 2010/05/27  30531 大矢 睦美</br>
    /// <br>             : 出庫、入庫タイトルの印字内容を設定できるように修正。（森川部品個別対応の為）</br>
    /// <br></br>
    /// <br>Update Note  : 2011/08/15 李占川   連番985</br>
    /// <br>             　【PM要望改良9月配信分】Redmine#23541 連番985の対応</br> 
    /// <br></br>
    /// </remarks>
	public class PMZAI08001PA : ISlipPrintProc
	{
		#region PrivateMember
        // --------------------------------------------------------
        // ☆☆☆ 印刷データ系 ☆☆☆
        // --------------------------------------------------------
        // 印刷データ
        private DataSet _ds;
        // 自由帳票印字位置設定マスタ
        private FrePrtPSetWork _frePrtPSet;
        //// 透かし画像
        //private System.Drawing.Image _watermarkImage;

        // --------------------------------------------------------
        // ☆☆☆ 印刷設定データ系 ☆☆☆
        // --------------------------------------------------------
        // 伝票印刷設定マスタ
        private SlipPrtSetWork _slipPrtSet;
        // 伝票タイプ別設定
        private EachSlipTypeSet _eachSlipTypeSet;
        // 在庫管理全体設定マスタ
        private StockMngTtlStWork _stockMngTtlSt;
        // 全体初期表示
        private AllDefSetWork _allDefSet;
        // 伝票印刷パラメータ
        private SlipPrintParameter _slipPrintParameter;
        // 伝票印刷条件クラス
        private SlipPrintConditionInfo _slipPrintConditionInfo;
        // --- ADD m.suzuki 2010/05/17 ---------->>>>>
        // サブレポートディクショナリ
        private Dictionary<string, ar.ActiveReport3> _subReportDic;
        // 自由帳票印字位置設定ディクショナリ
        private Dictionary<string, FrePrtPSetWork> _frePrtPSetDic;
        // --- ADD m.suzuki 2010/05/17 ----------<<<<<

        // --------------------------------------------------------
        // ☆☆☆ 印刷ドキュメント ☆☆☆
        // --------------------------------------------------------
        // プレビュードキュメントクラス
        private Document _previewDocument;
        // 印刷ドキュメントクラス
        private Document _printDocument;

        // --------------------------------------------------------
        // 印刷制御
        // --------------------------------------------------------
        private PMCMN02000CA _reportCtrl;

        #endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public PMZAI08001PA()
		{
            _previewDocument = new Document();
            _printDocument = new Document();

            _reportCtrl = PMCMN02000CA.GetInstance();
		}
		#endregion

		#region ISlipPrintProc メンバ
		/// <summary>
		/// 印刷ドキュメント（プレビュー用）
		/// </summary>
		public Document PreviewDocument
		{
			get { return _previewDocument; }
		}

		/// <summary>
		/// 印刷ドキュメント（印刷用）
		/// </summary>
		public Document PrintDocument
		{
			get { return _printDocument; }
		}

		/// <summary>
		/// 印刷用情報取得処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="slipPrintConditionInfo">印刷設定情報オブジェクト</param>
		/// <param name="slipPrintData">印刷内容情報オブジェクト</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 印刷用データを取得します。</br>
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.08.09</br>
        /// <br>Update Note : 2011/08/15 李占川</br>
        /// <br>             【PM要望改良9月配信分】Redmine#23541 連番985の対応</br> 
		/// </remarks>
		public int SetPrintConditionInfoAndData(object sender, SlipPrintConditionInfo slipPrintConditionInfo, object slipPrintData)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			try
			{
				_slipPrintConditionInfo = slipPrintConditionInfo;

				// 印刷系データ取得
				if (slipPrintData != null)
				{
                    // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                    _frePrtPSetDic = null;
                    Dictionary<string, bool> decryptedFrePrtPSetDic = null;
                    // --- ADD m.suzuki 2010/05/17 ----------<<<<<

                    // 設定系データ取得
                    # region [設定系データ取得]
                    if ( slipPrintConditionInfo != null )
                    {
                        ArrayList extrInfoList = (ArrayList)slipPrintConditionInfo.ExtrInfo;

                        foreach ( Object wkObj in extrInfoList )
                        {
                            // 伝票印刷設定マスタ
                            if ( wkObj is SlipPrtSetWork )
                            {
                                _slipPrtSet = (SlipPrtSetWork)wkObj;
                                _eachSlipTypeSet = new EachSlipTypeSet( _slipPrtSet );
                            }
                            // 自由帳票印字位置設定マスタ
                            else if ( wkObj is FrePrtPSetWork )
                            {
                                _frePrtPSet = (FrePrtPSetWork)wkObj;
                            }
                            // 在庫管理全体設定マスタ
                            else if ( wkObj is StockMngTtlStWork )
                            {
                                _stockMngTtlSt = (StockMngTtlStWork)wkObj;
                            }
                            // 全体初期表示設定マスタ
                            else if ( wkObj is AllDefSetWork )
                            {
                                _allDefSet = (AllDefSetWork)wkObj;
                            }
                            // 伝票印刷パラメータ
                            else if ( wkObj is Dictionary<string,object>)
                            {
                                _slipPrintParameter = new SlipPrintParameter( (Dictionary<string, object>)wkObj );
                            }
                            // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                            // 自由帳票印字位置設定ディクショナリ
                            else if ( wkObj is Dictionary<string, FrePrtPSetWork> )
                            {
                                _frePrtPSetDic = (Dictionary<string, FrePrtPSetWork>)wkObj;
                            }
                            // 復号化済み自由帳票印字位置設定ディクショナリ
                            else if ( wkObj is Dictionary<string, bool> )
                            {
                                decryptedFrePrtPSetDic = (Dictionary<string, bool>)wkObj;
                            }
                            // --- ADD m.suzuki 2010/05/17 ----------<<<<<
                        }
                    }

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 ADD
                    if ( CheckExistsMasters() == false )
                    {
                        return -1;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 ADD
                    # endregion

                    // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                    //// 印刷レイアウト情報取得
                    //Dictionary<string, string> columnVisibleTypeDic;
                    //Dictionary<string, string> titleDic;
                    //GetLayoutInfo(_frePrtPSet, out columnVisibleTypeDic );
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
                    // 印刷レイアウト情報取得
                    Dictionary<string, string> columnVisibleTypeDic = new Dictionary<string, string>();
                    Dictionary<string, string> titleDic = new Dictionary<string, string>();
                    // --- UPD  大矢睦美  2010/05/27 ---------->>>>>
                    //GetLayoutInfo( _frePrtPSet, ref columnVisibleTypeDic );
                    GetLayoutInfo(_frePrtPSet, ref columnVisibleTypeDic, ref titleDic);
                    // --- UPD  大矢睦美  2010/05/27 ----------<<<<<
                    // --- UPD m.suzuki 2010/05/17 ----------<<<<<

                    // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                    // サブレポートディクショナリ更新（keyに合致するReportを取得して格納する）
                    ReflectSubReportDic( ref _subReportDic, _frePrtPSetDic, decryptedFrePrtPSetDic, ref columnVisibleTypeDic, ref titleDic );
                    _reportCtrl.SubReportDic = _subReportDic;
                    _reportCtrl.SubReportTargetList = new List<string>( new string[] { "FREEPRINT.SUBREPORT" } );
                    // --- ADD m.suzuki 2010/05/17 ----------<<<<<

                    // 印刷データ展開
                    _ds = new DataSet();
                    List<ArrayList> slipPrintDataList = (List<ArrayList>)slipPrintData;
                    int index = 0;

					foreach (ArrayList wkObj in slipPrintDataList)
					{
                        // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                        //// テーブルスキーム生成
                        //DataTable table = PMZAI08001PB.CreateFrePStockMoveSlipTable( index );

                        //FrePStockMoveSlipWork slipWork = (FrePStockMoveSlipWork)(wkObj as ArrayList)[0];
                        //List<FrePStockMoveDetailWork> detailWorks = (List<FrePStockMoveDetailWork>)(wkObj as ArrayList)[1];

                        //// データ展開
                        //PMZAI08001PB.CopyToDataTable( ref table, slipWork, detailWorks, _frePrtPSet, _slipPrtSet, _eachSlipTypeSet, _stockMngTtlSt, _allDefSet, _slipPrintParameter, columnVisibleTypeDic );

                        //_ds.Tables.Add( table );
                        //index++;

                        List<DataTable> tables = new List<DataTable>();
                        FrePStockMoveSlipWork slipWork = (FrePStockMoveSlipWork)(wkObj as ArrayList)[0];
                        List<FrePStockMoveDetailWork> detailWorks = (List<FrePStockMoveDetailWork>)(wkObj as ArrayList)[1];

                            // データ展開
                        // --- UPD  大矢睦美  2010/05/27 ---------->>>>>
                        //PMZAI08001PB.CopyToDataTable( ref tables, ref index, slipWork, detailWorks, _frePrtPSet, _slipPrtSet, _eachSlipTypeSet, _stockMngTtlSt, _allDefSet, _slipPrintParameter, columnVisibleTypeDic );
                        // --- UPD 李占川 2011/08/15---------->>>>>
                        //PMZAI08001PB.CopyToDataTable(ref tables, ref index, slipWork, detailWorks, _frePrtPSet, _slipPrtSet, _eachSlipTypeSet, _stockMngTtlSt, _allDefSet, _slipPrintParameter, columnVisibleTypeDic, titleDic);
                        PMZAI08001PB.CopyToDataTable(ref tables, ref index, slipWork, detailWorks, _frePrtPSet, _slipPrtSet, _eachSlipTypeSet, _stockMngTtlSt, _allDefSet, _slipPrintParameter, columnVisibleTypeDic, titleDic, _subReportDic);
                        // --- UPD 李占川 2011/08/15----------<<<<<
                        // --- UPD  大矢睦美  2010/05/27 ----------<<<<<

                        _ds.Tables.AddRange( tables.ToArray() );
                        // --- UPD m.suzuki 2010/05/17 ----------<<<<<
                    }
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
				string message = "印刷用情報取得処理にて例外が発生しました。"
					+ "\n\r" + ex.Message + "\n\r" + ex.StackTrace;
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_STOPDISP
					, ToString()
					, "自由帳票伝票印刷"
					, ex.TargetSite.ToString()
					, TMsgDisp.OPE_PRINT
					, message
					, status
					, null
					, MessageBoxButtons.OK
					, MessageBoxDefaultButton.Button1);
				return -1;
			}

			return status;
		}
        // --- ADD m.suzuki 2010/05/17 ---------->>>>>
        /// <summary>
        /// サブレポートディクショナリ更新処理
        /// </summary>
        /// <param name="subReportDic"></param>
        /// <param name="frePrtPSetDic"></param>
        /// <param name="decryptedFrePrtPSetDic"></param>
        private void ReflectSubReportDic( ref Dictionary<string, ar.ActiveReport3> subReportDic, Dictionary<string, FrePrtPSetWork> frePrtPSetDic, Dictionary<string, bool> decryptedFrePrtPSetDic, ref Dictionary<string, string> columnVisibleTypeDic, ref Dictionary<string, string> titleDic )
        {
            if ( subReportDic == null )
            {
                subReportDic = new Dictionary<string, DataDynamics.ActiveReports.ActiveReport3>();
                return;
            }
            if ( frePrtPSetDic == null || decryptedFrePrtPSetDic == null )
            {
                return;
            }

            Dictionary<string, DataDynamics.ActiveReports.ActiveReport3> newDic = new Dictionary<string, DataDynamics.ActiveReports.ActiveReport3>();

            foreach ( string key in subReportDic.Keys )
            {
                if ( !frePrtPSetDic.ContainsKey( key ) ) continue;
                FrePrtPSetWork pSetWork = frePrtPSetDic[key];

                if ( !decryptedFrePrtPSetDic.ContainsKey( key ) )
                {
                    // まだ復号化していない⇒復号化する
                    FrePrtSettingController.DecryptPrintPosClassData( pSetWork );
                    decryptedFrePrtPSetDic.Add( key, true );
                }

                // レイアウト情報取得処理
                GetLayoutInfo( pSetWork, ref columnVisibleTypeDic, ref titleDic);

                // レポート情報からレイアウト情報を復元する
                using ( MemoryStream stream = new MemoryStream( pSetWork.PrintPosClassData ) )
                {
                    // レイアウト生成
                    ar.ActiveReport3 prtRpt = new ar.ActiveReport3();
                    stream.Position = 0;
                    prtRpt.LoadLayout( stream );

                    // スクリプトクリア
                    prtRpt.Script = string.Empty;

                    // ディクショナリに追加
                    newDic.Add( key, prtRpt );
                }
            }

            // ディクショナリを差し替える
            subReportDic = newDic;
        }
        /// <summary>
        /// サブレポートディクショナリ再生成処理
        /// </summary>
        /// <param name="subReportDic"></param>
        /// <param name="frePrtPSetDic"></param>
        private void RenewSubReportDic( ref Dictionary<string, ar.ActiveReport3> subReportDic, Dictionary<string, FrePrtPSetWork> frePrtPSetDic )
        {
            //--------------------------------------------
            // ※ページ切替、複写切替の際にメインのレポートの
            //   インスタンスは作り直しているので、
            //   それに関連付けるサブレポートも
            //   インスタンスを作り直す必要がある。
            //--------------------------------------------

            if ( subReportDic == null )
            {
                subReportDic = new Dictionary<string, DataDynamics.ActiveReports.ActiveReport3>();
                return;
            }
            if ( frePrtPSetDic == null )
            {
                return;
            }

            Dictionary<string, ar.ActiveReport3> newDic = new Dictionary<string, ar.ActiveReport3>();

            foreach ( string key in subReportDic.Keys )
            {
                if ( !frePrtPSetDic.ContainsKey( key ) ) continue;
                FrePrtPSetWork pSetWork = frePrtPSetDic[key];

                // レポート情報からレイアウト情報を復元する
                using ( MemoryStream stream = new MemoryStream( pSetWork.PrintPosClassData ) )
                {
                    // レイアウト生成
                    ar.ActiveReport3 prtRpt = new ar.ActiveReport3();
                    stream.Position = 0;
                    prtRpt.LoadLayout( stream );

                    // スクリプトクリア
                    prtRpt.Script = string.Empty;

                    // ディクショナリに追加
                    newDic.Add( key, prtRpt );
                }
            }

            // ディクショナリを差し替える
            subReportDic = newDic;
        }
        // --- ADD m.suzuki 2010/05/17 ----------<<<<<
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
        /// <summary>
        /// 印刷レイアウト情報取得
        /// </summary>
        /// <param name="_frePrtPSet"></param>
        /// <param name="columnVisibleTypeDic"></param>
        // --- UPD m.suzuki 2010/05/17 ---------->>>>>
        //private void GetLayoutInfo( FrePrtPSetWork frePrtPSet, out Dictionary<string, string> columnVisibleTypeDic)
        // --- UPD  大矢睦美  2010/05/27 ---------->>>>>
        //private void GetLayoutInfo( FrePrtPSetWork frePrtPSet, ref Dictionary<string, string> columnVisibleTypeDic) 
        private void GetLayoutInfo( FrePrtPSetWork frePrtPSet, ref Dictionary<string, string> columnVisibleTypeDic, ref Dictionary<string,string> titleDic)
        // --- UPD  大矢睦美  2010/05/27 ----------<<<<<
        // --- UPD m.suzuki 2010/05/17 ----------<<<<<
        {
            // 初期化
            // --- UPD m.suzuki 2010/05/17 ---------->>>>>
            columnVisibleTypeDic = new Dictionary<string, string>();
            //// --- ADD  大矢睦美  2010/03/31 ---------->>>>>
            ////titleDic = new Dictionary<string, string>();
            //Dictionary<string, string> reportItemDic = new Dictionary<string, string>();
            //// --- ADD  大矢睦美  2010/03/31 ----------<<<<<
            if ( columnVisibleTypeDic == null )
            {
                columnVisibleTypeDic = new Dictionary<string, string>();
            }
            Dictionary<string, string> reportItemDic = PMZAI08001PB.ReportItemDic;
            if ( reportItemDic == null )
            {
                reportItemDic = new Dictionary<string, string>();
            }
            // --- UPD m.suzuki 2010/05/17 ----------<<<<<
            // --- ADD  大矢睦美  2010/05/27 ---------->>>>>
            if (titleDic == null)
            {
                titleDic = new Dictionary<string, string>();
            }
            // --- ADD  大矢睦美  2010/05/27 ----------<<<<<

            // --- UPD m.suzuki 2010/05/17 ---------->>>>>
            //if (_frePrtPSet == null || _frePrtPSet.PrintPosClassData == null) return;
            // 
            //using (MemoryStream stream = new MemoryStream(_frePrtPSet.PrintPosClassData))

            if ( frePrtPSet == null || frePrtPSet.PrintPosClassData == null ) return;

            using ( MemoryStream stream = new MemoryStream( frePrtPSet.PrintPosClassData ) )
            // --- UPD m.suzuki 2010/05/17 ----------<<<<<
            {
                // レイアウト生成
                ar.ActiveReport3 prtRpt = new ar.ActiveReport3();
                stream.Position = 0;
                prtRpt.LoadLayout( stream );

                // レイアウト情報の取得
                foreach ( DataDynamics.ActiveReports.Section section in prtRpt.Sections )
                {
                    foreach ( DataDynamics.ActiveReports.ARControl arControl in section.Controls )
                    {
                        if ( arControl is ar.TextBox && arControl.Tag is string )
                        {
                            // 【Tag情報の取得】
                            //   0: FreePrtPaperItemCd
                            //   1: PrintPageCtrlDivCd
                            //   2: GroupSuppressCd
                            //   3: DtlColorChangeCd
                            //   4: HeightAdjustDivCd);
                            string[] data = (arControl.Tag as String).Split( ',' );

                            // ※同一項目が複数ある場合は最初にヒットした情報を使用する。
                            string dataFieldName = arControl.DataField.ToUpper();
                            if ( !columnVisibleTypeDic.ContainsKey( dataFieldName ) )
                            {
                                // 伝票印刷用に変更したPrintPageCtrlDivCdを格納
                                columnVisibleTypeDic.Add( dataFieldName, data[1] );
                            }

                            // --- ADD  大矢睦美  2010/05/27 ---------->>>>>
                            //出庫タイトルテキスト退避
                            if ((arControl.Tag as String).StartsWith("91,"))
                            {
                                if (!titleDic.ContainsKey(PMZAI08001PB.ct_BfTitle))
                                {
                                    titleDic.Add(PMZAI08001PB.ct_BfTitle, (arControl as ar.TextBox).Text);
                                }
                            }
                            //入庫タイトルテキスト退避
                            if ((arControl.Tag as String).StartsWith("92,"))
                            {
                                if (!titleDic.ContainsKey(PMZAI08001PB.ct_AfTitle))
                                {
                                    titleDic.Add(PMZAI08001PB.ct_AfTitle, (arControl as ar.TextBox).Text);
                                }
                            }
                            // --- ADD  大矢睦美  2010/05/27 ----------<<<<<
                            // --- ADD  大矢睦美  2010/03/31 ---------->>>>>
                            if (!reportItemDic.ContainsKey(dataFieldName))
                            {
                                reportItemDic.Add(dataFieldName, dataFieldName);
                            }
                            // --- ADD  大矢睦美  2010/03/31 ----------<<<<<
                        }
                        // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                        else if ( arControl is ar.Label )
                        {
                            ar.Label label = (arControl as ar.Label);
                            const string subReportDataField = "FREEPRINT.SUBREPORT";

                            // サブレポート機能の判定
                            if ( arControl.DataField == subReportDataField )
                            {
                                // Textをカンマで区切る。
                                string formName = label.Text.Split( ',' )[0];

                                if ( _subReportDic == null )
                                {
                                    _subReportDic = new Dictionary<string, DataDynamics.ActiveReports.ActiveReport3>();
                                }

                                if ( !_subReportDic.ContainsKey( formName ) )
                                {
                                    // サブレポートディクショナリに追加（valueとなるReportは後で読み込んでセットする）
                                    _subReportDic.Add( formName, null );

                                    // レポート項目ディクショナリに追加
                                    if ( !reportItemDic.ContainsKey( subReportDataField ) )
                                    {
                                        reportItemDic.Add( subReportDataField, subReportDataField );
                                    }
                                }
                            }
                        }
                        // --- ADD m.suzuki 2010/05/17 ----------<<<<<
                    }
                }
            }
            // --- ADD  大矢睦美  2010/03/31 ---------->>>>>
            PMZAI08001PB.ReportItemDic = reportItemDic;
            // --- ADD  大矢睦美  2010/03/31 ----------<<<<<
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 ADD
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckExistsMasters()
        {
            List<string> errorList = new List<string>();

            // 伝票印刷設定マスタ
            if ( _slipPrtSet == null )
            {
                errorList.Add( "伝票印刷設定" );
            }
            // 自由帳票印字位置設定マスタ
            else if ( _frePrtPSet == null )
            {
                errorList.Add( "自由帳票印字位置設定" );
            }
            // 在庫管理全体設定マスタ
            else if ( _stockMngTtlSt == null )
            {
                errorList.Add( "在庫管理全体設定" );
            }
            // 全体初期表示設定マスタ
            else if ( _allDefSet == null )
            {
                errorList.Add( "全体初期表示設定" );
            }

            if ( errorList.Count == 0 )
            {
                return true;
            }
            else
            {
                string errMsg = "以下のマスタ登録内容が不正な為、印刷できませんでした。" + Environment.NewLine + Environment.NewLine;
                foreach ( string err in errorList )
                {
                    errMsg += string.Format( "  {0}{1}", err, Environment.NewLine );
                }
                errMsg += Environment.NewLine;

                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOPDISP
                    , ToString()
                    , "自由帳票伝票印刷"
                    , ""
                    , TMsgDisp.OPE_PRINT
                    , errMsg
                    , -1
                    , null
                    , MessageBoxButtons.OK
                    , MessageBoxDefaultButton.Button1 );

                return false;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 ADD

		/// <summary>
		/// 印刷開始処理（プレビュー無し）
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 印刷処理を開始します。</br>
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.08.09</br>
		/// </remarks>
		public int StartDirectPrint(object sender)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			status = StartPrint(true);

			return status;
		}

		/// <summary>
		/// 印刷開始処理（PDF出力）
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: PDF出力処理を開始します。</br>
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.08.09</br>
		/// </remarks>
		public int StartPdfPrint(object sender)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			status = StartPrint(false);

			return status;
		}

		/// <summary>
		/// プレビュー処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 印刷処理を開始します。</br>
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.08.09</br>
		/// </remarks>
		public int StartPreview(object sender)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			status = StartPrint(false);

			return status;
		}

		/// <summary>
		/// 印刷開始処理（プレビュー有り）
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 印刷処理を開始します。</br>
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.08.09</br>
		/// </remarks>
		public int StartPreviewPrint(object sender)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			status = StartPrint(false);

			return status;
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 印刷処理を行います。</br>
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.08.09</br>
		/// </remarks>
		private int StartPrint(bool isDirectPrint)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            if ( _frePrtPSet == null || _frePrtPSet.PrintPosClassData == null ) return status;

            // レポートドキュメント初期化
            _printDocument = new Document();
            _previewDocument = new Document();

            using ( MemoryStream stream = new MemoryStream( _frePrtPSet.PrintPosClassData ) )
			{
                //ar.ActiveReport3 prvRpt = null;
				ar.ActiveReport3 prtRpt = null;

                for ( int tableIndex = 0; tableIndex != _ds.Tables.Count; tableIndex++ )
                {
                    // ---------------------------------
                    // 印刷用Documentの生成
                    // ---------------------------------

                    // 印刷部数分繰り返す
                    for ( int circulateCount = 0; circulateCount < _slipPrtSet.PrtCirculation; circulateCount++ )
                    {
                        // 複写枚数分繰り返す
                        for ( int copyCount = 0; copyCount < _slipPrtSet.CopyCount; copyCount++ )
                        {
                            prtRpt = new ar.ActiveReport3();
                            stream.Position = 0;
                            prtRpt.LoadLayout( stream );
                            // --- DEL m.suzuki 2010/05/17 ---------->>>>>
                            //# if DEBUG
                            //if ( circulateCount == 0 && copyCount == 0)
                            //{
                            //    prtRpt.SaveLayout( "d:\\PMZAI08001P.dat" );
                            //}
                            //# endif
                            // --- DEL m.suzuki 2010/05/17 ----------<<<<<
                            // --- DEL m.suzuki 2010/05/17 ---------->>>>>
                            //SFANL08235CE.AddScriptReference( ref prtRpt );	// Script用参照追加
                            // --- DEL m.suzuki 2010/05/17 ----------<<<<<
                            // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                            prtRpt.Script = string.Empty;
                            // --- ADD m.suzuki 2010/05/17 ----------<<<<<
                            SetMargin( prtRpt );
                            SFANL08235CE.SetValidPaperKind( prtRpt );
                            _reportCtrl.SetReportProps( ref prtRpt ); // 帳票共通設定
                            prtRpt.DataSource = _ds;
                            prtRpt.DataMember = _ds.Tables[tableIndex].TableName;

                            # region [同一ページ内コピー制御]
                            DataDynamics.ActiveReports.GroupHeader topHeader;
                            try
                            {
                                topHeader = (DataDynamics.ActiveReports.GroupHeader)prtRpt.Sections["GroupHeader1"];
                            }
                            catch
                            {
                                prtRpt.Sections.Add( DataDynamics.ActiveReports.SectionType.GroupHeader, "GroupHeader1" );
                                topHeader = (DataDynamics.ActiveReports.GroupHeader)prtRpt.Sections["GroupHeader1"];
                            }
                            topHeader.DataField = PMZAI08001PB.ct_InPageCopyCount;
                            topHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
                            # endregion


                            // 複写に伴うフィールド設定
                            SettingFieldInfoByTag( ref prtRpt, copyCount );
                            // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                            # region [サブレポートにも適用]
                            // サブレポート情報の再作成
                            if ( tableIndex != 0 || circulateCount != 0 || copyCount != 0 )
                            {
                                RenewSubReportDic( ref _subReportDic, _frePrtPSetDic );
                                _reportCtrl.SubReportDic = _subReportDic;
                            }
                            // サブレポートに共通処理適用
                            foreach ( string key in _reportCtrl.SubReportDic.Keys )
                            {
                                ar.ActiveReport3 subReport = _reportCtrl.SubReportDic[key];
                                _reportCtrl.SetReportProps( ref subReport );
                                SettingFieldInfoByTag( ref subReport, copyCount );
                            }
                            # endregion
                            // --- ADD m.suzuki 2010/05/17 ----------<<<<<
                            
                            // 印刷実行
                            prtRpt.Run();

                            // 印刷用Documentにまとめる
                            _printDocument.Pages.AddRange( prtRpt.Document.Pages );

                            // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                            // プレビューは印刷部数によらず常に１部の分だけ表示する
                            if ( circulateCount == 0 && copyCount == 0 )
                            {
                                _previewDocument.Pages.AddRange( prtRpt.Document.Pages );
                            }
                            // --- ADD m.suzuki 2010/05/17 ----------<<<<<
                        }

                        // --- DEL m.suzuki 2010/05/17 ---------->>>>>
                        //// プレビューは印刷部数によらず常に１部の分だけ表示する
                        //if ( circulateCount == 0 )
                        //{
                        //    _previewDocument.Pages.AddRange( _printDocument.Pages );
                        //}
                        // --- DEL m.suzuki 2010/05/17 ----------<<<<<
                    }
                }
                if ( prtRpt != null )
                {
                    SetPrinterInfo( _printDocument );

                    // 用紙の種類を指定
                    _printDocument.Printer.PaperKind = prtRpt.PageSettings.PaperKind;
                    _previewDocument.Printer.PaperKind = prtRpt.PageSettings.PaperKind;
                    // 用紙サイズがカスタムの時は用紙サイズまで指定
                    if ( prtRpt.PageSettings.PaperKind == PaperKind.Custom )
                        _printDocument.Printer.PaperSize = new PaperSize( "Custom", Convert.ToInt32( prtRpt.PageSettings.PaperWidth * 100 ), Convert.ToInt32( prtRpt.PageSettings.PaperHeight * 100 ) );
                    // 用紙方向（縦・横）の設定
                    if ( prtRpt.PageSettings.Orientation == PageOrientation.Landscape )
                    {
                        _printDocument.Printer.Landscape = true;
                        _previewDocument.Printer.Landscape = true;
                    }
                }

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/28 ADD
                // 直接印刷の場合
                if ( isDirectPrint )
                {
                    _printDocument.Print( false, false, false );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/28 ADD

                stream.Close();
			}

			return status;
		}

        /// <summary>
        /// 複写に伴うフィールド設定処理
        /// </summary>
        /// <param name="prtRpt"></param>
        /// <param name="copyCount"></param>
        /// <remarks>伝票複写により変化する、伝票背景色、伝票タイトルに関する制御を行います。印字項目CD=51～100に対する処理。</remarks>
        /// 
        private void SettingFieldInfoByTag( ref DataDynamics.ActiveReports.ActiveReport3 prtRpt, int copyCount )
        {
            # region [複写色]
            Color backColor = GetBackColor( copyCount );
            Color backColorLight = MixColor( backColor, Color.FromArgb( 77, 70, 87 ), 0 );

            Color foreColor;
            // 背景が暗い場合は文字を白抜きにする
            if ( IsDark( backColor ) )
            {
                foreColor = Color.White;
            }
            else
            {
                foreColor = Color.Black;
            }
            # endregion

            foreach ( DataDynamics.ActiveReports.Section section in prtRpt.Sections )
            {
                foreach ( DataDynamics.ActiveReports.ARControl arControl in section.Controls )
                {
                    // --- UPD m.suzuki 2010/05/17 ---------->>>>>
                    //if (arControl.Tag is string)
                    if ( (arControl.Tag is string) && (arControl.Tag as string).Length >= 3 )
                    // --- UPD m.suzuki 2010/05/17 ----------<<<<<
                    {
                        string tagSub = (arControl.Tag as string).Substring( 0, 3 );

                        # region [特殊項目(51～100)]
                        switch ( tagSub )
                        {
                            // --- ADD 李占川 2011/08/15---------->>>>>
                            case "34,":
                                {
                                    //-------------------------------------------
                                    // 「34:タイトル１」の場合
                                    //-------------------------------------------
                                    switch (copyCount)
                                    {
                                        case 0:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_SlipTitle11;
                                            break;
                                        case 1:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_SlipTitle21;
                                            break;
                                        case 2:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_SlipTitle31;
                                            break;
                                        case 3:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_SlipTitle41;
                                            break;
                                        default:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                            break;
                                    }
                                }
                                break;
                            case "35,":
                                {
                                    //-------------------------------------------
                                    // 「35:タイトル２」の場合
                                    //-------------------------------------------
                                    switch (copyCount)
                                    {
                                        case 0:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_SlipTitle12;
                                            break;
                                        case 1:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_SlipTitle22;
                                            break;
                                        case 2:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_SlipTitle32;
                                            break;
                                        case 3:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_SlipTitle42;
                                            break;
                                        default:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                            break;
                                    }
                                }
                                break;
                            case "36,":
                                {
                                    //-------------------------------------------
                                    // 「36:タイトル３」の場合
                                    //-------------------------------------------
                                    switch (copyCount)
                                    {
                                        case 0:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_SlipTitle13;
                                            break;
                                        case 1:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_SlipTitle23;
                                            break;
                                        case 2:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_SlipTitle33;
                                            break;
                                        case 3:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_SlipTitle43;
                                            break;
                                        default:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                            break;
                                    }
                                }
                                break;
                            case "37,":
                                {
                                    //-------------------------------------------
                                    // 「37:タイトル４」の場合
                                    //-------------------------------------------
                                    switch (copyCount)
                                    {
                                        case 0:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_SlipTitle14;
                                            break;
                                        case 1:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_SlipTitle24;
                                            break;
                                        case 2:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_SlipTitle34;
                                            break;
                                        case 3:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_SlipTitle44;
                                            break;
                                        default:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                            break;
                                    }
                                }
                                break;
                            case "38,":
                                {
                                    //-------------------------------------------
                                    // 「38:タイトル５」の場合
                                    //-------------------------------------------
                                    switch (copyCount)
                                    {
                                        case 0:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_SlipTitle15;
                                            break;
                                        case 1:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_SlipTitle25;
                                            break;
                                        case 2:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_SlipTitle35;
                                            break;
                                        case 3:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_SlipTitle45;
                                            break;
                                        default:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                            break;
                                    }
                                }
                                break;
                            // --- ADD 李占川 2011/08/15----------<<<<<

                            case "51,":
                                {
                                    //-------------------------------------------
                                    // 「51:複写色背景固定文字」の場合
                                    //-------------------------------------------
                                    DataDynamics.ActiveReports.Label label = (arControl as DataDynamics.ActiveReports.Label);
                                    label.BackColor = backColorLight;
                                    label.ForeColor = foreColor;
                                    // 矩形枠の色設定
                                    label.Border.TopColor = backColor;
                                    label.Border.BottomColor = backColor;
                                    label.Border.LeftColor = backColor;
                                    label.Border.RightColor = backColor;
                                }
                                break;
                            case "52,":
                                {
                                    //-------------------------------------------
                                    // 「52:複写色直線」の場合
                                    //-------------------------------------------
                                    (arControl as DataDynamics.ActiveReports.Line).LineColor = backColor;
                                }
                                break;
                            case "53,":
                                {
                                    //-------------------------------------------
                                    // 「53:複写色枠線」の場合
                                    //-------------------------------------------
                                    (arControl as DataDynamics.ActiveReports.Shape).LineColor = backColor;
                                }
                                break;
                            case "54,":
                                {
                                    //-------------------------------------------
                                    // 「54:複写色固定文字」の場合
                                    //-------------------------------------------
                                    (arControl as DataDynamics.ActiveReports.TextBox).ForeColor = backColor;
                                }
                                break;
                            case "55,":
                                {
                                    //-------------------------------------------
                                    // 「55:複写対応伝票タイトル」の場合
                                    //-------------------------------------------
                                    //(arControl as DataDynamics.ActiveReports.Label).Text = GetSlipTitle( copyCount );
                                    //(arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                    switch ( copyCount )
                                    {
                                        case 0:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_InPageCopyTitle1;
                                            break;
                                        case 1:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_InPageCopyTitle2;
                                            break;
                                        case 2:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_InPageCopyTitle3;
                                            break;
                                        case 3:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMZAI08001PB.ct_InPageCopyTitle4;
                                            break;
                                        default:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                            break;
                                    }
                                }
                                break;
                            case "56,":
                                {
                                    //-------------------------------------------
                                    // 「56:自社情報固定文字」の場合
                                    //-------------------------------------------
                                    // 0:自社名印字　1:拠点名印字　2:ビットマップを印字　3:印字しない
                                    switch ( _slipPrtSet.EnterpriseNamePrtCd )
                                    {
                                        case 2:
                                        case 3:
                                            {
                                                arControl.Visible = false;
                                            }
                                            break;
                                    }
                                }
                                break;
                            case "57,":
                                {
                                    //-------------------------------------------
                                    // 「57:印刷時刻固定文字」の場合
                                    //-------------------------------------------
                                    // 0:非印字,1:印字
                                    if ( _slipPrtSet.TimePrintDivCd == 0 )
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "58,":
                                {
                                    //-------------------------------------------
                                    // 「58:担当者タイトル」の場合
                                    //-------------------------------------------
                                    if ( _eachSlipTypeSet.SalesEmployee == 0 )
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "59,":
                                {
                                    //-------------------------------------------
                                    // 「59:発行者タイトル」の場合
                                    //-------------------------------------------
                                    if ( _eachSlipTypeSet.SalesInput == 0 )
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "60,":
                                {
                                    //-------------------------------------------
                                    // 「60:品番タイトル」の場合
                                    //-------------------------------------------
                                    if ( _eachSlipTypeSet.GoodsNo == 0 )
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "61,":
                                {
                                    //-------------------------------------------
                                    // 「61:ＢＬコードタイトル」の場合
                                    //-------------------------------------------
                                    if ( _eachSlipTypeSet.BLGoodsCode == 0 )
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "62,":
                                {
                                    //-------------------------------------------
                                    // 「62:標準価格タイトル」の場合
                                    //-------------------------------------------
                                    if ( _eachSlipTypeSet.ListPrice1 == 0 )
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "63,":
                                {
                                    //-------------------------------------------
                                    // 「63:原価タイトル」の場合
                                    //-------------------------------------------
                                    if ( _eachSlipTypeSet.Cost == 0 )
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        # endregion
                    }
                }
            }
        }
        # region [伝票複写対応]
        /// <summary>
        /// 複写対応伝票タイトル取得処理
        /// </summary>
        /// <param name="copyCount"></param>
        /// <returns></returns>
        private string GetSlipTitle( int copyCount )
        {
            switch ( copyCount )
            {
                case 0:
                    return _slipPrtSet.TitleName1;
                case 1:
                    return _slipPrtSet.TitleName2;
                case 2:
                    return _slipPrtSet.TitleName3;
                case 3:
                    return _slipPrtSet.TitleName4;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// 伝票背景色取得処理
        /// </summary>
        /// <param name="copyCountIndex">複写ページindex</param>
        /// <returns></returns>
        private Color GetBackColor( int copyCountIndex )
        {
            switch ( copyCountIndex )
            {
                case 0:
                    return Color.FromArgb( _slipPrtSet.SlipBaseColorRed1, _slipPrtSet.SlipBaseColorGrn1, _slipPrtSet.SlipBaseColorBlu1 );
                case 1:
                    return Color.FromArgb( _slipPrtSet.SlipBaseColorRed2, _slipPrtSet.SlipBaseColorGrn2, _slipPrtSet.SlipBaseColorBlu2 );
                case 2:
                    return Color.FromArgb( _slipPrtSet.SlipBaseColorRed3, _slipPrtSet.SlipBaseColorGrn3, _slipPrtSet.SlipBaseColorBlu3 );
                case 3:
                    return Color.FromArgb( _slipPrtSet.SlipBaseColorRed4, _slipPrtSet.SlipBaseColorGrn4, _slipPrtSet.SlipBaseColorBlu4 );
                case 4:
                    return Color.FromArgb( _slipPrtSet.SlipBaseColorRed5, _slipPrtSet.SlipBaseColorGrn5, _slipPrtSet.SlipBaseColorBlu5 );
                default:
                    return Color.Transparent;
            }
        }
        /// <summary>
        /// 色合成処理
        /// </summary>
        /// <param name="firstColor">合成元のColor構造体</param>
        /// <param name="secondColor">合成元のColor構造体</param>
        /// <param name="mixMode">合成モード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note         : ２つのColor構造体から別のColor構造体を作成します。</br>
        /// <br>               （この処理はDC.NS流通伝票印刷の仕様に準拠しています。）</br>
        /// <br>Programmer   : 22018 鈴木　正臣</br>
        /// <br>Date         : 2008.06.04</br>
        /// </remarks>
        private static Color MixColor( Color firstColor, Color secondColor, int mixMode )
        {
            switch ( mixMode )
            {
                case 0:
                    {
                        int redColor = firstColor.R + secondColor.R;
                        if ( redColor > 255 )
                        {
                            redColor = 255;
                        }
                        int greenColor = firstColor.G + secondColor.G;
                        if ( greenColor > 255 )
                        {
                            greenColor = 255;
                        }
                        int blueColor = firstColor.B + secondColor.B;
                        if ( blueColor > 255 )
                        {
                            blueColor = 255;
                        }

                        return Color.FromArgb( redColor, greenColor, blueColor );
                    }
            }
            return Color.Transparent;
        }
        /// <summary>
        /// 背景色　明暗判定
        /// </summary>
        /// <param name="backColor"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>（この処理はDC.NS流通伝票印刷の仕様に準拠しています。）</br>
        /// </remarks>
        private static bool IsDark( Color backColor )
        {
            // 判定しきい値
            int divColorPoint = 200;

            if ( (int)backColor.R + (int)backColor.G + (int)backColor.B < divColorPoint )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        # endregion

        /// <summary>
		/// 余白設定処理
		/// </summary>
		/// <param name="rpt">アクティブレポートオブジェクト</param>
		/// <remarks>
		/// <br>Note		: 余白設定をします。</br>
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.08.09</br>
		/// </remarks>
		private void SetMargin(ar.ActiveReport3 rpt)
		{
			// 上の余白を設定
			rpt.PageSettings.Margins.Top
				= ar.ActiveReport3.CmToInch((float)_slipPrtSet.TopMargin);
			// 下の余白を設定
			rpt.PageSettings.Margins.Bottom
				= ar.ActiveReport3.CmToInch((float)_slipPrtSet.BottomMargin);
			// 左の余白を設定
			rpt.PageSettings.Margins.Left
				= ar.ActiveReport3.CmToInch((float)_slipPrtSet.LeftMargin);
			// 右の余白を設定
			rpt.PageSettings.Margins.Right
				= ar.ActiveReport3.CmToInch((float)_slipPrtSet.RightMargin);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  大矢　睦美 2009/12/09 ADD
            // ReportのPrintWidthがinch単位で中途半端な場合、不要な空ページが印刷されてしまうので防止する。
            // (小数第３位以降は切り捨てる)
            int width = (int)((float)rpt.PrintWidth * (float)100.0f);
            rpt.PrintWidth = (float)width / (float)100.0f;
            // 余白分を除く
            rpt.PrintWidth -= (rpt.PageSettings.Margins.Left + rpt.PageSettings.Margins.Right);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  大矢睦美 2009/12/09 ADD
		}

		/// <summary>
		/// プリンター情報セット処理
		/// </summary>
		/// <param name="document">レポートDocument</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: プリンター情報を設定します。</br>
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.08.09</br>
		/// </remarks>
		private void SetPrinterInfo(Document document)
		{
			// 使用プリンターの設定
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
            //foreach (string wkStr in PrinterSettings.InstalledPrinters)
            //{
            //    if (wkStr.Equals(_slipPrintConditionInfo.PrinterName))
            //    {
            //        document.Printer.PrinterSettings.PrinterName = _slipPrintConditionInfo.PrinterName;
            //        break;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 ADD
            document.Printer.PrinterSettings.PrinterName = _slipPrintConditionInfo.PrinterName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 ADD

			// 使用プリンタの有効有無チェック（有効では無い場合は仮想プリンタを使用）
			if (!document.Printer.PrinterSettings.IsValid)
				document.Printer.PrinterSettings.PrinterName = string.Empty;
		}
		#endregion
	}

    # region [伝票タイプ別設定]
    /// <summary>
    /// 伝票タイプ別設定
    /// </summary>
    internal struct EachSlipTypeSet
    {
        /// <summary>品番印字</summary>
        private int _goodsNo;
        /// <summary>ＢＬコード印字</summary>
        private int _bLGoodsCode;
        /// <summary>標準価格印字</summary>
        private int _listPrice1;
        /// <summary>原価印字</summary>
        private int _cost;
        /// <summary>担当者印字</summary>
        private int _salesEmployee;
        /// <summary>発行者印字</summary>
        private int _salesInput;
        /// <summary>
        /// 品番印字
        /// </summary>
        /// <remarks>0:印字しない,1:印字する</remarks>
        public int GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }
        /// <summary>
        /// ＢＬコード印字
        /// </summary>
        /// <remarks>0:印字しない,1:印字する</remarks>
        public int BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }
        /// <summary>
        /// 標準価格印字
        /// </summary>
        /// <remarks>0:印字しない,1:印字する</remarks>
        public int ListPrice1
        {
            get { return _listPrice1; }
            set { _listPrice1 = value; }
        }
        /// <summary>
        /// 原価印字
        /// </summary>
        /// <remarks>0:印字しない,1:印字する</remarks>
        public int Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
        /// <summary>
        /// 担当者印字
        /// </summary>
        /// <remarks>0:印字しない,1:印字する</remarks>
        public int SalesEmployee
        {
            get { return _salesEmployee; }
            set { _salesEmployee = value; }
        }
        /// <summary>
        /// 発行者印字
        /// </summary>
        /// <remarks>0:印字しない,1:印字する</remarks>
        public int SalesInput
        {
            get { return _salesInput; }
            set { _salesInput = value; }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="goodsNo">品番印字</param>
        /// <param name="bLGoodsCode">ＢＬコード印字</param>
        /// <param name="listPrice">標準価格印字</param>
        /// <param name="cost">原価印字</param>
        /// <param name="salesEmployee">担当者印字</param>
        /// <param name="salesInput">発行者印字</param>
        public EachSlipTypeSet( int goodsNo, int bLGoodsCode, int listPrice, int cost, int salesEmployee, int salesInput )
        {
            _goodsNo = goodsNo;
            _bLGoodsCode = bLGoodsCode;
            _listPrice1 = listPrice;
            _cost = cost;
            _salesEmployee = salesEmployee;
            _salesInput = salesInput;
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="slipPrtSet">伝票印刷設定</param>
        public EachSlipTypeSet( SlipPrtSetWork slipPrtSet )
        {
            _goodsNo = slipPrtSet.EachSlipTypeColPrt1;
            _bLGoodsCode = slipPrtSet.EachSlipTypeColPrt2;
            _listPrice1 = slipPrtSet.EachSlipTypeColPrt3;
            _cost = slipPrtSet.EachSlipTypeColPrt4;
            _salesEmployee = slipPrtSet.EachSlipTypeColPrt5;
            _salesInput = slipPrtSet.EachSlipTypeColPrt6;
        }
    }
    # endregion


    # region ■　伝票印刷パラメータ構造体　■
    /// <summary>
    /// 伝票印刷パラメータ構造体
    /// </summary>
    /// <remarks>
    /// <br>※データクラスのメンバとして存在しないデータを</br>
    /// <br>　印刷ＤＬＬに受け渡す為の構造体です。</br>
    /// <br>※objectのディクショナリとの相互変換機能を持ちます。</br>
    /// </remarks>
    internal struct SlipPrintParameter
    {
        /// <summary>日付印字有無(0:しない/1:する)</summary>
        private int _slipDatePrintDiv;
        /// <summary>合計金額印字(0:全頁/1:先頭のみ/2:最終のみ)</summary>
        private int _totalPricePrtCd;
        /// <summary>再発行区分</summary>
        private bool _reissueDiv;
        /// <summary>
        /// 日付印字有無(0:しない/1:する)
        /// </summary>
        public int SlipDatePrintDiv
        {
            get { return _slipDatePrintDiv; }
            set { _slipDatePrintDiv = value; }
        }
        /// <summary>
        /// 合計金額印字(0:全頁/1:先頭のみ/2:最終のみ)
        /// </summary>
        public int TotalPricePrtCd
        {
            get { return _totalPricePrtCd; }
            set { _totalPricePrtCd = value; }
        }
        /// <summary>
        /// 再発行区分
        /// </summary>
        public bool ReissueDiv
        {
            get { return _reissueDiv; }
            set { _reissueDiv = value; }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="slipDatePrintDiv">日付印字有無(0:しない/1:する)</param>
        /// <param name="totalPricePrtCd">合計金額印字(0:全頁/1:先頭のみ/2:最終のみ)</param>
        /// <param name="reissueDiv">再発行区分</param>
        public SlipPrintParameter( int slipDatePrintDiv, int totalPricePrtCd, bool reissueDiv )
        {
            _slipDatePrintDiv = slipDatePrintDiv;
            _totalPricePrtCd = totalPricePrtCd;
            _reissueDiv = reissueDiv;
        }
        /// <summary>
        /// コンストラクタ (objectのディクショナリより)
        /// </summary>
        /// <param name="objectDictionary"></param>
        public SlipPrintParameter( Dictionary<string, object> objectDictionary )
        {
            // 初期値を設定
            _slipDatePrintDiv = 1;
            _totalPricePrtCd = 0;
            _reissueDiv = false;

            // 渡されたListの内容を格納
            if ( objectDictionary != null )
            {
                if ( objectDictionary.ContainsKey( "SlipDatePrintDiv" ) && objectDictionary["SlipDatePrintDiv"] is int )
                {
                    _slipDatePrintDiv = (int)objectDictionary["SlipDatePrintDiv"];
                }
                if ( objectDictionary.ContainsKey( "TotalPricePrtCd" ) && objectDictionary["TotalPricePrtCd"] is int )
                {
                    _totalPricePrtCd = (int)objectDictionary["TotalPricePrtCd"];
                }
                if ( objectDictionary.ContainsKey( "ReissueDiv" ) && objectDictionary["ReissueDiv"] is bool )
                {
                    _reissueDiv = (bool)objectDictionary["ReissueDiv"];
                }
            }
        }
        /// <summary>
        /// ディクショナリへ変換
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> ToDictionary()
        {
            // メンバをディクショナリに格納
            Dictionary<string, object> objectDic = new Dictionary<string, object>();
            objectDic.Add( "SlipDatePrintDiv", _slipDatePrintDiv );
            objectDic.Add( "TotalPricePrtCd", _totalPricePrtCd );
            objectDic.Add( "ReissueDiv", _reissueDiv );

            // Dictionaryを返す
            return objectDic;
        }
    }
    # endregion ■　伝票印刷パラメータ構造体　■
}
