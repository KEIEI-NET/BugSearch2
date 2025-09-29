//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d���M�ҏW�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d���M�ҏW�A�N�Z�X���s��
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
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011/10/25  �C�����e : PM1113A ��NET-WEB�Ή��d�l�ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �t�n�d���M�ҏW�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d���M�ҏW�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
    /// <br>UpDate</br>
    /// <br>2010/05/07 ���� PM1008 ����UOE-WEB�Ή��ɔ����d�l�ǉ�</br>
    /// <br>UpDate</br>
    /// <br>2011/10/25 ������ PM1113A ��NET-WEB�Ή��d�l�ǉ�</br>
	/// </remarks>
	public partial class UoeSndEditAcs
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
		public UoeSndEditAcs()
		{
			//�t�n�d����M�i�m�k�A�N�Z�X�N���X
			_uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();

            //���엚�����O�A�N�Z�X�N���X
            _uoeOprtnHisLogAcs = UoeOprtnHisLogAcs.GetInstance();
            _uoeOprtnHisLogAcs.LogDataMachineName = _uoeSndRcvJnlAcs.cashRegisterNo.ToString("d3");

			//�t�n�d���M�ҏW����
			_uoeSndEditHedRstList = new List<UoeSndHed>();

			//�t�n�d���M�ҏW�i�g���^�o�c�S�j�A�N�Z�X�N���X
			_uoeSndEdit0102Acs = new UoeSndEdit0102Acs();

			//�t�n�d���M�ҏW�i�j�b�T���m�p�[�c�j�A�N�Z�X�N���X
			_uoeSndEdit0202Acs = new UoeSndEdit0202Acs();

			//�t�n�d���M�ҏW�i�O�H�j�A�N�Z�X�N���X
			_uoeSndEdit0301Acs = new UoeSndEdit0301Acs();

			//�t�n�d���M�ҏW�i���}�c�_�j�A�N�Z�X�N���X
			_uoeSndEdit0401Acs = new UoeSndEdit0401Acs();

			//�t�n�d���M�ҏW�i�V�}�c�_�j�A�N�Z�X�N���X
			_uoeSndEdit0402Acs = new UoeSndEdit0402Acs();

			//�t�n�d���M�ҏW�i�z���_�j�A�N�Z�X�N���X
			_uoeSndEdit0501Acs = new UoeSndEdit0501Acs();

			//�t�n�d���M�ҏW�i�D�ǁj�A�N�Z�X�N���X
			_uoeSndEdit1001Acs = new UoeSndEdit1001Acs();
		}
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members

		//�t�n�d���M�ҏW����
        private List<UoeSndHed> _uoeSndEditHedRstList = null;

		//�t�n�d����M�i�m�k�A�N�Z�X�N���X
        private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs = null;

        //���엚�����O�A�N�Z�X�N���X
        private UoeOprtnHisLogAcs _uoeOprtnHisLogAcs = null;

		//�t�n�d���M�ҏW�i�g���^�o�c�S�j�A�N�Z�X�N���X
		private UoeSndEdit0102Acs _uoeSndEdit0102Acs = null;

		//�t�n�d���M�ҏW�i�j�b�T���m�p�[�c�j�A�N�Z�X�N���X
		private UoeSndEdit0202Acs _uoeSndEdit0202Acs = null;

		//�t�n�d���M�ҏW�i�O�H�j�A�N�Z�X�N���X
		private UoeSndEdit0301Acs _uoeSndEdit0301Acs = null;

		//�t�n�d���M�ҏW�i���}�c�_�j�A�N�Z�X�N���X
		private UoeSndEdit0401Acs _uoeSndEdit0401Acs = null;

		//�t�n�d���M�ҏW�i�V�}�c�_�j�A�N�Z�X�N���X
		private UoeSndEdit0402Acs _uoeSndEdit0402Acs = null;

		//�t�n�d���M�ҏW�i�z���_�j�A�N�Z�X�N���X
		private UoeSndEdit0501Acs _uoeSndEdit0501Acs = null;

		//�t�n�d���M�ҏW�i�D�ǁj�A�N�Z�X�N���X
		private UoeSndEdit1001Acs _uoeSndEdit1001Acs = null;
		# endregion

		// ===================================================================================== //
		// �萔
		// ===================================================================================== //
		# region Const Members
		//�G���[���b�Z�[�W
		private const string MESSAGE_ERROR01 = "�Ɩ��敪�̃p�����[�^���Ⴂ�܂��B";

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
		# region �t�n�d���M�ҏW����
		/// <summary>
		/// �t�n�d���M�ҏW����
		/// </summary>
		public List<UoeSndHed> uoeSndEditHedRstList
		{
			get
			{
				return this._uoeSndEditHedRstList;
			}
			set
			{
				this._uoeSndEditHedRstList = value;
			}
		}
		# endregion

		# region �t�n�d����M�i�m�k�f�[�^�Z�b�g
		/// <summary>
		/// �t�n�d����M�i�m�k�f�[�^�Z�b�g
		/// </summary>
		public DataSet UoeJnlDataSet
		{
			get
			{
				return this._uoeSndRcvJnlAcs.UoeJnlDataSet;
			}
		}
		# endregion
		# endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods

		# region �t�n�d���M�ҏW
		/// <summary>
		/// �t�n�d���M�ҏW
		/// </summary>
		/// <param name="uoeSndEditSearchPara"></param>
		/// <returns></returns>
        /// <remarks>
        /// <br>Update Note : 2010/05/07 ����</br>
        /// <br>              PM1008 ����UOE-WEB�Ή��ɔ����d�l�ǉ�</br>
        /// <br>Update Note : 2011/10/25 ������</br>
        /// <br>              PM1113A ��NET-WEB�Ή��d�l�ǉ�</br>
        /// </remarks>
		public int writeUOESNDEdit(UoeSndRcvCtlPara para, Dictionary<Int32, UOESupplier> uOESupplierDictionary, out List<UoeSndHed> list, out string message)
		{
			//�ϐ��̏�����
            string procNm = "writeUOESNDEdit";
            string asseNm = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";
			list = new List<UoeSndHed>(); 

			try
			{
				//�t�n�d���M�ҏW����
				_uoeSndEditHedRstList = new List<UoeSndHed>();

				foreach (Int32 key in uOESupplierDictionary.Keys)
				{
					List<UoeSndDtl> uoeSndDtlList = new List<UoeSndDtl>();
					UOESupplier uOESupplier = uOESupplierDictionary[key];

                    asseNm = "���M�ҏW";
                    logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_START, 0, "", uOESupplier.UOESupplierCd);

					switch (uOESupplier.CommAssemblyId)
					{
						//�g���^
						case EnumUoeConst.ctCommAssemblyId_0102:
							{
								status = _uoeSndEdit0102Acs.writeUOESNDEdit0102(para.BusinessCode,
															para.SystemDivCd,
															uOESupplier,
															out uoeSndDtlList,
															out message);
                                break;
							}

						//�j�b�T��
						case EnumUoeConst.ctCommAssemblyId_0202:
							{
                                status = _uoeSndEdit0202Acs.writeUOESNDEdit0202(para.BusinessCode,
															para.SystemDivCd,
															uOESupplier,
															out uoeSndDtlList,
															out message);
                                break;
							}
						//�~�c�r�V
						case EnumUoeConst.ctCommAssemblyId_0301:
							{
                                status = _uoeSndEdit0301Acs.writeUOESNDEdit0301(para.BusinessCode,
															para.SystemDivCd,
															uOESupplier,
															out uoeSndDtlList,
															out message);
                                break;
							}
						//���}�c�_
						case EnumUoeConst.ctCommAssemblyId_0401:
							{
                                status = _uoeSndEdit0401Acs.writeUOESNDEdit0401(para.BusinessCode,
															para.SystemDivCd,
															uOESupplier,
															out uoeSndDtlList,
															out message);
                                break;
							}
						//�V�}�c�_
						case EnumUoeConst.ctCommAssemblyId_0402:
							{
                                status = _uoeSndEdit0402Acs.writeUOESNDEdit0402(para.BusinessCode,
															para.SystemDivCd,
															uOESupplier,
															out uoeSndDtlList,
															out message);
                                break;
							}
						//�z���_
						case EnumUoeConst.ctCommAssemblyId_0501:
							{
                                status = _uoeSndEdit0501Acs.writeUOESNDEdit0501(para.BusinessCode,
															para.SystemDivCd,
															uOESupplier,
															out uoeSndDtlList,
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
                                status = _uoeSndEdit1001Acs.writeUOESNDEdit1001(para.BusinessCode,
															para.SystemDivCd,
															uOESupplier,
															out uoeSndDtlList,
															out message);
                                break;
							}
						default:
							{
								continue;
							}
					}

                    logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, status, message, uOESupplier.UOESupplierCd);

					//���M�ҏW�N���X�̐���擾
					if (status == (int)EnumUoeConst.Status.ct_NORMAL)
					{
						//�t�n�d���M�ҏW�N���X�̊i�[����
						if (uoeSndDtlList.Count > 0)
						{
							//�t�n�d���M�ҏW Dtl���̊i�[����
							UoeSndHed uoeSndHed = new UoeSndHed();
							uoeSndHed.UoeSndDtlList = new List<UoeSndDtl>();
							uoeSndHed.UOESupplierCd = uOESupplier.UOESupplierCd;
							uoeSndHed.BusinessCode = para.BusinessCode;
							uoeSndHed.CommAssemblyId = uOESupplier.CommAssemblyId;
							uoeSndHed.UoeSndDtlList = uoeSndDtlList;

							//�t�n�d���M�ҏW Hed���̊i�[����
							_uoeSndEditHedRstList.Add(uoeSndHed);
						}
					}
					//���M�ҏW�N���X�Ȃ�
					else if (status == (int)EnumUoeConst.Status.ct_NOT_FOUND)
					{
						continue;
					}
					//�G���[�l
					else
					{
						break;
					}

				}
				//�ߒl�Ƃ��đ��M�ҏW���ʂ��i�[
				if(status == 0)
				{
					list = _uoeSndEditHedRstList;
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

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
        # region �c�r�o���O��������
        /// <summary>
        /// �c�r�o���O��������
        /// </summary>
        /// <param name="logDataObjProcNm"></param>
        /// <param name="logDataOperationCd"></param>
        /// <param name="logOperationStatus"></param>
        /// <param name="logDataMassage"></param>
        private void logd_update(string logDataObjProcNm, string logDataObjAssemblyNm, Int32 logDataOperationCd, Int32 logOperationStatus, string logDataMassage, Int32 uOESupplierCd)
        {
            _uoeOprtnHisLogAcs.logd_update(this, logDataObjProcNm, logDataObjAssemblyNm, logDataOperationCd, logOperationStatus, logDataMassage, uOESupplierCd);
        }
        # endregion
        # endregion
	}
}
