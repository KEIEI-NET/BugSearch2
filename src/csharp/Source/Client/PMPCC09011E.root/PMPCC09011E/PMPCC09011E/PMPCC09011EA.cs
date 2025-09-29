using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PccCmpnySt
    /// <summary>
    ///                      PCC���Аݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   PCC���Аݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2011/7/21</br>
    /// <br>Genarated Date   :   2011/08/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// --------------------------------------------------------------------------
    /// <br>Programmer       :   ����</br>
    /// <br>Date             :   2013/02/12</br>
    /// <br>Update Note      :   2013/03/06�z�M�@SCM��Q��10342,10343�Ή�</br>
    /// --------------------------------------------------------------------------
    /// <br>Programmer       :   ����</br>
    /// <br>Date             :   2013/09/13</br>
    /// <br>Update Note      :   SCM�d�|�ꗗ��10571�Ή� �Q�Ƒq�ɃR�[�h�ǉ�</br>
    /// --------------------------------------------------------------------------
    /// <br>Programmer       :   ���N�n��</br>
    /// <br>Date             :   2014/07/23</br>
    /// <br>Update Note      :   SCM�d�|�ꗗ��10659��1���݌ɐ��\���敪�̒ǉ�</br>
    /// --------------------------------------------------------------------------
    /// <br>Programmer       :   30746 ���� ��</br>
    /// <br>Date             :   2014/09/04</br>
    /// <br>Update Note      :   SCM�d�|�ꗗ��10678�Ή��@�񓚔[���\���敪�ǉ�</br>
    /// --------------------------------------------------------------------------
    /// </remarks>
    public class PccCmpnySt
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

        /// <summary>PCC���Ж���</summary>
        /// <remarks>PM�̓��Ӑ於��</remarks>
        private string _pccCompanyName = "";

        /// <summary>PCC�q�ɃR�[�h</summary>
        private string _pccWarehouseCd = "";

        /// <summary>PCC�q�ɖ���</summary>
        private string _pccWarehouseNm = "";

        /// <summary>PCC�D��q�ɃR�[�h1</summary>
        private string _pccPriWarehouseCd1 = "";

        /// <summary>PCC�D��q�ɃR�[�h2</summary>
        private string _pccPriWarehouseCd2 = "";

        /// <summary>PCC�D��q�ɃR�[�h3</summary>
        private string _pccPriWarehouseCd3 = "";

        /// <summary>�i�ԕ\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _goodsNoDspDiv;

        /// <summary>�i�ԕ\���敪����</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _goodsNoDspDivName = "";

        /// <summary>�W�����i�\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _listPrcDspDiv;

        /// <summary>�W�����i�\������</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _listPrcDspDivName = "";

        /// <summary>�d�؉��i�\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _costDspDiv;

        /// <summary>�d�؉��i�\������</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _costDspDivName = "";

        /// <summary>�I�ԕ\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _shelfDspDiv;

        /// <summary>�I�ԕ\������</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _shelfDspDivName = "";

        /// <summary>�݌ɕ\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _stockDspDiv;

        /// <summary>�݌ɕ\���敪����</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _stockDspDivName = "";

        /// <summary>�R�����g�\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _commentDspDiv;

        /// <summary>�R�����g�\������</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _commentDspDivName = "";

        /// <summary>�o�א��\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _spmtCntDspDiv;

        /// <summary>�o�א��\������</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _spmtCntDspDivName = "";

        /// <summary>�󒍐��\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _acptCntDspDiv;

        /// <summary>�󒍐��\������</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _acptCntDspDivName = "";

        /// <summary>���i�I��i�ԕ\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _prtSelGdNoDspDiv;

        /// <summary>���i�I��i�ԕ\������</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _prtSelGdNoDspDivName = "";

        /// <summary>���i�I��W�����i�\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _prtSelLsPrDspDiv;

        /// <summary>���i�I��W�����i�\������</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _prtSelLsPrDspDivName = "";

        /// <summary>���i�I��I�ԕ\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _prtSelSelfDspDiv;

        /// <summary>���i�I��I�ԕ\������</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _prtSelSelfDspDivName = "";

        /// <summary>���i�I���݌ɕ\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _prtSelStckDspDiv;

        /// <summary>���i�I���݌ɕ\������</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _prtSelStckDspDivName = "";

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

        /// <summary>�`�[���s���́iPCC�j</summary>
        /// <remarks>0:���Ȃ� 1:�� 2:�Ӱ� 3:����</remarks>
        private string _pccSlipPrtDivName = "";

        /// <summary>�`�[�Ĕ��s�敪</summary>
        /// <remarks>0:���Ȃ� 1:����</remarks>
        private Int32 _pccSlipRePrtDiv;

        /// <summary>�`�[�Ĕ��s����</summary>
        /// <remarks>0:���Ȃ� 1:����</remarks>
        private string _pccSlipRePrtDivName = "";

        /// <summary>���i�I��D�Ǖ\���敪</summary>
        /// <remarks>0:�S�� 1:���ЗD��݌� 2:���Ѝ݌�</remarks>
        private Int32 _prtSelPrmDspDiv;

        /// <summary>���i�I��D�Ǖ\������</summary>
        /// <remarks>0:�S�� 1:���ЗD��݌� 2:���Ѝ݌�</remarks>
        private string _prtSelPrmDspDivName = "";

        /// <summary>�݌ɏ󋵕\���敪</summary>
        /// <remarks>0:�}�[�N 1:���݌ɐ�</remarks>
        private Int32 _stckStDspDiv;

        /// <summary>�݌ɏ󋵕\������</summary>
        /// <remarks>0:�}�[�N 1:���݌ɐ�</remarks>
        private string _stckStDspDivName = "";

        /// <summary>�݌ɃR�����g1</summary>
        private string _stckStComment1 = "";

        /// <summary>�݌ɃR�����g2</summary>
        private string _stckStComment2 = "";

        /// <summary>�݌ɃR�����g3</summary>
        private string _stckStComment3 = "";

        // ADD 2013/02/12 SCM��Q��10342,10343�Ή� 2013/03/06�z�M-------------------------------------------->>>>>
        /// <summary>�q�ɕ\���敪(�⍇��)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _warehouseDspDiv;

        /// <summary>�q�ɕ\���敪����(�⍇��)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _warehouseDspDivName = "";

        /// <summary>����\���敪(�⍇��)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _cancelDspDiv;

        /// <summary>����\���敪����(�⍇��)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _cancelDspDivName = "";

        /// <summary>�i�ԕ\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _goodsNoDspDivOd;

        /// <summary>�i�ԕ\���敪����(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _goodsNoDspDivOdName = "";

        /// <summary>�W�����i�\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _listPrcDspDivOd;

        /// <summary>�W�����i�\���敪����(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _listPrcDspDivOdName = "";

        /// <summary>�d�؉��i�\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _costDspDivOd;

        /// <summary>�d�؉��i�\���敪����(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _costDspDivOdName = "";

        /// <summary>�I�ԕ\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _shelfDspDivOd;

        /// <summary>�I�ԕ\���敪����(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _shelfDspDivOdName = "";

        /// <summary>�݌ɕ\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _stockDspDivOd;

        /// <summary>�݌ɕ\���敪����(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _stockDspDivOdName = "";

        /// <summary>�R�����g�\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _commentDspDivOd;

        /// <summary>�R�����g�\���敪����(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _commentDspDivOdName = "";

        /// <summary>�o�א��\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _spmtCntDspDivOd;

        /// <summary>�o�א��\���敪����(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _spmtCntDspDivOdName = "";

        /// <summary>�󒍐��\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _acptCntDspDivOd;

        /// <summary>�󒍐��\���敪����(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _acptCntDspDivOdName = "";

        /// <summary>���i�I��i�ԕ\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _prtSelGdNoDspDivOd;

        /// <summary>���i�I��i�ԕ\���敪����(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _prtSelGdNoDspDivOdName = "";

        /// <summary>���i�I��W�����i�\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _prtSelLsPrDspDivOd;

        /// <summary>���i�I��W�����i�\���敪����(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _prtSelLsPrDspDivOdName = "";

        /// <summary>���i�I��I�ԕ\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _prtSelSelfDspDivOd;

        /// <summary>���i�I��I�ԕ\���敪����(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _prtSelSelfDspDivOdName = "";

        /// <summary>���i�I���݌ɕ\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _prtSelStckDspDivOd;

        /// <summary>���i�I���݌ɕ\���敪����(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _prtSelStckDspDivOdName = "";

        /// <summary>�q�ɕ\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _warehouseDspDivOd;

        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
        /// <summary>���݌ɐ��\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int16 _prsntStkCtDspDivOd;

        /// <summary>���݌ɐ��\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _prsntStkCtDspDivOdName;

        /// <summary>���݌ɐ��\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int16 _prsntStkCtDspDiv;

        /// <summary>���݌ɐ��\���敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _prsntStkCtDspDivName;
        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<

        /// <summary>�q�ɕ\���敪����(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _warehouseDspDivOdName = "";

        /// <summary>����\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _cancelDspDivOd;

        /// <summary>����\���敪����(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private string _cancelDspDivOdName = "";

        /// <summary>�⍇�������\���敪�ݒ�</summary>
        /// <remarks>0:�⍇���������� 1:�⍇��������</remarks>
        private Int32 _inqOdrDspDivSet;

        /// <summary>�⍇�������\���敪�ݒ�</summary>
        /// <remarks>0:�⍇���������� 1:�⍇��������</remarks>
        private string _inqOdrDspDivSetName = "";
        // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<

        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
        /// <summary>PCC�D��q�ɃR�[�h4</summary>
        private string _pccPriWarehouseCd4 = "";
        // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<

        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
        /// <summary>�񓚔[���\���敪(�⍇��)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int16 _ansDeliDtDspDiv;

        /// <summary>�񓚔[���\���敪����(�⍇��)</summary>
        private string _ansDeliDtDspDivName = "";

        /// <summary>�񓚔[���\���敪(����)</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int16 _ansDeliDtDspDivOd;

        /// <summary>�񓚔[���\���敪����(����)</summary>
        private string _ansDeliDtDspDivOdName = "";
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

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>�X�V���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>�X�V���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>�X�V���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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

        /// public propaty name  :  PccCompanyName
        /// <summary>PCC���Ж��̃v���p�e�B</summary>
        /// <value>PM�̓��Ӑ於��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC���Ж��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccCompanyName
        {
            get { return _pccCompanyName; }
            set { _pccCompanyName = value; }
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

        /// public propaty name  :  PccWarehouseNm
        /// <summary>PCC�q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC�q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccWarehouseNm
        {
            get { return _pccWarehouseNm; }
            set { _pccWarehouseNm = value; }
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
        /// <summary>�i�ԕ\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԕ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNoDspDiv
        {
            get { return _goodsNoDspDiv; }
            set { _goodsNoDspDiv = value; }
        }

        /// public propaty name  :  GoodsNoDspDivName
        /// <summary>�i�ԕ\���敪���̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԕ\���敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoDspDivName
        {
            get { return _goodsNoDspDivName; }
            set { _goodsNoDspDivName = value; }
        }

        /// public propaty name  :  ListPrcDspDiv
        /// <summary>�W�����i�\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ListPrcDspDiv
        {
            get { return _listPrcDspDiv; }
            set { _listPrcDspDiv = value; }
        }

        /// public propaty name  :  ListPrcDspDivName
        /// <summary>�W�����i�\�����̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ListPrcDspDivName
        {
            get { return _listPrcDspDivName; }
            set { _listPrcDspDivName = value; }
        }

        /// public propaty name  :  CostDspDiv
        /// <summary>�d�؉��i�\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�؉��i�\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CostDspDiv
        {
            get { return _costDspDiv; }
            set { _costDspDiv = value; }
        }

        /// public propaty name  :  CostDspDivName
        /// <summary>�d�؉��i�\�����̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�؉��i�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CostDspDivName
        {
            get { return _costDspDivName; }
            set { _costDspDivName = value; }
        }

        /// public propaty name  :  ShelfDspDiv
        /// <summary>�I�ԕ\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԕ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShelfDspDiv
        {
            get { return _shelfDspDiv; }
            set { _shelfDspDiv = value; }
        }

        /// public propaty name  :  ShelfDspDivName
        /// <summary>�I�ԕ\�����̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԕ\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShelfDspDivName
        {
            get { return _shelfDspDivName; }
            set { _shelfDspDivName = value; }
        }

        /// public propaty name  :  StockDspDiv
        /// <summary>�݌ɕ\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɕ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDspDiv
        {
            get { return _stockDspDiv; }
            set { _stockDspDiv = value; }
        }

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

        /// public propaty name  :  PrsntStkCtDspDivOdName
        /// <summary>���݌ɐ��\���敪(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���݌ɐ��\���敪(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrsntStkCtDspDivOdName
        {
            get { return _prsntStkCtDspDivOdName; }
            set { _prsntStkCtDspDivOdName = value; }
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

        /// public propaty name  :  PrsntStkCtDspDivOdName
        /// <summary>���݌ɐ��\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���݌ɐ��\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrsntStkCtDspDivName
        {
            get { return _prsntStkCtDspDivName; }
            set { _prsntStkCtDspDivName = value; }
        }
        // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<

        /// public propaty name  :  StockDspDivName
        /// <summary>�݌ɕ\���敪���̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɕ\���敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockDspDivName
        {
            get { return _stockDspDivName; }
            set { _stockDspDivName = value; }
        }

        /// public propaty name  :  CommentDspDiv
        /// <summary>�R�����g�\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R�����g�\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CommentDspDiv
        {
            get { return _commentDspDiv; }
            set { _commentDspDiv = value; }
        }

        /// public propaty name  :  CommentDspDivName
        /// <summary>�R�����g�\�����̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R�����g�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CommentDspDivName
        {
            get { return _commentDspDivName; }
            set { _commentDspDivName = value; }
        }

        /// public propaty name  :  SpmtCntDspDiv
        /// <summary>�o�א��\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SpmtCntDspDiv
        {
            get { return _spmtCntDspDiv; }
            set { _spmtCntDspDiv = value; }
        }

        /// public propaty name  :  SpmtCntDspDivName
        /// <summary>�o�א��\�����̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SpmtCntDspDivName
        {
            get { return _spmtCntDspDivName; }
            set { _spmtCntDspDivName = value; }
        }

        /// public propaty name  :  AcptCntDspDiv
        /// <summary>�󒍐��\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐��\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptCntDspDiv
        {
            get { return _acptCntDspDiv; }
            set { _acptCntDspDiv = value; }
        }

        /// public propaty name  :  AcptCntDspDivName
        /// <summary>�󒍐��\�����̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐��\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AcptCntDspDivName
        {
            get { return _acptCntDspDivName; }
            set { _acptCntDspDivName = value; }
        }

        /// public propaty name  :  PrtSelGdNoDspDiv
        /// <summary>���i�I��i�ԕ\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��i�ԕ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtSelGdNoDspDiv
        {
            get { return _prtSelGdNoDspDiv; }
            set { _prtSelGdNoDspDiv = value; }
        }

        /// public propaty name  :  PrtSelGdNoDspDivName
        /// <summary>���i�I��i�ԕ\�����̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��i�ԕ\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtSelGdNoDspDivName
        {
            get { return _prtSelGdNoDspDivName; }
            set { _prtSelGdNoDspDivName = value; }
        }

        /// public propaty name  :  PrtSelLsPrDspDiv
        /// <summary>���i�I��W�����i�\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��W�����i�\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtSelLsPrDspDiv
        {
            get { return _prtSelLsPrDspDiv; }
            set { _prtSelLsPrDspDiv = value; }
        }

        /// public propaty name  :  PrtSelLsPrDspDivName
        /// <summary>���i�I��W�����i�\�����̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��W�����i�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtSelLsPrDspDivName
        {
            get { return _prtSelLsPrDspDivName; }
            set { _prtSelLsPrDspDivName = value; }
        }

        /// public propaty name  :  PrtSelSelfDspDiv
        /// <summary>���i�I��I�ԕ\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��I�ԕ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtSelSelfDspDiv
        {
            get { return _prtSelSelfDspDiv; }
            set { _prtSelSelfDspDiv = value; }
        }

        /// public propaty name  :  PrtSelSelfDspDivName
        /// <summary>���i�I��I�ԕ\�����̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��I�ԕ\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtSelSelfDspDivName
        {
            get { return _prtSelSelfDspDivName; }
            set { _prtSelSelfDspDivName = value; }
        }

        /// public propaty name  :  PrtSelStckDspDiv
        /// <summary>���i�I���݌ɕ\���敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I���݌ɕ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrtSelStckDspDiv
        {
            get { return _prtSelStckDspDiv; }
            set { _prtSelStckDspDiv = value; }
        }

        /// public propaty name  :  PrtSelStckDspDivName
        /// <summary>���i�I���݌ɕ\�����̃v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I���݌ɕ\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtSelStckDspDivName
        {
            get { return _prtSelStckDspDivName; }
            set { _prtSelStckDspDivName = value; }
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

        /// public propaty name  :  PccSlipPrtDivName
        /// <summary>�`�[���s���́iPCC�j�v���p�e�B</summary>
        /// <value>0:���Ȃ� 1:�� 2:�Ӱ� 3:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���s���́iPCC�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSlipPrtDivName
        {
            get { return _pccSlipPrtDivName; }
            set { _pccSlipPrtDivName = value; }
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

        /// public propaty name  :  PccSlipRePrtDivName
        /// <summary>�`�[�Ĕ��s���̃v���p�e�B</summary>
        /// <value>0:���Ȃ� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�Ĕ��s���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccSlipRePrtDivName
        {
            get { return _pccSlipRePrtDivName; }
            set { _pccSlipRePrtDivName = value; }
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

        /// public propaty name  :  PrtSelPrmDspDivName
        /// <summary>���i�I��D�Ǖ\�����̃v���p�e�B</summary>
        /// <value>0:�S�� 1:���ЗD��݌� 2:���Ѝ݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��D�Ǖ\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtSelPrmDspDivName
        {
            get { return _prtSelPrmDspDivName; }
            set { _prtSelPrmDspDivName = value; }
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

        /// public propaty name  :  StckStDspDivName
        /// <summary>�݌ɏ󋵕\�����̃v���p�e�B</summary>
        /// <value>0:�}�[�N 1:���݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ󋵕\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StckStDspDivName
        {
            get { return _stckStDspDivName; }
            set { _stckStDspDivName = value; }
        }


        /// public propaty name  :  StckStComment1
        /// <summary>�݌ɃR�����g1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɃR�����g1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StckStComment1
        {
            get { return _stckStComment1; }
            set { _stckStComment1 = value; }
        }

        /// public propaty name  :  StckStComment2
        /// <summary>�݌ɃR�����g2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɃR�����g2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StckStComment2
        {
            get { return _stckStComment2; }
            set { _stckStComment2 = value; }
        }

        /// public propaty name  :  StckStComment3
        /// <summary>�݌ɃR�����g3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɃR�����g3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StckStComment3
        {
            get { return _stckStComment3; }
            set { _stckStComment3 = value; }
        }

        // ADD 2013/02/12 SCM��Q��10342,10343�Ή� 2013/03/06�z�M-------------------------------------------->>>>>
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


        /// public propaty name  :  WarehouseDspDivName
        /// <summary>�q�ɕ\���敪����(�⍇��)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɕ\���敪����(�⍇��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseDspDivName
        {
            get { return _warehouseDspDivName; }
            set { _warehouseDspDivName = value; }
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


        /// public propaty name  :  CancelDspDivName
        /// <summary>����\���敪����(�⍇��)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����\���敪����(�⍇��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CancelDspDivName
        {
            get { return _cancelDspDivName; }
            set { _cancelDspDivName = value; }
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

        /// public propaty name  :  GoodsNoDspDivOdName
        /// <summary>�i�ԕ\���敪����(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԕ\���敪����(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoDspDivOdName
        {
            get { return _goodsNoDspDivOdName; }
            set { _goodsNoDspDivOdName = value; }
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

        /// public propaty name  :  ListPrcDspDivOdName
        /// <summary>�W�����i�\���敪����(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�\���敪����(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ListPrcDspDivOdName
        {
            get { return _listPrcDspDivOdName; }
            set { _listPrcDspDivOdName = value; }
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

        /// public propaty name  :  CostDspDivOdName
        /// <summary>�d�؉��i�\���敪����(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�؉��i�\���敪����(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CostDspDivOdName
        {
            get { return _costDspDivOdName; }
            set { _costDspDivOdName = value; }
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

        /// public propaty name  :  ShelfDspDivOdName
        /// <summary>�I�ԕ\���敪����(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԕ\���敪����(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShelfDspDivOdName
        {
            get { return _shelfDspDivOdName; }
            set { _shelfDspDivOdName = value; }
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

        /// public propaty name  :  StockDspDivOdName
        /// <summary>�݌ɕ\���敪����(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɕ\���敪����(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockDspDivOdName
        {
            get { return _stockDspDivOdName; }
            set { _stockDspDivOdName = value; }
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

        /// public propaty name  :  CommentDspDivOdName
        /// <summary>�R�����g�\���敪����(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R�����g�\���敪����(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CommentDspDivOdName
        {
            get { return _commentDspDivOdName; }
            set { _commentDspDivOdName = value; }
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


        /// public propaty name  :  SpmtCntDspDivOdName
        /// <summary>�o�א��\���敪����(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�א��\���敪����(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SpmtCntDspDivOdName
        {
            get { return _spmtCntDspDivOdName; }
            set { _spmtCntDspDivOdName = value; }
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

        /// public propaty name  :  AcptCntDspDivOdName
        /// <summary>�󒍐��\���敪����(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐��\���敪����(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AcptCntDspDivOdName
        {
            get { return _acptCntDspDivOdName; }
            set { _acptCntDspDivOdName = value; }
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

        /// public propaty name  :  PrtSelGdNoDspDivOdName
        /// <summary>���i�I��i�ԕ\���敪����(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��i�ԕ\���敪����(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtSelGdNoDspDivOdName
        {
            get { return _prtSelGdNoDspDivOdName; }
            set { _prtSelGdNoDspDivOdName = value; }
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

        /// public propaty name  :  PrtSelLsPrDspDivOdName
        /// <summary>���i�I��W�����i�\���敪����(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��W�����i�\���敪����(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtSelLsPrDspDivOdName
        {
            get { return _prtSelLsPrDspDivOdName; }
            set { _prtSelLsPrDspDivOdName = value; }
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

        /// public propaty name  :  PrtSelSelfDspDivOdName
        /// <summary>���i�I��I�ԕ\���敪����(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I��I�ԕ\���敪����(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtSelSelfDspDivOdName
        {
            get { return _prtSelSelfDspDivOdName; }
            set { _prtSelSelfDspDivOdName = value; }
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

        /// public propaty name  :  PrtSelStckDspDivOdName
        /// <summary>���i�I���݌ɕ\���敪����(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�I���݌ɕ\���敪����(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtSelStckDspDivOdName
        {
            get { return _prtSelStckDspDivOdName; }
            set { _prtSelStckDspDivOdName = value; }
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

        /// public propaty name  :  WarehouseDspDivOdName
        /// <summary>�q�ɕ\���敪����(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɕ\���敪����(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseDspDivOdName
        {
            get { return _warehouseDspDivOdName; }
            set { _warehouseDspDivOdName = value; }
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

        /// public propaty name  :  CancelDspDivOdName
        /// <summary>����\���敪����(����)�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����\���敪����(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CancelDspDivOdName
        {
            get { return _cancelDspDivOdName; }
            set { _cancelDspDivOdName = value; }
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

        /// public propaty name  :  InqOdrDspDivSetName
        /// <summary>�⍇�������\���敪�ݒ薼�̃v���p�e�B</summary>
        /// <value>0:�⍇���������� 1:�⍇��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������\���敪�ݒ薼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOdrDspDivSetName
        {
            get { return _inqOdrDspDivSetName; }
            set { _inqOdrDspDivSetName = value; }
        }
        // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<

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

        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
        /// public propaty name  :  AnsDeliDtDspDiv
        /// <summary>�񓚔[���\���敪(�⍇��)�v���p�e�B</summary>
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

        /// public propaty name  :  AnsDeliDtDspDivName
        /// <summary>�񓚔[���\���敪����(�⍇��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���\���敪����(�⍇��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnsDeliDtDspDivName
        {
            get { return _ansDeliDtDspDivName; }
            set { _ansDeliDtDspDivName = value; }
        }

        /// public propaty name  :  AnsDeliDtDspDivOd
        /// <summary>�񓚔[���\���敪(����)�v���p�e�B</summary>
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

        /// public propaty name  :  AnsDeliDtDspDivOdName
        /// <summary>�񓚔[���\���敪����(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���\���敪����(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnsDeliDtDspDivOdName
        {
            get { return _ansDeliDtDspDivOdName; }
            set { _ansDeliDtDspDivOdName = value; }
        }
        // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<

        /// <summary>
        /// PCC���Аݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>PccCmpnySt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnySt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccCmpnySt()
        {
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
        /// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
        /// <param name="pccCompanyCode">PCC���ЃR�[�h(PM�̓��Ӑ�R�[�h)</param>
        /// <param name="pccCompanyName">PCC���Ж���(PM�̓��Ӑ於��)</param>
        /// <param name="pccWarehouseCd">PCC�q�ɃR�[�h</param>
        /// <param name="pccWarehouseNm">PCC�q�ɖ���</param>
        /// <param name="pccPriWarehouseCd1">PCC�D��q�ɃR�[�h1</param>
        /// <param name="pccPriWarehouseCd2">PCC�D��q�ɃR�[�h2</param>
        /// <param name="pccPriWarehouseCd3">PCC�D��q�ɃR�[�h3</param>
        /// <param name="goodsNoDspDiv">�i�ԕ\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="goodsNoDspDivName">�i�ԕ\���敪����(0:���� 1:���Ȃ�)</param>
        /// <param name="listPrcDspDiv">�W�����i�\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="listPrcDspDivName">�W�����i�\������(0:���� 1:���Ȃ�)</param>
        /// <param name="costDspDiv">�d�؉��i�\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="costDspDivName">�d�؉��i�\������(0:���� 1:���Ȃ�)</param>
        /// <param name="shelfDspDiv">�I�ԕ\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="shelfDspDivName">�I�ԕ\������(0:���� 1:���Ȃ�)</param>
        /// <param name="stockDspDiv">�݌ɕ\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="stockDspDivName">�݌ɕ\���敪����(0:���� 1:���Ȃ�)</param>
        /// <param name="commentDspDiv">�R�����g�\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="commentDspDivName">�R�����g�\������(0:���� 1:���Ȃ�)</param>
        /// <param name="spmtCntDspDiv">�o�א��\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="spmtCntDspDivName">�o�א��\������(0:���� 1:���Ȃ�)</param>
        /// <param name="acptCntDspDiv">�󒍐��\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="acptCntDspDivName">�󒍐��\������(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelGdNoDspDiv">���i�I��i�ԕ\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelGdNoDspDivName">���i�I��i�ԕ\������(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelLsPrDspDiv">���i�I��W�����i�\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelLsPrDspDivName">���i�I��W�����i�\������(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelSelfDspDiv">���i�I��I�ԕ\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelSelfDspDivName">���i�I��I�ԕ\������(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelStckDspDiv">���i�I���݌ɕ\���敪(0:���� 1:���Ȃ�)</param>
        /// <param name="prtSelStckDspDivName">���i�I���݌ɕ\������(0:���� 1:���Ȃ�)</param>
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
        /// <param name="pccSlipPrtDivName">�`�[���s���́iPCC�j(0:���Ȃ� 1:�� 2:�Ӱ� 3:����)</param>
        /// <param name="pccSlipRePrtDiv">�`�[�Ĕ��s�敪(0:���Ȃ� 1:����)</param>
        /// <param name="pccSlipRePrtDivName">�`�[�Ĕ��s����(0:���Ȃ� 1:����)</param>
        /// <param name="prtSelPrmDspDiv">���i�I��D�Ǖ\���敪(0:�S�� 1:���ЗD��݌� 2:���Ѝ݌�)</param>
        /// <param name="prtSelPrmDspDivName">���i�I��D�Ǖ\������(0:�S�� 1:���ЗD��݌� 2:���Ѝ݌�)</param>
        /// <param name="stckStDspDiv">�݌ɏ󋵕\���敪(0:�}�[�N 1:���݌ɐ�)</param>
        /// <param name="stckStDspDivName">�݌ɏ󋵕\������(0:�}�[�N 1:���݌ɐ�)</param>
        /// <param name="stckStComment1">�݌ɃR�����g1</param>
        /// <param name="stckStComment2">�݌ɃR�����g2</param>
        /// <param name="stckStComment3">�݌ɃR�����g3</param>
        /// <param name="warehouseDspDiv">�q�ɕ\���敪(�⍇��)</param>
        /// <param name="cancelDspDiv">����\���敪(�⍇��)</param>
        /// <param name="goodsNoDspDivOd">�i�ԕ\���敪(����)</param>
        /// <param name="listPrcDspDivOd">�W�����i�\���敪(����)</param>
        /// <param name="costDspDivOd">�d�؉��i�\���敪(����)</param>
        /// <param name="shelfDspDivOd">�I�ԕ\���敪(����)</param>
        /// <param name="stockDspDivOd">�݌ɕ\���敪(����)</param>
        /// <param name="commentDspDivOd">�R�����g�\���敪(����)</param>
        /// <param name="spmtCntDspDivOd">�o�א��\���敪(����)</param>
        /// <param name="acptCntDspDivOd">�󒍐��\���敪(����)</param>
        /// <param name="prtSelGdNoDspDivOd">���i�I��i�ԕ\���敪(����)</param>
        /// <param name="prtSelLsPrDspDivOd">���i�I��W�����i�\���敪(����)</param>
        /// <param name="prtSelSelfDspDivOd">���i�I��I�ԕ\���敪(����)</param>
        /// <param name="prtSelStckDspDivOd">���i�I���݌ɕ\���敪(����)</param>
        /// <param name="warehouseDspDivOd">�q�ɕ\���敪(����)</param>
        /// <param name="cancelDspDivOd">����\���敪(����)</param>
        /// <param name="inqOdrDspDivSet">�⍇�������\���敪�ݒ�</param>
        /// <param name="pccPriWarehouseCd4">PCC�D��q�ɃR�[�h4</param>
        /// <param name="prsntStkCtDspDivOd">���݌ɐ��\���敪(����)</param>
        /// <param name="prsntStkCtDspDivOdName">���݌ɐ��\���敪(����)����</param>
        /// <param name="prsntStkCtDspDiv">���݌ɐ��\���敪</param>
        /// <param name="prsntStkCtDspDivName">���݌ɐ��\���敪����</param>
        /// <param name="ansDeliDtDspDiv">�񓚔[���\���敪(�⍇��)</param>
        /// <param name="ansDeliDtDspDivName">�񓚔[���\���敪����(�⍇��)</param>
        /// <param name="ansDeliDtDspDivOd">�񓚔[���\���敪(����)</param>
        /// <param name="ansDeliDtDspDivOdName">�񓚔[���\���敪����(����)</param>
        /// <returns>PccCmpnySt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnySt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        // UPD 2013/02/12 SCM��Q��10342,10343�Ή� 2013/03/06�z�M -------------------------------------------->>>>>
        //public PccCmpnySt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, string pccCompanyName, string pccWarehouseCd, string pccWarehouseNm, string pccPriWarehouseCd1, string pccPriWarehouseCd2, string pccPriWarehouseCd3, Int32 goodsNoDspDiv, string goodsNoDspDivName, Int32 listPrcDspDiv, string listPrcDspDivName, Int32 costDspDiv, string costDspDivName, Int32 shelfDspDiv, string shelfDspDivName, Int32 stockDspDiv, string stockDspDivName, Int32 commentDspDiv, string commentDspDivName, Int32 spmtCntDspDiv, string spmtCntDspDivName, Int32 acptCntDspDiv, string acptCntDspDivName, Int32 prtSelGdNoDspDiv, string prtSelGdNoDspDivName, Int32 prtSelLsPrDspDiv, string prtSelLsPrDspDivName, Int32 prtSelSelfDspDiv, string prtSelSelfDspDivName, Int32 prtSelStckDspDiv, string prtSelStckDspDivName, string stckStMark1, string stckStMark2, string stckStMark3, string pccSuplName1, string pccSuplName2, string pccSuplKana, string pccSuplSnm, string pccSuplPostNo, string pccSuplAddr1, string pccSuplAddr2, string pccSuplAddr3, string pccSuplTelNo1, string pccSuplTelNo2, string pccSuplFaxNo, Int32 pccSlipPrtDiv, string pccSlipPrtDivName, Int32 pccSlipRePrtDiv, string pccSlipRePrtDivName, Int32 prtSelPrmDspDiv, string prtSelPrmDspDivName, Int32 stckStDspDiv, string stckStDspDivName, string stckStComment1, string stckStComment2, string stckStComment3)
        // UPD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
        //public PccCmpnySt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, string pccCompanyName, string pccWarehouseCd, string pccWarehouseNm, string pccPriWarehouseCd1, string pccPriWarehouseCd2, string pccPriWarehouseCd3, Int32 goodsNoDspDiv, string goodsNoDspDivName, Int32 listPrcDspDiv, string listPrcDspDivName, Int32 costDspDiv, string costDspDivName, Int32 shelfDspDiv, string shelfDspDivName, Int32 stockDspDiv, string stockDspDivName, Int32 commentDspDiv, string commentDspDivName, Int32 spmtCntDspDiv, string spmtCntDspDivName, Int32 acptCntDspDiv, string acptCntDspDivName, Int32 prtSelGdNoDspDiv, string prtSelGdNoDspDivName, Int32 prtSelLsPrDspDiv, string prtSelLsPrDspDivName, Int32 prtSelSelfDspDiv, string prtSelSelfDspDivName, Int32 prtSelStckDspDiv, string prtSelStckDspDivName, string stckStMark1, string stckStMark2, string stckStMark3, string pccSuplName1, string pccSuplName2, string pccSuplKana, string pccSuplSnm, string pccSuplPostNo, string pccSuplAddr1, string pccSuplAddr2, string pccSuplAddr3, string pccSuplTelNo1, string pccSuplTelNo2, string pccSuplFaxNo, Int32 pccSlipPrtDiv, string pccSlipPrtDivName, Int32 pccSlipRePrtDiv, string pccSlipRePrtDivName, Int32 prtSelPrmDspDiv, string prtSelPrmDspDivName, Int32 stckStDspDiv, string stckStDspDivName, string stckStComment1, string stckStComment2, string stckStComment3, Int32 warehouseDspDiv, Int32 cancelDspDiv, Int32 goodsNoDspDivOd, Int32 listPrcDspDivOd, Int32 costDspDivOd, Int32 shelfDspDivOd, Int32 stockDspDivOd, Int32 commentDspDivOd, Int32 spmtCntDspDivOd, Int32 acptCntDspDivOd, Int32 prtSelGdNoDspDivOd, Int32 prtSelLsPrDspDivOd, Int32 prtSelSelfDspDivOd, Int32 prtSelStckDspDivOd, Int32 warehouseDspDivOd, Int32 cancelDspDivOd, Int32 inqOdrDspDivSet, string warehouseDspDivName, string cancelDspDivName, string goodsNoDspDivOdName, string listPrcDspDivOdName, string costDspDivOdName, string shelfDspDivOdName, string stockDspDivOdName, string commentDspDivOdName, string spmtCntDspDivOdName, string acptCntDspDivOdName, string prtSelGdNoDspDivOdName, string prtSelLsPrDspDivOdName, string prtSelSelfDspDivOdName, string prtSelStckDspDivOdName, string warehouseDspDivOdName, string cancelDspDivOdName, string inqOdrDspDivSetName)
        //public PccCmpnySt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, string pccCompanyName, string pccWarehouseCd, string pccWarehouseNm, string pccPriWarehouseCd1, string pccPriWarehouseCd2, string pccPriWarehouseCd3, Int32 goodsNoDspDiv, string goodsNoDspDivName, Int32 listPrcDspDiv, string listPrcDspDivName, Int32 costDspDiv, string costDspDivName, Int32 shelfDspDiv, string shelfDspDivName, Int32 stockDspDiv, string stockDspDivName, Int32 commentDspDiv, string commentDspDivName, Int32 spmtCntDspDiv, string spmtCntDspDivName, Int32 acptCntDspDiv, string acptCntDspDivName, Int32 prtSelGdNoDspDiv, string prtSelGdNoDspDivName, Int32 prtSelLsPrDspDiv, string prtSelLsPrDspDivName, Int32 prtSelSelfDspDiv, string prtSelSelfDspDivName, Int32 prtSelStckDspDiv, string prtSelStckDspDivName, string stckStMark1, string stckStMark2, string stckStMark3, string pccSuplName1, string pccSuplName2, string pccSuplKana, string pccSuplSnm, string pccSuplPostNo, string pccSuplAddr1, string pccSuplAddr2, string pccSuplAddr3, string pccSuplTelNo1, string pccSuplTelNo2, string pccSuplFaxNo, Int32 pccSlipPrtDiv, string pccSlipPrtDivName, Int32 pccSlipRePrtDiv, string pccSlipRePrtDivName, Int32 prtSelPrmDspDiv, string prtSelPrmDspDivName, Int32 stckStDspDiv, string stckStDspDivName, string stckStComment1, string stckStComment2, string stckStComment3, Int32 warehouseDspDiv, Int32 cancelDspDiv, Int32 goodsNoDspDivOd, Int32 listPrcDspDivOd, Int32 costDspDivOd, Int32 shelfDspDivOd, Int32 stockDspDivOd, Int32 commentDspDivOd, Int32 spmtCntDspDivOd, Int32 acptCntDspDivOd, Int32 prtSelGdNoDspDivOd, Int32 prtSelLsPrDspDivOd, Int32 prtSelSelfDspDivOd, Int32 prtSelStckDspDivOd, Int32 warehouseDspDivOd, Int32 cancelDspDivOd, Int32 inqOdrDspDivSet, string warehouseDspDivName, string cancelDspDivName, string goodsNoDspDivOdName, string listPrcDspDivOdName, string costDspDivOdName, string shelfDspDivOdName, string stockDspDivOdName, string commentDspDivOdName, string spmtCntDspDivOdName, string acptCntDspDivOdName, string prtSelGdNoDspDivOdName, string prtSelLsPrDspDivOdName, string prtSelSelfDspDivOdName, string prtSelStckDspDivOdName, string warehouseDspDivOdName, string cancelDspDivOdName, string inqOdrDspDivSetName, string pccPriWarehouseCd4)// DEL 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ�
        // UPD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
        // UPD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
        // 2014/09/04 UPD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
        //public PccCmpnySt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, string pccCompanyName, string pccWarehouseCd, string pccWarehouseNm, string pccPriWarehouseCd1, string pccPriWarehouseCd2, string pccPriWarehouseCd3, Int32 goodsNoDspDiv, string goodsNoDspDivName, Int32 listPrcDspDiv, string listPrcDspDivName, Int32 costDspDiv, string costDspDivName, Int32 shelfDspDiv, string shelfDspDivName, Int32 stockDspDiv, string stockDspDivName, Int32 commentDspDiv, string commentDspDivName, Int32 spmtCntDspDiv, string spmtCntDspDivName, Int32 acptCntDspDiv, string acptCntDspDivName, Int32 prtSelGdNoDspDiv, string prtSelGdNoDspDivName, Int32 prtSelLsPrDspDiv, string prtSelLsPrDspDivName, Int32 prtSelSelfDspDiv, string prtSelSelfDspDivName, Int32 prtSelStckDspDiv, string prtSelStckDspDivName, string stckStMark1, string stckStMark2, string stckStMark3, string pccSuplName1, string pccSuplName2, string pccSuplKana, string pccSuplSnm, string pccSuplPostNo, string pccSuplAddr1, string pccSuplAddr2, string pccSuplAddr3, string pccSuplTelNo1, string pccSuplTelNo2, string pccSuplFaxNo, Int32 pccSlipPrtDiv, string pccSlipPrtDivName, Int32 pccSlipRePrtDiv, string pccSlipRePrtDivName, Int32 prtSelPrmDspDiv, string prtSelPrmDspDivName, Int32 stckStDspDiv, string stckStDspDivName, string stckStComment1, string stckStComment2, string stckStComment3, Int32 warehouseDspDiv, Int32 cancelDspDiv, Int32 goodsNoDspDivOd, Int32 listPrcDspDivOd, Int32 costDspDivOd, Int32 shelfDspDivOd, Int32 stockDspDivOd, Int32 commentDspDivOd, Int32 spmtCntDspDivOd, Int32 acptCntDspDivOd, Int32 prtSelGdNoDspDivOd, Int32 prtSelLsPrDspDivOd, Int32 prtSelSelfDspDivOd, Int32 prtSelStckDspDivOd, Int32 warehouseDspDivOd, Int32 cancelDspDivOd, Int32 inqOdrDspDivSet, string warehouseDspDivName, string cancelDspDivName, string goodsNoDspDivOdName, string listPrcDspDivOdName, string costDspDivOdName, string shelfDspDivOdName, string stockDspDivOdName, string commentDspDivOdName, string spmtCntDspDivOdName, string acptCntDspDivOdName, string prtSelGdNoDspDivOdName, string prtSelLsPrDspDivOdName, string prtSelSelfDspDivOdName, string prtSelStckDspDivOdName, string warehouseDspDivOdName, string cancelDspDivOdName, string inqOdrDspDivSetName, string pccPriWarehouseCd4, Int16 prsntStkCtDspDivOd, string prsntStkCtDspDivOdName, Int16 prsntStkCtDspDiv, string prsntStkCtDspDivName)// ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ�
        public PccCmpnySt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, string pccCompanyName, string pccWarehouseCd, string pccWarehouseNm, string pccPriWarehouseCd1, string pccPriWarehouseCd2, string pccPriWarehouseCd3, Int32 goodsNoDspDiv, string goodsNoDspDivName, Int32 listPrcDspDiv, string listPrcDspDivName, Int32 costDspDiv, string costDspDivName, Int32 shelfDspDiv, string shelfDspDivName, Int32 stockDspDiv, string stockDspDivName, Int32 commentDspDiv, string commentDspDivName, Int32 spmtCntDspDiv, string spmtCntDspDivName, Int32 acptCntDspDiv, string acptCntDspDivName, Int32 prtSelGdNoDspDiv, string prtSelGdNoDspDivName, Int32 prtSelLsPrDspDiv, string prtSelLsPrDspDivName, Int32 prtSelSelfDspDiv, string prtSelSelfDspDivName, Int32 prtSelStckDspDiv, string prtSelStckDspDivName, string stckStMark1, string stckStMark2, string stckStMark3, string pccSuplName1, string pccSuplName2, string pccSuplKana, string pccSuplSnm, string pccSuplPostNo, string pccSuplAddr1, string pccSuplAddr2, string pccSuplAddr3, string pccSuplTelNo1, string pccSuplTelNo2, string pccSuplFaxNo, Int32 pccSlipPrtDiv, string pccSlipPrtDivName, Int32 pccSlipRePrtDiv, string pccSlipRePrtDivName, Int32 prtSelPrmDspDiv, string prtSelPrmDspDivName, Int32 stckStDspDiv, string stckStDspDivName, string stckStComment1, string stckStComment2, string stckStComment3, Int32 warehouseDspDiv, Int32 cancelDspDiv, Int32 goodsNoDspDivOd, Int32 listPrcDspDivOd, Int32 costDspDivOd, Int32 shelfDspDivOd, Int32 stockDspDivOd, Int32 commentDspDivOd, Int32 spmtCntDspDivOd, Int32 acptCntDspDivOd, Int32 prtSelGdNoDspDivOd, Int32 prtSelLsPrDspDivOd, Int32 prtSelSelfDspDivOd, Int32 prtSelStckDspDivOd, Int32 warehouseDspDivOd, Int32 cancelDspDivOd, Int32 inqOdrDspDivSet, string warehouseDspDivName, string cancelDspDivName, string goodsNoDspDivOdName, string listPrcDspDivOdName, string costDspDivOdName, string shelfDspDivOdName, string stockDspDivOdName, string commentDspDivOdName, string spmtCntDspDivOdName, string acptCntDspDivOdName, string prtSelGdNoDspDivOdName, string prtSelLsPrDspDivOdName, string prtSelSelfDspDivOdName, string prtSelStckDspDivOdName, string warehouseDspDivOdName, string cancelDspDivOdName, string inqOdrDspDivSetName, string pccPriWarehouseCd4, Int16 prsntStkCtDspDivOd, string prsntStkCtDspDivOdName, Int16 prsntStkCtDspDiv, string prsntStkCtDspDivName, Int16 ansDeliDtDspDiv, string ansDeliDtDspDivName, Int16 ansDeliDtDspDivOd, string ansDeliDtDspDivOdName)
        // 2014/09/04 UPD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._pccCompanyCode = pccCompanyCode;
            this._pccCompanyName = pccCompanyName;
            this._pccWarehouseCd = pccWarehouseCd;
            this._pccWarehouseNm = pccWarehouseNm;
            this._pccPriWarehouseCd1 = pccPriWarehouseCd1;
            this._pccPriWarehouseCd2 = pccPriWarehouseCd2;
            this._pccPriWarehouseCd3 = pccPriWarehouseCd3;
            this._goodsNoDspDiv = goodsNoDspDiv;
            this._goodsNoDspDivName = goodsNoDspDivName;
            this._listPrcDspDiv = listPrcDspDiv;
            this._listPrcDspDivName = listPrcDspDivName;
            this._costDspDiv = costDspDiv;
            this._costDspDivName = costDspDivName;
            this._shelfDspDiv = shelfDspDiv;
            this._shelfDspDivName = shelfDspDivName;
            this._stockDspDiv = stockDspDiv;
            this._stockDspDivName = stockDspDivName;
            this._commentDspDiv = commentDspDiv;
            this._commentDspDivName = commentDspDivName;
            this._spmtCntDspDiv = spmtCntDspDiv;
            this._spmtCntDspDivName = spmtCntDspDivName;
            this._acptCntDspDiv = acptCntDspDiv;
            this._acptCntDspDivName = acptCntDspDivName;
            this._prtSelGdNoDspDiv = prtSelGdNoDspDiv;
            this._prtSelGdNoDspDivName = prtSelGdNoDspDivName;
            this._prtSelLsPrDspDiv = prtSelLsPrDspDiv;
            this._prtSelLsPrDspDivName = prtSelLsPrDspDivName;
            this._prtSelSelfDspDiv = prtSelSelfDspDiv;
            this._prtSelSelfDspDivName = prtSelSelfDspDivName;
            this._prtSelStckDspDiv = prtSelStckDspDiv;
            this._prtSelStckDspDivName = prtSelStckDspDivName;
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
            this._pccSlipPrtDivName = pccSlipPrtDivName;
            this._pccSlipRePrtDiv = pccSlipRePrtDiv;
            this._pccSlipRePrtDivName = pccSlipRePrtDivName;
            this._prtSelPrmDspDiv = prtSelPrmDspDiv;
            this._prtSelPrmDspDivName = prtSelPrmDspDivName;
            this._stckStDspDiv = stckStDspDiv;
            this._stckStDspDivName = stckStDspDivName;
            this._stckStComment1 = stckStComment1;
            this._stckStComment2 = stckStComment2;
            this._stckStComment3 = stckStComment3;
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� 2013/03/06�z�M-------------------------------------------->>>>>
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
            this._warehouseDspDivName = warehouseDspDivName;
            this._cancelDspDivName = cancelDspDivName;
            this._goodsNoDspDivOdName = goodsNoDspDivOdName;
            this._listPrcDspDivOdName = listPrcDspDivOdName;
            this._costDspDivOdName = costDspDivOdName;
            this._shelfDspDivOdName = shelfDspDivOdName;
            this._stockDspDivOdName = stockDspDivOdName;
            this._commentDspDivOdName = commentDspDivOdName;
            this._spmtCntDspDivOdName = spmtCntDspDivOdName;
            this._acptCntDspDivOdName = acptCntDspDivOdName;
            this._prtSelGdNoDspDivOdName = prtSelGdNoDspDivOdName;
            this._prtSelLsPrDspDivOdName = prtSelLsPrDspDivOdName;
            this._prtSelSelfDspDivOdName = prtSelSelfDspDivOdName;
            this._prtSelStckDspDivOdName = prtSelStckDspDivOdName;
            this._warehouseDspDivOdName = warehouseDspDivOdName;
            this._cancelDspDivOdName = cancelDspDivOdName;
            this._inqOdrDspDivSetName = inqOdrDspDivSetName;
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            this._pccPriWarehouseCd4 = pccPriWarehouseCd4;
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            this._prsntStkCtDspDivOd = prsntStkCtDspDivOd;
            this._prsntStkCtDspDivOdName = prsntStkCtDspDivOdName;
            this._prsntStkCtDspDiv = prsntStkCtDspDiv;
            this._prsntStkCtDspDivName = prsntStkCtDspDivName;
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            this._ansDeliDtDspDiv = ansDeliDtDspDiv;
            this._ansDeliDtDspDivName = ansDeliDtDspDivName;
            this._ansDeliDtDspDivOd = ansDeliDtDspDivOd;
            this._ansDeliDtDspDivOdName = ansDeliDtDspDivOdName;
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^��������
        /// </summary>
        /// <returns>PccCmpnySt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PccCmpnySt�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccCmpnySt Clone()
        {
            // UPD 2013/02/12 SCM��Q��10342,10343�Ή� 2013/03/06�z�M-------------------------------------------->>>>>
            //return new PccCmpnySt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._pccCompanyName, this._pccWarehouseCd, this._pccWarehouseNm, this._pccPriWarehouseCd1, this._pccPriWarehouseCd2, this._pccPriWarehouseCd3, this._goodsNoDspDiv, this._goodsNoDspDivName, this._listPrcDspDiv, this._listPrcDspDivName, this._costDspDiv, this._costDspDivName, this._shelfDspDiv, this._shelfDspDivName, this._stockDspDiv, this._stockDspDivName, this._commentDspDiv, this._commentDspDivName, this._spmtCntDspDiv, this._spmtCntDspDivName, this._acptCntDspDiv, this._acptCntDspDivName, this._prtSelGdNoDspDiv, this._prtSelGdNoDspDivName, this._prtSelLsPrDspDiv, this._prtSelLsPrDspDivName, this._prtSelSelfDspDiv, this._prtSelSelfDspDivName, this._prtSelStckDspDiv, this._prtSelStckDspDivName, this._stckStMark1, this._stckStMark2, this._stckStMark3, this._pccSuplName1, this._pccSuplName2, this._pccSuplKana, this._pccSuplSnm, this._pccSuplPostNo, this._pccSuplAddr1, this._pccSuplAddr2, this._pccSuplAddr3, this._pccSuplTelNo1, this._pccSuplTelNo2, this._pccSuplFaxNo, this._pccSlipPrtDiv, this._pccSlipPrtDivName, this._pccSlipRePrtDiv, this._pccSlipRePrtDivName, this._prtSelPrmDspDiv, this._prtSelPrmDspDivName, this._stckStDspDiv, this._stckStDspDivName, this._stckStComment1, this._stckStComment2, this._stckStComment3);
            // UPD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            //return new PccCmpnySt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._pccCompanyName, this._pccWarehouseCd, this._pccWarehouseNm, this._pccPriWarehouseCd1, this._pccPriWarehouseCd2, this._pccPriWarehouseCd3, this._goodsNoDspDiv, this._goodsNoDspDivName, this._listPrcDspDiv, this._listPrcDspDivName, this._costDspDiv, this._costDspDivName, this._shelfDspDiv, this._shelfDspDivName, this._stockDspDiv, this._stockDspDivName, this._commentDspDiv, this._commentDspDivName, this._spmtCntDspDiv, this._spmtCntDspDivName, this._acptCntDspDiv, this._acptCntDspDivName, this._prtSelGdNoDspDiv, this._prtSelGdNoDspDivName, this._prtSelLsPrDspDiv, this._prtSelLsPrDspDivName, this._prtSelSelfDspDiv, this._prtSelSelfDspDivName, this._prtSelStckDspDiv, this._prtSelStckDspDivName, this._stckStMark1, this._stckStMark2, this._stckStMark3, this._pccSuplName1, this._pccSuplName2, this._pccSuplKana, this._pccSuplSnm, this._pccSuplPostNo, this._pccSuplAddr1, this._pccSuplAddr2, this._pccSuplAddr3, this._pccSuplTelNo1, this._pccSuplTelNo2, this._pccSuplFaxNo, this._pccSlipPrtDiv, this._pccSlipPrtDivName, this._pccSlipRePrtDiv, this._pccSlipRePrtDivName, this._prtSelPrmDspDiv, this._prtSelPrmDspDivName, this._stckStDspDiv, this._stckStDspDivName, this._stckStComment1, this._stckStComment2, this._stckStComment3, this._warehouseDspDiv, this._cancelDspDiv, this._goodsNoDspDivOd, this._listPrcDspDivOd, this._costDspDivOd, this._shelfDspDivOd, this._stockDspDivOd, this._commentDspDivOd, this._spmtCntDspDivOd, this._acptCntDspDivOd, this._prtSelGdNoDspDivOd, this._prtSelLsPrDspDivOd, this._prtSelSelfDspDivOd, this._prtSelStckDspDivOd, this._warehouseDspDivOd, this._cancelDspDivOd, this._inqOdrDspDivSet, this._warehouseDspDivName, this._cancelDspDivName, this._goodsNoDspDivOdName, this._listPrcDspDivOdName, this._costDspDivOdName, this._shelfDspDivOdName, this._stockDspDivOdName, this._commentDspDivOdName, this._spmtCntDspDivOdName, this._acptCntDspDivOdName, this._prtSelGdNoDspDivOdName, this._prtSelLsPrDspDivOdName, this._prtSelSelfDspDivOdName, this._prtSelStckDspDivOdName, this._warehouseDspDivOdName, this._cancelDspDivOdName, this._inqOdrDspDivSetName);
            //return new PccCmpnySt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._pccCompanyName, this._pccWarehouseCd, this._pccWarehouseNm, this._pccPriWarehouseCd1, this._pccPriWarehouseCd2, this._pccPriWarehouseCd3, this._goodsNoDspDiv, this._goodsNoDspDivName, this._listPrcDspDiv, this._listPrcDspDivName, this._costDspDiv, this._costDspDivName, this._shelfDspDiv, this._shelfDspDivName, this._stockDspDiv, this._stockDspDivName, this._commentDspDiv, this._commentDspDivName, this._spmtCntDspDiv, this._spmtCntDspDivName, this._acptCntDspDiv, this._acptCntDspDivName, this._prtSelGdNoDspDiv, this._prtSelGdNoDspDivName, this._prtSelLsPrDspDiv, this._prtSelLsPrDspDivName, this._prtSelSelfDspDiv, this._prtSelSelfDspDivName, this._prtSelStckDspDiv, this._prtSelStckDspDivName, this._stckStMark1, this._stckStMark2, this._stckStMark3, this._pccSuplName1, this._pccSuplName2, this._pccSuplKana, this._pccSuplSnm, this._pccSuplPostNo, this._pccSuplAddr1, this._pccSuplAddr2, this._pccSuplAddr3, this._pccSuplTelNo1, this._pccSuplTelNo2, this._pccSuplFaxNo, this._pccSlipPrtDiv, this._pccSlipPrtDivName, this._pccSlipRePrtDiv, this._pccSlipRePrtDivName, this._prtSelPrmDspDiv, this._prtSelPrmDspDivName, this._stckStDspDiv, this._stckStDspDivName, this._stckStComment1, this._stckStComment2, this._stckStComment3, this._warehouseDspDiv, this._cancelDspDiv, this._goodsNoDspDivOd, this._listPrcDspDivOd, this._costDspDivOd, this._shelfDspDivOd, this._stockDspDivOd, this._commentDspDivOd, this._spmtCntDspDivOd, this._acptCntDspDivOd, this._prtSelGdNoDspDivOd, this._prtSelLsPrDspDivOd, this._prtSelSelfDspDivOd, this._prtSelStckDspDivOd, this._warehouseDspDivOd, this._cancelDspDivOd, this._inqOdrDspDivSet, this._warehouseDspDivName, this._cancelDspDivName, this._goodsNoDspDivOdName, this._listPrcDspDivOdName, this._costDspDivOdName, this._shelfDspDivOdName, this._stockDspDivOdName, this._commentDspDivOdName, this._spmtCntDspDivOdName, this._acptCntDspDivOdName, this._prtSelGdNoDspDivOdName, this._prtSelLsPrDspDivOdName, this._prtSelSelfDspDivOdName, this._prtSelStckDspDivOdName, this._warehouseDspDivOdName, this._cancelDspDivOdName, this._inqOdrDspDivSetName, this._pccPriWarehouseCd4);// DEL 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ�
            // UPD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            // UPD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
            // 2014/09/04 UPD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            //return new PccCmpnySt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._pccCompanyName, this._pccWarehouseCd, this._pccWarehouseNm, this._pccPriWarehouseCd1, this._pccPriWarehouseCd2, this._pccPriWarehouseCd3, this._goodsNoDspDiv, this._goodsNoDspDivName, this._listPrcDspDiv, this._listPrcDspDivName, this._costDspDiv, this._costDspDivName, this._shelfDspDiv, this._shelfDspDivName, this._stockDspDiv, this._stockDspDivName, this._commentDspDiv, this._commentDspDivName, this._spmtCntDspDiv, this._spmtCntDspDivName, this._acptCntDspDiv, this._acptCntDspDivName, this._prtSelGdNoDspDiv, this._prtSelGdNoDspDivName, this._prtSelLsPrDspDiv, this._prtSelLsPrDspDivName, this._prtSelSelfDspDiv, this._prtSelSelfDspDivName, this._prtSelStckDspDiv, this._prtSelStckDspDivName, this._stckStMark1, this._stckStMark2, this._stckStMark3, this._pccSuplName1, this._pccSuplName2, this._pccSuplKana, this._pccSuplSnm, this._pccSuplPostNo, this._pccSuplAddr1, this._pccSuplAddr2, this._pccSuplAddr3, this._pccSuplTelNo1, this._pccSuplTelNo2, this._pccSuplFaxNo, this._pccSlipPrtDiv, this._pccSlipPrtDivName, this._pccSlipRePrtDiv, this._pccSlipRePrtDivName, this._prtSelPrmDspDiv, this._prtSelPrmDspDivName, this._stckStDspDiv, this._stckStDspDivName, this._stckStComment1, this._stckStComment2, this._stckStComment3, this._warehouseDspDiv, this._cancelDspDiv, this._goodsNoDspDivOd, this._listPrcDspDivOd, this._costDspDivOd, this._shelfDspDivOd, this._stockDspDivOd, this._commentDspDivOd, this._spmtCntDspDivOd, this._acptCntDspDivOd, this._prtSelGdNoDspDivOd, this._prtSelLsPrDspDivOd, this._prtSelSelfDspDivOd, this._prtSelStckDspDivOd, this._warehouseDspDivOd, this._cancelDspDivOd, this._inqOdrDspDivSet, this._warehouseDspDivName, this._cancelDspDivName, this._goodsNoDspDivOdName, this._listPrcDspDivOdName, this._costDspDivOdName, this._shelfDspDivOdName, this._stockDspDivOdName, this._commentDspDivOdName, this._spmtCntDspDivOdName, this._acptCntDspDivOdName, this._prtSelGdNoDspDivOdName, this._prtSelLsPrDspDivOdName, this._prtSelSelfDspDivOdName, this._prtSelStckDspDivOdName, this._warehouseDspDivOdName, this._cancelDspDivOdName, this._inqOdrDspDivSetName, this._pccPriWarehouseCd4, this._prsntStkCtDspDivOd, this._prsntStkCtDspDivOdName, this._prsntStkCtDspDiv, this._prsntStkCtDspDivName);// ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ�
            return new PccCmpnySt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._pccCompanyName, this._pccWarehouseCd, this._pccWarehouseNm, this._pccPriWarehouseCd1, this._pccPriWarehouseCd2, this._pccPriWarehouseCd3, this._goodsNoDspDiv, this._goodsNoDspDivName, this._listPrcDspDiv, this._listPrcDspDivName, this._costDspDiv, this._costDspDivName, this._shelfDspDiv, this._shelfDspDivName, this._stockDspDiv, this._stockDspDivName, this._commentDspDiv, this._commentDspDivName, this._spmtCntDspDiv, this._spmtCntDspDivName, this._acptCntDspDiv, this._acptCntDspDivName, this._prtSelGdNoDspDiv, this._prtSelGdNoDspDivName, this._prtSelLsPrDspDiv, this._prtSelLsPrDspDivName, this._prtSelSelfDspDiv, this._prtSelSelfDspDivName, this._prtSelStckDspDiv, this._prtSelStckDspDivName, this._stckStMark1, this._stckStMark2, this._stckStMark3, this._pccSuplName1, this._pccSuplName2, this._pccSuplKana, this._pccSuplSnm, this._pccSuplPostNo, this._pccSuplAddr1, this._pccSuplAddr2, this._pccSuplAddr3, this._pccSuplTelNo1, this._pccSuplTelNo2, this._pccSuplFaxNo, this._pccSlipPrtDiv, this._pccSlipPrtDivName, this._pccSlipRePrtDiv, this._pccSlipRePrtDivName, this._prtSelPrmDspDiv, this._prtSelPrmDspDivName, this._stckStDspDiv, this._stckStDspDivName, this._stckStComment1, this._stckStComment2, this._stckStComment3, this._warehouseDspDiv, this._cancelDspDiv, this._goodsNoDspDivOd, this._listPrcDspDivOd, this._costDspDivOd, this._shelfDspDivOd, this._stockDspDivOd, this._commentDspDivOd, this._spmtCntDspDivOd, this._acptCntDspDivOd, this._prtSelGdNoDspDivOd, this._prtSelLsPrDspDivOd, this._prtSelSelfDspDivOd, this._prtSelStckDspDivOd, this._warehouseDspDivOd, this._cancelDspDivOd, this._inqOdrDspDivSet, this._warehouseDspDivName, this._cancelDspDivName, this._goodsNoDspDivOdName, this._listPrcDspDivOdName, this._costDspDivOdName, this._shelfDspDivOdName, this._stockDspDivOdName, this._commentDspDivOdName, this._spmtCntDspDivOdName, this._acptCntDspDivOdName, this._prtSelGdNoDspDivOdName, this._prtSelLsPrDspDivOdName, this._prtSelSelfDspDivOdName, this._prtSelStckDspDivOdName, this._warehouseDspDivOdName, this._cancelDspDivOdName, this._inqOdrDspDivSetName, this._pccPriWarehouseCd4, this._prsntStkCtDspDivOd, this._prsntStkCtDspDivOdName, this._prsntStkCtDspDiv, this._prsntStkCtDspDivName, this._ansDeliDtDspDiv, this._ansDeliDtDspDivName, this._ansDeliDtDspDivOd, this._ansDeliDtDspDivOdName);//@@@@20230303
            // 2014/09/04 UPD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PccCmpnySt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnySt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PccCmpnySt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim())//@@@@20230303
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.PccCompanyCode == target.PccCompanyCode)
                 && (this.PccCompanyName == target.PccCompanyName)
                 && (this.PccWarehouseCd == target.PccWarehouseCd)
                 && (this.PccWarehouseNm == target.PccWarehouseNm)
                 && (this.PccPriWarehouseCd1 == target.PccPriWarehouseCd1)
                 && (this.PccPriWarehouseCd2 == target.PccPriWarehouseCd2)
                 && (this.PccPriWarehouseCd3 == target.PccPriWarehouseCd3)
                 && (this.GoodsNoDspDiv == target.GoodsNoDspDiv)
                 && (this.GoodsNoDspDivName == target.GoodsNoDspDivName)
                 && (this.ListPrcDspDiv == target.ListPrcDspDiv)
                 && (this.ListPrcDspDivName == target.ListPrcDspDivName)
                 && (this.CostDspDiv == target.CostDspDiv)
                 && (this.CostDspDivName == target.CostDspDivName)
                 && (this.ShelfDspDiv == target.ShelfDspDiv)
                 && (this.ShelfDspDivName == target.ShelfDspDivName)
                 && (this.StockDspDiv == target.StockDspDiv)
                 && (this.StockDspDivName == target.StockDspDivName)
                 && (this.CommentDspDiv == target.CommentDspDiv)
                 && (this.CommentDspDivName == target.CommentDspDivName)
                 && (this.SpmtCntDspDiv == target.SpmtCntDspDiv)
                 && (this.SpmtCntDspDivName == target.SpmtCntDspDivName)
                 && (this.AcptCntDspDiv == target.AcptCntDspDiv)
                 && (this.AcptCntDspDivName == target.AcptCntDspDivName)
                 && (this.PrtSelGdNoDspDiv == target.PrtSelGdNoDspDiv)
                 && (this.PrtSelGdNoDspDivName == target.PrtSelGdNoDspDivName)
                 && (this.PrtSelLsPrDspDiv == target.PrtSelLsPrDspDiv)
                 && (this.PrtSelLsPrDspDivName == target.PrtSelLsPrDspDivName)
                 && (this.PrtSelSelfDspDiv == target.PrtSelSelfDspDiv)
                 && (this.PrtSelSelfDspDivName == target.PrtSelSelfDspDivName)
                 && (this.PrtSelStckDspDiv == target.PrtSelStckDspDiv)
                 && (this.PrtSelStckDspDivName == target.PrtSelStckDspDivName)
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
                 && (this.PccSlipPrtDivName == target.PccSlipPrtDivName)
                 && (this.PccSlipRePrtDiv == target.PccSlipRePrtDiv)
                 && (this.PccSlipRePrtDivName == target.PccSlipRePrtDivName)
                 && (this.PrtSelPrmDspDiv == target.PrtSelPrmDspDiv)
                 && (this.PrtSelPrmDspDivName == target.PrtSelPrmDspDivName)
                 && (this.StckStDspDiv == target.StckStDspDiv)
                 && (this.StckStDspDivName == target.StckStDspDivName)
                 && (this.StckStComment1 == target.StckStComment1)
                 && (this.StckStComment2 == target.StckStComment2)
                // UPD 2013/02/12 SCM��Q��10342,10343�Ή� 2013/03/06�z�M-------------------------------------------->>>>>
                //&& (this.StckStComment3 == target.StckStComment3));
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
                 && (this.WarehouseDspDivName == target.WarehouseDspDivName)
                 && (this.CancelDspDivName == target.CancelDspDivName)
                 && (this.GoodsNoDspDivOdName == target.GoodsNoDspDivOdName)
                 && (this.ListPrcDspDivOdName == target.ListPrcDspDivOdName)
                 && (this.CostDspDivOdName == target.CostDspDivOdName)
                 && (this.ShelfDspDivOdName == target.ShelfDspDivOdName)
                 && (this.StockDspDivOdName == target.StockDspDivOdName)
                 && (this.CommentDspDivOdName == target.CommentDspDivOdName)
                 && (this.SpmtCntDspDivOdName == target.SpmtCntDspDivOdName)
                 && (this.AcptCntDspDivOdName == target.AcptCntDspDivOdName)
                 && (this.PrtSelGdNoDspDivOdName == target.PrtSelGdNoDspDivOdName)
                 && (this.PrtSelLsPrDspDivOdName == target.PrtSelLsPrDspDivOdName)
                 && (this.PrtSelSelfDspDivOdName == target.PrtSelSelfDspDivOdName)
                 && (this.PrtSelStckDspDivOdName == target.PrtSelStckDspDivOdName)
                 && (this.WarehouseDspDivOdName == target.WarehouseDspDivOdName)
                 && (this.CancelDspDivOdName == target.CancelDspDivOdName)
                 && (this.InqOdrDspDivSetName == target.InqOdrDspDivSetName)
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                 && (this.PccPriWarehouseCd4 == target.PccPriWarehouseCd4)
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                 && (this.PrsntStkCtDspDivOd == target.PrsntStkCtDspDivOd)
                 && (this.PrsntStkCtDspDivOdName == target.PrsntStkCtDspDivOdName)
                 && (this.PrsntStkCtDspDiv == target.PrsntStkCtDspDiv)
                 && (this.PrsntStkCtDspDivName == target.PrsntStkCtDspDivName)
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                 && (this.AnsDeliDtDspDiv == target.AnsDeliDtDspDiv)
                 && (this.AnsDeliDtDspDivName == target.AnsDeliDtDspDivName)
                 && (this.AnsDeliDtDspDivOd == target.AnsDeliDtDspDivOd)
                 && (this.AnsDeliDtDspDivOdName == target.AnsDeliDtDspDivOdName)
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
                );
            // UPD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^��r����
        /// </summary>
        /// <param name="pccCmpnySt1">
        ///                    ��r����PccCmpnySt�N���X�̃C���X�^���X
        /// </param>
        /// <param name="pccCmpnySt2">��r����PccCmpnySt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnySt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(PccCmpnySt pccCmpnySt1, PccCmpnySt pccCmpnySt2)
        {
            return ((pccCmpnySt1.CreateDateTime == pccCmpnySt2.CreateDateTime)
                 && (pccCmpnySt1.UpdateDateTime == pccCmpnySt2.UpdateDateTime)
                 && (pccCmpnySt1.LogicalDeleteCode == pccCmpnySt2.LogicalDeleteCode)
                 && (pccCmpnySt1.InqOriginalEpCd.Trim() == pccCmpnySt2.InqOriginalEpCd.Trim())//@@@@20230303
                 && (pccCmpnySt1.InqOriginalSecCd == pccCmpnySt2.InqOriginalSecCd)
                 && (pccCmpnySt1.InqOtherEpCd == pccCmpnySt2.InqOtherEpCd)
                 && (pccCmpnySt1.InqOtherSecCd == pccCmpnySt2.InqOtherSecCd)
                 && (pccCmpnySt1.PccCompanyCode == pccCmpnySt2.PccCompanyCode)
                 && (pccCmpnySt1.PccCompanyName == pccCmpnySt2.PccCompanyName)
                 && (pccCmpnySt1.PccWarehouseCd == pccCmpnySt2.PccWarehouseCd)
                 && (pccCmpnySt1.PccWarehouseNm == pccCmpnySt2.PccWarehouseNm)
                 && (pccCmpnySt1.PccPriWarehouseCd1 == pccCmpnySt2.PccPriWarehouseCd1)
                 && (pccCmpnySt1.PccPriWarehouseCd2 == pccCmpnySt2.PccPriWarehouseCd2)
                 && (pccCmpnySt1.PccPriWarehouseCd3 == pccCmpnySt2.PccPriWarehouseCd3)
                 && (pccCmpnySt1.GoodsNoDspDiv == pccCmpnySt2.GoodsNoDspDiv)
                 && (pccCmpnySt1.GoodsNoDspDivName == pccCmpnySt2.GoodsNoDspDivName)
                 && (pccCmpnySt1.ListPrcDspDiv == pccCmpnySt2.ListPrcDspDiv)
                 && (pccCmpnySt1.ListPrcDspDivName == pccCmpnySt2.ListPrcDspDivName)
                 && (pccCmpnySt1.CostDspDiv == pccCmpnySt2.CostDspDiv)
                 && (pccCmpnySt1.CostDspDivName == pccCmpnySt2.CostDspDivName)
                 && (pccCmpnySt1.ShelfDspDiv == pccCmpnySt2.ShelfDspDiv)
                 && (pccCmpnySt1.ShelfDspDivName == pccCmpnySt2.ShelfDspDivName)
                 && (pccCmpnySt1.StockDspDiv == pccCmpnySt2.StockDspDiv)
                 && (pccCmpnySt1.StockDspDivName == pccCmpnySt2.StockDspDivName)
                 && (pccCmpnySt1.CommentDspDiv == pccCmpnySt2.CommentDspDiv)
                 && (pccCmpnySt1.CommentDspDivName == pccCmpnySt2.CommentDspDivName)
                 && (pccCmpnySt1.SpmtCntDspDiv == pccCmpnySt2.SpmtCntDspDiv)
                 && (pccCmpnySt1.SpmtCntDspDivName == pccCmpnySt2.SpmtCntDspDivName)
                 && (pccCmpnySt1.AcptCntDspDiv == pccCmpnySt2.AcptCntDspDiv)
                 && (pccCmpnySt1.AcptCntDspDivName == pccCmpnySt2.AcptCntDspDivName)
                 && (pccCmpnySt1.PrtSelGdNoDspDiv == pccCmpnySt2.PrtSelGdNoDspDiv)
                 && (pccCmpnySt1.PrtSelGdNoDspDivName == pccCmpnySt2.PrtSelGdNoDspDivName)
                 && (pccCmpnySt1.PrtSelLsPrDspDiv == pccCmpnySt2.PrtSelLsPrDspDiv)
                 && (pccCmpnySt1.PrtSelLsPrDspDivName == pccCmpnySt2.PrtSelLsPrDspDivName)
                 && (pccCmpnySt1.PrtSelSelfDspDiv == pccCmpnySt2.PrtSelSelfDspDiv)
                 && (pccCmpnySt1.PrtSelSelfDspDivName == pccCmpnySt2.PrtSelSelfDspDivName)
                 && (pccCmpnySt1.PrtSelStckDspDiv == pccCmpnySt2.PrtSelStckDspDiv)
                 && (pccCmpnySt1.PrtSelStckDspDivName == pccCmpnySt2.PrtSelStckDspDivName)
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
                 && (pccCmpnySt1.PccSlipPrtDivName == pccCmpnySt2.PccSlipPrtDivName)
                 && (pccCmpnySt1.PccSlipRePrtDiv == pccCmpnySt2.PccSlipRePrtDiv)
                 && (pccCmpnySt1.PccSlipRePrtDivName == pccCmpnySt2.PccSlipRePrtDivName)
                 && (pccCmpnySt1.PrtSelPrmDspDiv == pccCmpnySt2.PrtSelPrmDspDiv)
                 && (pccCmpnySt1.PrtSelPrmDspDivName == pccCmpnySt2.PrtSelPrmDspDivName)
                 && (pccCmpnySt1.StckStDspDiv == pccCmpnySt2.StckStDspDiv)
                 && (pccCmpnySt1.StckStDspDivName == pccCmpnySt2.StckStDspDivName)
                 && (pccCmpnySt1.StckStComment1 == pccCmpnySt2.StckStComment1)
                 && (pccCmpnySt1.StckStComment2 == pccCmpnySt2.StckStComment2)
                // UPD 2013/02/12 SCM��Q��10342,10343�Ή� 2013/03/06�z�M-------------------------------------------->>>>>
                //&& (pccCmpnySt1.StckStComment3 == pccCmpnySt2.StckStComment3));
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
                 && (pccCmpnySt1.WarehouseDspDivName == pccCmpnySt2.WarehouseDspDivName)
                 && (pccCmpnySt1.CancelDspDivName == pccCmpnySt2.CancelDspDivName)
                 && (pccCmpnySt1.GoodsNoDspDivOdName == pccCmpnySt2.GoodsNoDspDivOdName)
                 && (pccCmpnySt1.ListPrcDspDivOdName == pccCmpnySt2.ListPrcDspDivOdName)
                 && (pccCmpnySt1.CostDspDivOdName == pccCmpnySt2.CostDspDivOdName)
                 && (pccCmpnySt1.ShelfDspDivOdName == pccCmpnySt2.ShelfDspDivOdName)
                 && (pccCmpnySt1.StockDspDivOdName == pccCmpnySt2.StockDspDivOdName)
                 && (pccCmpnySt1.CommentDspDivOdName == pccCmpnySt2.CommentDspDivOdName)
                 && (pccCmpnySt1.SpmtCntDspDivOdName == pccCmpnySt2.SpmtCntDspDivOdName)
                 && (pccCmpnySt1.AcptCntDspDivOdName == pccCmpnySt2.AcptCntDspDivOdName)
                 && (pccCmpnySt1.PrtSelGdNoDspDivOdName == pccCmpnySt2.PrtSelGdNoDspDivOdName)
                 && (pccCmpnySt1.PrtSelLsPrDspDivOdName == pccCmpnySt2.PrtSelLsPrDspDivOdName)
                 && (pccCmpnySt1.PrtSelSelfDspDivOdName == pccCmpnySt2.PrtSelSelfDspDivOdName)
                 && (pccCmpnySt1.PrtSelStckDspDivOdName == pccCmpnySt2.PrtSelStckDspDivOdName)
                 && (pccCmpnySt1.WarehouseDspDivOdName == pccCmpnySt2.WarehouseDspDivOdName)
                 && (pccCmpnySt1.CancelDspDivOdName == pccCmpnySt2.CancelDspDivOdName)
                 && (pccCmpnySt1.InqOdrDspDivSetName == pccCmpnySt2.InqOdrDspDivSetName)
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                 && (pccCmpnySt1.PccPriWarehouseCd4 == pccCmpnySt2.PccPriWarehouseCd4)
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
                 && (pccCmpnySt1.PrsntStkCtDspDivOd == pccCmpnySt2.PrsntStkCtDspDivOd)
                 && (pccCmpnySt1.PrsntStkCtDspDivOdName == pccCmpnySt2.PrsntStkCtDspDivOdName)
                 && (pccCmpnySt1.PrsntStkCtDspDiv == pccCmpnySt2.PrsntStkCtDspDiv)
                 && (pccCmpnySt1.PrsntStkCtDspDivName == pccCmpnySt2.PrsntStkCtDspDivName)
                // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
                 && (pccCmpnySt1.AnsDeliDtDspDiv == pccCmpnySt2.AnsDeliDtDspDiv)
                 && (pccCmpnySt1.AnsDeliDtDspDivName == pccCmpnySt2.AnsDeliDtDspDivName)
                 && (pccCmpnySt1.AnsDeliDtDspDivOd == pccCmpnySt2.AnsDeliDtDspDivOd)
                 && (pccCmpnySt1.AnsDeliDtDspDivOdName == pccCmpnySt2.AnsDeliDtDspDivOdName)
                // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
                 );
            // UPD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
        }
        /// <summary>
        /// PCC���Аݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PccCmpnySt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnySt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PccCmpnySt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.PccCompanyCode != target.PccCompanyCode) resList.Add("PccCompanyCode");
            if (this.PccCompanyName != target.PccCompanyName) resList.Add("PccCompanyName");
            if (this.PccWarehouseCd != target.PccWarehouseCd) resList.Add("PccWarehouseCd");
            if (this.PccWarehouseNm != target.PccWarehouseNm) resList.Add("PccWarehouseNm");
            if (this.PccPriWarehouseCd1 != target.PccPriWarehouseCd1) resList.Add("PccPriWarehouseCd1");
            if (this.PccPriWarehouseCd2 != target.PccPriWarehouseCd2) resList.Add("PccPriWarehouseCd2");
            if (this.PccPriWarehouseCd3 != target.PccPriWarehouseCd3) resList.Add("PccPriWarehouseCd3");
            if (this.GoodsNoDspDiv != target.GoodsNoDspDiv) resList.Add("GoodsNoDspDiv");
            if (this.GoodsNoDspDivName != target.GoodsNoDspDivName) resList.Add("GoodsNoDspDivName");
            if (this.ListPrcDspDiv != target.ListPrcDspDiv) resList.Add("ListPrcDspDiv");
            if (this.ListPrcDspDivName != target.ListPrcDspDivName) resList.Add("ListPrcDspDivName");
            if (this.CostDspDiv != target.CostDspDiv) resList.Add("CostDspDiv");
            if (this.CostDspDivName != target.CostDspDivName) resList.Add("CostDspDivName");
            if (this.ShelfDspDiv != target.ShelfDspDiv) resList.Add("ShelfDspDiv");
            if (this.ShelfDspDivName != target.ShelfDspDivName) resList.Add("ShelfDspDivName");
            if (this.StockDspDiv != target.StockDspDiv) resList.Add("StockDspDiv");
            if (this.StockDspDivName != target.StockDspDivName) resList.Add("StockDspDivName");
            if (this.CommentDspDiv != target.CommentDspDiv) resList.Add("CommentDspDiv");
            if (this.CommentDspDivName != target.CommentDspDivName) resList.Add("CommentDspDivName");
            if (this.SpmtCntDspDiv != target.SpmtCntDspDiv) resList.Add("SpmtCntDspDiv");
            if (this.SpmtCntDspDivName != target.SpmtCntDspDivName) resList.Add("SpmtCntDspDivName");
            if (this.AcptCntDspDiv != target.AcptCntDspDiv) resList.Add("AcptCntDspDiv");
            if (this.AcptCntDspDivName != target.AcptCntDspDivName) resList.Add("AcptCntDspDivName");
            if (this.PrtSelGdNoDspDiv != target.PrtSelGdNoDspDiv) resList.Add("PrtSelGdNoDspDiv");
            if (this.PrtSelGdNoDspDivName != target.PrtSelGdNoDspDivName) resList.Add("PrtSelGdNoDspDivName");
            if (this.PrtSelLsPrDspDiv != target.PrtSelLsPrDspDiv) resList.Add("PrtSelLsPrDspDiv");
            if (this.PrtSelLsPrDspDivName != target.PrtSelLsPrDspDivName) resList.Add("PrtSelLsPrDspDivName");
            if (this.PrtSelSelfDspDiv != target.PrtSelSelfDspDiv) resList.Add("PrtSelSelfDspDiv");
            if (this.PrtSelSelfDspDivName != target.PrtSelSelfDspDivName) resList.Add("PrtSelSelfDspDivName");
            if (this.PrtSelStckDspDiv != target.PrtSelStckDspDiv) resList.Add("PrtSelStckDspDiv");
            if (this.PrtSelStckDspDivName != target.PrtSelStckDspDivName) resList.Add("PrtSelStckDspDivName");
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
            if (this.PccSlipPrtDivName != target.PccSlipPrtDivName) resList.Add("PccSlipPrtDivName");
            if (this.PccSlipRePrtDiv != target.PccSlipRePrtDiv) resList.Add("PccSlipRePrtDiv");
            if (this.PccSlipRePrtDivName != target.PccSlipRePrtDivName) resList.Add("PccSlipRePrtDivName");
            if (this.PrtSelPrmDspDiv != target.PrtSelPrmDspDiv) resList.Add("PrtSelPrmDspDiv");
            if (this.PrtSelPrmDspDivName != target.PrtSelPrmDspDivName) resList.Add("PrtSelPrmDspDivName");
            if (this.StckStDspDiv != target.StckStDspDiv) resList.Add("StckStDspDiv");
            if (this.StckStDspDivName != target.StckStDspDivName) resList.Add("StckStDspDivName");
            if (this.StckStComment1 != target.StckStComment1) resList.Add("StckStComment1");
            if (this.StckStComment2 != target.StckStComment2) resList.Add("StckStComment2");
            if (this.StckStComment3 != target.StckStComment3) resList.Add("StckStComment3");
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� 2013/03/06�z�M-------------------------------------------->>>>>
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
            if (this.WarehouseDspDivName != target.WarehouseDspDivName) resList.Add("WarehouseDspDivName");
            if (this.CancelDspDivName != target.CancelDspDivName) resList.Add("CancelDspDivName");
            if (this.GoodsNoDspDivOdName != target.GoodsNoDspDivOdName) resList.Add("GoodsNoDspDivOdName");
            if (this.ListPrcDspDivOdName != target.ListPrcDspDivOdName) resList.Add("ListPrcDspDivOdName");
            if (this.CostDspDivOdName != target.CostDspDivOdName) resList.Add("CostDspDivOdName");
            if (this.ShelfDspDivOdName != target.ShelfDspDivOdName) resList.Add("ShelfDspDivOdName");
            if (this.StockDspDivOdName != target.StockDspDivOdName) resList.Add("StockDspDivOdName");
            if (this.CommentDspDivOdName != target.CommentDspDivOdName) resList.Add("CommentDspDivOdName");
            if (this.SpmtCntDspDivOdName != target.SpmtCntDspDivOdName) resList.Add("SpmtCntDspDivOdName");
            if (this.AcptCntDspDivOdName != target.AcptCntDspDivOdName) resList.Add("AcptCntDspDivOdName");
            if (this.PrtSelGdNoDspDivOdName != target.PrtSelGdNoDspDivOdName) resList.Add("PrtSelGdNoDspDivOdName");
            if (this.PrtSelLsPrDspDivOdName != target.PrtSelLsPrDspDivOdName) resList.Add("PrtSelLsPrDspDivOdName");
            if (this.PrtSelSelfDspDivOdName != target.PrtSelSelfDspDivOdName) resList.Add("PrtSelSelfDspDivOdName");
            if (this.PrtSelStckDspDivOdName != target.PrtSelStckDspDivOdName) resList.Add("PrtSelStckDspDivOdName");
            if (this.WarehouseDspDivOdName != target.WarehouseDspDivOdName) resList.Add("WarehouseDspDivOdName");
            if (this.CancelDspDivOdName != target.CancelDspDivOdName) resList.Add("CancelDspDivOdName");
            if (this.InqOdrDspDivSetName != target.InqOdrDspDivSetName) resList.Add("InqOdrDspDivSetName");
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            if (this.PccPriWarehouseCd4 != target.PccPriWarehouseCd4) resList.Add("PccPriWarehouseCd4");
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            if (this.PrsntStkCtDspDivOd != target.PrsntStkCtDspDivOd) resList.Add("PrsntStkCtDspDivOd");
            if (this.PrsntStkCtDspDivOdName != target.PrsntStkCtDspDivOdName) resList.Add("PrsntStkCtDspDivOdName");
            if (this.PrsntStkCtDspDiv != target.PrsntStkCtDspDiv) resList.Add("PrsntStkCtDspDiv");
            if (this.PrsntStkCtDspDivName != target.PrsntStkCtDspDivName) resList.Add("PrsntStkCtDspDivNam");
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            if (this.AnsDeliDtDspDiv != target.AnsDeliDtDspDiv) resList.Add("AnsDeliDtDspDiv");
            if (this.AnsDeliDtDspDivName != target.AnsDeliDtDspDivName) resList.Add("AnsDeliDtDspDivName");
            if (this.AnsDeliDtDspDivOd != target.AnsDeliDtDspDivOd) resList.Add("AnsDeliDtDspDivOd");
            if (this.AnsDeliDtDspDivOdName != target.AnsDeliDtDspDivOdName) resList.Add("AnsDeliDtDspDivOdName");
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
            return resList;
        }

        /// <summary>
        /// PCC���Аݒ�}�X�^��r����
        /// </summary>
        /// <param name="pccCmpnySt1">��r����PccCmpnySt�N���X�̃C���X�^���X</param>
        /// <param name="pccCmpnySt2">��r����PccCmpnySt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccCmpnySt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PccCmpnySt pccCmpnySt1, PccCmpnySt pccCmpnySt2)
        {
            ArrayList resList = new ArrayList();
            if (pccCmpnySt1.CreateDateTime != pccCmpnySt2.CreateDateTime) resList.Add("CreateDateTime");
            if (pccCmpnySt1.UpdateDateTime != pccCmpnySt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pccCmpnySt1.LogicalDeleteCode != pccCmpnySt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pccCmpnySt1.InqOriginalEpCd.Trim() != pccCmpnySt2.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (pccCmpnySt1.InqOriginalSecCd != pccCmpnySt2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (pccCmpnySt1.InqOtherEpCd != pccCmpnySt2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (pccCmpnySt1.InqOtherSecCd != pccCmpnySt2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (pccCmpnySt1.PccCompanyCode != pccCmpnySt2.PccCompanyCode) resList.Add("PccCompanyCode");
            if (pccCmpnySt1.PccCompanyName != pccCmpnySt2.PccCompanyName) resList.Add("PccCompanyName");
            if (pccCmpnySt1.PccWarehouseCd != pccCmpnySt2.PccWarehouseCd) resList.Add("PccWarehouseCd");
            if (pccCmpnySt1.PccWarehouseNm != pccCmpnySt2.PccWarehouseNm) resList.Add("PccWarehouseNm");
            if (pccCmpnySt1.PccPriWarehouseCd1 != pccCmpnySt2.PccPriWarehouseCd1) resList.Add("PccPriWarehouseCd1");
            if (pccCmpnySt1.PccPriWarehouseCd2 != pccCmpnySt2.PccPriWarehouseCd2) resList.Add("PccPriWarehouseCd2");
            if (pccCmpnySt1.PccPriWarehouseCd3 != pccCmpnySt2.PccPriWarehouseCd3) resList.Add("PccPriWarehouseCd3");
            if (pccCmpnySt1.GoodsNoDspDiv != pccCmpnySt2.GoodsNoDspDiv) resList.Add("GoodsNoDspDiv");
            if (pccCmpnySt1.GoodsNoDspDivName != pccCmpnySt2.GoodsNoDspDivName) resList.Add("GoodsNoDspDivName");
            if (pccCmpnySt1.ListPrcDspDiv != pccCmpnySt2.ListPrcDspDiv) resList.Add("ListPrcDspDiv");
            if (pccCmpnySt1.ListPrcDspDivName != pccCmpnySt2.ListPrcDspDivName) resList.Add("ListPrcDspDivName");
            if (pccCmpnySt1.CostDspDiv != pccCmpnySt2.CostDspDiv) resList.Add("CostDspDiv");
            if (pccCmpnySt1.CostDspDivName != pccCmpnySt2.CostDspDivName) resList.Add("CostDspDivName");
            if (pccCmpnySt1.ShelfDspDiv != pccCmpnySt2.ShelfDspDiv) resList.Add("ShelfDspDiv");
            if (pccCmpnySt1.ShelfDspDivName != pccCmpnySt2.ShelfDspDivName) resList.Add("ShelfDspDivName");
            if (pccCmpnySt1.StockDspDiv != pccCmpnySt2.StockDspDiv) resList.Add("StockDspDiv");
            if (pccCmpnySt1.StockDspDivName != pccCmpnySt2.StockDspDivName) resList.Add("StockDspDivName");
            if (pccCmpnySt1.CommentDspDiv != pccCmpnySt2.CommentDspDiv) resList.Add("CommentDspDiv");
            if (pccCmpnySt1.CommentDspDivName != pccCmpnySt2.CommentDspDivName) resList.Add("CommentDspDivName");
            if (pccCmpnySt1.SpmtCntDspDiv != pccCmpnySt2.SpmtCntDspDiv) resList.Add("SpmtCntDspDiv");
            if (pccCmpnySt1.SpmtCntDspDivName != pccCmpnySt2.SpmtCntDspDivName) resList.Add("SpmtCntDspDivName");
            if (pccCmpnySt1.AcptCntDspDiv != pccCmpnySt2.AcptCntDspDiv) resList.Add("AcptCntDspDiv");
            if (pccCmpnySt1.AcptCntDspDivName != pccCmpnySt2.AcptCntDspDivName) resList.Add("AcptCntDspDivName");
            if (pccCmpnySt1.PrtSelGdNoDspDiv != pccCmpnySt2.PrtSelGdNoDspDiv) resList.Add("PrtSelGdNoDspDiv");
            if (pccCmpnySt1.PrtSelGdNoDspDivName != pccCmpnySt2.PrtSelGdNoDspDivName) resList.Add("PrtSelGdNoDspDivName");
            if (pccCmpnySt1.PrtSelLsPrDspDiv != pccCmpnySt2.PrtSelLsPrDspDiv) resList.Add("PrtSelLsPrDspDiv");
            if (pccCmpnySt1.PrtSelLsPrDspDivName != pccCmpnySt2.PrtSelLsPrDspDivName) resList.Add("PrtSelLsPrDspDivName");
            if (pccCmpnySt1.PrtSelSelfDspDiv != pccCmpnySt2.PrtSelSelfDspDiv) resList.Add("PrtSelSelfDspDiv");
            if (pccCmpnySt1.PrtSelSelfDspDivName != pccCmpnySt2.PrtSelSelfDspDivName) resList.Add("PrtSelSelfDspDivName");
            if (pccCmpnySt1.PrtSelStckDspDiv != pccCmpnySt2.PrtSelStckDspDiv) resList.Add("PrtSelStckDspDiv");
            if (pccCmpnySt1.PrtSelStckDspDivName != pccCmpnySt2.PrtSelStckDspDivName) resList.Add("PrtSelStckDspDivName");
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
            if (pccCmpnySt1.PccSlipPrtDivName != pccCmpnySt2.PccSlipPrtDivName) resList.Add("PccSlipPrtDivName");
            if (pccCmpnySt1.PccSlipRePrtDiv != pccCmpnySt2.PccSlipRePrtDiv) resList.Add("PccSlipRePrtDiv");
            if (pccCmpnySt1.PccSlipRePrtDivName != pccCmpnySt2.PccSlipRePrtDivName) resList.Add("PccSlipRePrtDivName");
            if (pccCmpnySt1.PrtSelPrmDspDiv != pccCmpnySt2.PrtSelPrmDspDiv) resList.Add("PrtSelPrmDspDiv");
            if (pccCmpnySt1.PrtSelPrmDspDivName != pccCmpnySt2.PrtSelPrmDspDivName) resList.Add("PrtSelPrmDspDivName");
            if (pccCmpnySt1.StckStDspDiv != pccCmpnySt2.StckStDspDiv) resList.Add("StckStDspDiv");
            if (pccCmpnySt1.StckStDspDivName != pccCmpnySt2.StckStDspDivName) resList.Add("StckStDspDivName");
            if (pccCmpnySt1.StckStComment1 != pccCmpnySt2.StckStComment1) resList.Add("StckStComment1");
            if (pccCmpnySt1.StckStComment2 != pccCmpnySt2.StckStComment2) resList.Add("StckStComment2");
            if (pccCmpnySt1.StckStComment3 != pccCmpnySt2.StckStComment3) resList.Add("StckStComment3");
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� 2013/03/06�z�M-------------------------------------------->>>>>
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
            if (pccCmpnySt1.WarehouseDspDivName != pccCmpnySt2.WarehouseDspDivName) resList.Add("WarehouseDspDivName");
            if (pccCmpnySt1.CancelDspDivName != pccCmpnySt2.CancelDspDivName) resList.Add("CancelDspDivName");
            if (pccCmpnySt1.GoodsNoDspDivOdName != pccCmpnySt2.GoodsNoDspDivOdName) resList.Add("GoodsNoDspDivOdName");
            if (pccCmpnySt1.ListPrcDspDivOdName != pccCmpnySt2.ListPrcDspDivOdName) resList.Add("ListPrcDspDivOdName");
            if (pccCmpnySt1.CostDspDivOdName != pccCmpnySt2.CostDspDivOdName) resList.Add("CostDspDivOdName");
            if (pccCmpnySt1.ShelfDspDivOdName != pccCmpnySt2.ShelfDspDivOdName) resList.Add("ShelfDspDivOdName");
            if (pccCmpnySt1.StockDspDivOdName != pccCmpnySt2.StockDspDivOdName) resList.Add("StockDspDivOdName");
            if (pccCmpnySt1.CommentDspDivOdName != pccCmpnySt2.CommentDspDivOdName) resList.Add("CommentDspDivOdName");
            if (pccCmpnySt1.SpmtCntDspDivOdName != pccCmpnySt2.SpmtCntDspDivOdName) resList.Add("SpmtCntDspDivOdName");
            if (pccCmpnySt1.AcptCntDspDivOdName != pccCmpnySt2.AcptCntDspDivOdName) resList.Add("AcptCntDspDivOdName");
            if (pccCmpnySt1.PrtSelGdNoDspDivOdName != pccCmpnySt2.PrtSelGdNoDspDivOdName) resList.Add("PrtSelGdNoDspDivOdName");
            if (pccCmpnySt1.PrtSelLsPrDspDivOdName != pccCmpnySt2.PrtSelLsPrDspDivOdName) resList.Add("PrtSelLsPrDspDivOdName");
            if (pccCmpnySt1.PrtSelSelfDspDivOdName != pccCmpnySt2.PrtSelSelfDspDivOdName) resList.Add("PrtSelSelfDspDivOdName");
            if (pccCmpnySt1.PrtSelStckDspDivOdName != pccCmpnySt2.PrtSelStckDspDivOdName) resList.Add("PrtSelStckDspDivOdName");
            if (pccCmpnySt1.WarehouseDspDivOdName != pccCmpnySt2.WarehouseDspDivOdName) resList.Add("WarehouseDspDivOdName");
            if (pccCmpnySt1.CancelDspDivOdName != pccCmpnySt2.CancelDspDivOdName) resList.Add("CancelDspDivOdName");
            if (pccCmpnySt1.InqOdrDspDivSetName != pccCmpnySt2.InqOdrDspDivSetName) resList.Add("InqOdrDspDivSetName");
            // ADD 2013/02/12 SCM��Q��10342,10343�Ή� --------------------------------------------<<<<<
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
            if (pccCmpnySt1.PccPriWarehouseCd4 != pccCmpnySt2.PccPriWarehouseCd4) resList.Add("PccPriWarehouseCd4");
            // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� ----------------------->>>>>
            if (pccCmpnySt1.PrsntStkCtDspDivOd != pccCmpnySt2.PrsntStkCtDspDivOd) resList.Add("PrsntStkCtDspDivOd");
            if (pccCmpnySt1.PrsntStkCtDspDivOdName != pccCmpnySt2.PrsntStkCtDspDivOdName) resList.Add("PrsntStkCtDspDivOdName");
            if (pccCmpnySt1.PrsntStkCtDspDiv != pccCmpnySt2.PrsntStkCtDspDiv) resList.Add("PrsntStkCtDspDiv");
            if (pccCmpnySt1.PrsntStkCtDspDivName != pccCmpnySt2.PrsntStkCtDspDivName) resList.Add("PrsntStkCtDspDivName");
            // ADD 2014/07/23 Redmine#43080��1���݌ɐ��\���敪�̒ǉ� -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� -------------------->>>>>>>>>>
            if (pccCmpnySt1.AnsDeliDtDspDiv != pccCmpnySt2.AnsDeliDtDspDiv) resList.Add("AnsDeliDtDspDiv");
            if (pccCmpnySt1.AnsDeliDtDspDivName != pccCmpnySt2.AnsDeliDtDspDivName) resList.Add("AnsDeliDtDspDivName");
            if (pccCmpnySt1.AnsDeliDtDspDivOd != pccCmpnySt2.AnsDeliDtDspDivOd) resList.Add("AnsDeliDtDspDivOd");
            if (pccCmpnySt1.AnsDeliDtDspDivOdName != pccCmpnySt2.AnsDeliDtDspDivOdName) resList.Add("AnsDeliDtDspDivOdName");
            // 2014/09/04 ADD TAKAGAWA SCM�d�|�ꗗ��10678�Ή� --------------------<<<<<<<<<<
            return resList;
        }
    }
}
