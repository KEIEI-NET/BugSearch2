//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �I����������
// �v���O�����T�v   : �I�����������Ńf�[�^�d�����̏������@��I��������B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����@�m
// �� �� ��  2007/04/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/05/21  �C�����e : �d�l�ύX�@���ӏ����A�I�����͐��̍폜
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
	/// �I�����������d��������m�FUI�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �I�����������d��������m�FUI�N���X�̋@�\���������܂�</br>
	/// <br>Programmer : 23010 �����@�m</br>
	/// <br>Date       : 2007.04.04</br>
    /// <br>UpdateNote : 2009/05/21 �Ɠc �M�u�@���ӏ����A�I�����͐��̍폜</br>
    /// <br>           : </br>
    /// </remarks>
	public partial class BeforeSaveCheckDialog : Form
	{
		#region Constructor
		/// <summary>
		/// �I�����������d��������m�FUI�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : �I�����������d��������m�FUI�N���X�̃C���X�^���X�����������܂�</br>
		/// <br>Programmer : 23010 �����@�m</br>
	    /// <br>Date       : 2007.04.04</br>
		/// </remarks>
		public BeforeSaveCheckDialog ()
		{
//MessageBox.Show("","");
            InitializeComponent();

			// ��������
			InitialSetting();
		}
		#endregion

		#region Private Member
		/// <summary> ����݌ɂ̏����敪(0:���������Ώۂɂ��Ȃ�,1:���������Ώۂɂ���) </summary>
		private int _alreadyData;
		/// <summary> �I�����͐������敪(0:�c��,1:�N���A) </summary>
		private int _repetitionData;
        /// <summary> �I�������敪(0:�č쐬(�I�����͐��N���A),1:�č쐬(�I�����͐��͎c��),2:�c��,3:�폜) </summary>
		private int _inventoryProcDiv;

		#endregion

        #region Const

        //����݌ɂ̏����敪
        private const string ctNOTTARGET    = "���������Ώۂɂ��Ȃ�";
        private const string ctTARGET       = "���������Ώۂɂ���";
        //�I�����͐������敪
        private const string ctSTAY         = "�c��";
        private const string ctCLEAR        = "�N���A";

        #endregion

        #region Public Property
        /// <summary>
		/// ����݌ɂ̏����敪(�ǂݎ���p)
		/// </summary>
		public int AlreadyData
		{
			get { return this._alreadyData; }
		}
		/// <summary>
		/// �I�����͐������敪(�ǂݎ���p)
		/// </summary>
		public int RepetitionData
		{
			get { return this._repetitionData; }
        }
        /// <summary>
		/// �݌ɏ����敪(�ǂݎ���p)
		/// </summary>
        public int InventoryProcDiv
		{
			get { return this._inventoryProcDiv; }
        }
        #endregion

        #region Public Enum
		/// <summary>
		/// ����݌ɂ̏����敪
		/// </summary>
		public enum AlreadyDataState
		{
			/// <summary> ���������Ώۂɂ��Ȃ� </summary>
			NotTarget = 0,
			/// <summary> ���������Ώۂɂ��� </summary>
			Target = 1
		}
		/// <summary>
		/// �I�����͐������敪
		/// </summary>
		public enum InventoryDataState
		{
			/// <summary> �c��</summary>
			Stay = 0,
			/// <summary> �N���A </summary>
			Clear = 1
		}
		#endregion

		#region Private Method

		#region ��������
		/// <summary>
		/// ��������
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����������s���B</br>
		/// <br>Programmer : 23010 �����@�m</br>
	    /// <br>Date       : 2007.04.04</br>
		/// </remarks>
		private void InitialSetting()
		{
			// �R���{�{�b�N�X�ɃA�C�e���ǉ�
			// ����݌ɂ̏����敪
			this.tceAlreadyData.Items.Clear();
			this.tceAlreadyData.Items.Add(AlreadyDataState.NotTarget, ctNOTTARGET);
			this.tceAlreadyData.Items.Add(AlreadyDataState.Target, ctTARGET);
			this.tceAlreadyData.MaxDropDownItems = this.tceAlreadyData.Items.Count;
			this.tceAlreadyData.SelectedIndex = 0;

			//�I�����͐������敪
			//����݌ɂ̏����敪���u���������Ώۂɂ���v�̂Ƃ������I�����\�ɂȂ�B
			this.tceRepetitionData.Items.Clear();
			this.tceRepetitionData.Items.Add(InventoryDataState.Stay, ctSTAY);
			this.tceRepetitionData.Items.Add(InventoryDataState.Clear, ctCLEAR);
			this.tceRepetitionData.MaxDropDownItems = this.tceRepetitionData.Items.Count;
			this.tceRepetitionData.SelectedIndex = 0;
			this.tceRepetitionData.Enabled = false;
            this.tceRepetitionData.Visible = false;                 //ADD 2009/05/21 �I�����͐��̍폜
            this.StockAnalysisDivCdTitle_Label.Visible = false;     //ADD 2009/05/21 �I�����͐��^�C�g���̍폜

            this.ultraLabel4.Visible = false;                       //ADD 2009/05/21 ���ӏ����̍폜

			// �{�^���A�C�R���ݒ�
			this.ubSave.ImageList = IconResourceManagement.ImageList16;
			this.ubReturn.ImageList = IconResourceManagement.ImageList16;

			this.ubSave.Appearance.Image	= Size16_Index.SAVE;
			this.ubReturn.Appearance.Image	= Size16_Index.BEFORE;
		}
		#endregion

		#endregion

		#region Control Event

		#region ����݌ɂ̏����敪 ComboBox(tceAlreadyData)

		#region ValueChanged Event
		/// <summary>
		/// tceAlreadyData_ValueChanged Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void tceAlreadyData_ValueChanged ( object sender, EventArgs e )
		{
            // ---DEL 2009/05/21 �I�����͐��폜�̈� ------------------------------------------->>>>>
            //bool repDataEnable = false;

            //// ����݌ɂ̏����敪���u���������Ώۂɂ���v�Ȃ�΁A�I�����͐������敪��I���ɂ���B
            //if ( (AlreadyDataState)tceAlreadyData.SelectedItem.DataValue == AlreadyDataState.Target ) 
            //    repDataEnable = true;
            //else
            //    repDataEnable = false;

            //this.tceRepetitionData.Enabled = repDataEnable;
            // ---DEL 2009/05/21 �I�����͐��폜�̈� -------------------------------------------<<<<<
        }
		#endregion

		#endregion
		
		#region ubSaveButtonClick Event
		/// <summary>
		/// ubSave_Click Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void ubSave_Click ( object sender, EventArgs e )
		{
			// �I����Ԃ̎擾
			this._alreadyData		= (int)this.tceAlreadyData.SelectedItem.DataValue;		// ����݌ɂ̏����敪
            // ---DEL 2009/05/21 �I�����͐��폜�̈� ----------------------------->>>>>
            //this._repetitionData = (int)this.tceRepetitionData.SelectedItem.DataValue;	// �I�����͐������敪

            ////�I�������敪���Z�b�g
            //// ����݌ɂ̏����敪
            //switch(this._alreadyData)
            //{
            //    //���������Ώۂɂ��Ȃ�
            //    case 0:
            //    {
            //        //�I�������敪
            //        this._inventoryProcDiv = 2;
            //        break;
            //    }
            //    //���������Ώۂɂ���
            //    case 1:
            //    {
            //        //�I�����͐������敪
            //        switch(this._repetitionData)
            //        {
            //            //�c��
            //            case 0:
            //            {
            //                //�I�������敪
            //                this._inventoryProcDiv = 1;
            //                break;
            //            }
            //            //�N���A
            //            case 1:
            //            {
            //                //�I�������敪
            //                this._inventoryProcDiv = 0;
            //                break;
            //            }
            //        }
            //        break;
            //    }
            //}
            // ---DEL 2009/05/21 �I�����͐��폜�̈� -----------------------------<<<<<
            // �u0:���������Ώۂɂ��Ȃ��v�u1:���������Ώۂɂ���v�Ƃ���B
            this._inventoryProcDiv = this._alreadyData;     //ADD 2009/05/21 �I�����͐��폜�̈�

            //�`�悪�Ԃɍ���Ȃ��̂Ő��Hide���Ă���
            this.Hide();
			// ���g��DialogResult��Ok�ɂ��ďI��
			this.DialogResult = DialogResult.OK;
            this.Close();

		}
		#endregion

		#region ubReturnButtonClick Event
		/// <summary>
		/// ubReturn_Click Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void ubReturn_Click ( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.Cancel;
		}
		#endregion

		#endregion
	}
}