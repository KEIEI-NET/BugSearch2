using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   UsrJoinPartsRetWork
	/// <summary>
	///                      ���[�U�[�������o���ʃN���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���[�U�[�������o���ʃN���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/06/05  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class UsrJoinPartsRetWork
	{
		/// <summary>�����\������</summary>
		/// <remarks>4,5,6,7,8,10,11������̌������������݂���ꍇ�̘A��</remarks>
		private Int32 _joinDispOrder;

		/// <summary>���������[�J�[�R�[�h</summary>
		private Int32 _joinSourceMakerCode;

		/// <summary>�������i��(�|�t���i��)</summary>
		/// <remarks>�n�C�t���t��</remarks>
		private string _joinSourPartsNoWithH = string.Empty;

		/// <summary>�������i��(�|�����i��)</summary>
		private string _joinSourPartsNoNoneH = string.Empty;

		/// <summary>�����惁�[�J�[�R�[�h</summary>
		private Int32 _joinDestMakerCd;

		/// <summary>������i��(�|�t���i��)</summary>
		/// <remarks>�n�C�t���t��</remarks>
		private string _joinDestPartsNo = string.Empty;

		/// <summary>����QTY</summary>
		private Double _joinQty;

		/// <summary>�����K�i�E���L����</summary>
		private string _joinSpecialNote = string.Empty;

		/// <summary>�����f�[�^�񋟓��t</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _joinOfferDate;


		/// public property name  :  JoinDispOrder
		/// <summary>�����\�����ʃv���p�e�B</summary>
		/// <value>4,5,6,7,8,10,11������̌������������݂���ꍇ�̘A��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����\�����ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 JoinDispOrder
		{
			get { return _joinDispOrder; }
			set { _joinDispOrder = value; }
		}

		/// public property name  :  JoinSourceMakerCode
		/// <summary>���������[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 JoinSourceMakerCode
		{
			get { return _joinSourceMakerCode; }
			set { _joinSourceMakerCode = value; }
		}

		/// public property name  :  JoinSourPartsNoWithH
		/// <summary>�������i��(�|�t���i��)�v���p�e�B</summary>
		/// <value>�n�C�t���t��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������i��(�|�t���i��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string JoinSourPartsNoWithH
		{
			get { return _joinSourPartsNoWithH; }
			set { _joinSourPartsNoWithH = value; }
		}

		/// public property name  :  JoinSourPartsNoNoneH
		/// <summary>�������i��(�|�����i��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������i��(�|�����i��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string JoinSourPartsNoNoneH
		{
			get { return _joinSourPartsNoNoneH; }
			set { _joinSourPartsNoNoneH = value; }
		}

		/// public property name  :  JoinDestMakerCd
		/// <summary>�����惁�[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����惁�[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 JoinDestMakerCd
		{
			get { return _joinDestMakerCd; }
			set { _joinDestMakerCd = value; }
		}

		/// public property name  :  JoinDestPartsNo
		/// <summary>������i��(�|�t���i��)�v���p�e�B</summary>
		/// <value>�n�C�t���t��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������i��(�|�t���i��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string JoinDestPartsNo
		{
			get { return _joinDestPartsNo; }
			set { _joinDestPartsNo = value; }
		}

		/// public property name  :  JoinQty
		/// <summary>����QTY�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����QTY�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double JoinQty
		{
			get { return _joinQty; }
			set { _joinQty = value; }
		}

		/// public property name  :  JoinSpecialNote
		/// <summary>�����K�i�E���L�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����K�i�E���L�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string JoinSpecialNote
		{
			get { return _joinSpecialNote; }
			set { _joinSpecialNote = value; }
		}

		/// public property name  :  JoinOfferDate
		/// <summary>�����f�[�^�񋟓��t�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����f�[�^�񋟓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 JoinOfferDate
		{
			get { return _joinOfferDate; }
			set { _joinOfferDate = value; }
		}


		/// <summary>
		/// ���[�U�[�������o���ʃN���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>UsrJoinPartsRetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UsrJoinPartsRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public UsrJoinPartsRetWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
	/// </summary>
	/// <returns>UsrJoinPartsRetWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   UsrJoinPartsRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public class UsrJoinPartsRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate �����o

		/// <summary>
		///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UsrJoinPartsRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  UsrJoinPartsRetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is UsrJoinPartsRetWork || graph is ArrayList || graph is UsrJoinPartsRetWork[]))
				throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(UsrJoinPartsRetWork).FullName));

			if (graph != null && graph is UsrJoinPartsRetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.UsrJoinPartsRetWork");

			//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
			int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is UsrJoinPartsRetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((UsrJoinPartsRetWork[])graph).Length;
			}
			else if (graph is UsrJoinPartsRetWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

			//�����\������
			serInfo.MemberInfo.Add(typeof(Int32)); //JoinDispOrder
			//���������[�J�[�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //JoinSourceMakerCode
			//�������i��(�|�t���i��)
			serInfo.MemberInfo.Add(typeof(string)); //JoinSourPartsNoWithH
			//�������i��(�|�����i��)
			serInfo.MemberInfo.Add(typeof(string)); //JoinSourPartsNoNoneH
			//�����惁�[�J�[�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //JoinDestMakerCd
			//������i��(�|�t���i��)
			serInfo.MemberInfo.Add(typeof(string)); //JoinDestPartsNo
			//����QTY
			serInfo.MemberInfo.Add(typeof(Double)); //JoinQty
			//�����K�i�E���L����
			serInfo.MemberInfo.Add(typeof(string)); //JoinSpecialNote
			//�����f�[�^�񋟓��t
			serInfo.MemberInfo.Add(typeof(Int32)); //JoinOfferDate


			serInfo.Serialize(writer, serInfo);
			if (graph is UsrJoinPartsRetWork)
			{
				UsrJoinPartsRetWork temp = (UsrJoinPartsRetWork)graph;

				SetUsrJoinPartsRetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is UsrJoinPartsRetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((UsrJoinPartsRetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (UsrJoinPartsRetWork temp in lst)
				{
					SetUsrJoinPartsRetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// UsrJoinPartsRetWork�����o��(public�v���p�e�B��)
		/// </summary>
		private const int currentMemberCount = 9;

		/// <summary>
		///  UsrJoinPartsRetWork�C���X�^���X��������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UsrJoinPartsRetWork�̃C���X�^���X����������</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private void SetUsrJoinPartsRetWork(System.IO.BinaryWriter writer, UsrJoinPartsRetWork temp)
		{
			//�����\������
			writer.Write(temp.JoinDispOrder);
			//���������[�J�[�R�[�h
			writer.Write(temp.JoinSourceMakerCode);
			//�������i��(�|�t���i��)
			writer.Write(temp.JoinSourPartsNoWithH);
			//�������i��(�|�����i��)
			writer.Write(temp.JoinSourPartsNoNoneH);
			//�����惁�[�J�[�R�[�h
			writer.Write(temp.JoinDestMakerCd);
			//������i��(�|�t���i��)
			writer.Write(temp.JoinDestPartsNo);
			//����QTY
			writer.Write(temp.JoinQty);
			//�����K�i�E���L����
			writer.Write(temp.JoinSpecialNote);
			//�����f�[�^�񋟓��t
			writer.Write(temp.JoinOfferDate);

		}

		/// <summary>
		///  UsrJoinPartsRetWork�C���X�^���X�擾
		/// </summary>
		/// <returns>UsrJoinPartsRetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UsrJoinPartsRetWork�̃C���X�^���X���擾���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private UsrJoinPartsRetWork GetUsrJoinPartsRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
			// serInfo.MemberInfo.Count < currentMemberCount
			// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

			UsrJoinPartsRetWork temp = new UsrJoinPartsRetWork();

			//�����\������
			temp.JoinDispOrder = reader.ReadInt32();
			//���������[�J�[�R�[�h
			temp.JoinSourceMakerCode = reader.ReadInt32();
			//�������i��(�|�t���i��)
			temp.JoinSourPartsNoWithH = reader.ReadString();
			//�������i��(�|�����i��)
			temp.JoinSourPartsNoNoneH = reader.ReadString();
			//�����惁�[�J�[�R�[�h
			temp.JoinDestMakerCd = reader.ReadInt32();
			//������i��(�|�t���i��)
			temp.JoinDestPartsNo = reader.ReadString();
			//����QTY
			temp.JoinQty = reader.ReadDouble();
			//�����K�i�E���L����
			temp.JoinSpecialNote = reader.ReadString();
			//�����f�[�^�񋟓��t
			temp.JoinOfferDate = reader.ReadInt32();


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
		/// <returns>UsrJoinPartsRetWork�N���X�̃C���X�^���X(object)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UsrJoinPartsRetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				UsrJoinPartsRetWork temp = GetUsrJoinPartsRetWork(reader, serInfo);
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
					retValue = (UsrJoinPartsRetWork[])lst.ToArray(typeof(UsrJoinPartsRetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}
