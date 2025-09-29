using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
	public partial class PMMIT01010UD : Form
	{
		public PMMIT01010UD()
		{
			InitializeComponent();

			// �ϐ�������
			this._imageList16 = IconResourceManagement.ImageList16;
		}

        public PMMIT01010UD( EstimateInputAcs estimateInputAcs, string salesSlipNum, int mode )
			: this()
		{
			this._estimateInputAcs = estimateInputAcs;

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._salesSlipNum = salesSlipNum;
        }

        private ImageList _imageList16 = null;

        private EstimateInputAcs _estimateInputAcs;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private SalesSlip _salesSlip = null;
        private List<SalesDetail> _salesDetailList = null;
        private List<StockWork> _stockWorkList = null;
        private List<AcceptOdrCar> _acceptOdrCarList = null;

        private readonly int _acptAnOdrStatus = 10;
        private string _salesSlipNum = "";

        DialogResult _result = DialogResult.Cancel;

		#region ��Properties
        /// <summary>����f�[�^�v���p�e�B</summary>
        internal SalesSlip SalesSlip
        {
            get { return _salesSlip; }
        }
        /// <summary>���㖾�׃f�[�^���X�g�v���p�e�B</summary>
        internal List<SalesDetail> SalesDetailList
        {
            get { return _salesDetailList; }
        }
        /// <summary>�݌Ƀ��[�N���X�g�v���p�e�B</summary>
        internal List<StockWork> StockWorkList
        {
            get { return _stockWorkList; }
        }
        /// <summary>�󒍃}�X�^�i���q�j���X�g�v���p�e�B</summary>
        internal List<AcceptOdrCar> AcceptOdrCarList
        {
            get { return _acceptOdrCarList; }
        }
        #endregion

		/// <summary>
		/// �ۑ�����
		/// </summary>
		/// <returns>true:�ۑ����� false:�ۑ����s</returns>
		private bool Save()
		{
			if (this.tNedit_SalesSlipNum.GetInt() == 0)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"�`�[�ԍ������͂���Ă��܂���B",
					-1,
					MessageBoxButtons.OK);

				return false;
			}
			else
			{
                SalesSlip salesSlip;
                List<SalesDetail> salesDetailList;
                List<StockWork> stockWorkList;
                List<AcceptOdrCar> acceptOdrCarList;

                // �f�[�^���[�h����
                int status = this._estimateInputAcs.ReadDBData(this._enterpriseCode, this._acptAnOdrStatus, this.tNedit_SalesSlipNum.Text.PadLeft(9, '0'), false, out salesSlip, out salesDetailList, out stockWorkList, out acceptOdrCarList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._result = DialogResult.OK;
                    this._salesSlip = salesSlip;
                    this._salesDetailList = salesDetailList;
                    this._stockWorkList = stockWorkList;
                    this._acceptOdrCarList = acceptOdrCarList;
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�Y���f�[�^�����݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);

                    return false;
                }
			}

			return true;
		}

		/// <summary>
		/// �t�H�[�J�X�R���g���[���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                // �`�[�ԍ� ============================================ //
                case "tNedit_SalesSlipNum":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    int code = this.tNedit_SalesSlipNum.GetInt();

                                    if (code != 0)
                                    {
                                        bool canSave = this.Save();

                                        if (canSave)
                                        {
                                            this.Close();
                                        }
                                        else
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                    }
                                    break;
                                }
                        }

                        break;
                    }
            }
		}

		/// <summary>
		/// �m��{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uButton_Save_Click(object sender, EventArgs e)
		{
			bool canSave = this.Save();

			if (canSave)
			{
				this.Close();
			}
			else
			{
				this.tNedit_SalesSlipNum.Focus();
			}
		}

		/// <summary>
		/// ����{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uButton_Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// �t�H�[���N���[�Y�㔭���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void PMMIT01010UD_FormClosed(object sender, FormClosedEventArgs e)
		{
			DialogResult = this._result;
		}

		/// <summary>
		/// �t�H�[�����[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void PMMIT01010UD_Load(object sender, EventArgs e)
		{
            this.uButton_SalesSlipGuide.ImageList = this._imageList16;
            this.uButton_SalesSlipGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.tNedit_SalesSlipNum.SetInt(TStrConv.StrToIntDef(this._salesSlipNum, 0));

            this.timer_InitialSetFocus.Enabled = true;
        }

		/// <summary>
		/// �����t�H�[�J�X�ݒ�^�C�}�[�N���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
		{
			this.timer_InitialSetFocus.Enabled = false;
			this.tNedit_SalesSlipNum.Focus();
		}

		/// <summary>
        /// ����`�[�����K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uButton_SalesSlipGuide_Click(object sender, EventArgs e)
		{
            MAHNB04110UA salesSlipGuide = new MAHNB04110UA();
            salesSlipGuide.TComboEditor_SalesFormalCode = false;
            salesSlipGuide.AutoSearch = true;
            salesSlipGuide.SectionCode = this._estimateInputAcs.SalesSlip.ResultsAddUpSecCd;
            salesSlipGuide.SectionName = this._estimateInputAcs.SalesSlip.ResultsAddUpSecNm;
            salesSlipGuide.AcptAnOdrStatus = _acptAnOdrStatus;
            SalesSlipSearchResult searchResult;
            DialogResult result = salesSlipGuide.ShowGuide(this, _enterpriseCode, _acptAnOdrStatus, 3, out searchResult);

            if (result == DialogResult.OK)
            {
                if (searchResult != null)
                {
                    this.tNedit_SalesSlipNum.SetInt(TStrConv.StrToIntDef(searchResult.SalesSlipNum, 0));

                    bool canSave = this.Save();

                    if (canSave)
                    {
                        this.Close();
                    }
                    else
                    {
                        this.tNedit_SalesSlipNum.Focus();
                    }
                }
            }
        }
	}
}