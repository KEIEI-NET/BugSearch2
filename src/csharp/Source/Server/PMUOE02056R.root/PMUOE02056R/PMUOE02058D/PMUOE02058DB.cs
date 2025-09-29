using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RecoveryDataResultWork
    /// <summary>
    ///                      �����f�[�^�ꗗ�\���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����f�[�^�ꗗ�\���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RecoveryDataResultWork
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

        /// <summary>�f�[�^���M�敪</summary>
        /// <remarks>0:������,1:������,2:���M�G���[,3:��M�G���[,4:�ُ�I��,5:�񓚖��ߍ���,9:����I��</remarks>
        private Int32 _dataSendCode;

        /// <summary>�I�����C���s�ԍ�</summary>
        private Int32 _onlineRowNo;

        /// <summary>�V�X�e���敪</summary>
        /// <remarks>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[</remarks>
        private Int32 _systemDivCd;


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

        /// public propaty name  :  DataSendCode
        /// <summary>�f�[�^���M�敪�v���p�e�B</summary>
        /// <value>0:������,1:������,2:���M�G���[,3:��M�G���[,4:�ُ�I��,5:�񓚖��ߍ���,9:����I��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^���M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataSendCode
        {
            get { return _dataSendCode; }
            set { _dataSendCode = value; }
        }

        /// public propaty name  :  OnlineRowNo
        /// <summary>�I�����C���s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����C���s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OnlineRowNo
        {
            get { return _onlineRowNo; }
            set { _onlineRowNo = value; }
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


        /// <summary>
        /// �����f�[�^�ꗗ�\���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RecoveryDataResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecoveryDataResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RecoveryDataResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RecoveryDataResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RecoveryDataResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RecoveryDataResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecoveryDataResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RecoveryDataResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RecoveryDataResultWork || graph is ArrayList || graph is RecoveryDataResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RecoveryDataResultWork).FullName));

            if (graph != null && graph is RecoveryDataResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RecoveryDataResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RecoveryDataResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RecoveryDataResultWork[])graph).Length;
            }
            else if (graph is RecoveryDataResultWork)
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
            //�f�[�^���M�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DataSendCode
            //�I�����C���s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //OnlineRowNo
            //�V�X�e���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SystemDivCd


            serInfo.Serialize(writer, serInfo);
            if (graph is RecoveryDataResultWork)
            {
                RecoveryDataResultWork temp = (RecoveryDataResultWork)graph;

                SetRecoveryDataResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RecoveryDataResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RecoveryDataResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RecoveryDataResultWork temp in lst)
                {
                    SetRecoveryDataResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RecoveryDataResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 14;

        /// <summary>
        ///  RecoveryDataResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecoveryDataResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRecoveryDataResultWork(System.IO.BinaryWriter writer, RecoveryDataResultWork temp)
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
            //�f�[�^���M�敪
            writer.Write(temp.DataSendCode);
            //�I�����C���s�ԍ�
            writer.Write(temp.OnlineRowNo);
            //�V�X�e���敪
            writer.Write(temp.SystemDivCd);

        }

        /// <summary>
        ///  RecoveryDataResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RecoveryDataResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecoveryDataResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RecoveryDataResultWork GetRecoveryDataResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RecoveryDataResultWork temp = new RecoveryDataResultWork();

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
            //�f�[�^���M�敪
            temp.DataSendCode = reader.ReadInt32();
            //�I�����C���s�ԍ�
            temp.OnlineRowNo = reader.ReadInt32();
            //�V�X�e���敪
            temp.SystemDivCd = reader.ReadInt32();


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
        /// <returns>RecoveryDataResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecoveryDataResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RecoveryDataResultWork temp = GetRecoveryDataResultWork(reader, serInfo);
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
                    retValue = (RecoveryDataResultWork[])lst.ToArray(typeof(RecoveryDataResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
