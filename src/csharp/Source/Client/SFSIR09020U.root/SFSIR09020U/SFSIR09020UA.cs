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
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �x���ݒ���̓t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �x���ݒ���s���܂��B
	///                  IMasterMaintenanceMultiType���������Ă��܂��B</br>
	/// <br>Programmer : 21027 �{��  ���u�Y</br>
	/// <br>Date       : 2005.04.12</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.13 22024 ����@�_�u</br>
	/// <br>           : �@�@����{�^���ɂā��L�[�������̐����ǉ��i�R���|�[�l���g�o�O�΍�j</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.20 22024 ����@�_�u</br>
	/// <br>           : �@�@�R�[�h�Q�Ƌ@�\�ꎞ�Ή��C��</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.21 22024 ����@�_�u</br>
	/// <br>           : �@�@CatchMouse�ATNedit(ZeroSupp�AImeMode)�AHotTracking</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.27 22024 ����@�_�u</br>
	/// <br>           : �@�@����{�^����Ł��L�[�⁨�L�[���͎��Ƀt�H�[�J�X�J�ڂ��Ȃ��悤�ɏC��</br>
	/// <br></br>
	/// <br>Update Note: 2005.07.05 23013 �q�@���l</br>
	/// <br>           : �@�t���[���̍ŏI�ŏ����Ή�</br>
	/// <br>           :   ArrowKeyControl��CatchMouse�v���p�e�B��True�ɐݒ�</br>
	/// <br></br>
	/// <br>Update Note: 2005.07.06 23013 �q ���l</br>
	/// <br>           :   �r�����䏈���@�r�������������Ƃ��Astatus��\�����Ȃ��悤�C��</br>
	/// <br></br>
	/// <br>Update Note: 2005.07.08 23013 �q ���l</br>
	/// <br>           :   �G���[���o����MessageBox��OK�{�^���������������AUI��ʂ���鏈��</br>
	/// <br></br>
	/// <br>Update Note: 2005.07.12 23013 �q ���l</br>
	/// <br>           :   �r�����䏈���̒��ɍŏ����Ή�������ǉ�</br>
	/// <br></br>
	/// <br>Update Note: 2005.09.03 23006 ���� ���q</br>
	/// <br>			   ����{�^���ւ̃t�H�[�J�X�Z�b�g����</br>
	/// <br></br>
	/// <br>Update Note: 2005.09.08  23006 ���� ���q</br>
	/// <br>			   ��ƃR�[�h�擾����</br>
	/// <br></br>
	/// <br>Update Note: 2005.09.24  23006 ���� ���q</br>
	/// <br>			   ����R�[�h�Q�ƑΉ��A���̓`�F�b�N�C��</br>
	/// <br></br>
	/// <br>Update Note: 2005.09.24  23006 ���� ���q</br>
	/// <br>			   TMsgDisp���i�Ή�</br>
	/// <br></br>
	/// <br>Update Note: 2005.10.07  23006 ���� ���q</br>
	/// <br>			   �K�C�h�{�^�������Ή�</br>
	/// <br></br>
	/// <br>Update Note: 2005.10.18  23006 ���� ���q</br>
	/// <br>			   �K�C�h�{�^���t�H�[�J�X����Ή�</br>
	/// <br></br>
	/// <br>Update Note : 2005.10.19  23006 ���� ���q</br>
	/// <br>			    UI�q���Hide����Owner.Activate�����ǉ�</br>
	/// <br></br>
	/// <br>Update Note : 2005.12.20  23006 ���� ���q</br>
	/// <br>			    �e�}�X�^���f�����Ή�</br>
	/// <br></br>
	/// <br>Update Note : 2006.01.13  23006 ���� ���q</br>
	/// <br>                �R�[�h�Q�ƍ��ڂ̓��͕ύX�t���O�𗧂Ă�Ƃ��̏����C��</br>
    /// <br></br>
    /// <br>Update Note : 2006.06.09  22029 ���R �b��</br>
    /// <br>                �x���ݒ�}�X�^�@�V���C�A�E�g�Ή�</br>
    /// <br></br>
    /// <br>Update Note :  2007.05.27 30005 �،� ��</br>
    /// <br>                ���z��ʖ��̎擾�̏C��</br>
    /// <br></br>
    /// <br>Update Note : 2008.06.18  ���i �r��</br>
    /// <br>	�@      �E���ځu�x���`�[�ďo�����v�폜�A�������W�b�N�ԈႢFIX�A9/10�Ԗڂ̃t�B�[���h�폜��</br>
    /// <br></br>
    /// </remarks>
	public class SFSIR09020UA : System.Windows.Forms.Form, IMasterMaintenanceSingleType
	{
		# region Private Members (Component)
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Broadleaf.Library.Windows.Forms.THtmlGenerate tHtmlGenerate1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Broadleaf.Library.Windows.Forms.TEdit PayStMoneyKindCd1RF_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PayStMoneyKindCd2RF_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PayStMoneyKindCd3RF_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PayStMoneyKindCd4RF_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PayStMoneyKindCd5RF_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PayStMoneyKindCd6RF_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PayStMoneyKindCd7RF_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PayStMoneyKindCd8RF_tEdit;
		private Broadleaf.Library.Windows.Forms.TNedit PayStMoneyKindCd1RF_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit PayStMoneyKindCd2RF_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit PayStMoneyKindCd3RF_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit PayStMoneyKindCd4RF_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit PayStMoneyKindCd5RF_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit PayStMoneyKindCd6RF_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit PayStMoneyKindCd7RF_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit PayStMoneyKindCd8RF_tNedit;
		private Infragistics.Win.Misc.UltraLabel PayStMoneyKindCdRF_Label;
		private Infragistics.Win.Misc.UltraLabel PayStMoneyKindCd1RF_Label;
		private Infragistics.Win.Misc.UltraLabel PayStMoneyKindCd2RF_Label;
		private Infragistics.Win.Misc.UltraLabel PayStMoneyKindCd3RF_Label;
		private Infragistics.Win.Misc.UltraLabel PayStMoneyKindCd4RF_Label;
		private Infragistics.Win.Misc.UltraLabel PayStMoneyKindCd5RF_Label;
		private Infragistics.Win.Misc.UltraLabel PayStMoneyKindCd6RF_Label;
		private Infragistics.Win.Misc.UltraLabel PayStMoneyKindCd7RF_Label;
		private Infragistics.Win.Misc.UltraLabel PayStMoneyKindCd8RF_Label;
		private System.Windows.Forms.Timer timer1;
		private Infragistics.Win.Misc.UltraButton PayStMoneyKindCd1RF_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton PayStMoneyKindCd2RF_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton PayStMoneyKindCd3RF_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton PayStMoneyKindCd4RF_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton PayStMoneyKindCd5RF_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton PayStMoneyKindCd6RF_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton PayStMoneyKindCd7RF_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton PayStMoneyKindCd8RF_tUltraBtn;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private UltraButton InitSelMoneyKindCdRF_tUltraBtn;
        private TEdit InitSelMoneyKindCdRF_tEdit;
        private TNedit InitSelMoneyKindCdRF_tNedit;
        private UltraLabel InitSelMoneyKindCdRF_Label;
        private UltraLabel PayStMoneyKindCd9RF_Label;
        private TNedit PayStMoneyKindCd9RF_tNedit;
        private UltraButton PayStMoneyKindCd9RF_tUltraBtn;
        private UltraLabel PayStMoneyKindCd10RF_Label;
        private TNedit PayStMoneyKindCd10RF_tNedit;
        private UltraButton PayStMoneyKindCd10RF_tUltraBtn;
        private TEdit PayStMoneyKindCd10RF_tEdit;
        private TEdit PayStMoneyKindCd9RF_tEdit;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private UltraButton Renewal_Button;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// �x���ݒ���̓t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �x���ݒ���̓t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public SFSIR09020UA()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

			// �x���ݒ�A�N�Z�X�N���X
			this.paymentSetAcs = new PaymentSetAcs();

			// �x���ݒ�N���X
			this.paymentSet = new PaymentSet();

			// ��ʃR���|�[�l���g�o�^
			tneditCompList = new ArrayList();
			tneditCompList.Add(this.PayStMoneyKindCd1RF_tNedit);
			tneditCompList.Add(this.PayStMoneyKindCd2RF_tNedit);
			tneditCompList.Add(this.PayStMoneyKindCd3RF_tNedit);
			tneditCompList.Add(this.PayStMoneyKindCd4RF_tNedit);
			tneditCompList.Add(this.PayStMoneyKindCd5RF_tNedit);
			tneditCompList.Add(this.PayStMoneyKindCd6RF_tNedit);
			tneditCompList.Add(this.PayStMoneyKindCd7RF_tNedit);
			tneditCompList.Add(this.PayStMoneyKindCd8RF_tNedit);
            //2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //tneditCompList.Add(this.PayStMoneyKindCd9RF_tNedit);
            //tneditCompList.Add(this.PayStMoneyKindCd10RF_tNedit);
            //2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			tneditCompList.TrimToSize();

			teditCompList = new ArrayList();;
			teditCompList.Add(this.PayStMoneyKindCd1RF_tEdit);
			teditCompList.Add(this.PayStMoneyKindCd2RF_tEdit);
			teditCompList.Add(this.PayStMoneyKindCd3RF_tEdit);
			teditCompList.Add(this.PayStMoneyKindCd4RF_tEdit);
			teditCompList.Add(this.PayStMoneyKindCd5RF_tEdit);
			teditCompList.Add(this.PayStMoneyKindCd6RF_tEdit);
			teditCompList.Add(this.PayStMoneyKindCd7RF_tEdit);
			teditCompList.Add(this.PayStMoneyKindCd8RF_tEdit);
            //2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //teditCompList.Add(this.PayStMoneyKindCd9RF_tEdit);
            //teditCompList.Add(this.PayStMoneyKindCd10RF_tEdit);
            //2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            teditCompList.TrimToSize();

			
			// ����\�t���O��ݒ肵�܂��B
			// Frame�̈���{�^���̕\����\���̐���Ɏg�p���܂��B
			_canPrint = false;

			// ��ʃN���[�Y����ݒ肵�܂��B
			// Close��Hide���̐���Ɏg�p���܂��B
			_canClose = false;

			// ��ƃR�[�h���擾����
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
			this.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
			// ����f�[�^�i�[�p
			this._moneyKindAcs = new MoneyKindAcs();
            this._moneyKindAcs.IsLocalDBRead = false;  // iitani a 2007.05.23 �����[�g�Œ�œǂނ悤�C��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END
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
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo11 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo4 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo5 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo6 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo7 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo8 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo9 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo10 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance117 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFSIR09020UA));
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.PayStMoneyKindCd1RF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PayStMoneyKindCdRF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd2RF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PayStMoneyKindCd1RF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd4RF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PayStMoneyKindCd3RF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PayStMoneyKindCd8RF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PayStMoneyKindCd7RF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PayStMoneyKindCd6RF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PayStMoneyKindCd5RF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tHtmlGenerate1 = new Broadleaf.Library.Windows.Forms.THtmlGenerate(this.components);
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd2RF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd3RF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd4RF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd5RF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd6RF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd7RF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd1RF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PayStMoneyKindCd2RF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PayStMoneyKindCd3RF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PayStMoneyKindCd4RF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PayStMoneyKindCd5RF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PayStMoneyKindCd6RF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PayStMoneyKindCd7RF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PayStMoneyKindCd8RF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PayStMoneyKindCd8RF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PayStMoneyKindCd1RF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.PayStMoneyKindCd2RF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.PayStMoneyKindCd3RF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.PayStMoneyKindCd4RF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.PayStMoneyKindCd5RF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.PayStMoneyKindCd6RF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.PayStMoneyKindCd7RF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.PayStMoneyKindCd8RF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.InitSelMoneyKindCdRF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.InitSelMoneyKindCdRF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.InitSelMoneyKindCdRF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.InitSelMoneyKindCdRF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PayStMoneyKindCd10RF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd10RF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PayStMoneyKindCd10RF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.PayStMoneyKindCd9RF_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayStMoneyKindCd9RF_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PayStMoneyKindCd9RF_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.PayStMoneyKindCd10RF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PayStMoneyKindCd9RF_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd1RF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd2RF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd4RF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd3RF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd8RF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd7RF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd6RF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd5RF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd1RF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd2RF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd3RF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd4RF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd5RF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd6RF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd7RF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd8RF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InitSelMoneyKindCdRF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InitSelMoneyKindCdRF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd10RF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd9RF_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd10RF_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd9RF_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 340);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(422, 23);
            this.ultraStatusBar1.TabIndex = 700;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(156, 279);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 23;
            this.Ok_Button.Tag = "210";
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(281, 279);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 24;
            this.Cancel_Button.Tag = "220";
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // PayStMoneyKindCd1RF_tEdit
            // 
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PayStMoneyKindCd1RF_tEdit.ActiveAppearance = appearance61;
            appearance62.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance62.ForeColorDisabled = System.Drawing.Color.Black;
            this.PayStMoneyKindCd1RF_tEdit.Appearance = appearance62;
            this.PayStMoneyKindCd1RF_tEdit.AutoSelect = true;
            this.PayStMoneyKindCd1RF_tEdit.DataText = "";
            this.PayStMoneyKindCd1RF_tEdit.Enabled = false;
            this.PayStMoneyKindCd1RF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd1RF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PayStMoneyKindCd1RF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PayStMoneyKindCd1RF_tEdit.Location = new System.Drawing.Point(122, 51);
            this.PayStMoneyKindCd1RF_tEdit.MaxLength = 30;
            this.PayStMoneyKindCd1RF_tEdit.Name = "PayStMoneyKindCd1RF_tEdit";
            this.PayStMoneyKindCd1RF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PayStMoneyKindCd1RF_tEdit.TabIndex = 620;
            this.PayStMoneyKindCd1RF_tEdit.TabStop = false;
            this.PayStMoneyKindCd1RF_tEdit.Tag = "111";
            // 
            // PayStMoneyKindCdRF_Label
            // 
            appearance63.ForeColor = System.Drawing.Color.White;
            appearance63.TextHAlignAsString = "Center";
            appearance63.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCdRF_Label.Appearance = appearance63;
            this.PayStMoneyKindCdRF_Label.BackColorInternal = System.Drawing.SystemColors.Highlight;
            this.PayStMoneyKindCdRF_Label.Location = new System.Drawing.Point(56, 26);
            this.PayStMoneyKindCdRF_Label.Name = "PayStMoneyKindCdRF_Label";
            this.PayStMoneyKindCdRF_Label.Size = new System.Drawing.Size(179, 24);
            this.PayStMoneyKindCdRF_Label.TabIndex = 503;
            this.PayStMoneyKindCdRF_Label.Tag = "";
            this.PayStMoneyKindCdRF_Label.Text = "�x���ݒ����R�[�h";
            // 
            // PayStMoneyKindCd2RF_tEdit
            // 
            appearance64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PayStMoneyKindCd2RF_tEdit.ActiveAppearance = appearance64;
            appearance65.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance65.ForeColorDisabled = System.Drawing.Color.Black;
            this.PayStMoneyKindCd2RF_tEdit.Appearance = appearance65;
            this.PayStMoneyKindCd2RF_tEdit.AutoSelect = true;
            this.PayStMoneyKindCd2RF_tEdit.DataText = "";
            this.PayStMoneyKindCd2RF_tEdit.Enabled = false;
            this.PayStMoneyKindCd2RF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd2RF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PayStMoneyKindCd2RF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PayStMoneyKindCd2RF_tEdit.Location = new System.Drawing.Point(122, 76);
            this.PayStMoneyKindCd2RF_tEdit.MaxLength = 30;
            this.PayStMoneyKindCd2RF_tEdit.Name = "PayStMoneyKindCd2RF_tEdit";
            this.PayStMoneyKindCd2RF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PayStMoneyKindCd2RF_tEdit.TabIndex = 630;
            this.PayStMoneyKindCd2RF_tEdit.TabStop = false;
            this.PayStMoneyKindCd2RF_tEdit.Tag = "112";
            // 
            // PayStMoneyKindCd1RF_Label
            // 
            appearance66.TextHAlignAsString = "Center";
            appearance66.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCd1RF_Label.Appearance = appearance66;
            this.PayStMoneyKindCd1RF_Label.Location = new System.Drawing.Point(36, 51);
            this.PayStMoneyKindCd1RF_Label.Name = "PayStMoneyKindCd1RF_Label";
            this.PayStMoneyKindCd1RF_Label.Size = new System.Drawing.Size(15, 24);
            this.PayStMoneyKindCd1RF_Label.TabIndex = 504;
            this.PayStMoneyKindCd1RF_Label.Tag = "2";
            this.PayStMoneyKindCd1RF_Label.Text = "�P";
            // 
            // PayStMoneyKindCd4RF_tEdit
            // 
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PayStMoneyKindCd4RF_tEdit.ActiveAppearance = appearance67;
            appearance68.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance68.ForeColorDisabled = System.Drawing.Color.Black;
            this.PayStMoneyKindCd4RF_tEdit.Appearance = appearance68;
            this.PayStMoneyKindCd4RF_tEdit.AutoSelect = true;
            this.PayStMoneyKindCd4RF_tEdit.DataText = "";
            this.PayStMoneyKindCd4RF_tEdit.Enabled = false;
            this.PayStMoneyKindCd4RF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd4RF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PayStMoneyKindCd4RF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PayStMoneyKindCd4RF_tEdit.Location = new System.Drawing.Point(122, 126);
            this.PayStMoneyKindCd4RF_tEdit.MaxLength = 30;
            this.PayStMoneyKindCd4RF_tEdit.Name = "PayStMoneyKindCd4RF_tEdit";
            this.PayStMoneyKindCd4RF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PayStMoneyKindCd4RF_tEdit.TabIndex = 650;
            this.PayStMoneyKindCd4RF_tEdit.TabStop = false;
            this.PayStMoneyKindCd4RF_tEdit.Tag = "114";
            // 
            // PayStMoneyKindCd3RF_tEdit
            // 
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PayStMoneyKindCd3RF_tEdit.ActiveAppearance = appearance69;
            appearance70.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance70.ForeColorDisabled = System.Drawing.Color.Black;
            this.PayStMoneyKindCd3RF_tEdit.Appearance = appearance70;
            this.PayStMoneyKindCd3RF_tEdit.AutoSelect = true;
            this.PayStMoneyKindCd3RF_tEdit.DataText = "";
            this.PayStMoneyKindCd3RF_tEdit.Enabled = false;
            this.PayStMoneyKindCd3RF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd3RF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PayStMoneyKindCd3RF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PayStMoneyKindCd3RF_tEdit.Location = new System.Drawing.Point(122, 101);
            this.PayStMoneyKindCd3RF_tEdit.MaxLength = 30;
            this.PayStMoneyKindCd3RF_tEdit.Name = "PayStMoneyKindCd3RF_tEdit";
            this.PayStMoneyKindCd3RF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PayStMoneyKindCd3RF_tEdit.TabIndex = 640;
            this.PayStMoneyKindCd3RF_tEdit.TabStop = false;
            this.PayStMoneyKindCd3RF_tEdit.Tag = "113";
            // 
            // PayStMoneyKindCd8RF_tEdit
            // 
            appearance71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PayStMoneyKindCd8RF_tEdit.ActiveAppearance = appearance71;
            appearance72.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance72.ForeColorDisabled = System.Drawing.Color.Black;
            this.PayStMoneyKindCd8RF_tEdit.Appearance = appearance72;
            this.PayStMoneyKindCd8RF_tEdit.AutoSelect = true;
            this.PayStMoneyKindCd8RF_tEdit.DataText = "";
            this.PayStMoneyKindCd8RF_tEdit.Enabled = false;
            this.PayStMoneyKindCd8RF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd8RF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PayStMoneyKindCd8RF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PayStMoneyKindCd8RF_tEdit.Location = new System.Drawing.Point(122, 226);
            this.PayStMoneyKindCd8RF_tEdit.MaxLength = 30;
            this.PayStMoneyKindCd8RF_tEdit.Name = "PayStMoneyKindCd8RF_tEdit";
            this.PayStMoneyKindCd8RF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PayStMoneyKindCd8RF_tEdit.TabIndex = 690;
            this.PayStMoneyKindCd8RF_tEdit.TabStop = false;
            this.PayStMoneyKindCd8RF_tEdit.Tag = "118";
            // 
            // PayStMoneyKindCd7RF_tEdit
            // 
            appearance73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PayStMoneyKindCd7RF_tEdit.ActiveAppearance = appearance73;
            appearance74.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance74.ForeColorDisabled = System.Drawing.Color.Black;
            this.PayStMoneyKindCd7RF_tEdit.Appearance = appearance74;
            this.PayStMoneyKindCd7RF_tEdit.AutoSelect = true;
            this.PayStMoneyKindCd7RF_tEdit.DataText = "";
            this.PayStMoneyKindCd7RF_tEdit.Enabled = false;
            this.PayStMoneyKindCd7RF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd7RF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PayStMoneyKindCd7RF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PayStMoneyKindCd7RF_tEdit.Location = new System.Drawing.Point(122, 201);
            this.PayStMoneyKindCd7RF_tEdit.MaxLength = 30;
            this.PayStMoneyKindCd7RF_tEdit.Name = "PayStMoneyKindCd7RF_tEdit";
            this.PayStMoneyKindCd7RF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PayStMoneyKindCd7RF_tEdit.TabIndex = 680;
            this.PayStMoneyKindCd7RF_tEdit.TabStop = false;
            this.PayStMoneyKindCd7RF_tEdit.Tag = "117";
            // 
            // PayStMoneyKindCd6RF_tEdit
            // 
            appearance75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PayStMoneyKindCd6RF_tEdit.ActiveAppearance = appearance75;
            appearance76.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance76.ForeColorDisabled = System.Drawing.Color.Black;
            this.PayStMoneyKindCd6RF_tEdit.Appearance = appearance76;
            this.PayStMoneyKindCd6RF_tEdit.AutoSelect = true;
            this.PayStMoneyKindCd6RF_tEdit.DataText = "";
            this.PayStMoneyKindCd6RF_tEdit.Enabled = false;
            this.PayStMoneyKindCd6RF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd6RF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PayStMoneyKindCd6RF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PayStMoneyKindCd6RF_tEdit.Location = new System.Drawing.Point(122, 176);
            this.PayStMoneyKindCd6RF_tEdit.MaxLength = 30;
            this.PayStMoneyKindCd6RF_tEdit.Name = "PayStMoneyKindCd6RF_tEdit";
            this.PayStMoneyKindCd6RF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PayStMoneyKindCd6RF_tEdit.TabIndex = 670;
            this.PayStMoneyKindCd6RF_tEdit.TabStop = false;
            this.PayStMoneyKindCd6RF_tEdit.Tag = "116";
            // 
            // PayStMoneyKindCd5RF_tEdit
            // 
            appearance77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PayStMoneyKindCd5RF_tEdit.ActiveAppearance = appearance77;
            appearance78.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance78.ForeColorDisabled = System.Drawing.Color.Black;
            this.PayStMoneyKindCd5RF_tEdit.Appearance = appearance78;
            this.PayStMoneyKindCd5RF_tEdit.AutoSelect = true;
            this.PayStMoneyKindCd5RF_tEdit.DataText = "";
            this.PayStMoneyKindCd5RF_tEdit.Enabled = false;
            this.PayStMoneyKindCd5RF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd5RF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PayStMoneyKindCd5RF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PayStMoneyKindCd5RF_tEdit.Location = new System.Drawing.Point(122, 151);
            this.PayStMoneyKindCd5RF_tEdit.MaxLength = 30;
            this.PayStMoneyKindCd5RF_tEdit.Name = "PayStMoneyKindCd5RF_tEdit";
            this.PayStMoneyKindCd5RF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PayStMoneyKindCd5RF_tEdit.TabIndex = 660;
            this.PayStMoneyKindCd5RF_tEdit.TabStop = false;
            this.PayStMoneyKindCd5RF_tEdit.Tag = "115";
            // 
            // tHtmlGenerate1
            // 
            this.tHtmlGenerate1.Align = Broadleaf.Library.Windows.Forms.align.center;
            this.tHtmlGenerate1.coltype = true;
            this.tHtmlGenerate1.Guusuucolor = System.Drawing.Color.PaleTurquoise;
            this.tHtmlGenerate1.GuusuuRow = true;
            this.tHtmlGenerate1.HaikeiColor = System.Drawing.Color.AliceBlue;
            this.tHtmlGenerate1.HightBR = 1;
            this.tHtmlGenerate1.koteicolcolor = System.Drawing.Color.RoyalBlue;
            this.tHtmlGenerate1.koteifontcolor = System.Drawing.Color.White;
            this.tHtmlGenerate1.RowBackColor = System.Drawing.Color.Transparent;
            this.tHtmlGenerate1.RowFontColor = System.Drawing.Color.Black;
            this.tHtmlGenerate1.RowFontSize = 7;
            this.tHtmlGenerate1.SelectedBackColor = System.Drawing.Color.White;
            this.tHtmlGenerate1.TitleColor = System.Drawing.Color.Navy;
            this.tHtmlGenerate1.TitleFontColor = System.Drawing.Color.White;
            this.tHtmlGenerate1.TitleFontSize = 7;
            // 
            // Mode_Label
            // 
            appearance79.ForeColor = System.Drawing.Color.White;
            appearance79.TextHAlignAsString = "Center";
            appearance79.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance79;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(318, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 501;
            this.Mode_Label.Tag = "";
            // 
            // PayStMoneyKindCd2RF_Label
            // 
            appearance80.TextHAlignAsString = "Center";
            appearance80.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCd2RF_Label.Appearance = appearance80;
            this.PayStMoneyKindCd2RF_Label.Location = new System.Drawing.Point(36, 76);
            this.PayStMoneyKindCd2RF_Label.Name = "PayStMoneyKindCd2RF_Label";
            this.PayStMoneyKindCd2RF_Label.Size = new System.Drawing.Size(15, 24);
            this.PayStMoneyKindCd2RF_Label.TabIndex = 505;
            this.PayStMoneyKindCd2RF_Label.Tag = "3";
            this.PayStMoneyKindCd2RF_Label.Text = "�Q";
            // 
            // PayStMoneyKindCd3RF_Label
            // 
            appearance81.TextHAlignAsString = "Center";
            appearance81.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCd3RF_Label.Appearance = appearance81;
            this.PayStMoneyKindCd3RF_Label.Location = new System.Drawing.Point(36, 101);
            this.PayStMoneyKindCd3RF_Label.Name = "PayStMoneyKindCd3RF_Label";
            this.PayStMoneyKindCd3RF_Label.Size = new System.Drawing.Size(15, 24);
            this.PayStMoneyKindCd3RF_Label.TabIndex = 506;
            this.PayStMoneyKindCd3RF_Label.Tag = "4";
            this.PayStMoneyKindCd3RF_Label.Text = "�R";
            // 
            // PayStMoneyKindCd4RF_Label
            // 
            appearance82.TextHAlignAsString = "Center";
            appearance82.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCd4RF_Label.Appearance = appearance82;
            this.PayStMoneyKindCd4RF_Label.Location = new System.Drawing.Point(36, 126);
            this.PayStMoneyKindCd4RF_Label.Name = "PayStMoneyKindCd4RF_Label";
            this.PayStMoneyKindCd4RF_Label.Size = new System.Drawing.Size(15, 24);
            this.PayStMoneyKindCd4RF_Label.TabIndex = 507;
            this.PayStMoneyKindCd4RF_Label.Tag = "5";
            this.PayStMoneyKindCd4RF_Label.Text = "�S";
            // 
            // PayStMoneyKindCd5RF_Label
            // 
            appearance83.TextHAlignAsString = "Center";
            appearance83.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCd5RF_Label.Appearance = appearance83;
            this.PayStMoneyKindCd5RF_Label.Location = new System.Drawing.Point(36, 151);
            this.PayStMoneyKindCd5RF_Label.Name = "PayStMoneyKindCd5RF_Label";
            this.PayStMoneyKindCd5RF_Label.Size = new System.Drawing.Size(15, 24);
            this.PayStMoneyKindCd5RF_Label.TabIndex = 508;
            this.PayStMoneyKindCd5RF_Label.Tag = "6";
            this.PayStMoneyKindCd5RF_Label.Text = "�T";
            // 
            // PayStMoneyKindCd6RF_Label
            // 
            appearance84.TextHAlignAsString = "Center";
            appearance84.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCd6RF_Label.Appearance = appearance84;
            this.PayStMoneyKindCd6RF_Label.Location = new System.Drawing.Point(36, 176);
            this.PayStMoneyKindCd6RF_Label.Name = "PayStMoneyKindCd6RF_Label";
            this.PayStMoneyKindCd6RF_Label.Size = new System.Drawing.Size(15, 24);
            this.PayStMoneyKindCd6RF_Label.TabIndex = 509;
            this.PayStMoneyKindCd6RF_Label.Tag = "7";
            this.PayStMoneyKindCd6RF_Label.Text = "�U";
            // 
            // PayStMoneyKindCd7RF_Label
            // 
            appearance85.TextHAlignAsString = "Center";
            appearance85.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCd7RF_Label.Appearance = appearance85;
            this.PayStMoneyKindCd7RF_Label.Location = new System.Drawing.Point(36, 201);
            this.PayStMoneyKindCd7RF_Label.Name = "PayStMoneyKindCd7RF_Label";
            this.PayStMoneyKindCd7RF_Label.Size = new System.Drawing.Size(15, 24);
            this.PayStMoneyKindCd7RF_Label.TabIndex = 510;
            this.PayStMoneyKindCd7RF_Label.Tag = "8";
            this.PayStMoneyKindCd7RF_Label.Text = "�V";
            // 
            // PayStMoneyKindCd1RF_tNedit
            // 
            appearance86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance86.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd1RF_tNedit.ActiveAppearance = appearance86;
            appearance87.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd1RF_tNedit.Appearance = appearance87;
            this.PayStMoneyKindCd1RF_tNedit.AutoSelect = true;
            this.PayStMoneyKindCd1RF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayStMoneyKindCd1RF_tNedit.DataText = "";
            this.PayStMoneyKindCd1RF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd1RF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayStMoneyKindCd1RF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayStMoneyKindCd1RF_tNedit.Location = new System.Drawing.Point(56, 51);
            this.PayStMoneyKindCd1RF_tNedit.MaxLength = 3;
            this.PayStMoneyKindCd1RF_tNedit.Name = "PayStMoneyKindCd1RF_tNedit";
            this.PayStMoneyKindCd1RF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.PayStMoneyKindCd1RF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PayStMoneyKindCd1RF_tNedit.TabIndex = 3;
            this.PayStMoneyKindCd1RF_tNedit.Tag = "1";
            this.PayStMoneyKindCd1RF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.PayStMoneyKindCd1RF_tNedit.Leave += new System.EventHandler(this.PayStMoneyKindCd1RF_tNedit_Leave);
            this.PayStMoneyKindCd1RF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // PayStMoneyKindCd2RF_tNedit
            // 
            appearance88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance88.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd2RF_tNedit.ActiveAppearance = appearance88;
            appearance89.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd2RF_tNedit.Appearance = appearance89;
            this.PayStMoneyKindCd2RF_tNedit.AutoSelect = true;
            this.PayStMoneyKindCd2RF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayStMoneyKindCd2RF_tNedit.DataText = "";
            this.PayStMoneyKindCd2RF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd2RF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayStMoneyKindCd2RF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayStMoneyKindCd2RF_tNedit.Location = new System.Drawing.Point(56, 76);
            this.PayStMoneyKindCd2RF_tNedit.MaxLength = 3;
            this.PayStMoneyKindCd2RF_tNedit.Name = "PayStMoneyKindCd2RF_tNedit";
            this.PayStMoneyKindCd2RF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.PayStMoneyKindCd2RF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PayStMoneyKindCd2RF_tNedit.TabIndex = 5;
            this.PayStMoneyKindCd2RF_tNedit.Tag = "2";
            this.PayStMoneyKindCd2RF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.PayStMoneyKindCd2RF_tNedit.Leave += new System.EventHandler(this.PayStMoneyKindCd2RF_tNedit_Leave);
            this.PayStMoneyKindCd2RF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // PayStMoneyKindCd3RF_tNedit
            // 
            appearance90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance90.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd3RF_tNedit.ActiveAppearance = appearance90;
            appearance91.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd3RF_tNedit.Appearance = appearance91;
            this.PayStMoneyKindCd3RF_tNedit.AutoSelect = true;
            this.PayStMoneyKindCd3RF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayStMoneyKindCd3RF_tNedit.DataText = "";
            this.PayStMoneyKindCd3RF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd3RF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayStMoneyKindCd3RF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayStMoneyKindCd3RF_tNedit.Location = new System.Drawing.Point(56, 101);
            this.PayStMoneyKindCd3RF_tNedit.MaxLength = 3;
            this.PayStMoneyKindCd3RF_tNedit.Name = "PayStMoneyKindCd3RF_tNedit";
            this.PayStMoneyKindCd3RF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.PayStMoneyKindCd3RF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PayStMoneyKindCd3RF_tNedit.TabIndex = 7;
            this.PayStMoneyKindCd3RF_tNedit.Tag = "3";
            this.PayStMoneyKindCd3RF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.PayStMoneyKindCd3RF_tNedit.Leave += new System.EventHandler(this.PayStMoneyKindCd3RF_tNedit_Leave);
            this.PayStMoneyKindCd3RF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // PayStMoneyKindCd4RF_tNedit
            // 
            appearance92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance92.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd4RF_tNedit.ActiveAppearance = appearance92;
            appearance93.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd4RF_tNedit.Appearance = appearance93;
            this.PayStMoneyKindCd4RF_tNedit.AutoSelect = true;
            this.PayStMoneyKindCd4RF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayStMoneyKindCd4RF_tNedit.DataText = "";
            this.PayStMoneyKindCd4RF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd4RF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayStMoneyKindCd4RF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayStMoneyKindCd4RF_tNedit.Location = new System.Drawing.Point(56, 126);
            this.PayStMoneyKindCd4RF_tNedit.MaxLength = 3;
            this.PayStMoneyKindCd4RF_tNedit.Name = "PayStMoneyKindCd4RF_tNedit";
            this.PayStMoneyKindCd4RF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.PayStMoneyKindCd4RF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PayStMoneyKindCd4RF_tNedit.TabIndex = 9;
            this.PayStMoneyKindCd4RF_tNedit.Tag = "4";
            this.PayStMoneyKindCd4RF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.PayStMoneyKindCd4RF_tNedit.Leave += new System.EventHandler(this.PayStMoneyKindCd4RF_tNedit_Leave);
            this.PayStMoneyKindCd4RF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // PayStMoneyKindCd5RF_tNedit
            // 
            appearance94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance94.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd5RF_tNedit.ActiveAppearance = appearance94;
            appearance95.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd5RF_tNedit.Appearance = appearance95;
            this.PayStMoneyKindCd5RF_tNedit.AutoSelect = true;
            this.PayStMoneyKindCd5RF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayStMoneyKindCd5RF_tNedit.DataText = "";
            this.PayStMoneyKindCd5RF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd5RF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayStMoneyKindCd5RF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayStMoneyKindCd5RF_tNedit.Location = new System.Drawing.Point(56, 151);
            this.PayStMoneyKindCd5RF_tNedit.MaxLength = 3;
            this.PayStMoneyKindCd5RF_tNedit.Name = "PayStMoneyKindCd5RF_tNedit";
            this.PayStMoneyKindCd5RF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.PayStMoneyKindCd5RF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PayStMoneyKindCd5RF_tNedit.TabIndex = 11;
            this.PayStMoneyKindCd5RF_tNedit.Tag = "5";
            this.PayStMoneyKindCd5RF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.PayStMoneyKindCd5RF_tNedit.Leave += new System.EventHandler(this.PayStMoneyKindCd5RF_tNedit_Leave);
            this.PayStMoneyKindCd5RF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // PayStMoneyKindCd6RF_tNedit
            // 
            appearance96.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance96.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd6RF_tNedit.ActiveAppearance = appearance96;
            appearance97.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd6RF_tNedit.Appearance = appearance97;
            this.PayStMoneyKindCd6RF_tNedit.AutoSelect = true;
            this.PayStMoneyKindCd6RF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayStMoneyKindCd6RF_tNedit.DataText = "";
            this.PayStMoneyKindCd6RF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd6RF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayStMoneyKindCd6RF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayStMoneyKindCd6RF_tNedit.Location = new System.Drawing.Point(56, 176);
            this.PayStMoneyKindCd6RF_tNedit.MaxLength = 3;
            this.PayStMoneyKindCd6RF_tNedit.Name = "PayStMoneyKindCd6RF_tNedit";
            this.PayStMoneyKindCd6RF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.PayStMoneyKindCd6RF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PayStMoneyKindCd6RF_tNedit.TabIndex = 13;
            this.PayStMoneyKindCd6RF_tNedit.Tag = "6";
            this.PayStMoneyKindCd6RF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.PayStMoneyKindCd6RF_tNedit.Leave += new System.EventHandler(this.PayStMoneyKindCd6RF_tNedit_Leave);
            this.PayStMoneyKindCd6RF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // PayStMoneyKindCd7RF_tNedit
            // 
            appearance98.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance98.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd7RF_tNedit.ActiveAppearance = appearance98;
            appearance99.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd7RF_tNedit.Appearance = appearance99;
            this.PayStMoneyKindCd7RF_tNedit.AutoSelect = true;
            this.PayStMoneyKindCd7RF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayStMoneyKindCd7RF_tNedit.DataText = "";
            this.PayStMoneyKindCd7RF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd7RF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayStMoneyKindCd7RF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayStMoneyKindCd7RF_tNedit.Location = new System.Drawing.Point(56, 201);
            this.PayStMoneyKindCd7RF_tNedit.MaxLength = 3;
            this.PayStMoneyKindCd7RF_tNedit.Name = "PayStMoneyKindCd7RF_tNedit";
            this.PayStMoneyKindCd7RF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.PayStMoneyKindCd7RF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PayStMoneyKindCd7RF_tNedit.TabIndex = 15;
            this.PayStMoneyKindCd7RF_tNedit.Tag = "7";
            this.PayStMoneyKindCd7RF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.PayStMoneyKindCd7RF_tNedit.Leave += new System.EventHandler(this.PayStMoneyKindCd7RF_tNedit_Leave);
            this.PayStMoneyKindCd7RF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // PayStMoneyKindCd8RF_tNedit
            // 
            appearance100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance100.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd8RF_tNedit.ActiveAppearance = appearance100;
            appearance101.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd8RF_tNedit.Appearance = appearance101;
            this.PayStMoneyKindCd8RF_tNedit.AutoSelect = true;
            this.PayStMoneyKindCd8RF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayStMoneyKindCd8RF_tNedit.DataText = "";
            this.PayStMoneyKindCd8RF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd8RF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayStMoneyKindCd8RF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayStMoneyKindCd8RF_tNedit.Location = new System.Drawing.Point(56, 226);
            this.PayStMoneyKindCd8RF_tNedit.MaxLength = 3;
            this.PayStMoneyKindCd8RF_tNedit.Name = "PayStMoneyKindCd8RF_tNedit";
            this.PayStMoneyKindCd8RF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.PayStMoneyKindCd8RF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PayStMoneyKindCd8RF_tNedit.TabIndex = 17;
            this.PayStMoneyKindCd8RF_tNedit.Tag = "8";
            this.PayStMoneyKindCd8RF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.PayStMoneyKindCd8RF_tNedit.Leave += new System.EventHandler(this.PayStMoneyKindCd8RF_tNedit_Leave);
            this.PayStMoneyKindCd8RF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // PayStMoneyKindCd8RF_Label
            // 
            appearance102.TextHAlignAsString = "Center";
            appearance102.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCd8RF_Label.Appearance = appearance102;
            this.PayStMoneyKindCd8RF_Label.Location = new System.Drawing.Point(36, 226);
            this.PayStMoneyKindCd8RF_Label.Name = "PayStMoneyKindCd8RF_Label";
            this.PayStMoneyKindCd8RF_Label.Size = new System.Drawing.Size(15, 24);
            this.PayStMoneyKindCd8RF_Label.TabIndex = 511;
            this.PayStMoneyKindCd8RF_Label.Tag = "9";
            this.PayStMoneyKindCd8RF_Label.Text = "�W";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PayStMoneyKindCd1RF_tUltraBtn
            // 
            this.PayStMoneyKindCd1RF_tUltraBtn.Location = new System.Drawing.Point(94, 51);
            this.PayStMoneyKindCd1RF_tUltraBtn.Name = "PayStMoneyKindCd1RF_tUltraBtn";
            this.PayStMoneyKindCd1RF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.PayStMoneyKindCd1RF_tUltraBtn.TabIndex = 4;
            ultraToolTipInfo11.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.PayStMoneyKindCd1RF_tUltraBtn, ultraToolTipInfo11);
            this.PayStMoneyKindCd1RF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.PayStMoneyKindCd1RF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
            // 
            // PayStMoneyKindCd2RF_tUltraBtn
            // 
            this.PayStMoneyKindCd2RF_tUltraBtn.Location = new System.Drawing.Point(94, 76);
            this.PayStMoneyKindCd2RF_tUltraBtn.Name = "PayStMoneyKindCd2RF_tUltraBtn";
            this.PayStMoneyKindCd2RF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.PayStMoneyKindCd2RF_tUltraBtn.TabIndex = 6;
            ultraToolTipInfo4.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.PayStMoneyKindCd2RF_tUltraBtn, ultraToolTipInfo4);
            this.PayStMoneyKindCd2RF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.PayStMoneyKindCd2RF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
            // 
            // PayStMoneyKindCd3RF_tUltraBtn
            // 
            this.PayStMoneyKindCd3RF_tUltraBtn.Location = new System.Drawing.Point(94, 101);
            this.PayStMoneyKindCd3RF_tUltraBtn.Name = "PayStMoneyKindCd3RF_tUltraBtn";
            this.PayStMoneyKindCd3RF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.PayStMoneyKindCd3RF_tUltraBtn.TabIndex = 8;
            ultraToolTipInfo5.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.PayStMoneyKindCd3RF_tUltraBtn, ultraToolTipInfo5);
            this.PayStMoneyKindCd3RF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.PayStMoneyKindCd3RF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
            // 
            // PayStMoneyKindCd4RF_tUltraBtn
            // 
            this.PayStMoneyKindCd4RF_tUltraBtn.Location = new System.Drawing.Point(94, 126);
            this.PayStMoneyKindCd4RF_tUltraBtn.Name = "PayStMoneyKindCd4RF_tUltraBtn";
            this.PayStMoneyKindCd4RF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.PayStMoneyKindCd4RF_tUltraBtn.TabIndex = 10;
            ultraToolTipInfo6.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.PayStMoneyKindCd4RF_tUltraBtn, ultraToolTipInfo6);
            this.PayStMoneyKindCd4RF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.PayStMoneyKindCd4RF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
            // 
            // PayStMoneyKindCd5RF_tUltraBtn
            // 
            this.PayStMoneyKindCd5RF_tUltraBtn.Location = new System.Drawing.Point(94, 151);
            this.PayStMoneyKindCd5RF_tUltraBtn.Name = "PayStMoneyKindCd5RF_tUltraBtn";
            this.PayStMoneyKindCd5RF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.PayStMoneyKindCd5RF_tUltraBtn.TabIndex = 12;
            ultraToolTipInfo7.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.PayStMoneyKindCd5RF_tUltraBtn, ultraToolTipInfo7);
            this.PayStMoneyKindCd5RF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.PayStMoneyKindCd5RF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
            // 
            // PayStMoneyKindCd6RF_tUltraBtn
            // 
            this.PayStMoneyKindCd6RF_tUltraBtn.Location = new System.Drawing.Point(94, 176);
            this.PayStMoneyKindCd6RF_tUltraBtn.Name = "PayStMoneyKindCd6RF_tUltraBtn";
            this.PayStMoneyKindCd6RF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.PayStMoneyKindCd6RF_tUltraBtn.TabIndex = 14;
            ultraToolTipInfo8.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.PayStMoneyKindCd6RF_tUltraBtn, ultraToolTipInfo8);
            this.PayStMoneyKindCd6RF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.PayStMoneyKindCd6RF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
            // 
            // PayStMoneyKindCd7RF_tUltraBtn
            // 
            this.PayStMoneyKindCd7RF_tUltraBtn.Location = new System.Drawing.Point(94, 201);
            this.PayStMoneyKindCd7RF_tUltraBtn.Name = "PayStMoneyKindCd7RF_tUltraBtn";
            this.PayStMoneyKindCd7RF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.PayStMoneyKindCd7RF_tUltraBtn.TabIndex = 16;
            ultraToolTipInfo9.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.PayStMoneyKindCd7RF_tUltraBtn, ultraToolTipInfo9);
            this.PayStMoneyKindCd7RF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.PayStMoneyKindCd7RF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
            // 
            // PayStMoneyKindCd8RF_tUltraBtn
            // 
            this.PayStMoneyKindCd8RF_tUltraBtn.Location = new System.Drawing.Point(94, 226);
            this.PayStMoneyKindCd8RF_tUltraBtn.Name = "PayStMoneyKindCd8RF_tUltraBtn";
            this.PayStMoneyKindCd8RF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.PayStMoneyKindCd8RF_tUltraBtn.TabIndex = 18;
            ultraToolTipInfo10.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.PayStMoneyKindCd8RF_tUltraBtn, ultraToolTipInfo10);
            this.PayStMoneyKindCd8RF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.PayStMoneyKindCd8RF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
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
            // InitSelMoneyKindCdRF_tNedit
            // 
            appearance115.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance115.TextHAlignAsString = "Right";
            this.InitSelMoneyKindCdRF_tNedit.ActiveAppearance = appearance115;
            appearance116.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance116.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance116.ForeColor = System.Drawing.Color.Black;
            appearance116.ForeColorDisabled = System.Drawing.Color.Black;
            appearance116.TextHAlignAsString = "Right";
            appearance116.TextVAlignAsString = "Middle";
            this.InitSelMoneyKindCdRF_tNedit.Appearance = appearance116;
            this.InitSelMoneyKindCdRF_tNedit.AutoSelect = true;
            this.InitSelMoneyKindCdRF_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.InitSelMoneyKindCdRF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.InitSelMoneyKindCdRF_tNedit.DataText = "";
            this.InitSelMoneyKindCdRF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.InitSelMoneyKindCdRF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.InitSelMoneyKindCdRF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.InitSelMoneyKindCdRF_tNedit.Location = new System.Drawing.Point(56, 301);
            this.InitSelMoneyKindCdRF_tNedit.MaxLength = 3;
            this.InitSelMoneyKindCdRF_tNedit.Name = "InitSelMoneyKindCdRF_tNedit";
            this.InitSelMoneyKindCdRF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.InitSelMoneyKindCdRF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.InitSelMoneyKindCdRF_tNedit.TabIndex = 1;
            this.InitSelMoneyKindCdRF_tNedit.Tag = "0";
            this.InitSelMoneyKindCdRF_tNedit.Visible = false;
            this.InitSelMoneyKindCdRF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.InitSelMoneyKindCdRF_tNedit.Leave += new System.EventHandler(this.tNedit_Leave);
            this.InitSelMoneyKindCdRF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // InitSelMoneyKindCdRF_Label
            // 
            appearance117.ForeColor = System.Drawing.Color.White;
            appearance117.TextHAlignAsString = "Center";
            appearance117.TextVAlignAsString = "Middle";
            this.InitSelMoneyKindCdRF_Label.Appearance = appearance117;
            this.InitSelMoneyKindCdRF_Label.BackColorInternal = System.Drawing.SystemColors.Highlight;
            this.InitSelMoneyKindCdRF_Label.Location = new System.Drawing.Point(56, 276);
            this.InitSelMoneyKindCdRF_Label.Name = "InitSelMoneyKindCdRF_Label";
            this.InitSelMoneyKindCdRF_Label.Size = new System.Drawing.Size(162, 24);
            this.InitSelMoneyKindCdRF_Label.TabIndex = 703;
            this.InitSelMoneyKindCdRF_Label.Tag = "";
            this.InitSelMoneyKindCdRF_Label.Text = "�����I������R�[�h";
            this.InitSelMoneyKindCdRF_Label.Visible = false;
            // 
            // InitSelMoneyKindCdRF_tUltraBtn
            // 
            this.InitSelMoneyKindCdRF_tUltraBtn.Location = new System.Drawing.Point(94, 301);
            this.InitSelMoneyKindCdRF_tUltraBtn.Name = "InitSelMoneyKindCdRF_tUltraBtn";
            this.InitSelMoneyKindCdRF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.InitSelMoneyKindCdRF_tUltraBtn.TabIndex = 2;
            ultraToolTipInfo3.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.InitSelMoneyKindCdRF_tUltraBtn, ultraToolTipInfo3);
            this.InitSelMoneyKindCdRF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.InitSelMoneyKindCdRF_tUltraBtn.Visible = false;
            this.InitSelMoneyKindCdRF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
            // 
            // InitSelMoneyKindCdRF_tEdit
            // 
            appearance113.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InitSelMoneyKindCdRF_tEdit.ActiveAppearance = appearance113;
            appearance114.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance114.ForeColorDisabled = System.Drawing.Color.Black;
            this.InitSelMoneyKindCdRF_tEdit.Appearance = appearance114;
            this.InitSelMoneyKindCdRF_tEdit.AutoSelect = true;
            this.InitSelMoneyKindCdRF_tEdit.DataText = "";
            this.InitSelMoneyKindCdRF_tEdit.Enabled = false;
            this.InitSelMoneyKindCdRF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.InitSelMoneyKindCdRF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.InitSelMoneyKindCdRF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.InitSelMoneyKindCdRF_tEdit.Location = new System.Drawing.Point(122, 301);
            this.InitSelMoneyKindCdRF_tEdit.MaxLength = 30;
            this.InitSelMoneyKindCdRF_tEdit.Name = "InitSelMoneyKindCdRF_tEdit";
            this.InitSelMoneyKindCdRF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.InitSelMoneyKindCdRF_tEdit.TabIndex = 3;
            this.InitSelMoneyKindCdRF_tEdit.TabStop = false;
            this.InitSelMoneyKindCdRF_tEdit.Tag = "111";
            this.InitSelMoneyKindCdRF_tEdit.Visible = false;
            // 
            // PayStMoneyKindCd10RF_Label
            // 
            appearance110.TextHAlignAsString = "Center";
            appearance110.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCd10RF_Label.Appearance = appearance110;
            this.PayStMoneyKindCd10RF_Label.Location = new System.Drawing.Point(15, 289);
            this.PayStMoneyKindCd10RF_Label.Name = "PayStMoneyKindCd10RF_Label";
            this.PayStMoneyKindCd10RF_Label.Size = new System.Drawing.Size(41, 24);
            this.PayStMoneyKindCd10RF_Label.TabIndex = 709;
            this.PayStMoneyKindCd10RF_Label.Tag = "11";
            this.PayStMoneyKindCd10RF_Label.Text = "�P�O";
            this.PayStMoneyKindCd10RF_Label.Visible = false;
            // 
            // PayStMoneyKindCd10RF_tNedit
            // 
            appearance111.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance111.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd10RF_tNedit.ActiveAppearance = appearance111;
            appearance112.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd10RF_tNedit.Appearance = appearance112;
            this.PayStMoneyKindCd10RF_tNedit.AutoSelect = true;
            this.PayStMoneyKindCd10RF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayStMoneyKindCd10RF_tNedit.DataText = "";
            this.PayStMoneyKindCd10RF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd10RF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayStMoneyKindCd10RF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayStMoneyKindCd10RF_tNedit.Location = new System.Drawing.Point(56, 289);
            this.PayStMoneyKindCd10RF_tNedit.MaxLength = 3;
            this.PayStMoneyKindCd10RF_tNedit.Name = "PayStMoneyKindCd10RF_tNedit";
            this.PayStMoneyKindCd10RF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.PayStMoneyKindCd10RF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PayStMoneyKindCd10RF_tNedit.TabIndex = 21;
            this.PayStMoneyKindCd10RF_tNedit.Tag = "10";
            this.PayStMoneyKindCd10RF_tNedit.Visible = false;
            this.PayStMoneyKindCd10RF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.PayStMoneyKindCd10RF_tNedit.Leave += new System.EventHandler(this.PayStMoneyKindCd10RF_tNedit_Leave);
            this.PayStMoneyKindCd10RF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // PayStMoneyKindCd10RF_tUltraBtn
            // 
            this.PayStMoneyKindCd10RF_tUltraBtn.Location = new System.Drawing.Point(94, 289);
            this.PayStMoneyKindCd10RF_tUltraBtn.Name = "PayStMoneyKindCd10RF_tUltraBtn";
            this.PayStMoneyKindCd10RF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.PayStMoneyKindCd10RF_tUltraBtn.TabIndex = 22;
            ultraToolTipInfo2.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.PayStMoneyKindCd10RF_tUltraBtn, ultraToolTipInfo2);
            this.PayStMoneyKindCd10RF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.PayStMoneyKindCd10RF_tUltraBtn.Visible = false;
            this.PayStMoneyKindCd10RF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
            // 
            // PayStMoneyKindCd9RF_Label
            // 
            this.PayStMoneyKindCd9RF_Label.AllowDrop = true;
            appearance107.TextHAlignAsString = "Center";
            appearance107.TextVAlignAsString = "Middle";
            this.PayStMoneyKindCd9RF_Label.Appearance = appearance107;
            this.PayStMoneyKindCd9RF_Label.Location = new System.Drawing.Point(36, 264);
            this.PayStMoneyKindCd9RF_Label.Name = "PayStMoneyKindCd9RF_Label";
            this.PayStMoneyKindCd9RF_Label.Size = new System.Drawing.Size(15, 24);
            this.PayStMoneyKindCd9RF_Label.TabIndex = 713;
            this.PayStMoneyKindCd9RF_Label.Tag = "10";
            this.PayStMoneyKindCd9RF_Label.Text = "�X";
            this.PayStMoneyKindCd9RF_Label.Visible = false;
            // 
            // PayStMoneyKindCd9RF_tNedit
            // 
            appearance108.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance108.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd9RF_tNedit.ActiveAppearance = appearance108;
            appearance109.TextHAlignAsString = "Right";
            this.PayStMoneyKindCd9RF_tNedit.Appearance = appearance109;
            this.PayStMoneyKindCd9RF_tNedit.AutoSelect = true;
            this.PayStMoneyKindCd9RF_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayStMoneyKindCd9RF_tNedit.DataText = "";
            this.PayStMoneyKindCd9RF_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd9RF_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayStMoneyKindCd9RF_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayStMoneyKindCd9RF_tNedit.Location = new System.Drawing.Point(56, 264);
            this.PayStMoneyKindCd9RF_tNedit.MaxLength = 3;
            this.PayStMoneyKindCd9RF_tNedit.Name = "PayStMoneyKindCd9RF_tNedit";
            this.PayStMoneyKindCd9RF_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.PayStMoneyKindCd9RF_tNedit.Size = new System.Drawing.Size(36, 24);
            this.PayStMoneyKindCd9RF_tNedit.TabIndex = 19;
            this.PayStMoneyKindCd9RF_tNedit.Tag = "9";
            this.PayStMoneyKindCd9RF_tNedit.Visible = false;
            this.PayStMoneyKindCd9RF_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.PayStMoneyKindCd9RF_tNedit.Leave += new System.EventHandler(this.PayStMoneyKindCd9RF_tNedit_Leave);
            this.PayStMoneyKindCd9RF_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // PayStMoneyKindCd9RF_tUltraBtn
            // 
            this.PayStMoneyKindCd9RF_tUltraBtn.Location = new System.Drawing.Point(94, 264);
            this.PayStMoneyKindCd9RF_tUltraBtn.Name = "PayStMoneyKindCd9RF_tUltraBtn";
            this.PayStMoneyKindCd9RF_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.PayStMoneyKindCd9RF_tUltraBtn.TabIndex = 20;
            ultraToolTipInfo1.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.PayStMoneyKindCd9RF_tUltraBtn, ultraToolTipInfo1);
            this.PayStMoneyKindCd9RF_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.PayStMoneyKindCd9RF_tUltraBtn.Visible = false;
            this.PayStMoneyKindCd9RF_tUltraBtn.Click += new System.EventHandler(this.PayStMoneyKindCd1RF_tUltraBtn_Click);
            // 
            // PayStMoneyKindCd10RF_tEdit
            // 
            appearance103.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PayStMoneyKindCd10RF_tEdit.ActiveAppearance = appearance103;
            appearance104.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance104.ForeColorDisabled = System.Drawing.Color.Black;
            this.PayStMoneyKindCd10RF_tEdit.Appearance = appearance104;
            this.PayStMoneyKindCd10RF_tEdit.AutoSelect = true;
            this.PayStMoneyKindCd10RF_tEdit.DataText = "";
            this.PayStMoneyKindCd10RF_tEdit.Enabled = false;
            this.PayStMoneyKindCd10RF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd10RF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PayStMoneyKindCd10RF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PayStMoneyKindCd10RF_tEdit.Location = new System.Drawing.Point(122, 289);
            this.PayStMoneyKindCd10RF_tEdit.MaxLength = 30;
            this.PayStMoneyKindCd10RF_tEdit.Name = "PayStMoneyKindCd10RF_tEdit";
            this.PayStMoneyKindCd10RF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PayStMoneyKindCd10RF_tEdit.TabIndex = 715;
            this.PayStMoneyKindCd10RF_tEdit.TabStop = false;
            this.PayStMoneyKindCd10RF_tEdit.Tag = "118";
            this.PayStMoneyKindCd10RF_tEdit.Visible = false;
            // 
            // PayStMoneyKindCd9RF_tEdit
            // 
            appearance105.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PayStMoneyKindCd9RF_tEdit.ActiveAppearance = appearance105;
            appearance106.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance106.ForeColorDisabled = System.Drawing.Color.Black;
            this.PayStMoneyKindCd9RF_tEdit.Appearance = appearance106;
            this.PayStMoneyKindCd9RF_tEdit.AutoSelect = true;
            this.PayStMoneyKindCd9RF_tEdit.DataText = "";
            this.PayStMoneyKindCd9RF_tEdit.Enabled = false;
            this.PayStMoneyKindCd9RF_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayStMoneyKindCd9RF_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PayStMoneyKindCd9RF_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PayStMoneyKindCd9RF_tEdit.Location = new System.Drawing.Point(122, 264);
            this.PayStMoneyKindCd9RF_tEdit.MaxLength = 30;
            this.PayStMoneyKindCd9RF_tEdit.Name = "PayStMoneyKindCd9RF_tEdit";
            this.PayStMoneyKindCd9RF_tEdit.Size = new System.Drawing.Size(252, 24);
            this.PayStMoneyKindCd9RF_tEdit.TabIndex = 714;
            this.PayStMoneyKindCd9RF_tEdit.TabStop = false;
            this.PayStMoneyKindCd9RF_tEdit.Tag = "117";
            this.PayStMoneyKindCd9RF_tEdit.Visible = false;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(31, 279);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 19;
            this.Renewal_Button.Tag = "210";
            this.Renewal_Button.Text = "�ŐV���(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // SFSIR09020UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(422, 363);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.PayStMoneyKindCd10RF_tEdit);
            this.Controls.Add(this.PayStMoneyKindCd9RF_tEdit);
            this.Controls.Add(this.PayStMoneyKindCd9RF_Label);
            this.Controls.Add(this.PayStMoneyKindCd9RF_tNedit);
            this.Controls.Add(this.PayStMoneyKindCd9RF_tUltraBtn);
            this.Controls.Add(this.PayStMoneyKindCd10RF_Label);
            this.Controls.Add(this.PayStMoneyKindCd10RF_tNedit);
            this.Controls.Add(this.PayStMoneyKindCd10RF_tUltraBtn);
            this.Controls.Add(this.InitSelMoneyKindCdRF_tUltraBtn);
            this.Controls.Add(this.InitSelMoneyKindCdRF_tEdit);
            this.Controls.Add(this.InitSelMoneyKindCdRF_tNedit);
            this.Controls.Add(this.InitSelMoneyKindCdRF_Label);
            this.Controls.Add(this.PayStMoneyKindCd1RF_tUltraBtn);
            this.Controls.Add(this.PayStMoneyKindCd8RF_Label);
            this.Controls.Add(this.PayStMoneyKindCd8RF_tNedit);
            this.Controls.Add(this.PayStMoneyKindCd7RF_tNedit);
            this.Controls.Add(this.PayStMoneyKindCd6RF_tNedit);
            this.Controls.Add(this.PayStMoneyKindCd5RF_tNedit);
            this.Controls.Add(this.PayStMoneyKindCd4RF_tNedit);
            this.Controls.Add(this.PayStMoneyKindCd3RF_tNedit);
            this.Controls.Add(this.PayStMoneyKindCd2RF_tNedit);
            this.Controls.Add(this.PayStMoneyKindCd1RF_tNedit);
            this.Controls.Add(this.PayStMoneyKindCd8RF_tEdit);
            this.Controls.Add(this.PayStMoneyKindCd7RF_tEdit);
            this.Controls.Add(this.PayStMoneyKindCd6RF_tEdit);
            this.Controls.Add(this.PayStMoneyKindCd5RF_tEdit);
            this.Controls.Add(this.PayStMoneyKindCd4RF_tEdit);
            this.Controls.Add(this.PayStMoneyKindCd3RF_tEdit);
            this.Controls.Add(this.PayStMoneyKindCd2RF_tEdit);
            this.Controls.Add(this.PayStMoneyKindCd1RF_tEdit);
            this.Controls.Add(this.PayStMoneyKindCd7RF_Label);
            this.Controls.Add(this.PayStMoneyKindCd6RF_Label);
            this.Controls.Add(this.PayStMoneyKindCd5RF_Label);
            this.Controls.Add(this.PayStMoneyKindCd4RF_Label);
            this.Controls.Add(this.PayStMoneyKindCd3RF_Label);
            this.Controls.Add(this.PayStMoneyKindCd2RF_Label);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.PayStMoneyKindCd1RF_Label);
            this.Controls.Add(this.PayStMoneyKindCdRF_Label);
            this.Controls.Add(this.PayStMoneyKindCd2RF_tUltraBtn);
            this.Controls.Add(this.PayStMoneyKindCd3RF_tUltraBtn);
            this.Controls.Add(this.PayStMoneyKindCd4RF_tUltraBtn);
            this.Controls.Add(this.PayStMoneyKindCd5RF_tUltraBtn);
            this.Controls.Add(this.PayStMoneyKindCd6RF_tUltraBtn);
            this.Controls.Add(this.PayStMoneyKindCd7RF_tUltraBtn);
            this.Controls.Add(this.PayStMoneyKindCd8RF_tUltraBtn);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFSIR09020UA";
            this.Text = "�x���ݒ�";
            this.Load += new System.EventHandler(this.SFSIR09020UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFSIR09020UA_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SFSIR09020UA_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd1RF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd2RF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd4RF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd3RF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd8RF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd7RF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd6RF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd5RF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd1RF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd2RF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd3RF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd4RF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd5RF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd6RF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd7RF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd8RF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InitSelMoneyKindCdRF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InitSelMoneyKindCdRF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd10RF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd9RF_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd10RF_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayStMoneyKindCd9RF_tEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion

		# region Events
		/// <summary>
		/// ��ʔ�\���C�x���g
		/// ��ʂ���\����ԂɂȂ����ۂɔ������܂��B
		/// </summary>
		public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		#region Private Members
		private PaymentSet paymentSet;
		private PaymentSet _paymentSetClone;	// ��r�pClone
		private PaymentSetAcs paymentSetAcs;
		private string enterpriseCode;
		private int payStMngNo = 0;				// �x���ݒ�Ǘ�No�F0�Œ�
////////////////////////////////////////////// 2005.06.20 TERASAKA ADD STA //
		// �ύX�t���O
		private bool _changeFlg = false;
// 2005.06.20 TERASAKA ADD END //////////////////////////////////////////////

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
		// �S�R���g���[���i�[�p
		private Hashtable _controlTable = null;
		// ����f�[�^�i�[�p
		private MoneyKindAcs _moneyKindAcs;
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canClose;

		// ��ʐ���p
		private ArrayList tneditCompList;
		private ArrayList teditCompList;

		private const string HTML_HEADER_TITLE = "�ݒ荀��";
		private const string HTML_HEADER_VALUE = "�ݒ�l";
		private const string HTML_UNREGISTER = "���ݒ�";

		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";
		private const string DELETE_MODE = "�폜���[�h";

        // �ҏW�O�̃R�[�h�ۑ��p
        private string _cachedValue = string.Empty;
        private bool _continueFlag = true;


        // �ҏW�O�̃R�[�h
        private string _cache1 = string.Empty;
        private string _cache2 = string.Empty;
        private string _cache3 = string.Empty;
        private string _cache4 = string.Empty;
        private string _cache5 = string.Empty;
        private string _cache6 = string.Empty;
        private string _cache7 = string.Empty;
        private string _cache8 = string.Empty;
        private string _cache9 = string.Empty;
        private string _cache10 = string.Empty;

		#endregion
		
		# region Main
		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFSIR09020UA());
		}
		# endregion

		# region Properties
		/// <summary>
		/// ����v���p�e�B
		/// </summary>
		/// <remarks>
		/// ����\���ǂ����̐ݒ���擾���܂��B�ifalse�Œ�j
		/// </remarks>
		public bool CanPrint
		{
			get{ return _canPrint; }
		}

		/// <summary>
		/// ��ʃN���[�Y�v���p�e�B
		/// </summary>
		/// <remarks>
		/// ��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B
		/// false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B
		/// </remarks>
		public bool CanClose
		{
			get{ return _canClose; }
			set{ _canClose = value; }
		}
		# endregion

		# region Public Methods
		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �i�������j</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public int Print()
		{
			// ����p�A�Z���u�������[�h����i�������j
			return 0;
		}

		/// <summary>
		/// HTML�R�[�h�擾����
		/// </summary>
		/// <returns>HTML�R�[�h</returns>
		/// <remarks>
		/// <br>Note       : �r���[�p�̂g�s�l�k�R�[�h���擾���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public string GetHtmlCode() 
		{
			string outCode = "";

			// tHtmlGenerate���i�̈����𐶐�����
// 2006.06.09  EMI Del			string [,] array = new string[10, 2];
            //string[,] array = new string[11, 2];      // 2006.06.09  EMI Add
            string[,] array = new string[9, 2];      // 2006.06.09  EMI Add

			this.tHtmlGenerate1.Coltypes = new int[2]; 

			this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
			this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;

			// �e�[�u���^�C�g��
			array[0, 0] = HTML_HEADER_TITLE;
			array[0, 1] = HTML_HEADER_VALUE;

            //if (this.Controls.Count != 0)
            //{
            //    for (int i=0; i < this.Controls.Count; i++)
            //    {
					// �ݒ荀�ڃ^�C�g��
                    //if (this.Controls[i] is UltraLabel)
                    //{
                    //    UltraLabel tLabel = (UltraLabel)this.Controls[i];
                    //    if (tLabel.Tag.ToString().Trim().Length > 0)
                    //    {
                            //int labelTag = Convert.ToInt16(tLabel.Tag);
                            //if (labelTag == 0)
                            //{
                            //    //2006.06.09  EMI Del		array[1, 0] = "�����\���V�X�e��";
                            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA MODIFY START
                            //    array[1, 0] = "�����I������R�[�h";         //2006.06.09  EMI Add
                            //    //array[2, 0] = "�����I������R�[�h";         //2006.06.09  EMI Add
                            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA MODIFY END
                            //}
                            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
                            ////2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            ////else if (labelTag == 0)
                            ////{
                            ////array[1, 0] = "�x���`�[�ďo����";
                            ////}
                            ////2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
                            //else if (labelTag != 0)
                            //{
                            //    //2006.06.09�@EMI Del							array[labelTag, 0] = "�x���ݒ����R�[�h " + tLabel.Text;
                            //    //array[labelTag + 1, 0] = "�x���ݒ����R�[�h " + tLabel.Text;
                            //    array[labelTag, 0] = "�x���ݒ����R�[�h " + tLabel.Text;
                            //}

                    //    }
                    //}
            //    }
            //}

            // ���I�������Ă����ʂȂ̂ŌŒ�쐬
            //array[1, 0] = "�����I������R�[�h";
            array[1, 0] = "�x���ݒ����R�[�h�P";
            array[2, 0] = "�x���ݒ����R�[�h�Q";
            array[3, 0] = "�x���ݒ����R�[�h�R";
            array[4, 0] = "�x���ݒ����R�[�h�S";
            array[5, 0] = "�x���ݒ����R�[�h�T";
            array[6, 0] = "�x���ݒ����R�[�h�U";
            array[7, 0] = "�x���ݒ����R�[�h�V";
            array[8, 0] = "�x���ݒ����R�[�h�W";
            //array[9, 0] = "�x���ݒ����R�[�h�X";
            //array[10, 0] = "�x���ݒ����R�[�h�P�O";

			// �x���ݒ�e�[�u���Ǎ�
			int status = this.paymentSetAcs.Read(out this.paymentSet, this.enterpriseCode, this.payStMngNo);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
//2006.06.09  EMI Del>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //    // �擾�������e���Z�b�g
            //    // �����\���V�X�e��
            //    array[1, 1] = this.paymentSet.PayInitSystemNm;
  			
            //    // �x���ݒ����R�[�h
            //    if (this.paymentSet.PayStMoneyKindCd1 != 0)
            //    {
            //        array[2, 1] = this.paymentSet.PayStMoneyKindNm1;
            //    }
            //    if (this.paymentSet.PayStMoneyKindCd2 != 0)
            //    {
            //        array[3, 1] = this.paymentSet.PayStMoneyKindNm2;
            //    }
            //    if (this.paymentSet.PayStMoneyKindCd3 != 0)
            //    {
            //        array[4, 1] = this.paymentSet.PayStMoneyKindNm3;
            //    }
            //    if (this.paymentSet.PayStMoneyKindCd4 != 0)
            //    {
            //        array[5, 1] = this.paymentSet.PayStMoneyKindNm4;
            //    }
            //    if (this.paymentSet.PayStMoneyKindCd5 != 0)
            //    {
            //        array[6, 1] = this.paymentSet.PayStMoneyKindNm5;
            //    }
            //    if (this.paymentSet.PayStMoneyKindCd6 != 0)
            //    {
            //        array[7, 1] = this.paymentSet.PayStMoneyKindNm6;
            //    }
            //    if (this.paymentSet.PayStMoneyKindCd7 != 0)
            //    {
            //        array[8, 1] = this.paymentSet.PayStMoneyKindNm7;
            //    }
            //    if (this.paymentSet.PayStMoneyKindCd8 != 0)
            //    {
            //        array[9, 1] = this.paymentSet.PayStMoneyKindNm8;
            //    }
            //}
//2006.06.09  EMI Del<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
//2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
				// �擾�������e���Z�b�g

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
                // �x���`�[�ďo����
                //array[1, 1] = this.paymentSet.PaySlipCallMonths.ToString();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA MODIFY START

                //// �����I������R�[�h
                //if (this.paymentSet.InitSelMoneyKindCd != 0)
                //{
                //    array[1, 1] = this.paymentSet.InitSelMoneyKindNm;
                //}
    			

				// �x���ݒ����R�[�h
				if (this.paymentSet.PayStMoneyKindCd1 != 0)
				{
					array[1, 1] = this.paymentSet.PayStMoneyKindNm1;
				}
				if (this.paymentSet.PayStMoneyKindCd2 != 0)
				{
					array[2, 1] = this.paymentSet.PayStMoneyKindNm2;
				}
				if (this.paymentSet.PayStMoneyKindCd3 != 0)
				{
					array[3, 1] = this.paymentSet.PayStMoneyKindNm3;
				}
				if (this.paymentSet.PayStMoneyKindCd4 != 0)
				{
					array[4, 1] = this.paymentSet.PayStMoneyKindNm4;
				}
				if (this.paymentSet.PayStMoneyKindCd5 != 0)
				{
					array[5, 1] = this.paymentSet.PayStMoneyKindNm5;
				}
				if (this.paymentSet.PayStMoneyKindCd6 != 0)
				{
					array[6, 1] = this.paymentSet.PayStMoneyKindNm6;
				}
				if (this.paymentSet.PayStMoneyKindCd7 != 0)
				{
					array[7, 1] = this.paymentSet.PayStMoneyKindNm7;
				}
				if (this.paymentSet.PayStMoneyKindCd8 != 0)
				{
					array[8, 1] = this.paymentSet.PayStMoneyKindNm8;
				}
                //if (this.paymentSet.PayStMoneyKindCd9 != 0)
                //{
                //    array[9, 1] = this.paymentSet.PayStMoneyKindNm9;
                //}
                //if (this.paymentSet.PayStMoneyKindCd10 != 0)
                //{
                //    array[10, 1] = this.paymentSet.PayStMoneyKindNm10;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA MODIFY END

			}
