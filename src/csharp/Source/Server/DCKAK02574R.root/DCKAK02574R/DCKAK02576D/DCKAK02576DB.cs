using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RsltInfo_PaymentBalanceWork
    /// <summary>
    ///                      �x���c���������o���ʃ��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �x���c���������o���ʃ��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RsltInfo_PaymentBalanceWork
    {
        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>�v�㋒�_����</summary>
        /// <remarks>�����[�g���ŎZ�o</remarks>
        private string _addUpSecName = "";

        /// <summary>�x����R�[�h</summary>
        /// <remarks>�x����̐e�R�[�h</remarks>
        private Int32 _payeeCode;

        /// <summary>�x���於��</summary>
        private string _payeeName = "";

        /// <summary>�x���於��2</summary>
        private string _payeeName2 = "";

        /// <summary>�x���旪��</summary>
        private string _payeeSnm = "";

        /// <summary>�v��N����</summary>
        /// <remarks>YYYYMMDD �x�������s�Ȃ������i������j</remarks>
        private DateTime _addUpDate;

        /// <summary>�O��x�����z</summary>
        private Int64 _lastTimePayment;

        /// <summary>����x�����z�i�ʏ�x���j</summary>
        /// <remarks>�x���z�̍��v���z</remarks>
        private Int64 _thisTimePayNrml;

        /// <summary>����J�z�c���i�x���v�j</summary>
        /// <remarks>����J�z�c�����O��x���z �[�@����x���z���v�i�ʏ�x���j</remarks>
        private Int64 _thisTimeTtlBlcPay;

        /// <summary>���E�㍡��d�����z</summary>
        /// <remarks>���E����</remarks>
        private Int64 _ofsThisTimeStock;

        /// <summary>���E�㍡��d�������</summary>
        /// <remarks>���E����</remarks>
        private Int64 _ofsThisStockTax;

        /// <summary>����d�����z</summary>
        /// <remarks>�|�d���F�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d�����z</remarks>
        private Int64 _thisTimeStockPrice;

        /// <summary>����d�������</summary>
        /// <remarks>����d������Ł��d���O�Ŋz���v�{�d�����Ŋz���v</remarks>
        private Int64 _thisStcPrcTax;

        /// <summary>����ԕi���z</summary>
        /// <remarks>�|�d���F�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d���ԕi���z</remarks>
        private Int64 _thisStckPricRgds;

        /// <summary>����l�����z</summary>
        /// <remarks>�|�d���F�Ŕ����̎d���l�������z</remarks>
        private Int64 _thisStckPricDis;

        /// <summary>�d�����v�c���i�x���v�j</summary>
        /// <remarks>���񕪂̎x�����z</remarks>
        private Int64 _stockTotalPayBalance;

        /// <summary>�d���`�[����</summary>
        private Int32 _stockSlipCount;

        /// <summary>�d��2��O�c���i�x���v�j</summary>
        private Int64 _stockTtl2TmBfBlPay;

        /// <summary>�d��3��O�c���i�x���v�j</summary>
        private Int64 _stockTtl3TmBfBlPay;

        /// <summary>�d���S���҃R�[�h</summary>
        private string _stockAgentCode = "";

        /// <summary>�d���S���Җ���</summary>
        private string _stockAgentName = "";

        /// <summary>�x������</summary>
        private Int32 _paymentCond;

        /// <summary>�x�����敪����</summary>
        /// <remarks>�����A�����A���X��</remarks>
        private string _paymentMonthName = "";

        /// <summary>�x����</summary>
        /// <remarks>DD</remarks>
        private Int32 _paymentDay;

        /// <summary>�x������</summary>
        private Int32 _paymentTotalDay;


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
        /// <value>�x����̐e�R�[�h</value>
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
        /// <value>YYYYMMDD �x�������s�Ȃ������i������j</value>
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

        /// public propaty name  :  LastTimePayment
        /// <summary>�O��x�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O��x�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 LastTimePayment
        {
            get { return _lastTimePayment; }
            set { _lastTimePayment = value; }
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

        /// public propaty name  :  ThisTimeTtlBlcPay
        /// <summary>����J�z�c���i�x���v�j�v���p�e�B</summary>
        /// <value>����J�z�c�����O��x���z �[�@����x���z���v�i�ʏ�x���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����J�z�c���i�x���v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeTtlBlcPay
        {
            get { return _thisTimeTtlBlcPay; }
            set { _thisTimeTtlBlcPay = value; }
        }

        /// public propaty name  :  OfsThisTimeStock
        /// <summary>���E�㍡��d�����z�v���p�e�B</summary>
        /// <value>���E����</value>
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
        /// <value>���E����</value>
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
        /// <value>�|�d���F�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d�����z</value>
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
        /// <value>�|�d���F�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d���ԕi���z</value>
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

        /// public propaty name  :  ThisStckPricDis
        /// <summary>����l�����z�v���p�e�B</summary>
        /// <value>�|�d���F�Ŕ����̎d���l�������z</value>
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

        /// public propaty name  :  StockTotalPayBalance
        /// <summary>�d�����v�c���i�x���v�j�v���p�e�B</summary>
        /// <value>���񕪂̎x�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v�c���i�x���v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalPayBalance
        {
            get { return _stockTotalPayBalance; }
            set { _stockTotalPayBalance = value; }
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

        /// public propaty name  :  StockTtl2TmBfBlPay
        /// <summary>�d��2��O�c���i�x���v�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��2��O�c���i�x���v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTtl2TmBfBlPay
        {
            get { return _stockTtl2TmBfBlPay; }
            set { _stockTtl2TmBfBlPay = value; }
        }

        /// public propaty name  :  StockTtl3TmBfBlPay
        /// <summary>�d��3��O�c���i�x���v�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��3��O�c���i�x���v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTtl3TmBfBlPay
        {
            get { return _stockTtl3TmBfBlPay; }
            set { _stockTtl3TmBfBlPay = value; }
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
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
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
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
        }

        /// public propaty name  :  PaymentCond
        /// <summary>�x�������v���p�e�B</summary>
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


        /// <summary>
        /// �x���c���������o���ʃ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RsltInfo_PaymentBalanceWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PaymentBalanceWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RsltInfo_PaymentBalanceWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RsltInfo_PaymentBalanceWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PaymentBalanceWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RsltInfo_PaymentBalanceWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PaymentBalanceWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RsltInfo_PaymentBalanceWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RsltInfo_PaymentBalanceWork || graph is ArrayList || graph is RsltInfo_PaymentBalanceWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RsltInfo_PaymentBalanceWork).FullName));

            if (graph != null && graph is RsltInfo_PaymentBalanceWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RsltInfo_PaymentBalanceWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RsltInfo_PaymentBalanceWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RsltInfo_PaymentBalanceWork[])graph).Length;
            }
            else if (graph is RsltInfo_PaymentBalanceWork)
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
            //�O��x�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimePayment
            //����x�����z�i�ʏ�x���j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimePayNrml
            //����J�z�c���i�x���v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlcPay
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
            //����l�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricDis
            //�d�����v�c���i�x���v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPayBalance
            //�d���`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCount
            //�d��2��O�c���i�x���v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtl2TmBfBlPay
            //�d��3��O�c���i�x���v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtl3TmBfBlPay
            //�d���S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //�d���S���Җ���
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //�x������
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentCond
            //�x�����敪����
            serInfo.MemberInfo.Add(typeof(string)); //PaymentMonthName
            //�x����
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentDay
            //�x������
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentTotalDay


            serInfo.Serialize(writer, serInfo);
            if (graph is RsltInfo_PaymentBalanceWork)
            {
                RsltInfo_PaymentBalanceWork temp = (RsltInfo_PaymentBalanceWork)graph;

                SetRsltInfo_PaymentBalanceWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RsltInfo_PaymentBalanceWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RsltInfo_PaymentBalanceWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RsltInfo_PaymentBalanceWork temp in lst)
                {
                    SetRsltInfo_PaymentBalanceWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RsltInfo_PaymentBalanceWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 26;

        /// <summary>
        ///  RsltInfo_PaymentBalanceWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PaymentBalanceWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRsltInfo_PaymentBalanceWork(System.IO.BinaryWriter writer, RsltInfo_PaymentBalanceWork temp)
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
            //�O��x�����z
            writer.Write(temp.LastTimePayment);
            //����x�����z�i�ʏ�x���j
            writer.Write(temp.ThisTimePayNrml);
            //����J�z�c���i�x���v�j
            writer.Write(temp.ThisTimeTtlBlcPay);
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
            //����l�����z
            writer.Write(temp.ThisStckPricDis);
            //�d�����v�c���i�x���v�j
            writer.Write(temp.StockTotalPayBalance);
            //�d���`�[����
            writer.Write(temp.StockSlipCount);
            //�d��2��O�c���i�x���v�j
            writer.Write(temp.StockTtl2TmBfBlPay);
            //�d��3��O�c���i�x���v�j
            writer.Write(temp.StockTtl3TmBfBlPay);
            //�d���S���҃R�[�h
            writer.Write(temp.StockAgentCode);
            //�d���S���Җ���
            writer.Write(temp.StockAgentName);
            //�x������
            writer.Write(temp.PaymentCond);
            //�x�����敪����
            writer.Write(temp.PaymentMonthName);
            //�x����
            writer.Write(temp.PaymentDay);
            //�x������
            writer.Write(temp.PaymentTotalDay);

        }

        /// <summary>
        ///  RsltInfo_PaymentBalanceWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RsltInfo_PaymentBalanceWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PaymentBalanceWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RsltInfo_PaymentBalanceWork GetRsltInfo_PaymentBalanceWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RsltInfo_PaymentBalanceWork temp = new RsltInfo_PaymentBalanceWork();

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
            //�O��x�����z
            temp.LastTimePayment = reader.ReadInt64();
            //����x�����z�i�ʏ�x���j
            temp.ThisTimePayNrml = reader.ReadInt64();
            //����J�z�c���i�x���v�j
            temp.ThisTimeTtlBlcPay = reader.ReadInt64();
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
            //����l�����z
            temp.ThisStckPricDis = reader.ReadInt64();
            //�d�����v�c���i�x���v�j
            temp.StockTotalPayBalance = reader.ReadInt64();
            //�d���`�[����
            temp.StockSlipCount = reader.ReadInt32();
            //�d��2��O�c���i�x���v�j
            temp.StockTtl2TmBfBlPay = reader.ReadInt64();
            //�d��3��O�c���i�x���v�j
            temp.StockTtl3TmBfBlPay = reader.ReadInt64();
            //�d���S���҃R�[�h
            temp.StockAgentCode = reader.ReadString();
            //�d���S���Җ���
            temp.StockAgentName = reader.ReadString();
            //�x������
            temp.PaymentCond = reader.ReadInt32();
            //�x�����敪����
            temp.PaymentMonthName = reader.ReadString();
            //�x����
            temp.PaymentDay = reader.ReadInt32();
            //�x������
            temp.PaymentTotalDay = reader.ReadInt32();


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
        /// <returns>RsltInfo_PaymentBalanceWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_PaymentBalanceWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RsltInfo_PaymentBalanceWork temp = GetRsltInfo_PaymentBalanceWork(reader, serInfo);
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
                    retValue = (RsltInfo_PaymentBalanceWork[])lst.ToArray(typeof(RsltInfo_PaymentBalanceWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
