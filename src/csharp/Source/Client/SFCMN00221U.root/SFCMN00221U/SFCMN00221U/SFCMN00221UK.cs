using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Collections;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �d���`�[���\�����[�U�[�R���g���[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �X���C�_�[�ɂĎd���`�[���I����̕\�����s���܂��B</br>
	/// <br>Programmer : 980076�@�Ȓ��@����Y</br>
	/// <br>Date       : 2007.02.23</br>
	/// <br></br>
    /// <br>Update Note: 2008.04.24 20056 ���n ���</br>
    ///	<br>		   : PM.NS ���ʏC�� ���Ӑ�E�d���敪���Ή�</br>
    /// </remarks>
	internal class SFCMN00221UK : System.Windows.Forms.UserControl
	{
		# region Components
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar uExplorerBar_LuncherInfo;
		internal System.Windows.Forms.Panel panel_Main;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar uExplorerBar_Infomation;
		private System.Windows.Forms.Splitter splitter;
		private System.ComponentModel.Container components = null;

		# endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// �d���`�[���\���t�H�[���N���X�̃f�t�H���g�R���X�g���N�^
		/// </summary>
		public SFCMN00221UK(ControlScreenSkin controlScreenSkin)
		{
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			InitializeComponent();
			 
			// �ϐ�������
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;		// ��ƃR�[�h���擾

			// �X�L���ݒ�
			List<string> ctrlNameList = new List<string>();
			ctrlNameList.Add(this.uExplorerBar_Infomation.Name);
			ctrlNameList.Add(this.uExplorerBar_LuncherInfo.Name);
			controlScreenSkin.SetExceptionCtrl(ctrlNameList);
			controlScreenSkin.SettingScreenSkin(this);
		}
		# endregion

		// ===================================================================================== //
		// �j������
		// ===================================================================================== //
		# region Dispose
		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		# endregion

		// ===================================================================================== //
		// �R���|�[�l���g �f�U�C�i �f�U�C�i�ō쐬���ꂽ�R�[�h
		// ===================================================================================== //
		#region �R���|�[�l���g �f�U�C�i �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
			Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			this.panel_Main = new System.Windows.Forms.Panel();
			this.uExplorerBar_LuncherInfo = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
			this.splitter = new System.Windows.Forms.Splitter();
			this.uExplorerBar_Infomation = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
			this.panel_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.uExplorerBar_LuncherInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.uExplorerBar_Infomation)).BeginInit();
			this.SuspendLayout();
			// 
			// panel_Main
			// 
			this.panel_Main.Controls.Add(this.uExplorerBar_LuncherInfo);
			this.panel_Main.Controls.Add(this.splitter);
			this.panel_Main.Controls.Add(this.uExplorerBar_Infomation);
			this.panel_Main.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.panel_Main.Location = new System.Drawing.Point(10, 9);
			this.panel_Main.Name = "panel_Main";
			this.panel_Main.Size = new System.Drawing.Size(354, 628);
			this.panel_Main.TabIndex = 4;
			// 
			// uExplorerBar_LuncherInfo
			// 
			this.uExplorerBar_LuncherInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.uExplorerBar_LuncherInfo.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance1.FontData.Name = "�l�r �S�V�b�N";
			appearance1.FontData.SizeInPoints = 11.25F;
			ultraExplorerBarGroup1.ItemSettings.AppearancesSmall.Appearance = appearance1;
			appearance2.Cursor = System.Windows.Forms.Cursors.Hand;
			appearance2.FontData.UnderlineAsString = "True";
			appearance2.ForeColor = System.Drawing.Color.Blue;
			ultraExplorerBarGroup1.ItemSettings.AppearancesSmall.HotTrackAppearance = appearance2;
			ultraExplorerBarGroup1.ItemSettings.Height = 22;
			ultraExplorerBarGroup1.ItemSettings.HotTracking = Infragistics.Win.DefaultableBoolean.True;
			ultraExplorerBarGroup1.ItemSettings.HotTrackStyle = Infragistics.Win.UltraWinExplorerBar.ItemHotTrackStyle.HighlightText;
			ultraExplorerBarGroup1.Key = "LuncherInfo";
			appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(225)))));
			appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			ultraExplorerBarGroup1.Settings.AppearancesSmall.Appearance = appearance3;
			appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(210)))));
			appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(156)))));
			appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance4.FontData.BoldAsString = "False";
			appearance4.FontData.Name = "�l�r �S�V�b�N";
			appearance4.FontData.SizeInPoints = 11.25F;
			appearance4.ForeColor = System.Drawing.Color.White;
			ultraExplorerBarGroup1.Settings.AppearancesSmall.HeaderAppearance = appearance4;
			ultraExplorerBarGroup1.Text = "�������܂����H";
			this.uExplorerBar_LuncherInfo.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1});
			this.uExplorerBar_LuncherInfo.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.SmallImagesWithText;
			this.uExplorerBar_LuncherInfo.ItemSettings.AllowDragCopy = Infragistics.Win.UltraWinExplorerBar.ItemDragStyle.None;
			this.uExplorerBar_LuncherInfo.ItemSettings.AllowDragMove = Infragistics.Win.UltraWinExplorerBar.ItemDragStyle.None;
			this.uExplorerBar_LuncherInfo.ItemSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
			this.uExplorerBar_LuncherInfo.Location = new System.Drawing.Point(0, 187);
			this.uExplorerBar_LuncherInfo.Name = "uExplorerBar_LuncherInfo";
			this.uExplorerBar_LuncherInfo.ShowDefaultContextMenu = false;
			this.uExplorerBar_LuncherInfo.Size = new System.Drawing.Size(354, 441);
			this.uExplorerBar_LuncherInfo.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.Listbar;
			this.uExplorerBar_LuncherInfo.TabIndex = 3;
			this.uExplorerBar_LuncherInfo.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.VisualStudio2005;
			this.uExplorerBar_LuncherInfo.ItemClick += new Infragistics.Win.UltraWinExplorerBar.ItemClickEventHandler(this.uExplorerBar_LuncherInfo_ItemClick);
			// 
			// splitter
			// 
			this.splitter.BackColor = System.Drawing.SystemColors.Control;
			this.splitter.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter.Location = new System.Drawing.Point(0, 184);
			this.splitter.Name = "splitter";
			this.splitter.Size = new System.Drawing.Size(354, 3);
			this.splitter.TabIndex = 2;
			this.splitter.TabStop = false;
			// 
			// uExplorerBar_Infomation
			// 
			this.uExplorerBar_Infomation.Dock = System.Windows.Forms.DockStyle.Top;
			this.uExplorerBar_Infomation.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance5.FontData.Name = "�l�r �S�V�b�N";
			appearance5.FontData.SizeInPoints = 11.25F;
			ultraExplorerBarGroup2.ItemSettings.AppearancesSmall.Appearance = appearance5;
			ultraExplorerBarGroup2.ItemSettings.Height = 22;
			ultraExplorerBarGroup2.Key = "Infomation";
			appearance6.BackColor = System.Drawing.Color.White;
			appearance6.BackColor2 = System.Drawing.Color.White;
			appearance6.FontData.Name = "�l�r �S�V�b�N";
			ultraExplorerBarGroup2.Settings.AppearancesSmall.Appearance = appearance6;
			appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(210)))));
			appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(67)))), ((int)(((byte)(156)))));
			appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance7.FontData.BoldAsString = "False";
			appearance7.FontData.Name = "�l�r �S�V�b�N";
			appearance7.FontData.SizeInPoints = 11.25F;
			appearance7.ForeColor = System.Drawing.Color.White;
			ultraExplorerBarGroup2.Settings.AppearancesSmall.HeaderAppearance = appearance7;
			ultraExplorerBarGroup2.Settings.HotTracking = Infragistics.Win.DefaultableBoolean.True;
			ultraExplorerBarGroup2.Text = "�d���`�[���";
			this.uExplorerBar_Infomation.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup2});
			this.uExplorerBar_Infomation.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.SmallImagesWithText;
			this.uExplorerBar_Infomation.Location = new System.Drawing.Point(0, 0);
			this.uExplorerBar_Infomation.Name = "uExplorerBar_Infomation";
			this.uExplorerBar_Infomation.ShowDefaultContextMenu = false;
			// 2007.10.12 sasaki >>
			//this.uExplorerBar_Infomation.Size = new System.Drawing.Size(354, 184);
			this.uExplorerBar_Infomation.Size = new System.Drawing.Size(354, 194);
			// 2007.10.12 sasaki <<
			this.uExplorerBar_Infomation.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.Listbar;
			this.uExplorerBar_Infomation.TabIndex = 1;
			this.uExplorerBar_Infomation.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.VisualStudio2005;
			// 
			// SFCMN00221UK
			// 
			this.Controls.Add(this.panel_Main);
			this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Name = "SFCMN00221UK";
			// 2007.10.12 sasaki >>
			//this.Size = new System.Drawing.Size(509, 646);
			this.Size = new System.Drawing.Size(509, 636);
			// 2007.10.12 sasaki <<
			this.panel_Main.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.uExplorerBar_LuncherInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.uExplorerBar_Infomation)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		// ===================================================================================== //
		// �����Ŏg�p����萔�Q
		// ===================================================================================== //
		# region Const
		private const string KEY_INFOMATION = "Infomation";
		private const string KEY_LUNCHER_INFO = "LuncherInfo";
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private string _enterpriseCode = "";									// ��ƃR�[�h
		private SearchRetStockSlip _searchRetStockSlip = new SearchRetStockSlip();
		private LuncherStartAssemblyInfo[] _luncherStartAssemblyInfoArray;		// �����`���[�\���A�Z���u�����(�d���`�[����)
		# endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region Event
		/// <summary>�p�l���ύX�C�x���g</summary>
		internal event PanelChangeEventHandler PanelChange;

		/// <summary>�����`���[�N���C�x���g</summary>
		internal event LuncherStartEventHandler LuncherStart;
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
		/// <summary>
		/// �d���`�[�������ʃN���X
		/// </summary>
		public SearchRetStockSlip SearchRetStockSlip_Data
		{
			get
			{
				return this._searchRetStockSlip;
			}
			set
			{
				this._searchRetStockSlip = value;
			}
		}

		/// <summary>
		/// �����`���[�\���A�Z���u�����(�d���`�[)
		/// </summary>
		public LuncherStartAssemblyInfo[] OdrLuncherStartAssemblyInfoArray
		{
			get
			{
				return this._luncherStartAssemblyInfoArray;
			}
			set
			{
				this._luncherStartAssemblyInfoArray = value;
			}
		}
		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// �����ݒ菈��
		/// </summary>
		public void InitialSetting(SFCMN00221UAParam param)
		{
			// ��ʏ����\���ݒ菈��
			this.DisplayInitialSetting(param);

			// �d���`�[�����`���[���j���[�\������
			this.DispLuncherWindow();
		}
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
		/// <summary>
		/// ��ʏ����\���ݒ菈��
		/// </summary>
		private void DisplayInitialSetting(SFCMN00221UAParam param)
		{
			// �C���[�W�A�C�R���ݒ菈��
			ImageList imglist = IconResourceManagement.ImageList16;

			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Clear();

			// 2007.10.12 sasaki >>
			//// �`�[�ԍ�
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("SupplierSlipNo", "�`�[�ԍ��@�@�F" + this._searchRetStockSlip.SupplierSlipNo.ToString());
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[0].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[0].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			//// �d���`�����̎擾����
			//string supplierFormalName = SliderCommonLib.GetSupplierFormalName(this._searchRetStockSlip);
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("SupplierFormal", "�d���`���@�@�F" + supplierFormalName);
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[1].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[1].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			//// ���ד�
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("ArrivalGoodsDay", "���ד��@�@�@�F" + this._searchRetStockSlip.ArrivalGoodsDay.ToString("yyyy/MM/dd"));
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[2].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[2].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			//// �v���
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("StockAddUpADate", "�v����@�@�@�F" + this._searchRetStockSlip.StockAddUpADate.ToString("yyyy/MM/dd"));
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[3].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[3].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			//// �d����
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("CustomerName", "�d����@�@�@�F" + this._searchRetStockSlip.CustomerName.ToString());
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[4].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[4].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			//// �d�����z
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("StockTotalPrice", "�d�����v���z�F" + this._searchRetStockSlip.StockTotalPrice.ToString("N0") + "�~");
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[5].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			//this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[5].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			int index = 0;
			// �`�[�ԍ�
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("SupplierSlipNo", "�`�[�ԍ��@�@�F" + this._searchRetStockSlip.SupplierSlipNo.ToString());
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			// �`�[��ʖ��̎擾����
			index++;
			string supplierFormalName = SliderCommonLib.GetSupplierFormalName(this._searchRetStockSlip);
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("SupplierFormal", "�`�[��ʁ@�@�F" + supplierFormalName);
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			// ���ד�
			index++;
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("ArrivalGoodsDay", "���ד��@�@�@�F" + this._searchRetStockSlip.ArrivalGoodsDay.ToString("yyyy/MM/dd"));
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			// �d���̏ꍇ�̂ݕ\��
			if (this._searchRetStockSlip.SupplierFormal == 0)
			{
				// �d����
				index++;
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("StockDate", "�d�����@�@�@�F" + this._searchRetStockSlip.StockDate.ToString("yyyy/MM/dd"));
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

				// �v���
				index++;
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("StockAddUpADate", "�v����@�@�@�F" + this._searchRetStockSlip.StockAddUpADate.ToString("yyyy/MM/dd"));
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
				this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;
			}
			// �d����
			index++;
            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("CustomerName", "�d����@�@�@�F" + this._searchRetStockSlip.CustomerName.ToString());
            this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("CustomerName", "�d����@�@�@�F" + this._searchRetStockSlip.SupplierNm1.ToString());
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;

			// �d�����z
			index++;
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items.Add("StockTotalPrice", "�d�����v���z�F" + this._searchRetStockSlip.StockTotalPrice.ToString("N0") + "�~");
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];
			this.uExplorerBar_Infomation.Groups[KEY_INFOMATION].Items[index].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;
			// 2007.10.12 sasaki <<
		}

		/// <summary>
		/// �d���`�[�����`���[���j���[�\������
		/// </summary>
		private void DispLuncherWindow()
		{
			this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items.Clear();
			
			if (this._luncherStartAssemblyInfoArray == null) return;

			// �����`���[���j���[�\������
			ImageList imglist = IconResourceManagement.ImageList16;
			
			for(int i = 0; i < this._luncherStartAssemblyInfoArray.Length; i++)
			{
				this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items.Add(i.ToString(), this._luncherStartAssemblyInfoArray[i].DispName);

				if (this._luncherStartAssemblyInfoArray[i].ImageNo >= 0)
				{
					if (this._luncherStartAssemblyInfoArray[i].Mode == SFCMN00221UA.LuncherMode_Separator)
					{
						this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items[i].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Separator;
					}
					else if (this._luncherStartAssemblyInfoArray[i].Mode == SFCMN00221UA.LuncherMode_Blank)
					{
						this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items[i].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Separator;
						this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items[i].Settings.AppearancesSmall.Appearance.ForeColor = Color.Transparent;
					}
					else
					{
						this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items[i].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;
						this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items[i].Settings.AppearancesSmall.Appearance.Image = imglist.Images[this._luncherStartAssemblyInfoArray[i].ImageNo];
					}
				}

				// �I�v�V�����`�F�b�N
				if (!(String.IsNullOrEmpty(this._luncherStartAssemblyInfoArray[i].SoftwareCode)))
				{
					this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items[i].Visible = SFCMN00221UA.OptionCheckForUSB(this._luncherStartAssemblyInfoArray[i].SoftwareCode);
				}

				// ���ꏈ��
				if (this._luncherStartAssemblyInfoArray[i].Mode == SFCMN00221UA.LuncherMode_TrustAppropriate)
				{
					if (this._searchRetStockSlip.SupplierFormal == 1)
					{
						this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items[i].Settings.Enabled = Infragistics.Win.DefaultableBoolean.True;
					}
					else
					{
						this.uExplorerBar_LuncherInfo.Groups[KEY_LUNCHER_INFO].Items[i].Settings.Enabled = Infragistics.Win.DefaultableBoolean.False;
					}
				}
			}
		}

		/// <summary>
		/// �p�l���ύX�C�x���g�R�[������
		/// </summary>
		/// <param name="recodeUpdateMode">��ʑJ�ڗ������X�V���[�h</param>
		/// <param name="dispNo">��ʔԍ�</param>
		private void PanelChangeEventCall(int recodeUpdateMode, int dispNo)
		{
			if (this.PanelChange != null)
			{
				PanelChangeEventArgs e = new PanelChangeEventArgs(recodeUpdateMode, dispNo);
				this.PanelChange(this, e);
			}
		}

		/// <summary>
		/// �����`���[�N���C�x���g�R�[������
		/// </summary>
		/// <param name="mode">���[�h</param>
		private void LuncherStartEventCall(LuncherStartAssemblyInfo luncherStartAssemblyInfo)
		{
			if (this.LuncherStart != null)
			{
				LuncherStartEventArgs e = new LuncherStartEventArgs(luncherStartAssemblyInfo, SFCMN00221UA.FORM_STATUS_StockSlipLuncher);
				this.LuncherStart(this, e);
			}
		}
		# endregion

		// ===================================================================================== //
		// �R���g���[���C�x���g���\�b�h
		// ===================================================================================== //
		# region Control Event Methods
		/// <summary>
		/// �d���`�[�����`���[�A�C�e���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uExplorerBar_LuncherInfo_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
		{
			this.uExplorerBar_LuncherInfo.Enabled = false;

			this.LuncherStartEventCall(this._luncherStartAssemblyInfoArray[e.Item.Index]);

			this.uExplorerBar_LuncherInfo.Enabled = true;
		}
		# endregion
	}
}
