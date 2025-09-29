using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
//using Broadleaf.Application.Remoting.ParamData;  // DEL 2008/06/03
using Broadleaf.Library.Text;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// SFKTN09000UA�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���_���ݒ���s���܂��B</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.03.18</br>
	/// <br></br>
	/// <br>Update Note: 2005.05.28 22025 �c�� �L</br>
	/// <br>					�E�t���[���̍ŏ����Ή�</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.17 22025 �c�� �L</br>
	/// <br>					�E�X�V���[�h�̏����t�H�[�J�X���ڂ�SelectAll�Ή�</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.18 22025 �c�� �L</br>
	/// <br>					�EForeColorDisabled��BackColorDisabled�̐ݒ�Ή�</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.20 22025 �c�� �L</br>
	/// <br>					�ELabel(�X�֔ԍ��}�[�N�̉E)��BackColorDisabled�̐ݒ�Ή�</br>
	/// <br></br>
	/// <br>Update Note: 2005.09.02 22021 �J���@�͍K</br> 
	/// <br>					�E�ۑ��m�F��̃G���^�[�L�[�������̃t�H�[�J�X�Ή�</br>
	/// <br></br>
	/// <br>Update Note: 2005.09.05 22033 �O��  �M�j</br>
	/// <br>					�E�X�֔ԍ������C��</br>
	/// <br>Update Note: 2005.09.08 22021 �J���@�͍K</br>
	/// <br>					�E���O�C�����擾���i�̑g����</br>
	/// <br>Update Note: 2005.09.22 23001 �H�R�@����</br>
	/// <br>					�E���b�Z�[�W�{�b�N�X�\�����i�̑g����</br>
	/// <br>Update Note: 2005.10.19 22021 �J���@�͍K</br>
	/// <br>		   :        �EUI�q���Hide����Owner.Activate�����ǉ�</br>
    /// <br>Update Note: 2006.01.13 22021 �J���@�͍K</br>
    /// <br>		   :        �E�R�[�h���͗�����s�S�Ή�</br>
    /// <br>Update Note: 2006.08.28 22021 �J���@�͍K</br>
    /// <br>		   :        �E���_OP���f���W�b�N�̕ύX</br>
    /// <br>Update Note: 2006.09.06 22021 �J���@�͍K</br>
    /// <br>		   :        �E���_OP�����̏ꍇ�͑����_�`�[���Ж�����敪�A�{��/���_�@�\�敪�̕\����Enable�ɂ���</br>
    /// <br>Update Note: 2006.09.26 22021 �J���@�͍K</br>
    /// <br>		   :        �E���_�R�[�h��0�`000000�̊Ԃ̏ꍇ�ɓ��̓`�F�b�N��������悤�ɏC��</br>
    /// <br>Update Note: 2006.12.13 22022 �i�� �m�q</br>
    /// <br>					1.SF�ł𗬗p���g�єł��쐬</br>
    /// <br>					2.���Ж���1��K�{���͂֕ύX</br>
    /// <br>Update Note: 2007.10.5  ��c �h��</br>
    /// <br>					�q��1�A2�A3����ʂɒǉ�</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008/06/03 30414�@�E�@�K�j</br>
    /// <br>           :�u���_���́v�u�����N�����v�ǉ��A�u�����_�`�[���Ж�����敪�v�u�\���Q�`�P�O�v�폜</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008/09/08 30414�@�E�@�K�j</br>
    /// <br>           :�u�����N�����v��N�����̂ݕ\������悤�C��</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008/09/12 30414�@�E�@�K�j</br>
    /// <br>           :�q�ɃK�C�h�{�^����ǉ�</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2013/02/06 �e�c�@���V</br>
    /// <br>           :�폜�ς݃f�[�^�̕\�����ɑq�ɃK�C�h�{�^���������ɂȂ��Ă����Q�̏C��</br>
    /// -----------------------------------------------------------------------
    /// </remarks>
	public class SFKTN09000UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{

		# region Private Members (Component)
		private System.ComponentModel.IContainer components;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraLabel EmployeeCode_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel20;
        private Broadleaf.Library.Windows.Forms.TEdit edtSectionGuideNm;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Data.DataSet Bind_DataSet;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionCode;
        private Infragistics.Win.Misc.UltraLabel CompanyName1_Title_Label;
		private Broadleaf.Library.Windows.Forms.TNedit CompanyNameCd1_tNedit;
        private Broadleaf.Library.Windows.Forms.TEdit CompanyName1_tEdit;
        // �� 2007.10.5 Keigo Yata add////////////////////////////////////////////////////////
        private Infragistics.Win.Misc.UltraLabel sectWarehouseNm1_Title_Label;
        private Infragistics.Win.Misc.UltraLabel sectWarehouseNm2_Title_Label;
        private Infragistics.Win.Misc.UltraLabel sectWarehouseNm3_Title_Label;
        private TEdit tEdit_WarehouseCode1;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_WarehouseCode2;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_WarehouseCode3;
        private Broadleaf.Library.Windows.Forms.TEdit SectWarehouseNm1_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit SectWarehouseNm2_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit SectWarehouseNm3_tEdit;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private TEdit edtSectionGuideSnm;
        private Infragistics.Win.Misc.UltraLabel ultraLabel18;
        private TDateEdit IntroductionDate_tDateEdit;
        private Infragistics.Win.Misc.UltraButton WarehouseGuide01_Button;
        private Infragistics.Win.Misc.UltraButton WarehouseGuide03_Button;
        private Infragistics.Win.Misc.UltraButton WarehouseGuide02_Button;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private UltraButton Renewal_Button;
        // �� 2007.10.5 Keigo Yata add ////////////////////////////////////////////////////////
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		# endregion

		# region Constructor
		/// <summary>
		/// SFKTN09000UA�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		public SFKTN09000UA()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

///////////////////////////////////////////////////////////////////// 2005.09.15 AKIYAMA ADD STA //
			// �G�f�B�b�g�����X�g�ɒǉ�
			SetCompanyNameControlList();
// 2005.09.15 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // �� 2007.10.5 Keigo Yata add//////////////////////////////////////////////////////////////////
            // �G�f�B�b�g�����X�g�ɒǉ�
            SetSectWarehouseNmControlList();
            // �� 2007.10.5 Keigo Yata add/////////////////////////////////////////////////////////////////

			// �f�[�^�Z�b�g����\�z����
			DataSetColumnConstruction();

			// ���C���t���[���V�K�{�^���p�t���O
			this._canNewFlg = true;
			// �ϐ�������
			this.secInfoSetTable = new Hashtable();
			this.secInfoSetAcs = new SecInfoSetAcs();
			this.totalCount = 0;

			// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			// Grid��IndexBuffer�i�[�p�ϐ��̏�����
			this._IndexBuffer = -2;
			// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            // ���_OP���f�p�t���O
            this._sectionFlg = false;
			// 2005.09.08 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 2005.09.08 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            #region // 2006.08.28 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            // --- ���_�I�v�V�����������Ŋ��Ƀ��R�[�h�����݂���ꍇ�͐V�K�s�� --- //
            // ���_�I�v�V�����`�F�b�N
            //if ((LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) != PurchaseStatus.Contract) ||
            //    (LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) != PurchaseStatus.Trial_Contract))
            //{
            //this._canDelete = false;
            //this._canLogicalDeleteDataExtraction = false;

            //int dummy = 0;
            //// ���R�[�h�����擾�̈�Search
            //Search (ref dummy, 0);

            //if (this.secInfoSetTable.Count >= 1)
            //{
            //    // ���C���t���[���V�K�{�^���p�t���O
            //    this._canNewFlg = false;
            //}
            //}
            //else
            //{
            //this._canDelete = true;
            //this._canLogicalDeleteDataExtraction = true;

            //}

            // 2006.08.28 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            #endregion

            // 2006.08.28 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START

            // --- ���_�I�v�V�����������Ŋ��Ƀ��R�[�h�����݂���ꍇ�͐V�K�s�� --- //
            // ���_�I�v�V�����`�F�b�N
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
            {
                this._canDelete = true;
                this._canLogicalDeleteDataExtraction = true;
            }
            else
            {
                this._canDelete = false;
                this._canLogicalDeleteDataExtraction = false;

                int dummy = 0;
                // ���R�[�h�����擾�̈�Search
                Search(ref dummy, 0);

                if (this.secInfoSetTable.Count >= 1)
                {
                    // ���C���t���[���V�K�{�^���p�t���O
                    this._canNewFlg = false;
                }
            }
            // 2006.08.28 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// �v���p�e�B�[�ϐ�������
			this._canPrint = false;
			if (this._canNewFlg)
			{
				this._canNew = true;
			}
			else
			{
				this._canNew = false;
			}
			this._canClose = true;		
			this._defaultAutoFillToColumn = false;
			this._dataIndex = -1;
			this._canSpecificationSearch = false;

            // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
            this._warehouseAcs = new WarehouseAcs();
            // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<
		}
		# endregion

		# region Dispose
		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
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
		# endregion

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�q�ɃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�q�ɃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�q�ɃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFKTN09000UA));
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Bind_DataSet = new System.Data.DataSet();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.EmployeeCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.edtSectionGuideNm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tEdit_SectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyName1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyNameCd1_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CompanyName1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.sectWarehouseNm1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.sectWarehouseNm2_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SectWarehouseNm1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectWarehouseNm2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.sectWarehouseNm3_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SectWarehouseNm3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_WarehouseCode1 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_WarehouseCode2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_WarehouseCode3 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.edtSectionGuideSnm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.IntroductionDate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.WarehouseGuide01_Button = new Infragistics.Win.Misc.UltraButton();
            this.WarehouseGuide02_Button = new Infragistics.Win.Misc.UltraButton();
            this.WarehouseGuide03_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyNameCd1_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyName1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectWarehouseNm1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectWarehouseNm2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectWarehouseNm3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSectionGuideSnm)).BeginInit();
            this.SuspendLayout();
            // 
            // Delete_Button
            // 
            this.Delete_Button.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.Delete_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F);
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(565, 329);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 17;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 373);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(947, 23);
            this.ultraStatusBar1.TabIndex = 45;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(842, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 46;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // Revive_Button
            // 
            this.Revive_Button.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.Revive_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F);
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(690, 329);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 18;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.Ok_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F);
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(690, 329);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 18;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.Cancel_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F);
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(815, 329);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 19;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // EmployeeCode_Title_Label
            // 
            appearance74.TextVAlignAsString = "Middle";
            this.EmployeeCode_Title_Label.Appearance = appearance74;
            this.EmployeeCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.EmployeeCode_Title_Label.Location = new System.Drawing.Point(20, 30);
            this.EmployeeCode_Title_Label.Name = "EmployeeCode_Title_Label";
            this.EmployeeCode_Title_Label.Size = new System.Drawing.Size(195, 24);
            this.EmployeeCode_Title_Label.TabIndex = 29;
            this.EmployeeCode_Title_Label.Text = "���_�R�[�h";
            // 
            // edtSectionGuideNm
            // 
            appearance85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.edtSectionGuideNm.ActiveAppearance = appearance85;
            appearance86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance86.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance86.ForeColorDisabled = System.Drawing.Color.Black;
            this.edtSectionGuideNm.Appearance = appearance86;
            this.edtSectionGuideNm.AutoSelect = true;
            this.edtSectionGuideNm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.edtSectionGuideNm.DataText = "";
            this.edtSectionGuideNm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.edtSectionGuideNm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.edtSectionGuideNm.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.edtSectionGuideNm.Location = new System.Drawing.Point(215, 60);
            this.edtSectionGuideNm.MaxLength = 6;
            this.edtSectionGuideNm.Name = "edtSectionGuideNm";
            this.edtSectionGuideNm.Size = new System.Drawing.Size(113, 24);
            this.edtSectionGuideNm.TabIndex = 1;
            // 
            // ultraLabel2
            // 
            appearance73.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance73;
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel2.Location = new System.Drawing.Point(20, 60);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(195, 24);
            this.ultraLabel2.TabIndex = 30;
            this.ultraLabel2.Text = "�K�C�h����";
            // 
            // ultraLabel20
            // 
            this.ultraLabel20.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel20.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel20.Location = new System.Drawing.Point(15, 165);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(915, 3);
            this.ultraLabel20.TabIndex = 34;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // tEdit_SectionCode
            // 
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCode.ActiveAppearance = appearance25;
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance26.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance26.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCode.Appearance = appearance26;
            this.tEdit_SectionCode.AutoSelect = true;
            this.tEdit_SectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCode.DataText = "";
            this.tEdit_SectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Top, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, true, true));
            this.tEdit_SectionCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tEdit_SectionCode.Location = new System.Drawing.Point(215, 30);
            this.tEdit_SectionCode.MaxLength = 2;
            this.tEdit_SectionCode.Name = "tEdit_SectionCode";
            this.tEdit_SectionCode.Size = new System.Drawing.Size(35, 24);
            this.tEdit_SectionCode.TabIndex = 0;
            // 
            // CompanyName1_Title_Label
            // 
            appearance63.TextVAlignAsString = "Middle";
            this.CompanyName1_Title_Label.Appearance = appearance63;
            this.CompanyName1_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.CompanyName1_Title_Label.Location = new System.Drawing.Point(20, 185);
            this.CompanyName1_Title_Label.Name = "CompanyName1_Title_Label";
            this.CompanyName1_Title_Label.Size = new System.Drawing.Size(195, 24);
            this.CompanyName1_Title_Label.TabIndex = 35;
            this.CompanyName1_Title_Label.Text = "���Ж���";
            // 
            // CompanyNameCd1_tNedit
            // 
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance21.ForeColor = System.Drawing.Color.Black;
            appearance21.TextHAlignAsString = "Right";
            appearance21.TextVAlignAsString = "Middle";
            this.CompanyNameCd1_tNedit.ActiveAppearance = appearance21;
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance22.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance22.ForeColor = System.Drawing.Color.Black;
            appearance22.ForeColorDisabled = System.Drawing.Color.Black;
            appearance22.TextHAlignAsString = "Right";
            appearance22.TextVAlignAsString = "Middle";
            this.CompanyNameCd1_tNedit.Appearance = appearance22;
            this.CompanyNameCd1_tNedit.AutoSelect = true;
            this.CompanyNameCd1_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CompanyNameCd1_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CompanyNameCd1_tNedit.DataText = "";
            this.CompanyNameCd1_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyNameCd1_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.CompanyNameCd1_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CompanyNameCd1_tNedit.Location = new System.Drawing.Point(215, 185);
            this.CompanyNameCd1_tNedit.MaxLength = 4;
            this.CompanyNameCd1_tNedit.Name = "CompanyNameCd1_tNedit";
            this.CompanyNameCd1_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.CompanyNameCd1_tNedit.Size = new System.Drawing.Size(43, 24);
            this.CompanyNameCd1_tNedit.TabIndex = 6;
            this.CompanyNameCd1_tNedit.ValueChanged += new System.EventHandler(this.Control_ValueChanged);
            this.CompanyNameCd1_tNedit.Leave += new System.EventHandler(this.CompanyNameCd_tNedit_Leave);
            this.CompanyNameCd1_tNedit.Enter += new System.EventHandler(this.CompanyNameCd_tNedit_Enter);
            // 
            // CompanyName1_tEdit
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.TextVAlignAsString = "Middle";
            this.CompanyName1_tEdit.ActiveAppearance = appearance19;
            appearance20.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.ForeColorDisabled = System.Drawing.Color.Black;
            appearance20.TextVAlignAsString = "Middle";
            this.CompanyName1_tEdit.Appearance = appearance20;
            this.CompanyName1_tEdit.AutoSelect = true;
            this.CompanyName1_tEdit.DataText = "";
            this.CompanyName1_tEdit.Enabled = false;
            this.CompanyName1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyName1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 41, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyName1_tEdit.Location = new System.Drawing.Point(265, 185);
            this.CompanyName1_tEdit.MaxLength = 41;
            this.CompanyName1_tEdit.Name = "CompanyName1_tEdit";
            this.CompanyName1_tEdit.Size = new System.Drawing.Size(670, 24);
            this.CompanyName1_tEdit.TabIndex = 7;
            // 
            // sectWarehouseNm1_Title_Label
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.sectWarehouseNm1_Title_Label.Appearance = appearance16;
            this.sectWarehouseNm1_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.sectWarehouseNm1_Title_Label.Location = new System.Drawing.Point(20, 215);
            this.sectWarehouseNm1_Title_Label.Name = "sectWarehouseNm1_Title_Label";
            this.sectWarehouseNm1_Title_Label.Size = new System.Drawing.Size(195, 24);
            this.sectWarehouseNm1_Title_Label.TabIndex = 47;
            this.sectWarehouseNm1_Title_Label.Text = "�q��1";
            // 
            // sectWarehouseNm2_Title_Label
            // 
            appearance15.TextVAlignAsString = "Middle";
            this.sectWarehouseNm2_Title_Label.Appearance = appearance15;
            this.sectWarehouseNm2_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.sectWarehouseNm2_Title_Label.Location = new System.Drawing.Point(20, 245);
            this.sectWarehouseNm2_Title_Label.Name = "sectWarehouseNm2_Title_Label";
            this.sectWarehouseNm2_Title_Label.Size = new System.Drawing.Size(195, 24);
            this.sectWarehouseNm2_Title_Label.TabIndex = 48;
            this.sectWarehouseNm2_Title_Label.Text = "�q��2";
            // 
            // SectWarehouseNm1_tEdit
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.TextVAlignAsString = "Middle";
            this.SectWarehouseNm1_tEdit.ActiveAppearance = appearance13;
            appearance14.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            appearance14.TextVAlignAsString = "Middle";
            this.SectWarehouseNm1_tEdit.Appearance = appearance14;
            this.SectWarehouseNm1_tEdit.AutoSelect = true;
            this.SectWarehouseNm1_tEdit.DataText = "";
            this.SectWarehouseNm1_tEdit.Enabled = false;
            this.SectWarehouseNm1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectWarehouseNm1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectWarehouseNm1_tEdit.Location = new System.Drawing.Point(281, 215);
            this.SectWarehouseNm1_tEdit.MaxLength = 20;
            this.SectWarehouseNm1_tEdit.Name = "SectWarehouseNm1_tEdit";
            this.SectWarehouseNm1_tEdit.Size = new System.Drawing.Size(314, 24);
            this.SectWarehouseNm1_tEdit.TabIndex = 9;
            // 
            // SectWarehouseNm2_tEdit
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.TextVAlignAsString = "Middle";
            this.SectWarehouseNm2_tEdit.ActiveAppearance = appearance11;
            appearance12.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.SectWarehouseNm2_tEdit.Appearance = appearance12;
            this.SectWarehouseNm2_tEdit.AutoSelect = true;
            this.SectWarehouseNm2_tEdit.DataText = "";
            this.SectWarehouseNm2_tEdit.Enabled = false;
            this.SectWarehouseNm2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectWarehouseNm2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectWarehouseNm2_tEdit.Location = new System.Drawing.Point(281, 245);
            this.SectWarehouseNm2_tEdit.MaxLength = 20;
            this.SectWarehouseNm2_tEdit.Name = "SectWarehouseNm2_tEdit";
            this.SectWarehouseNm2_tEdit.Size = new System.Drawing.Size(314, 24);
            this.SectWarehouseNm2_tEdit.TabIndex = 12;
            // 
            // sectWarehouseNm3_Title_Label
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.sectWarehouseNm3_Title_Label.Appearance = appearance10;
            this.sectWarehouseNm3_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.sectWarehouseNm3_Title_Label.Location = new System.Drawing.Point(20, 275);
            this.sectWarehouseNm3_Title_Label.Name = "sectWarehouseNm3_Title_Label";
            this.sectWarehouseNm3_Title_Label.Size = new System.Drawing.Size(195, 24);
            this.sectWarehouseNm3_Title_Label.TabIndex = 53;
            this.sectWarehouseNm3_Title_Label.Text = "�q��3";
            // 
            // SectWarehouseNm3_tEdit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.SectWarehouseNm3_tEdit.ActiveAppearance = appearance8;
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextVAlignAsString = "Middle";
            this.SectWarehouseNm3_tEdit.Appearance = appearance9;
            this.SectWarehouseNm3_tEdit.AutoSelect = true;
            this.SectWarehouseNm3_tEdit.DataText = "";
            this.SectWarehouseNm3_tEdit.Enabled = false;
            this.SectWarehouseNm3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectWarehouseNm3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectWarehouseNm3_tEdit.Location = new System.Drawing.Point(281, 275);
            this.SectWarehouseNm3_tEdit.MaxLength = 20;
            this.SectWarehouseNm3_tEdit.Name = "SectWarehouseNm3_tEdit";
            this.SectWarehouseNm3_tEdit.Size = new System.Drawing.Size(314, 24);
            this.SectWarehouseNm3_tEdit.TabIndex = 15;
            // 
            // tEdit_WarehouseCode1
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextVAlignAsString = "Middle";
            this.tEdit_WarehouseCode1.ActiveAppearance = appearance6;
            appearance7.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            appearance7.TextVAlignAsString = "Middle";
            this.tEdit_WarehouseCode1.Appearance = appearance7;
            this.tEdit_WarehouseCode1.AutoSelect = true;
            this.tEdit_WarehouseCode1.DataText = "";
            this.tEdit_WarehouseCode1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_WarehouseCode1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, true, true, true, true));
            this.tEdit_WarehouseCode1.Location = new System.Drawing.Point(215, 215);
            this.tEdit_WarehouseCode1.MaxLength = 6;
            this.tEdit_WarehouseCode1.Name = "tEdit_WarehouseCode1";
            this.tEdit_WarehouseCode1.Size = new System.Drawing.Size(59, 24);
            this.tEdit_WarehouseCode1.TabIndex = 8;
            // 
            // tEdit_WarehouseCode2
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextVAlignAsString = "Middle";
            this.tEdit_WarehouseCode2.ActiveAppearance = appearance4;
            appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            appearance5.TextVAlignAsString = "Middle";
            this.tEdit_WarehouseCode2.Appearance = appearance5;
            this.tEdit_WarehouseCode2.AutoSelect = true;
            this.tEdit_WarehouseCode2.DataText = "";
            this.tEdit_WarehouseCode2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_WarehouseCode2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, true, true, true, true));
            this.tEdit_WarehouseCode2.Location = new System.Drawing.Point(215, 245);
            this.tEdit_WarehouseCode2.MaxLength = 6;
            this.tEdit_WarehouseCode2.Name = "tEdit_WarehouseCode2";
            this.tEdit_WarehouseCode2.Size = new System.Drawing.Size(59, 24);
            this.tEdit_WarehouseCode2.TabIndex = 11;
            // 
            // tEdit_WarehouseCode3
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.tEdit_WarehouseCode3.ActiveAppearance = appearance2;
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextVAlignAsString = "Middle";
            this.tEdit_WarehouseCode3.Appearance = appearance3;
            this.tEdit_WarehouseCode3.AutoSelect = true;
            this.tEdit_WarehouseCode3.DataText = "";
            this.tEdit_WarehouseCode3.Enabled = false;
            this.tEdit_WarehouseCode3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_WarehouseCode3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, true, true, true, true));
            this.tEdit_WarehouseCode3.Location = new System.Drawing.Point(215, 275);
            this.tEdit_WarehouseCode3.MaxLength = 6;
            this.tEdit_WarehouseCode3.Name = "tEdit_WarehouseCode3";
            this.tEdit_WarehouseCode3.Size = new System.Drawing.Size(59, 24);
            this.tEdit_WarehouseCode3.TabIndex = 14;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // ultraLabel18
            // 
            appearance72.TextVAlignAsString = "Middle";
            this.ultraLabel18.Appearance = appearance72;
            this.ultraLabel18.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel18.Location = new System.Drawing.Point(20, 90);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(195, 24);
            this.ultraLabel18.TabIndex = 31;
            this.ultraLabel18.Text = "���_����";
            // 
            // edtSectionGuideSnm
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.edtSectionGuideSnm.ActiveAppearance = appearance17;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance28.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance28.ForeColorDisabled = System.Drawing.Color.Black;
            this.edtSectionGuideSnm.Appearance = appearance28;
            this.edtSectionGuideSnm.AutoSelect = true;
            this.edtSectionGuideSnm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.edtSectionGuideSnm.DataText = "";
            this.edtSectionGuideSnm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.edtSectionGuideSnm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.edtSectionGuideSnm.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.edtSectionGuideSnm.Location = new System.Drawing.Point(215, 90);
            this.edtSectionGuideSnm.MaxLength = 10;
            this.edtSectionGuideSnm.Name = "edtSectionGuideSnm";
            this.edtSectionGuideSnm.Size = new System.Drawing.Size(175, 24);
            this.edtSectionGuideSnm.TabIndex = 2;
            // 
            // ultraLabel1
            // 
            appearance64.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance64;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.Location = new System.Drawing.Point(20, 120);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(195, 24);
            this.ultraLabel1.TabIndex = 55;
            this.ultraLabel1.Text = "�����N����";
            // 
            // IntroductionDate_tDateEdit
            // 
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.IntroductionDate_tDateEdit.ActiveEditAppearance = appearance78;
            this.IntroductionDate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.IntroductionDate_tDateEdit.CalendarDisp = true;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance79.ForeColor = System.Drawing.Color.Black;
            appearance79.ForeColorDisabled = System.Drawing.Color.Black;
            appearance79.TextHAlignAsString = "Left";
            appearance79.TextVAlignAsString = "Middle";
            this.IntroductionDate_tDateEdit.EditAppearance = appearance79;
            this.IntroductionDate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.IntroductionDate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance80.TextHAlignAsString = "Left";
            appearance80.TextVAlignAsString = "Middle";
            this.IntroductionDate_tDateEdit.LabelAppearance = appearance80;
            this.IntroductionDate_tDateEdit.Location = new System.Drawing.Point(215, 120);
            this.IntroductionDate_tDateEdit.Name = "IntroductionDate_tDateEdit";
            this.IntroductionDate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.IntroductionDate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.IntroductionDate_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.IntroductionDate_tDateEdit.TabIndex = 5;
            this.IntroductionDate_tDateEdit.TabStop = true;
            // 
            // WarehouseGuide01_Button
            // 
            appearance18.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.WarehouseGuide01_Button.Appearance = appearance18;
            this.WarehouseGuide01_Button.Location = new System.Drawing.Point(609, 215);
            this.WarehouseGuide01_Button.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.WarehouseGuide01_Button.Name = "WarehouseGuide01_Button";
            this.WarehouseGuide01_Button.Size = new System.Drawing.Size(24, 24);
            this.WarehouseGuide01_Button.TabIndex = 10;
            this.WarehouseGuide01_Button.Tag = "1";
            ultraToolTipInfo3.ToolTipText = "�q�ɃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.WarehouseGuide01_Button, ultraToolTipInfo3);
            this.WarehouseGuide01_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.WarehouseGuide01_Button.Click += new System.EventHandler(this.WarehouseGuide_Button_Click);
            // 
            // WarehouseGuide02_Button
            // 
            this.WarehouseGuide02_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            appearance23.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.WarehouseGuide02_Button.Appearance = appearance23;
            this.WarehouseGuide02_Button.Location = new System.Drawing.Point(609, 245);
            this.WarehouseGuide02_Button.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.WarehouseGuide02_Button.Name = "WarehouseGuide02_Button";
            this.WarehouseGuide02_Button.Size = new System.Drawing.Size(24, 24);
            this.WarehouseGuide02_Button.TabIndex = 13;
            this.WarehouseGuide02_Button.Tag = "1";
            ultraToolTipInfo2.ToolTipText = "�q�ɃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.WarehouseGuide02_Button, ultraToolTipInfo2);
            this.WarehouseGuide02_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.WarehouseGuide02_Button.Click += new System.EventHandler(this.WarehouseGuide_Button_Click);
            // 
            // WarehouseGuide03_Button
            // 
            this.WarehouseGuide03_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            appearance27.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.WarehouseGuide03_Button.Appearance = appearance27;
            this.WarehouseGuide03_Button.Location = new System.Drawing.Point(609, 275);
            this.WarehouseGuide03_Button.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.WarehouseGuide03_Button.Name = "WarehouseGuide03_Button";
            this.WarehouseGuide03_Button.Size = new System.Drawing.Size(24, 24);
            this.WarehouseGuide03_Button.TabIndex = 16;
            this.WarehouseGuide03_Button.Tag = "";
            ultraToolTipInfo1.ToolTipText = "�q�ɃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.WarehouseGuide03_Button, ultraToolTipInfo1);
            this.WarehouseGuide03_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.WarehouseGuide03_Button.Click += new System.EventHandler(this.WarehouseGuide_Button_Click);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.Renewal_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F);
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(565, 329);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 17;
            this.Renewal_Button.Text = "�ŐV���(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // SFKTN09000UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(947, 396);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.WarehouseGuide03_Button);
            this.Controls.Add(this.WarehouseGuide02_Button);
            this.Controls.Add(this.WarehouseGuide01_Button);
            this.Controls.Add(this.IntroductionDate_tDateEdit);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.edtSectionGuideSnm);
            this.Controls.Add(this.tEdit_WarehouseCode3);
            this.Controls.Add(this.tEdit_WarehouseCode2);
            this.Controls.Add(this.tEdit_WarehouseCode1);
            this.Controls.Add(this.SectWarehouseNm3_tEdit);
            this.Controls.Add(this.sectWarehouseNm3_Title_Label);
            this.Controls.Add(this.SectWarehouseNm2_tEdit);
            this.Controls.Add(this.SectWarehouseNm1_tEdit);
            this.Controls.Add(this.sectWarehouseNm2_Title_Label);
            this.Controls.Add(this.sectWarehouseNm1_Title_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.CompanyName1_tEdit);
            this.Controls.Add(this.CompanyNameCd1_tNedit);
            this.Controls.Add(this.tEdit_SectionCode);
            this.Controls.Add(this.edtSectionGuideNm);
            this.Controls.Add(this.CompanyName1_Title_Label);
            this.Controls.Add(this.ultraLabel20);
            this.Controls.Add(this.ultraLabel18);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.EmployeeCode_Title_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Delete_Button);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFKTN09000UA";
            this.Text = "���_�ݒ�";
            this.Load += new System.EventHandler(this.SFKTN09000UAC_Load);
            this.VisibleChanged += new System.EventHandler(this.SFKTN09000UAC_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFKTN09000UAC_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyNameCd1_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyName1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectWarehouseNm1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectWarehouseNm2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectWarehouseNm3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSectionGuideSnm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Events
		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		# region Private Menbers 
		private SecInfoSetAcs secInfoSetAcs;

		//��r�pclone
		private SecInfoSet _secInfoSetClone;
	
		private int totalCount;
		private string _enterpriseCode;
		private Hashtable secInfoSetTable;

		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
		private bool _canSpecificationSearch;

		// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
		// Grid��IndexBuffer�i�[�p�ϐ�
		private int _IndexBuffer;
		// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

        // ���_OP���f�p�t���O
        private bool _sectionFlg;
		// ���C���t���[���V�K�{�^���p�t���O
		private bool _canNewFlg;

        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

///////////////////////////////////////////////////////////////////// 2005.09.15 AKIYAMA ADD STA //
		// �R���g���[���i�[�p���X�g
		private ArrayList _companyNameCdCtrlList;
		private ArrayList _companyNameCtrlList;
// 2005.09.15 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

        // �� 2007.10.5 Keigo Yata add///////////////////////////////////////////////////////////////////////
        // �R���g���[���i�[�p���X�g
        private ArrayList _sectWarehouseCdCtrlList;
        private ArrayList _sectWarehouseNmCtrlList;
        // �� 2007.10.5 Keigo Yata add//////////////////////////////////////////////////////////////////////
        // --- ADD 2013/02/06 Y.Wakita ---------->>>>>
        private ArrayList _warehouseGuideCtrlList;
        // --- ADD 2013/02/06 Y.Wakita ----------<<<<<
        // --- ADD 2008/09/12 --------------------------------------------------------------------->>>>>
        private WarehouseAcs _warehouseAcs;
        // --- ADD 2008/09/12 ---------------------------------------------------------------------<<<<<

		// Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
		private const string DELETE_DATE	= "�폜��";
		private const string SECTIONCODE	= "���_�R�[�h";

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//		private const string SECTIONNAME	= "���_����";
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

		private const string SECTIONGUNM	= "���_�K�C�h����";

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//		private const string SECTIONPR		= "���_�o�q��";
//		private const string POSTNO			= "�X�֔ԍ�";
//		private const string ADDRESS		= "�Z��";
//		private const string TEL1			= "�d�b�ԍ��P";
//		private const string TEL2			= "�d�b�ԍ��Q";
//		private const string TEL3			= "�d�b�ԍ��R";
//		private const string TRANGUID		= "��s�U���ē���";
//		private const string TRANACNT1		= "��s�U�������P";
//		private const string TRANACNT2		= "��s�U�������Q";
//		private const string TRANACNT3		= "��s�U�������R";
//		private const string SECTIONNOTE1	= "�E�v�P";
//		private const string SECTIONNOTE2	= "�E�v�Q";
//		private const string SLIPNAMECD		= "�`�[���Ж�����敪";
//		private const string BILLSECNMCD	= "���������Ж�����敪";
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

        //private const string OTHSLIPNAMECD	= "�����_�`�[���Ж�����敪";  // DEL 2008/06/03
        // --- DEL 2009/01/20 ��QID:10152�Ή�------------------------------------------------------>>>>>
        //private const string MEINSECTIONCD	= "�{�Ћ@�\�敪";
        // --- DEL 2009/01/20 ��QID:10152�Ή�------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
        //private const string SECCDFORNUMBERING_TITLE	= "���_�R�[�h(�ԍ��̔ԗp)";  // DEL 2008/06/03
        //private const string COMPANYNAMECD1_TITLE = "���Ж��̃R�[�h�P";  // DEL 2008/06/03
        private const string COMPANYNAMECD1_TITLE = "���Ж��̃R�[�h";  // ADD 2008/06/03
//		private const string COMPANYNAME1_TITLE		= "���Ж��̂P";
        // 2006.12.13 DANJO ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
        private const string COMPANYNAME1_TITLE     = "���Ж���";
        // 2006.12.13 DANJO ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
        // 2006.12.13 DANJO DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
        //private const string COMPANYNAME1_TITLE   = "�����V�X�e������";
        // 2006.12.13 DANJO DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
		private const string COMPANYNAMECD2_TITLE	= "���Ж��̃R�[�h�Q";
//		private const string COMPANYNAME2_TITLE		= "���Ж��̂Q";
        // 2006.12.13 DANJO ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
        private const string COMPANYNAME2_TITLE     = "�\���Q";
        // 2006.12.13 DANJO ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
        // 2006.12.13 DANJO DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
        //private const string COMPANYNAME2_TITLE     = "����V�X�e������";
        // 2006.12.13 DANJO DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
		private const string COMPANYNAMECD3_TITLE	= "���Ж��̃R�[�h�R";
//		private const string COMPANYNAME3_TITLE		= "���Ж��̂R";
        // 2006.12.13 DANJO ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
        private const string COMPANYNAME3_TITLE     = "�\���R";
        // 2006.12.13 DANJO ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
        // 2006.12.13 DANJO DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
        //private const string COMPANYNAME3_TITLE     = "�Ԕ̃V�X�e������";
        // 2006.12.13 DANJO DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
		private const string COMPANYNAMECD4_TITLE	= "���Ж��̃R�[�h�S";
//		private const string COMPANYNAME4_TITLE		= "���Ж��̂S";
        // 2006.12.13 DANJO ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
        private const string COMPANYNAME4_TITLE     = "�\���S";
        // 2006.12.13 DANJO ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
        // 2006.12.13 DANJO DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
        //private const string COMPANYNAME4_TITLE     = "�������֘A����";
        // 2006.12.13 DANJO DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
		private const string COMPANYNAMECD5_TITLE	= "���Ж��̃R�[�h�T";
//		private const string COMPANYNAME5_TITLE		= "���Ж��̂T";
		private const string COMPANYNAME5_TITLE		= "�\���T";
		private const string COMPANYNAMECD6_TITLE	= "���Ж��̃R�[�h�U";
//		private const string COMPANYNAME6_TITLE		= "���Ж��̂U";
		private const string COMPANYNAME6_TITLE		= "�\���U";
		private const string COMPANYNAMECD7_TITLE	= "���Ж��̃R�[�h�V";
//		private const string COMPANYNAME7_TITLE		= "���Ж��̂V";
		private const string COMPANYNAME7_TITLE		= "�\���V";
		private const string COMPANYNAMECD8_TITLE	= "���Ж��̃R�[�h�W";
//		private const string COMPANYNAME8_TITLE		= "���Ж��̂W";
		private const string COMPANYNAME8_TITLE		= "�\���W";
		private const string COMPANYNAMECD9_TITLE	= "���Ж��̃R�[�h�X";
//		private const string COMPANYNAME9_TITLE		= "���Ж��̂X";
		private const string COMPANYNAME9_TITLE		= "�\���X";
		private const string COMPANYNAMECD10_TITLE	= "���Ж��̃R�[�h�P�O";
//		private const string COMPANYNAME10_TITLE	= "���Ж��̂P�O";
		private const string COMPANYNAME10_TITLE		= "�\���P�O";
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
        // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

        // �� 2007.10.5  Keigo Yata add///////////////////////////////////////////////////////////////////////
        private const string SECTWAREHOUSECD1_TITLE = "���_�q�ɃR�[�h�P";
        private const string SECTWAREHOUSENM1_TITLE = "���_�q�ɖ���";
        private const string SECTWAREHOUSECD2_TITLE = "���_�q�ɃR�[�h2";
        private const string SECTWAREHOUSENM2_TITLE = "���_�q�ɖ���2";
        private const string SECTWAREHOUSECD3_TITLE = "���_�q�ɃR�[�h3";
        private const string SECTWAREHOUSENM3_TITLE = "���_�q�ɖ���3";
        // �� 2007.10.5 Keigo Yata add//////////////////////////////////////////////////////////////////////

        // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
        private const string SECTIONGUIDESNM_TITLE = "���_����";
        private const string INTRODUCTIONDATE_TITLE = "�����N����";
        // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

		private const string SECINFOSET_TABLE = "SECINFOSET";
		private const string GUID_TITLE		= "GUID";
		
		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";
		private const string DELETE_MODE = "�폜���[�h";

		private bool _changeFlg = false;

		# endregion
		
		# region Main
		/// <summary>���C������</summary>
		/// <value></value>
		/// <remarks>�A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</remarks>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFKTN09000UA());
		}
		# endregion

		# region Properties
		/// <summary>�����/�s�v���p�e�B</summary>
		/// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanPrint
		{
			get{ return this._canPrint; }
		}

		/// <summary>�_���폜�f�[�^���o��/�s�v���p�e�B</summary>
		/// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get{ return this._canLogicalDeleteDataExtraction; }
		}

		/// <summary>��ʏI���ݒ�v���p�e�B</summary>
		/// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		/// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
		public bool CanClose
		{
			get{ return this._canClose; }
			set{ this._canClose = value; }
		}

		/// <summary>�V�K�o�^��/�s�v���p�e�B</summary>
		/// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanNew
		{
			get{ return this._canNew; }
		}

		/// <summary>�폜��/�s�v���p�e�B</summary>
		/// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanDelete
		{
			get{ return this._canDelete; }
		}

		/// <summary>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X�v���p�e�B</summary>
		/// <value>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</value>
		public int DataIndex
		{
			get{ return this._dataIndex; }
			set{ this._dataIndex = value; }
		}

		/// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
		/// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
		public bool DefaultAutoFillToColumn
		{
			get{ return this._defaultAutoFillToColumn; }
		}

		/// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
		/// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		public bool CanSpecificationSearch
		{					 
			get{ return this._canSpecificationSearch; }
		}
		# endregion
		
		# region Public Methods
		/// <summary>
		/// �o�C���h�f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
		/// <param name="tableName">�e�[�u������</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = SECINFOSET_TABLE;
		}

		/// <summary>
		/// �f�[�^��������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList secInfoSets = null;

			if (this.secInfoSetTable.Count == 0)
			{
				// ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
				status = this.secInfoSetAcs.SearchAll(
					out secInfoSets,
					this._enterpriseCode);
				
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.totalCount = secInfoSets.Count;

						// ���_���N���X���f�[�^�Z�b�g�֓W�J����
						int index = 0;
						foreach(SecInfoSet secInfoSet in secInfoSets)
						{
							if (this.secInfoSetTable.ContainsKey(secInfoSet.FileHeaderGuid) == false)
							{
								SecInfoSetToDataSet(secInfoSet.Clone(), index);
								++index;
							}
						}

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						break;
					}
					default:
					{
						///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
						// �T�[�`
						TMsgDisp.Show( 
							this, 								// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
							"SFKTN09000U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
							"���_���o�^�C��", 				// �v���O��������
							"Search", 							// ��������
							TMsgDisp.OPE_GET, 					// �I�y���[�V����
							"�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
							status, 							// �X�e�[�^�X�l
							this.secInfoSetAcs, 				// �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK, 				// �\������{�^��
							MessageBoxDefaultButton.Button1 );	// �����\���{�^��
						// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
						///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
						//					MessageBox.Show(
						//						"�ǂݍ��݂Ɏ��s���܂����B st = " + status.ToString(),
						//						"�G���[",
						//						MessageBoxButtons.OK,
						//						MessageBoxIcon.Error,
						//						MessageBoxDefaultButton.Button1);
						// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

						break;
					}
				}
			}
			else
			{
				this.totalCount = this.secInfoSetTable.Count;
				SortedList sortedList = new SortedList();

				foreach (SecInfoSet	secInfoSet in this.secInfoSetTable.Values)
				{
					sortedList.Add(secInfoSet.SectionCode.TrimEnd(), secInfoSet.Clone());
				}

				// ���_���N���X���f�[�^�Z�b�g�֓W�J����
				int index = 0;
				foreach(SecInfoSet secInfoSet in sortedList.Values)
				{
					SecInfoSetToDataSet(secInfoSet.Clone(), index);
					++index;
				}
			}

			// �߂�l�Z�b�g
			totalCount = this.totalCount;

			return status;
		}

		/// <summary>
		/// �l�N�X�g�f�[�^��������
		/// </summary>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
