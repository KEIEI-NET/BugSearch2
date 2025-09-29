//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �D�ǃf�[�^�폜����
// �v���O�����T�v   : �D�ǃf�[�^�폜����
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : ���X��
// �� �� ��  2011/07/15  �C�����e : �A��No.2 �V�K�쐬                      
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11100068-00 �쐬�S�� : ���t
// �C �� ��  2015/06/08  �C�����e : REDMINE#45792�̑Ή�"���i�}�X�^�폜" �Ɠ�����
//                                  �|���}�X�^�́A�폜����E�폜���Ȃ��𐧌�ł���悤�ɏC������B
//----------------------------------------------------------------------------//
//****************************************************************************//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   DeleteConditionWork
    /// <summary>
    ///                      �폜�f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �폜�f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2011/7/15</br>
    /// <br>Genarated Date   :   2011/07/16  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class DeleteConditionWork : IFileHeader
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

        /// <summary>�폜�敪</summary>
        private Int32 _deleteCode;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCode;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_����</summary>
        private string _sectionName = "";

        /// <summary>�R�[�h1</summary>
        private Int32 _code1;

        /// <summary>�R�[�h2</summary>
        private Int32 _code2;

        /// <summary>�R�[�h3</summary>
        private Int32 _code3;

        /// <summary>�R�[�h4</summary>
        private Int32 _code4;

        /// <summary>���i�폜�敪</summary>
        private Int32 _goodsDeleteCode;

        /// <summary>�����폜�敪</summary>
        private Int32 _joinDeleteCode;

        /// <summary>�|���폜�敪</summary>
        private Int32 _rateDeleteCode; // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��

        /// <summary>���i�폜����</summary>
        private Int32 _goodsDeleteCnt;

        /// <summary>�����폜����</summary>
        private Int32 _joinDeleteCnt;

        /// <summary>�݌ɍ폜����</summary>
        private Int32 _stockDeleteCnt;

        /// <summary>�|���폜����</summary>
        private Int32 _rateDeleteCnt; // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��

        /// <summary>���i���폜����</summary>
        private Int32 _goodsNotDeleteCnt;

        /// <summary>�������폜����</summary>
        private Int32 _joinNotDeleteCnt;

        /// <summary>�݌ɖ��폜����</summary>
        private Int32 _stockNotDeleteCnt;

        /// <summary>�|�����폜����</summary>
        private Int32 _rateNotDeleteCnt; // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��

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

        /// public propaty name  :  DeleteCode
        /// <summary>�폜�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeleteCode
        {
            get { return _deleteCode; }
            set { _deleteCode = value; }
        }

        /// public propaty name  :  GoodsMakerCode
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCode
        {
            get { return _goodsMakerCode; }
            set { _goodsMakerCode = value; }
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

        /// public propaty name  :  SectionName
        /// <summary>���_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  Code1
        /// <summary>�R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Code1
        {
            get { return _code1; }
            set { _code1 = value; }
        }

        /// public propaty name  :  Code2
        /// <summary>�R�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Code2
        {
            get { return _code2; }
            set { _code2 = value; }
        }

        /// public propaty name  :  Code3
        /// <summary>�R�[�h3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Code3
        {
            get { return _code3; }
            set { _code3 = value; }
        }

        /// public propaty name  :  Code4
        /// <summary>�R�[�h4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R�[�h4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Code4
        {
            get { return _code4; }
            set { _code4 = value; }
        }

        /// public propaty name  :  GoodsDeleteCode
        /// <summary>���i�폜�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsDeleteCode
        {
            get { return _goodsDeleteCode; }
            set { _goodsDeleteCode = value; }
        }

        /// public propaty name  :  JoinDeleteCode
        /// <summary>�����폜�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinDeleteCode
        {
            get { return _joinDeleteCode; }
            set { _joinDeleteCode = value; }
        }

        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ---->>>>>
        /// public propaty name  :  RateDeleteCode
        /// <value>�|���폜�敪�v���p�e�B�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateDeleteCode
        {
            get { return _rateDeleteCode; }
            set { _rateDeleteCode = value; }
        }
        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----<<<<<

        /// public propaty name  :  GoodsDeleteCnt
        /// <summary>���i�폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsDeleteCnt
        {
            get { return _goodsDeleteCnt; }
            set { _goodsDeleteCnt = value; }
        }

        /// public propaty name  :  JoinDeleteCnt
        /// <summary>�����폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinDeleteCnt
        {
            get { return _joinDeleteCnt; }
            set { _joinDeleteCnt = value; }
        }

        /// public propaty name  :  StockDeleteCnt
        /// <summary>�݌ɍ폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɍ폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDeleteCnt
        {
            get { return _stockDeleteCnt; }
            set { _stockDeleteCnt = value; }
        }

        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ---->>>>>
        /// public propaty name  :  RateDeleteCnt
        /// <summary>�|���폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateDeleteCnt
        {
            get { return _rateDeleteCnt; }
            set { _rateDeleteCnt = value; }
        }
        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----<<<<<

        /// public propaty name  :  GoodsNotDeleteCnt
        /// <summary>���i���폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNotDeleteCnt
        {
            get { return _goodsNotDeleteCnt; }
            set { _goodsNotDeleteCnt = value; }
        }

        /// public propaty name  :  JoinNotDeleteCnt
        /// <summary>�������폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinNotDeleteCnt
        {
            get { return _joinNotDeleteCnt; }
            set { _joinNotDeleteCnt = value; }
        }

        /// public propaty name  :  StockNotDeleteCnt
        /// <summary>�݌ɖ��폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɖ��폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockNotDeleteCnt
        {
            get { return _stockNotDeleteCnt; }
            set { _stockNotDeleteCnt = value; }
        }

        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ---->>>>>
        /// public propaty name  :  RateNotDeleteCnt
        /// <summary>�|�����폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|�����폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateNotDeleteCnt
        {
            get { return _rateNotDeleteCnt; }
            set { _rateNotDeleteCnt = value; }
        }
        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----<<<<<

        /// <summary>
        /// �폜�f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>DeleteConditionWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DeleteConditionWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DeleteConditionWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>DeleteConditionWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   DeleteConditionWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class DeleteConditionWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DeleteConditionWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  DeleteConditionWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is DeleteConditionWork || graph is ArrayList || graph is DeleteConditionWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(DeleteConditionWork).FullName));

            if (graph != null && graph is DeleteConditionWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.DeleteConditionWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is DeleteConditionWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((DeleteConditionWork[])graph).Length;
            }
            else if (graph is DeleteConditionWork)
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
            //�폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DeleteCode
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_����
            serInfo.MemberInfo.Add(typeof(string)); //SectionName
            //�R�[�h1
            serInfo.MemberInfo.Add(typeof(Int32)); //Code1
            //�R�[�h2
            serInfo.MemberInfo.Add(typeof(Int32)); //Code2
            //�R�[�h3
            serInfo.MemberInfo.Add(typeof(Int32)); //Code3
            //�R�[�h4
            serInfo.MemberInfo.Add(typeof(Int32)); //Code4
            //���i�폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsDeleteCode
            //�����폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinDeleteCode
            //�|���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //RateDeleteCode // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
            //���i�폜����
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsDeleteCnt
            //�����폜����
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinDeleteCnt
            //�݌ɍ폜����
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDeleteCnt
            //�|���폜����
            serInfo.MemberInfo.Add(typeof(Int32)); //RateDeleteCnt // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
            //���i���폜����
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsNotDeleteCnt
            //�������폜����
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinNotDeleteCnt
            //�݌ɖ��폜����
            serInfo.MemberInfo.Add(typeof(Int32)); //StockNotDeleteCnt
            //�|�����폜����
            serInfo.MemberInfo.Add(typeof(Int32)); //RateNotDeleteCnt // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��


            serInfo.Serialize(writer, serInfo);
            if (graph is DeleteConditionWork)
            {
                DeleteConditionWork temp = (DeleteConditionWork)graph;

                SetDeleteConditionWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is DeleteConditionWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((DeleteConditionWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (DeleteConditionWork temp in lst)
                {
                    SetDeleteConditionWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// DeleteConditionWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 24; // DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
        private const int currentMemberCount = 27; // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��

        /// <summary>
        ///  DeleteConditionWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DeleteConditionWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetDeleteConditionWork(System.IO.BinaryWriter writer, DeleteConditionWork temp)
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
            //�폜�敪
            writer.Write(temp.DeleteCode);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_����
            writer.Write(temp.SectionName);
            //�R�[�h1
            writer.Write(temp.Code1);
            //�R�[�h2
            writer.Write(temp.Code2);
            //�R�[�h3
            writer.Write(temp.Code3);
            //�R�[�h4
            writer.Write(temp.Code4);
            //���i�폜�敪
            writer.Write(temp.GoodsDeleteCode);
            //�����폜�敪
            writer.Write(temp.JoinDeleteCode);
            //�|���폜�敪
            writer.Write(temp.RateDeleteCode); // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
            //���i�폜����
            writer.Write(temp.GoodsDeleteCnt);
            //�����폜����
            writer.Write(temp.JoinDeleteCnt);
            //�|���폜����
            writer.Write(temp.RateDeleteCnt); // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
            //�݌ɍ폜����
            writer.Write(temp.StockDeleteCnt);
            //���i���폜����
            writer.Write(temp.GoodsNotDeleteCnt);
            //�������폜����
            writer.Write(temp.JoinNotDeleteCnt);
            //�݌ɖ��폜����
            writer.Write(temp.StockNotDeleteCnt);
            //�|�����폜����
            writer.Write(temp.RateNotDeleteCnt); // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��

        }

        /// <summary>
        ///  DeleteConditionWork�C���X�^���X�擾
        /// </summary>
        /// <returns>DeleteConditionWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DeleteConditionWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private DeleteConditionWork GetDeleteConditionWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            DeleteConditionWork temp = new DeleteConditionWork();

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
            //�폜�敪
            temp.DeleteCode = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCode = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_����
            temp.SectionName = reader.ReadString();
            //�R�[�h1
            temp.Code1 = reader.ReadInt32();
            //�R�[�h2
            temp.Code2 = reader.ReadInt32();
            //�R�[�h3
            temp.Code3 = reader.ReadInt32();
            //�R�[�h4
            temp.Code4 = reader.ReadInt32();
            //���i�폜�敪
            temp.GoodsDeleteCode = reader.ReadInt32();
            //�����폜�敪
            temp.JoinDeleteCode = reader.ReadInt32();
            //�|���폜�敪
            temp.RateDeleteCode = reader.ReadInt32(); // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
            //���i�폜����
            temp.GoodsDeleteCnt = reader.ReadInt32();
            //�����폜����
            temp.JoinDeleteCnt = reader.ReadInt32();
            //�݌ɍ폜����
            temp.StockDeleteCnt = reader.ReadInt32();
            //�|���폜����
            temp.RateDeleteCnt = reader.ReadInt32(); // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
            //���i���폜����
            temp.GoodsNotDeleteCnt = reader.ReadInt32();
            //�������폜����
            temp.JoinNotDeleteCnt = reader.ReadInt32();
            //�݌ɖ��폜����
            temp.StockNotDeleteCnt = reader.ReadInt32();
            //�|�����폜����
            temp.RateNotDeleteCnt = reader.ReadInt32(); // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��


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
        /// <returns>DeleteConditionWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DeleteConditionWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                DeleteConditionWork temp = GetDeleteConditionWork(reader, serInfo);
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
                    retValue = (DeleteConditionWork[])lst.ToArray(typeof(DeleteConditionWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
