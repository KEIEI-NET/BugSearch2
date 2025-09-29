using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalCprtSndLogListResult
    /// <summary>
    /// ����f�[�^���M���O�e�[�u��
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����f�[�^���M���O�e�[�u���w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2019/12/02</br>
    /// <br>Genarated Date   :   2019/12/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SalCprtSndLogListResult
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�������M�敪</summary>
        /// <remarks>0:�蓮,1:����</remarks>
        private Int32 _sAndEAutoSendDiv;

        /// <summary>���M�����i�J�n�j</summary>
        /// <remarks>���M�J�n���ԁi200601011212(������t�{�����j</remarks>
        private Int64 _sendDateTimeStart;

        /// <summary>���M�����i�I���j</summary>
        /// <remarks>���M�������ԁi200601011212(������t�{�����j</remarks>
        private Int64 _sendDateTimeEnd;

        /// <summary>���M�Ώۓ��t�i�J�n�j</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _sendObjDateStart;

        /// <summary>���M�Ώۓ��t�i�I���j</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _sendObjDateEnd;

        /// <summary>���M�Ώۓ��Ӑ�i�J�n�j</summary>
        private Int32 _sendObjCustStart;

        /// <summary>���M�Ώۓ��Ӑ�i�I���j</summary>
        private Int32 _sendObjCustEnd;

        /// <summary>���M�Ώۋ敪</summary>
        /// <remarks>0:�S��,1:�����M,2�F���M��</remarks>
        private Int32 _sendObjDiv;

        /// <summary>���M����</summary>
        /// <remarks>0:���튮��,1�F���s</remarks>
        private Int32 _sendResults;

        /// <summary>���M�G���[���e</summary>
        private string _sendErrorContents = "";

        /// <summary>���M�`�[����</summary>
        /// <remarks>���M�����`�[����</remarks>
        private Int32 _sendSlipCount;

        /// <summary>���M�`�[���א�</summary>
        /// <remarks>���M�����`�[���א��\��</remarks>
        private Int32 _sendSlipDtlCnt;

        /// <summary>���M�`�[���v���z</summary>
        /// <remarks>���M�����`�[�̍��v���z</remarks>
        private Int64 _sendSlipTotalMny;

        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬����</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V����</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SAndEAutoSendDiv
        /// <summary>�������M�敪</summary>
        /// <value>0:�蓮,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������M�敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SAndEAutoSendDiv
        {
            get { return _sAndEAutoSendDiv; }
            set { _sAndEAutoSendDiv = value; }
        }

        /// public propaty name  :  SendDateTimeStart
        /// <summary>���M�����i�J�n�j</summary>
        /// <value>���M�J�n���ԁi200601011212(������t�{�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�����i�J�n�j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SendDateTimeStart
        {
            get { return _sendDateTimeStart; }
            set { _sendDateTimeStart = value; }
        }

        /// public propaty name  :  SendDateTimeEnd
        /// <summary>���M�����i�I���j</summary>
        /// <value>���M�������ԁi200601011212(������t�{�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�����i�I���j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SendDateTimeEnd
        {
            get { return _sendDateTimeEnd; }
            set { _sendDateTimeEnd = value; }
        }

        /// public propaty name  :  SendObjDateStart
        /// <summary>���M�Ώۓ��t�i�J�n�j</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�Ώۓ��t�i�J�n�j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendObjDateStart
        {
            get { return _sendObjDateStart; }
            set { _sendObjDateStart = value; }
        }

        /// public propaty name  :  SendObjDateEnd
        /// <summary>���M�Ώۓ��t�i�I���j</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�Ώۓ��t�i�I���j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendObjDateEnd
        {
            get { return _sendObjDateEnd; }
            set { _sendObjDateEnd = value; }
        }

        /// public propaty name  :  SendObjCustStart
        /// <summary>���M�Ώۓ��Ӑ�i�J�n�j</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�Ώۓ��Ӑ�i�J�n�j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendObjCustStart
        {
            get { return _sendObjCustStart; }
            set { _sendObjCustStart = value; }
        }

        /// public propaty name  :  SendObjCustEnd
        /// <summary>���M�Ώۓ��Ӑ�i�I���j</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�Ώۓ��Ӑ�i�I���j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendObjCustEnd
        {
            get { return _sendObjCustEnd; }
            set { _sendObjCustEnd = value; }
        }

        /// public propaty name  :  SendObjDiv
        /// <summary>���M�Ώۋ敪</summary>
        /// <value>0:�S��,1:�����M,2�F���M��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�Ώۋ敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendObjDiv
        {
            get { return _sendObjDiv; }
            set { _sendObjDiv = value; }
        }

        /// public propaty name  :  SendResults
        /// <summary>���M����</summary>
        /// <value>0:���튮��,1�F���s</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendResults
        {
            get { return _sendResults; }
            set { _sendResults = value; }
        }

        /// public propaty name  :  SendErrorContents
        /// <summary>���M�G���[���e</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�G���[���e</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SendErrorContents
        {
            get { return _sendErrorContents; }
            set { _sendErrorContents = value; }
        }

        /// public propaty name  :  SendSlipCount
        /// <summary>���M�`�[����</summary>
        /// <value>���M�����`�[����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�`�[����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendSlipCount
        {
            get { return _sendSlipCount; }
            set { _sendSlipCount = value; }
        }

        /// public propaty name  :  SendSlipDtlCnt
        /// <summary>���M�`�[���א�</summary>
        /// <value>���M�����`�[���א��\��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�`�[���א�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendSlipDtlCnt
        {
            get { return _sendSlipDtlCnt; }
            set { _sendSlipDtlCnt = value; }
        }

        /// public propaty name  :  SendSlipTotalMny
        /// <summary>���M�`�[���v���z</summary>
        /// <value>���M�����`�[�̍��v���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�`�[���v���z</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SendSlipTotalMny
        {
            get { return _sendSlipTotalMny; }
            set { _sendSlipTotalMny = value; }
        }

        /// <summary>
        /// ����f�[�^���M���O�e�[�u���R���X�g���N�^
        /// </summary>
        /// <returns>SalCprtSndLogListResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalCprtSndLogListResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalCprtSndLogListResult()
        {
        }

        /// <summary>
        /// ����f�[�^���M���O�e�[�u���R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2</param>
        /// <param name="logicalDeleteCode">�_���폜�敪</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="sAndEAutoSendDiv">�������M�敪</param>
        /// <param name="sendDateTimeStart">���M�����i�J�n�j</param>
        /// <param name="sendDateTimeEnd">���M�����i�I���j</param>
        /// <param name="sendObjDateStart">���M�Ώۓ��t�i�J�n�j</param>
        /// <param name="sendObjDateEnd">���M�Ώۓ��t�i�I���j</param>
        /// <param name="sendObjCustStart">���M�Ώۓ��Ӑ�i�J�n�j</param>
        /// <param name="sendObjCustEnd">���M�Ώۓ��Ӑ�i�I���j</param>
        /// <param name="sendObjDiv">���M�Ώۋ敪</param>
        /// <param name="sendResults">���M����</param>
        /// <param name="sendErrorContents">���M�G���[���e</param>
        /// <param name="sendSlipCount">���M�`�[����</param>
        /// <param name="sendSlipDtlCnt">���M�`�[���א�</param>
        /// <param name="sendSlipTotalMny">���M�`�[���v���z</param>
        /// <returns>SAndESalSndLogListResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESalSndLogListResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalCprtSndLogListResult(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 sAndEAutoSendDiv, Int64 sendDateTimeStart, Int64 sendDateTimeEnd, Int32 sendObjDateStart, Int32 sendObjDateEnd, Int32 sendObjCustStart, Int32 sendObjCustEnd, Int32 sendObjDiv, Int32 sendResults, string sendErrorContents, Int32 sendSlipCount, Int32 sendSlipDtlCnt, Int64 sendSlipTotalMny) 
        {
            this._createDateTime = createDateTime;
            this._updateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;
            this._sAndEAutoSendDiv = sAndEAutoSendDiv;
            this._sendDateTimeStart = sendDateTimeStart;
            this._sendDateTimeEnd = sendDateTimeEnd;
            this._sendObjDateStart = sendObjDateStart;
            this._sendObjDateEnd = sendObjDateEnd;
            this._sendObjCustStart = sendObjCustStart;
            this._sendObjCustEnd = sendObjCustEnd;
            this._sendObjDiv = sendObjDiv;
            this._sendResults = sendResults;
            this._sendErrorContents = sendErrorContents;
            this._sendSlipCount = sendSlipCount;
            this._sendSlipDtlCnt = sendSlipDtlCnt;
            this._sendSlipTotalMny = sendSlipTotalMny;
        }

        /// <summary>
        /// ����f�[�^���M���O�e�[�u����������
        /// </summary>
        /// <returns>SAndESalSndLogListResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SAndESalSndLogListResult�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalCprtSndLogListResult Clone()
        {
            return new SalCprtSndLogListResult(_createDateTime, _updateDateTime, _enterpriseCode, _fileHeaderGuid, _updEmployeeCode, _updAssemblyId1, _updAssemblyId2, _logicalDeleteCode, _sectionCode, _sAndEAutoSendDiv, _sendDateTimeStart, _sendDateTimeEnd, _sendObjDateStart, _sendObjDateEnd, _sendObjCustStart, _sendObjCustEnd, _sendObjDiv, _sendResults, _sendErrorContents, _sendSlipCount, _sendSlipDtlCnt, _sendSlipTotalMny);
        }

        /// <summary>
        /// ����f�[�^���M���O�e�[�u����r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SalCprtSndLogListResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalCprtSndLogListResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SalCprtSndLogListResult target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SAndEAutoSendDiv == target.SAndEAutoSendDiv)
                 && (this.SendDateTimeStart == target.SendDateTimeStart)
                 && (this.SendDateTimeEnd == target.SendDateTimeEnd)
                 && (this.SendObjDateStart == target.SendObjDateStart)
                 && (this.SendObjDateEnd == target.SendObjDateEnd)
                 && (this.SendObjCustStart == target.SendObjCustStart)
                 && (this.SendObjCustEnd == target.SendObjCustEnd)
                 && (this.SendObjDiv == target.SendObjDiv)
                 && (this.SendResults == target.SendResults)
                 && (this.SendErrorContents == target.SendErrorContents)
                 && (this.SendSlipCount == target.SendSlipCount)
                 && (this.SendSlipDtlCnt == target.SendSlipDtlCnt)
                 && (this.SendSlipTotalMny == target.SendSlipTotalMny));
        }

        /// <summary>
        /// ����f�[�^���M���O�e�[�u����r����
        /// </summary>
        /// <param name="SalCprtSndLogListResult1">��r����SalCprtSndLogListResult�N���X�̃C���X�^���X</param>
        /// <param name="SalCprtSndLogListResult2">��r����SalCprtSndLogListResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalCprtSndLogListResult2�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SalCprtSndLogListResult SalCprtSndLogListResult1, SalCprtSndLogListResult SalCprtSndLogListResult2)
        {
            return ((SalCprtSndLogListResult1.CreateDateTime == SalCprtSndLogListResult2.CreateDateTime)
                 && (SalCprtSndLogListResult1.UpdateDateTime == SalCprtSndLogListResult2.UpdateDateTime)
                 && (SalCprtSndLogListResult1.EnterpriseCode == SalCprtSndLogListResult2.EnterpriseCode)
                 && (SalCprtSndLogListResult1.FileHeaderGuid == SalCprtSndLogListResult2.FileHeaderGuid)
                 && (SalCprtSndLogListResult1.UpdEmployeeCode == SalCprtSndLogListResult2.UpdEmployeeCode)
                 && (SalCprtSndLogListResult1.UpdAssemblyId1 == SalCprtSndLogListResult2.UpdAssemblyId1)
                 && (SalCprtSndLogListResult1.UpdAssemblyId2 == SalCprtSndLogListResult2.UpdAssemblyId2)
                 && (SalCprtSndLogListResult1.LogicalDeleteCode == SalCprtSndLogListResult2.LogicalDeleteCode)
                 && (SalCprtSndLogListResult1.SectionCode == SalCprtSndLogListResult2.SectionCode)
                 && (SalCprtSndLogListResult1.SAndEAutoSendDiv == SalCprtSndLogListResult2.SAndEAutoSendDiv)
                 && (SalCprtSndLogListResult1.SendDateTimeStart == SalCprtSndLogListResult2.SendDateTimeStart)
                 && (SalCprtSndLogListResult1.SendDateTimeEnd == SalCprtSndLogListResult2.SendDateTimeEnd)
                 && (SalCprtSndLogListResult1.SendObjDateStart == SalCprtSndLogListResult2.SendObjDateStart)
                 && (SalCprtSndLogListResult1.SendObjDateEnd == SalCprtSndLogListResult2.SendObjDateEnd)
                 && (SalCprtSndLogListResult1.SendObjCustStart == SalCprtSndLogListResult2.SendObjCustStart)
                 && (SalCprtSndLogListResult1.SendObjCustEnd == SalCprtSndLogListResult2.SendObjCustEnd)
                 && (SalCprtSndLogListResult1.SendObjDiv == SalCprtSndLogListResult2.SendObjDiv)
                 && (SalCprtSndLogListResult1.SendResults == SalCprtSndLogListResult2.SendResults)
                 && (SalCprtSndLogListResult1.SendErrorContents == SalCprtSndLogListResult2.SendErrorContents)
                 && (SalCprtSndLogListResult1.SendSlipCount == SalCprtSndLogListResult2.SendSlipCount)
                 && (SalCprtSndLogListResult1.SendSlipDtlCnt == SalCprtSndLogListResult2.SendSlipDtlCnt)
                 && (SalCprtSndLogListResult1.SendSlipTotalMny == SalCprtSndLogListResult2.SendSlipTotalMny));
        }
        /// <summary>
        /// ����f�[�^���M���O�e�[�u����r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SalCprtSndLogListResult2�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalCprtSndLogListResult2�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SalCprtSndLogListResult target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SAndEAutoSendDiv != target.SAndEAutoSendDiv) resList.Add("SAndEAutoSendDiv");
            if (this.SendDateTimeStart != target.SendDateTimeStart) resList.Add("SendDateTimeStart");
            if (this.SendDateTimeEnd != target.SendDateTimeEnd) resList.Add("SendDateTimeEnd");
            if (this.SendObjDateStart != target.SendObjDateStart) resList.Add("SendObjDateStart");
            if (this.SendObjDateEnd != target.SendObjDateEnd) resList.Add("SendObjDateEnd");
            if (this.SendObjCustStart != target.SendObjCustStart) resList.Add("SendObjCustStart");
            if (this.SendObjCustEnd != target.SendObjCustEnd) resList.Add("SendObjCustEnd");
            if (this.SendObjDiv != target.SendObjDiv) resList.Add("SendObjDiv");
            if (this.SendResults != target.SendResults) resList.Add("SendResults");
            if (this.SendErrorContents != target.SendErrorContents) resList.Add("SendErrorContents");
            if (this.SendSlipCount != target.SendSlipCount) resList.Add("SendSlipCount");
            if (this.SendSlipDtlCnt != target.SendSlipDtlCnt) resList.Add("SendSlipDtlCnt");
            if (this.SendSlipTotalMny != target.SendSlipTotalMny) resList.Add("SendSlipTotalMny");

            return resList;
        }

        /// <summary>
        /// ����f�[�^���M���O�e�[�u����r����
        /// </summary>
        /// <param name="SalCprtSndLogListResult1">��r����SalCprtSndLogListResult1�N���X�̃C���X�^���X</param>
        /// <param name="SalCprtSndLogListResult2">��r����SalCprtSndLogListResult2�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalCprtSndLogListResult�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SalCprtSndLogListResult SalCprtSndLogListResult1, SalCprtSndLogListResult SalCprtSndLogListResult2)
        {
            ArrayList resList = new ArrayList();
            if (SalCprtSndLogListResult1.CreateDateTime != SalCprtSndLogListResult2.CreateDateTime) resList.Add("CreateDateTime");
            if (SalCprtSndLogListResult1.UpdateDateTime != SalCprtSndLogListResult2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (SalCprtSndLogListResult1.EnterpriseCode != SalCprtSndLogListResult2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (SalCprtSndLogListResult1.FileHeaderGuid != SalCprtSndLogListResult2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (SalCprtSndLogListResult1.UpdEmployeeCode != SalCprtSndLogListResult2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (SalCprtSndLogListResult1.UpdAssemblyId1 != SalCprtSndLogListResult2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (SalCprtSndLogListResult1.UpdAssemblyId2 != SalCprtSndLogListResult2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (SalCprtSndLogListResult1.LogicalDeleteCode != SalCprtSndLogListResult2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (SalCprtSndLogListResult1.SectionCode != SalCprtSndLogListResult2.SectionCode) resList.Add("SectionCode");
            if (SalCprtSndLogListResult1.SAndEAutoSendDiv != SalCprtSndLogListResult2.SAndEAutoSendDiv) resList.Add("SAndEAutoSendDiv");
            if (SalCprtSndLogListResult1.SendDateTimeStart != SalCprtSndLogListResult2.SendDateTimeStart) resList.Add("SendDateTimeStart");
            if (SalCprtSndLogListResult1.SendDateTimeEnd != SalCprtSndLogListResult2.SendDateTimeEnd) resList.Add("SendDateTimeEnd");
            if (SalCprtSndLogListResult1.SendObjDateStart != SalCprtSndLogListResult2.SendObjDateStart) resList.Add("SendObjDateStart");
            if (SalCprtSndLogListResult1.SendObjDateEnd != SalCprtSndLogListResult2.SendObjDateEnd) resList.Add("SendObjDateEnd");
            if (SalCprtSndLogListResult1.SendObjCustStart != SalCprtSndLogListResult2.SendObjCustStart) resList.Add("SendObjCustStart");
            if (SalCprtSndLogListResult1.SendObjCustEnd != SalCprtSndLogListResult2.SendObjCustEnd) resList.Add("SendObjCustEnd");
            if (SalCprtSndLogListResult1.SendObjDiv != SalCprtSndLogListResult2.SendObjDiv) resList.Add("SendObjDiv");
            if (SalCprtSndLogListResult1.SendResults != SalCprtSndLogListResult2.SendResults) resList.Add("SendResults");
            if (SalCprtSndLogListResult1.SendErrorContents != SalCprtSndLogListResult2.SendErrorContents) resList.Add("SendErrorContents");
            if (SalCprtSndLogListResult1.SendSlipCount != SalCprtSndLogListResult2.SendSlipCount) resList.Add("SendSlipCount");
            if (SalCprtSndLogListResult1.SendSlipDtlCnt != SalCprtSndLogListResult2.SendSlipDtlCnt) resList.Add("SendSlipDtlCnt");
            if (SalCprtSndLogListResult1.SendSlipTotalMny != SalCprtSndLogListResult2.SendSlipTotalMny) resList.Add("SendSlipTotalMny");

            return resList;
        }
    }
}
