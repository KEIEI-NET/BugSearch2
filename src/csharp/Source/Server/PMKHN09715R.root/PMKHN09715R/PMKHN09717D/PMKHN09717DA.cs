using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ConnectInfoWork
    /// <summary>
    ///                      �ڑ����񃏁[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ڑ����񃏁[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2012/12/12</br>
    /// <br>Genarated Date   :   2012/12/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ConnectInfoWork : IFileHeader
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

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

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�ڑ��p�X���[�h</summary>
        private string _connectPassword = "";

        /// <summary>�ڑ����[�UID</summary>
        private string _connectUserId = "";

        /// <summary>������z�敪�i�_�C�n�c�j</summary>
        private Int32 _daihatsuOrdreDiv;

        /// <summary>���O�C���^�C���A�E�g</summary>
        /// <remarks>�b</remarks>
        private Int32 _loginTimeoutVal;

        /// <summary>����URL</summary>
        private string _orderUrl = "";

        /// <summary>�݌Ɋm�FURL</summary>
        private string _stockCheckUrl = "";

        // ----- ADD 2013/07/05 �c���� ----->>>>>
        /// <summary>�ڑ��v���O�����^�C�v</summary>
        private Int32 _cnectProgramType;
        // ----- ADD 2013/07/05 �c���� -----<<<<<

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

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  ConnectPassword
        /// <summary>�ڑ��p�X���[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڑ��p�X���[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ConnectPassword
        {
            get { return _connectPassword; }
            set { _connectPassword = value; }
        }

        /// public propaty name  :  ConnectUserId
        /// <summary>�ڑ����[�UID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڑ����[�UID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ConnectUserId
        {
            get { return _connectUserId; }
            set { _connectUserId = value; }
        }

        /// public propaty name  :  DaihatsuOrdreDiv
        /// <summary>������z�敪�i�_�C�n�c�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�敪�i�_�C�n�c�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DaihatsuOrdreDiv
        {
            get { return _daihatsuOrdreDiv; }
            set { _daihatsuOrdreDiv = value; }
        }

        /// public propaty name  :  LoginTimeoutVal
        /// <summary>���O�C���^�C���A�E�g�v���p�e�B</summary>
        /// <value>�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�C���^�C���A�E�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LoginTimeoutVal
        {
            get { return _loginTimeoutVal; }
            set { _loginTimeoutVal = value; }
        }

        /// public propaty name  :  OrderUrl
        /// <summary>����URL�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����URL�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OrderUrl
        {
            get { return _orderUrl; }
            set { _orderUrl = value; }
        }

        /// public propaty name  :  StockCheckUrl
        /// <summary>�݌Ɋm�FURL�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɋm�FURL�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockCheckUrl
        {
            get { return _stockCheckUrl; }
            set { _stockCheckUrl = value; }
        }

        // ----- ADD 2013/07/05 �c���� ----->>>>>
        /// public propaty name  :  CnectProgramType
        /// <summary>�ڑ��v���O�����^�C�v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڑ��v���O�����^�C�v�v���p�e�B</br>
        /// <br>Programer        :   �c����</br>
        /// <br>Date             :   2013/07/05</br>
        /// </remarks>
        public Int32 CnectProgramType
        {
            get { return _cnectProgramType; }
            set { _cnectProgramType = value; }
        }
        // ----- ADD 2013/07/05 �c���� -----<<<<<

        /// <summary>
        /// �ڑ����񃏁[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ConnectInfoWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConnectInfoWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ConnectInfoWork()
        {
        }

        /// <summary>
        /// �ڑ�����ݒ�}�X�^����
        /// </summary>
        /// <param name="createDateTime">�쐬����</param>
        /// <param name="updateDateTime">�X�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalDeleteCode">�_���폜�敪</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="connectPassword">�p�X���[�h</param>
        /// <param name="connectUserId">���[�U�[�R�[�h</param>
        /// <param name="daihatsuOrdreDiv">�����p�A�h���X</param>
        /// <param name="loginTimeoutVal">�^�C���A�E�g</param>
        /// <param name="orderUrl">�h���C��</param>
        /// <param name="stockCheckUrl">�v���g�R��</param>
        //public ConnectInfoWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Int32 logicalDeleteCode, Int32 supplierCd, string connectPassword, string connectUserId, Int32 daihatsuOrdreDiv, Int32 loginTimeoutVal, string orderUrl, string stockCheckUrl) // DEL 2013/07/05 �c����
        public ConnectInfoWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Int32 logicalDeleteCode, Int32 supplierCd, string connectPassword, string connectUserId, Int32 daihatsuOrdreDiv, Int32 loginTimeoutVal, string orderUrl, string stockCheckUrl, Int32 cnectProgramType) // ADD 2013/07/05 �c����
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._logicalDeleteCode = logicalDeleteCode;
            this._supplierCd  = supplierCd;
            this._connectPassword = connectPassword;
            this._connectUserId = connectUserId;
            this._daihatsuOrdreDiv = daihatsuOrdreDiv;
            this._loginTimeoutVal = loginTimeoutVal;
            this._orderUrl = orderUrl;
            this._stockCheckUrl = stockCheckUrl;
            this._cnectProgramType = cnectProgramType; // ADD 2013/07/05 �c����
        }

        /// <summary>
        /// �ڑ�����ݒ�}�X�^��������
        /// </summary>
        /// <returns>CampaignPrcPrSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ConnectInfoWork�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ConnectInfoWork Clone()
        {
            //return new ConnectInfoWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._logicalDeleteCode, this._supplierCd, this._connectPassword, this._connectUserId, this._daihatsuOrdreDiv, this._loginTimeoutVal, this._orderUrl, this._stockCheckUrl); // DEL 2013/07/05 �c����
            return new ConnectInfoWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._logicalDeleteCode, this._supplierCd, this._connectPassword, this._connectUserId, this._daihatsuOrdreDiv, this._loginTimeoutVal, this._orderUrl, this._stockCheckUrl, this._cnectProgramType); // ADD 2013/07/05 �c����
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>ConnectInfoWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   ConnectInfoWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class ConnectInfoWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConnectInfoWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ConnectInfoWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ConnectInfoWork || graph is ArrayList || graph is ConnectInfoWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(ConnectInfoWork).FullName));

            if (graph != null && graph is ConnectInfoWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ConnectInfoWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ConnectInfoWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ConnectInfoWork[])graph).Length;
            }
            else if (graph is ConnectInfoWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
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
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�ڑ��p�X���[�h
            serInfo.MemberInfo.Add(typeof(string)); //ConnectPassword
            //�ڑ����[�UID
            serInfo.MemberInfo.Add(typeof(string)); //ConnectUserId
            //������z�敪�i�_�C�n�c�j
            serInfo.MemberInfo.Add(typeof(Int32)); //DaihatsuOrdreDiv
            //���O�C���^�C���A�E�g
            serInfo.MemberInfo.Add(typeof(Int32)); //LoginTimeoutVal
            //����URL
            serInfo.MemberInfo.Add(typeof(string)); //OrderUrl
            //�݌Ɋm�FURL
            serInfo.MemberInfo.Add(typeof(string)); //StockCheckUrl
            //�ڑ��v���O�����^�C�v
            serInfo.MemberInfo.Add(typeof(Int32)); //CnectProgramType // ADD 2013/07/05 �c����


            serInfo.Serialize(writer, serInfo);
            if (graph is ConnectInfoWork)
            {
                ConnectInfoWork temp = (ConnectInfoWork)graph;

                SetConnectInfoWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ConnectInfoWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ConnectInfoWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ConnectInfoWork temp in lst)
                {
                    SetConnectInfoWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ConnectInfoWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 15; // DEL 2013/07/05 �c����
        private const int currentMemberCount = 16; // ADD 2013/07/05 �c����

        /// <summary>
        ///  ConnectInfoWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConnectInfoWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetConnectInfoWork(System.IO.BinaryWriter writer, ConnectInfoWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
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
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�ڑ��p�X���[�h
            writer.Write(temp.ConnectPassword);
            //�ڑ����[�UID
            writer.Write(temp.ConnectUserId);
            //������z�敪�i�_�C�n�c�j
            writer.Write(temp.DaihatsuOrdreDiv);
            //���O�C���^�C���A�E�g
            writer.Write(temp.LoginTimeoutVal);
            //����URL
            writer.Write(temp.OrderUrl);
            //�݌Ɋm�FURL
            writer.Write(temp.StockCheckUrl);
            //�ڑ��v���O�����^�C�v
            writer.Write(temp.CnectProgramType); // ADD 2013/07/05 �c����

        }

        /// <summary>
        ///  ConnectInfoWork�C���X�^���X�擾
        /// </summary>
        /// <returns>ConnectInfoWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConnectInfoWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private ConnectInfoWork GetConnectInfoWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            ConnectInfoWork temp = new ConnectInfoWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
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
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�ڑ��p�X���[�h
            temp.ConnectPassword = reader.ReadString();
            //�ڑ����[�UID
            temp.ConnectUserId = reader.ReadString();
            //������z�敪�i�_�C�n�c�j
            temp.DaihatsuOrdreDiv = reader.ReadInt32();
            //���O�C���^�C���A�E�g
            temp.LoginTimeoutVal = reader.ReadInt32();
            //����URL
            temp.OrderUrl = reader.ReadString();
            //�݌Ɋm�FURL
            temp.StockCheckUrl = reader.ReadString();
            //�ڑ��v���O�����^�C�vURL
            temp.CnectProgramType = reader.ReadInt32(); // ADD 2013/07/05 �c����


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
        /// <returns>ConnectInfoWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConnectInfoWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ConnectInfoWork temp = GetConnectInfoWork(reader, serInfo);
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
                    retValue = (ConnectInfoWork[])lst.ToArray(typeof(ConnectInfoWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
