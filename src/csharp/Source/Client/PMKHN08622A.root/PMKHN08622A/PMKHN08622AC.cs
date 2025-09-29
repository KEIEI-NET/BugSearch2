using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �������i�}�X�^�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �������i�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class IsolIslandPrcSetAcs 
	{

        private static bool _isLocalDBRead = false;

        /// <summary>�������i�}�X�^�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IIsolIslandPrcDB _iIsolIslandPrcDB = null;

        private Dictionary<int, SecInfoSet> _secInfoDic;
        private SecInfoSetAcs _secInfoAcs;

        private Dictionary<int, MakerUMnt> _MakerDic; 
        private MakerAcs _makerAcs;

        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// �������i�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �������i�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public IsolIslandPrcSetAcs()
		{
            // �����[�g�I�u�W�F�N�g�擾
            this._iIsolIslandPrcDB = (IIsolIslandPrcDB)MediationIsolIslandPrcDB.GetIsolIslandPrcDB();

			this._makerAcs = new MakerAcs();
            this._secInfoAcs = new SecInfoSetAcs();
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
		/// �������i�}�X�^�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������i�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, IsolIslandPrcPrintWork isolIslandPrcPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, isolIslandPrcPrintWork);
		}

		/// <summary>
		/// �������i�}�X�^���������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������i�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, IsolIslandPrcPrintWork isolIslandPrcPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, isolIslandPrcPrintWork);
		}

		

		/// <summary>
		/// �������i�}�X�^��������
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <param name="readCnt">�Ǎ�����</param>
        /// <param name="isolIslandPrcPrintWork">���o����</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������i�}�X�^�̌����������s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, IsolIslandPrcPrintWork isolIslandPrcPrintWork)
		{
            int status = 0;
            int checkstatus = 0;

            //���f�[�^�L��������
            nextData = false;
            //0�ŏ�����
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            // �L�[�����Z�b�g
            IsolIslandPrcWork paramIsolIslandPrcWork = new IsolIslandPrcWork();
            paramIsolIslandPrcWork.EnterpriseCode = enterpriseCode;    // ��ƃR�[�h

            ArrayList retArray = new ArrayList();
            object retobj = (object)retArray;

            // �������i�}�X�^����
            status = this._iIsolIslandPrcDB.Search(ref retobj, paramIsolIslandPrcWork, 0, logicalMode);

            retArray = retobj as ArrayList;

            foreach (IsolIslandPrcWork isolIslandPrcWork in retArray)
            {
                // ���o����
                checkstatus = DataCheck(isolIslandPrcWork, isolIslandPrcPrintWork);
                if (checkstatus == 0)
                {

                    //�������i���N���X�փ����o�R�s�[
                    retList.Add(CopyToIsolIslandPrcSetFromSecInfoSetWork(isolIslandPrcWork, enterpriseCode));

                }
            }

            //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
            if (readCnt == 0) retTotalCnt = retList.Count;

            
			return status;
		}

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�������i�}�X�^���[�N�N���X�˗������i�}�X�^�N���X�j
        /// </summary>
        /// <param name="secInfoSetWork">�������i�}�X�^���[�N�N���X</param>
        /// <returns>�������i�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �������i�}�X�^���[�N�N���X���痣�����i�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private IsolIslandPrcSet CopyToIsolIslandPrcSetFromSecInfoSetWork(IsolIslandPrcWork isolIslandPrcWork, string enterpriseCode)
        {

            IsolIslandPrcSet isolIslandPrcSet = new IsolIslandPrcSet();

            isolIslandPrcSet.SectionCode = isolIslandPrcWork.SectionCode;
            isolIslandPrcSet.SectionGuideSnm = GetSectionName(isolIslandPrcWork.SectionCode.Trim(), enterpriseCode);
            isolIslandPrcSet.MakerCode = isolIslandPrcWork.MakerCode;
            isolIslandPrcSet.MakerShortName = GetMakerName(isolIslandPrcWork.MakerCode, enterpriseCode);
            isolIslandPrcSet.UpperLimitPrice = isolIslandPrcWork.UpperLimitPrice;
            isolIslandPrcSet.FractionProcUnit = isolIslandPrcWork.FractionProcUnit;
            isolIslandPrcSet.FractionProcCd = isolIslandPrcWork.FractionProcCd;
            isolIslandPrcSet.UpRate = isolIslandPrcWork.UpRate;


            return isolIslandPrcSet;
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// </remarks>
        private string GetSectionName(string sectionCode, string enterpriseCode)
        {
            string sectionName = "";
            ReadSecInfo(enterpriseCode);
            if (this._secInfoDic.ContainsKey(Int32.Parse(sectionCode)))
            {
                sectionName = this._secInfoDic[Int32.Parse(sectionCode)].SectionGuideNm.Trim();
            }

            return sectionName;
        }

        /// <summary>
        /// ���_���Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_���ꗗ��ǂݍ��݂܂��B</br>
        /// </remarks>
        private void ReadSecInfo(string enterpriseCode)
        {
            try
            {
                if (this._secInfoDic.Count == 0)
                {
                    this._secInfoDic = new Dictionary<int, SecInfoSet>();

                    ArrayList retList;

                    int status = this._secInfoAcs.SearchAll(out retList, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (SecInfoSet secInfoSet in retList)
                        {
                            if (secInfoSet.LogicalDeleteCode == 0)
                            {
                                this._secInfoDic.Add(Int32.Parse(secInfoSet.SectionCode), secInfoSet);
                            }
                        }
                    }
                }
            }
            catch
            {
                this._secInfoDic = new Dictionary<int, SecInfoSet>();

                ArrayList retList;

                int status = this._secInfoAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (SecInfoSet secInfoSet in retList)
                    {
                        if (secInfoSet.LogicalDeleteCode == 0)
                        {
                            this._secInfoDic.Add(Int32.Parse(secInfoSet.SectionCode), secInfoSet);
                        }
                    }
                }
            }
            return;
        }

        /// <summary>
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[����</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[���̂��擾���܂��B</br>
        /// </remarks>
        private string GetMakerName(int makerCode, string enterpriseCode)
        {
            string makerName = "";
            ReadMaker(enterpriseCode);
            if (this._MakerDic.ContainsKey(makerCode))
            {
                makerName = this._MakerDic[makerCode].MakerName.Trim();
            }

            return makerName;
        }

        /// <summary>
        /// ���[�J�[�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J�[�ꗗ��ǂݍ��݂܂��B</br>
        /// </remarks>
        private void ReadMaker(string enterpriseCode)
        {
            try
            {
                if (this._MakerDic.Count == 0)
                {
                    this._MakerDic = new Dictionary<int, MakerUMnt>();

                    ArrayList retList;

                    int status = this._makerAcs.SearchAll(out retList, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (MakerUMnt mkerUMnt in retList)
                        {
                            if (mkerUMnt.LogicalDeleteCode == 0)
                            {
                                this._MakerDic.Add(mkerUMnt.GoodsMakerCd, mkerUMnt);
                            }
                        }
                    }
                }
            }
            catch
            {
                this._MakerDic = new Dictionary<int, MakerUMnt>();

                    ArrayList retList;

                    int status = this._makerAcs.SearchAll(out retList, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (MakerUMnt mkerUMnt in retList)
                        {
                            if (mkerUMnt.LogicalDeleteCode == 0)
                            {
                                this._MakerDic.Add(mkerUMnt.GoodsMakerCd, mkerUMnt);
                            }
                        }
                    }
            }
            return;
        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="isolIslandPrcPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(IsolIslandPrcWork isolIslandPrcWork, IsolIslandPrcPrintWork isolIslandPrcPrintWork)
        {
            int status = 0;

            if (isolIslandPrcWork.LogicalDeleteCode != isolIslandPrcPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = isolIslandPrcWork.UpdateDateTime.Year.ToString("0000") +
                                isolIslandPrcWork.UpdateDateTime.Month.ToString("00") +
                                isolIslandPrcWork.UpdateDateTime.Day.ToString("00");

            if (isolIslandPrcPrintWork.LogicalDeleteCode == 1 &&
                isolIslandPrcPrintWork.DeleteDateTimeSt != 0 &&
                isolIslandPrcPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < isolIslandPrcPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > isolIslandPrcPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (isolIslandPrcPrintWork.LogicalDeleteCode == 1 &&
                        isolIslandPrcPrintWork.DeleteDateTimeSt != 0 &&
                        isolIslandPrcPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < isolIslandPrcPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (isolIslandPrcPrintWork.LogicalDeleteCode == 1 &&
                isolIslandPrcPrintWork.DeleteDateTimeSt == 0 &&
                isolIslandPrcPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > isolIslandPrcPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (!isolIslandPrcPrintWork.SectionCodeSt.Trim().Equals(string.Empty) &&
                !isolIslandPrcPrintWork.SectionCodeEd.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(isolIslandPrcWork.SectionCode) < Int32.Parse(isolIslandPrcPrintWork.SectionCodeSt) ||
                   Int32.Parse(isolIslandPrcWork.SectionCode) > Int32.Parse(isolIslandPrcPrintWork.SectionCodeEd))
                {
                    status = -1;
                    return status;
                }
            }
            else if (!isolIslandPrcPrintWork.SectionCodeSt.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(isolIslandPrcWork.SectionCode) < Int32.Parse(isolIslandPrcPrintWork.SectionCodeSt))
                {
                    status = -1;
                    return status;
                }
            }
            else if (!isolIslandPrcPrintWork.SectionCodeEd.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(isolIslandPrcWork.SectionCode) > Int32.Parse(isolIslandPrcPrintWork.SectionCodeEd))
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}