//2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			// �u���ݒ�v���Z�b�g
			for (int ix = 1; ix <  array.GetLength(0); ix++)
			{
				for (int iy = 1; iy <  array.GetLength(1); iy++)
				{
					if (array[ix, iy] == null)
					{
						//array[ix, iy] = HTML_UNREGISTER;        //2006.06.09  EMI Del
                        array[ix, iy] = "";                       //2006.06.09  EMI Add     �u���ݒ�v���󔒂ɕύX
                    }
				}
			}

			// �f�[�^�̂Q�����z��݂̂��w�肵�āA�v���p�e�B���g�p���ăO���b�h�\������
			this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array,ref outCode);

			return outCode;
		}
		# endregion
        
		# region private Methods
		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
        private void ScreenInitialSetting()
        {
//2006.06.09  EMI Del>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// �����\���V�X�e���R���{�{�b�N�X
            //PayInitSystemDivRF_tComboEditor.Items.Clear();
            //PayInitSystemDivRF_tComboEditor.Items.Add(1, "����");
            //PayInitSystemDivRF_tComboEditor.Items.Add(2, "���");
            //PayInitSystemDivRF_tComboEditor.Items.Add(3, "�Ԕ�");
            //PayInitSystemDivRF_tComboEditor.MaxDropDownItems = PayInitSystemDivRF_tComboEditor.Items.Count;
//2006.06.09  EMI Del<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


           // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //PaySlipCallMonthsRF_tNedit.Text = "" ;     //2006.06.09  EMI Add
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
        }

		/// <summary>
		/// �x���ݒ�N���X�f�[�^�i�[�����i��ʏ��ˎx���ݒ�N���X�j
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʏ�񂩂�x���ݒ�N���X�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private void ScreenToPaymentSet()
		{
/*
			if (this.paymentSet == null)
			{
				// �V�K�̏ꍇ
				this.paymentSet = new PaymentSet();

				// ��ƃR�[�h
				this.paymentSet.EnterpriseCode = this.enterpriseCode;
				// �x���ݒ�Ǘ�No 0�Œ�
				this.paymentSet.PayStMngNo = this.payStMngNo;
				// �x�������\����ʔԍ� 1:�ꊇ
				this.paymentSet.PayInitDspScrNumber = 1;
				// �x���\�����ݒ� 0:���t��
				this.paymentSet.DspOrderOfPaySt = 0;
				// �x���ꊇ��������R�[�h
				this.paymentSet.LumpSumMoneyKindCd = 1;
			}
*/
			// �����\���V�X�e��
            //2006.06.09  EMI Del			this.paymentSet.PayInitSystemDiv = Convert.ToInt32(PayInitSystemDivRF_tComboEditor.SelectedItem.DataValue);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
//2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // �x���`�[�ďo����
            //this.paymentSet.PaySlipCallMonths = PaySlipCallMonthsRF_tNedit.GetInt();
//2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

			// �x���ݒ����R�[�h
			this.paymentSet.PayStMoneyKindCd1 = PayStMoneyKindCd1RF_tNedit.GetInt();
			this.paymentSet.PayStMoneyKindCd2 = PayStMoneyKindCd2RF_tNedit.GetInt();
			this.paymentSet.PayStMoneyKindCd3 = PayStMoneyKindCd3RF_tNedit.GetInt();
			this.paymentSet.PayStMoneyKindCd4 = PayStMoneyKindCd4RF_tNedit.GetInt();
			this.paymentSet.PayStMoneyKindCd5 = PayStMoneyKindCd5RF_tNedit.GetInt();
			this.paymentSet.PayStMoneyKindCd6 = PayStMoneyKindCd6RF_tNedit.GetInt();
			this.paymentSet.PayStMoneyKindCd7 = PayStMoneyKindCd7RF_tNedit.GetInt();
			this.paymentSet.PayStMoneyKindCd8 = PayStMoneyKindCd8RF_tNedit.GetInt();
            //2006.06.09  EMI Del			this.paymentSet.PayStMoneyKindCd9 = 0;			// ��������0������
            this.paymentSet.PayStMoneyKindCd9 = PayStMoneyKindCd9RF_tNedit.GetInt();		// 2006.06.09  EMI Add
            this.paymentSet.PayStMoneyKindCd10 = PayStMoneyKindCd10RF_tNedit.GetInt();		// 2006.06.09  EMI Add
            //this.paymentSet.InitSelMoneyKindCd = InitSelMoneyKindCdRF_tNedit.GetInt();		// 2006.06.09  EMI Add

			//�x���ݒ���햼��
			this.paymentSet.PayStMoneyKindNm1 = PayStMoneyKindCd1RF_tEdit.Text.Trim();
			this.paymentSet.PayStMoneyKindNm2 = PayStMoneyKindCd2RF_tEdit.Text.Trim();
			this.paymentSet.PayStMoneyKindNm3 = PayStMoneyKindCd3RF_tEdit.Text.Trim();
			this.paymentSet.PayStMoneyKindNm4 = PayStMoneyKindCd4RF_tEdit.Text.Trim();
			this.paymentSet.PayStMoneyKindNm5 = PayStMoneyKindCd5RF_tEdit.Text.Trim();
			this.paymentSet.PayStMoneyKindNm6 = PayStMoneyKindCd6RF_tEdit.Text.Trim();
			this.paymentSet.PayStMoneyKindNm7 = PayStMoneyKindCd7RF_tEdit.Text.Trim();
			this.paymentSet.PayStMoneyKindNm8 = PayStMoneyKindCd8RF_tEdit.Text.Trim();
            //2006.06.09  EMI Del			this.paymentSet.PayStMoneyKindNm9 = null;		// ��������null������
            this.paymentSet.PayStMoneyKindNm9 = PayStMoneyKindCd9RF_tEdit.Text.Trim();		// 2006.06.09  EMI Add
            this.paymentSet.PayStMoneyKindNm10 = PayStMoneyKindCd10RF_tEdit.Text.Trim();		// 2006.06.09  EMI Add
            //this.paymentSet.InitSelMoneyKindNm = InitSelMoneyKindCdRF_tEdit.Text.Trim();		// 2006.06.09  EMI Add

		}

		/// <summary>
		///	�x���ݒ�N���X�f�[�^�W�J�����i�x���ݒ�N���X�ˉ�ʏ��j
		/// </summary>
		/// <remarks>
		/// <br>Note       : �x���ݒ�N���X�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private void PaymentSetToScreen()
		{
			// �����\���V�X�e��
            //2006.06.09  EMI Del		PayInitSystemDivRF_tComboEditor.SelectedIndex = this.paymentSet.PayInitSystemDiv -1;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
//2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // �x���`�[�ďo����
            //PaySlipCallMonthsRF_tNedit.SetInt(this.paymentSet.PaySlipCallMonths);
//2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

			// �x���ݒ����R�[�h
			if (this.paymentSet.PayStMoneyKindCd1 != 0)
			{
				PayStMoneyKindCd1RF_tNedit.SetInt(this.paymentSet.PayStMoneyKindCd1);
				PayStMoneyKindCd1RF_tEdit.Text = this.paymentSet.PayStMoneyKindNm1;
			}
			else
			{
				PayStMoneyKindCd1RF_tNedit.Clear();
				PayStMoneyKindCd1RF_tEdit.Clear();
			}
			if (this.paymentSet.PayStMoneyKindCd2 != 0)
			{
				PayStMoneyKindCd2RF_tNedit.SetInt(this.paymentSet.PayStMoneyKindCd2);
				PayStMoneyKindCd2RF_tEdit.Text = this.paymentSet.PayStMoneyKindNm2;
			}
			else
			{
				PayStMoneyKindCd2RF_tNedit.Clear();
				PayStMoneyKindCd2RF_tEdit.Clear();
			}
			if (this.paymentSet.PayStMoneyKindCd3 != 0)
			{
				PayStMoneyKindCd3RF_tNedit.SetInt(this.paymentSet.PayStMoneyKindCd3);
				PayStMoneyKindCd3RF_tEdit.Text = this.paymentSet.PayStMoneyKindNm3;
			}
			else
			{
				PayStMoneyKindCd3RF_tNedit.Clear();
				PayStMoneyKindCd3RF_tEdit.Clear();
			}
			if (this.paymentSet.PayStMoneyKindCd4 != 0)
			{
				PayStMoneyKindCd4RF_tNedit.SetInt(this.paymentSet.PayStMoneyKindCd4);
				PayStMoneyKindCd4RF_tEdit.Text = this.paymentSet.PayStMoneyKindNm4;
			}
			else
			{
				PayStMoneyKindCd4RF_tNedit.Clear();
				PayStMoneyKindCd4RF_tEdit.Clear();
			}
			if (this.paymentSet.PayStMoneyKindCd5 != 0)
			{
				PayStMoneyKindCd5RF_tNedit.SetInt(this.paymentSet.PayStMoneyKindCd5);
				PayStMoneyKindCd5RF_tEdit.Text = this.paymentSet.PayStMoneyKindNm5;
			}
			else
			{
				PayStMoneyKindCd5RF_tNedit.Clear();
				PayStMoneyKindCd5RF_tEdit.Clear();
			}
			if (this.paymentSet.PayStMoneyKindCd6 != 0)
			{
				PayStMoneyKindCd6RF_tNedit.SetInt(this.paymentSet.PayStMoneyKindCd6);
				PayStMoneyKindCd6RF_tEdit.Text = this.paymentSet.PayStMoneyKindNm6;
			}
			else
			{
				PayStMoneyKindCd6RF_tNedit.Clear();
				PayStMoneyKindCd6RF_tEdit.Clear();
			}
			if (this.paymentSet.PayStMoneyKindCd7 != 0)
			{
				PayStMoneyKindCd7RF_tNedit.SetInt(this.paymentSet.PayStMoneyKindCd7);
				PayStMoneyKindCd7RF_tEdit.Text = this.paymentSet.PayStMoneyKindNm7;
			}
			else
			{
				PayStMoneyKindCd7RF_tNedit.Clear();
				PayStMoneyKindCd7RF_tEdit.Clear();
			}
			if (this.paymentSet.PayStMoneyKindCd8 != 0)
			{
				PayStMoneyKindCd8RF_tNedit.SetInt(this.paymentSet.PayStMoneyKindCd8);
				PayStMoneyKindCd8RF_tEdit.Text = this.paymentSet.PayStMoneyKindNm8;
			}
			else
			{
				PayStMoneyKindCd8RF_tNedit.Clear();
				PayStMoneyKindCd8RF_tEdit.Clear();
			} 
//2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            if (this.paymentSet.PayStMoneyKindCd9 != 0)
            { 
                PayStMoneyKindCd9RF_tNedit.SetInt(this.paymentSet.PayStMoneyKindCd9);
                PayStMoneyKindCd9RF_tEdit.Text = this.paymentSet.PayStMoneyKindNm9;
            }
            else
            {
                PayStMoneyKindCd9RF_tNedit.Clear();
                PayStMoneyKindCd9RF_tEdit.Clear(); 
            }
            if (this.paymentSet.PayStMoneyKindCd10 != 0)
            {
                PayStMoneyKindCd10RF_tNedit.SetInt(this.paymentSet.PayStMoneyKindCd10);
                PayStMoneyKindCd10RF_tEdit.Text = this.paymentSet.PayStMoneyKindNm10;
            }
            else
            {
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
            //if (this.paymentSet.InitSelMoneyKindCd != 0)
            //{
            //    InitSelMoneyKindCdRF_tNedit.SetInt(this.paymentSet.InitSelMoneyKindCd);
            //    InitSelMoneyKindCdRF_tEdit.Text = this.paymentSet.InitSelMoneyKindNm;
            //}
            //else
            //{
            //    InitSelMoneyKindCdRF_tNedit.Clear();
            //    InitSelMoneyKindCdRF_tEdit.Clear();
            //}
//2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		}

		/// <summary>
		/// ��ʏ���������
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏��������s���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private void ScreenClear()
		{
			// �����\���V�X�e��
            //2006.06.09  EMI Del			PayInitSystemDivRF_tComboEditor.SelectedIndex = 0;

//2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            // �x���`�[�ďo����
            //PaySlipCallMonthsRF_tNedit.Clear();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
            
            //// �����I������R�[�h
            //InitSelMoneyKindCdRF_tNedit.Clear();�@�@�@
            //InitSelMoneyKindCdRF_tEdit.Clear();�@�@�@ 
//2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			// �x���ݒ����R�[�h
			PayStMoneyKindCd1RF_tNedit.Clear(); 
			PayStMoneyKindCd2RF_tNedit.Clear();
			PayStMoneyKindCd3RF_tNedit.Clear();
			PayStMoneyKindCd4RF_tNedit.Clear();
			PayStMoneyKindCd5RF_tNedit.Clear();
			PayStMoneyKindCd6RF_tNedit.Clear();
			PayStMoneyKindCd7RF_tNedit.Clear();
			PayStMoneyKindCd8RF_tNedit.Clear();
			PayStMoneyKindCd9RF_tNedit.Clear();�@�@�@ �@//2006.06.09  EMI Add
            PayStMoneyKindCd10RF_tNedit.Clear();�@�@�@�@//2006.06.09  EMI Add

			// �x���ݒ���햼��
			PayStMoneyKindCd1RF_tEdit.Clear();
			PayStMoneyKindCd2RF_tEdit.Clear();
			PayStMoneyKindCd3RF_tEdit.Clear();
			PayStMoneyKindCd4RF_tEdit.Clear();
			PayStMoneyKindCd5RF_tEdit.Clear();
			PayStMoneyKindCd6RF_tEdit.Clear();
			PayStMoneyKindCd7RF_tEdit.Clear();
			PayStMoneyKindCd8RF_tEdit.Clear();
            PayStMoneyKindCd9RF_tEdit.Clear();          //2006.06.09  EMI Add
            PayStMoneyKindCd10RF_tEdit.Clear();         //2006.06.09  EMI Add

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.01.13 TAKAHASHI ADD START
			// �ύX�t���O
			this._changeFlg = false;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.01.13 TAKAHASHI ADD END
		}

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			int status = paymentSetAcs.Read(out this.paymentSet, this.enterpriseCode, this.payStMngNo);
			if (status == 0)
			{
				Mode_Label.Text = UPDATE_MODE;

				// �x���ݒ�N���X��ʓW�J����
				PaymentSetToScreen();

                // ��ʏ�̐ݒ�
                EnableMonKindCodeFields(true, 0, true);
			}
			else
			{
				Mode_Label.Text = INSERT_MODE;

				// �f�[�^�N���X�V�K�쐬
				this.paymentSet = new PaymentSet();
				// ��ƃR�[�h
				this.paymentSet.EnterpriseCode = this.enterpriseCode;
				// �x���ݒ�Ǘ�No 0�Œ�
				this.paymentSet.PayStMngNo = this.payStMngNo;
				// �x�������\����ʔԍ� 1:�ꊇ
                //2006.06.09  EMI Del			this.paymentSet.PayInitDspScrNumber = 1;
				// �x���\�����ݒ� 0:���t��
                //2006.06.09  EMI Del			this.paymentSet.DspOrderOfPaySt = 0;
				// �x���ꊇ��������R�[�h
                //2006.06.09  EMI Del			this.paymentSet.LumpSumMoneyKindCd = 1;
			}

			// �x���ݒ�N���X�f�[�^�i�[
			ScreenToPaymentSet();
			// ���ύX��r�p�N���[���쐬
			this._paymentSetClone = this.paymentSet.Clone();
		}

		/// <summary>
		/// �x���ݒ��ʓ��̓`�F�b�N����
		/// </summary>
		/// <param name="checkMessage">�G���[���b�Z�[�W</param>
		/// <returns>�G���[�R�[�h</returns>
		/// <remarks>
		/// <br>Note       : �x���ݒ��ʂ̓��̓`�F�b�N�����܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private int checkDisplay(ref string checkMessage)
		{
			int returnStatus = 0;
			int compIndex = 0;
			try
			{
//2006.06.09  EMI Del>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //// �����\���V�X�e��
                //// �R���{�{�b�N�X�͕K���ݒ肷��
                //if (this.PayInitSystemDivRF_tComboEditor.SelectedIndex < 0)
                //{
                //    checkMessage = "�����\���V�X�e�������I���ł��B";
                //    returnStatus = 10;
                //    return returnStatus;
                //}
//2006.06.09  EMI Del<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                // ���o�^���Ȃ���(�ϊ����ɖ��o�^�`�F�b�N�����Ă���̂Ŋ�{�I�ɂ͂Ȃ�)
                checkMessage = "���o�^�̃R�[�h�͓o�^�ł��܂���B";
                //returnStatus = 11;
                if (this.PayStMoneyKindCd1RF_Label.Text == "���o�^")
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd2RF_Label.Text == "���o�^")
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd3RF_Label.Text == "���o�^")
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd4RF_Label.Text == "���o�^")
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd5RF_Label.Text == "���o�^")
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd6RF_Label.Text == "���o�^")
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd7RF_Label.Text == "���o�^")
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd8RF_Label.Text == "���o�^")
                {
                    return 11;
                }
                // 2008.11.18 add start [7900]
                checkMessage = "����R�[�h��0�͓o�^�ł��܂���B";
                //returnStatus = 11;
                if (this.PayStMoneyKindCd1RF_tNedit.Text.Trim().Equals("0") || this.PayStMoneyKindCd1RF_tNedit.Text.Trim().Equals("00"))
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd2RF_tNedit.Text.Trim().Equals("0") || this.PayStMoneyKindCd2RF_tNedit.Text.Trim().Equals("00"))
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd3RF_tNedit.Text.Trim().Equals("0") || this.PayStMoneyKindCd3RF_tNedit.Text.Trim().Equals("00"))
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd4RF_tNedit.Text.Trim().Equals("0") || this.PayStMoneyKindCd4RF_tNedit.Text.Trim().Equals("00"))
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd5RF_tNedit.Text.Trim().Equals("0") || this.PayStMoneyKindCd5RF_tNedit.Text.Trim().Equals("00"))
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd6RF_tNedit.Text.Trim().Equals("0") || this.PayStMoneyKindCd6RF_tNedit.Text.Trim().Equals("00"))
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd7RF_tNedit.Text.Trim().Equals("0") || this.PayStMoneyKindCd7RF_tNedit.Text.Trim().Equals("00"))
                {
                    return 11;
                }
                if (this.PayStMoneyKindCd8RF_tNedit.Text.Trim().Equals("0") || this.PayStMoneyKindCd8RF_tNedit.Text.Trim().Equals("00"))
                {
                    return 11;
                }
                // 2008.11.18 add end [7900]
                //if (this.PayStMoneyKindCd9RF_Label.Text == "���o�^")
                //{
                //    return 11;
                //}
                //if (this.PayStMoneyKindCd10RF_Label.Text == "���o�^")
                //{
                //    return 11;
                //}
                checkMessage = string.Empty;

                // ����Ȃ�
                if (String.IsNullOrEmpty(this.PayStMoneyKindCd1RF_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.PayStMoneyKindCd2RF_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.PayStMoneyKindCd3RF_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.PayStMoneyKindCd4RF_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.PayStMoneyKindCd5RF_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.PayStMoneyKindCd6RF_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.PayStMoneyKindCd7RF_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.PayStMoneyKindCd8RF_tNedit.Text.Trim())// &&
                    //String.IsNullOrEmpty(this.PayStMoneyKindCd9RF_tNedit.Text.Trim()) &&
                    //String.IsNullOrEmpty(this.PayStMoneyKindCd10RF_tNedit.Text.Trim())
                    )
                {
                    checkMessage = "�R�[�h���o�^����Ă��܂���B";
                    return 1;
                }

