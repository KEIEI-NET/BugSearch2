using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ColorCdRetWork
	/// <summary>
	///                      �J���[���o���ʃN���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �J���[���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/03/15  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ColorCdRetWork
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
/*
		/// <summary>�n���R�[�h</summary>
		private Int32 _systematicCode;

		/// <summary>���Y�N���R�[�h</summary>
		private Int32 _produceTypeOfYearCd;
*/
		/// <summary>�J���[�R�[�h</summary>
		/// <remarks>�J�^���O�̐F�R�[�h</remarks>
		private string _colorCode = "";
/*
		/// <summary>�J���[�R�[�h�d�����}��</summary>
		private Int32 _colorCdDupDerivedNo;
*/
		/// <summary>�J���[����1</summary>
		/// <remarks>��ʕ\���p��������</remarks>
		private string _colorName1 = "";


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
/*
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

		/// public propaty name  :  ProduceTypeOfYearCd
		/// <summary>���Y�N���R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Y�N���R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ProduceTypeOfYearCd
		{
			get { return _produceTypeOfYearCd; }
			set { _produceTypeOfYearCd = value; }
		}
*/
		/// public propaty name  :  ColorCode
		/// <summary>�J���[�R�[�h�v���p�e�B</summary>
		/// <value>�J�^���O�̐F�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J���[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ColorCode
		{
			get { return _colorCode; }
			set { _colorCode = value; }
		}
/*
		/// public propaty name  :  ColorCdDupDerivedNo
		/// <summary>�J���[�R�[�h�d�����}�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J���[�R�[�h�d�����}�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ColorCdDupDerivedNo
		{
			get { return _colorCdDupDerivedNo; }
			set { _colorCdDupDerivedNo = value; }
		}
*/
		/// public propaty name  :  ColorName1
		/// <summary>�J���[����1�v���p�e�B</summary>
		/// <value>��ʕ\���p��������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J���[����1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ColorName1
		{
			get { return _colorName1; }
			set { _colorName1 = value; }
		}


		/// <summary>
		/// �J���[���o���ʃN���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>ColorCdRetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ColorCdRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ColorCdRetWork()
		{
		}

	}


	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
	/// </summary>
	/// <returns>ColorCdRetWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   ColorCdRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public class ColorCdRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate �����o

		/// <summary>
		///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ColorCdRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  ColorCdRetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is ColorCdRetWork || graph is ArrayList || graph is ColorCdRetWork[]))
				throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(ColorCdRetWork).FullName));

			if (graph != null && graph is ColorCdRetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ColorCdRetWork");

			//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
			int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is ColorCdRetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((ColorCdRetWork[])graph).Length;
			}
			else if (graph is ColorCdRetWork)
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
/*			//�n���R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //SystematicCode
			//���Y�N���R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //ProduceTypeOfYearCd*/
			//�J���[�R�[�h
			serInfo.MemberInfo.Add(typeof(string)); //ColorCode
/*			//�J���[�R�[�h�d�����}��
			serInfo.MemberInfo.Add(typeof(Int32)); //ColorCdDupDerivedNo*/
			//�J���[����1
			serInfo.MemberInfo.Add(typeof(string)); //ColorName1


			serInfo.Serialize(writer, serInfo);
			if (graph is ColorCdRetWork)
			{
				ColorCdRetWork temp = (ColorCdRetWork)graph;

				SetColorCdRetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is ColorCdRetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((ColorCdRetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (ColorCdRetWork temp in lst)
				{
					SetColorCdRetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// ColorCdRetWork�����o��(public�v���p�e�B��)
		/// </summary>
		//private const int currentMemberCount = 8;
        private const int currentMemberCount = 5;

		/// <summary>
		///  ColorCdRetWork�C���X�^���X��������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ColorCdRetWork�̃C���X�^���X����������</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private void SetColorCdRetWork(System.IO.BinaryWriter writer, ColorCdRetWork temp)
		{
			//���[�J�[�R�[�h
			writer.Write(temp.MakerCode);
			//�Ԏ�R�[�h
			writer.Write(temp.ModelCode);
			//�Ԏ�T�u�R�[�h
			writer.Write(temp.ModelSubCode);
/*			//�n���R�[�h
			writer.Write(temp.SystematicCode);
			//���Y�N���R�[�h
			writer.Write(temp.ProduceTypeOfYearCd);*/
			//�J���[�R�[�h
			writer.Write(temp.ColorCode);
/*			//�J���[�R�[�h�d�����}��
			writer.Write(temp.ColorCdDupDerivedNo);*/
			//�J���[����1
			writer.Write(temp.ColorName1);

		}

		/// <summary>
		///  ColorCdRetWork�C���X�^���X�擾
		/// </summary>
		/// <returns>ColorCdRetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ColorCdRetWork�̃C���X�^���X���擾���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private ColorCdRetWork GetColorCdRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
			// serInfo.MemberInfo.Count < currentMemberCount
			// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

			ColorCdRetWork temp = new ColorCdRetWork();

			//���[�J�[�R�[�h
			temp.MakerCode = reader.ReadInt32();
			//�Ԏ�R�[�h
			temp.ModelCode = reader.ReadInt32();
			//�Ԏ�T�u�R�[�h
			temp.ModelSubCode = reader.ReadInt32();
/*			//�n���R�[�h
			temp.SystematicCode = reader.ReadInt32();
			//���Y�N���R�[�h
			temp.ProduceTypeOfYearCd = reader.ReadInt32();*/
			//�J���[�R�[�h
			temp.ColorCode = reader.ReadString();
/*			//�J���[�R�[�h�d�����}��
			temp.ColorCdDupDerivedNo = reader.ReadInt32();*/
			//�J���[����1
			temp.ColorName1 = reader.ReadString();


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
		/// <returns>ColorCdRetWork�N���X�̃C���X�^���X(object)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ColorCdRetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				ColorCdRetWork temp = GetColorCdRetWork(reader, serInfo);
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
					retValue = (ColorCdRetWork[])lst.ToArray(typeof(ColorCdRetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}
}
