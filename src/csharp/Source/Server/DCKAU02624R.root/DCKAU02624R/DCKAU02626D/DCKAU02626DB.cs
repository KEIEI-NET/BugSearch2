using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RsltInfo_AccRecConsTaxDiffWork
    /// <summary>
    ///                      ���|�c���������o���ʃ��[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���|�c���������o���ʃ��[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RsltInfo_AccRecConsTaxDiffWork
    {
        /// <summary>���ьv�㋒�_�R�[�h</summary>
        /// <remarks>���ьv����s����Ɠ��̋��_�R�[�h</remarks>
        private string _resultsAddUpSecCd = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>������t</summary>
        private DateTime _salesDate;

        /// <summary>������R�[�h</summary>
        private Int32 _claimCode;

        /// <summary>�����旪��</summary>
        private string _claimSnm = "";

        /// <summary>���㏬�v�i�Łj</summary>
        /// <remarks>�O�őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j</remarks>
        private Int64 _salesSubtotalTax;

        /// <summary>���㏤�i�敪</summary>
        private Int32 _salesGoodsCd;

        /// <summary>����Ŕ��l</summary>
        private string _taxNote = "";


        /// public propaty name  :  ResultsAddUpSecCd
        /// <summary>���ьv�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>���ьv����s����Ɠ��̋��_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ьv�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ResultsAddUpSecCd
        {
            get { return _resultsAddUpSecCd; }
            set { _resultsAddUpSecCd = value; }
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

        /// public propaty name  :  SalesDate
        /// <summary>������t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        /// public propaty name  :  ClaimSnm
        /// <summary>�����旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimSnm
        {
            get { return _claimSnm; }
            set { _claimSnm = value; }
        }

        /// public propaty name  :  SalesSubtotalTax
        /// <summary>���㏬�v�i�Łj�v���p�e�B</summary>
        /// <value>�O�őΏۋ��z�̏W�v�i�Ŕ��A�l���܂܂��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏬�v�i�Łj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesSubtotalTax
        {
            get { return _salesSubtotalTax; }
            set { _salesSubtotalTax = value; }
        }

        /// public propaty name  :  SalesGoodsCd
        /// <summary>���㏤�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㏤�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesGoodsCd
        {
            get { return _salesGoodsCd; }
            set { _salesGoodsCd = value; }
        }

        /// public propaty name  :  TaxNote
        /// <summary>����Ŕ��l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Ŕ��l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TaxNote
        {
            get { return _taxNote; }
            set { _taxNote = value; }
        }


        /// <summary>
        /// ���|�c���������o���ʃ��[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RsltInfo_AccRecConsTaxDiffWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_AccRecConsTaxDiffWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RsltInfo_AccRecConsTaxDiffWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RsltInfo_AccRecConsTaxDiffWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RsltInfo_AccRecConsTaxDiffWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RsltInfo_AccRecConsTaxDiffWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_AccRecConsTaxDiffWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RsltInfo_AccRecConsTaxDiffWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RsltInfo_AccRecConsTaxDiffWork || graph is ArrayList || graph is RsltInfo_AccRecConsTaxDiffWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RsltInfo_AccRecConsTaxDiffWork).FullName));

            if (graph != null && graph is RsltInfo_AccRecConsTaxDiffWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RsltInfo_AccRecConsTaxDiffWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RsltInfo_AccRecConsTaxDiffWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RsltInfo_AccRecConsTaxDiffWork[])graph).Length;
            }
            else if (graph is RsltInfo_AccRecConsTaxDiffWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���ьv�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ResultsAddUpSecCd
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //������t
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //�����旪��
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //���㏬�v�i�Łj
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSubtotalTax
            //���㏤�i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesGoodsCd
            //����Ŕ��l
            serInfo.MemberInfo.Add(typeof(string)); //TaxNote


            serInfo.Serialize(writer, serInfo);
            if (graph is RsltInfo_AccRecConsTaxDiffWork)
            {
                RsltInfo_AccRecConsTaxDiffWork temp = (RsltInfo_AccRecConsTaxDiffWork)graph;

                SetRsltInfo_AccRecConsTaxDiffWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RsltInfo_AccRecConsTaxDiffWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RsltInfo_AccRecConsTaxDiffWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RsltInfo_AccRecConsTaxDiffWork temp in lst)
                {
                    SetRsltInfo_AccRecConsTaxDiffWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RsltInfo_AccRecConsTaxDiffWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 8;

        /// <summary>
        ///  RsltInfo_AccRecConsTaxDiffWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_AccRecConsTaxDiffWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRsltInfo_AccRecConsTaxDiffWork(System.IO.BinaryWriter writer, RsltInfo_AccRecConsTaxDiffWork temp)
        {
            //���ьv�㋒�_�R�[�h
            writer.Write(temp.ResultsAddUpSecCd);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //������t
            writer.Write((Int64)temp.SalesDate.Ticks);
            //������R�[�h
            writer.Write(temp.ClaimCode);
            //�����旪��
            writer.Write(temp.ClaimSnm);
            //���㏬�v�i�Łj
            writer.Write(temp.SalesSubtotalTax);
            //���㏤�i�敪
            writer.Write(temp.SalesGoodsCd);
            //����Ŕ��l
            writer.Write(temp.TaxNote);

        }

        /// <summary>
        ///  RsltInfo_AccRecConsTaxDiffWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RsltInfo_AccRecConsTaxDiffWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_AccRecConsTaxDiffWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RsltInfo_AccRecConsTaxDiffWork GetRsltInfo_AccRecConsTaxDiffWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RsltInfo_AccRecConsTaxDiffWork temp = new RsltInfo_AccRecConsTaxDiffWork();

            //���ьv�㋒�_�R�[�h
            temp.ResultsAddUpSecCd = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //�v����t
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //������R�[�h
            temp.ClaimCode = reader.ReadInt32();
            //�����旪��
            temp.ClaimSnm = reader.ReadString();
            //���㏬�v�i�Łj
            temp.SalesSubtotalTax = reader.ReadInt64();
            //���㏤�i�敪
            temp.SalesGoodsCd = reader.ReadInt32();
            //����Ŕ��l
            temp.TaxNote = reader.ReadString();


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
        /// <returns>RsltInfo_AccRecConsTaxDiffWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_AccRecConsTaxDiffWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RsltInfo_AccRecConsTaxDiffWork temp = GetRsltInfo_AccRecConsTaxDiffWork(reader, serInfo);
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
                    retValue = (RsltInfo_AccRecConsTaxDiffWork[])lst.ToArray(typeof(RsltInfo_AccRecConsTaxDiffWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
