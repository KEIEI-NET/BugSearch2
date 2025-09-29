using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Collections.Generic;

using DataDynamics.ActiveReports.Document;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 新規作成ダイアログ画面
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票の新規作成に必要な情報を入力する画面です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.06.06</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08105UF : Form
	{
		#region PrivateMember
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
        // 帳票ID
        private string _prtFormId;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
		// 出力名称
		private string _displayName;
		// 用紙種別
		private PaperKind _paperKind;
		// 選択印字項目グループ
		private PrtItemGrpWork _selectedPrtItemGrp;
		// 印字項目グループLIST
		private List<PrtItemGrpWork> _prtItemGrpList;
		// 用紙方向 (Portrait:縦,Landscape:横)
		private PageOrientation _landscape = PageOrientation.Landscape;
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08105UF()
		{
			InitializeComponent();

			this.ubDecide.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.NEW];
			this.ubCancel.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.INTERRUPTION];

			_selectedPrtItemGrp = null;
		}
		#endregion

		#region Property
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
        /// <summary>帳票ID</summary>
        public string PrtFormId
        {
            get { return _prtFormId; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
		/// <summary>出力名称</summary>
		public string DisplayName
		{
			get { return _displayName; }
		}

		/// <summary>用紙種別</summary>
		public PaperKind PaperKind
		{
			get { return _paperKind; }
		}

		/// <summary>選択印字項目グループ</summary>
		public PrtItemGrpWork SelectedPrtItemGrp
		{
			get { return _selectedPrtItemGrp; }
		}

		/// <summary>用紙方向 (Portrait:縦,Landscape:横)</summary>
		public PageOrientation Landscape
		{
			get { return _landscape; }
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// 新規作成ダイアログ表示処理
		/// </summary>
		/// <param name="prtItemGrpList">印字項目グループLIST</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note		: 自由帳票の新規作成に必要な情報を入力する画面を表示します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public DialogResult ShowNewReportInfoDialog(List<PrtItemGrpWork> prtItemGrpList)
		{
			this.DialogResult = DialogResult.Cancel;

			_prtItemGrpList = prtItemGrpList;

			return this.ShowDialog();
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// 入力チェック
		/// </summary>
		/// <param name="message">メッセージ</param>
		/// <param name="control">コントロール</param>
		/// <returns>チェック結果</returns>
		/// <remarks>
		/// <br>Note		: 画面の入力チェックを行ないます。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private bool InputCheck(out string message, out Control control)
		{
			message = string.Empty;
			control = null;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
            // 帳票ID
            if ( this.tedPrtFormId.Text.Equals( string.Empty ) )
            {
                message = this.ulPrtFormId.Text + "が入力されていません。";
                control = this.tedPrtFormId;
                return false;
            }
            if ( this.tedPrtFormId.Text.IndexOf( '\\' ) != -1 || this.tedPrtFormId.Text.IndexOf( '/' ) != -1 )
            {
                message = this.ulPrtFormId.Text + "に下記文字は使用出来ません。" + Environment.NewLine + Environment.NewLine + "\\ /";
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
			if (this.tedDisplayName.Text.IndexOf('\\') != -1 || this.tedDisplayName.Text.IndexOf('/') != -1)
			{
				message = this.ulDisplayName.Text + "に下記文字は使用出来ません。" + Environment.NewLine + Environment.NewLine + "\\ /";
				control = this.tedDisplayName;
				return false;
			}

			// 印字項目グループ
			if (this.cmbFreePrtPprItemGrpNm.Value == null)
			{
				message = this.ulFreePrtPprItemGrpNm.Text + "が選択されていません。";
				control = this.cmbFreePrtPprItemGrpNm;
				return false;
			}

			return true;
		}

		/// <summary>
		/// 項目グループ更新処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 項目グループコンボボックスの更新を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void UpdateFreePrtPprItemGrp()
		{
			// 帳票用紙区分(1:帳票,2:伝票,3:DM一覧表,4:DMはがき)
			int printPaperUseDivcd = (int)this.cmbPrintPaperUseDivcd.Value;

			// 項目グループ
			this.cmbFreePrtPprItemGrpNm.Items.Clear();
			foreach (PrtItemGrpWork prtItemGrp in _prtItemGrpList)
			{
				if (printPaperUseDivcd == prtItemGrp.PrintPaperUseDivcd)
					this.cmbFreePrtPprItemGrpNm.Items.Add(prtItemGrp.FreePrtPprItemGrpCd, prtItemGrp.FreePrtPprItemGrpNm);
			}

			if (this.cmbFreePrtPprItemGrpNm.Items.Count > 0)
				this.cmbFreePrtPprItemGrpNm.SelectedIndex = 0;

			// 伝票,DMはがきの時は用紙方向を縦にする
			if (printPaperUseDivcd == 2 || printPaperUseDivcd == 4)
				this.uosOrientation.Value = PageOrientation.Portrait;
			else
				this.uosOrientation.Value = PageOrientation.Landscape;
		}
		#endregion

		#region Event
		/// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void SFANL08105UF_Load(object sender, EventArgs e)
		{
			// ☆☆☆ 初期設定 ☆☆☆
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
            // 帳票ID
            this.tedPrtFormId.Clear();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
			// 帳票名称
			this.tedDisplayName.Clear();
			// 用紙種類
			this.cmbPaperName.Items.Clear();
			this.cmbPaperName.Items.Add(PaperKind.A3, 				"Ａ３");
			this.cmbPaperName.Items.Add(PaperKind.A4, 				"Ａ４");
			this.cmbPaperName.Items.Add(PaperKind.A5, 				"Ａ５");
			this.cmbPaperName.Items.Add(PaperKind.B4, 				"Ｂ４");
			this.cmbPaperName.Items.Add(PaperKind.B5, 				"Ｂ５");
			this.cmbPaperName.Items.Add(PaperKind.JapanesePostcard,	"はがき");
			//this.cmbPaperName.Items.Add(PaperKind.Custom,			"カスタム");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
            this.cmbPaperName.Items.Add( PaperKind.Custom, "カスタム" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
			this.cmbPaperName.Value = PaperKind.A4;
			// 帳票用紙区分
			this.cmbPrintPaperUseDivcd.Items.Clear();
			this.cmbPrintPaperUseDivcd.Items.Add((int)SFANL08105UA.PrintPaperUseDivcdKind.Report,		"帳票");
			this.cmbPrintPaperUseDivcd.Items.Add((int)SFANL08105UA.PrintPaperUseDivcdKind.Slip,			"伝票");
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
            //this.cmbPrintPaperUseDivcd.Items.Add((int)SFANL08105UA.PrintPaperUseDivcdKind.DMReport,		"ＤＭ一覧表");
            //this.cmbPrintPaperUseDivcd.Items.Add((int)SFANL08105UA.PrintPaperUseDivcdKind.DMPostCard,	"ＤＭはがき");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
            this.cmbPrintPaperUseDivcd.Items.Add( (int)SFANL08105UA.PrintPaperUseDivcdKind.DmdBill, "請求書" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
			this.cmbPrintPaperUseDivcd.SelectedIndex = 0;
			UpdateFreePrtPprItemGrp();
			// 用紙方向
			this.uosOrientation.Items.Clear();
			this.uosOrientation.Items.Add(PageOrientation.Landscape,	"横");
			this.uosOrientation.Items.Add(PageOrientation.Portrait,		"縦");
			this.uosOrientation.CheckedIndex = 0;
		}

		/// <summary>
		/// 新規作成ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 新規作成ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ubDecide_Click(object sender, EventArgs e)
		{
			string message;
			Control control;

			if (InputCheck(out message, out control))
			{
				_selectedPrtItemGrp = _prtItemGrpList.Find(
					delegate(PrtItemGrpWork prtItemGrp)
					{
						if (prtItemGrp.FreePrtPprItemGrpCd.Equals(this.cmbFreePrtPprItemGrpNm.Value))
							return true;
						else
							return false;
					}
				);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                _prtFormId = this.tedPrtFormId.Text;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
				_displayName	= this.tedDisplayName.Text;
				_paperKind		= (PaperKind)this.cmbPaperName.Value;
				_landscape		= (PageOrientation)this.uosOrientation.Value;

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				TMsgDisp.Show(
					this,								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
					SFANL08105UH.ctASSEMBLY_ID,			// アセンブリＩＤまたはクラスＩＤ
					message,							// 表示するメッセージ 
					0,									// ステータス値
					MessageBoxButtons.OK);				// 表示するボタン
				control.Focus();
			}
		}

		/// <summary>
		/// キャンセルボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: キャンセルボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ubCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// SelectionChangedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 選択が変更された場合に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void cmbPrintPaperUseDivcd_SelectionChanged(object sender, EventArgs e)
		{
			UpdateFreePrtPprItemGrp();
		}

		/// <summary>
		/// フォームキーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォーム上でキー押下された時に発生します。</br>
		/// <br>Programer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void SFANL08105UF_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				ubCancel_Click(sender, e);
		}
		#endregion
	}
}