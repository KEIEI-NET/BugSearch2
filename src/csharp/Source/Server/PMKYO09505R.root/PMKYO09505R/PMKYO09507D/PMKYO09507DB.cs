//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���_�Ǘ�DC����M���������e�i���X
// �v���O�����T�v   : ����M�����̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ����
// �� �� ��  2012/07/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �� �� ��  2012/10/16  �C�����e : ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{

    /// public class name:   SndRcvHisConWork
    /// <summary>
    ///                      ����M�����e�[�u���f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����M�����e�[�u���f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2012/08/08</br>
    /// <br>Genarated Date   :   2012/08/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2012/08/08  ����</br>
    /// <br>                 :   �V�K�쐬</br>
    /// <br>Update Note      :   2012/10/16 ������</br>
    ///	<br>			         10801804-00�ARedmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SndRcvHisConWork : IFileHeader
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

        /// <summary>����M���𑗎�M�ԍ�</summary>
        private Int32 _sndRcvHisSndRcvNo;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>����M�������O���M�ԍ�</summary>
        private Int32 _sndRcvHisConsNo;

        /// <summary>����M����</summary>
        /// <remarks>������t�{�����@�@��j200601011212</remarks>
        private Int64 _sndRcvDateTime;

        /// <summary>����M�敪</summary>
        /// <remarks>0:���M�i�o�́j�@1:��M�i�捞�j</remarks>
        private Int32 _sendOrReceiveDivCd;

        /// <summary>���</summary>
        /// <remarks>0:�f�[�^�@1:�}�X�^</remarks>
        private Int32 _kind;

        /// <summary>����M���O���o�����敪</summary>
        /// <remarks>0:����(����)�@1:�蓮(����)</remarks>
        private Int32 _sndLogExtraCondDiv;

        // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
        ///// <summary>�����J�n����</summary>
        ///// <remarks>DateTime:���x��100�i�m�b</remarks>
        //private Int64 _procStartDateTime;

        ///// <summary>�����I������</summary>
        ///// <remarks>DateTime:���x��100�i�m�b</remarks>
        //private Int64 _procEndDateTime;
        // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<

        /// <summary>���M���ƃR�[�h</summary>
        private string _sendDestEpCode = "";

        /// <summary>���M�拒�_�R�[�h</summary>
        private string _sendDestSecCode = "";

        /// <summary>����M���</summary>
        /// <remarks>0:����  1:���s</remarks>
        private Int32 _sndRcvCondition;

        /// <summary>����M�敪</summary>
        /// <remarks>1:��M�@2:����M</remarks>
        private Int32 _tempReceiveDiv;

        /// <summary>����M�G���[���e</summary>
        private string _sndRcvErrContents = "";

        /// <summary>����M�t�@�C���h�c</summary>
        /// <remarks>�t�@�C��ID1,�t�@�C��ID2,�t�@�C��ID3�c�c�c�t�@�C��ID4</remarks>
        private string _sndRcvFileID = "";

        /// <summary>����M����(�J�n)</summary>
        /// <remarks>������t�{�����@�@��j200601011212</remarks>
        private Int64 _sndRcvStartDateTime;

        /// <summary>����M����(�I��)</summary>
        /// <remarks>������t�{�����@�@��j200601011212</remarks>
        private Int64 _sndRcvEndDateTime;


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

        /// public propaty name  :  SndRcvHisSndRcvNo
        /// <summary>����M���𑗎�M�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����M���𑗎�M�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SndRcvHisSndRcvNo
        {
            get { return _sndRcvHisSndRcvNo; }
            set { _sndRcvHisSndRcvNo = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SndRcvHisConsNo
        /// <summary>����M�������O���M�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����M�������O���M�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SndRcvHisConsNo
        {
            get { return _sndRcvHisConsNo; }
            set { _sndRcvHisConsNo = value; }
        }

        /// public propaty name  :  SndRcvDateTime
        /// <summary>����M�����v���p�e�B</summary>
        /// <value>������t�{�����@�@��j200601011212</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����M�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SndRcvDateTime
        {
            get { return _sndRcvDateTime; }
            set { _sndRcvDateTime = value; }
        }

        /// public propaty name  :  SendOrReceiveDivCd
        /// <summary>����M�敪�v���p�e�B</summary>
        /// <value>0:���M�i�o�́j�@1:��M�i�捞�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendOrReceiveDivCd
        {
            get { return _sendOrReceiveDivCd; }
            set { _sendOrReceiveDivCd = value; }
        }

        /// public propaty name  :  Kind
        /// <summary>��ʃv���p�e�B</summary>
        /// <value>0:�f�[�^�@1:�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }

        /// public propaty name  :  SndLogExtraCondDiv
        /// <summary>����M���O���o�����敪�v���p�e�B</summary>
        /// <value>0:����(����)�@1:�蓮(����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����M���O���o�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SndLogExtraCondDiv
        {
            get { return _sndLogExtraCondDiv; }
            set { _sndLogExtraCondDiv = value; }
        }

        // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
        ///// public propaty name  :  ProcStartDateTime
        ///// <summary>�����J�n�����v���p�e�B</summary>
        ///// <value>DateTime:���x��100�i�m�b</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �����J�n�����v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int64 ProcStartDateTime
        //{
        //    get { return _procStartDateTime; }
        //    set { _procStartDateTime = value; }
        //}

        ///// public propaty name  :  ProcEndDateTime
        ///// <summary>�����I�������v���p�e�B</summary>
        ///// <value>DateTime:���x��100�i�m�b</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �����I�������v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int64 ProcEndDateTime
        //{
        //    get { return _procEndDateTime; }
        //    set { _procEndDateTime = value; }
        //}
        // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<

        /// public propaty name  :  SendDestEpCode
        /// <summary>���M���ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M���ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SendDestEpCode
        {
            get { return _sendDestEpCode; }
            set { _sendDestEpCode = value; }
        }

        /// public propaty name  :  SendDestSecCode
        /// <summary>���M�拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SendDestSecCode
        {
            get { return _sendDestSecCode; }
            set { _sendDestSecCode = value; }
        }

        /// public propaty name  :  SndRcvCondition
        /// <summary>����M��ԃv���p�e�B</summary>
        /// <value>0:����  1:���s</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����M��ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SndRcvCondition
        {
            get { return _sndRcvCondition; }
            set { _sndRcvCondition = value; }
        }

        /// public propaty name  :  TempReceiveDiv
        /// <summary>����M�敪�v���p�e�B</summary>
        /// <value>1:��M�@2:����M</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TempReceiveDiv
        {
            get { return _tempReceiveDiv; }
            set { _tempReceiveDiv = value; }
        }

        /// public propaty name  :  SndRcvErrContents
        /// <summary>����M�G���[���e�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����M�G���[���e�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SndRcvErrContents
        {
            get { return _sndRcvErrContents; }
            set { _sndRcvErrContents = value; }
        }

        /// public propaty name  :  SndRcvFileID
        /// <summary>����M�t�@�C���h�c�v���p�e�B</summary>
        /// <value>�t�@�C��ID1,�t�@�C��ID2,�t�@�C��ID3�c�c�c�t�@�C��ID4</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����M�t�@�C���h�c�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SndRcvFileID
        {
            get { return _sndRcvFileID; }
            set { _sndRcvFileID = value; }
        }

        /// public propaty name  :  SndRcvStartDateTime
        /// <summary>����M����(�J�n)�v���p�e�B</summary>
        /// <value>������t�{�����@�@��j200601011212</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����M����(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SndRcvStartDateTime
        {
            get { return _sndRcvStartDateTime; }
            set { _sndRcvStartDateTime = value; }
        }

        /// public propaty name  :  SndRcvEndDateTime
        /// <summary>����M����(�I��)�v���p�e�B</summary>
        /// <value>������t�{�����@�@��j200601011212</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����M����(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SndRcvEndDateTime
        {
            get { return _sndRcvEndDateTime; }
            set { _sndRcvEndDateTime = value; }
        }


        /// <summary>
        /// ����M�����e�[�u���f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SndRcvHisConWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SndRcvHisConWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SndRcvHisConWork()
        {
        }

    }

    }
