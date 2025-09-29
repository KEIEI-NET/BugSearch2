using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

//���_�K�C�h���́A�d�����_�K�C�h���̂�Y�ꂸ�ɒǉ����邱�ƁI�I

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// �o�l�p�󕥓`�[�敪
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�l�ŕs�����Ă���󕥓`�[�敪�ł�</br>
    /// <br>Programmer : 22008�@�����@���n</br>
    /// <br>Date       : 2009.01.21</br>
    /// <br></br>
    /// </remarks>
    public enum ct_AcPaySlipCd_PM
    {
        /// <summary>�g��</summary>
        assemble = 60, 
        /// <summary>����</summary>
        separate = 61, 
        /// <summary>��[����</summary>
        replacement = 70, 
        /// <summary>��[�o��</summary>
        replaceShip = 71, 
    }


	/// public class name:   StockAdjustWork
	/// <summary>
	///                      �݌ɒ����f�[�^���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �݌ɒ����f�[�^���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2008/3/25</br>
	/// <br>Genarated Date   :   2008/08/25  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2008/6/20  ����</br>
	/// <br>                 :   �󕥌��`�[�敪,�󕥌�����敪�̕⑫��</br>
	/// <br>                 :   �u42:�}�X�^�����e�v�ǉ�</br>
	/// <br>Update Note      :   2008/6/30  ����</br>
	/// <br>                 :   �󕥌�����敪�̕⑫��</br>
	/// <br>                 :   �u42:�}�X�^�����e�v�폜</br>
	/// <br>Update Note      :   2008/8/22  ����</br>
	/// <br>                 :   �����ڍ폜</br>
	/// <br>                 :   �@���͒S���҃R�[�h</br>
	/// <br>                 :   �@���͒S���Җ���</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �@�d�����_�R�[�h</br>
	/// <br>                 :   �@�d�����͎҃R�[�h</br>
	/// <br>                 :   �@�d�����͎Җ���</br>
	/// <br>                 :   �@�d���S���҃R�[�h</br>
	/// <br>                 :   �@�d���S���Җ���</br>
	/// <br>                 :   �@�d�����z���v</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockAdjustWork : IFileHeader
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

		/// <summary>���_�R�[�h</summary>
		private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        private string _sectionGuideNm = "";
        
        /// <summary>�݌ɒ����`�[�ԍ�</summary>
		private Int32 _stockAdjustSlipNo;

		/// <summary>�󕥌��`�[�敪</summary>
		/// <remarks>10:�d��,11:���,12:��v��,13:�݌Ɏd��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,42:�}�X�^�����e,50:�I��</remarks>
		private Int32 _acPaySlipCd;

		/// <summary>�󕥌�����敪</summary>
		/// <remarks>10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���</remarks>
		private Int32 _acPayTransCd;

		/// <summary>�������t</summary>
		private DateTime _adjustDate;

		/// <summary>���͓��t</summary>
		private DateTime _inputDay;

        /// <summary>�d�����_�R�[�h</summary>
        private string _stockSectionCd = "";
 
        /// <summary>�d�����_�K�C�h����</summary>
        private string _stockSectionGuideNm = "";

		/// <summary>�d�����͎҃R�[�h</summary>
		private string _stockInputCode = "";

		/// <summary>�d�����͎Җ���</summary>
		private string _stockInputName = "";

		/// <summary>�d���S���҃R�[�h</summary>
		private string _stockAgentCode = "";

		/// <summary>�d���S���Җ���</summary>
		private string _stockAgentName = "";

		/// <summary>�d�����z���v</summary>
		private Int64 _stockSubttlPrice;

		/// <summary>�`�[���l</summary>
		private string _slipNote = "";


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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
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
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
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
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
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
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
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
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
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

		/// public propaty name  :  SectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

        /// public propaty name  :  SectionGuideNm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }
        
        /// public propaty name  :  StockAdjustSlipNo
		/// <summary>�݌ɒ����`�[�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɒ����`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockAdjustSlipNo
		{
			get{return _stockAdjustSlipNo;}
			set{_stockAdjustSlipNo = value;}
		}

		/// public propaty name  :  AcPaySlipCd
		/// <summary>�󕥌��`�[�敪�v���p�e�B</summary>
		/// <value>10:�d��,11:���,12:��v��,13:�݌Ɏd��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,42:�}�X�^�����e,50:�I��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󕥌��`�[�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcPaySlipCd
		{
			get{return _acPaySlipCd;}
			set{_acPaySlipCd = value;}
		}

		/// public propaty name  :  AcPayTransCd
		/// <summary>�󕥌�����敪�v���p�e�B</summary>
		/// <value>10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󕥌�����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcPayTransCd
		{
			get{return _acPayTransCd;}
			set{_acPayTransCd = value;}
		}

		/// public propaty name  :  AdjustDate
		/// <summary>�������t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AdjustDate
		{
			get{return _adjustDate;}
			set{_adjustDate = value;}
		}

		/// public propaty name  :  InputDay
		/// <summary>���͓��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime InputDay
		{
			get{return _inputDay;}
			set{_inputDay = value;}
		}

		/// public propaty name  :  StockSectionCd
		/// <summary>�d�����_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockSectionCd
		{
			get{return _stockSectionCd;}
			set{_stockSectionCd = value;}
		}

        /// public propaty name  :  StockSectionGuideNm
        /// <summary>�d�����_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockSectionGuideNm
        {
            get { return _stockSectionGuideNm; }
            set { _stockSectionGuideNm = value; }
        }
        
        /// public propaty name  :  StockInputCode
		/// <summary>�d�����͎҃R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����͎҃R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockInputCode
		{
			get{return _stockInputCode;}
			set{_stockInputCode = value;}
		}

		/// public propaty name  :  StockInputName
		/// <summary>�d�����͎Җ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����͎Җ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockInputName
		{
			get{return _stockInputName;}
			set{_stockInputName = value;}
		}

		/// public propaty name  :  StockAgentCode
		/// <summary>�d���S���҃R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���S���҃R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockAgentCode
		{
			get{return _stockAgentCode;}
			set{_stockAgentCode = value;}
		}

		/// public propaty name  :  StockAgentName
		/// <summary>�d���S���Җ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���S���Җ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockAgentName
		{
			get{return _stockAgentName;}
			set{_stockAgentName = value;}
		}

		/// public propaty name  :  StockSubttlPrice
		/// <summary>�d�����z���v�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����z���v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StockSubttlPrice
		{
			get{return _stockSubttlPrice;}
			set{_stockSubttlPrice = value;}
		}

		/// public propaty name  :  SlipNote
		/// <summary>�`�[���l�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[���l�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SlipNote
		{
			get{return _slipNote;}
			set{_slipNote = value;}
		}


		/// <summary>
		/// �݌ɒ����f�[�^���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>StockAdjustWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockAdjustWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockAdjustWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockAdjustWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockAdjustWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockAdjustWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
	    #region ICustomSerializationSurrogate �����o
    	
	    /// <summary>
	    ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
	    /// </summary>
	    /// <remarks>
	    /// <br>Note�@�@�@�@�@�@ :   StockAdjustWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	    /// <br>Programer        :   ��������</br>
	    /// </remarks>
	    public void Serialize(System.IO.BinaryWriter writer, object graph)
	    {
		    // TODO:  StockAdjustWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
		    if(  writer == null )
			    throw new ArgumentNullException();

		    if( graph != null && !( graph is StockAdjustWork || graph is ArrayList || graph is StockAdjustWork[]) )
			    throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockAdjustWork).FullName ) );

		    if( graph != null && graph is StockAdjustWork )
		    {
			    Type t = graph.GetType();
			    if( !CustomFormatterServices.NeedCustomSerialization( t ) )
				    throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
		    }

		    //SerializationTypeInfo
		    Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockAdjustWork" );

		    //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
		    int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
		    if( graph is ArrayList )
		    {
			    serInfo.RetTypeInfo = 0;
			    occurrence = ((ArrayList)graph).Count;
		    }else if( graph is StockAdjustWork[] )
		    {
			    serInfo.RetTypeInfo = 2;
			    occurrence = ((StockAdjustWork[])graph).Length;
		    }
		    else if( graph is StockAdjustWork )
		    {
			    serInfo.RetTypeInfo = 1;
			    occurrence = 1;
		    }

		    serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

		    //�쐬����
		    serInfo.MemberInfo.Add( typeof(Int64) ); //CreateDateTime
		    //�X�V����
		    serInfo.MemberInfo.Add( typeof(Int64) ); //UpdateDateTime
		    //��ƃR�[�h
		    serInfo.MemberInfo.Add( typeof(string) ); //EnterpriseCode
		    //GUID
		    serInfo.MemberInfo.Add( typeof(byte[]) );  //FileHeaderGuid
		    //�X�V�]�ƈ��R�[�h
		    serInfo.MemberInfo.Add( typeof(string) ); //UpdEmployeeCode
		    //�X�V�A�Z���u��ID1
		    serInfo.MemberInfo.Add( typeof(string) ); //UpdAssemblyId1
		    //�X�V�A�Z���u��ID2
		    serInfo.MemberInfo.Add( typeof(string) ); //UpdAssemblyId2
		    //�_���폜�敪
		    serInfo.MemberInfo.Add( typeof(Int32) ); //LogicalDeleteCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //�݌ɒ����`�[�ԍ�
		    serInfo.MemberInfo.Add( typeof(Int32) ); //StockAdjustSlipNo
		    //�󕥌��`�[�敪
		    serInfo.MemberInfo.Add( typeof(Int32) ); //AcPaySlipCd
		    //�󕥌�����敪
		    serInfo.MemberInfo.Add( typeof(Int32) ); //AcPayTransCd
		    //�������t
		    serInfo.MemberInfo.Add( typeof(Int32) ); //AdjustDate
		    //���͓��t
		    serInfo.MemberInfo.Add( typeof(Int32) ); //InputDay
            //�d�����_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd
            //�d�����_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionGuideNm
            //�d�����͎҃R�[�h
		    serInfo.MemberInfo.Add( typeof(string) ); //StockInputCode
		    //�d�����͎Җ���
		    serInfo.MemberInfo.Add( typeof(string) ); //StockInputName
		    //�d���S���҃R�[�h
		    serInfo.MemberInfo.Add( typeof(string) ); //StockAgentCode
		    //�d���S���Җ���
		    serInfo.MemberInfo.Add( typeof(string) ); //StockAgentName
		    //�d�����z���v
		    serInfo.MemberInfo.Add( typeof(Int64) ); //StockSubttlPrice
		    //�`�[���l
		    serInfo.MemberInfo.Add( typeof(string) ); //SlipNote

    			
		    serInfo.Serialize( writer, serInfo );
		    if( graph is StockAdjustWork )
		    {
			    StockAdjustWork temp = (StockAdjustWork)graph;

			    SetStockAdjustWork(writer, temp);
		    }
		    else
		    {
			    ArrayList lst= null;
			    if(graph is StockAdjustWork[])
			    {
				    lst = new ArrayList();
				    lst.AddRange((StockAdjustWork[])graph);
			    }
			    else
			    {
				    lst = (ArrayList)graph;	
			    }

			    foreach(StockAdjustWork temp in lst)
			    {
				    SetStockAdjustWork(writer, temp);
			    }

		    }

    		
	    }


	    /// <summary>
	    /// StockAdjustWork�����o��(public�v���p�e�B��)
	    /// </summary>
	    private const int currentMemberCount = 23;
    		
	    /// <summary>
	    ///  StockAdjustWork�C���X�^���X��������
	    /// </summary>
	    /// <remarks>
	    /// <br>Note�@�@�@�@�@�@ :   StockAdjustWork�̃C���X�^���X����������</br>
	    /// <br>Programer        :   ��������</br>
	    /// </remarks>
	    private void SetStockAdjustWork( System.IO.BinaryWriter writer, StockAdjustWork temp )
	    {
		    //�쐬����
		    writer.Write( (Int64)temp.CreateDateTime.Ticks );
		    //�X�V����
		    writer.Write( (Int64)temp.UpdateDateTime.Ticks );
		    //��ƃR�[�h
		    writer.Write( temp.EnterpriseCode );
		    //GUID
		    byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
		    writer.Write( fileHeaderGuidArray.Length );
		    writer.Write( temp.FileHeaderGuid.ToByteArray() );
		    //�X�V�]�ƈ��R�[�h
		    writer.Write( temp.UpdEmployeeCode );
		    //�X�V�A�Z���u��ID1
		    writer.Write( temp.UpdAssemblyId1 );
		    //�X�V�A�Z���u��ID2
		    writer.Write( temp.UpdAssemblyId2 );
		    //�_���폜�敪
		    writer.Write( temp.LogicalDeleteCode );
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideNm);
            //�݌ɒ����`�[�ԍ�
		    writer.Write( temp.StockAdjustSlipNo );
		    //�󕥌��`�[�敪
		    writer.Write( temp.AcPaySlipCd );
		    //�󕥌�����敪
		    writer.Write( temp.AcPayTransCd );
		    //�������t
		    writer.Write( (Int64)temp.AdjustDate.Ticks );
		    //���͓��t
		    writer.Write( (Int64)temp.InputDay.Ticks );
            //�d�����_�R�[�h
            writer.Write(temp.StockSectionCd);
            //�d�����_�K�C�h����
            writer.Write(temp.StockSectionGuideNm);
            //�d�����͎҃R�[�h
		    writer.Write( temp.StockInputCode );
		    //�d�����͎Җ���
		    writer.Write( temp.StockInputName );
		    //�d���S���҃R�[�h
		    writer.Write( temp.StockAgentCode );
		    //�d���S���Җ���
		    writer.Write( temp.StockAgentName );
		    //�d�����z���v
		    writer.Write( temp.StockSubttlPrice );
		    //�`�[���l
		    writer.Write( temp.SlipNote );

	    }

	    /// <summary>
	    ///  StockAdjustWork�C���X�^���X�擾
	    /// </summary>
	    /// <returns>StockAdjustWork�N���X�̃C���X�^���X</returns>
	    /// <remarks>
	    /// <br>Note�@�@�@�@�@�@ :   StockAdjustWork�̃C���X�^���X���擾���܂�</br>
	    /// <br>Programer        :   ��������</br>
	    /// </remarks>
	    private StockAdjustWork GetStockAdjustWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
	    {
		    // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
		    // serInfo.MemberInfo.Count < currentMemberCount
		    // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

		    StockAdjustWork temp = new StockAdjustWork();

		    //�쐬����
		    temp.CreateDateTime = new DateTime(reader.ReadInt64());
		    //�X�V����
		    temp.UpdateDateTime = new DateTime(reader.ReadInt64());
		    //��ƃR�[�h
		    temp.EnterpriseCode = reader.ReadString();
		    //GUID
		    int lenOfFileHeaderGuidArray = reader.ReadInt32();
		    byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
		    temp.FileHeaderGuid = new Guid( fileHeaderGuidArray );
		    //�X�V�]�ƈ��R�[�h
		    temp.UpdEmployeeCode = reader.ReadString();
		    //�X�V�A�Z���u��ID1
		    temp.UpdAssemblyId1 = reader.ReadString();
		    //�X�V�A�Z���u��ID2
		    temp.UpdAssemblyId2 = reader.ReadString();
		    //�_���폜�敪
		    temp.LogicalDeleteCode = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideNm = reader.ReadString();
            //�݌ɒ����`�[�ԍ�
		    temp.StockAdjustSlipNo = reader.ReadInt32();
		    //�󕥌��`�[�敪
		    temp.AcPaySlipCd = reader.ReadInt32();
		    //�󕥌�����敪
		    temp.AcPayTransCd = reader.ReadInt32();
		    //�������t
		    temp.AdjustDate = new DateTime(reader.ReadInt64());
		    //���͓��t
		    temp.InputDay = new DateTime(reader.ReadInt64());
            //�d�����_�R�[�h
            temp.StockSectionCd = reader.ReadString();
            //�d�����_�K�C�h����
            temp.StockSectionGuideNm = reader.ReadString();
            //�d�����͎҃R�[�h
		    temp.StockInputCode = reader.ReadString();
		    //�d�����͎Җ���
		    temp.StockInputName = reader.ReadString();
		    //�d���S���҃R�[�h
		    temp.StockAgentCode = reader.ReadString();
		    //�d���S���Җ���
		    temp.StockAgentName = reader.ReadString();
		    //�d�����z���v
		    temp.StockSubttlPrice = reader.ReadInt64();
		    //�`�[���l
		    temp.SlipNote = reader.ReadString();

    			
		    //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
		    //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
		    //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
		    //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
		    for( int k = currentMemberCount ; k < serInfo.MemberInfo.Count ; ++k )
		    {
			    //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
			    //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
			    //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
			    //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
			    int optCount = 0;   
			    object oMemberType = serInfo.MemberInfo[k];
			    if( oMemberType is Type )
			    {
				    Type t = (Type)oMemberType;
				    object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
				    if( t.Equals( typeof(int) ) )
				    {
					    optCount = Convert.ToInt32(oData);
				    }
				    else
				    {
					    optCount = 0;
				    }
			    }
			    else if( oMemberType is string )
			    {
				    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
				    object userData = formatter.Deserialize( reader );  //�ǂݔ�΂�
			    }
		    }
		    return temp;
	    }

	    /// <summary>
	    ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
	    /// </summary>
	    /// <returns>StockAdjustWork�N���X�̃C���X�^���X(object)</returns>
	    /// <remarks>
	    /// <br>Note�@�@�@�@�@�@ :   StockAdjustWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
	    /// <br>Programer        :   ��������</br>
	    /// </remarks>
	    public object Deserialize(System.IO.BinaryReader reader)
	    {
		    object retValue = null;
		    Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
		    ArrayList lst = new ArrayList();
		    for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
		    {
			    StockAdjustWork temp = GetStockAdjustWork( reader, serInfo );
			    lst.Add( temp );
		    }
		    switch(serInfo.RetTypeInfo)
		    {
			    case 0:
				    retValue = lst;
				    break;
			    case 1:
				    retValue = lst[0];
				    break;
			    case 2:
				    retValue = (StockAdjustWork[])lst.ToArray(typeof(StockAdjustWork));
				    break;
		    }
		    return retValue;
	    }

	    #endregion
    }

}
