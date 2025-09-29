using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SAndESalSndLogListResult
    /// <summary>
    /// ����f�[�^���M���O�e�[�u��
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����f�[�^���M���O�e�[�u���w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2013/06/26</br>
    /// <br>Genarated Date   :   2013/06/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SAndESalSndLogListResult
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
        /// <returns>SAndESalSndLogListResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESalSndLogListResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SAndESalSndLogListResult()
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
        public SAndESalSndLogListResult(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 sAndEAutoSendDiv, Int64 sendDateTimeStart, Int64 sendDateTimeEnd, Int32 sendObjDateStart, Int32 sendObjDateEnd, Int32 sendObjCustStart, Int32 sendObjCustEnd, Int32 sendObjDiv, Int32 sendResults, string sendErrorContents, Int32 sendSlipCount, Int32 sendSlipDtlCnt, Int64 sendSlipTotalMny) 
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
        public SAndESalSndLogListResult Clone()
        {
            return new SAndESalSndLogListResult(_createDateTime, _updateDateTime, _enterpriseCode, _fileHeaderGuid, _updEmployeeCode, _updAssemblyId1, _updAssemblyId2, _logicalDeleteCode, _sectionCode, _sAndEAutoSendDiv, _sendDateTimeStart, _sendDateTimeEnd, _sendObjDateStart, _sendObjDateEnd, _sendObjCustStart, _sendObjCustEnd, _sendObjDiv, _sendResults, _sendErrorContents, _sendSlipCount, _sendSlipDtlCnt, _sendSlipTotalMny);
        }

        /// <summary>
        /// ����f�[�^���M���O�e�[�u����r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SAndESalSndLogListResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESalSndLogListResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SAndESalSndLogListResult target)
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
        /// <param name="SAndESalSndLogListResult1">��r����SAndESalSndLogListResult�N���X�̃C���X�^���X</param>
        /// <param name="SAndESalSndLogListResult2">��r����SAndESalSndLogListResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESalSndLogListResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SAndESalSndLogListResult SAndESalSndLogListResult1, SAndESalSndLogListResult SAndESalSndLogListResult2)
        {
            return ((SAndESalSndLogListResult1.CreateDateTime == SAndESalSndLogListResult2.CreateDateTime)
                 && (SAndESalSndLogListResult1.UpdateDateTime == SAndESalSndLogListResult2.UpdateDateTime)
                 && (SAndESalSndLogListResult1.EnterpriseCode == SAndESalSndLogListResult2.EnterpriseCode)
                 && (SAndESalSndLogListResult1.FileHeaderGuid == SAndESalSndLogListResult2.FileHeaderGuid)
                 && (SAndESalSndLogListResult1.UpdEmployeeCode == SAndESalSndLogListResult2.UpdEmployeeCode)
                 && (SAndESalSndLogListResult1.UpdAssemblyId1 == SAndESalSndLogListResult2.UpdAssemblyId1)
                 && (SAndESalSndLogListResult1.UpdAssemblyId2 == SAndESalSndLogListResult2.UpdAssemblyId2)
                 && (SAndESalSndLogListResult1.LogicalDeleteCode == SAndESalSndLogListResult2.LogicalDeleteCode)
                 && (SAndESalSndLogListResult1.SectionCode == SAndESalSndLogListResult2.SectionCode)
                 && (SAndESalSndLogListResult1.SAndEAutoSendDiv == SAndESalSndLogListResult2.SAndEAutoSendDiv)
                 && (SAndESalSndLogListResult1.SendDateTimeStart == SAndESalSndLogListResult2.SendDateTimeStart)
                 && (SAndESalSndLogListResult1.SendDateTimeEnd == SAndESalSndLogListResult2.SendDateTimeEnd)
                 && (SAndESalSndLogListResult1.SendObjDateStart == SAndESalSndLogListResult2.SendObjDateStart)
                 && (SAndESalSndLogListResult1.SendObjDateEnd == SAndESalSndLogListResult2.SendObjDateEnd)
                 && (SAndESalSndLogListResult1.SendObjCustStart == SAndESalSndLogListResult2.SendObjCustStart)
                 && (SAndESalSndLogListResult1.SendObjCustEnd == SAndESalSndLogListResult2.SendObjCustEnd)
                 && (SAndESalSndLogListResult1.SendObjDiv == SAndESalSndLogListResult2.SendObjDiv)
                 && (SAndESalSndLogListResult1.SendResults == SAndESalSndLogListResult2.SendResults)
                 && (SAndESalSndLogListResult1.SendErrorContents == SAndESalSndLogListResult2.SendErrorContents)
                 && (SAndESalSndLogListResult1.SendSlipCount == SAndESalSndLogListResult2.SendSlipCount)
                 && (SAndESalSndLogListResult1.SendSlipDtlCnt == SAndESalSndLogListResult2.SendSlipDtlCnt)
                 && (SAndESalSndLogListResult1.SendSlipTotalMny == SAndESalSndLogListResult2.SendSlipTotalMny));
        }
        /// <summary>
        /// ����f�[�^���M���O�e�[�u����r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SAndESalSndLogListResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESalSndLogListResult�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SAndESalSndLogListResult target)
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
        /// <param name="SAndESalSndLogListResult1">��r����SAndESalSndLogListResult�N���X�̃C���X�^���X</param>
        /// <param name="SAndESalSndLogListResult2">��r����SAndESalSndLogListResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SAndESalSndLogListResult�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SAndESalSndLogListResult SAndESalSndLogListResult1, SAndESalSndLogListResult SAndESalSndLogListResult2)
        {
            ArrayList resList = new ArrayList();
            if (SAndESalSndLogListResult1.CreateDateTime != SAndESalSndLogListResult2.CreateDateTime) resList.Add("CreateDateTime");
            if (SAndESalSndLogListResult1.UpdateDateTime != SAndESalSndLogListResult2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (SAndESalSndLogListResult1.EnterpriseCode != SAndESalSndLogListResult2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (SAndESalSndLogListResult1.FileHeaderGuid != SAndESalSndLogListResult2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (SAndESalSndLogListResult1.UpdEmployeeCode != SAndESalSndLogListResult2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (SAndESalSndLogListResult1.UpdAssemblyId1 != SAndESalSndLogListResult2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (SAndESalSndLogListResult1.UpdAssemblyId2 != SAndESalSndLogListResult2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (SAndESalSndLogListResult1.LogicalDeleteCode != SAndESalSndLogListResult2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (SAndESalSndLogListResult1.SectionCode != SAndESalSndLogListResult2.SectionCode) resList.Add("SectionCode");
            if (SAndESalSndLogListResult1.SAndEAutoSendDiv != SAndESalSndLogListResult2.SAndEAutoSendDiv) resList.Add("SAndEAutoSendDiv");
            if (SAndESalSndLogListResult1.SendDateTimeStart != SAndESalSndLogListResult2.SendDateTimeStart) resList.Add("SendDateTimeStart");
            if (SAndESalSndLogListResult1.SendDateTimeEnd != SAndESalSndLogListResult2.SendDateTimeEnd) resList.Add("SendDateTimeEnd");
            if (SAndESalSndLogListResult1.SendObjDateStart != SAndESalSndLogListResult2.SendObjDateStart) resList.Add("SendObjDateStart");
            if (SAndESalSndLogListResult1.SendObjDateEnd != SAndESalSndLogListResult2.SendObjDateEnd) resList.Add("SendObjDateEnd");
            if (SAndESalSndLogListResult1.SendObjCustStart != SAndESalSndLogListResult2.SendObjCustStart) resList.Add("SendObjCustStart");
            if (SAndESalSndLogListResult1.SendObjCustEnd != SAndESalSndLogListResult2.SendObjCustEnd) resList.Add("SendObjCustEnd");
            if (SAndESalSndLogListResult1.SendObjDiv != SAndESalSndLogListResult2.SendObjDiv) resList.Add("SendObjDiv");
            if (SAndESalSndLogListResult1.SendResults != SAndESalSndLogListResult2.SendResults) resList.Add("SendResults");
            if (SAndESalSndLogListResult1.SendErrorContents != SAndESalSndLogListResult2.SendErrorContents) resList.Add("SendErrorContents");
            if (SAndESalSndLogListResult1.SendSlipCount != SAndESalSndLogListResult2.SendSlipCount) resList.Add("SendSlipCount");
            if (SAndESalSndLogListResult1.SendSlipDtlCnt != SAndESalSndLogListResult2.SendSlipDtlCnt) resList.Add("SendSlipDtlCnt");
            if (SAndESalSndLogListResult1.SendSlipTotalMny != SAndESalSndLogListResult2.SendSlipTotalMny) resList.Add("SendSlipTotalMny");

            return resList;
        }
    }
}
