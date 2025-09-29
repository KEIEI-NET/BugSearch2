//**********************************************************************//
// System           :   ＳＦ．ＮＥＴ                                    //
// Sub System       :                                                   //
// Program name     :   出力済帳票選択画面                              //
//                  :   SFUKK06025U.DLL                                 //
// Name Space       :   Broadleaf.Windows.Forms                         //
// Programer        :   日並　征二郎                                    //
// Date             :   2005.03.18                                      //
//----------------------------------------------------------------------//
// Update Note      :	2005.08.20　松林　真二　PDF削除処理追加         //
//----------------------------------------------------------------------//
//                Copyright(c)2005 Broadleaf Co.,Ltd.                   //
//**********************************************************************//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Xml;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
	/// **********************************************************************
	/// public class name:   SFANL06101U
	///                      SFANL06101U.DLL
	/// <summary>
	///                      出力済帳票選択画面
	/// </summary>
	/// ----------------------------------------------------------------------
	/// <remarks> 
	/// <br>note             :   出力済帳票を表示する画面です</br>
	/// <br>Programer        :   日並　征二郎</br>
	/// <br>Date             :   2005.03.18</br>
	/// <br>Update Note      :   </br>
	/// <br>Programmer : 94012 K.Takeshita</br>
	/// <br>Date       : 2005.09.26</br>
	/// <br>Note       :		・メッセージ表示をシステム規定のメッセージ表示に変更</br>
	/// <br>Programmer : 94012 K.Takeshita</br>
	/// <br>Date       : 2005.12.05</br>
	/// <br>Note       :    ・AddPrintInfoのOverLoad追加(ログイン担当者追加)</br>
	/// <br>Update Note: 2006.03.02 Y.Sasaki</br>
	/// <br>           : １.上記修正でログイン担当者情報を引数としてもらっている
	///	               :    この部品でログイン情報を取得して設定するように変更。</br>
	/// <br>Update Note: 2006.04.13 Y.Sasaki</br>
	/// <br>           : １.PDF履歴保存済みチェック機能追加。</br>
	/// <br>Update Note: 2006.08.01 Y.Sasaki</br>
	/// <br>           : １.コピーライト変更。</br>
	/// <br>           : ２.カレンダーの複数選択表示時の表示が変わる不具合対応。</br>
	/// <br>Update Note: 2007.01.12 中村　仁</br>
	/// <br>           : Vista対応</br>
	/// <br>           : カレンダーのサイズがスライダーに収まりきれないので、画面の配置を変更</br>
	/// <br>Update Note: 2008.03.11 Y.Sasaki</br>
	/// <br>           : １.SF eye's改良(08'Q1-2)(No.10400972-00) ロール機能対応</br>
    /// <br>Update Note: 2010.11.09 Miwa Honda</br>
    /// <br>           : PDF削除機能の障害解除(ＮＳ問題対応報告票)</br>
	/// </remarks>
	/// **********************************************************************
	public class SFANL06101UA : System.Windows.Forms.Form
	{
		// イベント制御
		private bool _DateRangeChage = false;
		private static bool _PrintItemInfoChange = false;
		// カレンダーの日付時刻
		private DateTime _CalenderDate = DateTime.Now;

		// 色定義
		private Color ctActiveForeColor   = Color.Black;
		private Color ctReadOnlyForeColor = Color.Gray;
//		private Color ActiveFocusColor = Color.FromArgb(255,224,194);

		// 帳票PDFの格納先(path)
		private string _PdfPath;
		// 帳票XMLの格納先(path)
		private string _XmlPath;
		// ログイン担当者
		private string _LoginWorker;
		// PDFファイルのコレクション
		private static ArrayList _PrintInfoItems = new ArrayList();
		// 印刷済のコレクション
		private static ArrayList _PrintKindInfo = new ArrayList();
		//マウスポインタのあるノードを保存する領域
		private Infragistics.Win.UltraWinTree.UltraTreeNode _LastUltraTreeNode = null;

#if !ADD20060302
		// ログイン従業員
		private Employee _loginEmployee = null; 
#endif
		
		private const string UNITID = "SFANL06101UA";
		private const string PGNM   = "出力済帳票選択画面";
		/// <summary>
		/// eventキーワードを付けたデリゲート関数のインスタンス
		/// </summary>
		public event SelectNodeEvent SelectNode;

		// >>>>> 2008.03.11 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
		/// <summary>システムロールIF</summary>
		INsMenuRoleManager _iNsMenuRoleManager;
		/// <summary>.NSシステム DIコンテナ</summary>
		ServiceInterfaceFactory _serviceInterfaceFactory;
		// <<<<< 2008.03.11 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

		private System.Windows.Forms.MonthCalendar monthCalendar;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet UdsDateType;
        private System.Windows.Forms.Timer PrintItemInfoTimer;
		private System.Windows.Forms.ToolTip NodeToolTip;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private Panel panel1;
        private Panel panel2;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet UdsDspType;
        private Infragistics.Win.UltraWinTree.UltraTree UTlistVew;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL06101UA()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
			//
			
			// 表示範囲指定グループボックス初期化
			UdsDateType.Value = 0;
			UdsDateType.CheckedIndex  = 0;

			// 表示形式指定グループボックス初期化
			UdsDspType.Value = 0;
			UdsDspType.CheckedIndex  = 0;

			// PDFパスとXMLパスを取得する
			SFCMN00331C prtCommon = new SFCMN00331C();
			prtCommon.GetPdfSavePath(ref _PdfPath);
			prtCommon.GetPdfXmlSavePath(ref _XmlPath);

#if REP20060302
			// LOGIN担当者を設定する☆
			_LoginWorker = "";
#else
			// ログイン従業員の取得
			this._loginEmployee = LoginInfoAcquisition.Employee.Clone();
			if (this._loginEmployee != null)
			{
				this._LoginWorker = this._loginEmployee.Name;
			} 
			else 
			{
				this._LoginWorker = "";
			}
#endif
		}

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFANL06101UA));
            Infragistics.Win.UltraWinTree.UltraTreeColumnSet ultraTreeColumnSet1 = new Infragistics.Win.UltraWinTree.UltraTreeColumnSet();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.UdsDateType = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.PrintItemInfoTimer = new System.Windows.Forms.Timer(this.components);
            this.NodeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UTlistVew = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.UdsDspType = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            ((System.ComponentModel.ISupportInitialize)(this.UdsDateType)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UTlistVew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdsDspType)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.BackColor = System.Drawing.Color.White;
            this.monthCalendar.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.monthCalendar.Location = new System.Drawing.Point(3, 42);
            this.monthCalendar.Margin = new System.Windows.Forms.Padding(0);
            this.monthCalendar.MaxSelectionCount = 1;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.ShowTodayCircle = false;
            this.monthCalendar.TabIndex = 1;
            this.monthCalendar.TitleBackColor = System.Drawing.Color.RoyalBlue;
            this.monthCalendar.TitleForeColor = System.Drawing.Color.Orange;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateChanged);
            // 
            // UdsDateType
            // 
            this.UdsDateType.Dock = System.Windows.Forms.DockStyle.Top;
            this.UdsDateType.ItemAppearance = appearance1;
            this.UdsDateType.ItemOrigin = new System.Drawing.Point(2, 10);
            valueListItem2.DataValue = ((short)(0));
            valueListItem2.DisplayText = "日指定";
            valueListItem1.DataValue = valueListItem2;
            valueListItem1.DisplayText = "日指定";
            valueListItem4.DataValue = ((short)(1));
            valueListItem4.DisplayText = "週指定";
            valueListItem3.DataValue = valueListItem4;
            valueListItem3.DisplayText = "週指定";
            valueListItem6.DataValue = ((short)(2));
            valueListItem6.DisplayText = "月指定";
            valueListItem5.DataValue = valueListItem6;
            valueListItem5.DisplayText = "月指定";
            valueListItem8.DataValue = ((short)(3));
            valueListItem8.DisplayText = "全て";
            valueListItem7.DataValue = valueListItem8;
            valueListItem7.DisplayText = "全て";
            this.UdsDateType.Items.Add(valueListItem1);
            this.UdsDateType.Items.Add(valueListItem3);
            this.UdsDateType.Items.Add(valueListItem5);
            this.UdsDateType.Items.Add(valueListItem7);
            this.UdsDateType.ItemSpacingHorizontal = 2;
            this.UdsDateType.ItemSpacingVertical = 2;
            this.UdsDateType.Location = new System.Drawing.Point(3, 3);
            this.UdsDateType.Margin = new System.Windows.Forms.Padding(0);
            this.UdsDateType.Name = "UdsDateType";
            this.UdsDateType.Size = new System.Drawing.Size(242, 37);
            this.UdsDateType.TabIndex = 0;
            this.UdsDateType.ValueChanged += new System.EventHandler(this.ultraOptionSet1_ValueChanged);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem3,
            this.menuItem2,
            this.menuItem4});
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "この帳票を削除(&D)";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "同一ｸﾞﾙｰﾌﾟの帳票を削除(&G)";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "リストの帳票を全て削除(&A)";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Text = "ｶﾚﾝﾀﾞｰ指定日以前の帳票を削除(&S)";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // PrintItemInfoTimer
            // 
            this.PrintItemInfoTimer.Interval = 10;
            this.PrintItemInfoTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // NodeToolTip
            // 
            this.NodeToolTip.AutomaticDelay = 50;
            this.NodeToolTip.AutoPopDelay = 1000;
            this.NodeToolTip.InitialDelay = 50;
            this.NodeToolTip.ReshowDelay = 10;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.UdsDateType);
            this.panel1.Controls.Add(this.monthCalendar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(248, 190);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.UTlistVew);
            this.panel2.Controls.Add(this.ultraLabel1);
            this.panel2.Controls.Add(this.UdsDspType);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 190);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panel2.Size = new System.Drawing.Size(248, 456);
            this.panel2.TabIndex = 6;
            // 
            // UTlistVew
            // 
            this.UTlistVew.AccessibleDescription = "";
            this.UTlistVew.ColumnSettings.RootColumnSet = ultraTreeColumnSet1;
            this.UTlistVew.ContextMenu = this.contextMenu1;
            this.UTlistVew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UTlistVew.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.UTlistVew.HideSelection = false;
            this.UTlistVew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UTlistVew.Location = new System.Drawing.Point(3, 35);
            this.UTlistVew.Name = "UTlistVew";
            this.UTlistVew.Size = new System.Drawing.Size(242, 418);
            this.UTlistVew.TabIndex = 5;
            this.UTlistVew.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UTlistVew_MouseMove);
            this.UTlistVew.Click += new System.EventHandler(this.UTlistVew_Click);
            this.UTlistVew.DoubleClick += new System.EventHandler(this.UTlistVew_DoubleClick);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraLabel1.Location = new System.Drawing.Point(3, 32);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(242, 3);
            this.ultraLabel1.TabIndex = 6;
            // 
            // UdsDspType
            // 
            this.UdsDspType.Dock = System.Windows.Forms.DockStyle.Top;
            this.UdsDspType.ItemAppearance = appearance2;
            this.UdsDspType.ItemOrigin = new System.Drawing.Point(10, 3);
            valueListItem10.DataValue = ((short)(0));
            valueListItem10.DisplayText = "出力日基準";
            valueListItem9.DataValue = valueListItem10;
            valueListItem9.DisplayText = "出力日基準";
            valueListItem12.DataValue = ((short)(1));
            valueListItem12.DisplayText = "出力帳票基準";
            valueListItem11.DataValue = valueListItem12;
            valueListItem11.DisplayText = "出力帳票基準";
            this.UdsDspType.Items.Add(valueListItem9);
            this.UdsDspType.Items.Add(valueListItem11);
            this.UdsDspType.ItemSpacingVertical = 10;
            this.UdsDspType.Location = new System.Drawing.Point(3, 0);
            this.UdsDspType.Name = "UdsDspType";
            this.UdsDspType.Size = new System.Drawing.Size(242, 32);
            this.UdsDspType.TabIndex = 4;
            this.UdsDspType.ValueChanged += new System.EventHandler(this.UdsDspType_ValueChanged);
            // 
            // SFANL06101UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 12);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(248, 646);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "SFANL06101UA";
            this.Text = "出力帳票検索";
            this.Load += new System.EventHandler(this.SFUANL06101UA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UdsDateType)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UTlistVew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UdsDspType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFANL06101UA());
		}

		/// <summary>
		/// 帳票PDFの格納先(Path)
		/// </summary>
		public string PdfPath
		{
			get { return _PdfPath; }
			set { _PdfPath = value; }
		}
		/// <summary>
		/// 帳票XMLの格納先(Path)
		/// </summary>
		public string XmlPath
		{
			get { return _XmlPath; }
			set { _XmlPath = value; }
		}
		
		/// <summary>
		/// ログイン担当者
		/// </summary>
		public string LoginWorker
		{
			get { return _LoginWorker; }
			set { _LoginWorker = value; }
		}

		/// <summary>
		/// 帳票情報の追加
		/// </summary>
		public void SetPrintKey(string pPrintKey, string pPrintName)
		{
			// 帳票種類情報をインスタンス化
			PrintInfoItem PrtInf = new PrintInfoItem(pPrintKey, pPrintName);

			// XMLからの読み込みの為、データセットを生成する
			DataSet PrintDs = new DataSet(pPrintKey);
			// データテーブルを生成
			DataTable dtPrintInfo = new DataTable("PrintInfo");
			// データテーブルに追加
			dtPrintInfo = setPrintInfoDataTable();
			// データセットにデータテーブルを追加
			PrintDs.Tables.Add(dtPrintInfo);

			// データソースに XML のデータを読み込む。
			string FileName = FileNameAddPath(_XmlPath, pPrintKey+".xml");
			if (System.IO.File.Exists(FileName) == true)
			{
				// ロードする前に、データセットをクリアする。
				PrintDs.Clear();

				FileStream myFileStream = new FileStream(FileName, System.IO.FileMode.Open);
				XmlTextReader myXmlReader = new XmlTextReader(myFileStream);
				// XML ファイルから読み込む
				PrintDs.ReadXml(myXmlReader);   

				myXmlReader.Close();
			}

			// 帳票種類情報コレクションに登録する
			_PrintKindInfo.Add(PrtInf);

			// 印刷情報を展開する
			for(int ii = 0; ii < PrintDs.Tables["PrintInfo"].Rows.Count; ii++)
			{
				_PrintInfoItems.Add(new PrintInfoItem(pPrintKey,
					(DateTime)PrintDs.Tables["PrintInfo"].Rows[ii]["PrintOutDateTime"],
					(string)PrintDs.Tables["PrintInfo"].Rows[ii]["PdfFileName"],
					(string)PrintDs.Tables["PrintInfo"].Rows[ii]["PrintName"],
					(string)PrintDs.Tables["PrintInfo"].Rows[ii]["PrintDetailName"],
					(string)PrintDs.Tables["PrintInfo"].Rows[ii]["LoginWorkerName"]));
			}
		}

		/// <summary>
		/// 帳票情報の追加
		/// </summary>
		public void AddPrintInfo(string PrintKey, string PrintName, string PrintDetailName, string PdfFileName)
		{
			// データセットをインスタンス化
			DataSet PrintDs = new DataSet(PrintKey);
			// データテーブルをインスタンス化
			DataTable dtPrintInfo = new DataTable("PrintInfo");
			// データテーブルを設定する
			dtPrintInfo = setPrintInfoDataTable();
			
			// データセットにデータテーブルを追加
			PrintDs.Tables.Add(dtPrintInfo);

			// データソースに XML のデータを読み込む。
			string FileName = FileNameAddPath(_XmlPath, PrintKey+".xml");
			if (System.IO.File.Exists(FileName) == true)
			{
				// ロードする前に、データセットをクリアする。
				PrintDs.Clear();

				FileStream ReadStream = new FileStream(FileName, System.IO.FileMode.Open);
				XmlTextReader myXmlReader = new XmlTextReader(ReadStream);
				// XML ファイルから読み込む
				PrintDs.ReadXml(myXmlReader);   

				myXmlReader.Close();
			}

			DateTime dt = DateTime.Now;
			// データセットにレコードを追加する
			DataRow row;
			row = PrintDs.Tables["PrintInfo"].NewRow();
			row["PrintOutDateTime"] = dt;
			row["PdfFileName"] = PdfFileName;
			row["PrintName"] = PrintName;
			row["PrintDetailName"] = PrintDetailName;
			row["LoginWorkerName"] = _LoginWorker;
			PrintDs.Tables["PrintInfo"].Rows.Add(row);

			// データソースに XML のデータを書き込む。
			FileStream WriteStream = new FileStream(FileName, System.IO.FileMode.Create);
			XmlTextWriter myXmlWriter = new XmlTextWriter(WriteStream, System.Text.Encoding.UTF8);
			// インデントをつけて書き出すように指定する。
			myXmlWriter.Formatting = Formatting.Indented;
			// XML ファイルに書き出す
			PrintDs.WriteXml(myXmlWriter);
			myXmlWriter.Close();

			// コレクションに追加する
			_PrintInfoItems.Add(new PrintInfoItem(PrintKey, dt, PdfFileName, PrintName, PrintDetailName, _LoginWorker));
			// TreeVewを再描画する
			_PrintItemInfoChange = true;
		}
		
		/// <summary>
		/// 帳票情報の追加
		/// </summary>
		/// <param name="PrintKey">帳票KEY情報</param>
		/// <param name="PrintName">帳票名称</param>
		/// <param name="PrintDetailName">帳票詳細名称</param>
		/// <param name="PdfFileName">PDFファイル名</param>
		/// <param name="loginName">ログイン担当者名</param>
		/// <remarks>
		/// <br>Note       : 帳票の出力情報をXmlに書き込みます</br>
		/// <br>Programmer : 94012 K.Takeshita</br>
		/// <br>Date       : 2005.12.05</br>
		/// <br>Note       :    ・OverLoadでLogin担当者追加</br>
		/// </remarks>
		public void AddPrintInfo(string PrintKey, string PrintName, string PrintDetailName, string PdfFileName, string loginName)
		{
			this._LoginWorker = loginName;
			AddPrintInfo(PrintKey, PrintName, PrintDetailName, PdfFileName);
		}

		/// <summary>
		/// 重複チェック処理
		/// </summary>
		/// <param name="printKey">帳票KEY情報</param>
		/// <param name="pdfFileName">PDFファイル名</param>
		/// <remarks>
		/// <br>Note       : 該当ＰＤＦファイルの重複チェックを行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.04.13</br>
		/// </remarks>
		public bool Contains(string printKey, string pdfFileName)
		{
			foreach (PrintInfoItem itm in _PrintInfoItems)
			{
				if (itm.PrintKey.Equals(printKey) &&
					itm.PdfFileName.Equals(pdfFileName))
				{
					return true;
				}
			}
			return false;
		}
		
		/// <summary>
		/// 帳票情報の追加
		/// </summary>
		private DataTable setPrintInfoDataTable()
		{
			// データテーブルを生成
			DataTable dtPrintInfo = new DataTable("PrintInfo");
			// データColm追加(発行日時)
			DataColumn colPrintOutDateTime = new DataColumn();
			colPrintOutDateTime.ColumnName = "PrintOutDateTime";
			colPrintOutDateTime.DataType   = typeof(DateTime);
			colPrintOutDateTime.Unique     = false;
			dtPrintInfo.Columns.Add(colPrintOutDateTime);
			// データColm追加(PDFファイル名)
			DataColumn colPdfFileName      = new DataColumn();
			colPdfFileName.ColumnName      = "PdfFileName";
			colPdfFileName.DataType        = typeof(string);
			colPdfFileName.Unique          = true;			// 主キー
			dtPrintInfo.Columns.Add(colPdfFileName);
			// データColm追加(帳票名)
			DataColumn colPrintName        = new DataColumn();
			colPrintName.ColumnName        = "PrintName";
			colPrintName.DataType          = typeof(string);
			colPrintName.Unique            = false;
			dtPrintInfo.Columns.Add(colPrintName);
			// データColm追加(帳票名詳細)
			DataColumn colPrintDetailName  = new DataColumn();
			colPrintDetailName.ColumnName  = "PrintDetailName";
			colPrintDetailName.DataType    = typeof(string);
			colPrintDetailName.Unique      = false;
			dtPrintInfo.Columns.Add(colPrintDetailName);
			// データColm追加(発行者)
			DataColumn colLoginWorkerName = new DataColumn();
			colLoginWorkerName.ColumnName = "LoginWorkerName";
			colLoginWorkerName.DataType   = typeof(string);
			colLoginWorkerName.Unique     = false;
			dtPrintInfo.Columns.Add(colLoginWorkerName);

			return dtPrintInfo;
		}

		/// **********************************************************************
		/// ivent name       : ultraOptionSet1_ValueChanged
		/// <summary>
		///                    日付け指定ボタンクリックイベント
		/// </summary>
		/// <param name="sender">
		///                    クリックされたオブジェクト
		/// </param>
		/// <param name="e">
		///                    イベント データ
		/// </param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note　　　　　　 :   日付け指定ボタンクリック時に発生します</br>
		/// <br>Programer       :   日並　征二郎</br>
		/// <br>Date            :   2005.03.18</br>
		/// <br>Update Note     :   </br>
		/// </remarks>
		/// **********************************************************************
		private void ultraOptionSet1_ValueChanged(object sender, System.EventArgs e)
		{
			if (UdsDateType.Value != null)
			{
                switch (UdsDateType.CheckedIndex) 
				{
					case 0:
						// 日付指定の場合
						monthCalendar.SelectionStart = _CalenderDate;
						monthCalendar.MaxSelectionCount = 1;
						monthCalendar.ForeColor = ctActiveForeColor;
						monthCalendar.Enabled = true;
						break;
					case 1:
						// 週間表示の場合
						monthCalendar.MaxSelectionCount = 7;
						monthCalendar.ForeColor = ctActiveForeColor;
						monthCalendar.Enabled = true;
						break;
					case 2:
						// 月間表示の場合
						monthCalendar.MaxSelectionCount = 31;
						monthCalendar.ForeColor = ctActiveForeColor;
						monthCalendar.Enabled = true;
						break;
					default:
						// 全ての場合
                        //2007/01/15 H.NAKAMURA DEL START //////////////////////////////////////////////////////////
                        //Vistaの場合MaxSelectionCount=1とすると選択されていたものが解除されてしまう(XPでは問題なし)
                        //全ての場合はそれ以外のMaxSelectionCountを引き継ぐことにする。                       
						//monthCalendar.MaxSelectionCount = 1;
                        //DEL END //////////////////////////////////////////////////////////////////////////////////
						monthCalendar.ForeColor = ctReadOnlyForeColor;
						monthCalendar.Enabled = false;
						break;
				}
				setMonthCalendarDateRange();
			}
		}

		/// **********************************************************************
		/// ivent name       : monthCalendar_DateChanged
		/// <summary>
		///                    カレンダーの日付を変更した場合に発生するイベント
		/// </summary>
		/// <param name="sender">
		///                    クリックされたオブジェクト
		/// </param>
		/// <param name="e">
		///                    イベント データ
		/// </param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note　　　　　　 :   カレンダーの日付けを変更した際に発生します</br>
		/// <br>Programer       :   日並　征二郎</br>
		/// <br>Date            :   2005.03.18</br>
		/// <br>Update Note     :   </br>
		/// </remarks>
		/// **********************************************************************
		private void monthCalendar_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e)
		{
			if (_DateRangeChage == false)
			{
				setMonthCalendarDateRange();

				if (UdsDateType.Value != null)
				{
					if(UdsDateType.CheckedIndex == 0) 
					{
						_CalenderDate = this.monthCalendar.SelectionStart;
					}
				}
			}
		}
		/// **********************************************************************
		/// ivent name       : SFUANL06101UA_Load
		/// <summary>
		///                    画面を生成する際に発生するイベント
		/// </summary>
		/// <param name="sender">
		///                    生成する画面のオブジェクト
		/// </param>
		/// <param name="e">
		///                    イベント データ
		/// </param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note　　　　　　 :   画面を生成する際に発生するイベント</br>
		/// <br>Programer       :   日並　征二郎</br>
		/// <br>Date            :   2005.03.18</br>
		/// <br>Update Note     :   </br>
		/// </remarks>
		/// **********************************************************************
		private void SFUANL06101UA_Load(object sender, System.EventArgs e)
		{
			// データを設定（表示）する
			setListData();
			// 画面起動の場合は、タイマを起動する。
			PrintItemInfoTimer.Enabled = true;
			PrintItemInfoTimer.Interval = 10;
			PrintItemInfoTimer.Start();
		}

		/// **********************************************************************
		/// ivent name       : UdsDspType_ValueChanged
		/// <summary>
		///                    表示方式（帳票別/日付別）を変更した場合に発生するイベント
		/// </summary>
		/// <param name="sender">
		///                    変更されたオブジェクト
		/// </param>
		/// <param name="e">
		///                    イベント データ
		/// </param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note　　　　　　 :   表示方式（帳票別/日付別）を変更した場合に発生する</br>
		/// <br>Programer       :   日並　征二郎</br>
		/// <br>Date            :   2005.03.18</br>
		/// <br>Update Note     :   </br>
		/// </remarks>
		/// **********************************************************************
		private void UdsDspType_ValueChanged(object sender, System.EventArgs e)
		{
			setListData();
		}

		/// **********************************************************************
		/// ivent name       : UTlistVew_DoubleClick
		/// <summary>
		///                    ノードをダブルクリックした際に発生するイベント
		/// </summary>
		/// <param name="sender">
		///                    ダブルクリックされたオブジェクト
		/// </param>
		/// <param name="e">
		///                    イベント データ
		/// </param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note　　　　　　 :   ノードをダブルクリックした際に発生する</br>
		/// <br>Programer       :   日並　征二郎</br>
		/// <br>Date            :   2005.03.18</br>
		/// <br>Update Note     :   </br>
		/// </remarks>
		/// **********************************************************************
		private void UTlistVew_DoubleClick(object sender, System.EventArgs e)
		{
			// 権限のチェック		2008.03.11 Y.Sasaki ADD
			if (this.CheckRoleManeger() != 0) return;

			PrintInfoItem Itm = new PrintInfoItem();
			// ノードを１個以上、選択しているか？
			if(UTlistVew.SelectedNodes.Count > 0)
			{
				// 選択されたノードの情報をコレクションから取得する
				Itm = NodeKeyToItem(UTlistVew.SelectedNodes[0].Key);
				if (Itm != null)
				{
					// デリゲート登録されているか？
					if (SelectNode != null)
					{
						// デリゲートされているイベントを起動する
						SelectNode(Itm.PrintKey, Itm.PrintName, Itm.PdfFileName);
					}
				}
			}
		}

		/// **********************************************************************
		/// ivent name       : UTlistVew_MouseMove
		/// <summary>
		///                    ツリー上でマウスを移動した際に発生するイベント
		/// </summary>
		/// <param name="sender">
		///                    フォーカスのあるオブジェクト
		/// </param>
		/// <param name="e">
		///                    イベント データ
		/// </param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note　　　　　　 :   ツリー上でマウスを移動した際に発生する</br>
		/// <br>Programer       :   日並　征二郎</br>
		/// <br>Date            :   2005.03.18</br>
		/// <br>Update Note     :   </br>
		/// </remarks>
		/// **********************************************************************
		private void UTlistVew_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(NodeToolTip != null)
			{
				Infragistics.Win.UltraWinTree.UltraTree ut = (Infragistics.Win.UltraWinTree.UltraTree)sender;
				//マウスポインタのあるアイテムを取得
				Infragistics.Win.UltraWinTree.UltraTreeNode Utn = ut.GetNodeFromPoint(e.X, e.Y);
				//ポイントされているアイテムが変わった時
				if (Utn != _LastUltraTreeNode)
				{
					// ToolTipがActiveな場合、Active解除
					if(NodeToolTip.Active)
						NodeToolTip.Active = false;
					if (Utn != null)
					{
						// ポイントされているノードの情報をコレクションから取得
						PrintInfoItem Itm = new PrintInfoItem();
						Itm = NodeKeyToItem(Utn.Key);
						if (Itm != null)
						{
							//ToolTipのテキストを設定する
							NodeToolTip.SetToolTip(ut, Itm.PrintDetailName+"  発行者："+Itm.LoginWorkerName);
							//ToolTipを再びアクティブにする
							NodeToolTip.Active = true;
						}
					}
					// ポイントされているノードを記憶する
					_LastUltraTreeNode = Utn;
				}
			}
		}

		/// **********************************************************************
		/// ivent name       : timer1_Tick
		/// <summary>
		///                    ツリー上でマウスを移動した際に発生するイベント
		/// </summary>
		/// <param name="sender">
		///                    タイマーオブジェクト
		/// </param>
		/// <param name="e">
		///                    イベント データ
		/// </param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note　　　　　　 :   タイマーが起動された際に発生する</br>
		/// <br>Programer       :   日並　征二郎</br>
		/// <br>Date            :   2005.03.18</br>
		/// <br>Update Note     :   </br>
		/// </remarks>
		/// **********************************************************************
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			// タイマーをストップする
			PrintItemInfoTimer.Stop();
			if (_PrintItemInfoChange == true)
			{
				_PrintItemInfoChange = false;
				setListData();
			}
			// タイマーをスタートする
			PrintItemInfoTimer.Start();
		}

		/// **********************************************************************
		/// Module name			: setMonthCalendarDateRange
		/// <summary>
		///						カレンダー日付の設定処理  
		/// </summary>
		/// <param>
		///						none
		/// </param>
		/// <returns>
		///						none
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note			:   カレンダーのプロパティを変更する</br>
		/// <br>Programer		:   日並　征二郎</br>
		/// <br>Date			:   2005.03.18</br>
		/// <br>Update Note		:   </br>
		/// </remarks>
		/// **********************************************************************
		private void setMonthCalendarDateRange()
		{
			System.DateTime dt, sdt, edt;

			if (UdsDateType.Value != null)
			{
				_DateRangeChage = true;
				dt = sdt = edt = monthCalendar.SelectionStart;
				switch (UdsDateType.CheckedIndex) 
				{
					case 0:
						// 日間表示の場合
						monthCalendar.SelectionStart = dt;
						monthCalendar.SelectionEnd   = dt;
						break;
					case 1:
						// 週間表示の場合
						switch (dt.DayOfWeek)
						{
							case DayOfWeek.Sunday  :
								sdt = dt;
								edt = dt.AddDays(6);
								break;
							case DayOfWeek.Monday :
								sdt = dt.AddDays(-1);
								edt = dt.AddDays(5);
								break;
							case DayOfWeek.Tuesday  :
								sdt = dt.AddDays(-2);
								edt = dt.AddDays(4);
								break;
							case DayOfWeek.Wednesday  :
								sdt = dt.AddDays(-3);
								edt = dt.AddDays(3);
								break;
							case DayOfWeek.Thursday  :
								sdt = dt.AddDays(-4);
								edt = dt.AddDays(2);
								break;
							case DayOfWeek.Friday  :
								sdt = dt.AddDays(-5);
								edt = dt.AddDays(1);
								break;
							case DayOfWeek.Saturday  :
								sdt = dt.AddDays(-6);
								edt = dt;
								break;
						};
						monthCalendar.SelectionStart = sdt;
						monthCalendar.SelectionEnd   = edt;
						break;
					case 2:
						// 月間表示の場合
						sdt = new DateTime(dt.Year, dt.Month, 1);
						edt = new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));
						monthCalendar.MaxSelectionCount = DateTime.DaysInMonth(dt.Year, dt.Month);
						monthCalendar.SelectionStart = sdt;
						monthCalendar.SelectionEnd   = edt;
						//2007/01/15 H.NAKAMURA DEL START //////////////////////////////////////////////////////////
                        //Vistaの場合MaxSelectionCount=1とすると選択されていたものが解除されてしまう(XPでは問題なし)
                        //よってMaxSelectionCountを変更しない。
						//monthCalendar.MaxSelectionCount = 1;
                        ////DEL END ////////////////////////////////////////////////////////////////////////////////
						break;
					default:
						break;
				}
				_DateRangeChage = false;

				setListData();
			}
		}

		/// <summary>
		/// 日時文字列をDateTime型に変換する
		/// </summary>
		/// **********************************************************************
		/// Module name			: setMonthCalendarDateRange
		/// <summary>
		///						日時文字列をDateTime型に変換する  
		/// </summary>
		/// <param name="dateTimeString">
		///						none
		/// </param>
		/// <returns>
		///						none
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note			:   カレンダーのプロパティを変更する</br>
		/// <br>Programer		:   日並　征二郎</br>
		/// <br>Date			:   2005.03.18</br>
		/// <br>Update Note		:   </br>
		/// </remarks>
		/// **********************************************************************
		private DateTime ToDateTime(string dateTimeString)
		{
			return System.DateTime.ParseExact(dateTimeString,
				"yyyyMMddHHmmss",
				System.Globalization.DateTimeFormatInfo.InvariantInfo,
				System.Globalization.DateTimeStyles.None);
		}


		/// <summary>
		/// 日付範囲の帳票を抽出する
		/// </summary>
		private void setListData()
		{
			if (_PdfPath == null || _PrintKindInfo.Count == 0) return;
			if (UdsDateType.Value != null)
			{
				if (UdsDspType.CheckedIndex == 0) 
				{
					setListVewOfDate();
				}
				else
				{
					setListVewOfPrintKey();
				}
			}
		}

		/// <summary>
		/// 帳票タイプでツリービューを設定する
		/// </summary>
		private void setListVewOfPrintKey()
		{
			string wstr;								// 文字列編集ワーク
			DateTime dt = DateTime.MinValue;			// 日付ワーク(初期値=MinValue)
			UTlistVew.Nodes.Clear();					// ツリービューのノードを初期化
			ArrayList PrtItmList = new ArrayList();		// 日付単位の設定用コレクション

			// 指定日付を変換
			int DateType = UdsDateType.CheckedIndex;
			if (DateType == 3)
			{
				// 全件抽出の場合

				// 帳票種別
				foreach(PrintInfoItem PrtKidInf in _PrintKindInfo)
				{
					// コレクション初期化
					PrtItmList.Clear();
					// 日付ソート用インターフェース生成
					PrintInfoComparer pc = new PrintInfoComparer();
					pc.Key = PrintInfoComparer.SortKey.PrintOutDateTime;
					// 降順を指定
					pc.Order = SortOrder.Descending;
					// 日付でソートする
					_PrintInfoItems.Sort(pc);
					// 日付で検索する
					foreach (PrintInfoItem Itm in _PrintInfoItems)
					{
						// 帳票種別は同じであるか？
						if (PrtKidInf.PrintKey == Itm.PrintKey)
						{
							// アイテムを追加する
							PrtItmList.Add(Itm);
						}
					}
					// コレクションの中身をTreeVewに設定する(種別ごとに)
					if (PrtItmList.Count > 0)
					{
						// 親ノードを生成
						wstr = PrtKidInf.PrintName;
						Infragistics.Win.UltraWinTree.UltraTreeNode topNode = new Infragistics.Win.UltraWinTree.UltraTreeNode("",wstr);
						foreach (PrintInfoItem DspItm in PrtItmList)
						{
							// 子ノードを追加する
							topNode.Nodes.Add(setNodePrintDate(DspItm));
						}
						// ツリービューを表示する
						UTlistVew.Nodes.Add(topNode);
					}
				}
				UTlistVew.ExpandAll();
			}
			else 
			{
				// 日付/週間/月間検索の場合
				foreach(PrintInfoItem PrtKidInf in _PrintKindInfo)
				{
					// コレクション初期化
					PrtItmList.Clear();
					// 日付範囲
					TimeSpan ts = monthCalendar.SelectionRange.End - monthCalendar.SelectionRange.Start;
					for(int xx = ts.Days +1; xx > 0; xx--)
					{
						// 週間検索の場合
						dt = monthCalendar.SelectionStart.AddDays(xx-1);
						// 日付ソート用インターフェース生成
						PrintInfoComparer pc = new PrintInfoComparer();
						pc.Key = PrintInfoComparer.SortKey.PrintOutDate;
						// 昇順を指定
						pc.Order = SortOrder.Ascending;
						// 日付でソートする
						_PrintInfoItems.Sort(pc);
						// 日付で検索する 
						int st = _PrintInfoItems.BinarySearch(new PrintInfoItem(null, dt, null, null, null, null), pc);
						if (st >= 0)
						{
							int StartPos = st;
							PrintInfoItem Itm = new PrintInfoItem();
							// スタート位置を検索（前方に同じものがあるか）
							for(int zz=st; zz >= 0 ;zz--)
							{
								Itm = (PrintInfoItem)_PrintInfoItems[zz];
								if (Itm.PrintOutDateTime.Date != dt.Date) break;
								StartPos = zz;
							}
							// リストを生成する
							for(int ii=StartPos; ii < _PrintInfoItems.Count; ii++)
							{
								// ArrayListをCastする
								Itm = (PrintInfoItem)_PrintInfoItems[ii];
								// 日付が一致しているか？
								if (Itm.PrintOutDateTime.Date != dt.Date) break;
								// 印刷種別が一致しているか？
								if (Itm.PrintKey == PrtKidInf.PrintKey)
								{
									// アイテムを追加する
									PrtItmList.Add(Itm);
								}
							}
						}
					}
					// コレクションの中身をTreeVewに設定する
					if (PrtItmList.Count > 0)
					{
						// 日付ソート用インターフェース生成
						PrintInfoComparer pc2 = new PrintInfoComparer();
						pc2.Key = PrintInfoComparer.SortKey.PrintOutDateTime;
						// 昇順を指定
						pc2.Order = SortOrder.Descending;
						// 日付でソートする
						PrtItmList.Sort(pc2);
						// 親ノードを生成
						wstr = PrtKidInf.PrintName;
						Infragistics.Win.UltraWinTree.UltraTreeNode topNode = new Infragistics.Win.UltraWinTree.UltraTreeNode("",wstr);
						foreach (PrintInfoItem DspItm in PrtItmList)
						{
							// 子ノードを追加する
							topNode.Nodes.Add(setNodePrintDate(DspItm));
						}
						// ツリービューを表示する
						UTlistVew.Nodes.Add(topNode);
					}
				}
				// ツリービューのノードを表示する
				UTlistVew.ExpandAll();
			}
		}

		/// <summary>
		/// 子ノード生成する（日付）
		/// </summary>
		private Infragistics.Win.UltraWinTree.UltraTreeNode setNodePrintDate(PrintInfoItem DspItm)
		{
			string  wstr;
			// 子ノードを追加する
			wstr = DspItm.PrintOutDateTime.ToString("yyyy年MM月dd日(ddd) HH:mm");
			Infragistics.Win.UltraWinTree.UltraTreeNode ChildNode = new Infragistics.Win.UltraWinTree.UltraTreeNode(DspItm.Id.ToString(),wstr);
			ChildNode.LeftImages.Add(this.imageList1.Images[0]);
			return ChildNode;
		}

		/// <summary>
		/// 日付でツリービューを設定する
		/// </summary>
		private void setListVewOfDate()
		{
			string wstr;								// 文字列編集ワーク
			DateTime dt = DateTime.MinValue;			// 日付ワーク(初期値=MinValue)
			UTlistVew.Nodes.Clear();					// ツリービューのノードを初期化
			ArrayList PrtItmList = new ArrayList();		// 日付単位の設定用コレクション

			// 指定日付を変換
			int DateType = UdsDateType.CheckedIndex;
			if (DateType == 3)
			{
				// 全件抽出の場合
				// 日付ソート用インターフェース生成
				PrintInfoComparer pc = new PrintInfoComparer();
				pc.Key = PrintInfoComparer.SortKey.PrintOutDateTime;
				// 降順を指定
				pc.Order = SortOrder.Descending;
				// 日付でソートする
				_PrintInfoItems.Sort(pc);
				// 日付で検索する
				foreach (PrintInfoItem Itm in _PrintInfoItems)
				{
					// 日付が一致しているか？
					if (Itm.PrintOutDateTime.Date != dt.Date)
					{
						// コレクションの中身をTreeVewに設定する
						if (PrtItmList.Count > 0)
						{
							// 親ノードを生成
							wstr = dt.ToString("yyyy年MM月dd日(ddd)");
							Infragistics.Win.UltraWinTree.UltraTreeNode topNode = new Infragistics.Win.UltraWinTree.UltraTreeNode("",wstr);
							foreach (PrintInfoItem DspItm in PrtItmList)
							{
								// 子ノードを追加する
								topNode.Nodes.Add(SetNodePrintName(DspItm));
							}
							// ツリービューを表示する
							UTlistVew.Nodes.Add(topNode);
						}
						// 日付けを待避する
						dt = Itm.PrintOutDateTime;
						// コレクション初期化
						PrtItmList.Clear();
					}
					// アイテムを追加する
					PrtItmList.Add(Itm);
				}
				// コレクションの中身をTreeVewに設定する
				if (PrtItmList.Count > 0)
				{
					// 親ノードを生成
					wstr = dt.ToString("yyyy年MM月dd日(ddd)");
					Infragistics.Win.UltraWinTree.UltraTreeNode topNode = new Infragistics.Win.UltraWinTree.UltraTreeNode("",wstr);
					foreach (PrintInfoItem DspItm in PrtItmList)
					{
						// 子ノードを追加する
						topNode.Nodes.Add(SetNodePrintName(DspItm));
					}
					// ツリービューを表示する
					UTlistVew.Nodes.Add(topNode);
				}
				UTlistVew.ExpandAll();
			}
			else 
			{
				// 日付/週間/月間検索の場合
				TimeSpan ts = monthCalendar.SelectionRange.End - monthCalendar.SelectionRange.Start;
				for(int xx = ts.Days +1; xx > 0; xx--)
				{
					// コレクション初期化
					PrtItmList.Clear();
					// 週間検索の場合
					dt = monthCalendar.SelectionStart.AddDays(xx-1);
					// 日付ソート用インターフェース生成
					PrintInfoComparer pc = new PrintInfoComparer();
					pc.Key = PrintInfoComparer.SortKey.PrintOutDate;
					// 昇順を指定
					pc.Order = SortOrder.Ascending;
					// 日付でソートする
					_PrintInfoItems.Sort(pc);
					// 日付で検索する 
					int st = _PrintInfoItems.BinarySearch(new PrintInfoItem(null, dt, null, null, null, null), pc);
					if (st >= 0)
					{
						int StartPos = st;
						PrintInfoItem Itm = new PrintInfoItem();
						// スタート位置を検索（前方に同じものがあるか）
						for(int zz=st; zz >= 0 ;zz--)
						{
							Itm = (PrintInfoItem)_PrintInfoItems[zz];
							if (Itm.PrintOutDateTime.Date != dt.Date) break;
							StartPos = zz;
						}
						// リストを生成する
						for(int ii=StartPos; ii < _PrintInfoItems.Count; ii++)
						{
							// ArrayListをCastする
							Itm = (PrintInfoItem)_PrintInfoItems[ii];
							// 日付が一致しているか？
							if (Itm.PrintOutDateTime.Date != dt.Date) break;
							// アイテムを追加する
							PrtItmList.Add(Itm);
						}
					}
					// コレクションの中身をTreeVewに設定する
					if (PrtItmList.Count > 0)
					{
						// 日付ソート用インターフェース生成
						PrintInfoComparer pc2 = new PrintInfoComparer();
						pc2.Key = PrintInfoComparer.SortKey.PrintOutDateTime;
						// 昇順を指定
						pc2.Order = SortOrder.Descending;
						// 日付でソートする
						PrtItmList.Sort(pc2);

						// 親ノードを生成
						wstr = dt.ToString("yyyy年MM月dd日(ddd)");
						Infragistics.Win.UltraWinTree.UltraTreeNode topNode = new Infragistics.Win.UltraWinTree.UltraTreeNode("",wstr);
						foreach (PrintInfoItem DspItm in PrtItmList)
						{
							// 子ノードを追加する
							topNode.Nodes.Add(SetNodePrintName(DspItm));
						}
						// ツリービューを表示する
						UTlistVew.Nodes.Add(topNode);
					}
				}
				UTlistVew.ExpandAll();
			}
		}

		/// <summary>
		/// 子ノード生成する（帳票）
		/// </summary>
		private Infragistics.Win.UltraWinTree.UltraTreeNode SetNodePrintName(PrintInfoItem DspItm)
		{
			string  wstr;
			wstr = DspItm.PrintName+DspItm.PrintOutDateTime.ToString(" HH:mm");
			Infragistics.Win.UltraWinTree.UltraTreeNode ChildNode = new Infragistics.Win.UltraWinTree.UltraTreeNode(DspItm.Id.ToString(),wstr);
			ChildNode.LeftImages.Add(this.imageList1.Images[0]);
			return ChildNode;
		}

		/// <summary>
		/// 帳票印刷設定
		/// </summary>
		private string FileNameAddPath(string path, string FileName)
		{
			return path + "\\" + FileName;
		}

		/// <summary>
		/// ノードＫＥＹよりＩｔｅｍを取得する
		/// </summary>
		private PrintInfoItem NodeKeyToItem(string NodeKey)
		{
			PrintInfoItem result = new PrintInfoItem();
			result = null;
			if ( NodeKey.Length > 0 && NodeKey != null )
			{
				// ノードに埋めたKEY（Guid)をGuid型に変換する
				GuidConverter gc = new GuidConverter();
				Guid wId = (Guid)gc.ConvertFromString(NodeKey);

				// Guidソート用インターフェース生成
				PrintInfoComparer pc = new PrintInfoComparer();
				pc.Key = PrintInfoComparer.SortKey.Id;
				_PrintInfoItems.Sort(pc);

				// Guidで検索する 
				int st = _PrintInfoItems.BinarySearch(new PrintInfoItem(wId, null, DateTime.Now, null, null, null, null), pc);
				if (st >= 0)
				{
					// 選択したPDFのファイル情報を取得する
					result = (PrintInfoItem)_PrintInfoItems[st];
				}
			}
			return result;
		}

		/// <summary>
		/// 削除メニューポップアップ
		/// </summary>
		private void contextMenu1_Popup(object sender, System.EventArgs e)
		{
			PrintInfoItem Itm = new PrintInfoItem();

			// ノードを１個以上、選択しているか？
			if(UTlistVew.SelectedNodes.Count > 0)
			{
				// 選択されたノードの情報をコレクションから取得する
				Itm = NodeKeyToItem(UTlistVew.SelectedNodes[0].Key);
			}
			//ツリー上でアイテムが未選択の時はポップアップしない
			if ( UTlistVew.SelectedNodes.Count == 0     ||   //アイテム未選択
				this._LastUltraTreeNode       == null ||   //前回選択無し
				Itm                           == null )    //印刷情報無し＝帳票でない部分が選択されている
			{
				contextMenu1.MenuItems[0].Visible = false;	//このﾌｧｲﾙを削除
				contextMenu1.MenuItems[1].Visible = false;	//同一ｸﾞﾙｰﾌﾟの帳票を削除
				contextMenu1.MenuItems[2].Visible = false;	//リストの帳票を全て削除(&A)
				//contextMenu1.MenuItems[3].Visible = false;	//ｶﾚﾝﾀﾞｰ指定日以前の帳票を削除
			}
			else
			{
				contextMenu1.MenuItems[0].Visible = true;	//このﾌｧｲﾙを削除
				contextMenu1.MenuItems[1].Visible = true;	//同一ｸﾞﾙｰﾌﾟの帳票を削除
				contextMenu1.MenuItems[2].Visible = true;	//リストの帳票を全て削除(&A)
				//contextMenu1.MenuItems[3].Visible = true;	//ｶﾚﾝﾀﾞｰ指定日以前の帳票を削除
			}
			contextMenu1.MenuItems[3].Visible = true;	//ｶﾚﾝﾀﾞｰ指定日以前の帳票を削除
		}

		/// <summary>
		/// 削除メニュー選択
		/// </summary>
		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			// 権限のチェック		2008.03.11 Y.Sasaki ADD
			if (this.CheckRoleManeger() != 0) return;

			//現在のマウスポインタがある位置が、最後に選択されているものか確認
			if (this._LastUltraTreeNode != null)
			{
				// ポイントされているノードの情報をコレクションから取得
				PrintInfoItem Itm = new PrintInfoItem();
				Itm = NodeKeyToItem(_LastUltraTreeNode.Key);
				if (Itm != null)
				{
					/*
										//削除メッセージ表示
		//                  MessageBox.Show("この帳票を削除します。よろしいですか？ \n\r"+
																		Itm.PrintName + "  " + Itm.PrintOutDateTime.ToShortDateString() + " " +
																														Itm.PrintOutDateTime.ToShortTimeString()
										);*/
				}
				else
				{
					return;
				}
		            
				// 選択されたノードの情報をコレクションから取得する
				Itm = NodeKeyToItem(UTlistVew.SelectedNodes[0].Key);
				if (Itm != null)
				{
					try //例外処理で
					{
						File.Delete(Itm.PdfFileName);
					}
					catch
					{
						//                      MessageBox.Show(
						//                          "現在表示中のため削除できません。",
						//                          "削除できません",
						//                          MessageBoxButtons.OK,
						//                          MessageBoxIcon.Error,
						//                          MessageBoxDefaultButton.Button1);
						MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "現在表示中のため削除できません。",-1,"menuItem1_Click");
						return;
					}
					finally
					{
						// いらないかも
					}

					//選択されたノードを削除する
					UTlistVew.SelectedNodes[0].Remove();

					// ファイル名で検索する
					//_PrintInfoItemsから削除する
					foreach (PrintInfoItem prtItm in _PrintInfoItems)
					{
						// 帳票種別は同じであるか？  
						//if (prtItm.PrintKey == Itm.PrintKey)                                             // 2010.11.09 del honda 
                        if ((prtItm.PrintKey == Itm.PrintKey) && (prtItm.PdfFileName == Itm.PdfFileName))  // 2010.11.09 add honda 
						{
							// アイテムを削除する
							_PrintInfoItems.Remove(prtItm);
							//XMLファイルを削除する
							DeletePrintInfXML(prtItm);
							break;
						}
					}//foreach
				}
			}
		}

		private void UTlistVew_Click(object sender, System.EventArgs e)
		{
			//TODO: 左クリックでも右クリックしたようにする

		}

		/// <summary>
		/// XMLファイルより印刷情報を削除します。
		/// </summary>
		/// <param name="prtItm">削除対象印刷情報</param>
		private void DeletePrintInfXML(PrintInfoItem prtItm)
		{
			//XMLファイルの読込
			string FileName = FileNameAddPath(_XmlPath, prtItm.PrintKey + ".xml");
			if (System.IO.File.Exists(FileName) == false) return; //ﾌｧｲﾙ無しはEXIT
		            
			//XMLの指定タグの子ノードリスト(TAGのリスト)を取得
			XmlDocument xmldoc = new XmlDocument();
			xmldoc.Load(FileName);
			XmlNodeList xmlList = xmldoc.GetElementsByTagName("PrintInfo");
			if (xmlList.Count == 0) return;

			//子ノードリストより各ノード（TAG）を取得
			bool breakFlg = false;
			foreach(XmlNode listNode in xmlList)
			{
				XmlNode childNode = listNode.FirstChild;            //最初のTAGを取得
				while(childNode != null)
				{
					XmlNode childnextNode = childNode.NextSibling;  //次のTAGを取得しておく

					//削除対象のPDFファイルパスと同じ記述のある
					//TAGの記述を全て削除することでXML上の印刷情報を削除する。
					if (childNode.LocalName == "PdfFileName")
					{
						if (childNode.InnerText == prtItm.PdfFileName)
						{
							listNode.ParentNode.RemoveChild(listNode);
							xmldoc.Save(FileName);
							breakFlg = true;
							break;
						}
					}
					childNode = childnextNode;
				}
				if (breakFlg) break;
			}

			//印刷情報が全て削除された場合はファイルを削除する
			if (xmldoc.GetElementsByTagName("PrintInfo").Count == 0)
			{
				try
				{
					File.Delete(FileName);
				}
				catch
				{
				}
			}
		        
		}

