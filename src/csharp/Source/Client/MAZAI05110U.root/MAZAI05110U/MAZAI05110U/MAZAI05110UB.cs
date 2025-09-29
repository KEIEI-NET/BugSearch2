//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 棚卸準備処理
// プログラム概要   : 棚卸準備処理でデータ重複時の処理方法を選択させる。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 中村　仁
// 作 成 日  2007/04/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/21  修正内容 : 仕様変更　注意書き、棚卸入力数の削除
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 棚卸準備処理重複時動作確認UIクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 棚卸準備処理重複時動作確認UIクラスの機能を実装します</br>
	/// <br>Programmer : 23010 中村　仁</br>
	/// <br>Date       : 2007.04.04</br>
    /// <br>UpdateNote : 2009/05/21 照田 貴志　注意書き、棚卸入力数の削除</br>
    /// <br>           : </br>
    /// </remarks>
	public partial class BeforeSaveCheckDialog : Form
	{
		#region Constructor
		/// <summary>
		/// 棚卸準備処理重複時動作確認UIクラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 棚卸準備処理重複時動作確認UIクラスのインスタンスを初期化します</br>
		/// <br>Programmer : 23010 中村　仁</br>
	    /// <br>Date       : 2007.04.04</br>
		/// </remarks>
		public BeforeSaveCheckDialog ()
		{
//MessageBox.Show("","");
            InitializeComponent();

			// 初期処理
			InitialSetting();
		}
		#endregion

		#region Private Member
		/// <summary> 同一在庫の処理区分(0:準備処理対象にしない,1:準備処理対象にする) </summary>
		private int _alreadyData;
		/// <summary> 棚卸入力数処理区分(0:残す,1:クリア) </summary>
		private int _repetitionData;
        /// <summary> 棚卸処理区分(0:再作成(棚卸入力数クリア),1:再作成(棚卸入力数は残す),2:残す,3:削除) </summary>
		private int _inventoryProcDiv;

		#endregion

        #region Const

        //同一在庫の処理区分
        private const string ctNOTTARGET    = "準備処理対象にしない";
        private const string ctTARGET       = "準備処理対象にする";
        //棚卸入力数処理区分
        private const string ctSTAY         = "残す";
        private const string ctCLEAR        = "クリア";

        #endregion

        #region Public Property
        /// <summary>
		/// 同一在庫の処理区分(読み取り専用)
		/// </summary>
		public int AlreadyData
		{
			get { return this._alreadyData; }
		}
		/// <summary>
		/// 棚卸入力数処理区分(読み取り専用)
		/// </summary>
		public int RepetitionData
		{
			get { return this._repetitionData; }
        }
        /// <summary>
		/// 在庫処理区分(読み取り専用)
		/// </summary>
        public int InventoryProcDiv
		{
			get { return this._inventoryProcDiv; }
        }
        #endregion

        #region Public Enum
		/// <summary>
		/// 同一在庫の処理区分
		/// </summary>
		public enum AlreadyDataState
		{
			/// <summary> 準備処理対象にしない </summary>
			NotTarget = 0,
			/// <summary> 準備処理対象にする </summary>
			Target = 1
		}
		/// <summary>
		/// 棚卸入力数処理区分
		/// </summary>
		public enum InventoryDataState
		{
			/// <summary> 残す</summary>
			Stay = 0,
			/// <summary> クリア </summary>
			Clear = 1
		}
		#endregion

		#region Private Method

		#region 初期処理
		/// <summary>
		/// 初期処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 初期処理を行う。</br>
		/// <br>Programmer : 23010 中村　仁</br>
	    /// <br>Date       : 2007.04.04</br>
		/// </remarks>
		private void InitialSetting()
		{
			// コンボボックスにアイテム追加
			// 同一在庫の処理区分
			this.tceAlreadyData.Items.Clear();
			this.tceAlreadyData.Items.Add(AlreadyDataState.NotTarget, ctNOTTARGET);
			this.tceAlreadyData.Items.Add(AlreadyDataState.Target, ctTARGET);
			this.tceAlreadyData.MaxDropDownItems = this.tceAlreadyData.Items.Count;
			this.tceAlreadyData.SelectedIndex = 0;

			//棚卸入力数処理区分
			//同一在庫の処理区分が「準備処理対象にする」のときだけ選択が可能になる。
			this.tceRepetitionData.Items.Clear();
			this.tceRepetitionData.Items.Add(InventoryDataState.Stay, ctSTAY);
			this.tceRepetitionData.Items.Add(InventoryDataState.Clear, ctCLEAR);
			this.tceRepetitionData.MaxDropDownItems = this.tceRepetitionData.Items.Count;
			this.tceRepetitionData.SelectedIndex = 0;
			this.tceRepetitionData.Enabled = false;
            this.tceRepetitionData.Visible = false;                 //ADD 2009/05/21 棚卸入力数の削除
            this.StockAnalysisDivCdTitle_Label.Visible = false;     //ADD 2009/05/21 棚卸入力数タイトルの削除

            this.ultraLabel4.Visible = false;                       //ADD 2009/05/21 注意書きの削除

			// ボタンアイコン設定
			this.ubSave.ImageList = IconResourceManagement.ImageList16;
			this.ubReturn.ImageList = IconResourceManagement.ImageList16;

			this.ubSave.Appearance.Image	= Size16_Index.SAVE;
			this.ubReturn.Appearance.Image	= Size16_Index.BEFORE;
		}
		#endregion

		#endregion

		#region Control Event

		#region 同一在庫の処理区分 ComboBox(tceAlreadyData)

		#region ValueChanged Event
		/// <summary>
		/// tceAlreadyData_ValueChanged Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void tceAlreadyData_ValueChanged ( object sender, EventArgs e )
		{
            // ---DEL 2009/05/21 棚卸入力数削除の為 ------------------------------------------->>>>>
            //bool repDataEnable = false;

            //// 同一在庫の処理区分が「準備処理対象にする」ならば、棚卸入力数処理区分を選択可にする。
            //if ( (AlreadyDataState)tceAlreadyData.SelectedItem.DataValue == AlreadyDataState.Target ) 
            //    repDataEnable = true;
            //else
            //    repDataEnable = false;

            //this.tceRepetitionData.Enabled = repDataEnable;
            // ---DEL 2009/05/21 棚卸入力数削除の為 -------------------------------------------<<<<<
        }
		#endregion

		#endregion
		
		#region ubSaveButtonClick Event
		/// <summary>
		/// ubSave_Click Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void ubSave_Click ( object sender, EventArgs e )
		{
			// 選択状態の取得
			this._alreadyData		= (int)this.tceAlreadyData.SelectedItem.DataValue;		// 同一在庫の処理区分
            // ---DEL 2009/05/21 棚卸入力数削除の為 ----------------------------->>>>>
            //this._repetitionData = (int)this.tceRepetitionData.SelectedItem.DataValue;	// 棚卸入力数処理区分

            ////棚卸処理区分をセット
            //// 同一在庫の処理区分
            //switch(this._alreadyData)
            //{
            //    //準備処理対象にしない
            //    case 0:
            //    {
            //        //棚卸処理区分
            //        this._inventoryProcDiv = 2;
            //        break;
            //    }
            //    //準備処理対象にする
            //    case 1:
            //    {
            //        //棚卸入力数処理区分
            //        switch(this._repetitionData)
            //        {
            //            //残す
            //            case 0:
            //            {
            //                //棚卸処理区分
            //                this._inventoryProcDiv = 1;
            //                break;
            //            }
            //            //クリア
            //            case 1:
            //            {
            //                //棚卸処理区分
            //                this._inventoryProcDiv = 0;
            //                break;
            //            }
            //        }
            //        break;
            //    }
            //}
            // ---DEL 2009/05/21 棚卸入力数削除の為 -----------------------------<<<<<
            // 「0:準備処理対象にしない」「1:準備処理対象にする」とする。
            this._inventoryProcDiv = this._alreadyData;     //ADD 2009/05/21 棚卸入力数削除の為

            //描画が間に合わないので先にHideしておく
            this.Hide();
			// 自身のDialogResultをOkにして終了
			this.DialogResult = DialogResult.OK;
            this.Close();

		}
		#endregion

		#region ubReturnButtonClick Event
		/// <summary>
		/// ubReturn_Click Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void ubReturn_Click ( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.Cancel;
		}
		#endregion

		#endregion
	}
}