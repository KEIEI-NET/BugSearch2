using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections.Generic;

using Infragistics.Win;
using Infragistics.Win.UltraWinToolTip;

using ar=DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 自由帳票全体情報設定画面
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票印字位置データの全体に関わる情報を設定する画面です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.06.06</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08105UC : UserControl
	{
		#region Enum
		/// <summary>設定変更タイプ</summary>
		public enum ChangedType
		{
			/// <summary>印字位置</summary>
			PrintPos,
			/// <summary>タイトル・コメント</summary>
			Comment,
			/// <summary>透かし画像</summary>
			Watermark,
		}
		#endregion

		#region PrivateMember
		private bool _isNowWorking;
		// 透かし画像用
		private Image _watermark;
		// 変更チェック用テキスト
		private string _bufText = string.Empty;
		// 変更チェック用コード
		private double _bufCode;
		// 全体設定変更イベントハンドラ
		internal event EventHandler WholeSettingChanged;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
        // センチ・インチ制御
        private CmInchControl _cmInchControl;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08105UC()
		{
			InitializeComponent();

			this.ubReference.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.NEW];
			this.ubClear.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.DELETE];

			this.cmbPaperName.Items.Clear();
			this.cmbPaperName.Items.Add(PaperKind.A3, "Ａ３");
			this.cmbPaperName.Items.Add(PaperKind.A4, "Ａ４");
			this.cmbPaperName.Items.Add(PaperKind.A5, "Ａ５");
			this.cmbPaperName.Items.Add(PaperKind.B4, "Ｂ４");
			this.cmbPaperName.Items.Add(PaperKind.B5, "Ｂ５");
			this.cmbPaperName.Items.Add(PaperKind.JapanesePostcard, "はがき");
			//this.cmbPaperName.Items.Add(PaperKind.Custom, "カスタム");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
            this.cmbPaperName.Items.Add( PaperKind.Custom, "カスタム" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD

			this.uosOrientation.Items.Clear();
			this.uosOrientation.Items.Add(PageOrientation.Landscape,	"横");
			this.uosOrientation.Items.Add(PageOrientation.Portrait,		"縦");
			this.uosOrientation.CheckedIndex = 0;

			this.cmbEdgeCharProcDivCd.Items.Clear();
			this.cmbEdgeCharProcDivCd.Items.Add(0,	"　");
			this.cmbEdgeCharProcDivCd.Items.Add(1,	"端文字切捨て");
			this.cmbEdgeCharProcDivCd.Items.Add(2,	"フォント縮小");
		}
		#endregion

		#region Property
		/// <summary>処理中フラグ</summary>
		public bool IsNowWorking
		{
			get { return _isNowWorking; }
		}

		/// <summary>透かし画像</summary>
		public Image Watermark
		{
			get { return _watermark; }
			set { _watermark = value; }
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/16 ADD
        /// <summary>透かし画像　開始位置左</summary>
        public double WatermarkPosLeft
        {
            get { return this.ndtWatermarkLeft.GetValue(); }
        }
        /// <summary>透かし画像　開始位置上</summary>
        public double WatermarkPosTop
        {
            get { return this.ndtWatermarkTop.GetValue(); }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/16 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
        /// <summary>センチ・インチ制御</summary>
        public CmInchControl CmInchControl
        {
            get { return _cmInchControl; }
            set { _cmInchControl = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
		#endregion

		#region PublicMethod
		/// <summary>
		/// 全体設定表示処理
		/// </summary>
		/// <param name="frePrtPSet">自由帳票印字位置設定マスタ</param>
		/// <param name="rpt">ActiveReportオブジェクト</param>
		/// <param name="isContractFreeSheetgMng">自由帳票管理オプションフラグ</param>
		/// <remarks>
		/// <br>Note		: 引数を元に全体設定を表示します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public void ShowWholeSetting(FrePrtPSet frePrtPSet, ar.ActiveReport3 rpt, bool isContractFreeSheetgMng)
		{
			if (frePrtPSet != null)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                // 帳票ＩＤ
                this.tedPrtFormId.Text = frePrtPSet.OutputFormFileName;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
				// 表示名称
				this.tedDisplayName.Text			= frePrtPSet.DisplayName;
				// 出力確認メッセージ
				this.tedOutConfimationMsg.Text		= frePrtPSet.OutConfimationMsg;
				// コメント（ユーザー）
				this.tedPrtPprUserDerivNoCmt.Text	= frePrtPSet.PrtPprUserDerivNoCmt;
				// 改頁行数
				this.ndtFormFeedLineCount.SetInt(frePrtPSet.FormFeedLineCount);
				// 改行文字数
				this.ndtCrCharCnt.SetInt(frePrtPSet.CrCharCnt);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                //// 帳票背景画像縦位置
                //this.ndtWatermarkTop.SetValue(frePrtPSet.PrtPprBgImageRowPos);
                //// 帳票背景画像横位置
                //this.ndtWatermarkLeft.SetValue(frePrtPSet.PrtPprBgImageColPos);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                // 帳票背景画像縦位置
                this.ndtWatermarkTop.SetValue( _cmInchControl.ToDisp( ar.ActiveReport3.CmToInch( (float)frePrtPSet.PrtPprBgImageRowPos ) ) );
                // 帳票背景画像横位置
                this.ndtWatermarkLeft.SetValue( _cmInchControl.ToDisp( ar.ActiveReport3.CmToInch( (float)frePrtPSet.PrtPprBgImageColPos ) ) );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
				// 透かし画像
				this.pnlWatermark.BackgroundImage	= _watermark;
				// 端文字処理区分
				this.cmbEdgeCharProcDivCd.Value		= frePrtPSet.EdgeCharProcDivCd;
				// 明細背景色
				this.ucpDetailBackColor.Color		= frePrtPSet.GetDetailBackColor();

				// 画面の入力制御
				if (frePrtPSet.UpdateDateTime != DateTime.MinValue)
					ChangeControlEnabled(frePrtPSet.PrintPaperUseDivcd, isContractFreeSheetgMng, true);
				else
					ChangeControlEnabled(frePrtPSet.PrintPaperUseDivcd, isContractFreeSheetgMng, false);
			}

			if (rpt != null)
			{
				// 用紙種別
				this.cmbPaperName.Value = rpt.PageSettings.PaperKind;
				// サポートしていない用紙種別の場合はCustomにする
				if (this.cmbPaperName.Value == null) this.cmbPaperName.Value = PaperKind.A4;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                //// 余白設定
                //this.ndtMarginTop.SetValue(FrePrtSettingController.ToHalfAdjust(ar.ActiveReport3.InchToCm(rpt.PageSettings.Margins.Top), 2));
                //this.ndtMarginBottom.SetValue(FrePrtSettingController.ToHalfAdjust(ar.ActiveReport3.InchToCm(rpt.PageSettings.Margins.Bottom), 2));
                //this.ndtMarginRight.SetValue(FrePrtSettingController.ToHalfAdjust(ar.ActiveReport3.InchToCm(rpt.PageSettings.Margins.Right), 2));
                //this.ndtMarginLeft.SetValue(FrePrtSettingController.ToHalfAdjust(ar.ActiveReport3.InchToCm(rpt.PageSettings.Margins.Left), 2));
                //// 用紙幅
                //this.ndtPrintWidth.SetValue(FrePrtSettingController.ToHalfAdjust(ar.ActiveReport3.InchToCm(rpt.PrintWidth), 2));
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
                //// 用紙高さ
                //this.ndtPrintHeight.SetValue( FrePrtSettingController.ToHalfAdjust( ar.ActiveReport3.InchToCm( rpt.PageSettings.PaperHeight ), 2 ) );
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                // 余白設定
                this.ndtMarginTop.SetValue( FrePrtSettingController.ToHalfAdjust( _cmInchControl.ToDisp( rpt.PageSettings.Margins.Top ), 2 ) );
                this.ndtMarginBottom.SetValue( FrePrtSettingController.ToHalfAdjust( _cmInchControl.ToDisp(  rpt.PageSettings.Margins.Bottom ), 2 ) );
                this.ndtMarginRight.SetValue( FrePrtSettingController.ToHalfAdjust( _cmInchControl.ToDisp(  rpt.PageSettings.Margins.Right ), 2 ) );
                this.ndtMarginLeft.SetValue( FrePrtSettingController.ToHalfAdjust( _cmInchControl.ToDisp(  rpt.PageSettings.Margins.Left ), 2 ) );
                // 用紙幅
                this.ndtPrintWidth.SetValue( FrePrtSettingController.ToHalfAdjust( _cmInchControl.ToDisp(  rpt.PrintWidth ), 2 ) );
                // 用紙高さ
                this.ndtPrintHeight.SetValue( FrePrtSettingController.ToHalfAdjust( _cmInchControl.ToDisp(  rpt.PageSettings.PaperHeight ), 2 ) );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
				// 印字方向
				this.uosOrientation.Value = (PageOrientation)rpt.PageSettings.Orientation;

				// UltraOptionSetにはReadOnlyが無い為、Enabled=falseの時に
				// 選択されてる項目のキャプションを黒に設定することで擬似的にReadOnly状態とする
				if (!this.uosOrientation.Enabled)
				{
					foreach (ValueListItem item in this.uosOrientation.Items)
					{
						if (item.DataValue == this.uosOrientation.Value)
							item.Appearance.ForeColorDisabled = Color.Black;
						else
							item.Appearance.ResetForeColorDisabled();
					}
				}
			}

			ShowPaperSizeComment();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
            // 単位テキスト設定
            string unitText = _cmInchControl.GetTitle();

            List<UltraLabel> labelList = new List<UltraLabel>( new UltraLabel[] { ulPrintWidthUnit, ultraLabel1, ulMarginTopUnit, ulMarginLeftUnit, ulMarginRightUnit, ulMarginBottomUnit } );

            foreach ( UltraLabel label in labelList )
            {
                label.Text = unitText;
            }
            ulWatermarkTop.Text = "上　　　　" + unitText;
            ulWatermarkLeft.Text = "左　　　　" + unitText;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
		}

		/// <summary>
		/// 全体設定取得処理
		/// </summary>
		/// <param name="frePrtPSet">自由帳票印字位置設定マスタ</param>
		/// <param name="rpt">ActiveReportオブジェクト</param>
		/// <remarks>
		/// <br>Note		: 画面より全体設定を取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public void GetWholeSetting(FrePrtPSet frePrtPSet, ar.ActiveReport3 rpt)
		{
			_isNowWorking = true;

			if (frePrtPSet != null)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                // 帳票ID
                frePrtPSet.OutputFormFileName = this.tedPrtFormId.Text;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
				// 表示名称
				frePrtPSet.DisplayName			= this.tedDisplayName.Text;
				// 出力確認メッセージ
				frePrtPSet.OutConfimationMsg	= this.tedOutConfimationMsg.Text;
				// コメント（ユーザー）
				frePrtPSet.PrtPprUserDerivNoCmt = this.tedPrtPprUserDerivNoCmt.Text;
				// 改頁行数
				frePrtPSet.FormFeedLineCount	= this.ndtFormFeedLineCount.GetInt();
				// 改行文字数
				frePrtPSet.CrCharCnt			= this.ndtCrCharCnt.GetInt();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                //// 帳票背景画像縦位置
                //frePrtPSet.PrtPprBgImageRowPos	= this.ndtWatermarkTop.GetValue();
                //// 帳票背景画像横位置
                //frePrtPSet.PrtPprBgImageColPos	= this.ndtWatermarkLeft.GetValue();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                // 帳票背景画像縦位置
                frePrtPSet.PrtPprBgImageRowPos = ar.ActiveReport3.InchToCm( _cmInchControl.ToData( (float)this.ndtWatermarkTop.GetValue() ) );
                // 帳票背景画像横位置
                frePrtPSet.PrtPprBgImageColPos = ar.ActiveReport3.InchToCm( _cmInchControl.ToData( (float)this.ndtWatermarkLeft.GetValue() ) );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
				// 端文字処理区分
				frePrtPSet.EdgeCharProcDivCd	= (int)this.cmbEdgeCharProcDivCd.Value;
				// 明細背景色
				frePrtPSet.SetDetailBackColor(this.ucpDetailBackColor.Color);
			}

			if (rpt != null)
			{
				// 用紙種別
				rpt.PageSettings.PaperKind = (PaperKind)this.cmbPaperName.Value;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                //// 余白設定
                //rpt.PageSettings.Margins.Top	= ar.ActiveReport3.CmToInch((float)this.ndtMarginTop.GetValue());
                //rpt.PageSettings.Margins.Bottom = ar.ActiveReport3.CmToInch((float)this.ndtMarginBottom.GetValue());
                //rpt.PageSettings.Margins.Right	= ar.ActiveReport3.CmToInch((float)this.ndtMarginRight.GetValue());
                //rpt.PageSettings.Margins.Left	= ar.ActiveReport3.CmToInch((float)this.ndtMarginLeft.GetValue());
                //// 用紙幅
                //rpt.PrintWidth = ar.ActiveReport3.CmToInch((float)this.ndtPrintWidth.GetValue());
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                // 余白設定
                rpt.PageSettings.Margins.Top = _cmInchControl.ToData( (float)this.ndtMarginTop.GetValue() );
                rpt.PageSettings.Margins.Bottom = _cmInchControl.ToData( (float)this.ndtMarginBottom.GetValue() );
                rpt.PageSettings.Margins.Right = _cmInchControl.ToData( (float)this.ndtMarginRight.GetValue() );
                rpt.PageSettings.Margins.Left = _cmInchControl.ToData( (float)this.ndtMarginLeft.GetValue() );
                // 用紙幅
                rpt.PrintWidth = _cmInchControl.ToData( (float)this.ndtPrintWidth.GetValue() );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
                // 印字方向
				rpt.PageSettings.Orientation = (PageOrientation)this.uosOrientation.Value;

				// 用紙種別がカスタムの時は用紙サイズ=レイアウトのサイズとする
				if (rpt.PageSettings.PaperKind == PaperKind.Custom)
				{
					// 幅＋余白（左右）
					rpt.PageSettings.PaperWidth = rpt.PrintWidth + rpt.PageSettings.Margins.Left + rpt.PageSettings.Margins.Right;
					
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 DEL
                    //// 全Sectionの高さ+余白（上下）
                    //float printHeight = 0;
                    //foreach (ar.Section section in rpt.Sections)
                    //    printHeight += section.Height;
                    //rpt.PageSettings.PaperHeight = printHeight + rpt.PageSettings.Margins.Bottom + rpt.PageSettings.Margins.Bottom;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                    //float printHeight = ar.ActiveReport3.CmToInch( (float)this.ndtPrintHeight.GetValue());
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                    float printHeight = _cmInchControl.ToData( (float)this.ndtPrintHeight.GetValue() );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
                    
                    if ( printHeight == 0 )
                    {
                        foreach ( ar.Section section in rpt.Sections )
                        {
                            if ( section.Type == DataDynamics.ActiveReports.SectionType.Detail )
                            {
                                printHeight += (section.Height * (float)frePrtPSet.FormFeedLineCount);
                            }
                            else
                            {
                                printHeight += section.Height;
                            }
                        }
                    }
                    rpt.PageSettings.PaperHeight = printHeight + rpt.PageSettings.Margins.Top + rpt.PageSettings.Margins.Bottom;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
				}
			}

			_isNowWorking = false;
		}

		/// <summary>
		/// 入力チェック処理
		/// </summary>
		/// <param name="message">メッセージ</param>
		/// <param name="control">コントロール</param>
		/// <returns>チェック結果</returns>
		/// <remarks>
		/// <br>Note		: 画面の入力チェックを行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public bool InputCheck(out string message, out Control control)
		{
			message = string.Empty;
			control = null;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
            // 帳票ＩＤ
            if ( this.tedPrtFormId.Text.Equals( string.Empty ) )
            {
                message = this.ulPrtFormId.Text + "が入力されていません。";
                control = this.tedPrtFormId;
                return false;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD

			// 帳票名称
			if (this.tedDisplayName.Text.Equals(string.Empty))
			{
				message = this.ulDisplayName.Text + "が入力されていません。";
				control = this.tedDisplayName;
				return false;
			}

			// コメント（ユーザー）
			if (this.tedPrtPprUserDerivNoCmt.Text.Equals(string.Empty))
			{
				message = this.ulPrtPprUserDerivNoCmt.Text + "が入力されていません。";
				control = this.tedPrtPprUserDerivNoCmt;
				return false;
			}

			// 出力確認メッセージ
			if (this.tedOutConfimationMsg.Text.Equals(string.Empty))
			{
				message = this.ulOutConfimationMsg.Text + "が入力されていません。";
				control = this.tedOutConfimationMsg;
				return false;
			}

			return true;
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// コントロール入力状態変更処理
		/// </summary>
		/// <param name="printPaperUseDivcd">帳票使用区分</param>
		/// <param name="isContractFreeSheetgMng">自由帳票管理オプションフラグ</param>
		/// <param name="isUpdateMode">更新モードフラグ</param>
		/// <remarks>
		/// <br>Note		: コントロールの入力状態を変更します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ChangeControlEnabled(int printPaperUseDivcd, bool isContractFreeSheetgMng, bool isUpdateMode)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 DEL
            //// 帳票使用区分が伝票且つ自由帳票管理オプション導入時のみ「改頁文字数」「端文字処理」の編集を許可する
            //if (printPaperUseDivcd == (int)SFANL08105UA.PrintPaperUseDivcdKind.Slip)
            //{
            //    this.ndtFormFeedLineCount.Enabled	= true;
            //    this.ndtCrCharCnt.Enabled			= true;
            //    this.ulCrCharCntComment.Visible		= true;
            //    if (isContractFreeSheetgMng)
            //    {
            //        this.ndtFormFeedLineCount.ReadOnly	= false;
            //        this.ndtCrCharCnt.ReadOnly			= false;
            //        this.ndtFormFeedLineCount.Appearance.ResetCursor();
            //        this.ndtCrCharCnt.Appearance.ResetCursor();
            //    }
            //    else
            //    {
            //        this.ndtFormFeedLineCount.ReadOnly	= true;
            //        this.ndtCrCharCnt.ReadOnly			= true;
            //        this.ndtFormFeedLineCount.Appearance.Cursor	= Cursors.Arrow;
            //        this.ndtCrCharCnt.Appearance.Cursor			= Cursors.Arrow;
            //    }
            //}
            //else
            //{
            //    this.ndtFormFeedLineCount.Enabled	= false;
            //    this.ndtCrCharCnt.Enabled			= false;
            //    this.ulCrCharCntComment.Visible		= false;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
            this.ndtFormFeedLineCount.Enabled = true;
            this.ndtCrCharCnt.Enabled = true;
            this.ulCrCharCntComment.Visible = true;
            this.ndtFormFeedLineCount.ReadOnly = false;
            this.ndtCrCharCnt.ReadOnly = false;
            this.ndtFormFeedLineCount.Appearance.ResetCursor();
            this.ndtCrCharCnt.Appearance.ResetCursor();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD

			// 更新モード時は「表示名称」「ユーザーコメント」「出力メッセージ」の編集を不可とする
			if (isUpdateMode)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                this.tedPrtFormId.ReadOnly = true;
                this.tedPrtFormId.Appearance.ResetBackColor();
                this.tedPrtFormId.Appearance.Cursor = Cursors.Arrow;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                //this.tedDisplayName.ReadOnly			= true;
                //this.tedPrtPprUserDerivNoCmt.ReadOnly	= true;
                //this.tedOutConfimationMsg.ReadOnly		= true;
                //this.tedDisplayName.Appearance.ResetBackColor();
                //this.tedPrtPprUserDerivNoCmt.Appearance.ResetBackColor();
                //this.tedOutConfimationMsg.Appearance.ResetBackColor();
                //this.tedDisplayName.Appearance.Cursor			= Cursors.Arrow;
                //this.tedPrtPprUserDerivNoCmt.Appearance.Cursor	= Cursors.Arrow;
                //this.tedOutConfimationMsg.Appearance.Cursor		= Cursors.Arrow;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
            }
			else
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                this.tedPrtFormId.ReadOnly = false;
                this.tedPrtFormId.Appearance.BackColor = Color.FromArgb( 179, 219, 231 );
                this.tedPrtFormId.Appearance.ResetCursor();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                //this.tedDisplayName.ReadOnly			= false;
                //this.tedPrtPprUserDerivNoCmt.ReadOnly	= false;
                //this.tedOutConfimationMsg.ReadOnly		= false;
                //this.tedDisplayName.Appearance.BackColor			= Color.FromArgb(179, 219, 231);
                //this.tedPrtPprUserDerivNoCmt.Appearance.BackColor	= Color.FromArgb(179, 219, 231);
                //this.tedOutConfimationMsg.Appearance.BackColor		= Color.FromArgb(179, 219, 231);
                //this.tedDisplayName.Appearance.ResetCursor();
                //this.tedPrtPprUserDerivNoCmt.Appearance.ResetCursor();
                //this.tedOutConfimationMsg.Appearance.ResetCursor();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //// 自由帳票管理オプションが未導入時は余白設定と背景関係以外の項目を編集不可とする
            //if (!isContractFreeSheetgMng)
            //{
            //    this.cmbPaperName.ReadOnly			= true;
            //    this.ndtPrintWidth.ReadOnly			= true;
            //    this.cmbEdgeCharProcDivCd.ReadOnly	= true;
            //    this.ucpDetailBackColor.ReadOnly	= true;
            //    this.cmbPaperName.Appearance.Cursor			= Cursors.Arrow;
            //    this.ndtPrintWidth.Appearance.Cursor		= Cursors.Arrow;
            //    this.cmbEdgeCharProcDivCd.Appearance.Cursor	= Cursors.Arrow;
            //    this.ucpDetailBackColor.Appearance.Cursor	= Cursors.Arrow;
				
            //    this.uosOrientation.Enabled = false;

            //    // 更新モードの伝票は余白設定も編集不可とする
            //    if (printPaperUseDivcd == (int)SFANL08105UA.PrintPaperUseDivcdKind.Slip && isUpdateMode)
            //    {
            //        this.ndtMarginTop.Enabled		= false;
            //        this.ndtMarginBottom.Enabled	= false;
            //        this.ndtMarginRight.Enabled		= false;
            //        this.ndtMarginLeft.Enabled		= false;
            //    }
            //    else
            //    {
            //        this.ndtMarginTop.Enabled		= true;
            //        this.ndtMarginBottom.Enabled	= true;
            //        this.ndtMarginRight.Enabled		= true;
            //        this.ndtMarginLeft.Enabled		= true;
            //    }
            //}
            //else
            //{
            //    this.cmbPaperName.ReadOnly			= false;
            //    this.ndtPrintWidth.ReadOnly			= false;
            //    this.cmbEdgeCharProcDivCd.ReadOnly	= false;
            //    this.ucpDetailBackColor.ReadOnly	= false;
            //    this.cmbPaperName.Appearance.ResetCursor();
            //    this.ndtPrintWidth.Appearance.ResetCursor();
            //    this.cmbEdgeCharProcDivCd.Appearance.ResetCursor();
            //    this.ucpDetailBackColor.Appearance.ResetCursor();

            //    this.uosOrientation.Enabled			= true;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
		}

		/// <summary>
		/// 用紙サイズコメント表示処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 用紙サイズの補足説明を表示します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ShowPaperSizeComment()
		{
			if (this.cmbPaperName.Value != null)
			{
				// 用紙種別
				PaperKind paperKind	= (PaperKind)this.cmbPaperName.Value;
				if (paperKind == PaperKind.Custom)
				{
					this.ulPaperSize.Text = string.Empty;
				}
				else
				{
					// プリンタークラスより用紙サイズを取得
					Printer printer = new Printer();
					// 仮想プリンタを指定
					printer.PrinterName = string.Empty;
					printer.PaperKind = paperKind;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                    //float paperWidth = ar.ActiveReport3.InchToCm(printer.PaperWidth);
                    //float paperHeight = ar.ActiveReport3.InchToCm(printer.PaperHeight);
                    //if ( (PageOrientation)this.uosOrientation.Value == PageOrientation.Landscape )
                    //    this.ulPaperSize.Text = string.Format( "用紙サイズ( {0:f1}㎝ x {1:f1}㎝ )", paperHeight, paperWidth );
                    //else
                    //    this.ulPaperSize.Text = string.Format( "用紙サイズ( {0:f1}㎝ x {1:f1}㎝ )", paperWidth, paperHeight );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                    float paperWidth = _cmInchControl.ToDisp( printer.PaperWidth );
                    float paperHeight = _cmInchControl.ToDisp( printer.PaperHeight );
                    if ( (PageOrientation)this.uosOrientation.Value == PageOrientation.Landscape )
                        this.ulPaperSize.Text = string.Format( "用紙サイズ( {0:f1}{2} x {1:f1}{2} )", paperHeight, paperWidth, _cmInchControl.GetTitle() );
                    else
                        this.ulPaperSize.Text = string.Format( "用紙サイズ( {0:f1}{2} x {1:f1}{2} )", paperWidth, paperHeight, _cmInchControl.GetTitle() );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
				}
			}
		}
		#endregion

		#region Event
		/// <summary>
		/// クリアボタンClickイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: クリアボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ubClear_Click(object sender, EventArgs e)
		{
			this.pnlWatermark.BackgroundImage = null;
			_watermark = null;

			WholeSettingChanged(ChangedType.Watermark, e);
		}

		/// <summary>
		/// 参照ボタンClickイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 参照ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ubReference_Click(object sender, EventArgs e)
		{
			DialogResult dlgRet = this.openFileDialog.ShowDialog();
			if (dlgRet == DialogResult.OK)
			{
				FileInfo fileInfo = new FileInfo(this.openFileDialog.FileName);
				if (fileInfo != null && fileInfo.Length > 1000000)
				{
					string message = "ファイルサイズの大きい画像が選択されました。"
						+ Environment.NewLine + Environment.NewLine
						+ "保存・呼出に時間がかかるようになりますが適用しますか？";
					dlgRet = TMsgDisp.Show(
						emErrorLevel.ERR_LEVEL_QUESTION,
						SFANL08105UH.ctASSEMBLY_ID,
						message,
						0,
						MessageBoxButtons.OKCancel);
				}
			}

			if (dlgRet == DialogResult.OK)
			{
				// Image.FromFile→Disposeで画像ファイルのロックを回避
				Image image = Image.FromFile(this.openFileDialog.FileName);
				Bitmap bitmap = new Bitmap(image);
				this.pnlWatermark.BackgroundImage = bitmap;
				_watermark = this.pnlWatermark.BackgroundImage;
				image.Dispose();

				WholeSettingChanged(ChangedType.Watermark, e);
			}
		}

		/// <summary>
		/// 印字方向ValueChangedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールの値が変更された場合に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void uosOrientation_ValueChanged(object sender, EventArgs e)
		{
			if (this.uosOrientation.Value == null)
				this.uosOrientation.CheckedIndex = 0;

			ShowPaperSizeComment();
		}

		/// <summary>
		/// 用紙種類SelectionChangeCommittedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 選択が変更された後に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void cmbPaperName_SelectionChangeCommitted(object sender, EventArgs e)
		{
			ShowPaperSizeComment();
		}

		/// <summary>
		/// tArrowKeyControl1_ChangeFocusイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: カーソルが移動する時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
            if ( e.NextCtrl == this.tedPrtFormId && this.tedPrtFormId.ReadOnly )
            {
                e.NextCtrl = null;
                return;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //if (e.NextCtrl == this.tedDisplayName && this.tedDisplayName.ReadOnly)
            //{
            //    e.NextCtrl = null;
            //    return;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL

			if (e.PrevCtrl is TNedit)
			{
				if (!_bufCode.Equals(((TNedit)e.PrevCtrl).GetValue()))
					WholeSettingChanged(ChangedType.PrintPos, e);
			}
			else if (e.PrevCtrl is TEdit)
			{
				if (!_bufText.Equals(((TEdit)e.PrevCtrl).Text))
					WholeSettingChanged(ChangedType.Comment, e);
			}

			if (e.NextCtrl is TNedit)
				_bufCode = ((TNedit)e.NextCtrl).GetValue();
			else if (e.NextCtrl is TEdit)
				_bufText = ((TEdit)e.NextCtrl).Text;

			switch (e.Key)
			{
				case Keys.Enter:
				{
					if (!this.Contains(e.NextCtrl))
					{
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                        //if ( this.tedDisplayName.ReadOnly )
                        //{
                        //    if (this.cmbPaperName.ReadOnly)
                        //        e.NextCtrl = this.ndtMarginTop;
                        //    else
                        //        e.NextCtrl = this.cmbPaperName;
                        //}
                        //else
                        //    e.NextCtrl = this.tedDisplayName;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                        if ( !this.tedPrtFormId.ReadOnly )
                        {
                            e.NextCtrl = this.tedPrtFormId;
                        }
                        else
                        {
                            e.NextCtrl = this.tedDisplayName;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
					}
					break;
				}
				case Keys.Up:
				case Keys.Down:
				case Keys.Left:
				case Keys.Right:
				{
					if (!this.Contains(e.NextCtrl))
						e.NextCtrl = null;
					break;
				}
			}
		}

		/// <summary>
		/// MouseEnterElementイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: マウスが要素の四角形に入った時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void TEdit_MouseEnterElement(object sender, UIElementEventArgs e)
		{
			object objContextRow	= e.Element.GetContext(typeof(TEdit));
			if (objContextRow != null)
			{
				TEdit tEdit = objContextRow as TEdit;

				int strWidth = FrePrtSettingController.GetStringWidth(tEdit);
				if (tEdit.ReadOnly && !tEdit.Text.Trim().Equals(string.Empty) && strWidth > tEdit.Width)
				{
					UltraToolTipInfo ultraToolTipInfo = new UltraToolTipInfo();
					ultraToolTipInfo.ToolTipText = tEdit.Text;

					this.ultraToolTipManager.SetUltraToolTip(tEdit, ultraToolTipInfo);
					this.ultraToolTipManager.Enabled = true;
				}
			}
		}

		/// <summary>
		/// MouseLeaveElementイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: マウスが要素の四角形から離れた時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void TEdit_MouseLeaveElement(object sender, UIElementEventArgs e)
		{
			// ツールチップを非表示にする
			this.ultraToolTipManager.HideToolTip();
			this.ultraToolTipManager.Enabled = false;
		}

		/// <summary>
		/// Enterイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールに</br>
		/// <br>			: なったときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void SFANL08105UC_Enter(object sender, EventArgs e)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //if (tedDisplayName.ReadOnly)
            //{
            //    if (!this.cmbPaperName.ReadOnly)
            //        this.cmbPaperName.Focus();
            //    else if (this.ndtMarginTop.Enabled)
            //        this.ndtMarginTop.Focus();
            //    else
            //        this.ubReference.Focus();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
            if ( !this.tedPrtFormId.ReadOnly )
            {
                this.tedPrtFormId.Focus();
            }
            else
            {
                this.tedDisplayName.Focus();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
		}
		#endregion
	}
}