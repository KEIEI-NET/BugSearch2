using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
//using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
// --- ADD 2012/09/13 ---------->>>>>
using Broadleaf.Application.Resources;
// --- ADD 2012/09/13 ----------<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �d����d�q�����f�[�^�擾�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d����d�q�����̃A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 30418 ���i</br>
    /// <br>Date       : 2008.09.09</br>
    /// <br></br>
    /// <br>UpdateNote : 2009.02.14 22018 ��ؐ��b</br>
    /// <br>             �@�S�̓I�ɏC���B</br>
    /// <br></br>
    /// <br>Update Note: 2009/09/08 ���̕�</br>
    /// <br>             PM.NS-2-B�E�o�l�D�m�r�ێ�˗��@</br>
    /// <br>                       �ߋ����\���Ή�</br>
    /// <br>Update Note: 2010/01/26 �H���b�D</br>
    /// <br>             MANTIS[14325]�Ή��F�C���X�g�[������Ɏd���`�[�~1�Ǝx���`�[�~1��o�^������ԂŌ�������ƁA�d���`�[���\������Ȃ�</br>
    /// <br>UpdateNote : 2010/01/27 30434 �H�� �b�D</br>
    /// <br>           �@��QID:14545�Ή� ���Ӑ�d�q�����Ɠ��l�̑��x�A�b�v�Ή��i2009/10/07���{�j�̑g�ݍ���</br>
    /// <br>UpdateNote : 2010/07/20 chenyd</br>
    /// <br>           �@�e�L�X�g�o�͑Ή�</br>
    /// <br>UpdateNote : 2011/11/24 ������</br>
    /// <br>             redmine#8078�@�d����d�q����/�W�����i�̕��я��͂�������</br>
    /// <br>UpdateNote : 2011/12/09 ������</br>
    /// <br>             �x���f�[�^�����G���[�̑Ή�</br>
    /// <br>Update Note: 2012/04/05 �����H</br>						
    /// <br>             2012/05/24�z�M�� Redmine#29310�@���v���̕s��ɂ��Ă̏C��</br>
    /// <br>Update Note: 2012/06/19 tianjw</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 2012/07/25�z�M��</br>
    /// <br>             Redmine#30529 �ŗ��Q�Ƃ̕s��̑Ή�</br>
    /// <br>Update Note: 2012/06/26 �ɓ� �L</br>
    /// <br>             �d�b�Ή�No.1027 �����I�[�o�[���Ƀ��b�Z�[�W��\��</br>
    /// <br>Update Note: 2012/09/13 FSI��k�c �G��</br>
    /// <br>             �d���摍���Ή��̒ǉ�</br> 
    /// <br>Update Note: 2012/10/15 �c����</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00�A2012/11/14�z�M��</br>
    /// <br>             Redmine#32862 ���i�ύX�������ׁA�F��ς���悤�ɏC��</br>
    /// <br>Update Note: 2012/10/30 �c����</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00�A2012/11/14�z�M��</br>
    /// <br>             Redmine#32862#20 �d���f�[�^�ɓ��͋敪�u���v�v�ō쐬���āA����������Ώۂɂ����ꍇ�A�V�X�e���G���[�ƂȂ�C��</br>
    /// <br>Update Note: 2013/01/21 FSI�y�~ �їR��</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00</br>
    /// <br>             [�d���ԕi�v��] 1.�I���`�F�b�N�{�b�N�X�ݒ�ǉ�,�ԕi�v��ɕK�v�ȃf�[�^�����ǉ�</br>
    /// <br>                            2.�ԕi�\��f�[�^�����@�\�ǉ�</br>
    /// <br>Update Note: 2013/02/16 �A����</br>�@ 
    /// <br>�Ǘ��ԍ�   : 10900691-00  2013/03/13�z�M��</br>
    /// <br>           : Redmine#34618 �d����d�q�����̍��v��ʂŏ���ł�����Ȃ���Q�̏C��</br>
    /// <br>Update Note: 2013/04/18 ���N</br>
    /// <br>�Ǘ��ԍ� �@: 10801804-00 2013/05/15�z�M��</br>
    /// <br>           : Redmine#35363 �d����d�q�����̓`�[�\���ɔw�i�F�s��̑Ή�</br>
    /// <br>Update Note: 2013/05/15 huangt </br>
    /// <br>�Ǘ��ԍ�   : 10902175-00 6��18���z�M���i��Q�ȊO�j</br>
    /// <br>           : Redmine#35640 �d����d�q���� �e�L�X�g�o�� ����ł��o�͂���Ȃ��̏C��</br>
    /// <br>Update Note: 2013/11/25 huangt </br>
    /// <br>�Ǘ��ԍ�   : 10902175-00 6��18���z�M���i��Q�ȊO�j</br>
    /// <br>           : Redmine#35640 �����̏ꍇ�͏���ł��o�͂��Ȃ��悤�ɏC��</br>
    /// <br></br>
    /// </remarks>
    public partial class SuppPrtSlipSearchAcs
    {

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SuppPrtSlipSearchAcs()
        {
            // �����[�g�C���X�^���X�擾
            this._iSuppPrtPprWorkDB = MediationSuppPrtPprWorkDB.GetSuppPrtPprWorkDB();

            // �f�[�^�Z�b�g���쐬
            this._dataSet = new SuppPtrStcDetailDataSet();

            // �A�N�Z�X�N���X���쐬
            this._supplierAcs = new SupplierAcs();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 ADD
            // �d���W�v�����[�g
            _iSuplierPayDB = MediationSuplierPayDB.GetSuplierPayDB();

            // �d������яC�������[�g
            _ISuppRsltUpdDB = MediationSuppRsltUpdDB.GetSuppRsltUpdDB();

            // �����Z�o���W���[��
            _ttlDayCalc = TotalDayCalculator.GetInstance();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 ADD

            // --- ADD 2012/09/13 ---------->>>>>
            this.CacheOptionInfo();
            // --- ADD 2012/09/13 ----------<<<<<
        }

        #endregion // �R���X�g���N�^

        #region �v���C�x�[�g�ϐ�

        // �����[�gDB�����N���X �C���^�t�F�[�X�I�u�W�F�N�g
        private ISuppPrtPprWorkDB _iSuppPrtPprWorkDB;

        // �f�[�^�Z�b�g�N���X
        private SuppPtrStcDetailDataSet _dataSet;

        // �d����擾�p�A�N�Z�X�N���X
        private SupplierAcs _supplierAcs;

        // �d������ߓ�
        private int _supplierCalcDate = 0;

        // ���Ӑ�w��t���O�i�w�肳��Ă��Ȃ��ꍇ�͎c������\�����Ȃ��j
        private bool _supplierPointed = true;
        
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 ADD
        // �d�����W�v�����[�g
        private ISuplierPayDB _iSuplierPayDB;

        // �d������яC�������[�g
        private ISuppRsltUpdDB _ISuppRsltUpdDB;

        // �����Z�o���W���[��
        private TotalDayCalculator _ttlDayCalc;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 ADD
        // ADD 2010/01/27 MANTIS�Ή�[14545]�F���Ӑ�d�q�����Ɠ��l�̑��x�A�b�v�Ή��i2009/10/07���{�j�̑g�ݍ��� ---------->>>>>
        // ���o���f�t���O
        private bool _extractCancelFlag;
        // ADD 2010/01/27 MANTIS�Ή�[14545]�F���Ӑ�d�q�����Ɠ��l�̑��x�A�b�v�Ή��i2009/10/07���{�j�̑g�ݍ��� ----------<<<<<

        // --- ADD 2012/09/13 ---------->>>>>
        // �d�������I�v�V�����t���O
        private bool _opt_SupplierSummary;
        // --- ADD 2012/09/13 ----------<<<<<

        #endregion // �v���C�x�[�g�ϐ�

        // --- ADD 2012/09/13 ---------->>>>>
        #region �񋓑�
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
        #endregion
        // --- ADD 2012/09/13 ----------<<<<<

        #region �萔

        #region 0�l�ߌ�

        /// <summary>���Ӑ�R�[�h ����:�����l 8</summary>
        private const int CT_DEPTH_CUSTOMERCODE = 8;

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

        #endregion

        #region ������萔

        /// <summary>���`���\�������� �����l [��]</summary>
        private const string CT_ACCPAYDIV_NAME_KURODEN = "";

        /// <summary>�ԓ`���\�������� �����l [�ԓ`]</summary>
        private const string CT_ACCPAYDIV_NAME_AKADEN = "�ԓ`";

        /// <summary>�������\�������� �����l [����]</summary>
        private const string CT_ACCPAYDIV_NAME_MOTOKURO = "����";

        /// <summary>�d���敪���\�������� �����l [�d��]</summary>
        private const string CT_SUPPLIERSLIPCD_NAME_01 = "�d��";

        /// <summary>�d���敪���\�������� �����l [�ԕi]</summary>
        private const string CT_SUPPLIERSLIPCD_NAME_02 = "�ԕi";

        /// <summary>�d���敪���\�������� �����l [����]</summary>
        private const string CT_SUPPLIERSLIPCD_NAME_03 = "����";

        /// <summary>�d���敪���\�������� �����l [����]</summary>
        private const string CT_SUPPLIERSLIPCD_NAME_04 = "����";

        /// <summary>�d���敪���\�������� �����l [�x��]</summary>
        private const string CT_SUPPLIERSLIPCD_NAME_05 = "�x��";

        /// <summary>�I�[�v�����i�\�������� �����l [�I�[�v�����i]</summary>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
        //private const string CT_OPENPRICEDIV_NAME = "�I�[�v�����i";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
        private const string CT_OPENPRICEDIV_NAME = "����݉��i";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD

        /// <summary>�݌Ɏ��敪�\�������� �����l [���]</summary>
        private const string CT_STOCKORDERDIV_NAME_01 = "���";

        /// <summary>�݌Ɏ��敪�\�������� �����l [�݌�]</summary>
        private const string CT_STOCKORDERDIV_NAME_02 = "�݌�";

        /// <summary>���|�敪�\�������� �����l [���|]</summary>
        private const string CT_ACCPAYDIV_NAME_01 = "���|";

        /// <summary>���l�Q�L�������\�������� �����l [�L�������F]</summary>
        private const string CT_SUPPLIERNOTE2_PRE = "�L�������F";

        #endregion // ������萔

        #endregion

        #region �v���p�e�B

        /// <summary>
        /// �f�[�^�Z�b�g�I�u�W�F�N�g 
        /// </summary>
        public SuppPtrStcDetailDataSet DataSet
        {
            get { return this._dataSet; }
            //set { this._dataSet = value; }
        }

        // ADD 2010/01/27 MANTIS�Ή�[14545]�F���Ӑ�d�q�����Ɠ��l�̑��x�A�b�v�Ή��i2009/10/07���{�j�̑g�ݍ��� ---------->>>>>
        /// <summary>
        /// ���o���f�t���O
        /// </summary>
        public bool ExtractCancelFlag
        {
            get { return _extractCancelFlag; }
            set { _extractCancelFlag = value; }
        }
        // ADD 2010/01/27 MANTIS�Ή�[14545]�F���Ӑ�d�q�����Ɠ��l�̑��x�A�b�v�Ή��i2009/10/07���{�j�̑g�ݍ��� ----------<<<<<

        // 2012/06/26 Y.Ito ADD START ��ʂŌ������m�F���邽�߂̃T�[�o����߂��Ă�������
        private long _searchCount;
        public long SearchCount
        {
            get { return _searchCount; }
            set { _searchCount = value; }
        }
        // 2012/06/26 Y.Ito ADD END ��ʂŌ������m�F���邽�߂̃T�[�o����߂��Ă�������

        #endregion // �v���p�e�B

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        public delegate void UpdateSectionEventHandler( object sender, string sectionCode, string sectionName );
        public event UpdateSectionEventHandler UpdateSection;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

        // ----- ADD 2012/06/19 tianjw Redmine#30529 ----->>>>>
        /// <summary>
        /// �ŗ��ݒ�擾����
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="taxRateCode"></param>
        /// <returns></returns>
        public TaxRateSet GetTaxRateSet(string enterpriseCode, int taxRateCode)
        {
            TaxRateSet taxRateSet;
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs(); // �ŗ��ݒ�}�X�^
            int status = taxRateSetAcs.Read(out taxRateSet, enterpriseCode, taxRateCode);
            if (status != 0)
            {
                taxRateSet = new TaxRateSet();
            }

            return taxRateSet;
        }

        /// <summary>
        /// �ŗ��ݒ�̓]�ŕ����擾����
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="taxRateCode"></param>
        /// <returns></returns>
        public int GetConsTaxLayMethod(string enterpriseCode, int taxRateCode)
        {
            TaxRateSet taxRateSet = GetTaxRateSet(enterpriseCode, taxRateCode);
            return taxRateSet.ConsTaxLayMethod;
        }
        // ----- ADD 2012/06/19 tianjw Redmine#30529 -----<<<<<

        /// <summary>
        /// TODO:����
        /// </summary>
        /// <param name="suppPrtPpr">���������N���X</param>
        /// <param name="logicalDelDiv">�폜�w��敪�F0=�W��,1=�폜���̂�</param>
        /// <param name="procDiv">�����敪�F0=�d�����,1=�d���ԕi�\����</param>   // ADD 2013/01/21
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2009/09/08 ���̕� �ߋ����\���Ή�</br>
        /// <br>Update Note: 2012/04/05 �����H</br>						
        /// <br>             2012/05/24�z�M�� Redmine#29310�@���v���̕s��ɂ��Ă̏C��</br>
        /// <br>Update Note: 2012/06/19 tianjw</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/07/25�z�M��</br>
        /// <br>             Redmine#30529 �ŗ��Q�Ƃ̕s��̑Ή�</br>
        /// <br>Update Note: 2012/06/26 �ɓ� �L</br>
        ///                  �d�b�Ή�No.1027 �����I�[�o�[���Ƀ��b�Z�[�W��\��
        /// <br>Update Note: 2012/10/15 �c����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A2012/11/14�z�M��</br>
        /// <br>             Redmine#32862 ���i�ύX�������ׁA�F��ς���悤�ɏC��</br>
        /// <br>Update Note: 2012/10/30 �c����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A2012/11/14�z�M��</br>
        /// <br>             Redmine#32862#20 �d���f�[�^�ɓ��͋敪�u���v�v�ō쐬���āA����������Ώۂɂ����ꍇ�A�V�X�e���G���[�ƂȂ�C��</br>
        /// <br>Update Note : 2013/01/21 FSI�y�~ �їR��</br>
        /// <br>              [�d���ԕi�v��] �I���`�F�b�N�{�b�N�X�ݒ�ǉ�</br>
        /// <br>Update Note: 2013/02/16 �A����</br>�@ 
        /// <br>�Ǘ��ԍ�   : 10900691-00   2013/03/13�z�M��</br>
        /// <br>           : Redmine#34618 �d����d�q�����̍��v��ʂŏ���ł�����Ȃ���Q�̏C��</br>
        /// <br>Update Note: 2020/03/11 ���V��</br>
        /// <br>�Ǘ��ԍ�   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912 �y���ŗ��Ή�</br>
        /// <br>           : �`�[�^�u�A���׃^�u�Ɂu����ŗ��v���ڂ�ǉ�</br>
        /// <br></br>
        /// </remarks>
        // ----------ADD 2013/01/21----------->>>>>
        //public int Search(SuppPrtPpr suppPrtPpr, int logicalDelDiv)
        public int Search(SuppPrtPpr suppPrtPpr, int logicalDelDiv, int procDiv)
        // ----------ADD 2013/01/21-----------<<<<<
        {
            int status;

            // 2012/06/26 Y.Ito ADD START �T�[�o����̌������ʂ����Z�b�g
            SearchCount = 0;
            // 2012/06/26 Y.Ito ADD END �T�[�o����̌������ʂ����Z�b�g

            int suppCTaxLayRefCd = -1; // ADD 2012/06/19 tianjw Redmine#30529

            // �d����R�[�h���w�肳��Ă���Ύc����\��
            if (suppPrtPpr.SupplierCd == 0)
            {
                // �d����R�[�h���Ȃ��ꍇ�͎c����\�����Ȃ�
                _supplierPointed = false;
            }
            else
            {
                // �d��������擾���A���ߓ����擾���Ă���
                Supplier supplierInfo;
                status = this._supplierAcs.Read(out supplierInfo, suppPrtPpr.EnterpriseCode, suppPrtPpr.SupplierCd);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �d�����ߓ����擾
                    this._supplierCalcDate = supplierInfo.PaymentTotalDay;
                    suppCTaxLayRefCd = supplierInfo.SuppCTaxLayRefCd; // ADD 2012/06/19 tianjw Redmine#30529
                }
                else
                {
                    // �d�����񂪂Ȃ�
                    // *** ���̂Ȃ��d����̓p�����[�^�Ƃ��ēn���Ă��Ȃ� ***
                }
            }


            // �p�����[�^�N���X���쐬
            SuppPrtPprWork suppPrtPprWork = new SuppPrtPprWork();
            SuppPrtPpr2SuppPrtPprWork(ref suppPrtPpr, ref suppPrtPprWork);
            
            //---------------------------------
            // �Ԃ�l�Ŏg�p����N���X���쐬
            //---------------------------------

            // �c���Ɖ�ɕ\������̂łP���̂�
            SuppPrtPprBlDspRsltWork suppPrtPprBlDspRsltWork = new SuppPrtPprBlDspRsltWork();
            object suppPrtPprBlDspRsltWorkObj = (object)suppPrtPprBlDspRsltWork;

            // ���ׂȂ̂�recordCount�����z��ŋA���Ă���
            SuppPrtPprStcTblRsltWork suppPrtPprStcTblRsltWork = new SuppPrtPprStcTblRsltWork();
            object suppPrtPprStcTblRsltWorkObj = (object)suppPrtPprStcTblRsltWork;
            long counter = 0;

            // ADD 2010/01/27 MANTIS�Ή�[14545]�F���Ӑ�d�q�����Ɠ��l�̑��x�A�b�v�Ή��i2009/10/07���{�j�̑g�ݍ��� ---------->>>>>
            if (ExtractCancelFlag == true) return 0;
            // ADD 2010/01/27 MANTIS�Ή�[14545]�F���Ӑ�d�q�����Ɠ��l�̑��x�A�b�v�Ή��i2009/10/07���{�j�̑g�ݍ��� ----------<<<<<

            // ----------ADD 2013/01/21----------->>>>>
            // �����敪=0(�d�����\��(�ԕi�\��͑ΏۊO))�̏ꍇ
            if (procDiv == 0)
            {
                //�d�������擾
                if (logicalDelDiv == 0)
                {
                    // �폜�����܂܂Ȃ��ꍇ��GetData0���w��(�폜�t���O=0�̃f�[�^��Ԃ�)
                    status = this._iSuppPrtPprWorkDB.SearchRef(ref suppPrtPprBlDspRsltWorkObj, ref suppPrtPprStcTblRsltWorkObj, (object)suppPrtPprWork, out counter, 0, ConstantManagement.LogicalMode.GetData0);
                }
                else
                {
                    // �폜�ς݂̏ꍇ��GetData1���w��(�폜�t���O=1�̃f�[�^��Ԃ�)
                    status = this._iSuppPrtPprWorkDB.SearchRef(ref suppPrtPprBlDspRsltWorkObj, ref suppPrtPprStcTblRsltWorkObj, (object)suppPrtPprWork, out counter, 0, ConstantManagement.LogicalMode.GetData1);
                }
            }
            // �����敪=1(�d���ԕi�\����̂ݕ\��)�̏ꍇ
            else
            {

                //�d���ԕi�\������擾
                status = this._iSuppPrtPprWorkDB.SearchRefPurchaseReturnSchedule(ref suppPrtPprStcTblRsltWorkObj, (object)suppPrtPprWork, out counter, logicalDelDiv);

            }
            // ----------ADD 2013/01/21-----------<<<<<

            // ADD 2010/01/27 MANTIS�Ή�[14545]�F���Ӑ�d�q�����Ɠ��l�̑��x�A�b�v�Ή��i2009/10/07���{�j�̑g�ݍ��� ---------->>>>>
            if (ExtractCancelFlag == true) return 0;
            // ADD 2010/01/27 MANTIS�Ή�[14545]�F���Ӑ�d�q�����Ɠ��l�̑��x�A�b�v�Ή��i2009/10/07���{�j�̑g�ݍ��� ----------<<<<<
            // ��������readMode�͌��ݎg�p���Ă��Ȃ��̂łǂ�Ȓl�����Ă����Ȃ�

            // 2012/06/26 Y.Ito ADD START �T�[�o����̌������ʂ�ێ�
            SearchCount = counter;
            // 2012/06/26 Y.Ito ADD END �T�[�o����̌������ʂ�ێ�

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            //// Status������l�������ꍇ�̂݃f�[�^�Z�b�g�ɖ߂�f�[�^���Z�b�g
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 ADD
                // ���d���N�Ԏ��яƉ�x�[�X�̎擾�d�l�ɕύX
                //   (�d����d�q���������[�g���Ԃ�suppPrtPprBlDspRsltWorkObj�͎g�p���Ȃ�)
                RemainDataExtra remainDataExtra = new RemainDataExtra();
                SearchBlDspRslt( ref suppPrtPprBlDspRsltWorkObj, ref remainDataExtra, suppPrtPpr );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 ADD

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                //// �ꌏ�ȏ�̖߂肪�������ꍇ�̂�
                //if (counter > 0)
                //{
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL

                #region �ϐ���`

                DataRow row = null;
                DataRow row2 = null;
                DataRow row3 = null;
                DataRow retRow = null; // ADD 2013/01/21 [�d���ԕi�v��]

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                //// �`�[�P�ʂ́A�u�`�[�ԍ��v�y�сu�d���^���v������̂��̂��ЂƂ̂�����Ƃ��Ĕ��肷��
                //string exSlipNum = string.Empty;    // �ЂƂO�̓`�[�ԍ�
                //int exSupplierFormal = 0;           // �ЂƂO�̎d���^��
                // �`�[�ԍ�
                //int supplierSlipNoExt = 0;// string.Empty;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                int supplierSlipNoExt = -1; // �ЂƂO�̓`�[�ԍ�
                int exSupplierFormal = -1;  // �ЂƂO�̎󒍃X�e�[�^�X
                // ADD 2010/01/26 MANTIS�Ή�[14325]�F�C���X�g�[������Ɏd���`�[�~1�Ǝx���`�[�~1��o�^������ԂŌ�������ƁA�d���`�[���\������Ȃ� ---------->>>>>
                string exSupplierSlipCdName = string.Empty; // �ЂƂO�̎d���`�[�敪��
                // ADD 2010/01/26 MANTIS�Ή�[14325]�F�C���X�g�[������Ɏd���`�[�~1�Ǝx���`�[�~1��o�^������ԂŌ�������ƁA�d���`�[���\������Ȃ� ----------<<<<<
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                long consumeTaxTotal = 0;           // �`�[�P�ʂ̏���Ŋz�݌v
                bool stckPrcConsTaxIncluAdjust = false; // ����ł�\�����邩�ǂ����̃t���O
                int rowCount = 0;
                int allRowCount = 0;

                // �c���\���Ŏg�p����W�v�l
                int slipCount = 0;                  // �`�[����
                double detailSlipCount = 0;         // ���א�
                double totalAmount = 0;             // ����
                double totalConsumeTaxAmount = 0;   // �����
                double totalConsumeTaxAmount2 = 0;   // �����(���׃f�[�^���W�v) //ADD �����H�@2012/04/05 Redmine#29310

                // �����͈͓��ŏW�v����l
                long totalThisStockPrice = 0;       // ����d��
                long totalOfsThisSalesTax = 0;      // ����Łi���j
                long totalThisTimePayNrml = 0;      // ����x��

                double StandardPrice_Total = 0;     // �W�����i���v
                double StockAmount_Total = 0;       // �d�����z���v
                double StockAmount_Total2 = 0;       // �d�����z���v(���׃f�[�^���W�v) //ADD �����H�@2012/04/05 Redmine#29310

                long StockTotalPayBalance = 0;      // �O��c��

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                //double wkStockAmount = 0;
                //double wkTotalConsumeTaxAmount = 0;
                long salAmntConsTaxInclu = 0; // �`�[�ʓ��ŋ��z�W�v�l
                string salesSlipNum = string.Empty; // �`�[����������`�[�ԍ�(�`�[����1�s�ł�����Αޔ�) 
                string prevSalesSlipNum = string.Empty;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD

                int rowNo = 1;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                int rowDetailNo = 0;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                // ADD 2010/01/27 MANTIS�Ή�[14545]�F���Ӑ�d�q�����Ɠ��l�̑��x�A�b�v�Ή��i2009/10/07���{�j�̑g�ݍ��� ---------->>>>>
                int lastIndex = 0;
                // ADD 2010/01/27 MANTIS�Ή�[14545]�F���Ӑ�d�q�����Ɠ��l�̑��x�A�b�v�Ή��i2009/10/07���{�j�̑g�ݍ��� ----------<<<<<

                #endregion // �ϐ���`

                #region �c���\��

                //-------------------
                // �c���\��
                //-------------------

                // �c���\�����ꌏ�œ���ł��Ȃ������ꍇ�͕\�����Ȃ�
                // �d���悪���݂��Ȃ��ꍇ���\�����Ȃ�
                ArrayList al = (ArrayList)suppPrtPprBlDspRsltWorkObj;
                if ( al.Count == 1 || !_supplierPointed )
                {
                    int suppCTaxLayCd = GetConsTaxLayMethod(suppPrtPpr.EnterpriseCode, 0); // ADD 2012/06/19 tianjw Redmine#30529
                    foreach ( SuppPrtPprBlDspRsltWork remainData in (ArrayList)suppPrtPprBlDspRsltWorkObj )
                    {
                        row3 = this._dataSet.BalanceTotal.NewRow();
                        row3[_dataSet.BalanceTotal.StockTtl2TmBfBlPayColumn.ColumnName] = remainData.StockTtl2TmBfBlPay;    // �O�X�X��c��
                        row3[_dataSet.BalanceTotal.LastTimePaymentColumn.ColumnName] = remainData.LastTimePayment;          // �O�X��c��
                        row3[_dataSet.BalanceTotal.StockTotalPayBalanceColumn.ColumnName] = remainData.StockTotalPayBalance;// �O��c��
                        StockTotalPayBalance = remainData.StockTotalPayBalance;
                        row3[_dataSet.BalanceTotal.AddUpYearMonthColumn.ColumnName] = remainData.AddUpYearMonth;            // �����N��
                        //row3[_dataSet.BalanceTotal.SuppCTaxationCdColumn.ColumnName] = remainData.SuppCTaxationCd;          // ����œ]�ŕ��� // DEL 2012/06/19 tianjw Redmine#30529
                        // ----- ADD 2012/06/19 tianjw Redmine#30529 ---------->>>>>
                        // ����œ]�ŕ���
                        if (suppCTaxLayRefCd == 0)
                        {
                            // �ŗ��Q�Ƃ̏ꍇ
                            row3[_dataSet.BalanceTotal.SuppCTaxationCdColumn.ColumnName] = suppCTaxLayCd;
                        }
                        else
                        {
                            // �d����Q�Ƃ̏ꍇ
                            row3[_dataSet.BalanceTotal.SuppCTaxationCdColumn.ColumnName] = remainData.SuppCTaxationCd;
                        }
                        // ----- ADD 2012/06/19 tianjw Redmine#30529 ----------<<<<<
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 ADD
                        // �x���c��
                        row3[_dataSet.BalanceTotal.PaymentRemainColumn.ColumnName] = remainDataExtra.PaymentRemain;
                        // ����d��
                        row3[_dataSet.BalanceTotal.ThisStockPriceTotalColumn.ColumnName] = remainDataExtra.ThisStockPriceTotal;
                        // �����
                        row3[_dataSet.BalanceTotal.OfsThisStockTaxColumn.ColumnName] = remainDataExtra.OfsThisStockTax;
                        // ����x��
                        row3[_dataSet.BalanceTotal.ThisTimePayNrmlColumn.ColumnName] = remainDataExtra.ThisTimePayNrml;
                        // ���J�n��
                        row3[_dataSet.BalanceTotal.DmdStDayColumn.ColumnName] = remainDataExtra.DmdStDay;
                        // ��������
                        row3[_dataSet.BalanceTotal.TotalDayColumn.ColumnName] = remainDataExtra.TotalDay;
                        // �e�t���O
                        row3[_dataSet.BalanceTotal.IsParentColumn.ColumnName] = remainDataExtra.IsParent;
                        // �f�[�^���݃t���O
                        row3[_dataSet.BalanceTotal.ExistsTotalColumn.ColumnName] = true;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 ADD
                        this._dataSet.BalanceTotal.Rows.Add( row3 );
                    }
                }

                #endregion // �c���\��

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                // �ꌏ�ȏ�̖߂肪�������ꍇ�̂�
                if (counter > 0)
                {
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD


                    // �S�������擾���Ă���
                    allRowCount = ((ArrayList)suppPrtPprStcTblRsltWorkObj).Count;

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                    //foreach (SuppPrtPprStcTblRsltWork data in (ArrayList)suppPrtPprStcTblRsltWorkObj)
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                    for ( int index = 0; index < (suppPrtPprStcTblRsltWorkObj as ArrayList).Count; index++ )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                    {
                        // 2012/06/26 Y.Ito ADD START 20000���𒴂���f�[�^�͊i�[���Ȃ��B
                        if (this._dataSet.StcDetail.Rows.Count >= suppPrtPpr.SearchCnt - 1)
                        {
                            break;
                        }
                        // 2012/06/26 Y.Ito ADD END 20000���𒴂���f�[�^�͕\�����Ȃ��B

                        // ADD 2010/01/27 MANTIS�Ή�[14545]�F���Ӑ�d�q�����Ɠ��l�̑��x�A�b�v�Ή��i2009/10/07���{�j�̑g�ݍ��� ---------->>>>>
                        lastIndex = index;
                        // ADD 2010/01/27 MANTIS�Ή�[14545]�F���Ӑ�d�q�����Ɠ��l�̑��x�A�b�v�Ή��i2009/10/07���{�j�̑g�ݍ��� ----------<<<<<

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        SuppPrtPprStcTblRsltWork data = (SuppPrtPprStcTblRsltWork)((suppPrtPprStcTblRsltWorkObj as ArrayList)[index]);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

                        // �f�[�^�Z�b�g�ɕԂ�l���Z�b�g����
                        try
                        {
                            #region ���׃f�[�^�e�[�u��

                            row = this._dataSet.StcDetail.NewRow();
                            retRow = this._dataSet.RetGdsStcDetail.NewRow(); // ADD 2013/01/21 [�d���ԕi�v��]

                            if (data.DataDiv == 0) // �d���f�[�^�̏ꍇ
                            {
                                #region ���ׁE�d���f�[�^

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
                                // �ԕi�E�l������̂��߂̐��ʁE���z�̕���(1or-1)
                                // �i�ԕi�̒l������-1*-1��1�j
                                // ���ԕi�E�l�����̓f�[�^�㐔�ʃ}�C�i�X�Ȃ̂ŁAdetailSign�������ăv���X�ɂ���
                                // �@�P����Abs���Ƃ�킯�ł͂Ȃ��̂Œ��ӁB
                                int detailSign = 1;

                                // �ԕi����
                                if ( data.SupplierSlipCd == 20 ) detailSign *= -1;

                                // ���i�l������(�s�l���͏��O)
                                if ( data.StockSlipCdDtl == 2 && !string.IsNullOrEmpty( data.GoodsNo ) ) detailSign *= -1;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD

                                // �I���`�F�b�N�{�b�N�X
                                row[_dataSet.StcDetail.SelectionCheckColumn.ColumnName] = false; // ADD 2013/01/21 [�d���ԕi�v��]
                                // �`�[�敪
                                row[_dataSet.StcDetail.DataDivColumn.ColumnName] = data.DataDiv;
                                // �s�ԍ�([�L�[��]���o�f�[�^�݌v)
                                row[_dataSet.StcDetail.RowNoColumn.ColumnName] = rowNo;
                                // �`�[���t
                                row[_dataSet.StcDetail.StockDateColumn.ColumnName] = data.StockDate;
                                // �`�[�ԍ�
                                row[_dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName] = data.PartySaleSlipNum;
                                // �sNo
                                row[_dataSet.StcDetail.StockRowNoColumn.ColumnName] = data.StockRowNo;
                                // �d���`��
                                row[_dataSet.StcDetail.SupplierFormalColumn.ColumnName] = data.SupplierFormal;
                                // �d���`�[�敪
                                row[_dataSet.StcDetail.SupplierSlipCdColumn.ColumnName] = data.SupplierSlipCd;
                                // �d���`�[�敪������
                                if (data.SupplierFormal == 0)   // �d��
                                {
                                    if (data.SupplierSlipCd == 10)
                                    {
                                        row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_01;
                                    }
                                    else if (data.SupplierSlipCd == 20)
                                    {
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                                        //row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_02;
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                                        row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_01 + CT_SUPPLIERSLIPCD_NAME_02; // �d���ԕi
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                                    }
                                }
                                else if (data.SupplierFormal == 1)   // ��
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                                    //row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_03;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                                    if ( data.SupplierSlipCd == 10 )
                                    {
                                        row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_04; // ����
                                    }
                                    else if ( data.SupplierSlipCd == 20 )
                                    {
                                        row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_04 + CT_SUPPLIERSLIPCD_NAME_02; // ���וԕi
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                                }
                                else if (data.SupplierFormal == 2)   // �o��
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                                    //row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_04;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                                    row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_03; // ����
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                                }
                                // ----------ADD 2013/01/21 [�d���ԕi�v��]----------->>>>>
                                else if (data.SupplierFormal == 3)   // �ԕi�\��
                                {
                                    if (data.SupplierSlipCd == 10)
                                    {
                                        row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_01; // �d��
                                    }
                                    else if (data.SupplierSlipCd == 20)
                                    {
                                        row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_02; // �ԕi
                                    }
                                }
                                // ----------ADD 2013/01/21 [�d���ԕi�v��]-----------<<<<<
                                else // �x��
                                {
                                    // [���x���`�[�͂����ɂ��Ȃ�]
                                    //row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_05;
                                }
                                // �S���Җ�
                                row[_dataSet.StcDetail.StockAgentNameColumn.ColumnName] = data.StockAgentName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                                //// ���z
                                //row[_dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName] = data.StockTtlPricTaxExc;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                                // �i��
                                row[_dataSet.StcDetail.GoodsNameColumn.ColumnName] = data.GoodsName;
                                // �i��
                                row[_dataSet.StcDetail.GoodsNoColumn.ColumnName] = data.GoodsNo;
                                // ���[�J�[�R�[�h[0�̂Ƃ��͋�]
                                if (data.GoodsMakerCd == 0)
                                {
                                    row[_dataSet.StcDetail.GoodsMakerCdColumn.ColumnName] = string.Empty;//DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.GoodsMakerCdColumn.ColumnName] = data.GoodsMakerCd.ToString().PadLeft(CT_DEPTH_GOODSMAKERCODE, '0');
                                }
                                // ���[�J�[��
                                row[_dataSet.StcDetail.MakerNameColumn.ColumnName] = data.MakerName;
                                // BL�R�[�h[0�̂Ƃ��͋�]
                                if (data.BLGoodsCode == 0)
                                {
                                    row[_dataSet.StcDetail.BLGoodsCodeColumn.ColumnName] = string.Empty;//DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.BLGoodsCodeColumn.ColumnName] = data.BLGoodsCode.ToString().PadLeft(CT_DEPTH_BLGOODSCODE, '0');
                                }
                                // BL�O���[�v
                                if (data.BLGroupCode == 0)
                                {
                                    row[_dataSet.StcDetail.BLGroupCodeColumn.ColumnName] = string.Empty;//DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode.ToString().PadLeft(CT_DEPTH_BLGROUPCODE, '0');
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                                //// ����
                                //row[_dataSet.StcDetail.StockCountColumn.ColumnName] = data.StockCount;

                                //// �I�[�v�����i�敪
                                //row[_dataSet.StcDetail.OpenPriceDivColumn.ColumnName] = data.OpenPriceDiv;
                                //// �W�����i(�I�[�v�����i�敪�ɂ��\���ύX)
                                //if (data.OpenPriceDiv == 0)
                                //{
                                //    row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = data.ListPriceTaxExcFl.ToString("#,###");
                                //}
                                //else
                                //{
                                //    row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = CT_OPENPRICEDIV_NAME;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 ADD
                                if ( data.StockGoodsCd == 0 )
                                {
                                    // ���P��
                                    row[_dataSet.StcDetail.StockUnitPriceFlColumn.ColumnName] = data.StockUnitPriceFl;

                                    // ����
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
                                    //row[_dataSet.StcDetail.StockCountColumn.ColumnName] = data.StockCount;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
                                    row[_dataSet.StcDetail.StockCountColumn.ColumnName] = detailSign * data.StockCount;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD

                                    // �I�[�v�����i�敪
                                    row[_dataSet.StcDetail.OpenPriceDivColumn.ColumnName] = data.OpenPriceDiv;
                                    
                                    // �W�����i(�I�[�v�����i�敪�ɂ��\���ύX)
                                    row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = data.ListPriceTaxExcFl;    // ADD by gezh 2011/11/24 redmine#8078
                                    // DEL by gezh 2011/11/24 redmine#8078 begin---------------------->>>>>
                                    //if (data.OpenPriceDiv == 0)
                                    //{
                                    //    row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = data.ListPriceTaxExcFl.ToString("#,###");
                                    //}
                                    //else
                                    //{
                                    //    row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = CT_OPENPRICEDIV_NAME;
                                    //}
                                    // DEL by gezh 2011/11/24 redmine#8078 end-----------------------<<<<<

                                    // ----------- ADD 2012/10/15 �c���� Redmine#32862 ------------>>>>>
                                    // ���P��
                                    row[_dataSet.StcDetail.BfStockUnitPriceFlColumn.ColumnName] = data.BfStockUnitPriceFl;
                                    // �W�����i
                                    row[_dataSet.StcDetail.BfListPriceColumn.ColumnName] = data.BfListPrice;
                                    // ----------- ADD 2012/10/15 �c���� Redmine#32862 ------------<<<<<
                                }
                                else
                                {
                                    // �����v���͂̏ꍇ�͔�\��

                                    // ���P��
                                    row[_dataSet.StcDetail.StockUnitPriceFlColumn.ColumnName] = DBNull.Value;
                                    // ����
                                    row[_dataSet.StcDetail.StockCountColumn.ColumnName] = DBNull.Value;
                                    // �I�[�v�����i�敪
                                    row[_dataSet.StcDetail.OpenPriceDivColumn.ColumnName] = DBNull.Value;
                                    // �W�����i(�I�[�v�����i�敪�ɂ��\���ύX)
                                    row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = DBNull.Value;

                                    // ----------- ADD 2012/10/30 �c���� Redmine#32862 ------------>>>>>
                                    // �ύX�O���P��
                                    row[_dataSet.StcDetail.BfStockUnitPriceFlColumn.ColumnName] = DBNull.Value;
                                    // �ύX�O�W�����i
                                    row[_dataSet.StcDetail.BfListPriceColumn.ColumnName] = DBNull.Value;
                                    // ----------- ADD 2012/10/30 �c���� Redmine#32862 ------------<<<<<
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 ADD

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                                //// �����(�d�������œ]�ŕ����R�[�h�ɂ��ω�)
                                //// *** ���z�\������ ***
                                //if (data.SuppTtlAmntDspWayCd == 1) 
                                //{
                                //    // [���z�\������]�̏ꍇ�͖��גP�ʈȊO�͐ݒ肳��Ȃ��B���׈ȊO���l������K�v�Ȃ�
                                //    // �e�X�g���ɂ��A���׈ȊO��ݒ肵�Ă���f�[�^������ꍇ�́A�f�[�^���ԈႢ

                                //    // �d�����z����Ŋz
                                //    row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = data.StockPriceConsTax;
                                //    //row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = data.StckPrcConsTaxInclu + data.StckDisTtlTaxInclu;
                                //}
                                //else // *** ���z�\�����Ȃ� ***
                                //{
                                //    if (data.SuppCTaxLayCd == 0) // �`�[�P��(0)
                                //    {
                                //        // �\�����Ȃ�
                                //        row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                //    }
                                //    else if (data.SuppCTaxLayCd == 2 || // �����e(2)
                                //        data.SuppCTaxLayCd == 3 || // �����q(3)
                                //        data.SuppCTaxLayCd == 9)   // ��ې�(9)
                                //    {
                                //        if (data.TaxationCode == 2) // *** ���� ***
                                //        {
                                //            row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = data.StockPriceConsTax;
                                //            //row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = data.StckPrcConsTaxInclu + data.StckDisTtlTaxInclu;
                                //        }
                                //        else
                                //        {
                                //            // �\�����Ȃ�
                                //            row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                //        }
                                //    }
                                //    else // ���גP��(1)
                                //    {
                                //        // �\������
                                //        row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = data.StockPriceConsTax;
                                //    }
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                                # region [����Ŋ֘A]
                                bool printTax = true;
                                Int64 stockTotalTaxInc;
                                Int64 stockTotalTaxExc = data.StockPriceTaxExc;
                                Int64 stockPriceConsTax;

                                // ����������Ŋz�̎擾
                                if ( data.SuppCTaxLayCd == 0 ) // �`�[�P��
                                {
                                    // ----- DEL huangt 2013/05/15 Redmine#35640 ---------- >>>>>
                                    //if ( !data.SupplierSlipNo.Equals( supplierSlipNoExt ) ) // ��s�ڂ̂ݕ\��
                                    //{
                                    //    stockPriceConsTax = data.StockTtlPricTaxInc - data.StockTtlPricTaxExc;
                                    //}
                                    //else
                                    //{
                                    //    stockPriceConsTax = 0;
                                    //    printTax = false;
                                    //}
                                    // ----- DEL huangt 2013/05/15 Redmine#35640 ---------- <<<<<

                                    // ----- ADD huangt 2013/05/15 Redmine#35640 ---------- >>>>>
                                    // ���א擪�s�ɏ���ł��󎚂����
                                    //if (data.StockRowNo == 1)    // DEL huangt 2013/11/25 Redmine#35640 �����̏ꍇ�͏���ł��o�͂��Ȃ��悤�ɏC��
                                    if (data.StockRowNo == 1 && data.SupplierFormal != 2)   // ADD huangt 2013/11/25 Redmine#35640 �����̏ꍇ�͏���ł��o�͂��Ȃ��悤�ɏC��
                                    {
                                        stockPriceConsTax = data.StockTtlPricTaxInc - data.StockTtlPricTaxExc;
                                    }
                                    else
                                    {
                                        stockPriceConsTax = 0;
                                        printTax = false;
                                    }
                                    // ----- ADD huangt 2013/05/15 Redmine#35640 ---------- <<<<<
                                }
                                //else if ( data.SuppCTaxLayCd == 1 ) // ���גP��
                                //{
                                //    stockPriceConsTax = data.StockPriceConsTaxDtl;
                                //}
                                //else
                                //{
                                //    stockPriceConsTax = 0;
                                //}
                                else
                                {
                                    //stockPriceConsTax = data.StockPriceConsTaxDtl;  // DEL�@�A�����@2013/02/16 Redmine#34618
                                    // -----ADD�@�A�����@2013/02/16 Redmine#34618----->>>>>
                                    if (data.StockPriceConsTaxDtl == 0)//�R���o�[�g�f�[�^���̎d�����׃f�[�^�ɏ���ł��[���̏ꍇ�A����ł��Ď擾����
                                    {
                                        stockPriceConsTax = data.StockPriceTaxInc - data.StockPriceTaxExc;
                                    }
                                    else
                                    {
                                        stockPriceConsTax = data.StockPriceConsTaxDtl;
                                    }
                                    // -----ADD�@�A�����@2013/02/16 Redmine#34618-----<<<<<
                                }

                                // �ō����z�̎擾
                                stockTotalTaxInc = stockTotalTaxExc + stockPriceConsTax;

                                if ( printTax )
                                {
                                    // ����ň󎚗L������Ƌ��z����
                                    int totalAmountDispWayCd = data.SuppTtlAmntDspWayCd;
                                    int taxationDivCd = data.TaxationCode;

                                    // ����ň󎚗L������
                                    printTax = ReflectMoneyForTaxPrint( ref stockTotalTaxExc, ref stockPriceConsTax, ref stockTotalTaxInc, totalAmountDispWayCd, data.SuppCTaxLayCd, taxationDivCd );
                                    if ( printTax )
                                    {
                                        if ( stockPriceConsTax != 0 )
                                        {
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
                                            //row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = stockPriceConsTax;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
                                            row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = detailSign * stockPriceConsTax;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD

                                            row[_dataSet.StcDetail.SupplierConsTaxRateColumn.ColumnName] = data.SupplierConsTaxRate; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                                        }
                                        else
                                        {
                                            // �󎚂��Ȃ�
                                            row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                            row[_dataSet.StcDetail.SupplierConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                                        }
                                    }
                                    else
                                    {
                                        // �󎚂��Ȃ�
                                        row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                        row[_dataSet.StcDetail.SupplierConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                                    }
                                }
                                else
                                {
                                    // �󎚂��Ȃ�
                                    row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.StcDetail.SupplierConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
                                //// �Ŕ����z�Z�b�g
                                //row[_dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName] = stockTotalTaxExc;
                                //// �ō����z�Z�b�g
                                //row[_dataSet.StcDetail.StockTtlPricTaxIncColumn.ColumnName] = stockTotalTaxInc;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
                                // �Ŕ����z�Z�b�g
                                row[_dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName] = detailSign * stockTotalTaxExc;
                                // �ō����z�Z�b�g
                                row[_dataSet.StcDetail.StockTtlPricTaxIncColumn.ColumnName] = detailSign * stockTotalTaxInc;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD
                                # endregion
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                                // ���l�P
                                row[_dataSet.StcDetail.SupplierSlipNote1Column.ColumnName] = data.SupplierSlipNote1;
                                // ���l�Q
                                row[_dataSet.StcDetail.SupplierSlipNote2Column.ColumnName] = data.SupplierSlipNote2;
                                // ���_�R�[�h
                                row[_dataSet.StcDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                                // ���_��
                                row[_dataSet.StcDetail.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                                // ���s��
                                // row[_dataSet.StcDetail.StockInputNameColumn.ColumnName] = data.StockInputName; // DEL 2009/09/08
                                // �d����R�[�h[NULL�̂Ƃ��͋�]
                                if (data.SupplierCd == 0)
                                {
                                    row[_dataSet.StcDetail.SupplierCdColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.SupplierCdColumn.ColumnName] = data.SupplierCd;//data.SupplierCd.ToString().PadLeft(CT_DEPTH_SUPPLIERCODE, '0');
                                }
                                // �d���於
                                row[_dataSet.StcDetail.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                                // �ݎ�
                                row[_dataSet.StcDetail.StockOrderDivCdColumn.ColumnName] = data.StockOrderDivCd;
                                // �ݎ於
                                if (data.StockOrderDivCd == 0)
                                {
                                    row[_dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName] = CT_STOCKORDERDIV_NAME_01;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName] = CT_STOCKORDERDIV_NAME_02;
                                }
                                // �q�ɃR�[�h
                                row[_dataSet.StcDetail.WarehouseCdColumn.ColumnName] = data.WarehouseCode;
                                // �q�ɖ�
                                row[_dataSet.StcDetail.WarehouseNameColumn.ColumnName] = data.WarehouseName;
                                // �I��
                                row[_dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName] = data.WarehouseShelfNo;
                                // UOE���}�[�N1
                                row[_dataSet.StcDetail.UoeRemark1Column.ColumnName] = data.UoeRemark1;
                                // UOE���}�[�N2
                                row[_dataSet.StcDetail.UoeRemark2Column.ColumnName] = data.UoeRemark2;
                                // �d��SEQ/�x����[0�̂Ƃ��͋�]
                                if (data.SupplierSlipNo == 0)
                                {
                                    row[_dataSet.StcDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                                }
                                // �v���
                                if (data.StockAddUpADate == DateTime.MinValue)
                                {
                                    row[_dataSet.StcDetail.StockAddUpADateColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.StockAddUpADateColumn.ColumnName] = data.StockAddUpADate;
                                }
                                // ���|�敪
                                row[_dataSet.StcDetail.AccPayDivCdColumn.ColumnName] = data.AccPayDivCd;
                                // ���|�敪��
                                if (data.AccPayDivCd == 1)
                                {
                                    row[_dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName] = CT_ACCPAYDIV_NAME_01;
                                }
                                // �ԓ`�敪
                                if (data.DebitNoteDiv == 0)
                                {
                                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_KURODEN;
                                }
                                else if (data.DebitNoteDiv == 1)
                                {
                                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_AKADEN;
                                }
                                else if (data.DebitNoteDiv == 2)
                                {
                                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_MOTOKURO;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                                }
                                // ��������`�[�ԍ�
                                row[_dataSet.StcDetail.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                                // ����������t
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 DEL
                                //row[_dataSet.StcDetail.SalesDateColumn.ColumnName] = data.SalesDate;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 ADD
                                if ( data.SalesDate != DateTime.MinValue )
                                {
                                    row[_dataSet.StcDetail.SalesDateColumn.ColumnName] = data.SalesDate;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.SalesDateColumn.ColumnName] = DBNull.Value;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                                //// ���Ӑ�R�[�h[0�̂Ƃ��͋�]
                                //if (data.CustomerCode > 0)
                                //{
                                //    row[_dataSet.StcDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode.ToString().PadLeft(CT_DEPTH_CUSTOMERCODE, '0');
                                //}
                                //else
                                //{
                                //    row[_dataSet.StcDetail.CustomerCodeColumn.ColumnName] = string.Empty;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                                // ���Ӑ�R�[�h
                                row[_dataSet.StcDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                                // ���Ӑ於
                                row[_dataSet.StcDetail.CustomerSnmColumn.ColumnName] = data.CustomerSnm;

                                //// �ۑ�����Ă���`�[�ԍ����X�V (�d��SEQ/�x��No�Ŕ�r����)
                                //if (data.SupplierSlipNo != supplierSlipNoExt)
                                //{
                                //    // �قȂ��Ă����ꍇ�͕ۑ�
                                //    supplierSlipNoExt = data.SupplierSlipNo;
                                //}

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
                                if (data.SupplierFormal != 2)
                                {
                                    //if (data.StockSlipCdDtl 
                                    switch ( data.StockSlipCdDtl )
                                    {
                                        default:
                                        case 0:
                                        case 1:
                                            {
                                                row[_dataSet.StcDetail.StockSlipCdDtlColumn.ColumnName] = "�ʏ�";
                                            }
                                            break;
                                        case 2:
                                            {
                                                if ( string.IsNullOrEmpty( data.GoodsNo ) )
                                                {
                                                    row[_dataSet.StcDetail.StockSlipCdDtlColumn.ColumnName] = "�s�l��";
                                                }
                                                else
                                                {
                                                    row[_dataSet.StcDetail.StockSlipCdDtlColumn.ColumnName] = "���i�l��";
                                                }
                                            }
                                            break;
                                    }
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD

                                // ----------ADD 2013/01/21----------->>>>>
                                // �s�ԍ�([�L�[��]���o�f�[�^�݌v)
                                retRow[_dataSet.RetGdsStcDetail.RowNoColumn.ColumnName] = rowNo;
                                // �d��SEQ/�x����[0�̂Ƃ��͋�]
                                retRow[_dataSet.RetGdsStcDetail.SupplierSlipNoColumn.ColumnName] = row[_dataSet.StcDetail.SupplierSlipNoColumn.ColumnName];
                                // �sNo
                                retRow[_dataSet.RetGdsStcDetail.StockRowNoColumn.ColumnName] = data.StockRowNo;

                                //�d�����͎҃R�[�h
                                retRow[_dataSet.RetGdsStcDetail.StockInputCodeColumn.ColumnName] = data.StockInputCode;
                                //�d���S���҃R�[�h
                                retRow[_dataSet.RetGdsStcDetail.StockAgentCodeColumn.ColumnName] = data.StockAgentCode;
                                //���i����
                                retRow[_dataSet.RetGdsStcDetail.GoodsKindCodeColumn.ColumnName] = data.GoodsKindCode;
                                //���[�J�[�J�i����
                                retRow[_dataSet.RetGdsStcDetail.MakerKanaNameColumn.ColumnName] = data.MakerKanaName;
                                //���[�J�[�J�i���́i�ꎮ�j
                                retRow[_dataSet.RetGdsStcDetail.CmpltMakerKanaNameColumn.ColumnName] = data.CmpltMakerKanaName;
                                //���i���̃J�i
                                retRow[_dataSet.RetGdsStcDetail.GoodsNameKanaColumn.ColumnName] = data.GoodsNameKana;
                                //���i�啪�ރR�[�h
                                retRow[_dataSet.RetGdsStcDetail.GoodsLGroupColumn.ColumnName] = data.GoodsLGroup;
                                //���i�啪�ޖ���
                                retRow[_dataSet.RetGdsStcDetail.GoodsLGroupNameColumn.ColumnName] = data.GoodsLGroupName;
                                //���i�����ރR�[�h
                                retRow[_dataSet.RetGdsStcDetail.GoodsMGroupColumn.ColumnName] = data.GoodsMGroup;
                                //���i�����ޖ���
                                retRow[_dataSet.RetGdsStcDetail.GoodsMGroupNameColumn.ColumnName] = data.GoodsMGroupName;
                                //BL�O���[�v�R�[�h����
                                retRow[_dataSet.RetGdsStcDetail.BLGroupNameColumn.ColumnName] = data.BLGroupName;
                                //BL���i�R�[�h���́i�S�p�j
                                retRow[_dataSet.RetGdsStcDetail.BLGoodsFullNameColumn.ColumnName] = data.BLGoodsFullName;
                                //���Е��ރR�[�h
                                retRow[_dataSet.RetGdsStcDetail.EnterpriseGanreCodeColumn.ColumnName] = data.EnterpriseGanreCode;
                                //�|���ݒ苒�_�i�d���P���j
                                retRow[_dataSet.RetGdsStcDetail.RateSectStckUnPrcColumn.ColumnName] = data.RateSectStckUnPrc;
                                //�|���ݒ�敪�i�d���P���j
                                retRow[_dataSet.RetGdsStcDetail.RateDivStckUnPrcColumn.ColumnName] = data.RateDivStckUnPrc;
                                //�P���Z�o�敪�i�d���P���j
                                retRow[_dataSet.RetGdsStcDetail.UnPrcCalcCdStckUnPrcColumn.ColumnName] = data.UnPrcCalcCdStckUnPrc;
                                //���i�敪�i�d���P���j
                                retRow[_dataSet.RetGdsStcDetail.PriceCdStckUnPrcColumn.ColumnName] = data.PriceCdStckUnPrc;
                                //��P���i�d���P���j
                                retRow[_dataSet.RetGdsStcDetail.StdUnPrcStckUnPrcColumn.ColumnName] = data.StdUnPrcStckUnPrc;
                                //�[�������P�ʁi�d���P���j
                                retRow[_dataSet.RetGdsStcDetail.FracProcUnitStcUnPrcColumn.ColumnName] = data.FracProcUnitStcUnPrc;
                                //�[�������i�d���P���j
                                retRow[_dataSet.RetGdsStcDetail.FracProcStckUnPrcColumn.ColumnName] = data.FracProcStckUnPrc;
                                //�d���P���i�ō��C�����j
                                retRow[_dataSet.RetGdsStcDetail.StockUnitTaxPriceFlColumn.ColumnName] = data.StockUnitTaxPriceFl;
                                //�d���P���ύX�敪
                                retRow[_dataSet.RetGdsStcDetail.StockUnitChngDivColumn.ColumnName] = data.StockUnitChngDiv;
                                //BL���i�R�[�h�i�|���j
                                retRow[_dataSet.RetGdsStcDetail.RateBLGoodsCodeColumn.ColumnName] = data.RateBLGoodsCode;
                                //BL���i�R�[�h���́i�|���j
                                retRow[_dataSet.RetGdsStcDetail.RateBLGoodsNameColumn.ColumnName] = data.RateBLGoodsName;
                                //���i�|���O���[�v�R�[�h�i�|���j
                                retRow[_dataSet.RetGdsStcDetail.RateGoodsRateGrpCdColumn.ColumnName] = data.RateGoodsRateGrpCd;
                                //���i�|���O���[�v���́i�|���j
                                retRow[_dataSet.RetGdsStcDetail.RateGoodsRateGrpNmColumn.ColumnName] = data.RateGoodsRateGrpNm;
                                //BL�O���[�v�R�[�h�i�|���j
                                retRow[_dataSet.RetGdsStcDetail.RateBLGroupCodeColumn.ColumnName] = data.RateBLGroupCode;
                                //BL�O���[�v���́i�|���j
                                retRow[_dataSet.RetGdsStcDetail.RateBLGroupNameColumn.ColumnName] = data.RateBLGroupName;
                                //��������
                                retRow[_dataSet.RetGdsStcDetail.OrderCntColumn.ColumnName] = data.OrderCnt;
                                //����������
                                retRow[_dataSet.RetGdsStcDetail.OrderAdjustCntColumn.ColumnName] = data.OrderAdjustCnt;
                                //�����c��
                                retRow[_dataSet.RetGdsStcDetail.OrderRemainCntColumn.ColumnName] = data.OrderRemainCnt;
                                //�c���X�V��
                                retRow[_dataSet.RetGdsStcDetail.RemainCntUpdDateColumn.ColumnName] = data.RemainCntUpdDate;
                                //�d���`�[���ה��l1
                                retRow[_dataSet.RetGdsStcDetail.StockDtiSlipNote1Column.ColumnName] = data.StockDtiSlipNote1;
                                //�̔���R�[�h
                                retRow[_dataSet.RetGdsStcDetail.SalesCustomerCodeColumn.ColumnName] = data.SalesCustomerCode;
                                //�̔��旪��
                                retRow[_dataSet.RetGdsStcDetail.SalesCustomerSnmColumn.ColumnName] = data.SalesCustomerSnm;
                                //�`�[�����P
                                retRow[_dataSet.RetGdsStcDetail.SlipMemo1Column.ColumnName] = data.SlipMemo1;
                                //�`�[�����Q
                                retRow[_dataSet.RetGdsStcDetail.SlipMemo2Column.ColumnName] = data.SlipMemo2;
                                //�`�[�����R
                                retRow[_dataSet.RetGdsStcDetail.SlipMemo3Column.ColumnName] = data.SlipMemo3;
                                //�Г������P
                                retRow[_dataSet.RetGdsStcDetail.InsideMemo1Column.ColumnName] = data.InsideMemo1;
                                //�Г������Q
                                retRow[_dataSet.RetGdsStcDetail.InsideMemo2Column.ColumnName] = data.InsideMemo2;
                                //�Г������R
                                retRow[_dataSet.RetGdsStcDetail.InsideMemo3Column.ColumnName] = data.InsideMemo3;
                                //�[�i��R�[�h
                                retRow[_dataSet.RetGdsStcDetail.AddresseeCodeColumn.ColumnName] = data.AddresseeCode;
                                //�[�i�於��
                                retRow[_dataSet.RetGdsStcDetail.AddresseeNameColumn.ColumnName] = data.AddresseeName;
                                //�����敪
                                retRow[_dataSet.RetGdsStcDetail.DirectSendingCdColumn.ColumnName] = data.DirectSendingCd;
                                //�����ԍ�
                                retRow[_dataSet.RetGdsStcDetail.OrderNumberColumn.ColumnName] = data.OrderNumber;
                                //�������@
                                retRow[_dataSet.RetGdsStcDetail.WayToOrderColumn.ColumnName] = data.WayToOrder;
                                //�[�i�����\���
                                retRow[_dataSet.RetGdsStcDetail.DeliGdsCmpltDueDateColumn.ColumnName] = data.DeliGdsCmpltDueDate;
                                //��]�[��
                                retRow[_dataSet.RetGdsStcDetail.ExpectDeliveryDateColumn.ColumnName] = data.ExpectDeliveryDate;
                                //�����f�[�^�쐬�敪
                                retRow[_dataSet.RetGdsStcDetail.OrderDataCreateDivColumn.ColumnName] = data.OrderDataCreateDiv;
                                //�����f�[�^�쐬��
                                retRow[_dataSet.RetGdsStcDetail.OrderDataCreateDateColumn.ColumnName] = data.OrderDataCreateDate;
                                //���������s�ϋ敪
                                retRow[_dataSet.RetGdsStcDetail.OrderFormIssuedDivColumn.ColumnName] = data.OrderFormIssuedDiv;
                                // �󒍔ԍ�
                                retRow[_dataSet.RetGdsStcDetail.AcceptAnOrderNoColumn.ColumnName] = data.AcceptAnOrderNo;
                                // ���ʒʔ�
                                retRow[_dataSet.RetGdsStcDetail.CommonSeqNoColumn.ColumnName] = data.CommonSeqNo;
                                // �d�����גʔ�
                                retRow[_dataSet.RetGdsStcDetail.StockSlipDtlNumColumn.ColumnName] = data.StockSlipDtlNum;
                                //�d�����גʔԁi���j
                                retRow[_dataSet.RetGdsStcDetail.StockSlipDtlNumSrcColumn.ColumnName] = data.StockSlipDtlNumSrc;
                                //���㖾�גʔԁi�����j
                                retRow[_dataSet.RetGdsStcDetail.SalesSlipDtlNumSyncColumn.ColumnName] = data.SalesSlipDtlNumSync;
                                // �d���`���i���j
                                retRow[_dataSet.RetGdsStcDetail.SupplierFormalSrcColumn.ColumnName] = data.SupplierFormalSrc;
                                //����R�[�h�i���ׁj
                                retRow[_dataSet.RetGdsStcDetail.SubSectionCodeColumn.ColumnName] = data.DtlSubSectionCode;
                                //���Е��ޖ��́i���ׁj
                                retRow[_dataSet.RetGdsStcDetail.EnterpriseGanreNameColumn.ColumnName] = data.EnterpriseGanreName;
                                //���i�|�������N�i���ׁj
                                retRow[_dataSet.RetGdsStcDetail.GoodsRateRankColumn.ColumnName] = data.GoodsRateRank;
                                //���Ӑ�|���O���[�v�R�[�h�i���ׁj
                                retRow[_dataSet.RetGdsStcDetail.CustRateGrpCodeColumn.ColumnName] = data.CustRateGrpCode;
                                //�d����|���O���[�v�R�[�h�i���ׁj
                                retRow[_dataSet.RetGdsStcDetail.SuppRateGrpCodeColumn.ColumnName] = data.SuppRateGrpCode;
                                //�艿�i�ō��C�����j�i���ׁj
                                retRow[_dataSet.RetGdsStcDetail.ListPriceTaxIncFlColumn.ColumnName] = data.ListPriceTaxIncFl;
                                //�d�����i���ׁj
                                retRow[_dataSet.RetGdsStcDetail.StockRateColumn.ColumnName] = data.StockRate;
                                //�ېŋ敪�i���ׁj
                                retRow[_dataSet.RetGdsStcDetail.TaxationCodeColumn.ColumnName] = data.TaxationCode;

                                //�d���`�[�敪�i���ׁj
                                row[_dataSet.StcDetail.StockSlipCdDtlIntColumn.ColumnName] = data.StockSlipCdDtl;
                                // �_���폜�敪(����)
                                row[_dataSet.StcDetail.LogicalDeleteCodeColumn.ColumnName] = data.DtlLogicalDeleteCode;
                                // ----------ADD 2013/01/21-----------<<<<<

                                #endregion // ���ׁE�d���f�[�^
                            }
                            else
                            {
                                #region ���ׁE�x���f�[�^

                                // �I���`�F�b�N�{�b�N�X
                                row[_dataSet.StcDetail.SelectionCheckColumn.ColumnName] = DBNull.Value; // ADD 2013/01/21 [�d���ԕi�\��]
                                // �`�[�敪
                                row[_dataSet.StcDetail.DataDivColumn.ColumnName] = data.DataDiv;
                                // �s�ԍ�(���o�f�[�^�݌v)
                                row[_dataSet.StcDetail.RowNoColumn.ColumnName] = rowNo;
                                // �`�[���t
                                row[_dataSet.StcDetail.StockDateColumn.ColumnName] = data.StockDate;
                                // �`�[�ԍ�
                                row[_dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName] = string.Empty;
                                // �sNo
                                row[_dataSet.StcDetail.StockRowNoColumn.ColumnName] = data.StockRowNo;
                                // �d���`��
                                row[_dataSet.StcDetail.SupplierFormalColumn.ColumnName] = data.SupplierFormal;
                                // �d���`�[�敪
                                row[_dataSet.StcDetail.SupplierSlipCdColumn.ColumnName] = data.SupplierSlipCd;
                                // �d���`�[�敪��
                                row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_05;
                                // �S���Җ�
                                row[_dataSet.StcDetail.StockAgentNameColumn.ColumnName] = data.StockAgentName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                                //// ���z
                                //row[_dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName] = data.StockTtlPricTaxExc;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                                // ���z(����)
                                row[_dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName] = data.StockPriceTaxExc;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                                // �i��
                                row[_dataSet.StcDetail.GoodsNameColumn.ColumnName] = data.GoodsName;
                                // �i��
                                row[_dataSet.StcDetail.GoodsNoColumn.ColumnName] = string.Empty; //DBNull.Value;
                                // ���[�J�[�R�[�h
                                row[_dataSet.StcDetail.GoodsMakerCdColumn.ColumnName] = string.Empty; //DBNull.Value;
                                // ���[�J�[��
                                row[_dataSet.StcDetail.MakerNameColumn.ColumnName] = string.Empty;
                                // BL�R�[�h
                                row[_dataSet.StcDetail.BLGoodsCodeColumn.ColumnName] = string.Empty; //DBNull.Value;
                                // BL�O���[�v
                                row[_dataSet.StcDetail.BLGroupCodeColumn.ColumnName] = string.Empty; //DBNull.Value;
                                // ����
                                row[_dataSet.StcDetail.StockCountColumn.ColumnName] = DBNull.Value;
                                // �I�[�v�����i�敪
                                row[_dataSet.StcDetail.OpenPriceDivColumn.ColumnName] = data.OpenPriceDiv;
                                // �W�����i
                                //row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = string.Empty; //DEL 2011/12/09
                                row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = DBNull.Value; //ADD 2011/12/09
                                // �����
                                row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                // ����ŗ�
                                row[_dataSet.StcDetail.SupplierConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD ���V�� 2020/03/11 PMKOBETSU-2912 
                                // ���l�P
                                row[_dataSet.StcDetail.SupplierSlipNote1Column.ColumnName] = data.SupplierSlipNote1;
                                // ���l�Q
                                if (data.SupplierSlipNote2.Equals("0"))
                                {
                                    row[_dataSet.StcDetail.SupplierSlipNote2Column.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.SupplierSlipNote2Column.ColumnName] = CT_SUPPLIERNOTE2_PRE + data.SupplierSlipNote2;
                                }
                                // ���_�R�[�h
                                row[_dataSet.StcDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                                // ���_��
                                row[_dataSet.StcDetail.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                                // ���s��
                                // row[_dataSet.StcDetail.StockInputNameColumn.ColumnName] = data.StockInputName; // DEL 2009/09/08
                                // �d����R�[�h[NULL�̂Ƃ��͋�]
                                if (data.SupplierCd == 0)
                                {
                                    row[_dataSet.StcDetail.SupplierCdColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.SupplierCdColumn.ColumnName] = data.SupplierCd;//data.SupplierCd.ToString().PadLeft(CT_DEPTH_SUPPLIERCODE, '0');
                                }
                                // �d���於
                                row[_dataSet.StcDetail.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                                // �ݎ�
                                row[_dataSet.StcDetail.StockOrderDivCdColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName] = string.Empty;
                                // �q�ɃR�[�h
                                row[_dataSet.StcDetail.WarehouseCdColumn.ColumnName] = string.Empty;
                                // �q�ɖ�
                                row[_dataSet.StcDetail.WarehouseNameColumn.ColumnName] = string.Empty;
                                // �I��
                                row[_dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName] = string.Empty;
                                // UOE���}�[�N1
                                row[_dataSet.StcDetail.UoeRemark1Column.ColumnName] = string.Empty;
                                // UOE���}�[�N2
                                row[_dataSet.StcDetail.UoeRemark2Column.ColumnName] = string.Empty;
                                // �d��SEQ/�x����[NULL�̂Ƃ��͋�]
                                if (data.SupplierSlipNo == 0)
                                {
                                    row[_dataSet.StcDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                                }
                                // �v���
                                if (data.StockAddUpADate == DateTime.MinValue)
                                {
                                    row[_dataSet.StcDetail.StockAddUpADateColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.StockAddUpADateColumn.ColumnName] = data.StockAddUpADate;
                                }
                                // ���|�敪
                                row[_dataSet.StcDetail.AccPayDivCdColumn.ColumnName] = DBNull.Value;
                                // ���|�敪��
                                row[_dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName] = string.Empty;
                                // �ԓ`�敪
                                if (data.DebitNoteDiv == 0)
                                {
                                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_KURODEN;
                                }
                                else if (data.DebitNoteDiv == 1)
                                {
                                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_AKADEN;
                                }
                                else if (data.DebitNoteDiv == 2)
                                {
                                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_MOTOKURO;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                                }
                                // ��������`�[�ԍ�
                                row[_dataSet.StcDetail.SalesSlipNumColumn.ColumnName] = string.Empty;
                                // ����������t
                                row[_dataSet.StcDetail.SalesDateColumn.ColumnName] = DBNull.Value;
                                // ���Ӑ�R�[�h
                                row[_dataSet.StcDetail.CustomerCodeColumn.ColumnName] = DBNull.Value;
                                // ���Ӑ於
                                row[_dataSet.StcDetail.CustomerSnmColumn.ColumnName] = string.Empty;

                                // ----------ADD 2013/01/21----------->>>>>
                                // �s�ԍ�([�L�[��]���o�f�[�^�݌v)
                                retRow[_dataSet.RetGdsStcDetail.RowNoColumn.ColumnName] = rowNo;
                                // ----------ADD 2013/01/21-----------<<<<<

                                #endregion // ���ׁE�x���f�[�^
                            }

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                            //// �s�ǉ�
                            //this._dataSet.StcDetail.Rows.Add(row);
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                            if ( data.DataDiv == 0 )
                            {
                                this._dataSet.StcDetail.Rows.Add( row );
                                this._dataSet.RetGdsStcDetail.Rows.Add(retRow);  //ADD 2013/01/21 [�d���ԕi�v��]
                            }
                            else
                            {
                                // �萔���A�l�����̖��׃f�[�^�͂��̎��_�ł͍쐬���Ȃ�
                                if ( (data.StockRowNo != 0) && (string.IsNullOrEmpty( data.GoodsName.TrimEnd() )) == false )
                                {
                                    this._dataSet.StcDetail.Rows.Add( row );
                                    this._dataSet.RetGdsStcDetail.Rows.Add(retRow);  //ADD 2013/01/21 [�d���ԕi�v��]
                                }
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD

                            #endregion // ���׃f�[�^�e�[�u��

                            #region ���z�f�[�^���W�v

                            //-------------------------
                            // ���z�f�[�^���W�v
                            //-------------------------
                            if (data.DataDiv == 0)  // �d���f�[�^�̏ꍇ
                            {
                                // �W�����i���v(�W�����i * ����)
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                                //StandardPrice_Total += (data.ListPriceTaxExcFl * data.StockCount);
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                                if ( data.OpenPriceDiv == 0 )
                                {
                                    // �I�[�v�����i�͏���
                                    StandardPrice_Total += (data.ListPriceTaxExcFl * data.StockCount);
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                                //// �d�����z���v
                                //StockAmount_Total += data.StockTtlPricTaxExc;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                                //�d�����z���v(����)
                                StockAmount_Total2 += data.StockPriceTaxExc;   //ADD �����H�@2012/04/05 Redmine#29310
                                // �������v
                                //Cost_Total += data.Cost;
                                // �e���z���v(���׋��z - ����)
                                //GrossProfitAmount_Total += (data.ListPriceTaxExcFl - Double.Parse(data.Cost.ToString()));
                                // ����Łi�d�j
                                totalOfsThisSalesTax += data.StockPriceConsTax;
                                //����Łi���ׁj
                                //totalConsumeTaxAmount2 += data.StockPriceConsTaxDtl;    //ADD �����H�@2012/04/05 Redmine#29310  // DEL�@�A�����@2013/02/16 Redmine#34618
                                // -----ADD�@�A�����@2013/02/16 Redmine#34618----->>>>>
                                // �����
                                switch (data.SuppCTaxLayCd)
                                {
                                    // ���ד]��
                                    case 1:
                                        // ���Z����
                                        if (data.StockPriceConsTaxDtl == 0)//�R���o�[�g�f�[�^���̎d�����׃f�[�^�ɏ���ł��[���̏ꍇ�A����ł��Ď擾����
                                        {
                                            totalConsumeTaxAmount2 += data.StockPriceTaxInc - data.StockPriceTaxExc;
                                        }
                                        else
                                        {
                                            totalConsumeTaxAmount2 += data.StockPriceConsTaxDtl;
                                        }

                                        break;
                                    // �`�[�]��
                                    case 0:
                                        if (!data.SupplierSlipNo.Equals(supplierSlipNoExt)) // ��s�ڂ̂݉��Z
                                        {
                                            totalConsumeTaxAmount2 += data.StockTtlPricTaxInc - data.StockTtlPricTaxExc;
                                        }
                                        break;
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
                                // -----ADD�@�A�����@2013/02/16 Redmine#34618-----<<<<<
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
                                //// �����
                                //totalConsumeTaxAmount += data.StockPriceConsTax;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
                                // ���ʌv
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                                // ���ʌv�͍��v���͂Ə��i�l�����������ďW�v����(StockSlipCdDtl=2�ōs�l�����܂܂�邪�ǂ���ł����ʓ���)
                                if ( data.StockGoodsCd == 0 && data.StockSlipCdDtl != 2 )
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                                {
                                    totalAmount += data.StockCount;
                                }

                                // ����d��
                                totalThisStockPrice += data.StockTtlPricTaxExc;

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                                // �`�[�ʓ��ŋ��z�W�v
                                if ( data.TaxationCode == 2 )
                                {
                                    long consTaxInclu = (long)row[_dataSet.StcDetail.StockTtlPricTaxIncColumn.ColumnName]
                                                        - (long)row[_dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName];
                                    salAmntConsTaxInclu += consTaxInclu;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                                if (!string.IsNullOrEmpty(data.SalesSlipNum))
                                {
                                    salesSlipNum = data.SalesSlipNum;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                            }
                            else // �x���f�[�^�̏ꍇ
                            {
                                //����x��
                                totalThisTimePayNrml += data.StockTtlPricTaxExc;
                            }

                            // ���א�
                            detailSlipCount++;

                            #endregion // ���z�f�[�^���W�v

                            #region �`�[�\���f�[�^�e�[�u��
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                            # region // DEL
                            //// ����͍i�荞�݂��s��
                            //// �i���̏������ڂ͓`�[�ԍ��A�d���`��
                            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                            ////if (data.SupplierSlipNo != supplierSlipNoExt)//(!data.PartySaleSlipNum.Equals(exSlipNum) || data.SupplierFormal != exSupplierFormal)
                            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                            //if ( index > 0 && (data.SupplierSlipNo != supplierSlipNoExt || data.SupplierFormal != exSupplierFormal))
                            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                            //{
                            //    // �V�K�s���쐬����O�ɁA����ł��Z�b�g
                            //    if (row2 != null)
                            //    {
                            //        // ����ŕ\�� = �\��������Ŋz>0�̏ꍇ�͕\��
                            //        if (stckPrcConsTaxIncluAdjust && consumeTaxTotal > 0)
                            //        {
                            //            // ��ɃZ�b�g
                            //            row2[_dataSet.StcList.StockPriceConsTaxColumn.ColumnName] = consumeTaxTotal;
                            //        }
                            //        else
                            //        {
                            //            row2[_dataSet.StcList.StockPriceConsTaxColumn.ColumnName] = DBNull.Value;
                            //        }

                            //        this._dataSet.StcList.Rows.Add(row2);

                            //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                            //        // �d�����z���v
                            //        StockAmount_Total += wkStockAmount;
                            //        // �����
                            //        totalConsumeTaxAmount += wkTotalConsumeTaxAmount;
                            //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

                            //        // �`�[����+1
                            //        slipCount++;
                            //    }
                            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                            //    wkStockAmount = data.StockTtlPricTaxExc;
                            //    wkTotalConsumeTaxAmount = data.StockPriceConsTax;
                            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD

                            //    // �`�[�ԍ�����юd���`�����قȂ�Εʓ`�[�Ƃ��Ď擾
                            //    row2 = _dataSet.StcList.NewRow();

                            //    // ����Ŋz�̏����l�����Z�b�g
                            //    consumeTaxTotal = 0;

                            //    // �d���`�[�Ȃ̂��x���`�[�Ȃ̂��Ńf�[�^�̍\�����قȂ�
                            //    if (data.DataDiv == 0)
                            //    {
                            //        #region �d���`�[
                            //        //-----------
                            //        // �d���`�[
                            //        //-----------

                            //        //row2[_dataSet.StcList.SelectionColumn.ColumnName] = false;
                            //        // �sNo
                            //        row2[_dataSet.StcList.RowNoColumn.ColumnName] = rowNo;
                            //        // �f�[�^�敪
                            //        row2[_dataSet.StcList.DataDivColumn.ColumnName] = data.DataDiv;
                            //        // �`�[���t
                            //        row2[_dataSet.StcList.StockDateColumn.ColumnName] = data.StockDate;
                            //        // �`�[�ԍ�
                            //        row2[_dataSet.StcList.PartySaleSlipNumColumn.ColumnName] = data.PartySaleSlipNum;
                            //        // �d���`��
                            //        row2[_dataSet.StcList.SupplierFormalColumn.ColumnName] = data.SupplierFormal;
                            //        // �d���`�[�敪
                            //        row2[_dataSet.StcList.SupplierSlipCdColumn.ColumnName] = data.SupplierSlipCd;
                            //        // �d���`�[�敪������
                            //        if (data.SupplierFormal == 0)   // �d��
                            //        {
                            //            if (data.SupplierSlipCd == 10)
                            //            {
                            //                row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_01;
                            //            }
                            //            else if (data.SupplierSlipCd == 20)
                            //            {
                            //                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                            //                //row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_02;
                            //                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                            //                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                            //                row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_01 + CT_SUPPLIERSLIPCD_NAME_02; // �d���ԕi
                            //                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                            //            }
                            //        }
                            //        else if (data.SupplierFormal == 1)   // ��
                            //        {
                            //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                            //            //row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_03;
                            //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                            //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                            //            if ( data.SupplierSlipCd == 10 )
                            //            {
                            //                row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_04; // ����
                            //            }
                            //            else if ( data.SupplierSlipCd == 20 )
                            //            {
                            //                row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_04 + CT_SUPPLIERSLIPCD_NAME_02; // ���וԕi
                            //            }
                            //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                            //        }
                            //        else if (data.SupplierFormal == 2)   // �o��
                            //        {
                            //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                            //            //row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_04;
                            //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                            //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                            //            row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_03; // ����
                            //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                            //        }
                            //        else // �x��
                            //        {
                            //            // [���x���`�[�͂����ɂ��Ȃ�]
                            //            //row[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_05;
                            //        }
                            //        // �S����
                            //        row2[_dataSet.StcList.StockAgentNameColumn.ColumnName] = data.StockAgentName;
                            //        // ���z
                            //        row2[_dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName] = data.StockTtlPricTaxExc;

                            //        // ����ł̗݌v���擾
                            //        consumeTaxTotal = data.StockPriceConsTax;
                                    
                            //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                            //        //// ����œ]�ŋ敪�ɂ��\�����邩���Ȃ���

                            //        //// [���z�\������]�̏ꍇ�͑S�ĕ\��(���גP�ʂƓ����Ȃ̂�)
                            //        //if (data.SuppTtlAmntDspWayCd == 1) // *** ���z�\������ ***
                            //        //{
                            //        //    // [���z�\������]�̏ꍇ�͖��גP�ʈȊO�͐ݒ肳��Ȃ��B���׈ȊO���l������K�v�Ȃ�
                            //        //    // �e�X�g���ɂ��A���׈ȊO��ݒ肵�Ă���f�[�^������ꍇ�́A�f�[�^���ԈႢ
                            //        //    stckPrcConsTaxIncluAdjust = true;
                            //        //}
                            //        //else // *** ���z�\�����Ȃ� ***
                            //        //{
                            //        //    if (data.SuppCTaxLayCd == 0 || // �`�[�P��(0)
                            //        //        data.SuppCTaxLayCd == 1)   // ���גP��(1)
                            //        //    {
                            //        //        // �\������
                            //        //        stckPrcConsTaxIncluAdjust = true;
                            //        //    }
                            //        //    else // �����e(2)�E�����q(3)�E��ې�(9)
                            //        //    {
                            //        //        // ���ŋ��z������Γ��ŋ��z��\������
                            //        //        if (data.StckPrcConsTaxInclu > 0)
                            //        //        {
                            //        //            stckPrcConsTaxIncluAdjust = true;
                            //        //        }
                            //        //        else
                            //        //        {
                            //        //            // ���ŋ��z���Ȃ���Δ�\��
                            //        //            stckPrcConsTaxIncluAdjust = false;
                            //        //        }
                            //        //    }
                            //        //}
                            //        //// �����
                            //        //row2[_dataSet.StcList.ConsumeTaxColumn.ColumnName] = data.StockTtlPricTaxInc - data.StockTtlPricTaxExc;
                            //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                            //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                            //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                            //        # region [����Ŋ֘A]
                            //        bool printTax = true;
                            //        Int64 salesTotalTaxInc;
                            //        Int64 salesTotalTaxExc = data.SalesTotalTaxExc;
                            //        Int64 salesPriceConsTax;

                            //        // ����������Ŋz�̎擾
                            //        if ( data.ConsTaxLayMethod == 0 || data.ConsTaxLayMethod == 1 ) // �`�[�P��or���גP��
                            //        {
                            //            salesPriceConsTax = data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                            //        }
                            //        else
                            //        {
                            //            salesPriceConsTax = 0;
                            //        }

                            //        // �ō����z�̎擾
                            //        salesTotalTaxInc = salesTotalTaxExc + salesPriceConsTax;

                            //        if ( printTax )
                            //        {
                            //            // ����ň󎚗L������Ƌ��z����
                            //            int totalAmountDispWayCd = data.TotalAmountDispWayCd;

                            //            // ����ň󎚗L������
                            //            printTax = ReflectMoneyForTaxPrintOfSlip( ref salesTotalTaxExc, ref salesPriceConsTax, ref salAmntConsTaxInclu, ref salesTotalTaxInc, totalAmountDispWayCd, data.ConsTaxLayMethod );
                            //            if ( printTax )
                            //            {
                            //                if ( salesPriceConsTax != 0 )
                            //                {
                            //                    row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = salesPriceConsTax;
                            //                }
                            //                else
                            //                {
                            //                    // �󎚂��Ȃ�
                            //                    row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                            //                }
                            //            }
                            //            else
                            //            {
                            //                // �󎚂��Ȃ�
                            //                row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                            //            }
                            //        }
                            //        else
                            //        {
                            //            // �󎚂��Ȃ�
                            //            row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                            //        }
                            //        // �Ŕ����z�Z�b�g
                            //        row2[_dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName] = salesTotalTaxExc;
                            //        // �e���Z�b�g
                            //        row2[_dataSet.SalesList.GrossProfitColumn.ColumnName] = salesTotalTaxExc - data.TotalCost;
                            //        # endregion
                            //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

                            //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD

                            //        // ���l�P
                            //        row2[_dataSet.StcList.SupplierSlipNote1Column.ColumnName] = data.SupplierSlipNote1;
                            //        // ���l�Q
                            //        row2[_dataSet.StcList.SupplierSlipNote2Column.ColumnName] = data.SupplierSlipNote2;
                            //        // ���_�R�[�h
                            //        row2[_dataSet.StcList.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                            //        // ���_��
                            //        row2[_dataSet.StcList.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                            //        // ���s��
                            //        row2[_dataSet.StcList.StockInputNameColumn.ColumnName] = data.StockInputName;
                            //        // �d����R�[�h[NULL�̂Ƃ��͋�]
                            //        if (data.SupplierCd == 0)
                            //        {
                            //            row2[_dataSet.StcList.SupplierCdColumn.ColumnName] = string.Empty; //DBNull.Value;
                            //        }
                            //        else
                            //        {
                            //            row2[_dataSet.StcList.SupplierCdColumn.ColumnName] = data.SupplierCd;//.ToString().PadLeft(CT_DEPTH_SUPPLIERCODE, '0');
                            //        }
                            //        // �d���於
                            //        row2[_dataSet.StcList.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                            //        // UOE���}�[�N1
                            //        row2[_dataSet.StcList.UoeRemark1Column.ColumnName] = data.UoeRemark1;
                            //        // UOE���}�[�N2
                            //        row2[_dataSet.StcList.UoeRemark2Column.ColumnName] = data.UoeRemark2;
                            //        // �d��SEQ/�x����[NULL�̂Ƃ��͋�]
                            //        if (data.SupplierSlipNo == 0)
                            //        {
                            //            row2[_dataSet.StcList.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                            //        }
                            //        else
                            //        {
                            //            row2[_dataSet.StcList.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                            //        }
                            //        // �v���
                            //        row2[_dataSet.StcList.StockAddUpADateColumn.ColumnName] = data.StockAddUpADate;
                            //        // ���|�敪
                            //        row2[_dataSet.StcList.AccPayDivCdColumn.ColumnName] = data.AccPayDivCd;
                            //        // ���|�敪��
                            //        if (data.AccPayDivCd == 1)
                            //        {
                            //            row2[_dataSet.StcList.AccPayDivCdNameColumn.ColumnName] = CT_ACCPAYDIV_NAME_01;
                            //        }
                            //        // �ԓ`�敪
                            //        if (data.DebitNoteDiv == 0)
                            //        {
                            //            row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_KURODEN;
                            //        }
                            //        else if (data.DebitNoteDiv == 1)
                            //        {
                            //            row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_AKADEN;
                            //        }
                            //        else if (data.DebitNoteDiv == 2)
                            //        {
                            //            row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_MOTOKURO;
                            //        }
                            //        else
                            //        {
                            //            row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = string.Empty;
                            //        }

                            //        #endregion // �d���`�[
                            //    }
                            //    else
                            //    {
                            //        #region �x���`�[
                            //        //----------
                            //        // �x���`�[
                            //        //----------

                            //        //row2[_dataSet.StcList.SelectionColumn.ColumnName] = false;
                            //        // �sNo
                            //        row2[_dataSet.StcList.RowNoColumn.ColumnName] = rowNo;
                            //        // �f�[�^�敪
                            //        row2[_dataSet.StcList.DataDivColumn.ColumnName] = data.DataDiv;
                            //        // �`�[���t
                            //        row2[_dataSet.StcList.StockDateColumn.ColumnName] = data.StockDate;
                            //        // �`�[�ԍ�
                            //        row2[_dataSet.StcList.PartySaleSlipNumColumn.ColumnName] = string.Empty;
                            //        // �d���`��
                            //        row2[_dataSet.StcList.SupplierFormalColumn.ColumnName] = data.SupplierFormal;
                            //        // �d���`�[�敪
                            //        row2[_dataSet.StcList.SupplierSlipCdColumn.ColumnName] = data.SupplierSlipCd;
                            //        // �d���`�[�敪������
                            //        row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_05;
                            //        // �S����
                            //        row2[_dataSet.StcList.StockAgentNameColumn.ColumnName] = data.StockAgentName;
                            //        // ���z
                            //        row2[_dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName] = data.StockTtlPricTaxExc;
                            //        // �����
                            //        row2[_dataSet.StcList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                            //        // ���l�P
                            //        row2[_dataSet.StcList.SupplierSlipNote1Column.ColumnName] = data.SupplierSlipNote1;
                            //        // ���l�Q
                            //        row2[_dataSet.StcList.SupplierSlipNote2Column.ColumnName] = string.Empty;
                            //        // ���_
                            //        // ���_�R�[�h
                            //        row2[_dataSet.StcList.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                            //        // ���_��
                            //        row2[_dataSet.StcList.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                            //        // ���s��
                            //        row2[_dataSet.StcList.StockInputNameColumn.ColumnName] = data.StockInputName;
                            //        // �d����R�[�h[NULL�̂Ƃ��͋�]
                            //        if (data.SupplierCd == 0)
                            //        {
                            //            row2[_dataSet.StcList.SupplierCdColumn.ColumnName] = string.Empty; //DBNull.Value;
                            //        }
                            //        else
                            //        {
                            //            row2[_dataSet.StcList.SupplierCdColumn.ColumnName] = data.SupplierCd.ToString().PadLeft(CT_DEPTH_SUPPLIERCODE, '0');
                            //        }
                            //        // �d���於
                            //        row2[_dataSet.StcList.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                            //        // UOE���}�[�N1
                            //        row2[_dataSet.StcList.UoeRemark1Column.ColumnName] = string.Empty;
                            //        // UOE���}�[�N2
                            //        row2[_dataSet.StcList.UoeRemark2Column.ColumnName] = string.Empty;
                            //        // �d��SEQ/�x����[NULL�̂Ƃ��͋�]
                            //        if (data.SupplierSlipNo == 0)
                            //        {
                            //            row2[_dataSet.StcList.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                            //        }
                            //        else
                            //        {
                            //            row2[_dataSet.StcList.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                            //        }
                            //        // �v���
                            //        row2[_dataSet.StcList.StockAddUpADateColumn.ColumnName] = data.StockAddUpADate;
                            //        // ���|�敪
                            //        row2[_dataSet.StcList.AccPayDivCdColumn.ColumnName] = data.AccPayDivCd;
                            //        // ���|�敪��
                            //        row2[_dataSet.StcList.AccPayDivCdNameColumn.ColumnName] = string.Empty;
                            //        // �ԓ`�敪
                            //        if (data.DebitNoteDiv == 0)
                            //        {
                            //            row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_KURODEN;
                            //        }
                            //        else if (data.DebitNoteDiv == 1)
                            //        {
                            //            row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_AKADEN;
                            //        }
                            //        else if (data.DebitNoteDiv == 2)
                            //        {
                            //            row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_MOTOKURO;
                            //        }
                            //        else
                            //        {
                            //            row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = string.Empty;
                            //        }

                            //        #endregion // �x���`�[
                            //    }

                            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 DEL
                            //    //// �Ō�̍s�̂݁A�`�[�ԍ��̔�r���s�킸�ɍs��ǉ�����
                            //    //if (rowNo == allRowCount)
                            //    //{
                            //    //    // �s�ǉ�
                            //    //    this._dataSet.StcList.Rows.Add(row2);

                            //    //    // �`�[����+1
                            //    //    slipCount++;
                            //    //}
                            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 DEL

                            //    // �`�[�ԍ���ۑ�
                            //    supplierSlipNoExt = data.SupplierSlipNo;
                            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                            //    exSupplierFormal = data.SupplierFormal;
                            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD

                            //    // �`�[�ԍ�����ю󒍃X�e�[�^�X��ۑ�
                            //    //exSupplierFormal = data.SupplierFormal;
                            //    //exSlipNum = data.PartySaleSlipNum;
                            //}
                            //else
                            //{
                            //    // [���z�\������]�̏ꍇ�͑S�ĕ\��(���גP�ʂƓ����Ȃ̂�)
                            //    if (data.SuppTtlAmntDspWayCd == 1) // *** ���z�\������ ***
                            //    {
                            //        // ����Ŋz��݌v����
                            //        consumeTaxTotal += data.StockPriceConsTax;
                            //        stckPrcConsTaxIncluAdjust = true;
                            //    }
                            //    else // *** ���z�\�����Ȃ� ***
                            //    {
                            //        if (data.SuppCTaxLayCd == 0 || // �`�[�P��(0)
                            //            data.SuppCTaxLayCd == 1)   // ���גP��(1)
                            //        {
                            //            // ����Ŋz��݌v����
                            //            consumeTaxTotal += data.StockPriceConsTax;
                            //            stckPrcConsTaxIncluAdjust = true;
                            //        }
                            //        else // �����e(2)�E�����q(3)�E��ې�(9)
                            //        {
                            //            // ���ŋ��z������Γ��ŋ��z��݌v����
                            //            if (data.StckPrcConsTaxInclu + data.StckDisTtlTaxInclu > 0)
                            //            {
                            //                consumeTaxTotal += data.StckPrcConsTaxInclu + data.StckDisTtlTaxInclu;
                            //                stckPrcConsTaxIncluAdjust = true;
                            //            }
                            //            // ���ŋ��z���Ȃ���Η݌v���Ȃ�
                            //        }
                            //    }

                            //    // ����Ŋz��݌v����
                            //    //consumeTaxTotal += data.StckPrcConsTaxInclu;
                            //}
                            # endregion
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                            // DEL 2010/01/26 MANTIS�Ή�[14325]�F�C���X�g�[������Ɏd���`�[�~1�Ǝx���`�[�~1��o�^������ԂŌ�������ƁA�d���`�[���\������Ȃ� ---------->>>>>
                            // FIXME:�`�[�ԍ��܂��͎󒍃X�e�[�^�X���ω�������`�[�\���f�[�^�e�[�u�����\�z
                            //if ( index > 0 && (data.SupplierSlipNo != supplierSlipNoExt || data.SupplierFormal != exSupplierFormal) )
                            // DEL 2010/01/26 MANTIS�Ή�[14325]�F�C���X�g�[������Ɏd���`�[�~1�Ǝx���`�[�~1��o�^������ԂŌ�������ƁA�d���`�[���\������Ȃ� ----------<<<<<
                            // ADD 2010/01/26 MANTIS�Ή�[14325]�F�C���X�g�[������Ɏd���`�[�~1�Ǝx���`�[�~1��o�^������ԂŌ�������ƁA�d���`�[���\������Ȃ� ---------->>>>>
                            if (
                                index > 0
                                    &&
                                (data.SupplierSlipNo != supplierSlipNoExt || data.SupplierFormal != exSupplierFormal || !exSupplierSlipCdName.Equals(GetSupplierSlipCdName(data))))
                            {
                                // ADD 2010/01/26 MANTIS�Ή�[14325]�F�C���X�g�[������Ɏd���`�[�~1�Ǝx���`�[�~1��o�^������ԂŌ�������ƁA�d���`�[���\������Ȃ� ----------<<<<<
                                SuppPrtPprStcTblRsltWork prevData = (SuppPrtPprStcTblRsltWork)((suppPrtPprStcTblRsltWorkObj as ArrayList)[index - 1]);

                                rowDetailNo = rowNo;
                                if ( prevData.DataDiv != 0 )
                                {
                                    // �x���萔���E�x���l�� �s�ǉ�
                                    SuppPtrStcDetailDataSet.StcDetailDataTable table = this._dataSet.StcDetail;
                                    AddFeeAndDepositRow( ref table, ref rowDetailNo, prevData );
                                }
                                rowNo = rowDetailNo;

                                // �`�[�\���O���b�h�ւ̃Z�b�g
                                RecordSetToSlipList( prevData, rowNo, salAmntConsTaxInclu, prevSalesSlipNum );

                                // ���v�\���ɉ��Z
                                StockAmount_Total += prevData.StockTtlPricTaxExc;
                                if (prevData.SuppCTaxLayCd == 0 || prevData.SuppCTaxLayCd == 1)
                                {
                                    totalConsumeTaxAmount += prevData.StockPriceConsTax;
                                }
                                // �`�[����+1
                                slipCount++;

                                salAmntConsTaxInclu = 0; // �`�[�ʓ��ŋ��z�W�v�l��������
                                prevSalesSlipNum = salesSlipNum;
                                salesSlipNum = string.Empty;

                                // ADD 2010/01/27 MANTIS�Ή�[14545]�F���Ӑ�d�q�����Ɠ��l�̑��x�A�b�v�Ή��i2009/10/07���{�j�̑g�ݍ��� ---------->>>>>
                                if (ExtractCancelFlag == true)
                                {
                                    supplierSlipNoExt = data.SupplierSlipNo;
                                    exSupplierFormal = data.SupplierFormal;
                                    exSupplierSlipCdName = GetSupplierSlipCdName(data);
                                    rowNo++;

                                    break;
                                }
                                // ADD 2010/01/27 MANTIS�Ή�[14545]�F���Ӑ�d�q�����Ɠ��l�̑��x�A�b�v�Ή��i2009/10/07���{�j�̑g�ݍ��� ----------<<<<<
                            }
                            // �`�[�ԍ���ۑ�
                            supplierSlipNoExt = data.SupplierSlipNo;
                            exSupplierFormal = data.SupplierFormal;
                            exSupplierSlipCdName = GetSupplierSlipCdName(data); // �d���`�[�敪����ۑ�

                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                            #endregion // �`�[�\���f�[�^�e�[�u��

                            rowNo++;

                        }
                        catch (ConstraintException ex)
                        {
                            //MessageBox.Show(ex.Message);
                        }

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 ADD
                        //// �Ō�̍s�̂݁A�`�[�ԍ��̔�r���s�킸�ɍs��ǉ�����
                        //if ( rowNo - 1 == allRowCount )
                        //{
                        //    // �s�ǉ�
                        //    this._dataSet.StcList.Rows.Add( row2 );

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                        //    // �d�����z���v
                        //    StockAmount_Total += wkStockAmount;
                        //    // �����
                        //    totalConsumeTaxAmount += wkTotalConsumeTaxAmount;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        //    // �`�[�\���O���b�h�ւ̃Z�b�g
                        //    CustPrtPprSalTblRsltWork prevData = (CustPrtPprSalTblRsltWork)((custPrtPprSalTblRsltWorkObj as ArrayList)[index - 1]);
                        //    RecordSetToSlipList( prevData, rowNo, salAmntConsTaxInclu );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

                        //    // �`�[����+1
                        //    slipCount++;
                        //}
                        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 ADD
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                    } // for ( int index = 0; index < (suppPrtPprStcTblRsltWorkObj as ArrayList).Count; index++ )

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                    // �Ō�̍s�̂݁A�`�[�ԍ��̔�r���s�킸�ɍs��ǉ�����
                    if ( suppPrtPprStcTblRsltWorkObj != null && (suppPrtPprStcTblRsltWorkObj as ArrayList).Count > 0 )
                    {
                        ArrayList retList = (ArrayList)suppPrtPprStcTblRsltWorkObj;
                        // DEL 2010/01/27 MANTIS�Ή�[14545]�F���Ӑ�d�q�����Ɠ��l�̑��x�A�b�v�Ή��i2009/10/07���{�j�̑g�ݍ��� ---------->>>>>
                        // FIXME:SuppPrtPprStcTblRsltWork prevData = (SuppPrtPprStcTblRsltWork)(retList[retList.Count - 1]);
                        // DEL 2010/01/27 MANTIS�Ή�[14545]�F���Ӑ�d�q�����Ɠ��l�̑��x�A�b�v�Ή��i2009/10/07���{�j�̑g�ݍ��� ----------<<<<<
                        // ADD 2010/01/27 MANTIS�Ή�[14545]�F���Ӑ�d�q�����Ɠ��l�̑��x�A�b�v�Ή��i2009/10/07���{�j�̑g�ݍ��� ---------->>>>>
                        SuppPrtPprStcTblRsltWork prevData = (SuppPrtPprStcTblRsltWork)(retList[lastIndex]);
                        // ADD 2010/01/27 MANTIS�Ή�[14545]�F���Ӑ�d�q�����Ɠ��l�̑��x�A�b�v�Ή��i2009/10/07���{�j�̑g�ݍ��� ----------<<<<<

                        rowDetailNo = rowNo;
                        if ( prevData.DataDiv != 0 )
                        {
                            // �x���萔���E�x���l�� �s�ǉ�
                            SuppPtrStcDetailDataSet.StcDetailDataTable table = this._dataSet.StcDetail;
                            AddFeeAndDepositRow( ref table, ref rowDetailNo, prevData );
                        }
                        rowNo = rowDetailNo;

                        // �`�[�\���O���b�h�ւ̃Z�b�g
                        RecordSetToSlipList( prevData, rowNo, salAmntConsTaxInclu, salesSlipNum );

                        // ���v�\���ɉ��Z
                        StockAmount_Total += prevData.StockTtlPricTaxExc;
                        if ( prevData.SuppCTaxLayCd == 0 || prevData.SuppCTaxLayCd == 1 )
                        {
                            totalConsumeTaxAmount += prevData.StockPriceConsTax;
                        }

                        // �`�[����+1
                        slipCount++;
                    }

                    # region [�x���`�[�̍s���̔�]
                    // �x���̂ݍs�ԍ��̔Ԃ��Ȃ���
                    DateTime exStockDate = DateTime.MinValue;
                    rowDetailNo = 1;
                    int exStockNum = -1;
                    //exSlipNum = string.Empty;

                    string filter = string.Format( "{0} <> {1}", this._dataSet.StcDetail.DataDivColumn.ColumnName, 0 );
                    string sort = string.Format( "{0}, {1}, {2}, {3}, {4}, {5}",
                                    this._dataSet.StcDetail.StockDateColumn.ColumnName,
                                    this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName,
                                    this._dataSet.StcDetail.DataDivColumn.ColumnName,
                                    this._dataSet.StcDetail.SupplierFormalColumn.ColumnName,
                                    this._dataSet.StcDetail.SupplierSlipCdColumn.ColumnName,
                                    this._dataSet.StcDetail.StockRowNoColumn.ColumnName );

                    DataRow[] dataRows = this._dataSet.StcDetail.Select( filter, sort );
                    DataRow dataRow = null;
                    for ( int i = 0; i <= dataRows.Length - 1; i++ )
                    {
                        dataRow = dataRows[i];

                        if ( (exStockDate.Equals( dataRow[this._dataSet.StcDetail.StockDateColumn.ColumnName] ) == false) ||
                            (exStockNum.Equals( dataRow[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName] ) == false) )
                        {
                            rowDetailNo = 1;
                        }

                        dataRow[this._dataSet.StcDetail.StockRowNoColumn.ColumnName] = rowDetailNo++;

                        exStockDate = (DateTime)dataRow[this._dataSet.StcDetail.StockDateColumn.ColumnName];
                        exStockNum = (int)dataRow[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName];
                    }
                    # endregion

                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                    # region // DEL
                    //#region �c���Ɖ�f�[�^�e�[�u��

                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 DEL
                    ////if (this._dataSet.BalanceTotal.Rows.Count > 0)
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 DEL
                    //{
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 DEL
                    //    //// �c���\�����f�[�^�Z�b�g��
                    //    //row3 = this._dataSet.BalanceTotal.Rows[0];
                    //    //// �x���c��
                    //    //row3[_dataSet.BalanceTotal.PaymentRemainColumn.ColumnName] = StockTotalPayBalance + totalThisStockPrice + totalOfsThisSalesTax - totalThisTimePayNrml;
                    //    //// ����d��
                    //    //row3[_dataSet.BalanceTotal.ThisStockPriceTotalColumn.ColumnName] = totalThisStockPrice;
                    //    //// �����
                    //    //row3[_dataSet.BalanceTotal.OfsThisStockTaxColumn.ColumnName] = totalOfsThisSalesTax;
                    //    //// ����x��
                    //    //row3[_dataSet.BalanceTotal.ThisTimePayNrmlColumn.ColumnName] = totalThisTimePayNrml;
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 DEL
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 ADD
                    //    if (this._dataSet.BalanceTotal.Rows.Count > 0)
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
                    //        this._dataSet.BalanceTotal.Rows.Add(row3);
                    //    }
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 ADD

                    //    // �W�����i���v
                    //    row3[_dataSet.BalanceTotal.StandardPrice_TotalColumn.ColumnName] = StandardPrice_Total;
                    //    // ������z���v
                    //    row3[_dataSet.BalanceTotal.StockAmount_TotalColumn.ColumnName] = StockAmount_Total;

                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                    //    //if (totalAmount > 0)
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                    //    if ( totalAmount != 0 )
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                    //    {
                    //        // �W�����i����
                    //        row3[_dataSet.BalanceTotal.StandardPrice_AvgColumn.ColumnName] = StandardPrice_Total / totalAmount;
                    //        // ������z����
                    //        row3[_dataSet.BalanceTotal.StockAmount_AvgColumn.ColumnName] = StockAmount_Total / totalAmount;
                    //    }
                    //    else
                    //    {
                    //        // �W�����i����
                    //        row3[_dataSet.BalanceTotal.StandardPrice_AvgColumn.ColumnName] = 0;
                    //        // ������z����
                    //        row3[_dataSet.BalanceTotal.StockAmount_AvgColumn.ColumnName] = 0;
                    //    }

                    //    // �`�[����
                    //    row3[_dataSet.BalanceTotal.SlipCountColumn.ColumnName] = slipCount;
                    //    // ���א�
                    //    row3[_dataSet.BalanceTotal.DetailCountColumn.ColumnName] = detailSlipCount;
                    //    // ���ʌv
                    //    row3[_dataSet.BalanceTotal.AmountColumn.ColumnName] = totalAmount;
                    //    // ����Ōv
                    //    row3[_dataSet.BalanceTotal.ConsumeTaxAmountColumn.ColumnName] = totalConsumeTaxAmount;
                    //}
                    //#endregion // �c���Ɖ�f�[�^�e�[�u��
                    # endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 ADD
                else
                {
                    // �����[���Ȃ�΃����[�gstatus��0:����ł��Y���Ȃ��ŕԂ�
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                #region �c���Ɖ�f�[�^�e�[�u��

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 DEL
                //if (this._dataSet.BalanceTotal.Rows.Count > 0)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 DEL
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 DEL
                    //// �c���\�����f�[�^�Z�b�g��
                    //row3 = this._dataSet.BalanceTotal.Rows[0];
                    //// �x���c��
                    //row3[_dataSet.BalanceTotal.PaymentRemainColumn.ColumnName] = StockTotalPayBalance + totalThisStockPrice + totalOfsThisSalesTax - totalThisTimePayNrml;
                    //// ����d��
                    //row3[_dataSet.BalanceTotal.ThisStockPriceTotalColumn.ColumnName] = totalThisStockPrice;
                    //// �����
                    //row3[_dataSet.BalanceTotal.OfsThisStockTaxColumn.ColumnName] = totalOfsThisSalesTax;
                    //// ����x��
                    //row3[_dataSet.BalanceTotal.ThisTimePayNrmlColumn.ColumnName] = totalThisTimePayNrml;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 ADD
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
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 ADD

                    // �W�����i���v
                    row3[_dataSet.BalanceTotal.StandardPrice_TotalColumn.ColumnName] = StandardPrice_Total;
                    // ������z���v
                    //row3[_dataSet.BalanceTotal.StockAmount_TotalColumn.ColumnName] = StockAmount_Total;     //DEL �����H�@2012/04/05 Redmine#29310
                    row3[_dataSet.BalanceTotal.StockAmount_TotalColumn.ColumnName] = StockAmount_Total2;    //ADD �����H�@2012/04/05 Redmine#29310

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                    //if (totalAmount > 0)
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                    if ( totalAmount != 0 )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                    {
                        // �W�����i����
                        row3[_dataSet.BalanceTotal.StandardPrice_AvgColumn.ColumnName] = StandardPrice_Total / totalAmount;
                        // ������z����
                        //row3[_dataSet.BalanceTotal.StockAmount_AvgColumn.ColumnName] = StockAmount_Total / totalAmount;   //DEL �����H�@2012/04/05 Redmine#29310
                        row3[_dataSet.BalanceTotal.StockAmount_AvgColumn.ColumnName] = StockAmount_Total2 / totalAmount;    //ADD �����H�@2012/04/05 Redmine#29310 
                    }
                    else
                    {
                        // �W�����i����
                        row3[_dataSet.BalanceTotal.StandardPrice_AvgColumn.ColumnName] = 0;
                        // ������z����
                        row3[_dataSet.BalanceTotal.StockAmount_AvgColumn.ColumnName] = 0;
                    }

                    // �`�[����
                    row3[_dataSet.BalanceTotal.SlipCountColumn.ColumnName] = slipCount;
                    // ���א�
                    row3[_dataSet.BalanceTotal.DetailCountColumn.ColumnName] = detailSlipCount;
                    // ���ʌv
                    row3[_dataSet.BalanceTotal.AmountColumn.ColumnName] = totalAmount;
                    // ����Ōv
                    //row3[_dataSet.BalanceTotal.ConsumeTaxAmountColumn.ColumnName] = totalConsumeTaxAmount;    //DEL �����H�@2012/04/05 Redmine#29310
                    row3[_dataSet.BalanceTotal.ConsumeTaxAmountColumn.ColumnName] = totalConsumeTaxAmount2;   //ADD �����H�@2012/04/05 Redmine#29310
                }

                #endregion // �c���Ɖ�f�[�^�e�[�u��
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
            }

            return status;
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
        /// <summary>
        /// �x���萔���E�x���l���s�̒ǉ�(����)
        /// </summary>
        /// <param name="stcDetailDataTable"></param>
        /// <param name="rowDetailNo"></param>
        /// <param name="data"></param>
        /// <remarks>
        /// <br>Update Note: 2009/09/08 ���̕� �ߋ����\���Ή�</br>
        /// </remarks>
        private void AddFeeAndDepositRow( ref SuppPtrStcDetailDataSet.StcDetailDataTable table, ref int rowDetailNo, SuppPrtPprStcTblRsltWork data )
        {
            DataRow row;

            // �萔�����גǉ�
            if ( data.FeePayment > 0 )
            {
                rowDetailNo++;
                row = table.NewRow();

                # region [�x���萔��]
                row[_dataSet.StcDetail.DataDivColumn.ColumnName] = data.DataDiv;
                row[_dataSet.StcDetail.RowNoColumn.ColumnName] = rowDetailNo; // ���s�ԍ�
                row[_dataSet.StcDetail.StockDateColumn.ColumnName] = data.StockDate;
                row[_dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.StockRowNoColumn.ColumnName] = data.StockRowNo;
                row[_dataSet.StcDetail.SupplierFormalColumn.ColumnName] = data.SupplierFormal;
                row[_dataSet.StcDetail.SupplierSlipCdColumn.ColumnName] = data.SupplierSlipCd;
                row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_05;
                row[_dataSet.StcDetail.StockAgentNameColumn.ColumnName] = data.StockAgentName;
                row[_dataSet.StcDetail.GoodsNameColumn.ColumnName] = "�萔��"; // ���i��
                row[_dataSet.StcDetail.GoodsNoColumn.ColumnName] = string.Empty; //DBNull.Value;
                row[_dataSet.StcDetail.GoodsMakerCdColumn.ColumnName] = string.Empty; //DBNull.Value;
                row[_dataSet.StcDetail.MakerNameColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.BLGoodsCodeColumn.ColumnName] = string.Empty; //DBNull.Value;
                row[_dataSet.StcDetail.BLGroupCodeColumn.ColumnName] = string.Empty; //DBNull.Value;
                row[_dataSet.StcDetail.StockCountColumn.ColumnName] = DBNull.Value;
                row[_dataSet.StcDetail.OpenPriceDivColumn.ColumnName] = data.OpenPriceDiv;
                //row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = string.Empty; //DEL 2011/12/09
                row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = DBNull.Value; //ADD 2011/12/09
                row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = DBNull.Value;
                // ����ŗ�
                row[_dataSet.StcDetail.SupplierConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD ���V�� 2020/03/11 PMKOBETSU-2912 
                row[_dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName] = data.FeePayment; // �����z(����)
                row[_dataSet.StcDetail.SupplierSlipNote1Column.ColumnName] = data.SupplierSlipNote1;
                if ( data.SupplierSlipNote2.Equals( "0" ) )
                {
                    row[_dataSet.StcDetail.SupplierSlipNote2Column.ColumnName] = string.Empty;
                }
                else
                {
                    row[_dataSet.StcDetail.SupplierSlipNote2Column.ColumnName] = CT_SUPPLIERNOTE2_PRE + data.SupplierSlipNote2;
                }
                row[_dataSet.StcDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                row[_dataSet.StcDetail.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                // row[_dataSet.StcDetail.StockInputNameColumn.ColumnName] = data.StockInputName; // DEL 2009/09/08
                if ( data.SupplierCd == 0 )
                {
                    row[_dataSet.StcDetail.SupplierCdColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row[_dataSet.StcDetail.SupplierCdColumn.ColumnName] = data.SupplierCd;//data.SupplierCd.ToString().PadLeft( CT_DEPTH_SUPPLIERCODE, '0' );
                }
                row[_dataSet.StcDetail.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                row[_dataSet.StcDetail.StockOrderDivCdColumn.ColumnName] = DBNull.Value;
                row[_dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.WarehouseCdColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.WarehouseNameColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.UoeRemark1Column.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.UoeRemark2Column.ColumnName] = string.Empty;
                if ( data.SupplierSlipNo == 0 )
                {
                    row[_dataSet.StcDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row[_dataSet.StcDetail.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                }
                if ( data.StockAddUpADate == DateTime.MinValue )
                {
                    row[_dataSet.StcDetail.StockAddUpADateColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row[_dataSet.StcDetail.StockAddUpADateColumn.ColumnName] = data.StockAddUpADate;
                }
                row[_dataSet.StcDetail.AccPayDivCdColumn.ColumnName] = DBNull.Value;
                row[_dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName] = string.Empty;
                if ( data.DebitNoteDiv == 0 )
                {
                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_KURODEN;
                }
                else if ( data.DebitNoteDiv == 1 )
                {
                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_AKADEN;
                }
                else if ( data.DebitNoteDiv == 2 )
                {
                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_MOTOKURO;
                }
                else
                {
                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                }
                row[_dataSet.StcDetail.SalesSlipNumColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.SalesDateColumn.ColumnName] = DBNull.Value;
                row[_dataSet.StcDetail.CustomerCodeColumn.ColumnName] = DBNull.Value;
                row[_dataSet.StcDetail.CustomerSnmColumn.ColumnName] = string.Empty;
                # endregion

                table.Rows.Add( row );
            }

            if ( data.DiscountPayment > 0 )
            {
                rowDetailNo++;
                row = table.NewRow();

                # region [�x���l��]
                row[_dataSet.StcDetail.DataDivColumn.ColumnName] = data.DataDiv;
                row[_dataSet.StcDetail.RowNoColumn.ColumnName] = rowDetailNo; // ���s�ԍ�
                row[_dataSet.StcDetail.StockDateColumn.ColumnName] = data.StockDate;
                row[_dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.StockRowNoColumn.ColumnName] = data.StockRowNo;
                row[_dataSet.StcDetail.SupplierFormalColumn.ColumnName] = data.SupplierFormal;
                row[_dataSet.StcDetail.SupplierSlipCdColumn.ColumnName] = data.SupplierSlipCd;
                row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_05;
                row[_dataSet.StcDetail.StockAgentNameColumn.ColumnName] = data.StockAgentName;
                row[_dataSet.StcDetail.GoodsNameColumn.ColumnName] = "�l��"; // ���i��
                row[_dataSet.StcDetail.GoodsNoColumn.ColumnName] = string.Empty; //DBNull.Value;
                row[_dataSet.StcDetail.GoodsMakerCdColumn.ColumnName] = string.Empty; //DBNull.Value;
                row[_dataSet.StcDetail.MakerNameColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.BLGoodsCodeColumn.ColumnName] = string.Empty; //DBNull.Value;
                row[_dataSet.StcDetail.BLGroupCodeColumn.ColumnName] = string.Empty; //DBNull.Value;
                row[_dataSet.StcDetail.StockCountColumn.ColumnName] = DBNull.Value;
                row[_dataSet.StcDetail.OpenPriceDivColumn.ColumnName] = data.OpenPriceDiv;
                //row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = string.Empty; //DEL 2011/12/09
                row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = DBNull.Value; //ADD 2011/12/09
                row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = DBNull.Value;
                // ����ŗ�
                row[_dataSet.StcDetail.SupplierConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD ���V�� 2020/03/11 PMKOBETSU-2912 
                row[_dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName] = data.DiscountPayment; // �����z(����)
                row[_dataSet.StcDetail.SupplierSlipNote1Column.ColumnName] = data.SupplierSlipNote1;
                if ( data.SupplierSlipNote2.Equals( "0" ) )
                {
                    row[_dataSet.StcDetail.SupplierSlipNote2Column.ColumnName] = string.Empty;
                }
                else
                {
                    row[_dataSet.StcDetail.SupplierSlipNote2Column.ColumnName] = CT_SUPPLIERNOTE2_PRE + data.SupplierSlipNote2;
                }
                row[_dataSet.StcDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                row[_dataSet.StcDetail.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                // row[_dataSet.StcDetail.StockInputNameColumn.ColumnName] = data.StockInputName; // DEL 2009/09/08
                if ( data.SupplierCd == 0 )
                {
                    row[_dataSet.StcDetail.SupplierCdColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row[_dataSet.StcDetail.SupplierCdColumn.ColumnName] = data.SupplierCd;//data.SupplierCd.ToString().PadLeft( CT_DEPTH_SUPPLIERCODE, '0' );
                }
                row[_dataSet.StcDetail.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                row[_dataSet.StcDetail.StockOrderDivCdColumn.ColumnName] = DBNull.Value;
                row[_dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.WarehouseCdColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.WarehouseNameColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.UoeRemark1Column.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.UoeRemark2Column.ColumnName] = string.Empty;
                if ( data.SupplierSlipNo == 0 )
                {
                    row[_dataSet.StcDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row[_dataSet.StcDetail.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                }
                if ( data.StockAddUpADate == DateTime.MinValue )
                {
                    row[_dataSet.StcDetail.StockAddUpADateColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row[_dataSet.StcDetail.StockAddUpADateColumn.ColumnName] = data.StockAddUpADate;
                }
                row[_dataSet.StcDetail.AccPayDivCdColumn.ColumnName] = DBNull.Value;
                row[_dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName] = string.Empty;
                if ( data.DebitNoteDiv == 0 )
                {
                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_KURODEN;
                }
                else if ( data.DebitNoteDiv == 1 )
                {
                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_AKADEN;
                }
                else if ( data.DebitNoteDiv == 2 )
                {
                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_MOTOKURO;
                }
                else
                {
                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                }
                row[_dataSet.StcDetail.SalesSlipNumColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.SalesDateColumn.ColumnName] = DBNull.Value;
                row[_dataSet.StcDetail.CustomerCodeColumn.ColumnName] = DBNull.Value;
                row[_dataSet.StcDetail.CustomerSnmColumn.ColumnName] = string.Empty;
                # endregion

                table.Rows.Add( row );
            }
        }
        /// <summary>
        /// �`�[�O���b�h�ւ̃Z�b�g(�`�[�P��)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rowNo"></param>
        /// <param name="salAmntConsTaxInclu"></param>
        /// <param name="salesSlipNum"></param>
        /// <remarks>
        /// <br>Update Note : 2013/01/21 FSI�y�~ �їR��</br>
        /// <br>              [�d���ԕi�v��] �I���`�F�b�N�{�b�N�X�ݒ�ǉ�,�`�[�敪���ɕԕi�\��ǉ�</br>
        /// <br>Update Note : 2013/04/18 ���N</br>
        /// <br>�Ǘ��ԍ��@�@: 10801804-00 2013/05/15�z�M��</br>
        /// <br>            : Redmine#35363 �d����d�q�����̓`�[�\���ɔw�i�F�s��̑Ή�</br>
        /// <br>Update Note: 2020/03/11 ���V��</br>
        /// <br>�Ǘ��ԍ�   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912 �y���ŗ��Ή�</br>
        /// <br>           : �`�[�^�u�A���׃^�u�Ɂu����ŗ��v���ڂ�ǉ�</br>
        /// </remarks>
        private void RecordSetToSlipList( SuppPrtPprStcTblRsltWork data, int rowNo, long salAmntConsTaxInclu, string salesSlipNum )
        {
            // �`�[�ԍ�����ю󒍃X�^�[�^�X���قȂ�Εʓ`�[�Ƃ��Ď擾
            DataRow row2 = _dataSet.StcList.NewRow();
            DataRow retRow = _dataSet.RetGdsStcList.NewRow(); //ADD 2013/01/21 [�d���ԕi�v��]

            // �d���`�[�Ȃ̂��x���`�[�Ȃ̂��Ńf�[�^�̍\�����قȂ�
            if ( data.DataDiv == 0 )
            {
                #region �d���`�[
                //-----------
                // �d���`�[
                //-----------

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
                // �ԕi����p ���z����
                int slipSign = 1;

                // �ԕi����
                if ( data.SupplierSlipCd == 20 ) slipSign *= -1;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD

                row2[_dataSet.StcList.SelectionColumn.ColumnName] = false; // ADD 2013/01/21 [�d���ԕi�v��]
                // �sNo
                row2[_dataSet.StcList.RowNoColumn.ColumnName] = rowNo;
                // �f�[�^�敪
                row2[_dataSet.StcList.DataDivColumn.ColumnName] = data.DataDiv;
                // �`�[���t
                row2[_dataSet.StcList.StockDateColumn.ColumnName] = data.StockDate;
                // �`�[�ԍ�
                row2[_dataSet.StcList.PartySaleSlipNumColumn.ColumnName] = data.PartySaleSlipNum;
                // �d���`��
                row2[_dataSet.StcList.SupplierFormalColumn.ColumnName] = data.SupplierFormal;
                // �d���`�[�敪
                row2[_dataSet.StcList.SupplierSlipCdColumn.ColumnName] = data.SupplierSlipCd;

                // �d���`�[�ԍ�
                row2[_dataSet.StcList.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;

                // �d���`�[�敪������
                if ( data.SupplierFormal == 0 )   // �d��
                {
                    if ( data.SupplierSlipCd == 10 )
                    {
                        row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_01;
                    }
                    else if ( data.SupplierSlipCd == 20 )
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                        //row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_02;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                        row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_01 + CT_SUPPLIERSLIPCD_NAME_02; // �d���ԕi
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                    }
                }
                else if ( data.SupplierFormal == 1 )   // ��
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                    //row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_03;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                    if ( data.SupplierSlipCd == 10 )
                    {
                        row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_04; // ����
                    }
                    else if ( data.SupplierSlipCd == 20 )
                    {
                        row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_04 + CT_SUPPLIERSLIPCD_NAME_02; // ���וԕi
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                }
                else if ( data.SupplierFormal == 2 )   // �o��
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                    //row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_04;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                    row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_03; // ����
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                }
                // ----------ADD 2013/01/21 [�d���ԕi�v��]----------->>>>>
                else if (data.SupplierFormal == 3)   // �ԕi�\��
                {
                    if (data.SupplierSlipCd == 10)
                    {
                        row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_01; // �d��
                    }
                    else if (data.SupplierSlipCd == 20)
                    {
                        row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_02; // �ԕi
                    }
                }
                // ----------ADD 2013/01/21 [�d���ԕi�v��]-----------<<<<<
                else // �x��
                {
                    // [���x���`�[�͂����ɂ��Ȃ�]
                    //row[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_05;
                }

                // �S����
                row2[_dataSet.StcList.StockAgentNameColumn.ColumnName] = data.StockAgentName;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
                //// ���z
                //row2[_dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName] = data.StockTtlPricTaxExc;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                //// ����ł̗݌v���擾
                //consumeTaxTotal = data.StockPriceConsTax;

                //// ����œ]�ŋ敪�ɂ��\�����邩���Ȃ���

                //// [���z�\������]�̏ꍇ�͑S�ĕ\��(���גP�ʂƓ����Ȃ̂�)
                //if (data.SuppTtlAmntDspWayCd == 1) // *** ���z�\������ ***
                //{
                //    // [���z�\������]�̏ꍇ�͖��גP�ʈȊO�͐ݒ肳��Ȃ��B���׈ȊO���l������K�v�Ȃ�
                //    // �e�X�g���ɂ��A���׈ȊO��ݒ肵�Ă���f�[�^������ꍇ�́A�f�[�^���ԈႢ
                //    stckPrcConsTaxIncluAdjust = true;
                //}
                //else // *** ���z�\�����Ȃ� ***
                //{
                //    if (data.SuppCTaxLayCd == 0 || // �`�[�P��(0)
                //        data.SuppCTaxLayCd == 1)   // ���גP��(1)
                //    {
                //        // �\������
                //        stckPrcConsTaxIncluAdjust = true;
                //    }
                //    else // �����e(2)�E�����q(3)�E��ې�(9)
                //    {
                //        // ���ŋ��z������Γ��ŋ��z��\������
                //        if (data.StckPrcConsTaxInclu > 0)
                //        {
                //            stckPrcConsTaxIncluAdjust = true;
                //        }
                //        else
                //        {
                //            // ���ŋ��z���Ȃ���Δ�\��
                //            stckPrcConsTaxIncluAdjust = false;
                //        }
                //    }
                //}
                //// �����
                //row2[_dataSet.StcList.ConsumeTaxColumn.ColumnName] = data.StockTtlPricTaxInc - data.StockTtlPricTaxExc;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                # region [����Ŋ֘A]
                bool printTax = true;
                Int64 salesTotalTaxInc;
                Int64 salesTotalTaxExc = data.StockTtlPricTaxExc;
                Int64 salesPriceConsTax;

                //// ����������Ŋz�̎擾
                if ( data.SuppCTaxLayCd == 0 || data.SuppCTaxLayCd == 1 ) // �`�[�P��or���גP��
                {
                    salesPriceConsTax = data.StockTtlPricTaxInc - data.StockTtlPricTaxExc;
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
                    int totalAmountDispWayCd = data.SuppTtlAmntDspWayCd;

                    // ����ň󎚗L������
                    printTax = ReflectMoneyForTaxPrintOfSlip( ref salesTotalTaxExc, ref salesPriceConsTax, ref salAmntConsTaxInclu, ref salesTotalTaxInc, totalAmountDispWayCd, data.SuppCTaxLayCd);
                    if ( printTax )
                    {
                        if ( salesPriceConsTax != 0 )
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
                            //row2[_dataSet.StcList.ConsumeTaxColumn.ColumnName] = salesPriceConsTax;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
                            row2[_dataSet.StcList.ConsumeTaxColumn.ColumnName] = slipSign * salesPriceConsTax;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD
                            row2[_dataSet.StcList.SupplierConsTaxRateColumn.ColumnName] = data.SupplierConsTaxRate; // ADD ���V�� 2020/03/11 PMKOBETSU-2912

                        }
                        else
                        {
                            // �󎚂��Ȃ�
                            row2[_dataSet.StcList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                            row2[_dataSet.StcList.SupplierConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                        }
                    }
                    else
                    {
                        // �󎚂��Ȃ�
                        row2[_dataSet.StcList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                        row2[_dataSet.StcList.SupplierConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                    }
                }
                else
                {
                    // �󎚂��Ȃ�
                    row2[_dataSet.StcList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                    row2[_dataSet.StcList.SupplierConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
                //// �Ŕ����z�Z�b�g
                //row2[_dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName] = salesTotalTaxExc;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
                // �Ŕ����z�Z�b�g
                row2[_dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName] = slipSign * salesTotalTaxExc;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD

                // ���l�P
                row2[_dataSet.StcList.SupplierSlipNote1Column.ColumnName] = data.SupplierSlipNote1;
                // ���l�Q
                row2[_dataSet.StcList.SupplierSlipNote2Column.ColumnName] = data.SupplierSlipNote2;
                // ���_�R�[�h
                row2[_dataSet.StcList.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                // ���_��
                row2[_dataSet.StcList.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                // ���s��
                // row2[_dataSet.StcList.StockInputNameColumn.ColumnName] = data.StockInputName; // DEL 2009/09/08
                // �d����R�[�h[NULL�̂Ƃ��͋�]
                if ( data.SupplierCd == 0 )
                {
                    row2[_dataSet.StcList.SupplierCdColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row2[_dataSet.StcList.SupplierCdColumn.ColumnName] = data.SupplierCd;//.ToString().PadLeft(CT_DEPTH_SUPPLIERCODE, '0');
                }
                // �d���於
                row2[_dataSet.StcList.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                // UOE���}�[�N1
                row2[_dataSet.StcList.UoeRemark1Column.ColumnName] = data.UoeRemark1;
                // UOE���}�[�N2
                row2[_dataSet.StcList.UoeRemark2Column.ColumnName] = data.UoeRemark2;
                // �d��SEQ/�x����[NULL�̂Ƃ��͋�]
                if ( data.SupplierSlipNo == 0 )
                {
                    row2[_dataSet.StcList.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row2[_dataSet.StcList.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                }
                // �v���
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                //row2[_dataSet.StcList.StockAddUpADateColumn.ColumnName] = data.StockAddUpADate;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                if ( data.StockAddUpADate != DateTime.MinValue )
                {
                    row2[_dataSet.StcList.StockAddUpADateColumn.ColumnName] = data.StockAddUpADate;
                }
                else
                {
                    row2[_dataSet.StcList.StockAddUpADateColumn.ColumnName] = DBNull.Value;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                // ���|�敪
                row2[_dataSet.StcList.AccPayDivCdColumn.ColumnName] = data.AccPayDivCd;
                // ���|�敪��
                if ( data.AccPayDivCd == 1 )
                {
                    row2[_dataSet.StcList.AccPayDivCdNameColumn.ColumnName] = CT_ACCPAYDIV_NAME_01;
                }
                // �ԓ`�敪
                if ( data.DebitNoteDiv == 0 )
                {
                    row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_KURODEN;
                }
                else if ( data.DebitNoteDiv == 1 )
                {
                    row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_AKADEN;
                }
                else if ( data.DebitNoteDiv == 2 )
                {
                    row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_MOTOKURO;
                }
                else
                {
                    row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = string.Empty;
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                // ��������`�[�ԍ�(�`�[���ɂP�s�ł�����Αޔ����Ă���(�w�i�E�����F�ύX�̂���))
                //row2[_dataSet.StcList.SalesSlipNumColumn.ColumnName] = salesSlipNum; // DEL ���N 2013/04/18 Redmine#35363
                row2[_dataSet.StcList.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum; // ADD ���N 2013/04/18 Redmine#35363
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD

                // ----------ADD 2013/01/21----------->>>>>
                // �sNo
                retRow[_dataSet.RetGdsStcList.RowNoColumn.ColumnName] = rowNo;
                // �d���`�[�ԍ�
                retRow[_dataSet.RetGdsStcList.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;

                retRow[_dataSet.RetGdsStcList.LogicalDeleteCdColumn.ColumnName] = data.SlpLogicalDeleteCode;    // �_���폜�敪
                retRow[_dataSet.RetGdsStcList.SuppTtlAmntDspWayCdColumn.ColumnName] = data.SuppTtlAmntDspWayCd; // �d���摍�z�\�����@�敪
                retRow[_dataSet.RetGdsStcList.SuppCTaxLayCdColumn.ColumnName] = data.SuppCTaxLayCd;             // �d�������œ]�ŕ����R�[�h
                retRow[_dataSet.RetGdsStcList.SupplierConsTaxRateColumn.ColumnName] = data.SupplierConsTaxRate; // �d�������Őŗ�

                retRow[_dataSet.RetGdsStcList.StockSectionCdColumn.ColumnName] = data.StockSectionCd; // �d�����_�R�[�h
                retRow[_dataSet.RetGdsStcList.StockGoodsCdColumn.ColumnName] = data.StockGoodsCd; // �d�����i�敪
                retRow[_dataSet.RetGdsStcList.StockTtlPricTaxIncColumn.ColumnName] = data.StockPriceTaxInc; // �d�����z�v�i�ō��݁j
                retRow[_dataSet.RetGdsStcList.StockAddUpSectionCdColumn.ColumnName] = data.StockAddUpSectionCd; // �d���v�㋒�_�R�[�h
                retRow[_dataSet.RetGdsStcList.SubSectionCodeColumn.ColumnName] = data.SlpSubSectionCode; // ����R�[�h
                // �Ǝ�R�[�h
                retRow[_dataSet.RetGdsStcList.BusinessTypeCodeColumn.ColumnName] = data.BusinessTypeCode;
                // �Ǝ햼��
                retRow[_dataSet.RetGdsStcList.BusinessTypeNameColumn.ColumnName] = data.BusinessTypeName;
                // �̔��G���A�R�[�h
                retRow[_dataSet.RetGdsStcList.SalesAreaCodeColumn.ColumnName] = data.SalesAreaCode;
                // �̔��G���A����
                retRow[_dataSet.RetGdsStcList.SalesAreaNameColumn.ColumnName] = data.SalesAreaName;
                // ���z�\���|���K�p�敪
                retRow[_dataSet.RetGdsStcList.TtlAmntDispRateApyColumn.ColumnName] = data.TtlAmntDispRateApy;
                // �d���[�������敪
                retRow[_dataSet.RetGdsStcList.StockFractionProcCdColumn.ColumnName] = data.StockFractionProcCd;
                // �`�[�Z���敪
                retRow[_dataSet.RetGdsStcList.SlipAddressDivColumn.ColumnName] = data.SlipAddressDiv;
                // �[�i��R�[�h
                retRow[_dataSet.RetGdsStcList.AddresseeCodeColumn.ColumnName] = data.SlpAddresseeCode;
                // �[�i�於��
                retRow[_dataSet.RetGdsStcList.AddresseeNameColumn.ColumnName] = data.SlpAddresseeName;
                // �[�i�於��2
                retRow[_dataSet.RetGdsStcList.AddresseeName2Column.ColumnName] = data.AddresseeName2;
                // �[�i��X�֔ԍ�
                retRow[_dataSet.RetGdsStcList.AddresseePostNoColumn.ColumnName] = data.AddresseePostNo;
                // �[�i��Z��1_�s���{���s��S�E�����E��
                retRow[_dataSet.RetGdsStcList.AddresseeAddr1Column.ColumnName] = data.AddresseeAddr1;
                // �[�i��Z��3_�Ԓn
                retRow[_dataSet.RetGdsStcList.AddresseeAddr3Column.ColumnName] = data.AddresseeAddr3;
                // �[�i��Z��4_�A�p�[�g����
                retRow[_dataSet.RetGdsStcList.AddresseeAddr4Column.ColumnName] = data.AddresseeAddr4;
                // �[�i��d�b�ԍ�
                retRow[_dataSet.RetGdsStcList.AddresseeTelNoColumn.ColumnName] = data.AddresseeTelNo;
                // �[�i��FAX�ԍ�
                retRow[_dataSet.RetGdsStcList.AddresseeFaxNoColumn.ColumnName] = data.AddresseeFaxNo;
                // �����敪
                retRow[_dataSet.RetGdsStcList.DirectSendingCdColumn.ColumnName] = data.SlpDirectSendingCd;
                // ----------ADD 2013/01/21-----------<<<<<

                #endregion // �d���`�[
            }
            else
            {
                #region �x���`�[
                //----------
                // �x���`�[
                //----------

                //row2[_dataSet.StcList.SelectionColumn.ColumnName] = false;
                row2[_dataSet.StcList.SelectionColumn.ColumnName] = DBNull.Value;    // ADD 2013/01/21 [�d���ԕi�v��]
                // �sNo
                row2[_dataSet.StcList.RowNoColumn.ColumnName] = rowNo;
                // �f�[�^�敪
                row2[_dataSet.StcList.DataDivColumn.ColumnName] = data.DataDiv;
                // �`�[���t
                row2[_dataSet.StcList.StockDateColumn.ColumnName] = data.StockDate;
                // �`�[�ԍ�
                row2[_dataSet.StcList.PartySaleSlipNumColumn.ColumnName] = string.Empty;
                // �d���`��
                row2[_dataSet.StcList.SupplierFormalColumn.ColumnName] = data.SupplierFormal;
                // �d���`�[�敪
                row2[_dataSet.StcList.SupplierSlipCdColumn.ColumnName] = data.SupplierSlipCd;
                // �d���`�[�敪������
                row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_05;
                // �S����
                row2[_dataSet.StcList.StockAgentNameColumn.ColumnName] = data.StockAgentName;
                // ���z
                row2[_dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName] = data.StockTtlPricTaxExc;
                // �����
                row2[_dataSet.StcList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                // ����ŗ�
                row2[_dataSet.StcList.SupplierConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                // ���l�P
                row2[_dataSet.StcList.SupplierSlipNote1Column.ColumnName] = data.SupplierSlipNote1;
                // ���l�Q
                row2[_dataSet.StcList.SupplierSlipNote2Column.ColumnName] = string.Empty;
                // ���_
                // ���_�R�[�h
                row2[_dataSet.StcList.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                // ���_��
                row2[_dataSet.StcList.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                // ���s��
                // row2[_dataSet.StcList.StockInputNameColumn.ColumnName] = data.StockInputName; // DEL 2009/09/08
                // �d����R�[�h[NULL�̂Ƃ��͋�]
                if ( data.SupplierCd == 0 )
                {
                    row2[_dataSet.StcList.SupplierCdColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row2[_dataSet.StcList.SupplierCdColumn.ColumnName] = data.SupplierCd;//data.SupplierCd.ToString().PadLeft( CT_DEPTH_SUPPLIERCODE, '0' );
                }
                // �d���於
                row2[_dataSet.StcList.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                // UOE���}�[�N1
                row2[_dataSet.StcList.UoeRemark1Column.ColumnName] = string.Empty;
                // UOE���}�[�N2
                row2[_dataSet.StcList.UoeRemark2Column.ColumnName] = string.Empty;
                // �d��SEQ/�x����[NULL�̂Ƃ��͋�]
                if ( data.SupplierSlipNo == 0 )
                {
                    row2[_dataSet.StcList.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row2[_dataSet.StcList.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                }
                // �v���
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                //row2[_dataSet.StcList.StockAddUpADateColumn.ColumnName] = data.StockAddUpADate;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                if ( data.StockAddUpADate != DateTime.MinValue )
                {
                    row2[_dataSet.StcList.StockAddUpADateColumn.ColumnName] = data.StockAddUpADate;
                }
                else
                {
                    row2[_dataSet.StcList.StockAddUpADateColumn.ColumnName] = DBNull.Value;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                // ���|�敪
                row2[_dataSet.StcList.AccPayDivCdColumn.ColumnName] = data.AccPayDivCd;
                // ���|�敪��
                row2[_dataSet.StcList.AccPayDivCdNameColumn.ColumnName] = string.Empty;
                // �ԓ`�敪
                if ( data.DebitNoteDiv == 0 )
                {
                    row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_KURODEN;
                }
                else if ( data.DebitNoteDiv == 1 )
                {
                    row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_AKADEN;
                }
                else if ( data.DebitNoteDiv == 2 )
                {
                    row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_MOTOKURO;
                }
                else
                {
                    row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = string.Empty;
                }

                // ----------ADD 2013/01/21----------->>>>>
                // �sNo
                retRow[_dataSet.RetGdsStcList.RowNoColumn.ColumnName] = rowNo;
                // �d���`�[�ԍ�
                retRow[_dataSet.RetGdsStcList.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;

                retRow[_dataSet.RetGdsStcList.LogicalDeleteCdColumn.ColumnName] = data.SlpLogicalDeleteCode;    // �_���폜�敪
                retRow[_dataSet.RetGdsStcList.SuppTtlAmntDspWayCdColumn.ColumnName] = data.SuppTtlAmntDspWayCd; // �d���摍�z�\�����@�敪
                retRow[_dataSet.RetGdsStcList.SuppCTaxLayCdColumn.ColumnName] = data.SuppCTaxLayCd;             // �d�������œ]�ŕ����R�[�h
                retRow[_dataSet.RetGdsStcList.SupplierConsTaxRateColumn.ColumnName] = data.SupplierConsTaxRate; // �d�������Őŗ�

                retRow[_dataSet.RetGdsStcList.StockSectionCdColumn.ColumnName] = data.StockSectionCd; // �d�����_�R�[�h
                retRow[_dataSet.RetGdsStcList.StockGoodsCdColumn.ColumnName] = data.StockGoodsCd; // �d�����i�敪
                retRow[_dataSet.RetGdsStcList.StockTtlPricTaxIncColumn.ColumnName] = data.StockPriceTaxInc; // �d�����z�v�i�ō��݁j
                retRow[_dataSet.RetGdsStcList.StockAddUpSectionCdColumn.ColumnName] = data.StockAddUpSectionCd; // �d���v�㋒�_�R�[�h
                retRow[_dataSet.RetGdsStcList.SubSectionCodeColumn.ColumnName] = data.SlpSubSectionCode; // ����R�[�h
                // �Ǝ�R�[�h
                retRow[_dataSet.RetGdsStcList.BusinessTypeCodeColumn.ColumnName] = data.BusinessTypeCode;
                // �Ǝ햼��
                retRow[_dataSet.RetGdsStcList.BusinessTypeNameColumn.ColumnName] = data.BusinessTypeName;
                // �̔��G���A�R�[�h
                retRow[_dataSet.RetGdsStcList.SalesAreaCodeColumn.ColumnName] = data.SalesAreaCode;
                // �̔��G���A����
                retRow[_dataSet.RetGdsStcList.SalesAreaNameColumn.ColumnName] = data.SalesAreaName;
                // ���z�\���|���K�p�敪
                retRow[_dataSet.RetGdsStcList.TtlAmntDispRateApyColumn.ColumnName] = data.TtlAmntDispRateApy;
                // �d���[�������敪
                retRow[_dataSet.RetGdsStcList.StockFractionProcCdColumn.ColumnName] = data.StockFractionProcCd;
                // �`�[�Z���敪
                retRow[_dataSet.RetGdsStcList.SlipAddressDivColumn.ColumnName] = data.SlipAddressDiv;
                // �[�i��R�[�h
                retRow[_dataSet.RetGdsStcList.AddresseeCodeColumn.ColumnName] = data.SlpAddresseeCode;
                // �[�i�於��
                retRow[_dataSet.RetGdsStcList.AddresseeNameColumn.ColumnName] = data.SlpAddresseeName;
                // �[�i�於��2
                retRow[_dataSet.RetGdsStcList.AddresseeName2Column.ColumnName] = data.AddresseeName2;
                // �[�i��X�֔ԍ�
                retRow[_dataSet.RetGdsStcList.AddresseePostNoColumn.ColumnName] = data.AddresseePostNo;
                // �[�i��Z��1_�s���{���s��S�E�����E��
                retRow[_dataSet.RetGdsStcList.AddresseeAddr1Column.ColumnName] = data.AddresseeAddr1;
                // �[�i��Z��3_�Ԓn
                retRow[_dataSet.RetGdsStcList.AddresseeAddr3Column.ColumnName] = data.AddresseeAddr3;
                // �[�i��Z��4_�A�p�[�g����
                retRow[_dataSet.RetGdsStcList.AddresseeAddr4Column.ColumnName] = data.AddresseeAddr4;
                // �[�i��d�b�ԍ�
                retRow[_dataSet.RetGdsStcList.AddresseeTelNoColumn.ColumnName] = data.AddresseeTelNo;
                // �[�i��FAX�ԍ�
                retRow[_dataSet.RetGdsStcList.AddresseeFaxNoColumn.ColumnName] = data.AddresseeFaxNo;
                // �����敪
                retRow[_dataSet.RetGdsStcList.DirectSendingCdColumn.ColumnName] = data.SlpDirectSendingCd;
                // ----------ADD 2013/01/21-----------<<<<<

                #endregion // �x���`�[
            }

            // �s�ǉ�
            this._dataSet.StcList.Rows.Add( row2 );
            this._dataSet.RetGdsStcList.Rows.Add(retRow); //ADD 2013/01/21 [�d���ԕi�v��]
        }

        // ADD 2010/01/26 MANTIS�Ή�[14325]�F�C���X�g�[������Ɏd���`�[�~1�Ǝx���`�[�~1��o�^������ԂŌ�������ƁA�d���`�[���\������Ȃ� ---------->>>>>
        /// <summary>
        /// �d���`�[�敪�����擾���܂��B
        /// </summary>
        /// <remarks>
        /// RecordSetToSlipList()��胁�\�b�h�Ƃ��Đ؂�o��
        /// </remarks>
        /// <param name="data">�`�[���׃f�[�^</param>
        /// <returns>�d���`�[�敪��(�d���A�x���A�����Ȃ�)</returns>
        /// <exception cref="ArgumentNullException"><c>data</c>��<c>null</c>�ł��B</exception>
        private static string GetSupplierSlipCdName(SuppPrtPprStcTblRsltWork data)
        {
            if (data == null) throw new ArgumentNullException("data");

            if (data.SupplierFormal == 0)   // �d��
            {
                if (data.SupplierSlipCd == 10)
                {
                    return CT_SUPPLIERSLIPCD_NAME_01;   // �d��
                }
                else if (data.SupplierSlipCd == 20)
                {
                    return CT_SUPPLIERSLIPCD_NAME_01 + CT_SUPPLIERSLIPCD_NAME_02; // �d���ԕi
                }
            }
            else if (data.SupplierFormal == 1)   // ��
            {
                if (data.SupplierSlipCd == 10)
                {
                    return CT_SUPPLIERSLIPCD_NAME_04; // ����
                }
                else if (data.SupplierSlipCd == 20)
                {
                    return CT_SUPPLIERSLIPCD_NAME_04 + CT_SUPPLIERSLIPCD_NAME_02; // ���וԕi
                }
            }
            else if (data.SupplierFormal == 2)   // �o��
            {
                return CT_SUPPLIERSLIPCD_NAME_03; // ����
            }

            // �x��
            return CT_SUPPLIERSLIPCD_NAME_05;
        }
        // ADD 2010/01/26 MANTIS�Ή�[14325]�F�C���X�g�[������Ɏd���`�[�~1�Ǝx���`�[�~1��o�^������ԂŌ�������ƁA�d���`�[���\������Ȃ� ----------<<<<<

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
                �@�@// ----- ADD huangt 2013/05/15 Redmine#35640 ---------- <<<<<
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
                        if ( consTaxLayMethod == 9 )
                        {
                            printTax = false;
                            priceConsTax = 0;
                            moneyTaxInc = moneyTaxExc;
                        }
                        else
                        {
                            printTax = (priceConsTaxInclu != 0);
                            priceConsTax = priceConsTaxInclu;
                            moneyTaxInc = moneyTaxExc + priceConsTaxInclu;
                        }
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
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 ADD
        /// <summary>
        /// �c���Ɖ�o
        /// </summary>
        /// <param name="suppPrtPprBlDspRsltWorkObj"></param>
        /// <param name="remainData"></param>
        /// <param name="suppPrtPpr"></param>
        /// <remarks>�d���N�Ԏ��яƉ�̃����[�g���g�p���܂�</remarks>
        private int SearchBlDspRslt( ref object suppPrtPprBlDspRsltWorkObj,�@ref RemainDataExtra remainDataEx, SuppPrtPpr suppPrtPpr )
        {
            suppPrtPprBlDspRsltWorkObj = new ArrayList();
            SuplierPayWork paraWork = new SuplierPayWork();

            string resultSectCd = string.Empty;
            string addUpSecCode = string.Empty;
            int supplierCd = 0;
            int payeeCd = 0;

            # region [�����Z�b�g]

            paraWork.EnterpriseCode = suppPrtPpr.EnterpriseCode; // ��ƃR�[�h

            //-----------------------------------------------------------
            // ���_���͔���
            //-----------------------------------------------------------
            if ( suppPrtPpr.SectionCode == null || suppPrtPpr.SectionCode.Length == 0 )
            {
                // 00:�S�ЂȂ�Ε\�����Ȃ�
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            string sectionCode = suppPrtPpr.SectionCode[0].Trim();
            paraWork.AddUpSecCode = sectionCode; // ���_�R�[�h

            if ( sectionCode == "00" ||
                string.IsNullOrEmpty( sectionCode ) )
            {
                // 00:�S�ЂȂ�Ε\�����Ȃ�
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }


            //-----------------------------------------------------------
            // �d����E�x������͔���
            //-----------------------------------------------------------
            // --- ADD 2012/09/13 ---------->>>>>
            if (_opt_SupplierSummary == true)
            {
                if (suppPrtPpr.SupplierCd != 0)
                {
                    paraWork.SupplierCd = suppPrtPpr.SupplierCd; // �d����R�[�h���d����R�[�h
                }
                else
                {
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
            }
            else
            {
            // --- ADD 2012/09/13 ----------<<<<<
            if ( suppPrtPpr.SupplierCd != 0 )
            {
                // �d����ǂݍ���
                Supplier supplier;
                int readStatus = _supplierAcs.Read( out supplier, suppPrtPpr.EnterpriseCode, suppPrtPpr.SupplierCd );
                if ( readStatus != 0 || supplier == null || supplier.LogicalDeleteCode != 0 )
                {
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }

                if ( suppPrtPpr.PayeeCode != 0 )
                {
                    //----------------------------------------------
                    // �d����{�x����
                    //----------------------------------------------

                    // �e�q�֌W����
                    if ( supplier.PayeeCode == suppPrtPpr.PayeeCode && supplier.PaymentSectionCode.Trim() == sectionCode )
                    {
                        paraWork.SupplierCd = suppPrtPpr.PayeeCode; // �d����R�[�h���x����R�[�h
                        paraWork.PayeeCode = supplier.PayeeCode;
                        paraWork.ResultsSectCd = "00";
                        paraWork.AddUpSecCode = sectionCode;

                        supplierCd = 0;
                        payeeCd = supplier.PayeeCode;
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
                    // �d����̂�
                    //----------------------------------------------
                    paraWork.SupplierCd = supplier.SupplierCd; // �d����R�[�h���d����R�[�h
                    paraWork.PayeeCode = supplier.PayeeCode;
                    paraWork.ResultsSectCd = supplier.PaymentSectionCode;
                    paraWork.AddUpSecCode = sectionCode;

                    supplierCd = supplier.SupplierCd;
                    payeeCd = supplier.PayeeCode;
                    resultSectCd = supplier.PaymentSectionCode;
                    addUpSecCode = sectionCode;
                }
            }
            else
            {
                if ( suppPrtPpr.PayeeCode != 0 )
                {
                    //----------------------------------------------
                    // �x����̂�
                    //----------------------------------------------

                    // �x����ǂݍ���
                    Supplier supplier;
                    int readStatus = _supplierAcs.Read( out supplier, suppPrtPpr.EnterpriseCode, suppPrtPpr.PayeeCode );
                    if ( readStatus != 0 || supplier == null || supplier.LogicalDeleteCode != 0 )
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }

                    // �e�q����
                    if ( supplier.PayeeCode == supplier.SupplierCd && supplier.PaymentSectionCode.Trim() == sectionCode )
                    {
                        paraWork.SupplierCd = suppPrtPpr.PayeeCode; // �d����R�[�h���x����R�[�h
                        paraWork.PayeeCode = supplier.SupplierCd;
                        paraWork.ResultsSectCd = "00";
                        paraWork.AddUpSecCode = sectionCode;

                        supplierCd = 0;
                        payeeCd = supplier.SupplierCd;
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
            }


            // ��ʏI����
            paraWork.AddUpDate = suppPrtPpr.Ed_StockDate;

            # endregion

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            suppPrtPprBlDspRsltWorkObj = null;

            // --- ADD 2012/09/13 ---------->>>>>
            if (_opt_SupplierSummary != true)
            {
            # region [���ς݁F�d����x�����z�}�X�^]
            //-----------------------------------------------
            // ���ς݁F�d����x�����z�}�X�^
            //-----------------------------------------------
            object retObj;

            addUpSecCode = addUpSecCode.Trim();
            resultSectCd = resultSectCd.Trim();

            if ( payeeCd == supplierCd && addUpSecCode == resultSectCd )
            {
                supplierCd = 0;
                resultSectCd = "00";
            }

            status = _ISuppRsltUpdDB.SearchSuplierPay( paraWork.EnterpriseCode, addUpSecCode, payeeCd, resultSectCd, supplierCd, 0, out retObj );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retObj != null)
            {
                CustomSerializeArrayList retObjList = (CustomSerializeArrayList)retObj;
                if ( retObjList.Count > 0 )
                {
                    for ( int index = 0; index < retObjList.Count; index++ )
                    {
                        ArrayList list = (ArrayList)(retObjList[index] as ArrayList)[0];

                        foreach ( SuplierPayWork retWork in list as ArrayList )
                        {
                            if ( retWork.AddUpDate < suppPrtPpr.Ed_StockDate ) continue;
                            if ( retWork.StartCAddUpUpdDate > suppPrtPpr.Ed_StockDate ) continue;

                            SuppPrtPprBlDspRsltWork rsltWork = new SuppPrtPprBlDspRsltWork();
                            remainDataEx = new RemainDataExtra();

                            # region [���ʃZ�b�g]

                            rsltWork.AddUpYearMonth = retWork.AddUpYearMonth;// �����N��
                            rsltWork.SuppCTaxationCd = retWork.SuppCTaxLayCd;// �]�ŕ���

                            rsltWork.StockTtl2TmBfBlPay = retWork.StockTtl3TmBfBlPay; // �O�X�X��c
                            rsltWork.LastTimePayment = retWork.StockTtl2TmBfBlPay; // �O�X��c
                            rsltWork.StockTotalPayBalance = retWork.LastTimePayment; // �O��c

                            remainDataEx.ThisStockPriceTotal = retWork.OfsThisTimeStock; // ����d��
                            remainDataEx.OfsThisStockTax = retWork.OfsThisStockTax; // �����
                            remainDataEx.ThisTimePayNrml = retWork.ThisTimePayNrml; // ����x��

                            remainDataEx.PaymentRemain = retWork.StockTotalPayBalance; // �x���c��

                            remainDataEx.DmdStDay = retWork.StartCAddUpUpdDate; // ���J�n��
                            remainDataEx.TotalDay = retWork.AddUpDate; // ��������

                            remainDataEx.IsParent = (retWork.SupplierCd == retWork.PayeeCode || retWork.SupplierCd == 0); // �e�t���O

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
            }
            // --- ADD 2012/09/13 ----------<<<<<

            if ( suppPrtPprBlDspRsltWorkObj == null )
            {
                # region [�����F�d�������W�v�����[�g�Ăяo��]
                //-----------------------------------------------
                // �����F�d�������W�v�����[�g�Ăяo��
                //-----------------------------------------------
                bool isParent;
                // --- ADD 2012/09/13 ---------->>>>>
                if (_opt_SupplierSummary == true)
                {
                    isParent = true;
                }
                else
                // --- ADD 2012/09/13 ----------<<<<<
                {
                if ( (paraWork.SupplierCd == paraWork.PayeeCode && paraWork.ResultsSectCd.Trim() == paraWork.AddUpSecCode.Trim())||
                     (supplierCd == 0 && resultSectCd.Trim() == "00") )
                {
                    isParent = true;
                    paraWork.SupplierCd = paraWork.PayeeCode;
                    paraWork.ResultsSectCd = paraWork.AddUpSecCode;
                }
                else
                {
                    isParent = false;
                    paraWork.SupplierCd = paraWork.PayeeCode;
                    paraWork.ResultsSectCd = paraWork.AddUpSecCode;
                }

                }
                

                object paraObj = paraWork;
                object childObj = null;
                string message;
                // --- DEL 2012/09/13 ---------->>>>>
                //status = _iSuplierPayDB.ReadSuplierPay( ref paraObj, ref childObj, out message );
                // --- DEL 2012/09/13 ----------<<<<< 
                // --- ADD 2012/09/13 ---------->>>>>
                if (_opt_SupplierSummary == true)
                {
                    status = _iSuplierPayDB.ReadSuplierPayByAddUpSecCode(ref paraObj, out message);
                }
                else
                {
                status = _iSuplierPayDB.ReadSuplierPay( ref paraObj, ref childObj, out message );
                }
                // --- ADD 2012/09/13 ----------<<<<<

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    SuppPrtPprBlDspRsltWork rsltWork = new SuppPrtPprBlDspRsltWork();
                    remainDataEx = new RemainDataExtra();

                    SuplierPayWork retWork = null;
                    if ( isParent )
                    {
                        retWork = (SuplierPayWork)paraObj;
                    }
                    else
                    {
                        foreach ( SuplierPayWork childWork in (childObj as ArrayList) )
                        {
                            if ( childWork.SupplierCd == supplierCd && childWork.ResultsSectCd.Trim() == resultSectCd.Trim() )
                            {
                                retWork = childWork;
                                break;
                            }
                        }
                    }

                    if ( retWork != null )
                    {
                        # region [���ʃZ�b�g]

                        rsltWork.AddUpYearMonth = retWork.AddUpYearMonth;// �����N��
                        rsltWork.SuppCTaxationCd = retWork.SuppCTaxLayCd;// �]�ŕ���

                        //rsltWork.StockTotalPayBalance = retWork.ThisTimeTtlBlcPay; // �O��c��
                        rsltWork.StockTtl2TmBfBlPay = retWork.StockTtl3TmBfBlPay; // �O�X�X��c
                        rsltWork.LastTimePayment = retWork.StockTtl2TmBfBlPay; // �O�X��c
                        rsltWork.StockTotalPayBalance = retWork.LastTimePayment; // �O��c

                        remainDataEx.ThisStockPriceTotal = retWork.OfsThisTimeStock; // ����d��
                        remainDataEx.OfsThisStockTax = retWork.OfsThisStockTax; // �����
                        remainDataEx.ThisTimePayNrml = retWork.ThisTimePayNrml; // ����x��

                        remainDataEx.PaymentRemain = retWork.StockTotalPayBalance; // �x���c��

                        remainDataEx.DmdStDay = retWork.StartCAddUpUpdDate; // ���J�n��
                        remainDataEx.TotalDay = suppPrtPpr.Ed_StockDate; // ��������

                        remainDataEx.IsParent = isParent; // �e�t���O

                        # endregion

                        // �ԋp�f�[�^
                        ArrayList retList = new ArrayList();
                        retList.Add( rsltWork );
                        suppPrtPprBlDspRsltWorkObj = retList;
                    }
                }
                # endregion
            }

            // �Y���f�[�^�Ȃ�
            if ( suppPrtPprBlDspRsltWorkObj == null )
            {
                suppPrtPprBlDspRsltWorkObj = new ArrayList();
            }

            return status;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 ADD

        /// <summary>
        /// �c���ꗗ�擾
        /// </summary>
        /// <param name="suppPrtPprBlnce"></param>
        /// <param name="remainType">0: ���� 1: ���|</param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
        //public int SearchBalance(SuppPrtPprBlnce suppPrtPprBlnce, int remainType)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
        public int SearchBalance( ref SuppPrtPprBlnce suppPrtPprBlnce, int remainType )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
            SuppPrtPprBlnce suppPrtPprBlnceBackup = suppPrtPprBlnce.Clone();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD

            try
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 ADD
                // �c���ꗗ���N���A
                this._dataSet.BalanceList.Clear();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 ADD

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                //---------------------------------
                // ���̓`�F�b�N
                //---------------------------------
                # region [���̓`�F�b�N]
                //////-----------------------------------------------------------
                ////// ���_���͔���
                //////-----------------------------------------------------------
                ////if ( suppPrtPprBlnce.SectionCode == null || suppPrtPprBlnce.SectionCode.Length == 0 )
                ////{
                ////    // 00:�S�ЂȂ�Ε\�����Ȃ�
                ////    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                ////}

                ////string sectionCode = suppPrtPprBlnce.SectionCode[0].Trim();

                ////if ( sectionCode == "00" || string.IsNullOrEmpty( sectionCode ) )
                ////{
                ////    // 00:�S�ЂȂ�Ε\�����Ȃ�
                ////    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                ////}

                if ( suppPrtPprBlnce.SectionCode == null || suppPrtPprBlnce.SectionCode.Length == 0 )
                {
                    suppPrtPprBlnce.SectionCode = new string[] { "00" };
                }
                string sectionCode = suppPrtPprBlnce.SectionCode[0].Trim();

                //-----------------------------------------------------------
                // �d����E�x������͔���
                //-----------------------------------------------------------
                // --- ADD 2012/09/13 ---------->>>>>
                if (_opt_SupplierSummary == true)
                {
                    if (suppPrtPprBlnce.SupplierCd == 0 )
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }

                    suppPrtPprBlnce.PayeeCode = suppPrtPprBlnce.SupplierCd;
                    suppPrtPprBlnce.SupplierCd = 0;
                }
                else
                // --- ADD 2012/09/13 ----------<<<<<
                {
                if ( suppPrtPprBlnce.SupplierCd != 0 )
                {
                    // �d����ǂݍ���
                    Supplier supplier;
                    int readStatus = _supplierAcs.Read( out supplier, suppPrtPprBlnce.EnterpriseCode, suppPrtPprBlnce.SupplierCd );
                    if ( readStatus != 0 || supplier == null || supplier.LogicalDeleteCode != 0 )
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                    sectionCode = supplier.MngSectionCode.Trim();

                    if ( suppPrtPprBlnce.PayeeCode != 0 )
                    {
                        //----------------------------------------------
                        // �d����{�x����
                        //----------------------------------------------

                        // �e�q�֌W����
                        if ( supplier.PayeeCode == suppPrtPprBlnce.PayeeCode && supplier.PaymentSectionCode.Trim() == sectionCode )
                        {
                            suppPrtPprBlnce.SupplierCd = 0;
                            suppPrtPprBlnce.PayeeCode = supplier.PayeeCode;
                            suppPrtPprBlnce.SectionCode[0] = sectionCode;
                        }
                        else
                        {
                            return (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                    }
                    else
                    {
                        //----------------------------------------------
                        // �d����̂�
                        //----------------------------------------------
                        if ( supplier.SupplierCd == supplier.PayeeCode )
                        {
                            suppPrtPprBlnce.SupplierCd = 0;
                            suppPrtPprBlnce.PayeeCode = supplier.PayeeCode;
                            suppPrtPprBlnce.SectionCode[0] = sectionCode;
                        }
                        else
                        {
                            return (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                    }
                    // ���_�X�V
                    if ( UpdateSection != null )
                    {
                        UpdateSection( this, supplier.MngSectionCode, supplier.MngSectionName );
                    }
                }
                else
                {
                    if ( suppPrtPprBlnce.PayeeCode != 0 )
                    {
                        //----------------------------------------------
                        // �x����̂�
                        //----------------------------------------------

                        // �x����ǂݍ���
                        Supplier supplier;
                        int readStatus = _supplierAcs.Read( out supplier, suppPrtPprBlnce.EnterpriseCode, suppPrtPprBlnce.PayeeCode );
                        if ( readStatus != 0 || supplier == null || supplier.LogicalDeleteCode != 0 )
                        {
                            return (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                        sectionCode = supplier.MngSectionCode.Trim();

                        // �e�q����
                        if ( supplier.PayeeCode == supplier.SupplierCd && supplier.PaymentSectionCode.Trim() == sectionCode )
                        {
                            suppPrtPprBlnce.SupplierCd = 0;
                            suppPrtPprBlnce.PayeeCode = supplier.SupplierCd;
                            suppPrtPprBlnce.SectionCode[0] = sectionCode;
                        }
                        else
                        {
                            return (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                        // ���_�X�V
                        if ( UpdateSection != null )
                        {
                            UpdateSection( this, supplier.MngSectionCode, supplier.MngSectionName );
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
                }
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

                //---------------------------------
                // �p�����[�^�N���X���쐬
                //---------------------------------
                SuppPrtPprBlnceWork suppPrtPprBlnceWork = new SuppPrtPprBlnceWork();
                SuppPrtPprBlnce2SuppPrtPprBlnceWork( ref suppPrtPprBlnce, ref suppPrtPprBlnceWork );
                // --- ADD 2012/09/13 ---------->>>>>
                suppPrtPprBlnceWork.OptSupplierSummary = this._opt_SupplierSummary;
                // --- ADD 2012/09/13 ----------<<<<<
                //---------------------------------
                // �Ԃ�l�Ŏg�p����N���X���쐬
                //---------------------------------
                SuppPrtPprBlTblRsltWork suppPrtPprBlTblRsltWork = new SuppPrtPprBlTblRsltWork();
                object suppPrtPprBlTblRsltWorkObj = (object)suppPrtPprBlTblRsltWork;
                long counter = 0;
                int status;

                // readMode, logicalMode�͌��󖢎g�p
                status = this._iSuppPrtPprWorkDB.SearchBlTbl( ref suppPrtPprBlTblRsltWorkObj, suppPrtPprBlnceWork, remainType, 0, ConstantManagement.LogicalMode.GetData0 );
                int rowNo = 0;
                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // �擾�������ʂ��f�[�^�Z�b�g�ɃZ�b�g
                    foreach ( SuppPrtPprBlTblRsltWork data in (ArrayList)suppPrtPprBlTblRsltWorkObj )
                    {
                        try
                        {
                            DataRow row = this._dataSet.BalanceList.NewRow();

                            #region �c���ꗗ�f�[�^

                            row[this._dataSet.BalanceList.RowNoColumn.ColumnName] = rowNo; // �s��
                            row[this._dataSet.BalanceList.AddUpDateColumn.ColumnName] = data.AddUpDate; // �v���
                            row[this._dataSet.BalanceList.LastTimeBlcColumn.ColumnName] = data.LastTimeBlc; // �O��c��
                            row[this._dataSet.BalanceList.ThisTimePayNrmlColumn.ColumnName] = data.ThisTimePayNrml; // ����x���z
                            row[this._dataSet.BalanceList.ThisTimeTtlBlcColumn.ColumnName] = data.ThisTimeTtlBlc; // �J�z�c��
                            row[this._dataSet.BalanceList.ThisTimeStockPriceColumn.ColumnName] = data.ThisTimeStockPrice; // ����d��
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
                            //row[this._dataSet.BalanceList.ThisStckPricRgdsDisColumn.ColumnName] = data.ThisStckPricRgdsDis; // �ԕi�l��
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                            row[this._dataSet.BalanceList.ThisStckPricRgdsDisColumn.ColumnName] = -1 * data.ThisStckPricRgdsDis; // �ԕi�l��(ϲŽ����׽�\�L)
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
                            row[this._dataSet.BalanceList.OfsThisTimeStockColumn.ColumnName] = data.OfsThisTimeStock; // ���d���z
                            row[this._dataSet.BalanceList.OfsThisStockTaxColumn.ColumnName] = data.OfsThisStockTax; // �����
                            row[this._dataSet.BalanceList.ThisStckPricTotalColumn.ColumnName] = data.ThisStckPricTotal; // ���񍇌v
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                            row[this._dataSet.BalanceList.StckTtlPayBlcColumn.ColumnName] = data.StckTtlPayBlc; // ����c��
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
                            row[this._dataSet.BalanceList.StockSlipCountColumn.ColumnName] = data.StockSlipCount; // �`�[����

                            this._dataSet.BalanceList.Rows.Add( row );

                            #endregion // �c���ꗗ�f�[�^

                            rowNo++;

                        }
                        catch ( ConstraintException )
                        {

                        }
                    }
                }

                return status;
            }
            finally
            {
                suppPrtPprBlnce= suppPrtPprBlnceBackup;
            }
        }
        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        /// <summary>
        /// �c���ꗗ�擾
        /// </summary>
        /// <param name="suppPrtPprBlnce">��������</param>
        /// <param name="remainType">0: �x�� 1: ���|</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: �o�͎c���ꗗ�擾���܂��B</br>
        /// <br>Programmer	: chenyd</br>
        /// <br>Date		: 2010/07/20</br>
        /// <br>Update Note: 2010/09/14 tianjw</br>
        /// <br>           �@�e�L�X�g�o�͑Ή�</br>
        /// </remarks>
        public int SearchBalanceAll(ref SuppPrtPprBlnce suppPrtPprBlnce, int remainType)
        {
            SuppPrtPprBlnce suppPrtPprBlnceBackup = suppPrtPprBlnce.Clone();

            try
            {
                // �c���ꗗ���N���A
                this._dataSet.BalanceList.Clear();

                //---------------------------------
                // �p�����[�^�N���X���쐬
                //---------------------------------
                SuppPrtPprBlnceWork suppPrtPprBlnceWork = new SuppPrtPprBlnceWork();
                SuppPrtPprBlnce2SuppPrtPprBlnceWork(ref suppPrtPprBlnce, ref suppPrtPprBlnceWork);
                // --- ADD 2012/09/13 ---------->>>>>
                suppPrtPprBlnceWork.OptSupplierSummary = this._opt_SupplierSummary;
                // --- ADD 2012/09/13 ----------<<<<<

                //---------------------------------
                // �Ԃ�l�Ŏg�p����N���X���쐬
                //---------------------------------
                SuppPrtPprBlTblRsltWork suppPrtPprBlTblRsltWork = new SuppPrtPprBlTblRsltWork();

                object suppPrtPprBlTblRsltWorkObj = (object)suppPrtPprBlTblRsltWork;
                int status;

                // readMode, logicalMode�͌��󖢎g�p
                status = this._iSuppPrtPprWorkDB.SearchBlTbl(ref suppPrtPprBlTblRsltWorkObj, suppPrtPprBlnceWork, remainType, 0, ConstantManagement.LogicalMode.GetData0);
                int rowNo = 0;
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �擾�������ʂ��f�[�^�Z�b�g�ɃZ�b�g
                    foreach (SuppPrtPprBlTblRsltWork data in (ArrayList)suppPrtPprBlTblRsltWorkObj)
                    {
                        try
                        {
                            DataRow row = this._dataSet.BalanceList.NewRow();

                            #region �c���ꗗ�f�[�^

                            row[this._dataSet.BalanceList.RowNoColumn.ColumnName] = rowNo; // �s��
                            row[this._dataSet.BalanceList.SupplierNameColumn.ColumnName] = data.SupplierNm1; // �d���於
                            row[this._dataSet.BalanceList.SupplierCodeColumn.ColumnName] = data.SupplierCd;  // �d����R�[�h
                            //row[this._dataSet.BalanceList.SectionCodeColumn.ColumnName] = data.AddUpSecCode; // ���_�R�[�h // DEL 2010/09/14
                            row[this._dataSet.BalanceList.SectionCodeColumn.ColumnName] = data.AddUpSecCode.Trim(); // ���_�R�[�h // ADD 2010/09/14
                            row[this._dataSet.BalanceList.AddUpDateColumn.ColumnName] = data.AddUpDate; // �v���
                            row[this._dataSet.BalanceList.LastTimeBlcColumn.ColumnName] = data.LastTimeBlc; // �O��c��
                            row[this._dataSet.BalanceList.ThisTimePayNrmlColumn.ColumnName] = data.ThisTimePayNrml; // ����x���z
                            row[this._dataSet.BalanceList.ThisTimeTtlBlcColumn.ColumnName] = data.ThisTimeTtlBlc; // �J�z�c��
                            row[this._dataSet.BalanceList.ThisTimeStockPriceColumn.ColumnName] = data.ThisTimeStockPrice; // ����d��
                            row[this._dataSet.BalanceList.ThisStckPricRgdsDisColumn.ColumnName] = -1 * data.ThisStckPricRgdsDis; // �ԕi�l��(ϲŽ����׽�\�L)
                            row[this._dataSet.BalanceList.OfsThisTimeStockColumn.ColumnName] = data.OfsThisTimeStock; // ���d���z
                            row[this._dataSet.BalanceList.OfsThisStockTaxColumn.ColumnName] = data.OfsThisStockTax; // �����
                            row[this._dataSet.BalanceList.ThisStckPricTotalColumn.ColumnName] = data.ThisStckPricTotal; // ���񍇌v
                            row[this._dataSet.BalanceList.StckTtlPayBlcColumn.ColumnName] = data.StckTtlPayBlc; // ����c��
                            row[this._dataSet.BalanceList.StockSlipCountColumn.ColumnName] = data.StockSlipCount; // �`�[����

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

                return status;
            }
            finally
            {
                suppPrtPprBlnce = suppPrtPprBlnceBackup;
            }
        }
        // ---------------------- ADD 2010/07/20---------------------------------<<<<<

        /// <summary>
        /// �������ʂ���f�[�^�e�[�u�����쐬
        /// </summary>
        /// <param name="suppPrtPprStcTblRsltWork">�������ʃN���X</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2009/09/08 ���̕� �ߋ����\���Ή�</br>
        /// </remarks>
        private bool AddRowDataFromSearchResult(SuppPrtPprStcTblRsltWork suppPrtPprSalTblRsltWork)
        {
            // �`�[�E���׌������ʃN���X���f�[�^�Z�b�g���쐬

            DataRow newDetailRow = this._dataSet.StcDetail.NewRow();      // ����
            DataRow newSlipRow = this._dataSet.StcList.NewRow();          // �`�[
            

            //newDetailRow[

            return true;
        }

        /// <summary>
        /// �p�����[�^�N���X(PMKOU04002E.SuppPrtPpr)���烊���[�g�p�����[�^�N���X(PMKOU04016D.SuppPrtPprWork)�N���X�֕ϊ�
        /// </summary>
        /// <param name="suppPrtPpr"></param>
        /// <param name="suppPrtPprWork"></param>
        private void SuppPrtPpr2SuppPrtPprWork(ref SuppPrtPpr suppPrtPpr, ref SuppPrtPprWork suppPrtPprWork)
        {
            suppPrtPprWork.BLGoodsCode = suppPrtPpr.BLGoodsCode;
            suppPrtPprWork.BLGroupCode = suppPrtPpr.BLGroupCode;
            suppPrtPprWork.Ed_InputDay = suppPrtPpr.Ed_InputDay;
            suppPrtPprWork.Ed_StockDate = suppPrtPpr.Ed_StockDate;
            suppPrtPprWork.EnterpriseCode = suppPrtPpr.EnterpriseCode;
            suppPrtPprWork.GoodsMakerCd = suppPrtPpr.GoodsMakerCd;
            suppPrtPprWork.GoodsName = suppPrtPpr.GoodsName;
            suppPrtPprWork.GoodsNo = suppPrtPpr.GoodsNo;
            suppPrtPprWork.PartySaleSlipNum = suppPrtPpr.PartySaleSlipNum;
            suppPrtPprWork.PayeeCode = suppPrtPpr.PayeeCode;
            suppPrtPprWork.PaymentSlipNo = suppPrtPpr.PaymentSlipNo;
            suppPrtPprWork.SearchCnt = suppPrtPpr.SearchCnt;
            suppPrtPprWork.SearchType = suppPrtPpr.SearchType;
            suppPrtPprWork.SectionCode = suppPrtPpr.SectionCode;
            suppPrtPprWork.St_InputDay = suppPrtPpr.St_InputDay;
            suppPrtPprWork.St_StockDate = suppPrtPpr.St_StockDate;
            suppPrtPprWork.StockAgentCode = suppPrtPpr.StockAgentCode;
            // suppPrtPprWork.StockInputCode = suppPrtPpr.StockInputCode; // DEL 2009/09/08
            suppPrtPprWork.StockOrderDivCd = suppPrtPpr.StockOrderDivCd;
            suppPrtPprWork.SupplierCd = suppPrtPpr.SupplierCd;
            suppPrtPprWork.SupplierFormal = suppPrtPpr.SupplierFormal;
            suppPrtPprWork.SupplierSlipCd = suppPrtPpr.SupplierSlipCd;
            suppPrtPprWork.SupplierSlipNote1 = suppPrtPpr.SupplierSlipNote1;
            suppPrtPprWork.SupplierSlipNote2 = suppPrtPpr.SupplierSlipNote2;
            suppPrtPprWork.UoeRemark1 = suppPrtPpr.UoeRemark1;
            suppPrtPprWork.UoeRemark2 = suppPrtPpr.UoeRemark2;
            suppPrtPprWork.WarehouseCode = suppPrtPpr.WarehouseCode;
            suppPrtPprWork.WayToOrder = suppPrtPpr.WayToOrder;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
            suppPrtPprWork.StockSlipCdDtl = suppPrtPpr.StockSlipCdDtl;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD
        }

        /// <summary>
        /// �p�����[�^�N���X(PMKOU04002E.SuppPrtPprBlnce)���烊���[�g�p�����[�^�N���X(PMKOU04016D.CustPrtPprBlnceWork)�N���X�֕ϊ�
        /// </summary>
        /// <param name="suppPrtPpr"></param>
        /// <param name="suppPrtPprWork"></param>
        /// <br>Update Note : 2010/07/20 chenyd</br>
        /// <br>           �@�e�L�X�g�o�͑Ή�</br>
        private void SuppPrtPprBlnce2SuppPrtPprBlnceWork(ref SuppPrtPprBlnce suppPrtPprBlnce, ref SuppPrtPprBlnceWork suppPrtPprBlnceWork)
        {
            suppPrtPprBlnceWork.EnterpriseCode = suppPrtPprBlnce.EnterpriseCode;
            suppPrtPprBlnceWork.SectionCode = suppPrtPprBlnce.SectionCode;
            suppPrtPprBlnceWork.SupplierCd = suppPrtPprBlnce.SupplierCd;
            suppPrtPprBlnceWork.PayeeCode = suppPrtPprBlnce.PayeeCode;
            suppPrtPprBlnceWork.St_AddUpYearMonth = suppPrtPprBlnce.St_AddUpYearMonth;
            suppPrtPprBlnceWork.Ed_AddUpYearMonth = suppPrtPprBlnce.Ed_AddUpYearMonth;
            // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
            suppPrtPprBlnceWork.St_SupplierCd = suppPrtPprBlnce.St_SupplierCd;
            suppPrtPprBlnceWork.Ed_SupplierCd = suppPrtPprBlnce.Ed_SupplierCd;
            suppPrtPprBlnceWork.SearchDiv = suppPrtPprBlnce.SearchDiv;
            // ---------------------- ADD 2010/07/20 ---------------------------------<<<<<
        }

        // --- ADD 2012/09/13 ---------->>>>>
        /// <summary>
        /// �I�v�V�������L���b�V��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�v�V������񐧌䏈���B</br>
        /// <br>Programmer : FSI��k�c �G��</br>
        /// <br>Date       : 2010/09/13</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            #region ���d���摍���I�v�V����
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SuppSumFunc);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_SupplierSummary = true;
            }
            else
            {
                this._opt_SupplierSummary = false;
            }
            #endregion
        }
        // --- ADD 2012/09/13 ----------<<<<<

        # region [�c���\�����]
        /// <summary>
        /// �c���\�����
        /// </summary>
        public struct RemainDataExtra
        {
            /// <summary>����d��</summary>
            private Int64 _thisStockPriceTotal;
            /// <summary>�����</summary>
            private Int64 _ofsThisStockTax;
            /// <summary>����x��</summary>
            private Int64 _thisTimePayNrml;
            /// <summary>�x���c��</summary>
            private Int64 _paymentRemain;
            /// <summary>���J�n��</summary>
            private DateTime _dmdStDay;
            /// <summary>��������</summary>
            private DateTime _totalDay;
            /// <summary>�e�t���O</summary>
            private bool _isParent;
            /// <summary>
            /// ����d��
            /// </summary>
            public Int64 ThisStockPriceTotal
            {
                get { return _thisStockPriceTotal; }
                set { _thisStockPriceTotal = value; }
            }
            /// <summary>
            /// �����
            /// </summary>
            public Int64 OfsThisStockTax
            {
                get { return _ofsThisStockTax; }
                set { _ofsThisStockTax = value; }
            }
            /// <summary>
            /// ����x��
            /// </summary>
            public Int64 ThisTimePayNrml
            {
                get { return _thisTimePayNrml; }
                set { _thisTimePayNrml = value; }
            }
            /// <summary>
            /// �x���c��
            /// </summary>
            public Int64 PaymentRemain
            {
                get { return _paymentRemain; }
                set { _paymentRemain = value; }
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
