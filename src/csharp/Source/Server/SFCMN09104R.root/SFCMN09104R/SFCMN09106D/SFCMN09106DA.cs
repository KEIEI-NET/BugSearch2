using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   NoMngSetWork
	/// <summary>
	///                      �ԍ��Ǘ��ݒ胏�[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �ԍ��Ǘ��ݒ胏�[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2005/8/30</br>
	/// <br>Genarated Date   :   2005/09/03  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class NoMngSetWork : IFileHeader
	{
		/// <summary>�쐬����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _createDateTime;

		/// <summary>�X�V����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _updateDateTime;

		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>�X�V�]�ƈ��R�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private string _updEmployeeCode = "";

		/// <summary>�X�V�A�Z���u��ID1</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>�X�V�A�Z���u��ID2</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>�_���폜�敪</summary>
		/// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>���_�R�[�h</summary>
		private string _sectionCode = "";

		/// <summary>�ԍ��R�[�h</summary>
		/// <remarks>1:�ڋq����,2:�ԗ��Ǘ��ԍ�,����Â�����(���ڏڍ�)</remarks>
		private Int32 _noCode;

		/// <summary>�ԍ����ݒl</summary>
		/// <remarks>�ԍ����ݒl�܂��͘_���폜ں��ތ���(���ڏڍ�)</remarks>
		private Int64 _noPresentVal;

		/// <summary>�ݒ�J�n�ԍ�</summary>
		private Int64 _settingStartNo;

		/// <summary>�ݒ�I���ԍ�</summary>
		private Int64 _settingEndNo;

		/// <summary>�ԍ�������</summary>
		private Int32 _noIncDecWidth;


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

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUID�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
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

		/// public propaty name  :  NoCode
		/// <summary>�ԍ��R�[�h�v���p�e�B</summary>
		/// <value>1:�ڋq����,2:�ԗ��Ǘ��ԍ�,����Â�����(���ڏڍ�)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԍ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NoCode
		{
			get{return _noCode;}
			set{_noCode = value;}
		}

		/// public propaty name  :  NoPresentVal
		/// <summary>�ԍ����ݒl�v���p�e�B</summary>
		/// <value>�ԍ����ݒl�܂��͘_���폜ں��ތ���(���ڏڍ�)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԍ����ݒl�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 NoPresentVal
		{
			get{return _noPresentVal;}
			set{_noPresentVal = value;}
		}

		/// public propaty name  :  SettingStartNo
		/// <summary>�ݒ�J�n�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ݒ�J�n�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SettingStartNo
		{
			get{return _settingStartNo;}
			set{_settingStartNo = value;}
		}

		/// public propaty name  :  SettingEndNo
		/// <summary>�ݒ�I���ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ݒ�I���ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SettingEndNo
		{
			get{return _settingEndNo;}
			set{_settingEndNo = value;}
		}

		/// public propaty name  :  NoIncDecWidth
		/// <summary>�ԍ��������v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԍ��������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NoIncDecWidth
		{
			get{return _noIncDecWidth;}
			set{_noIncDecWidth = value;}
		}


		/// <summary>
		/// �ԍ��Ǘ��ݒ胏�[�N�R���X�g���N�^
		/// </summary>
		/// <returns>NoMngSetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoMngSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public NoMngSetWork()
		{
		}

	}
	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
	/// </summary>
	/// <returns>NoMngSetWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   NoMngSetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public class NoMngSetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate �����o
	
		/// <summary>
		///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoMngSetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  NoMngSetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
			if(  writer == null )
				throw new ArgumentNullException();

			if( graph != null && !( graph is NoMngSetWork || graph is ArrayList || graph is NoMngSetWork[]) )
				throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof(NoMngSetWork).FullName ) );

			if( graph != null && graph is NoMngSetWork )
			{
				Type t = graph.GetType();
				if( !CustomFormatterServices.NeedCustomSerialization( t ) )
					throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.NoMngSetWork" );

			//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
			int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
			if( graph is ArrayList )
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if( graph is NoMngSetWork[] )
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((NoMngSetWork[])graph).Length;
			}
			else if( graph is NoMngSetWork )
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

			//�쐬����
			serInfo.MemberInfo.Add( typeof(Int64) ); //CreateDateTime
			//�X�V����
			serInfo.MemberInfo.Add( typeof(Int64) ); //UpdateDateTime
			//��ƃR�[�h
			serInfo.MemberInfo.Add( typeof(string) ); //EnterpriseCode
			//GUID
			serInfo.MemberInfo.Add( typeof(byte[]) );  //FileHeaderGuid
			//�X�V�]�ƈ��R�[�h
			serInfo.MemberInfo.Add( typeof(string) ); //UpdEmployeeCode
			//�X�V�A�Z���u��ID1
			serInfo.MemberInfo.Add( typeof(string) ); //UpdAssemblyId1
			//�X�V�A�Z���u��ID2
			serInfo.MemberInfo.Add( typeof(string) ); //UpdAssemblyId2
			//�_���폜�敪
			serInfo.MemberInfo.Add( typeof(Int32) ); //LogicalDeleteCode
			//���_�R�[�h
			serInfo.MemberInfo.Add( typeof(string) ); //SectionCode
			//�ԍ��R�[�h
			serInfo.MemberInfo.Add( typeof(Int32) ); //NoCode
			//�ԍ����ݒl
			serInfo.MemberInfo.Add( typeof(Int64) ); //NoPresentVal
			//�ݒ�J�n�ԍ�
			serInfo.MemberInfo.Add( typeof(Int64) ); //SettingStartNo
			//�ݒ�I���ԍ�
			serInfo.MemberInfo.Add( typeof(Int64) ); //SettingEndNo
			//�ԍ�������
			serInfo.MemberInfo.Add( typeof(Int32) ); //NoIncDecWidth

			
			serInfo.Serialize( writer, serInfo );
			if( graph is NoMngSetWork )
			{
				NoMngSetWork temp = (NoMngSetWork)graph;

				SetNoMngSetWork(writer, temp);
			}
			else
			{
				ArrayList lst= null;
				if(graph is NoMngSetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((NoMngSetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;	
				}

				foreach(NoMngSetWork temp in lst)
				{
					SetNoMngSetWork(writer, temp);
				}

			}

		
		}


		/// <summary>
		/// NoMngSetWork�����o��(public�v���p�e�B��)
		/// </summary>
		private const int currentMemberCount = 14;
		
		/// <summary>
		///  NoMngSetWork�C���X�^���X��������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoMngSetWork�̃C���X�^���X����������</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private void SetNoMngSetWork( System.IO.BinaryWriter writer, NoMngSetWork temp )
		{
			//�쐬����
			writer.Write( (Int64)temp.CreateDateTime.Ticks );
			//�X�V����
			writer.Write( (Int64)temp.UpdateDateTime.Ticks );
			//��ƃR�[�h
			writer.Write( temp.EnterpriseCode );
			//GUID
			byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
			writer.Write( fileHeaderGuidArray.Length );
			writer.Write( temp.FileHeaderGuid.ToByteArray() );
			//�X�V�]�ƈ��R�[�h
			writer.Write( temp.UpdEmployeeCode );
			//�X�V�A�Z���u��ID1
			writer.Write( temp.UpdAssemblyId1 );
			//�X�V�A�Z���u��ID2
			writer.Write( temp.UpdAssemblyId2 );
			//�_���폜�敪
			writer.Write( temp.LogicalDeleteCode );
			//���_�R�[�h
			writer.Write( temp.SectionCode );
			//�ԍ��R�[�h
			writer.Write( temp.NoCode );
			//�ԍ����ݒl
			writer.Write( temp.NoPresentVal );
			//�ݒ�J�n�ԍ�
			writer.Write( temp.SettingStartNo );
			//�ݒ�I���ԍ�
			writer.Write( temp.SettingEndNo );
			//�ԍ�������
			writer.Write( temp.NoIncDecWidth );

		}

		/// <summary>
		///  NoMngSetWork�C���X�^���X�擾
		/// </summary>
		/// <returns>NoMngSetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoMngSetWork�̃C���X�^���X���擾���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private NoMngSetWork GetNoMngSetWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
		{
			// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
			// serInfo.MemberInfo.Count < currentMemberCount
			// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

			NoMngSetWork temp = new NoMngSetWork();

			//�쐬����
			temp.CreateDateTime = new DateTime(reader.ReadInt64());
			//�X�V����
			temp.UpdateDateTime = new DateTime(reader.ReadInt64());
			//��ƃR�[�h
			temp.EnterpriseCode = reader.ReadString();
			//GUID
			int lenOfFileHeaderGuidArray = reader.ReadInt32();
			byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
			temp.FileHeaderGuid = new Guid( fileHeaderGuidArray );
			//�X�V�]�ƈ��R�[�h
			temp.UpdEmployeeCode = reader.ReadString();
			//�X�V�A�Z���u��ID1
			temp.UpdAssemblyId1 = reader.ReadString();
			//�X�V�A�Z���u��ID2
			temp.UpdAssemblyId2 = reader.ReadString();
			//�_���폜�敪
			temp.LogicalDeleteCode = reader.ReadInt32();
			//���_�R�[�h
			temp.SectionCode = reader.ReadString();
			//�ԍ��R�[�h
			temp.NoCode = reader.ReadInt32();
			//�ԍ����ݒl
			temp.NoPresentVal = reader.ReadInt64();
			//�ݒ�J�n�ԍ�
			temp.SettingStartNo = reader.ReadInt64();
			//�ݒ�I���ԍ�
			temp.SettingEndNo = reader.ReadInt64();
			//�ԍ�������
			temp.NoIncDecWidth = reader.ReadInt32();

			
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
		/// <returns>NoMngSetWork�N���X�̃C���X�^���X(object)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoMngSetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
			ArrayList lst = new ArrayList();
			for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
			{
				NoMngSetWork temp = GetNoMngSetWork( reader, serInfo );
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
					retValue = (NoMngSetWork[])lst.ToArray(typeof(NoMngSetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}