//
//			int dummy = 0;
//			ArrayList secInfoSets = null;
//
//			// ���o�Ώی�����0�̏ꍇ�́A�c��̑S���𒊏o
//			if (readCount == 0)
//			{
//				readCount =	this.totalCount - this.Bind_DataSet.Tables[0].Rows.Count;
//			}
//
//			// �����w�苒�_��񌟍������i�_���폜�����j
//			int status = this.secInfoSetAcs.SearchAll(
//							out secInfoSets,
//							out dummy,
//							out this.nextData, 
//							this._enterpriseCode,
//							readCount,
//							this.prevSecInfoSet);
//
//			switch (status)
//			{
//				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
//				{
//					// �ŏI�̋��_���N���X��ޔ�����
//					this.prevSecInfoSet = ((SecInfoSet)secInfoSets[secInfoSets.Count - 1]).Clone();
//
//					// ���_���N���X���f�[�^�Z�b�g�֓W�J����
//					int index = 0;
//					foreach(SecInfoSet secInfoSet in secInfoSets)
//					{
//						if (this.secInfoSetTable.ContainsKey(secInfoSet.FileHeaderGuid) == false)
//						{
//							SecInfoSetToDataSet(secInfoSet.Clone(), index);
//							++index;
//						}
//					}
//
//					break;
//				}
//				case (int)ConstantManagement.DB_Status.ctDB_EOF:
//				{
//					break;
//				}
//				default:
//				{
/////////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
//					// �T�[�`
//					TMsgDisp.Show( 
//						this, 								// �e�E�B���h�E�t�H�[��
//						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
//						"SFKTN09000U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
//						"���_���o�^�C��", 				// �v���O��������
//						"SearchNext", 						// ��������
//						TMsgDisp.OPE_GET, 					// �I�y���[�V����
//						"�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
//						status, 							// �X�e�[�^�X�l
//						this.secInfoSetAcs, 				// �G���[�����������I�u�W�F�N�g
//						MessageBoxButtons.OK, 				// �\������{�^��
//						MessageBoxDefaultButton.Button1 );	// �����\���{�^��
//// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
////					MessageBox.Show(
////						"�ǂݍ��݂Ɏ��s���܂����B st = " + status.ToString(),
////						"�G���[",
////						MessageBoxButtons.OK,
////						MessageBoxIcon.Error,
////						MessageBoxDefaultButton.Button1);
//// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
//
//					break;
//				}
//			}
//
//			return status;    
			return 0;
		}

		/// <summary>
		/// �f�[�^�폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		public int Delete()
		{

			// �ێ����Ă���f�[�^�Z�b�g���C���O���擾
			Guid guid = (Guid)this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[this.DataIndex][GUID_TITLE];
			SecInfoSet secInfoSet = (SecInfoSet)this.secInfoSetTable[guid];

			int status;
			
			// ���_���_���폜����
			status = this.secInfoSetAcs.LogicalDelete(ref secInfoSet);
			/////////////////////////////////////////////////////////////////2005 07.07 H.NAKAMURA DEL STA /////////
//			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//			{
//				MessageBox.Show(
//					"�폜�Ɏ��s���܂����B st = " + status.ToString(),
//					"�G���[",
//					MessageBoxButtons.OK,
//					MessageBoxIcon.Error,
//					MessageBoxDefaultButton.Button1);
//				return status;
//			}
			////////////////////2005 07.07 H.NAKAMURA DEL END //////////////////////////////////////////////////////

			/////////////////////////////////////////////////////////////////2005 07.07 H.NAKAMURA ADD STA /////////
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status);
					return status;
				}
				default:
				{
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
					// �_���폜
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
						"SFKTN09000U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���_���o�^�C��", 				// �v���O��������
						"Delete", 							// ��������
						TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
						"�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
						this.secInfoSetAcs, 				// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//					MessageBox.Show(
//						"�폜�Ɏ��s���܂����B st = " + status.ToString(),
//						"�G���[",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
					return status;
				}
			}
			////////////////////2005 07.07 H.NAKAMURA ADD END //////////////////////////////////////////////////////
			
			// ���_���N���X�f�[�^�Z�b�g�W�J����
			SecInfoSetToDataSet(secInfoSet.Clone(), this.DataIndex);

			return status;
		
		}
		
		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ������������s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		public int Print()
		{
			// ����p�A�Z���u�������[�h����i�������j
			return 0;
		}

		/// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
		/// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{

			Hashtable appearanceTable = new Hashtable();

			// �폜��
			appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));

			// ���_�R�[�h
			appearanceTable.Add(SECTIONCODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// ���_���̂P�{�Q
//			appearanceTable.Add(SECTIONNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//			
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			// ���_�K�C�h����
			appearanceTable.Add(SECTIONGUNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // ���_����
            appearanceTable.Add(SECTIONGUIDESNM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// ���_�o�q��
//			appearanceTable.Add(SECTIONPR, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// �X�֔ԍ�
//			appearanceTable.Add(POSTNO, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// �Z���P�{�Q�{�R
//			appearanceTable.Add(ADDRESS, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// �d�b�ԍ��P�^�C�g���{�ԍ�
//			appearanceTable.Add(TEL1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// �d�b�ԍ��Q�^�C�g���{�ԍ�
//			appearanceTable.Add(TEL2, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// �d�b�ԍ��R�^�C�g���{�ԍ�
//			appearanceTable.Add(TEL3, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// ��s�U���ē���
//			appearanceTable.Add(TRANGUID, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// ��s�U�������P
//			appearanceTable.Add(TRANACNT1, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// ��s�U�������Q
//			appearanceTable.Add(TRANACNT2, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// ��s�U�������R
//			appearanceTable.Add(TRANACNT3, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// �E�v�P
//			appearanceTable.Add(SECTIONNOTE1, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// �E�v�Q
//			appearanceTable.Add(SECTIONNOTE2, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
//			
//			// �`�[���Ж�����敪
//			appearanceTable.Add(SLIPNAMECD, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
			
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
			// ���_�R�[�h(�ԍ��̔ԗp)
///////////////////////////////////////////////////////////////////// 2005.11.02 AKIYAMA ADD STA //
            //appearanceTable.Add(SECCDFORNUMBERING_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));  // DEL 2008/06/03
// 2005.11.02 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.11.02 AKIYAMA DEL STA //
//			appearanceTable.Add(SECCDFORNUMBERING_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
// 2005.11.02 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // �����N����
            appearanceTable.Add(INTRODUCTIONDATE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

            // ���Ж��̃R�[�h
			appearanceTable.Add(COMPANYNAMECD1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#", Color.Black));
			// ���Ж���
			appearanceTable.Add(COMPANYNAME1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            // ���Ж��̃R�[�h�Q
            appearanceTable.Add(COMPANYNAMECD2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#", Color.Black));
            // ���Ж��̂Q
            appearanceTable.Add(COMPANYNAME2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���Ж��̃R�[�h�R
            appearanceTable.Add(COMPANYNAMECD3_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#", Color.Black));
            // ���Ж��̂R
            appearanceTable.Add(COMPANYNAME3_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���Ж��̃R�[�h�S
            appearanceTable.Add(COMPANYNAMECD4_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#", Color.Black));
            // ���Ж��̂S
            appearanceTable.Add(COMPANYNAME4_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���Ж��̃R�[�h�T
            appearanceTable.Add(COMPANYNAMECD5_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#", Color.Black));
            // ���Ж��̂T
            appearanceTable.Add(COMPANYNAME5_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���Ж��̃R�[�h�U
            appearanceTable.Add(COMPANYNAMECD6_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#", Color.Black));
            // ���Ж��̂U
            appearanceTable.Add(COMPANYNAME6_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���Ж��̃R�[�h�V
            appearanceTable.Add(COMPANYNAMECD7_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#", Color.Black));
            // ���Ж��̂V
            appearanceTable.Add(COMPANYNAME7_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���Ж��̃R�[�h�W
            appearanceTable.Add(COMPANYNAMECD8_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#", Color.Black));
            // ���Ж��̂W
            appearanceTable.Add(COMPANYNAME8_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���Ж��̃R�[�h�X
            appearanceTable.Add(COMPANYNAMECD9_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#", Color.Black));
            // ���Ж��̂X
            appearanceTable.Add(COMPANYNAME9_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���Ж��̃R�[�h�P�O
            appearanceTable.Add(COMPANYNAMECD10_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "#", Color.Black));
            // ���Ж��̂P�O
            appearanceTable.Add(COMPANYNAME10_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // �� 2007.10.5 Keigo Yata add/////////////////////////////////////////////////////////////////////           
            // ���_�q�ɃR�[�h1
            appearanceTable.Add(SECTWAREHOUSECD1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "#", Color.Black));
            // ���_�q�ɖ���1
            appearanceTable.Add(SECTWAREHOUSENM1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // ���_�q�ɃR�[�h2
            appearanceTable.Add(SECTWAREHOUSECD2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "#", Color.Black));
            // ���_�q�ɖ���2
            appearanceTable.Add(SECTWAREHOUSENM2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // ���_�q�ɃR�[�h3
            appearanceTable.Add(SECTWAREHOUSECD3_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "#", Color.Black));
            // ���_�q�ɖ���3
            appearanceTable.Add(SECTWAREHOUSENM3_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �� 2007.10.5 Keigo Yata add////////////////////////////////////////////////////////////////////

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            // �����_�`�[���Ж�����敪
            appearanceTable.Add(OTHSLIPNAMECD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            
            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// ���������Ж�����敪
//			appearanceTable.Add(BILLSECNMCD, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
			
            // �{�Ћ@�\�敪
            // --- DEL 2009/01/20 ��QID:10152�Ή�------------------------------------------------------>>>>>
            //appearanceTable.Add(MEINSECTIONCD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- DEL 2009/01/20 ��QID:10152�Ή�------------------------------------------------------<<<<<

            // GUID
            appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;

        }
        # endregion

        # region Private Methods
        /// <summary>
        /// ���_���N���X�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="secInfoSet">���_���N���X</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���_���N���X���f�[�^�Z�b�g�֊i�[���܂��B</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.03.18</br>
        /// </remarks>
        private void SecInfoSetToDataSet(SecInfoSet secInfoSet, int index)
        {

            if ((index < 0) || (this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[SECINFOSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows.Count - 1;

            }

            if (secInfoSet.LogicalDeleteCode == 0)
            {
                // �X�V�\��Ԃ̎�
                this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // �폜��Ԃ̎�
                this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][DELETE_DATE] = secInfoSet.UpdateDateTimeJpInFormal;
            }

            // ���_�R�[�h
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTIONCODE] = secInfoSet.SectionCode;
			
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			///////////////////////2005 08.08 H.NAKAMURA ADD STA ///////////////////////////////////////////////////////////////////
//			// ���_���̂P�{�Q�̊ԂɃX�y�[�X��}��
//			// ���_���̂P�{�Q
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTIONNAME] = secInfoSet.CompanyName1 + "�@" + secInfoSet.CompanyName2;
//			///////////////////////2005 08.08 H.NAKAMURA ADD STA ///////////////////////////////////////////////////////////////////
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            // ���_�K�C�h����
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTIONGUNM] = secInfoSet.SectionGuideNm;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// ���_�o�q��
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTIONPR] = secInfoSet.CompanyPr;
//
//			// �X�֔ԍ�
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][POSTNO] = secInfoSet.PostNo;
//
//			// �Z���P�{�Q�{�R�{�S
//			if (secInfoSet.Address2 == 0)
//			{
//				this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][ADDRESS] = secInfoSet.Address1 + secInfoSet.Address3 + " " + secInfoSet.Address4;
//			}
//			else
//			{
//				this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][ADDRESS] = secInfoSet.Address1 + secInfoSet.Address2 + "����" + secInfoSet.Address3 + " " + secInfoSet.Address4;
//			}
//
//			// �d�b�ԍ��P�^�C�g���{�ԍ�
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][TEL1] = secInfoSet.CompanyTelTitle1 + " " + secInfoSet.CompanyTelNo1;
//
//			// �d�b�ԍ��Q�^�C�g���{�ԍ�
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][TEL2] = secInfoSet.CompanyTelTitle2 + " " + secInfoSet.CompanyTelNo2;
//
//			// �d�b�ԍ��R�^�C�g���{�ԍ�
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][TEL3] = secInfoSet.CompanyTelTitle3 + " " + secInfoSet.CompanyTelNo3;
//
//			// ��s�U���ē���
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][TRANGUID] = secInfoSet.TransferGuidance;
//
//			// ��s�U�������P
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][TRANACNT1] = secInfoSet.AccountNoInfo1;
//
//			// ��s�U�������Q
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][TRANACNT2] = secInfoSet.AccountNoInfo2;
//
//			// ��s�U�������R
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][TRANACNT3] = secInfoSet.AccountNoInfo3;
//
//			// �E�v�P
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTIONNOTE1] = secInfoSet.CompanySetNote1;
//
//			// �E�v�Q
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTIONNOTE2] = secInfoSet.CompanySetNote2;
//
//			// �`�[���Ж�����敪
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SLIPNAMECD] = secInfoSet.SlipCompanyNmCd + " " + secInfoSet.SlipCompanyNm;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            // ���_�R�[�h(�ԍ��̔ԗp)
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECCDFORNUMBERING_TITLE] = secInfoSet.SecCdForNumbering;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

            // ���Ж��̃R�[�h
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAMECD1_TITLE] = secInfoSet.CompanyNameCd1.ToString("0000");
            // ���Ж���
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAME1_TITLE] = secInfoSet.CompanyName1;

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            // ���Ж��̃R�[�h�Q
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAMECD2_TITLE] = secInfoSet.CompanyNameCd2;
            // ���Ж��̂Q
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAME2_TITLE] = secInfoSet.CompanyName2;

            // ���Ж��̃R�[�h�R
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAMECD3_TITLE] = secInfoSet.CompanyNameCd3;
            // ���Ж��̂R
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAME3_TITLE] = secInfoSet.CompanyName3;

            // ���Ж��̃R�[�h�S
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAMECD4_TITLE] = secInfoSet.CompanyNameCd4;
            // ���Ж��̂S
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAME4_TITLE] = secInfoSet.CompanyName4;

            // ���Ж��̃R�[�h�T
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAMECD5_TITLE] = secInfoSet.CompanyNameCd5;
            // ���Ж��̂T
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAME5_TITLE] = secInfoSet.CompanyName5;

            // ���Ж��̃R�[�h�U
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAMECD6_TITLE] = secInfoSet.CompanyNameCd6;
            // ���Ж��̂U
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAME6_TITLE] = secInfoSet.CompanyName6;

            // ���Ж��̃R�[�h�V
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAMECD7_TITLE] = secInfoSet.CompanyNameCd7;
            // ���Ж��̂V
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAME7_TITLE] = secInfoSet.CompanyName7;

            // ���Ж��̃R�[�h�W
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAMECD8_TITLE] = secInfoSet.CompanyNameCd8;
            // ���Ж��̂W
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAME8_TITLE] = secInfoSet.CompanyName8;

            // ���Ж��̃R�[�h�X
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAMECD9_TITLE] = secInfoSet.CompanyNameCd9;
            // ���Ж��̂X
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAME9_TITLE] = secInfoSet.CompanyName9;

            // ���Ж��̃R�[�h�P�O
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAMECD10_TITLE] = secInfoSet.CompanyNameCd10;
            // ���Ж��̂P�O
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][COMPANYNAME10_TITLE] = secInfoSet.CompanyName10;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            
            // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // �� 2007.10.5 Keigo Yata add///////////////////////////////////////////////////////////////////

            //���_�q�ɃR�[�h1
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTWAREHOUSECD1_TITLE] = secInfoSet.SectWarehouseCd1;

            //���_�q�ɖ���1
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTWAREHOUSENM1_TITLE] = secInfoSet.SectWarehouseNm1;

            //���_�q�ɃR�[�h2
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTWAREHOUSECD2_TITLE] = secInfoSet.SectWarehouseCd2;

            //���_�q�ɖ���2
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTWAREHOUSENM2_TITLE] = secInfoSet.SectWarehouseNm2;

            //���_�q�ɃR�[�h3
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTWAREHOUSECD3_TITLE] = secInfoSet.SectWarehouseCd3;

            //���_�q�ɖ���3
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTWAREHOUSENM3_TITLE] = secInfoSet.SectWarehouseNm3;

            // �� 2007.10.5 Keigo Yata add//////////////////////////////////////////////////////////////////

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			// �����_�`�[���Ж�����敪
			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][OTHSLIPNAMECD] = secInfoSet.OthrSlipCompanyNm;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            
            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// ���������Ж�����敪
