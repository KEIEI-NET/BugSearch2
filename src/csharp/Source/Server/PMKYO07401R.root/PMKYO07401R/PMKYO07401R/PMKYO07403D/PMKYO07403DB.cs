//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^��M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/07/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ERInfoDataWork
	/// <summary>
	///                      �G���[��񃏁[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �G���[��񃏁[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2011/07/29  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ERInfoDataWork
	{
		/// <summary>�`�[</summary>
		private string _erSlipNm = "";

		/// <summary>�`�[�ԍ�</summary>
		private string _erSalesSlipNum = "";

		/// <summary>���t</summary>
		private Int32 _erDateTime;

		/// <summary>���_�R�[�h</summary>
		private string _erSectionCode = "";

		/// <summary>���_����</summary>
		private string _erSectionNm = "";

		/// <summary>���Ӑ�/�d����R�[�h</summary>
		private Int32 _erCustCode;

		/// <summary>���Ӑ�/�d���於��</summary>
		private string _erCustName = "";

		/// <summary>�G���[���</summary>
		private string _erInfo = "";


		/// public propaty name  :  ErSlipNm
		/// <summary>�`�[�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ErSlipNm
		{
			get { return _erSlipNm; }
			set { _erSlipNm = value; }
		}

		/// public propaty name  :  ErSalesSlipNum
		/// <summary>�`�[�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ErSalesSlipNum
		{
			get { return _erSalesSlipNum; }
			set { _erSalesSlipNum = value; }
		}

		/// public propaty name  :  ErDateTime
		/// <summary>���t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ErDateTime
		{
			get { return _erDateTime; }
			set { _erDateTime = value; }
		}

		/// public propaty name  :  ErSectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ErSectionCode
		{
			get { return _erSectionCode; }
			set { _erSectionCode = value; }
		}

		/// public propaty name  :  ErSectionNm
		/// <summary>���_���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ErSectionNm
		{
			get { return _erSectionNm; }
			set { _erSectionNm = value; }
		}

		/// public propaty name  :  ErCustCode
		/// <summary>���Ӑ�/�d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�/�d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ErCustCode
		{
			get { return _erCustCode; }
			set { _erCustCode = value; }
		}

		/// public propaty name  :  ErCustName
		/// <summary>���Ӑ�/�d���於�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�/�d���於�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ErCustName
		{
			get { return _erCustName; }
			set { _erCustName = value; }
		}

		/// public propaty name  :  ErInfo
		/// <summary>�G���[���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �G���[���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ErInfo
		{
			get { return _erInfo; }
			set { _erInfo = value; }
		}


		/// <summary>
		/// �G���[��񃏁[�N�R���X�g���N�^
		/// </summary>
		/// <returns>ERInfoDataWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ERInfoDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ERInfoDataWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
	/// </summary>
	/// <returns>ERInfoDataWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   ERInfoDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public class ERInfoDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate �����o

		/// <summary>
		///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ERInfoDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  ERInfoDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is ERInfoDataWork || graph is ArrayList || graph is ERInfoDataWork[]))
				throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(ERInfoDataWork).FullName));

			if (graph != null && graph is ERInfoDataWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ERInfoDataWork");

			//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
			int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is ERInfoDataWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((ERInfoDataWork[])graph).Length;
			}
			else if (graph is ERInfoDataWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

			//�`�[
			serInfo.MemberInfo.Add(typeof(string)); //ErSlipNm
			//�`�[�ԍ�
			serInfo.MemberInfo.Add(typeof(string)); //ErSalesSlipNum
			//���t
			serInfo.MemberInfo.Add(typeof(Int32)); //ErDateTime
			//���_�R�[�h
			serInfo.MemberInfo.Add(typeof(string)); //ErSectionCode
			//���_����
			serInfo.MemberInfo.Add(typeof(string)); //ErSectionNm
			//���Ӑ�/�d����R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //ErCustCode
			//���Ӑ�/�d���於��
			serInfo.MemberInfo.Add(typeof(string)); //ErCustName
			//�G���[���
			serInfo.MemberInfo.Add(typeof(string)); //ErInfo


			serInfo.Serialize(writer, serInfo);
			if (graph is ERInfoDataWork)
			{
				ERInfoDataWork temp = (ERInfoDataWork)graph;

				SetERInfoDataWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is ERInfoDataWork[])
				{
					lst = new ArrayList();
					lst.AddRange((ERInfoDataWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (ERInfoDataWork temp in lst)
				{
					SetERInfoDataWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// ERInfoDataWork�����o��(public�v���p�e�B��)
		/// </summary>
		private const int currentMemberCount = 8;

		/// <summary>
		///  ERInfoDataWork�C���X�^���X��������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ERInfoDataWork�̃C���X�^���X����������</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private void SetERInfoDataWork(System.IO.BinaryWriter writer, ERInfoDataWork temp)
		{
			//�`�[
			writer.Write(temp.ErSlipNm);
			//�`�[�ԍ�
			writer.Write(temp.ErSalesSlipNum);
			//���t
			writer.Write(temp.ErDateTime);
			//���_�R�[�h
			writer.Write(temp.ErSectionCode);
			//���_����
			writer.Write(temp.ErSectionNm);
			//���Ӑ�/�d����R�[�h
			writer.Write(temp.ErCustCode);
			//���Ӑ�/�d���於��
			writer.Write(temp.ErCustName);
			//�G���[���
			writer.Write(temp.ErInfo);

		}

		/// <summary>
		///  ERInfoDataWork�C���X�^���X�擾
		/// </summary>
		/// <returns>ERInfoDataWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ERInfoDataWork�̃C���X�^���X���擾���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private ERInfoDataWork GetERInfoDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
			// serInfo.MemberInfo.Count < currentMemberCount
			// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

			ERInfoDataWork temp = new ERInfoDataWork();

			//�`�[
			temp.ErSlipNm = reader.ReadString();
			//�`�[�ԍ�
			temp.ErSalesSlipNum = reader.ReadString();
			//���t
			temp.ErDateTime = reader.ReadInt32();
			//���_�R�[�h
			temp.ErSectionCode = reader.ReadString();
			//���_����
			temp.ErSectionNm = reader.ReadString();
			//���Ӑ�/�d����R�[�h
			temp.ErCustCode = reader.ReadInt32();
			//���Ӑ�/�d���於��
			temp.ErCustName = reader.ReadString();
			//�G���[���
			temp.ErInfo = reader.ReadString();


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
		/// <returns>ERInfoDataWork�N���X�̃C���X�^���X(object)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ERInfoDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				ERInfoDataWork temp = GetERInfoDataWork(reader, serInfo);
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
					retValue = (ERInfoDataWork[])lst.ToArray(typeof(ERInfoDataWork));
					break;
			}
			return retValue;
		}

		#endregion
	}


}

