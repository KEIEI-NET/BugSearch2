using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   FrePprSrtOWork
	/// <summary>
	///                      ���R���[�\�[�g���ʃ��[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���R���[�\�[�g���ʃ��[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   ����@�_�u</br>
	/// <br>Genarated Date   :   2007/06/11  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class FrePprSrtOWork : IFileHeader
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

		/// <summary>�o�̓t�@�C����</summary>
		/// <remarks>�t�H�[���t�@�C��ID or �t�H�[�}�b�g�t�@�C��ID</remarks>
		private string _outputFormFileName = "";

		/// <summary>���[�U�[���[ID�}�ԍ�</summary>
		private Int32 _userPrtPprIdDerivNo;

		/// <summary>�\�[�g���ʃR�[�h</summary>
		private Int32 _sortingOrderCode;

		/// <summary>�\�[�g����</summary>
		/// <remarks>���P</remarks>
		private Int32 _sortingOrder;

		/// <summary>���R���[���ږ���</summary>
		private string _freePrtPaperItemNm = "";

		/// <summary>DD����</summary>
		/// <remarks>�������œo�^</remarks>
		private string _dDName = "";

		/// <summary>�t�@�C������</summary>
		/// <remarks>DB�̃e�[�u��ID</remarks>
		private string _fileNm = "";

		/// <summary>�����~���敪</summary>
		/// <remarks>0:�Ȃ�,1:����,2:�~��</remarks>
		private Int32 _sortingOrderDivCd;


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
			get { return _createDateTime; }
			set { _createDateTime = value; }
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
			get { return _updateDateTime; }
			set { _updateDateTime = value; }
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
			get { return _enterpriseCode; }
			set { _enterpriseCode = value; }
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
			get { return _fileHeaderGuid; }
			set { _fileHeaderGuid = value; }
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
			get { return _updEmployeeCode; }
			set { _updEmployeeCode = value; }
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
			get { return _updAssemblyId1; }
			set { _updAssemblyId1 = value; }
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
			get { return _updAssemblyId2; }
			set { _updAssemblyId2 = value; }
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
			get { return _logicalDeleteCode; }
			set { _logicalDeleteCode = value; }
		}

		/// public propaty name  :  OutputFormFileName
		/// <summary>�o�̓t�@�C�����v���p�e�B</summary>
		/// <value>�t�H�[���t�@�C��ID or �t�H�[�}�b�g�t�@�C��ID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�̓t�@�C�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OutputFormFileName
		{
			get { return _outputFormFileName; }
			set { _outputFormFileName = value; }
		}

		/// public propaty name  :  UserPrtPprIdDerivNo
		/// <summary>���[�U�[���[ID�}�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�U�[���[ID�}�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UserPrtPprIdDerivNo
		{
			get { return _userPrtPprIdDerivNo; }
			set { _userPrtPprIdDerivNo = value; }
		}

		/// public propaty name  :  SortingOrderCode
		/// <summary>�\�[�g���ʃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �\�[�g���ʃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SortingOrderCode
		{
			get { return _sortingOrderCode; }
			set { _sortingOrderCode = value; }
		}

		/// public propaty name  :  SortingOrder
		/// <summary>�\�[�g���ʃv���p�e�B</summary>
		/// <value>���P</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �\�[�g���ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SortingOrder
		{
			get { return _sortingOrder; }
			set { _sortingOrder = value; }
		}

		/// public propaty name  :  FreePrtPaperItemNm
		/// <summary>���R���[���ږ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���R���[���ږ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FreePrtPaperItemNm
		{
			get { return _freePrtPaperItemNm; }
			set { _freePrtPaperItemNm = value; }
		}

		/// public propaty name  :  DDName
		/// <summary>DD���̃v���p�e�B</summary>
		/// <value>�������œo�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   DD���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DDName
		{
			get { return _dDName; }
			set { _dDName = value; }
		}

		/// public propaty name  :  FileNm
		/// <summary>�t�@�C�����̃v���p�e�B</summary>
		/// <value>DB�̃e�[�u��ID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �t�@�C�����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FileNm
		{
			get { return _fileNm; }
			set { _fileNm = value; }
		}

		/// public propaty name  :  SortingOrderDivCd
		/// <summary>�����~���敪�v���p�e�B</summary>
		/// <value>0:�Ȃ�,1:����,2:�~��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����~���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SortingOrderDivCd
		{
			get { return _sortingOrderDivCd; }
			set { _sortingOrderDivCd = value; }
		}


		/// <summary>
		/// ���R���[�\�[�g���ʃ��[�N�R���X�g���N�^
		/// </summary>
		/// <returns>FrePprSrtOWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprSrtOWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public FrePprSrtOWork()
		{
		}

	}
	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
	/// </summary>
	/// <returns>FrePprSrtOWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   FrePprSrtOWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public class FrePprSrtOWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate �����o

		/// <summary>
		///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprSrtOWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  FrePprSrtOWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is FrePprSrtOWork || graph is ArrayList || graph is FrePprSrtOWork[]))
				throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(FrePprSrtOWork).FullName));

			if (graph != null && graph is FrePprSrtOWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FrePprSrtOWork");

			//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
			int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is FrePprSrtOWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((FrePprSrtOWork[])graph).Length;
			}
			else if (graph is FrePprSrtOWork)
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
			//�o�̓t�@�C����
			serInfo.MemberInfo.Add(typeof(string)); //OutputFormFileName
			//���[�U�[���[ID�}�ԍ�
			serInfo.MemberInfo.Add(typeof(Int32)); //UserPrtPprIdDerivNo
			//�\�[�g���ʃR�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //SortingOrderCode
			//�\�[�g����
			serInfo.MemberInfo.Add(typeof(Int32)); //SortingOrder
			//���R���[���ږ���
			serInfo.MemberInfo.Add(typeof(string)); //FreePrtPaperItemNm
			//DD����
			serInfo.MemberInfo.Add(typeof(string)); //DDName
			//�t�@�C������
			serInfo.MemberInfo.Add(typeof(string)); //FileNm
			//�����~���敪
			serInfo.MemberInfo.Add(typeof(Int32)); //SortingOrderDivCd


			serInfo.Serialize(writer, serInfo);
			if (graph is FrePprSrtOWork)
			{
				FrePprSrtOWork temp = (FrePprSrtOWork)graph;

				SetFrePprSrtOWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is FrePprSrtOWork[])
				{
					lst = new ArrayList();
					lst.AddRange((FrePprSrtOWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (FrePprSrtOWork temp in lst)
				{
					SetFrePprSrtOWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// FrePprSrtOWork�����o��(public�v���p�e�B��)
		/// </summary>
		private const int currentMemberCount = 16;

		/// <summary>
		///  FrePprSrtOWork�C���X�^���X��������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprSrtOWork�̃C���X�^���X����������</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private void SetFrePprSrtOWork(System.IO.BinaryWriter writer, FrePprSrtOWork temp)
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
			//�o�̓t�@�C����
			writer.Write(temp.OutputFormFileName);
			//���[�U�[���[ID�}�ԍ�
			writer.Write(temp.UserPrtPprIdDerivNo);
			//�\�[�g���ʃR�[�h
			writer.Write(temp.SortingOrderCode);
			//�\�[�g����
			writer.Write(temp.SortingOrder);
			//���R���[���ږ���
			writer.Write(temp.FreePrtPaperItemNm);
			//DD����
			writer.Write(temp.DDName);
			//�t�@�C������
			writer.Write(temp.FileNm);
			//�����~���敪
			writer.Write(temp.SortingOrderDivCd);

		}

		/// <summary>
		///  FrePprSrtOWork�C���X�^���X�擾
		/// </summary>
		/// <returns>FrePprSrtOWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprSrtOWork�̃C���X�^���X���擾���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private FrePprSrtOWork GetFrePprSrtOWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
			// serInfo.MemberInfo.Count < currentMemberCount
			// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

			FrePprSrtOWork temp = new FrePprSrtOWork();

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
			//�o�̓t�@�C����
			temp.OutputFormFileName = reader.ReadString();
			//���[�U�[���[ID�}�ԍ�
			temp.UserPrtPprIdDerivNo = reader.ReadInt32();
			//�\�[�g���ʃR�[�h
			temp.SortingOrderCode = reader.ReadInt32();
			//�\�[�g����
			temp.SortingOrder = reader.ReadInt32();
			//���R���[���ږ���
			temp.FreePrtPaperItemNm = reader.ReadString();
			//DD����
			temp.DDName = reader.ReadString();
			//�t�@�C������
			temp.FileNm = reader.ReadString();
			//�����~���敪
			temp.SortingOrderDivCd = reader.ReadInt32();


			//�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
			//�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
			//�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
			//�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
			for (int k = currentMemberCount ; k < serInfo.MemberInfo.Count ; ++k)
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
		/// <returns>FrePprSrtOWork�N���X�̃C���X�^���X(object)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprSrtOWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt)
			{
				FrePprSrtOWork temp = GetFrePprSrtOWork(reader, serInfo);
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
				retValue = (FrePprSrtOWork[])lst.ToArray(typeof(FrePprSrtOWork));
				break;
			}
			return retValue;
		}

		#endregion
	}

}