//			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][BILLSECNMCD] = secInfoSet.BillCompanyNmPrtCd + " " + secInfoSet.BillCompanyNmPrtNm;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			// �{�Ћ@�\�敪
            // --- DEL 2009/01/20 ��QID:10152�Ή�------------------------------------------------------>>>>>
            //this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][MEINSECTIONCD] = secInfoSet.MainOfficeFuncFlagName;
            // --- DEL 2009/01/20 ��QID:10152�Ή�------------------------------------------------------<<<<<

			// GUID
			this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][GUID_TITLE] = secInfoSet.FileHeaderGuid;

			if (this.secInfoSetTable.ContainsKey(secInfoSet.FileHeaderGuid) == true)
			{
				this.secInfoSetTable.Remove(secInfoSet.FileHeaderGuid);
			}
			this.secInfoSetTable.Add(secInfoSet.FileHeaderGuid, secInfoSet);

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // ���_����
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][SECTIONGUIDESNM_TITLE] = secInfoSet.SectionGuideSnm;
            
            // �����N����
            // --- CHG 2008/09/08 --------------------------------------------------------------------->>>>>
            //this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][INTRODUCTIONDATE_TITLE] = secInfoSet.IntroductionDate;
            this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[index][INTRODUCTIONDATE_TITLE] = secInfoSet.IntroductionDate.ToShortDateString();
            // --- CHG 2008/09/08 ---------------------------------------------------------------------<<<<<
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
		}

		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : DataSet�̗�����\�z���܂��B�f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable secInfoSetTable = new DataTable(SECINFOSET_TABLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			secInfoSetTable.Columns.Add(DELETE_DATE, typeof(string));			// �폜��
			secInfoSetTable.Columns.Add(SECTIONCODE, typeof(string));			// ���_�R�[�h

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			secInfoSetTable.Columns.Add(SECTIONNAME, typeof(string));			// ���_���̂P�{�Q
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			secInfoSetTable.Columns.Add(SECTIONGUNM, typeof(string));			// ���_�K�C�h����

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            secInfoSetTable.Columns.Add(SECTIONGUIDESNM_TITLE, typeof(string));     // ���_����
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

            //secInfoSetTable.Columns.Add(OTHSLIPNAMECD, typeof(string));			// �����_�`�[���Ж�����敪  // DEL 2008/06/03
            // --- DEL 2009/01/20 ��QID:10152�Ή�------------------------------------------------------>>>>>
            //secInfoSetTable.Columns.Add(MEINSECTIONCD, typeof(string));			// �{�Ћ@�\�敪
            // --- DEL 2009/01/20 ��QID:10152�Ή�------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			secInfoSetTable.Columns.Add(SECTIONPR, typeof(string));				// ���_�o�q��
//			secInfoSetTable.Columns.Add(POSTNO, typeof(string));				// �X�֔ԍ�
//			secInfoSetTable.Columns.Add(ADDRESS, typeof(string));				// �Z���P�{�Q�{�R
//			secInfoSetTable.Columns.Add(TEL1, typeof(string));					// �d�b�ԍ��P�^�C�g���{�ԍ�
//			secInfoSetTable.Columns.Add(TEL2, typeof(string));					// �d�b�ԍ��Q�^�C�g���{�ԍ�
//			secInfoSetTable.Columns.Add(TEL3, typeof(string));					// �d�b�ԍ��R�^�C�g���{�ԍ�
//			secInfoSetTable.Columns.Add(TRANGUID, typeof(string));				// ��s�U���ē���
//			secInfoSetTable.Columns.Add(TRANACNT1, typeof(string));				// ��s�U�������P
//			secInfoSetTable.Columns.Add(TRANACNT2, typeof(string));				// ��s�U�������Q
//			secInfoSetTable.Columns.Add(TRANACNT3, typeof(string));				// ��s�U�������R
//			secInfoSetTable.Columns.Add(SECTIONNOTE1, typeof(string));			// �E�v�P
//			secInfoSetTable.Columns.Add(SECTIONNOTE2, typeof(string));			// �E�v�Q
//			secInfoSetTable.Columns.Add(SLIPNAMECD, typeof(string));			// �`�[���Ж�����敪
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
            //secInfoSetTable.Columns.Add(SECCDFORNUMBERING_TITLE, typeof(string));	// ���_�R�[�h(�ԍ��̔ԗp)  // DEL 2008/06/03

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            secInfoSetTable.Columns.Add(INTRODUCTIONDATE_TITLE, typeof(string));    // �����N����
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

			secInfoSetTable.Columns.Add(COMPANYNAMECD1_TITLE, typeof(string));			// ���Ж��̃R�[�h
			secInfoSetTable.Columns.Add(COMPANYNAME1_TITLE, typeof(string));		// ���Ж���
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			secInfoSetTable.Columns.Add(COMPANYNAMECD2_TITLE, typeof(int));			// ���Ж��̃R�[�h�Q
			secInfoSetTable.Columns.Add(COMPANYNAME2_TITLE, typeof(string));		// ���Ж��̂Q
			secInfoSetTable.Columns.Add(COMPANYNAMECD3_TITLE, typeof(int));			// ���Ж��̃R�[�h�R
			secInfoSetTable.Columns.Add(COMPANYNAME3_TITLE, typeof(string));		// ���Ж��̂R
			secInfoSetTable.Columns.Add(COMPANYNAMECD4_TITLE, typeof(int));			// ���Ж��̃R�[�h�S
			secInfoSetTable.Columns.Add(COMPANYNAME4_TITLE, typeof(string));		// ���Ж��̂S
			secInfoSetTable.Columns.Add(COMPANYNAMECD5_TITLE, typeof(int));			// ���Ж��̃R�[�h�T
			secInfoSetTable.Columns.Add(COMPANYNAME5_TITLE, typeof(string));		// ���Ж��̂T
			secInfoSetTable.Columns.Add(COMPANYNAMECD6_TITLE, typeof(int));			// ���Ж��̃R�[�h�U
			secInfoSetTable.Columns.Add(COMPANYNAME6_TITLE, typeof(string));		// ���Ж��̂U
			secInfoSetTable.Columns.Add(COMPANYNAMECD7_TITLE, typeof(int));			// ���Ж��̃R�[�h�V
			secInfoSetTable.Columns.Add(COMPANYNAME7_TITLE, typeof(string));		// ���Ж��̂V
			secInfoSetTable.Columns.Add(COMPANYNAMECD8_TITLE, typeof(int));			// ���Ж��̃R�[�h�W
			secInfoSetTable.Columns.Add(COMPANYNAME8_TITLE, typeof(string));		// ���Ж��̂W
			secInfoSetTable.Columns.Add(COMPANYNAMECD9_TITLE, typeof(int));			// ���Ж��̃R�[�h�X
			secInfoSetTable.Columns.Add(COMPANYNAME9_TITLE, typeof(string));		// ���Ж��̂X
			secInfoSetTable.Columns.Add(COMPANYNAMECD10_TITLE, typeof(int));		// ���Ж��̃R�[�h�P�O
			secInfoSetTable.Columns.Add(COMPANYNAME10_TITLE, typeof(string));		// ���Ж��̂P�O
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // �� 2007.10.5 Keigo Yata add///////////////////////////////////////////////////////////////////
            secInfoSetTable.Columns.Add(SECTWAREHOUSECD1_TITLE, typeof(string));    // ���_�q�ɃR�[�h1
            secInfoSetTable.Columns.Add(SECTWAREHOUSENM1_TITLE, typeof(string));    // ���_�q�ɖ���1
            secInfoSetTable.Columns.Add(SECTWAREHOUSECD2_TITLE, typeof(string));    // ���_�q�ɃR�[�h2
            secInfoSetTable.Columns.Add(SECTWAREHOUSENM2_TITLE, typeof(string));    // ���_�q�ɖ���2
            secInfoSetTable.Columns.Add(SECTWAREHOUSECD3_TITLE, typeof(string));    // ���_�q�ɃR�[�h3
            secInfoSetTable.Columns.Add(SECTWAREHOUSENM3_TITLE, typeof(string));    // ���_�q�ɖ���3
            // �� 2007.10.5 Keigo Yata add///////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			secInfoSetTable.Columns.Add(BILLSECNMCD, typeof(string));			// ���������Ж�����敪
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			secInfoSetTable.Columns.Add(GUID_TITLE, typeof(Guid));
//			secInfoSetTable.Columns.Add(SECINFOSET_TABLE, typeof(SecInfoSet));

			this.Bind_DataSet.Tables.Add(secInfoSetTable);
		}

		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.cmbSlipCompanyNmCd.Items.Clear();
