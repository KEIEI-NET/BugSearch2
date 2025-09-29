using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
//using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Controller; // 2010/04/15 Add
using Broadleaf.Application.Common; // 2010/04/15 Add
using Broadleaf.Application.Resources;  // 2010/04/15 Add
using System.Runtime.Serialization.Formatters.Binary;  // 2010/04/27 Add
using System.IO;  // 2010/04/15 Add  // 2010/04/27 Add



namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���Ӑ�d�q�����f�[�^�擾�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�d�q�����̃A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 30418 ���i</br>
    /// <br>Date       : 2008.09.09</br>
    /// <br>Update Note: 2009/09/07 ����</br>
    /// <br>             PM.NS-2-A ���p�Ǘ�</br>
    /// <br>             �ԓ`���s���̎��q���o�^���e�ɍ��ڂ�ǉ�</br>
    /// <br>Update Note: 2009/11/25 ������</br>
    /// <br>             PM.NS�ێ�˗��B �s��Ή�</br>
    /// <br>Update Note: 2009/12/15 ������</br>
    /// <br>             Redmine#1919�s��Ή�</br>
    /// <br>Update Note: 2009/12/28 ������</br>
    /// <br>             PM.NS�ێ�˗��C �s��Ή�</br>
    /// <br>Update Note: 2010/01/12 ������</br>
    /// <br>             PM.NS�ێ�˗��C �s��Ή�</br>
    /// <br>Update Note: 2010/01/29 �k���r</br>
    /// <br>             4������ �s��Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2010/04/15 30517 �Ė� �x��</br>
    /// <br>             Mantis.15309�@�e�L�X�g�o�͑Ή�</br>
    /// <br>             Mantis.15323�@�s��Ή�</br>
    /// <br>                           �����ŏo�͎��ɁA��ʂ̑O��c���A�u�O�X�X��c�{�O�X��c�{�O��c�v�̍��v�ɂȂ��Ă��Ȃ�</br>
    /// <br>UpdateNote : 2010/04/27 gaoyh</br>
    /// <br>             �󒍃}�X�^�i�ԗ��j�Ɏ��R�����^���Œ�ԍ��z��̒ǉ�</br>    
    /// <br>UpdateNote : 2010/06/08 ������</br>
    /// <br>             ��Q�E���ǑΉ��V�������[�X���@���㗚���f�[�^����`�[�Ĕ��s���\�֕ύX</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/07/08 30517 �Ė� �x��</br>
    /// <br>             Mantis.15724�@���v�\���^�u�̏���ŎZ�o�s���̏C��</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/07/21 22018 ��� ���b</br>
    /// <br>�@�@�@�@�@�@�@���ʕ������Q</br>
    /// <br>�@�@�@�@�@�@�@�@�@�c�����v�̒��o�Ń^�C���A�E�g�G���[�����������ꍇ�ɂo�f�����I���������b�Z�[�W�\������悤�C���B</br>
    /// <br>�@�@�@�@�@�@�@�@�A���Ӑ搿�����z�}�X�^�Ƀ��R�[�h�������ꍇ�A��ʏ�̔����(�J�n)�ȍ~�𒊏o����悤�ύX�B</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/08/05 ������</br>
    /// <br>�@�@�@�@�@�@ ��Q�E���ǑΉ�8�������[�X���Ή�</br>
    /// <br></br>
    /// <br>Update Note : 2010/08/31 ������</br>
    /// <br>              Redmine#14006�Ή�</br>
    /// <br>Update Note : 2010/09/01 caowj</br>
    /// <br>              Redmine#14073�Ή�</br>
    /// <br>Update Note: 2010/09/16 �k���r</br>
    /// <br>            �E��QID:14483 PM1012PM.NS��Q���ǑΉ��i�W�����j</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/12/20 22018 ��� ���b</br>
    /// <br>             ��Q���ǑΉ��P�Q��</br>
    /// <br>             �@�E2010/04/15�Ή������C���B</br>
    /// <br>                �@ �����ꗗ�\�A�N�Z�X�N���X���g�p�����(���������l�ݒ聁null�Ȃ̂�)���Ӑ�̏W������28�ȍ~�̏ꍇ�A�\�����Ȃ�����ɂȂ�B</br>
    /// <br>                 �@�����ꗗ�\�A�N�Z�X�N���X���g�p����Ə������璷�B(���[�v���ŉ��x�������[�g���������s�����)
    /// <br>�@�@�@�@�@�@�@�@�@�˓��Ӑ�d�q���������[�g�Łu�c�����O�X�X��{�O�X��{�O��v�̑Ή�������B</br>
    /// <br></br>
    /// <br>UpdateNote : 2011/07/13 ����R</br>
    /// <br>             �A��795</br>
    /// <br>             �W�����i�ŕ��ёւ���Ƃ��������i��ς��܂߂�������Ƃ��ď�������Ă���悤</br>
    /// <br>             �ˉ�ʃR�s�[</br>
    /// <br>             �˗�t�B���^�̃T���v���̕\����������</br>
    /// <br>Update Note : 2011/07/18 ���R �񓚋敪�̒ǉ�</br>
    /// <br>UpdateNote : 2011/07/28 ����R</br>
    /// <br>             �A��909</br>
    /// <br>             ���Ѓ}�X�^�ɂĔN�����u�a���v�\���ɕς��Ă���̂ɂ��ւ�炸�A�d�q�����̉�ʕ\��������\������Č��ɂ���</br>
    /// <br>UpdateNote : 2011/08/18 ����g</br>
    /// <br>             10704766-00 �A��729</br>
    /// <br>             ���ו��ʏ�����V�K����B</br>
    /// <br>Update Note: 2011/09/21 �c���� </br>
    /// <br>             Redmine#25430�Ή�</br>
    /// <br>             ���Ӑ�d�q�����̌����s��ɂ��Ă̏C��</br>
    /// <br>Update Note: 2011/11/23 ����</br>
    /// <br>             Redmine#8079�Ή�</br>
    /// <br>             ���Ӑ�d�q����/�N���̕\���ɂ��Ă̏C��</br>
    /// <br>Update Note: 2011/11/23 �����H </br>
    /// <br>             Redmine#7861�Ή�</br>
    /// <br>             ���Ӑ�d�q�����^�e�����̒ǉ���</br>
    /// <br>Update Note: 2011/11/28 �k�m </br>
    /// <br>             redmine#8172</br>
    /// <br>             ���Ӑ�d�q����/(BL�߰µ��ް����)�⍇���ԍ��̒ǉ�</br>
    /// <br>Update Note: 2012/04/01 gezh</br>
    /// <br>�Ǘ��ԍ�   : 2012/05/24�z�M��</br>
    /// <br>             Redmine#29250 ���Ӑ�d�q�����@���Ӑ�d�q�����@�f�[�^�X�V�����̒ǉ��ɂ��Ă̑Ή�</br>
    /// <br>Update Note: 2012/06/01 30744 ���� ����q</br>
    /// <br>             ���Ӑ�d�q�����@�c���ꗗ�\���̒��o���_�ǉ��ɂ��Ă̑Ή�</br>
    /// <br>Update Note : 2012/06/19 lanl</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00 2012/07/25�z�M��</br>
    /// <br>              Redmine#30529</br>
    /// <br>UpdateNote : 2012/06/26 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��Q�Ή� ��880</br>
    /// <br>             �N������͂����`�[�̌��o���\��t�����s���ƁA�N�����\����Ȃ����̑Ή�</br>
    /// <br>             �i�u�S�̏����\���ݒ�v�́u�����\���敪�i�N���j�v���h�a��h�ɐݒ肳��Ă���ꍇ�ɔ����j</br>
    /// <br>Update Note : 2012/07/10 tianjw</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00 2012/07/25�z�M��</br>
    /// <br>              Redmine#30529</br>
    /// <br>Update Note : 2012/11/15 yangmj</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00 20130116�z�M��</br>
    /// <br>              Redmine#33269�@��������̈���̑Ή�</br>
    /// <br>UpdateNote : 2012/12/14 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>             �����`�[���͂ɂĒl�����������͎萔������͂��A</br>
    /// <br>             ���̓`�[��ԓ`���s�����ꍇ�A���ו\���ɍ������\������Ȃ����̏C��</br>
	/// <br>Update Note : 2013/01/30 wangf </br>
	/// <br>            : 10801804-00�A���x���P�֘A�ARedmine#34513 �T�[�o�[���׌y���ׁ̈A���Ӑ�d�q�����̉��ǂ̑Ή�</br>
	/// <br>            : �c���W�v�̃^�C�~���O�����炷</br>
    /// <br>Update Note : 2013/04/12 zhujw </br>
    /// <br>            : 10800003-00�A2013/05/15�z�M���ARedmine#35205�@���Ӑ�d�q�����̑Ή�</br>
    /// <br>            : �^�M�c���o�͓��e�s���̏C���B</br>
    /// <br>Update Note : 2013/05/06 zhujw </br>
    /// <br>            : 10900691-00�A2013/05/15�z�M���ARedmine#34718�@���Ӑ�d�q�����̑Ή�</br>
    /// <br>            : �N�̂ݓ��͂���Ă����ꍇ�́A�N�݂̂̈󎚂���悤�ɏC���B</br>
    /// <br>Update Note: 2013/05/15 huangt </br>
    /// <br>�Ǘ��ԍ�   : 10902175-00 6��18���z�M���i��Q�ȊO�j</br>
    /// <br>           : Redmine#35640�@���Ӑ�d�q���� �e�L�X�g�o�� ����ł��o�͂���Ȃ��̏C��</br>
    /// <br>UpdateNote : 2013/10/02 �{�{ ����</br>
    /// <br>�Ǘ��ԍ�   : 10902175-00 �d�|�ꗗ ��2147</br>
    /// <br>             �e��(����)�����z�|�����ŎZ�o����悤�ɏC��</br>
    /// <br>UpdateNote : K2014/05/08 �ђ��}</br>
    /// <br>           : ���Ӑ�d�q������CSV�o�͍��ڂɎԎ탁�[�J�[�R�[�h��ǉ�����A��������ʑΉ�</br>
    /// <br>Update Note: K2014/05/28 �ђ��} </br>
    /// <br>           : ���Ӑ�d�q����  Redmine#42764 ����e�X�g��Q�Ή��B��������ʑΉ�</br>
    /// <br>Update Note: 2014/12/28 �i�N</br>
    /// <br>�Ǘ��ԍ�   : 11070263-00</br>
    /// <br>           : �ϊ���i�Ԃ̒ǉ��Ή�</br>
    /// <br>Update Note: K2015/06/16 鸏�</br>
    /// <br>�Ǘ��ԍ�   : 11101427-00</br>
    /// <br>           : ���C�S�����Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����B</br>
    /// <br>UpdateNote : 2015/02/05 ������ </br>
    /// <br>           : �e�L�X�g�o�͌��������Ȃ����[�h�̒ǉ�</br>
    /// <br>UpdateNote : 2015/05/11 ���R </br>
    /// <br>           : �e�L�X�g�o�͂ɂāu���o���������Ȃ��v�̏ꍇ�ɕϊ���i�Ԃ��o�͂���Ȃ��̑Ή�</br>
    /// <br>Update Note: K2015/04/27 �� </br>
    /// <br>�Ǘ��ԍ�   : 11100842-00 �����Z���i���̌ʊJ���˗� </br>
    /// <br>           : ���Ӑ�d�q������񔄉���ǉ�����B�����Z���i���I�v�V�������L���̏ꍇ�̂݁B</br>
    /// <br>Update Note: K2015/12/10 �e�c ���V </br>
    /// <br>�Ǘ��ԍ�   : 11170188-00 ���C�S�����Ӑ�d�q���� </br>
    /// <br>           : ���C�S���e�L�X�g�o�͂ɂāu���o���������Ȃ��v�̏ꍇ�Ɂu�n��v�Ɓu���̓R�[�h�v���o�͂���Ȃ���Q�Ή�</br>
    /// <br>Update Note: 2016/01/21 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 11270007-00</br>
    /// <br>           : �d�|�ꗗ��2808 �ݏo�󒍑Ή�</br>
    /// <br>           : �@���������Ɂu�o�׏󋵁v���ڂ�ǉ�</br>
    /// <br>           : �A���ו\���Ɍv�㐔�A���v�㐔���ڂ�ǉ�</br>
    /// <br>Update Note: K2016/02/23 ���V��</br>
    /// <br>�Ǘ��ԍ�   : 11200090-00 �C�P�� ���Ӑ�d�q����</br>
    /// <br>             ���C�P���g ���o�����ɂĎ󒍍쐬�敪��ǉ�����Ή�</br>
    /// <br>Update Note: 2020/03/11 ���V��</br>
    /// <br>�Ǘ��ԍ�   : 11570208-00</br>
    /// <br>           : PMKOBETSU-2912 �y���ŗ��Ή�</br>
    /// <br>           : �`�[�^�u�A���׃^�u�Ɂu����ŗ��v���ڂ�ǉ�</br>
    /// <br>Update Note: 2022/05/05 ����</br>
    /// <br>�Ǘ��ԍ�   : 11870080-00</br>
    /// <br>           : �[�i���d�q����A�g�Ή�</br>
    /// <br></br>
    /// </remarks>
    public partial class CustPrtSlipSearchAcs
    {

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <br>Update Note : K2015/06/16 鸏�</br>
        /// <br>�Ǘ��ԍ�    : 11101427-00</br>
        /// <br>            : ���C�S�����Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����B</br>
        public CustPrtSlipSearchAcs()
        {
            // �����[�g�C���X�^���X�擾
            this._iCustPrtPprWorkDB = MediationCustPrtPprWorkDB.GetCustPrtPprWorkDB();

            // �f�[�^�Z�b�g���쐬
            this._dataSet = new CustPtrSalesDetailDataSet();

            // �A�N�Z�X�N���X���쐬
            this._customerAcs = new CustomerSearchAcs();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 ADD
            // ���Ӑ�A�N�Z�X�N���X
            _customerInfoAcs = new CustomerInfoAcs();

            // ���Ӑ���яC�������[�g
            _iCustRsltUpdDB = MediationCustRsltUpdDB.GetCustRsltUpdDB();

            // �������X�V�����[�g
            _iCustDmdPrcDB = MediationCustDmdPrcDB.GetCustDmdPrcDB();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 ADD

            //----- ADD K2014/05/28 By �ђ��} Redmine#42764 ����e�X�g��Q�Ή� BEGIN--------->>>>>
            #region ��������I�v�V����
            // ��������ʃI�v�V�����R�[�h�̒ǉ�
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus touaCustom;
            touaCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_ToaCustom);
            if (touaCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Toua = Convert.ToInt32(Option.ON);
            }
            else
            {
                this._opt_Toua = Convert.ToInt32(Option.OFF);
            }
            #endregion
            //----- ADD K2014/05/28 By �ђ��} Redmine#42764 ����e�X�g��Q�Ή� END---------<<<<<

           // ---- ADD K2015/04/29 �� �e�L�X�g�o�͍��ڂɑ�񔄉���ǉ����� ---->>>>>
            // �����Z���i���̌ʃI�v�V�����R�[�h�̒ǉ�
            #region �����Z���i�I�v�V����
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus momoseCustom;
            momoseCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MomoseCustom);
            if (momoseCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Momose = Convert.ToInt32(Option.ON);
            }
            else
            {
                this._opt_Momose = Convert.ToInt32(Option.OFF);
            }
            #endregion
            // ---- ADD K2015/04/29 �� �e�L�X�g�o�͍��ڂɑ�񔄉���ǉ����� ----<<<<<

            //----- ADD 2015/02/05 ������ -------------------->>>>>
            #region ��PCC�I�v�V����
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus pccCustom;
            pccCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);
            if (pccCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Pcc = (int)Option.ON;
            }
            else
            {
                this._opt_Pcc = (int)Option.OFF;
            }
            #endregion

            #region �o�ˌʃI�v�V����
            // �o�ˌʃI�v�V�����R�[�h�̒ǉ�
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus nobutoCustom;
            nobutoCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_NobutoCustom);
            if (nobutoCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Nobuto = (int)Option.ON;
            }
            else
            {
                this._opt_Nobuto = (int)Option.OFF;
            }
            #endregion
            // �e�L�X�g�o�͗p�e�[�u��
            this._salesListTbl4Text = new CustPtrSalesDetailDataSet.SalesListDataTable();
            this._salesDetailTbl4Text = new CustPtrSalesDetailDataSet.SalesDetailDataTable();
            //----- ADD 2015/02/05 ������ --------------------<<<<<

            //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
            #region ���C�S���I�v�V����
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus meigoCustom;
            meigoCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MeigoLedgerCustom);
            if (meigoCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Meigo = Convert.ToInt32(Option.ON);
            }
            else
            {
                this._opt_Meigo = Convert.ToInt32(Option.OFF);
            }
            #endregion
            //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<

        }

        #endregion // �R���X�g���N�^

        // ADD 2012/06/01 ----------------------->>>>>
        #region �񋓑�
        /// <summary>
        /// ���o���_���
        /// </summary>
        public enum RemainSectionType : int
        {
            /// <summary>�Ǘ����_</summary>
            Mng = 0,
            /// <summary>�������_</summary>
            Claim = 1
        }
        #endregion
        // ADD 2012/06/01 -----------------------<<<<<

        #region �v���C�x�[�g�ϐ�

        // �����[�gDB�����N���X �C���^�t�F�[�X�I�u�W�F�N�g
        private ICustPrtPprWorkDB _iCustPrtPprWorkDB;

        // �f�[�^�Z�b�g�N���X
        private CustPtrSalesDetailDataSet _dataSet;

        // ���Ӑ�擾�p�A�N�Z�X�N���X
        private CustomerSearchAcs _customerAcs;

        // --- DEL 2020/12/21 �x���Ή� ---------->>>>>
        //// ���Ӑ���ߓ�
        //private int _customerCalcDate= 0;
        // --- DEL 2020/12/21 �x���Ή� ----------<<<<<

        // ���Ӑ�w��t���O�i�w�肳��Ă��Ȃ��ꍇ�͎c������\�����Ȃ��j
        private bool _customerPointed = true;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/15 ADD
        // ����S�̐ݒ�
        private SalesTtlSt _salesTtlSt;

        // ���Ӑ�A�N�Z�X
        private CustomerInfoAcs _customerInfoAcs;

        // ���Ӑ���яC�������[�g
        private ICustRsltUpdDB _iCustRsltUpdDB;

        // �������X�V�����[�g
        private ICustDmdPrcDB _iCustDmdPrcDB;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/15 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 ADD
        // ���o���f�t���O
        private bool _extractCancelFlag;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 ADD

        //----- ADD K2014/05/28 By �ђ��} Redmine#42764 ����e�X�g��Q�Ή� BEGIN--------->>>>>
        /// <summary>�����I�v�V�������</summary>
        private int _opt_Toua;
        /// <summary>
        /// �I�v�V�����L���L��
        /// </summary>
        public enum Option : int
        {
            /// <summary>����</summary>
            OFF = 0,
            /// <summary>�L��</summary>
            ON = 1,
        }
        //----- ADD K2014/05/28 By �ђ��} Redmine#42764 ����e�X�g��Q�Ή� END---------<<<<<

       // ---- ADD K2015/04/27 �� �����Z���i�̑�񔄉��ǉ� ---->>>>>
        /// <summary>�����Z���i</summary>
        private int _opt_Momose;
        /// <summary>�L�����N�^�[�̃h�b�g</summary>
        private const char CHAR_DOT = '.';
        /// <summary>�X�y�[�X</summary>
        private const char CHAR_SPACE = ' ';
        /// <summary>�X�g�����O�̃h�b�g</summary>
        private const string STR_DOT = ".";
        /// <summary>�v���X</summary>
        private const string STR_PURASU = "+";
        /// <summary>�[�������Ώۋ��z�敪�i����P���j</summary>
        internal const int ctFracProcMoneyDiv_SalesUnitPrice = 2;
        private SalesProcMoneyAcs _salesProcMoneyAcs;
        private List<SalesProcMoney> _salesProcMoneyList;
        // ---- ADD K2015/04/27 �� �����Z���i�̑�񔄉��ǉ� ----<<<<<

        //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
        /// <summary>���C�S���I�v�V�������<</summary>
        int _opt_Meigo;
        //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<

        #endregion // �v���C�x�[�g�ϐ�

        #region 0�l�ߌ��萔

        /// <summary>���Ӑ�R�[�h ����:�����l 9</summary>
        private const int CT_DEPTH_CUSTOMERCODE = 9;

        /// <summary>�d����R�[�h ����:�����l 6</summary>
        private const int CT_DEPTH_SUPPLIERCODE = 6;

        /// <summary>BL�R�[�h ����:�����l 5</summary>
        private const int CT_DEPTH_BLGOODSCODE = 5;

        /// <summary>BL�O���[�v�R�[�h ����:�����l 5</summary>
        private const int CT_DEPTH_BLGROUPCODE = 5;

        /// <summary>������R�[�h ����:�����l 6</summary>
        private const int CT_DEPTH_UOESUPPLIERCODE = 6;

        /// <summary>���[�J�[�R�[�h ����:�����l 4</summary>
        private const int CT_DEPTH_GOODSMAKERCODE = 4;

        //---ADD START 2011/11/28 �k�m ------------->>>>>
        /// <summary>�⍇���ԍ� ����:�����l 10</summary>
        private const int CT_DEPTH_INQUIRYNUMBER = 10;
        //---ADD END   2011/11/28 �k�m -------------<<<<<

        //----- ADD 2015/02/05 ������ -------------------->>>>>
        /// <summary>PCC�I�v�V�������</summary>
        private int _opt_Pcc;

        /// <summary>�o�˃I�v�V�������</summary>
        private int _opt_Nobuto;

        /// <summary>�����̓����F�����l 11</summary>
        private const int CT_LOOPDAYS = 11;
        // --------ADD 2022/05/05 ���� �[�i���d�q����A�g�Ή��@------->>>>>
        /// <summary> PDF�t�@�C���o�� 0:�o�͂��Ȃ� 1:�o�͂��� </summary>
        public static int PDFPrinterStatus;
        public int PDFPrinterStatus_EXT
        {
            get { return PDFPrinterStatus; }
        }
        // --------ADD 2022/05/05 ���� �[�i���d�q����A�g�Ή��@-------<<<<<

        /// <summary>�e�L�X�g�o�͗p����f�[�^�e�[�u��</summary>
        private CustPtrSalesDetailDataSet.SalesListDataTable _salesListTbl4Text;
        /// <summary>�e�L�X�g�o�͗p���㖾�׃f�[�^�e�[�u��</summary>
        private CustPtrSalesDetailDataSet.SalesDetailDataTable _salesDetailTbl4Text;

        /// <summary>
        /// �e�L�X�g�o�͗p����f�[�^�e�[�u��
        /// </summary>
        public CustPtrSalesDetailDataSet.SalesListDataTable SalesListTbl4Text
        {
            get { return _salesListTbl4Text; }
        }

        /// <summary>
        /// �e�L�X�g�o�͗p���㖾�׃f�[�^�e�[�u��
        /// </summary>
        public CustPtrSalesDetailDataSet.SalesDetailDataTable SalesDetailTbl4Text
        {
            get { return _salesDetailTbl4Text; }
        }
        //----- ADD 2015/02/05 ������ --------------------<<<<<

        #endregion

        #region �v���p�e�B

        /// <summary>
        /// �f�[�^�Z�b�g�I�u�W�F�N�g 
        /// </summary>
        public CustPtrSalesDetailDataSet DataSet
        {
            get { return this._dataSet; }
            //set { this._dataSet = value; }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/15 ADD
        /// <summary>
        /// ����S�̐ݒ�
        /// </summary>
        public SalesTtlSt SalesTtlSt
        {
            get { return _salesTtlSt; }
            set { _salesTtlSt = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/15 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 ADD
        /// <summary>
        /// ���o���f�t���O
        /// </summary>
        public bool ExtractCancelFlag
        {
            get { return _extractCancelFlag; }
            set { _extractCancelFlag = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 ADD
        #endregion // �v���p�e�B

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        public delegate void UpdateSectionEventHandler( object sender, string sectionCode, string sectionName );
        public event UpdateSectionEventHandler UpdateSection;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

        //----- ADD 2015/02/05 ������ -------------------->>>>>
        /// <summary>
        /// �e�L�X�g�o�͗p�e�[�u���^�C�g���̐ݒ�
        /// </summary>
        /// <param name="mode">���[�h�i0:�`�[ 1:���ׁj</param>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͗p�e�[�u���^�C�g���̐ݒ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// <br>UpdateNote : 2015/05/11 ���R </br>
        /// <br>           : �e�L�X�g�o�͂ɂāu���o���������Ȃ��v�̏ꍇ�ɕϊ���i�Ԃ��o�͂���Ȃ��̑Ή�</br>
        /// <br>UpdateNote : 2015/06/11 �� </br>
        /// <br>           : �e�L�X�g�o�͂ɂāu���o���������Ȃ��v�̏ꍇ�ɑ�񔄉����o�͂���Ȃ��̑Ή�</br>
        /// <br>UpdateNote : 2016/01/21 �e�c ���V</br>
        /// <br>�Ǘ��ԍ�   : 11270007-00</br>
        /// <br>           : �d�|�ꗗ��2808 �ݏo�󒍑Ή�</br>
        /// <br>           : �@���������Ɂu�o�׏󋵁v���ڂ�ǉ�</br>
        /// <br>           : �A���ו\���Ɍv�㐔�A���v�㐔���ڂ�ǉ�</br>
        /// <br>Update Note: 2020/03/11 ���V��</br>
        /// <br>�Ǘ��ԍ�   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912 �y���ŗ��Ή�</br>
        /// <br>           : �`�[�^�u�A���׃^�u�Ɂu����ŗ��v���ڂ�ǉ�</br>
        /// </remarks>
        private void SetTableCaption(int mode)
        {
            if (mode == 0)
            {
                #region �`�[
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SalesDateColumn.ColumnName].Caption = "�`�[���t";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SalesSlipNumColumn.ColumnName].Caption = "�`�[�ԍ�";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SalesSlipCdNameColumn.ColumnName].Caption = "�敪";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SalesEmployeeNmColumn.ColumnName].Caption = "�S���Җ�";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SalesTotalTaxExcColumn.ColumnName].Caption = "���z";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.ConsumeTaxColumn.ColumnName].Caption = "�����";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.GrossProfitColumn.ColumnName].Caption = "�e��";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.CategoryNoColumn.ColumnName].Caption = "�ޕʌ^��";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.ModelFullNameColumn.ColumnName].Caption = "�Ԏ�";
                if (this._opt_Toua == Convert.ToInt32(Option.ON))
                {
                    this._salesListTbl4Text.Columns[this._salesListTbl4Text.MakerCodeColumn.ColumnName].Caption = "�Ԏ탁�[�J�[�R�[�h";
                }
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.FirstEntryDateColumn.ColumnName].Caption = "�N��";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.FrameNoColumn.ColumnName].Caption = "�ԑ�No";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.FullModelColumn.ColumnName].Caption = "�^��";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SlipNoteColumn.ColumnName].Caption = "���l�P";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SlipNote2Column.ColumnName].Caption = "���l�Q";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SlipNote3Column.ColumnName].Caption = "���l�R";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.FrontEmployeeNmColumn.ColumnName].Caption = "�󒍎�";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SalesInputNameColumn.ColumnName].Caption = "���s��";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.CustomerCodeColumn.ColumnName].Caption = "���Ӑ�R�[�h";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.CustomerSnmColumn.ColumnName].Caption = "���Ӑ於";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.PartySaleSlipNumColumn.ColumnName].Caption = "�w����(���`)�ԍ�";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.CarMngCodeColumn.ColumnName].Caption = "�Ǘ�No";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.AcceptAnOrderNoColumn.ColumnName].Caption = "�v�㌳��No";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.ShipmSalesSlipNumColumn.ColumnName].Caption = "�v�㌳�ݏoNo";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.UoeRemark1Column.ColumnName].Caption = "UOE���}�[�N1";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.UoeRemark2Column.ColumnName].Caption = "UOE���}�[�N2";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SectionCdColumn.ColumnName].Caption = "���_�R�[�h";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SectionGuideNmColumn.ColumnName].Caption = "���_��";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.ColorName1Column.ColumnName].Caption = "�J���[����";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.TrimNameColumn.ColumnName].Caption = "�g��������";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.CustSlipNoColumn.ColumnName].Caption = "���Ӑ�`�[�ԍ�";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.AddUpADateColumn.ColumnName].Caption = "�v���";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.EnterpriseGanreCodeColumn.ColumnName].Caption = "���i�敪";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.AccRecDivCdNameColumn.ColumnName].Caption = "���|�敪";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.DebitNoteDivColumn.ColumnName].Caption = "�ԓ`�敪";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.AddresseeCodeColumn.ColumnName].Caption = "�[����R�[�h";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.AddresseeNameColumn.ColumnName].Caption = "�[���於";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.InputDayColumn.ColumnName].Caption = "���͓�";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.HistoryDivNameColumn.ColumnName].Caption = "����";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SlipPrintTimeColumn.ColumnName].Caption = "�`�[���s����";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.UpdateDateTimeColumn.ColumnName].Caption = "�X�V����";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.ConsTaxRateColumn.ColumnName].Caption = "����ŗ�"; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                #endregion
            }
            else
            {
                #region ����
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesDateColumn.ColumnName].Caption = "�`�[���t";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesSlipNumColumn.ColumnName].Caption = "�`�[�ԍ�";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesRowNoColumn.ColumnName].Caption = "�sNo";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesSlipCdNameColumn.ColumnName].Caption = "�敪";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesSlipCdDtlNameColumn.ColumnName].Caption = "���׋敪";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesEmployeeNmColumn.ColumnName].Caption = "�S���Җ�";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GoodsNameColumn.ColumnName].Caption = "�i��";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GoodsNoColumn.ColumnName].Caption = "�i��";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.BLGoodsCodeColumn.ColumnName].Caption = "BL����";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.BLGroupCodeColumn.ColumnName].Caption = "BL��ٰ��";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GoodsMGroupColumn.ColumnName].Caption = "�����ރR�[�h";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GoodsMGroupNameColumn.ColumnName].Caption = "�����ޖ�";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GoodsLGroupColumn.ColumnName].Caption = "�啪�ރR�[�h";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GoodsLGroupNameColumn.ColumnName].Caption = "�啪�ޖ�";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.ShipmentCntColumn.ColumnName].Caption = "����";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.ListPriceTaxExcFlColumn.ColumnName].Caption = "�W�����i";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesUnPrcTaxExcFlColumn.ColumnName].Caption = "�P��";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesUnitCostColumn.ColumnName].Caption = "����";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesMoneyTaxExcColumn.ColumnName].Caption = "���z";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesPriceConsTaxColumn.ColumnName].Caption = "�����";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GrossProfitDetailColumn.ColumnName].Caption = "�e��";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GrossProfitMarginColumn.ColumnName].Caption = "�e����";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.CategoryNoColumn.ColumnName].Caption = "�ޕʌ^��";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.ModelFullNameColumn.ColumnName].Caption = "�Ԏ�";
                if (this._opt_Toua == Convert.ToInt32(Option.ON))
                {
                    this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.MakerCodeColumn.ColumnName].Caption = "�Ԏ탁�[�J�[�R�[�h";
                }
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.FirstEntryDateColumn.ColumnName].Caption = "�N��";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.FrameNoColumn.ColumnName].Caption = "�ԑ�No";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.FullModelColumn.ColumnName].Caption = "�^��";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SlipNoteColumn.ColumnName].Caption = "���l�P";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SlipNote2Column.ColumnName].Caption = "���l�Q";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SlipNote3Column.ColumnName].Caption = "���l�R";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.FrontEmployeeNmColumn.ColumnName].Caption = "�󒍎�";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesInputNameColumn.ColumnName].Caption = "���s��";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.CustomerCodeColumn.ColumnName].Caption = "���Ӑ�R�[�h";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.CustomerSnmColumn.ColumnName].Caption = "���Ӑ�";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SupplierCdColumn.ColumnName].Caption = "�d����R�[�h";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SupplierSnmColumn.ColumnName].Caption = "�d����";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.PartySaleSlipNumColumn.ColumnName].Caption = "�w����(���`)�ԍ�";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.CarMngCodeColumn.ColumnName].Caption = "�Ǘ�No";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.AcceptAnOrderNoColumn.ColumnName].Caption = "�v�㌳��No";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.ShipSalesSlipNumColumn.ColumnName].Caption = "�v�㌳�ݏoNo";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SrcSalesSlipNumColumn.ColumnName].Caption = "����No";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.EnterpriseGanreCodeColumn.ColumnName].Caption = "���i�敪";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GoodsKindCodeNameColumn.ColumnName].Caption = "���i����";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesOrderDivCdNameColumn.ColumnName].Caption = "�݌Ɏ��敪";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.WarehouseNameColumn.ColumnName].Caption = "�q��";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.WarehouseShelfNoColumn.ColumnName].Caption = "�I��";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.StockPartySaleSlipNumColumn.ColumnName].Caption = "�����d��No";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.UOESupplierCdColumn.ColumnName].Caption = "������R�[�h";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.UOESupplierSnmColumn.ColumnName].Caption = "������";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.UOERemark1Column.ColumnName].Caption = "UOE���}�[�N1";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.UOERemark2Column.ColumnName].Caption = "UOE���}�[�N2";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GuideNameColumn.ColumnName].Caption = "�̔��敪";
                if (this._opt_Nobuto == (int)Option.ON)
                {
                    this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GuideNameColumn.ColumnName].Caption = "���̋敪";
                }
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SectionCdColumn.ColumnName].Caption = "���_�R�[�h";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SectionGuideNameColumn.ColumnName].Caption = "���_��";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.DtlNoteColumn.ColumnName].Caption = "���ה��l";

                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.ColorName1Column.ColumnName].Caption = "�J���[��";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.TrimNameColumn.ColumnName].Caption = "�g������";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.StdUnPrcLPriceColumn.ColumnName].Caption = "�Z�o���i";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.StdUnPrcSalUnPrcColumn.ColumnName].Caption = "�Z�o����";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.StdUnPrcUnCstColumn.ColumnName].Caption = "�Z�o����";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GoodsMakerCdColumn.ColumnName].Caption = "���[�J�[�R�[�h";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.MakerNameColumn.ColumnName].Caption = "���[�J�[��";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.CustSlipNoColumn.ColumnName].Caption = "���Ӑ�`�[�ԍ�";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.AddUpADateColumn.ColumnName].Caption = "�v���";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.AccRecDivCdNameColumn.ColumnName].Caption = "���|�敪";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.DebitNoteDivColumn.ColumnName].Caption = "�ԓ`�敪";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.AddresseeCodeColumn.ColumnName].Caption = "�[����R�[�h";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.AddresseeNameColumn.ColumnName].Caption = "�[���於";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.InputDayColumn.ColumnName].Caption = "���͓�";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.HistoryDivNameColumn.ColumnName].Caption = "����";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SlipPrintTimeColumn.ColumnName].Caption = "�`�[���s����";
                if (this._opt_Pcc == (int)Option.ON)
                {
                    this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.AutoAnswerDivSCMColumn.ColumnName].Caption = "������";
                    this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.InquiryNumberColumn.ColumnName].Caption = "�⍇���ԍ�";
                }
                this._salesDetailTbl4Text.Columns[this._salesListTbl4Text.UpdateDateTimeColumn.ColumnName].Caption = "�X�V����";

                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.ChangeGoodsNoColumn.ColumnName].Caption = "�ϊ���i��"; // ADD ���R 2015/05/11 �e�L�X�g�o�͂ɂāu���o���������Ȃ��v�̏ꍇ�ɕϊ���i�Ԃ��o�͂���Ȃ��̑Ή�

                // ---------- ADD 2016/01/21 Y.Wakita ---------->>>>>
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesRecognitionCntColumn.ColumnName].Caption = "�v�㐔";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesNotRecognitionCntColumn.ColumnName].Caption = "���v�㐔";
                // ---------- ADD 2016/01/21 Y.Wakita ----------<<<<<

                // ---- ADD K2015/06/09 �� �e�L�X�g�o�͍��ڂɑ�񔄉��ǉ���ǉ�����---->>>>>
                // �e�L�X�g�o�͂ɂāu���o���������Ȃ��v�̏ꍇ�ɑ�񔄉����o�͂���Ȃ��̑Ή�
                if (this._opt_Momose == Convert.ToInt32(Option.ON))
                {
                    this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SecondSalePriceColumn.ColumnName].Caption = "��񔄉�";
                }
                // ---- ADD K2015/06/09 �� �e�L�X�g�o�͍��ڂɑ�񔄉��ǉ���ǉ�����---->>>>>
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.ConsTaxRateColumn.ColumnName].Caption = "����ŗ�";�@// ADD ���V�� 2020/03/11 PMKOBETSU-2912
                #endregion
            }
        }

        /// <summary>
        /// ��������w�肳��Ȃ��ꍇ�ADB����J�n�E�I�����������������
        /// </summary>
        /// <param name="custPrtPpr">��������</param>
        /// <param name="logicalDelDiv">�_���폜�敪</param>
        /// <param name="salesDateSt">�J�n�����</param>
        /// <param name="salesDateEd">�I�������</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ��������w�肳��Ȃ��ꍇ�ADB����J�n�E�I�����������������B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        public int GetSalesDate4TextFile(CustPrtPpr custPrtPpr, int logicalDelDiv, out DateTime salesDateSt, out DateTime salesDateEd)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            salesDateSt = DateTime.MinValue;
            salesDateEd = DateTime.MinValue;
            CustPrtPprWork custPrtPprWork = null;

            try
            {
                // �p�����[�^�N���X���쐬
                custPrtPprWork = new CustPrtPprWork();
                CustPrtPpr2CustPrtPprWork(ref custPrtPpr, ref custPrtPprWork);

                if (_extractCancelFlag == true) return 0;

                if (logicalDelDiv == 0)
                {
                    // �폜�����܂܂Ȃ��ꍇ��GetData0���w��(�폜�t���O=0�̃f�[�^��Ԃ�)
                    status = this._iCustPrtPprWorkDB.GetSalesDate(out salesDateSt, out salesDateEd, (object)custPrtPprWork, ConstantManagement.LogicalMode.GetData0);
                }
                else
                {
                    // �폜�ς݂̏ꍇ��GetData1���w��(�폜�t���O=1�̃f�[�^��Ԃ�)
                    status = this._iCustPrtPprWorkDB.GetSalesDate(out salesDateSt, out salesDateEd, (object)custPrtPprWork, ConstantManagement.LogicalMode.GetData1);
                }

                if (_extractCancelFlag == true) return 0;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                custPrtPprWork = null;
            }

            return status;
        }

        /// <summary>
        /// �e�L�X�g�o�͗p�f�[�^�̌���
        /// </summary>
        /// <param name="custPrtPpr">��������</param>
        /// <param name="logicalDelDiv">�_���폜�敪</param>
        /// <param name="mode">�������[�h�i0:�`�[ 1:���ׁj</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͗p�f�[�^�̌����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// <br>UpdateNote : K2015/05/11 ���R </br>
        /// <br>           : �e�L�X�g�o�͂ɂāu���o���������Ȃ��v�̏ꍇ�ɕϊ���i�Ԃ��o�͂���Ȃ��̑Ή�</br>
        /// <br>UpdateNote : K2015/06/09 �� </br>
        /// <br>           : �e�L�X�g�o�͂ɂāu���o���������Ȃ��v�̏ꍇ�ɑ�񔄉����o�͂���Ȃ��̑Ή�</br>
        /// <br>UpdateNote : K2015/12/10 �e�c ���V </br>
        /// <br>           : ���C�S���e�L�X�g�o�͂ɂāu���o���������Ȃ��v�̏ꍇ�Ɂu�n��v�Ɓu���̓R�[�h�v���o�͂���Ȃ���Q�Ή�</br>
        /// <br>UpdateNote : 2016/01/21 �e�c ���V</br>
        /// <br>�Ǘ��ԍ�   : 11270007-00</br>
        /// <br>           : �d�|�ꗗ��2808 �ݏo�󒍑Ή�</br>
        /// <br>           : �@���������Ɂu�o�׏󋵁v���ڂ�ǉ�</br>
        /// <br>           : �A���ו\���Ɍv�㐔�A���v�㐔���ڂ�ǉ�</br>
        /// <br>Update Note: 2020/03/11 ���V��</br>
        /// <br>�Ǘ��ԍ�   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912 �y���ŗ��Ή�</br>
        /// <br>           : �`�[�^�u�A���׃^�u�Ɂu����ŗ��v���ڂ�ǉ�</br>
        /// </remarks>
        public int SearchAllData4TextFile(CustPrtPpr custPrtPpr, int logicalDelDiv, int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            ArrayList resultList = new ArrayList();
            try
            {
                // �p�����[�^�N���X���쐬
                CustPrtPprWork custPrtPprWork = new CustPrtPprWork();
                CustPrtPpr2CustPrtPprWork(ref custPrtPpr, ref custPrtPprWork);
                custPrtPprWork.SearchCountCtrl = 1; // ���o���������Ȃ��̏ꍇ

                CustPrtPprBlDspRsltWork custPrtPprBlDspRsltWork = null;
                CustPrtPprSalTblRsltWork custPrtPprSalTblRsltWork = null;
                object custPrtPprBlDspRsltWorkObj = null;
                object custPrtPprSalTblRsltWorkObj = null;

                try
                {
                    //---------------------------------
                    // �Ԃ�l�Ŏg�p����N���X���쐬
                    //---------------------------------

                    // �c���Ɖ�ɕ\������̂łP���̂�
                    custPrtPprBlDspRsltWork = new CustPrtPprBlDspRsltWork();
                    custPrtPprBlDspRsltWorkObj = (object)custPrtPprBlDspRsltWork;

                    // ���ׂȂ̂�recordCount�����z��ŋA���Ă���
                    custPrtPprSalTblRsltWork = new CustPrtPprSalTblRsltWork();
                    custPrtPprSalTblRsltWorkObj = (object)custPrtPprSalTblRsltWork;
                    long subCounter = 0;

                    if (_extractCancelFlag == true) return 0;

                    if (logicalDelDiv == 0)
                    {
                        // �폜�����܂܂Ȃ��ꍇ��GetData0���w��(�폜�t���O=0�̃f�[�^��Ԃ�)
                        status = this._iCustPrtPprWorkDB.SearchRef(ref custPrtPprBlDspRsltWorkObj, ref custPrtPprSalTblRsltWorkObj, (object)custPrtPprWork, out subCounter, 0, ConstantManagement.LogicalMode.GetData0);
                    }
                    else
                    {
                        // �폜�ς݂̏ꍇ��GetData1���w��(�폜�t���O=1�̃f�[�^��Ԃ�)
                        status = this._iCustPrtPprWorkDB.SearchRef(ref custPrtPprBlDspRsltWorkObj, ref custPrtPprSalTblRsltWorkObj, (object)custPrtPprWork, out subCounter, 0, ConstantManagement.LogicalMode.GetData1);
                    }

                    if (_extractCancelFlag == true) return 0;

                    resultList.AddRange(custPrtPprSalTblRsltWorkObj as ArrayList);
                }
                finally
                {
                    // �������̉��
                    custPrtPprBlDspRsltWork = null;
                    custPrtPprSalTblRsltWork = null;
                    custPrtPprBlDspRsltWorkObj = null;
                    custPrtPprSalTblRsltWorkObj = null;
                }

                if (_extractCancelFlag == true) return 0;

                if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                {
                    DataRow row;

                    // �e�L�X�g�o�͗p�e�[�u���^�C�g���̐ݒ�
                    SetTableCaption(mode);

                    // �`�[�P�ʂ́A�u�`�[�ԍ��v�y�сu�󒍃X�e�[�^�X�v������̂��̂��ЂƂ̂�����Ƃ��Ĕ��肷��
                    string exSlipNum = string.Empty;    // �ЂƂO�̓`�[�ԍ�
                    string exSlipNum2 = string.Empty;    // �ЂƂO�̓`�[�ԍ�
                    int exAcptAnOdrStatus = 0;          // �ЂƂO�̎󒍃X�e�[�^�X

                    long salAmntConsTaxInclu = 0; // �`�[�ʓ��ŋ��z�W�v�l

                    int rowNo = 1;
                    int rowDetailNo = 0;

                    // �ꌏ�ȏ�̖߂肪�������ꍇ�̂�
                    if (resultList.Count > 0)
                    {
                        int lastIndex = 0;

                        int maxCount = resultList.Count;

                        int beAcptAnOdrStatusSrc = 0;
                        string beHisDtlSlipNum = string.Empty;

                        AllDefSetAcs alldefsetacs = new AllDefSetAcs();
                        ArrayList outList = new ArrayList();
                        int yeardiv = 0;

                        int stat = alldefsetacs.Search(out outList, LoginInfoAcquisition.EnterpriseCode);

                        if (stat == 0)
                        {
                            foreach (AllDefSet alldefset in outList)
                            {
                                string sectionCodeE = alldefset.SectionCode.Trim();

                                if (sectionCodeE.Equals(LoginInfoAcquisition.Employee.BelongSectionCode.Trim()))
                                {
                                    yeardiv = alldefset.EraNameDispCd1;
                                }
                                else if (sectionCodeE.Equals("00"))
                                {
                                    yeardiv = alldefset.EraNameDispCd1;
                                }
                            }
                        }

                        for (int index = 0; index < maxCount; index++)
                        {
                            lastIndex = index;

                            CustPrtPprSalTblRsltWork data = (CustPrtPprSalTblRsltWork)(resultList[index]);

                            // �`�[�ԍ��t�H�[�}�b�g�Ή�
                            data.SalesSlipNum = GetSlipNum(data);
                            // �f�[�^�Z�b�g�ɕԂ�l���Z�b�g����
                            try
                            {
                                #region ���׃f�[�^�e�[�u��

                                row = _salesDetailTbl4Text.NewRow();

                                if (data.DataDiv == 0) // ����f�[�^�̏ꍇ
                                {
                                    #region ���ׁE����f�[�^
                                    // �ԕi�E�l������̂��߂̐��ʁE���z�̕���(1or-1)
                                    // �i�ԕi�̒l������-1*-1��1�j
                                    // ���ԕi�E�l�����̓f�[�^�㐔�ʃ}�C�i�X�Ȃ̂ŁAdetailSign�������ăv���X�ɂ���
                                    // �@�P����Abs���Ƃ�킯�ł͂Ȃ��̂Œ��ӁB
                                    int detailSign = 1;

                                    // �ԕi����
                                    if (data.SalesSlipCd == 1) detailSign *= -1;

                                    // ���i�l������(�s�l���͏��O)
                                    if (data.SalesSlipCdDtl == 2 && !string.IsNullOrEmpty(data.GoodsNo)) detailSign *= -1;
                                    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = false;
                                    row[_dataSet.SalesDetail.DataDivColumn.ColumnName] = data.DataDiv;
                                    row[_dataSet.SalesDetail.RowNoColumn.ColumnName] = rowNo;
                                    row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = data.SalesDate;
                                    row[_dataSet.SalesDetail.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                                    row[_dataSet.SalesDetail.SalesRowNoColumn.ColumnName] = data.SalesRowNo;
                                    row[_dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                                    row[_dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                                    row[_dataSet.SalesDetail.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                                    row[this._dataSet.SalesDetail.RetuppercntColumn.ColumnName] = data.Retuppercnt;
                                    row[this._dataSet.SalesDetail.RetuppercntDivColumn.ColumnName] = data.RetuppercntDiv;

                                    if (data.HistoryDiv == 0)
                                    {
                                        // �����ȊO
                                        row[_dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName] = data.AcptAnOdrRemainCnt;
                                    }
                                    else
                                    {
                                        // ����
                                        // �i�����I�ɂ͏o�א��Ɠ��������鎖�Őԓ`���s�\�ɂ���{�o�א��܂ł͐ԓ`�\�ɂ���j
                                        row[_dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName] = data.ShipmentCnt;
                                    }
                                    // �`�[�敪������
                                    if (data.SalesSlipCd == 0)
                                    {
                                        if (data.AcptAnOdrStatus == 20)
                                        {
                                            row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "��";
                                        }
                                        else if (data.AcptAnOdrStatus == 30)
                                        {
                                            row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "����";
                                        }
                                        else if (data.AcptAnOdrStatus == 40)
                                        {
                                            row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "�ݏo";
                                        }
                                        else
                                        {
                                        }
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "�ԕi";
                                    }
                                    row[_dataSet.SalesDetail.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                                    row[_dataSet.SalesDetail.GoodsNameColumn.ColumnName] = data.GoodsName;
                                    row[_dataSet.SalesDetail.GoodsNoColumn.ColumnName] = data.GoodsNo;
                                    if (data.BLGoodsCode == 0)
                                    {
                                        row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = DBNull.Value;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = data.BLGoodsCode.ToString().PadLeft(CT_DEPTH_BLGOODSCODE, '0');
                                    }
                                    row[_dataSet.SalesDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode;
                                    row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] = detailSign * data.ShipmentCnt;
                                    row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = data.ListPriceTaxExcFl;
                                    row[_dataSet.SalesDetail.CostRateColumn.ColumnName] = data.CostRate;     //������
                                    row[_dataSet.SalesDetail.SalesRateColumn.ColumnName] = data.SalesRate;   //������
                                    row[_dataSet.SalesDetail.OpenPriceDivColumn.ColumnName] = data.OpenPriceDiv;
                                    row[_dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName] = data.SalesUnPrcTaxExcFl;
                                    row[_dataSet.SalesDetail.SalesUnitCostColumn.ColumnName] = data.SalesUnitCost;
                                    row[_dataSet.SalesDetail.BfSalesUnitPriceColumn.ColumnName] = data.BfSalesUnitPrice;//�ύX�O�P��
                                    row[_dataSet.SalesDetail.BfUnitCostColumn.ColumnName] = data.BfUnitCost;//�ύX�O����
                                    row[_dataSet.SalesDetail.BfListPriceColumn.ColumnName] = data.BfListPrice;//�ύX�O�艿
                                    // 0:�ʏ�(PCC�A�g�Ȃ�)�A1:�蓮�񓚁A2:������
                                    if (data.AutoAnswerDivSCM == 0)
                                    {
                                        row[_dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName] = "�ʏ�";
                                    }
                                    else if (data.AutoAnswerDivSCM == 1)
                                    {
                                        row[_dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName] = "�蓮��";
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName] = "������";
                                    }
                                    if (data.InquiryNumber == 0)
                                    {
                                        row[_dataSet.SalesDetail.InquiryNumberColumn.ColumnName] = string.Empty; //�⍇���ԍ�
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.InquiryNumberColumn.ColumnName] = data.InquiryNumber.ToString().PadLeft(CT_DEPTH_INQUIRYNUMBER, '0'); //�⍇���ԍ�
                                    }
                                    row[_dataSet.SalesDetail.ConsTaxLayMethodColumn.ColumnName] = data.ConsTaxLayMethod;
                                    # region [����Ŋ֘A]
                                    bool printTax = true;
                                    Int64 salesTotalTaxInc;
                                    Int64 salesTotalTaxExc = data.SalesMoneyTaxExc;
                                    Int64 salesPriceConsTax;

                                    // ����������Ŋz�̎擾
                                    if (data.ConsTaxLayMethod == 0) // �`�[�P��
                                    {
                                        if (data.SalesRowNo == 1)  // �`�[���̖��א擪�s�ɏ���ł��󎚂����
                                        {
                                            salesPriceConsTax = data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                                        }
                                        else
                                        {
                                            salesPriceConsTax = 0;
                                            printTax = false;
                                        }
                                    }
                                    else if (data.ConsTaxLayMethod == 1) // ���גP��
                                    {
                                        salesPriceConsTax = data.SalesPriceConsTax;
                                    }
                                    else
                                    {
                                        salesPriceConsTax = 0;
                                    }

                                    // �ō����z�̎擾
                                    salesTotalTaxInc = salesTotalTaxExc + salesPriceConsTax;

                                    if (printTax)
                                    {
                                        // ����ň󎚗L������Ƌ��z����
                                        int totalAmountDispWayCd = data.TotalAmountDispWayCd;
                                        int taxationDivCd = data.TaxationDivCd;

                                        // ����ň󎚗L������
                                        printTax = ReflectMoneyForTaxPrint(ref salesTotalTaxExc, ref salesPriceConsTax, ref salesTotalTaxInc, totalAmountDispWayCd, data.ConsTaxLayMethod, taxationDivCd);
                                        if (printTax)
                                        {
                                            if (salesPriceConsTax != 0)
                                            {
                                                row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = detailSign * salesPriceConsTax;
                                                row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = data.ConsTaxRate; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                                            }
                                            else
                                            {
                                                // �󎚂��Ȃ�
                                                row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                                row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                                            }
                                        }
                                        else
                                        {
                                            // �󎚂��Ȃ�
                                            row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                            row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                                        }
                                    }
                                    else
                                    {
                                        // �󎚂��Ȃ�
                                        row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                        row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                                    }
                                    // �Ŕ����z�Z�b�g
                                    row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName] = detailSign * salesTotalTaxExc;
                                    // �ō����z�Z�b�g
                                    row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = detailSign * salesTotalTaxInc;
                                    # endregion
                                    row[_dataSet.SalesDetail.TotalCostColumn.ColumnName] = detailSign * data.TotalCost;
                                    // �ޕʌ^��
                                    row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = GetModelDesignationNoAndCategoryNo(data);
                                    // �^���w��ԍ�(���l)
                                    row[_dataSet.SalesDetail.ModelDesignationNoOrgColumn.ColumnName] = data.ModelDesignationNo;
                                    // �ޕʔԍ�(���l)
                                    row[_dataSet.SalesDetail.CategoryNoOrgColumn.ColumnName] = data.CategoryNo;
                                    row[_dataSet.SalesDetail.ModelFullNameColumn.ColumnName] = data.ModelFullName;
                                    // �Ԏ햼�J�i
                                    row[_dataSet.SalesDetail.ModelHalfNameColumn.ColumnName] = data.ModelHalfName;
                                    // �N��[NULL�̂Ƃ��͋�]
                                    if (data.FirstEntryDate == 0)
                                    {
                                        row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                                    }
                                    else
                                    {
                                        string firstEntryDate = "";

                                        if (data.FirstEntryDate.ToString().Length < 6)
                                        {
                                            firstEntryDate = "0000" + "/" + data.FirstEntryDate.ToString("D2");
                                        }
                                        else
                                        {
                                            firstEntryDate = data.FirstEntryDate.ToString().Substring(0, 4) + "/" + data.FirstEntryDate.ToString().Substring(4, 2);
                                        }
                                        firstEntryDate = firstEntryDate.Replace(@"/00", "");

                                        if (yeardiv == 1)
                                        {
                                            string date, stTarget;
                                            int StartTotalUnitYm;
                                            if (data.FirstEntryDate.ToString().Substring(4, 2) == "00")
                                            {
                                                date = data.FirstEntryDate.ToString().Substring(0, 4) + "0101";
                                                StartTotalUnitYm = Convert.ToInt32(date);
                                                stTarget = TDateTime.LongDateToString("GGyy", StartTotalUnitYm);
                                            }
                                            else
                                            {
                                                date = data.FirstEntryDate.ToString() + "01";
                                                StartTotalUnitYm = Convert.ToInt32(date);
                                                stTarget = TDateTime.LongDateToString("GGyymm", StartTotalUnitYm);
                                            }

                                            row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = stTarget;
                                        }
                                        else
                                        {
                                            row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = firstEntryDate;
                                        }
                                    }
                                    row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = data.FrameNo;

                                    row[_dataSet.SalesDetail.FullModelColumn.ColumnName] = data.FullModel;
                                    row[_dataSet.SalesDetail.SlipNoteColumn.ColumnName] = data.SlipNote;
                                    row[_dataSet.SalesDetail.SlipNote2Column.ColumnName] = data.SlipNote2;
                                    row[_dataSet.SalesDetail.SlipNote3Column.ColumnName] = data.SlipNote3;
                                    row[_dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                                    row[_dataSet.SalesDetail.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                                    row[_dataSet.SalesDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                                    row[_dataSet.SalesDetail.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                                    row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = data.SupplierCd;
                                    row[_dataSet.SalesDetail.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                                    row[_dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName] = data.PartySaleSlipNum;
                                    row[_dataSet.SalesDetail.CarMngCodeColumn.ColumnName] = data.CarMngCode;
                                    // �v�㌳��No[NULL�̂Ƃ��͋�]
                                    if (data.AcptAnOdrStatusSrc == 20)
                                    {
                                        if (!string.IsNullOrEmpty(data.HisDtlSlipNum.ToString()))
                                        {
                                            row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = data.HisDtlSlipNum;
                                        }
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                                    }

                                    if (data.AcptAnOdrStatusSrc == 40)
                                    {
                                        row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = data.HisDtlSlipNum;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = string.Empty;
                                    }

                                    // ����No[NULL�̂Ƃ��͋�]
                                    if (data.SrcSalesSlipNum == "0")
                                    {
                                        row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = string.Empty;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = data.SrcSalesSlipNum;
                                    }
                                    row[_dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName] = data.SalesOrderDivCd;
                                    if (data.SalesOrderDivCd == 0)
                                    {
                                        row[_dataSet.SalesDetail.SalesOrderDivCdNameColumn.ColumnName] = "���";
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.SalesOrderDivCdNameColumn.ColumnName] = "�݌�";
                                    }
                                    row[_dataSet.SalesDetail.WarehouseCdColumn.ColumnName] = data.WarehouseCode;
                                    row[_dataSet.SalesDetail.WarehouseNameColumn.ColumnName] = data.WarehouseName;
                                    // �����d��No[NULL�̂Ƃ��͋�]
                                    if (data.SupplierSlipNo == 0)
                                    {
                                        row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                                    }
                                    row[_dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName] = data.StockPartySaleSlipNum;
                                    // ������R�[�h[NULL�̂Ƃ��͋�]
                                    if (data.UOESupplierCd == 0)
                                    {
                                        row[_dataSet.SalesDetail.UOESupplierCdColumn.ColumnName] = string.Empty;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.UOESupplierCdColumn.ColumnName] = data.UOESupplierCd.ToString().PadLeft(CT_DEPTH_UOESUPPLIERCODE, '0');
                                    }
                                    row[_dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName] = data.UOESupplierSnm;
                                    row[_dataSet.SalesDetail.UOERemark1Column.ColumnName] = data.UoeRemark1;
                                    row[_dataSet.SalesDetail.UOERemark2Column.ColumnName] = data.UoeRemark2;
                                    row[_dataSet.SalesDetail.GuideNameColumn.ColumnName] = data.GuideName;
                                    row[_dataSet.SalesDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                                    row[_dataSet.SalesDetail.SectionGuideNameColumn.ColumnName] = data.SectionGuideNm;
                                    row[_dataSet.SalesDetail.DtlNoteColumn.ColumnName] = data.DtlNote;
                                    row[_dataSet.SalesDetail.ColorName1Column.ColumnName] = data.ColorName1;
                                    row[_dataSet.SalesDetail.TrimNameColumn.ColumnName] = data.TrimName;
                                    row[_dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName] = data.BfListPrice; // �ύX�O�艿
                                    row[_dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName] = data.BfSalesUnitPrice;// �ύX�O����
                                    row[_dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName] = data.BfUnitCost;// �ύX�O����
                                    // ���[�J�[�R�[�h
                                    row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = data.GoodsMakerCd;
                                    row[_dataSet.SalesDetail.MakerNameColumn.ColumnName] = data.MakerName;
                                    row[_dataSet.SalesDetail.CostColumn.ColumnName] = data.Cost;
                                    // ���Ӑ�`�[�ԍ�[NULL�̂Ƃ��͋�]
                                    if (data.CustSlipNo == 0)
                                    {
                                        row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = DBNull.Value;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = data.CustSlipNo;
                                    }
                                    if (data.AddUpADate != DateTime.MinValue)
                                    {
                                        row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = DBNull.Value;
                                    }
                                    row[_dataSet.SalesDetail.AccRecDivCdColumn.ColumnName] = data.AccRecDivCd;
                                    if (data.AccRecDivCd == 1)
                                    {
                                        row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = "���|";
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = "����";
                                    }
                                    if (data.DebitNoteDiv == 0)
                                    {
                                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "���`";
                                    }
                                    else if (data.DebitNoteDiv == 1)
                                    {
                                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "�ԓ`";
                                    }
                                    else if (data.DebitNoteDiv == 2)
                                    {
                                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "����";
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                                    }
                                    if (((long)row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] < 0 ||
                                         (double)row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] < 0)
                                        && data.SalesSlipCdDtl != 2)
                                    {
                                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "�ԓ`";
                                    }
                                    // �e��(����)
                                    row[_dataSet.SalesDetail.GrossProfitDetailColumn.ColumnName] = detailSign * this.GetGrossProfitDetail(data);

                                    //�e����
                                    row[_dataSet.SalesDetail.GrossProfitMarginColumn.ColumnName] = detailSign * this.GetGrossProfitMargin(data);  //#7861 2011/11/23 ADD

                                    // �[����R�[�h
                                    row[_dataSet.SalesDetail.AddresseeCodeColumn.ColumnName] = data.AddresseeCode;
                                    // �[���於1+2
                                    row[_dataSet.SalesDetail.AddresseeNameColumn.ColumnName] = data.AddresseeName + data.AddresseeName2;
                                    // �[���於1�̂�
                                    row[_dataSet.SalesDetail.AddresseeName1Column.ColumnName] = data.AddresseeName;
                                    // �[���於2�̂�
                                    row[_dataSet.SalesDetail.AddresseeName2Column.ColumnName] = data.AddresseeName2;
                                    // ���͓�
                                    if (data.InputDay != DateTime.MinValue)
                                    {
                                        row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = data.InputDay;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = DBNull.Value;
                                    }
                                    // ���׋敪
                                    row[_dataSet.SalesDetail.SalesSlipCdDtlColumn.ColumnName] = data.SalesSlipCdDtl;
                                    switch (data.SalesSlipCdDtl)
                                    {
                                        default:
                                        case 0:
                                        case 1:
                                            {
                                                row[_dataSet.SalesDetail.SalesSlipCdDtlNameColumn.ColumnName] = "�ʏ�";
                                            }
                                            break;
                                        case 2:
                                            {
                                                if (string.IsNullOrEmpty(data.GoodsNo))
                                                {
                                                    row[_dataSet.SalesDetail.SalesSlipCdDtlNameColumn.ColumnName] = "�s�l��";
                                                }
                                                else
                                                {
                                                    row[_dataSet.SalesDetail.SalesSlipCdDtlNameColumn.ColumnName] = "���i�l��";
                                                }
                                            }
                                            break;
                                    }

                                    // ���i�啪��
                                    row[_dataSet.SalesDetail.GoodsLGroupColumn.ColumnName] = data.GoodsLGroup;
                                    row[_dataSet.SalesDetail.GoodsLGroupNameColumn.ColumnName] = data.GoodsLGroupName;
                                    // ���i������
                                    row[_dataSet.SalesDetail.GoodsMGroupColumn.ColumnName] = data.GoodsMGroup;
                                    row[_dataSet.SalesDetail.GoodsMGroupNameColumn.ColumnName] = data.GoodsMGroupName;
                                    // ���i����
                                    row[_dataSet.SalesDetail.GoodsKindCodeColumn.ColumnName] = data.GoodsKindCode;
                                    switch (data.GoodsKindCode)
                                    {
                                        case 0:
                                            {
                                                row[_dataSet.SalesDetail.GoodsKindCodeNameColumn.ColumnName] = "����";
                                            }
                                            break;
                                        case 1:
                                        default:
                                            {
                                                row[_dataSet.SalesDetail.GoodsKindCodeNameColumn.ColumnName] = "���̑�";
                                            }
                                            break;
                                    }
                                    // �I��
                                    row[_dataSet.SalesDetail.WarehouseShelfNoColumn.ColumnName] = data.WarehouseShelfNo;

                                    // ���i�敪
                                    row[_dataSet.SalesDetail.EnterpriseGanreCodeColumn.ColumnName] = data.EnterpriseGanreCode;
                                    row[_dataSet.SalesDetail.CarMngNoColumn.ColumnName] = data.CarMngNo; // �ԗ��Ǘ�SEQ
                                    row[_dataSet.SalesDetail.MakerCodeColumn.ColumnName] = data.MakerCode; // �Ԏ탁�[�J�[�R�[�h
                                    row[_dataSet.SalesDetail.ModelCodeColumn.ColumnName] = data.ModelCode; // �Ԏ�R�[�h
                                    row[_dataSet.SalesDetail.ModelSubCodeColumn.ColumnName] = data.ModelSubCode; // �Ԏ�T�u�R�[�h
                                    row[_dataSet.SalesDetail.EngineModelNmColumn.ColumnName] = data.EngineModelNm; // �G���W���^������
                                    row[_dataSet.SalesDetail.ColorCodeColumn.ColumnName] = data.ColorCode; // �J���[�R�[�h
                                    row[_dataSet.SalesDetail.TrimCodeColumn.ColumnName] = data.TrimCode; // �g�����R�[�h
                                    row[_dataSet.SalesDetail.DeliveredGoodsDivColumn.ColumnName] = data.DeliveredGoodsDiv; // �[�i�敪

                                    int[] wkFullModelFixedNoAry = new int[data.FullModelFixedNoAry.Length];
                                    for (int i = 0; i < data.FullModelFixedNoAry.Length; i++)
                                    {
                                        wkFullModelFixedNoAry[i] = data.FullModelFixedNoAry[i];
                                    }
                                    row[_dataSet.SalesDetail.FullModelFixedNoAryColumn.ColumnName] = wkFullModelFixedNoAry; // �t���^���Œ�ԍ��z��

                                    string[] wkFreeSrchMdlFxdNoAry = new string[0];
                                    if (null != data.FreeSrchMdlFxdNoAry && 0 < data.FreeSrchMdlFxdNoAry.Length)
                                    {
                                        BinaryFormatter formatter = new BinaryFormatter();
                                        MemoryStream ms = new MemoryStream(data.FreeSrchMdlFxdNoAry);
                                        wkFreeSrchMdlFxdNoAry = (string[])formatter.Deserialize(ms);
                                        ms.Close();
                                    }
                                    row[_dataSet.SalesDetail.FreeSrchMdlFxdNoAryColumn.ColumnName] = wkFreeSrchMdlFxdNoAry;

                                    byte[] wkCategoryObjAry = new byte[data.CategoryObjAry.Length];
                                    for (int i = 0; i < data.CategoryObjAry.Length; i++)
                                    {
                                        wkCategoryObjAry[i] = data.CategoryObjAry[i];
                                    }
                                    row[_dataSet.SalesDetail.CategoryObjAryColumn.ColumnName] = wkCategoryObjAry; // �����I�u�W�F�N�g�z��
                                    row[_dataSet.SalesDetail.SalesInputCodeColumn.ColumnName] = data.SalesInputCode; // ���s��
                                    row[_dataSet.SalesDetail.FrontEmployeeCdColumn.ColumnName] = data.FrontEmployeeCd; // �󒍎�
                                    row[_dataSet.SalesDetail.HistoryDivNameColumn.ColumnName] = this.GetHistoryDivName(data.HistoryDiv);
                                    row[_dataSet.SalesDetail.SlipPrintTimeColumn.ColumnName] = this.GetSlipPrintTimeText(data.UpdateDateTime); // �`�[���s����
                                    if (data.UpdateDateTimeDetail != 0)
                                    {
                                        DateTime dt = new DateTime(data.UpdateDateTimeDetail);
                                        row[_dataSet.SalesDetail.UpdateDateTimeColumn.ColumnName] = dt.ToString("yyyy/MM/dd HH:mm:ss"); // �X�V����
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.UpdateDateTimeColumn.ColumnName] = string.Empty;
                                    }
                                    row[_dataSet.SalesDetail.MileageColumn.ColumnName] = data.Mileage;
                                    row[_dataSet.SalesDetail.CarNoteColumn.ColumnName] = data.CarNote;

                                    row[_dataSet.SalesDetail.ChangeGoodsNoColumn.ColumnName] = data.ChangeGoodsNo; // �ϊ���i�ԁ@// ADD ���R 2015/05/11 �e�L�X�g�o�͂ɂāu���o���������Ȃ��v�̏ꍇ�ɕϊ���i�Ԃ��o�͂���Ȃ��̑Ή�

                                    // ---------- ADD 2016/01/21 Y.Wakita ---------->>>>>
                                    row[_dataSet.SalesDetail.SalesNotRecognitionCntColumn.ColumnName] = DBNull.Value;   // ���v�㐔
                                    row[_dataSet.SalesDetail.SalesRecognitionCntColumn.ColumnName] = DBNull.Value;      // �v�㐔

                                    // �󒍃X�e�[�^�X��"�ݏo"�܂���"��" ���� ����`�[�敪(����)��"����"�̏ꍇ
                                    if ((data.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Shipment ||
                                         data.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder) &&
                                         data.SalesSlipCd == 0)
                                    {
                                        row[_dataSet.SalesDetail.SalesNotRecognitionCntColumn.ColumnName] = data.AcptAnOdrRemainCnt;                    // ���v�㐔
                                        row[_dataSet.SalesDetail.SalesRecognitionCntColumn.ColumnName] = (data.ShipmentCnt - data.AcptAnOdrRemainCnt);  // �v�㐔
                                    }
                                    // ---------- ADD 2016/01/21 Y.Wakita ----------<<<<<

                                    // ---- ADD K2015/06/09 �� �e�L�X�g�o�͍��ڂɑ�񔄉��ǉ���ǉ�����---->>>>>
                                    // �e�L�X�g�o�͂ɂāu���o���������Ȃ��v�̏ꍇ�ɑ�񔄉����o�͂���Ȃ��̑Ή�
                                    if (this._opt_Momose == Convert.ToInt32(Option.ON))
                                    {
                                        row[_dataSet.SalesDetail.SecondSalePriceColumn.ColumnName] = this.GetSecondPrice(data);
                                    }
                                    // ---- ADD K2015/06/09 �� �e�L�X�g�o�͍��ڂɑ�񔄉��ǉ���ǉ�����----<<<<<

                                    // ---------- ADD K2015/12/10 Y.Wakita ---------->>>>>
                                    // �e�L�X�g�o�͂ɂāu���o���������Ȃ��v�̏ꍇ�Ɂu�n��v�Ɓu���̓R�[�h�v���o�͂���Ȃ���Q�Ή�
                                    if (this._opt_Meigo == Convert.ToInt32(Option.ON))
                                    {
                                        row[_dataSet.SalesDetail.SalesAreaNameColumn.ColumnName] = data.SalesAreaName;
                                        if (data.CustAnalysCode1 != 0)
                                        {
                                            row[_dataSet.SalesDetail.CustAnalysCode1Column.ColumnName] = data.CustAnalysCode1;
                                        }
                                        if (data.CustAnalysCode2 != 0)
                                        {
                                            row[_dataSet.SalesDetail.CustAnalysCode2Column.ColumnName] = data.CustAnalysCode2;
                                        }
                                        if (data.CustAnalysCode3 != 0)
                                        {
                                            row[_dataSet.SalesDetail.CustAnalysCode3Column.ColumnName] = data.CustAnalysCode3;
                                        }
                                        if (data.CustAnalysCode4 != 0)
                                        {
                                            row[_dataSet.SalesDetail.CustAnalysCode4Column.ColumnName] = data.CustAnalysCode4;
                                        }
                                        if (data.CustAnalysCode5 != 0)
                                        {
                                            row[_dataSet.SalesDetail.CustAnalysCode5Column.ColumnName] = data.CustAnalysCode5;
                                        }
                                        if (data.CustAnalysCode6 != 0)
                                        {
                                            row[_dataSet.SalesDetail.CustAnalysCode6Column.ColumnName] = data.CustAnalysCode6;
                                        }
                                    }
                                    // ---------- ADD K2015/12/10 Y.Wakita ----------<<<<<

                                    #endregion // ���ׁE����f�[�^
                                }
                                else
                                {
                                    #region ���ׁE�����f�[�^
                                    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.RowNoColumn.ColumnName] = rowNo;
                                    row[_dataSet.SalesDetail.DataDivColumn.ColumnName] = data.DataDiv;
                                    // �������f�[�^���ADDUPADATE���`�[���t�Ȃ̂�SalesDateColumn�ɂ�ADDUPADATE���Z�b�g����(�v����Ɠ������e�ɂȂ�)
                                    row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = data.AddUpADate;
                                    row[_dataSet.SalesDetail.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                                    row[_dataSet.SalesDetail.SalesRowNoColumn.ColumnName] = data.SalesRowNo;
                                    row[_dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                                    row[_dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                                    row[_dataSet.SalesDetail.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                                    row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "����";
                                    row[_dataSet.SalesDetail.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                                    row[_dataSet.SalesDetail.GoodsNameColumn.ColumnName] = data.GoodsName;
                                    row[_dataSet.SalesDetail.GoodsNoColumn.ColumnName] = data.GoodsNo;
                                    if (data.BLGoodsCode == 0)
                                    {
                                        row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = DBNull.Value;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = data.BLGoodsCode.ToString().PadLeft(CT_DEPTH_BLGOODSCODE, '0');
                                    }
                                    row[_dataSet.SalesDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode;
                                    row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.OpenPriceDivColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SalesUnitCostColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName] = data.SalesMoneyTaxExc;
                                    row[_dataSet.SalesDetail.ConsTaxLayMethodColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                                    row[_dataSet.SalesDetail.TotalCostColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.ModelFullNameColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.ModelHalfNameColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.FullModelColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SlipNoteColumn.ColumnName] = data.SlipNote;
                                    row[_dataSet.SalesDetail.SlipNote2Column.ColumnName] = data.SlipNote2;
                                    row[_dataSet.SalesDetail.SlipNote3Column.ColumnName] = data.SlipNote3;
                                    row[_dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                                    row[_dataSet.SalesDetail.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                                    row[_dataSet.SalesDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                                    row[_dataSet.SalesDetail.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                                    row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SupplierSnmColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.CarMngCodeColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.WarehouseCdColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.WarehouseNameColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.UOESupplierCdColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.UOERemark1Column.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.UOERemark2Column.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.GuideNameColumn.ColumnName] = data.GuideName;
                                    row[_dataSet.SalesDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                                    row[_dataSet.SalesDetail.SectionGuideNameColumn.ColumnName] = data.SectionGuideNm;
                                    row[_dataSet.SalesDetail.DtlNoteColumn.ColumnName] = this.GetValidityTerm(data.DtlNote); // ���ה��l���L���������Z�b�g
                                    row[_dataSet.SalesDetail.ColorName1Column.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.TrimNameColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.MakerNameColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.CostColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = DBNull.Value;
                                    if (data.AddUpADate != DateTime.MinValue)
                                    {
                                        row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = DBNull.Value;
                                    }
                                    row[_dataSet.SalesDetail.AccRecDivCdColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = DBNull.Value;
                                    if (data.DebitNoteDiv == 0)
                                    {
                                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "��";
                                    }
                                    else if (data.DebitNoteDiv == 1)
                                    {
                                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "��";
                                    }
                                    else if (data.DebitNoteDiv == 2)
                                    {
                                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "���E�ςݍ�";
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                                    }
                                    row[_dataSet.SalesDetail.AddresseeCodeColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.AddresseeNameColumn.ColumnName] = DBNull.Value;
                                    // ���͓�
                                    if (data.InputDay != DateTime.MinValue)
                                    {
                                        row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = data.InputDay;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = DBNull.Value;
                                    }
                                    row[_dataSet.SalesDetail.SalesSlipCdDtlColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SalesSlipCdDtlNameColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.GoodsLGroupColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.GoodsLGroupNameColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.GoodsMGroupColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.GoodsMGroupNameColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.GoodsKindCodeColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.GoodsKindCodeNameColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.WarehouseShelfNoColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.HistoryDivNameColumn.ColumnName] = string.Empty; // �����敪
                                    row[_dataSet.SalesDetail.SlipPrintTimeColumn.ColumnName] = this.GetSlipPrintTimeText(data.UpdateDateTime); // �`�[���s����
                                    if (data.UpdateDateTimeDetail != 0)
                                    {
                                        DateTime dt = new DateTime(data.UpdateDateTimeDetail);
                                        row[_dataSet.SalesDetail.UpdateDateTimeColumn.ColumnName] = dt.ToString("yyyy/MM/dd HH:mm:ss"); // �X�V����
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.UpdateDateTimeColumn.ColumnName] = string.Empty;
                                    }
                                    #endregion // ���ׁE�����f�[�^
                                }

                                // �������[�h���u1�F���ׁv�̏ꍇ�A�s�ǉ�
                                if (mode == 1)
                                {
                                    if (data.DataDiv == 0)
                                    {
                                        this._salesDetailTbl4Text.Rows.Add(row);
                                    }
                                    else
                                    {
                                        // �萔���A�l�����̖��׃f�[�^�͂��̎��_�ł͍쐬���Ȃ�
                                        if ((data.SalesRowNo != 0) && (string.IsNullOrEmpty(data.GoodsName.TrimEnd())) == false)
                                        {
                                            this._salesDetailTbl4Text.Rows.Add(row);
                                        }
                                    }
                                }

                                #endregion // ���׃f�[�^�e�[�u��

                                #region ���z�f�[�^���W�v

                                //-------------------------
                                // ���z�f�[�^���W�v
                                //-------------------------
                                if (data.DataDiv == 0)  // ����f�[�^�̏ꍇ
                                {
                                    // �`�[�ʓ��ŋ��z�W�v
                                    if (data.TaxationDivCd == 2)
                                    {
                                        long consTaxInclu = (long)row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName]
                                                            - (long)row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName];
                                        salAmntConsTaxInclu += consTaxInclu;
                                    }

                                    // �ۑ�����Ă���`�[�ԍ����X�V
                                    if (!data.SalesSlipNum.Equals(exSlipNum2))
                                    {
                                        exSlipNum2 = data.SalesSlipNum;
                                    }
                                }

                                #endregion // ���z�f�[�^���W�v

                                #region �`�[�\���f�[�^�e�[�u��

                                // ����͍i�荞�݂��s��
                                // �i���̏������ڂ͓`�[�ԍ��A�󒍃X�e�[�^�X
                                if (index > 0 && (!data.SalesSlipNum.Equals(exSlipNum) || data.AcptAnOdrStatus != exAcptAnOdrStatus))
                                {
                                    // �`�[�\���O���b�h�ւ̃Z�b�g
                                    CustPrtPprSalTblRsltWork prevData = (CustPrtPprSalTblRsltWork)(resultList[index - 1]);
                                    CustPtrSalesDetailDataSet.SalesDetailDataTable table = this._salesDetailTbl4Text;
                                    rowDetailNo = rowNo;
                                    // �������[�h���u1�F���ׁv�̏ꍇ�A�s�ǉ�
                                    if (mode == 1)
                                    {
                                        AddFeeAndDiscountRow(ref table, ref rowDetailNo, prevData);
                                    }
                                    rowNo = rowDetailNo;
                                    prevData.AcptAnOdrStatusSrc = beAcptAnOdrStatusSrc;
                                    prevData.HisDtlSlipNum = beHisDtlSlipNum;
                                    // �������[�h���u0�F�`�[�v�̏ꍇ�A�`�[�O���b�h�ւ̃Z�b�g�i�`�[�P�ʁj
                                    if (mode == 0)
                                    {
                                        RecordSetToSlipList(prevData, rowNo, salAmntConsTaxInclu, yeardiv, 1);
                                    }
                                    beAcptAnOdrStatusSrc = data.AcptAnOdrStatusSrc;
                                    beHisDtlSlipNum = data.HisDtlSlipNum;
                                    rowNo = rowDetailNo;

                                    salAmntConsTaxInclu = 0; // �`�[�ʓ��ŋ��z�W�v�l��������
                                    if (_extractCancelFlag == true)
                                    {
                                        exAcptAnOdrStatus = data.AcptAnOdrStatus;
                                        exSlipNum = data.SalesSlipNum;
                                        rowNo++;

                                        break;
                                    }
                                }
                                if (index == 0)
                                {
                                    beAcptAnOdrStatusSrc = data.AcptAnOdrStatusSrc;
                                    beHisDtlSlipNum = data.HisDtlSlipNum;

                                }
                                // �`�[�ԍ�����ю󒍃X�e�[�^�X��ۑ�
                                exAcptAnOdrStatus = data.AcptAnOdrStatus;
                                exSlipNum = data.SalesSlipNum;
                                #endregion // �`�[�\���f�[�^�e�[�u��

                                rowNo++;
                            }
                            // --- UPD 2020/12/21 �x���Ή� ---------->>>>>
                            ///catch (ConstraintException ex)
                            catch (ConstraintException)
                            // --- UPD 2020/12/21 �x���Ή� ----------<<<<<
                            {
                            }
                        }

                        // �Ō�̓`�[�����Z�b�g
                        if (resultList != null && resultList.Count > 0)
                        {
                            ArrayList retList = resultList;
                            CustPrtPprSalTblRsltWork data = (CustPrtPprSalTblRsltWork)retList[lastIndex];

                            CustPtrSalesDetailDataSet.SalesDetailDataTable table = this._salesDetailTbl4Text;
                            rowDetailNo = rowNo;
                            // �������[�h���u1�F���ׁv�̏ꍇ�A�s�ǉ�
                            if (mode == 1)
                            {
                                AddFeeAndDiscountRow(ref table, ref rowDetailNo, data);
                            }
                            rowNo = rowDetailNo;
                            data.AcptAnOdrStatusSrc = beAcptAnOdrStatusSrc;
                            data.HisDtlSlipNum = beHisDtlSlipNum;
                            // �������[�h���u0�F�`�[�v�̏ꍇ�A�`�[�O���b�h�ւ̃Z�b�g�i�`�[�P�ʁj
                            if (mode == 0)
                            {
                                RecordSetToSlipList(data, rowNo, salAmntConsTaxInclu, yeardiv, 1);
                            }
                        }

                        // �������[�h���u1�F���ׁv�̏ꍇ
                        if (mode == 1)
                        {
                            // �����̂ݍs�ԍ��̔Ԃ��Ȃ���
                            DateTime exSalesDate = DateTime.MinValue;
                            rowDetailNo = 1;
                            exSlipNum = string.Empty;

                            string filter = string.Format("{0} <> {1}", this._dataSet.SalesDetail.DataDivColumn.ColumnName, 0);
                            string sort = string.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                                            this._dataSet.SalesDetail.SalesDateColumn.ColumnName,
                                            this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName,
                                            this._dataSet.SalesDetail.DataDivColumn.ColumnName,
                                            this._dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName,
                                            this._dataSet.SalesDetail.SalesSlipCdColumn.ColumnName,
                                            this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName);

                            DataRow[] dataRows = this._salesDetailTbl4Text.Select(filter, sort);
                            DataRow dataRow = null;
                            for (int i = 0; i <= dataRows.Length - 1; i++)
                            {
                                dataRow = dataRows[i];

                                if ((exSalesDate.Equals(dataRow[this._dataSet.SalesDetail.SalesDateColumn.ColumnName]) == false) ||
                                    (exSlipNum.Equals(dataRow[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName]) == false))
                                {
                                    rowDetailNo = 1;
                                }

                                dataRow[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName] = rowDetailNo++;

                                exSalesDate = (DateTime)dataRow[this._dataSet.SalesDetail.SalesDateColumn.ColumnName];
                                exSlipNum = (string)dataRow[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName];
                            }
                        }
                        // ���Ӑ斢���͂̂Ƃ�status=EOF�ŕԋp�����̂Ŗ��׊Y���f�[�^�������normal�ŕԂ�
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        // �����[���Ȃ�΃����[�gstatus��0:����ł��Y���Ȃ��ŕԂ�
                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // �f�[�^�Z�b�g���N���A
                this._salesListTbl4Text.Clear();
                this._salesDetailTbl4Text.Clear();

                resultList = null;
            }

            return status;
        }
        //----- ADD 2015/02/05 ������ --------------------<<<<<

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="custPtrPpr">���������N���X</param>
        /// <param name="logicalDelDiv">�폜�w��敪�F0=�W��,1=�폜���̂�</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note : 2009/11/25 ������</br>
        /// <br>              PM.NS�ێ�˗��B �s��Ή�</br>
        /// <br>              �@���׃^�u�Ń`�F�b�N�{�b�N�X��\������B�i�����f�[�^�A�ߋ����̗����f�[�^�ȊO�j</br>
        /// <br>              �A�ԕi���݌ɓo�^���̕s��Ή�</br>
        /// <br>Update Note : 2009/12/15 ������</br>
        /// <br>              Redmine#1919�Ή�</br>
        /// <br>Update Note : 2009/12/28 ������ PM.NS�ێ�˗��C</br>
        /// <br>              �ύX�O�P���A�ύX�O�����̒ǉ�</br>
        /// <br>Update Note : 2010/01/29 �k���r 4������</br>
        /// <br>              �ԕi�s�ݒ�@�\�̒ǉ�</br>
        /// <br>Update Note : 2010/08/05 ������</br>
        /// <br>              ����`�[���͎����z�ύX�����ꍇ���ׂ̐F��ς��ĕ\�����Ă��邪�A���Ӑ�d�q�����ł����l�ɐF��ς��ĕ\������B</br>
        /// <br>Update Note : 2010/08/31 ������</br>
        /// <br>              Redmine#14006�Ή�</br>
        /// <br>Update Note : 2010/09/01 caowj</br>
        /// <br>              Redmine#14073�Ή�</br>
        /// <br>Update Note: 2010/09/16 �k���r</br>
        /// <br>            �E��QID:14483 PM1012PM.NS��Q���ǑΉ��i�W�����j</br>
        /// <br>Update Note: 2010/12/20 yangmj </br>
        /// <br>             �W�����i�\���̕ύX</br>
        /// <br>             �N���Ɍ��̂ݐݒ肳��Ă���ꍇ�̃G���[�C��</br>
        /// <br>             �v�㌳�󒍇��E�v�㌳�ݏo���̕\�����e�C��</br>
        /// <br>             ���v�\�����ʂɏ��i�l�������������Ȃ��悤�C��</br>
        /// <br>            �E��QID:14483 PM1012PM.NS��Q���ǑΉ��i�W�����j</br>
        /// <br>Update Note: 2011/09/21 �c���� </br>
        /// <br>             Redmine#25430�Ή�</br>
        /// <br>             ���Ӑ�d�q�����̌����s��ɂ��Ă̏C��</br>
        /// <br>Update Note: 2011/11/23 ����</br>
        /// <br>             Redmine#8079�Ή�</br>
        /// <br>             ���Ӑ�d�q����/�N���̕\���ɂ��Ă̏C��</br>
        /// <br>Update Note: 2011/11/28 �k�m</br>
        /// <br>             Redmine#8172�̑Ή�</br>
        /// <br>             ���Ӑ�d�q����/(BL�߰µ��ް����)�⍇���ԍ��̒ǉ�</br>
		/// <br>Update Note : 2013/01/30 wangf </br>
		/// <br>            : 10801804-00�A���x���P�֘A�ARedmine#34513 �T�[�o�[���׌y���ׁ̈A���Ӑ�d�q�����̉��ǂ̑Ή�</br>
		/// <br>            : �c���W�v�̃^�C�~���O�����炷</br>
        /// <br>UpdateNote  : K2014/05/08 �ђ��}</br>
        /// <br>            : ���Ӑ�d�q������CSV�o�͍��ڂɎԎ탁�[�J�[�R�[�h��ǉ�����A��������ʑΉ�</br>
        /// <br>Update Note : K2015/4/27 ��</br>
        /// <br>            : 11100842-00 �����Z���i���̌ʊJ���˗�
        /// <br>            : ���Ӑ�d�q������񔄉���ǉ�����B�����Z���i���I�v�V�������L���̏ꍇ�̂݁B</br>
        /// <br>Update Note : K2015/06/16 鸏� </br>
        /// <br>            : ���C�S���̌ʊJ���˗� </br>
        /// <br>            : ���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����B</br>
        /// <br>Update Note : 2016/01/21 �e�c ���V</br>
        /// <br>�Ǘ��ԍ�    : 11270007-00</br>
        /// <br>            : �d�|�ꗗ��2808 �ݏo�󒍑Ή�</br>
        /// <br>            : �@���������Ɂu�o�׏󋵁v���ڂ�ǉ�</br>
        /// <br>            : �A���ו\���Ɍv�㐔�A���v�㐔���ڂ�ǉ�</br>
        /// <br>Update Note : 2020/03/11 ���V��</br>
        /// <br>�Ǘ��ԍ�    : 11570208-00</br>
        /// <br>            : PMKOBETSU-2912 �y���ŗ��Ή�</br>
        /// <br>            : �`�[�^�u�A���׃^�u�Ɂu����ŗ��v���ڂ�ǉ�</br>
        /// </remarks>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 UPD
        //public int Search(CustPrtPpr custPrtPpr, int logicalDelDiv)
        public int Search( CustPrtPpr custPrtPpr, int logicalDelDiv, out long counter )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 UPD
        {
            int status;

            // ���Ӑ�R�[�h���w�肳��Ă���Ύc����\��
            if ( custPrtPpr.CustomerCode == 0 )
            {
                // ���Ӑ�R�[�h���Ȃ��ꍇ�͎c����\�����Ȃ�
                _customerPointed = false;
            }
            else
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 DEL
                //// ���Ӑ�����擾���A���ߓ����擾���Ă���
                //CustomerSearchRet[] customerInfo;
                //CustomerSearchPara customerPara = new CustomerSearchPara();
                //customerPara.CustomerCode = custPrtPpr.CustomerCode;
                //status = this._customerAcs.Serch(out customerInfo, customerPara);
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    CustomerSearchRet data = (CustomerSearchRet)customerInfo[0];
                //    this._customerCalcDate = data.TotalDay;
                //    //foreach (CustomerSearchRet data in (ArrayList)customerInfo)
                //    //{
                //    // ���ߓ����擾
                //    //this._customerCalcDate = data.TotalDay;
                //    //}
                //}
                //else
                //{
                //    // ���Ӑ��񂪂Ȃ�
                //    // *** ���̂Ȃ����Ӑ�̓p�����[�^�Ƃ��ēn���Ă��Ȃ� ***
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 DEL
            }

            // �p�����[�^�N���X���쐬
            CustPrtPprWork custPrtPprWork = new CustPrtPprWork();
            CustPrtPpr2CustPrtPprWork( ref custPrtPpr, ref custPrtPprWork );

            //---------------------------------
            // �Ԃ�l�Ŏg�p����N���X���쐬
            //---------------------------------

            // �c���Ɖ�ɕ\������̂łP���̂�
            CustPrtPprBlDspRsltWork custPrtPprBlDspRsltWork = new CustPrtPprBlDspRsltWork();
            object custPrtPprBlDspRsltWorkObj = (object)custPrtPprBlDspRsltWork;

            // ���ׂȂ̂�recordCount�����z��ŋA���Ă���
            CustPrtPprSalTblRsltWork custPrtPprSalTblRsltWork = new CustPrtPprSalTblRsltWork();
            object custPrtPprSalTblRsltWorkObj = (object)custPrtPprSalTblRsltWork;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 UPD
            //long counter = 0;
            counter = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 UPD

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 ADD
            if ( _extractCancelFlag == true ) return 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 ADD
            if ( logicalDelDiv == 0 )
            {
                // �폜�����܂܂Ȃ��ꍇ��GetData0���w��(�폜�t���O=0�̃f�[�^��Ԃ�)
                status = this._iCustPrtPprWorkDB.SearchRef( ref custPrtPprBlDspRsltWorkObj, ref custPrtPprSalTblRsltWorkObj, (object)custPrtPprWork, out counter, 0, ConstantManagement.LogicalMode.GetData0 );
            }
            else
            {
                // �폜�ς݂̏ꍇ��GetData1���w��(�폜�t���O=1�̃f�[�^��Ԃ�)
                status = this._iCustPrtPprWorkDB.SearchRef( ref custPrtPprBlDspRsltWorkObj, ref custPrtPprSalTblRsltWorkObj, (object)custPrtPprWork, out counter, 0, ConstantManagement.LogicalMode.GetData1 );
            }
            custPrtPprBlDspRsltWorkObj = null; // ADD 2015/02/05 ������ // �������̉��
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 ADD
            if ( _extractCancelFlag == true ) return 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 ADD
            // ��������readMode�͌��ݎg�p���Ă��Ȃ��̂łǂ�Ȓl�����Ă����Ȃ�

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 DEL
            //// Status������l�������ꍇ�̂݃f�[�^�Z�b�g�ɖ߂�f�[�^���Z�b�g
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
            if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                //// �ꌏ�ȏ�̖߂肪�������ꍇ�̂�
                //if ( counter > 0 )
                //{
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL

                DataRow row;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                //DataRow row2;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                DataRow row3;
                // �`�[�P�ʂ́A�u�`�[�ԍ��v�y�сu�󒍃X�e�[�^�X�v������̂��̂��ЂƂ̂�����Ƃ��Ĕ��肷��
                string exSlipNum = string.Empty;    // �ЂƂO�̓`�[�ԍ�
                // 2010/07/08 Add >>>
                string exSlipNum2 = string.Empty;    // �ЂƂO�̓`�[�ԍ�
                // 2010/07/08 Add <<<
                int exAcptAnOdrStatus = 0;          // �ЂƂO�̎󒍃X�e�[�^�X

                // �c���\���Ŏg�p����W�v�l
                int slipCount = 0;              // �`�[����
                double detailSlipCount = 0;       // ���א�
                double totalAmount = 0;           // ����
                double totalConsumeTaxAmount = 0; // �����

                // �����͈͓��ŏW�v����l
                long totalThisSalesPrice = 0;   // ���񔄏�
                long totalOfsThisSalesTax = 0;  // ����Łi���j
                long totalThisTimeDmdNrml = 0;  // �������

                double StandardPrice_Total = 0;   // �W�����i���v
                //double StandardPrice_Avg = 0;     // �W�����i����
                double SoldAmount_Total = 0;      // ������z���v
                //double SoldAmount_Avg = 0;        // ������z����
                double Cost_Total = 0;            // �������v
                //double Cost_Avg = 0;              // ��������
                double GrossProfitAmount_Total = 0;   // �e���z���v
                //double GrossProfitAmount_Avg = 0;     // �e���z����

                // --- DEL 2020/12/21 �x���Ή� ---------->>>>>
                //long AfCalDemandPrice = 0;            // �O��c��
                //// --- DEL 2020/12/21 �x���Ή� ----------<<<<<
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                long salAmntConsTaxInclu = 0; // �`�[�ʓ��ŋ��z�W�v�l
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

                int rowNo = 1;
                int rowDetailNo = 0;        //ADD 2009/02/14 �s��Ή�[11391]

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                # region // DEL
                ////-------------------
                //// �c���\��
                ////-------------------

                //// �c���\�����ꌏ�œ���ł��Ȃ������ꍇ�͕\�����Ȃ�
                //// ���Ӑ悪���݂��Ȃ��ꍇ���\�����Ȃ�
                //ArrayList al = (ArrayList)custPrtPprBlDspRsltWorkObj;
                //if ( al.Count == 1 || !_customerPointed )
                //{
                //    foreach ( CustPrtPprBlDspRsltWork remainData in (ArrayList)custPrtPprBlDspRsltWorkObj )
                //    {
                //        row3 = this._dataSet.BalanceTotal.NewRow();
                //        row3[_dataSet.BalanceTotal.AcpOdrTtl2TmBfBlDmdColumn.ColumnName] = remainData.AcpOdrTtl2TmBfBlDmd;  // �O�X�X��c��
                //        row3[_dataSet.BalanceTotal.LastTimeDemandColumn.ColumnName] = remainData.LastTimeDemand;            // �O�X��c��
                //        row3[_dataSet.BalanceTotal.AfCalDemandPriceColumn.ColumnName] = remainData.AfCalDemandPrice;        // �O��c��
                //        AfCalDemandPrice = remainData.AfCalDemandPrice;
                //        row3[_dataSet.BalanceTotal.AddUpYearMonthColumn.ColumnName] = remainData.AddUpYearMonth;            // �����N��
                //        row3[_dataSet.BalanceTotal.ConsTaxLayMethodColumn.ColumnName] = remainData.ConsTaxLayMethod;        // ����œ]�ŕ���
                //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 ADD
                //        // �������z
                //        row3[_dataSet.BalanceTotal.AfCalBlcColumn.ColumnName] = remainDataExtra.AfCalBlc;
                //        // ���񔄏�
                //        row3[_dataSet.BalanceTotal.ThisSalesPriceTotalColumn.ColumnName] = remainDataExtra.OfsThisTimeSales;
                //        // �����
                //        row3[_dataSet.BalanceTotal.OfsThisSalesTaxColumn.ColumnName] = remainDataExtra.OfsThisSalesTax;
                //        // �������
                //        row3[_dataSet.BalanceTotal.ThisTimeDmdNrmlColumn.ColumnName] = remainDataExtra.ThisTimeDmdNrml;
                //        // ���J�n��
                //        row3[_dataSet.BalanceTotal.DmdStDayColumn.ColumnName] = remainDataExtra.DmdStDay;
                //        // ��������
                //        row3[_dataSet.BalanceTotal.TotalDayColumn.ColumnName] = remainDataExtra.TotalDay;
                //        // �e�t���O
                //        row3[_dataSet.BalanceTotal.IsParentColumn.ColumnName] = remainDataExtra.IsParent;
                //        // �f�[�^���݃t���O
                //        row3[_dataSet.BalanceTotal.ExistsTotalColumn.ColumnName] = true;
                //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 ADD

                //        this._dataSet.BalanceTotal.Rows.Add( row3 );
                //    }
                //}
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL

                // �`�[�ԍ�
                //string salesSlipNumExt = string.Empty;  // DEL huangt 2013/05/15 Redmine#35640 

                // --- DEL 2020/12/21 �x���Ή� ---------->>>>>
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 ADD
                //bool cancelFlag = false;
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 ADD
                // --- DEL 2020/12/21 �x���Ή� ----------<<<<<

				// ------------DEL wangf 2013/01/30 FOR Redmine#34513--------->>>>
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 ADD
				//// ����������W�v�����[�g���g�p
				////   (���Ӑ�d�q���������[�g���Ԃ�custPrtPprBlDspRsltWorkObj�͎g�p���Ȃ�)
				//RemainDataExtra remainDataExtra = new RemainDataExtra();
                
				//// --- UPD m.suzuki 2010/07/21 ---------->>>>>
				////SearchBlDspRslt( ref custPrtPprBlDspRsltWorkObj, ref remainDataExtra, custPrtPpr );
				//int blDspRsltStatus = SearchBlDspRslt( ref custPrtPprBlDspRsltWorkObj, ref remainDataExtra, custPrtPpr );
				//if ( blDspRsltStatus == (int)ConstantManagement.DB_Status.ctDB_ERROR )
				//{
				//    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
				//}
				//// --- UPD m.suzuki 2010/07/21 ----------<<<<<
				////-------------------
				//// �c���\��
				////-------------------
				//# region [�c���\��]
				//// �c���\�����ꌏ�œ���ł��Ȃ������ꍇ�͕\�����Ȃ�
				//// ���Ӑ悪���݂��Ȃ��ꍇ���\�����Ȃ�
				//ArrayList al = (ArrayList)custPrtPprBlDspRsltWorkObj;
				//if ( al.Count == 1 || !_customerPointed )
				//{
				//    foreach ( CustPrtPprBlDspRsltWork remainData in (ArrayList)custPrtPprBlDspRsltWorkObj )
				//    {
				//        row3 = this._dataSet.BalanceTotal.NewRow();
				//        row3[_dataSet.BalanceTotal.AcpOdrTtl2TmBfBlDmdColumn.ColumnName] = remainData.AcpOdrTtl2TmBfBlDmd;  // �O�X�X��c��
				//        row3[_dataSet.BalanceTotal.LastTimeDemandColumn.ColumnName] = remainData.LastTimeDemand;            // �O�X��c��
				//        row3[_dataSet.BalanceTotal.AfCalDemandPriceColumn.ColumnName] = remainData.AfCalDemandPrice;        // �O��c��
				//        AfCalDemandPrice = remainData.AfCalDemandPrice;
				//        row3[_dataSet.BalanceTotal.AddUpYearMonthColumn.ColumnName] = remainData.AddUpYearMonth;            // �����N��
				//        row3[_dataSet.BalanceTotal.ConsTaxLayMethodColumn.ColumnName] = remainData.ConsTaxLayMethod;        // ����œ]�ŕ���
				//        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 ADD
				//        // �������z
				//        row3[_dataSet.BalanceTotal.AfCalBlcColumn.ColumnName] = remainDataExtra.AfCalBlc;
				//        // ���񔄏�
				//        row3[_dataSet.BalanceTotal.ThisSalesPriceTotalColumn.ColumnName] = remainDataExtra.OfsThisTimeSales;
				//        // �����
				//        row3[_dataSet.BalanceTotal.OfsThisSalesTaxColumn.ColumnName] = remainDataExtra.OfsThisSalesTax;
				//        // �������
				//        row3[_dataSet.BalanceTotal.ThisTimeDmdNrmlColumn.ColumnName] = remainDataExtra.ThisTimeDmdNrml;
				//        // ���J�n��
				//        row3[_dataSet.BalanceTotal.DmdStDayColumn.ColumnName] = remainDataExtra.DmdStDay;
				//        // ��������
				//        row3[_dataSet.BalanceTotal.TotalDayColumn.ColumnName] = remainDataExtra.TotalDay;
				//        // �e�t���O
				//        row3[_dataSet.BalanceTotal.IsParentColumn.ColumnName] = remainDataExtra.IsParent;
				//        // �f�[�^���݃t���O
				//        row3[_dataSet.BalanceTotal.ExistsTotalColumn.ColumnName] = true;
				//        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 ADD

				//        this._dataSet.BalanceTotal.Rows.Add( row3 );
				//    }
				//}
				//# endregion

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 ADD
				// ------------DEL wangf 2013/01/30 FOR Redmine#34513---------<<<<

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                // �ꌏ�ȏ�̖߂肪�������ꍇ�̂�
                if ( counter > 0 )
                {
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 UPD
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                    ////foreach (CustPrtPprSalTblRsltWork data in (ArrayList)custPrtPprSalTblRsltWorkObj)
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                    //for ( int index = 0; index < (custPrtPprSalTblRsltWorkObj as ArrayList).Count; index++ )
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                    //for ( int index = 0; index < (custPrtPprSalTblRsltWorkObj as ArrayList).Count; index++ )

                    int lastIndex = 0;

                    int maxCount = (custPrtPprSalTblRsltWorkObj as ArrayList).Count;
                    if ( maxCount > custPrtPpr.SearchCnt - 1 )
                    {
                        // �����[�g����͍ő��20,001���Ԃ��Ă���̂ŁA20,000���܂łɂ���
                        maxCount = (int)custPrtPpr.SearchCnt - 1;
                    }
                    //-----ADD 2010/12/20 ----->>>>>
                    int beAcptAnOdrStatusSrc = 0;
                    string beHisDtlSlipNum = string.Empty;
                    //-----ADD 2010/12/20 -----<<<<<
                    //-----ADD 2011/07/28 ------>>>>>
                    AllDefSetAcs alldefsetacs = new AllDefSetAcs();
                    ArrayList outList = new ArrayList();
                    int yeardiv=0;
                    // ----- UPD 2011/09/21 -------------------------------------------------------->>>>>
                    //int stat = alldefsetacs.SearchAll(out outList, LoginInfoAcquisition.EnterpriseCode);
                    int stat = alldefsetacs.Search(out outList, LoginInfoAcquisition.EnterpriseCode);
                    // ----- UPD 2011/09/21 --------------------------------------------------------<<<<<
                    if (stat == 0)
                    {
                        foreach (AllDefSet alldefset in outList)
                        {
                            string sectionCodeE = alldefset.SectionCode.Trim();
                            // ----- UPD 2011/09/21 -------------------------------->>>>>
                            //if (sectionCodeE.Equals(custPrtPpr.SectionCode[0]))
                            //{
                            //    yeardiv = alldefset.EraNameDispCd1;
                            //}
                            if (sectionCodeE.Equals(LoginInfoAcquisition.Employee.BelongSectionCode.Trim()))
                            {
                                yeardiv = alldefset.EraNameDispCd1;
                            }
                            else if (sectionCodeE.Equals("00"))
                            {
                                yeardiv = alldefset.EraNameDispCd1;
                            }
                            // ----- UPD 2011/09/21 --------------------------------<<<<<
                        }
                    }
                    // ---- ADD K2015/04/27 �� �����Z���i�̑�񔄉��ǉ� ---->>>>>
                    // ������z�����ݒ�
                    if (_salesProcMoneyAcs == null)
                    {
                        this.InitSalesProcMoney();
                    }
                    // ---- ADD K2015/04/27 �� �����Z���i�̑�񔄉��ǉ� ----<<<<<

                    //-----ADD 2011/07/28 ------<<<<<
                    for ( int index = 0; index < maxCount; index++ )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 UPD
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 ADD
                        lastIndex = index;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 ADD

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        CustPrtPprSalTblRsltWork data = (CustPrtPprSalTblRsltWork)((custPrtPprSalTblRsltWorkObj as ArrayList)[index]);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                        // �`�[�ԍ��t�H�[�}�b�g�Ή�
                        data.SalesSlipNum = GetSlipNum( data );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                        // �f�[�^�Z�b�g�ɕԂ�l���Z�b�g����
                        try
                        {
                            #region ���׃f�[�^�e�[�u��

                            row = this._dataSet.SalesDetail.NewRow();

                            if ( data.DataDiv == 0 ) // ����f�[�^�̏ꍇ
                            {
                                #region ���ׁE����f�[�^
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                                // �ԕi�E�l������̂��߂̐��ʁE���z�̕���(1or-1)
                                // �i�ԕi�̒l������-1*-1��1�j
                                // ���ԕi�E�l�����̓f�[�^�㐔�ʃ}�C�i�X�Ȃ̂ŁAdetailSign�������ăv���X�ɂ���
                                // �@�P����Abs���Ƃ�킯�ł͂Ȃ��̂Œ��ӁB
                                int detailSign = 1;

                                // �ԕi����
                                if ( data.SalesSlipCd == 1 ) detailSign *= -1;

                                // ���i�l������(�s�l���͏��O)
                                if ( data.SalesSlipCdDtl == 2 && !string.IsNullOrEmpty( data.GoodsNo ) ) detailSign *= -1;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD

                                // --- UPD 2009/11/25 ---------->>>>>
                                // �ԓ`�E�����̓`�F�b�N�ł��Ȃ�
                                // �ߋ���(���㗚������̎擾��)�̓`�F�b�N�s��
                                //if ( data.DebitNoteDiv == 1 || data.DebitNoteDiv == 2 )
                                //{
                                //    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                //}
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
                                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                                //else if ( data.HistoryDiv != 0 )
                                //{
                                //    // �ߋ���(���㗚������̎擾��)�̓`�F�b�N�s��
                                //    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                //}
                                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                                // ----------DEL 2009/12/15------------>>>>>
                                //// �ߋ���(���㗚������̎擾��)�̓`�F�b�N�s��
                                //if (data.HistoryDiv != 0)
                                //{
                                //    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                //}
                                // ----------DEL 2009/12/15------------<<<<<
                                //else if (data.HistoryDiv == 0 && data.AcptAnOdrRemainCnt <= 0)
                                //{
                                //    // �ʏ�F�󒍎c�����c���Ă��Ȃ����ׂ͐ԓ`�s��
                                //    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
                                // ----------UPD 2009/12/15------------>>>>>
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = false;
                                //}
                                row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = false;
                                // ----------UPD 2009/12/15------------<<<<<
                                // --- UPD 2009/11/25 ----------<<<<<
                                row[_dataSet.SalesDetail.DataDivColumn.ColumnName] = data.DataDiv;
                                row[_dataSet.SalesDetail.RowNoColumn.ColumnName] = rowNo;
                                //row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.SalesDate);
                                row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = data.SalesDate;
                                row[_dataSet.SalesDetail.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;//.PadLeft(8, '0');
                                row[_dataSet.SalesDetail.SalesRowNoColumn.ColumnName] = data.SalesRowNo;
                                row[_dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                                row[_dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                                row[_dataSet.SalesDetail.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
                                //// sakurai Add 2009/02/03 >>>>>>>>>>>>>>>>>>>>>>>>>
                                //row[_dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName] = data.AcptAnOdrRemainCnt;
                                //// sakurai Add 2009/02/03 <<<<<<<<<<<<<<<<<<<<<<<<<

                                // --- ADD 2010/01/29 ---------->>>>>
                                row[this._dataSet.SalesDetail.RetuppercntColumn.ColumnName] = data.Retuppercnt;
                                row[this._dataSet.SalesDetail.RetuppercntDivColumn.ColumnName] = data.RetuppercntDiv;
                                // --- ADD 2010/01/29 ----------<<<<<

                                if ( data.HistoryDiv == 0 )
                                {
                                    // �����ȊO
                                    row[_dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName] = data.AcptAnOdrRemainCnt;
                                }
                                else
                                {
                                    // ����
                                    // �i�����I�ɂ͏o�א��Ɠ��������鎖�Őԓ`���s�\�ɂ���{�o�א��܂ł͐ԓ`�\�ɂ���j
                                    row[_dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName] = data.ShipmentCnt;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
                                // �`�[�敪������
                                if ( data.SalesSlipCd == 0 )
                                {
                                    if ( data.AcptAnOdrStatus == 20 )
                                    {
                                        row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "��";
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                        // row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value; // DEL 2009/11/25
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                    }
                                    else if ( data.AcptAnOdrStatus == 30 )
                                    {
                                        row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "����";
                                    }
                                    else if ( data.AcptAnOdrStatus == 40 )
                                    {
                                        row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "�ݏo";
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                        // row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;// DEL 2009/11/25
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                    }
                                    else
                                    {
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                        // row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value; // DEL 2009/11/25
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                    }
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "�ԕi";
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                    // row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;// DEL 2009/11/25
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
                                //if (data.AcptAnOdrRemainCnt == 0 || data.AcptAnOdrRemainCnt == null)
                                //{
                                //    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                //}
                                //----------- DEL 2009/11/25 --------->>>>>
                                //if ( (data.AcptAnOdrRemainCnt == 0 || data.AcptAnOdrRemainCnt == null) && data.HistoryDiv == 0 )
                                //{
                                //    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                //}
                                //----------- DEL 2009/11/25 ---------<<<<<
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
                                row[_dataSet.SalesDetail.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                                row[_dataSet.SalesDetail.GoodsNameColumn.ColumnName] = data.GoodsName;
                                row[_dataSet.SalesDetail.GoodsNoColumn.ColumnName] = data.GoodsNo;
                                row[_dataSet.SalesDetail.ChangeGoodsNoColumn.ColumnName] = data.ChangeGoodsNo; //ADD �i�N 2014/12/28 �ϊ���i�Ԃ̒ǉ��Ή�
                                if ( data.BLGoodsCode == 0 )
                                {
                                    row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = data.BLGoodsCode.ToString().PadLeft( CT_DEPTH_BLGOODSCODE, '0' );
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                                //row[_dataSet.SalesDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode.ToString().PadLeft(CT_DEPTH_BLGROUPCODE, '0');
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                row[_dataSet.SalesDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 DEL
                                //row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] = data.ShipmentCnt;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                                row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] = detailSign * data.ShipmentCnt;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD

                                //-----UPD 2010/12/20 ----->>>>>
                                //if ( data.OpenPriceDiv == 0 )
                                //{
                                //    row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = data.ListPriceTaxExcFl.ToString( "#,###" );
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = "����݉��i";
                                //}
                                //row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = data.ListPriceTaxExcFl.ToString("#,###");
                                //-----UPD 2011/07/13 ----->>>>>
                                row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = data.ListPriceTaxExcFl;
                                row[_dataSet.SalesDetail.CostRateColumn.ColumnName] = data.CostRate;     //������ ADD �A��729 2011/08/18
                                row[_dataSet.SalesDetail.SalesRateColumn.ColumnName] = data.SalesRate;   //������ ADD �A��729 2011/08/18
                                //-----UPD 2011/07/13 ----->>>>>
                                //-----UPD 2010/12/20 -----<<<<<

                                row[_dataSet.SalesDetail.OpenPriceDivColumn.ColumnName] = data.OpenPriceDiv;
                                row[_dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName] = data.SalesUnPrcTaxExcFl;
                                row[_dataSet.SalesDetail.SalesUnitCostColumn.ColumnName] = data.SalesUnitCost;
                                // -------------ADD 2009/12/28-------------->>>>>
                                row[_dataSet.SalesDetail.BfSalesUnitPriceColumn.ColumnName] = data.BfSalesUnitPrice;//�ύX�O�P��
                                row[_dataSet.SalesDetail.BfUnitCostColumn.ColumnName] = data.BfUnitCost;//�ύX�O����
                                // -------------ADD 2009/12/28--------------<<<<<
                                row[_dataSet.SalesDetail.BfListPriceColumn.ColumnName] = data.BfListPrice;//�ύX�O�艿// ADD 2010/08/05
                                // -------------ADD 2011/07/18 ���R-------------->>>>>
                                // 0:�ʏ�(PCC�A�g�Ȃ�)�A1:�蓮�񓚁A2:������
                                if (data.AutoAnswerDivSCM == 0)
                                {
                                    row[_dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName] = "�ʏ�";
                                }
                                else if (data.AutoAnswerDivSCM == 1)
                                {
                                    row[_dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName] = "�蓮��";
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName] = "������";
                                }
                                // -------------ADD 2011/07/18 ���R--------------<<<<<

                                //---ADD START 2011/11/28 �k�m ----------------------------------->>>>>
                                if (data.InquiryNumber == 0)
                                {
                                    row[_dataSet.SalesDetail.InquiryNumberColumn.ColumnName] = string.Empty; //�⍇���ԍ�
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.InquiryNumberColumn.ColumnName] = data.InquiryNumber.ToString().PadLeft(CT_DEPTH_INQUIRYNUMBER, '0'); //�⍇���ԍ�
                                }
                                //---ADD END 2011/11/28 �k�m -----------------------------------<<<<<
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/11 DEL
                                //row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName] = data.SalesMoneyTaxExc;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/11 DEL
                                row[_dataSet.SalesDetail.ConsTaxLayMethodColumn.ColumnName] = data.ConsTaxLayMethod;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/11 DEL
                                //row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = data.SalesTotalTaxInc;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/11 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/11 DEL
                                //if (data.ConsTaxLayMethod == 0) // �`�[�P��
                                //{
                                //    if (!data.SalesSlipNum.Equals(salesSlipNumExt)) // ��s�ڂ̂ݕ\��
                                //    {
                                //        // ����`�[���v(�ō�)(SalesTotalTaxInc) - ����`�[���v(�Ŕ���)()
                                //        row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                                //    }
                                //}
                                //else if (data.ConsTaxLayMethod == 1) // ���גP��
                                //{
                                //    // ������z����Ŋz
                                //    row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = data.SalesPriceConsTax;
                                //}
                                //else // �����e(2)�E�����q(3)�E��ې�(9)�͋�
                                //{
                                //    row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/11 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/11 ADD

                                # region [����Ŋ֘A]
                                bool printTax = true;
                                Int64 salesTotalTaxInc;
                                Int64 salesTotalTaxExc = data.SalesMoneyTaxExc;
                                Int64 salesPriceConsTax;

                                // ����������Ŋz�̎擾
                                if ( data.ConsTaxLayMethod == 0 ) // �`�[�P��
                                {
                                    //if ( !data.SalesSlipNum.Equals( salesSlipNumExt ) ) // ��s�ڂ̂ݕ\��     // DEL huangt 2013/05/15 Redmine#35640
                                    if (data.SalesRowNo == 1)  // �`�[���̖��א擪�s�ɏ���ł��󎚂����    �@�@// ADD huangt 2013/05/15 Redmine#35640 
                                    {
                                        salesPriceConsTax = data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                                    }
                                    else
                                    {
                                        salesPriceConsTax = 0;
                                        printTax = false;
                                    }
                                }
                                else if ( data.ConsTaxLayMethod == 1 ) // ���גP��
                                {
                                    salesPriceConsTax = data.SalesPriceConsTax;
                                }
                                else
                                {
                                    salesPriceConsTax = 0;
                                }

                                // �ō����z�̎擾
                                salesTotalTaxInc = salesTotalTaxExc + salesPriceConsTax;

                                if ( printTax )
                                {
                                    // ����ň󎚗L������Ƌ��z����
                                    int totalAmountDispWayCd = data.TotalAmountDispWayCd;
                                    int taxationDivCd = data.TaxationDivCd;

                                    // ����ň󎚗L������
                                    printTax = ReflectMoneyForTaxPrint( ref salesTotalTaxExc, ref salesPriceConsTax, ref salesTotalTaxInc, totalAmountDispWayCd, data.ConsTaxLayMethod, taxationDivCd );
                                    if ( printTax )
                                    {
                                        if ( salesPriceConsTax != 0 )
                                        {
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 DEL
                                            //row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = salesPriceConsTax;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 DEL
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                                            row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = detailSign * salesPriceConsTax;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD
                                            row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = data.ConsTaxRate; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                                        }
                                        else
                                        {
                                            // �󎚂��Ȃ�
                                            row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                            row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                                        }
                                    }
                                    else
                                    {
                                        // �󎚂��Ȃ�
                                        row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                        row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                                    }
                                }
                                else
                                {
                                    // �󎚂��Ȃ�
                                    row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 DEL
                                //// �Ŕ����z�Z�b�g
                                //row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName] = salesTotalTaxExc;
                                //// �ō����z�Z�b�g
                                //row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = salesTotalTaxInc;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                                // �Ŕ����z�Z�b�g
                                row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName] = detailSign * salesTotalTaxExc;
                                // �ō����z�Z�b�g
                                row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = detailSign * salesTotalTaxInc;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD
                                # endregion

                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/11 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 DEL
                                //row[_dataSet.SalesDetail.TotalCostColumn.ColumnName] = data.TotalCost;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                                row[_dataSet.SalesDetail.TotalCostColumn.ColumnName] = detailSign * data.TotalCost;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                                //// �ޕʔԍ�[0�̂Ƃ��͋�]
                                //if (data.CategoryNo == 0)
                                //{
                                //    row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = data.CategoryNo;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                // �ޕʌ^��
                                row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = GetModelDesignationNoAndCategoryNo( data );
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
                                // �^���w��ԍ�(���l)
                                row[_dataSet.SalesDetail.ModelDesignationNoOrgColumn.ColumnName] = data.ModelDesignationNo;
                                // �ޕʔԍ�(���l)
                                row[_dataSet.SalesDetail.CategoryNoOrgColumn.ColumnName] = data.CategoryNo;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD
                                row[_dataSet.SalesDetail.ModelFullNameColumn.ColumnName] = data.ModelFullName;
                                // --- ADD m.suzuki 2010/04/02 ---------->>>>>
                                // �Ԏ햼�J�i
                                row[_dataSet.SalesDetail.ModelHalfNameColumn.ColumnName] = data.ModelHalfName;
                                // --- ADD m.suzuki 2010/04/02 ----------<<<<<
                                //row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.FirstEntryDate);
                                // -----------UPD 2010/01/12----------->>>>>
                                // �N��[NULL�̂Ƃ��͋�]
                                //if (data.FirstEntryDate == DateTime.MinValue)//DBNull.Value)// 
                                if ( data.FirstEntryDate == 0 )
                                {
                                    row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    //row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = data.FirstEntryDate;
                                    //----UPD 2010/12/20----->>>>>
                                    string firstEntryDate = "";

                                    if (data.FirstEntryDate.ToString().Length < 6)
                                    {
                                        firstEntryDate = "0000" + "/" + data.FirstEntryDate.ToString("D2");
                                    }
                                    else
                                    {
                                        firstEntryDate = data.FirstEntryDate.ToString().Substring( 0, 4 ) + "/" + data.FirstEntryDate.ToString().Substring( 4, 2 );
                                    }
                                    firstEntryDate = firstEntryDate.Replace(@"/00", "");// ADD 2013/05/06 zhujw #34718
                                    //string firstEntryDate = data.FirstEntryDate.ToString().Substring( 0, 4 ) + "/" + data.FirstEntryDate.ToString().Substring( 4, 2 );
                                    //----UPD 2010/12/20-----<<<<<

                                    //row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = firstEntryDate;// DEL 2011/07/28
                                    //-----ADD 2011/07/28 ------>>>>>

                                    if (yeardiv ==1)
                                    {
                                        // --- UPD 2012/06/26 ��880 ---------->>>>>
                                        //string date = data.FirstEntryDate.ToString() + "01";
                                        //int StartTotalUnitYm = Convert.ToInt32(date);
                                        //string stTarget = TDateTime.LongDateToString("GGyymm", StartTotalUnitYm);
                                        string date, stTarget;
                                        int StartTotalUnitYm;
                                        if (data.FirstEntryDate.ToString().Substring(4, 2) == "00")
                                        {
                                            date = data.FirstEntryDate.ToString().Substring(0, 4) + "0101";
                                            StartTotalUnitYm = Convert.ToInt32(date);
                                            //stTarget = TDateTime.LongDateToString("GGyy", StartTotalUnitYm) + "00��"; // DEL 2013/05/06 zhujw #Redmine34718
                                            stTarget = TDateTime.LongDateToString("GGyy", StartTotalUnitYm);// ADD 2013/05/06 zhujw #Redmine34718
                                        }
                                        else
                                        {
                                            date = data.FirstEntryDate.ToString() + "01";
                                            StartTotalUnitYm = Convert.ToInt32(date);
                                            stTarget = TDateTime.LongDateToString("GGyymm", StartTotalUnitYm);
                                        }
                                        // --- UPD 2012/06/26 ��880 ----------<<<<<

                                        row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = stTarget;
                                        }
                                        else 
                                        {
                                          row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = firstEntryDate;
                                        }
                                    
                                    //-----ADD 2011/07/28 ------<<<<<

                                    }
                                    // -----------UPD 2010/01/12-----------<<<<<
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 DEL
                                    //// �ԑ�No[NULL�̂Ƃ��͋�]
                                    //if ( data.SearchFrameNo == 0 )
                                    //{
                                    //    row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = DBNull.Value;
                                    //}
                                    //else
                                    //{
                                    //    row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = data.SearchFrameNo;
                                    //}
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                                    row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = data.FrameNo;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD

                                row[_dataSet.SalesDetail.FullModelColumn.ColumnName] = data.FullModel;
                                row[_dataSet.SalesDetail.SlipNoteColumn.ColumnName] = data.SlipNote;
                                row[_dataSet.SalesDetail.SlipNote2Column.ColumnName] = data.SlipNote2;
                                row[_dataSet.SalesDetail.SlipNote3Column.ColumnName] = data.SlipNote3;
                                row[_dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                                row[_dataSet.SalesDetail.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 DEL
                                //row[_dataSet.SalesDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode.ToString().PadLeft(CT_DEPTH_CUSTOMERCODE, '0');
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD
                                row[_dataSet.SalesDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD
                                row[_dataSet.SalesDetail.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 DEL
                                //// �d����R�[�h[NULL�̂Ƃ��͋�]
                                //if (data.SupplierCd == 0)
                                //{
                                //    row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = string.Empty; //DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = data.SupplierCd.ToString().PadLeft(CT_DEPTH_SUPPLIERCODE, '0');
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD
                                row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = data.SupplierCd;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD
                                row[_dataSet.SalesDetail.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                                row[_dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName] = data.PartySaleSlipNum;
                                row[_dataSet.SalesDetail.CarMngCodeColumn.ColumnName] = data.CarMngCode;
                                // �v�㌳��No[NULL�̂Ƃ��͋�]

                                // ----- UPD 2010/12/20 ----->>>>>
                                //if (data.AcceptAnOrderNo == 0)
                                //{
                                //    row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = data.AcceptAnOrderNo;
                                //}
                                if (data.AcptAnOdrStatusSrc == 20)
                                {
                                    if (!string.IsNullOrEmpty(data.HisDtlSlipNum.ToString()))
                                    {
                                        row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = data.HisDtlSlipNum;
                                    }
                                }
                                else
                                {
                                    //if (data.AcceptAnOrderNo == 0)
                                    //{
                                        row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                                    //}
                                    //else
                                    //{
                                    //    row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = data.AcceptAnOrderNo;
                                    //}
                                }
                                
                                // �v�㌳�o��No[NULL�̂Ƃ��͋�]
                                //if (data.ShipmSalesSlipNum == "0")
                                //{
                                //    row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = string.Empty;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = data.ShipmSalesSlipNum;
                                //}
                                if (data.AcptAnOdrStatusSrc == 40)
                                {
                                    row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = data.HisDtlSlipNum;
                                }
                                else
                                {
                                    //if (data.ShipmSalesSlipNum == "0")
                                    //{
                                        row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = string.Empty;
                                    //}
                                    //else
                                    //{
                                    //    row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = data.ShipmSalesSlipNum;
                                    //}
                                }
                                // ----- UPD 2010/12/20 -----<<<<<

                                // ����No[NULL�̂Ƃ��͋�]
                                if ( data.SrcSalesSlipNum == "0" )
                                {
                                    row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = string.Empty; //DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = data.SrcSalesSlipNum;
                                }
                                row[_dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName] = data.SalesOrderDivCd;
                                if ( data.SalesOrderDivCd == 0 )
                                {
                                    row[_dataSet.SalesDetail.SalesOrderDivCdNameColumn.ColumnName] = "���";
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.SalesOrderDivCdNameColumn.ColumnName] = "�݌�";
                                }
                                row[_dataSet.SalesDetail.WarehouseCdColumn.ColumnName] = data.WarehouseCode;
                                row[_dataSet.SalesDetail.WarehouseNameColumn.ColumnName] = data.WarehouseName;
                                // �����d��No[NULL�̂Ƃ��͋�]
                                if ( data.SupplierSlipNo == 0 )
                                {
                                    row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                row[_dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName] = data.StockPartySaleSlipNum;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                // ������R�[�h[NULL�̂Ƃ��͋�]
                                if ( data.UOESupplierCd == 0 )
                                {
                                    row[_dataSet.SalesDetail.UOESupplierCdColumn] = string.Empty; //DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.UOESupplierCdColumn] = data.UOESupplierCd.ToString().PadLeft( CT_DEPTH_UOESUPPLIERCODE, '0' );
                                }
                                row[_dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName] = data.UOESupplierSnm;
                                row[_dataSet.SalesDetail.UOERemark1Column.ColumnName] = data.UoeRemark1;
                                row[_dataSet.SalesDetail.UOERemark2Column.ColumnName] = data.UoeRemark2;
                                row[_dataSet.SalesDetail.GuideNameColumn.ColumnName] = data.GuideName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //row[_dataSet.SalesDetail.SectionCdColumn.ColumnName] = data.SectionCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.SectionGuideNameColumn.ColumnName] = data.SectionGuideNm;
                                row[_dataSet.SalesDetail.DtlNoteColumn.ColumnName] = data.DtlNote;
                                row[_dataSet.SalesDetail.ColorName1Column.ColumnName] = data.ColorName1;
                                row[_dataSet.SalesDetail.TrimNameColumn.ColumnName] = data.TrimName;
                                //----- UPD 2010/09/16---------->>>>>
                                //row[_dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName] = data.StdUnPrcLPrice;
                                //row[_dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName] = data.StdUnPrcSalUnPrc;
                                //row[_dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName] = data.StdUnPrcUnCst;
                                row[_dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName] = data.BfListPrice; // �ύX�O�艿
                                row[_dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName] = data.BfSalesUnitPrice;// �ύX�O����
                                row[_dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName] = data.BfUnitCost;// �ύX�O����
                                //----- UPD 2010/09/16----------<<<<<
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 DEL
                                //// ���[�J�[�R�[�h[NULL�̂Ƃ��͋�]
                                //if (data.GoodsMakerCd == 0)
                                //{
                                //    row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = string.Empty; //DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = data.GoodsMakerCd.ToString().PadLeft(CT_DEPTH_GOODSMAKERCODE, '0');
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD
                                // ���[�J�[�R�[�h
                                row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = data.GoodsMakerCd;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD
                                row[_dataSet.SalesDetail.MakerNameColumn.ColumnName] = data.MakerName;
                                row[_dataSet.SalesDetail.CostColumn.ColumnName] = data.Cost;
                                // ���Ӑ�`�[�ԍ�[NULL�̂Ƃ��͋�]
                                if ( data.CustSlipNo == 0 )
                                {
                                    row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = data.CustSlipNo;
                                }
                                //row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.AddUpADate);
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                                //row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                if ( data.AddUpADate != DateTime.MinValue )
                                {
                                    row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = DBNull.Value;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                row[_dataSet.SalesDetail.AccRecDivCdColumn.ColumnName] = data.AccRecDivCd;
                                if ( data.AccRecDivCd == 1 )
                                {
                                    row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = "���|";
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                else
                                {
                                    row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = "����";
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                //row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = data.DebitNoteDiv;
                                if ( data.DebitNoteDiv == 0 )
                                {
                                    row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "���`";
                                }
                                else if ( data.DebitNoteDiv == 1 )
                                {
                                    row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "�ԓ`";
                                }
                                else if ( data.DebitNoteDiv == 2 )
                                {
                                    row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "����";
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 DEL
                                //if ( (long)row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] < 0 )
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                                if ( ((long)row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] < 0 ||
                                     (double)row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] < 0)
                                    && data.SalesSlipCdDtl != 2 )
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD
                                {
                                    row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "�ԓ`";
                                    // row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value; // DEL 2009/11/25
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 DEL
                                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/03 ADD
                                //// �e��(����)
                                //row[_dataSet.SalesDetail.GrossProfitDetailColumn.ColumnName] = this.GetGrossProfitDetail( data );
                                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/03 ADD
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                                // �e��(����)
                                row[_dataSet.SalesDetail.GrossProfitDetailColumn.ColumnName] = detailSign * this.GetGrossProfitDetail( data );
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD

                                //�e����
                                row[_dataSet.SalesDetail.GrossProfitMarginColumn.ColumnName] = detailSign * this.GetGrossProfitMargin(data);  //#7861 2011/11/23 ADD

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                                // �[����R�[�h
                                row[_dataSet.SalesDetail.AddresseeCodeColumn.ColumnName] = data.AddresseeCode;
                                // �[���於1+2
                                row[_dataSet.SalesDetail.AddresseeNameColumn.ColumnName] = data.AddresseeName + data.AddresseeName2;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
                                // �[���於1�̂�
                                row[_dataSet.SalesDetail.AddresseeName1Column.ColumnName] = data.AddresseeName;
                                // �[���於2�̂�
                                row[_dataSet.SalesDetail.AddresseeName2Column.ColumnName] = data.AddresseeName2;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
                                // ���͓�
                                if ( data.InputDay != DateTime.MinValue )
                                {
                                    row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = data.InputDay;
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = DBNull.Value;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                                // ���׋敪
                                row[_dataSet.SalesDetail.SalesSlipCdDtlColumn.ColumnName] = data.SalesSlipCdDtl;
                                switch ( data.SalesSlipCdDtl )
                                {
                                    default:
                                    case 0:
                                    case 1:
                                        {
                                            row[_dataSet.SalesDetail.SalesSlipCdDtlNameColumn.ColumnName] = "�ʏ�";
                                        }
                                        break;
                                    case 2:
                                        {
                                            if ( string.IsNullOrEmpty( data.GoodsNo ) )
                                            {
                                                row[_dataSet.SalesDetail.SalesSlipCdDtlNameColumn.ColumnName] = "�s�l��";
                                            }
                                            else
                                            {
                                                row[_dataSet.SalesDetail.SalesSlipCdDtlNameColumn.ColumnName] = "���i�l��";
                                            }
                                        }
                                        break;
                                }

                                // ���i�啪��
                                row[_dataSet.SalesDetail.GoodsLGroupColumn.ColumnName] = data.GoodsLGroup;
                                row[_dataSet.SalesDetail.GoodsLGroupNameColumn.ColumnName] = data.GoodsLGroupName;
                                // ���i������
                                row[_dataSet.SalesDetail.GoodsMGroupColumn.ColumnName] = data.GoodsMGroup;
                                row[_dataSet.SalesDetail.GoodsMGroupNameColumn.ColumnName] = data.GoodsMGroupName;
                                // ���i����
                                row[_dataSet.SalesDetail.GoodsKindCodeColumn.ColumnName] = data.GoodsKindCode;
                                switch ( data.GoodsKindCode )
                                {
                                    case 0:
                                        {
                                            row[_dataSet.SalesDetail.GoodsKindCodeNameColumn.ColumnName] = "����";
                                        }
                                        break;
                                    case 1:
                                    default:
                                        {
                                            row[_dataSet.SalesDetail.GoodsKindCodeNameColumn.ColumnName] = "���̑�";
                                        }
                                        break;
                                }
                                // �I��
                                row[_dataSet.SalesDetail.WarehouseShelfNoColumn.ColumnName] = data.WarehouseShelfNo;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD

                                // ���i�敪
                                row[_dataSet.SalesDetail.EnterpriseGanreCodeColumn.ColumnName] = data.EnterpriseGanreCode;

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
                                row[_dataSet.SalesDetail.CarMngNoColumn.ColumnName] = data.CarMngNo; // �ԗ��Ǘ�SEQ
                                row[_dataSet.SalesDetail.MakerCodeColumn.ColumnName] = data.MakerCode; // �Ԏ탁�[�J�[�R�[�h
                                row[_dataSet.SalesDetail.ModelCodeColumn.ColumnName] = data.ModelCode; // �Ԏ�R�[�h
                                row[_dataSet.SalesDetail.ModelSubCodeColumn.ColumnName] = data.ModelSubCode; // �Ԏ�T�u�R�[�h
                                row[_dataSet.SalesDetail.EngineModelNmColumn.ColumnName] = data.EngineModelNm; // �G���W���^������
                                row[_dataSet.SalesDetail.ColorCodeColumn.ColumnName] = data.ColorCode; // �J���[�R�[�h
                                row[_dataSet.SalesDetail.TrimCodeColumn.ColumnName] = data.TrimCode; // �g�����R�[�h
                                row[_dataSet.SalesDetail.DeliveredGoodsDivColumn.ColumnName] = data.DeliveredGoodsDiv; // �[�i�敪

                                int[] wkFullModelFixedNoAry = new int[data.FullModelFixedNoAry.Length];
                                for ( int i = 0; i < data.FullModelFixedNoAry.Length; i++ )
                                {
                                    wkFullModelFixedNoAry[i] = data.FullModelFixedNoAry[i];
                                }
                                row[_dataSet.SalesDetail.FullModelFixedNoAryColumn.ColumnName] = wkFullModelFixedNoAry; // �t���^���Œ�ԍ��z��

                                // --- ADD 2010/04/27 --------------->>>>>
                                string[] wkFreeSrchMdlFxdNoAry = new string[0];
                                if ( null != data.FreeSrchMdlFxdNoAry && 0 < data.FreeSrchMdlFxdNoAry.Length )
                                {
                                    BinaryFormatter formatter = new BinaryFormatter();
                                    MemoryStream ms = new MemoryStream( data.FreeSrchMdlFxdNoAry );
                                    wkFreeSrchMdlFxdNoAry = (string[])formatter.Deserialize( ms );
                                    ms.Close();
                                }
                                row[_dataSet.SalesDetail.FreeSrchMdlFxdNoAryColumn.ColumnName] = wkFreeSrchMdlFxdNoAry;
                                // --- ADD 2010/04/27 ---------------<<<<<

                                byte[] wkCategoryObjAry = new byte[data.CategoryObjAry.Length];
                                for ( int i = 0; i < data.CategoryObjAry.Length; i++ )
                                {
                                    wkCategoryObjAry[i] = data.CategoryObjAry[i];
                                }
                                row[_dataSet.SalesDetail.CategoryObjAryColumn.ColumnName] = wkCategoryObjAry; // �����I�u�W�F�N�g�z��
                                row[_dataSet.SalesDetail.SalesInputCodeColumn.ColumnName] = data.SalesInputCode; // ���s��
                                row[_dataSet.SalesDetail.FrontEmployeeCdColumn.ColumnName] = data.FrontEmployeeCd; // �󒍎�
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                                row[_dataSet.SalesDetail.HistoryDivNameColumn.ColumnName] = this.GetHistoryDivName( data.HistoryDiv ); // �����敪
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
                                row[_dataSet.SalesDetail.SlipPrintTimeColumn.ColumnName] = this.GetSlipPrintTimeText( data.UpdateDateTime ); // �`�[���s����
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
                                // ADD 2012/04/01 gezh Redmine#29250 ------------------------------------------------------------->>>>>
                                if (data.UpdateDateTimeDetail != 0)
                                {
                                    DateTime dt = new DateTime(data.UpdateDateTimeDetail);
                                    row[_dataSet.SalesDetail.UpdateDateTimeColumn.ColumnName] = dt.ToString("yyyy/MM/dd HH:mm:ss"); // �X�V����
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.UpdateDateTimeColumn.ColumnName] = string.Empty;
                                }
                                // ADD 2012/04/01 gezh Redmine#29250 -------------------------------------------------------------<<<<<
                                // --- ADD 2009/09/07 ---------->>>>>
                                row[_dataSet.SalesDetail.MileageColumn.ColumnName] = data.Mileage;
                                row[_dataSet.SalesDetail.CarNoteColumn.ColumnName] = data.CarNote;
                                // --- ADD 2009/09/07 ----------<<<<<


                                // ----- DEL huangt 2013/05/15 Redmine#35640 ---------- >>>>> 
                                //// �ۑ�����Ă���`�[�ԍ����X�V
                                //if ( !data.SalesSlipNum.Equals( salesSlipNumExt ) )
                                //{
                                //    salesSlipNumExt = data.SalesSlipNum;
                                //}
                                // ----- DEL huangt 2013/05/15 Redmine#35640 ---------- <<<<< 

                                // ---------- ADD 2016/01/21 Y.Wakita ---------->>>>>
                                row[_dataSet.SalesDetail.SalesNotRecognitionCntColumn.ColumnName] = DBNull.Value;   // ���v�㐔
                                row[_dataSet.SalesDetail.SalesRecognitionCntColumn.ColumnName] = DBNull.Value;      // �v�㐔

                                // �󒍃X�e�[�^�X��"�ݏo"�܂���"��" ���� ����`�[�敪(����)��"����"�̏ꍇ
                                if ((data.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Shipment ||
                                     data.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder) && 
                                     data.SalesSlipCd == 0)
                                {
                                    row[_dataSet.SalesDetail.SalesNotRecognitionCntColumn] = data.AcptAnOdrRemainCnt;                       // ���v�㐔
                                    row[_dataSet.SalesDetail.SalesRecognitionCntColumn] = (data.ShipmentCnt - data.AcptAnOdrRemainCnt);     // �v�㐔
                                }
                                // ---------- ADD 2016/01/21 Y.Wakita ----------<<<<<

                                // ---- ADD K2015/04/27 �� �����Z���i�̑�񔄉��ǉ�---->>>>>
                                // �����Z���i�̑�񔄉�
                                if (this._opt_Momose == Convert.ToInt32(Option.ON))
                                {
                                    row[this._dataSet.SalesDetail.SecondSalePriceColumn.ColumnName] = this.GetSecondPrice(data);
                                }
                                // ---- ADD K2015/04/27 �� �����Z���i�̑�񔄉��ǉ�----<<<<<

                                //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
                                if (this._opt_Meigo == Convert.ToInt32(Option.ON))
                                {
                                    row[_dataSet.SalesDetail.SalesAreaNameColumn.ColumnName] = data.SalesAreaName;
                                    if (data.CustAnalysCode1 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode1Column.ColumnName] = data.CustAnalysCode1;
                                    }
                                    if (data.CustAnalysCode2 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode2Column.ColumnName] = data.CustAnalysCode2;
                                    }
                                    if (data.CustAnalysCode3 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode3Column.ColumnName] = data.CustAnalysCode3;
                                    }
                                    if (data.CustAnalysCode4 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode4Column.ColumnName] = data.CustAnalysCode4;
                                    }
                                    if (data.CustAnalysCode5 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode5Column.ColumnName] = data.CustAnalysCode5;
                                    }
                                    if (data.CustAnalysCode6 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode6Column.ColumnName] = data.CustAnalysCode6;
                                    }
                                }
                                //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<

                                #endregion // ���ׁE����f�[�^
                            }
                            else
                            {
                                #region ���ׁE�����f�[�^
                                row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                //row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = false;
                                //row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.SalesDate);
                                row[_dataSet.SalesDetail.RowNoColumn.ColumnName] = rowNo;
                                row[_dataSet.SalesDetail.DataDivColumn.ColumnName] = data.DataDiv;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                                //row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = data.SalesDate;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                                // �������f�[�^���ADDUPADATE���`�[���t�Ȃ̂�SalesDateColumn�ɂ�ADDUPADATE���Z�b�g����(�v����Ɠ������e�ɂȂ�)
                                row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = data.AddUpADate;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                                row[_dataSet.SalesDetail.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                                row[_dataSet.SalesDetail.SalesRowNoColumn.ColumnName] = data.SalesRowNo;
                                row[_dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                                row[_dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                                row[_dataSet.SalesDetail.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                                row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "����";
                                row[_dataSet.SalesDetail.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                                row[_dataSet.SalesDetail.GoodsNameColumn.ColumnName] = data.GoodsName;
                                row[_dataSet.SalesDetail.GoodsNoColumn.ColumnName] = data.GoodsNo;
                                row[_dataSet.SalesDetail.ChangeGoodsNoColumn.ColumnName] = data.ChangeGoodsNo; //ADD �i�N 2014/12/28 �ϊ���i�Ԃ̒ǉ��Ή�
                                if ( data.BLGoodsCode == 0 )
                                {
                                    row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = data.BLGoodsCode.ToString().PadLeft( CT_DEPTH_BLGOODSCODE, '0' );
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                                //row[_dataSet.SalesDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode.ToString().PadLeft(CT_DEPTH_BLGROUPCODE, '0');
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                row[_dataSet.SalesDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] = data.ShipmentCnt;
                                //row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = data.ListPriceTaxExcFl;
                                //row[_dataSet.SalesDetail.OpenPriceDivColumn.ColumnName] = data.OpenPriceDiv;
                                //row[_dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName] = data.SalesUnPrcTaxExcFl;
                                //row[_dataSet.SalesDetail.SalesUnitCostColumn.ColumnName] = data.SalesUnitCost;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.OpenPriceDivColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.SalesUnitCostColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName] = data.SalesMoneyTaxExc;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //row[_dataSet.SalesDetail.ConsTaxLayMethodColumn.ColumnName] = data.ConsTaxLayMethod;
                                //row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = data.SalesTotalTaxInc;
                                //row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = data.SalesPriceConsTax;
                                //row[_dataSet.SalesDetail.TotalCostColumn.ColumnName] = data.TotalCost;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.ConsTaxLayMethodColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                                row[_dataSet.SalesDetail.TotalCostColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                                //// �ޕʔԍ�[0�̂Ƃ��͋�]
                                //if (data.CategoryNo == 0)
                                //{
                                //    row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = data.CategoryNo;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //row[_dataSet.SalesDetail.ModelFullNameColumn.ColumnName] = data.ModelFullName;
                                ////row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.FirstEntryDate);
                                //// �N��[NULL�̂Ƃ��͋�]
                                //if ( data.FirstEntryDate == DateTime.MinValue )//DBNull.Value)// 
                                //{
                                //    row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = data.FirstEntryDate;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                //----- ADD K2014/05/08 By �ђ��} �e�L�X�g�o�͍��ڂɎԎ탁�[�J�[�R�[�h��ǉ����� BEGIN--------->>>>>
                                row[_dataSet.SalesDetail.MakerCodeColumn.ColumnName] = DBNull.Value;
                                //----- ADD K2014/05/08 By �ђ��} �e�L�X�g�o�͍��ڂɎԎ탁�[�J�[�R�[�h��ǉ����� END---------<<<<<

                                // ---- ADD K2015/04/29 �� �e�L�X�g�o�͍��ڂɑ�񔄉��ǉ���ǉ����� ----->>>>>
                                if (this._opt_Momose == Convert.ToInt32(Option.ON))
                                {
                                    row[_dataSet.SalesDetail.SecondSalePriceColumn.ColumnName] = DBNull.Value;
                                }
                                // ---- ADD K2015/04/29 �� �e�L�X�g�o�͍��ڂɑ�񔄉��ǉ���ǉ����� ----<<<<<

                                row[_dataSet.SalesDetail.ModelFullNameColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                // --- ADD m.suzuki 2010/04/02 ---------->>>>>
                                row[_dataSet.SalesDetail.ModelHalfNameColumn.ColumnName] = DBNull.Value;
                                // --- ADD m.suzuki 2010/04/02 ----------<<<<<
                                // �ԑ�No[NULL�̂Ƃ��͋�]
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 DEL
                                //if ( data.SearchFrameNo == 0 )
                                //{
                                //    row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = data.SearchFrameNo;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                                row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //row[_dataSet.SalesDetail.FullModelColumn.ColumnName] = data.FullModel;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.FullModelColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.SlipNoteColumn.ColumnName] = data.SlipNote;
                                row[_dataSet.SalesDetail.SlipNote2Column.ColumnName] = data.SlipNote2;
                                row[_dataSet.SalesDetail.SlipNote3Column.ColumnName] = data.SlipNote3;
                                row[_dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                                row[_dataSet.SalesDetail.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 DEL
                                //row[_dataSet.SalesDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode.ToString().PadLeft(CT_DEPTH_CUSTOMERCODE, '0');
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 DEL 
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD
                                row[_dataSet.SalesDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD
                                row[_dataSet.SalesDetail.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 DEL
                                //// �d����R�[�h[NULL�̂Ƃ��͋�]
                                //if (data.SupplierCd == 0)
                                //{
                                //    row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = string.Empty; //DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = data.SupplierCd.ToString().PadLeft(CT_DEPTH_SUPPLIERCODE, '0');
                                //}
                                //row[_dataSet.SalesDetail.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                                //row[_dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName] = data.PartySaleSlipNum;
                                //row[_dataSet.SalesDetail.CarMngCodeColumn.ColumnName] = data.CarMngCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD
                                row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.SupplierSnmColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.CarMngCodeColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //// �v�㌳��No[NULL�̂Ƃ��͋�]
                                //if ( data.AcceptAnOrderNo == 0 )
                                //{
                                //    row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = data.AcceptAnOrderNo;
                                //}
                                //// �v�㌳�o��No[NULL�̂Ƃ��͋�]
                                //if ( data.ShipmSalesSlipNum == "0" )
                                //{
                                //    row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = string.Empty;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = data.ShipmSalesSlipNum;
                                //}
                                //// ����No[NULL�̂Ƃ��͋�]
                                //if ( data.SrcSalesSlipNum == "0" )
                                //{
                                //    row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = string.Empty; //DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = data.SrcSalesSlipNum;
                                //}
                                //row[_dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName] = data.SalesOrderDivCd;
                                //row[_dataSet.SalesDetail.WarehouseCdColumn.ColumnName] = data.WarehouseCode;
                                //row[_dataSet.SalesDetail.WarehouseNameColumn.ColumnName] = data.WarehouseName;
                                //// �����d��No[NULL�̂Ƃ��͋�]
                                //if ( data.SupplierSlipNo == 0 )
                                //{
                                //    row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.WarehouseCdColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.WarehouseNameColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                row[_dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //// ������R�[�h[NULL�̂Ƃ��͋�]
                                //if ( data.UOESupplierCd == 0 )
                                //{
                                //    row[_dataSet.SalesDetail.UOESupplierCdColumn] = string.Empty; //DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.UOESupplierCdColumn] = data.UOESupplierCd.ToString().PadLeft( CT_DEPTH_UOESUPPLIERCODE, '0' );
                                //}
                                //row[_dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName] = data.UOESupplierSnm;
                                //row[_dataSet.SalesDetail.UOERemark1Column.ColumnName] = data.UoeRemark1;
                                //row[_dataSet.SalesDetail.UOERemark2Column.ColumnName] = data.UoeRemark2;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.UOESupplierCdColumn] = DBNull.Value;
                                row[_dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.UOERemark1Column.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.UOERemark2Column.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.GuideNameColumn.ColumnName] = data.GuideName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //row[_dataSet.SalesDetail.SectionCdColumn.ColumnName] = data.SectionCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.SectionGuideNameColumn.ColumnName] = data.SectionGuideNm;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //row[_dataSet.SalesDetail.DtlNoteColumn.ColumnName] = data.DtlNote;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.DtlNoteColumn.ColumnName] = this.GetValidityTerm( data.DtlNote ); // ���ה��l���L���������Z�b�g
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //row[_dataSet.SalesDetail.ColorName1Column.ColumnName] = data.ColorName1;
                                //row[_dataSet.SalesDetail.TrimNameColumn.ColumnName] = data.TrimName;
                                //row[_dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName] = data.StdUnPrcLPrice;
                                //row[_dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName] = data.StdUnPrcSalUnPrc;
                                //row[_dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName] = data.StdUnPrcUnCst;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.ColorName1Column.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.TrimNameColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 DEL
                                //// ���[�J�[�R�[�h[NULL�̂Ƃ��͋�]
                                //if (data.GoodsMakerCd == 0)
                                //{
                                //    row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = string.Empty; //DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = data.GoodsMakerCd.ToString().PadLeft(CT_DEPTH_GOODSMAKERCODE, '0');
                                //}
                                //row[_dataSet.SalesDetail.MakerNameColumn.ColumnName] = data.MakerName;
                                //row[_dataSet.SalesDetail.CostColumn.ColumnName] = data.Cost;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD
                                row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.MakerNameColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.CostColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //// ���Ӑ�`�[�ԍ�[NULL�̂Ƃ��͋�]
                                //if ( data.CustSlipNo == 0 )
                                //{
                                //    row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = data.CustSlipNo;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                //row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.AddUpADate);
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                                //row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                if ( data.AddUpADate != DateTime.MinValue )
                                {
                                    row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = DBNull.Value;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //row[_dataSet.SalesDetail.AccRecDivCdColumn.ColumnName] = data.AccRecDivCd;
                                //if ( data.AccRecDivCd == 1 )
                                //{
                                //    row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = "���|";
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.AccRecDivCdColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                //row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = data.DebitNoteDiv;
                                if ( data.DebitNoteDiv == 0 )
                                {
                                    row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "��";
                                }
                                else if ( data.DebitNoteDiv == 1 )
                                {
                                    row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "��";
                                }
                                else if ( data.DebitNoteDiv == 2 )
                                {
                                    row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "���E�ςݍ�";
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                                row[_dataSet.SalesDetail.AddresseeCodeColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.AddresseeNameColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
                                // ���͓�
                                if ( data.InputDay != DateTime.MinValue )
                                {
                                    row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = data.InputDay;
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = DBNull.Value;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                                row[_dataSet.SalesDetail.SalesSlipCdDtlColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.SalesSlipCdDtlNameColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.GoodsLGroupColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.GoodsLGroupNameColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.GoodsMGroupColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.GoodsMGroupNameColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.GoodsKindCodeColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.GoodsKindCodeNameColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.WarehouseShelfNoColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                                row[_dataSet.SalesDetail.HistoryDivNameColumn.ColumnName] = string.Empty; // �����敪
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
                                row[_dataSet.SalesDetail.SlipPrintTimeColumn.ColumnName] = this.GetSlipPrintTimeText( data.UpdateDateTime ); // �`�[���s����
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
                                // ADD 2012/04/01 gezh Redmine#29250 ----------------------------------------------->>>>>
                                if (data.UpdateDateTimeDetail != 0)
                                {
                                    DateTime dt = new DateTime(data.UpdateDateTimeDetail);
                                    row[_dataSet.SalesDetail.UpdateDateTimeColumn.ColumnName] = dt.ToString("yyyy/MM/dd HH:mm:ss"); // �X�V����
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.UpdateDateTimeColumn.ColumnName] = string.Empty;
                                }
                                // ADD 2012/04/01 gezh Redmine#29250 -----------------------------------------------<<<<<

                                //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
                                if (this._opt_Meigo == Convert.ToInt32(Option.ON))
                                {
                                    row[_dataSet.SalesDetail.SalesAreaNameColumn.ColumnName] = data.SalesAreaName;
                                    if (data.CustAnalysCode1 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode1Column.ColumnName] = data.CustAnalysCode1;
                                    }
                                    if (data.CustAnalysCode2 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode2Column.ColumnName] = data.CustAnalysCode2;
                                    }
                                    if (data.CustAnalysCode3 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode3Column.ColumnName] = data.CustAnalysCode3;
                                    }
                                    if (data.CustAnalysCode4 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode4Column.ColumnName] = data.CustAnalysCode4;
                                    }
                                    if (data.CustAnalysCode5 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode5Column.ColumnName] = data.CustAnalysCode5;
                                    }
                                    if (data.CustAnalysCode6 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode6Column.ColumnName] = data.CustAnalysCode6;
                                    }
                                }
                                //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<

                                #endregion // ���ׁE�����f�[�^
                            }

                            // �s�ǉ�
                            //this._dataSet.SalesDetail.Rows.Add( row );        //DEL 2009/02/14 �s��Ή�[11391]
                            // ---ADD 2009/02/14 �s��Ή�[11391] -------------------------------------------->>>>>
                            if ( data.DataDiv == 0 )
                            {
                                this._dataSet.SalesDetail.Rows.Add( row );
                            }
                            else
                            {
                                // �萔���A�l�����̖��׃f�[�^�͂��̎��_�ł͍쐬���Ȃ�
                                if ( (data.SalesRowNo != 0) && (string.IsNullOrEmpty( data.GoodsName.TrimEnd() )) == false )
                                {
                                    this._dataSet.SalesDetail.Rows.Add( row );
                                }
                            }
                            // ---ADD 2009/02/14 �s��Ή�[11391] --------------------------------------------<<<<<

                            #endregion // ���׃f�[�^�e�[�u��

                            #region ���z�f�[�^���W�v

                            //-------------------------
                            // ���z�f�[�^���W�v
                            //-------------------------
                            //if (data.SalesSlipCd == 0) // ����
                            //{
                            if ( data.DataDiv == 0 )  // ����f�[�^�̏ꍇ
                            {
                                // �W�����i���v(�W�����i * �o�א�)
                                StandardPrice_Total += (data.ListPriceTaxExcFl * data.ShipmentCnt);
                                // ������z���v
                                // ---------UPD 2010/08/05--------->>>>>
                                // ---------UPD 2010/09/01--------->>>>>
                                SoldAmount_Total += data.SalesMoneyTaxExc;
                                //SoldAmount_Total += (data.SalesUnPrcTaxExcFl * data.ShipmentCnt);
                                // ---------UPD 2010/09/01---------<<<<<
                                // ---------UPD 2010/08/05---------<<<<<
                                // �������v
                                //Cost_Total += data.Cost;// DEL 2010/08/31
                                Cost_Total += data.ShipmentCnt * data.SalesUnitCost;// ADD 2010/08/31
                                // �e���z���v(���׋��z - ����)
                                GrossProfitAmount_Total += (data.SalesMoneyTaxExc - Double.Parse( data.Cost.ToString() ));
                                //GrossProfitAmount_Total += (data.SalesMoneyTaxExc - data.ShipmentCnt * data.SalesUnitCost);
                                // ����Łi���j
                                totalOfsThisSalesTax += data.SalesPriceConsTax;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 DEL
                                //// �����
                                //totalConsumeTaxAmount += data.SalesPriceConsTax;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
                                // �����
                                switch ( data.ConsTaxLayMethod )
                                {
                                    // 2010/07/08 Del >>>
                                    //// ���ד]��
                                    //case 0:
                                    // 2010/07/08 Del <<<
                                    // 2010/07/08 >>>
                                    //// �`�[�]��
                                    // ���ד]��
                                    // 2010/07/08 <<<
                                    case 1:
                                        // ���Z����
                                        totalConsumeTaxAmount += data.SalesPriceConsTax;
                                        break;
                                    // 2010/07/08 Add >>>
                                    // �`�[�]��
                                    case 0:
                                        if ( !data.SalesSlipNum.Equals( exSlipNum2 ) ) // ��s�ڂ̂݉��Z
                                        {
                                            totalConsumeTaxAmount += data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                                        }
                                        break;
                                    // 2010/07/08 Add <<<
                                    // �����e
                                    case 2:
                                    // �����q
                                    case 3:
                                    // ��ې�
                                    case 9:
                                    default:
                                        // ���Z���Ȃ�
                                        break;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
                                // ���ʌv
                                //-----UPD 2010/12/20----- >>>>>
                                if ((data.AcptAnOdrStatus == 30) && (data.SalesSlipCdDtl != 2))
�@                              {
                                    totalAmount += data.ShipmentCnt;
                                }
                                //totalAmount += data.ShipmentCnt;
                                //-----UPD 2010/12/20----- <<<<<
                                // ���񔄏�
                                totalThisSalesPrice += data.SalesMoneyTaxExc;

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                                // �`�[�ʓ��ŋ��z�W�v
                                if ( data.TaxationDivCd == 2 )
                                {
                                    long consTaxInclu = (long)row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName]
                                                        - (long)row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName];
                                    salAmntConsTaxInclu += consTaxInclu;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

                                // 2010/07/08 Add >>>
                                // �ۑ�����Ă���`�[�ԍ����X�V
                                if ( !data.SalesSlipNum.Equals( exSlipNum2 ) )
                                {
                                    exSlipNum2 = data.SalesSlipNum;
                                }
                                // 2010/07/08 Add <<<
                            }
                            else // �����f�[�^�̏ꍇ
                            {
                                //�������
                                totalThisTimeDmdNrml += data.SalesMoneyTaxExc;
                            }
                            //}
                            //else // �ԕi
                            //{
                            //    // �W�����i���v(�W�����i * �o�א�)
                            //    StandardPrice_Total -= (data.ListPriceTaxExcFl * data.ShipmentCnt);
                            //    // ������z���v
                            //    SoldAmount_Total -= data.SalesMoneyTaxExc;
                            //    // �������v
                            //    Cost_Total -= data.Cost;
                            //    // �e���z���v(���׋��z - ����)
                            //    GrossProfitAmount_Total -= (data.ListPriceTaxExcFl - Double.Parse(data.Cost.ToString()));
                            //    // ���񔄏�/�������
                            //    if (data.DataDiv == 0)  // ����f�[�^�̏ꍇ
                            //    {
                            //        totalThisSalesPrice -= data.SalesMoneyTaxExc;
                            //    }
                            //    else // �����f�[�^�̏ꍇ
                            //    {
                            //        totalThisTimeDmdNrml -= data.SalesMoneyTaxExc;
                            //    }
                            //    // ����Łi���j
                            //    totalOfsThisSalesTax -= data.SalesPriceConsTax;
                            //    // �����
                            //    totalConsumeTaxAmount -= data.SalesPriceConsTax;
                            //    // ���ʌv
                            //    totalAmount -= data.ShipmentCnt;
                            //}

                            // ���א�
                            detailSlipCount++;

                            #endregion // ���z�f�[�^���W�v

                            #region �`�[�\���f�[�^�e�[�u��

                            // ����͍i�荞�݂��s��
                            // �i���̏������ڂ͓`�[�ԍ��A�󒍃X�e�[�^�X
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                            //if (!data.SalesSlipNum.Equals(exSlipNum) || data.AcptAnOdrStatus != exAcptAnOdrStatus)
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                            if ( index > 0 && (!data.SalesSlipNum.Equals( exSlipNum ) || data.AcptAnOdrStatus != exAcptAnOdrStatus) )
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                            {
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                                # region // DEL
                                //// �`�[�ԍ�����ю󒍃X�^�[�^�X���قȂ�Εʓ`�[�Ƃ��Ď擾
                                //row2 = _dataSet.SalesList.NewRow();

                                //// ����`�[�Ȃ̂������`�[�Ȃ̂��Ńf�[�^�̍\�����قȂ�
                                //if (data.DataDiv == 0)
                                //{
                                //    #region ����`�[
                                //    // ����`�[
                                //    row2[_dataSet.SalesList.SelectionColumn.ColumnName] = false;
                                //    row2[_dataSet.SalesList.RowNoColumn.ColumnName] = rowNo;
                                //    row2[_dataSet.SalesList.DataDivColumn.ColumnName] = data.DataDiv;
                                //    row2[_dataSet.SalesList.SalesDateColumn.ColumnName] = data.SalesDate;
                                //    //row2[_dataSet.SalesList.SalesDateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.SalesDate);
                                //    row2[_dataSet.SalesList.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                                //    row2[_dataSet.SalesList.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                                //    row2[_dataSet.SalesList.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                                //    // �`�[�敪������
                                //    if (data.SalesSlipCd == 0)
                                //    {
                                //        if (data.AcptAnOdrStatus == 20)
                                //        {
                                //            row2[_dataSet.SalesList.SalesSlipCdNameColumn.ColumnName] = "��";
                                //        }
                                //        else if (data.AcptAnOdrStatus == 30)
                                //        {
                                //            row2[_dataSet.SalesList.SalesSlipCdNameColumn.ColumnName] = "����";
                                //        }
                                //        else if (data.AcptAnOdrStatus == 40)
                                //        {
                                //            row2[_dataSet.SalesList.SalesSlipCdNameColumn.ColumnName] = "�ݏo";
                                //        }
                                //    }
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.SalesSlipCdNameColumn.ColumnName] = "�ԕi";
                                //    }
                                //    row2[_dataSet.SalesList.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                                //    //row2[_dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                                //    //row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                                //    //row2[_dataSet.SalesList.GrossProfitColumn.ColumnName] = data.SalesTotalTaxExc - data.TotalCost;
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                                //    //if (data.CategoryNo == 0)
                                //    //{
                                //    //    row2[_dataSet.SalesList.CategoryNoColumn.ColumnName] = DBNull.Value;
                                //    //}
                                //    //else
                                //    //{
                                //    //    row2[_dataSet.SalesList.CategoryNoColumn.ColumnName] = data.CategoryNo;
                                //    //}
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                //    row2[_dataSet.SalesList.CategoryNoColumn.ColumnName] = GetModelDesignationNoAndCategoryNo( data );
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                //    row2[_dataSet.SalesList.ModelFullNameColumn.ColumnName] = data.ModelFullName;
                                //    if (data.FirstEntryDate == DateTime.MinValue)
                                //    {
                                //        row2[_dataSet.SalesList.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                                //    }
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.FirstEntryDateColumn.ColumnName] = data.FirstEntryDate;
                                //    }

                                //    //row2[_dataSet.SalesList.FirstEntryDateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.FirstEntryDate);
                                //    row2[_dataSet.SalesList.FullModelColumn.ColumnName] = data.FullModel;
                                //    if (data.SearchFrameNo == 0)
                                //    {
                                //        row2[_dataSet.SalesList.SearchFrameNoColumn.ColumnName] = DBNull.Value;
                                //    }
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.SearchFrameNoColumn.ColumnName] = data.SearchFrameNo;
                                //    }
                                //    row2[_dataSet.SalesList.SlipNoteColumn.ColumnName] = data.SlipNote;
                                //    row2[_dataSet.SalesList.SlipNote2Column.ColumnName] = data.SlipNote2;
                                //    row2[_dataSet.SalesList.SlipNote3Column.ColumnName] = data.SlipNote3;
                                //    row2[_dataSet.SalesList.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                                //    row2[_dataSet.SalesList.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 DEL
                                //    //row2[_dataSet.SalesList.CustomerCodeColumn.ColumnName] = data.CustomerCode.ToString().PadLeft(CT_DEPTH_CUSTOMERCODE, '0');
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 DEL
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD
                                //    row2[_dataSet.SalesList.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD
                                //    row2[_dataSet.SalesList.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                                //    row2[_dataSet.SalesList.PartySaleSlipNumColumn.ColumnName] = data.PartySaleSlipNum;
                                //    row2[_dataSet.SalesList.CarMngCodeColumn.ColumnName] = data.CarMngCode;
                                //    if (data.AcceptAnOrderNo == 0)
                                //    {
                                //        row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                                //    }
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = data.AcceptAnOrderNo;
                                //    }
                                //    if (data.ShipmSalesSlipNum == "0")
                                //    {
                                //        row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = string.Empty;
                                //    }
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = data.ShipmSalesSlipNum;
                                //    }
                                //    row2[_dataSet.SalesList.UoeRemark1Column.ColumnName] = data.UoeRemark1;
                                //    row2[_dataSet.SalesList.UoeRemark2Column.ColumnName] = data.UoeRemark2;
                                //    row2[_dataSet.SalesList.SectionCdColumn.ColumnName] = data.SectionCode;
                                //    row2[_dataSet.SalesList.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                                //    row2[_dataSet.SalesList.ColorName1Column.ColumnName] = data.ColorName1;
                                //    row2[_dataSet.SalesList.TrimNameColumn.ColumnName] = data.TrimName;
                                //    if (data.CustSlipNo == 0)
                                //    {
                                //        row2[_dataSet.SalesList.CustSlipNoColumn.ColumnName] = DBNull.Value;
                                //    }
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.CustSlipNoColumn.ColumnName] = data.CustSlipNo;
                                //    }
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                                //    //row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                //    if ( data.AddUpADate != DateTime.MinValue )
                                //    {
                                //        row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                //    }
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = DBNull.Value;
                                //    }
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                //    //row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.AddUpADate);
                                //    row2[_dataSet.SalesList.AccRecDivCdColumn.ColumnName] = data.AccRecDivCd;
                                //    if (data.AccRecDivCd == 1)
                                //    {
                                //        row2[_dataSet.SalesList.AccRecDivCdNameColumn.ColumnName] = "���|";
                                //    }
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.AccRecDivCdNameColumn.ColumnName] = "����";
                                //    }
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                //    //row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = data.DebitNoteDiv;
                                //    if (data.DebitNoteDiv == 0)
                                //    {
                                //        row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "���`";
                                //    }
                                //    else if (data.DebitNoteDiv == 1)
                                //    {
                                //        row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "�ԓ`";
                                //    }
                                //    else if (data.DebitNoteDiv == 2)
                                //    {
                                //        row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "����";
                                //    }
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = string.Empty;
                                //    }
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                //    if ( (long)row[_dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName] < 0 )
                                //    {
                                //        row[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "�ԓ`";
                                //    }
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                                //    # region [����Ŋ֘A]
                                //    bool printTax = true;
                                //    Int64 salesTotalTaxInc;
                                //    Int64 salesTotalTaxExc = data.SalesTotalTaxExc;
                                //    Int64 salesPriceConsTax;

                                //    // ����������Ŋz�̎擾
                                //    if ( data.ConsTaxLayMethod == 0 ) // �`�[�P��
                                //    {
                                //        salesPriceConsTax = data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                                //    }
                                //    else if ( data.ConsTaxLayMethod == 1 ) // ���גP��
                                //    {
                                //        salesPriceConsTax = data.SalesPriceConsTax;
                                //    }
                                //    else
                                //    {
                                //        salesPriceConsTax = 0;
                                //    }

                                //    // �ō����z�̎擾
                                //    salesTotalTaxInc = salesTotalTaxExc + salesPriceConsTax;

                                //    if ( printTax )
                                //    {
                                //        // ����ň󎚗L������Ƌ��z����
                                //        int totalAmountDispWayCd = data.TotalAmountDispWayCd;

                                //        // ����ň󎚗L������
                                //        printTax = ReflectMoneyForTaxPrintOfSlip( ref salesTotalTaxExc, ref salesPriceConsTax, ref salAmntConsTaxInclu, ref salesTotalTaxInc, totalAmountDispWayCd, data.ConsTaxLayMethod );
                                //        if ( printTax )
                                //        {
                                //            row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = salesPriceConsTax;
                                //        }
                                //        else
                                //        {
                                //            // �󎚂��Ȃ�
                                //            row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                                //        }
                                //    }
                                //    else
                                //    {
                                //        // �󎚂��Ȃ�
                                //        row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                                //    }
                                //    // �Ŕ����z�Z�b�g
                                //    row2[_dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName] = salesTotalTaxExc;
                                //    // �e���Z�b�g
                                //    row2[_dataSet.SalesList.GrossProfitColumn.ColumnName] = salesTotalTaxExc - data.TotalCost;
                                //    # endregion
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                                //    #endregion // ����`�[
                                //}
                                //else
                                //{
                                //    #region �����`�[
                                //    // �����`�[
                                //    // �I���`�F�b�N�{�b�N�X�Ȃ�
                                //    row2[_dataSet.SalesList.SelectionColumn.ColumnName] = DBNull.Value;
                                //    row2[_dataSet.SalesList.RowNoColumn.ColumnName] = rowNo;
                                //    row2[_dataSet.SalesList.DataDivColumn.ColumnName] = data.DataDiv;
                                //    row2[_dataSet.SalesList.SalesDateColumn.ColumnName] = data.SalesDate;
                                //    row2[_dataSet.SalesList.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                                //    row2[_dataSet.SalesList.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                                //    row2[_dataSet.SalesList.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                                //    row2[_dataSet.SalesList.SalesSlipCdNameColumn.ColumnName] = "����";
                                //    row2[_dataSet.SalesList.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                                //    row2[_dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                                //    //row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                                //    //row2[_dataSet.SalesList.GrossProfitColumn.ColumnName] = data.SalesTotalTaxExc - data.TotalCost;
                                //    //row2[_dataSet.SalesList.CategoryNoColumn.ColumnName] = data.CategoryNo;
                                //    row2[_dataSet.SalesList.CategoryNoColumn.ColumnName] = DBNull.Value;
                                //    //row2[_dataSet.SalesList.ModelFullNameColumn.ColumnName] = data.ModelFullName;
                                //    //row2[_dataSet.SalesList.FirstEntryDateColumn.ColumnName] = data.FirstEntryDate;
                                //    //row2[_dataSet.SalesList.FullModelColumn.ColumnName] = data.FullModel;
                                //    //row2[_dataSet.SalesList.SearchFrameNoColumn.ColumnName] = data.SearchFrameNo;
                                //    row2[_dataSet.SalesList.SearchFrameNoColumn.ColumnName] = DBNull.Value;
                                //    row2[_dataSet.SalesList.SlipNoteColumn.ColumnName] = data.SlipNote;
                                //    //row2[_dataSet.SalesList.SlipNote2Column.ColumnName] = data.SlipNote2;
                                //    //row2[_dataSet.SalesList.SlipNote3Column.ColumnName] = data.SlipNote3;
                                //    //row2[_dataSet.SalesList.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                                //    row2[_dataSet.SalesList.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 DEL
                                //    //row2[_dataSet.SalesList.CustomerCodeColumn.ColumnName] = data.CustomerCode.ToString().PadLeft(CT_DEPTH_CUSTOMERCODE, '0');
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 DEL
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD
                                //    row2[_dataSet.SalesList.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD
                                //    row2[_dataSet.SalesList.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                                //    //row2[_dataSet.SalesList.PartySaleSlipNumColumn.ColumnName] = data.PartySaleSlipNum;
                                //    //row2[_dataSet.SalesList.CarMngCodeColumn.ColumnName] = data.CarMngCode;
                                //    //row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = data.AcceptAnOrderNo;
                                //    row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                                //    //row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = data.ShipmSalesSlipNum;
                                //    row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = string.Empty;
                                //    //row2[_dataSet.SalesList.UoeRemark1Column.ColumnName] = data.UoeRemark1;
                                //    //row2[_dataSet.SalesList.UoeRemark2Column.ColumnName] = data.UoeRemark2;
                                //    row2[_dataSet.SalesList.SectionCdColumn.ColumnName] = data.SectionCode;
                                //    row2[_dataSet.SalesList.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                                //    //row2[_dataSet.SalesList.ColorName1Column.ColumnName] = data.ColorName1;
                                //    //row2[_dataSet.SalesList.TrimNameColumn.ColumnName] = data.TrimName;
                                //    //row2[_dataSet.SalesList.CustSlipNoColumn.ColumnName] = data.CustSlipNo;
                                //    row2[_dataSet.SalesList.CustSlipNoColumn.ColumnName] = DBNull.Value;
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                                //    if ( data.AddUpADate != DateTime.MinValue )
                                //    {
                                //        row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                //    }
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = DBNull.Value;
                                //    }
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                                //    //if (data.AccRecDivCd == 1)
                                //    //{
                                //    //    row2[_dataSet.SalesList.AccRecDivCdNameColumn.ColumnName] = "���|";
                                //    //}
                                //    //row2[_dataSet.SalesList.AccRecDivCdColumn.ColumnName] = data.AccRecDivCd;
                                //    if (data.DebitNoteDiv == 0)
                                //    {
                                //        row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "��";
                                //    }
                                //    else if (data.DebitNoteDiv == 1)
                                //    {
                                //        row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "��";
                                //    }
                                //    else if (data.DebitNoteDiv == 2)
                                //    {
                                //        row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "���E�ύ�";
                                //    }
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = string.Empty;
                                //    }
                                //    #endregion // �����`�[
                                //}

                                //// �s�ǉ�
                                //this._dataSet.SalesList.Rows.Add(row2);
                                # endregion
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                                # region // DEL
                                //// ---ADD 2009/02/14 �s��Ή�[11391] ----------------------------------------------------->>>>>
                                //rowDetailNo = rowNo;
                                //if (data.DataDiv != 0)
                                //{
                                //    // �萔�����גǉ�
                                //    if (data.FeeDeposit > 0)
                                //    {
                                //        rowDetailNo++;
                                //        row = this._dataSet.SalesDetail.NewRow();
                                //        #region �萔���p���׍쐬
                                //        row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.RowNoColumn.ColumnName] = rowDetailNo;
                                //        row[_dataSet.SalesDetail.DataDivColumn.ColumnName] = data.DataDiv;
                                //        row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = data.SalesDate;
                                //        row[_dataSet.SalesDetail.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                                //        row[_dataSet.SalesDetail.SalesRowNoColumn.ColumnName] = 98;
                                //        row[_dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                                //        row[_dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                                //        row[_dataSet.SalesDetail.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                                //        row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "����";
                                //        row[_dataSet.SalesDetail.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                                //        row[_dataSet.SalesDetail.GoodsNameColumn.ColumnName] = "�萔��";
                                //        row[_dataSet.SalesDetail.GoodsNoColumn.ColumnName] = data.GoodsNo;
                                //        if (data.BLGoodsCode == 0)
                                //        {
                                //            row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = DBNull.Value;
                                //        }
                                //        else
                                //        {
                                //            row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = data.BLGoodsCode.ToString().PadLeft(CT_DEPTH_BLGOODSCODE, '0');
                                //        }
                                //        row[_dataSet.SalesDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode;
                                //        row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.OpenPriceDivColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesUnitCostColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName] = data.FeeDeposit;
                                //        row[_dataSet.SalesDetail.ConsTaxLayMethodColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.TotalCostColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.ModelFullNameColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.FullModelColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SlipNoteColumn.ColumnName] = data.SlipNote;
                                //        row[_dataSet.SalesDetail.SlipNote2Column.ColumnName] = data.SlipNote2;
                                //        row[_dataSet.SalesDetail.SlipNote3Column.ColumnName] = data.SlipNote3;
                                //        row[_dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                                //        row[_dataSet.SalesDetail.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                                //        row[_dataSet.SalesDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                                //        row[_dataSet.SalesDetail.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                                //        row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SupplierSnmColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.CarMngCodeColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.WarehouseCdColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.WarehouseNameColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.UOESupplierCdColumn] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.UOERemark1Column.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.UOERemark2Column.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.GuideNameColumn.ColumnName] = data.GuideName;
                                //        row[_dataSet.SalesDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                                //        row[_dataSet.SalesDetail.SectionGuideNameColumn.ColumnName] = data.SectionGuideNm;
                                //        row[_dataSet.SalesDetail.DtlNoteColumn.ColumnName] = this.GetValidityTerm(data.DtlNote); // ���ה��l���L���������Z�b�g
                                //        row[_dataSet.SalesDetail.ColorName1Column.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.TrimNameColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.MakerNameColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.CostColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = DBNull.Value;
                                //        if (data.AddUpADate != DateTime.MinValue)
                                //        {
                                //            row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                //        }
                                //        else
                                //        {
                                //            row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = DBNull.Value;
                                //        }
                                //        row[_dataSet.SalesDetail.AccRecDivCdColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = DBNull.Value;
                                //        if (data.DebitNoteDiv == 0)
                                //        {
                                //            row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "��";
                                //        }
                                //        else if (data.DebitNoteDiv == 1)
                                //        {
                                //            row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "��";
                                //        }
                                //        else if (data.DebitNoteDiv == 2)
                                //        {
                                //            row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "���E�ςݍ�";
                                //        }
                                //        else
                                //        {
                                //            row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                                //        }
                                //        row[_dataSet.SalesDetail.AddresseeCodeColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.AddresseeNameColumn.ColumnName] = DBNull.Value;
                                //        #endregion
                                //        this._dataSet.SalesDetail.Rows.Add(row);
                                //    }

                                //    if (data.DiscountDeposit > 0)
                                //    {
                                //        rowDetailNo++;
                                //        row = this._dataSet.SalesDetail.NewRow();
                                //        #region �萔���p���׍쐬
                                //        row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.RowNoColumn.ColumnName] = rowDetailNo;
                                //        row[_dataSet.SalesDetail.DataDivColumn.ColumnName] = data.DataDiv;
                                //        row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = data.SalesDate;
                                //        row[_dataSet.SalesDetail.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                                //        row[_dataSet.SalesDetail.SalesRowNoColumn.ColumnName] = 98;
                                //        row[_dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                                //        row[_dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                                //        row[_dataSet.SalesDetail.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                                //        row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "����";
                                //        row[_dataSet.SalesDetail.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                                //        row[_dataSet.SalesDetail.GoodsNameColumn.ColumnName] = "�l��";
                                //        row[_dataSet.SalesDetail.GoodsNoColumn.ColumnName] = data.GoodsNo;
                                //        if (data.BLGoodsCode == 0)
                                //        {
                                //            row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = DBNull.Value;
                                //        }
                                //        else
                                //        {
                                //            row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = data.BLGoodsCode.ToString().PadLeft(CT_DEPTH_BLGOODSCODE, '0');
                                //        }
                                //        row[_dataSet.SalesDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode;
                                //        row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.OpenPriceDivColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesUnitCostColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName] = data.DiscountDeposit;
                                //        row[_dataSet.SalesDetail.ConsTaxLayMethodColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.TotalCostColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.ModelFullNameColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.FullModelColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SlipNoteColumn.ColumnName] = data.SlipNote;
                                //        row[_dataSet.SalesDetail.SlipNote2Column.ColumnName] = data.SlipNote2;
                                //        row[_dataSet.SalesDetail.SlipNote3Column.ColumnName] = data.SlipNote3;
                                //        row[_dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                                //        row[_dataSet.SalesDetail.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                                //        row[_dataSet.SalesDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                                //        row[_dataSet.SalesDetail.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                                //        row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SupplierSnmColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.CarMngCodeColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.WarehouseCdColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.WarehouseNameColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.UOESupplierCdColumn] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.UOERemark1Column.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.UOERemark2Column.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.GuideNameColumn.ColumnName] = data.GuideName;
                                //        row[_dataSet.SalesDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                                //        row[_dataSet.SalesDetail.SectionGuideNameColumn.ColumnName] = data.SectionGuideNm;
                                //        row[_dataSet.SalesDetail.DtlNoteColumn.ColumnName] = this.GetValidityTerm(data.DtlNote); // ���ה��l���L���������Z�b�g
                                //        row[_dataSet.SalesDetail.ColorName1Column.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.TrimNameColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.MakerNameColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.CostColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = DBNull.Value;
                                //        if (data.AddUpADate != DateTime.MinValue)
                                //        {
                                //            row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                //        }
                                //        else
                                //        {
                                //            row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = DBNull.Value;
                                //        }
                                //        row[_dataSet.SalesDetail.AccRecDivCdColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = DBNull.Value;
                                //        if (data.DebitNoteDiv == 0)
                                //        {
                                //            row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "��";
                                //        }
                                //        else if (data.DebitNoteDiv == 1)
                                //        {
                                //            row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "��";
                                //        }
                                //        else if (data.DebitNoteDiv == 2)
                                //        {
                                //            row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "���E�ςݍ�";
                                //        }
                                //        else
                                //        {
                                //            row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                                //        }
                                //        row[_dataSet.SalesDetail.AddresseeCodeColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.AddresseeNameColumn.ColumnName] = DBNull.Value;
                                //        #endregion
                                //        this._dataSet.SalesDetail.Rows.Add(row);
                                //    }
                                //}
                                //// ---ADD 2009/02/14 �s��Ή�[11391] -----------------------------------------------------<<<<<
                                # endregion
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                                // �`�[�\���O���b�h�ւ̃Z�b�g
                                CustPrtPprSalTblRsltWork prevData = (CustPrtPprSalTblRsltWork)((custPrtPprSalTblRsltWorkObj as ArrayList)[index - 1]);
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                                CustPtrSalesDetailDataSet.SalesDetailDataTable table = this._dataSet.SalesDetail;
                                rowDetailNo = rowNo;
                                AddFeeAndDiscountRow( ref table, ref rowDetailNo, prevData );
                                rowNo = rowDetailNo;
                                //-----ADD 2010/12/20 ----->>>>>
                                prevData.AcptAnOdrStatusSrc = beAcptAnOdrStatusSrc;
                                prevData.HisDtlSlipNum = beHisDtlSlipNum;
                                //-----ADD 2010/12/20 -----<<<<<
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                                //RecordSetToSlipList(prevData, rowNo, salAmntConsTaxInclu, yeardiv);// ���� 2011/11/23 ADD // DEL 2015/02/05 ������
                                //RecordSetToSlipList( prevData, rowNo, salAmntConsTaxInclu );// ���� 2011/11/23 DEL
                                RecordSetToSlipList(prevData, rowNo, salAmntConsTaxInclu, yeardiv, 0);// ADD 2015/02/05 ������
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

                                //-----ADD 2010/12/20 ----->>>>>
                                beAcptAnOdrStatusSrc = data.AcptAnOdrStatusSrc;
                                beHisDtlSlipNum = data.HisDtlSlipNum;
                                //-----ADD 2010/12/20 -----<<<<<

                                rowNo = rowDetailNo;        //ADD 2009/02/14 �s��Ή�[11391]

                                // �`�[����+1
                                slipCount++;

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                                //// �`�[�ԍ�����ю󒍃X�e�[�^�X��ۑ�
                                //exAcptAnOdrStatus = data.AcptAnOdrStatus;
                                //exSlipNum = data.SalesSlipNum;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                                salAmntConsTaxInclu = 0; // �`�[�ʓ��ŋ��z�W�v�l��������
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 ADD
                                if ( _extractCancelFlag == true )
                                {
                                    // --- DEL 2020/12/21 �x���Ή� ---------->>>>>
                                    //cancelFlag = true;
                                    // --- DEL 2020/12/21 �x���Ή� ----------<<<<<

                                    exAcptAnOdrStatus = data.AcptAnOdrStatus;
                                    exSlipNum = data.SalesSlipNum;
                                    rowNo++;

                                    break;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 ADD

                            }
                            //-----ADD 2010/12/20 ----->>>>>
                            if (index == 0)
                            {                                 
                                beAcptAnOdrStatusSrc = data.AcptAnOdrStatusSrc;
                                beHisDtlSlipNum = data.HisDtlSlipNum;
                                
                            }
                            //-----ADD 2010/12/20 -----<<<<<
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                            // �`�[�ԍ�����ю󒍃X�e�[�^�X��ۑ�
                            exAcptAnOdrStatus = data.AcptAnOdrStatus;
                            exSlipNum = data.SalesSlipNum;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

                            #endregion // �`�[�\���f�[�^�e�[�u��

                            rowNo++;
                        }
                        // --- UPD 2020/12/21 �x���Ή� ---------->>>>>
                        //catch ( ConstraintException ex )
                        catch (ConstraintException)
                        // --- UPD 2020/12/21 �x���Ή� ----------<<<<<
                        {
                            //MessageBox.Show(ex.Message);
                        }
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 UPD
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                    //// �Ō�̓`�[�����Z�b�g
                    //if ( custPrtPprSalTblRsltWorkObj != null && (custPrtPprSalTblRsltWorkObj as ArrayList).Count > 0 )
                    //{
                    //    ArrayList retList = (ArrayList)custPrtPprSalTblRsltWorkObj;
                    //    CustPrtPprSalTblRsltWork data = (CustPrtPprSalTblRsltWork)retList[retList.Count - 1];

                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                    //    CustPtrSalesDetailDataSet.SalesDetailDataTable table = this._dataSet.SalesDetail;
                    //    rowDetailNo = rowNo;
                    //    AddFeeAndDiscountRow( ref table, ref rowDetailNo, data );
                    //    rowNo = rowDetailNo;
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD

                    //    // �`�[�\���O���b�h�ւ̃Z�b�g
                    //    RecordSetToSlipList( data, rowNo, salAmntConsTaxInclu );
                    //    // �`�[����+1
                    //    slipCount++;
                    //}
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

                    // �Ō�̓`�[�����Z�b�g
                    if ( custPrtPprSalTblRsltWorkObj != null && (custPrtPprSalTblRsltWorkObj as ArrayList).Count > 0 )
                    {
                        ArrayList retList = (ArrayList)custPrtPprSalTblRsltWorkObj;
                        CustPrtPprSalTblRsltWork data = (CustPrtPprSalTblRsltWork)retList[lastIndex];

                        CustPtrSalesDetailDataSet.SalesDetailDataTable table = this._dataSet.SalesDetail;
                        rowDetailNo = rowNo;
                        AddFeeAndDiscountRow( ref table, ref rowDetailNo, data );
                        rowNo = rowDetailNo;
                        //-----ADD 2010/12/20 ----->>>>>
                        data.AcptAnOdrStatusSrc = beAcptAnOdrStatusSrc;
                        data.HisDtlSlipNum = beHisDtlSlipNum;
                        //-----ADD 2010/12/20 -----<<<<<
                        // �`�[�\���O���b�h�ւ̃Z�b�g
                        //RecordSetToSlipList(data, rowNo, salAmntConsTaxInclu, yeardiv);// ���� 2011/11/23 ADD // DEL 2015/02/05 ������
                        //RecordSetToSlipList( prevData, rowNo, salAmntConsTaxInclu );// ���� 2011/11/23 DEL
                        RecordSetToSlipList(data, rowNo, salAmntConsTaxInclu, yeardiv, 0);// ADD 2015/02/05 ������
                        // �`�[����+1
                        slipCount++;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 UPD


                    // ---ADD 2009/02/14 �s��Ή�[11381] ------------------------------------------------>>>>>
                    // �����̂ݍs�ԍ��̔Ԃ��Ȃ���
                    DateTime exSalesDate = DateTime.MinValue;
                    rowDetailNo = 1;
                    exSlipNum = string.Empty;

                    string filter = string.Format( "{0} <> {1}", this._dataSet.SalesDetail.DataDivColumn.ColumnName, 0 );
                    string sort = string.Format( "{0}, {1}, {2}, {3}, {4}, {5}",
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                        //this._dataSet.SalesDetail.SalesDateColumn.ColumnName,
                        //this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName,
                        //this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName,
                        //this._dataSet.SalesDetail.DataDivColumn.ColumnName,
                        //this._dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName,
                        //this._dataSet.SalesDetail.SalesSlipCdColumn.ColumnName);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                                    this._dataSet.SalesDetail.SalesDateColumn.ColumnName,
                                    this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName,
                                    this._dataSet.SalesDetail.DataDivColumn.ColumnName,
                                    this._dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName,
                                    this._dataSet.SalesDetail.SalesSlipCdColumn.ColumnName,
                                    this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD

                    DataRow[] dataRows = this._dataSet.SalesDetail.Select( filter, sort );
                    DataRow dataRow = null;
                    for ( int i = 0; i <= dataRows.Length - 1; i++ )
                    {
                        dataRow = dataRows[i];

                        if ( (exSalesDate.Equals( dataRow[this._dataSet.SalesDetail.SalesDateColumn.ColumnName] ) == false) ||
                            (exSlipNum.Equals( dataRow[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName] ) == false) )
                        {
                            rowDetailNo = 1;
                        }

                        dataRow[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName] = rowDetailNo++;

                        exSalesDate = (DateTime)dataRow[this._dataSet.SalesDetail.SalesDateColumn.ColumnName];
                        exSlipNum = (string)dataRow[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName];
                    }
                    // ---ADD 2009/02/14 �s��Ή�[11381] ------------------------------------------------<<<<<

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                    # region // DEL
                    //// �c���\�����f�[�^�Z�b�g��
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 DEL
                    ////if ( this._dataSet.BalanceTotal.Rows.Count > 0 )
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 DEL
                    //{
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 DEL
                    //    //row3 = this._dataSet.BalanceTotal.Rows[0];
                    //    //row3[_dataSet.BalanceTotal.AfCalBlcColumn.ColumnName] = AfCalDemandPrice + totalThisSalesPrice + totalOfsThisSalesTax - totalThisTimeDmdNrml;
                    //    //row3[_dataSet.BalanceTotal.ThisSalesPriceTotalColumn.ColumnName] = totalThisSalesPrice;                     // ���񔄏�
                    //    //row3[_dataSet.BalanceTotal.OfsThisSalesTaxColumn.ColumnName] = totalOfsThisSalesTax;                        // �����
                    //    //row3[_dataSet.BalanceTotal.ThisTimeDmdNrmlColumn.ColumnName] = totalThisTimeDmdNrml;                        // �������
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 DEL
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 ADD
                    //    if ( this._dataSet.BalanceTotal.Rows.Count > 0 )
                    //    {
                    //        row3 = this._dataSet.BalanceTotal.Rows[0];
                    //    }
                    //    else
                    //    {
                    //        // ������΍s�ǉ�����i�Q�ƌ^�Ȃ̂ōs�ǉ���ɕҏW���Ă����f�����j
                    //        row3 = this._dataSet.BalanceTotal.NewRow();
                    //        row3[_dataSet.BalanceTotal.ExistsTotalColumn.ColumnName] = false;
                    //        row3[_dataSet.BalanceTotal.DmdStDayColumn.ColumnName] = DateTime.MinValue;
                    //        row3[_dataSet.BalanceTotal.TotalDayColumn.ColumnName] = DateTime.MinValue;
                    //        row3[_dataSet.BalanceTotal.IsParentColumn.ColumnName] = false;
                    //        this._dataSet.BalanceTotal.Rows.Add( row3 );
                    //    }
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 ADD

                    //    row3[_dataSet.BalanceTotal.StandardPrice_TotalColumn.ColumnName] = StandardPrice_Total;                     // �W�����i���v
                    //    row3[_dataSet.BalanceTotal.SoldAmount_TotalColumn.ColumnName] = SoldAmount_Total;                           // ������z���v
                    //    row3[_dataSet.BalanceTotal.Cost_TotalColumn.ColumnName] = Cost_Total;                                       // �������v
                    //    row3[_dataSet.BalanceTotal.GrossProfitAmount_TotalColumn.ColumnName] = GrossProfitAmount_Total;             // �e���z���v

                    //    if ( totalAmount > 0 )
                    //    {
                    //        row3[_dataSet.BalanceTotal.StandardPrice_AvgColumn.ColumnName] = StandardPrice_Total / totalAmount;         // �W�����i����
                    //        row3[_dataSet.BalanceTotal.SoldAmount_AvgColumn.ColumnName] = SoldAmount_Total / totalAmount;               // ������z����
                    //        row3[_dataSet.BalanceTotal.Cost_AvgColumn.ColumnName] = Cost_Total / totalAmount;                           // ��������
                    //        row3[_dataSet.BalanceTotal.GrossProfitAmount_AvgColumn.ColumnName] = GrossProfitAmount_Total / totalAmount; // �e���z����
                    //    }
                    //    else
                    //    {
                    //        row3[_dataSet.BalanceTotal.StandardPrice_AvgColumn.ColumnName] = 0;
                    //        row3[_dataSet.BalanceTotal.SoldAmount_AvgColumn.ColumnName] = 0;
                    //        row3[_dataSet.BalanceTotal.Cost_AvgColumn.ColumnName] = 0;
                    //        row3[_dataSet.BalanceTotal.GrossProfitAmount_AvgColumn.ColumnName] = 0;
                    //    }

                    //    if ( SoldAmount_Total > 0 )
                    //    {
                    //        row3[_dataSet.BalanceTotal.GrossProfitPercentageColumn.ColumnName] = GrossProfitAmount_Total / SoldAmount_Total * 100; // �e����
                    //    }
                    //    else
                    //    {
                    //        row3[_dataSet.BalanceTotal.GrossProfitPercentageColumn.ColumnName] = 0;
                    //    }
                    //    row3[_dataSet.BalanceTotal.SlipCountColumn.ColumnName] = slipCount;                                         // �`�[����
                    //    row3[_dataSet.BalanceTotal.DetailCountColumn.ColumnName] = detailSlipCount;                                 // ���א�
                    //    row3[_dataSet.BalanceTotal.AmountColumn.ColumnName] = totalAmount;                                          // ���ʌv
                    //    row3[_dataSet.BalanceTotal.ConsumeTaxAmountColumn.ColumnName] = totalConsumeTaxAmount;                      // ����Ōv
                    //    //row3[_dataSet.BalanceList.SectionCodeColumn.ColumnName] = 
                    //}
                    # endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                    // ���Ӑ斢���͂̂Ƃ�status=EOF�ŕԋp�����̂Ŗ��׊Y���f�[�^�������normal�ŕԂ�
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                else
                {
                    // �����[���Ȃ�΃����[�gstatus��0:����ł��Y���Ȃ��ŕԂ�
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                # region [�c���\��]
                // �c���\�����f�[�^�Z�b�g��
                {
                    if ( this._dataSet.BalanceTotal.Rows.Count > 0 )
                    {
                        row3 = this._dataSet.BalanceTotal.Rows[0];
                    }
                    else
                    {
                        // ������΍s�ǉ�����i�Q�ƌ^�Ȃ̂ōs�ǉ���ɕҏW���Ă����f�����j
                        row3 = this._dataSet.BalanceTotal.NewRow();
                        row3[_dataSet.BalanceTotal.ExistsTotalColumn.ColumnName] = false;
                        row3[_dataSet.BalanceTotal.DmdStDayColumn.ColumnName] = DateTime.MinValue;
                        row3[_dataSet.BalanceTotal.TotalDayColumn.ColumnName] = DateTime.MinValue;
                        row3[_dataSet.BalanceTotal.IsParentColumn.ColumnName] = false;
                        this._dataSet.BalanceTotal.Rows.Add( row3 );
                    }

                    row3[_dataSet.BalanceTotal.StandardPrice_TotalColumn.ColumnName] = StandardPrice_Total;                     // �W�����i���v
                    row3[_dataSet.BalanceTotal.SoldAmount_TotalColumn.ColumnName] = SoldAmount_Total;                           // ������z���v
                    row3[_dataSet.BalanceTotal.Cost_TotalColumn.ColumnName] = Cost_Total;                                       // �������v
                    row3[_dataSet.BalanceTotal.GrossProfitAmount_TotalColumn.ColumnName] = GrossProfitAmount_Total;             // �e���z���v

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                    //if ( totalAmount > 0 )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                    if ( totalAmount != 0 )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                    {
                        row3[_dataSet.BalanceTotal.StandardPrice_AvgColumn.ColumnName] = StandardPrice_Total / totalAmount;         // �W�����i����
                        row3[_dataSet.BalanceTotal.SoldAmount_AvgColumn.ColumnName] = SoldAmount_Total / totalAmount;               // ������z����
                        row3[_dataSet.BalanceTotal.Cost_AvgColumn.ColumnName] = Cost_Total / totalAmount;                           // ��������
                        row3[_dataSet.BalanceTotal.GrossProfitAmount_AvgColumn.ColumnName] = GrossProfitAmount_Total / totalAmount; // �e���z����
                    }
                    else
                    {
                        row3[_dataSet.BalanceTotal.StandardPrice_AvgColumn.ColumnName] = 0;
                        row3[_dataSet.BalanceTotal.SoldAmount_AvgColumn.ColumnName] = 0;
                        row3[_dataSet.BalanceTotal.Cost_AvgColumn.ColumnName] = 0;
                        row3[_dataSet.BalanceTotal.GrossProfitAmount_AvgColumn.ColumnName] = 0;
                    }

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                    //if ( SoldAmount_Total > 0 )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                    if ( SoldAmount_Total != 0 )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                    {
                        row3[_dataSet.BalanceTotal.GrossProfitPercentageColumn.ColumnName] = GrossProfitAmount_Total / SoldAmount_Total * 100; // �e����
                    }
                    else
                    {
                        row3[_dataSet.BalanceTotal.GrossProfitPercentageColumn.ColumnName] = 0;
                    }
                    row3[_dataSet.BalanceTotal.SlipCountColumn.ColumnName] = slipCount;                                         // �`�[����
                    row3[_dataSet.BalanceTotal.DetailCountColumn.ColumnName] = detailSlipCount;                                 // ���א�
                    row3[_dataSet.BalanceTotal.AmountColumn.ColumnName] = totalAmount;                                          // ���ʌv
                    row3[_dataSet.BalanceTotal.ConsumeTaxAmountColumn.ColumnName] = totalConsumeTaxAmount;                      // ����Ōv
                }
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
            }

            return status;
        }

        // ---- ADD K2015/06/09 �� �e�L�X�g�o�͍��ڂɑ�񔄉��ǉ���ǉ�����---->>>>>
        /// <summary>
        /// ��񔄉��擾
        /// </summary>
        /// <param name="data">���׃f�[�^</param>
        /// <returns>��񔄉�</returns>
        private double GetSecondPrice(CustPrtPprSalTblRsltWork data)
        {
            double secondPrice = 0;
            // �u.�v�ꍇ�̃t���O
            bool isRate = false;
            double resultPrice = 0;

            bool isValid = CustPrtSlipSearchAcs.CheckSecondPrice(data.ListPriceTaxExcFl.ToString(), data.DtlNote, ref secondPrice, ref isRate);

            if (isValid)
            {
                if (isRate)
                {
                    // �[�������R�[�h(0:������z, 1:�����, 2:����P��)
                    int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(LoginInfoAcquisition.EnterpriseCode, data.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);

                    // ����Œ[�������P�ʁA�敪�擾
                    int taxFracProcCd = 0;
                    double taxFracProcUnit = 0;

                    // �[�������P�ʁA�[�������敪�擾����
                    this.GetSalesFractionProcInfo(ctFracProcMoneyDiv_SalesUnitPrice, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

                    // �[������
                    FractionCalculate.FracCalcMoney(secondPrice, taxFracProcUnit, taxFracProcCd, out resultPrice);

                    // ������7�̏ꍇ�A����
                    if (resultPrice > 9999999)
                    {
                        secondPrice = data.ListPriceTaxExcFl;
                    }
                    else
                    {
                        secondPrice = resultPrice;
                    }
                }
            }
            else
            {
                secondPrice = data.ListPriceTaxExcFl;
            }

            return secondPrice;
        }
        // ---- ADD K2015/06/09 �� �e�L�X�g�o�͍��ڂɑ�񔄉��ǉ���ǉ�����----<<<<<

        // ---- ADD K2015/04/27 �� �����Z���i�̑�񔄉��ǉ� ---->>>>>
        /// <summary>
        /// ������z�����ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���Ӑ�d�q������񔄉���ǉ�����B</br>
        /// <br>Programmer	: ��</br>
        /// <br>Date		: K2015/05/07</br>
        /// <br>�Ǘ��ԍ�    : 11100842-00 �����Z���i���̌ʊJ���˗�</br>
        private void InitSalesProcMoney()
        {
            _salesProcMoneyAcs = new SalesProcMoneyAcs();
            CacheSalesProcMoney();
        }

        /// <summary>
        /// �[�������P�ʁA�[�������敪�擾����
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        /// <remarks>
        /// <br>Note		: ���Ӑ�d�q������񔄉���ǉ�����B</br>
        /// <br>Programmer	: ��</br>
        /// <br>Date		: K2015/05/07</br>
        /// <br>�Ǘ��ԍ�    : 11100842-00 �����Z���i���̌ʊJ���˗�</br>
        public void GetSalesFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            //-----------------------------------------------------------------------------
            // �����l
            //-----------------------------------------------------------------------------
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // �P����0.01�~�P��
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // �P���ȊO��1�~�P��
                    break;
            }
            fractionProcCd = 1;     // �؎̂�

            //-----------------------------------------------------------------------------
            // �R�[�h�Y�����R�[�h�擾
            //-----------------------------------------------------------------------------
            List<SalesProcMoney> salesProcMoneyList = this._salesProcMoneyList.FindAll(
                delegate(SalesProcMoney sProcMoney)
                {
                    if ((sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                        (sProcMoney.FractionProcCode == fractionProcCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            // �\�[�g�i������z�i�����j�j
            salesProcMoneyList.Sort(new SalesProcMoneyComparer());

            //-----------------------------------------------------------------------------
            // ������z�Y�����R�[�h�擾
            //-----------------------------------------------------------------------------
            SalesProcMoney salesProcMoney = salesProcMoneyList.Find(
                delegate(SalesProcMoney spm)
                {
                    if (spm.UpperLimitPrice >= targetPrice)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            // �߂�l�ݒ�
            if (salesProcMoney != null)
            {
                fractionProcUnit = salesProcMoney.FractionProcUnit;
                fractionProcCd = salesProcMoney.FractionProcCd;
            }
        }

        /// <summary>
        /// ������z�����敪�}�X�^��r�N���X(������z(����))
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���Ӑ�d�q������񔄉���ǉ�����B</br>
        /// <br>Programmer	: ��</br>
        /// <br>Date		: K2015/05/07</br>
        /// <br>�Ǘ��ԍ�    : 11100842-00 �����Z���i���̌ʊJ���˗�</br>
        private class SalesProcMoneyComparer : Comparer<SalesProcMoney>
        {
            public override int Compare(SalesProcMoney x, SalesProcMoney y)
            {
                int result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }

        /// <summary>
        /// �d�����z�����敪�}�X�^��r�N���X(������z(����))
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���Ӑ�d�q������񔄉���ǉ�����B</br>
        /// <br>Programmer	: ��</br>
        /// <br>Date		: K2015/05/07</br>
        /// <br>�Ǘ��ԍ�    : 11100842-00 �����Z���i���̌ʊJ���˗�</br>
        private class StockProcMoneyComparer : Comparer<StockProcMoney>
        {
            public override int Compare(StockProcMoney x, StockProcMoney y)
            {
                int result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }

        /// <summary>
        /// ������z�����敪�ݒ�}�X�^�L���b�V������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���Ӑ�d�q������񔄉���ǉ�����B</br>
        /// <br>Programmer	: ��</br>
        /// <br>Date		: K2015/05/07</br>
        /// <br>�Ǘ��ԍ�    : 11100842-00 �����Z���i���̌ʊJ���˗�</br>
        /// </remarks>
        private void CacheSalesProcMoney()
        {
            _salesProcMoneyList = null;
            ArrayList al = null;
            int status = this._salesProcMoneyAcs.Search(out al, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (al != null)
                {
                    _salesProcMoneyList = new List<SalesProcMoney>((SalesProcMoney[])al.ToArray(typeof(SalesProcMoney)));
                }
            }
        }
        // ---- ADD K2015/04/27 �� �����Z���i�̑�񔄉��ǉ� ----<<<<<

        #region �`�F�b�N���ה��l
        /// <summary>
        /// �����Z���i�̑�񔄉��ǉ�
        /// �`�F�b�N���ה��l�̕��@
        /// </summary>
        /// <param name="standardPrice">�W�����i</param>
        /// <param name="strNote">���ה��l</param>
        /// <param name="number">��񔄉��l</param>
        /// <param name="isRate">�u.�v�ꍇ�̃`�F�b�N true:�u.�v�ꍇ false:�u.�v�ꍇ�Ȃ�</param>
        /// <returns>�L�������̃`�F�b�N true:�L�� false:����</returns>
        /// <remarks>
        /// <br>Note		: ���Ӑ�d�q������񔄉���ǉ�����B</br>
        /// <br>Programmer	: ��</br>
        /// <br>Date		: K2015/04/29</br>
        /// <br>�Ǘ��ԍ�    : 11100842-00 �����Z���i���̌ʊJ���˗�</br>
        /// </remarks>
        public static bool CheckSecondPrice(string standardPrice, string strNote, ref double number,ref bool isRate)
        {
            //���Unicode����
            string firstChar = string.Empty;
            bool isNumber = false;
            int stdPrice;

            number = 0;
            if (!int.TryParse(standardPrice, out stdPrice))
            {
                return isNumber;
            }

            if (!string.IsNullOrEmpty(strNote))
            {
                // ���Unicode�������擾����
                firstChar = strNote.Substring(0, 1);

                switch (firstChar)
                {
                    case "\\":
                    case "/":
                        {
                            // ���������_�^�Ɛ����̃`�F�b�N
                            isNumber = CheckRateAndNumber(standardPrice, strNote, ref number,ref isRate);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            return isNumber;
        }

        /// <summary>
        /// ���������_�^�Ɛ����̃`�F�b�N
        /// </summary>
        /// <param name="standardPrice">�W�����i</param>
        /// <param name="strNote">���ה��l</param>
        /// <param name="number">��񔄉��l</param>
        /// <param name="isRate">�u.�v�ꍇ�̃`�F�b�N true:�u.�v�ꍇ false:�u.�v�ꍇ�Ȃ�</param>
        /// <returns>�L�����f true:�L�� false:����</returns>
        /// <remarks>
        /// <br>Note		: ���Ӑ�d�q������񔄉���ǉ�����B</br>
        /// <br>Programmer	: ��</br>
        /// <br>Date		: K2015/05/07</br>
        /// <br>�Ǘ��ԍ�    : 11100842-00 �����Z���i���̌ʊJ���˗�</br>
        /// </remarks>
        static bool CheckRateAndNumber(string standardPrice, string strNote, ref double number,ref bool isRate)
        {
            // ���Unicode����
            string secondChar = string.Empty;
            // �L�������̃`�F�b�N true:�L�� false:����
            bool isNumber = false;
            string tempNote = string.Empty;
            string tempPrice = string.Empty;

            number = 0;

            //// ���p�̃X�y�[�X�̑O�ɁA�������擾����
            //// �Ⴆ�A
            //// �@\14250 �݌�  => \14250
            //// �A\14250 �݌�  => /14250
            tempNote = strNote.Split(CHAR_SPACE)[0].ToString();

            //// �u\�v�Ɓu/�v�͐؂�̂Ă�
            //// �Ⴆ�A
            //// �@\14250  => 14250
            //// �A/14250  => 14250
            //// �B\1.20�@ => 1.20
            //// �C/1.20   => 1.20
            //// �D/-14250 => -14250
            tempPrice = tempNote.Remove(0, 1);

            // �u.�v�̏ꍇ
            if (tempNote.Contains(STR_DOT))
            {
                isRate = true;
                isNumber = CheckDot(tempPrice, standardPrice, ref number);
            }
            else// �����̏ꍇ
            {
                isRate = false;

                // ���z(\)�A�����ȓ��A�J���}�ʒu�s��
                // ,123456,7 = 1234567
                tempPrice = tempPrice.Replace(",", "");
                isNumber = CheckIntNumber(tempPrice, standardPrice, ref number);
            }

            return isNumber;
        }

        /// <summary>
        /// �`�F�D�N�u.�v�̏ꍇ
        /// </summary>
        /// <param name="stdPrice">����</param>
        /// <param name="standardPrice">�W�����i</param>
        /// <param name="number">��񔄉��l</param>
        /// <returns>�L�����f true:�L�� false:����</returns>
        /// <remarks>
        /// <br>Note		: ���Ӑ�d�q������񔄉���ǉ�����B</br>
        /// <br>Programmer	: ��</br>
        /// <br>Date		: K2015/05/07</br>
        /// <br>�Ǘ��ԍ�    : 11100842-00 �����Z���i���̌ʊJ���˗�</br>
        /// </remarks>
        static bool CheckDot(string scdPrice, string standardPrice, ref double number)
        {
            bool isNumber = false;
            //���������_�^
            double dblNumber = 0.0;
            bool isPersent = false;

            number = 0;

            //�u\.�v�̏ꍇ�A����
            if (scdPrice.Length == 1)
            {
                return isNumber;
            }

            //��u.�v�ȏ�̏ꍇ�A����
            if (scdPrice.Split(CHAR_DOT).Length == 2)
            {
                // �����t�H�[�}�b�g����������ƃ`�F�b�N
                isPersent = IsValidRateNumber(ref scdPrice,ref dblNumber);

                if (isPersent)
                {
                    // �����̃`�F�b�N
                    isNumber = CheckNumber(standardPrice, dblNumber, isPersent, ref number);
                }
                else
                {
                    // ����
                    return isNumber;
                }
            }
            else
            {
                // ����
                return isNumber;
            }
            return isNumber;
        }

        /// <summary>
        /// �����ꍇ�̏���
        /// </summary>
        /// <param name="stdPrice">����</param>
        /// <param name="standardPrice">�W�����i</param>
        /// <param name="number">��񔄉��l</param>
        /// <returns>�L�����f true:�L�� false:����</returns>
        /// <remarks>
        /// <br>Note		: ���Ӑ�d�q������񔄉���ǉ�����B</br>
        /// <br>Programmer	: ��</br>
        /// <br>Date		: K2015/05/07</br>
        /// <br>�Ǘ��ԍ�    : 11100842-00 �����Z���i���̌ʊJ���˗�</br>
        /// </remarks>
        static bool CheckIntNumber(string scdPrice, string standardPrice, ref double number)
        {
            bool isNumber = false;
            double dblNumber = 0;
            bool isPersent = false;

            // �@�����̑O�Ɂu+�v���́A�A��񔄉���0���߂̏ꍇ
            // �@\+123 => +
            // �A\0123 => 0 
            string secondChar = string.Empty;

            number = 0;

            if (double.TryParse(scdPrice, out dblNumber))
            {
                secondChar = scdPrice.Substring(0, 1);

                // ��񔄉���0���߂̏ꍇ
                // �Ⴆ�A
                // \0123 =>����
                if (dblNumber > 0)
                {
                    if (secondChar.Equals("0"))
                    {
                        return isNumber;
                    }
                }

                // �����̑O�Ɂu+�v����
                // �Ⴆ�A
                // \+123 => + (����)
                if (secondChar.Equals(STR_PURASU))
                {
                    isNumber = false;
                }
                else
                {
                    // ����<0�̏ꍇ�A����
                    if (dblNumber < 0)
                    {
                        return isNumber;
                    }

                    // �����̃`�F�b�N
                    isNumber = CheckNumber(standardPrice, dblNumber, isPersent, ref number);
                }
            }

            return isNumber;
        }

        /// <summary>
        /// �h�b�g�����̃`�F�b�N
        /// </summary>
        /// <param name="secondPrice">�ŏ��̕���</param>
        /// <returns>�L�����f true:�L�� false:����</returns>
        /// <remarks>
        /// <br>Note		: ���Ӑ�d�q������񔄉���ǉ�����B</br>
        /// <br>Programmer	: ��</br>
        /// <br>Date		: K2015/05/07</br>
        /// <br>�Ǘ��ԍ�    : 11100842-00 �����Z���i���̌ʊJ���˗�</br>
        /// </remarks>
        static bool IsValidRateNumber(ref string secondPrice, ref double dblNumber)
        {
            string secondChar = string.Empty;
            char lastChar = secondPrice[secondPrice.Length - 1];
            bool isValit = false;
            secondChar = secondPrice.Substring(0, 1);
            // �Ō�Unicode������.�̏ꍇ
            // �Ⴆ�A
            // �@1. => ����
            // �A+1.0 => ����
            if (lastChar.ToString().Equals(STR_DOT) || secondChar.Equals(STR_PURASU))
            {
                return isValit;
            }
            else// �L���̏ꍇ
            {
                // ���Unicode������.�̏ꍇ�A�t�H�[�}�b�g���C������
                // �Ⴆ�A
                // �@.250 => 0.250
                if (secondChar.Equals(STR_DOT))
                {
                    secondPrice = "0" + secondPrice;
                }

                if (double.TryParse(secondPrice, out dblNumber))
                {
                    isValit = true;
                }
                else
                {
                    isValit = false;
                }
            }

            return isValit;
        }

        /// <summary>
        /// �����̃`�F�b�N
        /// </summary>
        /// <param name="standardPrice">�W�����i</param>
        /// <param name="dblNumber">����</param>
        /// <param name="isPersent">���������_�^�̔��f</param>
        /// <param name="number">��񔄉��l</param>
        /// <returns>�L�����f true:�L�� false:����</returns>
        /// <remarks>
        /// <br>Note		: ���Ӑ�d�q������񔄉���ǉ�����B</br>
        /// <br>Programmer	: ��</br>
        /// <br>Date		: K2015/05/07</br>
        /// <br>�Ǘ��ԍ�    : 11100842-00 �����Z���i���̌ʊJ���˗�</br>
        /// </remarks>
        static bool CheckNumber(string standardPrice, double dblNumber, bool isPersent, ref double number)
        {
            // ��񔄉�
            double secondPrice = 0;
            // �ŏ��̔�����
            // ��񔄉�����0�̏ꍇ�A0%�@�Ƃ��Ĉ󎚂��Ă��܂�
            double minPercent = 0.00;
            // �ő�̔�����
            double maxPercent = 9.99;
            // �W�����i
            double stdPrice;
            // �L�������̃`�F�b�N true:�L�� false:����
            bool isNumber = false;

            number = 0;
            //�@�_�u.�v�̏ꍇ
            if (isPersent)
            {
                // �ŏ��̔���������ő�̔������܂ŁA�L��
                if (dblNumber >= minPercent && dblNumber <= maxPercent)
                {
                    double.TryParse(standardPrice, out stdPrice);
                    // ���������_�^�̏��������͐؂�̂Ă�
                    // 0.996 => 0.99
                    dblNumber = Math.Truncate(dblNumber * 100) / 100;

                    secondPrice = stdPrice * dblNumber;
                    if (double.TryParse(secondPrice.ToString(), out number))
                    {
                        isNumber = true;
                    }
                    else
                    {
                        number = 0;
                        isNumber = false;
                    }
                }
            }
            else//�����̏ꍇ
            {
                // ������7�̏ꍇ�A����
                if (dblNumber <= 9999999)
                {
                    secondPrice = int.Parse(dblNumber.ToString());
                    number = secondPrice;
                    isNumber = true;
                }
            }

            return isNumber;
        }
        #endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
        /// <summary>
        /// �����敪���̎擾
        /// </summary>
        /// <param name="historyDiv"></param>
        /// <returns></returns>
        private string GetHistoryDivName( int historyDiv )
        {
            switch ( historyDiv )
            {
                default:
                case 0:
                    return string.Empty;
                case 1:
                    return "����";
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
        /// <summary>
        /// �`�[���s�����擾
        /// </summary>
        /// <param name="updateDateTime"></param>
        /// <returns></returns>
        private string GetSlipPrintTimeText( long updateDateTime )
        {
            if ( updateDateTime != 0 )
            {
                DateTime dt = new DateTime( updateDateTime );
                return dt.ToString( "HH:mm:ss" );
            }
            else
            {
                return string.Empty;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="rowDetailNo"></param>
        /// <param name="data"></param>
        /// <br>Update Note : K2015/06/16 鸏�</br>
        /// <br>�Ǘ��ԍ�    : 11101427-00</br>
        /// <br>            : ���C�S�����Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����B</br>
        private void AddFeeAndDiscountRow( ref CustPtrSalesDetailDataSet.SalesDetailDataTable table, ref int rowDetailNo, CustPrtPprSalTblRsltWork data )
        {
            DataRow row;

            // ---ADD 2009/02/14 �s��Ή�[11391] ----------------------------------------------------->>>>>
            //rowDetailNo = rowNo;
            if ( data.DataDiv != 0 )
            {
                // �萔�����גǉ�
                // ---------- UPD 2012/12/14 Y.Wakita ---------->>>>>
                //if (data.FeeDeposit > 0)
                if (data.FeeDeposit != 0)
                // ---------- UPD 2012/12/14 Y.Wakita ----------<<<<<
                {
                    rowDetailNo++;
                    //row = this._dataSet.SalesDetail.NewRow();
                    row = table.NewRow();
                    #region �萔���p���׍쐬
                    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.RowNoColumn.ColumnName] = rowDetailNo;
                    row[_dataSet.SalesDetail.DataDivColumn.ColumnName] = data.DataDiv;
                    row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = data.SalesDate;
                    row[_dataSet.SalesDetail.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                    row[_dataSet.SalesDetail.SalesRowNoColumn.ColumnName] = 98;
                    row[_dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                    row[_dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                    row[_dataSet.SalesDetail.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                    row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "����";
                    row[_dataSet.SalesDetail.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                    row[_dataSet.SalesDetail.GoodsNameColumn.ColumnName] = "�萔��";
                    row[_dataSet.SalesDetail.GoodsNoColumn.ColumnName] = data.GoodsNo;
                    row[_dataSet.SalesDetail.ChangeGoodsNoColumn.ColumnName] = data.ChangeGoodsNo; //ADD �i�N 2014/12/28 �ϊ���i�Ԃ̒ǉ��Ή�
                    if ( data.BLGoodsCode == 0 )
                    {
                        row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = DBNull.Value;
                    }
                    else
                    {
                        row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = data.BLGoodsCode.ToString().PadLeft( CT_DEPTH_BLGOODSCODE, '0' );
                    }
                    row[_dataSet.SalesDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode;
                    row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.OpenPriceDivColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesUnitCostColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName] = data.FeeDeposit;
                    row[_dataSet.SalesDetail.ConsTaxLayMethodColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                    row[_dataSet.SalesDetail.TotalCostColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.ModelFullNameColumn.ColumnName] = DBNull.Value;
                    // --- ADD m.suzuki 2010/04/02 ---------->>>>>
                    row[_dataSet.SalesDetail.ModelHalfNameColumn.ColumnName] = DBNull.Value;
                    // --- ADD m.suzuki 2010/04/02 ----------<<<<<
                    row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.FullModelColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SlipNoteColumn.ColumnName] = data.SlipNote;
                    row[_dataSet.SalesDetail.SlipNote2Column.ColumnName] = data.SlipNote2;
                    row[_dataSet.SalesDetail.SlipNote3Column.ColumnName] = data.SlipNote3;
                    row[_dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                    row[_dataSet.SalesDetail.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                    row[_dataSet.SalesDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                    row[_dataSet.SalesDetail.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                    row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SupplierSnmColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.CarMngCodeColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.WarehouseCdColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.WarehouseNameColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                    //row[_dataSet.SalesDetail.UOESupplierCdColumn] = DBNull.Value; // DEL 2015/02/05 ������
                    row[_dataSet.SalesDetail.UOESupplierCdColumn.ColumnName] = DBNull.Value; // ADD 2015/02/05 ������ // .ColumnName�̒ǉ�
                    row[_dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.UOERemark1Column.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.UOERemark2Column.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.GuideNameColumn.ColumnName] = data.GuideName;
                    row[_dataSet.SalesDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                    row[_dataSet.SalesDetail.SectionGuideNameColumn.ColumnName] = data.SectionGuideNm;
                    row[_dataSet.SalesDetail.DtlNoteColumn.ColumnName] = this.GetValidityTerm( data.DtlNote ); // ���ה��l���L���������Z�b�g
                    row[_dataSet.SalesDetail.ColorName1Column.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.TrimNameColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.MakerNameColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.CostColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = DBNull.Value;
                    if ( data.AddUpADate != DateTime.MinValue )
                    {
                        row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = data.AddUpADate;
                    }
                    else
                    {
                        row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = DBNull.Value;
                    }
                    row[_dataSet.SalesDetail.AccRecDivCdColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = DBNull.Value;
                    if ( data.DebitNoteDiv == 0 )
                    {
                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "��";
                    }
                    else if ( data.DebitNoteDiv == 1 )
                    {
                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "��";
                    }
                    else if ( data.DebitNoteDiv == 2 )
                    {
                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "���E�ςݍ�";
                    }
                    else
                    {
                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                    }
                    row[_dataSet.SalesDetail.AddresseeCodeColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.AddresseeNameColumn.ColumnName] = DBNull.Value;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/18 ADD
                    // ���͓�
                    if ( data.InputDay != DateTime.MinValue )
                    {
                        row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = data.InputDay;
                    }
                    else
                    {
                        row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = DBNull.Value;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/18 ADD

                    //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
                    if (this._opt_Meigo == Convert.ToInt32(Option.ON))
                    {
                        row[_dataSet.SalesDetail.SalesAreaNameColumn.ColumnName] = data.SalesAreaName;
                        if (data.CustAnalysCode1 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode1Column.ColumnName] = data.CustAnalysCode1;
                        }
                        if (data.CustAnalysCode2 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode2Column.ColumnName] = data.CustAnalysCode2;
                        }
                        if (data.CustAnalysCode3 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode3Column.ColumnName] = data.CustAnalysCode3;
                        }
                        if (data.CustAnalysCode4 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode4Column.ColumnName] = data.CustAnalysCode4;
                        }
                        if (data.CustAnalysCode5 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode5Column.ColumnName] = data.CustAnalysCode5;
                        }
                        if (data.CustAnalysCode6 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode6Column.ColumnName] = data.CustAnalysCode6;
                        }
                    }
                    //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<

                    #endregion
                    //this._dataSet.SalesDetail.Rows.Add( row );
                    table.Rows.Add( row );
                }

                // ---------- UPD 2012/12/14 Y.Wakita ---------->>>>>
                //if ( data.DiscountDeposit > 0 )
                if (data.DiscountDeposit != 0)
                // ---------- UPD 2012/12/14 Y.Wakita ----------<<<<<
                {
                    rowDetailNo++;
                    //row = this._dataSet.SalesDetail.NewRow();
                    row = table.NewRow();
                    #region �l���p���׍쐬
                    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.RowNoColumn.ColumnName] = rowDetailNo;
                    row[_dataSet.SalesDetail.DataDivColumn.ColumnName] = data.DataDiv;
                    row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = data.SalesDate;
                    row[_dataSet.SalesDetail.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                    row[_dataSet.SalesDetail.SalesRowNoColumn.ColumnName] = 98;
                    row[_dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                    row[_dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                    row[_dataSet.SalesDetail.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                    row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "����";
                    row[_dataSet.SalesDetail.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                    row[_dataSet.SalesDetail.GoodsNameColumn.ColumnName] = "�l��";
                    row[_dataSet.SalesDetail.GoodsNoColumn.ColumnName] = data.GoodsNo;
                    row[_dataSet.SalesDetail.ChangeGoodsNoColumn.ColumnName] = data.ChangeGoodsNo; //ADD �i�N 2014/12/28 �ϊ���i�Ԃ̒ǉ��Ή�
                    if ( data.BLGoodsCode == 0 )
                    {
                        row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = DBNull.Value;
                    }
                    else
                    {
                        row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = data.BLGoodsCode.ToString().PadLeft( CT_DEPTH_BLGOODSCODE, '0' );
                    }
                    row[_dataSet.SalesDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode;
                    row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.OpenPriceDivColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesUnitCostColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName] = data.DiscountDeposit;
                    row[_dataSet.SalesDetail.ConsTaxLayMethodColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                    row[_dataSet.SalesDetail.TotalCostColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.ModelFullNameColumn.ColumnName] = DBNull.Value;
                    // --- ADD m.suzuki 2010/04/02 ---------->>>>>
                    row[_dataSet.SalesDetail.ModelHalfNameColumn.ColumnName] = DBNull.Value;
                    // --- ADD m.suzuki 2010/04/02 ----------<<<<<
                    row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.FullModelColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SlipNoteColumn.ColumnName] = data.SlipNote;
                    row[_dataSet.SalesDetail.SlipNote2Column.ColumnName] = data.SlipNote2;
                    row[_dataSet.SalesDetail.SlipNote3Column.ColumnName] = data.SlipNote3;
                    row[_dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                    row[_dataSet.SalesDetail.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                    row[_dataSet.SalesDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                    row[_dataSet.SalesDetail.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                    row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SupplierSnmColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.CarMngCodeColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.WarehouseCdColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.WarehouseNameColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                    //row[_dataSet.SalesDetail.UOESupplierCdColumn] = DBNull.Value; // DEL 2015/02/05 ������
                    row[_dataSet.SalesDetail.UOESupplierCdColumn.ColumnName] = DBNull.Value; // ADD 2015/02/05 ������ // .ColumnName�̒ǉ�
                    row[_dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.UOERemark1Column.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.UOERemark2Column.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.GuideNameColumn.ColumnName] = data.GuideName;
                    row[_dataSet.SalesDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                    row[_dataSet.SalesDetail.SectionGuideNameColumn.ColumnName] = data.SectionGuideNm;
                    row[_dataSet.SalesDetail.DtlNoteColumn.ColumnName] = this.GetValidityTerm( data.DtlNote ); // ���ה��l���L���������Z�b�g
                    row[_dataSet.SalesDetail.ColorName1Column.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.TrimNameColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.MakerNameColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.CostColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = DBNull.Value;
                    if ( data.AddUpADate != DateTime.MinValue )
                    {
                        row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = data.AddUpADate;
                    }
                    else
                    {
                        row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = DBNull.Value;
                    }
                    row[_dataSet.SalesDetail.AccRecDivCdColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = DBNull.Value;
                    if ( data.DebitNoteDiv == 0 )
                    {
                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "��";
                    }
                    else if ( data.DebitNoteDiv == 1 )
                    {
                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "��";
                    }
                    else if ( data.DebitNoteDiv == 2 )
                    {
                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "���E�ςݍ�";
                    }
                    else
                    {
                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                    }
                    row[_dataSet.SalesDetail.AddresseeCodeColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.AddresseeNameColumn.ColumnName] = DBNull.Value;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                    row[_dataSet.SalesDetail.SalesSlipCdDtlColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesSlipCdDtlNameColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.GoodsLGroupColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.GoodsLGroupNameColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.GoodsMGroupColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.GoodsMGroupNameColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.GoodsKindCodeColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.GoodsKindCodeNameColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.WarehouseShelfNoColumn.ColumnName] = DBNull.Value;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/18 ADD
                    // ���͓�
                    if ( data.InputDay != DateTime.MinValue )
                    {
                        row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = data.InputDay;
                    }
                    else
                    {
                        row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = DBNull.Value;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/18 ADD

                    //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
                    if (this._opt_Meigo == Convert.ToInt32(Option.ON))
                    {
                        row[_dataSet.SalesDetail.SalesAreaNameColumn.ColumnName] = data.SalesAreaName;
                        if (data.CustAnalysCode1 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode1Column.ColumnName] = data.CustAnalysCode1;
                        }
                        if (data.CustAnalysCode2 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode2Column.ColumnName] = data.CustAnalysCode2;
                        }
                        if (data.CustAnalysCode3 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode3Column.ColumnName] = data.CustAnalysCode3;
                        }
                        if (data.CustAnalysCode4 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode4Column.ColumnName] = data.CustAnalysCode4;
                        }
                        if (data.CustAnalysCode5 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode5Column.ColumnName] = data.CustAnalysCode5;
                        }
                        if (data.CustAnalysCode6 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode6Column.ColumnName] = data.CustAnalysCode6;
                        }
                    }
                    //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<

                    #endregion
                    //this._dataSet.SalesDetail.Rows.Add( row );
                    table.Rows.Add( row );
                }
            }
            // ---ADD 2009/02/14 �s��Ή�[11391] -----------------------------------------------------<<<<<
        }

        /// <summary>
        /// �`�[�ԍ��t�H�[�}�b�g�Ή�
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>������`�[�ԍ�(string)�Ɠ����`�[�ԍ�(int)�����݂��Ă���̂Ō`����ݒ肷��</remarks>
        private string GetSlipNum( CustPrtPprSalTblRsltWork data )
        {
            string slipNum = data.SalesSlipNum;
            try
            {
                int slipNumInt = Int32.Parse( slipNum );
                slipNum = slipNumInt.ToString( new string( '0', 9 ) );
            }
            catch
            {
                // int�ɕϊ��ł��Ȃ������ꍇ�͂��̂܂܂�string�ŕԂ�
            }
            return slipNum;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD

		// ------------ADD wangf 2013/01/30 FOR Redmine#34513--------->>>>
		/// <summary>
		/// �c���Ɖ�o�i�O���p�j
		/// </summary>
		/// <param name="suppPrtPprBlDspRsltWorkObj">�c���Ɖ�X�g</param>
		/// <param name="remainDataEx">�����o�����</param>
		/// <param name="custPrtPpr">��������</param>
		/// <returns>�t���O</returns>
		/// <remarks>
		/// <br>Note		: �c���W�v�������s���B</br>
		/// <br>Programmer	: wangf</br>
		/// <br>Date		: 2012/01/30</br>
		/// </remarks>
		public int SearchBalanceResult(CustPrtPpr custPrtPpr)
		{
			DataRow row3;
			long AfCalDemandPrice = 0;            // �O��c��
			// �c���Ɖ�ɕ\������̂łP���̂�
			CustPrtPprBlDspRsltWork custPrtPprBlDspRsltWork = new CustPrtPprBlDspRsltWork();
			object custPrtPprBlDspRsltWorkObj = (object)custPrtPprBlDspRsltWork;
			RemainDataExtra remainDataExtra = new RemainDataExtra();

			// �������s
			int blDspRsltStatus = SearchBlDspRslt(ref custPrtPprBlDspRsltWorkObj, ref remainDataExtra, custPrtPpr);
			if (blDspRsltStatus == (int)ConstantManagement.DB_Status.ctDB_ERROR)
			{
				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			//-------------------
			// �c���\��
			//-------------------
			# region [�c���\��]
			// �c���\�����ꌏ�œ���ł��Ȃ������ꍇ�͕\�����Ȃ�
			// ���Ӑ悪���݂��Ȃ��ꍇ���\�����Ȃ�
			ArrayList al = (ArrayList)custPrtPprBlDspRsltWorkObj;
			if (al.Count == 1 || !_customerPointed)
			{
				foreach (CustPrtPprBlDspRsltWork remainData in (ArrayList)custPrtPprBlDspRsltWorkObj)
				{
                    if (this._dataSet.BalanceTotal.Count == 1)
                    {
                        row3 = this._dataSet.BalanceTotal.Rows[0];
                    }
                    else
                    {
                        row3 = this._dataSet.BalanceTotal.NewRow();
                        this._dataSet.BalanceTotal.Rows.Add(row3);
                    }
					row3[_dataSet.BalanceTotal.AcpOdrTtl2TmBfBlDmdColumn.ColumnName] = remainData.AcpOdrTtl2TmBfBlDmd;  // �O�X�X��c��
					row3[_dataSet.BalanceTotal.LastTimeDemandColumn.ColumnName] = remainData.LastTimeDemand;            // �O�X��c��
					row3[_dataSet.BalanceTotal.AfCalDemandPriceColumn.ColumnName] = remainData.AfCalDemandPrice;        // �O��c��
					AfCalDemandPrice = remainData.AfCalDemandPrice;
					row3[_dataSet.BalanceTotal.AddUpYearMonthColumn.ColumnName] = remainData.AddUpYearMonth;            // �����N��
					row3[_dataSet.BalanceTotal.ConsTaxLayMethodColumn.ColumnName] = remainData.ConsTaxLayMethod;        // ����œ]�ŕ���
					// �������z
					row3[_dataSet.BalanceTotal.AfCalBlcColumn.ColumnName] = remainDataExtra.AfCalBlc;
					// ���񔄏�
					row3[_dataSet.BalanceTotal.ThisSalesPriceTotalColumn.ColumnName] = remainDataExtra.OfsThisTimeSales;
					// �����
					row3[_dataSet.BalanceTotal.OfsThisSalesTaxColumn.ColumnName] = remainDataExtra.OfsThisSalesTax;
					// �������
					row3[_dataSet.BalanceTotal.ThisTimeDmdNrmlColumn.ColumnName] = remainDataExtra.ThisTimeDmdNrml;
					// ���J�n��
					row3[_dataSet.BalanceTotal.DmdStDayColumn.ColumnName] = remainDataExtra.DmdStDay;
					// ��������
					row3[_dataSet.BalanceTotal.TotalDayColumn.ColumnName] = remainDataExtra.TotalDay;
					// �e�t���O
					row3[_dataSet.BalanceTotal.IsParentColumn.ColumnName] = remainDataExtra.IsParent;
					// �f�[�^���݃t���O
					row3[_dataSet.BalanceTotal.ExistsTotalColumn.ColumnName] = true;
				}
			}
			# endregion
			// �c���\�����ꌏ�œ���ł��Ȃ������ꍇ�͕\�����Ȃ�
			// ���Ӑ悪���݂��Ȃ��ꍇ���\�����Ȃ�
			if (this._dataSet.BalanceTotal.Rows.Count == 1)
			{
				blDspRsltStatus = 0;
			}
			else
			{
				blDspRsltStatus = 1;
			}
			return blDspRsltStatus;
		}
		// ------------ADD wangf 2013/01/30 FOR Redmine#34513---------<<<<
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 ADD
        /// <summary>
        /// �c���Ɖ�o
        /// </summary>
        /// <param name="suppPrtPprBlDspRsltWorkObj"></param>
        /// <param name="remainData"></param>
        /// <param name="suppPrtPpr"></param>
        /// <remarks>���������X�V�����[�g���g�p���܂�</remarks>
        /// <br>Update Note: 2012/11/15 yangmj</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 20130116�z�M��</br>
        /// <br>             Redmine#33269�@��������̈���̑Ή�</br>
        private int SearchBlDspRslt( ref object suppPrtPprBlDspRsltWorkObj, ref RemainDataExtra remainDataEx, CustPrtPpr custPrtPpr )
        {
            suppPrtPprBlDspRsltWorkObj = new ArrayList();
            CustDmdPrcWork paraWork = new CustDmdPrcWork();

            string resultSectCd = string.Empty;
            string addUpSecCode = string.Empty;
            int customerCode = 0;
            int claimCode = 0;

            // ADD 2012/06/19 lanl for Redmine#30529 --->>>>>
            CustomerInfo customer = null;
            CustomerInputAcs customerInputAcs = new CustomerInputAcs();
            // ADD 2012/06/19 lanl for Remine#30529  ---<<<<<
            # region [�����Z�b�g]

            paraWork.EnterpriseCode = custPrtPpr.EnterpriseCode; // ��ƃR�[�h

            //----- DEL YANGMJ 2012/11/15 for redmine#33269 ----->>>>>
            ////-----------------------------------------------------------
            //// ���_���͔���
            ////-----------------------------------------------------------
            //if ( custPrtPpr.SectionCode == null || custPrtPpr.SectionCode.Length == 0 )
            //{
            //    // 00:�S�ЂȂ�Ε\�����Ȃ�
            //    return (int)ConstantManagement.DB_Status.ctDB_EOF;
            //}
            //string sectionCode = custPrtPpr.SectionCode[0].Trim();
            //----- DEL YANGMJ 2012/11/15 for redmine#33269 -----<<<<<
            //----- ADD YANGMJ 2012/11/15 for redmine#33269 ----->>>>>
            // ���͋��_�ݒ�
            string sectionCode = string.Empty;
            if (custPrtPpr.SectionCode != null)
            {
                sectionCode = custPrtPpr.SectionCode[0].Trim();
            }
            //----- ADD YANGMJ 2012/11/15 for redmine#33269 -----<<<<<

            // --- UPD m.suzuki 2010/07/21 ---------->>>>>
            //paraWork.AddUpSecCode = sectionCode; // ���_�R�[�h
            paraWork.ResultsSectCd = sectionCode; // ���_�R�[�h
            // --- UPD m.suzuki 2010/07/21 ----------<<<<<

            //----- DEL YANGMJ 2012/11/15 for redmine#33269 ----->>>>>
            //if ( sectionCode == "00" ||
            //    string.IsNullOrEmpty( sectionCode ) )
            //{
            //    // 00:�S�ЂȂ�Ε\�����Ȃ�
            //    return (int)ConstantManagement.DB_Status.ctDB_EOF;
            //}
            //----- DEL YANGMJ 2012/11/15 for redmine#33269 -----<<<<<

            //-----------------------------------------------------------
            // ���Ӑ�E��������͔���
            //-----------------------------------------------------------

            if ( custPrtPpr.CustomerCode != 0 )
            {
                // ���Ӑ�ǂݍ���
                //CustomerInfo customer;//DEL 2012/06/19 lanl for Redmine#30529
                int readStatus = _customerInfoAcs.ReadDBData( ConstantManagement.LogicalMode.GetData0, custPrtPpr.EnterpriseCode, custPrtPpr.CustomerCode, true, false, out customer );
                if ( readStatus != 0 || customer == null || customer.LogicalDeleteCode != 0 )
                {
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
                //----- ADD YANGMJ 2012/11/15 for redmine#33269 ----->>>>>
                // �q���Ӑ�̏ꍇ�A�������Ȃ�
                if (customer.ClaimCode != custPrtPpr.CustomerCode)
                {
                    // �q���Ӑ�Ȃ�Ε\�����Ȃ�
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
                // �e���Ӑ�̏ꍇ�A�������_ != �������_���A�������Ȃ�
                if (customer.ClaimCode == custPrtPpr.CustomerCode && (!string.IsNullOrEmpty(sectionCode)) && (!sectionCode.Equals(customer.ClaimSectionCode.Trim())))
                {
                    // �\�����Ȃ�
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }

                if (string.IsNullOrEmpty(sectionCode))
                {
                    //���_���S�Ђ̏ꍇ�́A���Ӑ�}�X�^�̐������_���g�p����
                    sectionCode = customer.ClaimSectionCode.Trim();
                    paraWork.ResultsSectCd = sectionCode; // ���_�R�[�h
                }
                //----- ADD YANGMJ 2012/11/15 for redmine#33269 -----<<<<<
                if ( custPrtPpr.ClaimCode != 0 )
                {
                    //----------------------------------------------
                    // ���Ӑ�{������
                    //----------------------------------------------

                    // �e�q�֌W����
                    if ( customer.ClaimCode == custPrtPpr.ClaimCode && customer.ClaimSectionCode.Trim() == sectionCode )
                    {
                        paraWork.CustomerCode = custPrtPpr.ClaimCode; // ���Ӑ�R�[�h��������R�[�h
                        paraWork.ClaimCode = customer.ClaimCode;
                        paraWork.ResultsSectCd = "00";
                        paraWork.AddUpSecCode = sectionCode;

                        customerCode = 0;
                        claimCode = customer.ClaimCode;
                        resultSectCd = "00";
                        addUpSecCode = sectionCode;
                    }
                    else
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                }
                else
                {
                    //----------------------------------------------
                    // ���Ӑ�̂�
                    //----------------------------------------------
                    paraWork.CustomerCode = customer.CustomerCode; // ���Ӑ�R�[�h�����Ӑ�R�[�h
                    paraWork.ClaimCode = customer.ClaimCode;
                    // --- UPD m.suzuki 2010/07/21 ---------->>>>>
                    //paraWork.ResultsSectCd = customer.ClaimSectionCode;
                    //paraWork.AddUpSecCode = sectionCode;
                    paraWork.ResultsSectCd = sectionCode;
                    paraWork.AddUpSecCode = customer.ClaimSectionCode; 
                    // --- UPD m.suzuki 2010/07/21 ----------<<<<<

                    customerCode = customer.CustomerCode;
                    claimCode = customer.ClaimCode;
                    // --- UPD m.suzuki 2010/07/21 ---------->>>>>
                    //resultSectCd = customer.ClaimSectionCode;
                    //addUpSecCode = sectionCode;
                    resultSectCd = sectionCode;
                    addUpSecCode = customer.ClaimSectionCode; 
                    // --- UPD m.suzuki 2010/07/21 ----------<<<<<
                }
            }
            else
            {
                if ( custPrtPpr.ClaimCode != 0 )
                {
                    //----------------------------------------------
                    // ������̂�
                    //----------------------------------------------

                    // ������ǂݍ���
                    CustomerInfo claim;
                    int readStatus = _customerInfoAcs.ReadDBData( ConstantManagement.LogicalMode.GetData0, custPrtPpr.EnterpriseCode, custPrtPpr.ClaimCode, true, false, out claim );
                    if ( readStatus != 0 || claim == null || claim.LogicalDeleteCode != 0 )
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }

                    // �e�q����
                    if ( claim.ClaimCode == claim.CustomerCode && claim.ClaimSectionCode.Trim() == sectionCode )
                    {
                        paraWork.CustomerCode = custPrtPpr.ClaimCode; // ���Ӑ�R�[�h��������R�[�h
                        paraWork.ClaimCode = claim.CustomerCode;
                        paraWork.ResultsSectCd = "00";
                        paraWork.AddUpSecCode = sectionCode;

                        customerCode = 0;
                        claimCode = claim.CustomerCode;
                        resultSectCd = "00";
                        addUpSecCode = sectionCode;
                    }
                    else
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                }
                else
                {
                    //----------------------------------------------
                    // (�����Ƃ����͂Ȃ�)
                    //----------------------------------------------
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
            }

            // ��ʏI����
            paraWork.AddUpDate = custPrtPpr.Ed_SalesDate;

            # endregion

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            suppPrtPprBlDspRsltWorkObj = null;

            # region [���ς݁F���Ӑ搿�����z�}�X�^]
            //-----------------------------------------------
            // ���ς݁F���Ӑ搿�����z�}�X�^
            //-----------------------------------------------
            object retObj;

            addUpSecCode = addUpSecCode.Trim();
            resultSectCd = resultSectCd.Trim();

            if ( claimCode == customerCode && addUpSecCode == resultSectCd )
            {
                customerCode = 0;
                resultSectCd = "00";
            }

            status = _iCustRsltUpdDB.SearchDmdPrc( paraWork.EnterpriseCode, addUpSecCode, claimCode, resultSectCd, customerCode, 0, out retObj );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retObj != null )
            {
                CustomSerializeArrayList retObjList = (CustomSerializeArrayList)retObj;
                if ( retObjList.Count > 0 )
                {
                    int TaxLayMethod = customerInputAcs.GetConsTaxLayMethod(paraWork.EnterpriseCode, 0);// ADD 2012/06/19 lanl for Redmine#30529
                    for ( int index = 0; index < retObjList.Count; index++ )
                    {
                        ArrayList list = (ArrayList)(retObjList[index] as ArrayList)[0];

                        foreach ( CustDmdPrcWork retWork in list as ArrayList )
                        {
                            if ( retWork.AddUpDate < custPrtPpr.Ed_SalesDate ) continue;
                            if ( retWork.StartCAddUpUpdDate > custPrtPpr.Ed_SalesDate ) continue;

                            CustPrtPprBlDspRsltWork rsltWork = new CustPrtPprBlDspRsltWork();
                            remainDataEx = new RemainDataExtra();

                            # region [���ʃZ�b�g]

                            rsltWork.AddUpYearMonth = retWork.AddUpYearMonth;// �����N��
                            rsltWork.ConsTaxLayMethod = retWork.ConsTaxLayMethod;// �]�ŕ���

                            // --- ADD 2012/06/19 lanl for Redmine#30529 ----------------------->>>>>
                            if (customer.CustCTaXLayRefCd == 0)//CustCTaXLayRefCdRF
                            {
                                rsltWork.ConsTaxLayMethod = TaxLayMethod;
                            }
                            else
                            {
                                
                                rsltWork.ConsTaxLayMethod = retWork.ConsTaxLayMethod;// �]�ŕ���
                            }
                            // --- ADD 2012/06/19 lanl for Redmine#30529 ----------------------<<<<< 
                            //rsltWork.ConsTaxLayMethod = retWork.ConsTaxLayMethod;// �]�ŕ��� // DEL  2012/06/19 lanl for Redmine#30529
                            rsltWork.AcpOdrTtl2TmBfBlDmd = retWork.AcpOdrTtl3TmBfBlDmd; // �O�X�X��c
                            rsltWork.LastTimeDemand = retWork.AcpOdrTtl2TmBfBlDmd; // �O�X��c
                            rsltWork.AfCalDemandPrice = retWork.LastTimeDemand; ; // �O��c

                            remainDataEx.OfsThisTimeSales = retWork.OfsThisTimeSales; // ���񔄏�
                            remainDataEx.OfsThisSalesTax = retWork.OfsThisSalesTax; // �����
                            remainDataEx.ThisTimeDmdNrml = retWork.ThisTimeDmdNrml; // �������
                            remainDataEx.AfCalBlc = retWork.AfCalDemandPrice; // �������z

                            remainDataEx.DmdStDay = retWork.StartCAddUpUpdDate; // ���J�n��
                            remainDataEx.TotalDay = retWork.AddUpDate; // ��������

                            remainDataEx.IsParent = (retWork.CustomerCode == retWork.ClaimCode || retWork.CustomerCode == 0); // �e�t���O

                            # endregion

                            // �ԋp�f�[�^
                            ArrayList retList = new ArrayList();
                            retList.Add( rsltWork );
                            suppPrtPprBlDspRsltWorkObj = retList;

                            break;
                        }
                    }
                }
            }
            # endregion

            if ( suppPrtPprBlDspRsltWorkObj == null )
            {
                # region [�����F��������W�v�����[�g�Ăяo��]
                //-----------------------------------------------
                // �����F��������W�v�����[�g�Ăяo��
                //-----------------------------------------------
                bool isParent;
                if ( (paraWork.CustomerCode == paraWork.ClaimCode && paraWork.ResultsSectCd.Trim() == paraWork.AddUpSecCode.Trim()) ||
                     (customerCode == 0 && resultSectCd.Trim() == "00") )
                {
                    isParent = true;
                    paraWork.CustomerCode = paraWork.ClaimCode;
                    paraWork.ResultsSectCd = paraWork.AddUpSecCode;
                }
                else
                {
                    isParent = false;
                    paraWork.CustomerCode = paraWork.ClaimCode;
                    paraWork.ResultsSectCd = paraWork.AddUpSecCode;
                }
                // --- ADD m.suzuki 2010/07/21 ---------->>>>>
                // ��ʊJ�n���i�O�������(���Ӑ搿�����z�}�X�^���R�[�h)�������ꍇ�ɓ��t�̊J�n���E�Ƃ��Ďg�p����j
                paraWork.ExtractStartDate = custPrtPpr.St_SalesDate;
                // --- ADD m.suzuki 2010/07/21 ----------<<<<<

                object paraObj = paraWork;
                object childObj = null;
                string message;
                status = _iCustDmdPrcDB.ReadCustDmdPrc( ref paraObj, ref childObj, out message );

                // --- ADD m.suzuki 2010/07/21 ---------->>>>>
                bool errorFlag = false;
                if ( paraObj == null && childObj == null)
                {
                    errorFlag = true;
                }
                else
                // --- ADD m.suzuki 2010/07/21 ----------<<<<<
                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    CustPrtPprBlDspRsltWork rsltWork = new CustPrtPprBlDspRsltWork();
                    remainDataEx = new RemainDataExtra();

                    CustDmdPrcWork retWork = null;
                    // --- ADD m.suzuki 2010/07/21 ---------->>>>>
                    try
                    {
                    // --- ADD m.suzuki 2010/07/21 ----------<<<<<
                        if ( isParent )
                        {
                            retWork = (CustDmdPrcWork)paraObj;
                        }
                        else
                        {
                            foreach ( CustDmdPrcWork childWork in (childObj as ArrayList) )
                            {
                                if ( childWork.CustomerCode == customerCode && childWork.ResultsSectCd.Trim() == resultSectCd.Trim() )
                                {
                                    retWork = childWork;
                                    break;
                                }
                            }
                        }
                    // --- ADD m.suzuki 2010/07/21 ---------->>>>>
                    }
                    catch
                    {
                        errorFlag = true;
                    }
                    // --- ADD m.suzuki 2010/07/21 ----------<<<<<

                    if ( retWork != null )
                    {
                        # region [���ʃZ�b�g]

                        rsltWork.AddUpYearMonth = retWork.AddUpYearMonth;// �����N��
                        // --- ADD 2012/06/19 lanl for Redmine#30529 ----------------------->>>>>
                        retWork.EnterpriseCode = custPrtPpr.EnterpriseCode; // ��ƃR�[�h // ADD 2012/07/10 tianjw for Redmine#30529 
                        if (customer.CustCTaXLayRefCd == 0)
                        {
                            rsltWork.ConsTaxLayMethod = customerInputAcs.GetConsTaxLayMethod(retWork.EnterpriseCode, 0);
                        }
                        else
                        {

                            rsltWork.ConsTaxLayMethod = retWork.ConsTaxLayMethod;// �]�ŕ���
                        }
                        // --- ADD lanl 2012/06/19 Redmine#30529 ----------------------<<<<< 
                        //rsltWork.ConsTaxLayMethod = retWork.ConsTaxLayMethod;// �]�ŕ��� // DEL  2012/06/19 lanl for Redmine#30529
                        rsltWork.AcpOdrTtl2TmBfBlDmd = retWork.AcpOdrTtl3TmBfBlDmd; // �O�X�X��c
                        rsltWork.LastTimeDemand = retWork.AcpOdrTtl2TmBfBlDmd; // �O�X��c
                        rsltWork.AfCalDemandPrice = retWork.LastTimeDemand; ; // �O��c

                        remainDataEx.OfsThisTimeSales = retWork.OfsThisTimeSales; // ���񔄏�
                        remainDataEx.OfsThisSalesTax = retWork.OfsThisSalesTax; // �����
                        remainDataEx.ThisTimeDmdNrml = retWork.ThisTimeDmdNrml; // �������
                        remainDataEx.AfCalBlc = retWork.AfCalDemandPrice; // �������z

                        remainDataEx.DmdStDay = retWork.StartCAddUpUpdDate; // ���J�n��
                        remainDataEx.TotalDay = custPrtPpr.Ed_SalesDate; // ��������

                        remainDataEx.IsParent = isParent; // �e�t���O

                        # endregion

                        // �ԋp�f�[�^
                        ArrayList retList = new ArrayList();
                        retList.Add( rsltWork );
                        suppPrtPprBlDspRsltWorkObj = retList;
                    }
                }
                // --- ADD m.suzuki 2010/07/21 ---------->>>>>
                if ( errorFlag )
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                // --- ADD m.suzuki 2010/07/21 ----------<<<<<
                # endregion
            }

            // �Y���f�[�^�Ȃ�
            if ( suppPrtPprBlDspRsltWorkObj == null )
            {
                suppPrtPprBlDspRsltWorkObj = new ArrayList();
            }

            return status;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 ADD

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
        /// <summary>
        /// �L�������擾����
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private object GetValidityTerm( string originText )
        {
            int validityTerm = 0;
            DateTime date;
            try
            {
                validityTerm = Int32.Parse( originText );
                date = GetDateTimeFromLongDate( validityTerm );
            }
            catch
            {
                date = DateTime.MinValue;
            }

            if ( date == DateTime.MinValue )
            {
                // �󔒂ɂ���
                return DBNull.Value;
            }
            else
            {
                // yyyy/mm/dd�ŃZ�b�g
                return date.ToString( "yyyy/MM/dd" );
            }
        }
        /// <summary>
        /// ���t�擾�����iint��DateTime�ϊ��j
        /// </summary>
        /// <param name="longDate"></param>
        /// <returns></returns>
        private DateTime GetDateTimeFromLongDate( int longDate )
        {
            try
            {
                return new DateTime( (longDate / 10000), ((longDate / 100) % 100), (longDate % 100) );
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
        /// <summary>
        /// �`�[�O���b�h�ւ̃Z�b�g�i�`�[�P�ʁj
        /// </summary>
        /// <param name="data"></param>
        /// <param name="salAmntConsTaxInclu"></param>
        /// <param name="yeardiv"></param>
        /// <param name="mode">�������[�h�i0:���팟���p 1:�e�L�X�g�o�͌����p�j</param> // ADD 2015/02/05 ������
        /// <br>Update Note: 2010/06/08 ������ ���㗚���f�[�^����`�[�Ĕ��s���\�֕ύX</br>
        /// <br>Update Note: 2010/12/20 yangmj </br>
        /// <br>             �N���Ɍ��̂ݐݒ肳��Ă���ꍇ�̃G���[�C��</br>
        /// <br>             �v�㌳�󒍇��E�v�㌳�ݏo���̕\�����e�C��</br>
        /// <br>Update Note: 2011/11/23 ����</br>
        /// <br>             Redmine#8079�Ή�</br>
        /// <br>             ���Ӑ�d�q����/�N���̕\���ɂ��Ă̏C��</br>
        /// <br>UpdateNote : 2015/02/05 ������ </br>
        /// <br>           : �e�L�X�g�o�͌��������Ȃ����[�h�̒ǉ�</br>
        /// <br>UpdateNote : K2014/05/08 �ђ��}</br>
        /// <br>           : ���Ӑ�d�q������CSV�o�͍��ڂɎԎ탁�[�J�[�R�[�h��ǉ�����A��������ʑΉ�</br>
        /// <br>Update Note: 2020/03/11 ���V��</br>
        /// <br>�Ǘ��ԍ�   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912 �y���ŗ��Ή�</br>
        /// <br>           : �`�[�^�u�A���׃^�u�Ɂu����ŗ��v���ڂ�ǉ�</br>
        //private void RecordSetToSlipList(CustPrtPprSalTblRsltWork data, int rowNo, long salAmntConsTaxInclu)//���� 2011/11/23 DEL
        private void RecordSetToSlipList(CustPrtPprSalTblRsltWork data, int rowNo, long salAmntConsTaxInclu, int yeardiv, int mode) // ADD 2015/02/05 ������
        {
            // �`�[�ԍ�����ю󒍃X�^�[�^�X���قȂ�Εʓ`�[�Ƃ��Ď擾
            //DataRow row2 = _dataSet.SalesList.NewRow();// DEL 2015/02/05 ������

            //----- ADD 2015/02/05 ������ -------------------->>>>>
            DataRow row2;
            if (mode == 0)
            {
                row2 = _dataSet.SalesList.NewRow();
            }
            else
            {
                row2 = this._salesListTbl4Text.NewRow();
            }
            //----- ADD 2015/02/05 ������ --------------------<<<<<

            // ����`�[�Ȃ̂������`�[�Ȃ̂��Ńf�[�^�̍\�����قȂ�
            if ( data.DataDiv == 0 )
            {
                #region ����`�[

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
                // �ԕi����p ���z����
                int slipSign = 1;

                // �ԕi����
                if ( data.SalesSlipCd == 1 ) slipSign *= -1;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD

                // ����`�[
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 DEL
                //row2[_dataSet.SalesList.SelectionColumn.ColumnName] = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                if ( data.HistoryDiv != 0 )
                {
                    // ----------UPD 2010/06/08----------->>>>>
                    //// �ߋ���(���㗚������擾��)�̓`�F�b�N�s��
                    //row2[_dataSet.SalesList.SelectionColumn.ColumnName] = DBNull.Value;
                    //���㗚���f�[�^����̍Ĕ��s�ł���
                    row2[_dataSet.SalesList.SelectionColumn.ColumnName] = false;
                    // ----------UPD 2010/06/08-----------<<<<<
                }
                else
                {
                    // �ʏ�
                    row2[_dataSet.SalesList.SelectionColumn.ColumnName] = false;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                row2[_dataSet.SalesList.RowNoColumn.ColumnName] = rowNo;
                row2[_dataSet.SalesList.DataDivColumn.ColumnName] = data.DataDiv;
                row2[_dataSet.SalesList.SalesDateColumn.ColumnName] = data.SalesDate;
                //row2[_dataSet.SalesList.SalesDateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.SalesDate);
                row2[_dataSet.SalesList.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                row2[_dataSet.SalesList.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                row2[_dataSet.SalesList.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                row2[_dataSet.SalesList.EnterpriseGanreCodeColumn.ColumnName] = data.EnterpriseGanreCode;
                // �`�[�敪������
                if ( data.SalesSlipCd == 0 )
                {
                    if ( data.AcptAnOdrStatus == 20 )
                    {
                        row2[_dataSet.SalesList.SalesSlipCdNameColumn.ColumnName] = "��";
                    }
                    else if ( data.AcptAnOdrStatus == 30 )
                    {
                        row2[_dataSet.SalesList.SalesSlipCdNameColumn.ColumnName] = "����";
                    }
                    else if ( data.AcptAnOdrStatus == 40 )
                    {
                        row2[_dataSet.SalesList.SalesSlipCdNameColumn.ColumnName] = "�ݏo";
                    }
                }
                else
                {
                    row2[_dataSet.SalesList.SalesSlipCdNameColumn.ColumnName] = "�ԕi";
                }
                row2[_dataSet.SalesList.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                //row2[_dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                //row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                //row2[_dataSet.SalesList.GrossProfitColumn.ColumnName] = data.SalesTotalTaxExc - data.TotalCost;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                //if (data.CategoryNo == 0)
                //{
                //    row2[_dataSet.SalesList.CategoryNoColumn.ColumnName] = DBNull.Value;
                //}
                //else
                //{
                //    row2[_dataSet.SalesList.CategoryNoColumn.ColumnName] = data.CategoryNo;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                row2[_dataSet.SalesList.CategoryNoColumn.ColumnName] = GetModelDesignationNoAndCategoryNo( data );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                //----- ADD K2014/05/28 By �ђ��} Redmine#42764 ����e�X�g��Q�Ή� BEGIN--------->>>>>
                //----- ADD K2014/05/08 By �ђ��} �e�L�X�g�o�͍��ڂɎԎ탁�[�J�[�R�[�h��ǉ����� BEGIN--------->>>>>
                if (this._opt_Toua == Convert.ToInt32(Option.ON))
                {
                    row2[_dataSet.SalesList.MakerCodeColumn.ColumnName] = data.MakerCode;
                }
                //----- ADD K2014/05/08 By �ђ��} �e�L�X�g�o�͍��ڂɎԎ탁�[�J�[�R�[�h��ǉ����� END---------<<<<<
                //----- ADD K2014/05/28 By �ђ��} Redmine#42764 ����e�X�g��Q�Ή� END---------<<<<<
                row2[_dataSet.SalesList.ModelFullNameColumn.ColumnName] = data.ModelFullName;
                // --- ADD m.suzuki 2010/04/02 ---------->>>>>
                row2[_dataSet.SalesList.ModelHalfNameColumn.ColumnName] = data.ModelHalfName;
                // --- ADD m.suzuki 2010/04/02 ----------<<<<<
                // -------------UPD 2010/01/12------------->>>>>
                //if ( data.FirstEntryDate == DateTime.MinValue )
                if (data.FirstEntryDate == 0)
                {
                    row2[_dataSet.SalesList.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    //row2[_dataSet.SalesList.FirstEntryDateColumn.ColumnName] = data.FirstEntryDate;
                    //----UPD 2010/12/20----->>>>>
                    string firstEntryDate = "";

                    if (data.FirstEntryDate.ToString().Length < 6)
                    {
                        firstEntryDate = "0000" + "/" + data.FirstEntryDate.ToString("D2");
                    }   
                    else
                    {
                        firstEntryDate = data.FirstEntryDate.ToString().Substring(0, 4) + "/" + data.FirstEntryDate.ToString().Substring(4, 2);
                    }
                    firstEntryDate = firstEntryDate.Replace(@"/00", ""); // ADD 2013/05/06 zhujw #34718
                    //string firstEntryDate = data.FirstEntryDate.ToString().Substring(0, 4) + "/" + data.FirstEntryDate.ToString().Substring(4, 2);
                    //----UPD 2010/12/20-----<<<<<
                    //���� 2011/11/23 ADD----->>>>>
                    if (yeardiv == 1)
                    {
                        // --- UPD 2012/06/26 ��880 ---------->>>>>
                        //string date = data.FirstEntryDate.ToString() + "01";
                        //int StartTotalUnitYm = Convert.ToInt32(date);
                        //string stTarget = TDateTime.LongDateToString("GGyymm", StartTotalUnitYm);
                        string date, stTarget;
                        int StartTotalUnitYm;
                        if (data.FirstEntryDate.ToString().Substring(4, 2) == "00")
                        {
                            date = data.FirstEntryDate.ToString().Substring(0, 4) + "0101";
                            StartTotalUnitYm = Convert.ToInt32(date);
                            //stTarget = TDateTime.LongDateToString("GGyy", StartTotalUnitYm) + "00��";// DEL 2013/05/06 zhujw #Redmine34718
                            stTarget = TDateTime.LongDateToString("GGyy", StartTotalUnitYm);// ADD 2013/05/06 zhujw #Redmine34718
                        }
                        else
                        {
                            date = data.FirstEntryDate.ToString() + "01";
                            StartTotalUnitYm = Convert.ToInt32(date);
                            stTarget = TDateTime.LongDateToString("GGyymm", StartTotalUnitYm);
                        }
                        // --- UPD 2012/06/26 ��880 ----------<<<<<

                        row2[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = stTarget;
                    }
                    else
                    {
                        row2[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = firstEntryDate;
                    }
                    //���� 2011/11/23 ADD-----<<<<<
                    //row2[_dataSet.SalesList.FirstEntryDateColumn.ColumnName] = firstEntryDate; //���� 2011/11/23 DEL
                }
                // -------------UPD 2010/01/12-------------<<<<<
                //row2[_dataSet.SalesList.FirstEntryDateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.FirstEntryDate);
                row2[_dataSet.SalesList.FullModelColumn.ColumnName] = data.FullModel;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 DEL
                //if ( data.SearchFrameNo == 0 )
                //{
                //    row2[_dataSet.SalesList.FrameNoColumn.ColumnName] = DBNull.Value;
                //}
                //else
                //{
                //    row2[_dataSet.SalesList.FrameNoColumn.ColumnName] = data.SearchFrameNo;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                row2[_dataSet.SalesList.FrameNoColumn.ColumnName] = data.FrameNo;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD
                row2[_dataSet.SalesList.SlipNoteColumn.ColumnName] = data.SlipNote;
                row2[_dataSet.SalesList.SlipNote2Column.ColumnName] = data.SlipNote2;
                row2[_dataSet.SalesList.SlipNote3Column.ColumnName] = data.SlipNote3;
                row2[_dataSet.SalesList.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                row2[_dataSet.SalesList.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 DEL
                //row2[_dataSet.SalesList.CustomerCodeColumn.ColumnName] = data.CustomerCode.ToString().PadLeft(CT_DEPTH_CUSTOMERCODE, '0');
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD
                row2[_dataSet.SalesList.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD
                row2[_dataSet.SalesList.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                row2[_dataSet.SalesList.PartySaleSlipNumColumn.ColumnName] = data.PartySaleSlipNum;
                row2[_dataSet.SalesList.CarMngCodeColumn.ColumnName] = data.CarMngCode;
                // ----- UPD 2010/12/20 ----->>>>>
                //if (data.AcceptAnOrderNo == 0)
                //{
                //    row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                //}
                //else
                //{
                //    row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = data.AcceptAnOrderNo;
                //}
                if (data.AcptAnOdrStatusSrc == 20)
                {
                    if (!string.IsNullOrEmpty(data.HisDtlSlipNum.ToString()))
                    {
                        row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = data.HisDtlSlipNum;
                    }
                }
                else
                {
                    //if (data.AcceptAnOrderNo == 0)
                    //{
                        row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                    //}
                    //else
                    //{
                    //    row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = data.AcceptAnOrderNo;
                    //}
                }

                // �v�㌳�o��No[NULL�̂Ƃ��͋�]

                //if (data.ShipmSalesSlipNum == "0")
                //{
                //    row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = string.Empty;
                //}
                //else
                //{
                //    row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = data.ShipmSalesSlipNum;
                //}
                if (data.AcptAnOdrStatusSrc == 40)
                {
                    row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = data.HisDtlSlipNum;
                }
                else
                {
                    //if (data.ShipmSalesSlipNum == "0")
                    //{
                        row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = string.Empty;
                    //}
                    //else
                    //{
                    //    row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = data.ShipmSalesSlipNum;
                    //}
                }
                // ----- UPD 2010/12/20 -----<<<<<

                row2[_dataSet.SalesList.UoeRemark1Column.ColumnName] = data.UoeRemark1;
                row2[_dataSet.SalesList.UoeRemark2Column.ColumnName] = data.UoeRemark2;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                //row2[_dataSet.SalesList.SectionCdColumn.ColumnName] = data.SectionCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                row2[_dataSet.SalesList.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                row2[_dataSet.SalesList.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                row2[_dataSet.SalesList.ColorName1Column.ColumnName] = data.ColorName1;
                row2[_dataSet.SalesList.TrimNameColumn.ColumnName] = data.TrimName;
                if ( data.CustSlipNo == 0 )
                {
                    row2[_dataSet.SalesList.CustSlipNoColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row2[_dataSet.SalesList.CustSlipNoColumn.ColumnName] = data.CustSlipNo;
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                //row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = data.AddUpADate;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                if ( data.AddUpADate != DateTime.MinValue )
                {
                    row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = data.AddUpADate;
                }
                else
                {
                    row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = DBNull.Value;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                //row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.AddUpADate);
                row2[_dataSet.SalesList.AccRecDivCdColumn.ColumnName] = data.AccRecDivCd;
                if ( data.AccRecDivCd == 1 )
                {
                    row2[_dataSet.SalesList.AccRecDivCdNameColumn.ColumnName] = "���|";
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                else
                {
                    row2[_dataSet.SalesList.AccRecDivCdNameColumn.ColumnName] = "����";
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                //row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = data.DebitNoteDiv;
                if ( data.DebitNoteDiv == 0 )
                {
                    row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "���`";
                }
                else if ( data.DebitNoteDiv == 1 )
                {
                    row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "�ԓ`";
                }
                else if ( data.DebitNoteDiv == 2 )
                {
                    row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "����";
                }
                else
                {
                    row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = string.Empty;
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                # region [����Ŋ֘A]
                bool printTax = true;
                Int64 salesTotalTaxInc;
                Int64 salesTotalTaxExc = data.SalesTotalTaxExc;
                Int64 salesPriceConsTax;

                // ����������Ŋz�̎擾
                if ( data.ConsTaxLayMethod == 0 || data.ConsTaxLayMethod == 1 ) // �`�[�P��or���גP��
                {
                    salesPriceConsTax = data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                }
                else
                {
                    salesPriceConsTax = 0;
                }

                // �ō����z�̎擾
                salesTotalTaxInc = salesTotalTaxExc + salesPriceConsTax;

                if ( printTax )
                {
                    // ����ň󎚗L������Ƌ��z����
                    int totalAmountDispWayCd = data.TotalAmountDispWayCd;

                    // ����ň󎚗L������
                    printTax = ReflectMoneyForTaxPrintOfSlip( ref salesTotalTaxExc, ref salesPriceConsTax, ref salAmntConsTaxInclu, ref salesTotalTaxInc, totalAmountDispWayCd, data.ConsTaxLayMethod );
                    if ( printTax )
                    {
                        if ( salesPriceConsTax != 0 )
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 DEL
                            //row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = salesPriceConsTax;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                            row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = slipSign * salesPriceConsTax;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD
                            // ����ŗ�
                            row2[_dataSet.SalesList.ConsTaxRateColumn.ColumnName] = data.ConsTaxRate; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                        }
                        else
                        {
                            // �󎚂��Ȃ�
                            row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                            row2[_dataSet.SalesList.ConsTaxRateColumn.ColumnName] = DBNull.Value;�@// ADD ���V�� 2020/03/11 PMKOBETSU-2912
                        }
                    }
                    else
                    {
                        // �󎚂��Ȃ�
                        row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                        row2[_dataSet.SalesList.ConsTaxRateColumn.ColumnName] = DBNull.Value;�@// ADD ���V�� 2020/03/11 PMKOBETSU-2912
                    }
                }
                else
                {
                    // �󎚂��Ȃ�
                    row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                    row2[_dataSet.SalesList.ConsTaxRateColumn.ColumnName] = DBNull.Value;�@// ADD ���V�� 2020/03/11 PMKOBETSU-2912
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 DEL
                //// �Ŕ����z�Z�b�g
                //row2[_dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName] = salesTotalTaxExc;
                //// �e���Z�b�g
                //row2[_dataSet.SalesList.GrossProfitColumn.ColumnName] = salesTotalTaxExc - data.TotalCost;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                // �Ŕ����z�Z�b�g
                row2[_dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName] =  slipSign * salesTotalTaxExc;
                // �e���Z�b�g
                row2[_dataSet.SalesList.GrossProfitColumn.ColumnName] = slipSign * (salesTotalTaxExc - data.TotalCost);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 DEL
                //if ( (long)row2[_dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName] < 0 )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                if ( data.ShipmentCnt < 0 && data.SalesSlipCdDtl != 2 )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD
                {
                    row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "�ԓ`";
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                row2[_dataSet.SalesList.AddresseeCodeColumn.ColumnName] = data.AddresseeCode;
                row2[_dataSet.SalesList.AddresseeNameColumn.ColumnName] = data.AddresseeName + data.AddresseeName2;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
                // ���͓�
                if ( data.InputDay != DateTime.MinValue )
                {
                    row2[_dataSet.SalesList.InputDayColumn.ColumnName] = data.InputDay;
                }
                else
                {
                    row2[_dataSet.SalesList.InputDayColumn.ColumnName] = DBNull.Value;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                row2[_dataSet.SalesList.HistoryDivNameColumn.ColumnName] = this.GetHistoryDivName( data.HistoryDiv ); // �����敪
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
                row2[_dataSet.SalesList.SlipPrintTimeColumn.ColumnName] = this.GetSlipPrintTimeText( data.UpdateDateTime ); // �`�[���s����
                // ADD 2012/04/01 gezh Redmine#29250 ------------------------------------------------------------->>>>>
                if (data.UpdateDateTime != 0)
                {
                    DateTime dt = new DateTime(data.UpdateDateTime);
                    row2[_dataSet.SalesList.UpdateDateTimeColumn.ColumnName] = dt.ToString("yyyy/MM/dd HH:mm:ss"); // �X�V����
                }
                else
                {
                    row2[_dataSet.SalesList.UpdateDateTimeColumn.ColumnName] = string.Empty;
                }
                // ADD 2012/04/01 gezh Redmine#29250 -------------------------------------------------------------<<<<<
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD

                //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
                if (this._opt_Meigo == Convert.ToInt32(Option.ON))
                {
                    row2[_dataSet.SalesList.SalesAreaNameColumn.ColumnName] = data.SalesAreaName;
                    if (data.CustAnalysCode1 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode1Column.ColumnName] = data.CustAnalysCode1;
                    }
                    if (data.CustAnalysCode2 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode2Column.ColumnName] = data.CustAnalysCode2;
                    }
                    if (data.CustAnalysCode3 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode3Column.ColumnName] = data.CustAnalysCode3;
                    }
                    if (data.CustAnalysCode4 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode4Column.ColumnName] = data.CustAnalysCode4;
                    }
                    if (data.CustAnalysCode5 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode5Column.ColumnName] = data.CustAnalysCode5;
                    }
                    if (data.CustAnalysCode6 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode6Column.ColumnName] = data.CustAnalysCode6;
                    }
                }
                //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<

                #endregion // ����`�[
            }
            else
            {
                #region �����`�[
                // �����`�[
                // �I���`�F�b�N�{�b�N�X�Ȃ�
                row2[_dataSet.SalesList.SelectionColumn.ColumnName] = DBNull.Value;
                row2[_dataSet.SalesList.RowNoColumn.ColumnName] = rowNo;
                row2[_dataSet.SalesList.DataDivColumn.ColumnName] = data.DataDiv;
                row2[_dataSet.SalesList.SalesDateColumn.ColumnName] = data.SalesDate;
                row2[_dataSet.SalesList.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                row2[_dataSet.SalesList.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                row2[_dataSet.SalesList.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                row2[_dataSet.SalesList.SalesSlipCdNameColumn.ColumnName] = "����";
                row2[_dataSet.SalesList.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                row2[_dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                //row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                //row2[_dataSet.SalesList.GrossProfitColumn.ColumnName] = data.SalesTotalTaxExc - data.TotalCost;
                //row2[_dataSet.SalesList.CategoryNoColumn.ColumnName] = data.CategoryNo;
                row2[_dataSet.SalesList.CategoryNoColumn.ColumnName] = DBNull.Value;
                //row2[_dataSet.SalesList.ModelFullNameColumn.ColumnName] = data.ModelFullName;
                //row2[_dataSet.SalesList.FirstEntryDateColumn.ColumnName] = data.FirstEntryDate;
                //row2[_dataSet.SalesList.FullModelColumn.ColumnName] = data.FullModel;
                //row2[_dataSet.SalesList.SearchFrameNoColumn.ColumnName] = data.SearchFrameNo;
                row2[_dataSet.SalesList.FrameNoColumn.ColumnName] = DBNull.Value;
                row2[_dataSet.SalesList.SlipNoteColumn.ColumnName] = data.SlipNote;
                //row2[_dataSet.SalesList.SlipNote2Column.ColumnName] = data.SlipNote2;
                //row2[_dataSet.SalesList.SlipNote3Column.ColumnName] = data.SlipNote3;
                //row2[_dataSet.SalesList.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                row2[_dataSet.SalesList.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 DEL
                //row2[_dataSet.SalesList.CustomerCodeColumn.ColumnName] = data.CustomerCode.ToString().PadLeft(CT_DEPTH_CUSTOMERCODE, '0');
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD
                row2[_dataSet.SalesList.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD
                row2[_dataSet.SalesList.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                //row2[_dataSet.SalesList.PartySaleSlipNumColumn.ColumnName] = data.PartySaleSlipNum;
                //row2[_dataSet.SalesList.CarMngCodeColumn.ColumnName] = data.CarMngCode;
                //row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = data.AcceptAnOrderNo;
                row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                //row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = data.ShipmSalesSlipNum;
                row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = string.Empty;
                //row2[_dataSet.SalesList.UoeRemark1Column.ColumnName] = data.UoeRemark1;
                //row2[_dataSet.SalesList.UoeRemark2Column.ColumnName] = data.UoeRemark2;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                //row2[_dataSet.SalesList.SectionCdColumn.ColumnName] = data.SectionCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                row2[_dataSet.SalesList.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                row2[_dataSet.SalesList.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                //row2[_dataSet.SalesList.ColorName1Column.ColumnName] = data.ColorName1;
                //row2[_dataSet.SalesList.TrimNameColumn.ColumnName] = data.TrimName;
                //row2[_dataSet.SalesList.CustSlipNoColumn.ColumnName] = data.CustSlipNo;
                row2[_dataSet.SalesList.CustSlipNoColumn.ColumnName] = DBNull.Value;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                if ( data.AddUpADate != DateTime.MinValue )
                {
                    row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = data.AddUpADate;
                }
                else
                {
                    row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = DBNull.Value;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                //if (data.AccRecDivCd == 1)
                //{
                //    row2[_dataSet.SalesList.AccRecDivCdNameColumn.ColumnName] = "���|";
                //}
                //row2[_dataSet.SalesList.AccRecDivCdColumn.ColumnName] = data.AccRecDivCd;
                if ( data.DebitNoteDiv == 0 )
                {
                    row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "��";
                }
                else if ( data.DebitNoteDiv == 1 )
                {
                    row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "��";
                }
                else if ( data.DebitNoteDiv == 2 )
                {
                    row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "���E�ύ�";
                }
                else
                {
                    row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = string.Empty;
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                row2[_dataSet.SalesList.AddresseeCodeColumn.ColumnName] = data.AddresseeCode;
                row2[_dataSet.SalesList.AddresseeNameColumn.ColumnName] = data.AddresseeName + data.AddresseeName2;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
                // ���͓�
                if ( data.InputDay != DateTime.MinValue )
                {
                    row2[_dataSet.SalesList.InputDayColumn.ColumnName] = data.InputDay;
                }
                else
                {
                    row2[_dataSet.SalesList.InputDayColumn.ColumnName] = DBNull.Value;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                row2[_dataSet.SalesList.HistoryDivNameColumn.ColumnName] = string.Empty; // �����敪
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
                row2[_dataSet.SalesList.SlipPrintTimeColumn.ColumnName] = this.GetSlipPrintTimeText( data.UpdateDateTime ); // �`�[���s����
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
                // ADD 2012/04/01 gezh Redmine#29250 --------------------------------------------------------------------->>>>>
                if (data.UpdateDateTime != 0)
                {
                    DateTime dt = new DateTime(data.UpdateDateTime);
                    row2[_dataSet.SalesList.UpdateDateTimeColumn.ColumnName] = dt.ToString("yyyy/MM/dd HH:mm:ss"); // �X�V����  
                }
                else
                {
                    row2[_dataSet.SalesList.UpdateDateTimeColumn.ColumnName] = string.Empty;
                }
                // ADD 2012/04/01 gezh Redmine#29250 ---------------------------------------------------------------------<<<<<
            

                //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
                if (this._opt_Meigo == Convert.ToInt32(Option.ON))
                {
                    row2[_dataSet.SalesList.SalesAreaNameColumn.ColumnName] = data.SalesAreaName;
                    if (data.CustAnalysCode1 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode1Column.ColumnName] = data.CustAnalysCode1;
                    }
                    if (data.CustAnalysCode2 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode2Column.ColumnName] = data.CustAnalysCode2;
                    }
                    if (data.CustAnalysCode3 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode3Column.ColumnName] = data.CustAnalysCode3;
                    }
                    if (data.CustAnalysCode4 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode4Column.ColumnName] = data.CustAnalysCode4;
                    }
                    if (data.CustAnalysCode5 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode5Column.ColumnName] = data.CustAnalysCode5;
                    }
                    if (data.CustAnalysCode6 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode6Column.ColumnName] = data.CustAnalysCode6;
                    }
                }
                //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<

                #endregion // �����`�[
            }

             // �s�ǉ�
            //this._dataSet.SalesList.Rows.Add( row2 ); // DEL 2015/02/05 ������

            //----- ADD 2015/02/05 ������ -------------------->>>>>
            if (mode == 0)
            {
            this._dataSet.SalesList.Rows.Add( row2 );
        }
            else
            {
                this._salesListTbl4Text.Rows.Add(row2);
            }
            //----- ADD 2015/02/05 ������ --------------------<<<<<
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
        /// <summary>
        /// �ޕʌ^���擾����
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private object GetModelDesignationNoAndCategoryNo( CustPrtPprSalTblRsltWork data )
        {
            int categoryNo = data.CategoryNo;
            int modelDesignationNo = data.ModelDesignationNo;

            if ( modelDesignationNo == 0 && categoryNo == 0 )
            {
                return string.Empty;
            }
            else
            {
                string result = string.Empty;

                // �^���w��ԍ�
                if ( modelDesignationNo == 0 )
                {
                    result += new string( ' ', 5 );
                }
                else
                {
                    result += modelDesignationNo.ToString( "00000" );
                }

                // �n�C�t��
                result += "-";

                // �ޕʔԍ�
                if ( categoryNo == 0 )
                {
                    result += new string( ' ', 4 );
                }
                else
                {
                    result += categoryNo.ToString( "0000" );
                }

                return result;
            }
        }
        /// <summary>
        /// ���z�擾�����i����ň���Ή��j
        /// </summary>
        /// <param name="moneyTaxExc"></param>
        /// <param name="priceConsTax"></param>
        /// <param name="moneyTaxInc"></param>
        /// <param name="totalAmountDispWayCd"></param>
        /// <param name="consTaxLayMethod"></param>
        /// <param name="taxationDivCd"></param>
        private static bool ReflectMoneyForTaxPrint( ref long moneyTaxExc, ref long priceConsTax, ref long moneyTaxInc, int totalAmountDispWayCd, int consTaxLayMethod, int taxationDivCd )
        {
            bool printTax;

            # region [printTax]
            switch ( GetTaxPrintType( totalAmountDispWayCd, consTaxLayMethod ) )
            {
                case 0:
                    // ----- ADD huangt 2013/05/15 Redmine#35640 ---------- >>>>> 
                    {
                        // �`�[�P�ʁi�`�[���̖��א擪�s�ɏ���ł��󎚂����j
                        printTax = true;
                    }
                    break;
                    // ----- ADD huangt 2013/05/15 Redmine#35640 ---------- <<<<<
                default:
                    {
                        // �`�[�P�ʁi���ז��̏���ł͕\�����Ȃ��j
                        printTax = false;
                    }
                    break;
                case 1:
                    {
                        // ���גP��/���z�\��
                        printTax = true;
                    }
                    break;
                case 2:
                    {
                        // �����e�q�E��ېŁi�ېŋ敪�����ł̂ݕ\���j
                        // �ېŋ敪�i0:�ې�,1:��ې�,2:�ېŁi���Łj�j
                        switch ( taxationDivCd )
                        {
                            case 0:
                            case 1:
                            default:
                                {
                                    printTax = false;
                                }
                                break;
                            case 2:
                                {
                                    printTax = true;
                                }
                                break;
                        }
                    }
                    break;
            }
            # endregion

            // �ň󎚂��Ȃ��ꍇ
            if ( !printTax )
            {
                priceConsTax = 0;
                moneyTaxInc = moneyTaxExc;
            }

            return printTax;
        }
        /// <summary>
        /// ���z�擾�����i����ň���Ή��j
        /// </summary>
        /// <param name="moneyTaxExc"></param>
        /// <param name="priceConsTax"></param>
        /// <param name="moneyTaxInc"></param>
        /// <param name="totalAmountDispWayCd"></param>
        /// <param name="consTaxLayMethod"></param>
        private static bool ReflectMoneyForTaxPrintOfSlip( ref long moneyTaxExc, ref long priceConsTax, ref long priceConsTaxInclu, ref long moneyTaxInc, int totalAmountDispWayCd, int consTaxLayMethod )
        {
            bool printTax;

            # region [printTax]
            switch ( GetTaxPrintType( totalAmountDispWayCd, consTaxLayMethod ) )
            {
                case 0:
                default:
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                        //// �`�[�P�ʁi���ז��̏���ł͕\�����Ȃ��j
                        //printTax = false;
                        //priceConsTax = 0;
                        //moneyTaxInc = moneyTaxExc;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                        // �`�[�P�ʁi�`�[�P�ʂ̏���ł��󎚂���j
                        printTax = true;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                    }
                    break;
                case 1:
                    {
                        // ���גP��/���z�\��
                        printTax = true;
                    }
                    break;
                case 2:
                    {
                        //// �����e�q�E��ېŁi�ېŋ敪�����ł̂ݕ\���j
                        //// �ېŋ敪�i0:�ې�,1:��ې�,2:�ېŁi���Łj�j
                        //switch ( taxationDivCd )
                        //{
                        //    case 0:
                        //    case 1:
                        //    default:
                        //        {
                        //            printTax = false;
                        //        }
                        //        break;
                        //    case 2:
                        //        {
                        //            printTax = true;
                        //        }
                        //        break;
                        //}
                        printTax = (priceConsTaxInclu != 0);
                        priceConsTax = priceConsTaxInclu;
                        moneyTaxInc = moneyTaxExc + priceConsTaxInclu;
                    }
                    break;
            }
            # endregion

            //// �ň󎚂��Ȃ��ꍇ
            //if ( !printTax )
            //{
            //    priceConsTax = 0;
            //    moneyTaxInc = moneyTaxExc;
            //}

            return printTax;
        }
        /// <summary>
        /// ����ŕ\���^�C�v�擾
        /// </summary>
        /// <param name="slipWork"></param>
        /// <returns>TaxPrintType�i0:�`�[�P��, 1:���גP��/���z�\������, 2:�����e/�����q/��ېŁj</returns>
        private static int GetTaxPrintType( int totalAmountDispWayCd, int consTaxLayMethod )
        {
            // ���z�\�����@
            switch ( totalAmountDispWayCd )
            {
                case 1:
                    // ���z�\������
                    return 1;
                case 0:
                default:
                    {
                        // ���z�\�����Ȃ�

                        switch ( consTaxLayMethod )
                        {
                            // 0:�`�[�P��
                            case 0:
                                return 0;
                            // 1:���גP��
                            case 1:
                                return 1;
                            // 2:�����e
                            case 2:
                            // 3:�����q
                            case 3:
                            // 9:��ې�
                            case 9:
                            default:
                                return 2;
                        }
                    }
            }
        }
        /// <summary>
        /// �e��(����)�Z�o
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private Int64 GetGrossProfitDetail( CustPrtPprSalTblRsltWork data )
        {
            // --- UPD 2013/10/02 T.Miyamoto ------------------------------>>>>>
            //decimal grossProfit = (decimal)data.SalesMoneyTaxExc - (decimal)data.ShipmentCnt * (decimal)data.SalesUnitCost;
            //// �؂�̂�
            //return (Int64)grossProfit;
            return data.SalesMoneyTaxExc - data.Cost;
            // --- UPD 2013/10/02 T.Miyamoto ------------------------------<<<<<
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  #7861 2011/11/23 ADD
        /// <summary>
        /// �e����(����)�Z�o
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private decimal GetGrossProfitMargin(CustPrtPprSalTblRsltWork data)
        {
            if (data.SalesMoneyTaxExc != 0)
            {
                decimal gpm = Convert.ToDecimal((data.SalesMoneyTaxExc - data.Cost) / (decimal)data.SalesMoneyTaxExc);

                return gpm;
            }
            else
                return 0;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  #7861 2011/11/23 ADD

        /// <summary>
        /// �c���ꗗ�擾
        /// </summary>
        /// <param name="custPrtPprBlnce"></param>
        /// <param name="remainType">0: ���� 1: ���|</param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 DEL
        //public int SearchBalance(CustPrtPprBlnce custPrtPprBlnce, int remainType)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 ADD
        public int SearchBalance( ref CustPrtPprBlnce custPrtPprBlnce, int remainType )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 ADD
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 ADD
            CustPrtPprBlnce custPrtPprBlnceBackup = custPrtPprBlnce.Clone();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 ADD

            try
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                // �N���A
                this._dataSet.BalanceList.Rows.Clear();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 ADD
                //---------------------------------
                // ���̓`�F�b�N
                //---------------------------------
                # region [���̓`�F�b�N]
                // ���_�R�[�h
                if ( custPrtPprBlnce.SectionCode == null || custPrtPprBlnce.SectionCode.Length == 0 )
                {
                    custPrtPprBlnce.SectionCode = new string[] { "00" };
                }
                string sectionCode = custPrtPprBlnce.SectionCode[0].Trim();

                //-----------------------------------------------------------
                // ���Ӑ�E��������͔���
                //-----------------------------------------------------------
                if ( custPrtPprBlnce.CustomerCode != 0 )
                {
                    // ���Ӑ�ǂݍ���
                    CustomerInfo customer;
                    int readStatus = _customerInfoAcs.ReadDBData( ConstantManagement.LogicalMode.GetData0, custPrtPprBlnce.EnterpriseCode, custPrtPprBlnce.CustomerCode, true, true, out customer );
                    if ( readStatus != 0 || customer == null || customer.LogicalDeleteCode != 0 )
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                    // UPD 2012/06/01 ----------------------->>>>>
                    //sectionCode = customer.MngSectionCode.Trim();
                    // ���o���_�ɂ��p�����[�^�̋��_�R�[�h��I������
                    if (custPrtPprBlnce.RemainSectionType.Equals((int)RemainSectionType.Mng))
                    {
                        sectionCode = customer.MngSectionCode.Trim();
                    }
                    else
                    {
                        sectionCode = customer.ClaimSectionCode.Trim();
                    }
                    // UPD 2012/06/01 -----------------------<<<<<

                    if (custPrtPprBlnce.ClaimCode != 0)
                    {
                        //----------------------------------------------
                        // ���Ӑ�{������
                        //----------------------------------------------

                        // �e�q�֌W����
                        if ( customer.ClaimCode == custPrtPprBlnce.ClaimCode && customer.ClaimSectionCode.Trim() == sectionCode )
                        {
                            custPrtPprBlnce.CustomerCode = 0;
                            custPrtPprBlnce.ClaimCode = customer.ClaimCode;
                            custPrtPprBlnce.SectionCode[0] = sectionCode;
                        }
                        else
                        {
                            return (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                    }
                    else
                    {
                        //----------------------------------------------
                        // ���Ӑ�̂�
                        //----------------------------------------------
                        if ( customer.CustomerCode == customer.ClaimCode )
                        {
                            custPrtPprBlnce.CustomerCode = 0;
                            custPrtPprBlnce.ClaimCode = customer.ClaimCode;
                            custPrtPprBlnce.SectionCode[0] = sectionCode;
                        }
                        else
                        {
                            return (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                    }
                    // ���_�X�V
                    if ( UpdateSection != null )
                    {
                        // UPD 2012/06/01 ----------------------->>>>>
                        //UpdateSection( this, customer.MngSectionCode, customer.MngSectionName );
                        // ���o���_�ɂ��p�����[�^�̋��_�R�[�h��I������
                        if (custPrtPprBlnce.RemainSectionType.Equals((int)RemainSectionType.Mng))
                        {
                            UpdateSection(this, customer.MngSectionCode, customer.MngSectionName);
                        }
                        else
                        {
                            UpdateSection(this, customer.ClaimSectionCode, customer.ClaimSectionName);
                        }
                        // UPD 2012/06/01 -----------------------<<<<<
                    }
                }
                else
                {
                    if ( custPrtPprBlnce.ClaimCode != 0 )
                    {
                        //----------------------------------------------
                        // ������̂�
                        //----------------------------------------------

                        // ������ǂݍ���
                        CustomerInfo claim;
                        int readStatus = _customerInfoAcs.ReadDBData( ConstantManagement.LogicalMode.GetData0, custPrtPprBlnce.EnterpriseCode, custPrtPprBlnce.ClaimCode, true, true, out claim );
                        if ( readStatus != 0 || claim == null || claim.LogicalDeleteCode != 0 )
                        {
                            return (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                        // UPD 2012/06/01 ----------------------->>>>>
                        //sectionCode = claim.MngSectionCode.Trim();
                        // ���o���_�ɂ��p�����[�^�̋��_�R�[�h��I������
                        if (custPrtPprBlnce.RemainSectionType.Equals((int)RemainSectionType.Mng))
                        {
                            sectionCode = claim.MngSectionCode.Trim();
                        }
                        else
                        {
                            sectionCode = claim.ClaimSectionCode.Trim();
                        }
                        // UPD 2012/06/01 -----------------------<<<<<

                        // �e�q����
                        if ( claim.ClaimCode == claim.CustomerCode && claim.ClaimSectionCode.Trim() == sectionCode )
                        {
                            custPrtPprBlnce.CustomerCode = 0;
                            custPrtPprBlnce.ClaimCode = claim.CustomerCode;
                            custPrtPprBlnce.SectionCode[0] = sectionCode;
                        }
                        else
                        {
                            return (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                        // ���_�X�V
                        if ( UpdateSection != null )
                        {
                            // UPD 2012/06/01 ----------------------->>>>>
                            //UpdateSection(this, claim.MngSectionCode, claim.MngSectionName);
                            // ���o���_�ɂ��p�����[�^�̋��_�R�[�h��I������
                            if (custPrtPprBlnce.RemainSectionType.Equals((int)RemainSectionType.Mng))
                            {
                                UpdateSection(this, claim.MngSectionCode, claim.MngSectionName);
                            }
                            else
                            {
                                UpdateSection(this, claim.ClaimSectionCode, claim.ClaimSectionName);
                            }
                            // UPD 2012/06/01 -----------------------<<<<<
                        }
                    }
                    else
                    {
                        //----------------------------------------------
                        // (�����Ƃ����͂Ȃ�)
                        //----------------------------------------------
                        return (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                }
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 ADD

                //---------------------------------
                // �p�����[�^�N���X���쐬
                //---------------------------------
                CustPrtPprBlnceWork custPrtPprBlnceWork = new CustPrtPprBlnceWork();
                CustPrtPprBlnce2CustPrtPprBlnceWork( ref custPrtPprBlnce, ref custPrtPprBlnceWork );

                //---------------------------------
                // �Ԃ�l�Ŏg�p����N���X���쐬
                //---------------------------------
                CustPrtPprBlTblRsltWork custPrtPprBlTblRsltWork = new CustPrtPprBlTblRsltWork();
                object custPrtPprBlTblRsltWorkObj = (object)custPrtPprBlTblRsltWork;
                // --- DEL 2020/12/21 �x���Ή� ---------->>>>>
                //long counter = 0;
                // --- DEL 2020/12/21 �x���Ή� ----------<<<<<
                int status;

                // readMode, logicalMode�͌��󖢎g�p
                status = this._iCustPrtPprWorkDB.SearchBlTbl( ref custPrtPprBlTblRsltWorkObj, custPrtPprBlnceWork, remainType, 0, ConstantManagement.LogicalMode.GetData0 );
                int rowNo = 0;
                // --- DEL m.suzuki 2010/12/20 ---------->>>>>
                # region // DEL
                //// 2010/04/15 Add �����ꗗ�\�����[�g����c���擾 >>>
                //DemandPrintAcs demandPrintAcs = new DemandPrintAcs();
                //ExtrInfo_DemandTotal extrInfoDemandTotal = new ExtrInfo_DemandTotal();
                //bool isOptSection = false;
                //bool isMainOfficeFunc = false;
                //string demandSectionCode;
                //Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
                //// ���_�I�v�V�����`�F�b�N
                //if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
                //{
                //    isOptSection = true;
                //}
                //else
                //{
                //    isOptSection = false;
                //#if CHG20060421
                //this._demandSectionCode = DemandPrintAcs.CT_AllSectionCode;
                //#else
                //#if CHG20060418
                //this._demandSectionCode = this._loginEmployee.BelongSectionCode;
                //#else
                //    demandSectionCode = loginEmployee.BelongSectionCode.TrimEnd();
                //#endif
                //#endif
                //    isMainOfficeFunc = demandPrintAcs.CheckMainOfficeFunc(loginEmployee.BelongSectionCode);
                //}
                //extrInfoDemandTotal.EnterpriseCode = custPrtPprBlnce.EnterpriseCode;
                //extrInfoDemandTotal.ResultsAddUpSecList = new string[1];
                //extrInfoDemandTotal.ResultsAddUpSecList[0] = sectionCode;
                //extrInfoDemandTotal.IsSelectAllSection = false;
                //extrInfoDemandTotal.IsOutputAllSecRec = false;
                //extrInfoDemandTotal.CustomerCodeSt = custPrtPprBlnce.ClaimCode;
                //extrInfoDemandTotal.CustomerCodeEd = custPrtPprBlnce.ClaimCode;
                //extrInfoDemandTotal.AccRecDivCd = 1;
                //extrInfoDemandTotal.DmdDtl = 1;
                //extrInfoDemandTotal.BalanceDepositDtl = 1;
                //extrInfoDemandTotal.IsMainOfficeFunc = isMainOfficeFunc;
                //extrInfoDemandTotal.IsOptSection = isOptSection;
                //string message;
                //string errDspMsg = null;
                //// 2010/04/15 Add <<<
                # endregion
                // --- DEL m.suzuki 2010/12/20 ----------<<<<<
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �擾�������ʂ��f�[�^�Z�b�g�ɃZ�b�g
                    foreach (CustPrtPprBlTblRsltWork data in (ArrayList)custPrtPprBlTblRsltWorkObj)
                    {
                        // --- DEL m.suzuki 2010/12/20 ---------->>>>>
                        # region // DEL
                        //// 2010/04/15 Add �����ꗗ�\�����[�g����c���擾 >>>
                        //if (remainType == 0)
                        //{
                        //    extrInfoDemandTotal.AddUpDate = data.AddUpDate;
                        //    status = demandPrintAcs.SearchDemandList(extrInfoDemandTotal, out message, out errDspMsg);
                        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //    {
                        //        RsltInfo_DemandTotalWork rsltInfoDemandTotalWork = new RsltInfo_DemandTotalWork();
                        //        if (demandPrintAcs.CustDmdPrcDataTable.Rows.Count != 0)
                        //        {
                        //            DataRow dr = demandPrintAcs.CustDmdPrcDataTable.Rows[0];

                        //            data.LastTimeBlc = Convert.ToInt64(dr["DemandBalance"]);
                        //        }
                        //    }
                        //}
                        //// 2010/04/15 Add <<<
                        # endregion
                        // --- DEL m.suzuki 2010/12/20 ----------<<<<<
                        try
                        {
                            DataRow row = this._dataSet.BalanceList.NewRow();

                            #region �c���ꗗ�f�[�^

                            row[this._dataSet.BalanceList.RowNoColumn.ColumnName] = rowNo;
                            row[this._dataSet.BalanceList.AddUpDateColumn.ColumnName] = data.AddUpDate;
                            row[this._dataSet.BalanceList.LastTimeBlcColumn.ColumnName] = data.LastTimeBlc;

                            row[this._dataSet.BalanceList.ThisTimeDmdNrmlColumn.ColumnName] = data.ThisTimeDmdNrml;
                            row[this._dataSet.BalanceList.ThisTimeTtlBlcColumn.ColumnName] = data.ThisTimeTtlBlc;
                            row[this._dataSet.BalanceList.ThisTimeSalesColumn.ColumnName] = data.ThisTimeSales;
                            row[this._dataSet.BalanceList.SalesPriceRgdsDisColumn.ColumnName] = data.SalesPricRgdsDis;
                            row[this._dataSet.BalanceList.OfsThisTimeSalesColumn.ColumnName] = data.OfsThisTimeSales;
                            row[this._dataSet.BalanceList.OfsThisSalesTaxColumn.ColumnName] = data.OfsThisSalesTax;
                            row[this._dataSet.BalanceList.AfCalBlcColumn.ColumnName] = data.AfCalBlc;
                            row[this._dataSet.BalanceList.SalesSlipCountColumn.ColumnName] = data.SalesSlipCount;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/07 ADD
                            row[this._dataSet.BalanceList.ThisSalesPricTotalColumn.ColumnName] = data.OfsThisTimeSales + data.OfsThisSalesTax;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/07 ADD

                            this._dataSet.BalanceList.Rows.Add(row);

                            #endregion // �c���ꗗ�f�[�^

                            rowNo++;

                        }
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                        //catch (ConstraintException)
                        //{
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                        catch (Exception exception)
                        {
                            string msg = exception.Message;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                    }   // 2010/04/15 Add �����ꗗ�\�����[�g����c���擾
                }


                return status;
            }
            finally
            {
                custPrtPprBlnce = custPrtPprBlnceBackup;
            }
        }

        // 2010/04/15 Add >>>
        /// <summary>
        /// �w�肳�ꂽ���Ӑ�͈̔͂Ŏc�����X�g���쐬���܂��B
        /// </summary>
        /// <param name="custPrtPprBlnce">��������</param>
        /// <param name="remainType">�c�����</param>
        /// <param name="customerList">���Ӑ惊�X�g</param>
        /// <returns>status</returns>
        /// <br>Update Note : 2010/09/28 tianjw</br>
        /// <br>              Redmine #15080 �e�L�X�g�o�͑Ή�</br>
        // --- UPD 2010/09/26 ---------->>>>>
        // public int SearchBalanceAll(ref CustPrtPprBlnce custPrtPprBlnce, int remainType, List<int> customerList)
        public int SearchBalanceAll(ref CustPrtPprBlnce custPrtPprBlnce, int remainType, List<CustomerInfo> customerList)
        // --- UPD 2010/09/26 ----------<<<<<
        {
            CustPrtPprBlnce custPrtPprBlnceBackup = custPrtPprBlnce.Clone();

            try
            {
                // �N���A
                this._dataSet.BalanceList.Rows.Clear();

                string sectionCodeSt;
                string sectionCodeEd;

                //---------------------------------
                // ���̓`�F�b�N
                //---------------------------------
                // ���_�R�[�h
                if (custPrtPprBlnce.SectionCode == null || custPrtPprBlnce.SectionCode.Length == 0)
                {
                    custPrtPprBlnce.SectionCode = new string[] { "00" };
                    sectionCodeSt = "00";
                    sectionCodeEd = "00";
                }
                else
                {
                    sectionCodeSt = custPrtPprBlnce.SectionCode[0].Trim();
                    sectionCodeEd = custPrtPprBlnce.SectionCode[custPrtPprBlnce.SectionCode.Length - 1].Trim();
                }
                string sectionCode = custPrtPprBlnce.SectionCode[0].Trim();

                int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                int rowNo = 0;

                // --- UPD 2010/09/26 ---------->>>>>
                //foreach (int customerCode in customerList)
                foreach (CustomerInfo customer in customerList)
                // --- UPD 2010/09/26 ----------<<<<<
                {
                    int customerCode = customer.CustomerCode;
                    if (customerCode != 0)
                    {
                        // --- DEL 2010/09/26 ---------->>>>>
                        // ���Ӑ�ǂݍ���
                        //CustomerInfo customer;
                        //int readStatus = _customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, custPrtPprBlnce.EnterpriseCode, customerCode, true, true, out customer);
                        //if (readStatus != 0 || customer == null || customer.LogicalDeleteCode != 0)
                        //{
                        //    continue;
                        //}
                        // --- DEL 2010/09/26 ----------<<<<<
                        // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
                        //sectionCode = customer.MngSectionCode.Trim();
                        // ���o���_�̎�ʂɂ���ċ��_�R�[�h��I������
                        if (custPrtPprBlnce.RemainSectionType.Equals((int)RemainSectionType.Mng))
                        {
                            sectionCode = customer.MngSectionCode.Trim();
                        }
                        else
                        {
                            sectionCode = customer.ClaimSectionCode.Trim();
                        }
                        // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<
                        //----------------------------------------------
                        // ���Ӑ�̂�
                        //----------------------------------------------
                        if (customer.CustomerCode == customer.ClaimCode)
                        {
                            // ------------ UPD 2010/09/28 ------------------------------------>>>>>
                            //if (sectionCodeSt == "00" && sectionCodeEd == "00" ||
                            //    Convert.ToInt32(sectionCodeSt) <= Convert.ToInt32(sectionCode) &&
                            //    Convert.ToInt32(sectionCodeEd) >= Convert.ToInt32(sectionCode))
                            if (sectionCodeSt == "00" && sectionCodeEd == "00" ||
                                Convert.ToInt32(sectionCodeSt) <= Convert.ToInt32(sectionCode) &&
                                Convert.ToInt32(sectionCodeEd) >= Convert.ToInt32(sectionCode) ||
                                sectionCodeEd == "00" && Convert.ToInt32(sectionCodeSt) <= Convert.ToInt32(sectionCode))
                            // ------------ UPD 2010/09/28 ------------------------------------<<<<<
                            {
                                custPrtPprBlnce.CustomerCode = 0;
                                custPrtPprBlnce.ClaimCode = customer.ClaimCode;
                                custPrtPprBlnce.SectionCode[0] = sectionCode;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                        //---------------------------------
                        // �p�����[�^�N���X���쐬
                        //---------------------------------
                        CustPrtPprBlnceWork custPrtPprBlnceWork = new CustPrtPprBlnceWork();
                        CustPrtPprBlnce2CustPrtPprBlnceWork(ref custPrtPprBlnce, ref custPrtPprBlnceWork);

                        //---------------------------------
                        // �Ԃ�l�Ŏg�p����N���X���쐬
                        //---------------------------------
                        CustPrtPprBlTblRsltWork custPrtPprBlTblRsltWork = new CustPrtPprBlTblRsltWork();
                        object custPrtPprBlTblRsltWorkObj = (object)custPrtPprBlTblRsltWork;

                        // readMode, logicalMode�͌��󖢎g�p
                        // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
                        //status = this._iCustPrtPprWorkDB.SearchBlTbl(ref custPrtPprBlTblRsltWorkObj, custPrtPprBlnceWork, remainType, 0, ConstantManagement.LogicalMode.GetData0);
                        if (custPrtPprBlnce.CreditMoneyOutputDiv)
                        {
                            // �c���ꗗ�\�������i�^�M�c���o�͗p�j
                            status = this._iCustPrtPprWorkDB.SearchBlTblOutput(ref custPrtPprBlTblRsltWorkObj, custPrtPprBlnceWork, remainType, 0, ConstantManagement.LogicalMode.GetData0, custPrtPprBlnce.CreditMoneyOutputDiv);
                        }
                        else
                        {
                            // �c���ꗗ�\������
                            status = this._iCustPrtPprWorkDB.SearchBlTbl(ref custPrtPprBlTblRsltWorkObj, custPrtPprBlnceWork, remainType, 0, ConstantManagement.LogicalMode.GetData0);
                        }
                        // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            DemandPrintAcs demandPrintAcs = new DemandPrintAcs();
                            ExtrInfo_DemandTotal extrInfoDemandTotal = new ExtrInfo_DemandTotal();
                            bool isOptSection = false;
                            bool isMainOfficeFunc = false;
                            string demandSectionCode;
                            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
                            // ���_�I�v�V�����`�F�b�N
                            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
                            {
                                isOptSection = true;
                            }
                            else
                            {
                                isOptSection = false;
#if CHG20060421
                this._demandSectionCode = DemandPrintAcs.CT_AllSectionCode;
#else
#if CHG20060418
				this._demandSectionCode = this._loginEmployee.BelongSectionCode;
#else
                                demandSectionCode = loginEmployee.BelongSectionCode.TrimEnd();
#endif
#endif
                                isMainOfficeFunc = demandPrintAcs.CheckMainOfficeFunc(loginEmployee.BelongSectionCode);
                            }
                            extrInfoDemandTotal.EnterpriseCode = customer.EnterpriseCode;
                            extrInfoDemandTotal.ResultsAddUpSecList = new string[1];
                            extrInfoDemandTotal.ResultsAddUpSecList[0] = sectionCode;
                            extrInfoDemandTotal.IsSelectAllSection = false;
                            extrInfoDemandTotal.IsOutputAllSecRec = false;
                            extrInfoDemandTotal.CustomerCodeSt = customerCode;
                            extrInfoDemandTotal.CustomerCodeEd = customerCode;
                            extrInfoDemandTotal.AccRecDivCd = 1;
                            extrInfoDemandTotal.DmdDtl = 1;
                            extrInfoDemandTotal.BalanceDepositDtl = 1;
                            extrInfoDemandTotal.IsMainOfficeFunc = isMainOfficeFunc;
                            extrInfoDemandTotal.IsOptSection = isOptSection;
                            string message;
                            string errDspMsg = null;
                            // �擾�������ʂ��f�[�^�Z�b�g�ɃZ�b�g
                            // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
                            #region  DEL
                            //foreach (CustPrtPprBlTblRsltWork data in (ArrayList)custPrtPprBlTblRsltWorkObj)
                            //{
                            //    if (remainType == 0)
                            //    {
                            //        extrInfoDemandTotal.AddUpDate = data.AddUpDate;
                            //        status = demandPrintAcs.SearchDemandList(extrInfoDemandTotal, out message, out errDspMsg);
                            //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            //        {
                            //            RsltInfo_DemandTotalWork rsltInfoDemandTotalWork = new RsltInfo_DemandTotalWork();
                            //            if (demandPrintAcs.CustDmdPrcDataTable.Rows.Count != 0)
                            //            {
                            //                DataRow dr = demandPrintAcs.CustDmdPrcDataTable.Rows[0];

                            //                data.LastTimeBlc = Convert.ToInt64(dr["DemandBalance"]);
                            //            }
                            //        }
                            //    }
                            //    try
                            //    {
                            //        DataRow row = this._dataSet.BalanceList.NewRow();

                            //        #region �c���ꗗ�f�[�^

                            //        row[this._dataSet.BalanceList.RowNoColumn.ColumnName] = rowNo;
                            //        row[this._dataSet.BalanceList.CustomerNameColumn.ColumnName] = customer.CustomerSnm;
                            //        row[this._dataSet.BalanceList.CustomerCodeColumn.ColumnName] = customer.CustomerCode;
                            //        row[this._dataSet.BalanceList.SectionCodeColumn.ColumnName] = sectionCode;
                            //        row[this._dataSet.BalanceList.AddUpDateColumn.ColumnName] = data.AddUpDate;
                            //        row[this._dataSet.BalanceList.LastTimeBlcColumn.ColumnName] = data.LastTimeBlc;
                            //        row[this._dataSet.BalanceList.ThisTimeDmdNrmlColumn.ColumnName] = data.ThisTimeDmdNrml;
                            //        row[this._dataSet.BalanceList.ThisTimeTtlBlcColumn.ColumnName] = data.ThisTimeTtlBlc;
                            //        row[this._dataSet.BalanceList.ThisTimeSalesColumn.ColumnName] = data.ThisTimeSales;
                            //        row[this._dataSet.BalanceList.SalesPriceRgdsDisColumn.ColumnName] = data.SalesPricRgdsDis;
                            //        row[this._dataSet.BalanceList.OfsThisTimeSalesColumn.ColumnName] = data.OfsThisTimeSales;
                            //        row[this._dataSet.BalanceList.OfsThisSalesTaxColumn.ColumnName] = data.OfsThisSalesTax;
                            //        row[this._dataSet.BalanceList.AfCalBlcColumn.ColumnName] = data.AfCalBlc;
                            //        row[this._dataSet.BalanceList.SalesSlipCountColumn.ColumnName] = data.SalesSlipCount;
                            //        row[this._dataSet.BalanceList.ThisSalesPricTotalColumn.ColumnName] = data.OfsThisTimeSales + data.OfsThisSalesTax;
                            //        this._dataSet.BalanceList.Rows.Add(row);

                            //        #endregion // �c���ꗗ�f�[�^

                            //        rowNo++;

                            //    }
                            //    catch (Exception exception)
                            //    {
                            //        string msg = exception.Message;
                            //        break;
                            //    }
                            //}
                            #endregion
                            // �^�M�c���o�͂̎�
                            if (custPrtPprBlnce.CreditMoneyOutputDiv)
                            {
                                foreach (CustPrtPprBlTblRsltWork data in (ArrayList)custPrtPprBlTblRsltWorkObj)
                                {
                                    // �J�n�N���̑O���̃f�[�^�͏o�͑ΏۊO�Ƃ���
                                    if (data.AddUpYearMonth < custPrtPprBlnce.Input_St_AddUpYearMonth)
                                    {
                                        continue;
                                    }
                                    if (remainType == 0)
                                    {
                                        extrInfoDemandTotal.AddUpDate = data.AddUpDate;
                                        status = demandPrintAcs.SearchDemandList(extrInfoDemandTotal, out message, out errDspMsg);
                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            RsltInfo_DemandTotalWork rsltInfoDemandTotalWork = new RsltInfo_DemandTotalWork();
                                            if (demandPrintAcs.CustDmdPrcDataTable.Rows.Count != 0)
                                            {
                                                DataRow dr = demandPrintAcs.CustDmdPrcDataTable.Rows[0];

                                                data.LastTimeBlc = Convert.ToInt64(dr["DemandBalance"]);
                                            }
                                        }
                                    }
                                    try
                                    {
                                        DataRow row = this._dataSet.BalanceList.NewRow();

                                        #region �c���ꗗ�f�[�^

                                        row[this._dataSet.BalanceList.RowNoColumn.ColumnName] = rowNo;
                                        row[this._dataSet.BalanceList.CustomerNameColumn.ColumnName] = customer.CustomerSnm;
                                        row[this._dataSet.BalanceList.CustomerCodeColumn.ColumnName] = customer.CustomerCode;
                                        row[this._dataSet.BalanceList.SectionCodeColumn.ColumnName] = sectionCode;
                                        row[this._dataSet.BalanceList.AddUpDateColumn.ColumnName] = data.AddUpDate;
                                        row[this._dataSet.BalanceList.LastTimeBlcColumn.ColumnName] = data.LastTimeBlc;
                                        row[this._dataSet.BalanceList.ThisTimeDmdNrmlColumn.ColumnName] = data.ThisTimeDmdNrml;
                                        row[this._dataSet.BalanceList.ThisTimeTtlBlcColumn.ColumnName] = data.ThisTimeTtlBlc;
                                        row[this._dataSet.BalanceList.ThisTimeSalesColumn.ColumnName] = data.ThisTimeSales;
                                        row[this._dataSet.BalanceList.SalesPriceRgdsDisColumn.ColumnName] = data.SalesPricRgdsDis;
                                        row[this._dataSet.BalanceList.OfsThisTimeSalesColumn.ColumnName] = data.OfsThisTimeSales;
                                        row[this._dataSet.BalanceList.OfsThisSalesTaxColumn.ColumnName] = data.OfsThisSalesTax;
                                        row[this._dataSet.BalanceList.AfCalBlcColumn.ColumnName] = data.AfCalBlc;
                                        row[this._dataSet.BalanceList.SalesSlipCountColumn.ColumnName] = data.SalesSlipCount;
                                        row[this._dataSet.BalanceList.ThisSalesPricTotalColumn.ColumnName] = data.OfsThisTimeSales + data.OfsThisSalesTax;
                                        row[this._dataSet.BalanceList.ClaimSectionCodeColumn.ColumnName] = customer.ClaimSectionCode;
                                        // �^�M�敪
                                        string creditMngCodeName = string.Empty;
                                        if (data.CreditMngCode.Equals(0)) creditMngCodeName = "0:���Ȃ�";
                                        else creditMngCodeName = "1:����";
                                        row[this._dataSet.BalanceList.CreditMngCodeColumn.ColumnName] = creditMngCodeName;
                                        row[this._dataSet.BalanceList.CreditMoneyColumn.ColumnName] = data.CreditMoney;
                                        row[this._dataSet.BalanceList.WarningCreditMoneyColumn.ColumnName] = data.WarningCreditMoney;
                                        row[this._dataSet.BalanceList.PrsntAccRecBalanceColumn.ColumnName] = data.PrsntAccRecBalance;
                                        row[this._dataSet.BalanceList.TotalDayColumn.ColumnName] = customer.TotalDay;
                                        row[this._dataSet.BalanceList.CompanyTotalDayColumn.ColumnName] = data.CompanyTotalDay;
                                        // �����E�������يz
                                        // ���������E���В�����������
                                        if (customer.TotalDay.Equals(data.CompanyTotalDay))
                                        {
                                            // �O���f�[�^�擾
                                            long difference = 0;
                                            foreach (CustPrtPprBlTblRsltWork data2 in (ArrayList)custPrtPprBlTblRsltWorkObj)
                                            {
                                                if (data2.AddUpYearMonth < data.AddUpYearMonth) difference = data2.AfCalDemandPrice - data2.AfCalBlc;
                                                if (data2.AddUpYearMonth >= data.AddUpYearMonth) break;
                                            }
                                            row[this._dataSet.BalanceList.DifferenceColumn.ColumnName] = difference.ToString("#,##0;-#,##0;");
                                            row[this._dataSet.BalanceList.CreditDifferenceColumn.ColumnName] = data.PrsntAccRecBalance - difference - data.AfCalBlc;
                                        }
                                        else
                                        {
                                            row[this._dataSet.BalanceList.DifferenceColumn.ColumnName] = "-";
                                            row[this._dataSet.BalanceList.CreditDifferenceColumn.ColumnName] = data.PrsntAccRecBalance - data.AfCalBlc;
                                        }
                                        // ���|�敪
                                        string accRecDivCdName = string.Empty;
                                        if (data.AccRecDivCd.Equals(0)) accRecDivCdName = "0:���|�Ȃ�";
                                        else accRecDivCdName = "1:���|";
                                        row[this._dataSet.BalanceList.AccRecDivCdColumn.ColumnName] = accRecDivCdName;

                                        // ADD 2013/04/12 zhujw Redmine#35205 --------------------->>>>>
                                        //�����X�V����薢���̃��R�[�h�ɂ������^�M�敪,�^�M�z,�x���^�M�z,�^�M���|�c��,��������,��������,�����E�������يz,�^�M�z����,���|�敪��ɂ��Ă͑S�ċ󔒂ŏo��
                                        if (data.CreditMngCode.Equals(2))
                                        {
                                            row[this._dataSet.BalanceList.CreditMngCodeColumn.ColumnName] = string.Empty;
                                            row[this._dataSet.BalanceList.CreditMoneyColumn.ColumnName] = DBNull.Value;
                                            row[this._dataSet.BalanceList.WarningCreditMoneyColumn.ColumnName] = DBNull.Value;
                                            row[this._dataSet.BalanceList.PrsntAccRecBalanceColumn.ColumnName] = DBNull.Value;
                                            row[this._dataSet.BalanceList.TotalDayColumn.ColumnName] = DBNull.Value;
                                            row[this._dataSet.BalanceList.CompanyTotalDayColumn.ColumnName] = DBNull.Value;
                                            row[this._dataSet.BalanceList.DifferenceColumn.ColumnName] = string.Empty;
                                            row[this._dataSet.BalanceList.CreditDifferenceColumn.ColumnName] = DBNull.Value;
                                            row[this._dataSet.BalanceList.AccRecDivCdColumn.ColumnName] = string.Empty;
                                        }
                                        // ADD 2013/04/12 zhujw Redmine#35205 ---------------------<<<<<

                                        this._dataSet.BalanceList.Rows.Add(row);

                                        #endregion // �c���ꗗ�f�[�^

                                        rowNo++;

                                    }
                                    catch (Exception exception)
                                    {
                                        string msg = exception.Message;
                                        break;
                                    }
                                }
                            }
                            // �^�M�c���o�͂Ȃ��̎�
                            else
                            {
                                foreach (CustPrtPprBlTblRsltWork data in (ArrayList)custPrtPprBlTblRsltWorkObj)
                                {
                                    if (remainType == 0)
                                    {
                                        extrInfoDemandTotal.AddUpDate = data.AddUpDate;
                                        status = demandPrintAcs.SearchDemandList(extrInfoDemandTotal, out message, out errDspMsg);
                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            RsltInfo_DemandTotalWork rsltInfoDemandTotalWork = new RsltInfo_DemandTotalWork();
                                            if (demandPrintAcs.CustDmdPrcDataTable.Rows.Count != 0)
                                            {
                                                DataRow dr = demandPrintAcs.CustDmdPrcDataTable.Rows[0];

                                                data.LastTimeBlc = Convert.ToInt64(dr["DemandBalance"]);
                                            }
                                        }
                                    }
                                    try
                                    {
                                        DataRow row = this._dataSet.BalanceList.NewRow();

                                        #region �c���ꗗ�f�[�^

                                        row[this._dataSet.BalanceList.RowNoColumn.ColumnName] = rowNo;
                                        row[this._dataSet.BalanceList.CustomerNameColumn.ColumnName] = customer.CustomerSnm;
                                        row[this._dataSet.BalanceList.CustomerCodeColumn.ColumnName] = customer.CustomerCode;
                                        row[this._dataSet.BalanceList.SectionCodeColumn.ColumnName] = sectionCode;
                                        row[this._dataSet.BalanceList.AddUpDateColumn.ColumnName] = data.AddUpDate;
                                        row[this._dataSet.BalanceList.LastTimeBlcColumn.ColumnName] = data.LastTimeBlc;
                                        row[this._dataSet.BalanceList.ThisTimeDmdNrmlColumn.ColumnName] = data.ThisTimeDmdNrml;
                                        row[this._dataSet.BalanceList.ThisTimeTtlBlcColumn.ColumnName] = data.ThisTimeTtlBlc;
                                        row[this._dataSet.BalanceList.ThisTimeSalesColumn.ColumnName] = data.ThisTimeSales;
                                        row[this._dataSet.BalanceList.SalesPriceRgdsDisColumn.ColumnName] = data.SalesPricRgdsDis;
                                        row[this._dataSet.BalanceList.OfsThisTimeSalesColumn.ColumnName] = data.OfsThisTimeSales;
                                        row[this._dataSet.BalanceList.OfsThisSalesTaxColumn.ColumnName] = data.OfsThisSalesTax;
                                        row[this._dataSet.BalanceList.AfCalBlcColumn.ColumnName] = data.AfCalBlc;
                                        row[this._dataSet.BalanceList.SalesSlipCountColumn.ColumnName] = data.SalesSlipCount;
                                        row[this._dataSet.BalanceList.ThisSalesPricTotalColumn.ColumnName] = data.OfsThisTimeSales + data.OfsThisSalesTax;
                                        this._dataSet.BalanceList.Rows.Add(row);

                                        #endregion // �c���ꗗ�f�[�^

                                        rowNo++;

                                    }
                                    catch (Exception exception)
                                    {
                                        string msg = exception.Message;
                                        break;
                                    }
                                }
                            }
                            // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<

                        }
                    }
                }

                return status;
            }
            // --- UPD 2020/12/21 �x���Ή� ---------->>>>>
            //catch(Exception ex)
            catch (Exception)
            // --- UPD 2020/12/21 �x���Ή� ----------<<<<<
            {
                throw;
            }
            finally
            {
                custPrtPprBlnce = custPrtPprBlnceBackup;
            }
        }
        // 2010/04/15 Add <<<
        // ------------DEL wangf 2013/01/30 FOR Redmine#34513--------->>>>
        //// ------------ADD wangf 2013/01/30 FOR Redmine#34513--------->>>>
        ///// <summary>
        ///// ���O���b�Z�[�W�L�^
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="pgName">PG��</param>
        ///// <param name="message">���b�Z�[�W</param>
        ///// <param name="logDataObjAssemblyID">�A�Z���u����</param>
        ///// <param name="logDataOperationCd">�����敪</param>
        ///// <param name="belongSectionCode">���O�C�����_</param>
        ///// <remarks>
        ///// <br>Note		: ���O���b�Z�[�W�L�^���s���B</br>
        ///// <br>Programmer	: wangf</br>
        ///// <br>Date		: 2013/01/30</br>
        ///// </remarks>
        //public void WriteLogMessage(string enterpriseCode, string pgName, string message, string logDataObjAssemblyID, int logDataOperationCd, string belongSectionCode)
        //{
        //    ArrayList writeList = new ArrayList();
        //    OprtnHisLogWork oprtnhislogWork = new OprtnHisLogWork();
        //    # region [�������ݓ��e�̃Z�b�g]
        //    Broadleaf.Library.Diagnostics.LogTextData logTextData = new Broadleaf.Library.Diagnostics.LogTextData("", "", 0, new Exception());
        //    oprtnhislogWork.EnterpriseCode = enterpriseCode;
        //    oprtnhislogWork.LogDataObjAssemblyID = logDataObjAssemblyID;
        //    oprtnhislogWork.LogDataObjAssemblyNm = pgName;
        //    oprtnhislogWork.LogDataObjClassID = this.GetType().Name;
        //    oprtnhislogWork.LogDataOperationCd = logDataOperationCd;
        //    oprtnhislogWork.LogDataMassage = message;
        //    oprtnhislogWork.LogDataCreateDateTime = DateTime.Now;
        //    oprtnhislogWork.LogDataMachineName = logTextData.GenerationServerUserId;
        //    oprtnhislogWork.LoginSectionCd = belongSectionCode;
        //    # endregion
        //    writeList.Add(oprtnhislogWork);
        //    object writeObj = writeList;
        //    _iOprtnHisLogDB.Write(ref writeObj);
        //}
        //// ------------ADD wangf 2013/01/30 FOR Redmine#34513---------<<<<
        // ------------DEL wangf 2013/01/30 FOR Redmine#34513---------<<<<

        /// <summary>
        /// �������ʂ���f�[�^�e�[�u�����쐬
        /// </summary>
        /// <param name="custPrtPprSalTblRsltWork">�������ʃN���X</param>
        /// <returns></returns>
        private bool AddRowDataFromSearchResult(CustPrtPprSalTblRsltWork custPrtPprSalTblRsltWork)
        {
            // �`�[�E���׌������ʃN���X���f�[�^�Z�b�g���쐬

            DataRow newDetailRow = this._dataSet.SalesDetail.NewRow();      // ����
            DataRow newSlipRow = this._dataSet.SalesList.NewRow();          // �`�[
            

            //newDetailRow[

            return true;
        }

        /// <summary>
        /// �p�����[�^�N���X(PMKAU04002E.CustPrtPpr)���烊���[�g�p�����[�^�N���X(PMKAU04016D.CustPrtPprWork)�N���X�֕ϊ�
        /// </summary>
        /// <param name="custPrtPpr"></param>
        /// <param name="custPrtPprWork"></param>
        /// <br>Update Note : 2011/11/28 �k�m ���Ӑ�d�q����/(BL�߰µ��ް����)�⍇���ԍ��̒ǉ�</br>
        /// <br>Update Note : K2015/06/16 鸏�</br>
        /// <br>�Ǘ��ԍ�    : 11101427-00</br>
        /// <br>            : ���C�S�����Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����B</br>
        /// <br>Update Note : 2016/01/21 �e�c ���V</br>
        /// <br>�Ǘ��ԍ�    : 11270007-00</br>
        /// <br>            : �d�|�ꗗ��2808 �ݏo�󒍑Ή�</br>
        /// <br>            : �@���������Ɂu�o�׏󋵁v���ڂ�ǉ�</br>
        /// <br>            : �A���ו\���Ɍv�㐔�A���v�㐔���ڂ�ǉ�</br>
        /// <br>Update Note : K2016/02/23 ���V��</br>
        /// <br>              ���C�P���g ���o�����ɂĎ󒍍쐬�敪��ǉ�����Ή�</br>
        private void CustPrtPpr2CustPrtPprWork(ref CustPrtPpr custPrtPpr, ref CustPrtPprWork custPrtPprWork)
        {
            custPrtPprWork.AcptAnOdrStatus = custPrtPpr.AcptAnOdrStatus;
            custPrtPprWork.BLGoodsCode = custPrtPpr.BLGoodsCode;
            custPrtPprWork.BLGroupCode = custPrtPpr.BLGroupCode;
            custPrtPprWork.CarMngCode = custPrtPpr.CarMngCode;
            custPrtPprWork.ClaimCode = custPrtPpr.ClaimCode;
            custPrtPprWork.ColorName1 = custPrtPpr.ColorName1;
            custPrtPprWork.CustomerCode = custPrtPpr.CustomerCode;
            custPrtPprWork.DataSendCode = custPrtPpr.DataSendCode;
            custPrtPprWork.DtlNote = custPrtPpr.DtlNote;
            custPrtPprWork.Ed_AddUpADate = custPrtPpr.Ed_AddUpADate;
            custPrtPprWork.Ed_SalesDate = custPrtPpr.Ed_SalesDate;
            custPrtPprWork.EnterpriseCode = custPrtPpr.EnterpriseCode;
            custPrtPprWork.EnterpriseGanreCode = custPrtPpr.EnterpriseGanreCode;
            custPrtPprWork.FrontEmployeeCd = custPrtPpr.FrontEmployeeCd;
            custPrtPprWork.FullModel = custPrtPpr.FullModel;
            custPrtPprWork.GoodsMakerCd = custPrtPpr.GoodsMakerCd;
            custPrtPprWork.GoodsName = custPrtPpr.GoodsName;
            custPrtPprWork.GoodsNo = custPrtPpr.GoodsNo;
            custPrtPprWork.ModelFullName = custPrtPpr.ModelFullName;
            custPrtPprWork.PartySaleSlipNum = custPrtPpr.PartySaleSlipNum;
            custPrtPprWork.SalesCode = custPrtPpr.SalesCode;
            custPrtPprWork.SalesEmployeeCd = custPrtPpr.SalesEmployeeCd;
            custPrtPprWork.SalesInputCode = custPrtPpr.SalesInputCode;
            custPrtPprWork.SalesOrderDivCd = custPrtPpr.SalesOrderDivCd;
            custPrtPprWork.SalesSlipCd = custPrtPpr.SalesSlipCd;
            custPrtPprWork.SalesSlipNum = custPrtPpr.SalesSlipNum;
            custPrtPprWork.SearchCnt = custPrtPpr.SearchCnt;
            custPrtPprWork.SearchFrameNo = custPrtPpr.SearchFrameNo;
            custPrtPprWork.FrameNo = custPrtPpr.FrameNo;// ADD 2010/08/05
            custPrtPprWork.SearchType = custPrtPpr.SearchType;
            custPrtPprWork.SectionCode = custPrtPpr.SectionCode;
            custPrtPprWork.SlipNote = custPrtPpr.SlipNote;
            custPrtPprWork.SlipNote2 = custPrtPpr.SlipNote2;
            custPrtPprWork.SlipNote3 = custPrtPpr.SlipNote3;
            custPrtPprWork.St_AddUpADate = custPrtPpr.St_AddUpADate;
            custPrtPprWork.St_SalesDate = custPrtPpr.St_SalesDate;
            custPrtPprWork.SupplierCd = custPrtPpr.SupplierCd;
            custPrtPprWork.SupplierSlipNo = custPrtPpr.SupplierSlipNo;
            custPrtPprWork.TrimName = custPrtPpr.TrimName;
            custPrtPprWork.UoeRemark1 = custPrtPpr.UoeRemark1;
            custPrtPprWork.UoeRemark2 = custPrtPpr.UoeRemark2;
            custPrtPprWork.UOESupplierCd = custPrtPpr.UOESupplierCd;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
            custPrtPprWork.AddresseeCode = custPrtPpr.AddresseeCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD
            custPrtPprWork.WarehouseCode = custPrtPpr.WarehouseCode;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
            custPrtPprWork.GoodsKindCode = custPrtPpr.GoodsKindCode; // ���i����
            custPrtPprWork.GoodsLGroup = custPrtPpr.GoodsLGroup; // ���i�啪�ރR�[�h
            custPrtPprWork.GoodsMGroup = custPrtPpr.GoodsMGroup; // ���i�����ރR�[�h
            custPrtPprWork.WarehouseShelfNo = custPrtPpr.WarehouseShelfNo; // �I��
            custPrtPprWork.SalesSlipCdDtl = custPrtPpr.SalesSlipCdDtl; // ����`�[�敪(����)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD
            custPrtPprWork.AutoAnswerDivSCM = custPrtPpr.AutoAnswerDivSCM; // ������// add 2011/07/18 ���R
            //---ADD START 2011/11/28 �k�m ----------------------------------->>>>>
            custPrtPprWork.InquiryNumber = custPrtPpr.InquiryNumber; //�⍇���ԍ�
            //---ADD END 2011/11/28 �k�m -----------------------------------<<<<<
            // ---------- ADD 2016/01/21 Y.Wakita ---------->>>>>
            custPrtPprWork.AddUpRemDiv = custPrtPpr.AddUpRemDiv;    // �o�׏�
            // ---------- ADD 2016/01/21 Y.Wakita ----------<<<<<
            //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
            custPrtPprWork.SalesAreaCode = custPrtPpr.SalesAreaCode;
            custPrtPprWork.CustAnalysCode1 = custPrtPpr.CustAnalysCode1;
            custPrtPprWork.CustAnalysCode2 = custPrtPpr.CustAnalysCode2;
            custPrtPprWork.CustAnalysCode3 = custPrtPpr.CustAnalysCode3;
            custPrtPprWork.CustAnalysCode4 = custPrtPpr.CustAnalysCode4;
            custPrtPprWork.CustAnalysCode5 = custPrtPpr.CustAnalysCode5;
            custPrtPprWork.CustAnalysCode6 = custPrtPpr.CustAnalysCode6;
            //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<
            custPrtPprWork.AcptAnOdrMakeDiv = custPrtPpr.AcptAnOdrMakeDiv; // ADD K2016/02/23 ���V�� ���C�P���g ���o�����ɂĎ󒍍쐬�敪��ǉ�����Ή�
        }

        /// <summary>
        /// �p�����[�^�N���X(PMKAU04002E.CustPrtPprBlnce)���烊���[�g�p�����[�^�N���X(PMKAU04016D.CustPrtPprBlnceWork)�N���X�֕ϊ�
        /// </summary>
        /// <param name="custPrtPpr"></param>
        /// <param name="custPrtPprWork"></param>
        private void CustPrtPprBlnce2CustPrtPprBlnceWork(ref CustPrtPprBlnce custPrtPprBlnce, ref CustPrtPprBlnceWork custPrtPprBlnceWork)
        {
            custPrtPprBlnceWork.EnterpriseCode = custPrtPprBlnce.EnterpriseCode;
            custPrtPprBlnceWork.SectionCode = custPrtPprBlnce.SectionCode;
            custPrtPprBlnceWork.CustomerCode = custPrtPprBlnce.CustomerCode;
            custPrtPprBlnceWork.ClaimCode = custPrtPprBlnce.ClaimCode;
            custPrtPprBlnceWork.St_AddUpYearMonth = custPrtPprBlnce.St_AddUpYearMonth;
            custPrtPprBlnceWork.Ed_AddUpYearMonth = custPrtPprBlnce.Ed_AddUpYearMonth;
        }

        # region [�c���\�����]
        /// <summary>
        /// �c���\�����
        /// </summary>
        public struct RemainDataExtra
        {
            /// <summary>���񔄏�</summary>
            private Int64 _ofsThisTimeSales;
            /// <summary>�����</summary>
            private Int64 _ofsThisSalesTax;
            /// <summary>�������</summary>
            private Int64 _thisTimeDmdNrml;
            /// <summary>�������z</summary>
            private Int64 _afCalBlc;
            /// <summary>���J�n��</summary>
            private DateTime _dmdStDay;
            /// <summary>��������</summary>
            private DateTime _totalDay;
            /// <summary>�e�t���O</summary>
            private bool _isParent;
            /// <summary>
            /// ���񔄏�
            /// </summary>
            public Int64 OfsThisTimeSales
            {
                get { return _ofsThisTimeSales; }
                set { _ofsThisTimeSales = value; }
            }
            /// <summary>
            /// �����
            /// </summary>
            public Int64 OfsThisSalesTax
            {
                get { return _ofsThisSalesTax; }
                set { _ofsThisSalesTax = value; }
            }
            /// <summary>
            /// �������
            /// </summary>
            public Int64 ThisTimeDmdNrml
            {
                get { return _thisTimeDmdNrml; }
                set { _thisTimeDmdNrml = value; }
            }
            /// <summary>
            /// �������z
            /// </summary>
            public Int64 AfCalBlc
            {
                get { return _afCalBlc; }
                set { _afCalBlc = value; }
            }
            /// <summary>
            /// ���J�n��
            /// </summary>
            public DateTime DmdStDay
            {
                get { return _dmdStDay; }
                set { _dmdStDay = value; }
            }
            /// <summary>
            /// ��������
            /// </summary>
            public DateTime TotalDay
            {
                get { return _totalDay; }
                set { _totalDay = value; }
            }
            /// <summary>
            /// �e�t���O
            /// </summary>
            public bool IsParent
            {
                get { return _isParent; }
                set { _isParent = value; }
            }
        }
        # endregion
    }
}
