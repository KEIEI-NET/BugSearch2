using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RsltInfo_PastYearStatisticsWork
    /// <summary>
    ///                      �ߔN�x���v�\���o���ʃ��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ߔN�x���v�\���o���ʃ��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/12/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RsltInfo_PastYearStatisticsWork
    {
        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
        private string _addUpSecCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
        private string _sectionGuideNm = "";

        /// <summary>���Ӑ�R�[�h</summary>
        /// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        /// <remarks>���ꂼ��̌����W�v�f�[�^����擾</remarks>
        private string _customerSnm = "";

        /// <summary>����z(1�N��)</summary>
        /// <remarks>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</remarks>
        private Int64 _salesMoney1;

        /// <summary>�e���z(1�N��)</summary>
        /// <remarks>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</remarks>
        private Int64 _grossMoney1;

        /// <summary>����z(2�N��)</summary>
        /// <remarks>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</remarks>
        private Int64 _salesMoney2;

        /// <summary>�e���z(2�N��)</summary>
        /// <remarks>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</remarks>
        private Int64 _grossMoney2;

        /// <summary>����z(3�N��)</summary>
        /// <remarks>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</remarks>
        private Int64 _salesMoney3;

        /// <summary>�e���z(3�N��)</summary>
        /// <remarks>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</remarks>
        private Int64 _grossMoney3;

        /// <summary>����z(4�N��)</summary>
        /// <remarks>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</remarks>
        private Int64 _salesMoney4;

        /// <summary>�e���z(4�N��)</summary>
        /// <remarks>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</remarks>
        private Int64 _grossMoney4;

        /// <summary>����z(5�N��)</summary>
        /// <remarks>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</remarks>
        private Int64 _salesMoney5;

        /// <summary>�e���z(5�N��)</summary>
        /// <remarks>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</remarks>
        private Int64 _grossMoney5;

        /// <summary>����z(6�N��)</summary>
        /// <remarks>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</remarks>
        private Int64 _salesMoney6;

        /// <summary>�e���z(6�N��)</summary>
        /// <remarks>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</remarks>
        private Int64 _grossMoney6;

        /// <summary>����z(7�N��)</summary>
        /// <remarks>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</remarks>
        private Int64 _salesMoney7;

        /// <summary>�e���z(7�N��)</summary>
        /// <remarks>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</remarks>
        private Int64 _grossMoney7;

        /// <summary>����z(8�N��)</summary>
        /// <remarks>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</remarks>
        private Int64 _salesMoney8;

        /// <summary>�e���z(8�N��)</summary>
        /// <remarks>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</remarks>
        private Int64 _grossMoney8;


        /// public propaty name  :  AddUpSecCode
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>���ꂼ��̌����W�v�f�[�^����擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>���ꂼ��̌����W�v�f�[�^����擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>���ꂼ��̌����W�v�f�[�^����擾</value>
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

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// <value>���ꂼ��̌����W�v�f�[�^����擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  SalesMoney1
        /// <summary>����z(1�N��)�v���p�e�B</summary>
        /// <value>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����z(1�N��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney1
        {
            get { return _salesMoney1; }
            set { _salesMoney1 = value; }
        }

        /// public propaty name  :  GrossMoney1
        /// <summary>�e���z(1�N��)�v���p�e�B</summary>
        /// <value>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���z(1�N��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossMoney1
        {
            get { return _grossMoney1; }
            set { _grossMoney1 = value; }
        }

        /// public propaty name  :  SalesMoney2
        /// <summary>����z(2�N��)�v���p�e�B</summary>
        /// <value>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����z(2�N��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney2
        {
            get { return _salesMoney2; }
            set { _salesMoney2 = value; }
        }

        /// public propaty name  :  GrossMoney2
        /// <summary>�e���z(2�N��)�v���p�e�B</summary>
        /// <value>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���z(2�N��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossMoney2
        {
            get { return _grossMoney2; }
            set { _grossMoney2 = value; }
        }

        /// public propaty name  :  SalesMoney3
        /// <summary>����z(3�N��)�v���p�e�B</summary>
        /// <value>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����z(3�N��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney3
        {
            get { return _salesMoney3; }
            set { _salesMoney3 = value; }
        }

        /// public propaty name  :  GrossMoney3
        /// <summary>�e���z(3�N��)�v���p�e�B</summary>
        /// <value>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���z(3�N��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossMoney3
        {
            get { return _grossMoney3; }
            set { _grossMoney3 = value; }
        }

        /// public propaty name  :  SalesMoney4
        /// <summary>����z(4�N��)�v���p�e�B</summary>
        /// <value>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����z(4�N��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney4
        {
            get { return _salesMoney4; }
            set { _salesMoney4 = value; }
        }

        /// public propaty name  :  GrossMoney4
        /// <summary>�e���z(4�N��)�v���p�e�B</summary>
        /// <value>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���z(4�N��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossMoney4
        {
            get { return _grossMoney4; }
            set { _grossMoney4 = value; }
        }

        /// public propaty name  :  SalesMoney5
        /// <summary>����z(5�N��)�v���p�e�B</summary>
        /// <value>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����z(5�N��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney5
        {
            get { return _salesMoney5; }
            set { _salesMoney5 = value; }
        }

        /// public propaty name  :  GrossMoney5
        /// <summary>�e���z(5�N��)�v���p�e�B</summary>
        /// <value>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���z(5�N��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossMoney5
        {
            get { return _grossMoney5; }
            set { _grossMoney5 = value; }
        }

        /// public propaty name  :  SalesMoney6
        /// <summary>����z(6�N��)�v���p�e�B</summary>
        /// <value>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����z(6�N��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney6
        {
            get { return _salesMoney6; }
            set { _salesMoney6 = value; }
        }

        /// public propaty name  :  GrossMoney6
        /// <summary>�e���z(6�N��)�v���p�e�B</summary>
        /// <value>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���z(6�N��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossMoney6
        {
            get { return _grossMoney6; }
            set { _grossMoney6 = value; }
        }

        /// public propaty name  :  SalesMoney7
        /// <summary>����z(7�N��)�v���p�e�B</summary>
        /// <value>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����z(7�N��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney7
        {
            get { return _salesMoney7; }
            set { _salesMoney7 = value; }
        }

        /// public propaty name  :  GrossMoney7
        /// <summary>�e���z(7�N��)�v���p�e�B</summary>
        /// <value>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���z(7�N��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossMoney7
        {
            get { return _grossMoney7; }
            set { _grossMoney7 = value; }
        }

        /// public propaty name  :  SalesMoney8
        /// <summary>����z(8�N��)�v���p�e�B</summary>
        /// <value>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����z(8�N��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoney8
        {
            get { return _salesMoney8; }
            set { _salesMoney8 = value; }
        }

        /// public propaty name  :  GrossMoney8
        /// <summary>�e���z(8�N��)�v���p�e�B</summary>
        /// <value>�u��~�P�ʁv����1000�Ŋ����ď����_���l�̌ܓ������l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���z(8�N��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossMoney8
        {
            get { return _grossMoney8; }
            set { _grossMoney8 = value; }
        }


        /// <summary>
        /// �ߔN�x���v�\���o���ʃ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RsltInfo_PastYearStatisticsWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PastYearStatisticsWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RsltInfo_PastYearStatisticsWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RsltInfo_PastYearStatisticsWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PastYearStatisticsWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RsltInfo_PastYearStatisticsWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PastYearStatisticsWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RsltInfo_PastYearStatisticsWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RsltInfo_PastYearStatisticsWork || graph is ArrayList || graph is RsltInfo_PastYearStatisticsWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RsltInfo_PastYearStatisticsWork).FullName));

            if (graph != null && graph is RsltInfo_PastYearStatisticsWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RsltInfo_PastYearStatisticsWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RsltInfo_PastYearStatisticsWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RsltInfo_PastYearStatisticsWork[])graph).Length;
            }
            else if (graph is RsltInfo_PastYearStatisticsWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //����z(1�N��)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney1
            //�e���z(1�N��)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossMoney1
            //����z(2�N��)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney2
            //�e���z(2�N��)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossMoney2
            //����z(3�N��)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney3
            //�e���z(3�N��)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossMoney3
            //����z(4�N��)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney4
            //�e���z(4�N��)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossMoney4
            //����z(5�N��)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney5
            //�e���z(5�N��)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossMoney5
            //����z(6�N��)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney6
            //�e���z(6�N��)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossMoney6
            //����z(7�N��)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney7
            //�e���z(7�N��)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossMoney7
            //����z(8�N��)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoney8
            //�e���z(8�N��)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossMoney8


            serInfo.Serialize(writer, serInfo);
            if (graph is RsltInfo_PastYearStatisticsWork)
            {
                RsltInfo_PastYearStatisticsWork temp = (RsltInfo_PastYearStatisticsWork)graph;

                SetRsltInfo_PastYearStatisticsWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RsltInfo_PastYearStatisticsWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RsltInfo_PastYearStatisticsWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RsltInfo_PastYearStatisticsWork temp in lst)
                {
                    SetRsltInfo_PastYearStatisticsWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RsltInfo_PastYearStatisticsWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 20;

        /// <summary>
        ///  RsltInfo_PastYearStatisticsWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PastYearStatisticsWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRsltInfo_PastYearStatisticsWork(System.IO.BinaryWriter writer, RsltInfo_PastYearStatisticsWork temp)
        {
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideNm);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //����z(1�N��)
            writer.Write(temp.SalesMoney1);
            //�e���z(1�N��)
            writer.Write(temp.GrossMoney1);
            //����z(2�N��)
            writer.Write(temp.SalesMoney2);
            //�e���z(2�N��)
            writer.Write(temp.GrossMoney2);
            //����z(3�N��)
            writer.Write(temp.SalesMoney3);
            //�e���z(3�N��)
            writer.Write(temp.GrossMoney3);
            //����z(4�N��)
            writer.Write(temp.SalesMoney4);
            //�e���z(4�N��)
            writer.Write(temp.GrossMoney4);
            //����z(5�N��)
            writer.Write(temp.SalesMoney5);
            //�e���z(5�N��)
            writer.Write(temp.GrossMoney5);
            //����z(6�N��)
            writer.Write(temp.SalesMoney6);
            //�e���z(6�N��)
            writer.Write(temp.GrossMoney6);
            //����z(7�N��)
            writer.Write(temp.SalesMoney7);
            //�e���z(7�N��)
            writer.Write(temp.GrossMoney7);
            //����z(8�N��)
            writer.Write(temp.SalesMoney8);
            //�e���z(8�N��)
            writer.Write(temp.GrossMoney8);

        }

        /// <summary>
        ///  RsltInfo_PastYearStatisticsWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RsltInfo_PastYearStatisticsWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PastYearStatisticsWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RsltInfo_PastYearStatisticsWork GetRsltInfo_PastYearStatisticsWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RsltInfo_PastYearStatisticsWork temp = new RsltInfo_PastYearStatisticsWork();

            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideNm = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //����z(1�N��)
            temp.SalesMoney1 = reader.ReadInt64();
            //�e���z(1�N��)
            temp.GrossMoney1 = reader.ReadInt64();
            //����z(2�N��)
            temp.SalesMoney2 = reader.ReadInt64();
            //�e���z(2�N��)
            temp.GrossMoney2 = reader.ReadInt64();
            //����z(3�N��)
            temp.SalesMoney3 = reader.ReadInt64();
            //�e���z(3�N��)
            temp.GrossMoney3 = reader.ReadInt64();
            //����z(4�N��)
            temp.SalesMoney4 = reader.ReadInt64();
            //�e���z(4�N��)
            temp.GrossMoney4 = reader.ReadInt64();
            //����z(5�N��)
            temp.SalesMoney5 = reader.ReadInt64();
            //�e���z(5�N��)
            temp.GrossMoney5 = reader.ReadInt64();
            //����z(6�N��)
            temp.SalesMoney6 = reader.ReadInt64();
            //�e���z(6�N��)
            temp.GrossMoney6 = reader.ReadInt64();
            //����z(7�N��)
            temp.SalesMoney7 = reader.ReadInt64();
            //�e���z(7�N��)
            temp.GrossMoney7 = reader.ReadInt64();
            //����z(8�N��)
            temp.SalesMoney8 = reader.ReadInt64();
            //�e���z(8�N��)
            temp.GrossMoney8 = reader.ReadInt64();


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
        /// <returns>RsltInfo_PastYearStatisticsWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PastYearStatisticsWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RsltInfo_PastYearStatisticsWork temp = GetRsltInfo_PastYearStatisticsWork(reader, serInfo);
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
                    retValue = (RsltInfo_PastYearStatisticsWork[])lst.ToArray(typeof(RsltInfo_PastYearStatisticsWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