//			this.cmbSlipCompanyNmCd.Items.Add(0, "���_�ݒ�");									// �� �v�ύX
//			this.cmbSlipCompanyNmCd.Items.Add(1, "���Аݒ�");									// �� �v�ύX
//			this.cmbSlipCompanyNmCd.MaxDropDownItems = this.cmbSlipCompanyNmCd.Items.Count;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			this.cmbOthrSlipCompanyNmCd.Items.Clear();
			this.cmbOthrSlipCompanyNmCd.Items.Add(0, "�����_���");								// �� �v�ύX
			this.cmbOthrSlipCompanyNmCd.Items.Add(1, "�����_���");								// �� �v�ύX
			this.cmbOthrSlipCompanyNmCd.MaxDropDownItems = this.cmbOthrSlipCompanyNmCd.Items.Count;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/


///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.cmbBillCompanyNmPrtCd.Items.Clear();
//			this.cmbBillCompanyNmPrtCd.Items.Add(0, "�����_�ݒ�");								// �� �v�ύX
//			this.cmbBillCompanyNmPrtCd.Items.Add(1, "���Аݒ�");								// �� �v�ύX
//			this.cmbBillCompanyNmPrtCd.MaxDropDownItems = this.cmbBillCompanyNmPrtCd.Items.Count;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            // --- DEL 2009/01/20 ��QID:10152�Ή�------------------------------------------------------>>>>>
            //this.cmbMainOfficeFuncFlag.Items.Clear();
            //this.cmbMainOfficeFuncFlag.Items.Add(0, "���_");									// �� �v�ύX
            //this.cmbMainOfficeFuncFlag.Items.Add(1, "�{��");									// �� �v�ύX
            //this.cmbMainOfficeFuncFlag.MaxDropDownItems = this.cmbMainOfficeFuncFlag.Items.Count;
            // --- DEL 2009/01/20 ��QID:10152�Ή�------------------------------------------------------<<<<<

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			this.Ok_Button.Location = new System.Drawing.Point(690, 624);
			this.Cancel_Button.Location = new System.Drawing.Point(815, 624);
			this.Delete_Button.Location = new System.Drawing.Point(565, 624);
			this.Revive_Button.Location = new System.Drawing.Point(690, 624);
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            this.Ok_Button.Location = new System.Drawing.Point(690, 329);
            this.Cancel_Button.Location = new System.Drawing.Point(815, 329);
            this.Delete_Button.Location = new System.Drawing.Point(565, 329);
            this.Revive_Button.Location = new System.Drawing.Point(690, 329);
            this.Renewal_Button.Location = new System.Drawing.Point(565, 329);
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
        }

		/// <summary>
		/// ��ʏ���������
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏��������s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		private void ScreenClear()
		{

			this.tEdit_SectionCode.Text = "";

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.edtCompanyName1.Text = "";
//			this.edtCompanyName2.Text = "";
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			this.edtSectionGuideNm.Text = "";

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            this.edtSectionGuideSnm.Text = "";
            this.IntroductionDate_tDateEdit.Clear();
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.edtCompanyPr.Text = "";
//			this.edtPostNo.Text = "";
//			this.edtAddress1.Text = "";
//			this.nedtAddress2.Text = "";
//			this.edtAddress3.Text = "";
//			this.edtAddress4.Text = "";
//			this.edtCompanyTelTitle1.Text = "";
//			this.edtCompanyTelTitle2.Text = "";
//			this.edtCompanyTelTitle3.Text = "";
//			this.edtCompanyTelNo1.Text = "";
//			this.edtCompanyTelNo2.Text = "";
//			this.edtCompanyTelNo3.Text = "";
//			this.edtTransferGuidance.Text = "";
//			this.edtAccountNoInfo1.Text = "";
//			this.edtAccountNoInfo2.Text = "";
//			this.edtAccountNoInfo3.Text = "";
//			this.edtCompanySetNote1.Text = "";
//			this.edtCompanySetNote2.Text = "";
//			this.cmbSlipCompanyNmCd.SelectedIndex = 0;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            //this.cmbOthrSlipCompanyNmCd.SelectedIndex = 0;  // DEL 2008/06/03

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.cmbBillCompanyNmPrtCd.SelectedIndex = 0;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            // --- DEL 2009/01/20 ��QID:10152�Ή�------------------------------------------------------>>>>>
            //this.cmbMainOfficeFuncFlag.SelectedIndex = 0;
            // --- DEL 2009/01/20 ��QID:10152�Ή�------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
            //this.SecCdForNumbering_tEdit.Clear();  // DEL 2008/06/03

            //for( int ix = 0; ix < 10; ix++ ) {  // DEL 2008/06/03
			for( int ix = 0; ix < 1; ix++ ) {  // ADD 2008/06/03
				// ���Ж��̃R�[�h
				( ( TNedit )this._companyNameCdCtrlList[ ix ] ).Clear();
				// ���Ж���
				( ( TEdit )this._companyNameCtrlList[ ix ] ).Clear();
			}
// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // �� 2007.10.5 Keigo Yata add///////////////////////////////////////////////////////////////////
            for (int ix = 0; ix < 3; ix++)
            {
                // ���_�q�ɃR�[�h
                ((TEdit)this._sectWarehouseCdCtrlList[ix]).Clear();
                // ���_�q�ɖ���
                ((TEdit)this._sectWarehouseNmCtrlList[ix]).Clear();
            }
            // �� 2007.10.5 Keigo Yata add//////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.PostNoMark_tEdit.Appearance.BackColorDisabled = Color.FromName("White");
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
			// 2006.1.13 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			// �Q�ƃR�[�h�ύX�t���O
			this._changeFlg = false;
			// 2006.1.13 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
		
		}

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ̍č\�z���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		private void ScreenReconstruction()
		{

			if (this.DataIndex < 0)
			{
				SecInfoSet secinfoset = new SecInfoSet();
				//�N���[���쐬
				this._secInfoSetClone = secinfoset.Clone();
				// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				this._IndexBuffer = this._dataIndex;
				// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
				DispToSecInfoSet(ref this._secInfoSetClone);

				// �V�K���[�h
				this.Mode_Label.Text = INSERT_MODE;

				this.Ok_Button.Visible = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                this.Renewal_Button.Visible = true;

				this.tEdit_SectionCode.Enabled = true;
				this.tEdit_SectionCode.Focus();

				// ��ʓ��͋����䏈��
				ScreenInputPermissionControl(true);

			}
			else
			{
				// �ێ����Ă���f�[�^�Z�b�g���C���O���擾
				Guid guid = (Guid)this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[this.DataIndex][GUID_TITLE];
				SecInfoSet secInfoSet = (SecInfoSet)this.secInfoSetTable[guid];
				
				// ���_���N���X��ʓW�J����
				SecInfoSetToScreen(secInfoSet);

				if (secInfoSet.LogicalDeleteCode == 0)
				{
				// �X�V�\��Ԃ̎�
					this.Mode_Label.Text = UPDATE_MODE;

                    this.Ok_Button.Visible = true;
                    this.Renewal_Button.Visible = true;
					this.Cancel_Button.Visible = true;
					this.Delete_Button.Visible = false;
					this.Revive_Button.Visible = false;

					// ��ʓ��͋����䏈��
					ScreenInputPermissionControl(true);

					// �X�V���[�h�̏ꍇ�́A���_�R�[�h�̂ݓ��͕s�Ƃ��܂��B
					this.tEdit_SectionCode.Enabled = false;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
					this.edtSectionGuideNm.Focus();
					this.edtSectionGuideNm.SelectAll();
// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
////					this.ultraStatusBar1.Focus();			// 2005.06.17 TOUMA DEL �X�V���[�h�̏����t�H�[�J�X���ڂ�SelectAll�Ή�
//					this.edtCompanyName1.Focus();
//					this.edtCompanyName1.SelectAll();		// 2005.06.17 TOUMA ADD �X�V���[�h�̏����t�H�[�J�X���ڂ�SelectAll�Ή�
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

					//�N���[���쐬
					this._secInfoSetClone = secInfoSet.Clone();  
					//��ʏ����r�p�N���[���ɃR�s�[����@�@�@�@�@   
					DispToSecInfoSet(ref this._secInfoSetClone);

				}
				else
				{
				// �폜��Ԃ̎�
					this.Mode_Label.Text = DELETE_MODE;

                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
					this.Cancel_Button.Visible = true;
					this.Delete_Button.Visible = true;
					this.Revive_Button.Visible = true;

					// ��ʓ��͋����䏈��
					ScreenInputPermissionControl(false);

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//					this.PostNoMark_tEdit.Appearance.BackColorDisabled = Color.FromName("Control");
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

					this.Delete_Button.Focus();

				}
				// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				this._IndexBuffer = this._dataIndex;
				// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			}
		}

		/// <summary>
		/// ��ʓ��͋����䏈��
		/// </summary>
		/// <param name="enabled">���͋��ݒ�l</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		private void ScreenInputPermissionControl(bool enabled)
		{

			this.tEdit_SectionCode.Enabled = enabled;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.edtCompanyName1.Enabled = enabled;
//			this.edtCompanyName2.Enabled = enabled;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			this.edtSectionGuideNm.Enabled = enabled;

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            this.edtSectionGuideSnm.Enabled = enabled;
            this.IntroductionDate_tDateEdit.Enabled = enabled;
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.edtCompanyPr.Enabled = enabled;
//			this.edtPostNo.Enabled = enabled;
//			this.edtAddress1.Enabled = enabled;
//			this.nedtAddress2.Enabled = enabled;
//			this.edtAddress3.Enabled = enabled;
//			this.edtAddress4.Enabled = enabled;
//			this.edtCompanyTelTitle1.Enabled = enabled;
//			this.edtCompanyTelTitle2.Enabled = enabled;
//			this.edtCompanyTelTitle3.Enabled = enabled;
//			this.edtCompanyTelNo1.Enabled = enabled;
//			this.edtCompanyTelNo2.Enabled = enabled;
//			this.edtCompanyTelNo3.Enabled = enabled;
//			this.edtTransferGuidance.Enabled = enabled;
//			this.edtAccountNoInfo1.Enabled = enabled;
//			this.edtAccountNoInfo2.Enabled = enabled;
//			this.edtAccountNoInfo3.Enabled = enabled;
//			this.edtCompanySetNote1.Enabled = enabled;
//			this.edtCompanySetNote2.Enabled = enabled;
//			this.cmbSlipCompanyNmCd.Enabled = enabled;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            //this.cmbOthrSlipCompanyNmCd.Enabled = enabled;  // DEL 2008/06/03

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.cmbBillCompanyNmPrtCd.Enabled = enabled;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            // --- DEL 2009/01/20 ��QID:10152�Ή�------------------------------------------------------>>>>>
            //this.cmbMainOfficeFuncFlag.Enabled = enabled;
            // --- DEL 2009/01/20 ��QID:10152�Ή�------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
            //this.SecCdForNumbering_tEdit.Enabled = enabled;  // DEL 2008/06/03

            //for( int ix = 0; ix < 10; ix++ ) {  // DEL 2008/06/03
			for( int ix = 0; ix < 1; ix++ ) {  // ADD 2008/06/03
				// ���Ж��̃R�[�h
				( ( TNedit )this._companyNameCdCtrlList[ ix ] ).Enabled = enabled;
			}
// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // �� 2007.10.5 Keigo Yata add///////////////////////////////////////////////////////////////////

            for (int ix = 0; ix < 3; ix++)
            {
                // ���_�q�ɃR�[�h
                ((TEdit)this._sectWarehouseCdCtrlList[ix]).Enabled = enabled;
                // --- ADD 2013/02/06 Y.Wakita ---------->>>>>
                // ���_�q�ɃK�C�h�{�^��
                ((UltraButton)this._warehouseGuideCtrlList[ix]).Enabled = enabled;
                // --- ADD 2013/02/06 Y.Wakita ----------<<<<<
            }
            // �� 2007.10.5 Keigo Yatav add//////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.AddressCode_Guide_Button.Enabled = enabled;
//			this.PostNo_Label1.Enabled = enabled;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            // 2006.09.06 N.TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
            // ���_OP�������ꍇ��
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) <= 0)
            {
                //this.cmbOthrSlipCompanyNmCd.Enabled = false;  // DEL 2008/06/03
                // --- DEL 2009/01/20 ��QID:10152�Ή�------------------------------------------------------>>>>>
                //this.cmbMainOfficeFuncFlag.Enabled = false;
                // --- DEL 2009/01/20 ��QID:10152�Ή�------------------------------------------------------<<<<<
            }
            // 2006.09.06 N.TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end

		}

		/// <summary>
		/// ���_���N���X��ʓW�J����
		/// </summary>
		/// <param name="secInfoSet">���_���N���X</param>
		/// <remarks>
		/// <br>Note       : ���_���N���X��񂩂��ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		private void SecInfoSetToScreen(SecInfoSet secInfoSet)
		{
			
			// ���_�R�[�h
			this.tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim();

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// ���_����
//			this.edtCompanyName1.Text = secInfoSet.CompanyName1;
//			this.edtCompanyName2.Text = secInfoSet.CompanyName2;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
			
			// ���_�K�C�h����
			this.edtSectionGuideNm.Text = secInfoSet.SectionGuideNm.Trim();

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // ���_����
            this.edtSectionGuideSnm.Text = secInfoSet.SectionGuideSnm.Trim();

            // �����N����
            this.IntroductionDate_tDateEdit.SetDateTime(secInfoSet.IntroductionDate);
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
			
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// ���_�o�q��
//			this.edtCompanyPr.Text = secInfoSet.CompanyPr;
//			
//			// �X�֔ԍ�
//			this.edtPostNo.Text = secInfoSet.PostNo;
//			
//			// �Z��
//			this.edtAddress1.Text = secInfoSet.Address1;
//			this.nedtAddress2.SetInt(secInfoSet.Address2);
//			this.edtAddress3.Text = secInfoSet.Address3;
//			this.edtAddress4.Text = secInfoSet.Address4;
//			
//			// �d�b�ԍ��P
//			this.edtCompanyTelTitle1.Text = secInfoSet.CompanyTelTitle1;
//			this.edtCompanyTelNo1.Text = secInfoSet.CompanyTelNo1;
//			
//			// �d�b�ԍ��Q
//			this.edtCompanyTelTitle2.Text = secInfoSet.CompanyTelTitle2;
//			this.edtCompanyTelNo2.Text = secInfoSet.CompanyTelNo2;
//			
//			// �d�b�ԍ��R
//			this.edtCompanyTelTitle3.Text = secInfoSet.CompanyTelTitle3;
//			this.edtCompanyTelNo3.Text = secInfoSet.CompanyTelNo3;
//			
//			// ��s�U���ē���
//			this.edtTransferGuidance.Text = secInfoSet.TransferGuidance;
//
//			// ��s�U������
//			this.edtAccountNoInfo1.Text = secInfoSet.AccountNoInfo1;
//			this.edtAccountNoInfo2.Text = secInfoSet.AccountNoInfo2;
//			this.edtAccountNoInfo3.Text = secInfoSet.AccountNoInfo3;
//
//			// �E�v
//			this.edtCompanySetNote1.Text = secInfoSet.CompanySetNote1;
//			this.edtCompanySetNote2.Text = secInfoSet.CompanySetNote2;
//
//			// �`�[���Ж�����敪
//			this.cmbSlipCompanyNmCd.SelectedIndex = secInfoSet.SlipCompanyNmCd;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			// �����_�`�[���Ж�����敪
            //this.cmbOthrSlipCompanyNmCd.SelectedIndex = secInfoSet.OthrSlipCompanyNmCd;  // DEL 2008/06/03

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// ���������Ж�����敪
//			this.cmbBillCompanyNmPrtCd.SelectedIndex = secInfoSet.BillCompanyNmPrtCd;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			// �{�Ћ@�\�敪
            // --- DEL 2009/01/20 ��QID:10152�Ή�------------------------------------------------------>>>>>
            //this.cmbMainOfficeFuncFlag.SelectedIndex = secInfoSet.MainOfficeFuncFlag;
            // --- DEL 2009/01/20 ��QID:10152�Ή�------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			// ���_�R�[�h(�ԍ��̔ԗp)
			this.SecCdForNumbering_tEdit.DataText = secInfoSet.SecCdForNumbering;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

            //for( int ix = 0; ix < 10; ix++ ) {  // DEL 2008/06/03
            for (int ix = 0; ix < 1; ix++){  // ADD 2008/06/03
				// ���Ж��̃R�[�h
				TNedit companyNameCd_tNedit = this._companyNameCdCtrlList[ ix ] as TNedit;
				if( companyNameCd_tNedit != null ) {
					companyNameCd_tNedit.SetInt( secInfoSet.GetCompanyNameCd( ix ) );
				}
				// ���Ж���
				TEdit companyName_tEdit = this._companyNameCtrlList[ ix ] as TEdit;
				if( companyName_tEdit != null ) {
					companyName_tEdit.DataText = secInfoSet.GetCompanyName( ix ).Trim();
				}
			}
// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // �� 2007.10.5 Keigo Yata add///////////////////////////////////////////////////////////////////
            for (int ix = 0; ix < 3; ix++)
            {
                // ���_�q�ɃR�[�h
                TEdit sectWarehouseCd_tEdit = this._sectWarehouseCdCtrlList[ix] as TEdit;
                if (sectWarehouseCd_tEdit != null)
                {
                    sectWarehouseCd_tEdit.DataText = secInfoSet.GetSectWarehouseCd(ix).Trim();
                }
                // ���_�q�ɖ���
                TEdit sectWarehouseNm_tEdit = this._sectWarehouseNmCtrlList[ix] as TEdit;
                if (sectWarehouseNm_tEdit != null)
                {
                    sectWarehouseNm_tEdit.DataText = secInfoSet.GetSectWarehouseNm(ix).Trim();
                }
            }
            //�� 2007.10.5 Keigo Yata add/////////////////////////////////////////////////////////////////
		}

		/// <summary>
		/// ��ʏ�񋒓_���N���X�i�[����
		/// </summary>
		/// <param name="secInfoSet">���_���N���X</param>
		/// <remarks>
		/// <br>Note       : ��ʏ�񂩂狒�_���N���X�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		private void DispToSecInfoSet(ref SecInfoSet secInfoSet)
		{
			if (secInfoSet == null)
			{
				// �V�K�̏ꍇ
				secInfoSet = new SecInfoSet();
			}

			// ��ƃR�[�h
			secInfoSet.EnterpriseCode = this._enterpriseCode;			// �� �v�ύX

			// ���_�R�[�h
			secInfoSet.SectionCode = this.tEdit_SectionCode.Text;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// ���_����
//			secInfoSet.CompanyName1 = this.edtCompanyName1.Text;
//			secInfoSet.CompanyName2 = this.edtCompanyName2.Text;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
			
			// ���_�K�C�h����
			secInfoSet.SectionGuideNm = this.edtSectionGuideNm.Text;

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // ���_����
            secInfoSet.SectionGuideSnm = this.edtSectionGuideSnm.Text;

            // �����N����
            secInfoSet.IntroductionDate = this.IntroductionDate_tDateEdit.GetDateTime();
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
			
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// ���_�o�q��
//			secInfoSet.CompanyPr = this.edtCompanyPr.Text;
//			
//			// �X�֔ԍ�
//			secInfoSet.PostNo = this.edtPostNo.Text;
//			
//			// �Z��
//			secInfoSet.Address1 = this.edtAddress1.Text;
//			secInfoSet.Address2 = this.nedtAddress2.GetInt();
//			secInfoSet.Address3 = this.edtAddress3.Text;
//			secInfoSet.Address4 = this.edtAddress4.Text;
//			
//			// �d�b�ԍ��P
//			secInfoSet.CompanyTelTitle1 = this.edtCompanyTelTitle1.Text;
//			secInfoSet.CompanyTelNo1 = this.edtCompanyTelNo1.Text;
//			
//			// �d�b�ԍ��Q
//			secInfoSet.CompanyTelTitle2 = this.edtCompanyTelTitle2.Text;
//			secInfoSet.CompanyTelNo2 = this.edtCompanyTelNo2.Text;
//			
//			// �d�b�ԍ��R
//			secInfoSet.CompanyTelTitle3 = this.edtCompanyTelTitle3.Text;
//			secInfoSet.CompanyTelNo3 = this.edtCompanyTelNo3.Text;
//			
//			// ��s�U���ē���
//			secInfoSet.TransferGuidance = this.edtTransferGuidance.Text;
//
//			// ��s�U������
//			secInfoSet.AccountNoInfo1 = this.edtAccountNoInfo1.Text;
//			secInfoSet.AccountNoInfo2 = this.edtAccountNoInfo2.Text;
//			secInfoSet.AccountNoInfo3 = this.edtAccountNoInfo3.Text;
//
//			// �E�v
//			secInfoSet.CompanySetNote1 = this.edtCompanySetNote1.Text;
//			secInfoSet.CompanySetNote2 = this.edtCompanySetNote2.Text;
//
//			// �`�[���Ж�����敪
//			secInfoSet.SlipCompanyNmCd = this.cmbSlipCompanyNmCd.SelectedIndex;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			// �����_�`�[���Ж�����敪
            //secInfoSet.OthrSlipCompanyNmCd = this.cmbOthrSlipCompanyNmCd.SelectedIndex;  // DEL 2008/06/03

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			// ���������Ж�����敪
//			secInfoSet.BillCompanyNmPrtCd = this.cmbBillCompanyNmPrtCd.SelectedIndex;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			// �{�Ћ@�\�敪
            // --- CHG 2009/01/20 ��QID:10152�Ή�------------------------------------------------------>>>>>
            //secInfoSet.MainOfficeFuncFlag = this.cmbMainOfficeFuncFlag.SelectedIndex;
            secInfoSet.MainOfficeFuncFlag = 1;
            // --- CHG 2009/01/20 ��QID:10152�Ή�------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			// ���_�R�[�h(�ԍ��̔ԗp)
			secInfoSet.SecCdForNumbering = this.SecCdForNumbering_tEdit.DataText;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

            //for( int ix = 0; ix < 10; ix++ ) {  // DEL 2008/06/03
			for( int ix = 0; ix < 1; ix++ ) {  // ADD 2008/06/03
				// ���Ж��̃R�[�h
				TNedit companyNameCd_tNedit = this._companyNameCdCtrlList[ ix ] as TNedit;
				if( companyNameCd_tNedit != null ) {
					secInfoSet.SetCompanyNameCd( companyNameCd_tNedit.GetInt(), ix );
				}
				// ���Ж���
				TEdit companyName_tEdit = this._companyNameCtrlList[ ix ] as TEdit;
				if( companyName_tEdit != null ) {
					secInfoSet.SetCompanyName( companyName_tEdit.DataText, ix );
				}
			}
// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
            // �� 2007.10.5 Keigo Yata add///////////////////////////////////////////////////////////////////
            for (int ix = 0; ix < 3; ix++)
            {
                // ���_�q�ɃR�[�h
                TEdit sectWarehouseCd_tEdit = this._sectWarehouseCdCtrlList[ix] as TEdit;
                if (sectWarehouseCd_tEdit != null)
                {
                    if (sectWarehouseCd_tEdit.DataText.Trim() == "")
                    {
                        secInfoSet.SetSectWarehouseCd(sectWarehouseCd_tEdit.DataText, ix);
                    }
                    else
                    {
                        secInfoSet.SetSectWarehouseCd(sectWarehouseCd_tEdit.DataText.Trim().PadLeft(4, '0'), ix);
                    }
                }
                // ���_�q�ɖ���
                TEdit sectWarehouseNm_tEdit = this._sectWarehouseNmCtrlList[ix] as TEdit;
                if (sectWarehouseNm_tEdit != null)
                {
                    secInfoSet.SetSectWarehouseNm(sectWarehouseNm_tEdit.DataText, ix);
                }
            }
            // �� 2007.10.5 Keigo Yata add//////////////////////////////////////////////////////////////////
		}

		/// <summary>
		/// ��ʓ��͏��s���`�F�b�N����
		/// </summary>
		/// <param name="control">�s���ΏۃR���g���[��</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <returns>�`�F�b�N���� (true:OK/false:NG)</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		private bool ScreenDataCheck(ref Control control, ref string message)
		{
			bool result = true;

			if (this.tEdit_SectionCode.Text.Trim() == "")
			{
				control = this.tEdit_SectionCode;
				message = "���_�R�[�h����͂��ĉ������B";
				result = false;
			}
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			else if (this.edtCompanyName1.Text.Trim() == "")
//			{
//				control = this.edtCompanyName1;
//				message = "���_���̂���͂��ĉ������B";
//				result = false;
//			}
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
			else if (this.edtSectionGuideNm.Text.Trim() == "")
			{
				control = this.edtSectionGuideNm;
				message = "���_�K�C�h���̂���͂��ĉ������B";
				result = false;
			}
            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            else if (this.edtSectionGuideSnm.Text.Trim() == "")
            {
                control = this.edtSectionGuideSnm;
                message = "���_���̂���͂��ĉ������B";
                result = false;
            }
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
			else if( this.tEdit_SectionCode.Text.TrimEnd() == "000000" ) {
				control = this.tEdit_SectionCode;
				message = "���_�R�[�h�� 000000 �͎g�p�ł��܂���B";
				result = false;
			}
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			else if( this.SecCdForNumbering_tEdit.Text.Trim() == "" ) {
				control = this.SecCdForNumbering_tEdit;
				message = this.SecCdForNumbering_Title_Label.Text + "����͂��Ă��������B";
				result = false;
			}
			else if( this.SecCdForNumbering_tEdit.Text.Trim().Length != 2 ) {
				control = this.SecCdForNumbering_tEdit;
				message = this.SecCdForNumbering_Title_Label.Text + "�� 2 ���œ��͂��Ă��������B";
				result = false;
			}
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            else if (this.IntroductionDate_tDateEdit.GetDateTime() == DateTime.MinValue)
            {
                control = this.IntroductionDate_tDateEdit;
                message = "�����N��������͂��ĉ������B";
                result = false;
            }
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
            // 2006.09.26 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            else if (TStrConv.StrToIntDef(this.tEdit_SectionCode.Text.TrimEnd(),-1) == 0)
            {
                control = this.tEdit_SectionCode;
                message = "���_�R�[�h�� " + this.tEdit_SectionCode.Text.TrimEnd() + " �͎g�p�ł��܂���B";
                result = false;
            }
            // 2006.09.26 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            // 2006.12.13 DANJO ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            else if (this.CompanyNameCd1_tNedit.Text.Trim() == "")
            {
                control = this.CompanyNameCd1_tNedit;
                message = this.CompanyName1_Title_Label.Text + "����͂��Ă��������B";
                result = false;
            }
            // 2006.12.13 DANJO ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            else
            {
                string warehouseCode1 = this.tEdit_WarehouseCode1.DataText.Trim();
                string warehouseCode2 = this.tEdit_WarehouseCode2.DataText.Trim();
                string warehouseCode3 = this.tEdit_WarehouseCode3.DataText.Trim();

                if (warehouseCode1 != "")
                {
                    string warehouseName;
                    int status = this.secInfoSetAcs.GetWarehouseName(out warehouseName, this._enterpriseCode, "", warehouseCode1);
                    if (warehouseName == "")
                    {
                        control = this.tEdit_WarehouseCode1;
                        this.tEdit_WarehouseCode1.SelectAll();
                        this.SectWarehouseNm1_tEdit.Clear();
                        message = "�}�X�^�ɓo�^����Ă��܂���B";
                        return (false);
                    }
                }
                if (warehouseCode2 != "")
                {
                    string warehouseName;
                    int status = this.secInfoSetAcs.GetWarehouseName(out warehouseName, this._enterpriseCode, "", warehouseCode2);
                    if (warehouseName == "")
                    {
                        control = this.tEdit_WarehouseCode2;
                        this.tEdit_WarehouseCode2.SelectAll();
                        this.SectWarehouseNm2_tEdit.Clear();
                        message = "�}�X�^�ɓo�^����Ă��܂���B";
                        return (false);
                    }
                }
                if (warehouseCode3 != "")
                {
                    string warehouseName;
                    int status = this.secInfoSetAcs.GetWarehouseName(out warehouseName, this._enterpriseCode, "", warehouseCode3);
                    if (warehouseName == "")
                    {
                        control = this.tEdit_WarehouseCode3;
                        this.tEdit_WarehouseCode3.SelectAll();
                        this.SectWarehouseNm3_tEdit.Clear();
                        message = "�}�X�^�ɓo�^����Ă��܂���B";
                        return (false);
                    }
                }

                if (warehouseCode1 != "")
                {
                    if (warehouseCode2 != "")
                    {
                        this.tEdit_WarehouseCode2.DataText = warehouseCode2.PadLeft(4, '0');

                        if (warehouseCode1.PadLeft(4, '0') == warehouseCode2.PadLeft(4, '0'))
                        {
                            control = this.tEdit_WarehouseCode2;
                            message = "�q�ɃR�[�h���d�����Ă��܂��B";
                            result = false;
                        }
                    }

                    if (warehouseCode3 != "")
                    {
                        if (warehouseCode1.PadLeft(4, '0') == warehouseCode3.PadLeft(4, '0'))
                        {
                            control = this.tEdit_WarehouseCode3;
                            message = "�q�ɃR�[�h���d�����Ă��܂��B";
                            result = false;
                        }
                    }
                }

                if ((warehouseCode2 != "") && (warehouseCode3 != ""))
                {
                    if (warehouseCode2.PadLeft(4, '0') == warehouseCode3.PadLeft(4, '0'))
                    {
                        control = this.tEdit_WarehouseCode3;
                        message = "�q�ɃR�[�h���d�����Ă��܂��B";
                        result = false;
                    }
                }
            }
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
			return result;
		}

