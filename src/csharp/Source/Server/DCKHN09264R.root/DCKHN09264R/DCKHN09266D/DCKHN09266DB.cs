using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SearchSlipOutputSetParaWork
    /// <summary>
    ///                      �`�[�o�͐�ݒ茟���p�����[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �`�[�o�͐�ݒ茟���p�����[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/12/19  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note      :   2008.06.02  20081 �D�c �E�l</br>
    /// <br>                     �q�ɃR�[�h�ǉ�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SearchSlipOutputSetParaWork
                       
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>���_�R�[�h</summary>
        /// <remarks>null�̏ꍇ�͑S���_</remarks>
        private String[] _selectSectCd;

        /// <summary>�q�ɃR�[�h</summary>
        /// <remarks>�q�ɖ�/�v�����^�ʂ̑ݏo�A�[�i���̎��̂ݎg�p</remarks>
        private string _warehouseCode = "";

        /// <summary>���W�ԍ�</summary>
        /// <remarks>�}�C�i�X�̏ꍇ�͑S��</remarks>
        private Int32 _cashRegisterNo;

        /// <summary>�f�[�^���̓V�X�e��</summary>
        /// <remarks>�}�C�i�X�̏ꍇ�͑S��</remarks>
        private Int32 _dataInputSystem;

        /// <summary>�`�[������</summary>
        /// <remarks>�}�C�i�X�̏ꍇ�͑S��</remarks>
        private Int32 _slipPrtKind;

        /// <summary>�`�[����ݒ�p���[ID</summary>
        /// <remarks>���ݒ�̏ꍇ�͑S��</remarks>
        private string _slipPrtSetPaperId = "";

        /// <summary>�v�����^�Ǘ�No</summary>
        /// <remarks>�}�C�i�X�̏ꍇ�͑S��</remarks>
        private Int32 _printerMngNo;


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

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  SelectSectCd
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>null�̏ꍇ�͑S���_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public String[] SelectSectCd
        {
            get { return _selectSectCd; }
            set { _selectSectCd = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// <value>�q�ɖ�/�v�����^�ʂ̑ݏo�A�[�i���̎��̂ݎg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  CashRegisterNo
        /// <summary>���W�ԍ��v���p�e�B</summary>
        /// <value>�}�C�i�X�̏ꍇ�͑S��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
        }

        /// public propaty name  :  DataInputSystem
        /// <summary>�f�[�^���̓V�X�e���v���p�e�B</summary>
        /// <value>�}�C�i�X�̏ꍇ�͑S��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^���̓V�X�e���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataInputSystem
        {
            get { return _dataInputSystem; }
            set { _dataInputSystem = value; }
        }

        /// public propaty name  :  SlipPrtKind
        /// <summary>�`�[�����ʃv���p�e�B</summary>
        /// <value>�}�C�i�X�̏ꍇ�͑S��</value>
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

        /// public propaty name  :  SlipPrtSetPaperId
        /// <summary>�`�[����ݒ�p���[ID�v���p�e�B</summary>
        /// <value>���ݒ�̏ꍇ�͑S��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[����ݒ�p���[ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipPrtSetPaperId
        {
            get { return _slipPrtSetPaperId; }
            set { _slipPrtSetPaperId = value; }
        }

        /// public propaty name  :  PrinterMngNo
        /// <summary>�v�����^�Ǘ�No�v���p�e�B</summary>
        /// <value>�}�C�i�X�̏ꍇ�͑S��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�����^�Ǘ�No�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrinterMngNo
        {
            get { return _printerMngNo; }
            set { _printerMngNo = value; }
        }


        /// <summary>
        /// �`�[�o�͐�ݒ茟���p�����[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SearchSlipOutputSetParaWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchSlipOutputSetParaWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SearchSlipOutputSetParaWork()
        {
        }

    }
}
