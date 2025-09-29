using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustomerSearchRetWork
    /// <summary>
    ///                      ���Ӑ挟�����ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ挟�����ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/05/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   �X�V������ǉ�</br>
    /// <br>Programmer       :   23015 �X�{ ��P</br>
    /// <br>Date             :   2008/09/05</br>
    /// <br>Update Note      :   MANTIS:14721 ���Ӑ挟�����ʂ̕\�����ڂɎ���FAX�ƋΖ���FAX��ǉ�</br>
    /// <br>Programmer       :   30517 �Ė� �x��</br>
    /// <br>Date             :   2009/12/02</br>
    /// <br></br>
    /// <br>Update Note      :   �I�����C����ʋ敪 �ǉ�</br>
    /// <br>Programmer       :   21024 ���X�� ��</br>
    /// <br>Date             :   2010/04/06 </br>
    /// <br></br>
    /// <br>Update Note      :   �ȒP�⍇���A�J�E���g�O���[�vID �ǉ�</br>
    /// <br>Programmer       :   22008 ���� ���n</br>
    /// <br>Date             :   2010/06/25 </br>
	/// <br></br>
	/// <br>Update Note      :   �ڋq�S���]�ƈ����� �ǉ�</br>
	/// <br>Programmer       :   22024 ���� �_�u</br>
	/// <br>Date             :   2012.04.10</br>
	/// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustomerSearchRetWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ�T�u�R�[�h</summary>
        private string _customerSubCode = "";

        /// <summary>����</summary>
        private string _name = "";

        /// <summary>���̂Q</summary>
        private string _name2 = "";

        /// <summary>�J�i</summary>
        private string _kana = "";

        /// <summary>�h��</summary>
        private string _honorificTitle = "";

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�d�b�ԍ��i�����p��4���j</summary>
        private string _searchTelNo = "";

        /// <summary>�d�b�ԍ��i����j</summary>
        /// <remarks>�n�C�t�����܂߂�16���̔ԍ�</remarks>
        private string _homeTelNo = "";

        /// <summary>�d�b�ԍ��i�Ζ���j</summary>
        private string _officeTelNo = "";

        /// <summary>�d�b�ԍ��i�g�сj</summary>
        private string _portableTelNo = "";

        /// <summary>�X�֔ԍ�</summary>
        private string _postNo = "";

        /// <summary>�Z���P�i�s���{���s��S�E�����E���j</summary>
        private string _address1 = "";

        /// <summary>�Z���R�i�Ԓn�j</summary>
        private string _address3 = "";

        /// <summary>�Z���S�i�A�p�[�g���́j</summary>
        private string _address4 = "";

        /// <summary>����</summary>
        /// <remarks>DD</remarks>
        private Int32 _totalDay;

        /// <summary>���Ӑ�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�d����敪</summary>
        /// <remarks>0:�d����ȊO,1:�d����</remarks>
        private Int32 _supplierDiv;

        /// <summary>�Ɣ̐�敪</summary>
        /// <remarks>0:�Ɣ̐�ȊO,1:�Ɣ̐�</remarks>
        private Int32 _acceptWholeSale;

        /// <summary>�Ǘ����_�R�[�h</summary>
        private string _mngSectionCode = "";

        // --- ADD 2008/09/05 ---------->>>>>
        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;
        // --- ADD 2008/09/05 ----------<<<<<

        // ADD 2009.02.10 >>>
        /// <summary>���Ӑ�`�[�ԍ��敪</summary>
        /// <remarks>0:�g�p���Ȃ�,1:�A��,2:����,3:����</remarks>
        private Int32 _customerSlipNoDiv;
        // ADD 2009.02.10 <<<

        // ADD 2009.06.09 >>>
        /// <summary>���Ӑ��ƃR�[�h</summary>
        /// <remarks>�V�X�e���A���\�ȏꍇ�̂ݓo�^�����</remarks>
        private string _customerEpCode = "";

        /// <summary>���Ӑ拒�_�R�[�h</summary>
        /// <remarks>�V�X�e���A���\�ȏꍇ�̂ݓo�^�����</remarks>
        private string _customerSecCode = "";
        // ADD 2009.06.09 <<<

        // ADD 2009.06.16 >>>
        /// <summary>�ڋq�S���]�ƈ��R�[�h</summary>
        /// <remarks>�����^</remarks>
        private string _customerAgentCd = "";
        // ADD 2009.06.16 <<<

