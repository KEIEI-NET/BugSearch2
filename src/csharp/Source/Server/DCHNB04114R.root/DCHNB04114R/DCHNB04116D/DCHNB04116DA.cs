using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalHisRefExtraParamWork
    /// <summary>
    ///                      ���㗚���Ɖ�o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���㗚���Ɖ�o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalHisRefExtraParamWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>����R�[�h</summary>
        private Int32 _subSectionCode;

        /// <summary>������R�[�h</summary>
        private Int32 _claimCode;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>������t(�J�n)</summary>
        private Int32 _salesDateSt;

        /// <summary>������t(�I��)</summary>
        private Int32 _salesDateEd;

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�:���w��</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>�i��</summary>
        private string _goodsNo = "";

        /// <summary>�i�Ԍ����^�C�v</summary>
        /// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
        private Int32 _goodsNoSrchTyp;

        /// <summary>����`�[�ԍ�(�J�n)</summary>
        private string _salesSlipNumSt = "";

        /// <summary>����`�[�ԍ�(�I��)</summary>
        private string _salesSlipNumEd = "";

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>���Ӑ撍���ԍ��i���`�ԍ��j</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>�i�������^�C�v</summary>
        /// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
        private Int32 _goodsNameSrchTyp;

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>��t�]�ƈ��R�[�h</summary>
        /// <remarks>��t�S���ҁi�󒍎ҁj</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>�̔��]�ƈ��R�[�h</summary>
        /// <remarks>�v��S���ҁi�S���ҁj</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>������͎҃R�[�h</summary>
        /// <remarks>���͒S���ҁi���s�ҁj</remarks>
        private string _salesInputCode = "";

        /// <summary>�`�[�������t(�J�n)</summary>
        private Int32 _searchSlipDateSt;

        /// <summary>�`�[�������t(�I��)</summary>
        private Int32 _searchSlipDateEd;

        /// <summary>����`�[�敪</summary>
        /// <remarks>0:����,1:�ԕi</remarks>
        private Int32 _salesSlipCd;

        /// <summary>���|�敪</summary>
        /// <remarks>0:���|�Ȃ�,1:���|</remarks>
        private Int32 _accRecDivCd;

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o�� ��15:�P������</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>�^���i�t���^�j</summary>
        /// <remarks>�t���^��(44���p)</remarks>
        private string _fullModel = "";

        /// <summary>�^�������^�C�v</summary>
        /// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
        private Int32 _fullModelSrchTyp;

        /// <summary>�v��c�敪</summary>
        /// <remarks>0:�S��,1:�c����,2:�v��ς� ���ρA�ݏo�̏ꍇ�̂ݎg�p</remarks>
        private Int32 _addUpRemDiv;

        //---ADD 2011/11/11 ------------------------->>>>>
        /// <summary>�󔭒����</summary>
        /// <remarks>0:PCCforNS�@,1:BL�߰µ��ް</remarks>
        private Int16 _acceptOrOrderKind;

        /// <summary>�����񓚎��</summary>
        /// <remarks>0:�ʏ�@,1:�蓮�񓚁@,2:������</remarks>
        private Int32 _autoAnswerDivSCM;

        //---ADD 2011/11/11 -------------------------<<<<<
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

        /// public propaty name  :  SubSectionCode
        /// <summary>����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
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

        /// public propaty name  :  SalesDateSt
        /// <summary>������t(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesDateSt
        {
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
        }

        /// public propaty name  :  SalesDateEd
        /// <summary>������t(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesDateEd
        {
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�:���w��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsNoSrchTyp
        /// <summary>�i�Ԍ����^�C�v�v���p�e�B</summary>
        /// <value>0:���S��v,1:�O����v����,2:�����v����,3:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�Ԍ����^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNoSrchTyp
        {
            get { return _goodsNoSrchTyp; }
            set { _goodsNoSrchTyp = value; }
        }

        /// public propaty name  :  SalesSlipNumSt
        /// <summary>����`�[�ԍ�(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ�(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipNumSt
        {
            get { return _salesSlipNumSt; }
            set { _salesSlipNumSt = value; }
        }

        /// public propaty name  :  SalesSlipNumEd
        /// <summary>����`�[�ԍ�(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ�(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipNumEd
        {
            get { return _salesSlipNumEd; }
            set { _salesSlipNumEd = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// <value>���Ӑ撍���ԍ��i���`�ԍ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  GoodsNameSrchTyp
        /// <summary>�i�������^�C�v�v���p�e�B</summary>
        /// <value>0:���S��v,1:�O����v����,2:�����v����,3:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�������^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNameSrchTyp
        {
            get { return _goodsNameSrchTyp; }
            set { _goodsNameSrchTyp = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>��t�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>��t�S���ҁi�󒍎ҁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>�̔��]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�v��S���ҁi�S���ҁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>������͎҃R�[�h�v���p�e�B</summary>
        /// <value>���͒S���ҁi���s�ҁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }

        /// public propaty name  :  SearchSlipDateSt
        /// <summary>�`�[�������t(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchSlipDateSt
        {
            get { return _searchSlipDateSt; }
            set { _searchSlipDateSt = value; }
        }

        /// public propaty name  :  SearchSlipDateEd
        /// <summary>�`�[�������t(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�������t(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchSlipDateEd
        {
            get { return _searchSlipDateEd; }
            set { _searchSlipDateEd = value; }
        }

        /// public propaty name  :  SalesSlipCd
        /// <summary>����`�[�敪�v���p�e�B</summary>
        /// <value>0:����,1:�ԕi</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }

        /// public propaty name  :  AccRecDivCd
        /// <summary>���|�敪�v���p�e�B</summary>
        /// <value>0:���|�Ȃ�,1:���|</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AccRecDivCd
        {
            get { return _accRecDivCd; }
            set { _accRecDivCd = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o�� ��15:�P������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>�^���i�t���^�j�v���p�e�B</summary>
        /// <value>�t���^��(44���p)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���i�t���^�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  FullModelSrchTyp
        /// <summary>�^�������^�C�v�v���p�e�B</summary>
        /// <value>0:���S��v,1:�O����v����,2:�����v����,3:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�������^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FullModelSrchTyp
        {
            get { return _fullModelSrchTyp; }
            set { _fullModelSrchTyp = value; }
        }

        /// public propaty name  :  AddUpRemDiv
        /// <summary>�v��c�敪�v���p�e�B</summary>
        /// <value>0:�S��,1:�c����,2:�v��ς� ���ρA�ݏo�̏ꍇ�̂ݎg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��c�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddUpRemDiv
        {
            get { return _addUpRemDiv; }
            set { _addUpRemDiv = value; }
        }



        //---ADD 2011/11/11 ----------------------->>>>>

        /// public propaty name  :  AcceptOrOrderKindRF
        /// <summary>�󔭒���ʃv���p�e�B</summary>
        /// <value>0:PCCforNS�@,1:BL�߰µ��ް</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󔭒���ʃv���p�e�B</br>
        /// <br>Programer        :   ���N�n��</br>
        /// </remarks>
        public Int16 AcceptOrOrderKind
        {
            get { return _acceptOrOrderKind; }
            set { _acceptOrOrderKind = value; }
        }


        /// public propaty name  :  AutoAnswerDivSCM
        /// <summary>�����񓚎�ʃv���p�e�B</summary>
        /// <value>0:�ʏ�@,1:�蓮�񓚁@,2:������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����񓚎�ʃv���p�e�B</br>
        /// <br>Programer        :   ���N�n��</br>
        /// </remarks>
        public Int32 AutoAnswerDivSCM
        {
            get { return _autoAnswerDivSCM; }
            set { _autoAnswerDivSCM = value; }
        }

        //---ADD 2011/11/11 -----------------------<<<<<


        /// <summary>
        /// ���㗚���Ɖ�o�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalHisRefExtraParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalHisRefExtraParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalHisRefExtraParamWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SalHisRefExtraParamWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SalHisRefExtraParamWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// <br>Update Note      :   2011/11/11 ���N�n�� BL�߰µ��ް�݌Ɋm�F���̌��ϓ`�[�Ή�</br>
    /// </remarks>
    public class SalHisRefExtraParamWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalHisRefExtraParamWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalHisRefExtraParamWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalHisRefExtraParamWork || graph is ArrayList || graph is SalHisRefExtraParamWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SalHisRefExtraParamWork).FullName));

            if (graph != null && graph is SalHisRefExtraParamWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalHisRefExtraParamWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalHisRefExtraParamWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalHisRefExtraParamWork[])graph).Length;
            }
            else if (graph is SalHisRefExtraParamWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //������t(�J�n)
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDateSt
            //������t(�I��)
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDateEd
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //�i��
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //�i�Ԍ����^�C�v
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsNoSrchTyp
            //����`�[�ԍ�(�J�n)
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNumSt
            //����`�[�ԍ�(�I��)
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNumEd
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PartySaleSlipNum
            //�i�������^�C�v
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsNameSrchTyp
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //��t�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeCd
            //�̔��]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeCd
            //������͎҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputCode
            //�`�[�������t(�J�n)
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchSlipDateSt
            //�`�[�������t(�I��)
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchSlipDateEd
            //����`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCd
            //���|�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AccRecDivCd
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //�^���i�t���^�j
            serInfo.MemberInfo.Add(typeof(string)); //FullModel
            //�^�������^�C�v
            serInfo.MemberInfo.Add(typeof(Int32)); //FullModelSrchTyp
            //�v��c�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpRemDiv

            //---ADD 2011/11/11 ---------------------->>>>>
            //�󔭒����
            serInfo.MemberInfo.Add(typeof(Int16)); //AcceptOrOrderKind
            //�����񓚎��
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoAnswerDivSCM
            //---ADD 2011/11/11 ----------------------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SalHisRefExtraParamWork)
            {
                SalHisRefExtraParamWork temp = (SalHisRefExtraParamWork)graph;

                SetSalHisRefExtraParamWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalHisRefExtraParamWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalHisRefExtraParamWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalHisRefExtraParamWork temp in lst)
                {
                    SetSalHisRefExtraParamWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalHisRefExtraParamWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 26; // DEL 2011/11/11

        private const int currentMemberCount = 28; // ADD 2011/11/11
        /// <summary>
        ///  SalHisRefExtraParamWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalHisRefExtraParamWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2011/11/11 ���N�n�� BL�߰µ��ް�݌Ɋm�F���̌��ϓ`�[�Ή�</br>
        /// </remarks>
        private void SetSalHisRefExtraParamWork(System.IO.BinaryWriter writer, SalHisRefExtraParamWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //����R�[�h
            writer.Write(temp.SubSectionCode);
            //������R�[�h
            writer.Write(temp.ClaimCode);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //������t(�J�n)
            writer.Write(temp.SalesDateSt);
            //������t(�I��)
            writer.Write(temp.SalesDateEd);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //�i��
            writer.Write(temp.GoodsNo);
            //�i�Ԍ����^�C�v
            writer.Write(temp.GoodsNoSrchTyp);
            //����`�[�ԍ�(�J�n)
            writer.Write(temp.SalesSlipNumSt);
            //����`�[�ԍ�(�I��)
            writer.Write(temp.SalesSlipNumEd);
            //�����`�[�ԍ�
            writer.Write(temp.PartySaleSlipNum);
            //�i�������^�C�v
            writer.Write(temp.GoodsNameSrchTyp);
            //���i����
            writer.Write(temp.GoodsName);
            //��t�]�ƈ��R�[�h
            writer.Write(temp.FrontEmployeeCd);
            //�̔��]�ƈ��R�[�h
            writer.Write(temp.SalesEmployeeCd);
            //������͎҃R�[�h
            writer.Write(temp.SalesInputCode);
            //�`�[�������t(�J�n)
            writer.Write(temp.SearchSlipDateSt);
            //�`�[�������t(�I��)
            writer.Write(temp.SearchSlipDateEd);
            //����`�[�敪
            writer.Write(temp.SalesSlipCd);
            //���|�敪
            writer.Write(temp.AccRecDivCd);
            //�󒍃X�e�[�^�X
            writer.Write(temp.AcptAnOdrStatus);
            //�^���i�t���^�j
            writer.Write(temp.FullModel);
            //�^�������^�C�v
            writer.Write(temp.FullModelSrchTyp);
            //�v��c�敪
            writer.Write(temp.AddUpRemDiv);
            //---ADD 2011/11/11 ------->>>>>
            //�󔭒����
            writer.Write(temp.AcceptOrOrderKind);
            //�����񓚎��
            writer.Write(temp.AutoAnswerDivSCM);
            //---ADD 2011/11/11 -------<<<<<

        }

        /// <summary>
        ///  SalHisRefExtraParamWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SalHisRefExtraParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalHisRefExtraParamWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2011/11/11 ���N�n�� BL�߰µ��ް�݌Ɋm�F���̌��ϓ`�[�Ή�</br>
        /// </remarks>
        private SalHisRefExtraParamWork GetSalHisRefExtraParamWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SalHisRefExtraParamWork temp = new SalHisRefExtraParamWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //����R�[�h
            temp.SubSectionCode = reader.ReadInt32();
            //������R�[�h
            temp.ClaimCode = reader.ReadInt32();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //������t(�J�n)
            temp.SalesDateSt = reader.ReadInt32();
            //������t(�I��)
            temp.SalesDateEd = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //�i��
            temp.GoodsNo = reader.ReadString();
            //�i�Ԍ����^�C�v
            temp.GoodsNoSrchTyp = reader.ReadInt32();
            //����`�[�ԍ�(�J�n)
            temp.SalesSlipNumSt = reader.ReadString();
            //����`�[�ԍ�(�I��)
            temp.SalesSlipNumEd = reader.ReadString();
            //�����`�[�ԍ�
            temp.PartySaleSlipNum = reader.ReadString();
            //�i�������^�C�v
            temp.GoodsNameSrchTyp = reader.ReadInt32();
            //���i����
            temp.GoodsName = reader.ReadString();
            //��t�]�ƈ��R�[�h
            temp.FrontEmployeeCd = reader.ReadString();
            //�̔��]�ƈ��R�[�h
            temp.SalesEmployeeCd = reader.ReadString();
            //������͎҃R�[�h
            temp.SalesInputCode = reader.ReadString();
            //�`�[�������t(�J�n)
            temp.SearchSlipDateSt = reader.ReadInt32();
            //�`�[�������t(�I��)
            temp.SearchSlipDateEd = reader.ReadInt32();
            //����`�[�敪
            temp.SalesSlipCd = reader.ReadInt32();
            //���|�敪
            temp.AccRecDivCd = reader.ReadInt32();
            //�󒍃X�e�[�^�X
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //�^���i�t���^�j
            temp.FullModel = reader.ReadString();
            //�^�������^�C�v
            temp.FullModelSrchTyp = reader.ReadInt32();
            //�v��c�敪
            temp.AddUpRemDiv = reader.ReadInt32();


            //---ADD 2011/11/11 ----------->>>>>
            //�󔭒����
            temp.AcceptOrOrderKind = reader.ReadInt16();
            //�����񓚎��
            temp.AutoAnswerDivSCM = reader.ReadInt32();
            //---ADD 2011/11/11 -----------<<<<<

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
        /// <returns>SalHisRefExtraParamWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalHisRefExtraParamWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalHisRefExtraParamWork temp = GetSalHisRefExtraParamWork(reader, serInfo);
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
                    retValue = (SalHisRefExtraParamWork[])lst.ToArray(typeof(SalHisRefExtraParamWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
