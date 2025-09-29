//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �����ݒ�
// �v���O�����T�v   : �����ݒ���s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2005 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 23013 �q�@���l
// �� �� ��  2005/08/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 23006 ���� ���q
// �C �� ��  2005/09/03  �C�����e : ����{�^���ւ̃t�H�[�J�X�Z�b�g����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 23006 ���� ���q
// �C �� ��  2005/09/08  �C�����e : ��ƃR�[�h�擾����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 23006 ���� ���q
// �C �� ��  2005/09/21  �C�����e : ����R�[�h�Q�ƑΉ��A���̓`�F�b�N�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 23006 ���� ���q
// �C �� ��  2005/09/24  �C�����e : TMsgDisp���i�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 23006 ���� ���q
// �C �� ��  2005/10/07  �C�����e : �K�C�h�{�^�������Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 23006 ���� ���q
// �C �� ��  2005/10/18  �C�����e : �K�C�h�{�^���t�H�[�J�X����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 23006 ���� ���q
// �C �� ��  2005/10/19  �C�����e : UI�q���Hide����Owner.Activate�����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 23006 ���� ���q
// �C �� ��  2005/12/20  �C�����e : �e�}�X�^���f�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 23006 ���� ���q
// �C �� ��  2006/01/13  �C�����e : �R�[�h�Q�ƍ��ڂ̓��͕ύX�t���O�𗧂Ă�Ƃ��̏����C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 980023 �ђJ �k��
// �C �� ��  2007/05/23  �C�����e : �}�X�����̃K�C�h�̓����[�g���Q�Ƃ���悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30005 �،� ��
// �C �� ��  2007/05/27  �C�����e : ���z��ʖ��̎擾�����̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30462 �s�V �m��
// �C �� ��  2008/10/10  �C�����e : �o�O�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/06/22  �C�����e : �s��Ή�[13580]
//                                  ���g�p�Ōx�����o�Ă���ϐ����폜
//----------------------------------------------------------------------------//
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
	/// �����ݒ���̓t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �����ݒ���s���܂��B
	///                  IMasterMaintenanceMultiType���������Ă��܂��B</br>
	/// <br>Programmer : 23013 �q�@���l</br>
	/// <br>Date       : 2005.08.05</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.03 23006 ���� ���q</br>
	/// <br>					�E����{�^���ւ̃t�H�[�J�X�Z�b�g����</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.08  23006 ���� ���q</br>
	/// <br>				    �E��ƃR�[�h�擾����</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.21  23006 ���� ���q</br>
	/// <br>				    �E����R�[�h�Q�ƑΉ��A���̓`�F�b�N�C��</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.24  23006 ���� ���q</br>
	/// <br>				    �ETMsgDisp���i�Ή�</br>
	/// <br></br>
	/// <br>Update Note: 2005.10.07  23006 ���� ���q</br>
	/// <br>			        �E�K�C�h�{�^�������Ή�</br>
	/// <br></br>
	/// <br>Update Note: 2005.10.18  23006 ���� ���q</br>
	/// <br>			        �E�K�C�h�{�^���t�H�[�J�X����Ή�</br>
	/// <br></br>
	/// <br>Update Note : 2005.10.19  23006 ���� ���q</br>
	/// <br>				    �EUI�q���Hide����Owner.Activate�����ǉ�</br>
	/// <br></br>
	/// <br>Update Note : 2005.12.20  23006 ���� ���q</br>
	/// <br>				    �E�e�}�X�^���f�����Ή�</br>
	/// <br></br>
	/// <br>Update Note : 2006.01.13  23006 ���� ���q</br>
	/// <br>                    �E�R�[�h�Q�ƍ��ڂ̓��͕ύX�t���O�𗧂Ă�Ƃ��̏����C��</br>
    /// <br></br>
    /// <br>Update Note : 2007.05.23  980023 �ђJ �k��</br>
    /// <br>                    �E�}�X�����̃K�C�h�̓����[�g���Q�Ƃ���悤�ɏC��</br>
    /// <br></br>
    /// <br>Update Note : 2007.05.27  30005 �،� ��</br>
    /// <br>                    �E���z��ʖ��̎擾�����̏C��</br>
    /// <br></br>
    /// <br>UpdateNote   : 2008/10/10 30462 �s�V �m���@�o�O�C��</br>
    /// <br></br>
    /// <br>UpdateNote   : 2009/06/22       �Ɠc �M�u</br>
    /// <br>                    �E�s��Ή�[13580]</br>
    /// <br>                    �E���g�p�Ōx�����o�Ă���ϐ����폜</br>
    /// </remarks>
	public class SFUKK09060UA : System.Windows.Forms.Form, IMasterMaintenanceSingleType
	{
		# region Private Members (Component)
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Broadleaf.Library.Windows.Forms.THtmlGenerate tHtmlGenerate1;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private System.Windows.Forms.Timer timer1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Infragistics.Win.Misc.UltraLabel DepositlnitStKind_Titl_Label;
		private Broadleaf.Library.Windows.Forms.TNedit InitSelMoneyKindCd_tNedit;
		private Broadleaf.Library.Windows.Forms.TEdit InitSelMoneyKindCdNm_tEdit;
		private Infragistics.Win.Misc.UltraButton InitSelMoneyKindCd_ultraButton;
        private Infragistics.Win.Misc.UltraLabel InitSelMoneyKindCd_Title_Label;
        private Infragistics.Win.Misc.UltraLabel AlwcDepoCallMonths_Title_Label;
		private Broadleaf.Library.Windows.Forms.TComboEditor AlwcDepoCallMonths_tComboEditor;
		private Broadleaf.Library.Windows.Forms.TEdit DepositStKindCdNm1_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit DepositStKindCdNm2_tEdit;
		private Infragistics.Win.Misc.UltraLabel DepositStKindCd1_Label;
		private Broadleaf.Library.Windows.Forms.TEdit DepositStKindCdNm4_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit DepositStKindCdNm3_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit DepositStKindCdNm8_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit DepositStKindCdNm7_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit DepositStKindCdNm6_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit DepositStKindCdNm5_tEdit;
		private Infragistics.Win.Misc.UltraLabel DepositStKindCd2_Label;
		private Infragistics.Win.Misc.UltraLabel DepositStKindCd3_Label;
		private Infragistics.Win.Misc.UltraLabel DepositStKindCd4_Label;
		private Infragistics.Win.Misc.UltraLabel DepositStKindCd5_Label;
		private Infragistics.Win.Misc.UltraLabel DepositStKindCd6_Label;
		private Infragistics.Win.Misc.UltraLabel DepositStKindCd7_Label;
		private Broadleaf.Library.Windows.Forms.TNedit DepositStKindCd1_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit DepositStKindCd2_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit DepositStKindCd3_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit DepositStKindCd4_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit DepositStKindCd5_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit DepositStKindCd6_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit DepositStKindCd7_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit DepositStKindCd8_tNedit;
		private Infragistics.Win.Misc.UltraLabel DepositStKindCd8_Label;
		private Infragistics.Win.Misc.UltraButton DepositStKindCd1_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton DepositStKindCd2_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton DepositStKindCd3_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton DepositStKindCd4_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton DepositStKindCd5_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton DepositStKindCd6_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton DepositStKindCd7_tUltraBtn;
		private Infragistics.Win.Misc.UltraButton DepositStKindCd8_tUltraBtn;
		private Infragistics.Win.Misc.UltraLabel DepositStKindCd9_Label;
		private Broadleaf.Library.Windows.Forms.TNedit DepositStKindCd9_tNedit;
		private Broadleaf.Library.Windows.Forms.TEdit DepositStKindCdNm9_tEdit;
		private Infragistics.Win.Misc.UltraLabel DepositStKindCd10_Label;
		private Broadleaf.Library.Windows.Forms.TNedit DepositStKindCd10_tNedit;
		private Broadleaf.Library.Windows.Forms.TEdit DepositStKindCdNm10_tEdit;
		private Infragistics.Win.Misc.UltraLabel DepositInitDspNo_Titl_Label;
		private Broadleaf.Library.Windows.Forms.TComboEditor DepositInitDspNo_tComboEditor;
		private Infragistics.Win.Misc.UltraButton DepositStKindCd9_tUltraBtn;
        private Infragistics.Win.Misc.UltraButton DepositStKindCd10_tUltraBtn;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private UltraButton Renewal_Button;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// �����ݒ���̓t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����ݒ���̓t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		public SFUKK09060UA()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

			// �����ݒ�A�N�Z�X�N���X
			this.depositStAcs = new DepositStAcs();

			// �����ݒ�N���X
			this.depositSt = new DepositSt();

			// ��ʃR���|�[�l���g�o�^
			tneditCompList = new ArrayList();
			tneditCompList.Add(this.DepositStKindCd1_tNedit);
			tneditCompList.Add(this.DepositStKindCd2_tNedit);
			tneditCompList.Add(this.DepositStKindCd3_tNedit);
			tneditCompList.Add(this.DepositStKindCd4_tNedit);
			tneditCompList.Add(this.DepositStKindCd5_tNedit);
			tneditCompList.Add(this.DepositStKindCd6_tNedit);
			tneditCompList.Add(this.DepositStKindCd7_tNedit);
			tneditCompList.Add(this.DepositStKindCd8_tNedit);
			tneditCompList.Add(this.DepositStKindCd9_tNedit);
			tneditCompList.Add(this.DepositStKindCd10_tNedit);

			tneditCompList.TrimToSize();

			teditCompList = new ArrayList();
			teditCompList.Add(this.DepositStKindCdNm1_tEdit);
			teditCompList.Add(this.DepositStKindCdNm2_tEdit);
			teditCompList.Add(this.DepositStKindCdNm3_tEdit);
			teditCompList.Add(this.DepositStKindCdNm4_tEdit);
			teditCompList.Add(this.DepositStKindCdNm5_tEdit);
			teditCompList.Add(this.DepositStKindCdNm6_tEdit);
			teditCompList.Add(this.DepositStKindCdNm7_tEdit);
			teditCompList.Add(this.DepositStKindCdNm8_tEdit);
			teditCompList.Add(this.DepositStKindCdNm9_tEdit);
			teditCompList.Add(this.DepositStKindCdNm10_tEdit);
			teditCompList.TrimToSize();

			
			// ����\�t���O��ݒ肵�܂��B
			// Frame�̈���{�^���̕\����\���̐���Ɏg�p���܂��B
			_canPrint = false;

			// ��ʃN���[�Y����ݒ肵�܂��B
			// Close��Hide���̐���Ɏg�p���܂��B
			_canClose = false;
			this._moneyKindAcs = new MoneyKindAcs();
            this._moneyKindAcs.IsLocalDBRead = false;  // iitani a 2007.05.23 �����[�g�Œ�œǂނ悤�C��

			// ��ƃR�[�h���擾����
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END

			SetControlTable();
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo11 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo4 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo5 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo6 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo7 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo8 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo9 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo10 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���z��ʃK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKK09060UA));
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.DepositStKindCdNm1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.DepositlnitStKind_Titl_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DepositStKindCdNm2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.DepositStKindCd1_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DepositStKindCdNm4_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.DepositStKindCdNm3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.DepositStKindCdNm8_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.DepositStKindCdNm7_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.DepositStKindCdNm6_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.DepositStKindCdNm5_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tHtmlGenerate1 = new Broadleaf.Library.Windows.Forms.THtmlGenerate(this.components);
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DepositStKindCd2_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DepositStKindCd3_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DepositStKindCd4_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DepositStKindCd5_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DepositStKindCd6_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DepositStKindCd7_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DepositInitDspNo_Titl_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DepositStKindCd1_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.DepositInitDspNo_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DepositStKindCd2_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.DepositStKindCd3_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.DepositStKindCd4_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.DepositStKindCd5_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.DepositStKindCd6_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.DepositStKindCd7_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.DepositStKindCd8_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.DepositStKindCd8_Label = new Infragistics.Win.Misc.UltraLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.DepositStKindCd1_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.DepositStKindCd2_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.DepositStKindCd3_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.DepositStKindCd4_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.DepositStKindCd5_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.DepositStKindCd6_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.DepositStKindCd7_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.DepositStKindCd8_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.DepositStKindCd9_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DepositStKindCd9_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.DepositStKindCdNm9_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.DepositStKindCd9_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.DepositStKindCd10_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DepositStKindCd10_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.DepositStKindCdNm10_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.DepositStKindCd10_tUltraBtn = new Infragistics.Win.Misc.UltraButton();
            this.InitSelMoneyKindCd_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.InitSelMoneyKindCdNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.InitSelMoneyKindCd_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.InitSelMoneyKindCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AlwcDepoCallMonths_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AlwcDepoCallMonths_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCdNm1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCdNm2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCdNm4_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCdNm3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCdNm8_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCdNm7_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCdNm6_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCdNm5_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCd1_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositInitDspNo_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCd2_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCd3_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCd4_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCd5_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCd6_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCd7_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCd8_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCd9_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCdNm9_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCd10_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCdNm10_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InitSelMoneyKindCd_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InitSelMoneyKindCdNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlwcDepoCallMonths_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 448);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(477, 23);
            this.ultraStatusBar1.TabIndex = 700;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(219, 399);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 26;
            this.Ok_Button.Tag = "210";
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(344, 399);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 27;
            this.Cancel_Button.Tag = "220";
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // DepositStKindCdNm1_tEdit
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DepositStKindCdNm1_tEdit.ActiveAppearance = appearance1;
            appearance2.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.DepositStKindCdNm1_tEdit.Appearance = appearance2;
            this.DepositStKindCdNm1_tEdit.AutoSelect = true;
            this.DepositStKindCdNm1_tEdit.DataText = "";
            this.DepositStKindCdNm1_tEdit.Enabled = false;
            this.DepositStKindCdNm1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DepositStKindCdNm1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.DepositStKindCdNm1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.DepositStKindCdNm1_tEdit.Location = new System.Drawing.Point(165, 104);
            this.DepositStKindCdNm1_tEdit.MaxLength = 30;
            this.DepositStKindCdNm1_tEdit.Name = "DepositStKindCdNm1_tEdit";
            this.DepositStKindCdNm1_tEdit.Size = new System.Drawing.Size(221, 24);
            this.DepositStKindCdNm1_tEdit.TabIndex = 6;
            this.DepositStKindCdNm1_tEdit.TabStop = false;
            this.DepositStKindCdNm1_tEdit.Tag = "1";
            // 
            // DepositlnitStKind_Titl_Label
            // 
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.DepositlnitStKind_Titl_Label.Appearance = appearance3;
            this.DepositlnitStKind_Titl_Label.BackColorInternal = System.Drawing.SystemColors.Highlight;
            this.DepositlnitStKind_Titl_Label.Location = new System.Drawing.Point(105, 79);
            this.DepositlnitStKind_Titl_Label.Name = "DepositlnitStKind_Titl_Label";
            this.DepositlnitStKind_Titl_Label.Size = new System.Drawing.Size(179, 24);
            this.DepositlnitStKind_Titl_Label.TabIndex = 503;
            this.DepositlnitStKind_Titl_Label.Tag = "0";
            this.DepositlnitStKind_Titl_Label.Text = "�����ݒ����R�[�h";
            // 
            // DepositStKindCdNm2_tEdit
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DepositStKindCdNm2_tEdit.ActiveAppearance = appearance4;
            appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.DepositStKindCdNm2_tEdit.Appearance = appearance5;
            this.DepositStKindCdNm2_tEdit.AutoSelect = true;
            this.DepositStKindCdNm2_tEdit.DataText = "";
            this.DepositStKindCdNm2_tEdit.Enabled = false;
            this.DepositStKindCdNm2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DepositStKindCdNm2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.DepositStKindCdNm2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.DepositStKindCdNm2_tEdit.Location = new System.Drawing.Point(165, 129);
            this.DepositStKindCdNm2_tEdit.MaxLength = 30;
            this.DepositStKindCdNm2_tEdit.Name = "DepositStKindCdNm2_tEdit";
            this.DepositStKindCdNm2_tEdit.Size = new System.Drawing.Size(221, 24);
            this.DepositStKindCdNm2_tEdit.TabIndex = 9;
            this.DepositStKindCdNm2_tEdit.TabStop = false;
            this.DepositStKindCdNm2_tEdit.Tag = "2";
            // 
            // DepositStKindCd1_Label
            // 
            appearance6.TextHAlignAsString = "Right";
            appearance6.TextVAlignAsString = "Middle";
            this.DepositStKindCd1_Label.Appearance = appearance6;
            this.DepositStKindCd1_Label.Location = new System.Drawing.Point(60, 104);
            this.DepositStKindCd1_Label.Name = "DepositStKindCd1_Label";
            this.DepositStKindCd1_Label.Size = new System.Drawing.Size(40, 24);
            this.DepositStKindCd1_Label.TabIndex = 504;
            this.DepositStKindCd1_Label.Tag = "2";
            this.DepositStKindCd1_Label.Text = "�P";
            // 
            // DepositStKindCdNm4_tEdit
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DepositStKindCdNm4_tEdit.ActiveAppearance = appearance7;
            appearance8.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            this.DepositStKindCdNm4_tEdit.Appearance = appearance8;
            this.DepositStKindCdNm4_tEdit.AutoSelect = true;
            this.DepositStKindCdNm4_tEdit.DataText = "";
            this.DepositStKindCdNm4_tEdit.Enabled = false;
            this.DepositStKindCdNm4_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DepositStKindCdNm4_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.DepositStKindCdNm4_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.DepositStKindCdNm4_tEdit.Location = new System.Drawing.Point(165, 179);
            this.DepositStKindCdNm4_tEdit.MaxLength = 30;
            this.DepositStKindCdNm4_tEdit.Name = "DepositStKindCdNm4_tEdit";
            this.DepositStKindCdNm4_tEdit.Size = new System.Drawing.Size(221, 24);
            this.DepositStKindCdNm4_tEdit.TabIndex = 15;
            this.DepositStKindCdNm4_tEdit.TabStop = false;
            this.DepositStKindCdNm4_tEdit.Tag = "4";
            // 
            // DepositStKindCdNm3_tEdit
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DepositStKindCdNm3_tEdit.ActiveAppearance = appearance9;
            appearance10.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            this.DepositStKindCdNm3_tEdit.Appearance = appearance10;
            this.DepositStKindCdNm3_tEdit.AutoSelect = true;
            this.DepositStKindCdNm3_tEdit.DataText = "";
            this.DepositStKindCdNm3_tEdit.Enabled = false;
            this.DepositStKindCdNm3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DepositStKindCdNm3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.DepositStKindCdNm3_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.DepositStKindCdNm3_tEdit.Location = new System.Drawing.Point(165, 154);
            this.DepositStKindCdNm3_tEdit.MaxLength = 30;
            this.DepositStKindCdNm3_tEdit.Name = "DepositStKindCdNm3_tEdit";
            this.DepositStKindCdNm3_tEdit.Size = new System.Drawing.Size(221, 24);
            this.DepositStKindCdNm3_tEdit.TabIndex = 12;
            this.DepositStKindCdNm3_tEdit.TabStop = false;
            this.DepositStKindCdNm3_tEdit.Tag = "3";
            // 
            // DepositStKindCdNm8_tEdit
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DepositStKindCdNm8_tEdit.ActiveAppearance = appearance11;
            appearance12.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            this.DepositStKindCdNm8_tEdit.Appearance = appearance12;
            this.DepositStKindCdNm8_tEdit.AutoSelect = true;
            this.DepositStKindCdNm8_tEdit.DataText = "";
            this.DepositStKindCdNm8_tEdit.Enabled = false;
            this.DepositStKindCdNm8_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DepositStKindCdNm8_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.DepositStKindCdNm8_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.DepositStKindCdNm8_tEdit.Location = new System.Drawing.Point(165, 279);
            this.DepositStKindCdNm8_tEdit.MaxLength = 30;
            this.DepositStKindCdNm8_tEdit.Name = "DepositStKindCdNm8_tEdit";
            this.DepositStKindCdNm8_tEdit.Size = new System.Drawing.Size(221, 24);
            this.DepositStKindCdNm8_tEdit.TabIndex = 690;
            this.DepositStKindCdNm8_tEdit.TabStop = false;
            this.DepositStKindCdNm8_tEdit.Tag = "8";
            // 
            // DepositStKindCdNm7_tEdit
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DepositStKindCdNm7_tEdit.ActiveAppearance = appearance13;
            appearance14.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            this.DepositStKindCdNm7_tEdit.Appearance = appearance14;
            this.DepositStKindCdNm7_tEdit.AutoSelect = true;
            this.DepositStKindCdNm7_tEdit.DataText = "";
            this.DepositStKindCdNm7_tEdit.Enabled = false;
            this.DepositStKindCdNm7_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DepositStKindCdNm7_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.DepositStKindCdNm7_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.DepositStKindCdNm7_tEdit.Location = new System.Drawing.Point(165, 254);
            this.DepositStKindCdNm7_tEdit.MaxLength = 30;
            this.DepositStKindCdNm7_tEdit.Name = "DepositStKindCdNm7_tEdit";
            this.DepositStKindCdNm7_tEdit.Size = new System.Drawing.Size(221, 24);
            this.DepositStKindCdNm7_tEdit.TabIndex = 680;
            this.DepositStKindCdNm7_tEdit.TabStop = false;
            this.DepositStKindCdNm7_tEdit.Tag = "7";
            // 
            // DepositStKindCdNm6_tEdit
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DepositStKindCdNm6_tEdit.ActiveAppearance = appearance15;
            appearance16.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance16.ForeColorDisabled = System.Drawing.Color.Black;
            this.DepositStKindCdNm6_tEdit.Appearance = appearance16;
            this.DepositStKindCdNm6_tEdit.AutoSelect = true;
            this.DepositStKindCdNm6_tEdit.DataText = "";
            this.DepositStKindCdNm6_tEdit.Enabled = false;
            this.DepositStKindCdNm6_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DepositStKindCdNm6_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.DepositStKindCdNm6_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.DepositStKindCdNm6_tEdit.Location = new System.Drawing.Point(165, 229);
            this.DepositStKindCdNm6_tEdit.MaxLength = 30;
            this.DepositStKindCdNm6_tEdit.Name = "DepositStKindCdNm6_tEdit";
            this.DepositStKindCdNm6_tEdit.Size = new System.Drawing.Size(221, 24);
            this.DepositStKindCdNm6_tEdit.TabIndex = 21;
            this.DepositStKindCdNm6_tEdit.TabStop = false;
            this.DepositStKindCdNm6_tEdit.Tag = "6";
            // 
            // DepositStKindCdNm5_tEdit
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DepositStKindCdNm5_tEdit.ActiveAppearance = appearance17;
            appearance18.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            this.DepositStKindCdNm5_tEdit.Appearance = appearance18;
            this.DepositStKindCdNm5_tEdit.AutoSelect = true;
            this.DepositStKindCdNm5_tEdit.DataText = "";
            this.DepositStKindCdNm5_tEdit.Enabled = false;
            this.DepositStKindCdNm5_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DepositStKindCdNm5_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.DepositStKindCdNm5_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.DepositStKindCdNm5_tEdit.Location = new System.Drawing.Point(165, 204);
            this.DepositStKindCdNm5_tEdit.MaxLength = 30;
            this.DepositStKindCdNm5_tEdit.Name = "DepositStKindCdNm5_tEdit";
            this.DepositStKindCdNm5_tEdit.Size = new System.Drawing.Size(221, 24);
            this.DepositStKindCdNm5_tEdit.TabIndex = 18;
            this.DepositStKindCdNm5_tEdit.TabStop = false;
            this.DepositStKindCdNm5_tEdit.Tag = "5";
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
            appearance19.ForeColor = System.Drawing.Color.White;
            appearance19.TextHAlignAsString = "Center";
            appearance19.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance19;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(360, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 501;
            this.Mode_Label.Tag = "0";
            // 
            // DepositStKindCd2_Label
            // 
            appearance20.TextHAlignAsString = "Right";
            appearance20.TextVAlignAsString = "Middle";
            this.DepositStKindCd2_Label.Appearance = appearance20;
            this.DepositStKindCd2_Label.Location = new System.Drawing.Point(60, 129);
            this.DepositStKindCd2_Label.Name = "DepositStKindCd2_Label";
            this.DepositStKindCd2_Label.Size = new System.Drawing.Size(40, 24);
            this.DepositStKindCd2_Label.TabIndex = 505;
            this.DepositStKindCd2_Label.Tag = "3";
            this.DepositStKindCd2_Label.Text = "�Q";
            // 
            // DepositStKindCd3_Label
            // 
            appearance21.TextHAlignAsString = "Right";
            appearance21.TextVAlignAsString = "Middle";
            this.DepositStKindCd3_Label.Appearance = appearance21;
            this.DepositStKindCd3_Label.Location = new System.Drawing.Point(60, 154);
            this.DepositStKindCd3_Label.Name = "DepositStKindCd3_Label";
            this.DepositStKindCd3_Label.Size = new System.Drawing.Size(40, 24);
            this.DepositStKindCd3_Label.TabIndex = 506;
            this.DepositStKindCd3_Label.Tag = "4";
            this.DepositStKindCd3_Label.Text = "�R";
            // 
            // DepositStKindCd4_Label
            // 
            appearance22.TextHAlignAsString = "Right";
            appearance22.TextVAlignAsString = "Middle";
            this.DepositStKindCd4_Label.Appearance = appearance22;
            this.DepositStKindCd4_Label.Location = new System.Drawing.Point(60, 179);
            this.DepositStKindCd4_Label.Name = "DepositStKindCd4_Label";
            this.DepositStKindCd4_Label.Size = new System.Drawing.Size(40, 24);
            this.DepositStKindCd4_Label.TabIndex = 507;
            this.DepositStKindCd4_Label.Tag = "5";
            this.DepositStKindCd4_Label.Text = "�S";
            // 
            // DepositStKindCd5_Label
            // 
            appearance23.TextHAlignAsString = "Right";
            appearance23.TextVAlignAsString = "Middle";
            this.DepositStKindCd5_Label.Appearance = appearance23;
            this.DepositStKindCd5_Label.Location = new System.Drawing.Point(60, 204);
            this.DepositStKindCd5_Label.Name = "DepositStKindCd5_Label";
            this.DepositStKindCd5_Label.Size = new System.Drawing.Size(40, 24);
            this.DepositStKindCd5_Label.TabIndex = 508;
            this.DepositStKindCd5_Label.Tag = "6";
            this.DepositStKindCd5_Label.Text = "�T";
            // 
            // DepositStKindCd6_Label
            // 
            appearance24.TextHAlignAsString = "Right";
            appearance24.TextVAlignAsString = "Middle";
            this.DepositStKindCd6_Label.Appearance = appearance24;
            this.DepositStKindCd6_Label.Location = new System.Drawing.Point(60, 229);
            this.DepositStKindCd6_Label.Name = "DepositStKindCd6_Label";
            this.DepositStKindCd6_Label.Size = new System.Drawing.Size(40, 24);
            this.DepositStKindCd6_Label.TabIndex = 509;
            this.DepositStKindCd6_Label.Tag = "7";
            this.DepositStKindCd6_Label.Text = "�U";
            // 
            // DepositStKindCd7_Label
            // 
            appearance25.TextHAlignAsString = "Right";
            appearance25.TextVAlignAsString = "Middle";
            this.DepositStKindCd7_Label.Appearance = appearance25;
            this.DepositStKindCd7_Label.Location = new System.Drawing.Point(60, 254);
            this.DepositStKindCd7_Label.Name = "DepositStKindCd7_Label";
            this.DepositStKindCd7_Label.Size = new System.Drawing.Size(40, 24);
            this.DepositStKindCd7_Label.TabIndex = 510;
            this.DepositStKindCd7_Label.Tag = "8";
            this.DepositStKindCd7_Label.Text = "�V";
            // 
            // DepositInitDspNo_Titl_Label
            // 
            appearance26.TextHAlignAsString = "Left";
            appearance26.TextVAlignAsString = "Middle";
            this.DepositInitDspNo_Titl_Label.Appearance = appearance26;
            this.DepositInitDspNo_Titl_Label.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.DepositInitDspNo_Titl_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DepositInitDspNo_Titl_Label.Location = new System.Drawing.Point(20, 35);
            this.DepositInitDspNo_Titl_Label.Name = "DepositInitDspNo_Titl_Label";
            this.DepositInitDspNo_Titl_Label.Size = new System.Drawing.Size(150, 24);
            this.DepositInitDspNo_Titl_Label.TabIndex = 502;
            this.DepositInitDspNo_Titl_Label.Tag = "1";
            this.DepositInitDspNo_Titl_Label.Text = "���������\�����";
            // 
            // DepositStKindCd1_tNedit
            // 
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance27.TextHAlignAsString = "Right";
            this.DepositStKindCd1_tNedit.ActiveAppearance = appearance27;
            appearance28.TextHAlignAsString = "Right";
            this.DepositStKindCd1_tNedit.Appearance = appearance28;
            this.DepositStKindCd1_tNedit.AutoSelect = true;
            this.DepositStKindCd1_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.DepositStKindCd1_tNedit.DataText = "";
            this.DepositStKindCd1_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DepositStKindCd1_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.DepositStKindCd1_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DepositStKindCd1_tNedit.Location = new System.Drawing.Point(105, 104);
            this.DepositStKindCd1_tNedit.MaxLength = 3;
            this.DepositStKindCd1_tNedit.Name = "DepositStKindCd1_tNedit";
            this.DepositStKindCd1_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DepositStKindCd1_tNedit.Size = new System.Drawing.Size(36, 24);
            this.DepositStKindCd1_tNedit.TabIndex = 3;
            this.DepositStKindCd1_tNedit.Tag = "1";
            this.DepositStKindCd1_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.DepositStKindCd1_tNedit.Leave += new System.EventHandler(this.DepositStKindCd1_tNedit_Leave);
            this.DepositStKindCd1_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // DepositInitDspNo_tComboEditor
            // 
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DepositInitDspNo_tComboEditor.ActiveAppearance = appearance29;
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.DepositInitDspNo_tComboEditor.Appearance = appearance30;
            this.DepositInitDspNo_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.DepositInitDspNo_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DepositInitDspNo_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DepositInitDspNo_tComboEditor.ItemAppearance = appearance31;
            this.DepositInitDspNo_tComboEditor.Location = new System.Drawing.Point(175, 35);
            this.DepositInitDspNo_tComboEditor.Name = "DepositInitDspNo_tComboEditor";
            this.DepositInitDspNo_tComboEditor.Size = new System.Drawing.Size(110, 24);
            this.DepositInitDspNo_tComboEditor.TabIndex = 0;
            this.DepositInitDspNo_tComboEditor.Tag = "10";
            // 
            // DepositStKindCd2_tNedit
            // 
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance32.TextHAlignAsString = "Right";
            this.DepositStKindCd2_tNedit.ActiveAppearance = appearance32;
            appearance33.TextHAlignAsString = "Right";
            this.DepositStKindCd2_tNedit.Appearance = appearance33;
            this.DepositStKindCd2_tNedit.AutoSelect = true;
            this.DepositStKindCd2_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.DepositStKindCd2_tNedit.DataText = "";
            this.DepositStKindCd2_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DepositStKindCd2_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.DepositStKindCd2_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DepositStKindCd2_tNedit.Location = new System.Drawing.Point(105, 129);
            this.DepositStKindCd2_tNedit.MaxLength = 3;
            this.DepositStKindCd2_tNedit.Name = "DepositStKindCd2_tNedit";
            this.DepositStKindCd2_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DepositStKindCd2_tNedit.Size = new System.Drawing.Size(36, 24);
            this.DepositStKindCd2_tNedit.TabIndex = 5;
            this.DepositStKindCd2_tNedit.Tag = "2";
            this.DepositStKindCd2_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.DepositStKindCd2_tNedit.Leave += new System.EventHandler(this.DepositStKindCd2_tNedit_Leave);
            this.DepositStKindCd2_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // DepositStKindCd3_tNedit
            // 
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance34.TextHAlignAsString = "Right";
            this.DepositStKindCd3_tNedit.ActiveAppearance = appearance34;
            appearance35.TextHAlignAsString = "Right";
            this.DepositStKindCd3_tNedit.Appearance = appearance35;
            this.DepositStKindCd3_tNedit.AutoSelect = true;
            this.DepositStKindCd3_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.DepositStKindCd3_tNedit.DataText = "";
            this.DepositStKindCd3_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DepositStKindCd3_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.DepositStKindCd3_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DepositStKindCd3_tNedit.Location = new System.Drawing.Point(105, 154);
            this.DepositStKindCd3_tNedit.MaxLength = 3;
            this.DepositStKindCd3_tNedit.Name = "DepositStKindCd3_tNedit";
            this.DepositStKindCd3_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DepositStKindCd3_tNedit.Size = new System.Drawing.Size(36, 24);
            this.DepositStKindCd3_tNedit.TabIndex = 7;
            this.DepositStKindCd3_tNedit.Tag = "3";
            this.DepositStKindCd3_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.DepositStKindCd3_tNedit.Leave += new System.EventHandler(this.DepositStKindCd3_tNedit_Leave);
            this.DepositStKindCd3_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // DepositStKindCd4_tNedit
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance36.TextHAlignAsString = "Right";
            this.DepositStKindCd4_tNedit.ActiveAppearance = appearance36;
            appearance37.TextHAlignAsString = "Right";
            this.DepositStKindCd4_tNedit.Appearance = appearance37;
            this.DepositStKindCd4_tNedit.AutoSelect = true;
            this.DepositStKindCd4_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.DepositStKindCd4_tNedit.DataText = "";
            this.DepositStKindCd4_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DepositStKindCd4_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.DepositStKindCd4_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DepositStKindCd4_tNedit.Location = new System.Drawing.Point(105, 179);
            this.DepositStKindCd4_tNedit.MaxLength = 3;
            this.DepositStKindCd4_tNedit.Name = "DepositStKindCd4_tNedit";
            this.DepositStKindCd4_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DepositStKindCd4_tNedit.Size = new System.Drawing.Size(36, 24);
            this.DepositStKindCd4_tNedit.TabIndex = 9;
            this.DepositStKindCd4_tNedit.Tag = "4";
            this.DepositStKindCd4_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.DepositStKindCd4_tNedit.Leave += new System.EventHandler(this.DepositStKindCd4_tNedit_Leave);
            this.DepositStKindCd4_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // DepositStKindCd5_tNedit
            // 
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance38.TextHAlignAsString = "Right";
            this.DepositStKindCd5_tNedit.ActiveAppearance = appearance38;
            appearance39.TextHAlignAsString = "Right";
            this.DepositStKindCd5_tNedit.Appearance = appearance39;
            this.DepositStKindCd5_tNedit.AutoSelect = true;
            this.DepositStKindCd5_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.DepositStKindCd5_tNedit.DataText = "";
            this.DepositStKindCd5_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DepositStKindCd5_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.DepositStKindCd5_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DepositStKindCd5_tNedit.Location = new System.Drawing.Point(105, 204);
            this.DepositStKindCd5_tNedit.MaxLength = 3;
            this.DepositStKindCd5_tNedit.Name = "DepositStKindCd5_tNedit";
            this.DepositStKindCd5_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DepositStKindCd5_tNedit.Size = new System.Drawing.Size(36, 24);
            this.DepositStKindCd5_tNedit.TabIndex = 11;
            this.DepositStKindCd5_tNedit.Tag = "5";
            this.DepositStKindCd5_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.DepositStKindCd5_tNedit.Leave += new System.EventHandler(this.DepositStKindCd5_tNedit_Leave);
            this.DepositStKindCd5_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // DepositStKindCd6_tNedit
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance40.TextHAlignAsString = "Right";
            this.DepositStKindCd6_tNedit.ActiveAppearance = appearance40;
            appearance41.TextHAlignAsString = "Right";
            this.DepositStKindCd6_tNedit.Appearance = appearance41;
            this.DepositStKindCd6_tNedit.AutoSelect = true;
            this.DepositStKindCd6_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.DepositStKindCd6_tNedit.DataText = "";
            this.DepositStKindCd6_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DepositStKindCd6_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.DepositStKindCd6_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DepositStKindCd6_tNedit.Location = new System.Drawing.Point(105, 229);
            this.DepositStKindCd6_tNedit.MaxLength = 3;
            this.DepositStKindCd6_tNedit.Name = "DepositStKindCd6_tNedit";
            this.DepositStKindCd6_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DepositStKindCd6_tNedit.Size = new System.Drawing.Size(36, 24);
            this.DepositStKindCd6_tNedit.TabIndex = 13;
            this.DepositStKindCd6_tNedit.Tag = "6";
            this.DepositStKindCd6_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.DepositStKindCd6_tNedit.Leave += new System.EventHandler(this.DepositStKindCd6_tNedit_Leave);
            this.DepositStKindCd6_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // DepositStKindCd7_tNedit
            // 
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance42.TextHAlignAsString = "Right";
            this.DepositStKindCd7_tNedit.ActiveAppearance = appearance42;
            appearance43.TextHAlignAsString = "Right";
            this.DepositStKindCd7_tNedit.Appearance = appearance43;
            this.DepositStKindCd7_tNedit.AutoSelect = true;
            this.DepositStKindCd7_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.DepositStKindCd7_tNedit.DataText = "";
            this.DepositStKindCd7_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DepositStKindCd7_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.DepositStKindCd7_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DepositStKindCd7_tNedit.Location = new System.Drawing.Point(105, 254);
            this.DepositStKindCd7_tNedit.MaxLength = 3;
            this.DepositStKindCd7_tNedit.Name = "DepositStKindCd7_tNedit";
            this.DepositStKindCd7_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DepositStKindCd7_tNedit.Size = new System.Drawing.Size(36, 24);
            this.DepositStKindCd7_tNedit.TabIndex = 15;
            this.DepositStKindCd7_tNedit.Tag = "7";
            this.DepositStKindCd7_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.DepositStKindCd7_tNedit.Leave += new System.EventHandler(this.DepositStKindCd7_tNedit_Leave);
            this.DepositStKindCd7_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // DepositStKindCd8_tNedit
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance44.TextHAlignAsString = "Right";
            this.DepositStKindCd8_tNedit.ActiveAppearance = appearance44;
            appearance45.TextHAlignAsString = "Right";
            this.DepositStKindCd8_tNedit.Appearance = appearance45;
            this.DepositStKindCd8_tNedit.AutoSelect = true;
            this.DepositStKindCd8_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.DepositStKindCd8_tNedit.DataText = "";
            this.DepositStKindCd8_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DepositStKindCd8_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.DepositStKindCd8_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DepositStKindCd8_tNedit.Location = new System.Drawing.Point(105, 279);
            this.DepositStKindCd8_tNedit.MaxLength = 3;
            this.DepositStKindCd8_tNedit.Name = "DepositStKindCd8_tNedit";
            this.DepositStKindCd8_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DepositStKindCd8_tNedit.Size = new System.Drawing.Size(36, 24);
            this.DepositStKindCd8_tNedit.TabIndex = 17;
            this.DepositStKindCd8_tNedit.Tag = "8";
            this.DepositStKindCd8_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.DepositStKindCd8_tNedit.Leave += new System.EventHandler(this.DepositStKindCd8_tNedit_Leave);
            this.DepositStKindCd8_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // DepositStKindCd8_Label
            // 
            appearance46.TextHAlignAsString = "Right";
            appearance46.TextVAlignAsString = "Middle";
            this.DepositStKindCd8_Label.Appearance = appearance46;
            this.DepositStKindCd8_Label.Location = new System.Drawing.Point(60, 279);
            this.DepositStKindCd8_Label.Name = "DepositStKindCd8_Label";
            this.DepositStKindCd8_Label.Size = new System.Drawing.Size(40, 24);
            this.DepositStKindCd8_Label.TabIndex = 511;
            this.DepositStKindCd8_Label.Tag = "9";
            this.DepositStKindCd8_Label.Text = "�W";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DepositStKindCd1_tUltraBtn
            // 
            this.DepositStKindCd1_tUltraBtn.Location = new System.Drawing.Point(140, 104);
            this.DepositStKindCd1_tUltraBtn.Name = "DepositStKindCd1_tUltraBtn";
            this.DepositStKindCd1_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.DepositStKindCd1_tUltraBtn.TabIndex = 4;
            ultraToolTipInfo11.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.DepositStKindCd1_tUltraBtn, ultraToolTipInfo11);
            this.DepositStKindCd1_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.DepositStKindCd1_tUltraBtn.Click += new System.EventHandler(this.MoneyKindGuide_Click);
            // 
            // DepositStKindCd2_tUltraBtn
            // 
            this.DepositStKindCd2_tUltraBtn.Location = new System.Drawing.Point(140, 129);
            this.DepositStKindCd2_tUltraBtn.Name = "DepositStKindCd2_tUltraBtn";
            this.DepositStKindCd2_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.DepositStKindCd2_tUltraBtn.TabIndex = 6;
            ultraToolTipInfo4.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.DepositStKindCd2_tUltraBtn, ultraToolTipInfo4);
            this.DepositStKindCd2_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.DepositStKindCd2_tUltraBtn.Click += new System.EventHandler(this.MoneyKindGuide_Click);
            // 
            // DepositStKindCd3_tUltraBtn
            // 
            this.DepositStKindCd3_tUltraBtn.Location = new System.Drawing.Point(140, 154);
            this.DepositStKindCd3_tUltraBtn.Name = "DepositStKindCd3_tUltraBtn";
            this.DepositStKindCd3_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.DepositStKindCd3_tUltraBtn.TabIndex = 8;
            ultraToolTipInfo5.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.DepositStKindCd3_tUltraBtn, ultraToolTipInfo5);
            this.DepositStKindCd3_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.DepositStKindCd3_tUltraBtn.Click += new System.EventHandler(this.MoneyKindGuide_Click);
            // 
            // DepositStKindCd4_tUltraBtn
            // 
            this.DepositStKindCd4_tUltraBtn.Location = new System.Drawing.Point(140, 179);
            this.DepositStKindCd4_tUltraBtn.Name = "DepositStKindCd4_tUltraBtn";
            this.DepositStKindCd4_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.DepositStKindCd4_tUltraBtn.TabIndex = 10;
            ultraToolTipInfo6.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.DepositStKindCd4_tUltraBtn, ultraToolTipInfo6);
            this.DepositStKindCd4_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.DepositStKindCd4_tUltraBtn.Click += new System.EventHandler(this.MoneyKindGuide_Click);
            // 
            // DepositStKindCd5_tUltraBtn
            // 
            this.DepositStKindCd5_tUltraBtn.Location = new System.Drawing.Point(140, 204);
            this.DepositStKindCd5_tUltraBtn.Name = "DepositStKindCd5_tUltraBtn";
            this.DepositStKindCd5_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.DepositStKindCd5_tUltraBtn.TabIndex = 12;
            ultraToolTipInfo7.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.DepositStKindCd5_tUltraBtn, ultraToolTipInfo7);
            this.DepositStKindCd5_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.DepositStKindCd5_tUltraBtn.Click += new System.EventHandler(this.MoneyKindGuide_Click);
            // 
            // DepositStKindCd6_tUltraBtn
            // 
            this.DepositStKindCd6_tUltraBtn.Location = new System.Drawing.Point(140, 229);
            this.DepositStKindCd6_tUltraBtn.Name = "DepositStKindCd6_tUltraBtn";
            this.DepositStKindCd6_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.DepositStKindCd6_tUltraBtn.TabIndex = 14;
            ultraToolTipInfo8.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.DepositStKindCd6_tUltraBtn, ultraToolTipInfo8);
            this.DepositStKindCd6_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.DepositStKindCd6_tUltraBtn.Click += new System.EventHandler(this.MoneyKindGuide_Click);
            // 
            // DepositStKindCd7_tUltraBtn
            // 
            this.DepositStKindCd7_tUltraBtn.Location = new System.Drawing.Point(140, 254);
            this.DepositStKindCd7_tUltraBtn.Name = "DepositStKindCd7_tUltraBtn";
            this.DepositStKindCd7_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.DepositStKindCd7_tUltraBtn.TabIndex = 16;
            ultraToolTipInfo9.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.DepositStKindCd7_tUltraBtn, ultraToolTipInfo9);
            this.DepositStKindCd7_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.DepositStKindCd7_tUltraBtn.Click += new System.EventHandler(this.MoneyKindGuide_Click);
            // 
            // DepositStKindCd8_tUltraBtn
            // 
            this.DepositStKindCd8_tUltraBtn.Location = new System.Drawing.Point(140, 279);
            this.DepositStKindCd8_tUltraBtn.Name = "DepositStKindCd8_tUltraBtn";
            this.DepositStKindCd8_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.DepositStKindCd8_tUltraBtn.TabIndex = 18;
            ultraToolTipInfo10.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.DepositStKindCd8_tUltraBtn, ultraToolTipInfo10);
            this.DepositStKindCd8_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.DepositStKindCd8_tUltraBtn.Click += new System.EventHandler(this.MoneyKindGuide_Click);
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
            // DepositStKindCd9_Label
            // 
            appearance68.TextHAlignAsString = "Right";
            appearance68.TextVAlignAsString = "Middle";
            this.DepositStKindCd9_Label.Appearance = appearance68;
            this.DepositStKindCd9_Label.Location = new System.Drawing.Point(60, 304);
            this.DepositStKindCd9_Label.Name = "DepositStKindCd9_Label";
            this.DepositStKindCd9_Label.Size = new System.Drawing.Size(40, 24);
            this.DepositStKindCd9_Label.TabIndex = 703;
            this.DepositStKindCd9_Label.Tag = "10";
            this.DepositStKindCd9_Label.Text = "�X";
            // 
            // DepositStKindCd9_tNedit
            // 
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance60.TextHAlignAsString = "Right";
            this.DepositStKindCd9_tNedit.ActiveAppearance = appearance60;
            appearance61.TextHAlignAsString = "Right";
            this.DepositStKindCd9_tNedit.Appearance = appearance61;
            this.DepositStKindCd9_tNedit.AutoSelect = true;
            this.DepositStKindCd9_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.DepositStKindCd9_tNedit.DataText = "";
            this.DepositStKindCd9_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DepositStKindCd9_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.DepositStKindCd9_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DepositStKindCd9_tNedit.Location = new System.Drawing.Point(105, 304);
            this.DepositStKindCd9_tNedit.MaxLength = 3;
            this.DepositStKindCd9_tNedit.Name = "DepositStKindCd9_tNedit";
            this.DepositStKindCd9_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DepositStKindCd9_tNedit.Size = new System.Drawing.Size(36, 24);
            this.DepositStKindCd9_tNedit.TabIndex = 19;
            this.DepositStKindCd9_tNedit.Tag = "9";
            this.DepositStKindCd9_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.DepositStKindCd9_tNedit.Leave += new System.EventHandler(this.DepositStKindCd9_tNedit_Leave);
            this.DepositStKindCd9_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // DepositStKindCdNm9_tEdit
            // 
            appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DepositStKindCdNm9_tEdit.ActiveAppearance = appearance62;
            appearance63.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance63.ForeColorDisabled = System.Drawing.Color.Black;
            this.DepositStKindCdNm9_tEdit.Appearance = appearance63;
            this.DepositStKindCdNm9_tEdit.AutoSelect = true;
            this.DepositStKindCdNm9_tEdit.DataText = "";
            this.DepositStKindCdNm9_tEdit.Enabled = false;
            this.DepositStKindCdNm9_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DepositStKindCdNm9_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.DepositStKindCdNm9_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.DepositStKindCdNm9_tEdit.Location = new System.Drawing.Point(165, 304);
            this.DepositStKindCdNm9_tEdit.MaxLength = 30;
            this.DepositStKindCdNm9_tEdit.Name = "DepositStKindCdNm9_tEdit";
            this.DepositStKindCdNm9_tEdit.Size = new System.Drawing.Size(221, 24);
            this.DepositStKindCdNm9_tEdit.TabIndex = 704;
            this.DepositStKindCdNm9_tEdit.TabStop = false;
            this.DepositStKindCdNm9_tEdit.Tag = "9";
            // 
            // DepositStKindCd9_tUltraBtn
            // 
            this.DepositStKindCd9_tUltraBtn.Location = new System.Drawing.Point(140, 304);
            this.DepositStKindCd9_tUltraBtn.Name = "DepositStKindCd9_tUltraBtn";
            this.DepositStKindCd9_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.DepositStKindCd9_tUltraBtn.TabIndex = 20;
            ultraToolTipInfo3.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.DepositStKindCd9_tUltraBtn, ultraToolTipInfo3);
            this.DepositStKindCd9_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.DepositStKindCd9_tUltraBtn.Click += new System.EventHandler(this.MoneyKindGuide_Click);
            // 
            // DepositStKindCd10_Label
            // 
            appearance67.TextHAlignAsString = "Right";
            appearance67.TextVAlignAsString = "Middle";
            this.DepositStKindCd10_Label.Appearance = appearance67;
            this.DepositStKindCd10_Label.Location = new System.Drawing.Point(60, 329);
            this.DepositStKindCd10_Label.Name = "DepositStKindCd10_Label";
            this.DepositStKindCd10_Label.Size = new System.Drawing.Size(40, 24);
            this.DepositStKindCd10_Label.TabIndex = 707;
            this.DepositStKindCd10_Label.Tag = "11";
            this.DepositStKindCd10_Label.Text = "�P�O";
            // 
            // DepositStKindCd10_tNedit
            // 
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance56.TextHAlignAsString = "Right";
            this.DepositStKindCd10_tNedit.ActiveAppearance = appearance56;
            appearance57.TextHAlignAsString = "Right";
            this.DepositStKindCd10_tNedit.Appearance = appearance57;
            this.DepositStKindCd10_tNedit.AutoSelect = true;
            this.DepositStKindCd10_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.DepositStKindCd10_tNedit.DataText = "";
            this.DepositStKindCd10_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DepositStKindCd10_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.DepositStKindCd10_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DepositStKindCd10_tNedit.Location = new System.Drawing.Point(105, 329);
            this.DepositStKindCd10_tNedit.MaxLength = 3;
            this.DepositStKindCd10_tNedit.Name = "DepositStKindCd10_tNedit";
            this.DepositStKindCd10_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DepositStKindCd10_tNedit.Size = new System.Drawing.Size(36, 24);
            this.DepositStKindCd10_tNedit.TabIndex = 21;
            this.DepositStKindCd10_tNedit.Tag = "10";
            this.DepositStKindCd10_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.DepositStKindCd10_tNedit.Leave += new System.EventHandler(this.DepositStKindCd10_tNedit_Leave);
            this.DepositStKindCd10_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // DepositStKindCdNm10_tEdit
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DepositStKindCdNm10_tEdit.ActiveAppearance = appearance58;
            appearance59.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            this.DepositStKindCdNm10_tEdit.Appearance = appearance59;
            this.DepositStKindCdNm10_tEdit.AutoSelect = true;
            this.DepositStKindCdNm10_tEdit.DataText = "";
            this.DepositStKindCdNm10_tEdit.Enabled = false;
            this.DepositStKindCdNm10_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DepositStKindCdNm10_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.DepositStKindCdNm10_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.DepositStKindCdNm10_tEdit.Location = new System.Drawing.Point(165, 329);
            this.DepositStKindCdNm10_tEdit.MaxLength = 30;
            this.DepositStKindCdNm10_tEdit.Name = "DepositStKindCdNm10_tEdit";
            this.DepositStKindCdNm10_tEdit.Size = new System.Drawing.Size(221, 24);
            this.DepositStKindCdNm10_tEdit.TabIndex = 708;
            this.DepositStKindCdNm10_tEdit.TabStop = false;
            this.DepositStKindCdNm10_tEdit.Tag = "10";
            // 
            // DepositStKindCd10_tUltraBtn
            // 
            this.DepositStKindCd10_tUltraBtn.Location = new System.Drawing.Point(140, 329);
            this.DepositStKindCd10_tUltraBtn.Name = "DepositStKindCd10_tUltraBtn";
            this.DepositStKindCd10_tUltraBtn.Size = new System.Drawing.Size(25, 24);
            this.DepositStKindCd10_tUltraBtn.TabIndex = 22;
            ultraToolTipInfo2.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.DepositStKindCd10_tUltraBtn, ultraToolTipInfo2);
            this.DepositStKindCd10_tUltraBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.DepositStKindCd10_tUltraBtn.Click += new System.EventHandler(this.MoneyKindGuide_Click);
            // 
            // InitSelMoneyKindCd_tNedit
            // 
            appearance52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance52.TextHAlignAsString = "Right";
            this.InitSelMoneyKindCd_tNedit.ActiveAppearance = appearance52;
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance53.TextHAlignAsString = "Right";
            this.InitSelMoneyKindCd_tNedit.Appearance = appearance53;
            this.InitSelMoneyKindCd_tNedit.AutoSelect = true;
            this.InitSelMoneyKindCd_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.InitSelMoneyKindCd_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.InitSelMoneyKindCd_tNedit.DataText = "";
            this.InitSelMoneyKindCd_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.InitSelMoneyKindCd_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.InitSelMoneyKindCd_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.InitSelMoneyKindCd_tNedit.Location = new System.Drawing.Point(175, 438);
            this.InitSelMoneyKindCd_tNedit.MaxLength = 3;
            this.InitSelMoneyKindCd_tNedit.Name = "InitSelMoneyKindCd_tNedit";
            this.InitSelMoneyKindCd_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.InitSelMoneyKindCd_tNedit.Size = new System.Drawing.Size(36, 24);
            this.InitSelMoneyKindCd_tNedit.TabIndex = 1;
            this.InitSelMoneyKindCd_tNedit.Tag = "108";
            this.InitSelMoneyKindCd_tNedit.Visible = false;
            this.InitSelMoneyKindCd_tNedit.ValueChanged += new System.EventHandler(this.tNedit_ValueChanged);
            this.InitSelMoneyKindCd_tNedit.Leave += new System.EventHandler(this.tNedit_Leave);
            this.InitSelMoneyKindCd_tNedit.Enter += new System.EventHandler(this.tNedit_Enter);
            // 
            // InitSelMoneyKindCdNm_tEdit
            // 
            appearance54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InitSelMoneyKindCdNm_tEdit.ActiveAppearance = appearance54;
            appearance55.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance55.ForeColorDisabled = System.Drawing.Color.Black;
            this.InitSelMoneyKindCdNm_tEdit.Appearance = appearance55;
            this.InitSelMoneyKindCdNm_tEdit.AutoSelect = true;
            this.InitSelMoneyKindCdNm_tEdit.DataText = "";
            this.InitSelMoneyKindCdNm_tEdit.Enabled = false;
            this.InitSelMoneyKindCdNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.InitSelMoneyKindCdNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.InitSelMoneyKindCdNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.InitSelMoneyKindCdNm_tEdit.Location = new System.Drawing.Point(237, 438);
            this.InitSelMoneyKindCdNm_tEdit.MaxLength = 30;
            this.InitSelMoneyKindCdNm_tEdit.Name = "InitSelMoneyKindCdNm_tEdit";
            this.InitSelMoneyKindCdNm_tEdit.Size = new System.Drawing.Size(221, 24);
            this.InitSelMoneyKindCdNm_tEdit.TabIndex = 3;
            this.InitSelMoneyKindCdNm_tEdit.TabStop = false;
            this.InitSelMoneyKindCdNm_tEdit.Tag = "118";
            this.InitSelMoneyKindCdNm_tEdit.Visible = false;
            // 
            // InitSelMoneyKindCd_ultraButton
            // 
            this.InitSelMoneyKindCd_ultraButton.Location = new System.Drawing.Point(212, 438);
            this.InitSelMoneyKindCd_ultraButton.Name = "InitSelMoneyKindCd_ultraButton";
            this.InitSelMoneyKindCd_ultraButton.Size = new System.Drawing.Size(25, 24);
            this.InitSelMoneyKindCd_ultraButton.TabIndex = 2;
            ultraToolTipInfo1.ToolTipText = "���z��ʃK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.InitSelMoneyKindCd_ultraButton, ultraToolTipInfo1);
            this.InitSelMoneyKindCd_ultraButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.InitSelMoneyKindCd_ultraButton.Visible = false;
            this.InitSelMoneyKindCd_ultraButton.Click += new System.EventHandler(this.MoneyKindGuide_Click);
            // 
            // InitSelMoneyKindCd_Title_Label
            // 
            appearance66.TextHAlignAsString = "Left";
            appearance66.TextVAlignAsString = "Middle";
            this.InitSelMoneyKindCd_Title_Label.Appearance = appearance66;
            this.InitSelMoneyKindCd_Title_Label.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.InitSelMoneyKindCd_Title_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.InitSelMoneyKindCd_Title_Label.Location = new System.Drawing.Point(20, 438);
            this.InitSelMoneyKindCd_Title_Label.Name = "InitSelMoneyKindCd_Title_Label";
            this.InitSelMoneyKindCd_Title_Label.Size = new System.Drawing.Size(150, 24);
            this.InitSelMoneyKindCd_Title_Label.TabIndex = 711;
            this.InitSelMoneyKindCd_Title_Label.Tag = "2";
            this.InitSelMoneyKindCd_Title_Label.Text = "�����I������R�[�h";
            this.InitSelMoneyKindCd_Title_Label.Visible = false;
            // 
            // AlwcDepoCallMonths_Title_Label
            // 
            appearance64.TextHAlignAsString = "Left";
            appearance64.TextVAlignAsString = "Middle";
            this.AlwcDepoCallMonths_Title_Label.Appearance = appearance64;
            this.AlwcDepoCallMonths_Title_Label.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.AlwcDepoCallMonths_Title_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AlwcDepoCallMonths_Title_Label.Location = new System.Drawing.Point(14, 359);
            this.AlwcDepoCallMonths_Title_Label.Name = "AlwcDepoCallMonths_Title_Label";
            this.AlwcDepoCallMonths_Title_Label.Size = new System.Drawing.Size(175, 24);
            this.AlwcDepoCallMonths_Title_Label.TabIndex = 714;
            this.AlwcDepoCallMonths_Title_Label.Tag = "0";
            this.AlwcDepoCallMonths_Title_Label.Text = "�����ϓ`�[�ďo�敪";
            // 
            // AlwcDepoCallMonths_tComboEditor
            // 
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AlwcDepoCallMonths_tComboEditor.ActiveAppearance = appearance48;
            this.AlwcDepoCallMonths_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.AlwcDepoCallMonths_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AlwcDepoCallMonths_tComboEditor.ItemAppearance = appearance49;
            this.AlwcDepoCallMonths_tComboEditor.Location = new System.Drawing.Point(194, 359);
            this.AlwcDepoCallMonths_tComboEditor.Name = "AlwcDepoCallMonths_tComboEditor";
            this.AlwcDepoCallMonths_tComboEditor.Size = new System.Drawing.Size(230, 24);
            this.AlwcDepoCallMonths_tComboEditor.TabIndex = 24;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(94, 399);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 25;
            this.Renewal_Button.Tag = "210";
            this.Renewal_Button.Text = "�ŐV���(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // SFUKK09060UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(477, 471);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.AlwcDepoCallMonths_tComboEditor);
            this.Controls.Add(this.InitSelMoneyKindCd_tNedit);
            this.Controls.Add(this.InitSelMoneyKindCdNm_tEdit);
            this.Controls.Add(this.DepositStKindCd10_tNedit);
            this.Controls.Add(this.DepositStKindCdNm10_tEdit);
            this.Controls.Add(this.DepositStKindCd9_tNedit);
            this.Controls.Add(this.DepositStKindCdNm9_tEdit);
            this.Controls.Add(this.DepositStKindCd8_tNedit);
            this.Controls.Add(this.DepositStKindCd7_tNedit);
            this.Controls.Add(this.DepositStKindCd6_tNedit);
            this.Controls.Add(this.DepositStKindCd5_tNedit);
            this.Controls.Add(this.DepositStKindCd4_tNedit);
            this.Controls.Add(this.DepositStKindCd3_tNedit);
            this.Controls.Add(this.DepositStKindCd2_tNedit);
            this.Controls.Add(this.DepositStKindCd1_tNedit);
            this.Controls.Add(this.DepositStKindCdNm8_tEdit);
            this.Controls.Add(this.DepositStKindCdNm7_tEdit);
            this.Controls.Add(this.DepositStKindCdNm6_tEdit);
            this.Controls.Add(this.DepositStKindCdNm5_tEdit);
            this.Controls.Add(this.DepositStKindCdNm4_tEdit);
            this.Controls.Add(this.DepositStKindCdNm3_tEdit);
            this.Controls.Add(this.DepositStKindCdNm2_tEdit);
            this.Controls.Add(this.DepositStKindCdNm1_tEdit);
            this.Controls.Add(this.AlwcDepoCallMonths_Title_Label);
            this.Controls.Add(this.InitSelMoneyKindCd_Title_Label);
            this.Controls.Add(this.InitSelMoneyKindCd_ultraButton);
            this.Controls.Add(this.DepositStKindCd10_Label);
            this.Controls.Add(this.DepositStKindCd10_tUltraBtn);
            this.Controls.Add(this.DepositStKindCd9_Label);
            this.Controls.Add(this.DepositStKindCd9_tUltraBtn);
            this.Controls.Add(this.DepositStKindCd1_tUltraBtn);
            this.Controls.Add(this.DepositStKindCd8_Label);
            this.Controls.Add(this.DepositInitDspNo_tComboEditor);
            this.Controls.Add(this.DepositStKindCd7_Label);
            this.Controls.Add(this.DepositStKindCd6_Label);
            this.Controls.Add(this.DepositStKindCd5_Label);
            this.Controls.Add(this.DepositStKindCd4_Label);
            this.Controls.Add(this.DepositStKindCd3_Label);
            this.Controls.Add(this.DepositStKindCd2_Label);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.DepositStKindCd1_Label);
            this.Controls.Add(this.DepositlnitStKind_Titl_Label);
            this.Controls.Add(this.DepositInitDspNo_Titl_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.DepositStKindCd2_tUltraBtn);
            this.Controls.Add(this.DepositStKindCd3_tUltraBtn);
            this.Controls.Add(this.DepositStKindCd4_tUltraBtn);
            this.Controls.Add(this.DepositStKindCd5_tUltraBtn);
            this.Controls.Add(this.DepositStKindCd6_tUltraBtn);
            this.Controls.Add(this.DepositStKindCd7_tUltraBtn);
            this.Controls.Add(this.DepositStKindCd8_tUltraBtn);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFUKK09060UA";
            this.Text = "�����ݒ�";
            this.Load += new System.EventHandler(this.SFUKK09060UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFUKK09060UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFUKK09060UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCdNm1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCdNm2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCdNm4_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCdNm3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCdNm8_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCdNm7_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCdNm6_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCdNm5_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCd1_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositInitDspNo_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCd2_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCd3_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCd4_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCd5_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCd6_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCd7_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCd8_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCd9_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCdNm9_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCd10_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositStKindCdNm10_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InitSelMoneyKindCd_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InitSelMoneyKindCdNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlwcDepoCallMonths_tComboEditor)).EndInit();
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

		private DepositSt depositSt;
		private DepositSt _depositStClone;	// ��r�pClone
		private DepositStAcs depositStAcs;
		private MoneyKindAcs _moneyKindAcs;
		private Hashtable _controlTable;
		private string _enterpriseCode;
		private int depositStMngCd = 0;				// �����ݒ�Ǘ�No�F0�Œ�

		// �ύX�t���O
		private bool _changeFlg = false;

		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canClose;

		// ��ʐ���p
		private ArrayList tneditCompList;
		private ArrayList teditCompList;

		private const string HTML_HEADER_TITLE = "�ݒ荀��";
		private const string HTML_HEADER_VALUE = "�ݒ�l";
		private const string HTML_UNREGISTER = "";

		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";
		private const string DELETE_MODE = "�폜���[�h";

        // �ҏW�O�̃R�[�h�ۑ��p
        private string _cachedValue = string.Empty;
        //private bool _continueFlag = true;                //DEL 2009/06/22 ���g�p�̈�

        // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
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
        // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
		#endregion
		
		# region Main
		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFUKK09060UA());
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
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.05</br>
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
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		public string GetHtmlCode()
		{
			string outCode = "";

			// tHtmlGenerate���i�̈����𐶐�����
			string [,] array = new string[13, 2];

			this.tHtmlGenerate1.Coltypes = new int[2];

			this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
			this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;

			if (this.Controls.Count != 0)
			{
				for (int i=0; i < this.Controls.Count; i++)
				{
					// �ݒ荀�ڃ^�C�g��
					if (this.Controls[i] is UltraLabel)
					{
						UltraLabel tLabel = (UltraLabel)this.Controls[i];
						int labelTag  = Convert.ToInt16(tLabel.Tag);
						if (labelTag == 1)
						{
							array[1,0]  = this.DepositInitDspNo_Titl_Label.Text;
						}
                        //else if(labelTag == 2)
                        //{
                        //    array[2,0]  = this.InitSelMoneyKindCd_Title_Label.Text;
                        //}
						else
						{
							array[labelTag, 0] = "�����ݒ����R�[�h " + tLabel.Text;
						}
					}
				}
			}
			// �e�[�u���^�C�g��
			array[0,0] = HTML_HEADER_TITLE;
			array[0,1] = HTML_HEADER_VALUE;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
			//array[13,0] = this.DepositCallMonths_Title_Label.Text;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA MODIFY START
            array[12, 0] = this.AlwcDepoCallMonths_Title_Label.Text;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA MODIFY END

			// �����ݒ�e�[�u���Ǎ�
			int status = this.depositStAcs.Read(out this.depositSt, this._enterpriseCode, this.depositStMngCd);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// �擾�������e���Z�b�g
				// ���������\�����
				array[1, 1] = this.depositSt.DepositInitDspNoName;

                //// �����I������R�[�h
                //if (this.depositSt.InitSelMoneyKindCd != 0)
                //{
                //    array[2, 1] = this.depositSt.InitSelMoneyKindCdNm;
                //}
				// �����ݒ����R�[�h
				if (this.depositSt.DepositStKindCd1 != 0)
				{
					array[2, 1] = this.depositSt.DepositStKindCdNm1;
				}
				if (this.depositSt.DepositStKindCd2 != 0)
				{
					array[3, 1] = this.depositSt.DepositStKindCdNm2;
				}
				if (this.depositSt.DepositStKindCd3 != 0)
				{
					array[4, 1] = this.depositSt.DepositStKindCdNm3;
				}
				if (this.depositSt.DepositStKindCd4 != 0)
				{
					array[5, 1] = this.depositSt.DepositStKindCdNm4;
				}
				if (this.depositSt.DepositStKindCd5 != 0)
				{
					array[6, 1] = this.depositSt.DepositStKindCdNm5;
				}
				if (this.depositSt.DepositStKindCd6 != 0)
				{
					array[7, 1] = this.depositSt.DepositStKindCdNm6;
				}
				if (this.depositSt.DepositStKindCd7 != 0)
				{
					array[8, 1] = this.depositSt.DepositStKindCdNm7;
				}
				if (this.depositSt.DepositStKindCd8 != 0)
				{
					array[9, 1] = this.depositSt.DepositStKindCdNm8;
				}
				if (this.depositSt.DepositStKindCd9 != 0)
				{
					array[10, 1] = this.depositSt.DepositStKindCdNm9;
				}
				if (this.depositSt.DepositStKindCd10 != 0)
				{
					array[11, 1] = this.depositSt.DepositStKindCdNm10;
				}
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
				//if (this.depositSt.DepositCallMonths != 0)
				//{
					//array[13, 1] = this.depositSt.DepositCallMonths.ToString() + "�����ȓ��𒊏o";
				//}
				//else
				//{
					// 2005.09.01 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					//array[13, 1] = HTML_UNREGISTER;
					//array[13, 1] = this.depositSt.DepositCallMonths.ToString() + "�������ɒ��o";
					// 2005.09.01 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
				//}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA MODIFY START
				array[12, 1] = this.depositSt.AlwcDepoCallMonthsCdName;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA MODIFY END

			}

			// �u���ݒ�v���Z�b�g
			for (int ix = 1; ix <  array.GetLength(0); ix++)
			{
				for (int iy = 1; iy <  array.GetLength(1); iy++)
				{
					if (array[ix, iy] == null)
					{
						array[ix, iy] = HTML_UNREGISTER;
					}
				}
			}

			// �f�[�^�̂Q�����z��݂̂��w�肵�āA�v���p�e�B���g�p���ăO���b�h�\������
			this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array,ref outCode);

			return outCode;
		}
		# endregion

		# region Private Methods
		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			// �����\���V�X�e���R���{�{�b�N�X
			DepositInitDspNo_tComboEditor.Items.Clear();
			// 2005.08.29 �R���{�{�b�N�X�̒��g�ύX >>>>>>>>>>>>>>>>>>>>>>> SATRT
