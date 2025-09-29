using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CompanyNmWork
    /// <summary>
    ///                      ���Ж��̃��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ж��̃��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/11</br>
    /// <br>Genarated Date   :   2008/05/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CompanyNmWork : IFileHeader
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

        /// <summary>���Ж��̃R�[�h</summary>
        private Int32 _companyNameCd;

        /// <summary>����PR��</summary>
        private string _companyPr = "";

        /// <summary>���Ж���1</summary>
        private string _companyName1 = "";

        /// <summary>���Ж���2</summary>
        private string _companyName2 = "";

        /// <summary>�X�֔ԍ�</summary>
        private string _postNo = "";

        /// <summary>�Z��1�i�s���{���s��S�E�����E���j</summary>
        private string _address1 = "";

        /// <summary>�Z��3�i�Ԓn�j</summary>
        private string _address3 = "";

        /// <summary>�Z��4�i�A�p�[�g���́j</summary>
        private string _address4 = "";

        /// <summary>���Гd�b�ԍ�1</summary>
        /// <remarks>TEL</remarks>
        private string _companyTelNo1 = "";

        /// <summary>���Гd�b�ԍ�2</summary>
        /// <remarks>TEL2</remarks>
        private string _companyTelNo2 = "";

        /// <summary>���Гd�b�ԍ�3</summary>
        /// <remarks>FAX</remarks>
        private string _companyTelNo3 = "";

        /// <summary>���Гd�b�ԍ��^�C�g��1</summary>
        /// <remarks>TEL</remarks>
        private string _companyTelTitle1 = "";

        /// <summary>���Гd�b�ԍ��^�C�g��2</summary>
        /// <remarks>TEL2</remarks>
        private string _companyTelTitle2 = "";

        /// <summary>���Гd�b�ԍ��^�C�g��3</summary>
        /// <remarks>FAX</remarks>
        private string _companyTelTitle3 = "";

        /// <summary>��s�U���ē���</summary>
        private string _transferGuidance = "";

        /// <summary>��s����1</summary>
        private string _accountNoInfo1 = "";

        /// <summary>��s����2</summary>
        private string _accountNoInfo2 = "";

        /// <summary>��s����3</summary>
        private string _accountNoInfo3 = "";

        /// <summary>���Аݒ�E�v1</summary>
        private string _companySetNote1 = "";

        /// <summary>���Аݒ�E�v2</summary>
        private string _companySetNote2 = "";

        /// <summary>�摜���敪</summary>
        /// <remarks>10:���Љ摜,20:POS�Ŏg�p����摜</remarks>
        private Int32 _imageInfoDiv;

        /// <summary>�摜���R�[�h</summary>
        private Int32 _imageInfoCode;

        /// <summary>����URL</summary>
        private string _companyUrl = "";

        /// <summary>����PR��2</summary>
        /// <remarks>��\����𓙂̏������</remarks>
        private string _companyPrSentence2 = "";

        /// <summary>�摜�󎚗p�R�����g1</summary>
        /// <remarks>�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j</remarks>
        private string _imageCommentForPrt1 = "";

        /// <summary>�摜�󎚗p�R�����g2</summary>
        /// <remarks>�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j</remarks>
        private string _imageCommentForPrt2 = "";


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

        /// public propaty name  :  CompanyNameCd
        /// <summary>���Ж��̃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CompanyNameCd
        {
            get { return _companyNameCd; }
            set { _companyNameCd = value; }
        }

        /// public propaty name  :  CompanyPr
        /// <summary>����PR���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����PR���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyPr
        {
            get { return _companyPr; }
            set { _companyPr = value; }
        }

        /// public propaty name  :  CompanyName1
        /// <summary>���Ж���1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyName1
        {
            get { return _companyName1; }
            set { _companyName1 = value; }
        }

        /// public propaty name  :  CompanyName2
        /// <summary>���Ж���2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyName2
        {
            get { return _companyName2; }
            set { _companyName2 = value; }
        }

        /// public propaty name  :  PostNo
        /// <summary>�X�֔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PostNo
        {
            get { return _postNo; }
            set { _postNo = value; }
        }

        /// public propaty name  :  Address1
        /// <summary>�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        /// public propaty name  :  Address3
        /// <summary>�Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address3
        {
            get { return _address3; }
            set { _address3 = value; }
        }

        /// public propaty name  :  Address4
        /// <summary>�Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address4
        {
            get { return _address4; }
            set { _address4 = value; }
        }

        /// public propaty name  :  CompanyTelNo1
        /// <summary>���Гd�b�ԍ�1�v���p�e�B</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyTelNo1
        {
            get { return _companyTelNo1; }
            set { _companyTelNo1 = value; }
        }

        /// public propaty name  :  CompanyTelNo2
        /// <summary>���Гd�b�ԍ�2�v���p�e�B</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyTelNo2
        {
            get { return _companyTelNo2; }
            set { _companyTelNo2 = value; }
        }

        /// public propaty name  :  CompanyTelNo3
        /// <summary>���Гd�b�ԍ�3�v���p�e�B</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyTelNo3
        {
            get { return _companyTelNo3; }
            set { _companyTelNo3 = value; }
        }

        /// public propaty name  :  CompanyTelTitle1
        /// <summary>���Гd�b�ԍ��^�C�g��1�v���p�e�B</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyTelTitle1
        {
            get { return _companyTelTitle1; }
            set { _companyTelTitle1 = value; }
        }

        /// public propaty name  :  CompanyTelTitle2
        /// <summary>���Гd�b�ԍ��^�C�g��2�v���p�e�B</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyTelTitle2
        {
            get { return _companyTelTitle2; }
            set { _companyTelTitle2 = value; }
        }

        /// public propaty name  :  CompanyTelTitle3
        /// <summary>���Гd�b�ԍ��^�C�g��3�v���p�e�B</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyTelTitle3
        {
            get { return _companyTelTitle3; }
            set { _companyTelTitle3 = value; }
        }

        /// public propaty name  :  TransferGuidance
        /// <summary>��s�U���ē����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s�U���ē����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TransferGuidance
        {
            get { return _transferGuidance; }
            set { _transferGuidance = value; }
        }

        /// public propaty name  :  AccountNoInfo1
        /// <summary>��s����1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AccountNoInfo1
        {
            get { return _accountNoInfo1; }
            set { _accountNoInfo1 = value; }
        }

        /// public propaty name  :  AccountNoInfo2
        /// <summary>��s����2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AccountNoInfo2
        {
            get { return _accountNoInfo2; }
            set { _accountNoInfo2 = value; }
        }

        /// public propaty name  :  AccountNoInfo3
        /// <summary>��s����3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s����3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AccountNoInfo3
        {
            get { return _accountNoInfo3; }
            set { _accountNoInfo3 = value; }
        }

        /// public propaty name  :  CompanySetNote1
        /// <summary>���Аݒ�E�v1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Аݒ�E�v1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanySetNote1
        {
            get { return _companySetNote1; }
            set { _companySetNote1 = value; }
        }

        /// public propaty name  :  CompanySetNote2
        /// <summary>���Аݒ�E�v2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Аݒ�E�v2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanySetNote2
        {
            get { return _companySetNote2; }
            set { _companySetNote2 = value; }
        }

        /// public propaty name  :  ImageInfoDiv
        /// <summary>�摜���敪�v���p�e�B</summary>
        /// <value>10:���Љ摜,20:POS�Ŏg�p����摜</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �摜���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ImageInfoDiv
        {
            get { return _imageInfoDiv; }
            set { _imageInfoDiv = value; }
        }

        /// public propaty name  :  ImageInfoCode
        /// <summary>�摜���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �摜���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ImageInfoCode
        {
            get { return _imageInfoCode; }
            set { _imageInfoCode = value; }
        }

        /// public propaty name  :  CompanyUrl
        /// <summary>����URL�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����URL�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyUrl
        {
            get { return _companyUrl; }
            set { _companyUrl = value; }
        }

        /// public propaty name  :  CompanyPrSentence2
        /// <summary>����PR��2�v���p�e�B</summary>
        /// <value>��\����𓙂̏������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����PR��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyPrSentence2
        {
            get { return _companyPrSentence2; }
            set { _companyPrSentence2 = value; }
        }

        /// public propaty name  :  ImageCommentForPrt1
        /// <summary>�摜�󎚗p�R�����g1�v���p�e�B</summary>
        /// <value>�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �摜�󎚗p�R�����g1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ImageCommentForPrt1
        {
            get { return _imageCommentForPrt1; }
            set { _imageCommentForPrt1 = value; }
        }

        /// public propaty name  :  ImageCommentForPrt2
        /// <summary>�摜�󎚗p�R�����g2�v���p�e�B</summary>
        /// <value>�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �摜�󎚗p�R�����g2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ImageCommentForPrt2
        {
            get { return _imageCommentForPrt2; }
            set { _imageCommentForPrt2 = value; }
        }


        /// <summary>
        /// ���Ж��̃��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CompanyNmWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CompanyNmWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CompanyNmWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CompanyNmWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CompanyNmWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class CompanyNmWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CompanyNmWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CompanyNmWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CompanyNmWork || graph is ArrayList || graph is CompanyNmWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(CompanyNmWork).FullName));

            if (graph != null && graph is CompanyNmWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CompanyNmWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CompanyNmWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CompanyNmWork[])graph).Length;
            }
            else if (graph is CompanyNmWork)
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
            //���Ж��̃R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CompanyNameCd
            //����PR��
            serInfo.MemberInfo.Add(typeof(string)); //CompanyPr
            //���Ж���1
            serInfo.MemberInfo.Add(typeof(string)); //CompanyName1
            //���Ж���2
            serInfo.MemberInfo.Add(typeof(string)); //CompanyName2
            //�X�֔ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PostNo
            //�Z��1�i�s���{���s��S�E�����E���j
            serInfo.MemberInfo.Add(typeof(string)); //Address1
            //�Z��3�i�Ԓn�j
            serInfo.MemberInfo.Add(typeof(string)); //Address3
            //�Z��4�i�A�p�[�g���́j
            serInfo.MemberInfo.Add(typeof(string)); //Address4
            //���Гd�b�ԍ�1
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelNo1
            //���Гd�b�ԍ�2
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelNo2
            //���Гd�b�ԍ�3
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelNo3
            //���Гd�b�ԍ��^�C�g��1
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelTitle1
            //���Гd�b�ԍ��^�C�g��2
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelTitle2
            //���Гd�b�ԍ��^�C�g��3
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelTitle3
            //��s�U���ē���
            serInfo.MemberInfo.Add(typeof(string)); //TransferGuidance
            //��s����1
            serInfo.MemberInfo.Add(typeof(string)); //AccountNoInfo1
            //��s����2
            serInfo.MemberInfo.Add(typeof(string)); //AccountNoInfo2
            //��s����3
            serInfo.MemberInfo.Add(typeof(string)); //AccountNoInfo3
            //���Аݒ�E�v1
            serInfo.MemberInfo.Add(typeof(string)); //CompanySetNote1
            //���Аݒ�E�v2
            serInfo.MemberInfo.Add(typeof(string)); //CompanySetNote2
            //�摜���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ImageInfoDiv
            //�摜���R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ImageInfoCode
            //����URL
            serInfo.MemberInfo.Add(typeof(string)); //CompanyUrl
            //����PR��2
            serInfo.MemberInfo.Add(typeof(string)); //CompanyPrSentence2
            //�摜�󎚗p�R�����g1
            serInfo.MemberInfo.Add(typeof(string)); //ImageCommentForPrt1
            //�摜�󎚗p�R�����g2
            serInfo.MemberInfo.Add(typeof(string)); //ImageCommentForPrt2


            serInfo.Serialize(writer, serInfo);
            if (graph is CompanyNmWork)
            {
                CompanyNmWork temp = (CompanyNmWork)graph;

                SetCompanyNmWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CompanyNmWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CompanyNmWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CompanyNmWork temp in lst)
                {
                    SetCompanyNmWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CompanyNmWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 35;

        /// <summary>
        ///  CompanyNmWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CompanyNmWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetCompanyNmWork(System.IO.BinaryWriter writer, CompanyNmWork temp)
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
            //���Ж��̃R�[�h
            writer.Write(temp.CompanyNameCd);
            //����PR��
            writer.Write(temp.CompanyPr);
            //���Ж���1
            writer.Write(temp.CompanyName1);
            //���Ж���2
            writer.Write(temp.CompanyName2);
            //�X�֔ԍ�
            writer.Write(temp.PostNo);
            //�Z��1�i�s���{���s��S�E�����E���j
            writer.Write(temp.Address1);
            //�Z��3�i�Ԓn�j
            writer.Write(temp.Address3);
            //�Z��4�i�A�p�[�g���́j
            writer.Write(temp.Address4);
            //���Гd�b�ԍ�1
            writer.Write(temp.CompanyTelNo1);
            //���Гd�b�ԍ�2
            writer.Write(temp.CompanyTelNo2);
            //���Гd�b�ԍ�3
            writer.Write(temp.CompanyTelNo3);
            //���Гd�b�ԍ��^�C�g��1
            writer.Write(temp.CompanyTelTitle1);
            //���Гd�b�ԍ��^�C�g��2
            writer.Write(temp.CompanyTelTitle2);
            //���Гd�b�ԍ��^�C�g��3
            writer.Write(temp.CompanyTelTitle3);
            //��s�U���ē���
            writer.Write(temp.TransferGuidance);
            //��s����1
            writer.Write(temp.AccountNoInfo1);
            //��s����2
            writer.Write(temp.AccountNoInfo2);
            //��s����3
            writer.Write(temp.AccountNoInfo3);
            //���Аݒ�E�v1
            writer.Write(temp.CompanySetNote1);
            //���Аݒ�E�v2
            writer.Write(temp.CompanySetNote2);
            //�摜���敪
            writer.Write(temp.ImageInfoDiv);
            //�摜���R�[�h
            writer.Write(temp.ImageInfoCode);
            //����URL
            writer.Write(temp.CompanyUrl);
            //����PR��2
            writer.Write(temp.CompanyPrSentence2);
            //�摜�󎚗p�R�����g1
            writer.Write(temp.ImageCommentForPrt1);
            //�摜�󎚗p�R�����g2
            writer.Write(temp.ImageCommentForPrt2);

        }

        /// <summary>
        ///  CompanyNmWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CompanyNmWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CompanyNmWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private CompanyNmWork GetCompanyNmWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            CompanyNmWork temp = new CompanyNmWork();

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
            //���Ж��̃R�[�h
            temp.CompanyNameCd = reader.ReadInt32();
            //����PR��
            temp.CompanyPr = reader.ReadString();
            //���Ж���1
            temp.CompanyName1 = reader.ReadString();
            //���Ж���2
            temp.CompanyName2 = reader.ReadString();
            //�X�֔ԍ�
            temp.PostNo = reader.ReadString();
            //�Z��1�i�s���{���s��S�E�����E���j
            temp.Address1 = reader.ReadString();
            //�Z��3�i�Ԓn�j
            temp.Address3 = reader.ReadString();
            //�Z��4�i�A�p�[�g���́j
            temp.Address4 = reader.ReadString();
            //���Гd�b�ԍ�1
            temp.CompanyTelNo1 = reader.ReadString();
            //���Гd�b�ԍ�2
            temp.CompanyTelNo2 = reader.ReadString();
            //���Гd�b�ԍ�3
            temp.CompanyTelNo3 = reader.ReadString();
            //���Гd�b�ԍ��^�C�g��1
            temp.CompanyTelTitle1 = reader.ReadString();
            //���Гd�b�ԍ��^�C�g��2
            temp.CompanyTelTitle2 = reader.ReadString();
            //���Гd�b�ԍ��^�C�g��3
            temp.CompanyTelTitle3 = reader.ReadString();
            //��s�U���ē���
            temp.TransferGuidance = reader.ReadString();
            //��s����1
            temp.AccountNoInfo1 = reader.ReadString();
            //��s����2
            temp.AccountNoInfo2 = reader.ReadString();
            //��s����3
            temp.AccountNoInfo3 = reader.ReadString();
            //���Аݒ�E�v1
            temp.CompanySetNote1 = reader.ReadString();
            //���Аݒ�E�v2
            temp.CompanySetNote2 = reader.ReadString();
            //�摜���敪
            temp.ImageInfoDiv = reader.ReadInt32();
            //�摜���R�[�h
            temp.ImageInfoCode = reader.ReadInt32();
            //����URL
            temp.CompanyUrl = reader.ReadString();
            //����PR��2
            temp.CompanyPrSentence2 = reader.ReadString();
            //�摜�󎚗p�R�����g1
            temp.ImageCommentForPrt1 = reader.ReadString();
            //�摜�󎚗p�R�����g2
            temp.ImageCommentForPrt2 = reader.ReadString();


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
        /// <returns>CompanyNmWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CompanyNmWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CompanyNmWork temp = GetCompanyNmWork(reader, serInfo);
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
                    retValue = (CompanyNmWork[])lst.ToArray(typeof(CompanyNmWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
