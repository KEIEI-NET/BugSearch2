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
	/// �Z�b�g�}�X�^�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �Z�b�g�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class GoodsSetSetAcs 
	{

        private static bool _isLocalDBRead = false;

        /// <summary>���i�Z�b�g�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IGoodsSetDB _iGoodsSetDB = null;

        private Dictionary<int, MakerUMnt> _MakerDic;
        private MakerAcs _makerAcs;

        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// �Z�b�g�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �Z�b�g�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public GoodsSetSetAcs()
		{
            // ���i�Z�b�g�}�X�^�����[�g�I�u�W�F�N�g�擾
            this._iGoodsSetDB = (IGoodsSetDB)MediationGoodsSetDB.GetGoodsSetDB();
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
		/// �Z�b�g�}�X�^�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �Z�b�g�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, GoodsSetPrintWork goodsSetPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, goodsSetPrintWork);
		}

		/// <summary>
		/// �Z�b�g�}�X�^���������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �Z�b�g�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, GoodsSetPrintWork goodsSetPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, goodsSetPrintWork);
		}

		

		/// <summary>
		/// �Z�b�g�}�X�^��������
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
		/// <br>Note       : �Z�b�g�}�X�^�̌����������s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, GoodsSetPrintWork goodsSetPrintWork)
		{
            GoodsSetWork goodsSetWork = new GoodsSetWork();
            goodsSetWork.EnterpriseCode = enterpriseCode;

            int status = 0;
            int checkstatus = 0;
            nextData = false;
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList paraList = new ArrayList();
            paraList.Clear();

            object paraobj = goodsSetWork;
            object retobj = paraList;

            status = this._iGoodsSetDB.Search(out retobj, paraobj, 0, logicalMode);

            paraList = (ArrayList)retobj;

            foreach (GoodsSetWork goodsSetWorkdata in paraList)
            {
                // ���o����
                checkstatus = DataCheck(goodsSetWorkdata, goodsSetPrintWork);
                if (checkstatus == 0)
                {
                    //�Z�b�g���N���X�փ����o�R�s�[
                    retList.Add(CopyToMakerSetFromSecInfoSetWork(goodsSetWorkdata, enterpriseCode));
                }
            }
            //this._makerAcs = new MakerAcs();

            //int status = 0;
            //int checkstatus = 0;

            ////���f�[�^�L��������
            //nextData = false;
            ////0�ŏ�����
            //retTotalCnt = 0;

            //retList = new ArrayList();
            //retList.Clear();

            //ArrayList makerUMnts = null;

            //status = this._makerAcs.SearchAll(
            //                    out makerUMnts,
            //                    enterpriseCode);

            //foreach (MakerUMnt makerUMnt in makerUMnts)
            //{
            //    // ���o����
            //    checkstatus = DataCheck(makerUMnt, goodsSetPrintWork);
            //    if (checkstatus == 0)
            //    {

            //        //�Z�b�g���N���X�փ����o�R�s�[
            //        retList.Add(CopyToMakerSetFromSecInfoSetWork(makerUMnt, enterpriseCode));

            //    }
            //}


            ////�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
            //if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�Z�b�g�}�X�^���[�N�N���X�˃Z�b�g�}�X�^�N���X�j
        /// </summary>
        /// <param name="secInfoSetWork">�Z�b�g�}�X�^���[�N�N���X</param>
        /// <returns>�Z�b�g�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �Z�b�g�}�X�^���[�N�N���X����Z�b�g�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private GoodsSetSet CopyToMakerSetFromSecInfoSetWork(GoodsSetWork goodsSetWorkdata, string enterpriseCode)
        {

            GoodsSetSet goodsSetSet = new GoodsSetSet();

            goodsSetSet.ParentGoodsMakerCd = goodsSetWorkdata.ParentGoodsMakerCd;
            goodsSetSet.ParentGoodsMakerName = GetMakerName(goodsSetWorkdata.ParentGoodsMakerCd, enterpriseCode);
            goodsSetSet.ParentGoodsNo = goodsSetWorkdata.ParentGoodsNo;
            goodsSetSet.DisplayOrder = goodsSetWorkdata.DisplayOrder;
            goodsSetSet.SubGoodsNo = goodsSetWorkdata.SubGoodsNo;
            goodsSetSet.GoodsNameKana = goodsSetWorkdata.SubGoodsName;
            goodsSetSet.SubGoodsMakerCd = goodsSetWorkdata.SubGoodsMakerCd;
            goodsSetSet.SubGoodsMakerName = goodsSetWorkdata.SubMakerName;
            goodsSetSet.CntFl = goodsSetWorkdata.CntFl;
            goodsSetSet.SetSpecialNote = goodsSetWorkdata.SetSpecialNote;



            return goodsSetSet;
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
        private int DataCheck(GoodsSetWork goodsSetWorkdata, GoodsSetPrintWork goodsSetPrintWork)
        {
            int status = 0;

            if (goodsSetWorkdata.LogicalDeleteCode != goodsSetPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = goodsSetWorkdata.UpdateDateTime.Year.ToString("0000") +
                                goodsSetWorkdata.UpdateDateTime.Month.ToString("00") +
                                goodsSetWorkdata.UpdateDateTime.Day.ToString("00");

            if (goodsSetPrintWork.LogicalDeleteCode == 1 &&
                goodsSetPrintWork.DeleteDateTimeSt != 0 &&
                goodsSetPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < goodsSetPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > goodsSetPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (goodsSetPrintWork.LogicalDeleteCode == 1 &&
                        goodsSetPrintWork.DeleteDateTimeSt != 0 &&
                        goodsSetPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < goodsSetPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (goodsSetPrintWork.LogicalDeleteCode == 1 &&
                goodsSetPrintWork.DeleteDateTimeSt == 0 &&
                goodsSetPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > goodsSetPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (goodsSetPrintWork.ParentGoodsMakerCdSt != 0 &&
                goodsSetPrintWork.ParentGoodsMakerCdEd != 0)
            {
                if (goodsSetWorkdata.ParentGoodsMakerCd < goodsSetPrintWork.ParentGoodsMakerCdSt ||
                   goodsSetWorkdata.ParentGoodsMakerCd > goodsSetPrintWork.ParentGoodsMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (goodsSetPrintWork.ParentGoodsMakerCdSt != 0)
            {
                if (goodsSetWorkdata.ParentGoodsMakerCd < goodsSetPrintWork.ParentGoodsMakerCdSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (goodsSetPrintWork.ParentGoodsMakerCdEd != 0)
            {
                if (goodsSetWorkdata.ParentGoodsMakerCd > goodsSetPrintWork.ParentGoodsMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }

            if (!goodsSetPrintWork.ParentGoodsNoSt.Trim().Equals(string.Empty) &&
                !goodsSetPrintWork.ParentGoodsNoEd.Trim().Equals(string.Empty))
            {
                if (goodsSetPrintWork.ParentGoodsNoSt.CompareTo(goodsSetWorkdata.ParentGoodsNo) > 0 ||
                    goodsSetPrintWork.ParentGoodsNoEd.CompareTo(goodsSetWorkdata.ParentGoodsNo) < 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!goodsSetPrintWork.ParentGoodsNoSt.Trim().Equals(string.Empty))
            {
                if (goodsSetPrintWork.ParentGoodsNoSt.CompareTo(goodsSetWorkdata.ParentGoodsNo) > 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!goodsSetPrintWork.ParentGoodsNoEd.Trim().Equals(string.Empty))
            {
                if (goodsSetPrintWork.ParentGoodsNoEd.CompareTo(goodsSetWorkdata.ParentGoodsNo) < 0)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}