//2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
                // �x���`�[�ďo����
                // �K���ݒ肷��
                //if (this.PaySlipCallMonthsRF_tNedit.GetInt() == 0 )
                //{
                    //checkMessage = "�x���`�[�ďo�������ݒ肳��Ă��܂���B";
                    //returnStatus = 10;
                    //return returnStatus;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
                
                // �����I������R�[�h
                // �K���ݒ肷��
                //if (this.InitSelMoneyKindCdRF_tNedit.GetInt() == 0)
                //{
                //    checkMessage = "�����I������R�[�h���ݒ肳��Ă��܂���B";
                //    returnStatus = 20;
                //    return returnStatus;
                //}
                //2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // 2007.04.03  S.Koga  add ------------------------------------
                //int IniSelMonKiCd = this.InitSelMoneyKindCdRF_tNedit.GetInt();
                bool _iniSelMonKiCdFlg = false; 

                //// ����R�[�h�P
                //if ((this.PayStMoneyKindCd1RF_tNedit.DataText != "") && (IniSelMonKiCd == this.PayStMoneyKindCd1RF_tNedit.GetInt()))
                //{
                //    _iniSelMonKiCdFlg = true;
                //}
                //// ����R�[�h�Q
                //if ((this.PayStMoneyKindCd2RF_tNedit.DataText != "") && (IniSelMonKiCd == this.PayStMoneyKindCd2RF_tNedit.GetInt()))
                //{
                //    _iniSelMonKiCdFlg = true;
                //}
                //// ����R�[�h�R
                //if ((this.PayStMoneyKindCd3RF_tNedit.DataText != "") && (IniSelMonKiCd == this.PayStMoneyKindCd3RF_tNedit.GetInt()))
                //{
                //    _iniSelMonKiCdFlg = true;
                //}
                //// ����R�[�h�S
                //if ((this.PayStMoneyKindCd4RF_tNedit.DataText != "") && (IniSelMonKiCd == this.PayStMoneyKindCd4RF_tNedit.GetInt()))
                //{
                //    _iniSelMonKiCdFlg = true;
                //}
                //// ����R�[�h�T
                //if ((this.PayStMoneyKindCd5RF_tNedit.DataText != "") && (IniSelMonKiCd == this.PayStMoneyKindCd5RF_tNedit.GetInt()))
                //{
                //    _iniSelMonKiCdFlg = true;
                //}
                //// ����R�[�h�U
                //if ((this.PayStMoneyKindCd6RF_tNedit.DataText != "") && (IniSelMonKiCd == this.PayStMoneyKindCd6RF_tNedit.GetInt()))
                //{
                //    _iniSelMonKiCdFlg = true;
                //}
                //// ����R�[�h�V
                //if ((this.PayStMoneyKindCd7RF_tNedit.DataText != "") && (IniSelMonKiCd == this.PayStMoneyKindCd7RF_tNedit.GetInt()))
                //{
                //    _iniSelMonKiCdFlg = true;
                //}
                //// ����R�[�h�W
                //if ((this.PayStMoneyKindCd8RF_tNedit.DataText != "") && (IniSelMonKiCd == this.PayStMoneyKindCd8RF_tNedit.GetInt()))
                //{
                //    _iniSelMonKiCdFlg = true;
                //}
                //// ����R�[�h�X
                //if ((this.PayStMoneyKindCd9RF_tNedit.DataText != "") && (IniSelMonKiCd == this.PayStMoneyKindCd9RF_tNedit.GetInt()))
                //{
                //    _iniSelMonKiCdFlg = true;
                //}
                //// ����R�[�h�P�O
                //if ((this.PayStMoneyKindCd10RF_tNedit.DataText != "") && (IniSelMonKiCd == this.PayStMoneyKindCd10RF_tNedit.GetInt()))
                //{
                //    _iniSelMonKiCdFlg = true;
                //}

                //if (_iniSelMonKiCdFlg == false)
                //{
                //    checkMessage = "�x���ݒ����R�[�h�̒�����I�����Ă��������B";
                //    returnStatus = 20;
                //    return returnStatus;
                //}
                // ------------------------------------------------------------

				// �x���ݒ����R�[�h
				// �G���[���̓`�F�b�N
				for (int i = 0; i < this.tneditCompList.Count; i++)
				{
					string wrkStr = "";
					int wrkInt = ((TNedit)tneditCompList[i]).GetInt();
					
					// ���͖���
					if (wrkInt == 0)
					{
						((TEdit)teditCompList[i]).Text = wrkStr;
						continue;
					}

					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI DELETE START
//					// ����R�[�h���݃`�F�b�N
//					// �� �v�ύX /////////////////////////////////////////////////////////////////
//					switch (wrkInt)
//					{
//						case 1 :
//						{ 
//							wrkStr = "�����E���؎�";
//							break;
//						}
//						case 2 :
//						{
//							wrkStr = "�U��";
//							break;
//						}
//						case 3 :
//						{
//							wrkStr = "�N���W�b�g";
//							break;
//						}
//						case 4 :
//						{
//							wrkStr = "�萔��";
//							break;
//						}
//						case 5 :
//						{
//							wrkStr = "��`";
//							break;
//						}
//						case 6 :
//						{
//							wrkStr = "���E";
//							break;
//						}
//						case 7 :
//						{
//							wrkStr = "���̑�";
//							break;
//						}
//						case 8 :
//						{
//							wrkStr = "�l��";
//							break;
//						}
//						case 9 :
//						{
//							wrkStr = "�a���";
//							break;
//						}
//						default :
//						{
//							wrkStr = null;
//							break;
//						}
//					}
//
//					if (wrkStr != null)
//					{
//						((TEdit)teditCompList[i]).Text = wrkStr;
//					}
//					else
//					{
//					////////////////////////////////////////////// 2005.06.20 TERASAKA DEL STA //
//					//						((TEdit)teditCompList[i]).Clear();
//					//						checkMessage = "�Ώۃf�[�^�����݂��܂���";
//					// 2005.06.20 TERASAKA DEL END //////////////////////////////////////////////
//					////////////////////////////////////////////// 2005.06.20 TERASAKA ADD STA //
//											((TEdit)teditCompList[i]).Text = "���o�^";
//											checkMessage = "�}�X�^�ɓo�^����Ă��܂���B";
//					// 2005.06.20 TERASAKA ADD END //////////////////////////////////////////////
//											compIndex = i;
//											returnStatus = 100;
//											return returnStatus;
//										}
//					�� �v�ύX /////////////////////////////////////////////////////////////////

				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI DELETE END
				}

				// �d���`�F�b�N
				bool isCash = false;
				//2006.06.09  EMI Del 
                //for (int i = 0; i < this.tneditCompList.Count -1; i++)
                //2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                for (int i = 0; i < this.tneditCompList.Count; i++)
                //2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                {
                    int sourceCd = ((TNedit)tneditCompList[i]).GetInt();

					if (sourceCd == 0) continue;
					//if (sourceCd == 1) isCash = true;			// 1:���ॏ��؎肪���͂���Ă��邩�̔��f������

					for (int j = i +1; j < this.tneditCompList.Count; j++)
					{
						int destCd = ((TNedit)tneditCompList[j]).GetInt();

						//if (destCd == 1) isCash = true;			// 1:���ॏ��؎肪���͂���Ă��邩�̔��f������
						if (sourceCd == destCd)
						{
							checkMessage = "�R�[�h���d�����Ă��܂�";
							compIndex = j;
							returnStatus = 100;
							return returnStatus;
						}
					}
				}

                //// 1: ���ॏ��؎�͕K�{����
                //if (isCash == false)
                //{
                //    checkMessage = "�u1: ���ॏ��؎�v���ݒ肳��Ă��܂���";
                //    compIndex = 0;
                //    returnStatus = 100;
                //    return returnStatus;
                //}

				return returnStatus;
			}
			finally
			{
				if (returnStatus != 0)
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
                    //TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                    //    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                    //    "SFSIR09020U",							// �A�Z���u��ID
                    //    checkMessage,	                        // �\�����郁�b�Z�[�W
                    //    0,   									// �X�e�[�^�X�l
                    //    MessageBoxButtons.OK);					// �\������{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					//�G���[�X�e�[�^�X�ɍ��킹�ăt�H�[�J�X�Z�b�g
					switch(returnStatus)
					{
//2006.06.09  EMI Del>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>					
                        //case 10 :	//�����\���V�X�e��
                        //{
                        //    this.PayInitSystemDivRF_tComboEditor.Focus();
                        //    break;
                        //}
//2006.06.09  EMI Del<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
//2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>					
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
                    //case 10:	//�x���`�[�ďo����
                        //{
                            //this.PaySlipCallMonthsRF_tNedit.Focus();
                            //break;
                        //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
                    //case 20:	//�����I������R�[�h
                    //    {
                    //        //this.InitSelMoneyKindCdRF_tNedit.Focus();�@
                    //        break;
                    //    }
//2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    case 100:	//�x���ݒ����R�[�h
						{
							((TNedit)this.tneditCompList[compIndex]).Focus();
							break;
						}
					}
				}
			}
		}

		/// <summary>
		/// �x���ݒ�ۑ�����
		/// </summary>
		/// <returns>�G���[�R�[�h</returns>
		/// <remarks>
		/// <br>Note       : �x���ݒ���̕ۑ����s���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private int SavePaymentSet()
		{
			//��ʃf�[�^���̓`�F�b�N����
			string checkMessage = "";
			int chkSt = checkDisplay(ref checkMessage);
			if (chkSt != 0)
			{
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                    "�x���ݒ�", "SavePaymentSet", TMsgDisp.OPE_UPDATE,
                    checkMessage, chkSt, this.paymentSetAcs, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return 9;
			}

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
            //2006.06.09  EMI Del			for (int ix = 1 ; ix <= 8; ix++)
            //for (int ix = 1; ix <= 10; ix++)       //2006.06.09  EMI Add

            //{
            //    string name;

            //    TNedit payStMonKiCd = (TNedit)this._controlTable["PayStMoneyKindCd" + ix + "RF_tNedit"];;

            //    TEdit payStMonKiNm = (TEdit)this._controlTable["PayStMoneyKindCd" + ix + "RF_tEdit"];

            //    int statusP = PayStMonKiCdChange(out name, payStMonKiCd.GetInt());

            //    if (statusP == -1)
            //    {
            //        //payStMonKiNm.Text = name;
            //        payStMonKiCd.Text = this._cachedValue;
            //        this._cachedValue = string.Empty;
            //        payStMonKiCd.Focus();
            //        payStMonKiCd.SelectAll();
            //        return statusP;
            //    }
            //    else if (statusP !=  0)
            //    {
            //        payStMonKiNm.Text = name;
            //        payStMonKiCd.Focus();
            //        payStMonKiCd.SelectAll();
            //        return statusP;
            //    }
            //}
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END
            //2006.06.09  EMI Add >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //string initname;
            
            //TNedit initSelMonKiCd = (TNedit)this._controlTable["InitSelMoneyKindCdRF_tNedit"]; ;

            //TEdit initSelMonKiNm = (TEdit)this._controlTable["InitSelMoneyKindCdRF_tEdit"];

            //int statusI = PayStMonKiCdChange(out initname, initSelMonKiCd.GetInt());

            //if (statusI == -1)
            //{
            //    //payStMonKiNm.Text = name;
            //    initSelMonKiCd.Text = this._cachedValue;
            //    this._cachedValue = string.Empty;
            //    initSelMonKiCd.Focus();
            //    initSelMonKiCd.SelectAll();
            //    return statusI;
            //}
            //else if (statusI != 0)
            //{
            //    initSelMonKiNm.Text = initname;
            //    initSelMonKiCd.Focus();
            //    initSelMonKiCd.SelectAll();
            //    return statusI;
            //}
            //2006.06.09  EMI Add <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			// ��ʂ���x���ݒ�N���X�Ƀf�[�^���Z�b�g���܂��B
			ScreenToPaymentSet();

			// �x���ݒ�o�^����
			int status = this.paymentSetAcs.Write(ref this.paymentSet);
			// 2005.07.06 �r�����䏈���@�r�������������Ƃ��Astatus��\�����Ȃ��悤�C�� >>>>>>>>>>>>>>>>> START
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{ 
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// �r������
					ExclusiveTransaction(status);
					
					// 2005.07.11 �r�����䏈���̒��ɍŏ����Ή���ǉ� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._paymentSetClone = null;
					// 2005.07.11 �r�����䏈���̒��ɍŏ����Ή���ǉ� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

					// 2005.07.08 �G���[���b�Z�[�W���o����UI��ʂ���鏈�� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> STRAT
					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					// 2005.07.08 �G���[���b�Z�[�W���o����UI��ʂ���鏈�� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
					return status;
				}
					// 2005.07.06 �r�����䏈���@�r�������������Ƃ��Astatus��\�����Ȃ��悤�C�� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
				default:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
						"SFSIR09020U",							// �A�Z���u��ID
						"�x���ݒ�",                             // �v���O��������
						"SavePaymentSet",                       // ��������
						TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
						"�o�^�Ɏ��s���܂����B",				    // �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this.paymentSetAcs,					    // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,					// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					// 2005.07.11 �r�����䏈���̒��ɍŏ����Ή���ǉ� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._paymentSetClone = null;
					// 2005.07.11 �r�����䏈���̒��ɍŏ����Ή���ǉ� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

					// 2005.07.08 �G���[���b�Z�[�W���o����UI��ʂ���鏈�� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> STRAT
					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					// 2005.07.08 �G���[���b�Z�[�W���o����UI��ʂ���鏈�� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END	
					return status;
				}
					// 2005.07.06 �r�����䏈���@�r�������������Ƃ��Astatus��\�����Ȃ��悤�C�� >>>>>>>>>>>>>>>>> END
			}
			return 0;
		}
		

		/// <summary>
		/// �r������
		/// </summary>
		/// <param name="status">�X�e�[�^�X</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.07.12</br>
		/// </remarks>
		private void ExclusiveTransaction(int status)
		{
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
						"SFSIR09020U",							// �A�Z���u��ID
						"���ɑ��[�����X�V����Ă��܂��B",	    // �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						MessageBoxButtons.OK);					// �\������{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
						"SFSIR09020U",							// �A�Z���u��ID
						"���ɑ��[�����폜����Ă��܂��B",	    // �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						MessageBoxButtons.OK);					// �\������{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					break;
				}
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �S�R���g���[���擾����
		/// </summary>
		/// <param name="parent">��{�R���g���[��</param>
		/// <returns>�S���ʉ��w�R���g���[��</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ��{�R���g���[�����S���ʉ��w�R���g���[����Ԃ��܂��B</br>
		/// <br>Programmer	: 23006�@���� ���q</br>
		/// <br>Date		: 2005.09.24</br>
		/// </remarks>
		private Control[] GetAllControls(Control parent)
		{
			ArrayList buf = new ArrayList();

			foreach (Control control in parent.Controls)
			{
				buf.Add(control);
				buf.AddRange(GetAllControls(control));
			}

			return (Control[])buf.ToArray(typeof(Control));
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �R���|�[�l���g�e�[�u���i�[����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �R���|�[�l���g���e�[�u���ɃZ�b�g���܂��B</br>
		/// <br>Programmer	: 23006�@���� ���q</br>
		/// <br>Date		: 2005.09.24</br>
		/// </remarks>
		private void SetControlTable()
		{
			this._controlTable = new Hashtable();

			foreach (Control control in this.GetAllControls(this))
			{
				if (!this._controlTable.Contains(control.Name))
				{
					this._controlTable.Add(control.Name, control);
				}
			}
		}
		
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���햼�̕ύX����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ����R�[�h�ɂ��킹�ĕ\������Ă�����햼�̂̕ύX���s���܂��B</br>
		/// <br>Programmer	: 23006�@���� ���q</br>
		/// <br>Date		: 2005.12.20</br>
		/// </remarks>
        private int PayStMonKiCdChange(int ix, TNedit payStMoneyKindCdRF_tNedit, TEdit payStMoneyKindCdNmRF_tEdit)//out string payStMonKiName, int payStMonKiCode)
		{
			int status = 0;

			//payStMonKiName = null;

			// ����R�[�h����Ȃ�ANull��Ԃ�
            if (payStMoneyKindCdRF_tNedit.GetInt() == 0)
			{
                payStMoneyKindCdNmRF_tEdit.Text = "";
			}
			else
			{
				MoneyKind moneyKindInfo = new MoneyKind();

				// PrimaryKey�����Z�b�g
				moneyKindInfo.EnterpriseCode = this.enterpriseCode;
				moneyKindInfo.PriceStCode    = 0;
                moneyKindInfo.MoneyKindCode = payStMoneyKindCdRF_tNedit.GetInt(); //payStMonKiCode;

                //string exCode = payStMoneyKindCdRF_tNedit.Text.Trim();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.05.27 T-Kidate START
				// ���z��ʃ}�X�^�������擾
				//status = this._moneyKindAcs.Read(ref moneyKindInfo);
                moneyKindInfo.MoneyKindName = this.paymentSetAcs.GetDepsitStKindNm(this.enterpriseCode, moneyKindInfo.MoneyKindCode);
                if (moneyKindInfo.MoneyKindName == "")
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.05.27 T-Kidate END
                
                switch (status)
                {
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						if (moneyKindInfo.LogicalDeleteCode != 0)
						{
							TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
								emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
								"SFSIR09020U",							// �A�Z���u��ID
								"�}�X�^����폜����Ă��܂��B",	        // �\�����郁�b�Z�[�W
								status,									// �X�e�[�^�X�l
								MessageBoxButtons.OK);					// �\������{�^��

                            payStMoneyKindCdNmRF_tEdit.Text = "�폜��";

							status = -2;
						}
						else
						{
                            // [2008/09/19]�����ȊO�͗��Ȃ��̂ő��͖���
                            if (moneyKindInfo.MoneyKindName == "���o�^")
                            {
                                TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                                    "SFUKK09060U",							// �A�Z���u��ID
                                    "�}�X�^�ɓo�^����Ă��܂���B",	        // �\�����郁�b�Z�[�W
                                    status,									// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);					// �\������{�^��

                                //payStMoneyKindCdRF_tNedit.Clear();
                                //if (!String.IsNullOrEmpty(this._cachedValue.Trim()))
                                //{
                                //    payStMoneyKindCdRF_tNedit.Text = this._cachedValue;
                                //    //payStMoneyKindCdRF_tNedit.Text = exCode;
                                //    //this._cachedValue = string.Empty;
                                //}
                                //payStMoneyKindCdRF_tNedit.Focus();
                                //_continueFlag = false;
                                status = -2;
                            }
                            else
                            {
                                payStMoneyKindCdNmRF_tEdit.Text = moneyKindInfo.MoneyKindName;
                            }
							//payStMonKiName = moneyKindInfo.MoneyKindName;
						}

						break;
					}

					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					{
						TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
							"SFSIR09020U",							// �A�Z���u��ID
							"�}�X�^�ɓo�^����Ă��܂���B",	        // �\�����郁�b�Z�[�W
							status,									// �X�e�[�^�X�l
							MessageBoxButtons.OK);					// �\������{�^��

                        payStMoneyKindCdNmRF_tEdit.Text = "���o�^";

						break;
					}

					default:
					{
                        payStMoneyKindCdNmRF_tEdit.Text = "";

						break;
					}
				}
			}

			return status;

//			payStMonKiName = "";
//
//			int status = 0;
//						
//			MoneyKind moneyKind = null;
//
//			// ���z��ʓo�^�C���}�X�^�ǂݍ���(����̂�)
//			// �_���폜�����擾
//			if 	(this._moneyKindBuf == null)
//			{
//				status = this._moneyKindAcs.SearchAll(out _moneyKindBuf, this.enterpriseCode);
//			}			
//			
//			
//			if (payStMonKiCode != 0) 
//			{									   
//				// ���z��ʓo�^�C���}�X�^Buffer����擾
//				foreach(MoneyKind moneyKindWork in this._moneyKindBuf)
//				{
//					if (moneyKindWork.PriceStCode == 0)
//					{
//						if (moneyKindWork.MoneyKindCode == payStMonKiCode)
//						{
//							moneyKind = moneyKindWork.Clone();
//							break;
//						}
//					}
//				}
//				
//				// �Y���R�[�h�����������ꍇStatus��NotFound��ݒ�
//				if (moneyKind == null)
//				{
//					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
//				}			
//			
//				switch (status)
//				{
//					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
//					{
//						// �_���폜����Ă����ꍇ
//						if (moneyKind.LogicalDeleteCode != 0)
//						{
//							// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
//							TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
//								emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
//								"SFSIR09020U",							// �A�Z���u��ID
//								"�}�X�^����폜����Ă��܂��B",	        // �\�����郁�b�Z�[�W
//								status,									// �X�e�[�^�X�l
//								MessageBoxButtons.OK);					// �\������{�^��
//							// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END
//						
//							payStMonKiName = "�폜��";
//							status = -2;
//						
//						}
//						else
//						{
//							payStMonKiName = moneyKind.MoneyKindName.TrimEnd();
//						}
//						break;
//					}
//					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
//					{
//						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
//						TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
//							emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
//							"SFSIR09020U",							// �A�Z���u��ID
//							"�}�X�^�ɓo�^����Ă��܂���B",	        // �\�����郁�b�Z�[�W
//							status,									// �X�e�[�^�X�l
//							MessageBoxButtons.OK);					// �\������{�^��
//						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END
//				
//						payStMonKiName = "���o�^";
//						break;
//					}
//					default:
//					{
//						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
//						TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
//							emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
//							"SFSIR09020U",							// �A�Z���u��ID
//							"�x���ݒ�",                             // �v���O��������
//							"PayStMonKiCdChange",                   // ��������
//							TMsgDisp.OPE_GET,                       // �I�y���[�V����
//							"����p���̂̓ǂݍ��݂Ɏ��s���܂����B",	// �\�����郁�b�Z�[�W
//							status,									// �X�e�[�^�X�l
//							this.paymentSetAcs,					    // �G���[�����������I�u�W�F�N�g
//							MessageBoxButtons.OK,					// �\������{�^��
//							MessageBoxDefaultButton.Button1);		// �����\���{�^��
//						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END
//
//						break;
//					}
//				}
//			}
//			return status;
		}

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.07 TAKAHASHI ADD START
		/// <summary>
		/// �K�C�h�N������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �K�C�h���N�����A�I����e����ʂɓK�p���܂��B</br>
		/// <br>Programmer	: 23006	 ���� ���q</br>
		/// <br>Date		: 2005.10.07</br>
		/// </remarks>
		private void StartGuidProc(string objectName)
		{
			MoneyKind moneyKind = new MoneyKind();

            // ----- iitani c ---------- start 2007.05.23
            //MoneyKindAcs moneyKindAcs = new MoneyKindAcs();
			// ���z��ʃK�C�h
			//switch (moneyKindAcs.ExecuteGuid(this.enterpriseCode, 0, out moneyKind, "MONEYKINDGUIDEPARENT.XML"))
			switch (this._moneyKindAcs.ExecuteGuid(this.enterpriseCode, 0, out moneyKind, "MONEYKINDGUIDEPARENT.XML"))
            // ----- iitani c ---------- start 2007.05.23
            {
				case 0:
					// ���z��ʏ��ύX����
					if (objectName == "PayStMoneyKindCd1RF_tUltraBtn")
					{
                        this.PayStMoneyKindCd1RF_tNedit.SetInt(moneyKind.MoneyKindCode);
                        this.PayStMoneyKindCd1RF_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache1 = moneyKind.MoneyKindCode.ToString();
                        EnableMonKindCodeFields(false, 2, true);
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
                        this.PayStMoneyKindCd2RF_tNedit.Focus();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "PayStMoneyKindCd2RF_tUltraBtn")
					{
						this.PayStMoneyKindCd2RF_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.PayStMoneyKindCd2RF_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache2 = moneyKind.MoneyKindCode.ToString();
                        EnableMonKindCodeFields(false, 3, true);
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.PayStMoneyKindCd3RF_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "PayStMoneyKindCd3RF_tUltraBtn")
					{
						this.PayStMoneyKindCd3RF_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.PayStMoneyKindCd3RF_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache3 = moneyKind.MoneyKindCode.ToString();
                        EnableMonKindCodeFields(false, 4, true);
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.PayStMoneyKindCd4RF_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "PayStMoneyKindCd4RF_tUltraBtn")
					{
						this.PayStMoneyKindCd4RF_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.PayStMoneyKindCd4RF_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache4 = moneyKind.MoneyKindCode.ToString();
                        EnableMonKindCodeFields(false, 5, true);
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.PayStMoneyKindCd5RF_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "PayStMoneyKindCd5RF_tUltraBtn")
					{
						this.PayStMoneyKindCd5RF_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.PayStMoneyKindCd5RF_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache5 = moneyKind.MoneyKindCode.ToString();
                        EnableMonKindCodeFields(false, 6, true);
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.PayStMoneyKindCd6RF_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "PayStMoneyKindCd6RF_tUltraBtn")
					{
						this.PayStMoneyKindCd6RF_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.PayStMoneyKindCd6RF_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache6 = moneyKind.MoneyKindCode.ToString();
                        EnableMonKindCodeFields(false, 7, true);
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.PayStMoneyKindCd7RF_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "PayStMoneyKindCd7RF_tUltraBtn")
					{
						this.PayStMoneyKindCd7RF_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.PayStMoneyKindCd7RF_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache7 = moneyKind.MoneyKindCode.ToString();
                        EnableMonKindCodeFields(false, 8, true);
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.PayStMoneyKindCd8RF_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "PayStMoneyKindCd8RF_tUltraBtn")
					{
                        this.PayStMoneyKindCd8RF_tNedit.SetInt(moneyKind.MoneyKindCode);
                        this.PayStMoneyKindCd8RF_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache8 = moneyKind.MoneyKindCode.ToString();
                        EnableMonKindCodeFields(false, 9, true);
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
                        //this.Ok_Button.Focus();
                        this.PayStMoneyKindCd9RF_tNedit.Focus();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

                    //2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    if (objectName == "PayStMoneyKindCd9RF_tUltraBtn")
                    {
                        this.PayStMoneyKindCd9RF_tNedit.SetInt(moneyKind.MoneyKindCode);
                        this.PayStMoneyKindCd9RF_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache9 = moneyKind.MoneyKindCode.ToString();
                        this.PayStMoneyKindCd9RF_tNedit.Focus();
                        EnableMonKindCodeFields(false, 10, true);
                        this.PayStMoneyKindCd10RF_tNedit.Focus();
                    }

                    if (objectName == "PayStMoneyKindCd10RF_tUltraBtn")
                    {
                        this.PayStMoneyKindCd10RF_tNedit.SetInt(moneyKind.MoneyKindCode);
                        this.PayStMoneyKindCd10RF_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache10 = moneyKind.MoneyKindCode.ToString();
                        this.Ok_Button.Focus();
                    }

                    //if (objectName == "InitSelMoneyKindCdRF_tUltraBtn")
                    //{
                    //    this.InitSelMoneyKindCdRF_tNedit.SetInt(moneyKind.MoneyKindCode);
                    //    this.InitSelMoneyKindCdRF_tEdit.Text = moneyKind.MoneyKindName;
                    //    this.Ok_Button.Focus();
                    //}

                    //2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
					break;

				case 1:
					break;
			}
		}
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.07 TAKAHASHI ADD END
		# endregion

		# region Control Events
		/// <summary>
		/// Form.Load �C�x���g(SFSIR09020UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private void SFSIR09020UA_Load(object sender, System.EventArgs e)
		{
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList24 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			// �ۑ��{�^��
			this.Ok_Button.ImageList = imageList24;
			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            // --- ADD 2009/03/19 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
            this.Renewal_Button.ImageList = imageList16;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            // --- ADD 2009/03/19 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
			// ����{�^��
			this.Cancel_Button.ImageList = imageList24;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			// �K�C�h�{�^��
			this.PayStMoneyKindCd1RF_tUltraBtn.ImageList = imageList16;
			this.PayStMoneyKindCd1RF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
			this.PayStMoneyKindCd2RF_tUltraBtn.ImageList = imageList16;
			this.PayStMoneyKindCd2RF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
			this.PayStMoneyKindCd3RF_tUltraBtn.ImageList = imageList16;
			this.PayStMoneyKindCd3RF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
			this.PayStMoneyKindCd4RF_tUltraBtn.ImageList = imageList16;
			this.PayStMoneyKindCd4RF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
			this.PayStMoneyKindCd5RF_tUltraBtn.ImageList = imageList16;
			this.PayStMoneyKindCd5RF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
			this.PayStMoneyKindCd6RF_tUltraBtn.ImageList = imageList16;
			this.PayStMoneyKindCd6RF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
			this.PayStMoneyKindCd7RF_tUltraBtn.ImageList = imageList16;
			this.PayStMoneyKindCd7RF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
			this.PayStMoneyKindCd8RF_tUltraBtn.ImageList = imageList16;
			this.PayStMoneyKindCd8RF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
            //2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            this.PayStMoneyKindCd9RF_tUltraBtn.ImageList = imageList16;
            this.PayStMoneyKindCd9RF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
            this.PayStMoneyKindCd10RF_tUltraBtn.ImageList = imageList16;
            this.PayStMoneyKindCd10RF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
            this.InitSelMoneyKindCdRF_tUltraBtn.ImageList = imageList16;
            this.InitSelMoneyKindCdRF_tUltraBtn.Appearance.Image = Size16_Index.STAR1;
            //2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			// �R���|�[�l���g�e�[�u���i�[����
			this.SetControlTable();


            // �����l�擾
            //_cache1 = this.PayStMoneyKindCd1RF_tNedit.Text.Trim();
            //_cache2 = this.PayStMoneyKindCd2RF_tNedit.Text.Trim();
            //_cache3 = this.PayStMoneyKindCd3RF_tNedit.Text.Trim();
            //_cache4 = this.PayStMoneyKindCd4RF_tNedit.Text.Trim();
            //_cache5 = this.PayStMoneyKindCd5RF_tNedit.Text.Trim();
            //_cache6 = this.PayStMoneyKindCd6RF_tNedit.Text.Trim();
            //_cache7 = this.PayStMoneyKindCd7RF_tNedit.Text.Trim();
            //_cache8 = this.PayStMoneyKindCd8RF_tNedit.Text.Trim();
            //_cache9 = this.PayStMoneyKindCd9RF_tNedit.Text.Trim();
            //_cache10 = this.PayStMoneyKindCd10RF_tNedit.Text.Trim();

            // �����l�擾
            _cache1 = this.paymentSet.PayStMoneyKindCd1.ToString();
            _cache2 = this.paymentSet.PayStMoneyKindCd2.ToString();
            _cache3 = this.paymentSet.PayStMoneyKindCd3.ToString();
            _cache4 = this.paymentSet.PayStMoneyKindCd4.ToString();
            _cache5 = this.paymentSet.PayStMoneyKindCd5.ToString();
            _cache6 = this.paymentSet.PayStMoneyKindCd6.ToString();
            _cache7 = this.paymentSet.PayStMoneyKindCd7.ToString();
            _cache8 = this.paymentSet.PayStMoneyKindCd8.ToString();
            _cache9 = this.paymentSet.PayStMoneyKindCd9.ToString();
            _cache10 = this.paymentSet.PayStMoneyKindCd10.ToString();

            

			// ��ʏ����ݒ菈��
            //2006.06.09  EMI Del			ScreenInitialSetting(); 
		}

        //2006.06.09  EMI Del>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// Form.Closing �C�x���g(SFSIR09020UA)
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        ///// <remarks>
        ///// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        ///// <br>Programmer : 21027 �{��  ���u�Y</br>
        ///// <br>Date       : 2005.04.12</br>
        ///// </remarks>
        //private void SFSIR09020UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    // 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>> START
        //    this._paymentSetClone = null;
        //    // 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>> END

        //    // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
        //    // �t�H�[�����\��������B
        //    //�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
        //    if (CanClose == false)
        //    {
        //        e.Cancel = true;
        //        this.Hide();
        //    }
        //}
        //2006.06.09  EMI Del<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// Form.Closing �C�x���g(SFSIR09020UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22029 ���R�@�b��</br>
        /// <br>Date       : 2006/6/9</br>�@
        /// </remarks>
        private void SFSIR09020UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TODO Close
            // 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            this._paymentSetClone = null;
            // 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>> END

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            //�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
        //2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// Form.VisibleChanged �C�x���g(SFSIR09020UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̕\���A��\�����ς�������ɔ������܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private void SFSIR09020UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
			if (this.Visible == false)
			{
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
				// ���C���t���[���A�N�e�B�u��
				this.Owner.Activate();
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END

				return;
			}

			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			if (this._paymentSetClone != null)
			{
				return;
			}
			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>> END

			ScreenClear();
			timer1.Enabled = true;
		}

		/// <summary>
		/// Control.Click �C�x���g(Ok_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{

            foreach (Control control in this._controlTable.Values)
            {
                if (control is TNedit)
                {
                    if (control.Name.IndexOf("PayStMoneyKindCd") == 0)
                    {
                        string payStMoneyKindCdNm = "PayStMoneyKindCd" + ((TNedit)control).Tag.ToString() + "RF_tEdit";
                        TEdit payStMoneyKindCdNmRF_tEdit = ((TEdit)this._controlTable[payStMoneyKindCdNm]);
                        if (PayStMonKiCdChange(0, (TNedit)control, payStMoneyKindCdNmRF_tEdit) != 0)
                        {
                            return;
                        }
                    }
                }
            }

			// �ۑ�����
			if (SavePaymentSet() != 0)
			{
				return;
			}

			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this._paymentSetClone = null;
			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>> END

			DialogResult dialogResult = DialogResult.OK;

			Mode_Label.Text = UPDATE_MODE;

			// ��ʔ�\���C�x���g
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
				UnDisplaying(this, me);
			}

			this.DialogResult = dialogResult;
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
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			DialogResult dialogResult = DialogResult.Cancel;

			// �x���ݒ�N���X�f�[�^�i�[
			ScreenToPaymentSet();
			if (!this.paymentSet.Equals(_paymentSetClone))
			{
				// ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
				DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
					"SFSIR09020U", 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
					null, 					                              // �\�����郁�b�Z�[�W
					0, 					                                  // �X�e�[�^�X�l
					MessageBoxButtons.YesNoCancel);	                      // �\������{�^��
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END
				switch (res)
				{
					case DialogResult.Yes :
					{
						if (SavePaymentSet() != 0)
						{
							return;
						}
						dialogResult = DialogResult.OK;
						break;
					}
					case DialogResult.No :
					{
						dialogResult = DialogResult.Cancel;
						break;
					}
					case DialogResult.Cancel :
					{
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.03 TAKAHASHI ADD START
						this.Cancel_Button.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.03 TAKAHASHI ADD END

						return;
					}
				}
			}

			// ��ʔ�\���C�x���g
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;

			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this._paymentSetClone = null;
			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>> END

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
		/// Control.Click �C�x���g(Guide_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private void PayStMoneyKindCd1RF_tUltraBtn_Click(object sender, System.EventArgs e)
		{
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.07 TAKAHASHI ADD START
			string objectName = null;

			if (sender is UltraButton)
			{
				objectName = ((UltraButton)sender).Name;
				StartGuidProc(objectName);
			}
			else
			{
				return;
			}			
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.07 TAKAHASHI ADD END
		}

		/// <summary>
		/// Timer.Tick �C�x���g(SFSIR09020UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �^�C�}�[���N������Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			timer1.Enabled = false;
			ScreenReconstruction();
        }

        #region [2005.09.24 TAKAHASHI DELETE START]
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI DELETE START
//		/// <summary>
//		/// TRetKeyControl.ChangeFocus �C�x���g(SFSIR09020UA)
//		/// </summary>
//		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
//		/// <param name="e">�L�[���</param>
//		/// <remarks>
//		/// <br>Note       : �t�H�[�J�X���J�ڂ���Ƃ��ɔ������܂��B</br>
//		/// <br>Programmer : 21027 �{��  ���u�Y</br>
//		/// <br>Date       : 2005.04.12</br>
//		/// </remarks>
//		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
//		{
//			if ((e.PrevCtrl == null)	|| (e.NextCtrl == null)) return;
//			
//			// �� �v�ύX /////////////////////////////////////////////////////////////////
//////////////////////////////////////////////// 2005.06.20 TERASAKA DEL STA //
////			// �I���{�^���N���b�N���̓`�F�b�N���Ȃ�
////			if (!(Convert.ToInt32(e.NextCtrl.Tag) == 220))
////			{
//// 2005.06.20 TERASAKA DEL END //////////////////////////////////////////////
//////////////////////////////////////////////// 2005.06.20 TERASAKA ADD STA //
//			// �I���{�^���N���b�N���̓`�F�b�N���Ȃ�
//			if ((!(Convert.ToInt32(e.NextCtrl.Tag) == 220)) &&
//				(this._changeFlg == true))
//			{
//				this._changeFlg = false;
//// 2005.06.20 TERASAKA ADD END //////////////////////////////////////////////
//				// ���̓R�[�h��薼�̎擾
//				int compTag =  Convert.ToInt32(e.PrevCtrl.Tag);
//
//				if ((e.PrevCtrl is TNedit) && (compTag >= 100) && (compTag < 200))
//				{
//					int wrkInt = ((TNedit)e.PrevCtrl).GetInt();
//					string wrkStr;
//
//					switch (wrkInt)
//					{
//						case 0 :
//						{
//							wrkStr = null;
//							break;
//						}
//						case 1 :
//						{
//							wrkStr = "�����E���؎�";
//							break;
//						}
//						case 2 :
//						{
//							wrkStr = "�U��";
//							break;
//						}
//						case 3 :
//						{
//							wrkStr = "�N���W�b�g";
//							break;
//						}
//						case 4 :
//						{
//							wrkStr = "�萔��";
//							break;
//						}
//						case 5 :
//						{
//							wrkStr = "��`";
//							break;
//						}
//						case 6 :
//						{
//							wrkStr = "���E";
//							break;
//						}
//						case 7 :
//						{
//							wrkStr = "���̑�";
//							break;
//						}
//						case 8 :
//						{
//							wrkStr = "�l��";
//							break;
//						}
//						case 9 :
//						{
//							wrkStr = "�a���";
//							break;
//						}
//						default :
//						{
//							MessageBox.Show(
//								"�}�X�^�ɓo�^����Ă��܂���B\n�R�[�h�Q�Ƌ@�\�͖������ł��B\n���e�����ł̉��Ή��ł��B",
//								"���̓`�F�b�N",
//								MessageBoxButtons.OK,
//								MessageBoxIcon.Exclamation,
//								MessageBoxDefaultButton.Button1);
//							wrkStr = "���o�^";
//							e.NextCtrl = e.PrevCtrl;
//							if (e.NextCtrl is TNedit)
//							{
//								((TNedit)(e.NextCtrl)).SelectAll();
//							}
//							break;
//						}
//					}
//
//					if (this.Controls.Count != 0)
//					{
//						for (int i=0; i < this.Controls.Count; i++)
//						{
//							// �ݒ荀�ڃ^�C�g��
//							if (this.Controls[i] is TEdit)
//							{
//								TEdit teditComp = (TEdit)this.Controls[i];
//								if (compTag +10L == Convert.ToInt32(teditComp.Tag))
//								{
//									teditComp.Text = wrkStr;
//									break;
//								}
//							}
//						}
//					}
//				}
//			}
//			// �� �v�ύX /////////////////////////////////////////////////////////////////
//		}
//////////////////////////////////////////////// 2005.06.13 TERASAKA ADD STA //
//		/// <summary>
//		/// ArrowKeyControl.ChangeFocus �C�x���g(SFSIR09020UA)
//		/// </summary>
//		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
//		/// <param name="e">�L�[���</param>
//		/// <remarks>
//		/// <br>Note       : �t�H�[�J�X���J�ڂ���Ƃ��ɔ������܂��B</br>
//		/// <br>Programmer : 22024 ����@�_�u</br>
//		/// <br>Date       : 2005.06.13</br>
//		/// </remarks>
//		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
//		{
//			if (e.NextCtrl == null) return;
//////////////////////////////////////////////// 2005.06.27 TERASAKA DEL STA //
////			if (e.PrevCtrl == this.PayInitSystemDivRF_tComboEditor)
////			{
////				switch (e.Key)
////				{
////					case Keys.Up:
////					{
////						e.NextCtrl = this.Cancel_Button;
////						break;
////					}
////					case Keys.Down:
////					{
////						e.NextCtrl = this.PayStMoneyKindCd1RF_tNedit;
////						break;
////					}
////				}
////			}
////			else if (e.PrevCtrl == this.Ok_Button)
////			{
////				if (e.Key == Keys.Down)
////				{
////					e.NextCtrl = this.Cancel_Button;
////				}
////			}
////			else if (e.PrevCtrl == this.Cancel_Button)
////			{
////				if ((e.Key == Keys.Down) ||
////					(e.Key == Keys.Right))
////				{
////					e.NextCtrl = this.PayInitSystemDivRF_tComboEditor;
////				}
////			}
//// 2005.06.27 TERASAKA DEL END //////////////////////////////////////////////
//			// �� �v�ύX /////////////////////////////////////////////////////////////////
//////////////////////////////////////////////// 2005.06.20 TERASAKA DEL STA //
////			// �I���{�^���N���b�N���̓`�F�b�N���Ȃ�
////			if (!(Convert.ToInt32(e.NextCtrl.Tag) == 220))
////			{
//// 2005.06.20 TERASAKA DEL END //////////////////////////////////////////////
//////////////////////////////////////////////// 2005.06.20 TERASAKA ADD STA //
//			// �I���{�^���N���b�N���̓`�F�b�N���Ȃ�
//			if ((!(Convert.ToInt32(e.NextCtrl.Tag) == 220)) &&
//				(this._changeFlg == true))
//			{
//				this._changeFlg = false;
//// 2005.06.20 TERASAKA ADD END //////////////////////////////////////////////
//				// ���̓R�[�h��薼�̎擾
//				int compTag =  Convert.ToInt32(e.PrevCtrl.Tag);
//
//				if ((e.PrevCtrl is TNedit) && (compTag >= 100) && (compTag < 200))
//				{
//					int wrkInt = ((TNedit)e.PrevCtrl).GetInt();
//					string wrkStr;
//
//					switch (wrkInt)
//					{
//						case 0 :
//						{
//							wrkStr = null;
//							break;
//						}
//						case 1 :
//						{
//							wrkStr = "�����E���؎�";
//							break;
//						}
//						case 2 :
//						{
//							wrkStr = "�U��";
//							break;
//						}
//						case 3 :
//						{
//							wrkStr = "�N���W�b�g";
//							break;
//						}
//						case 4 :
//						{
//							wrkStr = "�萔��";
//							break;
//						}
//						case 5 :
//						{
//							wrkStr = "��`";
//							break;
//						}
//						case 6 :
//						{
//							wrkStr = "���E";
//							break;
//						}
//						case 7 :
//						{
//							wrkStr = "���̑�";
//							break;
//						}
//						case 8 :
//						{
//							wrkStr = "�l��";
//							break;
//						}
//						case 9 :
//						{
//							wrkStr = "�a���";
//							break;
//						}
//						default :
//						{
//							MessageBox.Show(
//								"�}�X�^�ɓo�^����Ă��܂���B\n�R�[�h�Q�Ƌ@�\�͖������ł��B\n���e�����ł̉��Ή��ł��B",
//								"���̓`�F�b�N",
//								MessageBoxButtons.OK,
//								MessageBoxIcon.Exclamation,
//								MessageBoxDefaultButton.Button1);
//							wrkStr = "���o�^";
//							e.NextCtrl = e.PrevCtrl;
//							if (e.NextCtrl is TNedit)
//							{
//								((TNedit)(e.NextCtrl)).SelectAll();
//							}
//							break;
//						}
//					}
//
//					if (this.Controls.Count != 0)
//					{
//						for (int i=0; i < this.Controls.Count; i++)
//						{
//							// �ݒ荀�ڃ^�C�g��
//							if (this.Controls[i] is TEdit)
//							{
//								TEdit teditComp = (TEdit)this.Controls[i];
//								if (compTag +10L == Convert.ToInt32(teditComp.Tag))
//								{
//									teditComp.Text = wrkStr;
//									break;
//								}
//							}
//						}
//					}
//				}
//			}
//			// �� �v�ύX /////////////////////////////////////////////////////////////////
//		}
//// 2005.06.13 TERASAKA ADD END //////////////////////////////////////////////
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI DELETE END
        #endregion

        ////////////////////////////////////////////// 2005.06.20 TERASAKA ADD STA //
		/// <summary>
		///	Control.Enter �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�[���</param>
		/// <remarks>
		/// <br>Note			:	Control���A�N�e�B�u�ɂȂ����ۂɔ������܂��B</br>
		/// <br>Programmer		:	22024 ����@�_�u</br>
		/// <br>Date			:	2005.06.20</br>
		/// </remarks>
		private void tNedit_Enter(object sender, System.EventArgs e)
		{
            // �O�̒l��ۑ�
            //this._cachedValue = ((Broadleaf.Library.Windows.Forms.TNedit)sender).Text.Trim();
            //MessageBox.Show(_cachedValue);
            // �p����
            _continueFlag = true;

			this._changeFlg = false;
		}

// 2005.06.20 TERASAKA ADD END //////////////////////////////////////////////

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.ValueChanged �C�x���g(tNedit)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : tNedit���̃f�[�^���ύX���ꂽ�ۂɔ������܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2006.01.13</br>
		/// </remarks>
		private void tNedit_ValueChanged(object sender, System.EventArgs e)
		{
			// ���[�U�[�ɂ���ĕύX���ꂽ�ꍇ
			if (((TNedit)sender).Modified)
			{
				this._changeFlg = true;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Control.Leave �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�[���</param>
		/// <remarks>
		/// <br>Note			:	Control���tNedit�𔲂����ۂɔ������܂��B</br>
		/// <br>Programmer		:	23006�@���� ���q</br>
		/// <br>Date			:	2005.09.22</br>
		/// </remarks>
		private void tNedit_Leave(object sender, System.EventArgs e)
		{
            // �g�����y�я_����S���Ȃ����ߍ폜

//            string name;

//            TNedit payStMonKiCd = (TNedit)sender;

//            TEdit payStMonKiNm = (TEdit)this._controlTable["PayStMoneyKindCd" + (payStMonKiCd).Tag + "RF_tEdit"];
////2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//            //if (payStMonKiCd == InitSelMoneyKindCdRF_tNedit)
//            //{
//            //    payStMonKiNm = (TEdit)this._controlTable["InitSelMoneyKindCd" + "RF_tEdit"];
//            //}
////2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

//            if (payStMonKiCd.GetInt() == 0)
//            {
//                payStMonKiCd.Clear();
//                payStMonKiNm.Clear();
//            }
//            else if (this._changeFlg == true)
//            {
//                this._changeFlg = false;

//                //if (PayStMonKiCdChange(out name, payStMonKiCd.GetInt()) != 0)
//                if (PayStMonKiCdChange(0, payStMonKiCd, payStMonKiNm) != 0)
//                {
//                    payStMonKiCd.Focus();
//                    payStMonKiCd.SelectAll();
//                }
	
//                //payStMonKiNm.Text = name;
				
//            }

//            // �L���b�V���N���A
//            this._cachedValue = string.Empty;

        }

        /// <summary>
        /// Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayStMoneyKindCd1RF_tNedit_Leave(object sender, System.EventArgs e)
        {
            //if (PayStMoneyKindCd1RF_tNedit.GetInt() == 0)
            if (PayStMoneyKindCd1RF_tNedit.Text.Trim().Equals("0")
                || PayStMoneyKindCd1RF_tNedit.Text.Trim().Equals("00"))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                             "����R�[�h��0�͎w��ł��܂���B", 0, MessageBoxButtons.OK);
                this.PayStMoneyKindCd1RF_tNedit.SelectAll();
            }
            else if (String.IsNullOrEmpty(PayStMoneyKindCd1RF_tNedit.Text.Trim()))
            {
                PayStMoneyKindCd1RF_tNedit.Clear();
                PayStMoneyKindCd1RF_tEdit.Clear();
                PayStMoneyKindCd2RF_tNedit.Clear();
                PayStMoneyKindCd2RF_tEdit.Clear();
                PayStMoneyKindCd3RF_tNedit.Clear();
                PayStMoneyKindCd3RF_tEdit.Clear();
                PayStMoneyKindCd4RF_tNedit.Clear();
                PayStMoneyKindCd4RF_tEdit.Clear();
                PayStMoneyKindCd5RF_tNedit.Clear();
                PayStMoneyKindCd5RF_tEdit.Clear();
                PayStMoneyKindCd6RF_tNedit.Clear();
                PayStMoneyKindCd6RF_tEdit.Clear();
                PayStMoneyKindCd7RF_tNedit.Clear();
                PayStMoneyKindCd7RF_tEdit.Clear();
                PayStMoneyKindCd8RF_tNedit.Clear();
                PayStMoneyKindCd8RF_tEdit.Clear();
                PayStMoneyKindCd9RF_tNedit.Clear();
                PayStMoneyKindCd9RF_tEdit.Clear();
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
        }

        /// <summary>
        /// Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayStMoneyKindCd2RF_tNedit_Leave(object sender, System.EventArgs e)
        {
            //if (PayStMoneyKindCd2RF_tNedit.GetInt() == 0)
            if (PayStMoneyKindCd2RF_tNedit.Text.Trim().Equals("0")
                || PayStMoneyKindCd2RF_tNedit.Text.Trim().Equals("00"))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                             "����R�[�h��0�͎w��ł��܂���B", 0, MessageBoxButtons.OK);
                this.PayStMoneyKindCd2RF_tNedit.SelectAll();
            }
            else if (String.IsNullOrEmpty(PayStMoneyKindCd2RF_tNedit.Text.Trim()))
            {
                PayStMoneyKindCd2RF_tNedit.Clear();
                PayStMoneyKindCd2RF_tEdit.Clear();
                PayStMoneyKindCd3RF_tNedit.Clear();
                PayStMoneyKindCd3RF_tEdit.Clear();
                PayStMoneyKindCd4RF_tNedit.Clear();
                PayStMoneyKindCd4RF_tEdit.Clear();
                PayStMoneyKindCd5RF_tNedit.Clear();
                PayStMoneyKindCd5RF_tEdit.Clear();
                PayStMoneyKindCd6RF_tNedit.Clear();
                PayStMoneyKindCd6RF_tEdit.Clear();
                PayStMoneyKindCd7RF_tNedit.Clear();
                PayStMoneyKindCd7RF_tEdit.Clear();
                PayStMoneyKindCd8RF_tNedit.Clear();
                PayStMoneyKindCd8RF_tEdit.Clear();
                PayStMoneyKindCd9RF_tNedit.Clear();
                PayStMoneyKindCd9RF_tEdit.Clear();
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
            else if (this._changeFlg == true)
            {
                this._changeFlg = false;

                if (PayStMonKiCdChange(0, PayStMoneyKindCd2RF_tNedit, PayStMoneyKindCd2RF_tEdit) != 0)
                {
                    if (String.IsNullOrEmpty(PayStMoneyKindCd3RF_tNedit.Text))
                    {
                        EnableMonKindCodeFields(false, 2, false);
                    }
                    PayStMoneyKindCd2RF_tNedit.Focus();
                    PayStMoneyKindCd2RF_tNedit.SelectAll();
                }
                this._cachedValue = string.Empty;
            }
        }

        /// <summary>
        /// Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayStMoneyKindCd3RF_tNedit_Leave(object sender, System.EventArgs e)
        {
            //if (PayStMoneyKindCd3RF_tNedit.GetInt() == 0)
            if (PayStMoneyKindCd3RF_tNedit.Text.Trim().Equals("0")
                || PayStMoneyKindCd3RF_tNedit.Text.Trim().Equals("00"))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                             "����R�[�h��0�͎w��ł��܂���B", 0, MessageBoxButtons.OK);
                this.PayStMoneyKindCd3RF_tNedit.SelectAll();
            }
            else if (String.IsNullOrEmpty(PayStMoneyKindCd3RF_tNedit.Text.Trim()))
            {
                PayStMoneyKindCd3RF_tNedit.Clear();
                PayStMoneyKindCd3RF_tEdit.Clear();
                PayStMoneyKindCd4RF_tNedit.Clear();
                PayStMoneyKindCd4RF_tEdit.Clear();
                PayStMoneyKindCd5RF_tNedit.Clear();
                PayStMoneyKindCd5RF_tEdit.Clear();
                PayStMoneyKindCd6RF_tNedit.Clear();
                PayStMoneyKindCd6RF_tEdit.Clear();
                PayStMoneyKindCd7RF_tNedit.Clear();
                PayStMoneyKindCd7RF_tEdit.Clear();
                PayStMoneyKindCd8RF_tNedit.Clear();
                PayStMoneyKindCd8RF_tEdit.Clear();
                PayStMoneyKindCd9RF_tNedit.Clear();
                PayStMoneyKindCd9RF_tEdit.Clear();
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
            else if (this._changeFlg == true)
            {
                this._changeFlg = false;

                if (PayStMonKiCdChange(0, PayStMoneyKindCd3RF_tNedit, PayStMoneyKindCd3RF_tEdit) != 0)
                {
                    if (String.IsNullOrEmpty(PayStMoneyKindCd4RF_tNedit.Text))
                    {
                        EnableMonKindCodeFields(false, 4, false);
                    }
                    PayStMoneyKindCd3RF_tNedit.Focus();
                    PayStMoneyKindCd3RF_tNedit.SelectAll();
                }
                this._cachedValue = string.Empty;
            }
        }

        /// <summary>
        /// Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayStMoneyKindCd4RF_tNedit_Leave(object sender, System.EventArgs e)
        {
            //if (PayStMoneyKindCd4RF_tNedit.GetInt() == 0)
            if (PayStMoneyKindCd4RF_tNedit.Text.Trim().Equals("0")
                || PayStMoneyKindCd4RF_tNedit.Text.Trim().Equals("00"))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                             "����R�[�h��0�͎w��ł��܂���B", 0, MessageBoxButtons.OK);
                this.PayStMoneyKindCd4RF_tNedit.SelectAll();
            }
            else if (String.IsNullOrEmpty(PayStMoneyKindCd4RF_tNedit.Text.Trim()))
            {
                PayStMoneyKindCd4RF_tNedit.Clear();
                PayStMoneyKindCd4RF_tEdit.Clear();
                PayStMoneyKindCd5RF_tNedit.Clear();
                PayStMoneyKindCd5RF_tEdit.Clear();
                PayStMoneyKindCd6RF_tNedit.Clear();
                PayStMoneyKindCd6RF_tEdit.Clear();
                PayStMoneyKindCd7RF_tNedit.Clear();
                PayStMoneyKindCd7RF_tEdit.Clear();
                PayStMoneyKindCd8RF_tNedit.Clear();
                PayStMoneyKindCd8RF_tEdit.Clear();
                PayStMoneyKindCd9RF_tNedit.Clear();
                PayStMoneyKindCd9RF_tEdit.Clear();
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
            else if (this._changeFlg == true)
            {
                this._changeFlg = false;

                if (PayStMonKiCdChange(0, PayStMoneyKindCd4RF_tNedit, PayStMoneyKindCd4RF_tEdit) != 0)
                {
                    if (String.IsNullOrEmpty(PayStMoneyKindCd5RF_tNedit.Text))
                    {
                        EnableMonKindCodeFields(false, 5, false);
                    }
                    PayStMoneyKindCd4RF_tNedit.Focus();
                    PayStMoneyKindCd4RF_tNedit.SelectAll();
                }
                this._cachedValue = string.Empty;
            }
        }

        /// <summary>
        /// Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayStMoneyKindCd5RF_tNedit_Leave(object sender, System.EventArgs e)
        {
            //if (PayStMoneyKindCd5RF_tNedit.GetInt() == 0)
            if (PayStMoneyKindCd5RF_tNedit.Text.Trim().Equals("0")
                || PayStMoneyKindCd5RF_tNedit.Text.Trim().Equals("00"))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                             "����R�[�h��0�͎w��ł��܂���B", 0, MessageBoxButtons.OK);
                this.PayStMoneyKindCd5RF_tNedit.SelectAll();
            }
            else if (String.IsNullOrEmpty(PayStMoneyKindCd5RF_tNedit.Text.Trim()))
            {
                PayStMoneyKindCd5RF_tNedit.Clear();
                PayStMoneyKindCd5RF_tEdit.Clear();
                PayStMoneyKindCd6RF_tNedit.Clear();
                PayStMoneyKindCd6RF_tEdit.Clear();
                PayStMoneyKindCd7RF_tNedit.Clear();
                PayStMoneyKindCd7RF_tEdit.Clear();
                PayStMoneyKindCd8RF_tNedit.Clear();
                PayStMoneyKindCd8RF_tEdit.Clear();
                PayStMoneyKindCd9RF_tNedit.Clear();
                PayStMoneyKindCd9RF_tEdit.Clear();
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
            else if (this._changeFlg == true)
            {
                this._changeFlg = false;

                if (PayStMonKiCdChange(0, PayStMoneyKindCd5RF_tNedit, PayStMoneyKindCd5RF_tEdit) != 0)
                {
                    if (String.IsNullOrEmpty(PayStMoneyKindCd6RF_tNedit.Text))
                    {
                        EnableMonKindCodeFields(false, 6, false);
                    }
                    PayStMoneyKindCd5RF_tNedit.Focus();
                    PayStMoneyKindCd5RF_tNedit.SelectAll();
                }
                this._cachedValue = string.Empty;
            }
        }

        /// <summary>
        /// Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayStMoneyKindCd6RF_tNedit_Leave(object sender, System.EventArgs e)
        {
            //if (PayStMoneyKindCd6RF_tNedit.GetInt() == 0)
            if (PayStMoneyKindCd6RF_tNedit.Text.Trim().Equals("0")
                || PayStMoneyKindCd6RF_tNedit.Text.Trim().Equals("00"))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                             "����R�[�h��0�͎w��ł��܂���B", 0, MessageBoxButtons.OK);
                this.PayStMoneyKindCd6RF_tNedit.SelectAll();
            }
            else if (String.IsNullOrEmpty(PayStMoneyKindCd6RF_tNedit.Text.Trim()))
            {
                PayStMoneyKindCd6RF_tNedit.Clear();
                PayStMoneyKindCd6RF_tEdit.Clear();
                PayStMoneyKindCd7RF_tNedit.Clear();
                PayStMoneyKindCd7RF_tEdit.Clear();
                PayStMoneyKindCd8RF_tNedit.Clear();
                PayStMoneyKindCd8RF_tEdit.Clear();
                PayStMoneyKindCd9RF_tNedit.Clear();
                PayStMoneyKindCd9RF_tEdit.Clear();
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
            else if (this._changeFlg == true)
            {
                this._changeFlg = false;

                if (PayStMonKiCdChange(0, PayStMoneyKindCd6RF_tNedit, PayStMoneyKindCd6RF_tEdit) != 0)
                {
                    if (String.IsNullOrEmpty(PayStMoneyKindCd7RF_tNedit.Text))
                    {
                        EnableMonKindCodeFields(false, 7, false);
                    }
                    PayStMoneyKindCd6RF_tNedit.Focus();
                    PayStMoneyKindCd6RF_tNedit.SelectAll();
                }
                this._cachedValue = string.Empty;
            }
        }

        /// <summary>
        /// Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayStMoneyKindCd7RF_tNedit_Leave(object sender, System.EventArgs e)
        {
            //if (PayStMoneyKindCd7RF_tNedit.GetInt() == 0)
            if (PayStMoneyKindCd7RF_tNedit.Text.Trim().Equals("0")
                || PayStMoneyKindCd7RF_tNedit.Text.Trim().Equals("00"))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                             "����R�[�h��0�͎w��ł��܂���B", 0, MessageBoxButtons.OK);
                this.PayStMoneyKindCd7RF_tNedit.SelectAll();
            }
            else if (String.IsNullOrEmpty(PayStMoneyKindCd7RF_tNedit.Text.Trim()))
            {
                PayStMoneyKindCd7RF_tNedit.Clear();
                PayStMoneyKindCd7RF_tEdit.Clear();
                PayStMoneyKindCd8RF_tNedit.Clear();
                PayStMoneyKindCd8RF_tEdit.Clear();
                PayStMoneyKindCd9RF_tNedit.Clear();
                PayStMoneyKindCd9RF_tEdit.Clear();
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
            else if (this._changeFlg == true)
            {
                this._changeFlg = false;

                if (PayStMonKiCdChange(0, PayStMoneyKindCd7RF_tNedit, PayStMoneyKindCd7RF_tEdit) != 0)
                {
                    if (String.IsNullOrEmpty(PayStMoneyKindCd8RF_tNedit.Text))
                    {
                        EnableMonKindCodeFields(false, 8, false);
                    }
                    PayStMoneyKindCd7RF_tNedit.Focus();
                    PayStMoneyKindCd7RF_tNedit.SelectAll();
                }
                this._cachedValue = string.Empty;
            }
        }

        /// <summary>
        /// Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayStMoneyKindCd8RF_tNedit_Leave(object sender, System.EventArgs e)
        {
            //if (PayStMoneyKindCd8RF_tNedit.GetInt() == 0)
            if (PayStMoneyKindCd8RF_tNedit.Text.Trim().Equals("0")
                || PayStMoneyKindCd8RF_tNedit.Text.Trim().Equals("00"))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                             "����R�[�h��0�͎w��ł��܂���B", 0, MessageBoxButtons.OK);
                this.PayStMoneyKindCd8RF_tNedit.SelectAll();
            }
            else if (String.IsNullOrEmpty(PayStMoneyKindCd8RF_tNedit.Text.Trim()))
            {
                PayStMoneyKindCd8RF_tNedit.Clear();
                PayStMoneyKindCd8RF_tEdit.Clear();
                PayStMoneyKindCd9RF_tNedit.Clear();
                PayStMoneyKindCd9RF_tEdit.Clear();
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
            else if (this._changeFlg == true)
            {
                this._changeFlg = false;

                if (PayStMonKiCdChange(0, PayStMoneyKindCd8RF_tNedit, PayStMoneyKindCd8RF_tEdit) != 0)
                {
                    if (String.IsNullOrEmpty(PayStMoneyKindCd9RF_tNedit.Text))
                    {
                        EnableMonKindCodeFields(false, 9, false);
                    }
                    PayStMoneyKindCd8RF_tNedit.Focus();
                    PayStMoneyKindCd8RF_tNedit.SelectAll();
                }
                this._cachedValue = string.Empty;
            }
        }

        /// <summary>
        /// Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayStMoneyKindCd9RF_tNedit_Leave(object sender, System.EventArgs e)
        {
            //if (PayStMoneyKindCd9RF_tNedit.GetInt() == 0)
            if (PayStMoneyKindCd9RF_tNedit.Text.Trim().Equals("0")
                || PayStMoneyKindCd9RF_tNedit.Text.Trim().Equals("00"))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                             "����R�[�h��0�͎w��ł��܂���B", 0, MessageBoxButtons.OK);
                this.PayStMoneyKindCd9RF_tNedit.SelectAll();
            }
            else if (String.IsNullOrEmpty(PayStMoneyKindCd9RF_tNedit.Text.Trim()))
            {
                PayStMoneyKindCd9RF_tNedit.Clear();
                PayStMoneyKindCd9RF_tEdit.Clear();
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
            else if (this._changeFlg == true)
            {
                this._changeFlg = false;

                if (PayStMonKiCdChange(0, PayStMoneyKindCd9RF_tNedit, PayStMoneyKindCd9RF_tEdit) != 0)
                {
                    if (String.IsNullOrEmpty(PayStMoneyKindCd10RF_tNedit.Text))
                    {
                        EnableMonKindCodeFields(false, 10, false);
                    }
                    PayStMoneyKindCd9RF_tNedit.Focus();
                    PayStMoneyKindCd9RF_tNedit.SelectAll();
                }
                this._cachedValue = string.Empty;
            }
        }

        /// <summary>
        /// Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayStMoneyKindCd10RF_tNedit_Leave(object sender, System.EventArgs e)
        {
            //if (PayStMoneyKindCd10RF_tNedit.GetInt() == 0)
            if (PayStMoneyKindCd10RF_tNedit.Text.Trim().Equals("0")
                || PayStMoneyKindCd10RF_tNedit.Text.Trim().Equals("00"))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFSIR09020U",
                             "����R�[�h��0�͎w��ł��܂���B", 0, MessageBoxButtons.OK);
                this.PayStMoneyKindCd10RF_tNedit.SelectAll();
            }
            else if (String.IsNullOrEmpty(PayStMoneyKindCd10RF_tNedit.Text.Trim()))
            {
                PayStMoneyKindCd10RF_tNedit.Clear();
                PayStMoneyKindCd10RF_tEdit.Clear();
            }
            else if (this._changeFlg == true)
            {
                this._changeFlg = false;

                if (PayStMonKiCdChange(0, PayStMoneyKindCd10RF_tNedit, PayStMoneyKindCd10RF_tEdit) != 0)
                {
                    PayStMoneyKindCd10RF_tNedit.Focus();
                    PayStMoneyKindCd10RF_tNedit.SelectAll();
                }
                this._cachedValue = string.Empty;
            }
        }

        # endregion

        /// <summary>
        /// �R���g���[��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            bool correctCode = false;
            bool isEmpty = false;

            // ���̎擾 ============================================ //
            switch (e.PrevCtrl.Name)
            {
                #region �����ݒ����R�[�h [InitSelMoneyKindCdRF_tNedit]
                case "InitSelMoneyKindCdRF_tNedit":
                    {
                        string code = this.InitSelMoneyKindCdRF_tNedit.Text.Trim();

                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (String.IsNullOrEmpty(code))
                                    {
                                        // �󔒂̏ꍇ�̓K�C�h�{�^����
                                        e.NextCtrl = this.InitSelMoneyKindCdRF_tUltraBtn;
                                    }
                                    else
                                    {
                                        // ���͂���Ă���Ύx���ݒ����R�[�h1��
                                        e.NextCtrl = this.PayStMoneyKindCd1RF_tNedit;
                                    }

                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ����{�^����
                                    e.NextCtrl = this.Cancel_Button;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �����ݒ����R�[�h [InitSelMoneyKindCdRF_tNedit]

                #region �x���ݒ����R�[�h1 [PayStMoneyKindCd1RF_tNedit]
                case "PayStMoneyKindCd1RF_tNedit":
                    {
                        string code = this.PayStMoneyKindCd1RF_tNedit.Text.Trim();

                        // ���͂��ꂽ�l�̃`�F�b�N
                        if (String.IsNullOrEmpty(code))
                        {
                            // ��
                            isEmpty = true;
                            this._cache1 = string.Empty;
                            // 2�Ԗڈȍ~��Disable��
                            EnableMonKindCodeFields(false, 2, false);
                        }
                        else
                        {
                            // �R�[�h�`�F�b�N
                            if (PayStMonKiCdChange(0, PayStMoneyKindCd1RF_tNedit, PayStMoneyKindCd1RF_tEdit) == 0)
                            {
                                // �R�[�h�͐�����
                                correctCode = true;

                                // �R�[�h����������΃L���b�V�����X�V
                                this._cache1 = code;
                                // 2�Ԗڂ�Enable��
                                EnableMonKindCodeFields(false, 2, true);
                            }
                            else
                            {
                                // �R�[�h�s��

                                // �l��߂�
                                this.PayStMoneyKindCd1RF_tNedit.Text = this._cache1;
                            }
                        }
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ�̓K�C�h�{�^����
                                        e.NextCtrl = this.PayStMoneyKindCd1RF_tUltraBtn;
                                    }
                                    else
                                    {
                                        
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������2��
                                            e.NextCtrl = this.PayStMoneyKindCd2RF_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h�s���Ȃ�ړ��s��
                                            e.NextCtrl = this.PayStMoneyKindCd1RF_tNedit;
                                            PayStMoneyKindCd1RF_tNedit.Focus();
                                            PayStMoneyKindCd1RF_tNedit.SelectAll();
                                        }
                                    }

                                    break;
                                }
                            case Keys.Up:
                                {
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ�̓L�����Z���{�^����
                                        e.NextCtrl = this.Cancel_Button;
                                    }
                                    else
                                    {

                                        if (correctCode)
                                        {
                                            // �R�[�h�����������2��
                                            e.NextCtrl = this.PayStMoneyKindCd2RF_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h�s���Ȃ�ړ��s��
                                            e.NextCtrl = this.PayStMoneyKindCd1RF_tNedit;
                                            PayStMoneyKindCd1RF_tNedit.Focus();
                                            PayStMoneyKindCd1RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �x���ݒ����R�[�h1 [PayStMoneyKindCd1RF_tNedit]

                #region �x���ݒ����R�[�h1�K�C�h [PayStMoneyKindCd1RF_tUltraBtn]
                case "PayStMoneyKindCd1RF_tUltraBtn":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 2��Enable�Ȃ炻�����
                                    if (this.PayStMoneyKindCd2RF_tNedit.Enabled)
                                    {
                                        // ���͐ݒ����R�[�h2��
                                        e.NextCtrl = this.PayStMoneyKindCd2RF_tNedit;
                                    }
                                    else
                                    {
                                        // �ۑ��{�^����
                                        e.NextCtrl = this.Ok_Button;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // �L�����Z���{�^����
                                    e.NextCtrl = this.Cancel_Button;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �x���ݒ����R�[�h1�K�C�h [PayStMoneyKindCd1RF_tUltraBtn]

                #region �x���ݒ����R�[�h2 [PayStMoneyKindCd2RF_tNedit]
                case "PayStMoneyKindCd2RF_tNedit":
                    {
                        string code = this.PayStMoneyKindCd2RF_tNedit.Text.Trim();

                        // ���͂��ꂽ�l�̃`�F�b�N
                        if (String.IsNullOrEmpty(code))
                        {
                            // ��
                            isEmpty = true;
                            this._cache2 = string.Empty;
                            // 3�Ԗڈȍ~��Disable��
                            EnableMonKindCodeFields(false, 3, false);   
                        }
                        else
                        {
                            // �R�[�h�`�F�b�N
                            if (PayStMonKiCdChange(0, PayStMoneyKindCd2RF_tNedit, PayStMoneyKindCd2RF_tEdit) == 0)
                            {
                                // �R�[�h�͐�����
                                correctCode = true;

                                // �R�[�h����������΃L���b�V�����X�V
                                this._cache2 = code;
                                // 3�Ԗڂ�Enable��
                                EnableMonKindCodeFields(false, 3, true);
                            }
                            else
                            {
                                // �R�[�h�s��

                                // �l��߂�
                                this.PayStMoneyKindCd2RF_tNedit.Text = this._cache2;
                            }
                        }

                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ�̓K�C�h�{�^����
                                        e.NextCtrl = this.PayStMoneyKindCd2RF_tUltraBtn;
                                    }
                                    else 
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������3��
                                            e.NextCtrl = this.PayStMoneyKindCd3RF_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.PayStMoneyKindCd2RF_tNedit;
                                            PayStMoneyKindCd2RF_tNedit.Focus();
                                            PayStMoneyKindCd2RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ��1��
                                        e.NextCtrl = this.PayStMoneyKindCd1RF_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������1��
                                            e.NextCtrl = this.PayStMoneyKindCd1RF_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.PayStMoneyKindCd2RF_tNedit;
                                            PayStMoneyKindCd2RF_tNedit.Focus();
                                            PayStMoneyKindCd2RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �x���ݒ����R�[�h2 [PayStMoneyKindCd2RF_tNedit]

                #region �x���ݒ����R�[�h2�K�C�h [PayStMoneyKindCd2RF_tUltraBtn]
                case "PayStMoneyKindCd2RF_tUltraBtn":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 3��Enable�Ȃ炻�����
                                    if (this.PayStMoneyKindCd3RF_tNedit.Enabled)
                                    {
                                        // ���͐ݒ����R�[�h3��
                                        e.NextCtrl = this.PayStMoneyKindCd3RF_tNedit;
                                    }
                                    else
                                    {
                                        // �ۑ��{�^����
                                        e.NextCtrl = this.Ok_Button;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ���͐ݒ����R�[�h1��
                                    e.NextCtrl = this.PayStMoneyKindCd1RF_tNedit;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �x���ݒ����R�[�h2�K�C�h [PayStMoneyKindCd2RF_tUltraBtn]

                #region �x���ݒ����R�[�h3 [PayStMoneyKindCd3RF_tNedit]
                case "PayStMoneyKindCd3RF_tNedit":
                    {
                        string code = this.PayStMoneyKindCd3RF_tNedit.Text.Trim();

                        // ���͂��ꂽ�l�̃`�F�b�N
                        if (String.IsNullOrEmpty(code))
                        {
                            // ��
                            isEmpty = true;
                            this._cache3 = string.Empty;
                            // 4�Ԗڈȍ~��Disable��
                            EnableMonKindCodeFields(false, 4, false);
                        }
                        else
                        {
                            // �R�[�h�`�F�b�N
                            if (PayStMonKiCdChange(0, PayStMoneyKindCd3RF_tNedit, PayStMoneyKindCd3RF_tEdit) == 0)
                            {
                                // �R�[�h�͐�����
                                correctCode = true;

                                // �R�[�h����������΃L���b�V�����X�V
                                this._cache3 = code;
                                // 4�Ԗڂ�Enable��
                                EnableMonKindCodeFields(false, 4, true);
                            }
                            else
                            {
                                // �R�[�h�s��

                                // �l��߂�
                                this.PayStMoneyKindCd3RF_tNedit.Text = this._cache3;
                            }
                        }

                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ�̓K�C�h�{�^����
                                        e.NextCtrl = this.PayStMoneyKindCd3RF_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������4��
                                            e.NextCtrl = this.PayStMoneyKindCd4RF_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.PayStMoneyKindCd3RF_tNedit;
                                            PayStMoneyKindCd3RF_tNedit.Focus();
                                            PayStMoneyKindCd3RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ��2��
                                        e.NextCtrl = this.PayStMoneyKindCd2RF_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������2��
                                            e.NextCtrl = this.PayStMoneyKindCd2RF_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.PayStMoneyKindCd3RF_tNedit;
                                            PayStMoneyKindCd3RF_tNedit.Focus();
                                            PayStMoneyKindCd3RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �x���ݒ����R�[�h3 [PayStMoneyKindCd3RF_tNedit]

                #region �x���ݒ����R�[�h3�K�C�h [PayStMoneyKindCd3RF_tUltraBtn]
                case "PayStMoneyKindCd3RF_tUltraBtn":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 4��Enable�Ȃ炻�����
                                    if (this.PayStMoneyKindCd4RF_tNedit.Enabled)
                                    {
                                        // ���͐ݒ����R�[�h4��
                                        e.NextCtrl = this.PayStMoneyKindCd4RF_tNedit;
                                    }
                                    else
                                    {
                                        // �ۑ��{�^����
                                        e.NextCtrl = this.Ok_Button;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ���͐ݒ����R�[�h2��
                                    e.NextCtrl = this.PayStMoneyKindCd2RF_tNedit;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �x���ݒ����R�[�h3�K�C�h [PayStMoneyKindCd3RF_tUltraBtn]

                #region �x���ݒ����R�[�h4 [PayStMoneyKindCd4RF_tNedit]
                case "PayStMoneyKindCd4RF_tNedit":
                    {
                        string code = this.PayStMoneyKindCd4RF_tNedit.Text.Trim();

                        // ���͂��ꂽ�l�̃`�F�b�N
                        if (String.IsNullOrEmpty(code))
                        {
                            // ��
                            isEmpty = true;
                            this._cache4 = string.Empty;
                            // 5�Ԗڈȍ~��Disable��
                            EnableMonKindCodeFields(false, 5, false);
                        }
                        else
                        {
                            // �R�[�h�`�F�b�N
                            if (PayStMonKiCdChange(0, PayStMoneyKindCd4RF_tNedit, PayStMoneyKindCd4RF_tEdit) == 0)
                            {
                                // �R�[�h�͐�����
                                correctCode = true;

                                // �R�[�h����������΃L���b�V�����X�V
                                this._cache4 = code;
                                // 5�Ԗڂ�Enable��
                                EnableMonKindCodeFields(false, 5, true);
                            }
                            else
                            {
                                // �R�[�h�s��

                                // �l��߂�
                                this.PayStMoneyKindCd4RF_tNedit.Text = this._cache4;
                            }
                        }
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ�̓K�C�h�{�^����
                                        e.NextCtrl = this.PayStMoneyKindCd4RF_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������5��
                                            e.NextCtrl = this.PayStMoneyKindCd5RF_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.PayStMoneyKindCd4RF_tNedit;
                                            PayStMoneyKindCd4RF_tNedit.Focus();
                                            PayStMoneyKindCd4RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ��3��
                                        e.NextCtrl = this.PayStMoneyKindCd3RF_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������3��
                                            e.NextCtrl = this.PayStMoneyKindCd3RF_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.PayStMoneyKindCd4RF_tNedit;
                                            PayStMoneyKindCd4RF_tNedit.Focus();
                                            PayStMoneyKindCd4RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �x���ݒ����R�[�h4 [PayStMoneyKindCd4RF_tNedit]

                #region �x���ݒ����R�[�h4�K�C�h [PayStMoneyKindCd4RF_tUltraBtn]
                case "PayStMoneyKindCd4RF_tUltraBtn":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 5��Enable�Ȃ炻�����
                                    if (this.PayStMoneyKindCd5RF_tNedit.Enabled)
                                    {
                                        // ���͐ݒ����R�[�h5��
                                        e.NextCtrl = this.PayStMoneyKindCd5RF_tNedit;
                                    }
                                    else
                                    {
                                        // �ۑ��{�^����
                                        e.NextCtrl = this.Ok_Button;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ���͐ݒ����R�[�h3��
                                    e.NextCtrl = this.PayStMoneyKindCd3RF_tNedit;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �x���ݒ����R�[�h4�K�C�h [PayStMoneyKindCd4RF_tUltraBtn]

                #region �x���ݒ����R�[�h5 [PayStMoneyKindCd5RF_tNedit]
                case "PayStMoneyKindCd5RF_tNedit":
                    {
                        string code = this.PayStMoneyKindCd5RF_tNedit.Text.Trim();

                        // ���͂��ꂽ�l�̃`�F�b�N
                        if (String.IsNullOrEmpty(code))
                        {
                            // ��
                            isEmpty = true;
                            this._cache5 = string.Empty;
                            // 6�Ԗڈȍ~��Disable��
                            EnableMonKindCodeFields(false, 6, false);
                        }
                        else
                        {
                            // �R�[�h�`�F�b�N
                            if (PayStMonKiCdChange(0, PayStMoneyKindCd5RF_tNedit, PayStMoneyKindCd5RF_tEdit) == 0)
                            {
                                // �R�[�h�͐�����
                                correctCode = true;

                                // �R�[�h����������΃L���b�V�����X�V
                                this._cache5 = code;
                                // 6�Ԗڂ�Enable��
                                EnableMonKindCodeFields(false, 6, true);
                            }
                            else
                            {
                                // �R�[�h�s��

                                // �l��߂�
                                this.PayStMoneyKindCd5RF_tNedit.Text = this._cache5;
                            }
                        }

                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ�̓K�C�h�{�^����
                                        e.NextCtrl = this.PayStMoneyKindCd5RF_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������6��
                                            e.NextCtrl = this.PayStMoneyKindCd6RF_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.PayStMoneyKindCd5RF_tNedit;
                                            PayStMoneyKindCd5RF_tNedit.Focus();
                                            PayStMoneyKindCd5RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ��4��
                                        e.NextCtrl = this.PayStMoneyKindCd4RF_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������4��
                                            e.NextCtrl = this.PayStMoneyKindCd4RF_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.PayStMoneyKindCd5RF_tNedit;
                                            PayStMoneyKindCd5RF_tNedit.Focus();
                                            PayStMoneyKindCd5RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �x���ݒ����R�[�h5 [PayStMoneyKindCd5RF_tNedit]

                #region �x���ݒ����R�[�h5�K�C�h [PayStMoneyKindCd5RF_tUltraBtn]
                case "PayStMoneyKindCd5RF_tUltraBtn":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 6��Enable�Ȃ炻�����
                                    if (this.PayStMoneyKindCd6RF_tNedit.Enabled)
                                    {
                                        // ���͐ݒ����R�[�h6��
                                        e.NextCtrl = this.PayStMoneyKindCd6RF_tNedit;
                                    }
                                    else
                                    {
                                        // �ۑ��{�^����
                                        e.NextCtrl = this.Ok_Button;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ���͐ݒ����R�[�h4��
                                    e.NextCtrl = this.PayStMoneyKindCd4RF_tNedit;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �x���ݒ����R�[�h5�K�C�h [PayStMoneyKindCd5RF_tUltraBtn]

                #region �x���ݒ����R�[�h6 [PayStMoneyKindCd6RF_tNedit]
                case "PayStMoneyKindCd6RF_tNedit":
                    {
                        string code = this.PayStMoneyKindCd6RF_tNedit.Text.Trim();

                        // ���͂��ꂽ�l�̃`�F�b�N
                        if (String.IsNullOrEmpty(code))
                        {
                            // ��
                            isEmpty = true;
                            this._cache6 = string.Empty;
                            // 7�Ԗڈȍ~��Disable��
                            EnableMonKindCodeFields(false, 7, false);
                        }
                        else
                        {
                            // �R�[�h�`�F�b�N
                            if (PayStMonKiCdChange(0, PayStMoneyKindCd6RF_tNedit, PayStMoneyKindCd6RF_tEdit) == 0)
                            {
                                // �R�[�h�͐�����
                                correctCode = true;

                                // �R�[�h����������΃L���b�V�����X�V
                                this._cache6 = code;
                                // 7�Ԗڂ�Enable��
                                EnableMonKindCodeFields(false, 7, true);
                            }
                            else
                            {
                                // �R�[�h�s��

                                // �l��߂�
                                this.PayStMoneyKindCd6RF_tNedit.Text = this._cache6;
                            }
                        }

                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ�̓K�C�h�{�^����
                                        e.NextCtrl = this.PayStMoneyKindCd6RF_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������7��
                                            e.NextCtrl = this.PayStMoneyKindCd7RF_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.PayStMoneyKindCd6RF_tNedit;
                                            PayStMoneyKindCd6RF_tNedit.Focus();
                                            PayStMoneyKindCd6RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ��5��
                                        e.NextCtrl = this.PayStMoneyKindCd5RF_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������5��
                                            e.NextCtrl = this.PayStMoneyKindCd5RF_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.PayStMoneyKindCd6RF_tNedit;
                                            PayStMoneyKindCd6RF_tNedit.Focus();
                                            PayStMoneyKindCd6RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �x���ݒ����R�[�h6 [PayStMoneyKindCd6RF_tNedit]

                #region �x���ݒ����R�[�h6�K�C�h [PayStMoneyKindCd6RF_tUltraBtn]
                case "PayStMoneyKindCd6RF_tUltraBtn":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 7��Enable�Ȃ炻�����
                                    if (this.PayStMoneyKindCd7RF_tNedit.Enabled)
                                    {
                                        // ���͐ݒ����R�[�h7��
                                        e.NextCtrl = this.PayStMoneyKindCd7RF_tNedit;
                                    }
                                    else
                                    {
                                        // �ۑ��{�^����
                                        e.NextCtrl = this.Ok_Button;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ���͐ݒ����R�[�h5��
                                    e.NextCtrl = this.PayStMoneyKindCd5RF_tNedit;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �x���ݒ����R�[�h6�K�C�h [PayStMoneyKindCd6RF_tUltraBtn]

                #region �x���ݒ����R�[�h7 [PayStMoneyKindCd7RF_tNedit]
                case "PayStMoneyKindCd7RF_tNedit":
                    {
                        string code = this.PayStMoneyKindCd7RF_tNedit.Text.Trim();

                        // ���͂��ꂽ�l�̃`�F�b�N
                        if (String.IsNullOrEmpty(code))
                        {
                            // ��
                            isEmpty = true;
                            this._cache7 = string.Empty;
                            // 8�Ԗڈȍ~��Disable��
                            EnableMonKindCodeFields(false, 8, false);
                        }
                        else
                        {
                            // �R�[�h�`�F�b�N
                            if (PayStMonKiCdChange(0, PayStMoneyKindCd7RF_tNedit, PayStMoneyKindCd7RF_tEdit) == 0)
                            {
                                // �R�[�h�͐�����
                                correctCode = true;

                                // �R�[�h����������΃L���b�V�����X�V
                                this._cache7 = code;
                                // 8�Ԗڂ�Enable��
                                EnableMonKindCodeFields(false, 8, true);
                            }
                            else
                            {
                                // �R�[�h�s��

                                // �l��߂�
                                this.PayStMoneyKindCd7RF_tNedit.Text = this._cache7;
                            }
                        }

                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ�̓K�C�h�{�^����
                                        e.NextCtrl = this.PayStMoneyKindCd7RF_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������8��
                                            e.NextCtrl = this.PayStMoneyKindCd8RF_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.PayStMoneyKindCd7RF_tNedit;
                                            PayStMoneyKindCd7RF_tNedit.Focus();
                                            PayStMoneyKindCd7RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ��6��
                                        e.NextCtrl = this.PayStMoneyKindCd6RF_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������6��
                                            e.NextCtrl = this.PayStMoneyKindCd6RF_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.PayStMoneyKindCd7RF_tNedit;
                                            PayStMoneyKindCd7RF_tNedit.Focus();
                                            PayStMoneyKindCd7RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �x���ݒ����R�[�h7 [PayStMoneyKindCd7RF_tNedit]

                #region �x���ݒ����R�[�h7�K�C�h [PayStMoneyKindCd7RF_tUltraBtn]
                case "PayStMoneyKindCd7RF_tUltraBtn":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 8��Enable�Ȃ炻�����
                                    if (this.PayStMoneyKindCd8RF_tNedit.Enabled)
                                    {
                                        // ���͐ݒ����R�[�h8��
                                        e.NextCtrl = this.PayStMoneyKindCd8RF_tNedit;
                                    }
                                    else
                                    {
                                        // �ۑ��{�^����
                                        e.NextCtrl = this.Ok_Button;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ���͐ݒ����R�[�h6��
                                    e.NextCtrl = this.PayStMoneyKindCd6RF_tNedit;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �x���ݒ����R�[�h7�K�C�h [PayStMoneyKindCd7RF_tUltraBtn]

                #region �x���ݒ����R�[�h8 [PayStMoneyKindCd8RF_tNedit]
                case "PayStMoneyKindCd8RF_tNedit":
                    {
                        string code = this.PayStMoneyKindCd8RF_tNedit.Text.Trim();

                        // ���͂��ꂽ�l�̃`�F�b�N
                        if (String.IsNullOrEmpty(code))
                        {
                            // ��
                            isEmpty = true;
                            this._cache8 = string.Empty;
                            // 9�Ԗڈȍ~��Disable��
                            EnableMonKindCodeFields(false, 9, false);
                        }
                        else
                        {
                            // �R�[�h�`�F�b�N
                            if (PayStMonKiCdChange(0, PayStMoneyKindCd8RF_tNedit, PayStMoneyKindCd8RF_tEdit) == 0)
                            {
                                // �R�[�h�͐�����
                                correctCode = true;

                                // �R�[�h����������΃L���b�V�����X�V
                                this._cache8 = code;
                                // 9�Ԗڂ�Enable��
                                //EnableMonKindCodeFields(false, 9, true);
                            }
                            else
                            {
                                // �R�[�h�s��

                                // �l��߂�
                                this.PayStMoneyKindCd8RF_tNedit.Text = this._cache8;
                            }
                        }

                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ�̓K�C�h�{�^����
                                        e.NextCtrl = this.PayStMoneyKindCd8RF_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������9��
                                            //e.NextCtrl = this.PayStMoneyKindCd9RF_tNedit;
                                            e.NextCtrl = this.Ok_Button;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.PayStMoneyKindCd8RF_tNedit;
                                            PayStMoneyKindCd8RF_tNedit.Focus();
                                            PayStMoneyKindCd8RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ��7��
                                        e.NextCtrl = this.PayStMoneyKindCd7RF_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������7��
                                            e.NextCtrl = this.PayStMoneyKindCd7RF_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.PayStMoneyKindCd8RF_tNedit;
                                            PayStMoneyKindCd8RF_tNedit.Focus();
                                            PayStMoneyKindCd8RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �x���ݒ����R�[�h8 [PayStMoneyKindCd8RF_tNedit]

                #region �x���ݒ����R�[�h8�K�C�h [PayStMoneyKindCd8RF_tUltraBtn]
                case "PayStMoneyKindCd8RF_tUltraBtn":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    //// 9��Enable�Ȃ炻�����
                                    //if (this.PayStMoneyKindCd9RF_tNedit.Enabled)
                                    //{
                                    //    // ���͐ݒ����R�[�h9��
                                    //    e.NextCtrl = this.PayStMoneyKindCd9RF_tNedit;
                                    //}
                                    //else
                                    //{
                                        // �ۑ��{�^����
                                    //e.NextCtrl = this.Ok_Button;
                                    e.NextCtrl = this.Renewal_Button;
                                    //}
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ���͐ݒ����R�[�h7��
                                    e.NextCtrl = this.PayStMoneyKindCd7RF_tNedit;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �x���ݒ����R�[�h8�K�C�h [PayStMoneyKindCd8RF_tUltraBtn]

                #region �x���ݒ����R�[�h9 [PayStMoneyKindCd9RF_tNedit]
                case "PayStMoneyKindCd9RF_tNedit":
                    {
                        string code = this.PayStMoneyKindCd9RF_tNedit.Text.Trim();

                        // ���͂��ꂽ�l�̃`�F�b�N
                        if (String.IsNullOrEmpty(code))
                        {
                            // ��
                            isEmpty = true;
                            this._cache9 = string.Empty;
                            // 10�Ԗڈȍ~��Disable��
                            EnableMonKindCodeFields(false, 10, false);
                        }
                        else
                        {
                            // �R�[�h�`�F�b�N
                            if (PayStMonKiCdChange(0, PayStMoneyKindCd9RF_tNedit, PayStMoneyKindCd9RF_tEdit) == 0)
                            {
                                // �R�[�h�͐�����
                                correctCode = true;

                                // �R�[�h����������΃L���b�V�����X�V
                                this._cache9 = code;
                                // 10�Ԗڂ�Enable��
                                EnableMonKindCodeFields(false, 10, true);
                            }
                            else
                            {
                                // �R�[�h�s��

                                // �l��߂�
                                this.PayStMoneyKindCd9RF_tNedit.Text = this._cache9;
                            }
                        }

                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ�̓K�C�h�{�^����
                                        e.NextCtrl = this.PayStMoneyKindCd9RF_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������10��
                                            e.NextCtrl = this.PayStMoneyKindCd10RF_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.PayStMoneyKindCd9RF_tNedit;
                                            PayStMoneyKindCd9RF_tNedit.Focus();
                                            PayStMoneyKindCd9RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ��8��
                                        e.NextCtrl = this.PayStMoneyKindCd8RF_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������8��
                                            e.NextCtrl = this.PayStMoneyKindCd8RF_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.PayStMoneyKindCd9RF_tNedit;
                                            PayStMoneyKindCd9RF_tNedit.Focus();
                                            PayStMoneyKindCd9RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �x���ݒ����R�[�h9 [PayStMoneyKindCd9RF_tNedit]

                #region �x���ݒ����R�[�h9�K�C�h [PayStMoneyKindCd9RF_tUltraBtn]
                case "PayStMoneyKindCd9RF_tUltraBtn":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 10��Enable�Ȃ炻�����
                                    if (this.PayStMoneyKindCd10RF_tNedit.Enabled)
                                    {
                                        // ���͐ݒ����R�[�h10��
                                        e.NextCtrl = this.PayStMoneyKindCd10RF_tNedit;
                                    }
                                    else
                                    {
                                        // �ۑ��{�^����
                                        e.NextCtrl = this.Ok_Button;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ���͐ݒ����R�[�h8��
                                    e.NextCtrl = this.PayStMoneyKindCd8RF_tNedit;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �x���ݒ����R�[�h9�K�C�h [PayStMoneyKindCd9RF_tUltraBtn]

                #region �x���ݒ����R�[�h10 [PayStMoneyKindCd10RF_tNedit]
                case "PayStMoneyKindCd10RF_tNedit":
                    {
                        string code = this.PayStMoneyKindCd10RF_tNedit.Text.Trim();

                        // ���͂��ꂽ�l�̃`�F�b�N
                        if (String.IsNullOrEmpty(code))
                        {
                            // ��
                            isEmpty = true;
                            this._cache10 = string.Empty;
                        }
                        else
                        {
                            // �R�[�h�`�F�b�N
                            if (PayStMonKiCdChange(0, PayStMoneyKindCd10RF_tNedit, PayStMoneyKindCd10RF_tEdit) == 0)
                            {
                                // �R�[�h�͐�����
                                correctCode = true;

                                // �R�[�h����������΃L���b�V�����X�V
                                this._cache10 = code;
                            }
                            else
                            {
                                // �R�[�h�s��

                                // �l��߂�
                                this.PayStMoneyKindCd10RF_tNedit.Text = this._cache10;
                            }
                        }

                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ�̓K�C�h�{�^����
                                        e.NextCtrl = this.PayStMoneyKindCd10RF_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������OK�{�^����
                                            e.NextCtrl = this.Ok_Button;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.PayStMoneyKindCd10RF_tNedit;
                                            PayStMoneyKindCd10RF_tNedit.Focus();
                                            PayStMoneyKindCd10RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ��9��
                                        e.NextCtrl = this.PayStMoneyKindCd9RF_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������9��
                                            e.NextCtrl = this.PayStMoneyKindCd9RF_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.PayStMoneyKindCd10RF_tNedit;
                                            PayStMoneyKindCd10RF_tNedit.Focus();
                                            PayStMoneyKindCd10RF_tNedit.SelectAll();
                                        }
                                    }
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �x���ݒ����R�[�h10 [PayStMoneyKindCd10RF_tNedit]

                #region �x���ݒ����R�[�h10�K�C�h [PayStMoneyKindCd10RF_tUltraBtn]
                case "PayStMoneyKindCd10RF_tUltraBtn":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // �ۑ��{�^����
                                    e.NextCtrl = this.Ok_Button;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ���͐ݒ����R�[�h9��
                                    e.NextCtrl = this.PayStMoneyKindCd9RF_tNedit;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �x���ݒ����R�[�h10�K�C�h [PayStMoneyKindCd10RF_tUltraBtn]
            }

        }

        /// <summary>
        /// ��ʏ�̃{�^������уR�[�h���͗���Enable/Disable��
        /// </summary>
        /// <param name="initialSetting"></param>
        /// <param name="codeNumber"></param>
        /// <param name="enable"></param>
        private void EnableMonKindCodeFields(bool initialSetting, int codeNumber, bool enable)
        {
            if (initialSetting)
            {
                // 1���������ׂĂ̋���R�[�h���͗���Disable�ɁB�K�C�h�{�^����Disable
                if (String.IsNullOrEmpty(this.PayStMoneyKindCd1RF_tNedit.Text.Trim()) || this.PayStMoneyKindCd1RF_Label.Text.Equals("���o�^"))
                {
                    this.PayStMoneyKindCd2RF_tNedit.Enabled = false;
                    this.PayStMoneyKindCd2RF_tUltraBtn.Enabled = false;
                }
                else
                {
                    this.PayStMoneyKindCd2RF_tNedit.Enabled = true;
                    this.PayStMoneyKindCd2RF_tUltraBtn.Enabled = true;
                }
                if (String.IsNullOrEmpty(this.PayStMoneyKindCd2RF_tNedit.Text.Trim()) || this.PayStMoneyKindCd2RF_Label.Text.Equals("���o�^"))
                {
                    this.PayStMoneyKindCd3RF_tNedit.Enabled = false;
                    this.PayStMoneyKindCd3RF_tUltraBtn.Enabled = false;
                }
                else
                {
                    this.PayStMoneyKindCd3RF_tNedit.Enabled = true;
                    this.PayStMoneyKindCd3RF_tUltraBtn.Enabled = true;
                }
                if (String.IsNullOrEmpty(this.PayStMoneyKindCd3RF_tNedit.Text.Trim()) || this.PayStMoneyKindCd3RF_Label.Text.Equals("���o�^"))
                {
                    this.PayStMoneyKindCd4RF_tNedit.Enabled = false;
                    this.PayStMoneyKindCd4RF_tUltraBtn.Enabled = false;
                }
                else
                {
                    this.PayStMoneyKindCd4RF_tNedit.Enabled = true;
                    this.PayStMoneyKindCd4RF_tUltraBtn.Enabled = true;
                }
                if (String.IsNullOrEmpty(this.PayStMoneyKindCd4RF_tNedit.Text.Trim()) || this.PayStMoneyKindCd4RF_Label.Text.Equals("���o�^"))
                {
                    this.PayStMoneyKindCd5RF_tNedit.Enabled = false;
                    this.PayStMoneyKindCd5RF_tUltraBtn.Enabled = false;
                }
                else
                {
                    this.PayStMoneyKindCd5RF_tNedit.Enabled = true;
                    this.PayStMoneyKindCd5RF_tUltraBtn.Enabled = true;
                }
                if (String.IsNullOrEmpty(this.PayStMoneyKindCd5RF_tNedit.Text.Trim()) || this.PayStMoneyKindCd5RF_Label.Text.Equals("���o�^"))
                {
                    this.PayStMoneyKindCd6RF_tNedit.Enabled = false;
                    this.PayStMoneyKindCd6RF_tUltraBtn.Enabled = false;
                }
                else
                {
                    this.PayStMoneyKindCd6RF_tNedit.Enabled = true;
                    this.PayStMoneyKindCd6RF_tUltraBtn.Enabled = true;
                }
                if (String.IsNullOrEmpty(this.PayStMoneyKindCd6RF_tNedit.Text.Trim()) || this.PayStMoneyKindCd6RF_Label.Text.Equals("���o�^"))
                {
                    this.PayStMoneyKindCd7RF_tNedit.Enabled = false;
                    this.PayStMoneyKindCd7RF_tUltraBtn.Enabled = false;
                }
                else
                {
                    this.PayStMoneyKindCd7RF_tNedit.Enabled = true;
                    this.PayStMoneyKindCd7RF_tUltraBtn.Enabled = true;
                }
                if (String.IsNullOrEmpty(this.PayStMoneyKindCd7RF_tNedit.Text.Trim()) || this.PayStMoneyKindCd7RF_Label.Text.Equals("���o�^"))
                {
                    this.PayStMoneyKindCd8RF_tNedit.Enabled = false;
                    this.PayStMoneyKindCd8RF_tUltraBtn.Enabled = false;
                }
                else
                {
                    this.PayStMoneyKindCd8RF_tNedit.Enabled = true;
                    this.PayStMoneyKindCd8RF_tUltraBtn.Enabled = true;
                }
                if (String.IsNullOrEmpty(this.PayStMoneyKindCd8RF_tNedit.Text.Trim()) || this.PayStMoneyKindCd8RF_Label.Text.Equals("���o�^"))
                {
                    this.PayStMoneyKindCd9RF_tNedit.Enabled = false;
                    this.PayStMoneyKindCd9RF_tUltraBtn.Enabled = false;
                }
                else
                {
                    this.PayStMoneyKindCd9RF_tNedit.Enabled = true;
                    this.PayStMoneyKindCd9RF_tUltraBtn.Enabled = true;
                }
                if (String.IsNullOrEmpty(this.PayStMoneyKindCd9RF_tNedit.Text.Trim()) || this.PayStMoneyKindCd9RF_Label.Text.Equals("���o�^"))
                {
                    this.PayStMoneyKindCd10RF_tNedit.Enabled = false;
                    this.PayStMoneyKindCd10RF_tUltraBtn.Enabled = false;
                }
                else
                {
                    this.PayStMoneyKindCd10RF_tNedit.Enabled = true;
                    this.PayStMoneyKindCd10RF_tUltraBtn.Enabled = true;
                }
            }
            else
            {
                if (enable)
                {
                    if (codeNumber == 2)
                    //switch (codeNumber)
                    {
                        // �Q�Ԗڂ�Enable/Disable��
                        this.PayStMoneyKindCd2RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd2RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 3)
                    {
                        // �R�Ԗڂ�Enable/Disable��
                        this.PayStMoneyKindCd3RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd3RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 4)
                    {
                        // �S�Ԗڂ�Enable/Disable��
                        this.PayStMoneyKindCd4RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd4RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 5)
                    {
                        // �T�Ԗڂ�Enable/Disable��
                        this.PayStMoneyKindCd5RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd5RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 6)
                    {
                        // �U�Ԗڂ�Enable/Disable��
                        this.PayStMoneyKindCd6RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd6RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 7)
                    {
                        // �V�Ԗڂ�Enable/Disable��
                        this.PayStMoneyKindCd7RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd7RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 8)
                    {
                        // �W�Ԗڂ�Enable/Disable��
                        this.PayStMoneyKindCd8RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd8RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 9)
                    {
                        // �X�Ԗڂ�Enable/Disable��
                        this.PayStMoneyKindCd9RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd9RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 10)
                    {
                        // �P�O�Ԗڂ�Enable/Disable��
                        this.PayStMoneyKindCd10RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd10RF_tUltraBtn.Enabled = enable;
                    }

                }
                else
                {
                    // false�̂Ƃ��̓L�[���ڈȉ������ׂ�false

                    if (codeNumber < 3)
                    //switch (codeNumber)
                    {
                        // �Q�Ԗڂ�Enable/Disable��
                        this.PayStMoneyKindCd2RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd2RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 4)
                    {
                        // �R�Ԗڂ�Enable/Disable��
                        this.PayStMoneyKindCd3RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd3RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 5)
                    {
                        // �S�Ԗڂ�Enable/Disable��
                        this.PayStMoneyKindCd4RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd4RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 6)
                    {
                        // �T�Ԗڂ�Enable/Disable��
                        this.PayStMoneyKindCd5RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd5RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 7)
                    {
                        // �U�Ԗڂ�Enable/Disable��
                        this.PayStMoneyKindCd6RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd6RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 8)
                    {
                        // �V�Ԗڂ�Enable/Disable��
                        this.PayStMoneyKindCd7RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd7RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 9)
                    {
                        // �W�Ԗڂ�Enable/Disable��
                        this.PayStMoneyKindCd8RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd8RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 10)
                    {
                        // �X�Ԗڂ�Enable/Disable��
                        this.PayStMoneyKindCd9RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd9RF_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 11)
                    {
                        // �P�O�Ԗڂ�Enable/Disable��
                        this.PayStMoneyKindCd10RF_tNedit.Enabled = enable;
                        this.PayStMoneyKindCd10RF_tUltraBtn.Enabled = enable;
                    }
                }
            }
        }

        // --- ADD 2009/03/19 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this.paymentSetAcs = new PaymentSetAcs();

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          "SFSIR09020U",						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }
        // --- ADD 2009/03/19 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
    }
}
