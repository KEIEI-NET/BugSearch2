//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ���i�݌Ƀ}�X�^
// �v���O�����T�v   : ���i�݌ɂ̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : caohh
// �C �� ��  2011/08/02  �C�����e : NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : wangf
// �C �� ��  2011/09/15  �C�����e : �Č��ꗗ �A��265 �ł̃e�X�g�s��ɂ��Ă̏C�� FOR redmine #25013
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhuhh 
// �C �� ��  2012/11/21  �C�����e : 2013/01/16�z�M�� redmine #33230  
//                                : �|���ݒ�}�X�^���ɘ_���폜���R�[�h�����݂����ԂŁA
//                                  �����i�̊|���̓o�^�����悤�Ƃ��Ă��邽�߂ɔ������Ă���s��̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 11170129-00  �쐬�S�� : �����M
// �C �� �� 2015/09/10   �C�����e : Redmine#47026 ���i�݌Ƀ}�X�^�̏�Q�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370033-00 �쐬�S�� : ���O
// �X �V ��  2018/10/26�@�C�����e : Redmine#49732 ����UP���Ƒe���m�ۗ��̐ݒ肪������Ή�                       
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �P�i���������̓R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�}�X�����̒P�i���������͂��s���R���g���[���N���X�ł��B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2008.09.09</br>
    /// <br>UpdateNote : 2008/12/15 30462 �s�V�m���@�o�O�C��</br>
    /// <br>           : �O���b�g����Tab�L�[�ł̈ړ��Ή��B</br>
    /// <br>UpdateNote : 2009/01/09 30414 �E �K�j�@��QID:9903�Ή�</br>
    /// <br>UpdateNote : 2009/02/10 30414 �E �K�j�@��QID:11264�Ή�</br>
    /// <br>UpdateNote : 2009/03/18 30414 �E �K�j�@��QID:12530�Ή�</br>
    /// <br>UpdateNote : 2009/11/20 30434 �H���b�D 3�����Ή� ���Ӑ�|���O���[�v����</br>
    /// <br>UpdateNote : 2009/11/20 30434 �H���b�D ��QID:14598�Ή�</br>
    /// <br>UpdateNote : 2010/01/18 30434 �H���b�D ��QID:14896�Ή�</br>
    /// <br>Update Note: 2010/06/08 �k���r �s��̑Ή�</br>
    /// <br>Update Note: 2011/08/02 caohh �A��265 ���[�U�[�ݒ��ʂ̐V�K�ǉ��Ή�</br>
    /// <br>UpdateNote : 2012/11/21 zhuhh</br>
    /// <br>           : 2013/01/16�z�M��</br>
    /// <br>           : redmine #33230  �|���ݒ�}�X�^���ɘ_���폜���R�[�h�����݂����ԂŁA</br>
    /// <br>           : �����i�̊|���̓o�^�����悤�Ƃ��Ă��邽�߂ɔ�������</br>
    /// <br>           : ����s��̑Ή�</br>
    /// <br>Update Note: 2015/09/10 �����M</br>
    /// <br>�Ǘ��ԍ�   : 11170129-00</br>
    /// <br>             Redmine#47026 ���i�݌Ƀ}�X�^�̏�Q�Ή�</br>
    /// <br>Update Note: 2018/10/26 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11370033-00</br>
    /// <br>             Redmine#49732 ����UP���Ƒe���m�ۗ��̐ݒ肪������Ή�</br>
    /// </remarks>
    public partial class MAKHN09280UC : UserControl
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        //private GoodsAcs _goodsAcs;                                         // ���i�}�X�^�A�N�Z�X�N���X
        private DataTable _salesPriceRateTable; // ���i���i�f�[�^�e�[�u��
        private GoodsUnitData _goodsUnitData;                               // ���i�A���f�[�^�N���X
        private DateTime _beforePriceStartDate = DateTime.MinValue;
        //private double _beforeListPrice = 0;
        //private double _beforeStockRate = 0;
        //private double _beforeSalesUnitCost = 0;
        private DateTime _beforeOfferDate = DateTime.MinValue;
        private bool _beforeCellUpdateCancel = false;
        //private List<Rate> _rateList;
        private Dictionary<int, Rate> _rateBufferDic;
        // 2009.03.03 30413 ���� ���Ӑ�|���f���̂��L���b�V�� >>>>>>START
        private Dictionary<int, string> _custRateGrpNameDic;
        // 2009.03.03 30413 ���� ���Ӑ�|���f���̂��L���b�V�� <<<<<<END

        // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
        /// <summary>���Ӑ�|���O���[�v�̎w��Ȃ��̊|�����̃L���v�V����</summary>
        private const string ALL_RATE_GROUP_CAPTION = "ALL";
        /// <summary>���Ӑ�|���O���[�v�̎w��Ȃ��̓��Ӑ�|���O���[�v�R�[�h</summary>
        private const int ALL_RATE_GROUP_CODE = -1;
        /// <summary>���Ӑ�|���O���[�v�̎w��Ȃ��̓��Ӑ�|���O���[�v�R�[�h����</summary>
        private const string ALL_RATE_GROUP_CODE_NAME = "�w��Ȃ�";

        #region �|���ݒ�敪

        /// <summary>�ʏ�̊|���ݒ�敪</summary>
        private const string NORMAL_RATE_SETTING_DIVIDE = "4A"; // ���Ӑ�|���O���[�v+�i��+���[�J�[
        /// <summary>����Ȋ|���ݒ�敪</summary>
        private const string SPECIAL_RATE_SETTING_DIVIDE= "6A"; // �w��Ȃ�+�i��+���[�J�[
        /// <summary>�ΏۂƂ���|���ݒ�敪</summary>
        private string[] _targetRateSettingDivides = new string[] { NORMAL_RATE_SETTING_DIVIDE, SPECIAL_RATE_SETTING_DIVIDE };
        /// <summary>�ΏۂƂ���|���ݒ�敪���擾���܂��B</summary>
        private string[] TargetRateSettingDivides { get { return _targetRateSettingDivides; } }

        /// <summary>
        /// �ΏۂƂ���|���ݒ�敪�ł��邩���f���܂��B
        /// </summary>
        /// <param name="rateSettingDivide">�|���ݒ�敪</param>
        /// <returns>
        /// <c>true</c> :�ΏۂƂ���|���ݒ�敪�ł��B<br/>
        /// <c>false</c>:�ΏۂƂ���|���ݒ�敪�ł͂���܂���B
        /// </returns>
        private bool IsTargetRateSettingDivide(string rateSettingDivide)
        {
            return Array.Exists(TargetRateSettingDivides, delegate(string item)
            {
                return item.Equals(rateSettingDivide);
            });
        }

        /// <summary>
        /// �ʏ�̊|���ݒ�敪�ł��邩���f���܂��B
        /// </summary>
        /// <param name="rateSettingDivide">�|���ݒ�敪</param>
        /// <returns>
        /// <c>true</c> :�ʏ�̊|���ݒ�敪�ł��B<br/>
        /// <c>false</c>:�ʏ�̊|���ݒ�敪�ł͂���܂���B
        /// </returns>
        private static bool IsNormalRateSettingDivide(string rateSettingDivide)
        {
            return rateSettingDivide.Equals(NORMAL_RATE_SETTING_DIVIDE);
        }

        #endregion // �|���ݒ�敪
        // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

        private bool _parentEnabled = true;

        private const string ct_Col_CustRateGrp_00 = "CustRateGrp_00";
        private const string ct_Col_CustRateGrp_01 = "CustRateGrp_01";
        private const string ct_Col_CustRateGrp_02 = "CustRateGrp_02";
        private const string ct_Col_CustRateGrp_03 = "CustRateGrp_03";
        private const string ct_Col_CustRateGrp_04 = "CustRateGrp_04";
        private const string ct_Col_CustRateGrp_05 = "CustRateGrp_05";
        private const string ct_Col_CustRateGrp_06 = "CustRateGrp_06";
        private const string ct_Col_CustRateGrp_07 = "CustRateGrp_07";
        private const string ct_Col_CustRateGrp_08 = "CustRateGrp_08";
        private const string ct_Col_CustRateGrp_09 = "CustRateGrp_09";
        private const string ct_Col_CustRateGrp_10 = "CustRateGrp_10";
        private const string ct_Col_CustRateGrp_11 = "CustRateGrp_11";
        private const string ct_Col_CustRateGrp_12 = "CustRateGrp_12";
        private const string ct_Col_CustRateGrp_13 = "CustRateGrp_13";
        private const string ct_Col_CustRateGrp_14 = "CustRateGrp_14";
        private const string ct_Col_CustRateGrp_15 = "CustRateGrp_15";
        private const string ct_Col_CustRateGrp_16 = "CustRateGrp_16";
        private const string ct_Col_CustRateGrp_17 = "CustRateGrp_17";
        private const string ct_Col_CustRateGrp_18 = "CustRateGrp_18";
        private const string ct_Col_CustRateGrp_19 = "CustRateGrp_19";

        // 2009.03.03 30413 ���� �w�b�_�[�𓾈Ӑ�|���f�̃R�[�h�Ɩ���2�i�Ƃ��� >>>>>>START
        private const string ct_Col_CustRateGrp_20 = "CustRateGrp_20";
        private const string ct_Col_CustRateGrp_21 = "CustRateGrp_21";
        private const string ct_Col_CustRateGrp_22 = "CustRateGrp_22";
        private const string ct_Col_CustRateGrp_23 = "CustRateGrp_23";
        private const string ct_Col_CustRateGrp_24 = "CustRateGrp_24";
        private const string ct_Col_CustRateGrp_25 = "CustRateGrp_25";
        private const string ct_Col_CustRateGrp_26 = "CustRateGrp_26";
        private const string ct_Col_CustRateGrp_27 = "CustRateGrp_27";
        private const string ct_Col_CustRateGrp_28 = "CustRateGrp_28";
        private const string ct_Col_CustRateGrp_29 = "CustRateGrp_29";
        private const string ct_Col_CustRateGrp_30 = "CustRateGrp_30";
        private const string ct_Col_CustRateGrp_31 = "CustRateGrp_31";
        private const string ct_Col_CustRateGrp_32 = "CustRateGrp_32";
        private const string ct_Col_CustRateGrp_33 = "CustRateGrp_33";
        private const string ct_Col_CustRateGrp_34 = "CustRateGrp_34";
        private const string ct_Col_CustRateGrp_35 = "CustRateGrp_35";
        private const string ct_Col_CustRateGrp_36 = "CustRateGrp_36";
        private const string ct_Col_CustRateGrp_37 = "CustRateGrp_37";
        private const string ct_Col_CustRateGrp_38 = "CustRateGrp_38";
        private const string ct_Col_CustRateGrp_39 = "CustRateGrp_39";
        // 2009.03.03 30413 ���� �w�b�_�[�𓾈Ӑ�|���f�̃R�[�h�Ɩ���2�i�Ƃ��� <<<<<<END

        // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
        // ���Ӑ�|���O���[�v�̎w��Ȃ��f�[�^���������߁A2��(�������A����)�ǉ�
        private const string ct_Col_CustRateGrp_40 = "CustRateGrp_40";
        private const string ct_Col_CustRateGrp_41 = "CustRateGrp_41";
        // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
        // DEL 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
        // �������̏o����|���O���[�v�R�[�h�̐� (0�`ct_RateGroupCount-1���Ώ�)
        //private const int ct_RateGroupCount = 20;
        // DEL 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
        // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
        // ���Ӑ�|���O���[�v�̎w��Ȃ��f�[�^���������߁A20��21�ɕύX
        private const int ct_RateGroupCount = 21;
        // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        public MAKHN09280UC()
        {
            InitializeComponent();

            //this._goodsAcs = new GoodsAcs();
            this._salesPriceRateTable = this.CreateSalesPriceRateTable();
            //this._goodsUnitData = new GoodsUnitData();

            _rateBufferDic = new Dictionary<int, Rate>();
        }
        /// <summary>
        /// �|���e�[�u������
        /// </summary>
        /// <returns></returns>
        private DataTable CreateSalesPriceRateTable()
        {
            DataTable table = new DataTable();

            //--------------------------------------
            // �J�����ݒ菉����
            //--------------------------------------
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_00, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_01, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_02, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_03, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_04, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_05, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_06, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_07, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_08, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_09, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_10, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_11, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_12, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_13, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_14, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_15, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_16, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_17, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_18, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_CustRateGrp_19, typeof( double ) ) );

            // 2009.03.03 30413 ���� �w�b�_�[�𓾈Ӑ�|���f�̃R�[�h�Ɩ���2�i�Ƃ��� >>>>>>START
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_20, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_21, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_22, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_23, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_24, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_25, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_26, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_27, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_28, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_29, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_30, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_31, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_32, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_33, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_34, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_35, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_36, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_37, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_38, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_39, typeof(double)));
            // 2009.03.03 30413 ���� �w�b�_�[�𓾈Ӑ�|���f�̃R�[�h�Ɩ���2�i�Ƃ��� <<<<<<END

            // �����l�̃Z�b�g(DBNull�ɂ��G���[�h�~)
            table.Columns[ct_Col_CustRateGrp_00].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_01].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_02].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_03].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_04].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_05].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_06].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_07].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_08].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_09].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_10].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_11].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_12].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_13].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_14].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_15].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_16].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_17].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_18].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_19].DefaultValue = 0;

            // 2009.03.03 30413 ���� �w�b�_�[�𓾈Ӑ�|���f�̃R�[�h�Ɩ���2�i�Ƃ��� >>>>>>START
            table.Columns[ct_Col_CustRateGrp_20].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_21].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_22].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_23].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_24].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_25].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_26].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_27].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_28].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_29].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_30].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_31].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_32].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_33].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_34].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_35].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_36].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_37].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_38].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_39].DefaultValue = 0;
            // 2009.03.03 30413 ���� �w�b�_�[�𓾈Ӑ�|���f�̃R�[�h�Ɩ���2�i�Ƃ��� <<<<<<END

            // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
            // ���Ӑ�|���O���[�v�̎w��Ȃ��f�[�^���������߁A2��(�������A����)�ǉ�
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_40, typeof(double)));
            table.Columns.Add(new DataColumn(ct_Col_CustRateGrp_41, typeof(double)));
            table.Columns[ct_Col_CustRateGrp_40].DefaultValue = 0;
            table.Columns[ct_Col_CustRateGrp_41].DefaultValue = 0;
            // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

            //--------------------------------------
            // ��s�~�Q�ǉ�
            //--------------------------------------
            table.Rows.Add( table.NewRow() );   // ������
            table.Rows.Add( table.NewRow() );   // �����z

            return table;
        }

        // ===================================================================================== //
        // �萔
        // ===================================================================================== //

        // ===================================================================================== //
        // �f���Q�[�g
        // ===================================================================================== //
        /// <summary>
        /// ���i���ݒ�f���Q�[�g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="rowNo"></param>
        internal delegate void SettingGoodsPriceEventHandler(object sender, int rowNo);
        
        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        /// <summary>�O���b�h�ŏ�ʍs�L�[�_�E���C�x���g</summary>
        internal event EventHandler GridKeyDownTopRow;

        /// <summary>�O���b�h�ŉ��w�s�L�[�_�E���C�x���g</summary>
        internal event EventHandler GridKeyDownButtomRow;

        /// <summary>���i���ݒ�C�x���g</summary>
        internal event SettingGoodsPriceEventHandler SettingGoodsPrice;
        
        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        /// <summary>
        /// ���i�A���f�[�^�N���X
        /// </summary>
        public GoodsUnitData GoodsUnitData
        {
            get { return this._goodsUnitData; }
            set { this._goodsUnitData = value; }
        }

        //public List<Rate> RateList
        //{
        //    get { return this._rateList; }
        //    set { this._rateList = value; }
        //}

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        /// <summary>
        /// �O���b�h�L�[�}�b�s���O�ݒ菈��
        /// </summary>
        /// <param name="grid">�ݒ�Ώۂ̃O���b�h</param>
        private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;

            //----- Enter�L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_UnitSalesPriceInfo.KeyActionMappings.Add(enterMap);

            //----- Shift + Enter�L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true);
            this.uGrid_UnitSalesPriceInfo.KeyActionMappings.Add(enterMap);

            // --- DEL 2009/03/18 ��QID:12530�Ή�------------------------------------------------------>>>>>
            ////----- ���L�[
            //enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
            //    Keys.Up,
            //    Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
            //    Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
            //    Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
            //    Infragistics.Win.SpecialKeys.All,
            //    0,
            //    true);
            //this.uGrid_UnitSalesPriceInfo.KeyActionMappings.Add(enterMap);
            // --- DEL 2009/03/18 ��QID:12530�Ή�------------------------------------------------------<<<<<

            //----- ���L�[ (�ŏ�i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_UnitSalesPriceInfo.KeyActionMappings.Add(enterMap);

            //----- ���L�[ (�ŉ��i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_UnitSalesPriceInfo.KeyActionMappings.Add(enterMap);

            // --- DEL 2009/03/18 ��QID:12530�Ή�------------------------------------------------------>>>>>
            ////----- ���L�[
            //enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
            //    Keys.Down,
            //    Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
            //    Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
            //    Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
            //    Infragistics.Win.SpecialKeys.All,
            //    0,
            //    true);
            //this.uGrid_UnitSalesPriceInfo.KeyActionMappings.Add(enterMap);
            // --- DEL 2009/03/18 ��QID:12530�Ή�------------------------------------------------------<<<<<

            //----- �O�ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_UnitSalesPriceInfo.KeyActionMappings.Add(enterMap);

            //----- ���ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_UnitSalesPriceInfo.KeyActionMappings.Add(enterMap);
        }

        /// <summary>
        /// Return�L�[�_�E������
        /// </summary>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        internal bool ReturnKeyDown()
        {
            if (this.uGrid_UnitSalesPriceInfo.ActiveCell == null) return false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_UnitSalesPriceInfo.ActiveCell;
            int rowIndex = cell.Row.Index;

            this.uGrid_UnitSalesPriceInfo.BeginUpdate();

            this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

            // �O���b�h�Z���ݒ菈��
            this.SettingGridRow(rowIndex);

            try
            {
                bool canMove = true;

                if ( cell.Column.Key != ct_Col_CustRateGrp_19 )
                {
                    // [00]�`[18]��
                    if ( this._beforeCellUpdateCancel )
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // �����͉\�Z���ړ�����
                        canMove = this.MoveNextAllowEditCell( false );
                    }
                }
                else
                {
                    // �ŏI[19]��
                    // ADD 2008/12/15 �s��Ή�[8733] ---------->>>>>
                    if (this._beforeCellUpdateCancel)
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // �����͉\�Z���ړ�����
                        canMove = this.MoveNextAllowEditCell(false);
                    }
                    // ADD 2008/12/15 �s��Ή�[8733] ----------<<<<<
                }

                ////------------------------------------------------------------
                //// ���i�J�n��
                ////------------------------------------------------------------
                //if (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateColumn.ColumnName)
                //{
                //    if (this._beforeCellUpdateCancel)
                //    {
                //        this._beforeCellUpdateCancel = false;
                //    }
                //    else
                //    {
                //        // �����͉\�Z���ړ�����
                //        canMove = this.MoveNextAllowEditCell(false);
                //    }
                //}
                ////------------------------------------------------------------
                //// �W�����i
                ////------------------------------------------------------------
                //else if (cell.Column.Key == this._goodsPriceDataTable.ListPriceColumn.ColumnName)
                //{
                //    if (this._beforeCellUpdateCancel)
                //    {
                //        this._beforeCellUpdateCancel = false;
                //    }
                //    else
                //    {
                //        // �����͉\�Z���ړ�����
                //        canMove = this.MoveNextAllowEditCell(false);
                //    }
                //}
                ////------------------------------------------------------------
                //// �d����
                ////------------------------------------------------------------
                //else if (cell.Column.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName)
                //{
                //    if (this._beforeCellUpdateCancel)
                //    {
                //        this._beforeCellUpdateCancel = false;
                //    }
                //    else
                //    {
                //        // �����͉\�Z���ړ�����
                //        canMove = this.MoveNextAllowEditCell(false);
                //    }
                //}
                ////------------------------------------------------------------
                //// ���P��
                ////------------------------------------------------------------
                //else if (cell.Column.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName)
                //{
                //    if (this._beforeCellUpdateCancel)
                //    {
                //        this._beforeCellUpdateCancel = false;
                //    }
                //    else
                //    {
                //        // �����͉\�Z���ړ�����
                //        canMove = this.MoveNextAllowEditCell(false);
                //    }
                //}
                //else
                //{
                //    // �����͉\�Z���ړ�����
                //    canMove = this.MoveNextAllowEditCell(false);
                //}
                return canMove;
            }
            finally
            {
                this.uGrid_UnitSalesPriceInfo.EndUpdate();
            }
        }

        
        // ADD 2008/12/15 �s��Ή�[8733] ---------->>>>>
        internal bool ShiftReturnKeyDown()
        {
            if (this.uGrid_UnitSalesPriceInfo.ActiveCell == null) return false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_UnitSalesPriceInfo.ActiveCell;
            int rowIndex = cell.Row.Index;

            this.uGrid_UnitSalesPriceInfo.BeginUpdate();

            this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

            // �O���b�h�Z���ݒ菈��
            this.SettingGridRow(rowIndex);

            try
            {
                bool canMove = true;

                if ( this._beforeCellUpdateCancel )
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // �����͉\�Z���ړ�����
                        canMove = this.MovePrevAllowEditCell(false);
                    }
                return canMove;
            }
            finally
            {
                this.uGrid_UnitSalesPriceInfo.EndUpdate();
            }
        }

        /// <summary>
        /// �O���͉\�Z���ړ�����
        /// </summary>
        /// <param name="currentCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        private bool MovePrevAllowEditCell(bool activeCellCheck)
        {
            this.uGrid_UnitSalesPriceInfo.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_UnitSalesPriceInfo.ActiveCell != null))
            {
                if ((!this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.Hidden) &&
                    (this.uGrid_UnitSalesPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {

                performActionResult = this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);
                
                if (performActionResult)
                {
                    if ((this.uGrid_UnitSalesPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                    else
                    {
                        moved = false;
                    }
                }
                else
                {
                    break;
                }
            }

            if (moved)
            {
                this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.uGrid_UnitSalesPriceInfo.ResumeLayout();
            return performActionResult;
        }
        // ADD 2008/12/15 �s��Ή�[8733] ----------<<<<<

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="currentCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            this.uGrid_UnitSalesPriceInfo.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_UnitSalesPriceInfo.ActiveCell != null))
            {
                if ((!this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.Hidden) &&
                    (this.uGrid_UnitSalesPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
                //if (this.uGrid_UnitSalesPriceInfo.ActiveCell != null)
                //{
                //    int editMode = (int)this.uGrid_UnitSalesPriceInfo.Rows[this.uGrid_UnitSalesPriceInfo.ActiveCell.Row.Index].Cells[this._salesDetailDataTable.EditStatusColumn.ColumnName].Value;

                //    if ((editMode == StockSlipInputAcs.ctEDITSTATUS_AllDisable) || (editMode == StockSlipInputAcs.ctEDITSTATUS_AllReadOnly))
                //    {
                //        performActionResult = this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextRow);

                //        if ((performActionResult) && (this.uGrid_UnitSalesPriceInfo.ActiveRow != null))
                //        {
                //            int index = this.uGrid_UnitSalesPriceInfo.ActiveRow.Index;

                //            if (!(this.uGrid_UnitSalesPriceInfo.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsNoColumn.ColumnName].Hidden))
                //            {
                //                this.uGrid_UnitSalesPriceInfo.ActiveCell = this.uGrid_UnitSalesPriceInfo.Rows[index].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName];
                //            }
                //            else
                //            {
                //                this.uGrid_UnitSalesPriceInfo.ActiveCell = this.uGrid_UnitSalesPriceInfo.Rows[index].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName];
                //            }

                //            // �ċA����
                //            this.MoveNextAllowEditCell(true);

                //            return true;
                //        }
                //    }
                //}

                performActionResult = this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                //performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);

                if (performActionResult)
                {
                    if ((this.uGrid_UnitSalesPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                    else
                    {
                        moved = false;
                    }
                }
                else
                {
                    break;
                }
            }

            if (moved)
            {
                this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.uGrid_UnitSalesPriceInfo.ResumeLayout();
            return performActionResult;
        }

        /// <summary>
        /// ���i���ݒ�C�x���g�R�[������
        /// </summary>
        /// <param name="rowNo"></param>
        private void SettingGoodsPriceEventCall(int rowNo)
        {
            if ((this.SettingGoodsPrice != null) && (rowNo != 0))
            {
                this.SettingGoodsPrice(this, rowNo);
            }
        }

        /// <summary>
        /// ActiveRow�C���f�b�N�X�擾����
        /// </summary>
        /// <returns>ActiveRow�C���f�b�N�X</returns>
        private int GetActiveRowIndex()
        {
            if (this.uGrid_UnitSalesPriceInfo.ActiveCell != null)
            {
                return this.uGrid_UnitSalesPriceInfo.ActiveCell.Row.Index;
            }
            else if (this.uGrid_UnitSalesPriceInfo.ActiveRow != null)
            {
                return this.uGrid_UnitSalesPriceInfo.ActiveRow.Index;
            }
            else
            {
                return -1;
            }
        }

        ///// <summary>
        ///// ActiveRow�̍s�ԍ��擾����
        ///// </summary>
        ///// <returns></returns>
        //internal int GetActiveRowRowNo()
        //{
        //    int rowIndex = this.GetActiveRowIndex();
        //    if (rowIndex < 0) return -1;

        //    return this._goodsPriceDataTable[rowIndex].RowNo;
        //}

        /// <summary>
        /// ���׃O���b�h�E�s�P�ʂł̃Z���ݒ�
        /// </summary>
        /// <param name="rowIndex">�Ώۍs�C���f�b�N�X</param>
        /// <param name="salesSlip">�d���f�[�^�N���X�I�u�W�F�N�g</param>
        internal void SettingGridRow(int rowIndex)
        {
            if (this._salesPriceRateTable.Rows.Count == 0) return;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_UnitSalesPriceInfo.DisplayLayout.Bands[0];
            if (editBand == null) return;

            //// ���i�J�n��
            //DateTime priceStartDate = this._goodsPriceDataTable[rowIndex].PriceStartDate;
            //// �񋟓��t
            //DateTime offerDate = this._goodsPriceDataTable[rowIndex].OfferDate;

            //// �w��s�̑S�Ă̗�ɑ΂��Đݒ���s���B
            //foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            //{

            //    // �Z�������擾
            //    Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_UnitSalesPriceInfo.Rows[rowIndex].Cells[col];
            //    if (cell == null) continue;

            //    //------------------------------------------------
            //    // �Z����Ԑݒ�
            //    //------------------------------------------------
            //    if ((col.Key == this._goodsPriceDataTable.ListPriceColumn.ColumnName) ||
            //        (col.Key == this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName) ||
            //        (col.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName) ||
            //        (col.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName))
            //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/04 DEL
            //        //(col.Key == this._goodsPriceDataTable.OfferDateColumn.ColumnName)
            //      // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/04 DEL
            //    {
            //        if (priceStartDate == DateTime.MinValue)
            //        {
            //            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled; // �g�p�s��
            //        }
            //        else
            //        {
            //            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // �ҏW�\
            //        }
            //    }
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/04 ADD
            //    if ( col.Key == this._goodsPriceDataTable.OfferDateColumn.ColumnName )
            //    {
            //        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled; // �g�p�s��
            //    }
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/04 ADD

            //    //------------------------------------------------
            //    // �����v�f�̃e�L�X�g�J���[�ݒ�
            //    //------------------------------------------------
            //    // ���i�J�n��
            //    if (col.Key == this._goodsPriceDataTable.PriceStartDateColumn.ColumnName)
            //    {
            //        if (priceStartDate == DateTime.MinValue)
            //        {
            //            cell.Appearance.ForeColor = Color.Transparent;
            //        }
            //        else
            //        {
            //            cell.Appearance.ForeColor = this.uGrid_UnitSalesPriceInfo.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
            //        }
            //    }
            //    // �I�[�v�����i�敪
            //    if (col.Key == this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName)
            //    {
            //        if (priceStartDate == DateTime.MinValue)
            //        {
            //            cell.Appearance.ForeColor = Color.Transparent;
            //            cell.Appearance.ForeColorDisabled = Color.Transparent;
            //        }
            //        else
            //        {
            //            cell.Appearance.ForeColor = this.uGrid_UnitSalesPriceInfo.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
            //            cell.Appearance.ForeColorDisabled = this.uGrid_UnitSalesPriceInfo.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
            //        }
            //    }
            //    // �񋟓��t
            //    if ( col.Key == this._goodsPriceDataTable.OfferDateColumn.ColumnName )
            //    {
            //        if ( offerDate == DateTime.MinValue )
            //        {
            //            cell.Appearance.ForeColor = Color.Transparent;
            //            cell.Appearance.ForeColorDisabled = Color.Transparent;
            //        }
            //        else
            //        {
            //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/04 DEL
            //            //cell.Appearance.ForeColor = this.uGrid_UnitSalesPriceInfo.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
            //            //cell.Appearance.ForeColorDisabled = this.uGrid_UnitSalesPriceInfo.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
            //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/04 DEL
            //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/04 ADD
            //            cell.Appearance.ForeColor = Color.Black;
            //            cell.Appearance.ForeColorDisabled = Color.Black;
            //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/04 ADD
            //        }
            //    }
            //}
        }

        // ===================================================================================== //
        // �e�R���g���[���C�x���g����
        // ===================================================================================== //
        /// <summary>
        /// Load�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAKHN09280UC_Load(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 DEL
            //if ( (this._goodsUnitData.GoodsNo == string.Empty) )
            //{
            //    //this._salesPriceRateTable.Rows.Clear();
            //    this.ClearSalesPriceRateTable();

            //    this.uGrid_UnitSalesPriceInfo.DataSource = this._salesPriceRateTable;

            //    //this._goodsAcs.ClearGoodsPriceDataTable();
            //}
            //else
            //{
            //    this.uGrid_UnitSalesPriceInfo.DataSource = this._salesPriceRateTable;
            //}


            //// �L�[�}�b�s���O�ݒ�
            //this.MakeKeyMappingForGrid( this.uGrid_UnitSalesPriceInfo );

            //// �`�悪�K�v�Ȗ��׌������擾����B
            //int cnt = this._salesPriceRateTable.Rows.Count;

            //// �e�s���Ƃ̐ݒ�
            //for ( int i = 0; i < cnt; i++ )
            //{
            //    this.SettingGridRow( i );
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 DEL
        }
        /// <summary>
        /// ���[�h����
        /// </summary>
        public void Loading()
        {
            if ( (this._goodsUnitData.GoodsNo == string.Empty) )
            {
                this.ClearSalesPriceRateTable();
                this.uGrid_UnitSalesPriceInfo.DataSource = this._salesPriceRateTable;
            }
            else
            {
                this.uGrid_UnitSalesPriceInfo.DataSource = this._salesPriceRateTable;
            }

            // �L�[�}�b�s���O�ݒ�
            this.MakeKeyMappingForGrid( this.uGrid_UnitSalesPriceInfo );

            // �`�悪�K�v�Ȗ��׌������擾����B
            int cnt = this._salesPriceRateTable.Rows.Count;

            // �e�s���Ƃ̐ݒ�
            for ( int i = 0; i < cnt; i++ )
            {
                this.SettingGridRow( i );
            }
        }
        /// <summary>
        /// �e�[�u���N���A�����i�Q�s�Œ�Ȃ̂œ���j
        /// </summary>
        /// <br>Update Note: 2011/08/02 caohh �A��265 ���[�U�[�ݒ��ʂ̐V�K�ǉ��Ή�</br>
        /// <br>Update Note: 2011/09/15 wangf RedMine#20153�̑Ή�</br>
        //private void ClearSalesPriceRateTable() //DEL caohh 2011/08/02
        public void ClearSalesPriceRateTable() //ADD caohh 2011/08/02
        {
            // �폜
            this._salesPriceRateTable.Rows.Clear();
            _rateBufferDic.Clear(); // ADD wangf 2011/09/15

            // ��s�~�Q�ǉ�
            this._salesPriceRateTable.Rows.Add( this._salesPriceRateTable.NewRow() );
            this._salesPriceRateTable.Rows.Add( this._salesPriceRateTable.NewRow() );
        }

        // TODO:�|���̕\���p�e�[�u����ݒ肷�鏈���̓R�R����
        /// <summary>
        /// �|�����X�g�ݒ菈��
        /// </summary>
        /// <param name="rateList"></param>
        /// <br>Update Note: 2010/06/08 �k���r</br>
        /// <br>             �s��̑Ή�</br>
        /// <br>             �|���}�X�^�ɂ����đΏەi�Ԃɑ΂��āA�u�i�ԁ{���[�J�[�v�p�^�[����</br> 
        /// <br>             ���ʂ��Ƃ̔�������ݒ肵���ꍇ�A���i�}�X�^�ł��̕i�Ԃ��Ăяo���ƃG���[�ƂȂ�B</br>
        /// <br>Update Note: 2012/11/21 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 2013/01/16�z�M��</br>
        /// <br>           : Redmine#33230  �_���폜�f�[�^�܂�</br>
        public void SetRateList( List<Rate> rateList )
        {
            // ����������
            _rateBufferDic = new Dictionary<int, Rate>();
            ClearSalesPriceRateTable();

            // �w�胊�X�g������擾
            foreach ( Rate rate in rateList )
            {
                // ----- DEL zhuhh 2012/11/21 for Redmine #33230 ----->>>>>
                // 2009.02.20 30413 ���� �폜��̍ē��͕s�Ή� >>>>>>START
                //if (rate.LogicalDeleteCode != 0)
                //{
                //    // "0:�ʏ�"�ȊO�͓o�^���Ȃ�
                //    continue;
                //}
                // 2009.02.20 30413 ���� �폜��̍ē��͕s�Ή� <<<<<<END
                // ----- DEL zhuhh 2012/11/21 for Redmine #33230 -----<<<<<
                // ----- ADD zhuhh 2012/11/21 for Redmine #33230 ----->>>>>
                if (rate.LogicalDeleteCode != 0 & rate.LogicalDeleteCode != 1)
                {
                    // "0:�ʏ� 1:�_���폜"�ȊO�͓o�^���Ȃ�
                    continue;
                }
                // ----- ADD zhuhh 2012/11/21 for Redmine #33230 -----<<<<<
                // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                // �|���ݒ�敪��"4A"��"6A"��Ώ�
                if (!IsTargetRateSettingDivide(rate.RateSettingDivide.Trim())) continue;
                // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                int group = rate.CustRateGrpCode;

                if (IsNormalRateSettingDivide(rate.RateSettingDivide.Trim()))   // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v����
                {
                    if (group < 0 || ct_RateGroupCount - 1 < group) continue;

                    //--- ADD 2010/06/08 ---------->>>>> 
                    if (_rateBufferDic.ContainsKey(group))
                    {
                        continue;
                    }
                    //--- ADD 2010/06/08 ----------<<<<<

                    // DEL 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    //_salesPriceRateTable.Rows[0][group] = rate.RateVal;
                    //_salesPriceRateTable.Rows[1][group] = rate.PriceFl;
                    // DEL 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    // TODO:���Ӑ�|���O���[�v�R�[�h�Ƃ��̐ݒ�Z���̑Ή��t���̓R�R�Ō��܂�
                    // group��+1����ƌ����ڂ͉E��+1�V�t�g����
                    // �������A�O���b�h�̃w�b�_�L���v�V�����͕ς��Ȃ��̂ŁA�\���Z���ʒu���V�t�g�������ꍇ�A
                    // �w�b�_�L���v�V������uGrid_UnitSalesPriceInfo_InitializeLayout()�Œ�������K�v������B
                    // ----- DEL zhuhh 2012/11/21 for Redmine #33230 ----->>>>>
                    //_salesPriceRateTable.Rows[0][group + 1] = rate.RateVal;
                    //_salesPriceRateTable.Rows[1][group + 1] = rate.PriceFl;
                    // ----- DEL zhuhh 2012/11/21 for Redmine #33230 -----<<<<<
                    // ----- ADD zhuhh 2012/11/21 for Redmine #33230 ----->>>>>
                    if (rate.LogicalDeleteCode == 0)
                    {
                        _salesPriceRateTable.Rows[0][group + 1] = rate.RateVal;
                        _salesPriceRateTable.Rows[1][group + 1] = rate.PriceFl;
                    }
                    // ----- ADD zhuhh 2012/11/21 for Redmine #33230 -----<<<<<
                    // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                    // �������f�B�N�V���i���ɑޔ�
                    _rateBufferDic.Add(group, rate.Clone());
                }
                // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                else
                {
                    // --- ADD 2010/06/08 ---------->>>>> 
                    if (_rateBufferDic.ContainsKey(ALL_RATE_GROUP_CODE))
                    {
                        continue;
                    }
                    // --- ADD 2010/06/08 ----------<<<<<
                    // ----- DEL zhuhh 2012/11/21 for Redmine #33230 ----->>>>>
                    //_salesPriceRateTable.Rows[0][0] = rate.RateVal;
                    //_salesPriceRateTable.Rows[1][0] = rate.PriceFl;
                    // ----- DEL zhuhh 2012/11/21 for Redmine #33230 -----<<<<<
                    // ----- ADD zhuhh 2012/11/21 for Redmine #33230 ----->>>>>
                    if (rate.LogicalDeleteCode == 0)
                    {
                        _salesPriceRateTable.Rows[0][0] = rate.RateVal;
                        _salesPriceRateTable.Rows[1][0] = rate.PriceFl;
                    }
                    // ----- ADD zhuhh 2012/11/21 for Redmine #33230 -----<<<<<
                    // �������f�B�N�V���i���ɑޔ�
                    _rateBufferDic.Add(ALL_RATE_GROUP_CODE, rate.Clone());
                }
                // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
            }   // foreach ( Rate rate in rateList )
        }

        // --- ADD �����M 2015/09/10 Redmine#47026 --------------->>>>>
        /// <summary>
        /// �|�����X�g�ݒ菈��
        /// </summary>
        /// <param name="rateList">�|�����X�g</param>
        /// <param name="mode">0:���l���Z�b�g</param>
        /// <remarks>
        /// <br>Update Note: 2015/09/10 �����M</br>
        /// <br>�Ǘ��ԍ�   : 11170129-00</br>
        /// <br>             Redmine#47026 ���i�݌Ƀ}�X�^�̏�Q�Ή�</br>
        /// </remarks>
        public void SetRateList(List<Rate> rateList,int mode)
        {
            if (mode != 0)
            {
                // ���i�݌Ƀ}�X�^�U���Q�Ƃ��A���ɖ߂��֘A�����B
                // �폜
                this._salesPriceRateTable.Rows.Clear();

                // ��s�~�Q�ǉ�
                this._salesPriceRateTable.Rows.Add(this._salesPriceRateTable.NewRow());
                this._salesPriceRateTable.Rows.Add(this._salesPriceRateTable.NewRow());

                // �w�胊�X�g������擾
                foreach (Rate rate in rateList)
                {
                    if (rate.LogicalDeleteCode != 0 & rate.LogicalDeleteCode != 1)
                    {
                        // "0:�ʏ� 1:�_���폜"�ȊO�͓o�^���Ȃ�
                        continue;
                    }
                    // �|���ݒ�敪��"4A"��"6A"��Ώ�
                    if (!IsTargetRateSettingDivide(rate.RateSettingDivide.Trim())) continue;

                    int group = rate.CustRateGrpCode;

                    if (IsNormalRateSettingDivide(rate.RateSettingDivide.Trim()))
                    {
                        if (group < 0 || ct_RateGroupCount - 1 < group) continue;

                        if (rate.LogicalDeleteCode == 0)
                        {
                            _salesPriceRateTable.Rows[0][group + 1] = rate.RateVal;
                            _salesPriceRateTable.Rows[1][group + 1] = rate.PriceFl;
                        }
                    }
                    else
                    {
                        if (rate.LogicalDeleteCode == 0)
                        {
                            _salesPriceRateTable.Rows[0][0] = rate.RateVal;
                            _salesPriceRateTable.Rows[1][0] = rate.PriceFl;
                        }
                    }
                }
            }
        }
        // --- ADD �����M 2015/09/10 Redmine#47026 ---------------<<<<<

        /// <summary>
        /// �|�����X�g�擾����
        /// </summary>
        /// <returns></returns>
        /// <br>Update Note: 2012/11/21 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 2013/01/16�z�M��</br>
        /// <br>           : Redmine#33230  �_���폜�f�[�^�܂�</br>
        /// <br>Update Note: 2015/09/10 �����M</br>
        /// <br>�Ǘ��ԍ�   : 11170129-00</br>
        /// <br>             Redmine#47026 ���i�݌Ƀ}�X�^�̏�Q�Ή�</br>
        /// <br>Update Note: 2018/10/26 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11370033-00</br>
        /// <br>             Redmine#49732 ����UP���Ƒe���m�ۗ��̐ݒ肪������Ή�</br>
        public List<Rate> GetRateList()
        {
            List<Rate> retRateList = new List<Rate>();

            for ( int group = 0; group < ct_RateGroupCount; group++ )
            {
                // �O���b�h���͓��e���擾
                double rateVal = (double)_salesPriceRateTable.Rows[0][group];
                double priceFl = (double)_salesPriceRateTable.Rows[1][group];

                // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                int groupCode = group - 1;  // ���Ӑ�|���O���[�v�R�[�h�𒲐�
                // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                // ���͂���Ă����̂ݓo�^
                if ( rateVal != 0 || priceFl != 0 )
                {
                    Rate rate;
                    // DEL 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    // if (_rateBufferDic.ContainsKey(group))
                    // DEL 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    if (_rateBufferDic.ContainsKey(groupCode))
                    // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    {
                        // �����C��
                        // DEL 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                        // rate = _rateBufferDic[group];
                        // DEL 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                        // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                        //rate = _rateBufferDic[groupCode];// DEL �����M 2015/09/10 Redmine#47026
                        rate = _rateBufferDic[groupCode].Clone();// ADD �����M 2015/09/10 Redmine#47026
                        // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    }
                    else
                    {
                        // �V�K�쐬
                        rate = this.CreateNewRate();
                        // DEL 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                        // rate.CustRateGrpCode = group;
                        // DEL 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                        // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                        rate.CustRateGrpCode = groupCode;
                        // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    }

                    // ���͓��e�ŏ�������
                    rate.RateVal = rateVal;
                    rate.PriceFl = priceFl;

                    // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    // TODO:���Ӑ�|���O���[�v�R�[�h�w�肪�Ȃ��p�̕␳
                    if (groupCode < 0)
                    {
                        rate.UnitRateSetDivCd = "16A";      // �P�����+�|���ݒ�敪 ���P�����(1:�����ݒ�)
                        rate.RateSettingDivide = "6A";      // �|���ݒ�敪=�|���ݒ�敪(���Ӑ�)+�|���ݒ�敪(���i)
                        rate.RateMngCustCd = "6";           // �|���ݒ�敪(���Ӑ�)�c4:���Ӑ�|���O���[�v/6:�w��Ȃ�
                        rate.RateMngCustNm = "�w��Ȃ�";    // �|���ݒ薼��(���Ӑ�)�c4:���Ӑ�|���O���[�v/6:�w��Ȃ�
                        // ADD 2010/01/18 MANTIS[14896] ���Ӑ�|���O���[�v�R�[�h�F-1 �œo�^����͕̂s�� ---------->>>>>
                        if (rate.FileHeaderGuid.Equals(Guid.Empty))
                        {
                            rate.CustRateGrpCode = 0;// groupCode;   // ���Ӑ�|���O���[�v�R�[�h(-1:���ݒ�)���s��
                        }
                        // ADD 2010/01/18 MANTIS[14896] ���Ӑ�|���O���[�v�R�[�h�F-1 �œo�^����͕̂s�� ----------<<<<<
                    }
                    // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

                    // ���X�g�ɒǉ�
                    rate.LogicalDeleteCode = 0;// ADD zhuhh 2012/11/21 for Redmine #33230
                    retRateList.Add( rate );
                }
                // DEL 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                // else if ( _rateBufferDic.ContainsKey( group ) )
                // DEL 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                //else if (_rateBufferDic.ContainsKey(groupCode)) // DEL zhuhh 2012/11/21 for Redmine #33230
                // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                else if (_rateBufferDic.ContainsKey(groupCode) && _rateBufferDic[groupCode].LogicalDeleteCode != 1) // ADD zhuhh 2012/11/21 for Redmine #33230
                {
                    // �y�f�B�N�V���i���L��E���͖����z�Ȃ�폜���R�[�h����
                    // �����C��
                    // DEL 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    // Rate rate = _rateBufferDic[group];
                    // DEL 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    //Rate rate = _rateBufferDic[groupCode];// DEL �����M 2015/09/10 Redmine#47026
                    Rate rate = _rateBufferDic[groupCode].Clone();// ADD �����M 2015/09/10 Redmine#47026
                    // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    // --- ADD ���O 2018/10/26 Redmine#49732�̑Ή�---------->>>>>
                    if (rate.UpRate != 0 || rate.GrsProfitSecureRate != 0)
                    {
                        rate.RateVal = 0;
                        rate.PriceFl = 0;
                    }
                    else
                    {
                    // --- ADD ���O 2018/10/26 Redmine#49732�̑Ή�----------<<<<<
                        rate.LogicalDeleteCode = 3; // 3:�����폜
                        rate.RateVal = 0;
                        rate.PriceFl = 0;
                    }// ADD ���O 2018/10/26 Redmine#49732�̑Ή�

                    // ���X�g�ɒǉ�
                    retRateList.Add( rate );
                }
            }

            return retRateList;
        }
        /// <summary>
        /// �|�����X�g�i���ɖ߂��p�j�擾����
        /// </summary>
        /// <returns></returns>
        public List<Rate> GetRateListForRollBack()
        {
            List<Rate> rateList = new List<Rate>();
            foreach ( Rate rate in _rateBufferDic.Values )
            {
                rateList.Add( rate );
            }
            return rateList;
        }
        /// <summary>
        /// �|�����X�g�i���S�폜�p�j�擾����
        /// </summary>
        /// <returns></returns>
        /// <br>Update Note: 2012/11/21 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 2013/01/16�z�M��</br>
        /// <br>           : Redmine#33230  �_���폜�f�[�^�܂܂Ȃ�</br>
        public List<Rate> GetRateListForDelete()
        {
            //----------------------------------------
            // ��LogicalDeleteCode=3:�����폜���Z�b�g
            //----------------------------------------

            List<Rate> rateList = new List<Rate>();
            foreach ( Rate rate in _rateBufferDic.Values )
            {
                // ----- DEL zhuhh 2012/11/21 for Redmine #33230 ----->>>>>
                //rate.LogicalDeleteCode = 3;
                //rateList.Add( rate );
                // ----- DEL zhuhh 2012/11/21 for Redmine #33230 -----<<<<<
                // ----- ADD zhuhh 2012/11/21 for Redmine #33230 ----->>>>>
                if (rate.LogicalDeleteCode != 1)
                {
                    rate.LogicalDeleteCode = 3;
                    rateList.Add(rate); 
                }
                // ----- ADD zhuhh 2012/11/21 for Redmine #33230 -----<<<<<
            }
            return rateList;
        }
        /// <summary>
        /// �|�����X�g�i�_���폜�����p�j
        /// </summary>
        /// <returns></returns>
        public List<Rate> GetRateListForRevive()
        {
            //----------------------------------------
            // ��LogicalDeleteCode=0:�ʏ�ɖ߂�
            //----------------------------------------

            List<Rate> rateList = new List<Rate>();
            foreach ( Rate rate in _rateBufferDic.Values )
            {
                rate.LogicalDeleteCode = 0;
                rateList.Add( rate );
            }
            return rateList;
        }

        ///// <summary>
        ///// �O��l�ւ̖߂������i���ɖ߂��j
        ///// </summary>
        //public void RollBackInGrid()
        //{
        //    // �N���A����
        //    ClearSalesPriceRateTable();

        //    // �ޔ��f�B�N�V���i������Đݒ肷��B
        //    for ( int group = 0; group < ct_RateGroupCount - 1; group++ )
        //    {
        //        if ( !_rateBufferDic.ContainsKey( group ) ) continue;

        //        Rate rate = _rateBufferDic[group];
        //        _salesPriceRateTable.Rows[0][group] = rate.RateVal;
        //        _salesPriceRateTable.Rows[1][group] = rate.PriceFl;
        //    }
        //}
        /// <summary>
        /// TODO:�V�K�|���I�u�W�F�N�g�����i�֘A�t����ꂽ���i���Ɋ�Â��j
        /// </summary>
        /// <returns></returns>
        private Rate CreateNewRate()
        {
            Rate newRate = new Rate();

            string employeeCode = LoginInfoAcquisition.Employee.EmployeeCode;

            # region [�|��]
            newRate.CreateDateTime = DateTime.Now; // �쐬����
            newRate.UpdateDateTime = DateTime.MinValue; // �X�V����
            newRate.EnterpriseCode = _goodsUnitData.EnterpriseCode; // ��ƃR�[�h
            newRate.FileHeaderGuid = Guid.Empty; // GUID
            newRate.UpdEmployeeCode = employeeCode; // �X�V�]�ƈ��R�[�h
            //newRate.UpdAssemblyId1 = default( string ); // �X�V�A�Z���u��ID1
            //newRate.UpdAssemblyId2 = default( string ); // �X�V�A�Z���u��ID2
            newRate.LogicalDeleteCode = 0; // �_���폜�敪
            newRate.SectionCode = "00"; // ���_�R�[�h
            // --- CHG 2009/02/10 ��QID:11264�Ή�------------------------------------------------------>>>>>
            //newRate.UnitRateSetDivCd = "1A4"; // �P���|���ݒ�敪
            newRate.UnitRateSetDivCd = "14A"; // �P���|���ݒ�敪
            // --- CHG 2009/02/10 ��QID:11264�Ή�------------------------------------------------------<<<<<
            newRate.UnitPriceKind = "1"; // �P�����
            // --- CHG 2009/02/10 ��QID:11264�Ή�------------------------------------------------------>>>>>
            //newRate.RateSettingDivide = "A4"; // �|���ݒ�敪
            newRate.RateSettingDivide = "4A"; // FIXME:�|���ݒ�敪���i�����̃��\�b�h�̊O�ŃZ�b�g�j
            // --- CHG 2009/02/10 ��QID:11264�Ή�------------------------------------------------------<<<<<
            newRate.RateMngGoodsCd = "A"; // �|���ݒ�敪�i���i�j
            newRate.RateMngGoodsNm = "Ұ���{�i��"; // �|���ݒ薼�́i���i�j
            newRate.RateMngCustCd = "4"; // FIXME:�|���ݒ�敪�i���Ӑ�j���i�����̃��\�b�h�̊O�ŃZ�b�g�j
            newRate.RateMngCustNm = "���Ӑ�|���O���[�v"; // FIXME:�|���ݒ薼�́i���Ӑ�j���i�����̃��\�b�h�̊O�ŃZ�b�g�j
            newRate.GoodsMakerCd = _goodsUnitData.GoodsMakerCd; // ���i���[�J�[�R�[�h
            newRate.GoodsNo = _goodsUnitData.GoodsNo; // ���i�ԍ�
            newRate.GoodsRateRank = string.Empty; // ���i�|�������N
            newRate.GoodsRateGrpCode = 0; // ���i�|���O���[�v�R�[�h
            newRate.BLGroupCode = 0; // BL�O���[�v�R�[�h
            newRate.BLGoodsCode = 0; // BL���i�R�[�h
            newRate.CustomerCode = 0; // ���Ӑ�R�[�h
            newRate.CustRateGrpCode = 0; // FIXME:���Ӑ�|���O���[�v�R�[�h���i�����̃��\�b�h�̊O�ŃZ�b�g�j
            newRate.SupplierCd = 0; // �d����R�[�h
            newRate.LotCount = 9999999.99; // ���b�g��
            newRate.PriceFl = 0; // ���i�i�����j���i�����̃��\�b�h�̊O�ŃZ�b�g�j
            newRate.RateVal = 0; // �|�����i�����̃��\�b�h�̊O�ŃZ�b�g�j
            newRate.UpRate = 0; // UP��
            newRate.GrsProfitSecureRate = 0; // �e���m�ۗ�
            newRate.UnPrcFracProcUnit = 1; // �P���[�������P�� = 1
            newRate.UnPrcFracProcDiv = 2; // �P���[�������敪 = 2:�l�̌ܓ�
            # endregion

            return newRate;
        }

        /// <summary>
        /// InitializeLayout�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_UnitSalesPriceInfo_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_UnitSalesPriceInfo.DisplayLayout.Bands[0].Columns;

            #region �폜�R�[�h
            //// ��U�A�S�Ă̗���\���ɂ���B
            //foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            //{
            //    //��\���ݒ�
            //    column.Hidden = true;
            //}
            #endregion

            //string moneyFormat = "#,##0;-#,##0;''";
            string moneyFormatFl = "#,##0.00;-#,##0.00;''";
            //string rateFormatFl = "###0.00;-###0.00;''";

            #region �폜�R�[�h
            //// �񕝂̎����������@
            //this.uGrid_UnitSalesPriceInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;
            //this.uGrid_UnitSalesPriceInfo.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            //this.uGrid_UnitSalesPriceInfo.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            //this.uGrid_UnitSalesPriceInfo.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //this.uGrid_UnitSalesPriceInfo.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            //this.uGrid_UnitSalesPriceInfo.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            //this.uGrid_UnitSalesPriceInfo.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            #endregion

            //--------------------------------------------------------------------------------
            //  �\������J�������
            //--------------------------------------------------------------------------------
            //this.uGrid_UnitSalesPriceInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // 2009.03.03 30413 ���� �w�b�_�[�𓾈Ӑ�|���f�̃R�[�h�Ɩ���2�i�Ƃ��� >>>>>>START
            // �s���C�A�E�g�@�\��L��
            this.uGrid_UnitSalesPriceInfo.DisplayLayout.Bands[0].UseRowLayout = true;
            // ���Ӑ�|���f���̂��擾
            this.SetCustRateGrpName();
            // 2009.03.03 30413 ���� �w�b�_�[�𓾈Ӑ�|���f�̃R�[�h�Ɩ���2�i�Ƃ��� <<<<<<END
                
            int index = 0;
            
            // �S�񓯂��ݒ�łn�j
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
	        {
                // --- ADD 2009/01/09 ��QID:9903�Ή�------------------------------------------------------>>>>>
                //column.Header.Caption = index.ToString("00");
                column.Header.Caption = index.ToString("0000");
                // --- ADD 2009/01/09 ��QID:9903�Ή�------------------------------------------------------<<<<<
                // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                // TODO:���Ӑ�|���O���[�v�R�[�h�̎w��Ȃ��̃J�����p��1��E�ɃV�t�g
                int captionIndex = index - 1;
                column.Header.Caption = (captionIndex >= 0 ? captionIndex.ToString("d4") : ALL_RATE_GROUP_CAPTION);
                // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                // 2009.03.03 30413 ���� �w�b�_�[�𓾈Ӑ�|���f�̃R�[�h�Ɩ���2�i�Ƃ��� >>>>>>START
                // DEL 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                //if (index < 20)
                // DEL 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                if (index < ct_RateGroupCount)  // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v����
                {
                    column.RowLayoutColumnInfo.OriginY = 0;
                    column.RowLayoutColumnInfo.OriginX = index;
                    column.RowLayoutColumnInfo.SpanY = 1;
                    column.RowLayoutColumnInfo.SpanX = 1;
                }
                else
                {
                    // DEL 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    //int custRateGrpIdx = index - 20;
                    // DEL 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    // TODO:���Ӑ�|���O���[�v�R�[�h�̎w��Ȃ��̃J�����p��1��E�ɃV�t�g
                    int custRateGrpIdx = index - ct_RateGroupCount - 1;  // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v����
                    // 2009.03.12 30413 ���� �K�C�h�R�[�h�����o�^���̑Ή� >>>>>>START
                    //column.Header.Caption = this._custRateGrpNameDic[custRateGrpIdx];
                    column.Header.Caption = "";
                    if (this._custRateGrpNameDic.ContainsKey(custRateGrpIdx))
                    {
                        column.Header.Caption = this._custRateGrpNameDic[custRateGrpIdx];
                    }
                    // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    else if (custRateGrpIdx < 0)
                    {
                        column.Header.Caption = this._custRateGrpNameDic[ALL_RATE_GROUP_CODE];
                    }
                    // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    // 2009.03.12 30413 ���� �K�C�h�R�[�h�����o�^���̑Ή� <<<<<<END
                    column.RowLayoutColumnInfo.LabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.LabelOnly;
                    column.RowLayoutColumnInfo.OriginY = 1;
                    // DEL 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    //column.RowLayoutColumnInfo.OriginX = custRateGrpIdx;
                    // DEL 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                    column.RowLayoutColumnInfo.OriginX = index - ct_RateGroupCount;
                    // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                    column.RowLayoutColumnInfo.SpanY = 1;
                    column.RowLayoutColumnInfo.SpanX = 1;
                }
                // 2009.03.03 30413 ���� �w�b�_�[�𓾈Ӑ�|���f�̃R�[�h�Ɩ���2�i�Ƃ��� <<<<<<END
                
                column.Hidden = false;
                column.Width = 120;
                column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                if ( _parentEnabled )
                {
                    column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                else
                {
                    column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }
                column.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                column.Format = moneyFormatFl;

                column.Header.VisiblePosition = index++;
	        }

            // �Œ���؂���ݒ�
            this.uGrid_UnitSalesPriceInfo.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_UnitSalesPriceInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }

        /// <summary>
        /// AfterPerformAction�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_UnitSalesPriceInfo_AfterPerformAction(object sender, Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell:

                    // �A�N�e�B�u�ȃZ�������邩�H�܂��͕ҏW�\�Z�����H
                    if ((this.uGrid_UnitSalesPriceInfo.ActiveCell != null) && (this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_UnitSalesPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        // �A�N�e�B�u�Z���̃X�^�C�����擾
                        switch (this.uGrid_UnitSalesPriceInfo.ActiveCell.StyleResolved)
                        {
                            // �G�f�B�b�g�n�X�^�C��
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    // �ҏW���[�h�ɂ���H
                                    if (this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode))
                                    {
                                        if (!(this.uGrid_UnitSalesPriceInfo.ActiveCell.Value is System.DBNull))
                                        {
                                            //// �S�I����Ԃɂ���B
                                            //this.uGrid_UnitSalesPriceInfo.ActiveCell.SelStart = 0;
                                            //this.uGrid_UnitSalesPriceInfo.ActiveCell.SelLength = this.uGrid_UnitSalesPriceInfo.ActiveCell.Text.Length;
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    // �G�f�B�b�g�n�ȊO�̃X�^�C���ł���΁A�ҏW��Ԃɂ���B
                                    this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Enter�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_UnitSalesPriceInfo_Enter(object sender, EventArgs e)
        {
            if ( !_parentEnabled ) return;

            if (this.uGrid_UnitSalesPriceInfo.ActiveCell == null)
            {
                if (!this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell) || (this.uGrid_UnitSalesPriceInfo.ActiveCell == null))
                {
                    if (this.uGrid_UnitSalesPriceInfo.Rows.Count > 0)
                    {
                        this.uGrid_UnitSalesPriceInfo.ActiveCell = this.uGrid_UnitSalesPriceInfo.Rows[0].Cells[ct_Col_CustRateGrp_00];

                        // �����͉\�Z���ړ�����
                        this.MoveNextAllowEditCell(true);
                    }
                }
            }

            if (this.uGrid_UnitSalesPriceInfo.ActiveCell != null)
            {
                if ((!this.uGrid_UnitSalesPriceInfo.ActiveCell.IsInEditMode) && (this.uGrid_UnitSalesPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
                else
                {
                    // �����͉\�Z���ړ�����
                    this.MoveNextAllowEditCell(true);
                }
            }

            // �O���b�h�Z���A�N�e�B�u�㔭���C�x���g
            //this.uGrid_Details_AfterCellActivate(this.uGrid_Details, new EventArgs());

        }

        /// <summary>
        /// KeyDown�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_UnitSalesPriceInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_UnitSalesPriceInfo.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_UnitSalesPriceInfo.ActiveCell;

                if (e.KeyCode == Keys.Escape)
                {
                    //// �d�����׃f�[�^�e�[�u��RowStatus�񏉊�������
                    //this._stockSlipInputAcs.InitializeStockDetailRowStatusColumn();

                    //// ���׃O���b�h�Z���ݒ菈��
                    //this.SettingGrid();
                }

                if (e.Shift)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                this.uGrid_UnitSalesPriceInfo.ActiveCell = null;
                                this.uGrid_UnitSalesPriceInfo.ActiveRow = cell.Row;
                                this.uGrid_UnitSalesPriceInfo.Selected.Rows.Clear();
                                this.uGrid_UnitSalesPriceInfo.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Up:
                            {
                                this.uGrid_UnitSalesPriceInfo.ActiveCell = null;
                                this.uGrid_UnitSalesPriceInfo.ActiveRow = cell.Row;
                                this.uGrid_UnitSalesPriceInfo.Selected.Rows.Clear();
                                this.uGrid_UnitSalesPriceInfo.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Home:
                            {
                                if ((this.uGrid_UnitSalesPriceInfo.ActiveCell != null) && (this.uGrid_UnitSalesPriceInfo.ActiveCell.IsInEditMode))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                    this.MoveNextAllowEditCell(true);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                if ((this.uGrid_UnitSalesPriceInfo.ActiveCell != null) && (this.uGrid_UnitSalesPriceInfo.ActiveCell.IsInEditMode))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
                                }
                                break;
                            }
                    }
                }
                else if (e.Alt)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                //if ((cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown) &&
                                //    (cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList) &&
                                //    (cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate))
                                //{
                                //    ((Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_Main.Tools["PopupMenuTool_Edit"]).ShowPopup(System.Windows.Forms.Cursor.Position, this.uGrid_UnitSalesPriceInfo);
                                //}

                                break;
                            }
                    }
                }
                else
                {
                    // �ҏW���ł������ꍇ
                    if (cell.IsInEditMode)
                    {
                        // �Z���̃X�^�C���ɂĔ���
                        switch (this.uGrid_UnitSalesPriceInfo.ActiveCell.StyleResolved)
                        {
                            // �e�L�X�g�{�b�N�X�E�e�L�X�g�{�b�N�X(�{�^���t)
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ���L�[
                                        case Keys.Left:
                                            if (this.uGrid_UnitSalesPriceInfo.ActiveCell.SelStart == 0)
                                            {
                                                // --- CHG 2009/03/18 ��QID:12530�Ή�------------------------------------------------------>>>>>
                                                //this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                int rowIndex = this.uGrid_UnitSalesPriceInfo.ActiveCell.Row.Index;
                                                int colIndex = this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.Index;

                                                if (colIndex != 0)
                                                {
                                                    this.uGrid_UnitSalesPriceInfo.Rows[rowIndex].Cells[colIndex - 1].Activate();
                                                    this.uGrid_UnitSalesPriceInfo.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                // --- CHG 2009/03/18 ��QID:12530�Ή�------------------------------------------------------<<<<<
                                                e.Handled = true;
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            if (this.uGrid_UnitSalesPriceInfo.ActiveCell.SelStart >= this.uGrid_UnitSalesPriceInfo.ActiveCell.Text.Length)
                                            {
                                                // --- CHG 2009/03/18 ��QID:12530�Ή�------------------------------------------------------>>>>>
                                                //this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                int rowIndex = this.uGrid_UnitSalesPriceInfo.ActiveCell.Row.Index;
                                                int colIndex = this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.Index;

                                                if (colIndex != 19)
                                                {
                                                    this.uGrid_UnitSalesPriceInfo.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                                    this.uGrid_UnitSalesPriceInfo.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                // --- CHG 2009/03/18 ��QID:12530�Ή�------------------------------------------------------<<<<<
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                    break;
                                }
                            // ��L�ȊO�̃X�^�C��
                            default:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ���L�[
                                        case Keys.Left:
                                            {
                                                this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            {
                                                this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                    break;
                                }
                        }
                    }

                    switch (e.KeyCode)
                    {
                        case Keys.Home:
                            {
                                if ((this.uGrid_UnitSalesPriceInfo.ActiveCell != null) && (this.uGrid_UnitSalesPriceInfo.ActiveCell.IsInEditMode))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                                    this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    e.Handled = true;
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                if ((this.uGrid_UnitSalesPriceInfo.ActiveCell != null) && (this.uGrid_UnitSalesPriceInfo.ActiveCell.IsInEditMode))
                                {
                                    //
                                }
                                else
                                {
                                    this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                                    this.uGrid_UnitSalesPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    e.Handled = true;
                                }
                                break;
                            }
                        case Keys.Up:
                            {
                                if ((this.uGrid_UnitSalesPriceInfo.ActiveCell != null) && (!this.uGrid_UnitSalesPriceInfo.ActiveCell.DroppedDown))
                                {
                                    if (this.uGrid_UnitSalesPriceInfo.ActiveCell.Row.Index == 0)
                                    {
                                        if (this.GridKeyDownTopRow != null)
                                        {
                                            this.GridKeyDownTopRow(this, new EventArgs());
                                            e.Handled = true;
                                        }
                                    }
                                    // --- ADD 2009/03/18 ��QID:12530�Ή�------------------------------------------------------>>>>>
                                    else
                                    {
                                        int rowIndex = this.uGrid_UnitSalesPriceInfo.ActiveCell.Row.Index;
                                        int colIndex = this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.Index;

                                        e.Handled = true;
                                        this.uGrid_UnitSalesPriceInfo.Rows[rowIndex - 1].Cells[colIndex].Activate();
                                        this.uGrid_UnitSalesPriceInfo.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    // --- ADD 2009/03/18 ��QID:12530�Ή�------------------------------------------------------<<<<<
                                }

                                break;
                            }
                        case Keys.Down:
                            {
                                // --- ADD 2009/03/18 ��QID:12530�Ή�------------------------------------------------------>>>>>
                                e.Handled = true;
                                // --- ADD 2009/03/18 ��QID:12530�Ή�------------------------------------------------------<<<<<

                                if (this.uGrid_UnitSalesPriceInfo.ActiveCell.Row.Index == this.uGrid_UnitSalesPriceInfo.Rows.Count - 1)
                                {
                                    // --- DEL 2009/03/18 ��QID:12530�Ή�------------------------------------------------------>>>>>
                                    //if (e.KeyCode == Keys.Down)
                                    //{
                                    //    if (this.GridKeyDownButtomRow != null)
                                    //    {
                                    //        this.GridKeyDownButtomRow(this, new EventArgs());
                                    //        e.Handled = true;
                                    //    }
                                    //}
                                    // --- DEL 2009/03/18 ��QID:12530�Ή�------------------------------------------------------<<<<<
                                }
                                // --- ADD 2009/03/18 ��QID:12530�Ή�------------------------------------------------------>>>>>
                                else
                                {
                                    int rowIndex = this.uGrid_UnitSalesPriceInfo.ActiveCell.Row.Index;
                                    int colIndex = this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.Index;

                                    this.uGrid_UnitSalesPriceInfo.Rows[rowIndex + 1].Cells[colIndex].Activate();
                                    this.uGrid_UnitSalesPriceInfo.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                // --- ADD 2009/03/18 ��QID:12530�Ή�------------------------------------------------------<<<<<
                                break;
                            }
                    }
                }
            }
            else if (this.uGrid_UnitSalesPriceInfo.ActiveRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_UnitSalesPriceInfo.ActiveRow;

                if (this.uGrid_UnitSalesPriceInfo.ActiveRow.Index == 0)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        if (this.GridKeyDownTopRow != null)
                        {
                            this.GridKeyDownTopRow(this, new EventArgs());
                            e.Handled = true;
                        }
                    }
                }
                else if (this.uGrid_UnitSalesPriceInfo.ActiveRow.Index == this.uGrid_UnitSalesPriceInfo.Rows.Count - 1)
                {
                    if (e.KeyCode == Keys.Down)
                    {
                        if (this.GridKeyDownButtomRow != null)
                        {
                            this.GridKeyDownButtomRow(this, new EventArgs());
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// BeforeCellUpdate�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_UnitSalesPriceInfo_BeforeCellUpdate(object sender, Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs e)
        {
            if (e.Cell == null) return;

            this._beforeCellUpdateCancel = false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            ////------------------------------------------------------------
            //// ���i�J�n��
            ////------------------------------------------------------------
            //if (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateColumn.ColumnName)
            //{
            //    if ((e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)))
            //    {
            //        //DateTime dt = new DateTime((long)e.Cell.Value);
            //        DateTime dt = new DateTime();
            //        //DateTime dt = new DateTime((long)e.Cell.Value);
            //        dt = (DateTime)e.NewValue;
            //        // ���i�J�n���d���`�F�b�N
            //        if (this._goodsAcs.CheckRepeatPriceStartDate(dt))
            //        {
            //            TMsgDisp.Show(
            //                this,
            //                emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //                this.Name,
            //                "���͂��ꂽ���t�͊��ɑ��݂���ׁA���͂ł��܂���B",
            //                -1,
            //                MessageBoxButtons.OK);

            //            this._beforeCellUpdateCancel = true;
            //            e.Cancel = true;
            //            return;
            //        }
            //        this._beforePriceStartDate = (DateTime)e.Cell.Value;
            //    }
            //    else
            //    {
            //        this._beforePriceStartDate = DateTime.MinValue;
            //    }
            //}
            ////------------------------------------------------------------
            //// �W�����i
            ////------------------------------------------------------------
            //else if (cell.Column.Key == this._goodsPriceDataTable.ListPriceColumn.ColumnName)
            //{
            //    if ((e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)))
            //    {
            //        this._beforeListPrice = (double)e.Cell.Value;
            //    }
            //    else
            //    {
            //        this._beforeListPrice = 0;
            //    }
            //}
            ////------------------------------------------------------------
            //// �d����
            ////------------------------------------------------------------
            //else if (cell.Column.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName)
            //{
            //    if ((e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)))
            //    {
            //        this._beforeStockRate = (double)e.Cell.Value;
            //    }
            //    else
            //    {
            //        this._beforeStockRate = 0;
            //    }
            //}
            ////------------------------------------------------------------
            //// ���P��
            ////------------------------------------------------------------
            //else if (cell.Column.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName)
            //{
            //    if ((e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)))
            //    {
            //        this._beforeSalesUnitCost = (double)e.Cell.Value;
            //    }
            //    else
            //    {
            //        this._beforeSalesUnitCost = 0;
            //    }
            //}
        }

        /// <summary>
        /// AfterCellUpdate�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_UnitSalesPriceInfo_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;
            //int rowNo = this._goodsPriceDataTable[cell.Row.Index].RowNo;
            int rowIndex = e.Cell.Row.Index;
            if (e.Cell.Value is DBNull)
            {
                if ((e.Cell.Column.DataType == typeof(Int32)) ||
                    (e.Cell.Column.DataType == typeof(Int64)) ||
                    (e.Cell.Column.DataType == typeof(double)))
                {
                    e.Cell.Value = 0;
                }
                else if (e.Cell.Column.DataType == typeof(string))
                {
                    e.Cell.Value = "";
                }
            }

            # region [���͕ύX���ꂽ�Z���̕����F��ς���]
            bool valueChangeFlag = false;

            # region [valueChangeFlag�̔���]
            int group = e.Cell.Column.Index;
            switch ( e.Cell.Row.Index )
            {
                // ������
                case 0:
                    {
                        // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                        group--;    // TODO:���Ӑ�|���O���[�v�R�[�h�𒲐�
                        // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                        if ( _rateBufferDic.ContainsKey( group ) )
                        {
                            if ( _rateBufferDic[group].RateVal != (double)e.Cell.Value )
                            {
                                valueChangeFlag = true;
                            }
                        }
                        else
                        {
                            // �f�B�N�V���i����������ǉ����ꂽ
                            valueChangeFlag = true;
                        }
                    }
                    break;
                // �����z
                case 1:
                    {
                        // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                        group--;    // TODO:���Ӑ�|���O���[�v�R�[�h�𒲐�
                        // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                        if ( _rateBufferDic.ContainsKey( group ) )
                        {
                            if ( _rateBufferDic[group].PriceFl != (double)e.Cell.Value )
                            {
                                valueChangeFlag = true;
                            }
                        }
                        else
                        {
                            // �f�B�N�V���i����������ǉ����ꂽ
                            valueChangeFlag = true;
                        }
                    }
                    break;
                default:
                    break;
            }
            # endregion

            if ( valueChangeFlag )
            {
                // ���͕ύX�������ԕ����ɂ���
                e.Cell.Appearance.ForeColor = Color.Red;
                e.Cell.Appearance.ForeColorDisabled = Color.Red;
            }
            else
            {
                // �����F��߂�
                e.Cell.Appearance.ForeColor = SystemColors.WindowText;
                e.Cell.Appearance.ForeColorDisabled = SystemColors.WindowText;
            }
            # endregion

            #region �폜�R�[�h
            ////------------------------------------------------------------
            //// ���i�J�n��
            ////------------------------------------------------------------
            //if (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateColumn.ColumnName)
            //{
            //    DateTime dt = new DateTime();
            //    dt = (DateTime)e.Cell.Value;
            //    if (this._beforePriceStartDate != dt)
            //    {
            //        this._goodsAcs.CalclateUnitPrice(rowNo, this._goodsUnitData);

            //        this._goodsAcs.ClearInputInfo(rowNo); // ���͏��N���A
            //        this._goodsAcs.SettingCalcStockRate(rowNo); // �v�Z�������ݒ�
            //        this._goodsAcs.SettingCalcSalesUnitCost(rowNo); // �v�Z�����z�ݒ菈��
            //        this._goodsAcs.SettingCalcMaster(rowNo); // �Z�o�}�X�^�ݒ菈��
            //    }
            //}
            ////------------------------------------------------------------
            //// �W�����i
            ////------------------------------------------------------------
            //else if (cell.Column.Key == this._goodsPriceDataTable.ListPriceColumn.ColumnName)
            //{
            //    double listPrice = TStrConv.StrToDoubleDef(e.Cell.ToString(), 0);
            //    if (this._beforeListPrice != (double)e.Cell.Value)
            //    {
            //        // �v�Z���������̓`�F�b�N
            //        if (this._goodsAcs.CheckInputCalcStockRate(rowNo))
            //        {
            //            // �v�Z�����������͂���Ă���ꍇ�A�v�Z�����z�Čv�Z
            //            this._goodsAcs.SettingCalcStockRate(rowNo); // �v�Z�������ݒ�
            //            this._goodsAcs.SettingCalcSalesUnitCost(rowNo); // �v�Z�����z�ݒ菈��
            //            this._goodsAcs.SettingCalcMaster(rowNo); // �Z�o�}�X�^�ݒ菈��
            //        }
            //    }
            //}
            ////------------------------------------------------------------
            //// �d����
            ////------------------------------------------------------------
            //else if (cell.Column.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName)
            //{
            //    if (this._beforeStockRate != (double)e.Cell.Value)
            //    {
            //        this._goodsAcs.ClearCalcInfo(rowNo); // �Z�o���N���A
            //        this._goodsAcs.SettingCalcStockRate(rowNo); // �v�Z�������ݒ�
            //        this._goodsAcs.SettingCalcSalesUnitCost(rowNo); // �v�Z�����z�ݒ菈��
            //        this._goodsAcs.SettingCalcMaster(rowNo); // �Z�o�}�X�^�ݒ菈��
            //    }
            //}
            ////------------------------------------------------------------
            //// ���P��
            ////------------------------------------------------------------
            //else if (cell.Column.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName)
            //{
            //    if (this._beforeSalesUnitCost != (double)e.Cell.Value)
            //    {
            //        this._goodsAcs.ClearCalcInfo(rowNo); // �Z�o���N���A
            //        this._goodsAcs.SettingCalcStockRate(rowNo); // �v�Z�������ݒ�
            //        this._goodsAcs.SettingCalcSalesUnitCost(rowNo); // �v�Z�����z�ݒ菈��
            //        this._goodsAcs.SettingCalcMaster(rowNo); // �Z�o�}�X�^�ݒ菈��
            //    }
            //}

            //// ���i���ݒ�C�x���g�R�[��
            //this.SettingGoodsPriceEventCall(rowNo);
            #endregion

            // �O���b�h�Z���ݒ菈��
            this.SettingGridRow(rowIndex);
        }

        /// <summary>
        /// AfterRowActivate�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_UnitSalesPriceInfo_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.uGrid_UnitSalesPriceInfo.ActiveRow == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_UnitSalesPriceInfo.ActiveRow;

            //// ���i���ݒ�C�x���g�R�[��
            //this.SettingGoodsPriceEventCall(this.GetActiveRowRowNo());

            // �O���b�h�Z���ݒ菈��
            this.SettingGridRow(this.GetActiveRowIndex());
        }

        /// <summary>
        /// CellDataError�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_UnitSalesPriceInfo_CellDataError(object sender, Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs e)
        {
            if (this.uGrid_UnitSalesPriceInfo.ActiveCell != null)
            {
                // ���l���ڂ̏ꍇ
                if ((this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_UnitSalesPriceInfo.ActiveCell.EditorResolved;

                    // �����͂�0�ɂ���
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        editorBase.Value = 0;				// 0���Z�b�g
                        this.uGrid_UnitSalesPriceInfo.ActiveCell.Value = 0;
                    }
                    // ���l���ڂɁu-�vor�u.�v�������������ĂȂ�������ʖڂł�
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = 0;				// 0���Z�b�g
                        this.uGrid_UnitSalesPriceInfo.ActiveCell.Value = 0;
                    }
                    // �ʏ����
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_UnitSalesPriceInfo.ActiveCell.Column.DataType);
                            this.uGrid_UnitSalesPriceInfo.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;
                            this.uGrid_UnitSalesPriceInfo.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// �G���[�C�x���g�͔��������Ȃ�
                    e.RestoreOriginalValue = false;		// �Z���̒l�����ɖ߂��Ȃ�
                    e.StayInEditMode = false;			// �ҏW���[�h�͔�����
                }
            }
        }
        /// <summary>
        /// �O���b�h�E�o�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_UnitSalesPriceInfo_Leave( object sender, EventArgs e )
        {
            // �E�o��Ƀt�H�[�J�X��������
            if ( uGrid_UnitSalesPriceInfo.ActiveCell != null )
            {
                uGrid_UnitSalesPriceInfo.ActiveCell.Selected = false;
                uGrid_UnitSalesPriceInfo.ActiveCell = null;
                uGrid_UnitSalesPriceInfo.Invalidate();
            }
        }
        /// <summary>
        /// ���͉E�s����ݒ�
        /// </summary>
        /// <param name="enabled"></param>
        public void SettingEnabled( bool enabled )
        {
            _parentEnabled = enabled;
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_UnitSalesPriceInfo.DisplayLayout.Bands[0].Columns;

            try
            {
                if ( enabled )
                {
                    foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns )
                    {
                        column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    }
                }
                else
                {
                    foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns )
                    {
                        column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    }
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// �O���b�h���L�[�v���X�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_UnitSalesPriceInfo_KeyPress( object sender, KeyPressEventArgs e )
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = uGrid_UnitSalesPriceInfo.ActiveCell;

            switch ( cell.Row.Index )
            {
                // ������
                case 0:
                    {
                        if ( cell.IsInEditMode )
                        {
                            if ( !CheckMatchingSetRate( e, cell ) )
                            {
                                // �C�x���g�L�����Z������
                                e.Handled = true;
                            }
                        }
                    }
                    break;
                // �����z
                case 1:
                    {
                        if ( cell.IsInEditMode )
                        {
                            if ( !CheckMatchingSetPrice( e, cell ) )
                            {
                                // �C�x���g�L�����Z������
                                e.Handled = true;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// ���������̓L�[�v���X�`�F�b�N
        /// </summary>
        /// <param name="e"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private bool CheckMatchingSetRate( KeyPressEventArgs e, Infragistics.Win.UltraWinGrid.UltraGridCell cell )
        {
            return KeyPressNumCheck( 6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false );
        }
        /// <summary>
        /// �����z���̓L�[�v���X�`�F�b�N
        /// </summary>
        /// <param name="e"></param>
        /// <param name="cell"></param>
        /// <returns></returns>
        private bool CheckMatchingSetPrice( KeyPressEventArgs e, Infragistics.Win.UltraWinGrid.UltraGridCell cell )
        {
            return KeyPressNumCheck( 12, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false );
        }
        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="priod">�����_�ȉ�����</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <param name="minusFlg">�}�C�i�X���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        private bool KeyPressNumCheck( int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg )
        {
            // ����L�[�������ꂽ�H
            if ( Char.IsControl( key ) )
            {
                return true;
            }
            // ���l�ȊO�́A�m�f
            if ( !Char.IsDigit( key ) )
            {
                // �����_�܂��́A�}�C�i�X�ȊO
                if ( (key != '.') && (key != '-') )
                {
                    return false;
                }
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = "";
            if ( sellength > 0 )
            {
                _strResult = prevVal.Substring( 0, selstart ) + prevVal.Substring( selstart + sellength, prevVal.Length - (selstart + sellength) );
            }
            else
            {
                _strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if ( key == '-' )
            {
                if ( (minusFlg == false) || (selstart > 0) || (_strResult.IndexOf( '-' ) != -1) )
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if ( key == '.' )
            {
                if ( (priod <= 0) || (_strResult.IndexOf( '.' ) != -1) )
                {
                    return false;
                }
            }
            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring( 0, selstart )
                + key
                + prevVal.Substring( selstart + sellength, prevVal.Length - (selstart + sellength) );

            // �����`�F�b�N�I
            if ( _strResult.Length > keta )
            {
                if ( _strResult[0] == '-' )
                {
                    if ( _strResult.Length > (keta + 1) )
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // �����_�ȉ��̃`�F�b�N
            if ( priod > 0 )
            {
                // �����_�̈ʒu����
                int _pointPos = _strResult.IndexOf( '.' );

                // �������ɓ��͉\�Ȍ���������I
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // �������̌������`�F�b�N
                if ( _pointPos != -1 )
                {
                    if ( _pointPos > _Rketa )
                    {
                        return false;
                    }
                }
                else
                {
                    if ( _strResult.Length > _Rketa )
                    {
                        return false;
                    }
                }

                // �������̌������`�F�b�N
                if ( _pointPos != -1 )
                {
                    // �������̌������v�Z
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if ( priod < _priketa )
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// ���Ӑ�|���f���̂̎擾
        /// </summary>
        /// <returns></returns>
        private void SetCustRateGrpName()
        {
            int status = -1;
            
            UserGuideAcs userGuideAcs = new UserGuideAcs();
            ArrayList retList;

            this._custRateGrpNameDic = new Dictionary<int, string>();

            // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
            // ���Ӑ�|���O���[�v�R�[�h�̎w��Ȃ�
            this._custRateGrpNameDic.Add(ALL_RATE_GROUP_CODE, ALL_RATE_GROUP_CODE_NAME);
            // ADD 2009/11/20 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

            // ���Ӑ�|���f���̂̎擾
            status = userGuideAcs.SearchDivCodeBody(out retList, LoginInfoAcquisition.EnterpriseCode, 43, UserGuideAcsData.UserBodyData);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach(UserGdBd userGdBd in retList)
                {
                    if (!this._custRateGrpNameDic.ContainsKey(userGdBd.GuideCode))
                    {
                        this._custRateGrpNameDic.Add(userGdBd.GuideCode, userGdBd.GuideName);
                    }
                }
            }
        }
    }
}
