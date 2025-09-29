using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RsltInfo_AccPayBalanceWork
    /// <summary>
    ///                      ���|�c���������o���ʃ��[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���|�c���������o���ʃ��[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/27  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RsltInfo_AccPayBalanceWork
    {
        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>�v�㋒�_����</summary>
        /// <remarks>�����[�g���ŎZ�o</remarks>
        private string _addUpSecName = "";

        /// <summary>�x����R�[�h</summary>
        /// <remarks>������e�R�[�h</remarks>
        private Int32 _payeeCode;

        /// <summary>�x���於��</summary>
        private string _payeeName = "";

        /// <summary>�x���於��2</summary>
        private string _payeeName2 = "";

        /// <summary>�x���旪��</summary>
        private string _payeeSnm = "";

        /// <summary>�v��N����</summary>
        /// <remarks>YYYYMMDD ���������s�Ȃ������i������j</remarks>
        private DateTime _addUpDate;

        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>�O�񔃊|���z</summary>
        private Int64 _lastTimeAccPay;

        /// <summary>�d��2��O�c���i���|�v�j</summary>
        private Int64 _stckTtl2TmBfBlAccPay;

        /// <summary>�d��3��O�c���i���|�v�j</summary>
        private Int64 _stckTtl3TmBfBlAccPay;

        /// <summary>����x�����z�i�ʏ�x���j</summary>
        /// <remarks>�x���z�̍��v���z</remarks>
        private Int64 _thisTimePayNrml;

        /// <summary>����萔���z�i�ʏ�x���j</summary>
        private Int64 _thisTimeFeePayNrml;

        /// <summary>����l���z�i�ʏ�x���j</summary>
        private Int64 _thisTimeDisPayNrml;

        /// <summary>����J�z�c���i���|�v�j</summary>
        /// <remarks>����J�z�c�����O��x���z�|����x���z�i�x���v�j</remarks>
        private Int64 _thisTimeTtlBlcAcPay;

        /// <summary>���E�㍡��d�����z</summary>
        private Int64 _ofsThisTimeStock;

        /// <summary>���E�㍡��d�������</summary>
        private Int64 _ofsThisStockTax;

        /// <summary>����d�����z</summary>
        /// <remarks>�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d�����z</remarks>
        private Int64 _thisTimeStockPrice;

        /// <summary>����d�������</summary>
        /// <remarks>����d������Ł��d���O�Ŋz���v�{�d�����Ŋz���v</remarks>
        private Int64 _thisStcPrcTax;

        /// <summary>����ԕi���z</summary>
        /// <remarks>�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d���ԕi���z</remarks>
        private Int64 _thisStckPricRgds;

        /// <summary>����ԕi�����</summary>
        /// <remarks>����ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v</remarks>
        private Int64 _thisStcPrcTaxRgds;

        /// <summary>����l�����z</summary>
        /// <remarks>�Ŕ����̎d���l�������z</remarks>
        private Int64 _thisStckPricDis;

        /// <summary>����l�������</summary>
        /// <remarks>����l������Ł��l���O�Ŋz���v�{�l�����Ŋz���v</remarks>
        private Int64 _thisStcPrcTaxDis;

        /// <summary>����Œ����z</summary>
        private Int64 _taxAdjust;

        /// <summary>�c�������z</summary>
        private Int64 _balanceAdjust;

        /// <summary>�d�����v�c���i���|�v�j</summary>
        private Int64 _stckTtlAccPayBalance;

        /// <summary>�d���`�[����</summary>
        private Int32 _stockSlipCount;

        /// <summary>�x������</summary>
        /// <remarks>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</remarks>
        private Int32 _paymentCond;

        /// <summary>�x������</summary>
        private Int32 _paymentTotalDay;

        /// <summary>�x�����敪����</summary>
        /// <remarks>�����A�����A���X��</remarks>
        private string _paymentMonthName = "";

        /// <summary>�x����</summary>
        /// <remarks>DD</remarks>
        private Int32 _paymentDay;


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

        /// public propaty name  :  PayeeCode
        /// <summary>�x����R�[�h�v���p�e�B</summary>
        /// <value>������e�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayeeCode
        {
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

        /// public propaty name  :  PayeeName
        /// <summary>�x���於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeName
        {
            get { return _payeeName; }
            set { _payeeName = value; }
        }

        /// public propaty name  :  PayeeName2
        /// <summary>�x���於��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeName2
        {
            get { return _payeeName2; }
            set { _payeeName2 = value; }
        }

        /// public propaty name  :  PayeeSnm
        /// <summary>�x���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeSnm
        {
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
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

        /// public propaty name  :  LastTimeAccPay
        /// <summary>�O�񔃊|���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�񔃊|���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 LastTimeAccPay
        {
            get { return _lastTimeAccPay; }
            set { _lastTimeAccPay = value; }
        }

        /// public propaty name  :  StckTtl2TmBfBlAccPay
        /// <summary>�d��2��O�c���i���|�v�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��2��O�c���i���|�v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StckTtl2TmBfBlAccPay
        {
            get { return _stckTtl2TmBfBlAccPay; }
            set { _stckTtl2TmBfBlAccPay = value; }
        }

        /// public propaty name  :  StckTtl3TmBfBlAccPay
        /// <summary>�d��3��O�c���i���|�v�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��3��O�c���i���|�v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StckTtl3TmBfBlAccPay
        {
            get { return _stckTtl3TmBfBlAccPay; }
            set { _stckTtl3TmBfBlAccPay = value; }
        }

        /// public propaty name  :  ThisTimePayNrml
        /// <summary>����x�����z�i�ʏ�x���j�v���p�e�B</summary>
        /// <value>�x���z�̍��v���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����x�����z�i�ʏ�x���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimePayNrml
        {
            get { return _thisTimePayNrml; }
            set { _thisTimePayNrml = value; }
        }

        /// public propaty name  :  ThisTimeFeePayNrml
        /// <summary>����萔���z�i�ʏ�x���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����萔���z�i�ʏ�x���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeFeePayNrml
        {
            get { return _thisTimeFeePayNrml; }
            set { _thisTimeFeePayNrml = value; }
        }

        /// public propaty name  :  ThisTimeDisPayNrml
        /// <summary>����l���z�i�ʏ�x���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l���z�i�ʏ�x���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeDisPayNrml
        {
            get { return _thisTimeDisPayNrml; }
            set { _thisTimeDisPayNrml = value; }
        }

        /// public propaty name  :  ThisTimeTtlBlcAcPay
        /// <summary>����J�z�c���i���|�v�j�v���p�e�B</summary>
        /// <value>����J�z�c�����O��x���z�|����x���z�i�x���v�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����J�z�c���i���|�v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeTtlBlcAcPay
        {
            get { return _thisTimeTtlBlcAcPay; }
            set { _thisTimeTtlBlcAcPay = value; }
        }

        /// public propaty name  :  OfsThisTimeStock
        /// <summary>���E�㍡��d�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E�㍡��d�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OfsThisTimeStock
        {
            get { return _ofsThisTimeStock; }
            set { _ofsThisTimeStock = value; }
        }

        /// public propaty name  :  OfsThisStockTax
        /// <summary>���E�㍡��d������Ńv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E�㍡��d������Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OfsThisStockTax
        {
            get { return _ofsThisStockTax; }
            set { _ofsThisStockTax = value; }
        }

        /// public propaty name  :  ThisTimeStockPrice
        /// <summary>����d�����z�v���p�e�B</summary>
        /// <value>�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����d�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeStockPrice
        {
            get { return _thisTimeStockPrice; }
            set { _thisTimeStockPrice = value; }
        }

        /// public propaty name  :  ThisStcPrcTax
        /// <summary>����d������Ńv���p�e�B</summary>
        /// <value>����d������Ł��d���O�Ŋz���v�{�d�����Ŋz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����d������Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisStcPrcTax
        {
            get { return _thisStcPrcTax; }
            set { _thisStcPrcTax = value; }
        }

        /// public propaty name  :  ThisStckPricRgds
        /// <summary>����ԕi���z�v���p�e�B</summary>
        /// <value>�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d���ԕi���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ԕi���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisStckPricRgds
        {
            get { return _thisStckPricRgds; }
            set { _thisStckPricRgds = value; }
        }

        /// public propaty name  :  ThisStcPrcTaxRgds
        /// <summary>����ԕi����Ńv���p�e�B</summary>
        /// <value>����ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ԕi����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisStcPrcTaxRgds
        {
            get { return _thisStcPrcTaxRgds; }
            set { _thisStcPrcTaxRgds = value; }
        }

        /// public propaty name  :  ThisStckPricDis
        /// <summary>����l�����z�v���p�e�B</summary>
        /// <value>�Ŕ����̎d���l�������z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisStckPricDis
        {
            get { return _thisStckPricDis; }
            set { _thisStckPricDis = value; }
        }

        /// public propaty name  :  ThisStcPrcTaxDis
        /// <summary>����l������Ńv���p�e�B</summary>
        /// <value>����l������Ł��l���O�Ŋz���v�{�l�����Ŋz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l������Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisStcPrcTaxDis
        {
            get { return _thisStcPrcTaxDis; }
            set { _thisStcPrcTaxDis = value; }
        }

        /// public propaty name  :  TaxAdjust
        /// <summary>����Œ����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Œ����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TaxAdjust
        {
            get { return _taxAdjust; }
            set { _taxAdjust = value; }
        }

        /// public propaty name  :  BalanceAdjust
        /// <summary>�c�������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c�������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 BalanceAdjust
        {
            get { return _balanceAdjust; }
            set { _balanceAdjust = value; }
        }

        /// public propaty name  :  StckTtlAccPayBalance
        /// <summary>�d�����v�c���i���|�v�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v�c���i���|�v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StckTtlAccPayBalance
        {
            get { return _stckTtlAccPayBalance; }
            set { _stckTtlAccPayBalance = value; }
        }

        /// public propaty name  :  StockSlipCount
        /// <summary>�d���`�[�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSlipCount
        {
            get { return _stockSlipCount; }
            set { _stockSlipCount = value; }
        }

        /// public propaty name  :  PaymentCond
        /// <summary>�x�������v���p�e�B</summary>
        /// <value>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentCond
        {
            get { return _paymentCond; }
            set { _paymentCond = value; }
        }

        /// public propaty name  :  PaymentTotalDay
        /// <summary>�x�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentTotalDay
        {
            get { return _paymentTotalDay; }
            set { _paymentTotalDay = value; }
        }

        /// public propaty name  :  PaymentMonthName
        /// <summary>�x�����敪���̃v���p�e�B</summary>
        /// <value>�����A�����A���X��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentMonthName
        {
            get { return _paymentMonthName; }
            set { _paymentMonthName = value; }
        }

        /// public propaty name  :  PaymentDay
        /// <summary>�x�����v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentDay
        {
            get { return _paymentDay; }
            set { _paymentDay = value; }
        }


        /// <summary>
        /// ���|�c���������o���ʃ��[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RsltInfo_AccPayBalanceWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_AccPayBalanceWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RsltInfo_AccPayBalanceWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RsltInfo_AccPayBalanceWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RsltInfo_AccPayBalanceWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RsltInfo_AccPayBalanceWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_AccPayBalanceWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RsltInfo_AccPayBalanceWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RsltInfo_AccPayBalanceWork || graph is ArrayList || graph is RsltInfo_AccPayBalanceWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RsltInfo_AccPayBalanceWork).FullName));

            if (graph != null && graph is RsltInfo_AccPayBalanceWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RsltInfo_AccPayBalanceWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RsltInfo_AccPayBalanceWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RsltInfo_AccPayBalanceWork[])graph).Length;
            }
            else if (graph is RsltInfo_AccPayBalanceWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //�v�㋒�_����
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecName
            //�x����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //�x���於��
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName
            //�x���於��2
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName2
            //�x���旪��
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm
            //�v��N����
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //�v��N��
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //�O�񔃊|���z
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeAccPay
            //�d��2��O�c���i���|�v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //StckTtl2TmBfBlAccPay
            //�d��3��O�c���i���|�v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //StckTtl3TmBfBlAccPay
            //����x�����z�i�ʏ�x���j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimePayNrml
            //����萔���z�i�ʏ�x���j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeFeePayNrml
            //����l���z�i�ʏ�x���j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDisPayNrml
            //����J�z�c���i���|�v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlcAcPay
            //���E�㍡��d�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeStock
            //���E�㍡��d�������
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisStockTax
            //����d�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeStockPrice
            //����d�������
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStcPrcTax
            //����ԕi���z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricRgds
            //����ԕi�����
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStcPrcTaxRgds
            //����l�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricDis
            //����l�������
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStcPrcTaxDis
            //����Œ����z
            serInfo.MemberInfo.Add(typeof(Int64)); //TaxAdjust
            //�c�������z
            serInfo.MemberInfo.Add(typeof(Int64)); //BalanceAdjust
            //�d�����v�c���i���|�v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //StckTtlAccPayBalance
            //�d���`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCount
            //�x������
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentCond
            //�x������
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentTotalDay
            //�x�����敪����
            serInfo.MemberInfo.Add(typeof(string)); //PaymentMonthName
            //�x����
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentDay


            serInfo.Serialize(writer, serInfo);
            if (graph is RsltInfo_AccPayBalanceWork)
            {
                RsltInfo_AccPayBalanceWork temp = (RsltInfo_AccPayBalanceWork)graph;

                SetRsltInfo_AccPayBalanceWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RsltInfo_AccPayBalanceWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RsltInfo_AccPayBalanceWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RsltInfo_AccPayBalanceWork temp in lst)
                {
                    SetRsltInfo_AccPayBalanceWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RsltInfo_AccPayBalanceWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 31;

        /// <summary>
        ///  RsltInfo_AccPayBalanceWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_AccPayBalanceWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRsltInfo_AccPayBalanceWork(System.IO.BinaryWriter writer, RsltInfo_AccPayBalanceWork temp)
        {
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //�v�㋒�_����
            writer.Write(temp.AddUpSecName);
            //�x����R�[�h
            writer.Write(temp.PayeeCode);
            //�x���於��
            writer.Write(temp.PayeeName);
            //�x���於��2
            writer.Write(temp.PayeeName2);
            //�x���旪��
            writer.Write(temp.PayeeSnm);
            //�v��N����
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //�v��N��
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //�O�񔃊|���z
            writer.Write(temp.LastTimeAccPay);
            //�d��2��O�c���i���|�v�j
            writer.Write(temp.StckTtl2TmBfBlAccPay);
            //�d��3��O�c���i���|�v�j
            writer.Write(temp.StckTtl3TmBfBlAccPay);
            //����x�����z�i�ʏ�x���j
            writer.Write(temp.ThisTimePayNrml);
            //����萔���z�i�ʏ�x���j
            writer.Write(temp.ThisTimeFeePayNrml);
            //����l���z�i�ʏ�x���j
            writer.Write(temp.ThisTimeDisPayNrml);
            //����J�z�c���i���|�v�j
            writer.Write(temp.ThisTimeTtlBlcAcPay);
            //���E�㍡��d�����z
            writer.Write(temp.OfsThisTimeStock);
            //���E�㍡��d�������
            writer.Write(temp.OfsThisStockTax);
            //����d�����z
            writer.Write(temp.ThisTimeStockPrice);
            //����d�������
            writer.Write(temp.ThisStcPrcTax);
            //����ԕi���z
            writer.Write(temp.ThisStckPricRgds);
            //����ԕi�����
            writer.Write(temp.ThisStcPrcTaxRgds);
            //����l�����z
            writer.Write(temp.ThisStckPricDis);
            //����l�������
            writer.Write(temp.ThisStcPrcTaxDis);
            //����Œ����z
            writer.Write(temp.TaxAdjust);
            //�c�������z
            writer.Write(temp.BalanceAdjust);
            //�d�����v�c���i���|�v�j
            writer.Write(temp.StckTtlAccPayBalance);
            //�d���`�[����
            writer.Write(temp.StockSlipCount);
            //�x������
            writer.Write(temp.PaymentCond);
            //�x������
            writer.Write(temp.PaymentTotalDay);
            //�x�����敪����
            writer.Write(temp.PaymentMonthName);
            //�x����
            writer.Write(temp.PaymentDay);

        }

        /// <summary>
        ///  RsltInfo_AccPayBalanceWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RsltInfo_AccPayBalanceWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_AccPayBalanceWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RsltInfo_AccPayBalanceWork GetRsltInfo_AccPayBalanceWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RsltInfo_AccPayBalanceWork temp = new RsltInfo_AccPayBalanceWork();

            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //�v�㋒�_����
            temp.AddUpSecName = reader.ReadString();
            //�x����R�[�h
            temp.PayeeCode = reader.ReadInt32();
            //�x���於��
            temp.PayeeName = reader.ReadString();
            //�x���於��2
            temp.PayeeName2 = reader.ReadString();
            //�x���旪��
            temp.PayeeSnm = reader.ReadString();
            //�v��N����
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //�v��N��
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //�O�񔃊|���z
            temp.LastTimeAccPay = reader.ReadInt64();
            //�d��2��O�c���i���|�v�j
            temp.StckTtl2TmBfBlAccPay = reader.ReadInt64();
            //�d��3��O�c���i���|�v�j
            temp.StckTtl3TmBfBlAccPay = reader.ReadInt64();
            //����x�����z�i�ʏ�x���j
            temp.ThisTimePayNrml = reader.ReadInt64();
            //����萔���z�i�ʏ�x���j
            temp.ThisTimeFeePayNrml = reader.ReadInt64();
            //����l���z�i�ʏ�x���j
            temp.ThisTimeDisPayNrml = reader.ReadInt64();
            //����J�z�c���i���|�v�j
            temp.ThisTimeTtlBlcAcPay = reader.ReadInt64();
            //���E�㍡��d�����z
            temp.OfsThisTimeStock = reader.ReadInt64();
            //���E�㍡��d�������
            temp.OfsThisStockTax = reader.ReadInt64();
            //����d�����z
            temp.ThisTimeStockPrice = reader.ReadInt64();
            //����d�������
            temp.ThisStcPrcTax = reader.ReadInt64();
            //����ԕi���z
            temp.ThisStckPricRgds = reader.ReadInt64();
            //����ԕi�����
            temp.ThisStcPrcTaxRgds = reader.ReadInt64();
            //����l�����z
            temp.ThisStckPricDis = reader.ReadInt64();
            //����l�������
            temp.ThisStcPrcTaxDis = reader.ReadInt64();
            //����Œ����z
            temp.TaxAdjust = reader.ReadInt64();
            //�c�������z
            temp.BalanceAdjust = reader.ReadInt64();
            //�d�����v�c���i���|�v�j
            temp.StckTtlAccPayBalance = reader.ReadInt64();
            //�d���`�[����
            temp.StockSlipCount = reader.ReadInt32();
            //�x������
            temp.PaymentCond = reader.ReadInt32();
            //�x������
            temp.PaymentTotalDay = reader.ReadInt32();
            //�x�����敪����
            temp.PaymentMonthName = reader.ReadString();
            //�x����
            temp.PaymentDay = reader.ReadInt32();


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
        /// <returns>RsltInfo_AccPayBalanceWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_AccPayBalanceWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RsltInfo_AccPayBalanceWork temp = GetRsltInfo_AccPayBalanceWork(reader, serInfo);
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
                    retValue = (RsltInfo_AccPayBalanceWork[])lst.ToArray(typeof(RsltInfo_AccPayBalanceWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
