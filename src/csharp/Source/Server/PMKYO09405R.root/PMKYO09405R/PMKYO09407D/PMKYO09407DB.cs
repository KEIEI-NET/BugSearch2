using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SndRcvEtrWork
    /// <summary>
    ///                      ����M���o�����������O�f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����M���o�����������O�f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2011/7/15</br>
    /// <br>Genarated Date   :   2011/07/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/7/23  �g���Y</br>
    /// <br>                 :   �u�_���폜�敪�v��ǉ��B</br>
    /// <br>                 :   PK�ɍ��ځu11�v��ǉ�</br>
    /// <br>Update Note      :   2011/8/23  ������</br>
    /// <br>                 :   #23826�}�X�^����M�����F������M���ł��Ȃ�</br>
    /// <br>                 :   ����M�������O���M�ԍ��}�Ԃ�Int64����Int32�ɕύX�B</br> 
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SndRcvEtrWork : IFileHeader
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

        /// <summary>����M�������O���M�ԍ�</summary>
        /// <remarks>�ԍ��Ǘ��ݒ�ɂč̔�</remarks>
        private Int32 _sndRcvHisConsNo;

        /// <summary>����M�������O���M�ԍ��}��</summary>
		private Int32 _sndRcvHisConsDerivNo;

        /// <summary>���</summary>
        private Int32 _kind;

        /// <summary>�t�@�C���h�c</summary>
        private string _fileId = "";

        /// <summary>���o�J�n����</summary>
        /// <remarks>DateTime:���x��100�i�m�b</remarks>
        private DateTime _extraStartDate;

        /// <summary>���o�I������</summary>
        /// <remarks>DateTime:���x��100�i�m�b</remarks>
        private DateTime _extraEndDate;

        /// <summary>�J�n����1</summary>
        private string _startCond1 = "";

        /// <summary>�I������1</summary>
        private string _endCond1 = "";

        /// <summary>�J�n����2</summary>
        private string _startCond2 = "";

        /// <summary>�I������2</summary>
        private string _endCond2 = "";

        /// <summary>�J�n����3</summary>
        private string _startCond3 = "";

        /// <summary>�I������3</summary>
        private string _endCond3 = "";

        /// <summary>�J�n����4</summary>
        private string _startCond4 = "";

        /// <summary>�I������4</summary>
        private string _endCond4 = "";

        /// <summary>�J�n����5</summary>
        private string _startCond5 = "";

        /// <summary>�I������5</summary>
        private string _endCond5 = "";

        /// <summary>�J�n����6</summary>
        private string _startCond6 = "";

        /// <summary>�I������6</summary>
        private string _endCond6 = "";

        /// <summary>�J�n����7</summary>
        private string _startCond7 = "";

        /// <summary>�I������7</summary>
        private string _endCond7 = "";

        /// <summary>�J�n����8</summary>
        private string _startCond8 = "";

        /// <summary>�I������8</summary>
        private string _endCond8 = "";

        /// <summary>�J�n����9</summary>
        private string _startCond9 = "";

        /// <summary>�I������9</summary>
        private string _endCond9 = "";

        /// <summary>�J�n����10</summary>
        private string _startCond10 = "";

        /// <summary>�I������10</summary>
        private string _endCond10 = "";


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
        /// <value>�ԍ��Ǘ��ݒ�ɂč̔�</value>
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

        /// public propaty name  :  SndRcvHisConsDerivNo
        /// <summary>����M�������O���M�ԍ��}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����M�������O���M�ԍ��}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
		public Int32 SndRcvHisConsDerivNo
        {
            get { return _sndRcvHisConsDerivNo; }
            set { _sndRcvHisConsDerivNo = value; }
        }

        /// public propaty name  :  Kind
        /// <summary>��ʃv���p�e�B</summary>
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

        /// public propaty name  :  FileId
        /// <summary>�t�@�C���h�c�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C���h�c�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FileId
        {
            get { return _fileId; }
            set { _fileId = value; }
        }

        /// public propaty name  :  ExtraStartDate
        /// <summary>���o�J�n�����v���p�e�B</summary>
        /// <value>DateTime:���x��100�i�m�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�J�n�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ExtraStartDate
        {
            get { return _extraStartDate; }
            set { _extraStartDate = value; }
        }

        /// public propaty name  :  ExtraEndDate
        /// <summary>���o�I�������v���p�e�B</summary>
        /// <value>DateTime:���x��100�i�m�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�I�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ExtraEndDate
        {
            get { return _extraEndDate; }
            set { _extraEndDate = value; }
        }

        /// public propaty name  :  StartCond1
        /// <summary>�J�n����1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StartCond1
        {
            get { return _startCond1; }
            set { _startCond1 = value; }
        }

        /// public propaty name  :  EndCond1
        /// <summary>�I������1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I������1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EndCond1
        {
            get { return _endCond1; }
            set { _endCond1 = value; }
        }

        /// public propaty name  :  StartCond2
        /// <summary>�J�n����2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StartCond2
        {
            get { return _startCond2; }
            set { _startCond2 = value; }
        }

        /// public propaty name  :  EndCond2
        /// <summary>�I������2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I������2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EndCond2
        {
            get { return _endCond2; }
            set { _endCond2 = value; }
        }

        /// public propaty name  :  StartCond3
        /// <summary>�J�n����3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n����3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StartCond3
        {
            get { return _startCond3; }
            set { _startCond3 = value; }
        }

        /// public propaty name  :  EndCond3
        /// <summary>�I������3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I������3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EndCond3
        {
            get { return _endCond3; }
            set { _endCond3 = value; }
        }

        /// public propaty name  :  StartCond4
        /// <summary>�J�n����4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n����4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StartCond4
        {
            get { return _startCond4; }
            set { _startCond4 = value; }
        }

        /// public propaty name  :  EndCond4
        /// <summary>�I������4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I������4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EndCond4
        {
            get { return _endCond4; }
            set { _endCond4 = value; }
        }

        /// public propaty name  :  StartCond5
        /// <summary>�J�n����5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n����5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StartCond5
        {
            get { return _startCond5; }
            set { _startCond5 = value; }
        }

        /// public propaty name  :  EndCond5
        /// <summary>�I������5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I������5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EndCond5
        {
            get { return _endCond5; }
            set { _endCond5 = value; }
        }

        /// public propaty name  :  StartCond6
        /// <summary>�J�n����6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n����6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StartCond6
        {
            get { return _startCond6; }
            set { _startCond6 = value; }
        }

        /// public propaty name  :  EndCond6
        /// <summary>�I������6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I������6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EndCond6
        {
            get { return _endCond6; }
            set { _endCond6 = value; }
        }

        /// public propaty name  :  StartCond7
        /// <summary>�J�n����7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n����7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StartCond7
        {
            get { return _startCond7; }
            set { _startCond7 = value; }
        }

        /// public propaty name  :  EndCond7
        /// <summary>�I������7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I������7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EndCond7
        {
            get { return _endCond7; }
            set { _endCond7 = value; }
        }

        /// public propaty name  :  StartCond8
        /// <summary>�J�n����8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n����8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StartCond8
        {
            get { return _startCond8; }
            set { _startCond8 = value; }
        }

        /// public propaty name  :  EndCond8
        /// <summary>�I������8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I������8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EndCond8
        {
            get { return _endCond8; }
            set { _endCond8 = value; }
        }

        /// public propaty name  :  StartCond9
        /// <summary>�J�n����9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n����9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StartCond9
        {
            get { return _startCond9; }
            set { _startCond9 = value; }
        }

        /// public propaty name  :  EndCond9
        /// <summary>�I������9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I������9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EndCond9
        {
            get { return _endCond9; }
            set { _endCond9 = value; }
        }

        /// public propaty name  :  StartCond10
        /// <summary>�J�n����10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n����10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StartCond10
        {
            get { return _startCond10; }
            set { _startCond10 = value; }
        }

        /// public propaty name  :  EndCond10
        /// <summary>�I������10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I������10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EndCond10
        {
            get { return _endCond10; }
            set { _endCond10 = value; }
        }


        /// <summary>
        /// ����M���o�����������O�f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SndRcvEtrWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SndRcvEtrWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SndRcvEtrWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SndRcvEtrWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SndRcvEtrWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SndRcvEtrWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SndRcvEtrWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SndRcvEtrWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SndRcvEtrWork || graph is ArrayList || graph is SndRcvEtrWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SndRcvEtrWork).FullName));

            if (graph != null && graph is SndRcvEtrWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SndRcvEtrWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SndRcvEtrWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SndRcvEtrWork[])graph).Length;
            }
            else if (graph is SndRcvEtrWork)
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
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //����M�������O���M�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SndRcvHisConsNo
            //����M�������O���M�ԍ��}��
            serInfo.MemberInfo.Add(typeof(Int32)); //SndRcvHisConsDerivNo
            //���
            serInfo.MemberInfo.Add(typeof(Int32)); //Kind
            //�t�@�C���h�c
            serInfo.MemberInfo.Add(typeof(string)); //FileId
            //���o�J�n����
            serInfo.MemberInfo.Add(typeof(Int64)); //ExtraStartDate
            //���o�I������
            serInfo.MemberInfo.Add(typeof(Int64)); //ExtraEndDate
            //�J�n����1
            serInfo.MemberInfo.Add(typeof(string)); //StartCond1
            //�I������1
            serInfo.MemberInfo.Add(typeof(string)); //EndCond1
            //�J�n����2
            serInfo.MemberInfo.Add(typeof(string)); //StartCond2
            //�I������2
            serInfo.MemberInfo.Add(typeof(string)); //EndCond2
            //�J�n����3
            serInfo.MemberInfo.Add(typeof(string)); //StartCond3
            //�I������3
            serInfo.MemberInfo.Add(typeof(string)); //EndCond3
            //�J�n����4
            serInfo.MemberInfo.Add(typeof(string)); //StartCond4
            //�I������4
            serInfo.MemberInfo.Add(typeof(string)); //EndCond4
            //�J�n����5
            serInfo.MemberInfo.Add(typeof(string)); //StartCond5
            //�I������5
            serInfo.MemberInfo.Add(typeof(string)); //EndCond5
            //�J�n����6
            serInfo.MemberInfo.Add(typeof(string)); //StartCond6
            //�I������6
            serInfo.MemberInfo.Add(typeof(string)); //EndCond6
            //�J�n����7
            serInfo.MemberInfo.Add(typeof(string)); //StartCond7
            //�I������7
            serInfo.MemberInfo.Add(typeof(string)); //EndCond7
            //�J�n����8
            serInfo.MemberInfo.Add(typeof(string)); //StartCond8
            //�I������8
            serInfo.MemberInfo.Add(typeof(string)); //EndCond8
            //�J�n����9
            serInfo.MemberInfo.Add(typeof(string)); //StartCond9
            //�I������9
            serInfo.MemberInfo.Add(typeof(string)); //EndCond9
            //�J�n����10
            serInfo.MemberInfo.Add(typeof(string)); //StartCond10
            //�I������10
            serInfo.MemberInfo.Add(typeof(string)); //EndCond10


            serInfo.Serialize(writer, serInfo);
            if (graph is SndRcvEtrWork)
            {
                SndRcvEtrWork temp = (SndRcvEtrWork)graph;

                SetSndRcvEtrWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SndRcvEtrWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SndRcvEtrWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SndRcvEtrWork temp in lst)
                {
                    SetSndRcvEtrWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SndRcvEtrWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 35;

        /// <summary>
        ///  SndRcvEtrWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SndRcvEtrWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSndRcvEtrWork(System.IO.BinaryWriter writer, SndRcvEtrWork temp)
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
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //����M�������O���M�ԍ�
            writer.Write(temp.SndRcvHisConsNo);
            //����M�������O���M�ԍ��}��
            writer.Write(temp.SndRcvHisConsDerivNo);
            //���
            writer.Write(temp.Kind);
            //�t�@�C���h�c
            writer.Write(temp.FileId);
            //���o�J�n����
            writer.Write((Int64)temp.ExtraStartDate.Ticks);
            //���o�I������
            writer.Write((Int64)temp.ExtraEndDate.Ticks);
            //�J�n����1
            writer.Write(temp.StartCond1);
            //�I������1
            writer.Write(temp.EndCond1);
            //�J�n����2
            writer.Write(temp.StartCond2);
            //�I������2
            writer.Write(temp.EndCond2);
            //�J�n����3
            writer.Write(temp.StartCond3);
            //�I������3
            writer.Write(temp.EndCond3);
            //�J�n����4
            writer.Write(temp.StartCond4);
            //�I������4
            writer.Write(temp.EndCond4);
            //�J�n����5
            writer.Write(temp.StartCond5);
            //�I������5
            writer.Write(temp.EndCond5);
            //�J�n����6
            writer.Write(temp.StartCond6);
            //�I������6
            writer.Write(temp.EndCond6);
            //�J�n����7
            writer.Write(temp.StartCond7);
            //�I������7
            writer.Write(temp.EndCond7);
            //�J�n����8
            writer.Write(temp.StartCond8);
            //�I������8
            writer.Write(temp.EndCond8);
            //�J�n����9
            writer.Write(temp.StartCond9);
            //�I������9
            writer.Write(temp.EndCond9);
            //�J�n����10
            writer.Write(temp.StartCond10);
            //�I������10
            writer.Write(temp.EndCond10);

        }

        /// <summary>
        ///  SndRcvEtrWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SndRcvEtrWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SndRcvEtrWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SndRcvEtrWork GetSndRcvEtrWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SndRcvEtrWork temp = new SndRcvEtrWork();

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
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //����M�������O���M�ԍ�
            temp.SndRcvHisConsNo = reader.ReadInt32();
            //����M�������O���M�ԍ��}��
            temp.SndRcvHisConsDerivNo = reader.ReadInt32();
            //���
            temp.Kind = reader.ReadInt32();
            //�t�@�C���h�c
            temp.FileId = reader.ReadString();
            //���o�J�n����
            temp.ExtraStartDate = new DateTime(reader.ReadInt64());
            //���o�I������
            temp.ExtraEndDate = new DateTime(reader.ReadInt64());
            //�J�n����1
            temp.StartCond1 = reader.ReadString();
            //�I������1
            temp.EndCond1 = reader.ReadString();
            //�J�n����2
            temp.StartCond2 = reader.ReadString();
            //�I������2
            temp.EndCond2 = reader.ReadString();
            //�J�n����3
            temp.StartCond3 = reader.ReadString();
            //�I������3
            temp.EndCond3 = reader.ReadString();
            //�J�n����4
            temp.StartCond4 = reader.ReadString();
            //�I������4
            temp.EndCond4 = reader.ReadString();
            //�J�n����5
            temp.StartCond5 = reader.ReadString();
            //�I������5
            temp.EndCond5 = reader.ReadString();
            //�J�n����6
            temp.StartCond6 = reader.ReadString();
            //�I������6
            temp.EndCond6 = reader.ReadString();
            //�J�n����7
            temp.StartCond7 = reader.ReadString();
            //�I������7
            temp.EndCond7 = reader.ReadString();
            //�J�n����8
            temp.StartCond8 = reader.ReadString();
            //�I������8
            temp.EndCond8 = reader.ReadString();
            //�J�n����9
            temp.StartCond9 = reader.ReadString();
            //�I������9
            temp.EndCond9 = reader.ReadString();
            //�J�n����10
            temp.StartCond10 = reader.ReadString();
            //�I������10
            temp.EndCond10 = reader.ReadString();


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
        /// <returns>SndRcvEtrWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SndRcvEtrWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SndRcvEtrWork temp = GetSndRcvEtrWork(reader, serInfo);
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
                    retValue = (SndRcvEtrWork[])lst.ToArray(typeof(SndRcvEtrWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
