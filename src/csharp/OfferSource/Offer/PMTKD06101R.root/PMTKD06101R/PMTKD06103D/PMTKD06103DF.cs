using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;


namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   PrdTypYearRetWork
	/// <summary>
	///                      ���Y�N�����o���ʃN���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���Y�N�����o���ʃN���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/03/09  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class PrdTypYearRetWork
	{
		/// <summary>���[�J�[�R�[�h</summary>
		/// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
		private Int32 _makerCode;

		/// <summary>�ԑ�^��</summary>
		private string _frameModel = "";

		/// <summary>���Y�ԑ�ԍ��J�n</summary>
		private Int32 _stProduceFrameNo;

		/// <summary>���Y�ԑ�ԍ��I��</summary>
		private Int32 _edProduceFrameNo;

		/// <summary>���Y�N��</summary>
		/// <remarks>YYYYDD</remarks>
        private Int32 _produceTypeOfYear;


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

		/// public propaty name  :  FrameModel
		/// <summary>�ԑ�^���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԑ�^���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FrameModel
		{
			get { return _frameModel; }
			set { _frameModel = value; }
		}

		/// public propaty name  :  StProduceFrameNo
		/// <summary>���Y�ԑ�ԍ��J�n�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Y�ԑ�ԍ��J�n�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StProduceFrameNo
		{
			get { return _stProduceFrameNo; }
			set { _stProduceFrameNo = value; }
		}

		/// public propaty name  :  EdProduceFrameNo
		/// <summary>���Y�ԑ�ԍ��I���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Y�ԑ�ԍ��I���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdProduceFrameNo
		{
			get { return _edProduceFrameNo; }
			set { _edProduceFrameNo = value; }
		}

		/// public propaty name  :  ProduceTypeOfYear
		/// <summary>���Y�N���v���p�e�B</summary>
		/// <value>YYYYDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Y�N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Int32 ProduceTypeOfYear
		{
			get { return _produceTypeOfYear; }
			set { _produceTypeOfYear = value; }
		}


		/// <summary>
		/// ���Y�N�����o���ʃN���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>PrdTypYearRetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PrdTypYearRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public PrdTypYearRetWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
	/// </summary>
	/// <returns>PrdTypYearRetWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   PrdTypYearRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public class PrdTypYearRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate �����o

		/// <summary>
		///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PrdTypYearRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  PrdTypYearRetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is PrdTypYearRetWork || graph is ArrayList || graph is PrdTypYearRetWork[]))
				throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PrdTypYearRetWork).FullName));

			if (graph != null && graph is PrdTypYearRetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrdTypYearRetWork");

			//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
			int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is PrdTypYearRetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((PrdTypYearRetWork[])graph).Length;
			}
			else if (graph is PrdTypYearRetWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

			//���[�J�[�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
			//�ԑ�^��
			serInfo.MemberInfo.Add(typeof(string)); //FrameModel
			//���Y�ԑ�ԍ��J�n
			serInfo.MemberInfo.Add(typeof(Int32)); //StProduceFrameNo
			//���Y�ԑ�ԍ��I��
			serInfo.MemberInfo.Add(typeof(Int32)); //EdProduceFrameNo
			//���Y�N��
			serInfo.MemberInfo.Add(typeof(Int32)); //ProduceTypeOfYear


			serInfo.Serialize(writer, serInfo);
			if (graph is PrdTypYearRetWork)
			{
				PrdTypYearRetWork temp = (PrdTypYearRetWork)graph;

				SetPrdTypYearRetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is PrdTypYearRetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((PrdTypYearRetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (PrdTypYearRetWork temp in lst)
				{
					SetPrdTypYearRetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// PrdTypYearRetWork�����o��(public�v���p�e�B��)
		/// </summary>
		private const int currentMemberCount = 5;

		/// <summary>
		///  PrdTypYearRetWork�C���X�^���X��������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PrdTypYearRetWork�̃C���X�^���X����������</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private void SetPrdTypYearRetWork(System.IO.BinaryWriter writer, PrdTypYearRetWork temp)
		{
			//���[�J�[�R�[�h
			writer.Write(temp.MakerCode);
			//�ԑ�^��
			writer.Write(temp.FrameModel);
			//���Y�ԑ�ԍ��J�n
			writer.Write(temp.StProduceFrameNo);
			//���Y�ԑ�ԍ��I��
			writer.Write(temp.EdProduceFrameNo);
			//���Y�N��
			writer.Write(temp.ProduceTypeOfYear);

		}

		/// <summary>
		///  PrdTypYearRetWork�C���X�^���X�擾
		/// </summary>
		/// <returns>PrdTypYearRetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PrdTypYearRetWork�̃C���X�^���X���擾���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private PrdTypYearRetWork GetPrdTypYearRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
			// serInfo.MemberInfo.Count < currentMemberCount
			// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

			PrdTypYearRetWork temp = new PrdTypYearRetWork();

			//���[�J�[�R�[�h
			temp.MakerCode = reader.ReadInt32();
			//�ԑ�^��
			temp.FrameModel = reader.ReadString();
			//���Y�ԑ�ԍ��J�n
			temp.StProduceFrameNo = reader.ReadInt32();
			//���Y�ԑ�ԍ��I��
			temp.EdProduceFrameNo = reader.ReadInt32();
			//���Y�N��
			temp.ProduceTypeOfYear = reader.ReadInt32();


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
		/// <returns>PrdTypYearRetWork�N���X�̃C���X�^���X(object)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PrdTypYearRetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				PrdTypYearRetWork temp = GetPrdTypYearRetWork(reader, serInfo);
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
					retValue = (PrdTypYearRetWork[])lst.ToArray(typeof(PrdTypYearRetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}
