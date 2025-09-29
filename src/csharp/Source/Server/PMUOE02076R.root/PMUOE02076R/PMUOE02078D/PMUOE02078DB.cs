using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SupplierUnmResultWork
    /// <summary>
    ///                      �d����ϯ�ؽĒ��o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d����ϯ�ؽĒ��o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SupplierUnmResultWork
    {
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>������t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _salesDate;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>�󒍐���</summary>
        private Double _acceptAnOrderCnt;

        /// <summary>BO�敪</summary>
        private string _boCode = "";

        /// <summary>�񓚒艿</summary>
        private Double _answerListPrice;

        /// <summary>�񓚌����P��</summary>
        private Double _answerSalesUnitCost;

        /// <summary>UOE�����ԍ�</summary>
        private Int32 _uOESalesOrderNo;

        /// <summary>�V�X�e���敪</summary>
        /// <remarks>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[</remarks>
        private Int32 _systemDivCd;

        /// <summary>UOE���_�o�ɐ�</summary>
        private Int32 _uOESectOutGoodsCnt;

        /// <summary>BO�o�ɐ�1</summary>
        /// <remarks>�T�u�{���t�H���[��</remarks>
        private Int32 _bOShipmentCnt1;

        /// <summary>BO�o�ɐ�2</summary>
        /// <remarks>�{���t�H���[��</remarks>
        private Int32 _bOShipmentCnt2;

        /// <summary>BO�o�ɐ�3</summary>
        /// <remarks>���[�g�t�H���[��</remarks>
        private Int32 _bOShipmentCnt3;

        /// <summary>���[�J�[�t�H���[��</summary>
        private Int32 _makerFollowCnt;

        /// <summary>UOE���_�`�[�ԍ�</summary>
        private string _uOESectionSlipNo = "";

        /// <summary>BO�`�[�ԍ��P</summary>
        /// <remarks>�T�u�{���t�H���[�`�[��</remarks>
        private string _bOSlipNo1 = "";

        /// <summary>BO�`�[�ԍ��Q</summary>
        /// <remarks>�{���t�H���[�`�[��</remarks>
        private string _bOSlipNo2 = "";

        /// <summary>BO�`�[�ԍ��R</summary>
        /// <remarks>���[�g�t�H���[�`�[��</remarks>
        private string _bOSlipNo3 = "";

        /// <summary>EO������</summary>
        private Int32 _eOAlwcCount;


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

        /// public propaty name  :  SectionGuideSnm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>���[�󎚗p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>������t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  AcceptAnOrderCnt
        /// <summary>�󒍐��ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AcceptAnOrderCnt
        {
            get { return _acceptAnOrderCnt; }
            set { _acceptAnOrderCnt = value; }
        }

        /// public propaty name  :  BoCode
        /// <summary>BO�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BoCode
        {
            get { return _boCode; }
            set { _boCode = value; }
        }

        /// public propaty name  :  AnswerListPrice
        /// <summary>�񓚒艿�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚒艿�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AnswerListPrice
        {
            get { return _answerListPrice; }
            set { _answerListPrice = value; }
        }

        /// public propaty name  :  AnswerSalesUnitCost
        /// <summary>�񓚌����P���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚌����P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AnswerSalesUnitCost
        {
            get { return _answerSalesUnitCost; }
            set { _answerSalesUnitCost = value; }
        }

        /// public propaty name  :  UOESalesOrderNo
        /// <summary>UOE�����ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�����ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESalesOrderNo
        {
            get { return _uOESalesOrderNo; }
            set { _uOESalesOrderNo = value; }
        }

        /// public propaty name  :  SystemDivCd
        /// <summary>�V�X�e���敪�v���p�e�B</summary>
        /// <value>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V�X�e���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SystemDivCd
        {
            get { return _systemDivCd; }
            set { _systemDivCd = value; }
        }

        /// public propaty name  :  UOESectOutGoodsCnt
        /// <summary>UOE���_�o�ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�o�ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESectOutGoodsCnt
        {
            get { return _uOESectOutGoodsCnt; }
            set { _uOESectOutGoodsCnt = value; }
        }

        /// public propaty name  :  BOShipmentCnt1
        /// <summary>BO�o�ɐ�1�v���p�e�B</summary>
        /// <value>�T�u�{���t�H���[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�o�ɐ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BOShipmentCnt1
        {
            get { return _bOShipmentCnt1; }
            set { _bOShipmentCnt1 = value; }
        }

        /// public propaty name  :  BOShipmentCnt2
        /// <summary>BO�o�ɐ�2�v���p�e�B</summary>
        /// <value>�{���t�H���[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�o�ɐ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BOShipmentCnt2
        {
            get { return _bOShipmentCnt2; }
            set { _bOShipmentCnt2 = value; }
        }

        /// public propaty name  :  BOShipmentCnt3
        /// <summary>BO�o�ɐ�3�v���p�e�B</summary>
        /// <value>���[�g�t�H���[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�o�ɐ�3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BOShipmentCnt3
        {
            get { return _bOShipmentCnt3; }
            set { _bOShipmentCnt3 = value; }
        }

        /// public propaty name  :  MakerFollowCnt
        /// <summary>���[�J�[�t�H���[���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�t�H���[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerFollowCnt
        {
            get { return _makerFollowCnt; }
            set { _makerFollowCnt = value; }
        }

        /// public propaty name  :  UOESectionSlipNo
        /// <summary>UOE���_�`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE���_�`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESectionSlipNo
        {
            get { return _uOESectionSlipNo; }
            set { _uOESectionSlipNo = value; }
        }

        /// public propaty name  :  BOSlipNo1
        /// <summary>BO�`�[�ԍ��P�v���p�e�B</summary>
        /// <value>�T�u�{���t�H���[�`�[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�`�[�ԍ��P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BOSlipNo1
        {
            get { return _bOSlipNo1; }
            set { _bOSlipNo1 = value; }
        }

        /// public propaty name  :  BOSlipNo2
        /// <summary>BO�`�[�ԍ��Q�v���p�e�B</summary>
        /// <value>�{���t�H���[�`�[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�`�[�ԍ��Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BOSlipNo2
        {
            get { return _bOSlipNo2; }
            set { _bOSlipNo2 = value; }
        }

        /// public propaty name  :  BOSlipNo3
        /// <summary>BO�`�[�ԍ��R�v���p�e�B</summary>
        /// <value>���[�g�t�H���[�`�[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO�`�[�ԍ��R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BOSlipNo3
        {
            get { return _bOSlipNo3; }
            set { _bOSlipNo3 = value; }
        }

        /// public propaty name  :  EOAlwcCount
        /// <summary>EO�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   EO�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EOAlwcCount
        {
            get { return _eOAlwcCount; }
            set { _eOAlwcCount = value; }
        }


        /// <summary>
        /// �d����ϯ�ؽĒ��o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SupplierUnmResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierUnmResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SupplierUnmResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SupplierUnmResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SupplierUnmResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SupplierUnmResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierUnmResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SupplierUnmResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SupplierUnmResultWork || graph is ArrayList || graph is SupplierUnmResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SupplierUnmResultWork).FullName));

            if (graph != null && graph is SupplierUnmResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SupplierUnmResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SupplierUnmResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SupplierUnmResultWork[])graph).Length;
            }
            else if (graph is SupplierUnmResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //������t
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //�󒍐���
            serInfo.MemberInfo.Add(typeof(Double)); //AcceptAnOrderCnt
            //BO�敪
            serInfo.MemberInfo.Add(typeof(string)); //BoCode
            //�񓚒艿
            serInfo.MemberInfo.Add(typeof(Double)); //AnswerListPrice
            //�񓚌����P��
            serInfo.MemberInfo.Add(typeof(Double)); //AnswerSalesUnitCost
            //UOE�����ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESalesOrderNo
            //�V�X�e���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SystemDivCd
            //UOE���_�o�ɐ�
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESectOutGoodsCnt
            //BO�o�ɐ�1
            serInfo.MemberInfo.Add(typeof(Int32)); //BOShipmentCnt1
            //BO�o�ɐ�2
            serInfo.MemberInfo.Add(typeof(Int32)); //BOShipmentCnt2
            //BO�o�ɐ�3
            serInfo.MemberInfo.Add(typeof(Int32)); //BOShipmentCnt3
            //���[�J�[�t�H���[��
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerFollowCnt
            //UOE���_�`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //UOESectionSlipNo
            //BO�`�[�ԍ��P
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo1
            //BO�`�[�ԍ��Q
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo2
            //BO�`�[�ԍ��R
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo3
            //EO������
            serInfo.MemberInfo.Add(typeof(Int32)); //EOAlwcCount


            serInfo.Serialize(writer, serInfo);
            if (graph is SupplierUnmResultWork)
            {
                SupplierUnmResultWork temp = (SupplierUnmResultWork)graph;

                SetSupplierUnmResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SupplierUnmResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SupplierUnmResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SupplierUnmResultWork temp in lst)
                {
                    SetSupplierUnmResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SupplierUnmResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 23;

        /// <summary>
        ///  SupplierUnmResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierUnmResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSupplierUnmResultWork(System.IO.BinaryWriter writer, SupplierUnmResultWork temp)
        {
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //������t
            writer.Write((Int64)temp.SalesDate.Ticks);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //�󒍐���
            writer.Write(temp.AcceptAnOrderCnt);
            //BO�敪
            writer.Write(temp.BoCode);
            //�񓚒艿
            writer.Write(temp.AnswerListPrice);
            //�񓚌����P��
            writer.Write(temp.AnswerSalesUnitCost);
            //UOE�����ԍ�
            writer.Write(temp.UOESalesOrderNo);
            //�V�X�e���敪
            writer.Write(temp.SystemDivCd);
            //UOE���_�o�ɐ�
            writer.Write(temp.UOESectOutGoodsCnt);
            //BO�o�ɐ�1
            writer.Write(temp.BOShipmentCnt1);
            //BO�o�ɐ�2
            writer.Write(temp.BOShipmentCnt2);
            //BO�o�ɐ�3
            writer.Write(temp.BOShipmentCnt3);
            //���[�J�[�t�H���[��
            writer.Write(temp.MakerFollowCnt);
            //UOE���_�`�[�ԍ�
            writer.Write(temp.UOESectionSlipNo);
            //BO�`�[�ԍ��P
            writer.Write(temp.BOSlipNo1);
            //BO�`�[�ԍ��Q
            writer.Write(temp.BOSlipNo2);
            //BO�`�[�ԍ��R
            writer.Write(temp.BOSlipNo3);
            //EO������
            writer.Write(temp.EOAlwcCount);

        }

        /// <summary>
        ///  SupplierUnmResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SupplierUnmResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierUnmResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SupplierUnmResultWork GetSupplierUnmResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SupplierUnmResultWork temp = new SupplierUnmResultWork();

            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //������t
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //�󒍐���
            temp.AcceptAnOrderCnt = reader.ReadDouble();
            //BO�敪
            temp.BoCode = reader.ReadString();
            //�񓚒艿
            temp.AnswerListPrice = reader.ReadDouble();
            //�񓚌����P��
            temp.AnswerSalesUnitCost = reader.ReadDouble();
            //UOE�����ԍ�
            temp.UOESalesOrderNo = reader.ReadInt32();
            //�V�X�e���敪
            temp.SystemDivCd = reader.ReadInt32();
            //UOE���_�o�ɐ�
            temp.UOESectOutGoodsCnt = reader.ReadInt32();
            //BO�o�ɐ�1
            temp.BOShipmentCnt1 = reader.ReadInt32();
            //BO�o�ɐ�2
            temp.BOShipmentCnt2 = reader.ReadInt32();
            //BO�o�ɐ�3
            temp.BOShipmentCnt3 = reader.ReadInt32();
            //���[�J�[�t�H���[��
            temp.MakerFollowCnt = reader.ReadInt32();
            //UOE���_�`�[�ԍ�
            temp.UOESectionSlipNo = reader.ReadString();
            //BO�`�[�ԍ��P
            temp.BOSlipNo1 = reader.ReadString();
            //BO�`�[�ԍ��Q
            temp.BOSlipNo2 = reader.ReadString();
            //BO�`�[�ԍ��R
            temp.BOSlipNo3 = reader.ReadString();
            //EO������
            temp.EOAlwcCount = reader.ReadInt32();


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
        /// <returns>SupplierUnmResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierUnmResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SupplierUnmResultWork temp = GetSupplierUnmResultWork(reader, serInfo);
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
                    retValue = (SupplierUnmResultWork[])lst.ToArray(typeof(SupplierUnmResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
