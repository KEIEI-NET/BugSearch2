using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustomerSearchParaWork
    /// <summary>
    ///                      ���Ӑ挟�������p�����[�^�N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ挟�������p�����[�^�N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/01/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   MANTIS:14720 ���Ӑ於�����ǉ�</br>
    /// <br>Programmer       :   30517 �Ė� �x��</br>
    /// <br>Date             :   2009/12/02</br>
    /// <br>Update Note      :   �d�b�ԍ������ǉ��Ɣ����C��</br>
    /// <br>Programmer       :   PM1012A �� ��</br>
    /// <br>Date             :   2010/08/06</br>
     /// <br>Update Note     :   ���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
    /// <br>Programmer       :   PM1107C ���юR</br>
    /// <br>Date             :   2011/07/22</br>
    /// <br>Update Note      : PCC���Зp���Ӑ�K�C�h�ǉ�</br>
    /// <br>Programmer       : ���C��</br>
    /// <br>Date             : 2011/08/19</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustomerSearchParaWork 
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ�T�u�R�[�h</summary>
        private string _customerSubCode = "";

        /// <summary>�J�i</summary>
        private string _kana = "";

        /// <summary>�d�b�ԍ��i�����p��4���j</summary>
        private string _searchTelNo = "";

        /// <summary>�Ɣ̐�敪</summary>
        /// <remarks>0:�Ɣ̐�ȊO,1:�Ɣ̐�</remarks>
        private Int32 _acceptWholeSale;

        /// <summary>���Ӑ�T�u�R�[�h�����^�C�v</summary>
        /// <remarks>0:�O����v����,1:�B������</remarks>
        private Int32 _customerSubCodeSearchType;

        /// <summary>���Ӑ�J�i�����^�C�v</summary>
        /// <remarks>0:�O����v����,1:�B������</remarks>
        private Int32 _kanaSearchType;

        /// <summary>���Ӑ敪�̓R�[�h�P</summary>
        private Int32 _custAnalysCode1;

        /// <summary>���Ӑ敪�̓R�[�h�Q</summary>
        private Int32 _custAnalysCode2;

        /// <summary>���Ӑ敪�̓R�[�h�R</summary>
        private Int32 _custAnalysCode3;

        /// <summary>���Ӑ敪�̓R�[�h�S</summary>
        private Int32 _custAnalysCode4;

        /// <summary>���Ӑ敪�̓R�[�h�T</summary>
        private Int32 _custAnalysCode5;

        /// <summary>���Ӑ敪�̓R�[�h�U</summary>
        private Int32 _custAnalysCode6;

        /// <summary>�ڋq�S���]�ƈ��R�[�h</summary>
        /// <remarks>�����^</remarks>
        private string _customerAgentCd = "";

        /// <summary>�W���S���]�ƈ��R�[�h</summary>
        private string _billCollecterCd = "";

        /// <summary>�Ǘ����_�R�[�h</summary>
        private string _mngSectionCode = "";

        // 2009/12/02 Add >>>
        /// <summary>���Ӑ於</summary>
        private string _name = "";

        /// <summary>���Ӑ於�����^�C�v</summary>
        /// <remarks>0:�O����v����,1:�B������</remarks>
        private Int32 _nameSearchType;
        // 2009/12/02 Add <<<

        // ---ADD 2010/08/06-------------------->>>
        /// <summary>�d�b�ԍ�</summary>
        private string _telNum = "";

        /// <summary>�d�b�ԍ������^�C�v</summary>
        /// <remarks>0:�O����v����,1:�B������</remarks>
        private Int32 _telNumSearchType;
        // ---ADD 2010/08/06--------------------<<<
        
        // 2011/7/22 XUJS ADD STA>>>>>>
        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>���Ӑ旪�̌����^�C�v</summary>
        /// <remarks>0:�O����v����,1:�B������</remarks>
        private Int32 _customerSnmSearchType;
        // 2011/7/22 XUJS ADD END<<<<<<

        //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
        private Int32 _pccuoeMode;
        //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<

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

        /// public propaty name  :  CustomerSubCodeSearchType
        /// <summary>���Ӑ�T�u�R�[�h�����^�C�v�v���p�e�B</summary>
        /// <value>0:�O����v����,1:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�T�u�R�[�h�����^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerSubCodeSearchType
        {
            get { return _customerSubCodeSearchType; }
            set { _customerSubCodeSearchType = value; }
        }

        /// public propaty name  :  KanaSearchType
        /// <summary>���Ӑ�J�i�����^�C�v�v���p�e�B</summary>
        /// <value>0:�O����v����,1:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�J�i�����^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 KanaSearchType
        {
            get { return _kanaSearchType; }
            set { _kanaSearchType = value; }
        }

        /// public propaty name  :  CustAnalysCode1
        /// <summary>���Ӑ敪�̓R�[�h�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode1
        {
            get { return _custAnalysCode1; }
            set { _custAnalysCode1 = value; }
        }

        /// public propaty name  :  CustAnalysCode2
        /// <summary>���Ӑ敪�̓R�[�h�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode2
        {
            get { return _custAnalysCode2; }
            set { _custAnalysCode2 = value; }
        }

        /// public propaty name  :  CustAnalysCode3
        /// <summary>���Ӑ敪�̓R�[�h�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode3
        {
            get { return _custAnalysCode3; }
            set { _custAnalysCode3 = value; }
        }

        /// public propaty name  :  CustAnalysCode4
        /// <summary>���Ӑ敪�̓R�[�h�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode4
        {
            get { return _custAnalysCode4; }
            set { _custAnalysCode4 = value; }
        }

        /// public propaty name  :  CustAnalysCode5
        /// <summary>���Ӑ敪�̓R�[�h�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode5
        {
            get { return _custAnalysCode5; }
            set { _custAnalysCode5 = value; }
        }

        /// public propaty name  :  CustAnalysCode6
        /// <summary>���Ӑ敪�̓R�[�h�U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ敪�̓R�[�h�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustAnalysCode6
        {
            get { return _custAnalysCode6; }
            set { _custAnalysCode6 = value; }
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

        /// public propaty name  :  BillCollecterCd
        /// <summary>�W���S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W���S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BillCollecterCd
        {
            get { return _billCollecterCd; }
            set { _billCollecterCd = value; }
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

        // 2009/12/02 Add >>>
        /// public propaty name  :  Name
        /// <summary>���Ӑ於�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// public propaty name  :  KanaSearchType
        /// <summary>���Ӑ於�����^�C�v�v���p�e�B</summary>
        /// <value>0:�O����v����,1:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�����^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NameSearchType
        {
            get { return _nameSearchType; }
            set { _nameSearchType = value; }
        }
        // 2009/12/02 Add <<<

        // ---ADD 2010/08/06-------------------->>>
        /// public propaty name  :  TelNum
        /// <summary>�d�b�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TelNum
        {
            get { return _telNum; }
            set { _telNum = value; }
        }

        /// public propaty name  :  TelNumSearchType
        /// <summary>�d�b�ԍ������^�C�v�v���p�e�B</summary>
        /// <value>0:�O����v����,1:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ������^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TelNumSearchType
        {
            get { return _telNumSearchType; }
            set { _telNumSearchType = value; }
        }
        // ---ADD 2010/08/06--------------------<<<
        //1/7/22 XUJS ADD STA>>>>>>
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

        /// public propaty name  :  CustomerSnmSearchType
        /// <summary>���Ӑ旪�̌����^�C�v�v���p�e�B</summary>
        /// <value>0:�O����v����,1:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̌����^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerSnmSearchType
        {
            get { return _customerSnmSearchType; }
            set { _customerSnmSearchType = value; }
        }
        // 2011/7/22 XUJS ADD END<<<<<<

        //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
        /// public propaty name  :  PccuoeMode
        /// <summary>PCC���Зp�^�C�v���p�e�B</summary>
        /// <value>0:�ʏ�,1:PCC���Зp,2:PCC�}�X�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ������^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PccuoeMode
        {
            get { return _pccuoeMode; }
            set { _pccuoeMode = value; }
        }
        //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<

        /// <summary>
        /// ���Ӑ挟�������p�����[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CustomerSearchParaWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerSearchParaWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustomerSearchParaWork()
        {
        }
    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CustomerSearchParaWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CustomerSearchParaWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class CustomerSearchParaWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerSearchParaWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   ���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>Programmer       :   PM1107C ���юR</br>
        /// <br>Date             :   2011/07/22</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CustomerSearchParaWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CustomerSearchParaWork || graph is ArrayList || graph is CustomerSearchParaWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(CustomerSearchParaWork).FullName));

            if (graph != null && graph is CustomerSearchParaWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustomerSearchParaWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CustomerSearchParaWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustomerSearchParaWork[])graph).Length;
            }
            else if (graph is CustomerSearchParaWork)
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
            //�J�i
            serInfo.MemberInfo.Add(typeof(string)); //Kana
            //�d�b�ԍ��i�����p��4���j
            serInfo.MemberInfo.Add(typeof(string)); //SearchTelNo
            //�Ɣ̐�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptWholeSale
            //���Ӑ�T�u�R�[�h�����^�C�v
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerSubCodeSearchType
            //���Ӑ�J�i�����^�C�v
            serInfo.MemberInfo.Add(typeof(Int32)); //KanaSearchType
            //���Ӑ敪�̓R�[�h�P
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode1
            //���Ӑ敪�̓R�[�h�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode2
            //���Ӑ敪�̓R�[�h�R
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode3
            //���Ӑ敪�̓R�[�h�S
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode4
            //���Ӑ敪�̓R�[�h�T
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode5
            //���Ӑ敪�̓R�[�h�U
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode6
            //�ڋq�S���]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgentCd
            //�W���S���]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BillCollecterCd
            //�Ǘ����_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //MngSectionCode
            // 2009/12/02 Add >>>
            //���Ӑ於
            serInfo.MemberInfo.Add(typeof(string)); //Name
            // 2009/12/02 Add <<<

            // ---ADD 2010/08/06-------------------->>>
            //�d�b�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //TelNum
            // ---ADD 2010/08/06--------------------<<<
            
            // 2011/7/22 XUJS ADD STA>>>>>>
            serInfo.MemberInfo.Add(typeof(string)); //SNM
            // 2011/7/22 XUJS ADD END<<<<<<
            //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
            //PCC���Зp�^�C�v
            serInfo.MemberInfo.Add(typeof(Int32)); //PccuoeMode
            //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is CustomerSearchParaWork)
            {
                CustomerSearchParaWork temp = (CustomerSearchParaWork)graph;

                SetCustomerSearchParaWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CustomerSearchParaWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CustomerSearchParaWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CustomerSearchParaWork temp in lst)
                {
                    SetCustomerSearchParaWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CustomerSearchParaWork�����o��(public�v���p�e�B��)
        /// </summary>
        // 2009/12/02 >>>
        //private const int currentMemberCount = 17;
        // ---UPD 2010/08/06-------------------->>>
        //private const int currentMemberCount = 18;
        // 2011/7/22 XUJS EDIT STA>>>>>>
        //private const int currentMemberCount = 19;
       // private const int currentMemberCount = 20;
        // 2011/7/22 XUJS EDIT END<<<<<<
        // ---UPD 2010/08/06--------------------<<<
        //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
        private const int currentMemberCount = 21;
        //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<
        // 2009/12/02 <<<

        /// <summary>
        ///  CustomerSearchParaWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerSearchParaWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   ���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>Programmer       :   PM1107C ���юR</br>
        /// <br>Date             :   2011/07/22</br>
        /// </remarks>
        private void SetCustomerSearchParaWork(System.IO.BinaryWriter writer, CustomerSearchParaWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ�T�u�R�[�h
            writer.Write(temp.CustomerSubCode);
            //�J�i
            writer.Write(temp.Kana);
            //�d�b�ԍ��i�����p��4���j
            writer.Write(temp.SearchTelNo);
            //�Ɣ̐�敪
            writer.Write(temp.AcceptWholeSale);
            //���Ӑ�T�u�R�[�h�����^�C�v
            writer.Write(temp.CustomerSubCodeSearchType);
            //���Ӑ�J�i�����^�C�v
            writer.Write(temp.KanaSearchType);
            //���Ӑ敪�̓R�[�h�P
            writer.Write(temp.CustAnalysCode1);
            //���Ӑ敪�̓R�[�h�Q
            writer.Write(temp.CustAnalysCode2);
            //���Ӑ敪�̓R�[�h�R
            writer.Write(temp.CustAnalysCode3);
            //���Ӑ敪�̓R�[�h�S
            writer.Write(temp.CustAnalysCode4);
            //���Ӑ敪�̓R�[�h�T
            writer.Write(temp.CustAnalysCode5);
            //���Ӑ敪�̓R�[�h�U
            writer.Write(temp.CustAnalysCode6);
            //�ڋq�S���]�ƈ��R�[�h
            writer.Write(temp.CustomerAgentCd);
            //�W���S���]�ƈ��R�[�h
            writer.Write(temp.BillCollecterCd);
            //�Ǘ����_�R�[�h
            writer.Write(temp.MngSectionCode);
            // 2009/12/02 Add >>>
            //���Ӑ於
            writer.Write(temp.Name);
            // 2009/12/02 Add <<<
            // ---ADD 2010/08/06-------------------->>>
            //�d�b�ԍ�
            writer.Write(temp.TelNum);
            // ---ADD 2010/08/06--------------------<<<
      
            // 2011/7/22 XUJS ADD STA>>>>>>
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            // 2011/7/22 XUJS ADD END<<<<<<
            //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
            //PCC���Зp�^�C�v
            writer.Write(temp.PccuoeMode);
            //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<
        }

        /// <summary>
        ///  CustomerSearchParaWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CustomerSearchParaWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerSearchParaWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   ���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>Programmer       :   PM1107C ���юR</br>
        /// <br>Date             :   2011/07/22</br>
        /// </remarks>
        private CustomerSearchParaWork GetCustomerSearchParaWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            CustomerSearchParaWork temp = new CustomerSearchParaWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ�T�u�R�[�h
            temp.CustomerSubCode = reader.ReadString();
            //�J�i
            temp.Kana = reader.ReadString();
            //�d�b�ԍ��i�����p��4���j
            temp.SearchTelNo = reader.ReadString();
            //�Ɣ̐�敪
            temp.AcceptWholeSale = reader.ReadInt32();
            //���Ӑ�T�u�R�[�h�����^�C�v
            temp.CustomerSubCodeSearchType = reader.ReadInt32();
            //���Ӑ�J�i�����^�C�v
            temp.KanaSearchType = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h�P
            temp.CustAnalysCode1 = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h�Q
            temp.CustAnalysCode2 = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h�R
            temp.CustAnalysCode3 = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h�S
            temp.CustAnalysCode4 = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h�T
            temp.CustAnalysCode5 = reader.ReadInt32();
            //���Ӑ敪�̓R�[�h�U
            temp.CustAnalysCode6 = reader.ReadInt32();
            //�ڋq�S���]�ƈ��R�[�h
            temp.CustomerAgentCd = reader.ReadString();
            //�W���S���]�ƈ��R�[�h
            temp.BillCollecterCd = reader.ReadString();
            //�Ǘ����_�R�[�h
            temp.MngSectionCode = reader.ReadString();
            // 2009/12/02 Add >>>
            //���Ӑ於
            temp.Name = reader.ReadString();
            // 2009/12/02 Add <<<
            // ---ADD 2010/08/06-------------------->>>
            //�d�b�ԍ�
            temp.TelNum = reader.ReadString();
            // ---ADD 2010/08/06--------------------<<<
            
            // 2011/7/22 XUJS ADD STA>>>>>>
            temp.CustomerSnm = reader.ReadString();
            // 2011/7/22 XUJS ADD END<<<<<<
            //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>> 
            //PCC���Зp�^�C�v
            temp.PccuoeMode = reader.ReadInt32();
            //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<

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
        /// <returns>CustomerSearchParaWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerSearchParaWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CustomerSearchParaWork temp = GetCustomerSearchParaWork(reader, serInfo);
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
                    retValue = (CustomerSearchParaWork[])lst.ToArray(typeof(CustomerSearchParaWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
