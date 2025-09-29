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
	/// ��փ}�X�^�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ��փ}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class PartsSubstSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private PartsSubstUAcs _partsSubstUAcs;

        private Dictionary<int, MakerUMnt> _MakerDic;
        private MakerAcs _makerAcs;
        

        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// ��փ}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��փ}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public PartsSubstSetAcs()
		{
            this._makerAcs = new MakerAcs();
			
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
		/// ��փ}�X�^�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ��փ}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, PartsSubstPrintWork partsSubstPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, partsSubstPrintWork);
		}

		/// <summary>
		/// ��փ}�X�^���������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ��փ}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, PartsSubstPrintWork partsSubstPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, partsSubstPrintWork);
		}

		

		/// <summary>
		/// ��փ}�X�^��������
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
		/// <br>Note       : ��փ}�X�^�̌����������s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, PartsSubstPrintWork partsSubstPrintWork)
		{

            this._partsSubstUAcs = new PartsSubstUAcs();

            int status = 0;
            int checkstatus = 0;

            //���f�[�^�L��������
            nextData = false;
            //0�ŏ�����
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList partsSubstUs = null;

            status = this._partsSubstUAcs.SearchAll(
                                out partsSubstUs,
                                enterpriseCode);

            foreach (PartsSubstU partsSubstU in partsSubstUs)
            {
                // ���o����
                checkstatus = DataCheck(partsSubstU, partsSubstPrintWork);
                if (checkstatus == 0)
                {

                    //��֏��N���X�փ����o�R�s�[
                    retList.Add(CopyToMakerSetFromSecInfoSetWork(partsSubstU, enterpriseCode));

                }
            }


            //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i��փ}�X�^���[�N�N���X�ˑ�փ}�X�^�N���X�j
        /// </summary>
        /// <param name="secInfoSetWork">��փ}�X�^���[�N�N���X</param>
        /// <returns>��փ}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : ��փ}�X�^���[�N�N���X�����փ}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private PartsSubstSet CopyToMakerSetFromSecInfoSetWork(PartsSubstU partsSubstU, string enterpriseCode)
        {

            PartsSubstSet partsSubstSet = new PartsSubstSet();

            partsSubstSet.ChgSrcMakerCd = partsSubstU.ChgSrcMakerCd;
            partsSubstSet.ChgSrcMakerName = GetMakerName(partsSubstU.ChgSrcMakerCd,enterpriseCode);
            partsSubstSet.ChgSrcGoodsNo = partsSubstU.ChgSrcGoodsNo;
            partsSubstSet.ChgDestMakerCd = partsSubstU.ChgDestMakerCd;
            partsSubstSet.ChgDestMakerName = GetMakerName(partsSubstU.ChgDestMakerCd, enterpriseCode);
            partsSubstSet.ChgDestGoodsNo = partsSubstU.ChgDestGoodsNo;
            partsSubstSet.ApplyStaDate = partsSubstU.ApplyStaDate;
            partsSubstSet.ApplyEndDate = partsSubstU.ApplyEndDate;


            return partsSubstSet;
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
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(PartsSubstU partsSubstU, PartsSubstPrintWork partsSubstPrintWork)
        {
            int status = 0;

            if (partsSubstU.LogicalDeleteCode != partsSubstPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = partsSubstU.UpdateDateTime.Year.ToString("0000") +
                                partsSubstU.UpdateDateTime.Month.ToString("00") +
                                partsSubstU.UpdateDateTime.Day.ToString("00");

            if (partsSubstPrintWork.LogicalDeleteCode == 1 &&
                partsSubstPrintWork.DeleteDateTimeSt != 0 &&
                partsSubstPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < partsSubstPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > partsSubstPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (partsSubstPrintWork.LogicalDeleteCode == 1 &&
                        partsSubstPrintWork.DeleteDateTimeSt != 0 &&
                        partsSubstPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < partsSubstPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (partsSubstPrintWork.LogicalDeleteCode == 1 &&
                partsSubstPrintWork.DeleteDateTimeSt == 0 &&
                partsSubstPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > partsSubstPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (partsSubstPrintWork.ChgSrcMakerCdSt != 0 &&
                partsSubstPrintWork.ChgSrcMakerCdEd != 0)
            {
                if (partsSubstU.ChgSrcMakerCd < partsSubstPrintWork.ChgSrcMakerCdSt ||
                   partsSubstU.ChgSrcMakerCd > partsSubstPrintWork.ChgSrcMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (partsSubstPrintWork.ChgSrcMakerCdSt != 0)
            {
                if (partsSubstU.ChgSrcMakerCd < partsSubstPrintWork.ChgSrcMakerCdSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (partsSubstPrintWork.ChgSrcMakerCdEd != 0)
            {
                if (partsSubstU.ChgSrcMakerCd > partsSubstPrintWork.ChgSrcMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }

            if (!partsSubstPrintWork.ChgSrcGoodsNoSt.Trim().Equals(string.Empty) &&
                !partsSubstPrintWork.ChgSrcGoodsNoEd.Trim().Equals(string.Empty))
            {
                if (partsSubstPrintWork.ChgSrcGoodsNoSt.CompareTo(partsSubstU.ChgSrcGoodsNo) > 0 ||
                    partsSubstPrintWork.ChgSrcGoodsNoEd.CompareTo(partsSubstU.ChgSrcGoodsNo) < 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!partsSubstPrintWork.ChgSrcGoodsNoSt.Trim().Equals(string.Empty))
            {
                if (partsSubstPrintWork.ChgSrcGoodsNoSt.CompareTo(partsSubstU.ChgSrcGoodsNo) > 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!partsSubstPrintWork.ChgSrcGoodsNoEd.Trim().Equals(string.Empty))
            {
                if (partsSubstPrintWork.ChgSrcGoodsNoEd.CompareTo(partsSubstU.ChgSrcGoodsNo) < 0)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}
