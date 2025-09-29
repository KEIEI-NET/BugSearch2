using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   CEqpDefDspRetWork
	/// <summary>
	///                      �������o���ʃN���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �������o���ʃN���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/03/09  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class CEqpDefDspRetWork
	{
		/// <summary>���[�J�[�R�[�h</summary>
		/// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
		private Int32 _makerCode;

		/// <summary>�Ԏ�R�[�h</summary>
		/// <remarks>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
		private Int32 _modelCode;

		/// <summary>�Ԏ�T�u�R�[�h</summary>
		/// <remarks>0�`899:�񋟕�,900�`հ�ް�o�^</remarks>
		private Int32 _modelSubCode;

		/// <summary>�n���R�[�h</summary>
		private Int32 _systematicCode;

		/// <summary>�����\������</summary>
		private Int32 _equipmentDispOrder;

		/// <summary>�������ރR�[�h</summary>
		private Int32 _equipmentGenreCd;

		/// <summary>�������ޖ���</summary>
		private string _equipmentGenreNm = "";

		/// <summary>�����R�[�h</summary>
		private Int32 _equipmentCode;

		/// <summary>��������</summary>
		private string _equipmentName = "";

		/// <summary>��������</summary>
		private string _equipmentShortName = "";

		/// <summary>����ICON�R�[�h</summary>
		private Int32 _equipmentIconCode;


		/// public propaty name  :  MakerCode
		/// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
		/// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MakerCode
		{
			get { return _makerCode; }
			set { _makerCode = value; }
		}

		/// public propaty name  :  ModelCode
		/// <summary>�Ԏ�R�[�h�v���p�e�B</summary>
		/// <value>�Ԗ��R�[�h(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ԏ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ModelCode
		{
			get { return _modelCode; }
			set { _modelCode = value; }
		}

		/// public propaty name  :  ModelSubCode
		/// <summary>�Ԏ�T�u�R�[�h�v���p�e�B</summary>
		/// <value>0�`899:�񋟕�,900�`հ�ް�o�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ԏ�T�u�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ModelSubCode
		{
			get { return _modelSubCode; }
			set { _modelSubCode = value; }
		}

		/// public propaty name  :  SystematicCode
		/// <summary>�n���R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �n���R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SystematicCode
		{
			get { return _systematicCode; }
			set { _systematicCode = value; }
		}

		/// public propaty name  :  EquipmentDispOrder
		/// <summary>�����\�����ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����\�����ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EquipmentDispOrder
		{
			get { return _equipmentDispOrder; }
			set { _equipmentDispOrder = value; }
		}

		/// public propaty name  :  EquipmentGenreCd
		/// <summary>�������ރR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������ރR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
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
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EquipmentGenreNm
		{
			get { return _equipmentGenreNm; }
			set { _equipmentGenreNm = value; }
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


		/// <summary>
		/// �������o���ʃN���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>CEqpDefDspRetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CEqpDefDspRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CEqpDefDspRetWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
	/// </summary>
	/// <returns>CEqpDefDspRetWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   CEqpDefDspRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public class CEqpDefDspRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate �����o

		/// <summary>
		///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CEqpDefDspRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  CEqpDefDspRetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is CEqpDefDspRetWork || graph is ArrayList || graph is CEqpDefDspRetWork[]))
				throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(CEqpDefDspRetWork).FullName));

			if (graph != null && graph is CEqpDefDspRetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CEqpDefDspRetWork");

			//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
			int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is CEqpDefDspRetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((CEqpDefDspRetWork[])graph).Length;
			}
			else if (graph is CEqpDefDspRetWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

			//���[�J�[�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
			//�Ԏ�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //ModelCode
			//�Ԏ�T�u�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //ModelSubCode
			//�n���R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //SystematicCode
			//�����\������
			serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentDispOrder
			//�������ރR�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentGenreCd
			//�������ޖ���
			serInfo.MemberInfo.Add(typeof(string)); //EquipmentGenreNm
			//�����R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentCode
			//��������
			serInfo.MemberInfo.Add(typeof(string)); //EquipmentName
			//��������
			serInfo.MemberInfo.Add(typeof(string)); //EquipmentShortName
			//����ICON�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentIconCode


			serInfo.Serialize(writer, serInfo);
			if (graph is CEqpDefDspRetWork)
			{
				CEqpDefDspRetWork temp = (CEqpDefDspRetWork)graph;

				SetCEqpDefDspRetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is CEqpDefDspRetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((CEqpDefDspRetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (CEqpDefDspRetWork temp in lst)
				{
					SetCEqpDefDspRetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// CEqpDefDspRetWork�����o��(public�v���p�e�B��)
		/// </summary>
		private const int currentMemberCount = 11;

		/// <summary>
		///  CEqpDefDspRetWork�C���X�^���X��������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CEqpDefDspRetWork�̃C���X�^���X����������</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private void SetCEqpDefDspRetWork(System.IO.BinaryWriter writer, CEqpDefDspRetWork temp)
		{
			//���[�J�[�R�[�h
			writer.Write(temp.MakerCode);
			//�Ԏ�R�[�h
			writer.Write(temp.ModelCode);
			//�Ԏ�T�u�R�[�h
			writer.Write(temp.ModelSubCode);
			//�n���R�[�h
			writer.Write(temp.SystematicCode);
			//�����\������
			writer.Write(temp.EquipmentDispOrder);
			//�������ރR�[�h
			writer.Write(temp.EquipmentGenreCd);
			//�������ޖ���
			writer.Write(temp.EquipmentGenreNm);
			//�����R�[�h
			writer.Write(temp.EquipmentCode);
			//��������
			writer.Write(temp.EquipmentName);
			//��������
			writer.Write(temp.EquipmentShortName);
			//����ICON�R�[�h
			writer.Write(temp.EquipmentIconCode);

		}

		/// <summary>
		///  CEqpDefDspRetWork�C���X�^���X�擾
		/// </summary>
		/// <returns>CEqpDefDspRetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CEqpDefDspRetWork�̃C���X�^���X���擾���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private CEqpDefDspRetWork GetCEqpDefDspRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
			// serInfo.MemberInfo.Count < currentMemberCount
			// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

			CEqpDefDspRetWork temp = new CEqpDefDspRetWork();

			//���[�J�[�R�[�h
			temp.MakerCode = reader.ReadInt32();
			//�Ԏ�R�[�h
			temp.ModelCode = reader.ReadInt32();
			//�Ԏ�T�u�R�[�h
			temp.ModelSubCode = reader.ReadInt32();
			//�n���R�[�h
			temp.SystematicCode = reader.ReadInt32();
			//�����\������
			temp.EquipmentDispOrder = reader.ReadInt32();
			//�������ރR�[�h
			temp.EquipmentGenreCd = reader.ReadInt32();
			//�������ޖ���
			temp.EquipmentGenreNm = reader.ReadString();
			//�����R�[�h
			temp.EquipmentCode = reader.ReadInt32();
			//��������
			temp.EquipmentName = reader.ReadString();
			//��������
			temp.EquipmentShortName = reader.ReadString();
			//����ICON�R�[�h
			temp.EquipmentIconCode = reader.ReadInt32();


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
		/// <returns>CEqpDefDspRetWork�N���X�̃C���X�^���X(object)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CEqpDefDspRetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				CEqpDefDspRetWork temp = GetCEqpDefDspRetWork(reader, serInfo);
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
					retValue = (CEqpDefDspRetWork[])lst.ToArray(typeof(CEqpDefDspRetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}
