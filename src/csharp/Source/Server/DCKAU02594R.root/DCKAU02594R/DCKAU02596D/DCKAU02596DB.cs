using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RsltInfo_DemandBalanceWork
    /// <summary>
    ///                      �����c���������o���ʃ��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����c���������o���ʃ��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RsltInfo_DemandBalanceWork
    {
        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>�v�㋒�_����</summary>
        /// <remarks>�����[�g���ŎZ�o</remarks>
        private string _addUpSecName = "";

        /// <summary>������R�[�h</summary>
        /// <remarks>������e�R�[�h</remarks>
        private Int32 _claimCode;

        /// <summary>�����於��</summary>
        private string _claimName = "";

        /// <summary>�����於��2</summary>
        private string _claimName2 = "";

        /// <summary>�����旪��</summary>
        private string _claimSnm = "";

        /// <summary>�v��N����</summary>
        /// <remarks>YYYYMMDD ���������s�Ȃ������i������j</remarks>
        private DateTime _addUpDate;

        /// <summary>�O�񐿋����z</summary>
        private Int64 _lastTimeDemand;

        /// <summary>����������z�i�ʏ�����j</summary>
        /// <remarks>�����z�̍��v���z</remarks>
        private Int64 _thisTimeDmdNrml;

        /// <summary>����J�z�c���i�x���v�j</summary>
        /// <remarks>����J�z�c�����O�񐿋��z �{ �c�������z �[�@���񐿋��z�i�����v�j</remarks>
        private Int64 _thisTimeTtlBlcDmd;

        /// <summary>���E�㍡�񔄏���z</summary>
        /// <remarks>�|���F���񔄏���z�{���񔄏�ԕi���z�{���񔄏�l�����z</remarks>
        private Int64 _ofsThisTimeSales;

        /// <summary>���E�㍡�񔄏�����</summary>
        /// <remarks>�|���F����Ŋz���v</remarks>
        private Int64 _ofsThisSalesTax;

        /// <summary>���񔄏���z</summary>
        /// <remarks>�|���F�l���A�ԕi���܂܂Ȃ��Ŕ����̔�����z</remarks>
        private Int64 _thisTimeSales;

        /// <summary>���񔄏�����</summary>
        private Int64 _thisSalesTax;

        /// <summary>���񔄏�ԕi���z</summary>
        /// <remarks>�|���F�l�����܂܂Ȃ��Ŕ����̔���ԕi���z</remarks>
        private Int64 _thisSalesPricRgds;

        /// <summary>���񔄏�l�����z</summary>
        /// <remarks>�|���F�Ŕ����̔���l�����z</remarks>
        private Int64 _thisSalesPricDis;

        /// <summary>�v�Z�㐿�����z</summary>
        /// <remarks>���񐿋����z</remarks>
        private Int64 _afCalDemandPrice;

        /// <summary>����`�[����</summary>
        private Int32 _salesSlipCount;

        /// <summary>��2��O�c���i�����v�j</summary>
        private Int64 _acpOdrTtl2TmBfBlDmd;

        /// <summary>��3��O�c���i�����v�j</summary>
        private Int64 _acpOdrTtl3TmBfBlDmd;

        /// <summary>�W���S���]�ƈ��R�[�h</summary>
        private string _billCollecterCd = "";

        /// <summary>�W���S���]�ƈ�����</summary>
        private string _billCollecterNm = "";

        /// <summary>�������</summary>
        private Int32 _collectCond;

        /// <summary>�W�����敪����</summary>
        /// <remarks>����,����,���X��</remarks>
        private string _collectMoneyName = "";

        /// <summary>����</summary>
        /// <remarks>DD</remarks>
        private Int32 _totalDay;

        /// <summary>�W����</summary>
        /// <remarks>DD</remarks>
        private Int32 _collectMoneyDay;


        /// public propaty name  :  AddUpSecCode
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  AddUpSecName
        /// <summary>�v�㋒�_���̃v���p�e�B</summary>
        /// <value>�����[�g���ŎZ�o</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecName
        {
            get { return _addUpSecName; }
            set { _addUpSecName = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// <value>������e�R�[�h</value>
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

        /// public propaty name  :  ClaimName
        /// <summary>�����於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimName
        {
            get { return _claimName; }
            set { _claimName = value; }
        }

        /// public propaty name  :  ClaimName2
        /// <summary>�����於��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimName2
        {
            get { return _claimName2; }
            set { _claimName2 = value; }
        }

        /// public propaty name  :  ClaimSnm
        /// <summary>�����旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimSnm
        {
            get { return _claimSnm; }
            set { _claimSnm = value; }
        }

        /// public propaty name  :  AddUpDate
        /// <summary>�v��N�����v���p�e�B</summary>
        /// <value>YYYYMMDD ���������s�Ȃ������i������j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpDate
        {
            get { return _addUpDate; }
            set { _addUpDate = value; }
        }

        /// public propaty name  :  LastTimeDemand
        /// <summary>�O�񐿋����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�񐿋����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 LastTimeDemand
        {
            get { return _lastTimeDemand; }
            set { _lastTimeDemand = value; }
        }

        /// public propaty name  :  ThisTimeDmdNrml
        /// <summary>����������z�i�ʏ�����j�v���p�e�B</summary>
        /// <value>�����z�̍��v���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����������z�i�ʏ�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeDmdNrml
        {
            get { return _thisTimeDmdNrml; }
            set { _thisTimeDmdNrml = value; }
        }

        /// public propaty name  :  ThisTimeTtlBlcDmd
        /// <summary>����J�z�c���i�x���v�j�v���p�e�B</summary>
        /// <value>����J�z�c�����O�񐿋��z �{ �c�������z �[�@���񐿋��z�i�����v�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����J�z�c���i�x���v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeTtlBlcDmd
        {
            get { return _thisTimeTtlBlcDmd; }
            set { _thisTimeTtlBlcDmd = value; }
        }

        /// public propaty name  :  OfsThisTimeSales
        /// <summary>���E�㍡�񔄏���z�v���p�e�B</summary>
        /// <value>�|���F���񔄏���z�{���񔄏�ԕi���z�{���񔄏�l�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E�㍡�񔄏���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OfsThisTimeSales
        {
            get { return _ofsThisTimeSales; }
            set { _ofsThisTimeSales = value; }
        }

        /// public propaty name  :  OfsThisSalesTax
        /// <summary>���E�㍡�񔄏����Ńv���p�e�B</summary>
        /// <value>�|���F����Ŋz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E�㍡�񔄏����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OfsThisSalesTax
        {
            get { return _ofsThisSalesTax; }
            set { _ofsThisSalesTax = value; }
        }

        /// public propaty name  :  ThisTimeSales
        /// <summary>���񔄏���z�v���p�e�B</summary>
        /// <value>�|���F�l���A�ԕi���܂܂Ȃ��Ŕ����̔�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeSales
        {
            get { return _thisTimeSales; }
            set { _thisTimeSales = value; }
        }

        /// public propaty name  :  ThisSalesTax
        /// <summary>���񔄏����Ńv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisSalesTax
        {
            get { return _thisSalesTax; }
            set { _thisSalesTax = value; }
        }

        /// public propaty name  :  ThisSalesPricRgds
        /// <summary>���񔄏�ԕi���z�v���p�e�B</summary>
        /// <value>�|���F�l�����܂܂Ȃ��Ŕ����̔���ԕi���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏�ԕi���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisSalesPricRgds
        {
            get { return _thisSalesPricRgds; }
            set { _thisSalesPricRgds = value; }
        }

        /// public propaty name  :  ThisSalesPricDis
        /// <summary>���񔄏�l�����z�v���p�e�B</summary>
        /// <value>�|���F�Ŕ����̔���l�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏�l�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisSalesPricDis
        {
            get { return _thisSalesPricDis; }
            set { _thisSalesPricDis = value; }
        }

        /// public propaty name  :  AfCalDemandPrice
        /// <summary>�v�Z�㐿�����z�v���p�e�B</summary>
        /// <value>���񐿋����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�Z�㐿�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AfCalDemandPrice
        {
            get { return _afCalDemandPrice; }
            set { _afCalDemandPrice = value; }
        }

        /// public propaty name  :  SalesSlipCount
        /// <summary>����`�[�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCount
        {
            get { return _salesSlipCount; }
            set { _salesSlipCount = value; }
        }

        /// public propaty name  :  AcpOdrTtl2TmBfBlDmd
        /// <summary>��2��O�c���i�����v�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��2��O�c���i�����v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AcpOdrTtl2TmBfBlDmd
        {
            get { return _acpOdrTtl2TmBfBlDmd; }
            set { _acpOdrTtl2TmBfBlDmd = value; }
        }

        /// public propaty name  :  AcpOdrTtl3TmBfBlDmd
        /// <summary>��3��O�c���i�����v�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��3��O�c���i�����v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AcpOdrTtl3TmBfBlDmd
        {
            get { return _acpOdrTtl3TmBfBlDmd; }
            set { _acpOdrTtl3TmBfBlDmd = value; }
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

        /// public propaty name  :  BillCollecterNm
        /// <summary>�W���S���]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W���S���]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BillCollecterNm
        {
            get { return _billCollecterNm; }
            set { _billCollecterNm = value; }
        }

        /// public propaty name  :  CollectCond
        /// <summary>��������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CollectCond
        {
            get { return _collectCond; }
            set { _collectCond = value; }
        }

        /// public propaty name  :  CollectMoneyName
        /// <summary>�W�����敪���̃v���p�e�B</summary>
        /// <value>����,����,���X��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CollectMoneyName
        {
            get { return _collectMoneyName; }
            set { _collectMoneyName = value; }
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

        /// public propaty name  :  CollectMoneyDay
        /// <summary>�W�����v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CollectMoneyDay
        {
            get { return _collectMoneyDay; }
            set { _collectMoneyDay = value; }
        }


        /// <summary>
        /// �����c���������o���ʃ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RsltInfo_DemandBalanceWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_DemandBalanceWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RsltInfo_DemandBalanceWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RsltInfo_DemandBalanceWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RsltInfo_DemandBalanceWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RsltInfo_DemandBalanceWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_DemandBalanceWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RsltInfo_DemandBalanceWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RsltInfo_DemandBalanceWork || graph is ArrayList || graph is RsltInfo_DemandBalanceWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RsltInfo_DemandBalanceWork).FullName));

            if (graph != null && graph is RsltInfo_DemandBalanceWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RsltInfo_DemandBalanceWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RsltInfo_DemandBalanceWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RsltInfo_DemandBalanceWork[])graph).Length;
            }
            else if (graph is RsltInfo_DemandBalanceWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //�v�㋒�_����
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecName
            //������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //�����於��
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName
            //�����於��2
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName2
            //�����旪��
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //�v��N����
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //�O�񐿋����z
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeDemand
            //����������z�i�ʏ�����j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDmdNrml
            //����J�z�c���i�x���v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlcDmd
            //���E�㍡�񔄏���z
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeSales
            //���E�㍡�񔄏�����
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisSalesTax
            //���񔄏���z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeSales
            //���񔄏�����
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesTax
            //���񔄏�ԕi���z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricRgds
            //���񔄏�l�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricDis
            //�v�Z�㐿�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //AfCalDemandPrice
            //����`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCount
            //��2��O�c���i�����v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl2TmBfBlDmd
            //��3��O�c���i�����v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl3TmBfBlDmd
            //�W���S���]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BillCollecterCd
            //�W���S���]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //BillCollecterNm
            //�������
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectCond
            //�W�����敪����
            serInfo.MemberInfo.Add(typeof(string)); //CollectMoneyName
            //����
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalDay
            //�W����
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectMoneyDay


            serInfo.Serialize(writer, serInfo);
            if (graph is RsltInfo_DemandBalanceWork)
            {
                RsltInfo_DemandBalanceWork temp = (RsltInfo_DemandBalanceWork)graph;

                SetRsltInfo_DemandBalanceWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RsltInfo_DemandBalanceWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RsltInfo_DemandBalanceWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RsltInfo_DemandBalanceWork temp in lst)
                {
                    SetRsltInfo_DemandBalanceWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RsltInfo_DemandBalanceWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 26;

        /// <summary>
        ///  RsltInfo_DemandBalanceWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_DemandBalanceWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRsltInfo_DemandBalanceWork(System.IO.BinaryWriter writer, RsltInfo_DemandBalanceWork temp)
        {
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //�v�㋒�_����
            writer.Write(temp.AddUpSecName);
            //������R�[�h
            writer.Write(temp.ClaimCode);
            //�����於��
            writer.Write(temp.ClaimName);
            //�����於��2
            writer.Write(temp.ClaimName2);
            //�����旪��
            writer.Write(temp.ClaimSnm);
            //�v��N����
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //�O�񐿋����z
            writer.Write(temp.LastTimeDemand);
            //����������z�i�ʏ�����j
            writer.Write(temp.ThisTimeDmdNrml);
            //����J�z�c���i�x���v�j
            writer.Write(temp.ThisTimeTtlBlcDmd);
            //���E�㍡�񔄏���z
            writer.Write(temp.OfsThisTimeSales);
            //���E�㍡�񔄏�����
            writer.Write(temp.OfsThisSalesTax);
            //���񔄏���z
            writer.Write(temp.ThisTimeSales);
            //���񔄏�����
            writer.Write(temp.ThisSalesTax);
            //���񔄏�ԕi���z
            writer.Write(temp.ThisSalesPricRgds);
            //���񔄏�l�����z
            writer.Write(temp.ThisSalesPricDis);
            //�v�Z�㐿�����z
            writer.Write(temp.AfCalDemandPrice);
            //����`�[����
            writer.Write(temp.SalesSlipCount);
            //��2��O�c���i�����v�j
            writer.Write(temp.AcpOdrTtl2TmBfBlDmd);
            //��3��O�c���i�����v�j
            writer.Write(temp.AcpOdrTtl3TmBfBlDmd);
            //�W���S���]�ƈ��R�[�h
            writer.Write(temp.BillCollecterCd);
            //�W���S���]�ƈ�����
            writer.Write(temp.BillCollecterNm);
            //�������
            writer.Write(temp.CollectCond);
            //�W�����敪����
            writer.Write(temp.CollectMoneyName);
            //����
            writer.Write(temp.TotalDay);
            //�W����
            writer.Write(temp.CollectMoneyDay);

        }

        /// <summary>
        ///  RsltInfo_DemandBalanceWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RsltInfo_DemandBalanceWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_DemandBalanceWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RsltInfo_DemandBalanceWork GetRsltInfo_DemandBalanceWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RsltInfo_DemandBalanceWork temp = new RsltInfo_DemandBalanceWork();

            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //�v�㋒�_����
            temp.AddUpSecName = reader.ReadString();
            //������R�[�h
            temp.ClaimCode = reader.ReadInt32();
            //�����於��
            temp.ClaimName = reader.ReadString();
            //�����於��2
            temp.ClaimName2 = reader.ReadString();
            //�����旪��
            temp.ClaimSnm = reader.ReadString();
            //�v��N����
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //�O�񐿋����z
            temp.LastTimeDemand = reader.ReadInt64();
            //����������z�i�ʏ�����j
            temp.ThisTimeDmdNrml = reader.ReadInt64();
            //����J�z�c���i�x���v�j
            temp.ThisTimeTtlBlcDmd = reader.ReadInt64();
            //���E�㍡�񔄏���z
            temp.OfsThisTimeSales = reader.ReadInt64();
            //���E�㍡�񔄏�����
            temp.OfsThisSalesTax = reader.ReadInt64();
            //���񔄏���z
            temp.ThisTimeSales = reader.ReadInt64();
            //���񔄏�����
            temp.ThisSalesTax = reader.ReadInt64();
            //���񔄏�ԕi���z
            temp.ThisSalesPricRgds = reader.ReadInt64();
            //���񔄏�l�����z
            temp.ThisSalesPricDis = reader.ReadInt64();
            //�v�Z�㐿�����z
            temp.AfCalDemandPrice = reader.ReadInt64();
            //����`�[����
            temp.SalesSlipCount = reader.ReadInt32();
            //��2��O�c���i�����v�j
            temp.AcpOdrTtl2TmBfBlDmd = reader.ReadInt64();
            //��3��O�c���i�����v�j
            temp.AcpOdrTtl3TmBfBlDmd = reader.ReadInt64();
            //�W���S���]�ƈ��R�[�h
            temp.BillCollecterCd = reader.ReadString();
            //�W���S���]�ƈ�����
            temp.BillCollecterNm = reader.ReadString();
            //�������
            temp.CollectCond = reader.ReadInt32();
            //�W�����敪����
            temp.CollectMoneyName = reader.ReadString();
            //����
            temp.TotalDay = reader.ReadInt32();
            //�W����
            temp.CollectMoneyDay = reader.ReadInt32();


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
        /// <returns>RsltInfo_DemandBalanceWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_DemandBalanceWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RsltInfo_DemandBalanceWork temp = GetRsltInfo_DemandBalanceWork(reader, serInfo);
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
                    retValue = (RsltInfo_DemandBalanceWork[])lst.ToArray(typeof(RsltInfo_DemandBalanceWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
