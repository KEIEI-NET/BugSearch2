using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �`�[�ԍ����̓t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>UpDate</br>
    /// <br>2010/01/06 30434 �H�� MANTIS[14856] �R���g���[���̏����l�͌Œ�Ƃ���</br>
    /// <br>2010/12/03 yangmj ��Q���ǑΉ�</br>
    /// <br>Update Note: ���_�Ǘ� ���M�σf�[�^�`�F�b�N�s��Ή�</br>
    /// <br>Programmer : �e�c ���V</br>
    /// <br>Date       : 2012/08/30</br>
    /// </remarks>
	public partial class MAKON01110UD : Form
	{
		public MAKON01110UD(int supplierFormal, int supplierSlipNo, bool canSupplierFormalChange, MAKON01320UA.ExtractSlipCdType extractSlipCdType)
		{
			InitializeComponent();

			// �ϐ�������
			this._imageList16 = IconResourceManagement.ImageList16;
			this._stockSlipInputAcs = StockSlipInputAcs.GetInstance();

            // DEL 2010/01/06 MANTIS�Ή�[14856]�F�R���g���[���̏����l�͌Œ�Ƃ��� ---------->>>>>
            // MEMO:�ȉ��̃t�B�[���h�l�ɂ���ē`�[�ԍ��̎�ʁA�ԍ��w��̎�ʂ̑I���R���g���[���̏����l���ω�����̂ŁA�ݒ��p�~
            // this._supplierFormal = supplierFormal;
            // this._supplierSlipNo = supplierSlipNo;
            // DEL 2010/01/06 MANTIS�Ή�[14856]�F�R���g���[���̏����l�͌Œ�Ƃ��� ----------<<<<<

			this._canSupplierFormalChange = canSupplierFormalChange;
            this._extractSlipCdType = extractSlipCdType;
		}

        //----ADD 2010/12/03----->>>>>
        /// <summary>
        /// �d�����̓t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <param name="supplierFormal">�`�[�ԍ��̎��</param>
        /// <param name="supplierSlipNo">�ԍ��w��</param>
        /// <param name="canSupplierFormalChange">�`�[�ԍ��̎�ʂ��I�����邩�ǂ���</param>
        /// <param name="extractSlipCdType">�ԍ��^�C�v</param>
        /// <param name="type">�`�[��ʁ@�O�F���׌v��</param>
        public MAKON01110UD(int supplierFormal, int supplierSlipNo, bool canSupplierFormalChange, MAKON01320UA.ExtractSlipCdType extractSlipCdType, int type)
        {
            InitializeComponent();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._stockSlipInputAcs = StockSlipInputAcs.GetInstance();

            if (type == 0)
            {
                this._supplierFormal = supplierFormal;
            }

            this._canSupplierFormalChange = canSupplierFormalChange;
            this._extractSlipCdType = extractSlipCdType;
        }
        //----ADD 2010/12/03-----<<<<<

        public MAKON01110UD(int supplierFormal, string partySalesSlipNum, bool canSupplierFormalChange, MAKON01320UA.ExtractSlipCdType extractSlipCdType)
		{
			InitializeComponent();

			// �ϐ�������
			this._imageList16 = IconResourceManagement.ImageList16;
			this._stockSlipInputAcs = StockSlipInputAcs.GetInstance();

			this._supplierFormal = supplierFormal;
			this._partySalesSlipNum = partySalesSlipNum;
			this._canSupplierFormalChange = canSupplierFormalChange;
            this._extractSlipCdType = extractSlipCdType;
		}

		private ImageList _imageList16 = null;

		private StockSlipInputAcs _stockSlipInputAcs;
		private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

        // DEL 2010/01/06 MANTIS�Ή�[14856]�F�R���g���[���̏����l�͌Œ�Ƃ��� ---------->>>>>
        //private int _supplierFormal = 0;
        //private int _supplierSlipNo = 0;
        // DEL 2010/01/06 MANTIS�Ή�[14856]�F�R���g���[���̏����l�͌Œ�Ƃ��� ----------<<<<<
        // ADD 2010/01/06 MANTIS�Ή�[14856]�F�R���g���[���̏����l�͌Œ�Ƃ��� ---------->>>>>
        private readonly int _supplierFormal = 0;
        private readonly int _supplierSlipNo = 0;
        // ADD 2010/01/06 MANTIS�Ή�[14856]�F�R���g���[���̏����l�͌Œ�Ƃ��� ----------<<<<<

		private bool _canSupplierFormalChange = false;
		private string _partySalesSlipNum;
        private MAKON01320UA.ExtractSlipCdType _extractSlipCdType = MAKON01320UA.ExtractSlipCdType.All;

		private StockSlip _stockSlip = null;
        private StockSlip _baseStockSlip = null; // 2009.03.25
		private List<StockDetail> _stockDetailList = null;
		private List<StockDetail> _addUpSrcDetailList = null;
		private List<SalesTemp> _salesTempList = null;
		private PaymentSlp _paymentSlp = null;
        private List<PaymentDtl> _paymentDtlList = null;
		private List<StockWork> _stockWorkList = null;

		DialogResult _result = DialogResult.Cancel;

		#region ��Properties
        /// <summary>�d���f�[�^�v���p�e�B</summary>
        internal StockSlip StockSlip
        {
            get { return _stockSlip; }
        }

        // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>�␳�O�d���f�[�^�v���p�e�B</summary>
        internal StockSlip BaseStockSlip
        {
            get { return _baseStockSlip; }
        }
        // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>�d�����׃f�[�^���X�g�v���p�e�B</summary>
		internal List<StockDetail> StockDetailList
		{
			get { return _stockDetailList; }
		}

		/// <summary>�v�㌳���׃��X�g�v���p�e�B</summary>
		internal List<StockDetail> AddUpSrcDetailList
		{
			get { return _addUpSrcDetailList; }
		}

		/// <summary>�x���f�[�^�v���p�e�B</summary>
		internal PaymentSlp PaymentSlp
		{
			get { return _paymentSlp; }
		}

        /// <summary>�x�����׃f�[�^���X�g�v���p�e�B</summary>
        internal List<PaymentDtl> PaymentDtlList
        {
            get { return _paymentDtlList; }
        }

		/// <summary>����f�[�^(�d�������v��)�f�[�^���X�g</summary>
		internal List<SalesTemp> SalesTempList
		{
			get { return _salesTempList; }
		}

		/// <summary>�݌Ƀ��[�N���X�g</summary>
		internal List<StockWork> StockWorkList
		{
			get { return _stockWorkList; }
		}
		#endregion

		/// <summary>
		/// �ۑ�����
		/// </summary>
		/// <returns>true:�ۑ����� false:�ۑ����s</returns>
		private bool Save()
		{
			if (this.tNedit_SupplierSlipNo.GetInt() == 0)
			{
                int numberselect = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_NumberSelect, ComboEditorGetDataType.VALUE);
                string msg = ( numberselect == 0 ) ? "�`�[�ԍ�" : "�d��SEQ�ԍ�";
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    string.Format("{0}�����͂���Ă��܂���B", msg),
                    -1,
                    MessageBoxButtons.OK);

				return false;
			}
			else
			{
				StockSlip stockSlip;
                StockSlip baseStockSlip; // 2009.03.25
				List<StockDetail> stockDetailList;
				List<StockDetail> addUpSrcDetailList;
				PaymentSlp paymentSlp;
                List<PaymentDtl> paymentDtlList;
				List<SalesTemp> salesTempList;
				List<StockWork> stockWorkList;

				int supplierFormal = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_SupplierFormal);

				// �f�[�^���[�h����
                //int status = this._stockSlipInputAcs.ReadDBData(this._enterpriseCode, supplierFormal, this.tNedit_SupplierSlipNo.GetInt(), false, out stockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25
                int status = this._stockSlipInputAcs.ReadDBData(this._enterpriseCode, supplierFormal, this.tNedit_SupplierSlipNo.GetInt(), false, out stockSlip, out baseStockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    stockSlip.PreStockDate = stockSlip.StockDate;   //ADD 2012/08/30
                    this._result = DialogResult.OK;
					this._stockSlip = stockSlip;
                    this._baseStockSlip = baseStockSlip; // 2009.03.25
					this._stockDetailList = stockDetailList;
					this._paymentSlp = paymentSlp;
                    this._paymentDtlList = paymentDtlList;
					this._addUpSrcDetailList = addUpSrcDetailList;
					this._salesTempList = salesTempList;
					this._stockWorkList = stockWorkList;
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
		/// �ۑ�����(�����`�[�ԍ��p)
		/// </summary>
		/// <returns>true:�ۑ����� false:�ۑ����s</returns>
		private bool SavePartySalesSlipNum()
		{
			if (string.IsNullOrEmpty(this.tEdit_PartySaleSlipNum.Text))
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
				List<StockSlip> stockSlipList;
				int supplierFormal = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_SupplierFormal);

				int status = this._stockSlipInputAcs.ReadStockSlip(this._enterpriseCode, supplierFormal, this.tEdit_PartySaleSlipNum.Text, 1, out stockSlipList);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					StockSlip selectStockSlip;  
					// ���������������ꍇ�͓���d���`�[�ԍ��I����ʂ��N��
					if (( stockSlipList != null ) && ( stockSlipList.Count > 1 ))
					{
						MAKON01110UH stockSlipSelectGuide = new MAKON01110UH();

						DialogResult dialogResult = stockSlipSelectGuide.ShowDialog(this, supplierFormal, stockSlipList);
						if (( dialogResult == DialogResult.OK ))
						{
							selectStockSlip = stockSlipSelectGuide.SelectDataList[0];
						}
						else
						{
							return false;
						}
					}
					else
					{
						selectStockSlip = stockSlipList[0].Clone();
					}
					if (selectStockSlip != null)
					{
						StockSlip stockSlip;
                        StockSlip baseStockSlip; // 2009.03.25
						List<StockDetail> stockDetailList;
						List<StockDetail> addUpSrcDetailList;
						PaymentSlp paymentSlp;
                        List<PaymentDtl> paymentDtlList;
						List<SalesTemp> salesTempList;
						List<StockWork> stockWorkList;


						// �f�[�^���[�h����
                        //status = this._stockSlipInputAcs.ReadDBData(selectStockSlip.EnterpriseCode, selectStockSlip.SupplierFormal, selectStockSlip.SupplierSlipNo, false, out stockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25
                        status = this._stockSlipInputAcs.ReadDBData(selectStockSlip.EnterpriseCode, selectStockSlip.SupplierFormal, selectStockSlip.SupplierSlipNo, false, out stockSlip, out baseStockSlip, out stockDetailList, out addUpSrcDetailList, out paymentSlp, out paymentDtlList, out salesTempList, out stockWorkList); // 2009.03.25

						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
                            stockSlip.PreStockDate = stockSlip.StockDate;   //ADD 2012/08/30
                            this._result = DialogResult.OK;
							this._stockSlip = stockSlip;
                            this._baseStockSlip = baseStockSlip; // 2009.03.25
							this._stockDetailList = stockDetailList;
							this._paymentSlp = paymentSlp;
							this._addUpSrcDetailList = addUpSrcDetailList;
							this._salesTempList = salesTempList;
							this._stockWorkList = stockWorkList;
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
        /// <br>Update Note: 2010/12/03 yangmj �C���Ăяo�����̓`�[�ԍ����̓_�C�A���O�̓��͐���̏C��</br>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null || e.NextCtrl == null) return;

			switch (e.PrevCtrl.Name)
			{
				// �d��SEQ�ԍ� ============================================ //
				case "tNedit_SupplierSlipNo":
				{
					switch (e.Key)
					{
						case Keys.Return:
						{
							int code = this.tNedit_SupplierSlipNo.GetInt();

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
			// �`�[�ԍ� ============================================ //
			case "tEdit_PartySaleSlipNum":
				{
					switch (e.Key)
					{
						case Keys.Return:
							{
								string code = this.tEdit_PartySaleSlipNum.Text;

								if (!string.IsNullOrEmpty(code))
								{
									bool canSave = this.SavePartySalesSlipNum();

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
            //----ADD 2010/12/03----->>>>>
            // �ԍ��w�� ============================================ //
            case "tComboEditor_NumberSelect":
                {
                    int numberselect = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_NumberSelect, ComboEditorGetDataType.VALUE);
                    this.SlipNumberDisplayChange(numberselect);
                    switch (e.Key)
                    {
                        case Keys.Return:
                            {
                                if (this.tComboEditor_SupplierFormal.Enabled == true)
                                {
                                    this.tComboEditor_SupplierFormal.Focus();
                                }
                                else if (this.panel_PartySalesSlipNum.Visible == true && this.tEdit_PartySaleSlipNum.Enabled == true)
                                {
                                    this.tEdit_PartySaleSlipNum.Focus();
                                }
                                else if (this.tNedit_SupplierSlipNo.Visible == true && this.tNedit_SupplierSlipNo.Enabled == true)
                                {
                                    this.tNedit_SupplierSlipNo.Focus();
                                }
                                break;
                            }
                    }
                    break;
                }
            //----ADD 2010/12/03-----<<<<<
			}
		}

		/// <summary>
		/// �m��{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uButton_Save_Click(object sender, EventArgs e)
		{
            int numberselect = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_NumberSelect, ComboEditorGetDataType.VALUE);

            bool canSave = ( numberselect == 0 ) ? this.SavePartySalesSlipNum() : this.Save();

			if (canSave)
			{
				this.Close();
			}
			else
			{
                if (numberselect == 0)
                {
                    this.tNedit_SupplierSlipNo.Focus();
                }
                else
                {
                    this.tEdit_PartySaleSlipNum.Focus();
                }
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
		private void MAKON01110UD_FormClosed(object sender, FormClosedEventArgs e)
		{
			DialogResult = this._result;
		}

		/// <summary>
		/// �t�H�[�����[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void MAKON01110UD_Load(object sender, EventArgs e)
		{
			this.uButton_SupplierSlipGuide.ImageList = this._imageList16;
			this.uButton_SupplierSlipGuide.Appearance.Image = (int)Size16_Index.STAR1;

			this.uButton_PartySaleSlipNumGuide.ImageList = this._imageList16;
			this.uButton_PartySaleSlipNumGuide.Appearance.Image = (int)Size16_Index.STAR1;

			int numberSelectDefaultValue = ( this._supplierSlipNo == 0 ) ? 0 : 1;
			ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_NumberSelect, numberSelectDefaultValue, true);
			ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_SupplierFormal, this._supplierFormal, true);
			this.tNedit_SupplierSlipNo.SetInt(this._supplierSlipNo);
			this.tEdit_PartySaleSlipNum.Text = this._partySalesSlipNum;

			if (this._canSupplierFormalChange)
			{
				this.tComboEditor_SupplierFormal.Enabled = true;
			}
			else
			{
				this.tComboEditor_SupplierFormal.Enabled = false;
			}

			this.SlipNumberDisplayChange(numberSelectDefaultValue);

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
			this.tNedit_SupplierSlipNo.Focus();
		}

		/// <summary>
		/// �d���`�[�����K�C�h�{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		private void uButton_SupplierSlipGuide_Click(object sender, EventArgs e)
		{
            int supplierFormal = ComboEditorItemControl.GetComboEditorValueFromText(this.tComboEditor_SupplierFormal);

            MAKON01320UA supplierSlipGuide = new MAKON01320UA(this._stockSlipInputAcs.StockSlip.StockSectionCd, this._extractSlipCdType);
            supplierSlipGuide.SectionCode = this._stockSlipInputAcs.StockSlip.StockSectionCd;
            supplierSlipGuide.SectionName= this._stockSlipInputAcs.StockSlip.StockSectionNm;

			supplierSlipGuide.TComboEditor_SupplierFormal = this.tComboEditor_SupplierFormal.Enabled;
            DialogResult result = supplierSlipGuide.ShowDialog(this, supplierFormal);

            if (result == DialogResult.OK)
            {
                SearchRetStockSlip searchRetStockSlip = supplierSlipGuide.searchRetStockSlip;

                if (searchRetStockSlip != null)
                {
                    this.tNedit_SupplierSlipNo.SetInt(searchRetStockSlip.SupplierSlipNo);
					this.tEdit_PartySaleSlipNum.Text = searchRetStockSlip.PartySaleSlipNum;

                    ComboEditorItemControl.SetComboEditorItemIndex(this.tComboEditor_SupplierFormal, searchRetStockSlip.SupplierFormal, true);

                    bool canSave = this.Save();

                    if (canSave)
                    {
                        this.Close();
                    }
                    else
                    {
						if (sender == this.uButton_SupplierSlipGuide)
						{
							this.tNedit_SupplierSlipNo.Focus();
						}
						else if (sender == this.uButton_PartySaleSlipNumGuide)
						{
							this.tEdit_PartySaleSlipNum.Focus();
						}
                    }
                }
            }
		}

		/// <summary>
		/// �ԍ��w��R���{�G�f�B�^�I���m��㔭���C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tComboEditor_NumberSelect_SelectionChangeCommitted( object sender, EventArgs e )
		{
			int numberselect = ComboEditorItemControl.GetComboEditorValue(this.tComboEditor_NumberSelect, ComboEditorGetDataType.VALUE);
			this.SlipNumberDisplayChange(numberselect);
		}

		/// <summary>
		/// �`�[�ԍ��\���ύX
		/// </summary>
		/// <param name="numberSelect">�ԍ��w��</param>
		private void SlipNumberDisplayChange(int numberSelect)
		{
			switch (numberSelect)
			{
				case 1:
					{
						this.panel_PartySalesSlipNum.Visible = false;
						this.tNedit_SupplierSlipNo.Enabled = true;
						this.uButton_SupplierSlipGuide.Enabled = true;
						break;
					}
				default:
					{
						this.panel_PartySalesSlipNum.Visible = true;
						this.tNedit_SupplierSlipNo.Enabled = false;
						this.uButton_SupplierSlipGuide.Enabled = false;
						break;
					}
			}
		}

	
	}
}