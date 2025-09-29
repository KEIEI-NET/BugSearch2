//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^�N���A����
// �v���O�����T�v   : �f�[�^�N���A�������[�N
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/06/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   DataClearWork
	/// <summary>
	///                      �f�[�^�N���A���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �f�[�^�N���A���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2008/06/18</br>
	/// <br>Genarated Date   :   2009/06/18  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class DataClearWork
	{
		/// <summary>�e�[�u��ID</summary>
		private string _tableId = "";

		/// <summary>�e�[�u����</summary>
		private string _tableNm = "";

		/// <summary>�`�F�b�N���ǂ���</summary>
		private bool _isChecked;

		/// <summary>�����R�[�h</summary>
		private Int32 _clearCode;

		/// <summary>�����t�B�[���h</summary>
		private string _fileId = "";

		/// <summary>��������</summary>
		private string _result = "";


		/// public propaty name  :  TableId
		/// <summary>�e�[�u��ID�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e�[�u��ID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TableId
		{
			get{return _tableId;}
			set{_tableId = value;}
		}

		/// public propaty name  :  TableNm
		/// <summary>�e�[�u�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e�[�u�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TableNm
		{
			get{return _tableNm;}
			set{_tableNm = value;}
		}

		/// public propaty name  :  IsChecked
		/// <summary>�`�F�b�N���ǂ����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�F�b�N���ǂ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool IsChecked
		{
			get{return _isChecked;}
			set{_isChecked = value;}
		}

		/// public propaty name  :  ClearCode
		/// <summary>�����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ClearCode
		{
			get{return _clearCode;}
			set{_clearCode = value;}
		}

		/// public propaty name  :  FileId
		/// <summary>�����t�B�[���h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����t�B�[���h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FileId
		{
			get{return _fileId;}
			set{_fileId = value;}
		}

        /// public propaty name  :  Result
		/// <summary>�������ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public string Result
		{
            get { return _result; }
            set { _result = value; }
		}

		/// <summary>
		/// �f�[�^�N���A���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>DataClearWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   DataClearWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DataClearWork()
		{
		}
	}

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>DataClearWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   DataClearWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class DataClearWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DataClearWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  DataClearWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is DataClearWork || graph is ArrayList || graph is DataClearWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(DataClearWork).FullName));

            if (graph != null && graph is DataClearWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.DataClearWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is DataClearWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((DataClearWork[])graph).Length;
            }
            else if (graph is DataClearWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�e�[�u��ID
            serInfo.MemberInfo.Add(typeof(string)); //TableId
            //�e�[�u����
            serInfo.MemberInfo.Add(typeof(string)); //TableNm
            //�`�F�b�N���ǂ���
            serInfo.MemberInfo.Add(typeof(bool));   //IsChecked
            //�����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ClearCode
            //�����t�B�[���h
            serInfo.MemberInfo.Add(typeof(string)); //FileId
            //��������
            serInfo.MemberInfo.Add(typeof(string)); //Result


            serInfo.Serialize(writer, serInfo);
            if (graph is DataClearWork)
            {
                DataClearWork temp = (DataClearWork)graph;

                SetDataClearWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is DataClearWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((DataClearWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (DataClearWork temp in lst)
                {
                    SetDataClearWork(writer, temp);
                }

            }


        }

        /// <summary>
        /// DataClearWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 6;

        /// <summary>
        ///  DataClearWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DataClearWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetDataClearWork(System.IO.BinaryWriter writer, DataClearWork temp)
        {
            //�e�[�u��ID
            writer.Write(temp.TableId);
            //�e�[�u����
            writer.Write(temp.TableNm);
            //�`�F�b�N���ǂ���
            writer.Write(temp.IsChecked);
            //�����R�[�h
            writer.Write(temp.ClearCode);
            //�����t�B�[���h
            writer.Write(temp.FileId);
            //��������
            writer.Write(temp.Result);

        }

        /// <summary>
        ///  DataClearWork�C���X�^���X�擾
        /// </summary>
        /// <returns>DataClearWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DataClearWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private DataClearWork GetDataClearWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            DataClearWork temp = new DataClearWork();

            //�e�[�u��ID
            temp.TableId = reader.ReadString();
            //�e�[�u����
            temp.TableNm = reader.ReadString();
            //�`�F�b�N���ǂ���
            temp.IsChecked = reader.ReadBoolean();
            //�����R�[�h
            temp.ClearCode = reader.ReadInt32();
            //�����t�B�[���h
            temp.FileId = reader.ReadString();
            //��������
            temp.Result = reader.ReadString();


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
        /// <returns>DataClearWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DataClearWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                DataClearWork temp = GetDataClearWork(reader, serInfo);
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
                    retValue = (DataClearWork[])lst.ToArray(typeof(DataClearWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
