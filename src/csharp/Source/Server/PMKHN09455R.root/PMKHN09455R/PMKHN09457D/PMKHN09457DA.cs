//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �ڕW�����ݒ�DB����N���X
//                  :   PMKHN09457D.DLL
// Name Space       :   Broadleaf.Application.Remoting.ParamData
// Programmer       :   杍^
// Date             :   2009.3.30
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ObjAutoSetWork
    /// <summary>
    ///                      �ڕW�����ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ڕW�����ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/3/13</br>
    /// <br>Genarated Date   :   2009/04/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ObjAutoSetWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _secCode = "";

        /// <summary>���_DRP</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Int32 _secDrp;

        /// <summary>����DRP</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private Int32 _buMonDrp;

        /// <summary>���Ӑ�DRP</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private Int32 _customerDrp;

        /// <summary>�S����DRP</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _tantosyaDrp;

        /// <summary>�󒍎�DRP</summary>
        /// <remarks>0:�f�[�^�@1:�}�X�^</remarks>
        private Int32 _receOrdDrp;

        /// <summary>���s��DRP</summary>
        /// <remarks>0:���M 1:��M</remarks>
        private Int32 _publisherDrp;

        /// <summary>�n��DRP</summary>
        private Int32 _districtDrp;

        /// <summary>�Ǝ�DRP</summary>
        /// <remarks>�ŏI���M��</remarks>
        private Int32 _typeBusinessDrp;

        /// <summary>�̔��敪DRP</summary>
        /// <remarks>�t�h�p�i�����̃R���{�{�b�N�X���j</remarks>
        private Int32 _salesDivisionDrp;

        /// <summary>���i�敪DRP</summary>
        private Int32 _comDivisionDrp;

        /// <summary>�Ώۋ��zDRP</summary>
        private Int32 _objMoneyDrp;

        /// <summary>�Ώۊ�DRP</summary>
        private Int32 _objPeriodDrp;

        /// <summary>�䗦DRP</summary>
        private Int32 _ratioDrp;

        /// <summary>�P��DRP</summary>
        private Int32 _unitDrp;

        /// <summary>�[������DRP</summary>
        private Int32 _fractionProcDrp;

        /// <summary>����ڕW</summary>
        private Int32 _salesTarget;

        /// <summary>�e���ڕW</summary>
        private Int32 _groMarginTarget;

        /// <summary>���ʖڕW</summary>
        private Int32 _amountTarget;

        /// <summary>�ߋ�</summary>
        private Int32 _past;


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

        /// public propaty name  :  SecCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SecCode
        {
            get { return _secCode; }
            set { _secCode = value; }
        }

        /// public propaty name  :  SecDrp
        /// <summary>���_DRP�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_DRP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SecDrp
        {
            get { return _secDrp; }
            set { _secDrp = value; }
        }

        /// public propaty name  :  BuMonDrp
        /// <summary>����DRP�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����DRP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BuMonDrp
        {
            get { return _buMonDrp; }
            set { _buMonDrp = value; }
        }

        /// public propaty name  :  CustomerDrp
        /// <summary>���Ӑ�DRP�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�DRP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerDrp
        {
            get { return _customerDrp; }
            set { _customerDrp = value; }
        }

        /// public propaty name  :  TantosyaDrp
        /// <summary>�S����DRP�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S����DRP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TantosyaDrp
        {
            get { return _tantosyaDrp; }
            set { _tantosyaDrp = value; }
        }

        /// public propaty name  :  ReceOrdDrp
        /// <summary>�󒍎�DRP�v���p�e�B</summary>
        /// <value>0:�f�[�^�@1:�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍎�DRP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReceOrdDrp
        {
            get { return _receOrdDrp; }
            set { _receOrdDrp = value; }
        }

        /// public propaty name  :  PublisherDrp
        /// <summary>���s��DRP�v���p�e�B</summary>
        /// <value>0:���M 1:��M</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s��DRP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PublisherDrp
        {
            get { return _publisherDrp; }
            set { _publisherDrp = value; }
        }

        /// public propaty name  :  DistrictDrp
        /// <summary>�n��DRP�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n��DRP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DistrictDrp
        {
            get { return _districtDrp; }
            set { _districtDrp = value; }
        }

        /// public propaty name  :  TypeBusinessDrp
        /// <summary>�Ǝ�DRP�v���p�e�B</summary>
        /// <value>�ŏI���M��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�DRP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TypeBusinessDrp
        {
            get { return _typeBusinessDrp; }
            set { _typeBusinessDrp = value; }
        }

        /// public propaty name  :  SalesDivisionDrp
        /// <summary>�̔��敪DRP�v���p�e�B</summary>
        /// <value>�t�h�p�i�����̃R���{�{�b�N�X���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪DRP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesDivisionDrp
        {
            get { return _salesDivisionDrp; }
            set { _salesDivisionDrp = value; }
        }

        /// public propaty name  :  ComDivisionDrp
        /// <summary>���i�敪DRP�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪DRP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ComDivisionDrp
        {
            get { return _comDivisionDrp; }
            set { _comDivisionDrp = value; }
        }

        /// public propaty name  :  ObjMoneyDrp
        /// <summary>�Ώۋ��zDRP�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ώۋ��zDRP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ObjMoneyDrp
        {
            get { return _objMoneyDrp; }
            set { _objMoneyDrp = value; }
        }

        /// public propaty name  :  ObjPeriodDrp
        /// <summary>�Ώۊ�DRP�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ώۊ�DRP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ObjPeriodDrp
        {
            get { return _objPeriodDrp; }
            set { _objPeriodDrp = value; }
        }

        /// public propaty name  :  RatioDrp
        /// <summary>�䗦DRP�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �䗦DRP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RatioDrp
        {
            get { return _ratioDrp; }
            set { _ratioDrp = value; }
        }

        /// public propaty name  :  UnitDrp
        /// <summary>�P��DRP�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P��DRP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnitDrp
        {
            get { return _unitDrp; }
            set { _unitDrp = value; }
        }

        /// public propaty name  :  FractionProcDrp
        /// <summary>�[������DRP�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[������DRP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FractionProcDrp
        {
            get { return _fractionProcDrp; }
            set { _fractionProcDrp = value; }
        }

        /// public propaty name  :  SalesTarget
        /// <summary>����ڕW�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesTarget
        {
            get { return _salesTarget; }
            set { _salesTarget = value; }
        }

        /// public propaty name  :  GroMarginTarget
        /// <summary>�e���ڕW�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���ڕW�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GroMarginTarget
        {
            get { return _groMarginTarget; }
            set { _groMarginTarget = value; }
        }

        /// public propaty name  :  AmountTarget
        /// <summary>���ʖڕW�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʖڕW�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AmountTarget
        {
            get { return _amountTarget; }
            set { _amountTarget = value; }
        }

        /// public propaty name  :  Past
        /// <summary>�ߋ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ߋ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Past
        {
            get { return _past; }
            set { _past = value; }
        }


        /// <summary>
        /// �ڕW�����ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ObjAutoSetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ObjAutoSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ObjAutoSetWork()
        {
        }

    }
}
