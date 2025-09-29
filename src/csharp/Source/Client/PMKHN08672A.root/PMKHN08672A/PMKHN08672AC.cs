using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �Ԏ�}�X�^�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �Ԏ�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
    /// <br>UpdateNote  : 2008/12/02 30462 �s�V�m���@�o�O�C��</br>
	/// <br></br>
    /// </remarks>
	public class ModelNameSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private MakerAcs _makerAcs;
        private ModelNameUAcs _modelNameUAcs;

        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// �Ԏ�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �Ԏ�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public ModelNameSetAcs()
		{

			
        }

        

        /// <summary>�I�����C�����[�h�̗񋓌^�ł��B</summary>
		public enum OnlineMode 
		{
			/// <summary>�I�t���C��</summary>
			Offline,
			/// <summary>�I�����C��</summary>
			Online 
		}

	

		/// <summary>
		/// �Ԏ�}�X�^�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �Ԏ�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, ModelNamePrintWork modelNamePrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, modelNamePrintWork);
		}

		/// <summary>
		/// �Ԏ�}�X�^���������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �Ԏ�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, ModelNamePrintWork modelNamePrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, modelNamePrintWork);
		}

		

		/// <summary>
		/// �Ԏ�}�X�^��������
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <param name="readCnt">�Ǎ�����</param>
        /// <param name="sectionPrintWork">���o����</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �Ԏ�}�X�^�̌����������s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, ModelNamePrintWork modelNamePrintWork)
		{

            this._makerAcs = new MakerAcs();
            this._modelNameUAcs = new ModelNameUAcs();

            int status = 0;
            int checkstatus = 0;

            //���f�[�^�L��������
            nextData = false;
            //0�ŏ�����
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList makerUMnts = null;
            ArrayList modelNameUs = null;
            status = this._makerAcs.SearchAll(
                                out makerUMnts,
                                enterpriseCode);

            foreach (MakerUMnt makerUMnt in makerUMnts)
            {
                checkstatus = DataCheck(makerUMnt, modelNamePrintWork);
                if (checkstatus == 0)
                {
                    modelNameUs = null;
                    status = this._modelNameUAcs.SearchAll(makerUMnt.GoodsMakerCd, out modelNameUs, enterpriseCode);

                    foreach (ModelNameU modelNameU in modelNameUs)
                    {
                        // ���o����
                        checkstatus = DataCheck(modelNameU, modelNamePrintWork);
                        if (checkstatus == 0)
                        {

                            //�Ԏ���N���X�փ����o�R�s�[
                            retList.Add(CopyToMakerSetFromSecInfoSetWork(modelNameU, enterpriseCode));

                        }
                    }
                }
            }
            status = 0;

            //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�Ԏ�}�X�^���[�N�N���X�ˎԎ�}�X�^�N���X�j
        /// </summary>
        /// <param name="secInfoSetWork">�Ԏ�}�X�^���[�N�N���X</param>
        /// <returns>�Ԏ�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �Ԏ�}�X�^���[�N�N���X����Ԏ�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private ModelNameSet CopyToMakerSetFromSecInfoSetWork(ModelNameU modelNameU, string enterpriseCode)
        {

            ModelNameSet modelNameSet = new ModelNameSet();

            modelNameSet.MakerCode = modelNameU.MakerCode;
            modelNameSet.ModelCode = modelNameU.ModelCode;
            modelNameSet.ModelSubCode = modelNameU.ModelSubCode;
            modelNameSet.ModelFullName = modelNameU.ModelFullName;
            modelNameSet.ModelHalfName = modelNameU.ModelHalfName;
            modelNameSet.ModelAliasName = modelNameU.ModelAliasName;

            return modelNameSet;
        }

        /// <summary>
        /// ���[�J�[���o����
        /// </summary>
        /// <param name="makerUMnt"></param>
        /// <param name="modelNamePrintWork"></param>
        /// <returns></returns>
        private int DataCheck(MakerUMnt makerUMnt, ModelNamePrintWork modelNamePrintWork)
        {
            int status = 0;

            if (modelNamePrintWork.MakerCodeSt != 0 &&
                modelNamePrintWork.MakerCodeEd != 0)
            {
                if (makerUMnt.GoodsMakerCd < modelNamePrintWork.MakerCodeSt ||
                   makerUMnt.GoodsMakerCd > modelNamePrintWork.MakerCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (modelNamePrintWork.MakerCodeSt != 0)
            {
                if (makerUMnt.GoodsMakerCd < modelNamePrintWork.MakerCodeSt)
                {
                    status = -1;
                    return status;
                }
                // ADD 2008/12/02 �s��Ή�[8363] ---------->>>>>
                // �Ԏ�g�p���[�J�ȊO�̃��[�J�[�͑ΏۊO�Ƃ���
                if (makerUMnt.GoodsMakerCd > 999)
                {
                    status = -1;
                    return status;
                }
                // ADD 2008/12/02 �s��Ή�[8363] ----------<<<<<

            }
            else if (modelNamePrintWork.MakerCodeEd != 0)
            {
                if (makerUMnt.GoodsMakerCd > modelNamePrintWork.MakerCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            // ADD 2008/12/02 �s��Ή�[8363] ---------->>>>>
            else
            {
                // �Ԏ�g�p���[�J�ȊO�̃��[�J�[�͑ΏۊO�Ƃ���
                if (makerUMnt.GoodsMakerCd > 999)
                {
                    status = -1;
                    return status;
                }
            }
            // ADD 2008/12/02 �s��Ή�[8363] ----------<<<<<

            return status;
        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(ModelNameU modelNameU, ModelNamePrintWork modelNamePrintWork)
        {
            int status = 0;

            if (modelNameU.LogicalDeleteCode != modelNamePrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = modelNameU.UpdateDateTime.Year.ToString("0000") +
                                modelNameU.UpdateDateTime.Month.ToString("00") +
                                modelNameU.UpdateDateTime.Day.ToString("00");

            if (modelNamePrintWork.LogicalDeleteCode == 1 &&
                modelNamePrintWork.DeleteDateTimeSt != 0 &&
                modelNamePrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < modelNamePrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > modelNamePrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (modelNamePrintWork.LogicalDeleteCode == 1 &&
                        modelNamePrintWork.DeleteDateTimeSt != 0 &&
                        modelNamePrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < modelNamePrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (modelNamePrintWork.LogicalDeleteCode == 1 &&
                modelNamePrintWork.DeleteDateTimeSt == 0 &&
                modelNamePrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > modelNamePrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (modelNamePrintWork.MakerCodeSt != 0 &&
                modelNamePrintWork.MakerCodeEd != 0)
            {
                if (modelNameU.MakerCode < modelNamePrintWork.MakerCodeSt ||
                   modelNameU.MakerCode > modelNamePrintWork.MakerCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (modelNamePrintWork.MakerCodeSt != 0)
            {
                if (modelNameU.MakerCode < modelNamePrintWork.MakerCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (modelNamePrintWork.MakerCodeEd != 0)
            {
                if (modelNameU.MakerCode > modelNamePrintWork.MakerCodeEd)
                {
                    status = -1;
                    return status;
                }
            }

            if (modelNamePrintWork.ModelCodeSt != 0)
            {
                if (modelNameU.MakerCode == modelNamePrintWork.MakerCodeSt)
                {
                    if (modelNameU.ModelCode < modelNamePrintWork.ModelCodeSt)
                    {
                        status = -1;
                        return status;
                    }
                }
            }
            if (modelNamePrintWork.ModelCodeEd != 0)
            {
                if (modelNameU.MakerCode == modelNamePrintWork.MakerCodeEd)
                {
                    if (modelNameU.ModelCode > modelNamePrintWork.ModelCodeEd)
                    {
                        status = -1;
                        return status;
                    }
                }
            }

            if (modelNamePrintWork.ModelSubCodeSt != 0)
            {
                if (modelNameU.MakerCode == modelNamePrintWork.MakerCodeSt &&
                    modelNameU.ModelCode == modelNamePrintWork.ModelCodeSt)
                {
                    if (modelNameU.ModelSubCode < modelNamePrintWork.ModelSubCodeSt)
                    {
                        status = -1;
                        return status;
                    }
                }
            }
            if (modelNamePrintWork.ModelSubCodeEd != 0)
            {
                if (modelNameU.MakerCode == modelNamePrintWork.MakerCodeEd &&
                    modelNameU.ModelCode == modelNamePrintWork.ModelCodeEd)
                {
                    if (modelNameU.ModelSubCode > modelNamePrintWork.ModelSubCodeEd)
                    {
                        status = -1;
                        return status;
                    }
                }
            }
            return status;
        }
    }
}
