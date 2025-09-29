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
using Broadleaf.Application.UIData;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 自由帳票(見積書)印刷クラス
	/// </summary>
	/// <remarks>
	/// <br>Note         : 自由帳票の印刷ドキュメントを作成します。</br>
	/// <br>Programmer   : 22018 鈴木　正臣</br>
	/// <br>Date         : 2008.06.03</br>
	/// <br></br>
    /// <br>Update Note  : 2010.03.10 22018 鈴木  正臣</br>
    /// <br>             : 印刷部数の不具合を修正</br>
    /// <br></br>
    /// </remarks>
	public class PMMIT08001PA : ISlipPrintProc
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
        // 見積初期値設定マスタ
        private EstimateDefSet _estimateDefSet;
        // 全体初期表示設定マスタ
        private AllDefSetWork _allDefSet;

        // 印刷元データクラス退避用
        private List<EstFmUnitExtraData> _estFmUnitExtraDataList;
       

        // --------------------------------------------------------
        // ☆☆☆ 印刷設定データ系 ☆☆☆
        // --------------------------------------------------------
        // 伝票印刷設定マスタ
        private SlipPrtSetWork _slipPrtSet;
        // 伝票印刷設定伝票タイプ別設定
        private EachSlipTypeSet _eachSlipTypeSet;
        // 伝票印刷パラメータ
        private SlipPrintParameter _slipPrintParameter;
        // 伝票印刷条件クラス
        private SlipPrintConditionInfo _slipPrintConditionInfo;

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
		public PMMIT08001PA()
		{
            _previewDocument = new Document();
            _printDocument = new Document();

            _reportCtrl = PMCMN02000CA.GetInstance();
            _reportCtrl.DoubleHeightTargetList = PMMIT08001PB.GetDoubleHeightTargetList();
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
                    // 設定系データ取得
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
                            // 見積初期値設定マスタ
                            else if ( wkObj is EstimateDefSet )
                            {
                                _estimateDefSet = (EstimateDefSet)wkObj;
                            }
                            // 全体初期表示設定マスタ
                            else if ( wkObj is AllDefSetWork )
                            {
                                _allDefSet = (AllDefSetWork)wkObj;
                            }
                            // 伝票印刷パラメータ
                            else if ( wkObj is Dictionary<string, object> )
                            {
                                _slipPrintParameter = new SlipPrintParameter( (Dictionary<string, object>)wkObj );
                            }
                        }
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 ADD
                    if ( CheckExistsMasters() == false )
                    {
                        return -1;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 ADD
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                    // 印刷レイアウト情報取得
                    Dictionary<string, string> columnVisibleTypeDic;
                    GetLayoutInfo( _frePrtPSet, out columnVisibleTypeDic );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD

                    // 印刷データ展開
                    _ds = new DataSet();
                    _estFmUnitExtraDataList = new List<EstFmUnitExtraData>();
                    List<ArrayList> slipPrintDataList = (List<ArrayList>)slipPrintData;

                    for ( int index = 0; index < slipPrintDataList.Count; index++ )
                    {
                        ArrayList wkObj = slipPrintDataList[index];

                        FrePEstFmHead slipWork = (FrePEstFmHead)(wkObj as ArrayList)[0];
                        List<FrePEstFmDetail> detailWorks = (List<FrePEstFmDetail>)(wkObj as ArrayList)[1];
                        _estFmUnitExtraDataList.Add( (EstFmUnitExtraData)(wkObj as ArrayList)[2] );

                        // データ展開
                        DataTable table = PMMIT08001PB.CreateFrePEstFmHeadTable( index );
                        PMMIT08001PB.CopyToDataTable( ref table, slipWork, detailWorks, _slipPrtSet, _eachSlipTypeSet, _frePrtPSet, _slipPrintParameter, _estimateDefSet, _allDefSet, columnVisibleTypeDic );

                        _ds.Tables.Add( table );
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
					, "自由帳票見積書印刷"
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
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
        /// <summary>
        /// 印刷レイアウト情報取得
        /// </summary>
        /// <param name="frePrtPSet"></param>
        /// <param name="columnVisibleTypeDic"></param>
        private void GetLayoutInfo( FrePrtPSetWork frePrtPSet, out Dictionary<string, string> columnVisibleTypeDic )
        {
            // 初期化
            columnVisibleTypeDic = new Dictionary<string, string>();

            if ( _frePrtPSet == null || _frePrtPSet.PrintPosClassData == null ) return;

            using ( MemoryStream stream = new MemoryStream( _frePrtPSet.PrintPosClassData ) )
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
                        }
                    }
                }
            }
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
            // 見積初期値設定マスタ
            else if ( _estimateDefSet == null )
            {
                errorList.Add( "見積初期値設定" );
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
                    , "見積書印刷"
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
            Document wkPrintDocument = new Document();
            _printDocument = new Document();
            _previewDocument = new Document();

            using ( MemoryStream stream = new MemoryStream( _frePrtPSet.PrintPosClassData ) )
			{
                //ar.ActiveReport3 prvRpt = null;
				ar.ActiveReport3 prtRpt = null;

                for ( int tableIndex = 0; tableIndex != _ds.Tables.Count; tableIndex++ )
                {
                    // ---------------------------------
                    // 設定値の取得
                    // ---------------------------------
                    EstFmUnitExtraData extraData = _estFmUnitExtraDataList[tableIndex];

                    # region [印刷部数]
                    int printCount;
                    // 伝票印刷設定の部数
                    if ( _slipPrtSet.PrtCirculation > 0 )
                    {
                        printCount = _slipPrtSet.PrtCirculation;
                    }
                    else
                    {
                        printCount = 1;
                    }
                    // 検索見積の部数
                    if ( extraData.PrintCount > 0 )
                    {
                        printCount *= extraData.PrintCount;
                    }
                    # endregion

                    // ---------------------------------
                    // 印刷用Documentの生成
                    // ---------------------------------

                    // --- ADD m.suzuki 2010/03/10 ---------->>>>>
                    // "全て","純正のみ","優良のみ","選択分のみ"の各タイプ毎に初期化する
                    wkPrintDocument = new Document();
                    // --- ADD m.suzuki 2010/03/10 ----------<<<<<

                    // 印刷部数分繰り返す
                    for ( int circulateCount = 0; circulateCount < printCount; circulateCount++ )
                    {
                        if ( circulateCount == 0 )
                        {
                            // 複写枚数分繰り返す
                            for ( int copyCount = 0; copyCount < _slipPrtSet.CopyCount; copyCount++ )
                            {
                                prtRpt = new ar.ActiveReport3();
                                stream.Position = 0;
                                prtRpt.LoadLayout( stream );
                                SFANL08235CE.AddScriptReference( ref prtRpt );	// Script用参照追加
                                SetMargin( prtRpt );
                                SFANL08235CE.SetValidPaperKind( prtRpt );
                                _reportCtrl.SetReportProps( ref prtRpt ); // 帳票共通設定
                                prtRpt.DataSource = _ds;
                                prtRpt.DataMember = _ds.Tables[tableIndex].TableName;
                                //prtRpt.DataSource = _ds.Tables[tableIndex];

                                # region [改ページ制御]
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
                                topHeader.DataField = PMMIT08001PB.ct_PageCount;
                                topHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
                                # endregion

                                // 複写に伴うフィールド設定
                                SettingFieldInfoByCopying( ref prtRpt, copyCount, _ds.Tables[tableIndex] );

                                # region [デザイン適用]
                                // 明細部デザイン適用
                                ReflectDetailDesign( ref prtRpt, _ds.Tables[tableIndex] );
                                // 合計部デザイン適用
                                ReflectSumDesign( ref prtRpt, _ds.Tables[tableIndex] );
                                # endregion

                                // 印刷実行
                                prtRpt.Run();

                                // 印刷用Documentにまとめる
                                wkPrintDocument.Pages.AddRange( prtRpt.Document.Pages );

                                // プレビューは印刷部数によらず常に１部の分だけ表示する
                                if ( copyCount == 0 && circulateCount == 0 )
                                {
                                    _previewDocument.Pages.AddRange( prtRpt.Document.Pages );
                                }
                            }
                        }
                        _printDocument.Pages.AddRange( wkPrintDocument.Pages );
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
        /// <param name="dataTable"></param>
        /// <remarks>伝票複写により変化する、伝票背景色、伝票タイトルに関する制御を行います。印字項目CD=51～100に対する処理。</remarks>
        /// 
        private void SettingFieldInfoByCopying( ref DataDynamics.ActiveReports.ActiveReport3 prtRpt, int copyCount, DataTable dataTable )
        {
            //--------------------------------------------------------
            // テーブル情報の取得
            //--------------------------------------------------------
            if ( dataTable.Rows.Count == 0 )
            {
                return;
            }

            // 見積書区分取得
            EstFmDivState estFmDivState = PMMIT08001PB.GetRowInfoEstFmDiv( dataTable.Rows[0] );
            // 伝票番号取得
            string salesSlipNum = PMMIT08001PB.GetRowInfoSalesSlipNum( dataTable.Rows[0] );

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
                    if ( arControl.Tag is string )
                    {
                        string tagSub = (arControl.Tag as string).Substring( 0, 3 );

                        # region [特殊項目(51～100)]
                        switch ( tagSub )
                        {
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
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMMIT08001PB.ct_InPageCopyTitle1;
                                            break;
                                        case 1:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMMIT08001PB.ct_InPageCopyTitle2;
                                            break;
                                        case 2:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMMIT08001PB.ct_InPageCopyTitle3;
                                            break;
                                        case 3:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = PMMIT08001PB.ct_InPageCopyTitle4;
                                            break;
                                        default:
                                            (arControl as DataDynamics.ActiveReports.Label).DataField = string.Empty;
                                            break;
                                    }
                                }
                                break;
                            case "56,":
                            case "58,":
                                {
                                    //-------------------------------------------
                                    // 56:品番タイトル、58:品番用直線
                                    //-------------------------------------------
                                    // 0:品番印字しない
                                    if ( _estimateDefSet.PartsNoPrtCd == 0 )
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "57,":
                            case "59,":
                                {
                                    //-------------------------------------------
                                    // 57:標準価格タイトル、58:標準価格用直線
                                    //-------------------------------------------
                                    // 0:標準価格印字しない
                                    if ( _estimateDefSet.ListPricePrintDiv == 0 )
                                    {
                                        arControl.Visible = false;
                                    }
                                }
                                break;
                            case "65,":
                                {
                                    //-------------------------------------------
                                    // 「65:純正優良説明文」の場合
                                    //-------------------------------------------
                                    if ( estFmDivState != EstFmDivState.All )
                                    {
                                        (arControl as DataDynamics.ActiveReports.Label).Visible = false;
                                    }
                                }
                                break;
                            case "66,":
                                {
                                    //-------------------------------------------
                                    // 「66:純正説明文」の場合
                                    //-------------------------------------------
                                    if ( estFmDivState != EstFmDivState.Pure )
                                    {
                                        (arControl as DataDynamics.ActiveReports.Label).Visible = false;
                                    }
                                }
                                break;
                            case "67,":
                                {
                                    //-------------------------------------------
                                    // 「67:優良説明文」の場合
                                    //-------------------------------------------
                                    if ( estFmDivState != EstFmDivState.Prime )
                                    {
                                        (arControl as DataDynamics.ActiveReports.Label).Visible = false;
                                    }
                                }
                                break;
                            case "74,":
                                {
                                    //-------------------------------------------
                                    // 「74:自社情報固定文字」の場合
                                    //-------------------------------------------
                                    if ( _slipPrtSet.EnterpriseNamePrtCd == 2 || _slipPrtSet.EnterpriseNamePrtCd == 3 )
                                    {
                                        // 2:ビットマップ、または3:印字しない、ならば自社情報固定文字を印字しない
                                        (arControl as DataDynamics.ActiveReports.Label).Visible = false;
                                    }
                                }
                                break;
                            case "75,":
                                {
                                    //-------------------------------------------
                                    // 「75:伝票番号タイトル」の場合
                                    //-------------------------------------------
                                    if ( string.IsNullOrEmpty( salesSlipNum ) )
                                    {
                                        // 伝票番号未設定ならば伝票番号タイトルを印字しない
                                        (arControl as DataDynamics.ActiveReports.Label).Visible = false;
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

        # region [明細デザイン適用]
        /// <summary>
        /// 明細デザイン適用
        /// </summary>
        /// <param name="prtRpt"></param>
        /// <param name="dataTable"></param>
        private void ReflectDetailDesign( ref DataDynamics.ActiveReports.ActiveReport3 prtRpt, DataTable dataTable )
        {
            try
            {
                //--------------------------------------------------------
                // テーブル情報の取得
                //--------------------------------------------------------
                if ( dataTable.Rows.Count == 0 )
                {
                    return;
                }
                
                // 見積書区分取得
                EstFmDivState estFmDivState = PMMIT08001PB.GetRowInfoEstFmDiv( dataTable.Rows[0] );

                // オプション印字区分
                int optionPrintDivCd = _estimateDefSet.OptionPringDivCd;

//# if DEBUG
//                estFmDivState = EstFmDivState.All;
//                optionPrintDivCd = 1;
//                // →ここも　GetFeedCount
//# endif

               
                //--------------------------------------------------------
                // 印刷レイアウトに対する制御
                //--------------------------------------------------------

                // 明細セクション取得
                ar.Section detail = prtRpt.Sections["Detail1"];

                // 明細デザイン用ラベル
                ar.Label designDetail1 = null;
                ar.Label designDetail2 = null;
                ar.Label designDetail3 = null;

                // 明細セクションのコントロールを調査
                foreach ( ar.ARControl control in detail.Controls )
                {
                    string tagText = (string)control.Tag;
                    tagText = tagText.Substring( 0, 3 );

                    switch ( tagText )
                    {
                        case "68,":
                            designDetail1 = (ar.Label)control;
                            break;
                        case "69,":
                            designDetail2 = (ar.Label)control;
                            break;
                        case "70,":
                            designDetail3 = (ar.Label)control;
                            break;
                        default:
                            break;
                    }
                }

                // 対象データフィールドリスト取得
                List<string> detail1List = PMMIT08001PB.GetDesignDetail1List();
                List<string> detail2List = PMMIT08001PB.GetDesignDetail2List();
                List<string> detail3List = PMMIT08001PB.GetDesignDetail3List();

                if ( designDetail2 == null )
                {
                    // 明細２ガイドが無い場合は明細１リストに移して明細２リストをクリア
                    detail1List.AddRange( detail2List );
                    detail2List.Clear();
                }
                if ( designDetail3 == null )
                {
                    // 明細３ガイドが無い場合は明細１リストに移して明細３リストをクリア
                    detail1List.AddRange( detail3List );
                    detail3List.Clear();
                }

                if ( optionPrintDivCd > 0 )
                {
                    // オプション印刷＝１：する
                    if ( estFmDivState == EstFmDivState.All )
                    {
                        //--------------------------------------------------------
                        // 純正＋優良＋オプション
                        // →制御は不要
                        //--------------------------------------------------------
                    }
                    else
                    {
                        //--------------------------------------------------------
                        // 純正or優良＋オプション
                        // →優良を消す、オプションを上に移動、明細詰める
                        //--------------------------------------------------------
                        # region [純正or優良＋オプション]
                        foreach ( ar.ARControl control in detail.Controls )
                        {
                            if ( control is ar.TextBox )
                            {
                                string dataField = control.DataField.ToUpper();

                                if ( detail2List.Contains( dataField ) )
                                {
                                    control.Visible = false;
                                    control.Top = designDetail1.Top;
                                }
                                else if ( detail3List.Contains( dataField ) )
                                {
                                    control.Top = designDetail2.Top;
                                }
                            }
                        }

                        float shaveHeight = 0;
                        
                        if ( designDetail1 != null )
                        {
                            designDetail1.Top = 0;
                        }
                        if ( designDetail2 != null )
                        {
                            designDetail2.Top = 0;
                            shaveHeight += designDetail2.Height;
                        }
                        if ( designDetail3 != null )
                        {
                            designDetail3.Top = 0;
                        }

                        // 明細縮小制御
                        CollapseDetail( prtRpt, shaveHeight );
                        # endregion
                    }
                }
                else
                {
                    // オプション印刷＝０：しない
                    if ( estFmDivState == EstFmDivState.All )
                    {
                        //--------------------------------------------------------
                        // 純正＋優良
                        // →オプションを消す、明細詰める
                        //--------------------------------------------------------
                        # region [純正＋優良]
                        foreach ( ar.ARControl control in detail.Controls )
                        {
                            if ( control is ar.TextBox )
                            {
                                string dataField = control.DataField.ToUpper();

                                if ( detail3List.Contains( dataField ) )
                                {
                                    control.Visible = false;
                                    control.Top = designDetail1.Top;
                                }
                            }
                        }

                        float shaveHeight = 0;

                        if ( designDetail1 != null )
                        {
                            designDetail1.Top = 0;
                        }
                        if ( designDetail2 != null )
                        {
                            designDetail2.Top = 0;
                        }
                        if ( designDetail3 != null )
                        {
                            designDetail3.Top = 0;
                            shaveHeight += designDetail3.Height;
                        }

                        // 明細縮小制御
                        CollapseDetail( prtRpt, shaveHeight );

                        # endregion
                    }
                    else
                    {
                        //--------------------------------------------------------
                        // 純正or優良
                        // →オプションを消す、優良を消す、明細詰める
                        //--------------------------------------------------------
                        # region [純正or優良]
                        foreach ( ar.ARControl control in detail.Controls )
                        {
                            if ( control is ar.TextBox )
                            {
                                string dataField = control.DataField.ToUpper();

                                if ( detail3List.Contains( dataField ) )
                                {
                                    control.Visible = false;
                                    control.Top = designDetail1.Top;
                                }
                                else if ( detail2List.Contains( dataField ) )
                                {
                                    control.Visible = false;
                                    control.Top = designDetail1.Top;
                                }
                            }
                        }

                        float shaveHeight = 0;

                        if ( designDetail1 != null )
                        {
                            designDetail1.Top = 0;
                        }
                        if ( designDetail2 != null )
                        {
                            designDetail2.Top = 0;
                            shaveHeight += designDetail2.Height;
                        }
                        if ( designDetail3 != null )
                        {
                            designDetail3.Top = 0;
                            shaveHeight += designDetail3.Height;
                        }

                        // 明細縮小制御
                        CollapseDetail( prtRpt, shaveHeight );

                        # endregion
                    }
                }

            }
            catch
            {
            }
        }

        /// <summary>
        /// 明細の圧縮処理
        /// </summary>
        /// <param name="prtRpt"></param>
        /// <param name="shaveHeight"></param>
        private void CollapseDetail( DataDynamics.ActiveReports.ActiveReport3 prtRpt, float shaveHeight )
        {
            ar.Section detail = prtRpt.Sections["Detail1"];

            // 明細セクションのコントロールを調査
            foreach ( ar.ARControl control in detail.Controls )
            {
                if ( control is ar.Line || control is ar.Shape )
                {
                    if ( control.Top + control.Height > detail.Height - shaveHeight )
                    {
                        control.Height = (detail.Height - shaveHeight) - control.Top;
                    }
                }
            }
        }
        /// <summary>
        /// 合計デザイン適用
        /// </summary>
        /// <param name="prtRpt"></param>
        private void ReflectSumDesign( ref DataDynamics.ActiveReports.ActiveReport3 prtRpt, DataTable dataTable )
        {
            try
            {
                //--------------------------------------------------------
                // テーブル情報の取得
                //--------------------------------------------------------
                if ( dataTable.Rows.Count == 0 )
                {
                    return;
                }

                // 見積書区分取得
                EstFmDivState estFmDivState = PMMIT08001PB.GetRowInfoEstFmDiv( dataTable.Rows[0] );
                // 課税区分
                int consTaxLayMethod = PMMIT08001PB.GetRowInfoConsTaxLayMethod( dataTable.Rows[0] );

                //--------------------------------------------------------
                // 印刷レイアウトに対する制御
                //--------------------------------------------------------

                // 合計セクション取得
                ar.Section fotter = prtRpt.Sections["GroupFooter1"];

                // 合計デザイン用ラベル
                ar.Label designSubtotal = null;
                ar.Label designTax = null;
                ar.Label designTotal = null;
                // 合計用枠線
                ar.Shape designTotalShape = null;
                // 合計タイトル
                ar.Label designSubtotalLabel = null;
                ar.Label designTaxLabel = null;
                ar.Label designTotalLabel = null;

                // 合計セクションのコントロールを調査
                foreach ( ar.ARControl control in fotter.Controls )
                {
                    string tagText = (string)control.Tag;
                    tagText = tagText.Substring( 0, 3 );

                    switch ( tagText )
                    {
                        case "61,":
                            designTotalShape = (ar.Shape)control;
                            break;
                        case "62,":
                            designSubtotal = (ar.Label)control;
                            break;
                        case "63,":
                            designTax = (ar.Label)control;
                            break;
                        case "64,":
                            designTotal = (ar.Label)control;
                            break;
                        case "71,":
                            designSubtotalLabel = (ar.Label)control;
                            break;
                        case "72,":
                            designTaxLabel = (ar.Label)control;
                            break;
                        case "73,":
                            designTotalLabel = (ar.Label)control;
                            break;
                        default:
                            break;
                    }
                }

                // 対象データフィールドリスト取得
                List<string> subTotalList = PMMIT08001PB.GetDesignSubTotalList();
                List<string> taxList = PMMIT08001PB.GetDesignTaxList();
                List<string> totalList = PMMIT08001PB.GetDesignTotalList();
                List<string> primeList = PMMIT08001PB.GetDesignTotalPrimeList();

                if ( estFmDivState == EstFmDivState.All )
                {
                    //--------------------------------------------------------
                    // 純正＋優良
                    // →制御不要
                    //--------------------------------------------------------
                }
                else
                {
                    //--------------------------------------------------------
                    // 純正or優良
                    // →優良を消す、合計枠詰める
                    //--------------------------------------------------------
                    # region [純正or優良]
                    foreach ( ar.ARControl control in fotter.Controls )
                    {
                        if ( control is ar.TextBox )
                        {
                            string dataField = control.DataField.ToUpper();

                            // 優良を消す
                            if ( primeList.Contains( dataField ) )
                            {
                                control.Visible = false;
                            }

                            // 小計を移動
                            if ( designSubtotal != null && subTotalList.Contains( dataField ) )
                            {
                                control.Top = designSubtotal.Top;
                            }
                            // 税を移動
                            else if ( designTax != null && taxList.Contains( dataField ) )
                            {
                                control.Top = designTax.Top;
                            }
                            // 合計を移動
                            else if ( designTotal != null && totalList.Contains( dataField ) )
                            {
                                control.Top = designTotal.Top;
                            }
                        }
                    }
                    // 合計部枠線の高さを半分にする
                    if ( designTotalShape != null )
                    {
                        designTotalShape.Height = designTotalShape.Height / 2;
                    }
                    // 小計タイトルの位置を変更
                    if ( designSubtotalLabel != null && designSubtotalLabel != null )
                    {
                        designSubtotalLabel.Top -= designSubtotal.Top;
                    }
                    // 税タイトルの位置を変更
                    if ( designTaxLabel != null && designTax != null )
                    {
                        designTaxLabel.Top -= designTax.Top;
                    }
                    // 合計タイトルの位置を変更
                    if ( designTotalLabel != null && designTotal != null )
                    {
                        designTotalLabel.Top -= designTotal.Top;
                    }
                    # endregion
                }

                // 消費税タイトル・合計タイトル非印字
                # region [消費税タイトル・合計タイトル非印字]
                bool totalPrintEnable = true;
                bool taxPrintEnable = true;
                // 消費税区分 0:する　1:しない
                if ( _estimateDefSet.ConsTaxPrintDiv == 0 )
                {
                    // 転嫁方式　0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税
                    switch ( consTaxLayMethod )
                    {
                        case 0:
                        case 1:
                            {
                            }
                            break;
                        case 2:
                        case 3:
                            {
                                totalPrintEnable = false;
                            }
                            break;
                        case 9:
                        default:
                            {
                                totalPrintEnable = false;
                                taxPrintEnable = false;
                            }
                            break;
                    }
                }
                else
                {
                    totalPrintEnable = false;
                    taxPrintEnable = false;
                }
                // 消費税タイトル
                if ( taxPrintEnable == false )
                {
                    if ( designTaxLabel != null ) designTaxLabel.Visible = false;
                }
                // 合計タイトル
                if ( totalPrintEnable == false )
                {
                    if ( designTotalLabel != null ) designTotalLabel.Visible = false;
                }
                # endregion
            }
            catch
            {
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/04 DEL
            //foreach (string wkStr in PrinterSettings.InstalledPrinters)
            //{
            //    if (wkStr.Equals(_slipPrintConditionInfo.PrinterName))
            //    {
            //        document.Printer.PrinterSettings.PrinterName = _slipPrintConditionInfo.PrinterName;
            //        break;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/04 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/04 ADD
            document.Printer.PrinterSettings.PrinterName = _slipPrintConditionInfo.PrinterName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/04 ADD

			// 使用プリンタの有効有無チェック（有効では無い場合は仮想プリンタを使用）
			if (!document.Printer.PrinterSettings.IsValid)
				document.Printer.PrinterSettings.PrinterName = string.Empty;
		}
		#endregion
	}

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

    # region [伝票タイプ別設定]
    /// <summary>
    /// 伝票タイプ別設定
    /// </summary>
    /// <remarks>伝票印刷設定の「伝票タイプ別設定」を定義・取得します。2009.01.19未使用</remarks>
    internal struct EachSlipTypeSet
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="slipPrtSetWork"></param>
        public EachSlipTypeSet( SlipPrtSetWork slipPrtSetWork )
        {
        }
    }
    # endregion

}