///////////////////////////////////////////////////////////////////// 2005.09.15 AKIYAMA ADD STA //
		/// <summary>
		/// ���Ж��̃R���g���[�����X�g�i�[����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ж��̃R�[�h�E���Ж��̂̃G�f�B�b�g�����X�g�Ɋi�[���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.15</br>
		/// </remarks>
		private void SetCompanyNameControlList()
		{
			// ���Ж��̃R�[�h�G�f�B�b�g
			this._companyNameCdCtrlList = new ArrayList();
			this._companyNameCdCtrlList.Add( this.CompanyNameCd1_tNedit );
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			this._companyNameCdCtrlList.Add( this.CompanyNameCd2_tNedit );
			this._companyNameCdCtrlList.Add( this.CompanyNameCd3_tNedit );
			this._companyNameCdCtrlList.Add( this.CompanyNameCd4_tNedit );
			this._companyNameCdCtrlList.Add( this.CompanyNameCd5_tNedit );
			this._companyNameCdCtrlList.Add( this.CompanyNameCd6_tNedit );
			this._companyNameCdCtrlList.Add( this.CompanyNameCd7_tNedit );
			this._companyNameCdCtrlList.Add( this.CompanyNameCd8_tNedit );
			this._companyNameCdCtrlList.Add( this.CompanyNameCd9_tNedit );
			this._companyNameCdCtrlList.Add( this.CompanyNameCd10_tNedit );
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

			this._companyNameCtrlList = new ArrayList();
			this._companyNameCtrlList.Add( this.CompanyName1_tEdit );
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			this._companyNameCtrlList.Add( this.CompanyName2_tEdit );
			this._companyNameCtrlList.Add( this.CompanyName3_tEdit );
			this._companyNameCtrlList.Add( this.CompanyName4_tEdit );
			this._companyNameCtrlList.Add( this.CompanyName5_tEdit );
			this._companyNameCtrlList.Add( this.CompanyName6_tEdit );
			this._companyNameCtrlList.Add( this.CompanyName7_tEdit );
			this._companyNameCtrlList.Add( this.CompanyName8_tEdit );
			this._companyNameCtrlList.Add( this.CompanyName9_tEdit );
			this._companyNameCtrlList.Add( this.CompanyName10_tEdit );
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
        }

		/// <summary>
		/// ���Ж��̏��ύX����
		/// </summary>
		/// <param name="companyNameCd_tNedit">���Ж��̃R�[�h�G�f�B�b�g</param>
		/// <param name="companyName_tEdit">���Ж��̃G�f�B�b�g</param>
		/// <param name="showMessage">���b�Z�[�W�̕\��(true:�\��, false:��\��)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �R�[�h���玩�Ж��̂��Q�Ƃ��܂��B����̂݃f�[�^���o�b�t�@�ɕۑ����܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.15</br>
		/// </remarks>
		private int CompanyNameCdChange( TNedit companyNameCd_tNedit, TEdit companyName_tEdit, bool showMessage )
		{
			int status = 0;
			CompanyNm companyNm = null;

			if( companyNameCd_tNedit.GetInt() == 0 ) {
				companyNameCd_tNedit.Clear();
				companyName_tEdit.Clear();
				return 0;
			}

			status = this.secInfoSetAcs.ReadCompanyNm( out companyNm, 
				this._enterpriseCode, companyNameCd_tNedit.GetInt() );
			switch( status ) 
			{
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( companyNm.LogicalDeleteCode == 0 ) {
						// �_���폜����Ă��Ȃ��ꍇ
						companyName_tEdit.DataText = companyNm.CompanyName1 + "�@" + companyNm.CompanyName2;
					}
					else {
						// �_���폜����Ă����ꍇ
                        companyName_tEdit.DataText = "�폜��";  // ADD 2008/06/03

						if( showMessage == true ) {
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
							// �R�[�h�Q�Ɓi�폜�ρj
							TMsgDisp.Show( 
								this, 								// �e�E�B���h�E�t�H�[��
								emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
								"SFKTN09000U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
								"�}�X�^����폜����Ă��܂��B", 	// �\�����郁�b�Z�[�W
								0, 									// �X�e�[�^�X�l
								MessageBoxButtons.OK );				// �\������{�^��
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//							MessageBox.Show( 
//								"�}�X�^����폜����Ă��܂��B", 
//								"���̓`�F�b�N", 
//								MessageBoxButtons.OK, 
//								MessageBoxIcon.Exclamation, 
//								MessageBoxDefaultButton.Button1 );
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
                            //companyName_tEdit.DataText = "�폜��";  // DEL 2008/06/03

							companyNameCd_tNedit.Focus();
							companyNameCd_tNedit.SelectAll();
                        }

						return -2;
					}
					break;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
                    companyName_tEdit.DataText = "���o�^";  // ADD 2008/06/03

					if( showMessage == true ) {
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
					// �R�[�h�Q�Ɓi���o�^�j
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
						"SFKTN09000U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"�}�X�^�ɓo�^����Ă��܂���B", 	// �\�����郁�b�Z�[�W
						0, 									// �X�e�[�^�X�l
						MessageBoxButtons.OK );				// �\������{�^��
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//						MessageBox.Show( 
//							"�}�X�^�ɓo�^����Ă��܂���B", 
//							"���̓`�F�b�N", 
//							MessageBoxButtons.OK, 
//							MessageBoxIcon.Exclamation, 
//							MessageBoxDefaultButton.Button1 );
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
                    //companyName_tEdit.DataText = "���o�^";  // DEL 2008/06/03

						companyNameCd_tNedit.Focus();
						companyNameCd_tNedit.SelectAll();
                    }

					break;
				}
				default:
				{
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
					// �T�[�`
					TMsgDisp.Show( 
						this, 									// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 			// �G���[���x��
						"SFKTN09000U", 							// �A�Z���u���h�c�܂��̓N���X�h�c
						"���_���o�^�C��", 					// �v���O��������
						"CompanyNameCdChange", 					// ��������
						TMsgDisp.OPE_GET, 						// �I�y���[�V����
						"���Ж��̂̓ǂݍ��݂Ɏ��s���܂����B", 	// �\�����郁�b�Z�[�W
						status, 								// �X�e�[�^�X�l
						this.secInfoSetAcs, 					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 					// �\������{�^��
						MessageBoxDefaultButton.Button1 );		// �����\���{�^��
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//					MessageBox.Show( 
//						"���Ж��̂̓ǂݍ��݂Ɏ��s���܂����B st = " + status.ToString(), 
//						"�G���[", 
//						MessageBoxButtons.OK, 
//						MessageBoxIcon.Error, 
//						MessageBoxDefaultButton.Button1 );
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
					companyNameCd_tNedit.Clear();
					companyName_tEdit.Clear();
					break;
				}
			}

			return status;
		}
