using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;


namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   UsrPartsSubstRetWork
	/// <summary>
	///                      ���[�U�[��֒��o���ʃN���X���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���[�U�[��֒��o���ʃN���X���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/04/12  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class UsrPartsSubstRetWork
	{
		/// <summary>���[�J�[�R�[�h</summary>
		private Int32 _makerCode;

		/// <summary>�i��(-�t�i��)</summary>
		private string _prtsNoWithHyphen = string.Empty;

		/// <summary>��֏���</summary>
		private Int32 _substOrder;

		/// <summary>��֌����[�J�[�R�[�h</summary>
		private Int32 _substSorMakerCd;

		/// <summary>��֌��i��(-�t�i��)</summary>
		private string _substSorPartsNo = string.Empty;

		/// <summary>��֐惁�[�J�[�R�[�h</summary>
		private Int32 _substDestMakerCd;

		/// <summary>��֐�i��(-�t�i��)</summary>
		private string _substDestPartsNo = string.Empty;

		/// <summary>�K�p�J�n�N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _applyStDate;

		/// <summary>�K�p�I���N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _applyEdDate;


		/// public property name  :  MakerCode
		/// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
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

		/// public property name  :  PrtsNoWithHyphen
		/// <summary>�i��(-�t�i��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �i��(-�t�i��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PrtsNoWithHyphen
		{
			get { return _prtsNoWithHyphen; }
			set { _prtsNoWithHyphen = value; }
		}

		/// public property name  :  SubstOrder
		/// <summary>��֏��ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��֏��ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SubstOrder
		{
			get { return _substOrder; }
			set { _substOrder = value; }
		}

		/// public property name  :  SubstSorMakerCd
		/// <summary>��֌����[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��֌����[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SubstSorMakerCd
		{
			get { return _substSorMakerCd; }
			set { _substSorMakerCd = value; }
		}

		/// public property name  :  SubstSorPartsNo
		/// <summary>��֌��i��(-�t�i��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��֌��i��(-�t�i��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SubstSorPartsNo
		{
			get { return _substSorPartsNo; }
			set { _substSorPartsNo = value; }
		}

		/// public property name  :  SubstDestMakerCd
		/// <summary>��֐惁�[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��֐惁�[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SubstDestMakerCd
		{
			get { return _substDestMakerCd; }
			set { _substDestMakerCd = value; }
		}

		/// public property name  :  SubstDestPartsNo
		/// <summary>��֐�i��(-�t�i��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��֐�i��(-�t�i��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SubstDestPartsNo
		{
			get { return _substDestPartsNo; }
			set { _substDestPartsNo = value; }
		}

		/// public property name  :  ApplyStDate
		/// <summary>�K�p�J�n�N�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �K�p�J�n�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ApplyStDate
		{
			get { return _applyStDate; }
			set { _applyStDate = value; }
		}

		/// public property name  :  ApplyEdDate
		/// <summary>�K�p�I���N�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �K�p�I���N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ApplyEdDate
		{
			get { return _applyEdDate; }
			set { _applyEdDate = value; }
		}

		/// <summary>
		/// ���[�U�[��֒��o���ʃN���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>UsrPartsSubstRetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UsrPartsSubstRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public UsrPartsSubstRetWork()
		{
		}

        /// <summary>
        /// ���[�U�[��֒��o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="srcObject">�R�s�[����\�[�X�C���X�^���X</param>
        /// <returns>UsrPartsSubstRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UsrPartsSubstRetWork�N���X�̃C���X�^���X�̃R�s�[�𐶐����܂�</br>
        /// <br>Programer        :   30290</br>
        /// </remarks>
        public UsrPartsSubstRetWork(UsrPartsSubstRetWork srcObject)
        {
            _makerCode = srcObject.MakerCode;
            _prtsNoWithHyphen = srcObject.PrtsNoWithHyphen;
            _substOrder = srcObject.SubstOrder;
            
            _substSorMakerCd = srcObject.SubstSorMakerCd;
            _substSorPartsNo = srcObject.SubstSorPartsNo;

            _substDestMakerCd = srcObject.SubstDestMakerCd;
            _substDestPartsNo = srcObject.SubstDestPartsNo;

            _applyStDate = srcObject.ApplyStDate;
            _applyEdDate = srcObject.ApplyEdDate;
        }

	}

	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
	/// </summary>
	/// <returns>UsrPartsSubstRetWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   UsrPartsSubstRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public class UsrPartsSubstRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate �����o

		/// <summary>
		///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UsrPartsSubstRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  UsrPartsSubstRetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is UsrPartsSubstRetWork || graph is ArrayList || graph is UsrPartsSubstRetWork[]))
				throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(UsrPartsSubstRetWork).FullName));

			if (graph != null && graph is UsrPartsSubstRetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.UsrPartsSubstRetWork");

			//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
			int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is UsrPartsSubstRetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((UsrPartsSubstRetWork[])graph).Length;
			}
			else if (graph is UsrPartsSubstRetWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

			//���[�J�[�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
			//�i��(-�t�i��)
			serInfo.MemberInfo.Add(typeof(string)); //PrtsNoWithHyphen
			//��֏���
			serInfo.MemberInfo.Add(typeof(Int32)); //SubstOrder
			//��֌����[�J�[�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //SubstSorMakerCd
			//��֌��i��(-�t�i��)
			serInfo.MemberInfo.Add(typeof(string)); //SubstSorPartsNo
			//��֐惁�[�J�[�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //SubstDestMakerCd
			//��֐�i��(-�t�i��)
			serInfo.MemberInfo.Add(typeof(string)); //SubstDestPartsNo
			//�K�p�J�n�N����
			serInfo.MemberInfo.Add(typeof(Int32)); //ApplyStDate
			//�K�p�I���N����
			serInfo.MemberInfo.Add(typeof(Int32)); //ApplyEdDate


			serInfo.Serialize(writer, serInfo);
			if (graph is UsrPartsSubstRetWork)
			{
				UsrPartsSubstRetWork temp = (UsrPartsSubstRetWork)graph;

				SetUsrPartsSubstRetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is UsrPartsSubstRetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((UsrPartsSubstRetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (UsrPartsSubstRetWork temp in lst)
				{
					SetUsrPartsSubstRetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// UsrPartsSubstRetWork�����o��(public�v���p�e�B��)
		/// </summary>
		private const int currentMemberCount = 9;

		/// <summary>
		///  UsrPartsSubstRetWork�C���X�^���X��������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UsrPartsSubstRetWork�̃C���X�^���X����������</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private void SetUsrPartsSubstRetWork(System.IO.BinaryWriter writer, UsrPartsSubstRetWork temp)
		{
			//���[�J�[�R�[�h
			writer.Write(temp.MakerCode);
			//�i��(-�t�i��)
			writer.Write(temp.PrtsNoWithHyphen);
			//��֏���
			writer.Write(temp.SubstOrder);
			//��֌����[�J�[�R�[�h
			writer.Write(temp.SubstSorMakerCd);
			//��֌��i��(-�t�i��)
			writer.Write(temp.SubstSorPartsNo);
			//��֐惁�[�J�[�R�[�h
			writer.Write(temp.SubstDestMakerCd);
			//��֐�i��(-�t�i��)
			writer.Write(temp.SubstDestPartsNo);
			//�K�p�J�n�N����
			writer.Write(temp.ApplyStDate);
			//�K�p�I���N����
			writer.Write(temp.ApplyEdDate);

		}

		/// <summary>
		///  UsrPartsSubstRetWork�C���X�^���X�擾
		/// </summary>
		/// <returns>UsrPartsSubstRetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UsrPartsSubstRetWork�̃C���X�^���X���擾���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private UsrPartsSubstRetWork GetUsrPartsSubstRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
			// serInfo.MemberInfo.Count < currentMemberCount
			// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

			UsrPartsSubstRetWork temp = new UsrPartsSubstRetWork();

			//���[�J�[�R�[�h
			temp.MakerCode = reader.ReadInt32();
			//�i��(-�t�i��)
			temp.PrtsNoWithHyphen = reader.ReadString();
			//��֏���
			temp.SubstOrder = reader.ReadInt32();
			//��֌����[�J�[�R�[�h
			temp.SubstSorMakerCd = reader.ReadInt32();
			//��֌��i��(-�t�i��)
			temp.SubstSorPartsNo = reader.ReadString();
			//��֐惁�[�J�[�R�[�h
			temp.SubstDestMakerCd = reader.ReadInt32();
			//��֐�i��(-�t�i��)
			temp.SubstDestPartsNo = reader.ReadString();
			//�K�p�J�n�N����
			temp.ApplyStDate = reader.ReadInt32();
			//�K�p�I���N����
			temp.ApplyEdDate = reader.ReadInt32();


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
		/// <returns>UsrPartsSubstRetWork�N���X�̃C���X�^���X(object)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   UsrPartsSubstRetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				UsrPartsSubstRetWork temp = GetUsrPartsSubstRetWork(reader, serInfo);
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
					retValue = (UsrPartsSubstRetWork[])lst.ToArray(typeof(UsrPartsSubstRetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}
