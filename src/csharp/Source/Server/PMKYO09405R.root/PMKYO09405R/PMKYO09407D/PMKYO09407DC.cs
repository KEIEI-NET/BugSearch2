using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SndRcvHisCondWork
    /// <summary>
    ///                      ����M�������O�f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����M�������O�f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   �{���@���a</br>
    /// <br>Genarated Date   :   2011/07/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/7/23  �g���Y</br>
    /// <br>                 :   �u���M�Ώە����_�R�[�h�v����u���M�Ώۋ��_�R�[�h�v�֏C��</br>
    /// <br>                 :   �u���M�Ώە��J�n�����v����u���M�ΏۊJ�n�����v�֏C��</br>
	/// <br>                 :   �u���M�Ώە��I�������v����u���M�ΏۏI�������v�֏C��</br>
	/// <br>Update Note      :   2011/9/14  ����</br>
	/// <br>                 :   Redmine #25051 #24952 ���M�������O�����e�@�f�[�^�\���̕s��</br>
    /// <br>Update Note      :   2012/07/24 �L�w�� </br>
    /// <br>                 :   10801804-00�ARedmine#31026 ���_�Ǘ��c�b���O���Ԓǉ�����</br>
    /// <br>Update Note      :   2012/10/16 ������</br>
    ///	<br>			         10801804-00�ARedmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SndRcvHisCondWork : IFileHeader
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�Q�Ɗ�ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _paraEnterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���M��(�J�n)</summary>
        /// <remarks>200601011212(������t�{�����j</remarks>
        private Int64 _sendDateTimeStart;

        /// <summary>���M��(�I��)</summary>
        /// <remarks>200601011212(������t�{�����j</remarks>
        private Int64 _sendDateTimeEnd;

        /// <summary>����M�敪</summary>
        /// <remarks>0:���M�i�o�́j,1:��M�i�捞�j</remarks>
        private Int32 _sendOrReceiveDivCd;

        /// <summary>���</summary>
        /// <remarks>0:�f�[�^�@1:�}�X�^</remarks>
        private Int32 _kind;

        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

		// ADD 2011.09.14 --------->>>>>
		/// <summary>�p�����[�^���_�R�[�h</summary>
		private string _paraSectionCode = "";

		/// <summary>����M�敪</summary>
		/// <remarks>0:���M�i�o�́j,1:��M�i�捞�j</remarks>
		private Int32 _paraSendOrReceiveDivCd;
		// ADD 2011.09.14 ---------<<<<<

        // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
        //// ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026-------->>>>>
        ///// <summary>����M�������O���M�ԍ�</summary>
        ///// <remarks>�ԍ��Ǘ��ݒ�ɂč̔�</remarks>
        //private Int32 _sndRcvHisConsNo;

        ///// <summary>����M�t�@�C���h�c</summary>
        //private string _sndRcvFileID = "";
        //// ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026---------<<<<<

        //// ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026-------->>>>>
        ///// public propaty name  :  SndRcvHisConsNo
        ///// <summary>����M�������O���M�ԍ��v���p�e�B</summary>
        ///// <value>�ԍ��Ǘ��ݒ�ɂč̔�</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ����M�������O���M�ԍ��v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 SndRcvHisConsNo
        //{
        //    get { return _sndRcvHisConsNo; }
        //    set { _sndRcvHisConsNo = value; }
        //}

        ///// public propaty name  :  SndRcvFileID
        ///// <summary>����M�t�@�C���h�c</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ����M�t�@�C���h�c�p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string SndRcvFileID
        //{
        //    get { return _sndRcvFileID; }
        //    set { _sndRcvFileID = value; }
        //}
        //// ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026---------<<<<<
        // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  ParaEnterpriseCode
        /// <summary>�Q�Ɗ�ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Q�Ɗ�ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ParaEnterpriseCode
        {
            get { return _paraEnterpriseCode; }
            set { _paraEnterpriseCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SendDateTimeStart
        /// <summary>���M��(�J�n)�v���p�e�B</summary>
        /// <value>200601011212(������t�{�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M��(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SendDateTimeStart
        {
            get { return _sendDateTimeStart; }
            set { _sendDateTimeStart = value; }
        }

        /// public propaty name  :  SendDateTimeEnd
        /// <summary>���M��(�I��)�v���p�e�B</summary>
        /// <value>200601011212(������t�{�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M��(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SendDateTimeEnd
        {
            get { return _sendDateTimeEnd; }
            set { _sendDateTimeEnd = value; }
        }

        /// public propaty name  :  SendOrReceiveDivCd
        /// <summary>����M�敪�v���p�e�B</summary>
        /// <value>0:���M�i�o�́j,1:��M�i�捞�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendOrReceiveDivCd
        {
            get { return _sendOrReceiveDivCd; }
            set { _sendOrReceiveDivCd = value; }
        }

        /// public propaty name  :  Kind
        /// <summary>��ʃv���p�e�B</summary>
        /// <value>0:�f�[�^�@1:�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }

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
            get { return _createDateTime; }
            set { _createDateTime = value; }
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
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
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
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }
		// ADD 2011.09.14 --------->>>>>
		/// public propaty name  :  ParaSectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ParaSectionCode
		{
			get { return _paraSectionCode; }
			set { _paraSectionCode = value; }
		}

		/// public propaty name  :  ParaSendOrReceiveDivCd
		/// <summary>����M�敪�v���p�e�B</summary>
		/// <value>0:���M�i�o�́j,1:��M�i�捞�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����M�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ParaSendOrReceiveDivCd
		{
			get { return _paraSendOrReceiveDivCd; }
			set { _paraSendOrReceiveDivCd = value; }
		}
		// ADD 2011.09.14 ---------<<<<<

        /// <summary>
        /// ����M�������O�f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SndRcvHisCondWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SndRcvHisCondWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SndRcvHisCondWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SndRcvHisCondWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SndRcvHisCondWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SndRcvHisCondWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SndRcvHisCondWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2012/10/16 ������</br>
        ///	<br>			         10801804-00�ARedmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SndRcvHisCondWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SndRcvHisCondWork || graph is ArrayList || graph is SndRcvHisCondWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SndRcvHisCondWork).FullName));

            if (graph != null && graph is SndRcvHisCondWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SndRcvHisCondWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SndRcvHisCondWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SndRcvHisCondWork[])graph).Length;
            }
            else if (graph is SndRcvHisCondWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //�Q�Ɗ�ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ParaEnterpriseCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���M��(�J�n)
            serInfo.MemberInfo.Add(typeof(Int64)); //SendDateTimeStart
            //���M��(�I��)
            serInfo.MemberInfo.Add(typeof(Int64)); //SendDateTimeEnd
            //����M�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SendOrReceiveDivCd
            //���
            serInfo.MemberInfo.Add(typeof(Int32)); //Kind
            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode

			// ADD 2011.09.14 ---------->>>>>
			//���_�R�[�h
			serInfo.MemberInfo.Add(typeof(string)); //ParaSectionCode
			//����M�敪
			serInfo.MemberInfo.Add(typeof(Int32)); //ParaSendOrReceiveDivCd
			// ADD 2011.09.14 ----------<<<<<

            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
            //// ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026-------->>>>>
            ////����M�������O���M�ԍ�
            //serInfo.MemberInfo.Add(typeof(Int32)); //SndRcvHisConsNo
            ////����M�t�@�C���h�c
            //serInfo.MemberInfo.Add(typeof(string)); //SndRcvFileID
            //// ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026---------<<<<<
            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SndRcvHisCondWork)
            {
                SndRcvHisCondWork temp = (SndRcvHisCondWork)graph;

                SetSndRcvHisCondWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SndRcvHisCondWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SndRcvHisCondWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SndRcvHisCondWork temp in lst)
                {
                    SetSndRcvHisCondWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SndRcvHisCondWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 16;
        //private const int currentMemberCount = 18;    // DEL 2012/07/24 �L�w��//DEL 2012/10/16 ������ for redmine#31026
        private const int currentMemberCount = 16; //ADD 2012/10/16 ������ for redmine#31026

        /// <summary>
        ///  SndRcvHisCondWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SndRcvHisCondWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2012/10/16 ������</br>
        ///	<br>			         10801804-00�ARedmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        /// </remarks>
        private void SetSndRcvHisCondWork(System.IO.BinaryWriter writer, SndRcvHisCondWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�Q�Ɗ�ƃR�[�h
            writer.Write(temp.ParaEnterpriseCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���M��(�J�n)
            writer.Write(temp.SendDateTimeStart);
            //���M��(�I��)
            writer.Write(temp.SendDateTimeEnd);
            //����M�敪
            writer.Write(temp.SendOrReceiveDivCd);
            //���
            writer.Write(temp.Kind);
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
			// ADD 2011.09.14 ---------->>>>>
			//���_�R�[�h
			writer.Write(temp.ParaSectionCode);
			//����M�敪
			writer.Write(temp.ParaSendOrReceiveDivCd);
			// ADD 2011.09.14 ----------<<<<<

            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
            //// ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026-------->>>>>
            ////����M�������O���M�ԍ�
            //writer.Write(temp.SndRcvHisConsNo);
            ////����M�t�@�C���h�c
            //writer.Write(temp.SndRcvFileID);
            //// ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026---------<<<<<
            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<

        }

        /// <summary>
        ///  SndRcvHisCondWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SndRcvHisCondWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SndRcvHisCondWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2012/10/16 ������</br>
        ///	<br>			         10801804-00�ARedmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        /// </remarks>
        private SndRcvHisCondWork GetSndRcvHisCondWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SndRcvHisCondWork temp = new SndRcvHisCondWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�Q�Ɗ�ƃR�[�h
            temp.ParaEnterpriseCode = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���M��(�J�n)
            temp.SendDateTimeStart = reader.ReadInt64();
            //���M��(�I��)
            temp.SendDateTimeEnd = reader.ReadInt64();
            //����M�敪
            temp.SendOrReceiveDivCd = reader.ReadInt32();
            //���
            temp.Kind = reader.ReadInt32();
            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
			// ADD 2011.09.14 ---------->>>>>
			//���_�R�[�h
			temp.ParaSectionCode = reader.ReadString();
			//����M�敪
			temp.ParaSendOrReceiveDivCd = reader.ReadInt32();
			// ADD 2011.09.14 ----------<<<<<

            // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
            //// ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026-------->>>>>
            ////����M�������O���M�ԍ�
            //temp.SndRcvHisConsNo = reader.ReadInt32();
            ////����M�t�@�C���h�c
            //temp.SndRcvFileID = reader.ReadString();
            //// ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026---------<<<<<
            // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<

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
        /// <returns>SndRcvHisCondWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SndRcvHisCondWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SndRcvHisCondWork temp = GetSndRcvHisCondWork(reader, serInfo);
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
                    retValue = (SndRcvHisCondWork[])lst.ToArray(typeof(SndRcvHisCondWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