// 2005.09.15 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

        // �� 2007.10.5 Keigo Yata add////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ���_�q�ɖ��̃R���g���[�����X�g�i�[����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_�q�ɃR�[�h�E���_�q�ɖ��̂̃G�f�B�b�g�����X�g�Ɋi�[���܂��B</br>
        /// <br>programer  : ��c �h��</br>
        /// <br>Date       : 2007.10.5</br>
        /// </remarks>
        private void SetSectWarehouseNmControlList()
        {
            // ���_�q�ɖ��̃R�[�h�G�f�B�b�g
            this._sectWarehouseCdCtrlList = new ArrayList();
            this._sectWarehouseCdCtrlList.Add(this.tEdit_WarehouseCode1);
            this._sectWarehouseCdCtrlList.Add(this.tEdit_WarehouseCode2);
            this._sectWarehouseCdCtrlList.Add(this.tEdit_WarehouseCode3);

            this._sectWarehouseNmCtrlList = new ArrayList();
            this._sectWarehouseNmCtrlList.Add(this.SectWarehouseNm1_tEdit);
            this._sectWarehouseNmCtrlList.Add(this.SectWarehouseNm2_tEdit);
            this._sectWarehouseNmCtrlList.Add(this.SectWarehouseNm3_tEdit);

            // --- ADD 2013/02/06 Y.Wakita ---------->>>>>
            this._warehouseGuideCtrlList = new ArrayList();
            this._warehouseGuideCtrlList.Add(this.WarehouseGuide01_Button);
            this._warehouseGuideCtrlList.Add(this.WarehouseGuide02_Button);
            this._warehouseGuideCtrlList.Add(this.WarehouseGuide03_Button);
            // --- ADD 2013/02/06 Y.Wakita ----------<<<<<

        }
        // �� 2007.10.5 Keigo Yata add////////////////////////////////////////////////////////////////////

        //�� 2007.10.5 Keigo Yata add////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ���_�q�ɖ��̏��ύX����
        /// </summary>
        /// <param name="sectWarehouseCd_tEdit">���_�q�ɃR�[�h�G�f�B�b�g</param>
        /// <param name="sectWarehouseNm_tEdit">���_�q�ɖ��̃G�f�B�b�g</param>
        /// <param name="showMessage">���b�Z�[�W�̕\��(true:�\��, false:��\��)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �R�[�h���狒�_�q�ɖ��̂��Q�Ƃ��܂��B����̂݃f�[�^���o�b�t�@�ɕۑ����܂��B</br>
        /// <br>Programer  : ��c �h��</br>
        /// <br>Date       : 2007.10.5</br>
        /// </remarks>
        private int SectWarehouseNmCdChange(TEdit sectWarehouseCd_tEdit, TEdit sectWarehouseNm_tEdit, bool showMessage)
        {
            int status = 0;

            string warehouseName = "";

            if (sectWarehouseCd_tEdit.Text == "")
            {
                sectWarehouseCd_tEdit.Clear();
                sectWarehouseNm_tEdit.Clear();
                return 0;
            }

            status = this.secInfoSetAcs.GetWarehouseName(out warehouseName, this._enterpriseCode, this.tEdit_SectionCode.Text, sectWarehouseCd_tEdit.DataText.Trim().PadLeft(4, '0'));

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if(warehouseName != "�폜��")
                        //if (warehouse.LogicalDeleteCode == 0)
                        {
                            // �_���폜����Ă��Ȃ��ꍇ
                            sectWarehouseNm_tEdit.DataText = warehouseName;
                        }

                        else
                        {
                            // �_���폜����Ă����ꍇ
                            if (showMessage == true)
                            {

                                // �R�[�h�Q�Ɓi�폜�ρj
                                TMsgDisp.Show(
                                    this, 								// �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                                    "SFKTN09000U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                                    "�}�X�^����폜����Ă��܂��B", 	// �\�����郁�b�Z�[�W
                                    0, 									// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);				// �\������{�^��
                                sectWarehouseNm_tEdit.DataText = "�폜��";
                                sectWarehouseCd_tEdit.Focus();
                                sectWarehouseCd_tEdit.SelectAll();
                            }

                            sectWarehouseNm_tEdit.DataText = "�폜��";
                            return -2;
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        if (showMessage == true)
                        {

                            // �R�[�h�Q�Ɓi���o�^�j
                            TMsgDisp.Show(
                                this, 								// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                                "SFKTN09000U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                                "�}�X�^�ɓo�^����Ă��܂���B", 	// �\�����郁�b�Z�[�W
                                0, 									// �X�e�[�^�X�l
                                MessageBoxButtons.OK);				// �\������{�^��

                            sectWarehouseNm_tEdit.DataText = "���o�^";
                            sectWarehouseCd_tEdit.Focus();
                            sectWarehouseCd_tEdit.SelectAll();
                        }

                        sectWarehouseNm_tEdit.DataText = "���o�^";
                        break;
                    }

                default:
                    {
                        // �T�[�`
                        TMsgDisp.Show(
                            this, 									  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 			  // �G���[���x��
                            "SFKTN09000U", 							  // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���_���o�^�C��", 					  // �v���O��������
                            "SectWarehouseNmCdChange", 			      // ��������
                            TMsgDisp.OPE_GET, 						  // �I�y���[�V����
                            "���_�q�ɖ��̂̓ǂݍ��݂Ɏ��s���܂����B", // �\�����郁�b�Z�[�W
                            status, 								  // �X�e�[�^�X�l
                            this.secInfoSetAcs, 					  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 					  // �\������{�^��
                            MessageBoxDefaultButton.Button1);		  // �����\���{�^��

                        sectWarehouseCd_tEdit.Clear();
                        sectWarehouseNm_tEdit.Clear();
                        break;
                    }
            }

            return status;
        }
        // �� 2007.10.5 Keigo Yata add////////////////////////////////////////////////////////////////////////////////

		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005.07.07 H.NAKAMURA Insert Start
		/// <summary>
		/// �r������
		/// </summary>
		/// <param name="status">STATUS</param>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2005.07.07</br>
		/// </remarks>
		private void ExclusiveTransaction(int status)
		{
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
					// ���[���X�V
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
						"SFKTN09000U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
						0, 									// �X�e�[�^�X�l
						MessageBoxButtons.OK );				// �\������{�^��
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//					MessageBox.Show(
//						"���ɑ��[�����X�V����Ă��܂�",
//						"����",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Exclamation,
//						MessageBoxDefaultButton.Button1);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
					this.Hide();
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
					// ���[���폜
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
						"SFKTN09000U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
						0, 									// �X�e�[�^�X�l
						MessageBoxButtons.OK );				// �\������{�^��
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//					MessageBox.Show(
//						"���ɑ��[�����폜����Ă��܂�",
//						"����",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Exclamation,
//						MessageBoxDefaultButton.Button1);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
					this.Hide();
					break;
				}
			}
		}
		//2005.07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//		/// <summary>
