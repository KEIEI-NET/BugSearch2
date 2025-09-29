using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ExtrInfo_PastYearStatisticsWork
    /// <summary>
    ///                      �ߔN�x���v�\���o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ߔN�x���v�\���o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/12/03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ExtrInfo_PastYearStatisticsWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�o�͑Ώۋ��_</summary>
        /// <remarks>null�̏ꍇ�͑S���_</remarks>
        private String[] _secCodeList;

        /// <summary>�W�v���@</summary>
        /// <remarks>True:�S�ЏW�v False:���_�ʏW�v</remarks>
        private Boolean _totalWay;

        /// <summary>���[�^�C�v</summary>
        /// <remarks>0:���_�� 1:���Ӑ��</remarks>
        private Int32 _listType;

        /// <summary>���z�P��</summary>
        /// <remarks>0:��~�P�� 1:��~�P��</remarks>
        private Int32 _moneyUnit;

        /// <summary>�J�n�Ώ۔N��</summary>
        /// <remarks>YYYY</remarks>
        private Int32 _st_AddUpYear;

        /// <summary>�I���Ώ۔N��</summary>
        /// <remarks>YYYY</remarks>
        private Int32 _ed_AddUpYear;

        /// <summary>�J�n���Ӑ�R�[�h</summary>
        /// <remarks>���Ӑ�ʂŎg�p</remarks>
        private Int32 _st_CustomerCode;

        /// <summary>�I�����Ӑ�R�[�h</summary>
        /// <remarks>���Ӑ�ʂŎg�p</remarks>
        private Int32 _ed_CustomerCode;


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

        /// public propaty name  :  SecCodeList
        /// <summary>�o�͑Ώۋ��_�v���p�e�B</summary>
        /// <value>null�̏ꍇ�͑S���_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͑Ώۋ��_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public String[] SecCodeList
        {
            get { return _secCodeList; }
            set { _secCodeList = value; }
        }

        /// public propaty name  :  TotalWay
        /// <summary>�W�v���@�v���p�e�B</summary>
        /// <value>True:�S�ЏW�v False:���_�ʏW�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�v���@�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean TotalWay
        {
            get { return _totalWay; }
            set { _totalWay = value; }
        }

        /// public propaty name  :  ListType
        /// <summary>���[�^�C�v�v���p�e�B</summary>
        /// <value>0:���_�� 1:���Ӑ��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ListType
        {
            get { return _listType; }
            set { _listType = value; }
        }

        /// public propaty name  :  MoneyUnit
        /// <summary>���z�P�ʃv���p�e�B</summary>
        /// <value>0:��~�P�� 1:��~�P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�P�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyUnit
        {
            get { return _moneyUnit; }
            set { _moneyUnit = value; }
        }

        /// public propaty name  :  St_AddUpYear
        /// <summary>�J�n�Ώ۔N���v���p�e�B</summary>
        /// <value>YYYY</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�Ώ۔N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_AddUpYear
        {
            get { return _st_AddUpYear; }
            set { _st_AddUpYear = value; }
        }

        /// public propaty name  :  Ed_AddUpYear
        /// <summary>�I���Ώ۔N���v���p�e�B</summary>
        /// <value>YYYY</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���Ώ۔N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_AddUpYear
        {
            get { return _ed_AddUpYear; }
            set { _ed_AddUpYear = value; }
        }

        /// public propaty name  :  St_CustomerCode
        /// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>���Ӑ�ʂŎg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_CustomerCode; }
            set { _st_CustomerCode = value; }
        }

        /// public propaty name  :  Ed_CustomerCode
        /// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>���Ӑ�ʂŎg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_CustomerCode; }
            set { _ed_CustomerCode = value; }
        }


        /// <summary>
        /// �ߔN�x���v�\���o�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ExtrInfo_PastYearStatisticsWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ExtrInfo_PastYearStatisticsWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ExtrInfo_PastYearStatisticsWork()
        {
        }

    }
}
