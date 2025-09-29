using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustPrtPprBlDspRsltWork
    /// <summary>
    ///                      ���Ӑ�d�q�������o����(�c���Ɖ�)�N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ�d�q�������o����(�c���Ɖ�)�N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustPrtPprBlDspRsltWork
    {
        /// <summary>�O�X�X��c��</summary>
        /// <remarks>��2��O�c���i�����v�j</remarks>
        private Int64 _acpOdrTtl2TmBfBlDmd;

        /// <summary>�O�X��c��</summary>
        /// <remarks>�O�񐿋����z</remarks>
        private Int64 _lastTimeDemand;

        /// <summary>�O��c��</summary>
        /// <remarks>�v�Z�㐿�����z</remarks>
        private Int64 _afCalDemandPrice;

        /// <summary>�����͈�</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>����œ]�ŕ���</summary>
        /// <remarks>0:�`�[�P��1:���גP��2:�����e3:�����q�@9:��ې�</remarks>
        private Int32 _consTaxLayMethod;


        /// public propaty name  :  AcpOdrTtl2TmBfBlDmd
        /// <summary>�O�X�X��c���v���p�e�B</summary>
        /// <value>��2��O�c���i�����v�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�X�X��c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AcpOdrTtl2TmBfBlDmd
        {
            get { return _acpOdrTtl2TmBfBlDmd; }
            set { _acpOdrTtl2TmBfBlDmd = value; }
        }

        /// public propaty name  :  LastTimeDemand
        /// <summary>�O�X��c���v���p�e�B</summary>
        /// <value>�O�񐿋����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�X��c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 LastTimeDemand
        {
            get { return _lastTimeDemand; }
            set { _lastTimeDemand = value; }
        }

        /// public propaty name  :  AfCalDemandPrice
        /// <summary>�O��c���v���p�e�B</summary>
        /// <value>�v�Z�㐿�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O��c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AfCalDemandPrice
        {
            get { return _afCalDemandPrice; }
            set { _afCalDemandPrice = value; }
        }

        /// public propaty name  :  AddUpYearMonth
        /// <summary>�����͈̓v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����͈̓v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>����œ]�ŕ����v���p�e�B</summary>
        /// <value>0:�`�[�P��1:���גP��2:�����e3:�����q�@9:��ې�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����œ]�ŕ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }


        /// <summary>
        /// ���Ӑ�d�q�������o����(�c���Ɖ�)�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CustPrtPprBlDspRsltWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlDspRsltWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustPrtPprBlDspRsltWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CustPrtPprBlDspRsltWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlDspRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class CustPrtPprBlDspRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlDspRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CustPrtPprBlDspRsltWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CustPrtPprBlDspRsltWork || graph is ArrayList || graph is CustPrtPprBlDspRsltWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(CustPrtPprBlDspRsltWork).FullName));

            if (graph != null && graph is CustPrtPprBlDspRsltWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustPrtPprBlDspRsltWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CustPrtPprBlDspRsltWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustPrtPprBlDspRsltWork[])graph).Length;
            }
            else if (graph is CustPrtPprBlDspRsltWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�O�X�X��c��
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl2TmBfBlDmd
            //�O�X��c��
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeDemand
            //�O��c��
            serInfo.MemberInfo.Add(typeof(Int64)); //AfCalDemandPrice
            //�����͈�
            serInfo.MemberInfo.Add(typeof(DateTime)); //AddUpYearMonth
            //����œ]�ŕ���
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod


            serInfo.Serialize(writer, serInfo);
            if (graph is CustPrtPprBlDspRsltWork)
            {
                CustPrtPprBlDspRsltWork temp = (CustPrtPprBlDspRsltWork)graph;

                SetCustPrtPprBlDspRsltWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CustPrtPprBlDspRsltWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CustPrtPprBlDspRsltWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CustPrtPprBlDspRsltWork temp in lst)
                {
                    SetCustPrtPprBlDspRsltWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CustPrtPprBlDspRsltWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  CustPrtPprBlDspRsltWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlDspRsltWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetCustPrtPprBlDspRsltWork(System.IO.BinaryWriter writer, CustPrtPprBlDspRsltWork temp)
        {
            //�O�X�X��c��
            writer.Write(temp.AcpOdrTtl2TmBfBlDmd);
            //�O�X��c��
            writer.Write(temp.LastTimeDemand);
            //�O��c��
            writer.Write(temp.AfCalDemandPrice);
            //�����͈�
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //����œ]�ŕ���
            writer.Write(temp.ConsTaxLayMethod);

        }

        /// <summary>
        ///  CustPrtPprBlDspRsltWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CustPrtPprBlDspRsltWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlDspRsltWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private CustPrtPprBlDspRsltWork GetCustPrtPprBlDspRsltWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            CustPrtPprBlDspRsltWork temp = new CustPrtPprBlDspRsltWork();

            //�O�X�X��c��
            temp.AcpOdrTtl2TmBfBlDmd = reader.ReadInt64();
            //�O�X��c��
            temp.LastTimeDemand = reader.ReadInt64();
            //�O��c��
            temp.AfCalDemandPrice = reader.ReadInt64();
            //�����͈�
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //����œ]�ŕ���
            temp.ConsTaxLayMethod = reader.ReadInt32();


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
        /// <returns>CustPrtPprBlDspRsltWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlDspRsltWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CustPrtPprBlDspRsltWork temp = GetCustPrtPprBlDspRsltWork(reader, serInfo);
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
                    retValue = (CustPrtPprBlDspRsltWork[])lst.ToArray(typeof(CustPrtPprBlDspRsltWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
