using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// �o�^�v���O�����I����ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�^�v���O�����I����ʃN���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public partial class SFNETMENU2D : Form
    {

        /// <summary>
        /// �o�^�v���O�����I����ʃR���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �o�^�v���O�����I����ʃR���X�g���N�^</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.09.04</br>
        /// </remarks>
        public SFNETMENU2D()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ���[�U�[���j���[�ҏW��ʕ\�����䏈��
        /// </summary>
        /// <param name="strFilter">�����t�B���^�[������</param>
        /// <param name="si">��ʐF���</param>
        /// <returns>�I�����j���[���</returns>
        /// <remarks>
        /// <br>Note       :���[�U�[���j���[�ҏW��ʕ\������</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public MenuItemInfomation[] ShowItemList(string strFilter, ScreenInfomation si)
        {

            btnSave.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.Decision];
            btnCancel.Image = MenuIconResourceManagement.imgToolBar.Images[(int)MenuIconResourceManagement.ToolBarImage.Back];
            btnSave.ForeColor = si.ToolBarForeColor;                            //  2007.01.10  �ǉ�
            btnCancel.ForeColor = si.ToolBarForeColor;                          //  2007.01.10  �ǉ�

            CustomProfessionalRenderer cpr = new CustomProfessionalRenderer();
            try
            {
                cpr._ToolStripGradientBegin = si.ToolBarColor.ToolStripGradientBegin;
                cpr._ToolStripGradientMiddle = si.ToolBarColor.ToolStripGradientMiddle;
                cpr._ToolStripGradientEnd = si.ToolBarColor.ToolStripGradientEnd;
                cpr._ToolStripPanelGradientBegin = si.ToolBarColor.ToolStripPanelGradientBegin;
                cpr._ToolStripPanelGradientEnd = si.ToolBarColor.ToolStripPanelGradientEnd;
            }
            catch (Exception)
            {
                cpr._ToolStripGradientBegin = Color.LightBlue;
                cpr._ToolStripGradientMiddle = Color.WhiteSmoke;
                cpr._ToolStripGradientEnd = Color.LightSkyBlue;
                cpr._ToolStripPanelGradientBegin = Color.LightSkyBlue;
                cpr._ToolStripPanelGradientEnd = Color.LightSkyBlue;
            }
            barSub.Renderer = new ToolStripProfessionalRenderer(cpr);

            BackColor = si.ScreenBackColor;

            Cursor = Cursors.WaitCursor;

            lstItems.Items.Clear();
            ShowFilterList(strFilter);

            Cursor = Cursors.Default;

            if (Visible != true)
            {
                ShowDialog();
            }

            if (lstItems.SelectedIndices.Count > 0)
            {

                MenuItemInfomation[] mii = new MenuItemInfomation[lstItems.SelectedIndices.Count];
                for (int i = 0; i < lstItems.SelectedIndices.Count; i++)
                {
                    mii[i] = (MenuItemInfomation)lstItems.Items[lstItems.SelectedIndices[i]].Tag;
                }
                return mii;
            }


            return null;
        }

        /// <summary>
        /// �������ʕ\�����䏈��
        /// </summary>
        /// <param name="strFilter">�����t�B���^�[������</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :�������ʕ\������</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        private int ShowFilterList(string strFilter)
        {
            try
            {

                //DataRow[] srchItemRows = SFNETMENU2Utilities.SearchProductItem(strFilter);            //  20069.09.26 �ύX
                DataRow[] srchItemRows = SFNETMENU2Utilities.SearchProductItem(strFilter, 0);
                for (int i = 0; i < srchItemRows.Length; i++)
                {
                    if (SystemCheck.CheckSystemPermissionFunction(srchItemRows[i]) != 0)
                    {
                        ListViewItem lvi = new ListViewItem();
                        //  ���ׂ��擾
                        MenuItemInfomation mii = new MenuItemInfomation();
                        mii.CategoryID = (int)srchItemRows[i]["CategoryID"];
                        mii.CategorySubID = (int)srchItemRows[i]["CategorySubID"];
                        mii.ItemID = (int)srchItemRows[i]["ItemID"];
                        mii.No = (int)srchItemRows[i]["No"];
                        mii.Pgid = srchItemRows[i]["Pgid"].ToString();
                        mii.Name = srchItemRows[i]["Name"].ToString();
                        mii.Parameter = srchItemRows[i]["Parameter"].ToString();
                        mii.Description = srchItemRows[i]["Description"].ToString();
                        //mii.IconType = srchItemRows[i]["IconType"].ToString();                        //  2006.09.29  �폜
                        mii.IconIndex = (int)srchItemRows[i]["IconIndex"];
                        mii.IconName = srchItemRows[i]["IconName"].ToString();
                        //mii.SystemCode = srchItemRows[i]["SystemCode"].ToString();                    //  2006.09.29  �폜
                        //mii.OptionCode = srchItemRows[i]["OptionCode"].ToString();                    //  2006.09.29  �폜
                        mii.SysOpCode = srchItemRows[i]["SysOpCode"].ToString();                        //  2006.09.29  �ǉ�
                        mii.DisplayOption = srchItemRows[i]["DisplayOption"].ToString();
                        mii.SearchKeyWord = srchItemRows[i]["SearchKeyWord"].ToString();
                        mii.Rank = (int)srchItemRows[i]["Rank"];


                        //2009.02.10 sugi add��
                        // �� �J�e�S�����������x�����Q�Ƃ��t�B���^�[�������� 
                        
                        //2009.02.10 sugi add��

                         //  �T�|�[�g��p�̃J�e�S��
                        if (mii.DisplayOption.ToUpper() == "S")
                        {
                            //  �T�|�[�g�ȊO�ɂ͔�\��
                            if (LoginInfoAcquisition.Employee.UserAdminFlag < 2) continue;
                        }

                        //  �Ǘ��Ґ�p�̃J�e�S��
                        else if (mii.DisplayOption.ToUpper() == "A")
                        {
                            //  �T�|�[�g�ƊǗ��҈ȊO�ɂ͔�\��
                            if (LoginInfoAcquisition.Employee.UserAdminFlag == 0) continue;
                        }
                        //  �T�|�[�g����ȊO�̃J�e�S���̓T�|�[�g�ɂ͔�\��
                        else
                        {
                            if (LoginInfoAcquisition.Employee.UserAdminFlag != 0) continue;
                        }
                        //2009.02.10 sugi add��
                        //  ���ׂ���J�e�S�����擾
                        //DataRow[] srchCategoryRows = SFNETMENU2Utilities.GetCategory("SuperFrontman", mii.CategoryID, true);      //  2006.09.29  �ύX
                        DataRow[] srchCategoryRows = SFNETMENU2Utilities.GetCategory(mii.CategoryID, true);
                        if (srchCategoryRows.Length > 0)
                        {
                            //  �J�e�S���@�\�̎g�p�E�s�̊m�F
                            if (SystemCheck.CheckSystemPermissionFunction(srchCategoryRows[0]) == 0)
                            {
                                continue;
                            }

                            //  �T�u�J�e�S��
                            //DataRow[] SubCategoryRows = SFNETMENU2Utilities.GetProductItem((int)srchItemRows[i]["CategoryID"], (int)srchItemRows[i]["CategorySubID"]);        //  2006.09.29  �ύX
                            DataRow[] SubCategoryRows = SFNETMENU2Utilities.GetProductItem((int)srchItemRows[i]["CategoryID"], (int)srchItemRows[i]["CategorySubID"], 0);
                            if (SubCategoryRows.Length == 0)
                            {
                                continue;
                            }

                            // ���A�C�e����񂩂�J�e�S��ID����уT�u�J�e�S��ID���擾���A����ɑ΂��錠�����x�����m�F����
                            DataRow[] CategoryRow = SFNETMENU2Utilities.GetCategory(mii.CategoryID, true);
                            DataRow[] SubCategoryRow = SFNETMENU2Utilities.GetSubCategory(mii.CategoryID, mii.CategorySubID);

                            bool CategoryCheck = false;
                            bool SubCategoryCheck = false;
                            bool ProductItemCheck = false;

                            if (CategoryRow.Length != 0 && SubCategoryRow.Length != 0)
                            {
                                CategoryCheck = SystemCheck.CheckAuthority(CategoryRow[0]);
                                SubCategoryCheck = SystemCheck.CheckAuthority(SubCategoryRow[0]);
                                ProductItemCheck = SystemCheck.CheckAuthority(srchItemRows[i]);
                            }

                            // ���Ɍ�����������Ε\���ł��Ȃ�(�J�e�S���A�T�u�J�e�S���A�v���_�N�g�A�C�e���`�F�b�N)
                            if (CategoryCheck == false || SubCategoryCheck == false || ProductItemCheck == false)
                            {
                                continue;
                            }

                            //  �J�e�S������ݒ�
                            lvi.Text = srchCategoryRows[0]["Name"].ToString();
                            //  ���ׂ���T�u�J�e�S�����擾
                            DataRow[] srchSubCategoryRows = SFNETMENU2Utilities.GetSubCategory(mii.CategoryID,mii.CategorySubID);
                            if (srchSubCategoryRows.Length > 0)
                            {
                                if (SystemCheck.CheckSystemPermissionFunction(SubCategoryRows[0]) == 0)
                                {
                                    continue;
                                }
                                if (SystemCheck.CheckSystemPermissionFunction(srchSubCategoryRows[0]) != 0)
                                {
                                    //  �T�u�J�e�S������ݒ�
                                    ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
                                    lvsi.Text = srchSubCategoryRows[0]["Name"].ToString().Replace("\\n", "");
                                    lvi.SubItems.Add(lvsi);
                                    ListViewItem.ListViewSubItem lvsi2 = new ListViewItem.ListViewSubItem();
                                    lvsi2.Text = mii.Name.Replace("\\n", "");
                                    lvi.SubItems.Add(lvsi2);
                                    ListViewItem.ListViewSubItem lvsi3 = new ListViewItem.ListViewSubItem();
                                    lvsi3.Text = mii.Description.Replace("\\n", ",");
                                    lvi.SubItems.Add(lvsi3);

                                    lvi.Tag = mii;
                                    lstItems.Items.Add(lvi);
                                }
                            }
                        }
                    }
                }

                return 0;
            }
            catch (Exception)
            {
                return 9;
            }
        }

        /// <summary>
        /// �m��{�^�������������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();

        }

        /// <summary>
        /// �߂�{�^�������������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();

        }

        /// <summary>
        /// �A�C�e���_�u���N���b�N�������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstItems_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();

        }

        /// <summary>
        /// �������x���̊m�F
        /// </summary>
        /// <param name="targetRow">�Ώۃ��R�[�h</param>
        /// <returns>ture:�����L false:������</returns>
        /// <remarks>
        /// <br>Note        :�������x���̊m�F</br>
        /// <br>Programmer  : 20008 �ɓ��@�L</br>
        /// <br>Date        : 2007.06.19</br>
        /// </remarks>
        private bool CheckAuthorityLevel(DataRow targetRow)
        {
            //targetRow[""]

            return false;
        }

    }
}