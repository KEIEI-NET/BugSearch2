using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

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
using Broadleaf.Library.Text;
using Broadleaf.Drawing.Printing;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �g�b�v���j���[���[�U�[�R���g���[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �X���C�_�[�̃g�b�v���j���[��\�����܂��B</br>
	/// <br>Programmer : 980076�@�Ȓ��@����Y</br>
	/// <br>Date       : 2007.02.19</br>
	/// <br></br>
	/// <br>Update Note: 2007.10.12 21024 ���X�� ��</br>
	/// <br>			 �E�g�єł�DC.NS�łɕύX</br>
    /// <br></br>
    /// <br>Update Note: 2008.04.24 20056 ���n ���</br>
    ///	<br>		   : PM.NS ���ʏC�� ���Ӑ�E�d���敪���Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2008.09.05 21024 ���X�� ��</br>
    ///	<br>		   : PM.NS�p�ɍ��ږ������C��</br>
    /// <br>Update Note: 2015/02/04 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11070149-00</br>
    /// <br>           : �d�|�ꗗ��2200 redmine #43864 �ǉ��Ή�</br>
    /// <br>           : �n���h���G���[���o���Q�̍ďC��</br>
    /// <br></br>
    /// <br>Update Note: 2015/02/06 30757 ���X�� �M�p</br>
    /// <br>�Ǘ��ԍ�   : 11070149-00</br>
    /// <br>           : �d�|�ꗗ��2200 redmine #43864 �ǉ��Ή�</br>
    /// <br>           : ����e�X�g��Q�Ή��@�F�V�K�{�^���������ɍŋߎg�����d���悪�N���A�����s��Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2015/02/12 30757 ���X�� �M�p</br>
    /// <br>�Ǘ��ԍ�   : 11070149-00</br>
    /// <br>           : �d�|�ꗗ��2200 redmine #43864 �ǉ��Ή�</br>
    /// <br>           : �V�X�e���e�X�g��Q�Ή��F�ŋߎg�p�����d���`�[���J���Ă����Ԃŉ�ʍX�V����ƍŋߎg�p�����d���`�[�������Q�Ή�</br>
    /// <br></br>
    /// </remarks>
	internal partial class SFCMN00221UF : System.Windows.Forms.UserControl
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// �g�b�v���j���[�t�H�[���N���X�̃f�t�H���g�R���X�g���N�^
		/// </summary>
		public SFCMN00221UF(ControlScreenSkin controlScreenSkin)
		{
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			InitializeComponent();

			// �ϐ�������
			this.CustomerListShow = true;
			this.StockSlipListShow = true;
			this._customerSearchRetRecordList = new List<CustomerSearchRet>();			// �ŋߑI���������Ӑ���
			// 2008.05.22 Update >>>
			//this._supplierSearchRetRecordList = new List<CustomerSearchRet>();			// �ŋߑI�������d������
			this._supplierSearchRetRecordList = new List<Supplier>();					// �ŋߑI�������d������
			// 2008.05.22 Update <<<
			this._stockSlipRecordList = new List<SearchRetStockSlip>();					// �ŋߑI�������d���`�[���

			// �X�L���ݒ�
			List<string> ctrlNameList = new List<string>();
			ctrlNameList.Add(this.uExplorerBar_Top.Name);
			ctrlNameList.Add(this.uExplorerBar_TopRecord.Name);
			controlScreenSkin.SetExceptionCtrl(ctrlNameList);
			controlScreenSkin.SettingScreenSkin(this);
		}

        // --- ADD 杍^ 2015/02/04 ------ >>>
        /// <summary>
        /// ���������b�\�h�i�R���|�|�l���g�����j
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d�|�ꗗ��2200 redmine #43864 �ǉ��Ή�</br>
        /// <br>             �R���|�[�l���g�n���h�������G���[�Ή��i�āj</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2015/02/04 </br>
        /// <br></br>
        /// <br>Update Note: 2015/02/06 30757 ���X�� �M�p</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00</br>
        /// <br>           : �d�|�ꗗ��2200 redmine #43864 �ǉ��Ή�</br>
        /// <br>           : ����e�X�g��Q�Ή��@�F�V�K�{�^���������ɍŋߎg�����d���悪�N���A�����s��Ή�</br>
        /// <br></br>
        /// <br>Update Note: 2015/02/12 30757 ���X�� �M�p</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00</br>
        /// <br>           : �d�|�ꗗ��2200 redmine #43864 �ǉ��Ή�</br>
        /// <br>           : �V�X�e���e�X�g��Q�Ή��F�ŋߎg�p�����d���`�[���J���Ă����Ԃŉ�ʍX�V����ƍŋߎg�p�����d���`�[�������Q�Ή�</br>
        /// <br></br>
        /// </remarks>
        public void InitForNoComponent()
        {
            // �ϐ�������
            // --- DEL 30757 ���X�� �M�p 2015/02/12 �V�X�e���e�X�g��Q�Ή��F�ŋߎg�p�����d���`�[���J���Ă����Ԃŉ�ʍX�V����ƍŋߎg�p�����d���`�[�������Q�Ή�------ >>>
            //this.CustomerListShow = true;
            //this.StockSlipListShow = true;
            // --- DEL 30757 ���X�� �M�p 2015/02/12 �V�X�e���e�X�g��Q�Ή��F�ŋߎg�p�����d���`�[���J���Ă����Ԃŉ�ʍX�V����ƍŋߎg�p�����d���`�[�������Q�Ή�------ <<<
            // --- DEL 30757 ���X�� �M�p 2015/02/06 ����e�X�g��Q�Ή��@�F�V�K�{�^���������ɍŋߎg�����d���悪�N���A�����s��Ή�------ >>>
            //this._customerSearchRetRecordList = new List<CustomerSearchRet>();			// �ŋߑI���������Ӑ���
            //this._supplierSearchRetRecordList = new List<Supplier>();					// �ŋߑI�������d������
            //this._stockSlipRecordList = new List<SearchRetStockSlip>();					// �ŋߑI�������d���`�[���
            // --- DEL 30757 ���X�� �M�p 2015/02/06 ����e�X�g��Q�Ή��@�F�V�K�{�^���������ɍŋߎg�����d���悪�N���A�����s��Ή�------ <<<
            // --- ADD 30757 ���X�� �M�p 2015/02/06 ����e�X�g��Q�Ή��@�F�V�K�{�^���������ɍŋߎg�����d���悪�N���A�����s��Ή�------ >>>
            if (null == this._customerSearchRetRecordList)
            {
                this._customerSearchRetRecordList = new List<CustomerSearchRet>();			// �ŋߑI���������Ӑ���
            }
            if (null == this._supplierSearchRetRecordList)
            {
                this._supplierSearchRetRecordList = new List<Supplier>();					// �ŋߑI�������d������
            }
            if (null == this._stockSlipRecordList)
            {
                this._stockSlipRecordList = new List<SearchRetStockSlip>();					// �ŋߑI�������d���`�[���
            }
            // --- ADD 30757 ���X�� �M�p 2015/02/06 ����e�X�g��Q�Ή��@�F�V�K�{�^���������ɍŋߎg�����d���悪�N���A�����s��Ή�------ <<<
        }
        // --- ADD 杍^ 2015/02/04 ------ <<<
		# endregion

		// ===================================================================================== //
		// �����Ŏg�p����萔�S
		// ===================================================================================== //
		# region const
		private const string TOP_KEY = "TopNavigator";
		private const string RECORD_KEY_CUSTOMER = "CustomerRecord";
		private const string RECORD_KEY_STOCKSLIP = "StockSlipRecord";
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private bool _customerListShow = true;
		private bool _stockSlipListShow = true;
		private List<CustomerSearchRet> _customerSearchRetRecordList;					// �ŋߑI���������Ӑ���
		// 2008.05.22 Update >>>
		//private List<CustomerSearchRet> _supplierSearchRetRecordList;					// �ŋߑI�������d������
		private List<Supplier> _supplierSearchRetRecordList;							// �ŋߑI�������d������
		// 2008.05.22 Update <<<
		private List<SearchRetStockSlip> _stockSlipRecordList;							// �ŋߑI�������d���`�[���
		private LuncherTopMenuInfo[] _luncherTopMenuInfoArray;							// �����`���[�g�b�v���j���[���
		# endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region Event
		/// <summary>�p�l���ύX�C�x���g</summary>
		internal event PanelChangeEventHandler PanelChange;

		/// <summary>�g�b�v���j���[�I���C�x���g</summary>
		internal event TopMenuSelectEventHandler TopMenuSelect;

		/// <summary>���Ӑ�I����C�x���g</summary>
		internal event CustomerSelectedHandler CustomerSelected;

		// 2008.05.22 Add >>>
		/// <summary>�d����I����C�x���g</summary>
		internal event SupplierSelectedHandler SupplierSelected;
		// 2008.05.22 Add <<<

		/// <summary>�d���`�[�I����C�x���g</summary>
		internal event SearchRetStockSlipSelectedHandler StockSlipSelected;
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Priperties
		/// <summary>
		/// �ŋߎQ�Ƃ������Ӑ�\���v���p�e�B
		/// </summary>
		public bool CustomerListShow
		{
			get
			{
				return this._customerListShow;
			}
			set
			{
				this._customerListShow = value;

				this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Visible = this._customerListShow;

				if ((this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Visible) && 
					(this.uExplorerBar_TopRecord.Groups[RECORD_KEY_STOCKSLIP].Visible))
				{
					this.uExplorerBar_Top.Dock = DockStyle.Top;
					this.uExplorerBar_TopRecord.Visible = true;
					this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Selected = true;
				}
				else if (this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Visible)
				{
					this.uExplorerBar_Top.Dock = DockStyle.Top;
					this.uExplorerBar_TopRecord.Visible = true;
					this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Selected = true;
				}
				else if (this.uExplorerBar_TopRecord.Groups[RECORD_KEY_STOCKSLIP].Visible)
				{
					this.uExplorerBar_Top.Dock = DockStyle.Top;
					this.uExplorerBar_TopRecord.Visible = true;
					this.uExplorerBar_TopRecord.Groups[RECORD_KEY_STOCKSLIP].Selected = true;
				}
				else
				{
					this.uExplorerBar_Top.Dock = DockStyle.Fill;
					this.uExplorerBar_TopRecord.Visible = false;
				}
			}
		}

		/// <summary>
		/// �ŋߎQ�Ƃ����d���`�[�\���v���p�e�B
		/// </summary>
		public bool StockSlipListShow
		{
			get
			{
				return this._stockSlipListShow;
			}
			set
			{
				this._stockSlipListShow = value;

				this.uExplorerBar_TopRecord.Groups[RECORD_KEY_STOCKSLIP].Visible = this._stockSlipListShow;

				if ((this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Visible) &&
					(this.uExplorerBar_TopRecord.Groups[RECORD_KEY_STOCKSLIP].Visible))
				{
					this.uExplorerBar_Top.Dock = DockStyle.Top;
					this.uExplorerBar_TopRecord.Visible = true;
					this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Selected = true;
				}
				else if (this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Visible)
				{
					this.uExplorerBar_Top.Dock = DockStyle.Top;
					this.uExplorerBar_TopRecord.Visible = true;
					this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Selected = true;
				}
				else if (this.uExplorerBar_TopRecord.Groups[RECORD_KEY_STOCKSLIP].Visible)
				{
					this.uExplorerBar_Top.Dock = DockStyle.Top;
					uExplorerBar_TopRecord.Visible = true;
					uExplorerBar_TopRecord.Groups[RECORD_KEY_STOCKSLIP].Selected = true;
				}
				else
				{
					this.uExplorerBar_Top.Dock = DockStyle.Fill;
					this.uExplorerBar_TopRecord.Visible = false;
				}
			}
		}

		/// <summary>
		/// �ŋߑI���������Ӑ���v���p�e�B
		/// </summary>
		public List<CustomerSearchRet> CustomerSearchRetRecordList
		{
			get
			{
				return this._customerSearchRetRecordList;
			}
			set
			{
				this._customerSearchRetRecordList = value;
			}
		}

		/// <summary>
		/// �ŋߑI�������d������v���p�e�B
		/// </summary>
		// 2008.05.22 Update >>>
		//public List<CustomerSearchRet> SupplierSearchRetRecordList
		public List<Supplier> SupplierSearchRetRecordList
		// 2008.05.22 Update <<<
		{
			get
			{
				return this._supplierSearchRetRecordList;
			}
			set
			{
				this._supplierSearchRetRecordList = value;
			}
		}

		/// <summary>
		/// �ŋߑI�������d���`�[���
		/// </summary>
		public List<SearchRetStockSlip> StockSlipRecordList
		{
			get
			{
				return this._stockSlipRecordList;
			}
			set
			{
				this._stockSlipRecordList = value;
			}
		}

		/// <summary>
		/// �����`���[�g�b�v���j���[���
		/// </summary>
		public LuncherTopMenuInfo[] LuncherTopMenuInfoArray
		{
			get
			{
				return this._luncherTopMenuInfoArray;
			}
			set
			{
				this._luncherTopMenuInfoArray = value;
			}
		}
		# endregion

		// ===================================================================================== //
		// �C���^�[�i�����\�b�h
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// �����ݒ菈��
		/// </summary>
		internal void InitialSetting(SFCMN00221UAParam param)
		{
			// ��ʏ����\���ݒ菈��
			this.DisplayInitialSetting(param);
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

			// TOP�����I���O���[�v
			this.uExplorerBar_Top.Groups[TOP_KEY].ItemSettings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.EDITING];
			
			// �ŋߎg�������Ӑ�I���O���[�v
			if (param.SupplierDiv == 1)
			{
				this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].ItemSettings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.CUSTOMERCORP2];
			}
			else
			{
				this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].ItemSettings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.CUSTOMER];
			}
			
			// �ŋߎg�����`�[�O���[�v
			this.uExplorerBar_TopRecord.Groups[RECORD_KEY_STOCKSLIP].ItemSettings.AppearancesSmall.Appearance.Image = imglist.Images[(int)Size16_Index.LIST1];

			// �ŋߎg�p�������Ӑ�̕\��
			this.DispViewCustomer(param);

			// �ŋߎg�p�����d���`�[�̕\��
			this.DispViewStockSlip();
			
			// TOP���j���[�\��
			this.DispTopMenuWindow();
		}

		/// <summary>
		/// �ŋߎg�p�������Ӑ�̕\������
		/// </summary>
		private void DispViewCustomer(SFCMN00221UAParam param)
		{
			string title = "";
			// 2008.05.22 Update >>>
			//List<CustomerSearchRet> searchRetRecordList;

			//if (param.SupplierDiv == 1)
			//{
			//    this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Text = "�ŋߎg�p�����d����";
			//    title = "�d����";
			//    searchRetRecordList = this._supplierSearchRetRecordList;
			//}
			//else
			//{
			//    this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Text = "�ŋߎg�p�������Ӑ�";
			//    title = "���Ӑ�";
			//    searchRetRecordList = this._customerSearchRetRecordList;
			//}

			//this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Items.Clear();

			//// �ŋߎg�p�������Ӑ�̕\��
			//for (int i = searchRetRecordList.Count; i > 0; i--)
			//{
			//    CustomerSearchRet lst = searchRetRecordList[i - 1];

			//    if (lst.EnterpriseCode != LoginInfoAcquisition.EnterpriseCode) continue;

			//    // �d����w��̏ꍇ�A�d����ȊO�̃f�[�^�͕\�����Ȃ�
			//    if ((param.SupplierDiv == 1) && (lst.SupplierDiv != 1)) continue;

			//    Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem item = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem("Name");
			//    item.Text = lst.Name + " " + lst.Name2;
			//    item.Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;
			//    item.ToolTipText = this.GetCustomerInfoHint(lst);
			//    item.Settings.Tag = title + "���";
			//    item.Tag = lst.Clone();

			//    this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Items.Add(item);
			//}


			if (param.SupplierDiv == 1)
			{
				List<Supplier> searchRetRecordList;
				this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Text = "�ŋߎg�p�����d����";
				title = "�d����";
				searchRetRecordList = this._supplierSearchRetRecordList;

				this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Items.Clear();

				// �ŋߎg�p�������Ӑ�̕\��
				for (int i = searchRetRecordList.Count; i > 0; i--)
				{
					Supplier lst = searchRetRecordList[i - 1];

					if (lst.EnterpriseCode != LoginInfoAcquisition.EnterpriseCode) continue;

					Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem item = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem("Name");
					item.Text = lst.SupplierNm1 + " " + lst.SupplierNm2;
					item.Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;
					item.ToolTipText = this.GetSupplierInfoHint(lst);
					item.Settings.Tag = title + "���";
					item.Tag = lst.Clone();

					this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Items.Add(item);
				}
			}
			else
			{
				List<CustomerSearchRet> searchRetRecordList;
				this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Text = "�ŋߎg�p�������Ӑ�";
				title = "���Ӑ�";
				searchRetRecordList = this._customerSearchRetRecordList;

				this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Items.Clear();

				// �ŋߎg�p�������Ӑ�̕\��
				for (int i = searchRetRecordList.Count; i > 0; i--)
				{
					CustomerSearchRet lst = searchRetRecordList[i - 1];

					if (lst.EnterpriseCode != LoginInfoAcquisition.EnterpriseCode) continue;

					Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem item = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem("Name");
					item.Text = lst.Name + " " + lst.Name2;
					item.Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;
					item.ToolTipText = this.GetCustomerInfoHint(lst);
					item.Settings.Tag = title + "���";
					item.Tag = lst.Clone();

					this.uExplorerBar_TopRecord.Groups[RECORD_KEY_CUSTOMER].Items.Add(item);
				}
			}

			// 2008.05.22 Update <<<
		}

		/// <summary>
		/// �ŋߎg�p�����d���`�[�̕\������
		/// </summary>
		private void DispViewStockSlip()
		{
			this.uExplorerBar_TopRecord.Groups[RECORD_KEY_STOCKSLIP].Items.Clear();

			// �ŋߎg�p�����d���`�[�̕\��
			for (int i = this._stockSlipRecordList.Count; i > 0; i--)
			{
				SearchRetStockSlip lst = this._stockSlipRecordList[i - 1];

				if (lst.EnterpriseCode != LoginInfoAcquisition.EnterpriseCode) continue;

				// �d���`�����̎擾����
				string supplierFormalName = SliderCommonLib.GetSupplierFormalName(lst);

				Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem item = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem("Name");
                // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //item.Text = supplierFormalName + "," + lst.ArrivalGoodsDay.ToString("yyyy/MM/dd") + "," + lst.CustomerName;
                item.Text = supplierFormalName + "," + lst.ArrivalGoodsDay.ToString("yyyy/MM/dd") + "," + lst.SupplierNm1;
                // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
				item.Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;
				item.ToolTipText = this.GetStockSlipInfoHint(lst);
				item.Settings.Tag = "�d���`�[���";
				item.Tag = lst;

				this.uExplorerBar_TopRecord.Groups[RECORD_KEY_STOCKSLIP].Items.Add(item);
			}
		}

		/// <summary>
		/// �����`���[TOP���j���[�\������
		/// </summary>
		private void DispTopMenuWindow()
		{
			this.uExplorerBar_Top.Groups[TOP_KEY].Items.Clear();
			if (this._luncherTopMenuInfoArray == null) return;

			// �����`���[���j���[�\������
			ImageList imglist = IconResourceManagement.ImageList16;
			
			for (int i = 0; i < this._luncherTopMenuInfoArray.Length; i++)
			{
				this.uExplorerBar_Top.Groups[TOP_KEY].Items.Add(this._luncherTopMenuInfoArray[i].Mode.ToString(), this._luncherTopMenuInfoArray[i].DispName);
				
				if (this._luncherTopMenuInfoArray[i].ImageNo >= 0)
				{
					this.uExplorerBar_Top.Groups[TOP_KEY].Items[i].Settings.AppearancesSmall.Appearance.Image = imglist.Images[this._luncherTopMenuInfoArray[i].ImageNo];
				}

				if (this._luncherTopMenuInfoArray[i].Mode == SFCMN00221UA.LuncherMode_Separator)
				{
					this.uExplorerBar_Top.Groups[TOP_KEY].Items[i].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Separator;
				}
				else if (this._luncherTopMenuInfoArray[i].Mode == SFCMN00221UA.LuncherMode_Blank)
				{
					this.uExplorerBar_Top.Groups[TOP_KEY].Items[i].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Separator;
					this.uExplorerBar_Top.Groups[TOP_KEY].Items[i].Settings.AppearancesSmall.Appearance.ForeColor = Color.Transparent;
				}
				else
				{
					this.uExplorerBar_Top.Groups[TOP_KEY].Items[i].Settings.Style = Infragistics.Win.UltraWinExplorerBar.ItemStyle.Label;
				}
			}
		}

		/// <summary>
		/// ���Ӑ���q���g������擾����
		/// </summary>
		/// <param name="customerSearchRet">���Ӑ挟�����ʃN���X</param>
		/// <returns>���Ӑ���q���g������</returns>
		private string GetCustomerInfoHint(CustomerSearchRet customerSearchRet)
		{
			StringBuilder tipString = new StringBuilder();
			int maxLength = 10;

			// ���Ӑ於��
			tipString.Append(SFCMN00221UA.CommonLib.PadRight(maxLength, "���Ӑ於", ' ') + "�F" + customerSearchRet.Name + " " + customerSearchRet.Name2);
					
			// �J�i
			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, "�J�i", ' ') + "�F" + customerSearchRet.Kana);

			// ���Ӑ�R�[�h
			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, "�R�[�h", ' ') + "�F" + customerSearchRet.CustomerCode.ToString());
					
			// ���Ӑ�T�u�R�[�h
			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, "�T�u�R�[�h", ' ') + "�F" + customerSearchRet.CustomerSubCode);

			// ����TEL
			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, SFCMN00221UA.GetTelNoDspName(0), ' ') + "�F" + customerSearchRet.HomeTelNo);
					
			// �Ζ���TEL
			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, SFCMN00221UA.GetTelNoDspName(1), ' ') + "�F" + customerSearchRet.OfficeTelNo);
					
			// �g��TEL
			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, SFCMN00221UA.GetTelNoDspName(2), ' ') + "�F" + customerSearchRet.PortableTelNo);

			// �Z�� ��ݒ�
			string address =
				customerSearchRet.Address1 +
				// 2008.05.22 Update >>>
				//AddressConverter.CombineAddress(customerSearchRet.Address2, customerSearchRet.Address3) +
				customerSearchRet.Address3 +
				// 2008.05.22 Update <<<
				customerSearchRet.Address4;

			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, "�Z��", ' ') + "�F" + address);

			return tipString.ToString();
		}

		// 2008.05.22 Add >>>
		/// <summary>
		/// �d������q���g������擾����
		/// </summary>
		/// <param name="supplierSearchRet">�d���挟�����ʃN���X</param>
		/// <returns>���Ӑ���q���g������</returns>
		private string GetSupplierInfoHint( Supplier supplierSearchRet )
		{
			StringBuilder tipString = new StringBuilder();
			int maxLength = 10;

			// �d���於��
			tipString.Append(SFCMN00221UA.CommonLib.PadRight(maxLength, "�d���於", ' ') + "�F" + supplierSearchRet.SupplierNm1 + " " + supplierSearchRet.SupplierNm2);

			// �J�i
			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, "�J�i", ' ') + "�F" + supplierSearchRet.SupplierKana);

			// ���Ӑ�R�[�h
			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, "�R�[�h", ' ') + "�F" + supplierSearchRet.SupplierCd.ToString());

			// ����TEL
			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, "�s�d�k", ' ') + "�F" + supplierSearchRet.SupplierTelNo);

			// �Z�� ��ݒ�
			string address =
				supplierSearchRet.SupplierAddr1 +
				supplierSearchRet.SupplierAddr3 +
				supplierSearchRet.SupplierAddr4;

			tipString.Append("\r\n" + SFCMN00221UA.CommonLib.PadRight(maxLength, "�Z��", ' ') + "�F" + address);

			return tipString.ToString();
		}		
		// 2008.05.22 Add <<<

		/// <summary>
		/// �d���`�[���q���g������擾����
		/// </summary>
		/// <param name="searchRetStockSlip">�d���`�[�������ʃN���X</param>
		/// <returns>�d���`�[���q���g������</returns>
		private string GetStockSlipInfoHint(SearchRetStockSlip searchRetStockSlip)
		{
			string tipString = "";
			int totalLength = 12;

			// �u�����N
			tipString += "�@\r\n";

			// �d���`�[�ԍ�
            // 2008.09.05 Update >>>
			//tipString += SFCMN00221UA.CommonLib.PadRight(totalLength, "�`�[�ԍ�", ' ') + "�F" + searchRetStockSlip.SupplierSlipNo.ToString();
            tipString += SFCMN00221UA.CommonLib.PadRight(totalLength, "�d��SEQ�ԍ�", ' ') + "�F" + searchRetStockSlip.SupplierSlipNo.ToString();
            // 2008.09.05 Update <<<

			// 2007.10.12 sasaki >>
			//// ���ד�
			//tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "���ד�", ' ') + "�F" + searchRetStockSlip.ArrivalGoodsDay.ToString("yyyy/MM/dd");

			//// �v���
			//tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "�v���", ' ') + "�F" + searchRetStockSlip.StockAddUpADate.ToString("yyyy/MM/dd");

			// ���ד�
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "���ד�", ' ') + "�F" + searchRetStockSlip.ArrivalGoodsDay.ToString("yyyy/MM/dd");

			// �d�����A�v����͎d���`�[�̏ꍇ�̂ݕ\������
			if (searchRetStockSlip.SupplierFormal == 0) 
			{
				// �d����
				tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "�d����", ' ') + "�F" + searchRetStockSlip.StockDate.ToString("yyyy/MM/dd");

				// �v���
				tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "�v���", ' ') + "�F" + searchRetStockSlip.StockAddUpADate.ToString("yyyy/MM/dd");
			}
			// 2007.10.12 sasaki <<

			// �d���S��
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "�d���S��", ' ') + "�F" + searchRetStockSlip.StockAgentName;

            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// �d����
            //tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "�d����", ' ') + "�F" + searchRetStockSlip.CustomerName;
            // �d����
            tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "�d����", ' ') + "�F" + searchRetStockSlip.SupplierNm1;
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			// 2007.10.12 sasaki >>
			/*
			// �q��
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "�q��", ' ') + "�F" + searchRetStockSlip.WarehouseName;

			// ���Ǝ�
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "���Ǝ�", ' ') + "�F" + searchRetStockSlip.CarrierEpName;
			*/
			// 2007.10.12 sasaki <<

			// �����`��
            // 2008.09.05 Update >>>
			//tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "�����`��", ' ') + "�F" + searchRetStockSlip.PartySaleSlipNum;
            tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "�`�[�ԍ�", ' ') + "�F" + searchRetStockSlip.PartySaleSlipNum;
            // 2008.09.05 Update <<<

			// �Z�p���[�^
			tipString += "\r\n";

			/*
			// �d���`��
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "�d���`��", ' ') + "�F" + searchRetStockSlip.SupplierFomalName;

			// �`�[�敪
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "�`�[�敪", ' ') + "�F" + searchRetStockSlip.SupplierSlipCdName;

			// �ԓ`�敪
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "�ԓ`�敪", ' ') + "�F" + searchRetStockSlip.DebitNoteDivName;

			// ���i�敪
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "���i�敪", ' ') + "�F" + searchRetStockSlip.StockGoodsCdName;

			// ���|�敪
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "���|�敪", ' ') + "�F" + searchRetStockSlip.AccPayDivCdName;

			// �Z�p���[�^
			tipString += "\r\n";
			*/

			// �d�����z���v
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "�d�����v���z", ' ') + "�F" + searchRetStockSlip.StockTotalPrice.ToString("N0") + "�~";

			// �Z�p���[�^
			tipString += "\r\n";

			// ���l�P
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "���l1", ' ') + "�F" + searchRetStockSlip.SupplierSlipNote1;

			// ���l�Q
			tipString += "\r\n" + SFCMN00221UA.CommonLib.PadRight(totalLength, "���l2", ' ') + "�F" + searchRetStockSlip.SupplierSlipNote2;

			return tipString;
		}

		/// <summary>
		/// �p�l���ύX�C�x���g�R�[������
		/// </summary>
		/// <param name="mode">���[�h</param>
		private void PanelChangeEventCall(int dispNo)
		{
			if (this.PanelChange != null)
			{
				PanelChangeEventArgs e = new PanelChangeEventArgs(PanelChangeEventArgs.MODE_UPDATE, dispNo);
				this.PanelChange(this, e);
			}
		}

		/// <summary>
		/// �����`���[�N���C�x���g�R�[������
		/// </summary>
		/// <param name="mode">���[�h</param>
		private void TopMenuSelectEventCall(LuncherTopMenuInfo luncherTopMenuInfo)
		{
			if (this.TopMenuSelect != null)
			{
				this.TopMenuSelect(this, luncherTopMenuInfo);
			}
		}

		/// <summary>
		/// ���Ӑ�ԗ��������ʃN���X�擾�����i���o����I�����Ɏg�p�j
		/// </summary>
		/// <param name="customerSearchRet">���Ӑ�ԗ��������ʃN���X</param>
		/// <returns>STATUS 0:�Y���f�[�^���� others:�Y���f�[�^�Ȃ�</returns>
		private int GetSearchRetCustomer(ref CustomerSearchRet customerSearchRet)
		{
			int result = 4;

			// ���������N���X�̃C���X�^���X��
			CustomerSearchPara para = new CustomerSearchPara();
			para.EnterpriseCode = customerSearchRet.EnterpriseCode;
			para.CustomerCode = customerSearchRet.CustomerCode;

			CustomerSearchRet[] retArray;

			// ���Ӑ�ԗ������A�N�Z�X�N���X�̃C���X�^���X��
			CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			status = customerSearchAcs.Serch(out retArray, para);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				foreach (CustomerSearchRet ret in retArray)
				{
					if ((ret.EnterpriseCode.Trim() == customerSearchRet.EnterpriseCode.Trim()) &&
						(ret.CustomerCode == customerSearchRet.CustomerCode))
					{
						customerSearchRet = ret.Clone();
						result = 0;
						break;
					}
				}
			}

			return result;
		}

		// 2008.05.22 Add >>>
		/// <summary>
		/// �d����N���X�擾�����i���o����I�����Ɏg�p�j
		/// </summary>
		/// <param name="supplierSearchRet">���Ӑ�ԗ��������ʃN���X</param>
		/// <returns>STATUS 0:�Y���f�[�^���� others:�Y���f�[�^�Ȃ�</returns>
		private int GetSearchRetCustomer( ref Supplier supplierSearchRet )
		{
			int result = 4;

			// �d����A�N�Z�X�N���X�̃C���X�^���X��
			SupplierAcs supplierAcs = new SupplierAcs();
			Supplier retSupplier;

			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			status = supplierAcs.Read(out retSupplier, supplierSearchRet.EnterpriseCode, supplierSearchRet.SupplierCd);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				supplierSearchRet = retSupplier.Clone();
				result = 0;
			}

			return result;
		}
		// 2008.05.22 Add <<<

		/// <summary>
		/// �d���`�[�������ʃN���X�擾�����i���o����I�����Ɏg�p�j
		/// </summary>
		/// <param name="searchRetStockSlip">�d���`�[�������ʃN���X</param>
		/// <returns>STATUS 0:�Y���f�[�^���� others:�Y���f�[�^�Ȃ�</returns>
		private int GetSearchRetStockSlip(ref SearchRetStockSlip searchRetStockSlip)
		{
			int result = 4;

			// ���������N���X�̃C���X�^���X��
			SearchParaStockSlip para = new SearchParaStockSlip();
			para.EnterpriseCode = searchRetStockSlip.EnterpriseCode;
			para.SupplierFormal = searchRetStockSlip.SupplierFormal;
            // 2008.09.05 Update >>>
			//para.SupplierSlipNo = searchRetStockSlip.SupplierSlipNo;
            para.SupplierSlipNoSt = searchRetStockSlip.SupplierSlipNo;
            // 2008.09.05 Update <<<
            para.SupplierSlipCd = 99;
			para.DebitNoteDiv = 99;
			para.StockGoodsCd = 99;
			para.AccPayDivCd = 99;

			List<SearchRetStockSlip> searchRetStockSlipList;

			// �d���`�[�����A�N�Z�X�N���X�̃C���X�^���X��
			SearchSlipAcs searchSlipAcs = new SearchSlipAcs();
			int status = searchSlipAcs.Search(out searchRetStockSlipList, para);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				foreach (SearchRetStockSlip ret in searchRetStockSlipList)
				{
					if ((searchRetStockSlip.EnterpriseCode.Trim() == searchRetStockSlip.EnterpriseCode.Trim()) &&
						(searchRetStockSlip.SupplierFormal == searchRetStockSlip.SupplierFormal) &&
						(searchRetStockSlip.SupplierSlipNo == searchRetStockSlip.SupplierSlipNo))
					{
						searchRetStockSlip = ret;
						result = 0;
						break;
					}
				}
			}

			return result;
		}
		# endregion

		// ===================================================================================== //
		// �R���g���[���C�x���g���\�b�h
		// ===================================================================================== //
		# region Control Event Methods
		/// <summary>
		/// �g�b�v�G�N�X�v���[���[�o�[�A�C�e���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�p�����[�^�N���X</param>
		/// <param name="e">�ΏۃI�u�W�F�N�g</param>
		private void uExplorerBar_Top_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
		{
			int key = 0;
			
			try
			{
				key = Convert.ToInt32(e.Item.Key.ToString());
			}
			catch
			{
				return;
			}

			switch (key)
			{
				// ���Ӑ挟����
				case SFCMN00221UA.TOP_MODE_CustomerSearch:
				{
					this.PanelChangeEventCall(SFCMN00221UA.FORM_STATUS_FindCustomer);
					break;				
				}
				// �d���挟����
				case SFCMN00221UA.TOP_MODE_SupplierSearch:
				{
					this.PanelChangeEventCall(SFCMN00221UA.FORM_STATUS_FindSupplier);
					break;
				}
				// �d��������
				case SFCMN00221UA.TOP_MODE_StockSlipSearch:
				{
					this.PanelChangeEventCall(SFCMN00221UA.FORM_STATUS_FindStockSlip);
					break;				
				}
				default:
				{
					this.TopMenuSelectEventCall(this._luncherTopMenuInfoArray[e.Item.Index]);
					break;
				}
			}
		}

		/// <summary>
		/// �����G�N�X�v���[���[�o�[�A�C�e���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uExplorerBar_TopRecord_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
		{
			if (e.Item.Group.Key == RECORD_KEY_CUSTOMER)			// ���Ӑ�ԗ��I����
			{
				// 2008.05.22 Del >>>
				//CustomerSearchRet customerSearchRet = e.Item.Tag as CustomerSearchRet;
				// 2008.05.22 Del <<<

				if (LoginInfoAcquisition.OnlineFlag)
				{
					// 2008.05.22 Update >>>
					//int status = this.GetSearchRetCustomer(ref customerSearchRet);
					//if (status != 0)
					//{
					//    TMsgDisp.Show(
					//        Form.ActiveForm,
					//        emErrorLevel.ERR_LEVEL_INFO,
					//        this.Name,
					//        "�I���������Ӑ�͊��ɍ폜����Ă��邽�߁A�I���o���܂���",
					//        0,
					//        MessageBoxButtons.OK);

					//    return;
					//}

					//if (this.CustomerSelected != null)
					//{
					//    this.CustomerSelected(this, customerSearchRet);

					//    // �p�l���ύX�C�x���g�R�[������
					//    this.PanelChangeEventCall(SFCMN00221UA.FORM_STATUS_CustomerLuncher);
					//}

					if (e.Item.Tag is CustomerSearchRet)
					{
						CustomerSearchRet customerSearchRet = e.Item.Tag as CustomerSearchRet;

						int status = this.GetSearchRetCustomer(ref customerSearchRet);
						if (status != 0)
						{
							TMsgDisp.Show(
								Form.ActiveForm,
								emErrorLevel.ERR_LEVEL_INFO,
								this.Name,
								"�I���������Ӑ�͊��ɍ폜����Ă��邽�߁A�I���o���܂���",
								0,
								MessageBoxButtons.OK);

							return;
						}

						if (this.CustomerSelected != null)
						{
							this.CustomerSelected(this, customerSearchRet);

							// �p�l���ύX�C�x���g�R�[������
							this.PanelChangeEventCall(SFCMN00221UA.FORM_STATUS_CustomerLuncher);
						}
					}
					else if (e.Item.Tag is Supplier)
					{
						Supplier supplierSearchRet = e.Item.Tag as Supplier;

						int status = this.GetSearchRetCustomer(ref supplierSearchRet);
						if (status != 0)
						{
							TMsgDisp.Show(
								Form.ActiveForm,
								emErrorLevel.ERR_LEVEL_INFO,
								this.Name,
								"�I�������d����͊��ɍ폜����Ă��邽�߁A�I���o���܂���",
								0,
								MessageBoxButtons.OK);

							return;
						}

						if (this.SupplierSelected != null)
						{
							this.SupplierSelected(this, supplierSearchRet);

							// �p�l���ύX�C�x���g�R�[������
							this.PanelChangeEventCall(SFCMN00221UA.FORM_STATUS_CustomerLuncher);
						}
					}
					// 2008.05.22 Update <<<
				}
				else
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"�I�t���C�����[�h�ׁ̈A�������s���܂���B",
						0,
						MessageBoxButtons.OK);
				}
			}
			else													// �d���`�[�I����
			{			
//				int cnt = this._stockSlipRecordList.Count - 1;
				SearchRetStockSlip searchRetStockSlip = e.Item.Tag as SearchRetStockSlip;

				if (LoginInfoAcquisition.OnlineFlag)
				{
					int status = this.GetSearchRetStockSlip(ref searchRetStockSlip);
					if (status != 0)
					{
						TMsgDisp.Show(
							Form.ActiveForm,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"�I�������d���`�[�`�[�͊��ɍ폜����Ă��邽�߁A�I���o���܂���",
							0,
							MessageBoxButtons.OK);

						return;
					}

					if (this.StockSlipSelected != null)
					{
						this.StockSlipSelected(this, searchRetStockSlip);

						// �p�l���ύX�C�x���g�R�[������
						this.PanelChangeEventCall(SFCMN00221UA.FORM_STATUS_StockSlipLuncher);
					}
				}
				else
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"�I�t���C�����[�h�ׁ̈A�������s���܂���B",
						0,
						MessageBoxButtons.OK);
				}
			}
		}

		/// <summary>
		/// �G�N�X�v���[���[�o�[�}�E�X�G���^�[�G�������g�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uExplorerBar_TopRecord_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
			// �d���`�[�����|�b�v�A�b�v�\��
			Infragistics.Win.UIElement element = e.Element;
			object oContextItem = null;

			oContextItem = element.GetContext(typeof(Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem));

			if (oContextItem != null)
			{
				Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem item = (Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem)oContextItem;

				if ((item.ToolTipText != "") && (item.Settings.Tag != null))
				{
					Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
					ultraToolTipInfo.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
					ultraToolTipInfo.ToolTipTitle = item.Settings.Tag.ToString();
					ultraToolTipInfo.ToolTipText = item.ToolTipText.ToString();

					this.uToolTipManager_Information.Appearance.FontData.Name = "�l�r �S�V�b�N";
					this.uToolTipManager_Information.SetUltraToolTip(this.uExplorerBar_TopRecord, ultraToolTipInfo);
					this.uToolTipManager_Information.Enabled = true;
				}
			}
		}

		/// <summary>
		/// �G�N�X�v���[���[�o�[�}�E�X���[���G�������g�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uExplorerBar_TopRecord_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
		{
			this.uToolTipManager_Information.Enabled = false;
		}
		# endregion
	}

	# region internal Delegate
	/// <summary>�g�b�v���j���[�I���C�x���g�p�f���Q�[�g</summary>
	internal delegate void TopMenuSelectEventHandler(object sender, LuncherTopMenuInfo luncherTopMenuInfo);
	# endregion
}
