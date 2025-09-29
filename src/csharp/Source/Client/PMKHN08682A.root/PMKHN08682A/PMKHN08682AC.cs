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
	/// ���ʃ}�X�^�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���ʃ}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class PartsPosCodeSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private PartsPosCodeUAcs _partsPosCodeUAcs;
        

        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// ���ʃ}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ʃ}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public PartsPosCodeSetAcs()
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
		/// ���ʃ}�X�^�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���ʃ}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, PartsPosCodePrintWork partsPosCodePrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, partsPosCodePrintWork);
		}

		/// <summary>
		/// ���ʃ}�X�^���������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���ʃ}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, PartsPosCodePrintWork partsPosCodePrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, partsPosCodePrintWork);
		}

		

		/// <summary>
		/// ���ʃ}�X�^��������
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
		/// <br>Note       : ���ʃ}�X�^�̌����������s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, PartsPosCodePrintWork partsPosCodePrintWork)
		{

            this._partsPosCodeUAcs = new PartsPosCodeUAcs();

            int status = 0;
            int checkstatus = 0;

            //���f�[�^�L��������
            nextData = false;
            //0�ŏ�����
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList partsPosCodeUs = null;
            string strname = "";

            status = this._partsPosCodeUAcs.SearchAll(
                                out partsPosCodeUs,
                                enterpriseCode);

            foreach (PartsPosCodeU partsPosCodeU in partsPosCodeUs)
            {
                // ���o����
                checkstatus = DataCheck(partsPosCodeU, partsPosCodePrintWork);
                if (checkstatus == 0)
                {
                    if (partsPosCodeU.TbsPartsCode != 0)
                    {
                        //���ʏ��N���X�փ����o�R�s�[
                        retList.Add(CopyToMakerSetFromSecInfoSetWork(partsPosCodeU, enterpriseCode, strname));
                    }
                    else
                    {
                        strname = partsPosCodeU.SearchPartsPosName;
                    }

                }
            }


            //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���ʃ}�X�^���[�N�N���X�˕��ʃ}�X�^�N���X�j
        /// </summary>
        /// <param name="secInfoSetWork">���ʃ}�X�^���[�N�N���X</param>
        /// <returns>���ʃ}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���ʃ}�X�^���[�N�N���X���畔�ʃ}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private PartsPosCodeSet CopyToMakerSetFromSecInfoSetWork(PartsPosCodeU partsPosCodeU, string enterpriseCode, string name)
        {

            PartsPosCodeSet partsPosCodeSet = new PartsPosCodeSet();

            partsPosCodeSet.CustomerCode = partsPosCodeU.CustomerCode;
            if (partsPosCodeU.CustomerCode == 0)
            {
                partsPosCodeSet.CustomerSnm = "���ʐݒ�";
            }
            else
            {
                partsPosCodeSet.CustomerSnm = partsPosCodeU.CustomerSnm;
            }
            partsPosCodeSet.SearchPartsPosCode = partsPosCodeU.SearchPartsPosCode;
            partsPosCodeSet.SearchPartsPosName = name;
            partsPosCodeSet.PosDispOrder = partsPosCodeU.PosDispOrder;
            partsPosCodeSet.TbsPartsCode = partsPosCodeU.TbsPartsCode;
            partsPosCodeSet.BLGoodsHalfName = partsPosCodeU.TbsPartsName;

            return partsPosCodeSet;
        }


        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(PartsPosCodeU partsPosCodeU, PartsPosCodePrintWork partsPosCodePrintWork)
        {
            int status = 0;

            if (partsPosCodeU.LogicalDeleteCode != partsPosCodePrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = partsPosCodeU.UpdateDateTime.Year.ToString("0000") +
                                partsPosCodeU.UpdateDateTime.Month.ToString("00") +
                                partsPosCodeU.UpdateDateTime.Day.ToString("00");

            if (partsPosCodePrintWork.LogicalDeleteCode == 1 &&
                partsPosCodePrintWork.DeleteDateTimeSt != 0 &&
                partsPosCodePrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < partsPosCodePrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > partsPosCodePrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (partsPosCodePrintWork.LogicalDeleteCode == 1 &&
                        partsPosCodePrintWork.DeleteDateTimeSt != 0 &&
                        partsPosCodePrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < partsPosCodePrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (partsPosCodePrintWork.LogicalDeleteCode == 1 &&
                partsPosCodePrintWork.DeleteDateTimeSt == 0 &&
                partsPosCodePrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > partsPosCodePrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (partsPosCodePrintWork.SearchPartsPosCodeSt != 0 &&
                partsPosCodePrintWork.SearchPartsPosCodeEd != 0)
            {
                if (partsPosCodeU.SearchPartsPosCode < partsPosCodePrintWork.SearchPartsPosCodeSt ||
                   partsPosCodeU.SearchPartsPosCode > partsPosCodePrintWork.SearchPartsPosCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (partsPosCodePrintWork.SearchPartsPosCodeSt != 0)
            {
                if (partsPosCodeU.SearchPartsPosCode < partsPosCodePrintWork.SearchPartsPosCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (partsPosCodePrintWork.SearchPartsPosCodeEd != 0)
            {
                if (partsPosCodeU.SearchPartsPosCode > partsPosCodePrintWork.SearchPartsPosCodeEd)
                {
                    status = -1;
                    return status;
                }
            }

            if (partsPosCodePrintWork.CustomerCodeSt != 0 &&
                partsPosCodePrintWork.CustomerCodeEd != 0)
            {
                if (partsPosCodeU.CustomerCode < partsPosCodePrintWork.CustomerCodeSt ||
                   partsPosCodeU.CustomerCode > partsPosCodePrintWork.CustomerCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (partsPosCodePrintWork.CustomerCodeSt != 0)
            {
                if (partsPosCodeU.CustomerCode < partsPosCodePrintWork.CustomerCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (partsPosCodePrintWork.CustomerCodeEd != 0)
            {
                if (partsPosCodeU.CustomerCode > partsPosCodePrintWork.CustomerCodeEd)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}
