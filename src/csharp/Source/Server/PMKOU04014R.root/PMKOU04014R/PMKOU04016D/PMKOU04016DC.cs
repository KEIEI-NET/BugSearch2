using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SuppPrtPprBlDspRsltWork
    /// <summary>
    ///                      �d����d�q�������o����(�c���Ɖ�)�N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d����d�q�������o����(�c���Ɖ�)�N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SuppPrtPprBlDspRsltWork
    {
        /// <summary>�O�X�X��c��</summary>
        /// <remarks>�d��2��O�c���i�x���v�j</remarks>
        private Int64 _stockTtl2TmBfBlPay;

        /// <summary>�O�X��c��</summary>
        /// <remarks>�O��x�����z</remarks>
        private Int64 _lastTimePayment;

        /// <summary>�O��c��</summary>
        /// <remarks>�d�����v�c���i�x���v�j</remarks>
        private Int64 _stockTotalPayBalance;

        /// <summary>�����͈�</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>����œ]�ŕ���</summary>
        /// <remarks>�d�������œ]�ŕ����R�[�h(0:�`�[�P�� 1:���גP�� 2:�����P�ʁi������j3:�����P�ʁi���Ӑ�j9:��ې�)</remarks>
        private Int32 _suppCTaxationCd;


        /// public propaty name  :  StockTtl2TmBfBlPay
        /// <summary>�O�X�X��c���v���p�e�B</summary>
        /// <value>�d��2��O�c���i�x���v�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�X�X��c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTtl2TmBfBlPay
        {
            get { return _stockTtl2TmBfBlPay; }
            set { _stockTtl2TmBfBlPay = value; }
        }

        /// public propaty name  :  LastTimePayment
        /// <summary>�O�X��c���v���p�e�B</summary>
        /// <value>�O��x�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�X��c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 LastTimePayment
        {
            get { return _lastTimePayment; }
            set { _lastTimePayment = value; }
        }

        /// public propaty name  :  StockTotalPayBalance
        /// <summary>�O��c���v���p�e�B</summary>
        /// <value>�d�����v�c���i�x���v�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O��c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalPayBalance
        {
            get { return _stockTotalPayBalance; }
            set { _stockTotalPayBalance = value; }
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

        /// public propaty name  :  SuppCTaxationCd
        /// <summary>����œ]�ŕ����v���p�e�B</summary>
        /// <value>�d�������œ]�ŕ����R�[�h(0:�`�[�P�� 1:���גP�� 2:�����P�ʁi������j3:�����P�ʁi���Ӑ�j9:��ې�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����œ]�ŕ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppCTaxationCd
        {
            get { return _suppCTaxationCd; }
            set { _suppCTaxationCd = value; }
        }


        /// <summary>
        /// �d����d�q�������o����(�c���Ɖ�)�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SuppPrtPprBlDspRsltWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlDspRsltWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SuppPrtPprBlDspRsltWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SuppPrtPprBlDspRsltWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlDspRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SuppPrtPprBlDspRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlDspRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SuppPrtPprBlDspRsltWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SuppPrtPprBlDspRsltWork || graph is ArrayList || graph is SuppPrtPprBlDspRsltWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SuppPrtPprBlDspRsltWork).FullName));

            if (graph != null && graph is SuppPrtPprBlDspRsltWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprBlDspRsltWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SuppPrtPprBlDspRsltWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SuppPrtPprBlDspRsltWork[])graph).Length;
            }
            else if (graph is SuppPrtPprBlDspRsltWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�O�X�X��c��
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtl2TmBfBlPay
            //�O�X��c��
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimePayment
            //�O��c��
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPayBalance
            //�����͈�
            serInfo.MemberInfo.Add(typeof(DateTime)); //AddUpYearMonth
            //����œ]�ŕ���
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxationCd


            serInfo.Serialize(writer, serInfo);
            if (graph is SuppPrtPprBlDspRsltWork)
            {
                SuppPrtPprBlDspRsltWork temp = (SuppPrtPprBlDspRsltWork)graph;

                SetSuppPrtPprBlDspRsltWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SuppPrtPprBlDspRsltWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SuppPrtPprBlDspRsltWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SuppPrtPprBlDspRsltWork temp in lst)
                {
                    SetSuppPrtPprBlDspRsltWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SuppPrtPprBlDspRsltWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  SuppPrtPprBlDspRsltWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlDspRsltWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSuppPrtPprBlDspRsltWork(System.IO.BinaryWriter writer, SuppPrtPprBlDspRsltWork temp)
        {
            //�O�X�X��c��
            writer.Write(temp.StockTtl2TmBfBlPay);
            //�O�X��c��
            writer.Write(temp.LastTimePayment);
            //�O��c��
            writer.Write(temp.StockTotalPayBalance);
            //�����͈�
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //����œ]�ŕ���
            writer.Write(temp.SuppCTaxationCd);

        }

        /// <summary>
        ///  SuppPrtPprBlDspRsltWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SuppPrtPprBlDspRsltWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlDspRsltWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SuppPrtPprBlDspRsltWork GetSuppPrtPprBlDspRsltWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SuppPrtPprBlDspRsltWork temp = new SuppPrtPprBlDspRsltWork();

            //�O�X�X��c��
            temp.StockTtl2TmBfBlPay = reader.ReadInt64();
            //�O�X��c��
            temp.LastTimePayment = reader.ReadInt64();
            //�O��c��
            temp.StockTotalPayBalance = reader.ReadInt64();
            //�����͈�
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //����œ]�ŕ���
            temp.SuppCTaxationCd = reader.ReadInt32();


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
        /// <returns>SuppPrtPprBlDspRsltWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlDspRsltWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SuppPrtPprBlDspRsltWork temp = GetSuppPrtPprBlDspRsltWork(reader, serInfo);
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
                    retValue = (SuppPrtPprBlDspRsltWork[])lst.ToArray(typeof(SuppPrtPprBlDspRsltWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
