using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using System.IO;
using System.Drawing.Imaging;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �摜�o�^���
    /// </summary>
    public partial class GoodsImageForm : Form
    {
        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public GoodsImageForm()
        {
            InitializeComponent();
            this._imgTable = new DataTable();
            this._imgTable.CaseSensitive = true;
            this._TBOServiceACS = new TBOServiceACS();
            this._goodsImageDic = new Dictionary<long, List<GoodsImage>>();
            this._saveDiv = false;
            this._imageNameChange = false;
            this._imageList = new ImageList();
            this._imageList.Images.Add(Properties.Resources._28_STAR1);
            this._imageList.TransparentColor = Color.Cyan;
            this._dataReadFlag = false;
        }
        #endregion

        #region �����o

        /// <summary>�f�[�^�e�[�u��</summary>
        private DataTable _imgTable;
        /// <summary>TOB�A�N�Z�X�N���X</summary>
        private TBOServiceACS _TBOServiceACS;
        /// <summary>�t�������f�B�N�V���i���[</summary>
        private Dictionary<long, List<GoodsImage>> _goodsImageDic;
        /// <summary>�摜���̕ύX�t���O</summary>
        private bool _imageNameChange;
        /// <summary>�C���[�W���X�g</summary>
        private ImageList _imageList;

        /// <summary>��ƃR�[�h</summary>
        public string _enterPriseCode;
        /// <summary>�N�����[�h(0:�}�X�����A1:�K�C�h���[�h)</summary>
        public int _mode;
        /// <summary>���i�J�e�S�����X�g</summary>
        public List<GoodsCategory> _goodsCategoryList;
        /// <summary>�I�𒆃J�e�S��ID</summary>
        public long _goodsCategoryId;
        /// <summary>�f�[�^�Ǎ��ς݃t���O</summary>
        public bool _dataReadFlag;
        /// <summary>�ۑ��ς݃t���O</summary>
        public bool _saveDiv;

        // �K�C�h���[�h
        /// <summary>�I���C���[�WID</summary>
        public long _imageID;
        /// <summary>�I�����i�摜</summary>
        public Image _goodsImage;

        #endregion

        #region const
        private const string COL_DEL = "�폜";
        private const string COL_ID = "ID";
        private const string COL_NAME = "����";
        private const string COL_IMAGE = "�摜";
        private const string COL_IMAGE_CHANGE = "�摜�ύX�敪";
        private const string COL_GUIDE = "�K�C�h";
        private const string COL_DATA = "�f�[�^";
        private const string CT_ASSEMBLYID = "SFMIT10201U";
        #endregion

        #region Public
        /// <summary>
        /// ���i�摜�ݒ��ʋN��
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowGoodsImageFrom()
        {
            if (this._mode == 0)
            {
                // �}�X����
                this.Text = "���i�摜�ݒ�";
                this.ToolBar_panel.Visible = false;
                this.Category_label.Text = "���i�J�e�S��";
                this.Category_ComboEditor.Visible = true;
                this.tool_panel.Visible = true;
                this.Buttom_panel.Visible = true;

                // �R���{�쐬
                this.Category_ComboEditor.ValueChanged -= new EventHandler(this.Category_ComboEditor_ValueChanged);
                foreach (GoodsCategory goodsCategory in _goodsCategoryList)
                {
                    this.Category_ComboEditor.Items.Add(goodsCategory.GoodsCategoryId, goodsCategory.GoodsCategoryName);
                }
                this.Category_ComboEditor.SelectedIndex = 0;
                // �^�C���������I��
                this._goodsCategoryId = (long)this.Category_ComboEditor.Value;
                this.Category_ComboEditor.ValueChanged += new EventHandler(this.Category_ComboEditor_ValueChanged);

            }
            else
            {
                // �K�C�h
                this.Search_panel.Visible = true;
                this.Text = "���i�摜�K�C�h";
                this.ToolBar_panel.Visible = true;
                this.Category_label.Text = "���i�摜��I�����ĉ�����";
                this.Category_ComboEditor.Visible = false;
                this.tool_panel.Visible = false;
                this.Buttom_panel.Visible = false;
                this.Annotation_panel.Visible = false;
                this.ImageName_TextBox.Text = "";
                this.GoodsImage_Grid.DoubleClickRow += new DoubleClickRowEventHandler(GoodsImage_Grid_DoubleClickRow);
            }

            int st = 0;

            //�s���s���\��
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "���o��";
            form.Message = "���݁A�摜�f�[�^�𒊏o���ł��B";


            // �摜�f�[�^�擾
            try
            {
                this.Cursor = Cursors.WaitCursor;
                form.Show();

                if ((this._mode == 0) || (this._dataReadFlag == true))
                {
                    // ������
                    this._goodsImageDic = new Dictionary<long, List<GoodsImage>>();
                    st = this.SearchGoodsImage();
                    if (st == 0)
                    {
                        this._dataReadFlag = false;
                    }
                }
            }
            finally
            {
                // �_�C�A���O�����
                form.Close();
                this.Cursor = Cursors.Default;
                System.Windows.Forms.Application.DoEvents();
            }

            if (st != 0)
            {
                this.DialogResult = DialogResult.Cancel;
                return this.DialogResult;
            }

            // �e�[�u���쐬
            this.MakeGoodsImageTable();
            // �f�[�^�Z�b�g
            this.SetDataTable();

            // �N��
            return this.ShowDialog();
        }

        #endregion

        #region Private

        #region  ���i�摜�e�[�u���쐬
        /// <summary>
        /// ���i�摜�e�[�u���쐬
        /// </summary>
        private void MakeGoodsImageTable()
        {
            this._imgTable = new DataTable();
            this._imgTable.Columns.Add(COL_DEL, typeof(int));
            this._imgTable.Columns.Add(COL_ID, typeof(long));
            this._imgTable.Columns.Add(COL_NAME, typeof(string));
            this._imgTable.Columns.Add(COL_IMAGE, typeof(Image));
            this._imgTable.Columns.Add(COL_IMAGE_CHANGE, typeof(int));
            this._imgTable.Columns.Add(COL_GUIDE, typeof(object));
            this._imgTable.Columns.Add(COL_DATA, typeof(object));
            this._imgTable.Columns[COL_DEL].DefaultValue = 0;
            this._imgTable.Columns[COL_NAME].DefaultValue = "";
            this._imgTable.Columns[COL_ID].DefaultValue = 0;
            this._imgTable.Columns[COL_IMAGE_CHANGE].DefaultValue = 0;
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
            for (int i = 0; i < this.GoodsImage_Grid.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                this.GoodsImage_Grid.DisplayLayout.Bands[0].Columns[i].Hidden = true;
            }

            // ����
            cols[COL_NAME].Hidden = false;
            cols[COL_NAME].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            if (this._mode == 0)
            {
                cols[COL_NAME].CellActivation = Activation.AllowEdit;
            }
            else
            {
                cols[COL_NAME].CellActivation = Activation.NoEdit;
            }
            cols[COL_NAME].MaxLength = 256;
            cols[COL_NAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            cols[COL_NAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            cols[COL_NAME].CellDisplayStyle = CellDisplayStyle.PlainText;

            cols[COL_NAME].Width = 190;

            //// �}�X����
            if (this._mode == 0)
            {
                cols[COL_NAME].Width = 170;
            }

            // �摜
            cols[COL_IMAGE].Hidden = false;
            cols[COL_IMAGE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image;
            cols[COL_IMAGE].CellActivation = Activation.NoEdit;
            cols[COL_IMAGE].TabStop = false;
            

            // �摜�}�X����
            if (this._mode == 0)
            {
                cols[COL_GUIDE].Hidden = false;
                cols[COL_GUIDE].Header.Caption = "";
                cols[COL_GUIDE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                cols[COL_GUIDE].CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                cols[COL_GUIDE].CellButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                cols[COL_GUIDE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
                cols[COL_GUIDE].CellButtonAppearance.Image = this._imageList.Images[0];
                cols[COL_GUIDE].Width = 15;
            }
        }
        #endregion

        #region ���i�摜�f�[�^�擾
        /// <summary>
        /// ���i�摜�f�[�^�擾����
        /// </summary>
        /// <returns></returns>
        private int SearchGoodsImage()
        {
            List<GoodsImage> goodsImageList = new List<GoodsImage>();
            string errMsg = "";
            int st = this._TBOServiceACS.GetGoodsImageIdList(this._enterPriseCode, out goodsImageList, out errMsg);
            if (st == 0)
            {
                // �摜��1�����擾����
                foreach (GoodsImage goodsImage in goodsImageList)
                {
                    long imgId = goodsImage.imageId;
                    GoodsImage wkgoodsImage = new GoodsImage();
                    st = this._TBOServiceACS.GetGoodsImage(this._enterPriseCode, imgId, out wkgoodsImage, out errMsg);

                    if (st == 0)
                    {
                        if (this._goodsImageDic.ContainsKey(wkgoodsImage.goodsCategoryId))
                        {
                            this._goodsImageDic[wkgoodsImage.goodsCategoryId].Add(wkgoodsImage);
                        }
                        else
                        {
                            List<GoodsImage> wkList = new List<GoodsImage>();
                            wkList.Add(wkgoodsImage);
                            this._goodsImageDic.Add(wkgoodsImage.goodsCategoryId, wkList);
                        }
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,							                // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	            // �G���[���x��
                        CT_ASSEMBLYID,					                // �A�Z���u��ID�܂��̓N���XID
                        errMsg,	                                    // �\�����郁�b�Z�[�W 
                        st,								            // �X�e�[�^�X�l
                        MessageBoxButtons.OK);
                        return st;
                    }
                }

                // �\�[�g
                this.SortGoodsImageDic();
            }
            else
            {
                TMsgDisp.Show(
                     this,							                // �e�E�B���h�E�t�H�[��
                     emErrorLevel.ERR_LEVEL_STOPDISP,	            // �G���[���x��
                     CT_ASSEMBLYID,					                // �A�Z���u��ID�܂��̓N���XID
                     errMsg,	                                    // �\�����郁�b�Z�[�W 
                     st,								            // �X�e�[�^�X�l
                     MessageBoxButtons.OK);
            }
            return st;
        }
        #endregion

        #region �擾�f�[�^�˃e�[�u���Z�b�g
        /// <summary>
        /// �擾�f�[�^���e�[�u���ɃZ�b�g
        /// </summary>
        private void SetDataTable()
        {
            this._imgTable.Rows.Clear();

            if (this._goodsImageDic.ContainsKey(this._goodsCategoryId))
            {
                foreach (GoodsImage goodsImage in this._goodsImageDic[this._goodsCategoryId])
                {
                    DataRow row = this._imgTable.NewRow();
                    row[COL_DEL] = goodsImage.logicalDelDiv;
                    row[COL_DATA] = goodsImage;
                    row[COL_ID] = goodsImage.imageId;
                    row[COL_NAME] = goodsImage.imageKeyword;
                    row[COL_IMAGE] = goodsImage.imageData_Image;
                    this._imgTable.Rows.Add(row);
                }
            }

            DataView view = this._imgTable.DefaultView;
            // �t�B���^�[
            StringBuilder filter = new StringBuilder();
            filter.Append(String.Format("{0}={1}", COL_DEL, 0));
            view.RowFilter = filter.ToString();
            this.GoodsImage_Grid.DataSource = view;
        }
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
            GoodsImage[] saveArray = new GoodsImage[0];
            this.MakeSaveData(ref saveArray);

            // �ۑ��Ώۃf�[�^���Ȃ���Ώ������f
            if (saveArray == null || saveArray.Length == 0)
            {
                return 0;
            }

            // �摜������̂�1�����Ón��
            foreach (GoodsImage goodsImage in saveArray)
            {
                GoodsImage wkGoodImage = goodsImage;
                int mode = this.GetMode(goodsImage);
                // �ۑ����s
                st = this._TBOServiceACS.SaveGoodsImage(mode, ref wkGoodImage, out errMsg);

                if (st == 0)
                {
                    if (mode == 3)
                    {
                        // �폜
                        if (this._goodsImageDic.ContainsKey(wkGoodImage.goodsCategoryId))
                        {
                            GoodsImage target = this._goodsImageDic[wkGoodImage.goodsCategoryId].Find(
                               delegate(GoodsImage wkGoodsImage)
                               {
                                   if (wkGoodsImage.imageId == wkGoodImage.imageId)
                                       return true;
                                   else
                                       return false;
                               }
                            );
                            if (target != null)
                            {
                                this._goodsImageDic[goodsImage.goodsCategoryId].Remove(target);
                            }
                        }
                    }
                    else
                    {
                        // �V�K�X�V

                        // Dic�ŐV��
                        if (this._goodsImageDic.ContainsKey(wkGoodImage.goodsCategoryId))
                        {
                            GoodsImage target = this._goodsImageDic[wkGoodImage.goodsCategoryId].Find(
                                delegate(GoodsImage wkGoodsImage)
                                {
                                    if (wkGoodsImage.imageId == wkGoodImage.imageId)
                                        return true;
                                    else
                                        return false;
                                }
                             );

                            if (target == null)
                            {
                                this._goodsImageDic[goodsImage.goodsCategoryId].Add(wkGoodImage);
                            }
                            else
                            {
                                this._goodsImageDic[goodsImage.goodsCategoryId].Remove(target);
                                this._goodsImageDic[goodsImage.goodsCategoryId].Add(wkGoodImage);
                            }
                        }
                        else
                        {
                            List<GoodsImage> list = new List<GoodsImage>();
                            list.Add(wkGoodImage);
                            this._goodsImageDic.Add(wkGoodImage.goodsCategoryId, list);
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(errMsg))
                    {
                        errMsg = "���i�摜�̓o�^�Ɏ��s���܂����B";
                    }

                    TMsgDisp.Show(
                        this,							    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                        CT_ASSEMBLYID,					    // �A�Z���u��ID�܂��̓N���XID
                        errMsg,	                            // �\�����郁�b�Z�[�W 
                        st,								    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);
                    return st;
                }
            }

            if (st == 0)
            {
                TMsgDisp.Show(
                      this,								// �e�E�B���h�E�t�H�[��
                      emErrorLevel.ERR_LEVEL_INFO,	    // �G���[���x��
                      CT_ASSEMBLYID,					// �A�Z���u��ID�܂��̓N���XID
                      "�ۑ����܂����B",			        // �\�����郁�b�Z�[�W 
                      0,								// �X�e�[�^�X�l
                      MessageBoxButtons.OK);
            }

            this._saveDiv = true;

            // �\�[�g����
            this.SortGoodsImageDic();

            // �e�[�u���č\�z
            this.SetDataTable();

            return st;
        }
        #endregion

        #region �ۑ��f�[�^�쐬

        /// <summary>
        /// �ۑ��Ώۃf�[�^�쐬
        /// </summary>
        /// <param name="saveArray"></param>
        private void MakeSaveData(ref GoodsImage[] saveArray)
        {
            // �`���~
            this.GoodsImage_Grid.BeginUpdate();

            // ��U�t�B���^�[������
            this._imgTable.DefaultView.RowFilter = "";

            // ���ۑ��̍폜�f�[�^���e�[�u������폜
            StringBuilder cndString = new StringBuilder();
            cndString.Append(String.Format("{0}={1} AND {2} is {3}", COL_DEL, 1, COL_DATA, "null"));

            DataRow[] delRows = this._imgTable.Select(cndString.ToString());
            foreach (DataRow delRow in delRows)
            {
                delRow.Delete();
            }
            this._imgTable.AcceptChanges();

            List<GoodsImage> retList = new List<GoodsImage>();
            for (int i = 0; i < this._imgTable.DefaultView.Count; i++)
            {
                GoodsImage saveDate = new GoodsImage();
                if (this._imgTable.DefaultView[i].Row[COL_DATA] != DBNull.Value)
                {
                    // �X�V����ĂȂ��s�͑ΏۊO
                    if (IsChengeRow(this._imgTable.DefaultView[i].Row))
                    {
                        saveDate = ((GoodsImage)this._imgTable.DefaultView[i].Row[COL_DATA]).Clone();
                        saveDate.imageKeyword = this._imgTable.DefaultView[i].Row[COL_NAME].ToString();
                        saveDate.imageData_Image = (Image)this._imgTable.DefaultView[i].Row[COL_IMAGE];
                        saveDate.logicalDelDiv = (int)this._imgTable.DefaultView[i].Row[COL_DEL];
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    // �V�K�s
                    saveDate.imageKeyword = this._imgTable.DefaultView[i].Row[COL_NAME].ToString();
                    saveDate.enterpriseCode = this._enterPriseCode;
                    saveDate.goodsCategoryId = this._goodsCategoryId;
                    saveDate.uuid = "";
                    saveDate.imageData_Image = (Image)this._imgTable.DefaultView[i].Row[COL_IMAGE];
                }
                retList.Add(saveDate);
            }
            saveArray = retList.ToArray();

            // �ēx�t�B���^�[�Z�b�g
            StringBuilder filter = new StringBuilder();
            filter.Append(String.Format("{0}={1}", COL_DEL, 0));
            this._imgTable.DefaultView.RowFilter = filter.ToString();

            // �`��J�n
            this.GoodsImage_Grid.EndUpdate();
            this.UpDateGrid();
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

                this.GoodsImage_Grid.ActiveCell = this.GoodsImage_Grid.Rows[rowIndex].Cells[columnNm];
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
            for (int ix = 0; ix < this.GoodsImage_Grid.Rows.Count; ix++)
            {
                UltraGridRow ugRow = this.GoodsImage_Grid.Rows[ix];

                // �����̓`�F�b�N  �摜
                if (ugRow.Cells[COL_IMAGE].Value == DBNull.Value)
                {
                    rowIndex = ix;
                    errMsg = "�摜��ݒ肵�ĉ�����";
                    columnNm = COL_IMAGE;
                    return false;
                }
            }
            return result;
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
            this._imgTable.AcceptChanges();

            // �f�[�^���e��r
            for (int i = 0; i < this._imgTable.Rows.Count; i++)
            {
                DataRow row = this._imgTable.Rows[i];
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
                        GoodsImage image = (GoodsImage)row[COL_DATA];

                        // ����
                        if (!image.imageKeyword.Equals(row[COL_NAME].ToString()))
                        {
                            return true;
                        }
                        // �摜
                        if ((int)row[COL_IMAGE_CHANGE] == 1)
                        {
                            return true;
                        }
                    }
                }
            }
            return ret;
        }


        /// <summary>
        /// �X�V�`�F�b�N(�s�P��)
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        private bool IsChengeRow(DataRow dataRow)
        {
            bool ret = false;
            // �폜����Ă���
            if ((int)dataRow[COL_DEL] == 1)
            {
                return true;
            }

            // �摜���ύX����Ă���
            if ((int)dataRow[COL_IMAGE_CHANGE] == 1)
            {
                return true;
            }

            // ���̂��ύX����Ă���
            if (!dataRow[COL_NAME].ToString().Equals(((GoodsImage)dataRow[COL_DATA]).imageKeyword))
            {
                return true;
            }
            return ret;
        }
        #endregion

        #region �O���b�h�A�b�v�f�[�g����
        /// <summary>
        /// �O���b�h�A�b�v�f�[�g����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�b�v�f�[�g�������s���܂��B</br>
        /// </remarks>
        private void UpDateGrid()
        {
            this.GoodsImage_Grid.UpdateData();
            this.GoodsImage_Grid.Refresh();
        }
        #endregion

        #region �r�W�l�X���W�b�N

        #region �\�[�g
        /// <summary>
        /// �\�[�g����
        /// </summary>
        private void SortGoodsImageDic()
        {
            if (this._goodsImageDic.ContainsKey(this._goodsCategoryId))
            {
                this._goodsImageDic[this._goodsCategoryId].Sort(delegate(GoodsImage obj1, GoodsImage obj2)
                {
                    // �C���[�WID��
                    return obj1.imageId.CompareTo(obj2.imageId);
                });
            }
        }
        #endregion

        #region �t�B���^�[
        /// <summary>
        /// �t�B���^�[����
        /// </summary>
        private void MakeFilter()
        {
            string filter = "";
            StringBuilder cndString = new StringBuilder();
            if (!string.IsNullOrEmpty(this.ImageName_TextBox.Text))
            {
                cndString.Append(String.Format("{0} Like '%{1}%'", COL_NAME, this.ImageName_TextBox.Text));
                filter = cndString.ToString();
            }
            this._imgTable.DefaultView.RowFilter = filter;
            this.GoodsImage_Grid.Refresh();
            this.GoodsImage_Grid.Update();
        }
        #endregion

        #region �X�V���[�h�擾
        /// <summary>
        /// �X�V���[�h�擾����
        /// </summary>
        /// <param name="goodsImage"></param>
        /// <returns></returns>
        private int GetMode(GoodsImage goodsImage)
        {
            int mode = 1;
            if (goodsImage.insDtTime == 0)
            {
                // POST
                mode = 1;
            }
            else if (goodsImage.logicalDelDiv == 1)
            {
                //DELETE
                mode = 3;
            }
            else
            {
                //PUT
                mode = 2;
            }
            return mode;
        }
        #endregion

        #endregion

        #region �K�C�h�I�����ʃZ�b�g
        /// <summary>
        /// �I�����ʂ��Z�b�g
        /// </summary>
        private void SetResult()
        {
            if (this.GoodsImage_Grid.ActiveRow != null)
            {
                this._imageID = (long)this.GoodsImage_Grid.ActiveRow.Cells[COL_ID].Value;
                this._goodsImage = (Image)this.GoodsImage_Grid.ActiveRow.Cells[COL_IMAGE].Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region GridEvent

        #region InitializeLayout
        /// <summary>
        /// InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsImage_Grid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            // �O���b�h�̃J��������ݒ肵�܂��B
            this.SettingGridColumn(layout.Bands[0].Columns);

            layout.Override.DefaultRowHeight = 90;

            layout.ScrollBounds = ScrollBounds.ScrollToFill;
            layout.ScrollStyle = ScrollStyle.Immediate;
            layout.Override.AllowAddNew = AllowAddNew.No;
            layout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
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
            if (this._mode == 0)
            {
                layout.Override.SelectTypeCell = SelectType.Single;
            }
            else
            {
                layout.Override.SelectTypeCell = SelectType.None;

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

            }
            layout.Override.SelectTypeCol = SelectType.None;

            // �s�t�B���^�[�̐ݒ�
            layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // ��̎�������
            layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            // ��̓��֕s��
            layout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            // ��̃T�C�Y�ύX�s��
            layout.Override.AllowColSizing = AllowColSizing.None;
            // ��̃\�[�g�s��
            layout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;
            layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;

            //�s�T�C�Y�ύX�s��
            layout.Override.RowSizing = RowSizing.Fixed;


            if (this._mode == 0)
            {
                // �}�X�������[�h
                layout.Override.CellClickAction = CellClickAction.Default;
                if (this.GoodsImage_Grid.Rows.Count > 0)
                {
                    this.GoodsImage_Grid.Focus();
                    this.GoodsImage_Grid.Rows[0].Cells[COL_NAME].Selected = true;
                    this.GoodsImage_Grid.Rows[0].Cells[COL_NAME].Activated = true;
                    this.GoodsImage_Grid.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            else
            {
                // �K�C�h���[�h
                layout.Override.CellClickAction = CellClickAction.RowSelect;
                if (this.GoodsImage_Grid.Rows.Count > 0)
                {
                    this.GoodsImage_Grid.Rows[0].Selected = true;
                    this.GoodsImage_Grid.Rows[0].Activated = true;
                }
            }
        }
        #endregion

        #region KeyDown
        /// <summary>
        /// GoodsImage_Grid_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsImage_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            // �ҏW���ł������ꍇ
            if (this._mode == 0)
            {
                if (this.GoodsImage_Grid.ActiveCell != null)
                {
                    // �A�N�e�B�u�Z��
                    UltraGridCell activeCell = this.GoodsImage_Grid.ActiveCell;

                    switch (e.KeyData)
                    {
                        // ���L�[
                        case Keys.Left:
                            if (activeCell.IsInEditMode && activeCell.SelStart == 0)
                            {
                                this.GoodsImage_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                e.Handled = true;
                            }
                            else if (!activeCell.IsInEditMode)
                            {
                                this.GoodsImage_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                e.Handled = true;
                            }
                            break;
                        // ���L�[
                        case Keys.Right:
                            if (activeCell.IsInEditMode && (activeCell.SelStart >= activeCell.Text.Length))
                            {
                                this.GoodsImage_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                e.Handled = true;
                            }
                            else if (!activeCell.IsInEditMode)
                            {
                                this.GoodsImage_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                e.Handled = true;
                            }
                            break;
                        // ���L�[
                        case Keys.Up:
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
                                        this.GoodsImage_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                            }
                            else
                            {
                                this.AddRow_ultraButton.Focus();
                            }
                            e.Handled = true;
                            break;
                        // ���L�[
                        case Keys.Down:
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
                                        this.GoodsImage_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                            }
                            else
                            {
                                this.Save_Button.Focus();
                            }
                            e.Handled = true;
                            break;
                        case Keys.Space:
                            if (activeCell.Column.Key == COL_GUIDE)
                            {
                                this.GoodsImage_Grid_ClickCellButton(this.GoodsImage_Grid, new CellEventArgs(activeCell));
                            }
                            e.Handled = true;
                            break;
                    }
                }
            }
            else
            {
                if (this.GoodsImage_Grid.ActiveRow != null)
                {
                    // �A�N�e�B�u�Z��
                    UltraGridRow activeRow = this.GoodsImage_Grid.ActiveRow;

                    switch (e.KeyData)
                    {
                        // ���L�[
                        case Keys.Up:
                            if (activeRow.HasPrevSibling())
                            {
                                this.GoodsImage_Grid.PerformAction(UltraGridAction.AboveRow);
                            }
                            else
                            {
                                this.ImageName_TextBox.Focus();
                            }
                            e.Handled = true;
                            break;
                        // ���L�[
                        case Keys.Down:
                            if (activeRow.HasNextSibling())
                            {
                                this.GoodsImage_Grid.PerformAction(UltraGridAction.NextRow);
                            }
                            e.Handled = true;
                            break;
                    }
                }
            }
        }
        #endregion

        #region Enter
        /// <summary>
        /// GoodsImage_Grid_Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsImage_Grid_Enter(object sender, EventArgs e)
        {
            if (this._mode == 0)
            {
                if (this.GoodsImage_Grid.Rows.Count > 0)
                {
                    this.GoodsImage_Grid.Rows[0].Cells[COL_NAME].Selected = true;
                    this.GoodsImage_Grid.Rows[0].Cells[COL_NAME].Activated = true;
                    this.GoodsImage_Grid.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
        }
        #endregion

        #region DoubleClickRow
        /// <summary>
        /// �s�_�u���N���b�N(�K�C�h���̂�)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsImage_Grid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            this._imageID = (long)e.Row.Cells[COL_ID].Value;
            this._goodsImage = (Image)e.Row.Cells[COL_IMAGE].Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        #region ClickCellButton
        /// <summary>
        /// �摜�I���K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsImage_Grid_ClickCellButton(object sender, CellEventArgs e)
        {
            // �K�C�h�{�^���̏ꍇ
            if (e.Cell.Column.Key == COL_GUIDE)
            {
                // �_�C�A���O�̕\��
                OpenFileDialog openFileDialog = new OpenFileDialog();
                // ���݂��Ȃ��t�@�C���I�����̌x��
                openFileDialog.CheckFileExists = true;
                // �f�B���N�g���ύX��_�C�A���O�{�b�N�X�����Ƃ����ɖ߂�
                openFileDialog.RestoreDirectory = true;
                // �t�B���^
                openFileDialog.Filter =
                      "�摜�t�@�C��|*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;*.dib;*.tif;*.tiff;*.gif|" +
                      "PNG�t�@�C��(*.png)|*.png|" +
                      "JPG�t�@�C��(*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|" +
                      "BMP�t�@�C��(*.bmp;*.dib)|*.bmp;*.dib|" +
                      "TIF�t�@�C��(*.tif;*.tiff)|*.tif;*.tiff|" +
                      "GIF�t�@�C��(*.gif)|*.gif";
                      //"ICO�t�@�C��(*.gif)|*.ico"; ;
                // �����t�B���^�ʒu
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                // �t�@�C��Info�擾
                FileInfo info = new FileInfo(openFileDialog.FileName);

                if (info.Length > 204800)
                {
                    TMsgDisp.Show(
                       this,							                        // �e�E�B���h�E�t�H�[��
                       emErrorLevel.ERR_LEVEL_EXCLAMATION,	                    // �G���[���x��
                       CT_ASSEMBLYID,					                        // �A�Z���u��ID�܂��̓N���XID
                       "�摜�T�C�Y��200KB�𒴂��Ă���ׁA�捞�ł��܂���",       // �\�����郁�b�Z�[�W 
                       0,								                        // �X�e�[�^�X�l
                       MessageBoxButtons.OK);
                    return;
                }

                // �摜�ƃt�@�C���p�X���擾
                Image image = Image.FromFile(openFileDialog.FileName);

                string name = Path.GetFileNameWithoutExtension(info.Name);
                if (name.Length > 256)
                {
                    name = name.Substring(0, 256);
                }

                // �摜��ǉ�
                int index = this.GoodsImage_Grid.ActiveRow.Index;
                this.GoodsImage_Grid.Rows[index].Cells[COL_IMAGE].Value = image;
                this.GoodsImage_Grid.Rows[index].Cells[COL_NAME].Value = name;
                this.GoodsImage_Grid.Rows[index].Cells[COL_IMAGE_CHANGE].Value = 1;
            }
        }
        #endregion
        
        #endregion

        #region ���̑��C�x���g

        #region Button

        /// <summary>
        /// �ۑ��{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            // �ۑ�����
            this.SaveProc();
        }

        /// <summary>
        /// �摜�捞
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportImage_Button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //�㕔�ɕ\����������e�L�X�g���w�肷��
            fbd.Description = "�摜�t�H���_���w�肵�Ă��������B" + Environment.NewLine + "���t�@�C���T�C�Y��200KB�𒴂���摜�͎�荞�ނ��Ƃ��ł��܂���B";

            //�f�t�H���g��Desktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.ShowNewFolderButton = true;

            //�_�C�A���O��\������
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                //�I�����ꂽ�t�H���_��\������
                string path = fbd.SelectedPath;

                DirectoryInfo dInfo = new DirectoryInfo(path);
                FileInfo[] fInfo = dInfo.GetFiles();

                if (fInfo != null)
                {
                    bool importFlag = false;

                    foreach (FileInfo info in fInfo)
                    {
                        try
                        {
                            // Byte �Ƃ肠����200KB�𒴂�����͎̂�荞�܂Ȃ�
                            long length = info.Length;
                            // 1024B=1KB
                            // 204800    =200KB
                            if (length > 204800)
                            {
                                continue;
                            }

                            Image image = Image.FromFile(info.FullName);
                            if (image != null)
                            {
                                DataRow row = this._imgTable.NewRow();
                                row[COL_IMAGE] = image;
                                string name = Path.GetFileNameWithoutExtension(info.Name);
                                if (name.Length > 256)
                                {
                                    name = name.Substring(0, 256); 
                                }
                                row[COL_NAME] = name;
                                row[COL_IMAGE_CHANGE] = 1;
                                this._imgTable.Rows.Add(row);
                                importFlag = true;
                            }
                        }
                        catch
                        {

                        }
                    }
                    this._imgTable.AcceptChanges();
                    this.UpDateGrid();

                    if(importFlag)
                    {
                          TMsgDisp.Show(
                          this,							        // �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,	        // �G���[���x��
                          CT_ASSEMBLYID,					    // �A�Z���u��ID�܂��̓N���XID
                          "�捞���������܂����B",               // �\�����郁�b�Z�[�W 
                          0,								    // �X�e�[�^�X�l
                          MessageBoxButtons.OK);
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,							                    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	                // �G���[���x��
                        CT_ASSEMBLYID,					                    // �A�Z���u��ID�܂��̓N���XID
                        "�捞�\�ȉ摜�t�@�C�������݂��܂���ł����B",     // �\�����郁�b�Z�[�W 
                        0,								                    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);
                    }
                }
            }
        }

        /// <summary>
        /// ����{�^���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// �s�ǉ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRow_ultraButton_Click(object sender, EventArgs e)
        {
            DataRow row = this._imgTable.NewRow();
            this._imgTable.Rows.Add(row);
            this.UpDateGrid();
        }

        /// <summary>
        /// �s�폜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelRow_Button_Click(object sender, EventArgs e)
        {
            if (this.GoodsImage_Grid.Selected.Rows.Count > 0)
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
                    foreach (UltraGridRow row in this.GoodsImage_Grid.Selected.Rows)
                    {
                        // �ۑ��ύs
                        row.Cells[COL_DEL].Value = 1;
                    }
                }
                this._imgTable.AcceptChanges();
                this.UpDateGrid();
            }
            else if (this.GoodsImage_Grid.ActiveRow != null)
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
                    this.GoodsImage_Grid.ActiveRow.Cells[COL_DEL].Value = 1;
                }
                this._imgTable.AcceptChanges();
                this.UpDateGrid();
            }
            else if (this.GoodsImage_Grid.ActiveCell != null)
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
                    this.GoodsImage_Grid.ActiveCell.Row.Cells[COL_DEL].Value = 1;
                }
                this._imgTable.AcceptChanges();
                this.UpDateGrid();
            }
        }

        #endregion

        #region ToolStrip

        /// <summary>
        /// �I���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.SetResult();
        }

        /// <summary>
        /// �߂�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region TextBox
        /// <summary>
        /// ImageName_TextBox_Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageName_TextBox_Enter(object sender, EventArgs e)
        {
            //�t���O������
            this._imageNameChange = false;
        }

        /// <summary>
        /// ImageName_TextBox_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageName_TextBox_Leave(object sender, EventArgs e)
        {
            if (this._imageNameChange)
            {
                this.MakeFilter();
            }
        }

        /// <summary>
        /// ImageName_TextBox_TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageName_TextBox_TextChanged(object sender, EventArgs e)
        {
            //���[�U�[�ɂ��ύX���H
            if (this.ImageName_TextBox.Modified == true)
            {
                //�t���O������
                this._imageNameChange = true;
            }
        }

        #endregion

        #region ComboEditor
        /// <summary>
        /// �J�e�S���ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Category_ComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // �ύX�`�F�b�N
            if (this._goodsCategoryId != (long)this.Category_ComboEditor.Value)
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
                            this._goodsCategoryId = (long)this.Category_ComboEditor.Value;
                            dataSearhFlag = true;
                        }
                        else
                        {
                            // �ۑ��Ɏ��s
                            this.Category_ComboEditor.ValueChanged -= new EventHandler(this.Category_ComboEditor_ValueChanged);
                            this.Category_ComboEditor.Value = this._goodsCategoryId;
                            this.Category_ComboEditor.ValueChanged += new EventHandler(this.Category_ComboEditor_ValueChanged);

                        }
                    }
                    else if (ret == DialogResult.No)
                    {
                        // �ҏW���e��j�� �C���f�b�N���X�V
                        this._goodsCategoryId = (long)this.Category_ComboEditor.Value;
                        dataSearhFlag = true;
                    }
                    else
                    {
                        // �L�����Z�� ���@�߂�
                        this.Category_ComboEditor.ValueChanged -= new EventHandler(this.Category_ComboEditor_ValueChanged);
                        this.Category_ComboEditor.Value = this._goodsCategoryId;
                        this.Category_ComboEditor.ValueChanged += new EventHandler(this.Category_ComboEditor_ValueChanged);
                    }
                }
                else
                {
                    // �f�[�^�ύX�Ȃ�
                    // �C���f�b�N�X���X�V
                    this._goodsCategoryId = (long)this.Category_ComboEditor.Value;
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

        #region RetKey
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
                case "GoodsImage_Grid":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = null;
                                    if (this._mode == 0)
                                    {
                                        if (e.ShiftKey)
                                        {
                                            // �ŏ��̃Z��
                                            if (this.GoodsImage_Grid.ActiveCell != null && this.GoodsImage_Grid.ActiveCell.Column.Key == COL_NAME)
                                            {
                                                if (this.GoodsImage_Grid.ActiveCell.Row.HasPrevSibling())
                                                {
                                                    UltraGridRow prevRow = this.GoodsImage_Grid.ActiveCell.Row.GetSibling(SiblingRow.Previous);
                                                    UltraGridCell prevCel = null;

                                                    prevCel = prevRow.Cells[COL_IMAGE];

                                                    if (prevCel != null)
                                                    {
                                                        prevCel.Activate();
                                                        prevCel.Selected = true;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                this.GoodsImage_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                            }
                                        }
                                        else
                                        {
                                            // �ŏI�Z��
                                            if (this.GoodsImage_Grid.ActiveCell != null && this.GoodsImage_Grid.ActiveCell.Column.Key == COL_GUIDE)
                                            {
                                                if (this.GoodsImage_Grid.ActiveCell.Row.HasNextSibling())
                                                {
                                                    UltraGridRow nextRow = this.GoodsImage_Grid.ActiveCell.Row.GetSibling(SiblingRow.Next);
                                                    UltraGridCell nextCel = nextRow.Cells[COL_NAME];
                                                    if (nextCel != null)
                                                    {
                                                        nextCel.Activate();
                                                        this.GoodsImage_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                this.GoodsImage_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (e.Key == Keys.Enter)
                                        {
                                            this.SetResult();
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

        #region Form
      
        /// <summary>
        /// FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsImageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._mode == 0)
            {
                // �}�X�������[�h�̏ꍇ�͓��̓`�F�b�N

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
                        if (st != 0)
                        {
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
        }
        #endregion

        /// <summary>
        /// GoodsImage_Grid_InitializeRow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsImage_Grid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (this._mode == 0)
            {
                if (e.Row.Cells[COL_DATA].Value != DBNull.Value)
                {
                    e.Row.Cells[COL_GUIDE].Activation = Activation.Disabled;
                }
            }
        }
        #endregion

        #endregion
    }
}