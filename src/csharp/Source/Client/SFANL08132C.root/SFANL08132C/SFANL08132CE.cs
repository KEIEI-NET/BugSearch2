using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// ���o�������͉�ʁi���Ԍ^�j
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���o��������͂����ʂł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.03.30</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08132CE : Panel, IFreePrintUserControl
	{
		#region PrivateMember
		// �N����i3:�J�n���,4:�I������j
		private int _extraConditionTypeCd = 0;
		// �J�n����A�I��������̍��W�ʒu�ύX�p
		private const int ctStPoint1 = 35;
		private const int ctStPoint2 = 65;
		private const int ctEdPoint1 = 112;
		private const int ctEdPoint2 = 142;
		// ���l�ύX�`�F�b�N�p�o�b�t�@
		private int _numBuff = 0;
		#endregion

		#region Const
		private const string ctStartDateBaseComment = "�J�n������@�@�@�@�@�@��";
		private const string ctEndDateBaseComment	= "�I��������@�@�@�@�@�@�O";
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08132CE()
		{
			InitializeComponent();
		}
		#endregion

		#region IFreePrintUserControl �����o
		/// <summary>���R���[���o�������׃}�X�^���X�g</summary>
		public List<FrePExCndD> FrePExCndDList { set { } }

		/// <summary>
		/// ���̓`�F�b�N����
		/// </summary>
		/// <param name="message">�s�����̃��b�Z�[�W</param>
		/// <param name="control">�s�����̃R���g���[��</param>
		/// <param name="isNecessaryExtraCondCheck">�K�{�����`�F�b�N</param>
		/// <returns>�`�F�b�N����</returns>
		public bool InputCheck(out string message, out Control control, bool isNecessaryExtraCondCheck)
		{
			message = string.Empty;
			control = null;

			int startDate	= 0;
			int endDate		= 0;
			if (_extraConditionTypeCd == 3)
			{
				startDate	= this.dateExtraDate.GetLongDate();
				endDate		= this.dateExtraDateTerm.GetLongDate();
			}
			else
			{
				startDate	= this.dateExtraDateTerm.GetLongDate();
				endDate		= this.dateExtraDate.GetLongDate();
			}

			// �K�{���ڃ`�F�b�N
			if (isNecessaryExtraCondCheck)
			{
				if ((startDate == 10101 || startDate == 0) &&
					(endDate == 10101 || endDate == 0))
				{
					message = this.ulExtraConditionTitle.Text + "�����͂���Ă��܂���B";
					if (_extraConditionTypeCd == 3)
						control = this.cmbExtraDateBaseCd;
					else
						control = this.nedExtraDateNumTerm;
					return false;
				}
			}

			// �召�`�F�b�N
			if (startDate > 10101 && endDate > 10101)
			{
				if (startDate > endDate)
				{
					message = this.ulExtraConditionTitle.Text + "�͈͎̔w�肪�s���ł��B";
					if (_extraConditionTypeCd == 3)
						control = this.cmbExtraDateBaseCd;
					else
						control = this.nedExtraDateNumTerm;
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// ���R���[���o�����ݒ���擾����
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		/// <returns>�X�e�[�^�X</returns>
		public void GetFrePprECndInfo(ref FrePprECnd frePprECnd)
		{
			if (frePprECnd.ExtraConditionTypeCd == 3)
			{
				// ������ ���ԁi�J�n����j ������
				frePprECnd.StExtraDateSignCd	= (int)this.cmbExtraDateSignCd.Value;
				frePprECnd.StExtraDateNum		= this.nedExtraDateNum.GetInt();
				frePprECnd.StExtraDateUnitCd	= (int)this.cmbExtraDateUnitCd.Value;
				frePprECnd.StExtraDateBaseCd	= (int)this.cmbExtraDateBaseCd.Value;
				frePprECnd.StartExtraDate		= this.dateExtraDate.GetLongDate();

				frePprECnd.EdExtraDateBaseCd	= 2;
				frePprECnd.EdExtraDateSignCd	= 0;
				frePprECnd.EdExtraDateNum		= this.nedExtraDateNumTerm.GetInt();
				frePprECnd.EdExtraDateUnitCd	= (int)this.cmbExtraDateUnitCdTerm.Value;
				frePprECnd.EndExtraDate			= this.dateExtraDateTerm.GetLongDate();
			}
			else
			{
				// ������ ���ԁi�I������j ������
				frePprECnd.EdExtraDateSignCd	= (int)this.cmbExtraDateSignCd.Value;
				frePprECnd.EdExtraDateNum		= this.nedExtraDateNum.GetInt();
				frePprECnd.EdExtraDateUnitCd	= (int)this.cmbExtraDateUnitCd.Value;
				frePprECnd.EdExtraDateBaseCd	= (int)this.cmbExtraDateBaseCd.Value;
				frePprECnd.EndExtraDate			= this.dateExtraDate.GetLongDate();

				frePprECnd.StExtraDateBaseCd	= 2;
				frePprECnd.StExtraDateSignCd	= 0;
				frePprECnd.StExtraDateNum		= this.nedExtraDateNumTerm.GetInt();
				frePprECnd.StExtraDateUnitCd	= (int)this.cmbExtraDateUnitCdTerm.Value;
				frePprECnd.StartExtraDate		= this.dateExtraDateTerm.GetLongDate();
			}
		}

		/// <summary>
		/// ���R���[���o�����ݒ���ݒ菈��
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		public void SetFrePprECndInfo(FrePprECnd frePprECnd)
		{
			_extraConditionTypeCd = frePprECnd.ExtraConditionTypeCd;

			// ���o�����^�C�v
			if (frePprECnd.ExtraConditionTypeCd == 3)
			{
				// ������ ���ԁi�J�n����j ������
				// ��ʃ��C�A�E�g��ݒ�
				this.cmbExtraDateBaseCd.Top				= ctStPoint1;
				this.cmbExtraDateSignCd.Top				= ctStPoint1;
				this.nedExtraDateNum.Top				= ctStPoint1;
				this.cmbExtraDateUnitCd.Top				= ctStPoint1;
				this.dateExtraDate.Top					= ctStPoint2;
				this.cmbExtraDateBaseCd.TabIndex		= 1;
				this.cmbExtraDateSignCd.TabIndex		= 2;
				this.nedExtraDateNum.TabIndex			= 3;
				this.cmbExtraDateUnitCd.TabIndex		= 4;
				this.dateExtraDate.TabIndex				= 5;

				this.ulTermComment.Top					= ctEdPoint1;
				this.nedExtraDateNumTerm.Top			= ctEdPoint1;
				this.cmbExtraDateUnitCdTerm.Top 		= ctEdPoint1;
				this.dateExtraDateTerm.Top				= ctEdPoint2;
				this.ulTermComment.TabIndex				= 6;
				this.nedExtraDateNumTerm.TabIndex		= 7;
				this.cmbExtraDateUnitCdTerm.TabIndex	= 8;
				this.dateExtraDateTerm.TabIndex			= 9;

				this.ulExtraConditionTitle.Text	= frePprECnd.ExtraConditionTitle;
				this.ulTermComment.Text			= ctStartDateBaseComment;

				// ���o�J�n���t�i��j
				this.cmbExtraDateBaseCd.Value = frePprECnd.StExtraDateBaseCd;
				if (frePprECnd.StExtraDateBaseCd == 5)	// 5:���t�w��
				{
					this.dateExtraDate.SetDateTime(TDateTime.LongDateToDateTime(frePprECnd.StartExtraDate));
				}
				else
				{
					this.cmbExtraDateSignCd.Value	= frePprECnd.StExtraDateSignCd;
					this.nedExtraDateNum.SetInt(frePprECnd.StExtraDateNum);
					this.cmbExtraDateUnitCd.Value	= frePprECnd.StExtraDateUnitCd;
				}

				this.nedExtraDateNumTerm.SetInt(frePprECnd.EdExtraDateNum);
				this.cmbExtraDateUnitCdTerm.Value = frePprECnd.EdExtraDateUnitCd;
			}
			else
			{
				// ������ ���ԁi�I������j ������
				// ��ʃ��C�A�E�g��ݒ�
				this.cmbExtraDateBaseCd.Top				= ctEdPoint1;
				this.cmbExtraDateSignCd.Top				= ctEdPoint1;
				this.nedExtraDateNum.Top				= ctEdPoint1;
				this.cmbExtraDateUnitCd.Top				= ctEdPoint1;
				this.dateExtraDate.Top					= ctEdPoint2;
				this.cmbExtraDateBaseCd.TabIndex		= 5;
				this.cmbExtraDateSignCd.TabIndex		= 6;
				this.nedExtraDateNum.TabIndex			= 7;
				this.cmbExtraDateUnitCd.TabIndex		= 8;
				this.dateExtraDate.TabIndex				= 9;

				this.ulTermComment.Top					= ctStPoint1;
				this.nedExtraDateNumTerm.Top			= ctStPoint1;
				this.cmbExtraDateUnitCdTerm.Top 		= ctStPoint1;
				this.dateExtraDateTerm.Top				= ctStPoint2;
				this.ulTermComment.TabIndex				= 1;
				this.nedExtraDateNumTerm.TabIndex		= 2;
				this.cmbExtraDateUnitCdTerm.TabIndex	= 3;
				this.dateExtraDateTerm.TabIndex			= 4;

				this.ulExtraConditionTitle.Text	= frePprECnd.ExtraConditionTitle;
				this.ulTermComment.Text			= ctEndDateBaseComment;

				this.cmbExtraDateBaseCd.Value = frePprECnd.EdExtraDateBaseCd;
				// ���o�J�n���t�i��j
				if (frePprECnd.EdExtraDateBaseCd == 5)	// 5:���t�w��
				{
					this.dateExtraDate.SetDateTime(TDateTime.LongDateToDateTime(frePprECnd.EndExtraDate));
				}
				else
				{
					this.cmbExtraDateSignCd.Value	= frePprECnd.EdExtraDateSignCd;
					this.nedExtraDateNum.SetInt(frePprECnd.EdExtraDateNum);
					this.cmbExtraDateUnitCd.Value	= frePprECnd.EdExtraDateUnitCd;
				}

				this.nedExtraDateNumTerm.SetInt(frePprECnd.StExtraDateNum);
				this.cmbExtraDateUnitCdTerm.Value = frePprECnd.StExtraDateUnitCd;
			}

			// �K�{�����̔w�i�F��ݒ�i���ʎd�l�j
			if (frePprECnd.NecessaryExtraCondCd == 1)
			{
				this.dateExtraDate.EditAppearance.BackColor			= Color.FromArgb(179, 219, 231);
				this.dateExtraDateTerm.EditAppearance.BackColor		= Color.FromArgb(179, 219, 231);
				this.cmbExtraDateSignCd.Appearance.BackColor		= Color.FromArgb(179, 219, 231);
				this.nedExtraDateNum.Appearance.BackColor			= Color.FromArgb(179, 219, 231);
				this.cmbExtraDateUnitCd.Appearance.BackColor		= Color.FromArgb(179, 219, 231);
				this.nedExtraDateNumTerm.Appearance.BackColor		= Color.FromArgb(179, 219, 231);
				this.cmbExtraDateUnitCdTerm.Appearance.BackColor	= Color.FromArgb(179, 219, 231);
			}

			// ���o���Ԃ��Z��
			CalculateTerm();
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// ���o���ԎZ�菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: ��ʂɓ��͂��ꂽ�f�[�^�����ɒ��o���Ԃ��Z�肵�܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		private void CalculateTerm()
		{
			if (this.cmbExtraDateBaseCd.Value == null ||
				this.cmbExtraDateSignCd.Value == null ||
				this.cmbExtraDateUnitCd.Value == null ||
				this.cmbExtraDateUnitCdTerm.Value == null)
				return;

			int extraDateBaseCd = (int)this.cmbExtraDateBaseCd.Value;
			if (extraDateBaseCd != 5)
			{
				int extraDateSignCd	= (int)this.cmbExtraDateSignCd.Value;
				int extraDateNum	= this.nedExtraDateNum.GetInt();
				int extraDateUnitCd	= (int)this.cmbExtraDateUnitCd.Value;
				// ���o������v�Z
				DateTime wkDateTime = CalculateDate(DateTime.Today
					, extraDateBaseCd
					, extraDateSignCd
					, extraDateNum
					, extraDateUnitCd);
				this.dateExtraDate.SetDateTime(wkDateTime);
			}

			DateTime baseDate = this.dateExtraDate.GetDateTime();

			int extraDateNumTerm	= this.nedExtraDateNumTerm.GetInt();
			int extraDateUnitCdTerm	= (int)this.cmbExtraDateUnitCdTerm.Value;
			// ���Ԃ��Z��
			DateTime termDate = DateTime.MinValue;
			if (baseDate != DateTime.MinValue)
			{
				if (_extraConditionTypeCd == 3)
					termDate = CalculateDate(baseDate, 2, 0, extraDateNumTerm, extraDateUnitCdTerm);
				else
					termDate = CalculateDate(baseDate, 2, 1, extraDateNumTerm, extraDateUnitCdTerm);
			}
			this.dateExtraDateTerm.SetDateTime(termDate);
		}

		/// <summary>
		/// ���t�Z�菈��
		/// </summary>
		/// <param name="baseDate">�v�Z���</param>
		/// <param name="baseCd">�(0:�O�X��,1:�O��,2:�{��,3:����,4:���X��,5:���t�w��)</param>
		/// <param name="sign">�����i0:�{,1:�|�j</param>
		/// <param name="num">���l</param>
		/// <param name="unit">�P�ʁi0:��,1:�T,2:��,3:�N�j</param>
		/// <returns>�Z�茋�ʓ��t</returns>
		/// <remarks>
		/// <br>Note		: ���t�̎Z����s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		private DateTime CalculateDate(DateTime baseDate, int baseCd, int sign, int num, int unit)
		{
			DateTime retDate = baseDate;

			// ������Z��
			switch (baseCd)
			{
				case 0: retDate = retDate.AddDays(-2); break;
				case 1: retDate = retDate.AddDays(-1); break;
				case 3: retDate = retDate.AddDays(1); break;
				case 4: retDate = retDate.AddDays(2); break;
			}

			if (sign == 1)
				num *= -1;

			switch (unit)
			{
				case 0: retDate = retDate.AddDays(num); break;
				case 1: retDate = retDate.AddDays(num * 7); break;
				case 2: retDate = retDate.AddMonths(num); break;
				case 3: retDate = retDate.AddYears(num); break;
			}

			return retDate;
		}
		#endregion

		#region Event
		/// <summary>
		/// ���ԍ���SelectionChanged�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �I�����ύX���ꂽ�ꍇ�ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		private void ExtrTerm_SelectionChanged(object sender, EventArgs e)
		{
			if (sender == this.cmbExtraDateBaseCd)
			{
				if ((int)this.cmbExtraDateBaseCd.Value == 5)
				{
					// �f�[�^���N���A
					this.cmbExtraDateSignCd.SelectedIndex	= 0;
					this.nedExtraDateNum.Clear();
					this.cmbExtraDateUnitCd.SelectedIndex	= 0;
					// ���͐���
					this.cmbExtraDateSignCd.Enabled	= false;
					this.nedExtraDateNum.Enabled	= false;
					this.cmbExtraDateUnitCd.Enabled	= false;
					this.dateExtraDate.ReadOnly		= false;
				}
				else
				{
					// ���͐���
					this.cmbExtraDateSignCd.Enabled	= true;
					this.nedExtraDateNum.Enabled	= true;
					this.cmbExtraDateUnitCd.Enabled	= true;
					this.dateExtraDate.ReadOnly		= true;
				}
			}

			// ���o���Ԃ��Z��
			CalculateTerm();
		}

		/// <summary>
		/// ���l����Enter�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �R���g���[�����t�H�[���̃A�N�e�B�u�R���g���[����</br>
		/// <br>			: �Ȃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		private void ExtrTerm_Enter(object sender, EventArgs e)
		{
			if (sender is TNedit)
				_numBuff = ((TNedit)sender).GetInt();
			else if (sender is TDateEdit)
				_numBuff = ((TDateEdit)sender).GetLongDate();
		}

		/// <summary>
		/// ���l����Leave�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �R���g���[�����t�H�[���̃A�N�e�B�u�R���g���[����</br>
		/// <br>			: �Ȃ��Ȃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.30</br>
		/// </remarks>
		private void ExtrTerm_Leave(object sender, EventArgs e)
		{
			if (sender is TNedit)
			{
				TNedit wkTNedit = (TNedit)sender;
				// ���o���Ԃ��Z��
				if (!_numBuff.Equals(wkTNedit.GetInt()))
					CalculateTerm();
			}
			else if (sender is TDateEdit)
			{
				TDateEdit wkTDateEdit = (TDateEdit)sender;
				// ���o���Ԃ��Z��
				if (!_numBuff.Equals(wkTDateEdit.GetLongDate()))
					CalculateTerm();
			}
		}

		/// <summary>
		/// SizeChanged�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: Size �v���p�e�B�̒l���R���g���[���ŕύX���ꂽ�Ƃ���</br>
		/// <br>			: ��������C�x���g�ł��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.07.05</br>
		/// </remarks>
		private void ulExtraConditionTitle_SizeChanged(object sender, EventArgs e)
		{
			FrePrtSettingController.AdjustControlFontSize(this.ulExtraConditionTitle, 11);
		}

		/// <summary>
		/// TextChanged�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: TextChanged �v���p�e�B�̒l���R���g���[���ŕύX���ꂽ�Ƃ���</br>
		/// <br>			: ��������C�x���g�ł��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.07.05</br>
		/// </remarks>
		private void ulExtraConditionTitle_TextChanged(object sender, EventArgs e)
		{
			FrePrtSettingController.AdjustControlFontSize(this.ulExtraConditionTitle, 11);
		}
		#endregion
	}
}
