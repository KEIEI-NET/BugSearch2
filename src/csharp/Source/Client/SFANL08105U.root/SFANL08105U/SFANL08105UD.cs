using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinToolTip;
using Infragistics.Win.UltraWinEditors;

using ar=DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Design;

using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// プロパティ設定画面
	/// </summary>
	/// <remarks>
	/// <br>Note		: ActiveReportのプロパティを設定する画面です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.06.06</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08105UD : UserControl
	{
		#region PrivateMember
		// 印字項目グループアクセスクラス
		private PrtItemGrpAcs			_prtItemGrpAcs;
		// 処理中フラグ
		private bool					_isNowWorking;
		// プロパティ表示中フラグ
		private bool					_isShowPropertyData;
		// 選択中のコントロール
		private Selection				_selection;
		// 入力変更チェック用
		private double					_buffCode;
		private string					_buffText;
		// 印字項目設定LIST
		private List<PrtItemSetWork>	_prtItemSetList;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
        // 印字位置設定
        private FrePrtPSet _frePrtPSet;
        // レポートインスタンス
        private ar.ActiveReport3 _report;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
        // センチ・インチ制御
        private CmInchControl _cmInchControl;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
		// フォントサイズ
		private int[] _fontSizeArray	= new int[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
		#endregion

		#region Delegate
		// 選択コントロール変更イベントハンドラ
		public delegate void SelectedARControlNameChangedEventHandler(string name);
		#endregion

		#region PublicEventHandler
		// 選択コントロール変更イベント
		public event SelectedARControlNameChangedEventHandler SelectedARControlNameChanged;
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08105UD()
		{
			InitializeComponent();

			// Regularをサポートしていないフォントは削除する
			for (int ix = 0 ; ix != this.ufnFontName.Items.Count ; ix++)
			{
				FontFamily fontFamily = new FontFamily(this.ufnFontName.Items[ix].ToString());
				if (!fontFamily.IsStyleAvailable(FontStyle.Regular))
					this.ufnFontName.Items.RemoveAt(ix);
			}

			this.cmbOutputFormat.Items.Clear();
			this.cmbOutputFormat.Items.Add(string.Empty,	" ");
			this.cmbOutputFormat.Items.Add("#,###",			"#,###");
			this.cmbOutputFormat.Items.Add("#,##0",			"#,##0");
			this.cmbOutputFormat.Items.Add(@"\\#,##0",		"\\#,##0");
			this.cmbOutputFormat.Items.Add(@"\\#,##0-",		"\\#,##0-");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/09 ADD
            this.cmbOutputFormat.Items.Add( @"\\#,###;-\\#,###;''", "\\#,###" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/09 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/00/00 ADD
            this.cmbOutputFormat.Items.Add( "###0", "###0" );
            this.cmbOutputFormat.Items.Add( "####", "####" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/00/00 ADD
			this.cmbOutputFormat.Items.Add("0.0",			"0.0");
			this.cmbOutputFormat.Items.Add("0.00",			"0.00");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this.cmbOutputFormat.Items.Add( "#,##0.00", "#,##0.00" );
            this.cmbOutputFormat.Items.Add( @"\\#,##0.00", "\\#,##0.00" );
            this.cmbOutputFormat.Items.Add( @"\\#,##0.00-", "\\#,##0.00-" );
            this.cmbOutputFormat.Items.Add( "0", "0" );
            this.cmbOutputFormat.Items.Add( "00", "00" );
            this.cmbOutputFormat.Items.Add( "000", "000" );
            this.cmbOutputFormat.Items.Add( "0000", "0000" );
            this.cmbOutputFormat.Items.Add( "00000", "00000" );
            this.cmbOutputFormat.Items.Add( "000000", "000000" );
            this.cmbOutputFormat.Items.Add( "0000000", "0000000" );
            this.cmbOutputFormat.Items.Add( "00000000", "00000000" );
            this.cmbOutputFormat.Items.Add( "000000000", "000000000" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			this.cmbAlignment.Items.Clear();
			this.cmbAlignment.Items.Add(ar.TextAlignment.Left,		"左寄せ");
			this.cmbAlignment.Items.Add(ar.TextAlignment.Center,	"中央合わせ");
			this.cmbAlignment.Items.Add(ar.TextAlignment.Right,		"右寄せ");

			this.cmbVerticalAlignment.Items.Clear();
			this.cmbVerticalAlignment.Items.Add(ar.VerticalTextAlignment.Top,		"上寄せ");
			this.cmbVerticalAlignment.Items.Add(ar.VerticalTextAlignment.Middle,	"中央合わせ");
			this.cmbVerticalAlignment.Items.Add(ar.VerticalTextAlignment.Bottom,	"下寄せ");

			this.cmbLineStyle.Items.Clear();
			this.cmbLineStyle.Items.Add(ar.LineStyle.Transparent,	"なし");
			this.cmbLineStyle.Items.Add(ar.LineStyle.Solid,			"実線");
			this.cmbLineStyle.Items.Add(ar.LineStyle.Dash,			"破線");
			this.cmbLineStyle.Items.Add(ar.LineStyle.Dot,			"点線");
			this.cmbLineStyle.Items.Add(ar.LineStyle.DashDot,		"一点鎖線");
			this.cmbLineStyle.Items.Add(ar.LineStyle.DashDotDot,	"二点鎖線");

			this.cmbStyle.Items.Clear();
			this.cmbStyle.Items.Add(ar.ShapeType.Rectangle,	"長方形");
			this.cmbStyle.Items.Add(ar.ShapeType.Ellipse,	"楕円");
			this.cmbStyle.Items.Add(ar.ShapeType.RoundRect,	"角丸長方形");

			this.cmbPictureAlignment.Items.Clear();
			this.cmbPictureAlignment.Items.Add(ar.PictureAlignment.TopLeft,		"左上");
			this.cmbPictureAlignment.Items.Add(ar.PictureAlignment.TopRight,	"右上");
			this.cmbPictureAlignment.Items.Add(ar.PictureAlignment.Center,		"中央");
			this.cmbPictureAlignment.Items.Add(ar.PictureAlignment.BottomLeft,	"左下");
			this.cmbPictureAlignment.Items.Add(ar.PictureAlignment.BottomRight,	"右下");

			this.cmbSizeMode.Items.Clear();
			this.cmbSizeMode.Items.Add(ar.SizeModes.Clip,		"原寸大");
			this.cmbSizeMode.Items.Add(ar.SizeModes.Stretch,	"幅に合わせる");
			this.cmbSizeMode.Items.Add(ar.SizeModes.Zoom,		"縦横比固定");

			this.cmbPrintPageCtrlDivCd.Items.Clear();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 DEL
            //this.cmbPrintPageCtrlDivCd.Items.Add(0, "全ページ");
            //this.cmbPrintPageCtrlDivCd.Items.Add(1, "1ページ目のみ");
            //this.cmbPrintPageCtrlDivCd.Items.Add(2, "最終ページのみ");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 DEL

			this.cmbNewPage.Items.Clear();
			this.cmbNewPage.Items.Add(ar.NewPage.None,			"　");
			this.cmbNewPage.Items.Add(ar.NewPage.Before,		"印字前");
			this.cmbNewPage.Items.Add(ar.NewPage.After,			"印字後");
			this.cmbNewPage.Items.Add(ar.NewPage.BeforeAfter,	"印字前後");

			this.cmbRepeatStyle.Items.Clear();
			this.cmbRepeatStyle.Items.Add(ar.RepeatStyle.None,					"　");
			this.cmbRepeatStyle.Items.Add(ar.RepeatStyle.OnPage,				"ページ毎");
			this.cmbRepeatStyle.Items.Add(ar.RepeatStyle.OnPageIncludeNoDetail,	"関連データ有り時");

			this.cmbSummaryFunc.Items.Clear();
			this.cmbSummaryFunc.Items.Add(ar.SummaryFunc.Sum,	"合計");
			this.cmbSummaryFunc.Items.Add(ar.SummaryFunc.Avg,	"平均");
			this.cmbSummaryFunc.Items.Add(ar.SummaryFunc.Count,	"総数");
			this.cmbSummaryFunc.Items.Add(ar.SummaryFunc.Min,	"最小値");
			this.cmbSummaryFunc.Items.Add(ar.SummaryFunc.Max,	"最大値");

			this.cmbSummaryRunning.Items.Clear();
			this.cmbSummaryRunning.Items.Add(ar.SummaryRunning.None,	"　");
			this.cmbSummaryRunning.Items.Add(ar.SummaryRunning.Group,	"グループ");
			this.cmbSummaryRunning.Items.Add(ar.SummaryRunning.All,		"全て");

			this.cmbSummaryType.Items.Clear();
			this.cmbSummaryType.Items.Add(ar.SummaryType.None,			"　");
			this.cmbSummaryType.Items.Add(ar.SummaryType.SubTotal,		"グループ");
			this.cmbSummaryType.Items.Add(ar.SummaryType.PageTotal,		"ページ");
			this.cmbSummaryType.Items.Add(ar.SummaryType.GrandTotal,	"全て");

			this.cmbGroupSuppressCd.Items.Clear();
			this.cmbGroupSuppressCd.Items.Add(0, "なし");
			this.cmbGroupSuppressCd.Items.Add(1, "あり");

			this.cmbDtlColorChangeCd.Items.Clear();
			this.cmbDtlColorChangeCd.Items.Add(0, "なし");
			this.cmbDtlColorChangeCd.Items.Add(1, "あり");

			this.cmbHeightAdjustDivCd.Items.Clear();
			this.cmbHeightAdjustDivCd.Items.Add(0, "なし");
			this.cmbHeightAdjustDivCd.Items.Add(1, "あり");

			this.cmbFontSize.DataSource = _fontSizeArray;

			this.ubImage.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

			this.ubDataField.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

			_prtItemSetList = new List<PrtItemSetWork>();
		}
		#endregion

		#region Property
		/// <summary>印字項目設定LIST</summary>
		public List<PrtItemSetWork> PrtItemSetList
		{
			set {
				if (value == null)
					_prtItemSetList = new List<PrtItemSetWork>();
				else
					_prtItemSetList = value;
			}
		}

		/// <summary>処理中フラグ</summary>
		public bool IsNowWorking
		{
			get { return _isNowWorking; }
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
        /// <summary>
        /// 印字位置設定
        /// </summary>
        public FrePrtPSet FrePrtPSet
        {
            set
            {
                if ( value == null )
                {
                    _frePrtPSet = new FrePrtPSet();
                }
                else
                {
                    _frePrtPSet = value;
                }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
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
		/// プロパティ情報表示処理
		/// </summary>
		/// <param name="rpt">ActiveReportオブジェクト</param>
		/// <param name="selection">選択項目</param>
		/// <param name="aRCtrlDispList">自由帳票プロパティ表示情報LIST</param>
		/// <remarks>
		/// <br>Note		: 選択された項目のプロパティ情報を表示します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public void ShowPropertyInfo(ar.ActiveReport3 rpt, Selection selection, List<ARCtrlPropertyDispInfo> aRCtrlDispList)
		{
			this.SuspendLayout();

			_selection = selection;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
            _report = rpt;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD

			this.cmbSummaryGroup.Items.Clear();
			this.cmbSummaryGroup.Items.Add(string.Empty);
			foreach (ar.Section section in rpt.Sections)
			{
				if (section is ar.GroupHeader)
					this.cmbSummaryGroup.Items.Add(section.Name);
			}

			VisibleSetting(aRCtrlDispList);

			ShowPropertyData();

			this.ResumeLayout(true);
		}

		/// <summary>
		/// 選択項目コンボボックス更新処理
		/// </summary>
		/// <param name="rpt">ActiveReportオブジェクト</param>
		/// <param name="imageList">画像LIST</param>
		/// <remarks>
		/// <br>Note		: 選択項目コンボボックスの内容を更新します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public void UpdateSelectItemCombo(ar.ActiveReport3 rpt, ImageList imageList)
		{
			this.cmbSelectItem.Items.Clear();
			foreach (ar.Section section in rpt.Sections)
			{
				foreach (ar.ARControl aRControl in section.Controls)
				{
					ValueListItem valueListItem;
					valueListItem = this.cmbSelectItem.Items.Add(aRControl.Name, GetItemDispName(aRControl, _prtItemSetList));

					// ICONの設定
					switch (aRControl.GetType().Name)
					{
						case "TextBox":	valueListItem.Appearance.Image = imageList.Images[SFANL08105UA.AR_ICON_TEXTBOX];	break;
						case "Label":	valueListItem.Appearance.Image = imageList.Images[SFANL08105UA.AR_ICON_LABEL];		break;
						case "Picture":	valueListItem.Appearance.Image = imageList.Images[SFANL08105UA.AR_ICON_PICTURE];	break;
						case "Shape":	valueListItem.Appearance.Image = imageList.Images[SFANL08105UA.AR_ICON_SHAPE];		break;
						case "Line":	valueListItem.Appearance.Image = imageList.Images[SFANL08105UA.AR_ICON_LINE];		break;
						case "Barcode":	valueListItem.Appearance.Image = imageList.Images[SFANL08105UA.AR_ICON_BARCODE];	break;
					}
				}
			}
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// 可視設定処理
		/// </summary>
		/// <param name="aRCtrlDispList">自由帳票プロパティ表示情報LIST</param>
		/// <remarks>
		/// <br>Note		: 自由帳票プロパティ表示情報を元に各パネルのVisible設定を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void VisibleSetting(List<ARCtrlPropertyDispInfo> aRCtrlDispList)
		{
			foreach (Control control in this.Controls)
				control.Visible = true;

			foreach (Control control in this.Controls)
			{
				if (control.Tag != null && !control.Tag.ToString().Equals(string.Empty))
				{
					for (int ix = 0 ; ix < _selection.Count ; ix++)
					{
						PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])[control.Tag.ToString()];
						if (propertyInfo == null)
						{
							control.Visible = false;
							break;
						}
						else
						{
							// 特殊な設定画面処理
							if (_selection[ix] is ar.ARControl)
							{
								// Pictureのバインド項目は画像設定を行わせない
								if (propertyInfo.Name == SFANL08105UA.ctPropName_Image)
								{
									ar.ARControl aRControl = (ar.ARControl)_selection[ix];
									PrtItemSetWork prtItemSetWork = FrePrtSettingController.GetPrtItemSet(aRControl, _prtItemSetList);
									if (prtItemSetWork != null)
									{
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 DEL
                                        //if (prtItemSetWork.FreePrtPaperItemCd != (int)SFANL08105UA.FreePrtPaperItemCdKind.Picture)
                                        //    control.Visible = false;
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 DEL
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
                                        if ( prtItemSetWork.DDName != null && prtItemSetWork.DDName.Trim() != string.Empty )
                                        {
                                            // バインドするデータフィールド名が設定されている場合は画像設定不要
                                            control.Visible = false;
                                        }
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
									}
								}
							}

							ARCtrlPropertyDispInfo aRCtrlPropertyDispInfo
								= GetARCtrlPropertyDispInfo(aRCtrlDispList, _selection[ix].GetType().Name,propertyInfo.Name);
							if (aRCtrlPropertyDispInfo != null)
							{
								if (aRCtrlPropertyDispInfo.CanDisplay == 0)
								{
									control.Visible = false;
									break;
								}
							}
							else
							{
								control.Visible = false;
								break;
							}
						}
					}
				}
			}

			// 特殊な設定画面処理
			this.pnlPrintPageCtrlDivCd.Visible	= false;
			this.pnlGroupSuppressCd.Visible		= false;
			this.pnlDtlColorChangeCd.Visible	= false;
			this.pnlSummaryFunc.Visible			= false;
			this.pnlSummaryGroup.Visible		= false;
			this.pnlSummaryRunning.Visible		= false;
			this.pnlSummaryType.Visible			= false;
			this.pnlDataField.Visible			= false;

			// 単一選択時のみに行われる処理
			if (_selection.Count == 1)
			{
				// 選択項目名
				PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[0])["Name"];
				if (propertyInfo != null)
					this.cmbSelectItem.Value = propertyInfo.GetValue(_selection[0]);

				if (_selection[0] is ar.ARControl)
				{
					ar.ARControl aRControl = (ar.ARControl)_selection[0];
					if (aRControl.Tag != null)
					{
						_isShowPropertyData = true;
						try
						{
							PrtItemSetWork prtItemSetWork = FrePrtSettingController.GetPrtItemSet(aRControl, _prtItemSetList);
							if (prtItemSetWork != null)
							{
								ARCtrlPropertyDispInfo aRCtrlPropertyDispInfo = null;
								// Detailに配置されてる場合のみ編集可能な項目の処理
								if (aRControl.Parent is ar.Detail)
								{
									// 「サプレス」（TextBoxの時のみ有効）
									aRCtrlPropertyDispInfo
										= GetARCtrlPropertyDispInfo(aRCtrlDispList, aRControl.GetType().Name, "GroupSuppressCd");
									if (aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1)
										this.pnlGroupSuppressCd.Visible = true;
									this.cmbGroupSuppressCd.Value = prtItemSetWork.GroupSuppressCd;

									// 「網掛け」
									aRCtrlPropertyDispInfo
										= GetARCtrlPropertyDispInfo(aRCtrlDispList, aRControl.GetType().Name, "DtlColorChangeCd");
									if (aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1)
										this.pnlDtlColorChangeCd.Visible = true;
									this.cmbDtlColorChangeCd.Value = prtItemSetWork.DtlColorChangeCd;

									// 「高さの同期」
									aRCtrlPropertyDispInfo
										= GetARCtrlPropertyDispInfo(aRCtrlDispList, aRControl.GetType().Name, "HeightAdjustDivCd");
									if (aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1)
										this.pnlHeightAdjustDivCd.Visible = true;
									this.cmbHeightAdjustDivCd.Value = prtItemSetWork.HeightAdjustDivCd;
								}

								// 「印字ページ」
								aRCtrlPropertyDispInfo
									= GetARCtrlPropertyDispInfo(aRCtrlDispList, aRControl.GetType().Name, "PrintPageCtrlDivCd");
								if (aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1)
									this.pnlPrintPageCtrlDivCd.Visible = true;
								this.cmbPrintPageCtrlDivCd.Items.Clear();
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 DEL
                                //this.cmbPrintPageCtrlDivCd.Items.Add(0, "全ページ");
                                //this.cmbPrintPageCtrlDivCd.Items.Add(1, "1ページ目のみ");
                                //if (aRControl.Parent is ar.GroupFooter)
                                //    this.cmbPrintPageCtrlDivCd.Items.Add(2, "最終ページのみ");
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                                if ( _frePrtPSet.PrintPaperUseDivcd == 2 )
                                {
                                    ulPrintPageCtrlDivCd.Text = "印字制御";
                                    ulPrintPageCtrlDivCd.Font = new Font( ulPrintPageCtrlDivCd.Font.OriginalFontName, 11 );

                                    if ( aRControl is ar.TextBox )
                                    {
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 0, "全て" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 1, "タイトル１のみ" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 2, "タイトル２のみ" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 3, "タイトル３のみ" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 4, "タイトル４のみ" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 5, "タイトル５のみ" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 6, "タイトル１除く" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 7, "タイトル２除く" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 8, "タイトル３除く" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 9, "タイトル４除く" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 10, "タイトル５除く" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 11, "タイトル１,２" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 12, "タイトル１,２,３" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 13, "タイトル３,４,５" );
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 14, "タイトル４,５" );
                                    }
                                    else
                                    {
                                        // 非表示にする
                                        this.pnlPrintPageCtrlDivCd.Visible = false;
                                    }
                                }
                                else
                                {
                                    ulPrintPageCtrlDivCd.Text = "印字ページ";
                                    ulPrintPageCtrlDivCd.Font = new Font( ulPrintPageCtrlDivCd.Font.OriginalFontName, 9 );

                                    this.cmbPrintPageCtrlDivCd.Items.Add( 0, "全ページ" );
                                    this.cmbPrintPageCtrlDivCd.Items.Add( 1, "1ページ目のみ" );
                                    if ( aRControl.Parent is ar.GroupFooter )
                                        this.cmbPrintPageCtrlDivCd.Items.Add( 2, "最終ページのみ" );
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
								this.cmbPrintPageCtrlDivCd.Value = prtItemSetWork.PrintPageCtrlDivCd;

								// 集計関連項目は「FreePrtPaperItemCd=1」のみ編集可能(※DataFieldに関わる部分)
								if (prtItemSetWork.FreePrtPaperItemCd == 1)
								{
									// 「集計関数」
									aRCtrlPropertyDispInfo
										= GetARCtrlPropertyDispInfo(aRCtrlDispList, aRControl.GetType().Name, "SummaryFunc");
									if (aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1)
										this.pnlSummaryFunc.Visible		= true;
									// 「集計グループ」
									aRCtrlPropertyDispInfo
										= GetARCtrlPropertyDispInfo(aRCtrlDispList, aRControl.GetType().Name, "SummaryGroup");
									if (aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1)
										this.pnlSummaryGroup.Visible	= true;
									// 「累積範囲」
									aRCtrlPropertyDispInfo
										= GetARCtrlPropertyDispInfo(aRCtrlDispList, aRControl.GetType().Name, "SummaryRunning");
									if (aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1)
										this.pnlSummaryRunning.Visible	= true;
									// 「集計タイプ」
									aRCtrlPropertyDispInfo
										= GetARCtrlPropertyDispInfo(aRCtrlDispList, aRControl.GetType().Name, "SummaryType");
									if (aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1)
										this.pnlSummaryType.Visible		= true;

									// 「集計項目」
									this.cmbDataField.Items.Clear();
									if (_prtItemSetList != null)
									{
										List<PrtItemSetWork> wkPrtItemSetList
											= _prtItemSetList.FindAll(
												delegate(PrtItemSetWork wkPrtItemSetWork)
												{
													if (wkPrtItemSetWork.TotalItemDivCd == 1)
														return true;
													else
														return false;
												}
											);
										foreach (PrtItemSetWork wkPrtItemSet in wkPrtItemSetList)
											this.cmbDataField.Items.Add(FrePrtSettingController.CreateDataField(wkPrtItemSet), wkPrtItemSet.FreePrtPaperItemNm);
									}
									if (this.cmbDataField.Items.Count > 0)
									{
										this.cmbDataField.Items.Insert(0, string.Empty, "　");
										aRCtrlPropertyDispInfo
											= GetARCtrlPropertyDispInfo(aRCtrlDispList, aRControl.GetType().Name, "DataField");
										if (aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1)
											this.pnlDataField.Visible = true;
									}
								}
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
                                // 印字可能バイト数
                                aRCtrlPropertyDispInfo
                                    = GetARCtrlPropertyDispInfo( aRCtrlDispList, aRControl.GetType().Name, "PrintableByteCount" );
                                if ( aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1 )
                                {
                                    this.pnlPrintableByteCount.Visible = true;
                                }
                                else
                                {
                                    this.pnlPrintableByteCount.Visible = false;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
							}
						}
						finally
						{
							_isShowPropertyData = false;
						}
					}
				}
				else if (_selection[0] is ar.GroupHeader)
				{
					// DataField表示に関する制御
					this.cmbDataField.Items.Clear();
					if (_prtItemSetList != null)
					{
						List<PrtItemSetWork> wkPrtItemSetList
							= _prtItemSetList.FindAll(
								delegate(PrtItemSetWork prtItemSetWork)
								{
									if (prtItemSetWork.FormFeedItemDivCd != 0)
										return true;
									else
										return false;
								}
							);
						foreach (PrtItemSetWork wkPrtItemSet in wkPrtItemSetList)
							this.cmbDataField.Items.Add(FrePrtSettingController.CreateDataField(wkPrtItemSet), wkPrtItemSet.FreePrtPaperItemNm);
					}
					if (this.cmbDataField.Items.Count > 0)
					{
						this.cmbDataField.Items.Insert(0, string.Empty, "　");
						ARCtrlPropertyDispInfo　aRCtrlPropertyDispInfo
							= GetARCtrlPropertyDispInfo(aRCtrlDispList, _selection[0].GetType().Name, "DataField");
						if (aRCtrlPropertyDispInfo != null && aRCtrlPropertyDispInfo.CanDisplay == 1)
							this.pnlDataField.Visible = true;
					}
				}
				else if (_selection[0] is ar.ActiveReport3)
				{
					// 選択項目名を空白にする
					this.cmbSelectItem.SelectedIndex = -1;
				}
			}
			else
			{
				// 選択項目名を空白にする
				this.cmbSelectItem.SelectedIndex = -1;
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
            // 単位テキスト設定
            string unitText = _cmInchControl.GetTitle();

            List<UltraLabel> labelList = new List<UltraLabel>( new UltraLabel[] { ulUnitTop, ulUnitLeft, ulUnitWidth, ulUnitHeight, ulLineWeightUnit } );

            foreach ( UltraLabel label in labelList )
            {
                label.Text = unitText;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
		}

		/// <summary>
		/// コントロール表示情報クラス取得処理
		/// </summary>
		/// <param name="aRCtrlDispList">取得元コントロール表示情報LIST</param>
		/// <param name="typeName">コントロールタイプ名称</param>
		/// <param name="propertyName">プロパティ名称</param>
		/// <returns>コントロール表示情報クラス</returns>
		/// <remarks>
		/// <br>Note		: コントロール表示情報を取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private ARCtrlPropertyDispInfo GetARCtrlPropertyDispInfo(List<ARCtrlPropertyDispInfo> aRCtrlDispList, string typeName, string propertyName)
		{
			ARCtrlPropertyDispInfo aRCtrlPropertyDispInfo
				= aRCtrlDispList.Find(
					delegate(ARCtrlPropertyDispInfo dispInfo)
					{
						if (dispInfo.ARControlTypeName.Equals(typeName) &&
							dispInfo.PropertyName.Equals(propertyName))
							return true;
						else
							return false;
					}
				 );

			return aRCtrlPropertyDispInfo;
		}

		/// <summary>
		/// プロパティ情報表示処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: プロパティ情報を表示します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ShowPropertyData()
		{
			_isShowPropertyData = true;
			try
			{
				// 各プロパティ設定画面の構築
				foreach (Control control in this.Controls)
				{
					Panel panel = control as Panel;
                    if ( panel != null && panel.Visible )
					{
						foreach (Control targetCtrl in panel.Controls)
						{
							if (targetCtrl.Tag != null && !targetCtrl.Tag.ToString().Equals(string.Empty))
							{
								// バリューが複数種存在するかの判断用
								object buffObj		= null;
								bool isMultiValue	= false;

								// データを取得及び画面へのセット
								for (int ix = 0 ; ix < _selection.Count ; ix++)
								{
									PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])[panel.Tag.ToString()];
									if (propertyInfo != null)
									{
										if (buffObj != null)
										{
											if (!object.Equals(buffObj, propertyInfo.GetValue(_selection[ix])))
												isMultiValue = true;
										}
										else
										{
											buffObj = propertyInfo.GetValue(_selection[ix]);
                                        }

                                        # region [propertyInfo.Name]
                                        switch (propertyInfo.Name)
										{
											case SFANL08105UA.ctPropName_Text:
											case SFANL08105UA.ctPropName_Caption:
											{
												TEdit tEdit = (TEdit)targetCtrl;
												if (isMultiValue)
													tEdit.Clear();
												else
													tEdit.Text = propertyInfo.GetValue(_selection[ix]) as string;
												break;
											}
											case SFANL08105UA.ctPropName_Top:
											case SFANL08105UA.ctPropName_Left:
											case SFANL08105UA.ctPropName_Width:
											case SFANL08105UA.ctPropName_Height:
											case SFANL08105UA.ctPropName_X1:
											case SFANL08105UA.ctPropName_X2:
											case SFANL08105UA.ctPropName_Y1:
											case SFANL08105UA.ctPropName_Y2:
											{
												TNedit tNedit = (TNedit)targetCtrl;
												if (isMultiValue)
												{
													tNedit.Clear();
												}
												else
												{
                                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                                                    //float centi = ar.ActiveReport3.InchToCm((float)propertyInfo.GetValue(_selection[ix]));
                                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                                                    float centi = _cmInchControl.ToDisp( (float)propertyInfo.GetValue( _selection[ix] ) );
                                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
													tNedit.SetValue(centi);
												}
												break;
											}
											case SFANL08105UA.ctPropName_LineWeight:
											{
												TNedit tNedit = (TNedit)targetCtrl;
												if (isMultiValue)
												{
													tNedit.Clear();
												}
												else
												{
                                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                                                    //float centi = ar.ActiveReport3.InchToCm(((float)propertyInfo.GetValue(_selection[ix]) / 144));
                                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                                                    float centi = _cmInchControl.ToDisp( ((float)propertyInfo.GetValue( _selection[ix] ) / 144) );
                                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
													tNedit.SetValue((float)FrePrtSettingController.ToHalfAdjust(centi, 2));
												}
												break;
											}
											case SFANL08105UA.ctPropName_Font:
											{
												Font font = (Font)propertyInfo.GetValue(_selection[ix]);
												if (isMultiValue)
												{
													this.ufnFontName.SelectedIndex = -1;
													this.uceBold.Checked		= false;
													this.uceItalic.Checked		= false;
													this.uceUnderLine.Checked	= false;
													this.cmbFontSize.Value		= 11;
												}
												else
												{
													this.ufnFontName.Value		= font.Name;
													this.uceBold.Checked		= font.Bold;
													this.uceItalic.Checked		= font.Italic;
													this.uceUnderLine.Checked	= font.Underline;
													this.cmbFontSize.Value		= font.Size;
												}
												break;
											}
											case SFANL08105UA.ctPropName_BackColor:
											case SFANL08105UA.ctPropName_ForeColor:
											case SFANL08105UA.ctPropName_LineColor:
											{
												UltraColorPicker ultraColorPicker = (UltraColorPicker)targetCtrl;
												if (isMultiValue)
													ultraColorPicker.Clear();
												else
													ultraColorPicker.Color = (Color)propertyInfo.GetValue(_selection[ix]);
												break;
											}
											case SFANL08105UA.ctPropName_WordWrap:
											case SFANL08105UA.ctPropName_MultiLine:
											case SFANL08105UA.ctPropName_Visible:
											case SFANL08105UA.ctPropName_CanShrink:
											case SFANL08105UA.ctPropName_CanGrow:
											case SFANL08105UA.ctPropName_PrintAtBottom:
											case SFANL08105UA.ctPropName_KeepTogether:
											{
												UltraCheckEditor ultraCheckEditor = (UltraCheckEditor)targetCtrl;
												if (isMultiValue)
													ultraCheckEditor.CheckState	= CheckState.Indeterminate;
												else
													ultraCheckEditor.Checked	= (bool)propertyInfo.GetValue(_selection[ix]);
												break;
											}
											case SFANL08105UA.ctPropName_Alignment:
											case SFANL08105UA.ctPropName_VAlignment:
											case SFANL08105UA.ctPropName_LineStyle:
											case SFANL08105UA.ctPropName_Style:
											case SFANL08105UA.ctPropName_PictureAlign:
											case SFANL08105UA.ctPropName_SizeMode:
											case SFANL08105UA.ctPropName_OutputFormat:
											case SFANL08105UA.ctPropName_NewPage:
											case SFANL08105UA.ctPropName_RepeatStyle:
											case SFANL08105UA.ctPropName_SummaryRunning:
											case SFANL08105UA.ctPropName_SummaryFunc:
											case SFANL08105UA.ctPropName_SummaryType:
											case SFANL08105UA.ctPropName_SummaryGroup:
											{
												TComboEditor tComboEditor = (TComboEditor)targetCtrl;
												if (isMultiValue)
													tComboEditor.SelectedIndex = -1;
												else
													tComboEditor.Value = propertyInfo.GetValue(_selection[ix]);
												break;
											}
											case SFANL08105UA.ctPropName_DataField:
											{
												TComboEditor tComboEditor = (TComboEditor)targetCtrl;
												tComboEditor.Value = propertyInfo.GetValue(_selection[ix]);
												break;
											}
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                                            case SFANL08105UA.ctPropName_CharacterSpacing:
                                            {
                                                TNedit tNedit = (TNedit)targetCtrl;
                                                tNedit.Value = propertyInfo.GetValue( _selection[ix] );
                                                break;
                                            }
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
                                        }
                                        # endregion

                                        if (isMultiValue) break;
                                    }

                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
                                    if ( panel.Tag.ToString() == SFANL08105UA.ctPropName_PrintableByteCount )
                                    {
                                        TEdit tEdit = (TEdit)targetCtrl;

                                        if ( _selection[ix] is ar.TextBox )
                                        {
                                            
                                            int minCount;
                                            int maxCount;
                                            Broadleaf.Drawing.Printing.PMCMN02000CA.GetPrintableByteCount( (_selection[ix] as ar.TextBox), out minCount, out maxCount );
                                            if ( minCount == maxCount )
                                            {
                                                tEdit.Text = string.Format( "{0}", minCount );
                                            }
                                            else
                                            {
                                                tEdit.Text = string.Format( "{0}～{1}", minCount, maxCount );
                                            }
                                        }
                                        else
                                        {
                                            tEdit.Text = string.Empty;
                                        }
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
                                }
							}
						}
					}
				}

				TextCaptionSetting();
			}
			finally
			{
				_isShowPropertyData = false;
			}
		}

		/// <summary>
		/// Textプロパティ用パネルCaption設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: Textプロパティ用のパネル内にあるCaptionを設定します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void TextCaptionSetting()
		{
			if (pnlText.Visible && _selection != null)
			{
				bool existTextBox = false;
				bool existLabel = false;
				for (int ix = 0 ; ix < _selection.Count ; ix++)
				{
					if (existTextBox && existLabel) break;

					if (!existTextBox && _selection[ix] is ar.TextBox)
					{
						existTextBox = true;
						continue;
					}
					else if (!existLabel && _selection[ix] is ar.Label)
					{
						existLabel = true;
						continue;
					}
				}

				if (existTextBox && existLabel)
					this.ulText.Text = string.Empty;
				else if (existTextBox)
					this.ulText.Text = "テスト文字";
				else if (existLabel)
					this.ulText.Text = "印字文字";
			}
		}

		/// <summary>
		/// フォント情報更新処理
		/// </summary>
		/// <param name="upDateItemCode">更新項目(0:FontFamily,1:Size,2:Style)</param>
		/// <remarks>
		/// <br>Note		: フォント情報を更新します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void UpdateFontInfo(int upDateItemCode)
		{
			for (int ix = 0 ; ix < _selection.Count ; ix++)
			{
				Font oldFont;
				PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])["Font"];
				if (propertyInfo != null)
				{
					oldFont = (Font)propertyInfo.GetValue(_selection[ix]);

					FontFamily fontFamily	= oldFont.FontFamily;
					float fontSize			= oldFont.Size;
					FontStyle fontStyle		= oldFont.Style;
					switch (upDateItemCode)
					{
						case 0:
						{
							fontFamily = new FontFamily(this.ufnFontName.Value.ToString());
							break;
						}
						case 1:
						{
							float newFontSize = (float)TStrConv.StrToDoubleDef(this.cmbFontSize.Text, 1);
							if (newFontSize >= 1)
							{
								fontSize = newFontSize;
							}
							else
							{
								this.cmbFontSize.Value = 1;
								fontSize = 1;
							}
							break;
						}
						case 2:
						{
							if (this.uceBold.Checked && this.uceItalic.Checked && this.uceUnderLine.Checked)
								fontStyle = FontStyle.Bold | FontStyle.Italic | FontStyle.Underline;
							else if (!this.uceBold.Checked && this.uceItalic.Checked && this.uceUnderLine.Checked)
								fontStyle = FontStyle.Italic | FontStyle.Underline;
							else if (this.uceBold.Checked && !this.uceItalic.Checked && this.uceUnderLine.Checked)
								fontStyle = FontStyle.Bold | FontStyle.Underline;
							else if (this.uceBold.Checked && this.uceItalic.Checked && !this.uceUnderLine.Checked)
								fontStyle = FontStyle.Bold | FontStyle.Italic;
							else if (this.uceBold.Checked && !this.uceItalic.Checked && !this.uceUnderLine.Checked)
								fontStyle = FontStyle.Bold;
							else if (!this.uceBold.Checked && this.uceItalic.Checked && !this.uceUnderLine.Checked)
								fontStyle = FontStyle.Italic;
							else if (!this.uceBold.Checked && !this.uceItalic.Checked && this.uceUnderLine.Checked)
								fontStyle = FontStyle.Underline;
							else
								fontStyle = FontStyle.Regular;
							break;
						}
					}

					Font newFont = new Font(fontFamily, fontSize, fontStyle);

					propertyInfo.SetValue(_selection[ix], newFont);
				}
			}
		}

		/// <summary>
		/// 項目表示名称取得処理
		/// </summary>
		/// <param name="aRControl">コントロール</param>
		/// <param name="prtItemSetList">印字項目設定LIST</param>
		/// <returns>表示名称</returns>
		/// <remarks>
		/// <br>Note		: 項目の表示名称を取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private string GetItemDispName(ar.ARControl aRControl, List<PrtItemSetWork> prtItemSetList)
		{
			string dispName = string.Empty;
			
			PrtItemSetWork prtItemSet = FrePrtSettingController.GetPrtItemSet(aRControl, prtItemSetList);
			if (prtItemSet != null)
			{
				if (prtItemSet.FreePrtPaperItemCd == 1 && aRControl is ar.TextBox)
				{
					ar.TextBox textBox = (ar.TextBox)aRControl;
					if (!string.IsNullOrEmpty(textBox.DataField))
					{
						PrtItemSetWork dataFieldPrtItemSet = prtItemSetList.Find(
								delegate(PrtItemSetWork wkPrtItemSetWork)
								{
									if (FrePrtSettingController.CreateDataField(wkPrtItemSetWork) == textBox.DataField)
										return true;
									else
										return false;
								}
							);
						if (dataFieldPrtItemSet != null)
							dispName = prtItemSet.FreePrtPaperItemNm + " - " + dataFieldPrtItemSet.FreePrtPaperItemNm;
						else
							dispName = prtItemSet.FreePrtPaperItemNm;
					}
					else
					{
						dispName = prtItemSet.FreePrtPaperItemNm;
					}
				}
				else
				{
					dispName = prtItemSet.FreePrtPaperItemNm;
				}
			}
			else
			{
				if (aRControl is ar.TextBox)
					dispName = ((ar.TextBox)aRControl).Text;
				else if (aRControl is ar.Label)
					dispName = ((ar.Label)aRControl).Text;
				else
					dispName = aRControl.Name;
			}

			return dispName;
		}
		#endregion

		#region Event
		/// <summary>
		/// コントロールLeaveイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールで</br>
		/// <br>			: なくなったときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void Item_Leave(object sender, EventArgs e)
		{
			if (_isShowPropertyData) return;

			_isNowWorking = true;
			try
			{
				switch (sender.GetType().Name)
				{
					case "TEdit":
					{
						TEdit tEdit = (TEdit)sender;
						if (!_buffText.Equals(tEdit.Text) && tEdit.Tag != null && !tEdit.Tag.Equals(string.Empty))
						{
							for (int ix = 0 ; ix < _selection.Count ; ix++)
							{
								PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])[tEdit.Tag.ToString()];
								if (propertyInfo != null)
									propertyInfo.SetValue(_selection[ix], tEdit.Text);
							}
						}
						break;
					}
					case "TNedit":
					{
						TNedit tNedit = (TNedit)sender;
						double nowValue = TStrConv.StrToDoubleDef(tNedit.Text, -1);
						if (!_buffCode.Equals(nowValue) && tNedit.Tag != null && !tNedit.Tag.Equals(string.Empty))
						{
							for (int ix = 0 ; ix < _selection.Count ; ix++)
							{
								switch (tNedit.Tag.ToString())
								{
									case SFANL08105UA.ctPropName_Top:
									case SFANL08105UA.ctPropName_Left:
									case SFANL08105UA.ctPropName_Width:
									case SFANL08105UA.ctPropName_Height:
									case SFANL08105UA.ctPropName_X1:
									case SFANL08105UA.ctPropName_X2:
									case SFANL08105UA.ctPropName_Y1:
									case SFANL08105UA.ctPropName_Y2:
									{
										PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])[tNedit.Tag.ToString()];
										if (propertyInfo != null)
										{
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                                            //float inch = ar.ActiveReport3.CmToInch((float)tNedit.GetValue());
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                                            float inch = _cmInchControl.ToData( (float)tNedit.GetValue() );
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
											propertyInfo.SetValue(_selection[ix], (float)inch);
										}
										break;
									}
									case SFANL08105UA.ctPropName_LineWeight:
									{
										PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])[tNedit.Tag.ToString()];
										if (propertyInfo != null)
										{
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 DEL
                                            //float inch = ar.ActiveReport3.CmToInch((float)tNedit.GetValue());
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 DEL
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/21 ADD
                                            float inch = _cmInchControl.ToData( (float)tNedit.GetValue() );
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/21 ADD
											propertyInfo.SetValue(_selection[ix], Convert.ToInt32(inch * 144));
										}
										break;
									}
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                                    case SFANL08105UA.ctPropName_CharacterSpacing:
                                    {
                                        PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties( _selection[ix] )[tNedit.Tag.ToString()];
                                        if ( propertyInfo != null )
                                            propertyInfo.SetValue( _selection[ix], (Single)tNedit.GetValue() );
                                        break;
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
									default:
									{
										PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])[tNedit.Tag.ToString()];
										if (propertyInfo != null)
											propertyInfo.SetValue(_selection[ix], tNedit.GetInt());
										break;
									}
								}
							}
						}
						break;
					}
					case "TComboEditor":
					{
						TComboEditor tComboEditor = (TComboEditor)sender;
						double code = TStrConv.StrToDoubleDef(tComboEditor.Text, 0);
						if (!_buffCode.Equals(code) && tComboEditor.Tag != null && !tComboEditor.Tag.Equals(string.Empty))
						{
							UpdateFontInfo(1);
						}
						break;
					}
					case "UltraFontNameEditor":
					{
						UltraFontNameEditor ultraFontNameEditor = (UltraFontNameEditor)sender;
						ultraFontNameEditor.Appearance.BackColor = Color.White;
						break;
					}
					case "UltraColorPicker":
					{
						UltraColorPicker ultraColorPicker = (UltraColorPicker)sender;
						ultraColorPicker.Appearance.BackColor = Color.White;
						break;
					}
				}
			}
			finally
			{
				_isNowWorking = false;
			}
		}

		/// <summary>
		/// コントロールEnterイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールに</br>
		/// <br>			: なったときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void Item_Enter(object sender, EventArgs e)
		{
			switch (sender.GetType().Name)
			{
				case "TEdit":
				{
					TEdit tEdit = (TEdit)sender;
					_buffText = tEdit.Text;
					break;
				}
				case "TNedit":
				{
					TNedit tNedit = (TNedit)sender;
					_buffCode = TStrConv.StrToDoubleDef(tNedit.Text, -1);
					break;
				}
				case "TComboEditor":
				{
					TComboEditor tComboEditor = (TComboEditor)sender;
					_buffCode = TStrConv.StrToDoubleDef(tComboEditor.Text, 0);
					break;
				}
				case "UltraColorPicker":
				{
					UltraColorPicker ultraColorPicker = (UltraColorPicker)sender;
					ultraColorPicker.Appearance.BackColor = this.cmbSelectItem.ActiveAppearance.BackColor;
					break;
				}
				case "UltraFontNameEditor":
				{
					UltraFontNameEditor ultraFontNameEditor = (UltraFontNameEditor)sender;
					ultraFontNameEditor.Appearance.BackColor = this.cmbSelectItem.ActiveAppearance.BackColor;
					break;
				}
			}
		}

		/// <summary>
		/// ColorChangedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 色が変更された場合に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void Color_Changed(object sender, EventArgs e)
		{
			if (_isShowPropertyData) return;

			_isNowWorking = true;
			try
			{
				UltraColorPicker ultraColorPicker = (UltraColorPicker)sender;
				if (ultraColorPicker.Tag != null && !ultraColorPicker.Tag.Equals(string.Empty))
				{
					for (int ix = 0 ; ix < _selection.Count ; ix++)
					{
						PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])[ultraColorPicker.Tag.ToString()];
						if (propertyInfo != null)
							propertyInfo.SetValue(_selection[ix], ultraColorPicker.Color);
					}
				}
			}
			finally
			{
				_isNowWorking = false;
			}
		}

		/// <summary>
		/// コントロールCheckedChangedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: Checkedプロパティの値が変更された後に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void Item_CheckedChanged(object sender, EventArgs e)
		{
			if (_isShowPropertyData) return;

			_isNowWorking = true;
			try
			{
				UltraCheckEditor ultraCheckEditor = (UltraCheckEditor)sender;
				for (int ix = 0 ; ix < _selection.Count ; ix++)
				{
					switch (ultraCheckEditor.Tag.ToString())
					{
						case SFANL08105UA.ctPropName_Bold:
						case SFANL08105UA.ctPropName_Italic:
						case SFANL08105UA.ctPropName_UnderLine:
						{
							UpdateFontInfo(2);
							break;
						}
						default:
						{
							PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])[ultraCheckEditor.Tag.ToString()];
							if (propertyInfo != null)
								propertyInfo.SetValue(_selection[ix], ultraCheckEditor.Checked);
							break;
						}
					}
				}
			}
			finally
			{
				_isNowWorking = false;
			}
		}

		/// <summary>
		/// コントロールSelectionChangeCommittedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 選択が変更された後に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void Item_ValueChanged(object sender, EventArgs e)
		{
			if (_isShowPropertyData) return;

			_isNowWorking = true;
			try
			{
				switch (sender.GetType().Name)
				{
					case "TComboEditor":
					{
						if (sender == this.cmbFontSize)
						{
							UpdateFontInfo(1);
						}
						else if (sender == this.cmbPrintPageCtrlDivCd ||
							sender == this.cmbGroupSuppressCd ||
							sender == this.cmbDtlColorChangeCd || 
							sender == this.cmbHeightAdjustDivCd)
						{
							ar.ARControl aRControl = _selection[0] as ar.ARControl;
							if (aRControl != null)
							{
								int printPageCtrlDivCd	= 0;
								int groupSuppressCd		= 0;
								int dtlColorChangeCd	= 0;
								int heightAdjustDivCd	= 0;
								if (this.cmbPrintPageCtrlDivCd.Value != null)
									int.TryParse(this.cmbPrintPageCtrlDivCd.Value.ToString(), out printPageCtrlDivCd);
								if (this.cmbGroupSuppressCd.Value != null)
									int.TryParse(this.cmbGroupSuppressCd.Value.ToString(), out groupSuppressCd);
								if (this.cmbDtlColorChangeCd.Value != null)
									int.TryParse(this.cmbDtlColorChangeCd.Value.ToString(), out dtlColorChangeCd);
								if (this.cmbHeightAdjustDivCd.Value != null)
									int.TryParse(this.cmbHeightAdjustDivCd.Value.ToString(), out heightAdjustDivCd);

								PrtItemSetWork prtItemSet = FrePrtSettingController.GetPrtItemSet(aRControl, _prtItemSetList);
								if (prtItemSet != null)
								{
									prtItemSet.PrintPageCtrlDivCd	= printPageCtrlDivCd;
									prtItemSet.GroupSuppressCd		= groupSuppressCd;
									prtItemSet.DtlColorChangeCd		= dtlColorChangeCd;
									prtItemSet.HeightAdjustDivCd	= heightAdjustDivCd;
									aRControl.Tag = FrePrtSettingController.GetARControlTagInfo(prtItemSet);

                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                                    // 伝票で印字ページ区分を変更した時のみ、
                                    // 同一のDataFieldの項目の印字ページ区分も更新する。
                                    if ( _frePrtPSet.PrintPaperUseDivcd == 2 && sender == this.cmbPrintPageCtrlDivCd )
                                    {
                                        foreach ( ar.Section section in _report.Sections )
                                        {
                                            foreach ( ar.ARControl control in section.Controls )
                                            {
                                                if ( control.DataField == aRControl.DataField && control != aRControl )
                                                {
                                                    PrtItemSetWork wkPrtItemSet = FrePrtSettingController.GetPrtItemSet( control, _prtItemSetList );
                                                    if ( wkPrtItemSet != null )
                                                    {
                                                        // 印字ページ区分を更新
                                                        wkPrtItemSet.PrintPageCtrlDivCd = printPageCtrlDivCd;
                                                        control.Tag = FrePrtSettingController.GetARControlTagInfo( wkPrtItemSet );
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
								}
							}
						}
						else
						{
							TComboEditor tComboEditor = (TComboEditor)sender;
							for (int ix = 0 ; ix < _selection.Count ; ix++)
							{
								PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])[tComboEditor.Tag.ToString()];
								if (propertyInfo != null)
									propertyInfo.SetValue(_selection[ix], tComboEditor.Value);
							}
						}
						break;
					}
					case "UltraFontNameEditor":
					{
						UpdateFontInfo(0);
						break;
					}
				}
			}
			finally
			{
				_isNowWorking = false;
			}
		}

		/// <summary>
		/// 画像ボタンClickイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 画像ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ubImage_Click(object sender, EventArgs e)
		{
			_isNowWorking = true;
			try
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
					for (int ix = 0 ; ix < _selection.Count ; ix++)
					{
						if (_selection[ix] is ar.Picture)
						{
							ar.Picture picture = (ar.Picture)_selection[ix];
							picture.Image = bitmap;
						}
					}
					image.Dispose();
				}
			}
			finally
			{
				_isNowWorking = false;
			}
		}

		/// <summary>
		/// 画像クリアボタンClickイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 画像クリアボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ubImageClear_Click(object sender, EventArgs e)
		{
			_isNowWorking = true;
			try
			{
				for (int ix = 0 ; ix < _selection.Count ; ix++)
				{
					if (_selection[ix] is ar.Picture)
					{
						ar.Picture picture = (ar.Picture)_selection[ix];
						picture.ResetImage();
					}
				}
			}
			finally
			{
				_isNowWorking = false;
			}
		}

		/// <summary>
		/// 選択項目コンボボックスSelectionChangeCommittedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 選択が変更された後に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void cmbSelectItem_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this.cmbSelectItem.Value != null && !_isShowPropertyData)
				SelectedARControlNameChanged(this.cmbSelectItem.Value.ToString());
		}

		/// <summary>
		/// KeyPressイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォーカスを持っていて、</br>
		/// <br>			: ユーザーがキーを押して離したときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void cmbFontSize_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!SFANL08105UH.KeyPressCheck(this.cmbFontSize.MaxLength, 2, this.cmbFontSize.Text, e.KeyChar, this.cmbFontSize.SelectionStart, this.cmbFontSize.SelectionLength, false))
				e.Handled = true;
		}

		/// <summary>
		/// ValueChangedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールの値が変更された場合に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void TEdit_ValueChanged(object sender, EventArgs e)
		{
			if (_isShowPropertyData) return;

			TEdit tEdit = (TEdit)sender;
			if (tEdit.Tag != null && !tEdit.Tag.Equals(string.Empty))
			{
				for (int ix = 0 ; ix < _selection.Count ; ix++)
				{
					PropertyDescriptor propertyInfo = TypeDescriptor.GetProperties(_selection[ix])[tEdit.Tag.ToString()];
					if (propertyInfo != null)
						propertyInfo.SetValue(_selection[ix], tEdit.Text);
				}
			}
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
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			switch (e.Key)
			{
				case Keys.Enter:
				{
					if (!this.Contains(e.NextCtrl))
						e.NextCtrl = this.cmbSelectItem;
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

			if (e.PrevCtrl == this.tedText && this.tedText.IsInEditMode)
			{
				// 選択文字がある場合は入力キーに応じてカーソル位置を変化させる
				if (this.tedText.SelectionLength > 0)
				{
                    if (e.Key == Keys.Up)
                    {
                        this.tedText.Select(this.tedText.SelectionStart, 0);
                        e.NextCtrl = null;
                        this.tedText.ScrollToCaret();
                    }
                    else if (e.Key == Keys.Down)
                    {
                        this.tedText.Select(this.tedText.SelectionStart + this.tedText.SelectionLength, 0);
                        e.NextCtrl = null;
                        this.tedText.ScrollToCaret();
                    }
				}
			}
		}

		/// <summary>
		/// DataFieldボタンClickイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: DataFieldボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ubDataField_Click(object sender, EventArgs e)
		{
			if (_prtItemSetList != null && _prtItemSetList.Count > 0)
			{
				if (_prtItemGrpAcs == null)
					_prtItemGrpAcs = new PrtItemGrpAcs();

				int freePrtPprItemGrpCd	= _prtItemSetList[0].FreePrtPprItemGrpCd;
				int totalItemDivCd		= 0;
				int formFeedItemDivCd	= 0;

				if (_selection[0] is ar.ARControl)
					totalItemDivCd		= 1;
				if (_selection[0] is ar.Section)
					formFeedItemDivCd	= 1;

				PrtItemSetWork prtItemSetWork;
				DialogResult dlgRet = _prtItemGrpAcs.ExecuteGuide(freePrtPprItemGrpCd, totalItemDivCd, formFeedItemDivCd, _prtItemSetList, out prtItemSetWork);
				if (dlgRet == DialogResult.OK)
				{
					this.cmbDataField.Value = FrePrtSettingController.CreateDataField(prtItemSetWork);
					if (this.cmbSelectItem.SelectedIndex >= 0 && _selection[0] is ar.ARControl)
					{
						ar.ARControl aRControl = (ar.ARControl)_selection[0];
						this.cmbSelectItem.SelectedItem.DisplayText = GetItemDispName(aRControl, _prtItemSetList);
						this.cmbSelectItem.Refresh();
					}
				}
			}
		}

		/// <summary>
		/// DataFieldクリアボタンClickイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: DataFieldクリアボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ubDataFieldClear_Click(object sender, EventArgs e)
		{
			this.cmbDataField.Value = 0;
			if (this.cmbSelectItem.SelectedIndex >= 0 && _selection[0] is ar.ARControl)
			{
				ar.ARControl aRControl = (ar.ARControl)_selection[0];
				this.cmbSelectItem.SelectedItem.DisplayText = GetItemDispName(aRControl, _prtItemSetList);
				this.cmbSelectItem.Refresh();
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
		private void TComboEditor_MouseEnterElement(object sender, UIElementEventArgs e)
		{
			object objContextRow = e.Element.GetContext(typeof(TComboEditor));
			if (objContextRow != null)
			{
				TComboEditor tComboEditor = objContextRow as TComboEditor;

				int strWidth = FrePrtSettingController.GetStringWidth(tComboEditor);
				if (tComboEditor.ReadOnly && !tComboEditor.Text.Trim().Equals(string.Empty) && strWidth > tComboEditor.Width)
				{
					UltraToolTipInfo ultraToolTipInfo = new UltraToolTipInfo();
					ultraToolTipInfo.ToolTipText	= tComboEditor.Text;

					this.ultraToolTipManager.SetUltraToolTip(tComboEditor, ultraToolTipInfo);
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
		private void TComboEditor_MouseLeaveElement(object sender, UIElementEventArgs e)
		{
			// ツールチップを非表示にする
			this.ultraToolTipManager.HideToolTip();
			this.ultraToolTipManager.Enabled = false;
		}

		/// <summary>
		/// 集計タイプコンボボックスSelectionChangedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 選択が変更された場合に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void cmbSummaryType_SelectionChanged(object sender, EventArgs e)
		{
			switch ((ar.SummaryType)this.cmbSummaryType.Value)
			{
				case ar.SummaryType.SubTotal:
				{
					this.cmbSummaryGroup.Enabled = true;
					break;
				}
				default:
				{
					this.cmbSummaryGroup.Enabled = false;
					break;
				}
			}
		}
		#endregion
	}
}