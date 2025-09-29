using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   CategoryEquipmentRetWork
	/// <summary>
	///                      �������i�敪���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �������i�敪���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   96137 �v�ۓc�@�M��</br>
	/// <br>Date             :   2005/4/4</br>
	/// <br>Genarated Date   :   2005/04/05  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class CategoryEquipmentRetWork
	{
		#region private�����o��`
		/// <summary>�������ރR�[�h</summary>
		private Int32 _equipmentGenreCd = 0;

		/// <summary>�������ޖ���</summary>
		private string _equipmentGenreNm = "";

		/// <summary>�����Ǘ��敪�R�[�h</summary>
		private Int32 _equipmentMngCode = 0;

		/// <summary>�����Ǘ��敪����</summary>
		private string _equipmentMngName = "";

		/// <summary>�����R�[�h</summary>
		private Int32 _equipmentCode = 0;

		/// <summary>�����\������</summary>
		private Int32 _equipmentDispOrder = 0;

		/// <summary>�����i�R�[�h</summary>
		/// <remarks>1�`99999:�񋟕�,100000�`���[�U�[�o�^�p</remarks>
		private Int32 _tbsPartsCode = 0;

		/// <summary>��������</summary>
		private string _equipmentName = "";

		/// <summary>��������</summary>
		private string _equipmentShortName = "";

		/// <summary>����ICON�R�[�h</summary>
		private Int32 _equipmentIconCode = 0;

		/// <summary>�����P�ʃR�[�h</summary>
		private Int32 _equipmentUnitCode = 0;

		/// <summary>�����P�ʖ���</summary>
		private string _equipmentUnitName = "";

		/// <summary>��������</summary>
		private Double _equipmentCnt = 0.0;

		/// <summary>�����R�����g1</summary>
		private string _equipmentComment1 = "";

		/// <summary>�����R�����g2</summary>
		private string _equipmentComment2 = "";

		#endregion

		#region public�v���p�e�B��`
		/// public propaty name  :  EquipmentGenreCd
		/// <summary>�������ރR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   �v�ۓc�@�M��</br>
		/// </remarks>
		public Int32 EquipmentGenreCd
		{
			get { return _equipmentGenreCd; }
			set { _equipmentGenreCd = value; }
		}

		/// public propaty name  :  EquipmentGenreNm
		/// <summary>�������ޖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������ޖ��̃v���p�e�B</br>
		/// <br>Programer        :   �v�ۓc�@�M��</br>
		/// </remarks>
		public string EquipmentGenreNm
		{
			get { return _equipmentGenreNm; }
			set { _equipmentGenreNm = value; }
		}

		/// public propaty name  :  EquipmentMngCode
		/// <summary>�����Ǘ��敪�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����Ǘ��敪�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EquipmentMngCode
		{
			get { return _equipmentMngCode; }
			set { _equipmentMngCode = value; }
		}

		/// public propaty name  :  EquipmentMngName
		/// <summary>�����Ǘ��敪���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����Ǘ��敪���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EquipmentMngName
		{
			get { return _equipmentMngName; }
			set { _equipmentMngName = value; }
		}

		/// public propaty name  :  EquipmentCode
		/// <summary>�����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EquipmentCode
		{
			get { return _equipmentCode; }
			set { _equipmentCode = value; }
		}

		/// public propaty name  :  EquipmentDispOrder
		/// <summary>�����\�����ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EquipmentDispOrder
		{
			get { return _equipmentDispOrder; }
			set { _equipmentDispOrder = value; }
		}

		/// public propaty name  :  TbsPartsCode
		/// <summary>�����i�R�[�h�v���p�e�B</summary>
		/// <value>1�`99999:�񋟕�,100000�`���[�U�[�o�^�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����i�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TbsPartsCode
		{
			get { return _tbsPartsCode; }
			set { _tbsPartsCode = value; }
		}

		/// public propaty name  :  EquipmentName
		/// <summary>�������̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EquipmentName
		{
			get { return _equipmentName; }
			set { _equipmentName = value; }
		}

		/// public propaty name  :  EquipmentShortName
		/// <summary>�������̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EquipmentShortName
		{
			get { return _equipmentShortName; }
			set { _equipmentShortName = value; }
		}

		/// public propaty name  :  EquipmentIconCode
		/// <summary>����ICON�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����ICON�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EquipmentIconCode
		{
			get { return _equipmentIconCode; }
			set { _equipmentIconCode = value; }
		}

		/// public propaty name  :  EquipmentUnitCode
		/// <summary>�����P�ʃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����P�ʃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EquipmentUnitCode
		{
			get { return _equipmentUnitCode; }
			set { _equipmentUnitCode = value; }
		}

		/// public propaty name  :  EquipmentUnitName
		/// <summary>�����P�ʖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����P�ʖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EquipmentUnitName
		{
			get { return _equipmentUnitName; }
			set { _equipmentUnitName = value; }
		}

		/// public propaty name  :  EquipmentCnt
		/// <summary>�������ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double EquipmentCnt
		{
			get { return _equipmentCnt; }
			set { _equipmentCnt = value; }
		}

		/// public propaty name  :  EquipmentComment1
		/// <summary>�����R�����g1�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����R�����g1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EquipmentComment1
		{
			get { return _equipmentComment1; }
			set { _equipmentComment1 = value; }
		}

		/// public propaty name  :  EquipmentComment2
		/// <summary>�����R�����g2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����R�����g2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EquipmentComment2
		{
			get { return _equipmentComment2; }
			set { _equipmentComment2 = value; }
		}

		#endregion

		/// <summary>
		/// �ޕʑ������i�敪���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>CategoryEquipmentRetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CategoryEquipmentPartsWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   �v�ۓc�@�M��</br>
		/// </remarks>
		public CategoryEquipmentRetWork()
		{
		}

	}


	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
	/// </summary>
	/// <returns>CategoryEquipmentRetWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   CategoryEquipmentRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public class CategoryEquipmentRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate �����o

		/// <summary>
		///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CategoryEquipmentRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  CategoryEquipmentRetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is CategoryEquipmentRetWork || graph is ArrayList || graph is CategoryEquipmentRetWork[]))
				throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(CategoryEquipmentRetWork).FullName));

			if (graph != null && graph is CategoryEquipmentRetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CategoryEquipmentRetWork");

			//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
			int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is CategoryEquipmentRetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((CategoryEquipmentRetWork[])graph).Length;
			}
			else if (graph is CategoryEquipmentRetWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

			//�������ރR�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentGenreCd
			//�������ޖ���
			serInfo.MemberInfo.Add(typeof(string)); //EquipmentGenreNm
			//�����Ǘ��敪�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentMngCode
			//�����Ǘ��敪����
			serInfo.MemberInfo.Add(typeof(string)); //EquipmentMngName
			//�����R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentCode
			//�����\������
			serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentDispOrder
			//�����i�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
			//��������
			serInfo.MemberInfo.Add(typeof(string)); //EquipmentName
			//��������
			serInfo.MemberInfo.Add(typeof(string)); //EquipmentShortName
			//����ICON�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentIconCode
			//�����P�ʃR�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentUnitCode
			//�����P�ʖ���
			serInfo.MemberInfo.Add(typeof(string)); //EquipmentUnitName
			//��������
			serInfo.MemberInfo.Add(typeof(Double)); //EquipmentCnt
			//�����R�����g1
			serInfo.MemberInfo.Add(typeof(string)); //EquipmentComment1
			//�����R�����g2
			serInfo.MemberInfo.Add(typeof(string)); //EquipmentComment2


			serInfo.Serialize(writer, serInfo);
			if (graph is CategoryEquipmentRetWork)
			{
				CategoryEquipmentRetWork temp = (CategoryEquipmentRetWork)graph;

				SetCategoryEquipmentRetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is CategoryEquipmentRetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((CategoryEquipmentRetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (CategoryEquipmentRetWork temp in lst)
				{
					SetCategoryEquipmentRetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// CategoryEquipmentRetWork�����o��(public�v���p�e�B��)
		/// </summary>
		private const int currentMemberCount = 15;

		/// <summary>
		///  CategoryEquipmentRetWork�C���X�^���X��������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CategoryEquipmentRetWork�̃C���X�^���X����������</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private void SetCategoryEquipmentRetWork(System.IO.BinaryWriter writer, CategoryEquipmentRetWork temp)
		{
			//�������ރR�[�h
			writer.Write(temp.EquipmentGenreCd);
			//�������ޖ���
			writer.Write(temp.EquipmentGenreNm);
			//�����Ǘ��敪�R�[�h
			writer.Write(temp.EquipmentMngCode);
			//�����Ǘ��敪����
			writer.Write(temp.EquipmentMngName);
			//�����R�[�h
			writer.Write(temp.EquipmentCode);
			//�����\������
			writer.Write(temp.EquipmentDispOrder);
			//�����i�R�[�h
			writer.Write(temp.TbsPartsCode);
			//��������
			writer.Write(temp.EquipmentName);
			//��������
			writer.Write(temp.EquipmentShortName);
			//����ICON�R�[�h
			writer.Write(temp.EquipmentIconCode);
			//�����P�ʃR�[�h
			writer.Write(temp.EquipmentUnitCode);
			//�����P�ʖ���
			writer.Write(temp.EquipmentUnitName);
			//��������
			writer.Write(temp.EquipmentCnt);
			//�����R�����g1
			writer.Write(temp.EquipmentComment1);
			//�����R�����g2
			writer.Write(temp.EquipmentComment2);

		}

		/// <summary>
		///  CategoryEquipmentRetWork�C���X�^���X�擾
		/// </summary>
		/// <returns>CategoryEquipmentRetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CategoryEquipmentRetWork�̃C���X�^���X���擾���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private CategoryEquipmentRetWork GetCategoryEquipmentRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
			// serInfo.MemberInfo.Count < currentMemberCount
			// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

			CategoryEquipmentRetWork temp = new CategoryEquipmentRetWork();

			//�������ރR�[�h
			temp.EquipmentGenreCd = reader.ReadInt32();
			//�������ޖ���
			temp.EquipmentGenreNm = reader.ReadString();
			//�����Ǘ��敪�R�[�h
			temp.EquipmentMngCode = reader.ReadInt32();
			//�����Ǘ��敪����
			temp.EquipmentMngName = reader.ReadString();
			//�����R�[�h
			temp.EquipmentCode = reader.ReadInt32();
			//�����\������
			temp.EquipmentDispOrder = reader.ReadInt32();
			//�����i�R�[�h
			temp.TbsPartsCode = reader.ReadInt32();
			//��������
			temp.EquipmentName = reader.ReadString();
			//��������
			temp.EquipmentShortName = reader.ReadString();
			//����ICON�R�[�h
			temp.EquipmentIconCode = reader.ReadInt32();
			//�����P�ʃR�[�h
			temp.EquipmentUnitCode = reader.ReadInt32();
			//�����P�ʖ���
			temp.EquipmentUnitName = reader.ReadString();
			//��������
			temp.EquipmentCnt = reader.ReadDouble();
			//�����R�����g1
			temp.EquipmentComment1 = reader.ReadString();
			//�����R�����g2
			temp.EquipmentComment2 = reader.ReadString();


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
		/// <returns>CategoryEquipmentRetWork�N���X�̃C���X�^���X(object)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CategoryEquipmentRetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				CategoryEquipmentRetWork temp = GetCategoryEquipmentRetWork(reader, serInfo);
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
					retValue = (CategoryEquipmentRetWork[])lst.ToArray(typeof(CategoryEquipmentRetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}
}
