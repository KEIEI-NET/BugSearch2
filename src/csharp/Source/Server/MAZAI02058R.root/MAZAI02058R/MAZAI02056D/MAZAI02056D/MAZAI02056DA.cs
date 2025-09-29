using System;
using System.Collections;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockAdjustCndtnWork
    /// <summary>
    ///                      �݌Ɏd���m�F�\���o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌Ɏd���m�F�\���o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/06/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockAdjustCndtnWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
        private string[] _sectionCodes;

        /// <summary>�J�n�q�ɃR�[�h</summary>
        private string _st_WarehouseCode = "";

        /// <summary>�I���q�ɃR�[�h</summary>
        private string _ed_WarehouseCode = "";

        /// <summary>�󕥌��`�[�敪</summary>
        /// <remarks>10:�d��,11:���,12:��v��,13:�݌Ɏd��20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,42:�}�X�^�����e,50:�I��,60:�g��,61:����,70:��[����,71:��[�o��,null:�S��</remarks>
        private Int32[] _acPaySlipCds;

        /// <summary>�󕥌�����敪</summary>
        /// <remarks>10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����,30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,42:�}�X�^�����e,90:���</remarks>
        private Int32 _acPayTransCd;

        /// <summary>�J�n�������t</summary>
        private DateTime _st_AdjustDate;

        /// <summary>�I���������t</summary>
        private DateTime _ed_AdjustDate;

        /// <summary>�J�n���͓��t</summary>
        private DateTime _st_InputDay;

        /// <summary>�I�����͓��t</summary>
        private DateTime _ed_InputDay;

        /// <summary>�J�n���͒S���҃R�[�h</summary>
        private string _st_InputAgenCd = "";

        /// <summary>�I�����͒S���҃R�[�h</summary>
        private string _ed_InputAgenCd = "";

        /// <summary>�݌ɋ敪</summary>
        /// <remarks>0:���ЁA1:���</remarks>
        private Int32 _stockDiv;


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

        /// public propaty name  :  SectionCodes
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>(�z��)�@�S�Ўw���{""}</value>
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

        /// public propaty name  :  AcPaySlipCd
        /// <summary>�󕥌��`�[�敪�v���p�e�B</summary>
        /// <value>10:�d��,11:���,12:��v��,13:�݌Ɏd��20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,42:�}�X�^�����e,50:�I��,60:�g��,61:����,70:��[����,71:��[�o��,null:�S��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󕥌��`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] AcPaySlipCds
        {
            get { return _acPaySlipCds; }
            set { _acPaySlipCds = value; }
        }

        /// public propaty name  :  AcPayTransCd
        /// <summary>�󕥌�����敪�v���p�e�B</summary>
        /// <value>10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����,30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,42:�}�X�^�����e,90:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󕥌�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcPayTransCd
        {
            get { return _acPayTransCd; }
            set { _acPayTransCd = value; }
        }

        /// public propaty name  :  St_AdjustDate
        /// <summary>�J�n�������t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_AdjustDate
        {
            get { return _st_AdjustDate; }
            set { _st_AdjustDate = value; }
        }

        /// public propaty name  :  Ed_AdjustDate
        /// <summary>�I���������t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_AdjustDate
        {
            get { return _ed_AdjustDate; }
            set { _ed_AdjustDate = value; }
        }

        /// public propaty name  :  St_InputDay
        /// <summary>�J�n���͓��t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���͓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_InputDay
        {
            get { return _st_InputDay; }
            set { _st_InputDay = value; }
        }

        /// public propaty name  :  Ed_InputDay
        /// <summary>�I�����͓��t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����͓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_InputDay
        {
            get { return _ed_InputDay; }
            set { _ed_InputDay = value; }
        }

        /// public propaty name  :  St_InputAgenCd
        /// <summary>�J�n���͒S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���͒S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_InputAgenCd
        {
            get { return _st_InputAgenCd; }
            set { _st_InputAgenCd = value; }
        }

        /// public propaty name  :  Ed_InputAgenCd
        /// <summary>�I�����͒S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����͒S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_InputAgenCd
        {
            get { return _ed_InputAgenCd; }
            set { _ed_InputAgenCd = value; }
        }

        /// public propaty name  :  StockDiv
        /// <summary>�݌ɋ敪�v���p�e�B</summary>
        /// <value>0:���ЁA1:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDiv
        {
            get { return _stockDiv; }
            set { _stockDiv = value; }
        }


        /// <summary>
        /// �݌Ɏd���m�F�\���o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockAdjustCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockAdjustCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockAdjustCndtnWork()
        {
        }

    }

}