// ------------------------------------------------------>>MOTO

		/// <summary>
		/// 全印刷ファイル削除処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : リストにあるPDFファイルを全て削除します。</br>
		/// <br>Programmer : 90030 松林　真二</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			// 権限のチェック		2008.03.11 Y.Sasaki ADD
			if (this.CheckRoleManeger() != 0) return;

			//TODO:(ﾟДﾟ)ﾉ ｧｨ ここではリストにある全ファイルを削除します
			//リストにある情報を取得し、削除します
			PrintInfoItem Itm = new PrintInfoItem();

			//①親ノードで検索します
			foreach (Infragistics.Win.UltraWinTree.UltraTreeNode wTreeNode in UTlistVew.Nodes)
			{
				//②親ノードに付随する子ノードの情報を取得します
				int NodesCount = wTreeNode.Nodes.Count;
				for (int ix = NodesCount-1; ix >= 0 ; ix--)
				{
					Itm = NodeKeyToItem(wTreeNode.Nodes[ix].Key);
					if (Itm != null)
					{
						int ErrStatus = 0;
						PdfFileDeleteProc(Itm, ErrStatus);
						if (ErrStatus != 0 )
						{
//					        MessageBox.Show(
//						    "現在表示中のため削除できません。",
//						    "削除できません",
//						    MessageBoxButtons.OK,
//						    MessageBoxIcon.Error,
//						    MessageBoxDefaultButton.Button1);
                            MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "現在表示中のため削除できません。",-1,"menuItem2_Click");
                            return;
						}//if (ErrStatus != 0 )
					}//if (Itm != null)
				}//for (int ix = NodesCount-1; ix >= 0 ; ix--)
			}//foreach-Parent

			//再度リスト表示を行います
			setListData();
		}

		/// <summary>
		/// 同一グループ印刷ファイル削除処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : リストにある指定したグループのPDFファイルを削除します。</br>
		/// <br>Programmer : 90030 松林　真二</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			// 権限のチェック		2008.03.11 Y.Sasaki ADD
			if (this.CheckRoleManeger() != 0) return;

			//TODO:(´・ｪ・｀) 指定したグループのPDFファイルを削除します
			//リストにある情報を取得し、削除します
			PrintInfoItem Itm = new PrintInfoItem();

			//①子ノードに対する親ノードの情報を取得します
			Infragistics.Win.UltraWinTree.UltraTreeNode wTreeNode = new Infragistics.Win.UltraWinTree.UltraTreeNode();
			Infragistics.Win.UltraWinTree.UltraTreeNode wTreeNodeParent = new Infragistics.Win.UltraWinTree.UltraTreeNode();
			wTreeNode = UTlistVew.SelectedNodes[0];	//子ノード情報
			wTreeNodeParent = wTreeNode.Parent;		//子に対する親ノード情報
			
			//②親ノードに付随する子ノードの情報を取得します
			int NodesCount = wTreeNode.Parent.Nodes.Count;
			for (int ix = NodesCount-1; ix >= 0 ; ix--)
			{
				Itm = NodeKeyToItem(wTreeNodeParent.Nodes[ix].Key);
				if (Itm != null)
				{
					int ErrStatus = 0;
					PdfFileDeleteProc(Itm, ErrStatus);
					if (ErrStatus != 0 )
					{
//						MessageBox.Show(
//							"現在表示中のため削除できません。",
//							"削除できません",
//							MessageBoxButtons.OK,
//							MessageBoxIcon.Error,
//							MessageBoxDefaultButton.Button1);
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "現在表示中のため削除できません。",-1,"menuItem3_Click");
                        return;
					}//if (ErrStatus != 0 )
				}//if (Itm != null)
			}//for (int ix = NodesCount-1; ix >= 0 ; ix--)

			//再度リスト表示を行いすま
			setListData();
		}

		/// <summary>
		/// 指定日以前の印刷ファイル削除処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 指定した日以前のPDFファイルを削除します。</br>
		/// <br>Programmer : 90030 松林　真二</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			// 権限のチェック		2008.03.11 Y.Sasaki ADD
			if (this.CheckRoleManeger() != 0) return;

			//指定日を取得します
			//指定が日ではなく週や月の場合はそのなかの終了の日を取得します
			DateTime dt = DateTime.MinValue;			// 日付ワーク(初期値=MinValue)
			dt = monthCalendar.SelectionEnd.Date;
			string wstr;								// 文字列編集ワーク
			ArrayList PrtItmList = new ArrayList();		// 日付単位の設定用コレクション

			//取得した日付より以前のファイルを全て削除します
			if (UdsDateType.Value != null)
			{
				// 帳票種別
				foreach(PrintInfoItem PrtKidInf in _PrintKindInfo)
				{
					// コレクション初期化
					PrtItmList.Clear();
					// 日付ソート用インターフェース生成
					PrintInfoComparer pc = new PrintInfoComparer();
					pc.Key = PrintInfoComparer.SortKey.PrintOutDateTime;
					// 降順を指定
					pc.Order = SortOrder.Descending;
					// 日付でソートする
					_PrintInfoItems.Sort(pc);
					// 日付で検索する
					foreach (PrintInfoItem Itm in _PrintInfoItems)
					{
						//日付の判断
						if (Itm.PrintOutDateTime.Date > dt.Date) continue;
						// 帳票種別は同じであるか？
						if (PrtKidInf.PrintKey == Itm.PrintKey)
						{
							// アイテムを追加する
							PrtItmList.Add(Itm);
						}
					}//foreach (PrintInfoItem Itm in _PrintInfoItems)

					// コレクションの中身をTreeVewに設定する(種別ごとに)
					if (PrtItmList.Count > 0)
					{
						// 親ノードを生成
						wstr = PrtKidInf.PrintName;
						Infragistics.Win.UltraWinTree.UltraTreeNode topNode = new Infragistics.Win.UltraWinTree.UltraTreeNode("",wstr);
						foreach (PrintInfoItem Itm in PrtItmList)
						{
							// 子ノードを削除する
							if (Itm != null)
							{
								int ErrStatus = 0;
								PdfFileDeleteProc(Itm, ErrStatus);
								if (ErrStatus != 0 )
								{
//									MessageBox.Show(
//										"現在表示中のため削除できません。",
//										"削除できません",
//										MessageBoxButtons.OK,
//										MessageBoxIcon.Error,
//										MessageBoxDefaultButton.Button1);
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "現在表示中のため削除できません。",-1,"menuItem3_Click");
                                    return;
								}//if (ErrStatus != 0 )
							}//if (Itm != null)
						}//foreach (PrintInfoItem Itm in PrtItmList)
					}//if (PrtItmList.Count > 0)
				}//foreach(PrintInfoItem PrtKidInf in _PrintKindInfo)

				//再度リスト表示を行います
				setListData();

			}//if (UdsDateType.Value != null)

		}

		/// <summary>
		/// PDFファイル削除処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 指定したPDFファイルを削除します。</br>
		/// <br>Programmer : 90030 松林　真二</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		private void PdfFileDeleteProc(PrintInfoItem Itm, int ErrStatus)
		{
			ErrStatus = 0;

			if (Itm != null)
			{
				try //例外処理で
				{
					File.Delete(Itm.PdfFileName);
				}
				catch
				{
					ErrStatus = -1;
					return;
				}
				finally
				{
					//
				}

				// ファイル名で検索する
				//_PrintInfoItemsから削除する
				foreach (PrintInfoItem prtItm in _PrintInfoItems)
				{
					// 帳票種別は同じであるか？
					if((prtItm.PrintKey == Itm.PrintKey) && (prtItm.PdfFileName == Itm.PdfFileName))
					{
						// アイテムを削除する
						_PrintInfoItems.Remove(prtItm);
						//XMLファイルを削除する
						DeletePrintInfXML(prtItm);
						break;
					}
				}//foreach
			}//if (Itm != null)
		}

		#region ◆　システムロールチェック
		/// <summary>
		/// ロールチェック
		/// </summary>
		/// <returns>0：権限有り、-1：権限無し</returns>
		/// <remarks>
		/// <br>Note       : 文字列型の数字を数字型に変更する</br>
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2008.03.11</br>
		/// </remarks>
		private int CheckRoleManeger()
		{
			try
			{

				// DIコンテナのインスタンス化
				if (this._serviceInterfaceFactory == null)
					this._serviceInterfaceFactory = new ServiceInterfaceFactory();

				// インタフェースの取得
				if (this._iNsMenuRoleManager == null)
					this._iNsMenuRoleManager = (INsMenuRoleManager)this._serviceInterfaceFactory.GetObject("INsMenuRoleManager");

				if (this._iNsMenuRoleManager == null)
					return 0;
				// ↑ serviceInterfaceFactory.GetObject を使用して iNsMenuRoleManager を取得することが目的ですので、
				//    serviceInterfaceFactory.GetObject は、リフレクションを使用して実行しても構いません
				//    Broadleaf.Application.Common.ServiceInterfaceFactoryのアセンブリIDは、SFCMN00040C.DLL です
				//----------------------------------------------------------------------------------------------

				// PDF出力のシステムロールチェック
				RoleCheckInfo roleCheckInfo = new RoleCheckInfo();

				roleCheckInfo.ShowMessage = true;																											// true に設定すると "この機能は使用を許可されていません”等のメッセージが出力される
				roleCheckInfo.SystemFunctionCd = "MENU-5028";																					// ロール機能コード(PDF出力機能:MENU-5028)
				roleCheckInfo.EmployeeCode = this._loginEmployee.EmployeeCode;												// ログイン従業員コード

				// ロール権限チェック
				bool chkRes = this._iNsMenuRoleManager.CheckPossibleToUseFunction(ref roleCheckInfo);

				if (chkRes)
				{
					return 0;
				}
				else
				{
					return -1;
				}
			}
			catch (Exception)
			{
				return 0;
			}
		}
		#endregion

		/// <summary>
		/// エラーMSG表示処理
		/// </summary>
		/// <param name="level">表示レベル</param>
		/// <param name="msg">表示メッセージ</param>
		/// <param name="status">ステータス</param>
		/// <param name="proc">発生元メソッドID</param>
		/// <remarks>
		/// <br>Programmer : 94012 竹下　謙二</br>
		/// <br>Date       : 2005.09.26</br>
		/// </remarks>
		private void MsgDispProc(emErrorLevel level, string msg, int status, string proc)
		{
			DialogResult dlresult = new DialogResult();

			dlresult = TMsgDisp.Show(
				level,                              //エラーレベル
				UNITID,                             //UNIT　ID
				PGNM,                               //プログラム名称
				proc,                               //プロセスID
				"",                                 //オペレーション
				msg,                                //メッセージ
				status,                             //ステータス
				null,                               //オブジェクト
				MessageBoxButtons.OK,               //ダイアログボタン指定
				MessageBoxDefaultButton.Button1     //ダイアログ初期ボタン指定
				);
		}
	}

	/// <summary>
	/// Class1 の概要の説明です。
	/// </summary>
	//並び替える方法を定義するクラス
	//IComparerインターフェイスを実装する
	public class PrintInfoComparer : IComparer
	{
		/// <summary>
		/// 並び替える方法（デフォルト）・・・昇順
		/// </summary>
		public SortOrder Order = SortOrder.Ascending;

		/// <summary>
		/// 並び替える項目(デフォルト）・・・日付
		/// </summary>
		public SortKey Key = SortKey.PrintOutDateTime;

		/// <summary>
		/// ソートKEY定義
		/// </summary>
		public enum SortKey
		{
			/// <summary>Id</summary>
			Id,
			/// <summary>帳票識別</summary>
			PrintKey,
			/// <summary>発行日</summary>
			PrintOutDate,
			/// <summary>発行日時刻</summary>
			PrintOutDateTime,
		}
		/// <summary>
		/// xがyより小さいときはマイナスの数、大きいときはプラスの数
		/// 同じときは0を返す
		/// </summary>
		/// <param name="x">比較元オブジェクト</param>
		/// <param name="y">比較先オブジェクト</param>
		/// <returns>比較結果</returns>
		public int Compare(object x, object y)
		{
			int result = 0;
			PrintInfoItem cx = (PrintInfoItem) x;
			PrintInfoItem cy = (PrintInfoItem) y;

			if (Key == SortKey.Id)
			{
				// Idで並び替える
				result = cx.Id.CompareTo(cy.Id);
			}
			else if (Key == SortKey.PrintKey)
			{
				// 種別で並び替える
				result = string.Compare(cx.PrintKey, cy.PrintKey);
			}
			else if (Key == SortKey.PrintOutDate)
			{
				// 発行日付で並び替える
				result = DateTime.Compare(cx.PrintOutDateTime.Date, cy.PrintOutDateTime.Date);
			}
			else if (Key == SortKey.PrintOutDateTime)
			{
				// 発行日付時刻で並び替える
				result = DateTime.Compare(cx.PrintOutDateTime, cy.PrintOutDateTime);
			}
			//降順のときは+-を逆転させる
			if (Order == SortOrder.Descending)
			{
				result = -result;
			}
			//結果を返す
			return result;
		}
	}

	/// <summary>
	/// 帳票印刷設定
	/// </summary>
	public class PrintInfoItem
	{
		/// <summary>
		/// GUID
		/// </summary>
		private Guid _Id;
		/// <summary>
		/// 帳票区分
		/// </summary>
		private string _PrintKey;
		/// <summary>
		/// 発行日付時刻
		/// </summary>
		private DateTime _PrintOutDateTime;
		/// <summary>
		/// PDFファイル名
		/// </summary>
		private string _PdfFileName;
		/// <summary>
		/// 帳票名
		/// </summary>
		private string _PrintName;
		/// <summary>
		/// 帳票詳細名
		/// </summary>
		private string _PrintDetailName;
		/// <summary>
		/// 発行者名
		/// </summary>
		private string _LoginWorkerName;

		/// <summary>
		/// ID
		/// </summary>
		public Guid Id
		{
			get { return _Id; }
		}
		/// <summary>
		/// 帳票区分
		/// </summary>
		public string PrintKey
		{
			get { return _PrintKey; }
			set { _PrintKey = value; }
		}
		/// <summary>
		/// 発行日付時刻
		/// </summary>
		public DateTime PrintOutDateTime
		{
			get { return _PrintOutDateTime; }
			set { _PrintOutDateTime = value; }
		}
		/// <summary>
		/// PDFファイル名
		/// </summary>
		public string PdfFileName
		{
			get { return _PdfFileName; }
			set { _PdfFileName = value; }
		}
		/// <summary>
		/// 帳票名
		/// </summary>
		public string PrintName
		{
			get { return _PrintName; }
			set { _PrintName = value; }
		}
		/// <summary>
		/// 帳票詳細名
		/// </summary>
		public string PrintDetailName
		{
			get { return _PrintDetailName; }
			set { _PrintDetailName = value; }
		}
		/// <summary>
		/// 発行者名
		/// </summary>
		public string LoginWorkerName
		{
			get { return _LoginWorkerName; }
			set { _LoginWorkerName = value; }
		}
		
		/// <summary>
		/// コンストラクタ定義
		/// </summary>
		/// <param name="id">ID</param>
		/// <param name="P0">帳票区分</param>
		/// <param name="P1">発行日付時刻</param>
		/// <param name="P2">PDFファイル名</param>
		/// <param name="P3">帳票名</param>
		/// <param name="P4">帳票詳細名</param>
		/// <param name="P5">発行者名</param>
		public PrintInfoItem(Guid id, string P0, DateTime P1, string P2, string P3, string P4, string P5)
		{
			// ID
			_Id = id;
			// 帳票区分
			_PrintKey = P0;
			// 発行日付時刻
			_PrintOutDateTime = P1;
			// PDFファイル名
			_PdfFileName = P2;
			// 帳票名
			_PrintName = P3;
			// 帳票詳細名
			_PrintDetailName = P4;
			// 発行者名
			_LoginWorkerName = P5;
		}
		
		/// <summary>
		/// コンストラクタ定義
		/// </summary>
		/// <param name="P0">帳票区分</param>
		/// <param name="P1">発行日付時刻</param>
		/// <param name="P2">PDFファイル名</param>
		/// <param name="P3">帳票名</param>
		/// <param name="P4">帳票詳細名</param>
		/// <param name="P5">発行者名</param>
		public PrintInfoItem(string P0, DateTime P1, string P2, string P3, string P4, string P5)
			: this( Guid.NewGuid(), P0, P1, P2, P3, P4, P5)
		{
			// 帳票区分
			_PrintKey = P0;
			// 発行日付時刻
			_PrintOutDateTime = P1;
			// PDFファイル名
			_PdfFileName = P2;
			// 帳票名
			_PrintName = P3;
			// 帳票詳細名
			_PrintDetailName = P4;
			// 発行者名
			_LoginWorkerName = P5;
		}
		
		/// <summary>
		/// コンストラクタ定義
		/// </summary>
		/// <param name="P0">帳票区分</param>
		/// <param name="P1">帳票名</param>
		public PrintInfoItem(string P0, string P1)
			: this( Guid.NewGuid(), P0, DateTime.Now, string.Empty, P1, string.Empty, string.Empty)
		{
			// 帳票区分
			_PrintKey = P0;
			// 帳票名
			_PrintName = P1;
		}

		/// <summary>
		/// コンストラクタ定義
		/// </summary>
		public PrintInfoItem()
			: this(string.Empty, DateTime.Now, string.Empty, string.Empty, string.Empty, string.Empty)
		{
		}
	}
	/// <summary>
	/// デリゲート宣言
	/// </summary>
	public delegate void SelectNodeEvent(string PrintKey, string PrintName, string PdfFileName);
}

