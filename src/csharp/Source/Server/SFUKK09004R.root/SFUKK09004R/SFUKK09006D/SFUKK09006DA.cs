using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TaxRateSetWork
    /// <summary>
    ///                      �ŗ��ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ŗ��ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/17</br>
    /// <br>Genarated Date   :   2008/05/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TaxRateSetWork : IFileHeader
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

        /// <summary>�ŗ��R�[�h</summary>
        /// <remarks>0:��ʏ����,1:����p�����</remarks>
        private Int32 _taxRateCode;

        /// <summary>�ŗ��ŗL����</summary>
        /// <remarks>�ŗ��R�[�h�ŗL�̖���(�ύX�s��)</remarks>
        private string _taxRateProperNounNm = "";

        /// <summary>�ŗ�����</summary>
        private string _taxRateName = "";

        /// <summary>����œ]�ŕ���</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�����e3:�����q</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>�ŗ��J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _taxRateStartDate;

        /// <summary>�ŗ��I����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _taxRateEndDate;

        /// <summary>�ŗ�</summary>
        private Double _taxRate;

        /// <summary>�ŗ��J�n��2</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _taxRateStartDate2;

        /// <summary>�ŗ��I����2</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _taxRateEndDate2;

        /// <summary>�ŗ�2</summary>
        private Double _taxRate2;

        /// <summary>�ŗ��J�n��3</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _taxRateStartDate3;

        /// <summary>�ŗ��I����3</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _taxRateEndDate3;

        /// <summary>�ŗ�3</summary>
        private Double _taxRate3;


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

        /// public propaty name  :  TaxRateCode
        /// <summary>�ŗ��R�[�h�v���p�e�B</summary>
        /// <value>0:��ʏ����,1:����p�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxRateCode
        {
            get { return _taxRateCode; }
            set { _taxRateCode = value; }
        }

        /// public propaty name  :  TaxRateProperNounNm
        /// <summary>�ŗ��ŗL���̃v���p�e�B</summary>
        /// <value>�ŗ��R�[�h�ŗL�̖���(�ύX�s��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��ŗL���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TaxRateProperNounNm
        {
            get { return _taxRateProperNounNm; }
            set { _taxRateProperNounNm = value; }
        }

        /// public propaty name  :  TaxRateName
        /// <summary>�ŗ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TaxRateName
        {
            get { return _taxRateName; }
            set { _taxRateName = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>����œ]�ŕ����v���p�e�B</summary>
        /// <value>0:�`�[�P��1:���גP��2:�����e3:�����q</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����œ]�ŕ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// public propaty name  :  TaxRateStartDate
        /// <summary>�ŗ��J�n���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime TaxRateStartDate
        {
            get { return _taxRateStartDate; }
            set { _taxRateStartDate = value; }
        }

        /// public propaty name  :  TaxRateEndDate
        /// <summary>�ŗ��I�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��I�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime TaxRateEndDate
        {
            get { return _taxRateEndDate; }
            set { _taxRateEndDate = value; }
        }

        /// public propaty name  :  TaxRate
        /// <summary>�ŗ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TaxRate
        {
            get { return _taxRate; }
            set { _taxRate = value; }
        }

        /// public propaty name  :  TaxRateStartDate2
        /// <summary>�ŗ��J�n��2�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��J�n��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime TaxRateStartDate2
        {
            get { return _taxRateStartDate2; }
            set { _taxRateStartDate2 = value; }
        }

        /// public propaty name  :  TaxRateEndDate2
        /// <summary>�ŗ��I����2�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��I����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime TaxRateEndDate2
        {
            get { return _taxRateEndDate2; }
            set { _taxRateEndDate2 = value; }
        }

        /// public propaty name  :  TaxRate2
        /// <summary>�ŗ�2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TaxRate2
        {
            get { return _taxRate2; }
            set { _taxRate2 = value; }
        }

        /// public propaty name  :  TaxRateStartDate3
        /// <summary>�ŗ��J�n��3�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��J�n��3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime TaxRateStartDate3
        {
            get { return _taxRateStartDate3; }
            set { _taxRateStartDate3 = value; }
        }

        /// public propaty name  :  TaxRateEndDate3
        /// <summary>�ŗ��I����3�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ��I����3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime TaxRateEndDate3
        {
            get { return _taxRateEndDate3; }
            set { _taxRateEndDate3 = value; }
        }

        /// public propaty name  :  TaxRate3
        /// <summary>�ŗ�3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TaxRate3
        {
            get { return _taxRate3; }
            set { _taxRate3 = value; }
        }


        /// <summary>
        /// �ŗ��ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>TaxRateSetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TaxRateSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TaxRateSetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>TaxRateSetWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   TaxRateSetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class TaxRateSetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TaxRateSetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  TaxRateSetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is TaxRateSetWork || graph is ArrayList || graph is TaxRateSetWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(TaxRateSetWork).FullName));

            if (graph != null && graph is TaxRateSetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TaxRateSetWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is TaxRateSetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((TaxRateSetWork[])graph).Length;
            }
            else if (graph is TaxRateSetWork)
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
            //�ŗ��R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxRateCode
            //�ŗ��ŗL����
            serInfo.MemberInfo.Add(typeof(string)); //TaxRateProperNounNm
            //�ŗ�����
            serInfo.MemberInfo.Add(typeof(string)); //TaxRateName
            //����œ]�ŕ���
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod
            //�ŗ��J�n��
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxRateStartDate
            //�ŗ��I����
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxRateEndDate
            //�ŗ�
            serInfo.MemberInfo.Add(typeof(Double)); //TaxRate
            //�ŗ��J�n��2
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxRateStartDate2
            //�ŗ��I����2
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxRateEndDate2
            //�ŗ�2
            serInfo.MemberInfo.Add(typeof(Double)); //TaxRate2
            //�ŗ��J�n��3
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxRateStartDate3
            //�ŗ��I����3
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxRateEndDate3
            //�ŗ�3
            serInfo.MemberInfo.Add(typeof(Double)); //TaxRate3


            serInfo.Serialize(writer, serInfo);
            if (graph is TaxRateSetWork)
            {
                TaxRateSetWork temp = (TaxRateSetWork)graph;

                SetTaxRateSetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is TaxRateSetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((TaxRateSetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (TaxRateSetWork temp in lst)
                {
                    SetTaxRateSetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// TaxRateSetWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 21;

        /// <summary>
        ///  TaxRateSetWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TaxRateSetWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetTaxRateSetWork(System.IO.BinaryWriter writer, TaxRateSetWork temp)
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
            //�ŗ��R�[�h
            writer.Write(temp.TaxRateCode);
            //�ŗ��ŗL����
            writer.Write(temp.TaxRateProperNounNm);
            //�ŗ�����
            writer.Write(temp.TaxRateName);
            //����œ]�ŕ���
            writer.Write(temp.ConsTaxLayMethod);
            //�ŗ��J�n��
            writer.Write((Int64)temp.TaxRateStartDate.Ticks);
            //�ŗ��I����
            writer.Write((Int64)temp.TaxRateEndDate.Ticks);
            //�ŗ�
            writer.Write(temp.TaxRate);
            //�ŗ��J�n��2
            writer.Write((Int64)temp.TaxRateStartDate2.Ticks);
            //�ŗ��I����2
            writer.Write((Int64)temp.TaxRateEndDate2.Ticks);
            //�ŗ�2
            writer.Write(temp.TaxRate2);
            //�ŗ��J�n��3
            writer.Write((Int64)temp.TaxRateStartDate3.Ticks);
            //�ŗ��I����3
            writer.Write((Int64)temp.TaxRateEndDate3.Ticks);
            //�ŗ�3
            writer.Write(temp.TaxRate3);

        }

        /// <summary>
        ///  TaxRateSetWork�C���X�^���X�擾
        /// </summary>
        /// <returns>TaxRateSetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TaxRateSetWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private TaxRateSetWork GetTaxRateSetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            TaxRateSetWork temp = new TaxRateSetWork();

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
            //�ŗ��R�[�h
            temp.TaxRateCode = reader.ReadInt32();
            //�ŗ��ŗL����
            temp.TaxRateProperNounNm = reader.ReadString();
            //�ŗ�����
            temp.TaxRateName = reader.ReadString();
            //����œ]�ŕ���
            temp.ConsTaxLayMethod = reader.ReadInt32();
            //�ŗ��J�n��
            temp.TaxRateStartDate = new DateTime(reader.ReadInt64());
            //�ŗ��I����
            temp.TaxRateEndDate = new DateTime(reader.ReadInt64());
            //�ŗ�
            temp.TaxRate = reader.ReadDouble();
            //�ŗ��J�n��2
            temp.TaxRateStartDate2 = new DateTime(reader.ReadInt64());
            //�ŗ��I����2
            temp.TaxRateEndDate2 = new DateTime(reader.ReadInt64());
            //�ŗ�2
            temp.TaxRate2 = reader.ReadDouble();
            //�ŗ��J�n��3
            temp.TaxRateStartDate3 = new DateTime(reader.ReadInt64());
            //�ŗ��I����3
            temp.TaxRateEndDate3 = new DateTime(reader.ReadInt64());
            //�ŗ�3
            temp.TaxRate3 = reader.ReadDouble();


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
        /// <returns>TaxRateSetWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TaxRateSetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                TaxRateSetWork temp = GetTaxRateSetWork(reader, serInfo);
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
                    retValue = (TaxRateSetWork[])lst.ToArray(typeof(TaxRateSetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
