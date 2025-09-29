using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
 	/// public class name:   PrmSettingChgWork
	/// <summary>
	///                      �D�ǐݒ�ύX���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �D�ǐݒ�ύX���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   1/5</br>
	/// <br>Genarated Date   :   2009/01/20  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class PrmSettingChgWork
	{
		/// <summary>�񋟓��t</summary>
		/// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

		/// <summary>���i�����ރR�[�h</summary>
		private Int32 _goodsMGroup;

		/// <summary>���i���[�J�[�R�[�h</summary>
		private Int32 _partsMakerCd;

		/// <summary>BL�R�[�h</summary>
		private Int32 _tbsPartsCode;

		/// <summary>BL�R�[�h�}��</summary>
		/// <remarks>�����g�p���ځi���C�A�E�g�ɂ͓���Ă����j</remarks>
		private Int32 _tbsPartsCdDerivedNo;

		/// <summary>�D�ǐݒ�ڍ׃R�[�h�P</summary>
		private Int32 _prmSetDtlNo1;

		/// <summary>�D�ǐݒ�ڍ׃R�[�h�Q</summary>
		private Int32 _prmSetDtlNo2;

		/// <summary>�ύX��D�ǐݒ�ڍ׃R�[�h�P</summary>
		/// <remarks>-1�̎��ύX�ΏۊO</remarks>
		private Int32 _afPrmSetDtlNo1;

		/// <summary>�ύX��D�ǐݒ�ڍ׃R�[�h�Q</summary>
		/// <remarks>-1�̎��ύX�ΏۊO</remarks>
		private Int32 _afPrmSetDtlNo2;

		/// <summary>�ύX��D�Ǖ\���敪</summary>
		/// <remarks>1:���i&�����@2:���i (-1�̎��ύX�ΏۊO)</remarks>
		private Int32 _afPrimeDisplayCode;

		/// <summary>�����敪</summary>
		/// <remarks>0:�ύX 1:�폜</remarks>
		private Int32 _procDivCd;


		/// public propaty name  :  OfferDate
		/// <summary>�񋟓��t�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񋟓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Int32 OfferDate
		{
			get{return _offerDate;}
			set{_offerDate = value;}
		}

		/// public propaty name  :  GoodsMGroup
		/// <summary>���i�����ރR�[�h�v���p�e�B</summary>
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

		/// public propaty name  :  TbsPartsCdDerivedNo
		/// <summary>BL�R�[�h�}�ԃv���p�e�B</summary>
		/// <value>�����g�p���ځi���C�A�E�g�ɂ͓���Ă����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL�R�[�h�}�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TbsPartsCdDerivedNo
		{
			get{return _tbsPartsCdDerivedNo;}
			set{_tbsPartsCdDerivedNo = value;}
		}

		/// public propaty name  :  PrmSetDtlNo1
		/// <summary>�D�ǐݒ�ڍ׃R�[�h�P�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �D�ǐݒ�ڍ׃R�[�h�P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrmSetDtlNo1
		{
			get{return _prmSetDtlNo1;}
			set{_prmSetDtlNo1 = value;}
		}

		/// public propaty name  :  PrmSetDtlNo2
		/// <summary>�D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrmSetDtlNo2
		{
			get{return _prmSetDtlNo2;}
			set{_prmSetDtlNo2 = value;}
		}

		/// public propaty name  :  AfPrmSetDtlNo1
		/// <summary>�ύX��D�ǐݒ�ڍ׃R�[�h�P�v���p�e�B</summary>
		/// <value>-1�̎��ύX�ΏۊO</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ύX��D�ǐݒ�ڍ׃R�[�h�P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AfPrmSetDtlNo1
		{
			get{return _afPrmSetDtlNo1;}
			set{_afPrmSetDtlNo1 = value;}
		}

		/// public propaty name  :  AfPrmSetDtlNo2
		/// <summary>�ύX��D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</summary>
		/// <value>-1�̎��ύX�ΏۊO</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ύX��D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AfPrmSetDtlNo2
		{
			get{return _afPrmSetDtlNo2;}
			set{_afPrmSetDtlNo2 = value;}
		}

		/// public propaty name  :  AfPrimeDisplayCode
		/// <summary>�ύX��D�Ǖ\���敪�v���p�e�B</summary>
		/// <value>1:���i&�����@2:���i (-1�̎��ύX�ΏۊO)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ύX��D�Ǖ\���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AfPrimeDisplayCode
		{
			get{return _afPrimeDisplayCode;}
			set{_afPrimeDisplayCode = value;}
		}

		/// public propaty name  :  ProcDivCd
		/// <summary>�����敪�v���p�e�B</summary>
		/// <value>0:�ύX 1:�폜</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ProcDivCd
		{
			get{return _procDivCd;}
			set{_procDivCd = value;}
		}


		/// <summary>
		/// �D�ǐݒ�ύX���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>PrmSettingChgWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PrmSettingChgWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public PrmSettingChgWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PrmSettingChgWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PrmSettingChgWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PrmSettingChgWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmSettingChgWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
	{
		// TODO:  PrmSettingChgWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
		if(  writer == null )
			throw new ArgumentNullException();

		if( graph != null && !( graph is PrmSettingChgWork || graph is ArrayList || graph is PrmSettingChgWork[]) )
			throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof(PrmSettingChgWork).FullName ) );

		if( graph != null && graph is PrmSettingChgWork )
		{
			Type t = graph.GetType();
			if( !CustomFormatterServices.NeedCustomSerialization( t ) )
				throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
		}

		//SerializationTypeInfo
		Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrmSettingChgWork" );

		//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
		int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
		if( graph is ArrayList )
		{
			serInfo.RetTypeInfo = 0;
			occurrence = ((ArrayList)graph).Count;
		}else if( graph is PrmSettingChgWork[] )
		{
			serInfo.RetTypeInfo = 2;
			occurrence = ((PrmSettingChgWork[])graph).Length;
		}
		else if( graph is PrmSettingChgWork )
		{
			serInfo.RetTypeInfo = 1;
			occurrence = 1;
		}

		serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

		//�񋟓��t
		serInfo.MemberInfo.Add( typeof(Int32) ); //OfferDate
		//���i�����ރR�[�h
		serInfo.MemberInfo.Add( typeof(Int32) ); //GoodsMGroup
		//���i���[�J�[�R�[�h
		serInfo.MemberInfo.Add( typeof(Int32) ); //PartsMakerCd
		//BL�R�[�h
        serInfo.MemberInfo.Add( typeof(Int32) ); //TbsPartsCode
		//BL�R�[�h�}��
		serInfo.MemberInfo.Add( typeof(Int32) ); //TbsPartsCdDerivedNo
		//�D�ǐݒ�ڍ׃R�[�h�P
		serInfo.MemberInfo.Add( typeof(Int32) ); //PrmSetDtlNo1
		//�D�ǐݒ�ڍ׃R�[�h�Q
		serInfo.MemberInfo.Add( typeof(Int32) ); //PrmSetDtlNo2
		//�ύX��D�ǐݒ�ڍ׃R�[�h�P
		serInfo.MemberInfo.Add( typeof(Int32) ); //AfPrmSetDtlNo1
		//�ύX��D�ǐݒ�ڍ׃R�[�h�Q
		serInfo.MemberInfo.Add( typeof(Int32) ); //AfPrmSetDtlNo2
		//�ύX��D�Ǖ\���敪
		serInfo.MemberInfo.Add( typeof(Int32) ); //AfPrimeDisplayCode
		//�����敪
		serInfo.MemberInfo.Add( typeof(Int32) ); //ProcDivCd

			
		serInfo.Serialize( writer, serInfo );
		if( graph is PrmSettingChgWork )
		{
			PrmSettingChgWork temp = (PrmSettingChgWork)graph;

			SetPrmSettingChgWork(writer, temp);
		}
		else
		{
			ArrayList lst= null;
			if(graph is PrmSettingChgWork[])
			{
				lst = new ArrayList();
				lst.AddRange((PrmSettingChgWork[])graph);
			}
			else
			{
				lst = (ArrayList)graph;	
			}

			foreach(PrmSettingChgWork temp in lst)
			{
				SetPrmSettingChgWork(writer, temp);
			}

		}

		
	}


        /// <summary>
        /// PrmSettingChgWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 11;

        /// <summary>
        ///  PrmSettingChgWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmSettingChgWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPrmSettingChgWork(System.IO.BinaryWriter writer, PrmSettingChgWork temp)
        {
            //�񋟓��t
            writer.Write(temp.OfferDate);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //���i���[�J�[�R�[�h
            writer.Write(temp.PartsMakerCd);
            //BL�R�[�h
            writer.Write(temp.TbsPartsCode);
            //BL�R�[�h�}��
            writer.Write(temp.TbsPartsCdDerivedNo);
            //�D�ǐݒ�ڍ׃R�[�h�P
            writer.Write(temp.PrmSetDtlNo1);
            //�D�ǐݒ�ڍ׃R�[�h�Q
            writer.Write(temp.PrmSetDtlNo2);
            //�ύX��D�ǐݒ�ڍ׃R�[�h�P
            writer.Write(temp.AfPrmSetDtlNo1);
            //�ύX��D�ǐݒ�ڍ׃R�[�h�Q
            writer.Write(temp.AfPrmSetDtlNo2);
            //�ύX��D�Ǖ\���敪
            writer.Write(temp.AfPrimeDisplayCode);
            //�����敪
            writer.Write(temp.ProcDivCd);

        }

        /// <summary>
        ///  PrmSettingChgWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PrmSettingChgWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmSettingChgWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PrmSettingChgWork GetPrmSettingChgWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PrmSettingChgWork temp = new PrmSettingChgWork();

            //�񋟓��t
            temp.OfferDate = reader.ReadInt32();
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.PartsMakerCd = reader.ReadInt32();
            //BL�R�[�h
            temp.TbsPartsCode = reader.ReadInt32();
            //BL�R�[�h�}��
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //�D�ǐݒ�ڍ׃R�[�h�P
            temp.PrmSetDtlNo1 = reader.ReadInt32();
            //�D�ǐݒ�ڍ׃R�[�h�Q
            temp.PrmSetDtlNo2 = reader.ReadInt32();
            //�ύX��D�ǐݒ�ڍ׃R�[�h�P
            temp.AfPrmSetDtlNo1 = reader.ReadInt32();
            //�ύX��D�ǐݒ�ڍ׃R�[�h�Q
            temp.AfPrmSetDtlNo2 = reader.ReadInt32();
            //�ύX��D�Ǖ\���敪
            temp.AfPrimeDisplayCode = reader.ReadInt32();
            //�����敪
            temp.ProcDivCd = reader.ReadInt32();


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
        /// <returns>PrmSettingChgWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmSettingChgWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PrmSettingChgWork temp = GetPrmSettingChgWork(reader, serInfo);
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
                    retValue = (PrmSettingChgWork[])lst.ToArray(typeof(PrmSettingChgWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