////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
        /// <summary>�ڋq�S���]�ƈ�����</summary>
        /// <remarks>�����^</remarks>
        private string _customerAgentNm = "";
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

        // 2009/12/02 Add >>>
        /// <summary>FAX�ԍ��i�g�сj</summary>
        private string _homeFaxNo = "";

        /// <summary>FAX�ԍ��i�Ζ���j</summary>
        private string _officeFaxNo = "";
        // 2009/12/02 Add <<<

        // 2010/04/06 Add >>>
        /// <summary>�I�����C����ʋ敪</summary>
        /// <remarks>0:�Ȃ� 10:SCM�A20:TSP.NS�A30:TSP.NS�C�����C���A40:TSP���[��</remarks>
        private Int32 _onlineKindDiv;
        // 2010/04/06 Add <<<

        // 2010/06/25 Add >>>
        /// <summary>�ȒP�⍇���A�J�E���g�O���[�vID</summary>
        private string _simplInqAcntAcntGrId = "";
        // 2010/06/25 Add <<<
        

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

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerSubCode
        /// <summary>���Ӑ�T�u�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�T�u�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSubCode
        {
            get { return _customerSubCode; }
            set { _customerSubCode = value; }
        }

        /// public propaty name  :  Name
        /// <summary>���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// public propaty name  :  Name2
        /// <summary>���̂Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���̂Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Name2
        {
            get { return _name2; }
            set { _name2 = value; }
        }

        /// public propaty name  :  Kana
        /// <summary>�J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Kana
        {
            get { return _kana; }
            set { _kana = value; }
        }

        /// public propaty name  :  HonorificTitle
        /// <summary>�h�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HonorificTitle
        {
            get { return _honorificTitle; }
            set { _honorificTitle = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  SearchTelNo
        /// <summary>�d�b�ԍ��i�����p��4���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i�����p��4���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTelNo
        {
            get { return _searchTelNo; }
            set { _searchTelNo = value; }
        }

        /// public propaty name  :  HomeTelNo
        /// <summary>�d�b�ԍ��i����j�v���p�e�B</summary>
        /// <value>�n�C�t�����܂߂�16���̔ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HomeTelNo
        {
            get { return _homeTelNo; }
            set { _homeTelNo = value; }
        }

        /// public propaty name  :  OfficeTelNo
        /// <summary>�d�b�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfficeTelNo
        {
            get { return _officeTelNo; }
            set { _officeTelNo = value; }
        }

        /// public propaty name  :  PortableTelNo
        /// <summary>�d�b�ԍ��i�g�сj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i�g�сj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PortableTelNo
        {
            get { return _portableTelNo; }
            set { _portableTelNo = value; }
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
            get { return _postNo; }
            set { _postNo = value; }
        }

        /// public propaty name  :  Address1
        /// <summary>�Z���P�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z���P�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        /// public propaty name  :  Address3
        /// <summary>�Z���R�i�Ԓn�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z���R�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address3
        {
            get { return _address3; }
            set { _address3 = value; }
        }

        /// public propaty name  :  Address4
        /// <summary>�Z���S�i�A�p�[�g���́j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z���S�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address4
        {
            get { return _address4; }
            set { _address4 = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>�����v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>���Ӑ�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  SupplierDiv
        /// <summary>�d����敪�v���p�e�B</summary>
        /// <value>0:�d����ȊO,1:�d����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierDiv
        {
            get { return _supplierDiv; }
            set { _supplierDiv = value; }
        }

        /// public propaty name  :  AcceptWholeSale
        /// <summary>�Ɣ̐�敪�v���p�e�B</summary>
        /// <value>0:�Ɣ̐�ȊO,1:�Ɣ̐�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ɣ̐�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcceptWholeSale
        {
            get { return _acceptWholeSale; }
            set { _acceptWholeSale = value; }
        }

        /// public propaty name  :  MngSectionCode
        /// <summary>�Ǘ����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
        }

        // --- ADD 2008/09/05 ---------->>>>>
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
        // --- ADD 2008/09/05 ----------<<<<<

        // ADD 2009.02.10 >>>
        /// public propaty name  :  CustomerSlipNoDiv
        /// <summary>���Ӑ�`�[�ԍ��敪�v���p�e�B</summary>
        /// <value>0:�g�p���Ȃ�,1:�A��,2:����,3:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�`�[�ԍ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerSlipNoDiv
        {
            get { return _customerSlipNoDiv; }
            set { _customerSlipNoDiv = value; }
        }
        // ADD 2009.02.10 <<<

        /// public propaty name  :  CustomerEpCode
        /// <summary>���Ӑ��ƃR�[�h�v���p�e�B</summary>
        /// <value>�V�X�e���A���\�ȏꍇ�̂ݓo�^�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerEpCode
        {
            get { return _customerEpCode; }
            set { _customerEpCode = value; }
        }

        /// public propaty name  :  CustomerSecCode
        /// <summary>���Ӑ拒�_�R�[�h�v���p�e�B</summary>
        /// <value>�V�X�e���A���\�ȏꍇ�̂ݓo�^�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSecCode
        {
            get { return _customerSecCode; }
            set { _customerSecCode = value; }
        }

        /// public propaty name  :  CustomerAgentCd
        /// <summary>�ڋq�S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�����^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerAgentCd
        {
            get { return _customerAgentCd; }
            set { _customerAgentCd = value; }
        }

////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
        /// public propaty name  :  CustomerAgentNm
        /// <summary>�ڋq�S���]�ƈ����̃v���p�e�B</summary>
        /// <value>�����^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerAgentNm
        {
            get { return _customerAgentNm; }
            set { _customerAgentNm = value; }
        }
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

        // 2009/12/02 Add >>>
        /// public propaty name  :  HomeFaxNo
        /// <summary>FAX�ԍ��i����j�v���p�e�B</summary>
        /// <value>�n�C�t�����܂߂�16���̔ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX�ԍ��i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HomeFaxNo
        {
            get { return _homeFaxNo; }
            set { _homeFaxNo = value; }
        }

        /// public propaty name  :  OfficeFaxNo
        /// <summary>FAX�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfficeFaxNo
        {
            get { return _officeFaxNo; }
            set { _officeFaxNo = value; }
        }
         //2009/12/02 Add <<<

        // 2010/04/06 Add >>>
        /// public propaty name  :  OnlineKindDiv
        /// <summary>�I�����C����ʋ敪�v���p�e�B</summary>
        /// <value>0:�Ȃ� 10:SCM�A20:TSP.NS�A30:TSP.NS�C�����C���A40:TSP���[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����C����ʋ敪�v���p�e�B</br>
        /// <br>Programer        :   21024 ���X�� ��</br>
        /// </remarks>
        public Int32 OnlineKindDiv
        {
            get { return _onlineKindDiv; }
            set { _onlineKindDiv = value; }
        }
        // 2010/04/06 Add <<<

        //2010/06/25 Add >>>
        /// public propaty name  :  SimplInqAcntAcntGrId
        /// <summary>�ȒP�⍇���A�J�E���g�O���[�vID�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ȒP�⍇���A�J�E���g�O���[�vID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SimplInqAcntAcntGrId
        {
            get { return _simplInqAcntAcntGrId; }
            set { _simplInqAcntAcntGrId = value; }
        }
        //2009/06/25 Add <<<

        /// <summary>
        /// ���Ӑ挟�����ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CustomerSearchRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerSearchRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustomerSearchRetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CustomerSearchRetWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CustomerSearchRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class CustomerSearchRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerSearchRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CustomerSearchRetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CustomerSearchRetWork || graph is ArrayList || graph is CustomerSearchRetWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(CustomerSearchRetWork).FullName));

            if (graph != null && graph is CustomerSearchRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustomerSearchRetWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CustomerSearchRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustomerSearchRetWork[])graph).Length;
            }
            else if (graph is CustomerSearchRetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ�T�u�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSubCode
            //����
            serInfo.MemberInfo.Add(typeof(string)); //Name
            //���̂Q
            serInfo.MemberInfo.Add(typeof(string)); //Name2
            //�J�i
            serInfo.MemberInfo.Add(typeof(string)); //Kana
            //�h��
            serInfo.MemberInfo.Add(typeof(string)); //HonorificTitle
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //�d�b�ԍ��i�����p��4���j
            serInfo.MemberInfo.Add(typeof(string)); //SearchTelNo
            //�d�b�ԍ��i����j
            serInfo.MemberInfo.Add(typeof(string)); //HomeTelNo
            //�d�b�ԍ��i�Ζ���j
            serInfo.MemberInfo.Add(typeof(string)); //OfficeTelNo
            //�d�b�ԍ��i�g�сj
            serInfo.MemberInfo.Add(typeof(string)); //PortableTelNo
            //�X�֔ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PostNo
            //�Z���P�i�s���{���s��S�E�����E���j
            serInfo.MemberInfo.Add(typeof(string)); //Address1
            //�Z���R�i�Ԓn�j
            serInfo.MemberInfo.Add(typeof(string)); //Address3
            //�Z���S�i�A�p�[�g���́j
            serInfo.MemberInfo.Add(typeof(string)); //Address4
            //����
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalDay
            //���Ӑ�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //�d����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierDiv
            //�Ɣ̐�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptWholeSale
            //�Ǘ����_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //MngSectionCode
            // --- ADD 2008/09/05 ---------->>>>>
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            // --- ADD 2008/09/05 ----------<<<<<
            // ADD 2009.02.10 >>>
            //���Ӑ�`�[�ԍ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerSlipNoDiv
            // ADD 2009.02.10 <<<
            //���Ӑ��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CustomerEpCode
            //���Ӑ拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSecCode
            //�ڋq�S���]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgentCd
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
            //�ڋq�S���]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgentNm
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

            // 2009/12/02 Add >>>
            //FAX�ԍ��i����j
            serInfo.MemberInfo.Add(typeof(string)); //HomeFaxNo
            //FAX�ԍ��i�Ζ���j
            serInfo.MemberInfo.Add(typeof(string)); //OfficeFaxNo
            // 2009/12/02 Add <<<

            // 2010/04/06 Add >>>
            serInfo.MemberInfo.Add(typeof(Int32));  //OnlineKindDiv
            // 2010/04/05 Add <<<

            // 2010/06/25 Add >>>
            serInfo.MemberInfo.Add(typeof(string));  //SimplInqAcntAcntGrId
            // 2010/06/25 Add <<<

            serInfo.Serialize(writer, serInfo);
            if (graph is CustomerSearchRetWork)
            {
                CustomerSearchRetWork temp = (CustomerSearchRetWork)graph;

                SetCustomerSearchRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CustomerSearchRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CustomerSearchRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CustomerSearchRetWork temp in lst)
                {
                    SetCustomerSearchRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CustomerSearchRetWork�����o��(public�v���p�e�B��)
        /// </summary>
		#region 2012.04.10 TERASAKA DEL STA
//        // 2010/06/25 >>>
//        //// 2010/04/06 >>>
//        ////// 2009/12/02 >>>
//        //////private const int currentMemberCount = 26;
//        ////private const int currentMemberCount = 28;
//        ////// 2009/12/02 <<<
//
//        //private const int currentMemberCount = 29;
//        //// 2010/04/06 <<<
//
//        private const int currentMemberCount = 30;
//        // 2010/06/25 <<<
		#endregion
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
        private const int currentMemberCount = 31;
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
        
        /// <summary>
        ///  CustomerSearchRetWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerSearchRetWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetCustomerSearchRetWork(System.IO.BinaryWriter writer, CustomerSearchRetWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ�T�u�R�[�h
            writer.Write(temp.CustomerSubCode);
            //����
            writer.Write(temp.Name);
            //���̂Q
            writer.Write(temp.Name2);
            //�J�i
            writer.Write(temp.Kana);
            //�h��
            writer.Write(temp.HonorificTitle);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //�d�b�ԍ��i�����p��4���j
            writer.Write(temp.SearchTelNo);
            //�d�b�ԍ��i����j
            writer.Write(temp.HomeTelNo);
            //�d�b�ԍ��i�Ζ���j
            writer.Write(temp.OfficeTelNo);
            //�d�b�ԍ��i�g�сj
            writer.Write(temp.PortableTelNo);
            //�X�֔ԍ�
            writer.Write(temp.PostNo);
            //�Z���P�i�s���{���s��S�E�����E���j
            writer.Write(temp.Address1);
            //�Z���R�i�Ԓn�j
            writer.Write(temp.Address3);
            //�Z���S�i�A�p�[�g���́j
            writer.Write(temp.Address4);
            //����
            writer.Write(temp.TotalDay);
            //���Ӑ�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //�d����敪
            writer.Write(temp.SupplierDiv);
            //�Ɣ̐�敪
            writer.Write(temp.AcceptWholeSale);
            //�Ǘ����_�R�[�h
            writer.Write(temp.MngSectionCode);
            // --- ADD 2008/09/05 ---------->>>>>
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            // --- ADD 2008/09/05 ----------<<<<<
            // ADD 2009.02.10 >>>
            //���Ӑ�`�[�ԍ��敪
            writer.Write(temp.CustomerSlipNoDiv);
            // ADD 2009.02.10 <<<
            //���Ӑ��ƃR�[�h
            writer.Write(temp.CustomerEpCode);
            //���Ӑ拒�_�R�[�h
            writer.Write(temp.CustomerSecCode);
            //�ڋq�S���]�ƈ��R�[�h
            writer.Write(temp.CustomerAgentCd);
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
            //�ڋq�S���]�ƈ�����
            writer.Write(temp.CustomerAgentNm);
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

            // 2009/12/02 Add >>>
            //FAX�ԍ��i����j
            writer.Write(temp.HomeFaxNo);
            //FAX�ԍ��i�Ζ���j
            writer.Write(temp.OfficeFaxNo);
            // 2009/12/02 Add <<<

            // 2010/04/06 Add >>>
            //�I�����C����ʋ敪
            writer.Write(temp.OnlineKindDiv);
            // 2010/04/06 Add <<<
            // 2010/06/25 Add >>>
            //�ȒP�⍇���A�J�E���g�O���[�vID
            writer.Write(temp.SimplInqAcntAcntGrId);
            // 2010/06/25 Add <<<
        }

        /// <summary>
        ///  CustomerSearchRetWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CustomerSearchRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerSearchRetWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private CustomerSearchRetWork GetCustomerSearchRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            CustomerSearchRetWork temp = new CustomerSearchRetWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ�T�u�R�[�h
            temp.CustomerSubCode = reader.ReadString();
            //����
            temp.Name = reader.ReadString();
            //���̂Q
            temp.Name2 = reader.ReadString();
            //�J�i
            temp.Kana = reader.ReadString();
            //�h��
            temp.HonorificTitle = reader.ReadString();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //�d�b�ԍ��i�����p��4���j
            temp.SearchTelNo = reader.ReadString();
            //�d�b�ԍ��i����j
            temp.HomeTelNo = reader.ReadString();
            //�d�b�ԍ��i�Ζ���j
            temp.OfficeTelNo = reader.ReadString();
            //�d�b�ԍ��i�g�сj
            temp.PortableTelNo = reader.ReadString();
            //�X�֔ԍ�
            temp.PostNo = reader.ReadString();
            //�Z���P�i�s���{���s��S�E�����E���j
            temp.Address1 = reader.ReadString();
            //�Z���R�i�Ԓn�j
            temp.Address3 = reader.ReadString();
            //�Z���S�i�A�p�[�g���́j
            temp.Address4 = reader.ReadString();
            //����
            temp.TotalDay = reader.ReadInt32();
            //���Ӑ�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //�d����敪
            temp.SupplierDiv = reader.ReadInt32();
            //�Ɣ̐�敪
            temp.AcceptWholeSale = reader.ReadInt32();
            //�Ǘ����_�R�[�h
            temp.MngSectionCode = reader.ReadString();
            // --- ADD 2008/09/05 ---------->>>>>
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            // --- ADD 2008/09/05 ----------<<<<<
            // ADD 2009.02.10 >>>
            //���Ӑ�`�[�ԍ��敪
            temp.CustomerSlipNoDiv = reader.ReadInt32();
            // ADD 2009.02.10 <<<
            //���Ӑ��ƃR�[�h
            temp.CustomerEpCode = reader.ReadString();
            //���Ӑ拒�_�R�[�h
            temp.CustomerSecCode = reader.ReadString();
            //�ڋq�S���]�ƈ��R�[�h
            temp.CustomerAgentCd = reader.ReadString();
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
            //�ڋq�S���]�ƈ�����
            temp.CustomerAgentNm = reader.ReadString();
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

            // 2009/12/02 Add >>>
            //FAX�ԍ��i����j
            temp.HomeFaxNo = reader.ReadString();
            //FAX�ԍ��i�Ζ���j
            temp.OfficeFaxNo = reader.ReadString();
            // 2009/12/02 Add <<<

            // 2010/04/05 Add >>>
            // �I�����C����ʋ敪
            temp.OnlineKindDiv = reader.ReadInt32();
            // 2010/04/06 Add <<<
            // 2010/06/25 Add >>>
            // �ȒP�⍇���A�J�E���g�O���[�vID
            temp.SimplInqAcntAcntGrId = reader.ReadString();
            // 2010/06/26 Add <<<

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
        /// <returns>CustomerSearchRetWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerSearchRetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CustomerSearchRetWork temp = GetCustomerSearchRetWork(reader, serInfo);
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
                    retValue = (CustomerSearchRetWork[])lst.ToArray(typeof(CustomerSearchRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
