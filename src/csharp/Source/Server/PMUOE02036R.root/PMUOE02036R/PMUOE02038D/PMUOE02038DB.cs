using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SendBeforResultWork
    /// <summary>
    ///                      ���M�O���X�g���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���M�O���X�g���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SendBeforResultWork
    {
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>UOE������R�[�h</summary>
        private Int32 _uOESupplierCd;

        /// <summary>UOE�����於��</summary>
        private string _uOESupplierName = "";

        /// <summary>�I�����C���ԍ�</summary>
        private Int32 _onlineNo;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>�]�ƈ��R�[�h</summary>
        /// <remarks>�˗��҃R�[�h</remarks>
        private string _employeeCode = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>�󒍐���</summary>
        private Double _acceptAnOrderCnt;

        /// <summary>BO�敪</summary>
        private string _boCode = "";

        /// <summary>�t�n�d���}�[�N�P</summary>
        private string _uoeRemark1 = "";

        /// <summary>�t�n�d���}�[�N�Q</summary>
        private string _uoeRemark2 = "";

        /// <summary>�[�i�敪</summary>
        private string _uOEDeliGoodsDiv = "";

        /// <summary>�t�H���[�[�i�敪</summary>
        private string _followDeliGoodsDiv = "";

        /// <summary>UOE�w�苒�_</summary>
        private string _uOEResvdSection = "";


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

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

        /// public propaty name  :  UOESupplierName
        /// <summary>UOE�����於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�����於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESupplierName
        {
            get { return _uOESupplierName; }
            set { _uOESupplierName = value; }
        }

        /// public propaty name  :  OnlineNo
        /// <summary>�I�����C���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����C���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OnlineNo
        {
            get { return _onlineNo; }
            set { _onlineNo = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  EmployeeCode
        /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�˗��҃R�[�h</value>
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

        /// public propaty name  :  UoeRemark1
        /// <summary>�t�n�d���}�[�N�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>�t�n�d���}�[�N�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  UOEDeliGoodsDiv
        /// <summary>�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEDeliGoodsDiv
        {
            get { return _uOEDeliGoodsDiv; }
            set { _uOEDeliGoodsDiv = value; }
        }

        /// public propaty name  :  FollowDeliGoodsDiv
        /// <summary>�t�H���[�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�H���[�[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FollowDeliGoodsDiv
        {
            get { return _followDeliGoodsDiv; }
            set { _followDeliGoodsDiv = value; }
        }

        /// public propaty name  :  UOEResvdSection
        /// <summary>UOE�w�苒�_�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�w�苒�_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEResvdSection
        {
            get { return _uOEResvdSection; }
            set { _uOEResvdSection = value; }
        }


        /// <summary>
        /// ���M�O���X�g���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SendBeforResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SendBeforResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SendBeforResultWork()
        {
        }

    }


    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SendBeforResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SendBeforResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SendBeforResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SendBeforResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SendBeforResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SendBeforResultWork || graph is ArrayList || graph is SendBeforResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SendBeforResultWork).FullName));

            if (graph != null && graph is SendBeforResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SendBeforResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SendBeforResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SendBeforResultWork[])graph).Length;
            }
            else if (graph is SendBeforResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //UOE������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESupplierCd
            //UOE�����於��
            serInfo.MemberInfo.Add(typeof(string)); //UOESupplierName
            //�I�����C���ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //OnlineNo
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //�󒍐���
            serInfo.MemberInfo.Add(typeof(Double)); //AcceptAnOrderCnt
            //BO�敪
            serInfo.MemberInfo.Add(typeof(string)); //BoCode
            //�t�n�d���}�[�N�P
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //�t�n�d���}�[�N�Q
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2
            //�[�i�敪
            serInfo.MemberInfo.Add(typeof(string)); //UOEDeliGoodsDiv
            //�t�H���[�[�i�敪
            serInfo.MemberInfo.Add(typeof(string)); //FollowDeliGoodsDiv
            //UOE�w�苒�_
            serInfo.MemberInfo.Add(typeof(string)); //UOEResvdSection


            serInfo.Serialize(writer, serInfo);
            if (graph is SendBeforResultWork)
            {
                SendBeforResultWork temp = (SendBeforResultWork)graph;

                SetSendBeforResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SendBeforResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SendBeforResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SendBeforResultWork temp in lst)
                {
                    SetSendBeforResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SendBeforResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 17;

        /// <summary>
        ///  SendBeforResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SendBeforResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSendBeforResultWork(System.IO.BinaryWriter writer, SendBeforResultWork temp)
        {
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //UOE������R�[�h
            writer.Write(temp.UOESupplierCd);
            //UOE�����於��
            writer.Write(temp.UOESupplierName);
            //�I�����C���ԍ�
            writer.Write(temp.OnlineNo);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //�]�ƈ��R�[�h
            writer.Write(temp.EmployeeCode);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //�󒍐���
            writer.Write(temp.AcceptAnOrderCnt);
            //BO�敪
            writer.Write(temp.BoCode);
            //�t�n�d���}�[�N�P
            writer.Write(temp.UoeRemark1);
            //�t�n�d���}�[�N�Q
            writer.Write(temp.UoeRemark2);
            //�[�i�敪
            writer.Write(temp.UOEDeliGoodsDiv);
            //�t�H���[�[�i�敪
            writer.Write(temp.FollowDeliGoodsDiv);
            //UOE�w�苒�_
            writer.Write(temp.UOEResvdSection);

        }

        /// <summary>
        ///  SendBeforResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SendBeforResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SendBeforResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SendBeforResultWork GetSendBeforResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SendBeforResultWork temp = new SendBeforResultWork();

            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //UOE������R�[�h
            temp.UOESupplierCd = reader.ReadInt32();
            //UOE�����於��
            temp.UOESupplierName = reader.ReadString();
            //�I�����C���ԍ�
            temp.OnlineNo = reader.ReadInt32();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //�]�ƈ��R�[�h
            temp.EmployeeCode = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //�󒍐���
            temp.AcceptAnOrderCnt = reader.ReadDouble();
            //BO�敪
            temp.BoCode = reader.ReadString();
            //�t�n�d���}�[�N�P
            temp.UoeRemark1 = reader.ReadString();
            //�t�n�d���}�[�N�Q
            temp.UoeRemark2 = reader.ReadString();
            //�[�i�敪
            temp.UOEDeliGoodsDiv = reader.ReadString();
            //�t�H���[�[�i�敪
            temp.FollowDeliGoodsDiv = reader.ReadString();
            //UOE�w�苒�_
            temp.UOEResvdSection = reader.ReadString();


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
        /// <returns>SendBeforResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SendBeforResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SendBeforResultWork temp = GetSendBeforResultWork(reader, serInfo);
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
                    retValue = (SendBeforResultWork[])lst.ToArray(typeof(SendBeforResultWork));
                    break;
            }
            return retValue;
        }
    }
    #endregion
}
