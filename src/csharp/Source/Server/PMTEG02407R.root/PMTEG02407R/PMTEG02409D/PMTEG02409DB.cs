//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`���ʗ\��\���o�����N���X���[�N
// �v���O�����T�v   : ��`���ʗ\��\���o�����N���X���[�N�w�b�_�t�@�C��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �I�M
// �� �� ��  2010/05/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   TegataTsukibetsuYoteListReportResultWork
	/// <summary>
	///                      ���E�x����`�f�[�^���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���E�x����`�f�[�^���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2008/4/24</br>
	/// <br>Genarated Date   :   2010/04/22  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class TegataTsukibetsuYoteListReportResultWork : IFileHeader
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

		/// <summary>��`���</summary>
		/// <remarks>0:�莝 1:�旧 2:���� 3:���n 4:�S�� 5:�s�n 6:�x�� 7:��t 9:����</remarks>
		private Int32 _draftKindCd;

		/// <summary>��`�敪</summary>
		/// <remarks>0:���U 1:���U�@���������U�敪</remarks>
		private Int32 _draftDivide;

		/// <summary>�������z/�x�����z</summary>
		/// <remarks>�l���E�萔�����������z</remarks>
		private Int64 _deposit;

		/// <summary>��s�E�x�X�R�[�h</summary>
		/// <remarks>��4����s���ޤ��3���x�X����</remarks>
		private Int32 _bankAndBranchCd;

		/// <summary>��s�E�x�X����</summary>
		private string _bankAndBranchNm = "";

		/// <summary>�L������</summary>
		/// <remarks>YYYYMMDD�@�������A�������Ƃ��Ďg�p</remarks>
		private Int32 _validityTerm;

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

		/// public propaty name  :  DraftKindCd
		/// <summary>��`��ʃv���p�e�B</summary>
		/// <value>0:�莝 1:�旧 2:���� 3:���n 4:�S�� 5:�s�n 6:�x�� 7:��t 9:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��`��ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DraftKindCd
		{
			get { return _draftKindCd; }
			set { _draftKindCd = value; }
		}

		/// public propaty name  :  DraftDivide
		/// <summary>��`�敪�v���p�e�B</summary>
		/// <value>0:���U 1:���U�@���������U�敪</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��`�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DraftDivide
		{
			get{return _draftDivide;}
			set{_draftDivide = value;}
		}

		/// public propaty name  :  Deposit
		/// <summary>�������z/�x�����z�v���p�e�B</summary>
		/// <value>�l���E�萔�����������z</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������z/�x�����z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 Deposit
		{
			get{return _deposit;}
			set{_deposit = value;}
		}

		/// public propaty name  :  BankAndBranchCd
		/// <summary>��s�E�x�X�R�[�h�v���p�e�B</summary>
		/// <value>��4����s���ޤ��3���x�X����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��s�E�x�X�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BankAndBranchCd
		{
			get { return _bankAndBranchCd; }
			set { _bankAndBranchCd = value; }
		}

		/// public propaty name  :  BankAndBranchNm
		/// <summary>��s�E�x�X���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��s�E�x�X���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BankAndBranchNm
		{
			get { return _bankAndBranchNm; }
			set { _bankAndBranchNm = value; }
		}

		/// public propaty name  :  ValidityTerm
		/// <summary>�L�������v���p�e�B</summary>
		/// <value>YYYYMMDD�@�������A�������Ƃ��Ďg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �L�������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ValidityTerm
		{
			get{return _validityTerm;}
			set{_validityTerm = value;}
		}

		/// <summary>
		/// ���E�x����`�f�[�^���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>TegataTsukibetsuYoteListReportResultWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TegataTsukibetsuYoteListReportResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public TegataTsukibetsuYoteListReportResultWork()
		{
		}

	}
	
	/// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>TegataTsukibetsuYoteListReportResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   TegataTsukibetsuYoteListReportResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class TegataTsukibetsuYoteListReportResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
	    #region ICustomSerializationSurrogate �����o
    	
	    /// <summary>
	    ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
	    /// </summary>
	    /// <remarks>
	    /// <br>Note�@�@�@�@�@�@ :   TegataTsukibetsuYoteListReportResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	    /// <br>Programer        :   ��������</br>
	    /// </remarks>
	    public void Serialize(System.IO.BinaryWriter writer, object graph)
	    {
		    // TODO:  TegataTsukibetsuYoteListReportResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
		    if(  writer == null )
			    throw new ArgumentNullException();

		    if( graph != null && !( graph is TegataTsukibetsuYoteListReportResultWork || graph is ArrayList || graph is TegataTsukibetsuYoteListReportResultWork[]) )
			    throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof(TegataTsukibetsuYoteListReportResultWork).FullName ) );

		    if( graph != null && graph is TegataTsukibetsuYoteListReportResultWork )
		    {
			    Type t = graph.GetType();
			    if( !CustomFormatterServices.NeedCustomSerialization( t ) )
				    throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
		    }

		    //SerializationTypeInfo
		    Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TegataTsukibetsuYoteListReportResultWork" );

		    //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
		    int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
		    if( graph is ArrayList )
		    {
			    serInfo.RetTypeInfo = 0;
			    occurrence = ((ArrayList)graph).Count;
		    }else if( graph is TegataTsukibetsuYoteListReportResultWork[] )
		    {
			    serInfo.RetTypeInfo = 2;
			    occurrence = ((TegataTsukibetsuYoteListReportResultWork[])graph).Length;
		    }
		    else if( graph is TegataTsukibetsuYoteListReportResultWork )
		    {
			    serInfo.RetTypeInfo = 1;
			    occurrence = 1;
		    }

		    serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

			//�쐬����
			serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
			//�X�V����
			serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
			//��ƃR�[�h
			serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
			//GUID
			serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
			//�X�V�]�ƈ��R�[�h
			serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
			//�X�V�A�Z���u��ID1
			serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
			//�X�V�A�Z���u��ID2
			serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
			//�_���폜�敪
			serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
			//��`���
			serInfo.MemberInfo.Add(typeof(Int32)); //DraftKindCd
			//��`�敪
			serInfo.MemberInfo.Add(typeof(Int32)); //DraftDivide
			//�������z/�x�����z
			serInfo.MemberInfo.Add(typeof(Int64)); //Deposit
			//��s�E�x�X�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //BankAndBranchCd
			//��s�E�x�X����
			serInfo.MemberInfo.Add(typeof(string)); //BankAndBranchNm
			//�L������
			serInfo.MemberInfo.Add(typeof(Int32)); //ValidityTerm

    			
		    serInfo.Serialize( writer, serInfo );
		    if( graph is TegataTsukibetsuYoteListReportResultWork )
		    {
			    TegataTsukibetsuYoteListReportResultWork temp = (TegataTsukibetsuYoteListReportResultWork)graph;

			    SetTegataTsukibetsuYoteListReportResultWork(writer, temp);
		    }
		    else
		    {
			    ArrayList lst= null;
			    if(graph is TegataTsukibetsuYoteListReportResultWork[])
			    {
				    lst = new ArrayList();
				    lst.AddRange((TegataTsukibetsuYoteListReportResultWork[])graph);
			    }
			    else
			    {
				    lst = (ArrayList)graph;	
			    }

			    foreach(TegataTsukibetsuYoteListReportResultWork temp in lst)
			    {
				    SetTegataTsukibetsuYoteListReportResultWork(writer, temp);
			    }

		    }

    		
	    }


	    /// <summary>
	    /// TegataTsukibetsuYoteListReportResultWork�����o��(public�v���p�e�B��)
	    /// </summary>
	    private const int currentMemberCount = 14;
    		
	    /// <summary>
	    ///  TegataTsukibetsuYoteListReportResultWork�C���X�^���X��������
	    /// </summary>
	    /// <remarks>
	    /// <br>Note�@�@�@�@�@�@ :   TegataTsukibetsuYoteListReportResultWork�̃C���X�^���X����������</br>
	    /// <br>Programer        :   ��������</br>
	    /// </remarks>
	    private void SetTegataTsukibetsuYoteListReportResultWork( System.IO.BinaryWriter writer, TegataTsukibetsuYoteListReportResultWork temp )
	    {
			//�쐬����
			writer.Write((Int64)temp.CreateDateTime.Ticks);
			//�X�V����
			writer.Write((Int64)temp.UpdateDateTime.Ticks);
			//��ƃR�[�h
			writer.Write(temp.EnterpriseCode);
			//GUID
			byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
			writer.Write(fileHeaderGuidArray.Length);
			writer.Write(temp.FileHeaderGuid.ToByteArray());
			//�X�V�]�ƈ��R�[�h
			writer.Write(temp.UpdEmployeeCode);
			//�X�V�A�Z���u��ID1
			writer.Write(temp.UpdAssemblyId1);
			//�X�V�A�Z���u��ID2
			writer.Write(temp.UpdAssemblyId2);
			//�_���폜�敪
			writer.Write(temp.LogicalDeleteCode);
			//��`���
			writer.Write(temp.DraftKindCd);
			//��`�敪
			writer.Write(temp.DraftDivide);
			//�������z/�x�����z
			writer.Write(temp.Deposit);
			//��s�E�x�X�R�[�h
			writer.Write(temp.BankAndBranchCd);
			//��s�E�x�X����
			writer.Write(temp.BankAndBranchNm);
			//�L������
			writer.Write(temp.ValidityTerm);

	    }

	    /// <summary>
	    ///  TegataTsukibetsuYoteListReportResultWork�C���X�^���X�擾
	    /// </summary>
	    /// <returns>TegataTsukibetsuYoteListReportResultWork�N���X�̃C���X�^���X</returns>
	    /// <remarks>
	    /// <br>Note�@�@�@�@�@�@ :   TegataTsukibetsuYoteListReportResultWork�̃C���X�^���X���擾���܂�</br>
	    /// <br>Programer        :   ��������</br>
	    /// </remarks>
	    private TegataTsukibetsuYoteListReportResultWork GetTegataTsukibetsuYoteListReportResultWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
	    {
		    // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
		    // serInfo.MemberInfo.Count < currentMemberCount
		    // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

		    TegataTsukibetsuYoteListReportResultWork temp = new TegataTsukibetsuYoteListReportResultWork();

			//�쐬����
			temp.CreateDateTime = new DateTime(reader.ReadInt64());
			//�X�V����
			temp.UpdateDateTime = new DateTime(reader.ReadInt64());
			//��ƃR�[�h
			temp.EnterpriseCode = reader.ReadString();
			//GUID
			int lenOfFileHeaderGuidArray = reader.ReadInt32();
			byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
			temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
			//�X�V�]�ƈ��R�[�h
			temp.UpdEmployeeCode = reader.ReadString();
			//�X�V�A�Z���u��ID1
			temp.UpdAssemblyId1 = reader.ReadString();
			//�X�V�A�Z���u��ID2
			temp.UpdAssemblyId2 = reader.ReadString();
			//�_���폜�敪
			temp.LogicalDeleteCode = reader.ReadInt32();
			//��`���
			temp.DraftKindCd = reader.ReadInt32();
			//��`�敪
			temp.DraftDivide = reader.ReadInt32();
			//�������z/�x�����z
			temp.Deposit = reader.ReadInt64();
			//��s�E�x�X�R�[�h
			temp.BankAndBranchCd = reader.ReadInt32();
			//��s�E�x�X����
			temp.BankAndBranchNm = reader.ReadString();
			//�L������
			temp.ValidityTerm = reader.ReadInt32();

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
	    /// <returns>TegataTsukibetsuYoteListReportResultWork�N���X�̃C���X�^���X(object)</returns>
	    /// <remarks>
	    /// <br>Note�@�@�@�@�@�@ :   TegataTsukibetsuYoteListReportResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
	    /// <br>Programer        :   ��������</br>
	    /// </remarks>
	    public object Deserialize(System.IO.BinaryReader reader)
	    {
		    object retValue = null;
		    Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
		    ArrayList lst = new ArrayList();
		    for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
		    {
			    TegataTsukibetsuYoteListReportResultWork temp = GetTegataTsukibetsuYoteListReportResultWork( reader, serInfo );
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
				    retValue = (TegataTsukibetsuYoteListReportResultWork[])lst.ToArray(typeof(TegataTsukibetsuYoteListReportResultWork));
				    break;
		    }
		    return retValue;
	    }

	    #endregion
    }

}
