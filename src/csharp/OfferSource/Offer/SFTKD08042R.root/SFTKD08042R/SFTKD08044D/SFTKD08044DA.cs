using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   UserGdHdWork
	/// <summary>
	///                      ���[�U�[�K�C�h�}�X�^�i�w�b�_�j���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���[�U�[�K�C�h�}�X�^�i�w�b�_�j���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2005/03/30</br>
	/// <br>Genarated Date   :   2006/04/13  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2006/4/7  ����@���j</br>
	/// <br>                 :   ���ʃt�@�C���w�b�_�ύX�i���ڍ폜�j</br>
	/// <br>                 :   �E��ƃR�[�h</br>
	/// <br>                 :   �EGUID</br>
	/// <br>                 :   �E�X�V�]�ƈ��R�[�h</br>
	/// <br>                 :   �E�X�V�A�Z���u��ID1</br>
	/// <br>                 :   �E�X�V�A�Z���u��ID2</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class UserGdHdWork : IFileHeaderOffer
	{
		/// <summary>�쐬����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _createDateTime;

		/// <summary>�X�V����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _updateDateTime;

		/// <summary>�_���폜�敪</summary>
		/// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>���[�U�[�K�C�h�敪</summary>
		/// <remarks>1:���������N,2:DM�敪,3:���ɑ��iDM����Â�����</remarks>
		private Int32 _userGuideDivCd;

		/// <summary>���[�U�[�K�C�h�敪����</summary>
		private string _userGuideDivNm = "";

		/// <summary>�}�X�^�񋟋敪</summary>
		/// <remarks>0:��,1:������</remarks>
		private Int32 _masterOfferCd;


		/// public propaty name  :  CreateDateTime
		/// <summary>�쐬�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
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
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>�_���폜�敪�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �_���폜�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

		/// public propaty name  :  UserGuideDivCd
		/// <summary>���[�U�[�K�C�h�敪�v���p�e�B</summary>
		/// <value>1:���������N,2:DM�敪,3:���ɑ��iDM����Â�����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�U�[�K�C�h�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UserGuideDivCd
		{
			get{return _userGuideDivCd;}
			set{_userGuideDivCd = value;}
		}

		/// public propaty name  :  UserGuideDivNm
		/// <summary>���[�U�[�K�C�h�敪���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�U�[�K�C�h�敪���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UserGuideDivNm
		{
			get{return _userGuideDivNm;}
			set{_userGuideDivNm = value;}
		}

		/// public propaty name  :  MasterOfferCd
		/// <summary>�}�X�^�񋟋敪�v���p�e�B</summary>
		/// <value>0:��,1:������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �}�X�^�񋟋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MasterOfferCd
		{
			get{return _masterOfferCd;}
			set{_masterOfferCd = value;}
		}


		/// <summary>
		/// ���[�U�[�K�C�h�}�X�^�i�w�b�_�j���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>UserGdHdWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UserGdHdWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public UserGdHdWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
	/// </summary>
	/// <returns>UserGdHdWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   UserGdHdWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public class UserGdHdWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate �����o
	
		/// <summary>
		///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UserGdHdWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  UserGdHdWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
			if(  writer == null )
				throw new ArgumentNullException();

			if( graph != null && !( graph is UserGdHdWork || graph is ArrayList || graph is UserGdHdWork[]) )
				throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof(UserGdHdWork).FullName ) );

			if( graph != null && graph is UserGdHdWork )
			{
				Type t = graph.GetType();
				if( !CustomFormatterServices.NeedCustomSerialization( t ) )
					throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.UserGdHdWork" );

			//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
			int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
			if( graph is ArrayList )
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if( graph is UserGdHdWork[] )
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((UserGdHdWork[])graph).Length;
			}
			else if( graph is UserGdHdWork )
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

			//�쐬����
			serInfo.MemberInfo.Add( typeof(Int64) ); //CreateDateTime
			//�X�V����
			serInfo.MemberInfo.Add( typeof(Int64) ); //UpdateDateTime
			//�_���폜�敪
			serInfo.MemberInfo.Add( typeof(Int32) ); //LogicalDeleteCode
			//���[�U�[�K�C�h�敪
			serInfo.MemberInfo.Add( typeof(Int32) ); //UserGuideDivCd
			//���[�U�[�K�C�h�敪����
			serInfo.MemberInfo.Add( typeof(string) ); //UserGuideDivNm
			//�}�X�^�񋟋敪
			serInfo.MemberInfo.Add( typeof(Int32) ); //MasterOfferCd

			
			serInfo.Serialize( writer, serInfo );
			if( graph is UserGdHdWork )
			{
				UserGdHdWork temp = (UserGdHdWork)graph;

				SetUserGdHdWork(writer, temp);
			}
			else
			{
				ArrayList lst= null;
				if(graph is UserGdHdWork[])
				{
					lst = new ArrayList();
					lst.AddRange((UserGdHdWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;	
				}

				foreach(UserGdHdWork temp in lst)
				{
					SetUserGdHdWork(writer, temp);
				}

			}

		
		}


		/// <summary>
		/// UserGdHdWork�����o��(public�v���p�e�B��)
		/// </summary>
		private const int currentMemberCount = 6;
		
		/// <summary>
		///  UserGdHdWork�C���X�^���X��������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UserGdHdWork�̃C���X�^���X����������</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private void SetUserGdHdWork( System.IO.BinaryWriter writer, UserGdHdWork temp )
		{
			//�쐬����
			writer.Write( (Int64)temp.CreateDateTime.Ticks );
			//�X�V����
			writer.Write( (Int64)temp.UpdateDateTime.Ticks );
			//�_���폜�敪
			writer.Write( temp.LogicalDeleteCode );
			//���[�U�[�K�C�h�敪
			writer.Write( temp.UserGuideDivCd );
			//���[�U�[�K�C�h�敪����
			writer.Write( temp.UserGuideDivNm );
			//�}�X�^�񋟋敪
			writer.Write( temp.MasterOfferCd );

		}

		/// <summary>
		///  UserGdHdWork�C���X�^���X�擾
		/// </summary>
		/// <returns>UserGdHdWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UserGdHdWork�̃C���X�^���X���擾���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private UserGdHdWork GetUserGdHdWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
		{
			// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
			// serInfo.MemberInfo.Count < currentMemberCount
			// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

			UserGdHdWork temp = new UserGdHdWork();

			//�쐬����
			temp.CreateDateTime = new DateTime(reader.ReadInt64());
			//�X�V����
			temp.UpdateDateTime = new DateTime(reader.ReadInt64());
			//�_���폜�敪
			temp.LogicalDeleteCode = reader.ReadInt32();
			//���[�U�[�K�C�h�敪
			temp.UserGuideDivCd = reader.ReadInt32();
			//���[�U�[�K�C�h�敪����
			temp.UserGuideDivNm = reader.ReadString();
			//�}�X�^�񋟋敪
			temp.MasterOfferCd = reader.ReadInt32();

			
			//�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
			//�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
			//�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
			//�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
			for( int k = currentMemberCount ; k < serInfo.MemberInfo.Count ; ++k )
			{
				//byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
				//�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
				//�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
				//�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
				int optCount = 0;   
				object oMemberType = serInfo.MemberInfo[k];
				if( oMemberType is Type )
				{
					Type t = (Type)oMemberType;
					object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
					if( t.Equals( typeof(int) ) )
					{
						optCount = Convert.ToInt32(oData);
					}
					else
					{
						optCount = 0;
					}
				}
				else if( oMemberType is string )
				{
					Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
					object userData = formatter.Deserialize( reader );  //�ǂݔ�΂�
				}
			}
			return temp;
		}

		/// <summary>
		///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
		/// </summary>
		/// <returns>UserGdHdWork�N���X�̃C���X�^���X(object)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UserGdHdWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
			ArrayList lst = new ArrayList();
			for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
			{
				UserGdHdWork temp = GetUserGdHdWork( reader, serInfo );
				lst.Add( temp );
			}
			switch(serInfo.RetTypeInfo)
			{
				case 0:
					retValue = lst;
					break;
				case 1:
					retValue = lst[0];
					break;
				case 2:
					retValue = (UserGdHdWork[])lst.ToArray(typeof(UserGdHdWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}
