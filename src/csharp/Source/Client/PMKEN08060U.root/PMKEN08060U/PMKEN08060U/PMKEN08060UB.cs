using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Threading;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

using System.IO;   // ADD 杍^ 2014/09/01 FOR Redmine#43289
using Broadleaf.Application.Resources;  // ADD 杍^ 2014/09/01 FOR Redmine#43289
using Broadleaf.Application.Common;   // ADD 杍^ 2014/09/01 FOR Redmine#43289
using Broadleaf.Library.Globarization; // ADD 杍^ 2014/09/01 FOR Redmine#43289

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// �I���K�C�h
    /// </summary>
    /// <remarks>
    /// <br>�{�N���X��internal�Ő錾����Ă���ׁA�O���A�Z���u������͒��ڎQ�Ƃł��Ȃ��B</br>
    /// <br>�O���A�Z���u������{�N���X�ɃA�N�Z�X����ꍇ�́A����N���X�ɃC���^�[�t�F�[�X</br>
    /// <br>�ƂȂ郁�\�b�h��v���p�e�B���쐬���鎖</br>
    /// <br></br>
    /// <br>Update Note	: ���x�`���[�j���O�Ή��i�\���Ώۃf�[�^�̉��i�ꊇ�擾��ǉ��j</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2009.02.10</br>
    /// <br></br>
    /// <br>Update Note	: �D��q�ɂɃg�����������ă`�F�b�N����悤�ɏC��</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2009.02.16</br>
    /// <br></br>
    /// <br>Update Note	: NS���[�h�AEnetr�u����ʁv�Ŏ��̉�ʂɕ\������f�[�^�������ꍇ�ɕ��i���I������Ȃ��s��C��</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2009.02.18</br>
    /// <br></br>
    /// <br>Update Note	: �I�[�i�[�t�H�[���Ή��A��ւ����镔�i��I���������ɐV�i�Ԃɑ��������f�����悤�ɏC��</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2009.02.19</br>
    /// <br></br>
    /// <br>Update Note	: �D�ǐݒ�Őݒ肵���\�����ʏ��ŕ\�������悤�C��</br>
    /// <br>Programmer	: 22018�@��� ���b</br>
    /// <br>Date		: 2009.03.18</br>
    /// <br></br>
    /// <br>Update Note	: �݌ɕ\�����ŗD��q�ɂ���ɕ\�������悤�ύX</br>
    /// <br>            : �݌ɂ̑I����@���`�F�b�N�����ɕύX�i���`�F�b�N�Ŏ���I���\�ɕύX�j</br>
    /// <br>Programmer	: 22018�@��� ���b</br>
    /// <br>Date		: 2009.03.27</br>
    /// <br></br>
    /// <br>Update Note	: BL�R�[�h�}�ԑΉ�</br>
    /// <br>Programmer	: 20056 ���n ���</br>
    /// <br>Date		: 2009.06.08</br>
    /// <br></br>
    /// <br>Update Note	: �\�[�g����ύX�B��{��PM7�ɍ��킹�邪�񋟃f�[�^�̃��C�A�E�g��A</br>
    /// <br>            : ��߼�ݺ���(PM7�ɗL��������)�̑���ɵ�߼�ݖ��̂��g�p�B</br>
    /// <br>Programmer	: 22018�@��� ���b</br>
    /// <br>Date		: 2009.07.23</br>
    /// <br></br>
    /// <br>Update Note	: ������ցu���Ȃ��v�ꍇ�ɁA�\�����i��1���̏ꍇ�ɃJ�^���O�i�Ԃ̌�����񂪕\������Ȃ��s��̏C��</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2009/09/29</br>
    /// <br></br>
    /// <br>Update Note	: �@������ցu���Ȃ��v�ꍇ�ɁA�ŐV�i�Ԃ̏�񂪑��݂��Ȃ��Ɨ�����s��̏C��</br>
    /// <br>            : �A������ցu���Ȃ��v�ꍇ�ɁA�������i�Ԃ��Z�b�g����Ȃ��s��̏C��</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2009/11/27</br>
    /// <br></br>
    /// <br>Update Note	: �@���i�I���E�B���h�E�����i�P���i�̂݁j�̏ꍇ�ɁA�������A�Z�b�g�e�i�Ԃ�I�������ꍇ�ɍ݌ɏ�񂪔��f����Ȃ����ۂ̏C��(MANTIS[0014650]</br>
    /// <br>              �A�I��i�Ԃ́A�I�𕔕i���ɃZ�b�g����悤�ɏC��</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2009/12/14</br>
    /// <br></br>
    /// <br>Update Note : ���i�I���E�B���h�E�ɕ\������镔�i���X�g���擾�ł��郁�\�b�h��ǉ�(���i�I��UI�p)</br>
    /// <br>Programmer  : 21024�@���X�� ��</br>
    /// <br>Date        : 2010/03/15</br>    
    /// <br></br>
    /// <br>Update Note  : �񋟑�փ}�X�^��QTY���[���̏ꍇ�A��֐��QTY�ɑ�֌���QTY���\������Ȃ��ꍇ�����錏�̏C��(MANTIS[0014913])</br>
    /// <br>Programmer   : 22018  ��� ���b</br>
    /// <br>Date         : 2010/03/16</br>
    /// <br></br>
    /// <br>Update Note  : �������ɂ��i�荞�݂Őݒ�Ȃ��̃f�[�^���\���ΏۂƂȂ�Ȃ����̏C��(MANTIS[0014913])</br>
    /// <br>Programmer   : 20056 ���n ���</br>
    /// <br>Date         : 2010/03/29</br>
    /// <br></br>
    /// <br>Update Note : ���R�����I�v�V���� �w�b�_���Ɍ�������BL�R�[�h��\������悤�C��</br>
    /// <br>Programmer  : 22018�@��ؐ��b</br>
    /// <br>Date        : 2010/06/10</br>
    /// <br></br>
    /// <br>Update Note : ���ʕ�����</br>
    /// <br>                ���R���� 2010/06/10 �̑g��</br>
    /// <br>Programmer  : 22018�@��ؐ��b</br>
    /// <br>Date        : 2010/06/10</br>
    /// <br></br>
    /// <br>Update Note : ���ʕ�����</br>
    /// <br>                �T������ 2010/03/16 �̑g��</br>
    /// <br>                �T������ 2010/03/29 �̑g��</br>
    /// <br>                ����`�[���͍������Ή� Delphi����`�[���͂���Ăяo���ƃG���[�ɂȂ錏�̑Ή�</br>
    /// <br>                                      this.ToolbarsManager.DockWithinContainer = SelectionForm_Fill_Panel</br>
    /// <br>Programmer  : 22018�@��ؐ��b</br>
    /// <br>Date        : 2010/06/21</br>
    /// <br></br>
    /// <br>Update Note  : ���i�I���E�B���h�E�����i�P���i�̂݁j�̏ꍇ�ŁA�������̑�֌����݌ɂȂ��E��֐悪�݌ɂ���̂Ƃ��A</br>
    /// <br>             : �������݌ɏ�񂪑I����ԂɂȂ�Ȃ����ۂ̏C��(MANTIS[0015647])</br>
    /// <br>Programmer   : 22018  ��� ���b</br>
    /// <br>Date         : 2010/06/24</br>
    /// <br></br>
    /// <br>Update Note  : ���ʕ�����</br>
    /// <br>             : �@MANTIS[0015647] 2010/06/24 �̑g��</br>
    /// <br>Programmer   : 22018  ��� ���b</br>
    /// <br>Date         : 2010/06/24</br>
    /// <br></br>
    /// <br>Update Note  : ��Q���ǑΉ�(�W����)</br>
    /// <br>             :   �E���i�I���ł̕s���ȉ�ʑJ�ڂ̏C���B</br>
    /// <br>Programmer   : 22018  ��� ���b</br>
    /// <br>Date         : 2010/10/01</br>
    /// <br></br>
    /// <br>Update Note  : ��Q���ǑΉ�(�W����) (�����������ԕ��i �Ή�)</br>
    /// <br>             :   �t�H�[�J�X�ʒu���s���ɂȂ�����A������ɂ����Ȃ�̂�h���B</br>
    /// <br>             : �@�EgridCondition.TabStop = false �ɕύX</br>
    /// <br>             :   �EtxtBLCode.Enabled = false �ɕύX (BackColorDisabled=White,ForeColorDisabled=WindowText)</br>
    /// <br>             :   �EtxtPartName.Enabled = false �ɕύX (BackColorDisabled=White,ForeColorDisabled=WindowText)</br>
    /// <br>             : �@�E�������O���b�h�ɐi�������狭���I�ɕ��i�O���b�h�Ɉړ�������B</br>
    /// <br>             :   �E�[�����̏ꍇ�́A�݌ɁE�J���[�E�g�����E�����̊e�O���b�h�Ɉړ����Ȃ��B(��,���i�O���b�h�ֈړ�)</br>
    /// <br>Programmer   : 22018  ��� ���b</br>
    /// <br>Date         : 2010/10/26</br>
    /// <br></br>
    /// <br>Update Note  : �������i���P�̏ꍇ�ɁA�D��q�ɏ��ɍ݌ɂ���������Ȃ��s��̏C��(MANTIS[0016779])</br>
    /// <br>Programmer   : 21024  ���X�� ��</br>
    /// <br>Date         : 2010/12/20</br>
    /// <br></br>
    /// <br>Update Note  : ��Q���ǑΉ�(��������)</br>
    /// <br>             :   �E��֐�����o�l�V�����̓���ɏC���B</br>
    /// <br>                   �i��֌��̍݌ɂ�����΁A��ւ��Ȃ��B(�A�����[�U�[��ւƒ񋟑�ւŔ�����@���Ⴄ)�j</br>
    /// <br>Programmer   : 22018  ��� ���b</br>
    /// <br>Date         : 2011/02/01</br>
    /// <br></br>
    /// <br>Update Note  : ��Q���ǑΉ�(��������)</br>
    /// <br>             :   �E2011/02/01���̏C���B�݌ɗL������͗D��q�ɂ̂ݑΏۂƂ���B(PM7����)</br>
    /// <br>Programmer   : 22018  ��� ���b</br>
    /// <br>Date         : 2011/02/09</br>
    /// <br></br>
    /// <br>Update Note  : ��Q���ǑΉ�(��������)</br>
    /// <br>             :   �E2011/02/01���̏C���B�W�����i�擾�̏������C���B</br>
    /// <br>Programmer   : 22018  ��� ���b</br>
    /// <br>Date         : 2011/02/14</br>
    /// <br></br>
    /// <br>Update Note  : ��Q���ǑΉ�(��������)</br>
    /// <br>             :   �E2011/02/09���̏C���B�D��q�ɖ��ݒ�̏ꍇ�̏������C��(�ُ�I�������Ȃ�)</br>
    /// <br>Programmer   : 22018  ��� ���b</br>
    /// <br>Date         : 2011/02/18</br>
    /// <br></br>
    /// <br>Update Note  : ��Q���ǑΉ�(2011�N03��)</br>
    /// <br>             :   �E�����������̏������t���Ă��镔�i���܂ތ����ŁA������񂪐ݒ肳��Ă��Ȃ����i���ΏۊO�ɂȂ錏�̏C��</br>
    /// <br>Programmer   : 22018  ��� ���b</br>
    /// <br>Date         : 2011/03/03</br>
    /// <br></br>
    /// <br>Update Note  : SCM�Ή�</br>
    /// <br>             :   �E�����񓚎��A���i���ꌏ�ł��񓚂ł��Ȃ����̏C��</br>
    /// <br>Programmer   : 21024  ���X�� ��</br>
    /// <br>Date         : 2011/03/08</br>
    /// <br></br>
    /// <br>Update Note  : SCM�Ή�</br>
    /// <br>             :  �E�����񓚎��A�݌ɂ̈������J�^���O�i�ԂɂȂ錏�̏C��</br>
    /// <br>Programmer   : 21024  ���X�� ��</br>
    /// <br>Date         : 2011/03/15</br>
    /// <br></br>
    /// <br>Update Note  : ��Q���ǑΉ�(2011�N03��)</br>
    /// <br>             :   �E(2011/03/03�Ɋ֘A���ďC��)�^���S�I�����ɑ����ɂ��i�荞�݂�����ɍs���Ȃ��ׁA�C���B</br>
    /// <br>Programmer   : 22018  ��� ���b</br>
    /// <br>Date         : 2011/03/16</br>
    /// <br>Update Note  : 2011/07/25�@杍^�@�A��No.702�̑Ή�</br>
    /// <br>               ��ւ���i�݌ɖ��j�̏ꍇ�A�݌ɐ����P�ł̏����ɂ��ė~�����B�i�ԓ��͂̏ꍇ���A�݌ɏ������Q�Ƃ��ė~����</br>
    /// <br>Update Note  : PCCUOE�Ή�</br>
    /// <br>             :   �E����Index�w��ɂ��I�����\�Ƃ���</br>
    /// <br>Programmer   : 20056 ���n ���</br>
    /// <br>Date         : 2011/09/04</br>
    /// <br></br>
    /// <br>Update Note  : 2011/11/29�@yangmj�@redmine#7759 �̑Ή�</br>
    /// <br>               �����I�����\������Ȃ��̏C��</br>
    /// <br></br>
    /// <br>Update Note  : PMSF�A�g</br>
    /// <br>             :   �E������ւ���̏ꍇ�A�����񓚂Ő���ɕ��i�����񓚂ł��Ȃ����̑Ή�</br>
    /// <br>Programmer   : 20056 ���n ���</br>
    /// <br>Date         : 2012/02/09</br>
    /// <br></br>
    /// <br>Update Note	 : �i�������̃J���[���w�肵���ꍇ�A�F�������i�����o�����悤�ɏC���i�g���������l�j</br>
    /// <br>Programmer	 : 30810�@�{�{ ����</br>
    /// <br>Date		 : 2012/11/27</br>
    /// <br></br>
    /// <br>Update Note  : SCM��Q���ǈꗗ��253�Ή�</br>
    /// <br>             :   �ESF����J���[���t����F/�o���p�[�𔭒����Ă������񓚂���Ȃ����̑Ή�</br>
    /// <br>Programmer   : ���� ��</br>
    /// <br>Date         : 2012/09/14</br>
    /// <br></br>
    /// <br>Update Note  : 10900269-00 SPK�ԑ�ԍ�������Ή�</br>
    /// <br>                 ���i�i���敪�ƍ��Y/�O�ԋ敪�ɉ�����VIN�R�[�h��\������Ή�</br>
    /// <br>Programmer   : FSI�֓� �a�G</br>
    /// <br>Date         : 2013/03/25</br>
    /// <br>Update Note: 2014/09/01 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11070184-00�@SCM��Q�Ή� ��190�@RedMine#43289</br>
    /// <br>         �@: SF����⍇���̎��q���E���l�𔄏�`�[���͂ɕ\������</br>
    /// <br>Update Note: 2014/09/22 ���� ��Y</br>
    /// <br>�Ǘ��ԍ�   : 11070184-00�@SCM�d�|�ꗗNo.10598</br>
    /// <br>         �@: ������ԑ�ԍ��ł̔����E�⍇���Ή�</br>
    /// <br>Update Note: 2014/11/04 �{�{ ����</br>
    /// <br>�Ǘ��ԍ�   : 11070221-00�@�d�|�ꗗ ��2577</br>
    /// <br>         �@: �ԗ�����\���ؑ֎��̖��׃O���b�h�̍��������������C��</br>
    /// <br>Update Note: 2019/01/08 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11470076-00</br>
    /// <br>         �@: �V�����̑Ή�</br>
    /// </remarks>
    public partial class SelectionParts : Form
    {
        # region DataSet�X�L�[�}���
        /// <summary>�f�[�^�Z�b�g</summary>
        private PMKEN01010E _orgCar = null;
        private PartsInfoDataSet _orgDataSet = null;
        private PartsInfoDataSet.OfrColorInfoDataTable _colorTable;
        private PartsInfoDataSet.OfrTrimInfoDataTable _trimTable;
        private PartsInfoDataSet.OfrEquipInfoDataTable _equipTable;

        private dsPartsSel _dsParts = null;
        private dsPartsSel.PartsInfoDataTable _partsInfo = null;
        /// <summary>���i�I��UI�p�f�[�^</summary>
        public dsPartsSel.PartsInfoDataTable PartsInfo
        {
            get { return _partsInfo; }
        }
        private dsPartsSel.StockDataTable _StockTable = null;
        private dsPartsSel.ModelPartsDetailDataTable _modelPartsDetail = null;
        private int _selectIndex = -1; // 2011/09/04
        /// <summary>
        /// PM.NS������^�ȑO�J���ꂽ�I��UI���������ɂȂ�s 
        /// ��j2�s�ڂɑ΂��Č����I��UI���J���Ė߂��ė�������2�s�ڂƂȂ�B
        /// </summary>
        private PartsInfoDataSet.UsrGoodsInfoRow _prevRow = null;
        //private PartsInfoDataSet.UsrGoodsInfoRow _orgRow = null;

        # endregion

        # region private member �e��萔(���b�Z�[�W�Ȃ�)
        private string rowNoInput = string.Empty;

        private List<string> colToShow;

        private bool IsColorData = false;
        private bool IsTrimData = false;
        private bool IsEquipData = false;
        private bool isSelectChangeDisabled = false;
        private bool eraNameDispDiv;    // false:����  true:�a��
        private bool uiControlFlg;      // false:PM7�X�^�C��   true:PM.NS�X�^�C��
        private int substFlg;          // 0:��ւ��Ȃ�  1:��ւ���i�݌ɔ��肠��j 2:��ւ���i�݌ɔ���Ȃ��j
        private int userSubstFlg;
        private int enterFlg;           // 0:PM7, 1:�I�� 2:����ʁi�����ˌ����A�����˃Z�b�g�A�Z�b�g�ˊm��j
        private int totalAmountDispWay;       // ���z�\�����@�敪 0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j

        private int catalogMakerCd;

        private DateTimeFormatInfo dtfi;
        private int PartsNarrowing = 0;
        private string originalRowFilter = string.Empty;
        private bool isUserClose = true;
        private int _mode; // 0:�ʏ�@1:�������ϐ�p

        private FrmPartsInfo frmPartsInfo = null;
        private FrmJoinPartsInfo frmJoinInfo = null;

        private UltraGridCell processedCell = null;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusPanel panel;

        private int currentCell;
        private readonly int conditionCellCount = 15;
        private Dictionary<RowFilterKind, string> rowFilterList = new Dictionary<RowFilterKind, string>(18);
        private Dictionary<string, RowFilterKind> lstEnum = new Dictionary<string, RowFilterKind>(18);
        private SelectionInfo _prevSelInfo;
        private bool isDialogShown = true;

        // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- >>>
        private string _pgid = string.Empty;
        /// <summary>�ԗ�����\���pXML�t�@�C�����i���`��ʁj</summary>
        private const string MAHNB01001U_PMKEN08060U_CARINFOSELETED = "MAHNB01001U_PMKEN08060U_CarInfoSeleted.XML";
        /// <summary>�ԗ�����\���pXML�t�@�C�����i���ω�ʁj</summary>
        private const string PMMIT01010U_PMKEN08060U_CARINFOSELETED = "PMMIT01010U_PMKEN08060U_CarInfoSeleted.XML";
        /// <summary>���`���PGID</summary>
        private const string MAHNB01001U_PGID = "MAHNB01001U";
        /// <summary>���ω��PGID</summary>
        private const string PMMIT01010U_PGID = "PMMIT01010U";
        /// <summary>�ԗ����\���pSOLT</summary>
        private const string CARINFOSOLT = "CARINFOSOLT";
        private LocalDataStoreSlot carInfoSolt = null;
        // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- <<<

        /// <summary> �_�C�A���O���\���ۃt���O�i�f�[�^���ɂ�莩������j </summary>
        public bool IsDialogShown
        {
            get { return isDialogShown; }
        }
        # endregion

        #region [ Constructor ]
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SelectionParts()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �I����ʃR���X�g���N�^
        /// </summary>
        /// <param name="dsCar">�^�����̃f�[�^�Z�b�g</param>
        /// <param name="dsParts">�O���b�h�ɕ\������f�[�^���w�肵�܂��B</param>
        public SelectionParts(PMKEN01010E dsCar, PartsInfoDataSet dsParts)
        {
            InitialMain(dsCar, dsParts);
        }

        /// <summary>
        /// �I����ʃR���X�g���N�^
        /// </summary>
        /// <param name="dsCar">�^�����̃f�[�^�Z�b�g</param>
        /// <param name="dsParts">�O���b�h�ɕ\������f�[�^���w�肵�܂��B</param>
        /// <param name="mode">0:�ʏ�@1:�������ϐ�p 2:SCM�����񓚗p</param>
        public SelectionParts(PMKEN01010E dsCar, PartsInfoDataSet dsParts, int mode)
        {
            _mode = mode;
            // 2010/03/15 >>>
            //InitialMain(dsCar, dsParts);
            switch (mode)
            {
                case 0:
                case 1:
                    InitialMain(dsCar, dsParts);
                    break;
                case 2:
                    InitialMain2(dsCar, dsParts);
                    break;
            }
            // 2010/03/15 <<<
        }
        // 2010/03/15 Add >>>
        // 2010/03/15 Add <<<
        #endregion

        #region [ �������� ]
        /// <summary>
        /// �R���X�g���N�^�ł̏������������C��
        /// </summary>
        /// <param name="dsCar"></param>
        /// <param name="dsParts"></param>
        private void InitialMain(PMKEN01010E dsCar, PartsInfoDataSet dsParts)
        {
            _orgCar = dsCar;
            _orgDataSet = dsParts;
            SearchCntSetWork cond = dsParts.SearchCondition.SearchCntSetWork;
            eraNameDispDiv = Convert.ToBoolean(cond.EraNameDispCd1); // 0:����^1:�a��
            uiControlFlg = Convert.ToBoolean(cond.SearchUICntDivCd); // 0:PM7�X�^�C���^1:PM.NS�X�^�C��
            substFlg = cond.SubstCondDivCd; // 0:��ւ��Ȃ�  1:��ւ���i�݌ɔ��肠��j 2:��ւ���i�݌ɔ���Ȃ��j
            userSubstFlg = cond.SubstApplyDivCd;
            enterFlg = cond.EnterProcDivCd; // 0:PM7, 1:�I�� 2:����ʁi�����ˌ����A�����˃Z�b�g�A�Z�b�g�ˊm��j
            totalAmountDispWay = cond.TotalAmountDispWayCd; // 0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j
            if (eraNameDispDiv) // �a��\���̏ꍇ
            {
                dtfi = new CultureInfo("ja-JP").DateTimeFormat;
                dtfi.Calendar = new JapaneseCalendar();
            }
            _dsParts = new dsPartsSel();
            _partsInfo = _dsParts.PartsInfo;
            _StockTable = _dsParts.Stock;
            _modelPartsDetail = _dsParts.ModelPartsDetail;

            Thread initialProcThread = new Thread(InitialThread1);
            Thread initialProcThread2 = new Thread(InitialThread2);
            Thread initialProcThread3 = new Thread(InitialThread3);
            initialProcThread.Start();
            initialProcThread2.Start();
            initialProcThread3.Start();

            InitializeComponent();
            InitializeComponentCustom();

            //InitializeData();

            InitializeForm();
            while (initialProcThread.ThreadState == ThreadState.Running || initialProcThread2.ThreadState == ThreadState.Running)
                Thread.Sleep(10);

            InitializeForm2();

            InitializeTable();
            InitializeGrid();
            MakeConditionGridData();
            RefreshDataCount();
        }

        /// <summary>
        /// �}���`�X���b�h�ŏ�������镔��
        /// </summary>
        private void InitialThread1()
        {
            // 2010/03/15 >>>
            //_colorTable = _orgDataSet.OfrColorInfo;
            //_trimTable = _orgDataSet.OfrTrimInfo;
            //_equipTable = _orgDataSet.OfrEquipInfo;

            //InitializeData();
            ////frmPartsInfo = new FrmPartsInfo();
            ////frmJoinInfo = new FrmJoinPartsInfo(_orgDataSet.UsrJoinParts);

            this.InitialThread1(true);
            // 2010/03/15 <<<
        }

        // 2010/03/15 Add >>>
        /// <summary>
        /// �}���`�X���b�h�ŏ�������镔��
        /// </summary>
        private void InitialThread1(bool settingPrice)
        {
            _colorTable = _orgDataSet.OfrColorInfo;
            _trimTable = _orgDataSet.OfrTrimInfo;
            _equipTable = _orgDataSet.OfrEquipInfo;

            InitializeData(settingPrice);
        }
        // 2010/03/15 Add <<<

        private void InitialThread2()
        {
            while (_orgDataSet == null)
                System.Threading.Thread.Sleep(10);
            _modelPartsDetail.Merge(_orgDataSet.ModelPartsDetail, true, MissingSchemaAction.Ignore);

        }

        private void InitialThread3()
        {
            lstEnum.Add("ModelGradeNm", RowFilterKind.ModelGradeNm);
            lstEnum.Add("BodyName", RowFilterKind.BodyName);
            lstEnum.Add("DoorCount", RowFilterKind.DoorCount);
            lstEnum.Add("EngineModelNm", RowFilterKind.EngineModelNm);
            lstEnum.Add("EngineDisplaceNm", RowFilterKind.EngineDisplaceNm);
            lstEnum.Add("EDivNm", RowFilterKind.EDivNm);
            lstEnum.Add("TransmissionNm", RowFilterKind.TransmissionNm);
            lstEnum.Add("ShiftNm", RowFilterKind.ShiftNm);
            lstEnum.Add("WheelDriveMethodNm", RowFilterKind.WheelDriveMethodNm);
            lstEnum.Add("AddiCarSpec1", RowFilterKind.AddiCarSpec1);
            lstEnum.Add("AddiCarSpec2", RowFilterKind.AddiCarSpec2);
            lstEnum.Add("AddiCarSpec3", RowFilterKind.AddiCarSpec3);
            lstEnum.Add("AddiCarSpec4", RowFilterKind.AddiCarSpec4);
            lstEnum.Add("AddiCarSpec5", RowFilterKind.AddiCarSpec5);
            lstEnum.Add("AddiCarSpec6", RowFilterKind.AddiCarSpec6);

            frmPartsInfo = new FrmPartsInfo();
            frmJoinInfo = new FrmJoinPartsInfo(_orgDataSet);
        }

        private void InitializeComponentCustom()
        {
            panel = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            panel.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            panel.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            this.StatusBar.Panels.Add(panel);
        }

        private void InitializeForm()
        {
            // �X�e�[�^�X�o�[�̏�����
            StatusBar.Panels[0].Text = string.Empty;

            // �c�[���o�[�̃C���[�W(16x16)�⃁�b�Z�[�W��ݒ肷��
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;

            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;

            if (uiControlFlg && _mode == 0) // PM.NS����ʐ���@���@�ʏ탂�[�h
            {
                ToolbarsManager.Tools["Button_Set"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.MODEL;
                ToolbarsManager.Tools["Button_Join"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CARCHANGE;
            }
            else// PM7����ʐ���@���́@�������ϐ�p���[�h
            {
                ToolbarsManager.Tools["Button_Set"].SharedProps.Visible = false;
                ToolbarsManager.Tools["Button_Join"].SharedProps.Visible = false;
            }

            if (substFlg != 0)
            {
                ToolbarsManager.Tools["Button_Subst"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CARADD;
                //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            }
            else
            {
                ToolbarsManager.Tools["Button_Subst"].SharedProps.Visible = false;
            }
            //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = false;
            ToolbarsManager.Tools["BtnClear"].SharedProps.Visible = false;

            ToolbarsManager.Tools["BtnExchangeDisp"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INDICATIONCHANGE;
            ToolbarsManager.Tools["BtnSpec"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SUBMENU;
            ToolbarsManager.Tools["BtnClear"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;

        }

        private void InitializeForm2()
        {
            IsColorData = _colorTable != null && _colorTable.Count >= 1;
            IsTrimData = _trimTable != null && _trimTable.Count >= 1;
            IsEquipData = _equipTable != null && _equipTable.Count >= 1;

            //�J���[
            ColorGrid.Visible = IsColorData;//�J���[������
            splitContainer1.Panel1Collapsed = !IsColorData; // �J���[������
            splitContainer1.Panel2Collapsed = (!IsTrimData && !IsEquipData);// �g�����A��������������
            //�g����
            splitContainer2.Panel1Collapsed = !IsTrimData; //�g����������
            //����
            splitContainer2.Panel2Collapsed = !IsEquipData; //����������

            ultraLabel5.Visible = (!IsColorData && !IsTrimData && !IsEquipData);

            if (IsColorData)
                splitContainer1.SplitterDistance = Convert.ToInt32(dockableWindow2.Width / 2);
            else if (IsTrimData || (IsTrimData == false && IsEquipData))
                splitContainer2.Width = dockableWindow2.Width;

            // --- UPD m.suzuki 2010/06/10 ---------->>>>>
            //txtBLCode.Text = _partsInfo[0].TbsPartsCode.ToString("00000");
            if ( !_partsInfo[0].IsTbsPartsCodeFSNull() && _partsInfo[0].TbsPartsCodeFS != 0 )
            {
                // ���R�����̏ꍇ�͉�ʓ��͂��ꂽBL�R�[�h��\������
                // �i�����i�E���i��BL���ނƈقȂ�ݒ���\�Ȉׁj
                txtBLCode.Text = _partsInfo[0].TbsPartsCodeFS.ToString( "00000" );
            }
            else
            {
                txtBLCode.Text = _partsInfo[0].TbsPartsCode.ToString( "00000" );
            }
            // --- UPD m.suzuki 2010/06/10 ----------<<<<<
            PartsInfoDataSet.UsrGoodsInfoRow rowGoods = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(_partsInfo[0].CatalogPartsMakerCd, _partsInfo[0].ClgPrtsNoWithHyphen);
            if (rowGoods != null)
            {
                if (rowGoods.SearchPartsFullName != string.Empty)
                {
                    txtPartName.Text = rowGoods.SearchPartsFullName;
                }
                else if (rowGoods.GoodsName != string.Empty)
                {
                    txtPartName.Text = rowGoods.GoodsName;
                }
                else
                {
                    txtPartName.Text = rowGoods.GoodsOfrName;
                }
            }
            else
            {
                txtPartName.Text = _partsInfo[0].PartsName;
            }
            string keyCol;
            string valueCol;
            if (IsColorData)
            {
                cmbColor.BeginUpdate();
                keyCol = _colorTable.ColorCdInfoNoColumn.ColumnName;
                valueCol = _colorTable.ColorNameColumn.ColumnName;
                cmbColor.DataSource = CmbDataContainer.GetList(_colorTable, keyCol, valueCol);
                cmbColor.ValueMember = "KeyMember";
                cmbColor.DisplayMember = "DisplayMember";
                cmbColor.EndUpdate();
                PMKEN01010E.ColorCdInfoRow[] row = (PMKEN01010E.ColorCdInfoRow[])_orgCar.ColorCdInfo.Select("SelectionState = true", "", DataViewRowState.CurrentRows);
                if (row.Length > 0)
                {
                    cmbColor.Value = row[0].ColorCode;
                }
            }
            else
            {
                pnlColor.Visible = false;
            }
            if (IsTrimData)
            {
                cmbTrim.BeginUpdate();
                keyCol = _trimTable.TrimCodeColumn.ColumnName;
                valueCol = _trimTable.TrimNameColumn.ColumnName;
                cmbTrim.DataSource = CmbDataContainer.GetList(_trimTable, keyCol, valueCol);
                cmbTrim.ValueMember = "KeyMember";
                cmbTrim.DisplayMember = "DisplayMember";
                cmbTrim.EndUpdate();
                PMKEN01010E.TrimCdInfoRow[] row = (PMKEN01010E.TrimCdInfoRow[])_orgCar.TrimCdInfo.Select("SelectionState = true", "", DataViewRowState.CurrentRows);
                if (row.Length > 0)
                {
                    cmbTrim.Value = row[0].TrimCode;
                }
            }
            else
            {
                pnlTrim.Visible = false;
            }
            if (IsEquipData)
            {
                FillInSoubiGrid();
                GridFiltering();
            }
            else
            {
                pnlEquip.Visible = IsEquipData;
            }

            //RefreshDataCount();
        }

        private void InitializeTable()
        {
            originalRowFilter = _orgDataSet.PartsInfo.DefaultView.RowFilter;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2009.07.23 DEL
            //_partsInfo.DefaultView.Sort = _partsInfo.ModelPrtsAblsYmColumn.ColumnName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2009.07.23 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2009.07.23 ADD
            _partsInfo.DefaultView.Sort = string.Format( "{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                                                        _partsInfo.SeriesModelColumn.ColumnName,
                                                        _partsInfo.CategorySignModelColumn.ColumnName,
                                                        _partsInfo.ExhaustGasSignColumn.ColumnName,
                                                        _partsInfo.FullModelFixedNoColumn.ColumnName,
                                                        _partsInfo.PartsQtyColumn.ColumnName,
                                                        _partsInfo.PartsOpNmColumn.ColumnName,
                                                        _partsInfo.NewPrtsNoWithHyphenColumn.ColumnName,
                                                        _partsInfo.CatalogPartsMakerCdColumn.ColumnName,
                                                        _partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName
                                                        );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2009.07.23 ADD
            gridPartsInfo.BeginUpdate();
            gridPartsInfo.DataSource = _partsInfo.DefaultView;//_orgDataSet.PartsInfo.DefaultView;
            gridPartsInfo.EndUpdate();
            gridStock.DataSource = _StockTable.DefaultView;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
            SettingStockView( _StockTable.DefaultView );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
            ColorGrid.DataSource = _colorTable.DefaultView;
            TrimGrid.DataSource = _trimTable.DefaultView;
            EquipGrid.DataSource = _equipTable.DefaultView;

            PartsNarrowing = _partsInfo[0].PartsNarrowingCode;
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
        /// <summary>
        /// �݌ɂ�DataSource�ƂȂ�View��ݒ肵�܂�
        /// </summary>
        /// <param name="dataView"></param>
        private void SettingStockView( DataView dataView )
        {
            // �\�[�g�ݒ�
            dataView.Sort = string.Format( "{0}, {1}",
                                            _StockTable.SortDivColumn.ColumnName,
                                            _StockTable.WarehouseCodeColumn.ColumnName );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD

        private void InitializeGrid()
        {
            colToShow = new List<string>(new string[]{ 
                _modelPartsDetail.ModelGradeNmColumn.ColumnName,            // 0
                _modelPartsDetail.BodyNameColumn.ColumnName,                // 1
                _modelPartsDetail.DoorCountColumn.ColumnName,               // 2
                _modelPartsDetail.EngineModelNmColumn.ColumnName,           // 3
                _modelPartsDetail.EngineDisplaceNmColumn.ColumnName,        // 4
                _modelPartsDetail.EDivNmColumn.ColumnName,                  // 5
                _modelPartsDetail.TransmissionNmColumn.ColumnName,          // 6
                _modelPartsDetail.ShiftNmColumn.ColumnName,                 // 7
                _modelPartsDetail.WheelDriveMethodNmColumn.ColumnName,      // 8
                _modelPartsDetail.AddiCarSpec1Column.ColumnName,            // 9
                _modelPartsDetail.AddiCarSpec2Column.ColumnName,            // 10
                _modelPartsDetail.AddiCarSpec3Column.ColumnName,            // 11
                _modelPartsDetail.AddiCarSpec4Column.ColumnName,            // 12
                _modelPartsDetail.AddiCarSpec5Column.ColumnName,            // 13
                _modelPartsDetail.AddiCarSpec6Column.ColumnName,            // 14
                _modelPartsDetail.SelImgColumn.ColumnName
            });

            gridPartsInfo.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            //gridPartsInfo.DisplayLayout.InterBandSpacing = 3;

            Infragistics.Win.UltraWinGrid.UltraGridBand Band0 = gridPartsInfo.DisplayLayout.Bands[0];
            Infragistics.Win.UltraWinGrid.UltraGridBand Band1 = gridPartsInfo.DisplayLayout.Bands[1];

            #region ���i���o���h(�e�o���h)
            Band0.Override.HeaderPlacement = HeaderPlacement.FixedOnTop;
            Band0.Override.RowSizing = RowSizing.Fixed;
            Band0.Override.AllowColSizing = AllowColSizing.None;
            Band0.Indentation = 0;
            Band0.UseRowLayout = true;
            Band0.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            #region �s�v�R������\������
            Band0.Columns[_partsInfo.PartsNarrowingCodeColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.PartsCodeColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.PartsNameColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.FullModelFixedNoColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.TbsPartsCodeColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.CatalogPartsMakerNmColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.ColdDistrictsFlagColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.ColorNarrowingFlagColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.TrimNarrowingFlagColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.EquipNarrowingFlagColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.MakerOfferPartsNameColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.PartsLayerCdColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.PartsUniqueNoColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.SelectionStateColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.NewPrtsNoWithHyphenColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.OldPartsNoColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.ModelPrtsAdptYmColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.ModelPrtsAblsYmColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.ModelPrtsAdptFrameNoColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.ModelPrtsAblsFrameNoColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.UsrSubstColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.WarehouseCodeColumn.ColumnName].Hidden = true;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2009.07.23 ADD
            Band0.Columns[_partsInfo.SeriesModelColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.CategorySignModelColumn.ColumnName].Hidden = true;
            Band0.Columns[_partsInfo.ExhaustGasSignColumn.ColumnName].Hidden = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2009.07.23 ADD
            // --- ADD m.suzuki 2010/06/10 ---------->>>>>
            Band0.Columns[_partsInfo.TbsPartsCodeFSColumn.ColumnName].Hidden = true;
            // --- ADD m.suzuki 2010/06/10 ----------<<<<<
            #endregion
            if (_mode == 1) // �������ϐ�p���[�h
            {
                Band0.Columns[_partsInfo.JoinColumn.ColumnName].Hidden = true;
                Band0.Columns[_partsInfo.SetColumn.ColumnName].Hidden = true;
            }
            if (substFlg == 0) // �u��ւ��Ȃ��v�͑�փJ������\�����Ȃ��B
            {
                Band0.Columns[_partsInfo.SubstColumn.ColumnName].Hidden = true;
            }

            for (int Index = 0; Index < Band0.Columns.Count; Index++)
            {
                if (Band0.Columns[Index].Hidden)
                    continue;
                // �����\���ʒu
                if ((Band0.Columns[Index].DataType == typeof(int)) ||
                         (Band0.Columns[Index].DataType == typeof(double)) ||
                         (Band0.Columns[Index].DataType == typeof(Int64)) ||
                         (Band0.Columns[Index].DataType == typeof(Int16)))
                {
                    Band0.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else if (Band0.Columns[Index].DataType == typeof(Image))
                {
                    Band0.Columns[Index].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                }
                else
                {
                    Band0.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                Band0.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // �����\���ʒu
                Band0.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            ColInfo.SetColInfo(Band0, _partsInfo.SelImageColumn.ColumnName, 2, 0, 1, 6, 15);

            // 1�i
            ColInfo.SetColInfo(Band0, _partsInfo.PartsNoColumn.ColumnName, 3, 0, 7, 2, 70);
            ColInfo.SetColInfo(Band0, _partsInfo.PrimePartsNoColumn.ColumnName, 10, 0, 7, 2, 70);
            ColInfo.SetColInfo(Band0, _partsInfo.JoinSrcPartsNoColumn.ColumnName, 17, 0, 7, 2, 60);

            // --- ADD 2013/03/25 ---------->>>>>
            // ���Y/�O�ԋ敪�̒l���`�F�b�N
            if (_orgCar != null && _orgCar.CarModelUIData[0].DomesticForeignCode == 2)
            {
                // �O�Ԃ̏ꍇ
                // ���i�i���敪�̒l���`�F�b�N
                if (PartsNarrowing == 1)
                {
                    // ���i�i���敪���ԑ�ԍ�
                    // VIN�R�[�h�J�n�EVIN�R�[�h�I����\��
                    ColInfo.SetColInfo(Band0, _partsInfo.VinProduceStartNoColumn.ColumnName, 24, 0, 6, 2, 60);
                    ColInfo.SetColInfo(Band0, _partsInfo.VinProduceEndNoColumn.ColumnName, 30, 0, 6, 2, 60);
                    // �N���E�ԑ�ԍ��͔�\��
                    Band0.Columns[_partsInfo.YearStartColumn.ColumnName].Hidden = true;
                    Band0.Columns[_partsInfo.YearEndColumn.ColumnName].Hidden = true;
                    Band0.Columns[_partsInfo.FrameNoStartColumn.ColumnName].Hidden = true;
                    Band0.Columns[_partsInfo.FrameNoEndColumn.ColumnName].Hidden = true;
                    
                }
                else
                {
                    // ���i�i���敪���N��
                    ColInfo.SetColInfo(Band0, _partsInfo.YearStartColumn.ColumnName, 24, 0, 6, 2, 60);
                    ColInfo.SetColInfo(Band0, _partsInfo.YearEndColumn.ColumnName, 30, 0, 6, 2, 60);
                    // VIN�R�[�h�E�ԑ�ԍ��͔�\��
                    Band0.Columns[_partsInfo.VinProduceStartNoColumn.ColumnName].Hidden = true;
                    Band0.Columns[_partsInfo.VinProduceEndNoColumn.ColumnName].Hidden = true;
                    Band0.Columns[_partsInfo.FrameNoStartColumn.ColumnName].Hidden = true;
                    Band0.Columns[_partsInfo.FrameNoEndColumn.ColumnName].Hidden = true;
                }
            }
            else
            {
                // ���Y�Ԃ̏ꍇ��VIN�R�[�h���\���ɃZ�b�g
                Band0.Columns[_partsInfo.VinProduceStartNoColumn.ColumnName].Hidden = true;
                Band0.Columns[_partsInfo.VinProduceEndNoColumn.ColumnName].Hidden = true;

                // VIN�R�[�h�i���s��Ȃ��ꍇ
                if (PartsNarrowing == 0)
                {
                    ColInfo.SetColInfo(Band0, _partsInfo.YearStartColumn.ColumnName, 24, 0, 6, 2, 60);
                    ColInfo.SetColInfo(Band0, _partsInfo.YearEndColumn.ColumnName, 30, 0, 6, 2, 60);
                    Band0.Columns[_partsInfo.FrameNoStartColumn.ColumnName].Hidden = true;
                    Band0.Columns[_partsInfo.FrameNoEndColumn.ColumnName].Hidden = true;
                }
                else
                {
                    ColInfo.SetColInfo(Band0, _partsInfo.FrameNoStartColumn.ColumnName, 24, 0, 6, 2, 60);
                    ColInfo.SetColInfo(Band0, _partsInfo.FrameNoEndColumn.ColumnName, 30, 0, 6, 2, 60);
                    Band0.Columns[_partsInfo.YearStartColumn.ColumnName].Hidden = true;
                    Band0.Columns[_partsInfo.YearEndColumn.ColumnName].Hidden = true;
                }
            }
            // --- ADD 2013/03/25 ----------<<<<<

            ColInfo.SetColInfo(Band0, _partsInfo.PartsQtyColumn.ColumnName, 36, 0, 4, 2, 40);
            if (_mode == 0)
            {
                ColInfo.SetColInfo(Band0, _partsInfo.GenkaColumn.ColumnName, 40, 0, 4, 2, 40);
                ColInfo.SetColInfo(Band0, _partsInfo.ArarirituColumn.ColumnName, 44, 0, 4, 2, 40);
            }
            else // �������ϐ�p���[�h�ł͌����E��ւȂǂ��Ȃ����������K�v�E�Q�i�����l
            {
                ColInfo.SetColInfo(Band0, _partsInfo.GenkaColumn.ColumnName, 40, 0, 4, 2, 40);
                ColInfo.SetColInfo(Band0, _partsInfo.ArarirituColumn.ColumnName, 45, 0, 5, 2, 40);
            }

            // 2�i
            ColInfo.SetColInfo(Band0, _partsInfo.PartsOpNmColumn.ColumnName, 3, 2, 14, 2, 140);
            ColInfo.SetColInfo(Band0, _partsInfo.StandardNameColumn.ColumnName, 17, 2, 7, 2, 70);
            ColInfo.SetColInfo(Band0, _partsInfo.WarehouseColumn.ColumnName, 24, 2, 4, 2, 40);
            ColInfo.SetColInfo(Band0, _partsInfo.ShelfColumn.ColumnName, 28, 2, 4, 2, 40);
            ColInfo.SetColInfo(Band0, _partsInfo.StockCntColumn.ColumnName, 32, 2, 4, 2, 40);
            ColInfo.SetColInfo(Band0, _partsInfo.PriceColumn.ColumnName, 36, 2, 4, 2, 40);
            if (_mode == 0)
            {
                ColInfo.SetColInfo(Band0, _partsInfo.UrikaColumn.ColumnName, 40, 2, 4, 2, 40);
                ColInfo.SetColInfo(Band0, _partsInfo.ArarigakuColumn.ColumnName, 44, 2, 4, 2, 40);
            }
            else
            {
                ColInfo.SetColInfo(Band0, _partsInfo.UrikaColumn.ColumnName, 40, 2, 5, 2, 40);
                ColInfo.SetColInfo(Band0, _partsInfo.ArarigakuColumn.ColumnName, 45, 2, 5, 2, 40);
            }

            // 1�E2�i
            if (_mode == 0) // �ʏ탂�[�h�̏ꍇ
            {
                if (substFlg == 0) // ��ւ��Ȃ�
                {
                    ColInfo.SetColInfo(Band0, _partsInfo.SetColumn.ColumnName, 48, 0, 1, 4, 12);
                    ColInfo.SetColInfo(Band0, _partsInfo.JoinColumn.ColumnName, 49, 0, 1, 4, 12);
                }
                else // ��ւ���i�݌ɔ���Ȃ��j ���́@��ւ���i�݌ɔ��肠��j
                {
                    ColInfo.SetColInfo(Band0, _partsInfo.SubstColumn.ColumnName, 48, 0, 1, 4, 15);
                    ColInfo.SetColInfo(Band0, _partsInfo.SetColumn.ColumnName, 49, 0, 1, 4, 15);
                    ColInfo.SetColInfo(Band0, _partsInfo.JoinColumn.ColumnName, 50, 0, 1, 4, 15);
                }
            }
            else            // �������ϐ�p���[�h�̏ꍇ
            {
                if (substFlg != 0)
                {
                    ColInfo.SetColInfo(Band0, _partsInfo.SubstColumn.ColumnName, 50, 0, 1, 4, 12);
                }
            }

            Band0.Columns[_partsInfo.PriceColumn.ColumnName].Format = "C";
            Band0.Columns[_partsInfo.GenkaColumn.ColumnName].Format = "C";
            Band0.Columns[_partsInfo.UrikaColumn.ColumnName].Format = "C";
            Band0.Columns[_partsInfo.ArarigakuColumn.ColumnName].Format = "C";
            Band0.Columns[_partsInfo.ArarirituColumn.ColumnName].Format = "#%";
            Band0.Columns[_partsInfo.StockCntColumn.ColumnName].Format = "###,###,##0.00";
            Band0.Columns[_partsInfo.PartsQtyColumn.ColumnName].Format = "###,###,##0.00";
            #endregion

            #region �^�����o���h�ݒ�
            List<String> ret = SetAddCarSpecColumn(gridPartsInfo.DisplayLayout.Bands[1]);
            bool is4thRow = false;
            if (ret.Count > 0)
                is4thRow = true;

            Band1.UseRowLayout = true;
            Band1.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.None;
            //Band1.Override.HeaderPlacement = HeaderPlacement.OncePerGroupedRowIsland;
            //Band1.ColHeadersVisible = false;
            Band1.Indentation = 0;
            //Band1.Override.DefaultRowHeight = 20;
            Band1.Columns[_modelPartsDetail.FullModelFixedNoColumn.ColumnName].Hidden = true;
            Band1.Columns[_modelPartsDetail.PartsNoColumn.ColumnName].Hidden = true;
            Band1.Columns[_modelPartsDetail.PartsMakerCdColumn.ColumnName].Hidden = true;
            Band1.Columns[_modelPartsDetail.SelectionStateColumn.ColumnName].Hidden = true;
            Band1.Columns[_modelPartsDetail.PartsUniqueNoColumn.ColumnName].Hidden = true;
            Band1.Columns[_modelPartsDetail.AddiCarSpecTitle1Column.ColumnName].Hidden = true;
            Band1.Columns[_modelPartsDetail.AddiCarSpecTitle2Column.ColumnName].Hidden = true;
            Band1.Columns[_modelPartsDetail.AddiCarSpecTitle3Column.ColumnName].Hidden = true;
            Band1.Columns[_modelPartsDetail.AddiCarSpecTitle4Column.ColumnName].Hidden = true;
            Band1.Columns[_modelPartsDetail.AddiCarSpecTitle5Column.ColumnName].Hidden = true;
            Band1.Columns[_modelPartsDetail.AddiCarSpecTitle6Column.ColumnName].Hidden = true;

            Band1.Override.RowSizing = RowSizing.Fixed;
            Band1.Override.AllowColSizing = AllowColSizing.None;
            Band1.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // �������
            if (ret.Count > 0)
                ColInfo.SetColInfo(Band1, _modelPartsDetail.SelImgColumn.ColumnName, 2, 0, 1, 4, 13);
            else
                ColInfo.SetColInfo(Band1, _modelPartsDetail.SelImgColumn.ColumnName, 2, 0, 1, 2, 13);
            ColInfo.SetColInfo(Band1, colToShow[0], 3, 0, 6, 2, 50, 16);
            ColInfo.SetColInfo(Band1, colToShow[1], 9, 0, 6, 2, 50, 16);
            ColInfo.SetColInfo(Band1, colToShow[2], 15, 0, 6, 2, 50, 16);
            ColInfo.SetColInfo(Band1, colToShow[3], 21, 0, 6, 2, 50, 16);
            ColInfo.SetColInfo(Band1, colToShow[4], 27, 0, 6, 2, 50, 16);
            ColInfo.SetColInfo(Band1, colToShow[5], 33, 0, 6, 2, 50, 16);
            ColInfo.SetColInfo(Band1, colToShow[6], 39, 0, 5, 2, 50, 16);
            ColInfo.SetColInfo(Band1, colToShow[7], 44, 0, 4, 2, 50, 16);
            ColInfo.SetColInfo(Band1, colToShow[8], 48, 0, 4, 2, 50, 16);
            if (is4thRow)
            {
                int originX = 4;
                int del = 48 / ret.Count;
                int remainder = 48;
                for (int i = 0; i < ret.Count; i++)
                {
                    if (i == ret.Count - 1)
                        del = remainder;
                    ColInfo.SetColInfo(Band1, ret[i], originX, 2, del, 2, 60, 16);
                    originX += del;
                    remainder -= del;
                }
            }
            #endregion

            #region �J���O���b�h
            ColorGrid.DisplayLayout.Bands[0].Columns[_colorTable.PartsProperNoColumn.ColumnName].Hidden = true;
            ColorGrid.DisplayLayout.Bands[0].Columns[_colorTable.SelectionStateColumn.ColumnName].Hidden = true;
            ColorGrid.DisplayLayout.Bands[0].Columns[_colorTable.ColorCdInfoNoColumn.ColumnName].Width = 100;
            ColorGrid.DisplayLayout.Bands[0].Columns[_colorTable.ColorNameColumn.ColumnName].Width = 200;
            ColorGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            #endregion

            #region �g�����O���b�h
            TrimGrid.DisplayLayout.Bands[0].Columns[_trimTable.PartsProperNoColumn.ColumnName].Hidden = true;
            TrimGrid.DisplayLayout.Bands[0].Columns[_trimTable.SelectionStateColumn.ColumnName].Hidden = true;
            TrimGrid.DisplayLayout.Bands[0].Columns[_trimTable.TrimCodeColumn.ColumnName].Width = 100;
            TrimGrid.DisplayLayout.Bands[0].Columns[_trimTable.TrimNameColumn.ColumnName].Width = 200;
            TrimGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            #endregion

            #region �����O���b�h
            EquipGrid.DisplayLayout.Bands[0].Columns[_equipTable.PartsProperNoColumn.ColumnName].Hidden = true;
            EquipGrid.DisplayLayout.Bands[0].Columns[_equipTable.SelectionStateColumn.ColumnName].Hidden = true;
            EquipGrid.DisplayLayout.Bands[0].Columns[_equipTable.EquipmentCodeColumn.ColumnName].Hidden = true;
            EquipGrid.DisplayLayout.Bands[0].Columns[_equipTable.EquipmentDispOrderColumn.ColumnName].Hidden = true;
            EquipGrid.DisplayLayout.Bands[0].Columns[_equipTable.EquipmentGenreCdColumn.ColumnName].Hidden = true;
            EquipGrid.DisplayLayout.Bands[0].Columns[_equipTable.EquipmentIconCodeColumn.ColumnName].Hidden = true;
            EquipGrid.DisplayLayout.Bands[0].Columns[_equipTable.EquipmentShortNameColumn.ColumnName].Hidden = true;
            EquipGrid.DisplayLayout.Bands[0].Columns[_equipTable.EquipmentGenreNmColumn.ColumnName].Width = 200;
            EquipGrid.DisplayLayout.Bands[0].Columns[_equipTable.EquipmentNameColumn.ColumnName].Width = 200;
            EquipGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            #endregion

        }

        //---- ADD 杍^  2019/01/08 FOR �V�����̑Ή� ---->>>>>
        /// <summary>
        /// ���Y�N��������擾����
        /// </summary>
        /// <param name="produceTypeOfYear">���Y�N��</param>
        /// <remarks>
        /// <br>Note	   : ���Y�N����a��́uGG YY�NMM���v�`���ɕϊ�����</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2019/01/08</br>
        /// </remarks>
        private string GetStrFromDt(DateTime produceTypeOfYear)
        {
            string retYear = string.Empty;
            retYear = TDateTime.DateTimeToString("GGYYMM", produceTypeOfYear);
            string gg = retYear.Substring(0, 2);
            string yymm = retYear.Substring(2, 6);
            retYear = gg + " " + yymm;
            return retYear;
        }
        //---- ADD 杍^  2019/01/08 FOR �V�����̑Ή� ----<<<<<

        /// <summary>
        /// �\���p�f�[�^��DataTable�ɓo�^���邽�߂̃T�u�X���b�h
        /// </summary>
        /// <param name="setPrice">���i�̃Z�b�g</param>
        // 2010/03/15 >>>
        //private void InitializeData()
        /// <remarks>
        /// <br>UpdateNote   2019/01/08  杍^</br>
        /// <br>�C�����e     �V�����̑Ή�</br>
        /// </remarks>
        private void InitializeData(bool setPrice)
        // 2010/03/15 <<<
        {
            // 2010/03/15 >>>
            //// 2009.02.10 Add >>>
            //this.SettingPriceTargetData();
            //// 2009.02.10 Add <<<

            if (setPrice) this.SettingPriceTargetData();
            // 2010/03/15 <<<

            // 2009.06.08 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //_partsInfo.Merge(_orgDataSet.PartsInfo, true, MissingSchemaAction.Ignore);

            if (_orgDataSet.BLGoodsDrCode != 0)
            {
                DataRow[] rows = _orgDataSet.PartsInfo.Select(string.Format("{0}={1}", _orgDataSet.PartsInfo.TbsPartsCdDerivedNoColumn.ColumnName, _orgDataSet.BLGoodsDrCode));
                PartsInfoDataSet.PartsInfoDataTable dt = new PartsInfoDataSet.PartsInfoDataTable();
                if (( rows != null ) && ( rows.Length != 0 ))
                {
                    foreach (DataRow row in rows)
                    {
                        PartsInfoDataSet.PartsInfoRow p = dt.NewPartsInfoRow();
                        PartsInfoDataSet.PartsInfoRow temprow = (PartsInfoDataSet.PartsInfoRow)row;
                        p.CatalogPartsMakerCd = temprow.CatalogPartsMakerCd;
                        p.CatalogPartsMakerNm = temprow.CatalogPartsMakerNm;
                        p.ClgPrtsNoWithHyphen = temprow.ClgPrtsNoWithHyphen;
                        p.ColdDistrictsFlag = temprow.ColdDistrictsFlag;
                        p.ColorNarrowingFlag = temprow.ColorNarrowingFlag;
                        p.EquipNarrowingFlag = temprow.EquipNarrowingFlag;
                        p.FigshapeNo = temprow.FigshapeNo;
                        p.FullModelFixedNo = temprow.FullModelFixedNo;
                        p.MakerOfferPartsName = temprow.MakerOfferPartsName;
                        p.ModelPrtsAblsFrameNo = temprow.ModelPrtsAblsFrameNo;
                        p.ModelPrtsAblsYm = temprow.ModelPrtsAblsYm;
                        p.ModelPrtsAdptFrameNo = temprow.ModelPrtsAdptFrameNo;
                        p.ModelPrtsAdptYm = temprow.ModelPrtsAdptYm;
                        p.NewPrtsNoNoneHyphen = temprow.NewPrtsNoNoneHyphen;
                        p.NewPrtsNoWithHyphen = temprow.NewPrtsNoWithHyphen;
                        p.OfferDate = temprow.OfferDate;
                        p.PartsCode = temprow.PartsCode;
                        p.PartsLayerCd = temprow.PartsLayerCd;
                        p.PartsName = temprow.PartsName;
                        p.PartsNameKana = temprow.PartsNameKana;
                        p.PartsNarrowingCode = temprow.PartsNarrowingCode;
                        p.PartsOpNm = temprow.PartsOpNm;
                        p.PartsQty = temprow.PartsQty;
                        p.PartsSearchCode = temprow.PartsSearchCode;
                        p.PartsUniqueNo = temprow.PartsUniqueNo;
                        p.SelectionState = temprow.SelectionState;
                        p.StandardName = temprow.StandardName;
                        p.TbsPartsCdDerivedNo = temprow.TbsPartsCdDerivedNo;
                        p.TbsPartsCode = temprow.TbsPartsCode;
                        p.TrimNarrowingFlag = temprow.TrimNarrowingFlag;
                        p.WorkOrPartsDivNm = temprow.WorkOrPartsDivNm;

                        // --- ADD 2013/03/25 ---------->>>>>
                        // �uVIN���YNo.(�n��)�v�uVIN���YNo.(�I��)�v
                        p.VinProduceStartNo = temprow.VinProduceStartNo;
                        p.VinProduceEndNo = temprow.VinProduceEndNo;
                        // --- ADD 2013/03/25 ----------<<<<<

                        dt.AddPartsInfoRow(p);
                    }
                }

                if (dt.Count != 0)
                {
                    _partsInfo.Merge(dt, true, MissingSchemaAction.Ignore);
                }
                else
                {
                    _partsInfo.Merge(_orgDataSet.PartsInfo, true, MissingSchemaAction.Ignore);
                }
            }
            else
            {
                _partsInfo.Merge(_orgDataSet.PartsInfo, true, MissingSchemaAction.Ignore);
            }
            // 2009.06.08 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            catalogMakerCd = _partsInfo[0].CatalogPartsMakerCd;
            //_modelPartsDetail.Merge(_orgDataSet.ModelPartsDetail, true, MissingSchemaAction.Ignore);
            int cnt = _partsInfo.Count;
            string catalogPartsNo, newPartsNo, partsNoInUse = string.Empty;
            int makerCd;
            for (int i = 0; i < cnt; i++)
            {
                #region [ �N���E�ԑ�ԍ��EQTY�ݒ菈�� ]
                // �N�����ҏW
                if (eraNameDispDiv) // �a��
                {
                    if (_partsInfo[i].ModelPrtsAdptYm > 0)
                        //---- UPD 杍^  2019/01/08 FOR �V�����̑Ή� ---->>>>>
                        //_partsInfo[i].YearStart = GetDtFromInt(_partsInfo[i].ModelPrtsAdptYm).ToString("gg yy�NMM��", dtfi);
                        _partsInfo[i].YearStart = GetStrFromDt(GetDtFromInt(_partsInfo[i].ModelPrtsAdptYm));
                        //---- UPD 杍^  2019/01/08 FOR �V�����̑Ή� ----<<<<<
                    if (_partsInfo[i].ModelPrtsAdptYm > 0 && _partsInfo[i].ModelPrtsAblsYm != 999999)
                        //---- UPD 杍^  2019/01/08 FOR �V�����̑Ή� ---->>>>>
                        //_partsInfo[i].YearEnd = GetDtFromInt(_partsInfo[i].ModelPrtsAblsYm).ToString("gg yy�NMM��", dtfi);
                        _partsInfo[i].YearEnd = GetStrFromDt(GetDtFromInt(_partsInfo[i].ModelPrtsAblsYm));
                        //---- UPD 杍^  2019/01/08 FOR �V�����̑Ή� ----<<<<<
                }
                else                // ����
                {
                    if (_partsInfo[i].ModelPrtsAdptYm > 0)
                        _partsInfo[i].YearStart = _partsInfo[i].ModelPrtsAdptYm.ToString("####�N ##��");
                    if (_partsInfo[i].ModelPrtsAdptYm > 0 && _partsInfo[i].ModelPrtsAblsYm != 999999)
                        _partsInfo[i].YearEnd = _partsInfo[i].ModelPrtsAblsYm.ToString("####�N ##��");
                }
                _partsInfo[i].FrameNoStart = _partsInfo[i].ModelPrtsAdptFrameNo.ToString();

                // �t���[���ԍ����ҏW
                if (_partsInfo[i].ModelPrtsAblsFrameNo != 99999999)
                    _partsInfo[i].FrameNoEnd = _partsInfo[i].ModelPrtsAblsFrameNo.ToString();
                _partsInfo[i].JoinSrcPartsNo = _partsInfo[i].ClgPrtsNoWithHyphen;

                // QTY���ҏW
                if (_partsInfo[i].PartsQty == 0)
                    _partsInfo[i].PartsQty = 1;
                #endregion

                catalogPartsNo = _partsInfo[i].ClgPrtsNoWithHyphen;
                newPartsNo = _partsInfo[i].NewPrtsNoWithHyphen;
                makerCd = _partsInfo[i].CatalogPartsMakerCd;
                PartsInfoDataSet.UsrGoodsInfoRow row;
                // --- UPD m.suzuki 2011/02/01 ---------->>>>>
                # region // DEL
                //if (substFlg == 1 && CatalogPartsStockCheck(catalogPartsNo, makerCd))
                //{       // ��֏����F�݌ɔ���L�@���@�J�^���O�i�݌ɂ���̏ꍇ
                //    partsNoInUse = catalogPartsNo;  // ���i�E�݌ɁE�Z�b�g�����J�^���O�i�Ԃ���擾
                //    row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNoInUse);
                //}
                //else
                //{
                //    row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, catalogPartsNo);
                //    if (userSubstFlg != 0)
                //    {
                //        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst(row);
                //        if (rowSubst.Equals(row))
                //        {
                //            row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, newPartsNo);
                //            rowSubst = _orgDataSet.GetUsrSubst(row);
                //            if (rowSubst.Equals(row) == false) // �ŐV�i�ɑ΂��ă��[�U�[��ւ�����ꍇ
                //            {
                //                _partsInfo[i].CatalogPartsMakerCd = makerCd = rowSubst.GoodsMakerCd;
                //                partsNoInUse = rowSubst.GoodsNo;      // ���i�E�݌ɁE�Z�b�g�����ŐV�i�Ԃ���擾
                //                catalogPartsNo = newPartsNo = partsNoInUse;
                //                _partsInfo[i].JoinSrcPartsNo = partsNoInUse;
                //                row = rowSubst;
                //                _partsInfo[i].UsrSubst = true;
                //                _partsInfo[i].NewPrtsNoWithHyphen = string.Empty;
                //            }
                //            else // ���[�U�[��ւ��Ȃ��ꍇ
                //            {
                //                partsNoInUse = newPartsNo;      // ���i�E�݌ɁE�Z�b�g�����ŐV�i�Ԃ���擾
                //            }
                //        }
                //        else // �J�^���O�i�ɑ΂��ă��[�U�[��ւ�����ꍇ
                //        {
                //            _partsInfo[i].CatalogPartsMakerCd = makerCd = rowSubst.GoodsMakerCd;
                //            partsNoInUse = rowSubst.GoodsNo;      // ���i�E�݌ɁE�Z�b�g�����ŐV�i�Ԃ���擾
                //            catalogPartsNo = newPartsNo = partsNoInUse;
                //            _partsInfo[i].JoinSrcPartsNo = partsNoInUse;
                //            row = rowSubst;
                //            _partsInfo[i].UsrSubst = true;
                //            _partsInfo[i].NewPrtsNoWithHyphen = string.Empty;
                //        }
                //    }
                //    else // ���[�U�[��ւ��Ȃ��ꍇ
                //    {
                //        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, newPartsNo);
                //        partsNoInUse = newPartsNo;      // ���i�E�݌ɁE�Z�b�g�����ŐV�i�Ԃ���擾
                //    }
                //}
                # endregion

                bool stockCountNotZero;
                if ( CatalogPartsStockCheck( catalogPartsNo, makerCd, out stockCountNotZero ) )
                {
                    // �݌Ƀ��R�[�h����
                    if ( stockCountNotZero )
                    {
                        //------------------------------
                        // �݌ɂ���(�݌ɐ�>0) �� ��֌�
                        //------------------------------

                        // ��֌�
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( makerCd, catalogPartsNo );
                        partsNoInUse = catalogPartsNo;  // ���i�E�݌ɁE�Z�b�g�����J�^���O�i�Ԃ���擾
                    }
                    else
                    {
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( makerCd, catalogPartsNo );

                        //------------------------------
                        // �݌Ƀ[�� �� ���[�U�[��ւ̂ݗL��
                        //------------------------------
                        // ���[�U�[��֋敪
                        // --- UPD 2011/07/25 ---- >>>>>
                        //if ( userSubstFlg != 0 )
                        //{
                        // --- ADD 2011/11/29 ---- >>>>>
                        if ( userSubstFlg != 0 )
                        {
                        // --- ADD 2011/11/29 ---- <<<<<
                            // ���[�U�[��֐�(������Α�֌�)
                            PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst( row );
                            bool usrSubst = !(rowSubst.Equals( row ));
                            row = rowSubst;

                            _partsInfo[i].CatalogPartsMakerCd = makerCd = rowSubst.GoodsMakerCd;
                            partsNoInUse = rowSubst.GoodsNo;      // ���i�E�݌ɁE�Z�b�g�����ŐV�i�Ԃ���擾
                            catalogPartsNo = newPartsNo = partsNoInUse;
                            _partsInfo[i].JoinSrcPartsNo = partsNoInUse;
                            _partsInfo[i].UsrSubst = usrSubst;
                            _partsInfo[i].NewPrtsNoWithHyphen = string.Empty;
                        // --- ADD 2011/11/29 ---- >>>>>
                        }
                        else
                        {
                            // ��֌�
                            partsNoInUse = catalogPartsNo;  // ���i�E�݌ɁE�Z�b�g�����J�^���O�i�Ԃ���擾
                        }
                        // --- ADD 2011/11/29 ---- <<<<<
                        //}
                        //else
                        //{
                        //    // ��֌�
                        //    partsNoInUse = catalogPartsNo;  // ���i�E�݌ɁE�Z�b�g�����J�^���O�i�Ԃ���擾
                        //}
                        // --- UPD 2011/07/25 ---- <<<<<
                    }
                }
                else
                {
                    //------------------------------
                    // �݌Ƀ��R�[�h�Ȃ� �� ���[�U�[��ցE�񋟑��
                    //------------------------------
                    // ���[�U�[��֋敪
                    // --- UPD 2011/07/25 ---- >>>>>
                    //if ( userSubstFlg != 0 )
                    //{
                    // --- ADD 2011/11/29 ---- >>>>>
                    if ( userSubstFlg != 0 )
                    {
                    // --- ADD 2011/11/29 ---- <<<<<
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( makerCd, catalogPartsNo );

                        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst( row );
                        if ( rowSubst.Equals( row ) )
                        {
                            row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( makerCd, newPartsNo );
                            rowSubst = _orgDataSet.GetUsrSubst( row );
                            if ( rowSubst.Equals( row ) == false ) // �ŐV�i�ɑ΂��ă��[�U�[��ւ�����ꍇ
                            {
                                row = rowSubst;

                                _partsInfo[i].CatalogPartsMakerCd = makerCd = rowSubst.GoodsMakerCd;
                                partsNoInUse = rowSubst.GoodsNo;      // ���i�E�݌ɁE�Z�b�g�����ŐV�i�Ԃ���擾
                                catalogPartsNo = newPartsNo = partsNoInUse;
                                _partsInfo[i].JoinSrcPartsNo = partsNoInUse;
                                _partsInfo[i].UsrSubst = true;
                                _partsInfo[i].NewPrtsNoWithHyphen = string.Empty;
                            }
                            else // ���[�U�[��ւ��Ȃ��ꍇ
                            {
                                partsNoInUse = newPartsNo;
                            }
                        }
                        else // �J�^���O�i�ɑ΂��ă��[�U�[��ւ�����ꍇ
                        {
                            row = rowSubst;

                            _partsInfo[i].CatalogPartsMakerCd = makerCd = rowSubst.GoodsMakerCd;
                            partsNoInUse = rowSubst.GoodsNo;      // ���i�E�݌ɁE�Z�b�g�����ŐV�i�Ԃ���擾
                            catalogPartsNo = newPartsNo = partsNoInUse;
                            _partsInfo[i].JoinSrcPartsNo = partsNoInUse;
                            _partsInfo[i].UsrSubst = true;
                            _partsInfo[i].NewPrtsNoWithHyphen = string.Empty;
                        }
                    // --- ADD 2011/11/29 ---- >>>>>
                    }
                    else
                    {
                        // �񋟑�֐�(������Α�֌�)
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, newPartsNo);
                        partsNoInUse = newPartsNo;      // ���i�E�݌ɁE�Z�b�g�����ŐV�i�Ԃ���擾
                    }
                    // --- ADD 2011/11/29 ---- <<<<<
                    //}
                    //else
                    //{
                    //    // �񋟑�֐�(������Α�֌�)
                    //    row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( makerCd, newPartsNo );
                    //    partsNoInUse = newPartsNo;      // ���i�E�݌ɁE�Z�b�g�����ŐV�i�Ԃ���擾
                    //}
                    // --- UPD 2011/07/25 ---- <<<<<
                }

                // --- UPD m.suzuki 2011/02/01 ----------<<<<<


                _partsInfo[i].PartsNo = partsNoInUse;
                //PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNoInUse);

                if (row != null)    // 2009/11/27 Add
                {                   // 2009/11/27 Add

                    if (totalAmountDispWay == 1) // ���z�\������i�ō��݁j
                    {
                        _partsInfo[i].Price = row.PriceTaxInc;
                        _partsInfo[i].Urika = row.SalesUnitPriceTaxInc;
                        _partsInfo[i].Genka = row.UnitCostTaxInc;
                    }
                    else // ���z�\�����Ȃ��i�Ŕ����j
                    {
                        _partsInfo[i].Price = row.PriceTaxExc;
                        _partsInfo[i].Urika = row.SalesUnitPriceTaxExc;
                        _partsInfo[i].Genka = row.UnitCostTaxExc;
                    }
                    // �e���z�E�e�����͋敪�֌W�Ȃ��Ŕ����Ōv�Z
                    _partsInfo[i].Ararigaku = row.SalesUnitPriceTaxExc - row.UnitCostTaxExc;
                    if (row.SalesUnitPriceTaxExc != 0)
                        _partsInfo[i].Arariritu = _partsInfo[i].Ararigaku / row.SalesUnitPriceTaxExc;
                }               // 2009/11/27 Add
                // �D�Ǖi�ԏ��ҏW
                string primePartsNo;
                if (JoinExists(catalogPartsNo, makerCd, out primePartsNo))
                {
                    _partsInfo[i].Join = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARCHANGE];
                    _partsInfo[i].PrimePartsNo = primePartsNo;
                }
                // ��֏����敪���݌ɔ���L�ŃJ�^���O�i�Ԃ̍݌ɗL�̏ꍇ�J�^���O�i�Ԃ݂̂��猋�����邽�ߒ����̏����͂��Ȃ�
                if (catalogPartsNo != newPartsNo && partsNoInUse == newPartsNo
                        && JoinExists(newPartsNo, makerCd, out primePartsNo))
                {
                    _partsInfo[i].Join = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARCHANGE];
                    if (_partsInfo[i].PrimePartsNo == string.Empty)
                    {
                        _partsInfo[i].PrimePartsNo = primePartsNo;
                    }
                }

                if (SubstExists(catalogPartsNo, makerCd)) // ��ւɊւ��Ă͂��̃��W���[���̒��Ŋe�`�F�b�N�������s��
                {
                    _partsInfo[i].Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
                }
                if (SetExists(partsNoInUse, makerCd))
                {
                    _partsInfo[i].Set = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
                }

                #region [ �݌ɐݒ� ]
                //�݌ɐݒ�
                bool flgStock = false;
                string filter = string.Format("{0}={1} AND {2}='{3}'",
                            _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, makerCd,
                            _orgDataSet.Stock.GoodsNoColumn.ColumnName, partsNoInUse);
                PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])_orgDataSet.Stock.Select(filter);
                for (int j = 0; j < stockRows.Length; j++)
                {
                    if (_StockTable.FindByWarehouseCodeGoodsMakerCdGoodsNo(stockRows[j].WarehouseCode,
                            stockRows[j].GoodsMakerCd, stockRows[j].GoodsNo) == null)
                    {
                        dsPartsSel.StockRow stockRow = _StockTable.NewStockRow();
                        stockRow.GoodsMakerCd = stockRows[j].GoodsMakerCd;
                        stockRow.GoodsNo = stockRows[j].GoodsNo;
                        stockRow.MaximumStockCnt = stockRows[j].MaximumStockCnt;
                        stockRow.MinimumStockCnt = stockRows[j].MinimumStockCnt;
                        stockRow.ShipmentPosCnt = stockRows[j].ShipmentPosCnt;
                        stockRow.WarehouseCode = stockRows[j].WarehouseCode;
                        stockRow.WarehouseName = stockRows[j].WarehouseName;
                        stockRow.WarehouseShelfNo = stockRows[j].WarehouseShelfNo;
                        stockRow.SelectionState = stockRows[j].SelectionState;

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
                        // �݌ɏ��̃\�[�g�Ɏg�p����敪�l���Z�b�g����
                        if ( _orgDataSet.ListPriorWarehouse != null )
                        {
                            int index = _orgDataSet.ListPriorWarehouse.IndexOf( stockRow.WarehouseCode.Trim() );
                            if ( index >= 0 )
                            {
                                // �D��q�Ƀ��X�g�ɂ����index���Z�b�g
                                stockRow.SortDiv = index;
                            }
                            else
                            {
                                // �D��q�Ƀ��X�g�ɂȂ���΃��X�g��Count(�ő��index+1)
                                stockRow.SortDiv = _orgDataSet.ListPriorWarehouse.Count;
                            }
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD

                        _StockTable.AddStockRow(stockRow);
                        if (stockRows[j].SelectionState)
                        {
                            _partsInfo[i].Shelf = stockRow.WarehouseShelfNo;
                            _partsInfo[i].StockCnt = stockRow.ShipmentPosCnt;
                            _partsInfo[i].Warehouse = stockRow.WarehouseName;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                            _partsInfo[i].WarehouseCode = stockRow.WarehouseCode;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                            flgStock = true;
                        }
                    }
                }
                if (flgStock == false && _orgDataSet.ListPriorWarehouse != null)
                {
                    for (int j = 0; j < _orgDataSet.ListPriorWarehouse.Count; j++)
                    {
                        // 2009.02.16 >>>
                        //string warehouseCd = _orgDataSet.ListPriorWarehouse[j];
                        string warehouseCd = _orgDataSet.ListPriorWarehouse[j].Trim();
                        // 2009.02.16 <<<
                        for (int k = 0; k < stockRows.Length; k++)
                        {
                            if (stockRows[k].WarehouseCode.Equals(warehouseCd))
                            {
                                _partsInfo[i].Shelf = stockRows[k].WarehouseShelfNo;
                                _partsInfo[i].StockCnt = stockRows[k].ShipmentPosCnt;
                                _partsInfo[i].Warehouse = stockRows[k].WarehouseName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                                _partsInfo[i].WarehouseCode = stockRows[k].WarehouseCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                                flgStock = true;
                                break;
                            }
                        }
                        if (flgStock)
                            break;
                    }
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL // �D��q�ɂɂȂ���Ύ��ɂ���
                //if (flgStock == false && stockRows.Length > 0)
                //{
                //    _partsInfo[i].Shelf = stockRows[0].WarehouseShelfNo;
                //    _partsInfo[i].StockCnt = stockRows[0].ShipmentPosCnt;
                //    _partsInfo[i].Warehouse = stockRows[0].WarehouseName;
                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                //    _partsInfo[i].WarehouseCode = stockRows[0].WarehouseCode;
                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
                #endregion
            }
        }

        // 2009.02.10 Add >>>
        /// <summary>
        /// �Ώۃf�[�^�̉��i�ݒ�
        /// </summary>
        private void SettingPriceTargetData()
        {
            if (_orgDataSet.CalculateGoodsPrice == null) return;

            List<PartsInfoDataSet.GoodsPrimaryKey> goodsPrimaryKeyList = new List<PartsInfoDataSet.GoodsPrimaryKey>();

            foreach (PartsInfoDataSet.PartsInfoRow partsInfoRow in _orgDataSet.PartsInfo)
            {
                string catalogPartsNo = partsInfoRow.ClgPrtsNoWithHyphen;
                string newPartsNo = partsInfoRow.NewPrtsNoWithHyphen;
                // --- DEL m.suzuki 2011/02/01 ---------->>>>>
                //string partsNoInUse;
                // --- DEL m.suzuki 2011/02/01 ----------<<<<<
                int makerCd = partsInfoRow.CatalogPartsMakerCd;
                PartsInfoDataSet.UsrGoodsInfoRow row;
                // --- UPD m.suzuki 2011/02/01 ---------->>>>>
                # region // DEL
                //if (substFlg == 1 && CatalogPartsStockCheck(catalogPartsNo, makerCd))
                //{       // ��֏����F�݌ɔ���L�@���@�J�^���O�i�݌ɂ���̏ꍇ
                //    partsNoInUse = catalogPartsNo;  // ���i�E�݌ɁE�Z�b�g�����J�^���O�i�Ԃ���擾
                //    row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNoInUse);
                //}
                //else
                //{
                //    row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, catalogPartsNo);
                //    if (userSubstFlg != 0)
                //    {
                //        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst(row);
                //        if (rowSubst.Equals(row))
                //        {
                //            row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, newPartsNo);
                //            rowSubst = _orgDataSet.GetUsrSubst(row);
                //            if (rowSubst.Equals(row) == false) // �ŐV�i�ɑ΂��ă��[�U�[��ւ�����ꍇ
                //            {
                //                row = rowSubst;
                //            }
                //            else // ���[�U�[��ւ��Ȃ��ꍇ
                //            {
                //            }
                //        }
                //        else // �J�^���O�i�ɑ΂��ă��[�U�[��ւ�����ꍇ
                //        {
                //            row = rowSubst;
                //        }
                //    }
                //    else // ���[�U�[��ւ��Ȃ��ꍇ
                //    {
                //        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, newPartsNo);
                //    }
                //}
                //if (row != null)
                //{
                //    goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(row.GoodsNo, row.GoodsMakerCd));
                //}
                # endregion

                bool stockCountNotZero;
                if ( CatalogPartsStockCheck( catalogPartsNo, makerCd, out stockCountNotZero ) )
                {   
                    // �݌Ƀ��R�[�h����
                    if ( stockCountNotZero )
                    {
                        //------------------------------
                        // �݌ɂ���(�݌ɐ�>0) �� ��֌�
                        //------------------------------

                        // ��֌�
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( makerCd, catalogPartsNo );
                    }
                    else
                    {
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( makerCd, catalogPartsNo );

                        //------------------------------
                        // �݌Ƀ[�� �� ���[�U�[��ւ̂ݗL��
                        //------------------------------
                        // ���[�U�[��֋敪
                        // --- UPD 2011/07/25 ---- >>>>>
                        //if ( userSubstFlg != 0 )
                        //{
                        // --- ADD 2011/11/29 ---- >>>>>
                        if ( userSubstFlg != 0 )
                        {
                        // --- ADD 2011/11/29 ---- >>>>>
                            // ���[�U�[��֐�(������Α�֌�)
                            PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst( row );
                            row = rowSubst;
                        // --- ADD 2011/11/29 ---- >>>>>
                        }
                        else
                        {
                            // ��֌�
                        }
                        // --- ADD 2011/11/29 ---- <<<<<
                        //}
                        //else
                        //{
                        //    // ��֌�
                        //}
                        // --- UPD 2011/07/25 ---- <<<<<
                    }
                }
                else
                {
                    //------------------------------
                    // �݌Ƀ��R�[�h�Ȃ� �� ���[�U�[��ցE�񋟑��
                    //------------------------------
                    // ���[�U�[��֋敪
                    // --- UPD 2011/07/25 ---- >>>>>
                    //if ( userSubstFlg != 0 )
                    //{
                    // --- ADD 2011/11/29 ---- >>>>>
                    if ( userSubstFlg != 0 )
                    {
                    // --- ADD 2011/11/29 ---- <<<<<
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( makerCd, catalogPartsNo );

                        PartsInfoDataSet.UsrGoodsInfoRow rowSubst = _orgDataSet.GetUsrSubst( row );
                        if ( rowSubst.Equals( row ) )
                        {
                            row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( makerCd, newPartsNo );
                            rowSubst = _orgDataSet.GetUsrSubst( row );
                            if ( rowSubst.Equals( row ) == false ) // �ŐV�i�ɑ΂��ă��[�U�[��ւ�����ꍇ
                            {
                                row = rowSubst;
                            }
                            else // ���[�U�[��ւ��Ȃ��ꍇ
                            {
                            }
                        }
                        else // �J�^���O�i�ɑ΂��ă��[�U�[��ւ�����ꍇ
                        {
                            row = rowSubst;
                        }
                    // --- ADD 2011/11/29 ---- >>>>>
                    }
                    else
                    {
                        // �񋟑�֐�(������Α�֌�)
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, newPartsNo);
                    }
                    // --- ADD 2011/11/29 ---- <<<<<
                    //}
                    //else
                    //{
                    //    // �񋟑�֐�(������Α�֌�)
                    //    row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( makerCd, newPartsNo );
                    //}
                    // --- UPD 2011/07/25 ---- <<<<<
                }
                // --- UPD m.suzuki 2011/02/01 ----------<<<<<
                // --- ADD m.suzuki 2011/02/14 ---------->>>>>
                if ( row != null )
                {
                    // ���i�擾���X�g�ɒǉ�
                    goodsPrimaryKeyList.Add( new PartsInfoDataSet.GoodsPrimaryKey( row.GoodsNo, row.GoodsMakerCd ) );
                }
                // --- ADD m.suzuki 2011/02/14 ----------<<<<<
            }
            // ���i��񂪑��݂���ꍇ�͉��i�v�Z
            if (goodsPrimaryKeyList.Count > 0)
            {
                _orgDataSet.SettingGoodsPrice(goodsPrimaryKeyList);
            }

        }
        // 2009.02.10 Add <<<
        #endregion

        #region [ �t�H�[���C�x���g���� ]
        /// <summary>
        /// �_�C�A���O��\������B[���̉�ʂ��J�����O�ɑ�֏������������ꍇ��֌��i�Ԃ����֐�i�Ԃւ̐؂�ւ��������s��]
        /// </summary>
        /// <returns></returns>
        // 2009.02.19 >>>
        //public new DialogResult ShowDialog()
        public new DialogResult ShowDialog(IWin32Window owner)
        // 2009.02.19 <<<
        {
            // --- ADD 杍^ 2014/09/01 Redmine#43289 -------------------- >>>
            // Thread���A�ԗ������擾���܂�
            carInfoSolt = Thread.GetNamedDataSlot(CARINFOSOLT);
            string carInfoStr = string.Empty;
            // Thread���A�ԗ������擾�ł���ꍇ�A
            if (Thread.GetData(carInfoSolt) != null)
            {
                CarInfoThreadData carInfoThreadData = (CarInfoThreadData)Thread.GetData(carInfoSolt);


                // �ޕ�(PM�̏��)
                this.tNedit_ModelDesignationNo.SetInt(carInfoThreadData.ModelDesignationNo);
                // �ԍ�(PM�̏��)
                this.tNedit_CategoryNo.SetInt(carInfoThreadData.CategoryNo);
                // �ԑ�ԍ�(PM��SF�v�Z��̏��)
                this.tEdit_ProduceFrameNo.Text = carInfoThreadData.FrameNo;
                // VIN�R�[�h�u1:���Y,2:�O�ԁv
                if (carInfoThreadData.FrameNoKubun == 2)
                {
                    this.uLabel_ProduceFrameNoTitle.Text = "VIN�R�[�h";
                    this.uLabel_ProduceFrameNoTitle.Size = new Size(80, 24);
                    // --- DEL 2014/09/22 ���� �d�|�ꗗ ��10598 ------------------------------>>>>>
                    //this.tEdit_ProduceFrameNo.Size = new Size(147, 24);
                    // --- DEL 2014/09/22 ���� �d�|�ꗗ ��10598 ------------------------------<<<<<
                }
                else
                {
                    this.uLabel_ProduceFrameNoTitle.Text = "�ԑ�ԍ�";
                    this.uLabel_ProduceFrameNoTitle.Size = new Size(67, 24);
                    // --- DEL 2014/09/22 ���� �d�|�ꗗ ��10598 ------------------------------>>>>>
                    //this.tEdit_ProduceFrameNo.Size = new Size(76, 24);
                    // --- DEL 2014/09/22 ���� �d�|�ꗗ ��10598 ------------------------------<<<<<
                }
                // �N���敪(PM�̏��)�S�̏����l�ݒ�}�X�^�́u0:����@1:�a��i�N���j�v
                if (carInfoThreadData.FirstEntryDateKubun == 0)
                {
                    // ����
                    this.tEdit_Gango.Visible = false;
                    this.tNedit_Wareki_Year.Visible = false;
                    this.tNedit_Sereki_Year.Visible = true;

                    // ����
                    if (carInfoThreadData.FirstEntryDate != 0)
                    {
                        this.tNedit_Sereki_Year.SetInt(carInfoThreadData.FirstEntryDate / 100); // ����N
                        this.tNedit_Month.SetInt(carInfoThreadData.FirstEntryDate % 100);�@// ���
                    }
                }
                else
                {
                    // �a��
                    this.tEdit_Gango.Visible = true;
                    this.tNedit_Wareki_Year.Visible = true;
                    this.tNedit_Sereki_Year.Visible = false;

                    // �a��
                    if (carInfoThreadData.FirstEntryDate != 0)
                    {
                        this.tNedit_Wareki_Year.SetInt(GetDateFW(carInfoThreadData.FirstEntryDate * 100 + 1)); // �a��N
                        this.tEdit_Gango.Text = TDateTime.LongDateToString("GG", carInfoThreadData.FirstEntryDate * 100 + 1); // �a���
                        this.tNedit_Month.SetInt(carInfoThreadData.FirstEntryDate % 100); // �a�
                    }
                }

                // ���[�J�[(PM�̏��)
                this.tNedit_MakerCode.SetInt(carInfoThreadData.MakerCode);
                // �Ԏ�(PM�̏��)(PM�̏��)
                this.tNedit_ModelCode.SetInt(carInfoThreadData.ModelCode);
                // �Ԏ�T�u�R�[�h(PM�̏��)
                this.tNedit_ModelSubCode.SetInt(carInfoThreadData.ModelSubCode);
                // �Ԏ햼(PM�̏��)
                this.tEdit_ModelFullName.Text = carInfoThreadData.ModelFullName;
                // �^��(PM��SF�v�Z��̏��)
                this.tEdit_FullModel.Text = carInfoThreadData.FullModel;
                // ���l(PM��SF�v�Z��̏��)
                this.tEdit_Note.Text = carInfoThreadData.Note;
                // ��ʌ�
                this._pgid = carInfoThreadData.Pgid;
            }

            // �������ω�ʂ�XML�t�@�C����ǂ�
            if (this._pgid.Equals(PMMIT01010U_PGID))
            {
                bool carInfoFlg = Deserialize(PMMIT01010U_PMKEN08060U_CARINFOSELETED);
                this.pnl_CarInfo.Visible = carInfoFlg;
                this.SetPnlCarInfoVisible(carInfoFlg);
            }
            // ���`��ʂ�XML�t�@�C����ǂ�
            else if (this._pgid.Equals(MAHNB01001U_PGID))
            {
                bool carInfoFlg = Deserialize(MAHNB01001U_PMKEN08060U_CARINFOSELETED);
                this.pnl_CarInfo.Visible = carInfoFlg;
                this.SetPnlCarInfoVisible(carInfoFlg);
            }
            // --- ADD 杍^ 2014/09/01 Redmine#43289 -------------------- <<<

            #region [ �\������f�[�^��1�������Ȃ��Ƃ��̏����|�I�����I�� ]
            if ( gridPartsInfo.Rows.Count == 1
                && (substFlg == 0 || gridPartsInfo.Rows[0].Cells[_partsInfo.SubstColumn.ColumnName].Value.Equals( DBNull.Value )) )
            {
                int makerCd = (int)gridPartsInfo.Rows[0].Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value;
                // 2009/09/29 >>>
                //string goodsNo = gridPartsInfo.Rows[0].Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                // �������i�J�^���O���i�j�̃f�[�^���g�p����B
                string goodsNo = gridPartsInfo.Rows[0].Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString();
                // 2009/09/29 <<<
                SelectionInfo selInfo = new SelectionInfo();
                selInfo.Depth = 0;
                selInfo.Key = gridPartsInfo.Rows[0].ListIndex;
                selInfo.RowGoods = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, goodsNo);
                // 2009/09/29 Add >>>
                // �ŐV�i�Ԃ��Z�b�g
                selInfo.RowGoods.NewGoodsNo = gridPartsInfo.Rows[0].Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                // 2009/09/29 Add <<<
                // 2009/11/27 Add >>>
                selInfo.RowGoods.JoinSrcPrtsNo= gridPartsInfo.Rows[0].Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString();
                // 2009/11/27 Add <<<
                _orgDataSet.AddSelectionInfo(_orgDataSet.ListSelectionInfo, selInfo.Key, ref selInfo);
                isDialogShown = false;
                // --- ADD m.suzuki 2010/10/01 ---------->>>>>
                selInfo.ExtractSetParent = IsSetParent( gridPartsInfo.Rows[0] ); // �Z�b�g�e�Ȃ�true
                // --- ADD m.suzuki 2010/10/01 ----------<<<<<

                if (gridPartsInfo.Rows[0].Cells[_partsInfo.JoinColumn.ColumnName].Value.Equals(DBNull.Value)
                        && gridPartsInfo.Rows[0].Cells[_partsInfo.SetColumn.ColumnName].Value.Equals(DBNull.Value))
                {
                    selInfo.Selected = true;

                    // --- UPD m.suzuki 2010/06/24 ---------->>>>>
                    //string filter = string.Format("{0}={1} AND {2}='{3}' ",
                    //    _StockTable.GoodsMakerCdColumn.ColumnName, makerCd,
                    //    _StockTable.GoodsNoColumn.ColumnName, goodsNo);
                    // �ŐV�i�Ԃō݌ɂ��`�F�b�N����
                    string filter = string.Format( "{0}={1} AND {2}='{3}' ",
                        _StockTable.GoodsMakerCdColumn.ColumnName, makerCd,
                        _StockTable.GoodsNoColumn.ColumnName, selInfo.RowGoods.NewGoodsNo );
                    // --- UPD m.suzuki 2010/06/24 ----------<<<<<
                    _StockTable.DefaultView.RowFilter = filter;
                    if (_orgDataSet.ListPriorWarehouse != null) // �D��q�Ɏw�肠��
                    {
                        for (int i = 0; i < _orgDataSet.ListPriorWarehouse.Count; i++)
                        {
                            // 2009.02.16 >>>
                            //string warehouseCd = _orgDataSet.ListPriorWarehouse[i];
                            string warehouseCd = _orgDataSet.ListPriorWarehouse[i].Trim();
                            // 2009.02.16 <<<
                            for (int j = 0; j < _StockTable.DefaultView.Count; j++)
                            {
                                if (warehouseCd.Equals(_StockTable.DefaultView[j][_StockTable.WarehouseCodeColumn.ColumnName]))
                                {
                                    selInfo.WarehouseCode = warehouseCd;
                                    return DialogResult.OK;
                                }
                            }
                        }
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL // �D��q�ɂɂȂ��ꍇ�͎��ɂ���
                    //if (_StockTable.DefaultView.Count > 0)
                    //    selInfo.WarehouseCode = _StockTable.DefaultView[0][_StockTable.WarehouseCodeColumn.ColumnName].ToString();
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
                }
                else
                {
                    // 2009/12/14 �@�@Add >>>
                    if (_orgDataSet.ListPriorWarehouse != null) // �D��q�Ɏw�肠��
                    {
                        string orgFilter = _StockTable.DefaultView.RowFilter;
                        try
                        {
                            // --- UPD m.suzuki 2010/06/24 ---------->>>>>
                            //string filter = string.Format( "{0}={1} AND {2}='{3}' ",
                            //    _StockTable.GoodsMakerCdColumn.ColumnName, makerCd,
                            //    _StockTable.GoodsNoColumn.ColumnName, godsNo);
                            // �ŐV�i�Ԃō݌ɂ��`�F�b�N����
                            string filter = string.Format( "{0}={1} AND {2}='{3}' ",
                                _StockTable.GoodsMakerCdColumn.ColumnName, makerCd,
                                _StockTable.GoodsNoColumn.ColumnName, selInfo.RowGoods.NewGoodsNo );
                            // --- UPD m.suzuki 2010/06/24 ----------<<<<<
                            _StockTable.DefaultView.RowFilter = filter;
                            if (_StockTable.DefaultView.Count > 0)
                            {
                                for (int i = 0; i < _orgDataSet.ListPriorWarehouse.Count; i++)
                                {
                                    bool stockExist = false;    // 2010/12/20 Add
                                    string warehouseCd = _orgDataSet.ListPriorWarehouse[i].Trim();
                                    for (int j = 0; j < _StockTable.DefaultView.Count; j++)
                                    {
                                        if (warehouseCd.Equals(_StockTable.DefaultView[j][_StockTable.WarehouseCodeColumn.ColumnName]))
                                        {
                                            selInfo.WarehouseCode = warehouseCd;
                                            // 2010/12/20 Add >>>
                                            stockExist = true;
                                            break;
                                            // 2010/12/20 Add <<<
                                        }
                                    }
                                    if ( stockExist ) break; // 2010/12/20 Add
                                }
                            }
                        }
                        finally
                        {
                            _StockTable.DefaultView.RowFilter = orgFilter;
                        }
                    }
                    // 2009/12/14 �@�@Add <<<
                    if (uiControlFlg)
                    {
                        _orgDataSet.UsrGoodsInfo.RowToProcess = selInfo.RowGoods;
                        if (gridPartsInfo.Rows[0].Cells[_partsInfo.JoinColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                        {
                            _orgDataSet.JoinSrcSelInf = selInfo;
                            _orgDataSet.UIKind = SelectUIKind.Join;
                        }
                        else
                        {
                            _orgDataSet.SetSrcSelInf = selInfo;
                            _orgDataSet.UIKind = SelectUIKind.Set;
                        }
                        return DialogResult.Retry;
                    }
                    // 2009/12/14 �A�@>>>
                    //_orgDataSet.GoodsNoSel = gridPartsInfo.Rows[0].Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                    selInfo.SelectedPartsNo = gridPartsInfo.Rows[0].Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                    // 2009/12/14 �A�@<<<
                }

                return DialogResult.OK;
            }
            #endregion
            if (_prevRow != null && _prevRow.NewGoodsNo != string.Empty) //��ւ��ꂽ���i�����邩�`�F�b�N[NewGoodsNo:��֐�i��]
            {
                #region [ ��֑I��UI���Ə��� ]
                _orgDataSet.GoodsNoSel = string.Empty;
                string partsNo;
                UltraGridRow gridRow = gridPartsInfo.Rows.GetRowWithListIndex(_prevSelInfo.Key);
                // ��ւ���O�̑I������������E�Z�b�g�q���i���N���A
                _prevSelInfo.ListChildGoods.Clear();
                _prevSelInfo.ListChildGoods2.Clear();
                if (_prevSelInfo.ListPlrlSubst.Count > 0)
                    _prevSelInfo.ListPlrlSubst.RemoveAt(0); // 1�ڂ͑�֕i���Ȃ̂ō폜���Ă����B
                if (_prevRow.NewGoodsNo == _prevRow.GoodsNo) // ��֑I��UI�ő�ւƂ��đ�֌��i�Ԃ�I�񂾎��̏���
                {
                    _prevRow.NewGoodsNo = string.Empty;
                    gridRow.Cells[_partsInfo.OldPartsNoColumn.ColumnName].Value = gridRow.Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value;
                    gridRow.Cells[_partsInfo.SelectionStateColumn.ColumnName].Value = _prevRow.SelectionState;
                    gridRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value = _prevRow.GoodsNo;
                    gridRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value = _prevRow.GoodsNo;
                    partsNo = _prevRow.GoodsNo;
                    gridRow.Cells[_partsInfo.PartsNameColumn.ColumnName].Value = _prevRow.GoodsName;
                    if (totalAmountDispWay == 1) // ���z�\������i�ō��݁j
                    {
                        gridRow.Cells[_partsInfo.PriceColumn.ColumnName].Value = _prevRow.PriceTaxInc;
                        gridRow.Cells[_partsInfo.UrikaColumn.ColumnName].Value = _prevRow.SalesUnitPriceTaxInc;
                        gridRow.Cells[_partsInfo.GenkaColumn.ColumnName].Value = _prevRow.UnitCostTaxInc;
                    }
                    else // ���z�\�����Ȃ��i�Ŕ����j
                    {
                        gridRow.Cells[_partsInfo.PriceColumn.ColumnName].Value = _prevRow.PriceTaxExc;
                        gridRow.Cells[_partsInfo.UrikaColumn.ColumnName].Value = _prevRow.SalesUnitPriceTaxExc;
                        gridRow.Cells[_partsInfo.GenkaColumn.ColumnName].Value = _prevRow.UnitCostTaxExc;
                    }
                    // �e���z�E�e�����͋敪�֌W�Ȃ��Ŕ����Ōv�Z
                    gridRow.Cells[_partsInfo.ArarigakuColumn.ColumnName].Value = _prevRow.SalesUnitPriceTaxExc - _prevRow.UnitCostTaxExc;
                    if (_prevRow.UnitCostTaxExc != 0)
                        gridRow.Cells[_partsInfo.ArarirituColumn.ColumnName].Value = (_prevRow.SalesUnitPriceTaxExc - _prevRow.UnitCostTaxExc) / _prevRow.UnitCostTaxExc;

                    // --- UPD m.suzuki 2010/03/16 ---------->>>>>
                    //gridRow.Cells[_partsInfo.PartsQtyColumn.ColumnName].Value = ((_prevRow.QTY != 0) ? _prevRow.QTY : 1);
                    double partsQty = _prevRow.QTY;
                    if ( partsQty == 0 )
                    {
                        // ��֌��i�Ԃ��擾
                        string oldGoodsNo = string.Empty;
                        if ( gridRow.Cells[_partsInfo.OldPartsNoColumn.ColumnName].Value != null && gridRow.Cells[_partsInfo.OldPartsNoColumn.ColumnName].Value != DBNull.Value )
                        {
                            try
                            {
                                oldGoodsNo = (string)gridRow.Cells[_partsInfo.OldPartsNoColumn.ColumnName].Value;
                            }
                            catch
                            {
                                oldGoodsNo = string.Empty;
                            }
                        }
                        if ( !string.IsNullOrEmpty( oldGoodsNo ) )
                        {
                            // ��֌�Find
                            PartsInfoDataSet.PartsInfoRow rowPartsInfo =
                                _orgDataSet.PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen( _prevRow.GoodsMakerCd, oldGoodsNo );
                            if ( rowPartsInfo != null )
                            {
                                // ��֌���QTY�ŏ�������
                                partsQty = rowPartsInfo.PartsQty;
                            }
                        }
                    }
                    gridRow.Cells[_partsInfo.PartsQtyColumn.ColumnName].Value = ((partsQty != 0) ? partsQty : 1);
                    // --- UPD m.suzuki 2010/03/16 ----------<<<<<
                    gridRow.Cells[_partsInfo.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    gridRow.Cells[_partsInfo.SelectionStateColumn.ColumnName].Value = true;
                }
                else                                        // ��L�ȊO��ւ������̏���
                {
                    PartsInfoDataSet.UsrGoodsInfoRow newRow =
                            _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(_prevRow.GoodsMakerCd, _prevRow.NewGoodsNo);

                    gridRow.Cells[_partsInfo.OldPartsNoColumn.ColumnName].Value = gridRow.Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value;
                    gridRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value = newRow.GoodsNo;
                    gridRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value = newRow.GoodsNo;
                    partsNo = newRow.GoodsNo;
                    gridRow.Cells[_partsInfo.PartsNameColumn.ColumnName].Value = newRow.GoodsName;
                    if (totalAmountDispWay == 1) // ���z�\������i�ō��݁j
                    {
                        gridRow.Cells[_partsInfo.PriceColumn.ColumnName].Value = newRow.PriceTaxInc;
                        gridRow.Cells[_partsInfo.UrikaColumn.ColumnName].Value = newRow.SalesUnitPriceTaxInc;
                        gridRow.Cells[_partsInfo.GenkaColumn.ColumnName].Value = newRow.UnitCostTaxInc;
                    }
                    else // ���z�\�����Ȃ��i�Ŕ����j
                    {
                        gridRow.Cells[_partsInfo.PriceColumn.ColumnName].Value = _prevRow.PriceTaxExc;
                        gridRow.Cells[_partsInfo.UrikaColumn.ColumnName].Value = _prevRow.SalesUnitPriceTaxExc;
                        gridRow.Cells[_partsInfo.GenkaColumn.ColumnName].Value = _prevRow.UnitCostTaxExc;
                    }
                    // �e���z�E�e�����͋敪�֌W�Ȃ��Ŕ����Ōv�Z
                    gridRow.Cells[_partsInfo.ArarigakuColumn.ColumnName].Value = _prevRow.SalesUnitPriceTaxExc - _prevRow.UnitCostTaxExc;
                    if (_prevRow.UnitCostTaxExc != 0)
                        gridRow.Cells[_partsInfo.ArarirituColumn.ColumnName].Value = (_prevRow.SalesUnitPriceTaxExc - _prevRow.UnitCostTaxExc) / _prevRow.UnitCostTaxExc;

                    PartsInfoDataSet.PartsInfoRow rowPartsInfo =
                        _orgDataSet.PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(newRow.GoodsMakerCd, newRow.GoodsNo);
                    if (rowPartsInfo != null)
                    {
                        gridRow.Cells[_partsInfo.PartsQtyColumn.ColumnName].Value = ((rowPartsInfo.PartsQty != 0) ? rowPartsInfo.PartsQty : 1);
                    }
                    gridRow.Cells[_partsInfo.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    gridRow.Cells[_partsInfo.SelectionStateColumn.ColumnName].Value = true;
                    _prevRow.NewGoodsNo = string.Empty;
                }
                if (SetExists(partsNo, catalogMakerCd))
                {
                    gridRow.Cells[_partsInfo.SetColumn.ColumnName].Value = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
                }
                else
                {
                    gridRow.Cells[_partsInfo.SetColumn.ColumnName].Value = DBNull.Value;
                }
                string primePartsNo;
                if (JoinExists(partsNo, catalogMakerCd, out primePartsNo))
                {
                    gridRow.Cells[_partsInfo.JoinColumn.ColumnName].Value = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARCHANGE];
                    gridRow.Cells[_partsInfo.PrimePartsNoColumn.ColumnName].Value = primePartsNo;
                }
                else
                {
                    gridRow.Cells[_partsInfo.JoinColumn.ColumnName].Value = DBNull.Value;
                    gridRow.Cells[_partsInfo.PrimePartsNoColumn.ColumnName].Value = string.Empty;
                }
                _prevRow.NewGoodsNo = string.Empty;
                _prevRow = null;
                SelectionInfo selInfo = _prevSelInfo;
                if (selInfo != null)
                {
                    UltraGridRow row = gridPartsInfo.Rows.GetRowWithListIndex(selInfo.Key);
                    row.Cells[_partsInfo.WarehouseCodeColumn.ColumnName].Value = selInfo.WarehouseCode;
                }
                _partsInfo.AcceptChanges();
                #endregion
            }
            else // ��֑I��UI�ȊO�̉�ʂ���̑J�ڂ̏ꍇ�̍X�V�������s���B
            {
                //_orgRow = _orgDataSet.UsrGoodsInfo.RowToProcess;
                SelectionInfo selInfo = _prevSelInfo;
                if (selInfo != null)
                {
                    UltraGridRow row = gridPartsInfo.Rows.GetRowWithListIndex(selInfo.Key);

                    row.Cells[_partsInfo.SelectionStateColumn.ColumnName].Value = selInfo.Selected;
                    row.Cells[_partsInfo.WarehouseCodeColumn.ColumnName].Value = selInfo.WarehouseCode;
                    if (selInfo.Selected)
                    {
                        row.Cells[_partsInfo.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    }
                    else
                    {
                        row.Cells[_partsInfo.SelImageColumn.ColumnName].Value = DBNull.Value;
                    }
                }
            }
            // �݌ɕ\���X�V
            gridPartsInfo_AfterSelectChange(this, null);

            isUserClose = true; // �~�{�^������t���O�@���Z�b�g

            if (gridPartsInfo.Selected.Rows.Count > 0)
            {
                gridPartsInfo.Selected.Rows[0].Activated = true;
                int makerCd;
                string goodsNo;
                if (gridPartsInfo.Selected.Rows[0].Band.ParentBand == null)
                {
                    makerCd = (int)gridPartsInfo.Selected.Rows[0].Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value;
                    goodsNo = gridPartsInfo.Selected.Rows[0].Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                    //goodsNo = gridPartsInfo.Selected.Rows[0].Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString();
                    PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, goodsNo);

                    if (row.SelectionComplete)
                    {
                        gridPartsInfo.Selected.Rows[0].Cells[_partsInfo.SelImageColumn.ColumnName].Appearance.BackColor = Color.DarkKhaki;
                        gridPartsInfo.Selected.Rows[0].Cells[_partsInfo.SelImageColumn.ColumnName].SelectedAppearance.BackColor = Color.DarkKhaki;
                        gridPartsInfo.Selected.Rows[0].Cells[_partsInfo.SelImageColumn.ColumnName].SelectedAppearance.BackColor2 = Color.DarkKhaki;
                    }
                    else
                    {
                        gridPartsInfo.Selected.Rows[0].Cells[_partsInfo.SelImageColumn.ColumnName].Appearance.ResetBackColor();
                        gridPartsInfo.Selected.Rows[0].Cells[_partsInfo.SelImageColumn.ColumnName].SelectedAppearance.ResetBackColor();
                        gridPartsInfo.Selected.Rows[0].Cells[_partsInfo.SelImageColumn.ColumnName].SelectedAppearance.ResetBackColor2();
                    }
                }
            }
            else
            {
                gridPartsInfo.Rows[0].Activate();
                gridPartsInfo.Rows[0].Selected = true;
            }
            // 2009.02.19 >>>
            //return base.ShowDialog();
            return base.ShowDialog(owner);
            // 2009.02.19 <<<
        }

        // --- ADD m.suzuki 2010/10/01 ---------->>>>>
        /// <summary>
        /// �Z�b�g�e���菈��
        /// </summary>
        /// <param name="ultraGridRow"></param>
        /// <returns>true: �Z�b�g�e, false: �Z�b�g�e�ł͂Ȃ�</returns>
        private bool IsSetParent( UltraGridRow ultraGridRow )
        {
            string goodsNo = ultraGridRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString();
            int makerCd = (int)ultraGridRow.Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value;

            //----------------------------------------
            // GoodsSet
            //----------------------------------------
            DataRow[] rows;
            rows = _orgDataSet.GoodsSet.Select( string.Format( "{0}='{1}' AND {2}='{3}' ",
                                                                _orgDataSet.GoodsSet.SetMainPartsNoColumn.ColumnName, goodsNo,
                                                                _orgDataSet.GoodsSet.SetMainMakerCdColumn.ColumnName, makerCd ) );
            if ( rows.Length > 0 ) return true;
            
            //----------------------------------------
            // UsrSetParts
            //----------------------------------------
            rows = _orgDataSet.UsrSetParts.Select( string.Format( "{0}='{1}' AND {2}='{3}' ",
                                                                _orgDataSet.UsrSetParts.ParentGoodsNoColumn.ColumnName, goodsNo,
                                                                _orgDataSet.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, makerCd ) );
            if ( rows.Length > 0 ) return true;

            // �Z�b�g�e�ł͂Ȃ�
            return false;
        }
        // --- ADD m.suzuki 2010/10/01 ----------<<<<<

        /// <summary>
        /// FormClosing �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>�s���̎��Ԃ�����邽�߁A�T�u�X���b�h�̎��s���͏I���ł��Ȃ��悤�ɂ���</br>
        /// </remarks>
        private void SelectionParts_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (uiControlFlg && e.CloseReason == CloseReason.UserClosing && isUserClose) // PM.NS������ �� �~�{�^������
            //{
            //    if (TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Text, "�I��UI���I�����܂����H", 0, MessageBoxButtons.YesNo)
            //        == DialogResult.Yes)
            //    {
            //        this.DialogResult = DialogResult.Abort;
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //    }
            //}
        }

        /// <summary>
        /// FormClosed �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>DialogResult��OK�̏ꍇ�ɂ̂݁A�O���b�h��őI������Ă���s�Ɋ֘A����DataRow�I�u�W�F�N�g���擾���A</br>
        /// <br>"�I�����"�ɑ������鏈�����s���܂��B</br>
        /// </remarks>
        private void SelectionParts_FormClosed(object sender, FormClosedEventArgs e)
        {

            // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- >>>
            bool carInfoFlg = this.pnl_CarInfo.Visible;

            if (this._pgid.Equals(PMMIT01010U_PGID))
            {
                Serialize(carInfoFlg, PMMIT01010U_PMKEN08060U_CARINFOSELETED);
            }
            else if (this._pgid.Equals(MAHNB01001U_PGID))
            {
                Serialize(carInfoFlg, MAHNB01001U_PMKEN08060U_CARINFOSELETED);
            }
            // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- <<<

            if (this.DialogResult == DialogResult.Cancel)
            {
                return;
            }
            int cnt = gridPartsInfo.Rows.Count;
            for (int i = 0; i < cnt; i++)
            {
                PartsInfoDataSet.UsrGoodsInfoRow row = null;
                UltraGridRow gridRow = gridPartsInfo.Rows[i];

                if (gridRow.Cells[_partsInfo.SelectionStateColumn.ColumnName].Value.Equals(true))
                {
                    SelectionInfo selInfo = null;
                    if (gridRow.Cells[_partsInfo.UsrSubstColumn.ColumnName].Value.Equals(true)) // ���[�U�[��ւ��ꂽ�ꍇ
                    {
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo((int)gridRow.Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value,
                                gridRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString());
                        if (row != null)
                        {
                            selInfo = new SelectionInfo();
                            selInfo.Depth = 0;
                            selInfo.Key = gridRow.ListIndex;
                            selInfo.RowGoods = row;
                            row.JoinSrcPrtsNo = gridRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString();
                            selInfo.WarehouseCode = gridRow.Cells[_partsInfo.WarehouseCodeColumn.ColumnName].Value.ToString();
                            if (gridRow.Cells[_partsInfo.SelImageColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                            {
                                if (uiControlFlg)
                                    selInfo.Selected = true;
                                else if (gridPartsInfo.ActiveRow != null && i == gridPartsInfo.ActiveRow.Index
                                        && _orgDataSet.UIKind == SelectUIKind.Subst)
                                    selInfo.Selected = true;
                            }
                            else
                                selInfo.Selected = false;
                            _orgDataSet.AddSelectionInfo(_orgDataSet.ListSelectionInfo, selInfo.Key, ref selInfo);
                            if (gridPartsInfo.ActiveRow != null && i == gridPartsInfo.ActiveRow.Index)
                            {
                                switch (_orgDataSet.UIKind)
                                {
                                    case SelectUIKind.Join:
                                        _orgDataSet.JoinSrcSelInf = selInfo;
                                        // 2009/12/14 �A�@>>>
                                        //_orgDataSet.GoodsNoSel = gridRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                                        selInfo.SelectedPartsNo = gridRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                                        // 2009/12/14 �A�@<<<
                                        break;
                                    case SelectUIKind.Set:
                                        _orgDataSet.SetSrcSelInf = selInfo;
                                        break;
                                    case SelectUIKind.Subst:
                                        _orgDataSet.SubstSrcSelInf = selInfo;
                                        break;
                                }
                                _prevSelInfo = selInfo;
                            }
                        }
                    }
                    else // �ʏ�P�[�X
                    {
                        row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo((int)gridRow.Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value,
                                gridRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString());
                        if (row != null)
                        {
                            selInfo = new SelectionInfo();
                            selInfo.Depth = 0;
                            selInfo.Key = gridRow.ListIndex;
                            selInfo.RowGoods = row;
                            row.JoinSrcPrtsNo = gridRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString();
                            selInfo.WarehouseCode = gridRow.Cells[_partsInfo.WarehouseCodeColumn.ColumnName].Value.ToString();
                            if (gridRow.Cells[_partsInfo.SelImageColumn.ColumnName].Value.Equals(DBNull.Value) == false)
                            {
                                if (uiControlFlg)
                                    selInfo.Selected = true;
                                else if (gridPartsInfo.ActiveRow != null && i == gridPartsInfo.ActiveRow.Index
                                        && _orgDataSet.UIKind == SelectUIKind.Subst)
                                    selInfo.Selected = true;
                            }
                            else
                                selInfo.Selected = false;
                            _orgDataSet.AddSelectionInfo(_orgDataSet.ListSelectionInfo, selInfo.Key, ref selInfo);
                            if (gridPartsInfo.ActiveRow != null && i == gridPartsInfo.ActiveRow.Index)
                            {
                                switch (_orgDataSet.UIKind)
                                {
                                    case SelectUIKind.Join:
                                        _orgDataSet.JoinSrcSelInf = selInfo;
                                        // 2009/12/14 �A�@>>>
                                        //_orgDataSet.GoodsNoSel = gridRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                                        selInfo.SelectedPartsNo = gridRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                                        // 2009/12/14 �A�@<<<
                                        break;
                                    case SelectUIKind.Set:
                                        _orgDataSet.SetSrcSelInf = selInfo;
                                        break;
                                    case SelectUIKind.Subst:
                                        _orgDataSet.SubstSrcSelInf = selInfo;
                                        break;
                                }
                                _prevSelInfo = selInfo;
                            }
                            if (substFlg == 1 && gridRow.Cells[_partsInfo.StockCntColumn.ColumnName].Value.Equals(0) // �݌ɂ��Ȃ��Ƃ��͕��ʂ̑�֏��������邽�ߍ݌ɐ��`�F�b�N
                                && gridRow.Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value.Equals(gridRow.Cells[_partsInfo.NewPrtsNoWithHyphenColumn.ColumnName].Value) == false)
                            {   // ��֏����敪���݌ɔ���L���݌ɂ��聕�J�^���O�i�Ԃ��ŐV�i�ԂƈقȂ�Ƃ�
                                row.NewGoodsNo = _partsInfo[i].PartsNo;  // �݌ɗL���ɂ�蔻�肳�ꂽ�i�Ԃɑ�ւ���B
                            }
                            else if (_orgDataSet.UIKind != SelectUIKind.Subst &&
                                gridRow.Cells[_partsInfo.NewPrtsNoWithHyphenColumn.ColumnName].Value.Equals(gridRow.Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value) == false)
                            {
                                // �������i�Ԃ̐ݒ�
                                if (gridRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.Equals(gridRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value))
                                {   // ��֑I��UI�ő�ւ����ꍇ
                                    row.NewGoodsNo = gridRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                                }
                                else
                                {
                                    row.NewGoodsNo = gridRow.Cells[_partsInfo.NewPrtsNoWithHyphenColumn.ColumnName].Value.ToString();
                                }
                                row.QTY = (double)gridRow.Cells[_partsInfo.PartsQtyColumn.ColumnName].Value;
                            }
                        }
                    }
                    // 2009/12/14 �A�@>>>
                    //if (uiControlFlg == false && string.IsNullOrEmpty(_orgDataSet.GoodsNoSel)) // PM7����Ō�����ʗp�i�Ԃ����ݒ�H
                    if (uiControlFlg == false && string.IsNullOrEmpty(selInfo.SelectedPartsNo)) // PM7����Ō�����ʗp�i�Ԃ����ݒ�H
                    // 2009/12/14 �A�@<<<
                    {
                        // 2009/12/14 �A�@>>>
                        //_orgDataSet.GoodsNoSel = gridPartsInfo.Rows.GetRowWithListIndex(selInfo.Key).Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString(); //selInfo.RowGoods.NewGoodsNo;
                        selInfo.SelectedPartsNo = gridPartsInfo.Rows.GetRowWithListIndex(selInfo.Key).Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                        // 2009/12/14 �A�@<<<
                    }
                }
                else
                {
                    _orgDataSet.RemoveSelectionInfo(_orgDataSet.ListSelectionInfo, gridRow.ListIndex);
                }
                if (row != null)
                {
                    row.GoodsKindResolved = (int)GoodsKind.Parent;
                    // 2009.02.19 Add >>>
                    if (!string.IsNullOrEmpty(row.NewGoodsNo) && row.NewGoodsNo != row.GoodsNo)
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow rowToProcess = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(row.GoodsMakerCd,row.NewGoodsNo);
                        if (rowToProcess !=null)
                        {
                            rowToProcess.GoodsKindResolved = (int)GoodsKind.Parent;
                        }
                    }
                    // 2009.02.19 Add <<<
                }
            }
            if (cmbColor.Value != null)
            {
                string filter = string.Format("{0}='{1}'", _orgCar.ColorCdInfo.ColorCodeColumn.ColumnName, cmbColor.Value);
                PMKEN01010E.ColorCdInfoRow[] colorRows = (PMKEN01010E.ColorCdInfoRow[])_orgCar.ColorCdInfo.Select(filter);
                if (colorRows.Length > 0)
                {
                    colorRows[0].SelectionState = true;
                }
            }
            if (cmbTrim.Value != null)
            {
                string filter = string.Format("{0}='{1}'", _orgCar.TrimCdInfo.TrimCodeColumn.ColumnName, cmbTrim.Value);
                PMKEN01010E.TrimCdInfoRow[] trimRows = (PMKEN01010E.TrimCdInfoRow[])_orgCar.TrimCdInfo.Select(filter);
                if (trimRows.Length > 0)
                {
                    trimRows[0].SelectionState = true;
                }
            }
        }

        private void SelectionParts_Shown(object sender, EventArgs e)
        {
            // �擪�s��I����Ԃɂ���
            if (gridPartsInfo.Focused == false)
            {
                gridPartsInfo.Focus();
                if (gridPartsInfo.Selected.Rows.Count > 0)
                {
                    gridPartsInfo.Selected.Rows[0].Activate();
                }
                else
                {
                    gridPartsInfo.Rows[0].Activate();
                    gridPartsInfo.Rows[0].Selected = true;
                }
            }
        }

        /// <summary>
        /// ESC�L�[�����ɂ��I������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionParts_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    isUserClose = false;
                    break;

                case Keys.Back:
                    int rowNo;
                    if (rowNoInput.Length > 1)
                    {
                        rowNoInput = rowNoInput.Remove(rowNoInput.Length - 1);
                        rowNo = int.Parse(rowNoInput);
                    }
                    else
                    {
                        rowNoInput = string.Empty;
                        rowNo = 1;
                    }
                    gridPartsInfo.Rows[rowNo - 1].Activate();
                    gridPartsInfo.Rows[rowNo - 1].Selected = true;
                    break;

                case Keys.Delete:
                    rowNoInput = string.Empty;
                    gridPartsInfo.Rows[0].Activate();
                    gridPartsInfo.Rows[0].Selected = true;
                    break;
            }
        }

        private void SelectionParts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                string strRowNo = rowNoInput + e.KeyChar.ToString();

                int rowNo = int.Parse(strRowNo);
                if (rowNo > 0 && rowNo <= gridPartsInfo.Rows.VisibleRowCount)
                {
                    rowNoInput = strRowNo;
                }
                else
                {
                    if (e.KeyChar.Equals('0') == false)
                    {
                        rowNoInput = e.KeyChar.ToString();
                    }
                    rowNo = int.Parse(rowNoInput);
                    if (rowNo > gridPartsInfo.Rows.VisibleRowCount)
                    {
                        rowNoInput = string.Empty;
                        rowNo = 1;
                    }
                }
                if (gridPartsInfo.Focused == false)
                    gridPartsInfo.Select();
                gridPartsInfo.Rows[rowNo - 1].Activate();
                gridPartsInfo.Rows[rowNo - 1].Selected = true;
            }
        }
        #endregion

        #region [ �`�F�b�N���� ]
        /// <summary>
        /// �J�^���O�i�Ԃ̌��݌ɐ��`�F�b�N
        /// </summary>
        /// <param name="parts">�i��</param>
        /// <param name="maker">���[�J�[</param>
        /// <returns>true:���݌ɐ�����@false:���݌ɂȂ�</returns>
        internal bool CatalogPartsStockCheck(string parts, int maker)
        {
            bool ret = false;
            string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        _orgDataSet.Stock.GoodsNoColumn.ColumnName, parts,
                        _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, maker);
            PartsInfoDataSet.StockRow[] rowStock = (PartsInfoDataSet.StockRow[])_orgDataSet.Stock.Select(rowFilter);
            if (rowStock.Length > 0) // ���͉��L�̃R�����g���ꂽ�����������Ɛ������Ǝv���邪�APM7�ɍ��킹���ق���
                ret = true;          // �����Ƃ������Ƃɂ�肱�̏����ɂ���B
            //for (int i = 0; i < rowStock.Length; i++)
            //{
            //    if (rowStock[i].ShipmentPosCnt > 0)
            //    {
            //        ret = true;
            //        break;
            //    }
            //}
            return ret;
        }
        // --- ADD m.suzuki 2011/02/01 ---------->>>>>
        /// <summary>
        /// �J�^���O�i�Ԃ̌��݌ɐ��`�F�b�N(2)
        /// </summary>
        /// <param name="parts">�i��</param>
        /// <param name="maker">���[�J�[</param>
        /// <param name="stockCountNotZero"></param>
        /// <returns>true:���݌ɐ�����@false:���݌ɂȂ�</returns>
        /// <br>Update Note: 2011/07/25�@杍^�@�A��No.702�̑Ή�</br>
        /// <br>             ��ւ���i�݌ɖ��j�̏ꍇ�A�݌ɐ����P�ł̏����ɂ��ė~�����B�i�ԓ��͂̏ꍇ���A�݌ɏ������Q�Ƃ��ė~����</br>
        internal bool CatalogPartsStockCheck( string parts, int maker, out bool stockCountNotZero )
        {
            bool ret = false;
            stockCountNotZero = false;

            // --- ADD m.suzuki 2011/02/09 ---------->>>>>
            if ( _orgDataSet.ListPriorWarehouse == null ||
                 _orgDataSet.ListPriorWarehouse.Count == 0 )
            {
                return false;
            }
            // --- ADD m.suzuki 2011/02/09 ----------<<<<<
            // --- ADD m.suzuki 2011/02/18 ---------->>>>>
            bool settingFlag = false;
            foreach ( string warehouseCd in _orgDataSet.ListPriorWarehouse )
            {
                if ( !string.IsNullOrEmpty( warehouseCd ) )
                {
                    settingFlag = true;
                    break;
                }
            }
            if ( settingFlag == false )
            {
                return false;
            }
            // --- ADD m.suzuki 2011/02/18 ----------<<<<<
            string rowFilter = String.Format( "{0}='{1}' AND {2}={3}",
                        _orgDataSet.Stock.GoodsNoColumn.ColumnName, parts,
                        _orgDataSet.Stock.GoodsMakerCdColumn.ColumnName, maker );
            // --- ADD m.suzuki 2011/02/09 ---------->>>>>
            rowFilter += " AND (";
            foreach ( string priorWarehouse in _orgDataSet.ListPriorWarehouse )
            {
                if ( string.IsNullOrEmpty( priorWarehouse ) ) continue;
                rowFilter += string.Format( " {0}='{1}' OR", _orgDataSet.Stock.WarehouseCodeColumn.ColumnName, priorWarehouse );
            }
            rowFilter = rowFilter.Remove( rowFilter.Length - 2, 2 );
            rowFilter += ")";
            // --- ADD m.suzuki 2011/02/09 ----------<<<<<
            PartsInfoDataSet.StockRow[] rowStock = (PartsInfoDataSet.StockRow[])_orgDataSet.Stock.Select( rowFilter );

            if ( rowStock.Length > 0 )
            {
                // �݌Ƀ��R�[�h����
                //ret = true;   // DEL 2011/07/25

                // �݌ɐ�>0�̃��R�[�h�L���𔻒�
                for ( int i = 0; i < rowStock.Length; i++ )
                {
                    if ( rowStock[i].ShipmentPosCnt > 0 )
                    {
                        // �݌ɐ�>0�̍݌ɂ����݂���
                        stockCountNotZero = true;
                        // �݌Ƀ��R�[�h����
                        ret = true;   // ADD 2011/07/25
                        break;
                    }
                }
            }

            return ret;
        }
        // --- ADD m.suzuki 2011/02/01 ----------<<<<<

        internal bool SubstExists(string parts, int maker)
        {
            // --- UPD m.suzuki 2011/02/01 ---------->>>>>
            # region // DEL
            //if (substFlg == 0) // �u��ւ��Ȃ��v�̎��͖�����false
            //    return false;
            //string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4} = true", // ��֑I��UI�ɂ͒񋟂̂ݕ\��
            //    _orgDataSet.UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, parts,
            //    _orgDataSet.UsrSubstParts.ChgSrcMakerCdColumn.ColumnName, maker, _orgDataSet.UsrSubstParts.OfferKubunColumn.ColumnName);
            //if (_orgDataSet.UsrSubstParts.Select(rowFilter).Length > 0)
            //{
            //    if (substFlg == 2) // �u�݌ɔ���Ȃ��v�̎��́@��ւ����邾����true
            //    {
            //        return true;
            //    }
            //    else // �u�݌ɔ��肠��v�̎��͑�ւ��芎��֌��i�̌��݌ɐ��Ȃ��̎��̂�true
            //    {
            //        if (CatalogPartsStockCheck(parts, maker) == false) // ���݌ɂȂ��Ȃ�u�݌ɔ���L�v�ł���։�
            //        {
            //            return true;
            //        }
            //    }
            //}
            //return false;
            # endregion

            // ������֋敪���u2:��ւ���(�݌ɖ���)�v
            if ( substFlg == 2 )
            {
                // ��ւ����TRUE
                string rowFilter = String.Format( "{0}='{1}' AND {2}={3} AND {4} = true", // ��֑I��UI�ɂ͒񋟂̂ݕ\��
                    _orgDataSet.UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, parts,
                    _orgDataSet.UsrSubstParts.ChgSrcMakerCdColumn.ColumnName, maker, _orgDataSet.UsrSubstParts.OfferKubunColumn.ColumnName );
                if ( _orgDataSet.UsrSubstParts.Select( rowFilter ).Length > 0 )
                {
                    return true;
                }
            }
            return false;
            // --- UPD m.suzuki 2011/02/01 ----------<<<<<
        }

        internal bool SetExists(string parts, int maker)
        {
            string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4}=true",
                _orgDataSet.UsrSetParts.ParentGoodsNoColumn.ColumnName, parts,
                _orgDataSet.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, maker,
                _orgDataSet.UsrSetParts.PrmSettingFlgColumn.ColumnName);

            if (_orgDataSet.UsrSetParts.Select(rowFilter).Length > 0)
                return true;
            return false;
        }

        internal bool JoinExists(string parts, int maker, out string primePartsNo)
        {
            primePartsNo = string.Empty;
            string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4}=true",
                _orgDataSet.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, parts,
                _orgDataSet.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, maker,
                _orgDataSet.UsrJoinParts.PrmSettingFlgColumn.ColumnName);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/18 DEL
            //PartsInfoDataSet.UsrJoinPartsRow[] rows = (PartsInfoDataSet.UsrJoinPartsRow[])_orgDataSet.UsrJoinParts.Select( rowFilter );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/18 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/18 ADD
            string sortString = String.Format( "{0}",
                _orgDataSet.UsrJoinParts.JoinDispOrderColumn
                );
            PartsInfoDataSet.UsrJoinPartsRow[] rows = (PartsInfoDataSet.UsrJoinPartsRow[])_orgDataSet.UsrJoinParts.Select( rowFilter, sortString );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/18 ADD
            if (rows.Length > 0)
            {
                primePartsNo = rows[0].JoinDestPartsNo;
                return true;
            }
            return false;
        }

        internal bool JoinExists(string parts, int maker)
        {
            string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4}=true",
                _orgDataSet.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, parts,
                _orgDataSet.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, maker,
                _orgDataSet.UsrJoinParts.PrmSettingFlgColumn.ColumnName);
            if (_orgDataSet.UsrJoinParts.Select(rowFilter).Length > 0)
                return true;
            return false;
        }

        #endregion
        /*---------------------------------------------------------------------------*/

        private List<String> SetAddCarSpecColumn(UltraGridBand band)
        {
            //UltraGridBand band0 = gridPartsInfo.DisplayLayout.Bands[0];
            //UltraGridBand band = gridPartsInfo.DisplayLayout.Bands[1];
            List<String> ret = new List<string>();
            //�ǉ������̕\���ݒ�i�擪���\���̏ꍇ�S�ĕ\������j
            if (_modelPartsDetail[0].AddiCarSpec1 == string.Empty)
            {
                //band0.Columns[_partsInfo.AddiCarSpec1Column.ColumnName].Hidden = true;
                band.Columns[_modelPartsDetail.AddiCarSpec1Column.ColumnName].Hidden = true;
            }
            else
            {
                ret.Add(_modelPartsDetail.AddiCarSpec1Column.ColumnName);
                band.Columns[_modelPartsDetail.AddiCarSpec1Column.ColumnName].Header.Caption = _orgDataSet.ModelPartsDetail.AddiCarSpec1Column.Caption;
            }
            if (_modelPartsDetail[0].AddiCarSpec2 == string.Empty)
            {
                //band0.Columns[_partsInfo.AddiCarSpec2Column.ColumnName].Hidden = true;
                band.Columns[_modelPartsDetail.AddiCarSpec2Column.ColumnName].Hidden = true;
            }
            else
            {
                ret.Add(_modelPartsDetail.AddiCarSpec2Column.ColumnName);
                band.Columns[_modelPartsDetail.AddiCarSpec2Column.ColumnName].Header.Caption = _orgDataSet.ModelPartsDetail.AddiCarSpec2Column.Caption;
            }
            if (_modelPartsDetail[0].AddiCarSpec3 == string.Empty)
            {
                //band0.Columns[_partsInfo.AddiCarSpec3Column.ColumnName].Hidden = true;
                band.Columns[_modelPartsDetail.AddiCarSpec3Column.ColumnName].Hidden = true;
            }
            else
            {
                ret.Add(_modelPartsDetail.AddiCarSpec3Column.ColumnName);
                band.Columns[_modelPartsDetail.AddiCarSpec3Column.ColumnName].Header.Caption = _orgDataSet.ModelPartsDetail.AddiCarSpec3Column.Caption;
            }
            if (_modelPartsDetail[0].AddiCarSpec4 == string.Empty)
            {
                //band0.Columns[_partsInfo.AddiCarSpec4Column.ColumnName].Hidden = true;
                band.Columns[_modelPartsDetail.AddiCarSpec4Column.ColumnName].Hidden = true;
            }
            else
            {
                ret.Add(_modelPartsDetail.AddiCarSpec4Column.ColumnName);
                band.Columns[_modelPartsDetail.AddiCarSpec4Column.ColumnName].Header.Caption = _orgDataSet.ModelPartsDetail.AddiCarSpec4Column.Caption;
            }
            if (_modelPartsDetail[0].AddiCarSpec5 == string.Empty)
            {
                //band0.Columns[_partsInfo.AddiCarSpec5Column.ColumnName].Hidden = true;
                band.Columns[_modelPartsDetail.AddiCarSpec5Column.ColumnName].Hidden = true;
            }
            else
            {
                ret.Add(_modelPartsDetail.AddiCarSpec5Column.ColumnName);
                band.Columns[_modelPartsDetail.AddiCarSpec5Column.ColumnName].Header.Caption = _orgDataSet.ModelPartsDetail.AddiCarSpec5Column.Caption;
            }
            if (_modelPartsDetail[0].AddiCarSpec6 == string.Empty)
            {
                //band0.Columns[_partsInfo.AddiCarSpec6Column.ColumnName].Hidden = true;
                band.Columns[_modelPartsDetail.AddiCarSpec6Column.ColumnName].Hidden = true;
            }
            else
            {
                ret.Add(_modelPartsDetail.AddiCarSpec6Column.ColumnName);
                band.Columns[_modelPartsDetail.AddiCarSpec6Column.ColumnName].Header.Caption = _orgDataSet.ModelPartsDetail.AddiCarSpec6Column.Caption;
            }
            return ret;
        }

        internal static class ColInfo
        {
            public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int width)
            {
                System.Drawing.Size sizeHeader = new Size();
                System.Drawing.Size sizeCell = new Size();

                Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
                Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

                Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
                Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
                Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;

                sizeCell.Height = 24;
                sizeCell.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                sizeHeader.Height = 20;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }
            public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int spanX, int spanY, int width)
            {
                System.Drawing.Size sizeHeader = new Size();
                System.Drawing.Size sizeCell = new Size();

                Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
                Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

                Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
                Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
                Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;
                Band.Columns[colname].RowLayoutColumnInfo.SpanX = spanX;
                Band.Columns[colname].RowLayoutColumnInfo.SpanY = spanY;

                sizeCell.Height = 24;
                sizeCell.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                sizeHeader.Height = 20;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }
            public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int spanX, int spanY, int width, int height)
            {
                System.Drawing.Size sizeHeader = new Size();
                System.Drawing.Size sizeCell = new Size();

                Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
                Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

                Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
                Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
                Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;
                Band.Columns[colname].RowLayoutColumnInfo.SpanX = spanX;
                Band.Columns[colname].RowLayoutColumnInfo.SpanY = spanY;

                sizeCell.Height = height;
                sizeCell.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                sizeHeader.Height = height - 2;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }
        }

        #region [ �c�[���o�[���� ]
        /// <summary>
        /// �c�[���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            UltraGridRow activeRow = gridPartsInfo.ActiveRow;
            switch (e.Tool.Key)
            {
                case "Button_Select":
                    // �I������Ă���s���m�肷��
                    //if ((!uiControlFlg && _partsInfo.Select("SelectionState = true").Length == 0)
                    //    || (uiControlFlg && _partsInfo.Select("SelectionState = true").Length == 0 // PM.NS������̏ꍇ����ʋy��
                    //        && _orgDataSet.UsrGoodsInfo.Select("SelectionState = true").Length == 0)) // ����ʂ̑I����ԃ`�F�b�N
                    if (enterFlg == 2)
                    {
                        SetSelect(false);
                    }
                    else
                    {
                        if (_partsInfo.Select("SelectionState = true").Length == 0
                           && (_orgDataSet.ListSelectionInfo.Count == 0 ||
                           (_orgDataSet.ListSelectionInfo.ContainsKey(_prevSelInfo.Key) && _orgDataSet.ListSelectionInfo[_prevSelInfo.Key].IsThereSelection == false)))
                        {
                            SetStatusBarText(1, "�f�[�^�̑I��������Ă��܂���B");
                            break;
                        }
                        DialogResult = DialogResult.OK;
                    }
                    isUserClose = false;
                    break;

                case "Button_Back":
                    // �O�̉�ʂɖ߂�
                    DialogResult = DialogResult.Cancel;
                    isUserClose = false;
                    break;

                case "Button_Subst":
                    // ��ւ�����ꍇ���UI�\��
                    if (substFlg != 0 && activeRow != null)
                    {
                        if (activeRow.Cells[_partsInfo.SubstColumn.ColumnName].Value != DBNull.Value)
                        {
                            int makerCd = (int)activeRow.Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value;
                            //string clgpartsNo = activeRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString();
                            string clgpartsNo = activeRow.Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value.ToString();
                            PartsInfoDataSet.UsrGoodsInfoRow rowClg =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, clgpartsNo);
                            if (rowClg != null)
                            {
                                //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = rowClg;
                                activeRow.Cells[_partsInfo.SelectionStateColumn.ColumnName].Value = true;
                                _orgDataSet.UsrGoodsInfo.RowToProcess = rowClg;
                                //_prevRow = rowClg;
                                _prevRow = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd,
                                    activeRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString());
                                _orgDataSet.UIKind = SelectUIKind.Subst;
                                DialogResult = DialogResult.Retry;
                                isUserClose = false;
                            }
                        }
                    }
                    break;

                case "Button_Set": // �Z�b�g������ꍇ�Z�b�g�I��UI�\��                    
                    if (uiControlFlg && activeRow != null)
                    {
                        if (activeRow.Cells[_partsInfo.SetColumn.ColumnName].Value != DBNull.Value)
                        {
                            int makerCd = (int)activeRow.Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value;
                            string partsNo = activeRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
                            PartsInfoDataSet.UsrGoodsInfoRow row =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                            if (row != null)
                            {
                                activeRow.Cells[_partsInfo.SelectionStateColumn.ColumnName].Value = true;
                                //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                _orgDataSet.UIKind = SelectUIKind.Set;
                                DialogResult = DialogResult.Retry;
                                isUserClose = false;
                            }
                        }
                    }
                    break;

                case "Button_Join":
                    if (uiControlFlg && activeRow != null)
                    {
                        if (activeRow.Cells[_partsInfo.JoinColumn.ColumnName].Value != DBNull.Value)
                        {
                            int makerCd = (int)activeRow.Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value;
                            string partsNo = activeRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString();
                            PartsInfoDataSet.UsrGoodsInfoRow row =
                                _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo);
                            if (row != null)
                            {
                                activeRow.Cells[_partsInfo.SelectionStateColumn.ColumnName].Value = true;
                                //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                _orgDataSet.UIKind = SelectUIKind.Join;
                                DialogResult = DialogResult.Retry;
                                isUserClose = false;
                            }
                        }
                    }
                    break;

                case "Button_SubstOff":
                    //BtnSubstOffProc();
                    break;

                case "BtnExchangeDisp":
                    ExchangeDisp();
                    break;

                case "BtnSpec":
                    if (ToolbarsManager.Tools["BtnSpec"].SharedProps.Caption.Equals("�����ڍ�(F3)"))
                        SetSpecVisible();
                    else
                        SetSpecInvisible();
                    break;

                case "BtnClear":
                    ClearCondition();
                    break;

                // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- >>>
                case "Button_Car":
                    if (this.pnl_CarInfo.Visible == false)
                    {
                        this.pnl_CarInfo.Visible = true;
                    }
                    else
                    {
                        this.pnl_CarInfo.Visible = false;
                    }

                    this.SetPnlCarInfoVisible(this.pnl_CarInfo.Visible);
                    break;
                // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- <<<
            }
        }

        /// <summary>
        /// ��ʕ\���ؑ֏���
        /// </summary>
        private void ExchangeDisp()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand Band0 = gridPartsInfo.DisplayLayout.Bands[0];
            if (Band0.Columns[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Hidden) // �D�Ǖi�ԕ\����
            {
                Band0.Columns[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Hidden = false;
                Band0.Columns[_partsInfo.PrimePartsNoColumn.ColumnName].Hidden = true;
                ColInfo.SetColInfo(Band0, _partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName, 10, 0, 7, 2, 70);

                Band0.Columns[_partsInfo.NewPrtsNoWithHyphenColumn.ColumnName].Hidden = false;
                Band0.Columns[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Hidden = true;
                ColInfo.SetColInfo(Band0, _partsInfo.NewPrtsNoWithHyphenColumn.ColumnName, 17, 0, 7, 2, 60);
            }
            else                                                                       // �J�^���O�i�ԕ\����
            {
                Band0.Columns[_partsInfo.PrimePartsNoColumn.ColumnName].Hidden = false;
                Band0.Columns[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Hidden = true;
                ColInfo.SetColInfo(Band0, _partsInfo.PrimePartsNoColumn.ColumnName, 10, 0, 7, 2, 70);

                Band0.Columns[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Hidden = false;
                Band0.Columns[_partsInfo.NewPrtsNoWithHyphenColumn.ColumnName].Hidden = true;
                ColInfo.SetColInfo(Band0, _partsInfo.JoinSrcPartsNoColumn.ColumnName, 17, 0, 7, 2, 60);
            }
        }

        /// <summary>
        /// ��֎��s�\���`�F�b�N����
        /// </summary>
        /// <returns>true�F��֕s�^false�F��։�</returns>
        private bool CheckSubstExecution()
        {
            bool ret = true;
            UltraGridRow activeRow = gridPartsInfo.ActiveRow;
            int makerCd = (int)activeRow.Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value;
            string partsNo = activeRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
            string clgPartsNo = activeRow.Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value.ToString();
            string query = string.Format("{0}={1} AND {2}='{3}'",
                _partsInfo.CatalogPartsMakerCdColumn.ColumnName, makerCd,
                _partsInfo.PartsNoColumn.ColumnName, partsNo);
            dsPartsSel.PartsInfoRow[] rows = (dsPartsSel.PartsInfoRow[])_partsInfo.Select(query);
            if (rows.Length > 1 && (rows[0].ClgPrtsNoWithHyphen.Equals(clgPartsNo) == false ||
                    _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo).SelectionComplete == false))
            {
                ret = false;
            }
            //string joinSrcPartsNo = gridPartsInfo.ActiveRow.Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString();
            //string partsNo = gridPartsInfo.ActiveRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString();
            //int makerCd = (int)gridPartsInfo.ActiveRow.Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value;
            //string query = String.Format("({0}='{1}' OR {2}='{3}') AND {4}={5}", // ��֑I��UI�ɂ͒񋟂̂ݕ\��
            //    _orgDataSet.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, partsNo,
            //    _orgDataSet.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, joinSrcPartsNo,
            //    _orgDataSet.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, makerCd);
            //PartsInfoDataSet.UsrJoinPartsRow[] rows = (PartsInfoDataSet.UsrJoinPartsRow[])_orgDataSet.UsrJoinParts.Select(query);
            //PartsInfoDataSet.UsrGoodsInfoRow rowGoods;
            //for (int i = 0; i < rows.Length; i++)
            //{
            //    rowGoods = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(rows[i].JoinDestMakerCd, rows[i].JoinDestPartsNo);
            //    if (rowGoods != null && rowGoods.SelectionState)
            //    {
            //        ret = true;
            //        break;
            //    }
            //}
            return ret;
        }

        /*
        /// <summary>��։�������</summary>
        private void BtnSubstOffProc()
        {
            if (gridPartsInfo.ActiveRow != null &&
                        gridPartsInfo.ActiveRow.Cells[_partsInfo.OldPartsNoColumn.ColumnName].Value.Equals(string.Empty) == false)
            {
                int makerCd = (int)gridPartsInfo.ActiveRow.Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value;
                string partsNo = gridPartsInfo.ActiveRow.Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value.ToString();
                string nPartsNo = gridPartsInfo.ActiveRow.Cells[_partsInfo.NewPrtsNoWithHyphenColumn.ColumnName].Value.ToString();
                string oldPartsNo = gridPartsInfo.ActiveRow.Cells[_partsInfo.OldPartsNoColumn.ColumnName].Value.ToString();
                PartsInfoDataSet.UsrGoodsInfoRow newRow =�@//�@�ŐV�i�Ԃ̕��i���
                    _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, nPartsNo);

                string filter = string.Format("{0}={1} AND {2}='{3}'",
                     _partsInfo.CatalogPartsMakerCdColumn.ColumnName, makerCd,
                     _partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName, partsNo);

                dsPartsSel.PartsInfoRow[] oldRow = (dsPartsSel.PartsInfoRow[])_partsInfo.Select(filter);
                for (int i = 0; i < oldRow.Length; i++)
                {
                    if (oldRow[i].OldPartsNo == oldPartsNo) // ��։������镔�i��(��ւ��ꂽ��֌�����v���镔�i)
                    {
                        oldRow[i].OldPartsNo = string.Empty;
                        oldRow[i].JoinSrcPartsNo = partsNo; // ��։������̓J�^���O�i�Ԃ��������i��
                        oldRow[i].PartsNo = nPartsNo;
                        oldRow[i].PartsName = newRow.GoodsName;
                        oldRow[i].Price = newRow.Price;
                        oldRow[i].Urika = newRow.SalesUnitPrice;
                        oldRow[i].Genka = newRow.UnitCost;
                        oldRow[i].Ararigaku = newRow.SalesUnitPrice - newRow.UnitCost;
                        if (newRow.UnitCost != 0)
                            oldRow[i].Arariritu = oldRow[i].Ararigaku / newRow.UnitCost;
                        PartsInfoDataSet.PartsInfoRow rowPartsInfo =
                            _orgDataSet.PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(newRow.GoodsMakerCd, newRow.GoodsNo);
                        if (rowPartsInfo != null)
                        {
                            oldRow[i].PartsQty = rowPartsInfo.PartsQty;
                        }
                        if (SubstExists(oldPartsNo, makerCd)) // ��ւ̓J�^���O�i�ԂŃ`�F�b�N
                        {
                            oldRow[i].Subst = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARADD];
                        }
                        if (SetExists(nPartsNo, makerCd)) // �Z�b�g�͍ŐV�i�ԂŃ`�F�b�N
                        {
                            oldRow[i].Set = IconResourceManagement.ImageList16.Images[(int)Size16_Index.MODEL];
                        }
                        if (JoinExists(oldPartsNo, makerCd) || JoinExists(nPartsNo, makerCd)) // �����͗����Ń`�F�b�N
                        {
                            oldRow[i].Join = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CARCHANGE];
                        }

                        _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNo).SelectionState = false;
                        SetButtonState();
                        //ToolbarsManager.Tools["Button_SubstOff"].SharedProps.Visible = false;
                        break;
                    }
                }
                gridPartsInfo_AfterSelectChange(this, null);
            }
        }
        */
        /// <summary>
        /// �I���s�ɂ��{�^���̊����E�񊈐���Ԃ�ؑւ��܂��B
        /// </summary>
        private void SetButtonState()
        {
            bool enaSet = false;
            bool enaSubst = false;
            bool enaJoin = false;
            try
            {
                if (gridPartsInfo.ActiveRow == null) return;//
                if (gridPartsInfo.ActiveRow.Band != gridPartsInfo.DisplayLayout.Bands[0]) return;

                enaSet = (gridPartsInfo.ActiveRow.Cells[_partsInfo.SetColumn.ColumnName].Value != System.DBNull.Value);
                enaSubst = (gridPartsInfo.ActiveRow.Cells[_partsInfo.SubstColumn.ColumnName].Value != System.DBNull.Value);
                enaJoin = (gridPartsInfo.ActiveRow.Cells[_partsInfo.JoinColumn.ColumnName].Value != System.DBNull.Value);

            }
            finally
            {
                ToolbarsManager.Tools["Button_Set"].SharedProps.Enabled = enaSet;
                ToolbarsManager.Tools["Button_Subst"].SharedProps.Enabled = enaSubst;
                ToolbarsManager.Tools["Button_Join"].SharedProps.Enabled = enaJoin;
            }

        }

        /// <summary>
        /// �݌ɃO���b�h�I�������i���[�U�[�I�����D��q�Ɂ��擪�s�̏��őI���j
        /// </summary>
        private void SetStockGridSelect()
        {
            if ( gridPartsInfo.ActiveRow.Cells[_partsInfo.WarehouseCodeColumn.ColumnName].Value.Equals( string.Empty ) == false )
            {
                for ( int i = 0; i < gridStock.Rows.Count; i++ )
                {
                    if ( gridStock.Rows[i].Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value
                        .Equals( gridPartsInfo.ActiveRow.Cells[_partsInfo.WarehouseCodeColumn.ColumnName].Value ) )
                    {
                        gridStock.Rows[i].Activate();
                        gridStock.Rows[i].Selected = true;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                        SetSelectStock( false, true );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
                        return;
                    }
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
                // �Y�����Ȃ���ΐ擪�Ƀt�H�[�J�X�̂݃Z�b�g
                if ( gridStock.Rows.Count > 0 )
                {
                    gridStock.Rows[0].Activate();
                    gridStock.Rows[0].Selected = true;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            else
            {
                // �݌ɖ��I��(��񈵂�)�Ȃ�΍݌ɍs�̑I������
                foreach ( UltraGridRow row in gridStock.Rows )
                {
                    if ( row.Cells[_StockTable.SelImageColumn.ColumnName].Value != DBNull.Value )
                    {
                        row.Cells[_StockTable.SelImageColumn.ColumnName].Value = DBNull.Value;
                        row.Cells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
                    }
                }
                // �݌ɂ�S�đI������������A�t�H�[�J�X�͐擪�̍݌�
                if ( gridStock.Rows.Count > 0 )
                {
                    gridStock.Rows[0].Activate();
                    gridStock.Rows[0].Selected = true;
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL
            //if (_orgDataSet.ListPriorWarehouse != null)
            //{
            //    for (int i = 0; i < _orgDataSet.ListPriorWarehouse.Count; i++)
            //    {
            //        // 2009.02.16 >>>
            //        //string warehouseCd = _orgDataSet.ListPriorWarehouse[i];
            //        string warehouseCd = _orgDataSet.ListPriorWarehouse[i].Trim();
            //        // 2009.02.16 <<<
            //        for (int j = 0; j < gridStock.Rows.Count; j++)
            //        {
            //            if (gridStock.Rows[j].Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value.Equals(warehouseCd))
            //            {
            //                gridStock.Rows[j].Activate();
            //                gridStock.Rows[j].Selected = true;
            //                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            //                if ( (bool)gridStock.Rows[i].Cells[_StockTable.SelectionStateColumn.ColumnName].Value == false )
            //                {
            //                    SetSelectStock( false );
            //                }
            //                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
            //                return;
            //            }
            //        }
            //    }
            //}
            //if ( gridStock.Rows.Count > 0 )
            //{
            //    gridStock.Rows[0].Activate();
            //    gridStock.Rows[0].Selected = true;
            //    gridStock.Rows[0].Cells[_StockTable.SelectionStateColumn.ColumnName].Value = true;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            //    gridStock.Rows[0].Cells[_StockTable.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
            //}
            //else
            //{
            //    gridPartsInfo.ActiveRow.Cells[_partsInfo.WarehouseColumn.ColumnName].Value = string.Empty;
            //    gridPartsInfo.ActiveRow.Cells[_partsInfo.ShelfColumn.ColumnName].Value = string.Empty;
            //    gridPartsInfo.ActiveRow.Cells[_partsInfo.StockCntColumn.ColumnName].Value = 0;
            //    gridPartsInfo.ActiveRow.Cells[_partsInfo.WarehouseCodeColumn.ColumnName].Value = string.Empty;
            //    gridPartsInfo.UpdateData();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
        }

        /// <summary>
        /// �������\��
        /// </summary>
        private void SetSpecVisible()
        {
            if (gridPartsInfo.ActiveRow != null && gridPartsInfo.ActiveRow.Band.ParentBand == null)
            {
                if (gridPartsInfo.ActiveRow.ChildBands.Count > 0)
                {
                    gridPartsInfo.ActiveRow.ExpandAll();
                    ToolbarsManager.Tools["BtnSpec"].SharedProps.Caption = "�i�ԒP��(F3)";
                }
            }
        }

        /// <summary>
        /// ��������\��
        /// </summary>
        private void SetSpecInvisible()
        {
            if (gridPartsInfo.ActiveRow != null)
            {
                if (gridPartsInfo.ActiveRow.Band.ParentBand == null)
                {
                    gridPartsInfo.ActiveRow.CollapseAll();
                    ToolbarsManager.Tools["BtnSpec"].SharedProps.Caption = "�����ڍ�(F3)";
                }
                else
                {
                    gridPartsInfo.ActiveRow.ParentRow.CollapseAll();
                    ToolbarsManager.Tools["BtnSpec"].SharedProps.Caption = "�����ڍ�(F3)";
                }
            }
        }
        ///////////////////////////////////////////////////////////

        private void RefreshDataCount()
        {
            int cnt = gridPartsInfo.Rows.VisibleRowCount;
            string cntMsg;
            if (cnt != 0)
            {
                if (gridPartsInfo.Selected.Rows.Count > 0 && gridPartsInfo.Selected.Rows[0].VisibleIndex != -1)
                {
                    cntMsg = string.Format("{0} / {1}", gridPartsInfo.Selected.Rows[0].VisibleIndex + 1, cnt);
                }
                else
                {
                    cntMsg = string.Format("1 / {0}", cnt);
                }
            }
            else
            {
                cntMsg = "0 / 0";
            }
            ToolbarsManager.Tools["LblCntDisplay"].SharedProps.Caption = cntMsg;
        }
        #endregion

        #region [ �O���b�h�C�x���g���� ]

        /// <summary>
        /// �A�N�e�B�u�s�ύX��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridPartsInfo_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            if (isSelectChangeDisabled)
                return;
            
            if (gridPartsInfo.Selected.Rows.Count == 0)
                return;
            if (gridPartsInfo.Selected.Rows[0].Activated == false)
                gridPartsInfo.Selected.Rows[0].Activate();
            UltraGridRow activeRow = gridPartsInfo.ActiveRow;
            if (activeRow == null || activeRow.Band.ParentBand != null) // �e�o���h�̏ꍇ
                return;
            #region [ �݌ɃO���b�h�t�B���^�����O���� ]
            string filter = string.Empty;
            try
            {
                filter = string.Format("{0}={1} AND {2}='{3}' ",
                    _StockTable.GoodsMakerCdColumn.ColumnName,
                    activeRow.Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value,
                    _StockTable.GoodsNoColumn.ColumnName,
                    activeRow.Cells[_partsInfo.PartsNoColumn.ColumnName].Value);
            }
            finally
            {
                _StockTable.DefaultView.RowFilter = filter;
            }
            #endregion

            SetStockGridSelect();

            _colorTable.DefaultView.RowFilter = string.Empty;
            _trimTable.DefaultView.RowFilter = string.Empty;
            _equipTable.DefaultView.RowFilter = string.Empty;

            string partsProperNo = activeRow.Cells[_partsInfo.PartsUniqueNoColumn.ColumnName].Text;
            if (IsColorData)
            {
                filter = string.Format("{0} = '{1}'", _colorTable.PartsProperNoColumn.ColumnName, partsProperNo);
                _colorTable.DefaultView.RowFilter = filter;
            }
            if (IsTrimData)
            {
                filter = string.Format("{0} = '{1}'", _trimTable.PartsProperNoColumn.ColumnName, partsProperNo);
                _trimTable.DefaultView.RowFilter = filter;
            }
            if (IsEquipData)
            {
                filter = string.Format("{0} = '{1}'", _equipTable.PartsProperNoColumn.ColumnName, partsProperNo);
                _equipTable.DefaultView.RowFilter = filter;
            }
            if (activeRow.Expanded)
            {
                ToolbarsManager.Tools["BtnSpec"].SharedProps.Caption = "�i�ԒP��(F3)";
            }
            else
            {
                ToolbarsManager.Tools["BtnSpec"].SharedProps.Caption = "�����ڍ�(F3)";
            }
            RefreshDataCount();

            SetButtonState();
        }

        /// <summary>
        /// �s���_�u���N���b�N���ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// �f�[�^���\������Ă��Ȃ��s���_�u���N���b�N���Ă��{�C�x���g�͔������Ȃ��B
        /// </remarks>
        private void gridPartsInfo_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            SetSelect(false);
        }

        /// <summary>
        /// �O���b�h���Enter�L�[�������ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridPartsInfo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add:
                    SetSpecVisible();
                    break;

                case Keys.Subtract:
                    SetSpecInvisible();
                    break;

                case Keys.Enter:
                    SetSelect(true);
                    break;

            }
        }

        private void gridPartsInfo_MouseEnterElement(object sender, Infragistics.Win.UIElementEventArgs e)
        {
            if (e.Element.ToString().Contains("CellUIElement") == false)
                return;
            for (int i = 0; i < gridPartsInfo.Rows.Count; i++)
            {
                UltraGridCell processingCell = gridPartsInfo.Rows[i].Cells[_partsInfo.NewPrtsNoWithHyphenColumn.ColumnName];
                UltraGridCell processingCell2 = gridPartsInfo.Rows[i].Cells[_partsInfo.PrimePartsNoColumn.ColumnName];
                if (e.Element.Equals(processingCell.GetUIElement()) &&
                    processingCell.Value.Equals(gridPartsInfo.Rows[i].Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value) == false)
                {
                    processedCell = processingCell;

                    string query = string.Format("{0}={1} AND {2}='{3}'",
                        _partsInfo.CatalogPartsMakerCdColumn.ColumnName, catalogMakerCd,
                        _partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName, processingCell.Value);
                    dsPartsSel.PartsInfoRow[] rows = (dsPartsSel.PartsInfoRow[])_partsInfo.Select(query);
                    if (rows.Length > 0)
                    {
                        processingCell.Appearance.BackColor = Color.White;
                        processingCell.Appearance.BackColor2 = Color.LightBlue;
                        processingCell.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
                        processingCell.SelectedAppearance = processingCell.Appearance;
                        panel.Text = string.Format("�}�E�X�E�N���b�N�ŃJ�^���O�i��{0}�̍ŐV�������i�̏������邱�Ƃ��o���܂��B",
                            gridPartsInfo.Rows[i].Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value);

                        Infragistics.Win.UIElement element = processingCell.GetUIElement();
                        frmPartsInfo.Year = rows[0].ModelPrtsAdptYm.ToString("####�N##��") + " - " + rows[0].ModelPrtsAblsYm.ToString("####�N##��");
                        frmPartsInfo.SpecialNote = rows[0].PartsOpNm;
                        frmPartsInfo.Standard = rows[0].StandardName;
                        frmPartsInfo.PartsNo = rows[0].ClgPrtsNoWithHyphen;

                        frmPartsInfo.Left = this.Left + element.Rect.Left + (element.Rect.Width / 4);
                        frmPartsInfo.Top = this.Top + gridPartsInfo.Top + 30 + element.Rect.Top + element.Rect.Height - frmPartsInfo.Height;
                        //frmPartsInfo.Show(this);
                        currentCell = 1;
                    }

                    break;
                }
                else if (e.Element.Equals(processingCell2.GetUIElement())
                    && gridPartsInfo.Rows[i].Cells[_partsInfo.PrimePartsNoColumn.ColumnName].Value.Equals(string.Empty) == false)
                {
                    processedCell = processingCell2;

                    panel.Text = string.Format("�}�E�X�E�N���b�N�ŕi��{0}�̑S�Ă̌������i�̏������邱�Ƃ��o���܂��B",
                        gridPartsInfo.Rows[i].Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value);
                    processingCell2.Appearance.BackColor = Color.White;
                    processingCell2.Appearance.BackColor2 = Color.LightBlue;
                    processingCell2.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
                    processingCell2.SelectedAppearance = processingCell2.Appearance;

                    Infragistics.Win.UIElement element = processingCell2.GetUIElement();
                    frmJoinInfo.Left = this.Left + element.Rect.Left + (element.Rect.Width / 4);
                    frmJoinInfo.Top = this.Top + gridPartsInfo.Top + 30 + element.Rect.Top + element.Rect.Height - frmJoinInfo.Height;
                    if (frmJoinInfo.Top < 0)
                        frmJoinInfo.Top = this.Top + gridPartsInfo.Top + 34 + element.Rect.Top + element.Rect.Height * 2;

                    frmJoinInfo.JoinSrcMakerCd = (int)gridPartsInfo.Rows[i].Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value;
                    frmJoinInfo.JoinSrcPartsNo = (string)gridPartsInfo.Rows[i].Cells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value;
                    //frmJoinInfo.Show(this, (int)gridPartsInfo.Rows[i].Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value,
                    //    (string)gridPartsInfo.Rows[i].Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value);
                    currentCell = 2;
                    break;
                }
            }
        }

        /// <summary>
        /// �}�E�X�J�[�\�����O���b�h�̓���Z�����痣���ۂ̏���
        /// </summary>
        private void gridPartsInfo_MouseLeaveElement(object sender, Infragistics.Win.UIElementEventArgs e)
        {
            GridElementLeaveProcess();
        }

        /// <summary>
        /// �}�E�X�J�[�\�����O���b�h�̓���Z�����痣���ۂ̏���
        /// </summary>
        private void gridPartsInfo_Leave(object sender, EventArgs e)
        {
            GridElementLeaveProcess();
        }

        private void gridPartsInfo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (currentCell == 1)
                {
                    frmPartsInfo.Show(this);
                }
                else if (currentCell == 2)
                {
                    frmJoinInfo.Show(this);//, (int)gridPartsInfo.Rows[i].Cells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value,
                    // (string)gridPartsInfo.Rows[i].Cells[_partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName].Value);
                }
                currentCell = 0;
            }
        }

        private void gridCondition_CellListSelect(object sender, CellEventArgs e)
        {
            if (isSelectChangeDisabled)
                return;
            string filterString = string.Empty;

            RowFilterKind selected = lstEnum[e.Cell.Column.Key];
            if (e.Cell.Text == string.Empty)
            {
                if (rowFilterList.ContainsKey(selected))
                {
                    rowFilterList.Remove(selected);
                }
            }
            else
            {
                filterString = string.Format("{0} = '{1}'", e.Cell.Column.Key, e.Cell.Text);
                if (rowFilterList.ContainsKey(selected))
                {
                    rowFilterList[selected] = filterString;
                }
                else
                {
                    rowFilterList.Add(selected, filterString);
                }
            }

            gridCondition.UpdateData();

            GridFiltering();
        }

        /// <summary>
        /// �}�E�X�J�[�\�����O���b�h�̓���Z�����痣���ۂ̏���
        /// </summary>
        private void GridElementLeaveProcess()
        {
            if (frmPartsInfo.Visible)
            {
                frmPartsInfo.Visible = false;
            }
            if (frmJoinInfo.Visible)
            {
                frmJoinInfo.Visible = false;
            }
            if (processedCell != null)
            {
                processedCell.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.None;
                processedCell.Appearance.ResetBackColor();
                processedCell.SelectedAppearance.Reset();
            }
            panel.Text = "";
            currentCell = 0;
            processedCell = null;
        }

        /// <summary>
        /// Enter�L�[(�_�u���N���b�N)�ɂ��I������
        /// </summary>
        /// <param name="moveFlg">true:���̍s��I����ԂɁ^false:�Ȃɂ����Ȃ��i�}�E�X�_�u���N���b�N���j</param>
        private void SetSelect(bool moveFlg)
        {
            UltraGridRow activeRow = gridPartsInfo.ActiveRow;
            if (activeRow != null)
            {
                CellsCollection activeCells = activeRow.Cells;
                if (activeRow.Band.ParentBand == null // �e�o���h��(�q�o���h�͎ԗ����̂��߁j
                    && enterFlg != 2) // �iPM.NS�������Enter�L�[���u����ʁv�j�ȊO��
                {
                    if (activeCells[_partsInfo.SelImageColumn.ColumnName].Value != DBNull.Value)
                    {
                        activeCells[_partsInfo.SelImageColumn.ColumnName].Value = DBNull.Value;
                        activeCells[_partsInfo.SelectionStateColumn.ColumnName].Value = false;
                        if (_orgDataSet.ListSelectionInfo.ContainsKey(activeRow.ListIndex)) // �I���������镔�i�̌�����Ȃǂ̑I����ԉ���
                        {
                            _orgDataSet.ListSelectionInfo.Remove(activeRow.ListIndex);
                        }
                    }
                    else
                    {
                        activeCells[_partsInfo.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                        activeCells[_partsInfo.SelectionStateColumn.ColumnName].Value = true;
                    }
                    _partsInfo.AcceptChanges();
                }
                switch (enterFlg) // �G���^�[�L�[�����敪
                {
                    case 2: // Enter�L�[���u����ʁv�̏ꍇ
                        foreach (UltraGridRow row in gridPartsInfo.Rows) // ����ʂ̎��͑I���s�ȊO�͑I����������
                        {
                            if (row.Equals(activeRow) == false && row.Cells[_partsInfo.SelImageColumn.ColumnName].Value != DBNull.Value)
                            {
                                row.Cells[_partsInfo.SelImageColumn.ColumnName].Value = DBNull.Value;
                                row.Cells[_partsInfo.SelectionStateColumn.ColumnName].Value = false;
                                if (_orgDataSet.ListSelectionInfo.ContainsKey(row.ListIndex))
                                {
                                    _orgDataSet.ListSelectionInfo.Remove(row.ListIndex);
                                }
                            }
                        }
                        if (uiControlFlg) // PM.NS����
                        {
                            //_orgDataSet.UsrGoodsInfo.PreviousActiveRow = row;
                            if (activeCells[_partsInfo.JoinColumn.ColumnName].Value != DBNull.Value) // ������񂠂�
                            {
                                PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo
                                    ((int)activeCells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value,
                                     activeCells[_partsInfo.JoinSrcPartsNoColumn.ColumnName].Value.ToString());
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                _orgDataSet.UIKind = SelectUIKind.Join;
                                DialogResult = DialogResult.Retry;
                            }
                            else if (activeCells[_partsInfo.SetColumn.ColumnName].Value != DBNull.Value) // �Z�b�g��񂠂�
                            {
                                PartsInfoDataSet.UsrGoodsInfoRow row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo
                                    ((int)activeCells[_partsInfo.CatalogPartsMakerCdColumn.ColumnName].Value,
                                     activeCells[_partsInfo.PartsNoColumn.ColumnName].Value.ToString());
                                _orgDataSet.UsrGoodsInfo.RowToProcess = row;
                                _orgDataSet.UIKind = SelectUIKind.Set;
                                DialogResult = DialogResult.Retry;
                            }
                            else
                            {
                                // 2009.02.18 >>>
                                //DialogResult = DialogResult.OK;
                                activeCells[_partsInfo.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                                activeCells[_partsInfo.SelectionStateColumn.ColumnName].Value = true;
                                DialogResult = DialogResult.OK;
                                return;
                                // 2009.02.18 <<<
                            }
                            //activeCells[_partsInfo.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                            //activeCells[_partsInfo.SelectionStateColumn.ColumnName].Value = true; // ����ʂ��Ȃ��ꍇ�I�����I��
                        }
                        else // PM7����
                        {
                            //activeCells[_partsInfo.SelImageColumn.ColumnName].Value = DBNull.Value;
                            //activeCells[_partsInfo.SelectionStateColumn.ColumnName].Value = true;
                            DialogResult = DialogResult.OK;
                        }
                        activeCells[_partsInfo.SelImageColumn.ColumnName].Value = DBNull.Value;
                        activeCells[_partsInfo.SelectionStateColumn.ColumnName].Value = true;
                        break;
                    default: // Enter�L�[���u�I���v�uPM7�v�̏ꍇ�F�����I�𓮍�̂��ߎ��s��I����ԂƂ���B
                        if (moveFlg)
                        {
                            UltraGridRow ugr = activeRow.GetSibling(SiblingRow.Next);
                            if (ugr != null)
                            {
                                ugr.Selected = true;
                                ugr.Activate();
                            }
                        }
                        break;
                }
            }
        }
        #endregion

        #region [ �i���֘A���� ]
        private void cmbColor_SelectionChanged(object sender, EventArgs e)
        {
            if (isSelectChangeDisabled)
                return;
            GridFiltering();
            gridPartsInfo.Select();
        }

        private void cmbTrim_SelectionChanged(object sender, EventArgs e)
        {
            if (isSelectChangeDisabled)
                return;
            GridFiltering();
            gridPartsInfo.Select();
        }

        private void GridFiltering()
        {
            string filter = MakeRowFilterString();

            gridPartsInfo.BeginUpdate();
            _partsInfo.DefaultView.RowFilter = filter;
            gridPartsInfo.EndUpdate();
            if (gridPartsInfo.Rows.Count > 0)
            {
                gridPartsInfo.Rows[0].Activate();
                gridPartsInfo.Rows[0].Selected = true;
            }
            //gridPartsInfo_AfterSelectChange(this, null);
            RefreshDataCount();
        }

        /// <summary>
        /// �e��i�������ɂ��t�B���^�����O�N�G���쐬
        /// </summary>
        /// <returns></returns>
        private string MakeRowFilterString()
        {
            string innerFilter;
            List<long> partsProperNoList = null;
            List<long> properNoLstClrTrm = null;
            #region [ �J���[�E�g�����E�����i�� ]
            if (IsColorData)
            {
                if (cmbColor.Value != null && !cmbColor.Value.Equals(string.Empty))
                {
                    properNoLstClrTrm = new List<long>();
                    innerFilter = string.Format("{0} = '{1}'", _colorTable.ColorCdInfoNoColumn.ColumnName, cmbColor.Value);

                    PartsInfoDataSet.OfrColorInfoRow[] row = (PartsInfoDataSet.OfrColorInfoRow[])_colorTable.Select(innerFilter);
                    for (int i = 0; i < row.Length; i++)
                    {
                        if (properNoLstClrTrm.Contains(row[i].PartsProperNo) == false)
                            properNoLstClrTrm.Add(row[i].PartsProperNo);
                    }
                    // --- ADD 2012/11/27 T.Miyamoto ------------------------------>>>>>
                    // �J���[���Ȃ����i(�J���[�i���t���O���O)���t�B���^�[�����ɒǉ�
                    innerFilter = string.Format("{0} = {1}", _partsInfo.ColorNarrowingFlagColumn.ColumnName, 0);
                    dsPartsSel.PartsInfoRow[] rows = (dsPartsSel.PartsInfoRow[])_partsInfo.Select(innerFilter);
                    for (int iChk = 0; iChk < rows.Length; iChk++)
                    {
                        if (properNoLstClrTrm.Contains(rows[iChk].PartsUniqueNo) == false)
                            properNoLstClrTrm.Add(rows[iChk].PartsUniqueNo);
                    }
                    // --- ADD 2012/11/27 T.Miyamoto ------------------------------<<<<<
                }
            }
            if (IsTrimData)
            {
                if (cmbTrim.Value != null && !cmbTrim.Value.Equals(string.Empty))
                {
                    properNoLstClrTrm = new List<long>();
                    innerFilter = string.Format("{0} = '{1}'", _trimTable.TrimCodeColumn.ColumnName, cmbTrim.Value);

                    PartsInfoDataSet.OfrTrimInfoRow[] row = (PartsInfoDataSet.OfrTrimInfoRow[])_trimTable.Select(innerFilter);
                    for (int i = 0; i < row.Length; i++)
                    {
                        if (properNoLstClrTrm.Contains(row[i].PartsProperNo) == false)
                            properNoLstClrTrm.Add(row[i].PartsProperNo);
                    }
                    // --- ADD 2012/11/27 T.Miyamoto ------------------------------>>>>>
                    // �g�������Ȃ����i(�g�����i���t���O���O)���t�B���^�[�����ɒǉ�
                    innerFilter = string.Format("{0} = {1}", _partsInfo.TrimNarrowingFlagColumn.ColumnName, 0);
                    dsPartsSel.PartsInfoRow[] rows = (dsPartsSel.PartsInfoRow[])_partsInfo.Select(innerFilter);
                    for (int iChk = 0; iChk < rows.Length; iChk++)
                    {
                        if (properNoLstClrTrm.Contains(rows[iChk].PartsUniqueNo) == false)
                            properNoLstClrTrm.Add(rows[iChk].PartsUniqueNo);
                    }
                    // --- ADD 2012/11/27 T.Miyamoto ------------------------------<<<<<
                }
            }
            if (IsEquipData)
            {
                innerFilter = string.Empty;
                List<long> lstTmp;

                for (int i = 0; i < gridSoubi.Rows.Count; i++)
                {
                    lstTmp = null;
                    if (gridSoubi.Rows[i].Cells[1].Value.Equals(string.Empty) == false && gridSoubi.Rows[i].Cells[1].Value.Equals(DBNull.Value) == false)
                    {
                        lstTmp = new List<long>();
                        innerFilter = string.Format("{0} = '{1}' AND ({2}='{3}' OR {4}='')",
                            _equipTable.EquipmentGenreNmColumn.ColumnName, gridSoubi.Rows[i].Cells[0].Value,
                            _equipTable.EquipmentNameColumn.ColumnName, gridSoubi.Rows[i].Cells[1].Value.ToString(),
                            _equipTable.EquipmentNameColumn.ColumnName);
                        PartsInfoDataSet.OfrEquipInfoRow[] row = (PartsInfoDataSet.OfrEquipInfoRow[])_equipTable.Select(innerFilter);
                        for (int j = 0; j < row.Length; j++)
                        {
                            lstTmp.Add(row[j].PartsProperNo);
                        }
                    }
                    //>>>2010/03/29
                    else
                    {
                        lstTmp = new List<long>();
                        foreach ( PartsInfoDataSet.OfrEquipInfoRow row in this._equipTable )
                        {
                            lstTmp.Add( row.PartsProperNo );
                        }
                    }
                    //<<<2010/03/29

                    // --- DEL m.suzuki 2011/03/03 ---------->>>>>
                    //if (partsProperNoList == null) // �����
                    //    partsProperNoList = lstTmp;
                    //else
                    //    partsProperNoList = GetCommonLongList(lstTmp, partsProperNoList);
                    // --- DEL m.suzuki 2011/03/03 ----------<<<<<

                    //>>>2010/03/29
                    dsPartsSel.ModelPartsDetailDataTable svModelPartsDetail = (dsPartsSel.ModelPartsDetailDataTable)this._modelPartsDetail.Copy();
                    string filter = string.Empty;
                    foreach ( PartsInfoDataSet.OfrEquipInfoRow equipRow in this._equipTable )
                    {
                        // --- ADD m.suzuki 2011/03/16 ---------->>>>>
                        // �����ڂ��Ă���gridSoubi.Rows[i]�ƈقȂ鑕�����͖�������B
                        if ( gridSoubi.Rows[i].Cells[0].Value.Equals( DBNull.Value ) ||
                             (string)gridSoubi.Rows[i].Cells[0].Value != equipRow.EquipmentGenreNm )
                        {
                            continue;
                        }
                        // --- ADD m.suzuki 2011/03/16 ----------<<<<<

                        string ffilter = string.Format( "{0} = '{1}'", svModelPartsDetail.PartsUniqueNoColumn, equipRow.PartsProperNo );

                        dsPartsSel.ModelPartsDetailRow[] rows = (dsPartsSel.ModelPartsDetailRow[])svModelPartsDetail.Select( ffilter );

                        if ( rows.Length != 0 )
                        {
                            // --- UPD m.suzuki 2011/03/16 ---------->>>>>
                            //svModelPartsDetail.RemoveModelPartsDetailRow( rows[0] );
                            // ����PartsProperNo�̍s���S�ď��O
                            for ( int deleteIndex = 0; deleteIndex < rows.Length; deleteIndex++ )
                            {
                                svModelPartsDetail.RemoveModelPartsDetailRow( rows[deleteIndex] );
                            }
                            // --- UPD m.suzuki 2011/03/16 ----------<<<<<
                        }
                    }
                    if ( svModelPartsDetail.Count != 0 )
                    {
                        foreach ( dsPartsSel.ModelPartsDetailRow row in svModelPartsDetail )
                        {
                            if ( lstTmp == null ) lstTmp = new List<long>();
                            lstTmp.Add( row.PartsUniqueNo );
                        }
                    }
                    if ( (partsProperNoList != null) && (partsProperNoList.Count == 0) ) partsProperNoList = null;

                    if ( partsProperNoList == null ) // �����
                        partsProperNoList = lstTmp;
                    else
                        partsProperNoList = GetCommonLongList( lstTmp, partsProperNoList );
                    //<<<2010/03/29
                }
                partsProperNoList = GetCommonLongList(properNoLstClrTrm, partsProperNoList);
            }
            else // ���������Ȃ��̂Ƃ��̓J���[�E�g�����݂̂ɂ��
            {
                partsProperNoList = properNoLstClrTrm;
            }
            #endregion

            bool flg2 = false;  // �ԗ����i���@��������t���O
            List<long> lstProperNoFromCarInfo = new List<long>();

            if (rowFilterList.Values.Count > 0)
            {
                flg2 = true;
                StringBuilder modelFilter = new StringBuilder();
                foreach (string rowFilter in rowFilterList.Values)
                {
                    modelFilter.Append(" AND " + rowFilter);
                }
                modelFilter.Remove(0, 4);
                dsPartsSel.ModelPartsDetailRow[] modelRows = (dsPartsSel.ModelPartsDetailRow[])_modelPartsDetail.Select(modelFilter.ToString());
                for (int i = 0; i < modelRows.Length; i++)
                {
                    if (lstProperNoFromCarInfo.Contains(modelRows[i].PartsUniqueNo) == false)
                        lstProperNoFromCarInfo.Add(modelRows[i].PartsUniqueNo);
                }
            }

            StringBuilder retRowFilter = new StringBuilder();
            retRowFilter.Append(originalRowFilter);

            if (partsProperNoList == null || partsProperNoList.Count > 0) // �J���[�E�g�����E�������i�������Ȃ��@���́@���芎���i�ŗL�ԍ����X�g����
            {
                if (partsProperNoList == null && flg2 == false) // �ԗ��i������Ȃ��@�y�с@�J���[�g�������������Ȃ�
                {
                    this.ToolbarsManager.Tools["BtnClear"].SharedProps.Visible = false;
                    return originalRowFilter;
                }

                if (retRowFilter.Length > 0)
                {
                    retRowFilter.Append(" AND ");
                }
                retRowFilter.Append("PartsUniqueNo in (");

                if (partsProperNoList != null && partsProperNoList.Count > 0)
                {
                    bool isCondition = false;
                    for (int i = 0; i < partsProperNoList.Count; i++)
                    {
                        if (flg2 == false || (flg2 && lstProperNoFromCarInfo.Contains(partsProperNoList[i])))
                        { // �ԗ����i���@�����Ȃ��@���́@���芎���i�ŗL�ԍ����X�g�ɓ��ꕔ�i�ŗL�ԍ�����
                            retRowFilter.Append(partsProperNoList[i]);
                            retRowFilter.Append(", ");
                            isCondition = true;
                        }
                    }
                    if (isCondition == false)
                        return "false";
                }
                else
                {
                    if (lstProperNoFromCarInfo.Count == 0)
                        return "false";
                    for (int i = 0; i < lstProperNoFromCarInfo.Count; i++)
                    {
                        retRowFilter.Append(lstProperNoFromCarInfo[i]);
                        retRowFilter.Append(", ");
                    }
                }

                retRowFilter.Remove(retRowFilter.Length - 2, 2);
                retRowFilter.Append(")");

                if (flg2) // �ԗ����i�������̂݁@�i�������N���A�ΏۂƂ���B
                {
                    this.ToolbarsManager.Tools["BtnClear"].SharedProps.Visible = true;
                }
                else
                {
                    this.ToolbarsManager.Tools["BtnClear"].SharedProps.Visible = false;
                }

            }
            else // �i�������ɊY�����镔�i�Ȃ�
            {
                return "false";
            }
            return retRowFilter.ToString();
        }

        /// <summary>
        /// ��̃��X�g���狤�ʂ̗v�f�݂̂̃��X�g��Ԃ��B
        /// </summary>
        /// <param name="lst1">���X�g�P</param>
        /// <param name="lst2">���X�g�Q</param>
        /// <returns>���ʗv�f�̃��X�g</returns>
        private List<long> GetCommonLongList(List<long> lst1, List<long> lst2)
        {
            List<long> lstTmpResult;
            List<long> lstShort;
            List<long> lstLong;
            if (lst1 == null)
            {
                if (lst2 == null)
                    return null;
                else
                    return lst2;
            }
            else
            {
                if (lst2 == null)
                    return lst1;
            }
            lstTmpResult = new List<long>();
            if (lst1.Count > lst2.Count)
            {
                lstShort = lst2;
                lstLong = lst1;
            }
            else
            {
                lstShort = lst1;
                lstLong = lst2;
            }
            for (int j = 0; j < lstShort.Count; j++) // �Z�����X�g�̗v�f���������X�g�ɂ��邩�`�F�b�N
            {
                if (lstLong.Contains(lstShort[j]))
                    lstTmpResult.Add(lstShort[j]);
            }
            return lstTmpResult;
        }

        /// <summary>
        /// �i���O���b�h�f�[�^�쐬����
        /// </summary>
        private void MakeConditionGridData()
        {
            List<Infragistics.Win.ValueList> vlist = new List<Infragistics.Win.ValueList>();

            for (int i = 0; i < conditionCellCount; i++)
            {
                vlist.Add(new Infragistics.Win.ValueList());
                vlist[i].ValueListItems.Add("");
            }

            gridCondition.BeginUpdate();

            gridCondition.DisplayLayout.Bands[0].AddNew();

            for (int i = 0; i < conditionCellCount; i++)
            {
                gridCondition.Rows[0].Cells[i].ValueList = vlist[i];
            }
            SetAddCarSpecColumn(gridCondition.DisplayLayout.Bands[0]);

            for (int i = 0; i < _modelPartsDetail.DefaultView.Count; i++)
            {
                dsPartsSel.ModelPartsDetailRow rowToComp = (dsPartsSel.ModelPartsDetailRow)_modelPartsDetail.DefaultView[i].Row;

                if (vlist[0].FindByDataValue(rowToComp.ModelGradeNm) == null)      // �^���O���[�h����
                    vlist[0].ValueListItems.Add(rowToComp.ModelGradeNm);
                if (vlist[1].FindByDataValue(rowToComp.BodyName) == null)          // �{�f�B�[����
                    vlist[1].ValueListItems.Add(rowToComp.BodyName);
                if (vlist[2].FindByDataValue(rowToComp.DoorCount) == null)         // �h�A��
                    vlist[2].ValueListItems.Add(rowToComp.DoorCount);
                if (vlist[3].FindByDataValue(rowToComp.EngineModelNm) == null)     // �G���W���^������
                    vlist[3].ValueListItems.Add(rowToComp.EngineModelNm);
                if (vlist[4].FindByDataValue(rowToComp.EngineDisplaceNm) == null)  // �r�C�ʖ���
                    vlist[4].ValueListItems.Add(rowToComp.EngineDisplaceNm);
                if (vlist[5].FindByDataValue(rowToComp.EDivNm) == null)            // E�敪����
                    vlist[5].ValueListItems.Add(rowToComp.EDivNm);
                if (vlist[6].FindByDataValue(rowToComp.TransmissionNm) == null)    // �~�b�V��������
                    vlist[6].ValueListItems.Add(rowToComp.TransmissionNm);
                if (vlist[7].FindByDataValue(rowToComp.ShiftNm) == null)           // �V�t�g����
                    vlist[7].ValueListItems.Add(rowToComp.ShiftNm);
                if (vlist[8].FindByDataValue(rowToComp.WheelDriveMethodNm) == null)// �쓮��������
                    vlist[8].ValueListItems.Add(rowToComp.WheelDriveMethodNm);
                if (vlist[9].FindByDataValue(rowToComp.AddiCarSpec1) == null)      // �ǉ�����1
                    vlist[9].ValueListItems.Add(rowToComp.AddiCarSpec1);
                if (vlist[10].FindByDataValue(rowToComp.AddiCarSpec2) == null)      // �ǉ�����2
                    vlist[10].ValueListItems.Add(rowToComp.AddiCarSpec2);
                if (vlist[11].FindByDataValue(rowToComp.AddiCarSpec3) == null)      // �ǉ�����3
                    vlist[11].ValueListItems.Add(rowToComp.AddiCarSpec3);
                if (vlist[12].FindByDataValue(rowToComp.AddiCarSpec4) == null)      // �ǉ�����4
                    vlist[12].ValueListItems.Add(rowToComp.AddiCarSpec4);
                if (vlist[13].FindByDataValue(rowToComp.AddiCarSpec5) == null)      // �ǉ�����5
                    vlist[13].ValueListItems.Add(rowToComp.AddiCarSpec5);
                if (vlist[14].FindByDataValue(rowToComp.AddiCarSpec6) == null)      // �ǉ�����6
                    vlist[14].ValueListItems.Add(rowToComp.AddiCarSpec6);
            }

            for (int i = 0; i < conditionCellCount; i++)
            {
                if (vlist[i].ValueListItems.Count <= 2) // �i��������1�i�擪�󔒊܂߂�2�j�����Ȃ��ꍇ
                {
                    gridCondition.Rows[0].Cells[i].Column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                    gridCondition.Rows[0].Cells[i].Column.CellClickAction = CellClickAction.CellSelect;
                    if (vlist[i].ValueListItems.Count == 2)
                        gridCondition.Rows[0].Cells[i].Value = vlist[i].ValueListItems[1].DisplayText;
                }
            }
            gridCondition.UpdateData();
            gridCondition.EndUpdate();

            UltraGridBand band = gridCondition.DisplayLayout.Bands[0];
            band.UseRowLayout = true;
            band.Columns[colToShow[2]].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right; // �h�A�E�l��
            gridCondition.DisplayLayout.Override.RowSelectorWidth = gridPartsInfo.DisplayLayout.Override.RowSelectorWidth;
            ColInfo.SetColInfo(band, colToShow[0], 2, 0, 4, 2, 120);    // ModelGradeNm
            ColInfo.SetColInfo(band, colToShow[1], 6, 0, 4, 2, 120);    // BodyName
            ColInfo.SetColInfo(band, colToShow[2], 10, 0, 2, 2, 60);    // DoorCount
            ColInfo.SetColInfo(band, colToShow[3], 12, 0, 4, 2, 120);   // EngineModelNm
            ColInfo.SetColInfo(band, colToShow[4], 16, 0, 4, 2, 120);    // EngineDisplaceNm
            ColInfo.SetColInfo(band, colToShow[5], 20, 0, 2, 2, 60);   // EDivNm
            ColInfo.SetColInfo(band, colToShow[6], 22, 0, 4, 2, 120);   // TransmissionNm
            ColInfo.SetColInfo(band, colToShow[7], 26, 0, 3, 2, 90);   // ShiftNm
            ColInfo.SetColInfo(band, colToShow[8], 29, 0, 3, 2, 90);   // WheelDriveMethodNm
            // 3�i
            int originX = 2;
            if (band.Columns[colToShow[9]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[9], originX, 2, 5, 2, 150);   // �ǉ�����1
                originX += 5;
            }
            if (band.Columns[colToShow[10]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[10], originX, 2, 5, 2, 150);   // �ǉ�����2
                originX += 5;
            }
            if (band.Columns[colToShow[11]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[11], originX, 2, 5, 2, 150);  // �ǉ�����3
                originX += 5;
            }
            if (band.Columns[colToShow[12]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[12], originX, 2, 5, 2, 150);  // �ǉ�����4
                originX += 5;
            }
            if (band.Columns[colToShow[13]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[13], originX, 2, 5, 2, 150);  // �ǉ�����5
                originX += 5;
            }
            if (band.Columns[colToShow[14]].Hidden == false)
            {
                ColInfo.SetColInfo(band, colToShow[14], originX, 2, 5, 2, 120);  // �ǉ�����6
            }

            if (originX > 2) // �ǉ�������񂪂���ꍇ
            {
                gridCondition.Height = 94;
                gridPartsInfo.Top += 48;
                gridPartsInfo.Height -= 48;
            }
            else
            {
                gridCondition.Height = 48;
            }
        }

        private void ClearCondition()
        {
            isSelectChangeDisabled = true;
            //cmbColor.SelectedIndex = 0;
            //cmbTrim.SelectedIndex = 0;
            //cmbEquip.SelectedIndex = 0;
            for (int i = 0; i < conditionCellCount; i++)
            {
                if (gridCondition.Rows[0].Cells[i].Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                {
                    gridCondition.Rows[0].Cells[i].Value = string.Empty;
                }
            }
            isSelectChangeDisabled = false;

            gridCondition.UpdateData();
            rowFilterList.Clear();

            GridFiltering();
            isSelectChangeDisabled = true;
            gridPartsInfo.Selected.Rows.Clear();
            isSelectChangeDisabled = false;
            RefreshDataCount();
        }
        #endregion

        private DateTime GetDtFromInt(int dt)
        {
            if (dt <= 101)
                return DateTime.MinValue;
            if (dt > 300000)
                return DateTime.MaxValue;
            int year = dt / 100;
            int month = dt % 100;

            return new DateTime(year, month, 1);
        }

        /// <summary>
        /// �X�e�[�^�X�o�[�ݒ�
        /// </summary>
        /// <param name="mode">0:�����@1:�Ԏ�</param>
        /// <param name="msg">�ݒ肷�郁�b�Z�[�W</param>
        private void SetStatusBarText(int mode, string msg)
        {
            StatusBar.Panels[0].Text = msg;
            switch (mode)
            {
                case 0: // 0:����
                    StatusBar.Panels[0].Appearance.Reset();
                    break;
                case 1: // 1:�Ԏ�
                    StatusBar.Panels[0].Appearance.ForeColor = Color.Red;
                    StatusBar.Panels[0].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    break;
            }
        }

        #region [ �݌ɃO���b�h�C�x���g���� ]
        private void gridStock_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            UltraGridBand band = e.Layout.Bands[0];
            band.UseRowLayout = true;
            band.Indentation = 0;

            band.Columns[_StockTable.SelectionStateColumn.ColumnName].Hidden = true;
            band.Columns[_StockTable.GoodsMakerCdColumn.ColumnName].Hidden = true;
            band.Columns[_StockTable.GoodsNoColumn.ColumnName].Hidden = true;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
            band.Columns[_StockTable.SortDivColumn.ColumnName].Hidden = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
            for (int Index = 0; Index < band.Columns.Count; Index++)
            {
                // �����\���ʒu
                if ((band.Columns[Index].DataType == typeof(int)) ||
                   (band.Columns[Index].DataType == typeof(double)))
                {
                    band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else
                {
                    band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                band.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // �����\���ʒu
                band.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
            ColInfo.SetColInfo( band, _StockTable.SelImageColumn.ColumnName, 0, 0, 10 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
            ColInfo.SetColInfo(band, _StockTable.WarehouseCodeColumn.ColumnName, 2, 0, 50);
            ColInfo.SetColInfo(band, _StockTable.WarehouseNameColumn.ColumnName, 5, 0, 100);
            ColInfo.SetColInfo(band, _StockTable.WarehouseShelfNoColumn.ColumnName, 7, 0, 50);
            ColInfo.SetColInfo(band, _StockTable.ShipmentPosCntColumn.ColumnName, 9, 0, 50);
            ColInfo.SetColInfo(band, _StockTable.MinimumStockCntColumn.ColumnName, 11, 0, 50);
            ColInfo.SetColInfo(band, _StockTable.MaximumStockCntColumn.ColumnName, 13, 0, 50);
            band.Columns[_StockTable.ShipmentPosCntColumn.ColumnName].Format = "###,###,##0.00";
            band.Columns[_StockTable.MinimumStockCntColumn.ColumnName].Format = "###,###,##0.00";
            band.Columns[_StockTable.MaximumStockCntColumn.ColumnName].Format = "###,###,##0.00";
        }

        private void gridStock_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL
            //if (gridStock.ActiveRow != null && gridPartsInfo.ActiveRow != null)
            //{
            //    gridPartsInfo.ActiveRow.Cells[_partsInfo.WarehouseColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseNameColumn.ColumnName].Value;
            //    gridPartsInfo.ActiveRow.Cells[_partsInfo.ShelfColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseShelfNoColumn.ColumnName].Value;
            //    gridPartsInfo.ActiveRow.Cells[_partsInfo.StockCntColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
            //    gridPartsInfo.ActiveRow.Cells[_partsInfo.WarehouseCodeColumn.ColumnName].Value
            //        = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL
            //    //gridStock.ActiveRow.Cells[_StockTable.SelectionStateColumn.ColumnName].Value = true;
            //    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            //    //gridStock.ActiveRow.Cells[_partsInfo.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
            //    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
            //    gridPartsInfo.UpdateData();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
        }

        private void gridStock_BeforeSelectChange(object sender, BeforeSelectChangeEventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 DEL
            //if ( gridStock.Selected.Rows.Count > 0 )
            //{
            //    gridStock.Selected.Rows[0].Cells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
            //    gridStock.Selected.Rows[0].Cells[_partsInfo.SelImageColumn.ColumnName].Value = DBNull.Value;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 DEL
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/27 ADD
        /// <summary>
        /// �݌ɃO���b�h�EEnter�L�[(�_�u���N���b�N)�ɂ��I������
        /// </summary>
        /// <param name="moveFlg"></param>
        private void SetSelectStock( bool moveFlg )
        {
            SetSelectStock( moveFlg, false );
        }
        /// <summary>
        /// �݌ɃO���b�h�EEnter�L�[(�_�u���N���b�N)�ɂ��I������
        /// </summary>
        /// <param name="moveFlg">true:���̍s��I����ԂɁ^false:�Ȃɂ����Ȃ��i�}�E�X�_�u���N���b�N���j</param>
        /// <param name="setTrue">true:�I�����TRUE�ɂ���^�I����Ԃ𔽓]����</param>
        private void SetSelectStock( bool moveFlg, bool setTrue )
        {
            UltraGridRow activeRow = gridStock.ActiveRow;
            if ( activeRow != null )
            {
                CellsCollection activeCells = activeRow.Cells;

                // �I��/��I���̐؂�ւ�
                if ( activeCells[_StockTable.SelImageColumn.ColumnName].Value != DBNull.Value && !setTrue )
                {
                    activeCells[_StockTable.SelImageColumn.ColumnName].Value = DBNull.Value;
                    activeCells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
                }
                else
                {
                    activeCells[_StockTable.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    activeCells[_StockTable.SelectionStateColumn.ColumnName].Value = true;
                }
                _StockTable.AcceptChanges();

                // ���̍s�͑I����������
                # region [���̍s�͑I����������]
                foreach ( UltraGridRow row in gridStock.Rows )
                {
                    if ( row.Equals( activeRow ) == false && row.Cells[_StockTable.SelImageColumn.ColumnName].Value != DBNull.Value )
                    {
                        row.Cells[_StockTable.SelImageColumn.ColumnName].Value = DBNull.Value;
                        row.Cells[_StockTable.SelectionStateColumn.ColumnName].Value = false;
                    }
                }
                # endregion

                // ���i�O���b�h�̍݌ɏ��\�����X�V
                # region [���i�O���b�h�̍݌ɏ��\�����X�V]
                if ( gridPartsInfo.ActiveRow != null )
                {
                    if ( (bool)activeCells[_StockTable.SelectionStateColumn.ColumnName].Value == true )
                    {
                        // ���i�O���b�h�ɍ݌ɏ��\��
                        gridPartsInfo.ActiveRow.Cells[_partsInfo.WarehouseColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseNameColumn.ColumnName].Value;
                        gridPartsInfo.ActiveRow.Cells[_partsInfo.ShelfColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseShelfNoColumn.ColumnName].Value;
                        gridPartsInfo.ActiveRow.Cells[_partsInfo.StockCntColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.ShipmentPosCntColumn.ColumnName].Value;
                        gridPartsInfo.ActiveRow.Cells[_partsInfo.WarehouseCodeColumn.ColumnName].Value
                            = gridStock.ActiveRow.Cells[_StockTable.WarehouseCodeColumn.ColumnName].Value;
                    }
                    else
                    {
                        // ���i�O���b�h�̍݌ɏ����N���A
                        gridPartsInfo.ActiveRow.Cells[_partsInfo.WarehouseColumn.ColumnName].Value = string.Empty;
                        gridPartsInfo.ActiveRow.Cells[_partsInfo.ShelfColumn.ColumnName].Value = string.Empty;
                        gridPartsInfo.ActiveRow.Cells[_partsInfo.StockCntColumn.ColumnName].Value = 0;
                        gridPartsInfo.ActiveRow.Cells[_partsInfo.WarehouseCodeColumn.ColumnName].Value = string.Empty;
                    }
                    gridPartsInfo.UpdateData();
                }
                # endregion
            }
        }
        /// <summary>
        /// �݌ɃO���b�h�E�s�_�u���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridStock_DoubleClickRow( object sender, DoubleClickRowEventArgs e )
        {
            SetSelectStock( false );
        }
        /// <summary>
        /// �݌ɃO���b�h�E�L�[�_�E��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridStock_KeyDown( object sender, KeyEventArgs e )
        {
            switch ( e.KeyCode )
            {
                case Keys.Enter:
                    SetSelectStock( true );
                    break;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/27 ADD
        #endregion

        #region [ �����i������ ]
        // �����i�������ݒ��ʕ\��
        private void lblSoubi_Click(object sender, EventArgs e)
        {
            if (pnlGridSoubi.Visible)
            {
                pnlGridSoubi.Visible = false;
            }
            else
            {
                pnlGridSoubi.Visible = true;
                gridSoubi.Select();
            }
        }

        /// <summary>
        /// �����i���p�O���b�h���ߍ���
        /// </summary>
        private void FillInSoubiGrid()
        {
            List<string> lst = new List<string>();
            List<string> equipGenreLst = new List<string>();

            Infragistics.Win.ValueList vList = null;
            int count = _equipTable.Count;
            UltraGridBand band = gridSoubi.DisplayLayout.Bands[0];
            gridSoubi.BeginUpdate();
            for (int i = 0; i < count; i++)
            {
                if (lst.Contains(_equipTable[i].EquipmentGenreNm) == false)
                {
                    string filter = string.Format("{0}={1}",
                        _orgCar.CEqpDefDspInfo.EquipmentGenreCdColumn.ColumnName, _equipTable[i].EquipmentGenreCd);
                    _orgCar.CEqpDefDspInfo.DefaultView.RowFilter = filter;
                    vList = new Infragistics.Win.ValueList();
                    vList.DisplayStyle = Infragistics.Win.ValueListDisplayStyle.DataValueAndPicture;
                    vList.Key = _equipTable[i].EquipmentGenreNm;
                    for (int j = 0; j < _orgCar.CEqpDefDspInfo.DefaultView.Count; j++)
                    {
                        PMKEN01010E.CEqpDefDspInfoRow row = (PMKEN01010E.CEqpDefDspInfoRow)_orgCar.CEqpDefDspInfo.DefaultView[j].Row;
                        Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem(row.EquipmentName);

                        item.Appearance.Image = EquipmentIconResourceManagement.Equipment_ImageList16.Images[row.EquipmentIconCode];
                        vList.ValueListItems.Add(item);
                        if (row.SelectionState)
                        {
                            vList.SelectedItem = item;
                        }
                    }
                    lst.Add(vList.Key);

                    UltraGridRow gridRow = band.AddNew();
                    gridRow.Cells[0].Value = _equipTable[i].EquipmentGenreNm;
                    //row.Cells[1].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                    gridRow.Cells[1].ValueList = vList;
                    if (vList.SelectedItem != null)
                    {
                        gridRow.Cells[1].Value = vList.SelectedItem.ToString();
                    }
                }
            }
            gridSoubi.EndUpdate();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlGridSoubi.Visible = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isSelectChangeDisabled)
                return;
            GridFiltering();
            gridPartsInfo.Select();
            pnlGridSoubi.Visible = false;
        }
        #endregion

        // 2010/03/15 Add >>>
        /// <summary>
        /// �R���X�g���N�^�ł̏������������C��
        /// </summary>
        /// <param name="dsCar"></param>
        /// <param name="dsParts"></param>
        public void InitialMain2(PMKEN01010E dsCar, PartsInfoDataSet dsParts)
        {
            _orgCar = dsCar;
            _orgDataSet = dsParts;
            SearchCntSetWork cond = dsParts.SearchCondition.SearchCntSetWork;
            //eraNameDispDiv = Convert.ToBoolean(cond.EraNameDispCd1); // 0:����^1:�a��
            //uiControlFlg = Convert.ToBoolean(cond.SearchUICntDivCd); // 0:PM7�X�^�C���^1:PM.NS�X�^�C��
            //>>>2012/02/09
            //substFlg = cond.SubstCondDivCd; // 0:��ւ��Ȃ�  1:��ւ���i�݌ɔ��肠��j 2:��ւ���i�݌ɔ���Ȃ��j
            substFlg = 0;
            //<<<2012/02/09
            userSubstFlg = cond.SubstApplyDivCd;
            //enterFlg = cond.EnterProcDivCd; // 0:PM7, 1:�I�� 2:����ʁi�����ˌ����A�����˃Z�b�g�A�Z�b�g�ˊm��j
            totalAmountDispWay = cond.TotalAmountDispWayCd; // 0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j
            _dsParts = new dsPartsSel();
            _partsInfo = _dsParts.PartsInfo;
            _StockTable = _dsParts.Stock;
            _modelPartsDetail = _dsParts.ModelPartsDetail;
            _selectIndex = dsParts.SelectIndex; // 2011/09/04

            this.InitialThread1(false);
            this.InitialThread2();

            originalRowFilter = _orgDataSet.PartsInfo.DefaultView.RowFilter;
            _partsInfo.DefaultView.Sort = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                                                        _partsInfo.SeriesModelColumn.ColumnName,
                                                        _partsInfo.CategorySignModelColumn.ColumnName,
                                                        _partsInfo.ExhaustGasSignColumn.ColumnName,
                                                        _partsInfo.FullModelFixedNoColumn.ColumnName,
                                                        _partsInfo.PartsQtyColumn.ColumnName,
                                                        _partsInfo.PartsOpNmColumn.ColumnName,
                                                        _partsInfo.NewPrtsNoWithHyphenColumn.ColumnName,
                                                        _partsInfo.CatalogPartsMakerCdColumn.ColumnName,
                                                        _partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName
                                                        );

            #region �J���[�E�g�����E�����ł̍i�荞��

            IsColorData = _colorTable != null && _colorTable.Count >= 1;
            IsTrimData = _trimTable != null && _trimTable.Count >= 1;
            IsEquipData = _equipTable != null && _equipTable.Count >= 1;
            string colorCode = string.Empty;
            string trimCode = string.Empty;
            if (IsColorData)
            {
                PMKEN01010E.ColorCdInfoRow[] row = (PMKEN01010E.ColorCdInfoRow[])_orgCar.ColorCdInfo.Select("SelectionState = true", "", DataViewRowState.CurrentRows);
                if (row.Length > 0)
                {
                    colorCode = row[0].ColorCode;
                }
            }
            if (IsTrimData)
            {
                PMKEN01010E.TrimCdInfoRow[] row = (PMKEN01010E.TrimCdInfoRow[])_orgCar.TrimCdInfo.Select("SelectionState = true", "", DataViewRowState.CurrentRows);
                if (row.Length > 0)
                {
                    trimCode = row[0].TrimCode;
                }
            }
            if (IsEquipData)
            {
                //FillInSoubiGrid();
                //GridFiltering();
            }

            List<long> properNoLstClrTrm = null;
            string innerFilter = string.Empty;
            if (IsColorData && !string.IsNullOrEmpty(colorCode))
            {
                properNoLstClrTrm = new List<long>();
                innerFilter = string.Format("{0} = '{1}'", _colorTable.ColorCdInfoNoColumn.ColumnName, colorCode);

                PartsInfoDataSet.OfrColorInfoRow[] row = (PartsInfoDataSet.OfrColorInfoRow[])_colorTable.Select(innerFilter);
                for (int i = 0; i < row.Length; i++)
                {
                    if (properNoLstClrTrm.Contains(row[i].PartsProperNo) == false)
                        properNoLstClrTrm.Add(row[i].PartsProperNo);
                }
            }

            if (IsTrimData && !string.IsNullOrEmpty(trimCode))
            {
                properNoLstClrTrm = new List<long>();
                innerFilter = string.Format("{0} = '{1}'", _trimTable.TrimCodeColumn.ColumnName, trimCode);

                PartsInfoDataSet.OfrTrimInfoRow[] row = (PartsInfoDataSet.OfrTrimInfoRow[])_trimTable.Select(innerFilter);
                for (int i = 0; i < row.Length; i++)
                {
                    if (properNoLstClrTrm.Contains(row[i].PartsProperNo) == false)
                        properNoLstClrTrm.Add(row[i].PartsProperNo);
                }
            }

            if (properNoLstClrTrm != null && properNoLstClrTrm.Count > 0)
            {
                StringBuilder retRowFilter = new StringBuilder();
                retRowFilter.Append(originalRowFilter);

                if (retRowFilter.Length > 0)
                {
                    retRowFilter.Append(" AND ");
                }
                retRowFilter.Append("PartsUniqueNo in (");

                foreach (long no in properNoLstClrTrm)
                {
                    retRowFilter.Append(no);
                    retRowFilter.Append(", ");
                }
                retRowFilter.Remove(retRowFilter.Length - 2, 2);
                retRowFilter.Append(")");

                _partsInfo.DefaultView.RowFilter = retRowFilter.ToString();
            }
            #endregion

        }

        /// <summary>
        /// ���i�I��
        /// </summary>
        /// <returns></returns>
        public  DialogResult SelectParts()
        {
            DataView dv = _partsInfo.DefaultView;

            //>>>2011/09/04
            if (_selectIndex != -1) return SelectParts(_selectIndex);
            //<<<2011/09/04

            #region �������i���P�����Ȃ�
            if (dv.Count == 1
                // 2011/03/08 >>>
                //&& ( substFlg == 0 || dv[0][_partsInfo.SubstColumn.ColumnName] == null ))
                && ( substFlg == 0 || dv[0][_partsInfo.SubstColumn.ColumnName].Equals(DBNull.Value) ))
                // 2011/03/08 <<<
            {

                int makerCd = (int)dv[0][_partsInfo.CatalogPartsMakerCdColumn.ColumnName];
                // �������i�J�^���O���i�j�̃f�[�^���g�p����B
                string goodsNo = (string)dv[0][_partsInfo.JoinSrcPartsNoColumn.ColumnName];
                SelectionInfo selInfo = new SelectionInfo();
                selInfo.Depth = 0;
                selInfo.Key = 0;
                selInfo.RowGoods = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, goodsNo);
                // �ŐV�i�Ԃ��Z�b�g
                selInfo.RowGoods.NewGoodsNo = (string)dv[0][_partsInfo.PartsNoColumn.ColumnName];
                selInfo.RowGoods.JoinSrcPrtsNo = (string)dv[0][_partsInfo.JoinSrcPartsNoColumn.ColumnName];
                selInfo.RowGoods.SelectionState = true;
                selInfo.Selected = true;
                _orgDataSet.AddSelectionInfo(_orgDataSet.ListSelectionInfo, selInfo.Key, ref selInfo);
                isDialogShown = false;

                // ������񂪂���ꍇ�̓Z�b�g
                if (dv[0][_partsInfo.JoinColumn.ColumnName] != null)
                {
                    _orgDataSet.JoinSrcSelInf = selInfo;
                    _orgDataSet.UIKind = SelectUIKind.Join;
                }
                _orgDataSet.UsrGoodsInfo.RowToProcess = selInfo.RowGoods;

                #region �q�ɂ̐ݒ�
                string orgFilter = _StockTable.DefaultView.RowFilter;
                try
                {
                    // 2011/03/15 >>>
                    //string filter = string.Format("{0}={1} AND {2}='{3}' ",
                    //    _StockTable.GoodsMakerCdColumn.ColumnName, makerCd,
                    //    _StockTable.GoodsNoColumn.ColumnName, goodsNo);
                    // �ŐV�i�Ԃō݌ɂ��`�F�b�N����
                    string filter = string.Format("{0}={1} AND {2}='{3}' ",
                        _StockTable.GoodsMakerCdColumn.ColumnName, makerCd,
                        _StockTable.GoodsNoColumn.ColumnName, selInfo.RowGoods.NewGoodsNo);
                    // 2011/03/15 <<<
                    _StockTable.DefaultView.RowFilter = filter;
                    if (_StockTable.DefaultView.Count > 0)
                    {
                        for (int i = 0; i < _orgDataSet.ListPriorWarehouse.Count; i++)
                        {
                            bool stockExist = false;    // 2010/12/20 Add
                            string warehouseCd = _orgDataSet.ListPriorWarehouse[i].Trim();
                            for (int j = 0; j < _StockTable.DefaultView.Count; j++)
                            {
                                if (warehouseCd.Equals(_StockTable.DefaultView[j][_StockTable.WarehouseCodeColumn.ColumnName]))
                                {
                                    selInfo.WarehouseCode = warehouseCd;
                                    // 2010/12/20 Add >>>
                                    stockExist = true;
                                    break;
                                    // 2010/12/20 Add <<<
                                }
                            }
                            if ( stockExist ) break; // 2010/12/20 Add
                        }
                    }
                }
                finally
                {
                    _StockTable.DefaultView.RowFilter = orgFilter;
                }
                #endregion

                #region �����炭�s�v
                //if (dv[0][_partsInfo.JoinColumn.ColumnName] != null || dv[0][_partsInfo.SetColumn.ColumnName] != null)
                //{
                //    if (uiControlFlg)
                //    {
                //        _orgDataSet.UsrGoodsInfo.RowToProcess = selInfo.RowGoods;

                //        if (dv[0][_partsInfo.JoinColumn.ColumnName] != null)
                //        {
                //            _orgDataSet.JoinSrcSelInf = selInfo;
                //            _orgDataSet.UIKind = SelectUIKind.Join;
                //        }
                //        else
                //        {
                //            _orgDataSet.SetSrcSelInf = selInfo;
                //            _orgDataSet.UIKind = SelectUIKind.Set;
                //        }
                //    }
                //    else
                //    {
                //        selInfo.SelectedPartsNo = (string)dv[0][_partsInfo.PartsNoColumn.ColumnName];
                //    }
                //}
                #endregion

                return DialogResult.OK;
            }
            #endregion

            return DialogResult.None;
        }
        // 2010/03/15 Add <<<

        //>>>2011/09/04
        /// <summary>
        /// ���i�I��(����Index�w��)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public DialogResult SelectParts(int index)
        {
            DataView dv = _partsInfo.DefaultView;

            // 2012/09/14 ADD TAKAGAWA SCM��Q���ǈꗗ��253 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            if (dv.Count <= index) return DialogResult.None;
            // 2012/09/14 ADD TAKAGAWA SCM��Q���ǈꗗ��253 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            #region �������i��Index�w��
            if (substFlg == 0 || dv[index][_partsInfo.SubstColumn.ColumnName] == null)
            {
                int makerCd = (int)dv[index][_partsInfo.CatalogPartsMakerCdColumn.ColumnName];
                // �������i�J�^���O���i�j�̃f�[�^���g�p����B
                string goodsNo = (string)dv[index][_partsInfo.JoinSrcPartsNoColumn.ColumnName];
                SelectionInfo selInfo = new SelectionInfo();
                selInfo.Depth = 0;
                selInfo.Key = 0;
                selInfo.RowGoods = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, goodsNo);
                // �ŐV�i�Ԃ��Z�b�g
                selInfo.RowGoods.NewGoodsNo = (string)dv[index][_partsInfo.PartsNoColumn.ColumnName];
                selInfo.RowGoods.JoinSrcPrtsNo = (string)dv[index][_partsInfo.JoinSrcPartsNoColumn.ColumnName];
                selInfo.RowGoods.SelectionState = true;
                selInfo.Selected = true;
                _orgDataSet.AddSelectionInfo(_orgDataSet.ListSelectionInfo, selInfo.Key, ref selInfo);
                isDialogShown = false;

                // ������񂪂���ꍇ�̓Z�b�g
                if (dv[index][_partsInfo.JoinColumn.ColumnName] != null)
                {
                    _orgDataSet.JoinSrcSelInf = selInfo;
                    _orgDataSet.UIKind = SelectUIKind.Join;
                }
                _orgDataSet.UsrGoodsInfo.RowToProcess = selInfo.RowGoods;

                #region �q�ɂ̐ݒ�
                string orgFilter = _StockTable.DefaultView.RowFilter;
                try
                {
                    string filter = string.Format("{0}={1} AND {2}='{3}' ",
                        _StockTable.GoodsMakerCdColumn.ColumnName, makerCd,
                        _StockTable.GoodsNoColumn.ColumnName, goodsNo);
                    _StockTable.DefaultView.RowFilter = filter;
                    if (_StockTable.DefaultView.Count > 0)
                    {
                        for (int i = 0; i < _orgDataSet.ListPriorWarehouse.Count; i++)
                        {
                            string warehouseCd = _orgDataSet.ListPriorWarehouse[i].Trim();
                            for (int j = 0; j < _StockTable.DefaultView.Count; j++)
                            {
                                if (warehouseCd.Equals(_StockTable.DefaultView[j][_StockTable.WarehouseCodeColumn.ColumnName]))
                                {
                                    selInfo.WarehouseCode = warehouseCd;
                                }
                            }
                        }
                    }
                }
                finally
                {
                    _StockTable.DefaultView.RowFilter = orgFilter;
                }
                #endregion

                #region �����炭�s�v
                //if (dv[0][_partsInfo.JoinColumn.ColumnName] != null || dv[0][_partsInfo.SetColumn.ColumnName] != null)
                //{
                //    if (uiControlFlg)
                //    {
                //        _orgDataSet.UsrGoodsInfo.RowToProcess = selInfo.RowGoods;

                //        if (dv[0][_partsInfo.JoinColumn.ColumnName] != null)
                //        {
                //            _orgDataSet.JoinSrcSelInf = selInfo;
                //            _orgDataSet.UIKind = SelectUIKind.Join;
                //        }
                //        else
                //        {
                //            _orgDataSet.SetSrcSelInf = selInfo;
                //            _orgDataSet.UIKind = SelectUIKind.Set;
                //        }
                //    }
                //    else
                //    {
                //        selInfo.SelectedPartsNo = (string)dv[0][_partsInfo.PartsNoColumn.ColumnName];
                //    }
                //}
                #endregion

                return DialogResult.OK;
            }
            #endregion

            return DialogResult.None;
        }
        //<<<2011/09/04

        // --- ADD m.suzuki 2010/10/26 ---------->>>>>
        # region [�������]
        /// <summary>
        /// �������O���b�h�ւ̐i��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridCondition_Enter( object sender, EventArgs e )
        {
            // �����I�ɕ��i�O���b�h�Ƀt�H�[�J�X�ړ�����
            gridPartsInfo.Focus();
        }
        # endregion

        # region [�J���[�^�g�����^����]
        /// <summary>
        /// �����i�J���[�^�g�����^�����j�R���e�i�i����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitContainer1_Enter( object sender, EventArgs e )
        {
            if ( ColorGrid.Rows.Count > 0 )
            {
                // �J���[
                SetGridFocus( ColorGrid );
            }
            else if ( TrimGrid.Rows.Count > 0 )
            {
                // �g����
                SetGridFocus( TrimGrid );
            }
            else if ( EquipGrid.Rows.Count > 0 )
            {
                // ����
                SetGridFocus( EquipGrid );
            }
            else
            {
                // �����I�ɕ��i�O���b�h�Ƀt�H�[�J�X�ړ�����
                gridPartsInfo.Focus();
            }
        }
        /// <summary>
        /// �O���b�h�ւ̃t�H�[�J�X�Z�b�g�����i�J���[�E�g�����E���� �p�j
        /// </summary>
        /// <param name="grid"></param>
        private void SetGridFocus( UltraGrid grid )
        {
            // �X�V�J�n >>>
            grid.BeginUpdate();

            // �O���b�h���̂Ƀt�H�[�J�X�ړ�
            grid.Focus();

            // �s���A�N�e�B�u�ɂ���
            if ( grid.ActiveRow == null )
            {
                grid.Rows[0].Activate();
            }

            // �s��I����Ԃɂ���
            if ( grid.ActiveRow != null )
            {
                grid.ActiveRow.Selected = true;
            }

            // �X�V�I��<<<
            grid.EndUpdate();
        }
        /// <summary>
        /// �J���[�O���b�h�i����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorGrid_Enter( object sender, EventArgs e )
        {
            if ( ColorGrid.Rows.Count == 0 )
            {
                // �����I�ɕ��i�O���b�h�Ƀt�H�[�J�X�ړ�����
                gridPartsInfo.Focus();
            }
        }
        /// <summary>
        /// �J���[�O���b�h�E�o
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorGrid_Leave( object sender, EventArgs e )
        {
            if ( ColorGrid.Rows.Count > 0 && ColorGrid.ActiveRow != null )
            {
                ColorGrid.ActiveRow.Selected = false;
                ColorGrid.ActiveRow = null;
            }
        }
        /// <summary>
        /// �g�����O���b�h�i����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrimGrid_Enter( object sender, EventArgs e )
        {
            if ( TrimGrid.Rows.Count == 0 )
            {
                // �����I�ɕ��i�O���b�h�Ƀt�H�[�J�X�ړ�����
                gridPartsInfo.Focus();
            }
        }
        /// <summary>
        /// �g�����O���b�h�E�o
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrimGrid_Leave( object sender, EventArgs e )
        {
            if ( TrimGrid.Rows.Count > 0 && TrimGrid.ActiveRow != null )
            {
                TrimGrid.ActiveRow.Selected = false;
                TrimGrid.ActiveRow = null;
            }
        }
        /// <summary>
        /// �����O���b�h�i����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EquipGrid_Enter( object sender, EventArgs e )
        {
            if ( EquipGrid.Rows.Count == 0 )
            {
                // �����I�ɕ��i�O���b�h�Ƀt�H�[�J�X�ړ�����
                gridPartsInfo.Focus();
            }
        }
        /// <summary>
        /// �����O���b�h�E�o
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EquipGrid_Leave( object sender, EventArgs e )
        {
            if ( EquipGrid.Rows.Count > 0 && EquipGrid.ActiveRow != null )
            {
                EquipGrid.ActiveRow.Selected = false;
                EquipGrid.ActiveRow = null;
            }
        }
        # endregion

        # region [�݌�]
        /// <summary>
        /// �݌ɃO���b�h�i����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridStock_Enter( object sender, EventArgs e )
        {
            if ( gridStock.Rows.Count == 0 )
            {
                // �����I�ɕ��i�O���b�h�Ƀt�H�[�J�X�ړ�����
                gridPartsInfo.Focus();
            }
        }
        # endregion
        // --- ADD m.suzuki 2010/10/26 ----------<<<<<

        // ADD 杍^ 2014/09/01 FOR Redmine#43289�@--- >>>
        /// <summary>
        /// XML�t�@�C����ۑ�����
        /// </summary>
        /// <param name="carInfoFlg">�ԗ����{�^���\���t���O</param>
        /// <param name="fileName">�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : XML�t�@�C����ۑ��������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2014/09/01</br>
        /// </remarks>
        private void Serialize(bool carInfoFlg, string fileName)
        {
            UserSettingController.SerializeUserSetting(carInfoFlg, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
        }


        /// <summary>
        /// XML�t�@�C����ǂݏ���
        /// </summary>
        /// <param name="fileName">�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : XML�t�@�C����ǂݏ������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2014/09/01</br>
        /// </remarks>
        private bool Deserialize(string fileName)
        {
            bool carInfoFlg = false;

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)))
            {
                try
                {
                    carInfoFlg = UserSettingController.DeserializeUserSetting<bool>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
                }
                catch (System.InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
                }
            }

            return carInfoFlg;
        }

        /// <summary>
        /// �ԗ�����\���ؑ֏���
        /// </summary>
        private void SetPnlCarInfoVisible(bool carInfoVisible)
        {
            if (carInfoVisible)
            {
                this.gridCondition.Location = new System.Drawing.Point(0, this.ultraGroupBox1.Height + this.pnl_CarInfo.Height);
                this.gridPartsInfo.Location = new System.Drawing.Point(0, this.ultraGroupBox1.Height + this.gridCondition.Height + this.pnl_CarInfo.Height);
                // --- ADD 2014/11/04 T.Miyamoto �d�|�ꗗ ��2577 ------------------------------>>>>>
                this.gridPartsInfo.Height = panel1.Height - (this.ultraGroupBox1.Height + this.pnl_CarInfo.Height + this.gridCondition.Height);
                // --- ADD 2014/11/04 T.Miyamoto �d�|�ꗗ ��2577 ------------------------------<<<<<
            }
            else
            {
                this.gridCondition.Location = new System.Drawing.Point(0, this.ultraGroupBox1.Height);
                this.gridPartsInfo.Location = new System.Drawing.Point(0, this.ultraGroupBox1.Height + this.gridCondition.Height);
                // --- UPD 2014/11/04 T.Miyamoto �d�|�ꗗ ��2577 ------------------------------>>>>>
                //this.gridPartsInfo.Height = this.gridPartsInfo.Height + this.pnl_CarInfo.Height;
                this.gridPartsInfo.Height = panel1.Height - (this.ultraGroupBox1.Height + this.gridCondition.Height);
                // --- UPD 2014/11/04 T.Miyamoto �d�|�ꗗ ��2577 ------------------------------<<<<<
            }
        }

        /// <summary>
        /// �a��N�擾�����iH20��"20"�݂̂��擾����j
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static int GetDateFW(int date)
        {
            // �a������擾
            string date_gg = TDateTime.LongDateToString("gg", date);  // H
            string date_exggyy = TDateTime.LongDateToString("exggyy", date);  // H20

            // "H20" ���� "H" ����菜���� "20" ���擾����
            return ToInt(date_exggyy.Substring(date_gg.Length, date_exggyy.Length - date_gg.Length));

        }

        /// <summary>
        /// ���l�ϊ�����
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static int ToInt(string text)
        {
            try
            {
                return Int32.Parse(text);
            }
            catch
            {
                return 0;
            }
        }
        // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- <<<
    }
}