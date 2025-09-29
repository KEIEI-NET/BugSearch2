using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   NoteGuidHdWork
	/// <summary>
	///                      ���l�K�C�h�}�X�^�i�w�b�_�j���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���l�K�C�h�}�X�^�i�w�b�_�j���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2005/03/30</br>
	/// <br>Genarated Date   :   2005/08/02  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008.09.17 men �����񏉊����������Ă����ׂɒǉ�</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class NoteGuidHdWork : IFileHeader
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

		/// <summary>���l�K�C�h�敪</summary>
		/// <remarks>1�`100:�ڋq���l,101�`200:�ԗ����l</remarks>
		private Int32 _noteGuideDivCode;

		/// <summary>���l�K�C�h�敪����</summary>
		private string _noteGuideDivName = "";			// 2008.09.17 men chg


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

		/// public propaty name  :  NoteGuideDivCode
		/// <summary>���l�K�C�h�敪�v���p�e�B</summary>
		/// <value>1�`100:�ڋq���l,101�`200:�ԗ����l</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���l�K�C�h�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NoteGuideDivCode
		{
			get{return _noteGuideDivCode;}
			set{_noteGuideDivCode  = value;}
		}

		/// public propaty name  :  NoteGuideDivName
		/// <summary>���l�K�C�h�敪���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���l�K�C�h�敪���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string NoteGuideDivName
		{
			get{return _noteGuideDivName;}
			set{_noteGuideDivName  = value;}
		}


		/// <summary>
		/// ���l�K�C�h�}�X�^�i�w�b�_�j���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>NoteGuidHdWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoteGuidHdWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public NoteGuidHdWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
	/// </summary>
	/// <returns>NoteGuidHdWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   NoteGuidHdWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public class NoteGuidHdWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate �����o
	
		/// <summary>
		///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoteGuidHdWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  NoteGuidHdWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
			if(  writer == null )
				throw new ArgumentNullException();

			if( graph != null && !( graph is NoteGuidHdWork || graph is ArrayList || graph is NoteGuidHdWork[]) )
				throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof(NoteGuidHdWork).FullName ) );

			if( graph != null && graph is NoteGuidHdWork )
			{
				Type t = graph.GetType();
				if( !CustomFormatterServices.NeedCustomSerialization( t ) )
					throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.NoteGuidHdWork" );

			//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
			int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
			if( graph is ArrayList )
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if( graph is NoteGuidHdWork[] )
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((NoteGuidHdWork[])graph).Length;
			}
			else if( graph is NoteGuidHdWork )
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
			//���l�K�C�h�敪
			serInfo.MemberInfo.Add( typeof(Int32) ); //NoteGuideDivCode
			//���l�K�C�h�敪����
			serInfo.MemberInfo.Add( typeof(string) ); //NoteGuideDivName

			
			serInfo.Serialize( writer, serInfo );
			if( graph is NoteGuidHdWork )
			{
				NoteGuidHdWork temp = (NoteGuidHdWork)graph;

				SetNoteGuidHdWork(writer, temp);
			}
			else
			{
				ArrayList lst= null;
				if(graph is NoteGuidHdWork[])
				{
					lst = new ArrayList();
					lst.AddRange((NoteGuidHdWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;	
				}

				foreach(NoteGuidHdWork temp in lst)
				{
					SetNoteGuidHdWork(writer, temp);
				}

			}

		
		}


		/// <summary>
		/// NoteGuidHdWork�����o��(public�v���p�e�B��)
		/// </summary>
		private const int currentMemberCount = 10;
		
		/// <summary>
		///  NoteGuidHdWork�C���X�^���X��������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoteGuidHdWork�̃C���X�^���X����������</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private void SetNoteGuidHdWork( System.IO.BinaryWriter writer, NoteGuidHdWork temp )
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
			//���l�K�C�h�敪
			writer.Write( temp.NoteGuideDivCode );
			//���l�K�C�h�敪����
			writer.Write( temp.NoteGuideDivName );

		}

		/// <summary>
		///  NoteGuidHdWork�C���X�^���X�擾
		/// </summary>
		/// <returns>NoteGuidHdWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoteGuidHdWork�̃C���X�^���X���擾���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private NoteGuidHdWork GetNoteGuidHdWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
		{
			// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
			// serInfo.MemberInfo.Count < currentMemberCount
			// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

			NoteGuidHdWork temp = new NoteGuidHdWork();

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
			//���l�K�C�h�敪
			temp.NoteGuideDivCode = reader.ReadInt32();
			//���l�K�C�h�敪����
			temp.NoteGuideDivName = reader.ReadString();

			
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
		/// <returns>NoteGuidHdWork�N���X�̃C���X�^���X(object)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   NoteGuidHdWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
			ArrayList lst = new ArrayList();
			for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
			{
				NoteGuidHdWork temp = GetNoteGuidHdWork( reader, serInfo );
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
					retValue = (NoteGuidHdWork[])lst.ToArray(typeof(NoteGuidHdWork));
					break;
			}
			return retValue;
		}

		#endregion
	}
}
