using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   AddressWork
	/// <summary>
	///                      �Z�����[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �Z�����[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2005/03/07</br>
	/// <br>Genarated Date   :   2006/04/13  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2006/4/7  ����@���j</br>
	/// <br>                 :   ���ʃt�@�C���w�b�_�ύX�i���ڍ폜�j</br>
	/// <br>                 :   �E��ƃR�[�h</br>
	/// <br>                 :   �EGUID</br>
	/// <br>                 :   �E�X�V�]�ƈ��R�[�h</br>
	/// <br>                 :   �E�X�V�A�Z���u��ID1</br>
	/// <br>                 :   �E�X�V�A�Z���u��ID2</br>
	/// <br>                 :   �E�v���C�}���[�L�[�̍폜�i�C���f�b�N�X�̂݁j</br>
	/// </remarks>
	[Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class AddressWork : IFileHeaderOffer, ICloneable
	{
		/// <summary>�쐬����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _createDateTime;

		/// <summary>�X�V����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _updateDateTime;

		/// <summary>�_���폜�敪</summary>
		/// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>�X�֔ԍ�</summary>
		private string _postNo = "";

		/// <summary>�s���{���R�[�h</summary>
		/// <remarks>�s���{���s��Q���ނ̏�2��</remarks>
		private Int32 _addressCode1Upper;

		/// <summary>�s��S�R�[�h</summary>
		/// <remarks>�s���{���s��Q���ނ̉�3��</remarks>
		private Int32 _addressCode1Lower;

		/// <summary>�����R�[�h</summary>
		private Int32 _addressCode2;

		/// <summary>���R�[�h</summary>
		private Int32 _addressCode3;

		/// <summary>���X�֔ԍ�</summary>
		private string _oldPostNo = "";

		/// <summary>���s���{���R�[�h</summary>
		/// <remarks>�s���{���s��Q���ނ̏�2��</remarks>
		private Int32 _oldAddressCode11;

		/// <summary>���s��S�R�[�h</summary>
		/// <remarks>�s���{���s��Q���ނ̉�3��</remarks>
		private Int32 _oldAddressCode12;

		/// <summary>�������R�[�h</summary>
		private Int32 _oldAddressCode2;

		/// <summary>�����R�[�h</summary>
		private Int32 _oldAddressCode3;

		/// <summary>�Z������</summary>
		private string _addressName = "";

		/// <summary>�Z���J�i</summary>
		private string _addressKana = "";

		/// <summary>�Z���A���R�[�h1</summary>
		private Int32 _addrConnectCd1;

		/// <summary>�����Z������1</summary>
		private string _divAddress1 = "";

		/// <summary>�Z���A���R�[�h2</summary>
		private Int32 _addrConnectCd2;

		/// <summary>�����Z������2</summary>
		private string _divAddress2 = "";

		/// <summary>�Z���A���R�[�h3</summary>
		private Int32 _addrConnectCd3;

		/// <summary>�����Z������3</summary>
		private string _divAddress3 = "";

		/// <summary>�Z���A���R�[�h4</summary>
		private Int32 _addrConnectCd4;

		/// <summary>�����Z������4</summary>
		private string _divAddress4 = "";

		/// <summary>�Z���A���R�[�h5</summary>
		private Int32 _addrConnectCd5;

		/// <summary>�����Z������5</summary>
		private string _divAddress5 = "";


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
			get{return _createDateTime;}
			set{_createDateTime = value;}
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
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
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
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

		/// public propaty name  :  PostNo
		/// <summary>�X�֔ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�֔ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PostNo
		{
			get{return _postNo;}
			set{_postNo = value;}
		}

		/// public propaty name  :  AddressCode1Upper
		/// <summary>�s���{���R�[�h�v���p�e�B</summary>
		/// <value>�s���{���s��Q���ނ̏�2��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �s���{���R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AddressCode1Upper
		{
			get{return _addressCode1Upper;}
			set{_addressCode1Upper = value;}
		}

		/// public propaty name  :  AddressCode1Lower
		/// <summary>�s��S�R�[�h�v���p�e�B</summary>
		/// <value>�s���{���s��Q���ނ̉�3��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �s��S�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AddressCode1Lower
		{
			get{return _addressCode1Lower;}
			set{_addressCode1Lower = value;}
		}

		/// public propaty name  :  AddressCode2
		/// <summary>�����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AddressCode2
		{
			get{return _addressCode2;}
			set{_addressCode2 = value;}
		}

		/// public propaty name  :  AddressCode3
		/// <summary>���R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AddressCode3
		{
			get{return _addressCode3;}
			set{_addressCode3 = value;}
		}

		/// public propaty name  :  OldPostNo
		/// <summary>���X�֔ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���X�֔ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OldPostNo
		{
			get{return _oldPostNo;}
			set{_oldPostNo = value;}
		}

		/// public propaty name  :  OldAddressCode11
		/// <summary>���s���{���R�[�h�v���p�e�B</summary>
		/// <value>�s���{���s��Q���ނ̏�2��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���s���{���R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OldAddressCode11
		{
			get{return _oldAddressCode11;}
			set{_oldAddressCode11 = value;}
		}

		/// public propaty name  :  OldAddressCode12
		/// <summary>���s��S�R�[�h�v���p�e�B</summary>
		/// <value>�s���{���s��Q���ނ̉�3��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���s��S�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OldAddressCode12
		{
			get{return _oldAddressCode12;}
			set{_oldAddressCode12 = value;}
		}

		/// public propaty name  :  OldAddressCode2
		/// <summary>�������R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OldAddressCode2
		{
			get{return _oldAddressCode2;}
			set{_oldAddressCode2 = value;}
		}

		/// public propaty name  :  OldAddressCode3
		/// <summary>�����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OldAddressCode3
		{
			get{return _oldAddressCode3;}
			set{_oldAddressCode3 = value;}
		}

		/// public propaty name  :  AddressName
		/// <summary>�Z�����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddressName
		{
			get{return _addressName;}
			set{_addressName = value;}
		}

		/// public propaty name  :  AddressKana
		/// <summary>�Z���J�i�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z���J�i�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddressKana
		{
			get{return _addressKana;}
			set{_addressKana = value;}
		}

		/// public propaty name  :  AddrConnectCd1
		/// <summary>�Z���A���R�[�h1�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z���A���R�[�h1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AddrConnectCd1
		{
			get{return _addrConnectCd1;}
			set{_addrConnectCd1 = value;}
		}

		/// public propaty name  :  DivAddress1
		/// <summary>�����Z������1�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����Z������1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DivAddress1
		{
			get{return _divAddress1;}
			set{_divAddress1 = value;}
		}

		/// public propaty name  :  AddrConnectCd2
		/// <summary>�Z���A���R�[�h2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z���A���R�[�h2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AddrConnectCd2
		{
			get{return _addrConnectCd2;}
			set{_addrConnectCd2 = value;}
		}

		/// public propaty name  :  DivAddress2
		/// <summary>�����Z������2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����Z������2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DivAddress2
		{
			get{return _divAddress2;}
			set{_divAddress2 = value;}
		}

		/// public propaty name  :  AddrConnectCd3
		/// <summary>�Z���A���R�[�h3�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z���A���R�[�h3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AddrConnectCd3
		{
			get{return _addrConnectCd3;}
			set{_addrConnectCd3 = value;}
		}

		/// public propaty name  :  DivAddress3
		/// <summary>�����Z������3�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����Z������3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DivAddress3
		{
			get{return _divAddress3;}
			set{_divAddress3 = value;}
		}

		/// public propaty name  :  AddrConnectCd4
		/// <summary>�Z���A���R�[�h4�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z���A���R�[�h4�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AddrConnectCd4
		{
			get{return _addrConnectCd4;}
			set{_addrConnectCd4 = value;}
		}

		/// public propaty name  :  DivAddress4
		/// <summary>�����Z������4�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����Z������4�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DivAddress4
		{
			get{return _divAddress4;}
			set{_divAddress4 = value;}
		}

		/// public propaty name  :  AddrConnectCd5
		/// <summary>�Z���A���R�[�h5�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z���A���R�[�h5�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AddrConnectCd5
		{
			get{return _addrConnectCd5;}
			set{_addrConnectCd5 = value;}
		}

		/// public propaty name  :  DivAddress5
		/// <summary>�����Z������5�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����Z������5�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DivAddress5
		{
			get{return _divAddress5;}
			set{_divAddress5 = value;}
		}


		/// <summary>
		/// �Z�����[�N�R���X�g���N�^
		/// </summary>
		/// <returns>AddressWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   AddressWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public AddressWork()
		{
		}
		
		#region ICloneable �����o

        /// <summary>
        /// �N���[������
        /// </summary>
        /// <returns></returns>
		public object Clone()
		{
			return MemberwiseClone();
		}
		
		#endregion
		
	}

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>AddressWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   AddressWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class AddressWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AddressWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  AddressWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is AddressWork || graph is ArrayList || graph is AddressWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(AddressWork).FullName));

            if (graph != null && graph is AddressWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.AddressWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is AddressWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((AddressWork[])graph).Length;
            }
            else if (graph is AddressWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //�X�֔ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PostNo
            //�s���{���R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //AddressCode1Upper
            //�s��S�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //AddressCode1Lower
            //�����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //AddressCode2
            //���R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //AddressCode3
            //���X�֔ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //OldPostNo
            //���s���{���R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //OldAddressCode11
            //���s��S�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //OldAddressCode12
            //�������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //OldAddressCode2
            //�����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //OldAddressCode3
            //�Z������
            serInfo.MemberInfo.Add(typeof(string)); //AddressName
            //�Z���J�i
            serInfo.MemberInfo.Add(typeof(string)); //AddressKana
            //�Z���A���R�[�h1
            serInfo.MemberInfo.Add(typeof(Int32)); //AddrConnectCd1
            //�����Z������1
            serInfo.MemberInfo.Add(typeof(string)); //DivAddress1
            //�Z���A���R�[�h2
            serInfo.MemberInfo.Add(typeof(Int32)); //AddrConnectCd2
            //�����Z������2
            serInfo.MemberInfo.Add(typeof(string)); //DivAddress2
            //�Z���A���R�[�h3
            serInfo.MemberInfo.Add(typeof(Int32)); //AddrConnectCd3
            //�����Z������3
            serInfo.MemberInfo.Add(typeof(string)); //DivAddress3
            //�Z���A���R�[�h4
            serInfo.MemberInfo.Add(typeof(Int32)); //AddrConnectCd4
            //�����Z������4
            serInfo.MemberInfo.Add(typeof(string)); //DivAddress4
            //�Z���A���R�[�h5
            serInfo.MemberInfo.Add(typeof(Int32)); //AddrConnectCd5
            //�����Z������5
            serInfo.MemberInfo.Add(typeof(string)); //DivAddress5


            serInfo.Serialize(writer, serInfo);
            if (graph is AddressWork)
            {
                AddressWork temp = (AddressWork)graph;

                SetAddressWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is AddressWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((AddressWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (AddressWork temp in lst)
                {
                    SetAddressWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// AddressWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 25;

        /// <summary>
        ///  AddressWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AddressWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetAddressWork(System.IO.BinaryWriter writer, AddressWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //�X�֔ԍ�
            writer.Write(temp.PostNo);
            //�s���{���R�[�h
            writer.Write(temp.AddressCode1Upper);
            //�s��S�R�[�h
            writer.Write(temp.AddressCode1Lower);
            //�����R�[�h
            writer.Write(temp.AddressCode2);
            //���R�[�h
            writer.Write(temp.AddressCode3);
            //���X�֔ԍ�
            writer.Write(temp.OldPostNo);
            //���s���{���R�[�h
            writer.Write(temp.OldAddressCode11);
            //���s��S�R�[�h
            writer.Write(temp.OldAddressCode12);
            //�������R�[�h
            writer.Write(temp.OldAddressCode2);
            //�����R�[�h
            writer.Write(temp.OldAddressCode3);
            //�Z������
            writer.Write(temp.AddressName);
            //�Z���J�i
            writer.Write(temp.AddressKana);
            //�Z���A���R�[�h1
            writer.Write(temp.AddrConnectCd1);
            //�����Z������1
            writer.Write(temp.DivAddress1);
            //�Z���A���R�[�h2
            writer.Write(temp.AddrConnectCd2);
            //�����Z������2
            writer.Write(temp.DivAddress2);
            //�Z���A���R�[�h3
            writer.Write(temp.AddrConnectCd3);
            //�����Z������3
            writer.Write(temp.DivAddress3);
            //�Z���A���R�[�h4
            writer.Write(temp.AddrConnectCd4);
            //�����Z������4
            writer.Write(temp.DivAddress4);
            //�Z���A���R�[�h5
            writer.Write(temp.AddrConnectCd5);
            //�����Z������5
            writer.Write(temp.DivAddress5);

        }

        /// <summary>
        ///  AddressWork�C���X�^���X�擾
        /// </summary>
        /// <returns>AddressWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AddressWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private AddressWork GetAddressWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            AddressWork temp = new AddressWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //�X�֔ԍ�
            temp.PostNo = reader.ReadString();
            //�s���{���R�[�h
            temp.AddressCode1Upper = reader.ReadInt32();
            //�s��S�R�[�h
            temp.AddressCode1Lower = reader.ReadInt32();
            //�����R�[�h
            temp.AddressCode2 = reader.ReadInt32();
            //���R�[�h
            temp.AddressCode3 = reader.ReadInt32();
            //���X�֔ԍ�
            temp.OldPostNo = reader.ReadString();
            //���s���{���R�[�h
            temp.OldAddressCode11 = reader.ReadInt32();
            //���s��S�R�[�h
            temp.OldAddressCode12 = reader.ReadInt32();
            //�������R�[�h
            temp.OldAddressCode2 = reader.ReadInt32();
            //�����R�[�h
            temp.OldAddressCode3 = reader.ReadInt32();
            //�Z������
            temp.AddressName = reader.ReadString();
            //�Z���J�i
            temp.AddressKana = reader.ReadString();
            //�Z���A���R�[�h1
            temp.AddrConnectCd1 = reader.ReadInt32();
            //�����Z������1
            temp.DivAddress1 = reader.ReadString();
            //�Z���A���R�[�h2
            temp.AddrConnectCd2 = reader.ReadInt32();
            //�����Z������2
            temp.DivAddress2 = reader.ReadString();
            //�Z���A���R�[�h3
            temp.AddrConnectCd3 = reader.ReadInt32();
            //�����Z������3
            temp.DivAddress3 = reader.ReadString();
            //�Z���A���R�[�h4
            temp.AddrConnectCd4 = reader.ReadInt32();
            //�����Z������4
            temp.DivAddress4 = reader.ReadString();
            //�Z���A���R�[�h5
            temp.AddrConnectCd5 = reader.ReadInt32();
            //�����Z������5
            temp.DivAddress5 = reader.ReadString();


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
        /// <returns>AddressWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AddressWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                AddressWork temp = GetAddressWork(reader, serInfo);
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
                    retValue = (AddressWork[])lst.ToArray(typeof(AddressWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
