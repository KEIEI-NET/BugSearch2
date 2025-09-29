using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.LocalAccess;
using Broadleaf.Application.Controller.Agent;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���l�K�C�h�}�X�^�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���l�K�C�h�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class NoteGuidSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private NoteGuidAcs _noteGuidAcs;
        private SubSectionAcs _subSectionAcs;

        private const int NULL_JOBTYPE_CODE = 0;
        private const string NULL_JOBTYPE_NAME = "";
        private const int NULL_EMPLOYMENTFORM_CODE = 0;
        private const string NULL_EMPLOYMENTFORM_NAME = "";

        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// ���l�K�C�h�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���l�K�C�h�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public NoteGuidSetAcs()
		{

            this._subSectionAcs = new SubSectionAcs();
                       		
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
		/// ���l�K�C�h�}�X�^�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���l�K�C�h�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, NoteGuidPrintWork noteGuidPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, noteGuidPrintWork);
		}

		/// <summary>
		/// ���l�K�C�h�}�X�^���������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���l�K�C�h�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, NoteGuidPrintWork noteGuidPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, noteGuidPrintWork);
		}

		

		/// <summary>
		/// ���l�K�C�h�}�X�^��������
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
		/// <br>Note       : ���l�K�C�h�}�X�^�̌����������s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, NoteGuidPrintWork noteGuidPrintWork)
		{

            this._noteGuidAcs = new NoteGuidAcs();

            int status = 0;
            int checkstatus = 0;

            //���f�[�^�L��������
            nextData = false;
            //0�ŏ�����
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList HeadList = null;
            ArrayList BodyList = null;

            status = this._noteGuidAcs.SearchAllHeader(
                                out HeadList,
                                enterpriseCode);

            status = this._noteGuidAcs.SearchAllBody(
                                out BodyList,
                                enterpriseCode);


            foreach (NoteGuidHd noteGuidHd in HeadList)
            {
                // ���o����
                checkstatus = DataCheck(noteGuidHd, noteGuidPrintWork);
                if (checkstatus == 0)
                {
                    foreach (NoteGuidBd noteGuidBd in BodyList)
                    {
                        if (noteGuidHd.NoteGuideDivCode == noteGuidBd.NoteGuideDivCode)
                        {
                            //���_���N���X�փ����o�R�s�[
                            retList.Add(CopyToNoteGuidSetFromSecInfoSetWork(noteGuidHd, noteGuidBd, enterpriseCode));
                            
                        }
                    }
                }
            }


            //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}



        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���l�K�C�h�}�X�^���[�N�N���X�˔��l�K�C�h�}�X�^�N���X�j
        /// </summary>
        /// <param name="secInfoSetWork">���l�K�C�h�}�X�^���[�N�N���X</param>
        /// <returns>���l�K�C�h�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���l�K�C�h�}�X�^���[�N�N���X������l�K�C�h�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private NoteGuidSet CopyToNoteGuidSetFromSecInfoSetWork(NoteGuidHd noteGuidHd,NoteGuidBd noteGuidBd, string enterpriseCode)
        {

            NoteGuidSet noteGuidSet = new NoteGuidSet();

            noteGuidSet.NoteGuideDivCode = noteGuidHd.NoteGuideDivCode;
            noteGuidSet.NoteGuideDivName = noteGuidHd.NoteGuideDivName;
            noteGuidSet.NoteGuideCode = noteGuidBd.NoteGuideCode;
            noteGuidSet.NoteGuideName = noteGuidBd.NoteGuideName;
            
            return noteGuidSet;
        }


        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(NoteGuidHd noteGuidHd, NoteGuidPrintWork noteGuidPrintWork)
        {
            int status = 0;

            if (noteGuidHd.LogicalDeleteCode != noteGuidPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = noteGuidHd.UpdateDateTime.Year.ToString("0000") +
                                noteGuidHd.UpdateDateTime.Month.ToString("00") +
                                noteGuidHd.UpdateDateTime.Day.ToString("00");

            if (noteGuidPrintWork.LogicalDeleteCode == 1 &&
                noteGuidPrintWork.DeleteDateTimeSt != 0 &&
                noteGuidPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < noteGuidPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > noteGuidPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (noteGuidPrintWork.LogicalDeleteCode == 1 &&
                        noteGuidPrintWork.DeleteDateTimeSt != 0 &&
                        noteGuidPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < noteGuidPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (noteGuidPrintWork.LogicalDeleteCode == 1 &&
             noteGuidPrintWork.DeleteDateTimeSt == 0 &&
             noteGuidPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > noteGuidPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (noteGuidPrintWork.NoteGuideDivCodeSt != 0 &&
                noteGuidPrintWork.NoteGuideDivCodeEd != 0)
            {
                if (noteGuidHd.NoteGuideDivCode < noteGuidPrintWork.NoteGuideDivCodeSt ||
                   noteGuidHd.NoteGuideDivCode > noteGuidPrintWork.NoteGuideDivCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (noteGuidPrintWork.NoteGuideDivCodeSt != 0)
            {
                if (noteGuidHd.NoteGuideDivCode < noteGuidPrintWork.NoteGuideDivCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (noteGuidPrintWork.NoteGuideDivCodeEd != 0)
            {
                if (noteGuidHd.NoteGuideDivCode > noteGuidPrintWork.NoteGuideDivCodeEd)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}
