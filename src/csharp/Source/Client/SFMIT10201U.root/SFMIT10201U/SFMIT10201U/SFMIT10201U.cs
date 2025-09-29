using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolTip;
using System.Collections;
using Broadleaf.Application.Common;

using System.Reflection;

using System.IO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// TBO�p�i�o�^���
    /// </summary>
    /// </summary>
    /// <remarks>
    /// <br>Programmer  : 23010 JIN</br>
    /// <br>Date        : 2016.05.25</br>
    /// </br>
    /// </remarks>
    public partial class SFMIT10201U : Form
    {
        #region const
        /// <summary>
        /// �Z�p���[�^
        /// </summary>
        private const string ctSeparator = @"	";

        /// <summary>
        /// �e�[�u����
        /// </summary>
        private const string TABLE_MAIN = "GOODS_MAIN";      // ���ʃe�[�u��
        private const string TABLE_SUB  = "GOODS_CUSTOM";    // �ʐݒ�e�[�u��

        /// <summary>
        /// �t�H�[�}�b�g
        /// </summary>
        private const string CT_MONEYFORMAT = "#,##0;-#,##0;";
        private const string CT_CODEFORMAT = "#0;-#0;''";
        private const string CT_PARCENTFROMAT = "0.0%";

        /// <summary>���[�h�I�����[�p�w�i�F</summary>
        private static readonly Color READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));

        /// <summary>
        ///  �����H��J�����J���[
        /// </summary>
        /// 
        private static readonly Color REPAIR_COLOR1 = Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(134)))), ((int)(((byte)(76)))));
        private static readonly Color REPAIR_COLOR2 = Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(104)))), ((int)(((byte)(32)))));
        private static readonly Color PRPAIR_FORE = Color.White;

        /// <summary>
        /// PGID
        /// </summary>
        private const string CT_ASSEMBLYID = "SFMIT10201U";

        ///PM���oPG���
        string CT_PM_AssemblyID = "PMKHN09510U.dll";
        string CT_PM_ClassID = "Broadleaf.Windows.Forms.PMKHN09510UA";

        #region Grid�J������`

        // ����
        private const string COL_DEL = "�_���폜";
        private const string COL_SORTNO = "�\�[�g��";
        private const string COL_RELEASE = "���J";
        private const string COL_RECOMMEND = "�I�X�X��";
        private const string COL_GOODSNO = "�i��";
        private const string COL_BLCD = "BL�R�[�h";
        private const string COL_BLCDBR = "BL�R�[�h�}��";
        private const string COL_IMAGE_NO = "�摜No";
        private const string COL_IMAGE = "�摜";
        private const string COL_IMAGE_GUIDE = "�摜�K�C�h";
        private const string COL_IMAGE_CHANGE = "�摜�ύX";
        private const string COL_MAKERTITLE = "���[�J�[";
        private const string COL_MAKERNM = "����";
        private const string COL_MAKERCD = "�R�[�h";
        private const string COL_MAKERGD = "�K�C�h";
        private const string COL_GOODSNM = "���i����";
        private const string COL_RELEASEDATE = "������";
        private const string COL_SHOPSALEBEGINDATE = "���J�J�n��";
        private const string COL_SHOPSALEENDDATE = "���J�I����";

        private const string COL_STOCKCOUNT = "�݌ɐ�";
        private const string COL_STOCKSTATE = "�݌ɏ��";
        private const string COL_GOODSNOTE = "���i����";
        private const string COL_GOODSPR = "���i�o�q";
        // �����H����z�J���� (���i�����[�h�̏ꍇ�̂ݕ\��)
        private const string COL_SF_TITLE = "�����H��";
        private const string COL_SUGGEST_PRICE = "�W�����i";
        private const string COL_SHOP_PRICE = "�X�����i";
        private const string COL_GROSS_SF = "�e��";
        private const string COL_GROSSMARGIN_SF = "�e����";
        // ���i���J����
        private const string COL_PM_TITLE = "���i��";
        private const string COL_TRADE_PRICE = "����";
        private const string COL_PURCHASE_COST = "�d������";
        private const string COL_GROSS_PM = "�e��PM";
        private const string COL_GROSSMARGIN_PM = "�e����PM";
        // �ʐݒ�
        private const string COL_INDIVIDUAL = "���Ӑ�ʐݒ�";
        // ��\���J����
        private const string COL_PM_UPDATETIME = "�݌ɍX�V��"; // hyde

        // �J�e�S����
        // �^�C��
        private const string COL_TIRE_KEY1 = "�T�C�Y";
        private const string COL_TIRE_KEY2 = "�X�^�b�h���X";
        // �o�b�e��
        private const string COL_BATTERY_KEY1 = "�K�i";
        private const string COL_BATTERY_KEY2 = "�K��";
        // �I�C��
        private const string COL_OIL_KEY1 = "�S�x";
        private const string COL_OIL_KEY2 = "�K���I�C��";
        // ���i���I�u�W�F�N�g
        private const string COL_POSTPARACLASS = "POST�p�����[�^�N���X";
        // �t�������p 
        private const string COL_REPARE = "COL_REPARE";

        // ���i���i���v
        private const string COL_MONEY_TOTAL = "���v";
     
        // �s�R�s�[�o�b�t�@
        private List<object> _copyBufferList;

        // ���z����MSG�@�@��
        private const string CT_INPMSG_TIRE     = "�����L���z�́A�P�{�P�ʂ̉��i�i�Ŕ��j�ƂȂ�܂�";
        private const string CT_INPMSG_BATTERY  = "�����L���z�́A�P�P�ʂ̉��i�i�Ŕ��j�ƂȂ�܂�";
        private const string CT_INPMSG_OIL      = "�����L���z�́A�P�k�P�ʂ̉��i�i�Ŕ��j�ƂȂ�܂�";

        // CSV�捞�G���[ST
        private const string ct_ErrSt = "-999";
        private const int ct_ErrInt = -999;
        private const short ct_Errshort = -999;
        private const double ct_ErrDouble = -999;


        #endregion

        #endregion

        #region �����o

        // �N���p�����[�^
        private Propose_Para_Main _bootPara;
        // TOB�A�N�Z�X�N���X
        private TBOServiceACS _TBOServiceACS;
        // �t����������</summary>
        private int _repairCount;
        // �t�������ݒ�
        private Dictionary<long, List<AttendRepairSet>> _attendRepairSetDic;
        // �t�������J�����f�B�N�V���i���[
        private Dictionary<long, List<string>> _attendRepairColDic;
        // ���_��SCM��Ƌ��_�A���f�B�N�V���i���[</summary>
        private Dictionary<string, List<Propose_Para_SCM>> _scmSceDic;
        // ���[�J�[�f�B�N�V���i���[
        private Dictionary<int, Propose_Para_Maker> _makerCdDic;
        // �Z����A�N�e�B�u���̃Z�����
        private UltraGridCell _tempCell = null;
        // �Z����A�N�e�B�u���̏����l
        private object _tempValue = null;

        // ���i�J�e�S�����X�g
        private List<GoodsCategory> _categoryList;
        private ImageList _imgList;

        // �摜�K�C�h
        private GoodsImageForm _imageGuide;

        private DateTime _releaseStDate;

        // ���z�v�Z�K�C�h
        private CalcPriceForm _calcPriceForm;

        // ����ݒ胊�X�g
        private Dictionary<string, Settings> _settingsDic;

        // �O���b�h�F�������t���O
        private bool _initFlag = false;

        #endregion

        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SFMIT10201U()
        {
            InitializeComponent();
            this._TBOServiceACS = new TBOServiceACS();
            this._scmSceDic = new Dictionary<string, List<Propose_Para_SCM>>();
            this._attendRepairSetDic = new Dictionary<long, List<AttendRepairSet>>();
            this._makerCdDic = new Dictionary<int, Propose_Para_Maker>();
            this._attendRepairColDic = new Dictionary<long, List<string>>();
            this._categoryList = new List<GoodsCategory>();
            this._imgList = new ImageList();
            this._imgList.TransparentColor = Color.Cyan;
            this._imgList.Images.Add(Properties.Resources._28_STAR1);
            this._releaseStDate = DateTime.Now;
            this._settingsDic = new Dictionary<string, Settings>();
            this._copyBufferList = new List<object>();
        }
        #endregion

        #region public

        /// <summary>
        /// �O���N������
        /// </summary>
        /// <returns></returns>
        public void Show(Propose_Para_Main para)
        {
            this._bootPara = para;

            if (this._bootPara.BootMode == BootMode.PM)
            {
                this.Icon = Properties.Resources.PMICON;

#if DEBUG
                //// �e�X�g�p�@����PM���[�h
                //Propose_Para_SCM scm = new Propose_Para_SCM();
                //scm.CnectOriginalEpCd = "0140150842030050";
                //scm.CnectOriginalEpNm = "50���";
                //scm.CnectOriginalSecCd = "000001";
                //scm.CnectOriginalSecNm = "�{��";
                //scm.CnectOtherEpCd = "0140150842030504";
                //scm.CnectOtherEpNm = "������Ѓu���[�h���[�t�����J����(10.20.70.217)";
                //scm.CnectOtherSecCd = "01";
                //scm.CnectOtherSecNm = "�{��";
                //scm.DiscDivCd = 0;

                //Propose_Para_SCM scm2 = new Propose_Para_SCM();
                //scm2.CnectOriginalEpCd = "0140150842030050";
                //scm2.CnectOriginalEpNm = "������Ѓu���[�h���[�t �{��";
                //scm2.CnectOriginalSecCd = "000001";
                //scm2.CnectOriginalSecNm = "�{��";
                ////scm2.CnectOtherEpCd = "0140150842030504";
                //scm2.CnectOtherEpCd = "0101150842021003";
                //scm2.CnectOtherEpNm = "���L�t�p�[�c";
                //scm2.CnectOtherSecCd = "01";
                //scm2.CnectOtherSecNm = "�{��";
                //scm2.DiscDivCd = 0;

                Propose_Para_SCM scm3 = new Propose_Para_SCM();
                scm3.CnectOriginalEpCd = "0140150842030035";
                scm3.CnectOriginalEpNm = "�u���[�h���[�t CarpodTab�P��";
                scm3.CnectOriginalSecCd = "000001";
                scm3.CnectOriginalSecNm = "�{��";
                scm3.CnectOtherEpCd = "0101150842021003";
                scm3.CnectOtherEpNm = "���L�t�p�[�c";
                scm3.CnectOtherSecCd = "01";
                scm3.CnectOtherSecNm = "�{��";
                scm3.DiscDivCd = 0;

                // ���i�����[�h
                this._bootPara.EnterpriseCode = "0101150842021003";
                this._bootPara.EnterpriseName = "���L�t�p�[�c";
                this._bootPara.EmployeeCode = "1000";
                this._bootPara.EmployeeName = "���i���Y";
                this._bootPara.SectionCode = "01";


                List<Propose_Para_SCM> list = new List<Propose_Para_SCM>();
                //list.Add(scm);
                //list.Add(scm2);
                list.Add(scm3);
                this._bootPara.Propose_Para_SCM = list;

                List<Propose_Para_Section> secList = new List<Propose_Para_Section>();
                Propose_Para_Section section = new Propose_Para_Section();
                section.SectionCode = "01";
                section.SectionGuideNm = "�{��";
                section.MainOfficeFuncFlag = 0;
                secList.Add(section);

                Propose_Para_Section section2 = new Propose_Para_Section();
                section2.SectionCode = "02";
                section2.SectionGuideNm = "���˓X";
                section2.MainOfficeFuncFlag = 0;
                secList.Add(section2);

                Propose_Para_Section section3 = new Propose_Para_Section();
                section3.SectionCode = "03";
                section3.SectionGuideNm = "���F�X";
                section3.MainOfficeFuncFlag = 0;
                secList.Add(section3);
                this._bootPara.Propose_Para_Section = secList;
#endif

                #region �����e�����񃌃r���[�p

                //// TODO �����e�����񃌃r���[�p
                //// �e�X�g�p�@����PM���[�h
                ////TODO �_�~�[�ŋ��_�A�����쐬
                //Propose_Para_SCM scm = new Propose_Para_SCM();
                //scm.CnectOriginalEpCd = "0140150842030035";
                //scm.CnectOriginalEpNm = "������Ѓr�b�O���[�^�[";
                //scm.CnectOriginalSecCd = "000001";
                //scm.CnectOriginalSecNm = "�t���X";
                //scm.CnectOtherEpCd = "0140150842030504";
                //scm.CnectOtherEpNm = "������Ѓ����e��";
                //scm.CnectOtherSecCd = "01";
                //scm.CnectOtherSecNm = "�{��";
                //scm.DiscDivCd = 0;

                //// ���i�����[�h
                //this._bootPara.EnterpriseCode = "0140150842030504";
                //this._bootPara.EnterpriseName = "������Ѓ����e��";
                //this._bootPara.EmployeeCode = "1000";
                //this._bootPara.EmployeeName = "���i���Y";
                //this._bootPara.SectionCode = "01";


                //List<Propose_Para_SCM> list = new List<Propose_Para_SCM>();
                //list.Add(scm);
                //this._bootPara.Propose_Para_SCM = list;


                //List<Propose_Para_Section> secList = new List<Propose_Para_Section>();
                //Propose_Para_Section section = new Propose_Para_Section();
                //section.SectionCode = "01";
                //section.SectionGuideNm = "�{��";
                //section.MainOfficeFuncFlag = 0;
                //secList.Add(section);

                //Propose_Para_Section section2 = new Propose_Para_Section();
                //section2.SectionCode = "02";
                //section2.SectionGuideNm = "�����c�Ə�";
                //section2.MainOfficeFuncFlag = 0;
                //secList.Add(section2);

                //Propose_Para_Section section3 = new Propose_Para_Section();
                //section3.SectionCode = "03";
                //section3.SectionGuideNm = "�v���ĉc�Ə�";
                //section3.MainOfficeFuncFlag = 0;
                //secList.Add(section3);
                //this._bootPara.Propose_Para_Section = secList;

                #endregion

            }
            this.Show();
        }

        #endregion

        #region Private

        #region ���_���X�g�쐬
        /// <summary>
        /// ���_���X�g�쐬
        /// </summary>
        private void SetSection()
        {
            if (this._bootPara.BootMode == BootMode.SF)
            {
                // �����H�ꃂ�[�h�̏ꍇ�͖{�Ћ��_�@�\������ 
                Propose_Para_Section target = this._bootPara.Propose_Para_Section.Find(
                    delegate(Propose_Para_Section sec)
                    {
                        if (sec.SectionCode.TrimEnd() == this._bootPara.SectionCode.TrimEnd())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    });

                if (target != null)
                {
                    if (target.MainOfficeFuncFlag == 1)
                    {
                        // �{�Ћ@�\
                        foreach (Propose_Para_Section section in this._bootPara.Propose_Para_Section)
                        {
                            this.Section_ComboEditor.Items.Add(section.SectionCode, section.SectionGuideNm);
                        }
                    }
                    else
                    {
                        // ���_�@�\
                        this.Section_ComboEditor.Items.Add(target.SectionCode, target.SectionGuideNm);
                    }

                    // ���O�C�����_�������I��
                    this.Section_ComboEditor.Value = this._bootPara.SectionCode;
                }
            }
            else
            {
                // ���i�����[�h
                // PM�ɂ͖{�Ћ@�\�敪�̊T�O���Ȃ��A���[���őΉ����Ă���Ƃ̂���
                // ��Ƌ��_�A�������鋒�_�ł����o�^�͕s��

                bool loginExist = false;
                
                foreach (Propose_Para_Section section in this._bootPara.Propose_Para_Section)
                {
                    // ��Ƌ��_�A��������
                    if (this._scmSceDic.ContainsKey(section.SectionCode))
                    {
                        if (section.SectionCode.TrimEnd() == this._bootPara.SectionCode.TrimEnd())
                        {
                            loginExist = true;
                        }
                        this.Section_ComboEditor.Items.Add(section.SectionCode, section.SectionGuideNm);
                    }
                }
                // ���O�C�����_�ɗL����SCM�A���ݒ肪���݂��Ȃ��ꍇ�����邩������Ȃ��̂�
                if (loginExist)
                {
                    // ���O�C�����_�������I��
                    this.Section_ComboEditor.Value = this._bootPara.SectionCode;
                }
                else
                {
                    // ��Ƌ��_�A�����L���ȋ��_�͂��邪�A����̓��O�C�����_�ł͂Ȃ�
                    // ���O�C�����_�������I��
                    this.Section_ComboEditor.SelectedIndex = 0;

                    TMsgDisp.Show(
                      this,								                        // �e�E�B���h�E�t�H�[��
                      emErrorLevel.ERR_LEVEL_EXCLAMATION,	                    // �G���[���x��
                      CT_ASSEMBLYID,						                    // �A�Z���u��ID�܂��̓N���XID
                      "���݃��O�C�����̋��_�ɂ͗L���Ȓ�Đ悪����܂���B",
                      0,								                        // �X�e�[�^�X�l
                      MessageBoxButtons.OK);				                    // �\������{�^��

                }
            }
        }
        #endregion

        #region ���J��쐬
        /// <summary>
        /// ���_�ʌ��J�惊�X�g���쐬
        /// </summary>
        private void MakeCustomerList()
        {
            // ���i�����[�h�̏ꍇ�A��Ƌ��_�A���ݒ�����J������߂�
            if (this._bootPara.Propose_Para_SCM != null && this._bootPara.Propose_Para_SCM.Count > 0)
            {
                // �ڑ��L���`�F�b�N�́A���̎��_�Ŋ�Ƃ̐ڑ��L����������Ȃ��̂ŁA�ł��Ȃ��B
                // PM������ڑ����L���Ȃ��̂̂ݒ����B
                // ���Ԃ��ƘA���F0:�L���@AND�@���_�A���F0:�L���@AND�@(�ʐM����(SCM):1:����@OR �ʐM����(PCC-UOE):1����) RC�̂ݗL���Ƃ��̓_���H

                foreach (Propose_Para_SCM para in this._bootPara.Propose_Para_SCM)
                {
                    if (this._scmSceDic.ContainsKey(para.CnectOtherSecCd))
                    {
                        this._scmSceDic[para.CnectOtherSecCd].Add(para);
                    }
                    else
                    {
                        List<Propose_Para_SCM> wkList = new List<Propose_Para_SCM>();
                        wkList.Add(para);
                        this._scmSceDic.Add(para.CnectOtherSecCd, wkList);
                    }
                }
            }
            else
            {
                // �O���t�@�C���m�F
                if (File.Exists(Path.Combine(Directory.GetCurrentDirectory() ,"TBOConectInfo.xml")))
                {
                    Propose_Para_SCM[] localList = UserSettingController.DeserializeUserSetting<Propose_Para_SCM[]>(Path.Combine(Directory.GetCurrentDirectory() , "TBOConectInfo.xml"));

                    if(localList.Length > 0)
                    {
                        this._bootPara.Propose_Para_SCM = new List<Propose_Para_SCM>();
                        this._bootPara.Propose_Para_SCM.AddRange(localList);

                        // �\�����ʂŃ\�[�g
                        this._bootPara.Propose_Para_SCM.Sort(delegate(Propose_Para_SCM obj1, Propose_Para_SCM obj2)
                        {
                            return obj1.DisplayOrder.CompareTo(obj2.DisplayOrder);
                        });

                             foreach (Propose_Para_SCM para in this._bootPara.Propose_Para_SCM)
                        {
                            if (this._scmSceDic.ContainsKey(para.CnectOtherSecCd))
                            {
                                this._scmSceDic[para.CnectOtherSecCd].Add(para);
                            }
                            else
                            {
                                List<Propose_Para_SCM> wkList = new List<Propose_Para_SCM>();
                                wkList.Add(para);
                                this._scmSceDic.Add(para.CnectOtherSecCd, wkList);
                            }
                        }
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,								    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	    // �G���[���x��
                        CT_ASSEMBLYID,						    // �A�Z���u��ID�܂��̓N���XID
                        "�L���Ȓ�Đ悪����܂���B" 
                        + Environment.NewLine
                        + "�A�v���P�[�V�������I�����܂�",		// �\�����郁�b�Z�[�W 
                        -1,								        // �X�e�[�^�X�l
                        MessageBoxButtons.OK);				    // �\������{
                        this.Close();
                    }
                }
                else
                {
                    TMsgDisp.Show(
                        this,								    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	    // �G���[���x��
                        CT_ASSEMBLYID,						    // �A�Z���u��ID�܂��̓N���XID
                        "�L���Ȓ�Đ悪����܂���B" 
                        + Environment.NewLine
                        + "�A�v���P�[�V�������I�����܂�",		// �\�����郁�b�Z�[�W 
                        -1,								        // �X�e�[�^�X�l
                        MessageBoxButtons.OK);				    // �\������{

                    this.Close();
                }
            }
        }

        #endregion

        #region �J�e�S�����X�g�쐬
        /// <summary>
        /// �J�e�S�����X�g�쐬
        /// </summary>
        private void SetCategory()
        {
            this._categoryList = new List<GoodsCategory>();
            string errMsg = "";
            int st = this._TBOServiceACS.GetGoodsCategory(out this._categoryList, out errMsg);

            if (st == 0)
            {
                foreach (GoodsCategory category in this._categoryList)
                {
                    this.Category_ComboEditor.Items.Add(category.GoodsCategoryId, category.GoodsCategoryName);
                }

                // �����I���͍l���邪�Ƃ肠�����^�C��
                this.Category_ComboEditor.SelectedIndex = 0;
            }
            else
            {
                TMsgDisp.Show(
                     this,								            // �e�E�B���h�E�t�H�[��
                     emErrorLevel.ERR_LEVEL_STOPDISP,	            // �G���[���x��
                     CT_ASSEMBLYID,						            // �A�Z���u��ID�܂��̓N���XID
                     "���i�J�e�S�����̎擾�Ɏ��s���܂����B",		// �\�����郁�b�Z�[�W 
                     st,								            // �X�e�[�^�X�l
                     MessageBoxButtons.OK);				            // �\������{
            }
        }
        #endregion

        #region �t�������f�B�N�V���i���쐬

        #region ���i���p
        /// <summary>
        /// �t�������ݒ���擾
        /// </summary>
        private int SetAttendRepairSet()
        {
            int st = 0;
            List<AttendRepairSet> attendRepairSetList = new List<AttendRepairSet>();
            this._attendRepairSetDic.Clear();
            this._attendRepairColDic.Clear();

            string errMsg = "";

            // �t�������ݒ���擾
            st = this._TBOServiceACS.GetAttendRepairSet(this._bootPara.EnterpriseCode, out attendRepairSetList, out errMsg);

            if (st == 0)
            {
                foreach (AttendRepairSet attendRepairSet in attendRepairSetList)
                {
                    // �J�e�S����
                    if (this._attendRepairSetDic.ContainsKey(attendRepairSet.goodsCategoryId))
                    {
                        this._attendRepairSetDic[attendRepairSet.goodsCategoryId].Add(attendRepairSet);
                    }
                    else
                    {
                        List<AttendRepairSet> wkList = new List<AttendRepairSet>();
                        wkList.Add(attendRepairSet);
                        this._attendRepairSetDic.Add(attendRepairSet.goodsCategoryId, wkList);
                    }

                    // �J�e�S���ʗ񖼃��X�g(���i�����[�h�̏ꍇ�� COL_REPARE)
                    string colNm = MakeAttenRepairKey(attendRepairSet.attendRepairId.ToString());

                    if (this._attendRepairColDic.ContainsKey(attendRepairSet.goodsCategoryId))
                    {
                        this._attendRepairColDic[attendRepairSet.goodsCategoryId].Add(colNm);
                    }
                    else
                    {
                        List<string> colList = new List<string>();
                        colList.Add(colNm);
                        this._attendRepairColDic.Add(attendRepairSet.goodsCategoryId, colList);
                    }

                }
            }
            else
            {
                TMsgDisp.Show(
                     this,								            // �e�E�B���h�E�t�H�[��
                     emErrorLevel.ERR_LEVEL_STOPDISP,	            // �G���[���x��
                     CT_ASSEMBLYID,						            // �A�Z���u��ID�܂��̓N���XID
                     "�t�������ݒ���̎擾�Ɏ��s���܂����B",		// �\�����郁�b�Z�[�W 
                     st,								            // �X�e�[�^�X�l
                     MessageBoxButtons.OK);				            // �\������{
            }
            return st;
        }

        /// <summary>
        /// �t�������J�����̃L�[���쐬
        /// </summary>
        /// <param name="p"></param>
        private string MakeAttenRepairKey(string repairId)
        {
            return COL_REPARE + repairId;
        }

        #endregion

        #region �����H��p
        /// <summary>
        /// �t�������ݒ���擾
        /// </summary>
        private int SetAttendRepairSet_ModeSF(out string errMsg)
        {
            int st = 0;
            errMsg = "";
            List<AttendRepairSet> attendRepairSetList = new List<AttendRepairSet>();
            this._attendRepairSetDic.Clear();
            this._attendRepairColDic.Clear();

            // �t�������ݒ���擾
            st = this._TBOServiceACS.GetAttendRepairSetSF(this._bootPara.EnterpriseCode, this.Section_ComboEditor.Value.ToString(), (long)this.Category_ComboEditor.Value, out attendRepairSetList, out errMsg);
           
            if (st == 0)
            {
                foreach (AttendRepairSet attendRepairSet in attendRepairSetList)
                {
                    // �J�e�S����
                    if (this._attendRepairSetDic.ContainsKey(attendRepairSet.goodsCategoryId))
                    {
                        this._attendRepairSetDic[attendRepairSet.goodsCategoryId].Add(attendRepairSet);
                    }
                    else
                    {
                        List<AttendRepairSet> wkList = new List<AttendRepairSet>();
                        wkList.Add(attendRepairSet);
                        this._attendRepairSetDic.Add(attendRepairSet.goodsCategoryId, wkList);
                    }

                    // �J�e�S���ʗ񖼃��X�g �����H�ꃂ�[�h�̏ꍇ��COL_REPARE + storeAttendRepairId
                    string colNm = MakeAttenRepairKey(attendRepairSet.storeAttendRepairId.ToString());

                    if (this._attendRepairColDic.ContainsKey(attendRepairSet.goodsCategoryId))
                    {
                        if (!this._attendRepairColDic[attendRepairSet.goodsCategoryId].Contains(colNm))
                        {
                            this._attendRepairColDic[attendRepairSet.goodsCategoryId].Add(colNm);
                        }
                    }
                    else
                    {
                        List<string> colList = new List<string>();
                        colList.Add(colNm);
                        this._attendRepairColDic.Add(attendRepairSet.goodsCategoryId, colList);
                    }
                }
            }
            return st;
        }
        #endregion


        #endregion

        #region ���[�J�[���X�g�쐬
        /// <summary>
        /// ���[�J�[���X�g�쐬
        /// </summary>
        private void MakeMakerDic()
        {
            // �\�����ʂŃ\�[�g
            this._bootPara.Propose_Para_Maker.Sort(delegate(Propose_Para_Maker obj1, Propose_Para_Maker obj2)
            {
                return obj1.DisplayOrder.CompareTo(obj2.DisplayOrder);
            });
            foreach (Propose_Para_Maker maker in this._bootPara.Propose_Para_Maker)
            {
                // ���[�J�[�R�[�h�f�B�N�V���i��
                if (!this._makerCdDic.ContainsKey(maker.GoodsMakerCd))
                {
                    this._makerCdDic.Add(maker.GoodsMakerCd, maker);
                }
            }
        }
        #endregion

        #region �f�[�^�e�[�u���쐬
        /// <summary>
        /// �f�[�^�e�[�u���쐬
        /// </summary>
        private void MakeDataSet()
        {
            // ���i�e�[�u��(����)
            DataTable tboTable = new DataTable(TABLE_MAIN);

            tboTable.Columns.Add(COL_DEL, typeof(Int32));            // �폜�敪   
            tboTable.Columns.Add(COL_SORTNO, typeof(Int32));        // �\�[�g��
            tboTable.Columns.Add(COL_RELEASE, typeof(bool));        // ���J      
            tboTable.Columns.Add(COL_RECOMMEND, typeof(bool));      // �I�X�X��
            tboTable.Columns.Add(COL_GOODSNO, typeof(string));      // �i��  

            tboTable.Columns.Add(COL_BLCD, typeof(Int32));          // BL�R�[�h  
            tboTable.Columns.Add(COL_BLCDBR, typeof(Int32));        // BL�R�[�h�}��

            tboTable.Columns.Add(COL_MAKERTITLE, typeof(string));   // ���[�J�[�^�C�g��  
            tboTable.Columns.Add(COL_MAKERCD, typeof(Int32));       // ���i���[�J�[CD
            tboTable.Columns.Add(COL_MAKERGD, typeof(string));      // ���i���[�J�[�K�C�h 
            tboTable.Columns.Add(COL_MAKERNM, typeof(string));      // ���i���[�J�[����

            // �J�e�S�����̃L�[
            // �^�C��
            tboTable.Columns.Add(COL_TIRE_KEY1, typeof(string));    // �T�C�Y
            tboTable.Columns.Add(COL_TIRE_KEY2, typeof(bool));      // �X�^�b�h���X
            // �o�b�e��
            tboTable.Columns.Add(COL_BATTERY_KEY1, typeof(string)); // �K�i
            tboTable.Columns.Add(COL_BATTERY_KEY2, typeof(Int32)); // �K��(1:�ʏ�,2:ISS,3:���p)
            // �I�C��
            tboTable.Columns.Add(COL_OIL_KEY1, typeof(string));     // �S�x
            tboTable.Columns.Add(COL_OIL_KEY2, typeof(Int32));     // �K��(1:�K�\�����A2:�f�B�[�[���A3�F���p)

            tboTable.Columns.Add(COL_IMAGE_NO, typeof(long));      // �摜��
            tboTable.Columns.Add(COL_IMAGE, typeof(Image));         // �摜
            tboTable.Columns.Add(COL_IMAGE_GUIDE, typeof(string));  // �摜�K�C�h
            tboTable.Columns.Add(COL_IMAGE_CHANGE, typeof(int));    // �摜�ύX�敪
            
            
            tboTable.Columns.Add(COL_GOODSNM, typeof(string));      // ���i����
            tboTable.Columns.Add(COL_GOODSNOTE, typeof(string));    // ���i����
            tboTable.Columns.Add(COL_GOODSPR, typeof(string));      // ���iPR

            tboTable.Columns.Add(COL_RELEASEDATE, typeof(DateTime));    // ������

            tboTable.Columns.Add(COL_STOCKCOUNT, typeof(Double));      // �݌ɐ�
            tboTable.Columns.Add(COL_STOCKSTATE, typeof(Int32));       // �݌ɏ��

            tboTable.Columns.Add(COL_SHOPSALEBEGINDATE, typeof(DateTime));  // ���J�J�n��
            tboTable.Columns.Add(COL_SHOPSALEENDDATE, typeof(DateTime));    // ���J�I����

            // �����H��J����
            tboTable.Columns.Add(COL_SF_TITLE, typeof(string));      // �^�C�g��SF
            tboTable.Columns.Add(COL_SUGGEST_PRICE, typeof(long));   // ��]�������i
            tboTable.Columns.Add(COL_SHOP_PRICE, typeof(long));     // �X�����i 

            // ������ێ�
            this._repairCount = 0;


            // �t������
            if (this._attendRepairSetDic.ContainsKey((long)this.Category_ComboEditor.Value))
            {
                List<AttendRepairSet> setList = this._attendRepairSetDic[(long)this.Category_ComboEditor.Value];
                for (int i = 0; i < setList.Count; i++)
                {
                    string key = "";
                    if (this._bootPara.BootMode == BootMode.PM)
                    {
                        // ���i�����[�h�˕t������ID���L�[�Ƃ���
                        key = MakeAttenRepairKey(setList[i].attendRepairId.ToString());
                    }
                    else
                    {
                        // �����H�ꃂ�[�h�˓X�ܕt������ID���L�[�Ƃ���
                        key = MakeAttenRepairKey(setList[i].storeAttendRepairId.ToString());
                    }

                    if (!tboTable.Columns.Contains(key))
                    {
                        tboTable.Columns.Add(key, typeof(long));  // �t������ix
                        tboTable.Columns[key].DefaultValue = setList[i].repairPrice;  // �����l
                    }
                    this._repairCount++;
                }
            }

            // ���v��
            tboTable.Columns.Add(COL_MONEY_TOTAL, typeof(long));      // ���z

            tboTable.Columns.Add(COL_GROSS_SF, typeof(long));           // �e��(�����H��)   
            tboTable.Columns.Add(COL_GROSSMARGIN_SF, typeof(string));   // �e����(�����H��) 

            // ���i���J����
            tboTable.Columns.Add(COL_PM_TITLE, typeof(string));         // �^�C�g��PM
            tboTable.Columns.Add(COL_TRADE_PRICE, typeof(long));        // ���l�i�����H��̎d�������j
            tboTable.Columns.Add(COL_PURCHASE_COST, typeof(long));      // �d������(���i���̎d������) PM��double�₯�ǁA�l�̌ܓ�����
            tboTable.Columns.Add(COL_GROSS_PM, typeof(long));           // �e��(���i��)  
            tboTable.Columns.Add(COL_GROSSMARGIN_PM, typeof(string));   // �e����(���i��)  
            tboTable.Columns.Add(COL_INDIVIDUAL, typeof(string));       // �ʐݒ�
            tboTable.Columns.Add(COL_PM_UPDATETIME, typeof(long));      // PM�݌ɍX�V��
            tboTable.Columns.Add(COL_POSTPARACLASS, typeof(object));    // ���i���POST�p�����[�^�N���X

            // �����l
            tboTable.Columns[COL_DEL].DefaultValue = 0;
            tboTable.Columns[COL_RELEASE].DefaultValue = true;
            tboTable.Columns[COL_RECOMMEND].DefaultValue = false;
            tboTable.Columns[COL_GOODSNO].DefaultValue = "";

            tboTable.Columns[COL_BLCD].DefaultValue = 0;
            tboTable.Columns[COL_BLCDBR].DefaultValue = 0;

            tboTable.Columns[COL_MAKERCD].DefaultValue = 0;
            tboTable.Columns[COL_MAKERNM].DefaultValue = "";
            tboTable.Columns[COL_GOODSNM].DefaultValue = "";
            tboTable.Columns[COL_GOODSNOTE].DefaultValue = "";
            tboTable.Columns[COL_GOODSPR].DefaultValue = "";
            tboTable.Columns[COL_TIRE_KEY1].DefaultValue = "";
            tboTable.Columns[COL_TIRE_KEY2].DefaultValue = false;
            tboTable.Columns[COL_BATTERY_KEY1].DefaultValue = "";
            tboTable.Columns[COL_BATTERY_KEY2].DefaultValue = 1;
            tboTable.Columns[COL_OIL_KEY1].DefaultValue = "";
            tboTable.Columns[COL_OIL_KEY2].DefaultValue = 1;
            tboTable.Columns[COL_IMAGE_NO].DefaultValue = 0;
            tboTable.Columns[COL_IMAGE_CHANGE].DefaultValue = 0;
            tboTable.Columns[COL_STOCKCOUNT].DefaultValue = 0;
            tboTable.Columns[COL_STOCKSTATE].DefaultValue = -1;
            tboTable.Columns[COL_SUGGEST_PRICE].DefaultValue = 0;
            tboTable.Columns[COL_MONEY_TOTAL].DefaultValue = 0;
            tboTable.Columns[COL_SHOP_PRICE].DefaultValue = 0;
            tboTable.Columns[COL_GROSS_SF].DefaultValue = 0;
            tboTable.Columns[COL_GROSSMARGIN_SF].DefaultValue = "";
            tboTable.Columns[COL_TRADE_PRICE].DefaultValue = 0;
            tboTable.Columns[COL_PURCHASE_COST].DefaultValue = 0;
            tboTable.Columns[COL_GROSS_PM].DefaultValue = 0;
            tboTable.Columns[COL_GROSSMARGIN_PM].DefaultValue = "";
            tboTable.Columns[COL_SHOPSALEBEGINDATE].DefaultValue = this._releaseStDate; // ���J�J�n��


            this.TBODataSet.Tables.Add(tboTable);
        }
        #endregion

        #region �e�[�u���f�[�^�Z�b�g����
        /// <summary>
        /// �f�[�^�e�[�u���Z�b�g����
        /// </summary>
        /// <param name="retList"></param>
        private void SetDataTable(List<ProposeGoods> retList)
        {
            // �e�[�u����������
            if (this.TBODataSet.Tables.Contains(TABLE_MAIN))
            {
                this.TBODataSet.Tables.Remove(TABLE_MAIN);
            }

            // �e�[�u���쐬
            this.MakeDataSet();

            // �f�[�^���Z�b�g
            foreach (ProposeGoods proposeGoods in retList)
            {
                DataRow row = this.TBODataSet.Tables[TABLE_MAIN].NewRow();

                // �摜
                row[COL_IMAGE_NO] = proposeGoods.imageId;
                row[COL_IMAGE] = proposeGoods.image_Data;
                row[COL_DEL] = proposeGoods.logicalDelDiv;          // �_���폜�敪
                row[COL_SORTNO] = proposeGoods.sortNo;              // �\�[�g��
                row[COL_RELEASE] = proposeGoods.releaseFlag;        // ���J�t���O
                row[COL_RECOMMEND] = proposeGoods.recommendFlag;    // �I�X�X���t���O

                // �^�O
                if (proposeGoods.goodsTagList != null)
                {
                    switch (proposeGoods.goodsCategoryId)
                    {
                        case 1: // �^�C��          
                            for (int i = 0; i < proposeGoods.goodsTagList.Length; i++)
                            {
                                if (proposeGoods.goodsTagList[i].tagNo == 1)
                                {
                                    row[COL_TIRE_KEY1] = proposeGoods.goodsTagList[i].tag;
                                }
                                else if (proposeGoods.goodsTagList[i].tagNo == 2)
                                {
                                    row[COL_TIRE_KEY2] = proposeGoods.goodsTagList[i].tag.Equals("0") ? false : true;
                                }
                            }
                            break;
                        case 2: // �o�b�e��
                            string bTag2 = "";
                            string bTag3 = "";
                            for (int i = 0; i < proposeGoods.goodsTagList.Length; i++)
                            {
                                if (proposeGoods.goodsTagList[i].tagNo == 1)
                                {
                                    row[COL_BATTERY_KEY1] = proposeGoods.goodsTagList[i].tag;
                                }
                                else if (proposeGoods.goodsTagList[i].tagNo == 2)
                                {
                                    bTag2 = proposeGoods.goodsTagList[i].tag;
                                }
                                else if (proposeGoods.goodsTagList[i].tagNo == 3)
                                {
                                    bTag3 = proposeGoods.goodsTagList[i].tag;
                                }
                            }
                            if (bTag2 == "0")
                            {
                                if (bTag3 == "1")
                                {
                                    // ISS�Ԑ�p
                                    row[COL_BATTERY_KEY2] = 2;
                                }
                                else
                                {
                                    // ���肦�Ȃ����W���Ԑ�p�Ƃ���
                                    row[COL_BATTERY_KEY2] = 1;
                                }
                            }
                            else
                            {
                                if (bTag3 == "1")
                                {
                                    // ���p
                                    row[COL_BATTERY_KEY2] = 3;
                                }
                                else
                                {
                                    // �W���Ԑ�p
                                    row[COL_BATTERY_KEY2] = 1;
                                }
                            }
                            break;
                        case 3: // �I�C��
                            string oTag2 = "";
                            string oTag3 = "";
                            for (int i = 0; i < proposeGoods.goodsTagList.Length; i++)
                            {
                                if (proposeGoods.goodsTagList[i].tagNo == 1)
                                {
                                    row[COL_OIL_KEY1] = proposeGoods.goodsTagList[i].tag;
                                }
                                else if (proposeGoods.goodsTagList[i].tagNo == 2)
                                {
                                    oTag2 = proposeGoods.goodsTagList[i].tag;
                                }
                                else if (proposeGoods.goodsTagList[i].tagNo == 3)
                                {
                                    oTag3 = proposeGoods.goodsTagList[i].tag;
                                }
                            }
                            if (oTag2 == "0")
                            {
                                if (oTag3 == "1")
                                {
                                    // �f�B�[�[���Ԑ�p
                                    row[COL_OIL_KEY2] = 2;
                                }
                                else
                                {
                                    // ���肦�Ȃ����K�\�����Ԑ�p���Z�b�g
                                    row[COL_OIL_KEY2] = 1;
                                }
                            }
                            else
                            {
                                if (oTag3 == "1")
                                {
                                    // ���p
                                    row[COL_OIL_KEY2] = 3;
                                }
                                else
                                {
                                    // �K�\�����Ԑ�p
                                    row[COL_OIL_KEY2] = 1;
                                }
                            }
                            break;
                    }
                }

                row[COL_GOODSNOTE] = proposeGoods.goodsNote;        // ���i����
                row[COL_GOODSPR] = proposeGoods.goodsPr;            // ���iPR
                row[COL_MAKERCD] = proposeGoods.pmMakerCode;        // �i��
                row[COL_MAKERNM] = proposeGoods.makerName;          // ���[�J�[����
                row[COL_GOODSNO] = proposeGoods.partsNumber;        // �i��
                row[COL_GOODSNM] = proposeGoods.proposeGoodsName;   // ���i����
                row[COL_PM_UPDATETIME] = proposeGoods.pmUpdDtTime;  // PM�݌ɍX�V����

                if (!String.IsNullOrEmpty(proposeGoods.releaseDate))
                {
                    try
                    {
                        row[COL_RELEASEDATE] = DateTime.Parse(proposeGoods.releaseDate); // ������

                    }
                    catch
                    {

                    }
                }

                // ���J�J�n��
                if (!String.IsNullOrEmpty(proposeGoods.shopSaleBeginDate))
                {
                    try
                    {
                        row[COL_SHOPSALEBEGINDATE] = DateTime.Parse(proposeGoods.shopSaleBeginDate); // ������

                    }
                    catch
                    {

                    }
                }

                // ���J�I����
                if (!String.IsNullOrEmpty(proposeGoods.shopSaleEndDate))
                {
                    try
                    {
                        row[COL_SHOPSALEENDDATE] = DateTime.Parse(proposeGoods.shopSaleEndDate); // ������

                    }
                    catch
                    {

                    }
                }


                row[COL_SUGGEST_PRICE] = proposeGoods.suggestPrice; // �W�����i
                row[COL_SHOP_PRICE] = proposeGoods.shopPrice;      // �X�����i
                row[COL_TRADE_PRICE] = proposeGoods.tradePrice;     // ���l
                row[COL_PURCHASE_COST] = proposeGoods.purchaseCost; // �d������
                row[COL_STOCKSTATE] = proposeGoods.stockState;      // �݌ɏ��
                row[COL_POSTPARACLASS] = proposeGoods;              // ���i���

                // �t������
                // �o�^�����f�[�^(proposeGoods.attendRepairList)�̌��f�[�^�t�������ݒ�A�X�ܕt�������ݒ肪������Ă�ƁA���܂�̂ŁA�ŐV�̐ݒ�ɂ�����̂̂ݕ\������
                
                // �ŐV�̃}�X�^�ݒ�����Ƀf�[�^�𕜌�
                if (this._attendRepairSetDic.Count > 0)
                {
                    if (this._attendRepairSetDic.ContainsKey((long)this.Category_ComboEditor.Value))
                    {
                        Dictionary<long, long> monyDic = new Dictionary<long, long>();
                        if (proposeGoods.attendRepairList != null && proposeGoods.attendRepairList.Length > 0)
                        {
                            for (int i = 0; i < proposeGoods.attendRepairList.Length; i++)
                            {
                                // ���i�����[�h�FproposeGoods.attendRepairId�ɕt�������ݒ��attendRepairId���Z�b�g����Ă�
                                // �����H�ꃂ�[�h�FproposeGoods.attendRepairId�ɓX�ܕt�������ݒ��storeAttendRepairId���Z�b�g����Ă�
                                if (!monyDic.ContainsKey(proposeGoods.attendRepairList[i].attendRepairId))
                                {
                                    // ���ɓo�^�ς݂̕t���������z���i�[
                                    monyDic.Add(proposeGoods.attendRepairList[i].attendRepairId, proposeGoods.attendRepairList[i].repairPrice);
                                }
                            }
                        }

                        List<AttendRepairSet> list = this._attendRepairSetDic[(long)this.Category_ComboEditor.Value];
                        for (int i = 0; i < list.Count; i++)
                        {
                            // �f�[�^��̕t������ID���ݒ�ɂ��邩�`�F�b�N�A�ݒ�ɂ���ꍇ�͋��z���Z�b�g
                            // �匳�̕t�������ݒ�f�[�^�������Ă��邩�m�F
                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                if (monyDic.ContainsKey(list[i].attendRepairId))
                                {
                                    row[MakeAttenRepairKey(list[i].attendRepairId.ToString())] = monyDic[list[i].attendRepairId];
                                }
                            }
                            else
                            {
                                if (monyDic.ContainsKey(list[i].storeAttendRepairId))
                                {
                                    row[MakeAttenRepairKey(list[i].storeAttendRepairId.ToString())] = monyDic[list[i].storeAttendRepairId];
                                }
                            }
                        }
                    }
                }

                // �e�����v�Z

                // �t��������L��
                bool existRepair = false;

                // �t���������z
                long repareTotal = 0;
                foreach (DataColumn col in this.TBODataSet.Tables[TABLE_MAIN].Columns)
                {
                    if (col.ColumnName.Contains(COL_REPARE))
                    {
                        existRepair = true;
                        repareTotal += (long)row[col.ColumnName];
                    }
                }

                // �t��������L��
                if (existRepair)
                {
                    row[COL_MONEY_TOTAL] = proposeGoods.shopPrice + repareTotal;
                }

                // �����H��̑e�����Čv�Z
                long grossSF = 0;
                string grossMarginSF = "";
                this.CalcGrossSF(proposeGoods.shopPrice, repareTotal, proposeGoods.tradePrice, out grossSF, out grossMarginSF);
                // �v�Z���ʂ�W�J
                row[COL_GROSS_SF] = grossSF;
                row[COL_GROSSMARGIN_SF] = grossMarginSF;

                // ���i�����[�h
                if (this._bootPara.BootMode == BootMode.PM)
                {
                    // ���i���̑e�����Čv�Z
                    long grossPM = 0;
                    long cost = (long)proposeGoods.purchaseCost;
                    string grossMarginPM = "";
                    this.CalcGrossPM(proposeGoods.tradePrice, cost, out grossPM, out grossMarginPM);
                    // �v�Z���ʂ�W�J
                    row[COL_GROSS_PM] = grossPM;
                    row[COL_GROSSMARGIN_PM] = grossMarginPM;
                }
                this.TBODataSet.Tables[TABLE_MAIN].Rows.Add(row);
            }

            this.Goods_Grid.DataSource = this.TBODataSet.Tables[TABLE_MAIN];

            this.UpDateGrid();
        }
        #endregion

        #region �I�X�X��
        /// <summary>
        /// �I�X�X���ݒ�
        /// </summary>
        /// <param name="count">�I�X�X������</param>
        /// <param name="target">1:���i��,2:�����H��</param>
        private void SetRecommend(int count, int target)
        {
            // �f�[�^��0���̏ꍇ�̓X���[
            if (this.Goods_Grid.Rows.Count > 0)
            {
                // �܂��S�ẴI�X�X�����O��
                foreach (DataRow row in this.TBODataSet.Tables[TABLE_MAIN].Rows)
                {
                    // �폜���͑ΏۊO
                    if (GetCellInt32(row[COL_DEL], 0) == 1)
                    {
                        continue;
                    }
                    row[COL_RECOMMEND] = false;
                }

                string GROSSCOL = COL_GROSS_SF;

                if (this._bootPara.BootMode == BootMode.PM && target == 1)
                {
                    // ���i�����[�h�ŕ��i���̑e������������
                    GROSSCOL = COL_GROSS_PM;
                }

                string TARGETCOL = "";
                switch ((long)this.Category_ComboEditor.Value)
                {
                    case 1:
                        TARGETCOL = COL_TIRE_KEY1;
                        break;
                    case 2:
                        TARGETCOL = COL_BATTERY_KEY1;
                        break;
                    case 3:
                        TARGETCOL = COL_OIL_KEY1;
                        break;
                }

                // ���i�^�O�P�ŋ[��GROUPBY���s��
                DataView wkView = new DataView(this.TBODataSet.Tables[TABLE_MAIN]);
                DataTable wkTable = wkView.ToTable(true, new string[] { TARGETCOL });

                foreach (DataRow wkRow in wkTable.Rows)
                {
                    StringBuilder cndString = new StringBuilder();
                    string val = wkRow[TARGETCOL].ToString();
                    cndString.Append(String.Format("{0}={1} AND {2}='{3}'", COL_DEL, 0, TARGETCOL, val));
                    string sort = GROSSCOL + " DESC";
                    try
                    {
                        DataRow[] rows = this.TBODataSet.Tables[TABLE_MAIN].Select(cndString.ToString(), sort);
                        if (rows != null)
                        {
                            for (int i = 0; i < rows.Length; i++)
                            {
                                if (i == count) break;
                                rows[i][COL_RECOMMEND] = true;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }
        #endregion

        #region Enable����

        /// <summary>
        /// �{�^������
        /// </summary>
        /// <param name="enabled"></param>
        private void SetSpButtonEnabled(bool enabled)
        {
            this.AddRow_button.Enabled = enabled;
            this.Recommend_button.Enabled = enabled;
            this.CalcPrice_Button.Enabled = enabled;
        }

        /// <summary>
        /// �s�폜�{�^��Enabled�ݒ菈��
        /// </summary>
        /// <remarks>
        /// </remarks>
        private void SetRowDelEnabled()
        {
            if (this.Goods_Grid.Selected.Rows.Count > 0)
            {
                this.Del_button.Enabled = true;
            }
            else
            {
                this.Del_button.Enabled = false;
            }
        }
        #endregion

        #region �`�F�b�N����

        #region ���̓`�F�b�N

        /// <summary>
        /// ���[�j���O�`�F�b�N
        /// </summary>
        /// <returns></returns>
        private bool DataWarningCheck()
        {
            // �K�{�ł͂Ȃ����ǁA���͂��Ȃ��Ƃ܂������낤�Ƃ������̂��`�F�b�N

            bool ret = true;
            string errMsg = "";
            string columnNm = "";
            int rowIndex = 0;
            // �O���b�h���̓`�F�b�N
            if (!GridWarningCheck(out errMsg, out columnNm, out rowIndex))
            {
                // ���b�Z�[�W��\��
                DialogResult rlt = TMsgDisp.Show(
                   this,							        // �e�E�B���h�E�t�H�[��
                   emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                   CT_ASSEMBLYID,					        // �A�Z���u��ID�܂��̓N���XID
                   errMsg, 	                                // �\�����郁�b�Z�[�W 
                   0,								        // �X�e�[�^�X�l
                   MessageBoxButtons.OKCancel);

                if (rlt == DialogResult.Cancel)
                {
                    ret = false;
                    this.Goods_Grid.ActiveCell = this.Goods_Grid.Rows[rowIndex].Cells[columnNm];
                    this.Goods_Grid.ActiveCell.Activate();
                    this.Goods_Grid.ActiveCell.Selected = true;
                    this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                    this.Goods_Grid.DisplayLayout.ColScrollRegions[0].ScrollCellIntoView(this.Goods_Grid.ActiveCell, this.Goods_Grid.DisplayLayout.RowScrollRegions[0]);
                   
                }
            }
            return ret;

        }

        /// <summary>
        /// ���[�j���O�`�F�b�N
        /// </summary>
        /// <param name="errMsg"></param>
        /// <param name="columnNm"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private bool GridWarningCheck(out string errMsg, out string columnNm, out int rowIndex)
        {
            bool result = true;
            errMsg = "";
            columnNm = "";
            rowIndex = 0;
            //�O���b�h�̃A�b�v�f�[�g
            this.UpDateGrid();

            errMsg = "�ȉ��̏��i�����݂��܂��B" + Environment.NewLine + "���̂܂ܓo�^���Ă���낵���ł����H";

            bool noInputFlag = false;
            bool minusFlag = false;
            int rowIndexNoinput = -1;
            int rowIndexMinus = -1;
            string ColNmNoinput = "";
            string ColNmMinus = "";

            for (int ix = 0; ix < this.Goods_Grid.Rows.Count; ix++)
            {
                UltraGridRow ugRow = this.Goods_Grid.Rows[ix];

                if (noInputFlag == false)
                {
                    // �W�����i
                    if (GetCellLong(ugRow.Cells[COL_SUGGEST_PRICE].Value, 0) == 0)
                    {
                        rowIndexNoinput = ix;
                        ColNmNoinput = COL_SUGGEST_PRICE;
                        noInputFlag = true;
                    }
                }

                if (noInputFlag == false)
                {
                    // �X�����i
                    if (GetCellLong(ugRow.Cells[COL_SHOP_PRICE].Value, 0) == 0)
                    {
                        rowIndexNoinput = ix;
                        ColNmNoinput = COL_SHOP_PRICE;
                        noInputFlag = true;
                    }
                }

                if (noInputFlag == false)
                {
                    // �t������
                    if (this._attendRepairSetDic.ContainsKey((long)this.Category_ComboEditor.Value))
                    {
                        List<AttendRepairSet> setList = this._attendRepairSetDic[(long)this.Category_ComboEditor.Value];
                        for (int i = 0; i < setList.Count; i++)
                        {
                            string key = "";
                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                key = this.MakeAttenRepairKey(setList[i].attendRepairId.ToString());
                            }
                            else
                            {
                                key = this.MakeAttenRepairKey(setList[i].storeAttendRepairId.ToString());
                            }

                            if (this.Goods_Grid.DisplayLayout.Bands[0].Columns.Exists(key))
                            {
                                if (GetCellLong(ugRow.Cells[key].Value, 0) == 0)
                                {
                                    rowIndexNoinput = ix;
                                    ColNmNoinput = key;
                                    noInputFlag = true;
                                }
                            }
                        }
                    }
                }

                if (noInputFlag == false)
                {
                    // �̔����i
                    if (GetCellLong(ugRow.Cells[COL_TRADE_PRICE].Value, 0) == 0)
                    {
                        rowIndexNoinput = ix;
                        ColNmNoinput = COL_TRADE_PRICE;
                        noInputFlag = true;
                    }
                }

                if (noInputFlag == false)
                {
                    // ���i�����[�h�̏ꍇ
                    if (this._bootPara.BootMode == BootMode.PM)
                    {
                        // �d������
                        if (GetCellLong(ugRow.Cells[COL_PURCHASE_COST].Value, 0) == 0)
                        {
                            rowIndexNoinput = ix;
                            ColNmNoinput = COL_PURCHASE_COST;
                            noInputFlag = true;
                        }
                    }
                }

                if (!minusFlag)
                {
                    // �e��(�����H��)
                    if (GetCellLong(ugRow.Cells[COL_GROSS_SF].Value, 0) <= 0)
                    {
                        rowIndexMinus = ix;
                        ColNmMinus = COL_GROSS_SF;
                        minusFlag = true;
                    }
                }

                if (!minusFlag)
                {
                    // ���i�����[�h�̏ꍇ
                    if (this._bootPara.BootMode == BootMode.PM)
                    {
                        if (GetCellLong(ugRow.Cells[COL_GROSS_PM].Value, 0) <= 0)
                        {
                            rowIndexMinus = ix;
                            ColNmMinus = COL_GROSS_PM;
                            minusFlag = true;
                        }
                    }
                }

                if (noInputFlag && minusFlag)
                {
                    break;
                }
            }

            if (noInputFlag || minusFlag)
            {
                if (noInputFlag)
                {
                    errMsg += Environment.NewLine + "�E���z��������";
                }

                if (minusFlag)
                {
                    errMsg += Environment.NewLine + "�E�e����0�~�ȉ�";
                }

                if (rowIndexNoinput == -1)
                {
                    rowIndex = rowIndexMinus;
                    columnNm = ColNmMinus;
                }
                else if (rowIndexMinus == -1)
                {
                    rowIndex = rowIndexNoinput;
                    columnNm = ColNmNoinput;
                }
                else if (rowIndexNoinput > rowIndexMinus)
                {
                    rowIndex = rowIndexMinus;
                    columnNm = ColNmMinus;
                }
                else
                {
                    rowIndex = rowIndexNoinput;
                    columnNm = ColNmNoinput;
                }
                return false;
            }
            return result;
        }

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

                this.Goods_Grid.ActiveCell = this.Goods_Grid.Rows[rowIndex].Cells[columnNm];
                this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
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

            // ���̓`�F�b�N
            for (int ix = 0; ix < this.Goods_Grid.Rows.Count; ix++)
            {
                UltraGridRow ugRow = this.Goods_Grid.Rows[ix];

                // �����̓`�F�b�N  �i��
                if (String.IsNullOrEmpty(GetCellString(ugRow.Cells[COL_GOODSNO].Value, "")))
                {
                    rowIndex = ix;
                    errMsg = "�i�Ԃ���͂��ĉ������B";
                    columnNm = COL_GOODSNO;
                    return false;
                }

                // �����̓`�F�b�N ���[�J�[ 
                // SF�̏ꍇ�񋟂̃��[�J�[�����I���ł��Ȃ��̂ŁA���[�J�[���̂̎���͂��\�Ƃ���
                // ����ă��[�J�[���̂ɂă`�F�b�N����
                if (String.IsNullOrEmpty(GetCellString(ugRow.Cells[COL_MAKERNM].Value, "")))
                {
                    rowIndex = ix;
                    errMsg = "���[�J�[����͂��ĉ������B";
                    columnNm = COL_MAKERNM;
                    return false;
                }

                // �����̓`�F�b�N ���i
                if (String.IsNullOrEmpty(GetCellString(ugRow.Cells[COL_GOODSNM].Value, "")))
                {
                    rowIndex = ix;
                    errMsg = "���i���̂���͂��ĉ������B";
                    columnNm = COL_GOODSNM;
                    return false;
                }

                // ���i���J��
                if (ugRow.Cells[COL_SHOPSALEBEGINDATE].Value == DBNull.Value)
                {
                    rowIndex = ix;
                    errMsg = "���J�J�n������͂��ĉ������B";
                    columnNm = COL_SHOPSALEBEGINDATE;
                    return false;
                }

                // ���i���J�� > ���i�I�����`�F�b�N
                if (ugRow.Cells[COL_SHOPSALEBEGINDATE].Value != DBNull.Value && ugRow.Cells[COL_SHOPSALEENDDATE].Value != DBNull.Value)
                {
                    if(((DateTime)ugRow.Cells[COL_SHOPSALEBEGINDATE].Value) > (((DateTime)ugRow.Cells[COL_SHOPSALEENDDATE].Value)))
                    {
                        rowIndex = ix;
                        errMsg = "���J�J�n�������J�I������薢���̓��t�ɂȂ��Ă��܂��B";
                        columnNm = COL_SHOPSALEBEGINDATE;
                        return false;
                    }
                }
            }

            // �d���`�F�b�N
            string mkNm = "";
            string goodsNo = "";
            Dictionary<string, int> overlapDic = new Dictionary<string, int>();
            for (int ix = 0; ix < this.Goods_Grid.Rows.Count; ix++)
            {
                UltraGridRow ugRow = this.Goods_Grid.Rows[ix];

                mkNm = GetCellString(ugRow.Cells[COL_MAKERNM].Value, "");
                goodsNo = GetCellString(ugRow.Cells[COL_GOODSNO].Value, "");
                string key = mkNm + ctSeparator + goodsNo;
                if (overlapDic.ContainsKey(key))
                {
                    // �d��
                    int befIndex = overlapDic[key];
                    if (this.Goods_Grid.Rows[befIndex].Cells[COL_GOODSNO].Activation == Activation.NoEdit)
                    {
                        rowIndex = ix;
                        errMsg = "�i�Ԃ��d�����Ă��܂��B" + Environment.NewLine + "�i�ԁF" + goodsNo;
                        columnNm = COL_GOODSNO;
                        return false;
                    }
                    else
                    {
                        rowIndex = befIndex;
                        errMsg = "�i�Ԃ��d�����Ă��܂��B" + Environment.NewLine + "�i�ԁF" + goodsNo;
                        columnNm = COL_GOODSNO;
                        return false;
                    }
                }
                else
                {
                    overlapDic.Add(key, ix);
                }
            }
            return result;
        }
        #endregion

        #region �f�[�^�ύX�`�F�b�N

        /// <summary>
        /// �f�[�^�ύX�`�F�b�N
        /// </summary>
        /// <returns></returns>
        private bool CheckUpDate()
        {
            bool result = true;

            if (this.Goods_Grid.DataSource == null) return true;

            // �X�V�`�F�b�N
            if (!CheckUpDateProc())
            {
                DialogResult ret = TMsgDisp.Show(
                   this,								        // �e�E�B���h�E�t�H�[��
                   emErrorLevel.ERR_LEVEL_EXCLAMATION,	        // �G���[���x��
                   CT_ASSEMBLYID,						        // �A�Z���u��ID�܂��̓N���XID
                   "���݁A�ҏW���̃f�[�^�����݂��܂�"
                   + Environment.NewLine
                   + "�o�^���Ă���낵���ł����H",   		    // �\�����郁�b�Z�[�W 
                   0,								            // �X�e�[�^�X�l
                   MessageBoxButtons.YesNoCancel);				// �\������{�^��

                if (ret == DialogResult.Yes)
                {
                    // �ۑ�����
                    int st = this.SaveProc();
                    if (st != 0)
                    {
                        return false;
                    }
                }
                else if (ret == DialogResult.Cancel)
                {
                    return false;
                }
            }
            return result;
        }

        /// <summary>
        /// �f�[�^�ύX�`�F�b�N
        /// </summary>
        /// <returns></returns>
        private bool CheckUpDateProc()
        {
            bool ret = true;

            // �f�[�^���X�V����Ă��邩�`�F�b�N
            this.UpDateGrid();
            this.TBODataSet.Tables[TABLE_MAIN].AcceptChanges();

            // �ۑ��f�[�^���쐬
            List<ProposeGoods> saveList = new List<ProposeGoods>();
            List<ProposeGoods> delList = new List<ProposeGoods>();
            this.MakeSaveData(0, out saveList, out delList);

            // �f�[�^���e��r
            for (int i = 0; i < this.TBODataSet.Tables[TABLE_MAIN].Rows.Count; i++)
            {
                DataRow row = this.TBODataSet.Tables[TABLE_MAIN].Rows[i];

                // �摜�ύX�`�F�b�N
                if ((int)row[COL_IMAGE_CHANGE] == 1)
                {
                    return false;
                }

                if (row[COL_POSTPARACLASS] == DBNull.Value)
                {
                    // �V�K�s
                    return false;
                }
                else
                {
                    if ((int)row[COL_DEL] == 1)
                    {
                        // �ۑ��ύs���폜����Ă���
                        return false;
                    }
                    else
                    {
                        ProposeGoods befGoods = (ProposeGoods)row[COL_POSTPARACLASS];
                        ProposeGoods afGoods = saveList.Find(
                            delegate(ProposeGoods wkProposeGoods)
                            {
                                if (wkProposeGoods.partsNumber == befGoods.partsNumber &&
                                    wkProposeGoods.makerName == befGoods.makerName)
                                    return true;
                                else
                                    return false;
                            }
                        );

                        if (afGoods == null)
                        {
                            return false;
                        }
                        else
                        {
                            // �����o��r(�t�������A���i�^�O�ȊO)
                            if (!ProposeGoods.Equals(befGoods, afGoods))
                            {
                                return false;
                            }

                            // �t���������r
                            #region
                            if (befGoods.attendRepairList == null)
                            {
                                if (afGoods.attendRepairList != null && afGoods.attendRepairList.Length > 0)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                if (afGoods.attendRepairList == null)
                                {
                                    return false;
                                }
                                else if (befGoods.attendRepairList.Length != afGoods.attendRepairList.Length)
                                {
                                    return false;
                                }
                                else
                                {
                                    foreach (AttendRepair bf in befGoods.attendRepairList)
                                    {
                                        bool sameFlag = false;
                                        foreach (AttendRepair af in afGoods.attendRepairList)
                                        {
                                            if (bf.attendRepairId == af.attendRepairId)
                                            {
                                                sameFlag = true;
                                                if (!bf.dataType.Equals(af.dataType)) return false;
                                                if (!bf.priceType.Equals(af.priceType)) return false;
                                                if (!bf.repairName.Equals(af.repairName)) return false;
                                                if (!bf.repairPrice.Equals(af.repairPrice)) return false;
                                                if (!bf.sortNo.Equals(af.sortNo)) return false;
                                            }
                                        }
                                        if (sameFlag == false) return false;
                                    }
                                }
                            }
                            #endregion

                            // ���i�^�O���r
                            #region
                            if (befGoods.goodsTagList == null)
                            {
                                if (afGoods.goodsTagList != null && afGoods.goodsTagList.Length > 0)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                if (afGoods.goodsTagList == null)
                                {
                                    return false;
                                }
                                else if (befGoods.goodsTagList.Length != afGoods.goodsTagList.Length)
                                {
                                    return false;
                                }
                                else
                                {
                                    foreach (GoodsTag bfTag in befGoods.goodsTagList)
                                    {
                                        bool sameFlag = false;
                                        foreach (GoodsTag afTag in afGoods.goodsTagList)
                                        {
                                            if (bfTag.goodsTagId == afTag.goodsTagId)
                                            {
                                                sameFlag = true;
                                                if (!bfTag.tag.Equals(afTag.tag)) return false;
                                            }
                                        }
                                        if (sameFlag == false) return false;
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                }
            }
            return ret;
        }


        /// <summary>
        /// �f�[�^�ύX�`�F�b�N(�s�P��)
        /// </summary>
        /// <returns></returns>
        private bool CheckUpDateProc(DataRow row, ProposeGoods afGoods, ProposeGoods befGoods)
        {
            bool ret = true;

            // �摜�ύX�`�F�b�N
            if ((int)row[COL_IMAGE_CHANGE] == 1)
            {
                return false;
            }

            if ((int)row[COL_DEL] == 1)
            {
                // �ۑ��ύs���폜����Ă���
                return false;
            }
            else
            {
                // �����o��r(�t�������A���i�^�O�ȊO)
                if (!ProposeGoods.Equals(befGoods, afGoods))
                {
                    return false;
                }

                // �t���������r
                #region
                if (befGoods.attendRepairList == null)
                {
                    if (afGoods.attendRepairList != null && afGoods.attendRepairList.Length > 0)
                    {
                        return false;
                    }
                }
                else
                {
                    if (afGoods.attendRepairList == null)
                    {
                        return false;
                    }
                    else if (befGoods.attendRepairList.Length != afGoods.attendRepairList.Length)
                    {
                        return false;
                    }
                    else
                    {
                        foreach (AttendRepair bf in befGoods.attendRepairList)
                        {
                            bool sameFlag = false;
                            foreach (AttendRepair af in afGoods.attendRepairList)
                            {
                                if (bf.attendRepairId == af.attendRepairId)
                                {
                                    sameFlag = true;
                                    if (!bf.dataType.Equals(af.dataType)) return false;
                                    if (!bf.priceType.Equals(af.priceType)) return false;
                                    if (!bf.repairName.Equals(af.repairName)) return false;
                                    if (!bf.repairPrice.Equals(af.repairPrice)) return false;
                                    if (!bf.sortNo.Equals(af.sortNo)) return false;
                                }
                            }
                            if (sameFlag == false) return false;
                        }
                    }
                }
                #endregion

                // ���i�^�O���r
                #region
                if (befGoods.goodsTagList == null)
                {
                    if (afGoods.goodsTagList != null && afGoods.goodsTagList.Length > 0)
                    {
                        return false;
                    }
                }
                else
                {
                    if (afGoods.goodsTagList == null)
                    {
                        return false;
                    }
                    else if (befGoods.goodsTagList.Length != afGoods.goodsTagList.Length)
                    {
                        return false;
                    }
                    else
                    {
                        foreach (GoodsTag bfTag in befGoods.goodsTagList)
                        {
                            bool sameFlag = false;
                            foreach (GoodsTag afTag in afGoods.goodsTagList)
                            {
                                if (bfTag.goodsTagId == afTag.goodsTagId)
                                {
                                    sameFlag = true;
                                    if (!bfTag.tag.Equals(afTag.tag)) return false;
                                }
                            }
                            if (sameFlag == false) return false;
                        }
                    }
                }
                #endregion
            }
            return ret;
        }
        #endregion

        #endregion

        #region �ۑ�����

        /// <summary>
        /// �ۑ�����
        /// </summary>
        private int SaveProc()
        {
            int st = 0;
            string errMsg = "";

            // ���o����ĂȂ�
            if (this.Goods_Grid.DataSource == null) return st;

            // �O���b�h���ҏW����������ҏW���[�h���I������
            if (this.Goods_Grid.ActiveCell != null)
            {
                this.Goods_Grid.ActiveCell.Selected = false;
                this.Goods_Grid.PerformAction(UltraGridAction.ExitEditMode);
            }

            // ���̓`�F�b�N
            if (!this.DataInputCheck())
            {
                return -1;
            }

            // ���[�j���O
            if (!this.DataWarningCheck())
            {
                return -1;
            }

            // TODO ���J��ǉ��̎��ɖ��ɂȂ肻���Ȃ̂ł�߂�
            // �f�[�^���P���ł��X�V����Ă���
            //if (CheckUpDateProc())
            //{
            //    TMsgDisp.Show(
            //          this,							        // �e�E�B���h�E�t�H�[��
            //          emErrorLevel.ERR_LEVEL_INFO,	        // �G���[���x��
            //          CT_ASSEMBLYID,					    // �A�Z���u��ID�܂��̓N���XID
            //          "�X�V�Ώۃf�[�^�͂���܂���",		    // �\�����郁�b�Z�[�W 
            //          st,								    // �X�e�[�^�X�l
            //          MessageBoxButtons.OK);
            //    return st;
            //}

            // �ۑ������p���X�g
            List<ProposeGoods> saveParaList = new List<ProposeGoods>();
            List<ProposeGoods> dellParaList = new List<ProposeGoods>();

            // ���i�����[�h�̏ꍇ�͌��J��I����ʂ��N��
            if (this._bootPara.BootMode == BootMode.PM)
            {

                // ���J��I����ʂ��N��
                ReleaseSelectForm form = new ReleaseSelectForm();
                form.Icon = this.Icon;
                form._categoryID = (long)this.Category_ComboEditor.Value;
                form._categoryName = this.Category_ComboEditor.Text;
                form._enterpriseCode = this._bootPara.EnterpriseCode;
                form._enterpriseName = this._bootPara.EnterpriseName;
                form._sectionCode = this.Section_ComboEditor.Value.ToString();
                form._sectionName = this.Section_ComboEditor.Text;

                // TODO���݂̋��_����SCM�ڑ�����n��
                if (this._scmSceDic.ContainsKey(form._sectionCode))
                {
                    form._scmList = this._scmSceDic[form._sectionCode];
                }
                else
                {
                    // �L���Ȍ��J�悪�Ȃ� ���肦�Ȃ�����
                    TMsgDisp.Show(
                    this,							        // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_STOPDISP,	    // �G���[���x��
                    CT_ASSEMBLYID,					        // �A�Z���u��ID�܂��̓N���XID
                    "���J��̎擾�Ɏ��s���܂���",		    // �\�����郁�b�Z�[�W 
                    -1,								        // �X�e�[�^�X�l
                    MessageBoxButtons.OK);
                    return -1;
                }

                form._mode = 0;

                DialogResult ret = form.ShowReleaseSelectFrom();
                if (ret == DialogResult.Cancel)
                {
                    return 0;
                }
                else if (ret == DialogResult.Abort)
                {
                    return -1;
                }

                // �ۑ��f�[�^�쐬
                this.MakeSaveData(1, out saveParaList, out dellParaList);
                ProposeGoods[] saveAray = saveParaList.ToArray();

                //�s���s���\��
                Broadleaf.Windows.Forms.SFCMN00299CA waitForm = new Broadleaf.Windows.Forms.SFCMN00299CA();
                // �\��������ݒ�
                waitForm.Title = "�ۑ���";
                waitForm.Message = "���݁A���i�f�[�^��ۑ����ł��B";

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    waitForm.Show();

                    // ��ď��i���̍X�V
                    st = this._TBOServiceACS.SavePropose_Goods(ref saveAray, out errMsg);

                    if (st == 0)
                    {
                        // �X�V���𔽉f
                        this.SetSaveData(saveAray, dellParaList);

                        // ���J���ۑ�����
                        if (form._startProposeList.Count > 0)
                        {
                            // �V�����o�^
                            News news = new News();
                            news.enterpriseCode = this._bootPara.EnterpriseCode;
                            news.enterpriseName = this._bootPara.EnterpriseName;
                            news.goodsCategoryId = (long)this.Category_ComboEditor.Value;
                            news.newsTitle = form.NewsTitle;
                            news.newsContent = form.NewsContent;
                            news.sectionCode = this.Section_ComboEditor.Value.ToString();
                            news.sectionName = this.Section_ComboEditor.Text;
                            news.proposeDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                            List<ProposeStore> storeList = new List<ProposeStore>();
                            foreach (Propose_Para_SCM scm in form._startProposeList)
                            {
                                ProposeStore proposeStore = new ProposeStore();
                                proposeStore.enterpriseCode = scm.CnectOriginalEpCd;
                                proposeStore.enterpriseName = scm.CnectOriginalEpNm;
                                proposeStore.sectionCode = scm.CnectOriginalSecCd;
                                proposeStore.sectionName = scm.CnectOriginalSecNm;
                                storeList.Add(proposeStore);
                            }
                            news.proposeStoreList = storeList.ToArray();

                            

                            // ���J����
                            st = this._TBOServiceACS.SaveNews(news, out errMsg);
                            if (st != 0)
                            {
                                this.Cursor = Cursors.Default;
                                waitForm.Close();

                                TMsgDisp.Show(
                                this,							        // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOPDISP,	    // �G���[���x��
                                CT_ASSEMBLYID,					        // �A�Z���u��ID�܂��̓N���XID
                                errMsg,		                        // �\�����郁�b�Z�[�W 
                                st,								    // �X�e�[�^�X�l
                                MessageBoxButtons.OK);
                                return st;
                            }
                        }

                        // ���J��~
                        if (form._stopProposeList.Count > 0)
                        {
                            st = this._TBOServiceACS.DeleteDestSetting_bulk(form._stopProposeList, out errMsg);

                            if (st != 0)
                            {
                                this.Cursor = Cursors.Default;
                                waitForm.Close();
                                TMsgDisp.Show(
                                this,							        // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOPDISP,	    // �G���[���x��
                                CT_ASSEMBLYID,					        // �A�Z���u��ID�܂��̓N���XID
                                errMsg,		                        // �\�����郁�b�Z�[�W 
                                st,								    // �X�e�[�^�X�l
                                MessageBoxButtons.OK);
                                return st;
                            }
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        waitForm.Close();

                        if (saveAray.Length > 0)
                        {
                            // �X�V���𔽉f
                            this.SetSaveData(saveAray, dellParaList);
                        }

                         TMsgDisp.Show(
                         this,							        // �e�E�B���h�E�t�H�[��
                         emErrorLevel.ERR_LEVEL_STOPDISP,	    // �G���[���x��
                         CT_ASSEMBLYID,					        // �A�Z���u��ID�܂��̓N���XID
                         errMsg,		                        // �\�����郁�b�Z�[�W 
                         st,								    // �X�e�[�^�X�l
                         MessageBoxButtons.OK);
                        return st;
                    }
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    waitForm.Close();
                }

                if (st == 0)
                {
                    if (this._initFlag)
                    {
                        // �Z���F��������
                        this._initFlag = false;
                        this.Goods_Grid.DataSource = null;
                        this.Goods_Grid.DataSource = this.TBODataSet.Tables[TABLE_MAIN];
                    }

                    TMsgDisp.Show(
                    this,							// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_INFO,	    // �G���[���x��
                    CT_ASSEMBLYID,					// �A�Z���u��ID�܂��̓N���XID
                    "�ۑ����܂����B",			    // �\�����郁�b�Z�[�W 
                    st,								// �X�e�[�^�X�l
                    MessageBoxButtons.OK);
                }
            }
            else 
            {
                // �����H�ꃂ�[�h

                // �ۑ��f�[�^�쐬
                this.MakeSaveData(1, out saveParaList, out dellParaList);
                ProposeGoods[] saveAray = saveParaList.ToArray();

                 //�s���s���\��
                Broadleaf.Windows.Forms.SFCMN00299CA waitForm = new Broadleaf.Windows.Forms.SFCMN00299CA();
                // �\��������ݒ�
                waitForm.Title = "�ۑ���";
                waitForm.Message = "���݁A��ăf�[�^��ۑ����ł��B";

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    waitForm.Show();

                    // ��ď��i���̍X�V
                    st = this._TBOServiceACS.SavePropose_Goods(ref saveAray, out errMsg);
                    if (st == 0)
                    {
                        // �X�V���𔽉f
                        this.SetSaveData(saveAray, dellParaList);

                        // ���Ѝ݌ɂȂ̂Ō��J��I����ʂ͋N�����Ȃ�
                        // �V�����o�^
                        News news = new News();
                        news.enterpriseCode = this._bootPara.EnterpriseCode;
                        news.enterpriseName = this._bootPara.EnterpriseName;
                        news.goodsCategoryId = (long)this.Category_ComboEditor.Value;
                        news.newsTitle = "���i���̍X�V";
                        news.sectionCode = this.Section_ComboEditor.Value.ToString();
                        news.sectionName = this.Section_ComboEditor.Text;
                        news.proposeDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        ProposeStore proposeStore = new ProposeStore();
                        proposeStore.enterpriseCode = this._bootPara.EnterpriseCode;
                        proposeStore.enterpriseName = this._bootPara.EnterpriseName;
                        proposeStore.sectionCode = this.Section_ComboEditor.Value.ToString();
                        proposeStore.sectionName = this.Section_ComboEditor.Text;
                        news.proposeStoreList = new ProposeStore[] { proposeStore };

                        // ���J����
                        st = this._TBOServiceACS.SaveNewsAdopt(news, out errMsg);
                        if (st != 0)
                        {
                            this.Cursor = Cursors.Default;
                            waitForm.Close();
                            TMsgDisp.Show(
                            this,							        // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	    // �G���[���x��
                            CT_ASSEMBLYID,					        // �A�Z���u��ID�܂��̓N���XID
                            errMsg,		                        // �\�����郁�b�Z�[�W 
                            st,								    // �X�e�[�^�X�l
                            MessageBoxButtons.OK);
                            return st;
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        waitForm.Close();
                        TMsgDisp.Show(
                        this,							        // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	    // �G���[���x��
                        CT_ASSEMBLYID,					        // �A�Z���u��ID�܂��̓N���XID
                        errMsg,		                        // �\�����郁�b�Z�[�W 
                        st,								    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);
                        return st;
                    }
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    waitForm.Close();
                }

                if (st == 0)
                {
                    if (this._initFlag)
                    {
                        // �Z���F��������
                        this._initFlag = false;
                        this.Goods_Grid.DataSource = null;
                        this.Goods_Grid.DataSource = this.TBODataSet.Tables[TABLE_MAIN];
                    }

                    string saveMsg = "�ۑ����܂����B";
                    if (this._bootPara.BootMode == BootMode.SF)
                    {
                        saveMsg += Environment.NewLine + "CarpodTab�ɂď��i�̊m�F�E���J���s���ĉ������B";
                    }

                    TMsgDisp.Show(
                    this,							// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_INFO,	// �G���[���x��
                    CT_ASSEMBLYID,					// �A�Z���u��ID�܂��̓N���XID
                    saveMsg,			            // �\�����郁�b�Z�[�W 
                    st,								// �X�e�[�^�X�l
                    MessageBoxButtons.OK);
                }
            }
            return st;
        }

        #region �ۑ��f�[�^�쐬

        #region ���C��
        /// <summary>
        /// �ۑ��f�[�^�쐬(���C��)
        /// </summary>
        /// <param name="mode">0:���̓`�F�b�N�p,1:�ۑ��f�[�^�쐬�p</param>
        /// <param name="saveParaList">�ۑ��f�[�^</param>
        /// <param name="dellParaList">�폜�f�[�^</param>
        private void MakeSaveData(int mode,�@out List<ProposeGoods> saveParaList, out List<ProposeGoods> dellParaList)
        {
            saveParaList = new List<ProposeGoods>();
            dellParaList = new List<ProposeGoods>();

            // ���ۑ��s�폜�����e�[�u���������
            List<DataRow> delRowList = new List<DataRow>();
            for (int i = 0; i < this.TBODataSet.Tables[TABLE_MAIN].Rows.Count; i++)
            {
                DataRow row = this.TBODataSet.Tables[TABLE_MAIN].Rows[i];
                // �V�K�A�X�V���f
                if ((int)row[COL_DEL] == 1 && row[COL_POSTPARACLASS] == DBNull.Value)
                {
                    delRowList.Add(row);
                }
            }

            foreach (DataRow delRow in delRowList)
            {
                this.TBODataSet.Tables[TABLE_MAIN].Rows.Remove(delRow);
            }

            this.TBODataSet.Tables[TABLE_MAIN].AcceptChanges();
            this.UpDateGrid();

            // �O���b�h�̕\�����Ń\�[�g����U��Ȃ���
            for (int i = 0; i < this.Goods_Grid.Rows.Count; i++)
            {
                this.Goods_Grid.Rows[i].Cells[COL_SORTNO].Value = i;
            }

            this.TBODataSet.Tables[TABLE_MAIN].AcceptChanges();
            this.UpDateGrid();


            List<AttendRepairSet> repairSetList = new List<AttendRepairSet>();
            Dictionary<string, string> repairIdDic = new Dictionary<string, string>();
            if (this._attendRepairSetDic.ContainsKey((long)this.Category_ComboEditor.Value))
            {
                repairSetList = this._attendRepairSetDic[(long)this.Category_ComboEditor.Value];
                repairIdDic = new Dictionary<string, string>();

                // �t������ID�f�B�N�V���i��
                foreach (DataColumn col in this.TBODataSet.Tables[TABLE_MAIN].Columns)
                {
                    if (col.ColumnName.Contains(COL_REPARE))
                    {
                        // ���i�����[�h�̏ꍇ��attendRepairID�A�����H�ꃂ�[�h�̏ꍇ��storeRepairID���L�[�ƂȂ�
                        repairIdDic.Add(col.ColumnName.Replace(COL_REPARE, ""), col.ColumnName);
                    }
                }
            }

            long dtTicks = DateTime.Now.Ticks;

            for (int i = 0; i < this.TBODataSet.Tables[TABLE_MAIN].Rows.Count; i++)
            {
                ProposeGoods proposeGoods = new ProposeGoods();
                GoodsTag[] tagArray = null;

                DataRow row = this.TBODataSet.Tables[TABLE_MAIN].Rows[i];

                // �V�K�A�X�V���f
                if (row[COL_POSTPARACLASS] != DBNull.Value)
                {
                    // �X�V���R�[�h�N���[��
                    proposeGoods = ((ProposeGoods)row[COL_POSTPARACLASS]).Clone();

                    // �^�O
                    if(proposeGoods.goodsTagList != null)
                    {
                        tagArray = new GoodsTag[proposeGoods.goodsTagList.Length];
                        for (int ii = 0; ii < proposeGoods.goodsTagList.Length; ii++)
			            {
                            tagArray[ii] = proposeGoods.goodsTagList[ii].Clone();
			            }
                    }

                    // PM�X�V����
                    proposeGoods.pmUpdDtTime = (long)row[COL_PM_UPDATETIME];
                }
                else
                {
                    // �V�K���R�[�h
                    proposeGoods.enterpriseCode = this._bootPara.EnterpriseCode;            // ��ƃR�[�h  
                    proposeGoods.enterpriseName = this._bootPara.EnterpriseName;            // ��Ɩ��� 
                    proposeGoods.sectionCode = this.Section_ComboEditor.Value.ToString();   // ���_�R�[�h
                    proposeGoods.sectionName = this.Section_ComboEditor.Text;               // ���_����
                    proposeGoods.goodsCategoryId = (long)this.Category_ComboEditor.Value;    // ���i�J�e�S��

                    // �w�b�_����
                    proposeGoods.insAccountId = 0;
                    proposeGoods.insDtTime = 0;
                    proposeGoods.proposeGoodsId = 0;
                    proposeGoods.uuid = "";

                    // PM�X�V��
                    if (row[COL_PM_UPDATETIME] == DBNull.Value || (long)row[COL_PM_UPDATETIME] == 0)
                    {
                        proposeGoods.pmUpdDtTime = dtTicks;
                    }
                    else
                    {
                        proposeGoods.pmUpdDtTime = (long)row[COL_PM_UPDATETIME];
                    }
                }

                // �V�K�E�X�V����
                proposeGoods.logicalDelDiv = (int)row[COL_DEL];                         // �_���폜�敪
                proposeGoods.releaseFlag = (bool)row[COL_RELEASE];                      // ���J�t���O
                proposeGoods.recommendFlag = (bool)row[COL_RECOMMEND];                  // �I�X�X���t���O
                proposeGoods.pmMakerCode = (int)row[COL_MAKERCD];                       // ���[�J�[�R�[�h
                proposeGoods.makerName = row[COL_MAKERNM].ToString();                   // ���[�J�[����
                proposeGoods.partsNumber = row[COL_GOODSNO].ToString();                 // �i��   
                proposeGoods.proposeGoodsName = row[COL_GOODSNM].ToString();            // ���i����
                proposeGoods.goodsNote = row[COL_GOODSNOTE].ToString();                 // ���i����
                proposeGoods.goodsPr = row[COL_GOODSPR].ToString();                     // ���i�o�q



                // ������
                if (row[COL_RELEASEDATE] != DBNull.Value)
                {
                    proposeGoods.releaseDate = ((DateTime)row[COL_RELEASEDATE]).ToString("yyyy-MM-dd");
                }
                else
                {
                    proposeGoods.releaseDate = null;
                }

                // ���J�J�n��
                if (row[COL_SHOPSALEBEGINDATE] != DBNull.Value)
                {
                    proposeGoods.shopSaleBeginDate = ((DateTime)row[COL_SHOPSALEBEGINDATE]).ToString("yyyy-MM-dd");
                }
                else
                {
                    proposeGoods.shopSaleBeginDate = null;
                }

                // ���J�I����
                if (row[COL_SHOPSALEENDDATE] != DBNull.Value)
                {
                    proposeGoods.shopSaleEndDate = ((DateTime)row[COL_SHOPSALEENDDATE]).ToString("yyyy-MM-dd");
                }
                else
                {
                    proposeGoods.shopSaleEndDate = null;
                }


                // ���z
                proposeGoods.suggestPrice = (long)row[COL_SUGGEST_PRICE];                   // �W�����i
                proposeGoods.shopPrice = (long)row[COL_SHOP_PRICE];                        // �X�����i
                proposeGoods.tradePrice = (long)row[COL_TRADE_PRICE];                       // ���l
                proposeGoods.purchaseCost = (long)row[COL_PURCHASE_COST];                   // �d������
                proposeGoods.stockState = Convert.ToInt32(row[COL_STOCKSTATE].ToString());   // �݌ɏ��

                // ���i�^�O���X�g
                proposeGoods.goodsTagList = this.MakeGoodsTagList(row, tagArray);

                // �t���������X�g
                proposeGoods.attendRepairList = this.MakeAttendRepairList(row, repairSetList, repairIdDic);

                // �\�[�g
                proposeGoods.sortNo = (int)row[COL_SORTNO];

                // �ʐݒ聨�g���p
                proposeGoods.proposeDistGoodsSetting = new ProposeDistGoodsSetting[0];

                // �摜
                proposeGoods.imageId = (long)row[COL_IMAGE_NO];
                // �V���A���C�Y�ŃG���[�ɂȂ�̂�Image�͍폜
                proposeGoods.image_Data = null;


                // �f�[�^�ۑ����͕ύX�����镪�̂ݍ쐬
                if (mode == 1)
                {
                    if (row[COL_POSTPARACLASS] != DBNull.Value)
                    {
                        // �s�ύX�`�F�b�N
                        if (this.CheckUpDateProc(row, proposeGoods, ((ProposeGoods)row[COL_POSTPARACLASS]).Clone()))
                        {
                            // �ύX����ĂȂ�������ۑ��ΏۊO�Ƃ���
                            continue;
                        }
                    }
                }

                saveParaList.Add(proposeGoods);

                if (proposeGoods.logicalDelDiv == 1)
                {
                    dellParaList.Add(proposeGoods.Clone());
                }
            }
        }
        #endregion

        #region �t������
        /// <summary>
        /// �t�������f�[�^�쐬����
        /// </summary>
        /// <param name="row"></param>
        /// <param name="repairArray"></param>
        /// <returns></returns>
        private AttendRepair[] MakeAttendRepairList(DataRow row, List<AttendRepairSet> repairList, Dictionary<string, string> repairIdDic)
        {
            // DB����DEL��INSERT�Ȃ̂ŏ�ɐV�K�ő���B
            // ��ď��i�t������
            List<AttendRepair> retList = new List<AttendRepair>();

            // �t�������ݒ�
            foreach (AttendRepairSet set in repairList)
            {
                AttendRepair newData = new AttendRepair();
                newData.enterpriseCode = this._bootPara.EnterpriseCode;
                newData.sectionCode = this.Section_ComboEditor.Value.ToString();
                newData.dataType = set.dataType;
                newData.priceType = set.priceType;
                newData.repairName = set.repairName;
                newData.sortNo = set.sortNo;
                newData.uuid = "";

                if (this._bootPara.BootMode == BootMode.PM)
                {
                    newData.attendRepairId = set.attendRepairId;

                    if (repairIdDic.ContainsKey(set.attendRepairId.ToString()))
                    {
                        string colNm = repairIdDic[set.attendRepairId.ToString()];
                        if (this.TBODataSet.Tables[TABLE_MAIN].Columns.Contains(colNm))
                        {
                            newData.repairPrice = (long)row[colNm];
                        }
                        else
                        {
                            newData.repairPrice = set.repairPrice;
                        }
                    }
                }
                else
                {
                    // �����H�ꃂ�[�h�̏ꍇ��storeAttendRepairId��attendRepairId�ɃZ�b�g
                    newData.attendRepairId = set.storeAttendRepairId;

                    if (repairIdDic.ContainsKey(set.storeAttendRepairId.ToString()))
                    {
                        string colNm = repairIdDic[set.storeAttendRepairId.ToString()];
                        if (this.TBODataSet.Tables[TABLE_MAIN].Columns.Contains(colNm))
                        {
                            newData.repairPrice = (long)row[colNm];
                        }
                        else
                        {
                            newData.repairPrice = set.repairPrice;
                        }
                    }
                }
                retList.Add(newData);
            }
            return retList.ToArray();
        }
        #endregion

        #region ���i�^�O���X�g
        /// <summary>
        /// ���i�^�O���X�g�쐬
        /// </summary>
        /// <returns></returns>
        private GoodsTag[] MakeGoodsTagList(DataRow row, GoodsTag[] tagArray)
        {
            #region
            List<GoodsTag> tagList = new List<GoodsTag>();

            if (tagArray != null && tagArray.Length > 0)
            {
                // �X�V��
                // �_���폜�敪��ݒ�
                for (int i = 0; i < tagArray.Length; i++)
                {
                    tagArray[i].logicalDelDiv = (int)row[COL_DEL];
                }
            }

            if (tagArray != null)
            {
                // �X�V��
                switch ((long)this.Category_ComboEditor.Value)
                {
                    case 1: // �^�C��
                        for (int i = 0; i < tagArray.Length; i++)
                        {
                            if (tagArray[i].tagNo == 1)
                            {
                                // �T�C�Y
                                tagArray[i].tag = row[COL_TIRE_KEY1].ToString();
                            }
                            else if (tagArray[i].tagNo == 2)
                            {
                                // �X�^�b�h���X
                                if ((bool)row[COL_TIRE_KEY2])
                                {
                                    tagArray[i].tag = "1";
                                }
                                else
                                {
                                    tagArray[i].tag = "0";
                                }
                            }
                        }
                        break;
                    case 2: // �o�b�e��
                        for (int i = 0; i < tagArray.Length; i++)
                        {
                            if (tagArray[i].tagNo == 1)
                            {
                                // �K�i
                                tagArray[i].tag = row[COL_BATTERY_KEY1].ToString();
                            }
                            else if (tagArray[i].tagNo == 2)
                            {
                                // �K��
                                switch ((int)row[COL_BATTERY_KEY2])
                                {
                                    case 1: // �W���Ԑ�p
                                    case 3: // ���p
                                        tagArray[i].tag = "1";
                                        break;
                                    case 2: // ISS��p
                                        tagArray[i].tag = "0";
                                        break;
                                    default:
                                        tagArray[i].tag = "1";
                                        break;
                                }
                            }
                            else if (tagArray[i].tagNo == 3)
                            {
                                // �K��
                                switch ((int)row[COL_BATTERY_KEY2])
                                {
                                    case 1: // �W���Ԑ�p
                                        tagArray[i].tag = "0";
                                        break;
                                    case 2: // ISS��p
                                    case 3: // ���p
                                        tagArray[i].tag = "1";
                                        break;
                                    default:
                                        tagArray[i].tag = "0";
                                        break;
                                }
                            }
                        }
                        break;
                    case 3: // �I�C��
                        for (int i = 0; i < tagArray.Length; i++)
                        {
                            if (tagArray[i].tagNo == 1)
                            {
                                // �K�i
                                tagArray[i].tag = row[COL_OIL_KEY1].ToString();
                            }
                            else if (tagArray[i].tagNo == 2)
                            {
                                // �K��
                                switch ((int)row[COL_OIL_KEY2])
                                {
                                    case 1: // �K�\������p
                                    case 3: // ���p
                                        tagArray[i].tag = "1";
                                        break;
                                    case 2: // �f�B�[�[����p
                                        tagArray[i].tag = "0";
                                        break;
                                    default:
                                        tagArray[i].tag = "1";
                                        break;
                                }
                            }
                            else if (tagArray[i].tagNo == 3)
                            {
                                // �K��
                                switch ((int)row[COL_OIL_KEY2])
                                {
                                    case 1: // �K�\������p
                                        tagArray[i].tag = "0";
                                        break;
                                    case 2: // �f�B�[�[����p
                                    case 3: // ���p
                                        tagArray[i].tag = "1";
                                        break;
                                    default:
                                        tagArray[i].tag = "0";
                                        break;
                                }
                            }
                        }
                        break;
                }
            }
            else
            {
                // �V�K��
                // �J�e�S���� ���g�p����L�[�͍��̂Ƃ���Œ�
                switch ((long)this.Category_ComboEditor.Value)
                {
                    case 1: // �^�C��
                        for (int i = 1; i < 3; i++)
                        {
                            GoodsTag tag = new GoodsTag();
                            tag.enterpriseCode = this._bootPara.EnterpriseCode;
                            tag.tagNo = i;
                            tag.sectionCode = this.Section_ComboEditor.Value.ToString();
                            tag.uuid = "";
                            if (i == 1)
                            {
                                // �T�C�Y
                                tag.tag = row[COL_TIRE_KEY1].ToString();
                            }
                            else if (i == 2)
                            {
                                // �X�^�b�h���X
                                if ((bool)row[COL_TIRE_KEY2])
                                {
                                    tag.tag = "1";
                                }
                                else
                                {
                                    tag.tag = "0";
                                }
                            }
                            tagList.Add(tag);
                        }
                        break;
                    case 2:�@// �o�b�e��

                        // �^�O
                        GoodsTag btag1 = new GoodsTag();
                        GoodsTag btag2 = new GoodsTag();
                        GoodsTag btag3 = new GoodsTag();
                        btag1.enterpriseCode = btag2.enterpriseCode = btag3.enterpriseCode = this._bootPara.EnterpriseCode;
                        btag1.tagNo = 1;
                        btag2.tagNo = 2;
                        btag3.tagNo = 3;
                        btag1.sectionCode = btag2.sectionCode = btag3.sectionCode = this.Section_ComboEditor.Value.ToString();
                        btag1.uuid = btag2.uuid = btag3.uuid = "";

                        // �K�i
                        btag1.tag = row[COL_BATTERY_KEY1].ToString();

                        // �K��
                        switch ((int)row[COL_BATTERY_KEY2])
                        {
                            case 1: // �W���Ԑ�p
                                btag2.tag = "1";
                                btag3.tag = "0";
                                break;
                            case 2: // ISS��p
                                btag2.tag = "0";
                                btag3.tag = "1";
                                break;
                            case 3: // ���p
                                btag2.tag = "1";
                                btag3.tag = "1";
                                break;
                            default:
                                btag2.tag = "1";
                                btag3.tag = "0";
                                break;
                        }

                        tagList.Add(btag1);
                        tagList.Add(btag2);
                        tagList.Add(btag3);
                        break;
                    case 3:�@// �I�C��
                        // �^�O
                        GoodsTag otag1 = new GoodsTag();
                        GoodsTag otag2 = new GoodsTag();
                        GoodsTag otag3 = new GoodsTag();
                        otag1.enterpriseCode = otag2.enterpriseCode = otag3.enterpriseCode = this._bootPara.EnterpriseCode;
                        otag1.tagNo = 1;
                        otag2.tagNo = 2;
                        otag3.tagNo = 3;
                        otag1.sectionCode = otag2.sectionCode = otag3.sectionCode = this.Section_ComboEditor.Value.ToString();
                        otag1.uuid = otag2.uuid = otag3.uuid = "";

                        // �K�i
                        otag1.tag = row[COL_OIL_KEY1].ToString();

                        // �K��
                        switch ((int)row[COL_OIL_KEY2])
                        {
                            case 1: // �K�\�����Ԑ�p
                                otag2.tag = "1";
                                otag3.tag = "0";
                                break;
                            case 2:�@// �f�B�[�[���Ԑ�p
                                otag2.tag = "0";
                                otag3.tag = "1";
                                break;
                            case 3: // ���p
                                otag2.tag = "1";
                                otag3.tag = "1";
                                break;
                            default:
                                otag2.tag = "1";
                                otag3.tag = "0";
                                break;
                        }
                        tagList.Add(otag1);
                        tagList.Add(otag2);
                        tagList.Add(otag3);
                        break;
                }
            }

            if (tagArray != null)
                tagList.AddRange(tagArray);

            return tagList.ToArray();
            #endregion
        }
        #endregion

        #endregion

        /// <summary>
        /// �ۑ��ς݃f�[�^�X�V
        /// </summary>
        /// <param name="saveAray"></param>
        private void SetSaveData(ProposeGoods[] saveAray, List<ProposeGoods> dellList)
        {
            // ��ď��iID�̓T�[�o�[���ō̔Ԃ����̂ŃL�[�ɂȂ�Ȃ�
            // ����ĕi�� + ���[�J�[���̂ɂē��Ă�
            // ���̂ł��Ă�̂̓��[�J�[�R�[�h�̖����͂�������

            string mkNm = "";
            string goodsNo = "";
            if (saveAray != null)
            {
                for (int i = 0; i < saveAray.Length; i++)
                {
                    mkNm = saveAray[i].makerName;
                    goodsNo = saveAray[i].partsNumber;
                    StringBuilder cndString = new StringBuilder();
                    cndString.Append(String.Format("{0}='{1}' AND {2}='{3}'", COL_MAKERNM, mkNm, COL_GOODSNO, goodsNo));
                    DataRow[] rows = this.TBODataSet.Tables[TABLE_MAIN].Select(cndString.ToString());
                    if (rows != null)
                    {
                        rows[0][COL_POSTPARACLASS] = saveAray[i];
                        rows[0][COL_PM_UPDATETIME] = saveAray[i].pmUpdDtTime;
                        rows[0][COL_IMAGE_CHANGE] = 0;
                    }
                }
            }

            if (dellList != null && dellList.Count > 0)
            {
                for (int i = 0; i < dellList.Count; i++)
                {
                    mkNm = dellList[i].makerName;
                    goodsNo = dellList[i].partsNumber;
                    StringBuilder cndString = new StringBuilder();
                    cndString.Append(String.Format("{0}='{1}' AND {2}='{3}'", COL_MAKERNM, mkNm, COL_GOODSNO, goodsNo));
                    DataRow[] rows = this.TBODataSet.Tables[TABLE_MAIN].Select(cndString.ToString());
                    if (rows != null)
                    {
                        for (int ii = 0; ii < rows.Length; ii++)
                        {
                            this.TBODataSet.Tables[TABLE_MAIN].Rows.Remove(rows[ii]);
                        }
                    }
                }
            }
        }
        #endregion

        #region ���z�v�Z

        #region �e��
        /// <summary>
        /// �e���̌v�Z���s���܂�(�����H��)
        /// </summary>
        private void CalcGrossSF(long shopPrice, long repareTotal, long tradePrice, out long gross, out string grossMargin)
        {
            // ���i�����[�h�����H��̑e��
            // �e�����z: �X�����i�{�t������-�����@
            // �e����  : �e�����z / ���㍂ ������͕t����Ƃ�����Ƃ��Ċ܂߂Čv�Z

            gross = 0;
            grossMargin = "";

            // �e��
            gross = shopPrice + repareTotal - tradePrice;
            // ����
            long salesTotal = shopPrice + repareTotal;

            // �e�����v�Z(�����_�ȉ��l�̌ܓ��Ƃ���)

            if (salesTotal != 0) // 0���Z�`�F�b�N
            {
                double wkGross = gross;
                double wkTotal = salesTotal;
                double ans = Math.Round(((wkGross / wkTotal) * 100), MidpointRounding.AwayFromZero);
                grossMargin = ans.ToString("F0") + "%";
            }
            else
            {
                grossMargin = "";
            }

        }

        /// <summary>
        /// �e���̌v�Z���s���܂�
        /// </summary>
        private void CalcGrossPM(long tradePrice, long cost, out long gross, out string grossMargin)
        {
            // ���i�����[�h���i���̑e��
            // �e�����z: �̔����i - �d�������@
            // �e����  : �e�����z / �̔����i 

            gross = 0;
            grossMargin = "";

            // �e��
            gross = tradePrice - cost;

            // �e�����v�Z(�����_�ȉ��l�̌ܓ��Ƃ���)

            if (tradePrice != 0) // 0���Z�`�F�b�N
            {
                double wkGross = gross;
                double wkTotal = tradePrice;
                double ans = Math.Round(((wkGross / wkTotal) * 100), MidpointRounding.AwayFromZero);
                grossMargin = ans.ToString("F0") + "%";
            }
            else
            {
                grossMargin = "";
            }
        }
        #endregion

        #region �t������
        /// <summary>
        /// �t���������z�̍��v���v�Z���܂�
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private long CalcRepareTotal(int index)
        {
            long ret = 0;
            UltraGridRow row = this.Goods_Grid.Rows[index];

            if (this._attendRepairSetDic.ContainsKey((long)this.Category_ComboEditor.Value))
            {
                List<AttendRepairSet> list = this._attendRepairSetDic[(long)this.Category_ComboEditor.Value];
                for (int i = 0; i < list.Count; i++)
                {
                    string key = "";
                    if (this._bootPara.BootMode == BootMode.PM)
                    {
                        key = this.MakeAttenRepairKey(list[i].attendRepairId.ToString());
                    }
                    else
                    {
                        key = this.MakeAttenRepairKey(list[i].storeAttendRepairId.ToString());
                    }

                    if(this.TBODataSet.Tables[TABLE_MAIN].Columns.Contains(key))
                    {
                        ret += GetCellLong(row.Cells[key].Value, 0);
                    }
                }
            }
            return ret;
        }
        #endregion

        #endregion

        #region Grid�֘A

        #region ���̃Z���擾
        /// <summary>
        /// ���̃Z���擾
        /// </summary>
        /// <param name="activeCell"></param>
        /// <returns></returns>
        private UltraGridCell GetNextCell(UltraGridCell activeCell)
        {
            UltraGridCell nextCell = null;
            switch (activeCell.Column.Key)
            {
                case COL_GOODSNO: nextCell = activeCell.Row.Cells[COL_MAKERCD]; break;   // �i�ԁ����[�J�[CD
                case COL_MAKERCD: nextCell = activeCell.Row.Cells[COL_MAKERGD]; break;   // ���[�J�[CD���K�C�h
                case COL_MAKERGD: nextCell = activeCell.Row.Cells[COL_MAKERNM]; break;   // �K�C�h������

                case COL_GROSSMARGIN_SF:
                    if (this._bootPara.BootMode == BootMode.SF)
                    {
                        // ���̍s
                        if (activeCell.Row.HasNextSibling())
                        {
                            UltraGridRow nextRow = activeCell.Row.GetSibling(SiblingRow.Next);
                            nextCell = nextRow.Cells[COL_RELEASE];
                        }
                        break;
                    }
                    break;
                case COL_GROSSMARGIN_PM:
                    {
                        // ���̍s
                        if (activeCell.Row.HasNextSibling())
                        {
                            UltraGridRow nextRow = activeCell.Row.GetSibling(SiblingRow.Next);
                            nextCell = nextRow.Cells[COL_RELEASE];
                        }
                        else
                        {
                            // �ŏI�Z��
                            nextCell = activeCell;
                        }
                        break;
                    }
            }

            if (nextCell != null)
            {
                if (nextCell.Row.GetCellActivationResolved(nextCell.Column) == Activation.Disabled)
                    nextCell = GetNextCell(nextCell);
            }

            return nextCell;
        }
        #endregion

        #region �O�̃Z���擾
        /// <summary>
        /// �O�̃Z���擾
        /// </summary>
        /// <param name="activeCell"></param>
        /// <returns></returns>
        private UltraGridCell GetPrevCell(UltraGridCell activeCell)
        {
            UltraGridCell prevCell = null;
            switch (activeCell.Column.Key)
            {
                case COL_GOODSNO: prevCell = activeCell.Row.Cells[COL_RECOMMEND]; break; // �i�ԁ��I�X�X��
                case COL_MAKERCD: prevCell = activeCell.Row.Cells[COL_GOODSNO]; break;   // ���[�J�[CD���i��
                case COL_MAKERGD: prevCell = activeCell.Row.Cells[COL_MAKERCD]; break;   // ���[�J�[�K�C�h��CD
                case COL_MAKERNM: prevCell = activeCell.Row.Cells[COL_MAKERGD]; break;   // ���[�J�[���́��K�C�h
                case COL_RELEASE:
                    {
                        // �O�̍s
                        if (activeCell.Row.HasPrevSibling())
                        {
                            UltraGridRow prvRow = activeCell.Row.GetSibling(SiblingRow.Previous);
                            if (this._bootPara.BootMode == BootMode.SF)
                            {
                                prevCell = prvRow.Cells[COL_GROSSMARGIN_SF];
                            }
                            else
                            {
                                prevCell = prvRow.Cells[COL_GROSSMARGIN_PM];
                            }
                        }
                        break;
                    }
            }

            if (prevCell != null)
            {
                if (prevCell.Row.GetCellActivationResolved(prevCell.Column) == Activation.Disabled)
                    prevCell = GetPrevCell(prevCell);
            }
            return prevCell;
        }
        #endregion

        #region �Z�����f�[�^�擾����
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

        #region �A�N�e�B�u�s�C���f�b�N�X�擾����
        /// <summary>
        /// �A�N�e�B�u�s�C���f�b�N�X�擾����
        /// </summary>
        /// <return>�s�C���f�b�N�X</return>
        /// <remarks>
        /// <br>Note       : �A�N�e�B�u�s�̃C���f�b�N�X���擾���܂�</br>
        /// <br>Programer  : 23010 �����@�m</br>
        /// <br>Date       : 2007.08.02</br>
        /// </remarks>
        private int GetActiveIndex()
        {
            if (this.Goods_Grid.ActiveCell != null)
            {
                return this.Goods_Grid.ActiveCell.Row.Index;
            }
            else if (this.Goods_Grid.ActiveRow != null)
            {
                return this.Goods_Grid.ActiveRow.Index;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region �X�V�G���[��������O����
        /// <summary>
        /// �Z���X�V�G������������
        /// </summary>
        private void CellDataErrorProc()
        {
            // ���l���ڂ̏ꍇ
            if ((this.Goods_Grid.ActiveCell.Column.DataType == typeof(Int32)) ||
                (this.Goods_Grid.ActiveCell.Column.DataType == typeof(Int64)) ||
                (this.Goods_Grid.ActiveCell.Column.DataType == typeof(double)))
            {
                Infragistics.Win.EmbeddableEditorBase editorBase = this.Goods_Grid.ActiveCell.EditorResolved;

                // �����͂�0�ɂ���
                if (editorBase.CurrentEditText.Trim() == "")
                {
                    editorBase.Value = 0;				// 0���Z�b�g
                    this.Goods_Grid.ActiveCell.Value = 0;
                }
                // ���l���ڂɁu-�vor�u.�v�������������ĂȂ�������ʖڂł�
                else if ((editorBase.CurrentEditText.Trim() == "-") ||
                    (editorBase.CurrentEditText.Trim() == ".") ||
                    (editorBase.CurrentEditText.Trim() == "-."))
                {
                    editorBase.Value = 0;				// 0���Z�b�g
                    this.Goods_Grid.ActiveCell.Value = 0;
                }
                // �ʏ����
                else
                {
                    try
                    {
                        editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.Goods_Grid.ActiveCell.Column.DataType);
                        this.Goods_Grid.ActiveCell.Value = editorBase.Value;
                    }
                    catch
                    {
                        editorBase.Value = 0;
                        this.Goods_Grid.ActiveCell.Value = 0;
                        if(this.Goods_Grid.ActiveCell.Column.Key == COL_MAKERCD)
                        {
                            // ���̂��N���A
                            this.Goods_Grid.ActiveCell.Row.Cells[COL_MAKERNM].Value = string.Empty;
                        }
                    }
                }
            }
        }

        #endregion

        #region ���l���̓`�F�b�N
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

        #region �O���b�h�A�b�v�f�[�g
        /// <summary>
        /// �O���b�h�A�b�v�f�[�g����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃A�b�v�f�[�g�������s���܂��B</br>
        /// </remarks>
        private void UpDateGrid()
        {
            this.Goods_Grid.UpdateData();
            this.Goods_Grid.Refresh();

            if (this.Goods_Grid.DataSource != null)
            {
                this.rowCout_label.Text = this.Goods_Grid.Rows.Count.ToString() + "��";

                switch ((long)this.Category_ComboEditor.Value)
                {
                    case 1:
                        this.InputMsg_Label.Text = CT_INPMSG_TIRE;
                        break;
                    case 2:
                        this.InputMsg_Label.Text = CT_INPMSG_BATTERY;
                        break;
                    case 3:
                        this.InputMsg_Label.Text = CT_INPMSG_OIL;
                        break;
                }
            }
            else
            {
                this.rowCout_label.Text = "";
                this.InputMsg_Label.Text = "";
            }
        }

        #endregion

        #endregion

        #endregion

        #region Event

        #region From

        #region Shown

        /// <summary>
        /// �N������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFMIT10201U_Shown(object sender, EventArgs e)
        {
            // �����H�ꃂ�[�h
            if (this._bootPara.BootMode == BootMode.SF)
            {
                // �����H�ꃂ�[�h�̎��A���J��͔�\��
                this.proposeInfo_toolStripButton.Visible = false;
                // �Z�b�g�}�X�^�捞�͔�\��
                this.toolStripButton_SetImp.Visible = false;
                this.toolStripSeparator4.Visible = false;
                this.toolStripSeparator6.Visible = false;
                // ����ݒ�͔�\��
                this.Setting_Button.Visible = false;
                this.SFImageSet_Button.Visible = true;
             
            }
            else
            {
                // ���J�惊�X�g�쐬
                this.MakeCustomerList();
                // ����ݒ胊�X�g�擾
                this.GetSettings();
            }

            // ���O�C���S���\��
            this.EmpName_toolStripLabel.Text = this._bootPara.EmployeeName;
            // ���_���X�g�쐬  // TODO �{�ЁA���_����
            this.SetSection();
            // �J�e�S�����X�g�쐬
            this.SetCategory();

            // ���i�����[�h�̏ꍇ�͊�ƒP�ʂ̐ݒ�Ȃ̂ŋN�����ɑS���擾���Ă���
            if (this._bootPara.BootMode == BootMode.PM)
            {
                // �t���������X�g�쐬
                this.SetAttendRepairSet();
            }
          
            // ���[�J�[���X�g�쐬
            this.MakeMakerDic();
           
            // �{�^������
            this.SetRowDelEnabled();
            this.SetSpButtonEnabled(false);
        }
        

        /// <summary>
        /// ����ݒ�擾
        /// </summary>
        private void GetSettings()
        {
            List<Settings> settingsList = new List<Settings>();
            string errMsg = "";
            this._settingsDic.Clear();
            int st = this._TBOServiceACS.GetSettings(this._bootPara.EnterpriseCode, out settingsList, out errMsg);

            if (st == 0)
            {
                foreach (Settings settings in settingsList)
                {
                    if (!this._settingsDic.ContainsKey(settings.sectionCode))
                    {
                        this._settingsDic.Add(settings.sectionCode, settings);
                    }
                }
            }
            else
            {
                TMsgDisp.Show(
                     this,								            // �e�E�B���h�E�t�H�[��
                     emErrorLevel.ERR_LEVEL_STOPDISP,	            // �G���[���x��
                     CT_ASSEMBLYID,						            // �A�Z���u��ID�܂��̓N���XID
                     errMsg,		                                // �\�����郁�b�Z�[�W 
                     st,								            // �X�e�[�^�X�l
                     MessageBoxButtons.OK);				            // �\������{
            }
        }

        #endregion

        #region FormClosing
        /// <summary>
        /// ���鏈��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFMIT10201U_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckUpDate())
            {
                e.Cancel = true;
            }
        }
        #endregion

        #endregion

        #region Grid

        #region InitializeLayout

        /// <summary>
        /// �O���b�h�������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // �s�Z���N�^
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            e.Layout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            e.Layout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            e.Layout.Override.RowSelectorWidth = 20;

            // UseRowLayout���[�hON
            e.Layout.Bands[0].UseRowLayout = true;

            // ��
            e.Layout.Override.DefaultRowHeight = 100;
            e.Layout.Override.AllowAddNew = AllowAddNew.Yes;
            e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            e.Layout.Override.AllowColMoving = AllowColMoving.NotAllowed;  // �s�ړ��s��

            // �t�B���^�[ �L��
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            
            // �w�b�_�̊T��
            e.Layout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            e.Layout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            e.Layout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            e.Layout.Override.HeaderAppearance.ForeColor = System.Drawing.Color.White;
            e.Layout.Override.HeaderAppearance.FontData.Name = "�l�r �S�V�b�N";
            e.Layout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            e.Layout.Override.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
            e.Layout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            // ��\��
            e.Layout.Bands[0].Columns[COL_DEL].Hidden = true;
            e.Layout.Bands[0].Columns[COL_SORTNO].Hidden = true;
            e.Layout.Bands[0].Columns[COL_PM_UPDATETIME].Hidden = true;
            e.Layout.Bands[0].Columns[COL_POSTPARACLASS].Hidden = true;
            e.Layout.Bands[0].Columns[COL_INDIVIDUAL].Hidden = true;
            e.Layout.Bands[0].Columns[COL_STOCKCOUNT].Hidden = true;
            e.Layout.Bands[0].Columns[COL_IMAGE_NO].Hidden = true;
            e.Layout.Bands[0].Columns[COL_IMAGE_CHANGE].Hidden = true;
            // ���v��
            e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Hidden = true;

            // BL�R�[�h
            e.Layout.Bands[0].Columns[COL_BLCD].Hidden = true;
            e.Layout.Bands[0].Columns[COL_BLCDBR].Hidden = true;
            

            // ���i�J�e�S���擾
            long category = (long)this.Category_ComboEditor.Value;
            switch (category)
            {
                case 1:
                    e.Layout.Bands[0].Columns[COL_BATTERY_KEY1].Hidden = true;
                    e.Layout.Bands[0].Columns[COL_BATTERY_KEY2].Hidden = true;
                    e.Layout.Bands[0].Columns[COL_OIL_KEY1].Hidden = true;
                    e.Layout.Bands[0].Columns[COL_OIL_KEY2].Hidden = true;
                    break;
                case 2:
                    e.Layout.Bands[0].Columns[COL_TIRE_KEY1].Hidden = true;
                    e.Layout.Bands[0].Columns[COL_TIRE_KEY2].Hidden = true;
                    e.Layout.Bands[0].Columns[COL_OIL_KEY1].Hidden = true;
                    e.Layout.Bands[0].Columns[COL_OIL_KEY2].Hidden = true;
                    break;
                case 3:
                    e.Layout.Bands[0].Columns[COL_TIRE_KEY1].Hidden = true;
                    e.Layout.Bands[0].Columns[COL_TIRE_KEY2].Hidden = true;
                    e.Layout.Bands[0].Columns[COL_BATTERY_KEY1].Hidden = true;
                    e.Layout.Bands[0].Columns[COL_BATTERY_KEY2].Hidden = true;
                    break;
            }

            // �݌ɏ�� �� ����ݒ�ɂĒʒm����ɂȂ��Ă���ꍇ�͕\��
            this.DispChangeStockState(e.Layout.Bands[0].Columns[COL_STOCKSTATE]);

            if (this._bootPara.BootMode == BootMode.SF)
            {
                // �����H�ꃂ�[�h�̏ꍇ�͕\�����Ȃ�
                e.Layout.Bands[0].Columns[COL_GROSS_PM].Hidden = true;
                e.Layout.Bands[0].Columns[COL_GROSSMARGIN_PM].Hidden = true;
                e.Layout.Bands[0].Columns[COL_PM_TITLE].Hidden = true;
                e.Layout.Bands[0].Columns[COL_PURCHASE_COST].Hidden = true;
                e.Layout.Bands[0].Columns[COL_SF_TITLE].Hidden = true;
                e.Layout.Bands[0].Columns[COL_STOCKSTATE].Hidden = true;
            }
          
            // �O��
            e.Layout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;

            // �`��
            foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
            {
                col.CellActivation = Activation.NoEdit;
                col.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

                switch (col.Key)
                {
                    #region �J������`��
                    case COL_RELEASE: // ���J
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                            col.Header.Caption = COL_RELEASE;
                            col.Width = 80;
                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.RELEASE;
                            col.RowLayoutColumnInfo.OriginY = 0;

                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_RECOMMEND: // �I�X�X��
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                            col.Header.Caption = COL_RECOMMEND;
                            col.Width = 80;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.RECOMMEND;
                            col.RowLayoutColumnInfo.OriginY = 0;

                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_GOODSNO: // �i��
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Header.Caption = COL_GOODSNO;
                            col.Width = 150;
                            col.MaxLength = 24;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.GOODSNO;
                            col.RowLayoutColumnInfo.OriginY = 0;

                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_MAKERTITLE: // ���[�J�[�^�C�g��
                        {
                            col.Header.Caption = COL_MAKERTITLE;
                            col.RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;
                            col.RowLayoutColumnInfo.SpanX = 3;
                            col.RowLayoutColumnInfo.SpanY = 1;
                            col.RowLayoutColumnInfo.OriginX = OriginX.MAKERTITLE;
                            col.RowLayoutColumnInfo.OriginY = 0;
                            col.TabStop = false;
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_MAKERCD: // ���[�J�[�R�[�h
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Header.Caption = COL_MAKERCD;
                            col.Width = 60;
                            col.MaxLength = 4;
                            col.Format = CT_CODEFORMAT;
                            col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 1;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.MAKERCD;
                            col.RowLayoutColumnInfo.OriginY = 1;
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                         
                            break;
                        }
                    case COL_MAKERGD: // ���[�J�[�K�C�h
                        {
                            col.CellActivation = Activation.NoEdit;
                            col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                            col.CellButtonAppearance.Image = this._imgList.Images[0];
                            col.ButtonDisplayStyle = ButtonDisplayStyle.Always;
                            col.Header.Caption = " ";
                            col.Width = 30;
                            col.CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                            col.CellButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 1;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.MAKERGD;
                            col.RowLayoutColumnInfo.OriginY = 1;
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_MAKERNM: // ���[�J�[����
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Header.Caption = COL_MAKERNM;
                            col.Width = 150;
                            col.MaxLength = 30;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 1;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.MAKERNM;
                            col.RowLayoutColumnInfo.OriginY = 1;

                            break;
                        }
                    case COL_TIRE_KEY1: // �^�C�������L�[�P
                        {
                            if (category == 1)
                            {
                                col.CellActivation = Activation.AllowEdit;
                                col.Header.Caption = "�T�C�Y";
                                col.Width = 120;
                                col.MaxLength = 32;

                                col.RowLayoutColumnInfo.SpanX = 1;
                                col.RowLayoutColumnInfo.SpanY = 2;
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.TIRE_KEY1;
                                col.RowLayoutColumnInfo.OriginY = 0;


                            }
                            break;
                        }
                    case COL_TIRE_KEY2: // �^�C�������L�[�Q
                        {
                            if (category == 1)
                            {
                                col.CellActivation = Activation.AllowEdit;
                                col.Header.Caption = "�X�^�b�h���X";
                                col.Width = 110;
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;

                                col.RowLayoutColumnInfo.SpanX = 1;
                                col.RowLayoutColumnInfo.SpanY = 2;
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.TIRE_KEY2;
                                col.RowLayoutColumnInfo.OriginY = 0;
                                col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            }
                            break;
                        }
                    case COL_BATTERY_KEY1: // �o�b�e�������L�[�P
                        {
                            if (category == 2)
                            {
                                col.CellActivation = Activation.AllowEdit;
                                col.Header.Caption = "�K�i";
                                col.Width = 120;
                                col.MaxLength = 32;

                                col.RowLayoutColumnInfo.SpanX = 1;
                                col.RowLayoutColumnInfo.SpanY = 2;
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.BATTERY_KEY1;
                                col.RowLayoutColumnInfo.OriginY = 0;
                            }
                            break;
                        }
                    case COL_BATTERY_KEY2: // �o�b�e�������L�[�Q
                        {
                            if (category == 2)
                            {
                                col.CellActivation = Activation.AllowEdit;
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                                col.Header.Caption = "�K��";
                                col.Width = 120;

                                Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();
                                valueList.ValueListItems.Add("1", "�W����");
                                valueList.ValueListItems.Add("2", "ISS��");
                                valueList.ValueListItems.Add("3", "���p");
                                col.ValueList = valueList;

                                col.RowLayoutColumnInfo.SpanX = 1;
                                col.RowLayoutColumnInfo.SpanY = 2;
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.BATTERY_KEY2;
                                col.RowLayoutColumnInfo.OriginY = 0;
                            }
                            break;
                        }
                    case COL_OIL_KEY1: // �I�C�������L�[�P
                        {
                            if (category == 3)
                            {
                                col.CellActivation = Activation.AllowEdit;
                                col.Header.Caption = "�S�x";
                                col.Width = 120;
                                col.MaxLength = 32;

                                col.RowLayoutColumnInfo.SpanX = 1;
                                col.RowLayoutColumnInfo.SpanY = 2;
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.OIL_KEY1;
                                col.RowLayoutColumnInfo.OriginY = 0;

                            }
                            break;
                        }
                    case COL_OIL_KEY2: // �I�C�������L�[�Q
                        {
                            if (category == 3)
                            {
                                col.CellActivation = Activation.AllowEdit;
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                                col.Header.Caption = "�K��";
                                col.Width = 120;

                                Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();
                                valueList.ValueListItems.Add("1", "�K�\������");
                                valueList.ValueListItems.Add("2", "�f�B�[�[����");
                                valueList.ValueListItems.Add("3", "���p");
                                col.ValueList = valueList;

                                col.RowLayoutColumnInfo.SpanX = 1;
                                col.RowLayoutColumnInfo.SpanY = 2;
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.OIL_KEY2;
                                col.RowLayoutColumnInfo.OriginY = 0;
                            }
                            break;
                        }
                    case COL_IMAGE: // �摜
                        {
                            col.CellActivation = Activation.NoEdit;
                            col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image;
                            col.Header.Caption = COL_IMAGE;
                            col.Width = 100;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.IMAGE;
                            col.RowLayoutColumnInfo.OriginY = 0;

                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            //col.TabStop = false;
                            break;
                        }
                    case COL_IMAGE_GUIDE: // �摜�K�C�h
                        {
                            col.CellActivation = Activation.NoEdit;
                            col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                            col.CellButtonAppearance.Image = this._imgList.Images[0];
                            col.ButtonDisplayStyle = ButtonDisplayStyle.Always;
                            col.Header.Caption = " ";
                            col.Width = 30;
                            col.CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                            col.CellButtonAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.IMAGE_GD;
                            col.RowLayoutColumnInfo.OriginY = 0;

                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }

                    case COL_GOODSNM: // ���i����
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Header.Caption = COL_GOODSNM;
                            col.Width = 240;
                            col.MaxLength = 60;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.GOODSNM;
                            col.RowLayoutColumnInfo.OriginY = 0;
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_GOODSNOTE: // ���i����
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Header.Caption = COL_GOODSNOTE;
                            col.Width = 300;
                            col.MaxLength = 256;
                            col.CellMultiLine = Infragistics.Win.DefaultableBoolean.True; // �����s����

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.GOODSNOTE;
                            col.RowLayoutColumnInfo.OriginY = 0;
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_GOODSPR: // ���iPR
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Width = 240;
                            col.MaxLength = 15;
                            col.Header.Caption = "���i���o��";

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.GOODSPR;
                            col.RowLayoutColumnInfo.OriginY = 0;
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_RELEASEDATE: // ������
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
                            col.MinValue = new DateTime(1753, 1, 1);
                            col.MaxValue = new DateTime(9998, 12, 31);
                            col.MaskInput = "yyyy�Nmm��";
                            col.Header.Caption = COL_RELEASEDATE;
                            col.Width = 110;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.RELEASEDATE;
                            col.RowLayoutColumnInfo.OriginY = 0;
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_STOCKCOUNT: // �݌ɐ�
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Header.Caption = COL_STOCKCOUNT;
                            col.MaxLength = 8;
                            col.Format = "#0.00";
                            col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                            col.Width = 70;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.STOCKCOUNT;
                            col.RowLayoutColumnInfo.OriginY = 0;

                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_STOCKSTATE: // �݌ɏ��
                        {
                            col.Header.Caption = COL_STOCKSTATE;
                            col.CellActivation = Activation.AllowEdit;
                            col.Width = 80;
                            col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;


                            Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();
                            valueList.ValueListItems.Add("-1"," ");
                            valueList.ValueListItems.Add("1", "��");
                            valueList.ValueListItems.Add("2", "��");
                            valueList.ValueListItems.Add("3", "�~");
                            col.ValueList = valueList;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.STOCKSTATE;
                            col.RowLayoutColumnInfo.OriginY = 0;

                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_SHOPSALEBEGINDATE: // ���J�J�n��
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
                            col.MinValue = new DateTime(1753, 1, 1);
                            col.MaxValue = new DateTime(9998, 12, 31);
                            col.MaskInput = "yyyy�Nmm��dd��";
                            col.Header.Caption = COL_SHOPSALEBEGINDATE;
                            col.Width = 130;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.SHOPSALEBEGINDATE;
                            col.RowLayoutColumnInfo.OriginY = 0;


                            break;
                        }
                    case COL_SHOPSALEENDDATE: // ���J�I����
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime;
                            col.MinValue = new DateTime(1753, 1, 1);
                            col.MaxValue = new DateTime(9998, 12, 31);
                            col.MaskInput = "yyyy�Nmm��dd��";
                            col.Header.Caption = COL_SHOPSALEENDDATE;
                            col.Width = 130;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.SHOPSALEENDDATE;
                            col.RowLayoutColumnInfo.OriginY = 0;
                            break;
                        }
                    case COL_SF_TITLE: // SF�^�C�g��
                        {
                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;
                                col.Header.Caption = "�����H��";
                                col.RowLayoutColumnInfo.SpanX = 4 + _repairCount;
                                if (_repairCount > 0)
                                {
                                    col.RowLayoutColumnInfo.SpanX++; // ���v�^�C�g����
                                }
                                col.RowLayoutColumnInfo.SpanY = 1;
                                col.RowLayoutColumnInfo.OriginX = OriginX.SF_TITLE;
                                col.RowLayoutColumnInfo.OriginY = 0;


                                col.Header.Appearance.BackColor = REPAIR_COLOR1;
                                col.Header.Appearance.BackColor2 = REPAIR_COLOR2;
                                col.Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                                col.Header.Appearance.ForeColor = PRPAIR_FORE;
                                col.Header.Appearance.FontData.Name = "�l�r �S�V�b�N";
                                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                                col.Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

                                col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            }
                            col.TabStop = false;
                            break;
                        }
                    case COL_SUGGEST_PRICE: // �W�����i
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Header.Caption = COL_SUGGEST_PRICE;
                            col.Format = CT_MONEYFORMAT;
                            col.MaxLength = 9;
                            col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.SUGGEST_PRICE;
                            col.RowLayoutColumnInfo.OriginY = 0;
                            col.RowLayoutColumnInfo.SpanY = 2;

                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.RowLayoutColumnInfo.OriginY = 1;
                                col.RowLayoutColumnInfo.SpanY = 1;

                                col.Header.Appearance.BackColor = REPAIR_COLOR1;
                                col.Header.Appearance.BackColor2 = REPAIR_COLOR2;
                                col.Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                                col.Header.Appearance.ForeColor = PRPAIR_FORE;
                                col.Header.Appearance.FontData.Name = "�l�r �S�V�b�N";
                                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                                col.Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
                            }

                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_SHOP_PRICE: // �X�����i
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Header.Caption = COL_SHOP_PRICE;
                            col.Format = CT_MONEYFORMAT;
                            col.MaxLength = 9;
                            col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.SHOPP_PRICE;
                            col.RowLayoutColumnInfo.OriginY = 0;
                            col.RowLayoutColumnInfo.SpanY = 2;

                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.RowLayoutColumnInfo.OriginY = 1;
                                col.RowLayoutColumnInfo.SpanY = 1;

                                col.Header.Appearance.BackColor = REPAIR_COLOR1;
                                col.Header.Appearance.BackColor2 = REPAIR_COLOR2;
                                col.Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                                col.Header.Appearance.ForeColor = PRPAIR_FORE;
                                col.Header.Appearance.FontData.Name = "�l�r �S�V�b�N";
                                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                                col.Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
                            }
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_GROSS_SF: // �e��SF 
                        {
                            col.Header.Caption = "�e��";
                            col.Format = CT_MONEYFORMAT;
                            col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.GROSS_SF + _repairCount;
                            if (_repairCount > 0)
                            {
                                col.RowLayoutColumnInfo.OriginX++; // ���v�^�C�g����
                                col.TabIndex++;
                            }
                            col.RowLayoutColumnInfo.OriginY = 0;
                            col.RowLayoutColumnInfo.SpanY = 2;

                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.GROSS_SF_PM + _repairCount;
                                if (_repairCount > 0)
                                {
                                    col.RowLayoutColumnInfo.OriginX++; // ���v�^�C�g����
                                }

                                col.RowLayoutColumnInfo.OriginY = 1;
                                col.RowLayoutColumnInfo.SpanY = 1;

                                col.Header.Appearance.BackColor = REPAIR_COLOR1;
                                col.Header.Appearance.BackColor2 = REPAIR_COLOR2;
                                col.Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                                col.Header.Appearance.ForeColor = PRPAIR_FORE;
                                col.Header.Appearance.FontData.Name = "�l�r �S�V�b�N";
                                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                                col.Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
                            }
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_GROSSMARGIN_SF: // �e����SF
                        {
                            col.Header.Caption = "�e����";
                            col.Format = CT_PARCENTFROMAT;
                            col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.GROSSMARGIN_SF + _repairCount;
                            if (_repairCount > 0)
                            {
                                col.RowLayoutColumnInfo.OriginX++; // ���v�^�C�g����
                                col.TabIndex++;
                            }
                            col.RowLayoutColumnInfo.OriginY = 0;
                            col.RowLayoutColumnInfo.SpanY = 2;

                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.GROSSMARGIN_SF_PM + _repairCount;
                                if (_repairCount > 0)
                                {
                                    col.RowLayoutColumnInfo.OriginX++; // ���v�^�C�g����
                                }
                                col.RowLayoutColumnInfo.OriginY = 1;
                                col.RowLayoutColumnInfo.SpanY = 1;

                                col.Header.Appearance.BackColor = REPAIR_COLOR1;
                                col.Header.Appearance.BackColor2 = REPAIR_COLOR2;
                                col.Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                                col.Header.Appearance.ForeColor = PRPAIR_FORE;
                                col.Header.Appearance.FontData.Name = "�l�r �S�V�b�N";
                                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                                col.Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
                            }

                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_PM_TITLE: // PM�^�C�g��
                        {
                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.RowLayoutColumnInfo.LabelPosition = LabelPosition.LabelOnly;
                                col.Header.Caption = "���i��";
                                col.RowLayoutColumnInfo.SpanX = 4;
                                col.RowLayoutColumnInfo.SpanY = 1;
                                col.RowLayoutColumnInfo.OriginX = OriginX.PM_TITLE + _repairCount;
                                col.RowLayoutColumnInfo.OriginY = 0;
                            }
                            col.TabStop = false;

                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_TRADE_PRICE: // �����H�ꃂ�[�h:�d�������A���i�����[�h���Ɣ���
                        {
                            col.CellActivation = Activation.AllowEdit;
                            col.Header.Caption = "�d������";
                            col.Format = CT_MONEYFORMAT;
                            col.MaxLength = 9;
                            col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                            col.RowLayoutColumnInfo.SpanX = 1;
                            col.RowLayoutColumnInfo.SpanY = 2;
                            col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.TRADE_PRICE_SF + _repairCount;
                            col.RowLayoutColumnInfo.OriginY = 0;

                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.Header.Caption = COL_TRADE_PRICE;
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.TRADE_PRICE_PM + _repairCount;
                                col.RowLayoutColumnInfo.OriginY = 1;
                                col.RowLayoutColumnInfo.SpanY = 1;
                            }
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_PURCHASE_COST: // �d������
                        {
                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.CellActivation = Activation.AllowEdit;
                                col.Header.Caption = COL_PURCHASE_COST;
                                col.Format = CT_MONEYFORMAT;
                                col.MaxLength = 9;
                                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                                col.RowLayoutColumnInfo.SpanX = 1;
                                col.RowLayoutColumnInfo.SpanY = 1;
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.PURCHASE_COST + _repairCount;
                                col.RowLayoutColumnInfo.OriginY = 1;
                            }
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_GROSS_PM: // �e��PM
                        {
                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.Header.Caption = "�e��";
                                col.Format = CT_MONEYFORMAT;
                                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                                col.RowLayoutColumnInfo.SpanX = 1;
                                col.RowLayoutColumnInfo.SpanY = 1;
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.GROSS_PM + _repairCount;
                                col.RowLayoutColumnInfo.OriginY = 1;
                            }
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_GROSSMARGIN_PM: // �e����PM
                        {
                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.Header.Caption = "�e����";
                                col.Format = CT_PARCENTFROMAT;
                                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                                col.RowLayoutColumnInfo.SpanX = 1;
                                col.RowLayoutColumnInfo.SpanY = 1;
                                col.RowLayoutColumnInfo.OriginX = col.TabIndex = OriginX.GROSSMARGIN_PM + _repairCount;
                                col.RowLayoutColumnInfo.OriginY = 1;
                            }
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            break;
                        }
                    case COL_INDIVIDUAL: // ���Ӑ�ʐݒ�
                        {
                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                col.Header.Caption = COL_INDIVIDUAL;
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;

                                col.RowLayoutColumnInfo.SpanX = 1;
                                col.RowLayoutColumnInfo.SpanY = 2;
                                col.RowLayoutColumnInfo.OriginX = OriginX.INDIVIDUAL + _repairCount;
                                col.RowLayoutColumnInfo.OriginY = 0;
                            }
                            col.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                            col.TabStop = false;
                            break;
                        }
                    #endregion
                }
            }

            int count = OriginX.REPAIR;
            List<AttendRepairSet> list = new List<AttendRepairSet>();
            if (this._attendRepairSetDic.ContainsKey((long)this.Category_ComboEditor.Value))
            {
                list = this._attendRepairSetDic[(long)this.Category_ComboEditor.Value];

                for (int i = 0; i < list.Count; i++)
                {
                    string key = "";
                    if (this._bootPara.BootMode == BootMode.PM)
                    {
                        key = this.MakeAttenRepairKey(list[i].attendRepairId.ToString());
                    }
                    else
                    {
                        key = this.MakeAttenRepairKey(list[i].storeAttendRepairId.ToString());
                    }

                    e.Layout.Bands[0].Columns[key].CellActivation = Activation.AllowEdit;
                    e.Layout.Bands[0].Columns[key].Header.Caption = list[i].repairName;
                    e.Layout.Bands[0].Columns[key].Format = CT_MONEYFORMAT;
                    e.Layout.Bands[0].Columns[key].MaxLength = 9;
                    e.Layout.Bands[0].Columns[key].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    e.Layout.Bands[0].Columns[key].DefaultCellValue = list[i].repairPrice;

                    e.Layout.Bands[0].Columns[key].RowLayoutColumnInfo.SpanX = 1;
                    e.Layout.Bands[0].Columns[key].RowLayoutColumnInfo.SpanY = 2;

                    e.Layout.Bands[0].Columns[key].RowLayoutColumnInfo.OriginY = 0;

                    if (this._bootPara.BootMode == BootMode.PM)
                    {
                        e.Layout.Bands[0].Columns[key].RowLayoutColumnInfo.SpanY = 1;
                        e.Layout.Bands[0].Columns[key].RowLayoutColumnInfo.OriginY = 1;

                        e.Layout.Bands[0].Columns[key].Header.Appearance.BackColor = REPAIR_COLOR1;
                        e.Layout.Bands[0].Columns[key].Header.Appearance.BackColor2 = REPAIR_COLOR2;
                        e.Layout.Bands[0].Columns[key].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        e.Layout.Bands[0].Columns[key].Header.Appearance.ForeColor = PRPAIR_FORE;
                        e.Layout.Bands[0].Columns[key].Header.Appearance.FontData.Name = "�l�r �S�V�b�N";
                        e.Layout.Bands[0].Columns[key].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                        e.Layout.Bands[0].Columns[key].Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

                    }
                    e.Layout.Bands[0].Columns[key].RowLayoutColumnInfo.OriginX = e.Layout.Bands[0].Columns[key].TabIndex = count++;

                    e.Layout.Bands[0].Columns[key].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

                }
            }

            // ���v��
            if (list.Count > 0)
            {
                // �t���������聨���v���\��
                e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Hidden = false;
                e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;


                e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].CellActivation = Activation.NoEdit;
                e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Format = CT_MONEYFORMAT;
                e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].RowLayoutColumnInfo.SpanX = 1;
                e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].RowLayoutColumnInfo.SpanY = 2;
                e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].RowLayoutColumnInfo.OriginX = e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].TabIndex = OriginX.MONEY_TOTAL + _repairCount;
                e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].RowLayoutColumnInfo.OriginY = 0;

                if (this._bootPara.BootMode == BootMode.PM)
                {
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].RowLayoutColumnInfo.OriginY = 1;
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].RowLayoutColumnInfo.SpanY = 1;
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Header.Appearance.BackColor = REPAIR_COLOR1;
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Header.Appearance.BackColor2 = REPAIR_COLOR2;
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Header.Appearance.ForeColor = PRPAIR_FORE;
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Header.Appearance.FontData.Name = "�l�r �S�V�b�N";
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
                }

                // �L���v�V��������
                if (this._bootPara.BootMode == BootMode.SF)
                {
                    #region SF���[�h + �t�������L��
                    // �@���v
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Header.Caption = "�@" + COL_MONEY_TOTAL;
                    // �A�d������
                    e.Layout.Bands[0].Columns[COL_TRADE_PRICE].Header.Caption = "�A" + COL_PURCHASE_COST;
                    // �BSF�e��
                    e.Layout.Bands[0].Columns[COL_GROSS_SF].Header.Caption = "�B" + "�e��" + "(�@-�A)";
                    // �C�e����
                    e.Layout.Bands[0].Columns[COL_GROSSMARGIN_SF].Header.Caption = "�e����" + "(�B/�@)";

                    #endregion
                }
                else
                {
                    #region PM���[�h + �t�������L��
                    // �@���v
                    e.Layout.Bands[0].Columns[COL_MONEY_TOTAL].Header.Caption = "�@" + "���v";
                    // �A����
                    e.Layout.Bands[0].Columns[COL_TRADE_PRICE].Header.Caption = "�A" + COL_TRADE_PRICE;
                    // �BSF�e��
                    e.Layout.Bands[0].Columns[COL_GROSS_SF].Header.Caption = "�B" + "�e��" + "(�@-�A)";
                    // �C�e����
                    e.Layout.Bands[0].Columns[COL_GROSSMARGIN_SF].Header.Caption = "�e����" + "(�B/�@)";

                    // PM��
                    // �D�d������
                    e.Layout.Bands[0].Columns[COL_PURCHASE_COST].Header.Caption = "�D" + COL_PURCHASE_COST;
                    // �EPM�e��
                    e.Layout.Bands[0].Columns[COL_GROSS_PM].Header.Caption = "�E" + "�e��" + "(�A-�D)";
                    // �FPM�e����
                    e.Layout.Bands[0].Columns[COL_GROSSMARGIN_PM].Header.Caption = "�e����" + "(�E/�A)";
                    #endregion
                }
            }
            else
            {
                // �t�������Ȃ�

                if (this._bootPara.BootMode == BootMode.SF)
                {
                    #region SF���[�h + �t����������
                    // �@�X�����i
                    e.Layout.Bands[0].Columns[COL_SHOP_PRICE].Header.Caption = "�@" + COL_SHOP_PRICE;
                    // �A�d������
                    e.Layout.Bands[0].Columns[COL_TRADE_PRICE].Header.Caption = "�A" + COL_PURCHASE_COST;
                    // �BSF�e��
                    e.Layout.Bands[0].Columns[COL_GROSS_SF].Header.Caption = "�B" + "�e��" + "(�@-�A)";
                    // �C�e����
                    e.Layout.Bands[0].Columns[COL_GROSSMARGIN_SF].Header.Caption = "�e����" + "(�B/�@)";

                    #endregion

                }
                else
                {
                    #region PM���[�h + �t��������
                    // �@�X�����i
                    e.Layout.Bands[0].Columns[COL_SHOP_PRICE].Header.Caption = "�@" + COL_SHOP_PRICE;
                    // �A����
                    e.Layout.Bands[0].Columns[COL_TRADE_PRICE].Header.Caption = "�A" + COL_TRADE_PRICE;
                    // �BSF�e��
                    e.Layout.Bands[0].Columns[COL_GROSS_SF].Header.Caption = "�B" + "�e��" + "(�@-�A)";
                    // �C�e����
                    e.Layout.Bands[0].Columns[COL_GROSSMARGIN_SF].Header.Caption = "�e����" + "(�B/�@)";

                    // PM��
                    // �D�d������
                    e.Layout.Bands[0].Columns[COL_PURCHASE_COST].Header.Caption = "�D" + COL_PURCHASE_COST;
                    // �EPM�e��
                    e.Layout.Bands[0].Columns[COL_GROSS_PM].Header.Caption = "�E" + "�e��" + "(�A-�D)";
                    // �FPM�e����
                    e.Layout.Bands[0].Columns[COL_GROSSMARGIN_PM].Header.Caption = "�e����" + "(�E/�A)";

                    #endregion
                }

            }

            // �w�b�_�[�Ƀ`�F�b�N�{�b�N�X�\��
            this.InitCheckBoxOnColumnHeader();

            // �{�^������
            this.SetSpButtonEnabled(true);
        }



        /// <summary>
        /// �O���b�h�� Boolean ��̗�w�b�_�ɁA�`�F�b�N�{�b�N�X��\�����܂��B
        /// </summary>
        private void InitCheckBoxOnColumnHeader()
        {
            // �쐬�t�B���^�[�̃C���X�^���X���쐬���܂��B
            TBOCustomFilter filter = new TBOCustomFilter();
            // ��w�b�_��̃`�F�b�N�{�b�N�X���N���b�N���ꂽ�Ƃ��ɔ�������C�x���g�̃n���h�����`���܂��B
            filter.CheckChanged += new TBOCustomFilter.HeaderCheckBoxClickedHandler(OnHeaderCheckBoxCheckChanged);
            // �쐬�t�B���^�[���O���b�h�� CreationFilter �v���p�e�B�Ɋ��蓖�Ă܂��B
            this.Goods_Grid.CreationFilter = filter;
        }

        /// <summary>
        /// �O���b�h�w�b�_�[�`�F�b�N�{�b�N�X�N���b�N���̏���
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�w�b�_�[�`�F�b�N�{�b�N�X�N���b�N���ꂽ���ɁA�������s���܂��B</br>
        /// </remarks>
        internal void OnHeaderCheckBoxCheckChanged(object sender, TBOCustomFilter.HeaderCheckBoxEventArgs e)
        {
            this.UpDateGrid();
        }

        /// <summary>
        /// �݌ɏ�ԃJ�����\���ؑ�
        /// </summary>
        /// <param name="ultraGridColumn"></param>
        private void DispChangeStockState(UltraGridColumn ultraGridColumn)
        {
            if (this._settingsDic.ContainsKey(this.Section_ComboEditor.Value.ToString()))
            {
                if (this._settingsDic[this.Section_ComboEditor.Value.ToString()].stockDisplayFlag)
                {
                    // �ʒm����
                    ultraGridColumn.Hidden = false;
                }
                else
                {
                    // �ʒm���Ȃ�
                    ultraGridColumn.Hidden = true;
                }
            }
            else
            {
                // �ݒ�Ȃ�
                ultraGridColumn.Hidden = true;
            }
        }

        #endregion

        #region KeyPress
        /// <summary>
        /// Grid KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.Goods_Grid.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Goods_Grid.ActiveCell;

                switch (cell.Column.Key)
                {
                    case COL_MAKERCD:
                        if (this.Goods_Grid.ActiveCell.Activation == Activation.AllowEdit && this.Goods_Grid.ActiveCell.IsInEditMode)
                        {
                            e.Handled = !KeyPressCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false);
                        }
                        break;
                    case COL_SUGGEST_PRICE:
                    case COL_SHOP_PRICE:
                    case COL_TRADE_PRICE:
                    case COL_PURCHASE_COST:
                        if (this.Goods_Grid.ActiveCell.Activation == Activation.AllowEdit && this.Goods_Grid.ActiveCell.IsInEditMode)
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
                // �t������
                if (this._attendRepairColDic.ContainsKey((long)this.Category_ComboEditor.Value))
                {
                    if (this._attendRepairColDic[(long)this.Category_ComboEditor.Value].Contains(cell.Column.Key))
                    {
                        if (this.Goods_Grid.ActiveCell.Activation == Activation.AllowEdit && this.Goods_Grid.ActiveCell.IsInEditMode)
                        {
                            if (!KeyPressCheck(9, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                            {
                                e.Handled = true;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region AfterSelectChange
        /// <summary>
        /// �O���b�h�I����ԕύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            // �{�^������
            this.SetRowDelEnabled();
        }
        #endregion

        #region InitializeRow
        /// <summary>
        /// Goods_Grid_InitializeRow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (e.Row.Cells[COL_POSTPARACLASS].Value == DBNull.Value)
            {
                e.Row.Cells[COL_GOODSNO].Activation = Activation.AllowEdit;
                e.Row.Cells[COL_MAKERCD].Activation = Activation.AllowEdit;
                e.Row.Cells[COL_MAKERGD].Activation = Activation.AllowEdit;
                e.Row.Cells[COL_MAKERNM].Activation = Activation.AllowEdit;
            }
            else
            {
                e.Row.Cells[COL_GOODSNO].Activation = Activation.NoEdit;
                e.Row.Cells[COL_MAKERCD].Activation = Activation.NoEdit;
                e.Row.Cells[COL_MAKERGD].Activation = Activation.Disabled;
                e.Row.Cells[COL_MAKERNM].Activation = Activation.NoEdit;

                e.Row.Cells[COL_GOODSNO].Appearance.BackColor = READONLY_CELL_COLOR;
                e.Row.Cells[COL_MAKERCD].Appearance.BackColor = READONLY_CELL_COLOR;
                e.Row.Cells[COL_MAKERGD].Appearance.BackColor = READONLY_CELL_COLOR;
                e.Row.Cells[COL_MAKERNM].Appearance.BackColor = READONLY_CELL_COLOR;
            }
            e.Row.Cells[COL_GROSS_SF].Appearance.BackColor = READONLY_CELL_COLOR;
            e.Row.Cells[COL_GROSS_PM].Appearance.BackColor = READONLY_CELL_COLOR;
            e.Row.Cells[COL_GROSSMARGIN_PM].Appearance.BackColor = READONLY_CELL_COLOR;
            e.Row.Cells[COL_GROSSMARGIN_SF].Appearance.BackColor = READONLY_CELL_COLOR;

            e.Row.Cells[COL_MONEY_TOTAL].Appearance.BackColor = READONLY_CELL_COLOR;

        }
        #endregion

        #region KeyDown
        /// <summary>
        /// �L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            // �ҏW���ł������ꍇ
            if (this.Goods_Grid.ActiveCell != null)
            {
                // �A�N�e�B�u�Z��
                UltraGridCell activeCell = this.Goods_Grid.ActiveCell;

                // �Z���̃X�^�C���ɂĔ���
                switch (activeCell.StyleResolved)
                {
                    // �e�L�X�g�{�b�N�X�E�e�L�X�g�{�b�N�X(�{�^���t)
                    case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                        switch (e.KeyData)
                        {
                            // ���L�[
                            case Keys.Left:
                                if (activeCell.IsInEditMode && activeCell.SelStart == 0)
                                {
                                    this.Goods_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                    e.Handled = true;
                                }
                                else if (!activeCell.IsInEditMode)
                                {
                                    UltraGridCell prevCell = GetPrevCell(activeCell);
                                    if (prevCell != null)
                                    {
                                        prevCell.Activate();
                                        prevCell.Selected = true;
                                        if (prevCell.Activation == Activation.AllowEdit)
                                        {
                                            this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                    }
                                    else
                                    {
                                        this.Goods_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                    }
                                    e.Handled = true;
                                }
                                break;
                            // ���L�[
                            case Keys.Right:
                                if (activeCell.IsInEditMode && (activeCell.SelStart >= activeCell.Text.Length))
                                {
                                    this.Goods_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                    e.Handled = true;
                                }
                                else if (!activeCell.IsInEditMode)
                                {
                                    UltraGridCell nextCell = GetNextCell(activeCell);
                                    if (nextCell != null)
                                    {
                                        nextCell.Activate();
                                        nextCell.Selected = true;
                                        if (nextCell.Activation == Activation.AllowEdit)
                                        {
                                            this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                    }
                                    else
                                    {
                                        this.Goods_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                    }
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
                                            this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                    }
                                    this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    this.CalcPrice_Button.Focus();
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
                                            this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                    }
                                }
                                e.Handled = true;
                                break;
                        }

                        // ���s
                        if (e.KeyCode == Keys.Enter && e.Alt)
                        {
                            if (this.Goods_Grid.ActiveCell != null && (this.Goods_Grid.ActiveCell.Column.Key == COL_GOODSNOTE))
                            {
                                // ���s
                                try
                                {
                                    int index = this.Goods_Grid.ActiveCell.SelStart;
                                    string insertVal = this.Goods_Grid.ActiveCell.Text;
                                    int length = insertVal.Length;
                                    if (length + 2 <= this.Goods_Grid.ActiveCell.Column.MaxLength)
                                    {
                                        string wk = insertVal.Insert(index, Environment.NewLine);
                                        this.Goods_Grid.ActiveCell.Value = wk;
                                        this.Goods_Grid.ActiveCell.SelStart = index + 2;  // rn��
                                    }
                                }
                                catch
                                {

                                }
                            }
                        }
                        break;
                    case Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList:  // �h���b�v�_�E��
                        switch (e.KeyData)
                        {
                            // ���L�[
                            case Keys.Left:
                                this.Goods_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                e.Handled = true;
                                break;
                            // ���L�[
                            case Keys.Right:
                                this.Goods_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                e.Handled = true;
                                break;
                            // ���L�[
                            case Keys.Down:
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
                                            this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                    }
                                }
                                e.Handled = true;
                                break;
                            // ���L�[ 
                            case Keys.Up:
                                if (activeCell.DroppedDown)
                                {
                                    return;
                                }
                                else if (activeCell.Row.HasPrevSibling())
                                {
                                    UltraGridRow prevRow = activeCell.Row.GetSibling(SiblingRow.Previous);
                                    UltraGridCell prevCel = prevRow.Cells[activeCell.Column.Key];
                                    if (prevCel != null)
                                    {
                                        prevCel.Activate();
                                        prevCel.Selected = true;
                                        if (prevCel.Activation == Activation.AllowEdit)
                                        {
                                            this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                    }
                                }
                                else
                                {
                                    this.CalcPrice_Button.Focus();
                                }
                                e.Handled = true;
                                break;
                        }
                        break;
                    case Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime:  // ���t
                        switch (e.KeyData)
                        {
                            // ���L�[
                            case Keys.Left:
                                if (activeCell.DroppedDown)
                                {
                                    return;
                                }
                                else
                                {
                                    this.Goods_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                }
                                e.Handled = true;
                                break;
                            // ���L�[
                            case Keys.Right:
                                if (activeCell.DroppedDown)
                                {
                                    return;
                                }
                                else
                                {
                                    this.Goods_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                }
                                e.Handled = true;
                                break;
                            // ���L�[
                            case Keys.Down:
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
                                            this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                    }
                                }
                                e.Handled = true;
                                break;
                            // ���L�[ 
                            case Keys.Up:
                                if (activeCell.DroppedDown)
                                {
                                    return;
                                }
                                else if (activeCell.Row.HasPrevSibling())
                                {
                                    UltraGridRow prevRow = activeCell.Row.GetSibling(SiblingRow.Previous);
                                    UltraGridCell prevCel = prevRow.Cells[activeCell.Column.Key];
                                    if (prevCel != null)
                                    {
                                        prevCel.Activate();
                                        prevCel.Selected = true;
                                        if (prevCel.Activation == Activation.AllowEdit)
                                        {
                                            this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                    }
                                }
                                else
                                {
                                    this.CalcPrice_Button.Focus();
                                }
                                e.Handled = true;
                                break;
                        }
                        break;
                    // ��L�ȊO�̃X�^�C�� �`�F�b�N�{�b�N�X�Ȃ�
                    default:
                        switch (e.KeyData)
                        {
                            // ���L�[
                            case Keys.Left:
                                // �ŏ��̃Z��
                                if (activeCell.Column.Key == COL_RELEASE)
                                {
                                    if (activeCell.Row.HasPrevSibling())
                                    {
                                        UltraGridRow prevRow = activeCell.Row.GetSibling(SiblingRow.Previous);
                                        UltraGridCell prevCel = null;
                                        if (this._bootPara.BootMode == BootMode.PM)
                                        {
                                            prevCel = prevRow.Cells[COL_GROSSMARGIN_PM];
                                        }
                                        else
                                        {
                                            prevCel = prevRow.Cells[COL_GROSSMARGIN_SF];
                                        }

                                        if (prevCel != null)
                                        {
                                            prevCel.Activate();
                                            prevCel.Selected = true;
                                            if (prevCel.Activation == Activation.AllowEdit)
                                            {
                                                this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    this.Goods_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                }
                                e.Handled = true;
                                break;
                            // ���L�[
                            case Keys.Right:
                                // �ŏI�Z��
                                if (activeCell.Column.Key == COL_GROSSMARGIN_PM)
                                {
                                    if (activeCell.Row.HasNextSibling())
                                    {
                                        UltraGridRow nextRow = activeCell.Row.GetSibling(SiblingRow.Next);
                                        UltraGridCell nextCel = nextRow.Cells[COL_RELEASE];

                                        if (nextCel != null)
                                        {
                                            nextCel.Activate();
                                            nextCel.Selected = true;
                                            if (nextCel.Activation == Activation.AllowEdit)
                                            {
                                                this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                            }
                                        }
                                    }
                                }
                                else if (activeCell != null && activeCell.Column.Key == COL_GROSSMARGIN_SF)
                                {
                                    if (this._bootPara.BootMode == BootMode.SF)
                                    {
                                        if (activeCell.Row.HasNextSibling())
                                        {
                                            UltraGridRow nextRow = activeCell.Row.GetSibling(SiblingRow.Next);
                                            UltraGridCell nextCel = nextRow.Cells[COL_RELEASE];
                                            if (nextCel != null)
                                            {
                                                nextCel.Activate();
                                                nextCel.Selected = true;
                                                if (nextCel.Activation == Activation.AllowEdit)
                                                {
                                                    this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        this.Goods_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                    }
                                }
                                else
                                {
                                    this.Goods_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                }
                                e.Handled = true;
                                break;
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
                                            this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        }
                                    }
                                    this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    this.CalcPrice_Button.Focus();
                                }
                                e.Handled = true;
                                break;
                            // ���L�[
                            case Keys.Down:
                                if (activeCell.Row.HasNextSibling())
                                {
                                    UltraGridRow belowRow = activeCell.Row.GetSibling(SiblingRow.Next);
                                    UltraGridCell belowCel = belowRow.Cells[activeCell.Column.Key];

                                    belowCel.Activate();
                                    belowCel.Selected = true;
                                    if (belowCel.Activation == Activation.AllowEdit)
                                    {
                                        this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                                e.Handled = true;
                                break;
                            case Keys.Space:
                                if (activeCell.Activation != Activation.Disabled)
                                {
                                    if (activeCell.Column.Key == COL_MAKERGD)
                                    {
                                        // ���[�J�[�K�C�h
                                        this.ShowMakerGuide(activeCell.Row.Index);
                                    }
                                    else if (activeCell.Column.Key == COL_IMAGE_GUIDE)
                                    {
                                        // �摜�K�C�h
                                        this.ShowImageGuide(activeCell.Row.Index);
                                    }
                                    else if (activeCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox)
                                    {
                                        activeCell.Value = !((bool)activeCell.Value);
                                    }
                                }
                                e.Handled = true;
                                break;
                        }
                        break;
                }
            }

            // �s�R�s�[�A�\��t��
            if (this.Goods_Grid.Selected.Rows != null && this.Goods_Grid.Selected.Rows.Count > 0)
            {
                if (e.KeyCode == Keys.C && e.Control)
                {
                    // �R�s�[
                    this.ROW_COPY_Click(this.Goods_Grid, new EventArgs());
                }
                else if (e.KeyCode == Keys.V && e.Control)
                {
                    // �\��t��
                    this.ROW_PAST_Click(this.Goods_Grid, new EventArgs());
                }
                else if (e.KeyCode == Keys.A && e.Control)
                {
                    // �S�I��
                    foreach (UltraGridRow row in this.Goods_Grid.Rows)
                    {
                        if (!row.IsFilteredOut)
                        {
                            row.Selected = true;
                        }
                    }
                }
            }
        }
        #endregion

        #region CellChange
        /// <summary>
        /// Goods_Grid_CellChange
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            string columnKey = e.Cell.Column.Key;
            if (columnKey == COL_RELEASE)
            {
                if (this.Goods_Grid.ActiveRow.Cells[COL_RELEASE].Text == "True")
                {
                    this.Goods_Grid.ActiveRow.Cells[COL_RELEASE].Value = true;
                }
                else
                {
                    this.Goods_Grid.ActiveRow.Cells[COL_RELEASE].Value = false;
                }
            }
            else if (columnKey == COL_RECOMMEND)
            {
                if (this.Goods_Grid.ActiveRow.Cells[COL_RECOMMEND].Text == "True")
                {
                    this.Goods_Grid.ActiveRow.Cells[COL_RECOMMEND].Value = true;
                }
                else
                {
                    this.Goods_Grid.ActiveRow.Cells[COL_RECOMMEND].Value = false;
                }
            }
            else if (columnKey == COL_TIRE_KEY2)
            {
                if (this.Goods_Grid.ActiveRow.Cells[COL_TIRE_KEY2].Text == "True")
                {
                    this.Goods_Grid.ActiveRow.Cells[COL_TIRE_KEY2].Value = true;
                }
                else
                {
                    this.Goods_Grid.ActiveRow.Cells[COL_TIRE_KEY2].Value = false;
                }
            }

            // ���݂̃A�N�e�B�u�Z���̃X�^�C����Edit or Default �̏ꍇ
            if ((this.Goods_Grid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
                (this.Goods_Grid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default))
            {
                // �ύX���ꂽ���ʁAText���󔒂ƂȂ����ꍇ
                if ((this.Goods_Grid.ActiveCell.Text == null) || ((this.Goods_Grid.ActiveCell.Text != null) && (this.Goods_Grid.ActiveCell.Text.Trim() == "")))
                {
                    // ���݂̃Z���̌^���AInt32�AInt64�Adouble�^�̏ꍇ
                    if ((this.Goods_Grid.ActiveCell.Column.DataType == typeof(Int32)) ||
                        (this.Goods_Grid.ActiveCell.Column.DataType == typeof(Int64)) ||
                        (this.Goods_Grid.ActiveCell.Column.DataType == typeof(double)))
                    {
                        // �l���󔒂Ƃ͂����ɁA"0"���Z�b�g����
                        this.Goods_Grid.ActiveCell.Value = 0;
                        return;
                    }
                }
            }
        }
        #endregion

        #region AfterEnterEditMode
        /// <summary>
        /// Goods_Grid_AfterEnterEditMode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_AfterEnterEditMode(object sender, EventArgs e)
        {
            // �ҏW���[�h�ɂȂ�����I�����
            this.Goods_Grid.ActiveCell.SelectAll();
        }
        #endregion

        #region CellDataError
        /// <summary>
        /// ���̓G���[��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.Goods_Grid.ActiveCell != null)
            {
                CellDataErrorProc();
                e.RaiseErrorEvent = false;			// �G���[�C�x���g�͔��������Ȃ�
                e.RestoreOriginalValue = false;		// �Z���̒l�����ɖ߂��Ȃ�
                e.StayInEditMode = false;			// �ҏW���[�h�͔�����
            }
        }
        #endregion

        #region AfterCellActivate
        /// <summary>
        /// AfterCellActivate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_AfterCellActivate(object sender, EventArgs e)
        {
            //��A�N�e�B�u����r�p�Ƀo�b�t�@�����O
            this._tempCell = this.Goods_Grid.ActiveCell;
            if (this._tempCell != null)
            {
                this._tempValue = this._tempCell.Value;
            }
            else
            {
                this._tempValue = null;
            }
            // IME����
            this.Goods_Grid.ImeMode = ImeMode.Off;
            if (this.Goods_Grid.ActiveCell.Row.GetCellActivationResolved(this.Goods_Grid.ActiveCell.Column) != Activation.Disabled)
            {
                switch (this.Goods_Grid.ActiveCell.Column.Key)
                {
                    case COL_GOODSNOTE:
                    case COL_GOODSPR:
                    case COL_MAKERNM:
                        {
                            this.Goods_Grid.ImeMode = ImeMode.Hiragana;
                            break;
                        }
                    case COL_GOODSNO:
                        {
                            this.Goods_Grid.ImeMode = ImeMode.Disable;
                            break;
                        }
                }
                if (this.Goods_Grid.ActiveCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
                    this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
            }
        }
        #endregion

        #region BeforeExitEditMode
        /// <summary>
        /// BeforeExitEditMode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_BeforeExitEditMode(object sender, BeforeExitEditModeEventArgs e)
        {
            try
            {
                // AfterCellActivate�C�x���g�ŕߑ������Z���ł��邩�H
                if ((this.Goods_Grid.ActiveCell != null) && (this._tempCell == this.Goods_Grid.ActiveCell))
                {
                    // �R�s�y�Ή�
                    if (this.Goods_Grid.ActiveCell.Column.DataType == typeof(int) && this.Goods_Grid.ActiveCell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                        Convert.ToInt32(this.Goods_Grid.ActiveCell.Text);
                    else if (this.Goods_Grid.ActiveCell.Column.DataType == typeof(long))
                        //Convert.ToInt64(this.Goods_Grid.ActiveCell.Text);
                        Convert.ToInt64(this.Goods_Grid.ActiveCell.Value);
                    else if (this.Goods_Grid.ActiveCell.Column.DataType == typeof(double))
                        Convert.ToDouble(this.Goods_Grid.ActiveCell.Text);

                    //�O���b�h�̃A�b�v�f�[�g
                    this.Goods_Grid.UpdateData();
                    //�f�[�^�e�[�u���ւ̕ύX���R�~�b�g
                    this.TBODataSet.Tables[TABLE_MAIN].AcceptChanges();
                    //�`����Ƃ߂�
                    this.Goods_Grid.BeginUpdate();

                    // �l�ɕύX���������H
                    if (this.Goods_Grid.ActiveCell.Value.ToString() != this._tempValue.ToString())
                    {
                        int index = GetActiveIndex();

                        long shopPrice = GetCellLong(this.Goods_Grid.Rows[index].Cells[COL_SHOP_PRICE].Value, 0);      // �X�����i
                        long repareTotal = CalcRepareTotal(index);                                                      // �t���������v���z
                        long tradePrice = GetCellLong(this.Goods_Grid.Rows[index].Cells[COL_TRADE_PRICE].Value, 0);     // ���l
                        long cost = GetCellLong(this.Goods_Grid.Rows[index].Cells[COL_PURCHASE_COST].Value, 0);         // �d������
                        long grossSF = 0;
                        string grossMarginSF = "";
                        long grossPM = 0;
                        string grossMarginPM = "";

                        if (this.Goods_Grid.ActiveCell.Column.Key.Contains(COL_REPARE))
                        {
                            // �t�������J����
                            // �����H��̑e�����Čv�Z
                            this.CalcGrossSF(shopPrice, repareTotal, tradePrice, out grossSF, out grossMarginSF);
                            // �v�Z���ʂ�W�J
                            this.Goods_Grid.Rows[index].Cells[COL_GROSS_SF].Value = grossSF;
                            this.Goods_Grid.Rows[index].Cells[COL_GROSSMARGIN_SF].Value = grossMarginSF;

                            // ���v���z���v�Z
                            this.Goods_Grid.Rows[index].Cells[COL_MONEY_TOTAL].Value = shopPrice + repareTotal;
                        }
                        else if (this.Goods_Grid.ActiveCell.Column.Key == COL_SHOP_PRICE)   // �X�����i
                        {
                            // �����H��̑e�����Čv�Z
                            this.CalcGrossSF(shopPrice, repareTotal, tradePrice, out grossSF, out grossMarginSF);
                            // �v�Z���ʂ�W�J
                            this.Goods_Grid.Rows[index].Cells[COL_GROSS_SF].Value = grossSF;
                            this.Goods_Grid.Rows[index].Cells[COL_GROSSMARGIN_SF].Value = grossMarginSF;

                            // ���v���z���v�Z
                            this.Goods_Grid.Rows[index].Cells[COL_MONEY_TOTAL].Value = shopPrice + repareTotal;
                        }
                        else if (this.Goods_Grid.ActiveCell.Column.Key == COL_TRADE_PRICE)    // ���l
                        {
                            // �����̑e�����Čv�Z

                            // �����H��̑e�����Čv�Z
                            this.CalcGrossSF(shopPrice, repareTotal, tradePrice, out grossSF, out grossMarginSF);
                            // �v�Z���ʂ�W�J
                            this.Goods_Grid.Rows[index].Cells[COL_GROSS_SF].Value = grossSF;
                            this.Goods_Grid.Rows[index].Cells[COL_GROSSMARGIN_SF].Value = grossMarginSF;

                            // ���i���̑e�����Čv�Z
                            this.CalcGrossPM(tradePrice, cost, out grossPM, out grossMarginPM);
                            // �v�Z���ʂ�W�J
                            this.Goods_Grid.Rows[index].Cells[COL_GROSS_PM].Value = grossPM;
                            this.Goods_Grid.Rows[index].Cells[COL_GROSSMARGIN_PM].Value = grossMarginPM;

                            // ���v���z���v�Z
                            this.Goods_Grid.Rows[index].Cells[COL_MONEY_TOTAL].Value = shopPrice + repareTotal;

                        }
                        else if (this.Goods_Grid.ActiveCell.Column.Key == COL_PURCHASE_COST)   //�@�d������
                        {
                            // ���i���̑e�����Čv�Z
                            this.CalcGrossPM(tradePrice, cost, out grossPM, out grossMarginPM);
                            // �v�Z���ʂ�W�J
                            this.Goods_Grid.Rows[index].Cells[COL_GROSS_PM].Value = grossPM;
                            this.Goods_Grid.Rows[index].Cells[COL_GROSSMARGIN_PM].Value = grossMarginPM;
                        }
                        else if (this.Goods_Grid.ActiveCell.Column.Key == COL_MAKERCD) // ���[�J�[CD
                        {
                            int mkCd = GetCellInt32(this.Goods_Grid.ActiveCell.Value, 0);

                            if (this._makerCdDic.ContainsKey(mkCd))
                            {
                                this.Goods_Grid.ActiveCell.Row.Cells[COL_MAKERNM].Value = this._makerCdDic[mkCd].MakerName;
                            }
                            else
                            {
                                if (GetCellInt32(this.Goods_Grid.ActiveCell.Value, 0) == 0)
                                {
                                    this.Goods_Grid.ActiveCell.Row.Cells[COL_MAKERNM].Value = "";
                                }
                                else if (this._tempValue != null)
                                {
                                    // ���ɖ߂�
                                    this.Goods_Grid.ActiveCell.Value = this._tempValue;
                                }
                            }
                        }
                        else if (this.Goods_Grid.ActiveCell.Column.Key == COL_MAKERNM) // ���[�J�[����
                        {
                            if (GetCellInt32(this.Goods_Grid.ActiveCell.Row.Cells[COL_MAKERCD].Value, 0) != 0)
                            {
                                // ���ɖ߂�
                                this.Goods_Grid.ActiveCell.Value = this._tempValue;
                            }
                        }
                        else if (this.Goods_Grid.ActiveCell.Column.Key == COL_SHOPSALEBEGINDATE) // ���J�J�n��
                        {
                            if (this.Goods_Grid.ActiveCell.Row.Cells[COL_SHOPSALEBEGINDATE].Value == DBNull.Value)
                            {
                                // ���ɖ߂�
                                this.Goods_Grid.ActiveCell.Value = this._tempValue;
                            }
                        }
                    }
                }
            }
            catch
            {
                if (this.Goods_Grid.ActiveCell != null)
                {
                    //�Z���X�V�G���[������
                    CellDataErrorProc();
                }
            }
            finally
            {
                this.Goods_Grid.EndUpdate();
                //�f�[�^�e�[�u���ւ̕ύX���R�~�b�g
                this.TBODataSet.Tables[TABLE_MAIN].AcceptChanges();
            }
        }
        #endregion

        #endregion

        #region ComboEditor
        /// <summary>
        /// ���_�R���{ValueChange�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Section_ComboEditor_ValueChanged(object sender, EventArgs e)
        {
            //if (this._bootPara.BootMode == BootMode.PM)
            //{
            //    string sectionCode = ((Infragistics.Win.UltraWinEditors.UltraComboEditor)sender).Value.ToString();

            //    // ���i�����[�h�̏ꍇ�A���_�ύX���Ɍ��J����ύX����B�@���_���C�y�ɕύX�����ƍ���̂ŁA�����܂Œ��o���Ă�����A�؂�ւ��ق�����������

            //    // TODO ��U�`�F�b�N�O��
            //    //if (this._scmSceDic.Count == 0)
            //    //{
            //    //    MessageBox.Show("�L���Ȍ��J�悪����܂���B");
            //    //}
            //    //else
            //    //{
            //    //    if (this._scmSceDic.ContainsKey(sectionCode))
            //    //    {
            //    //        this.MakeCustomerTree(this._scmSceDic[sectionCode]);
            //    //    }
            //    //    else
            //    //    {
            //    //        MessageBox.Show("�L���Ȍ��J�悪����܂���B");
            //    //    }
            //    //}
            //}
        }
        #endregion

        #region Button
        /// <summary>
        /// �I���{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_toolStripButton_Click(object sender, EventArgs e)
        {
            // �I��
            this.Close();
        }

        /// <summary>
        /// �s�폜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Del_button_Click(object sender, EventArgs e)
        {
            // �Ƃ肠�����͘_���폜�Ƃ��āA�X�V���ɑS������

            if (this.Goods_Grid.Selected.Rows.Count > 0)
            {
                DialogResult ret
                    = TMsgDisp.Show(
                       this,								// �e�E�B���h�E�t�H�[��
                       emErrorLevel.ERR_LEVEL_QUESTION,	    // �G���[���x��
                       CT_ASSEMBLYID,						// �A�Z���u��ID�܂��̓N���XID
                       "�I���s���폜���܂����H",			// �\�����郁�b�Z�[�W 
                       0,								    // �X�e�[�^�X�l
                       MessageBoxButtons.YesNo);

                if (ret == DialogResult.Yes)
                {
                    foreach (UltraGridRow row in this.Goods_Grid.Selected.Rows)
                    {
                        // �ۑ��ύs
                        row.Cells[COL_DEL].Value = 1;
                    }
                }

                DataView dtView = this.TBODataSet.Tables[TABLE_MAIN].DefaultView;

                // �t�B���^�[�|���Ă݂�
                StringBuilder filter = new StringBuilder();
                filter.Append(String.Format("{0}={1}", COL_DEL, 0));
                this.TBODataSet.Tables[TABLE_MAIN].DefaultView.RowFilter = filter.ToString();

                this.TBODataSet.Tables[TABLE_MAIN].AcceptChanges();
                this.UpDateGrid();
            }
        }

        /// <summary>
        /// �s�ǉ��{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRow_button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Goods_Grid.BeginUpdate();

                // �s�t�B���^�͋�������
                this.Goods_Grid.DisplayLayout.Bands[0].ColumnFilters[COL_MAKERNM].FilterConditions.Clear();
                this.Goods_Grid.DisplayLayout.Bands[0].ColumnFilters[COL_OIL_KEY1].FilterConditions.Clear();
                this.Goods_Grid.DisplayLayout.Bands[0].ColumnFilters[COL_TIRE_KEY1].FilterConditions.Clear();
                this.Goods_Grid.DisplayLayout.Bands[0].ColumnFilters[COL_BATTERY_KEY1].FilterConditions.Clear();
                this.Goods_Grid.DisplayLayout.Bands[0].ColumnFilters[COL_SHOPSALEBEGINDATE].FilterConditions.Clear();
                this.Goods_Grid.DisplayLayout.Bands[0].ColumnFilters[COL_SHOPSALEENDDATE].FilterConditions.Clear();

                DataRow row = this.TBODataSet.Tables[TABLE_MAIN].NewRow();

                row[COL_DEL] = 0;               // �_���폜�敪
                row[COL_RELEASE] = true;        // ���J�t���O
                row[COL_RECOMMEND] = false;     // �I�X�X���t���O
                row[COL_TIRE_KEY2] = false;
                row[COL_BATTERY_KEY2] = 1;
                row[COL_OIL_KEY2] = 1;
                row[COL_STOCKSTATE] = -1;

                // �s�̑e�����v�Z
                this.CalcGrossProc(ref row);

                this.TBODataSet.Tables[TABLE_MAIN].Rows.Add(row);

                UltraGridRow ugRow = this.Goods_Grid.GetRow(ChildRow.Last);
                if (ugRow != null)
                {
                    UltraGridCell cell = ugRow.Cells[COL_RELEASE];
                    this.Goods_Grid.Focus();
                    cell.Row.Cells[COL_RELEASE].Activate();
                    cell.Selected = true;
                    cell.Activate();
                }

            }
            finally
            {
                this.Goods_Grid.EndUpdate();
                this.UpDateGrid();
            }
        }

        /// <summary>
        /// �s�̑e�����v�Z
        /// </summary>
        /// <param name="row"></param>
        private void CalcGrossProc(ref DataRow row)
        {
            // �e���v�Z
            long shopPrice = GetCellLong(row[COL_SHOP_PRICE], 0);                  // �X�����i
            long repareTotal = 0;                                                   // �t���������v���z
            foreach (DataColumn col in this.TBODataSet.Tables[TABLE_MAIN].Columns)
            {
                if (col.ColumnName.Contains(COL_REPARE))
                {
                    repareTotal += (long)row[col.ColumnName];
                }
            }

            long tradePrice = GetCellLong(row[COL_TRADE_PRICE], 0);     // ���l
            long cost = GetCellLong(row[COL_PURCHASE_COST], 0);         // �d������
            long grossSF = 0;
            string grossMarginSF = "";
            long grossPM = 0;
            string grossMarginPM = "";

            // �����̑e�����Čv�Z

            // �����H��̑e�����Čv�Z
            this.CalcGrossSF(shopPrice, repareTotal, tradePrice, out grossSF, out grossMarginSF);
            // �v�Z���ʂ�W�J
            row[COL_GROSS_SF] = grossSF;
            row[COL_GROSSMARGIN_SF] = grossMarginSF;

            // ���i���̑e�����Čv�Z
            this.CalcGrossPM(tradePrice, cost, out grossPM, out grossMarginPM);
            // �v�Z���ʂ�W�J
            row[COL_GROSS_PM] = grossPM;
            row[COL_GROSSMARGIN_PM] = grossMarginPM;

            // ���v���z���v�Z
            row[COL_MONEY_TOTAL] = shopPrice + repareTotal;
        }

      
        /// <summary>
        /// �ȈՃI�X�X��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Recommend_button_Click(object sender, EventArgs e)
        {
            RecommendForm form = new RecommendForm();
            form.Icon = this.Icon;

            DialogResult ret = form.ShowRecomendForm(this._bootPara.BootMode, (long)this.Category_ComboEditor.Value, this.Category_ComboEditor.Text);
            if (ret == DialogResult.OK)
            {
                // �I�X�X���ݒ�
                this.SetRecommend(form._count, form._target);
            }
        }

        #endregion

        #region RetKeyControl
        /// <summary>
        /// RetKey_ChangeFocus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if ((e.PrevCtrl == null) || (e.NextCtrl == null))
                return;

            //�L�[����         
            switch (e.PrevCtrl.Name)
            {
                case "Goods_Grid":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = null;

                                    //�V�t�g�L�[��������Ă��邩�H
                                    if (e.ShiftKey)
                                    {
                                        // �ŏ��̃Z��
                                        if (this.Goods_Grid.ActiveCell != null && this.Goods_Grid.ActiveCell.Column.Key == COL_RELEASE)
                                        {
                                            if (this.Goods_Grid.ActiveCell.Row.HasPrevSibling())
                                            {
                                                UltraGridRow prevRow = this.Goods_Grid.ActiveCell.Row.GetSibling(SiblingRow.Previous);
                                                UltraGridCell prevCel = null;
                                                if (this._bootPara.BootMode == BootMode.PM)
                                                {
                                                    prevCel = prevRow.Cells[COL_GROSSMARGIN_PM];
                                                }
                                                else
                                                {
                                                    prevCel = prevRow.Cells[COL_GROSSMARGIN_SF];
                                                }
                                                if (prevCel != null)
                                                {
                                                    prevCel.Activate();
                                                    prevCel.Selected = true;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            this.Goods_Grid.PerformAction(UltraGridAction.PrevCellByTab);
                                        }
                                    }
                                    else
                                    {
                                        // �ŏI�Z��
                                        if (this.Goods_Grid.ActiveCell != null && this.Goods_Grid.ActiveCell.Column.Key == COL_GROSSMARGIN_PM)
                                        {
                                            if (this.Goods_Grid.ActiveCell.Row.HasNextSibling())
                                            {
                                                UltraGridRow nextRow = this.Goods_Grid.ActiveCell.Row.GetSibling(SiblingRow.Next);
                                                UltraGridCell nextCel = nextRow.Cells[COL_RELEASE];
                                                if (nextCel != null)
                                                {
                                                    nextCel.Activate();
                                                    this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                            }
                                        }
                                        else if (this.Goods_Grid.ActiveCell != null && this.Goods_Grid.ActiveCell.Column.Key == COL_GROSSMARGIN_SF)
                                        {
                                            if (this._bootPara.BootMode == BootMode.SF)
                                            {
                                                if (this.Goods_Grid.ActiveCell.Row.HasNextSibling())
                                                {
                                                    UltraGridRow nextRow = this.Goods_Grid.ActiveCell.Row.GetSibling(SiblingRow.Next);
                                                    UltraGridCell nextCel = nextRow.Cells[COL_RELEASE];
                                                    if (nextCel != null)
                                                    {
                                                        nextCel.Activate();
                                                        this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                this.Goods_Grid.PerformAction(UltraGridAction.NextCellByTab);
                                            }
                                        }
                                        else
                                        {
                                            this.Goods_Grid.PerformAction(UltraGridAction.NextCellByTab);
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

        #region ToolStrip

        #region ���o
        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_button_Click(object sender, EventArgs e)
        {
            //�s���s���\��
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "���o��";
            form.Message = "���݁A���i�f�[�^�𒊏o���ł��B";

            try
            {
                this.Cursor = Cursors.WaitCursor;
                // �_�C�A���O�\��
                form.Show();

                int st = 0;
                string errMsg = "";
                List<ProposeGoods> retList = new List<ProposeGoods>();
                st = this.SearchGoodsProc(out retList, out errMsg);

                if (st == 0)
                {
                    // �f�[�^�𔽉f
                    this.SetDataTable(retList);
                    this.Section_ComboEditor.Enabled = false;
                    this.Search_button.Enabled = false;
                    this.Category_ComboEditor.Enabled = false;
                }
                else
                {
                    TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            CT_ASSEMBLYID,						// �A�Z���u��ID�܂��̓N���XID
                            errMsg,			                    // �\�����郁�b�Z�[�W 
                            st,								    // �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                }
            }
            finally
            {
                form.Close();
                this.Cursor = Cursors.Default;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        /// <summary>
        /// ���i��������
        /// </summary>
        private int SearchGoodsProc(out  List<ProposeGoods> retList, out string errMsg)
        {
            errMsg = "";
            int st = 0;
            retList = new List<ProposeGoods>();
            errMsg = "";

            // �����H�ꃂ�[�h�̏ꍇ�͋��_�ʂȂ̂ŁA���i���擾���ɕt�����������擾����
            if (this._bootPara.BootMode == BootMode.SF)
            {
                st = this.SetAttendRepairSet_ModeSF(out errMsg);
                if (st != 0)
                {
                    return st;
                }
            }

            st = this._TBOServiceACS.GetProposegoods(this._bootPara.EnterpriseCode, this.Section_ComboEditor.Value.ToString(), (long)this.Category_ComboEditor.Value, out retList, out errMsg);
            return st;
        }
        #endregion

        #region �N���A
        /// <summary>
        /// �N���A����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_toolStripButton_Click(object sender, EventArgs e)
        {
            // �X�V�`�F�b�N
            if (this.CheckUpDate())
            {
                if (this.Goods_Grid.DataSource != null)
                {
                    this.Goods_Grid.BeginUpdate();
                    this.Goods_Grid.DataSource = null;
                    this.TBODataSet.Tables[TABLE_MAIN].Rows.Clear();
                    this.Goods_Grid.EndUpdate();
                    this.UpDateGrid();
                    this.Section_ComboEditor.Enabled = true;
                    this.Del_button.Enabled = false;
                    this.Category_ComboEditor.Enabled = true;
                    this.Search_button.Enabled = true;
                    this.SetSpButtonEnabled(false);
                    this._copyBufferList.Clear();
                    this.Goods_Grid.EndUpdate();
                }
            }
        }
        #endregion

        #region �ۑ�
        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            this.SaveProc();
            this.UpDateGrid();
        }
        #endregion


        #endregion

        #endregion
       
        #region internal Class

        /// <summary>
        /// �u�[�g���[�h�N���X
        /// </summary>
        internal class BootMode
        {
            public const int PM = 1;    //���i�����[�h
            public const int SF = 2;    //�����H�ꃂ�[�h
        }

        /// <summary>
        /// �O���b�h�J���� �|�W�V����
        /// </summary>
        internal class OriginX
        {
            public const int RELEASE = 0;           //���J
            public const int RECOMMEND = 1;         //�I�X�X��
            public const int GOODSNO = 2;           //�i��
            public const int MAKERTITLE = 10;       //���[�J�[�^�C�g��
            public const int MAKERCD = 10;          //���[�J�[�R�[�h
            public const int MAKERGD = 11;          //���[�J�[�K�C�h
            public const int MAKERNM = 12;          //���[�J�[����
            public const int TIRE_KEY1 = 26;        //�^�C�������L�[�P
            public const int TIRE_KEY2 = 27;        //�^�C�������L�[�Q
            public const int BATTERY_KEY1 = 26;     //�o�b�e�������L�[�P
            public const int BATTERY_KEY2 = 27;     //�o�b�e�������L�[�Q
            public const int OIL_KEY1 = 26;         //�I�C�������L�[�P
            public const int OIL_KEY2 = 27;         //�I�C�������L�[�Q
            public const int IMAGE_NO = 40;         //�摜��
            public const int IMAGE = 41;            //�摜      
            public const int IMAGE_GD = 42;         //�摜�K�C�h      
            public const int GOODSNM = 50;         //���i����
            public const int GOODSNOTE = 51;       //���i���� 
            public const int GOODSPR = 52;         //���iPR
            public const int RELEASEDATE = 53;     //������
            public const int SHOPSALEBEGINDATE = 54;    //���J�J�n��
            public const int SHOPSALEENDDATE = 55;      //���J�I����
            public const int STOCKCOUNT = 57;      //�݌ɐ�
            public const int STOCKSTATE = 58;      //�݌ɏ��

            public const int SF_TITLE = 86;             //SF�^�C�g��
            public const int SUGGEST_PRICE = 86;        //�W�����i
            public const int SHOPP_PRICE = 87;          //�X�����i
            public const int REPAIR = 88;              // �t������
            public const int MONEY_TOTAL = 88;         // �X�����i�{�t������
            //public const int GROSS_SF_PM = 89;          //SF�e��(���i�����[�h)
            //public const int GROSSMARGIN_SF_PM = 90;    //�e����SF(���i�����[�h)

            public const int GROSS_SF_PM = 88;          //SF�e��(���i�����[�h)
            public const int GROSSMARGIN_SF_PM = 89;    //�e����SF(���i�����[�h)
            
            public const int PM_TITLE = 100;             //PM�^�C�g��
            public const int TRADE_PRICE_PM = 100;       //(���i��:�̔����i)
            public const int PURCHASE_COST = 101;        //�d������
            public const int GROSS_PM = 102;             //�e��PM
            public const int GROSSMARGIN_PM = 103;       //�e����PM
            public const int INDIVIDUAL = 104;         //�ʐݒ�PM


            public const int TRADE_PRICE_SF = 89;      //(�����H��F�d������)
            public const int GROSS_SF = 90;            //SF�e��(�����H�ꃂ�[�h)
            public const int GROSSMARGIN_SF = 91;      //�e����SF(�����H�ꃂ�[�h)
        }

        #endregion

        /// <summary>
        /// �摜�ݒ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // �X�V�`�F�b�N
            if (this.CheckUpDate())
            {
                GoodsImageForm form = new GoodsImageForm();
                form._enterPriseCode = this._bootPara.EnterpriseCode;
                form._goodsCategoryId = (long)this.Category_ComboEditor.Value;
                form._goodsCategoryList = this._categoryList;
                form._mode = 0;
                form.Icon = this.Icon;
                form.ShowGoodsImageFrom();

                if (form._saveDiv)
                {
                    // �ēǍ�
                    if (this.Category_ComboEditor.Enabled == false)
                    {
                        this.Search_button_Click(this, new EventArgs());
                    }

                    if (this._imageGuide != null)
                    {
                        this._imageGuide._dataReadFlag = true;
                    }
                }
            }
        }

        /// <summary>
        /// ���i�摜�ݒ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsImageSet_Button_Click(object sender, EventArgs e)
        {
            // �X�V�`�F�b�N
            if (this.CheckUpDate())
            {
                GoodsImageForm form = new GoodsImageForm();
                form._enterPriseCode = this._bootPara.EnterpriseCode;
                form._goodsCategoryId = (long)this.Category_ComboEditor.Value;
                form._goodsCategoryList = this._categoryList;
                form._mode = 0;
                form.Icon = this.Icon;
                form.ShowGoodsImageFrom();

                if (form._saveDiv)
                {
                    // �ēǍ�
                    if (this.Category_ComboEditor.Enabled == false)
                    {
                        this.Search_button_Click(this, new EventArgs());
                    }

                    if (this._imageGuide != null)
                    {
                        this._imageGuide._dataReadFlag = true;
                    }
                }
            }
        }


        /// <summary>
        /// ����ݒ�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OthreSetting_Button_Click(object sender, EventArgs e)
        {
            OthreSettingForm form = new OthreSettingForm();
            form.Icon = this.Icon;
            form._enterpirseCode = this._bootPara.EnterpriseCode;
            form._sectionCode = this.Section_ComboEditor.Value.ToString();
            form._sectionList = this._bootPara.Propose_Para_Section;
            form._settingsDic = this._settingsDic;
            form.ShowOtherSettinfForm();

            // �f�[�^���X�V����Ă���
            if (form._saveFlag)
            {
                // ����ݒ�Ď擾
                this.GetSettings();

                // �O���b�h�ؑ�
                if (this.Goods_Grid.DataSource != null)
                {
                    this.DispChangeStockState(this.Goods_Grid.DisplayLayout.Bands[0].Columns[COL_STOCKSTATE]);
                }
            }

        }

        /// <summary>
        /// �O���b�h�{�^���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            // �摜�K�C�h
            if (e.Cell.Column.Key == COL_IMAGE_GUIDE)
            {
                this.ShowImageGuide(e.Cell.Row.Index);
            }
            // ���[�J�[�K�C�h
            else if (e.Cell.Column.Key == COL_MAKERGD)
            {
                this.ShowMakerGuide(e.Cell.Row.Index);
            }
        }

        /// <summary>
        /// ���[�J�[�K�C�h�N��
        /// </summary>
        /// <param name="p"></param>
        private void ShowMakerGuide(int index)
        {
            MakerGuide guide = new MakerGuide();
            guide.Icon = this.Icon;
            guide._makerList = this._bootPara.Propose_Para_Maker;
            DialogResult ret = guide.ShowMakerGuide();
            if (ret == DialogResult.OK)
            {
                this.Goods_Grid.Rows[index].Cells[COL_MAKERCD].Value = guide._makerCode;
                this.Goods_Grid.Rows[index].Cells[COL_MAKERNM].Value = guide._makerName;
            }
        }

        /// <summary>
        /// �摜�K�C�h�N��
        /// </summary>
        private void ShowImageGuide(int index)
        {
            if(this._imageGuide == null) 
            {
                this._imageGuide = new GoodsImageForm();
                this._imageGuide._dataReadFlag = true;
                this._imageGuide._mode = 1;
                this._imageGuide.Icon = this.Icon;

            }
            this._imageGuide._enterPriseCode = this._bootPara.EnterpriseCode;
            this._imageGuide._goodsCategoryId = (long)this.Category_ComboEditor.Value;
            this._imageGuide._goodsCategoryList = this._categoryList;
            this._imageGuide._imageID = 0;
            this._imageGuide._goodsImage = null;

            DialogResult ret = this._imageGuide.ShowGoodsImageFrom();
            if (ret == DialogResult.OK)
            {
                this.Goods_Grid.Rows[index].Cells[COL_IMAGE_NO].Value = this._imageGuide._imageID;
                this.Goods_Grid.Rows[index].Cells[COL_IMAGE].Value = this._imageGuide._goodsImage;
                this.Goods_Grid.Rows[index].Cells[COL_IMAGE_CHANGE].Value = 1;
            }
        }

        /// <summary>
        /// �s�폜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ROW_DEL_Click(object sender, EventArgs e)
        {
            this.Del_button_Click(this, new EventArgs());
        }

        /// <summary>
        /// �s�R�s�[
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ROW_COPY_Click(object sender, EventArgs e)
        {
            if (this.Goods_Grid.Selected.Rows.Count == 0) return; 

            try
            {
                this.Goods_Grid.BeginUpdate();
                this._copyBufferList.Clear();
                // �_���폜�s������̂ň�U�t�B���^�[���N���A
                this.TBODataSet.Tables[TABLE_MAIN].DefaultView.RowFilter = "";

                foreach (UltraGridRow row in this.Goods_Grid.Selected.Rows)
                {
                    this._copyBufferList.Add(this.TBODataSet.Tables[TABLE_MAIN].Rows[row.Index].ItemArray.Clone());
                }
            }
            finally
            {
                StringBuilder filter = new StringBuilder();
                filter.Append(String.Format("{0}={1}", COL_DEL, 0));
                this.TBODataSet.Tables[TABLE_MAIN].DefaultView.RowFilter = filter.ToString();
                this.TBODataSet.Tables[TABLE_MAIN].AcceptChanges();
                this.Goods_Grid.EndUpdate();
                this.UpDateGrid();
            }
        }

        /// <summary>
        /// �s�\��t��(�}���\��t���Ƃ���)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ROW_PAST_Click(object sender, EventArgs e)
        {
            if (this._copyBufferList.Count == 0) return;

            try
            {
                this.Goods_Grid.BeginUpdate();

                // �_���폜�s������̂ň�U�t�B���^�[���N���A
                this.TBODataSet.Tables[TABLE_MAIN].DefaultView.RowFilter = "";

                int index = -1;
                if (this.Goods_Grid.Selected.Rows != null)
                {
                    foreach (UltraGridRow row in this.Goods_Grid.Selected.Rows)
                    {
                        if (row.Activated)
                        {
                            index = row.Index;
                            break;
                        }
                    }
                }

                if (index != -1)
                {
                    for (int i = 0; i < this._copyBufferList.Count; i++)
                    {
                        DataRow newRow = this.TBODataSet.Tables[TABLE_MAIN].NewRow();
                        newRow.ItemArray = (object[])this._copyBufferList[i];
                        // �R�s�[������_���Ȃ��̂�������
                        newRow[COL_IMAGE_CHANGE] = 0;
                        newRow[COL_PM_UPDATETIME] = 0;
                        newRow[COL_POSTPARACLASS] = DBNull.Value;
                        newRow[COL_SORTNO] = 0;
                        newRow[COL_STOCKCOUNT] = 0;
                        this.TBODataSet.Tables[TABLE_MAIN].Rows.InsertAt(newRow, index);
                        index++;
                    }
                }
            }
            finally
            {
                StringBuilder filter = new StringBuilder();
                filter.Append(String.Format("{0}={1}", COL_DEL, 0));
                this.TBODataSet.Tables[TABLE_MAIN].DefaultView.RowFilter = filter.ToString();
                this.TBODataSet.Tables[TABLE_MAIN].AcceptChanges();
                this.Goods_Grid.EndUpdate();
                this.UpDateGrid();
                this._copyBufferList.Clear();
            } 
        }

        /// <summary>
        /// �R���e�N�X�g���j���[�\��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.Goods_Grid.Selected.Rows.Count > 0)
            {
                this.ROW_DEL.Enabled = true;
                this.ROW_COPY.Enabled = true;
                this.IMAGE_SET.Enabled = true;
                this.IMAGE_CLEAR.Enabled = true;
            }
            else
            {
                this.ROW_DEL.Enabled = false;
                this.ROW_COPY.Enabled = false;
                this.IMAGE_SET.Enabled = false;
                this.IMAGE_CLEAR.Enabled = false;
            }

            // �\��t��
            if (this._copyBufferList.Count > 0)
            {
                this.ROW_PAST.Enabled = true;
            }
            else
            {
                this.ROW_PAST.Enabled = false;
            }
        }

        /// <summary>
        /// �摜�w��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IMAGE_SET_Click(object sender, EventArgs e)
        {
            // �摜�K�C�h�N��
            if (this._imageGuide == null)
            {
                this._imageGuide = new GoodsImageForm();
                this._imageGuide._dataReadFlag = true;
                this._imageGuide._mode = 1;
                this._imageGuide.Icon = this.Icon;
            }
            this._imageGuide._enterPriseCode = this._bootPara.EnterpriseCode;
            this._imageGuide._goodsCategoryId = (long)this.Category_ComboEditor.Value;
            this._imageGuide._goodsCategoryList = this._categoryList;
            this._imageGuide._imageID = 0;
            this._imageGuide._goodsImage = null;

            DialogResult ret = this._imageGuide.ShowGoodsImageFrom();
            if (ret == DialogResult.OK)
            {
                for (int i = 0; i < this.Goods_Grid.Selected.Rows.Count; i++)
                {
                    this.Goods_Grid.Selected.Rows[i].Cells[COL_IMAGE_NO].Value = this._imageGuide._imageID;
                    this.Goods_Grid.Selected.Rows[i].Cells[COL_IMAGE].Value = this._imageGuide._goodsImage;
                    this.Goods_Grid.Selected.Rows[i].Cells[COL_IMAGE_CHANGE].Value = 1;
                }
            }
        }

        /// <summary>
        /// �摜�N���A
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IMAGE_CLEAR_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Goods_Grid.Selected.Rows.Count; i++)
            {
                if (GetCellLong(this.Goods_Grid.Selected.Rows[i].Cells[COL_IMAGE_NO].Value, 0) != 0)
                {
                    this.Goods_Grid.Selected.Rows[i].Cells[COL_IMAGE_NO].Value = 0;
                    this.Goods_Grid.Selected.Rows[i].Cells[COL_IMAGE].Value = DBNull.Value;
                    this.Goods_Grid.Selected.Rows[i].Cells[COL_IMAGE_CHANGE].Value = 1;
                }
            }
        }

        /// <summary>
        /// �O���b�h�}�E�X�N���b�N(�E�N���b�N�p)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_MouseClick(object sender, MouseEventArgs e)
        {
            // �E�N���b�N�ȊO�͔�����
            if (e.Button != MouseButtons.Right)
                return;

            try 
            {
                UltraGrid targetGrid = sender as UltraGrid;

                if (targetGrid.Selected.Rows.Count == 0) return;

                // �}�E�X���������Ō�̗v�f���擾
                Infragistics.Win.UIElement lastUIElement = targetGrid.DisplayLayout.UIElement.LastElementEntered;
                // �`�F�[������RowUIElement�����邩�ǂ����𒲂ׂ܂�
                RowUIElement rowElement;

                if (lastUIElement == null)
                    return;

                if (lastUIElement is RowUIElement)
                {
                    rowElement = (RowUIElement)lastUIElement;
                }
                else
                {
                    rowElement = (RowUIElement)lastUIElement.GetAncestor(typeof(RowUIElement));
                }

                // �v�f����s���擾���܂�
                UltraGridRow row = (UltraGridRow)rowElement.GetContext(typeof(UltraGridRow));
                if (row == null)
                    return;

                // �}�E�X�͍s�̏�ɂ���܂�

                // ���݂̃}�E�X�|�C���^�̈ʒu���擾���ăO���b�h���W�ɕϊ����܂�
                Point mousePosition = targetGrid.PointToClient(Control.MousePosition);

                // ���W�_��AdjustableElement��ɂ��邩�ǂ����𒲂ׂ܂��B���Ȃ킿�A
                // ���[�U�[���s�Z���N�^��̍s���N���b�N���Ă��邩�ǂ����B
                if (lastUIElement.AdjustableElementFromPoint(mousePosition) != null)
                    return;

                // �E�N���b�N���j���[�\��
                if (this.Goods_Grid.Selected.Rows.Count > 0)
                {
                    this.InsertUpRow_ToolStripMenuItem.Text = this.Goods_Grid.Selected.Rows.Count.ToString() + "�s��}��";
                    //this.InsertDownRow_ToolStripMenuItem.Text = this.Goods_Grid.Selected.Rows.Count.ToString() + "�s�����ɑ}��";
                }
               
                this.contextMenuStrip1.Show(this.Goods_Grid, e.X, e.Y);
            }
            catch (Exception)
            {
                // �\�����ʃG���[�p
            }
        }



        /// <summary>
        /// �Z�b�g�}�X�^�捞
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_SetImp_Click(object sender, EventArgs e)
        {
            // �ۑ��m�F
            if (CheckUpDate() == false) return;

            // �ҏW���[�h�I��
            this.Goods_Grid.PerformAction(UltraGridAction.ExitEditMode);

            int st = 0;
            string errMsg = "";
            List<Propose_Goods> retList = new List<Propose_Goods>();

            try
            {
                // �A�Z���u�����[�h
                Assembly assm = Assembly.LoadFrom(CT_PM_AssemblyID);
                // �^�C�v�擾
                Type type = assm.GetType(CT_PM_ClassID);

                if (assm != null && type != null)
                {
                    // �C���X�^���X����
                    object instance = Activator.CreateInstance(type);
                    // �N��
                    MethodInfo method = type.GetMethod("ShowDialog", new Type[] { typeof(string), typeof(string), typeof(string), typeof(Int32) });
                    long categoryIDlong = (long)this.Category_ComboEditor.Value;
                    int categoryID = Convert.ToInt32(categoryIDlong .ToString());
                    //object ob = method.Invoke(instance, new object[] { this._bootPara.EnterpriseCode, this._bootPara.SectionCode, this._bootPara.EmployeeName, categoryID });
                    // ���O�C�����_�ł͂Ȃ��A���ݑI�𒆂̋��_��n��
                    object ob = method.Invoke(instance, new object[] { this._bootPara.EnterpriseCode, this.Section_ComboEditor.Value.ToString(), this._bootPara.EmployeeName, categoryID });

                    // ���ʂ��擾
                    PropertyInfo property = type.GetProperty("TBODataList");
                    retList = (List<Propose_Goods>)property.GetValue(instance, null);

                    #region �T���v��
#if DEBUG
                    retList = new List<Propose_Goods>();

                    if ((long)this.Category_ComboEditor.Value == 1)
                    {
                        Propose_Goods sample1 = new Propose_Goods();
                        sample1.BLGoodsCode = 7110;
                        sample1.GoodsCategory = 1;
                        sample1.GoodsMakerCd = 1464;
                        sample1.GoodsName = "�u���W�X�g�� 215/45R17 ZE914";
                        sample1.GoodsNo = "PMUPDATE";
                        sample1.MakerName = "�t�@���P��";
                        //sample1.PMUpdateTime = DateTime.Now.Ticks;
                        sample1.PurchaseCost = 8300;
                        sample1.SearchTag1 = "215/45R17";
                        sample1.SearchTag2 = "0";
                        sample1.SectionCode = "01";
                        sample1.StockStatusDiv = 0;
                        sample1.SuggestPrice = 0;
                        sample1.PMUpdateTime = DateTime.Now.Ticks;

                        //Propose_Goods sample2 = new Propose_Goods();
                        //sample2.BLGoodsCode = 7110;
                        //sample2.GoodsCategory = 1;
                        //sample2.GoodsMakerCd = 2485;
                        //sample2.GoodsName = "İְ��� 215/45R17 PROXES R1R";
                        //sample2.GoodsNo = "14850554";
                        //sample2.MakerName = "���m�S���H��";
                        //sample2.PMUpdateTime = DateTime.Now.Ticks;
                        //sample2.PurchaseCost = 0;
                        //sample2.SearchTag1 = "215/45R17";
                        //sample2.SearchTag2 = "0";
                        //sample2.SectionCode = "01";
                        //sample2.StockStatusDiv = 2;
                        //sample2.SuggestPrice = 27900;

                        //Propose_Goods sample2_s = new Propose_Goods();
                        //sample2_s.BLGoodsCode = 7110;
                        //sample2_s.GoodsCategory = 1;
                        //sample2_s.GoodsMakerCd = 2485;
                        //sample2_s.GoodsName = "İְ�����ڽ 215/45R17 GARIT G5";
                        //sample2_s.GoodsNo = "14860613";
                        //sample2_s.MakerName = "���m�S���H��";
                        //sample2_s.PMUpdateTime = DateTime.Now.Ticks;
                        //sample2_s.PurchaseCost = 16800;
                        //sample2_s.SearchTag1 = "215/45R17";
                        //sample2_s.SearchTag2 = "1";
                        //sample2_s.SectionCode = "01";
                        //sample2_s.StockStatusDiv = 3;
                        //sample2_s.SuggestPrice = 33500;


                        //Propose_Goods sample3 = new Propose_Goods();
                        //sample3.BLGoodsCode = 7110;
                        //sample3.GoodsCategory = 1;
                        //sample3.GoodsMakerCd = 1464;
                        //sample3.GoodsName = "̧ٹ� 215/45R18 ZE914";
                        //sample3.GoodsNo = "315265";
                        //sample3.MakerName = "�t�@���P��";
                        //sample3.PMUpdateTime = DateTime.Now.Ticks;
                        //sample3.PurchaseCost = 11900;
                        //sample3.SearchTag1 = "215/45R18";
                        //sample3.SearchTag2 = "0";
                        //sample3.SectionCode = "01";
                        //sample3.StockStatusDiv = 0;
                        //sample3.SuggestPrice = 23800;

                        //Propose_Goods sample4 = new Propose_Goods();
                        //sample4.BLGoodsCode = 7110;
                        //sample4.GoodsCategory = 1;
                        //sample4.GoodsMakerCd = 2485;
                        //sample4.GoodsName = "İְ��� 215/45R18 PROXES T1S";
                        //sample4.GoodsNo = "12270186";
                        //sample4.MakerName = "���m�S���H��";
                        //sample4.PMUpdateTime = DateTime.Now.Ticks;
                        //sample4.PurchaseCost = 0;
                        //sample4.SearchTag1 = "215/45R18";
                        //sample4.SearchTag2 = "0";
                        //sample4.SectionCode = "01";
                        //sample4.StockStatusDiv = 2;
                        //sample4.SuggestPrice = 28300;


                        //Propose_Goods sample5 = new Propose_Goods();
                        //sample5.BLGoodsCode = 7110;
                        //sample5.GoodsCategory = 1;
                        //sample5.GoodsMakerCd = 1464;
                        //sample5.GoodsName = "̧ٹ� 215/50R17 ZE914";
                        //sample5.GoodsNo = "315293";
                        //sample5.MakerName = "�t�@���P��";
                        //sample5.PMUpdateTime = DateTime.Now.Ticks;
                        //sample5.PurchaseCost = 11900;
                        //sample5.SearchTag1 = "215/50R17";
                        //sample5.SearchTag2 = "0";
                        //sample5.SectionCode = "01";
                        //sample5.StockStatusDiv = 3;
                        //sample5.SuggestPrice = 20400;

                        //Propose_Goods sample6 = new Propose_Goods();
                        //sample6.BLGoodsCode = 7110;
                        //sample6.GoodsCategory = 1;
                        //sample6.GoodsMakerCd = 2485;
                        //sample6.GoodsName = "İְ��� 215/50R17 PXCF2";
                        //sample6.GoodsNo = "13350175";
                        //sample6.MakerName = "���m�S���H��";
                        //sample6.PMUpdateTime = DateTime.Now.Ticks;
                        //sample6.PurchaseCost = 13500;
                        //sample6.SearchTag1 = "215/50R17";
                        //sample6.SearchTag2 = "0";
                        //sample6.SectionCode = "01";
                        //sample6.StockStatusDiv =�@0;
                        //sample6.SuggestPrice = 23500;

                        retList.Add(sample1);
                        //retList.Add(sample2);
                        //retList.Add(sample2_s);
                        //retList.Add(sample3);
                        //retList.Add(sample4);
                        //retList.Add(sample5);
                        //retList.Add(sample6);
                    }

                    else if ((long)this.Category_ComboEditor.Value == 2)
                    {
                        // �o�b�e��

                        Propose_Goods sample4 = new Propose_Goods();
                        sample4.BLGoodsCode = 7350;
                        sample4.GoodsCategory = 2;
                        sample4.GoodsMakerCd = 1758;
                        sample4.GoodsName = "�ޯ�ذ 75D23L/SP";
                        sample4.GoodsNo = "N-75D23L/SP";
                        sample4.MakerName = "�p�i�\�j�b�N�@�X�g���[�W�o�b�e";
                        sample4.PMUpdateTime = DateTime.Now.Ticks;
                        sample4.PurchaseCost = 14800;
                        sample4.SearchTag1 = "75D23L/SP";
                        sample4.SearchTag2 = "1";
                        sample4.SearchTag3 = "0";
                        sample4.SectionCode = "01";
                        sample4.StockStatusDiv = 1;
                        sample4.SuggestPrice = 20900;

                        Propose_Goods sample5 = new Propose_Goods();
                        sample5.BLGoodsCode = 7350;
                        sample5.GoodsCategory = 2;
                        sample5.GoodsMakerCd = 2480;
                        sample5.GoodsName = "�ޯ�ذ 75D23L/SP";
                        sample5.GoodsNo = "N-75D23L/SP";
                        sample5.MakerName = "�u���a�X�g��";
                        sample5.PMUpdateTime = DateTime.Now.Ticks;
                        sample5.PurchaseCost = 14800;
                        sample5.SearchTag1 = "75D23L/SP";
                        sample5.SearchTag2 = "1";
                        sample5.SearchTag3 = "0";
                        sample5.SectionCode = "01";
                        sample5.StockStatusDiv = 1;
                        sample5.SuggestPrice = 20900;

                        Propose_Goods sample1 = new Propose_Goods();
                        sample1.BLGoodsCode = 7350;
                        sample1.GoodsCategory = 2;
                        sample1.GoodsMakerCd = 1091;
                        sample1.GoodsName = "��ٺ��ޯ�ذ2�N4���ەۏ�";
                        sample1.GoodsNo = "D-80D23R/PL";
                        sample1.MakerName = "�r�o�j�E����";
                        sample1.PMUpdateTime = DateTime.Now.Ticks;
                        sample1.PurchaseCost = 6100;
                        sample1.SearchTag1 = "80D23R";
                        sample1.SearchTag2 = "1";
                        sample1.SearchTag3 = "0";
                        sample1.SectionCode = "01";
                        sample1.StockStatusDiv = 1;
                        sample1.SuggestPrice = 10800;

                        Propose_Goods sample2 = new Propose_Goods();
                        sample2.BLGoodsCode = 7350;
                        sample2.GoodsCategory = 2;
                        sample2.GoodsMakerCd = 1091;
                        sample2.GoodsName = "��ٺ��ޯ�ذ2�N4���ەۏ�";
                        sample2.GoodsNo = "0-90D26L/PL";
                        sample2.MakerName = "�r�o�j�E����";
                        sample2.PMUpdateTime = DateTime.Now.Ticks;
                        sample2.PurchaseCost = 7000;
                        sample2.SearchTag1 = "90D26L";
                        sample2.SearchTag2 = "1";
                        sample2.SearchTag3 = "0";
                        sample2.SectionCode = "01";
                        sample2.StockStatusDiv = 1;
                        sample2.SuggestPrice = 0;

                        Propose_Goods sample3 = new Propose_Goods();
                        sample3.BLGoodsCode = 7350;
                        sample3.GoodsCategory = 2;
                        sample3.GoodsMakerCd = 1758;
                        sample3.GoodsName = "�ޯ�ذ 135D31R/C4";
                        sample3.GoodsNo = "A-135D31R/C4";
                        sample3.MakerName = "�p�i�\�j�b�N�@�X�g���[�W�o�b�e";
                        sample3.PMUpdateTime = DateTime.Now.Ticks;
                        sample3.PurchaseCost = 14700;
                        sample3.SearchTag1 = "135D31R/C4";
                        sample3.SearchTag2 = "1";
                        sample3.SearchTag3 = "0";
                        sample3.SectionCode = "01";
                        sample3.StockStatusDiv = 1;
                        sample3.SuggestPrice = 20800;

                        retList.Add(sample4);
                        retList.Add(sample1);
                        retList.Add(sample2);
                        retList.Add(sample3);
                        retList.Add(sample5);
                    }
#endif

                    #endregion




                    if (retList.Count == 0)
                    {
                        TMsgDisp.Show(
                          this,								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,	    // �G���[���x��
                          CT_ASSEMBLYID,					// �A�Z���u��ID�܂��̓N���XID
                          "�捞�f�[�^������܂���",			// �\�����郁�b�Z�[�W 
                          -1,								// �X�e�[�^�X�l
                          MessageBoxButtons.OK);			// �\������{�^��
                        return;
                    }

                     // �����f�[�^�Ǎ����s���Ă��Ȃ��ꍇ�͈�U���o�������s��
                    if (this.Section_ComboEditor.Enabled == true)
                    {
                        st = 0;
                        errMsg = "";
                        List<ProposeGoods> proposeGoodstList = new List<ProposeGoods>();
                        st = this.SearchGoodsProc(out proposeGoodstList, out errMsg);

                        if (st == 0)
                        {
                            // �f�[�^�𔽉f
                            this.SetDataTable(proposeGoodstList);
                            this.Section_ComboEditor.Enabled = false;
                            this.Search_button.Enabled = false;
                            this.Category_ComboEditor.Enabled = false;
                        }
                        else
                        {
                            TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            CT_ASSEMBLYID,						// �A�Z���u��ID�܂��̓N���XID
                            errMsg,			                    // �\�����郁�b�Z�[�W 
                            st,								    // �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                            return;
                        }
                    }

                    // ���oPG�Œ��o�����f�[�^�𔽉f
                    int newCount;
                    int updateCount;
                    Dictionary<int, List<string>> changeList = new Dictionary<int, List<string>>();

                    // ���ʂ��\�[�g ���i�^�O�P�����[�J�[�R�[�h���i��
                    retList.Sort(delegate(Propose_Goods obj1, Propose_Goods obj2)
                    {
                        if (obj1.SearchTag1.CompareTo(obj2.SearchTag1) == 0)
                        {
                            if (obj1.GoodsMakerCd.CompareTo(obj2.GoodsMakerCd) == 0)
                            {
                                return obj1.GoodsNo.CompareTo(obj2.GoodsNo);
                            }
                            else
                            {
                                return obj1.GoodsMakerCd.CompareTo(obj2.GoodsMakerCd);
                            }
                        }
                        else
                        {
                            return obj1.SearchTag1.CompareTo(obj2.SearchTag1);
                        }
                    });

                    // �捞���s
                    st = this.ReflectImportData(retList, out newCount, out updateCount, out changeList, out errMsg);
                    if (st == 0)
                    {
                        // �捞����
                        if (changeList.Count > 0)
                        {
                            foreach (int rowIndex in changeList.Keys)
                            {
                                foreach (string colNm in changeList[rowIndex])
                                {
                                    this._initFlag = true;

                                    // �ύX�Z���̕����F��ύX
                                    if (this.Goods_Grid.Rows[rowIndex].Cells[colNm].Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox)
                                    {
                                        this.Goods_Grid.Rows[rowIndex].Cells[colNm].Appearance.BackColor = Color.LightPink;
                                    }
                                    else
                                    {
                                        if (colNm == COL_STOCKSTATE && (int)this.Goods_Grid.Rows[rowIndex].Cells[colNm].Value == -1)
                                        {
                                            this.Goods_Grid.Rows[rowIndex].Cells[colNm].Appearance.BackColor = Color.LightPink;
                                        }
                                        else if (colNm == COL_SHOPSALEENDDATE && this.Goods_Grid.Rows[rowIndex].Cells[colNm].Value == DBNull.Value)
                                        {
                                            this.Goods_Grid.Rows[rowIndex].Cells[colNm].Appearance.BackColor = Color.LightPink;
                                        }
                                        else
                                        {
                                            this.Goods_Grid.Rows[rowIndex].Cells[colNm].Appearance.ForeColor = Color.Red;
                                            this.Goods_Grid.Rows[rowIndex].Cells[colNm].Appearance.ForeColor = Color.Red;
                                        }
                                    }
                                }
                            }
                        }

                        // �O���b�h�X�V
                        this.UpDateGrid();

                        TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,	    // �G���[���x��
                        CT_ASSEMBLYID,						// �A�Z���u��ID�܂��̓N���XID
                        "�捞���������܂����B"              // �\�����郁�b�Z�[�W 
                        + Environment.NewLine
                        + "�V�K:"
                        + newCount.ToString() + "��"
                        + Environment.NewLine
                        + "�X�V:"
                        + updateCount.ToString() + "��",
                        st,								    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��
                    }
                    else
                    {
                        // �捞���s
                        TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                        CT_ASSEMBLYID,						// �A�Z���u��ID�܂��̓N���XID
                        errMsg,			                    // �\�����郁�b�Z�[�W 
                        st,								    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��
                    }
                }
                else
                {
                    throw new System.ArgumentException();
                }

            }
            catch(Exception)
            {
                TMsgDisp.Show(
                this,								                // �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION,	            // �G���[���x��
                CT_ASSEMBLYID,					                    // �A�Z���u��ID�܂��̓N���XID
                "�Z�b�g�}�X�^�捞��ʂ̋N���Ɏ��s���܂����B",		// �\�����郁�b�Z�[�W 
                -1,								                // �X�e�[�^�X�l
                MessageBoxButtons.OK);			                    // �\������{�^��
                return;
            }
        }


        #region �Z�b�g�}�X�^�捞
        /// <summary>
        /// �捞�f�[�^���f
        /// </summary>
        /// <param name="saveAray"></param>
        private int ReflectImportData(List<Propose_Goods> retList, out int newCount, out int updateCount, out  Dictionary<int, List<string>> changeList, out string errMsg)
        {
            int st = 0;
            newCount = 0;
            updateCount = 0;
            errMsg = "";
            changeList = new Dictionary<int, List<string>>();

            bool showMsg = false;
            bool upDateGoodsNm = false;

            try
            {
                this.Goods_Grid.BeginUpdate();

                // �i�� + ���[�J�[���̂ɂĊ����s������

                if (retList != null)
                {
                    string mkNm = "";
                    string goodsNo = "";
                    for (int i = 0; i < retList.Count; i++)
                    {
                        mkNm = retList[i].MakerName;
                        goodsNo = retList[i].GoodsNo;
                        StringBuilder cndString = new StringBuilder();
                        // �o�^�ύs�̂�
                        cndString.Append(String.Format("{0}='{1}' AND {2}='{3}'", COL_MAKERNM, mkNm, COL_GOODSNO, goodsNo));
                        DataRow[] rows = this.TBODataSet.Tables[TABLE_MAIN].Select(cndString.ToString());

                        if (rows != null && rows.Length > 0 && rows[0][COL_POSTPARACLASS] != DBNull.Value)
                        {
                            List<string> changColList = new List<string>();

                            // �Z�b�g�}�X�^�捞�̏ꍇ�APM�X�V�����ύX����ĂȂ�������X�V���Ȃ�
                            if (((long)rows[0][COL_PM_UPDATETIME]).Equals(retList[i].PMUpdateTime))
                            {
                                continue;
                            }

                            // PM�X�V��
                            rows[0][COL_PM_UPDATETIME] = retList[i].PMUpdateTime;

                            if (showMsg == false)
                            {
                                // �㏑���m�F
                                DialogResult rslt = TMsgDisp.Show(
                                this,								        // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO,	            // �G���[���x��
                                CT_ASSEMBLYID,						        // �A�Z���u��ID�܂��̓N���XID
                                "���ɓo�^�ς݂̏��i���܂܂�Ă��܂��B" 
                                + Environment.NewLine
                                + "���i���̂̏㏑�����s���܂����H",			// �\�����郁�b�Z�[�W 
                                st,								            // �X�e�[�^�X�l
                                MessageBoxButtons.YesNo);				        // �\������{�^��

                                if (rslt == DialogResult.Yes)
                                {
                                    upDateGoodsNm = true;
                                }
                                showMsg = true;
                            }


                            // BL�R�[�h ���f�[�^�ɓ����ĂȂ�������ǉ�
                            if (GetCellInt32(rows[0][COL_BLCD], 0) == 0)
                            {
                                rows[0][COL_BLCD] = retList[i].BLGoodsCode;
                                rows[0][COL_BLCDBR] = retList[i].BLGoodsDrCode;
                            }

                            // ���i����
                            if (upDateGoodsNm)
                            {
                                // �C���|�[�g�l��NULl����Ȃ����l���ύX����Ă���ꍇ�i�������Ԃ�����ׁj
                                if (!string.IsNullOrEmpty(retList[i].GoodsName) && !(rows[0][COL_GOODSNM].ToString().Equals(retList[i].GoodsName)))
                                {
                                    rows[0][COL_GOODSNM] = retList[i].GoodsName;
                                    changColList.Add(COL_GOODSNM);
                                }
                            }

                            // ���z���
                            // �W�����i�A�d�������͋����㏑���i������0�~�͏��O�j

                            // �W�����i
                            if (!retList[i].SuggestPrice.Equals(0))
                            {
                                long suggestPrice = Convert.ToInt64(retList[i].SuggestPrice);
                                if (!((long)rows[0][COL_SUGGEST_PRICE]).Equals(suggestPrice))
                                {
                                    rows[0][COL_SUGGEST_PRICE] = suggestPrice;
                                    changColList.Add(COL_SUGGEST_PRICE);
                                }
                            }

                            // �d������
                            if (!retList[i].PurchaseCost.Equals(0))
                            {
                                long purchaseCost = Convert.ToInt64(retList[i].PurchaseCost);
                                if (!((long)rows[0][COL_PURCHASE_COST]).Equals(purchaseCost))
                                {
                                    rows[0][COL_PURCHASE_COST] = purchaseCost;
                                    changColList.Add(COL_PURCHASE_COST);
                                }
                            }

                            // �������Z�b�g�����悤�ɂȂ����̂�0�łȂ����A�ύX����Ă����荞��
                            // ����
                            if (!retList[i].TradePrice.Equals(0))
                            {
                                long tradePrice = Convert.ToInt64(retList[i].TradePrice);
                                if (!((long)rows[0][COL_TRADE_PRICE]).Equals(tradePrice))
                                {
                                    rows[0][COL_TRADE_PRICE] = tradePrice;
                                    changColList.Add(COL_TRADE_PRICE);
                                }
                            }



                            // �݌ɏ�� PM�����0:���ב҂�,2:�݌Ɏc��,3:�݌ɖL�x�@�����߂�Ȃ�
                            int stockStatusDiv = retList[i].StockStatusDiv;

                            switch (stockStatusDiv)
                            {
                                case 0: // ����
                                    if (!((int)rows[0][COL_STOCKSTATE]).Equals(3))
                                    {
                                        rows[0][COL_STOCKSTATE] = 3;
                                        changColList.Add(COL_STOCKSTATE);
                                    }
                                    break;
                                case 2: // �݌Ɏc��
                                    if (!((int)rows[0][COL_STOCKSTATE]).Equals(2))
                                    {
                                        rows[0][COL_STOCKSTATE] = 2;
                                        changColList.Add(COL_STOCKSTATE);
                                    }
                                    break;
                                case 3: // �݌ɖL�x
                                    if (!((int)rows[0][COL_STOCKSTATE]).Equals(1))
                                    {
                                        rows[0][COL_STOCKSTATE] = 1;
                                        changColList.Add(COL_STOCKSTATE);
                                    }
                                    break;
                                default:
                                    if (!((int)rows[0][COL_STOCKSTATE]).Equals(stockStatusDiv))
                                    {
                                        rows[0][COL_STOCKSTATE] = -1;
                                        changColList.Add(COL_STOCKSTATE);
                                    }
                                    break;
                            }

                            // ���i�^�O
                            switch ((long)this.Category_ComboEditor.Value)
                            {
                                case 1: // �^�C��
                                    // // ���i�^�O1 �T�C�Y
                                    if (!string.IsNullOrEmpty(retList[i].SearchTag1) && !(rows[0][COL_TIRE_KEY1].ToString().Equals(retList[i].SearchTag1)))
                                    {
                                        rows[0][COL_TIRE_KEY1] = retList[i].SearchTag1;
                                        changColList.Add(COL_TIRE_KEY1);
                                    }
                                    // ���i�^�O�Q �X�^�b�h���X
                                    #region ����PM������͖߂��Ă��Ȃ����A�Z�b�g���ꂽ�ꍇ�Ɏ�荞�߂�悤�ɂ��Ă���
                                    if (retList[i].SearchTag2 != null && !String.IsNullOrEmpty(retList[i].SearchTag2))
                                    {
                                        if (((bool)rows[0][COL_TIRE_KEY2] == false) && (retList[i].SearchTag2 == "1"))
                                        {
                                            rows[0][COL_TIRE_KEY2] = true;
                                            changColList.Add(COL_TIRE_KEY2);
                                        }
                                        else if (((bool)rows[0][COL_TIRE_KEY2] == true) && (retList[i].SearchTag2 == "0"))
                                        {
                                            rows[0][COL_TIRE_KEY2] = false;
                                            changColList.Add(COL_TIRE_KEY2);
                                        }
                                    }
                                    #endregion

                                    break;
                                case 2: //�o�b�e��
                                    // // ���i�^�O1 �K�i
                                    if (!string.IsNullOrEmpty(retList[i].SearchTag1) && !(rows[0][COL_BATTERY_KEY1].ToString().Equals(retList[i].SearchTag1)))
                                    {
                                        rows[0][COL_BATTERY_KEY1] = retList[i].SearchTag1;
                                        changColList.Add(COL_BATTERY_KEY1);
                                    }

                                    // ���i�^�O2 �K��
                                    #region ����PM������͖߂��Ă��Ȃ����A�Z�b�g���ꂽ�ꍇ�Ɏ�荞�߂�悤�ɂ��Ă���
                                    if (retList[i].SearchTag2 != null && retList[i].SearchTag3 != null && !String.IsNullOrEmpty(retList[i].SearchTag2) && !String.IsNullOrEmpty(retList[i].SearchTag3))
                                    {
                                        if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("0") && (int)rows[0][COL_BATTERY_KEY2] != 1)
                                        {
                                            rows[0][COL_BATTERY_KEY2] = 1;
                                            changColList.Add(COL_BATTERY_KEY2);
                                        }
                                        else if (retList[i].SearchTag2.Equals("0") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_BATTERY_KEY2] != 2)
                                        {
                                            rows[0][COL_BATTERY_KEY2] = 2;
                                            changColList.Add(COL_BATTERY_KEY2);
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_BATTERY_KEY2] != 3)
                                        {
                                            rows[0][COL_BATTERY_KEY2] = 3;
                                            changColList.Add(COL_BATTERY_KEY2);
                                        }
                                    }
                                    #endregion

                                    break;
                                case 3: // �I�C��

                                    // ���i�^�O1 �S�x
                                    if (!string.IsNullOrEmpty(retList[i].SearchTag1) && !(rows[0][COL_OIL_KEY1].ToString().Equals(retList[i].SearchTag1)))
                                    {
                                        rows[0][COL_OIL_KEY1] = retList[i].SearchTag1;
                                        changColList.Add(COL_OIL_KEY1);
                                    }

                                    // ���i�^�O2 �K��
                                    #region ����PM������͖߂��Ă��Ȃ����A�Z�b�g���ꂽ�ꍇ�Ɏ�荞�߂�悤�ɂ��Ă���
                                    if (retList[i].SearchTag2 != null && retList[i].SearchTag3 != null && !String.IsNullOrEmpty(retList[i].SearchTag2) && !String.IsNullOrEmpty(retList[i].SearchTag3))
                                    {
                                        if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("0") && (int)rows[0][COL_OIL_KEY2] != 1)
                                        {
                                            rows[0][COL_OIL_KEY2] = 1;
                                            changColList.Add(COL_OIL_KEY2);
                                        }
                                        else if (retList[i].SearchTag2.Equals("0") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_OIL_KEY2] != 2)
                                        {
                                            rows[0][COL_OIL_KEY2] = 2;
                                            changColList.Add(COL_OIL_KEY2);
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_OIL_KEY2] != 3)
                                        {
                                            rows[0][COL_OIL_KEY2] = 3;
                                            changColList.Add(COL_OIL_KEY2);
                                        }
                                    }
                                    #endregion

                                    break;
                            }

                            // �X�V�s��Index���擾
                            if (!changeList.ContainsKey(this.TBODataSet.Tables[TABLE_MAIN].Rows.IndexOf(rows[0])))
                            {
                                changeList.Add(this.TBODataSet.Tables[TABLE_MAIN].Rows.IndexOf(rows[0]), changColList);
                            }

                            // �s�̑e�����v�Z
                            this.CalcGrossProc(ref rows[0]);
                            // �X�V����
                            updateCount++;
                        }
                        else
                        {
                            // �V�K
                            // �ǉ�
                            DataRow newRow = this.TBODataSet.Tables[TABLE_MAIN].NewRow();
                            newRow[COL_BLCD] = retList[i].BLGoodsCode;
                            newRow[COL_BLCDBR] = retList[i].BLGoodsDrCode;
                            newRow[COL_GOODSNM] = retList[i].GoodsName;
                            newRow[COL_GOODSNO] = retList[i].GoodsNo;

                            // ���[�J�[���X�g�ɂ���΃R�[�h�̗p�B�񋟂̖��̂𔽉f
                            if (this._makerCdDic.ContainsKey(retList[i].GoodsMakerCd))
                            {
                                newRow[COL_MAKERCD] = retList[i].GoodsMakerCd;
                                newRow[COL_MAKERNM] = this._makerCdDic[retList[i].GoodsMakerCd].MakerName;
                            }
                            else
                            {
                                // ���X�g�ɂȂ���Ζ��̂̂ݔ��f
                                newRow[COL_MAKERCD] = 0;
                                newRow[COL_MAKERNM] = retList[i].MakerName;
                            }

                            // PM�݌ɍX�V��
                            newRow[COL_PM_UPDATETIME] = retList[i].PMUpdateTime;
                           
                            // ���z�n
                            newRow[COL_SHOP_PRICE] = Convert.ToInt64(retList[i].ShopPrice);
                            newRow[COL_STOCKCOUNT] = retList[i].StockCnt;

                            // �݌ɏ��
                            int stockStatusDiv = retList[i].StockStatusDiv;

                            switch (stockStatusDiv)
                            {
                                case 0: // ����
                                    newRow[COL_STOCKSTATE] = 3;
                                    break;
                                case 2: // �݌Ɏc��
                                    newRow[COL_STOCKSTATE] = 2;
                                    break;
                                case 3: // �݌ɖL�x
                                    newRow[COL_STOCKSTATE] = 1;
                                    break;
                                default:
                                    newRow[COL_STOCKSTATE] = -1;
                                    break;
                            }

                            newRow[COL_SUGGEST_PRICE] = Convert.ToInt64(retList[i].SuggestPrice);
                            newRow[COL_TRADE_PRICE] = Convert.ToInt64(retList[i].TradePrice);
                            newRow[COL_PURCHASE_COST] = Convert.ToInt64(retList[i].PurchaseCost);

                            switch ((long)this.Category_ComboEditor.Value)
                            {
                                case 1: // �^�C��
                                    newRow[COL_TIRE_KEY1] = retList[i].SearchTag1;

                                    #region ����PM������͖߂��Ă��Ȃ����A�Z�b�g���ꂽ�ꍇ�Ɏ�荞�߂�悤�ɂ��Ă���
                                    if (retList[i].SearchTag2 != null && !String.IsNullOrEmpty(retList[i].SearchTag2))
                                    {
                                        if (retList[i].SearchTag2 == "0")
                                        {
                                            newRow[COL_TIRE_KEY2] = false;
                                        }
                                        else if (retList[i].SearchTag2 == "1")
                                        {
                                            newRow[COL_TIRE_KEY2] = true;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 2: // �o�b�e��
                                    newRow[COL_BATTERY_KEY1] = retList[i].SearchTag1;

                                    #region ����PM������͖߂��Ă��Ȃ����A�Z�b�g���ꂽ�ꍇ�Ɏ�荞�߂�悤�ɂ��Ă���
                                    if (retList[i].SearchTag2 != null && retList[i].SearchTag3 != null && !String.IsNullOrEmpty(retList[i].SearchTag2) && !String.IsNullOrEmpty(retList[i].SearchTag3))
                                    {
                                        if (retList[i].SearchTag2.Equals("0") && retList[i].SearchTag3.Equals("1"))
                                        {
                                            newRow[COL_BATTERY_KEY2] = 2;
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("0"))
                                        {
                                            newRow[COL_BATTERY_KEY2] = 1;
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("1"))
                                        {
                                            newRow[COL_BATTERY_KEY2] = 3;
                                        }
                                    }
                                    #endregion
                                    break;
                                case 3: // �I�C��
                                    newRow[COL_OIL_KEY1] = retList[i].SearchTag1;

                                    #region ����PM������͖߂��Ă��Ȃ����A�Z�b�g���ꂽ�ꍇ�Ɏ�荞�߂�悤�ɂ��Ă���
                                    if (retList[i].SearchTag2 != null && retList[i].SearchTag3 != null && !String.IsNullOrEmpty(retList[i].SearchTag2) && !String.IsNullOrEmpty(retList[i].SearchTag3))
                                    {
                                        if (retList[i].SearchTag2.Equals("0") && retList[i].SearchTag3.Equals("1"))
                                        {
                                            newRow[COL_OIL_KEY2] = 2;
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("0"))
                                        {
                                            newRow[COL_OIL_KEY2] = 1;
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("1"))
                                        {
                                            newRow[COL_OIL_KEY2] = 3;
                                        }
                                    }
                                    #endregion
                                    break;
                            }

                            // �s�̑e�����v�Z
                            this.CalcGrossProc(ref newRow);

                            this.TBODataSet.Tables[TABLE_MAIN].Rows.Add(newRow);
                            // �V�K����
                            newCount++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "���i�捞�������ɗ�O���������܂����B" + Environment.NewLine + ex.StackTrace.ToString();
            }
            finally
            {
                this.Goods_Grid.EndUpdate();
            }
            return st;
        }
        #endregion

        #region CSV�C���|�[�g
        /// <summary>
        /// �捞�f�[�^���f
        /// </summary>
        /// <param name="saveAray"></param>
        private int ReflectCSVImportData(List<Propose_Goods> retList, out int newCount, out int updateCount, out  Dictionary<int, List<string>> changeList, out string errMsg)
        {
            // �Z�b�g�}�X�^�捞�Ƃ��������������������A�o�O�𐶂܂Ȃ��悤�ɕʏ����ɂ���
            // CSV�捞�̏ꍇ��CSV�𐳂Ƃ��đS�㏑���Ƃ���

            int st = 0;
            newCount = 0;
            updateCount = 0;
            errMsg = "";
            changeList = new Dictionary<int, List<string>>();
          
            try
            {
                this.Goods_Grid.BeginUpdate();

                // �i�� + ���[�J�[���̂ɂĊ����s������
                // �����L�[�������܂܂�Ă�����?
                // ���X�V���F�㏟�����C���M�����[�Ȃ̂łn�j
                // ���V�K���F�S�ĐV�K�s�Ŏ捞�A�ۑ����Ƀ`�F�b�N���C���M�����[�Ȃ̂łn�j

                if (retList != null)
                {
                    string mkNm = "";
                    string goodsNo = "";
                    for (int i = 0; i < retList.Count; i++)
                    {
                        mkNm = retList[i].MakerName;
                        goodsNo = retList[i].GoodsNo;
                        StringBuilder cndString = new StringBuilder();
                        // �o�^�ύs�̂�
                        cndString.Append(String.Format("{0}='{1}' AND {2}='{3}'", COL_MAKERNM, mkNm, COL_GOODSNO, goodsNo));
                        DataRow[] rows = this.TBODataSet.Tables[TABLE_MAIN].Select(cndString.ToString());

                        if (rows != null && rows.Length > 0 && rows[0][COL_POSTPARACLASS] != DBNull.Value)
                        {
                            List<string> changColList = new List<string>();

                            // �X�V
                            // �捞�G���[���������ĂȂ�������㏑��
                            // ���i����
                            // �ύX����Ă����荞��
                            if (retList[i].GoodsName != ct_ErrSt && !(rows[0][COL_GOODSNM].ToString().Equals(retList[i].GoodsName)))
                            {
                                rows[0][COL_GOODSNM] = retList[i].GoodsName;
                                changColList.Add(COL_GOODSNM);
                            }

                            // ���i����
                            if (retList[i].GoodsNote != ct_ErrSt && !(rows[0][COL_GOODSNOTE].ToString().Equals(retList[i].GoodsNote)))
                            {
                                rows[0][COL_GOODSNOTE] = retList[i].GoodsNote;
                                changColList.Add(COL_GOODSNOTE);
                            }


                            // ���iPR
                            if (retList[i].GoodsPR != ct_ErrSt && !(rows[0][COL_GOODSPR].ToString().Equals(retList[i].GoodsPR)))
                            {
                                rows[0][COL_GOODSPR] = retList[i].GoodsPR;
                                changColList.Add(COL_GOODSPR);
                            }

                            // ���z���

                            // �W�����i
                            if (retList[i].SuggestPrice != ct_ErrDouble)
                            {
                                long suggestPrice = Convert.ToInt64(retList[i].SuggestPrice);
                                if (!((long)rows[0][COL_SUGGEST_PRICE]).Equals(suggestPrice))
                                {
                                    rows[0][COL_SUGGEST_PRICE] = suggestPrice;
                                    changColList.Add(COL_SUGGEST_PRICE);
                                }
                            }

                            // �X�����i 
                            if (retList[i].ShopPrice != ct_ErrDouble)
                            {
                                long shopPrice = Convert.ToInt64(retList[i].ShopPrice);
                                if (!((long)rows[0][COL_SHOP_PRICE]).Equals(shopPrice))
                                {
                                    rows[0][COL_SHOP_PRICE] = shopPrice;
                                    changColList.Add(COL_SHOP_PRICE);
                                }
                            }

                            // �d������
                            if (retList[i].PurchaseCost != ct_ErrDouble)
                            {
                                long purchaseCost = Convert.ToInt64(retList[i].PurchaseCost);
                                if (!((long)rows[0][COL_PURCHASE_COST]).Equals(purchaseCost))
                                {
                                    rows[0][COL_PURCHASE_COST] = purchaseCost;
                                    changColList.Add(COL_PURCHASE_COST);
                                }
                            }

                            // ����
                            if (retList[i].TradePrice != ct_ErrDouble)
                            {
                                long tradePrice = Convert.ToInt64(retList[i].TradePrice);
                                if (!((long)rows[0][COL_TRADE_PRICE]).Equals(tradePrice))
                                {
                                    rows[0][COL_TRADE_PRICE] = tradePrice;
                                    changColList.Add(COL_TRADE_PRICE);
                                }
                            }

                            // �̔���
                            if (retList[i].ReleaseDate != ct_ErrInt)
                            {
                                if (retList[i].ReleaseDate == 0)
                                {
                                    // �̔����͈ꊇ�N���A���������Ƃ����邩������Ȃ��̂�
                                    if (rows[0][COL_RELEASEDATE] != DBNull.Value)
                                    {
                                        rows[0][COL_RELEASEDATE] = DBNull.Value;
                                        changColList.Add(COL_RELEASEDATE);
                                    }
                                }
                                else
                                {
                                    DateTime releaseDate = DateTime.MinValue;
                                    try
                                    {
                                        int releaseDateInt = retList[i].ReleaseDate;
                                        string releaseDateSt = retList[i].ReleaseDate.ToString();
                                        if (releaseDateSt.Length == 6)
                                        {
                                            releaseDateSt = ((releaseDateInt * 100) + 1).ToString();
                                        }
                                        // �J���`���[�ݒ�
                                        IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                                        releaseDate = DateTime.ParseExact(releaseDateSt, "yyyyMMdd", format);
                                    }
                                    catch
                                    {

                                    }

                                    if (releaseDate != null && releaseDate != DateTime.MinValue)
                                    {
                                        if (rows[0][COL_RELEASEDATE] == DBNull.Value)
                                        {
                                            rows[0][COL_RELEASEDATE] = releaseDate;
                                            changColList.Add(COL_RELEASEDATE);
                                        }
                                        else
                                        {
                                            // YYYYMM�Ŕ�r
                                            int befYear  = ((DateTime)rows[0][COL_RELEASEDATE]).Year;
                                            int befMonth = ((DateTime)rows[0][COL_RELEASEDATE]).Month;
                                            int afYear   = releaseDate.Year;
                                            int afMonth   = releaseDate.Month;

                                            if(!befYear.Equals(afYear) || !befMonth.Equals(afMonth))
                                            {
                                                rows[0][COL_RELEASEDATE] = releaseDate;
                                                changColList.Add(COL_RELEASEDATE);
                                            }
                                        }
                                    }
                                }
                            }

                            // ���J�J�n��
                            if (retList[i].ShopSaleBeginDate != ct_ErrInt)
                            {
                                DateTime beginDate = DateTime.MinValue;
                                try
                                {
                                    string beginDateIntSt = retList[i].ShopSaleBeginDate.ToString();
                                    // �J���`���[�ݒ�
                                    IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                                    beginDate = DateTime.ParseExact(beginDateIntSt, "yyyyMMdd", format);
                                }
                                catch
                                {

                                }
                                if (beginDate != null && beginDate != DateTime.MinValue)
                                {
                                    if (rows[0][COL_SHOPSALEBEGINDATE] == DBNull.Value)
                                    {
                                        rows[0][COL_SHOPSALEBEGINDATE] = beginDate;
                                        changColList.Add(COL_SHOPSALEBEGINDATE);
                                    }
                                    else if (!((DateTime)rows[0][COL_SHOPSALEBEGINDATE]).Equals(beginDate))
                                    {
                                        rows[0][COL_SHOPSALEBEGINDATE] = beginDate;
                                        changColList.Add(COL_SHOPSALEBEGINDATE);
                                    }
                                }

                                // ���J���̓f�t�H���g��0�Ȃ̂ŁA0�����Ă��N���A���Ȃ�
                            }


                            // ���J�I����
                            if (retList[i].ShopSaleEndDate != ct_ErrInt)
                            {
                                if (retList[i].ShopSaleEndDate == 0)
                                {
                                    // �I�����͈ꊇ�N���A���������Ƃ����邩������Ȃ��̂�
                                    if (rows[0][COL_SHOPSALEENDDATE] != DBNull.Value)
                                    {
                                        rows[0][COL_SHOPSALEENDDATE] = DBNull.Value;
                                        changColList.Add(COL_SHOPSALEENDDATE);
                                    }
                                }
                                else
                                {
                                    DateTime endDate = DateTime.MinValue;
                                    try
                                    {
                                        string endDateSt = retList[i].ShopSaleEndDate.ToString();
                                        // �J���`���[�ݒ�
                                        IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                                        endDate = DateTime.ParseExact(endDateSt, "yyyyMMdd", format);
                                    }
                                    catch
                                    {

                                    }

                                    if (endDate != null && endDate != DateTime.MinValue)
                                    {
                                        if (rows[0][COL_SHOPSALEENDDATE] == DBNull.Value)
                                        {
                                            rows[0][COL_SHOPSALEENDDATE] = endDate;
                                            changColList.Add(COL_SHOPSALEENDDATE);
                                        }
                                        else if (!((DateTime)rows[0][COL_SHOPSALEENDDATE]).Equals(endDate))
                                        {
                                            rows[0][COL_SHOPSALEENDDATE] = endDate;
                                            changColList.Add(COL_SHOPSALEENDDATE);
                                        }
                                    }
                                }
                            }

                            if (retList[i].StockStatusDiv != ct_Errshort)
                            {
                                // �݌ɏ�� (-1,0,1,2�ł���̂ł��̂܂܃Z�b�g)
                                int stockStatusDiv = retList[i].StockStatusDiv;
                                if (!((int)rows[0][COL_STOCKSTATE]).Equals(stockStatusDiv))
                                {
                                    rows[0][COL_STOCKSTATE] = stockStatusDiv;
                                    changColList.Add(COL_STOCKSTATE);
                                }
                            }

                            // ���i�^�O
                            switch ((long)this.Category_ComboEditor.Value)
                            {
                                case 1: // �^�C��
                                    // // ���i�^�O1 �T�C�Y
                                    if (retList[i].SearchTag1 != ct_ErrSt && !(rows[0][COL_TIRE_KEY1].ToString().Equals(retList[i].SearchTag1)))
                                    {
                                        rows[0][COL_TIRE_KEY1] = retList[i].SearchTag1;
                                        changColList.Add(COL_TIRE_KEY1);
                                    }
                                    // ���i�^�O�Q �X�^�b�h���X
                                    if (retList[i].SearchTag2 != ct_ErrSt)
                                    {
                                        if (((bool)rows[0][COL_TIRE_KEY2] == false) && (retList[i].SearchTag2 == "1") ||
                                        ((bool)rows[0][COL_TIRE_KEY2] == true) && (retList[i].SearchTag2 == "0"))
                                        {
                                            rows[0][COL_TIRE_KEY2] = retList[i].SearchTag2.Equals("0") ? false : true;
                                            changColList.Add(COL_TIRE_KEY2);
                                        }
                                    }
                                    break;
                                case 2: //�o�b�e��
                                    // // ���i�^�O1 �K�i
                                    if (retList[i].SearchTag1 != ct_ErrSt && !(rows[0][COL_BATTERY_KEY1].ToString().Equals(retList[i].SearchTag1)))
                                    {
                                        rows[0][COL_BATTERY_KEY1] = retList[i].SearchTag1;
                                        changColList.Add(COL_BATTERY_KEY1);
                                    }

                                    // ���i�^�O2 �K��
                                    if (retList[i].SearchTag2 != ct_ErrSt && retList[i].SearchTag3 != ct_ErrSt)
                                    {
                                        if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("0") && (int)rows[0][COL_BATTERY_KEY2] != 1)
                                        {
                                            rows[0][COL_BATTERY_KEY2] = 1;
                                            changColList.Add(COL_BATTERY_KEY2);
                                        }
                                        else if (retList[i].SearchTag2.Equals("0") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_BATTERY_KEY2] != 2)
                                        {
                                            rows[0][COL_BATTERY_KEY2] = 2;
                                            changColList.Add(COL_BATTERY_KEY2);
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_BATTERY_KEY2] != 3)
                                        {
                                            rows[0][COL_BATTERY_KEY2] = 3;
                                            changColList.Add(COL_BATTERY_KEY2);
                                        }
                                    }
                                    break;
                                case 3: // �I�C��

                                    // ���i�^�O1 �S�x
                                    if (retList[i].SearchTag1 != ct_ErrSt && !(rows[0][COL_OIL_KEY1].ToString().Equals(retList[i].SearchTag1)))
                                    {
                                        rows[0][COL_OIL_KEY1] = retList[i].SearchTag1;
                                        changColList.Add(COL_OIL_KEY1);
                                    }

                                    // ���i�^�O2 �K��
                                    if (retList[i].SearchTag2 != ct_ErrSt && retList[i].SearchTag3 != ct_ErrSt)
                                    {
                                        if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("0") && (int)rows[0][COL_OIL_KEY2] != 1)
                                        {
                                            rows[0][COL_OIL_KEY2] = 1;
                                            changColList.Add(COL_OIL_KEY2);
                                        }
                                        else if (retList[i].SearchTag2.Equals("0") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_OIL_KEY2] != 2)
                                        {
                                            rows[0][COL_OIL_KEY2] = 2;
                                            changColList.Add(COL_OIL_KEY2);
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_OIL_KEY2] != 3)
                                        {
                                            rows[0][COL_OIL_KEY2] = 3;
                                            changColList.Add(COL_OIL_KEY2);
                                        }
                                    }
                                    break;
                            }


                            // ���J
                            if (retList[i].release != ct_ErrInt)
                            {
                                if (((bool)rows[0][COL_RELEASE] == false) && (retList[i].release == 1) ||
                                    ((bool)rows[0][COL_RELEASE] == true) && (retList[i].release == 0))
                                {
                                    rows[0][COL_RELEASE] = retList[i].release;
                                    changColList.Add(COL_RELEASE);
                                }
                            }
                         

                            // �I�X�X��
                            if (retList[i].recommend != ct_ErrInt)
                            {
                                if (((bool)rows[0][COL_RECOMMEND] == false) && (retList[i].recommend == 1) ||
                              ((bool)rows[0][COL_RECOMMEND] == true) && (retList[i].recommend == 0))
                                {
                                    rows[0][COL_RECOMMEND] = retList[i].recommend;
                                    changColList.Add(COL_RECOMMEND);
                                }
                            }

                            #region �ߋ��̎d�l
                            //// �C���|�[�g�l��NULl����Ȃ����l���ύX����Ă���ꍇ�i�������Ԃ�����ׁj
                            //if (!string.IsNullOrEmpty(retList[i].GoodsName) && !(rows[0][COL_GOODSNM].ToString().Equals(retList[i].GoodsName)))
                            //{
                            //    rows[0][COL_GOODSNM] = retList[i].GoodsName;
                            //    changColList.Add(COL_GOODSNM);
                            //}

                            //// ���i����
                            //if (!string.IsNullOrEmpty(retList[i].GoodsNote) && !(rows[0][COL_GOODSNOTE].ToString().Equals(retList[i].GoodsNote)))
                            //{
                            //    rows[0][COL_GOODSNOTE] = retList[i].GoodsNote;
                            //    changColList.Add(COL_GOODSNOTE);
                            //}
                           

                            //// ���iPR
                            //if (!string.IsNullOrEmpty(retList[i].GoodsPR) && !(rows[0][COL_GOODSPR].ToString().Equals(retList[i].GoodsPR)))
                            //{
                            //    rows[0][COL_GOODSPR] = retList[i].GoodsPR;
                            //    changColList.Add(COL_GOODSPR);
                            //}

                            //// ���z���

                            //// �W�����i
                            //if (!retList[i].SuggestPrice.Equals(0))
                            //{
                            //    long suggestPrice = Convert.ToInt64(retList[i].SuggestPrice);
                            //    if (!((long)rows[0][COL_SUGGEST_PRICE]).Equals(suggestPrice))
                            //    {
                            //        rows[0][COL_SUGGEST_PRICE] = suggestPrice;
                            //        changColList.Add(COL_SUGGEST_PRICE);
                            //    }
                            //}

                            //// �X�����i 
                            //if (!retList[i].ShopPrice.Equals(0))
                            //{
                            //    long shopPrice = Convert.ToInt64(retList[i].ShopPrice);
                            //    if (!((long)rows[0][COL_SHOP_PRICE]).Equals(shopPrice))
                            //    {
                            //        rows[0][COL_SHOP_PRICE] = shopPrice;
                            //        changColList.Add(COL_SHOP_PRICE);
                            //    }
                            //}

                            //// �d������
                            //if (!retList[i].PurchaseCost.Equals(0))
                            //{
                            //    long purchaseCost = Convert.ToInt64(retList[i].PurchaseCost);
                            //    if (!((long)rows[0][COL_PURCHASE_COST]).Equals(purchaseCost))
                            //    {
                            //        rows[0][COL_PURCHASE_COST] = purchaseCost;
                            //        changColList.Add(COL_PURCHASE_COST);
                            //    }
                            //}

                            //// ����
                            //if (!retList[i].TradePrice.Equals(0))
                            //{
                            //    long tradePrice = Convert.ToInt64(retList[i].TradePrice);
                            //    if (!((long)rows[0][COL_TRADE_PRICE]).Equals(tradePrice))
                            //    {
                            //        rows[0][COL_TRADE_PRICE] = tradePrice;
                            //        changColList.Add(COL_TRADE_PRICE);
                            //    }
                            //}

                            //// �̔���
                            //DateTime releaseDate = DateTime.MinValue;

                            //try
                            //{
                            //    int releaseDateInt = retList[i].ReleaseDate;
                            //    string releaseDateSt = retList[i].ReleaseDate.ToString();
                            //    if (releaseDateSt.Length == 6)
                            //    {
                            //        releaseDateSt = ((releaseDateInt * 100) + 1).ToString();
                            //    }
                            //    // �J���`���[�ݒ�
                            //    IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                            //    releaseDate = DateTime.ParseExact(releaseDateSt, "yyyyMMdd", format);
                            //}
                            //catch
                            //{

                            //}

                            //if (releaseDate != null && releaseDate != DateTime.MinValue)
                            //{
                            //    if (rows[0][COL_RELEASEDATE] == DBNull.Value)
                            //    {
                            //        rows[0][COL_RELEASEDATE] = releaseDate;
                            //        changColList.Add(COL_RELEASEDATE);
                            //    }
                            //    else if (!((DateTime)rows[0][COL_RELEASEDATE]).Equals(releaseDate))
                            //    {
                            //        rows[0][COL_RELEASEDATE] = releaseDate;
                            //        changColList.Add(COL_RELEASEDATE);
                            //    }
                            //}


                            //// ���J�J�n��(�㏑��)
                            //DateTime beginDate = DateTime.MinValue;

                            //try
                            //{
                            //    string beginDateIntSt = retList[i].ShopSaleBeginDate.ToString();
                            //    // �J���`���[�ݒ�
                            //    IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                            //    beginDate = DateTime.ParseExact(beginDateIntSt, "yyyyMMdd", format);
                            //}
                            //catch
                            //{

                            //}
                            //if (beginDate != null && beginDate != DateTime.MinValue)
                            //{
                            //    if (rows[0][COL_SHOPSALEBEGINDATE] == DBNull.Value)
                            //    {
                            //        rows[0][COL_SHOPSALEBEGINDATE] = beginDate;
                            //        changColList.Add(COL_SHOPSALEBEGINDATE);
                            //    }
                            //    else if (!((DateTime)rows[0][COL_SHOPSALEBEGINDATE]).Equals(beginDate))
                            //    {
                            //        rows[0][COL_SHOPSALEBEGINDATE] = beginDate;
                            //        changColList.Add(COL_SHOPSALEBEGINDATE);
                            //    }
                            //}


                            //// ���J�I����
                            //if (retList[i].ShopSaleEndDate == 0)
                            //{
                            //    // �I�����͈ꊇ�N���A���������Ƃ����邩������Ȃ��̂�
                            //    if (rows[0][COL_SHOPSALEENDDATE] != DBNull.Value)
                            //    {
                            //        rows[0][COL_SHOPSALEENDDATE] = DBNull.Value;
                            //        changColList.Add(COL_SHOPSALEENDDATE);
                            //    }
                            //}
                            //else
                            //{
                            //    DateTime endDate = DateTime.MinValue;

                            //    try
                            //    {
                            //        string endDateSt = retList[i].ShopSaleEndDate.ToString();
                            //        // �J���`���[�ݒ�
                            //        IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                            //        endDate = DateTime.ParseExact(endDateSt, "yyyyMMdd", format);
                            //    }
                            //    catch
                            //    {

                            //    }

                            //    if (endDate != null && endDate != DateTime.MinValue)
                            //    {
                            //        if (rows[0][COL_SHOPSALEENDDATE] == DBNull.Value)
                            //        {
                            //            rows[0][COL_SHOPSALEENDDATE] = endDate;
                            //            changColList.Add(COL_SHOPSALEENDDATE);
                            //        }
                            //        else if (!((DateTime)rows[0][COL_SHOPSALEENDDATE]).Equals(endDate))
                            //        {
                            //            rows[0][COL_SHOPSALEENDDATE] = endDate;
                            //            changColList.Add(COL_SHOPSALEENDDATE);
                            //        }
                            //    }
                            //}

                            //// �݌ɏ�� (-1,0,1,2�ł���̂ł��̂܂܃Z�b�g)
                            //int stockStatusDiv = retList[i].StockStatusDiv;
                            //if (!((int)rows[0][COL_STOCKSTATE]).Equals(stockStatusDiv))
                            //{
                            //    rows[0][COL_STOCKSTATE] = stockStatusDiv;
                            //    changColList.Add(COL_STOCKSTATE);
                            //}

                            //// ���i�^�O
                            //switch ((long)this.Category_ComboEditor.Value)
                            //{
                            //    case 1: // �^�C��
                            //        // // ���i�^�O1 �T�C�Y
                            //        if (!string.IsNullOrEmpty(retList[i].SearchTag1) && !(rows[0][COL_TIRE_KEY1].ToString().Equals(retList[i].SearchTag1)))
                            //        {
                            //            rows[0][COL_TIRE_KEY1] = retList[i].SearchTag1;
                            //            changColList.Add(COL_TIRE_KEY1);
                            //        }
                            //        // ���i�^�O�Q �X�^�b�h���X
                            //        if (((bool)rows[0][COL_TIRE_KEY2] == false) && (retList[i].SearchTag2 == "1") ||
                            //        ((bool)rows[0][COL_TIRE_KEY2] == true) && (retList[i].SearchTag2 == "0"))
                            //        {
                            //            rows[0][COL_TIRE_KEY2] = retList[i].SearchTag2.Equals("0") ? false : true;
                            //            changColList.Add(COL_TIRE_KEY2);
                            //        }
                            //        break;
                            //    case 2: //�o�b�e��
                            //        // // ���i�^�O1 �K�i
                            //        if (!string.IsNullOrEmpty(retList[i].SearchTag1) && !(rows[0][COL_BATTERY_KEY1].ToString().Equals(retList[i].SearchTag1)))
                            //        {
                            //            rows[0][COL_BATTERY_KEY1] = retList[i].SearchTag1;
                            //            changColList.Add(COL_BATTERY_KEY1);
                            //        }

                            //        // ���i�^�O2 �K��
                            //        if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("0") && (int)rows[0][COL_BATTERY_KEY2] != 1)
                            //        {
                            //            rows[0][COL_BATTERY_KEY2] = 1;
                            //            changColList.Add(COL_BATTERY_KEY2);
                            //        }
                            //        else if (retList[i].SearchTag2.Equals("0") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_BATTERY_KEY2] != 2)
                            //        {
                            //            rows[0][COL_BATTERY_KEY2] = 2;
                            //            changColList.Add(COL_BATTERY_KEY2);
                            //        }
                            //        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_BATTERY_KEY2] != 3)
                            //        {
                            //            rows[0][COL_BATTERY_KEY2] = 3;
                            //            changColList.Add(COL_BATTERY_KEY2);
                            //        }
                            //        break;
                            //    case 3: // �I�C��

                            //        // ���i�^�O1 �S�x
                            //        if (!string.IsNullOrEmpty(retList[i].SearchTag1) && !(rows[0][COL_OIL_KEY1].ToString().Equals(retList[i].SearchTag1)))
                            //        {
                            //            rows[0][COL_OIL_KEY1] = retList[i].SearchTag1;
                            //            changColList.Add(COL_OIL_KEY1);
                            //        }

                            //        // ���i�^�O2 �K��
                            //        if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("0") && (int)rows[0][COL_OIL_KEY2] != 1)
                            //        {
                            //            rows[0][COL_OIL_KEY2] = 1;
                            //            changColList.Add(COL_OIL_KEY2);
                            //        }
                            //        else if (retList[i].SearchTag2.Equals("0") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_OIL_KEY2] != 2)
                            //        {
                            //            rows[0][COL_OIL_KEY2] = 2;
                            //            changColList.Add(COL_OIL_KEY2);
                            //        }
                            //        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("1") && (int)rows[0][COL_OIL_KEY2] != 3)
                            //        {
                            //            rows[0][COL_OIL_KEY2] = 3;
                            //            changColList.Add(COL_OIL_KEY2);
                            //        }
                            //        break;
                            //}

                            
                            //// ���J
                            //if (((bool)rows[0][COL_RELEASE] == false) && (retList[i].release == 1) ||
                            //    ((bool)rows[0][COL_RELEASE] == true ) && (retList[i].release == 0))
                            //{
                            //    rows[0][COL_RELEASE] = retList[i].release;
                            //    changColList.Add(COL_RELEASE);
                            //}
                    
                            //// �I�X�X��
                            //if (((bool)rows[0][COL_RECOMMEND] == false) && (retList[i].recommend == 1) ||
                            //   ((bool)rows[0][COL_RECOMMEND] == true) && (retList[i].recommend == 0))
                            //{
                            //    rows[0][COL_RECOMMEND] = retList[i].recommend;
                            //    changColList.Add(COL_RECOMMEND);
                            //}
                            #endregion

                            // �X�V�s��Index���擾
                            if (!changeList.ContainsKey(this.TBODataSet.Tables[TABLE_MAIN].Rows.IndexOf(rows[0])))
                            {
                                changeList.Add(this.TBODataSet.Tables[TABLE_MAIN].Rows.IndexOf(rows[0]), changColList);
                            }

                            // �s�̑e�����v�Z
                            this.CalcGrossProc(ref rows[0]);
                            // �X�V����
                            updateCount++;
                        }
                        else
                        {
                            // �V�K
                            // �ǉ�
                            DataRow newRow = this.TBODataSet.Tables[TABLE_MAIN].NewRow();

                            if (retList[i].GoodsName != ct_ErrSt)
                            {
                                newRow[COL_GOODSNM] = retList[i].GoodsName;
                            }
                            if (retList[i].GoodsNo != ct_ErrSt)
                            {
                                newRow[COL_GOODSNO] = retList[i].GoodsNo;
                            }
                            if (retList[i].GoodsNote != ct_ErrSt)
                            {
                                newRow[COL_GOODSNOTE] = retList[i].GoodsNote;
                            }
                            if (retList[i].GoodsPR != ct_ErrSt)
                            {
                                newRow[COL_GOODSPR] = retList[i].GoodsPR;
                            } 

                            // ���[�J�[���X�g�ɂ���΃R�[�h�̗p�B�񋟂̖��̂𔽉f

                            if (retList[i].MakerName != ct_ErrSt)
                            {
                                newRow[COL_MAKERNM] = retList[i].MakerName;
                            }

                            if (retList[i].GoodsMakerCd != ct_ErrInt)
                            {
                                if (this._makerCdDic.ContainsKey(retList[i].GoodsMakerCd))
                                {
                                    newRow[COL_MAKERCD] = retList[i].GoodsMakerCd;
                                    newRow[COL_MAKERNM] = this._makerCdDic[retList[i].GoodsMakerCd].MakerName;
                                }
                                else
                                {
                                    // ���X�g�ɂȂ���΃N���A
                                    newRow[COL_MAKERCD] = 0;
                                }
                            }

                            // ������
                            if (retList[i].ReleaseDate != ct_ErrInt)
                            {
                                DateTime releaseDate = DateTime.MinValue;
                                try
                                {
                                    int releaseDateInt = retList[i].ReleaseDate;
                                    string releaseDateSt = retList[i].ReleaseDate.ToString();
                                    if (releaseDateSt.Length == 6)
                                    {
                                        releaseDateSt = ((releaseDateInt * 100) + 1).ToString();
                                    }
                                    // �J���`���[�ݒ�
                                    IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                                    releaseDate = DateTime.ParseExact(releaseDateSt, "yyyyMMdd", format);
                                }
                                catch
                                {

                                }

                                if (releaseDate != null && releaseDate != DateTime.MinValue)
                                {
                                    newRow[COL_RELEASEDATE] = releaseDate;
                                }
                            }

                            // ���J�J�n��
                            if (retList[i].ShopSaleBeginDate != ct_ErrInt)
                            {
                                DateTime beginDate = DateTime.MinValue;

                                try
                                {
                                    string beginDateIntSt = retList[i].ShopSaleBeginDate.ToString();
                                    // �J���`���[�ݒ�
                                    IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                                    beginDate = DateTime.ParseExact(beginDateIntSt, "yyyyMMdd", format);
                                }
                                catch
                                {

                                }
                                if (beginDate != null && beginDate != DateTime.MinValue)
                                {
                                    newRow[COL_SHOPSALEBEGINDATE] = beginDate;
                                }
                            }

                            // ���J�I����
                            if (retList[i].ShopSaleEndDate != ct_ErrInt)
                            {
                                DateTime endDate = DateTime.MinValue;
                                try
                                {
                                    string endDateSt = retList[i].ShopSaleEndDate.ToString();
                                    // �J���`���[�ݒ�
                                    IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);
                                    endDate = DateTime.ParseExact(endDateSt, "yyyyMMdd", format);
                                }
                                catch
                                {

                                }

                                if (endDate != null && endDate != DateTime.MinValue)
                                {
                                    newRow[COL_SHOPSALEENDDATE] = endDate;
                                }
                            }
                            
                            // ���z

                            // �W�����i�iPM,SF���p�j
                            if (retList[i].SuggestPrice != ct_ErrDouble)
                            {
                                newRow[COL_SUGGEST_PRICE] = Convert.ToInt64(retList[i].SuggestPrice);
                            }
                            // �X�����i�iPM,SF���p�j
                            if (retList[i].ShopPrice != ct_ErrDouble)
                            {
                                newRow[COL_SHOP_PRICE] = Convert.ToInt64(retList[i].ShopPrice);
                            }

                            // ����(PM��)�A�d������(SF��)
                            if (retList[i].TradePrice != ct_ErrDouble)
                            {
                                newRow[COL_TRADE_PRICE] = Convert.ToInt64(retList[i].TradePrice);
                            }

                            // �d�������iPM�p�j
                            if (retList[i].PurchaseCost != ct_ErrDouble)
                            {
                                newRow[COL_PURCHASE_COST] = Convert.ToInt64(retList[i].PurchaseCost);
                            }

                            if (this._bootPara.BootMode == BootMode.PM)
                            {
                                // ���i�����[�h

                                // �݌ɏ��
                                if (retList[i].StockStatusDiv != ct_Errshort)
                                {
                                    newRow[COL_STOCKSTATE] = retList[i].StockStatusDiv;
                                }
                            }
                            else
                            {
                                // �����H�ꃂ�[�h
                                // �݌ɏ��
                                newRow[COL_STOCKSTATE] = -1;
                            }

                            switch ((long)this.Category_ComboEditor.Value)
                            {
                                case 1: // �^�C��
                                    if (retList[i].SearchTag1 != ct_ErrSt)
                                    {
                                        newRow[COL_TIRE_KEY1] = retList[i].SearchTag1;
                                    }
                                    if (retList[i].SearchTag2 != ct_ErrSt)
                                    {
                                        if (retList[i].SearchTag2.Equals("1"))
                                        {
                                            newRow[COL_TIRE_KEY2] = true;
                                        }
                                        else
                                        {
                                            newRow[COL_TIRE_KEY2] = false;
                                        }
                                    }
                                    break;
                                case 2: // �o�b�e��
                                    if (retList[i].SearchTag1 != ct_ErrSt)
                                    {
                                        newRow[COL_BATTERY_KEY1] = retList[i].SearchTag1;
                                    }
                                    if (retList[i].SearchTag2 != ct_ErrSt && retList[i].SearchTag3 != ct_ErrSt)
                                    {
                                        if (retList[i].SearchTag2.Equals("0") && retList[i].SearchTag3.Equals("1"))
                                        {
                                            newRow[COL_BATTERY_KEY2] = 2;
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("0"))
                                        {
                                            newRow[COL_BATTERY_KEY2] = 1;
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("1"))
                                        {
                                            newRow[COL_BATTERY_KEY2] = 3;
                                        }
                                    }
                                    break;
                                case 3: // �I�C��
                                    if (retList[i].SearchTag1 != ct_ErrSt)
                                    {
                                        newRow[COL_OIL_KEY1] = retList[i].SearchTag1;
                                    }
                                    if (retList[i].SearchTag2 != ct_ErrSt && retList[i].SearchTag3 != ct_ErrSt)
                                    {
                                        if (retList[i].SearchTag2.Equals("0") && retList[i].SearchTag3.Equals("1"))
                                        {
                                            newRow[COL_OIL_KEY2] = 2;
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("0"))
                                        {
                                            newRow[COL_OIL_KEY2] = 1;
                                        }
                                        else if (retList[i].SearchTag2.Equals("1") && retList[i].SearchTag3.Equals("1"))
                                        {
                                            newRow[COL_OIL_KEY2] = 3;
                                        }
                                    }
                                    break;
                            }
                      
                            // ���J
                            if (retList[i].release != ct_ErrInt)
                            {
                                newRow[COL_RELEASE] = retList[i].release;
                            }

                            // �I�X�X��
                            if (retList[i].recommend != ct_ErrInt)
                            {
                                newRow[COL_RECOMMEND] = retList[i].recommend;
                            }

                            // �s�̑e�����v�Z
                            this.CalcGrossProc(ref newRow);

                            this.TBODataSet.Tables[TABLE_MAIN].Rows.Add(newRow);
                            // �V�K����
                            newCount++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                st = -1;
                errMsg = "���i�捞�������ɗ�O���������܂����B" + Environment.NewLine + ex.StackTrace.ToString();
            }
            finally
            {
                this.Goods_Grid.EndUpdate();
            }
            return st;
        }
        #endregion


        /// <summary>
        /// CSV�C���|�[�g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // �ۑ��m�F
            if (CheckUpDate() == false) return;
            CsvImportForm form = new CsvImportForm();
            form.Icon = this.Icon;
            form._bootMode = this._bootPara.BootMode;

            form._categoryId = (long)this.Category_ComboEditor.Value;
            form._categoryName = this.Category_ComboEditor.Text;

            int st = 0;
            string errMsg = "";

            DialogResult ret = form.ShowCsvImportForm();
            if (ret == DialogResult.OK)
            {
                if (form._proposeGoodsList.Count == 0)
                {
                    // �捞�f�[�^�Ȃ�
                    TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_INFO,	    // �G���[���x��
                    CT_ASSEMBLYID,						// �A�Z���u��ID�܂��̓N���XID
                    "�捞�f�[�^������܂���",			// �\�����郁�b�Z�[�W 
                    0,								    // �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��
                }
                else
                {
                    // �����f�[�^�Ǎ����s���Ă��Ȃ��ꍇ�͈�U���o�������s��
                    if (this.Section_ComboEditor.Enabled == true)
                    {
                        st = 0;
                        errMsg = "";
                        List<ProposeGoods> proposeGoodstList = new List<ProposeGoods>();
                        st = this.SearchGoodsProc(out proposeGoodstList, out errMsg);

                        if (st == 0)
                        {
                            // �f�[�^�𔽉f
                            this.SetDataTable(proposeGoodstList);
                            this.Section_ComboEditor.Enabled = false;
                            this.Search_button.Enabled = false;
                            this.Category_ComboEditor.Enabled = false;
                        }
                        else
                        {
                            TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            CT_ASSEMBLYID,						// �A�Z���u��ID�܂��̓N���XID
                            errMsg,			                    // �\�����郁�b�Z�[�W 
                            st,								    // �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                            return;
                        }
                    }

                    // ���oPG�Œ��o�����f�[�^�𔽉f
                    int newCount;
                    int updateCount;
                    Dictionary<int, List<string>> changeList = new Dictionary<int, List<string>>();

                    //�s���s���\��
                    Broadleaf.Windows.Forms.SFCMN00299CA waitForm = new Broadleaf.Windows.Forms.SFCMN00299CA();
                    // �\��������ݒ�
                    waitForm.Title = "�捞��";
                    waitForm.Message = "���݁A���i�f�[�^�̎捞���ł��B";

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        waitForm.Show();

                        // �捞���s
                        st = this.ReflectCSVImportData(form._proposeGoodsList, out newCount, out updateCount, out changeList, out errMsg);

                        if (st == 0)
                        {
                            // �捞����
                            if (changeList.Count > 0)
                            {
                                foreach (int rowIndex in changeList.Keys)
                                {
                                    foreach (string colNm in changeList[rowIndex])
                                    {
                                        this._initFlag = true;
                                        // �ύX�Z���̕����F��ύX
                                        if (this.Goods_Grid.Rows[rowIndex].Cells[colNm].Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox)
                                        {
                                            this.Goods_Grid.Rows[rowIndex].Cells[colNm].Appearance.BackColor = Color.LightPink;
                                        }
                                        else
                                        {
                                            if (colNm == COL_STOCKSTATE && (int)this.Goods_Grid.Rows[rowIndex].Cells[colNm].Value == -1)
                                            {
                                                this.Goods_Grid.Rows[rowIndex].Cells[colNm].Appearance.BackColor = Color.LightPink;
                                            }
                                            else if (colNm == COL_SHOPSALEENDDATE && this.Goods_Grid.Rows[rowIndex].Cells[colNm].Value == DBNull.Value)
                                            {
                                                this.Goods_Grid.Rows[rowIndex].Cells[colNm].Appearance.BackColor = Color.LightPink;
                                            }
                                            else
                                            {
                                                this.Goods_Grid.Rows[rowIndex].Cells[colNm].Appearance.BackColor = Color.LightPink;
                                                this.Goods_Grid.Rows[rowIndex].Cells[colNm].Appearance.ForeColor = Color.Red;
                                            }
                                        }
                                    }
                                }
                            }

                            this.Cursor = Cursors.Default;
                            waitForm.Close();

                            this.UpDateGrid();

                            TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_INFO,	    // �G���[���x��
                            CT_ASSEMBLYID,						// �A�Z���u��ID�܂��̓N���XID
                            "�捞���������܂����B"              // �\�����郁�b�Z�[�W 
                            + Environment.NewLine
                            + "�V�K:"
                            + newCount.ToString() + "��"
                            + Environment.NewLine
                            + "�X�V:"
                            + updateCount.ToString() + "��",
                            st,								    // �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        }
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                        waitForm.Close();
                    }
                }
            }
        }

        /// <summary>
        /// ���z�ꊇ�v�Z
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalcPrice_Button_Click(object sender, EventArgs e)
        {
            // ���i���[�h
            // �����H��̓X�����i�v�Z�@�\
            // �W�����i��80%
            // �̔����i��120%

            // ���i���̔����v�Z�@�\
            // �d��������120%
            // �̔����i��90%
            // �W�����i��70%

            // �[�������͎l�̌ܓ�

            // �����H�ꃂ�[�h
            // �X�����i�̌v�Z�@�\
            // �W�����i��XX%
            // �d��������XX%

            if (this._calcPriceForm == null)
            {
                this._calcPriceForm = new CalcPriceForm(this._bootPara.BootMode);
                this._calcPriceForm.Icon = this.Icon;
                this._calcPriceForm._bootMode = this._bootPara.BootMode;
            }

            DialogResult ret = this._calcPriceForm.ShowCalcPriceForm();
            if (ret == DialogResult.OK)
            {
                this.Goods_Grid.BeginUpdate();

                bool calcSF = false;
                bool calcPM = false;
                // ���z�Čv�Z
                if (!string.IsNullOrEmpty(this._calcPriceForm._originCol_SF) && !string.IsNullOrEmpty(this._calcPriceForm._targetCol_SF) && this._calcPriceForm._percentage_SF != 0)
                {
                    calcSF = true;
                }

                if (!string.IsNullOrEmpty(this._calcPriceForm._originCol_PM) && !string.IsNullOrEmpty(this._calcPriceForm._targetCol_PM) && this._calcPriceForm._percentage_PM != 0)
                {
                    calcPM = true;
                }

                // �����H����z
                // �̔����i���Čv�Z

                for (int i = 0; i < this.Goods_Grid.Rows.Count; i++)
                {
                    UltraGridRow row = this.Goods_Grid.Rows[i];

                    if (calcPM)
                    {
                        // ���z�����ݒ�̏��i�̂�
                        if (this._calcPriceForm._calcDiv && GetCellLong(row.Cells[this._calcPriceForm._targetCol_PM].Value, 0) != 0) continue;
                        long retPrice = this.CalcPrice(GetCellLong(row.Cells[this._calcPriceForm._originCol_PM].Value, 0), this._calcPriceForm._percentage_PM, this._calcPriceForm._fracCd);
                        if (retPrice > 999999999)
                        {
                            retPrice = 999999999;
                        }
                        row.Cells[this._calcPriceForm._targetCol_PM].Value = retPrice;

                        // �s�̑e�����v�Z
                        DataRow targetRow = this.TBODataSet.Tables[TABLE_MAIN].Rows[row.Index];
                        this.CalcGrossProc(ref targetRow);
                    }
                    if (calcSF)
                    {
                        // ���z�����ݒ�̏��i�̂�
                        if (this._calcPriceForm._calcDiv && GetCellLong(row.Cells[this._calcPriceForm._targetCol_SF].Value, 0) != 0) continue;
                        long retPrice = this.CalcPrice(GetCellLong(row.Cells[this._calcPriceForm._originCol_SF].Value, 0), this._calcPriceForm._percentage_SF, this._calcPriceForm._fracCd);
                        if(retPrice > 999999999)
                        {
                            retPrice = 999999999;
                        }
                        row.Cells[this._calcPriceForm._targetCol_SF].Value = retPrice;

                        // �s�̑e�����v�Z
                        DataRow targetRow = this.TBODataSet.Tables[TABLE_MAIN].Rows[row.Index];
                        this.CalcGrossProc(ref targetRow);
                    }
                }

                this.Goods_Grid.EndUpdate();
                this.UpDateGrid();

                TMsgDisp.Show(
                  this,								// �e�E�B���h�E�t�H�[��
                  emErrorLevel.ERR_LEVEL_INFO,	    // �G���[���x��
                  CT_ASSEMBLYID,					// �A�Z���u��ID�܂��̓N���XID
                  "�v�Z���������܂����B",           // �\�����郁�b�Z�[�W 
                  0,								// �X�e�[�^�X�l
                  MessageBoxButtons.OK);			// �\������{�^��
            }
        }


        /// <summary>
        /// ���z�Čv�Z
        /// </summary>
        /// <param name="price">�v�Z�����z</param>
        /// <param name="persentage">����</param>
        /// <param name="fracCd">�[�������敪</param>
        /// <returns></returns>
        private long CalcPrice(long price, int persentage, int fracCd)
        {
            long retPrice = 0;
            double priceDouble = price;
            double Base = 100;
            double rate = persentage / Base;
            double targetPrice = priceDouble * rate;

            retPrice = (long)CalculateConsTax.Fraction(targetPrice, fracCd);
            return retPrice;
        }

        /// <summary>
        /// ��ɑ}��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertUpRow_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // �`��STOP
                this.Goods_Grid.BeginUpdate();

                int index = 0;
                if (this.Goods_Grid.Selected.Rows != null)
                {
                    // �_���폜�s������̂ň�U�t�B���^�[���N���A
                    this.TBODataSet.Tables[TABLE_MAIN].DefaultView.RowFilter = "";

                    foreach (UltraGridRow row in this.Goods_Grid.Selected.Rows)
                    {
                        if (row.Activated)
                        {
                            index = row.Index;
                            break;
                        }
                    }

                    for (int i = 0; i < this.Goods_Grid.Selected.Rows.Count; i++)
                    {
                        DataRow row = this.TBODataSet.Tables[TABLE_MAIN].NewRow();
                        row[COL_DEL] = 0;          // �_���폜�敪
                        row[COL_RELEASE] = true;        // ���J�t���O
                        row[COL_RECOMMEND] = false;    // �I�X�X���t���O
                        row[COL_TIRE_KEY2] = false;
                        row[COL_BATTERY_KEY2] = 1;
                        row[COL_OIL_KEY2] = 1;
                        row[COL_STOCKSTATE] = -1; //TODO

                        // �s�̑e�����v�Z
                        this.CalcGrossProc(ref row);

                        this.TBODataSet.Tables[TABLE_MAIN].Rows.InsertAt(row, index);
                        index++;
                    }

                    UltraGridRow ugRow = this.Goods_Grid.Rows[index];
                    if (ugRow != null)
                    {
                        UltraGridCell cell = ugRow.Cells[COL_RELEASE];
                        this.Goods_Grid.Focus();
                        cell.Row.Cells[COL_RELEASE].Activate();
                        cell.Selected = true;
                        cell.Activate();
                    }
                }
            }
            finally
            {
                StringBuilder filter = new StringBuilder();
                filter.Append(String.Format("{0}={1}", COL_DEL, 0));
                this.TBODataSet.Tables[TABLE_MAIN].DefaultView.RowFilter = filter.ToString();
                this.TBODataSet.Tables[TABLE_MAIN].AcceptChanges();
                this.Goods_Grid.EndUpdate();
                this.UpDateGrid();
            }
        }

        /// <summary>
        /// ���ɑ}��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertDownRow_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = 0;
            if (this.Goods_Grid.Selected.Rows != null)
            {
                foreach (UltraGridRow row in this.Goods_Grid.Selected.Rows)
                {
                    if (row.Activated)
                    {
                        index = row.Index;
                        break;
                    }
                }

                for (int i = 0; i < this.Goods_Grid.Selected.Rows.Count; i++)
                {
                    DataRow row = this.TBODataSet.Tables[TABLE_MAIN].NewRow();
                    row[COL_DEL] = 0;          // �_���폜�敪
                    row[COL_RELEASE] = true;        // ���J�t���O
                    row[COL_RECOMMEND] = false;    // �I�X�X���t���O
                    row[COL_TIRE_KEY2] = false;
                    row[COL_BATTERY_KEY2] = 1;
                    row[COL_OIL_KEY2] = 1;
                    row[COL_STOCKSTATE] = -1; //TODO

                    // �s�̑e�����v�Z
                    this.CalcGrossProc(ref row);

                    index++;
                    this.TBODataSet.Tables[TABLE_MAIN].Rows.InsertAt(row, index);
                }

                UltraGridRow ugRow = this.Goods_Grid.Rows[index];
                if (ugRow != null)
                {
                    UltraGridCell cell = ugRow.Cells[COL_RELEASE];
                    this.Goods_Grid.Focus();
                    cell.Row.Cells[COL_RELEASE].Activate();
                    cell.Selected = true;
                    cell.Activate();
                }

                this.UpDateGrid();

            }
        }

        /// <summary>
        /// ���J�󋵊m�F
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void proposeInfo_toolStripButton_Click(object sender, EventArgs e)
        {
            // ���J��I����ʂ��N��
            ReleaseSelectForm form = new ReleaseSelectForm();
            form.Icon = this.Icon;
            form._categoryID = (long)this.Category_ComboEditor.Value;
            form._categoryName = this.Category_ComboEditor.Text;
            form._enterpriseCode = this._bootPara.EnterpriseCode;
            form._enterpriseName = this._bootPara.EnterpriseName;
            form._sectionCode = this.Section_ComboEditor.Value.ToString();
            form._sectionName = this.Section_ComboEditor.Text;

            // ���݂̋��_����SCM�ڑ�����n��
            if (this._scmSceDic.ContainsKey(form._sectionCode))
            {
                form._scmList = this._scmSceDic[form._sectionCode];
            }
            else
            {
                // �L���Ȍ��J�悪�Ȃ� ���肦�Ȃ�����
                TMsgDisp.Show(
                this,							        // �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_STOPDISP,	    // �G���[���x��
                CT_ASSEMBLYID,					        // �A�Z���u��ID�܂��̓N���XID
                "���J��̎擾�Ɏ��s���܂���",		    // �\�����郁�b�Z�[�W 
                -1,								        // �X�e�[�^�X�l
                MessageBoxButtons.OK);
                return;
            }

            form._mode = 1;
            DialogResult ret = form.ShowReleaseSelectFrom();
        }

        /// <summary>
        /// Goods_Grid_Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goods_Grid_Enter(object sender, EventArgs e)
        {
            if (this.Goods_Grid.ActiveCell != null)
            {
                this.Goods_Grid.ActiveCell.Selected = true;
                this.Goods_Grid.ActiveCell.Activate();
                this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
            }
            else
            {
                if (this.Goods_Grid.Rows.Count > 0)
                {
                    this.Goods_Grid.Rows[0].Cells[COL_RELEASE].Selected = true;
                    this.Goods_Grid.Rows[0].Cells[COL_RELEASE].Activate();
                    this.Goods_Grid.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
        }

        /// <summary>
        /// �t������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendRepairSet_Button_Click(object sender, EventArgs e)
        {
            // �X�V�`�F�b�N
            if (this.CheckUpDate())
            {
                AttendRepairSetForm form = new AttendRepairSetForm();
                form.Icon = this.Icon;
                form._categoryList = this._categoryList;
                form.ShowDialog(this._bootPara.EnterpriseCode, this._bootPara.BootMode);

                if (form._saveDiv)
                {
                    // �t�������ēǍ�
                    this.SetAttendRepairSet();

                    // �ēǍ�
                    if (this.Category_ComboEditor.Enabled == false)
                    {
                        this.Search_button_Click(this, new EventArgs());
                    }
                }
            }
        }

        #region InnerClass

        /// <summary>
        /// �O���b�h�̃w�b�_�Ƀ`�F�b�N�{�b�N�X��\������ׂ̃t�B���^�[�N���X
        /// </summary>
        public class TBOCustomFilter : Infragistics.Win.IUIElementCreationFilter
        {
            #region �C�x���g
            /// <summary>
            /// �J�����w�b�h�̃`�F�b�N�{�b�N�X�N���b�N�C�x���g
            /// </summary>
            /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
            /// <param name="e">�C�x���g�p�����[�^</param>
            /// <remarks>
            /// <br>Note�@�@�@ : �J�����w�b�h�̃`�F�b�N�{�b�N�X���N���b�N���ꂽ���ɁA�������܂��B</br>
            /// </remarks>
            public delegate void HeaderCheckBoxClickedHandler(object sender, HeaderCheckBoxEventArgs e);

            /// <summary>
            /// �J�����w�b�h�̃`�F�b�N�{�b�N�X�N���b�N�C�x���g
            /// </summary>
            public event HeaderCheckBoxClickedHandler CheckChanged;

            /// <summary>
            /// Boolean�^�̃J�����w�b�h�Ƀ`�F�b�N�{�b�N�X��\�������N���X�R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note	   : Boolean�^�̃J�����w�b�h�Ƀ`�F�b�N�{�b�N�X��\�������N���X�C���X�^���X�������������s���܂��B�B</br>
            /// </remarks>
            public TBOCustomFilter()
            {
                CheckChanged += new HeaderCheckBoxClickedHandler(CheckBoxOnHeader_CreationFilter_HeaderCheckBoxClicked);
            }

            /// <summary>
            /// �J�����w�b�h�̃`�F�b�N�{�b�N�X�̃N���b�N �C�x���g
            /// </summary>
            /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
            /// <param name="e">�C�x���g�p�����[�^</param>
            /// <remarks>
            /// <br>Note�@�@�@ : �J�����w�b�h�̃`�F�b�N�{�b�N�X���N���b�N���ꂽ���ɁA�������܂��B</br>
            /// </remarks>
            private void CheckBoxOnHeader_CreationFilter_HeaderCheckBoxClicked(object sender, TBOCustomFilter.HeaderCheckBoxEventArgs e)
            {
                // �J�����^�C�v // ���J��̂�
                if (e.Header.Column.DataType == typeof(bool) && e.Header.Column.Key == COL_RELEASE)
                {
                    foreach (UltraGridRow aRow in e.Rows)
                    {
                        aRow.Cells[e.Header.Column.Index].Value = (e.CurrentCheckState == CheckState.Checked);
                    }
                }
            }

            /// <summary>
            /// �J�����w�b�h�̃`�F�b�N�{�b�N�X�̃N���b�N �C�x���g
            /// </summary>
            /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
            /// <param name="e">�C�x���g�p�����[�^</param>
            /// <remarks>
            /// <br>Note�@�@�@ : �J�����w�b�h�̃`�F�b�N�{�b�N�X���N���b�N���ꂽ���ɁA�������܂��B</br>
            /// </remarks>
            private void CheckBoxUIElement_ElementClick(Object sender, Infragistics.Win.UIElementEventArgs e)
            {
                // �N���b�N���ꂽ�`�F�b�N�{�b�N�XUI�v�f
                Infragistics.Win.CheckBoxUIElement aCheckBoxUIElement = (Infragistics.Win.CheckBoxUIElement)e.Element;

                // �J�����w�b�h
                Infragistics.Win.UltraWinGrid.ColumnHeader aColumnHeader = (Infragistics.Win.UltraWinGrid.ColumnHeader)aCheckBoxUIElement.GetAncestor(typeof(HeaderUIElement)).GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

                // �`�F�b�N��Ԑݒ�
                aColumnHeader.Tag = aCheckBoxUIElement.CheckState;

                // �w�b�hUI�v�f
                HeaderUIElement aHeaderUIElement = aCheckBoxUIElement.GetAncestor(typeof(HeaderUIElement)) as HeaderUIElement;

                // �s�W��
                RowsCollection hRows = aHeaderUIElement.GetContext(typeof(RowsCollection)) as RowsCollection;

                // �J�����w�b�h�̃`�F�b�N�{�b�N�X�N���b�N�C�x���g
                if (CheckChanged != null)
                    CheckChanged(this, new HeaderCheckBoxEventArgs(aColumnHeader, aCheckBoxUIElement.CheckState, hRows));
            }
            #endregion

            #region IUIElementCreationFilter �����o
            /// <summary>
            /// BeforeCreateChildElements
            /// </summary>
            /// <param name="parent">UIElement</param>
            public bool BeforeCreateChildElements(Infragistics.Win.UIElement parent)
            {
                // �����Ȃ�
                return false;
            }

            /// <summary>
            /// BeforeCreateChildElements
            /// </summary>
            /// <param name="parent">UIElement</param>
            /// <returns>bool</returns>
            public void AfterCreateChildElements(Infragistics.Win.UIElement parent)
            {
                // �O���[�v�w�b�_�E�J�����w�b�_
                if (parent is HeaderUIElement)
                {
                    Infragistics.Win.UltraWinGrid.HeaderBase aHeader = ((HeaderUIElement)parent).Header;

                    // �J�����^�C�v�@���@bool �����J��̂�
                    if (aHeader.Column.DataType == typeof(bool) && aHeader.Column.Key == COL_RELEASE)
                    {
                        Infragistics.Win.TextUIElement aTextUIElement;
                        Infragistics.Win.CheckBoxUIElement aCheckBoxUIElement = (Infragistics.Win.CheckBoxUIElement)parent.GetDescendant(typeof(Infragistics.Win.CheckBoxUIElement));

                        if (aCheckBoxUIElement == null)
                        {
                            aCheckBoxUIElement = new Infragistics.Win.CheckBoxUIElement(parent);
                        }

                        // XP �e�[�}���g�p���܂��B
                        if (aCheckBoxUIElement.Appearance == null)
                            aCheckBoxUIElement.Appearance = new Infragistics.Win.Appearance();
                        aCheckBoxUIElement.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Opaque;

                        // �e�L�X�g�擾
                        aTextUIElement = (Infragistics.Win.TextUIElement)parent.GetDescendant(typeof(Infragistics.Win.TextUIElement));

                        if (aTextUIElement == null)
                            return;

                        // �J�����w�b�_
                        Infragistics.Win.UltraWinGrid.ColumnHeader aColumnHeader =
                            (Infragistics.Win.UltraWinGrid.ColumnHeader)aCheckBoxUIElement.GetAncestor(typeof(HeaderUIElement))
                            .GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

                        // �J�����`�F�b�N�{�b�N�X�̏�����
                        if (aColumnHeader.Tag == null)
                            aColumnHeader.Tag = CheckState.Unchecked;
                        else
                            aCheckBoxUIElement.CheckState = (CheckState)aColumnHeader.Tag;

                        // �J�����w�b�h�̃`�F�b�N�{�b�N�X�̃N���b�N�C�x���g
                        aCheckBoxUIElement.ElementClick += new Infragistics.Win.UIElementEventHandler(CheckBoxUIElement_ElementClick);

                        parent.ChildElements.Add(aCheckBoxUIElement);

                        // �`�F�b�N�{�b�N�X�Ɨ�w�b�_�[�̍��[�̊Ԃ� 3�s�N�Z���̗]����ݒ肵�܂��B
                        // �܂��A�`�F�b�N�{�b�N�X����w�b�_�[�̒��i�ɕ\�������悤�ɂ��܂��B
                        aCheckBoxUIElement.Rect = new Rectangle(
                        parent.Rect.X + 5,
                        parent.Rect.Y + ((parent.Rect.Height - aCheckBoxUIElement.CheckSize.Height) / 2),
                        aCheckBoxUIElement.CheckSize.Width,
                        aCheckBoxUIElement.CheckSize.Height);

                        // �e�L�X�g�ʒu����
                        aTextUIElement.Rect = new Rectangle(
                            aCheckBoxUIElement.Rect.Right + 3,
                            aTextUIElement.Rect.Y,
                            parent.Rect.Width - (aCheckBoxUIElement.Rect.Right - parent.Rect.X),
                            aTextUIElement.Rect.Height);
                    }
                    // �J�����^�C�v�@�����@bool
                    else
                    {
                        Infragistics.Win.CheckBoxUIElement aCheckBoxUIElement = (Infragistics.Win.CheckBoxUIElement)parent.GetDescendant(typeof(Infragistics.Win.CheckBoxUIElement));

                        if (aCheckBoxUIElement != null)
                        {
                            parent.ChildElements.Remove(aCheckBoxUIElement);
                            aCheckBoxUIElement.Dispose();
                        }
                    }
                }
            }

            #endregion

            #region HeaderCheckBoxEventArgs
            /// <summary>
            /// �C�x���g�p�����[�^
            /// </summary>
            /// <remarks>
            /// <br>Note�@�@�@ : �C�x���g�p�����[�^�ł��B</br>
            /// </remarks>
            public class HeaderCheckBoxEventArgs : EventArgs
            {
                // �J�����w�b�h
                private Infragistics.Win.UltraWinGrid.ColumnHeader mvarColumnHeader;
                // �`�F�b�N���
                private CheckState mvarCheckState;
                // �s�W��
                private RowsCollection mvarRowsCollection;

                /// <summary>
                /// �C�x���g�p�����[�^�N���X�R���X�g���N�^
                /// </summary>
                /// <param name="hdrColumnHeader">�J�����w�b�h</param>
                /// <param name="chkCheckState">�`�F�b�N���</param>
                /// <param name="Rows">�s�W��</param>
                public HeaderCheckBoxEventArgs(Infragistics.Win.UltraWinGrid.ColumnHeader hdrColumnHeader, CheckState chkCheckState, RowsCollection Rows)
                {
                    mvarColumnHeader = hdrColumnHeader;
                    mvarCheckState = chkCheckState;
                    mvarRowsCollection = Rows;
                }

                /// <summary>
                /// �s�W��
                /// </summary>
                public RowsCollection Rows
                {
                    get
                    {
                        return mvarRowsCollection;
                    }
                }

                /// <summary>
                /// �J�����w�b�h
                /// </summary>
                public Infragistics.Win.UltraWinGrid.ColumnHeader Header
                {
                    get
                    {
                        return mvarColumnHeader;
                    }
                }

                /// <summary>
                /// �`�F�b�N���
                /// </summary>
                public CheckState CurrentCheckState
                {
                    get
                    {
                        return mvarCheckState;
                    }
                    set
                    {
                        mvarCheckState = value;
                    }
                }
            }
            #endregion
        }   

        #endregion
    }
}