using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 新規登録情報入力画面
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票の新規登録に必要な情報を入力する画面です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.06.06</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08105UG : Form
	{
		#region PrivateMember
		// 自由帳票印字位置設定
		private FrePrtPSet	_frePrtPSet;
		// 伝票種別コード
		private List<int>	_slipPrtKindList;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
        // 新規書込フラグ
        private bool isNewWrite;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08105UG()
		{
			InitializeComponent();

			this.ubSave.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.SAVE];
			this.ubCancel.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.INTERRUPTION];

			_slipPrtKindList = new List<int>();
		}
		#endregion

		#region Property
		/// <summary>
		/// 伝票種別
		/// </summary>
		public List<int> SlipPrtKindList
		{
			get { return _slipPrtKindList; }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
            set { _slipPrtKindList = value; }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
        /// <summary>
        /// 新規書込フラグ
        /// </summary>
        public bool IsNewWrite
        {
            get { return isNewWrite; }
            set { isNewWrite = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
		#endregion

		#region PublicMethod
		/// <summary>
		/// 新規登録情報ダイアログ表示処理
		/// </summary>
		/// <param name="frePrtPSet">自由帳票印字位置設定</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note		: 自由帳票の新規登録に必要な情報を入力する画面を表示します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public DialogResult ShowNewWriteInfoDialog(FrePrtPSet frePrtPSet)
		{
			_frePrtPSet = frePrtPSet;

			DialogResult dlgRet = this.ShowDialog();

			return dlgRet;
		}
		#endregion

		#region PrivateMthod
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

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
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
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD

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

			// 伝票種別
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 DEL
            //if (_frePrtPSet.PrintPaperUseDivcd == (int)SFANL08105UA.PrintPaperUseDivcdKind.Slip)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 ADD
            if ( _frePrtPSet.PrintPaperUseDivcd == (int)SFANL08105UA.PrintPaperUseDivcdKind.Slip &&
                 _frePrtPSet.FreePrtPprSpPrpseCd != (int)SFANL08105UA.FreePrtPprSpPrpseCd.EstimateForm &&
                 _frePrtPSet.FreePrtPprSpPrpseCd != (int)SFANL08105UA.FreePrtPprSpPrpseCd.StockMoveSlip &&
                 _frePrtPSet.FreePrtPprSpPrpseCd != (int)SFANL08105UA.FreePrtPprSpPrpseCd.StockReturnSlip &&
                 _frePrtPSet.FreePrtPprSpPrpseCd != (int)SFANL08105UA.FreePrtPprSpPrpseCd.UoeSlip )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 ADD
			{
				if (!this.uceEstimate.Checked &&
					!this.uceShipment.Checked &&
					!this.uceAcpOdr.Checked &&
					!this.uceDelivery.Checked)
				{
					message = this.ulSlipPrtKind.Text + "が選択されていません。";
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 DEL
                    //control = this.uceEstimate;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 ADD
                    control = this.uceDelivery;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 ADD
					return false;
				}
			}
			
			return true;
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
		private void SFANL08105UI_Load(object sender, EventArgs e)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
            // 帳票ID
            this.tedPrtFormId.Text = _frePrtPSet.OutputFormFileName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
			// 出力名称
			this.tedDisplayName.Text			= _frePrtPSet.DisplayName;
			// 出力確認メッセージ
			this.tedOutConfimationMsg.Text		= _frePrtPSet.OutConfimationMsg;
			// 帳票ユーザー枝番コメント
			this.tedPrtPprUserDerivNoCmt.Text	= _frePrtPSet.PrtPprUserDerivNoCmt;

			// 用紙使用区分毎の制御
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 DEL
            //if (_frePrtPSet.PrintPaperUseDivcd == (int)SFANL08105UA.PrintPaperUseDivcdKind.Slip)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 ADD
            // 伝票以外と「見積書」「在庫移動伝票」「仕入返品伝票」「ＵＯＥ」伝票は除く
            if ( _frePrtPSet.PrintPaperUseDivcd == (int)SFANL08105UA.PrintPaperUseDivcdKind.Slip &&
                 _frePrtPSet.FreePrtPprSpPrpseCd != (int)SFANL08105UA.FreePrtPprSpPrpseCd.EstimateForm &&
                 _frePrtPSet.FreePrtPprSpPrpseCd != (int)SFANL08105UA.FreePrtPprSpPrpseCd.StockMoveSlip &&
                 _frePrtPSet.FreePrtPprSpPrpseCd != (int)SFANL08105UA.FreePrtPprSpPrpseCd.StockReturnSlip &&
                 _frePrtPSet.FreePrtPprSpPrpseCd != (int)SFANL08105UA.FreePrtPprSpPrpseCd.UoeSlip )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 ADD
			{
                this.pnlSlipPrtKind.Visible = true;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                //this.uceEstimate.Checked = true;
                //this.uceShipment.Checked = true;
                //this.uceAcpOdr.Checked = true;
                //this.uceDelivery.Checked = true;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                if ( this.isNewWrite )
                {
                    // 売上
                    this.uceDelivery.Checked = true;
                    this.uceDelivery.Enabled = true;
                    // 受注
                    this.uceAcpOdr.Checked = true;
                    this.uceAcpOdr.Enabled = true;
                    // 貸出
                    this.uceShipment.Checked = true;
                    this.uceShipment.Enabled = true;
                    // 見積
                    this.uceEstimate.Checked = true;
                    this.uceEstimate.Enabled = true;
                }
                else
                {
                    // 売上
                    this.SetCheckEditState( uceDelivery, _slipPrtKindList.Contains( 30 ) );
                    // 受注
                    this.SetCheckEditState( uceAcpOdr, _slipPrtKindList.Contains( 120 ) );
                    // 貸出
                    this.SetCheckEditState( uceShipment, _slipPrtKindList.Contains( 130 ) );
                    // 見積
                    this.SetCheckEditState( uceEstimate, _slipPrtKindList.Contains( 140 ) );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
            }
			else
			{
                this.pnlSlipPrtKind.Visible = false;
                this.Height -= this.pnlSlipPrtKind.Height;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
            if ( this.IsNewWrite )
            {
                // 新規モード(名前を付けて保存)
                this.tedPrtFormId.ReadOnly = false;
                this.tedPrtFormId.Appearance.BackColor = Color.FromArgb( 179, 219, 231 );
                this.tedPrtFormId.Appearance.ResetCursor();

                // フォームタイトル
                this.Text = string.Format( "{0} - {1}", "自由帳票", "名前を付けて保存" );

                // フォーカス
                this.tedPrtFormId.Focus();
            }
            else
            {
                // 更新モード
                this.tedPrtFormId.ReadOnly = true;
                this.tedPrtFormId.Appearance.ResetBackColor();
                this.tedPrtFormId.Appearance.Cursor = Cursors.Arrow;

                // フォームタイトル
                this.Text = string.Format( "{0} - {1}", "自由帳票", "上書き保存" );
                // フォーカス
                this.tedDisplayName.Focus();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
        /// <summary>
        /// チェックボックス状態設定処理
        /// </summary>
        /// <param name="targetCheckEditor"></param>
        /// <param name="prevExists"></param>
        private void SetCheckEditState( Infragistics.Win.UltraWinEditors.UltraCheckEditor targetCheckEditor, bool prevExists )
        {
            if ( prevExists )
            {
                targetCheckEditor.Checked = true;
                targetCheckEditor.Enabled = false;
            }
            else
            {
                targetCheckEditor.Checked = false;
                targetCheckEditor.Enabled = true;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD

		/// <summary>
		/// 保存ボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 保存ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void ubSave_Click(object sender, EventArgs e)
		{
			string message;
			Control control;
			if (InputCheck(out message, out control))
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                // 帳票ID
                _frePrtPSet.OutputFormFileName = this.tedPrtFormId.Text;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
				// 出力名称
				_frePrtPSet.DisplayName				= this.tedDisplayName.Text;
				// 出力確認メッセージ
				_frePrtPSet.OutConfimationMsg		= this.tedOutConfimationMsg.Text;
				// 帳票ユーザー枝番コメント
				_frePrtPSet.PrtPprUserDerivNoCmt	= this.tedPrtPprUserDerivNoCmt.Text;
				// 用紙使用区分毎の制御
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 DEL
                //if ( _frePrtPSet.PrintPaperUseDivcd == (int)SFANL08105UA.PrintPaperUseDivcdKind.Slip )
                //{
                //    if ( this.uceEstimate.Checked ) _slipPrtKindList.Add( 10 );
                //    if ( this.uceShipment.Checked ) _slipPrtKindList.Add( 20 );
                //    if ( this.uceAcpOdr.Checked ) _slipPrtKindList.Add( 21 );
                //    if ( this.uceDelivery.Checked ) _slipPrtKindList.Add( 30 );
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 ADD
                _slipPrtKindList.Clear();
				if (_frePrtPSet.PrintPaperUseDivcd == (int)SFANL08105UA.PrintPaperUseDivcdKind.Slip)
				{
                    switch ( _frePrtPSet.FreePrtPprSpPrpseCd )
                    {
                        // 見積書
                        case (int)SFANL08105UA.FreePrtPprSpPrpseCd.EstimateForm:
                            {
                                _slipPrtKindList.Add( 10 );
                            }
                            break;
                        // 仕入返品
                        case (int)SFANL08105UA.FreePrtPprSpPrpseCd.StockReturnSlip:
                            {
                                _slipPrtKindList.Add( 40 );
                            }
                            break;
                        // 在庫移動
                        case (int)SFANL08105UA.FreePrtPprSpPrpseCd.StockMoveSlip:
                            {
                                _slipPrtKindList.Add( 150 );
                            }
                            break;
                        // ＵＯＥ
                        case (int)SFANL08105UA.FreePrtPprSpPrpseCd.UoeSlip:
                            {
                                _slipPrtKindList.Add( 160 );
                            }
                            break;
                        default:
                            {
                                // 売上・受注・出荷・見積伝票
                                if ( this.uceDelivery.Checked ) _slipPrtKindList.Add( 30 );
                                if ( this.uceAcpOdr.Checked ) _slipPrtKindList.Add( 120 );
                                if ( this.uceShipment.Checked ) _slipPrtKindList.Add( 130 );
                                if ( this.uceEstimate.Checked ) _slipPrtKindList.Add( 140 );
                            }
                            break;
                    }
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 ADD

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
		/// フォームキーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォーム上でキー押下された時に発生します。</br>
		/// <br>Programer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void SFANL08105UG_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				ubCancel_Click(sender, e);
		}
		#endregion
	}
}