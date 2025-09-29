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
	/// ���i�����ރ}�X�^�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���i�����ރ}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class GoodsGroupSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private GoodsGroupUAcs _goodsGroupUAcs;
        

        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// ���i�����ރ}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���i�����ރ}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public GoodsGroupSetAcs()
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
		/// ���i�����ރ}�X�^�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ރ}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, GoodsGroupPrintWork goodsGroupPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, goodsGroupPrintWork);
		}

		/// <summary>
		/// ���i�����ރ}�X�^���������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ރ}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, GoodsGroupPrintWork goodsGroupPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, goodsGroupPrintWork);
		}

		

		/// <summary>
		/// ���i�����ރ}�X�^��������
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
		/// <br>Note       : ���i�����ރ}�X�^�̌����������s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, GoodsGroupPrintWork goodsGroupPrintWork)
		{

            this._goodsGroupUAcs = new GoodsGroupUAcs();

            int status = 0;
            int checkstatus = 0;

            //���f�[�^�L��������
            nextData = false;
            //0�ŏ�����
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList goodsGroupUs = null;

            status = this._goodsGroupUAcs.SearchAll(
                                out goodsGroupUs,
                                enterpriseCode);

            foreach (GoodsGroupU goodsGroupU in goodsGroupUs)
            {
                // ���o����
                checkstatus = DataCheck(goodsGroupU, goodsGroupPrintWork);
                if (checkstatus == 0)
                {

                    //���i�����ޏ��N���X�փ����o�R�s�[
                    retList.Add(CopyToMakerSetFromSecInfoSetWork(goodsGroupU, enterpriseCode));

                }
            }


            //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���i�����ރ}�X�^���[�N�N���X�ˏ��i�����ރ}�X�^�N���X�j
        /// </summary>
        /// <param name="secInfoSetWork">���i�����ރ}�X�^���[�N�N���X</param>
        /// <returns>���i�����ރ}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���i�����ރ}�X�^���[�N�N���X���珤�i�����ރ}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private GoodsGroupSet CopyToMakerSetFromSecInfoSetWork(GoodsGroupU goodsGroupU, string enterpriseCode)
        {

            GoodsGroupSet goodsGroupSet = new GoodsGroupSet();

            goodsGroupSet.GoodsMGroup = goodsGroupU.GoodsMGroup;
            goodsGroupSet.GoodsMGroupName = goodsGroupU.GoodsMGroupName;

            return goodsGroupSet;
        }


        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(GoodsGroupU goodsGroupU, GoodsGroupPrintWork goodsGroupPrintWork)
        {
            int status = 0;

            if (goodsGroupU.LogicalDeleteCode != goodsGroupPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = goodsGroupU.UpdateDateTime.Year.ToString("0000") +
                                goodsGroupU.UpdateDateTime.Month.ToString("00") +
                                goodsGroupU.UpdateDateTime.Day.ToString("00");

            if (goodsGroupPrintWork.LogicalDeleteCode == 1 &&
                goodsGroupPrintWork.DeleteDateTimeSt != 0 &&
                goodsGroupPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < goodsGroupPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > goodsGroupPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (goodsGroupPrintWork.LogicalDeleteCode == 1 &&
                        goodsGroupPrintWork.DeleteDateTimeSt != 0 &&
                        goodsGroupPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < goodsGroupPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (goodsGroupPrintWork.LogicalDeleteCode == 1 &&
                   goodsGroupPrintWork.DeleteDateTimeSt == 0 &&
                   goodsGroupPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > goodsGroupPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (goodsGroupPrintWork.GoodsMGroupSt != 0 &&
                goodsGroupPrintWork.GoodsMGroupEd != 0)
            {
                if (goodsGroupU.GoodsMGroup < goodsGroupPrintWork.GoodsMGroupSt ||
                   goodsGroupU.GoodsMGroup > goodsGroupPrintWork.GoodsMGroupEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (goodsGroupPrintWork.GoodsMGroupSt != 0)
            {
                if (goodsGroupU.GoodsMGroup < goodsGroupPrintWork.GoodsMGroupSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (goodsGroupPrintWork.GoodsMGroupEd != 0)
            {
                if (goodsGroupU.GoodsMGroup > goodsGroupPrintWork.GoodsMGroupEd)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}
