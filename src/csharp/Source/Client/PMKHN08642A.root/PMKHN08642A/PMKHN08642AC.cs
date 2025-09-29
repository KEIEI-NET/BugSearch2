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
	/// �����}�X�^�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �����}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class JoinPartsSetAcs 
	{
        #region public�֘A
        /// <summary>���i�A���f�[�^�ێ��p</summary>
        public struct F_DATA_GOODSUNIT
        {
            /// <summary>�����惁�[�J�[�R�[�h</summary>
            public int joinDestMakerCd;
            /// <summary>������i��</summary>
            public string joinDestPartsNo;
        }

        /// <summary>
        /// ���i�}�X�^�A�N�Z�X���擾���܂��B
        /// </summary>
        /// <value>���i�}�X�^�A�N�Z�X</value>
        public GoodsAcsProxy GoodsAccess
        {
            get { return (GoodsAcsProxy)_goodsAcs; }
        }
        #endregion

        private static bool _isLocalDBRead = false;

        /// <summary>���i�Z�b�g�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IJoinPartsUDB _iGoodsSetDB;

        private Dictionary<int, MakerUMnt> _MakerDic;
        private MakerAcs _makerAcs;

        /// <summary>���i�}�X�^�A�N�Z�X</summary>
        private readonly GoodsAcs _goodsAcs;

        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// �����}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public JoinPartsSetAcs()
		{
            this._iGoodsSetDB = (IJoinPartsUDB)MediationJoinPartsUDB.GetJoinPartsUDB();
            this._makerAcs = new MakerAcs();
            this._goodsAcs = new GoodsAcsProxy();
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
		/// �����}�X�^�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �����}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, JoinPartsPrintWork joinPartsPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, joinPartsPrintWork);
		}

		/// <summary>
		/// �����}�X�^���������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �����}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, JoinPartsPrintWork joinPartsPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, joinPartsPrintWork);
		}

		

		/// <summary>
		/// �����}�X�^��������
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
		/// <br>Note       : �����}�X�^�̌����������s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, JoinPartsPrintWork joinPartsPrintWork)
		{

            JoinPartsUWork goodsSetWork = new JoinPartsUWork();
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
            object retobj = new ArrayList();

            status = this._iGoodsSetDB.Search(ref retobj, paraobj, 0, logicalMode);

            paraList = retobj as ArrayList;

            // [[�������L���b�V��]]
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            List<GoodsUnitData> goodsUnitDataList;
            string strMsg;
            string goodName;

            foreach (JoinPartsUWork joinPartsUWork in paraList)
            {
                // ���o����
                checkstatus = DataCheck(joinPartsUWork, joinPartsPrintWork);
                if (checkstatus == 0)
                {
                    goodName ="";
                    goodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;  // ��ƃR�[�h
                    goodsCndtn.GoodsMakerCd = joinPartsUWork.JoinDestMakerCd;         // �����惁�[�J�[�R�[�h
                    goodsCndtn.GoodsNo = joinPartsUWork.JoinDestPartsNo;              // ������i��

                    // ���i�A���f�[�^������
                    int parStatus = GoodsAccess.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out strMsg);

                    if (parStatus == 0)
                    {
                        goodName = goodsUnitDataList[0].GoodsName;
                    }

                    //�������N���X�փ����o�R�s�[
                    retList.Add(CopyToJoinPartsSetFromSecInfoSetWork(joinPartsUWork, enterpriseCode, goodName));
                }

            }

           
				
			return status;
		}

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�����}�X�^���[�N�N���X�ˌ����}�X�^�N���X�j
        /// </summary>
        /// <param name="secInfoSetWork">�����}�X�^���[�N�N���X</param>
        /// <returns>�����}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �����}�X�^���[�N�N���X���猋���}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private JoinPartsSet CopyToJoinPartsSetFromSecInfoSetWork(JoinPartsUWork joinPartsUWork, string enterpriseCode, string goodName)
        {

            JoinPartsSet joinPartsSet = new JoinPartsSet();

            joinPartsSet.JoinSourceMakerCode = joinPartsUWork.JoinSourceMakerCode;
            joinPartsSet.JoinSourceMakerName = GetMakerName(joinPartsUWork.JoinSourceMakerCode, enterpriseCode);
            joinPartsSet.JoinSourPartsNoWithH = joinPartsUWork.JoinSourPartsNoWithH;
            joinPartsSet.GoodsNameKana = goodName;
            joinPartsSet.JoinDispOrder = joinPartsUWork.JoinDispOrder;
            joinPartsSet.JoinDestPartsNo = joinPartsUWork.JoinDestPartsNo;
            joinPartsSet.JoinDestMakerCd = joinPartsUWork.JoinDestMakerCd;
            joinPartsSet.JoinDestMakerName = GetMakerName(joinPartsUWork.JoinDestMakerCd, enterpriseCode);
            joinPartsSet.JoinQty = joinPartsUWork.JoinQty;

            return joinPartsSet;
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
        private int DataCheck(JoinPartsUWork joinPartsUWork, JoinPartsPrintWork joinPartsPrintWork)
        {
            int status = 0;

            if (joinPartsUWork.LogicalDeleteCode != joinPartsPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = joinPartsUWork.UpdateDateTime.Year.ToString("0000") +
                                joinPartsUWork.UpdateDateTime.Month.ToString("00") +
                                joinPartsUWork.UpdateDateTime.Day.ToString("00");

            if (joinPartsPrintWork.LogicalDeleteCode == 1 &&
                joinPartsPrintWork.DeleteDateTimeSt != 0 &&
                joinPartsPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < joinPartsPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > joinPartsPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (joinPartsPrintWork.LogicalDeleteCode == 1 &&
                        joinPartsPrintWork.DeleteDateTimeSt != 0 &&
                        joinPartsPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < joinPartsPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (joinPartsPrintWork.LogicalDeleteCode == 1 &&
                joinPartsPrintWork.DeleteDateTimeSt == 0 &&
                joinPartsPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > joinPartsPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (joinPartsPrintWork.JoinSourceMakerCodeSt != 0 &&
                joinPartsPrintWork.JoinSourceMakerCodeEd != 0)
            {
                if (joinPartsUWork.JoinSourceMakerCode < joinPartsPrintWork.JoinSourceMakerCodeSt ||
                   joinPartsUWork.JoinSourceMakerCode > joinPartsPrintWork.JoinSourceMakerCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (joinPartsPrintWork.JoinSourceMakerCodeSt != 0)
            {
                if (joinPartsUWork.JoinSourceMakerCode < joinPartsPrintWork.JoinSourceMakerCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (joinPartsPrintWork.JoinSourceMakerCodeEd != 0)
            {
                if (joinPartsUWork.JoinSourceMakerCode > joinPartsPrintWork.JoinSourceMakerCodeEd)
                {
                    status = -1;
                    return status;
                }
            }

            if (!joinPartsPrintWork.JoinSourPartsNoWithHSt.Trim().Equals(string.Empty) &&
                !joinPartsPrintWork.JoinSourPartsNoWithHEd.Trim().Equals(string.Empty))
            {
                if (joinPartsPrintWork.JoinSourPartsNoWithHSt.CompareTo(joinPartsUWork.JoinSourPartsNoWithH) > 0 ||
                    joinPartsPrintWork.JoinSourPartsNoWithHEd.CompareTo(joinPartsUWork.JoinSourPartsNoWithH) < 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!joinPartsPrintWork.JoinSourPartsNoWithHSt.Trim().Equals(string.Empty))
            {
                if (joinPartsPrintWork.JoinSourPartsNoWithHSt.CompareTo(joinPartsUWork.JoinSourPartsNoWithH) > 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!joinPartsPrintWork.JoinSourPartsNoWithHEd.Trim().Equals(string.Empty))
            {
                if (joinPartsPrintWork.JoinSourPartsNoWithHEd.CompareTo(joinPartsUWork.JoinSourPartsNoWithH) < 0)
                {
                    status = -1;
                    return status;
                }
            }
            return status;
        }
    }


    #region <���i�A���f�[�^�A�N�Z�X�̃v���L�V/>

    /// <summary>
    /// ���i�A���f�[�^�A�N�Z�X�N���X�̃v���L�V�N���X
    /// </summary>
    public sealed class GoodsAcsProxy : GoodsAcs
    {
        #region <�{���̏��i�A���f�[�^�A�N�Z�X/>

        /// <summary>�{���̏��i�A���f�[�^�A�N�Z�X</summary>
        private GoodsAcs _realGoodsAcs;
        /// <summary>
        /// �{���̏��i�A���f�[�^�A�N�Z�X���擾���܂��B
        /// </summary>
        /// <value>�{���̏��i�A���f�[�^�A�N�Z�X</value>
        public GoodsAcs RealGoodsAcs
        {
            get
            {
                if (_realGoodsAcs == null)
                {
                    _realGoodsAcs = new GoodsAcs();
                }
                return _realGoodsAcs;
            }
        }

        #endregion  // <�{���̏��i�A���f�[�^�A�N�Z�X/>

        #region <���i�A���f�[�^�̃L���b�V��/>

        /// <summary>���i�A���f�[�^�n�b�V���e�[�u��</summary>
        private readonly Hashtable _goodsUnitDataHashTable = new Hashtable();
        /// <summary>
        /// ���i�A���f�[�^�n�b�V���e�[�u�����擾���܂��B
        /// </summary>
        /// <remarks>
        /// key�F<c>JoinPartsUAcs.F_DATA_GOODSUNIT</c>
        /// val�F<c>GoodsUnitData</c>
        /// </remarks>
        /// <value>���i�A���f�[�^�n�b�V���e�[�u��</value>
        public Hashtable GoodsUnitDataHashTable
        {
            get { return _goodsUnitDataHashTable; }
        }

        #endregion  // <���i�A���f�[�^�̃L���b�V��/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public GoodsAcsProxy() : base() { }

        #endregion  // <Constructor/>

        /// <summary>
        /// �������������ŕi�Ԃ��������܂��B
        /// </summary>
        /// <remarks>
        /// ���i�A���f�[�^Hashtable�o�^�����������ɍs���܂��B
        /// </remarks>
        /// <param name="goodsCondition">��������</param>
        /// <param name="goodsUnitDataList">�������ꂽ���i�A���f�[�^���X�g</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>���ʃR�[�h</returns>
        new public int SearchPartsFromGoodsNoNonVariousSearch(
            GoodsCndtn goodsCondition,
            out List<GoodsUnitData> goodsUnitDataList,
            out string msg
        )
        {
            int status = RealGoodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCondition, out goodsUnitDataList, out msg);

            // ���i���L���b�V��
            if (goodsUnitDataList != null && goodsUnitDataList.Count > 0)
            {
                foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                {
                    SetGoodsUnitData(goodsUnitData);
                }
            }

            return status;
        }

        /// <summary>
        /// ���i�A���f�[�^Hashtable�o�^����
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <see cref="JoinPartsUAcs"/>
        private void SetGoodsUnitData(GoodsUnitData goodsUnitData)
        {
            JoinPartsSetAcs.F_DATA_GOODSUNIT dataGoodsUnit = new JoinPartsSetAcs.F_DATA_GOODSUNIT();

            dataGoodsUnit.joinDestMakerCd = goodsUnitData.GoodsMakerCd;  // �����惁�[�J�[�R�[�h
            dataGoodsUnit.joinDestPartsNo = goodsUnitData.GoodsNo;       // ������i��

            if (GoodsUnitDataHashTable.ContainsKey(dataGoodsUnit))
            {
                GoodsUnitDataHashTable.Remove(dataGoodsUnit);    // MEMO:�폜���闝�R�́Hon����ōX�V�������邽�߁H
            }

            // ���i�A���f�[�^�o�^
            GoodsUnitDataHashTable.Add(dataGoodsUnit, goodsUnitData);
        }

        /// <summary>�l���I������Ȃ������Ƃ��̌��ʃR�[�h</summary>
        public const int DB_RESULT_OF_NOT_SELECTED_VALUE = -1;

        /// <summary>
        /// �����}�X�^�ɂ�����i�Ԃ̎�ʂ̗񋓑�
        /// </summary>
        public enum JoinedGoodsNoType : int
        {
            /// <summary>�e�i�������j</summary>
            Parent,
            /// <summary>�q�i������j</summary>
            Child
        }

        /// <summary>
        /// �i�Ԍ����i���������L�芮�S��v�j�����s���A�����E�Z�b�g�E��֏����擾���܂��B
        /// </summary>
        /// <remarks>
        /// �i�Ԍ����i�������������j�����s���A�i�ԁE���[�J�[���m�肵����ɁA���������L�芮�S��v�̌������s���܂��B
        /// </remarks>
        /// <param name="goodsCondition">��������</param>
        /// <param name="partsInfoDataSet">�������ꂽ���i���̃f�[�^�Z�b�g</param>
        /// <param name="goodsUnitDataList">�������ꂽ���i�A���f�[�^�̃��X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="joinedGoodsNoType">�����}�X�^�ɂ�����i�Ԃ̎��</param>
        /// <returns>���ʃR�[�h</returns>
        public int SearchPartsFromGoodsNoWholeWordBeforeSearchingPartsFromGoodsNoNonVariousSearch(
            GoodsCndtn goodsCondition,
            out PartsInfoDataSet partsInfoDataSet,
            out List<GoodsUnitData> goodsUnitDataList,
            out string message,
            JoinedGoodsNoType joinedGoodsNoType
        )
        {
            partsInfoDataSet = new PartsInfoDataSet();

            // �i�Ԍ����i�������������j�����s���A�i�ԁE���[�J�[���m�肷��B
            int status = this.SearchPartsFromGoodsNoNonVariousSearch(goodsCondition, out goodsUnitDataList, out message);
            if (!status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL)) return status;

            if (joinedGoodsNoType.Equals(JoinedGoodsNoType.Child) && goodsUnitDataList != null && goodsUnitDataList.Count > 0)
            {
                return status;  // �q�i������j�̏ꍇ�A�����ŏ����͏I��
            }

            // �i�Ԍ����i���������L�芮�S��v�j�����s���A�����E�Z�b�g�E��֏����擾����B
            GoodsCndtn goodsConditionOfWholeWord = goodsCondition.Clone();
            if (goodsUnitDataList != null && goodsUnitDataList.Count > 0)
            {
                goodsConditionOfWholeWord.GoodsNo = goodsUnitDataList[0].GoodsNo;
            }

            return RealGoodsAcs.SearchPartsFromGoodsNoWholeWord(
                goodsConditionOfWholeWord,
                out partsInfoDataSet,
                out goodsUnitDataList,
                out message
            );
        }
    }

    #endregion  // <���i�A���f�[�^�A�N�Z�X�̃v���L�V/>
}
