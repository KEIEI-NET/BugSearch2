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
	/// ���[�U�[�K�C�h�}�X�^�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���[�U�[�K�C�h�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class UserGdSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private UserGuideAcs _userGuideAcs;
        

        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// ���[�U�[�K�C�h�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public UserGdSetAcs()
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
        /// ���[�U�[�K�C�h�w�b�_���̎擾
        /// </summary>
        /// <param name="retList"></param>
        /// <returns></returns>
        public int SearchHeader(out ArrayList retList)
        {
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }
            return this._userGuideAcs.SearchHeader(out retList);
        }

		/// <summary>
		/// ���[�U�[�K�C�h�}�X�^�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, UserGdPrintWork userGdPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, userGdPrintWork);
		}

		/// <summary>
		/// ���[�U�[�K�C�h�}�X�^���������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, UserGdPrintWork userGdPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, userGdPrintWork);
		}

		

		/// <summary>
		/// ���[�U�[�K�C�h�}�X�^��������
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
		/// <br>Note       : ���[�U�[�K�C�h�}�X�^�̌����������s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, UserGdPrintWork userGdPrintWork)
		{
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            int status = 0;
            int checkstatus = 0;

            //���f�[�^�L��������
            nextData = false;
            //0�ŏ�����
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList userGdBd = null;

            // ���[�U�[�K�C�h�i�{�f�B�j�擾
            status = this._userGuideAcs.SearchAllBody(
                    out userGdBd,
                    enterpriseCode,
                    UserGuideAcsData.OfferDivCodeMergeBodyData);

            foreach (UserGdBd usergdbd in userGdBd)
            {
                if (usergdbd.UserGuideDivCd == userGdPrintWork.UserGuideDivCd)
                {
                    // ���o����
                    checkstatus = DataCheck(usergdbd, userGdPrintWork);
                    if (checkstatus == 0)
                    {

                        //���[�U�[�K�C�h���N���X�փ����o�R�s�[
                        retList.Add(CopyToMakerSetFromSecInfoSetWork(usergdbd, enterpriseCode));

                    }
                }
            }

            //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���[�U�[�K�C�h�}�X�^���[�N�N���X�˃��[�U�[�K�C�h�}�X�^�N���X�j
        /// </summary>
        /// <param name="secInfoSetWork">���[�U�[�K�C�h�}�X�^���[�N�N���X</param>
        /// <returns>���[�U�[�K�C�h�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^���[�N�N���X���烆�[�U�[�K�C�h�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private UserGdSet CopyToMakerSetFromSecInfoSetWork(UserGdBd usergdbd, string enterpriseCode)
        {

            UserGdSet userGdSet = new UserGdSet();

            userGdSet.GuideCode = usergdbd.GuideCode;
            userGdSet.GuideName = usergdbd.GuideName;

            return userGdSet;
        }


        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(UserGdBd usergdbd, UserGdPrintWork userGdPrintWork)
        {
            int status = 0;

            if (usergdbd.LogicalDeleteCode != userGdPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = usergdbd.UpdateDateTime.Year.ToString("0000") +
                                usergdbd.UpdateDateTime.Month.ToString("00") +
                                usergdbd.UpdateDateTime.Day.ToString("00");

            if (userGdPrintWork.LogicalDeleteCode == 1 &&
                userGdPrintWork.DeleteDateTimeSt != 0 &&
                userGdPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < userGdPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > userGdPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (userGdPrintWork.LogicalDeleteCode == 1 &&
                        userGdPrintWork.DeleteDateTimeSt != 0 &&
                        userGdPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < userGdPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (userGdPrintWork.LogicalDeleteCode == 1 &&
                userGdPrintWork.DeleteDateTimeSt == 0 &&
                userGdPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > userGdPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (userGdPrintWork.GuideCodeSt != 0 &&
                userGdPrintWork.GuideCodeEd != 0)
            {
                if (usergdbd.GuideCode < userGdPrintWork.GuideCodeSt ||
                   usergdbd.GuideCode > userGdPrintWork.GuideCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (userGdPrintWork.GuideCodeSt != 0)
            {
                if (usergdbd.GuideCode < userGdPrintWork.GuideCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (userGdPrintWork.GuideCodeEd != 0)
            {
                if (usergdbd.GuideCode > userGdPrintWork.GuideCodeEd)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}
