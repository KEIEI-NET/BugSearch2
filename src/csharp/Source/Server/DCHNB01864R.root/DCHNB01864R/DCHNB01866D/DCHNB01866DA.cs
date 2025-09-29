using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// ����E�d������I�v�V�����̐���N�_�ɐݒ肷��l
    /// </summary>
    public enum IOWriteCtrlOptCtrlStartingPoint
    {
        /// <summary>0:����</summary>
        Sales = 0,
        /// <summary>1:�d��</summary>
        Purchase = 1,
        /// <summary>2:�d�����㓯��</summary>
        PurchaseAndSales = 2,
        /// <summary>9:���ݒ�(�����l)</summary>
        None = 9
    }

    /// public class name:   IOWriteCtrlOptWork
    /// <summary>
    ///                      ����E�d������I�v�V�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����E�d������I�v�V�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class IOWriteCtrlOptWork
    {
        /// <summary>����N�_</summary>
        /// <remarks>0:����,1:�d��,2:�d�����㓯���v��,9:���ݒ�</remarks>
        private Int32 _ctrlStartingPoint;

        /// <summary>���σf�[�^�v��c�敪</summary>
        /// <remarks>0:�c���@1:�c���Ȃ�</remarks>
        private Int32 _estimateAddUpRemDiv;

        /// <summary>�󒍃f�[�^�v��c�敪</summary>
        /// <remarks>0:�c���@1:�c���Ȃ�</remarks>
        private Int32 _acpOdrrAddUpRemDiv;

        /// <summary>�o�׃f�[�^�v��c�敪</summary>
        /// <remarks>0:�c���@1:�c���Ȃ�</remarks>
        private Int32 _shipmAddUpRemDiv;

        /// <summary>�ԕi���݌ɓo�^�敪</summary>
        /// <remarks>0:����@1:���Ȃ�</remarks>
        private Int32 _retGoodsStockEtyDiv;

        /// <summary>�d���`�[�폜�敪</summary>
        /// <remarks>0:���Ȃ��@1:�m�F�@2:����@(����:���d�������v��̎d���`�[�𔄓`�폜���ɓ����폜)</remarks>
        private Int32 _supplierSlipDelDiv;

        /// <summary>�c���Ǘ��敪</summary>
        /// <remarks>0:����@1:���Ȃ� �@�@���`�[�폜���Ɏc�ɖ߂����ǂ��� </remarks>
        private Int32 _remainCntMngDiv;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>�r������̃L�[�Ƃ��ėp�����ƃR�[�h</remarks>
        private string _enterpriseCode = "";

        /// <summary>�ԗ��Ǘ��敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private Int32 _carMngDivCd;


        /// public propaty name  :  CtrlStartingPoint
        /// <summary>����N�_�v���p�e�B</summary>
        /// <value>0:����,1:�d��,2:�d�����㓯���v��,9:���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����N�_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CtrlStartingPoint
        {
            get { return _ctrlStartingPoint; }
            set { _ctrlStartingPoint = value; }
        }

        /// public propaty name  :  EstimateAddUpRemDiv
        /// <summary>���σf�[�^�v��c�敪�v���p�e�B</summary>
        /// <value>0:�c���@1:�c���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σf�[�^�v��c�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EstimateAddUpRemDiv
        {
            get { return _estimateAddUpRemDiv; }
            set { _estimateAddUpRemDiv = value; }
        }

        /// public propaty name  :  AcpOdrrAddUpRemDiv
        /// <summary>�󒍃f�[�^�v��c�敪�v���p�e�B</summary>
        /// <value>0:�c���@1:�c���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃f�[�^�v��c�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcpOdrrAddUpRemDiv
        {
            get { return _acpOdrrAddUpRemDiv; }
            set { _acpOdrrAddUpRemDiv = value; }
        }

        /// public propaty name  :  ShipmAddUpRemDiv
        /// <summary>�o�׃f�[�^�v��c�敪�v���p�e�B</summary>
        /// <value>0:�c���@1:�c���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׃f�[�^�v��c�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShipmAddUpRemDiv
        {
            get { return _shipmAddUpRemDiv; }
            set { _shipmAddUpRemDiv = value; }
        }

        /// public propaty name  :  RetGoodsStockEtyDiv
        /// <summary>�ԕi���݌ɓo�^�敪�v���p�e�B</summary>
        /// <value>0:����@1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi���݌ɓo�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RetGoodsStockEtyDiv
        {
            get { return _retGoodsStockEtyDiv; }
            set { _retGoodsStockEtyDiv = value; }
        }

        /// public propaty name  :  SupplierSlipDelDiv
        /// <summary>�d���`�[�폜�敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:�m�F�@2:����@(����:���d�������v��̎d���`�[�𔄓`�폜���ɓ����폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipDelDiv
        {
            get { return _supplierSlipDelDiv; }
            set { _supplierSlipDelDiv = value; }
        }

        /// public propaty name  :  RemainCntMngDiv
        /// <summary>�c���Ǘ��敪�v���p�e�B</summary>
        /// <value>0:����@1:���Ȃ� �@�@���`�[�폜���Ɏc�ɖ߂����ǂ��� </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c���Ǘ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RemainCntMngDiv
        {
            get { return _remainCntMngDiv; }
            set { _remainCntMngDiv = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>�r������̃L�[�Ƃ��ėp�����ƃR�[�h</value>
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

        /// public propaty name  :  CarMngDivCd
        /// <summary>�ԗ��Ǘ��敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��Ǘ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarMngDivCd
        {
            get { return _carMngDivCd; }
            set { _carMngDivCd = value; }
        }


        /// <summary>
        /// ����E�d������I�v�V�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>IOWriteCtrlOptWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteCtrlOptWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public IOWriteCtrlOptWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>IOWriteCtrlOptWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   IOWriteCtrlOptWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class IOWriteCtrlOptWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteCtrlOptWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  IOWriteCtrlOptWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is IOWriteCtrlOptWork || graph is ArrayList || graph is IOWriteCtrlOptWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(IOWriteCtrlOptWork).FullName));

            if (graph != null && graph is IOWriteCtrlOptWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.IOWriteCtrlOptWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is IOWriteCtrlOptWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((IOWriteCtrlOptWork[])graph).Length;
            }
            else if (graph is IOWriteCtrlOptWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //����N�_
            serInfo.MemberInfo.Add(typeof(Int32)); //CtrlStartingPoint
            //���σf�[�^�v��c�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //EstimateAddUpRemDiv
            //�󒍃f�[�^�v��c�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AcpOdrrAddUpRemDiv
            //�o�׃f�[�^�v��c�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmAddUpRemDiv
            //�ԕi���݌ɓo�^�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //RetGoodsStockEtyDiv
            //�d���`�[�폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipDelDiv
            //�c���Ǘ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //RemainCntMngDiv
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //�ԗ��Ǘ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CarMngDivCd


            serInfo.Serialize(writer, serInfo);
            if (graph is IOWriteCtrlOptWork)
            {
                IOWriteCtrlOptWork temp = (IOWriteCtrlOptWork)graph;

                SetIOWriteCtrlOptWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is IOWriteCtrlOptWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((IOWriteCtrlOptWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (IOWriteCtrlOptWork temp in lst)
                {
                    SetIOWriteCtrlOptWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// IOWriteCtrlOptWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 9;

        /// <summary>
        ///  IOWriteCtrlOptWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteCtrlOptWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetIOWriteCtrlOptWork(System.IO.BinaryWriter writer, IOWriteCtrlOptWork temp)
        {
            //����N�_
            writer.Write(temp.CtrlStartingPoint);
            //���σf�[�^�v��c�敪
            writer.Write(temp.EstimateAddUpRemDiv);
            //�󒍃f�[�^�v��c�敪
            writer.Write(temp.AcpOdrrAddUpRemDiv);
            //�o�׃f�[�^�v��c�敪
            writer.Write(temp.ShipmAddUpRemDiv);
            //�ԕi���݌ɓo�^�敪
            writer.Write(temp.RetGoodsStockEtyDiv);
            //�d���`�[�폜�敪
            writer.Write(temp.SupplierSlipDelDiv);
            //�c���Ǘ��敪
            writer.Write(temp.RemainCntMngDiv);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�ԗ��Ǘ��敪
            writer.Write(temp.CarMngDivCd);

        }

        /// <summary>
        ///  IOWriteCtrlOptWork�C���X�^���X�擾
        /// </summary>
        /// <returns>IOWriteCtrlOptWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteCtrlOptWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private IOWriteCtrlOptWork GetIOWriteCtrlOptWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            IOWriteCtrlOptWork temp = new IOWriteCtrlOptWork();

            //����N�_
            temp.CtrlStartingPoint = reader.ReadInt32();
            //���σf�[�^�v��c�敪
            temp.EstimateAddUpRemDiv = reader.ReadInt32();
            //�󒍃f�[�^�v��c�敪
            temp.AcpOdrrAddUpRemDiv = reader.ReadInt32();
            //�o�׃f�[�^�v��c�敪
            temp.ShipmAddUpRemDiv = reader.ReadInt32();
            //�ԕi���݌ɓo�^�敪
            temp.RetGoodsStockEtyDiv = reader.ReadInt32();
            //�d���`�[�폜�敪
            temp.SupplierSlipDelDiv = reader.ReadInt32();
            //�c���Ǘ��敪
            temp.RemainCntMngDiv = reader.ReadInt32();
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�ԗ��Ǘ��敪
            temp.CarMngDivCd = reader.ReadInt32();


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
        /// <returns>IOWriteCtrlOptWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteCtrlOptWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                IOWriteCtrlOptWork temp = GetIOWriteCtrlOptWork(reader, serInfo);
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
                    retValue = (IOWriteCtrlOptWork[])lst.ToArray(typeof(IOWriteCtrlOptWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
