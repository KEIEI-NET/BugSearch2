using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ExtrInfo_DemandTotalWork
    /// <summary>
    ///                      ������(�ӕ�)���o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ������(�ӕ�)���o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/06  (CSharp File Generated Date)</br>
    /// <br>UpdateNote       :   11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer       :   ���O</br>
    /// <br>Date	         :   2020/04/13</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ExtrInfo_DemandTotalWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���ьv�㋒�_�R�[�h���X�g</summary>
        /// <remarks>�����^�@���z�񍀖� �S�Ўw���{""}</remarks>
        private string[] _resultsAddUpSecList;

        /// <summary>�v��N����</summary>
        /// <remarks>YYYYMMDD ���������s�Ȃ������i������j</remarks>
        private DateTime _addUpDate;

        /// <summary>�W���S���R�[�h(�J�n)</summary>
        /// <remarks>�����^</remarks>
        private string _billCollecterCdSt = "";

        /// <summary>�W���S���R�[�h(�I��)</summary>
        /// <remarks>�����^</remarks>
        private string _billCollecterCdEd = "";

        /// <summary>�ڋq�S���R�[�h(�J�n)</summary>
        /// <remarks>�����^</remarks>
        private string _customerAgentCdSt = "";

        /// <summary>�ڋq�S���R�[�h(�I��)</summary>
        /// <remarks>�����^</remarks>
        private string _customerAgentCdEd = "";

        /// <summary>�̔��G���A�R�[�h(�J�n)</summary>
        private Int32 _salesAreaCodeSt;

        /// <summary>�̔��G���A�R�[�h(�I��)</summary>
        private Int32 _salesAreaCodeEd;

        /// <summary>���Ӑ�R�[�h(�J�n)</summary>
        private Int32 _customerCodeSt;

        /// <summary>���Ӑ�R�[�h(�I��)</summary>
        private Int32 _customerCodeEd;

        /// <summary>��������</summary>
        /// <remarks>0:����(�e�{�q) 1:�e�̂ݏo�� 2:�q�̂ݏo��</remarks>
        private Int32 _dmdItems;

        /// <summary>���������s���Ӑ�t���O</summary>
        private Boolean _isBillOutputOnly;

        /// <summary>�`�[������</summary>
        /// <remarks>50:���v������,60:���א�����,70:�`�[���v������,80:�̎���</remarks>
        private Int32 _slipPrtKind;

        // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
        /// <summary>�ŕʓ���󎚋敪</summary>
        /// <remarks>0:�󎚂��� 1:�󎚂��Ȃ�</remarks>
        private Int32 _taxPrintDiv;

        /// <summary>�ŗ�1</summary>
        /// <remarks>�ŗ�1</remarks>
        private Double _taxRate1;

        /// <summary>�ŗ�2</summary>
        /// <remarks>�ŗ�2</remarks>
        private Double _taxRate2;
        // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<

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

        /// public propaty name  :  ResultsAddUpSecList
        /// <summary>���ьv�㋒�_�R�[�h���X�g�v���p�e�B</summary>
        /// <value>�����^�@���z�񍀖� �S�Ўw���{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ьv�㋒�_�R�[�h���X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] ResultsAddUpSecList
        {
            get { return _resultsAddUpSecList; }
            set { _resultsAddUpSecList = value; }
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

        /// public propaty name  :  BillCollecterCdSt
        /// <summary>�W���S���R�[�h(�J�n)�v���p�e�B</summary>
        /// <value>�����^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W���S���R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BillCollecterCdSt
        {
            get { return _billCollecterCdSt; }
            set { _billCollecterCdSt = value; }
        }

        /// public propaty name  :  BillCollecterCdEd
        /// <summary>�W���S���R�[�h(�I��)�v���p�e�B</summary>
        /// <value>�����^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W���S���R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BillCollecterCdEd
        {
            get { return _billCollecterCdEd; }
            set { _billCollecterCdEd = value; }
        }

        /// public propaty name  :  CustomerAgentCdSt
        /// <summary>�ڋq�S���R�[�h(�J�n)�v���p�e�B</summary>
        /// <value>�����^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerAgentCdSt
        {
            get { return _customerAgentCdSt; }
            set { _customerAgentCdSt = value; }
        }

        /// public propaty name  :  CustomerAgentCdEd
        /// <summary>�ڋq�S���R�[�h(�I��)�v���p�e�B</summary>
        /// <value>�����^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerAgentCdEd
        {
            get { return _customerAgentCdEd; }
            set { _customerAgentCdEd = value; }
        }

        /// public propaty name  :  SalesAreaCodeSt
        /// <summary>�̔��G���A�R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCodeSt
        {
            get { return _salesAreaCodeSt; }
            set { _salesAreaCodeSt = value; }
        }

        /// public propaty name  :  SalesAreaCodeEd
        /// <summary>�̔��G���A�R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCodeEd
        {
            get { return _salesAreaCodeEd; }
            set { _salesAreaCodeEd = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>���Ӑ�R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>���Ӑ�R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  DmdItems
        /// <summary>��������v���p�e�B</summary>
        /// <value>0:����(�e�{�q) 1:�e�̂ݏo�� 2:�q�̂ݏo��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DmdItems
        {
            get { return _dmdItems; }
            set { _dmdItems = value; }
        }

        /// public propaty name  :  IsBillOutputOnly
        /// <summary>���������s���Ӑ�t���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������s���Ӑ�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean IsBillOutputOnly
        {
            get { return _isBillOutputOnly; }
            set { _isBillOutputOnly = value; }
        }

        /// public propaty name  :  SlipPrtKind
        /// <summary>�`�[�����ʃv���p�e�B</summary>
        /// <value>50:���v������,60:���א�����,70:�`�[���v������,80:�̎���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipPrtKind
        {
            get { return _slipPrtKind; }
            set { _slipPrtKind = value; }
        }

        // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
        /// public propaty name  :  TaxPrintDiv
        /// <summary>�ŕʓ���󎚋敪</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŕʓ���󎚋敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxPrintDiv
        {
            get { return _taxPrintDiv; }
            set { _taxPrintDiv = value; }
        }

        /// public propaty name  :  TaxRate1
        /// <summary>�ŗ�1</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�1</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TaxRate1
        {
            get { return _taxRate1; }
            set { _taxRate1 = value; }
        }

        /// public propaty name  :  TaxRate2
        /// <summary>�ŗ�2</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�2</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TaxRate2
        {
            get { return _taxRate2; }
            set { _taxRate2 = value; }
        }
        // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<

        /// <summary>
        /// ������(�ӕ�)���o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ExtrInfo_DemandTotalWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandTotalWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ExtrInfo_DemandTotalWork()
        {
        }

    }

}
