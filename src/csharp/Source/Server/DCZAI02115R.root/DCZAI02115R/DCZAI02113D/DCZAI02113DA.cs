using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockManagementListCndtnWork
    /// <summary>
    ///                      �݌ɊǗ��\���o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌ɊǗ��\���o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/09/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockManagementListCndtnWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�J�n�N���x</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _st_AddUpYearMonth;

        /// <summary>�I���N���x</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _ed_AddUpYearMonth;

        /// <summary>���_�R�[�h</summary>
        /// <remarks>�i�z��j</remarks>
        private string[] _sectionCodes;

        /// <summary>�J�n�q�ɃR�[�h</summary>
        private string _st_WarehouseCode = "";

        /// <summary>�I���q�ɃR�[�h</summary>
        private string _ed_WarehouseCode = "";

        /// <summary>�J�n���i���[�J�[�R�[�h</summary>
        private Int32 _st_GoodsMakerCd;

        /// <summary>�I�����i���[�J�[�R�[�h</summary>
        private Int32 _ed_GoodsMakerCd;

        /// <summary>�J�n���i�敪�O���[�v�R�[�h</summary>
        private string _st_LargeGoodsGanreCode = "";

        /// <summary>�I�����i�敪�O���[�v�R�[�h</summary>
        private string _ed_LargeGoodsGanreCode = "";

        /// <summary>�J�n���i�敪�R�[�h</summary>
        private string _st_MediumGoodsGanreCode = "";

        /// <summary>�I�����i�敪�R�[�h</summary>
        private string _ed_MediumGoodsGanreCode = "";

        /// <summary>�J�n���i�敪�ڍ׃R�[�h</summary>
        private string _st_DetailGoodsGanreCode = "";

        /// <summary>�I�����i�敪�ڍ׃R�[�h</summary>
        private string _ed_DetailGoodsGanreCode = "";

        /// <summary>�J�n���Е��ރR�[�h</summary>
        private Int32 _st_EnterpriseGanreCode;

        /// <summary>�I�����Е��ރR�[�h</summary>
        private Int32 _ed_EnterpriseGanreCode;

        /// <summary>�J�n�a�k���i�R�[�h</summary>
        private Int32 _st_BLGoodsCode;

        /// <summary>�I���a�k���i�R�[�h</summary>
        private Int32 _ed_BLGoodsCode;

        /// <summary>���񌎈Ȍ�݌v�敪</summary>
        /// <remarks>0:�݌v�󎚂��Ȃ�, 1:�݌v�󎚂��� (�݌v=���񌎂���̗ݐύ��v)</remarks>
        private Int32 _accumulatePrintDiv;


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

        /// public propaty name  :  St_AddUpYearMonth
        /// <summary>�J�n�N���x�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�N���x�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_AddUpYearMonth
        {
            get { return _st_AddUpYearMonth; }
            set { _st_AddUpYearMonth = value; }
        }

        /// public propaty name  :  Ed_AddUpYearMonth
        /// <summary>�I���N���x�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���N���x�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_AddUpYearMonth
        {
            get { return _ed_AddUpYearMonth; }
            set { _ed_AddUpYearMonth = value; }
        }

        /// public propaty name  :  SectionCodes
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>�i�z��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  St_WarehouseCode
        /// <summary>�J�n�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_WarehouseCode
        {
            get { return _st_WarehouseCode; }
            set { _st_WarehouseCode = value; }
        }

        /// public propaty name  :  Ed_WarehouseCode
        /// <summary>�I���q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_WarehouseCode
        {
            get { return _ed_WarehouseCode; }
            set { _ed_WarehouseCode = value; }
        }

        /// public propaty name  :  St_GoodsMakerCd
        /// <summary>�J�n���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_GoodsMakerCd
        {
            get { return _st_GoodsMakerCd; }
            set { _st_GoodsMakerCd = value; }
        }

        /// public propaty name  :  Ed_GoodsMakerCd
        /// <summary>�I�����i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_GoodsMakerCd
        {
            get { return _ed_GoodsMakerCd; }
            set { _ed_GoodsMakerCd = value; }
        }

        /// public propaty name  :  St_LargeGoodsGanreCode
        /// <summary>�J�n���i�敪�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�敪�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_LargeGoodsGanreCode
        {
            get { return _st_LargeGoodsGanreCode; }
            set { _st_LargeGoodsGanreCode = value; }
        }

        /// public propaty name  :  Ed_LargeGoodsGanreCode
        /// <summary>�I�����i�敪�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�敪�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_LargeGoodsGanreCode
        {
            get { return _ed_LargeGoodsGanreCode; }
            set { _ed_LargeGoodsGanreCode = value; }
        }

        /// public propaty name  :  St_MediumGoodsGanreCode
        /// <summary>�J�n���i�敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_MediumGoodsGanreCode
        {
            get { return _st_MediumGoodsGanreCode; }
            set { _st_MediumGoodsGanreCode = value; }
        }

        /// public propaty name  :  Ed_MediumGoodsGanreCode
        /// <summary>�I�����i�敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_MediumGoodsGanreCode
        {
            get { return _ed_MediumGoodsGanreCode; }
            set { _ed_MediumGoodsGanreCode = value; }
        }

        /// public propaty name  :  St_DetailGoodsGanreCode
        /// <summary>�J�n���i�敪�ڍ׃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�敪�ڍ׃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_DetailGoodsGanreCode
        {
            get { return _st_DetailGoodsGanreCode; }
            set { _st_DetailGoodsGanreCode = value; }
        }

        /// public propaty name  :  Ed_DetailGoodsGanreCode
        /// <summary>�I�����i�敪�ڍ׃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�敪�ڍ׃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_DetailGoodsGanreCode
        {
            get { return _ed_DetailGoodsGanreCode; }
            set { _ed_DetailGoodsGanreCode = value; }
        }

        /// public propaty name  :  St_EnterpriseGanreCode
        /// <summary>�J�n���Е��ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Е��ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_EnterpriseGanreCode
        {
            get { return _st_EnterpriseGanreCode; }
            set { _st_EnterpriseGanreCode = value; }
        }

        /// public propaty name  :  Ed_EnterpriseGanreCode
        /// <summary>�I�����Е��ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Е��ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_EnterpriseGanreCode
        {
            get { return _ed_EnterpriseGanreCode; }
            set { _ed_EnterpriseGanreCode = value; }
        }

        /// public propaty name  :  St_BLGoodsCode
        /// <summary>�J�n�a�k���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�a�k���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_BLGoodsCode
        {
            get { return _st_BLGoodsCode; }
            set { _st_BLGoodsCode = value; }
        }

        /// public propaty name  :  Ed_BLGoodsCode
        /// <summary>�I���a�k���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���a�k���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_BLGoodsCode
        {
            get { return _ed_BLGoodsCode; }
            set { _ed_BLGoodsCode = value; }
        }

        /// public propaty name  :  AccumulatePrintDiv
        /// <summary>���񌎈Ȍ�݌v�敪�v���p�e�B</summary>
        /// <value>0:�݌v�󎚂��Ȃ�, 1:�݌v�󎚂��� (�݌v=���񌎂���̗ݐύ��v)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񌎈Ȍ�݌v�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AccumulatePrintDiv
        {
            get { return _accumulatePrintDiv; }
            set { _accumulatePrintDiv = value; }
        }


        /// <summary>
        /// �݌ɊǗ��\���o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockManagementListCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockManagementListCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockManagementListCndtnWork()
        {
        }

    }
}




