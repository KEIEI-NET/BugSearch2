//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d������A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d������A�N�Z�X���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902931-00 �쐬�S�� : 杍^
// �� �� ��  2014/03/24  �C�����e : �������_�̔������Ď擾�̑Ή�
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

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �t�n�d������A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d������A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeSndRcvJnlAcs
	{
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

		# region ������}�X�^���擾
		/// <summary>
		/// ������}�X�^���擾
		/// </summary>
		/// <returns></returns>
		public int GetUOESupplier()
		{
			string message = "";
			return (GetUOESupplier(out message));
		}

        /// <summary>
        /// �����\���[�J�[���`�F�b�N
        /// </summary>
        /// <param name="uOESupplierCd">������R�[�h</param>
        /// <param name="enableOdrMakerCdList">���[�J�[�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        public bool ExistUOESupplierMaker(Int32 uOESupplierCd, List<Int32> enableOdrMakerCdList)
        {
            bool returnStatus = false;

			try
			{
                foreach (Int32 enableOdrMakerCd in enableOdrMakerCdList)
                {
                    String cdString = uOESupplierCd.ToString("d9") + enableOdrMakerCd.ToString("d6");
                    if (_uoeOrderMakerSearchDictionary.ContainsKey(cdString))
                    {
                        returnStatus = true;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                returnStatus = false;
            }
            return returnStatus;
        }

		/// <summary>
		/// ������}�X�^���擾
		/// </summary>
		/// <param name="para"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public int GetUOESupplier(out string message)
		{
			int status = 0;

			message = "";
			try
			{
				//������Dictionary�������������p��
				if (_uoeOrderSearchDictionary == null)
				{
					_uoeOrderSearchDictionary = new Dictionary<Int32, UOESupplier	>();
				}

				//�����\���[�J�[Dictionary�������������p��
                if(_uoeOrderMakerSearchDictionary == null)
                {
                    _uoeOrderMakerSearchDictionary = new Dictionary<string,string>();
                }

				if (_uoeOrderSearchDictionary.Count > 0)
				{
					return status;
				}

				ArrayList retList = new ArrayList();

				status = _uOESupplierAcs.SearchAll(out retList, _enterpriseCode, _sectionCode);

				if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (retList is ArrayList))
				{
					foreach (UOESupplier rst in retList)
					{
						SetUoeOrderSearch(rst);
                        SetUoeOrderMakerSearch(rst);
                    }
				}
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return status;
		}
		# endregion


        // ------------- ADD 杍^ 2014/03/24 -------- >>>>>>>>>>
        /// <summary>
        /// ������}�X�^���擾
        /// </summary>
        /// <returns></returns>
        public int GetUOESupplierForMoreSection()
        {
            string message = "";
            return (GetUOESupplierForMoreSection(out message));
        }

        /// <summary>
        /// ������}�X�^���擾
        /// </summary>
        /// <param name="para"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int GetUOESupplierForMoreSection(out string message)
        {
            int status = 0;

            message = "";
            try
            {
                //������Dictionary�������������p��
                _uoeOrderSearchDictionary = new Dictionary<Int32, UOESupplier>();

                //�����\���[�J�[Dictionary�������������p��
                _uoeOrderMakerSearchDictionary = new Dictionary<string, string>();

                ArrayList retList = new ArrayList();

                status = _uOESupplierAcs.SearchAll(out retList, _enterpriseCode, _sectionCode);

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (retList is ArrayList))
                {
                    foreach (UOESupplier rst in retList)
                    {
                        SetUoeOrderSearch(rst);
                        SetUoeOrderMakerSearch(rst);
                    }
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return status;
        }
        // ------------- ADD 杍^�@2014/03/24 -------- <<<<<<<<<<

		# region ����������擾�������p��
		/// <summary>
		/// ����������擾�������p��
		/// </summary>
		/// <param name="cd"></param>
		/// <param name="uOESupplier"></param>
		/// <returns></returns>
		public UOESupplier SearchUOESupplier(Int32 cd)
		{
			UOESupplier uOESupplier = null;

			if (_uoeOrderSearchDictionary.ContainsKey(cd))
			{
				uOESupplier = _uoeOrderSearchDictionary[cd];
			}
			return uOESupplier;
		}
		# endregion

        # region �D�ǎd����M�`�F�b�N
        /// <summary>
        /// �D�ǎd����M�`�F�b�N
        /// </summary>
        /// <param name="cd">������R�[�h</param>
        /// <returns>true:���� false:�Ȃ�</returns>
        public bool ChkStockSlipDtRecvDiv(Int32 cd)
        {
            bool returnBool = false;

            try
            {
                UOESupplier uOESupplier = SearchUOESupplier(cd);
                if (uOESupplier != null)
                {
                    returnBool = ChkStockSlipDtRecvDiv(uOESupplier);
                }
            }
            catch (Exception)
            {
                returnBool = false;
            }
            return returnBool;
        }

        /// <summary>
        /// �D�ǎd����M�`�F�b�N
        /// </summary>
        /// <param name="uOESupplier">������I�u�W�F�N�g</param>
        /// <returns>true:���� false:�Ȃ�</returns>
        public bool ChkStockSlipDtRecvDiv(UOESupplier uOESupplier)
        {
            bool returnBool = false;

            try
            {
                if (uOESupplier != null)
                {
                    if ((ChkCommAssemblyId(uOESupplier.CommAssemblyId) == false)
                    && (uOESupplier.StockSlipDtRecvDiv == 1))
                    {
                        returnBool = true;
                    }
                }
            }
            catch (Exception)
            {
                returnBool = false;
            }
            return returnBool;
        }
        # endregion

        # region �����Y�ƃ`�F�b�N
        /// <summary>
        /// �����Y�ƃ`�F�b�N
        /// </summary>
        /// <param name="cd">������R�[�h</param>
        /// <returns>true:���� false:�����ȊO</returns>
        public bool ChkMeiji(Int32 cd)
        {
			bool returnBool = false;

            try
            {
                UOESupplier uOESupplier = SearchUOESupplier(cd);
                if (uOESupplier != null)
                {
                    returnBool = ChkMeiji(uOESupplier);
                }
            }
            catch (Exception)
            {
                returnBool = false;
            }
			return returnBool;
        }

        /// <summary>
        /// �����Y�ƃ`�F�b�N
        /// </summary>
        /// <param name="uOESupplier">������I�u�W�F�N�g</param>
        /// <returns>true:���� false:�����ȊO</returns>
        public bool ChkMeiji(UOESupplier uOESupplier)
        {
            bool returnBool = false;

            try
            {
                if (uOESupplier != null)
                {
                    if ((uOESupplier.ReceiveCondition == 1) && (uOESupplier.StockSlipDtRecvDiv == 1))
                    {
                        returnBool = true;
                    }
                }
            }
            catch (Exception)
            {
                returnBool = false;
            }
            return returnBool;
        }
        # endregion

        # region �����E�D�ǔ���
        /// <summary>
        /// �����E�D�ǔ���
        /// </summary>
        /// <param name="cd">������R�[�h</param>
        /// <returns>True:���� False:�D��</returns>
        public bool ChkCommAssemblyId(Int32 cd)
        {
            bool returnBool = false;

            try
            {
                UOESupplier uOESupplier = SearchUOESupplier(cd);
                if (uOESupplier != null)
                {
                    returnBool = ChkCommAssemblyId(uOESupplier.CommAssemblyId);
                }
            }
            catch (Exception)
            {
                returnBool = false;
            }
            return returnBool;
        }
        
        /// <summary>
        /// �����E�D�ǔ���
        /// </summary>
        /// <param name="commAssemblyId">�ʐM�A�Z���u��ID</param>
        /// <returns>True:���� False:�D��</returns>
        public bool ChkCommAssemblyId(string commAssemblyId)
        {
            bool returnBool = true;

            int cd = 0;

            try
            {
                cd = int.Parse(commAssemblyId);
            }
            catch (Exception)
            {
                cd = 0;
            }
            if (cd >= 1000) returnBool = false;
            return (returnBool);
        }
        # endregion

		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
		# region ���������ۑ��������p��
		/// <summary>
		/// ���������ۑ��������p��
		/// </summary>
		/// <param name="uOESupplier">������I�u�W�F�N�g</param>
		/// <returns>�X�e�[�^�X</returns>
		private bool SetUoeOrderSearch(UOESupplier uOESupplier)
		{
			bool status = false;
			Int32 cd = uOESupplier.UOESupplierCd;

			if((uOESupplier.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData0)
			&& (_uoeOrderSearchDictionary.ContainsKey(cd) != true))
			{
				_uoeOrderSearchDictionary.Add(cd, uOESupplier);
				status = true;
			}

			return status;
		}
		# endregion

		# region �����\���[�J�[����ۑ��������p��
        /// <summary>
        /// �����\���[�J�[����ۑ��������p��
        /// </summary>
        /// <param name="uOESupplier">������I�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        private bool SetUoeOrderMakerSearch(UOESupplier uOESupplier)
        {
            Int32 enableOdrMakerCd = 0;

			if(uOESupplier.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0)
            {
                return(false);
            }

            for(int i=0; i<6; i++)
            {
                switch(i)
                {
                    case 0:
                        enableOdrMakerCd = uOESupplier.EnableOdrMakerCd1;
                        break;
                    case 1:
                        enableOdrMakerCd = uOESupplier.EnableOdrMakerCd2;
                        break;
                    case 2:
                        enableOdrMakerCd = uOESupplier.EnableOdrMakerCd3;
                        break;
                    case 3:
                        enableOdrMakerCd = uOESupplier.EnableOdrMakerCd4;
                        break;
                    case 4:
                        enableOdrMakerCd = uOESupplier.EnableOdrMakerCd5;
                        break;
                    case 5:
                        enableOdrMakerCd = uOESupplier.EnableOdrMakerCd6;
                        break;
                }
                if(enableOdrMakerCd == 0)   continue;

        		String cdString = uOESupplier.UOESupplierCd.ToString("d9") + enableOdrMakerCd.ToString("d6");

	    		if(_uoeOrderMakerSearchDictionary.ContainsKey(cdString) != true)
                {
                    _uoeOrderMakerSearchDictionary.Add(cdString, cdString);
                }
            }
			return true;
        }
        # endregion
        # endregion
    }
}
