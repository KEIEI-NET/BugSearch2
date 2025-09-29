//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PCC���Аݒ�}�X�^�����e������o���ʃ��[�N
// �v���O�����T�v   : PCC���Аݒ�}�X�^�����e������o���ʃ��[�N�f�[�^�p�����[�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2011.08.08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� 
// �C �� ��  2013/09/13  �C�����e : SCM�d�|�ꗗ��10571�Ή��@�Q�Ƒq�ɃR�[�h�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070147-00 �쐬�S�� : ���N�n��
// �� �� ��  2014/07/23  �C�����e : SCM�d�|�ꗗ��10659��1���݌ɐ��\���敪�̒ǉ�     
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30746 ���� ��
// �C �� ��  2014/09/04  �C�����e : SCM�d�|�ꗗ��10678�Ή��@�񓚔[���\���敪�ǉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PccCmpnyStWork
    /// <summary>
    ///                      PCC���Аݒ�}�X�^�����e������o���ʃ��[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   PCC���Аݒ�}�X�^�����e������o���ʃ��[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011.08.08  (CSharp File Generated Date)</br>
    /// <br>Programmer       :   ���N�n��</br>
    /// <br>Date             :   2014/07/23</br>
    /// <br>Update Note      :   SCM�d�|�ꗗ��10659��1���݌ɐ��\���敪�̒ǉ�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PccCmpnyStWork
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�⍇������ƃR�[�h</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>�⍇�������_�R�[�h</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>�⍇�����ƃR�[�h</summary>
        private string _inqOtherEpCd = "";

        /// <summary>�⍇���拒�_�R�[�h</summary>
        private string _inqOtherSecCd = "";

        /// <summary>PCC���ЃR�[�h</summary>
        /// <remarks>PM�̓��Ӑ�R�[�h</remarks>
        private Int32 _pccCompanyCode;

        /// <summary>PCC�q�ɃR�[�h</summary>
        private string _pccWarehouseCd = "";

        /// <summary>PCC�D��q�ɃR�[�h1</summary>
        private string _pccPriWarehouseCd1 = "";

        /// <summary>PCC�D��q�ɃR�[�h2</summary>
        private string _pccPriWarehouseCd2 = "";

        /// <summary>PCC�D��q�ɃR�[�h3</summary>
        private string _pccPriWarehouseCd3 = "";

        /// <summary>�i�ԕ\���敪(�⍇��)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _goodsNoDspDiv;

        /// <summary>�W�����i�\���敪(�⍇��)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _listPrcDspDiv;

        /// <summary>�d�؉��i�\���敪(�⍇��)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _costDspDiv;

        /// <summary>�I�ԕ\���敪(�⍇��)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _shelfDspDiv;

        /// <summary>�݌ɕ\���敪(�⍇��)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _stockDspDiv;

        /// <summary>�R�����g�\���敪(�⍇��)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _commentDspDiv;

        /// <summary>�o�א��\���敪(�⍇��)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _spmtCntDspDiv;

        /// <summary>�󒍐��\���敪(�⍇��)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _acptCntDspDiv;

        /// <summary>���i�I��i�ԕ\���敪(�⍇��)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _prtSelGdNoDspDiv;

        /// <summary>���i�I��W�����i�\���敪(�⍇��)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _prtSelLsPrDspDiv;

        /// <summary>���i�I��I�ԕ\���敪(�⍇��)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _prtSelSelfDspDiv;

        /// <summary>���i�I���݌ɕ\���敪(�⍇��)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _prtSelStckDspDiv;

        /// <summary>�݌ɏ󋵃}�[�N1</summary>
        /// <remarks>(���p�S�p����)�݌ɂ���</remarks>
        private string _stckStMark1 = "";

        /// <summary>�݌ɏ󋵃}�[�N2</summary>
        /// <remarks>(���p�S�p����)�݌ɂȂ�</remarks>
        private string _stckStMark2 = "";

        /// <summary>�݌ɏ󋵃}�[�N3</summary>
        /// <remarks>(���p�S�p����)�݌ɕs��</remarks>
        private string _stckStMark3 = "";

        /// <summary>PCC�����於��1</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _pccSuplName1 = "";

        /// <summary>PCC�����於��2</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _pccSuplName2 = "";

        /// <summary>PCC������J�i����</summary>
        /// <remarks>(���p�̂�)</remarks>
        private string _pccSuplKana = "";

        /// <summary>PCC�����旪��</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _pccSuplSnm = "";

        /// <summary>PCC������X�֔ԍ�</summary>
        /// <remarks>(���p�̂�)</remarks>
        private string _pccSuplPostNo = "";

        /// <summary>PCC������Z��1</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _pccSuplAddr1 = "";

        /// <summary>PCC������Z��2</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _pccSuplAddr2 = "";

        /// <summary>PCC������Z��3</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _pccSuplAddr3 = "";

        /// <summary>PCC������d�b�ԍ�1</summary>
        /// <remarks>(���p�̂�)</remarks>
        private string _pccSuplTelNo1 = "";

        /// <summary>PCC������d�b�ԍ�2</summary>
        /// <remarks>(���p�̂�)</remarks>
        private string _pccSuplTelNo2 = "";

        /// <summary>PCC������FAX�ԍ�</summary>
        /// <remarks>(���p�̂�)</remarks>
        private string _pccSuplFaxNo = "";

        /// <summary>�`�[���s�敪�iPCC�j</summary>
        /// <remarks>0:���Ȃ� 1:�� 2:�Ӱ� 3:����</remarks>
        private Int32 _pccSlipPrtDiv;

        /// <summary>�`�[�Ĕ��s�敪</summary>
        /// <remarks>0:���Ȃ� 1:����</remarks>
        private Int32 _pccSlipRePrtDiv;

        /// <summary>���i�I��D�Ǖ\���敪</summary>
        /// <remarks>0:�S�� 1:���ЗD��݌� 2:���Ѝ݌�</remarks>
        private Int32 _prtSelPrmDspDiv;

        /// <summary>�݌ɏ󋵕\���敪</summary>
        /// <remarks>0:�}�[�N 1:���݌ɐ�</remarks>
        private Int32 _stckStDspDiv;

        /// <summary>�݌ɏ󋵃R�����g1</summary>
        /// <remarks>(���p�S�p����) �݌ɂ���</remarks>
        private string _stckStComment1 = "";

        /// <summary>�݌ɏ󋵃R�����g2</summary>
        /// <remarks>(���p�S�p����) �݌ɂȂ�</remarks>
        private string _stckStComment2 = "";

        /// <summary>�݌ɏ󋵃R�����g3</summary>
        /// <remarks>(���p�S�p����) �݌ɕs��</remarks>
        private string _stckStComment3 = "";

        /// <summary>�q�ɕ\���敪(�⍇��)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _warehouseDspDiv;

        /// <summary>����\���敪(�⍇��)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _cancelDspDiv;

        /// <summary>�i�ԕ\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _goodsNoDspDivOd;

        /// <summary>�W�����i�\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _listPrcDspDivOd;

        /// <summary>�d�؉��i�\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _costDspDivOd;

        /// <summary>�I�ԕ\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _shelfDspDivOd;

        /// <summary>�݌ɕ\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _stockDspDivOd;

        /// <summary>�R�����g�\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _commentDspDivOd;

        /// <summary>�o�א��\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _spmtCntDspDivOd;

        /// <summary>�󒍐��\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _acptCntDspDivOd;

        /// <summary>���i�I��i�ԕ\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _prtSelGdNoDspDivOd;

        /// <summary>���i�I��W�����i�\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _prtSelLsPrDspDivOd;

        /// <summary>���i�I��I�ԕ\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _prtSelSelfDspDivOd;

        /// <summary>���i�I���݌ɕ\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _prtSelStckDspDivOd;

        /// <summary>�q�ɕ\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _warehouseDspDivOd;

        /// <summary>����\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _cancelDspDivOd;

        /// <summary>�⍇�������\���敪�ݒ�</summary>
        /// <remarks>0:�⍇���������� 1:�⍇��������</remarks>
        private Int32 _inqOdrDspDivSet;

        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
        /// <summary>PCC�D��q�ɃR�[�h4</summary>
        private string _pccPriWarehouseCd4 = "";
        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<

        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
        /// <summary>���݌ɐ��\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int16 _prsntStkCtDspDivOd;
        /// <summary>���݌ɐ��\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int16 _prsntStkCtDspDiv;
        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<

        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
        /// <summary>�񓚔[���\���敪(�⍇��)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int16 _ansDeliDtDspDiv;

        /// <summary>�񓚔[���\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int16 _ansDeliDtDspDivOd;
        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<

        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
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

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>�⍇�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>�⍇�����ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�����ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>�⍇���拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  PccCompanyCode
        /// <summary>PCC���ЃR�[�h�v���p�e�B</summary>
        /// <value>PM�̓��Ӑ�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC���ЃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PccCompanyCode
        {
            get { return _pccCompanyCode; }
            set { _pccCompanyCode = value; }
        }

        /// public propaty name  :  PccWarehouseCd
        /// <summary>PCC�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC�q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccWarehouseCd
        {
            get { return _pccWarehouseCd; }
            set { _pccWarehouseCd = value; }
        }

        /// public propaty name  :  PccPriWarehouseCd1
        /// <summary>PCC�D��q�ɃR�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC�D��q�ɃR�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccPriWarehouseCd1
        {
            get { return _pccPriWarehouseCd1; }
            set { _pccPriWarehouseCd1 = value; }
        }

        /// public propaty name  :  PccPriWarehouseCd2
        /// <summary>PCC�D��q�ɃR�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC�D��q�ɃR�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccPriWarehouseCd2
        {
            get { return _pccPriWarehouseCd2; }
            set { _pccPriWarehouseCd2 = value; }
        }

        /// public propaty name  :  PccPriWarehouseCd3
        /// <summary>PCC�D��q�ɃR�[�h3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC�D��q�ɃR�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccPriWarehouseCd3
        {
            get { return _pccPriWarehouseCd3; }
            set { _pccPriWarehouseCd3 = value; }
        }

        /// public propaty name  :  GoodsNoDspDiv
        /// <summary>�i�ԕ\���敪(�⍇��)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԕ\���敪(�⍇��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNoDspDiv
        {
            get { return _goodsNoDspDiv; }
            set { _goodsNoDspDiv = value; }
        }

        /// public propaty name  :  ListPrcDspDiv
        /// <summary>�W�����i�\���敪(�⍇��)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�\���敪(�⍇��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ListPrcDspDiv
        {
            get { return _listPrcDspDiv; }
            set { _listPrcDspDiv = value; }
        }

        /// public propaty name  :  CostDspDiv
        /// <summary>�d�؉��i�\���敪(�⍇��)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�؉��i�\���敪(�⍇��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CostDspDiv
        {
            get { return _costDspDiv; }
            set { _costDspDiv = value; }
        }

        /// public propaty name  :  ShelfDspDiv
        /// <summary>�I�ԕ\���敪(�⍇��)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԕ\���敪(�⍇��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShelfDspDiv
        {
            get { return _shelfDspDiv; }
            set { _shelfDspDiv = value; }
        }

        /// public propaty name  :  StockDspDiv
        /// <summary>�݌ɕ\���敪(�⍇��)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɕ\���敪(�⍇��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDspDiv
        {
            get { return _stockDspDiv; }
            set { _stockDspDiv = value; }
        }

        /// public propaty name  :  CommentDspDiv
        /// <summary>�R�����g�\���敪(�⍇��)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R�����g�\���敪(�⍇��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CommentDspDiv
        {
            get { return _commentDspDiv; }
            set { _commentDspDiv = value; }
        }

        /// public propaty name  :  SpmtCntDspDiv
        /// <summary>�o�א��\���敪(�⍇��)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��\���敪(�⍇��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SpmtCntDspDiv
        {
            get { return _spmtCntDspDiv; }
            set { _spmtCntDspDiv = value; }
        }

        /// public propaty name  :  AcptCntDspDiv
        /// <summary>�󒍐��\���敪(�⍇��)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐��\���敪(�⍇��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptCntDspDiv
        {
            get { return _acptCntDspDiv; }
            set { _acptCntDspDiv = value; }
        }

        /// public propaty name  :  PrtSelGdNoDspDiv
        /// <summary>���i�I��i�ԕ\���敪(�⍇��)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��i�ԕ\���敪(�⍇��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtSelGdNoDspDiv
        {
            get { return _prtSelGdNoDspDiv; }
            set { _prtSelGdNoDspDiv = value; }
        }

        /// public propaty name  :  PrtSelLsPrDspDiv
        /// <summary>���i�I��W�����i�\���敪(�⍇��)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��W�����i�\���敪(�⍇��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtSelLsPrDspDiv
        {
            get { return _prtSelLsPrDspDiv; }
            set { _prtSelLsPrDspDiv = value; }
        }

        /// public propaty name  :  PrtSelSelfDspDiv
        /// <summary>���i�I��I�ԕ\���敪(�⍇��)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��I�ԕ\���敪(�⍇��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtSelSelfDspDiv
        {
            get { return _prtSelSelfDspDiv; }
            set { _prtSelSelfDspDiv = value; }
        }

        /// public propaty name  :  PrtSelStckDspDiv
        /// <summary>���i�I���݌ɕ\���敪(�⍇��)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I���݌ɕ\���敪(�⍇��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtSelStckDspDiv
        {
            get { return _prtSelStckDspDiv; }
            set { _prtSelStckDspDiv = value; }
        }

        /// public propaty name  :  StckStMark1
        /// <summary>�݌ɏ󋵃}�[�N1�v���p�e�B</summary>
        /// <value>(���p�S�p����)�݌ɂ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ󋵃}�[�N1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StckStMark1
        {
            get { return _stckStMark1; }
            set { _stckStMark1 = value; }
        }

        /// public propaty name  :  StckStMark2
        /// <summary>�݌ɏ󋵃}�[�N2�v���p�e�B</summary>
        /// <value>(���p�S�p����)�݌ɂȂ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ󋵃}�[�N2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StckStMark2
        {
            get { return _stckStMark2; }
            set { _stckStMark2 = value; }
        }

        /// public propaty name  :  StckStMark3
        /// <summary>�݌ɏ󋵃}�[�N3�v���p�e�B</summary>
        /// <value>(���p�S�p����)�݌ɕs��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ󋵃}�[�N3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StckStMark3
        {
            get { return _stckStMark3; }
            set { _stckStMark3 = value; }
        }

        /// public propaty name  :  PccSuplName1
        /// <summary>PCC�����於��1�v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC�����於��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplName1
        {
            get { return _pccSuplName1; }
            set { _pccSuplName1 = value; }
        }

        /// public propaty name  :  PccSuplName2
        /// <summary>PCC�����於��2�v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC�����於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplName2
        {
            get { return _pccSuplName2; }
            set { _pccSuplName2 = value; }
        }

        /// public propaty name  :  PccSuplKana
        /// <summary>PCC������J�i���̃v���p�e�B</summary>
        /// <value>(���p�̂�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC������J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplKana
        {
            get { return _pccSuplKana; }
            set { _pccSuplKana = value; }
        }

        /// public propaty name  :  PccSuplSnm
        /// <summary>PCC�����旪�̃v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC�����旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplSnm
        {
            get { return _pccSuplSnm; }
            set { _pccSuplSnm = value; }
        }

        /// public propaty name  :  PccSuplPostNo
        /// <summary>PCC������X�֔ԍ��v���p�e�B</summary>
        /// <value>(���p�̂�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC������X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplPostNo
        {
            get { return _pccSuplPostNo; }
            set { _pccSuplPostNo = value; }
        }

        /// public propaty name  :  PccSuplAddr1
        /// <summary>PCC������Z��1�v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC������Z��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplAddr1
        {
            get { return _pccSuplAddr1; }
            set { _pccSuplAddr1 = value; }
        }

        /// public propaty name  :  PccSuplAddr2
        /// <summary>PCC������Z��2�v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC������Z��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplAddr2
        {
            get { return _pccSuplAddr2; }
            set { _pccSuplAddr2 = value; }
        }

        /// public propaty name  :  PccSuplAddr3
        /// <summary>PCC������Z��3�v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC������Z��3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplAddr3
        {
            get { return _pccSuplAddr3; }
            set { _pccSuplAddr3 = value; }
        }

        /// public propaty name  :  PccSuplTelNo1
        /// <summary>PCC������d�b�ԍ�1�v���p�e�B</summary>
        /// <value>(���p�̂�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC������d�b�ԍ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplTelNo1
        {
            get { return _pccSuplTelNo1; }
            set { _pccSuplTelNo1 = value; }
        }

        /// public propaty name  :  PccSuplTelNo2
        /// <summary>PCC������d�b�ԍ�2�v���p�e�B</summary>
        /// <value>(���p�̂�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC������d�b�ԍ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplTelNo2
        {
            get { return _pccSuplTelNo2; }
            set { _pccSuplTelNo2 = value; }
        }

        /// public propaty name  :  PccSuplFaxNo
        /// <summary>PCC������FAX�ԍ��v���p�e�B</summary>
        /// <value>(���p�̂�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC������FAX�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSuplFaxNo
        {
            get { return _pccSuplFaxNo; }
            set { _pccSuplFaxNo = value; }
        }

        /// public propaty name  :  PccSlipPrtDiv
        /// <summary>�`�[���s�敪�iPCC�j�v���p�e�B</summary>
        /// <value>0:���Ȃ� 1:�� 2:�Ӱ� 3:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���s�敪�iPCC�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PccSlipPrtDiv
        {
            get { return _pccSlipPrtDiv; }
            set { _pccSlipPrtDiv = value; }
        }

        /// public propaty name  :  PccSlipRePrtDiv
        /// <summary>�`�[�Ĕ��s�敪�v���p�e�B</summary>
        /// <value>0:���Ȃ� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�Ĕ��s�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PccSlipRePrtDiv
        {
            get { return _pccSlipRePrtDiv; }
            set { _pccSlipRePrtDiv = value; }
        }

        /// public propaty name  :  PrtSelPrmDspDiv
        /// <summary>���i�I��D�Ǖ\���敪�v���p�e�B</summary>
        /// <value>0:�S�� 1:���ЗD��݌� 2:���Ѝ݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��D�Ǖ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtSelPrmDspDiv
        {
            get { return _prtSelPrmDspDiv; }
            set { _prtSelPrmDspDiv = value; }
        }

        /// public propaty name  :  StckStDspDiv
        /// <summary>�݌ɏ󋵕\���敪�v���p�e�B</summary>
        /// <value>0:�}�[�N 1:���݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ󋵕\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StckStDspDiv
        {
            get { return _stckStDspDiv; }
            set { _stckStDspDiv = value; }
        }

        /// public propaty name  :  StckStComment1
        /// <summary>�݌ɏ󋵃R�����g1�v���p�e�B</summary>
        /// <value>(���p�S�p����) �݌ɂ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ󋵃R�����g1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StckStComment1
        {
            get { return _stckStComment1; }
            set { _stckStComment1 = value; }
        }

        /// public propaty name  :  StckStComment2
        /// <summary>�݌ɏ󋵃R�����g2�v���p�e�B</summary>
        /// <value>(���p�S�p����) �݌ɂȂ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ󋵃R�����g2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StckStComment2
        {
            get { return _stckStComment2; }
            set { _stckStComment2 = value; }
        }

        /// public propaty name  :  StckStComment3
        /// <summary>�݌ɏ󋵃R�����g3�v���p�e�B</summary>
        /// <value>(���p�S�p����) �݌ɕs��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ󋵃R�����g3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StckStComment3
        {
            get { return _stckStComment3; }
            set { _stckStComment3 = value; }
        }

        /// public propaty name  :  WarehouseDspDiv
        /// <summary>�q�ɕ\���敪(�⍇��)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɕ\���敪(�⍇��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 WarehouseDspDiv
        {
            get { return _warehouseDspDiv; }
            set { _warehouseDspDiv = value; }
        }

        /// public propaty name  :  CancelDspDiv
        /// <summary>����\���敪(�⍇��)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����\���敪(�⍇��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CancelDspDiv
        {
            get { return _cancelDspDiv; }
            set { _cancelDspDiv = value; }
        }

        /// public propaty name  :  GoodsNoDspDivOd
        /// <summary>�i�ԕ\���敪(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԕ\���敪(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNoDspDivOd
        {
            get { return _goodsNoDspDivOd; }
            set { _goodsNoDspDivOd = value; }
        }

        /// public propaty name  :  ListPrcDspDivOd
        /// <summary>�W�����i�\���敪(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�\���敪(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ListPrcDspDivOd
        {
            get { return _listPrcDspDivOd; }
            set { _listPrcDspDivOd = value; }
        }

        /// public propaty name  :  CostDspDivOd
        /// <summary>�d�؉��i�\���敪(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�؉��i�\���敪(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CostDspDivOd
        {
            get { return _costDspDivOd; }
            set { _costDspDivOd = value; }
        }

        /// public propaty name  :  ShelfDspDivOd
        /// <summary>�I�ԕ\���敪(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԕ\���敪(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShelfDspDivOd
        {
            get { return _shelfDspDivOd; }
            set { _shelfDspDivOd = value; }
        }

        /// public propaty name  :  StockDspDivOd
        /// <summary>�݌ɕ\���敪(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɕ\���敪(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDspDivOd
        {
            get { return _stockDspDivOd; }
            set { _stockDspDivOd = value; }
        }

        /// public propaty name  :  CommentDspDivOd
        /// <summary>�R�����g�\���敪(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R�����g�\���敪(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CommentDspDivOd
        {
            get { return _commentDspDivOd; }
            set { _commentDspDivOd = value; }
        }

        /// public propaty name  :  SpmtCntDspDivOd
        /// <summary>�o�א��\���敪(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��\���敪(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SpmtCntDspDivOd
        {
            get { return _spmtCntDspDivOd; }
            set { _spmtCntDspDivOd = value; }
        }

        /// public propaty name  :  AcptCntDspDivOd
        /// <summary>�󒍐��\���敪(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐��\���敪(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptCntDspDivOd
        {
            get { return _acptCntDspDivOd; }
            set { _acptCntDspDivOd = value; }
        }

        /// public propaty name  :  PrtSelGdNoDspDivOd
        /// <summary>���i�I��i�ԕ\���敪(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��i�ԕ\���敪(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtSelGdNoDspDivOd
        {
            get { return _prtSelGdNoDspDivOd; }
            set { _prtSelGdNoDspDivOd = value; }
        }

        /// public propaty name  :  PrtSelLsPrDspDivOd
        /// <summary>���i�I��W�����i�\���敪(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��W�����i�\���敪(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtSelLsPrDspDivOd
        {
            get { return _prtSelLsPrDspDivOd; }
            set { _prtSelLsPrDspDivOd = value; }
        }

        /// public propaty name  :  PrtSelSelfDspDivOd
        /// <summary>���i�I��I�ԕ\���敪(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��I�ԕ\���敪(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtSelSelfDspDivOd
        {
            get { return _prtSelSelfDspDivOd; }
            set { _prtSelSelfDspDivOd = value; }
        }

        /// public propaty name  :  PrtSelStckDspDivOd
        /// <summary>���i�I���݌ɕ\���敪(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I���݌ɕ\���敪(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtSelStckDspDivOd
        {
            get { return _prtSelStckDspDivOd; }
            set { _prtSelStckDspDivOd = value; }
        }

        /// public propaty name  :  WarehouseDspDivOd
        /// <summary>�q�ɕ\���敪(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɕ\���敪(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 WarehouseDspDivOd
        {
            get { return _warehouseDspDivOd; }
            set { _warehouseDspDivOd = value; }
        }

        /// public propaty name  :  CancelDspDivOd
        /// <summary>����\���敪(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����\���敪(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CancelDspDivOd
        {
            get { return _cancelDspDivOd; }
            set { _cancelDspDivOd = value; }
        }

        /// public propaty name  :  InqOdrDspDivSet
        /// <summary>�⍇�������\���敪�ݒ�v���p�e�B</summary>
        /// <value>0:�⍇���������� 1:�⍇��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������\���敪�ݒ�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InqOdrDspDivSet
        {
            get { return _inqOdrDspDivSet; }
            set { _inqOdrDspDivSet = value; }
        }

        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
        /// public propaty name  :  PccPriWarehouseCd4
        /// <summary>PCC�D��q�ɃR�[�h4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC�D��q�ɃR�[�h4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccPriWarehouseCd4
        {
            get { return _pccPriWarehouseCd4; }
            set { _pccPriWarehouseCd4 = value; }
        }
        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<


        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
        /// public propaty name  :  PrsntStkCtDspDivOd
        /// <summary>���݌ɐ��\���敪(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���݌ɐ��\���敪(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 PrsntStkCtDspDivOd
        {
            get { return _prsntStkCtDspDivOd; }
            set { _prsntStkCtDspDivOd = value; }
        }
        /// public propaty name  :  PrsntStkCtDspDiv
        /// <summary>���݌ɐ��\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���݌ɐ��\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 PrsntStkCtDspDiv
        {
            get { return _prsntStkCtDspDiv; }
            set { _prsntStkCtDspDiv = value; }
        }
        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<

        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
        /// public propaty name  :  AnsDeliDtDspDivRF
        /// <summary>�񓚔[���\���敪(�⍇��)�v���p�e�B</summary>
        /// <value>0:���Ȃ� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���\���敪(�⍇��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 AnsDeliDtDspDiv
        {
            get { return _ansDeliDtDspDiv; }
            set { _ansDeliDtDspDiv = value; }
        }

        /// public propaty name  :  AnsDeliDtDspDivRF
        /// <summary>�񓚔[���\���敪(����)�v���p�e�B</summary>
        /// <value>0:���Ȃ� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���\���敪(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 AnsDeliDtDspDivOd
        {
            get { return _ansDeliDtDspDivOd; }
            set { _ansDeliDtDspDivOd = value; }
        }
        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<

        /// <summary>
        /// PCC���Аݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PccCmpnyStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnyStWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccCmpnyStWork()
        {
        }

        /// <summary>
        /// PCC���Аݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
        /// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
        /// <param name="pccCompanyCode">PCC���ЃR�[�h(PM�̓��Ӑ�R�[�h)</param>
        /// <param name="pccWarehouseCd">PCC�q�ɃR�[�h</param>
        /// <param name="pccPriWarehouseCd1">PCC�D��q�ɃR�[�h1</param>
        /// <param name="pccPriWarehouseCd2">PCC�D��q�ɃR�[�h2</param>
        /// <param name="pccPriWarehouseCd3">PCC�D��q�ɃR�[�h3</param>
        /// <param name="goodsNoDspDiv">�i�ԕ\���敪(�⍇��)(0:���� 1:���Ȃ�)</param>
        /// <param name="listPrcDspDiv">�W�����i�\���敪(�⍇��)(0:���� 1:���Ȃ�)</param>
        /// <param name="costDspDiv">�d�؉��i�\���敪(�⍇��)(0:���� 1:���Ȃ�)</param>
        /// <param name="shelfDspDiv">�I�ԕ\���敪(�⍇��)(0:���� 1:���Ȃ�)</param>
        /// <param name="stockDspDiv">�݌ɕ\���敪(�⍇��)(0:���� 1:���Ȃ�)</param>
        /// <param name="commentDspDiv">�R�����g�\���敪(�⍇��)(0:���� 1:���Ȃ�)</param>
        /// <param name="spmtCntDspDiv">�o�א��\���敪(�⍇��)(0:���� 1:���Ȃ�)</param>
        /// <param name="acptCntDspDiv">�󒍐��\���敪(�⍇��)(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelGdNoDspDiv">���i�I��i�ԕ\���敪(�⍇��)(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelLsPrDspDiv">���i�I��W�����i�\���敪(�⍇��)(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelSelfDspDiv">���i�I��I�ԕ\���敪(�⍇��)(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelStckDspDiv">���i�I���݌ɕ\���敪(�⍇��)(0:���� 1:���Ȃ�)</param>
        /// <param name="stckStMark1">�݌ɏ󋵃}�[�N1((���p�S�p����)�݌ɂ���)</param>
        /// <param name="stckStMark2">�݌ɏ󋵃}�[�N2((���p�S�p����)�݌ɂȂ�)</param>
        /// <param name="stckStMark3">�݌ɏ󋵃}�[�N3((���p�S�p����)�݌ɕs��)</param>
        /// <param name="pccSuplName1">PCC�����於��1((���p�S�p����))</param>
        /// <param name="pccSuplName2">PCC�����於��2((���p�S�p����))</param>
        /// <param name="pccSuplKana">PCC������J�i����((���p�̂�))</param>
        /// <param name="pccSuplSnm">PCC�����旪��((���p�S�p����))</param>
        /// <param name="pccSuplPostNo">PCC������X�֔ԍ�((���p�̂�))</param>
        /// <param name="pccSuplAddr1">PCC������Z��1((���p�S�p����))</param>
        /// <param name="pccSuplAddr2">PCC������Z��2((���p�S�p����))</param>
        /// <param name="pccSuplAddr3">PCC������Z��3((���p�S�p����))</param>
        /// <param name="pccSuplTelNo1">PCC������d�b�ԍ�1((���p�̂�))</param>
        /// <param name="pccSuplTelNo2">PCC������d�b�ԍ�2((���p�̂�))</param>
        /// <param name="pccSuplFaxNo">PCC������FAX�ԍ�((���p�̂�))</param>
        /// <param name="pccSlipPrtDiv">�`�[���s�敪�iPCC�j(0:���Ȃ� 1:�� 2:�Ӱ� 3:����)</param>
        /// <param name="pccSlipRePrtDiv">�`�[�Ĕ��s�敪(0:���Ȃ� 1:����)</param>
        /// <param name="prtSelPrmDspDiv">���i�I��D�Ǖ\���敪(0:�S�� 1:���ЗD��݌� 2:���Ѝ݌�)</param>
        /// <param name="stckStDspDiv">�݌ɏ󋵕\���敪(0:�}�[�N 1:���݌ɐ�)</param>
        /// <param name="stckStComment1">�݌ɏ󋵃R�����g1((���p�S�p����) �݌ɂ���)</param>
        /// <param name="stckStComment2">�݌ɏ󋵃R�����g2((���p�S�p����) �݌ɂȂ�)</param>
        /// <param name="stckStComment3">�݌ɏ󋵃R�����g3((���p�S�p����) �݌ɕs��)</param>
        /// <param name="warehouseDspDiv">�q�ɕ\���敪(�⍇��)(0:���� 1:���Ȃ�)</param>
        /// <param name="cancelDspDiv">����\���敪(�⍇��)(0:���� 1:���Ȃ�)</param>
        /// <param name="goodsNoDspDivOd">�i�ԕ\���敪(����)(0:���� 1:���Ȃ�)</param>
        /// <param name="listPrcDspDivOd">�W�����i�\���敪(����)(0:���� 1:���Ȃ�)</param>
        /// <param name="costDspDivOd">�d�؉��i�\���敪(����)(0:���� 1:���Ȃ�)</param>
        /// <param name="shelfDspDivOd">�I�ԕ\���敪(����)(0:���� 1:���Ȃ�)</param>
        /// <param name="stockDspDivOd">�݌ɕ\���敪(����)(0:���� 1:���Ȃ�)</param>
        /// <param name="commentDspDivOd">�R�����g�\���敪(����)(0:���� 1:���Ȃ�)</param>
        /// <param name="spmtCntDspDivOd">�o�א��\���敪(����)(0:���� 1:���Ȃ�)</param>
        /// <param name="acptCntDspDivOd">�󒍐��\���敪(����)(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelGdNoDspDivOd">���i�I��i�ԕ\���敪(����)(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelLsPrDspDivOd">���i�I��W�����i�\���敪(����)(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelSelfDspDivOd">���i�I��I�ԕ\���敪(����)(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelStckDspDivOd">���i�I���݌ɕ\���敪(����)(0:���� 1:���Ȃ�)</param>
        /// <param name="warehouseDspDivOd">�q�ɕ\���敪(����)(0:���� 1:���Ȃ�)</param>
        /// <param name="cancelDspDivOd">����\���敪(����)(0:���� 1:���Ȃ�)</param>
        /// <param name="inqOdrDspDivSet">�⍇�������\���敪�ݒ�(0:�⍇���������� 1:�⍇��������)</param>
        /// <param name="pccPriWarehouseCd4">PCC�D��q�ɃR�[�h4</param>
        /// <param name="prsntStkCtDspDivOd">���݌ɐ��\���敪(����)</param>
        /// <param name="prsntStkCtDspDiv">���݌ɐ��\���敪</param>
        /// <param name="ansDeliDtDspDiv">�񓚔[���\���敪(�⍇��)</param>
        /// <param name="ansDeliDtDspDivOd">�񓚔[���\���敪(����)</param>
        /// <returns>PccCmpnyStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnyStWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        // UPD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
        //public PccCmpnyStWork(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, string pccWarehouseCd, string pccPriWarehouseCd1, string pccPriWarehouseCd2, string pccPriWarehouseCd3, Int32 goodsNoDspDiv, Int32 listPrcDspDiv, Int32 costDspDiv, Int32 shelfDspDiv, Int32 stockDspDiv, Int32 commentDspDiv, Int32 spmtCntDspDiv, Int32 acptCntDspDiv, Int32 prtSelGdNoDspDiv, Int32 prtSelLsPrDspDiv, Int32 prtSelSelfDspDiv, Int32 prtSelStckDspDiv, string stckStMark1, string stckStMark2, string stckStMark3, string pccSuplName1, string pccSuplName2, string pccSuplKana, string pccSuplSnm, string pccSuplPostNo, string pccSuplAddr1, string pccSuplAddr2, string pccSuplAddr3, string pccSuplTelNo1, string pccSuplTelNo2, string pccSuplFaxNo, Int32 pccSlipPrtDiv, Int32 pccSlipRePrtDiv, Int32 prtSelPrmDspDiv, Int32 stckStDspDiv, string stckStComment1, string stckStComment2, string stckStComment3, Int32 warehouseDspDiv, Int32 cancelDspDiv, Int32 goodsNoDspDivOd, Int32 listPrcDspDivOd, Int32 costDspDivOd, Int32 shelfDspDivOd, Int32 stockDspDivOd, Int32 commentDspDivOd, Int32 spmtCntDspDivOd, Int32 acptCntDspDivOd, Int32 prtSelGdNoDspDivOd, Int32 prtSelLsPrDspDivOd, Int32 prtSelSelfDspDivOd, Int32 prtSelStckDspDivOd, Int32 warehouseDspDivOd, Int32 cancelDspDivOd, Int32 inqOdrDspDivSet)
        //public PccCmpnyStWork(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, string pccWarehouseCd, string pccPriWarehouseCd1, string pccPriWarehouseCd2, string pccPriWarehouseCd3, Int32 goodsNoDspDiv, Int32 listPrcDspDiv, Int32 costDspDiv, Int32 shelfDspDiv, Int32 stockDspDiv, Int32 commentDspDiv, Int32 spmtCntDspDiv, Int32 acptCntDspDiv, Int32 prtSelGdNoDspDiv, Int32 prtSelLsPrDspDiv, Int32 prtSelSelfDspDiv, Int32 prtSelStckDspDiv, string stckStMark1, string stckStMark2, string stckStMark3, string pccSuplName1, string pccSuplName2, string pccSuplKana, string pccSuplSnm, string pccSuplPostNo, string pccSuplAddr1, string pccSuplAddr2, string pccSuplAddr3, string pccSuplTelNo1, string pccSuplTelNo2, string pccSuplFaxNo, Int32 pccSlipPrtDiv, Int32 pccSlipRePrtDiv, Int32 prtSelPrmDspDiv, Int32 stckStDspDiv, string stckStComment1, string stckStComment2, string stckStComment3, Int32 warehouseDspDiv, Int32 cancelDspDiv, Int32 goodsNoDspDivOd, Int32 listPrcDspDivOd, Int32 costDspDivOd, Int32 shelfDspDivOd, Int32 stockDspDivOd, Int32 commentDspDivOd, Int32 spmtCntDspDivOd, Int32 acptCntDspDivOd, Int32 prtSelGdNoDspDivOd, Int32 prtSelLsPrDspDivOd, Int32 prtSelSelfDspDivOd, Int32 prtSelStckDspDivOd, Int32 warehouseDspDivOd, Int32 cancelDspDivOd, Int32 inqOdrDspDivSet, string pccPriWarehouseCd4)// DEL 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ�
        // UPD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
        // 2014/09/04 UPD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
        //public PccCmpnyStWork(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, string pccWarehouseCd, string pccPriWarehouseCd1, string pccPriWarehouseCd2, string pccPriWarehouseCd3, Int32 goodsNoDspDiv, Int32 listPrcDspDiv, Int32 costDspDiv, Int32 shelfDspDiv, Int32 stockDspDiv, Int32 commentDspDiv, Int32 spmtCntDspDiv, Int32 acptCntDspDiv, Int32 prtSelGdNoDspDiv, Int32 prtSelLsPrDspDiv, Int32 prtSelSelfDspDiv, Int32 prtSelStckDspDiv, string stckStMark1, string stckStMark2, string stckStMark3, string pccSuplName1, string pccSuplName2, string pccSuplKana, string pccSuplSnm, string pccSuplPostNo, string pccSuplAddr1, string pccSuplAddr2, string pccSuplAddr3, string pccSuplTelNo1, string pccSuplTelNo2, string pccSuplFaxNo, Int32 pccSlipPrtDiv, Int32 pccSlipRePrtDiv, Int32 prtSelPrmDspDiv, Int32 stckStDspDiv, string stckStComment1, string stckStComment2, string stckStComment3, Int32 warehouseDspDiv, Int32 cancelDspDiv, Int32 goodsNoDspDivOd, Int32 listPrcDspDivOd, Int32 costDspDivOd, Int32 shelfDspDivOd, Int32 stockDspDivOd, Int32 commentDspDivOd, Int32 spmtCntDspDivOd, Int32 acptCntDspDivOd, Int32 prtSelGdNoDspDivOd, Int32 prtSelLsPrDspDivOd, Int32 prtSelSelfDspDivOd, Int32 prtSelStckDspDivOd, Int32 warehouseDspDivOd, Int32 cancelDspDivOd, Int32 inqOdrDspDivSet, string pccPriWarehouseCd4, Int16 prsntStkCtDspDivOd, Int16 prsntStkCtDspDiv)// ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ�
        public PccCmpnyStWork(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, string pccWarehouseCd, string pccPriWarehouseCd1, string pccPriWarehouseCd2, string pccPriWarehouseCd3, Int32 goodsNoDspDiv, Int32 listPrcDspDiv, Int32 costDspDiv, Int32 shelfDspDiv, Int32 stockDspDiv, Int32 commentDspDiv, Int32 spmtCntDspDiv, Int32 acptCntDspDiv, Int32 prtSelGdNoDspDiv, Int32 prtSelLsPrDspDiv, Int32 prtSelSelfDspDiv, Int32 prtSelStckDspDiv, string stckStMark1, string stckStMark2, string stckStMark3, string pccSuplName1, string pccSuplName2, string pccSuplKana, string pccSuplSnm, string pccSuplPostNo, string pccSuplAddr1, string pccSuplAddr2, string pccSuplAddr3, string pccSuplTelNo1, string pccSuplTelNo2, string pccSuplFaxNo, Int32 pccSlipPrtDiv, Int32 pccSlipRePrtDiv, Int32 prtSelPrmDspDiv, Int32 stckStDspDiv, string stckStComment1, string stckStComment2, string stckStComment3, Int32 warehouseDspDiv, Int32 cancelDspDiv, Int32 goodsNoDspDivOd, Int32 listPrcDspDivOd, Int32 costDspDivOd, Int32 shelfDspDivOd, Int32 stockDspDivOd, Int32 commentDspDivOd, Int32 spmtCntDspDivOd, Int32 acptCntDspDivOd, Int32 prtSelGdNoDspDivOd, Int32 prtSelLsPrDspDivOd, Int32 prtSelSelfDspDivOd, Int32 prtSelStckDspDivOd, Int32 warehouseDspDivOd, Int32 cancelDspDivOd, Int32 inqOdrDspDivSet, string pccPriWarehouseCd4, Int16 prsntStkCtDspDivOd, Int16 prsntStkCtDspDiv, Int16 ansDeliDtDspDiv, Int16 ansDeliDtDspDivOd)
        // 2014/09/04 UPD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd;
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._pccCompanyCode = pccCompanyCode;
            this._pccWarehouseCd = pccWarehouseCd;
            this._pccPriWarehouseCd1 = pccPriWarehouseCd1;
            this._pccPriWarehouseCd2 = pccPriWarehouseCd2;
            this._pccPriWarehouseCd3 = pccPriWarehouseCd3;
            this._goodsNoDspDiv = goodsNoDspDiv;
            this._listPrcDspDiv = listPrcDspDiv;
            this._costDspDiv = costDspDiv;
            this._shelfDspDiv = shelfDspDiv;
            this._stockDspDiv = stockDspDiv;
            this._commentDspDiv = commentDspDiv;
            this._spmtCntDspDiv = spmtCntDspDiv;
            this._acptCntDspDiv = acptCntDspDiv;
            this._prtSelGdNoDspDiv = prtSelGdNoDspDiv;
            this._prtSelLsPrDspDiv = prtSelLsPrDspDiv;
            this._prtSelSelfDspDiv = prtSelSelfDspDiv;
            this._prtSelStckDspDiv = prtSelStckDspDiv;
            this._stckStMark1 = stckStMark1;
            this._stckStMark2 = stckStMark2;
            this._stckStMark3 = stckStMark3;
            this._pccSuplName1 = pccSuplName1;
            this._pccSuplName2 = pccSuplName2;
            this._pccSuplKana = pccSuplKana;
            this._pccSuplSnm = pccSuplSnm;
            this._pccSuplPostNo = pccSuplPostNo;
            this._pccSuplAddr1 = pccSuplAddr1;
            this._pccSuplAddr2 = pccSuplAddr2;
            this._pccSuplAddr3 = pccSuplAddr3;
            this._pccSuplTelNo1 = pccSuplTelNo1;
            this._pccSuplTelNo2 = pccSuplTelNo2;
            this._pccSuplFaxNo = pccSuplFaxNo;
            this._pccSlipPrtDiv = pccSlipPrtDiv;
            this._pccSlipRePrtDiv = pccSlipRePrtDiv;
            this._prtSelPrmDspDiv = prtSelPrmDspDiv;
            this._stckStDspDiv = stckStDspDiv;
            this._stckStComment1 = stckStComment1;
            this._stckStComment2 = stckStComment2;
            this._stckStComment3 = stckStComment3;
            this._warehouseDspDiv = warehouseDspDiv;
            this._cancelDspDiv = cancelDspDiv;
            this._goodsNoDspDivOd = goodsNoDspDivOd;
            this._listPrcDspDivOd = listPrcDspDivOd;
            this._costDspDivOd = costDspDivOd;
            this._shelfDspDivOd = shelfDspDivOd;
            this._stockDspDivOd = stockDspDivOd;
            this._commentDspDivOd = commentDspDivOd;
            this._spmtCntDspDivOd = spmtCntDspDivOd;
            this._acptCntDspDivOd = acptCntDspDivOd;
            this._prtSelGdNoDspDivOd = prtSelGdNoDspDivOd;
            this._prtSelLsPrDspDivOd = prtSelLsPrDspDivOd;
            this._prtSelSelfDspDivOd = prtSelSelfDspDivOd;
            this._prtSelStckDspDivOd = prtSelStckDspDivOd;
            this._warehouseDspDivOd = warehouseDspDivOd;
            this._cancelDspDivOd = cancelDspDivOd;
            this._inqOdrDspDivSet = inqOdrDspDivSet;

            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            this._pccPriWarehouseCd4 = pccPriWarehouseCd4;
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<

            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            this._prsntStkCtDspDivOd = prsntStkCtDspDivOd;
            this._prsntStkCtDspDiv = prsntStkCtDspDiv;
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<

            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            this._ansDeliDtDspDiv = ansDeliDtDspDiv;
            this._ansDeliDtDspDivOd = ansDeliDtDspDivOd;
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
        }

        /// <summary>
        /// PCC���Аݒ胏�[�N��������
        /// </summary>
        /// <returns>PccCmpnyStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PccCmpnyStWork�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccCmpnyStWork Clone()
        {
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            //return new PccCmpnyStWork(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._pccWarehouseCd, this._pccPriWarehouseCd1, this._pccPriWarehouseCd2, this._pccPriWarehouseCd3, this._goodsNoDspDiv, this._listPrcDspDiv, this._costDspDiv, this._shelfDspDiv, this._stockDspDiv, this._commentDspDiv, this._spmtCntDspDiv, this._acptCntDspDiv, this._prtSelGdNoDspDiv, this._prtSelLsPrDspDiv, this._prtSelSelfDspDiv, this._prtSelStckDspDiv, this._stckStMark1, this._stckStMark2, this._stckStMark3, this._pccSuplName1, this._pccSuplName2, this._pccSuplKana, this._pccSuplSnm, this._pccSuplPostNo, this._pccSuplAddr1, this._pccSuplAddr2, this._pccSuplAddr3, this._pccSuplTelNo1, this._pccSuplTelNo2, this._pccSuplFaxNo, this._pccSlipPrtDiv, this._pccSlipRePrtDiv, this._prtSelPrmDspDiv, this._stckStDspDiv, this._stckStComment1, this._stckStComment2, this._stckStComment3, this._warehouseDspDiv, this._cancelDspDiv, this._goodsNoDspDivOd, this._listPrcDspDivOd, this._costDspDivOd, this._shelfDspDivOd, this._stockDspDivOd, this._commentDspDivOd, this._spmtCntDspDivOd, this._acptCntDspDivOd, this._prtSelGdNoDspDivOd, this._prtSelLsPrDspDivOd, this._prtSelSelfDspDivOd, this._prtSelStckDspDivOd, this._warehouseDspDivOd, this._cancelDspDivOd, this._inqOdrDspDivSet);
            //return new PccCmpnyStWork(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._pccWarehouseCd, this._pccPriWarehouseCd1, this._pccPriWarehouseCd2, this._pccPriWarehouseCd3, this._goodsNoDspDiv, this._listPrcDspDiv, this._costDspDiv, this._shelfDspDiv, this._stockDspDiv, this._commentDspDiv, this._spmtCntDspDiv, this._acptCntDspDiv, this._prtSelGdNoDspDiv, this._prtSelLsPrDspDiv, this._prtSelSelfDspDiv, this._prtSelStckDspDiv, this._stckStMark1, this._stckStMark2, this._stckStMark3, this._pccSuplName1, this._pccSuplName2, this._pccSuplKana, this._pccSuplSnm, this._pccSuplPostNo, this._pccSuplAddr1, this._pccSuplAddr2, this._pccSuplAddr3, this._pccSuplTelNo1, this._pccSuplTelNo2, this._pccSuplFaxNo, this._pccSlipPrtDiv, this._pccSlipRePrtDiv, this._prtSelPrmDspDiv, this._stckStDspDiv, this._stckStComment1, this._stckStComment2, this._stckStComment3, this._warehouseDspDiv, this._cancelDspDiv, this._goodsNoDspDivOd, this._listPrcDspDivOd, this._costDspDivOd, this._shelfDspDivOd, this._stockDspDivOd, this._commentDspDivOd, this._spmtCntDspDivOd, this._acptCntDspDivOd, this._prtSelGdNoDspDivOd, this._prtSelLsPrDspDivOd, this._prtSelSelfDspDivOd, this._prtSelStckDspDivOd, this._warehouseDspDivOd, this._cancelDspDivOd, this._inqOdrDspDivSet, this._pccPriWarehouseCd4);// DEL 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ�
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            // 2014/09/04 UPD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            //return new PccCmpnyStWork(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._pccWarehouseCd, this._pccPriWarehouseCd1, this._pccPriWarehouseCd2, this._pccPriWarehouseCd3, this._goodsNoDspDiv, this._listPrcDspDiv, this._costDspDiv, this._shelfDspDiv, this._stockDspDiv, this._commentDspDiv, this._spmtCntDspDiv, this._acptCntDspDiv, this._prtSelGdNoDspDiv, this._prtSelLsPrDspDiv, this._prtSelSelfDspDiv, this._prtSelStckDspDiv, this._stckStMark1, this._stckStMark2, this._stckStMark3, this._pccSuplName1, this._pccSuplName2, this._pccSuplKana, this._pccSuplSnm, this._pccSuplPostNo, this._pccSuplAddr1, this._pccSuplAddr2, this._pccSuplAddr3, this._pccSuplTelNo1, this._pccSuplTelNo2, this._pccSuplFaxNo, this._pccSlipPrtDiv, this._pccSlipRePrtDiv, this._prtSelPrmDspDiv, this._stckStDspDiv, this._stckStComment1, this._stckStComment2, this._stckStComment3, this._warehouseDspDiv, this._cancelDspDiv, this._goodsNoDspDivOd, this._listPrcDspDivOd, this._costDspDivOd, this._shelfDspDivOd, this._stockDspDivOd, this._commentDspDivOd, this._spmtCntDspDivOd, this._acptCntDspDivOd, this._prtSelGdNoDspDivOd, this._prtSelLsPrDspDivOd, this._prtSelSelfDspDivOd, this._prtSelStckDspDivOd, this._warehouseDspDivOd, this._cancelDspDivOd, this._inqOdrDspDivSet, this._pccPriWarehouseCd4, this._prsntStkCtDspDivOd, this._prsntStkCtDspDiv);// ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ�
            return new PccCmpnyStWork(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._pccWarehouseCd, this._pccPriWarehouseCd1, this._pccPriWarehouseCd2, this._pccPriWarehouseCd3, this._goodsNoDspDiv, this._listPrcDspDiv, this._costDspDiv, this._shelfDspDiv, this._stockDspDiv, this._commentDspDiv, this._spmtCntDspDiv, this._acptCntDspDiv, this._prtSelGdNoDspDiv, this._prtSelLsPrDspDiv, this._prtSelSelfDspDiv, this._prtSelStckDspDiv, this._stckStMark1, this._stckStMark2, this._stckStMark3, this._pccSuplName1, this._pccSuplName2, this._pccSuplKana, this._pccSuplSnm, this._pccSuplPostNo, this._pccSuplAddr1, this._pccSuplAddr2, this._pccSuplAddr3, this._pccSuplTelNo1, this._pccSuplTelNo2, this._pccSuplFaxNo, this._pccSlipPrtDiv, this._pccSlipRePrtDiv, this._prtSelPrmDspDiv, this._stckStDspDiv, this._stckStComment1, this._stckStComment2, this._stckStComment3, this._warehouseDspDiv, this._cancelDspDiv, this._goodsNoDspDivOd, this._listPrcDspDivOd, this._costDspDivOd, this._shelfDspDivOd, this._stockDspDivOd, this._commentDspDivOd, this._spmtCntDspDivOd, this._acptCntDspDivOd, this._prtSelGdNoDspDivOd, this._prtSelLsPrDspDivOd, this._prtSelSelfDspDivOd, this._prtSelStckDspDivOd, this._warehouseDspDivOd, this._cancelDspDivOd, this._inqOdrDspDivSet, this._pccPriWarehouseCd4, this._prsntStkCtDspDivOd, this._prsntStkCtDspDiv, this._ansDeliDtDspDiv, this._ansDeliDtDspDivOd);
            // 2014/09/04 UPD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
        }

        /// <summary>
        /// PCC���Аݒ胏�[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PccCmpnyStWork�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnyStWork�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PccCmpnyStWork target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd == target.InqOriginalEpCd)
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.PccCompanyCode == target.PccCompanyCode)
                 && (this.PccWarehouseCd == target.PccWarehouseCd)
                 && (this.PccPriWarehouseCd1 == target.PccPriWarehouseCd1)
                 && (this.PccPriWarehouseCd2 == target.PccPriWarehouseCd2)
                 && (this.PccPriWarehouseCd3 == target.PccPriWarehouseCd3)
                 && (this.GoodsNoDspDiv == target.GoodsNoDspDiv)
                 && (this.ListPrcDspDiv == target.ListPrcDspDiv)
                 && (this.CostDspDiv == target.CostDspDiv)
                 && (this.ShelfDspDiv == target.ShelfDspDiv)
                 && (this.StockDspDiv == target.StockDspDiv)
                 && (this.CommentDspDiv == target.CommentDspDiv)
                 && (this.SpmtCntDspDiv == target.SpmtCntDspDiv)
                 && (this.AcptCntDspDiv == target.AcptCntDspDiv)
                 && (this.PrtSelGdNoDspDiv == target.PrtSelGdNoDspDiv)
                 && (this.PrtSelLsPrDspDiv == target.PrtSelLsPrDspDiv)
                 && (this.PrtSelSelfDspDiv == target.PrtSelSelfDspDiv)
                 && (this.PrtSelStckDspDiv == target.PrtSelStckDspDiv)
                 && (this.StckStMark1 == target.StckStMark1)
                 && (this.StckStMark2 == target.StckStMark2)
                 && (this.StckStMark3 == target.StckStMark3)
                 && (this.PccSuplName1 == target.PccSuplName1)
                 && (this.PccSuplName2 == target.PccSuplName2)
                 && (this.PccSuplKana == target.PccSuplKana)
                 && (this.PccSuplSnm == target.PccSuplSnm)
                 && (this.PccSuplPostNo == target.PccSuplPostNo)
                 && (this.PccSuplAddr1 == target.PccSuplAddr1)
                 && (this.PccSuplAddr2 == target.PccSuplAddr2)
                 && (this.PccSuplAddr3 == target.PccSuplAddr3)
                 && (this.PccSuplTelNo1 == target.PccSuplTelNo1)
                 && (this.PccSuplTelNo2 == target.PccSuplTelNo2)
                 && (this.PccSuplFaxNo == target.PccSuplFaxNo)
                 && (this.PccSlipPrtDiv == target.PccSlipPrtDiv)
                 && (this.PccSlipRePrtDiv == target.PccSlipRePrtDiv)
                 && (this.PrtSelPrmDspDiv == target.PrtSelPrmDspDiv)
                 && (this.StckStDspDiv == target.StckStDspDiv)
                 && (this.StckStComment1 == target.StckStComment1)
                 && (this.StckStComment2 == target.StckStComment2)
                 && (this.StckStComment3 == target.StckStComment3)
                 && (this.WarehouseDspDiv == target.WarehouseDspDiv)
                 && (this.CancelDspDiv == target.CancelDspDiv)
                 && (this.GoodsNoDspDivOd == target.GoodsNoDspDivOd)
                 && (this.ListPrcDspDivOd == target.ListPrcDspDivOd)
                 && (this.CostDspDivOd == target.CostDspDivOd)
                 && (this.ShelfDspDivOd == target.ShelfDspDivOd)
                 && (this.StockDspDivOd == target.StockDspDivOd)
                 && (this.CommentDspDivOd == target.CommentDspDivOd)
                 && (this.SpmtCntDspDivOd == target.SpmtCntDspDivOd)
                 && (this.AcptCntDspDivOd == target.AcptCntDspDivOd)
                 && (this.PrtSelGdNoDspDivOd == target.PrtSelGdNoDspDivOd)
                 && (this.PrtSelLsPrDspDivOd == target.PrtSelLsPrDspDivOd)
                 && (this.PrtSelSelfDspDivOd == target.PrtSelSelfDspDivOd)
                 && (this.PrtSelStckDspDivOd == target.PrtSelStckDspDivOd)
                 && (this.WarehouseDspDivOd == target.WarehouseDspDivOd)
                 && (this.CancelDspDivOd == target.CancelDspDivOd)
                 && (this.InqOdrDspDivSet == target.InqOdrDspDivSet)
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                 && (this.PccPriWarehouseCd4 == target.PccPriWarehouseCd4)
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                 && (this.PrsntStkCtDspDivOd == target.PrsntStkCtDspDivOd)
                 && (this.PrsntStkCtDspDiv == target.PrsntStkCtDspDiv)
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                 && (this.AnsDeliDtDspDiv == target.AnsDeliDtDspDiv)
                 && (this.AnsDeliDtDspDivOd == target.AnsDeliDtDspDivOd)
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
                 );
        }

        /// <summary>
        /// PCC���Аݒ胏�[�N��r����
        /// </summary>
        /// <param name="pccCmpnySt1">
        ///                    ��r����PccCmpnyStWork�N���X�̃C���X�^���X
        /// </param>
        /// <param name="pccCmpnySt2">��r����PccCmpnyStWork�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnyStWork�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(PccCmpnyStWork pccCmpnySt1, PccCmpnyStWork pccCmpnySt2)
        {
            return ((pccCmpnySt1.CreateDateTime == pccCmpnySt2.CreateDateTime)
                 && (pccCmpnySt1.UpdateDateTime == pccCmpnySt2.UpdateDateTime)
                 && (pccCmpnySt1.LogicalDeleteCode == pccCmpnySt2.LogicalDeleteCode)
                 && (pccCmpnySt1.InqOriginalEpCd == pccCmpnySt2.InqOriginalEpCd)
                 && (pccCmpnySt1.InqOriginalSecCd == pccCmpnySt2.InqOriginalSecCd)
                 && (pccCmpnySt1.InqOtherEpCd == pccCmpnySt2.InqOtherEpCd)
                 && (pccCmpnySt1.InqOtherSecCd == pccCmpnySt2.InqOtherSecCd)
                 && (pccCmpnySt1.PccCompanyCode == pccCmpnySt2.PccCompanyCode)
                 && (pccCmpnySt1.PccWarehouseCd == pccCmpnySt2.PccWarehouseCd)
                 && (pccCmpnySt1.PccPriWarehouseCd1 == pccCmpnySt2.PccPriWarehouseCd1)
                 && (pccCmpnySt1.PccPriWarehouseCd2 == pccCmpnySt2.PccPriWarehouseCd2)
                 && (pccCmpnySt1.PccPriWarehouseCd3 == pccCmpnySt2.PccPriWarehouseCd3)
                 && (pccCmpnySt1.GoodsNoDspDiv == pccCmpnySt2.GoodsNoDspDiv)
                 && (pccCmpnySt1.ListPrcDspDiv == pccCmpnySt2.ListPrcDspDiv)
                 && (pccCmpnySt1.CostDspDiv == pccCmpnySt2.CostDspDiv)
                 && (pccCmpnySt1.ShelfDspDiv == pccCmpnySt2.ShelfDspDiv)
                 && (pccCmpnySt1.StockDspDiv == pccCmpnySt2.StockDspDiv)
                 && (pccCmpnySt1.CommentDspDiv == pccCmpnySt2.CommentDspDiv)
                 && (pccCmpnySt1.SpmtCntDspDiv == pccCmpnySt2.SpmtCntDspDiv)
                 && (pccCmpnySt1.AcptCntDspDiv == pccCmpnySt2.AcptCntDspDiv)
                 && (pccCmpnySt1.PrtSelGdNoDspDiv == pccCmpnySt2.PrtSelGdNoDspDiv)
                 && (pccCmpnySt1.PrtSelLsPrDspDiv == pccCmpnySt2.PrtSelLsPrDspDiv)
                 && (pccCmpnySt1.PrtSelSelfDspDiv == pccCmpnySt2.PrtSelSelfDspDiv)
                 && (pccCmpnySt1.PrtSelStckDspDiv == pccCmpnySt2.PrtSelStckDspDiv)
                 && (pccCmpnySt1.StckStMark1 == pccCmpnySt2.StckStMark1)
                 && (pccCmpnySt1.StckStMark2 == pccCmpnySt2.StckStMark2)
                 && (pccCmpnySt1.StckStMark3 == pccCmpnySt2.StckStMark3)
                 && (pccCmpnySt1.PccSuplName1 == pccCmpnySt2.PccSuplName1)
                 && (pccCmpnySt1.PccSuplName2 == pccCmpnySt2.PccSuplName2)
                 && (pccCmpnySt1.PccSuplKana == pccCmpnySt2.PccSuplKana)
                 && (pccCmpnySt1.PccSuplSnm == pccCmpnySt2.PccSuplSnm)
                 && (pccCmpnySt1.PccSuplPostNo == pccCmpnySt2.PccSuplPostNo)
                 && (pccCmpnySt1.PccSuplAddr1 == pccCmpnySt2.PccSuplAddr1)
                 && (pccCmpnySt1.PccSuplAddr2 == pccCmpnySt2.PccSuplAddr2)
                 && (pccCmpnySt1.PccSuplAddr3 == pccCmpnySt2.PccSuplAddr3)
                 && (pccCmpnySt1.PccSuplTelNo1 == pccCmpnySt2.PccSuplTelNo1)
                 && (pccCmpnySt1.PccSuplTelNo2 == pccCmpnySt2.PccSuplTelNo2)
                 && (pccCmpnySt1.PccSuplFaxNo == pccCmpnySt2.PccSuplFaxNo)
                 && (pccCmpnySt1.PccSlipPrtDiv == pccCmpnySt2.PccSlipPrtDiv)
                 && (pccCmpnySt1.PccSlipRePrtDiv == pccCmpnySt2.PccSlipRePrtDiv)
                 && (pccCmpnySt1.PrtSelPrmDspDiv == pccCmpnySt2.PrtSelPrmDspDiv)
                 && (pccCmpnySt1.StckStDspDiv == pccCmpnySt2.StckStDspDiv)
                 && (pccCmpnySt1.StckStComment1 == pccCmpnySt2.StckStComment1)
                 && (pccCmpnySt1.StckStComment2 == pccCmpnySt2.StckStComment2)
                 && (pccCmpnySt1.StckStComment3 == pccCmpnySt2.StckStComment3)
                 && (pccCmpnySt1.WarehouseDspDiv == pccCmpnySt2.WarehouseDspDiv)
                 && (pccCmpnySt1.CancelDspDiv == pccCmpnySt2.CancelDspDiv)
                 && (pccCmpnySt1.GoodsNoDspDivOd == pccCmpnySt2.GoodsNoDspDivOd)
                 && (pccCmpnySt1.ListPrcDspDivOd == pccCmpnySt2.ListPrcDspDivOd)
                 && (pccCmpnySt1.CostDspDivOd == pccCmpnySt2.CostDspDivOd)
                 && (pccCmpnySt1.ShelfDspDivOd == pccCmpnySt2.ShelfDspDivOd)
                 && (pccCmpnySt1.StockDspDivOd == pccCmpnySt2.StockDspDivOd)
                 && (pccCmpnySt1.CommentDspDivOd == pccCmpnySt2.CommentDspDivOd)
                 && (pccCmpnySt1.SpmtCntDspDivOd == pccCmpnySt2.SpmtCntDspDivOd)
                 && (pccCmpnySt1.AcptCntDspDivOd == pccCmpnySt2.AcptCntDspDivOd)
                 && (pccCmpnySt1.PrtSelGdNoDspDivOd == pccCmpnySt2.PrtSelGdNoDspDivOd)
                 && (pccCmpnySt1.PrtSelLsPrDspDivOd == pccCmpnySt2.PrtSelLsPrDspDivOd)
                 && (pccCmpnySt1.PrtSelSelfDspDivOd == pccCmpnySt2.PrtSelSelfDspDivOd)
                 && (pccCmpnySt1.PrtSelStckDspDivOd == pccCmpnySt2.PrtSelStckDspDivOd)
                 && (pccCmpnySt1.WarehouseDspDivOd == pccCmpnySt2.WarehouseDspDivOd)
                 && (pccCmpnySt1.CancelDspDivOd == pccCmpnySt2.CancelDspDivOd)
                 && (pccCmpnySt1.InqOdrDspDivSet == pccCmpnySt2.InqOdrDspDivSet)
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                 && (pccCmpnySt1.PccPriWarehouseCd4 == pccCmpnySt2.PccPriWarehouseCd4)
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                 && (pccCmpnySt1.PrsntStkCtDspDivOd == pccCmpnySt2.PrsntStkCtDspDivOd)
                 && (pccCmpnySt1.PrsntStkCtDspDiv == pccCmpnySt2.PrsntStkCtDspDiv)
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                 && (pccCmpnySt1.AnsDeliDtDspDiv == pccCmpnySt2.AnsDeliDtDspDiv)
                 && (pccCmpnySt1.AnsDeliDtDspDivOd == pccCmpnySt2.AnsDeliDtDspDivOd)
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
                 );
        }
        /// <summary>
        /// PCC���Аݒ胏�[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PccCmpnyStWork�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnyStWork�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PccCmpnyStWork target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd != target.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.PccCompanyCode != target.PccCompanyCode) resList.Add("PccCompanyCode");
            if (this.PccWarehouseCd != target.PccWarehouseCd) resList.Add("PccWarehouseCd");
            if (this.PccPriWarehouseCd1 != target.PccPriWarehouseCd1) resList.Add("PccPriWarehouseCd1");
            if (this.PccPriWarehouseCd2 != target.PccPriWarehouseCd2) resList.Add("PccPriWarehouseCd2");
            if (this.PccPriWarehouseCd3 != target.PccPriWarehouseCd3) resList.Add("PccPriWarehouseCd3");
            if (this.GoodsNoDspDiv != target.GoodsNoDspDiv) resList.Add("GoodsNoDspDiv");
            if (this.ListPrcDspDiv != target.ListPrcDspDiv) resList.Add("ListPrcDspDiv");
            if (this.CostDspDiv != target.CostDspDiv) resList.Add("CostDspDiv");
            if (this.ShelfDspDiv != target.ShelfDspDiv) resList.Add("ShelfDspDiv");
            if (this.StockDspDiv != target.StockDspDiv) resList.Add("StockDspDiv");
            if (this.CommentDspDiv != target.CommentDspDiv) resList.Add("CommentDspDiv");
            if (this.SpmtCntDspDiv != target.SpmtCntDspDiv) resList.Add("SpmtCntDspDiv");
            if (this.AcptCntDspDiv != target.AcptCntDspDiv) resList.Add("AcptCntDspDiv");
            if (this.PrtSelGdNoDspDiv != target.PrtSelGdNoDspDiv) resList.Add("PrtSelGdNoDspDiv");
            if (this.PrtSelLsPrDspDiv != target.PrtSelLsPrDspDiv) resList.Add("PrtSelLsPrDspDiv");
            if (this.PrtSelSelfDspDiv != target.PrtSelSelfDspDiv) resList.Add("PrtSelSelfDspDiv");
            if (this.PrtSelStckDspDiv != target.PrtSelStckDspDiv) resList.Add("PrtSelStckDspDiv");
            if (this.StckStMark1 != target.StckStMark1) resList.Add("StckStMark1");
            if (this.StckStMark2 != target.StckStMark2) resList.Add("StckStMark2");
            if (this.StckStMark3 != target.StckStMark3) resList.Add("StckStMark3");
            if (this.PccSuplName1 != target.PccSuplName1) resList.Add("PccSuplName1");
            if (this.PccSuplName2 != target.PccSuplName2) resList.Add("PccSuplName2");
            if (this.PccSuplKana != target.PccSuplKana) resList.Add("PccSuplKana");
            if (this.PccSuplSnm != target.PccSuplSnm) resList.Add("PccSuplSnm");
            if (this.PccSuplPostNo != target.PccSuplPostNo) resList.Add("PccSuplPostNo");
            if (this.PccSuplAddr1 != target.PccSuplAddr1) resList.Add("PccSuplAddr1");
            if (this.PccSuplAddr2 != target.PccSuplAddr2) resList.Add("PccSuplAddr2");
            if (this.PccSuplAddr3 != target.PccSuplAddr3) resList.Add("PccSuplAddr3");
            if (this.PccSuplTelNo1 != target.PccSuplTelNo1) resList.Add("PccSuplTelNo1");
            if (this.PccSuplTelNo2 != target.PccSuplTelNo2) resList.Add("PccSuplTelNo2");
            if (this.PccSuplFaxNo != target.PccSuplFaxNo) resList.Add("PccSuplFaxNo");
            if (this.PccSlipPrtDiv != target.PccSlipPrtDiv) resList.Add("PccSlipPrtDiv");
            if (this.PccSlipRePrtDiv != target.PccSlipRePrtDiv) resList.Add("PccSlipRePrtDiv");
            if (this.PrtSelPrmDspDiv != target.PrtSelPrmDspDiv) resList.Add("PrtSelPrmDspDiv");
            if (this.StckStDspDiv != target.StckStDspDiv) resList.Add("StckStDspDiv");
            if (this.StckStComment1 != target.StckStComment1) resList.Add("StckStComment1");
            if (this.StckStComment2 != target.StckStComment2) resList.Add("StckStComment2");
            if (this.StckStComment3 != target.StckStComment3) resList.Add("StckStComment3");
            if (this.WarehouseDspDiv != target.WarehouseDspDiv) resList.Add("WarehouseDspDiv");
            if (this.CancelDspDiv != target.CancelDspDiv) resList.Add("CancelDspDiv");
            if (this.GoodsNoDspDivOd != target.GoodsNoDspDivOd) resList.Add("GoodsNoDspDivOd");
            if (this.ListPrcDspDivOd != target.ListPrcDspDivOd) resList.Add("ListPrcDspDivOd");
            if (this.CostDspDivOd != target.CostDspDivOd) resList.Add("CostDspDivOd");
            if (this.ShelfDspDivOd != target.ShelfDspDivOd) resList.Add("ShelfDspDivOd");
            if (this.StockDspDivOd != target.StockDspDivOd) resList.Add("StockDspDivOd");
            if (this.CommentDspDivOd != target.CommentDspDivOd) resList.Add("CommentDspDivOd");
            if (this.SpmtCntDspDivOd != target.SpmtCntDspDivOd) resList.Add("SpmtCntDspDivOd");
            if (this.AcptCntDspDivOd != target.AcptCntDspDivOd) resList.Add("AcptCntDspDivOd");
            if (this.PrtSelGdNoDspDivOd != target.PrtSelGdNoDspDivOd) resList.Add("PrtSelGdNoDspDivOd");
            if (this.PrtSelLsPrDspDivOd != target.PrtSelLsPrDspDivOd) resList.Add("PrtSelLsPrDspDivOd");
            if (this.PrtSelSelfDspDivOd != target.PrtSelSelfDspDivOd) resList.Add("PrtSelSelfDspDivOd");
            if (this.PrtSelStckDspDivOd != target.PrtSelStckDspDivOd) resList.Add("PrtSelStckDspDivOd");
            if (this.WarehouseDspDivOd != target.WarehouseDspDivOd) resList.Add("WarehouseDspDivOd");
            if (this.CancelDspDivOd != target.CancelDspDivOd) resList.Add("CancelDspDivOd");
            if (this.InqOdrDspDivSet != target.InqOdrDspDivSet) resList.Add("InqOdrDspDivSet");
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            if (this.PccPriWarehouseCd4 != target.PccPriWarehouseCd4) resList.Add("PccPriWarehouseCd4");
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            if (this.PrsntStkCtDspDivOd != target.PrsntStkCtDspDivOd) resList.Add("PrsntStkCtDspDivOd");
            if (this.PrsntStkCtDspDiv != target.PrsntStkCtDspDiv) resList.Add("PrsntStkCtDspDiv");
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            if (this.AnsDeliDtDspDiv != target.AnsDeliDtDspDiv) resList.Add("AnsDeliDtDspDiv");
            if (this.AnsDeliDtDspDivOd != target.AnsDeliDtDspDivOd) resList.Add("AnsDeliDtDspDivOd");
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<

            return resList;
        }

        /// <summary>
        /// PCC���Аݒ胏�[�N��r����
        /// </summary>
        /// <param name="pccCmpnySt1">��r����PccCmpnyStWork�N���X�̃C���X�^���X</param>
        /// <param name="pccCmpnySt2">��r����PccCmpnyStWork�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnyStWork�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PccCmpnyStWork pccCmpnySt1, PccCmpnyStWork pccCmpnySt2)
        {
            ArrayList resList = new ArrayList();
            if (pccCmpnySt1.CreateDateTime != pccCmpnySt2.CreateDateTime) resList.Add("CreateDateTime");
            if (pccCmpnySt1.UpdateDateTime != pccCmpnySt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pccCmpnySt1.LogicalDeleteCode != pccCmpnySt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pccCmpnySt1.InqOriginalEpCd != pccCmpnySt2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
            if (pccCmpnySt1.InqOriginalSecCd != pccCmpnySt2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (pccCmpnySt1.InqOtherEpCd != pccCmpnySt2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (pccCmpnySt1.InqOtherSecCd != pccCmpnySt2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (pccCmpnySt1.PccCompanyCode != pccCmpnySt2.PccCompanyCode) resList.Add("PccCompanyCode");
            if (pccCmpnySt1.PccWarehouseCd != pccCmpnySt2.PccWarehouseCd) resList.Add("PccWarehouseCd");
            if (pccCmpnySt1.PccPriWarehouseCd1 != pccCmpnySt2.PccPriWarehouseCd1) resList.Add("PccPriWarehouseCd1");
            if (pccCmpnySt1.PccPriWarehouseCd2 != pccCmpnySt2.PccPriWarehouseCd2) resList.Add("PccPriWarehouseCd2");
            if (pccCmpnySt1.PccPriWarehouseCd3 != pccCmpnySt2.PccPriWarehouseCd3) resList.Add("PccPriWarehouseCd3");
            if (pccCmpnySt1.GoodsNoDspDiv != pccCmpnySt2.GoodsNoDspDiv) resList.Add("GoodsNoDspDiv");
            if (pccCmpnySt1.ListPrcDspDiv != pccCmpnySt2.ListPrcDspDiv) resList.Add("ListPrcDspDiv");
            if (pccCmpnySt1.CostDspDiv != pccCmpnySt2.CostDspDiv) resList.Add("CostDspDiv");
            if (pccCmpnySt1.ShelfDspDiv != pccCmpnySt2.ShelfDspDiv) resList.Add("ShelfDspDiv");
            if (pccCmpnySt1.StockDspDiv != pccCmpnySt2.StockDspDiv) resList.Add("StockDspDiv");
            if (pccCmpnySt1.CommentDspDiv != pccCmpnySt2.CommentDspDiv) resList.Add("CommentDspDiv");
            if (pccCmpnySt1.SpmtCntDspDiv != pccCmpnySt2.SpmtCntDspDiv) resList.Add("SpmtCntDspDiv");
            if (pccCmpnySt1.AcptCntDspDiv != pccCmpnySt2.AcptCntDspDiv) resList.Add("AcptCntDspDiv");
            if (pccCmpnySt1.PrtSelGdNoDspDiv != pccCmpnySt2.PrtSelGdNoDspDiv) resList.Add("PrtSelGdNoDspDiv");
            if (pccCmpnySt1.PrtSelLsPrDspDiv != pccCmpnySt2.PrtSelLsPrDspDiv) resList.Add("PrtSelLsPrDspDiv");
            if (pccCmpnySt1.PrtSelSelfDspDiv != pccCmpnySt2.PrtSelSelfDspDiv) resList.Add("PrtSelSelfDspDiv");
            if (pccCmpnySt1.PrtSelStckDspDiv != pccCmpnySt2.PrtSelStckDspDiv) resList.Add("PrtSelStckDspDiv");
            if (pccCmpnySt1.StckStMark1 != pccCmpnySt2.StckStMark1) resList.Add("StckStMark1");
            if (pccCmpnySt1.StckStMark2 != pccCmpnySt2.StckStMark2) resList.Add("StckStMark2");
            if (pccCmpnySt1.StckStMark3 != pccCmpnySt2.StckStMark3) resList.Add("StckStMark3");
            if (pccCmpnySt1.PccSuplName1 != pccCmpnySt2.PccSuplName1) resList.Add("PccSuplName1");
            if (pccCmpnySt1.PccSuplName2 != pccCmpnySt2.PccSuplName2) resList.Add("PccSuplName2");
            if (pccCmpnySt1.PccSuplKana != pccCmpnySt2.PccSuplKana) resList.Add("PccSuplKana");
            if (pccCmpnySt1.PccSuplSnm != pccCmpnySt2.PccSuplSnm) resList.Add("PccSuplSnm");
            if (pccCmpnySt1.PccSuplPostNo != pccCmpnySt2.PccSuplPostNo) resList.Add("PccSuplPostNo");
            if (pccCmpnySt1.PccSuplAddr1 != pccCmpnySt2.PccSuplAddr1) resList.Add("PccSuplAddr1");
            if (pccCmpnySt1.PccSuplAddr2 != pccCmpnySt2.PccSuplAddr2) resList.Add("PccSuplAddr2");
            if (pccCmpnySt1.PccSuplAddr3 != pccCmpnySt2.PccSuplAddr3) resList.Add("PccSuplAddr3");
            if (pccCmpnySt1.PccSuplTelNo1 != pccCmpnySt2.PccSuplTelNo1) resList.Add("PccSuplTelNo1");
            if (pccCmpnySt1.PccSuplTelNo2 != pccCmpnySt2.PccSuplTelNo2) resList.Add("PccSuplTelNo2");
            if (pccCmpnySt1.PccSuplFaxNo != pccCmpnySt2.PccSuplFaxNo) resList.Add("PccSuplFaxNo");
            if (pccCmpnySt1.PccSlipPrtDiv != pccCmpnySt2.PccSlipPrtDiv) resList.Add("PccSlipPrtDiv");
            if (pccCmpnySt1.PccSlipRePrtDiv != pccCmpnySt2.PccSlipRePrtDiv) resList.Add("PccSlipRePrtDiv");
            if (pccCmpnySt1.PrtSelPrmDspDiv != pccCmpnySt2.PrtSelPrmDspDiv) resList.Add("PrtSelPrmDspDiv");
            if (pccCmpnySt1.StckStDspDiv != pccCmpnySt2.StckStDspDiv) resList.Add("StckStDspDiv");
            if (pccCmpnySt1.StckStComment1 != pccCmpnySt2.StckStComment1) resList.Add("StckStComment1");
            if (pccCmpnySt1.StckStComment2 != pccCmpnySt2.StckStComment2) resList.Add("StckStComment2");
            if (pccCmpnySt1.StckStComment3 != pccCmpnySt2.StckStComment3) resList.Add("StckStComment3");
            if (pccCmpnySt1.WarehouseDspDiv != pccCmpnySt2.WarehouseDspDiv) resList.Add("WarehouseDspDiv");
            if (pccCmpnySt1.CancelDspDiv != pccCmpnySt2.CancelDspDiv) resList.Add("CancelDspDiv");
            if (pccCmpnySt1.GoodsNoDspDivOd != pccCmpnySt2.GoodsNoDspDivOd) resList.Add("GoodsNoDspDivOd");
            if (pccCmpnySt1.ListPrcDspDivOd != pccCmpnySt2.ListPrcDspDivOd) resList.Add("ListPrcDspDivOd");
            if (pccCmpnySt1.CostDspDivOd != pccCmpnySt2.CostDspDivOd) resList.Add("CostDspDivOd");
            if (pccCmpnySt1.ShelfDspDivOd != pccCmpnySt2.ShelfDspDivOd) resList.Add("ShelfDspDivOd");
            if (pccCmpnySt1.StockDspDivOd != pccCmpnySt2.StockDspDivOd) resList.Add("StockDspDivOd");
            if (pccCmpnySt1.CommentDspDivOd != pccCmpnySt2.CommentDspDivOd) resList.Add("CommentDspDivOd");
            if (pccCmpnySt1.SpmtCntDspDivOd != pccCmpnySt2.SpmtCntDspDivOd) resList.Add("SpmtCntDspDivOd");
            if (pccCmpnySt1.AcptCntDspDivOd != pccCmpnySt2.AcptCntDspDivOd) resList.Add("AcptCntDspDivOd");
            if (pccCmpnySt1.PrtSelGdNoDspDivOd != pccCmpnySt2.PrtSelGdNoDspDivOd) resList.Add("PrtSelGdNoDspDivOd");
            if (pccCmpnySt1.PrtSelLsPrDspDivOd != pccCmpnySt2.PrtSelLsPrDspDivOd) resList.Add("PrtSelLsPrDspDivOd");
            if (pccCmpnySt1.PrtSelSelfDspDivOd != pccCmpnySt2.PrtSelSelfDspDivOd) resList.Add("PrtSelSelfDspDivOd");
            if (pccCmpnySt1.PrtSelStckDspDivOd != pccCmpnySt2.PrtSelStckDspDivOd) resList.Add("PrtSelStckDspDivOd");
            if (pccCmpnySt1.WarehouseDspDivOd != pccCmpnySt2.WarehouseDspDivOd) resList.Add("WarehouseDspDivOd");
            if (pccCmpnySt1.CancelDspDivOd != pccCmpnySt2.CancelDspDivOd) resList.Add("CancelDspDivOd");
            if (pccCmpnySt1.InqOdrDspDivSet != pccCmpnySt2.InqOdrDspDivSet) resList.Add("InqOdrDspDivSet");
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            if (pccCmpnySt1.PccPriWarehouseCd4 != pccCmpnySt2.PccPriWarehouseCd4) resList.Add("PccPriWarehouseCd4");
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            if (pccCmpnySt1.PrsntStkCtDspDivOd != pccCmpnySt2.PrsntStkCtDspDivOd) resList.Add("PrsntStkCtDspDivOd");
            if (pccCmpnySt1.PrsntStkCtDspDiv != pccCmpnySt2.PrsntStkCtDspDiv) resList.Add("PrsntStkCtDspDiv");
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            if (pccCmpnySt1.AnsDeliDtDspDiv != pccCmpnySt2.AnsDeliDtDspDiv) resList.Add("AnsDeliDtDspDiv");
            if (pccCmpnySt1.AnsDeliDtDspDivOd != pccCmpnySt2.AnsDeliDtDspDivOd) resList.Add("AnsDeliDtDspDivOd");
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<

            return resList;
        }
    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PccCmpnyStWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PccCmpnyStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PccCmpnyStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnyStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PccCmpnyStWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PccCmpnyStWork || graph is ArrayList || graph is PccCmpnyStWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PccCmpnyStWork).FullName));

            if (graph != null && graph is PccCmpnyStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PccCmpnyStWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PccCmpnyStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PccCmpnyStWork[])graph).Length;
            }
            else if (graph is PccCmpnyStWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //�⍇������ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //�⍇�������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //�⍇�����ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //�⍇���拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //PCC���ЃR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PccCompanyCode
            //PCC�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //PccWarehouseCd
            //PCC�D��q�ɃR�[�h1
            serInfo.MemberInfo.Add(typeof(string)); //PccPriWarehouseCd1
            //PCC�D��q�ɃR�[�h2
            serInfo.MemberInfo.Add(typeof(string)); //PccPriWarehouseCd2
            //PCC�D��q�ɃR�[�h3
            serInfo.MemberInfo.Add(typeof(string)); //PccPriWarehouseCd3
            //�i�ԕ\���敪(�⍇��)
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsNoDspDiv
            //�W�����i�\���敪(�⍇��)
            serInfo.MemberInfo.Add(typeof(Int32)); //ListPrcDspDiv
            //�d�؉��i�\���敪(�⍇��)
            serInfo.MemberInfo.Add(typeof(Int32)); //CostDspDiv
            //�I�ԕ\���敪(�⍇��)
            serInfo.MemberInfo.Add(typeof(Int32)); //ShelfDspDiv
            //�݌ɕ\���敪(�⍇��)
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDspDiv
            //�R�����g�\���敪(�⍇��)
            serInfo.MemberInfo.Add(typeof(Int32)); //CommentDspDiv
            //�o�א��\���敪(�⍇��)
            serInfo.MemberInfo.Add(typeof(Int32)); //SpmtCntDspDiv
            //�󒍐��\���敪(�⍇��)
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptCntDspDiv
            //���i�I��i�ԕ\���敪(�⍇��)
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtSelGdNoDspDiv
            //���i�I��W�����i�\���敪(�⍇��)
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtSelLsPrDspDiv
            //���i�I��I�ԕ\���敪(�⍇��)
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtSelSelfDspDiv
            //���i�I���݌ɕ\���敪(�⍇��)
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtSelStckDspDiv
            //�݌ɏ󋵃}�[�N1
            serInfo.MemberInfo.Add(typeof(string)); //StckStMark1
            //�݌ɏ󋵃}�[�N2
            serInfo.MemberInfo.Add(typeof(string)); //StckStMark2
            //�݌ɏ󋵃}�[�N3
            serInfo.MemberInfo.Add(typeof(string)); //StckStMark3
            //PCC�����於��1
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplName1
            //PCC�����於��2
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplName2
            //PCC������J�i����
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplKana
            //PCC�����旪��
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplSnm
            //PCC������X�֔ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplPostNo
            //PCC������Z��1
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplAddr1
            //PCC������Z��2
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplAddr2
            //PCC������Z��3
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplAddr3
            //PCC������d�b�ԍ�1
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplTelNo1
            //PCC������d�b�ԍ�2
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplTelNo2
            //PCC������FAX�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplFaxNo
            //�`�[���s�敪�iPCC�j
            serInfo.MemberInfo.Add(typeof(Int32)); //PccSlipPrtDiv
            //�`�[�Ĕ��s�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PccSlipRePrtDiv
            //���i�I��D�Ǖ\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtSelPrmDspDiv
            //�݌ɏ󋵕\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StckStDspDiv
            //�݌ɏ󋵃R�����g1
            serInfo.MemberInfo.Add(typeof(string)); //StckStComment1
            //�݌ɏ󋵃R�����g2
            serInfo.MemberInfo.Add(typeof(string)); //StckStComment2
            //�݌ɏ󋵃R�����g3
            serInfo.MemberInfo.Add(typeof(string)); //StckStComment3
            //�q�ɕ\���敪(�⍇��)
            serInfo.MemberInfo.Add(typeof(Int32)); //WarehouseDspDiv
            //����\���敪(�⍇��)
            serInfo.MemberInfo.Add(typeof(Int32)); //CancelDspDiv
            //�i�ԕ\���敪(����)
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsNoDspDivOd
            //�W�����i�\���敪(����)
            serInfo.MemberInfo.Add(typeof(Int32)); //ListPrcDspDivOd
            //�d�؉��i�\���敪(����)
            serInfo.MemberInfo.Add(typeof(Int32)); //CostDspDivOd
            //�I�ԕ\���敪(����)
            serInfo.MemberInfo.Add(typeof(Int32)); //ShelfDspDivOd
            //�݌ɕ\���敪(����)
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDspDivOd
            //�R�����g�\���敪(����)
            serInfo.MemberInfo.Add(typeof(Int32)); //CommentDspDivOd
            //�o�א��\���敪(����)
            serInfo.MemberInfo.Add(typeof(Int32)); //SpmtCntDspDivOd
            //�󒍐��\���敪(����)
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptCntDspDivOd
            //���i�I��i�ԕ\���敪(����)
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtSelGdNoDspDivOd
            //���i�I��W�����i�\���敪(����)
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtSelLsPrDspDivOd
            //���i�I��I�ԕ\���敪(����)
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtSelSelfDspDivOd
            //���i�I���݌ɕ\���敪(����)
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtSelStckDspDivOd
            //�q�ɕ\���敪(����)
            serInfo.MemberInfo.Add(typeof(Int32)); //WarehouseDspDivOd
            //����\���敪(����)
            serInfo.MemberInfo.Add(typeof(Int32)); //CancelDspDivOd
            //�⍇�������\���敪�ݒ�
            serInfo.MemberInfo.Add(typeof(Int32)); //InqOdrDspDivSet
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            //PCC�D��q�ɃR�[�h4
            serInfo.MemberInfo.Add(typeof(string)); //PccPriWarehouseCd4
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            //���݌ɐ��\���敪(����)
            serInfo.MemberInfo.Add(typeof(Int16)); //PrsntStkCtDspDivOd
            //���݌ɐ��\���敪(�⍇��)
            serInfo.MemberInfo.Add(typeof(Int16)); //PrsntStkCtDspDiv
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            // �񓚔[���\���敪(�⍇��)
            serInfo.MemberInfo.Add(typeof(Int16));  //AnsDeliDtDspDiv
            // �񓚔[���\���敪(����)
            serInfo.MemberInfo.Add(typeof(Int16));  //AnsDeliDtDspDivOd
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is PccCmpnyStWork)
            {
                PccCmpnyStWork temp = (PccCmpnyStWork)graph;

                SetPccCmpnyStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PccCmpnyStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PccCmpnyStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PccCmpnyStWork temp in lst)
                {
                    SetPccCmpnyStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PccCmpnyStWork�����o��(public�v���p�e�B��)
        /// </summary>
        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
        //private const int currentMemberCount = 62;
        //private const int currentMemberCount = 63;// DEL 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ�
        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
        //private const int currentMemberCount = 65;// ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ�
        private const int currentMemberCount = 67;
        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<

        /// <summary>
        ///  PccCmpnyStWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnyStWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPccCmpnyStWork(System.IO.BinaryWriter writer, PccCmpnyStWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //�⍇������ƃR�[�h
            writer.Write(temp.InqOriginalEpCd);
            //�⍇�������_�R�[�h
            writer.Write(temp.InqOriginalSecCd);
            //�⍇�����ƃR�[�h
            writer.Write(temp.InqOtherEpCd);
            //�⍇���拒�_�R�[�h
            writer.Write(temp.InqOtherSecCd);
            //PCC���ЃR�[�h
            writer.Write(temp.PccCompanyCode);
            //PCC�q�ɃR�[�h
            writer.Write(temp.PccWarehouseCd);
            //PCC�D��q�ɃR�[�h1
            writer.Write(temp.PccPriWarehouseCd1);
            //PCC�D��q�ɃR�[�h2
            writer.Write(temp.PccPriWarehouseCd2);
            //PCC�D��q�ɃR�[�h3
            writer.Write(temp.PccPriWarehouseCd3);
            //�i�ԕ\���敪(�⍇��)
            writer.Write(temp.GoodsNoDspDiv);
            //�W�����i�\���敪(�⍇��)
            writer.Write(temp.ListPrcDspDiv);
            //�d�؉��i�\���敪(�⍇��)
            writer.Write(temp.CostDspDiv);
            //�I�ԕ\���敪(�⍇��)
            writer.Write(temp.ShelfDspDiv);
            //�݌ɕ\���敪(�⍇��)
            writer.Write(temp.StockDspDiv);
            //�R�����g�\���敪(�⍇��)
            writer.Write(temp.CommentDspDiv);
            //�o�א��\���敪(�⍇��)
            writer.Write(temp.SpmtCntDspDiv);
            //�󒍐��\���敪(�⍇��)
            writer.Write(temp.AcptCntDspDiv);
            //���i�I��i�ԕ\���敪(�⍇��)
            writer.Write(temp.PrtSelGdNoDspDiv);
            //���i�I��W�����i�\���敪(�⍇��)
            writer.Write(temp.PrtSelLsPrDspDiv);
            //���i�I��I�ԕ\���敪(�⍇��)
            writer.Write(temp.PrtSelSelfDspDiv);
            //���i�I���݌ɕ\���敪(�⍇��)
            writer.Write(temp.PrtSelStckDspDiv);
            //�݌ɏ󋵃}�[�N1
            writer.Write(temp.StckStMark1);
            //�݌ɏ󋵃}�[�N2
            writer.Write(temp.StckStMark2);
            //�݌ɏ󋵃}�[�N3
            writer.Write(temp.StckStMark3);
            //PCC�����於��1
            writer.Write(temp.PccSuplName1);
            //PCC�����於��2
            writer.Write(temp.PccSuplName2);
            //PCC������J�i����
            writer.Write(temp.PccSuplKana);
            //PCC�����旪��
            writer.Write(temp.PccSuplSnm);
            //PCC������X�֔ԍ�
            writer.Write(temp.PccSuplPostNo);
            //PCC������Z��1
            writer.Write(temp.PccSuplAddr1);
            //PCC������Z��2
            writer.Write(temp.PccSuplAddr2);
            //PCC������Z��3
            writer.Write(temp.PccSuplAddr3);
            //PCC������d�b�ԍ�1
            writer.Write(temp.PccSuplTelNo1);
            //PCC������d�b�ԍ�2
            writer.Write(temp.PccSuplTelNo2);
            //PCC������FAX�ԍ�
            writer.Write(temp.PccSuplFaxNo);
            //�`�[���s�敪�iPCC�j
            writer.Write(temp.PccSlipPrtDiv);
            //�`�[�Ĕ��s�敪
            writer.Write(temp.PccSlipRePrtDiv);
            //���i�I��D�Ǖ\���敪
            writer.Write(temp.PrtSelPrmDspDiv);
            //�݌ɏ󋵕\���敪
            writer.Write(temp.StckStDspDiv);
            //�݌ɏ󋵃R�����g1
            writer.Write(temp.StckStComment1);
            //�݌ɏ󋵃R�����g2
            writer.Write(temp.StckStComment2);
            //�݌ɏ󋵃R�����g3
            writer.Write(temp.StckStComment3);
            //�q�ɕ\���敪(�⍇��)
            writer.Write(temp.WarehouseDspDiv);
            //����\���敪(�⍇��)
            writer.Write(temp.CancelDspDiv);
            //�i�ԕ\���敪(����)
            writer.Write(temp.GoodsNoDspDivOd);
            //�W�����i�\���敪(����)
            writer.Write(temp.ListPrcDspDivOd);
            //�d�؉��i�\���敪(����)
            writer.Write(temp.CostDspDivOd);
            //�I�ԕ\���敪(����)
            writer.Write(temp.ShelfDspDivOd);
            //�݌ɕ\���敪(����)
            writer.Write(temp.StockDspDivOd);
            //�R�����g�\���敪(����)
            writer.Write(temp.CommentDspDivOd);
            //�o�א��\���敪(����)
            writer.Write(temp.SpmtCntDspDivOd);
            //�󒍐��\���敪(����)
            writer.Write(temp.AcptCntDspDivOd);
            //���i�I��i�ԕ\���敪(����)
            writer.Write(temp.PrtSelGdNoDspDivOd);
            //���i�I��W�����i�\���敪(����)
            writer.Write(temp.PrtSelLsPrDspDivOd);
            //���i�I��I�ԕ\���敪(����)
            writer.Write(temp.PrtSelSelfDspDivOd);
            //���i�I���݌ɕ\���敪(����)
            writer.Write(temp.PrtSelStckDspDivOd);
            //�q�ɕ\���敪(����)
            writer.Write(temp.WarehouseDspDivOd);
            //����\���敪(����)
            writer.Write(temp.CancelDspDivOd);
            //�⍇�������\���敪�ݒ�
            writer.Write(temp.InqOdrDspDivSet);
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            //PCC�D��q�ɃR�[�h4
            writer.Write(temp.PccPriWarehouseCd4);
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            //���݌ɐ��\���敪(����)
            writer.Write(temp.PrsntStkCtDspDivOd);
            //���݌ɐ��\���敪(�⍇��)
            writer.Write(temp.PrsntStkCtDspDiv);
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            // �񓚔[���\���敪(�⍇��)
            writer.Write(temp.AnsDeliDtDspDiv);
            // �񓚔[���\���敪(����)
            writer.Write(temp.AnsDeliDtDspDivOd);
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<

        }

        /// <summary>
        ///  PccCmpnyStWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PccCmpnyStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnyStWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PccCmpnyStWork GetPccCmpnyStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PccCmpnyStWork temp = new PccCmpnyStWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //�⍇������ƃR�[�h
            temp.InqOriginalEpCd = reader.ReadString();
            //�⍇�������_�R�[�h
            temp.InqOriginalSecCd = reader.ReadString();
            //�⍇�����ƃR�[�h
            temp.InqOtherEpCd = reader.ReadString();
            //�⍇���拒�_�R�[�h
            temp.InqOtherSecCd = reader.ReadString();
            //PCC���ЃR�[�h
            temp.PccCompanyCode = reader.ReadInt32();
            //PCC�q�ɃR�[�h
            temp.PccWarehouseCd = reader.ReadString();
            //PCC�D��q�ɃR�[�h1
            temp.PccPriWarehouseCd1 = reader.ReadString();
            //PCC�D��q�ɃR�[�h2
            temp.PccPriWarehouseCd2 = reader.ReadString();
            //PCC�D��q�ɃR�[�h3
            temp.PccPriWarehouseCd3 = reader.ReadString();
            //�i�ԕ\���敪(�⍇��)
            temp.GoodsNoDspDiv = reader.ReadInt32();
            //�W�����i�\���敪(�⍇��)
            temp.ListPrcDspDiv = reader.ReadInt32();
            //�d�؉��i�\���敪(�⍇��)
            temp.CostDspDiv = reader.ReadInt32();
            //�I�ԕ\���敪(�⍇��)
            temp.ShelfDspDiv = reader.ReadInt32();
            //�݌ɕ\���敪(�⍇��)
            temp.StockDspDiv = reader.ReadInt32();
            //�R�����g�\���敪(�⍇��)
            temp.CommentDspDiv = reader.ReadInt32();
            //�o�א��\���敪(�⍇��)
            temp.SpmtCntDspDiv = reader.ReadInt32();
            //�󒍐��\���敪(�⍇��)
            temp.AcptCntDspDiv = reader.ReadInt32();
            //���i�I��i�ԕ\���敪(�⍇��)
            temp.PrtSelGdNoDspDiv = reader.ReadInt32();
            //���i�I��W�����i�\���敪(�⍇��)
            temp.PrtSelLsPrDspDiv = reader.ReadInt32();
            //���i�I��I�ԕ\���敪(�⍇��)
            temp.PrtSelSelfDspDiv = reader.ReadInt32();
            //���i�I���݌ɕ\���敪(�⍇��)
            temp.PrtSelStckDspDiv = reader.ReadInt32();
            //�݌ɏ󋵃}�[�N1
            temp.StckStMark1 = reader.ReadString();
            //�݌ɏ󋵃}�[�N2
            temp.StckStMark2 = reader.ReadString();
            //�݌ɏ󋵃}�[�N3
            temp.StckStMark3 = reader.ReadString();
            //PCC�����於��1
            temp.PccSuplName1 = reader.ReadString();
            //PCC�����於��2
            temp.PccSuplName2 = reader.ReadString();
            //PCC������J�i����
            temp.PccSuplKana = reader.ReadString();
            //PCC�����旪��
            temp.PccSuplSnm = reader.ReadString();
            //PCC������X�֔ԍ�
            temp.PccSuplPostNo = reader.ReadString();
            //PCC������Z��1
            temp.PccSuplAddr1 = reader.ReadString();
            //PCC������Z��2
            temp.PccSuplAddr2 = reader.ReadString();
            //PCC������Z��3
            temp.PccSuplAddr3 = reader.ReadString();
            //PCC������d�b�ԍ�1
            temp.PccSuplTelNo1 = reader.ReadString();
            //PCC������d�b�ԍ�2
            temp.PccSuplTelNo2 = reader.ReadString();
            //PCC������FAX�ԍ�
            temp.PccSuplFaxNo = reader.ReadString();
            //�`�[���s�敪�iPCC�j
            temp.PccSlipPrtDiv = reader.ReadInt32();
            //�`�[�Ĕ��s�敪
            temp.PccSlipRePrtDiv = reader.ReadInt32();
            //���i�I��D�Ǖ\���敪
            temp.PrtSelPrmDspDiv = reader.ReadInt32();
            //�݌ɏ󋵕\���敪
            temp.StckStDspDiv = reader.ReadInt32();
            //�݌ɏ󋵃R�����g1
            temp.StckStComment1 = reader.ReadString();
            //�݌ɏ󋵃R�����g2
            temp.StckStComment2 = reader.ReadString();
            //�݌ɏ󋵃R�����g3
            temp.StckStComment3 = reader.ReadString();
            //�q�ɕ\���敪(�⍇��)
            temp.WarehouseDspDiv = reader.ReadInt32();
            //����\���敪(�⍇��)
            temp.CancelDspDiv = reader.ReadInt32();
            //�i�ԕ\���敪(����)
            temp.GoodsNoDspDivOd = reader.ReadInt32();
            //�W�����i�\���敪(����)
            temp.ListPrcDspDivOd = reader.ReadInt32();
            //�d�؉��i�\���敪(����)
            temp.CostDspDivOd = reader.ReadInt32();
            //�I�ԕ\���敪(����)
            temp.ShelfDspDivOd = reader.ReadInt32();
            //�݌ɕ\���敪(����)
            temp.StockDspDivOd = reader.ReadInt32();
            //�R�����g�\���敪(����)
            temp.CommentDspDivOd = reader.ReadInt32();
            //�o�א��\���敪(����)
            temp.SpmtCntDspDivOd = reader.ReadInt32();
            //�󒍐��\���敪(����)
            temp.AcptCntDspDivOd = reader.ReadInt32();
            //���i�I��i�ԕ\���敪(����)
            temp.PrtSelGdNoDspDivOd = reader.ReadInt32();
            //���i�I��W�����i�\���敪(����)
            temp.PrtSelLsPrDspDivOd = reader.ReadInt32();
            //���i�I��I�ԕ\���敪(����)
            temp.PrtSelSelfDspDivOd = reader.ReadInt32();
            //���i�I���݌ɕ\���敪(����)
            temp.PrtSelStckDspDivOd = reader.ReadInt32();
            //�q�ɕ\���敪(����)
            temp.WarehouseDspDivOd = reader.ReadInt32();
            //����\���敪(����)
            temp.CancelDspDivOd = reader.ReadInt32();
            //�⍇�������\���敪�ݒ�
            temp.InqOdrDspDivSet = reader.ReadInt32();
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            //PCC�D��q�ɃR�[�h4
            temp.PccPriWarehouseCd4 = reader.ReadString();
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            //���݌ɐ��\���敪(����)
            temp.PrsntStkCtDspDivOd = reader.ReadInt16();
            //���݌ɐ��\���敪(�⍇��)
            temp.PrsntStkCtDspDiv = reader.ReadInt16();
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            // �񓚔[���\���敪(�⍇��)
            temp.AnsDeliDtDspDiv = reader.ReadInt16();
            // �񓚔[���\���敪(����)
            temp.AnsDeliDtDspDivOd = reader.ReadInt16();
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<

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
        /// <returns>PccCmpnyStWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnyStWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PccCmpnyStWork temp = GetPccCmpnyStWork(reader, serInfo);
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
                    retValue = (PccCmpnyStWork[])lst.ToArray(typeof(PccCmpnyStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
