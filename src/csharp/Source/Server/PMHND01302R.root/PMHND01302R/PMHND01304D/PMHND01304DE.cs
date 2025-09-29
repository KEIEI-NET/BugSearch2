//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �n���f�B�^�[�~�i���ϑ��݌ɕ�[�̌��i���ۑ��������[�N
// �v���O�����T�v   : �n���f�B�^�[�~�i���ϑ��݌ɕ�[�̌��i���ۑ��������[�N�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : 杍^
// �� �� ��  2017/08/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;

using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ConsStockRepInspectDataParamWork
    /// <summary>
    ///                      �ϑ��݌ɕ�[�̌��i���ۑ��������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ϑ��݌ɕ�[�̌��i���ۑ��������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2017/08/11</br>
    /// <br>Genarated Date   :   2017/08/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ConsStockRepInspectDataParamWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�󕥌��`�[�敪</summary>
        /// <remarks>10:�d��,11:���,12:��v��,13:�݌Ɏd��20:����,21:���v��,22:�ݏo,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,42:�}�X�^�����e,50:�I��,60:�g��,61:����,70:��[����,71:��[�o��</remarks>
        private Int32 _acPaySlipCd;

        /// <summary>�ϑ���݌ɒ����`�[�ԍ�</summary>
        /// <remarks>�u�󕥌��`�[�v�̓`�[�ԍ����i�[</remarks>
        private string _acPaySlipNum = "";

        /// <summary>�ϑ���݌ɒ����s�ԍ�</summary>
        /// <remarks>�u�󕥌��`�[�v�̓`�[�s�ԍ����i�[</remarks>
        private Int32 _acPaySlipRowNo;

        /// <summary>�󕥌�����敪</summary>
        /// <remarks>10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���</remarks>
        private Int32 _acPayTransCd;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>�ϑ���q�ɃR�[�h</summary>
        /// <remarks>�݌ɊǗ��Ȃ���"0"</remarks>
        private string _warehouseCode = "";

        /// <summary>���i����</summary>
        private Int64 _inspectDateTime;

        /// <summary>���i�X�e�[�^�X</summary>
        /// <remarks>1:���i�� 2:�s�b�L���O�ς� 3:���i�ς݁@�ꊇ���i��"2"��o�^���܂��B</remarks>
        private Int32 _inspectStatus;

        /// <summary>���i�敪</summary>
        /// <remarks>1:�ʏ� 2:�蓮���i </remarks>
        private Int32 _inspectCode;

        /// <summary>���i��</summary>
        private Double _inspectCnt;

        /// <summary>�n���f�B�^�[�~�i���敪</summary>
        /// <remarks>1:�n���f�B�^�[�~�i�� 9:���̑�</remarks>
        private Int32 _handTerminalCode;

        /// <summary>�R���s���[�^��</summary>
        private string _machineName = "";

        /// <summary>�]�ƈ��R�[�h</summary>
        /// <remarks>���i�]�ƈ�</remarks>
        private string _employeeCode = "";

        /// <summary>�����敪</summary>
        private Int32 _opDiv;


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

        /// public propaty name  :  AcPaySlipCd
        /// <summary>�󕥌��`�[�敪�v���p�e�B</summary>
        /// <value>10:�d��,11:���,12:��v��,13:�݌Ɏd��20:����,21:���v��,22:�ݏo,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,42:�}�X�^�����e,50:�I��,60:�g��,61:����,70:��[����,71:��[�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󕥌��`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcPaySlipCd
        {
            get { return _acPaySlipCd; }
            set { _acPaySlipCd = value; }
        }

        /// public propaty name  :  AcPaySlipNum
        /// <summary>�ϑ���݌ɒ����`�[�ԍ��v���p�e�B</summary>
        /// <value>�u�󕥌��`�[�v�̓`�[�ԍ����i�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϑ���݌ɒ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AcPaySlipNum
        {
            get { return _acPaySlipNum; }
            set { _acPaySlipNum = value; }
        }

        /// public propaty name  :  AcPaySlipRowNo
        /// <summary>�ϑ���݌ɒ����s�ԍ��v���p�e�B</summary>
        /// <value>�u�󕥌��`�[�v�̓`�[�s�ԍ����i�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϑ���݌ɒ����s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcPaySlipRowNo
        {
            get { return _acPaySlipRowNo; }
            set { _acPaySlipRowNo = value; }
        }

        /// public propaty name  :  AcPayTransCd
        /// <summary>�󕥌�����敪�v���p�e�B</summary>
        /// <value>10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󕥌�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcPayTransCd
        {
            get { return _acPayTransCd; }
            set { _acPayTransCd = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
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

        /// public propaty name  :  WarehouseCode
        /// <summary>�ϑ���q�ɃR�[�h�v���p�e�B</summary>
        /// <value>�݌ɊǗ��Ȃ���"0"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϑ���q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  InspectDateTime
        /// <summary>���i�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 InspectDateTime
        {
            get { return _inspectDateTime; }
            set { _inspectDateTime = value; }
        }

        /// public propaty name  :  InspectStatus
        /// <summary>���i�X�e�[�^�X�v���p�e�B</summary>
        /// <value>1:���i�� 2:�s�b�L���O�ς� 3:���i�ς݁@�ꊇ���i��"2"��o�^���܂��B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InspectStatus
        {
            get { return _inspectStatus; }
            set { _inspectStatus = value; }
        }

        /// public propaty name  :  InspectCode
        /// <summary>���i�敪�v���p�e�B</summary>
        /// <value>1:�ʏ� 2:�蓮���i </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InspectCode
        {
            get { return _inspectCode; }
            set { _inspectCode = value; }
        }

        /// public propaty name  :  InspectCnt
        /// <summary>���i���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double InspectCnt
        {
            get { return _inspectCnt; }
            set { _inspectCnt = value; }
        }

        /// public propaty name  :  HandTerminalCode
        /// <summary>�n���f�B�^�[�~�i���敪�v���p�e�B</summary>
        /// <value>1:�n���f�B�^�[�~�i�� 9:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n���f�B�^�[�~�i���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HandTerminalCode
        {
            get { return _handTerminalCode; }
            set { _handTerminalCode = value; }
        }

        /// public propaty name  :  MachineName
        /// <summary>�R���s���[�^���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R���s���[�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MachineName
        {
            get { return _machineName; }
            set { _machineName = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���i�]�ƈ�</value>
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

        /// public propaty name  :  OpDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OpDiv
        {
            get { return _opDiv; }
            set { _opDiv = value; }
        }


        /// <summary>
        /// �ϑ��݌ɕ�[�̌��i���ۑ��������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ConsStockRepInspectDataParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConsStockRepInspectDataParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ConsStockRepInspectDataParamWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>ConsStockRepInspectDataParamWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   ConsStockRepInspectDataParamWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class ConsStockRepInspectDataParamWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConsStockRepInspectDataParamWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ConsStockRepInspectDataParamWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ConsStockRepInspectDataParamWork || graph is ArrayList || graph is ConsStockRepInspectDataParamWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(ConsStockRepInspectDataParamWork).FullName));

            if (graph != null && graph is ConsStockRepInspectDataParamWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ConsStockRepInspectDataParamWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ConsStockRepInspectDataParamWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ConsStockRepInspectDataParamWork[])graph).Length;
            }
            else if (graph is ConsStockRepInspectDataParamWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //�󕥌��`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AcPaySlipCd
            //�ϑ���݌ɒ����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //AcPaySlipNum
            //�ϑ���݌ɒ����s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //AcPaySlipRowNo
            //�󕥌�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AcPayTransCd
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //�ϑ���q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //���i����
            serInfo.MemberInfo.Add(typeof(Int64)); //InspectDateTime
            //���i�X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //InspectStatus
            //���i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //InspectCode
            //���i��
            serInfo.MemberInfo.Add(typeof(Double)); //InspectCnt
            //�n���f�B�^�[�~�i���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //HandTerminalCode
            //�R���s���[�^��
            serInfo.MemberInfo.Add(typeof(string)); //MachineName
            //�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OpDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is ConsStockRepInspectDataParamWork)
            {
                ConsStockRepInspectDataParamWork temp = (ConsStockRepInspectDataParamWork)graph;

                SetConsStockRepInspectDataParamWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ConsStockRepInspectDataParamWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ConsStockRepInspectDataParamWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ConsStockRepInspectDataParamWork temp in lst)
                {
                    SetConsStockRepInspectDataParamWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ConsStockRepInspectDataParamWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 16;

        /// <summary>
        ///  ConsStockRepInspectDataParamWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConsStockRepInspectDataParamWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetConsStockRepInspectDataParamWork(System.IO.BinaryWriter writer, ConsStockRepInspectDataParamWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�󕥌��`�[�敪
            writer.Write(temp.AcPaySlipCd);
            //�ϑ���݌ɒ����`�[�ԍ�
            writer.Write(temp.AcPaySlipNum);
            //�ϑ���݌ɒ����s�ԍ�
            writer.Write(temp.AcPaySlipRowNo);
            //�󕥌�����敪
            writer.Write(temp.AcPayTransCd);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //�ϑ���q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //���i����
            writer.Write(temp.InspectDateTime);
            //���i�X�e�[�^�X
            writer.Write(temp.InspectStatus);
            //���i�敪
            writer.Write(temp.InspectCode);
            //���i��
            writer.Write(temp.InspectCnt);
            //�n���f�B�^�[�~�i���敪
            writer.Write(temp.HandTerminalCode);
            //�R���s���[�^��
            writer.Write(temp.MachineName);
            //�]�ƈ��R�[�h
            writer.Write(temp.EmployeeCode);
            //�����敪
            writer.Write(temp.OpDiv);

        }

        /// <summary>
        ///  ConsStockRepInspectDataParamWork�C���X�^���X�擾
        /// </summary>
        /// <returns>ConsStockRepInspectDataParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConsStockRepInspectDataParamWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private ConsStockRepInspectDataParamWork GetConsStockRepInspectDataParamWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            ConsStockRepInspectDataParamWork temp = new ConsStockRepInspectDataParamWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�󕥌��`�[�敪
            temp.AcPaySlipCd = reader.ReadInt32();
            //�ϑ���݌ɒ����`�[�ԍ�
            temp.AcPaySlipNum = reader.ReadString();
            //�ϑ���݌ɒ����s�ԍ�
            temp.AcPaySlipRowNo = reader.ReadInt32();
            //�󕥌�����敪
            temp.AcPayTransCd = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //�ϑ���q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //���i����
            temp.InspectDateTime = reader.ReadInt64();
            //���i�X�e�[�^�X
            temp.InspectStatus = reader.ReadInt32();
            //���i�敪
            temp.InspectCode = reader.ReadInt32();
            //���i��
            temp.InspectCnt = reader.ReadDouble();
            //�n���f�B�^�[�~�i���敪
            temp.HandTerminalCode = reader.ReadInt32();
            //�R���s���[�^��
            temp.MachineName = reader.ReadString();
            //�]�ƈ��R�[�h
            temp.EmployeeCode = reader.ReadString();
            //�����敪
            temp.OpDiv = reader.ReadInt32();


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
        /// <returns>ConsStockRepInspectDataParamWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConsStockRepInspectDataParamWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ConsStockRepInspectDataParamWork temp = GetConsStockRepInspectDataParamWork(reader, serInfo);
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
                    retValue = (ConsStockRepInspectDataParamWork[])lst.ToArray(typeof(ConsStockRepInspectDataParamWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
