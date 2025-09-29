//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ��񃏁[�N
// �v���O�����T�v   : �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ��񃏁[�N�ł�
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
    /// public class name:   HandyUOEOrderListWork
    /// <summary>
    ///                      �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ��񃏁[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ��񃏁[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2017/08/11</br>
    /// <br>Genarated Date   :   2017/08/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyUOEOrderListWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�I�����C���ԍ�</summary>
        private Int32 _onlineNo;

        /// <summary>UOE�����ԍ�</summary>
        private Int32 _uOESalesOrderNo;

        /// <summary>�t�n�d���}�[�N�P</summary>
        private string _uoeRemark1 = "";

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

        /// <summary>���ɍX�V�敪�i���_�j</summary>
        /// <remarks>0:������ 1:���ɍ�</remarks>
        private Int32 _enterUpdDivSec;

        /// <summary>���ɍX�V�敪�iBO1�j</summary>
        /// <remarks>0:������ 1:���ɍ�</remarks>
        private Int32 _enterUpdDivBO1;

        /// <summary>���ɍX�V�敪�iBO2�j</summary>
        /// <remarks>0:������ 1:���ɍ�</remarks>
        private Int32 _enterUpdDivBO2;

        /// <summary>���ɍX�V�敪�iBO3�j</summary>
        /// <remarks>0:������ 1:���ɍ�</remarks>
        private Int32 _enterUpdDivBO3;

        /// <summary>���ɍX�V�敪�iҰ���j</summary>
        /// <remarks>0:������ 1:���ɍ�</remarks>
        private Int32 _enterUpdDivMaker;

        /// <summary>���ɍX�V�敪�iEO�j</summary>
        /// <remarks>0:������ 1:���ɍ�</remarks>
        private Int32 _enterUpdDivEO;

        /// <summary>�ʐM�A�Z���u��ID</summary>
        private string _commAssemblyId = "";


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

        /// public propaty name  :  EnterUpdDivSec
        /// <summary>���ɍX�V�敪�i���_�j�v���p�e�B</summary>
        /// <value>0:������ 1:���ɍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɍX�V�敪�i���_�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterUpdDivSec
        {
            get { return _enterUpdDivSec; }
            set { _enterUpdDivSec = value; }
        }

        /// public propaty name  :  EnterUpdDivBO1
        /// <summary>���ɍX�V�敪�iBO1�j�v���p�e�B</summary>
        /// <value>0:������ 1:���ɍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɍX�V�敪�iBO1�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterUpdDivBO1
        {
            get { return _enterUpdDivBO1; }
            set { _enterUpdDivBO1 = value; }
        }

        /// public propaty name  :  EnterUpdDivBO2
        /// <summary>���ɍX�V�敪�iBO2�j�v���p�e�B</summary>
        /// <value>0:������ 1:���ɍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɍX�V�敪�iBO2�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterUpdDivBO2
        {
            get { return _enterUpdDivBO2; }
            set { _enterUpdDivBO2 = value; }
        }

        /// public propaty name  :  EnterUpdDivBO3
        /// <summary>���ɍX�V�敪�iBO3�j�v���p�e�B</summary>
        /// <value>0:������ 1:���ɍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɍX�V�敪�iBO3�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterUpdDivBO3
        {
            get { return _enterUpdDivBO3; }
            set { _enterUpdDivBO3 = value; }
        }

        /// public propaty name  :  EnterUpdDivMaker
        /// <summary>���ɍX�V�敪�iҰ���j�v���p�e�B</summary>
        /// <value>0:������ 1:���ɍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɍX�V�敪�iҰ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterUpdDivMaker
        {
            get { return _enterUpdDivMaker; }
            set { _enterUpdDivMaker = value; }
        }

        /// public propaty name  :  EnterUpdDivEO
        /// <summary>���ɍX�V�敪�iEO�j�v���p�e�B</summary>
        /// <value>0:������ 1:���ɍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɍX�V�敪�iEO�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterUpdDivEO
        {
            get { return _enterUpdDivEO; }
            set { _enterUpdDivEO = value; }
        }

        /// public propaty name  :  CommAssemblyId
        /// <summary>�ʐM�A�Z���u��ID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ʐM�A�Z���u��ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CommAssemblyId
        {
            get { return _commAssemblyId; }
            set { _commAssemblyId = value; }
        }


        /// <summary>
        /// �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ��񃏁[�N�R���X�g���N�^
        /// </summary>
        /// <returns>HandyUOEOrderListWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyUOEOrderListWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public HandyUOEOrderListWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł��B
    /// </summary>
    /// <returns>HandyUOEOrderListWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   HandyUOEOrderListWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class HandyUOEOrderListWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyUOEOrderListWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  HandyUOEOrderListWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is HandyUOEOrderListWork || graph is ArrayList || graph is HandyUOEOrderListWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(HandyUOEOrderListWork).FullName));

            if (graph != null && graph is HandyUOEOrderListWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.HandyUOEOrderListWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is HandyUOEOrderListWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((HandyUOEOrderListWork[])graph).Length;
            }
            else if (graph is HandyUOEOrderListWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //�I�����C���ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //OnlineNo
            //UOE�����ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESalesOrderNo
            //�t�n�d���}�[�N�P
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //UOE���_�`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //UOESectionSlipNo
            //BO�`�[�ԍ��P
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo1
            //BO�`�[�ԍ��Q
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo2
            //BO�`�[�ԍ��R
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo3
            //���ɍX�V�敪�i���_�j
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterUpdDivSec
            //���ɍX�V�敪�iBO1�j
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterUpdDivBO1
            //���ɍX�V�敪�iBO2�j
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterUpdDivBO2
            //���ɍX�V�敪�iBO3�j
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterUpdDivBO3
            //���ɍX�V�敪�iҰ���j
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterUpdDivMaker
            //���ɍX�V�敪�iEO�j
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterUpdDivEO
            //�ʐM�A�Z���u��ID
            serInfo.MemberInfo.Add(typeof(string)); //CommAssemblyId


            serInfo.Serialize(writer, serInfo);
            if (graph is HandyUOEOrderListWork)
            {
                HandyUOEOrderListWork temp = (HandyUOEOrderListWork)graph;

                SetHandyUOEOrderListWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is HandyUOEOrderListWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((HandyUOEOrderListWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (HandyUOEOrderListWork temp in lst)
                {
                    SetHandyUOEOrderListWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// HandyUOEOrderListWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 15;

        /// <summary>
        ///  HandyUOEOrderListWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyUOEOrderListWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetHandyUOEOrderListWork(System.IO.BinaryWriter writer, HandyUOEOrderListWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�I�����C���ԍ�
            writer.Write(temp.OnlineNo);
            //UOE�����ԍ�
            writer.Write(temp.UOESalesOrderNo);
            //�t�n�d���}�[�N�P
            writer.Write(temp.UoeRemark1);
            //UOE���_�`�[�ԍ�
            writer.Write(temp.UOESectionSlipNo);
            //BO�`�[�ԍ��P
            writer.Write(temp.BOSlipNo1);
            //BO�`�[�ԍ��Q
            writer.Write(temp.BOSlipNo2);
            //BO�`�[�ԍ��R
            writer.Write(temp.BOSlipNo3);
            //���ɍX�V�敪�i���_�j
            writer.Write(temp.EnterUpdDivSec);
            //���ɍX�V�敪�iBO1�j
            writer.Write(temp.EnterUpdDivBO1);
            //���ɍX�V�敪�iBO2�j
            writer.Write(temp.EnterUpdDivBO2);
            //���ɍX�V�敪�iBO3�j
            writer.Write(temp.EnterUpdDivBO3);
            //���ɍX�V�敪�iҰ���j
            writer.Write(temp.EnterUpdDivMaker);
            //���ɍX�V�敪�iEO�j
            writer.Write(temp.EnterUpdDivEO);
            //�ʐM�A�Z���u��ID
            writer.Write(temp.CommAssemblyId);

        }

        /// <summary>
        ///  HandyUOEOrderListWork�C���X�^���X�擾
        /// </summary>
        /// <returns>HandyUOEOrderListWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyUOEOrderListWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private HandyUOEOrderListWork GetHandyUOEOrderListWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            HandyUOEOrderListWork temp = new HandyUOEOrderListWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�I�����C���ԍ�
            temp.OnlineNo = reader.ReadInt32();
            //UOE�����ԍ�
            temp.UOESalesOrderNo = reader.ReadInt32();
            //�t�n�d���}�[�N�P
            temp.UoeRemark1 = reader.ReadString();
            //UOE���_�`�[�ԍ�
            temp.UOESectionSlipNo = reader.ReadString();
            //BO�`�[�ԍ��P
            temp.BOSlipNo1 = reader.ReadString();
            //BO�`�[�ԍ��Q
            temp.BOSlipNo2 = reader.ReadString();
            //BO�`�[�ԍ��R
            temp.BOSlipNo3 = reader.ReadString();
            //���ɍX�V�敪�i���_�j
            temp.EnterUpdDivSec = reader.ReadInt32();
            //���ɍX�V�敪�iBO1�j
            temp.EnterUpdDivBO1 = reader.ReadInt32();
            //���ɍX�V�敪�iBO2�j
            temp.EnterUpdDivBO2 = reader.ReadInt32();
            //���ɍX�V�敪�iBO3�j
            temp.EnterUpdDivBO3 = reader.ReadInt32();
            //���ɍX�V�敪�iҰ���j
            temp.EnterUpdDivMaker = reader.ReadInt32();
            //���ɍX�V�敪�iEO�j
            temp.EnterUpdDivEO = reader.ReadInt32();
            //�ʐM�A�Z���u��ID
            temp.CommAssemblyId = reader.ReadString();


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
        /// <returns>HandyUOEOrderListWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyUOEOrderListWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                HandyUOEOrderListWork temp = GetHandyUOEOrderListWork(reader, serInfo);
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
                    retValue = (HandyUOEOrderListWork[])lst.ToArray(typeof(HandyUOEOrderListWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
