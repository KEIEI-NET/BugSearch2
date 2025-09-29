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
	/// �a�k�O���[�v�}�X�^�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �a�k�O���[�v�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class BLGroupSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private BLGroupUAcs _bLGroupUAcs;

        private Dictionary<int, UserGdBd> _salesCodeDic;
        private Dictionary<int, UserGdBd> _goodsLGroupDic;
        private UserGuideAcs _userGuideAcs;

        private Dictionary<int, GoodsGroupU> _goodsGroupDic;
        private GoodsGroupUAcs _goodsGroupUAcs;

        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// �a�k�O���[�v�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �a�k�O���[�v�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public BLGroupSetAcs()
		{
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            this._userGuideAcs = new UserGuideAcs();
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
		/// �a�k�O���[�v�}�X�^�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �a�k�O���[�v�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, BLGroupPrintWork bLGroupPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, bLGroupPrintWork);
		}

		/// <summary>
		/// �a�k�O���[�v�}�X�^���������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �a�k�O���[�v�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, BLGroupPrintWork bLGroupPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, bLGroupPrintWork);
		}

		

		/// <summary>
		/// �a�k�O���[�v�}�X�^��������
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
		/// <br>Note       : �a�k�O���[�v�}�X�^�̌����������s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, BLGroupPrintWork bLGroupPrintWork)
		{

            this._bLGroupUAcs = new BLGroupUAcs();

            int status = 0;
            int checkstatus = 0;

            //���f�[�^�L��������
            nextData = false;
            //0�ŏ�����
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList bLGroupUs = null;

            status = this._bLGroupUAcs.SearchAll(
                                out bLGroupUs,
                                enterpriseCode);

            foreach (BLGroupU bLGroupU in bLGroupUs)
            {
                // ���o����
                checkstatus = DataCheck(bLGroupU, bLGroupPrintWork);
                if (checkstatus == 0)
                {

                    //�a�k�O���[�v���N���X�փ����o�R�s�[
                    retList.Add(CopyToMakerSetFromSecInfoSetWork(bLGroupU, enterpriseCode));

                }
            }


            //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�a�k�O���[�v�}�X�^���[�N�N���X�˂a�k�O���[�v�}�X�^�N���X�j
        /// </summary>
        /// <param name="secInfoSetWork">�a�k�O���[�v�}�X�^���[�N�N���X</param>
        /// <returns>�a�k�O���[�v�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �a�k�O���[�v�}�X�^���[�N�N���X����a�k�O���[�v�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private BLGroupSet CopyToMakerSetFromSecInfoSetWork(BLGroupU bLGroupU, string enterpriseCode)
        {

            BLGroupSet bLGroupSet = new BLGroupSet();

            bLGroupSet.BLGroupCode = bLGroupU.BLGroupCode;
            bLGroupSet.BLGroupName = bLGroupU.BLGroupName;
            bLGroupSet.BLGroupKanaName = bLGroupU.BLGroupKanaName;
            bLGroupSet.SalesCode = bLGroupU.SalesCode;
            bLGroupSet.SalesCodeName = GetSalesCodeName(bLGroupU.SalesCode, enterpriseCode);
            bLGroupSet.GoodsLGroup = bLGroupU.GoodsLGroup;
            bLGroupSet.GoodsLGroupName = GetGoodsLGroupName(bLGroupU.GoodsLGroup, enterpriseCode);
            bLGroupSet.GoodsMGroup = bLGroupU.GoodsMGroup;
            bLGroupSet.GoodsMGroupName = GetGoodsMGroupName(bLGroupU.GoodsMGroup, enterpriseCode);


            return bLGroupSet;
        }

        /// <summary>
        /// �̔��敪���̎擾����
        /// </summary>
        /// <param name="salesCode">�̔��敪�R�[�h</param>
        /// <remarks>
        /// <br>Note       : �̔��敪���̂��擾���܂��B</br>
        /// </remarks>
        private string GetSalesCodeName(int salesCode, string enterpriseCode)
        {
            string salesCodeName = "";
            ReadSalesCode(enterpriseCode);
            if (this._salesCodeDic.ContainsKey(salesCode))
            {
                salesCodeName = this._salesCodeDic[salesCode].GuideName.Trim();
            }

            return salesCodeName;
        }


        /// <summary>
        /// �̔��敪�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �̔��敪�ꗗ��ǂݍ��݂܂��B</br>
        /// </remarks>
        private void ReadSalesCode(string enterpriseCode)
        {
            try
            {
                if (this._salesCodeDic.Count == 0)
                {
                    this._salesCodeDic = new Dictionary<int, UserGdBd>();

                    ArrayList retList;

                    // ���[�U�[�K�C�h�f�[�^�擾(�̔��敪)
                    int status = GetUserGuideBd(out retList, 71, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (UserGdBd userGdBd in retList)
                        {
                            if (userGdBd.LogicalDeleteCode == 0)
                            {
                                this._salesCodeDic.Add(userGdBd.GuideCode, userGdBd);
                            }
                        }
                    }
                }
            }
            catch
            {
                this._salesCodeDic = new Dictionary<int, UserGdBd>();

                ArrayList retList;

                // ���[�U�[�K�C�h�f�[�^�擾(�̔��敪)
                int status = GetUserGuideBd(out retList, 71, enterpriseCode);
                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            this._salesCodeDic.Add(userGdBd.GuideCode, userGdBd);
                        }
                    }
                }
            }
            return;
        }

        /// <summary>
        /// ���i�啪�ޖ��̎擾����
        /// </summary>
        /// <param name="goodsLGroupCode">���i�啪�ރR�[�h</param>
        /// <remarks>
        /// <br>Note       : ���i�啪�ޖ��̂��擾���܂��B</br>
        /// </remarks>
        private string GetGoodsLGroupName(int goodsLGroupCode, string enterpriseCode)
        {
            string goodsLGroupName = "";
            ReadGoodsLGroup(enterpriseCode);
            if (this._goodsLGroupDic.ContainsKey(goodsLGroupCode))
            {
                goodsLGroupName = this._goodsLGroupDic[goodsLGroupCode].GuideName.Trim();
            }

            return goodsLGroupName;
        }

        /// <summary>
        /// ���i�啪�ޓǍ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�啪�ވꗗ��ǂݍ��݂܂��B</br>
        /// </remarks>
        private void ReadGoodsLGroup(string enterpriseCode)
        {
            try
            {
                if (this._goodsLGroupDic.Count == 0)
                {
                    this._goodsLGroupDic = new Dictionary<int, UserGdBd>();

                    ArrayList retList;

                    // ���[�U�[�K�C�h�f�[�^�擾(���i�啪��)
                    int status = GetUserGuideBd(out retList, 70, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (UserGdBd userGdBd in retList)
                        {
                            if (userGdBd.LogicalDeleteCode == 0)
                            {
                                this._goodsLGroupDic.Add(userGdBd.GuideCode, userGdBd);
                            }
                        }
                    }
                }
            }
            catch
            {
                this._goodsLGroupDic = new Dictionary<int, UserGdBd>();

                ArrayList retList;

                // ���[�U�[�K�C�h�f�[�^�擾(���i�啪��)
                int status = GetUserGuideBd(out retList, 70, enterpriseCode);
                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            this._goodsLGroupDic.Add(userGdBd.GuideCode, userGdBd);
                        }
                    }
                }
            }
            return;
        }

        /// <summary>
        /// ���[�U�[�K�C�h�f�[�^�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�f�[�^���擾���܂��B</br>
        /// </remarks>
        private int GetUserGuideBd(out ArrayList retList, int userGuideDivCd, string enterpriseCode)
        {
            int status;
            retList = new ArrayList();

            status = this._userGuideAcs.SearchAllDivCodeBody(out retList, enterpriseCode,
                                                             userGuideDivCd, UserGuideAcsData.UserBodyData);

            return status;
        }

        /// <summary>
        /// ���i�����ޖ��̎擾����
        /// </summary>
        /// <param name="goodsMGroupCode">���i�����ރR�[�h</param>
        /// <remarks>
        /// <br>Note       : ���i�����ޖ��̂��擾���܂��B</br>
        /// </remarks>
        private string GetGoodsMGroupName(int goodsMGroupCode, string enterpriseCode)
        {
            string goodsMGroupName = "";
            ReadGoodsMGroup(enterpriseCode);
            if (this._goodsGroupDic.ContainsKey(goodsMGroupCode))
            {
                goodsMGroupName = this._goodsGroupDic[goodsMGroupCode].GoodsMGroupName.Trim();
            }

            return goodsMGroupName;
        }

        /// <summary>
        /// ���i�����ޓǍ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�����ވꗗ��ǂݍ��݂܂��B</br>
        /// </remarks>
        private void ReadGoodsMGroup(string enterpriseCode)
        {
            try
            {
                if (this._goodsGroupDic.Count == 0)
                {
                    this._goodsGroupDic = new Dictionary<int, GoodsGroupU>();

                    ArrayList retList;

                    int status = this._goodsGroupUAcs.SearchAll(out retList, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (GoodsGroupU goodsGroupU in retList)
                        {
                            if (goodsGroupU.LogicalDeleteCode == 0)
                            {
                                this._goodsGroupDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                            }
                        }
                    }
                }
            }
            catch
            {
                this._goodsGroupDic = new Dictionary<int, GoodsGroupU>();

                ArrayList retList;

                int status = this._goodsGroupUAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (GoodsGroupU goodsGroupU in retList)
                    {
                        if (goodsGroupU.LogicalDeleteCode == 0)
                        {
                            this._goodsGroupDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
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
        private int DataCheck(BLGroupU bLGroupU, BLGroupPrintWork bLGroupPrintWork)
        {
            int status = 0;

            if (bLGroupU.LogicalDeleteCode != bLGroupPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = bLGroupU.UpdateDateTime.Year.ToString("0000") +
                                bLGroupU.UpdateDateTime.Month.ToString("00") +
                                bLGroupU.UpdateDateTime.Day.ToString("00");

            if (bLGroupPrintWork.LogicalDeleteCode == 1 &&
                bLGroupPrintWork.DeleteDateTimeSt != 0 &&
                bLGroupPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < bLGroupPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > bLGroupPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (bLGroupPrintWork.LogicalDeleteCode == 1 &&
                        bLGroupPrintWork.DeleteDateTimeSt != 0 &&
                        bLGroupPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < bLGroupPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (bLGroupPrintWork.LogicalDeleteCode == 1 &&
                       bLGroupPrintWork.DeleteDateTimeSt == 0 &&
                       bLGroupPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > bLGroupPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (bLGroupPrintWork.BLGroupCodeSt != 0 &&
                bLGroupPrintWork.BLGroupCodeEd != 0)
            {
                if (bLGroupU.BLGroupCode < bLGroupPrintWork.BLGroupCodeSt ||
                   bLGroupU.BLGroupCode > bLGroupPrintWork.BLGroupCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (bLGroupPrintWork.BLGroupCodeSt != 0)
            {
                if (bLGroupU.BLGroupCode < bLGroupPrintWork.BLGroupCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (bLGroupPrintWork.BLGroupCodeEd != 0)
            {
                if (bLGroupU.BLGroupCode > bLGroupPrintWork.BLGroupCodeEd)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}
