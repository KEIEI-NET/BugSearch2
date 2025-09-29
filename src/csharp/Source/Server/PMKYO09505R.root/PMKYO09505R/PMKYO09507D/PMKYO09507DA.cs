//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : DC����M�����@�f�[�^�p�����[�^
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
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Data;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SndRcvHisTableWork
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
    public class SndRcvHisTableWork: IFileHeader
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

        /// <summary>����M���O���p�敪</summary>
        /// <remarks>���O�̗��p�`�� 0:���_�Ǘ�</remarks>
        private Int32 _sndLogUseDiv;

        /// <summary>���o�Ώۋ��_�R�[�h</summary>
        /// <remarks>���M�f�[�^�i�}�X�^�j�̏������鋒�_</remarks>
        private string _extraObjSecCode = "";

        /// <summary>���M�ΏۊJ�n����</summary>
        /// <remarks>DateTime:���x��100�i�m�b</remarks>
        private Int64 _sndObjStartDate;

        /// <summary>���M�ΏۏI������</summary>
        /// <remarks>DateTime:���x��100�i�m�b</remarks>
        private Int64 _sndObjEndDate;

        /// <summary>�V���N���s���t</summary>
        /// <remarks>�ŏI���M��</remarks>
        private Int64 _syncExecDate;

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

        /// public propaty name  :  SndLogUseDiv
        /// <summary>����M���O���p�敪�v���p�e�B</summary>
        /// <value>���O�̗��p�`�� 0:���_�Ǘ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����M���O���p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SndLogUseDiv
        {
            get { return _sndLogUseDiv; }
            set { _sndLogUseDiv = value; }
        }

        /// public propaty name  :  ExtraObjSecCode
        /// <summary>���o�Ώۋ��_�R�[�h�v���p�e�B</summary>
        /// <value>���M�f�[�^�i�}�X�^�j�̏������鋒�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�Ώۋ��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ExtraObjSecCode
        {
            get { return _extraObjSecCode; }
            set { _extraObjSecCode = value; }
        }

        /// public propaty name  :  SndObjStartDate
        /// <summary>���M�ΏۊJ�n�����v���p�e�B</summary>
        /// <value>DateTime:���x��100�i�m�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�ΏۊJ�n�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SndObjStartDate
        {
            get { return _sndObjStartDate; }
            set { _sndObjStartDate = value; }
        }

        /// public propaty name  :  SndObjEndDate
        /// <summary>���M�ΏۏI�������v���p�e�B</summary>
        /// <value>DateTime:���x��100�i�m�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�ΏۏI�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SndObjEndDate
        {
            get { return _sndObjEndDate; }
            set { _sndObjEndDate = value; }
        }

        /// public propaty name  :  SyncExecDate
        /// <summary>�V���N���s���t�v���p�e�B</summary>
        /// <value>�ŏI���M��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���N���s���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SyncExecDate
        {
            get { return _syncExecDate; }
            set { _syncExecDate = value; }
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
        /// <returns>SndRcvHisTableWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SndRcvHisTableWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SndRcvHisTableWork()
        {
        }

    }



    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SndRcvHisTableWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SndRcvHisTableWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SndRcvHisTableWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SndRcvHisTableWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2012/10/16 ������</br>
        ///	<br>			         Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SndRcvHisTableWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SndRcvHisTableWork || graph is ArrayList || graph is SndRcvHisTableWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SndRcvHisTableWork).FullName));

            if (graph != null && graph is SndRcvHisTableWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SndRcvHisTableWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SndRcvHisTableWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SndRcvHisTableWork[])graph).Length;
            }
            else if (graph is SndRcvHisTableWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //����M���𑗎�M�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SndRcvHisSndRcvNo
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //����M�������O���M�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SndRcvHisConsNo
            //����M����
            serInfo.MemberInfo.Add(typeof(Int64)); //SndRcvDateTime
            //����M�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SendOrReceiveDivCd
            //���
            serInfo.MemberInfo.Add(typeof(Int32)); //Kind
            //����M���O���o�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SndLogExtraCondDiv
            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
            ////�����J�n����
            //serInfo.MemberInfo.Add(typeof(Int64)); //ProcStartDateTime
            ////�����I������
            //serInfo.MemberInfo.Add(typeof(Int64)); //ProcEndDateTime
            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
            //���M���ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SendDestEpCode
            //���M�拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SendDestSecCode
            //����M���
            serInfo.MemberInfo.Add(typeof(Int32)); //SndRcvCondition
            //����M�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TempReceiveDiv
            //����M�G���[���e
            serInfo.MemberInfo.Add(typeof(string)); //SndRcvErrContents
            //����M�t�@�C���h�c
            serInfo.MemberInfo.Add(typeof(string)); //SndRcvFileID
            //����M���O���p�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SndLogUseDiv
            //���o�Ώۋ��_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ExtraObjSecCode
            //���M�ΏۊJ�n����
            serInfo.MemberInfo.Add(typeof(Int64)); //SndObjStartDate
            //���M�ΏۏI������
            serInfo.MemberInfo.Add(typeof(Int64)); //SndObjEndDate
            //�V���N���s���t
            serInfo.MemberInfo.Add(typeof(Int64)); //SyncExecDate
            //����M����(�J�n)
            serInfo.MemberInfo.Add(typeof(Int64)); //SndRcvStartDateTime
            //����M����(�I��)
            serInfo.MemberInfo.Add(typeof(Int64)); //SndRcvEndDateTime


            serInfo.Serialize(writer, serInfo);
            if (graph is SndRcvHisTableWork)
            {
                SndRcvHisTableWork temp = (SndRcvHisTableWork)graph;

                SetSndRcvHisTableWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SndRcvHisTableWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SndRcvHisTableWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SndRcvHisTableWork temp in lst)
                {
                    SetSndRcvHisTableWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SndRcvHisTableWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 30;//DEL 2012/10/16 ������ for redmine#31026
        private const int currentMemberCount = 28;//ADD 2012/10/16 ������ for redmine#31026

        /// <summary>
        ///  SndRcvHisTableWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SndRcvHisTableWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2012/10/16 ������</br>
        ///	<br>			         Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        /// </remarks>
        private void SetSndRcvHisTableWork(System.IO.BinaryWriter writer, SndRcvHisTableWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //����M���𑗎�M�ԍ�
            writer.Write(temp.SndRcvHisSndRcvNo);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //����M�������O���M�ԍ�
            writer.Write(temp.SndRcvHisConsNo);
            //����M����
            writer.Write(temp.SndRcvDateTime);
            //����M�敪
            writer.Write(temp.SendOrReceiveDivCd);
            //���
            writer.Write(temp.Kind);
            //����M���O���o�����敪
            writer.Write(temp.SndLogExtraCondDiv);
            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
            ////�����J�n����
            //writer.Write(temp.ProcStartDateTime);
            ////�����I������
            //writer.Write(temp.ProcEndDateTime);
            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
            //���M���ƃR�[�h
            writer.Write(temp.SendDestEpCode);
            //���M�拒�_�R�[�h
            writer.Write(temp.SendDestSecCode);
            //����M���
            writer.Write(temp.SndRcvCondition);
            //����M�敪
            writer.Write(temp.TempReceiveDiv);
            //����M�G���[���e
            writer.Write(temp.SndRcvErrContents);
            //����M�t�@�C���h�c
            writer.Write(temp.SndRcvFileID);
            //����M���O���p�敪
            writer.Write(temp.SndLogUseDiv);
            //���o�Ώۋ��_�R�[�h
            writer.Write(temp.ExtraObjSecCode);
            //���M�ΏۊJ�n����
            writer.Write(temp.SndObjStartDate);
            //���M�ΏۏI������
            writer.Write(temp.SndObjEndDate);
            //�V���N���s���t
            writer.Write(temp.SyncExecDate);
            //����M����(�J�n)
            writer.Write(temp.SndRcvStartDateTime);
            //����M����(�I��)
            writer.Write(temp.SndRcvEndDateTime);

        }

        /// <summary>
        ///  SndRcvHisTableWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SndRcvHisTableWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SndRcvHisTableWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2012/10/16 ������</br>
        ///	<br>			         Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        /// </remarks>
        private SndRcvHisTableWork GetSndRcvHisTableWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SndRcvHisTableWork temp = new SndRcvHisTableWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //����M���𑗎�M�ԍ�
            temp.SndRcvHisSndRcvNo = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //����M�������O���M�ԍ�
            temp.SndRcvHisConsNo = reader.ReadInt32();
            //����M����
            temp.SndRcvDateTime = reader.ReadInt64();
            //����M�敪
            temp.SendOrReceiveDivCd = reader.ReadInt32();
            //���
            temp.Kind = reader.ReadInt32();
            //����M���O���o�����敪
            temp.SndLogExtraCondDiv = reader.ReadInt32();
            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
            ////�����J�n����
            //temp.ProcStartDateTime = reader.ReadInt64();
            ////�����I������
            //temp.ProcEndDateTime = reader.ReadInt64();
            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
            //���M���ƃR�[�h
            temp.SendDestEpCode = reader.ReadString();
            //���M�拒�_�R�[�h
            temp.SendDestSecCode = reader.ReadString();
            //����M���
            temp.SndRcvCondition = reader.ReadInt32();
            //����M�敪
            temp.TempReceiveDiv = reader.ReadInt32();
            //����M�G���[���e
            temp.SndRcvErrContents = reader.ReadString();
            //����M�t�@�C���h�c
            temp.SndRcvFileID = reader.ReadString();
            //����M���O���p�敪
            temp.SndLogUseDiv = reader.ReadInt32();
            //���o�Ώۋ��_�R�[�h
            temp.ExtraObjSecCode = reader.ReadString();
            //���M�ΏۊJ�n����
            temp.SndObjStartDate = reader.ReadInt64();
            //���M�ΏۏI������
            temp.SndObjEndDate = reader.ReadInt64();
            //�V���N���s���t
            temp.SyncExecDate = reader.ReadInt64();
            //����M����(�J�n)
            temp.SndRcvStartDateTime = reader.ReadInt64();
            //����M����(�I��)
            temp.SndRcvEndDateTime = reader.ReadInt64();


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
        /// <returns>SndRcvHisTableWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SndRcvHisTableWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SndRcvHisTableWork temp = GetSndRcvHisTableWork(reader, serInfo);
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
                    retValue = (SndRcvHisTableWork[])lst.ToArray(typeof(SndRcvHisTableWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
