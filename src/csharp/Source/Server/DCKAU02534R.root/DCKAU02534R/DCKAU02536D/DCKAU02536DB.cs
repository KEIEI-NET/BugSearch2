using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RsltInfo_CollectPlanWork
    /// <summary>
    ///                      ����\��\���o���ʃ��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����\��\���o���ʃ��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RsltInfo_CollectPlanWork
    {
        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>�v�㋒�_����</summary>
        /// <remarks>���_���ݒ�}�X�^����擾</remarks>
        private string _addUpSecName = "";

        /// <summary>������R�[�h</summary>
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

        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>��3��O�c���i�����v�j</summary>
        private Int64 _acpOdrTtl3TmBfBlDmd;

        /// <summary>��2��O�c���i�����v�j</summary>
        private Int64 _acpOdrTtl2TmBfBlDmd;

        /// <summary>�O�񐿋����z</summary>
        private Int64 _lastTimeDemand;

        /// <summary>���E�㍡�񔄏���z</summary>
        /// <remarks>���E���ʁ@�u���E��F***�v�̒l���������z�ƂȂ�</remarks>
        private Int64 _ofsThisTimeSales;

        /// <summary>���񔄏�ԕi���z</summary>
        /// <remarks>�|���F�l�����܂܂Ȃ��Ŕ����̔���ԕi���z</remarks>
        private Int64 _thisSalesPricRgds;

        /// <summary>���񔄏�l�����z</summary>
        /// <remarks>�|���F�Ŕ����̔���l�����z</remarks>
        private Int64 _thisSalesPricDis;

        /// <summary>���E�㍡�񔄏�����</summary>
        /// <remarks>���E����</remarks>
        private Int64 _ofsThisSalesTax;

        /// <summary>����������z�i�ʏ�����j</summary>
        /// <remarks>�����z�̍��v���z</remarks>
        private Int64 _thisTimeDmdNrml;

        /// <summary>��������z</summary>
        /// <remarks>���������`����\����܂ł̓����z(�����[�g���ŎZ�o)</remarks>
        private Int64 _afterCloseDemand;

        /// <summary>�W�����敪�R�[�h</summary>
        /// <remarks>0:����,1:����,2:���X��</remarks>
        private Int32 _collectMoneyCode;

        /// <summary>�W�����敪����</summary>
        /// <remarks>����,����,���X��</remarks>
        private string _collectMoneyName = "";

        /// <summary>�W����</summary>
        /// <remarks>DD</remarks>
        private Int32 _collectMoneyDay;

        /// <summary>�������</summary>
        /// <remarks>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</remarks>
        private Int32 _collectCond;

        /// <summary>����T�C�g</summary>
        /// <remarks>��`�T�C�g�@180��</remarks>
        private Int32 _collectSight;

        /// <summary>�W���S���]�ƈ��R�[�h</summary>
        /// <remarks>���Ӑ�}�X�^����擾</remarks>
        private string _billCollecterCd = "";

        /// <summary>�W���S���]�ƈ�����</summary>
        /// <remarks>���Ӑ�}�X�^����擾</remarks>
        private string _billCollecterNm = "";

        /// <summary>�ڋq�S���]�ƈ��R�[�h</summary>
        /// <remarks>���Ӑ�}�X�^����擾(�V���S���Ή��������[�g���Ŏ��s)</remarks>
        private string _customerAgentCd = "";

        /// <summary>�ڋq�S���]�ƈ�����</summary>
        /// <remarks>���Ӑ�}�X�^����擾(�V���S���Ή��������[�g���Ŏ��s)</remarks>
        private string _customerAgentNm = "";

        /// <summary>�̔��G���A�R�[�h</summary>
        /// <remarks>���Ӑ�}�X�^����擾</remarks>
        private Int32 _salesAreaCode;

        /// <summary>�̔��G���A����</summary>
        /// <remarks>���Ӑ�}�X�^����擾</remarks>
        private string _salesAreaName = "";

        /// <summary>����\��敪</summary>
        /// <remarks>0:�敪 1:���t �����S�̐ݒ�}�X�^����擾</remarks>
        private Int32 _collectPlnDiv;

        /// <summary>����</summary>
        /// <remarks>DD ���Ӑ�}�X�^����擾</remarks>
        private Int32 _totalDay;


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
        /// <value>���_���ݒ�}�X�^����擾</value>
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

        /// public propaty name  :  AddUpYearMonth
        /// <summary>�v��N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
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

        /// public propaty name  :  OfsThisTimeSales
        /// <summary>���E�㍡�񔄏���z�v���p�e�B</summary>
        /// <value>���E���ʁ@�u���E��F***�v�̒l���������z�ƂȂ�</value>
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

        /// public propaty name  :  OfsThisSalesTax
        /// <summary>���E�㍡�񔄏����Ńv���p�e�B</summary>
        /// <value>���E����</value>
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

        /// public propaty name  :  AfterCloseDemand
        /// <summary>��������z�v���p�e�B</summary>
        /// <value>���������`����\����܂ł̓����z(�����[�g���ŎZ�o)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AfterCloseDemand
        {
            get { return _afterCloseDemand; }
            set { _afterCloseDemand = value; }
        }

        /// public propaty name  :  CollectMoneyCode
        /// <summary>�W�����敪�R�[�h�v���p�e�B</summary>
        /// <value>0:����,1:����,2:���X��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CollectMoneyCode
        {
            get { return _collectMoneyCode; }
            set { _collectMoneyCode = value; }
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

        /// public propaty name  :  CollectCond
        /// <summary>��������v���p�e�B</summary>
        /// <value>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</value>
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

        /// public propaty name  :  CollectSight
        /// <summary>����T�C�g�v���p�e�B</summary>
        /// <value>��`�T�C�g�@180��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����T�C�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CollectSight
        {
            get { return _collectSight; }
            set { _collectSight = value; }
        }

        /// public propaty name  :  BillCollecterCd
        /// <summary>�W���S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���Ӑ�}�X�^����擾</value>
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
        /// <value>���Ӑ�}�X�^����擾</value>
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

        /// public propaty name  :  CustomerAgentCd
        /// <summary>�ڋq�S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���Ӑ�}�X�^����擾(�V���S���Ή��������[�g���Ŏ��s)</value>
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

        /// public propaty name  :  CustomerAgentNm
        /// <summary>�ڋq�S���]�ƈ����̃v���p�e�B</summary>
        /// <value>���Ӑ�}�X�^����擾(�V���S���Ή��������[�g���Ŏ��s)</value>
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

        /// public propaty name  :  SalesAreaCode
        /// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
        /// <value>���Ӑ�}�X�^����擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaName
        /// <summary>�̔��G���A���̃v���p�e�B</summary>
        /// <value>���Ӑ�}�X�^����擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  CollectPlnDiv
        /// <summary>����\��敪�v���p�e�B</summary>
        /// <value>0:�敪 1:���t �����S�̐ݒ�}�X�^����擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����\��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CollectPlnDiv
        {
            get { return _collectPlnDiv; }
            set { _collectPlnDiv = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>�����v���p�e�B</summary>
        /// <value>DD ���Ӑ�}�X�^����擾</value>
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


        /// <summary>
        /// ����\��\���o���ʃ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RsltInfo_CollectPlanWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_CollectPlanWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RsltInfo_CollectPlanWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RsltInfo_CollectPlanWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RsltInfo_CollectPlanWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RsltInfo_CollectPlanWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_CollectPlanWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RsltInfo_CollectPlanWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RsltInfo_CollectPlanWork || graph is ArrayList || graph is RsltInfo_CollectPlanWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RsltInfo_CollectPlanWork).FullName));

            if (graph != null && graph is RsltInfo_CollectPlanWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RsltInfo_CollectPlanWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RsltInfo_CollectPlanWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RsltInfo_CollectPlanWork[])graph).Length;
            }
            else if (graph is RsltInfo_CollectPlanWork)
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
            //�v��N��
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //��3��O�c���i�����v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl3TmBfBlDmd
            //��2��O�c���i�����v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl2TmBfBlDmd
            //�O�񐿋����z
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeDemand
            //���E�㍡�񔄏���z
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeSales
            //���񔄏�ԕi���z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricRgds
            //���񔄏�l�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricDis
            //���E�㍡�񔄏�����
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisSalesTax
            //����������z�i�ʏ�����j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDmdNrml
            //��������z
            serInfo.MemberInfo.Add(typeof(Int64)); //AfterCloseDemand
            //�W�����敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectMoneyCode
            //�W�����敪����
            serInfo.MemberInfo.Add(typeof(string)); //CollectMoneyName
            //�W����
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectMoneyDay
            //�������
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectCond
            //����T�C�g
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectSight
            //�W���S���]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BillCollecterCd
            //�W���S���]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //BillCollecterNm
            //�ڋq�S���]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgentCd
            //�ڋq�S���]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgentNm
            //�̔��G���A�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //�̔��G���A����
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //����\��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectPlnDiv
            //����
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalDay


            serInfo.Serialize(writer, serInfo);
            if (graph is RsltInfo_CollectPlanWork)
            {
                RsltInfo_CollectPlanWork temp = (RsltInfo_CollectPlanWork)graph;

                SetRsltInfo_CollectPlanWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RsltInfo_CollectPlanWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RsltInfo_CollectPlanWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RsltInfo_CollectPlanWork temp in lst)
                {
                    SetRsltInfo_CollectPlanWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RsltInfo_CollectPlanWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 30;

        /// <summary>
        ///  RsltInfo_CollectPlanWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_CollectPlanWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRsltInfo_CollectPlanWork(System.IO.BinaryWriter writer, RsltInfo_CollectPlanWork temp)
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
            //�v��N��
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //��3��O�c���i�����v�j
            writer.Write(temp.AcpOdrTtl3TmBfBlDmd);
            //��2��O�c���i�����v�j
            writer.Write(temp.AcpOdrTtl2TmBfBlDmd);
            //�O�񐿋����z
            writer.Write(temp.LastTimeDemand);
            //���E�㍡�񔄏���z
            writer.Write(temp.OfsThisTimeSales);
            //���񔄏�ԕi���z
            writer.Write(temp.ThisSalesPricRgds);
            //���񔄏�l�����z
            writer.Write(temp.ThisSalesPricDis);
            //���E�㍡�񔄏�����
            writer.Write(temp.OfsThisSalesTax);
            //����������z�i�ʏ�����j
            writer.Write(temp.ThisTimeDmdNrml);
            //��������z
            writer.Write(temp.AfterCloseDemand);
            //�W�����敪�R�[�h
            writer.Write(temp.CollectMoneyCode);
            //�W�����敪����
            writer.Write(temp.CollectMoneyName);
            //�W����
            writer.Write(temp.CollectMoneyDay);
            //�������
            writer.Write(temp.CollectCond);
            //����T�C�g
            writer.Write(temp.CollectSight);
            //�W���S���]�ƈ��R�[�h
            writer.Write(temp.BillCollecterCd);
            //�W���S���]�ƈ�����
            writer.Write(temp.BillCollecterNm);
            //�ڋq�S���]�ƈ��R�[�h
            writer.Write(temp.CustomerAgentCd);
            //�ڋq�S���]�ƈ�����
            writer.Write(temp.CustomerAgentNm);
            //�̔��G���A�R�[�h
            writer.Write(temp.SalesAreaCode);
            //�̔��G���A����
            writer.Write(temp.SalesAreaName);
            //����\��敪
            writer.Write(temp.CollectPlnDiv);
            //����
            writer.Write(temp.TotalDay);

        }

        /// <summary>
        ///  RsltInfo_CollectPlanWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RsltInfo_CollectPlanWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_CollectPlanWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RsltInfo_CollectPlanWork GetRsltInfo_CollectPlanWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RsltInfo_CollectPlanWork temp = new RsltInfo_CollectPlanWork();

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
            //�v��N��
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //��3��O�c���i�����v�j
            temp.AcpOdrTtl3TmBfBlDmd = reader.ReadInt64();
            //��2��O�c���i�����v�j
            temp.AcpOdrTtl2TmBfBlDmd = reader.ReadInt64();
            //�O�񐿋����z
            temp.LastTimeDemand = reader.ReadInt64();
            //���E�㍡�񔄏���z
            temp.OfsThisTimeSales = reader.ReadInt64();
            //���񔄏�ԕi���z
            temp.ThisSalesPricRgds = reader.ReadInt64();
            //���񔄏�l�����z
            temp.ThisSalesPricDis = reader.ReadInt64();
            //���E�㍡�񔄏�����
            temp.OfsThisSalesTax = reader.ReadInt64();
            //����������z�i�ʏ�����j
            temp.ThisTimeDmdNrml = reader.ReadInt64();
            //��������z
            temp.AfterCloseDemand = reader.ReadInt64();
            //�W�����敪�R�[�h
            temp.CollectMoneyCode = reader.ReadInt32();
            //�W�����敪����
            temp.CollectMoneyName = reader.ReadString();
            //�W����
            temp.CollectMoneyDay = reader.ReadInt32();
            //�������
            temp.CollectCond = reader.ReadInt32();
            //����T�C�g
            temp.CollectSight = reader.ReadInt32();
            //�W���S���]�ƈ��R�[�h
            temp.BillCollecterCd = reader.ReadString();
            //�W���S���]�ƈ�����
            temp.BillCollecterNm = reader.ReadString();
            //�ڋq�S���]�ƈ��R�[�h
            temp.CustomerAgentCd = reader.ReadString();
            //�ڋq�S���]�ƈ�����
            temp.CustomerAgentNm = reader.ReadString();
            //�̔��G���A�R�[�h
            temp.SalesAreaCode = reader.ReadInt32();
            //�̔��G���A����
            temp.SalesAreaName = reader.ReadString();
            //����\��敪
            temp.CollectPlnDiv = reader.ReadInt32();
            //����
            temp.TotalDay = reader.ReadInt32();


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
        /// <returns>RsltInfo_CollectPlanWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_CollectPlanWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RsltInfo_CollectPlanWork temp = GetRsltInfo_CollectPlanWork(reader, serInfo);
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
                    retValue = (RsltInfo_CollectPlanWork[])lst.ToArray(typeof(RsltInfo_CollectPlanWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
