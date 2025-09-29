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
	/// ���[�J�[�}�X�^�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���[�J�[�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class MakerSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private MakerAcs _makerAcs;
        

        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// ���[�J�[�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�J�[�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public MakerSetAcs()
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
		/// ���[�J�[�}�X�^�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���[�J�[�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, MakerPrintWork makerPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, makerPrintWork);
		}

		/// <summary>
		/// ���[�J�[�}�X�^���������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���[�J�[�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, MakerPrintWork makerPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, makerPrintWork);
		}

		

		/// <summary>
		/// ���[�J�[�}�X�^��������
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
		/// <br>Note       : ���[�J�[�}�X�^�̌����������s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, MakerPrintWork makerPrintWork)
		{

            this._makerAcs = new MakerAcs();

            int status = 0;
            int checkstatus = 0;

            //���f�[�^�L��������
            nextData = false;
            //0�ŏ�����
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList makerUMnts = null;

            status = this._makerAcs.SearchAll(
                                out makerUMnts,
                                enterpriseCode);

            foreach (MakerUMnt makerUMnt in makerUMnts)
            {
                // ���o����
                checkstatus = DataCheck(makerUMnt, makerPrintWork);
                if (checkstatus == 0)
                {

                    //���[�J�[���N���X�փ����o�R�s�[
                    retList.Add(CopyToMakerSetFromSecInfoSetWork(makerUMnt, enterpriseCode));

                }
            }


            //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���[�J�[�}�X�^���[�N�N���X�˃��[�J�[�}�X�^�N���X�j
        /// </summary>
        /// <param name="secInfoSetWork">���[�J�[�}�X�^���[�N�N���X</param>
        /// <returns>���[�J�[�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�}�X�^���[�N�N���X���烁�[�J�[�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private MakerSet CopyToMakerSetFromSecInfoSetWork(MakerUMnt makerUMnt, string enterpriseCode)
        {

            MakerSet makerSet = new MakerSet();

            makerSet.GoodsMakerCd = makerUMnt.GoodsMakerCd;
            makerSet.MakerName = makerUMnt.MakerName;
            makerSet.MakerShortName = makerUMnt.MakerShortName;
            makerSet.MakerKanaName = makerUMnt.MakerKanaName;
            makerSet.DisplayOrder = makerUMnt.DisplayOrder;

            return makerSet;
        }


        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(MakerUMnt makerUMnt, MakerPrintWork makerPrintWork)
        {
            int status = 0;

            if (makerUMnt.LogicalDeleteCode != makerPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = makerUMnt.UpdateDateTime.Year.ToString("0000") +
                                makerUMnt.UpdateDateTime.Month.ToString("00") +
                                makerUMnt.UpdateDateTime.Day.ToString("00");

            if (makerPrintWork.LogicalDeleteCode == 1 &&
                makerPrintWork.DeleteDateTimeSt != 0 &&
                makerPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < makerPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > makerPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (makerPrintWork.LogicalDeleteCode == 1 &&
                        makerPrintWork.DeleteDateTimeSt != 0 &&
                        makerPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < makerPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (makerPrintWork.LogicalDeleteCode == 1 &&
                makerPrintWork.DeleteDateTimeSt == 0 &&
                makerPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > makerPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (makerPrintWork.GoodsMakerCdSt != 0 &&
                makerPrintWork.GoodsMakerCdEd != 0)
            {
                if (makerUMnt.GoodsMakerCd < makerPrintWork.GoodsMakerCdSt ||
                   makerUMnt.GoodsMakerCd > makerPrintWork.GoodsMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (makerPrintWork.GoodsMakerCdSt != 0)
            {
                if (makerUMnt.GoodsMakerCd < makerPrintWork.GoodsMakerCdSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (makerPrintWork.GoodsMakerCdEd != 0)
            {
                if (makerUMnt.GoodsMakerCd > makerPrintWork.GoodsMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}
