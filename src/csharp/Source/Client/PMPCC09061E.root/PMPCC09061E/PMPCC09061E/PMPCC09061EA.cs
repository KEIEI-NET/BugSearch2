using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PccCpMsgSt
    /// <summary>
    ///                      PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2011/7/21</br>
    /// <br>Genarated Date   :   2011/08/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PccCpMsgSt
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

        /// <summary>�⍇�����ƃR�[�h</summary>
        private string _inqOtherEpCd = "";

        /// <summary>�⍇���拒�_�R�[�h</summary>
        private string _inqOtherSecCd = "";

        /// <summary>�L�����y�[���R�[�h</summary>
        private Int32 _campaignCode;

        /// <summary>�K�p�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyStaDate;

        /// <summary>�K�p�I����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyEndDate;

        /// <summary>PCC���b�Z�[�W�{��</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _pccMsgDocCnts = "";

        /// <summary>�L�����y�[������</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _campaignName = "";

        /// <summary>�L�����y�[���Ώۋ敪</summary>
        /// <remarks>0:�S���Ӑ� 1:�Ώۓ��Ӑ�</remarks>
        private Int32 _campaignObjDiv;

        /// <summary>�X�V�敪</summary>
        /// <remarks>0:�V�K 1:�X�V 2:�폜</remarks>
        private Int32 _updateFlag;


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

        /// public propaty name  :  InqOtherEpCd
        /// <summary>�⍇�����ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�����ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>�⍇���拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  CampaignCode
        /// <summary>�L�����y�[���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CampaignCode
        {
            get { return _campaignCode; }
            set { _campaignCode = value; }
        }

        /// public propaty name  :  ApplyStaDate
        /// <summary>�K�p�J�n���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ApplyStaDate
        {
            get { return _applyStaDate; }
            set { _applyStaDate = value; }
        }

        /// public propaty name  :  ApplyEndDate
        /// <summary>�K�p�I�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�I�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
        }

        /// public propaty name  :  PccMsgDocCnts
        /// <summary>PCC���b�Z�[�W�{���v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC���b�Z�[�W�{���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccMsgDocCnts
        {
            get { return _pccMsgDocCnts; }
            set { _pccMsgDocCnts = value; }
        }

        /// public propaty name  :  CampaignName
        /// <summary>�L�����y�[�����̃v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CampaignName
        {
            get { return _campaignName; }
            set { _campaignName = value; }
        }

        /// public propaty name  :  CampaignObjDiv
        /// <summary>�L�����y�[���Ώۋ敪�v���p�e�B</summary>
        /// <value>0:�S���Ӑ� 1:�Ώۓ��Ӑ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���Ώۋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CampaignObjDiv
        {
            get { return _campaignObjDiv; }
            set { _campaignObjDiv = value; }
        }

        /// public propaty name  :  UpdateFlag
        /// <summary>�X�V�敪�v���p�e�B</summary>
        /// <value>0:�V�K 1:�X�V 2:�폜</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateFlag
        {
            get { return _updateFlag; }
            set { _updateFlag = value; }
        }


        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>PccCpMsgSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCpMsgSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccCpMsgSt()
        {
        }

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
        /// <param name="campaignCode">�L�����y�[���R�[�h</param>
        /// <param name="applyStaDate">�K�p�J�n��(YYYYMMDD)</param>
        /// <param name="applyEndDate">�K�p�I����(YYYYMMDD)</param>
        /// <param name="pccMsgDocCnts">PCC���b�Z�[�W�{��((���p�S�p����))</param>
        /// <param name="campaignName">�L�����y�[������((���p�S�p����))</param>
        /// <param name="campaignObjDiv">�L�����y�[���Ώۋ敪(0:�S���Ӑ� 1:�Ώۓ��Ӑ�)</param>
        /// <param name="updateFlag">�X�V�敪(0:�V�K 1:�X�V 2:�폜)</param>
        /// <returns>PccCpMsgSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCpMsgSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccCpMsgSt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOtherEpCd, string inqOtherSecCd, Int32 campaignCode, Int32 applyStaDate, Int32 applyEndDate, string pccMsgDocCnts, string campaignName, Int32 campaignObjDiv, Int32 updateFlag)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._campaignCode = campaignCode;
            this._applyStaDate = applyStaDate;
            this._applyEndDate = applyEndDate;
            this._pccMsgDocCnts = pccMsgDocCnts;
            this._campaignName = campaignName;
            this._campaignObjDiv = campaignObjDiv;
            this._updateFlag = updateFlag;

        }

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^��������
        /// </summary>
        /// <returns>PccCpMsgSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PccCpMsgSt�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccCpMsgSt Clone()
        {
            return new PccCpMsgSt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOtherEpCd, this._inqOtherSecCd, this._campaignCode, this._applyStaDate, this._applyEndDate, this._pccMsgDocCnts, this._campaignName, this._campaignObjDiv, this._updateFlag);
        }

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PccCpMsgSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCpMsgSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PccCpMsgSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.CampaignCode == target.CampaignCode)
                 && (this.ApplyStaDate == target.ApplyStaDate)
                 && (this.ApplyEndDate == target.ApplyEndDate)
                 && (this.PccMsgDocCnts == target.PccMsgDocCnts)
                 && (this.CampaignName == target.CampaignName)
                 && (this.CampaignObjDiv == target.CampaignObjDiv)
                 && (this.UpdateFlag == target.UpdateFlag));
        }

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="pccCpMsgSt1">
        ///                    ��r����PccCpMsgSt�N���X�̃C���X�^���X
        /// </param>
        /// <param name="pccCpMsgSt2">��r����PccCpMsgSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCpMsgSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(PccCpMsgSt pccCpMsgSt1, PccCpMsgSt pccCpMsgSt2)
        {
            return ((pccCpMsgSt1.CreateDateTime == pccCpMsgSt2.CreateDateTime)
                 && (pccCpMsgSt1.UpdateDateTime == pccCpMsgSt2.UpdateDateTime)
                 && (pccCpMsgSt1.LogicalDeleteCode == pccCpMsgSt2.LogicalDeleteCode)
                 && (pccCpMsgSt1.InqOtherEpCd == pccCpMsgSt2.InqOtherEpCd)
                 && (pccCpMsgSt1.InqOtherSecCd == pccCpMsgSt2.InqOtherSecCd)
                 && (pccCpMsgSt1.CampaignCode == pccCpMsgSt2.CampaignCode)
                 && (pccCpMsgSt1.ApplyStaDate == pccCpMsgSt2.ApplyStaDate)
                 && (pccCpMsgSt1.ApplyEndDate == pccCpMsgSt2.ApplyEndDate)
                 && (pccCpMsgSt1.PccMsgDocCnts == pccCpMsgSt2.PccMsgDocCnts)
                 && (pccCpMsgSt1.CampaignName == pccCpMsgSt2.CampaignName)
                 && (pccCpMsgSt1.CampaignObjDiv == pccCpMsgSt2.CampaignObjDiv)
                 && (pccCpMsgSt1.UpdateFlag == pccCpMsgSt2.UpdateFlag));
        }
        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PccCpMsgSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCpMsgSt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PccCpMsgSt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.CampaignCode != target.CampaignCode) resList.Add("CampaignCode");
            if (this.ApplyStaDate != target.ApplyStaDate) resList.Add("ApplyStaDate");
            if (this.ApplyEndDate != target.ApplyEndDate) resList.Add("ApplyEndDate");
            if (this.PccMsgDocCnts != target.PccMsgDocCnts) resList.Add("PccMsgDocCnts");
            if (this.CampaignName != target.CampaignName) resList.Add("CampaignName");
            if (this.CampaignObjDiv != target.CampaignObjDiv) resList.Add("CampaignObjDiv");
            if (this.UpdateFlag != target.UpdateFlag) resList.Add("UpdateFlag");

            return resList;
        }

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="pccCpMsgSt1">��r����PccCpMsgSt�N���X�̃C���X�^���X</param>
        /// <param name="pccCpMsgSt2">��r����PccCpMsgSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCpMsgSt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PccCpMsgSt pccCpMsgSt1, PccCpMsgSt pccCpMsgSt2)
        {
            ArrayList resList = new ArrayList();
            if (pccCpMsgSt1.CreateDateTime != pccCpMsgSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (pccCpMsgSt1.UpdateDateTime != pccCpMsgSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pccCpMsgSt1.LogicalDeleteCode != pccCpMsgSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pccCpMsgSt1.InqOtherEpCd != pccCpMsgSt2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (pccCpMsgSt1.InqOtherSecCd != pccCpMsgSt2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (pccCpMsgSt1.CampaignCode != pccCpMsgSt2.CampaignCode) resList.Add("CampaignCode");
            if (pccCpMsgSt1.ApplyStaDate != pccCpMsgSt2.ApplyStaDate) resList.Add("ApplyStaDate");
            if (pccCpMsgSt1.ApplyEndDate != pccCpMsgSt2.ApplyEndDate) resList.Add("ApplyEndDate");
            if (pccCpMsgSt1.PccMsgDocCnts != pccCpMsgSt2.PccMsgDocCnts) resList.Add("PccMsgDocCnts");
            if (pccCpMsgSt1.CampaignName != pccCpMsgSt2.CampaignName) resList.Add("CampaignName");
            if (pccCpMsgSt1.CampaignObjDiv != pccCpMsgSt2.CampaignObjDiv) resList.Add("CampaignObjDiv");
            if (pccCpMsgSt1.UpdateFlag != pccCpMsgSt2.UpdateFlag) resList.Add("UpdateFlag");

            return resList;
        }
    }
}