//		/// �X�֔ԍ��ύX����
//		/// </summary>
//		/// <remarks>
//		/// <br>Note		: �X�֔ԍ��ɂ��킹�ĕ\������Ă���Z���P�̕ύX���s���܂��B</br>
//		/// <br>Programmer	: 23010 �����@�m</br>
//		/// <br>Date		: 2005.08.22</br>
//		/// </remarks>
//		private void EpPostNoChange()
//		{																		
//			AddressGuide adg = new AddressGuide();
//			AddressGuideResult adgRet = new AddressGuideResult();
//			string postNo = this.edtPostNo.DataText;  
//
//			// �Z���}�X�^�Ǎ���
//			adg.SearchAddressFromPostNo(postNo, ref adgRet);
//
//			if ((adgRet.PostNo != "") &&
//				(adgRet.AddressName != ""))
//			{
//				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>20050905 Misaki Insert Start
//				this.edtPostNo.Text		= adgRet.PostNo;
//				//20050905 Misaki Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
//				this.edtAddress1.Text	= adgRet.AddressName;
//			}
//		}
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �R���g���[���T�C�Y�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���g���[���̃T�C�Y�ݒ菈�����s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/6/4</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tEdit_SectionCode.Size = new System.Drawing.Size(36, 24);
            this.edtSectionGuideNm.Size = new System.Drawing.Size(113, 24);
            this.edtSectionGuideSnm.Size = new System.Drawing.Size(175, 24);
            // --- DEL 2009/01/20 ��QID:10152�Ή�------------------------------------------------------>>>>>
            //this.cmbMainOfficeFuncFlag.Size = new System.Drawing.Size(170, 24);
            // --- DEL 2009/01/20 ��QID:10152�Ή�------------------------------------------------------<<<<<
            this.IntroductionDate_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.CompanyNameCd1_tNedit.Size = new System.Drawing.Size(43, 24);
            this.CompanyName1_tEdit.Size = new System.Drawing.Size(670, 24);
            this.tEdit_WarehouseCode1.Size = new System.Drawing.Size(59, 24);
            this.SectWarehouseNm1_tEdit.Size = new System.Drawing.Size(322, 24);
            this.tEdit_WarehouseCode2.Size = new System.Drawing.Size(59, 24);
            this.SectWarehouseNm2_tEdit.Size = new System.Drawing.Size(322, 24);
            this.tEdit_WarehouseCode3.Size = new System.Drawing.Size(59, 24);
            this.SectWarehouseNm3_tEdit.Size = new System.Drawing.Size(322, 24);
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

		# endregion

		# region Control Events
		/// <summary>
		/// ��ʃ��[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�f�[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.03.18</br>
		/// </remarks>
		private void SFKTN09000UAC_Load(object sender, System.EventArgs e)
		{
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList24 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList = imageList24;
			this.Cancel_Button.ImageList = imageList24;
			this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.AddressCode_Guide_Button.ImageList = imageList16;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            // --- ADD 2008/09/12 --------------------------------------------------------------------->>>>>
            this.WarehouseGuide01_Button.ImageList = imageList16;
            this.WarehouseGuide01_Button.Appearance.Image = Size16_Index.STAR1;
            this.WarehouseGuide02_Button.ImageList = imageList16;
            this.WarehouseGuide02_Button.Appearance.Image = Size16_Index.STAR1;
            this.WarehouseGuide03_Button.ImageList = imageList16;
            this.WarehouseGuide03_Button.Appearance.Image = Size16_Index.STAR1;
            // --- ADD 2008/09/12 ---------------------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			this.AddressCode_Guide_Button.Appearance.Image = Size16_Index.STAR1;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			// ��ʏ����ݒ菈��
			ScreenInitialSetting();

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // �R���g���[���T�C�Y�ݒ�
            SetControlSize();
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
		}

			/// <summary>
		/// ��ʃN���[�Y�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�f�[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[������悤�Ƃ������ɔ������܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.03.18</br>
		/// </remarks>
		private void SFKTN09000UAC_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			// Grid��IndexBuffer�i�[�p�ϐ��̏�����
			this._IndexBuffer = -2;
			// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			
			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
			// �t�H�[�����\��������B
			//�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}

		}

		/// <summary>
		/// ��ʕ\����ԕύX�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�f�[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ��ʂ̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.03.18</br>
		/// </remarks>
		private void SFKTN09000UAC_VisibleChanged(object sender, System.EventArgs e)
		{
			// �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
			if (this.Visible == false)
			{
				//2005.10.19 N.TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
				// ���C���t���[���A�N�e�B�u��
				this.Owner.Activate();
				//2005.10.19 N.TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
				return;
			}
			// ���_�I�v�V�����������̏ꍇ
            // 2006.08.26 N.TANIFUJI DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
            //else if ((LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) != PurchaseStatus.Contract) ||
            //    (LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) != PurchaseStatus.Trial_Contract))
            // 2006.08.26 N.TANIFUJI DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end

            // 2006.08.26 N.TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
            // 2006.08.26 N.TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
            {
                // ���_OP���f�p�t���O
                if ((!this._sectionFlg) &&
                    (!this._canNewFlg) &&
                    (this._dataIndex == -1))
                {
                    TMsgDisp.Show(
                        this, 																// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,									// �G���[���x��
                        "SFKTN09000U", 														// �A�Z���u���h�c�܂��̓N���X�h�c
                        "���_�I�v�V�������������̏ꍇ�͋��_�͂P�������o�^�o���܂���B",		// �\�����郁�b�Z�[�W
                        0, 																	// �X�e�[�^�X�l
                        MessageBoxButtons.OK);												// �\������{�^��

                    this._sectionFlg = true;
                    this.Hide();
                    return;
                }
                // ��ʋ���Hide���W�b�N
                else if ((this._dataIndex == -1) &&
                    (this._sectionFlg))
                {
                    this._sectionFlg = false;
                    this.Hide();
                    return;
                }
            }

			// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			if (this._IndexBuffer == this._dataIndex)
			{
				return;
			}
			// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			
			Initial_Timer.Enabled = true;
			
			// ��ʏ���������
			ScreenClear();

		}

		/// <summary>
		/// �ۑ��{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�f�[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.03.18</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			// �V�K����ʏI�����f�p���[�J���t���O
			bool secFlg = true;

			// �o�^�����̏W�� 2005.05.26 by yap
			if (SaveProc() == false)
			{
				return;
			}
			// end �o�^�����̏W�� 2005.05.26 by yap

			//���_�I�v�V�����L��
            // 2006.08.26 N.TANIFUJI DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
            //if ((LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) == PurchaseStatus.Contract) ||
            //    (LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) == PurchaseStatus.Trial_Contract))
            // 2006.08.26 N.TANIFUJI DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end

            // 2006.08.26 N.TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
            // 2006.08.26 N.TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
            {
                secFlg = true;
            }
            else
            {
                secFlg = false;
            }

			// �o�^���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
			if ((this.Mode_Label.Text == INSERT_MODE) &&
				(secFlg))
			{
				// �f�[�^�C���f�b�N�X������������
				this.DataIndex = -1;

				// ��ʏ���������
				ScreenClear();
				this.tEdit_SectionCode.Focus();
			}
			else
			{
				this.DialogResult = DialogResult.OK;

				// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
				// �t�H�[�����\��������B
				if (CanClose == true)
				{
					this.Close();
				}
				else
				{
					this.Hide();
				}

				// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				// Grid��IndexBuffer�i�[�p�ϐ��̏�����
				this._IndexBuffer = -2;
				// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			}

		}

		/// <summary>
		/// �o�^����
		/// </summary>
		/// <remarks>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.03.18</br>
		/// </remarks>
		private bool SaveProc()
		{
			bool result = false;
			Control control = null;
			string message = "";

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // ��ʓ��͏��s���`�F�b�N����
            if (!ScreenDataCheck(ref control, ref message))
            {
                ///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
                // ���̓`�F�b�N
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    "SFKTN09000U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message, 							// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��
                // 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
                //				MessageBox.Show(
                //					message,
                //					"���̓`�F�b�N",
                //					MessageBoxButtons.OK,
                //					MessageBoxIcon.Exclamation,
                //					MessageBoxDefaultButton.Button1);
                // 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
                control.Focus();
                return result;
            }
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.15 AKIYAMA ADD STA //
			// ���Ж��̃R�[�h�Q�ƃ`�F�b�N
            //for( int ix = 0; ix < 10; ix++ ) {  // DEL 2008/06/03
            for (int ix = 0; ix < 1; ix++)
            {  // ADD 2008/06/03
                TNedit companyNameCd_tNedit = this._companyNameCdCtrlList[ix] as TNedit;
                TEdit companyName_tEdit = this._companyNameCtrlList[ix] as TEdit;
                if ((companyNameCd_tNedit != null) &&
                    (companyName_tEdit != null))
                {
                    if (CompanyNameCdChange(companyNameCd_tNedit, companyName_tEdit, true) != 0)
                    {
                        return result;
                    }
                }
            }
// 2005.09.15 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            // ���_�q�ɃR�[�h�Q�ƃ`�F�b�N
            for (int ix = 0; ix < 3; ix++)
            {
                TEdit sectWarehouseCd_tEdit = this._sectWarehouseCdCtrlList[ix] as TEdit;
                TEdit sectWarehouseNm_tEdit = this._sectWarehouseNmCtrlList[ix] as TEdit;

                if ((sectWarehouseCd_tEdit != null) &&
                    (sectWarehouseNm_tEdit != null))
                {
                    if (SectWarehouseNmCdChange(sectWarehouseCd_tEdit, sectWarehouseNm_tEdit, true) != 0)
                    {
                        return result;
                    }
                }
            }
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

            // �� 2007.10.5 Keigo Yata add///////////////////////////////////////////////////////////////////
            // ���_�q�ɃR�[�h�̃R���g���[�����󔒂̏ꍇ�ɂ͋l�߂鏈��
            for (int ix = 0; ix < 3; ix++)
            {
                TEdit sectWarehouseCd_tEdit = this._sectWarehouseCdCtrlList[ix] as TEdit;
                TEdit sectWarehouseNm_tEdit = this._sectWarehouseNmCtrlList[ix] as TEdit;

                if (tEdit_WarehouseCode1.DataText == "")
                {
                    tEdit_WarehouseCode1.DataText = tEdit_WarehouseCode2.DataText;
                    tEdit_WarehouseCode2.DataText = tEdit_WarehouseCode3.DataText;
                    tEdit_WarehouseCode3.DataText = "";

                    // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
                    SectWarehouseNm1_tEdit.DataText = SectWarehouseNm2_tEdit.DataText;
                    SectWarehouseNm2_tEdit.DataText = SectWarehouseNm3_tEdit.DataText;
                    SectWarehouseNm3_tEdit.DataText = "";
                    // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
                }
                
                else if((tEdit_WarehouseCode1.DataText != "") &&
                    (tEdit_WarehouseCode2.DataText == ""))
                {
                    tEdit_WarehouseCode2.DataText = tEdit_WarehouseCode3.DataText;
                    tEdit_WarehouseCode3.DataText = "";

                    // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
                    SectWarehouseNm2_tEdit.DataText = SectWarehouseNm3_tEdit.DataText;
                    SectWarehouseNm3_tEdit.DataText = "";
                    // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
                }

                else if ((tEdit_WarehouseCode1.DataText == "") &&
                    (tEdit_WarehouseCode2.DataText == ""))
                {
                    tEdit_WarehouseCode1.DataText = tEdit_WarehouseCode3.DataText;
                    tEdit_WarehouseCode3.DataText = "";

                    // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
                    SectWarehouseNm1_tEdit.DataText = SectWarehouseNm3_tEdit.DataText;
                    SectWarehouseNm3_tEdit.DataText = "";
                    // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
                }

                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
                if ((sectWarehouseCd_tEdit != null) &&
                    (sectWarehouseNm_tEdit != null))
                {
                    if (SectWarehouseNmCdChange(sectWarehouseCd_tEdit, sectWarehouseNm_tEdit, true) != 0)
                    {
                        return result;
                    }
                }
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            }
            // �� 2007.10.5 Keigo Yata add///////////////////////////////////////////////////////////////////

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			// ��ʓ��͏��s���`�F�b�N����
			if (!ScreenDataCheck(ref control, ref message))
			{
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
				// ���̓`�F�b�N
				TMsgDisp.Show( 
					this, 								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
					"SFKTN09000U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
					message, 							// �\�����郁�b�Z�[�W
					0, 									// �X�e�[�^�X�l
					MessageBoxButtons.OK );				// �\������{�^��
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//				MessageBox.Show(
//					message,
//					"���̓`�F�b�N",
//					MessageBoxButtons.OK,
//					MessageBoxIcon.Exclamation,
//					MessageBoxDefaultButton.Button1);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
				control.Focus();
				return result;
			}
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            
            SecInfoSet secInfoSet = null;

			// �C���o�^�̎�
			if (DataIndex >= 0)
			{
				// �ێ����Ă���f�[�^�Z�b�g���C���O���擾
				Guid guid = (Guid)this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[this.DataIndex][GUID_TITLE];
			//	secInfoSet = (SecInfoSet)this.secInfoSetTable[guid];
				secInfoSet = ((SecInfoSet)this.secInfoSetTable[guid]).Clone();
			}

			// ��ʏ�񋒓_���N���X�i�[����
			DispToSecInfoSet(ref secInfoSet);

			// ���_���o�^�E�X�V����
			int status = this.secInfoSetAcs.Write(ref secInfoSet);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					// �ۑ����s��ꂽ�����_OP�����̏ꍇ����ȏ�̐V�K�͂��肦�Ȃ�
					//this._canNewFlg = false;
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
					// �R�[�h�d��
					TMsgDisp.Show( 
						this, 									// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_INFO, 			// �G���[���x��
						"SFKTN09000U", 							// �A�Z���u���h�c�܂��̓N���X�h�c
						"���̋��_�R�[�h�͊��Ɏg�p����Ă��܂��B", 	// �\�����郁�b�Z�[�W
						0, 										// �X�e�[�^�X�l
						MessageBoxButtons.OK );					// �\������{�^��
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//					MessageBox.Show(
//						"���̋��_�R�[�h�͊��Ɏg�p����Ă��܂��B",
//						"���",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Information,
//						MessageBoxDefaultButton.Button1);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

					this.tEdit_SectionCode.Focus();
					return result;
				}
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005.07.07 H.NAKAMURA Insert Start
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status);
					return result;
				}
				//2005.07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
				default:
				{
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
					// �o�^���s
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
						"SFKTN09000U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���_���o�^�C��", 				// �v���O��������
						"SaveProc", 						// ��������
						TMsgDisp.OPE_UPDATE, 				// �I�y���[�V����
						"�o�^�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
						this.secInfoSetAcs, 				// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//					MessageBox.Show(
//						"�o�^�Ɏ��s���܂����B st = " + status.ToString(),
//						"�G���[",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
					this.Hide();
                    this._IndexBuffer = -2;
					return result;
				}
			}

			// ���_���N���X�f�[�^�Z�b�g�W�J����
			SecInfoSetToDataSet(secInfoSet, this.DataIndex);

			// ��ʔ�\���C�x���g
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			result = true;
			return result;
		}

        private string GetCompanyName(int companyNameCd)
        {
            string companyName = "";

            if (companyNameCd == 0)
            {
                this.CompanyNameCd1_tNedit.Clear();
                this.CompanyName1_tEdit.Clear();
            }

            CompanyNm companyNm = new CompanyNm();
            int status = this.secInfoSetAcs.ReadCompanyNm(out companyNm, this._enterpriseCode, companyNameCd);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (companyNm.LogicalDeleteCode == 0)
                        {
                            // �_���폜����Ă��Ȃ��ꍇ
                            companyName = companyNm.CompanyName1 + "�@" + companyNm.CompanyName2;
                        }
                        else
                        {
                            companyName = "�폜��";
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        companyName = "���o�^";
                        break;
                    }
                default:
                    {
                        this.CompanyNameCd1_tNedit.Clear();
                        this.CompanyName1_tEdit.Clear();
                        break;
                    }
            }

            return companyName;
        }

		/// <summary>
		/// ����{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�f�[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.03.18</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
			if (this.Mode_Label.Text != DELETE_MODE) 
			{
				//�ۑ��m�F
				SecInfoSet compareSecInfoSet = new SecInfoSet();
				compareSecInfoSet = this._secInfoSetClone.Clone();
				// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				this._IndexBuffer = this._dataIndex;
				// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END


				//���݂̉�ʏ����擾����
				DispToSecInfoSet(ref compareSecInfoSet);
				//�ŏ��Ɏ擾������ʏ��Ɣ�r
				if (!(this._secInfoSetClone.Equals(compareSecInfoSet)))	
				{
					//��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
					// �ۑ��m�F
					DialogResult res = TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_SAVECONFIRM, // �G���[���x��
						"SFKTN09000U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						null, 								// �\�����郁�b�Z�[�W
						0, 									// �X�e�[�^�X�l
						MessageBoxButtons.YesNoCancel );	// �\������{�^��
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//					DialogResult res = MessageBox.Show(
//						"�ҏW���̃f�[�^�����݂��܂�"+"\r\n"+"\r\n"+"�o�^���Ă���낵���ł����H",
//						"�ۑ��m�F",
//						MessageBoxButtons.YesNoCancel,
//						MessageBoxIcon.Information);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
					switch(res)
					{
						case DialogResult.Yes:
						{

							// �o�^�����̏W�� 2005.05.26 by yap
							if (SaveProc() == false)
							{
								return;
							}
							// end �o�^�����̏W�� 2005.05.26 by yap

							break;
						}
						case DialogResult.No:
						{
							// ��ʔ�\���C�x���g
							if (UnDisplaying != null)
							{
								MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
								UnDisplaying(this, me);
							}
							break;
						}
						default:
						{
                            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                            //// 2005.09.02 TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
                            //this.Cancel_Button.Focus();
                            //// 2005.09.02 TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
                            if (_modeFlg)
                            {
                                tEdit_SectionCode.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
							return;
						}
					}
				}
			}

			// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			// Grid��IndexBuffer�i�[�p�ϐ��̏�����
			this._IndexBuffer = -2;
			// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			this.DialogResult = DialogResult.Cancel;

			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
			// �t�H�[�����\��������B
			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}

		}
		

		/// <summary>
		/// ���S�폜�{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�f�[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.03.18</br>
		/// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
		
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
			// ���S�폜�m�F
			DialogResult result = TMsgDisp.Show( 
				this, 								// �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
				"SFKTN09000U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
				"�f�[�^���폜���܂��B" + "\r\n" + 
				"��낵���ł����H", 				// �\�����郁�b�Z�[�W
				0, 									// �X�e�[�^�X�l
				MessageBoxButtons.OKCancel, 		// �\������{�^��
				MessageBoxDefaultButton.Button2 );	// �����\���{�^��
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//			DialogResult result = MessageBox.Show(
//				"�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",
//				"�폜�m�F",
//				MessageBoxButtons.OKCancel,
//				MessageBoxIcon.Exclamation,
//				MessageBoxDefaultButton.Button2);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			if (result == DialogResult.OK)
			{
				// �ێ����Ă���f�[�^�Z�b�g�����擾
				Guid guid = (Guid)this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[this.DataIndex][GUID_TITLE];
				SecInfoSet secInfoSet = (SecInfoSet)this.secInfoSetTable[guid];

				// ���_���_���폜����
				int status = this.secInfoSetAcs.Delete(secInfoSet);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[this.DataIndex].Delete();
						this.secInfoSetTable.Remove(secInfoSet.FileHeaderGuid);

						break;
					}
					//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005.07.07 H.NAKAMURA Insert Start
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						ExclusiveTransaction(status);
						return;
					}
					//2005.07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
					default:
					{
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
						// �����폜
						TMsgDisp.Show( 
							this, 								// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
							"SFKTN09000U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
							"���_���o�^�C��", 				// �v���O��������
							"Delete_Button_Click", 				// ��������
							TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
							"�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
							status, 							// �X�e�[�^�X�l
							this.secInfoSetAcs, 				// �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK, 				// �\������{�^��
							MessageBoxDefaultButton.Button1 );	// �����\���{�^��
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//						MessageBox.Show(
//							"�폜�Ɏ��s���܂����B st = " + status.ToString(),
//							"�G���[",
//							MessageBoxButtons.OK,
//							MessageBoxIcon.Error,
//							MessageBoxDefaultButton.Button1);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
						return;
					}
				}
			}
			else
			{
///////////////////////////////////////////////////////////////////// 2005.09.26 AKIYAMA ADD STA //
				this.Delete_Button.Focus();
// 2005.09.26 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
				return;
			}

			// ��ʔ�\���C�x���g
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			// Grid��IndexBuffer�i�[�p�ϐ��̏�����
			this._IndexBuffer = -2;
			// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
			// �t�H�[�����\��������B
			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}

		}

		/// <summary>
		/// �����{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�f�[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �����{�^���R���g���[�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.03.18</br>
		/// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
            DialogResult res = TMsgDisp.Show(this,
                                 emErrorLevel.ERR_LEVEL_QUESTION,
                                 "SFKTN09000U",
                                 "���ݕ\�����̋��_�}�X�^�𕜊����܂��B" + "\r\n" + "��낵���ł����H",
                                 0,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxDefaultButton.Button1);

            if (res != DialogResult.Yes)
            {
                return;
            }

			// �ێ����Ă���f�[�^�Z�b�g�����擾
			Guid guid = (Guid)this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[this.DataIndex][GUID_TITLE];
			SecInfoSet secInfoSet = (SecInfoSet)this.secInfoSetTable[guid];

			// ���_���o�^�E�X�V����
			int status = this.secInfoSetAcs.Revival(ref secInfoSet);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005.07.07 H.NAKAMURA Insert Start
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status);
					return;
				}
				//2005.07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005.07.07 H.NAKAMURA DEL Start
