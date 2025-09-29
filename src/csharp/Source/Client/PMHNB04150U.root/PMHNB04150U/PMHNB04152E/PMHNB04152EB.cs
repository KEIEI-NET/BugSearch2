using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalesReportResult
    /// <summary>
    ///                      ���㑬��\�����o���ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���㑬��\�����o���ʃN���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SalesReportResult
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>����`�[���v�i�Ŕ����j</summary>
        /// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j</remarks>
        private Int64 _salesTotalTaxExc;

        /// <summary>����ڕW���z</summary>
        private Int64 _salesTargetMoney;

        /// <summary>�B�����i������j</summary>
        private Int32 _achievementRateNet;

        /// <summary>�e��</summary>
        private Int64 _grossMargin;

        /// <summary>����ڕW�e���z</summary>
        private Int64 _salesTargetProfit;

        /// <summary>�B�����i�e���j</summary>
        private Int32 _achievementRateGross;

        /// <summary>�ғ���</summary>
        private Int32 _operationDay;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";


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

        /// public propaty name  :  SectionGuideSnm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>���[�󎚗p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  SalesTotalTaxExc
        /// <summary>����`�[���v�i�Ŕ����j�v���p�e�B</summary>
        /// <value>���㐳�����z�{����l�����z�v�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���v�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTotalTaxExc
        {
            get { return _salesTotalTaxExc; }
            set { _salesTotalTaxExc = value; }
        }

        /// public propaty name  :  SalesTargetMoney
        /// <summary>����ڕW���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney
        {
            get { return _salesTargetMoney; }
            set { _salesTargetMoney = value; }
        }

        /// public propaty name  :  AchievementRateNet 
        /// <summary>�B�����i������j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �B�����i������j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AchievementRateNet
        {
            get { return _achievementRateNet; }
            set { _achievementRateNet = value; }
        }

        /// public propaty name  :  GrossMargin
        /// <summary>�e���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossMargin
        {
            get { return _grossMargin; }
            set { _grossMargin = value; }
        }

        /// public propaty name  :  SalesTargetProfit
        /// <summary>����ڕW�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit
        {
            get { return _salesTargetProfit; }
            set { _salesTargetProfit = value; }
        }

        /// public propaty name  :  AchievementRateGross
        /// <summary>�B�����i�e���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �B�����i�e���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AchievementRateGross
        {
            get { return _achievementRateGross; }
            set { _achievementRateGross = value; }
        }

        /// public propaty name  :  OperationDay
        /// <summary>�ғ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ғ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OperationDay
        {
            get { return _operationDay; }
            set { _operationDay = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }


        /// <summary>
        /// ���㑬��\�����o���ʃN���X�R���X�g���N�^
        /// </summary>
        /// <returns>SalesReportResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesReportResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesReportResult()
        {
        }

        /// <summary>
        /// ���㑬��\�����o���ʃN���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="sectionGuideSnm">���_�K�C�h����(���[�󎚗p)</param>
        /// <param name="salesTotalTaxExc">����`�[���v�i�Ŕ����j(���㐳�����z�{����l�����z�v�i�Ŕ����j)</param>
        /// <param name="salesTargetMoney">����ڕW���z</param>
        /// <param name="achievementRateNet ">�B�����i������j</param>
        /// <param name="grossMargin">�e��</param>
        /// <param name="salesTargetProfit">����ڕW�e���z</param>
        /// <param name="achievementRateGross">�B�����i�e���j</param>
        /// <param name="operationDay">�ғ���</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <returns>SalesReportResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesReportResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesReportResult(string enterpriseCode, string sectionCode, string sectionGuideSnm, Int64 salesTotalTaxExc, Int64 salesTargetMoney, Int32 achievementRateNet, Int64 grossMargin, Int64 salesTargetProfit, Int32 achievementRateGross, Int32 operationDay, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._sectionGuideSnm = sectionGuideSnm;
            this._salesTotalTaxExc = salesTotalTaxExc;
            this._salesTargetMoney = salesTargetMoney;
            this._achievementRateNet = achievementRateNet;
            this._grossMargin = grossMargin;
            this._salesTargetProfit = salesTargetProfit;
            this._achievementRateGross = achievementRateGross;
            this._operationDay = operationDay;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// ���㑬��\�����o���ʃN���X��������
        /// </summary>
        /// <returns>SalesReportResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SalesReportResult�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesReportResult Clone()
        {
            return new SalesReportResult(this._enterpriseCode, this._sectionCode, this._sectionGuideSnm, this._salesTotalTaxExc, this._salesTargetMoney, this._achievementRateNet, this._grossMargin, this._salesTargetProfit, this._achievementRateGross, this._operationDay, this._enterpriseName);
        }

        /// <summary>
        /// ���㑬��\�����o���ʃN���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SalesReportResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesReportResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SalesReportResult target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SectionGuideSnm == target.SectionGuideSnm)
                 && (this.SalesTotalTaxExc == target.SalesTotalTaxExc)
                 && (this.SalesTargetMoney == target.SalesTargetMoney)
                 && (this.AchievementRateNet == target.AchievementRateNet)
                 && (this.GrossMargin == target.GrossMargin)
                 && (this.SalesTargetProfit == target.SalesTargetProfit)
                 && (this.AchievementRateGross == target.AchievementRateGross)
                 && (this.OperationDay == target.OperationDay)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// ���㑬��\�����o���ʃN���X��r����
        /// </summary>
        /// <param name="salesReportResult1">
        ///                    ��r����SalesReportResult�N���X�̃C���X�^���X
        /// </param>
        /// <param name="salesReportResult2">��r����SalesReportResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesReportResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SalesReportResult salesReportResult1, SalesReportResult salesReportResult2)
        {
            return ((salesReportResult1.EnterpriseCode == salesReportResult2.EnterpriseCode)
                 && (salesReportResult1.SectionCode == salesReportResult2.SectionCode)
                 && (salesReportResult1.SectionGuideSnm == salesReportResult2.SectionGuideSnm)
                 && (salesReportResult1.SalesTotalTaxExc == salesReportResult2.SalesTotalTaxExc)
                 && (salesReportResult1.SalesTargetMoney == salesReportResult2.SalesTargetMoney)
                 && (salesReportResult1.AchievementRateNet == salesReportResult2.AchievementRateNet)
                 && (salesReportResult1.GrossMargin == salesReportResult2.GrossMargin)
                 && (salesReportResult1.SalesTargetProfit == salesReportResult2.SalesTargetProfit)
                 && (salesReportResult1.AchievementRateGross == salesReportResult2.AchievementRateGross)
                 && (salesReportResult1.OperationDay == salesReportResult2.OperationDay)
                 && (salesReportResult1.EnterpriseName == salesReportResult2.EnterpriseName));
        }
        /// <summary>
        /// ���㑬��\�����o���ʃN���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SalesReportResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesReportResult�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SalesReportResult target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SectionGuideSnm != target.SectionGuideSnm) resList.Add("SectionGuideSnm");
            if (this.SalesTotalTaxExc != target.SalesTotalTaxExc) resList.Add("SalesTotalTaxExc");
            if (this.SalesTargetMoney != target.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (this.AchievementRateNet != target.AchievementRateNet) resList.Add("AchievementRateNet ");
            if (this.GrossMargin != target.GrossMargin) resList.Add("GrossMargin");
            if (this.SalesTargetProfit != target.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (this.AchievementRateGross != target.AchievementRateGross) resList.Add("AchievementRateGross");
            if (this.OperationDay != target.OperationDay) resList.Add("OperationDay");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// ���㑬��\�����o���ʃN���X��r����
        /// </summary>
        /// <param name="salesReportResult1">��r����SalesReportResult�N���X�̃C���X�^���X</param>
        /// <param name="salesReportResult2">��r����SalesReportResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesReportResult�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SalesReportResult salesReportResult1, SalesReportResult salesReportResult2)
        {
            ArrayList resList = new ArrayList();
            if (salesReportResult1.EnterpriseCode != salesReportResult2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (salesReportResult1.SectionCode != salesReportResult2.SectionCode) resList.Add("SectionCode");
            if (salesReportResult1.SectionGuideSnm != salesReportResult2.SectionGuideSnm) resList.Add("SectionGuideSnm");
            if (salesReportResult1.SalesTotalTaxExc != salesReportResult2.SalesTotalTaxExc) resList.Add("SalesTotalTaxExc");
            if (salesReportResult1.SalesTargetMoney != salesReportResult2.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (salesReportResult1.AchievementRateNet != salesReportResult2.AchievementRateNet) resList.Add("AchievementRateNet ");
            if (salesReportResult1.GrossMargin != salesReportResult2.GrossMargin) resList.Add("GrossMargin");
            if (salesReportResult1.SalesTargetProfit != salesReportResult2.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (salesReportResult1.AchievementRateGross != salesReportResult2.AchievementRateGross) resList.Add("AchievementRateGross");
            if (salesReportResult1.OperationDay != salesReportResult2.OperationDay) resList.Add("OperationDay");
            if (salesReportResult1.EnterpriseName != salesReportResult2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
