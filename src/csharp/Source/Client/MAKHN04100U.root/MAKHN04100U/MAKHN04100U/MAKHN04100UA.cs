using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;


namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 商品検索入力メインフレームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 商品検索・商品入力の制御を行うメインフレームです。</br>
	/// <br>Programmer : 20056 對馬 大輔</br>
	/// <br>Date       : 2007.08.30</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2008.06.18 20056 對馬 大輔</br>
    /// <br>           : PM.NS対応(コメント無し)</br>
    /// <br>Update Npte: 王君</br>
    /// <br>Date       : 2013/05/02</br>
    /// <br>管理番号   : 10901273-00 2013/06/18配信分</br>
    /// <br>           : Redmine#35434の対応</br>
    /// </remarks>
	public partial class MAKHN04100UA : Form
	{
		//================================================================================
		//  コンストラクタ
		//================================================================================
		#region Constructor
		/// <summary>
		/// 商品検索シートメインフレームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : コンストラクタ内処理の概要を記述</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.1.15</br>
        /// <br>Update Note: 王君</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分</br>
        /// <br>           : Redmine#35434の対応</br>
		/// </remarks>
		//public MAKHN04100UA() // DEL 王君 2013/05/02 Redmine#35434
        public MAKHN04100UA(int mode)// ADD 王君 2013/05/02 Redmine#35434
		{
			InitializeComponent();

            this._mode = mode; // ADD 王君 2013/05/02 Redmine#35434
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			if (LoginInfoAcquisition.Employee != null)
			{
				this._loginEmployee = LoginInfoAcquisition.Employee.Clone();
			}

			this._controlScreenSkin = new ControlScreenSkin();
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);
		}
		#endregion

		// ===============================================================================
		// プライベートメンバー
		// ===============================================================================
		#region Private member
		private string _enterpriseCode;
		private Employee _loginEmployee;
		private ControlScreenSkin _controlScreenSkin;
        private int _mode; // 起動モード　// ADD 王君 2013/05/02 Redmine#35434
		#endregion

		// ===============================================================================
		// プライベート定数
		// ===============================================================================
		#region Private Constant
		private const string CT_PGID = "MAKHN04100U";
		#endregion

		//================================================================================
		//  コントロールイベント
		//================================================================================
		#region Control Event
		/// <summary>
		/// 画面ロードイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		/// <remarks>
		/// <br>Note        : 画面がロードされた際、発生するイベントです。</br>
		/// <br>Programmer  : 18012 Y.Sasaki</br>
		/// <br>Date        : 2007.1.15</br>
        /// <br>Update Note : 2013/05/02 王君</br>
        /// <br>管理番号　  : 10901273-00 2013/06/18配信分</br>
        /// <br>            : Redmine#35434の対応</br>
		/// </remarks>
		private void MAKHN04100UA_Load(object sender, EventArgs e)
		{
			//MAKHN04110UA childFrm = new MAKHN04110UA(); // DEL 王君 2013/05/02 Redmine#5434
            MAKHN04110UA childFrm = new MAKHN04110UA(this._mode); // ADD 王君 2013/05/02 Redmine#35434

			childFrm.MdiParent = this;
			childFrm.FormBorderStyle = FormBorderStyle.None;
			childFrm.Dock = DockStyle.Fill;

			childFrm.Show();
		}
		#endregion
	}
}