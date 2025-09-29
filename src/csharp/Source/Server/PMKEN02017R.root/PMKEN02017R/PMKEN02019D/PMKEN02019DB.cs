using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   PrmSettingPrintResultWork
	/// <summary>
	///                      �D�ǐݒ������o���ʃN���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �D�ǐݒ������o���ʃN���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/13  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class PrmSettingPrintResultWork
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		private string _sectionCode = "";

		/// <summary>���_�K�C�h����</summary>
		/// <remarks>���[�󎚗p</remarks>
		private string _sectionGuideSnm = "";

		/// <summary>���i�����ރR�[�h</summary>
		/// <remarks>��������</remarks>
		private Int32 _goodsMGroup;

		/// <summary>���i�����ޖ���</summary>
		private string _goodsMGroupName = "";

		/// <summary>BL�R�[�h</summary>
		private Int32 _tbsPartsCode;

		/// <summary>BL���i�R�[�h���́i���p�j</summary>
		private string _bLGoodsHalfName = "";

		/// <summary>���i���[�J�[�R�[�h</summary>
		private Int32 _partsMakerCd;

		/// <summary>���[�J�[����</summary>
		private string _makerShortName = "";

		/// <summary>�D�Ǖ\������</summary>
		private Int32 _primeDispOrder;

		/// <summary>�d����R�[�h</summary>
		private Int32 _supplierCd;

		/// <summary>�d���旪��</summary>
		private string _supplierSnm = "";

		/// <summary>�D�ǐݒ�ڍז��̂P</summary>
		private string _prmSetDtlName1 = "";

		/// <summary>�D�ǐݒ�ڍז��̂Q</summary>
		private string _prmSetDtlName2 = "";

		/// <summary>���[�J�[�\������</summary>
		private Int32 _makerDispOrder;

		/// <summary>�D�Ǖ\���敪</summary>
		/// <remarks>0:�����@1:���i&�����@2:���i</remarks>
		private Int32 _primeDisplayCode;


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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  SectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
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
			get{return _sectionGuideSnm;}
			set{_sectionGuideSnm = value;}
		}

		/// public propaty name  :  GoodsMGroup
		/// <summary>���i�����ރR�[�h�v���p�e�B</summary>
		/// <value>��������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsMGroup
		{
			get{return _goodsMGroup;}
			set{_goodsMGroup = value;}
		}

		/// public propaty name  :  GoodsMGroupName
		/// <summary>���i�����ޖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�����ޖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsMGroupName
		{
			get{return _goodsMGroupName;}
			set{_goodsMGroupName = value;}
		}

		/// public propaty name  :  TbsPartsCode
		/// <summary>BL�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TbsPartsCode
		{
			get{return _tbsPartsCode;}
			set{_tbsPartsCode = value;}
		}

		/// public propaty name  :  BLGoodsHalfName
		/// <summary>BL���i�R�[�h���́i���p�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h���́i���p�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BLGoodsHalfName
		{
			get{return _bLGoodsHalfName;}
			set{_bLGoodsHalfName = value;}
		}

		/// public propaty name  :  PartsMakerCd
		/// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PartsMakerCd
		{
			get{return _partsMakerCd;}
			set{_partsMakerCd = value;}
		}

		/// public propaty name  :  MakerShortName
		/// <summary>���[�J�[���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string MakerShortName
		{
			get{return _makerShortName;}
			set{_makerShortName = value;}
		}

		/// public propaty name  :  PrimeDispOrder
		/// <summary>�D�Ǖ\�����ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �D�Ǖ\�����ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrimeDispOrder
		{
			get{return _primeDispOrder;}
			set{_primeDispOrder = value;}
		}

		/// public propaty name  :  SupplierCd
		/// <summary>�d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierCd
		{
			get{return _supplierCd;}
			set{_supplierCd = value;}
		}

		/// public propaty name  :  SupplierSnm
		/// <summary>�d���旪�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���旪�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SupplierSnm
		{
			get{return _supplierSnm;}
			set{_supplierSnm = value;}
		}

		/// public propaty name  :  PrmSetDtlName1
		/// <summary>�D�ǐݒ�ڍז��̂P�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �D�ǐݒ�ڍז��̂P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PrmSetDtlName1
		{
			get{return _prmSetDtlName1;}
			set{_prmSetDtlName1 = value;}
		}

		/// public propaty name  :  PrmSetDtlName2
		/// <summary>�D�ǐݒ�ڍז��̂Q�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �D�ǐݒ�ڍז��̂Q�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PrmSetDtlName2
		{
			get{return _prmSetDtlName2;}
			set{_prmSetDtlName2 = value;}
		}

		/// public propaty name  :  MakerDispOrder
		/// <summary>���[�J�[�\�����ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[�\�����ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MakerDispOrder
		{
			get{return _makerDispOrder;}
			set{_makerDispOrder = value;}
		}

		/// public propaty name  :  PrimeDisplayCode
		/// <summary>�D�Ǖ\���敪�v���p�e�B</summary>
		/// <value>0:�����@1:���i&�����@2:���i</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �D�Ǖ\���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrimeDisplayCode
		{
			get{return _primeDisplayCode;}
			set{_primeDisplayCode = value;}
		}


		/// <summary>
		/// �D�ǐݒ������o���ʃN���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>PrmSettingPrintResultWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PrmSettingPrintResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public PrmSettingPrintResultWork()
		{
		}

	}


    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PrmSettingPrintResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PrmSettingPrintResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PrmSettingPrintResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmSettingPrintResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PrmSettingPrintResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PrmSettingPrintResultWork || graph is ArrayList || graph is PrmSettingPrintResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PrmSettingPrintResultWork).FullName));

            if (graph != null && graph is PrmSettingPrintResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrmSettingPrintResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PrmSettingPrintResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PrmSettingPrintResultWork[])graph).Length;
            }
            else if (graph is PrmSettingPrintResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //���i�����ޖ���
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMGroupName
            //BL�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //BL���i�R�[�h���́i���p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsHalfName
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerShortName
            //�D�Ǖ\������
            serInfo.MemberInfo.Add(typeof(Int32)); //PrimeDispOrder
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�D�ǐݒ�ڍז��̂P
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName1
            //�D�ǐݒ�ڍז��̂Q
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName2
            //���[�J�[�\������
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerDispOrder
            //�D�Ǖ\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PrimeDisplayCode


            serInfo.Serialize(writer, serInfo);
            if (graph is PrmSettingPrintResultWork)
            {
                PrmSettingPrintResultWork temp = (PrmSettingPrintResultWork)graph;

                SetPrmSettingPrintResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PrmSettingPrintResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PrmSettingPrintResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PrmSettingPrintResultWork temp in lst)
                {
                    SetPrmSettingPrintResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PrmSettingPrintResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 16;

        /// <summary>
        ///  PrmSettingPrintResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmSettingPrintResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPrmSettingPrintResultWork(System.IO.BinaryWriter writer, PrmSettingPrintResultWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //���i�����ޖ���
            writer.Write(temp.GoodsMGroupName);
            //BL�R�[�h
            writer.Write(temp.TbsPartsCode);
            //BL���i�R�[�h���́i���p�j
            writer.Write(temp.BLGoodsHalfName);
            //���i���[�J�[�R�[�h
            writer.Write(temp.PartsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerShortName);
            //�D�Ǖ\������
            writer.Write(temp.PrimeDispOrder);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�D�ǐݒ�ڍז��̂P
            writer.Write(temp.PrmSetDtlName1);
            //�D�ǐݒ�ڍז��̂Q
            writer.Write(temp.PrmSetDtlName2);
            //���[�J�[�\������
            writer.Write(temp.MakerDispOrder);
            //�D�Ǖ\���敪
            writer.Write(temp.PrimeDisplayCode);

        }

        /// <summary>
        ///  PrmSettingPrintResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PrmSettingPrintResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmSettingPrintResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PrmSettingPrintResultWork GetPrmSettingPrintResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PrmSettingPrintResultWork temp = new PrmSettingPrintResultWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //���i�����ޖ���
            temp.GoodsMGroupName = reader.ReadString();
            //BL�R�[�h
            temp.TbsPartsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i���p�j
            temp.BLGoodsHalfName = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.PartsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerShortName = reader.ReadString();
            //�D�Ǖ\������
            temp.PrimeDispOrder = reader.ReadInt32();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�D�ǐݒ�ڍז��̂P
            temp.PrmSetDtlName1 = reader.ReadString();
            //�D�ǐݒ�ڍז��̂Q
            temp.PrmSetDtlName2 = reader.ReadString();
            //���[�J�[�\������
            temp.MakerDispOrder = reader.ReadInt32();
            //�D�Ǖ\���敪
            temp.PrimeDisplayCode = reader.ReadInt32();


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
        /// <returns>PrmSettingPrintResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmSettingPrintResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PrmSettingPrintResultWork temp = GetPrmSettingPrintResultWork(reader, serInfo);
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
                    retValue = (PrmSettingPrintResultWork[])lst.ToArray(typeof(PrmSettingPrintResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
