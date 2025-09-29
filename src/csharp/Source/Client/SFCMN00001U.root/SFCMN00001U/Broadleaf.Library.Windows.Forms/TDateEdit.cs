//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   画面ＵＩ部品(TDateEdit)                         //
// Name Space       :   Broadleaf.Library.Windows.Forms					//
// Programer        :                                                   //
// Date             :                                                   //
//----------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号  11470076-00    作成担当：陳艶丹
// 修正日    2019/01/25     修正内容：新元号の追加対応
// ---------------------------------------------------------------------//
using Broadleaf.Library.Globarization;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Collections;// ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応
namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// 画面ＵＩ部品(TDateEdit)  
    /// </summary>
    /// <remarks>
    /// <br>Update Note: 2019/01/25 陳艶丹</br>	
    /// <br>管理番号   ：11470076-00</br>	 
    /// <br>             新元号の追加対応</br>
    /// </remarks>
	[ToolboxBitmap(typeof(TDateEdit), "TDateEdit.bmp")]
	public class TDateEdit : Panel
	{
		public const int ctYearDef = 19000000;
		public const int ctMonthDayDef = 101;
		private TNedit YearEdit;
		private TNedit MonthEdit;
		private TNedit DayEdit;
		protected TComboEditor JpGenCombo2;
		private MonthCalendar Calendar;
		private UltraLabel YearLabel;
		private UltraLabel MonthLabel;
		private UltraLabel DayLabel;
		private UltraDropDownButton CalendarBtn;
		private UltraPopupControlContainer CalenderContainer;
		private IContainer components;
		private emDateFormat prDateFormat;
		private emDateSequence prDateSequence;
		private emInitFocus prInitFocus;
		private int prLongDate;
		private TExtCase FExtCase = new TExtCase();
		private bool dntSetDspFg;
		private bool dntChgEditFg;
		private int FJpnYearCol = 4;
		private int FYearCol = 2;
		private int FMonthCol = 2;
		private int FDayCol = 2;
		private TEnableEditors FEnableEditors;
		private TNecessaryEditors FNecessaryEditors;
		private TDateEditOptions FOptions;
		private Control FCurCtrl;
		private bool FReadOnly;
        // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 ----->>>>>
        /// <summary>
        /// 初期フォーカス元号。日付コンポーネントにフォーカスが当たった際の元号を保持します。
        /// </summary>
        private string defaultFocusGengo = string.Empty;

        /// <summary>
        /// DateFormatプロパティ設定用XMLをチェックしたか否か
        /// </summary>
        private bool HasCheckedDateFormatFromXml = false;

        /// <summary>
        /// DateFormatプロパティをXMLから設定したか否か
        /// </summary>
        private bool isSetDateFormatFromXml = false;
        // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 -----<<<<<

        [Description("LongDateプロパティの値が変更された場合に発生します。")]
        public event EventHandler ValueChanged;
        [Description("年入力エディットのTextプロパティの値がControlで変更されたときに発生するイベントです。")]
        public event EventHandler TextChangedYearEdit;
        [Description("月入力エディットのTextプロパティの値がControlで変更されたときに発生するイベントです。")]
        public event EventHandler TextChangedMonthEdit;
        [Description("日入力エディットのTextプロパティの値がControlで変更されたときに発生するイベントです。")]
        public event EventHandler TextChangedDayEdit;
        [Description("年入力エディットでキー押下された場合に発生します。")]
        public event KeyEventHandler KeyDownYearEdit;
        [Description("月入力エディットでキー押下された場合に発生します。")]
        public event KeyEventHandler KeyDownMonthEdit;
        [Description("日入力エディットでキー押下された場合に発生します。")]
        public event KeyEventHandler KeyDownDayEdit;
		[DefaultValue(false)]
		public bool ReadOnly
		{
			get
			{
				return this.FReadOnly;
			}
			set
			{
				if (this.FReadOnly != value)
				{
					this.FReadOnly = value;
					this.JpGenCombo2.ReadOnly = value;
					this.YearEdit.ReadOnly = value;
					this.MonthEdit.ReadOnly = value;
					this.DayEdit.ReadOnly = value;
					this.CalendarBtn.Enabled = (!this.FReadOnly && base.Enabled);
					this.MoveChildControl();
				}
			}
		}
		[Category("Behavior"), Description("入力可/不可を項目単位に設定、取得を行います"), TypeConverter(typeof(TEnableEditors.TEnableEditorsConverter))]
		public TEnableEditors EnableEditors
		{
			get
			{
				return this.FEnableEditors;
			}
			set
			{
				this.FEnableEditors = value;
				this.JpGenCombo2.Enabled = this.FEnableEditors.deeJpn;
				this.YearEdit.Enabled = this.FEnableEditors.deeYear;
				this.MonthEdit.Enabled = this.FEnableEditors.deeMonth;
				this.DayEdit.Enabled = this.FEnableEditors.deeDay;
			}
		}
		[Category("Behavior"), Description("必須入力項目を項目単位に設定、取得を行います"), TypeConverter(typeof(TNecessaryEditors.TNecessaryEditorsConverter))]
		public TNecessaryEditors NecessaryEditors
		{
			get
			{
				return this.FNecessaryEditors;
			}
			set
			{
				this.FNecessaryEditors = value;
			}
		}
		[Category("Behavior"), Description("オプション項目の設定、取得を行います"), TypeConverter(typeof(TDateEditOptions.TDateEditOptionsConverter))]
		public TDateEditOptions Options
		{
			get
			{
				return this.FOptions;
			}
			set
			{
				this.FOptions = value;
			}
		}
		[Category("Behavior"), DefaultValue(4), Description("元号領域の桁数を指定します")]
		public int JpnYearCol
		{
			get
			{
				return this.FJpnYearCol;
			}
			set
			{
				if (this.FJpnYearCol != value)
				{
					this.FJpnYearCol = value;
				}
			}
		}
		[Category("Appearance"), Description("ラベルの外観を指定します"), TypeConverter(typeof(Infragistics.Win.Appearance.AppearanceTypeConverter))]
		public AppearanceBase LabelAppearance
		{
			get
			{
				return this.YearLabel.Appearance;
			}
			set
			{
				this.YearLabel.Appearance = value;
				this.MonthLabel.Appearance = value;
				this.DayLabel.Appearance = value;
			}
		}
		[Category("Appearance"), Description("エディット部分の外観を指定します"), TypeConverter(typeof(Infragistics.Win.Appearance.AppearanceTypeConverter))]
		public AppearanceBase EditAppearance
		{
			get
			{
				return this.YearEdit.Appearance;
			}
			set
			{
				this.JpGenCombo2.Appearance = value;
				this.YearEdit.Appearance = value;
				this.MonthEdit.Appearance = value;
				this.DayEdit.Appearance = value;
			}
		}
		[Category("Appearance"), Description("アクティブ時の外観を指定します(エディット部)"), TypeConverter(typeof(Infragistics.Win.Appearance.AppearanceTypeConverter))]
		public AppearanceBase ActiveEditAppearance
		{
			get
			{
				return this.YearEdit.ActiveAppearance;
			}
			set
			{
				this.JpGenCombo2.ActiveAppearance = value;
				this.YearEdit.ActiveAppearance = value;
				this.MonthEdit.ActiveAppearance = value;
				this.DayEdit.ActiveAppearance = value;
			}
		}
		[Category("Layout"), DefaultValue("年"), Description("年部分の表示文字の設定、取得を行います")]
		public string LabelYear
		{
			get
			{
				return this.YearLabel.Text;
			}
			set
			{
				this.YearLabel.Text = value;
			}
		}
		[Category("Layout"), DefaultValue("月"), Description("月部分の表示文字の設定、取得を行います")]
		public string LabelMonth
		{
			get
			{
				return this.MonthLabel.Text;
			}
			set
			{
				this.MonthLabel.Text = value;
			}
		}
		[Category("Layout"), DefaultValue("日"), Description("日部分の表示文字の設定、取得を行います")]
		public string LabelDay
		{
			get
			{
				return this.DayLabel.Text;
			}
			set
			{
				this.DayLabel.Text = value;
			}
		}
		[Category("Behavior"), Description("エディットから脱出可能なキーの取得、設定を行います。"), TypeConverter(typeof(TExtCase.TExtCaseConverter))]
		public TExtCase ExtCase
		{
			get
			{
				return this.FExtCase;
			}
			set
			{
				this.FExtCase = value;
			}
		}
		[Category("Behavior"), Description("カレンダー表示機能の設定、取得を行います。")]
		public bool CalendarDisp
		{
			get
			{
				return this.CalendarBtn.Visible;
			}
			set
			{
				this.CalendarBtn.Visible = value;
				this.MoveChildControl();
				base.Invalidate();
			}
		}
		[Category("Appearance"), DefaultValue(emDateFormat.df4Y2M2D), Description("入力書式を指定します")]
		public emDateFormat DateFormat
		{
			get
			{
				return this.prDateFormat;
			}
			set
			{
                // ----- UPD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 ----->>>>>
                //if (this.prDateFormat != value)
                if (!this.isSetDateFormatFromXml && this.prDateFormat != value)
                // ----- UPD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 -----<<<<<
				{
					this.prDateFormat = value;
					switch (this.prDateFormat)
					{
					case emDateFormat.df4Y2M2D:
						this.JpGenCombo2.Visible = false;
						this.YearEdit.Visible = true;
						this.YearLabel.Visible = this.YearEdit.Visible;
						this.MonthEdit.Visible = true;
						this.MonthLabel.Visible = this.MonthEdit.Visible;
						this.DayEdit.Visible = true;
						this.DayLabel.Visible = this.DayEdit.Visible;
						this.YearEdit.ExtEdit.Column = (this.FYearCol = 4);
						this.MonthEdit.ExtEdit.Column = (this.FMonthCol = 2);
						this.DayEdit.ExtEdit.Column = (this.FDayCol = 2);
						break;
					case emDateFormat.df2Y2M2D:
						this.JpGenCombo2.Visible = false;
						this.YearEdit.Visible = true;
						this.YearLabel.Visible = this.YearEdit.Visible;
						this.MonthEdit.Visible = true;
						this.MonthLabel.Visible = this.MonthEdit.Visible;
						this.DayEdit.Visible = true;
						this.DayLabel.Visible = this.DayEdit.Visible;
						this.YearEdit.ExtEdit.Column = (this.FYearCol = 2);
						this.MonthEdit.ExtEdit.Column = (this.FMonthCol = 2);
						this.DayEdit.ExtEdit.Column = (this.FDayCol = 2);
						break;
					case emDateFormat.dfG2Y2M2D:
						this.JpGenCombo2.Visible = true;
						this.YearEdit.Visible = true;
						this.YearLabel.Visible = this.YearEdit.Visible;
						this.MonthEdit.Visible = true;
						this.MonthLabel.Visible = this.MonthEdit.Visible;
						this.DayEdit.Visible = true;
						this.DayLabel.Visible = this.DayEdit.Visible;
						this.YearEdit.ExtEdit.Column = (this.FYearCol = 2);
						this.MonthEdit.ExtEdit.Column = (this.FMonthCol = 2);
						this.DayEdit.ExtEdit.Column = (this.FDayCol = 2);
						break;
					case emDateFormat.df4Y2M:
						this.JpGenCombo2.Visible = false;
						this.YearEdit.Visible = true;
						this.YearLabel.Visible = this.YearEdit.Visible;
						this.MonthEdit.Visible = true;
						this.MonthLabel.Visible = this.MonthEdit.Visible;
						this.DayEdit.Visible = false;
						this.DayLabel.Visible = this.DayEdit.Visible;
						this.YearEdit.ExtEdit.Column = (this.FYearCol = 4);
						this.MonthEdit.ExtEdit.Column = (this.FMonthCol = 2);
						this.DayEdit.ExtEdit.Column = (this.FDayCol = 2);
						break;
					case emDateFormat.df2Y2M:
						this.JpGenCombo2.Visible = false;
						this.YearEdit.Visible = true;
						this.YearLabel.Visible = this.YearEdit.Visible;
						this.MonthEdit.Visible = true;
						this.MonthLabel.Visible = this.MonthEdit.Visible;
						this.DayEdit.Visible = false;
						this.DayLabel.Visible = this.DayEdit.Visible;
						this.YearEdit.ExtEdit.Column = (this.FYearCol = 2);
						this.MonthEdit.ExtEdit.Column = (this.FMonthCol = 2);
						this.DayEdit.ExtEdit.Column = (this.FDayCol = 2);
						break;
					case emDateFormat.dfG2Y2M:
						this.JpGenCombo2.Visible = true;
						this.YearEdit.Visible = true;
						this.YearLabel.Visible = this.YearEdit.Visible;
						this.MonthEdit.Visible = true;
						this.MonthLabel.Visible = this.MonthEdit.Visible;
						this.DayEdit.Visible = false;
						this.DayLabel.Visible = this.DayEdit.Visible;
						this.YearEdit.ExtEdit.Column = (this.FYearCol = 2);
						this.MonthEdit.ExtEdit.Column = (this.FMonthCol = 2);
						this.DayEdit.ExtEdit.Column = (this.FDayCol = 2);
						break;
					case emDateFormat.df2M2D:
						this.JpGenCombo2.Visible = false;
						this.YearEdit.Visible = false;
						this.YearLabel.Visible = this.YearEdit.Visible;
						this.MonthEdit.Visible = true;
						this.MonthLabel.Visible = this.MonthEdit.Visible;
						this.DayEdit.Visible = true;
						this.DayLabel.Visible = this.DayEdit.Visible;
						this.YearEdit.ExtEdit.Column = (this.FYearCol = 4);
						this.MonthEdit.ExtEdit.Column = (this.FMonthCol = 2);
						this.DayEdit.ExtEdit.Column = (this.FDayCol = 2);
						break;
					case emDateFormat.df4Y:
						this.JpGenCombo2.Visible = false;
						this.YearEdit.Visible = true;
						this.YearLabel.Visible = this.YearEdit.Visible;
						this.MonthEdit.Visible = false;
						this.MonthLabel.Visible = this.MonthEdit.Visible;
						this.DayEdit.Visible = false;
						this.DayLabel.Visible = this.DayEdit.Visible;
						this.YearEdit.ExtEdit.Column = (this.FYearCol = 4);
						this.MonthEdit.ExtEdit.Column = (this.FMonthCol = 2);
						this.DayEdit.ExtEdit.Column = (this.FDayCol = 2);
						break;
					case emDateFormat.df2Y:
						this.JpGenCombo2.Visible = false;
						this.YearEdit.Visible = true;
						this.YearLabel.Visible = this.YearEdit.Visible;
						this.MonthEdit.Visible = false;
						this.MonthLabel.Visible = this.MonthEdit.Visible;
						this.DayEdit.Visible = false;
						this.DayLabel.Visible = this.DayEdit.Visible;
						this.YearEdit.ExtEdit.Column = (this.FYearCol = 2);
						this.MonthEdit.ExtEdit.Column = (this.FMonthCol = 2);
						this.DayEdit.ExtEdit.Column = (this.FDayCol = 2);
						break;
					case emDateFormat.dfG2Y:
						this.JpGenCombo2.Visible = true;
						this.YearEdit.Visible = true;
						this.YearLabel.Visible = this.YearEdit.Visible;
						this.MonthEdit.Visible = false;
						this.MonthLabel.Visible = this.MonthEdit.Visible;
						this.DayEdit.Visible = false;
						this.DayLabel.Visible = this.DayEdit.Visible;
						this.YearEdit.ExtEdit.Column = (this.FYearCol = 2);
						this.MonthEdit.ExtEdit.Column = (this.FMonthCol = 2);
						this.DayEdit.ExtEdit.Column = (this.FDayCol = 2);
						break;
					case emDateFormat.df2M:
						this.JpGenCombo2.Visible = false;
						this.YearEdit.Visible = false;
						this.YearLabel.Visible = this.YearEdit.Visible;
						this.MonthEdit.Visible = true;
						this.MonthLabel.Visible = this.MonthEdit.Visible;
						this.DayEdit.Visible = false;
						this.DayLabel.Visible = this.DayEdit.Visible;
						this.YearEdit.ExtEdit.Column = (this.FYearCol = 4);
						this.MonthEdit.ExtEdit.Column = (this.FMonthCol = 2);
						this.DayEdit.ExtEdit.Column = (this.FDayCol = 2);
						break;
					case emDateFormat.df2D:
						this.JpGenCombo2.Visible = false;
						this.YearEdit.Visible = false;
						this.YearLabel.Visible = this.YearEdit.Visible;
						this.MonthEdit.Visible = false;
						this.MonthLabel.Visible = this.MonthEdit.Visible;
						this.DayEdit.Visible = true;
						this.DayLabel.Visible = this.DayEdit.Visible;
						this.YearEdit.ExtEdit.Column = (this.FYearCol = 4);
						this.MonthEdit.ExtEdit.Column = (this.FMonthCol = 2);
						this.DayEdit.ExtEdit.Column = (this.FDayCol = 2);
						break;
					}
					this.MoveChildControl();
					base.Invalidate();
				}
			}
		}
		[Category("Appearance"), DefaultValue(emDateSequence.dsYMD), Description("入力項目の並び順を指定します")]
		public emDateSequence DateSequence
		{
			get
			{
				return this.prDateSequence;
			}
			set
			{
				if (this.prDateSequence != value)
				{
					this.prDateSequence = value;
					this.MoveChildControl();
					base.Invalidate();
				}
			}
		}
		[Category("Appearance"), DefaultValue(emInitFocus.difNone), Description("入力項目の並び順を指定します")]
		public emInitFocus InitFocus
		{
			get
			{
				return this.prInitFocus;
			}
			set
			{
				if (this.prInitFocus != value)
				{
					this.prInitFocus = value;
				}
			}
		}
		[Category("Data"), DefaultValue(0), Description("YYYYMMDD形式の日付データを保持")]
		public int LongDate
		{
			get
			{
				return this.prLongDate;
			}
			set
			{
				if (this.prLongDate != value)
				{
					this.SetLongDate(value);
				}
			}
		}
		[DefaultValue(ImeMode.Disable)]
		public new ImeMode ImeMode
		{
			get
			{
				return base.ImeMode;
			}
			set
			{
				base.ImeMode = value;
			}
		}
		public TDateEdit()
		{
			this.InitializeComponent();
            // 元号コンボボックスの初期設定
            SetGengouMode(TDateTimeGengouMode.Default);// ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応
			this.Calendar.Visible = true;
			this.Calendar.Visible = false;
			this.JpGenCombo2.GotFocus += new EventHandler(this.JpGenCombo2_GotFocus);
			this.YearEdit.KeyDown += new KeyEventHandler(this.YearEdit_KeyDown);
			this.MonthEdit.KeyDown += new KeyEventHandler(this.MonthEdit_KeyDown);
			this.DayEdit.KeyDown += new KeyEventHandler(this.DayEdit_KeyDown);
			emDateFormat dateFormat = this.DateFormat;
			this.DateFormat = emDateFormat.df2Y2M;
			this.DateFormat = dateFormat;
			this.FEnableEditors = new TEnableEditors();
			this.FNecessaryEditors = new TNecessaryEditors();
			this.FOptions = new TDateEditOptions();
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 ----->>>>>
            // デフォルト元号を最新元号で設定
            ArrayList eraList = null;
            TDateTime.GetGengouList(out eraList);

            if (eraList.Count != 0)
            {
                defaultFocusGengo = eraList[0].ToString();
            }
            // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 -----<<<<<
			this.MoveChildControl();
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance activeAppearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance activeAppearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance activeAppearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance activeAppearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.YearEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.MonthEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.DayEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CalendarBtn = new Infragistics.Win.Misc.UltraDropDownButton();
            this.CalenderContainer = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.Calendar = new System.Windows.Forms.MonthCalendar();
            this.JpGenCombo2 = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.YearLabel = new Infragistics.Win.Misc.UltraLabel();
            this.MonthLabel = new Infragistics.Win.Misc.UltraLabel();
            this.DayLabel = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.YearEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DayEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JpGenCombo2)).BeginInit();
            this.SuspendLayout();
            // 
            // YearEdit
            // 
            this.YearEdit.ActiveAppearance = activeAppearance;
            appearance.TextHAlignAsString = "Left";
            appearance.TextVAlignAsString = "Middle";
            this.YearEdit.Appearance = appearance;
            this.YearEdit.AutoSelect = true;
            this.YearEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.YearEdit.DataText = "";
            this.YearEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.YearEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.YearEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.YearEdit.Location = new System.Drawing.Point(17, 17);
            this.YearEdit.MaxLength = 1;
            this.YearEdit.Name = "YearEdit";
            this.YearEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.YearEdit.Size = new System.Drawing.Size(20, 21);
            this.YearEdit.TabIndex = 11;
            this.YearEdit.WordWrap = false;
            this.YearEdit.TextChanged += new System.EventHandler(this.YearEdit_TextChanged);
            this.YearEdit.SizeChanged += new System.EventHandler(this.JpGenCombo_SizeChanged);
            this.YearEdit.Enter += new System.EventHandler(this.JpGenCombo2_Enter);
            this.YearEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JpGenCombo2_KeyDown);
            // 
            // MonthEdit
            // 
            this.MonthEdit.ActiveAppearance = activeAppearance2;
            this.MonthEdit.AutoSelect = true;
            this.MonthEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.MonthEdit.DataText = "";
            this.MonthEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MonthEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.MonthEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MonthEdit.Location = new System.Drawing.Point(239, 17);
            this.MonthEdit.MaxLength = 1;
            this.MonthEdit.Name = "MonthEdit";
            this.MonthEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.MonthEdit.Size = new System.Drawing.Size(20, 21);
            this.MonthEdit.TabIndex = 14;
            this.MonthEdit.WordWrap = false;
            this.MonthEdit.TextChanged += new System.EventHandler(this.YearEdit_TextChanged);
            this.MonthEdit.SizeChanged += new System.EventHandler(this.JpGenCombo_SizeChanged);
            this.MonthEdit.Enter += new System.EventHandler(this.JpGenCombo2_Enter);
            this.MonthEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JpGenCombo2_KeyDown);
            // 
            // DayEdit
            // 
            this.DayEdit.ActiveAppearance = activeAppearance3;
            this.DayEdit.AutoSelect = true;
            this.DayEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.DayEdit.DataText = "";
            this.DayEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DayEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.DayEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DayEdit.Location = new System.Drawing.Point(343, 17);
            this.DayEdit.MaxLength = 1;
            this.DayEdit.Name = "DayEdit";
            this.DayEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.DayEdit.Size = new System.Drawing.Size(20, 21);
            this.DayEdit.TabIndex = 15;
            this.DayEdit.WordWrap = false;
            this.DayEdit.TextChanged += new System.EventHandler(this.YearEdit_TextChanged);
            this.DayEdit.SizeChanged += new System.EventHandler(this.JpGenCombo_SizeChanged);
            this.DayEdit.Enter += new System.EventHandler(this.JpGenCombo2_Enter);
            this.DayEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JpGenCombo2_KeyDown);
            // 
            // CalendarBtn
            // 
            this.CalendarBtn.BackColorInternal = System.Drawing.SystemColors.Control;
            this.CalendarBtn.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsXPCommandButton;
            this.CalendarBtn.Location = new System.Drawing.Point(434, 17);
            this.CalendarBtn.Name = "CalendarBtn";
            this.CalendarBtn.PopupItemKey = "Calendar";
            this.CalendarBtn.PopupItemProvider = this.CalenderContainer;
            this.CalendarBtn.Size = new System.Drawing.Size(13, 24);
            this.CalendarBtn.TabIndex = 18;
            this.CalendarBtn.TabStop = false;
            this.CalendarBtn.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.CalendarBtn.DroppingDown += new System.ComponentModel.CancelEventHandler(this.CalendarBtn_DroppingDown);
            // 
            // CalenderContainer
            // 
            this.CalenderContainer.PopupControl = this.Calendar;
            // 
            // Calendar
            // 
            this.Calendar.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Calendar.Location = new System.Drawing.Point(549, 17);
            this.Calendar.MaxSelectionCount = 1;
            this.Calendar.Name = "Calendar";
            this.Calendar.TabIndex = 20;
            this.Calendar.Visible = false;
            this.Calendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.Calendar_DateSelected);
            this.Calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Calendar_DateChanged);
            this.Calendar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Calendar_KeyDown);
            // 
            // JpGenCombo2
            // 
            this.JpGenCombo2.ActiveAppearance = activeAppearance4;
            this.JpGenCombo2.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.JpGenCombo2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.JpGenCombo2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.JpGenCombo2.Location = new System.Drawing.Point(112, 17);
            this.JpGenCombo2.Name = "JpGenCombo2";
            this.JpGenCombo2.Size = new System.Drawing.Size(36, 21);
            this.JpGenCombo2.TabIndex = 19;
            this.JpGenCombo2.TextChanged += new System.EventHandler(this.YearEdit_TextChanged);
            this.JpGenCombo2.SizeChanged += new System.EventHandler(this.JpGenCombo_SizeChanged);
            this.JpGenCombo2.Enter += new System.EventHandler(this.JpGenCombo2_Enter);
            this.JpGenCombo2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JpGenCombo2_KeyDown);
            // 
            // YearLabel
            // 
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.YearLabel.Appearance = appearance2;
            this.YearLabel.AutoSize = true;
            this.YearLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.YearLabel.Location = new System.Drawing.Point(263, 54);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(17, 14);
            this.YearLabel.TabIndex = 21;
            this.YearLabel.Text = "年";
            this.YearLabel.SizeChanged += new System.EventHandler(this.JpGenCombo_SizeChanged);
            // 
            // MonthLabel
            // 
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.MonthLabel.Appearance = appearance3;
            this.MonthLabel.AutoSize = true;
            this.MonthLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.MonthLabel.Location = new System.Drawing.Point(646, 17);
            this.MonthLabel.Name = "MonthLabel";
            this.MonthLabel.Size = new System.Drawing.Size(17, 14);
            this.MonthLabel.TabIndex = 22;
            this.MonthLabel.Text = "月";
            this.MonthLabel.SizeChanged += new System.EventHandler(this.JpGenCombo_SizeChanged);
            // 
            // DayLabel
            // 
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.DayLabel.Appearance = appearance4;
            this.DayLabel.AutoSize = true;
            this.DayLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.DayLabel.Location = new System.Drawing.Point(164, 54);
            this.DayLabel.Name = "DayLabel";
            this.DayLabel.Size = new System.Drawing.Size(17, 14);
            this.DayLabel.TabIndex = 23;
            this.DayLabel.Text = "日";
            this.DayLabel.SizeChanged += new System.EventHandler(this.JpGenCombo_SizeChanged);
            // 
            // TDateEdit
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Calendar);
            this.Controls.Add(this.JpGenCombo2);
            this.Controls.Add(this.CalendarBtn);
            this.Controls.Add(this.DayEdit);
            this.Controls.Add(this.MonthEdit);
            this.Controls.Add(this.YearEdit);
            this.Controls.Add(this.DayLabel);
            this.Controls.Add(this.MonthLabel);
            this.Controls.Add(this.YearLabel);
            this.Size = new System.Drawing.Size(340, 188);
            this.TabStop = true;
            ((System.ComponentModel.ISupportInitialize)(this.YearEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DayEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JpGenCombo2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			this.CalendarBtn.Enabled = (!this.FReadOnly && base.Enabled);
			this.MoveChildControl();
		}
		private bool CheckExitCase(Keys keycode, stSHIFTSTAT shiftstat)
		{
			if (this.FExtCase.Necessary && this.IsDataEmpty())
			{
				return false;
			}
			if (keycode != Keys.Tab)
			{
				if (keycode != Keys.Return)
				{
					switch (keycode)
					{
					case Keys.Left:
						if (!shiftstat.bAlt && !shiftstat.bCtrl && !shiftstat.bShift && !this.FExtCase.LeftKey)
						{
							return false;
						}
						break;
					case Keys.Up:
						if (!shiftstat.bAlt && !shiftstat.bCtrl && !shiftstat.bShift && !this.FExtCase.UpKey)
						{
							return false;
						}
						break;
					case Keys.Right:
						if (!shiftstat.bAlt && !shiftstat.bCtrl && !shiftstat.bShift && !this.FExtCase.RightKey)
						{
							return false;
						}
						break;
					case Keys.Down:
						if (!shiftstat.bAlt && !shiftstat.bCtrl && !shiftstat.bShift && !this.FExtCase.DownKey)
						{
							return false;
						}
						break;
					}
				}
				else
				{
					if (shiftstat.bAlt || shiftstat.bCtrl)
					{
						return false;
					}
					if (!shiftstat.bShift && !this.FExtCase.RetKey)
					{
						return false;
					}
					if (shiftstat.bShift && !this.FExtCase.ShiftRetKey)
					{
						return false;
					}
				}
			}
			else
			{
				if (shiftstat.bAlt || shiftstat.bCtrl)
				{
					return false;
				}
				if (!shiftstat.bShift && !this.FExtCase.TabKey)
				{
					return false;
				}
				if (shiftstat.bShift && !this.FExtCase.ShiftTabKey)
				{
					return false;
				}
			}
			return true;
		}
		private bool CheckNecessary()
		{
			return (!this.JpGenCombo2.Visible || !this.FNecessaryEditors.dneJpn || this.JpGenCombo2.SelectedIndex >= 0) && (!this.YearEdit.Visible || !this.FNecessaryEditors.dneYear || this.YearEdit.GetInt() != 0) && (!this.MonthEdit.Visible || !this.FNecessaryEditors.dneMonth || this.MonthEdit.GetInt() != 0) && (!this.DayEdit.Visible || !this.FNecessaryEditors.dneDay || this.DayEdit.GetInt() != 0);
		}
		public virtual bool CanExit(Keys keycode, stSHIFTSTAT shiftstat)
		{
			if (!this.CheckExitCase(keycode, shiftstat))
			{
				return false;
			}
			if (!this.CheckNecessary())
			{
				return false;
			}
			bool result = true;
			if (keycode <= Keys.Tab)
			{
				switch (keycode)
				{
				case Keys.None:
				case Keys.LButton:
					return result;
				default:
					if (keycode != Keys.Tab)
					{
						goto IL_A8;
					}
					break;
				}
			}
			else
			{
				if (keycode != Keys.Return)
				{
					switch (keycode)
					{
					case Keys.Left:
					case Keys.Right:
						return result;
					case Keys.Up:
					case Keys.Down:
						if (this.JpGenCombo2.Focused && this.JpGenCombo2.DroppedDown)
						{
							result = false;
							return result;
						}
						return result;
					default:
						goto IL_A8;
					}
				}
			}
			if (shiftstat.bAlt || shiftstat.bCtrl)
			{
				result = false;
				return result;
			}
			Control control;
			if (shiftstat.bShift)
			{
				control = this.GetPrevEnableControl();
			}
			else
			{
				control = this.GetNextEnableControl();
			}
			if (control != null)
			{
				result = false;
				return result;
			}
			return result;
			IL_A8:
			result = false;
			return result;
		}
		protected bool IsDataEmpty()
		{
			return (!this.JpGenCombo2.Visible || this.JpGenCombo2.SelectedIndex < 0) && (!this.YearEdit.Visible || !(this.YearEdit.DataText != "")) && (!this.MonthEdit.Visible || !(this.MonthEdit.DataText != "")) && (!this.DayEdit.Visible || !(this.DayEdit.DataText != ""));
		}
		protected Control GetPrevEnableControl()
		{
			Control control = null;
			if (this.FCurCtrl != null)
			{
				foreach (Control control2 in base.Controls)
				{
					if (control2 != this.FCurCtrl && control2.Enabled && control2.Visible && control2.TabStop && control2.TabIndex <= this.FCurCtrl.TabIndex && (control == null || control2.TabIndex > control.TabIndex))
					{
						control = control2;
					}
				}
			}
			return control;
		}
		protected Control GetNextEnableControl()
		{
			Control control = null;
			if (this.FCurCtrl != null)
			{
				foreach (Control control2 in base.Controls)
				{
					if (control2 != this.FCurCtrl && control2.Enabled && control2.Visible && control2.TabStop && control2.TabIndex >= this.FCurCtrl.TabIndex && (control == null || control2.TabIndex < control.TabIndex))
					{
						control = control2;
					}
				}
			}
			return control;
		}
		private void MoveChildControl()
		{
			int num = 0;
			int tabIndex = 0;
			this.YearEdit.ExtEdit.Column = this.FYearCol;
			this.MonthEdit.ExtEdit.Column = this.FMonthCol;
			this.DayEdit.ExtEdit.Column = this.FDayCol;
			this.JpGenCombo2.Top = 0;
			this.YearEdit.Top = 0;
			this.MonthEdit.Top = 0;
			this.DayEdit.Top = 0;
			this.CalendarBtn.Top = 0;
			switch (this.prDateSequence)
			{
			case emDateSequence.dsYMD:
				if (this.JpGenCombo2.Visible)
				{
					this.JpGenCombo2.Left = num;
					num = this.JpGenCombo2.Right;
					this.JpGenCombo2.TabIndex = tabIndex++;
				}
				if (this.YearEdit.Visible)
				{
					this.YearEdit.Left = num;
					this.YearLabel.Left = this.YearEdit.Right;
					this.YearLabel.Top = (this.YearEdit.Height - this.YearLabel.Height) / 2;
					num = this.YearLabel.Right;
					this.YearEdit.TabIndex = tabIndex++;
				}
				if (this.MonthEdit.Visible)
				{
					this.MonthEdit.Left = num;
					this.MonthLabel.Left = this.MonthEdit.Right;
					this.MonthLabel.Top = (this.MonthEdit.Height - this.MonthLabel.Height) / 2;
					num = this.MonthLabel.Right;
					this.MonthEdit.TabIndex = tabIndex++;
				}
				if (this.DayEdit.Visible)
				{
					this.DayEdit.Left = num;
					this.DayLabel.Left = this.DayEdit.Right;
					this.DayLabel.Top = (this.DayEdit.Height - this.DayLabel.Height) / 2;
					num = this.DayLabel.Right;
					this.DayEdit.TabIndex = tabIndex++;
				}
				if (this.CalendarBtn.Visible)
				{
					this.CalendarBtn.Left = num;
					num = this.CalendarBtn.Right;
					this.CalendarBtn.TabIndex = tabIndex++;
				}
				break;
			case emDateSequence.dsYDM:
				if (this.JpGenCombo2.Visible)
				{
					this.JpGenCombo2.Left = num;
					num = this.JpGenCombo2.Right;
					this.JpGenCombo2.TabIndex = tabIndex++;
				}
				if (this.YearEdit.Visible)
				{
					this.YearEdit.Left = num;
					this.YearLabel.Left = this.YearEdit.Right;
					this.YearLabel.Top = (this.YearEdit.Height - this.YearLabel.Height) / 2;
					num = this.YearLabel.Right;
					this.YearEdit.TabIndex = tabIndex;
				}
				if (this.DayEdit.Visible)
				{
					this.DayEdit.Left = num;
					this.DayLabel.Left = this.DayEdit.Right;
					this.DayLabel.Top = (this.DayEdit.Height - this.DayLabel.Height) / 2;
					num = this.DayLabel.Right;
					this.DayEdit.TabIndex = tabIndex++;
				}
				if (this.MonthEdit.Visible)
				{
					this.MonthEdit.Left = num;
					this.MonthLabel.Left = this.MonthEdit.Right;
					this.MonthLabel.Top = (this.MonthEdit.Height - this.MonthLabel.Height) / 2;
					num = this.MonthLabel.Right;
					this.MonthEdit.TabIndex = tabIndex++;
				}
				if (this.CalendarBtn.Visible)
				{
					this.CalendarBtn.Left = num;
					num = this.CalendarBtn.Right;
					this.CalendarBtn.TabIndex = tabIndex++;
				}
				break;
			case emDateSequence.dsMDY:
				if (this.MonthEdit.Visible)
				{
					this.MonthEdit.Left = num;
					this.MonthLabel.Left = this.MonthEdit.Right;
					this.MonthLabel.Top = (this.MonthEdit.Height - this.MonthLabel.Height) / 2;
					num = this.MonthLabel.Right;
					this.MonthEdit.TabIndex = tabIndex++;
				}
				if (this.DayEdit.Visible)
				{
					this.DayEdit.Left = num;
					this.DayLabel.Left = this.DayEdit.Right;
					this.DayLabel.Top = (this.DayEdit.Height - this.DayLabel.Height) / 2;
					num = this.DayLabel.Right;
					this.DayEdit.TabIndex = tabIndex++;
				}
				if (this.JpGenCombo2.Visible)
				{
					this.JpGenCombo2.Left = num;
					num = this.JpGenCombo2.Right;
					this.JpGenCombo2.TabIndex = tabIndex++;
				}
				if (this.YearEdit.Visible)
				{
					this.YearEdit.Left = num;
					this.YearLabel.Left = this.YearEdit.Right;
					this.YearLabel.Top = (this.YearEdit.Height - this.YearLabel.Height) / 2;
					num = this.YearLabel.Right;
					this.YearEdit.TabIndex = tabIndex++;
				}
				if (this.CalendarBtn.Visible)
				{
					this.CalendarBtn.Left = num;
					num = this.CalendarBtn.Right;
					this.CalendarBtn.TabIndex = tabIndex++;
				}
				break;
			case emDateSequence.dsMYD:
				if (this.MonthEdit.Visible)
				{
					this.MonthEdit.Left = num;
					this.MonthLabel.Left = this.MonthEdit.Right;
					this.MonthLabel.Top = (this.MonthEdit.Height - this.MonthLabel.Height) / 2;
					num = this.MonthLabel.Right;
					this.MonthEdit.TabIndex = tabIndex++;
				}
				if (this.JpGenCombo2.Visible)
				{
					this.JpGenCombo2.Left = num;
					num = this.JpGenCombo2.Right;
					this.JpGenCombo2.TabIndex = tabIndex++;
				}
				if (this.YearEdit.Visible)
				{
					this.YearEdit.Left = num;
					this.YearLabel.Left = this.YearEdit.Right;
					this.YearLabel.Top = (this.YearEdit.Height - this.YearLabel.Height) / 2;
					num = this.YearLabel.Right;
					this.YearEdit.TabIndex = tabIndex++;
				}
				if (this.DayEdit.Visible)
				{
					this.DayEdit.Left = num;
					this.DayLabel.Left = this.DayEdit.Right;
					this.DayLabel.Top = (this.DayEdit.Height - this.DayLabel.Height) / 2;
					num = this.DayLabel.Right;
					this.DayEdit.TabIndex = tabIndex++;
				}
				if (this.CalendarBtn.Visible)
				{
					this.CalendarBtn.Left = num;
					num = this.CalendarBtn.Right;
					this.CalendarBtn.TabIndex = tabIndex++;
				}
				break;
			case emDateSequence.dsDYM:
				if (this.DayEdit.Visible)
				{
					this.DayEdit.Left = num;
					this.DayLabel.Left = this.DayEdit.Right;
					this.DayLabel.Top = (this.DayEdit.Height - this.DayLabel.Height) / 2;
					num = this.DayLabel.Right;
					this.DayEdit.TabIndex = tabIndex++;
				}
				if (this.JpGenCombo2.Visible)
				{
					this.JpGenCombo2.Left = num;
					num = this.JpGenCombo2.Right;
					this.JpGenCombo2.TabIndex = tabIndex++;
				}
				if (this.YearEdit.Visible)
				{
					this.YearEdit.Left = num;
					this.YearLabel.Left = this.YearEdit.Right;
					this.YearLabel.Top = (this.YearEdit.Height - this.YearLabel.Height) / 2;
					num = this.YearLabel.Right;
					this.YearEdit.TabIndex = tabIndex++;
				}
				if (this.MonthEdit.Visible)
				{
					this.MonthEdit.Left = num;
					this.MonthLabel.Left = this.MonthEdit.Right;
					this.MonthLabel.Top = (this.MonthEdit.Height - this.MonthLabel.Height) / 2;
					num = this.MonthLabel.Right;
					this.MonthEdit.TabIndex = tabIndex++;
				}
				if (this.CalendarBtn.Visible)
				{
					this.CalendarBtn.Left = num;
					num = this.CalendarBtn.Right;
					this.CalendarBtn.TabIndex = tabIndex++;
				}
				break;
			case emDateSequence.dsDMY:
				if (this.DayEdit.Visible)
				{
					this.DayEdit.Left = num;
					this.DayLabel.Left = this.DayEdit.Right;
					this.DayLabel.Top = (this.DayEdit.Height - this.DayLabel.Height) / 2;
					num = this.DayLabel.Right;
					this.DayEdit.TabIndex = tabIndex++;
				}
				if (this.MonthEdit.Visible)
				{
					this.MonthEdit.Left = num;
					this.MonthLabel.Left = this.MonthEdit.Right;
					this.MonthLabel.Top = (this.MonthEdit.Height - this.MonthLabel.Height) / 2;
					num = this.MonthLabel.Right;
					this.MonthEdit.TabIndex = tabIndex++;
				}
				if (this.JpGenCombo2.Visible)
				{
					this.JpGenCombo2.Left = num;
					num = this.JpGenCombo2.Right;
					this.JpGenCombo2.TabIndex = tabIndex++;
				}
				if (this.YearEdit.Visible)
				{
					this.YearEdit.Left = num;
					this.YearLabel.Left = this.YearEdit.Right;
					this.YearLabel.Top = (this.YearEdit.Height - this.YearLabel.Height) / 2;
					num = this.YearLabel.Right;
					this.YearEdit.TabIndex = tabIndex++;
				}
				if (this.CalendarBtn.Visible && !this.FReadOnly && base.Enabled)
				{
					this.CalendarBtn.Left = num;
					num = this.CalendarBtn.Right;
					this.CalendarBtn.TabIndex = tabIndex++;
				}
				break;
			}
			base.ClientSize = new Size(num, this.JpGenCombo2.Height);
			this.CalendarBtn.Height = this.JpGenCombo2.Height;
		}
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			bool flag = false;
			switch (this.prInitFocus)
			{
			case emInitFocus.difJpn:
				if (this.JpGenCombo2.Enabled && this.JpGenCombo2.Visible && !this.JpGenCombo2.Focused)
				{
                    // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 ----->>>>>
                    if (JpGenCombo2.SelectedIndex < 0)
                    {
                        SetJpGenCombo2Index(defaultFocusGengo);
                    }
                    // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 -----<<<<<
					this.JpGenCombo2.Focus();
					flag = true;
				}
				break;
			case emInitFocus.difYear:
				if (this.YearEdit.Enabled && this.YearEdit.Visible && !this.YearEdit.Focused)
				{
					this.YearEdit.Focus();
					flag = true;
				}
				break;
			case emInitFocus.difMonth:
				if (this.MonthEdit.Enabled && this.MonthEdit.Visible && !this.MonthEdit.Focused)
				{
					this.MonthEdit.Focus();
					flag = true;
				}
				break;
			case emInitFocus.difDay:
				if (this.DayEdit.Enabled && this.DayEdit.Visible && !this.DayEdit.Focused)
				{
					this.DayEdit.Focus();
					flag = true;
				}
				break;
			}
			if (flag)
			{
				return;
			}
			switch (this.prDateSequence)
			{
			case emDateSequence.dsYMD:
				if (this.JpGenCombo2.Enabled && this.JpGenCombo2.Visible)
				{
					if (!this.JpGenCombo2.Focused)
					{
                        // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 ----->>>>>
                        if (JpGenCombo2.SelectedIndex < 0)
                        {
                            SetJpGenCombo2Index(defaultFocusGengo);
                        }
                        // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 -----<<<<<
						this.JpGenCombo2.Focus();
						return;
					}
				}
				else
				{
					if (this.YearEdit.Enabled && this.YearEdit.Visible)
					{
						if (!this.YearEdit.Focused)
						{
							this.YearEdit.Focus();
							return;
						}
					}
					else
					{
						if (this.MonthEdit.Enabled && this.MonthEdit.Visible)
						{
							if (!this.MonthEdit.Focused)
							{
								this.MonthEdit.Focus();
								return;
							}
						}
						else
						{
							if (this.DayEdit.Enabled && this.DayEdit.Visible && !this.DayEdit.Focused)
							{
								this.DayEdit.Focus();
								return;
							}
						}
					}
				}
				break;
			case emDateSequence.dsYDM:
				if (this.JpGenCombo2.Enabled && this.JpGenCombo2.Visible)
				{
					if (!this.JpGenCombo2.Focused)
					{
                        // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 ----->>>>>
                        if (JpGenCombo2.SelectedIndex < 0)
                        {
                            SetJpGenCombo2Index(defaultFocusGengo);
                        }
                        // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 -----<<<<<
						this.JpGenCombo2.Focus();
						return;
					}
				}
				else
				{
					if (this.YearEdit.Enabled && this.YearEdit.Visible)
					{
						if (!this.YearEdit.Focused)
						{
							this.YearEdit.Focus();
							return;
						}
					}
					else
					{
						if (this.DayEdit.Enabled && this.DayEdit.Visible)
						{
							if (!this.DayEdit.Focused)
							{
								this.DayEdit.Focus();
								return;
							}
						}
						else
						{
							if (this.MonthEdit.Enabled && this.MonthEdit.Visible && this.MonthEdit.Focused)
							{
								this.MonthEdit.Focus();
								return;
							}
						}
					}
				}
				break;
			case emDateSequence.dsMDY:
				if (this.MonthEdit.Enabled && this.MonthEdit.Visible)
				{
					if (!this.MonthEdit.Focused)
					{
						this.MonthEdit.Focus();
						return;
					}
				}
				else
				{
					if (this.DayEdit.Enabled && this.DayEdit.Visible)
					{
						if (!this.DayEdit.Focused)
						{
							this.DayEdit.Focus();
							return;
						}
					}
					else
					{
						if (this.JpGenCombo2.Enabled && this.JpGenCombo2.Visible)
						{
							if (!this.JpGenCombo2.Focused)
							{
                                // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 ----->>>>>
                                if (JpGenCombo2.SelectedIndex < 0)
                                {
                                    SetJpGenCombo2Index(defaultFocusGengo);
                                }
                                // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 -----<<<<<
								this.JpGenCombo2.Focus();
								return;
							}
						}
						else
						{
							if (this.YearEdit.Enabled && this.YearEdit.Visible && !this.YearEdit.Focused)
							{
								this.YearEdit.Focus();
								return;
							}
						}
					}
				}
				break;
			case emDateSequence.dsMYD:
				if (this.MonthEdit.Enabled && this.MonthEdit.Visible)
				{
					if (this.MonthEdit.Focused)
					{
						this.MonthEdit.Focus();
						return;
					}
				}
				else
				{
					if (this.JpGenCombo2.Enabled && this.JpGenCombo2.Visible)
					{
						if (!this.JpGenCombo2.Focused)
						{
                            // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 ----->>>>>
                            if (JpGenCombo2.SelectedIndex < 0)
                            {
                                SetJpGenCombo2Index(defaultFocusGengo);
                            }
                            // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 -----<<<<<

							this.JpGenCombo2.Focus();
							return;
						}
					}
					else
					{
						if (this.YearEdit.Enabled && this.YearEdit.Visible)
						{
							if (!this.YearEdit.Focused)
							{
								this.YearEdit.Focus();
								return;
							}
						}
						else
						{
							if (this.DayEdit.Enabled && this.DayEdit.Visible && !this.DayEdit.Focused)
							{
								this.DayEdit.Focus();
								return;
							}
						}
					}
				}
				break;
			case emDateSequence.dsDYM:
				if (this.DayEdit.Enabled && this.DayEdit.Visible)
				{
					if (!this.DayEdit.Focused)
					{
						this.DayEdit.Focus();
						return;
					}
				}
				else
				{
					if (this.JpGenCombo2.Enabled && this.JpGenCombo2.Visible)
					{
						if (!this.JpGenCombo2.Focused)
						{
                            // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 ----->>>>>
                            if (JpGenCombo2.SelectedIndex < 0)
                            {
                                SetJpGenCombo2Index(defaultFocusGengo);
                            }
                            // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 -----<<<<<
							this.JpGenCombo2.Focus();
							return;
						}
					}
					else
					{
						if (this.YearEdit.Enabled && this.YearEdit.Visible)
						{
							if (!this.YearEdit.Focused)
							{
								this.YearEdit.Focus();
								return;
							}
						}
						else
						{
							if (this.MonthEdit.Enabled && this.MonthEdit.Visible && !this.MonthEdit.Focused)
							{
								this.MonthEdit.Focus();
								return;
							}
						}
					}
				}
				break;
			case emDateSequence.dsDMY:
				if (this.DayEdit.Enabled && this.DayEdit.Visible)
				{
					if (!this.DayEdit.Focused)
					{
						this.DayEdit.Focus();
						return;
					}
				}
				else
				{
					if (this.MonthEdit.Enabled && this.MonthEdit.Visible)
					{
						if (!this.MonthEdit.Focused)
						{
							this.MonthEdit.Focus();
							return;
						}
					}
					else
					{
						if (this.JpGenCombo2.Enabled && this.JpGenCombo2.Visible)
						{
							if (!this.JpGenCombo2.Focused)
							{
                                // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 ----->>>>>
                                if (JpGenCombo2.SelectedIndex < 0)
                                {
                                    SetJpGenCombo2Index(defaultFocusGengo);
                                }
                                // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 -----<<<<<
								this.JpGenCombo2.Focus();
								return;
							}
						}
						else
						{
							if (this.YearEdit.Enabled && this.YearEdit.Visible && !this.YearEdit.Focused)
							{
								this.YearEdit.Focus();
							}
						}
					}
				}
				break;
			default:
				return;
			}
		}
		protected override void OnVisibleChanged(EventArgs e)
		{
			if (base.Visible)
			{
                // XMLからのフォーマット読み込みもここで実行する
                SetDateFormatFromXml();// ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応

				emDateFormat dateFormat = this.prDateFormat;
				if (this.DateFormat == emDateFormat.dfG2Y)
				{
					this.DateFormat = emDateFormat.dfG2Y2M;
				}
				else
				{
					this.DateFormat = emDateFormat.dfG2Y;
				}
				this.DateFormat = dateFormat;
			}
			base.OnVisibleChanged(e);
		}
		protected override void OnImeModeChanged(EventArgs e)
		{
			base.OnImeModeChanged(e);
			this.JpGenCombo2.ImeMode = this.ImeMode;
			this.YearEdit.ImeMode = this.ImeMode;
			this.MonthEdit.ImeMode = this.ImeMode;
			this.DayEdit.ImeMode = this.ImeMode;
		}
		private void JpGenCombo_SizeChanged(object sender, EventArgs e)
		{
			if (sender == this.JpGenCombo2)
			{
				int num = (int)Math.Ceiling((double)((float)this.FJpnYearCol * this.GetAveCharWidth(this.JpGenCombo2) + 10f));
				if (this.JpGenCombo2.Width != num)
				{
					this.JpGenCombo2.Width = num;
					return;
				}
			}
			this.MoveChildControl();
			base.Invalidate();
		}
		private void JpGenCombo2_KeyDown(object sender, KeyEventArgs e)
		{
			Control control = null;
			if (sender == this.JpGenCombo2 && !this.JpGenCombo2.DroppedDown && !base.DesignMode)
			{
				Keys keyCode = e.KeyCode;
				if (keyCode != Keys.Escape)
				{
					if (keyCode == Keys.Space)
					{
						int num = this.JpGenCombo2.SelectedIndex + 1;
						if (num >= this.JpGenCombo2.Items.Count)
						{
							num = 0;
						}
						this.JpGenCombo2.SelectedIndex = num;
					}
				}
				else
				{
					this.JpGenCombo2.SelectedIndex = -1;
				}
			}
			if ((!e.Shift && (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)) || e.KeyCode == Keys.Right)
			{
				control = this.GetNextEnableControl();
			}
			else
			{
				if ((e.Shift && (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)) || e.KeyCode == Keys.Left)
				{
					control = this.GetPrevEnableControl();
				}
			}
			if (control != null)
			{
				control.Focus();
			}
		}
		internal Control CheckInputDataForKeyCtrl()
		{
			if (!this.FOptions.deoInputCheck)
			{
				return null;
			}
			switch (TLib.CheckLongDate(this.prLongDate))
			{
			case TLib.TCheckDateStat.cdsIllegalYear:
				return this.YearEdit;
			case TLib.TCheckDateStat.cdsIllegalMonth:
				return this.MonthEdit;
			case TLib.TCheckDateStat.cdsIllegalDay:
				return this.DayEdit;
			default:
				return null;
			}
		}
		public Control CheckInputData()
		{
			if (this.JpGenCombo2.Visible)
			{
				if (this.JpGenCombo2.DroppedDown)
				{
					this.JpGenCombo2.CloseUp();
				}
				if (this.prLongDate != 0 && this.prLongDate != 10101 && this.JpGenCombo2.SelectedIndex == -1 && this.YearEdit.GetInt() != 0)
				{
					return this.JpGenCombo2;
				}
			}
			switch (TLib.CheckLongDate(this.prLongDate))
			{
			case TLib.TCheckDateStat.cdsIllegalYear:
				return this.YearEdit;
			case TLib.TCheckDateStat.cdsIllegalMonth:
				return this.MonthEdit;
			case TLib.TCheckDateStat.cdsIllegalDay:
				return this.DayEdit;
			default:
				return null;
			}
		}
        /// <summary>
        /// 年変更のイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Update Note: 2019/01/25 陳艶丹</br>	
        /// <br>管理番号   ：11470076-00</br>	 
        /// <br>             新元号の追加対応</br>
        /// </remarks>
		private void YearEdit_TextChanged(object sender, EventArgs e)
		{
			if (!this.dntChgEditFg)
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				if (this.YearEdit.Visible)
				{
					num = this.YearEdit.GetInt();
				}
				if (this.MonthEdit.Visible)
				{
					num2 = this.MonthEdit.GetInt();
				}
				if (this.DayEdit.Visible)
				{
					num3 = this.DayEdit.GetInt();
				}
				if (this.JpGenCombo2.Visible && this.JpGenCombo2.Text.Trim() != "" && num != 0)
				{
                    // ----- UPD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 ----->>>>>
                    //string s = this.JpGenCombo2.Text + "01/12/31";
					//num4 = Convert.ToInt32(DateTime.Parse(s).ToString("yyyyMMdd")) / 10000 - 1;
                    num4 = TDateTime.GetBaseYear(JpGenCombo2.Text.Trim());
                    // ----- UPD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 -----<<<<<
				}
				int num5 = num * 10000 + num2 * 100 + num3;
				if (num5 != 0)
				{
					num5 += num4 * 10000;
				}
				this.dntSetDspFg = true;
				this.SetLongDate(num5);
				this.dntSetDspFg = false;
				if (sender is TNedit && ((TNedit)sender).Modified && ((TNedit)sender).TextLength == ((TNedit)sender).MaxLength)
				{
					Control nextEnableControl = this.GetNextEnableControl();
					if (nextEnableControl != null)
					{
						nextEnableControl.Focus();
					}
				}
				if (sender == this.YearEdit)
				{
					if (this.TextChangedYearEdit != null && this.YearEdit.Visible)
					{
						this.TextChangedYearEdit(sender, e);
						return;
					}
				}
				else
				{
					if (sender == this.MonthEdit)
					{
						if (this.TextChangedMonthEdit != null && this.MonthEdit.Visible)
						{
							this.TextChangedMonthEdit(sender, e);
							return;
						}
					}
					else
					{
						if (sender == this.DayEdit && this.TextChangedDayEdit != null && this.DayEdit.Visible)
						{
							this.TextChangedDayEdit(sender, e);
						}
					}
				}
			}
		}
		private void Calendar_DateChanged(object sender, DateRangeEventArgs e)
		{
			if (sender is MonthCalendar && ((MonthCalendar)sender).Visible)
			{
				this.Calendar.DateChanged -= new DateRangeEventHandler(this.Calendar_DateChanged);
				this.Calendar.SelectionStart = e.Start;
				this.Calendar.SelectionEnd = e.Start;
				this.Calendar.MaxSelectionCount = 1;
				this.SetDateTime(e.Start);
				this.Calendar.DateChanged += new DateRangeEventHandler(this.Calendar_DateChanged);
			}
		}
		private void Calendar_DateSelected(object sender, DateRangeEventArgs e)
		{
			if (sender is MonthCalendar && ((MonthCalendar)sender).Visible)
			{
				this.SetDateTime(e.Start);
				this.CalendarBtn.CloseUp();
			}
		}
		private void JpGenCombo2_Enter(object sender, EventArgs e)
		{
			this.FCurCtrl = (Control)sender;
		}
		private void JpGenCombo2_GotFocus(object sender, EventArgs e)
		{
			if (sender == this.JpGenCombo2 && this.FOptions.deoYearNameList)
			{
				if (this.JpGenCombo2.SelectedIndex == -1)
				{
					this.JpGenCombo2.SelectedIndex = 0;
				}
				if (!this.JpGenCombo2.DroppedDown && this.JpGenCombo2.Items.Count > 1)
				{
					this.JpGenCombo2.DropDown();
				}
			}
		}
		private void Calendar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				switch (this.prDateSequence)
				{
				case emDateSequence.dsYMD:
					if (this.JpGenCombo2.Visible && this.JpGenCombo2.Enabled)
					{
						this.JpGenCombo2.Focus();
						return;
					}
					if (this.YearEdit.Visible && this.YearEdit.Enabled)
					{
						this.YearEdit.Focus();
						return;
					}
					if (this.MonthEdit.Visible && this.MonthEdit.Enabled)
					{
						this.MonthEdit.Focus();
						return;
					}
					if (this.DayEdit.Visible && this.DayEdit.Enabled)
					{
						this.DayEdit.Focus();
						return;
					}
					break;
				case emDateSequence.dsYDM:
					if (this.JpGenCombo2.Visible && this.JpGenCombo2.Enabled)
					{
						this.JpGenCombo2.Focus();
						return;
					}
					if (this.YearEdit.Visible && this.YearEdit.Enabled)
					{
						this.YearEdit.Focus();
						return;
					}
					if (this.DayEdit.Visible && this.DayEdit.Enabled)
					{
						this.DayEdit.Focus();
						return;
					}
					if (this.MonthEdit.Visible && this.MonthEdit.Enabled)
					{
						this.MonthEdit.Focus();
						return;
					}
					break;
				case emDateSequence.dsMDY:
					if (this.MonthEdit.Visible && this.MonthEdit.Enabled)
					{
						this.MonthEdit.Focus();
						return;
					}
					if (this.DayEdit.Visible && this.DayEdit.Enabled)
					{
						this.DayEdit.Focus();
						return;
					}
					if (this.JpGenCombo2.Visible && this.JpGenCombo2.Enabled)
					{
						this.JpGenCombo2.Focus();
						return;
					}
					if (this.YearEdit.Visible && this.YearEdit.Enabled)
					{
						this.YearEdit.Focus();
						return;
					}
					break;
				case emDateSequence.dsMYD:
					if (this.MonthEdit.Visible && this.MonthEdit.Enabled)
					{
						this.MonthEdit.Focus();
						return;
					}
					if (this.JpGenCombo2.Visible && this.JpGenCombo2.Enabled)
					{
						this.JpGenCombo2.Focus();
						return;
					}
					if (this.YearEdit.Visible && this.YearEdit.Enabled)
					{
						this.YearEdit.Focus();
						return;
					}
					if (this.DayEdit.Visible && this.DayEdit.Enabled)
					{
						this.DayEdit.Focus();
						return;
					}
					break;
				case emDateSequence.dsDYM:
					if (this.DayEdit.Visible && this.DayEdit.Enabled)
					{
						this.DayEdit.Focus();
						return;
					}
					if (this.JpGenCombo2.Visible && this.JpGenCombo2.Enabled)
					{
						this.JpGenCombo2.Focus();
						return;
					}
					if (this.YearEdit.Visible && this.YearEdit.Enabled)
					{
						this.YearEdit.Focus();
						return;
					}
					if (this.MonthEdit.Visible && this.MonthEdit.Enabled)
					{
						this.MonthEdit.Focus();
						return;
					}
					break;
				case emDateSequence.dsDMY:
					if (this.DayEdit.Visible && this.DayEdit.Enabled)
					{
						this.DayEdit.Focus();
						return;
					}
					if (this.MonthEdit.Visible && this.MonthEdit.Enabled)
					{
						this.MonthEdit.Focus();
						return;
					}
					if (this.JpGenCombo2.Visible && this.JpGenCombo2.Enabled)
					{
						this.JpGenCombo2.Focus();
						return;
					}
					if (this.YearEdit.Visible && this.YearEdit.Enabled)
					{
						this.YearEdit.Focus();
						return;
					}
					break;
				}
				this.CalendarBtn.CloseUp();
			}
		}
		private void CalendarBtn_DroppingDown(object sender, CancelEventArgs e)
		{
			if (this.prLongDate != 0)
			{
				int num = this.prLongDate / 10000;
				if (num == 0)
				{
					num = DateTime.Today.Year;
				}
				int num2 = this.prLongDate % 10000 / 100;
				if (num2 < 1)
				{
					num2 = 1;
				}
				if (num2 > 12)
				{
					num2 = 12;
				}
				int num3 = this.prLongDate % 100;
				if (num3 < 1)
				{
					num3 = 1;
				}
				if (TLib.GetMonthDay(num, num2) < num3)
				{
					num3 = TLib.GetMonthDay(num, num2);
				}
				try
				{
					this.Calendar.SelectionStart = new DateTime(num, num2, num3);
					goto IL_8E;
				}
				catch
				{
					goto IL_8E;
				}
			}
			this.Calendar.SelectionStart = DateTime.Today;
			IL_8E:
			this.Calendar.Focus();
		}
		private void YearEdit_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.KeyDownYearEdit != null && this.YearEdit.Visible)
			{
				this.KeyDownYearEdit(sender, e);
			}
		}
		private void MonthEdit_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.KeyDownMonthEdit != null && this.MonthEdit.Visible)
			{
				this.KeyDownMonthEdit(sender, e);
			}
		}
		private void DayEdit_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.KeyDownDayEdit != null && this.DayEdit.Visible)
			{
				this.KeyDownDayEdit(sender, e);
			}
		}
		public void Clear()
		{
			this.SetLongDate(0);
		}
		public void SetLongDate(int SetValue)
		{
			if (SetValue == 10101)
			{
				SetValue = 0;
			}
			if (SetValue != this.prLongDate)
			{
				this.prLongDate = SetValue;
				if (!this.dntSetDspFg)
				{
					this.dntChgEditFg = true;
					this.SetLongDateToEditer(SetValue);
					this.dntChgEditFg = false;
				}
				if (this.ValueChanged != null)
				{
					EventArgs e = new EventArgs();
					this.ValueChanged(this, e);
					return;
				}
			}
			else
			{
				if (SetValue == 0 && !this.dntSetDspFg)
				{
					this.dntChgEditFg = true;
					this.SetLongDateToEditer(SetValue);
					this.dntChgEditFg = false;
				}
			}
		}
		public int GetLongDate()
		{
			return this.LongDate;
		}
		public DateTime GetDateTime()
		{
			DateTime result = new DateTime(0L);
			int longDate = this.GetLongDate();
			if (longDate >= 19000101)
			{
				result = TDateTime.LongDateToDateTime(longDate);
			}
			return result;
		}
		public void SetDateTime(DateTime SetValue)
		{
			if (SetValue == DateTime.MinValue)
			{
				this.SetLongDate(0);
				return;
			}
			this.SetLongDate(Convert.ToInt32(SetValue.ToString("yyyyMMdd")));
		}
		public int GetDateYear()
		{
			return this.prLongDate / 10000;
		}
		public int GetDateYear(string dateFormat)
		{
			string text = "";
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			num = this.GetDateYear();
			num2 = this.GetDateMonth();
			if (num2 <= 0)
			{
				num2 = 1;
			}
			num3 = this.GetDateDay();
			if (num3 <= 0)
			{
				num3 = 1;
			}
			DateTime orgDate = new DateTime(num, num2, num3);
			TDateTime.SplitDate(dateFormat, orgDate, ref text, ref num, ref num2, ref num3);
			return num;
		}
		public int GetDateMonth()
		{
			return this.prLongDate % 10000 / 100;
		}
		public int GetDateDay()
		{
			return this.prLongDate % 100;
		}
		public string GetDateTimeString(string dateFormat)
		{
			DateTime dateTime = this.GetDateTime();
			return TDateTime.DateTimeToString(dateFormat, dateTime);
		}
		public void SetToday()
		{
			DateTime today = DateTime.Today;
			this.SetDateTime(today);
		}
		public void SetEndOfMonth(int SetValue)
		{
			int num = SetValue / 10000;
			int num2 = SetValue % 10000 / 100;
			if (num == 0 && (num2 < 1 || num2 > 12))
			{
				num = DateTime.Today.Year;
				num2 = DateTime.Today.Month;
			}
			int monthDay = TLib.GetMonthDay(num, num2);
			this.SetLongDate(num * 10000 + num2 * 100 + monthDay);
		}

        // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 ----->>>>>
        /// <summary>
        /// 元号モード変更処理。
        /// 本コンポーネント内の元号コンボボックスの内容を、指定されたモードによって変更します。
        /// なお、TDateEditは平成以降の元号を持ったコンポーネントのため、平成より前のモードを指定された場合も平成以降しか表示しません。
        /// </summary>
        /// <param name="mode">元号モード</param>
        /// <remarks>
        /// <br>Note       : 元号モード変更処理</br>
        /// <br>Programer  : 陳艶丹</br>
        /// <br>Date       : 2019/01/25</br>
        /// </remarks>
        public virtual void SetGengouMode(TDateTimeGengouMode mode)
        {
            // 元号リストをクリアする
            JpGenCombo2.Items.Clear();

            // 平成より前のモードを指定された場合も、平成以降を表示するように変更する。
            // ※この共通部品が平成以降を表示するものでなくなった場合は、必ず変更を行ってください。
            if (mode < TDateTimeGengouMode.StartsWithHeisei)
            {
                mode = TDateTimeGengouMode.StartsWithHeisei;
            }

            // 共通部品で元号リストを取得
            ArrayList eraList = null;
            TDateTime.GetGengouList(out eraList, mode);

            int index = 0;
            foreach (string eraName in eraList)
            {
                Infragistics.Win.ValueListItem valueListItem = new Infragistics.Win.ValueListItem();
                valueListItem.DataValue = "ValueListItem" + index;
                valueListItem.DisplayText = eraName;
                JpGenCombo2.Items.Add(valueListItem);
                index++;
            }
        }

        /// <summary>
        /// 初期フォーカスの元号を設定します。
        /// 本メソッドのコールは、必ず各画面のInitializeComponent後に行ってください。
        /// </summary>
        /// <param name="gengo">元号</param>
        /// <remarks>
        /// <br>Note       : 初期フォーカスの元号を設定します。</br>
        /// <br>Programer  : 陳艶丹</br>
        /// <br>Date       : 2019/01/25</br>
        /// </remarks>
        public void SetDefaultFocusGengo(string gengo)
        {
            this.defaultFocusGengo = gengo;
        }
        // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 -----<<<<<

		private void SetLongDateToEditer(int SetValue)
		{
			string text = "";
			int @int = 0;
			int int2 = 0;
			int int3 = 0;
			switch (this.prDateFormat)
			{
			case emDateFormat.df4Y2M2D:
			case emDateFormat.df4Y2M:
			case emDateFormat.df4Y:
				TDateTime.SplitDate("YYYYMMDD", SetValue, ref text, ref @int, ref int2, ref int3);
				goto IL_A0;
			case emDateFormat.dfG2Y2M2D:
			case emDateFormat.dfG2Y2M:
			case emDateFormat.dfG2Y:
				try
				{
					TDateTime.SplitDate("GGYYMMDD", SetValue, ref text, ref @int, ref int2, ref int3);
					goto IL_A0;
				}
				catch
				{
					text = "";
					@int = 0;
					int2 = SetValue % 10000 / 100;
					int3 = SetValue % 100;
					goto IL_A0;
				}
			}
			TDateTime.SplitDate("YYMMDD", SetValue, ref text, ref @int, ref int2, ref int3);
			IL_A0:
            if (!base.DesignMode)
            {
                // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 ----->>>>>
                if (JpGenCombo2.SelectedItem == null || text != JpGenCombo2.SelectedItem.DisplayText)
                {
                    // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 -----<<<<<
                    this.JpGenCombo2.SelectedItem = null;
                    object[] all = this.JpGenCombo2.Items.All;
                    object[] array = all;
                    for (int i = 0; i < array.Length; i++)
                    {
                        ValueListItem valueListItem = (ValueListItem)array[i];
                        if (valueListItem.DisplayText == text)
                        {
                            this.JpGenCombo2.SelectedItem = valueListItem;
                            break;
                        }
                    }
                }// ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応
            }
            else
            {
                this.JpGenCombo2.Text = text;
            }
			this.JpGenCombo2.Text = text;
			this.YearEdit.SetInt(@int);
			this.MonthEdit.SetInt(int2);
			this.DayEdit.SetInt(int3);
		}
		private float GetAveCharWidth(UltraComboEditor cmb)
		{
			Graphics graphics = cmb.CreateGraphics();
			string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			FontStyle fontStyle = FontStyle.Regular;
			string name;
			if (cmb.Appearance.FontData.Name == "" || cmb.Appearance.FontData.Name == null)
			{
				name = cmb.Font.Name;
			}
			else
			{
				name = cmb.Appearance.FontData.Name;
			}
			float sizeInPoints;
			if ((double)cmb.Appearance.FontData.SizeInPoints == 0.0)
			{
				sizeInPoints = cmb.Font.SizeInPoints;
			}
			else
			{
				sizeInPoints = cmb.Appearance.FontData.SizeInPoints;
			}
			if (cmb.Appearance.FontData.Bold == DefaultableBoolean.Default)
			{
				if (cmb.Font.Bold)
				{
					fontStyle |= FontStyle.Bold;
				}
			}
			else
			{
				if (cmb.Appearance.FontData.Bold == DefaultableBoolean.True)
				{
					fontStyle |= FontStyle.Bold;
				}
			}
			if (cmb.Appearance.FontData.Italic == DefaultableBoolean.Default)
			{
				if (cmb.Font.Italic)
				{
					fontStyle |= FontStyle.Italic;
				}
			}
			else
			{
				if (cmb.Appearance.FontData.Italic == DefaultableBoolean.True)
				{
					fontStyle |= FontStyle.Italic;
				}
			}
			if (cmb.Appearance.FontData.Strikeout == DefaultableBoolean.Default)
			{
				if (cmb.Font.Strikeout)
				{
					fontStyle |= FontStyle.Strikeout;
				}
			}
			else
			{
				if (cmb.Appearance.FontData.Strikeout == DefaultableBoolean.True)
				{
					fontStyle |= FontStyle.Strikeout;
				}
			}
			if (cmb.Appearance.FontData.Underline == DefaultableBoolean.Default)
			{
				if (cmb.Font.Underline)
				{
					fontStyle |= FontStyle.Underline;
				}
			}
			else
			{
				if (cmb.Appearance.FontData.Underline == DefaultableBoolean.True)
				{
					fontStyle |= FontStyle.Underline;
				}
			}
			Font font = new Font(name, sizeInPoints, fontStyle);
			StringFormat stringFormat = new StringFormat();
			stringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
			stringFormat.Alignment = StringAlignment.Near;
			stringFormat.LineAlignment = StringAlignment.Near;
			float result = graphics.MeasureString(text, font, 640, stringFormat).Width / 26f;
			font.Dispose();
			graphics.Dispose();
			return result;
		}

        // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 ----->>>>>
        /// <summary>
        /// 元号コンボの選択処理。
        /// 指定された元号を選択します。
        /// </summary>
        /// <param name="gengo">元号名称</param>
        /// <remarks>
        /// <br>Note       : 元号コンボの選択処理を行う。</br>
        /// <br>Programer  : 陳艶丹</br>
        /// <br>Date       : 2019/01/25</br>
        /// </remarks>
        private void SetJpGenCombo2Index(string gengo)
        {
            // このメソッド内で選択がされたか否か
            bool hasNewSelected = false;

            foreach (ValueListItem item in JpGenCombo2.Items)
            {
                if (item.DisplayText == gengo)
                {
                    JpGenCombo2.SelectedIndex = JpGenCombo2.Items.IndexOf(item);
                    hasNewSelected = true;
                    break;
                }
            }

            // うまく元号選択ができない場合は、SelectedIndexを-1（空白）に設定）
            if (!hasNewSelected)
            {
                JpGenCombo2.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// XMLからのDateFormatの設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : XMLからのDateFormatの設定処理を行う。</br>
        /// <br>Programer  : 陳艶丹</br>
        /// <br>Date       : 2019/01/25</br>
        /// </remarks>
        private void SetDateFormatFromXml()
        {
            // XML読み込み済みの場合、もしくはNameプロパティ未設定の状態では設定しない
            if (HasCheckedDateFormatFromXml || string.IsNullOrEmpty(this.Name))
            {
                return;
            }

            // 自身よりも親のコンポーネントで、Broadleaf.Windows.Forms名前空間のものを探す
            Control form = SearchParentBLForms(this);

            // 見つからなかった場合は設定しない
            if (form == null)
            {
                return;
            }

            // XMLからDateFormat(文字列)設定を取得
            string dateFormatStr = TDateTime.GetDateFormat(form.Name, this.Name);
            // XML読み込み済みにしておく
            this.HasCheckedDateFormatFromXml = true;

            // 設定なしの場合は設定しない
            if (string.IsNullOrEmpty(dateFormatStr))
            {
                return;
            }
            // 取得した設定がDateFormat列挙体に定義されていない場合は無視する
            else if (!Enum.IsDefined(typeof(emDateFormat), dateFormatStr))
            {
                return;
            }

            // 実際にその値を設定
            this.DateFormat = (emDateFormat)Enum.Parse(typeof(emDateFormat), dateFormatStr);
            this.isSetDateFormatFromXml = true;
            // 元号等の変更があった場合に対応するため、各子コントロールの値再設定も実施
            this.SetLongDateToEditer(this.LongDate);
        }

        /// <summary>
        /// 引数のコンポーネントより親のコンポーネントで、Broadleaf.Windows.Forms名前空間のものを探す
        /// （再帰呼び出しメソッド）
        /// </summary>
        /// <param name="childControl">検索元となる子のコンポーネント</param>
        /// <returns>最初に発見されたBroadleaf.Windows.Forms名前空間のコンポーネント。見つからなかった場合はnull。</returns>
        /// <remarks>
        /// <br>Note       : 引数のコンポーネントより親のコンポーネントで、Broadleaf.Windows.Forms名前空間のものを探す</br>
        /// <br>Programer  : 陳艶丹</br>
        /// <br>Date       : 2019/01/25</br>
        /// </remarks>
        private Control SearchParentBLForms(Control childControl)
        {
            Control returnControl;
            if (childControl.Parent == null)
            {
                // 親コントロールがない場合は、そこで検索終了
                returnControl = null;
            }
            else if (childControl.Parent.GetType().Namespace == "Broadleaf.Windows.Forms")
            {
                // 親コントロールがBroadleaf.Windows.Formsなら、そのコントロールを返却
                returnControl = childControl.Parent;
            }
            else
            {
                // それ以外は再帰呼び出し
                returnControl = SearchParentBLForms(childControl.Parent);
            }

            return returnControl;
        }
        // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 -----<<<<<
	}
}
