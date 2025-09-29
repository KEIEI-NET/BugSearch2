using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesDayMonthReportResultWork
    /// <summary>
    ///                      ������񌎕񒊏o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ������񌎕񒊏o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      : 2012/05/22 ������</br>
    /// <br>�Ǘ��ԍ�         : 10801804-00 06/27�z�M��</br>
    /// <br>                   Redmine#29898   ������񌎕� �i�����Z�o���ɉc�Ɠ����Q�Ƃ��Ă��Ȃ��p�^�[�������݂���</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesDayMonthReportResultWork
    {
        /// <summary>�R�[�h</summary>
        /// <remarks>XXX�R�[�h(�S����/�󒍎�/���s��/�n��/�Ǝ�/�̔��敪)</remarks>
        private string _code = "";

        /// <summary>����</summary>
        /// <remarks>XXX����(�S����/�󒍎�/���s��/�n��/�Ǝ�/�̔��敪)</remarks>
        private string _name = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_����</summary>
        /// <remarks>���_�K�C�h����</remarks>
        private string _companyName1 = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        // --------------- ADD START 2012/05/22 Redmine#29898 ������-------->>>>
        /// <summary>�Ǘ����_�R�[�h</summary>
        private string _sectionMngCode = "";
        // --------------- ADD END 2012/05/22 Redmine#29898 ������--------<<<<

        /// <summary>���Ӑ於��</summary>
        /// <remarks>���Ӑ旪��</remarks>
        private string _customerSnm = "";

        /// <summary>���ԓ`�[����</summary>
        private Int32 _termSalesSlipCount;

        /// <summary>���Ԕ��㍇�v</summary>
        /// <remarks>�`�[�敪=0:���� �̔���`�[���v�i�Ŕ����j</remarks>
        private Int64 _termSalesTotalTaxExc;

        /// <summary>���ԕԕi���v</summary>
        /// <remarks>�`�[�敪=1:�ԕi �̔���`�[���v�i�Ŕ����j</remarks>
        private Int64 _termSalesBackTotalTaxExc;

        /// <summary>���Ԓl�����v</summary>
        /// <remarks>����l�����z�v�i�Ŕ����j���`�[�敪�֌W�Ȃ�</remarks>
        private Int64 _termSalesDisTtlTaxExc;

        /// <summary>���Ԍ������z�v</summary>
        private Int64 _termTotalCost;

        /// <summary>���Ԕ���ڕW</summary>
        private Int64 _termSalesTargetMoney;

        /// <summary>���ԑe���ڕW</summary>
        private Int64 _termSalesTargetProfit;

        /// <summary>�����`�[����</summary>
        private Int32 _monthSalesSlipCount;

        /// <summary>�������㍇�v</summary>
        /// <remarks>�`�[�敪=0:���� �̔���`�[���v�i�Ŕ����j</remarks>
        private Int64 _monthSalesTotalTaxExc;

        /// <summary>�����ԕi���v</summary>
        /// <remarks>�`�[�敪=1:�ԕi �̔���`�[���v�i�Ŕ����j</remarks>
        private Int64 _monthSalesBackTotalTaxExc;

        /// <summary>�����l�����v</summary>
        /// <remarks>����l�����z�v�i�Ŕ����j���`�[�敪�֌W�Ȃ�</remarks>
        private Int64 _monthSalesDisTtlTaxExc;

        /// <summary>�����������z�v</summary>
        private Int64 _monthTotalCost;

        /// <summary>��������ڕW</summary>
        private Int64 _monthSalesTargetMoney;

        /// <summary>�����e���ڕW</summary>
        private Int64 _monthSalesTargetProfit;


        /// public propaty name  :  Code
        /// <summary>�R�[�h�v���p�e�B</summary>
        /// <value>XXX�R�[�h(�S����/�󒍎�/���s��/�n��/�Ǝ�/�̔��敪)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        /// public propaty name  :  Name
        /// <summary>���̃v���p�e�B</summary>
        /// <value>XXX����(�S����/�󒍎�/���s��/�n��/�Ǝ�/�̔��敪)</value>
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

        /// public propaty name  :  CompanyName1
        /// <summary>���_���̃v���p�e�B</summary>
        /// <value>���_�K�C�h����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyName1
        {
            get { return _companyName1; }
            set { _companyName1 = value; }
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

        // --------------- ADD START 2012/05/22 Redmine#29898 ������-------->>>>
        /// public propaty name  :  SectionMngCode
        /// <summary>�Ǘ����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ������</br>
        /// </remarks>
        public string SectionMngCode
        {
            get { return _sectionMngCode; }
            set { _sectionMngCode = value; }
        }
        // --------------- ADD END 2012/05/22 Redmine#29898 ������--------<<<<

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ於�̃v���p�e�B</summary>
        /// <value>���Ӑ旪��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  TermSalesSlipCount
        /// <summary>���ԓ`�[�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ԓ`�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TermSalesSlipCount
        {
            get { return _termSalesSlipCount; }
            set { _termSalesSlipCount = value; }
        }

        /// public propaty name  :  TermSalesTotalTaxExc
        /// <summary>���Ԕ��㍇�v�v���p�e�B</summary>
        /// <value>�`�[�敪=0:���� �̔���`�[���v�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ԕ��㍇�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TermSalesTotalTaxExc
        {
            get { return _termSalesTotalTaxExc; }
            set { _termSalesTotalTaxExc = value; }
        }

        /// public propaty name  :  TermSalesBackTotalTaxExc
        /// <summary>���ԕԕi���v�v���p�e�B</summary>
        /// <value>�`�[�敪=1:�ԕi �̔���`�[���v�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ԕԕi���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TermSalesBackTotalTaxExc
        {
            get { return _termSalesBackTotalTaxExc; }
            set { _termSalesBackTotalTaxExc = value; }
        }

        /// public propaty name  :  TermSalesDisTtlTaxExc
        /// <summary>���Ԓl�����v�v���p�e�B</summary>
        /// <value>����l�����z�v�i�Ŕ����j���`�[�敪�֌W�Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ԓl�����v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TermSalesDisTtlTaxExc
        {
            get { return _termSalesDisTtlTaxExc; }
            set { _termSalesDisTtlTaxExc = value; }
        }

        /// public propaty name  :  TermTotalCost
        /// <summary>���Ԍ������z�v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ԍ������z�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TermTotalCost
        {
            get { return _termTotalCost; }
            set { _termTotalCost = value; }
        }

        /// public propaty name  :  TermSalesTargetMoney
        /// <summary>���Ԕ���ڕW�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ԕ���ڕW�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TermSalesTargetMoney
        {
            get { return _termSalesTargetMoney; }
            set { _termSalesTargetMoney = value; }
        }

        /// public propaty name  :  TermSalesTargetProfit
        /// <summary>���ԑe���ڕW�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ԑe���ڕW�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TermSalesTargetProfit
        {
            get { return _termSalesTargetProfit; }
            set { _termSalesTargetProfit = value; }
        }

        /// public propaty name  :  MonthSalesSlipCount
        /// <summary>�����`�[�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MonthSalesSlipCount
        {
            get { return _monthSalesSlipCount; }
            set { _monthSalesSlipCount = value; }
        }

        /// public propaty name  :  MonthSalesTotalTaxExc
        /// <summary>�������㍇�v�v���p�e�B</summary>
        /// <value>�`�[�敪=0:���� �̔���`�[���v�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������㍇�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthSalesTotalTaxExc
        {
            get { return _monthSalesTotalTaxExc; }
            set { _monthSalesTotalTaxExc = value; }
        }

        /// public propaty name  :  MonthSalesBackTotalTaxExc
        /// <summary>�����ԕi���v�v���p�e�B</summary>
        /// <value>�`�[�敪=1:�ԕi �̔���`�[���v�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ԕi���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthSalesBackTotalTaxExc
        {
            get { return _monthSalesBackTotalTaxExc; }
            set { _monthSalesBackTotalTaxExc = value; }
        }

        /// public propaty name  :  MonthSalesDisTtlTaxExc
        /// <summary>�����l�����v�v���p�e�B</summary>
        /// <value>����l�����z�v�i�Ŕ����j���`�[�敪�֌W�Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����l�����v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthSalesDisTtlTaxExc
        {
            get { return _monthSalesDisTtlTaxExc; }
            set { _monthSalesDisTtlTaxExc = value; }
        }

        /// public propaty name  :  MonthTotalCost
        /// <summary>�����������z�v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������z�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthTotalCost
        {
            get { return _monthTotalCost; }
            set { _monthTotalCost = value; }
        }

        /// public propaty name  :  MonthSalesTargetMoney
        /// <summary>��������ڕW�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������ڕW�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthSalesTargetMoney
        {
            get { return _monthSalesTargetMoney; }
            set { _monthSalesTargetMoney = value; }
        }

        /// public propaty name  :  MonthSalesTargetProfit
        /// <summary>�����e���ڕW�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����e���ڕW�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthSalesTargetProfit
        {
            get { return _monthSalesTargetProfit; }
            set { _monthSalesTargetProfit = value; }
        }


        /// <summary>
        /// ������񌎕񒊏o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalesDayMonthReportResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesDayMonthReportResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesDayMonthReportResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SalesDayMonthReportResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SalesDayMonthReportResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// <br>�Ǘ��ԍ�         : 10801804-00 06/27�z�M��</br>
    /// <br>                   Redmine#29898   ������񌎕� �i�����Z�o���ɉc�Ɠ����Q�Ƃ��Ă��Ȃ��p�^�[�������݂���</br>
    /// </remarks>
    public class SalesDayMonthReportResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesDayMonthReportResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      : 2012/05/22 ������</br>
        /// <br>�Ǘ��ԍ�         : 10801804-00 06/27�z�M��</br>
        /// <br>                   Redmine#29898   ������񌎕� �i�����Z�o���ɉc�Ɠ����Q�Ƃ��Ă��Ȃ��p�^�[�������݂���</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesDayMonthReportResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesDayMonthReportResultWork || graph is ArrayList || graph is SalesDayMonthReportResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SalesDayMonthReportResultWork).FullName));

            if (graph != null && graph is SalesDayMonthReportResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesDayMonthReportResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesDayMonthReportResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesDayMonthReportResultWork[])graph).Length;
            }
            else if (graph is SalesDayMonthReportResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //Code
            //����
            serInfo.MemberInfo.Add(typeof(string)); //Name
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            // --------------- ADD START 2012/05/22 Redmine#29898 ������-------->>>>
            //�Ǘ����_�R�[�h
            serInfo.MemberInfo.Add(typeof(string));//SectionMngCode
            // --------------- ADD END 2012/05/22 Redmine#29898 ������--------<<<<
            //���_����
            serInfo.MemberInfo.Add(typeof(string)); //CompanyName1
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ於��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //���ԓ`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //TermSalesSlipCount
            //���Ԕ��㍇�v
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTotalTaxExc
            //���ԕԕi���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesBackTotalTaxExc
            //���Ԓl�����v
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesDisTtlTaxExc
            //���Ԍ������z�v
            serInfo.MemberInfo.Add(typeof(Int64)); //TermTotalCost
            //���Ԕ���ڕW
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTargetMoney
            //���ԑe���ڕW
            serInfo.MemberInfo.Add(typeof(Int64)); //TermSalesTargetProfit
            //�����`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //MonthSalesSlipCount
            //�������㍇�v
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesTotalTaxExc
            //�����ԕi���v
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesBackTotalTaxExc
            //�����l�����v
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesDisTtlTaxExc
            //�����������z�v
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthTotalCost
            //��������ڕW
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesTargetMoney
            //�����e���ڕW
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthSalesTargetProfit


            serInfo.Serialize(writer, serInfo);
            if (graph is SalesDayMonthReportResultWork)
            {
                SalesDayMonthReportResultWork temp = (SalesDayMonthReportResultWork)graph;

                SetSalesDayMonthReportResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesDayMonthReportResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesDayMonthReportResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesDayMonthReportResultWork temp in lst)
                {
                    SetSalesDayMonthReportResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesDayMonthReportResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        // private const int currentMemberCount = 20;//DEL 2012/05/22 ������ Redmine#29898
           private const int currentMemberCount = 21;//ADD 2012/05/22 ������ Redmine#29898
        /// <summary>
        ///  SalesDayMonthReportResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesDayMonthReportResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>�Ǘ��ԍ�         : 10801804-00 06/27�z�M��</br>
        /// <br>                   Redmine#29898   ������񌎕� �i�����Z�o���ɉc�Ɠ����Q�Ƃ��Ă��Ȃ��p�^�[�������݂���</br>
        /// </remarks>
        private void SetSalesDayMonthReportResultWork(System.IO.BinaryWriter writer, SalesDayMonthReportResultWork temp)
        {
            //�R�[�h
            writer.Write(temp.Code);
            //����
            writer.Write(temp.Name);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            // --------------- ADD START 2012/05/22 Redmine#29898 ������-------->>>>
            //�Ǘ����_�R�[�h
            writer.Write(temp.SectionMngCode);
            // --------------- ADD END 2012/05/22 Redmine#29898 ������--------<<<<
            //���_����
            writer.Write(temp.CompanyName1);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ於��
            writer.Write(temp.CustomerSnm);
            //���ԓ`�[����
            writer.Write(temp.TermSalesSlipCount);
            //���Ԕ��㍇�v
            writer.Write(temp.TermSalesTotalTaxExc);
            //���ԕԕi���v
            writer.Write(temp.TermSalesBackTotalTaxExc);
            //���Ԓl�����v
            writer.Write(temp.TermSalesDisTtlTaxExc);
            //���Ԍ������z�v
            writer.Write(temp.TermTotalCost);
            //���Ԕ���ڕW
            writer.Write(temp.TermSalesTargetMoney);
            //���ԑe���ڕW
            writer.Write(temp.TermSalesTargetProfit);
            //�����`�[����
            writer.Write(temp.MonthSalesSlipCount);
            //�������㍇�v
            writer.Write(temp.MonthSalesTotalTaxExc);
            //�����ԕi���v
            writer.Write(temp.MonthSalesBackTotalTaxExc);
            //�����l�����v
            writer.Write(temp.MonthSalesDisTtlTaxExc);
            //�����������z�v
            writer.Write(temp.MonthTotalCost);
            //��������ڕW
            writer.Write(temp.MonthSalesTargetMoney);
            //�����e���ڕW
            writer.Write(temp.MonthSalesTargetProfit);

        }

        /// <summary>
        ///  SalesDayMonthReportResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SalesDayMonthReportResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesDayMonthReportResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>�Ǘ��ԍ�         : 10801804-00 06/27�z�M��</br>
        /// <br>                   Redmine#29898   ������񌎕� �i�����Z�o���ɉc�Ɠ����Q�Ƃ��Ă��Ȃ��p�^�[�������݂���</br>
        /// </remarks>
        private SalesDayMonthReportResultWork GetSalesDayMonthReportResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SalesDayMonthReportResultWork temp = new SalesDayMonthReportResultWork();

            //�R�[�h
            temp.Code = reader.ReadString();
            //����
            temp.Name = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            // --------------- ADD START 2012/05/22 Redmine#29898 ������-------->>>>
            //�Ǘ����_�R�[�h
            temp.SectionMngCode = reader.ReadString();
            // --------------- ADD END 2012/05/22 Redmine#29898 ������--------<<<<
            //���_����
            temp.CompanyName1 = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ於��
            temp.CustomerSnm = reader.ReadString();
            //���ԓ`�[����
            temp.TermSalesSlipCount = reader.ReadInt32();
            //���Ԕ��㍇�v
            temp.TermSalesTotalTaxExc = reader.ReadInt64();
            //���ԕԕi���v
            temp.TermSalesBackTotalTaxExc = reader.ReadInt64();
            //���Ԓl�����v
            temp.TermSalesDisTtlTaxExc = reader.ReadInt64();
            //���Ԍ������z�v
            temp.TermTotalCost = reader.ReadInt64();
            //���Ԕ���ڕW
            temp.TermSalesTargetMoney = reader.ReadInt64();
            //���ԑe���ڕW
            temp.TermSalesTargetProfit = reader.ReadInt64();
            //�����`�[����
            temp.MonthSalesSlipCount = reader.ReadInt32();
            //�������㍇�v
            temp.MonthSalesTotalTaxExc = reader.ReadInt64();
            //�����ԕi���v
            temp.MonthSalesBackTotalTaxExc = reader.ReadInt64();
            //�����l�����v
            temp.MonthSalesDisTtlTaxExc = reader.ReadInt64();
            //�����������z�v
            temp.MonthTotalCost = reader.ReadInt64();
            //��������ڕW
            temp.MonthSalesTargetMoney = reader.ReadInt64();
            //�����e���ڕW
            temp.MonthSalesTargetProfit = reader.ReadInt64();


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
        /// <returns>SalesDayMonthReportResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesDayMonthReportResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesDayMonthReportResultWork temp = GetSalesDayMonthReportResultWork(reader, serInfo);
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
                    retValue = (SalesDayMonthReportResultWork[])lst.ToArray(typeof(SalesDayMonthReportResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
