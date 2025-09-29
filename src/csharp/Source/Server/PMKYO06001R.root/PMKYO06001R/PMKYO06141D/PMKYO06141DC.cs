//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   �}�X�^����M���o�E�X�VDB����N���X              //
//                  :   PMKYO06141D.DLL                                 //
// Name Space       :   Broadleaf.Application.Remoting.ParamData        //
// Programmer       :   ������                                          //
// Date             :   2009.04.28                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   APCustSlipMngWork
	/// <summary>
	///                      ���Ӑ�i�`�[�Ǘ��j���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���Ӑ�i�`�[�Ǘ��j���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2008/3/26</br>
	/// <br>Genarated Date   :   2009/04/28  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/1/28  ����</br>
	/// <br>                 :   ���`�[��ʕ⑫�����ǉ�</br>
	/// <br>                 :   120:�󒍓`�[,130:���ϓ`�[,140:�ݏo�`�[</br>
	/// <br>                 :   ,150:�݌Ɉړ��`�[,160:UOE�`�[</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class APCustSlipMngWork : IFileHeader
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

		/// <summary>�f�[�^���̓V�X�e��</summary>
		/// <remarks>0:����,1:����,2:���,3:�Ԕ�</remarks>
		private Int32 _dataInputSystem;

		/// <summary>�`�[������</summary>
		/// <remarks>10:���Ϗ�,20:�w�����i�������j,21:���菑,30:�[�i�� 40:�ԕi�`�[,100:���[�N�V�[�g,110:�{�f�B���@�},120:�󒍓`�[,130:���ϓ`�[,140:�ݏo�`�[,150:�݌Ɉړ��`�[,160:UOE�`�[</remarks>
		private Int32 _slipPrtKind;

		/// <summary>���_�R�[�h</summary>
		/// <remarks>0�̏ꍇ�͎��Аݒ薔�͓��Ӑ�ݒ�</remarks>
		private string _sectionCode = "";

		/// <summary>���Ӑ�R�[�h</summary>
		/// <remarks>0�̏ꍇ�͎��Аݒ薔�͋��_�ݒ�</remarks>
		private Int32 _customerCode;

		/// <summary>�`�[����ݒ�p���[ID</summary>
		/// <remarks>�`�[����ݒ�p</remarks>
		private string _slipPrtSetPaperId = "";


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

		/// public propaty name  :  DataInputSystem
		/// <summary>�f�[�^���̓V�X�e���v���p�e�B</summary>
		/// <value>0:����,1:����,2:���,3:�Ԕ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �f�[�^���̓V�X�e���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DataInputSystem
		{
			get{return _dataInputSystem;}
			set{_dataInputSystem = value;}
		}

		/// public propaty name  :  SlipPrtKind
		/// <summary>�`�[�����ʃv���p�e�B</summary>
		/// <value>10:���Ϗ�,20:�w�����i�������j,21:���菑,30:�[�i�� 40:�ԕi�`�[,100:���[�N�V�[�g,110:�{�f�B���@�},120:�󒍓`�[,130:���ϓ`�[,140:�ݏo�`�[,150:�݌Ɉړ��`�[,160:UOE�`�[</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�����ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SlipPrtKind
		{
			get{return _slipPrtKind;}
			set{_slipPrtKind = value;}
		}

		/// public propaty name  :  SectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// <value>0�̏ꍇ�͎��Аݒ薔�͓��Ӑ�ݒ�</value>
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

		/// public propaty name  :  CustomerCode
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
		/// <value>0�̏ꍇ�͎��Аݒ薔�͋��_�ݒ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  SlipPrtSetPaperId
		/// <summary>�`�[����ݒ�p���[ID�v���p�e�B</summary>
		/// <value>�`�[����ݒ�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[����ݒ�p���[ID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SlipPrtSetPaperId
		{
			get{return _slipPrtSetPaperId;}
			set{_slipPrtSetPaperId = value;}
		}


		/// <summary>
		/// ���Ӑ�i�`�[�Ǘ��j���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>CustSlipMngWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustSlipMngWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public APCustSlipMngWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CustSlipMngWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CustSlipMngWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class APCustSlipMngWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
	#region ICustomSerializationSurrogate �����o
	
	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
	/// </summary>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   CustSlipMngWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public void Serialize(System.IO.BinaryWriter writer, object graph)
	{
		// TODO:  CustSlipMngWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
		if(  writer == null )
			throw new ArgumentNullException();

		if( graph != null && !( graph is APCustSlipMngWork || graph is ArrayList || graph is APCustSlipMngWork[]) )
			throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof(APCustSlipMngWork).FullName ) );

		if( graph != null && graph is APCustSlipMngWork )
		{
			Type t = graph.GetType();
			if( !CustomFormatterServices.NeedCustomSerialization( t ) )
				throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
		}

		//SerializationTypeInfo
		Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustSlipMngWork" );

		//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
		int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
		if( graph is ArrayList )
		{
			serInfo.RetTypeInfo = 0;
			occurrence = ((ArrayList)graph).Count;
		}else if( graph is APCustSlipMngWork[] )
		{
			serInfo.RetTypeInfo = 2;
			occurrence = ((APCustSlipMngWork[])graph).Length;
		}
		else if( graph is APCustSlipMngWork )
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
		//�f�[�^���̓V�X�e��
		serInfo.MemberInfo.Add( typeof(Int32) ); //DataInputSystem
		//�`�[������
		serInfo.MemberInfo.Add( typeof(Int32) ); //SlipPrtKind
		//���_�R�[�h
		serInfo.MemberInfo.Add( typeof(string) ); //SectionCode
		//���Ӑ�R�[�h
		serInfo.MemberInfo.Add( typeof(Int32) ); //CustomerCode
		//�`�[����ݒ�p���[ID
		serInfo.MemberInfo.Add( typeof(string) ); //SlipPrtSetPaperId

			
		serInfo.Serialize( writer, serInfo );
		if( graph is APCustSlipMngWork )
		{
			APCustSlipMngWork temp = (APCustSlipMngWork)graph;

			SetCustSlipMngWork(writer, temp);
		}
		else
		{
			ArrayList lst= null;
			if(graph is APCustSlipMngWork[])
			{
				lst = new ArrayList();
				lst.AddRange((APCustSlipMngWork[])graph);
			}
			else
			{
				lst = (ArrayList)graph;	
			}

			foreach(APCustSlipMngWork temp in lst)
			{
				SetCustSlipMngWork(writer, temp);
			}

		}

		
	}


	/// <summary>
	/// CustSlipMngWork�����o��(public�v���p�e�B��)
	/// </summary>
	private const int currentMemberCount = 13;
		
	/// <summary>
	///  CustSlipMngWork�C���X�^���X��������
	/// </summary>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   CustSlipMngWork�̃C���X�^���X����������</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	private void SetCustSlipMngWork( System.IO.BinaryWriter writer, APCustSlipMngWork temp )
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
		//�f�[�^���̓V�X�e��
		writer.Write( temp.DataInputSystem );
		//�`�[������
		writer.Write( temp.SlipPrtKind );
		//���_�R�[�h
		writer.Write( temp.SectionCode );
		//���Ӑ�R�[�h
		writer.Write( temp.CustomerCode );
		//�`�[����ݒ�p���[ID
		writer.Write( temp.SlipPrtSetPaperId );

	}

	/// <summary>
	///  CustSlipMngWork�C���X�^���X�擾
	/// </summary>
	/// <returns>CustSlipMngWork�N���X�̃C���X�^���X</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   CustSlipMngWork�̃C���X�^���X���擾���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	private APCustSlipMngWork GetCustSlipMngWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
	{
		// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
		// serInfo.MemberInfo.Count < currentMemberCount
		// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

		APCustSlipMngWork temp = new APCustSlipMngWork();

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
		//�f�[�^���̓V�X�e��
		temp.DataInputSystem = reader.ReadInt32();
		//�`�[������
		temp.SlipPrtKind = reader.ReadInt32();
		//���_�R�[�h
		temp.SectionCode = reader.ReadString();
		//���Ӑ�R�[�h
		temp.CustomerCode = reader.ReadInt32();
		//�`�[����ݒ�p���[ID
		temp.SlipPrtSetPaperId = reader.ReadString();

			
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
	/// <returns>CustSlipMngWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   CustSlipMngWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public object Deserialize(System.IO.BinaryReader reader)
	{
		object retValue = null;
		Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
		ArrayList lst = new ArrayList();
		for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
		{
			APCustSlipMngWork temp = GetCustSlipMngWork( reader, serInfo );
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
				retValue = (APCustSlipMngWork[])lst.ToArray(typeof(APCustSlipMngWork));
				break;
		}
		return retValue;
	}

	#endregion
}
}