//			DepositInitDspNo_tComboEditor.Items.Add(1, "�ꊇ");
//			DepositInitDspNo_tComboEditor.Items.Add(2, "�`�[");
//			DepositInitDspNo_tComboEditor.Items.Add(3, "�ꗗ");
//			DepositInitDspNo_tComboEditor.Items.Add(4, "���w��");
//			DepositInitDspNo_tComboEditor.Items.Add(5, "�����ꗗ");
//			DepositInitDspNo_tComboEditor.Items.Add(6, "�������`");
			DepositInitDspNo_tComboEditor.Items.Add(1, "�����^");
			//DepositInitDspNo_tComboEditor.Items.Add(2, "�󒍎w��^");         //DEL 2009/06/22 �s��Ή�[13580]
            DepositInitDspNo_tComboEditor.Items.Add(2, "����w��^");           //ADD 2009/06/22 �s��Ή�[13580]
            // 2005.08.29 �R���{�{�b�N�X�̒��g�ύX >>>>>>>>>>>>>>>>>>>>>>> END
			DepositInitDspNo_tComboEditor.MaxDropDownItems = DepositInitDspNo_tComboEditor.Items.Count;
			AlwcDepoCallMonths_tComboEditor.Items.Clear();
			AlwcDepoCallMonths_tComboEditor.Items.Add(0,"�����ς݂ł��Ăяo��");
			AlwcDepoCallMonths_tComboEditor.Items.Add(1,"���z�����ς݂͌Ăяo���Ȃ�");
			AlwcDepoCallMonths_tComboEditor.MaxDropDownItems = AlwcDepoCallMonths_tComboEditor.Items.Count;

		}

		/// <summary>
		/// �����ݒ�N���X�f�[�^�i�[�����i��ʏ��˓����ݒ�N���X�j
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʏ�񂩂�����ݒ�N���X�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		private void ScreenToDepositSt()
		{

			// �����\���V�X�e��
			this.depositSt.DepositInitDspNo = Convert.ToInt32(DepositInitDspNo_tComboEditor.SelectedItem.DataValue);
			//this.depositSt.InitSelMoneyKindCd = InitSelMoneyKindCd_tNedit.GetInt();
			//this.depositSt.InitSelMoneyKindCdNm = InitSelMoneyKindCdNm_tEdit.Text.TrimEnd();

			// �����ݒ����R�[�h
			this.depositSt.DepositStKindCd1  = DepositStKindCd1_tNedit.GetInt();
			this.depositSt.DepositStKindCd2  = DepositStKindCd2_tNedit.GetInt();
			this.depositSt.DepositStKindCd3  = DepositStKindCd3_tNedit.GetInt();
			this.depositSt.DepositStKindCd4  = DepositStKindCd4_tNedit.GetInt();
			this.depositSt.DepositStKindCd5  = DepositStKindCd5_tNedit.GetInt();
			this.depositSt.DepositStKindCd6  = DepositStKindCd6_tNedit.GetInt();
			this.depositSt.DepositStKindCd7  = DepositStKindCd7_tNedit.GetInt();
			this.depositSt.DepositStKindCd8  = DepositStKindCd8_tNedit.GetInt();
			this.depositSt.DepositStKindCd9	 = DepositStKindCd9_tNedit.GetInt();
			this.depositSt.DepositStKindCd10 = DepositStKindCd10_tNedit.GetInt();

			//�����ݒ���햼��
			this.depositSt.DepositStKindCdNm1  = DepositStKindCdNm1_tEdit.Text.Trim();
			this.depositSt.DepositStKindCdNm2  = DepositStKindCdNm2_tEdit.Text.Trim();
			this.depositSt.DepositStKindCdNm3  = DepositStKindCdNm3_tEdit.Text.Trim();
			this.depositSt.DepositStKindCdNm4  = DepositStKindCdNm4_tEdit.Text.Trim();
			this.depositSt.DepositStKindCdNm5  = DepositStKindCdNm5_tEdit.Text.Trim();
			this.depositSt.DepositStKindCdNm6  = DepositStKindCdNm6_tEdit.Text.Trim();
			this.depositSt.DepositStKindCdNm7  = DepositStKindCdNm7_tEdit.Text.Trim();
			this.depositSt.DepositStKindCdNm8  = DepositStKindCdNm8_tEdit.Text.Trim();
			this.depositSt.DepositStKindCdNm9  = DepositStKindCdNm9_tEdit.Text.Trim();
			this.depositSt.DepositStKindCdNm10 = DepositStKindCdNm10_tEdit.Text.Trim();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
			//this.depositSt.DepositCallMonths = DepositCallMonths_tNedit.GetInt();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
			this.depositSt.AlwcDepoCallMonthsCd = Convert.ToInt32(AlwcDepoCallMonths_tComboEditor.SelectedItem.DataValue);
		}

		/// <summary>
		///	�����ݒ�N���X�f�[�^�W�J�����i�����ݒ�N���X�ˉ�ʏ��j
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����ݒ�N���X�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		private void DepositStToScreen()
		{
			// �����\���V�X�e��
			DepositInitDspNo_tComboEditor.SelectedIndex = this.depositSt.DepositInitDspNo -1;

            //// �����ݒ����R�[�h
            //if (this.depositSt.InitSelMoneyKindCd != 0)
            //{
            //    //InitSelMoneyKindCd_tNedit.SetInt(this.depositSt.InitSelMoneyKindCd);
            //    InitSelMoneyKindCdNm_tEdit.Text = this.depositSt.InitSelMoneyKindCdNm;
            //}
            //else
            //{
            //    InitSelMoneyKindCd_tNedit.Clear();
            //    InitSelMoneyKindCdNm_tEdit.Clear();
            //}
			// �����ݒ����R�[�h
			if (this.depositSt.DepositStKindCd1 != 0)
			{
				DepositStKindCd1_tNedit.SetInt(this.depositSt.DepositStKindCd1);
				DepositStKindCdNm1_tEdit.Text = this.depositSt.DepositStKindCdNm1;
			}
			else
			{
				DepositStKindCd1_tNedit.Clear();
				DepositStKindCdNm1_tEdit.Clear();
			}
			if (this.depositSt.DepositStKindCd2 != 0)
			{
				DepositStKindCd2_tNedit.SetInt(this.depositSt.DepositStKindCd2);
				DepositStKindCdNm2_tEdit.Text = this.depositSt.DepositStKindCdNm2;
			}
			else
			{
				DepositStKindCd2_tNedit.Clear();
				DepositStKindCdNm2_tEdit.Clear();
			}
			if (this.depositSt.DepositStKindCd3 != 0)
			{
				DepositStKindCd3_tNedit.SetInt(this.depositSt.DepositStKindCd3);
				DepositStKindCdNm3_tEdit.Text = this.depositSt.DepositStKindCdNm3;
			}
			else
			{
				DepositStKindCd3_tNedit.Clear();
				DepositStKindCdNm3_tEdit.Clear();
			}
			if (this.depositSt.DepositStKindCd4 != 0)
			{
				DepositStKindCd4_tNedit.SetInt(this.depositSt.DepositStKindCd4);
				DepositStKindCdNm4_tEdit.Text = this.depositSt.DepositStKindCdNm4;
			}
			else
			{
				DepositStKindCd4_tNedit.Clear();
				DepositStKindCdNm4_tEdit.Clear();
			}
			if (this.depositSt.DepositStKindCd5 != 0)
			{
				DepositStKindCd5_tNedit.SetInt(this.depositSt.DepositStKindCd5);
				DepositStKindCdNm5_tEdit.Text = this.depositSt.DepositStKindCdNm5;
			}
			else
			{
				DepositStKindCd5_tNedit.Clear();
				DepositStKindCdNm5_tEdit.Clear();
			}
			if (this.depositSt.DepositStKindCd6 != 0)
			{
				DepositStKindCd6_tNedit.SetInt(this.depositSt.DepositStKindCd6);
				DepositStKindCdNm6_tEdit.Text = this.depositSt.DepositStKindCdNm6;
			}
			else
			{
				DepositStKindCd6_tNedit.Clear();
				DepositStKindCdNm6_tEdit.Clear();
			}
			if (this.depositSt.DepositStKindCd7 != 0)
			{
				DepositStKindCd7_tNedit.SetInt(this.depositSt.DepositStKindCd7);
				DepositStKindCdNm7_tEdit.Text = this.depositSt.DepositStKindCdNm7;
			}
			else
			{
				DepositStKindCd7_tNedit.Clear();
				DepositStKindCdNm7_tEdit.Clear();
			}
			if (this.depositSt.DepositStKindCd8 != 0)
			{
				DepositStKindCd8_tNedit.SetInt(this.depositSt.DepositStKindCd8);
				DepositStKindCdNm8_tEdit.Text = this.depositSt.DepositStKindCdNm8;
			}
			else
			{
				DepositStKindCd8_tNedit.Clear();
				DepositStKindCdNm8_tEdit.Clear();
			}
			if (this.depositSt.DepositStKindCd9 != 0)
			{
				DepositStKindCd9_tNedit.SetInt(this.depositSt.DepositStKindCd9);
				DepositStKindCdNm9_tEdit.Text = this.depositSt.DepositStKindCdNm9;
			}
			else
			{
				DepositStKindCd9_tNedit.Clear();
				DepositStKindCdNm9_tEdit.Clear();
			}
			if (this.depositSt.DepositStKindCd10 != 0)
			{
				DepositStKindCd10_tNedit.SetInt(this.depositSt.DepositStKindCd10);
				DepositStKindCdNm10_tEdit.Text = this.depositSt.DepositStKindCdNm10;
			}
			else
			{
				DepositStKindCd10_tNedit.Clear();
				DepositStKindCdNm10_tEdit.Clear();
			}
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
			//if (this.depositSt.DepositCallMonths != 0)
			//{
				//DepositCallMonths_tNedit.SetInt(this.depositSt.DepositCallMonths);
			//}
			//else
			//{
				// 2005.09.01 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				//DepositCallMonths_tNedit.SetInt(this.depositSt.DepositCallMonths);
				//DepositCallMonths_tNedit.Clear();
				// 2005.09.01 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
			//}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
			AlwcDepoCallMonths_tComboEditor.SelectedIndex = this.depositSt.AlwcDepoCallMonthsCd;
		}

		/// <summary>
		/// ��ʏ���������
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏��������s���܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		private void ScreenClear()
		{
			// �����\���V�X�e��
			DepositInitDspNo_tComboEditor.SelectedIndex = 0;

			//InitSelMoneyKindCd_tNedit.Clear();
			// �����ݒ����R�[�h
			DepositStKindCd1_tNedit.Clear();
			DepositStKindCd2_tNedit.Clear();
			DepositStKindCd3_tNedit.Clear();
			DepositStKindCd4_tNedit.Clear();
			DepositStKindCd5_tNedit.Clear();
			DepositStKindCd6_tNedit.Clear();
			DepositStKindCd7_tNedit.Clear();
			DepositStKindCd8_tNedit.Clear();
			DepositStKindCd9_tNedit.Clear();
			DepositStKindCd10_tNedit.Clear();

			InitSelMoneyKindCdNm_tEdit.Clear();
			// �����ݒ���햼��
			DepositStKindCdNm1_tEdit.Clear();
			DepositStKindCdNm2_tEdit.Clear();
			DepositStKindCdNm3_tEdit.Clear();
			DepositStKindCdNm4_tEdit.Clear();
			DepositStKindCdNm5_tEdit.Clear();
			DepositStKindCdNm6_tEdit.Clear();
			DepositStKindCdNm7_tEdit.Clear();
			DepositStKindCdNm8_tEdit.Clear();
			DepositStKindCdNm9_tEdit.Clear();
			DepositStKindCdNm10_tEdit.Clear();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
			//DepositCallMonths_tNedit.Clear();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
			AlwcDepoCallMonths_tComboEditor.SelectedIndex = 0;

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
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			int status = depositStAcs.Read(out this.depositSt, this._enterpriseCode, this.depositStMngCd);
			if (status == 0)
			{
				Mode_Label.Text = UPDATE_MODE;

				// �����ݒ�N���X��ʓW�J����
				DepositStToScreen();

                // ��ʏ�̐ݒ�
                EnableMonKindCodeFields(true, 0, true);
			}
			else
			{
				Mode_Label.Text = INSERT_MODE;

				// �f�[�^�N���X�V�K�쐬
				this.depositSt = new DepositSt();
				// ��ƃR�[�h
				this.depositSt.EnterpriseCode = this._enterpriseCode;
				// �����ݒ�Ǘ�No 0�Œ�
				this.depositSt.DepositStMngCd = this.depositStMngCd;
				// ���������\����ʔԍ� 
				this.depositSt.DepositInitDspNo = 1;
				// �����\�����ݒ� 
				this.depositSt.AlwcDepoCallMonthsCd = 0;
			}

			// �����ݒ�N���X�f�[�^�i�[
			ScreenToDepositSt();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
			//if(DepositCallMonths_tNedit.GetInt() == 0)
			//{
				//this.monce_Label.Text = "�������ɒ��o";
			//}
			//else
			//{
				//this.monce_Label.Text = "�����ȓ��𒊏o";
			//}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
			// ���ύX��r�p�N���[���쐬
			this._depositStClone = this.depositSt.Clone();

            // ADD 2008/10/15 �s��Ή�[6500] ---------->>>>>
            if (this.depositSt.DepositStKindCd1 == 0)
            {
                _cache1 = string.Empty;
            }
            else
            {
                _cache1 = this.depositSt.DepositStKindCd1.ToString();
            }
            if (this.depositSt.DepositStKindCd2 == 0)
            {
                _cache2 = string.Empty;
            }
            else
            {
                _cache2 = this.depositSt.DepositStKindCd2.ToString();
            }
            if (this.depositSt.DepositStKindCd3 == 0)
            {
                _cache3 = string.Empty;
            }
            else
            {
                _cache3 = this.depositSt.DepositStKindCd3.ToString();
            }
            if (this.depositSt.DepositStKindCd4 == 0)
            {
                _cache4 = string.Empty;
            }
            else
            {
                _cache4 = this.depositSt.DepositStKindCd4.ToString();
            }
            if (this.depositSt.DepositStKindCd5 == 0)
            {
                _cache5 = string.Empty;
            }
            else
            {
                _cache5 = this.depositSt.DepositStKindCd5.ToString();
            }
            if (this.depositSt.DepositStKindCd6 == 0)
            {
                _cache6 = string.Empty;
            }
            else
            {
                _cache6 = this.depositSt.DepositStKindCd6.ToString();
            }
            if (this.depositSt.DepositStKindCd7 == 0)
            {
                _cache7 = string.Empty;
            }
            else
            {
                _cache7 = this.depositSt.DepositStKindCd7.ToString();
            }
            if (this.depositSt.DepositStKindCd8 == 0)
            {
                _cache8 = string.Empty;
            }
            else
            {
                _cache8 = this.depositSt.DepositStKindCd8.ToString();
            }
            if (this.depositSt.DepositStKindCd9 == 0)
            {
                _cache9 = string.Empty;
            }
            else
            {
                _cache9 = this.depositSt.DepositStKindCd9.ToString();
            }
            if (this.depositSt.DepositStKindCd10 == 0)
            {
                _cache10 = string.Empty;
            }
            else
            {
                _cache10 = this.depositSt.DepositStKindCd10.ToString();
            }

            
            // ADD 2008/10/15 �s��Ή�[6500] ----------<<<<<
		}

		/// <summary>
		/// �����ݒ��ʓ��̓`�F�b�N����
		/// </summary>
		/// <param name="checkMessage">�G���[���b�Z�[�W</param>
		/// <returns>�G���[�R�[�h</returns>
		/// <remarks>
		/// <br>Note       : �����ݒ��ʂ̓��̓`�F�b�N�����܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		private int checkDisplay(ref string checkMessage)
		{
			int returnStatus = 0;
			int compIndex = 0;
			////bool _iniSelMonKiCdFlg = true;      //DEL 2009/06/22 ���g�p�̈�
            //bool _iniSelMonKiCdFlg = false;       //DEL 2009/06/22 ���g�p�̈�

			try
			{
				// ���������\�����
				// �R���{�{�b�N�X�͕K���ݒ肷��
            	if (this.DepositInitDspNo_tComboEditor.SelectedIndex < 0)
				{
					checkMessage = "���������\����ʂ����I���ł��B";
					returnStatus = 10;
					return returnStatus;
				}

                // ���o�^���Ȃ���(�ϊ����ɖ��o�^�`�F�b�N�����Ă���̂Ŋ�{�I�ɂ͂Ȃ�)
                checkMessage = "���o�^�̃R�[�h�͓o�^�ł��܂���B";
                //returnStatus = 11;
                if (this.DepositStKindCd1_Label.Text == "���o�^")
                {
                    return 11;
                }
                if (this.DepositStKindCd2_Label.Text == "���o�^")
                {
                    return 11;
                }
                if (this.DepositStKindCd3_Label.Text == "���o�^")
                {
                    return 11;
                }
                if (this.DepositStKindCd4_Label.Text == "���o�^")
                {
                    return 11;
                }
                if (this.DepositStKindCd5_Label.Text == "���o�^")
                {
                    return 11;
                }
                if (this.DepositStKindCd6_Label.Text == "���o�^")
                {
                    return 11;
                }
                if (this.DepositStKindCd7_Label.Text == "���o�^")
                {
                    return 11;
                }
                if (this.DepositStKindCd8_Label.Text == "���o�^")
                {
                    return 11;
                }
                if (this.DepositStKindCd9_Label.Text == "���o�^")
                {
                    return 11;
                }
                if (this.DepositStKindCd10_Label.Text == "���o�^")
                {
                    return 11;
                }
                checkMessage = string.Empty;

                // ADD 2008/10/10 �s��Ή�[6497] ---------->>>>>
                // ����Ȃ�
                if (String.IsNullOrEmpty(this.DepositStKindCd1_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.DepositStKindCd2_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.DepositStKindCd3_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.DepositStKindCd4_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.DepositStKindCd5_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.DepositStKindCd6_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.DepositStKindCd7_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.DepositStKindCd8_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.DepositStKindCd9_tNedit.Text.Trim()) &&
                    String.IsNullOrEmpty(this.DepositStKindCd10_tNedit.Text.Trim()))
                {
                    checkMessage = "�R�[�h���o�^����Ă��܂���B";
                    returnStatus = 100;
                    return returnStatus;
                }
                // ADD 2008/10/10 �s��Ή�[6497] ----------<<<<<

				// �����ݒ����R�[�h
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
				}

				// �d���`�F�b�N
				//bool isCash = false;      //DEL 2009/06/22 ���g�p�̈�
				for (int i = 0; i < this.tneditCompList.Count -1; i++)
				{
					int sourceCd = ((TNedit)tneditCompList[i]).GetInt();

					if (sourceCd == 0) continue;
                    //if (sourceCd == 1) isCash = true;			// 1:���������͂���Ă��邩�̔��f������

					for (int j = i +1; j < this.tneditCompList.Count; j++)
					{
						int destCd = ((TNedit)tneditCompList[j]).GetInt();

                        //if (destCd == 1) isCash = true;			// 1:���������͂���Ă��邩�̔��f������
						if (sourceCd == destCd)
						{
							checkMessage = "�R�[�h���d�����Ă��܂�";
							compIndex = j;
							returnStatus = 100;
							return returnStatus;
						}
					}
				}

                //// 1: �����͕K�{����
                //if (isCash == false)
                //{
                //    checkMessage = "�u1: ���ॏ��؎�v���ݒ肳��Ă��܂���";
                //    compIndex = 0;
                //    returnStatus = 100;
                //    return returnStatus;
                //}

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.21 TAKAHASHI ADD START
                // �����I������R�[�h
                //int IniSelMonKiCd = this.InitSelMoneyKindCd_tNedit.GetInt();

                //// ����R�[�h�P
                //if ((this.DepositStKindCd1_tNedit.DataText != "") && (IniSelMonKiCd == this.DepositStKindCd1_tNedit.GetInt()))
                //{
                //    return 0;
                //}
                //// ����R�[�h�Q
                //if ((this.DepositStKindCd2_tNedit.DataText != "") && (IniSelMonKiCd == this.DepositStKindCd2_tNedit.GetInt()))
                //{
                //    return 0;
                //}
                //// ����R�[�h�R
                //if ((this.DepositStKindCd3_tNedit.DataText != "") && (IniSelMonKiCd == this.DepositStKindCd3_tNedit.GetInt()))
                //{
                //    return 0;
                //}
                //// ����R�[�h�S
                //if ((this.DepositStKindCd4_tNedit.DataText != "") && (IniSelMonKiCd == this.DepositStKindCd4_tNedit.GetInt()))
                //{
                //    return 0;
                //}
                //// ����R�[�h�T
                //if ((this.DepositStKindCd5_tNedit.DataText != "") && (IniSelMonKiCd == this.DepositStKindCd5_tNedit.GetInt()))
                //{
                //    return 0;
                //}
                //// ����R�[�h�U
                //if ((this.DepositStKindCd6_tNedit.DataText != "") && (IniSelMonKiCd == this.DepositStKindCd6_tNedit.GetInt()))
                //{
                //    return 0;
                //}
                //// ����R�[�h�V
                //if ((this.DepositStKindCd7_tNedit.DataText != "") && (IniSelMonKiCd == this.DepositStKindCd7_tNedit.GetInt()))
                //{
                //    return 0;
                //}
                //// ����R�[�h�W
                //if ((this.DepositStKindCd8_tNedit.DataText != "") && (IniSelMonKiCd == this.DepositStKindCd8_tNedit.GetInt()))
                //{
                //    return 0;
                //}
                //// ����R�[�h�X
                //if ((this.DepositStKindCd9_tNedit.DataText != "") && (IniSelMonKiCd == this.DepositStKindCd9_tNedit.GetInt()))
                //{
                //    return 0;
                //}
                //// ����R�[�h�P�O
                //if ((this.DepositStKindCd10_tNedit.DataText != "") && (IniSelMonKiCd == this.DepositStKindCd10_tNedit.GetInt()))
                //{
                //    return 0;
                //}
                //else
                //{
                //    _iniSelMonKiCdFlg = false;
                //}

                //if (_iniSelMonKiCdFlg == false)
                //{
                //    checkMessage = "�����ݒ����R�[�h�̒�����I�����Ă��������B";
                //    returnStatus = 200;
                //}
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.21 TAKAHASHI ADD END

				return returnStatus;
			}
			finally
			{
				if (returnStatus != 0)
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
						"SFUKK09060U",							// �A�Z���u��ID
						checkMessage,	                        // �\�����郁�b�Z�[�W
						0,   									// �X�e�[�^�X�l
						MessageBoxButtons.OK);					// �\������{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					//�G���[�X�e�[�^�X�ɍ��킹�ăt�H�[�J�X�Z�b�g
					switch(returnStatus)
					{
						case 10 :	//���������\�����
						{
							this.DepositInitDspNo_tComboEditor.Focus();
							break;
						}

						case 100 :	//�����ݒ����R�[�h
						{
							((TNedit)this.tneditCompList[compIndex]).Focus();
							break;
						}

						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.21 TAKAHASHI ADD START
						case 200:  // �����I������R�[�h
						{
							//this.InitSelMoneyKindCd_tNedit.Focus();
							break;
						}
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.21 TAKAHASHI ADD END
					}
				}
			}
		}

		/// <summary>
		/// �����ݒ�ۑ�����
		/// </summary>
		/// <returns>�G���[�R�[�h</returns>
		/// <remarks>
		/// <br>Note       : �����ݒ���̕ۑ����s���܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		private int SaveDepositSt()
		{
			//��ʃf�[�^���̓`�F�b�N����
			string checkMessage = "";
			int chkSt = checkDisplay(ref checkMessage);
			if (chkSt != 0)
			{
				return 9;
			}

			// ��ʂ�������ݒ�N���X�Ƀf�[�^���Z�b�g���܂��B
			ScreenToDepositSt();

			// �����ݒ�o�^����
			int status = this.depositStAcs.Write(ref this.depositSt);
			// �r�����䏈��
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
					
					// �r�����䏈���̒��ɍŏ����Ή�
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._depositStClone = null;
					
					// �G���[���b�Z�[�W���o����UI��ʂ���鏈��
					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					return status;
				}
				default:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
						"SFUKK09060U",							// �A�Z���u��ID
						"�����ݒ�",                             // �v���O��������
						"SaveDepositSt",                        // ��������
						TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
						"�o�^�Ɏ��s���܂����B",			     	// �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this.depositStAcs,					    // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,					// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					// �r�����䏈���̒��ɍŏ����Ή�
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._depositStClone = null;

					// �G���[���b�Z�[�W���o����UI��ʂ����
					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}

					return status;
				}
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
		/// <br>Date       : 2005.08.05</br>
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
						"SFUKK09060U",							// �A�Z���u��ID
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
						"SFUKK09060U",							// �A�Z���u��ID
						"���ɑ��[�����폜����Ă��܂��B",	    // �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						MessageBoxButtons.OK);					// �\������{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					break;
				}
			}
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
			MoneyKindAcs moneyKindAcs = new MoneyKindAcs();
            
            // ----- iitani c ---------- start 2007.05.23
			//switch (moneyKindAcs.ExecuteGuid(this._enterpriseCode, 0, out moneyKind, "MONEYKINDGUIDEPARENT.XML"))
			switch (moneyKindAcs.ExecuteGuid(this._enterpriseCode, 0, out moneyKind, "MONEYKINDGUIDEPARENT.XML",1))
            // ----- iitani c ---------- end 2007.05.23
            {
				case 0:
                    //// ���z��ʏ��ύX����
                    //if (objectName == "InitSelMoneyKindCd_ultraButton")
                    //{
                    //    this.InitSelMoneyKindCd_tNedit.SetInt(moneyKind.MoneyKindCode);
                    //    this.InitSelMoneyKindCdNm_tEdit.Text = moneyKind.MoneyKindName;

                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
                    //    this.DepositStKindCd1_tNedit.Focus();
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
                    //}

					if (objectName == "DepositStKindCd1_tUltraBtn")
					{
						this.DepositStKindCd1_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.DepositStKindCdNm1_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache1 = moneyKind.MoneyKindCode.ToString();      // ADD 2008/10/10 �s��Ή�[6500]
                        EnableMonKindCodeFields(false, 2, true);

						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.DepositStKindCd2_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "DepositStKindCd2_tUltraBtn")
					{
						this.DepositStKindCd2_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.DepositStKindCdNm2_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache2 = moneyKind.MoneyKindCode.ToString();      // ADD 2008/10/10 �s��Ή�[6500]
                        EnableMonKindCodeFields(false, 3, true);

						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.DepositStKindCd3_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "DepositStKindCd3_tUltraBtn")
					{
						this.DepositStKindCd3_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.DepositStKindCdNm3_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache3 = moneyKind.MoneyKindCode.ToString();      // ADD 2008/10/10 �s��Ή�[6500]
                        EnableMonKindCodeFields(false, 4, true);

						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.DepositStKindCd4_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "DepositStKindCd4_tUltraBtn")
					{
						this.DepositStKindCd4_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.DepositStKindCdNm4_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache4 = moneyKind.MoneyKindCode.ToString();      // ADD 2008/10/10 �s��Ή�[6500]
                        EnableMonKindCodeFields(false, 5, true);

						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.DepositStKindCd5_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "DepositStKindCd5_tUltraBtn")
					{
						this.DepositStKindCd5_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.DepositStKindCdNm5_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache5 = moneyKind.MoneyKindCode.ToString();      // ADD 2008/10/10 �s��Ή�[6500]
                        EnableMonKindCodeFields(false, 6, true);

						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.DepositStKindCd6_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "DepositStKindCd6_tUltraBtn")
					{
						this.DepositStKindCd6_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.DepositStKindCdNm6_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache6 = moneyKind.MoneyKindCode.ToString();      // ADD 2008/10/10 �s��Ή�[6500]
                        EnableMonKindCodeFields(false, 7, true);

						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.DepositStKindCd7_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "DepositStKindCd7_tUltraBtn")
					{
						this.DepositStKindCd7_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.DepositStKindCdNm7_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache7 = moneyKind.MoneyKindCode.ToString();      // ADD 2008/10/10 �s��Ή�[6500]
                        EnableMonKindCodeFields(false, 8, true);

						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.DepositStKindCd8_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "DepositStKindCd8_tUltraBtn")
					{
						this.DepositStKindCd8_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.DepositStKindCdNm8_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache8 = moneyKind.MoneyKindCode.ToString();      // ADD 2008/10/10 �s��Ή�[6500]
                        EnableMonKindCodeFields(false, 9, true);

						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.DepositStKindCd9_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "DepositStKindCd9_tUltraBtn")
					{
						this.DepositStKindCd9_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.DepositStKindCdNm9_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache9 = moneyKind.MoneyKindCode.ToString();      // ADD 2008/10/10 �s��Ή�[6500]
                        EnableMonKindCodeFields(false, 10, true);

						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						this.DepositStKindCd10_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
					}

					if (objectName == "DepositStKindCd10_tUltraBtn")
					{
						this.DepositStKindCd10_tNedit.SetInt(moneyKind.MoneyKindCode);
						this.DepositStKindCdNm10_tEdit.Text = moneyKind.MoneyKindName;
                        this._cache10 = moneyKind.MoneyKindCode.ToString();      // ADD 2008/10/10 �s��Ή�[6500]
                        // ADD 2008/10/10 �s��Ή�[6498] ---------->>>>>
                        this.AlwcDepoCallMonths_tComboEditor.Focus();
                        // ADD 2008/10/10 �s��Ή�[6498] ----------<<<<<

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
						//this.DepositCallMonths_tNedit.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
					}

					break;

				case 1:
					break;
			}
		}
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.07 TAKAHASHI ADD END
		# endregion

		# region Control Events
		/// <summary>
		/// Form.Load �C�x���g(SFUKK09060UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		private void SFUKK09060UA_Load(object sender, System.EventArgs e)
		{
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList24 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			// �ۑ��{�^��
			this.Ok_Button.ImageList = imageList24;
			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			// ����{�^��
			this.Cancel_Button.ImageList = imageList24;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            // --- ADD 2009/03/19 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
            // �ŐV���{�^��
            this.Renewal_Button.ImageList = imageList16;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            // --- ADD 2009/03/19 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
			// �K�C�h�{�^��
			this.InitSelMoneyKindCd_ultraButton.ImageList			= imageList16;
			this.InitSelMoneyKindCd_ultraButton.Appearance.Image	= Size16_Index.STAR1;
			this.DepositStKindCd1_tUltraBtn.ImageList				= imageList16;
			this.DepositStKindCd1_tUltraBtn.Appearance.Image		= Size16_Index.STAR1;
			this.DepositStKindCd2_tUltraBtn.ImageList				= imageList16;
			this.DepositStKindCd2_tUltraBtn.Appearance.Image		= Size16_Index.STAR1;
			this.DepositStKindCd3_tUltraBtn.ImageList				= imageList16;
			this.DepositStKindCd3_tUltraBtn.Appearance.Image		= Size16_Index.STAR1;
			this.DepositStKindCd4_tUltraBtn.ImageList				= imageList16;
			this.DepositStKindCd4_tUltraBtn.Appearance.Image		= Size16_Index.STAR1;
			this.DepositStKindCd5_tUltraBtn.ImageList				= imageList16;
			this.DepositStKindCd5_tUltraBtn.Appearance.Image		= Size16_Index.STAR1;
			this.DepositStKindCd6_tUltraBtn.ImageList				= imageList16;
			this.DepositStKindCd6_tUltraBtn.Appearance.Image		= Size16_Index.STAR1;
			this.DepositStKindCd7_tUltraBtn.ImageList				= imageList16;
			this.DepositStKindCd7_tUltraBtn.Appearance.Image		= Size16_Index.STAR1;
			this.DepositStKindCd8_tUltraBtn.ImageList				= imageList16;
			this.DepositStKindCd8_tUltraBtn.Appearance.Image		= Size16_Index.STAR1;
			this.DepositStKindCd9_tUltraBtn.ImageList				= imageList16;
			this.DepositStKindCd9_tUltraBtn.Appearance.Image		= Size16_Index.STAR1;
			this.DepositStKindCd10_tUltraBtn.ImageList				= imageList16;
			this.DepositStKindCd10_tUltraBtn.Appearance.Image		= Size16_Index.STAR1;

            // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
            // �����l�擾
            if (this.depositSt.DepositStKindCd1 == 0)
            {
                _cache1 = string.Empty;
            }
            else
            {
                _cache1 = this.depositSt.DepositStKindCd1.ToString();
            }
            if (this.depositSt.DepositStKindCd2 == 0)
            {
                _cache2 = string.Empty;
            }
            else
            {
                _cache2 = this.depositSt.DepositStKindCd2.ToString();
            }
            if (this.depositSt.DepositStKindCd3 == 0)
            {
                _cache3 = string.Empty;
            }
            else
            {
                _cache3 = this.depositSt.DepositStKindCd3.ToString();
            }
            if (this.depositSt.DepositStKindCd4 == 0)
            {
                _cache4 = string.Empty;
            }
            else
            {
                _cache4 = this.depositSt.DepositStKindCd4.ToString();
            }
            if (this.depositSt.DepositStKindCd5 == 0)
            {
                _cache5 = string.Empty;
            }
            else
            {
                _cache5 = this.depositSt.DepositStKindCd5.ToString();
            }
            if (this.depositSt.DepositStKindCd6 == 0)
            {
                _cache6 = string.Empty;
            }
            else
            {
                _cache6 = this.depositSt.DepositStKindCd6.ToString();
            }
            if (this.depositSt.DepositStKindCd7 == 0)
            {
                _cache7 = string.Empty;
            }
            else
            {
                _cache7 = this.depositSt.DepositStKindCd7.ToString();
            }
            if (this.depositSt.DepositStKindCd8 == 0)
            {
                _cache8 = string.Empty;
            }
            else
            {
                _cache8 = this.depositSt.DepositStKindCd8.ToString();
            }
            if (this.depositSt.DepositStKindCd9 == 0)
            {
                _cache9 = string.Empty;
            }
            else
            {
                _cache9 = this.depositSt.DepositStKindCd9.ToString();
            }
            if (this.depositSt.DepositStKindCd10 == 0)
            {
                _cache10 = string.Empty;
            }
            else
            {
                _cache10 = this.depositSt.DepositStKindCd10.ToString();
            }
            // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<

			// ��ʏ����ݒ菈��
			ScreenInitialSetting();
		}

		/// <summary>
		/// Form.Closing �C�x���g(SFUKK09060UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		private void SFUKK09060UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// �t���[���̍ŏI�ŏ����Ή�
			this._depositStClone = null;

			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
			// �t�H�[�����\��������B
			//�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
			}
		}

		/// <summary>
		/// Form.VisibleChanged �C�x���g(SFUKK09060UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̕\���A��\�����ς�������ɔ������܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		private void SFUKK09060UA_VisibleChanged(object sender, System.EventArgs e)
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

			// �t���[���̍ŏI�ŏ���
			if (this._depositStClone != null)
			{
				return;
			}

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
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.21 TAKAHASHI DELETE START
//			if (InitSelMoneyKindCdInfoChange(0) != 0)
//			{
//				return;
//			}
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.21 TAKAHASHI DELETE END

			foreach (Control control in this._controlTable.Values)
			{
				if(control is TNedit)
				{
					if (control.Name.IndexOf("DepositStKindCd") == 0)
					{
						string depositStKindCdNm = "DepositStKindCdNm" + ((TNedit)control).Tag.ToString() + "_tEdit";
						TEdit depositStKindCdNm_tEdit	= ((TEdit)this._controlTable[depositStKindCdNm]);
						if(DepositStKindCdInfoChange(0,(TNedit)control,depositStKindCdNm_tEdit) != 0)
						{
							return;
						}
					}
				}
			}
			
			// �ۑ�����
			if (SaveDepositSt() != 0)
			{
				return;
			}

			// �t���[���̍ŏI�ŏ���
			this._depositStClone = null;

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
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			DialogResult dialogResult = DialogResult.Cancel;

			// �����ݒ�N���X�f�[�^�i�[
			ScreenToDepositSt();
			if (!this._depositStClone.Equals(depositSt))
			{
				// ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI DELETE START
//				switch (MessageBox.Show("�ҏW���̃f�[�^�����݂��܂�\r\n\r\n�o�^���Ă���낵���ł����H",
//										"�ۑ��m�F",
//										MessageBoxButtons.YesNoCancel,
//										MessageBoxIcon.Question))
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI DELETE END

				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
				DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
					"SFUKK09060U", 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
					null, 					                              // �\�����郁�b�Z�[�W
					0, 					                                  // �X�e�[�^�X�l
					MessageBoxButtons.YesNoCancel);                       // �\������{�^��

				switch(res)
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

				{
					case DialogResult.Yes :
					{
						foreach (Control control in this._controlTable.Values)
						{
							if(control is TNedit)
							{
								if (control.Name.IndexOf("DepositStKindCd") == 0)
								{
									string depositStKindCdNm = "DepositStKindCdNm" + ((TNedit)control).Tag.ToString() + "_tEdit";
									TEdit depositStKindCdNm_tEdit	= ((TEdit)this._controlTable[depositStKindCdNm]);
									if(DepositStKindCdInfoChange(0,(TNedit)control,depositStKindCdNm_tEdit) != 0)
									{
										return;
									}
								}
							}
						}

						if (SaveDepositSt() != 0)
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

			// �t���[���̍ŏI�ŏ���
			this._depositStClone = null;

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
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		private void MoneyKindGuide_Click(object sender, System.EventArgs e)
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
		/// Timer.Tick �C�x���g(SFUKK09060UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �^�C�}�[���N������Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			timer1.Enabled = false;
			ScreenReconstruction();
		}

		/// <summary>
		///	Control.Enter �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�[���</param>
		/// <remarks>
		/// <br>Note			:	Control���A�N�e�B�u�ɂȂ����ۂɔ������܂��B</br>
		/// <br>Programmer		:	23013 �q�@���l</br>
		/// <br>Date			:	2005.08.05</br>
		/// </remarks>
		private void tNedit_Enter(object sender, System.EventArgs e)
		{
            // �O�̒l��ۑ�
            this._cachedValue = ((Broadleaf.Library.Windows.Forms.TNedit)sender).Text.Trim();
            // �p����
            //_continueFlag = true;         //DEL 2009/06/22 ���g�p�̈�

			this._changeFlg = false;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.Leave �C�x���g(tNedit)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �����I������R�[�htNedit�𔲂������ɔ������܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.09.21</br>
		/// </remarks>
		private void tNedit_Leave(object sender, System.EventArgs e)
		{
			if (this.InitSelMoneyKindCd_tNedit.GetInt() == 0)
			{
				this.InitSelMoneyKindCd_tNedit.Clear();
				this.InitSelMoneyKindCdNm_tEdit.Clear();
			}
			else
			{
				if (this._changeFlg == true )
				{
					this._changeFlg = false;

                    int status = InitSelMoneyKindCdInfoChange(0);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        // "���o�^"

                    }
                    else if (status != 0)
                    {
                        this.InitSelMoneyKindCd_tNedit.SelectAll();
                    }
				}
			}

            // �L���b�V���N���A
            this._cachedValue = string.Empty;
		}

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
		/// ������ύX����(InitSelMoneyKindCdInfoChange)
		/// </summary>
		/// <param name="ix">���b�Z�[�W�\���L�� (0:���b�Z�[�W�\������  1:���b�Z�[�W�\�����Ȃ�)</param>
		/// <remarks>
		/// <br>Note		: �����R�[�h�ɂ��킹�ĕ\������Ă���������̕ύX���s���܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.12.20</br>
		/// </remarks>
		private int InitSelMoneyKindCdInfoChange(int ix)
		{
			int status = 0;

			// ����R�[�h����Ȃ�ANull��Ԃ�
            //if (this.InitSelMoneyKindCd_tNedit.GetInt() == 0)
            //{
            //    this.InitSelMoneyKindCdNm_tEdit.Text = "";
            //}
            //else
            //{
                //MoneyKind moneyKindInfo = new MoneyKind();

                //// PrimaryKey�����Z�b�g
                //moneyKindInfo.EnterpriseCode = this._enterpriseCode;
                //moneyKindInfo.PriceStCode    = 0;
                //moneyKindInfo.MoneyKindCode  = this.InitSelMoneyKindCd_tNedit.GetInt();

                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.06.05 T-Kidate START
                //// ���z��ʃ}�X�^�������擾
                ////status = this._moneyKindAcs.Read(ref moneyKindInfo);
                //moneyKindInfo.MoneyKindName = this.depositStAcs.GetDepsitStKindNm(this._enterpriseCode, InitSelMoneyKindCd_tNedit.GetInt());
                //if (moneyKindInfo.MoneyKindName == "")
                //{
                //    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //}
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.06.05 T-Kidate END

                //switch (status)
                //{
                //    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                //    {
                //        if (moneyKindInfo.LogicalDeleteCode != 0)
                //        {
                //            TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                //                emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                //                "SFUKK09060U",							// �A�Z���u��ID
                //                "�}�X�^����폜����Ă��܂��B",	        // �\�����郁�b�Z�[�W
                //                status,									// �X�e�[�^�X�l
                //                MessageBoxButtons.OK);					// �\������{�^��

                //            this.InitSelMoneyKindCdNm_tEdit.Text = "�폜��";
                //            this.InitSelMoneyKindCdNm_tEdit.Focus();

                //            status = -2;
                //        }
                //        else
                //        {
                //            this.InitSelMoneyKindCdNm_tEdit.Text = moneyKindInfo.MoneyKindName;
                //        }

                //        break;
                //    }

                //    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                //    {
                //        TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                //            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                //            "SFUKK09060U",							// �A�Z���u��ID
                //            "�}�X�^�ɓo�^����Ă��܂���B",	        // �\�����郁�b�Z�[�W
                //            status,									// �X�e�[�^�X�l
                //            MessageBoxButtons.OK);					// �\������{�^��

                //        this.InitSelMoneyKindCdNm_tEdit.Text = "���o�^";
                //        this.InitSelMoneyKindCdNm_tEdit.Focus();

                //        break;
                //    }

                //    default:
                //    {
                //        this.InitSelMoneyKindCdNm_tEdit.Text = "";

                //        break;
                //    }
                //}
            //}

			return status;
		}

		/// <summary>
		/// �R���|�[�l���g���n�b�V���Ɋi�[����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �R���|�[�l���g���n�b�V���Ɋi�[�������s���܂��B</br>
		/// <br>Programmer	: 23013 �q�@���l</br>
		/// <br>Date		: 2005.08.05</br>
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
		/// <summary>
		/// �R���|�[�l���g���n�b�V���Ɋi�[����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �R���|�[�l���g���n�b�V���Ɋi�[�������s���܂��B</br>
		/// <br>Programmer	: 23013 �q�@���l</br>
		/// <br>Date		: 2005.08.05</br>
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

		/// <summary>
		///	Control.Leave�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�[���</param>
		/// <remarks>
		/// <br>Programmer		:	23013 �q�@���l</br>
		/// <br>Date			:	2005.08.05</br>
		/// </remarks>
		private void DepositStKindCd_tNedit_Leave(object sender, System.EventArgs e)
		{
            // �g�����y�я_����S���Ȃ����ߍ폜

            //string depositStKindCd			= "DepositStKindCd"	 + ((TNedit)sender).Tag.ToString() + "_tNedit";
            //TNedit depositStKindCd_tNedit	= ((TNedit)this._controlTable[depositStKindCd]);

            //string depositStKindCdNm	    = "DepositStKindCdNm"	 + ((TNedit)sender).Tag.ToString() + "_tEdit";
            //TEdit depositStKindCdNm_tEdit	= ((TEdit)this._controlTable[depositStKindCdNm]);

            //if(depositStKindCd_tNedit.GetInt() == 0)
            //{
            //    depositStKindCd_tNedit.Clear();
            //    depositStKindCdNm_tEdit.Clear();
            //}
            //else
            //{
            //    if (this._changeFlg == true )
            //    {
            //        this._changeFlg = false;

            //        if (DepositStKindCdInfoChange(0,depositStKindCd_tNedit,depositStKindCdNm_tEdit) != 0)
            //        {
            //            depositStKindCd_tNedit.SelectAll();
            //        }
            //    }
            //}
        }

        #region �e�t�B�[���h���Ƃ�Leave���\�b�h��ǉ�

        /// <summary>
        /// �t�B�[���h����Leave���\�b�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepositStKindCd1_tNedit_Leave(object sender, System.EventArgs e)
        {
            if (DepositStKindCd1_tNedit.GetInt() == 0)
            {
                this.DepositStKindCd1_tNedit.Clear();
                this.DepositStKindCdNm1_tEdit.Clear();
                this.DepositStKindCd2_tNedit.Clear();
                this.DepositStKindCdNm2_tEdit.Clear();
                this.DepositStKindCd3_tNedit.Clear();
                this.DepositStKindCdNm3_tEdit.Clear();
                this.DepositStKindCd4_tNedit.Clear();
                this.DepositStKindCdNm4_tEdit.Clear();
                this.DepositStKindCd5_tNedit.Clear();
                this.DepositStKindCdNm5_tEdit.Clear();
                this.DepositStKindCd6_tNedit.Clear();
                this.DepositStKindCdNm6_tEdit.Clear();
                this.DepositStKindCd7_tNedit.Clear();
                this.DepositStKindCdNm7_tEdit.Clear();
                this.DepositStKindCd8_tNedit.Clear();
                this.DepositStKindCdNm8_tEdit.Clear();
                this.DepositStKindCd9_tNedit.Clear();
                this.DepositStKindCdNm9_tEdit.Clear();
                this.DepositStKindCd10_tNedit.Clear();
                this.DepositStKindCdNm10_tEdit.Clear();
            }
            // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
            //else
            //{
            //    if (this._changeFlg == true)
            //    {
            //        this._changeFlg = false;

            //        if (DepositStKindCdInfoChange(0, this.DepositStKindCd1_tNedit, this.DepositStKindCdNm1_tEdit) != 0)
            //        {
            //            this.DepositStKindCd1_tNedit.SelectAll();
            //        }
            //    }
            //}
            // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
        }

        /// <summary>
        /// �t�B�[���h����Leave���\�b�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepositStKindCd2_tNedit_Leave(object sender, System.EventArgs e)
        {
            if (DepositStKindCd2_tNedit.GetInt() == 0)
            {
                this.DepositStKindCd2_tNedit.Clear();
                this.DepositStKindCdNm2_tEdit.Clear();
                this.DepositStKindCd3_tNedit.Clear();
                this.DepositStKindCdNm3_tEdit.Clear();
                this.DepositStKindCd4_tNedit.Clear();
                this.DepositStKindCdNm4_tEdit.Clear();
                this.DepositStKindCd5_tNedit.Clear();
                this.DepositStKindCdNm5_tEdit.Clear();
                this.DepositStKindCd6_tNedit.Clear();
                this.DepositStKindCdNm6_tEdit.Clear();
                this.DepositStKindCd7_tNedit.Clear();
                this.DepositStKindCdNm7_tEdit.Clear();
                this.DepositStKindCd8_tNedit.Clear();
                this.DepositStKindCdNm8_tEdit.Clear();
                this.DepositStKindCd9_tNedit.Clear();
                this.DepositStKindCdNm9_tEdit.Clear();
                this.DepositStKindCd10_tNedit.Clear();
                this.DepositStKindCdNm10_tEdit.Clear();
            }
            else
            {
                if (this._changeFlg == true)
                {
                    this._changeFlg = false;
                    // DEL 2008/10/10 �s��Ή�[6494][6496] ��
                    //if (DepositStKindCdInfoChange(0, this.DepositStKindCd1_tNedit, this.DepositStKindCdNm1_tEdit) != 0)
                    if (DepositStKindCdInfoChange(0, this.DepositStKindCd2_tNedit, this.DepositStKindCdNm2_tEdit) != 0) // ADD 2008/10/10 �s��Ή�[6494][6496]
                    {
                        this.DepositStKindCd1_tNedit.SelectAll();
                    }
                }
            }
        }

        /// <summary>
        /// �t�B�[���h����Leave���\�b�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepositStKindCd3_tNedit_Leave(object sender, System.EventArgs e)
        {
            if (DepositStKindCd3_tNedit.GetInt() == 0)
            {
                this.DepositStKindCd3_tNedit.Clear();
                this.DepositStKindCdNm3_tEdit.Clear();
                this.DepositStKindCd4_tNedit.Clear();
                this.DepositStKindCdNm4_tEdit.Clear();
                this.DepositStKindCd5_tNedit.Clear();
                this.DepositStKindCdNm5_tEdit.Clear();
                this.DepositStKindCd6_tNedit.Clear();
                this.DepositStKindCdNm6_tEdit.Clear();
                this.DepositStKindCd7_tNedit.Clear();
                this.DepositStKindCdNm7_tEdit.Clear();
                this.DepositStKindCd8_tNedit.Clear();
                this.DepositStKindCdNm8_tEdit.Clear();
                this.DepositStKindCd9_tNedit.Clear();
                this.DepositStKindCdNm9_tEdit.Clear();
                this.DepositStKindCd10_tNedit.Clear();
                this.DepositStKindCdNm10_tEdit.Clear();
            }
            else
            {
                if (this._changeFlg == true)
                {
                    this._changeFlg = false;
                    // DEL 2008/10/10 �s��Ή�[6494][6496] ��
                    //if (DepositStKindCdInfoChange(0, this.DepositStKindCd1_tNedit, this.DepositStKindCdNm1_tEdit) != 0)
                    if (DepositStKindCdInfoChange(0, this.DepositStKindCd3_tNedit, this.DepositStKindCdNm3_tEdit) != 0) // ADD 2008/10/10 �s��Ή�[6494][6496]
                    {
                        this.DepositStKindCd1_tNedit.SelectAll();
                    }
                }
            }
        }
        /// <summary>
        /// �t�B�[���h����Leave���\�b�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepositStKindCd4_tNedit_Leave(object sender, System.EventArgs e)
        {
            if (DepositStKindCd4_tNedit.GetInt() == 0)
            {
                this.DepositStKindCd4_tNedit.Clear();
                this.DepositStKindCdNm4_tEdit.Clear();
                this.DepositStKindCd5_tNedit.Clear();
                this.DepositStKindCdNm5_tEdit.Clear();
                this.DepositStKindCd6_tNedit.Clear();
                this.DepositStKindCdNm6_tEdit.Clear();
                this.DepositStKindCd7_tNedit.Clear();
                this.DepositStKindCdNm7_tEdit.Clear();
                this.DepositStKindCd8_tNedit.Clear();
                this.DepositStKindCdNm8_tEdit.Clear();
                this.DepositStKindCd9_tNedit.Clear();
                this.DepositStKindCdNm9_tEdit.Clear();
                this.DepositStKindCd10_tNedit.Clear();
                this.DepositStKindCdNm10_tEdit.Clear();
            }
            else
            {
                if (this._changeFlg == true)
                {
                    this._changeFlg = false;
                    // DEL 2008/10/10 �s��Ή�[6494][6496] ��
                    //if (DepositStKindCdInfoChange(0, this.DepositStKindCd1_tNedit, this.DepositStKindCdNm1_tEdit) != 0)
                    if (DepositStKindCdInfoChange(0, this.DepositStKindCd4_tNedit, this.DepositStKindCdNm4_tEdit) != 0) // ADD 2008/10/10 �s��Ή�[6494][6496]
                    {
                        this.DepositStKindCd1_tNedit.SelectAll();
                    }
                }
            }
        }
        /// <summary>
        /// �t�B�[���h����Leave���\�b�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepositStKindCd5_tNedit_Leave(object sender, System.EventArgs e)
        {
            if (DepositStKindCd5_tNedit.GetInt() == 0)
            {
                this.DepositStKindCd5_tNedit.Clear();
                this.DepositStKindCdNm5_tEdit.Clear();
                this.DepositStKindCd6_tNedit.Clear();
                this.DepositStKindCdNm6_tEdit.Clear();
                this.DepositStKindCd7_tNedit.Clear();
                this.DepositStKindCdNm7_tEdit.Clear();
                this.DepositStKindCd8_tNedit.Clear();
                this.DepositStKindCdNm8_tEdit.Clear();
                this.DepositStKindCd9_tNedit.Clear();
                this.DepositStKindCdNm9_tEdit.Clear();
                this.DepositStKindCd10_tNedit.Clear();
                this.DepositStKindCdNm10_tEdit.Clear();
            }
            else
            {
                if (this._changeFlg == true)
                {
                    this._changeFlg = false;
                    // DEL 2008/10/10 �s��Ή�[6494][6496] ��
                    //if (DepositStKindCdInfoChange(0, this.DepositStKindCd1_tNedit, this.DepositStKindCdNm1_tEdit) != 0)
                    if (DepositStKindCdInfoChange(0, this.DepositStKindCd5_tNedit, this.DepositStKindCdNm5_tEdit) != 0) // ADD 2008/10/10 �s��Ή�[6494][6496]
                    {
                        this.DepositStKindCd1_tNedit.SelectAll();
                    }
                }
            }
        }

        /// <summary>
        /// �t�B�[���h����Leave���\�b�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepositStKindCd6_tNedit_Leave(object sender, System.EventArgs e)
        {
            if (DepositStKindCd6_tNedit.GetInt() == 0)
            {
                this.DepositStKindCd6_tNedit.Clear();
                this.DepositStKindCdNm6_tEdit.Clear();
                this.DepositStKindCd7_tNedit.Clear();
                this.DepositStKindCdNm7_tEdit.Clear();
                this.DepositStKindCd8_tNedit.Clear();
                this.DepositStKindCdNm8_tEdit.Clear();
                this.DepositStKindCd9_tNedit.Clear();
                this.DepositStKindCdNm9_tEdit.Clear();
                this.DepositStKindCd10_tNedit.Clear();
                this.DepositStKindCdNm10_tEdit.Clear();
            }
            else
            {
                if (this._changeFlg == true)
                {
                    this._changeFlg = false;
                    // DEL 2008/10/10 �s��Ή�[6494][6496] ��
                    //if (DepositStKindCdInfoChange(0, this.DepositStKindCd1_tNedit, this.DepositStKindCdNm1_tEdit) != 0)
                    if (DepositStKindCdInfoChange(0, this.DepositStKindCd6_tNedit, this.DepositStKindCdNm6_tEdit) != 0) // ADD 2008/10/10 �s��Ή�[6494][6496]
                    {
                        this.DepositStKindCd1_tNedit.SelectAll();
                    }
                }
            }
        }

        /// <summary>
        /// �t�B�[���h����Leave���\�b�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepositStKindCd7_tNedit_Leave(object sender, System.EventArgs e)
        {
            if (DepositStKindCd7_tNedit.GetInt() == 0)
            {
                this.DepositStKindCd7_tNedit.Clear();
                this.DepositStKindCdNm7_tEdit.Clear();
                this.DepositStKindCd8_tNedit.Clear();
                this.DepositStKindCdNm8_tEdit.Clear();
                this.DepositStKindCd9_tNedit.Clear();
                this.DepositStKindCdNm9_tEdit.Clear();
                this.DepositStKindCd10_tNedit.Clear();
                this.DepositStKindCdNm10_tEdit.Clear();
            }
            else
            {
                if (this._changeFlg == true)
                {
                    this._changeFlg = false;
                    // DEL 2008/10/10 �s��Ή�[6494][6496] ��
                    //if (DepositStKindCdInfoChange(0, this.DepositStKindCd1_tNedit, this.DepositStKindCdNm1_tEdit) != 0)
                    if (DepositStKindCdInfoChange(0, this.DepositStKindCd7_tNedit, this.DepositStKindCdNm7_tEdit) != 0) // ADD 2008/10/10 �s��Ή�[6494][6496]
                    {
                        this.DepositStKindCd1_tNedit.SelectAll();
                    }
                }
            }
        }

        /// <summary>
        /// �t�B�[���h����Leave���\�b�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepositStKindCd8_tNedit_Leave(object sender, System.EventArgs e)
        {
            if (DepositStKindCd8_tNedit.GetInt() == 0)
            {
                this.DepositStKindCd8_tNedit.Clear();
                this.DepositStKindCdNm8_tEdit.Clear();
                this.DepositStKindCd9_tNedit.Clear();
                this.DepositStKindCdNm9_tEdit.Clear();
                this.DepositStKindCd10_tNedit.Clear();
                this.DepositStKindCdNm10_tEdit.Clear();
            }
            else
            {
                if (this._changeFlg == true)
                {
                    this._changeFlg = false;
                    // DEL 2008/10/10 �s��Ή�[6494][6496] ��
                    //if (DepositStKindCdInfoChange(0, this.DepositStKindCd1_tNedit, this.DepositStKindCdNm1_tEdit) != 0)
                    if (DepositStKindCdInfoChange(0, this.DepositStKindCd8_tNedit, this.DepositStKindCdNm8_tEdit) != 0) // ADD 2008/10/10 �s��Ή�[6494][6496]
                    {
                        this.DepositStKindCd1_tNedit.SelectAll();
                    }
                }
            }
        }

        /// <summary>
        /// �t�B�[���h����Leave���\�b�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepositStKindCd9_tNedit_Leave(object sender, System.EventArgs e)
        {
            if (DepositStKindCd9_tNedit.GetInt() == 0)
            {
                this.DepositStKindCd9_tNedit.Clear();
                this.DepositStKindCdNm9_tEdit.Clear();
                this.DepositStKindCd10_tNedit.Clear();
                this.DepositStKindCdNm10_tEdit.Clear();
            }
            else
            {
                if (this._changeFlg == true)
                {
                    this._changeFlg = false;
                    // DEL 2008/10/10 �s��Ή�[6494][6496] ��
                    //if (DepositStKindCdInfoChange(0, this.DepositStKindCd1_tNedit, this.DepositStKindCdNm1_tEdit) != 0)
                    if (DepositStKindCdInfoChange(0, this.DepositStKindCd9_tNedit, this.DepositStKindCdNm9_tEdit) != 0) // ADD 2008/10/10 �s��Ή�[6494][6496]
                    {
                        this.DepositStKindCd1_tNedit.SelectAll();
                    }
                }
            }
        }

        /// <summary>
        /// �t�B�[���h����Leave���\�b�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepositStKindCd10_tNedit_Leave(object sender, System.EventArgs e)
        {
            if (DepositStKindCd10_tNedit.GetInt() == 0)
            {
                this.DepositStKindCd10_tNedit.Clear();
                this.DepositStKindCdNm10_tEdit.Clear();
            }
            else
            {
                if (this._changeFlg == true)
                {
                    this._changeFlg = false;
                    // DEL 2008/10/10 �s��Ή�[6494][6496] ��
                    //if (DepositStKindCdInfoChange(0, this.DepositStKindCd1_tNedit, this.DepositStKindCdNm1_tEdit) != 0)
                    if (DepositStKindCdInfoChange(0, this.DepositStKindCd10_tNedit, this.DepositStKindCdNm10_tEdit) != 0)   // ADD 2008/10/10 �s��Ή�[6494][6496]
                    {
                        this.DepositStKindCd1_tNedit.SelectAll();
                    }
                }
            }
        }

        #endregion // �e�t�B�[���h���Ƃ�Leave���\�b�h��ǉ�

        /*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ������ύX����(DepositStKindCdInfoChange)
		/// </summary>
		/// <param name="ix">���b�Z�[�W�\���L�� (0:���b�Z�[�W�\������  1:���b�Z�[�W�\�����Ȃ�)</param>
		/// <param name="depositStKindCd_tNedit">���z���TNedit</param>
		/// <param name="depositStKindCdNm_tEdit">���z���TEdit</param>
		/// <remarks>
		/// <br>Note		: �����R�[�h�ɂ��킹�ĕ\������Ă���������̕ύX���s���܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.12.20</br>
		/// </remarks>
		private int DepositStKindCdInfoChange(int ix, TNedit depositStKindCd_tNedit, TEdit depositStKindCdNm_tEdit)
		{
			int status = 0;

			// ����R�[�h����Ȃ�ANull��Ԃ�
			if (depositStKindCd_tNedit.GetInt() == 0)
			{
				depositStKindCdNm_tEdit.Text = "";
			}
			else
			{
				MoneyKind moneyKindInfo = new MoneyKind();

				// PrimaryKey�����Z�b�g
				moneyKindInfo.EnterpriseCode = this._enterpriseCode;
				moneyKindInfo.PriceStCode    = 0;
				moneyKindInfo.MoneyKindCode  = depositStKindCd_tNedit.GetInt();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.05.27 T-Kidate START
                // ���z��ʃ}�X�^�������擾
                //status = this._moneyKindAcs.Read(ref moneyKindInfo);
                moneyKindInfo.MoneyKindName = this.depositStAcs.GetDepsitStKindNm(this._enterpriseCode, depositStKindCd_tNedit.GetInt());
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
								"SFUKK09060U",							// �A�Z���u��ID
								"�}�X�^����폜����Ă��܂��B",	        // �\�����郁�b�Z�[�W
								status,									// �X�e�[�^�X�l
								MessageBoxButtons.OK);					// �\������{�^��

							depositStKindCdNm_tEdit.Text = "�폜��";
							depositStKindCd_tNedit.Focus();

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

                                // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                //depositStKindCd_tNedit.Clear();
                                //if (!String.IsNullOrEmpty(this._cachedValue.Trim()))
                                //{
                                //    depositStKindCd_tNedit.Text = this._cachedValue;
                                //    this._cachedValue = string.Empty;
                                //}
                                //depositStKindCd_tNedit.Focus();
                                //_continueFlag = false;
                                // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<

                                status = -2;    // ADD 2008/10/10 �s��Ή�[6500]
                            }
                            else
                            {
                                depositStKindCdNm_tEdit.Text = moneyKindInfo.MoneyKindName;
                            }
						}

						break;
					}

					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					{
						TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
							"SFUKK09060U",							// �A�Z���u��ID
							"�}�X�^�ɓo�^����Ă��܂���B",	        // �\�����郁�b�Z�[�W
							status,									// �X�e�[�^�X�l
							MessageBoxButtons.OK);					// �\������{�^��

						depositStKindCdNm_tEdit.Text = "���o�^";
						depositStKindCd_tNedit.Focus();

						break;
					}

					default:
					{
						depositStKindCdNm_tEdit.Text = "";

						break;
					}
				}
			}

			return status;
		}

        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
            bool correctCode = false;
            bool isEmpty = false;
            // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<

            // ���̎擾 ============================================ //
            switch (e.PrevCtrl.Name)
            {

                #region ���������\����ʑI�� [DepositInitDspNo_tComboEditor]
                case "DepositInitDspNo_tComboEditor":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // �����I������R�[�h��
                                    //e.NextCtrl = this.InitSelMoneyKindCd_tNedit;
                                    e.NextCtrl = this.DepositStKindCd1_tNedit;
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
                #endregion // ���������\����ʑI�� [DepositInitDspNo_tComboEditor]

                #region �����I������R�[�h [InitSelMoneyKindCd_tNedit]
                case "InitSelMoneyKindCd_tNedit":
                    {
                        string code = this.InitSelMoneyKindCd_tNedit.Text.Trim();

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
                                        e.NextCtrl = this.InitSelMoneyKindCd_ultraButton;
                                    }
                                    else
                                    {
                                        // ���͂���Ă���Γ��͐ݒ����R�[�h1��
                                        e.NextCtrl = this.DepositStKindCd1_tNedit;
                                        // tArrowControl��tNedit_Enter()�𖳎����邽�߂̏���
                                        this._cachedValue = this.DepositStKindCd1_tNedit.Text.Trim();
                                    }

                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ���������\����ʑI����
                                    e.NextCtrl = this.DepositInitDspNo_tComboEditor;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �����I������R�[�h [InitSelMoneyKindCd_tNedit]

                #region �����I������K�C�h [InitSelMoneyKindCd_ultraButton]
                case "InitSelMoneyKindCd_ultraButton":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // ���͐ݒ����R�[�h1��
                                    e.NextCtrl = this.DepositStKindCd1_tNedit;
                                    this._cachedValue = this.DepositStKindCd1_tNedit.Text.Trim();
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ���������\����ʑI����
                                    e.NextCtrl = this.DepositInitDspNo_tComboEditor;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �����I������K�C�h [InitSelMoneyKindCd_ultraButton]

                #region ���͐ݒ����R�[�h1 [DepositStKindCd1_tNedit]
                case "DepositStKindCd1_tNedit":
                    {
                        string code = this.DepositStKindCd1_tNedit.Text.Trim();
                        // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                        // ���͂��ꂽ�l�̃`�F�b�N
                        if (String.IsNullOrEmpty(code))
                        {
                            // ��
                            isEmpty = true;
                            this._cache1 = string.Empty;
                            // 2�Ԗڈȍ~��Disable��
                            EnableMonKindCodeFields(false, 2, false);
                        }
                        else if(code.Equals("0"))
                        {
                            // �l��߂�
                            this.DepositStKindCd1_tNedit.Text = this._cache1;
                        }
                        else
                        {
                            // �R�[�h�`�F�b�N                                     
                            if (DepositStKindCdInfoChange(0, DepositStKindCd1_tNedit, DepositStKindCdNm1_tEdit) == 0)
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
                                this.DepositStKindCd1_tNedit.Text = this._cache1;
                            }
                        }
                        // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                        
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
                                        e.NextCtrl = this.DepositStKindCd1_tUltraBtn;
                                        // 2�Ԗڈȍ~��Disable��
                                        //EnableMonKindCodeFields(false, 2, false); // DEL 2008/10/10 �s��Ή�[6500]
                                    }
                                    else
                                    {
                                        // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                        //// ���͂���Ă����2�Ԗڂ�Enable��
                                        //EnableMonKindCodeFields(false, 2, true);
                                        //// ���͐ݒ����R�[�h2��
                                        //e.NextCtrl = this.DepositStKindCd2_tNedit;
                                        //this._cachedValue = this.DepositStKindCd2_tNedit.Text.Trim();
                                        // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<

                                        // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������2��
                                            e.NextCtrl = this.DepositStKindCd2_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h�s���Ȃ�ړ��s��
                                            e.NextCtrl = this.DepositStKindCd1_tNedit;
                                            DepositStKindCd1_tNedit.Focus();
                                            DepositStKindCd1_tNedit.SelectAll();
                                        }
                                        // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                        

                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    //// �����I������R�[�h��
                                    ////e.NextCtrl = this.InitSelMoneyKindCd_tNedit;
                                    //e.NextCtrl = this.DepositInitDspNo_tComboEditor;
                                    // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<

                                    // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
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
                                            e.NextCtrl = this.DepositStKindCd2_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h�s���Ȃ�ړ��s��
                                            e.NextCtrl = this.DepositStKindCd1_tNedit;
                                            DepositStKindCd1_tNedit.Focus();
                                            DepositStKindCd1_tNedit.SelectAll();
                                        }
                                    }
                                    // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // ���͐ݒ����R�[�h1 [DepositStKindCd1_tNedit]

                #region ���͐ݒ����R�[�h1�K�C�h [DepositStKindCd1_tUltraBtn]
                case "DepositStKindCd1_tUltraBtn":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 2��Enable�Ȃ炻�����
                                    if (this.DepositStKindCd2_tNedit.Enabled)
                                    {
                                        // ���͐ݒ����R�[�h2��
                                        e.NextCtrl = this.DepositStKindCd2_tNedit;
                                        this._cachedValue = this.DepositStKindCd2_tNedit.Text.Trim();
                                    }
                                    else
                                    {
                                        // �����ϓ`�[�ďo�敪�I����
                                        e.NextCtrl = this.AlwcDepoCallMonths_tComboEditor;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // �����I������R�[�h��
                                    //e.NextCtrl = this.InitSelMoneyKindCd_tNedit;
                                    e.NextCtrl = this.DepositInitDspNo_tComboEditor;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // ���͐ݒ����R�[�h1�K�C�h [DepositStKindCd1_tUltraBtn]

                #region ���͐ݒ����R�[�h2 [DepositStKindCd2_tNedit]
                case "DepositStKindCd2_tNedit":
                    {
                        string code = this.DepositStKindCd2_tNedit.Text.Trim();

                        // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                        // ���͂��ꂽ�l�̃`�F�b�N
                        if (String.IsNullOrEmpty(code))
                        {
                            // ��
                            isEmpty = true;
                            this._cache2 = string.Empty;
                            // 3�Ԗڈȍ~��Disable��
                            EnableMonKindCodeFields(false, 3, false);
                        }
                        else if (code.Equals("0"))
                        {
                            // �l��߂�
                            this.DepositStKindCd2_tNedit.Text = this._cache2;
                        }
                        else
                        {
                            // �R�[�h�`�F�b�N                                     
                            if (DepositStKindCdInfoChange(0, DepositStKindCd2_tNedit, DepositStKindCdNm2_tEdit) == 0)
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
                                this.DepositStKindCd2_tNedit.Text = this._cache2;
                            }
                        }
                        // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<

                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    //if (String.IsNullOrEmpty(code))
                                    //{
                                    //    // �󔒂̏ꍇ�̓K�C�h�{�^����
                                    //    e.NextCtrl = this.DepositStKindCd2_tUltraBtn;
                                    //    // 3�Ԗڂ�Disable��
                                    //    EnableMonKindCodeFields(false, 3, false);
                                    //}
                                    //else
                                    //{
                                    //    // ���͂���Ă����3�Ԗڂ�Enable��
                                    //    EnableMonKindCodeFields(false, 3, true);
                                    //    // ���͐ݒ����R�[�h3��
                                    //    e.NextCtrl = this.DepositStKindCd3_tNedit;
                                    //    this._cachedValue = this.DepositStKindCd3_tNedit.Text.Trim();
                                    //}
                                    // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ�̓K�C�h�{�^����
                                        e.NextCtrl = this.DepositStKindCd2_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������3��
                                            e.NextCtrl = this.DepositStKindCd3_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.DepositStKindCd2_tNedit;
                                            DepositStKindCd2_tNedit.Focus();
                                            DepositStKindCd2_tNedit.SelectAll();
                                        }
                                    }
                                    // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    //// ���͐ݒ����R�[�h1��
                                    //e.NextCtrl = this.DepositStKindCd1_tNedit;
                                    //this._cachedValue = this.DepositStKindCd1_tNedit.Text.Trim();
                                    // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<

                                    // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ��1��
                                        e.NextCtrl = this.DepositStKindCd1_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������1��
                                            e.NextCtrl = this.DepositStKindCd1_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.DepositStKindCd2_tNedit;
                                            DepositStKindCd2_tNedit.Focus();
                                            DepositStKindCd2_tNedit.SelectAll();
                                        }
                                    }
                                    // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // ���͐ݒ����R�[�h2 [DepositStKindCd2_tNedit]

                #region ���͐ݒ����R�[�h2�K�C�h [DepositStKindCd2_tUltraBtn]
                case "DepositStKindCd2_tUltraBtn":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 3��Enable�Ȃ炻�����
                                    if (this.DepositStKindCd3_tNedit.Enabled)
                                    {
                                        // ���͐ݒ����R�[�h3��
                                        e.NextCtrl = this.DepositStKindCd3_tNedit;
                                        this._cachedValue = this.DepositStKindCd3_tNedit.Text.Trim();
                                    }
                                    else
                                    {
                                        // �����ϓ`�[�ďo�敪�I����
                                        e.NextCtrl = this.AlwcDepoCallMonths_tComboEditor;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ���͐ݒ����R�[�h1��
                                    e.NextCtrl = this.DepositStKindCd1_tNedit;
                                    this._cachedValue = this.DepositStKindCd1_tNedit.Text.Trim();
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // ���͐ݒ����R�[�h2�K�C�h [DepositStKindCd2_tUltraBtn]

                #region ���͐ݒ����R�[�h3 [DepositStKindCd3_tNedit]
                case "DepositStKindCd3_tNedit":
                    {
                        string code = this.DepositStKindCd3_tNedit.Text.Trim();

                        // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                        // ���͂��ꂽ�l�̃`�F�b�N
                        if (String.IsNullOrEmpty(code))
                        {
                            // ��
                            isEmpty = true;
                            this._cache3 = string.Empty;
                            // 4�Ԗڈȍ~��Disable��
                            EnableMonKindCodeFields(false, 4, false);
                        }
                        else if (code.Equals("0"))
                        {
                            // �l��߂�
                            this.DepositStKindCd3_tNedit.Text = this._cache3;
                        }
                        else
                        {
                            // �R�[�h�`�F�b�N                                     
                            if (DepositStKindCdInfoChange(0, DepositStKindCd3_tNedit, DepositStKindCdNm3_tEdit) == 0)
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
                                this.DepositStKindCd3_tNedit.Text = this._cache3;
                            }
                        }
                        // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<

                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    //if (String.IsNullOrEmpty(code))
                                    //{
                                    //    // �󔒂̏ꍇ�̓K�C�h�{�^����
                                    //    e.NextCtrl = this.DepositStKindCd3_tUltraBtn;
                                    //    // 4�Ԗڂ�Disable��
                                    //    EnableMonKindCodeFields(false, 4, false);
                                    //}
                                    //else
                                    //{
                                    //    // ���͂���Ă����4�Ԗڂ�Enable��
                                    //    EnableMonKindCodeFields(false, 4, true);
                                    //    // ���͐ݒ����R�[�h4��
                                    //    e.NextCtrl = this.DepositStKindCd4_tNedit;
                                    //    this._cachedValue = this.DepositStKindCd4_tNedit.Text.Trim();
                                    //}
                                    // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ�̓K�C�h�{�^����
                                        e.NextCtrl = this.DepositStKindCd3_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������4��
                                            e.NextCtrl = this.DepositStKindCd4_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.DepositStKindCd3_tNedit;
                                            DepositStKindCd3_tNedit.Focus();
                                            DepositStKindCd3_tNedit.SelectAll();
                                        }
                                    }
                                    // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    //// ���͐ݒ����R�[�h2��
                                    //e.NextCtrl = this.DepositStKindCd2_tNedit;
                                    //this._cachedValue = this.DepositStKindCd2_tNedit.Text.Trim();
                                    // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<

                                    // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ��2��
                                        e.NextCtrl = this.DepositStKindCd2_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������2��
                                            e.NextCtrl = this.DepositStKindCd2_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.DepositStKindCd3_tNedit;
                                            DepositStKindCd3_tNedit.Focus();
                                            DepositStKindCd3_tNedit.SelectAll();
                                        }
                                    }
                                    // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // ���͐ݒ����R�[�h3 [DepositStKindCd3_tNedit]

                #region ���͐ݒ����R�[�h3�K�C�h [DepositStKindCd3_tUltraBtn]
                case "DepositStKindCd3_tUltraBtn":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 4��Enable�Ȃ炻�����
                                    if (this.DepositStKindCd4_tNedit.Enabled)
                                    {
                                        // ���͐ݒ����R�[�h4��
                                        e.NextCtrl = this.DepositStKindCd4_tNedit;
                                        this._cachedValue = this.DepositStKindCd4_tNedit.Text.Trim();
                                    }
                                    else
                                    {
                                        // �����ϓ`�[�ďo�敪�I����
                                        e.NextCtrl = this.AlwcDepoCallMonths_tComboEditor;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ���͐ݒ����R�[�h2��
                                    e.NextCtrl = this.DepositStKindCd2_tNedit;
                                    this._cachedValue = this.DepositStKindCd2_tNedit.Text.Trim();
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // ���͐ݒ����R�[�h3�K�C�h [DepositStKindCd3_tUltraBtn]

                #region ���͐ݒ����R�[�h4 [DepositStKindCd4_tNedit]
                case "DepositStKindCd4_tNedit":
                    {
                        string code = this.DepositStKindCd4_tNedit.Text.Trim();
                        // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                        // ���͂��ꂽ�l�̃`�F�b�N
                        if (String.IsNullOrEmpty(code))
                        {
                            // ��
                            isEmpty = true;
                            this._cache4 = string.Empty;
                            // 5�Ԗڈȍ~��Disable��
                            EnableMonKindCodeFields(false, 5, false);
                        }
                        else if (code.Equals("0"))
                        {
                            // �l��߂�
                            this.DepositStKindCd4_tNedit.Text = this._cache4;
                        }
                        else
                        {
                            // �R�[�h�`�F�b�N                                     
                            if (DepositStKindCdInfoChange(0, DepositStKindCd4_tNedit, DepositStKindCdNm4_tEdit) == 0)
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
                                this.DepositStKindCd4_tNedit.Text = this._cache4;
                            }
                        }
                        // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<

                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    //if (String.IsNullOrEmpty(code))
                                    //{
                                    //    // �󔒂̏ꍇ�̓K�C�h�{�^����
                                    //    e.NextCtrl = this.DepositStKindCd4_tUltraBtn;
                                    //    // 5�Ԗڂ�Disable��
                                    //    EnableMonKindCodeFields(false, 5, false);
                                    //}
                                    //else
                                    //{
                                    //    // ���͂���Ă����5�Ԗڂ�Enable��
                                    //    EnableMonKindCodeFields(false, 5, true);
                                    //    // ���͐ݒ����R�[�h5��
                                    //    e.NextCtrl = this.DepositStKindCd5_tNedit;
                                    //    this._cachedValue = this.DepositStKindCd5_tNedit.Text.Trim();
                                    //}
                                    // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ�̓K�C�h�{�^����
                                        e.NextCtrl = this.DepositStKindCd4_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������5��
                                            e.NextCtrl = this.DepositStKindCd5_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.DepositStKindCd4_tNedit;
                                            DepositStKindCd4_tNedit.Focus();
                                            DepositStKindCd4_tNedit.SelectAll();
                                        }
                                    }
                                    // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    //// ���͐ݒ����R�[�h3��
                                    //e.NextCtrl = this.DepositStKindCd3_tNedit;
                                    //this._cachedValue = this.DepositStKindCd3_tNedit.Text.Trim();
                                    // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<

                                    // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ��3��
                                        e.NextCtrl = this.DepositStKindCd3_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������3��
                                            e.NextCtrl = this.DepositStKindCd3_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.DepositStKindCd4_tNedit;
                                            DepositStKindCd4_tNedit.Focus();
                                            DepositStKindCd4_tNedit.SelectAll();
                                        }
                                    }
                                    // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // ���͐ݒ����R�[�h4 [DepositStKindCd4_tNedit]

                #region ���͐ݒ����R�[�h4�K�C�h [DepositStKindCd4_tUltraBtn]
                case "DepositStKindCd4_tUltraBtn":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 5��Enable�Ȃ炻�����
                                    if (this.DepositStKindCd5_tNedit.Enabled)
                                    {
                                        // ���͐ݒ����R�[�h5��
                                        e.NextCtrl = this.DepositStKindCd5_tNedit;
                                        this._cachedValue = this.DepositStKindCd5_tNedit.Text.Trim();
                                    }
                                    else
                                    {
                                        // �����ϓ`�[�ďo�敪�I����
                                        e.NextCtrl = this.AlwcDepoCallMonths_tComboEditor;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ���͐ݒ����R�[�h3��
                                    e.NextCtrl = this.DepositStKindCd3_tNedit;
                                    this._cachedValue = this.DepositStKindCd3_tNedit.Text.Trim();
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // ���͐ݒ����R�[�h4�K�C�h [DepositStKindCd4_tUltraBtn]

                #region ���͐ݒ����R�[�h5 [DepositStKindCd5_tNedit]
                case "DepositStKindCd5_tNedit":
                    {
                        string code = this.DepositStKindCd5_tNedit.Text.Trim();
                        // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                        // ���͂��ꂽ�l�̃`�F�b�N
                        if (String.IsNullOrEmpty(code))
                        {
                            // ��
                            isEmpty = true;
                            this._cache5 = string.Empty;
                            // 6�Ԗڈȍ~��Disable��
                            EnableMonKindCodeFields(false, 6, false);
                        }
                        else if (code.Equals("0"))
                        {
                            // �l��߂�
                            this.DepositStKindCd5_tNedit.Text = this._cache5;
                        }
                        else
                        {
                            // �R�[�h�`�F�b�N                                     
                            if (DepositStKindCdInfoChange(0, DepositStKindCd5_tNedit, DepositStKindCdNm5_tEdit) == 0)
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
                                this.DepositStKindCd5_tNedit.Text = this._cache5;
                            }
                        }
                        // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    //if (String.IsNullOrEmpty(code))
                                    //{
                                    //    // �󔒂̏ꍇ�̓K�C�h�{�^����
                                    //    e.NextCtrl = this.DepositStKindCd5_tUltraBtn;
                                    //    // 6�Ԗڂ�Disable��
                                    //    EnableMonKindCodeFields(false, 6, false);
                                    //}
                                    //else
                                    //{
                                    //    // ���͂���Ă����6�Ԗڂ�Enable��
                                    //    EnableMonKindCodeFields(false, 6, true);
                                    //    // ���͐ݒ����R�[�h6��
                                    //    e.NextCtrl = this.DepositStKindCd6_tNedit;
                                    //    this._cachedValue = this.DepositStKindCd6_tNedit.Text.Trim();
                                    //}
                                    // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ�̓K�C�h�{�^����
                                        e.NextCtrl = this.DepositStKindCd5_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������6��
                                            e.NextCtrl = this.DepositStKindCd6_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.DepositStKindCd5_tNedit;
                                            DepositStKindCd5_tNedit.Focus();
                                            DepositStKindCd5_tNedit.SelectAll();
                                        }
                                    }
                                    // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    //// ���͐ݒ����R�[�h4��
                                    //e.NextCtrl = this.DepositStKindCd4_tNedit;
                                    //this._cachedValue = this.DepositStKindCd4_tNedit.Text.Trim();
                                    // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<

                                    // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ��4��
                                        e.NextCtrl = this.DepositStKindCd4_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������4��
                                            e.NextCtrl = this.DepositStKindCd4_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.DepositStKindCd5_tNedit;
                                            DepositStKindCd5_tNedit.Focus();
                                            DepositStKindCd5_tNedit.SelectAll();
                                        }
                                    }
                                    // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // ���͐ݒ����R�[�h5 [DepositStKindCd5_tNedit]

                #region ���͐ݒ����R�[�h5�K�C�h [DepositStKindCd5_tUltraBtn]
                case "DepositStKindCd5_tUltraBtn":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 6��Enable�Ȃ炻�����
                                    if (this.DepositStKindCd6_tNedit.Enabled)
                                    {
                                        // ���͐ݒ����R�[�h6��
                                        e.NextCtrl = this.DepositStKindCd6_tNedit;
                                        this._cachedValue = this.DepositStKindCd6_tNedit.Text.Trim();
                                    }
                                    else
                                    {
                                        // �����ϓ`�[�ďo�敪�I����
                                        e.NextCtrl = this.AlwcDepoCallMonths_tComboEditor;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ���͐ݒ����R�[�h4��
                                    e.NextCtrl = this.DepositStKindCd4_tNedit;
                                    this._cachedValue = this.DepositStKindCd4_tNedit.Text.Trim();
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // ���͐ݒ����R�[�h5�K�C�h [DepositStKindCd5_tUltraBtn]

                #region ���͐ݒ����R�[�h6 [DepositStKindCd6_tNedit]
                case "DepositStKindCd6_tNedit":
                    {
                        string code = this.DepositStKindCd6_tNedit.Text.Trim();
                        // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                        // ���͂��ꂽ�l�̃`�F�b�N
                        if (String.IsNullOrEmpty(code))
                        {
                            // ��
                            isEmpty = true;
                            this._cache6 = string.Empty;
                            // 7�Ԗڈȍ~��Disable��
                            EnableMonKindCodeFields(false, 7, false);
                        }
                        else if (code.Equals("0"))
                        {
                            // �l��߂�
                            this.DepositStKindCd6_tNedit.Text = this._cache6;
                        }
                        else
                        {
                            // �R�[�h�`�F�b�N                                     
                            if (DepositStKindCdInfoChange(0, DepositStKindCd6_tNedit, DepositStKindCdNm6_tEdit) == 0)
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
                                this.DepositStKindCd6_tNedit.Text = this._cache6;
                            }
                        }
                        // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    //if (String.IsNullOrEmpty(code))
                                    //{
                                    //    // �󔒂̏ꍇ�̓K�C�h�{�^����
                                    //    e.NextCtrl = this.DepositStKindCd6_tUltraBtn;
                                    //    // 7�Ԗڂ�Disable��
                                    //    EnableMonKindCodeFields(false, 7, false);
                                    //}
                                    //else
                                    //{
                                    //    // ���͂���Ă����7�Ԗڂ�Enable��
                                    //    EnableMonKindCodeFields(false, 7, true);
                                    //    // ���͐ݒ����R�[�h7��
                                    //    e.NextCtrl = this.DepositStKindCd7_tNedit;
                                    //    this._cachedValue = this.DepositStKindCd7_tNedit.Text.Trim();
                                    //}
                                    // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ�̓K�C�h�{�^����
                                        e.NextCtrl = this.DepositStKindCd6_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������7��
                                            e.NextCtrl = this.DepositStKindCd7_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.DepositStKindCd6_tNedit;
                                            DepositStKindCd6_tNedit.Focus();
                                            DepositStKindCd6_tNedit.SelectAll();
                                        }
                                    }
                                    // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    //// ���͐ݒ����R�[�h5��
                                    //e.NextCtrl = this.DepositStKindCd5_tNedit;
                                    //this._cachedValue = this.DepositStKindCd5_tNedit.Text.Trim();
                                    // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ��5��
                                        e.NextCtrl = this.DepositStKindCd5_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������5��
                                            e.NextCtrl = this.DepositStKindCd5_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.DepositStKindCd6_tNedit;
                                            DepositStKindCd6_tNedit.Focus();
                                            DepositStKindCd6_tNedit.SelectAll();
                                        }
                                    }
                                    // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // ���͐ݒ����R�[�h6 [DepositStKindCd6_tNedit]

                #region ���͐ݒ����R�[�h6�K�C�h [DepositStKindCd6_tUltraBtn]
                case "DepositStKindCd6_tUltraBtn":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 7��Enable�Ȃ炻�����
                                    if (this.DepositStKindCd7_tNedit.Enabled)
                                    {
                                        // ���͐ݒ����R�[�h7��
                                        e.NextCtrl = this.DepositStKindCd7_tNedit;
                                        this._cachedValue = this.DepositStKindCd7_tNedit.Text.Trim();
                                    }
                                    else
                                    {
                                        // �����ϓ`�[�ďo�敪�I����
                                        e.NextCtrl = this.AlwcDepoCallMonths_tComboEditor;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ���͐ݒ����R�[�h5��
                                    e.NextCtrl = this.DepositStKindCd5_tNedit;
                                    this._cachedValue = this.DepositStKindCd5_tNedit.Text.Trim();
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // ���͐ݒ����R�[�h6�K�C�h [DepositStKindCd6_tUltraBtn]

                #region ���͐ݒ����R�[�h7 [DepositStKindCd7_tNedit]
                case "DepositStKindCd7_tNedit":
                    {
                        string code = this.DepositStKindCd7_tNedit.Text.Trim();
                        // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                        // ���͂��ꂽ�l�̃`�F�b�N
                        if (String.IsNullOrEmpty(code))
                        {
                            // ��
                            isEmpty = true;
                            this._cache7 = string.Empty;
                            // 8�Ԗڈȍ~��Disable��
                            EnableMonKindCodeFields(false, 8, false);
                        }
                        else if (code.Equals("0"))
                        {
                            // �l��߂�
                            this.DepositStKindCd7_tNedit.Text = this._cache7;
                        }
                        else
                        {
                            // �R�[�h�`�F�b�N                                     
                            if (DepositStKindCdInfoChange(0, DepositStKindCd7_tNedit, DepositStKindCdNm7_tEdit) == 0)
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
                                this.DepositStKindCd7_tNedit.Text = this._cache7;
                            }
                        }
                        // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    //if (String.IsNullOrEmpty(code))
                                    //{
                                    //    // �󔒂̏ꍇ�̓K�C�h�{�^����
                                    //    e.NextCtrl = this.DepositStKindCd7_tUltraBtn;
                                    //    // 8�Ԗڂ�Disable��
                                    //    EnableMonKindCodeFields(false, 8, false);
                                    //}
                                    //else
                                    //{
                                    //    // ���͂���Ă����8�Ԗڂ�Enable��
                                    //    EnableMonKindCodeFields(false, 8, true);
                                    //    // ���͐ݒ����R�[�h8��
                                    //    e.NextCtrl = this.DepositStKindCd8_tNedit;
                                    //    this._cachedValue = this.DepositStKindCd8_tNedit.Text.Trim();
                                    //}
                                    // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ�̓K�C�h�{�^����
                                        e.NextCtrl = this.DepositStKindCd7_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������8��
                                            e.NextCtrl = this.DepositStKindCd8_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.DepositStKindCd7_tNedit;
                                            DepositStKindCd7_tNedit.Focus();
                                            DepositStKindCd7_tNedit.SelectAll();
                                        }
                                    }
                                    // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    //// ���͐ݒ����R�[�h6��
                                    //e.NextCtrl = this.DepositStKindCd6_tNedit;
                                    //this._cachedValue = this.DepositStKindCd6_tNedit.Text.Trim();
                                    // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ��6��
                                        e.NextCtrl = this.DepositStKindCd6_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������6��
                                            e.NextCtrl = this.DepositStKindCd6_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.DepositStKindCd7_tNedit;
                                            DepositStKindCd7_tNedit.Focus();
                                            DepositStKindCd7_tNedit.SelectAll();
                                        }
                                    }
                                    // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // ���͐ݒ����R�[�h7 [DepositStKindCd7_tNedit]

                #region ���͐ݒ����R�[�h7�K�C�h [DepositStKindCd7_tUltraBtn]
                case "DepositStKindCd7_tUltraBtn":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 8��Enable�Ȃ炻�����
                                    if (this.DepositStKindCd8_tNedit.Enabled)
                                    {
                                        // ���͐ݒ����R�[�h8��
                                        e.NextCtrl = this.DepositStKindCd8_tNedit;
                                        this._cachedValue = this.DepositStKindCd8_tNedit.Text.Trim();
                                    }
                                    else
                                    {
                                        // �����ϓ`�[�ďo�敪�I����
                                        e.NextCtrl = this.AlwcDepoCallMonths_tComboEditor;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ���͐ݒ����R�[�h6��
                                    e.NextCtrl = this.DepositStKindCd6_tNedit;
                                    this._cachedValue = this.DepositStKindCd6_tNedit.Text.Trim();
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // ���͐ݒ����R�[�h7�K�C�h [DepositStKindCd7_tUltraBtn]

                #region ���͐ݒ����R�[�h8 [DepositStKindCd8_tNedit]
                case "DepositStKindCd8_tNedit":
                    {
                        string code = this.DepositStKindCd8_tNedit.Text.Trim();
                        // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                        // ���͂��ꂽ�l�̃`�F�b�N
                        if (String.IsNullOrEmpty(code))
                        {
                            // ��
                            isEmpty = true;
                            this._cache8 = string.Empty;
                            // 9�Ԗڈȍ~��Disable��
                            EnableMonKindCodeFields(false, 9, false);
                        }
                        else if (code.Equals("0"))
                        {
                            // �l��߂�
                            this.DepositStKindCd8_tNedit.Text = this._cache8;
                        }
                        else
                        {
                            // �R�[�h�`�F�b�N                                     
                            if (DepositStKindCdInfoChange(0, DepositStKindCd8_tNedit, DepositStKindCdNm8_tEdit) == 0)
                            {
                                // �R�[�h�͐�����
                                correctCode = true;

                                // �R�[�h����������΃L���b�V�����X�V
                                this._cache8 = code;
                                // 9�Ԗڂ�Enable��
                                EnableMonKindCodeFields(false, 9, true);
                            }
                            else
                            {
                                // �R�[�h�s��

                                // �l��߂�
                                this.DepositStKindCd8_tNedit.Text = this._cache8;
                            }
                        }
                        // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    //if (String.IsNullOrEmpty(code))
                                    //{
                                    //    // �󔒂̏ꍇ�̓K�C�h�{�^����
                                    //    e.NextCtrl = this.DepositStKindCd8_tUltraBtn;
                                    //    // 9�Ԗڂ�Disable��
                                    //    EnableMonKindCodeFields(false, 9, false);
                                    //}
                                    //else
                                    //{
                                    //    // ���͂���Ă����9�Ԗڂ�Enable��
                                    //    EnableMonKindCodeFields(false, 9, true);
                                    //    // ���͐ݒ����R�[�h9��
                                    //    e.NextCtrl = this.DepositStKindCd9_tNedit;
                                    //    this._cachedValue = this.DepositStKindCd9_tNedit.Text.Trim();
                                    //}
                                    // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ�̓K�C�h�{�^����
                                        e.NextCtrl = this.DepositStKindCd8_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������9��
                                            e.NextCtrl = this.DepositStKindCd9_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.DepositStKindCd8_tNedit;
                                            DepositStKindCd8_tNedit.Focus();
                                            DepositStKindCd8_tNedit.SelectAll();
                                        }
                                    }
                                    // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    //// ���͐ݒ����R�[�h7��
                                    //e.NextCtrl = this.DepositStKindCd7_tNedit;
                                    //this._cachedValue = this.DepositStKindCd7_tNedit.Text.Trim();
                                    // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ��7��
                                        e.NextCtrl = this.DepositStKindCd7_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������7��
                                            e.NextCtrl = this.DepositStKindCd7_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.DepositStKindCd8_tNedit;
                                            DepositStKindCd8_tNedit.Focus();
                                            DepositStKindCd8_tNedit.SelectAll();
                                        }
                                    }
                                    // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // ���͐ݒ����R�[�h8 [DepositStKindCd8_tNedit]

                #region ���͐ݒ����R�[�h8�K�C�h [DepositStKindCd8_tUltraBtn]
                case "DepositStKindCd8_tUltraBtn":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 9��Enable�Ȃ炻�����
                                    if (this.DepositStKindCd9_tNedit.Enabled)
                                    {
                                        // ���͐ݒ����R�[�h9��
                                        e.NextCtrl = this.DepositStKindCd9_tNedit;
                                        this._cachedValue = this.DepositStKindCd9_tNedit.Text.Trim();
                                    }
                                    else
                                    {
                                        // �����ϓ`�[�ďo�敪�I����
                                        e.NextCtrl = this.AlwcDepoCallMonths_tComboEditor;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ���͐ݒ����R�[�h7��
                                    e.NextCtrl = this.DepositStKindCd7_tNedit;
                                    this._cachedValue = this.DepositStKindCd7_tNedit.Text.Trim();
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // ���͐ݒ����R�[�h8�K�C�h [DepositStKindCd8_tUltraBtn]

                #region ���͐ݒ����R�[�h9 [DepositStKindCd9_tNedit]
                case "DepositStKindCd9_tNedit":
                    {
                        string code = this.DepositStKindCd9_tNedit.Text.Trim();
                        // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                        // ���͂��ꂽ�l�̃`�F�b�N
                        if (String.IsNullOrEmpty(code))
                        {
                            // ��
                            isEmpty = true;
                            this._cache9 = string.Empty;
                            // 10�Ԗڈȍ~��Disable��
                            EnableMonKindCodeFields(false, 10, false);
                        }
                        else if (code.Equals("0"))
                        {
                            // �l��߂�
                            this.DepositStKindCd9_tNedit.Text = this._cache9;
                        }
                        else
                        {
                            // �R�[�h�`�F�b�N                                     
                            if (DepositStKindCdInfoChange(0, DepositStKindCd9_tNedit, DepositStKindCdNm9_tEdit) == 0)
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
                                this.DepositStKindCd9_tNedit.Text = this._cache9;
                            }
                        }
                        // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    //if (String.IsNullOrEmpty(code))
                                    //{
                                    //    // �󔒂̏ꍇ�̓K�C�h�{�^����
                                    //    e.NextCtrl = this.DepositStKindCd9_tUltraBtn;
                                    //    // 10�Ԗڂ�Disable��
                                    //    EnableMonKindCodeFields(false, 10, false);
                                    //}
                                    //else
                                    //{
                                    //    // ���͂���Ă����10�Ԗڂ�Enable��
                                    //    EnableMonKindCodeFields(false, 10, true);
                                    //    // ���͐ݒ����R�[�h10��
                                    //    e.NextCtrl = this.DepositStKindCd10_tNedit;
                                    //    this._cachedValue = this.DepositStKindCd10_tNedit.Text.Trim();
                                    //}
                                    // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ�̓K�C�h�{�^����
                                        e.NextCtrl = this.DepositStKindCd9_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������10��
                                            e.NextCtrl = this.DepositStKindCd10_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.DepositStKindCd9_tNedit;
                                            DepositStKindCd9_tNedit.Focus();
                                            DepositStKindCd9_tNedit.SelectAll();
                                        }
                                    }
                                    // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    //// ���͐ݒ����R�[�h8��
                                    //e.NextCtrl = this.DepositStKindCd8_tNedit;
                                    //this._cachedValue = this.DepositStKindCd8_tNedit.Text.Trim();
                                    // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ��8��
                                        e.NextCtrl = this.DepositStKindCd8_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������8��
                                            e.NextCtrl = this.DepositStKindCd8_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.DepositStKindCd9_tNedit;
                                            DepositStKindCd9_tNedit.Focus();
                                            DepositStKindCd9_tNedit.SelectAll();
                                        }
                                    }
                                    // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // ���͐ݒ����R�[�h9 [DepositStKindCd9_tNedit]

                #region ���͐ݒ����R�[�h9�K�C�h [DepositStKindCd9_tUltraBtn]
                case "DepositStKindCd9_tUltraBtn":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // 10��Enable�Ȃ炻�����
                                    if (this.DepositStKindCd10_tNedit.Enabled)
                                    {
                                        // ���͐ݒ����R�[�h10��
                                        e.NextCtrl = this.DepositStKindCd10_tNedit;
                                        this._cachedValue = this.DepositStKindCd10_tNedit.Text.Trim();
                                    }
                                    else
                                    {
                                        // �����ϓ`�[�ďo�敪�I����
                                        e.NextCtrl = this.AlwcDepoCallMonths_tComboEditor;
                                    }
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ���͐ݒ����R�[�h8��
                                    e.NextCtrl = this.DepositStKindCd8_tNedit;
                                    this._cachedValue = this.DepositStKindCd8_tNedit.Text.Trim();
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // ���͐ݒ����R�[�h9�K�C�h [DepositStKindCd9_tUltraBtn]

                #region ���͐ݒ����R�[�h10 [DepositStKindCd10_tNedit]
                case "DepositStKindCd10_tNedit":
                    {
                        string code = this.DepositStKindCd10_tNedit.Text.Trim();
                        // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                        // ���͂��ꂽ�l�̃`�F�b�N
                        if (String.IsNullOrEmpty(code))
                        {
                            // ��
                            isEmpty = true;
                            this._cache10 = string.Empty;
                        }
                        else if (code.Equals("0"))
                        {
                            // �l��߂�
                            this.DepositStKindCd10_tNedit.Text = this._cache10;
                        }
                        else
                        {
                            // �R�[�h�`�F�b�N                                     
                            if (DepositStKindCdInfoChange(0, DepositStKindCd10_tNedit, DepositStKindCdNm10_tEdit) == 0)
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
                                this.DepositStKindCd10_tNedit.Text = this._cache10;
                            }
                        }
                        // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    //if (String.IsNullOrEmpty(code))
                                    //{
                                    //    // �󔒂̏ꍇ�̓K�C�h�{�^����
                                    //    e.NextCtrl = this.DepositStKindCd10_tUltraBtn;
                                    //    this._cachedValue = this.DepositStKindCd10_tNedit.Text.Trim();
                                    //}
                                    //else
                                    //{
                                    //    // ���͂���Ă���Έ����ϓ`�[�ďo�敪�I����
                                    //    e.NextCtrl = this.AlwcDepoCallMonths_tComboEditor;
                                    //}
                                    // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ�̓K�C�h�{�^����
                                        e.NextCtrl = this.DepositStKindCd10_tUltraBtn;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h����������Έ����ϓ`�[�ďo�敪�I����
                                            e.NextCtrl = this.AlwcDepoCallMonths_tComboEditor;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.DepositStKindCd10_tNedit;
                                            DepositStKindCd10_tNedit.Focus();
                                            DepositStKindCd10_tNedit.SelectAll();
                                        }
                                    }
                                    // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<

                                    break;
                                }
                            case Keys.Up:
                                {
                                    // DEL 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    //// ���͐ݒ����R�[�h9��
                                    //e.NextCtrl = this.DepositStKindCd9_tNedit;
                                    //this._cachedValue = this.DepositStKindCd8_tNedit.Text.Trim();
                                    // DEL 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                                    if (isEmpty)
                                    {
                                        // �󔒂̏ꍇ��9��
                                        e.NextCtrl = this.DepositStKindCd9_tNedit;
                                    }
                                    else
                                    {
                                        if (correctCode)
                                        {
                                            // �R�[�h�����������9��
                                            e.NextCtrl = this.DepositStKindCd9_tNedit;
                                        }
                                        else
                                        {
                                            // �R�[�h���s���Ȃ�ړ��s��
                                            e.NextCtrl = this.DepositStKindCd10_tNedit;
                                            DepositStKindCd10_tNedit.Focus();
                                            DepositStKindCd10_tNedit.SelectAll();
                                        }
                                    }
                                    // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // ���͐ݒ����R�[�h10 [DepositStKindCd10_tNedit]

                #region ���͐ݒ����R�[�h10�K�C�h [DepositStKindCd10_tUltraBtn]
                case "DepositStKindCd10_tUltraBtn":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // �����ϓ`�[�ďo�敪�I����
                                    e.NextCtrl = this.AlwcDepoCallMonths_tComboEditor;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // ���͐ݒ����R�[�h9��
                                    e.NextCtrl = this.DepositStKindCd9_tNedit;
                                    this._cachedValue = this.DepositStKindCd9_tNedit.Text.Trim();
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // ���͐ݒ����R�[�h10�K�C�h [DepositStKindCd10_tUltraBtn]

                #region �����ϓ`�[�ďo�敪�I�� [AlwcDepoCallMonths_tComboEditor]
                case "AlwcDepoCallMonths_tComboEditor":
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
                                    // ���͐ݒ����R�[�h10��
                                    e.NextCtrl = this.DepositStKindCd10_tNedit;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �����ϓ`�[�ďo�敪�I�� [AlwcDepoCallMonths_tComboEditor]

                #region �ۑ��{�^�� [Ok_Button]
                case "Ok_Button":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // �L�����Z���{�^����
                                    e.NextCtrl = this.Cancel_Button;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // �����ϓ`�[�ďo�敪�I����
                                    e.NextCtrl = this.AlwcDepoCallMonths_tComboEditor;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �ۑ��{�^�� [Ok_Button]

                #region �L�����Z���{�^�� [Cancel_Button]
                case "Cancel_Button":
                    {
                        // NextCtrl����
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                            case Keys.Down:
                                {
                                    // ���������\����ʑI����
                                    e.NextCtrl = this.DepositInitDspNo_tComboEditor;
                                    break;
                                }
                            case Keys.Up:
                                {
                                    // �ۑ��{�^����
                                    e.NextCtrl = this.Ok_Button;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                #endregion // �L�����Z���{�^�� [Cancel_Button]
            
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
                if (String.IsNullOrEmpty(this.DepositStKindCd1_tNedit.Text.Trim()) || this.DepositStKindCd1_Label.Text.Equals("���o�^"))
                {
                    this.DepositStKindCd2_tNedit.Enabled = false;
                    this.DepositStKindCd2_tUltraBtn.Enabled = false;
                }
                // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                else
                {
                    this.DepositStKindCd2_tNedit.Enabled = true;
                    this.DepositStKindCd2_tUltraBtn.Enabled = true;
                }
                // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                if (String.IsNullOrEmpty(this.DepositStKindCd2_tNedit.Text.Trim()) || this.DepositStKindCd2_Label.Text.Equals("���o�^"))
                {
                    this.DepositStKindCd3_tNedit.Enabled = false;
                    this.DepositStKindCd3_tUltraBtn.Enabled = false;
                }
                // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                else
                {
                    this.DepositStKindCd3_tNedit.Enabled = true;
                    this.DepositStKindCd3_tUltraBtn.Enabled = true;
                }
                // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                if (String.IsNullOrEmpty(this.DepositStKindCd3_tNedit.Text.Trim()) || this.DepositStKindCd3_Label.Text.Equals("���o�^"))
                {
                    this.DepositStKindCd4_tNedit.Enabled = false;
                    this.DepositStKindCd4_tUltraBtn.Enabled = false;
                }
                // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                else
                {
                    this.DepositStKindCd4_tNedit.Enabled = true;
                    this.DepositStKindCd4_tUltraBtn.Enabled = true;
                }
                // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                if (String.IsNullOrEmpty(this.DepositStKindCd4_tNedit.Text.Trim()) || this.DepositStKindCd4_Label.Text.Equals("���o�^"))
                {
                    this.DepositStKindCd5_tNedit.Enabled = false;
                    this.DepositStKindCd5_tUltraBtn.Enabled = false;
                }
                // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                else
                {
                    this.DepositStKindCd5_tNedit.Enabled = true;
                    this.DepositStKindCd5_tUltraBtn.Enabled = true;
                }
                // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                if (String.IsNullOrEmpty(this.DepositStKindCd5_tNedit.Text.Trim()) || this.DepositStKindCd5_Label.Text.Equals("���o�^"))
                {
                    this.DepositStKindCd6_tNedit.Enabled = false;
                    this.DepositStKindCd6_tUltraBtn.Enabled = false;
                }
                // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                else
                {
                    this.DepositStKindCd6_tNedit.Enabled = true;
                    this.DepositStKindCd6_tUltraBtn.Enabled = true;
                }
                // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                if (String.IsNullOrEmpty(this.DepositStKindCd6_tNedit.Text.Trim()) || this.DepositStKindCd6_Label.Text.Equals("���o�^"))
                {
                    this.DepositStKindCd7_tNedit.Enabled = false;
                    this.DepositStKindCd7_tUltraBtn.Enabled = false;
                }
                // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                else
                {
                    this.DepositStKindCd7_tNedit.Enabled = true;
                    this.DepositStKindCd7_tUltraBtn.Enabled = true;
                }
                // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                if (String.IsNullOrEmpty(this.DepositStKindCd7_tNedit.Text.Trim()) || this.DepositStKindCd7_Label.Text.Equals("���o�^"))
                {
                    this.DepositStKindCd8_tNedit.Enabled = false;
                    this.DepositStKindCd8_tUltraBtn.Enabled = false;
                }
                // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                else
                {
                    this.DepositStKindCd8_tNedit.Enabled = true;
                    this.DepositStKindCd8_tUltraBtn.Enabled = true;
                }
                // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                if (String.IsNullOrEmpty(this.DepositStKindCd8_tNedit.Text.Trim()) || this.DepositStKindCd8_Label.Text.Equals("���o�^"))
                {
                    this.DepositStKindCd9_tNedit.Enabled = false;
                    this.DepositStKindCd9_tUltraBtn.Enabled = false;
                }
                // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                else
                {
                    this.DepositStKindCd9_tNedit.Enabled = true;
                    this.DepositStKindCd9_tUltraBtn.Enabled = true;
                }
                // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
                if (String.IsNullOrEmpty(this.DepositStKindCd9_tNedit.Text.Trim()) || this.DepositStKindCd9_Label.Text.Equals("���o�^"))
                {
                    this.DepositStKindCd10_tNedit.Enabled = false;
                    this.DepositStKindCd10_tUltraBtn.Enabled = false;
                }
                // ADD 2008/10/10 �s��Ή�[6500] ---------->>>>>
                else
                {
                    this.DepositStKindCd10_tNedit.Enabled = true;
                    this.DepositStKindCd10_tUltraBtn.Enabled = true;
                }
                // ADD 2008/10/10 �s��Ή�[6500] ----------<<<<<
            }
            else
            {
                if (enable)
                {
                    if (codeNumber == 2)
                    //switch (codeNumber)
                    {
                        // �Q�Ԗڂ�Enable/Disable��
                        this.DepositStKindCd2_tNedit.Enabled = enable;
                        this.DepositStKindCd2_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 3)
                    {
                        // �R�Ԗڂ�Enable/Disable��
                        this.DepositStKindCd3_tNedit.Enabled = enable;
                        this.DepositStKindCd3_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 4)
                    {
                        // �S�Ԗڂ�Enable/Disable��
                        this.DepositStKindCd4_tNedit.Enabled = enable;
                        this.DepositStKindCd4_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 5)
                    {
                        // �T�Ԗڂ�Enable/Disable��
                        this.DepositStKindCd5_tNedit.Enabled = enable;
                        this.DepositStKindCd5_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 6)
                    {
                        // �U�Ԗڂ�Enable/Disable��
                        this.DepositStKindCd6_tNedit.Enabled = enable;
                        this.DepositStKindCd6_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 7)
                    {
                        // �V�Ԗڂ�Enable/Disable��
                        this.DepositStKindCd7_tNedit.Enabled = enable;
                        this.DepositStKindCd7_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 8)
                    {
                        // �W�Ԗڂ�Enable/Disable��
                        this.DepositStKindCd8_tNedit.Enabled = enable;
                        this.DepositStKindCd8_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 9)
                    {
                        // �X�Ԗڂ�Enable/Disable��
                        this.DepositStKindCd9_tNedit.Enabled = enable;
                        this.DepositStKindCd9_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber == 10)
                    {
                        // �P�O�Ԗڂ�Enable/Disable��
                        this.DepositStKindCd10_tNedit.Enabled = enable;
                        this.DepositStKindCd10_tUltraBtn.Enabled = enable;
                    }

                }
                else
                {
                    // false�̂Ƃ��̓L�[���ڈȉ������ׂ�false

                    if (codeNumber < 3)
                    //switch (codeNumber)
                    {
                        // �Q�Ԗڂ�Enable/Disable��
                        this.DepositStKindCd2_tNedit.Enabled = enable;
                        this.DepositStKindCd2_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 4)
                    {
                        // �R�Ԗڂ�Enable/Disable��
                        this.DepositStKindCd3_tNedit.Enabled = enable;
                        this.DepositStKindCd3_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 5)
                    {
                        // �S�Ԗڂ�Enable/Disable��
                        this.DepositStKindCd4_tNedit.Enabled = enable;
                        this.DepositStKindCd4_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 6)
                    {
                        // �T�Ԗڂ�Enable/Disable��
                        this.DepositStKindCd5_tNedit.Enabled = enable;
                        this.DepositStKindCd5_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 7)
                    {
                        // �U�Ԗڂ�Enable/Disable��
                        this.DepositStKindCd6_tNedit.Enabled = enable;
                        this.DepositStKindCd6_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 8)
                    {
                        // �V�Ԗڂ�Enable/Disable��
                        this.DepositStKindCd7_tNedit.Enabled = enable;
                        this.DepositStKindCd7_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 9)
                    {
                        // �W�Ԗڂ�Enable/Disable��
                        this.DepositStKindCd8_tNedit.Enabled = enable;
                        this.DepositStKindCd8_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 10)
                    {
                        // �X�Ԗڂ�Enable/Disable��
                        this.DepositStKindCd9_tNedit.Enabled = enable;
                        this.DepositStKindCd9_tUltraBtn.Enabled = enable;
                    }

                    if (codeNumber < 11)
                    {
                        // �P�O�Ԗڂ�Enable/Disable��
                        this.DepositStKindCd10_tNedit.Enabled = enable;
                        this.DepositStKindCd10_tUltraBtn.Enabled = enable;
                    }
                }
            }
        }

        // --- ADD 2009/03/19 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this.depositStAcs = new DepositStAcs();

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          "SFUKK09060U",						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }
        // --- ADD 2009/03/19 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

        /*
		/// <summary>
		/// DepositCallMonths_tNedit_Leave�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
         */
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
		//private void DepositCallMonths_tNedit_Leave(object sender, System.EventArgs e)
		//{
			//if(DepositCallMonths_tNedit.Text == "")
			//{
				//DepositCallMonths_tNedit.SetInt(0);
				//this.monce_Label.Text = "�������ɒ��o";
			//}
			//else if(DepositCallMonths_tNedit.GetInt() == 0)
			//{
				//this.monce_Label.Text = "�������ɒ��o";
			//}
			//else
			//{
				//this.monce_Label.Text = "�����ȓ��𒊏o";
			//}

		//}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
		# endregion
	}
}
