using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   UsrSetPartsRetWork
	/// <summary>
	///                      ���[�U�[�Z�b�g���o���ʃN���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���[�U�[�Z�b�g���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/06/05  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class UsrSetPartsRetWork
	{
		/// <summary>�Z�b�g�e���[�J�[�R�[�h</summary>
		private Int32 _setMainMakerCd;

		/// <summary>�Z�b�g�e�i��</summary>
		/// <remarks>�n�C�t���t��</remarks>
		private string _setMainPartsNo = string.Empty;

		/// <summary>�Z�b�g�q���[�J�[�R�[�h</summary>
		private Int32 _setSubMakerCd;

		/// <summary>�Z�b�g�q�i��</summary>
		/// <remarks>�n�C�t���t��</remarks>
		private string _setSubPartsNo = string.Empty;

		/// <summary>�Z�b�g�\������</summary>
		private Int32 _setDispOrder;

		/// <summary>�Z�b�gQTY</summary>
		private Double _setQty;

		/// <summary>�Z�b�g����</summary>
		private string _setName = string.Empty;

		/// <summary>�Z�b�g�K�i�E���L����</summary>
		private string _setSpecialNote = string.Empty;

		/// <summary>�J�^���O�}��</summary>
		private string _catalogShapeNo = string.Empty;


		/// public property name  :  SetMainMakerCd
		/// <summary>�Z�b�g�e���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�b�g�e���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SetMainMakerCd
		{
			get { return _setMainMakerCd; }
			set { _setMainMakerCd = value; }
		}

		/// public property name  :  SetMainPartsNo
		/// <summary>�Z�b�g�e�i�ԃv���p�e�B</summary>
		/// <value>�n�C�t���t��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�b�g�e�i�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SetMainPartsNo
		{
			get { return _setMainPartsNo; }
			set { _setMainPartsNo = value; }
		}

		/// public property name  :  SetSubMakerCd
		/// <summary>�Z�b�g�q���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�b�g�q���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SetSubMakerCd
		{
			get { return _setSubMakerCd; }
			set { _setSubMakerCd = value; }
		}

		/// public property name  :  SetSubPartsNo
		/// <summary>�Z�b�g�q�i�ԃv���p�e�B</summary>
		/// <value>�n�C�t���t��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�b�g�q�i�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SetSubPartsNo
		{
			get { return _setSubPartsNo; }
			set { _setSubPartsNo = value; }
		}

		/// public property name  :  SetDispOrder
		/// <summary>�Z�b�g�\�����ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�b�g�\�����ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SetDispOrder
		{
			get { return _setDispOrder; }
			set { _setDispOrder = value; }
		}

		/// public property name  :  SetQty
		/// <summary>�Z�b�gQTY�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�b�gQTY�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SetQty
		{
			get { return _setQty; }
			set { _setQty = value; }
		}

		/// public property name  :  SetName
		/// <summary>�Z�b�g���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�b�g���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SetName
		{
			get { return _setName; }
			set { _setName = value; }
		}

		/// public property name  :  SetSpecialNote
		/// <summary>�Z�b�g�K�i�E���L�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�b�g�K�i�E���L�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SetSpecialNote
		{
			get { return _setSpecialNote; }
			set { _setSpecialNote = value; }
		}

		/// public property name  :  CatalogShapeNo
		/// <summary>�J�^���O�}�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�^���O�}�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CatalogShapeNo
		{
			get { return _catalogShapeNo; }
			set { _catalogShapeNo = value; }
		}


		/// <summary>
		/// ���[�U�[�Z�b�g���o���ʃN���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>UsrSetPartsRetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UsrSetPartsRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public UsrSetPartsRetWork()
		{
		}

	}
	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
	/// </summary>
	/// <returns>UsrSetPartsRetWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   UsrSetPartsRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public class UsrSetPartsRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate �����o

		/// <summary>
		///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UsrSetPartsRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  UsrSetPartsRetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is UsrSetPartsRetWork || graph is ArrayList || graph is UsrSetPartsRetWork[]))
				throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(UsrSetPartsRetWork).FullName));

			if (graph != null && graph is UsrSetPartsRetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.UsrSetPartsRetWork");

			//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
			int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is UsrSetPartsRetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((UsrSetPartsRetWork[])graph).Length;
			}
			else if (graph is UsrSetPartsRetWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

			//�Z�b�g�e���[�J�[�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //SetMainMakerCd
			//�Z�b�g�e�i��
			serInfo.MemberInfo.Add(typeof(string)); //SetMainPartsNo
			//�Z�b�g�q���[�J�[�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //SetSubMakerCd
			//�Z�b�g�q�i��
			serInfo.MemberInfo.Add(typeof(string)); //SetSubPartsNo
			//�Z�b�g�\������
			serInfo.MemberInfo.Add(typeof(Int32)); //SetDispOrder
			//�Z�b�gQTY
			serInfo.MemberInfo.Add(typeof(Double)); //SetQty
			//�Z�b�g����
			serInfo.MemberInfo.Add(typeof(string)); //SetName
			//�Z�b�g�K�i�E���L����
			serInfo.MemberInfo.Add(typeof(string)); //SetSpecialNote
			//�J�^���O�}��
			serInfo.MemberInfo.Add(typeof(string)); //CatalogShapeNo


			serInfo.Serialize(writer, serInfo);
			if (graph is UsrSetPartsRetWork)
			{
				UsrSetPartsRetWork temp = (UsrSetPartsRetWork)graph;

				SetUsrSetPartsRetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is UsrSetPartsRetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((UsrSetPartsRetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (UsrSetPartsRetWork temp in lst)
				{
					SetUsrSetPartsRetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// UsrSetPartsRetWork�����o��(public�v���p�e�B��)
		/// </summary>
		private const int currentMemberCount = 9;

		/// <summary>
		///  UsrSetPartsRetWork�C���X�^���X��������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UsrSetPartsRetWork�̃C���X�^���X����������</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private void SetUsrSetPartsRetWork(System.IO.BinaryWriter writer, UsrSetPartsRetWork temp)
		{
			//�Z�b�g�e���[�J�[�R�[�h
			writer.Write(temp.SetMainMakerCd);
			//�Z�b�g�e�i��
			writer.Write(temp.SetMainPartsNo);
			//�Z�b�g�q���[�J�[�R�[�h
			writer.Write(temp.SetSubMakerCd);
			//�Z�b�g�q�i��
			writer.Write(temp.SetSubPartsNo);
			//�Z�b�g�\������
			writer.Write(temp.SetDispOrder);
			//�Z�b�gQTY
			writer.Write(temp.SetQty);
			//�Z�b�g����
			writer.Write(temp.SetName);
			//�Z�b�g�K�i�E���L����
			writer.Write(temp.SetSpecialNote);
			//�J�^���O�}��
			writer.Write(temp.CatalogShapeNo);

		}

		/// <summary>
		///  UsrSetPartsRetWork�C���X�^���X�擾
		/// </summary>
		/// <returns>UsrSetPartsRetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UsrSetPartsRetWork�̃C���X�^���X���擾���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private UsrSetPartsRetWork GetUsrSetPartsRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
			// serInfo.MemberInfo.Count < currentMemberCount
			// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

			UsrSetPartsRetWork temp = new UsrSetPartsRetWork();

			//�Z�b�g�e���[�J�[�R�[�h
			temp.SetMainMakerCd = reader.ReadInt32();
			//�Z�b�g�e�i��
			temp.SetMainPartsNo = reader.ReadString();
			//�Z�b�g�q���[�J�[�R�[�h
			temp.SetSubMakerCd = reader.ReadInt32();
			//�Z�b�g�q�i��
			temp.SetSubPartsNo = reader.ReadString();
			//�Z�b�g�\������
			temp.SetDispOrder = reader.ReadInt32();
			//�Z�b�gQTY
			temp.SetQty = reader.ReadDouble();
			//�Z�b�g����
			temp.SetName = reader.ReadString();
			//�Z�b�g�K�i�E���L����
			temp.SetSpecialNote = reader.ReadString();
			//�J�^���O�}��
			temp.CatalogShapeNo = reader.ReadString();


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
		/// <returns>UsrSetPartsRetWork�N���X�̃C���X�^���X(object)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UsrSetPartsRetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				UsrSetPartsRetWork temp = GetUsrSetPartsRetWork(reader, serInfo);
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
					retValue = (UsrSetPartsRetWork[])lst.ToArray(typeof(UsrSetPartsRetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}
