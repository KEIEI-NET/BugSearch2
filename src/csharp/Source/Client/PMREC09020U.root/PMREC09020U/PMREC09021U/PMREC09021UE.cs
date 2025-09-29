//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������i�ʐݒ�}�X�^
// �v���O�����T�v   : ���������i�ݒ�}�X�^�E���������i�ʐݒ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �� �� ��  2015/02/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/10  �C�����e : RedMine#351 ���P���̌����ɐ������������Ă��Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/11  �C�����e : �������ύX���ɕW�����i���ύX�ɂȂ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : ���I ���
// �X �V ��  2015/03/13  �C�����e : ���P����K�{���͂ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/16  �C�����e : �v�] ���J�敪��OFF�ɂ����ꍇ�ɔ񊈐����ڂ̒l���N���A���Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/25  �C�����e : ���[�J�[���i�擾���@�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/26  �C�����e : �i��Redmine#3247
//                                  PM���i�}�X�^(���[�U�[�o�^)����擾�������[�J�[���i�ɑ΂��ė����ݒ肪���f�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/04/08  �C�����e : �i��Redmine#3435
//                                  ���������i�̓��Ӑ�ʐݒ�I���K�C�h�œ��Ӑ�I����A
//                                  �u�߂�v��I�����Ă��K�C�h�̑I����Ԃ��ʐݒ��ʂɔ��f�����B
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Globalization; // ���t�`�F�b�N

