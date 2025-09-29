using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// ���i���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       :���i��N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 2006.09.29 ����@�K��</br>
    /// </remarks>
    [Serializable()]
    public class ProductsInfomation
    {
        public string ProductID = "";
        public string ProductName = "";
        public string Version = "";
        //public string IconType = "";                                  //  2006.09.29  �폜
        public int IconIndex = -1;
        public string IconName = "";
        public Image Icon = null;
        //public string SystemCode = "";                                //  2006.09.29  �폜
        //public string OptionCode = "";                                //  2006.09.29  �폜
        public string SysOpCode = "";                                   //  2006.09.29  �ǉ�
        public string DisplayOption = "";
    }

    /// <summary>
    /// �^�u���j���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �^�u���j���[���N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    [Serializable()]
    public class TabMenuInfomation
    {
        public int SubMenuItemCount;
        public int SubMenuItemSetType;   //0:�T�C�Y�D��,1:�y�[�W�����D��
        public int SubMenuItemWidth1;
        public int SubMenuItemWidth2;
        public int SubMenuItemMaxWidth1;
        public int SubMenuItemMaxWidth2;
        public int SubMenuItemMaxWidth3;
        public int SubMenuItemDefCount1;
        public int SubMenuItemDefCount2;
        public int SubMenuItemDefCount3;
        public int SubMenuItemMaxItemFig1;//�m�[�}��
        public int SubMenuItemMaxItemFig2;//�}�X����
        public int SubMenuItemMaxItemFig3;//���[
        public int SubMenuItemMargin;
        public int CategoryID;
        //public string IconType;               //  2006.09.29  �폜
        public int IconIndex;
        public string IconName = null;
        public Image Icon;
        public bool NeedRefresh;
        public ArrayList arSubItems;

        public TabMenuInfomation(int iCategoryID)
        {
            CategoryID = iCategoryID;
            arSubItems = new ArrayList();
            arSubItems.Clear();
        }
    }

    /// <summary>
    /// �J�e�S�����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �J�e�S�����N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    [Serializable()]
    public class CategoryInfomation
    {

        public int CategoryID;
        public int No;
        public string Name;
        public string Description;
        //public string IconType;               //  2006.09.29  �폜
        public int IconIndex;
        public string IconName;
        public Image Icon;
        //public string SystemCode;             //  2006.09.29  �폜
        //public string OptionCode;             //  2006.09.29  �폜
        public string SysOpCode;                //  2006.09.29  �ǉ�
        public string DisplayOption;

    }

    /// <summary>
    /// �T�u�J�e�S�����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �T�u�J�e�S�����N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    [Serializable()]
    public class SubCategoryInfomation
    {

        public int CategoryID;
        public int CategorySubID;
        public int No;
        public string Name;
        public string Description;
        //public string IconType;               //  2006.09.29  �폜
        public int IconIndex;
        public string IconName;
        //public string SystemCode;             //  2006.09.29  �폜
        //public string OptionCode;             //  2006.09.29  �폜
        public string SysOpCode;                //  2006.09.29  �ǉ�
        public string DisplayOption;

    }

    /// <summary>
    /// �T�u�J�e�S�����N���X(�����f���o����)
    /// </summary>
    /// <remarks>
    /// <br>Note       : �T�u�J�e�S�����N���X(�����f���o����-�ߋ��o�[�W�����̏�ʌ݊��ׂ̈ɂ���)</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.29</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    [Serializable()]
    public class SubCategoryInfomationOldVer1
    {

        public int CategoryID;
        public int CategorySubID;
        public int No;
        public string Name;
        public string Description;
        public string IconType;
        public int IconIndex;
        public string IconName;
        public string SystemCode;
        public string OptionCode;
        public string DisplayOption;

    }

    /// <summary>
    /// �T�u���j���[�A�C�e�����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �T�u���j���[�A�C�e���N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    [Serializable()]
    public class MenuItemInfomation
    {

        public int CategoryID;
        public int CategorySubID;
        public int ItemID;
        public int No;
        public int ItemSubID;                   //  2006.09.29  �ǉ�
        public int SubNo;                       //  2006.09.29  �ǉ�
        public string Pgid;
        public string Name;
        public string Parameter;
        public string Description;
        //public string IconType;               //  2006.09.29  �폜
        public int IconIndex;
        public string IconName;
        //public string SystemCode;             //  2006.09.29  �폜
        //public string OptionCode;             //  2006.09.29  �폜
        public string SysOpCode;                //  2006.09.29  �ǉ�
        public string DisplayOption;
        public string SearchKeyWord;
        public int Rank;

    }


    public class RollSettingInfomation
    {
        public int RollRank;
        public string RollName;
        public int PassWordType;
        public string PassWord;
        public string Result;
    }

    /// <summary>
    /// ���[�e�B���e�B�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�e�B���e�B�N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 2007.01.10 ����@�K��</br>
    /// <br></br>
    /// <br>Update Note: 2012/11/29 22018 ��ؐ��b</br>
    /// <br>             �m�F�_�C�A���O�̒ǉ�</br>
    /// </remarks>
    public class SFNETMENU2Utilities
    {

        private static DataSet dsSystemProducts = new DataSet();
        private static DataSet dsUserProducts = new DataSet();

        public  const string DefaultSystemXML = "SfNetMenuNavigator.xml";
        public  const string RollSettingXML = "SfNetNullSet.xml";
        public  static string StatusMessage = "";

        public  const int CallndarTypeFig = 12;

        /// <summary>���b�Z�[�W���x��</summary>
        /// <remarks>ShowMessage�Ŏg�p���郁�b�Z�[�W���x���̗񋓌^�ł�</remarks>
        public enum MessageDlgLevel : int
        {
            /// <summary>���\��</summary>
            msgErrLevelInfo,
            /// <summary>�m�F�P(�͂��E������)</summary>
            msgErrLevelConfirem1,
            /// <summary>�m�F�Q(�͂��E�������E�L�����Z��)</summary>
            msgErrLevelConfirem2,
            /// <summary>�m�F�R(OK�E�L�����Z��)</summary>
            msgErrLevelConfirem3,
            /// <summary>�x��</summary>
            msgErrLevelWarning,
            // --- ADD m.suzuki 2012/11/29 ---------->>>>>
            /// <summary>�x���i�������E�͂��j</summary>
            msgErrLevelWarningConfirem,
            // --- ADD m.suzuki 2012/11/29 ----------<<<<<
            /// <summary>�G���[</summary>
            msgErrLevelError
        }

        /// <summary>
        /// ���b�Z�[�W�o�͏���
        /// </summary>
        /// <param name="ErrLevel">�G���[���x��</param>
        /// <param name="Unit">���j�b�g��</param>
        /// <param name="ErrMainMessage">�G���[���b�Z�[�W(���R)</param>
        /// <param name="ErrStatusMessage">�V�X�e���G���[���b�Z�[�W</param>
        /// <param name="ErrStatusMessage">�V�X�e���G���[�R�[�h</param>
        /// <returns>���[�U�[�Ή�����</returns>
        /// <remarks>
        /// <br>Note       :���b�Z�[�W���o�͂���</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static DialogResult ShowMessage(MessageDlgLevel ErrLevel, string Unit, string ErrMainMessage, string ErrStatusMessage, string ErrCode)
        {
            MessageBoxButtons btnType = MessageBoxButtons.OK;
            MessageBoxIcon icoType = MessageBoxIcon.Exclamation;
            // --- ADD m.suzuki 2012/11/29 ---------->>>>>
            MessageBoxDefaultButton defaultBtn = MessageBoxDefaultButton.Button1;
            // --- ADD m.suzuki 2012/11/29 ----------<<<<<
            string errCaption = "";
            string errMsg = "";

            switch (ErrLevel)
            {
                case MessageDlgLevel.msgErrLevelInfo:					//	�C���t�H���[�V����
                    btnType = MessageBoxButtons.OK;
                    icoType = MessageBoxIcon.Information;
                    //errCaption = "��� �| <SuperFrontman.NS �Ɩ����j���[>";        //  2006.09.29  �ύX
                    errCaption = "��� �| <.NS �Ɩ����j���[>";
                    break;
                case MessageDlgLevel.msgErrLevelConfirem1:				//	�m�F�P(�͂��E������)
                    btnType = MessageBoxButtons.YesNo;
                    icoType = MessageBoxIcon.Question;
                    //errCaption = "�m�F �| <SuperFrontman.NS �Ɩ����j���[>";        //  2006.09.29  �ύX
                    errCaption = "�m�F �| <.NS �Ɩ����j���[>";
                    break;
                case MessageDlgLevel.msgErrLevelConfirem2:				//	�m�F�Q(�͂��E�������E�L�����Z��)
                    btnType = MessageBoxButtons.YesNoCancel;
                    icoType = MessageBoxIcon.Question;
                    //errCaption = "�m�F �| <SuperFrontman.NS �Ɩ����j���[>";        //  2006.09.29  �ύX
                    errCaption = "�m�F �| <.NS �Ɩ����j���[>";
                    break;
                case MessageDlgLevel.msgErrLevelConfirem3:				//	�m�F�R(OK�E�L�����Z��)
                    btnType = MessageBoxButtons.OKCancel;
                    icoType = MessageBoxIcon.Question;
                    //errCaption = "�m�F �| <SuperFrontman.NS �Ɩ����j���[>";        //  2006.09.29  �ύX
                    errCaption = "�m�F �| <.NS �Ɩ����j���[>";
                    break;
                case MessageDlgLevel.msgErrLevelWarning:				//	�x��
                    btnType = MessageBoxButtons.OK;
                    icoType = MessageBoxIcon.Exclamation;
                    //errCaption = "�x�� �| <SuperFrontman.NS �Ɩ����j���[>";        //  2006.09.29  �ύX
                    errCaption = "�x�� �| <.NS �Ɩ����j���[>";
                    break;
                // --- ADD m.suzuki 2012/11/29 ---------->>>>>
                case MessageDlgLevel.msgErrLevelWarningConfirem:        // �x���i�������E�͂��j
                    btnType = MessageBoxButtons.YesNo;
                    icoType = MessageBoxIcon.Exclamation;
                    errCaption = "�x�� �| <.NS �Ɩ����j���[>";
                    defaultBtn = MessageBoxDefaultButton.Button2; // �f�t�H���g=������
                    break;
                // --- ADD m.suzuki 2012/11/29 ----------<<<<<
                case MessageDlgLevel.msgErrLevelError:					//	�G���[
                    btnType = MessageBoxButtons.OK;
                    icoType = MessageBoxIcon.Stop;
                    //errCaption = "�G���[���� �| <SuperFrontman.NS �Ɩ����j���[>";   //  2006.09.29  �ύX
                    //errMsg = "SuperFrontman.NS �Ɩ����j���[(" + Unit + ")�ɂăG���[���������܂����B\n\n";
                    errCaption = "�G���[���� �| <.NS �Ɩ����j���[>";
                    errMsg = ".NS �Ɩ����j���[(" + Unit + ")�ɂăG���[���������܂����B\n\n";
                    break;
            }

            // --- UPD m.suzuki 2012/11/29 ---------->>>>>
            if (ErrLevel != MessageDlgLevel.msgErrLevelWarningConfirem)
            {
                errMsg = errMsg + "[" + ErrMainMessage + "]\n\n" + ErrStatusMessage;
                if (ErrLevel > MessageDlgLevel.msgErrLevelConfirem3)
                    errMsg = errMsg + "\n\n  <�X�e�[�^�X = " + ErrCode + " >";
            }
            else
            {
                errMsg = ErrStatusMessage;
            }
            // --- UPD m.suzuki 2012/11/29 ----------<<<<<

            // --- UPD m.suzuki 2012/11/29 ---------->>>>>
            //return (MessageBox.Show(errMsg, errCaption, btnType, icoType));
            return (MessageBox.Show( errMsg, errCaption, btnType, icoType, defaultBtn ));
            // --- UPD m.suzuki 2012/11/29 ----------<<<<<
        }

        /// <summary>
        /// �V�X�e�����j���[���ݒ菈��
        /// </summary>
        /// <param name="xmlConfig">�V�X�e�����j���[���</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :�V�X�e�����j���[���ݒ�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static int SetSystemConfig(MemoryStream xmlConfig)
        {
            int nRtnCd = 0;

            StatusMessage = "";

            try
            {
                dsSystemProducts.ReadXml(xmlConfig, XmlReadMode.Auto);
            }
            catch (Exception er)
            {
                nRtnCd = 5;
                StatusMessage = er.Message;
            }

            return nRtnCd;

        }

        /// <summary>
        /// ���[�U�[���j���[���ݒ菈��
        /// </summary>
        /// <param name="dsUserData">���[�U�[���j���[���</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :���[�U�[���j���[���ݒ�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static DataSet SetUserConfig(DataSet dsUserData)
        {
            //int nRtnCd = 0;

            StatusMessage = "";

            try
            {
                return dsUserProducts = dsUserData;
            }
            catch (Exception er)
            {
                //nRtnCd = 5;
                StatusMessage = er.Message;
                return null;
            }

        }

        /// <summary>
        /// ���[�U�[���j���[���擾����
        /// </summary>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :���[�U�[���j���[���擾</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static DataSet GetUserConfig()
        {
            //int nRtnCd = 0;

            StatusMessage = "";

            try
            {
                return dsUserProducts;
            }
            catch (Exception er)
            {
                //nRtnCd = 5;
                StatusMessage = er.Message;
                return null;
            }

        }

        /// <summary>
        /// ���i���擾����(�v���_�N�g�w��)
        /// </summary>
        /// <param name="Products">�v���_�N�g��</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :���i���擾</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.29</br>
        /// </remarks>
        public static DataRow[] GetProducts(string Products)
        {

            try
            {
                //  �ŏ�ʏ��
                DataRow[] foundRows = dsSystemProducts.Tables["ProductCategory"].Select("CategoryID < 0 and Products = '" + Products + "'", "CategoryID");

                return foundRows;
            }
            catch (Exception)
            {
                return new DataRow[0];
            }


        }

        /// <summary>
        /// �J�e�S�����擾����(�v���_�N�g�w��)
        /// </summary>
        /// <param name="Products">�v���_�N�g��</param>
        /// <param name="IncludeAll">���ʐ��i���擾</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :�J�e�S�����擾</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
//        public static DataRow[] GetCategory(string[] Products)                    //  2006.09.29  �ύX
        public static DataRow[] GetCategory(string[] Products, bool IncludeAll)
        {
            DataRow[] foundRows;

            //                                                                      //  2006.09.29  �ύX VV
            /*
            string sWhere = "";
            for (int i = 0; i < Products.Length; i++)
            {
                sWhere = sWhere + "Products = '" + Products[i] + "'";
                if (i < (Products.Length - 1))
                {
                    sWhere = sWhere + " and ";
                }
            }
            sWhere = sWhere + " and CategoryID <> 0"; 
            */
            string sWhere = "";
            if (IncludeAll == true)
            {
                sWhere = "Products = 'All' or ";
            }
            for (int i = 0; i < Products.Length; i++)
            {
                sWhere = sWhere + "Products = '" + Products[i] + "'";
                if (i < (Products.Length - 1))
                {
                    sWhere = sWhere + " or ";
                }
            }
            sWhere = sWhere + " and CategoryID > 0"; 
            //                                                                      //  2006.09.29  �ύX AA

            try
            {
                foundRows = dsSystemProducts.Tables["ProductCategory"].Select(sWhere, "No");

                return foundRows;
            }
            catch (Exception)
            {
                return new DataRow[0];
            }


        }

        /// <summary>
        /// �J�e�S�����擾����(�J�e�S���w��-�J�e�S��ID�͐��i�ɂ�炸���j�[�N)
        /// </summary>
        /// <param name="CategoryID">�ΏۃJ�e�S��ID</param>
        /// <param name="SingleRows">��s�擾</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :�J�e�S�����擾</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.29</br>
        /// </remarks>
        public static DataRow[] GetCategory(int CategoryID, bool SingleRows)
        {
            DataRow[] foundRows;

            try
            {
                if (SingleRows == true)
                {
                    //  1�s�擾
                    foundRows = dsSystemProducts.Tables["ProductCategory"].Select("CategoryID = " + CategoryID.ToString(), "No");
                }
                else
                {
                    //  �����擾
                    foundRows = dsSystemProducts.Tables["ProductCategory"].Select("CategoryID >= " + CategoryID.ToString(), "No");
                }

                return foundRows;
            }
            catch (Exception)
            {
                return new DataRow[0];
            }


        }


        /// <summary>
        /// �J�e�S�����擾����(�v���_�N�g/�J�e�S���w��)
        /// </summary>
        /// <param name="Products">�v���_�N�g��</param>
        /// <param name="CategoryID">�ΏۃJ�e�S��ID</param>
        /// <param name="SingleRows">��s�擾</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :�J�e�S�����擾</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        //                                                                                          //  2006.09.29  �폜
        /*
        public static DataRow[] GetCategory(string Products, int CategoryID, bool SingleRows)
        {
            DataRow[] foundRows;

            try
            {
                if (SingleRows == true)
                {
                    foundRows = dsSystemProducts.Tables["ProductCategory"].Select("Products = '" + Products + "' and CategoryID = " + CategoryID.ToString(), "No");
                }
                else
                {
                    foundRows = dsSystemProducts.Tables["ProductCategory"].Select("Products = '" + Products + "' and CategoryID >= " + CategoryID.ToString(), "No");
                }

                return foundRows;
            }
            catch (Exception er)
            {
                return new DataRow[0];
            }


        }
        */

        /// <summary>
        /// �T�u�J�e�S�����擾����(�w��T�u�J�e�S��)
        /// </summary>
        /// <param name="CategoryID">�ΏۃJ�e�S��ID</param>
        /// <param name="CategorySubID">�ΏۃT�u�J�e�S��ID</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :�T�u�J�e�S�����擾(�w��T�u�J�e�S��)</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static DataRow[] GetSubCategory(int CategoryID, int CategorySubID)
        {
            DataRow[] foundRows;

            try
            {

                foundRows = dsSystemProducts.Tables["ProductSubCategory"].Select("CategoryID = " + CategoryID.ToString() + " and CategorySubID = " + CategorySubID.ToString(), "No");

                return foundRows;

            }
            catch (Exception)
            {
                return new DataRow[0];
            }


        }

        /// <summary>
        /// �T�u�J�e�S�����擾����(�J�e�S�����S�T�u�J�e�S��)
        /// </summary>
        /// <param name="CategoryID">�ΏۃJ�e�S��ID</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :�T�u�J�e�S�����擾(�J�e�S�����S�T�u�J�e�S��)</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static DataRow[] GetSubCategoryGroup(int CategoryID)
        {
            DataRow[] foundRows;

            try
            {

                if (CategoryID != 0)
                {

                    foundRows = dsSystemProducts.Tables["ProductSubCategory"].Select("CategoryID = " + CategoryID.ToString(), "No");
                }
                else
                {

                    foundRows = dsSystemProducts.Tables["ProductSubCategory"].Select("", "No");
                }
                return foundRows;

            }
            catch (Exception)
            {
                return new DataRow[0];
            }


        }

        /// <summary>
        /// ���j���[�A�C�e�����擾����(�J�e�S��ID�E�T�u�J�e�S��ID�w��)
        /// </summary>
        /// <param name="CategoryID">�ΏۃJ�e�S��ID</param>
        /// <param name="CategorySubID">�ΏۃJ�e�S���T�uID</param>
        /// <param name="GetType">�擾�Ώۃ^�C�v(0:�{��PG�̂�,1:�qPG�̂�,2:�{�́E�q��)</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :���j���[�A�C�e�����擾</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        //public static DataRow[] GetProductItem(int CategoryID, int CategorySubID)                         //  2006.09.29  �ύX
        public static DataRow[] GetProductItem(int CategoryID, int CategorySubID, int GetType)
        {
            DataRow[] foundRows;

            try
            {
                //  �擾�^�C�v�Ō����������ύX����                           // 2006.09.29  �ǉ�
                string WhereString = "CategoryID = " + CategoryID + " and CategorySubID = " + CategorySubID;
                if (GetType == 0)
                {
                    WhereString = WhereString + " and ItemSubID = 0";
                }
                else if (GetType == 1)
                {
                    WhereString = WhereString + " and ItemSubID <> 0"; 
                }

                //foundRows = dsSystemProducts.Tables["ProductItem"].Select("CategoryID = " + CategoryID + " and CategorySubID = " + CategorySubID, "No, SubNo");   //  2006.09.29  �ύX
                foundRows = dsSystemProducts.Tables["ProductItem"].Select(WhereString, "No, SubNo");
                return foundRows;

            }
            catch (Exception)
            {
                return new DataRow[0];
            }

        }

        /// <summary>
        /// ���j���[�A�C�e�����擾����(�J�e�S��ID�E�T�u�J�e�S��ID�E�A�C�e��ID�w��)
        /// </summary>
        /// <param name="CategoryID">�ΏۃJ�e�S��ID</param>
        /// <param name="CategorySubID">�ΏۃJ�e�S���T�uID</param>
        /// <param name="ItemID">�ΏۃJ�e�S���T�uID</param>
        /// <param name="GetType">�擾�Ώۃ^�C�v(0:�{��PG�̂�,1:�qPG�̂�,2:�{�́E�q��)</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :���j���[�A�C�e�����擾</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static DataRow[] GetProductItem(int CategoryID, int CategorySubID, int ItemID, int GetType)
        {
            DataRow[] foundRows;

            try
            {
                //  �擾�^�C�v�Ō����������ύX����                           // 2006.09.29  �ǉ�
                string WhereString = "CategoryID = " + CategoryID + " and CategorySubID = " + CategorySubID + " and ItemID = " + ItemID.ToString();
                if (GetType == 0)
                {
                    WhereString = WhereString + " and ItemSubID = 0";
                }
                else if (GetType == 1)
                {
                    WhereString = WhereString + " and ItemSubID <> 0";
                }

                //foundRows = dsSystemProducts.Tables["ProductItem"].Select("CategoryID = " + CategoryID + " and CategorySubID = " + CategorySubID, "No, SubNo");   //  2006.09.29  �ύX
                foundRows = dsSystemProducts.Tables["ProductItem"].Select(WhereString, "No, SubNo");
                return foundRows;

            }
            catch (Exception)
            {
                return new DataRow[0];
            }



        }

        /// <summary>
        /// ���j���[�A�C�e����񌟍�����
        /// </summary>
        /// <param name="srchTargetProgram">����������</param>
        /// <param name="GetType">�擾�Ώۃ^�C�v(0:�{��PG�̂�,1:�qPG�̂�,2:�{�́E�q��)</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :���j���[�A�C�e����񌟍�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        //public static DataRow[] SearchProductItem(string srchTargetProgram)
        public static DataRow[] SearchProductItem(string srchTargetProgram, int GetType)
        {
            DataRow[] foundRows;

            try
            {
                //  �擾�^�C�v�Ō����������ύX����                           // 2006.09.29  �ǉ�
                //string WhereString = "Name LIKE '*" + srchTargetProgram + "*' or SearchKeyWord LIKE '*" + srchTargetProgram + "*'";   //  2007.01.10  �ύX
                string WhereString = "(Name LIKE '*" + srchTargetProgram + "*' or SearchKeyWord LIKE '*" + srchTargetProgram + "*')";
                if (GetType == 0)
                {
                    WhereString = WhereString + " and ItemSubID = 0";
                }
                else if (GetType == 1)
                {
                    WhereString = WhereString + " and ItemSubID <> 0";
                }

                //foundRows = dsSystemProducts.Tables["ProductItem"].Select("Name LIKE '*" + srchTargetProgram + "*' or SearchKeyWord LIKE '*" + srchTargetProgram + "*'", "CategoryID, CategorySubID, No");    //  2006.09.29  �ύX
                foundRows = dsSystemProducts.Tables["ProductItem"].Select(WhereString, "CategoryID, CategorySubID, No, SubNo");

                return foundRows;
            }
            catch (Exception)
            {
                return new DataRow[0];
            }

        }

        /// <summary>
        /// ���j���[�X�L�[�}�E�N���[���쐬����
        /// </summary>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :���j���[�X�L�[�}�E�N���[���쐬</br>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static int CloneSchema()
        {
            try
            {
                dsUserProducts = dsSystemProducts.Clone();
                for (int i = 0; i < dsUserProducts.Tables.Count; i++)
                {
                    dsUserProducts.Tables[i].Clear();
                }

                return 0;
            }
            catch (Exception)
            {
                return 5;
            }

        }

        /// <summary>
        /// ���[�U�[���j���[�O���[�v�ǉ�����
        /// </summary>
        /// <param name="ci">�J�e�S�����</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :���[�U�[���j���[�O���[�v�ǉ�����</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static int AddUserMenuCategory(CategoryInfomation ci)
        {

            DataRow dr = dsUserProducts.Tables["ProductCategory"].NewRow();
            dr["Products"] = "User";
            dr["CategoryID"] = -101;
            dr["CategorySubID"] = ci.No;
            dr["No"] = ci.No;           //  ��������
            dr["Name"] = ci.Name;
            dr["Description"] = ci.Description;
            //dr["IconType"] = ci.IconType;                                 //  2006.09.29  �폜
            dr["IconIndex"] = ci.IconIndex;
            dr["IconName"] = ci.IconName;
            //dr["SystemCode"] = ci.SystemCode;                             //  2006.09.29  �폜
            //dr["OptionCode"] = ci.OptionCode;                             //  2006.09.29  �폜
            dr["SysOpCode"] = ci.SysOpCode;                                 //  2006.09.29  �ǉ�
            dr["DisplayOption"] = ci.DisplayOption;
            dsUserProducts.Tables["ProductCategory"].Rows.Add(dr);

            return 0;

        }

        /// <summary>
        /// ���[�U�[���j���[�O���[�v�N���A����
        /// </summary>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :���[�U�[���j���[�O���[�v�N���A����</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static int ClearUserCategory()
        {

            dsUserProducts.Tables["UserCategory"].Rows.Clear();

            return 0;

        }

        /// <summary>
        /// ���[�U�[���j���[�A�C�e���N���A����
        /// </summary>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :���[�U�[���j���[�A�C�e���N���A����</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static int ClearUserItem()
        {

            dsUserProducts.Tables["UserItem"].Clear();

            return 0;

        }

        /// <summary>
        /// ���[�U�[���j���[�O���[�v�ǉ�����
        /// </summary>
        /// <param name="usrCategoryID">���[�U�[�J�e�S��ID</param>
        /// <param name="usrName">���[�U�[�J�e�S������</param>
        /// <param name="usrNo">���[�U�[�J�e�S���\����</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :���[�U�[���j���[�O���[�v�ǉ�����</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static int AddUserCategory(int usrCategoryID, string usrName, int usrNo)
        {

            DataRow dr = dsUserProducts.Tables["UserCategory"].NewRow();
            dr["UserCategoryID"] = usrCategoryID;
            dr["Name"] = usrName;
            dr["UserNo"] = usrNo;
            dsUserProducts.Tables["UserCategory"].Rows.Add(dr);

            return 0;

        }

        /// <summary>
        /// ���[�U�[���j���[�A�C�e���ǉ�����
        /// </summary>
        /// <param name="usrCategoryID">���[�U�[�J�e�S��ID</param>
        /// <param name="CategroyID">�J�e�S��ID</param>
        /// <param name="SubCategoryID">�T�u�J�e�S��ID</param>
        /// <param name="ItemID">�A�C�e��ID</param>
        /// <param name="No">�\����</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :���[�U�[���j���[�A�C�e���ǉ�����</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static int AddUserItem(int usrCategoryID, int CategroyID, int SubCategoryID, int ItemID, int No)
        {

            DataRow dr = dsUserProducts.Tables["UserItem"].NewRow();
            dr["UserCategoryID"] = usrCategoryID;
            dr["CategoryID"] = CategroyID;
            dr["CategorySubID"] = SubCategoryID;
            dr["ItemID"] = ItemID;
            dr["No"] = No;
            dsUserProducts.Tables["UserItem"].Rows.Add(dr);

            return 0;

        }

        /// <summary>
        /// ���j���[�}�[�W����
        /// </summary>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :���j���[�}�[�W����</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static int MergeMenuInfomation()
        {
            try
            {
                dsSystemProducts.Merge(dsUserProducts);

                return 0;
            }
            catch (Exception)
            {
                return 5;
            }

        }

        /// <summary>
        /// ���[�U�[���j���[���쐬����
        /// </summary>
        /// <returns>���[�U�[���j���[</returns>
        /// <remarks>
        /// <br>Note       :���[�U�[���j���[���쐬</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static DataSet CreateUserMenuInfomation()
        {

            try
            {
                //  ���[�U�[�T�u�J�e�S��(�O���[�v)�e�[�u����`
                DataTable tUserCategory = new DataTable("UserCategory");
                DataColumn cUserCategoryID = new DataColumn();
                DataColumn cUserCategoryName = new DataColumn();
                DataColumn cUserNo = new DataColumn();
                cUserCategoryID.DataType = System.Type.GetType("System.Int32");
                cUserCategoryID.AllowDBNull = false;
                cUserCategoryID.ColumnName = "UserCategoryID";
                cUserCategoryName.DataType = System.Type.GetType("System.String");
                cUserCategoryName.AllowDBNull = false;
                cUserCategoryName.ColumnName = "Name";
                cUserNo.DataType = System.Type.GetType("System.Int32");
                cUserNo.AllowDBNull = false;
                cUserNo.ColumnName = "UserNo";
                tUserCategory.Columns.Add(cUserCategoryID);
                tUserCategory.Columns.Add(cUserCategoryName);
                tUserCategory.Columns.Add(cUserNo);

                //  ���[�U�[�A�C�e����`
                DataTable tUserItem = new DataTable("UserItem");
                DataColumn cUserCategoryID2 = new DataColumn();
                DataColumn cCategoryID = new DataColumn();
                DataColumn cCategorySubID = new DataColumn();
                DataColumn cItemID = new DataColumn();
                DataColumn cNo = new DataColumn();
                cUserCategoryID2.DataType = System.Type.GetType("System.Int32");
                cUserCategoryID2.AllowDBNull = false;
                cUserCategoryID2.ColumnName = "UserCategoryID";
                cCategoryID.DataType = System.Type.GetType("System.Int32");
                cCategoryID.AllowDBNull = false;
                cCategoryID.ColumnName = "CategoryID";
                cCategorySubID.DataType = System.Type.GetType("System.Int32");
                cCategorySubID.AllowDBNull = false;
                cCategorySubID.ColumnName = "CategorySubID";
                cItemID.DataType = System.Type.GetType("System.Int32");
                cItemID.AllowDBNull = false;
                cItemID.ColumnName = "ItemID";
                cNo.DataType = System.Type.GetType("System.Int32");
                cNo.AllowDBNull = false;
                cNo.ColumnName = "No";
                tUserItem.Columns.Add(cUserCategoryID2);
                tUserItem.Columns.Add(cCategoryID);
                tUserItem.Columns.Add(cCategorySubID);
                tUserItem.Columns.Add(cItemID);
                tUserItem.Columns.Add(cNo);

                //  �f�[�^�Z�b�g�ɒǉ�
                dsUserProducts = new DataSet();
                dsUserProducts.Tables.Add(tUserCategory);
                dsUserProducts.Tables.Add(tUserItem);


                return dsUserProducts;
            }
            catch(Exception)
            {
                return null;

            }


        }

        /// <summary>
        /// ���[�U�[���j���[�J�e�S�����擾����
        /// </summary>
        /// <param name="CategroyID">�J�e�S��ID</param>
        /// <returns>�擾����</returns>
        /// <remarks>
        /// <br>Note       :���[�U�[���j���[�J�e�S�����擾</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static DataRow[] GetUserCategoryGroup(int CategoryID)
        {

            try
            {
                DataTable tmpProductCategory = dsSystemProducts.Tables["ProductSubCategory"].Clone();

                //  �J�e�S��=-1�Ȃ�S���R�[�h                                             //  2007.01.10  �ǉ�
                string WhereString = "";
                if (CategoryID > -1)
                {
                    WhereString = "UserCategoryID = " + CategoryID.ToString();
                }
                //DataRow[] tmpRows = dsUserProducts.Tables["UserCategory"].Select("", "UserNo");   //  2007.01.10  �ύX
                DataRow[] tmpRows = dsUserProducts.Tables["UserCategory"].Select(WhereString, "UserNo");

                DataRow[] ret = new DataRow[tmpRows.Length];

                int i = 0;
                foreach (DataRow dr in tmpRows)
                {
                    DataRow foundRows = tmpProductCategory.NewRow();
                    foundRows["Products"] = "User";
                    foundRows["CategoryID"] = -101;
                    foundRows["CategorySubID"] = dr["UserCategoryID"];           //  ��������
                    foundRows["No"] = dr["UserNo"];                                  //  ��������
                    foundRows["Name"] = dr["Name"];
                    foundRows["Description"] = "";
                    //foundRows["IconType"] = "res";                            //  2006.09.29  �폜
                    foundRows["IconIndex"] = 0;
                    foundRows["IconName"] = "";
                    //foundRows["SystemCode"] = "";                             //  2006.09.29  �폜
                    //foundRows["OptionCode"] = "";                             //  2006.09.29  �폜
                    foundRows["SysOpCode"] = "";                                //  2006.09.29  �ǉ�
                    foundRows["DisplayOption"] = "0";
                    ret[i++] = foundRows;
                }

                return ret;
            }
            catch (Exception)
            {
                return new DataRow[0];
            }

        }


        /// <summary>
        /// ���[�U�[���j���[�A�C�e�����擾����
        /// </summary>
        /// <param name="UserCategoryID">���[�U�[�J�e�S��ID</param>
        /// <returns>�擾����</returns>
        /// <remarks>
        /// <br>Note       :���[�U�[���j���[�A�C�e�����擾</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static DataRow[] GetUserItem(int UserCategoryID)
        {
            DataTable tmpProductItem = dsSystemProducts.Tables["ProductItem"].Clone();
            DataRowCollection foundRows = tmpProductItem.Rows;

            DataRow[] tmpUserItemRow = dsUserProducts.Tables["UserItem"].Select("UserCategoryID = " + UserCategoryID.ToString(), "");

            foreach (DataRow dr in tmpUserItemRow)
            {
                //String strSearch = "CategoryID = " + dr["CategoryID"] + " and CategorySubID = " + dr["CategorySubID"] + " and ItemID = " + dr["ItemID"];      //  2006.09.29  �ǉ�
                String strSearch = "CategoryID = " + dr["CategoryID"] + " and CategorySubID = " + dr["CategorySubID"] + " and ItemID = " + dr["ItemID"] + " and ItemSubID = 0";
                DataRow[] tmpRows = dsSystemProducts.Tables["ProductItem"].Select(strSearch, "No");
                if (tmpRows.Length != 0)
                {
                    try
                    {
                        tmpProductItem.ImportRow(tmpRows[0]);
                    }
                    catch(Exception)
                    {
                        //  �d����NULL��
                    }

                }
            }
            DataRow[] ret = new DataRow[tmpProductItem.Rows.Count];
            for (int i = 0; i < tmpProductItem.Rows.Count; i++)
            {
                ret[i] = tmpProductItem.Rows[i];
            }

            return ret;

        }

        /// <summary>
        /// �`�����J�����_�[������擾����
        /// </summary>
        /// <param name="FormatType">�t�H�[�}�b�g�^�C�v</param>
        /// <returns>�`�����J�����_�[������</returns>
        /// <remarks>
        /// <br>Note       :�`�����J�����_�[������擾</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static string GetCalendar(ref int FormatType)
        {

            //  ���t�ݒ�
//            string sWeekJ;
            string sWeekE;
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
            {
//                sWeekJ = "(��)";
                sWeekE = "(Mon)";
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Tuesday)
            {
//                sWeekJ = "(��)";
                sWeekE = "(Tue)";
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Wednesday)
            {
//                sWeekJ = "(��)";
                sWeekE = "(Wed)";
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Thursday)
            {
//                sWeekJ = "(��)";
                sWeekE = "(Thu)";
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Friday)
            {
//                sWeekJ = "(��y)";
                sWeekE = "(Fri)";
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
            {
//                sWeekJ = "(�y)";
                sWeekE = "(Sat)";
            }
            else
            {
//                sWeekJ = "(��)";
                sWeekE = "(Sun)";
            }

            try
            {
                if (FormatType > 11)
                {
                    FormatType = 0;
                }

                switch (FormatType)
                {

                    case 0: return DateTime.Now.ToString("�y yyyy�NMM��dd��(ddd) �z");
                    case 1: return DateTime.Now.ToString("�y yyyy�NMM��dd�� �z");
                    case 2: return DateTime.Now.ToString("�y yyyy/MM/dd") + sWeekE + " �z";
                    case 3: return DateTime.Now.ToString("�y yyyy/MM/dd �z");
                    case 4: return DateTime.Now.ToString("�y MM��dd��(ddd) �z");
                    case 5: return DateTime.Now.ToString("�y MM��dd�� �z");
                    case 6: return DateTime.Now.ToString("�y MM/dd") + sWeekE + " �z";
                    case 7: return DateTime.Now.ToString("�y MM/dd �z");
                    case 8: return DateTime.Now.ToString("�y yyyy�NMM��dd��(ddd)  HH:mm �z");
                    case 9: return DateTime.Now.ToString("�y yyyy�NMM��dd��  HH:mm �z");
                    case 10: return DateTime.Now.ToString("�y yyyy/MM/dd HH:mm  �z");
                    case 11: return DateTime.Now.ToString("�y MM/dd HH:mm �z");
                    default: return DateTime.Now.ToString("�y yyyy�NMM��dd��(ddd) �z");
                }
            }
            catch
            {
                return "";
            }

        }

    }
}




