//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�
// �v���O�����T�v   : �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ�����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// �Ǘ��ԍ�  11500865-00  �쐬�S�� : 杍^
// �� �� ��  2019/09/02   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   EmpScSalesTargetWork
    /// <summary>
    ///                      �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2019/09/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class EmpScSalesTargetWork : IFileHeader
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

        /// <summary>�ڕW�ݒ�敪</summary>
        /// <remarks>10�F���ԖڕW,20�F�ʊ��ԖڕW</remarks>
        private Int32 _targetSetCd;

        /// <summary>�ڕW�Δ�敪</summary>
        /// <remarks>99:�S����+�̔��敪</remarks>
        private Int32 _targetContrastCd;

        /// <summary>�ڕW�敪�R�[�h</summary>
        /// <remarks>���ԖڕW�FYYYYMM�A�ʊ��ԖڕW�F�C�ӃR�[�h</remarks>
        private string _targetDivideCode = "";

        /// <summary>�ڕW�敪����</summary>
        private string _targetDivideName = "";

        /// <summary>�̔��敪</summary>
        /// <remarks>���[�U�[�K�C�h</remarks>
        private Int32 _salesCode;

        /// <summary>�]�ƈ��R�[�h</summary>
        private string _employeeCode = "";

        /// <summary>�K�p�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyStaDate;

        /// <summary>�K�p�I����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyEndDate;

        /// <summary>����ڕW���z</summary>
        private Int64 _salesTargetMoney;

        /// <summary>����ڕW�e���z</summary>
        private Int64 _salesTargetProfit;

        /// <summary>����ڕW����</summary>
        private Double _salesTargetCount;


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

        /// public propaty name  :  TargetSetCd
        /// <summary>�ڕW�ݒ�敪�v���p�e�B</summary>
        /// <value>10�F���ԖڕW,20�F�ʊ��ԖڕW</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڕW�ݒ�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TargetSetCd
        {
            get { return _targetSetCd; }
            set { _targetSetCd = value; }
        }

        /// public propaty name  :  TargetContrastCd
        /// <summary>�ڕW�Δ�敪�v���p�e�B</summary>
        /// <value>99:�S����+�̔��敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڕW�Δ�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TargetContrastCd
        {
            get { return _targetContrastCd; }
            set { _targetContrastCd = value; }
        }

        /// public propaty name  :  TargetDivideCode
        /// <summary>�ڕW�敪�R�[�h�v���p�e�B</summary>
        /// <value>���ԖڕW�FYYYYMM�A�ʊ��ԖڕW�F�C�ӃR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڕW�敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TargetDivideCode
        {
            get { return _targetDivideCode; }
            set { _targetDivideCode = value; }
        }

        /// public propaty name  :  TargetDivideName
        /// <summary>�ڕW�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڕW�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TargetDivideName
        {
            get { return _targetDivideName; }
            set { _targetDivideName = value; }
        }

        /// public propaty name  :  SalesCode
        /// <summary>�̔��敪�v���p�e�B</summary>
        /// <value>���[�U�[�K�C�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
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

        /// public propaty name  :  ApplyStaDate
        /// <summary>�K�p�J�n���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ApplyStaDate
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
        public DateTime ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
        }

        /// public propaty name  :  SalesTargetMoney
        /// <summary>����ڕW���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney
        {
            get { return _salesTargetMoney; }
            set { _salesTargetMoney = value; }
        }

        /// public propaty name  :  SalesTargetProfit
        /// <summary>����ڕW�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit
        {
            get { return _salesTargetProfit; }
            set { _salesTargetProfit = value; }
        }

        /// public propaty name  :  SalesTargetCount
        /// <summary>����ڕW���ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount
        {
            get { return _salesTargetCount; }
            set { _salesTargetCount = value; }
        }


        /// <summary>
        /// �]�ƈ��ʔ̔��敪�ʔ���ڕW�ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>EmpScSalesTargetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmpScSalesTargetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public EmpScSalesTargetWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>EmpScSalesTargetWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   EmpScSalesTargetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class EmpScSalesTargetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmpScSalesTargetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  EmpScSalesTargetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is EmpScSalesTargetWork || graph is ArrayList || graph is EmpScSalesTargetWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(EmpScSalesTargetWork).FullName));

            if (graph != null && graph is EmpScSalesTargetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.EmpScSalesTargetWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is EmpScSalesTargetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((EmpScSalesTargetWork[])graph).Length;
            }
            else if (graph is EmpScSalesTargetWork)
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
            //�ڕW�ݒ�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TargetSetCd
            //�ڕW�Δ�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TargetContrastCd
            //�ڕW�敪�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //TargetDivideCode
            //�ڕW�敪����
            serInfo.MemberInfo.Add(typeof(string)); //TargetDivideName
            //�̔��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCode
            //�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //�K�p�J�n��
            serInfo.MemberInfo.Add(typeof(Int32)); //ApplyStaDate
            //�K�p�I����
            serInfo.MemberInfo.Add(typeof(Int32)); //ApplyEndDate
            //����ڕW���z
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney
            //����ڕW�e���z
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit
            //����ڕW����
            serInfo.MemberInfo.Add(typeof(Double)); //SalesTargetCount


            serInfo.Serialize(writer, serInfo);
            if (graph is EmpScSalesTargetWork)
            {
                EmpScSalesTargetWork temp = (EmpScSalesTargetWork)graph;

                SetEmpScSalesTargetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is EmpScSalesTargetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((EmpScSalesTargetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (EmpScSalesTargetWork temp in lst)
                {
                    SetEmpScSalesTargetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// EmpScSalesTargetWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 19;

        /// <summary>
        ///  EmpScSalesTargetWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmpScSalesTargetWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetEmpScSalesTargetWork(System.IO.BinaryWriter writer, EmpScSalesTargetWork temp)
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
            //�ڕW�ݒ�敪
            writer.Write(temp.TargetSetCd);
            //�ڕW�Δ�敪
            writer.Write(temp.TargetContrastCd);
            //�ڕW�敪�R�[�h
            writer.Write(temp.TargetDivideCode);
            //�ڕW�敪����
            writer.Write(temp.TargetDivideName);
            //�̔��敪
            writer.Write(temp.SalesCode);
            //�]�ƈ��R�[�h
            writer.Write(temp.EmployeeCode);
            //�K�p�J�n��
            writer.Write((Int64)temp.ApplyStaDate.Ticks);
            //�K�p�I����
            writer.Write((Int64)temp.ApplyEndDate.Ticks);
            //����ڕW���z
            writer.Write(temp.SalesTargetMoney);
            //����ڕW�e���z
            writer.Write(temp.SalesTargetProfit);
            //����ڕW����
            writer.Write(temp.SalesTargetCount);

        }

        /// <summary>
        ///  EmpScSalesTargetWork�C���X�^���X�擾
        /// </summary>
        /// <returns>EmpScSalesTargetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmpScSalesTargetWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private EmpScSalesTargetWork GetEmpScSalesTargetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            EmpScSalesTargetWork temp = new EmpScSalesTargetWork();

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
            //�ڕW�ݒ�敪
            temp.TargetSetCd = reader.ReadInt32();
            //�ڕW�Δ�敪
            temp.TargetContrastCd = reader.ReadInt32();
            //�ڕW�敪�R�[�h
            temp.TargetDivideCode = reader.ReadString();
            //�ڕW�敪����
            temp.TargetDivideName = reader.ReadString();
            //�̔��敪
            temp.SalesCode = reader.ReadInt32();
            //�]�ƈ��R�[�h
            temp.EmployeeCode = reader.ReadString();
            //�K�p�J�n��
            temp.ApplyStaDate = new DateTime(reader.ReadInt64());
            //�K�p�I����
            temp.ApplyEndDate = new DateTime(reader.ReadInt64());
            //����ڕW���z
            temp.SalesTargetMoney = reader.ReadInt64();
            //����ڕW�e���z
            temp.SalesTargetProfit = reader.ReadInt64();
            //����ڕW����
            temp.SalesTargetCount = reader.ReadDouble();


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
        /// <returns>EmpScSalesTargetWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmpScSalesTargetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                EmpScSalesTargetWork temp = GetEmpScSalesTargetWork(reader, serInfo);
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
                    retValue = (EmpScSalesTargetWork[])lst.ToArray(typeof(EmpScSalesTargetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