using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���������i�ʐݒ�}�X�^ ���׃R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���������i�ʐݒ�}�X�^ ���׃R���g���[���N���X</br>
    /// <br>Programmer : �e�c ���V</br>
    /// <br>Date       : 2015/02/20</br>
    /// </remarks>
    public partial class PMREC09021UE : UserControl
    {

        #region �N���X

        # region [�O���b�h�Z����������N���X]
        /// <summary>
        /// �O���b�h�Z����������N���X(�J�X�^�}�C�Y)
        /// </summary>
        public class CustomMergedCellEvaluator : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
        {
            /// <summary>���������Z�����X�g</summary>
            private List<string> _joinColList;
            /// <summary>
            /// ���������Z�����X�g
            /// </summary>
            public List<string> JoinColList
            {
                get { return _joinColList; }
                set { _joinColList = value; }
            }

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public CustomMergedCellEvaluator()
            {
                _joinColList = new List<string>();
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public CustomMergedCellEvaluator(params string[] joinCols)
            {
                _joinColList = new List<string>(joinCols);
            }

            /// <summary>
            /// �Z���������菈��
            /// </summary>
            /// <param name="row1"></param>
            /// <param name="row2"></param>
            /// <param name="column"></param>
            /// <returns></returns>
            public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column)
            {
                foreach (string joinColName in JoinColList)
                {
                    if (!EqualCellValue(row1, row2, joinColName)) return false;
                }
                return true;
            }
            /// <summary>
            /// �Z��Value��r����
            /// </summary>
            /// <param name="row1"></param>
            /// <param name="row2"></param>
            /// <param name="columnName"></param>
            /// <returns></returns>
            private bool EqualCellValue(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, string columnName)
            {
                return ((row1.Cells[columnName].Value.ToString().Trim() == row2.Cells[columnName].Value.ToString().Trim()));
            }
        }

        ///// <summary>
        ///// �A�g���_�\����\��
        ///// </summary>
        //public void InqOtherSecHidden(bool hidden)
        //{
        //    Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
        //    if (editBand == null) return;

        //    editBand.Columns[this._RecBgnCustDataTable.InqOtherSecCdColumn.ColumnName].Hidden = hidden;		// �A�g���_
        //}

        # endregion

        # region [ColumnInfo]
        /// <summary>
        /// ColumnInfo
        /// </summary>
        [Serializable]
        public struct ColumnInfo
        {
            /// <summary>��</summary>
            private string _columnName;

            /// <summary>��</summary>
            private int _width;

            /// <summary>
            /// ��
            /// </summary>
            public string ColumnName
            {
                get { return _columnName; }
                set { _columnName = value; }
            }

            /// <summary>
            /// ��
            /// </summary>
            public int Width
            {
                get { return _width; }
                set { _width = value; }
            }

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="columnName">��</param>
            /// <param name="width">��</param>
            public ColumnInfo(string columnName, int width)
            {
                _columnName = columnName;
                _width = width;
            }
        }
        # endregion

        #region ���������i�ݒ�}�X�^�p�O���b�h�ݒ�N���X

        /// <summary>
        /// ���������i�ݒ�}�X�^�p�O���b�h�ݒ�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�p�O���b�h�ݒ�N���X</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// <br></br>
        /// </remarks>
        [Serializable]
        public class RecBgnCustUserSet
        {
            #region Private Member

            // �o�͌`��
            private int _outputStyle;

            // ���׃O���b�h�J�������X�g
            private List<ColumnInfo> _detailColumnsList;

            // ���׃O���b�h�����T�C�Y����
            private bool _autoAdjustDetail;

            #endregion

            # region constractors
            /// <summary>
            /// ���������i�ݒ�}�X�^�p�O���b�h�ݒ�N���X
            /// </summary>
            public RecBgnCustUserSet()
            {

            }
            # endregion

            #region Public Methods
            /// <summary>�o�͌^��</summary>
            public int OutputStyle
            {
                get { return this._outputStyle; }
                set { this._outputStyle = value; }
            }

            /// <summary>���׃O���b�h�J�������X�g</summary>
            public List<ColumnInfo> DetailColumnsList
            {
                get { return this._detailColumnsList; }
                set { this._detailColumnsList = value; }
            }

            /// <summary>���׃O���b�h�����T�C�Y����</summary>
            public bool AutoAdjustDetail
            {
                get { return _autoAdjustDetail; }
                set { _autoAdjustDetail = value; }
            }
            #endregion
        }

        #endregion

        #endregion

        # region Private Members

        #region �萔

        /// <summary>�c�[���o�[:�s�폜</summary>
        private const string TOOLBAR_ROWDELETEBUTTON_KEY = "ButtonTool_RowDelete";						// �s�폜
        /// <summary>�S�Аݒ�:���_�R�[�h'00'</summary>
        private const string ALL_SECTION_CODE = "00";
        /// <summary>�S�Аݒ�:���_��'�S��'</summary>
        private const string ALL_SECTION_NAME = "�S��";
        /// <summary>�ݒ�XML�t�@�C����</summary>
        private const string XML_FILE_NAME = "PMREC09020U_Construction.XML";

        #endregion

        #region �ϐ�

        private RecBgnGdsDataSet.RecBgnGdsRow _recBgnGdsRow;
        private RecBgnGdsDataSet.RecBgnCustDataTable _recBgnCustDataTable;
        private RecBgnGdsDataSet.RecBgnCustTmpDataTable _recBgnCustTmpDataTable;
        private RecBgnGdsDataSet.SecCusSetDataTable _secCusSetDataTable;
        private GoodsUnitData _swGoodsUnitData;
        // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
        private Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> _swMkrSuggestRtPricList;
        private Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> _swMkrSuggestRtPricUList;
        // --- ADD 2015/03/25 Y.Wakita ----------<<<<<
        private Calculator _calculator = null;

        private ButtonTextCustomizableMessageBox _imageMsg = new ButtonTextCustomizableMessageBox();

        private static readonly Color ct_DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color ct_DISABLE_FONT_COLOR = Color.Black;
        private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));

        /// <summary> ��ƃR�[�h</summary>
        private string _enterpriseCode = string.Empty;
        /// <summary> ���O�C�����_</summary>
        private string _loginSectionCode = string.Empty;
        /// <summary> ���Ӑ���</summary>
        private string _swCustomerInfo = string.Empty;
        /// <summary> ���������i��ٰ�ߏ��</summary>
        private short _swRecBgnGrpInfo = 0;

        /// <summary> ���������i�ݒ�}�X�^�A�N�Z�X�N���X</summary>
        private RecBgnGdsAcs _recBgnGdsAcs = null;
        /// <summary> SCM��ƘA���f�[�^�A�N�Z�X�N���X</summary>
        private ScmEpScCntAcs _scmEpScCntAcs;
        /// <summary> ���_�}�X�^�A�N�Z�X�N���X</summary>
        private SecInfoSetAcs _secInfoSetAcs;
        /// <summary> ���[�U�[�K�C�h�A�N�Z�X�N���X</summary>
        private UserGuideAcs _userGuideAcs;

        /// <summary> ���[�U�[�ݒ�</summary>
        private RecBgnCustUserSet _userSetting;
        /// <summary> ���_�}�X�^���X�g</summary>
        private List<SecInfoSet> _secInfoSetList;

        /// <summary> ���Ӑ挟������</summary>
        private CustomerSearchRet _customerSearchRet = null;
        /// <summary> ���������i�O���[�v��������</summary>
        private RecBgnGrpRet _recBgnGrpRet = null;

        /// <summary> ���̎擾</summary>
        private bool isUnMatched = false;

        #endregion

        #endregion

        #region EventHandlers

        /// <summary>�K�C�h�{�^�� �C�x���g�n���h��</summary>
        internal event SetGuidButtonEventHandler SetGuidButton;
        /// <summary>�K�C�h�{�^�� �C�x���g�n���h���E�f���Q�[�g</summary>
        internal delegate void SetGuidButtonEventHandler(Boolean enable);

        #endregion

        #region Public �v���p�e�B

        /// <summary>
        /// ���������i�ݒ�}�X�^ �A�N�Z�X�N���X�v���p�e�B
        /// </summary>
        public RecBgnGdsAcs RecBgnGdsAcs
        {
            get { return this._recBgnGdsAcs; }
        }

        /// <summary>
        /// ���������i�ݒ�}�X�^ ���i�Z�o�A�N�Z�X�N���X�v���p�e�B
        /// </summary>
        public Calculator Calculator
        {
            get { return this._calculator; }
        }

        /// <summary>
        /// ���[�U�̃v���p�e�B
        /// </summary>
        public RecBgnCustUserSet UserSetting
        {
            get { return this._userSetting; }
        }
        #endregion

        # region Constroctors

        /// <summary>
        /// ���͖��ד��̓R���g���[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���͖��ד��̓R���g���[���N���X �f�t�H���g���s���R���g���[���N���X�ł��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public PMREC09021UE(RecBgnGdsCustInfo recBgnGdsCustInfo)
        {
            InitializeComponent();

            // TODO �p�����[�^�ύX
            this._recBgnGdsRow = recBgnGdsCustInfo.recBgnGdsRow;
            this._recBgnCustDataTable = (RecBgnGdsDataSet.RecBgnCustDataTable)recBgnGdsCustInfo.recBgnCust.Copy();
            this._swGoodsUnitData = (GoodsUnitData)recBgnGdsCustInfo.recBgnGdsRow.goodsUnitData;
            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
            this._swMkrSuggestRtPricList = (Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>)recBgnGdsCustInfo.recBgnGdsRow.mkrSuggestRtPricList;
            this._swMkrSuggestRtPricUList = (Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>)recBgnGdsCustInfo.recBgnGdsRow.mkrSuggestRtPricUList;
            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<
            this._recBgnCustTmpDataTable = new RecBgnGdsDataSet.RecBgnCustTmpDataTable();
            this._secCusSetDataTable = new RecBgnGdsDataSet.SecCusSetDataTable();
            
            // ��ƃR�[�h
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._recBgnGdsAcs = new RecBgnGdsAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._userGuideAcs = new UserGuideAcs();

            this._userSetting = new RecBgnCustUserSet();
            this._scmEpScCntAcs = new ScmEpScCntAcs();
            this._secInfoSetList = new List<SecInfoSet>();
            this._calculator = new Calculator();

        }
        #endregion

        #region Public Methods

        #region �O���b�h�J�������

        /// <summary>
        /// �O���b�h�J�������̕ۑ�
        /// </summary>
        /// <param name="fontSize">fontSize</param>
        /// <param name="autoFillToGrid">autoFillToGrid</param>
        public void SaveSettings(int fontSize, bool autoFillToGrid)
        {
            // ���׃O���b�h
            List<ColumnInfo> detailColumnsList;
            this.SaveGridColumnsSetting(uGrid_Details, out detailColumnsList);
            this._userSetting.DetailColumnsList = detailColumnsList;
            this._userSetting.OutputStyle = fontSize;
            this._userSetting.AutoAdjustDetail = autoFillToGrid;
        }

        /// <summary>
        /// �O���b�h�J�������̓ǂݍ���
        /// </summary>
        public void LoadSettings()
        {
            this.LoadGridColumnsSetting(ref uGrid_Details, this._userSetting.DetailColumnsList);
        }

        /// <summary>
        /// �O���b�h�J�������̕ۑ�
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        private void SaveGridColumnsSetting(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, out List<ColumnInfo> settingList)
        {
            settingList = new List<ColumnInfo>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                settingList.Add(new ColumnInfo(ultraGridColumn.Key, ultraGridColumn.Width));
            }
        }

        #endregion

        #region �`�F�b�N����

        /// <summary>
        /// �ԋp�f�[�^�L��
        /// </summary>
        /// <returns>true:�L false:��</returns>
        public bool IsUpdated()
        {
            foreach (RecBgnGdsDataSet.RecBgnCustRow row in this._recBgnCustDataTable.Rows)
            {
                if (row.RowDevelopFlg == 1 && (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// �ۑ��O�`�F�b�N����
        /// </summary>
        /// <param name="deleteList">�폜���X�g</param>
        /// <param name="updateList">�X�V���X�g</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��O�`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public bool CheckSaveDate(out RecBgnGdsDataSet.RecBgnCustDataTable recBgnCustDataTable)
        {
            recBgnCustDataTable = null;

            #region �K�{�`�F�b�N

            foreach (RecBgnGdsDataSet.RecBgnCustRow row in this._recBgnCustDataTable.Rows)
            {

                //�s�ԍ����擾
                int rowIndex = row.RowNo;

                // ���Ӑ�R�[�h����̓`�F�b�N
                if (row.RowDevelopFlg != 0 && row.CustomerCode.Trim().Equals(string.Empty))
                {
                    TMsgDisp.Show(
                         this,
                         emErrorLevel.ERR_LEVEL_EXCLAMATION,
                         this.Name,
                         "���Ӑ�R�[�h����͂��ĉ������B",
                         0,
                         MessageBoxButtons.OK);
                    if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                    {
                        this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    return false;
                }

                // ���������i�O���[�v�R�[�h
                if (row.RowDevelopFlg != 0 && row.DisplayDivCode !=0 && row.BrgnGoodsGrpCode == 0)
                {
                    TMsgDisp.Show(
                         this,
                         emErrorLevel.ERR_LEVEL_EXCLAMATION,
                         this.Name,
                         "���������i�O���[�v�R�[�h����͂��ĉ������B",
                         0,
                         MessageBoxButtons.OK);
                    if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                    {
                        this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    return false;
                }

                //---------ADD 2015/03/13 ���I--------->>>>>>
                // ���P������̓`�F�b�N
                if (row.RowDevelopFlg != 0 && row.DisplayDivCode != 0 && row.UnitPrice == 0)
                {
                    TMsgDisp.Show(
                         this,
                         emErrorLevel.ERR_LEVEL_EXCLAMATION,
                         this.Name,
                         "���P������͂��ĉ������B",
                         0,
                         MessageBoxButtons.OK);
                    if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                    {
                        this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    return false;
                }
                //---------ADD 2015/03/13 ���I---------<<<<<<
            }
            #endregion

            #region �d���`�F�b�N
            foreach (RecBgnGdsDataSet.RecBgnCustRow bgn in this._recBgnCustDataTable.Rows)
            {

                //�s�ԍ����擾
                int rowIndex = bgn.RowNo;
                
                // �ϊ�
                RecBgnCust recBgnCust= null;
                this.CopyToRecBgnCustFromDetailRow(bgn, ref recBgnCust);

                int flag = 0;
                string errorMsg = string.Empty;

                #region �d�����R�[�h�̑��݃`�F�b�N
                flag = 0;
                foreach (RecBgnGdsDataSet.RecBgnCustRow row in this._recBgnCustDataTable.Rows)
                {
                    if (row.RowNo == bgn.RowNo) continue;

                    if (recBgnCust.InqOriginalEpCd == row.InqOriginalEpCd
                        && recBgnCust.InqOriginalSecCd == row.InqOriginalSecCd
                        && recBgnCust.InqOtherEpCd == row.InqOtherEpCd
                        && recBgnCust.InqOtherSecCd.ToString().PadLeft(2, '0') == row.InqOtherSecCd.ToString().PadLeft(2, '0'))
                    {
                        errorMsg = "���J���F" + recBgnCust.ApplyStaDate.ToString().PadLeft(6, '0')
                               + "�`" + recBgnCust.ApplyEndDate.ToString().PadLeft(6, '0')
                               + "�A���Ӑ�F" + recBgnCust.CustomerCode.ToString().PadLeft(8, '0');

                        int startDate = 0;
                        if (!row.ApplyStaDate.Trim().Equals(string.Empty)) startDate = int.Parse(row.ApplyStaDate.Trim().Replace("/", ""));
                        int endDate = 0;
                        if (!row.ApplyEndDate.Trim().Equals(string.Empty)) endDate = int.Parse(row.ApplyEndDate.Trim().Replace("/", ""));

                        if ((startDate <= recBgnCust.ApplyStaDate
                            && recBgnCust.ApplyStaDate <= endDate)
                            || (startDate <= recBgnCust.ApplyEndDate
                            && recBgnCust.ApplyEndDate <= endDate))
                        {
                            flag++;
                        }
                    }
                    if (flag > 1)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "���꓾�Ӑ�̐ݒ肪���ɓo�^����Ă��܂��B" + "\r\n" +
                             errorMsg,
                             0,
                             MessageBoxButtons.OK);

                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }
                }
                #endregion
            }
            #endregion

            recBgnCustDataTable = this._recBgnCustDataTable;
            return true;
        }

        /// <summary>
        /// DOWN�O�`�F�b�N����
        /// </summary>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��O�`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2011/07/06</br>
        /// </remarks>
        public bool CheckDateForDown()
        {
            RecBgnCust recBgnCust = new RecBgnCust();
            this.CopyToRecBgnCustFromDetailRow((RecBgnGdsDataSet.RecBgnCustRow)this._recBgnCustDataTable.Rows[this._recBgnCustDataTable.Count - 1], ref recBgnCust);

            // ���Ӑ�R�[�h����̓`�F�b�N
            if (recBgnCust.CustomerCode == 0)
            {
                return false;
            }
            return true;
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
        /// <remarks>
        /// <br>Note        : ���l���̓`�F�b�N����</br>
        /// <br>Programmer  : �e�c ���V</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        public bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }
            // ���l�ȊO�́A�m�f
            if (!Char.IsDigit(key))
            {
                // �����_�܂��́A�}�C�i�X�ȊO
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = string.Empty;
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
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
            if (priod > 0)
            {
                // �����_�̈ʒu����
                int _pointPos = _strResult.IndexOf('.');

                // �������ɓ��͉\�Ȍ���������I
                int _Rketa = RecBgnGdsAcs.diverge<int>(_strResult[0] == '-', keta - priod, keta - priod - 1);
                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (_strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    // �������̌������v�Z
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// ���t���̓`�F�b�N����
        /// </summary>
        /// <param name="keta">����(�X���b�V���������܂܂�)</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <remarks>
        /// <br>Note        : ���t���̓`�F�b�N����</br>
        /// <br>Programmer  : ���� ��Y</br>
        /// <br>Date        : 2015/02/09</br>
        /// </remarks>
        public bool KeyPressDateCheck(int keta, string prevVal, char key, int selstart, int sellength)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }
            // ���l�ȊO�́A�m�f
            if (!Char.IsDigit(key))
            {
                // �X���b�V���ȊO
                if (key != '/') return false;
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = string.Empty;
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '/')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region �O���b�h

        /// <summary>
        /// ReturnKey��������(�O���b�h��)
        /// </summary>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ReturnKey�����������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void ReturnKeyDown(ref ChangeFocusEventArgs e)
        {
            if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow == null))
            {
                this.uGrid_Details.Rows[0].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Activate();
            }

            string columnKey;
            int rowIndex;

            if (this.uGrid_Details.ActiveCell != null)
            {
                columnKey = this.uGrid_Details.ActiveCell.Column.Key;
                rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            }
            else
            {
                columnKey = this._recBgnCustDataTable.CustomerCodeColumn.ColumnName;
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }

            e.NextCtrl = null;

            //if (this.uGrid_Details.ActiveRow != null)
            //{
            //    if (this.uGrid_Details.ActiveRow.Selected)
            //    {
            //        this.uGrid_Details.ActiveRow.Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activate();
            //        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
            //        return;
            //    }
            //}

            this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

            // ���̓G���[���͈ړ������Ȃ�
            if (isUnMatched)
            {
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                isUnMatched = false;
                    return;
                }

            MoveNextAllowEditCell(false);

        }

        /// <summary>
        /// ShiftKey��������(�O���b�h��)
        /// </summary>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ShiftKey�����������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void ShiftKeyDown(ref ChangeFocusEventArgs e)
        {
            if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow == null))
            {
                this.uGrid_Details.Rows[0].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Activate();
            }

            string columnKey;
            int rowIndex;

            if (this.uGrid_Details.ActiveCell != null)
            {
                columnKey = this.uGrid_Details.ActiveCell.Column.Key;
                rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            }
            else
            {
                columnKey = this._recBgnCustDataTable.CustomerCodeColumn.ColumnName;
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }

            e.NextCtrl = null;

            if (this.uGrid_Details.ActiveRow != null)
            {
                if (this.uGrid_Details.ActiveRow.Selected)
                {
                    if (this.uGrid_Details.ActiveRow.Index > 0)
                    {
                        if (this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].Activation == Activation.AllowEdit)
                        {
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        else
                        {
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                    }
                    return;
                }
            }

            this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

            MovePreAllowEditCell(false);
        }

        /// <summary>
        /// ���ו��A�N�b�`�u�L�[���擾
        /// </summary>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <remarks>
        /// <br>Note       : ���ו��A�N�b�`�u�L�[���擾���s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public string GetFocusColumnKey(out int rowIndex, out RecBgnGdsDataSet.RecBgnCustRow dataRow)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                rowIndex = -1;
                dataRow = null;
                return string.Empty;
            }

            rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            dataRow = (RecBgnGdsDataSet.RecBgnCustRow)this._recBgnCustDataTable.Rows[rowIndex];
            return this.uGrid_Details.ActiveCell.Column.Key;
        }

        #endregion ReturnKeyDown

        #region �K�C�h
        /// <summary>
        /// �K�C�h�{�^���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �K�C�h�{�^���ݒ菈�����s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void SetGridGuid()
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                switch (this.uGrid_Details.ActiveCell.Column.Key)
                {
                    case "CustomerCode":
                    case "BrgnGoodsGrpCode": 
                        {
                            if (this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                            {
                                this.SetGuidButton(true);
                            }
                            else
                            {
                                this.SetGuidButton(false);
                            }
                            break;
                        }
                    default:
                        {
                            this.SetGuidButton(false);
                            break;
                        }
                }
            }
            else
            {
                this.SetGuidButton(false);
            }
        }

        #endregion

        #endregion

        #region Private Methods

        #region ControlEvents

        #region �t�H�[��

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note	   : �t�H�[�����ǂݍ��܂ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void PMREC09021UE_Load(object sender, EventArgs e)
        {
            // �f�[�^�\�[�X�Ƃ��ăf�[�^�r���[���w��
            this.uGrid_Details.DataSource = this._recBgnCustDataTable;

            // ������
            this.Init(false);

            #region �q��ʗp�ǉ�
            // ���_���̃L���b�V��
            ArrayList list = new ArrayList();
            this._secInfoSetAcs.Search(out list, this._enterpriseCode);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GetType().Equals(typeof(SecInfoSet)))
                {
                    this._secInfoSetList.Add((SecInfoSet)list[i]);
                }
            }
            #endregion
        }

        #endregion

        #region Toolbar
        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note	   : �t�H�[�����ǂݍ��܂ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �s�폜
                case TOOLBAR_ROWDELETEBUTTON_KEY:
                    {
                        this.uButton_RowDelete_Click(sender, new EventArgs());
                        break;
                    }
            }
        }

        #endregion

        #region �{�^��


        /// <summary>
        /// �s�폜
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        private void DeleteRow(RecBgnGdsDataSet.RecBgnCustRow row)
        {

            // �s�N���A
            this._recBgnCustDataTable.Rows.Remove(row);
            this.AddNewRow();
            AcceptChangesRecBgnCustDataRow();
            this._recBgnCustTmpDataTable.AcceptChanges();

        }
        
        /// <summary>
        /// �s�폜�i���꓾�Ӑ�s�ꊇ�폜�j
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        private void DeleteRow(string customerCode)
        {
            // �m��s�͓��꓾�Ӑ�s��S�č폜����
            if (!customerCode.Equals(string.Empty))
            {
                DataRow[] rows = this._recBgnCustDataTable.Select("CustomerCode = '" + customerCode + "'");
                for (int i = 0; i < rows.Length; i++)
                {
                    _recBgnCustDataTable.Rows.Remove(rows[i]);
                }
                this._recBgnCustTmpDataTable.AcceptChanges();
                AcceptChangesRecBgnCustDataRow();

            }

        }
        
        /// <summary>
        /// �s�폜����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �s�폜�������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void uButton_RowDelete_Click(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null) return;

            DialogResult dialogResult = TMsgDisp.Show(this
                                                     , emErrorLevel.ERR_LEVEL_QUESTION
                                                     , this.Name
                                                     , "���ׂ��N���A���Ă���낵���ł����H"
                                                     , 0
                                                     , MessageBoxButtons.YesNo
                                                     , MessageBoxDefaultButton.Button1);

            if (dialogResult == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                this.uGrid_Details.BeginUpdate();

                // �A�N�e�B�u�s���
                int activeRowIndex = this.uGrid_Details.ActiveRow.Index;
                RecBgnGdsDataSet.RecBgnCustRow row = (RecBgnGdsDataSet.RecBgnCustRow)this._recBgnCustDataTable.Rows[activeRowIndex];

                // ���m��̐V�K�s�̓N���A����
                if (row.RowDevelopFlg == 0)
                {
                    DeleteRow(row);
                    this.uGrid_Details.EndUpdate();
                    this.Cursor = Cursors.Default;
                    return;
                }

                // �m��s�͓��꓾�Ӑ���ꊇ�폜����
                DeleteRow(row.CustomerCode);

                this.uGrid_Details.EndUpdate();
                this.Cursor = Cursors.Default;

                // ------------------------------------------
                // Active�ɂ���s�����
                int rowIndex = 0;
                if (activeRowIndex < this._recBgnCustDataTable.Rows.Count - 1)
                {
                    rowIndex = activeRowIndex;
                }
                else
                {
                    rowIndex = this._recBgnCustDataTable.Rows.Count - 1;
                }
                if (rowIndex < 0) rowIndex = 0;

                // �V�K�s�͓��Ӑ�A�����͕\���敪���A�N�e�B�u
                RecBgnGdsDataSet.RecBgnCustRow updateRow = (RecBgnGdsDataSet.RecBgnCustRow)this._recBgnCustDataTable.Rows[rowIndex];
                if (updateRow.RowDevelopFlg == 0)
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Activate();
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Activate();
                }
            }
            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
        }

        #endregion

        #region Grid
        /// <summary>
        /// ���׏������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note	   : ���׏������C�x���g���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.uGrid_Details.BeginUpdate();

            // �O���b�h�񏉊��ݒ菈��
            this.InitialSettingGridCol();

            this.uGrid_Details.EndUpdate();
        }

        /// <summary>
        /// �Z���̃f�[�^�`�F�b�N����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <returns/>
        /// <remarks>
        /// <br>Note       : �Z���̃f�[�^�`�F�b�N�����B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                // ���l���ڂ̏ꍇ
                if ((this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int16)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;

                    // �����͂�0�ɂ���				
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        //editorBase.Value = 0;				// 0���Z�b�g
                        //this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // ���l���ڂɁu-�vor�u.�v�������������ĂȂ�������ʖڂł�				
                    else if ((editorBase.CurrentEditText.Trim() == "-")
                          || (editorBase.CurrentEditText.Trim() == ".")
                          || (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = this.uGrid_Details.ActiveCell.Value;				// �O��l���Z�b�g
                    }
                    // �ʏ����				
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_Details.ActiveCell.Column.DataType);
                            this.uGrid_Details.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;				// 0���Z�b�g
                            this.uGrid_Details.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// �G���[�C�x���g�͔��������Ȃ�
                    e.RestoreOriginalValue = false;		// �Z���̒l�����ɖ߂��Ȃ�	
                    e.StayInEditMode = false;			// �ҏW���[�h�͔�����
                }
            }
        }

        /// <summary>
        /// �O���b�h�Z���A�N�e�B�u�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Z���A�N�e�B�u�㔭���C�x���g</br>
        /// <br>Programmer  : �e�c ���V</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            this.SetGridGuid();

            //// ���i���v���r���[�\��
            //this.GoodsInfoPreview(this.uGrid_Details.ActiveRow.Index);
        }

        /// <summary>
        /// �O���b�h�Z���A�N�e�B�u�O�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Z���A�N�e�B�u�O�����C�x���g</br>
        /// <br>Programmer  : �e�c ���V</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;

            // ���̑� IME�𖳌�
            this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Disable;

            // ���Ӑ�R�[�h
            if (cell.Column.Key == this._recBgnCustDataTable.CustomerCodeColumn.ColumnName)
            {
                this._swCustomerInfo = e.Cell.Value.ToString().PadLeft(8, '0');
            }
            // ���������i�O���[�v�R�[�h
            else if (cell.Column.Key == this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName)
            {
                this._swRecBgnGrpInfo = (Int16)e.Cell.Value;
            }
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : �e�c ���V</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {

            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            string columnKey = this.uGrid_Details.ActiveCell.Column.Key;

            if (this.uGrid_Details.ActiveCell.IsInEditMode)
            {
                if (this.uGrid_Details.ActiveCell.Editor != null)
                {
                    if (e.KeyCode == Keys.Left && this.uGrid_Details.ActiveCell.SelStart != 0)
                    {
                        return;
                    }
                    if (e.KeyCode == Keys.Right && this.uGrid_Details.ActiveCell.SelStart < this.uGrid_Details.ActiveCell.Text.Length)
                    {
                        return;
                    }
                }
            }

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (rowIndex == 0)
                        {
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = true;
                            this.uGrid_Details.Rows[rowIndex - 1].Cells[columnKey].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Down:
                case Keys.Return:
                    {
                        this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                        if (rowIndex == this.uGrid_Details.Rows.Count - 1)
                        {
                            e.Handled = true;
                            if (CheckDateForDown())
                            {
                                // ���דW�J����
                                if (this.BgnDataDeployment() == true)
                                {
                                    this.AddNewRow();

                                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.AllowEdit;
                                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            e.Handled = true;
                            this.uGrid_Details.Rows[rowIndex + 1].Cells[columnKey].Activate();
                        }
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                case Keys.Left:
                    {
                        this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                        // ���Ӑ�̏ꍇ
                        if (columnKey == this._recBgnCustDataTable.CustomerCodeColumn.ColumnName)
                        {
                            // ���[���玟�s���[�Ɉړ������Ȃ�
                            if (this.uGrid_Details.ActiveCell.Column.Header.VisiblePosition == 1)
                            {
                                e.Handled = true;
                            }
                            else
                            {
                                e.Handled = true;
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                break;
                            }
                        }
                        else
                        {
                            // ���Z���擾
                            string columnName = columnKey;
                            // ���Z���擾
                            int targetColumnIndex = GetNextColumnIndexByTab(1, rowIndex, columnName);

                            if (targetColumnIndex != -1)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[targetColumnIndex].Activate();
                            }
                            else
                            {
                                columnName = this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName;
                                this.uGrid_Details.Rows[rowIndex - 1].Cells[columnName].Activate();
                            }
                        }

                        e.Handled = true;
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                case Keys.Right:
                    {
                        if (columnKey == this._recBgnCustDataTable.UpdateTimeColumn.ColumnName)
                        {
                            // �Ȃ��B
                        }
                        else if (columnKey == this._recBgnCustDataTable.UnitPriceColumn.ColumnName)
                        {
                            // �E�[��VisiblePosition���擾
                            int lastPosition = this.GetGridLastPosition(this.uGrid_Details);

                            // �E�[���玟�s���[�Ɉړ������Ȃ�
                            if (this.uGrid_Details.ActiveCell.Column.Header.VisiblePosition == lastPosition)
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                            // ���Z���擾
                            string columnName = columnKey;
                            // ���Z���擾
                            int targetColumnIndex = GetNextColumnIndexByTab(0, rowIndex, columnName);

                            if (targetColumnIndex != -1)
                            {
                                //if (focusFlg)
                                //{
                                this.uGrid_Details.Rows[rowIndex].Cells[targetColumnIndex].Activate();
                                //}
                            }
                            else
                            {
                                if (rowIndex < this.uGrid_Details.Rows.Count - 1)
                                {
                                    // ���s
                                    columnName = this._recBgnCustDataTable.CustomerCodeColumn.ColumnName;
                                    this.uGrid_Details.Rows[rowIndex + 1].Cells[columnName].Activate();
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                            }

                            e.Handled = true;
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
            }

        }

        /// <summary>
        /// �O���b�h���̍Ō��VisiblePosition�擾
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private int GetGridLastPosition(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            if (grid.ActiveRow == null) return 0;

            int colCount = 0;
            for (int index = 0; index < grid.ActiveRow.Cells.Count; index++)
            {
                if (grid.ActiveRow.Cells[index].Column.Hidden == false)
                {
                    if (colCount < grid.ActiveRow.Cells[index].Column.Header.VisiblePosition)
                    {
                        colCount = grid.ActiveRow.Cells[index].Column.Header.VisiblePosition;
                    }
                }
            }
            return colCount;
        }

        /// <summary>
        /// �O���b�h���̍őO��VisiblePosition�擾
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private int GetGridFirstPosition(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            if (grid.ActiveRow == null) return 0;

            int colCount = 5;
            for (int index = 0; index < grid.ActiveRow.Cells.Count; index++)
            {
                if (grid.ActiveRow.Cells[index].Column.Hidden == false)
                {
                    if (colCount > grid.ActiveRow.Cells[index].Column.Header.VisiblePosition)
                    {
                        colCount = grid.ActiveRow.Cells[index].Column.Header.VisiblePosition;
                    }
                }
            }
            return colCount;
        }

        /// <summary>
        /// �O���b�h�Z���A�v�f�g�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Z���A�v�f�g�㔭���C�x���g</br>
        /// <br>Programmer  : �e�c ���V</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;
            UltraGridRow row = e.Cell.Row;
            

            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;

            // ���Ӑ�
            if (cell.Column.Key == this._recBgnCustDataTable.CustomerCodeColumn.ColumnName)
            {
                int inputValue = 0;

                // ���͒l���擾
                Int32.TryParse(cell.Value.ToString(), out inputValue);

                if (inputValue != 0)
                {
                    string errMsg = string.Empty;

                    // ���͒l���擾
                    Int32.TryParse(cell.Value.ToString(), out inputValue);
                    if (this._recBgnGdsAcs.CheckCustomer(inputValue, true, out errMsg))
                    {
                        CustomerInfo customerInfo = this._recBgnGdsAcs.CustomerDic[inputValue];
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Value = inputValue.ToString().PadLeft(8, '0');    // ���Ӑ�R�[�h
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].Value = customerInfo.CustomerSnm;                 // ���Ӑ於
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.InqOriginalEpCdColumn.ColumnName].Value = customerInfo.CustomerEpCode;           // �⍇������ƃR�[�h
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.InqOriginalSecCdColumn.ColumnName].Value = customerInfo.CustomerSecCode;         // �⍇�������_�R�[�h
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.MngSectionCodeColumn.ColumnName].Value = customerInfo.MngSectionCode;            // �Ǘ����_
                        this._swCustomerInfo = inputValue.ToString().PadLeft(8, '0');
                    }
                    else
                    {
                        TMsgDisp.Show(this
                                     , emErrorLevel.ERR_LEVEL_EXCLAMATION
                                     , this.Name
                                     , errMsg
                                     , 0
                                     , MessageBoxButtons.OK);

                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Value = this._swCustomerInfo.ToString().PadLeft(8, '0');
                        isUnMatched = true;
                    }
                }
                else
                {
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Value = string.Empty;     // ���Ӑ�R�[�h
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].Value = string.Empty;     // ���Ӑ於
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.InqOriginalEpCdColumn.ColumnName].Value = string.Empty;  // �⍇������ƃR�[�h
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.InqOriginalSecCdColumn.ColumnName].Value = string.Empty; // �⍇�������_�R�[�h
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.MngSectionCodeColumn.ColumnName].Value = string.Empty;   // �Ǘ����_
                    this._swCustomerInfo = string.Empty;
                }
            }

            // ���������i�O���\�v
            if (cell.Column.Key == this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName)
            {
                short gdsGrpCode = 0;
                short.TryParse(cell.Value.ToString(), out gdsGrpCode);

                // ���J����ꍇ�̂�
                if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Text != "0")
                {

                    // ���͒l���擾
                    if (!cell.Value.ToString().Trim().Equals(string.Empty))
                    {
                        string errMsg = string.Empty;

                        RecBgnGdsDataSet.RecBgnCustRow dataRow = (RecBgnGdsDataSet.RecBgnCustRow)this._recBgnCustDataTable.Rows[cell.Row.Index];

                        if (this._recBgnGdsAcs.CheckRecBgnGrp(dataRow.InqOriginalEpCd, dataRow.InqOriginalSecCd, gdsGrpCode, true, out errMsg))
                        {
                            string recBgnGrpName = this._recBgnGdsAcs.GetRecBgnGrpName(dataRow.InqOriginalEpCd, dataRow.InqOriginalSecCd, gdsGrpCode);

                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = gdsGrpCode;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = recBgnGrpName;
                            this._swRecBgnGrpInfo = gdsGrpCode;
                        }
                        else
                        {
                            TMsgDisp.Show(this
                                         , emErrorLevel.ERR_LEVEL_EXCLAMATION
                                         , this.Name
                                         , errMsg
                                         , 0
                                         , MessageBoxButtons.OK);

                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = this._swRecBgnGrpInfo;
                            this.isUnMatched = true;
                        }
                    }
                    else
                    {
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = 0;
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = string.Empty;
                        this._swRecBgnGrpInfo = 0;
                    }
                }
            }

            // ������
            if (cell.Column.Key == this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName)
            {

                double inputValue = 0.0;
                double.TryParse(cell.Value.ToString(), out inputValue);

                RecBgnGdsDataSet.RecBgnCustRow dataRow = (RecBgnGdsDataSet.RecBgnCustRow)this._recBgnCustDataTable.Rows[row.Index];
                if (dataRow.RowDevelopFlg==0) return;

                // ���J����ꍇ�̂�
                if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Text != "0")
                {
                    // ���Ӑ�Ɣ������̓��͎��ɔ����v�Z
                    if (inputValue != 0
                        && !dataRow.CustomerCode.Trim().Equals(string.Empty))
                    {

                        string sectionCode = dataRow.MngSectionCode;                            // �Ǘ����_
                        int customerCode = int.Parse(dataRow.CustomerCode);                     // ���Ӑ�
                        long mkrSuggestRtPric = dataRow.MkrSuggestRtPric;                       // ���[�J�[��]���i
                        DateTime startTime = DateTime.Parse(this._recBgnGdsRow.ApplyStaDate);   // �J�n��
                        double listPrice = 0;                                                   // �艿
                        double unitPrice = 0;                                                   // ����

                        // ���i�v�Z
                        this._calculator.GetUnitPriceFromRate(sectionCode, customerCode, mkrSuggestRtPric, inputValue, this._swGoodsUnitData, startTime, out listPrice, out unitPrice);

                        //this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Value = (long)listPrice;     // �艿    // DEL 2015/03/11 Y.Wakita
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Value = (long)unitPrice;     // ����

                    }
                    else
                    {
                        if (!dataRow.CustomerCode.Trim().Equals(string.Empty))
                        {
                            string sectionCode = dataRow.MngSectionCode;                            // ���_
                            int customerCode = int.Parse(dataRow.CustomerCode);                     // ���Ӑ�
                            long mkrSuggestRtPric = dataRow.MkrSuggestRtPric;                       // ���[�J�[��]���i
                            DateTime startTime = DateTime.Parse(this._recBgnGdsRow.ApplyStaDate);   // �J�n��
                            long listPrice = 0;                                                   // �艿
                            long unitPrice = 0;                                                   // ����
                            bool uPricDiv = false;  // ADD 2015/03/26 Y.Wakita

                            // ��蒼��
                            // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                            //this._calculator.GetUnitPrice(customerCode
                            //                           , this._swGoodsUnitData
                            //                           , startTime
                            //                           , dataRow.MngSectionCode
                            //                           , out mkrSuggestRtPric
                            //                           , out listPrice
                            //                           , out unitPrice);
                            this._calculator.GetUnitPrice(customerCode
                                                       , this._swGoodsUnitData
                                                       , startTime
                                                       , dataRow.MngSectionCode
                                                       , this._swMkrSuggestRtPricList
                                                       , this._swMkrSuggestRtPricUList
                                                       , out uPricDiv   // ADD 2015/03/26 Y.Wakita
                                                       , out mkrSuggestRtPric
                                                       , out listPrice
                                                       , out unitPrice);
                            // --- UPD 2015/03/25 Y.Wakita ----------<<<<<

                            //this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Value = (long)listPrice;     // �艿    // DEL 2015/03/11 Y.Wakita
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Value = (long)unitPrice;     // ����
                        }
                    }
                }
            }

            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
        }

        /// <summary>
        /// �O���b�h�Z��KeyPress�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Z��KeyPress�����C�x���g</br>
        /// <br>Programmer  : �e�c ���V</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (!cell.IsInEditMode) return;

            //----------------------------------------------
            // ActiveCell�����Ӑ�̏ꍇ
            //----------------------------------------------
            else if (cell.Column.Key == this._recBgnCustDataTable.CustomerCodeColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(8, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCell�����������i�O���[�v�R�[�h�̏ꍇ
            //----------------------------------------------
            else if (cell.Column.Key == this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCell���������̏ꍇ
            //----------------------------------------------
            else if (cell.Column.Key == this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        #endregion

        #endregion

        /// <summary>
        /// ���������i�ʐݒ�}�X�^�[�����׍s
        /// </summary>
        /// <param name="row">���׍s</param>
        /// <param name="RecBgnGds">���������i�ݒ�}�X�^</param>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�[�����׍s</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void CopyToRecBgnCustFromDetailRow(RecBgnGdsDataSet.RecBgnCustRow row, ref RecBgnCust recBgnCust)
        {
            if (recBgnCust == null)
            {
                recBgnCust = new RecBgnCust();
            }
            recBgnCust.InqOriginalEpCd = row.InqOriginalEpCd;      // �⍇������ƃR�[�h
            recBgnCust.InqOriginalSecCd = row.InqOriginalSecCd;    // �⍇�������_�R�[�h
            recBgnCust.InqOtherEpCd = row.InqOtherEpCd;            // �⍇�����ƃR�[�h
            recBgnCust.InqOtherSecCd = row.InqOtherSecCd.ToString().PadLeft(2, '0');   // �⍇���拒�_�R�[�h
            if (row.CustomerCode.Trim() == string.Empty)            // ���Ӑ�R�[�h
            {
                recBgnCust.CustomerCode = 0;
            }
            else
            {
                recBgnCust.CustomerCode = Convert.ToInt32(row.CustomerCode);
            }
            recBgnCust.MngSectionCode = row.MngSectionCode;         // �Ǘ����_�R�[�h
            recBgnCust.GoodsNo = row.GoodsNo;                       // ���i�ԍ�
            recBgnCust.GoodsMakerCd = row.GoodsMakerCode;           // ���i���[�J�[�R�[�h
            recBgnCust.GoodsApplyStaDate = row.GoodsApplyStaDate;   // ���i�K�p�J�n��
            recBgnCust.MkrSuggestRtPric = row.MkrSuggestRtPric;     // Ұ����]�������i
            recBgnCust.ListPrice = row.ListPrice;                   // �艿
            recBgnCust.UnitCalcRate = row.UnitCalcRate;             // �P���Z�o�|��
            recBgnCust.UnitPrice = row.UnitPrice;                   // �P��
            recBgnCust.BrgnGoodsGrpCode = row.BrgnGoodsGrpCode;     // ���������i�O���[�v�R�[�h
            int startDate = 0;                                      // ���J�J�n��
            if (!row.ApplyStaDate.Replace("/", "").Equals(string.Empty)) startDate = int.Parse(row.ApplyStaDate.Replace("/", ""));
            recBgnCust.ApplyStaDate = startDate;
            int endDate = 0;                                        // ���J�I����
            if (!row.ApplyEndDate.Replace("/", "").Equals(string.Empty)) endDate = int.Parse(row.ApplyEndDate.Replace("/", ""));
            recBgnCust.ApplyEndDate = endDate;
            recBgnCust.RowIndex = row.RowNo;
        }
        
        /// <summary>
        /// ���t�`�F�b�N����
        /// </summary>
        /// <param name="sChkDate"></param>
        /// <returns></returns>
        private bool CheckDateValue(ref string sChkDate)
        {
            string cellValue = sChkDate;
            string nowString = DateTime.Now.Date.ToString("yyyyMMdd");
            int n = sChkDate.Length - sChkDate.Replace("/", "").Length;
            string format = "yyyy/M/d";

            // �X���b�V���Ȃ�
            switch (n)
            {
                case 0:
                    switch (sChkDate.Length)
                    {
                        case 1: // ���̂ݓ���
                            cellValue = nowString.Substring(0, 6) + "0" + cellValue;
                            cellValue = cellValue.Insert(4, "/");
                            cellValue = cellValue.Insert(7, "/");
                            break;
                        case 3: // ���E���̂ݓ���
                            cellValue = nowString.Substring(0, 4) + "0" + cellValue;
                            cellValue = cellValue.Insert(4, "/");
                            cellValue = cellValue.Insert(7, "/");
                            break;
                        case 0:
                        case 5:
                        case 7:
                            break;
                        default:
                            cellValue = nowString.Substring(0, 8 - cellValue.Length) + cellValue;
                            cellValue = cellValue.Insert(4, "/");
                            cellValue = cellValue.Insert(7, "/");
                            break;
                    }
                    break;
                case 1:
                    cellValue = nowString.Substring(0, 4) + cellValue;
                    cellValue = cellValue.Insert(4, "/");
                    break;

                case 2:
                    if (cellValue.Split('/')[0].Length < 3) format = "y/M/d";
                    break;
            }

            DateTime parseDate;
            if (!DateTime.TryParseExact(cellValue, format, null, DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite | DateTimeStyles.AllowInnerWhite, out parseDate))
            {
                return false;
            }
            sChkDate = parseDate.ToString("yyyy/MM/dd");
            return true;
        }

        #region Grid
        
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ��ʏ������������܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        internal void Init(bool settingGrid)
        {
            
            // ���׃f�[�^�e�[�u����������
            this.AcceptChangesRecBgnCustDataRow();

            // �O���b�h�w�i�F������
            AllCellNoEdit(0);

            // �O���b�h�s�����ݒ�
            this.AddNewRow();

            // �O���b�h���͕s��w�i�F�ݒ�
            this.SetReadOnlyColumnSettings();

            if (settingGrid)
            {
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recBgnCustDataTable.UpdateTimeColumn.ColumnName].Hidden = true;
            }

        }

        /// <summary>
        /// �ʐݒ�f�[�^���R�~�b�g����
        /// </summary>
        /// <remarks>RowState�����ׂ�Unchanged�ɂ���</remarks>
        private void AcceptChangesRecBgnCustDataRow()
        {
            int rowNo = 0;
            foreach (RecBgnGdsDataSet.RecBgnCustRow row in this._recBgnCustDataTable)
            {
                rowNo++;
                row.RowNo = rowNo;
            }
        }

        /// <summary>
        /// �ŏI���͍s���폜����
        /// </summary>
        /// <remarks></remarks>
        public RecBgnGdsDataSet.RecBgnCustDataTable GetResultRecBgnCust()
        {

            DataRow[] rows = this._recBgnCustDataTable.Select("RowDevelopFlg = 0");
            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].RowState != DataRowState.Deleted)
                {
                    rows[i].Delete();
                }
            }
            this._recBgnCustDataTable.AcceptChanges();

            return this._recBgnCustDataTable;

        }

        /// <summary>
        /// �O���b�h���ו�����������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���ו��������������܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // �S�Ă̗�����������\���ɂ���B
                col.Hidden = true;
                col.Header.Fixed = false;

                // �uNo��v�ȊO�̑S�ẴZ����DiabledColor��ݒ肷��B
                if (col.Key != this._recBgnCustDataTable.RowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = ct_DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = ct_DISABLE_FONT_COLOR;
                }
            }

            #region ���\�����ݒ�
            editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].Width = 40;		        // ��
            editBand.Columns[this._recBgnCustDataTable.UpdateTimeColumn.ColumnName].Width = 80;		    // �폜��
            //------------------------------------------------------------------------------------------------------
            editBand.Columns[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Width = 65;		// ���Ӑ�
            editBand.Columns[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].Width = 100;		// ���Ӑ於
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Width = 65;	// ���������i�O���[�v�R�[�h
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].Width = 100;	// ���������i�O���[�v��
            editBand.Columns[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Width = 50;		// �\���敪
            editBand.Columns[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].Width = 75;		// ���J�J�n��
            editBand.Columns[this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName].Width = 75;		// ���J�I����
            editBand.Columns[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].Width = 130;  // Ұ����]�������i
            editBand.Columns[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Width = 130;			// �W�����i
            editBand.Columns[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Width = 50;		// �P���Z�o�|��
            editBand.Columns[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Width = 130;			// ���P��
            #endregion

            #region ���Œ��ݒ�
            //editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].Header.Fixed = true;		            // ��
            //editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;		            // ��
            editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].Header.Fixed = false;	// ��
            #endregion

            #region ��CellAppearance�ݒ�
            editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;               // ��
            editBand.Columns[this._recBgnCustDataTable.UpdateTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// �폜��
            editBand.Columns[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		// ���Ӑ�
            editBand.Columns[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;		    // ���Ӗ�
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	// ���������i�O���[�v�R�[�h
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;		// ���������i�O���[�v�R�[�h��
            editBand.Columns[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;		// �\���敪
            editBand.Columns[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// ���J�J�n��
            editBand.Columns[this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// ���J�I����
            editBand.Columns[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;    // Ұ����]�������i
            editBand.Columns[this._recBgnCustDataTable.ListPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;           // �W�����i
            editBand.Columns[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		// ������
            editBand.Columns[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;			// ���P��

            editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            //editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            //editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            //editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            #endregion

            #region �����͋��ݒ�
            //editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;		        // ��
            editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].CellActivation = Activation.NoEdit;
            editBand.Columns[this._recBgnCustDataTable.UpdateTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;			// �폜��
            editBand.Columns[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 		// ���Ӑ�
            editBand.Columns[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;         // ���Ӑ於
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 	// ���������i�O���[�v�R�[�h
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;     // ���������i�O���[�v��
            editBand.Columns[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;    // �\���敪
            editBand.Columns[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; 		// ���J�J�n��
            editBand.Columns[this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; 		// ���J�I����
            editBand.Columns[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;     // Ұ����]�������i
            editBand.Columns[this._recBgnCustDataTable.ListPriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;            // �W�����i
            editBand.Columns[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 		// ������
            editBand.Columns[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 		// ���P��
            #endregion

            #region ��Style�ݒ�
            editBand.Columns[this._recBgnCustDataTable.UpdateTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;        // �폜��
            editBand.Columns[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // ���Ӑ�
            editBand.Columns[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // ���Ӑ於
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;  // ���������i�O���[�v�R�[�h
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;  // ���������i�O���[�v��
            editBand.Columns[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;// �\���敪
            editBand.Columns[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // ���J�J�n��
            editBand.Columns[this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // ���J�I����
            editBand.Columns[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;  // Ұ����]�������i
            editBand.Columns[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;         // �W�����i
            editBand.Columns[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // �P���Z�o�|��
            editBand.Columns[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // ������
            editBand.Columns[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;         // ���P��
            #endregion

            #region ���t�H�[�}�b�g�ݒ�
            string decimalFormat = "#,##0;-#,##0;''";
            string doubleFormat = "##0.#0;-##0.#0;''";
            string codeFormat2 = "#0;-#0;''";
            string codeFormat3 = "#00000000;-#00000000;''";

            editBand.Columns[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Format = codeFormat3;		    // ���Ӑ�
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Format = codeFormat2;		// ���������i�O���[�v�R�[�h
            editBand.Columns[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].Format = decimalFormat;	// Ұ����]�������i
            editBand.Columns[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Format = decimalFormat;			// �W�����i
            editBand.Columns[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Format = doubleFormat;		// ������
            editBand.Columns[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Format = decimalFormat;			// ���P��
            #endregion

            #region ��MaxLength�ݒ�
            editBand.Columns[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].MaxLength = 8;		        // ���Ӑ�
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].MaxLength = 4;		    // ���������i�O���[�v�R�[�h
            editBand.Columns[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].MaxLength = 10;		        // ���J�J�n��
            editBand.Columns[this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName].MaxLength = 10;               // ���J�I����
            editBand.Columns[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].MaxLength = 6;                // ������
            // --- UPD 2015/03/09 Y.Wakita Redmine#351 ---------->>>>>
            //editBand.Columns[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].MaxLength = 17;			        // ���P�� 
            editBand.Columns[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].MaxLength = 7;			        // ���P�� 
            // --- UPD 2015/03/09 Y.Wakita Redmine#351 ----------<<<<<
            #endregion

            #region ���O���b�h��\����\���ݒ菈��
            editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].Hidden = false;		        // ��
            editBand.Columns[this._recBgnCustDataTable.UpdateTimeColumn.ColumnName].Hidden = true;		    // �폜��
            editBand.Columns[this._recBgnCustDataTable.GoodsMakerCodeColumn.ColumnName].Hidden = true;		// Ұ��
            editBand.Columns[this._recBgnCustDataTable.GoodsNoColumn.ColumnName].Hidden = true;	            // �i��
            editBand.Columns[this._recBgnCustDataTable.GoodsApplyStaDateColumn.ColumnName].Hidden = true;	// ���i�K�p�J�n��
            editBand.Columns[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Hidden = false;		// ���Ӑ�
            editBand.Columns[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].Hidden = false;		// ���Ӑ於
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Hidden = false;	// ���������i�O���[�v�R�[�h
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].Hidden = false;	// ���������i�O���[�v��
            editBand.Columns[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Hidden = false;		// �\���敪
            editBand.Columns[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].Hidden = false;		// ���J�J�n��
            editBand.Columns[this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName].Hidden = false;		// ���J�I����
            editBand.Columns[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].Hidden = false;   // Ұ����]�������i
            editBand.Columns[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Hidden = false;			// �W�����i
            editBand.Columns[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Hidden = false;       // �P���Z�o�|��
            editBand.Columns[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Hidden = false;			// ���P��
            #endregion

            #region ���O���b�h��\�[�g�ݒ菈��
            editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].SortIndicator = SortIndicator.Disabled;              // ��
            editBand.Columns[this._recBgnCustDataTable.UpdateTimeColumn.ColumnName].SortIndicator = SortIndicator.Disabled;         // �폜��
            editBand.Columns[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// ���Ӑ�
            editBand.Columns[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// ���Ӑ於
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].SortIndicator = SortIndicator.Disabled;	// ���������i�O���[�v�R�[�h
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].SortIndicator = SortIndicator.Disabled;	// ���������i�O���[�v��
            editBand.Columns[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// �\���敪
            editBand.Columns[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// ���J�J�n��
            editBand.Columns[this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// ���J�I����
            editBand.Columns[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].SortIndicator = SortIndicator.Disabled;   // Ұ����]�������i
            editBand.Columns[this._recBgnCustDataTable.ListPriceColumn.ColumnName].SortIndicator = SortIndicator.Disabled;			// �W�����i
            editBand.Columns[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// ������
            editBand.Columns[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].SortIndicator = SortIndicator.Disabled;			// ���P��
            #endregion

            try
            {
                this.uGrid_Details.BeginUpdate();
                ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

                # region [�Z�������ݒ�]
                List<string> colNameList = new List<string>(new string[] 
                                            { 
                                                this._recBgnCustDataTable.UpdateTimeColumn.ColumnName,
                                                this._recBgnCustDataTable.CustomerCodeColumn.ColumnName,
                                                this._recBgnCustDataTable.CustomerNameColumn.ColumnName,
                                                this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName,
                                                this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName,
                                                this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName,
                                                this._recBgnCustDataTable.ListPriceColumn.ColumnName,
                                            });
                Infragistics.Win.Appearance margedCellAppearance = new Infragistics.Win.Appearance();

                for (int index = 0; index < colNameList.Count; index++)
                {
                    string colName = colNameList[index];

                    // CellAppearance�������I�ɓ��ꂷ��i�s���͏����j
                    if (!columns[colName].Key.Trim().Equals(this._recBgnCustDataTable.RowNoColumn.ColumnName.Trim()))
                    {
                        columns[colName].MergedCellAppearance = margedCellAppearance;
                        columns[colName].CellAppearance.TextVAlign = VAlign.Top;
                    }
                    // �Z�������ݒ�
                    columns[colName].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
                    columns[colName].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
                    columns[colName].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
                }

                // �Z�������ݒ�ڍׁi�e��𔻒�Ɋ܂߂�j
                // ���Ӑ�
                columns[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnCustDataTable.CustomerCodeColumn.ColumnName);

                // ���Ӑ於�F���Ӑ� | ���Ӑ於
                columns[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnCustDataTable.CustomerCodeColumn.ColumnName,
                                                    this._recBgnCustDataTable.CustomerNameColumn.ColumnName);

                // ��ٰ��  �F���Ӑ� | ���Ӑ於 | ��ٰ��
                columns[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnCustDataTable.CustomerCodeColumn.ColumnName,
                                                    this._recBgnCustDataTable.CustomerNameColumn.ColumnName,
                                                    this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName);

                // ��ٰ�ߖ��F���Ӑ於 | ��ٰ�� | ��ٰ�ߖ�
                columns[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnCustDataTable.CustomerCodeColumn.ColumnName,
                                                    this._recBgnCustDataTable.CustomerNameColumn.ColumnName,
                                                    this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName,
                                                    this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName);

                // Ұ�����i�F���Ӑ� | ���Ӑ於 | Ұ�����i
                columns[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnCustDataTable.CustomerCodeColumn.ColumnName,
                                                    this._recBgnCustDataTable.CustomerNameColumn.ColumnName,
                                                    this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName);

                // �W�����i�F���Ӑ� | ���Ӑ於 | �W�����i
                columns[this._recBgnCustDataTable.ListPriceColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnCustDataTable.CustomerCodeColumn.ColumnName,
                                                    this._recBgnCustDataTable.CustomerNameColumn.ColumnName,
                                                    this._recBgnCustDataTable.ListPriceColumn.ColumnName);

                # endregion
            }
            finally
            {
                this.uGrid_Details.EndUpdate();
            }
        }

        /// <summary>
        /// ���������i�ʐݒ�}�X�^ DataTable�ɐV�K�s��ǉ�����
        /// </summary>
        private void AddNewRow()
        {

            this._recBgnCustDataTable.BeginLoadData();
            RecBgnGdsDataSet.RecBgnCustRow newRow = this._recBgnCustDataTable.NewRecBgnCustRow();

            // ����l�ݒ�
            newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
            newRow.FilterGuid = Guid.Empty;
            newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");

            newRow.InqOtherEpCd = this._recBgnGdsRow.InqOtherEpCd;              // �⍇�����ƃR�[�h
            newRow.InqOtherSecCd = this._recBgnGdsRow.InqOtherSecCd;            // �⍇���拒�_�R�[�h
            newRow.GoodsNo = this._recBgnGdsRow.GoodsNo;                        // ���i�ԍ�
            newRow.GoodsMakerCode = this._recBgnGdsRow.GoodsMakerCode;          // ���i���[�J�[�R�[�h
            newRow.GoodsApplyStaDate = (int.Parse(this._swGoodsUnitData.OfferDate.ToString("yyyyMMdd")));   // ���i�K�p�J�n��
            newRow.DisplayDivCode = 1;                                                                   // �\���敪
            newRow.UnitCalcRate = 0;
            newRow.UnitPrice = 0;
            newRow.MkrSuggestRtPric = 0;

            // �s�ǉ�
            this._recBgnCustDataTable.AddRecBgnCustRow(newRow);
            this._recBgnCustDataTable.EndLoadData();

            // �w�i�F
            SetReadOnlyColumnSettings();

            uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
            uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Activate();
            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
            this._recBgnCustDataTable.AcceptChanges();

        }

        /// <summary>
        /// �O���b�h�J�������̓ǂݍ���
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        private void LoadGridColumnsSetting(ref Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, List<ColumnInfo> settingList)
        {
            if (settingList == null || settingList.Count == 0) return;

            targetGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            foreach (ColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Width = columnInfo.Width;
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// �O���b�h��s���͐F�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �O���b�h��s���͐F�ݒ肵�܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        internal void SetReadOnlyColumnSettings()
        {
            // ���ז��̏ꍇ�͉������Ȃ�
            if (this.uGrid_Details == null || this.uGrid_Details.Rows.Count < 1) return;

            // ���Ӑ於�E���������i�O���[�v���E���J�J�n���E���J�I�����EҰ����]�������i�E�W�����i�ɐݒ�
            UltraGridRow row = this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count-1];
            foreach (UltraGridCell cell in row.Cells)
            {
                if (cell.Column.Key == this._recBgnCustDataTable.CustomerNameColumn.ColumnName
                 || cell.Column.Key == this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName
                 || cell.Column.Key == this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName
                 || cell.Column.Key == this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName
                 || cell.Column.Key == this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName
                 || cell.Column.Key == this._recBgnCustDataTable.ListPriceColumn.ColumnName)
                {
                    cell.Activation = Activation.NoEdit;
                    cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                }
            }
        }


        /// <summary>
        /// �O���b�h �S���ړ��͕s�\�Z���ݒ菈��
        /// </summary>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void AllCellNoEdit(int mode)
        {
            foreach (UltraGridRow row in this.uGrid_Details.Rows)
            {
                if (mode == 1)
                {
                    if ((Guid)row.Cells[this._recBgnCustDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                    {
                        continue;
                    }
                }
                foreach (UltraGridCell cell in row.Cells)
                {
                    if (cell.Column.Key != this._recBgnCustDataTable.RowNoColumn.ColumnName)
                    {
                        // �s�ԍ��ȊO��񊈐�
                        cell.Appearance.BackColor = ct_DISABLE_COLOR;
                        cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                        cell.Activation = Activation.NoEdit;

                        // �\���敪�͏�Ɋ���
                        if (cell.Column.Key == this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName)
                        {
                            cell.Activation = Activation.AllowEdit;
                            cell.Appearance.BackColor = Color.Empty;
                            cell.Appearance.BackColor2 = Color.Empty;
                            cell.Appearance.BackColorDisabled = Color.Empty;
                            cell.Appearance.BackColorDisabled2 = Color.Empty;
                        }
                        // ���������i�O���[�v�R�[�h�E�������E���P���͕\���敪���u���J����v�ꍇ�Ɋ���
                        else if (cell.Column.Key == this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName
                            || cell.Column.Key == this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName
                            || cell.Column.Key == this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName
                            || cell.Column.Key == this._recBgnCustDataTable.UnitPriceColumn.ColumnName)
                        {
                            if (row.Cells[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Text != "0")
                            {
                                cell.Activation = Activation.AllowEdit;
                                cell.Appearance.BackColor = Color.Empty;
                                cell.Appearance.BackColor2 = Color.Empty;
                                cell.Appearance.BackColorDisabled = Color.Empty;
                                cell.Appearance.BackColorDisabled2 = Color.Empty;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �O���b�h Next�t�H�[�J�X�擾����
        /// </summary>
        /// <param name="mode">���[�h(0:Tab;1;Shift + Tab)</param>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <param name="columnKey">columnKey</param>
        /// <returns>columnIndex</returns>
        /// <remarks>
        /// <br>Note        : �O���b�hNext�t�H�[�J�X�擾���s���܂��B</br>
        /// <br>Programmer  : �e�c ���V</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private int GetNextColumnIndexByTab(int mode, int rowIndex, string columnKey)
        {
            int columnIndex = -1;
            switch (mode)
            {
                case 0:
                    #region Tab

                    // ���Ӑ�
                    if (columnKey == this._recBgnCustDataTable.CustomerCodeColumn.ColumnName)
                    {
                        // ���Ӑ於
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].Column.Index;
                    }
                    // ���Ӑ於
                    else if (columnKey == this._recBgnCustDataTable.CustomerNameColumn.ColumnName)
                    {
                        // ���J�J�n��
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].Column.Index;
                    }
                    // ���J�J�n��
                    else if (columnKey == this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName)
                    {
                        // ���J�I����
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName].Column.Index;
                    }
                    // ���J�I����
                    else if (columnKey == this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName)
                    {
                        // ���J�敪
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Column.Index;
                    }
                    // ���J�敪
                    else if (columnKey == this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName)
                    {
                        // ���������i�O���[�v�R�[�h
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Column.Index;
                    }
                    // ���������i�O���[�v�R�[�h
                    else if (columnKey == this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName)
                    {
                        // ���������i�O���[�v��
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].Column.Index;
                    }
                    // ���������i�O���[�v��
                    else if (columnKey == this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName)
                    {
                        // Ұ����]�������i
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].Column.Index;
                    }
                    // Ұ����]�������i
                    else if (columnKey == this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName)
                    {
                        // �W�����i
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Column.Index;
                    }
                    // �W�����i
                    else if (columnKey == this._recBgnCustDataTable.ListPriceColumn.ColumnName)
                    {
                        // ������
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Column.Index;
                    }
                    // ������
                    else if (columnKey == this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName)
                    {
                        // �P���Z�o�|��
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Column.Index;
                    }
                    // �P���Z�o�|��
                    else if (columnKey == this._recBgnCustDataTable.UnitPriceColumn.ColumnName)
                    {
                        columnIndex = -1;
                    }
                    
                    
                    break;
                    #endregion Tab
                case 1:
                    #region Shift + Tab

                    // ���Ӑ�
                    if (columnKey == this._recBgnCustDataTable.CustomerCodeColumn.ColumnName)
                    {
                        columnIndex = -1;
                    }
                    // ���Ӑ於
                    else if (columnKey == this._recBgnCustDataTable.CustomerNameColumn.ColumnName)
                    {
                        // ���Ӑ�R�[�h
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Column.Index;
                    }
                    // ���J�J�n��
                    else if (columnKey == this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName)
                    {
                        // ���Ӗ�
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].Column.Index;
                    }
                    // ���J�I����
                    else if (columnKey == this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName)
                    {
                        // ���J�J�n��
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].Column.Index;
                    }
                    // ���J�敪
                    else if (columnKey == this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName)
                    {
                        // ���J�I����
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName].Column.Index;
                    }
                    // ���������i�O���[�v�R�[�h
                    else if (columnKey == this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName)
                    {
                        // ���J�敪
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Column.Index;
                    }
                    // ���������i�O���[�v��
                    else if (columnKey == this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName)
                    {
                        // ���������i�O���[�v�R�[�h
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Column.Index;
                    }
                    // Ұ����]�������i
                    else if (columnKey == this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName)
                    {
                        // ���������i�O���[�v��
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Column.Index;
                    }
                    // �W�����i
                    else if (columnKey == this._recBgnCustDataTable.ListPriceColumn.ColumnName)
                    {
                        // Ұ����]�������i
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].Column.Index;
                    }
                    // �P���Z�o�|��
                    else if (columnKey == this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName)
                    {
                        // �W�����i
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Column.Index;
                    }
                    // �P��
                    else if (columnKey == this._recBgnCustDataTable.UnitPriceColumn.ColumnName)
                    {
                        // �P���Z�o�|��
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Column.Index;
                    }


                    break;
                    #endregion Shift + Tab
            }

            return columnIndex;
        }
        
        /// <summary>
        /// �O���b�h �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �����͉\�Z���ړ��������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool isActiveCellStop)
        {
            bool isMoved = false;   // �ړ����
            bool isResult = false;  // PerformActionResult

            try
            {
                int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;

                // �X�V�J�n�i�`��X�g�b�v�j
                this.uGrid_Details.BeginUpdate();

                // ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ�
                if ((isActiveCellStop) && (this.uGrid_Details.ActiveCell != null))
                {
                    if ((!this.uGrid_Details.ActiveCell.Column.Hidden) &&
                        (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        isMoved = true;
                    }
                }

                // Next�Ɉړ�������
                while (!isMoved)
                {
                    if (this.uGrid_Details.ActiveRow.Index == this._recBgnCustDataTable.Count - 1)
                    {
                        
                        if (this.uGrid_Details.ActiveCell == null) break;

                        // ���Ӑ�
                        if (this._recBgnCustDataTable.CustomerCodeColumn.ColumnName.Equals(this.uGrid_Details.ActiveCell.Column.Key))
                        {
                            // ���דW�J����
                            if (this.BgnDataDeployment() == true)
                            {
                                this.AddNewRow();
                                isMoved = true;

                                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                break;
                            }
                            return true;
                        }
                    }

                    isResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                    if (isResult)
                    {
                        if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            isMoved = true;
                        }
                        else
                        {
                            isMoved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                // �ړ���̃Z���ݒ�
                if (isMoved)
                {
                    // Active�Z����ҏW���[�h�ɂ���
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                // �X�V�I���i�`��ĊJ�j
                this.uGrid_Details.EndUpdate();
            }

            return isResult;
        }

        /// <summary>
        /// �O���b�h �O���͉\�Z���ړ�����
        /// </summary>
        /// <param name="isActiveCellStop">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �O���͉\�Z���ړ��������s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private bool MovePreAllowEditCell(bool isActiveCellStop)
        {
            bool isMoved = false;   // �ړ����
            bool isResult = false;  // PerformActionResult

            try
            {
                // �X�V�J�n�i�`��X�g�b�v�j
                this.uGrid_Details.BeginUpdate();

                // ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ�
                if ((isActiveCellStop) && (this.uGrid_Details.ActiveCell != null))
                {
                    if ((!this.uGrid_Details.ActiveCell.Column.Hidden) &&
                        (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        isMoved = true;
                    }
                }

                // Next�Ɉړ�������
                while (!isMoved)
                {
                    isResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

                    if (isResult)
                    {
                        if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            isMoved = true;
                        }
                        else
                        {
                            isMoved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                // �ړ���̃Z���ݒ�
                if (isMoved)
                {
                    // Active�Z����ҏW���[�h�ɂ���
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                // �X�V�I���i�`��ĊJ�j
                this.uGrid_Details.EndUpdate();
            }

            return isResult;
        }
        #endregion

        #region �K�C�h


        /// <summary>
        /// ���������i�O���[�v�K�C�h�N��
        /// </summary>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <remarks>
        /// <br>Note	   : ���������i�O���[�v�K�C�h�N��</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        internal void SetGdsGrpCodeGuide(int rowIndex, int customerCode)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ���������i�O���[�v�K�C�h
                PMREC09030UA recBgnGrpSearchForm = new PMREC09030UA(PMREC09030UA.GUIDETYPE_NORMAL, customerCode, new ArrayList(this._recBgnGdsAcs.CustomerSearchRetList));
                recBgnGrpSearchForm.RecBgnGrpSelect += new PMREC09030UA.RecBgnGrpSelectEventHandler(this.RecBgnGrpSearchForm_RecBgnGrpSelect);
                recBgnGrpSearchForm.ShowDialog(this);

                if (this._recBgnGrpRet != null)
                {
                    // ���������i�O���[�v
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = this._recBgnGrpRet.BrgnGoodsGrpCode.ToString().PadLeft(4, '0');

                    MoveNextAllowEditCell(false);
                    this._customerSearchRet = null;
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���������i�O���[�v�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���������i�O���[�v�����߂�l�N���X</param>
        /// <remarks>
        /// <br>Note        : ���������i�O���[�v�I�����ɔ������܂��B</br>
        /// <br>Programmer	: �e�c ���V</br>
        /// <br>Date		: 2015/02/20</br>
        /// </remarks>
        private void RecBgnGrpSearchForm_RecBgnGrpSelect(object sender, RecBgnGrpRet recBgnGrpRet)
        {
            if (recBgnGrpRet == null)
            {
                this._recBgnGrpRet = null;
                return;
            }
            this._recBgnGrpRet = recBgnGrpRet;
        }
        
        /// <summary>
        /// ���Ӑ�R�[�h�K�C�h�N��
        /// </summary>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <remarks>
        /// <br>Note	   : ���Ӑ�R�[�h�K�C�h�N���B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        internal void SetCustomerCodeGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // ���Ӑ�K�C�h
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                if (this._customerSearchRet != null)
                {
                    // ���Ӑ�R�[�h
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Value = this._customerSearchRet.CustomerCode.ToString().PadLeft(8, '0');

                    MoveNextAllowEditCell(false);
                    this._customerSearchRet = null;
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <remarks>
        /// <br>Note        : ���Ӑ�I�����ɔ������܂��B</br>
        /// <br>Programmer	: �e�c ���V</br>
        /// <br>Date		: 2015/02/20</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._customerSearchRet = null;
                return;
            }
            this._customerSearchRet = customerSearchRet;
        }

        #endregion

        #region ���דW�J����

        /// <summary>
        /// ���דW�J����
        /// </summary>
        private bool BgnDataDeployment()
        {
            string sectionCode = string.Empty;
            string errorMsg = string.Empty;
            string date = string.Empty;

            int customerCode = 0;
            int rowIndex = this.uGrid_Details.ActiveRow.Index;
            int rowNo = this._recBgnCustDataTable[rowIndex].RowNo;

            int status = 0;
            bool chkStatus = false;

            // ���_
            sectionCode = this._recBgnGdsRow.InqOtherSecCd;

            // ���Ӑ�
            if (this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Value.ToString() != string.Empty)
                customerCode = int.Parse(this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Value.ToString().Trim());

            // �e���|�������N���A
            this._recBgnCustTmpDataTable.Clear();

            // ���_�E���Ӑ�I���f�[�^�e�[�u���̐ݒ� // ���������i�O���[�v�R�[�h
            this.SetSecCusSetDataTable(customerCode, sectionCode);

            switch (_secCusSetDataTable.Count)
            {
                case 0:
                    // 0���̏ꍇ �G���[
                    TMsgDisp.Show(this
                                 , emErrorLevel.ERR_LEVEL_EXCLAMATION
                                 , this.Name
                                 , "�A�g���Ă��链�Ӑ�ł͂���܂���B"
                                 , 0
                                 , MessageBoxButtons.OK);

                    return false;
                //break;
                case 1:
                    // 1���̏ꍇ �I����ʕ\������
                    break;
                default:
                    // 2���ȏ�̏ꍇ �I����ʕ\��

                    PMREC09021UC salesSlipNumInputDialog = new PMREC09021UC(this._secCusSetDataTable);

                    // -- �q��ʑI���s�f�[�^�̂ݎc���Ă��܂��B
                    this._secCusSetDataTable = salesSlipNumInputDialog.SecCusSetDataTable;
                    DialogResult dialogResult = salesSlipNumInputDialog.ShowDialog();

                    salesSlipNumInputDialog.Close();

                    // --- ADD 2015/04/08 Y.Wakita Redmine#3435 ---------->>>>>
                    if (dialogResult == DialogResult.Cancel) return false;
                    // --- ADD 2015/04/08 Y.Wakita Redmine#3435 ----------<<<<<

                    break;
            }

            DateTime startDate = DateTime.Parse(this._recBgnGdsRow.ApplyStaDate);   // ���J�J�n��
            DateTime endDate = DateTime.Parse(this._recBgnGdsRow.ApplyEndDate);     // ���J�I����

            List<RecBgnGdsAcs.StartEndDate> retOpenStartEndDateList;
            foreach (RecBgnGdsDataSet.SecCusSetRow row in this._secCusSetDataTable.Rows)
            {
                if (this._recBgnGdsRow.InqOtherSecCd.Trim() == "00")
                    row.SectionCode = this._recBgnGdsRow.InqOtherSecCd.Trim();

                // ���Ӑ�
                customerCode = int.Parse(row.CustomerCode);

                // �Ǘ����_���_
                sectionCode = row.MngSectionCode;

                // �͈͎擾
                // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                //status = RecBgnGdsAcs.GetOpenStartEndDateList(startDate, endDate, customerCode, sectionCode, this._swGoodsUnitData, out retOpenStartEndDateList);
                status = RecBgnGdsAcs.GetOpenStartEndDateList(startDate, endDate, customerCode, sectionCode, this._swGoodsUnitData, this._swMkrSuggestRtPricList, this._swMkrSuggestRtPricUList, out retOpenStartEndDateList);
                // --- UPD 2015/03/25 Y.Wakita ----------<<<<<

                // �e���|�������쐬
                // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                //this.AddToRecBgnCustTmpFromRecBgnCust(this._recBgnCustDataTable[rowIndex], row, retOpenStartEndDateList, _swGoodsUnitData);
                this.AddToRecBgnCustTmpFromRecBgnCust(this._recBgnCustDataTable[rowIndex], row, retOpenStartEndDateList, _swGoodsUnitData, this._swMkrSuggestRtPricList, this._swMkrSuggestRtPricUList);
                // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
            }

            // ��ʔ��f�`�F�b�N
            chkStatus = this.AddToRecBgnCustCheck(rowNo, out errorMsg);
            if (errorMsg != string.Empty)
            {
                TMsgDisp.Show(
                     this,
                     emErrorLevel.ERR_LEVEL_EXCLAMATION,
                     this.Name,
                     "����̐ݒ肪���ɓo�^����Ă��܂��B" + "\r\n" +
                     errorMsg,
                     0,
                     MessageBoxButtons.OK);
            }

            if (chkStatus == true)
            {
                // �e���|��������ʂɔ��f
                this.AddToRecBgnCustFromRecBgnCustTmp(this._recBgnCustTmpDataTable, rowIndex, rowNo);

                // �S���ڎg�p�s��
                this.AllCellNoEdit(0);
            }
            this._recBgnCustTmpDataTable.Clear();

            return chkStatus;
        }

        /// <summary>
        /// ���_���Ӑ��ʕ\���p�f�[�^�e�[�u���̐ݒ�
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        private void SetSecCusSetDataTable(int customerCode, string sectionCode)
        {

            List<ScmEpScCnt> scmEpScCntList = new List<ScmEpScCnt>();
            _secCusSetDataTable.Clear();

            // SCM��ƘA���f�[�^�̎擾 ���������F���O�C����ƃR�[�h
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            if (this._recBgnGdsAcs.ScmEpScCntList.Count == 0)
            {
                status = this.SearchCnectOriginalEpFromSc(ref scmEpScCntList);
            }
            else
            {
                scmEpScCntList = this._recBgnGdsAcs.ScmEpScCntList;
            }

            if (status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                foreach (ScmEpScCnt wk in scmEpScCntList)
                {
                    #region SCM��ƘA���f�[�^�̍i����

                    if (!wk.LogicalDeleteCode.Equals(0)) continue;                              // �_���폜�F�L���ȊO
                    if (wk.DiscDivCd.Equals(1)) continue;                                       // �A������
                    if (wk.ScmCommMethod.Equals(0) && wk.PccUoeCommMethod.Equals(0)) continue;  // �ʐM����������

                    if (!this._secInfoSetList.Exists(delegate(SecInfoSet sec)
                                                        {
                                                            return (sec.SectionCode.Trim().Equals(wk.CnectOtherSecCd.Trim()));
                                                        }
                                                        )
                        ) continue; // ���_�}�X�^�ɑ��݂��Ȃ�


                    // �S�Ђł͖����ꍇ�A���_�ōi����
                    if (!sectionCode.Equals(ALL_SECTION_CODE))
                    {
                        if (!sectionCode.Equals(wk.CnectOtherSecCd.Trim())) continue;
                    }

                    // ���Ӑ悪�ݒ�ς݂ł���΁A���Ӑ�ɐݒ肵�Ă���SF���_�ł̍i����
                    if (customerCode > 0)
                    {
                        // �I�����C����ʋ敪�A���Ӑ��ƃR�[�h�A���Ӑ拒�_�R�[�h�̔���
                        if (!(this._recBgnGdsAcs.CustomerDic[customerCode].OnlineKindDiv == 10  // 10:SCM
                            && this._recBgnGdsAcs.CustomerDic[customerCode].CustomerEpCode.Trim().Equals(wk.CnectOriginalEpCd.Trim())
                            && this._recBgnGdsAcs.CustomerDic[customerCode].CustomerSecCode.Trim().Equals(wk.CnectOriginalSecCd.Trim())
                            ))
                        {

                            continue;
                        }
                    }
                    #endregion SCM��ƘA���f�[�^�̍i����

                    // ���Ӑ�w��L��
                    if (customerCode > 0)
                    {
                        // ���Ӑ�ǉ��L���`�F�b�N
                        DataRow[] rows = this._secCusSetDataTable.Select("CustomerCode = '" + customerCode.ToString().PadLeft(8, '0') + "'");
                        if (rows.Length == 0)
                        {
                            // ���Ӑ�R�[�h�̎w�肪����ꍇ�͊Y���̓��Ӑ�����擾���s�ǉ�����
                            RecBgnGdsDataSet.SecCusSetRow row = _secCusSetDataTable.NewSecCusSetRow();
                            row.CustomerCode = customerCode.ToString().PadLeft(8, '0');
                            row.CustomerName = ((CustomerInfo)this._recBgnGdsAcs.CustomerDic[customerCode]).CustomerSnm.Trim();
                            row.SectionCode = wk.CnectOtherSecCd;
                            row.SectionName = wk.CnectOtherSecNm;
                            row.CnectOriginalEpCd = wk.CnectOriginalEpCd;
                            row.CnectOriginalSecCd = wk.CnectOriginalSecCd;
                            row.MngSectionCode = ((CustomerInfo)this._recBgnGdsAcs.CustomerDic[customerCode]).MngSectionCode.Trim(); // �Ǘ����_�R�[�h
                            _secCusSetDataTable.AddSecCusSetRow(row);
                        }
                    }
                    else
                    {
                        // ���Ӑ�R�[�h�̎w�肪�Ȃ��ꍇ�͑Ώہi�I�����C����񂪓���ł���΁A�����̓��Ӑ�j�̓��Ӑ�����擾���s�ǉ�����
                        foreach (CustomerInfo customerInfo in this._recBgnGdsAcs.CustomerDic.Values)
                        {
                            if (customerInfo.OnlineKindDiv == 10  // 10:SCM
                             && customerInfo.CustomerEpCode.Trim().Equals(wk.CnectOriginalEpCd.Trim())
                             && customerInfo.CustomerSecCode.Trim().Equals(wk.CnectOriginalSecCd.Trim()))
                            {
                                // ���Ӑ�ǉ��L���`�F�b�N
                                DataRow[] rows = this._secCusSetDataTable.Select("CustomerCode = '" + ((CustomerInfo)this._recBgnGdsAcs.CustomerDic[customerInfo.CustomerCode]).CustomerCode.ToString().PadLeft(8, '0') + "'");
                                if (rows.Length == 0)
                                {
                                    RecBgnGdsDataSet.SecCusSetRow row = _secCusSetDataTable.NewSecCusSetRow();
                                    row.CustomerCode = ((CustomerInfo)this._recBgnGdsAcs.CustomerDic[customerInfo.CustomerCode]).CustomerCode.ToString().PadLeft(8, '0');
                                    row.CustomerName = ((CustomerInfo)this._recBgnGdsAcs.CustomerDic[customerInfo.CustomerCode]).CustomerSnm.Trim();
                                    row.SectionCode = wk.CnectOtherSecCd;
                                    row.SectionName = wk.CnectOtherSecNm;
                                    row.CnectOriginalEpCd = wk.CnectOriginalEpCd;
                                    row.CnectOriginalSecCd = wk.CnectOriginalSecCd;
                                    row.MngSectionCode = ((CustomerInfo)this._recBgnGdsAcs.CustomerDic[customerInfo.CustomerCode]).MngSectionCode.Trim(); // �Ǘ����_�R�[�h
                                    _secCusSetDataTable.AddSecCusSetRow(row);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// SCM��ƘA���f�[�^����
        /// �i�������̃G���[���b�Z�[�W�̏o�͐���j
        /// </summary>
        /// <param name="scmEpScCntList">SCM��ƘA���f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X 0�F����I�� 0�ȊO�F�ُ�I�� </returns>
        private int SearchCnectOriginalEpFromSc(ref List<ScmEpScCnt> scmEpScCntList)
        {
            int status = -1;
            const string ctASSEMBLY_ID = "PMREC09021U";
            const string ctASSEMBLY_NAME = "���������i�ݒ�}�X�^";
            List<ScmEpCnect> scmEpCnectList = new List<ScmEpCnect>();

            try
            {
                bool msgDiv;
                string errMsg;

                status = this._scmEpScCntAcs.SearchCnectOriginalEpFromSc(this._enterpriseCode, ConstantManagement.LogicalMode.GetData01, out scmEpScCntList, out msgDiv, out errMsg);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                        {
                            string message = "SCM��ƘA���f�[�^�̓Ǎ��݂ɂă^�C���A�E�g���������܂����B";
                            if (msgDiv)
                            {
                                message = message + Environment.NewLine + Environment.NewLine + "*�ڍ� = " + errMsg;
                            }

                            TMsgDisp.Show(
                                this,								// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                                ctASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                                ctASSEMBLY_NAME,					// �v���O��������
                                "Search",							// ��������
                                TMsgDisp.OPE_GET,					// �I�y���[�V����
                                message,							// �T�[�o�[����̃��b�Z�[�W��\��
                                status,								// �X�e�[�^�X�l
                                this._scmEpScCntAcs,				// �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK,				// �\������{�^��
                                MessageBoxDefaultButton.Button1);	// �����\���{�^��
                            break;
                        }
                    default:
                        {
                            // �T�[�`
                            TMsgDisp.Show(
                                this,	        						 // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOPDISP,         // �G���[���x��
                                ctASSEMBLY_ID,			          		 // �A�Z���u���h�c�܂��̓N���X�h�c
                                ctASSEMBLY_NAME,				         // �v���O��������
                                "Search",				        		 // ��������
                                TMsgDisp.OPE_GET,        				 // �I�y���[�V����
                                "��ƘA���f�[�^�̌����Ɏ��s���܂����B",  // �\�����郁�b�Z�[�W
                                status,								     // �X�e�[�^�X�l
                                this._scmEpScCntAcs,         			 // �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK,		        	 // �\������{�^��
                                MessageBoxDefaultButton.Button1);        // �����\���{�^��
                            break;
                        }
                }

            }
            catch (Exception ex)
            {
                string message = "��ƘA���f�[�^���������ɂė�O���������܂����B" + Environment.NewLine + ex.Message;
                TMsgDisp.Show(
                    this,									// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_STOPDISP,		// �G���[���x��
                    ctASSEMBLY_ID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                    ctASSEMBLY_NAME,						// �v���O��������
                    "Search",								// ��������
                    TMsgDisp.OPE_GET,						// �I�y���[�V����
                    message,								// �\�����郁�b�Z�[�W
                    status,									// �X�e�[�^�X�l
                     this._scmEpScCntAcs,					// �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK,					// �\������{�^��
                    MessageBoxDefaultButton.Button1);		// �����\���{�^��
            }

            return status;
        }

        /// <summary>
        /// RecBgnGds->RecBgnGdsTmp
        /// </summary>
        /// <param name="RecBgnGdsWork">���������i�ݒ�</param>
        /// <returns>���������i�ݒ�TEMP</returns>
        /// <remarks>
        /// <br>Note       : RecBgnGds->RecBgnGdsTmp</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
        //private void AddToRecBgnCustTmpFromRecBgnCust(RecBgnGdsDataSet.RecBgnCustRow recBgnCust
        //                                        , RecBgnGdsDataSet.SecCusSetRow secCusSetRow
        //                                        , List<RecBgnGdsAcs.StartEndDate> retOpenStartEndDateList
        //                                        , GoodsUnitData goodsUnitData)
        private void AddToRecBgnCustTmpFromRecBgnCust(RecBgnGdsDataSet.RecBgnCustRow recBgnCust
                                                , RecBgnGdsDataSet.SecCusSetRow secCusSetRow
                                                , List<RecBgnGdsAcs.StartEndDate> retOpenStartEndDateList
                                                , GoodsUnitData goodsUnitData
                                                , Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList
                                                , Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList)
        // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
        {
            bool status = true;
            foreach (RecBgnGdsAcs.StartEndDate list in retOpenStartEndDateList)
            {
                status = true;
                foreach (RecBgnGdsDataSet.RecBgnCustTmpRow recBgnCustTmp in this._recBgnCustTmpDataTable)
                {
                    // �d���`�F�b�N
                    if ((recBgnCustTmp.InqOriginalEpCd == secCusSetRow.CnectOriginalEpCd)
                     && (recBgnCustTmp.InqOriginalSecCd == secCusSetRow.CnectOriginalSecCd)
                     && (recBgnCustTmp.InqOtherEpCd == this._enterpriseCode)
                     && (recBgnCustTmp.InqOtherSecCd.Trim() == secCusSetRow.SectionCode.Trim()))
                    {
                        if ((recBgnCustTmp.ApplyStaDate <= int.Parse(list.StartDate.ToString("yyyyMMdd"))
                          && int.Parse(list.StartDate.ToString("yyyyMMdd")) <= recBgnCustTmp.ApplyEndDate)
                         || (recBgnCustTmp.ApplyStaDate <= int.Parse(list.EndDate.ToString("yyyyMMdd"))
                          && int.Parse(list.EndDate.ToString("yyyyMMdd")) <= recBgnCustTmp.ApplyEndDate))
                        {
                            status = false;
                            break;
                        }
                    }
                }

                // �G���[�̏ꍇ�A�ǉ����Ȃ�
                if (status == false) continue;

                long wkMkrSuggestRtPric = 0;
                long wkListPrice = 0;
                long wkUnitPrice = 0;
                bool uPricDiv = false;  // ADD 2015/03/26 Y.Wakita

                // ���i�擾
                // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                //Calculator.GetUnitPrice(int.Parse(secCusSetRow.CustomerCode)
                //                           , goodsUnitData
                //                           , list.StartDate
                //                           , secCusSetRow.MngSectionCode
                //                           , out wkMkrSuggestRtPric
                //                           , out wkListPrice
                //                           , out wkUnitPrice);
                Calculator.GetUnitPrice(int.Parse(secCusSetRow.CustomerCode)
                                           , goodsUnitData
                                           , list.StartDate
                                           , secCusSetRow.MngSectionCode
                                           , mkrSuggestRtPricList
                                           , mkrSuggestRtPricUList
                                           , out uPricDiv   // ADD 2015/03/26 Y.Wakita
                                           , out wkMkrSuggestRtPric
                                           , out wkListPrice
                                           , out wkUnitPrice);
                // --- UPD 2015/03/25 Y.Wakita ----------<<<<<

                this._recBgnCustTmpDataTable.BeginLoadData();
                RecBgnGdsDataSet.RecBgnCustTmpRow newRow = this._recBgnCustTmpDataTable.NewRecBgnCustTmpRow();

                newRow.RowNo = this._recBgnCustTmpDataTable.Count + 1;
                // ---------- ���ʍ��� ----------
                newRow.FilterGuid = recBgnCust.FilterGuid;
                newRow.UpdateTime = recBgnCust.UpdateTime;
                newRow.RowDeleteFlg = recBgnCust.RowDeleteFlg;
                // ---------- �ݒ荀�� ----------
                newRow.InqOriginalEpCd = secCusSetRow.CnectOriginalEpCd;                            // �⍇������ƃR�[�h
                newRow.InqOriginalSecCd = secCusSetRow.CnectOriginalSecCd;                          // �⍇�������_�R�[�h
                newRow.InqOtherEpCd = this._enterpriseCode;                                         // �⍇�����ƃR�[�h
                newRow.InqOtherSecCd = secCusSetRow.SectionCode;                                    // �⍇���拒�_�R�[�h
                newRow.CustomerCode = secCusSetRow.CustomerCode.ToString().PadLeft(8, '0');         // ���Ӑ�R�[�h
                //newRow.BrgnGoodsGrpCode = 0;                                                        // ���������i�O���[�v�R�[�h
                newRow.BrgnGoodsGrpCode = this._recBgnGdsRow.BrgnGoodsGrpCode;                      // ���������i�O���[�v�R�[�h
                newRow.GoodsNo = this._recBgnGdsRow.GoodsNo;
                newRow.GoodsMakerCode = this._recBgnGdsRow.GoodsMakerCode;
                newRow.GoodsApplyStaDate = int.Parse(this._swGoodsUnitData.OfferDate.ToString("yyyyMMdd"));     
                newRow.DisplayDivCode = 1;                                                          // �\���敪
                newRow.MngSectionCode = secCusSetRow.MngSectionCode;                                // �Ǘ����_�R�[�h
                newRow.MkrSuggestRtPric = wkMkrSuggestRtPric;                                       // ���[�J�[��]�������i
                newRow.ListPrice = wkListPrice;                                                     // �艿
                newRow.UnitCalcRate = 0;                                                            // ������
                newRow.UnitPrice = wkUnitPrice;                                                     // �P��
                newRow.ApplyStaDate = int.Parse(list.StartDate.ToString("yyyyMMdd"));               // �K�p�J�n��
                newRow.ApplyEndDate = int.Parse(list.EndDate.ToString("yyyyMMdd"));                 // �K�p�I����

                this._recBgnCustTmpDataTable.AddRecBgnCustTmpRow(newRow);
                this._recBgnCustTmpDataTable.EndLoadData();
            }

        }

        #endregion

        #endregion

        #region �V���A���C�Y�E�f�V���A���C�Y
        /// <summary>
        /// ���������i�p���[�U�[�ݒ�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���������i�p���[�U�[�ݒ�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }

        }

        /// <summary>
        /// ���������i�p���[�U�[�ݒ�f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���������i�p���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                try
                {
                    this._userSetting = UserSettingController.DeserializeUserSetting<RecBgnCustUserSet>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                }
                catch
                {
                    this._userSetting = new RecBgnCustUserSet();
                }
            }
        }

        #endregion

        #region �`�F�b�N����
        /// <summary>
        /// RecBgnGdsTmp->RecBgnGds
        /// </summary>
        /// <param name="RecBgnGds">���������i�ʐݒ�</param>
        /// <returns>���������i�ݒ�</returns>
        /// <remarks>
        /// <br>Note       : RecBgnGdsTmp->RecBgnGds</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private bool AddToRecBgnCustCheck(int rowNo, out string errorMsg)
        {
            bool status = true;

            int errorCount = 0;
            errorMsg = string.Empty;

            foreach (RecBgnGdsDataSet.RecBgnCustTmpRow recBgnGdsTmp in this._recBgnCustTmpDataTable)
            {
                recBgnGdsTmp.ErrorDiv = 0;
                foreach (RecBgnGdsDataSet.RecBgnCustRow recBgnCust in this._recBgnCustDataTable)
                {
                    if (recBgnCust.FilterGuid == Guid.Empty && recBgnCust.RowDeleteFlg == 1) continue;

                    if (recBgnCust.RowNo == rowNo) continue;

                    // �d���`�F�b�N
                    if ((recBgnCust.InqOriginalEpCd == recBgnGdsTmp.InqOriginalEpCd)
                     && (recBgnCust.InqOriginalSecCd == recBgnGdsTmp.InqOriginalSecCd)
                     && (recBgnCust.InqOtherEpCd == recBgnGdsTmp.InqOtherEpCd)
                     && (recBgnCust.InqOtherSecCd.Trim() == recBgnGdsTmp.InqOtherSecCd.Trim())
                     )
                    {
                        int startDate = 0;
                        if (!recBgnCust.ApplyStaDate.Trim().Equals(string.Empty)) startDate = int.Parse(recBgnCust.ApplyStaDate.Trim().Replace("/", ""));
                        int endDate = 0;
                        if (!recBgnCust.ApplyEndDate.Trim().Equals(string.Empty)) endDate = int.Parse(recBgnCust.ApplyEndDate.Trim().Replace("/", ""));

                        if ((startDate <= recBgnGdsTmp.ApplyStaDate
                           && recBgnGdsTmp.ApplyStaDate <= endDate)
                           || (startDate <= recBgnGdsTmp.ApplyEndDate
                           && recBgnGdsTmp.ApplyEndDate <= endDate))
                        {

                            // �L�[���ڂ��d�����Ă���ꍇ
                            errorMsg += "���J���F" + recBgnCust.ApplyStaDate.ToString().PadLeft(6, '0')
                                    + "�`" + recBgnCust.ApplyEndDate.ToString().PadLeft(6, '0')
                                    + "�A���Ӑ�F" + recBgnCust.CustomerCode.ToString().PadLeft(8, '0')
                                    + "\r\n";
                            recBgnGdsTmp.ErrorDiv = 1;
                            errorCount += 1;
                        }
                    }
                }
            }

            if (this._recBgnCustTmpDataTable.Count == errorCount)
            {
                // �W�J�f�[�^���S�ďd��
                status = false;
            }

            return status;
        }

        /// <summary>
        /// RecBgnGdsTmp->RecBgnGds
        /// </summary>
        /// <param name="RecBgnGds">���������i�ݒ�</param>
        /// <returns>���������i�ݒ�</returns>
        /// <remarks>
        /// <br>Note       : RecBgnGdsTmp->RecBgnGds</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void AddToRecBgnCustFromRecBgnCustTmp(RecBgnGdsDataSet.RecBgnCustTmpDataTable RecBgnCustTmp, int rowIndex, int rowNo)
        {
            // ���f�[�^�폜
            this._recBgnCustDataTable.Rows[rowIndex].Delete();
            this._recBgnCustDataTable.AcceptChanges();

            foreach (RecBgnGdsDataSet.RecBgnCustTmpRow recBgnCustTmp in RecBgnCustTmp)
            {
                if (recBgnCustTmp.ErrorDiv == 1) continue;   // �d���G���[�̏ꍇ

                this._recBgnCustDataTable.BeginLoadData();
                RecBgnGdsDataSet.RecBgnCustRow newRow = this._recBgnCustDataTable.NewRecBgnCustRow();

                // ---------- ���ʍ��� ----------
                newRow.RowNo = rowNo;
                newRow.FilterGuid = recBgnCustTmp.FilterGuid;
                newRow.UpdateTime = recBgnCustTmp.UpdateTime;
                newRow.RowDeleteFlg = recBgnCustTmp.RowDeleteFlg;
                newRow.InqOriginalEpCd = recBgnCustTmp.InqOriginalEpCd;                                             // �⍇������ƃR�[�h
                newRow.InqOriginalSecCd = recBgnCustTmp.InqOriginalSecCd;                                           // �⍇�������_�R�[�h
                newRow.InqOtherEpCd = recBgnCustTmp.InqOtherEpCd;                                                   // �⍇�����ƃR�[�h
                newRow.InqOtherSecCd = recBgnCustTmp.InqOtherSecCd;                                                 // �⍇���拒�_�R�[�h 
                // ---------- ���ʍ��� ----------
                newRow.CustomerCode = recBgnCustTmp.CustomerCode.ToString().PadLeft(8, '0');                        // ���Ӑ�R�[�h
                newRow.BrgnGoodsGrpCode = recBgnCustTmp.BrgnGoodsGrpCode;                                           // ���������i�O���\�v�R�[�h
                newRow.BrgnGoodsGrpName = this._recBgnGdsRow.BrgnGoodsGrpName;                                      // ���������i�O���\�v��
                newRow.GoodsNo = recBgnCustTmp.GoodsNo;                                                             // �i��
                newRow.GoodsMakerCode = recBgnCustTmp.GoodsMakerCode;                                               // ���[�J�[
                newRow.GoodsApplyStaDate = recBgnCustTmp.GoodsApplyStaDate;                                         // ���i�K�p�J�n��
                newRow.MngSectionCode = recBgnCustTmp.MngSectionCode;                                               // �Ǘ����_
                newRow.DisplayDivCode = recBgnCustTmp.DisplayDivCode;                                               // �\���敪
                newRow.MkrSuggestRtPric = recBgnCustTmp.MkrSuggestRtPric;                                           // ���[�J�[��]�������i
                newRow.ListPrice = recBgnCustTmp.ListPrice;                                                         // �艿
                newRow.UnitCalcRate = recBgnCustTmp.UnitCalcRate;                                                   // ������
                newRow.UnitPrice = recBgnCustTmp.UnitPrice;                                                         // �P��
                string startDate = string.Empty;                                                                    // �K�p�J�n��
                if (recBgnCustTmp.ApplyStaDate != 0) startDate = recBgnCustTmp.ApplyStaDate.ToString("0000/00/00");
                newRow.ApplyStaDate = startDate;
                string endDate = string.Empty;                                                                      // �K�p�I����
                if (recBgnCustTmp.ApplyEndDate != 0) endDate = recBgnCustTmp.ApplyEndDate.ToString("0000/00/00");
                newRow.ApplyEndDate = endDate;
                // ---------- ���̎擾���� ----------
                newRow.CustomerName = this._recBgnGdsAcs.GetCustomerName(int.Parse(recBgnCustTmp.CustomerCode));    // ���Ӑ於

                newRow.RowDevelopFlg = 1;
                this._recBgnCustDataTable.AddRecBgnCustRow(newRow);
                this._recBgnCustDataTable.EndLoadData();

                rowNo += 1;
            }
            this._recBgnCustDataTable.AcceptChanges();
        }
        #endregion


        /// <summary>
        /// �O���b�h �Z���ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_CellChange(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;

            // ���J�敪
            if (e.Cell.Column.Key == this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName)
            {

                // ���m��s�͔��肵�Ȃ�
                RecBgnGdsDataSet.RecBgnCustRow row = (RecBgnGdsDataSet.RecBgnCustRow)this._recBgnCustDataTable.Rows[e.Cell.Row.Index];
                if (row.RowDevelopFlg == 0) return;
                
                // �����J���͂��������i�O���[�v�E���i�̒l���N���A�����͕s��
                List<UltraGridCell> cellList = new List<UltraGridCell>();
                cellList.Add(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName]);   // ���������i�O���[�v�R�[�h
                cellList.Add(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName]);       // ������
                cellList.Add(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.UnitPriceColumn.ColumnName]);          // ���P��


                // �����E�񊈐��ؑ�
                foreach (UltraGridCell cell in cellList)
                {
                    if (e.Cell.Text != "0")
                    {
                        cell.Appearance.BackColor = Color.Empty;
                        cell.Appearance.BackColor2 = Color.Empty;
                        cell.Activation = Activation.AllowEdit;
                    }
                    else
                    {
                        cell.Appearance.BackColor = ct_DISABLE_COLOR;
                        cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                        cell.Activation = Activation.NoEdit;
                    }
                }

                // --- DEL 2015/03/16 Y.Wakita �v�] ---------->>>>>
                //// �Z���l���X�V
                //if (e.Cell.Text != "0")
                //{
                //    // ���J���͍Čv�Z
                //    RecBgnGdsDataSet.RecBgnCustRow dataRow = (RecBgnGdsDataSet.RecBgnCustRow)this._recBgnCustDataTable.Rows[e.Cell.Row.Index];
                //    DateTime startDate = DateTime.Parse(dataRow.ApplyEndDate);
                //    long mkrSuggestRtPric = 0;
                //    long listPrice = 0;
                //    long unitPrice = 0;
                //    this._calculator.GetUnitPrice(int.Parse(dataRow.CustomerCode)
                //                               , this._swGoodsUnitData
                //                               , startDate
                //                               , dataRow.MngSectionCode
                //                               , out mkrSuggestRtPric
                //                               , out listPrice
                //                               , out unitPrice);

                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].Value = mkrSuggestRtPric;  // ���[�J�[��]�������i
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Value = listPrice;                // �艿
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Value = unitPrice;                // ����

                //    // ���������i�O���[�v�R�[�h�̎w�肪�Ȃ��ꍇ�͈����p�����R�[�h�A���̂��g�p����
                //    if (int.Parse(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value.ToString()) == 0)
                //    {
                //        this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = this._recBgnGdsRow.BrgnGoodsGrpCode;
                //        this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = this._recBgnGdsRow.BrgnGoodsGrpName;
                //    }

                //}
                //else
                //{
                //    // ����J���̓N���A
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = 0;                 // ���������i�O���[�v�R�[�h
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = string.Empty;      // ���������i�O���[�v��
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].Value = 0;                 // ���[�J�[��]�������i
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Value = 0;                        // �艿
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Value = 0;                     // ������
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Value = 0;                        // ���P��
                
                //}
                // --- DEL 2015/03/16 Y.Wakita �v�] ----------<<<<<
            }
        }
    }

}
