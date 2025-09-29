//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   �}�X�^����M���o�E�X�VDB����N���X              //
//                  :   PMKYO06121D.DLL                                 //
// Name Space       :   Broadleaf.Application.Remoting.ParamData        //
// Programmer       :   ������                                          //
// Date             :   2009.04.28                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   APEmployeeWork
    /// <summary>
    ///                      �]�ƈ����[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �]�ƈ����[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/17</br>
    /// <br>Genarated Date   :   2009/04/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class APEmployeeWork : IFileHeader
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

        /// <summary>�]�ƈ��R�[�h</summary>
        private string _employeeCode = "";

        /// <summary>����</summary>
        private string _name = "";

        /// <summary>�J�i</summary>
        private string _kana = "";

        /// <summary>�Z�k����</summary>
        private string _shortName = "";

        /// <summary>���ʃR�[�h</summary>
        /// <remarks>0:�j,1:��,2:�s��</remarks>
        private Int32 _sexCode;

        /// <summary>���ʖ���</summary>
        /// <remarks>�S�p�ŊǗ�</remarks>
        private string _sexName = "";

        /// <summary>���N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _birthday;

        /// <summary>�d�b�ԍ��i��Ёj</summary>
        private string _companyTelNo = "";

        /// <summary>�d�b�ԍ��i�g�сj</summary>
        private string _portableTelNo = "";

        /// <summary>��E�R�[�h</summary>
        private Int32 _postCode;

        /// <summary>�Ɩ��敪</summary>
        private Int32 _businessCode;

        /// <summary>��t�E���J�敪</summary>
        /// <remarks>0:��t,1:���J,2:�c��</remarks>
        private Int32 _frontMechaCode;

        /// <summary>�Г��O�敪</summary>
        /// <remarks>0:�Г�,1:�ЊO</remarks>
        private Int32 _inOutsideCompanyCode;

        /// <summary>�������_�R�[�h</summary>
        private string _belongSectionCode = "";

        /// <summary>���o���[�g�����i��ʁj</summary>
        private Int64 _lvrRtCstGeneral;

        /// <summary>���o���[�g�����i�Ԍ��j</summary>
        private Int64 _lvrRtCstCarInspect;

        /// <summary>���o���[�g�����i�h���j</summary>
        private Int64 _lvrRtCstBodyPaint;

        /// <summary>���o���[�g�����i����j</summary>
        private Int64 _lvrRtCstBodyRepair;

        /// <summary>���O�C��ID</summary>
        private string _loginId = "";

        /// <summary>���O�C���p�X���[�h</summary>
        private string _loginPassword = "";

        /// <summary>���[�U�[�Ǘ��҃t���O</summary>
        /// <remarks>0:���,1:���[�U�[�Ǘ���</remarks>
        private Int32 _userAdminFlag;

        /// <summary>���Г�</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _enterCompanyDate;

        /// <summary>�ސE��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _retirementDate;

        /// <summary>�������x��1</summary>
        /// <remarks>80:�X�� 70:�X���̔���(���Ј�) 60:�X���̔���(�A���o�C�g) 40:�o�b�N���[�h�S���� 20:����</remarks>
        private Int32 _authorityLevel1;

        /// <summary>�������x��2</summary>
        /// <remarks>50:���Ј� 10:�A���o�C�g</remarks>
        private Int32 _authorityLevel2;


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

        /// public propaty name  :  EmployeeCode
        /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  Name
        /// <summary>���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// public propaty name  :  Kana
        /// <summary>�J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Kana
        {
            get { return _kana; }
            set { _kana = value; }
        }

        /// public propaty name  :  ShortName
        /// <summary>�Z�k���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�k���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShortName
        {
            get { return _shortName; }
            set { _shortName = value; }
        }

        /// public propaty name  :  SexCode
        /// <summary>���ʃR�[�h�v���p�e�B</summary>
        /// <value>0:�j,1:��,2:�s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SexCode
        {
            get { return _sexCode; }
            set { _sexCode = value; }
        }

        /// public propaty name  :  SexName
        /// <summary>���ʖ��̃v���p�e�B</summary>
        /// <value>�S�p�ŊǗ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SexName
        {
            get { return _sexName; }
            set { _sexName = value; }
        }

        /// public propaty name  :  Birthday
        /// <summary>���N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        /// public propaty name  :  CompanyTelNo
        /// <summary>�d�b�ԍ��i��Ёj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i��Ёj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyTelNo
        {
            get { return _companyTelNo; }
            set { _companyTelNo = value; }
        }

        /// public propaty name  :  PortableTelNo
        /// <summary>�d�b�ԍ��i�g�сj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i�g�сj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PortableTelNo
        {
            get { return _portableTelNo; }
            set { _portableTelNo = value; }
        }

        /// public propaty name  :  PostCode
        /// <summary>��E�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��E�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PostCode
        {
            get { return _postCode; }
            set { _postCode = value; }
        }

        /// public propaty name  :  BusinessCode
        /// <summary>�Ɩ��敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ɩ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessCode
        {
            get { return _businessCode; }
            set { _businessCode = value; }
        }

        /// public propaty name  :  FrontMechaCode
        /// <summary>��t�E���J�敪�v���p�e�B</summary>
        /// <value>0:��t,1:���J,2:�c��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�E���J�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FrontMechaCode
        {
            get { return _frontMechaCode; }
            set { _frontMechaCode = value; }
        }

        /// public propaty name  :  InOutsideCompanyCode
        /// <summary>�Г��O�敪�v���p�e�B</summary>
        /// <value>0:�Г�,1:�ЊO</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Г��O�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InOutsideCompanyCode
        {
            get { return _inOutsideCompanyCode; }
            set { _inOutsideCompanyCode = value; }
        }

        /// public propaty name  :  BelongSectionCode
        /// <summary>�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BelongSectionCode
        {
            get { return _belongSectionCode; }
            set { _belongSectionCode = value; }
        }

        /// public propaty name  :  LvrRtCstGeneral
        /// <summary>���o���[�g�����i��ʁj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o���[�g�����i��ʁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 LvrRtCstGeneral
        {
            get { return _lvrRtCstGeneral; }
            set { _lvrRtCstGeneral = value; }
        }

        /// public propaty name  :  LvrRtCstCarInspect
        /// <summary>���o���[�g�����i�Ԍ��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o���[�g�����i�Ԍ��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 LvrRtCstCarInspect
        {
            get { return _lvrRtCstCarInspect; }
            set { _lvrRtCstCarInspect = value; }
        }

        /// public propaty name  :  LvrRtCstBodyPaint
        /// <summary>���o���[�g�����i�h���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o���[�g�����i�h���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 LvrRtCstBodyPaint
        {
            get { return _lvrRtCstBodyPaint; }
            set { _lvrRtCstBodyPaint = value; }
        }

        /// public propaty name  :  LvrRtCstBodyRepair
        /// <summary>���o���[�g�����i����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o���[�g�����i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 LvrRtCstBodyRepair
        {
            get { return _lvrRtCstBodyRepair; }
            set { _lvrRtCstBodyRepair = value; }
        }

        /// public propaty name  :  LoginId
        /// <summary>���O�C��ID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�C��ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LoginId
        {
            get { return _loginId; }
            set { _loginId = value; }
        }

        /// public propaty name  :  LoginPassword
        /// <summary>���O�C���p�X���[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�C���p�X���[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LoginPassword
        {
            get { return _loginPassword; }
            set { _loginPassword = value; }
        }

        /// public propaty name  :  UserAdminFlag
        /// <summary>���[�U�[�Ǘ��҃t���O�v���p�e�B</summary>
        /// <value>0:���,1:���[�U�[�Ǘ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[�Ǘ��҃t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UserAdminFlag
        {
            get { return _userAdminFlag; }
            set { _userAdminFlag = value; }
        }

        /// public propaty name  :  EnterCompanyDate
        /// <summary>���Г��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Г��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime EnterCompanyDate
        {
            get { return _enterCompanyDate; }
            set { _enterCompanyDate = value; }
        }

        /// public propaty name  :  RetirementDate
        /// <summary>�ސE���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ސE���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime RetirementDate
        {
            get { return _retirementDate; }
            set { _retirementDate = value; }
        }

        /// public propaty name  :  AuthorityLevel1
        /// <summary>�������x��1�v���p�e�B</summary>
        /// <value>80:�X�� 70:�X���̔���(���Ј�) 60:�X���̔���(�A���o�C�g) 40:�o�b�N���[�h�S���� 20:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������x��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AuthorityLevel1
        {
            get { return _authorityLevel1; }
            set { _authorityLevel1 = value; }
        }

        /// public propaty name  :  AuthorityLevel2
        /// <summary>�������x��2�v���p�e�B</summary>
        /// <value>50:���Ј� 10:�A���o�C�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������x��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AuthorityLevel2
        {
            get { return _authorityLevel2; }
            set { _authorityLevel2 = value; }
        }


        /// <summary>
        /// �]�ƈ����[�N�R���X�g���N�^
        /// </summary>
        /// <returns>EmployeeWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public APEmployeeWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>EmployeeWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   EmployeeWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class APEmployeeWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  EmployeeWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is APEmployeeWork || graph is ArrayList || graph is APEmployeeWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(APEmployeeWork).FullName));

            if (graph != null && graph is APEmployeeWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.EmployeeWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is APEmployeeWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((APEmployeeWork[])graph).Length;
            }
            else if (graph is APEmployeeWork)
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
            //�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //����
            serInfo.MemberInfo.Add(typeof(string)); //Name
            //�J�i
            serInfo.MemberInfo.Add(typeof(string)); //Kana
            //�Z�k����
            serInfo.MemberInfo.Add(typeof(string)); //ShortName
            //���ʃR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SexCode
            //���ʖ���
            serInfo.MemberInfo.Add(typeof(string)); //SexName
            //���N����
            serInfo.MemberInfo.Add(typeof(Int32)); //Birthday
            //�d�b�ԍ��i��Ёj
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelNo
            //�d�b�ԍ��i�g�сj
            serInfo.MemberInfo.Add(typeof(string)); //PortableTelNo
            //��E�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PostCode
            //�Ɩ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessCode
            //��t�E���J�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //FrontMechaCode
            //�Г��O�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //InOutsideCompanyCode
            //�������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BelongSectionCode
            //���o���[�g�����i��ʁj
            serInfo.MemberInfo.Add(typeof(Int64)); //LvrRtCstGeneral
            //���o���[�g�����i�Ԍ��j
            serInfo.MemberInfo.Add(typeof(Int64)); //LvrRtCstCarInspect
            //���o���[�g�����i�h���j
            serInfo.MemberInfo.Add(typeof(Int64)); //LvrRtCstBodyPaint
            //���o���[�g�����i����j
            serInfo.MemberInfo.Add(typeof(Int64)); //LvrRtCstBodyRepair
            //���O�C��ID
            serInfo.MemberInfo.Add(typeof(string)); //LoginId
            //���O�C���p�X���[�h
            serInfo.MemberInfo.Add(typeof(string)); //LoginPassword
            //���[�U�[�Ǘ��҃t���O
            serInfo.MemberInfo.Add(typeof(Int32)); //UserAdminFlag
            //���Г�
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterCompanyDate
            //�ސE��
            serInfo.MemberInfo.Add(typeof(Int32)); //RetirementDate
            //�������x��1
            serInfo.MemberInfo.Add(typeof(Int32)); //AuthorityLevel1
            //�������x��2
            serInfo.MemberInfo.Add(typeof(Int32)); //AuthorityLevel2


            serInfo.Serialize(writer, serInfo);
            if (graph is APEmployeeWork)
            {
                APEmployeeWork temp = (APEmployeeWork)graph;

                SetEmployeeWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is APEmployeeWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((APEmployeeWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (APEmployeeWork temp in lst)
                {
                    SetEmployeeWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// EmployeeWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 33;

        /// <summary>
        ///  EmployeeWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetEmployeeWork(System.IO.BinaryWriter writer, APEmployeeWork temp)
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
            //�]�ƈ��R�[�h
            writer.Write(temp.EmployeeCode);
            //����
            writer.Write(temp.Name);
            //�J�i
            writer.Write(temp.Kana);
            //�Z�k����
            writer.Write(temp.ShortName);
            //���ʃR�[�h
            writer.Write(temp.SexCode);
            //���ʖ���
            writer.Write(temp.SexName);
            //���N����
            writer.Write((Int64)temp.Birthday.Ticks);
            //�d�b�ԍ��i��Ёj
            writer.Write(temp.CompanyTelNo);
            //�d�b�ԍ��i�g�сj
            writer.Write(temp.PortableTelNo);
            //��E�R�[�h
            writer.Write(temp.PostCode);
            //�Ɩ��敪
            writer.Write(temp.BusinessCode);
            //��t�E���J�敪
            writer.Write(temp.FrontMechaCode);
            //�Г��O�敪
            writer.Write(temp.InOutsideCompanyCode);
            //�������_�R�[�h
            writer.Write(temp.BelongSectionCode);
            //���o���[�g�����i��ʁj
            writer.Write(temp.LvrRtCstGeneral);
            //���o���[�g�����i�Ԍ��j
            writer.Write(temp.LvrRtCstCarInspect);
            //���o���[�g�����i�h���j
            writer.Write(temp.LvrRtCstBodyPaint);
            //���o���[�g�����i����j
            writer.Write(temp.LvrRtCstBodyRepair);
            //���O�C��ID
            writer.Write(temp.LoginId);
            //���O�C���p�X���[�h
            writer.Write(temp.LoginPassword);
            //���[�U�[�Ǘ��҃t���O
            writer.Write(temp.UserAdminFlag);
            //���Г�
            writer.Write((Int64)temp.EnterCompanyDate.Ticks);
            //�ސE��
            writer.Write((Int64)temp.RetirementDate.Ticks);
            //�������x��1
            writer.Write(temp.AuthorityLevel1);
            //�������x��2
            writer.Write(temp.AuthorityLevel2);

        }

        /// <summary>
        ///  EmployeeWork�C���X�^���X�擾
        /// </summary>
        /// <returns>EmployeeWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private APEmployeeWork GetEmployeeWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            APEmployeeWork temp = new APEmployeeWork();

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
            //�]�ƈ��R�[�h
            temp.EmployeeCode = reader.ReadString();
            //����
            temp.Name = reader.ReadString();
            //�J�i
            temp.Kana = reader.ReadString();
            //�Z�k����
            temp.ShortName = reader.ReadString();
            //���ʃR�[�h
            temp.SexCode = reader.ReadInt32();
            //���ʖ���
            temp.SexName = reader.ReadString();
            //���N����
            temp.Birthday = new DateTime(reader.ReadInt64());
            //�d�b�ԍ��i��Ёj
            temp.CompanyTelNo = reader.ReadString();
            //�d�b�ԍ��i�g�сj
            temp.PortableTelNo = reader.ReadString();
            //��E�R�[�h
            temp.PostCode = reader.ReadInt32();
            //�Ɩ��敪
            temp.BusinessCode = reader.ReadInt32();
            //��t�E���J�敪
            temp.FrontMechaCode = reader.ReadInt32();
            //�Г��O�敪
            temp.InOutsideCompanyCode = reader.ReadInt32();
            //�������_�R�[�h
            temp.BelongSectionCode = reader.ReadString();
            //���o���[�g�����i��ʁj
            temp.LvrRtCstGeneral = reader.ReadInt64();
            //���o���[�g�����i�Ԍ��j
            temp.LvrRtCstCarInspect = reader.ReadInt64();
            //���o���[�g�����i�h���j
            temp.LvrRtCstBodyPaint = reader.ReadInt64();
            //���o���[�g�����i����j
            temp.LvrRtCstBodyRepair = reader.ReadInt64();
            //���O�C��ID
            temp.LoginId = reader.ReadString();
            //���O�C���p�X���[�h
            temp.LoginPassword = reader.ReadString();
            //���[�U�[�Ǘ��҃t���O
            temp.UserAdminFlag = reader.ReadInt32();
            //���Г�
            temp.EnterCompanyDate = new DateTime(reader.ReadInt64());
            //�ސE��
            temp.RetirementDate = new DateTime(reader.ReadInt64());
            //�������x��1
            temp.AuthorityLevel1 = reader.ReadInt32();
            //�������x��2
            temp.AuthorityLevel2 = reader.ReadInt32();


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
        /// <returns>EmployeeWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                APEmployeeWork temp = GetEmployeeWork(reader, serInfo);
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
                    retValue = (APEmployeeWork[])lst.ToArray(typeof(APEmployeeWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

