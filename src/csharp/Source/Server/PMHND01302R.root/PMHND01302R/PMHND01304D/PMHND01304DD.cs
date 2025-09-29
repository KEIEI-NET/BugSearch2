//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �n���f�B�^�[�~�i���ϑ��݌ɕ�[�̌��i���擾���ʃ��[�N
// �v���O�����T�v   : �n���f�B�^�[�~�i���ϑ��݌ɕ�[�̌��i���擾���ʃ��[�N�ł�
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
    /// public class name:   ConsStockRepInspectRetWork
    /// <summary>
    ///                      �ϑ��݌ɕ�[�̌��i���擾���ʃ��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ϑ��݌ɕ�[�̌��i���擾���ʃ��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2017/08/11</br>
    /// <br>Genarated Date   :   2017/08/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ConsStockRepInspectRetWork
    {
        /// <summary>�݌ɒ����`�[�ԍ�</summary>
        private Int32 _stockAdjustSlipNo;

        /// <summary>�݌ɒ����s�ԍ�</summary>
        private Int32 _stockAdjustRowNo;

        /// <summary>�������t</summary>
        private Int32 _adjustDate;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>������</summary>
        /// <remarks>�ύX�O�ƕύX��̎d���݌ɐ��̍���o�^����B</remarks>
        private Double _adjustCount;

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>�q�ɒI��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>���i�o�[�R�[�h</summary>
        private string _goodsBarCode = "";

        /// <summary>���i�X�e�[�^�X</summary>
        /// <remarks>1:���i�� 2:�s�b�L���O�ς� 3:���i�ς݁@�ꊇ���i��"2"��o�^���܂��B</remarks>
        private Int32 _inspectStatus;

        /// <summary>���i�敪</summary>
        /// <remarks>1:�ʏ� 2:�蓮���i </remarks>
        private Int32 _inspectCode;

        /// <summary>���i��</summary>
        private Double _inspectCnt;


        /// public propaty name  :  StockAdjustSlipNo
        /// <summary>�݌ɒ����`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɒ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockAdjustSlipNo
        {
            get { return _stockAdjustSlipNo; }
            set { _stockAdjustSlipNo = value; }
        }

        /// public propaty name  :  StockAdjustRowNo
        /// <summary>�݌ɒ����s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɒ����s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockAdjustRowNo
        {
            get { return _stockAdjustRowNo; }
            set { _stockAdjustRowNo = value; }
        }

        /// public propaty name  :  AdjustDate
        /// <summary>�������t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AdjustDate
        {
            get { return _adjustDate; }
            set { _adjustDate = value; }
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

        /// public propaty name  :  AdjustCount
        /// <summary>�������v���p�e�B</summary>
        /// <value>�ύX�O�ƕύX��̎d���݌ɐ��̍���o�^����B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double AdjustCount
        {
            get { return _adjustCount; }
            set { _adjustCount = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>�q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>�q�ɒI�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɒI�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  GoodsBarCode
        /// <summary>���i�o�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�o�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsBarCode
        {
            get { return _goodsBarCode; }
            set { _goodsBarCode = value; }
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


        /// <summary>
        /// �ϑ��݌ɕ�[�̌��i���擾���ʃ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ConsStockRepInspectRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConsStockRepInspectRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ConsStockRepInspectRetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł��B
    /// </summary>
    /// <returns>ConsStockRepInspectRetWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   ConsStockRepInspectRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class ConsStockRepInspectRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConsStockRepInspectRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ConsStockRepInspectRetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ConsStockRepInspectRetWork || graph is ArrayList || graph is ConsStockRepInspectRetWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(ConsStockRepInspectRetWork).FullName));

            if (graph != null && graph is ConsStockRepInspectRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ConsStockRepInspectRetWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ConsStockRepInspectRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ConsStockRepInspectRetWork[])graph).Length;
            }
            else if (graph is ConsStockRepInspectRetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�݌ɒ����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAdjustSlipNo
            //�݌ɒ����s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAdjustRowNo
            //�������t
            serInfo.MemberInfo.Add(typeof(Int32)); //AdjustDate
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //������
            serInfo.MemberInfo.Add(typeof(Double)); //AdjustCount
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //�q�ɒI��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //���i�o�[�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //GoodsBarCode
            //���i�X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //InspectStatus
            //���i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //InspectCode
            //���i��
            serInfo.MemberInfo.Add(typeof(Double)); //InspectCnt


            serInfo.Serialize(writer, serInfo);
            if (graph is ConsStockRepInspectRetWork)
            {
                ConsStockRepInspectRetWork temp = (ConsStockRepInspectRetWork)graph;

                SetConsStockRepInspectRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ConsStockRepInspectRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ConsStockRepInspectRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ConsStockRepInspectRetWork temp in lst)
                {
                    SetConsStockRepInspectRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ConsStockRepInspectRetWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 14;

        /// <summary>
        ///  ConsStockRepInspectRetWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConsStockRepInspectRetWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetConsStockRepInspectRetWork(System.IO.BinaryWriter writer, ConsStockRepInspectRetWork temp)
        {
            //�݌ɒ����`�[�ԍ�
            writer.Write(temp.StockAdjustSlipNo);
            //�݌ɒ����s�ԍ�
            writer.Write(temp.StockAdjustRowNo);
            //�������t
            writer.Write(temp.AdjustDate);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //������
            writer.Write(temp.AdjustCount);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //�q�ɒI��
            writer.Write(temp.WarehouseShelfNo);
            //���i�o�[�R�[�h
            writer.Write(temp.GoodsBarCode);
            //���i�X�e�[�^�X
            writer.Write(temp.InspectStatus);
            //���i�敪
            writer.Write(temp.InspectCode);
            //���i��
            writer.Write(temp.InspectCnt);

        }

        /// <summary>
        ///  ConsStockRepInspectRetWork�C���X�^���X�擾
        /// </summary>
        /// <returns>ConsStockRepInspectRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConsStockRepInspectRetWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private ConsStockRepInspectRetWork GetConsStockRepInspectRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            ConsStockRepInspectRetWork temp = new ConsStockRepInspectRetWork();

            //�݌ɒ����`�[�ԍ�
            temp.StockAdjustSlipNo = reader.ReadInt32();
            //�݌ɒ����s�ԍ�
            temp.StockAdjustRowNo = reader.ReadInt32();
            //�������t
            temp.AdjustDate = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //������
            temp.AdjustCount = reader.ReadDouble();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //�q�ɒI��
            temp.WarehouseShelfNo = reader.ReadString();
            //���i�o�[�R�[�h
            temp.GoodsBarCode = reader.ReadString();
            //���i�X�e�[�^�X
            temp.InspectStatus = reader.ReadInt32();
            //���i�敪
            temp.InspectCode = reader.ReadInt32();
            //���i��
            temp.InspectCnt = reader.ReadDouble();


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
        /// <returns>ConsStockRepInspectRetWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConsStockRepInspectRetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ConsStockRepInspectRetWork temp = GetConsStockRepInspectRetWork(reader, serInfo);
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
                    retValue = (ConsStockRepInspectRetWork[])lst.ToArray(typeof(ConsStockRepInspectRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
