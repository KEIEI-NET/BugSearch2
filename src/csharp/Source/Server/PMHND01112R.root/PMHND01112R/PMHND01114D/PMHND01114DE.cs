//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ��񃏁[�N�iHT/AP�T�[�o�[�p�j���[�N
// �v���O�����T�v   : �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ��񃏁[�N�iHT/AP�T�[�o�[�p�j���[�N�ł�
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
    /// public class name:   HandyUOEOrderResultListWork
    /// <summary>
    ///                      �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ��񃏁[�N�iHT/AP�T�[�o�[�p�j���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ��񃏁[�N�iHT/AP�T�[�o�[�p�j���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2017/08/11</br>
    /// <br>Genarated Date   :   2017/08/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyUOEOrderResultListWork
    {
        /// <summary>�t�n�d���}�[�N�P</summary>
        private string _uoeRemark1 = "";

        /// <summary>�`�[�ԍ�</summary>
        private string _slipNo = "";

        /// <summary>�I�����C���ԍ�</summary>
        private Int32 _onlineNo;

        /// <summary>UOE�����ԍ�</summary>
        private Int32 _uOESalesOrderNo;

        /// <summary>���ɋ敪</summary>
        /// <remarks>1:���_ 2:BO1 3:BO2 4:BO3 5:Ұ�� 6�FEO</remarks>
        private Int32 _warehousingDivCd;


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

        /// public propaty name  :  SlipNo
        /// <summary>�`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNo
        {
            get { return _slipNo; }
            set { _slipNo = value; }
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

        /// public propaty name  :  WarehousingDivCd
        /// <summary>���ɋ敪�v���p�e�B</summary>
        /// <value>1:���_ 2:BO1 3:BO2 4:BO3 5:Ұ�� 6�FEO</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 WarehousingDivCd
        {
            get { return _warehousingDivCd; }
            set { _warehousingDivCd = value; }
        }


        /// <summary>
        /// �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ��񃏁[�N�iHT/AP�T�[�o�[�p�j���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>HandyUOEOrderResultListWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyUOEOrderResultListWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public HandyUOEOrderResultListWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł��B
    /// </summary>
    /// <returns>HandyUOEOrderResultListWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   HandyUOEOrderResultListWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class HandyUOEOrderResultListWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyUOEOrderResultListWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  HandyUOEOrderResultListWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is HandyUOEOrderResultListWork || graph is ArrayList || graph is HandyUOEOrderResultListWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(HandyUOEOrderResultListWork).FullName));

            if (graph != null && graph is HandyUOEOrderResultListWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.HandyUOEOrderResultListWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is HandyUOEOrderResultListWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((HandyUOEOrderResultListWork[])graph).Length;
            }
            else if (graph is HandyUOEOrderResultListWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�t�n�d���}�[�N�P
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //�`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SlipNo
            //�I�����C���ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //OnlineNo
            //UOE�����ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESalesOrderNo
            //���ɋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //WarehousingDivCd


            serInfo.Serialize(writer, serInfo);
            if (graph is HandyUOEOrderResultListWork)
            {
                HandyUOEOrderResultListWork temp = (HandyUOEOrderResultListWork)graph;

                SetHandyUOEOrderResultListWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is HandyUOEOrderResultListWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((HandyUOEOrderResultListWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (HandyUOEOrderResultListWork temp in lst)
                {
                    SetHandyUOEOrderResultListWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// HandyUOEOrderResultListWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  HandyUOEOrderResultListWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyUOEOrderResultListWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetHandyUOEOrderResultListWork(System.IO.BinaryWriter writer, HandyUOEOrderResultListWork temp)
        {
            //�t�n�d���}�[�N�P
            writer.Write(temp.UoeRemark1);
            //�`�[�ԍ�
            writer.Write(temp.SlipNo);
            //�I�����C���ԍ�
            writer.Write(temp.OnlineNo);
            //UOE�����ԍ�
            writer.Write(temp.UOESalesOrderNo);
            //���ɋ敪
            writer.Write(temp.WarehousingDivCd);

        }

        /// <summary>
        ///  HandyUOEOrderResultListWork�C���X�^���X�擾
        /// </summary>
        /// <returns>HandyUOEOrderResultListWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyUOEOrderResultListWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private HandyUOEOrderResultListWork GetHandyUOEOrderResultListWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            HandyUOEOrderResultListWork temp = new HandyUOEOrderResultListWork();

            //�t�n�d���}�[�N�P
            temp.UoeRemark1 = reader.ReadString();
            //�`�[�ԍ�
            temp.SlipNo = reader.ReadString();
            //�I�����C���ԍ�
            temp.OnlineNo = reader.ReadInt32();
            //UOE�����ԍ�
            temp.UOESalesOrderNo = reader.ReadInt32();
            //���ɋ敪
            temp.WarehousingDivCd = reader.ReadInt32();


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
        /// <returns>HandyUOEOrderResultListWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyUOEOrderResultListWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                HandyUOEOrderResultListWork temp = GetHandyUOEOrderResultListWork(reader, serInfo);
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
                    retValue = (HandyUOEOrderResultListWork[])lst.ToArray(typeof(HandyUOEOrderResultListWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
