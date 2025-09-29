//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/05/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���n ���
// �� �� ��  2010/03/05  �C�����e : ���[�UDB�f�[�^(�󒍃f�[�^�A�ԗ����A���׏��)�擾���ɁA�����_�R�[�h�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/03/30  �C�����e : ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LDNS�̗���
// �� �� ��  2011/08/10  �C�����e : �����񓚑Ή��ASCM�Z�b�g�}�X�^���M�ł��邽��
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�J�X�^���R���X�g���N�^��ǉ�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/10/17  �C�����e : SCM��Q�Ή� SCM�A�g�����M�f�[�^�擾�������C�� ��10414
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 31065 �L�� ���O
// �� �� ��  2014/11/26  �C�����e : SCM�d�|�ꗗ��10707�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller.Agent
{
#if DEBUG
    using WebHeaderRecordType   = Broadleaf.Application.UIData.ScmOdrData;
    using WebCarRecordType      = Broadleaf.Application.UIData.ScmOdDtCar;
    using WebDetailRecordType   = Broadleaf.Application.UIData.ScmOdDtInq;
    using WebAnswerRecordType   = Broadleaf.Application.UIData.ScmOdDtAns;
    // -- ADD 2011/08/10   ------ >>>>>>
    using WebSetDtRecordType    = Broadleaf.Application.UIData.ScmOdSetDt;
    // -- ADD 2011/08/10   ------ <<<<<<
#else
    using WebHeaderRecordType   = Broadleaf.Application.UIData.ScmOdrData;
    using WebCarRecordType      = Broadleaf.Application.UIData.ScmOdDtCar;
    using WebDetailRecordType   = Broadleaf.Application.UIData.ScmOdDtInq;
    using WebAnswerRecordType   = Broadleaf.Application.UIData.ScmOdDtAns;
    // -- ADD 2011/08/10   ------ >>>>>>
    using WebSetDtRecordType    = Broadleaf.Application.UIData.ScmOdSetDt;
    // -- ADD 2011/08/10   ------ <<<<<<
#endif

    /// <summary>
    /// SCM��I/O�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public abstract class SCMIOAgent
    {
        /// <summary>���O�p�̖���</summary>
        private const string MY_NAME = "SCMIOAgent";

        #region <SCM�󒍃f�[�^>

        /// <summary>���M����SCM�󒍃f�[�^�̃��R�[�h���X�g</summary>
        private IList<ISCMOrderHeaderRecord> _foundSendingHeaderList;
        /// <summary>���M����SCM�󒍃f�[�^�̃��R�[�h���X�g���擾���܂��B</summary>
        public IList<ISCMOrderHeaderRecord> FoundSendingHeaderList
        {
            get
            {
                const string METHOD = "FoundSendingHeaderList_get";
                const string INDENT = "\t    ";

                if (_foundSendingHeaderList == null)
                {
                    _foundSendingHeaderList = FindSendingHeaderData();

                    Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "�w�b�_�Ɩ��ׂ��֘A�t����f�[�^���\�z���c");

                    RelationalHeaderMap.Clear();
                    for (int i = 0; i < _foundSendingHeaderList.Count; i++)
                    {
                        AddToRelationalHeaderMap((long)i, _foundSendingHeaderList[i]);
                    }

                    Util.SimpleLogger.WriteDebugLog(MY_NAME, METHOD, INDENT + "�w�b�_�Ɩ��ׂ��֘A�t����f�[�^���\�z����");
                }
                return _foundSendingHeaderList;
            }
            set
            {
                _foundSendingHeaderList = value;
            }
        }

        /// <summary>SCM�󒍃f�[�^�̊֘A�}�b�v</summary>
        private readonly IDictionary<string, KeyValuePair<long, ISCMOrderHeaderRecord>> _relationalHeaderMap = new Dictionary<string, KeyValuePair<long, ISCMOrderHeaderRecord>>();
        /// <summary>SCM�󒍃}�b�v�̊֘A�}�b�v���擾���܂��B</summary>
        protected IDictionary<string, KeyValuePair<long, ISCMOrderHeaderRecord>> RelationalHeaderMap { get { return _relationalHeaderMap; } }
        /// <summary>
        /// SCM�󒍃f�[�^�̊֘A�}�b�v�ɒǉ����܂��B
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="headerRecord">SCM�󒍃f�[�^�̃��R�[�h</param>
        private void AddToRelationalHeaderMap(
            long id,
            ISCMOrderHeaderRecord headerRecord
        )
        {
            string key = headerRecord.ToRelationKey() + headerRecord.SalesSlipNum.PadLeft(9, '0') + headerRecord.AcptAnOdrStatus.ToString("d2");
            if (RelationalHeaderMap.ContainsKey(key))
            {
                RelationalHeaderMap.Remove(key);
            }
            RelationalHeaderMap.Add(key, new KeyValuePair<long, ISCMOrderHeaderRecord>(id, headerRecord));
        }

        #endregion // </SCM�󒍃f�[�^>

        #region <SCM�󒍖��׃f�[�^(��)>

        /// <summary>���M����SCM�󒍖��׃f�[�^(��)�̃��R�[�h���X�g</summary>
        private IList<ISCMOrderAnswerRecord> _foundSendingAnswerList;
        /// <summary>���M����SCM�󒍖��׃f�[�^(��)�̃��R�[�h���X�g���擾���܂��B</summary>
        public IList<ISCMOrderAnswerRecord> FoundSendingAnswerList
        {
            get
            {
                if (_foundSendingAnswerList == null)
                {
                    _foundSendingAnswerList = FindSendingAnswerData();

                    //// �⍇���ԍ��������Ȃ����̂𕪕�
                    //AnswerMapWithoutInquiryNumber.Clear();
                    //foreach (ISCMOrderAnswerRecord detailRecord in _foundSendingAnswerList)
                    //{
                    //    if (detailRecord.InquiryNumber.Equals(0))
                    //    {
                    //        AddAnswerMapWithoutInquiryNumber(detailRecord);
                    //    }
                    //}
                }
                return _foundSendingAnswerList;
            }
            set
            {
                _foundSendingAnswerList = value;
            }
        }

        #endregion // </SCM�󒍖��׃f�[�^(��)>

        #region <SCM�󒍃f�[�^(�ԗ����)>

        /// <summary>���M����SCM�󒍃f�[�^(�ԗ����)�̃��R�[�h���X�g</summary>
        private IList<ISCMOrderCarRecord> _foundSendingCarList;
        /// <summary>���M����SCM�󒍃f�[�^(�ԗ����)�̃��R�[�h���X�g���擾���܂��B</summary>
        public IList<ISCMOrderCarRecord> FoundSendingCarList
        {
            get
            {
                if (_foundSendingCarList == null)
                {
                    _foundSendingCarList = FindSendingCarData();
                }
                return _foundSendingCarList;
            }
            set
            {
                _foundSendingCarList = value;
            }
        }

        #endregion // </SCM�󒍃f�[�^(�ԗ����)>

        #region <SCM�󒍖��׃f�[�^(�⍇���E����)>

        ///// <summary>���M����SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h���X�g</summary>
        //private IList<ISCMOrderDetailRecord> _foundSendingDetailList;
        ///// <summary>���M����SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h���X�g���擾���܂��B</summary>
        //public IList<ISCMOrderDetailRecord> FoundSendingDetailList
        //{
        //    get
        //    {
        //        if (_foundSendingDetailList == null)
        //        {
        //            _foundSendingDetailList = FindSendingDetailData();
        //        }
        //        return _foundSendingDetailList;
        //    }
        //    set
        //    {
        //        _foundSendingDetailList = value;
        //    }
        //}

        #endregion // </SCM�󒍖��׃f�[�^(�⍇���E����)>
        // -- ADD 2011/08/08   ------ >>>>>>
        #region <�Z�b�g���̃��R�[�h���X�g>

        // -- ADD 2011/08/10   ------ >>>>>>
        #region <SCM�Z�b�g�}�X�^>
        /// <summary>
        /// SCM�Z�b�g�}�X�^�̃��R�[�h���X�g
        /// </summary>
        private IList<ISCMAcOdSetDtRecord> _foundSendingSetDtList;

        /// <summary>
        /// ���M����SCM�Z�b�g�}�X�^�̃��R�[�h���X�g���擾���܂��B
        /// </summary>
        public IList<ISCMAcOdSetDtRecord> FoundSendingSetDtList
        {
            get
            {
                if (_foundSendingSetDtList == null)
                {
                    _foundSendingSetDtList = FindSendingSetDtData();
                }

                return _foundSendingSetDtList;
            }

            set
            {
                _foundSendingSetDtList = value;
            }
        }

        #endregion      // <SCM�Z�b�g�}�X�^>
        // -- ADD 2011/08/10   ------ <<<<<<

        #region <SCM�f�[�^����>
        /// <summary>
        /// ���M����SCM�󒍃f�[�^���������܂��B
        /// </summary>
        /// <returns>���M����SCM�󒍃f�[�^</returns>
        protected abstract IList<ISCMOrderHeaderRecord> FindSendingHeaderData();

        /// <summary>
        /// ���M����SCM�󒍖��׃f�[�^(��)���������܂��B
        /// </summary>
        /// <returns>���M����SCM�󒍖��׃f�[�^(��)</returns>
        protected abstract IList<ISCMOrderAnswerRecord> FindSendingAnswerData();

        /// <summary>
        /// ���M����SCM�󒍃f�[�^(�ԗ����)���������܂��B
        /// </summary>
        /// <returns>���M����SCM�󒍃f�[�^(�ԗ����)</returns>
        protected abstract IList<ISCMOrderCarRecord> FindSendingCarData();

        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>
        /// ���M����SCM�Z�b�g�}�X�^���������܂��B
        /// </summary>
        /// <returns>���M����SCM�Z�b�g�}�X�^</returns>
        protected abstract IList<ISCMAcOdSetDtRecord> FindSendingSetDtData();
        // -- ADD 2011/08/10   ------ <<<<<<

        #endregion

        #region <SCM User-DB�̌��J>
        /// <summary>
        /// SCM�󒍃f�[�^�̃��R�[�h���X�g�𐶐����܂��B
        /// </summary>
        /// <returns></returns>
        public List<SCMAcOdrDataWork> CreateUserHeaderRecordList()
        {
            List<SCMAcOdrDataWork> userHeaderList = new List<SCMAcOdrDataWork>();

            foreach (UserSCMOrderHeaderRecord enmHeaderRecord in FoundSendingHeaderList)
            {
                userHeaderList.Add(enmHeaderRecord.RealRecord);
            }

            return userHeaderList;
        }

        /// <summary>
        /// SCM�󒍃f�[�^(�ԗ����)�̃��R�[�h���X�g�𐶐����܂��B
        /// </summary>
        /// <returns></returns>
        public List<SCMAcOdrDtCarWork> CreateUserCarRecordList()
        {
            List<SCMAcOdrDtCarWork> userCarList = new List<SCMAcOdrDtCarWork>();

            foreach (UserSCMOrderCarRecord enmCarRecord in FoundSendingCarList)
            {
                userCarList.Add(enmCarRecord.RealRecord);
            }

            return userCarList;
        }

        /// <summary>
        /// SCM�󒍖��׃f�[�^(��)�̃��R�[�h���X�g�𐶐����܂��B
        /// </summary>
        /// <returns></returns>
        public List<SCMAcOdrDtlAsWork> CreateUserAnswerRecordList()
        {
            List<SCMAcOdrDtlAsWork> userAnswerList = new List<SCMAcOdrDtlAsWork>();

            foreach (UserSCMOrderAnswerRecord enmAnswerRecord in FoundSendingAnswerList)
            {
                userAnswerList.Add(enmAnswerRecord.RealRecord);
            }

            return userAnswerList;
        }

        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>
        /// SCM�Z�b�g�}�X�^�̃��R�[�h���X�g�𐶐����܂��B
        /// </summary>
        /// <returns></returns>
        public List<SCMAcOdSetDtWork> CreateUserSetDtRecordList()
        {
            List<SCMAcOdSetDtWork> userSetDtList = new List<SCMAcOdSetDtWork>();

            foreach(UserSCMAcOdSetDtRecord enmSetDtRecord in FoundSendingSetDtList)
            {
                userSetDtList.Add(enmSetDtRecord.RealRecord);
            }

            return userSetDtList;
        }
        // -- ADD 2011/08/10   ------ <<<<<<

        #endregion

        #region <SCM Web-DB �ւ̕ϊ�>

        /// <summary>
        /// SCM�󔭒��f�[�^�̃��R�[�h���X�g�𐶐����܂��B
        /// </summary>
        /// <returns>SCM�󔭒��f�[�^�̃��R�[�h���X�g</returns>
        public List<WebHeaderRecordType> CreateWebHeaderRecordList()
        {
            List<WebHeaderRecordType> headerList = new List<WebHeaderRecordType>();
            {
                foreach (ISCMOrderHeaderRecord enmHeaderRecord in FoundSendingHeaderList)
                {
                    UserSCMOrderHeaderRecord userHeader = enmHeaderRecord as UserSCMOrderHeaderRecord;
                    if (userHeader == null) continue;

                    headerList.Add(userHeader.CopyToWebSCMOrderHeaderRecord().RealRecord);
                }
            }
            return headerList;
        }

        /// <summary>
        /// SCM�󔭒��f�[�^(�ԗ����)�̃��R�[�h�𐶐����܂��B
        /// </summary>
        /// <returns>SCM�󔭒��f�[�^(�ԗ����)�̃��R�[�h</returns>
        public List<WebCarRecordType> CreateWebCarRecordList()
        {
            List<WebCarRecordType> carList = new List<WebCarRecordType>();
            {
                foreach (ISCMOrderCarRecord enmCarRecord in FoundSendingCarList)
                {
                    UserSCMOrderCarRecord userCar = enmCarRecord as UserSCMOrderCarRecord;
                    if (userCar == null) continue;

                    carList.Add(userCar.CopyToWebSCMOrderCarRecord().RealRecord);
                }
            }
            return carList;
        }

        /// <summary>
        /// SCM�󔭒����׃f�[�^(��)�̃��R�[�h���X�g�𐶐����܂��B
        /// </summary>
        /// <returns>SCM�󔭒����׃f�[�^(��)�̃��R�[�h���X�g</returns>
        public List<WebAnswerRecordType> CreateWebAnswerRecordList()
        {
            List<WebAnswerRecordType> answerList = new List<WebAnswerRecordType>();
            {
                foreach (ISCMOrderAnswerRecord enmAnswerRecord in FoundSendingAnswerList)
                {
                    UserSCMOrderAnswerRecord userAnswer = enmAnswerRecord as UserSCMOrderAnswerRecord;
                    if (userAnswer == null) continue;

                    answerList.Add(userAnswer.CopyToWebSCMOrderAnswerRecord().RealRecord);
                }
            }
            return answerList;
        }

        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>
        /// SCM�Z�b�g�}�X�^�̃��R�[�h���X�g�𐶐����܂��B
        /// </summary>
        /// <returns></returns>
        public List<WebSetDtRecordType> CreateWebSetDtRecordList()
        {
            List<WebSetDtRecordType> setDtList = new List<WebSetDtRecordType>();

            foreach (ISCMAcOdSetDtRecord enmSetDtRecord in FoundSendingSetDtList)
            {
                UserSCMAcOdSetDtRecord userSetDtRecord = enmSetDtRecord as UserSCMAcOdSetDtRecord;

                if (userSetDtRecord == null)
                {
                    continue;
                }

                setDtList.Add(userSetDtRecord.CopyToWebSCMAcOdSetDtRecord().RealRecord);
            }

            return setDtList;
        }
        // -- ADD 2011/08/10   ------ <<<<<<

        #endregion // </SCM Web-DB �ւ̕ϊ�>

        #region <���M������ʗp�f�[�^�Z�b�g>
        /// <summary>
        /// ���M������ʗp�f�[�^�Z�b�g�𐶐����܂��B
        /// </summary>
        /// <returns>���M������ʗp�f�[�^�Z�b�g</returns>
        public abstract SCMSendViewDataSet CreateSCMSendViewDataSet();

        /// <summary>
        /// �`�[���(�󒍃X�e�[�^�X)�񋓌^
        /// </summary>
        private enum SlipType : int
        {
            /// <summary>����</summary>
            Estimate = 10,
            /// <summary>��</summary>
            Order = 20,
            /// <summary>����</summary>
            Sales = 30
        }

        /// <summary>
        /// �`�[��ʖ����擾���܂��B
        /// </summary>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <returns>10:����/20:��/30:����</returns>
        protected static string GetSlipTypeName(int acptAnOdrStatus)
        {
            switch (acptAnOdrStatus)
            {
                case (int)SlipType.Estimate:
                    return "����";  // LITERAL:
                case (int)SlipType.Order:
                    return "��";  // LITERAL:
                case (int)SlipType.Sales:
                    return "����";  // LITERAL:
                default:
                    return "����";// LITERAL:
            }
        }

        /// <summary>
        /// ������t���擾���܂��B
        /// </summary>
        /// <param name="headerRecord">SCM�󒍃f�[�^�̃��R�[�h</param>
        /// <returns>
        /// �󒍃X�e�[�^�X�����ρF�⍇����<br/>
        /// �󒍃X�e�[�^�X������F������
        /// </returns>
        protected static DateTime GetSalesDate(ISCMOrderHeaderRecord headerRecord)
        {
            return headerRecord.AcptAnOdrStatus.Equals((int)SlipType.Sales)
                ? headerRecord.InquiryDate
                : headerRecord.InquiryDate;
        }

        #endregion // </���M������ʗp�f�[�^�Z�b�g>

        #region <�X�V�������s>
        /// <summary>
        /// �X�V�������s(Insert�ł͂Ȃ�)
        /// </summary>
        /// <returns></returns>
        public abstract int UpdateData(object wirtePara);
        #endregion

        #region <�ێ������؂�XML�t�@�C���폜����>
        /// <summary>
        /// �����؂�XML�t�@�C���폜����
        /// </summary>
        /// <param name="limit"></param>
        public virtual void DeletePassedPeriodXMLFiles(DateTime limit) { }
        #endregion

        #region <Constructor>

        // DEL 2010/03/30 ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ� ---------->>>>>
        ///// <summary>
        ///// �f�t�H���g�R���X�g���N�^
        ///// </summary>
        //protected SCMIOAgent() { }
        // DEL 2010/03/30 ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ� ----------<<<<<
        // ADD 2010/03/30 ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ� ---------->>>>>
        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="withoutCustomerInfo">���Ӑ����K�v�Ƃ��Ȃ��t���O</param>
        protected SCMIOAgent(bool withoutCustomerInfo)
        {
            _withoutCustomerInfo = withoutCustomerInfo;
        }
        // ADD 2010/03/30 ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ� ----------<<<<<

        #endregion // </Constructor>

        //>>>2010/03/05
        private string _enterpriseCd;

        /// <summary>
        /// ����ƃR�[�h
        /// </summary>
        public string EnterpriseCd
        {
            get
            {
                if (_enterpriseCd == null || _enterpriseCd == string.Empty)
                {
                    _enterpriseCd = LoginInfoAcquisition.EnterpriseCode;
                }

                return _enterpriseCd;
            }
        }
        
        private string _belongSectionCode;
        /// <summary>
        /// �����_�R�[�h
        /// </summary>
        public string BelongSectionCode
        {
            get
            {
                if (LoginInfoAcquisition.Employee != null)
                {
                    if ((_belongSectionCode == null) || (_belongSectionCode == string.Empty))
                    {
                        _belongSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
                    }
                }

                return _belongSectionCode;
            }
        }
        //<<<2010/03/05


        //>>>2010/04/08
        //// 2010/03/15 Add >>>
        //private int _acptAnOdrStatus;
        //private string _salesSlipNum;

        //public int AcptAnOdrStatus
        //{
        //    get { return _acptAnOdrStatus; }
        //    set { _acptAnOdrStatus = value; }
        //}


        //public string SalesSlipNum
        //{
        //    get { return _salesSlipNum; }
        //    set { _salesSlipNum = value; }
        //}
        //// 2010/03/15 Add <<<

        private Int64 _inquiryNumber;
        private int _inqOrdDivCd;
        // ADD 2012/10/17 ���� SCM��Q�Ή� ��10414------------------------>>>>>
        private List<string> _salesSlipNumList = null;
        // ADD 2012/10/17 ���� SCM��Q�Ή� ��10414------------------------<<<<<

        public Int64 InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }

        public int InqOrdDivCd
        {
            get { return _inqOrdDivCd; }
            set { _inqOrdDivCd = value; }
        }
        //<<<2010/04/08

        // ADD 2012/10/17 ���� SCM��Q�Ή� ��10414------------------------>>>>>
        public List<string> SalesSlipNumList
        {
            get { return _salesSlipNumList; }
            set { _salesSlipNumList = value; }
        }
        // ADD 2012/10/17 ���� SCM��Q�Ή� ��10414------------------------<<<<<

        // ADD 2010/03/30 ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ� ---------->>>>>
        #region ���Ӑ����K�v�Ƃ��Ȃ��t���O

        /// <summary>���Ӑ����K�v�Ƃ��Ȃ��t���O</summary>
        private readonly bool _withoutCustomerInfo;
        /// <summary>���Ӑ����K�v�Ƃ��Ȃ��t���O���擾���܂��B</summary>
        protected bool WithoutCustomerInfo { get { return _withoutCustomerInfo; } }

        #endregion // ���Ӑ����K�v�Ƃ��Ȃ��t���O
        // ADD 2010/03/30 ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ� ----------<<<<<

        // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� --->>>>>>
        #region <�ݒ���>
        // �ݒ���
        private SCMSendSettingInformation _settingInfo = null;

        /// <summary>�ݒ�����擾�܂��͐ݒ肵�܂��B</summary>
        public SCMSendSettingInformation SettingInformation
        {
            get { return _settingInfo; }
            set { _settingInfo = value; }
        }
        #endregion
        // ADD 2014/11/26 k.toyosawa SCM�d�|�ꗗ��10707�Ή� ---<<<<<<
    }
}
#endregion 