using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   IOWriteMASIRDeleteWork
    /// <summary>
    ///                      �d���f�[�^(IOWriteMASIRDelete)���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���f�[�^(IOWriteMASIRDelete)���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/04/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/09/30 �݌Ƀ}�X�^�X�V�敪��ǉ�</br>
    /// <br>--------------------------------------</br>
    /// <br>Update Note      :   �d�����גʔԂ�ǉ�</br>
    /// <br>                     ����d���������͂Ŕ���`�[��ʁX�œ��͂��d���`�[�ԍ��𓯈�ō쐬���A</br>
    /// <br>                     �쐬��������`�[�̕Е���`�[�폜�����ꍇ�A�d���`�[���Ăяo���Ȃ��Ȃ錏�̏C��</br>
    /// <br>Programmer       :   �e�c ���V</br>
    /// <br>Date             :   2012/11/30</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class IOWriteMASIRDeleteWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�d���`��</summary>
        /// <remarks>0:����(�d��),1:���</remarks>
        private Int32 _supplierFormal;

        /// <summary>�d���`�[�ԍ�</summary>
        private Int32 _supplierSlipNo;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>�ԓ`�敪</summary>
        /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
        private Int32 _debitNoteDiv;

        // -- ADD 2009/09/30 -------------------->>>
        /// <summary>�݌Ƀ}�X�^�X�V�敪</summary>
        /// <remarks>0:�X�V,1�X�V���Ȃ�</remarks>
        private Int32 _stockUpdDiv;
        // -- ADD 2009/09/30 --------------------<<<

        // --- ADD 2012/11/30 Y.Wakita ---------->>>>>
        /// <summary>�d�����גʔ�</summary>
        private Int64 _stockSlipDtlNum;
        // --- ADD 2012/11/30 Y.Wakita ----------<<<<<

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

        /// public propaty name  :  SupplierFormal
        /// <summary>�d���`���v���p�e�B</summary>
        /// <value>0:����(�d��),1:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  DebitNoteDiv
        /// <summary>�ԓ`�敪�v���p�e�B</summary>
        /// <value>0:���`,1:�ԓ`,2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԓ`�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        // -- ADD 2009/09/30 ---------------------------->>>
        /// public propaty name  :  StockUpdDiv
        /// <summary>�݌Ƀ}�X�^�X�V�敪�v���p�e�B</summary>
        /// <value>0:�X�V,1:�X�V���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ƀ}�X�^�X�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockUpdDiv
        {
            get { return _stockUpdDiv; }
            set { _stockUpdDiv = value; }
        }
        // -- ADD 2009/09/30 ----------------------------<<<

        // --- ADD 2012/11/30 Y.Wakita ---------->>>>>
        /// public propaty name  :  StockSlipDtlNum
        /// <summary>�d�����גʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����גʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockSlipDtlNum
        {
            get { return _stockSlipDtlNum; }
            set { _stockSlipDtlNum = value; }
        }
        // --- ADD 2012/11/30 Y.Wakita ----------<<<<<

        /// <summary>
        /// �d���f�[�^(IOWriteMASIRDelete)���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>IOWriteMASIRDeleteWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteMASIRDeleteWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public IOWriteMASIRDeleteWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>IOWriteMASIRDeleteWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   IOWriteMASIRDeleteWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class IOWriteMASIRDeleteWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteMASIRDeleteWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  IOWriteMASIRDeleteWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is IOWriteMASIRDeleteWork || graph is ArrayList || graph is IOWriteMASIRDeleteWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(IOWriteMASIRDeleteWork).FullName));

            if (graph != null && graph is IOWriteMASIRDeleteWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.IOWriteMASIRDeleteWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is IOWriteMASIRDeleteWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((IOWriteMASIRDeleteWork[])graph).Length;
            }
            else if (graph is IOWriteMASIRDeleteWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //�d���`��
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //�d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //�ԓ`�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            // -- ADD 2009/09/30 ------------------------------->>>
            //�݌Ƀ}�X�^�X�V�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockUpdDiv
            // -- ADD 2009/09/30 -------------------------------<<<
            // --- ADD 2012/11/30 Y.Wakita ---------->>>>>
            //�d�����גʔ�
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNum
            // --- ADD 2012/11/30 Y.Wakita ----------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is IOWriteMASIRDeleteWork)
            {
                IOWriteMASIRDeleteWork temp = (IOWriteMASIRDeleteWork)graph;

                SetIOWriteMASIRDeleteWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is IOWriteMASIRDeleteWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((IOWriteMASIRDeleteWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (IOWriteMASIRDeleteWork temp in lst)
                {
                    SetIOWriteMASIRDeleteWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// IOWriteMASIRDeleteWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 5; // DEL 2009/09/30
        //private const int currentMemberCount = 6; // ADD 2009/09/30 DEL 2012/11/30 Y.Wakita
        private const int currentMemberCount = 7; // --- ADD 2012/11/30 Y.Wakita

        /// <summary>
        ///  IOWriteMASIRDeleteWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteMASIRDeleteWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetIOWriteMASIRDeleteWork(System.IO.BinaryWriter writer, IOWriteMASIRDeleteWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�d���`��
            writer.Write(temp.SupplierFormal);
            //�d���`�[�ԍ�
            writer.Write(temp.SupplierSlipNo);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //�ԓ`�敪
            writer.Write(temp.DebitNoteDiv);
            // -- ADD 2009/09/30 ------------>>>
            //�݌Ƀ}�X�^�X�V�敪
            writer.Write(temp.StockUpdDiv);
            // -- ADD 2009/09/30 ------------<<<
            // --- ADD 2012/11/30 Y.Wakita ---------->>>>>
            //�d�����גʔ�
            writer.Write(temp.StockSlipDtlNum);
            // --- ADD 2012/11/30 Y.Wakita ----------<<<<<
        }

        /// <summary>
        ///  IOWriteMASIRDeleteWork�C���X�^���X�擾
        /// </summary>
        /// <returns>IOWriteMASIRDeleteWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteMASIRDeleteWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private IOWriteMASIRDeleteWork GetIOWriteMASIRDeleteWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            IOWriteMASIRDeleteWork temp = new IOWriteMASIRDeleteWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�d���`��
            temp.SupplierFormal = reader.ReadInt32();
            //�d���`�[�ԍ�
            temp.SupplierSlipNo = reader.ReadInt32();
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //�ԓ`�敪
            temp.DebitNoteDiv = reader.ReadInt32();
            // -- ADD 2009/09/30 -------------->>>
            //�݌Ƀ}�X�^�X�V�敪
            temp.StockUpdDiv = reader.ReadInt32();
            // -- ADD 2009/09/30 --------------<<<
            // --- ADD 2012/11/30 Y.Wakita ---------->>>>>
            //�d�����גʔ�
            temp.StockSlipDtlNum = reader.ReadInt64();
            // --- ADD 2012/11/30 Y.Wakita ----------<<<<<

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
        /// <returns>IOWriteMASIRDeleteWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteMASIRDeleteWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                IOWriteMASIRDeleteWork temp = GetIOWriteMASIRDeleteWork(reader, serInfo);
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
                    retValue = (IOWriteMASIRDeleteWork[])lst.ToArray(typeof(IOWriteMASIRDeleteWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
