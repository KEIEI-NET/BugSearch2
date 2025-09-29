//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M�ҏW�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d��M�ҏW���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601191-00 �쐬�S�� : ����
// �� �� ��  2010/05/07  �C�����e : PM1008 ����UOE-WEB�Ή��ɔ����d�l�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601191-00 �쐬�S�� : ����
// �� �� ��  2010/05/24  �C�����e : redmine#8268�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011/10/25  �C�����e : PM1113A ��NET-WEB�Ή��d�l�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LIUSY
// �� �� ��  2010/11/24  �C�����e : PM1113A ��NET-WEB�Ή��d�l�ǉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �t�n�d��M�ҏW�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d��M�ҏW�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
    /// <br>UpDate</br>
    /// <br>2010/05/07 ���� PM1008 ����UOE-WEB�Ή��ɔ����d�l�ǉ�</br>
    /// <br>UpDate</br>
    /// <br>2010/05/24 ���� PM1008 redmine#8268�̑Ή�</br>
    /// <br>2011/10/25 ������ PM1113A ��NET-WEB�Ή��d�l�ǉ�</br>
	/// </remarks>
	public partial class UoeRcvEditAcs
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		public UoeRcvEditAcs()
		{
			//��ƃR�[�h���擾����
			_enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			//�t�n�d����M�i�m�k�A�N�Z�X�N���X
			_uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();

			//�t�n�d��M�ҏW�i�g���^�o�c�S�j�A�N�Z�X�N���X
			_uoeRecEdit0102Acs = new UoeRecEdit0102Acs();

			//�t�n�d��M�ҏW�i�j�b�T���m�p�[�c�j�A�N�Z�X�N���X
			_uoeRecEdit0202Acs = new UoeRecEdit0202Acs();

			//�t�n�d��M�ҏW�i�O�H�j�A�N�Z�X�N���X
			_uoeRecEdit0301Acs = new UoeRecEdit0301Acs();

			//�t�n�d��M�ҏW�i���}�c�_�j�A�N�Z�X�N���X
			_uoeRecEdit0401Acs = new UoeRecEdit0401Acs();

			//�t�n�d��M�ҏW�i�V�}�c�_�j�A�N�Z�X�N���X
			_uoeRecEdit0402Acs = new UoeRecEdit0402Acs();

			//�t�n�d��M�ҏW�i�z���_�j�A�N�Z�X�N���X
			_uoeRecEdit0501Acs = new UoeRecEdit0501Acs();

			//�t�n�d��M�ҏW�i�D�ǁj�A�N�Z�X�N���X
			_uoeRecEdit1001Acs = new UoeRecEdit1001Acs();
		}
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		//��ƃR�[�h
		private string _enterpriseCode = "";

		//�t�n�d����M�i�m�k�A�N�Z�X�N���X
		private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs = null;

		//�t�n�d���M����
		private UoeSndHed _uoeSndHed = null;

		//�t�n�d��M����
		private UoeRecHed _uoeRecHed = null;

		//�t�n�d��M�ҏW�i�g���^�o�c�S�j�A�N�Z�X�N���X
		private UoeRecEdit0102Acs _uoeRecEdit0102Acs = null;

		//�t�n�d��M�ҏW�i�j�b�T���m�p�[�c�j�A�N�Z�X�N���X
		private UoeRecEdit0202Acs _uoeRecEdit0202Acs = null;

		//�t�n�d��M�ҏW�i�O�H�j�A�N�Z�X�N���X
		private UoeRecEdit0301Acs _uoeRecEdit0301Acs = null;

		//�t�n�d��M�ҏW�i���}�c�_�j�A�N�Z�X�N���X
		private UoeRecEdit0401Acs _uoeRecEdit0401Acs = null;

		//�t�n�d��M�ҏW�i�V�}�c�_�j�A�N�Z�X�N���X
		private UoeRecEdit0402Acs _uoeRecEdit0402Acs = null;

		//�t�n�d��M�ҏW�i�z���_�j�A�N�Z�X�N���X
		private UoeRecEdit0501Acs _uoeRecEdit0501Acs = null;

		//�t�n�d��M�ҏW�i�D�ǁj�A�N�Z�X�N���X
		private UoeRecEdit1001Acs _uoeRecEdit1001Acs = null;
		# endregion

		// ===================================================================================== //
		// �萔
		// ===================================================================================== //
		# region Const Members
		# endregion

		// ===================================================================================== //
		// �f���Q�[�g
		// ===================================================================================== //
		# region Delegate
		# endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region Event
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
		# region �t�n�d��M�ҏW��������
		/// <summary>
		/// �t�n�d��M�ҏW��������
		/// </summary>
		/// <param name="uoeSndEditSearchPara"></param>
		/// <returns></returns>
		public int UoeRecEditOrder(int systemDivCd, UoeSndHed uoeSndHed, UoeRecHed uoeRecHed, out string message)
		{
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
                //-----------------------------------------------------------
                // �ҏW�N���X�̕ۑ�
                //-----------------------------------------------------------
                //�t�n�d���M�ҏW�N���X�̕ۑ�
				_uoeSndHed = uoeSndHed;
				
				//�t�n�d��M�ҏW�N���X�̕ۑ�
				_uoeRecHed = uoeRecHed;

                //-----------------------------------------------------------
                // ��M�ҏW����
                //-----------------------------------------------------------
                status = GetJnlOrder(out message);
            }
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

		# region �t�n�d��M�ҏW�����ρ�
		/// <summary>
		/// �t�n�d��M�ҏW�����ρ�
		/// </summary>
		/// <param name="uoeSndEditSearchPara"></param>
		/// <returns></returns>
		public int UoeRecEditEstmt(int systemDivCd, UoeSndHed uoeSndHed, UoeRecHed uoeRecHed, out string message)
		{
			//�ϐ��̏�����
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";

			try
			{
                //-----------------------------------------------------------
                // �ҏW�N���X�̕ۑ�
                //-----------------------------------------------------------
                //�t�n�d���M�ҏW�N���X�̕ۑ�
				_uoeSndHed = uoeSndHed;

				//�t�n�d��M�ҏW�N���X�̕ۑ�
				_uoeRecHed = uoeRecHed;

                //-----------------------------------------------------------
                // ��M�ҏW����
                //-----------------------------------------------------------
				status = GetJnlEstmt(out message);
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

		# region �t�n�d��M�ҏW���݌Ɂ�
		/// <summary>
		/// �t�n�d��M�ҏW���݌Ɂ�
		/// </summary>
		/// <param name="uoeSndEditSearchPara"></param>
		/// <returns></returns>
		public int UoeRecEditStock(int systemDivCd, UoeSndHed uoeSndHed, UoeRecHed uoeRecHed, out string message)
		{
			//�ϐ��̏�����
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";

			try
			{
                //-----------------------------------------------------------
                // �ҏW�N���X�̕ۑ�
                //-----------------------------------------------------------
                //�t�n�d���M�ҏW�N���X�̕ۑ�
				_uoeSndHed = uoeSndHed;

				//�t�n�d��M�ҏW�N���X�̕ۑ�
				_uoeRecHed = uoeRecHed;

                //-----------------------------------------------------------
                // ��M�ҏW����
                //-----------------------------------------------------------
                status = GetJnlStock(out message);
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
        # region �t�n�d��M�ҏW��������
        /// <summary>
        /// �t�n�d��M�ҏW��������
        /// </summary>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Update Note : 2010/05/07 ����</br>
        /// <br>              PM1008 ����UOE-WEB�Ή��ɔ����d�l�ǉ�</br>
        /// <br>Update Note : 2011/10/25 ������</br>
        /// <br>              PM1113A ��NET-WEB�Ή��d�l�ǉ�</br>
        /// </remarks>
        private int GetJnlOrder(out string message)
        {
            //�ϐ��̏�����
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                switch (_uoeSndHed.CommAssemblyId)
                {
                    //�g���^
                    case EnumUoeConst.ctCommAssemblyId_0102:
                        {
                            status = _uoeRecEdit0102Acs.uoeRecEditOrder0102(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }

                    //�j�b�T��
                    case EnumUoeConst.ctCommAssemblyId_0202:
                        {
                            status = _uoeRecEdit0202Acs.uoeRecEditOrder0202(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //�~�c�r�V
                    case EnumUoeConst.ctCommAssemblyId_0301:
                        {
                            status = _uoeRecEdit0301Acs.uoeRecEditOrder0301(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //���}�c�_
                    case EnumUoeConst.ctCommAssemblyId_0401:
                        {
                            status = _uoeRecEdit0401Acs.uoeRecEditOrder0401(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //�V�}�c�_
                    case EnumUoeConst.ctCommAssemblyId_0402:
                        {
                            status = _uoeRecEdit0402Acs.uoeRecEditOrder0402(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //�z���_
                    case EnumUoeConst.ctCommAssemblyId_0501:
                        {
                            status = _uoeRecEdit0501Acs.uoeRecEditOrder0501(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    // ---ADD 2010/05/07 ------------------>>>>>
                    // �D�ǃ��[�J�[Web�̏ꍇ��ǉ� ���ʏ�̗D�ǃ��[�J�[�Ɠ����������s��
                    case EnumUoeConst.ctCommAssemblyId_1004:
                    // ---ADD 2010/05/07 ------------------<<<<<
                    // ---ADD 2011/10/25 ------------------>>>>>
                    // ��NET-WEB�Ή��d�l�ǉ�
                    case EnumUoeConst.ctCommAssemblyId_1003:
                    // ---ADD 2011/10/25 ------------------<<<<<
                    //�D�ǃ��[�J�[
                    case EnumUoeConst.ctCommAssemblyId_1001:
                        {
                            status = _uoeRecEdit1001Acs.uoeRecEditOrder1001(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    default:
                        {
                            status = -1;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # region �t�n�d��M�ҏW�����ρ�
        /// <summary>
        /// �t�n�d��M�ҏW�����ρ�
        /// </summary>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetJnlEstmt(out string message)
        {
            //�ϐ��̏�����
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                switch (_uoeSndHed.CommAssemblyId)
                {
                    //�g���^
                    case EnumUoeConst.ctCommAssemblyId_0102:
                        {
                            status = _uoeRecEdit0102Acs.uoeRecEditEstmt0102(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }

                    //�j�b�T��
                    case EnumUoeConst.ctCommAssemblyId_0202:
                        {
                            status = _uoeRecEdit0202Acs.uoeRecEditEstmt0202(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //�~�c�r�V
                    case EnumUoeConst.ctCommAssemblyId_0301:
                        {
                            status = _uoeRecEdit0301Acs.uoeRecEditEstmt0301(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //���}�c�_
                    case EnumUoeConst.ctCommAssemblyId_0401:
                        {
                            status = _uoeRecEdit0401Acs.uoeRecEditEstmt0401(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //�V�}�c�_
                    case EnumUoeConst.ctCommAssemblyId_0402:
                        {
                            status = _uoeRecEdit0402Acs.uoeRecEditEstmt0402(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //�z���_
                    case EnumUoeConst.ctCommAssemblyId_0501:
                        {
                            status = _uoeRecEdit0501Acs.uoeRecEditEstmt0501(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    default:
                        {
                            status = -1;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # region �t�n�d��M�ҏW���݌Ɂ�
        /// <summary>
        /// �t�n�d��M�ҏW���݌Ɂ�
        /// </summary>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Update Note : 2010/05/24 ����</br>
        /// <br>              PM1008 redmine#8268�̑Ή�</br>
        /// </remarks>
        private int GetJnlStock(out string message)
        {
            //�ϐ��̏�����
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                switch (_uoeSndHed.CommAssemblyId)
                {
                    //�g���^
                    case EnumUoeConst.ctCommAssemblyId_0102:
                        {
                            status = _uoeRecEdit0102Acs.uoeRecEditStock0102(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }

                    //�j�b�T��
                    case EnumUoeConst.ctCommAssemblyId_0202:
                        {
                            status = _uoeRecEdit0202Acs.uoeRecEditStock0202(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //�~�c�r�V
                    case EnumUoeConst.ctCommAssemblyId_0301:
                        {
                            status = _uoeRecEdit0301Acs.uoeRecEditStock0301(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //���}�c�_
                    case EnumUoeConst.ctCommAssemblyId_0401:
                        {
                            status = _uoeRecEdit0401Acs.uoeRecEditStock0401(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //�V�}�c�_
                    case EnumUoeConst.ctCommAssemblyId_0402:
                        {
                            status = _uoeRecEdit0402Acs.uoeRecEditStock0402(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    //�z���_
                    case EnumUoeConst.ctCommAssemblyId_0501:
                        {
                            status = _uoeRecEdit0501Acs.uoeRecEditStock0501(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    // ---ADD 2010/05/24 ------------------>>>>>
                    // �D�ǃ��[�J�[Web�̏ꍇ��ǉ� ���ʏ�̗D�ǃ��[�J�[�Ɠ����������s��
                    case EnumUoeConst.ctCommAssemblyId_1004:
                    // ---ADD 2010/05/24 ------------------<<<<<
                    //�D�ǃ��[�J�[
                    case EnumUoeConst.ctCommAssemblyId_1001:
                    // ---ADD 2010/11/24 ------------------<<<<<
                    //��WEB-NET
                    case EnumUoeConst.ctCommAssemblyId_1003:
                    // ---ADD 2010/11/24 ------------------<<<<<
                        {
                            status = _uoeRecEdit1001Acs.uoeRecEditStock1001(
                                                        _uoeSndHed,
                                                        _uoeRecHed,
                                                        out message);
                            break;
                        }
                    default:
                        {
                            status = -1;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

		# endregion
	}
}
