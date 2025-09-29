//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : TSP�A�g�}�X�^�ݒ�
// �v���O�����T�v   : TSP�A�g�}�X�^�ݒ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11670305-00  �쐬�S�� : 3H ������
// �� �� �� : 2020/11/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TspCprtStWork
    /// <summary>
    /// TSP�A�g�}�X�^�ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>Note             :   TSP�A�g�}�X�^�ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   3H ������</br>
    /// <br>Date             :   2020/11/23</br>
    /// <br>�˗��ԍ�         :   11670305-00</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TspCprtStWork : IFileHeader
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

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary> ���M�敪</summary>
        private Int32 _sendCode;

        /// <summary>�ԓ`���M�敪</summary>
        /// <remarks>0:����G1:���Ȃ�</remarks>
        private Int32 _debitNSendCode;

        /// <summary>���M��ƃR�[�h</summary>
        /// <remarks>TSP���M���ƃR�[�h</remarks>
        private string _sendEnterpriseCode = "";

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

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
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

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>���Ӑ�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  SendCode
        /// <summary>���M�敪�v���p�e�B</summary>
        /// <value>0:�����i�`�[�쐬���ɑ��M�j,1:�ꊇ�i�蓮���M��ʂő��M�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendCode
        {
            get { return _sendCode; }
            set { _sendCode = value; }
        }

        /// public propaty name  :  DebitNSendCode
        /// <summary>�ԓ`���M�敪�v���p�e�B</summary>
        /// <value>0:����,1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԓ`���M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNSendCode
        {
            get { return _debitNSendCode; }
            set { _debitNSendCode = value; }
        }

        /// public propaty name  :  SendEnterpriseCode
        /// <summary>���M��ƃR�[�h�v���p�e�B</summary>
        /// <value>TSP���M���ƃR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SendEnterpriseCode
        {
            get { return _sendEnterpriseCode; }
            set { _sendEnterpriseCode = value; }
        }

        /// public propaty name : UpdateDateTimeJpInFormal
        /// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note : �X�V���� �a��(��)�v���p�e�B</br>
        /// <br>Programer : ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// <summary>
        /// TSP�A�g�}�X�^�ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>TspCprtStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note             :   TspCprtStWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TspCprtStWork()
        {
        }

        /// <summary>
        /// TSP�A�g�}�X�^�ݒ�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="sendCode">���M�敪</param>
        /// <param name="debitNSendCode">�ԓ`���M�敪</param>
        /// <param name="sendEnterpriseCode">���M��ƃR�[�h</param>
        /// <returns>TspCprtStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note             :   SecOrderAutoSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TspCprtStWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 customerCode, Int32 sendCode, Int32 debitNSendCode, string sendEnterpriseCode)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._customerCode = customerCode;
            this._sendCode = sendCode;
            this._debitNSendCode = debitNSendCode;
            this._sendEnterpriseCode = sendEnterpriseCode;
        }

        /// <summary>
        /// TSP�A�g�}�X�^�ݒ蕡������
        /// </summary>
        /// <returns>TspCprtStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note             :   ���g�̓��e�Ɠ�����TspCprtStWork�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TspCprtStWork Clone()
        {
            return new TspCprtStWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._sendCode, this._debitNSendCode, this._sendEnterpriseCode);
        }

        /// <summary>
        /// TSP�A�g�}�X�^�ݒ��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SecOrderAutoSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note             : TspCprtStWork�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        : ��������</br>
        /// </remarks>
        public bool Equals(TspCprtStWork target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.SendCode == target.SendCode)
                 && (this.DebitNSendCode == target.DebitNSendCode)
                 && (this.SendEnterpriseCode == target.SendEnterpriseCode));
                 
        }

        /// <summary>
        /// TSP�A�g�}�X�^�ݒ��r����
        /// </summary>
        /// <param name="tspCprtSt1">
        /// ��r����TspCprtStWork�N���X�̃C���X�^���X
        /// </param>
        /// <param name="tspCprtSt2">��r����TspCprtStWork�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note             : TspCprtStWork�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        : ��������</br>
        /// </remarks>
        public static bool Equals(TspCprtStWork tspCprtSt1, TspCprtStWork tspCprtSt2)
        {
            return ((tspCprtSt1.CreateDateTime == tspCprtSt2.CreateDateTime)
                           && (tspCprtSt1.UpdateDateTime == tspCprtSt2.UpdateDateTime)
                           && (tspCprtSt1.EnterpriseCode == tspCprtSt2.EnterpriseCode)
                           && (tspCprtSt1.FileHeaderGuid == tspCprtSt2.FileHeaderGuid)
                           && (tspCprtSt1.UpdEmployeeCode == tspCprtSt2.UpdEmployeeCode)
                           && (tspCprtSt1.UpdAssemblyId1 == tspCprtSt2.UpdAssemblyId1)
                           && (tspCprtSt1.UpdAssemblyId2 == tspCprtSt2.UpdAssemblyId2)
                           && (tspCprtSt1.LogicalDeleteCode == tspCprtSt2.LogicalDeleteCode)
                           && (tspCprtSt1.CustomerCode == tspCprtSt2.CustomerCode)
                           && (tspCprtSt1.SendCode == tspCprtSt2.SendCode)
                           && (tspCprtSt1.DebitNSendCode == tspCprtSt2.DebitNSendCode)
                           && (tspCprtSt1.SendEnterpriseCode == tspCprtSt2.SendEnterpriseCode));
        }
        /// <summary>
        /// TSP�A�g�}�X�^�ݒ��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�TspCprtStWork�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note             : TspCprtStWork�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        : ��������</br>
        /// </remarks>
        public ArrayList Compare(TspCprtStWork target)
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
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.SendCode != target.SendCode) resList.Add("SendCode");
            if (this.DebitNSendCode != target.DebitNSendCode) resList.Add("DebitNSendCode");
            if (this.SendEnterpriseCode != target.SendEnterpriseCode) resList.Add("SendEnterpriseCode");

            return resList;
        }

        /// <summary>
        /// TSP�A�g�}�X�^�ݒ��r����
        /// </summary>
        /// <param name="tspCprtSt1">��r����TspCprtSt�N���X�̃C���X�^���X</param>
        /// <param name="tspCprtSt2">��r����TspCprtSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note             :   TspCprtStWork�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(TspCprtStWork tspCprtSt1, TspCprtStWork tspCprtSt2)
        {
            ArrayList resList = new ArrayList();
            if (tspCprtSt1.CreateDateTime != tspCprtSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (tspCprtSt1.UpdateDateTime != tspCprtSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (tspCprtSt1.EnterpriseCode != tspCprtSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (tspCprtSt1.FileHeaderGuid != tspCprtSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (tspCprtSt1.UpdEmployeeCode != tspCprtSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (tspCprtSt1.UpdAssemblyId1 != tspCprtSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (tspCprtSt1.UpdAssemblyId2 != tspCprtSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (tspCprtSt1.LogicalDeleteCode != tspCprtSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (tspCprtSt1.CustomerCode != tspCprtSt2.CustomerCode) resList.Add("CustomerCode");
            if (tspCprtSt1.SendCode != tspCprtSt2.SendCode) resList.Add("SendCode");
            if (tspCprtSt1.DebitNSendCode != tspCprtSt2.DebitNSendCode) resList.Add("DebitNSendCode");
            if (tspCprtSt1.SendEnterpriseCode != tspCprtSt2.SendEnterpriseCode) resList.Add("SendEnterpriseCode");
            
            return resList;
        }
    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>TspCprtStWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note             :   TspCprtStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class TspCprtStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note             :   TspCprtStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  TspCprtStWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is TspCprtStWork || graph is ArrayList || graph is TspCprtStWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(TspCprtStWork).FullName));

            if (graph != null && graph is TspCprtStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            // SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TspCprtStWork");

            // �J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     // ��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is TspCprtStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((TspCprtStWork[])graph).Length;
            }
            else if (graph is TspCprtStWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;         // �J��Ԃ���    
            // �쐬����
            serInfo.MemberInfo.Add(typeof(Int64));   // CreateDateTime
            // �X�V����
            serInfo.MemberInfo.Add(typeof(Int64));   // UpdateDateTime
            // ��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string));  // EnterpriseCode
            // GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  // FileHeaderGuid
            // �X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string));  // UpdEmployeeCode
            // �X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string));  // UpdAssemblyId1
            // �X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string));  // UpdAssemblyId2
            // �_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32));   // LogicalDeleteCode
            // ���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32));   // CustomerCode
            // ���M�敪
            serInfo.MemberInfo.Add(typeof(Int32));   // SendCode
            // �ԓ`���M�敪
            serInfo.MemberInfo.Add(typeof(Int32));   // DebitNSendCode
            // ���M��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string));  // SendEnterpriseCode
            
            serInfo.Serialize(writer, serInfo);
            if (graph is TspCprtStWork)
            {
                TspCprtStWork temp = (TspCprtStWork)graph;
                SetTspCprtStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is TspCprtStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((TspCprtStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (TspCprtStWork temp in lst)
                {
                    SetTspCprtStWork(writer, temp);
                }
            }
        }

        /// <summary>
        /// TspCprtStWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 12;

        /// <summary>
        ///  TspCprtStWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note             :   TspCprtStWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetTspCprtStWork(System.IO.BinaryWriter writer, TspCprtStWork temp)
        {
            // �쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            // �X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            // ��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            // GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            // �X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            // �X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            // �X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            // �_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            // ���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            // ���M�敪
            writer.Write(temp.SendCode);
            // �ԓ`���M�敪
            writer.Write(temp.DebitNSendCode);
            // ���M��ƃR�[�h
            writer.Write(temp.SendEnterpriseCode);
            
        }

        /// <summary>
        ///  TspCprtStWork�C���X�^���X�擾
        /// </summary>
        /// <returns>TspCprtStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       :   TspCprtStWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer  :   ��������</br>
        /// </remarks>
        private TspCprtStWork GetTspCprtStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            TspCprtStWork temp = new TspCprtStWork();

            // �쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            // �X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            // ��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            // GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            // �X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            // �X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            // �X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            // �_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            // ���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            // ���M�敪
            temp.SendCode = reader.ReadInt32();
            // �ԓ`���M�敪
            temp.DebitNSendCode = reader.ReadInt32();
            // ���M��ƃR�[�h
            temp.SendEnterpriseCode = reader.ReadString();

            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>TspCprtStWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note             :   TspCprtStWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                TspCprtStWork temp = GetTspCprtStWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (TspCprtStWork[])lst.ToArray(typeof(TspCprtStWork));
                    break;
            }
            return retValue;
        }
        #endregion
    }
}