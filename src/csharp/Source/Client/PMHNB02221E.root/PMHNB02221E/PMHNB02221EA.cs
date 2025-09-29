//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����s�����m�F�\
// �v���O�����T�v   : ����s�����m�F�\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{

    /// <summary>
    /// ����s�����m�F�\���o�����f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note             :   ����s�����m�F�\���o�����f�[�^�N���X�̃C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer       :   ���痈</br>
    /// <br>Date             :   2009.04.13</br>
    /// </remarks>
    public class SalesStockInfoMainCndtn
    {

        #region �� Public Const
        /// <summary>���� ���t�t�H�[�}�b�g yyyyMMdd </summary>
        public const string ct_DateFomat = "yyyyMMdd";
        /// <summary>���� ���t�t�H�[�}�b�g yyyy/MM/dd</summary>
        public const string ct_DateFomatWithLine = "yyyy/MM/dd";
        /// <summary>���� TOP</summary>
        public const string ct_Top = "TOP";
        /// <summary>���� END</summary>
        public const string ct_End = "END";
        #endregion

        #region �� Private Member
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>���_�I�v�V���������敪</summary>
        private bool _isOptSection;

        /// <summary>�{�Ћ@�\�v���p�e�B</summary>
        private bool _isMainOfficeFunc;

        /// <summary>�I���v�㋒�_�R�[�h</summary>
        private string[] _collectAddupSecCodeList;


        /// <summary>�Ώ۔N��</summary>
        private DateTime _yearMonth;

        /// <summary>�O���������</summary>
        private DateTime _prevTotalDay;

        /// <summary>�����������</summary>
        private DateTime _currentTotalDay;


        #endregion �� Private Member

        #region �� Public Property
        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ��ƃR�[�h�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���痈</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  IsOptSection
        /// <summary>���_�I�v�V���������敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ���_�I�v�V���������敪�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���痈</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// public propaty name  :  IsMainOfficeFunc
        /// <summary>�{�Ћ@�\�v���p�e�B�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �{�Ћ@�\�v���p�e�B�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���痈</br>
        /// </remarks>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }




        /// public propaty name  :  St_ShipmentFixDay
        /// <summary>�Ώ۔N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �Ώ۔N���v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���痈</br> 
        /// </remarks>
        public DateTime YearMonth
        {
            get { return _yearMonth; }
            set { _yearMonth = value; }
        }

        /// public propaty name  :  PrevTotalDay
        /// <summary>�O����������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �O����������v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���痈</br> 
        /// </remarks>
        public DateTime PrevTotalDay
        {
            get { return _prevTotalDay; }
            set { _prevTotalDay = value; }
        }

        /// public propaty name  :  CurrentTotalDay
        /// <summary>������������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ������������v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���痈</br> 
        /// </remarks>
        public DateTime CurrentTotalDay
        {
            get { return _currentTotalDay; }
            set { _currentTotalDay = value; }
        }

        /// public propaty name  :  IsSelectAllSection
        /// <summary>�S�БI���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �S�БI���v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���痈</br>
        /// </remarks>
        public bool IsSelectAllSection
        {
            get
            {
                bool isSelAlSec = false;
                if ((this._collectAddupSecCodeList.Length == 1) && (this._collectAddupSecCodeList[0].CompareTo("0") == 0))
                {
                    isSelAlSec = true;
                }
                return isSelAlSec;
            }
        }

        /// public propaty name  :  CollectAddupSecCodeList
        /// <summary>�I���v�㋒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �I���v�㋒�_�R�[�h�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���痈</br>
        /// </remarks>
        public string[] CollectAddupSecCodeList
        {
            get { return _collectAddupSecCodeList; }
            set { _collectAddupSecCodeList = value; }
        }


        #endregion �� Public Property


        #region �� Constructor
        /// <summary>
        /// ���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PaymentMainCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentMainCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ���痈</br>
        /// </remarks>
        public SalesStockInfoMainCndtn()
        {
            this._collectAddupSecCodeList = new string[0];	// �v�㋒�_�R�[�h���X�g 
        }
        #endregion �� Constructor

    }
}
