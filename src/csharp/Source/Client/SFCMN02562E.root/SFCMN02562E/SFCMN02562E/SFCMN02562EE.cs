using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   OScmBPSCnt
    /// <summary>
    ///                      �񋟑�SCM���Əꋒ�_�A���}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �񋟑�SCM���Əꋒ�_�A���}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2014/7/9</br>
    /// <br>Genarated Date   :   2014/09/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class OScmBPSCnt
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

        /// <summary>�A�����ƃR�[�h</summary>
        private string _cnectOtherEpCd = "";

        /// <summary>�A���拒�_�R�[�h</summary>
        private string _cnectOtherSecCd = "";

        /// <summary>�_���R�[�h</summary>
        private string _contractantCode = "";

        /// <summary>FTC���Ӑ�R�[�h</summary>
        private Int32 _fTCCustomerCode;

        /// <summary>�A������ƃR�[�h</summary>
        private string _cnectOriginalEpCd = "";

        /// <summary>�A�������_�R�[�h</summary>
        private string _cnectOriginalSecCd = "";

        /// <summary>�����_���R�[�h</summary>
        private string _transContractantCd = "";

        /// <summary>����擾�Ӑ�R�[�h</summary>
        private Int32 _transCustomerCd;


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

        /// public propaty name  :  CnectOtherSecCd
        /// <summary>�A���拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A���拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CnectOtherSecCd
        {
            get { return _cnectOtherSecCd; }
            set { _cnectOtherSecCd = value; }
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

        /// public propaty name  :  CnectOriginalSecCd
        /// <summary>�A�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CnectOriginalSecCd
        {
            get { return _cnectOriginalSecCd; }
            set { _cnectOriginalSecCd = value; }
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


        /// <summary>
        /// �񋟑�SCM���Əꋒ�_�A���}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>OScmBPSCnt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OScmBPSCnt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OScmBPSCnt()
        {
        }

        /// <summary>
        /// �񋟑�SCM���Əꋒ�_�A���}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="cnectOtherEpCd">�A�����ƃR�[�h</param>
        /// <param name="cnectOtherSecCd">�A���拒�_�R�[�h</param>
        /// <param name="contractantCode">�_���R�[�h</param>
        /// <param name="fTCCustomerCode">FTC���Ӑ�R�[�h</param>
        /// <param name="cnectOriginalEpCd">�A������ƃR�[�h</param>
        /// <param name="cnectOriginalSecCd">�A�������_�R�[�h</param>
        /// <param name="transContractantCd">�����_���R�[�h</param>
        /// <param name="transCustomerCd">����擾�Ӑ�R�[�h</param>
        /// <returns>OScmBPSCnt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OScmBPSCnt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OScmBPSCnt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string cnectOtherEpCd, string cnectOtherSecCd, string contractantCode, Int32 fTCCustomerCode, string cnectOriginalEpCd, string cnectOriginalSecCd, string transContractantCd, Int32 transCustomerCd)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._cnectOtherEpCd = cnectOtherEpCd;
            this._cnectOtherSecCd = cnectOtherSecCd;
            this._contractantCode = contractantCode;
            this._fTCCustomerCode = fTCCustomerCode;
            this._cnectOriginalEpCd = cnectOriginalEpCd;
            this._cnectOriginalSecCd = cnectOriginalSecCd;
            this._transContractantCd = transContractantCd;
            this._transCustomerCd = transCustomerCd;

        }

        /// <summary>
        /// �񋟑�SCM���Əꋒ�_�A���}�X�^��������
        /// </summary>
        /// <returns>OScmBPSCnt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����OScmBPSCnt�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OScmBPSCnt Clone()
        {
            return new OScmBPSCnt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._cnectOtherEpCd, this._cnectOtherSecCd, this._contractantCode, this._fTCCustomerCode, this._cnectOriginalEpCd, this._cnectOriginalSecCd, this._transContractantCd, this._transCustomerCd);
        }

        /// <summary>
        /// �񋟑�SCM���Əꋒ�_�A���}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�OScmBPSCnt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OScmBPSCnt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(OScmBPSCnt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.CnectOtherEpCd == target.CnectOtherEpCd)
                 && (this.CnectOtherSecCd == target.CnectOtherSecCd)
                 && (this.ContractantCode == target.ContractantCode)
                 && (this.FTCCustomerCode == target.FTCCustomerCode)
                 && (this.CnectOriginalEpCd == target.CnectOriginalEpCd)
                 && (this.CnectOriginalSecCd == target.CnectOriginalSecCd)
                 && (this.TransContractantCd == target.TransContractantCd)
                 && (this.TransCustomerCd == target.TransCustomerCd));
        }

        /// <summary>
        /// �񋟑�SCM���Əꋒ�_�A���}�X�^��r����
        /// </summary>
        /// <param name="oScmBPSCnt1">
        ///                    ��r����OScmBPSCnt�N���X�̃C���X�^���X
        /// </param>
        /// <param name="oScmBPSCnt2">��r����OScmBPSCnt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OScmBPSCnt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(OScmBPSCnt oScmBPSCnt1, OScmBPSCnt oScmBPSCnt2)
        {
            return ((oScmBPSCnt1.CreateDateTime == oScmBPSCnt2.CreateDateTime)
                 && (oScmBPSCnt1.UpdateDateTime == oScmBPSCnt2.UpdateDateTime)
                 && (oScmBPSCnt1.LogicalDeleteCode == oScmBPSCnt2.LogicalDeleteCode)
                 && (oScmBPSCnt1.CnectOtherEpCd == oScmBPSCnt2.CnectOtherEpCd)
                 && (oScmBPSCnt1.CnectOtherSecCd == oScmBPSCnt2.CnectOtherSecCd)
                 && (oScmBPSCnt1.ContractantCode == oScmBPSCnt2.ContractantCode)
                 && (oScmBPSCnt1.FTCCustomerCode == oScmBPSCnt2.FTCCustomerCode)
                 && (oScmBPSCnt1.CnectOriginalEpCd == oScmBPSCnt2.CnectOriginalEpCd)
                 && (oScmBPSCnt1.CnectOriginalSecCd == oScmBPSCnt2.CnectOriginalSecCd)
                 && (oScmBPSCnt1.TransContractantCd == oScmBPSCnt2.TransContractantCd)
                 && (oScmBPSCnt1.TransCustomerCd == oScmBPSCnt2.TransCustomerCd));
        }
        /// <summary>
        /// �񋟑�SCM���Əꋒ�_�A���}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�OScmBPSCnt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OScmBPSCnt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(OScmBPSCnt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.CnectOtherEpCd != target.CnectOtherEpCd) resList.Add("CnectOtherEpCd");
            if (this.CnectOtherSecCd != target.CnectOtherSecCd) resList.Add("CnectOtherSecCd");
            if (this.ContractantCode != target.ContractantCode) resList.Add("ContractantCode");
            if (this.FTCCustomerCode != target.FTCCustomerCode) resList.Add("FTCCustomerCode");
            if (this.CnectOriginalEpCd != target.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
            if (this.CnectOriginalSecCd != target.CnectOriginalSecCd) resList.Add("CnectOriginalSecCd");
            if (this.TransContractantCd != target.TransContractantCd) resList.Add("TransContractantCd");
            if (this.TransCustomerCd != target.TransCustomerCd) resList.Add("TransCustomerCd");

            return resList;
        }

        /// <summary>
        /// �񋟑�SCM���Əꋒ�_�A���}�X�^��r����
        /// </summary>
        /// <param name="oScmBPSCnt1">��r����OScmBPSCnt�N���X�̃C���X�^���X</param>
        /// <param name="oScmBPSCnt2">��r����OScmBPSCnt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   OScmBPSCnt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(OScmBPSCnt oScmBPSCnt1, OScmBPSCnt oScmBPSCnt2)
        {
            ArrayList resList = new ArrayList();
            if (oScmBPSCnt1.CreateDateTime != oScmBPSCnt2.CreateDateTime) resList.Add("CreateDateTime");
            if (oScmBPSCnt1.UpdateDateTime != oScmBPSCnt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (oScmBPSCnt1.LogicalDeleteCode != oScmBPSCnt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (oScmBPSCnt1.CnectOtherEpCd != oScmBPSCnt2.CnectOtherEpCd) resList.Add("CnectOtherEpCd");
            if (oScmBPSCnt1.CnectOtherSecCd != oScmBPSCnt2.CnectOtherSecCd) resList.Add("CnectOtherSecCd");
            if (oScmBPSCnt1.ContractantCode != oScmBPSCnt2.ContractantCode) resList.Add("ContractantCode");
            if (oScmBPSCnt1.FTCCustomerCode != oScmBPSCnt2.FTCCustomerCode) resList.Add("FTCCustomerCode");
            if (oScmBPSCnt1.CnectOriginalEpCd != oScmBPSCnt2.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
            if (oScmBPSCnt1.CnectOriginalSecCd != oScmBPSCnt2.CnectOriginalSecCd) resList.Add("CnectOriginalSecCd");
            if (oScmBPSCnt1.TransContractantCd != oScmBPSCnt2.TransContractantCd) resList.Add("TransContractantCd");
            if (oScmBPSCnt1.TransCustomerCd != oScmBPSCnt2.TransCustomerCd) resList.Add("TransCustomerCd");

            return resList;
        }
    }
}
