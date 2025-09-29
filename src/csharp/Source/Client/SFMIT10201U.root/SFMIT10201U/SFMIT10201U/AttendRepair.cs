using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinGrid;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �t�������ݒ���
    /// </summary>
    public partial class AttendRepairSetForm : Form
    {
        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public AttendRepairSetForm()
        {
            InitializeComponent();

            this._TBOServiceACS = new TBOServiceACS();
            this._repairDic = new Dictionary<long, List<AttendRepairSet>>();
            this._saveDiv = false;
        }
        #endregion

        #region �����o�ϐ�
        /// <summary>��ƃR�[�h</summary>
        private string _enterPriseCode;
        /// <summary>TOB�A�N�Z�X�N���X</summary>
        private TBOServiceACS _TBOServiceACS;
        /// <summary>�t�������f�B�N�V���i���[</summary>
        //private Dictionary<int, List<AttendRepairSet>> _repairDic;
        private Dictionary<long, List<AttendRepairSet>> _repairDic;
        /// <summary>�t�������e�[�u��</summary>
        private DataTable _repairTable;
        /// <summary>�J�e�S�� ���ݒlIndex</summary>
        private int _selectIndex;

        /// <summary>�ۑ������t���O</summary>
        public bool _saveDiv;
        /// <summary>���i�J�e�S�����</summary>
        public List<GoodsCategory> _categoryList;

        #endregion

        #region Const

        // �e�[�u����
        private const string TABLENM = "TABLENM";
        // �e�[�u���J����
        private const string COL_DEL = "�폜";
        private const string COL_SORTNO = "�\����";
        private const string COL_REPAIRNAME = "����";
        private const string COL_DATATYPE = "��ƁE���i";
        private const string COL_PRICETYPE = "�����^�C�v";
        private const string COL_REPAIRPRICE = "���z";
        private const string COL_DATA = "�X�V�O�f�[�^";
        // �f�[�^�t�H�[�}�b�g
        private const string CT_MONEYFORMAT = "#,##0;-#,##0;''";
        // PGID
        private const string CT_ASSEMBLYID = "SFMIT10201U";

        #endregion

        #region Method

        #region Public

        /// <summary>
        /// �N������
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowDialog(string enterPriseCode, short bootMode)
        {
            this._enterPriseCode = enterPriseCode;
            int st = 0;
          
            // ���i�J�e�S���Z�b�g
            this.SetGoodsCategory();

            // �t�������ݒ�擾
            st = this.SearchAttendRepairSet(enterPriseCode);

            // �f�[�^�e�[�u���쐬
            this.MakeDataTable();
            // �f�[�^�Z�b�g
            this.SetDataTable();
            // �\��
            return this.ShowDialog();
        }

        #endregion

        #region Private

        #region �e�[�u���\�z
        /// <summary>
        /// �f�[�^�e�[�u���쐬
        /// </summary>
        private void MakeDataTable()
        {
            // ���i�e�[�u��(����)
            this._repairTable = new DataTable(TABLENM);

            this._repairTable.Columns.Add(COL_DEL, typeof(Int32));          // �폜�敪       hyde 
            this._repairTable.Columns.Add(COL_SORTNO, typeof(Int32));       // �\�[�g��       hyde 
            this._repairTable.Columns.Add(COL_REPAIRNAME, typeof(string));  // ����
            this._repairTable.Columns.Add(COL_DATATYPE, typeof(Int32));     // ��ƁE���i�敪
            this._repairTable.Columns.Add(COL_PRICETYPE, typeof(Int32));    // ���z�^�C�v
            this._repairTable.Columns.Add(COL_REPAIRPRICE, typeof(long));  // ���z
            this._repairTable.Columns.Add(COL_DATA, typeof(object));        // �X�V�O�f�[�^
            this._repairTable.Columns[COL_DEL].DefaultValue = 0;
            this._repairTable.Columns[COL_SORTNO].DefaultValue = 0;
            this._repairTable.Columns[COL_REPAIRNAME].DefaultValue = "";
            this._repairTable.Columns[COL_DATATYPE].DefaultValue = 1;
            this._repairTable.Columns[COL_PRICETYPE].DefaultValue = 1;
            this._repairTable.Columns[COL_REPAIRPRICE].DefaultValue = 0;

        }
        #endregion

        #region Grid�J�����ݒ�
        /// <summary>
        /// �O���b�h�J�����ݒ�
        /// </summary>
        /// <param name="cols"></param>
        private void SettingGridColumn(ColumnsCollection cols)
        {
            //�S�ẴJ�������\���ɂ��Ă���
            for (int i = 0; i < this.AttendRepair_Grid.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                this.AttendRepair_Grid.DisplayLayout.Bands[0].Columns[i].Hidden = true;
            }

            // �f�[�^�^�C�v
            cols[COL_DATATYPE].Hidden = true;
            cols[COL_DATATYPE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList();
            valueList1.ValueListItems.Add("1", "���");
            valueList1.ValueListItems.Add("2", "���i");
            cols[COL_DATATYPE].ValueList = valueList1;

            // ���z�^�C�v
            cols[COL_PRICETYPE].Hidden = false;
            cols[COL_PRICETYPE].Width = 40;
            cols[COL_PRICETYPE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            Infragistics.Win.ValueList valueList2 = new Infragistics.Win.ValueList();
            valueList2.ValueListItems.Add("1", "�P��");
            valueList2.ValueListItems.Add("2", "���z");
            cols[COL_PRICETYPE].ValueList = valueList2;

            // ����
            cols[COL_REPAIRNAME].Hidden = false;
            cols[COL_REPAIRNAME].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            cols[COL_REPAIRNAME].MaxLength = 60;

            // ���z
            cols[COL_REPAIRPRICE].Hidden = false;
            cols[COL_PRICETYPE].Width = 100;
            cols[COL_REPAIRPRICE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            cols[COL_REPAIRPRICE].Format = CT_MONEYFORMAT;
            cols[COL_REPAIRPRICE].MaxLength = 9;
            cols[COL_REPAIRPRICE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
        }
        #endregion

        #region �f�[�^��Table���f
        /// <summary>
        /// �擾�����f�[�^���e�[�u���ɃZ�b�g���܂�
        /// </summary>
        private void SetDataTable()
        {
            this._repairTable.Rows.Clear();

            if (this._repairDic.ContainsKey((long)this.Category_ComboEditor.Value))
            {
                foreach (AttendRepairSet set in this._repairDic[(long)this.Category_ComboEditor.Value])
                {
                    DataRow row = this._repairTable.NewRow();
                    row[COL_DATA] = set;
                    row[COL_DATATYPE] = set.dataType;
                    row[COL_DEL] = set.logicalDelDiv;
                    row[COL_PRICETYPE] = set.priceType;
                    row[COL_REPAIRNAME] = set.repairName;
                    row[COL_REPAIRPRICE] = set.repairPrice;
                    row[COL_SORTNO] = set.sortNo;
                    this._repairTable.Rows.Add(row);
                }
            }
            DataView view = this._repairTable.DefaultView;
            view.Sort = COL_SORTNO + " ASC";
            // �t�B���^�[�|���Ă݂�
            StringBuilder filter = new StringBuilder();
            filter.Append(String.Format("{0}={1}", COL_DEL, 0));
            view.RowFilter = filter.ToString();
            this.AttendRepair_Grid.DataSource = view;
        }
        #endregion

        #region ����

        #region ���i�J�e�S��
        /// <summary>
        /// �J�e�S�����X�g�쐬
        /// </summary>
        private void SetGoodsCategory()
        {
            foreach (GoodsCategory category in this._categoryList)
            {
                this.Category_ComboEditor.Items.Add(category.GoodsCategoryId, category.GoodsCategoryName);
            }
            // �����I���̓^�C��
            this.Category_ComboEditor.ValueChanged -= new EventHandler(this.Category_ComboEditor_ValueChanged); 
            this._selectIndex = 0;
            this.Category_ComboEditor.SelectedIndex = 0;
            this.Category_ComboEditor.ValueChanged += new EventHandler(this.Category_ComboEditor_ValueChanged); 
        }
        #endregion

        #region �t������
        /// <summary>
        /// �t�������ݒ�S���擾
        /// </summary>
        /// <returns></returns>
        private int SearchAttendRepairSet(string enterPriseCode)
        {
            List<AttendRepairSet> attendRepairSetList = new List<AttendRepairSet>();
            string errMsg = "";
            int st = this._TBOServiceACS.GetAttendRepairSet(enterPriseCode, out attendRepairSetList, out errMsg);
            if (st == 0)
            {
                // �f�B�N�V���i���[�ɃZ�b�g
                foreach (AttendRepairSet ripairSet in attendRepairSetList)
                {
                    if (this._repairDic.ContainsKey(ripairSet.goodsCategoryId))
                    {
                        this._repairDic[ripairSet.goodsCategoryId].Add(ripairSet);
                    }
                    else
                    {
                        List<AttendRepairSet> wkList = new List<AttendRepairSet>();
                        wkList.Add(ripairSet);
                        this._repairDic.Add(ripairSet.goodsCategoryId, wkList);
                    }
                }
            }
            else
            {
                TMsgDisp.Show(
                     this,							                // �e�E�B���h�E�t�H�[��
                     emErrorLevel.ERR_LEVEL_STOPDISP,	            // �G���[���x��
                     CT_ASSEMBLYID,					                // �A�Z���u��ID�܂��̓N���XID
                     "�t���������̎擾�Ɏ��s���܂����B",	        // �\�����郁�b�Z�[�W 
                     st,								            // �X�e�[�^�X�l
                     MessageBoxButtons.OK);
            }
            return st;
        }
        #endregion

        #endregion

        #region �ۑ�����
        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns></returns>
        private int SaveProc()
        {
            int st = 0;
            string errMsg = "";

            // ���̓`�F�b�N
            if (!this.DataInputCheck())
            {
                return -1;
            }

            // �ۑ��Ώۃf�[�^�쐬
            AttendRepairSet[] saveArray = new AttendRepairSet[0];
            this.MakeSaveData(ref saveArray);

            // �ۑ��Ώۃf�[�^���Ȃ���Ώ������f
            if (saveArray == null || saveArray.Length == 0)
            {
                return 0;
            }

            // �ۑ����s
            st = this._TBOServiceACS.SaveAttendRepairSet(ref saveArray, out errMsg);

            if (st == 0)
            {
                 TMsgDisp.Show(
                       this,								// �e�E�B���h�E�t�H�[��
                       emErrorLevel.ERR_LEVEL_INFO,	    // �G���[���x��
                       CT_ASSEMBLYID,					// �A�Z���u��ID�܂��̓N���XID
                       "�ۑ����܂����B",			// �\�����郁�b�Z�[�W 
                       0,								// �X�e�[�^�X�l
                       MessageBoxButtons.OK);

                 this._saveDiv = true;

                // Dic�ŐV��
                List<AttendRepairSet> list = new List<AttendRepairSet>();
                if (saveArray != null)
                {
                    list.AddRange(saveArray);
                }

                if (this._repairDic.ContainsKey((long)this.Category_ComboEditor.Value))
                {
                    this._repairDic.Remove((long)this.Category_ComboEditor.Value);
                    this._repairDic.Add((long)this.Category_ComboEditor.Value, list);
                }
                else
                {
                    this._repairDic.Add((long)this.Category_ComboEditor.Value, list);
                }
                // �e�[�u���č쐬
                this.SetDataTable();
            }
            else
            {
                 TMsgDisp.Show(
                     this,							    // �e�E�B���h�E�t�H�[��
                     emErrorLevel.ERR_LEVEL_STOPDISP,	    // �G���[���x��
                     CT_ASSEMBLYID,					        // �A�Z���u��ID�܂��̓N���XID
                     "�t�������̓o�^�Ɏ��s���܂����B",		// �\�����郁�b�Z�[�W 
                     st,								    // �X�e�[�^�X�l
                     MessageBoxButtons.OK);
            }
            return st;
        }

        /// <summary>
        /// �ۑ��Ώۃf�[�^�쐬
        /// </summary>
        /// <param name="saveArray"></param>
        private void MakeSaveData(ref AttendRepairSet[] saveArray)
        {
            // �`���~
            this.AttendRepair_Grid.BeginUpdate();

            // ��U�t�B���^�[������
            this._repairTable.DefaultView.RowFilter = "";

            // ���ۑ��̍폜�f�[�^���e�[�u������폜
            StringBuilder cndString = new StringBuilder();
            cndString.Append(String.Format("{0}={1} AND {2} is {3}" ,COL_DEL, 1, COL_DATA, "null"));

            DataRow[] delRows = this._repairTable.Select(cndString.ToString());
            foreach (DataRow delRow in delRows)
            {
                delRow.Delete();
            }
            this._repairTable.AcceptChanges();

            List<AttendRepairSet> retList = new List<AttendRepairSet>();
            for (int i = 0; i < this._repairTable.DefaultView.Count; i++)
            {
                AttendRepairSet set = new AttendRepairSet();
                if (this._repairTable.DefaultView[i].Row[COL_DATA] != DBNull.Value)
                {
                    set = (((AttendRepairSet)this._repairTable.DefaultView[i].Row[COL_DATA]).Clone());
                }
                set.enterpriseCode = this._enterPriseCode;
                set.goodsCategoryId = (long)this.Category_ComboEditor.Value;

                set.dataType = (int)this._repairTable.DefaultView[i].Row[COL_DATATYPE];
                set.priceType = (int)this._repairTable.DefaultView[i].Row[COL_PRICETYPE];
                set.repairName = this._repairTable.DefaultView[i].Row[COL_REPAIRNAME].ToString();
                set.repairPrice = (long)this._repairTable.DefaultView[i].Row[COL_REPAIRPRICE];
                set.sortNo = i + 1;
                set.logicalDelDiv = (int)this._repairTable.DefaultView[i].Row[COL_DEL];
                retList.Add(set);
            }
            saveArray = retList.ToArray();

            // �ēx�t�B���^�[�Z�b�g
            StringBuilder filter = new StringBuilder();
            filter.Append(String.Format("{0}={1}", COL_DEL, 0));
            this._repairTable.DefaultView.RowFilter = filter.ToString();

            // �`���~
            this.AttendRepair_Grid.EndUpdate();
            this.UpDateGrid();
        }
        #endregion

        #region �ύX�`�F�b�N
        /// <summary>
        /// �ύX�`�F�b�N
        /// </summary>
        /// <returns></returns>
        private bool CheckUpdate()
        {
            bool ret = false;
            this._repairTable.AcceptChanges();

            // �f�[�^���e��r
            for (int i = 0; i < this._repairTable.Rows.Count; i++)
            {
                DataRow row = this._repairTable.Rows[i];
                if (row[COL_DATA] == DBNull.Value)
                {
                    // �V�K�s
                    if ((int)row[COL_DEL] == 1)
                    {
                        continue;
                    }
                    else
                    {
                        // �폜�Ώۂł͂Ȃ��V�K�s������ 
                        return true;
                    }
                }
                else
                {
                    // �ۑ��ύs
                    if ((int)row[COL_DEL] == 1)
                    {
                        // �ۑ��ύs���폜����Ă���
                        return true;
                    }
                    else
                    {
                        AttendRepairSet set = (AttendRepairSet)row[COL_DATA];
                        // �f�[�^�^�C�v
                        if (!set.dataType.Equals((int)row[COL_DATATYPE]))
                        {
                            return true;
                        }
                        // ���z�^�C�v
                        if (!set.priceType.Equals((int)row[COL_PRICETYPE]))
                        {
                            return true;
                        }
                        // �\�[�g��
                        if (!set.sortNo.Equals((int)row[COL_SORTNO]))
                        {
                            return true;
                        }
                        // ��������
                        if (!set.repairName.Equals(row[COL_REPAIRNAME].ToString()))
                        {
                            return true;
                        }
                        // �������z
                        if (!set.repairPrice.Equals((long)row[COL_REPAIRPRICE]))
                        {
                            return true;
                        }
                    }
                }
            }
            return ret;
        }
        #endregion

        #region ���̓`�F�b�N
        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <returns></returns>
        private bool DataInputCheck()
        {
            bool ret = true;
            string errMsg = "";
            string columnNm = "";
            int rowIndex = 0;
            // �O���b�h���̓`�F�b�N
            if (!GridInputCheck(out errMsg, out columnNm, out rowIndex))
            {
                // ���b�Z�[�W��\��
                TMsgDisp.Show(
                   this,							        // �e�E�B���h�E�t�H�[��
                   emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                   CT_ASSEMBLYID,					        // �A�Z���u��ID�܂��̓N���XID
                   errMsg,	                                // �\�����郁�b�Z�[�W 
                   0,								        // �X�e�[�^�X�l
                   MessageBoxButtons.OK);

                this.AttendRepair_Grid.ActiveCell = this.AttendRepair_Grid.Rows[rowIndex].Cells[columnNm];
                this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode);
                ret = false;
            }
            return ret;

        }

        /// <summary>
        /// �O���b�h���̓`�F�b�N
        /// </summary>
        /// <param name="mess"></param>
        /// <param name="columnNm"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private bool GridInputCheck(out string errMsg, out string columnNm, out int rowIndex)
        {
            bool result = true;
            errMsg = "";
            columnNm = "";
            rowIndex = 0;
            //�O���b�h�̃A�b�v�f�[�g
            this.UpDateGrid();
            for (int ix = 0; ix < this.AttendRepair_Grid.Rows.Count; ix++)
            {
                UltraGridRow ugRow = this.AttendRepair_Grid.Rows[ix];

                // �����̓`�F�b�N  ����
                if (String.IsNullOrEmpty(GetCellString(ugRow.Cells[COL_REPAIRNAME].Value, "")))
                {
                    rowIndex = ix;
                    errMsg = "���̂���͂��ĉ������B";
                    columnNm = COL_REPAIRNAME;
                    return false;
                }

                // �����̓`�F�b�N  ���z
                if (GetCellLong(ugRow.Cells[COL_REPAIRPRICE].Value, 0) == 0)
                {
                    rowIndex = ix;
                    errMsg = "���z����͂��ĉ������B";
                    columnNm = COL_REPAIRPRICE;
                    return false;
                }
            }
            return result;
        }
        #endregion

        #region �O���b�h�֘A����

        #region �O���b�h�A�b�v�f�[�g����
        /// <summary>
        /// �O���b�h�A�b�v�f�[�g����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�b�v�f�[�g�������s���܂��B</br>
        /// </remarks>
        private void UpDateGrid()
        {
            this.AttendRepair_Grid.UpdateData();
            this.AttendRepair_Grid.Refresh();
        }
        #endregion

        #region �L�[����
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
        private Boolean KeyPressCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key) == true)
            {
                return true;
            }
            // ���l�ȊO�́A�m�f
            if (Char.IsNumber(key) == false)
            {
                // �����_�܂��́A�}�C�i�X�ȊO
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = "";
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
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
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
        #endregion

        #region GridValue�擾����
        /// <summary>
        /// �Z����Int32�擾
        /// </summary>
        /// <param name="value">�l</param>
        /// <param name="defaultValue">�����l</param>
        /// <returns>�擾���l</returns>
        /// <remarks>
        /// <br>Note       : �Z���Ɋi�[����Ă���l��DBNull���ǂ����𔻕ʂ��Ēl��Ԃ��܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.05.11</br>
        /// </remarks>
        private Int32 GetCellInt32(object value, Int32 defaultValue)
        {
            return (value != DBNull.Value) ? (int)value : defaultValue;
        }

        /// <summary>
        /// �Z����long�擾
        /// </summary>
        /// <param name="value">�l</param>
        /// <param name="defaultValue">�����l</param>
        /// <returns>�擾���l</returns>
        /// <remarks>
        /// <br>Note       : �Z���Ɋi�[����Ă���l��DBNull���ǂ����𔻕ʂ��Ēl��Ԃ��܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.05.11</br>
        /// </remarks>
        private long GetCellLong(object value, long defaultValue)
        {
            return (value != DBNull.Value) ? (long)value : defaultValue;
        }

        /// <summary>
        /// �Z����������擾
        /// </summary>
        /// <param name="value">�l</param>
        /// <param name="defaultValue">�����l</param>
        /// <returns>�擾������</returns>
        /// <remarks>
        /// <br>Note       : �Z���Ɋi�[����Ă���l��DBNull���ǂ����𔻕ʂ��Ēl��Ԃ��܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.05.11</br>
        /// </remarks>
        private string GetCellString(object value, string defaultValue)
        {
            return (value != DBNull.Value) ? (string)value : defaultValue;
        }
        #endregion


        #endregion

        #endregion

        #endregion

        #region Event

        #region Category_ComboEditor_ValueChanged
        /// <summary>
        /// �J�e�S���ύX��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Category_ComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // �ύX�`�F�b�N
            if (this._selectIndex != this.Category_ComboEditor.SelectedIndex)
            {
                // �J�e�S�����ύX���ꂽ
                bool dataSearhFlag = false;
                // �X�V�m�F
                if (CheckUpdate())
                {
                       // ���b�Z�[�W��\��
                    DialogResult ret = TMsgDisp.Show(
                       this,							                        // �e�E�B���h�E�t�H�[��
                       emErrorLevel.ERR_LEVEL_INFO,	                            // �G���[���x��
                       CT_ASSEMBLYID,					                        // �A�Z���u��ID�܂��̓N���XID
                       "���ݕҏW���̃f�[�^�����݂��܂��B"                       // �\�����郁�b�Z�[�W 
                       + Environment.NewLine + "�o�^���Ă���낵���ł����H",	
                       0,								                        // �X�e�[�^�X�l
                       MessageBoxButtons.YesNoCancel);
                    
                    
                    if (ret == DialogResult.Yes)
                    {
                        // �ۑ�����
                        int st = this.SaveProc();
                        if (st == 0)
                        {
                            this._selectIndex = this.Category_ComboEditor.SelectedIndex;
                            dataSearhFlag = true;
                        }
                        else
                        {
                            // �ۑ��Ɏ��s
                            this.Category_ComboEditor.ValueChanged -= new EventHandler(this.Category_ComboEditor_ValueChanged);
                            this.Category_ComboEditor.SelectedIndex = this._selectIndex;
                            this.Category_ComboEditor.ValueChanged += new EventHandler(this.Category_ComboEditor_ValueChanged);

                        }
                    }
                    else if (ret == DialogResult.No)
                    {
                        // �ҏW���e��j�� �C���f�b�N���X�V
                        this._selectIndex = this.Category_ComboEditor.SelectedIndex;
                        dataSearhFlag = true;
                    }
                    else
                    {
                        // �L�����Z�� ���@�߂�
                        this.Category_ComboEditor.ValueChanged -= new EventHandler(this.Category_ComboEditor_ValueChanged);
                        this.Category_ComboEditor.SelectedIndex = this._selectIndex;
                        this.Category_ComboEditor.ValueChanged += new EventHandler(this.Category_ComboEditor_ValueChanged);
                    }
                }
                else
                {
                    // �f�[�^�ύX�Ȃ�
                    // �C���f�b�N�X���X�V
                    this._selectIndex = this.Category_ComboEditor.SelectedIndex;
                    dataSearhFlag = true;
                }
                if (dataSearhFlag)
                {
                    // �e�[�u���č\�z
                    this.SetDataTable();
                }
            }
        }
        #endregion

        #region AttendRepair_Grid_InitializeLayout
        /// <summary>
        /// �O���b�h�T�ϐݒ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendRepair_Grid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            // �O���b�h�̃J��������ݒ肵�܂��B
            this.SettingGridColumn(layout.Bands[0].Columns);

            layout.ScrollBounds = ScrollBounds.ScrollToFill;
            layout.ScrollStyle = ScrollStyle.Immediate;
            layout.Override.AllowAddNew = AllowAddNew.No;
            layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            layout.Override.AllowColMoving = AllowColMoving.NotAllowed;
            layout.UseFixedHeaders = false;
            // �w�b�_�[�̊O�ϐݒ�
            layout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            layout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            layout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            layout.Override.HeaderAppearance.ForeColor = System.Drawing.Color.White;
            layout.Override.HeaderAppearance.FontData.Name = "�l�r �S�V�b�N";
            layout.Override.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
            layout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            // 1�s�����̊O�ϐݒ�
            layout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
            // �s�Z���N�^�[�̐ݒ�
            layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            layout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            layout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            layout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            // �s�I��ݒ� �s�I�𖳂����[�h(�A�N�e�B�u�̂�)
            layout.Override.SelectTypeCell = SelectType.Single;
            layout.Override.SelectTypeCol = SelectType.SingleAutoDrag;
            // �I���s�̊O�ϐݒ�
            layout.Override.SelectedRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            layout.Override.SelectedRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            layout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            layout.Override.SelectedRowAppearance.ForeColor = System.Drawing.Color.Black;
            layout.Override.SelectedRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            layout.Override.SelectedRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);
            // �A�N�e�B�u�s�̊O�ϐݒ�
            layout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            layout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            layout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            layout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.Black;
            layout.Override.ActiveRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            layout.Override.ActiveRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);
            // �s�t�B���^�[�̐ݒ�
            layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // ��̎�������
            layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            // ��̓��֕s��
            layout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            // ��̃\�[�g�s��
            layout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;
            layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
        }
        #endregion

        #region Grid_KeyPress
        /// <summary>
        /// Grid_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendRepair_Grid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.AttendRepair_Grid.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.AttendRepair_Grid.ActiveCell;

                switch (cell.Column.Key)
                {
                    case COL_REPAIRPRICE:
                        if (this.AttendRepair_Grid.ActiveCell.Activation == Activation.AllowEdit && this.AttendRepair_Grid.ActiveCell.IsInEditMode)
                        {
                            if (!KeyPressCheck(9, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                            {
                                e.Handled = true;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region �s�ǉ��A�폜
        /// <summary>
        /// �s�ǉ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRow_ultraButton_Click(object sender, EventArgs e)
        {
            DataRow row = this._repairTable.NewRow();

            StringBuilder cndString = new StringBuilder();
            cndString.Append(String.Format("{0}={1} AND {2}=MAX({3})", COL_DEL, 0, COL_SORTNO, COL_SORTNO));

            DataRow[] rows = this._repairTable.Select(cndString.ToString());
            if (rows.Length > 0)
            {
                row[COL_SORTNO] = (int)rows[0][COL_SORTNO] + 1;
            }
            else
            {
                row[COL_SORTNO] = 1;
            }
            this._repairTable.Rows.Add(row);

            this.AttendRepair_Grid.Focus();
            UltraGridRow ugRow = this.AttendRepair_Grid.GetRow(ChildRow.Last);
            if (ugRow != null)
            {
                ugRow.Cells[COL_REPAIRNAME].Activate();
                ugRow.Cells[COL_REPAIRNAME].Selected = true;
                this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode);
            }

            this.UpDateGrid();
        }

        /// <summary>
        /// �s�폜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelRow_Button_Click(object sender, EventArgs e)
        {
            if (this.AttendRepair_Grid.Selected.Rows.Count > 0)
            {
                DialogResult ret = TMsgDisp.Show(
                       this,							                        // �e�E�B���h�E�t�H�[��
                       emErrorLevel.ERR_LEVEL_INFO,	                            // �G���[���x��
                       CT_ASSEMBLYID,					                        // �A�Z���u��ID�܂��̓N���XID
                       "�I���s���폜���܂����H",                                // �\�����郁�b�Z�[�W 
                       0,								                        // �X�e�[�^�X�l
                       MessageBoxButtons.OK);

                if (ret == DialogResult.OK)
                {
                    foreach (UltraGridRow row in this.AttendRepair_Grid.Selected.Rows)
                    {
                        // �ۑ��ύs
                        row.Cells[COL_DEL].Value = 1;
                    }
                }
                this._repairTable.AcceptChanges();
                this.UpDateGrid();
            }
            else if (this.AttendRepair_Grid.ActiveRow != null)
            {
                DialogResult ret = TMsgDisp.Show(
                       this,							                        // �e�E�B���h�E�t�H�[��
                       emErrorLevel.ERR_LEVEL_INFO,	                            // �G���[���x��
                       CT_ASSEMBLYID,					                        // �A�Z���u��ID�܂��̓N���XID
                       "�I���s���폜���܂����H",                                // �\�����郁�b�Z�[�W 
                       0,								                        // �X�e�[�^�X�l
                       MessageBoxButtons.OK);

                 if (ret == DialogResult.OK)
                {
                   this.AttendRepair_Grid.ActiveRow.Cells[COL_DEL].Value = 1;
                }
                this._repairTable.AcceptChanges();
                this.UpDateGrid();
            }
            else if (this.AttendRepair_Grid.ActiveCell != null)
            {
                DialogResult ret = TMsgDisp.Show(
                       this,							                        // �e�E�B���h�E�t�H�[��
                       emErrorLevel.ERR_LEVEL_INFO,	                            // �G���[���x��
                       CT_ASSEMBLYID,					                        // �A�Z���u��ID�܂��̓N���XID
                       "�I���s���폜���܂����H",                                // �\�����郁�b�Z�[�W 
                       0,								                        // �X�e�[�^�X�l
                       MessageBoxButtons.OK);

                if (ret == DialogResult.OK)
                {
                    this.AttendRepair_Grid.ActiveCell.Row.Cells[COL_DEL].Value = 1;
                }
                this._repairTable.AcceptChanges();
                this.UpDateGrid();
            }
        }
        #endregion

        #region �ۑ��A�I��
        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            // �ۑ�����
            this.SaveProc();
        }

        /// <summary>
        /// ����{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// �t�H�[���N���[�W���O
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendRepairSetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // �X�V�m�F
            if (CheckUpdate())
            {
                DialogResult ret = TMsgDisp.Show(
                       this,							                        // �e�E�B���h�E�t�H�[��
                       emErrorLevel.ERR_LEVEL_INFO,	                            // �G���[���x��
                       CT_ASSEMBLYID,					                        // �A�Z���u��ID�܂��̓N���XID
                       "���ݕҏW���̃f�[�^�����݂��܂��B"                       // �\�����郁�b�Z�[�W 
                       + Environment.NewLine + "�o�^���Ă���낵���ł����H",
                       0,								                        // �X�e�[�^�X�l
                       MessageBoxButtons.YesNoCancel);

                if (ret == DialogResult.Yes)
                {
                    // �ۑ�����
                    int st = this.SaveProc();
                    if (st != 0)
                    {
                        // �ۑ����s
                        e.Cancel = true;
                        return;
                    }
                }
                else if (ret == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
        #endregion

        #region Grid�C���M�����[����
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendRepair_Grid_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.AttendRepair_Grid.ActiveCell != null)
            {
                CellDataErrorProc();
                e.RaiseErrorEvent = false;			// �G���[�C�x���g�͔��������Ȃ�
                e.RestoreOriginalValue = false;		// �Z���̒l�����ɖ߂��Ȃ�
                e.StayInEditMode = false;			// �ҏW���[�h�͔�����
            }
        }

        /// <summary>
        /// �Z���X�V�G������������
        /// </summary>
        private void CellDataErrorProc()
        {
            // ���l���ڂ̏ꍇ
            if ((this.AttendRepair_Grid.ActiveCell.Column.DataType == typeof(Int32)) ||
                (this.AttendRepair_Grid.ActiveCell.Column.DataType == typeof(Int64)) ||
                (this.AttendRepair_Grid.ActiveCell.Column.DataType == typeof(double)))
            {
                Infragistics.Win.EmbeddableEditorBase editorBase = this.AttendRepair_Grid.ActiveCell.EditorResolved;

                // �����͂�0�ɂ���
                if (editorBase.CurrentEditText.Trim() == "")
                {
                    editorBase.Value = 0;				// 0���Z�b�g
                    this.AttendRepair_Grid.ActiveCell.Value = 0;
                }
                // ���l���ڂɁu-�vor�u.�v�������������ĂȂ�������ʖڂł�
                else if ((editorBase.CurrentEditText.Trim() == "-") ||
                    (editorBase.CurrentEditText.Trim() == ".") ||
                    (editorBase.CurrentEditText.Trim() == "-."))
                {
                    editorBase.Value = 0;				// 0���Z�b�g
                    this.AttendRepair_Grid.ActiveCell.Value = 0;
                }
                // �ʏ����
                else
                {
                    try
                    {
                        editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.AttendRepair_Grid.ActiveCell.Column.DataType);
                        this.AttendRepair_Grid.ActiveCell.Value = editorBase.Value;
                    }
                    catch
                    {
                        editorBase.Value = 0;
                        this.AttendRepair_Grid.ActiveCell.Value = 0;
                    }
                }
            }
        }


        /// <summary>
        /// AttendRepair_Grid_CellChange
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendRepair_Grid_CellChange(object sender, CellEventArgs e)
        {
            // ���݂̃A�N�e�B�u�Z���̃X�^�C����Edit or Default �̏ꍇ
            if ((this.AttendRepair_Grid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
                (this.AttendRepair_Grid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default))
            {
                // �ύX���ꂽ���ʁAText���󔒂ƂȂ����ꍇ
                if ((this.AttendRepair_Grid.ActiveCell.Text == null) || ((this.AttendRepair_Grid.ActiveCell.Text != null) && (this.AttendRepair_Grid.ActiveCell.Text.Trim() == "")))
                {
                    // ���݂̃Z���̌^���AInt32�AInt64�Adouble�^�̏ꍇ
                    if ((this.AttendRepair_Grid.ActiveCell.Column.DataType == typeof(Int32)) ||
                        (this.AttendRepair_Grid.ActiveCell.Column.DataType == typeof(Int64)) ||
                        (this.AttendRepair_Grid.ActiveCell.Column.DataType == typeof(double)))
                    {
                        // �l���󔒂Ƃ͂����ɁA"0"���Z�b�g����
                        this.AttendRepair_Grid.ActiveCell.Value = 0;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// AttendRepair_Grid_AfterPerformAction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendRepair_Grid_AfterPerformAction(object sender, AfterUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case UltraGridAction.AboveCell:
                case UltraGridAction.BelowCell:
                case UltraGridAction.NextCellByTab:
                case UltraGridAction.PrevCell:
                case UltraGridAction.PrevCellByTab:
                case UltraGridAction.NextCell:
                case UltraGridAction.PageUpCell:
                case UltraGridAction.PageDownCell:
                    //�A�N�e�B�u�ȃZ�������݂��邩�H
                    if (this.AttendRepair_Grid.ActiveCell != null)
                    {
                        // �A�N�e�B�u�Z���̃X�^�C�����擾
                        switch (this.AttendRepair_Grid.ActiveCell.StyleResolved)
                        {
                            // �G�f�B�b�g�n�X�^�C��
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:

                                if (this.AttendRepair_Grid.ActiveCell.Column.CellActivation == Activation.AllowEdit)
                                {
                                    //�ҏW���[�h�ɂ���B
                                    if (this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode))
                                    {
                                        //�ҏW���[�h�ɂȂ��Ă���
                                        if (this.AttendRepair_Grid.ActiveCell.IsInEditMode)
                                        {
                                            // �S�I����Ԃɂ���B
                                            this.AttendRepair_Grid.ActiveCell.SelStart = 0;
                                            this.AttendRepair_Grid.ActiveCell.SelLength = this.AttendRepair_Grid.ActiveCell.Text.Length;
                                        }
                                    }
                                }
                                break;
                            default:
                                // �G�f�B�b�g�n�ȊO�̃X�^�C���ł���΁A�ҏW��Ԃɂ���B
                                this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                break;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// AttendRepair_Grid_AfterEnterEditMode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendRepair_Grid_AfterEnterEditMode(object sender, EventArgs e)
        {
            // �ҏW���[�h�ɂȂ�����I�����
            this.AttendRepair_Grid.ActiveCell.SelectAll();
        }

        #endregion

        /// <summary>
        /// tRetKeyControl1_ChangeFocus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if ((e.PrevCtrl == null) || (e.NextCtrl == null))
                return;

            //�L�[����         
            switch (e.PrevCtrl.Name)
            {
                case "AttendRepair_Grid":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = null;
                                   
                                        if (e.ShiftKey)
                                        {
                                            // �ŏ��̃Z��
                                            if (this.AttendRepair_Grid.ActiveCell != null && this.AttendRepair_Grid.ActiveCell.Column.Key == COL_REPAIRNAME)
                                            {
                                                if (this.AttendRepair_Grid.ActiveCell.Row.HasPrevSibling())
                                                {
                                                    UltraGridRow prevRow = this.AttendRepair_Grid.ActiveCell.Row.GetSibling(SiblingRow.Previous);
                                                    UltraGridCell prevCel = null;

                                                    prevCel = prevRow.Cells[COL_REPAIRPRICE];

                                                    if (prevCel != null)
                                                    {
                                                        prevCel.Activate();
                                                        prevCel.Selected = true;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                this.AttendRepair_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                            }
                                        }
                                        else
                                        {
                                            // �ŏI�Z��
                                            if (this.AttendRepair_Grid.ActiveCell != null && this.AttendRepair_Grid.ActiveCell.Column.Key == COL_REPAIRPRICE)
                                            {
                                                if (this.AttendRepair_Grid.ActiveCell.Row.HasNextSibling())
                                                {
                                                    UltraGridRow nextRow = this.AttendRepair_Grid.ActiveCell.Row.GetSibling(SiblingRow.Next);
                                                    UltraGridCell nextCel = nextRow.Cells[COL_REPAIRNAME];
                                                    if (nextCel != null)
                                                    {
                                                        nextCel.Activate();
                                                        this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                this.AttendRepair_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                            }
                                        }
                                        break;
                                    }
                            }
                            break;
                    }
            }
        }
        #endregion

        /// <summary>
        /// AttendRepair_Grid_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendRepair_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.AttendRepair_Grid.ActiveCell != null)
            {
                // �A�N�e�B�u�Z��
                UltraGridCell activeCell = this.AttendRepair_Grid.ActiveCell;

                switch (e.KeyData)
                {
                    // ���L�[
                    case Keys.Left:
                        if(activeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                        {
                            if (activeCell.IsInEditMode && activeCell.SelStart == 0)
                            {
                                this.AttendRepair_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                e.Handled = true;
                            }
                            else if (!activeCell.IsInEditMode)
                            {
                                this.AttendRepair_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            this.AttendRepair_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                        }
                        break;
                    // ���L�[
                    case Keys.Right:
                        if (activeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                        {
                            if (activeCell.IsInEditMode && (activeCell.SelStart >= activeCell.Text.Length))
                            {
                                this.AttendRepair_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                e.Handled = true;
                            }
                            else if (!activeCell.IsInEditMode)
                            {
                                this.AttendRepair_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            this.AttendRepair_Grid.PerformAction(UltraGridAction.NextCellByTab);
                        }
                        //e.Handled = true;
                        break;
                    // ���L�[
                    case Keys.Up:
                        if (activeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                        {
                            if (activeCell.Row.HasPrevSibling())
                            {
                                UltraGridRow prevRow = activeCell.Row.GetSibling(SiblingRow.Previous);
                                UltraGridCell prevCel = prevRow.Cells[activeCell.Column.Key];
                                if (prevCel != null)
                                {
                                    prevCel.Activate();
                                    prevCel.Selected = true;
                                    if (prevCel.Activation == Activation.AllowEdit)
                                    {
                                        this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                            }
                            else
                            {
                                this.AddRow_ultraButton.Focus();
                            }
                        }
                        else if (activeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                        {
                            if (activeCell.DroppedDown)
                            {
                                return;
                            }
                            else
                            {
                                if (activeCell.Row.HasPrevSibling())
                                {
                                    UltraGridRow prevRow = activeCell.Row.GetSibling(SiblingRow.Previous);
                                    UltraGridCell prevCel = prevRow.Cells[activeCell.Column.Key];
                                    if (prevCel != null)
                                    {
                                        prevCel.Activate();
                                        prevCel.Selected = true;
                                        if (prevCel.Activation == Activation.AllowEdit)
                                        {
                                            this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                    }
                                }
                                else
                                {
                                    this.AddRow_ultraButton.Focus();
                                }
                            }
                        }
                     
                        e.Handled = true;
                        break;
                    // ���L�[
                    case Keys.Down:
                        if (activeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                        {
                            if (activeCell.Row.HasNextSibling())
                            {
                                UltraGridRow belowRow = activeCell.Row.GetSibling(SiblingRow.Next);
                                UltraGridCell belowCel = belowRow.Cells[activeCell.Column.Key];

                                if (belowCel != null)
                                {
                                    belowCel.Activate();
                                    belowCel.Selected = true;
                                    if (belowCel.Activation == Activation.AllowEdit)
                                    {
                                        this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                            }
                            else
                            {
                                this.Save_Button.Focus();
                            }
                        }
                        else if (activeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                        {
                            if (activeCell.DroppedDown)
                            {
                                return;
                            }
                            else if (activeCell.Row.HasNextSibling())
                            {
                                UltraGridRow belowRow = activeCell.Row.GetSibling(SiblingRow.Next);
                                UltraGridCell belowCel = belowRow.Cells[activeCell.Column.Key];

                                if (belowCel != null)
                                {
                                    belowCel.Activate();
                                    belowCel.Selected = true;
                                    if (belowCel.Activation == Activation.AllowEdit)
                                    {
                                        this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                            }
                            else
                            {
                                this.Save_Button.Focus();
                            }
                        }
                        e.Handled = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Grid_Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendRepair_Grid_Enter(object sender, EventArgs e)
        {
            if (this.AttendRepair_Grid.ActiveCell != null)
            {
                this.AttendRepair_Grid.ActiveCell.Selected = true;
                this.AttendRepair_Grid.ActiveCell.Activate();
                this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode);
            }
            else
            {
                if (this.AttendRepair_Grid.Rows.Count > 0)
                {
                    this.AttendRepair_Grid.Rows[0].Cells[COL_REPAIRNAME].Selected = true;
                    this.AttendRepair_Grid.Rows[0].Cells[COL_REPAIRNAME].Activate();
                    this.AttendRepair_Grid.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
        }   
    }
}