using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.Misc;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���p�o�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���p�o�^�t�H�[���̐ݒ���s���܂��B</br>
    /// <br>Programmer	: 30414 �E�@�K�j</br>
    /// <br>Date		: 2008/11/28</br>
    /// </remarks>
    public partial class PMKEN09110UB : Form
    {
        #region �� Const

        // �v���O����ID
        private const string ASSEMBLY_ID = "PMKEN09110U";
        
        #endregion �� Const


        #region �� Private Members

        // ��ƃR�[�h
        private string _enterpriseCode;
        // ��������
        private Int32 _equipGanreCode;
        // ������
        private String _equipGanreName;

        private List<TBOSearchU> _allTBOSearchUList;

        private TBOSearchUAcs _tboSearchAcs;

        private string _prevEquipNameSt;
        private string _prevEquipNameEd;

        // ��ʃf�U�C���ύX�N���X
        private ControlScreenSkin _controlScreenSkin;

        #endregion �� Private Members


        #region �� Constructor

        /// <summary>
        /// ���p�o�^�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���p�o�^�t�H�[���N���X�̃C���X�^���X���쐬���܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date		: 2008/11/28</br>
        /// </remarks>
        public PMKEN09110UB()
        {
            InitializeComponent();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._tboSearchAcs = new TBOSearchUAcs();

            this._controlScreenSkin = new ControlScreenSkin();

            // �������ސݒ�
            this.tComboEditor_EquipGenreCode.Items.Clear();
            this.tComboEditor_EquipGenreCode.Items.Add(1001, "�o�b�e���[");
            this.tComboEditor_EquipGenreCode.Items.Add(1005, "�^�C��");
            this.tComboEditor_EquipGenreCode.Items.Add(1010, "�I�C��");
        }

        #endregion �� Constructor


        #region �� Public Property

        /// <summary>�������ރv���p�e�B</summary>
        /// <value>���p�o�^��ʂ̌Ăь����瑕�����ނ��擾���܂��B</value>
        public Int32 EquipGanreCode
        {
            get
            {
                return this._equipGanreCode;
            }
            set
            {
                this._equipGanreCode = value;
            }
        }

        /// <summary>�������v���p�e�B</summary>
        /// <value>���p�o�^��ʂ̌Ăь����瑕�������擾���܂��B</value>
        public String EquipGanreName
        {
            get
            {
                return this._equipGanreName;
            }
            set
            {
                this._equipGanreName = value;
            }
        }

        /// <summary>TBO�������X�g(���[�U�[�o�^)�v���p�e�B</summary>
        /// <value>���p�o�^��ʂ̌Ăь�����TBO�������X�g(���[�U�[�o�^)���擾���܂��B</value>
        public List<TBOSearchU> AllTBOSearchUList
        {
            set
            {
                this._allTBOSearchUList = value;
            }
        }
        #endregion �� Public Property


        #region �� Private Methods

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ����N���A���܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date		: 2008/11/28</br>
        /// </remarks>
        private void ClearScreen()
        {
            this.tComboEditor_EquipGenreCode.Value = 0;
            this.tEdit_EquipGenreNameOrigin.Clear();
            this.tEdit_EquipGenreNameAfter.Clear();

            this._prevEquipNameSt = "";
            this._prevEquipNameEd = "";
        }

        /// <summary>
        /// �R���g���[���T�C�Y�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: �R���g���[���T�C�Y��ݒ肵�܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date		: 2008/11/28</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tComboEditor_EquipGenreCode.Size = new Size(144, 24);
            this.tEdit_EquipGenreNameOrigin.Size = new Size(496, 24);
            this.tEdit_EquipGenreNameAfter.Size = new Size(496, 24);
        }

        /// <summary>
        /// �������K�C�h�\������
        /// </summary>
        /// <param name="equipName">������</param>
        /// <param name="equipGanreCode">��������</param>
        /// <param name="searchName">������(�B�������Ή�)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �������K�C�h��\�����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private int ShowEquipNameGuide(out string equipName, int equipGanreCode, string searchName)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            equipName = "";

            try
            {
                this.Cursor = Cursors.WaitCursor;

                status = this._tboSearchAcs.ExecuteGuid(this._enterpriseCode, equipGanreCode, searchName, out equipName);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return (status);
        }

        /// <summary>
        /// ��ʏ����̓`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private bool CheckScreenInput()
        {
            string errMsg = "";

            try
            {
                if (this.tComboEditor_EquipGenreCode.Value == null)
                {
                    errMsg = "�������ނ�I�����Ă��������B";
                    this.tComboEditor_EquipGenreCode.Focus();
                    return (false);
                }

                if (this.tEdit_EquipGenreNameOrigin.DataText.Trim() == "")
                {
                    errMsg = "���p���̑���������͂��Ă��������B";
                    this.tEdit_EquipGenreNameOrigin.Focus();
                    return (false);
                }

                int equipGanreCode = (int)this.tComboEditor_EquipGenreCode.Value;
                string equipName = this.tEdit_EquipGenreNameOrigin.DataText.Trim();

                List<GoodsUnitData> goodsUnitDataList;
                int status = this._tboSearchAcs.Search(out goodsUnitDataList,
                                                       this._enterpriseCode,
                                                       LoginInfoAcquisition.Employee.BelongSectionCode,
                                                       equipGanreCode,
                                                       equipName);
                if ((status != 0) || (goodsUnitDataList == null) || (goodsUnitDataList.Count == 0))
                {
                    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                    this.tEdit_EquipGenreNameOrigin.Focus();
                    return (false);
                }

                if (this.tEdit_EquipGenreNameAfter.DataText.Trim() == "")
                {
                    errMsg = "���p��̑���������͂��Ă��������B";
                    this.tEdit_EquipGenreNameAfter.Focus();
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private int SaveProc()
        {
            //--------------------------------------------------
            // ���̓`�F�b�N
            //--------------------------------------------------
            bool bStatus = CheckScreenInput();
            if (!bStatus)
            {
                return (-1);
            }

            int equipGanreCode = (int)this.tComboEditor_EquipGenreCode.Value;
            string equipNameOrigin = this.tEdit_EquipGenreNameOrigin.DataText.Trim();
            string equipNameAfter = this.tEdit_EquipGenreNameAfter.DataText.Trim();

            //--------------------------------------------------
            // ���p��̏��i�A���f�[�^���X�g�擾
            //--------------------------------------------------
            List<GoodsUnitData> goodsUnitDataListAfter;
            int status = this._tboSearchAcs.Search(out goodsUnitDataListAfter,
                                                   this._enterpriseCode,
                                                   LoginInfoAcquisition.Employee.BelongSectionCode,
                                                   equipGanreCode,
                                                   equipNameAfter);

            if ((status == 0) && (goodsUnitDataListAfter.Count > 0))
            {
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                                  "�o�^��ɖ��ׂ����݂��܂��B" + "\r\n" + "\r\n" + "�o�^���Ă���낵���ł����H",
                                                  0,
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxDefaultButton.Button1);
                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            break;
                        }
                    case DialogResult.No:
                        {
                            this.DialogResult = DialogResult.Cancel;
                            return (1);
                        }
                }
            }

            //--------------------------------------------------
            // ���p���̏��i�A���f�[�^���X�g�擾(���[�U�[�A��)
            //--------------------------------------------------
            List<GoodsUnitData> goodsUnitDataListOrigin;
            status = this._tboSearchAcs.Search(out goodsUnitDataListOrigin,
                                                   this._enterpriseCode,
                                                   LoginInfoAcquisition.Employee.BelongSectionCode,
                                                   equipGanreCode,
                                                   equipNameOrigin);

            if ((status != 0) || (goodsUnitDataListOrigin == null) || (goodsUnitDataListOrigin.Count == 0))
            {
                this.DialogResult = DialogResult.Cancel;
                return (1);
            }

            //--------------------------------------------------
            // TBO�����}�X�^���X�g�擾(���[�U�[�o�^��)
            //--------------------------------------------------
            // ���p��
            List<TBOSearchU> tboSearchUListAfter = FindUserTBOSearchUList(equipGanreCode, equipNameAfter);

            // ���p��
            List<TBOSearchU> tboSearchUListOrigin = FindUserTBOSearchUList(equipGanreCode, equipNameOrigin);

            //--------------------------------------------------
            // TBO�����}�X�^���X�g�擾(�񋟕�)
            //--------------------------------------------------
            // ���p��
            List<TBOSearchU> offerTboSearchUListAfter = new List<TBOSearchU>();
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataListAfter)
            {
                int index = tboSearchUListAfter.FindIndex(delegate(TBOSearchU target)
                {
                    if ((target.JoinDestMakerCd == goodsUnitData.GoodsMakerCd) &&
                        (target.JoinDestPartsNo.Trim() == goodsUnitData.GoodsNo.Trim()))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                if (index < 0)
                {
                    TBOSearchU newTBOSearchU = new TBOSearchU();
                    newTBOSearchU.EnterpriseCode = this._enterpriseCode;
                    newTBOSearchU.BLGoodsCode = goodsUnitData.BLGoodsCode;
                    newTBOSearchU.EquipGenreCode = equipGanreCode;
                    newTBOSearchU.EquipName = equipNameAfter;
                    newTBOSearchU.CarInfoJoinDispOrder = goodsUnitData.DisplayOrder;
                    newTBOSearchU.JoinDestMakerCd = goodsUnitData.GoodsMakerCd;
                    newTBOSearchU.JoinDestMakerName = goodsUnitData.MakerName;
                    newTBOSearchU.JoinDestPartsNo = goodsUnitData.GoodsNo;
                    newTBOSearchU.JoinDestGoodsName = goodsUnitData.GoodsName;
                    newTBOSearchU.JoinQty = goodsUnitData.JoinQty;
                    newTBOSearchU.EquipSpecialNote = goodsUnitData.JoinSpecialNote;

                    offerTboSearchUListAfter.Add(newTBOSearchU);
                }
            }

            // ���p��
            List<TBOSearchU> offerTboSearchUListOrigin = new List<TBOSearchU>();
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataListOrigin)
            {
                int index = tboSearchUListOrigin.FindIndex(delegate(TBOSearchU target)
                {
                    if ((target.JoinDestMakerCd == goodsUnitData.GoodsMakerCd) &&
                        (target.JoinDestPartsNo.Trim() == goodsUnitData.GoodsNo.Trim()))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                if (index < 0)
                {
                    TBOSearchU newTBOSearchU = new TBOSearchU();
                    newTBOSearchU.EnterpriseCode = this._enterpriseCode;
                    newTBOSearchU.BLGoodsCode = goodsUnitData.BLGoodsCode;
                    newTBOSearchU.EquipGenreCode = equipGanreCode;
                    newTBOSearchU.EquipName = equipNameAfter;
                    newTBOSearchU.CarInfoJoinDispOrder = goodsUnitData.DisplayOrder;
                    newTBOSearchU.JoinDestMakerCd = goodsUnitData.GoodsMakerCd;
                    newTBOSearchU.JoinDestMakerName = goodsUnitData.MakerName;
                    newTBOSearchU.JoinDestPartsNo = goodsUnitData.GoodsNo;
                    newTBOSearchU.JoinDestGoodsName = goodsUnitData.GoodsName;
                    newTBOSearchU.JoinQty = goodsUnitData.JoinQty;
                    newTBOSearchU.EquipSpecialNote = goodsUnitData.JoinSpecialNote;

                    offerTboSearchUListOrigin.Add(newTBOSearchU);
                }
            }

            //--------------------------------------------------
            // �ۑ����X�g�쐬
            //--------------------------------------------------
            List<TBOSearchU> saveTBOList = new List<TBOSearchU>();

            // ���p���TBO�}�X�^���X�g(���[�U�[)��ۑ����X�g�ɒǉ�
            foreach (TBOSearchU tboSearchU in tboSearchUListAfter)
            {
                saveTBOList.Add(tboSearchU.Clone());
            }

            // ���p���TBO�}�X�^���X�g(��)��ۑ����X�g�ɒǉ�
            foreach (TBOSearchU tboSearchU in offerTboSearchUListAfter)
            {
                saveTBOList.Add(tboSearchU.Clone());
            }

            // ���p����TBO�}�X�^���X�g(���[�U�[)��ۑ����X�g�ɒǉ��E�㏑��
            foreach (TBOSearchU tboSearchU in tboSearchUListOrigin)
            {
                int index = saveTBOList.FindIndex(delegate(TBOSearchU target)
                {
                    if ((target.JoinDestMakerCd == tboSearchU.JoinDestMakerCd) &&
                        (target.JoinDestPartsNo.Trim() == tboSearchU.JoinDestPartsNo.Trim()))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                if (index >= 0)
                {
                    // �㏑��
                    saveTBOList[index].CarInfoJoinDispOrder = tboSearchU.CarInfoJoinDispOrder;
                    saveTBOList[index].JoinQty = tboSearchU.JoinQty;
                    saveTBOList[index].EquipSpecialNote = tboSearchU.EquipSpecialNote;
                }
                else
                {
                    // �V�K�ǉ�
                    tboSearchU.EquipName = equipNameAfter;
                    saveTBOList.Add(tboSearchU.Clone());
                }
            }

            // ���p����TBO�}�X�^���X�g(��)��ۑ����X�g�ɒǉ��E�㏑��
            foreach (TBOSearchU tboSearchU in offerTboSearchUListOrigin)
            {
                int index = saveTBOList.FindIndex(delegate(TBOSearchU target)
                {
                    if ((target.JoinDestMakerCd == tboSearchU.JoinDestMakerCd) &&
                        (target.JoinDestPartsNo.Trim() == tboSearchU.JoinDestPartsNo.Trim()))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                if (index >= 0)
                {
                    // �㏑��
                    saveTBOList[index].CarInfoJoinDispOrder = tboSearchU.CarInfoJoinDispOrder;
                    saveTBOList[index].JoinQty = tboSearchU.JoinQty;
                    saveTBOList[index].EquipSpecialNote = tboSearchU.EquipSpecialNote;
                }
                else
                {
                    // �V�K�ǉ�
                    tboSearchU.EquipName = equipNameAfter;
                    saveTBOList.Add(tboSearchU.Clone());
                }
            }

            //--------------------------------------------------
            // ���i���݃`�F�b�N
            //--------------------------------------------------
            ArrayList saveGoodsList = new ArrayList();
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataListOrigin)
            {
                // ���i�}�X�^�ɖ��o�^�̏ꍇ
                if (goodsUnitData.OfferKubun >= 3)
                {
                    goodsUnitData.OfferDate = DateTime.MinValue;
                    if (goodsUnitData.GoodsPriceList != null)
                    {
                        foreach (GoodsPrice price in goodsUnitData.GoodsPriceList)
                        {
                            price.OfferDate = DateTime.MinValue;
                        }
                    }

                    saveGoodsList.Add(goodsUnitData.Clone());
                }
            }

            // �ۑ����X�g��ArrayList�ɕϊ�
            ArrayList saveList = new ArrayList();
            foreach (TBOSearchU tboSearchU in saveTBOList)
            {
                saveList.Add(tboSearchU.Clone());
            }

            // �ۑ�����
            status = this._tboSearchAcs.WriteRelation(saveList, saveGoodsList);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �o�^�����_�C�A���O�\��
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);
                        this.DialogResult = DialogResult.OK;
                        this._equipGanreCode = equipGanreCode;
                        this._equipGanreName = equipNameAfter;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        this.DialogResult = DialogResult.Cancel;
                        break;
                    }
                default:
                    {
                        // �o�^���s
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "SaveProc",
                                       "�o�^�Ɏ��s���܂����B",
                                       status,
                                       MessageBoxButtons.OK);
                        this.DialogResult = DialogResult.Cancel;
                        break;
                    }
            }

            return (status);
        }

        /// <summary>
        /// TBO�����}�X�^���X�g�擾����(���[�U�[)
        /// </summary>
        /// <param name="equipGanreCode">��������</param>
        /// <param name="equipName">������</param>
        /// <returns>TBO�����}�X�^���X�g(���[�U�[)</returns>
        /// <remarks>
        /// <br>Note       : TBO�����}�X�^���X�g(���[�U�[)���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private List<TBOSearchU> FindUserTBOSearchUList(int equipGanreCode, string equipName)
        {
            // ���[�U�[�f�[�^�擾
            List<TBOSearchU> userTBOSearchUList = this._allTBOSearchUList.FindAll(delegate(TBOSearchU target)
            {
                if ((target.EquipGenreCode == equipGanreCode) && (target.EquipName.Trim() == equipName.Trim()))
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });

            if (userTBOSearchUList == null)
            {
                userTBOSearchUList = new List<TBOSearchU>();
            }

            return userTBOSearchUList;
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                       "ExclusiveTransaction",
                                       "���ɑ��[�����X�V����Ă��܂��B",
                                       status,
                                       MessageBoxButtons.OK);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                       "ExclusiveTransaction",
                                       "���ɑ��[�����폜����Ă��܂��B",
                                       status,
                                       MessageBoxButtons.OK);
                        break;
                    }
            }
        }

        #region ���b�Z�[�W�{�b�N�X�\��
        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <param name="defaultButton">�����\���{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // �e�E�B���h�E�t�H�[��
                                         errLevel,                          // �G���[���x��
                                         ASSEMBLY_ID,                        // �A�Z���u��ID
                                         message,                           // �\�����郁�b�Z�[�W
                                         status,                            // �X�e�[�^�X�l
                                         msgButton,                         // �\������{�^��
                                         defaultButton);                    // �����\���{�^��
            return dialogResult;
        }

        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="methodName">��������</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/28</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // �e�E�B���h�E�t�H�[��
                                         errLevel,			                // �G���[���x��
                                         this.Name,						    // �v���O��������
                                         ASSEMBLY_ID, 		  �@�@		    // �A�Z���u��ID
                                         methodName,						// ��������
                                         "",					            // �I�y���[�V����
                                         message,	                        // �\�����郁�b�Z�[�W
                                         status,							// �X�e�[�^�X�l
                                         this._tboSearchAcs,	            // �G���[�����������I�u�W�F�N�g
                                         msgButton,         			  	// �\������{�^��
                                         MessageBoxDefaultButton.Button1);	// �����\���{�^��

            return dialogResult;
        }
        #endregion ���b�Z�[�W�{�b�N�X�\��

        #endregion �� Private Methods


        #region �� Control Events

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�������[�h�������ɔ������܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date		: 2008/11/28</br>
        /// </remarks>
        private void PMKEN09110UB_Load(object sender, EventArgs e)
        {
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            // �R���g���[���T�C�Y�ݒ�
            SetControlSize();

            // �A�C�R���ݒ�
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.Ok_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.SAVE];
            this.Cancel_Button.Appearance.Image = imageList24.Images[(int)Size24_Index.CLOSE];
            this.EquipGenreGuideOrign_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.EquipGenreGuideAfter_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // ��ʏ�����
            ClearScreen();

            // �������ށE��������ݒ�
            this.tComboEditor_EquipGenreCode.Value = this._equipGanreCode;
            this.tEdit_EquipGenreNameOrigin.DataText = this._equipGanreName.Trim();
            this._prevEquipNameSt = this._equipGanreName.Trim();

            // �t�H�[�J�X�ݒ�
            this.tComboEditor_EquipGenreCode.Focus();
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �������K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date		: 2008/11/28</br>
        /// </remarks>
        private void EquipGenreGuide_Button_Click(object sender, EventArgs e)
        {
            UltraButton uButton = (UltraButton)sender;

            string equipName;
            int equipGanreCode = (int)this.tComboEditor_EquipGenreCode.Value;

            int status = ShowEquipNameGuide(out equipName, equipGanreCode, "*");
            if (status == 0)
            {
                // �������ݒ�
                if (uButton.Name == "EquipGenreGuideOrign_Button")
                {
                    // ���p��
                    this.tEdit_EquipGenreNameOrigin.DataText = equipName.Trim();
                    this._prevEquipNameSt = equipName.Trim();
                }
                else
                {
                    // ���p��
                    this.tEdit_EquipGenreNameAfter.DataText = equipName.Trim();
                    this._prevEquipNameEd = equipName.Trim();
                }
            }
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �ۑ��{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date		: 2008/11/28</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            int status = SaveProc();

            // ���̓G���[�̏ꍇ
            if (status == -1)
            {
                return;
            }

            this.Close();
        }

        /// <summary>
        /// Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: ����{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date		: 2008/11/28</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�J�X���ړ��������ɔ������܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date		: 2008/11/28</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // ������(�J�n)
                case "tEdit_EquipGenreNameOrigin":
                    {
                        string equipName = this.tEdit_EquipGenreNameOrigin.DataText.Trim();

                        if (equipName != "")
                        {
                            if (equipName != this._prevEquipNameSt.Trim())
                            {
                                // �������ރR�[�h�擾
                                int equipGanreCode = (int)this.tComboEditor_EquipGenreCode.Value;

                                // �B������
                                if (equipName.Substring(equipName.Length - 1) == "*")
                                {
                                    string retName;

                                    // �������ރK�C�h�\��
                                    int status = ShowEquipNameGuide(out retName, equipGanreCode, equipName);
                                    if (status == 0)
                                    {
                                        this.tEdit_EquipGenreNameOrigin.DataText = retName.Trim();
                                        this._prevEquipNameSt = retName.Trim();
                                    }
                                }
                                else
                                {
                                    this._prevEquipNameSt = equipName;
                                }
                            }
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (equipName != "")
                                {
                                    e.NextCtrl = this.tEdit_EquipGenreNameAfter;
                                }
                            }
                        }
                        break;
                    }
                // ������(�J�n)
                case "tEdit_EquipGenreNameAfter":
                    {
                        string equipName = this.tEdit_EquipGenreNameAfter.DataText.Trim();

                        if (equipName != "")
                        {
                            if (equipName != this._prevEquipNameEd.Trim())
                            {
                                // �������ރR�[�h�擾
                                int equipGanreCode = (int)this.tComboEditor_EquipGenreCode.Value;

                                // �B������
                                if (equipName.Substring(equipName.Length - 1) == "*")
                                {
                                    string retName;

                                    // �������ރK�C�h�\��
                                    int status = ShowEquipNameGuide(out retName, equipGanreCode, equipName);
                                    if (status == 0)
                                    {
                                        this.tEdit_EquipGenreNameAfter.DataText = retName.Trim();
                                        this._prevEquipNameEd = retName.Trim();
                                    }
                                }
                                else
                                {
                                    this._prevEquipNameEd = equipName;
                                }
                            }
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                if (equipName != "")
                                {
                                    e.NextCtrl = this.Ok_Button;
                                }
                            }
                        }
                        break;
                    }
            }
        }
        #endregion �� Control Events
    }
}