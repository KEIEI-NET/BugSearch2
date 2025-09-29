//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : ���i�Ώۏ�񃏁[�N
// �v���O�����T�v   : ���i�Ώۏ�񃏁[�N�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : ���R
// �� �� ��  2017/06/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;

using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   HandyInspectWork
    /// <summary>
    ///                      ���i�Ώۃ��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�Ώۃ��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/17</br>
    /// <br>Genarated Date   :   2017/06/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2012/05/30  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   ����`�[���͋N������</br>
    /// <br>                 :   ���Ӑ�d�q�����N������</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyInspectWork
    {
        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        private string _slipNum = "";

        /// <summary>�s�ԍ�</summary>
        private Int32 _rowNo;

        /// <summary>���[�J�[�R�[�h</summary>
        /// <remarks>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</remarks>
        private Int32 _makerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>�i���J�i</summary>
        private string _goodsNameKana = "";

        /// <summary>�o�ɐ�</summary>
        private Double _shipmentCnt;

        /// <summary>�I��</summary>
        private string _shelfNo = "";

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>����݌Ɏ�񂹋敪</summary>
        /// <remarks>0:��񂹁C1:�݌�</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>���i�o�[�R�[�h</summary>
        private string _goodsBarCode = "";

        /// <summary>���i�X�e�[�^�X</summary>
        /// <remarks>1:���i�� 2:�s�b�L���O�ς� 3:���i�ς݁@�ꊇ���i��"2"��o�^���܂��B</remarks>
        private Int32 _inspectStatus;

        /// <summary>���i��</summary>
        private Double _inspectCnt;

        /// <summary>���i�敪</summary>
        /// <remarks>1:�ʏ� 2:�蓮���i </remarks>
        private Int32 _inspectCode;

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
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

        /// public propaty name  :  SlipNum
        /// <summary>�`�[�ԍ��v���p�e�B</summary>
        /// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNum
        {
            get { return _slipNum; }
            set { _slipNum = value; }
        }

        /// public propaty name  :  RowNo
        /// <summary>�s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RowNo
        {
            get { return _rowNo; }
            set { _rowNo = value; }
        }

        /// public propaty name  :  MakerCd
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerCd
        {
            get { return _makerCd; }
            set { _makerCd = value; }
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

        /// public propaty name  :  GoodsNameKana
        /// <summary>�i���J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i���J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>�o�ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  ShelfNo
        /// <summary>�I�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShelfNo
        {
            get { return _shelfNo; }
            set { _shelfNo = value; }
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

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>����݌Ɏ�񂹋敪�v���p�e�B</summary>
        /// <value>0:��񂹁C1:�݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����݌Ɏ�񂹋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesOrderDivCd
        {
            get { return _salesOrderDivCd; }
            set { _salesOrderDivCd = value; }
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


        /// <summary>
        /// ���i�Ώۃ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>HandyInspectWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyInspectWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public HandyInspectWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł��B
    /// </summary>
    /// <returns>HandyInspectWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   HandyInspectWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class HandyInspectWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyInspectWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  HandyInspectWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is HandyInspectWork || graph is ArrayList || graph is HandyInspectWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(HandyInspectWork).FullName));

            if (graph != null && graph is HandyInspectWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.HandyInspectWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is HandyInspectWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((HandyInspectWork[])graph).Length;
            }
            else if (graph is HandyInspectWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //�`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SlipNum
            //�s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //RowNo
            //���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCd
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //�i���J�i
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //�o�ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //�I��
            serInfo.MemberInfo.Add(typeof(string)); //ShelfNo
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //����݌Ɏ�񂹋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderDivCd
            //���i�o�[�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //GoodsBarCode
            //���i�X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //InspectStatus
            //���i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //InspectCode
            //���i��
            serInfo.MemberInfo.Add(typeof(Double)); //InspectCnt


            serInfo.Serialize(writer, serInfo);
            if (graph is HandyInspectWork)
            {
                HandyInspectWork temp = (HandyInspectWork)graph;

                SetHandyInspectWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is HandyInspectWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((HandyInspectWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (HandyInspectWork temp in lst)
                {
                    SetHandyInspectWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// HandyInspectWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 14;

        /// <summary>
        ///  HandyInspectWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyInspectWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetHandyInspectWork(System.IO.BinaryWriter writer, HandyInspectWork temp)
        {
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //�`�[�ԍ�
            writer.Write(temp.SlipNum);
            //�s�ԍ�
            writer.Write(temp.RowNo);
            //���[�J�[�R�[�h
            writer.Write(temp.MakerCd);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //�i���J�i
            writer.Write(temp.GoodsNameKana);
            //�o�ɐ�
            writer.Write(temp.ShipmentCnt);
            //�I��
            writer.Write(temp.ShelfNo);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //����݌Ɏ�񂹋敪
            writer.Write(temp.SalesOrderDivCd);
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
        ///  HandyInspectWork�C���X�^���X�擾
        /// </summary>
        /// <returns>HandyInspectWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyInspectWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private HandyInspectWork GetHandyInspectWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            HandyInspectWork temp = new HandyInspectWork();

            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //�`�[�ԍ�
            temp.SlipNum = reader.ReadString();
            //�s�ԍ�
            temp.RowNo = reader.ReadInt32();
            //���[�J�[�R�[�h
            temp.MakerCd = reader.ReadInt32();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //�i���J�i
            temp.GoodsNameKana = reader.ReadString();
            //�o�ɐ�
            temp.ShipmentCnt = reader.ReadDouble();
            //�I��
            temp.ShelfNo = reader.ReadString();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //����݌Ɏ�񂹋敪
            temp.SalesOrderDivCd = reader.ReadInt32();
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
        /// <returns>HandyInspectWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyInspectWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                HandyInspectWork temp = GetHandyInspectWork(reader, serInfo);
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
                    retValue = (HandyInspectWork[])lst.ToArray(typeof(HandyInspectWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}