//				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
//				{
//					MessageBox.Show(
//						"���Ƀf�[�^�����S�폜����Ă��܂��B" + status.ToString(),
//						"���",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Information,
//						MessageBoxDefaultButton.Button1);
//
//					break;
//				}
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005.07.07 H.NAKAMURA DEL END		
				default:
				{
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA ADD STA //
					// �������s
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
						"SFKTN09000U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���_���o�^�C��", 				// �v���O��������
						"Revive_Button_Click", 				// ��������
						TMsgDisp.OPE_UPDATE, 				// �I�y���[�V����
						"�����Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
						this.secInfoSetAcs, 				// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��
// 2005.09.22 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.22 AKIYAMA DEL STA //
//					MessageBox.Show(
//						"�����Ɏ��s���܂����B st = " + status.ToString(),
//						"�G���[",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
// 2005.09.22 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

					break;
				}
			}

			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
			}

			// ���_���N���X�f�[�^�Z�b�g�W�J����
			SecInfoSetToDataSet(secInfoSet, this.DataIndex);

			// ��ʔ�\���C�x���g
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this._IndexBuffer = -2;
			// 2005.07.02 H.NAKAMURA ADD �t���[���̍ŏ����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
			// �t�H�[�����\��������B
			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}

		}

		/// <summary>
		/// Timer.Tick �C�x���g �C�x���g(Initial_Timer)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
		///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
		///					  �X���b�h�Ŏ��s����܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}
///////////////////////////////////////////////////////////////////// 2005.09.15 AKIYAMA ADD STA //
		/// <summary>
		/// Control.Enter�C�x���g(CompanyNameCd_tNedit)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �R���g���[�����t�H�[�J�X�𓾂��Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.15</br>
		/// </remarks>
		private void CompanyNameCd_tNedit_Enter(object sender, System.EventArgs e)
		{
			this._changeFlg = false;
		}

		/// <summary>
		///	Control.ValueChanged �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�[���</param>
		/// <remarks>
		/// <br>Note			: Control�̒l���ύX���ꂽ�ꍇ�ɔ������܂��B</br>
		/// <br>Programmer		: 22021  �J���@�͍K</br>
		/// <br>Date			: 2006.01.13</br>
		/// </remarks>
		private void Control_ValueChanged(object sender, System.EventArgs e)
		{
			TNedit tNEdit = (TNedit)sender;
			if (tNEdit.Modified)
			{
				_changeFlg = true;
			}
		}

		/// <summary>
		/// Control.Leave �C�x���g(CreditCompanyCode_tEdit)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �R���g���[�����t�H�[�J�X���������Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.15</br>
		/// </remarks>
		private void CompanyNameCd_tNedit_Leave(object sender, System.EventArgs e)
		{
			// ���Ж��̃R�[�h�G�f�B�b�g�擾
			TNedit companyNameCd_tNedit = sender as TNedit;
			if( companyNameCd_tNedit == null ) {
				return;
			}
			// ���Ж��̃G�f�B�b�g�擾
			int index = this._companyNameCdCtrlList.IndexOf( companyNameCd_tNedit );
			TEdit companyName_tEdit = this._companyNameCtrlList[ index ] as TEdit;
			if( companyName_tEdit == null ) {
				return;
			}

			if( companyNameCd_tNedit.GetInt() == 0 ) 
            {
				companyNameCd_tNedit.Clear();
				companyName_tEdit.Clear();
			}
			else 
            {
                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
				if( this._changeFlg == true ) {
					this._changeFlg = false;
					if( CompanyNameCdChange( companyNameCd_tNedit, companyName_tEdit, true ) != 0 ) {
						companyNameCd_tNedit.SelectAll();
					}
                    --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                this._changeFlg = false;
                //if (CompanyNameCdChange(companyNameCd_tNedit, companyName_tEdit, true) != 0)  // DEL 2008/06/03
                if (CompanyNameCdChange(companyNameCd_tNedit, companyName_tEdit, false) != 0)
                {
					companyNameCd_tNedit.SelectAll();
				}
			}
		}

// 2005.09.15 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

        
        /// <summary>
        /// ChanageFocus �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            this._changeFlg = false;

            if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            _modeFlg = false;
            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

            switch (e.PrevCtrl.Name)
            {
                case "tEdit_SectionCode":   // 2009.03.24 �V�K���[�h���烂�[�h�ύX�Ή�
                    {
                        // ���_�R�[�h
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // �J�ڐ悪����{�^��
                            _modeFlg = true;
                        }
                        else if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tEdit_SectionCode;
                            }
                        }
                        break;
                    }
                case "tEdit_WarehouseCode1":
                    {
                        TEdit tEdit = (TEdit)(e.PrevCtrl);

                        this._changeFlg = true;
                        
                        // ���_�q�ɃR�[�h�G�f�B�b�g�擾
                        TEdit sectWarehouseCd_tEdit = e.PrevCtrl as TEdit;
                        
                        if (sectWarehouseCd_tEdit == null)
                        {
                            return;
                        }
                        
                        // ���_�q�ɖ��̃G�f�B�b�g�擾
                        
                        int index = this._sectWarehouseCdCtrlList.IndexOf(sectWarehouseCd_tEdit);
                        
                        TEdit sectWarehouseNm_tEdit = this._sectWarehouseNmCtrlList[index] as TEdit;
                        
                        if (sectWarehouseNm_tEdit == null)
                        {
                            return;
                        }

                        if (sectWarehouseCd_tEdit.Text == "")
                        {
                            sectWarehouseCd_tEdit.Clear();
                            sectWarehouseNm_tEdit.Clear();

                            if (e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.WarehouseGuide01_Button;
                            }
                        }
                        else
                        {
                            if (this._changeFlg == true)
                            {
                                this._changeFlg = false;

                                //if (SectWarehouseNmCdChange(sectWarehouseCd_tEdit, sectWarehouseNm_tEdit, true) != 0)  // DEL 2008/06/03
                                if (SectWarehouseNmCdChange(sectWarehouseCd_tEdit, sectWarehouseNm_tEdit, false) != 0)
                                {
                                    sectWarehouseCd_tEdit.SelectAll();
                                }

                                if (e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.tEdit_WarehouseCode2;
                                }
                            }
                        }

                        break;
                    }


                case "tEdit_WarehouseCode2":
                    {
                        TEdit tEdit = (TEdit)(e.PrevCtrl);

                        this._changeFlg = true;

                        // ���_�q�ɃR�[�h�G�f�B�b�g�擾
                        TEdit sectWarehouseCd_tEdit = e.PrevCtrl as TEdit;

                        if (sectWarehouseCd_tEdit == null)
                        {
                            return;
                        }

                        // ���_�q�ɖ��̃G�f�B�b�g�擾

                        int index = this._sectWarehouseCdCtrlList.IndexOf(sectWarehouseCd_tEdit);

                        TEdit sectWarehouseNm_tEdit = this._sectWarehouseNmCtrlList[index] as TEdit;

                        if (sectWarehouseNm_tEdit == null)
                        {
                            return;
                        }

                        if (sectWarehouseCd_tEdit.Text == "")
                        {
                            sectWarehouseCd_tEdit.Clear();
                            sectWarehouseNm_tEdit.Clear();

                            if (e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.WarehouseGuide02_Button;
                            }
                        }
                        else
                        {
                            if (this._changeFlg == true)
                            {
                                this._changeFlg = false;

                                //if (SectWarehouseNmCdChange(sectWarehouseCd_tEdit, sectWarehouseNm_tEdit, true) != 0)  // DEL 2008/06/03
                                if (SectWarehouseNmCdChange(sectWarehouseCd_tEdit, sectWarehouseNm_tEdit, false) != 0)
                                {
                                    sectWarehouseCd_tEdit.SelectAll();
                                }

                                if (e.Key == Keys.Enter)
                                {
                                    e.NextCtrl = this.tEdit_WarehouseCode3;
                                }
                            }
                        }

                        break;
                    }

                case "tEdit_WarehouseCode3":
                    {
                        TEdit tEdit = (TEdit)(e.PrevCtrl);

                        this._changeFlg = true;

                        // ���_�q�ɃR�[�h�G�f�B�b�g�擾
                        TEdit sectWarehouseCd_tEdit = e.PrevCtrl as TEdit;

                        if (sectWarehouseCd_tEdit == null)
                        {
                            return;
                        }

                        // ���_�q�ɖ��̃G�f�B�b�g�擾

                        int index = this._sectWarehouseCdCtrlList.IndexOf(sectWarehouseCd_tEdit);

                        TEdit sectWarehouseNm_tEdit = this._sectWarehouseNmCtrlList[index] as TEdit;

                        if (sectWarehouseNm_tEdit == null)
                        {
                            return;
                        }

                        if (sectWarehouseCd_tEdit.Text == "")
                        {
                            sectWarehouseCd_tEdit.Clear();
                            sectWarehouseNm_tEdit.Clear();

                            if (e.Key == Keys.Enter)
                            {
                                e.NextCtrl = this.WarehouseGuide03_Button;
                            }
                        }
                        else
                        {
                            if (this._changeFlg == true)
                            {
                                this._changeFlg = false;

                                //if (SectWarehouseNmCdChange(sectWarehouseCd_tEdit, sectWarehouseNm_tEdit, true) != 0)  // DEL 2008/06/03
                                if (SectWarehouseNmCdChange(sectWarehouseCd_tEdit, sectWarehouseNm_tEdit, false) != 0)
                                {
                                    sectWarehouseCd_tEdit.SelectAll();
                                }

                                if (e.Key == Keys.Enter)
                                {
                                    //e.NextCtrl = this.Ok_Button;
                                    e.NextCtrl = this.Renewal_Button;
                                }
                            }
                        }

                        break;
                    }

            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �q�ɃK�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/12</br>
        /// </remarks>
        private void WarehouseGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UltraButton uButton = (UltraButton)sender;

                Warehouse warehouse;

                int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode);
                if (status == 0)
                {
                    if (uButton.Name == "WarehouseGuide01_Button")
                    {
                        this.tEdit_WarehouseCode1.DataText = warehouse.WarehouseCode.Trim();
                        this.SectWarehouseNm1_tEdit.DataText = warehouse.WarehouseName.Trim();

                        this.tEdit_WarehouseCode2.Focus();  // ADD 2008/10/09 �s��Ή�[6353]
                    }
                    else if (uButton.Name == "WarehouseGuide02_Button")
                    {
                        this.tEdit_WarehouseCode2.DataText = warehouse.WarehouseCode.Trim();
                        this.SectWarehouseNm2_tEdit.DataText = warehouse.WarehouseName.Trim();

                        this.tEdit_WarehouseCode3.Focus();  // ADD 2008/10/09 �s��Ή�[6353]
                    }
                    else if (uButton.Name == "WarehouseGuide03_Button")
                    {
                        this.tEdit_WarehouseCode3.DataText = warehouse.WarehouseCode.Trim();
                        this.SectWarehouseNm3_tEdit.DataText = warehouse.WarehouseName.Trim();

                        //this.Ok_Button.Focus();  // ADD 2008/10/09 �s��Ή�[6353]
                        this.Renewal_Button.Focus();  // ADD 2008/10/09 �s��Ή�[6353]
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // --- ADD 2009/03/18 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this.secInfoSetAcs = new SecInfoSetAcs();

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          "SFKTN09000U",						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }
        // --- ADD 2009/03/18 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // ���_�R�[�h
            string sectionCd = tEdit_SectionCode.Text.TrimEnd();

            for (int i = 0; i < this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsSecCd = (string)this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[i][SECTIONCODE];
                if (sectionCd.Equals(dsSecCd.TrimEnd()))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[SECINFOSET_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          "SFKTN09000U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̋��_�ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ���_�R�[�h�̃N���A
                        tEdit_SectionCode.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        "SFKTN09000U",                          // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̋��_�ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // ���_�R�[�h�̃N���A
                                tEdit_SectionCode.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
        
        // �� 2008.03.07 Keigo Yata add///////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//		/// <summary>
//		/// Control.Click Event(PrtBitmapGuid_Button, CursorBitmapGuid_Button)
//		/// </summary>
//		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
//		/// <param name="e">�C�x���g�p�����[�^</param>
//		/// <remarks>
//		/// <br>Note       : �t�@�C���K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ���</br>
//		/// <br>Programmer : 20089 �{���@���a</br>
//		/// <br>Date       : 2005.04.28</br>
//		/// </remarks>
//		private void AddressCode_Guide_Button_Click(object sender, System.EventArgs e)
//		{
//			AddressGuide adg = new AddressGuide();
//			string EnterpriseCode = this._enterpriseCode;
//			AddressGuideResult adgRet = new AddressGuideResult();
//			adg.SearchAddress(EnterpriseCode, ref adgRet);
//
//			if (adgRet.AddressName != "")
//			{
//				this.edtAddress1.Text = adgRet.AddressName;
//				this.edtPostNo.Text = adgRet.PostNo;	
//			}
//		}
//
//		/// <summary>
//		///	Control.Leave �C�x���g
//		/// </summary>
//		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
//		/// <param name="e">�L�[���</param>
//		/// <remarks>
//		/// <br>Note			:	Control���t�H�[���̃A�N�e�B�u�R���g���[���ł͂Ȃ��Ȃ����ۂɔ������܂��B</br>
//		/// <br>Programmer		:	22033 �O��  �M�j</br>
//		/// <br>Date			:	2005.08.22</br>
//		/// </remarks>
//		private void edtPostNo_Leave(object sender, System.EventArgs e)
//		{
//			// �X�֔ԍ��ύX����
//			if(this._changeFlg == true)
//			{
//				EpPostNoChange();
//			}
//		}
//
//		private void edtPostNo_Enter(object sender, System.EventArgs e)
//		{
//			this._changeFlg = false;
//		}
//
//		/// <summary>
//		///	Control.KeyDown �C�x���g(tNedit1)
//		/// </summary>
//		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
//		/// <param name="e">�L�[���</param>
//		/// <remarks>
//		/// <br>Note			: Control��ŃL�[�����������ۂɔ������܂��B</br>
//		/// <br>Programmer		: 22033 �O��  �M�j</br>
//		/// <br>Date			: 2005.06.03</br>
//		/// </remarks>
//		private void edtPostNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
//		{
////			if (((48 <= e.KeyValue) && (e.KeyValue <=  57)) ||	// 0�`9�L�[
////				((96 <= e.KeyValue) && (e.KeyValue <= 105)))	// 0�`9�L�[(�e���L�[)
//
//			if ((e.ToString() != "") &&
//				(e.KeyValue != 37) &&	  // �u���v�L�[
//				(e.KeyValue != 39))		  // �u���v�L�[
//			{
//				_changeFlg = true;		
//			}					
//		}
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
		# endregion
	}
}
