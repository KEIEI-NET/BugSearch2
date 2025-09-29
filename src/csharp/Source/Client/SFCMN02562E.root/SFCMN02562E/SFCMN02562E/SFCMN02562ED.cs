using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   OScmBPCnt
    /// <summary>
    ///                      �񋟑�SCM���Ə�A���}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �񋟑�SCM���Ə�A���}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2014/7/9</br>
    /// <br>Genarated Date   :   2014/09/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class OScmBPCnt
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�_���R�[�h</summary>
        private string _contractantCode = "";

        /// <summary>FTC���Ӑ�R�[�h</summary>
        private Int32 _fTCCustomerCode;

        /// <summary>BL���[�U�R�[�h1</summary>
        private string _bLUserCode1 = "";

        /// <summary>BL���[�U�R�[�h2</summary>
        private string _bLUserCode2 = "";

        /// <summary>�A�����ƃR�[�h</summary>
        private string _cnectOtherEpCd = "";

        /// <summary>�_��於��</summary>
        /// <remarks>��Ɩ���</remarks>
        private string _contractantName = "";

        /// <summary>FTC���Ӑ於��</summary>
        /// <remarks>���Əꖼ��</remarks>
        private string _fTCCustomerName = "";

        /// <summary>�����_���R�[�h</summary>
        private string _transContractantCd = "";

        /// <summary>����擾�Ӑ�R�[�h</summary>
        private Int32 _transCustomerCd;

        /// <summary>�����BL���[�U�R�[�h1</summary>
        private string _transBLUserCode1 = "";

        /// <summary>�����BL���[�U�R�[�h2</summary>
        private string _transBLUserCode2 = "";

        /// <summary>�A������ƃR�[�h</summary>
        private string _cnectOriginalEpCd = "";

        /// <summary>�����_��於��</summary>
        /// <remarks>��Ɩ���</remarks>
        private string _transContractantNm = "";

        /// <summary>����擾�Ӑ於��</summary>
        /// <remarks>���Əꖼ��</remarks>
        private string _transCustomerNm = "";

        /// <summary>�A�g�f�[�^�X�V�T�[�r�X�敪</summary>
        /// <remarks>0:FTC,1:SCM</remarks>
        private Int32 _cooprtDataUpdateDiv;


        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>�X�V���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>�X�V���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>�X�V���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  ContractantCode
        /// <summary>�_���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ContractantCode
        {
            get { return _contractantCode; }
            set { _contractantCode = value; }
        }

        /// public propaty name  :  FTCCustomerCode
        /// <summary>FTC���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FTC���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FTCCustomerCode
        {
            get { return _fTCCustomerCode; }
            set { _fTCCustomerCode = value; }
        }

        /// public propaty name  :  BLUserCode1
        /// <summary>BL���[�U�R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���[�U�R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLUserCode1
        {
            get { return _bLUserCode1; }
            set { _bLUserCode1 = value; }
        }

        /// public propaty name  :  BLUserCode2
        /// <summary>BL���[�U�R�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���[�U�R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLUserCode2
        {
            get { return _bLUserCode2; }
            set { _bLUserCode2 = value; }
        }

        /// public propaty name  :  CnectOtherEpCd
        /// <summary>�A�����ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�����ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CnectOtherEpCd
        {
            get { return _cnectOtherEpCd; }
            set { _cnectOtherEpCd = value; }
        }

        /// public propaty name  :  ContractantName
        /// <summary>�_��於�̃v���p�e�B</summary>
        /// <value>��Ɩ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_��於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ContractantName
        {
            get { return _contractantName; }
            set { _contractantName = value; }
        }

        /// public propaty name  :  FTCCustomerName
        /// <summary>FTC���Ӑ於�̃v���p�e�B</summary>
        /// <value>���Əꖼ��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FTC���Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FTCCustomerName
        {
            get { return _fTCCustomerName; }
            set { _fTCCustomerName = value; }
        }

        /// public propaty name  :  TransContractantCd
        /// <summary>�����_���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����_���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TransContractantCd
        {
            get { return _transContractantCd; }
            set { _transContractantCd = value; }
        }

        /// public propaty name  :  TransCustomerCd
        /// <summary>����擾�Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����擾�Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TransCustomerCd
        {
            get { return _transCustomerCd; }
            set { _transCustomerCd = value; }
        }

        /// public propaty name  :  TransBLUserCode1
        /// <summary>�����BL���[�U�R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����BL���[�U�R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TransBLUserCode1
        {
            get { return _transBLUserCode1; }
            set { _transBLUserCode1 = value; }
        }

        /// public propaty name  :  TransBLUserCode2
        /// <summary>�����BL���[�U�R�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����BL���[�U�R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TransBLUserCode2
        {
            get { return _transBLUserCode2; }
            set { _transBLUserCode2 = value; }
        }

        /// public propaty name  :  CnectOriginalEpCd
        /// <summary>�A������ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A������ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CnectOriginalEpCd
        {
            get { return _cnectOriginalEpCd; }
            set { _cnectOriginalEpCd = value; }
        }

        /// public propaty name  :  TransContractantNm
        /// <summary>�����_��於�̃v���p�e�B</summary>
        /// <value>��Ɩ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����_��於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TransContractantNm
        {
            get { return _transContractantNm; }
            set { _transContractantNm = value; }
        }

        /// public propaty name  :  TransCustomerNm
        /// <summary>����擾�Ӑ於�̃v���p�e�B</summary>
        /// <value>���Əꖼ��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����擾�Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TransCustomerNm
        {
            get { return _transCustomerNm; }
            set { _transCustomerNm = value; }
        }

        /// public propaty name  :  CooprtDataUpdateDiv
        /// <summary>�A�g�f�[�^�X�V�T�[�r�X�敪�v���p�e�B</summary>
        /// <value>0:FTC,1:SCM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�g�f�[�^�X�V�T�[�r�X�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CooprtDataUpdateDiv
        {
            get { return _cooprtDataUpdateDiv; }
            set { _cooprtDataUpdateDiv = value; }
        }


        /// <summary>
        /// �񋟑�SCM���Ə�A���}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>OScmBPCnt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OScmBPCnt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OScmBPCnt()
        {
        }

        /// <summary>
        /// �񋟑�SCM���Ə�A���}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="contractantCode">�_���R�[�h</param>
        /// <param name="fTCCustomerCode">FTC���Ӑ�R�[�h</param>
        /// <param name="bLUserCode1">BL���[�U�R�[�h1</param>
        /// <param name="bLUserCode2">BL���[�U�R�[�h2</param>
        /// <param name="cnectOtherEpCd">�A�����ƃR�[�h</param>
        /// <param name="contractantName">�_��於��(��Ɩ���)</param>
        /// <param name="fTCCustomerName">FTC���Ӑ於��(���Əꖼ��)</param>
        /// <param name="transContractantCd">�����_���R�[�h</param>
        /// <param name="transCustomerCd">����擾�Ӑ�R�[�h</param>
        /// <param name="transBLUserCode1">�����BL���[�U�R�[�h1</param>
        /// <param name="transBLUserCode2">�����BL���[�U�R�[�h2</param>
        /// <param name="cnectOriginalEpCd">�A������ƃR�[�h</param>
        /// <param name="transContractantNm">�����_��於��(��Ɩ���)</param>
        /// <param name="transCustomerNm">����擾�Ӑ於��(���Əꖼ��)</param>
        /// <param name="cooprtDataUpdateDiv">�A�g�f�[�^�X�V�T�[�r�X�敪(0:FTC,1:SCM)</param>
        /// <returns>OScmBPCnt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OScmBPCnt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OScmBPCnt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string contractantCode, Int32 fTCCustomerCode, string bLUserCode1, string bLUserCode2, string cnectOtherEpCd, string contractantName, string fTCCustomerName, string transContractantCd, Int32 transCustomerCd, string transBLUserCode1, string transBLUserCode2, string cnectOriginalEpCd, string transContractantNm, string transCustomerNm, Int32 cooprtDataUpdateDiv)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._contractantCode = contractantCode;
            this._fTCCustomerCode = fTCCustomerCode;
            this._bLUserCode1 = bLUserCode1;
            this._bLUserCode2 = bLUserCode2;
            this._cnectOtherEpCd = cnectOtherEpCd;
            this._contractantName = contractantName;
            this._fTCCustomerName = fTCCustomerName;
            this._transContractantCd = transContractantCd;
            this._transCustomerCd = transCustomerCd;
            this._transBLUserCode1 = transBLUserCode1;
            this._transBLUserCode2 = transBLUserCode2;
            this._cnectOriginalEpCd = cnectOriginalEpCd;
            this._transContractantNm = transContractantNm;
            this._transCustomerNm = transCustomerNm;
            this._cooprtDataUpdateDiv = cooprtDataUpdateDiv;

        }

        /// <summary>
        /// �񋟑�SCM���Ə�A���}�X�^��������
        /// </summary>
        /// <returns>OScmBPCnt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����OScmBPCnt�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OScmBPCnt Clone()
        {
            return new OScmBPCnt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._contractantCode, this._fTCCustomerCode, this._bLUserCode1, this._bLUserCode2, this._cnectOtherEpCd, this._contractantName, this._fTCCustomerName, this._transContractantCd, this._transCustomerCd, this._transBLUserCode1, this._transBLUserCode2, this._cnectOriginalEpCd, this._transContractantNm, this._transCustomerNm, this._cooprtDataUpdateDiv);
        }

        /// <summary>
        /// �񋟑�SCM���Ə�A���}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�OScmBPCnt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OScmBPCnt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(OScmBPCnt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.ContractantCode == target.ContractantCode)
                 && (this.FTCCustomerCode == target.FTCCustomerCode)
                 && (this.BLUserCode1 == target.BLUserCode1)
                 && (this.BLUserCode2 == target.BLUserCode2)
                 && (this.CnectOtherEpCd == target.CnectOtherEpCd)
                 && (this.ContractantName == target.ContractantName)
                 && (this.FTCCustomerName == target.FTCCustomerName)
                 && (this.TransContractantCd == target.TransContractantCd)
                 && (this.TransCustomerCd == target.TransCustomerCd)
                 && (this.TransBLUserCode1 == target.TransBLUserCode1)
                 && (this.TransBLUserCode2 == target.TransBLUserCode2)
                 && (this.CnectOriginalEpCd == target.CnectOriginalEpCd)
                 && (this.TransContractantNm == target.TransContractantNm)
                 && (this.TransCustomerNm == target.TransCustomerNm)
                 && (this.CooprtDataUpdateDiv == target.CooprtDataUpdateDiv));
        }

        /// <summary>
        /// �񋟑�SCM���Ə�A���}�X�^��r����
        /// </summary>
        /// <param name="oScmBPCnt1">
        ///                    ��r����OScmBPCnt�N���X�̃C���X�^���X
        /// </param>
        /// <param name="oScmBPCnt2">��r����OScmBPCnt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OScmBPCnt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(OScmBPCnt oScmBPCnt1, OScmBPCnt oScmBPCnt2)
        {
            return ((oScmBPCnt1.CreateDateTime == oScmBPCnt2.CreateDateTime)
                 && (oScmBPCnt1.UpdateDateTime == oScmBPCnt2.UpdateDateTime)
                 && (oScmBPCnt1.LogicalDeleteCode == oScmBPCnt2.LogicalDeleteCode)
                 && (oScmBPCnt1.ContractantCode == oScmBPCnt2.ContractantCode)
                 && (oScmBPCnt1.FTCCustomerCode == oScmBPCnt2.FTCCustomerCode)
                 && (oScmBPCnt1.BLUserCode1 == oScmBPCnt2.BLUserCode1)
                 && (oScmBPCnt1.BLUserCode2 == oScmBPCnt2.BLUserCode2)
                 && (oScmBPCnt1.CnectOtherEpCd == oScmBPCnt2.CnectOtherEpCd)
                 && (oScmBPCnt1.ContractantName == oScmBPCnt2.ContractantName)
                 && (oScmBPCnt1.FTCCustomerName == oScmBPCnt2.FTCCustomerName)
                 && (oScmBPCnt1.TransContractantCd == oScmBPCnt2.TransContractantCd)
                 && (oScmBPCnt1.TransCustomerCd == oScmBPCnt2.TransCustomerCd)
                 && (oScmBPCnt1.TransBLUserCode1 == oScmBPCnt2.TransBLUserCode1)
                 && (oScmBPCnt1.TransBLUserCode2 == oScmBPCnt2.TransBLUserCode2)
                 && (oScmBPCnt1.CnectOriginalEpCd == oScmBPCnt2.CnectOriginalEpCd)
                 && (oScmBPCnt1.TransContractantNm == oScmBPCnt2.TransContractantNm)
                 && (oScmBPCnt1.TransCustomerNm == oScmBPCnt2.TransCustomerNm)
                 && (oScmBPCnt1.CooprtDataUpdateDiv == oScmBPCnt2.CooprtDataUpdateDiv));
        }
        /// <summary>
        /// �񋟑�SCM���Ə�A���}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�OScmBPCnt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OScmBPCnt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(OScmBPCnt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.ContractantCode != target.ContractantCode) resList.Add("ContractantCode");
            if (this.FTCCustomerCode != target.FTCCustomerCode) resList.Add("FTCCustomerCode");
            if (this.BLUserCode1 != target.BLUserCode1) resList.Add("BLUserCode1");
            if (this.BLUserCode2 != target.BLUserCode2) resList.Add("BLUserCode2");
            if (this.CnectOtherEpCd != target.CnectOtherEpCd) resList.Add("CnectOtherEpCd");
            if (this.ContractantName != target.ContractantName) resList.Add("ContractantName");
            if (this.FTCCustomerName != target.FTCCustomerName) resList.Add("FTCCustomerName");
            if (this.TransContractantCd != target.TransContractantCd) resList.Add("TransContractantCd");
            if (this.TransCustomerCd != target.TransCustomerCd) resList.Add("TransCustomerCd");
            if (this.TransBLUserCode1 != target.TransBLUserCode1) resList.Add("TransBLUserCode1");
            if (this.TransBLUserCode2 != target.TransBLUserCode2) resList.Add("TransBLUserCode2");
            if (this.CnectOriginalEpCd != target.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
            if (this.TransContractantNm != target.TransContractantNm) resList.Add("TransContractantNm");
            if (this.TransCustomerNm != target.TransCustomerNm) resList.Add("TransCustomerNm");
            if (this.CooprtDataUpdateDiv != target.CooprtDataUpdateDiv) resList.Add("CooprtDataUpdateDiv");

            return resList;
        }

        /// <summary>
        /// �񋟑�SCM���Ə�A���}�X�^��r����
        /// </summary>
        /// <param name="oScmBPCnt1">��r����OScmBPCnt�N���X�̃C���X�^���X</param>
        /// <param name="oScmBPCnt2">��r����OScmBPCnt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OScmBPCnt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(OScmBPCnt oScmBPCnt1, OScmBPCnt oScmBPCnt2)
        {
            ArrayList resList = new ArrayList();
            if (oScmBPCnt1.CreateDateTime != oScmBPCnt2.CreateDateTime) resList.Add("CreateDateTime");
            if (oScmBPCnt1.UpdateDateTime != oScmBPCnt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (oScmBPCnt1.LogicalDeleteCode != oScmBPCnt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (oScmBPCnt1.ContractantCode != oScmBPCnt2.ContractantCode) resList.Add("ContractantCode");
            if (oScmBPCnt1.FTCCustomerCode != oScmBPCnt2.FTCCustomerCode) resList.Add("FTCCustomerCode");
            if (oScmBPCnt1.BLUserCode1 != oScmBPCnt2.BLUserCode1) resList.Add("BLUserCode1");
            if (oScmBPCnt1.BLUserCode2 != oScmBPCnt2.BLUserCode2) resList.Add("BLUserCode2");
            if (oScmBPCnt1.CnectOtherEpCd != oScmBPCnt2.CnectOtherEpCd) resList.Add("CnectOtherEpCd");
            if (oScmBPCnt1.ContractantName != oScmBPCnt2.ContractantName) resList.Add("ContractantName");
            if (oScmBPCnt1.FTCCustomerName != oScmBPCnt2.FTCCustomerName) resList.Add("FTCCustomerName");
            if (oScmBPCnt1.TransContractantCd != oScmBPCnt2.TransContractantCd) resList.Add("TransContractantCd");
            if (oScmBPCnt1.TransCustomerCd != oScmBPCnt2.TransCustomerCd) resList.Add("TransCustomerCd");
            if (oScmBPCnt1.TransBLUserCode1 != oScmBPCnt2.TransBLUserCode1) resList.Add("TransBLUserCode1");
            if (oScmBPCnt1.TransBLUserCode2 != oScmBPCnt2.TransBLUserCode2) resList.Add("TransBLUserCode2");
            if (oScmBPCnt1.CnectOriginalEpCd != oScmBPCnt2.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
            if (oScmBPCnt1.TransContractantNm != oScmBPCnt2.TransContractantNm) resList.Add("TransContractantNm");
            if (oScmBPCnt1.TransCustomerNm != oScmBPCnt2.TransCustomerNm) resList.Add("TransCustomerNm");
            if (oScmBPCnt1.CooprtDataUpdateDiv != oScmBPCnt2.CooprtDataUpdateDiv) resList.Add("CooprtDataUpdateDiv");

            return resList;
        }
    }
}
