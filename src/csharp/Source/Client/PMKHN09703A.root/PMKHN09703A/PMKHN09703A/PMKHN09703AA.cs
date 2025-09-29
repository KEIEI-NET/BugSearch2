//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����񓚕i�ڐݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �����񓚕i�ڐݒ�}�X�^�̑�����s���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g�� �F��
// �� �� ��  2012/10/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g���@�F��
// �� �� ��  2012/11/13  �C�����e : 11/14�z�M �V�X�e���e�X�g��Q��18,19�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g���@�F��
// �� �� ��  2012/11/16  �C�����e : 12/12�z�M �V�X�e���e�X�g��Q��36�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 �O�� �L��
// �� �� ��  2012/11/22  �C�����e : 2012/12/12�z�M�\��V�X�e���e�X�g��Q��58�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g���@�F��
// �� �� ��  2012/11/22  �C�����e : 2012/12/12�z�M�\��V�X�e���e�X�g��Q��77�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g���@�F��
// �� �� ��  2013/11/22  �C�����e : VSS[019] Redmine#677�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11170187-00 �쐬�S�� : �c����
// �� �� ��  2015/10/19  �C�����e : Redmine#47535
//                                  �������R�[�h�̗D�揇�ʁ��Q && �V�K���R�[�h�̗D�揇�ʁ��������R�[�h�̗D�揇�ʂ̏ꍇ�o�^�G���[�̉���
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����񓚕i�ڐݒ�}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����񓚕i�ڐݒ�}�X�^�̃A�N�Z�X������s���܂��B</br>
    /// <br></br>
    /// <br>UpdateNote : 2015/10/19 �c���� </br>
    /// <br>�Ǘ��ԍ�   : 11170187-00 Redmine#47535</br>
    /// <br>           : �������R�[�h�̗D�揇�ʁ��Q && �V�K���R�[�h�̗D�揇�ʁ��������R�[�h�̗D�揇�ʂ̏ꍇ�o�^�G���[�̉���</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class AutoAnsItemStAcs
    {
        #region public const
        //----------------------------------------
        // �����񓚕i�ڐݒ�}�X�^�萔��`
        //----------------------------------------
        /// <summary>�쐬����</summary>
        public const string ct_COL_CREATEDATETIME = "CreateDateTime";
        /// <summary>�X�V����</summary>
        public const string ct_COL_UPDATEDATETIME = "UpdateDateTime";
        /// <summary>��ƃR�[�h</summary>
        public const string ct_COL_ENTERPRISECODE = "EnterpriseCode";
        /// <summary>GUID</summary>
        public const string ct_COL_FILEHEADERGUID = "FileHeaderGuid";
        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        public const string ct_COL_UPDEMPLOYEECODE = "UpdEmployeeCode";
        /// <summary>�X�V�A�Z���u��ID1</summary>
        public const string ct_COL_UPDASSEMBLYID1 = "UpdAssemblyId1";
        /// <summary>�X�V�A�Z���u��ID2</summary>
        public const string ct_COL_UPDASSEMBLYID2 = "UpdAssemblyId2";
        /// <summary>�_���폜�敪</summary>
        public const string ct_COL_LOGICALDELETECODE = "LogicalDeleteCode";
        /// <summary>���_�R�[�h</summary>
        public const string ct_COL_SECTIONCODE = "SectionCode";
        /// <summary>���Ӑ�R�[�h</summary>
        public const string ct_COL_CUSTOMERCODE = "CustomerCode";
        /// <summary>���i�����ރR�[�h</summary>
        public const string ct_COL_GOODSMGROUP = "GoodsMGroup";
        /// <summary>BL���i�R�[�h</summary>
        public const string ct_COL_BLGOODSCODE = "BLGoodsCode";
        /// <summary>���i���[�J�[�R�[�h</summary>
        public const string ct_COL_GOODSMAKERCD = "GoodsMakerCd";
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q</summary>
        public const string ct_COL_PRMSETDTLNO2 = "PrmSetDtlNo2";
        /// <summary>�D�ǐݒ�ڍז��̂Q</summary>
        public const string ct_COL_PRMSETDTLNAME2 = "PrmSetDtlName2";
        /// <summary>�����񓚋敪</summary>
        public const string ct_COL_AUTOANSWERDIV = "AutoAnswerDiv";
        /// <summary>�D�揇��</summary>
        public const string ct_COL_PRIORITYORDER = "PriorityOrder";

        /// <summary>�����񓚋敪(�O��ޔ�)</summary>
        public const string ct_COL_AUTOANSWERDIV_BACKUP = "AutoAnswerDiv_Backup";

        /// <summary>�D�揇��(�O��ޔ�)</summary>
        public const string ct_COL_PRIORITYORDER_BACKUP = "PriorityOrder_Backup";

        /// <summary>���_����</summary>
        public const string ct_COL_SECTIONNM = "SectionNm";
        /// <summary>���Ӑ於��</summary>
        public const string ct_COL_CUSTOMERNAME = "CustomerName";
        /// <summary>���i�����ޖ���</summary>
        public const string ct_COL_GOODSMGROUPNAME = "GoodsMGroupName";
        /// <summary>BL���i�R�[�h����</summary>
        public const string ct_COL_BLGOODSNAME = "BLGoodsName";
        /// <summary>���[�J�[����</summary>
        public const string ct_COL_MAKERNAME = "MakerName";

        # region [�\�[�g�p]
        /// <summary>���_�R�[�h</summary>
        public const string ct_COL_SECTIONCODE_SORT = "SectionCode_Sort";
        /// <summary>���Ӑ�R�[�h</summary>
        public const string ct_COL_CUSTOMERCODE_SORT = "CustomerCode_Sort";
        /// <summary>���i�����ރR�[�h</summary>
        public const string ct_COL_GOODSMGROUP_SORT = "GoodsMGroup_Sort";
        /// <summary>BL���i�R�[�h</summary>
        public const string ct_COL_BLGOODSCODE_SORT = "BLGoodsCode_Sort";
        /// <summary>���i���[�J�[�R�[�h</summary>
        public const string ct_COL_GOODSMAKERCD_SORT = "GoodsMakerCd_Sort";
        /// <summary>��� </summary>
        public const string ct_COL_PRMSETDTLNO2_SORT = "PrmSetDtlName2_Sort";
        /// <summary>�D�揇�� </summary>
        public const string ct_COL_PRIORITYORDER_SORT = "PriorityOrder_Sort";
        # endregion

        /// <summary>�_���폜��(�\���p)</summary>
        public const string ct_COL_LOGICALDELETEDATE = "LogicalDeleteDate";

        /// <summary>���i�����ރR�[�h�i�\���p�j</summary>
        public const string ct_COL_GOODSMGROUPDISPLAY = "GoodsMGroupDisplay";
        /// <summary>BL���i�R�[�h�i�\���p�j</summary>
        public const string ct_COL_BLGOODSCODEDISPLAY = "BLGoodsCodeDisplay";
        /// <summary>��ʁi�\���p�j</summary>
        public const string ct_COL_PRMSETDTLNO2DISPLAY = "PrmSetDtlName2Display";
        /// <summary>�D�揇�ʁi�\���p�j</summary>
        public const string ct_COL_PRIORITYORDERDISPLAY = "PriorityOrderDisplay";
        /// <summary>�s���i�\���p�j</summary>
        public const string ct_COL_ROWNUMBERDISPLAY = "RowNumberDisplay";

        /// <summary>�����񓚕i�ڐݒ�}�X�^work�I�u�W�F�N�g(�����ێ��p)</summary>
        public const string ct_COL_AUTOANSITEMSTWORKOBJECT = "AutoAnsItemStWorkObject";
        public object _autoAnsItemStWorkList = null; // �����񓚕i�ڐݒ胊���[�g

        /// <summary>�V�K�ǉ��s�敪(�����ێ��p)</summary>
        public const string ct_COL_NEWADDROWDIV = "NewAddRowDiv";
        /// <summary>�V�K�ǉ��s�ۑ��ۋ敪(�����ێ��p)</summary>
        public const string ct_COL_NEWADDROWALLOWSAVE = "NewAddRowAllowSave";

        // �e�[�u����
        /// <summary>�����񓚕i�ڐݒ�e�[�u��</summary>
        public const string ct_TABLE_AUTOANSITEMST = "AutoAnsItemStTable";

        #region �D�ǐݒ�}�X�^�֘A

        /// <summary>�񋟗D�ǐݒ�N���X </summary>
        public const string COL_OFFERPRIMESETTING = "OfferPrimeSetting";
        /// <summary>հ�ް�D�ǐݒ�N���X </summary>
        public const string COL_USERPRIMESETTING = "UserPrimeSetting";
        /// <summary>�`�F�b�N�{�b�N�X�X�e�[�^�X </summary>
        public const string COL_CHECKSTATE = "CheckState";
        /// <summary>�ύX�t���O </summary>
        public const string COL_CHANGEFLAG = "ChangeFlag";
        /// <summary>�`�F�b�N�{�b�N�X�X�e�[�^�X </summary>
        public const string COL_ORIGINAL_CHECKSTATE = "Original_CheckState";

        #endregion

        #endregion

        #region Private Members
        // ===================================================================================== //
        // �v���C�x�[�g�����o�[
        // ===================================================================================== //
        // �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        private IAutoAnsItemStDB _iAutoAnsItemStDB = null; // �����񓚕i�ڐݒ胊���[�g

        private DataSet _dataTableList = null;
        private DataView _dataView = null;
        private bool _excludeLogicalDeleteFromView;

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = string.Empty;

        #endregion

        # region enum
        // �񋓌^
        /// <summary>�I�����C�����[�h�̗񋓌^�ł��B</summary>
        public enum OnlineMode
        {
            /// <summary>�I�t���C��</summary>
            Offline,
            /// <summary>�I�����C��</summary>
            Online
        }
        # endregion

        /// <summary>�����񓚋敪�̗񋓌^�ł��B</summary>
        public enum AutoAnswerDiv
        {
            /// <summary>0:���Ȃ�</summary>
            None = 0,
            /// <summary>1:����(�S�Ď�����)</summary>
            All = 1,
            /// <summary>2:����(�D�揇��)</summary>
            Priority = 2
        }

        /// <summary>�V�K�ǉ��s�敪�̗񋓌^�ł��B</summary>
        public enum NewAddRowDiv
        {
            /// <summary>0:�����s</summary>
            Edit = 0,
            /// <summary>1:�V�K�s</summary>
            New = 1
        }

        /// <summary>>�V�K�ǉ��s�ŕۑ��\�ȏ�Ԃ��ۂ��i�K�v��񂪓��͂���Ă��邩�ۂ��j</summary>
        public enum NewAddRowAllowSave
        {
            /// <summary>0:�ۑ��n�j�i�K�v�����͍ς݁j</summary>
            Yes = 0,
            /// <summary>1:�ۑ��m�f�i�K�v���s���j</summary>
            No = 1
        }

        #region Construcstor
        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����񓚕i�ڐݒ�}�X�^�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// </remarks>
        public AutoAnsItemStAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iAutoAnsItemStDB = (IAutoAnsItemStDB)MediationAutoAnsItemStDB.GetAutoAnsItemStDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iAutoAnsItemStDB = null;
            }

            // �_���폜���O����
            _excludeLogicalDeleteFromView = true;
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����񓚕i�ڐݒ�}�X�^�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// </remarks>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        public AutoAnsItemStAcs(string enterpriseCode, string sectionCode) : this()
        {
            _enterpriseCode = enterpriseCode;
            _sectionCode    = sectionCode;
        }
        #endregion

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iAutoAnsItemStDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// �f�[�^�e�[�u���X�V��C�x���g
        /// </summary>
        public event EventHandler AfterTableUpdate;


        #region Property
        /// <summary>
        /// �f�[�^�r���[�i�}�X�^�ꗗ�p�j
        /// </summary>
        public DataView DataViewForMstList
        {
            get 
            {
                // �����O��get�v�����ꂽ�珉���������������s����
                if ( _dataTableList == null )
                {
                    this._dataTableList = new DataSet();
                    DataSetColumnConstruction();
                }
                return _dataView; 
            }
        }
        /// <summary>
        /// DataView�_���폜���O�t���O
        /// </summary>
        public bool ExcludeLogicalDeleteFromView
        {
            set
            {
                DataView view = this.DataViewForMstList;
                if ( value == true )
                {
                    // �_���폜����
                    view.RowFilter = string.Format( "{0}='{1}'", ct_COL_LOGICALDELETECODE, 0 );
                }
                else
                {
                    // �_���폜�܂�
                    view.RowFilter = string.Empty;
                }
            }
            get { return _excludeLogicalDeleteFromView; }
        }

        /// <summary>
        /// ��ƃR�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        public string EnterpriseCode
        {
            get
            {
                if (string.IsNullOrEmpty(_enterpriseCode.Trim()))
                {
                    return LoginInfoAcquisition.EnterpriseCode;
                }
                else
                {
                    return _enterpriseCode;
                }
            }
            set { _enterpriseCode = value; }
        }

        /// <summary>
        /// ���_�R�[�h���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        public string SectionCode
        {
            get
            {
                if (string.IsNullOrEmpty(_sectionCode.Trim()))
                {
                    return LoginInfoAcquisition.Employee.BelongSectionCode;
                }
                else
                {
                    return _sectionCode;
                }
            }
            set { _sectionCode = value; }
        }
        #endregion

        #region Search ��������
        /// <summary>
        /// �������ʃN���A����
        /// </summary>
        public void Clear()
        {
            // �i�[��e�[�u������
            if ( _dataTableList == null )
            {
                // ����̂ݐ���
                this._dataTableList = new DataSet();
                DataSetColumnConstruction();
            }
            else
            {
                // �Q��ڈȍ~�̓N���A�̂�
                _dataTableList.Tables[ct_TABLE_AUTOANSITEMST].Clear();
            }
        }

        /// <summary>
        /// �D�揇�ʕt�������񓚕i�ڐݒ�}�X�^�������������i�_���폜�܂܂Ȃ��j�����񓚕i�ڐݒ�}�X�����ȊO�p
        /// </summary>
        /// <param name="paraData"></param>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        public int SearchAll(AutoAnsItemStOrder paraData, out List<AutoAnsItemSt> retList, out string message)
        {
            // 1�p����
            AutoAnsItemStOrder searchingByLump = new AutoAnsItemStOrder();
            {
                // ��ƃR�[�h
                searchingByLump.EnterpriseCode = paraData.EnterpriseCode;
            }
            // 2�p����
            List<AutoAnsItemSt> firstSearchedList = null;
            // �ꊇ����
            int status = SearchSimply(searchingByLump, out firstSearchedList, out message);

            if (firstSearchedList == null || firstSearchedList.Count.Equals(0))
            {
                retList = firstSearchedList;
                return status;
            }

            // ���Ӑ�R�[�h�Ƌ��_�Ƌ��ʂ𒊏o����
            retList = firstSearchedList.FindAll(
                      delegate(AutoAnsItemSt autoAnsItemSt)
                      {
                          if (autoAnsItemSt.CustomerCode == paraData.St_CustomerCode
                                ||
                              autoAnsItemSt.SectionCode.Trim() == paraData.SectionCode.Trim()
                                ||
                              autoAnsItemSt.SectionCode.Trim() == "00")
                          {
                              return true;
                          }
                          else
                          {
                              return false;
                          }
                      });
            return status;
        }

        /// <summary>
        /// �D�揇�ʕt�������񓚕i�ڐݒ�}�X�^�������������i�_���폜�܂܂Ȃ��j�����񓚕i�ڐݒ�}�X�����ȊO�p
        /// </summary>
        /// <param name="paraData"></param>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        public int Search(AutoAnsItemStOrder paraData, out List<AutoAnsItemSt> retList, out string message)
        {
            // 1�p����
            AutoAnsItemStOrder searchingByLump = new AutoAnsItemStOrder();
            {
                // ��ƃR�[�h�őS����
                searchingByLump.EnterpriseCode = paraData.EnterpriseCode;

                #region <��֏���>

                if (string.IsNullOrEmpty(searchingByLump.EnterpriseCode.Trim()))
                {
                    if (paraData.St_CustomerCode > 0)
                    {
                        // ��ƃR�[�h�����ݒ�̏ꍇ�A���Ӑ�R�[�h
                        searchingByLump.St_CustomerCode = paraData.St_CustomerCode;
                        searchingByLump.Ed_CustomerCode = paraData.Ed_CustomerCode;
                    }
                    else if (!string.IsNullOrEmpty(paraData.SectionCode.Trim()))
                    {
                        // ���Ӑ�R�[�h�����ݒ�̏ꍇ�A���_�R�[�h
                        searchingByLump.SectionCode = paraData.SectionCode;
                    }
                    else
                    {
                        // ���_�R�[�h�����ݒ�̏ꍇ�A���̂܂�
                        searchingByLump = paraData;
                    }
                }

                #endregion // </��֏���>
            }
            // 2�p����
            List<AutoAnsItemSt> firstSearchedList = null;
            // �ꊇ����
            int status = SearchSimply(searchingByLump, out firstSearchedList, out message);
            if (firstSearchedList == null || firstSearchedList.Count.Equals(0))
            {
                retList = firstSearchedList;
                return status;
            }

            // �ꊇ�������ʂ��D�揇�ʂɍ��킹�Č������ʂ𒊏o
            if (paraData.St_CustomerCode > 0)
            {
                #region  �D�揇��1:���Ӑ�{���[�J�[�{�i��

                retList = firstSearchedList.FindAll(
                    delegate(AutoAnsItemSt autoAnsItemSt)
                    {
                        return IsPriority1(autoAnsItemSt, paraData);
                    }
                );
                if (retList != null && retList.Count > 0)
                {
                    message = string.Format(
                        "�D�揇��1:���Ӑ�(={0})�{���[�J�[(={1}) �Ō�������܂����B",
                        paraData.St_CustomerCode,
                        paraData.St_GoodsMakerCd
                    );
                    return status;
                }

                #endregion

                #region �D�揇��2:���Ӑ�{���[�J�[�{BL�R�[�h

                retList = firstSearchedList.FindAll(
                    delegate(AutoAnsItemSt autoAnsItemSt)
                    {
                        return IsPriority2(autoAnsItemSt, paraData);
                    }
                );
                if (retList != null && retList.Count > 0)
                {
                    message = string.Format(
                        "�D�揇��2:���Ӑ�(={0})�{���[�J�[(={1})�{BL�R�[�h(={2}) �Ō�������܂����B",
                        paraData.St_CustomerCode,
                        paraData.St_GoodsMakerCd,
                        paraData.St_BLGoodsCode
                    );
                    return status;
                }

                #endregion

                #region �D�揇��3:���Ӑ�{���[�J�[�{�����ރR�[�h

                retList = firstSearchedList.FindAll(
                    delegate(AutoAnsItemSt autoAnsItemSt)
                    {
                        return IsPriority3(autoAnsItemSt, paraData);
                    }
                );
                if (retList != null && retList.Count > 0)
                {
                    message = string.Format(
                        "�D�揇��3:���Ӑ�(={0})�{���[�J�[(={1})�{�����ރR�[�h(={2}) �Ō�������܂����B",
                        paraData.St_CustomerCode,
                        paraData.St_GoodsMakerCd,
                        paraData.St_GoodsMGroup
                    );
                    return status;
                }

                #endregion

                #region �D�揇��4:���Ӑ�{���[�J�[

                retList = firstSearchedList.FindAll(
                    delegate(AutoAnsItemSt autoAnsItemSt)
                    {
                        return IsPriority4(autoAnsItemSt, paraData);
                    }
                );
                if (retList != null && retList.Count > 0)
                {
                    message = string.Format(
                        "�D�揇��4:���Ӑ�(={0})�{���[�J�[(={1}) �Ō�������܂����B",
                        paraData.St_CustomerCode,
                        paraData.St_GoodsMakerCd
                    );
                    return status;
                }

                #endregion
            }
            if (!string.IsNullOrEmpty(paraData.SectionCode.Trim()))
            {
                #region �D�揇��5:���_�{���[�J�[�{�i��

                retList = firstSearchedList.FindAll(
                    delegate(AutoAnsItemSt autoAnsItemSt)
                    {
                        return IsPriority5(autoAnsItemSt, paraData);
                    }
                );
                if (retList != null && retList.Count > 0)
                {
                    message = string.Format(
                        "�D�揇��5:���_(={0})�{���[�J�[(={1}) �Ō�������܂����B",
                        paraData.SectionCode,
                        paraData.St_GoodsMakerCd
                    );
                    return status;
                }

                #endregion

                #region �D�揇��6:���_�{���[�J�[�{BL�R�[�h

                retList = firstSearchedList.FindAll(
                    delegate(AutoAnsItemSt autoAnsItemSt)
                    {
                        return IsPriority6(autoAnsItemSt, paraData);
                    }
                );
                if (retList != null && retList.Count > 0)
                {
                    message = string.Format(
                        "�D�揇��6:���_(={0})�{���[�J�[(={1})�{BL�R�[�h(={2}) �Ō�������܂����B",
                        paraData.SectionCode,
                        paraData.St_GoodsMakerCd,
                        paraData.St_BLGoodsCode
                    );
                    return status;
                }

                #endregion

                #region �D�揇��7:���_�{���[�J�[�{�����ރR�[�h

                retList = firstSearchedList.FindAll(
                    delegate(AutoAnsItemSt autoAnsItemSt)
                    {
                        return IsPriority7(autoAnsItemSt, paraData);
                    }
                );
                if (retList != null && retList.Count > 0)
                {
                    message = string.Format(
                        "�D�揇��7:���_(={0})�{���[�J�[(={1})�{�����ރR�[�h(={2}) �Ō�������܂����B",
                        paraData.SectionCode,
                        paraData.St_GoodsMakerCd,
                        paraData.St_GoodsMGroup
                    );
                    return status;
                }

                #endregion

                #region �D�揇��8:���_�{���[�J�[

                retList = firstSearchedList.FindAll(
                    delegate(AutoAnsItemSt autoAnsItemSt)
                    {
                        return IsPriority8(autoAnsItemSt, paraData);
                    }
                );
                if (retList != null && retList.Count > 0)
                {
                    message = string.Format(
                        "�D�揇��8:���_(={0})�{���[�J�[(={1}) �Ō�������܂����B",
                        paraData.SectionCode,
                        paraData.St_GoodsMakerCd
                    );
                    return status;
                }

                #endregion
            }
            else
            {
                retList = null;
                return status;
            }

            int sectionCode = int.Parse(paraData.SectionCode.Trim());
            if (sectionCode > 0)
            {
                paraData.SectionCode = "00";    // �S�ЂōČ���
                return Search(paraData, out retList, out message);
            }

            retList = null;
            return status;
        }

        #region �D�揇�ʂ̔��f

        /// <summary>
        /// �D�揇��1:���Ӑ�{�����ށ{BL�R�[�h�{���[�J�[�ł��邩���f���܂��B
        /// </summary>
        /// <param name="AutoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="AutoAnsItemStOrder">�����񓚕i�ڐݒ����</param>
        /// <returns>
        /// <c>true</c> :�D�揇��1�ł��B<br/>
        /// <c>false</c>:�D�揇��1�ł͂���܂���B
        /// </returns>
        private static bool IsPriority1(AutoAnsItemSt autoAnsItemSt, AutoAnsItemStOrder autoAnsItemStOrder)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
               (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == autoAnsItemStOrder.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == autoAnsItemStOrder.St_CustomerCode
                        &&
                    autoAnsItemSt.GoodsMGroup == autoAnsItemStOrder.St_GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == autoAnsItemStOrder.St_BLGoodsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == autoAnsItemStOrder.St_GoodsMakerCd
                    );
            }
            return false;
        }

        /// <summary>
        /// �D�揇��1:���Ӑ�{�����ށ{BL�R�[�h�ł��邩���f���܂��B
        /// </summary>
        /// <param name="AutoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="AutoAnsItemStOrder">�����񓚕i�ڐݒ����</param>
        /// <returns>
        /// <c>true</c> :�D�揇��2�ł��B<br/>
        /// <c>false</c>:�D�揇��2�ł͂���܂���B
        /// </returns>
        private static bool IsPriority2(AutoAnsItemSt autoAnsItemSt, AutoAnsItemStOrder autoAnsItemStOrder)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
               (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == autoAnsItemStOrder.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == autoAnsItemStOrder.St_CustomerCode
                        &&
                    autoAnsItemSt.GoodsMGroup == autoAnsItemStOrder.St_GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == autoAnsItemStOrder.St_BLGoodsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == 0
                );
            }
            return false;
        }

        /// <summary>
        /// �D�揇��1:���Ӑ�{�����ނł��邩���f���܂��B
        /// </summary>
        /// <param name="AutoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="AutoAnsItemStOrder">�����񓚕i�ڐݒ����</param>
        /// <returns>
        /// <c>true</c> :�D�揇��3�ł��B<br/>
        /// <c>false</c>:�D�揇��3�ł͂���܂���B
        /// </returns>
        private static bool IsPriority3(AutoAnsItemSt autoAnsItemSt, AutoAnsItemStOrder autoAnsItemStOrder)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
               (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == autoAnsItemStOrder.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == autoAnsItemStOrder.St_CustomerCode
                        &&
                    autoAnsItemSt.GoodsMGroup == autoAnsItemStOrder.St_GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == autoAnsItemStOrder.St_GoodsMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// �D�揇��4:���Ӑ�ł��邩���f���܂��B
        /// </summary>
        /// <param name="AutoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="AutoAnsItemStOrder">�����񓚕i�ڐݒ����</param>
        /// <returns>
        /// <c>true</c> :�D�揇��4�ł��B<br/>
        /// <c>false</c>:�D�揇��4�ł͂���܂���B
        /// </returns>
        private static bool IsPriority4(AutoAnsItemSt autoAnsItemSt, AutoAnsItemStOrder autoAnsItemStOrder)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
               (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == autoAnsItemStOrder.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.CustomerCode == autoAnsItemStOrder.St_CustomerCode
                        &&
                    autoAnsItemSt.GoodsMGroup == 0
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == autoAnsItemStOrder.St_GoodsMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// �D�揇��5:���_�{�����ށ{BL�R�[�h�{���[�J�[�ł��邩���f���܂��B
        /// </summary>
        /// <param name="AutoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="AutoAnsItemStOrder">�����񓚕i�ڐݒ����</param>
        /// <returns>
        /// <c>true</c> :�D�揇��5�ł��B<br/>
        /// <c>false</c>:�D�揇��5�ł͂���܂���B
        /// </returns>
        private static bool IsPriority5(AutoAnsItemSt autoAnsItemSt, AutoAnsItemStOrder autoAnsItemStOrder)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
               (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == autoAnsItemStOrder.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == autoAnsItemStOrder.SectionCode.Trim()
                        &&
                    autoAnsItemSt.GoodsMGroup == autoAnsItemStOrder.St_GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == autoAnsItemStOrder.St_BLGoodsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == autoAnsItemStOrder.St_GoodsMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// �D�揇��6:���_�{�����ށ{BL�R�[�h�ł��邩���f���܂��B
        /// </summary>
        /// <param name="AutoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="AutoAnsItemStOrder">�����񓚕i�ڐݒ����</param>
        /// <returns>
        /// <c>true</c> :�D�揇��6�ł��B<br/>
        /// <c>false</c>:�D�揇��6�ł͂���܂���B
        /// </returns>
        private static bool IsPriority6(AutoAnsItemSt autoAnsItemSt, AutoAnsItemStOrder autoAnsItemStOrder)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
               (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == autoAnsItemStOrder.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == autoAnsItemStOrder.SectionCode.Trim()
                        &&
                    autoAnsItemSt.GoodsMGroup == autoAnsItemStOrder.St_GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == autoAnsItemStOrder.St_BLGoodsCode
                        &&
                    autoAnsItemSt.GoodsMakerCd == 0
                );
            }
            return false;
        }

        /// <summary>
        /// �D�揇��7:���_�{�����ނł��邩���f���܂��B
        /// </summary>
        /// <param name="AutoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="AutoAnsItemStOrder">�����񓚕i�ڐݒ����</param>
        /// <returns>
        /// <c>true</c> :�D�揇��7�ł��B<br/>
        /// <c>false</c>:�D�揇��7�ł͂���܂���B
        /// </returns>
        private static bool IsPriority7(AutoAnsItemSt autoAnsItemSt, AutoAnsItemStOrder autoAnsItemStOrder)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
                (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == autoAnsItemStOrder.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == autoAnsItemStOrder.SectionCode.Trim()
                        &&
                    autoAnsItemSt.GoodsMGroup == autoAnsItemStOrder.St_GoodsMGroup
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == autoAnsItemStOrder.St_GoodsMakerCd
                );
            }
            return false;
        }

        /// <summary>
        /// �D�揇��8:���_�ł��邩���f���܂��B
        /// </summary>
        /// <param name="AutoAnsItemSt">�����񓚕i�ڐݒ�</param>
        /// <param name="AutoAnsItemStOrder">�����񓚕i�ڐݒ����</param>
        /// <returns>
        /// <c>true</c> :�D�揇��8�ł��B<br/>
        /// <c>false</c>:�D�揇��8�ł͂���܂���B
        /// </returns>
        private static bool IsPriority8(AutoAnsItemSt autoAnsItemSt, AutoAnsItemStOrder autoAnsItemStOrder)
        {
            if (autoAnsItemSt.PrmSetDtlNo2 == 0 ||
               (autoAnsItemSt.PrmSetDtlNo2 != 0 && autoAnsItemSt.PrmSetDtlNo2 == autoAnsItemStOrder.PrmSetDtlNo2))
            {
                return (
                    autoAnsItemSt.SectionCode.Trim() == autoAnsItemStOrder.SectionCode.Trim()
                        &&
                    autoAnsItemSt.GoodsMGroup == 0
                        &&
                    autoAnsItemSt.BLGoodsCode == 0
                        &&
                    autoAnsItemSt.GoodsMakerCd == autoAnsItemStOrder.St_GoodsMakerCd
                );
            }
            return false;
        }

        #endregion // �D�揇�ʂ̔��f

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^�������������i�_���폜�܂܂Ȃ��j�����񓚕i�ڐݒ�}�X�����ȊO�p
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="AutoAnsItemStList">�����񓚕i�ڐݒ�I�u�W�F�N�g���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����񓚕i�ڐݒ�}�X�^���X�g�̏����Ɉ�v�����f�[�^���������܂��B�_���폜�f�[�^�͒��o�ΏۊO</br>
        /// </remarks>
        private int SearchSimply( AutoAnsItemStOrder paraData, out List<AutoAnsItemSt> retList, out string message )
        {
            // ����
            ArrayList retWorkList;
            int status = this.SearchProc( paraData, out retWorkList, ConstantManagement.LogicalMode.GetData0, out message );

            // ���ʊi�[
            retList = new List<AutoAnsItemSt>();
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retWorkList != null )
            {
                foreach ( object obj in retWorkList )
                {
                    if ( obj is AutoAnsItemStWork )
                    {
                        AutoAnsItemStWork retWork = (obj as AutoAnsItemStWork);

                        // �l���Z�b�g
                        AutoAnsItemSt autoAnsItemSt = CopyToAutoAnsItemStFromAutoAnsItemStWork(retWork);
                        retList.Add(autoAnsItemSt);
                    }
                }
            }

            if ( retList.Count == 0 )
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            return status;
        }

        /// <summary>
        /// �ŐV���擾����
        /// </summary>
        public void Renewal()
        {
            this.Clear();
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^�������������i�_���폜�܂܂Ȃ��j�����񓚕i�ڐݒ�}�X�����p
        /// </summary>
        /// <param name="paraData"></param>
        /// <param name="retList"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int Search( AutoAnsItemStOrder paraData, out string message )
        {
            // ������/�N���A
            this.Clear();

            // ����
            ArrayList retWorkList;
            int status = SearchProc( paraData, out retWorkList, ConstantManagement.LogicalMode.GetDataAll, out message );

            // ���ʊi�[
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retWorkList != null )
            {
                foreach (object obj in retWorkList)
                {
                    if (obj is AutoAnsItemStWork)
                    {
                        AutoAnsItemStWork retWork = (obj as AutoAnsItemStWork);

                        // �A�N�Z�X�N���X����DataTable�ɒǉ�
                        DataRow row = this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST].NewRow();

                        // �l���Z�b�g
                        CopyToDataRowFromAutoAnsItemStWork(ref row, retWork);
                        _dataTableList.Tables[ct_TABLE_AUTOANSITEMST].Rows.Add(row);
                    }
                }
            }

            // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��18,��19 --------->>>>>>>>>>>>>>>>>>>>>>>>
            // �V�K�ǉ��s�̒ǉ�
            RowAdd(); 
            #region ���\�[�X
            //// �V�K�ǉ��s�̒ǉ�
            //DataRow newRow = this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST].NewRow();
            //AutoAnsItemStWork newRetWork = new AutoAnsItemStWork();
            //CopyToDataRowFromAutoAnsItemStWorkNewAdd(ref newRow, newRetWork);
            //_dataTableList.Tables[ct_TABLE_AUTOANSITEMST].Rows.Add(newRow);

            //if (_dataTableList.Tables[ct_TABLE_AUTOANSITEMST].Rows.Count == 0)
            //{
            //    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //}

            //// �e�[�u���X�V��C�x���g
            //if ( AfterTableUpdate != null )
            //{
            //    AfterTableUpdate( this, new EventArgs() );
            //}
            #endregion
            // ADD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��18,��19 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            return status;
        }

        /// <summary>
        /// �}�X�����������R�[�h�擾����
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks>�����񓚕i�ڐݒ�}�X�����Ŏg�p����ꍇ�iDataTable�Ɍ��ʊi�[�ς݂̏ꍇ�j�̂ݑΉ����܂�</remarks>
        public AutoAnsItemSt GetRecordForMaintenance( Guid guid )
        {
            AutoAnsItemStWork autoAnsItemStWork = null;

            if ( _dataTableList != null )
            {
                DataView view = new DataView( this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST] );
                view.RowFilter = string.Format( "{0}='{1}'", ct_COL_FILEHEADERGUID, guid );

                if ( view.Count > 0 )
                {
                    autoAnsItemStWork = CopyToAutoAnsItemStWorkFromDataRow( view[0].Row );
                }
            }

            // �Y�������Ȃ��f�[�^
            if ( autoAnsItemStWork == null )
            {
                autoAnsItemStWork = new AutoAnsItemStWork();
            }

            return this.CopyToAutoAnsItemStFromAutoAnsItemStWork( autoAnsItemStWork );
        }

        /// <summary>
        /// �}�X�����������R�[�h�擾����
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks>�����񓚕i�ڐݒ�}�X�����Ŏg�p����ꍇ�iDataTable�Ɍ��ʊi�[�ς݂̏ꍇ�j�̂ݑΉ����܂�</remarks>
        public AutoAnsItemSt GetRecordForMaintenance(int rowIndex)
        {
            AutoAnsItemStWork autoAnsItemStWork = null;

            if (_dataTableList != null)
            {
                DataView view = new DataView(this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST]);
                view.RowFilter = string.Format("{0}='{1}'", ct_COL_ROWNUMBERDISPLAY, rowIndex);

                if (view.Count > 0)
                {
                    autoAnsItemStWork = CopyToAutoAnsItemStWorkFromDataRow(view[0].Row);
                }
            }

            // �Y�������Ȃ��f�[�^
            if (autoAnsItemStWork == null)
            {
                autoAnsItemStWork = new AutoAnsItemStWork();
            }

            return this.CopyToAutoAnsItemStFromAutoAnsItemStWork(autoAnsItemStWork);
        }

        /// <summary>
        /// �}�X�����������R�[�h�擾���� ���C������
        /// </summary>
        /// <param name="filter">��������</param>
        /// <returns>���������Ɉ�v�������R�[�h���X�g</returns>
        /// <remarks>�����񓚕i�ڐݒ�}�X�����Ŏg�p����ꍇ�iDataTable�Ɍ��ʊi�[�ς݂̏ꍇ�j�̂ݑΉ����܂�</remarks>
        public List<AutoAnsItemSt> GetRecordListForMaintenance(string filter,int rowCount)
        {
            List<AutoAnsItemStWork> autoAnsItemStWorkList = new List<AutoAnsItemStWork>();

            if (_dataTableList != null)
            {
                DataView view = new DataView(this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST]);
                view.RowFilter = filter;

                if (view.Count > 0)
                {
                    foreach (DataRow row in view.Table.Select(filter))
                    {
                        autoAnsItemStWorkList.Add(CopyToAutoAnsItemStWorkFromDataRow(row));
                    }
                }
            }

            // �Y�������Ȃ��f�[�^
            if (autoAnsItemStWorkList.Count.Equals(0))
            {
                for (int i = 0; i < rowCount; i++)
                {
                    autoAnsItemStWorkList.Add(new AutoAnsItemStWork());
                }
            }
            else
            {
                for (int i = autoAnsItemStWorkList.Count; i < rowCount; i++)
                {
                    autoAnsItemStWorkList.Add(new AutoAnsItemStWork());
                }
            }

            // �Ԓl�쐬
            List<AutoAnsItemSt> rtnList = new List<AutoAnsItemSt>();
            foreach (AutoAnsItemStWork wrk in autoAnsItemStWorkList)
            {
                rtnList.Add(this.CopyToAutoAnsItemStFromAutoAnsItemStWork(wrk));
            }

            return rtnList;
        }

        /// <summary>
        /// �}�X�����������R�[�h�擾����
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks>�����񓚕i�ڐݒ�}�X�����Ŏg�p����ꍇ�iDataTable�Ɍ��ʊi�[�ς݂̏ꍇ�j�̂ݑΉ����܂�</remarks>
        public DataRow GetRowForMaintenance( Guid guid )
        {
            DataRow row = null;
            if ( _dataTableList != null )
            {
                DataView view = new DataView( this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST] );
                view.RowFilter = string.Format( "{0}='{1}'", ct_COL_FILEHEADERGUID, guid );

                if ( view.Count > 0 )
                {
                    row = view[0].Row;
                }
            }

            // �Y�������Ȃ�NULL
            return row;
        }

        /// <summary>
        /// �}�X�����������R�[�h�擾����
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks>�����񓚕i�ڐݒ�}�X�����Ŏg�p����ꍇ�iDataTable�Ɍ��ʊi�[�ς݂̏ꍇ�j�̂ݑΉ����܂�</remarks>
        public DataRow GetRowForMaintenance(int rowIndex)
        {
            DataRow row = null;
            if (_dataTableList != null)
            {
                DataView view = new DataView(this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST]);
                view.RowFilter = string.Format("{0}='{1}'", ct_COL_ROWNUMBERDISPLAY, rowIndex);

                if (view.Count > 0)
                {
                    row = view[0].Row;
                }
            }

            // �Y�������Ȃ�NULL
            return row;
        }

        /// <summary>
        /// �}�X�����������R�[�h�擾����
        /// </summary>
        /// <param name="filter">���o����</param>
        /// <returns></returns>
        /// <remarks>�����񓚕i�ڐݒ�}�X�����Ŏg�p����ꍇ�iDataTable�Ɍ��ʊi�[�ς݂̏ꍇ�j�̂ݑΉ����܂�</remarks>
        public int GetRowForMaintenance(string filter)
        {
            int rowCount = 0;

            if (_dataTableList != null && !string.IsNullOrEmpty(filter))
            {
                DataView view = new DataView(this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST]);
                view.RowFilter = filter;
                rowCount = view.Count;
            }

            // �Y�������Ȃ�0
            return rowCount;
        }

        /// <summary>
        /// �}�X�����������R�[�h�擾����
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks>�����񓚕i�ڐݒ�}�X�����Ŏg�p����ꍇ�iDataTable�Ɍ��ʊi�[�ς݂̏ꍇ�j�̂ݑΉ����܂�</remarks>
        public DataView GetRowListForMaintenance(string filter)
        {
            DataView retView = null;
            if (_dataTableList != null)
            {
                retView = new DataView(this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST]);
                retView.RowFilter = filter;

                if (retView.Count > 0)
                {
                    return retView;
                }
            }
            // �Y�������Ȃ�NULL
            return retView;
        }

        #endregion

        #region Write �������ݏ���
        /// <summary>
        /// �������ݏ���
        /// </summary>
        /// <param name="autoAnsItemStList">�ۑ��f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �������ݏ������s���܂��B</br>
        /// </remarks>
        public int Write(ref ArrayList autoAnsItemStList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // �D�揇�ʂ̐ݒ�̗L���m�F
                bool isPriority = false;
                // �ҏW�Ώۃ��X�g
                List<AutoAnsItemSt> editList = new List<AutoAnsItemSt>();

                ArrayList paraAutoAnsItemStList = new ArrayList();

                // ��ʂ��ύX�̂��������R�[�h�ɗD�揇�ʂ̐ݒ肪���邩�`�F�b�N
                for ( int i = 0; i < autoAnsItemStList.Count; i++ )
                {
                    // ��U�A�p�����[�^���X�g���쐬
                    paraAutoAnsItemStList.Add(CopyToAutoAnsItemStWorkFromAutoAnsItemSt((AutoAnsItemSt)autoAnsItemStList[i]));
                    
                    if (((AutoAnsItemSt)autoAnsItemStList[i]).AutoAnswerDiv.Equals((int)AutoAnswerDiv.Priority))
                    {
                        editList.Add(((AutoAnsItemSt)autoAnsItemStList[i]));
                        isPriority = true;
                    }
                }

                // �D�ǃ��[�J�[�ŗD�揇�ʂ̐ݒ肪����ꍇ�A�����R�[�h�Ƃ̑Ó������m�F����
                if (isPriority)
                {
                    // �ҏW�Ώۃ��X�g��D�揇�ʂŃ\�[�g
                    editList.Sort(
                        delegate(AutoAnsItemSt w1, AutoAnsItemSt w2)
                        {
                            return w1.PriorityOrder - w2.PriorityOrder;
                        });

                    // �ҏW�Ώ�BL�R�[�h�ɐݒ肳��Ă��鏇�ʂ�S���擾
                    List<AutoAnsItemSt> retListWk = new List<AutoAnsItemSt>();
                    List<AutoAnsItemSt> retList = new List<AutoAnsItemSt>();

                    status = Read2(editList[0], ref retListWk, true);
                    if (!(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        // ��������̃G���[����
                        message = "�o�^�Ɏ��s���܂����B";
                        return status;
                    }

                    // ��L�S���擾(retListWk)����A��ʂ���n���ꂽ�ҏW�Ώۃ��R�[�h�Ɠ���̂��̂������AretList�ɒǉ�
                    foreach (AutoAnsItemSt retWk in retListWk)
                    {
                        bool isTarget = true;
                        foreach (AutoAnsItemSt edit in editList)
                        {
                            if(IsEqualsAutoAnsItemStForPriority(edit,retWk))
                            {
                                isTarget = false;
                                break;
                            }
                        }

                        if(isTarget)
                        {
                            retList.Add(retWk);
                        }
                    }

                    // �ҏW�Ώۃ��X�g��ҏW
                    EditForPriority(ref editList, ref retList);
                }

                // �ҏW�Ώۃ��X�g�����[�N�N���X�f�[�^�ɕϊ����p�����[�^���X�g�ɒǉ�
                foreach (AutoAnsItemSt edit in editList)
                {
                    // ���Ƀp�����[�^���X�g�ɑ��݂��Ă���ꍇ�́A�p�����[�^���X�g����폜���A�V���ɕҏW�Ώۃ��X�g����ǉ�
                    foreach (object para in paraAutoAnsItemStList)
                    {
                        if (IsEqualsAutoAnsItemSt(edit, para as AutoAnsItemStWork))
                        {
                            paraAutoAnsItemStList.Remove(para);
                            break;
                        }

                    }
                    paraAutoAnsItemStList.Add(CopyToAutoAnsItemStWorkFromAutoAnsItemSt(edit));
                }

                object paraObj = (object)paraAutoAnsItemStList;

                // �������ݏ���
                status = this._iAutoAnsItemStDB.Write( ref paraObj );

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ��������̃G���[����
                    message = "�o�^�Ɏ��s���܂����B";
                    return status;
                }
            }
            catch ( Exception ex )
            {
                message = ex.Message;
                // �I�t���C������null���Z�b�g
                this._iAutoAnsItemStDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �D�揇�ʕҏW���ɂ̂ݎg�p
        /// ����L�[�̎����񓚕i�ڐݒ�}�X�^���R�[�h���ۂ��i�D�ǐݒ�ڍ׃R�[�h�Q�͏����j
        /// ��ƃR�[�h�`BL�R�[�h�܂ł�����ł��邱�Ƃ��O��
        /// </summary>
        /// <param name="target1">��r�ΏۂP</param>
        /// <param name="target2">��r�ΏۂQ</param>
        /// <returns>true�F�L�[�������@false�F�L�[���قȂ�</returns>
        private bool IsEqualsAutoAnsItemStForPriority(AutoAnsItemSt target1, AutoAnsItemSt target2)
        {
            return target1.GoodsMakerCd == target2.GoodsMakerCd;
        }

        /// <summary>
        /// ����L�[�̎����񓚕i�ڐݒ�}�X�^���R�[�h���ۂ�
        /// </summary>
        /// <param name="target1">��r�ΏۂP</param>
        /// <param name="target2">��r�ΏۂQ</param>
        /// <returns>true�F�L�[�������@false�F�L�[���قȂ�</returns>
        private bool IsEqualsAutoAnsItemSt(AutoAnsItemSt target1, AutoAnsItemStWork target2)
        {
            if (target1.EnterpriseCode == target2.EnterpriseCode
                && target1.SectionCode == target2.SectionCode
                && target1.CustomerCode == target2.CustomerCode
                && target1.GoodsMGroup == target2.GoodsMGroup
                && target1.BLGoodsCode == target2.BLGoodsCode
                && target1.GoodsMakerCd == target2.GoodsMakerCd
                && target1.PrmSetDtlNo2 == target2.PrmSetDtlNo2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// �D�揇�ʂ̕ҏW
        /// </summary>
        /// <param name="editList">�ҏW�Ώۃ��X�g</param>
        /// <param name="retList">�ҏW�Ώۃ��X�g�Ɠ���BL�R�[�h�̃��R�[�h</param>
        /// <remarks>
        /// <br>UpdateNote : 2015/10/19 �c���� </br>
        /// <br>�Ǘ��ԍ�   : 11170187-00 Redmine#47535</br>
        /// <br>           : �������R�[�h�̗D�揇�ʁ��Q && �V�K���R�[�h�̗D�揇�ʁ��������R�[�h�̗D�揇�ʂ̏ꍇ�o�^�G���[�̉���</br>
        /// </remarks>
        private void EditForPriority(ref List<AutoAnsItemSt> editList, ref List<AutoAnsItemSt> retList )
        {
            // ���X�g����ǉ��E�폜���Ȃ��玩�ȉ�A���邽�߁Aforeach�͎g�p�s��
            for (int i1 = 0; i1 < retList.Count; i1++)
            {
                bool isNoAdd = true;
                for (int i2 = 0; i2 < editList.Count; i2++)
                {
                    if (editList[i2].PriorityOrder >= retList[i1].PriorityOrder)
                    {
                        if (editList[i2].PriorityOrder == retList[i1].PriorityOrder)
                        {
                            // ����̗D�揇�ʂł���ΗD�揇�ʂ��P�ǉ�
                            retList[i1].PriorityOrder++;
                            continue;
                        }

                        // �ҏW�Ώۃ��X�g�̓r���ɒǉ�
                        //editList.Insert(retList[i1].PriorityOrder - 1, retList[i1]); // DEL 2015/10/19 �c���� Redmine#47535
                        editList.Add(retList[i1]); // ADD 2015/10/19 �c���� Redmine#47535
                        isNoAdd = false;
                        break;
                    }
                }
                // �r���ɒǉ�����Ȃ�������AretList����ҏW�Ώۃ��X�g�̍Ō�ɒǉ�
                if (isNoAdd)
                {
                    editList.Add(retList[i1]);
                }
                // �ǉ��������R�[�h��retList����폜
                retList.Remove(retList[i1]);
                // ���ȉ�A
                EditForPriority(ref editList, ref retList);
            }
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^���R�[�h����A���������̍쐬
        /// �D�揇�ʂ̐������m�F�p
        /// </summary>
        /// <param name="r">�����񓚕i�ڐݒ�}�X�^���R�[�h</param>
        /// <returns>
        /// ��������������@�����L�[�F��ƃR�[�h�A���_�R�[�h�A���Ӑ�R�[�h
        /// ���i�����ރR�[�h�ABL���i�R�[�h
        /// </returns>
        private string GetFilterPriority(AutoAnsItemStWork r)
        {
            return string.Format(
                "{0}='{1}' AND " +
                "{2}='{3}' AND " +
                "{4}='{5}' AND " +
                "{6}='{7}' AND " +
                "{8}='{9}' AND " 
                , ct_COL_ENTERPRISECODE, r.EnterpriseCode.ToString()
                , ct_COL_SECTIONCODE, r.SectionCode
                , ct_COL_CUSTOMERCODE, r.CustomerCode
                , ct_COL_GOODSMGROUP, r.GoodsMGroup
                , ct_COL_BLGOODSCODE, r.BLGoodsCode);
        }


        /// <summary>
        /// �X�V�����̎擾�i����DataTable���j
        /// </summary>
        /// <returns></returns>
        public int GetUpdateCountFromTable()
        {
            if (_dataTableList != null)
            {
                DataView view = new DataView(_dataTableList.Tables[ct_TABLE_AUTOANSITEMST]);
                // �����񓚋敪�E�D�揇�ʂ̕ύX�����邩�A�V�K�ǉ��s�̓��͍s�����݂��鎞�A�X�V�ΏۂƂ���
                view.RowFilter = string.Format("{0}<>{1} OR {2}<>{3} OR ( {4}={5} AND {6}={7} )",
                                                ct_COL_AUTOANSWERDIV, ct_COL_AUTOANSWERDIV_BACKUP,
                                                ct_COL_PRIORITYORDER, ct_COL_PRIORITYORDER_BACKUP,
                                                ct_COL_NEWADDROWDIV, ((int)NewAddRowDiv.New).ToString(),
                                                ct_COL_NEWADDROWALLOWSAVE, ((int)NewAddRowAllowSave.Yes).ToString());

                return view.Count;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// DataTable����̈ꊇ�������ݏ���
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public int WriteAll( out string message )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // DataTable���珑�����݃��X�g����
                ArrayList paraAutoAnsItemStList = new ArrayList();
                foreach ( DataRow row in _dataTableList.Tables[ct_TABLE_AUTOANSITEMST].Rows )
                {
                    // �ύX�L���`�F�b�N
                    // UPD 2013/11/22 T.Yoshioka VSS[019] Redmine#677 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    #region ���\�[�X
                    //if (((int)row[ct_COL_AUTOANSWERDIV] == (int)row[ct_COL_AUTOANSWERDIV_BACKUP] &&
                    //     (int)row[ct_COL_PRIORITYORDER] == (int)row[ct_COL_PRIORITYORDER_BACKUP] &&
                    //     (int)row[ct_COL_NEWADDROWDIV] == (int)NewAddRowDiv.Edit) ||
                    //    ((int)row[ct_COL_NEWADDROWDIV] == (int)NewAddRowDiv.New &&
                    //     (int)row[ct_COL_NEWADDROWALLOWSAVE] == (int)NewAddRowAllowSave.No)
                    //   )
                    #endregion 
                    if (( IntObjToInt(row[ct_COL_AUTOANSWERDIV]) == IntObjToInt(row[ct_COL_AUTOANSWERDIV_BACKUP]) &&
                         IntObjToInt(row[ct_COL_PRIORITYORDER]) == IntObjToInt(row[ct_COL_PRIORITYORDER_BACKUP]) &&
                         IntObjToInt(row[ct_COL_NEWADDROWDIV]) == (int)NewAddRowDiv.Edit) ||
                        (IntObjToInt(row[ct_COL_NEWADDROWDIV]) == (int)NewAddRowDiv.New &&
                         IntObjToInt(row[ct_COL_NEWADDROWALLOWSAVE]) == (int)NewAddRowAllowSave.No)
                       )
                    // UPD 2013/11/22 T.Yoshioka VSS[019] Redmine#677 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    {
                        // �ύX�\�ȍ��ڂ�Search���ƕς��Ȃ��̂őΏۊO�ɂ���
                        continue;
                    }



                    AutoAnsItemStWork autoAnsItemStWork = CopyToAutoAnsItemStWorkFromDataRow( row );
                    paraAutoAnsItemStList.Add( autoAnsItemStWork );
                }
                // �ύX�L���`�F�b�N
                if ( paraAutoAnsItemStList.Count == 0 )
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    message = "�X�V�Ώۂ̃f�[�^�����݂��܂���";
                    return status;
                }

                object paraObj = (object)paraAutoAnsItemStList;


                // �������ݏ���
                status = this._iAutoAnsItemStDB.Write( ref paraObj );

                if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // ��������̃G���[����
                    message = "�o�^�Ɏ��s���܂����B";
                    return status;
                }
            }
            catch ( Exception ex )
            {
                message = ex.Message;
                // �I�t���C������null���Z�b�g
                this._iAutoAnsItemStDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �����f�[�^�e�[�u��������������(�����폜��)
        /// </summary>
        /// <param name="retObj"></param>
        private void DeleteFromDataTable( ArrayList AutoAnsItemStWorkList )
        {
            foreach ( object obj in AutoAnsItemStWorkList )
            {
                if ( obj is AutoAnsItemStWork )
                {
                    AutoAnsItemStWork retWork = (AutoAnsItemStWork)obj;

                    DataRow row = this.GetRowForMaintenance( retWork.FileHeaderGuid );

                    if ( row != null )
                    {
                        // �폜
                        _dataTableList.Tables[ct_TABLE_AUTOANSITEMST].Rows.Remove( row );
                    }
                }
            }
        }
        #endregion

        #region LogicalDelete �_���폜����
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="AutoAnsItemStList">�_���폜�f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�������s���܂��B</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList AutoAnsItemStList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // �f�[�^�������[�v
                ArrayList paraAutoAnsItemStList = new ArrayList();
                AutoAnsItemStWork autoAnsItemStWork = null;

                for (int i = 0; i < AutoAnsItemStList.Count; i++)
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    autoAnsItemStWork = CopyToAutoAnsItemStWorkFromAutoAnsItemSt((AutoAnsItemSt)AutoAnsItemStList[i]);

                    paraAutoAnsItemStList.Add(autoAnsItemStWork);
                }
                object paraObj = (object)paraAutoAnsItemStList;

                // �_���폜����
                status = this._iAutoAnsItemStDB.LogicalDelete( ref paraObj );

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ��������̃G���[����
                    message = "�폜�Ɏ��s���܂����B";
                    return status;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // �I�t���C������null���Z�b�g
                this._iAutoAnsItemStDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �����f�[�^�e�[�u��������������(�V�K�ǉ��s)
        /// </summary>
        /// <param name="retObj"></param>
        public int LogicalDeleteRowIndex(ref int rowIndex, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            DataRow row = this.GetRowForMaintenance(rowIndex);

            if (row != null)
            {
                // �폜
                _dataTableList.Tables[ct_TABLE_AUTOANSITEMST].Rows.Remove(row);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
        }

        /// <summary>
        /// �����f�[�^�e�[�u��������������(�V�K�ǉ��s)
        /// </summary>
        /// <param name="retObj"></param>
        private int LogicalDeleteFilter(string filter, out AutoAnsItemStWork deleteAutoAnsItemStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string message = string.Empty;
            deleteAutoAnsItemStWork = new AutoAnsItemStWork();

            DataView deleteDataView = this.GetRowListForMaintenance(filter);

            if (deleteDataView != null && deleteDataView.Count != 0)
            {
                // ���̑ޔ�
                deleteAutoAnsItemStWork.SectionNm = deleteDataView[0][ct_COL_SECTIONNM].ToString();
                deleteAutoAnsItemStWork.CustomerName = deleteDataView[0][ct_COL_CUSTOMERNAME].ToString();
                deleteAutoAnsItemStWork.GoodsMGroupName = deleteDataView[0][ct_COL_GOODSMGROUPNAME].ToString();
                deleteAutoAnsItemStWork.BLGoodsName = deleteDataView[0][ct_COL_BLGOODSNAME].ToString();
                deleteAutoAnsItemStWork.MakerName = deleteDataView[0][ct_COL_MAKERNAME].ToString();

                foreach (DataRow dvr in deleteDataView.Table.Select(filter))
                {
                    // �����e�[�u���s�w��폜
                    int rowNumberDisplay = 0;
                    int.TryParse(dvr[ct_COL_ROWNUMBERDISPLAY].ToString(), out rowNumberDisplay);
                    status = LogicalDeleteRowIndex(ref rowNumberDisplay, out message);
                    if (status != 0) break;
                }
            }
            return status;
        }

        #endregion

        #region Revival ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="AutoAnsItemStList">�_���폜�f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i�_���폜�����j���s���܂��B</br>
        /// </remarks>
        public int Revival(ref ArrayList autoAnsItemStList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // �f�[�^�������[�v
                ArrayList paraAutoAnsItemStList = new ArrayList();
                AutoAnsItemStWork autoAnsItemStWork = null;

                for (int i = 0; i < autoAnsItemStList.Count; i++)
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    autoAnsItemStWork = CopyToAutoAnsItemStWorkFromAutoAnsItemSt((AutoAnsItemSt)autoAnsItemStList[i]);

                    paraAutoAnsItemStList.Add(autoAnsItemStWork);
                }

                object paraObj = (object)paraAutoAnsItemStList;

                // �������ݏ���
                status = this._iAutoAnsItemStDB.RevivalLogicalDelete(ref paraObj);

                if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // ��������̃G���[����
                    message = "�폜�Ɏ��s���܂����B";
                    return status;
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // �I�t���C������null���Z�b�g
                this._iAutoAnsItemStDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region Delete �폜����
        /// <summary>
        /// �폜����
        /// </summary>
        /// <param name="AutoAnsItemStList">�폜�f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �폜�����i�����폜�j���s���܂��B</br>
        /// </remarks>
        public int Delete(ref ArrayList AutoAnsItemStList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // �����A�����폜�͗D�ǐݒ�ڍ׃R�[�h�Q���������L�[���ځi����ʂ���1���̃��R�[�h�ōςށj��
                // ���������Ƃ��邽�߁A�p�����[�^��1���ɂ���
                
                byte[] paraAutoAnsItemStWork = null;
                AutoAnsItemStWork autoAnsItemStWork = null;
                ArrayList autoAnsItemStWorkList = new ArrayList();	// ���[�N�N���X�i�[�pArrayList

                // ���[�N�N���X�i�[�pArrayList�֋l�ߑւ�
                for (int i = 0; i < AutoAnsItemStList.Count; i++)
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    autoAnsItemStWork = CopyToAutoAnsItemStWorkFromAutoAnsItemSt((AutoAnsItemSt)AutoAnsItemStList[i]);
                    autoAnsItemStWorkList.Add(autoAnsItemStWork);
                }
                // ArrayList����z��𐶐�
                AutoAnsItemStWork[] autoAnsItemStWorks = (AutoAnsItemStWork[])autoAnsItemStWorkList.ToArray(typeof(AutoAnsItemStWork));
                AutoAnsItemStWork[] autoAnsItemStWorksPara = new AutoAnsItemStWork[1];
                autoAnsItemStWorksPara[0] = autoAnsItemStWorks[0];

                // �V���A���C�Y
                paraAutoAnsItemStWork = XmlByteSerializer.Serialize(autoAnsItemStWorksPara);

                // �����폜����
                status = this._iAutoAnsItemStDB.Delete(paraAutoAnsItemStWork);

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    if ( _dataTableList != null )
                    {
                        // �e�[�u������폜
                        DeleteFromDataTable( autoAnsItemStWorkList );
                    }
                }
                else
                {
                    // ��������̃G���[����
                    message = "�폜�Ɏ��s���܂����B";
                    return status;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // �I�t���C������null���Z�b�g
                this._iAutoAnsItemStDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region �f�[�^�Z�b�g����\�z����
        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <param name="ds">�f�[�^�Z�b�g</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //----------------------------------------------------------------
            // �����񓚕i�ڐݒ�e�[�u�����`
            //----------------------------------------------------------------
            DataTable AutoAnsItemStTable = new DataTable(ct_TABLE_AUTOANSITEMST);


            // �쐬����
            AutoAnsItemStTable.Columns.Add(ct_COL_CREATEDATETIME, typeof(DateTime));
            // �X�V����
            AutoAnsItemStTable.Columns.Add(ct_COL_UPDATEDATETIME, typeof(DateTime));
            // ��ƃR�[�h
            AutoAnsItemStTable.Columns.Add(ct_COL_ENTERPRISECODE, typeof(string));
            // GUID
            AutoAnsItemStTable.Columns.Add(ct_COL_FILEHEADERGUID, typeof(Guid));
            // �X�V�]�ƈ��R�[�h
            AutoAnsItemStTable.Columns.Add(ct_COL_UPDEMPLOYEECODE, typeof(string));
            // �X�V�A�Z���u��ID1
            AutoAnsItemStTable.Columns.Add(ct_COL_UPDASSEMBLYID1, typeof(string));
            // �X�V�A�Z���u��ID2
            AutoAnsItemStTable.Columns.Add(ct_COL_UPDASSEMBLYID2, typeof(string));
            // �_���폜�敪
            AutoAnsItemStTable.Columns.Add(ct_COL_LOGICALDELETECODE, typeof(Int32));
            // ���_�R�[�h
            AutoAnsItemStTable.Columns.Add(ct_COL_SECTIONCODE, typeof(string));
            // ���_����
            AutoAnsItemStTable.Columns.Add(ct_COL_SECTIONNM, typeof(string));
            // ���Ӑ�R�[�h
            AutoAnsItemStTable.Columns.Add(ct_COL_CUSTOMERCODE, typeof(Int32));
            // ���Ӑ於��
            AutoAnsItemStTable.Columns.Add(ct_COL_CUSTOMERNAME, typeof(string));
            // ���i�����ރR�[�h
            AutoAnsItemStTable.Columns.Add(ct_COL_GOODSMGROUP, typeof(Int32));
            // ���i�����ޖ���
            AutoAnsItemStTable.Columns.Add(ct_COL_GOODSMGROUPNAME, typeof(string));
            // BL���i�R�[�h
            AutoAnsItemStTable.Columns.Add(ct_COL_BLGOODSCODE, typeof(Int32));
            // BL���i�R�[�h����
            AutoAnsItemStTable.Columns.Add(ct_COL_BLGOODSNAME, typeof(string));
            // ���i���[�J�[�R�[�h
            AutoAnsItemStTable.Columns.Add(ct_COL_GOODSMAKERCD, typeof(Int32));
            // ���[�J�[����
            AutoAnsItemStTable.Columns.Add(ct_COL_MAKERNAME, typeof(string));
            // ���
            AutoAnsItemStTable.Columns.Add(ct_COL_PRMSETDTLNO2, typeof(Int32));
            // ��ʖ���
            AutoAnsItemStTable.Columns.Add(ct_COL_PRMSETDTLNAME2, typeof(string));
            // �����񓚋敪
            AutoAnsItemStTable.Columns.Add(ct_COL_AUTOANSWERDIV, typeof(Int32));
            // �����񓚋敪�o�b�N�A�b�v
            AutoAnsItemStTable.Columns.Add(ct_COL_AUTOANSWERDIV_BACKUP, typeof(Int32));
            // �D�揇��
            AutoAnsItemStTable.Columns.Add(ct_COL_PRIORITYORDER, typeof(Int32));
            // �D�揇�ʃo�b�N�A�b�v
            AutoAnsItemStTable.Columns.Add(ct_COL_PRIORITYORDER_BACKUP, typeof(Int32));

            # region [�\�[�g�p]
            // ���_�R�[�h
            AutoAnsItemStTable.Columns.Add(ct_COL_SECTIONCODE_SORT, typeof(string));
            // ���Ӑ�R�[�h
            AutoAnsItemStTable.Columns.Add(ct_COL_CUSTOMERCODE_SORT, typeof(Int32));
            // ���i�����ރR�[�h
            AutoAnsItemStTable.Columns.Add(ct_COL_GOODSMGROUP_SORT, typeof(Int32));
            // BL���i�R�[�h
            AutoAnsItemStTable.Columns.Add(ct_COL_BLGOODSCODE_SORT, typeof(Int32));
            // ���i���[�J�[�R�[�h
            AutoAnsItemStTable.Columns.Add(ct_COL_GOODSMAKERCD_SORT, typeof(Int32));
            // ��ʃR�[�h
            AutoAnsItemStTable.Columns.Add(ct_COL_PRMSETDTLNO2_SORT, typeof(Int32));
            # endregion

            // �_���폜��(�\���p)
            AutoAnsItemStTable.Columns.Add(ct_COL_LOGICALDELETEDATE, typeof(string));
            // ���i�����ރR�[�h�i�\���p�j
            AutoAnsItemStTable.Columns.Add(ct_COL_GOODSMGROUPDISPLAY, typeof(string));
            // BL���i�R�[�h�i�\���p�j
            AutoAnsItemStTable.Columns.Add(ct_COL_BLGOODSCODEDISPLAY, typeof(string));
            // ��ʁi�\���p�j
            AutoAnsItemStTable.Columns.Add(ct_COL_PRMSETDTLNO2DISPLAY, typeof(string));
            // �D�揇�ʁi�\���p�j
            AutoAnsItemStTable.Columns.Add(ct_COL_PRIORITYORDERDISPLAY, typeof(string));
            // �I�u�W�F�N�g(�����ێ��p)
            AutoAnsItemStTable.Columns.Add(ct_COL_AUTOANSITEMSTWORKOBJECT, typeof(AutoAnsItemStWork));
            // �V�K�ǉ��s�敪�i�����ێ��p�j
            AutoAnsItemStTable.Columns.Add(ct_COL_NEWADDROWDIV, typeof(Int32));
            // �V�K�ǉ��s�\���敪�i�����ێ��p�j
            AutoAnsItemStTable.Columns.Add(ct_COL_NEWADDROWALLOWSAVE, typeof(Int32));
            // �s���i�\���p�j
            AutoAnsItemStTable.Columns.Add(ct_COL_ROWNUMBERDISPLAY, typeof(Int32));

            this._dataTableList.Tables.Add(AutoAnsItemStTable);

            //----------------------------------------------------------------
            // �f�[�^�r���[����
            //----------------------------------------------------------------
            this._dataView = new DataView(AutoAnsItemStTable);
            // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��36 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this._dataView.Sort = string.Format("{0}, {1}, {2}, {3}, {4}",
                                    ct_COL_SECTIONCODE_SORT,
                                    ct_COL_CUSTOMERCODE_SORT,
                                    ct_COL_GOODSMGROUP_SORT,
                                    ct_COL_BLGOODSCODE_SORT,
                                    ct_COL_GOODSMAKERCD_SORT
                                    );
            // ADD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��36 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        }
        #endregion

        #region �N���X�����o�R�s�[����
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�����񓚕i�ڐݒ�N���X�ˎ����񓚕i�ڐݒ胏�[�N�N���X�j
        /// </summary>
        /// <param name="AutoAnsItemSt">�����񓚕i�ڐݒ�N���X</param>
        /// <returns>AutoAnsItemStWork</returns>
        /// <remarks>
        /// <br>Note       : �����񓚕i�ڐݒ�N���X���玩���񓚕i�ڐݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// </remarks>
        private AutoAnsItemStWork CopyToAutoAnsItemStWorkFromAutoAnsItemSt(AutoAnsItemSt autoAnsItemSt)
        {
            AutoAnsItemStWork autoAnsItemStWork = new AutoAnsItemStWork();

            autoAnsItemStWork.CreateDateTime = autoAnsItemSt.CreateDateTime; // �쐬����
            autoAnsItemStWork.UpdateDateTime = autoAnsItemSt.UpdateDateTime; // �X�V����
            autoAnsItemStWork.EnterpriseCode = autoAnsItemSt.EnterpriseCode; // ��ƃR�[�h
            autoAnsItemStWork.FileHeaderGuid = autoAnsItemSt.FileHeaderGuid; // GUID
            autoAnsItemStWork.UpdEmployeeCode = autoAnsItemSt.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            autoAnsItemStWork.UpdAssemblyId1 = autoAnsItemSt.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            autoAnsItemStWork.UpdAssemblyId2 = autoAnsItemSt.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            autoAnsItemStWork.LogicalDeleteCode = autoAnsItemSt.LogicalDeleteCode; // �_���폜�敪
            autoAnsItemStWork.SectionCode = autoAnsItemSt.SectionCode; // ���_�R�[�h
            autoAnsItemStWork.CustomerCode = autoAnsItemSt.CustomerCode; // ���Ӑ�R�[�h
            autoAnsItemStWork.GoodsMGroup = autoAnsItemSt.GoodsMGroup; // ���i�����ރR�[�h
            autoAnsItemStWork.BLGoodsCode = autoAnsItemSt.BLGoodsCode; // BL���i�R�[�h
            autoAnsItemStWork.GoodsMakerCd = autoAnsItemSt.GoodsMakerCd; // ���i���[�J�[�R�[�h
            autoAnsItemStWork.PrmSetDtlNo2 = autoAnsItemSt.PrmSetDtlNo2; // �D�ǐݒ�ڍ׃R�[�h�Q
            autoAnsItemStWork.PrmSetDtlName2 = autoAnsItemSt.PrmSetDtlName2; // �D�ǐݒ�ڍז��̂Q
            autoAnsItemStWork.AutoAnswerDiv = autoAnsItemSt.AutoAnswerDiv; // �����񓚋敪
            autoAnsItemStWork.PriorityOrder = autoAnsItemSt.PriorityOrder; //�D�揇��

            autoAnsItemStWork.SectionNm = autoAnsItemSt.SectionNm;  // ���_����
            autoAnsItemStWork.CustomerName = autoAnsItemSt.CustomerName;    // ���Ӑ於��
            autoAnsItemStWork.GoodsMGroupName = autoAnsItemSt.GoodsMGroupName;  // ���i�����ޖ���
            autoAnsItemStWork.BLGoodsName = autoAnsItemSt.BLGoodsName; // BL���i�R�[�h����
            autoAnsItemStWork.MakerName = autoAnsItemSt.MakerName;  // ���[�J�[����


            return autoAnsItemStWork;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�����񓚕i�ڐݒ胏�[�N�N���X�ˎ����񓚕i�ڐݒ�N���X�j
        /// </summary>
        /// <param name="AutoAnsItemStWork">�����񓚕i�ڐݒ胏�[�N�N���X</param>
        /// <returns>AutoAnsItemSt</returns>
        /// <remarks>
        /// <br>Note       : �����񓚕i�ڐݒ胏�[�N�N���X���玩���񓚕i�ڐݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// </remarks>
        private AutoAnsItemSt CopyToAutoAnsItemStFromAutoAnsItemStWork(AutoAnsItemStWork autoAnsItemStWork)
        {
            AutoAnsItemSt autoAnsItemSt = new AutoAnsItemSt();

            autoAnsItemSt.CreateDateTime = autoAnsItemStWork.CreateDateTime; // �쐬����
            autoAnsItemSt.UpdateDateTime = autoAnsItemStWork.UpdateDateTime; // �X�V����
            autoAnsItemSt.EnterpriseCode = autoAnsItemStWork.EnterpriseCode; // ��ƃR�[�h
            autoAnsItemSt.FileHeaderGuid = autoAnsItemStWork.FileHeaderGuid; // GUID
            autoAnsItemSt.UpdEmployeeCode = autoAnsItemStWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            autoAnsItemSt.UpdAssemblyId1 = autoAnsItemStWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            autoAnsItemSt.UpdAssemblyId2 = autoAnsItemStWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            autoAnsItemSt.LogicalDeleteCode = autoAnsItemStWork.LogicalDeleteCode; // �_���폜�敪
            autoAnsItemSt.SectionCode = autoAnsItemStWork.SectionCode; // ���_�R�[�h
            autoAnsItemSt.SectionNm = autoAnsItemStWork.SectionNm;  // ���_����
            autoAnsItemSt.CustomerCode = autoAnsItemStWork.CustomerCode; // ���Ӑ�R�[�h
            autoAnsItemSt.CustomerName = autoAnsItemStWork.CustomerName; // ���Ӑ於��
            autoAnsItemSt.GoodsMGroup = autoAnsItemStWork.GoodsMGroup; // ���i�����ރR�[�h
            autoAnsItemSt.GoodsMGroupName = autoAnsItemStWork.GoodsMGroupName; // ���i�����ޖ���
            autoAnsItemSt.BLGoodsCode = autoAnsItemStWork.BLGoodsCode; // BL���i�R�[�h
            autoAnsItemSt.GoodsMakerCd = autoAnsItemStWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
            autoAnsItemSt.MakerName = autoAnsItemStWork.MakerName; // ���[�J�[����
            autoAnsItemSt.AutoAnswerDiv = autoAnsItemStWork.AutoAnswerDiv; // �����񓚋敪
            autoAnsItemSt.BLGoodsName = autoAnsItemStWork.BLGoodsName; // BL���i�R�[�h����
            autoAnsItemSt.PriorityOrder = autoAnsItemStWork.PriorityOrder; // �D�揇��
            autoAnsItemSt.PrmSetDtlNo2 = autoAnsItemStWork.PrmSetDtlNo2; //��ʃR�[�h
            autoAnsItemSt.PrmSetDtlName2 = autoAnsItemStWork.PrmSetDtlName2; //��ʖ���

            return autoAnsItemSt;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�����񓚕i�ڐݒ�N���X��DataRow�j
        /// </summary>
        /// <param name="AutoAnsItemStWork">�����񓚕i�ڐݒ�N���X</param>
        /// <returns>DataRow</returns>
        /// <remarks>
        /// <br>Note       : �����񓚕i�ڐݒ胏�[�N�N���X���玩���񓚕i�ڐݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// </remarks>
        private void CopyToDataRowFromAutoAnsItemStWork( ref DataRow dr, AutoAnsItemStWork autoAnsItemStWork )
        {
            # region [dr��AutoAnsItemSt]
            dr[ct_COL_ROWNUMBERDISPLAY] = 0;
            dr[ct_COL_CREATEDATETIME] = autoAnsItemStWork.CreateDateTime; // �쐬����
            dr[ct_COL_UPDATEDATETIME] = autoAnsItemStWork.UpdateDateTime; // �X�V����
            dr[ct_COL_ENTERPRISECODE] = autoAnsItemStWork.EnterpriseCode; // ��ƃR�[�h
            dr[ct_COL_FILEHEADERGUID] = autoAnsItemStWork.FileHeaderGuid; // GUID
            dr[ct_COL_UPDEMPLOYEECODE] = autoAnsItemStWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            dr[ct_COL_UPDASSEMBLYID1] = autoAnsItemStWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            dr[ct_COL_UPDASSEMBLYID2] = autoAnsItemStWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            dr[ct_COL_LOGICALDELETECODE] = autoAnsItemStWork.LogicalDeleteCode; // �_���폜�敪
            dr[ct_COL_SECTIONCODE] = autoAnsItemStWork.SectionCode; // ���_�R�[�h
            dr[ct_COL_SECTIONNM] = autoAnsItemStWork.SectionNm; // ���_����
            dr[ct_COL_CUSTOMERCODE] = autoAnsItemStWork.CustomerCode; // ���Ӑ�R�[�h
            dr[ct_COL_CUSTOMERNAME] = autoAnsItemStWork.CustomerName; // ���Ӑ於��
            if (autoAnsItemStWork.GoodsMGroup == 0)
            {
                dr[ct_COL_GOODSMGROUP] = 0; // ���i�����ރR�[�h
                dr[ct_COL_GOODSMGROUPDISPLAY] = "0000"; // ���i�����ރR�[�h�i�\���p�j
                dr[ct_COL_GOODSMGROUPNAME] = "����"; // ���i�����ޖ���
            }
            else
            {
                dr[ct_COL_GOODSMGROUP] = autoAnsItemStWork.GoodsMGroup; // ���i�����ރR�[�h
                dr[ct_COL_GOODSMGROUPDISPLAY] = autoAnsItemStWork.GoodsMGroup.ToString("0000"); // ���i�����ރR�[�h�i�\���p�j
                dr[ct_COL_GOODSMGROUPNAME] = autoAnsItemStWork.GoodsMGroupName; // ���i�����ޖ���
            }
            if (autoAnsItemStWork.BLGoodsCode == 0)
            {
                // ���i�����ރR�[�h�����ʂ̎���BL���i�R�[�h�̕\���͂��Ȃ�
                if (autoAnsItemStWork.GoodsMGroup == 0)
                {
                    dr[ct_COL_BLGOODSCODE] = 0; // BL���i�R�[�h
                    dr[ct_COL_BLGOODSCODEDISPLAY] = string.Empty; // BL���i�R�[�h�i�\���p�j
                    dr[ct_COL_BLGOODSNAME] = string.Empty; // BL���i����
                }
                else
                {
                    dr[ct_COL_BLGOODSCODE] = 0; // BL���i�R�[�h
                    dr[ct_COL_BLGOODSCODEDISPLAY] = "00000"; // BL���i�R�[�h�i�\���p�j
                    dr[ct_COL_BLGOODSNAME] = "����"; // BL���i����
                }
            }
            else
            {
                dr[ct_COL_BLGOODSCODE] = autoAnsItemStWork.BLGoodsCode; // BL���i�R�[�h
                dr[ct_COL_BLGOODSCODEDISPLAY] = autoAnsItemStWork.BLGoodsCode.ToString("00000"); // BL���i�R�[�h�i�\���p�j
                dr[ct_COL_BLGOODSNAME] = autoAnsItemStWork.BLGoodsName; // BL���i����
            }
            dr[ct_COL_GOODSMAKERCD] = autoAnsItemStWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
            dr[ct_COL_MAKERNAME] = autoAnsItemStWork.MakerName; // ���i���[�J�[����
            if (autoAnsItemStWork.PrmSetDtlNo2 == 0)
            {
                dr[ct_COL_PRMSETDTLNO2] = 0; // ��ʁi�D�ǐݒ�ڍ׃R�[�h�Q�j
                dr[ct_COL_PRMSETDTLNO2DISPLAY] = string.Empty; // ��ʁi�D�ǐݒ�ڍ׃R�[�h�Q�j�i�\���p�j
            }
            else
            {
                dr[ct_COL_PRMSETDTLNO2] = autoAnsItemStWork.PrmSetDtlNo2; // ��ʁi�D�ǐݒ�ڍ׃R�[�h�Q�j
                dr[ct_COL_PRMSETDTLNO2DISPLAY] = autoAnsItemStWork.PrmSetDtlNo2.ToString("0"); // ��ʁi�D�ǐݒ�ڍ׃R�[�h�Q�j�i�\���p�j
            }
            dr[ct_COL_PRMSETDTLNAME2] = autoAnsItemStWork.PrmSetDtlName2; // ��ʖ���
            dr[ct_COL_AUTOANSWERDIV] = autoAnsItemStWork.AutoAnswerDiv; // �����񓚋敪
            if (autoAnsItemStWork.PriorityOrder == 0)
            {
                dr[ct_COL_PRIORITYORDER] = 0; // �D�揇��
                dr[ct_COL_PRIORITYORDER_BACKUP] = 0; // �D�揇��(�O��l�ޔ�)
                dr[ct_COL_PRIORITYORDERDISPLAY] = string.Empty; // �D�揇�ʁi�\���p�j
            }
            else
            {
                dr[ct_COL_PRIORITYORDER] = autoAnsItemStWork.PriorityOrder; // �D�揇��
                dr[ct_COL_PRIORITYORDER_BACKUP] = autoAnsItemStWork.PriorityOrder; // �D�揇��(�O��l�ޔ�)
                dr[ct_COL_PRIORITYORDERDISPLAY] = autoAnsItemStWork.PriorityOrder.ToString("0"); // �D�揇�ʁi�\���p�j
            }


            dr[ct_COL_AUTOANSWERDIV_BACKUP] = autoAnsItemStWork.AutoAnswerDiv; // �����񓚋敪(�O��l�ޔ�)

            // �_���폜��(�\���p)
            if (autoAnsItemStWork.LogicalDeleteCode == 0)
            {
                dr[ct_COL_LOGICALDELETEDATE] = string.Empty;
            }
            else
            {
                dr[ct_COL_LOGICALDELETEDATE] = TDateTime.DateTimeToString("ggYY/MM/DD", autoAnsItemStWork.UpdateDateTime);
            }

            // �\�[�g�p�J����
            dr[ct_COL_SECTIONCODE_SORT] = GetSortValue(autoAnsItemStWork.SectionCode); // ���_�R�[�h
            dr[ct_COL_CUSTOMERCODE_SORT] = autoAnsItemStWork.CustomerCode; // ���Ӑ�R�[�h
            dr[ct_COL_GOODSMAKERCD_SORT] = autoAnsItemStWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
            dr[ct_COL_GOODSMGROUP_SORT] = autoAnsItemStWork.GoodsMGroup; // ���i�����ރR�[�h
            dr[ct_COL_BLGOODSCODE_SORT] = autoAnsItemStWork.BLGoodsCode; // BL���i�R�[�h
            dr[ct_COL_PRMSETDTLNO2_SORT] = autoAnsItemStWork.PrmSetDtlNo2; // ��ʃR�[�h

            // �I�u�W�F�N�g(�����ێ��p)
            dr[ct_COL_AUTOANSITEMSTWORKOBJECT] = autoAnsItemStWork;

            // �V�K�ǉ��s���
            dr[ct_COL_NEWADDROWDIV] = NewAddRowDiv.Edit;  // �V�K�ǉ��s�敪�i�����ێ��p�j
            dr[ct_COL_NEWADDROWALLOWSAVE] = NewAddRowAllowSave.Yes;  // �V�K�ǉ��s�\���敪�i�����ێ��p�j

            # endregion
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�����񓚕i�ڐݒ�N���X�i�V�K�j��DataRow�j
        /// </summary>
        /// <param name="AutoAnsItemStWork">�����񓚕i�ڐݒ�N���X�i�V�K�j</param>
        /// <returns>DataRow</returns>
        /// <remarks>
        /// <br>Note       : �����񓚕i�ڐݒ胏�[�N�N���X���玩���񓚕i�ڐݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// </remarks>
        private void CopyToDataRowFromAutoAnsItemStWorkNewAdd(ref DataRow dr, AutoAnsItemStWork autoAnsItemStWork)
        {
            # region [dr��AutoAnsItemSt(New)]
            dr[ct_COL_ROWNUMBERDISPLAY] = 1;
            dr[ct_COL_CREATEDATETIME] = autoAnsItemStWork.CreateDateTime; // �쐬����
            dr[ct_COL_UPDATEDATETIME] = autoAnsItemStWork.UpdateDateTime; // �X�V����
            dr[ct_COL_ENTERPRISECODE] = autoAnsItemStWork.EnterpriseCode; // ��ƃR�[�h
            dr[ct_COL_FILEHEADERGUID] = autoAnsItemStWork.FileHeaderGuid; // GUID
            dr[ct_COL_UPDEMPLOYEECODE] = autoAnsItemStWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            dr[ct_COL_UPDASSEMBLYID1] = autoAnsItemStWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            dr[ct_COL_UPDASSEMBLYID2] = autoAnsItemStWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            dr[ct_COL_LOGICALDELETECODE] = autoAnsItemStWork.LogicalDeleteCode; // �_���폜�敪
            dr[ct_COL_SECTIONCODE] = autoAnsItemStWork.SectionCode; // ���_�R�[�h 
            dr[ct_COL_SECTIONNM] = autoAnsItemStWork.SectionNm; // ���_����
            dr[ct_COL_CUSTOMERCODE] = autoAnsItemStWork.CustomerCode; // ���Ӑ�R�[�h
            dr[ct_COL_CUSTOMERNAME] = autoAnsItemStWork.CustomerName; // ���Ӑ於��
            dr[ct_COL_GOODSMGROUP] = autoAnsItemStWork.GoodsMGroup; // ���i�����ރR�[�h
            dr[ct_COL_GOODSMGROUPDISPLAY] = string.Empty; // ���i�����ރR�[�h�i�\���p�j
            dr[ct_COL_GOODSMGROUPNAME] = autoAnsItemStWork.GoodsMGroupName; // ���i�����ޖ���
            dr[ct_COL_BLGOODSCODE] = autoAnsItemStWork.BLGoodsCode; // BL���i�R�[�h
            dr[ct_COL_BLGOODSCODEDISPLAY] = string.Empty; // BL���i�R�[�h
            dr[ct_COL_BLGOODSNAME] = autoAnsItemStWork.BLGoodsName; // BL���i����
            dr[ct_COL_GOODSMAKERCD] = autoAnsItemStWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
            dr[ct_COL_MAKERNAME] = autoAnsItemStWork.MakerName; // ���i���[�J�[����
            dr[ct_COL_PRMSETDTLNO2] = autoAnsItemStWork.PrmSetDtlNo2; // ��ʁi�D�ǐݒ�ڍ׃R�[�h�Q�j
            dr[ct_COL_PRMSETDTLNO2DISPLAY] = string.Empty; // ��ʁi�D�ǐݒ�ڍ׃R�[�h�Q�j�i�\���p�j
            dr[ct_COL_PRMSETDTLNAME2] = autoAnsItemStWork.PrmSetDtlName2; // ��ʖ���
            dr[ct_COL_AUTOANSWERDIV] = autoAnsItemStWork.AutoAnswerDiv; // �����񓚋敪
            dr[ct_COL_PRIORITYORDER] = autoAnsItemStWork.PriorityOrder; // �D�揇��
            dr[ct_COL_PRIORITYORDER_BACKUP] = autoAnsItemStWork.PriorityOrder; // �D�揇��(�O��l�ޔ�)
            dr[ct_COL_PRIORITYORDERDISPLAY] = string.Empty; // �D�揇�ʁi�\���p�j
            dr[ct_COL_AUTOANSWERDIV_BACKUP] = autoAnsItemStWork.AutoAnswerDiv; // �����񓚋敪(�O��l�ޔ�)
            dr[ct_COL_LOGICALDELETEDATE] = string.Empty;

            // �\�[�g�p�J����
            // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��36 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // dr[ct_COL_SECTIONCODE_SORT] = GetSortValue(autoAnsItemStWork.SectionCode); // ���_�R�[�h
            // ���ҏW�̐V�K�ǉ��s�͏�Ɉ�ԉ��ɕ\��
            dr[ct_COL_SECTIONCODE_SORT] = "ZZ"; // ���_�R�[�h
            // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��36 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            dr[ct_COL_CUSTOMERCODE_SORT] = Int32.MaxValue; // ���Ӑ�R�[�h ���ŉ��s�ɕ\�����邽��MAX�l��ݒ肷��
            dr[ct_COL_GOODSMAKERCD_SORT] = autoAnsItemStWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
            dr[ct_COL_GOODSMGROUP_SORT] = autoAnsItemStWork.GoodsMGroup; // ���i�����ރR�[�h
            dr[ct_COL_BLGOODSCODE_SORT] = autoAnsItemStWork.BLGoodsCode; // BL���i�R�[�h
            dr[ct_COL_PRMSETDTLNO2_SORT] = autoAnsItemStWork.PrmSetDtlNo2; // ��ʃR�[�h

            // �I�u�W�F�N�g(�����ێ��p)
            dr[ct_COL_AUTOANSITEMSTWORKOBJECT] = autoAnsItemStWork;

            // �V�K�ǉ��s���
            dr[ct_COL_NEWADDROWDIV] = NewAddRowDiv.New;  // �V�K�ǉ��s�敪�i�����ێ��p�j
            dr[ct_COL_NEWADDROWALLOWSAVE] = NewAddRowAllowSave.No;  // �V�K�ǉ��s�\���敪�i�����ێ��p�j

            # endregion
        }

        /// <summary>
        /// �\�[�g�l�擾�i���l�j
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private int GetSortValue( int value )
        {
            if ( value != 0 )
            {
                return value;
            }
            else
            {
                // ���ݒ肪���ɂȂ�悤�ɂ���
                return Int32.MaxValue;
            }
        }
        /// <summary>
        /// �\�[�g�l�擾�i������j
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string GetSortValue( string value )
        {
            if ( value.Trim() != string.Empty )
            {
                return value;
            }
            else
            {
                // ���ݒ肪���ɂȂ�悤�ɂ���
                // (������͋��_�݂̂Ŏg�p���Ă���̂ŕ֋X�I��AA�ɂ��Ă��܂�)
                return "AA";
            }
        }
        /// <summary>
        /// �N���X�����o�[�R�s�[�����iDataRow�ˎ����񓚕i�ڐݒ�N���X�j
        /// </summary>
        /// <param name="row"></param>
        /// <returns>AutoAnsItemStWork</returns>
        /// <remarks>
        /// <br>Note       : �����񓚕i�ڐݒ胏�[�N�N���X���玩���񓚕i�ڐݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// </remarks>
        private AutoAnsItemStWork CopyToAutoAnsItemStWorkFromDataRow( DataRow row )
        {
            AutoAnsItemStWork autoAnsItemStWork = (AutoAnsItemStWork)row[ct_COL_AUTOANSITEMSTWORKOBJECT];
            
            // ���������\���ڂ̂ݍ����ւ���
            autoAnsItemStWork.AutoAnswerDiv = (int)row[ct_COL_AUTOANSWERDIV];
            autoAnsItemStWork.PriorityOrder = IntObjToInt(row[ct_COL_PRIORITYORDER]);
            

            // �V�K�ǉ��̎��͒ǉ����ڂ�ݒ肷��
            if ((int)row[ct_COL_NEWADDROWDIV] == (int)NewAddRowDiv.New)
            {
                autoAnsItemStWork.EnterpriseCode = this._enterpriseCode;
                autoAnsItemStWork.LogicalDeleteCode = (int)row[ct_COL_LOGICALDELETECODE]; // �_���폜�敪
                autoAnsItemStWork.SectionCode = row[ct_COL_SECTIONCODE].ToString(); // ���_�R�[�h
                autoAnsItemStWork.CustomerCode = (int)row[ct_COL_CUSTOMERCODE]; // ���Ӑ�R�[�h
                autoAnsItemStWork.GoodsMGroup = (int)row[ct_COL_GOODSMGROUP]; // ���i�����ރR�[�h
                autoAnsItemStWork.BLGoodsCode = (int)row[ct_COL_BLGOODSCODE]; // BL���i�R�[�h
                autoAnsItemStWork.GoodsMakerCd = (int)row[ct_COL_GOODSMAKERCD]; // ���i���[�J�[�R�[�h
                autoAnsItemStWork.PrmSetDtlNo2 = (int)row[ct_COL_PRMSETDTLNO2]; // �D�ǐݒ�ڍ׃R�[�h�Q
                autoAnsItemStWork.PrmSetDtlName2 = row[ct_COL_PRMSETDTLNAME2].ToString(); // �D�ǐݒ�ڍז��̂Q

                autoAnsItemStWork.SectionNm = row[ct_COL_SECTIONNM].ToString();  // ���_����
                autoAnsItemStWork.CustomerName = row[ct_COL_CUSTOMERNAME].ToString();    // ���Ӑ於��
                autoAnsItemStWork.GoodsMGroupName = row[ct_COL_GOODSMGROUPNAME].ToString();  // ���i�����ޖ���
                autoAnsItemStWork.BLGoodsName = row[ct_COL_BLGOODSNAME].ToString(); // BL���i�R�[�h����
                autoAnsItemStWork.MakerName = row[ct_COL_MAKERNAME].ToString();  // ���[�J�[����
            }

            return autoAnsItemStWork;
        }

        /// <summary>
        /// ���o�����N���X�����o�[�R�s�[����
        /// </summary>
        /// <param name="paraData"></param>
        /// <returns></returns>
        private AutoAnsItemStOrderWork CopyToAutoAnsItemStOrderWorkFromAutoAnsItemStOrder( AutoAnsItemStOrder paraData )
        {
            AutoAnsItemStOrderWork paraWork = new AutoAnsItemStOrderWork();
            
            # region [paraWork��paraData]
            paraWork.EnterpriseCode = paraData.EnterpriseCode;  // ��ƃR�[�h
            paraWork.SectionCode = paraData.SectionCode;  // ���_�R�[�h
            paraWork.St_CustomerCode = paraData.St_CustomerCode;  // �J�n���Ӑ�R�[�h
            paraWork.Ed_CustomerCode = paraData.Ed_CustomerCode;  // �I�����Ӑ�R�[�h
            paraWork.St_GoodsMGroup = paraData.St_GoodsMGroup;  // �J�n���i�����ރR�[�h
            paraWork.Ed_GoodsMGroup = paraData.Ed_GoodsMGroup;  // �I�����i�����ރR�[�h
            paraWork.St_BLGroupCode = paraData.St_BLGroupCode;  // �J�nBL�O���[�v�R�[�h
            paraWork.Ed_BLGroupCode = paraData.Ed_BLGroupCode;  // �I��BL�O���[�v�R�[�h
            paraWork.St_BLGoodsCode = paraData.St_BLGoodsCode;  // �J�nBL���i�R�[�h
            paraWork.Ed_BLGoodsCode = paraData.Ed_BLGoodsCode;  // �I��BL���i�R�[�h
            paraWork.St_GoodsMakerCd = paraData.St_GoodsMakerCd;  // �J�n���i���[�J�[�R�[�h
            paraWork.Ed_GoodsMakerCd = paraData.Ed_GoodsMakerCd;  // �I�����i���[�J�[�R�[�h
            # endregion
            
            return paraWork;
        }
        #endregion

        #region SearchProc �����������C���i�_���폜�܂ށj
        /// <summary>
        /// �����������C���i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃe�[�u��</param>
        /// <param name="AutoAnsItemStList">�����񓚕i�ڐݒ�I�u�W�F�N�g���X�g</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����񓚕i�ڐݒ�}�X�^�̕��������������s���܂��B</br>
        /// </remarks>
        private int SearchProc( AutoAnsItemStOrder paraData, out ArrayList retWorkList, ConstantManagement.LogicalMode logicalMode, out string message )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";
            retWorkList = null;

            try
            {
                _autoAnsItemStWorkList = null;
                //==========================================
                // �����񓚕i�ڐݒ�}�X�^�ǂݍ���
                //==========================================
                AutoAnsItemStOrderWork paraWork = CopyToAutoAnsItemStOrderWorkFromAutoAnsItemStOrder(paraData);

                // �����[�g�߂胊�X�g
                object autoAnsItemStWorkList = null;
                // �����񓚕i�ڐݒ�}�X�^����
                status = this._iAutoAnsItemStDB.Search(out autoAnsItemStWorkList, paraWork, 0, logicalMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retWorkList = (ArrayList)autoAnsItemStWorkList;
                    _autoAnsItemStWorkList = (ArrayList)autoAnsItemStWorkList;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }
        #endregion

        #region Read ��������
        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^�������������i�_���폜�܂܂Ȃ��j�����񓚕i�ڐݒ�}�X�����p
        /// </summary>
        /// <param name="autoAnsItemSt">�����p�����[�^�p</param>
        /// <param name="retList">�Ԓl�p���X�g</param>
        /// <returns></returns>
        public int Read2(AutoAnsItemSt autoAnsItemSt, ref List<AutoAnsItemSt> retList)
        {
            return Read2(autoAnsItemSt, ref retList, false);
        }

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^�������������i�_���폜�܂܂Ȃ��j�����񓚕i�ڐݒ�}�X�����p
        /// </summary>
        /// <param name="autoAnsItemSt">�����p�����[�^�p</param>
        /// <param name="retList">�Ԓl�p���X�g</param>
        /// <returns></returns>
        public int Read2(AutoAnsItemSt autoAnsItemSt, ref List<AutoAnsItemSt> retList,bool forPriority)
        {
            try
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string message;
                retList = new List<AutoAnsItemSt>();

                // ���o�����p�����[�^
                AutoAnsItemStWork autoAnsItemStWork = CopyToAutoAnsItemStWorkFromAutoAnsItemSt(autoAnsItemSt);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(autoAnsItemStWork);

                // ����
                ArrayList retWorkList;
                status = ReadProc2(parabyte, out retWorkList, ConstantManagement.LogicalMode.GetDataAll, out message, forPriority);

                if (status == 0)
                {
                    foreach (object obj in retWorkList)
                    {
                        if (obj is AutoAnsItemStWork)
                        {
                            AutoAnsItemStWork retWork = (obj as AutoAnsItemStWork);

                            // �N���X�������o�R�s�[
                            retList.Add(CopyToAutoAnsItemStFromAutoAnsItemStWork(retWork));
                        }
                    }
                }

                return status;
            }
            catch (Exception)
            {
                //�ʐM�G���[��-1��߂�
                retList.Clear();
                //�I�t���C������null���Z�b�g
                this._iAutoAnsItemStDB = null;
                return -1;
            }
        }

        /// <summary>
        /// �����������C���i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃe�[�u��</param>
        /// <param name="AutoAnsItemStList">�����񓚕i�ڐݒ�I�u�W�F�N�g���X�g</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����񓚕i�ڐݒ�}�X�^�̕��������������s���܂��B</br>
        /// </remarks>
        private int ReadProc2(byte[] paraData, out ArrayList retWorkList, ConstantManagement.LogicalMode logicalMode, out string message, bool forPriority)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";
            retWorkList = null;

            try
            {
                //==========================================
                // �����񓚕i�ڐݒ�}�X�^�ǂݍ���
                //==========================================
                // �����[�g�߂胊�X�g
                object autoAnsItemStWorkList = null;
                // �����񓚕i�ڐݒ�}�X�^����
                if (forPriority)
                {
                    status = this._iAutoAnsItemStDB.Read3(out autoAnsItemStWorkList, paraData, 0, logicalMode);
                }
                else
                {
                    status = this._iAutoAnsItemStDB.Read2(out autoAnsItemStWorkList, paraData, 0, logicalMode);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retWorkList = (ArrayList)autoAnsItemStWorkList;
                    _autoAnsItemStWorkList = (ArrayList)autoAnsItemStWorkList;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// �񋟗D�ǐݒ胊�X�g�擾
        /// </summary>
        public int GetOfferPrimesettingList(ref DataView dataView) 
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            object objret = null;
            int status = -1;

            IPrimeSettingDB offerPrimeSettingSearchDB = (IPrimeSettingDB)MediationPrimeSettingDB.GetPrimeSettingDB();
            DataTable PrimeSettingTable = CreateTable(PrimeSettingInfo.TABLENAME_PRIMESETTING);

            try
            {
                // �񋟗D�ǐݒ�擾
                status = offerPrimeSettingSearchDB.Search(out objret);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (PrmSettingWork wkPrimeSettingWork in (ArrayList)objret)       
                    {
                        DataRow primeSettingRow = PrimeSettingTable.NewRow();

                        primeSettingRow[COL_OFFERPRIMESETTING] = wkPrimeSettingWork;
                        primeSettingRow[COL_USERPRIMESETTING] = null;
                        primeSettingRow[COL_CHANGEFLAG] = false;                // �񋟂͕ύX�s��
                        primeSettingRow[COL_CHECKSTATE] = CheckState.Unchecked; // �񋟂͖��`�F�b�N�i�f�t�H���g�j
                        primeSettingRow[COL_ORIGINAL_CHECKSTATE] = CheckState.Unchecked; // �񋟂͖��`�F�b�N�i�f�t�H���g�j
                        
                        //�J�����Ƀf�[�^���Z�b�g
                        //�f�t�H���g�\�����ʂ̓��[�J�[�R�[�h��
                        primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER] = 0;   

                        //�\���敪�͂O�Œ�(�񋟂̏ꍇ�j
                        primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 0;
                        primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER] = wkPrimeSettingWork.DisplayOrder;
                        primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] = wkPrimeSettingWork.GoodsMGroup;        // ADD 2008/07/01
                        primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD] = wkPrimeSettingWork.PartsMakerCd;
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE] = wkPrimeSettingWork.TbsPartsCode;
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCDDERIVEDNO] = wkPrimeSettingWork.TbsPartsCdDerivedNo;
                        primeSettingRow[PrimeSettingInfo.COL_SELECTCODE] = wkPrimeSettingWork.PrmSetDtlNo1;
                        primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE] = wkPrimeSettingWork.PrmSetDtlNo2;
                        primeSettingRow[PrimeSettingInfo.COL_SECRETCODE] = wkPrimeSettingWork.SecretCode;

                        primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERFULLNAME] = "";
                        primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERHALFNAME] = "";
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSFULLNAME] = "";
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSHALFNAME] = "";

                        primeSettingRow[PrimeSettingInfo.COL_SELECTNAME] = wkPrimeSettingWork.PrmSetDtlName1;
                        primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDNAME] = wkPrimeSettingWork.PrmSetDtlName2;

                        primeSettingRow[PrimeSettingInfo.COL_PRMSETGROUP] = wkPrimeSettingWork.PrmSetGroup;

                        PrimeSettingTable.Rows.Add(primeSettingRow);

                        
                        if (!wkPrimeSettingWork.PrmSetGroup.Equals(0))
                        {
                            Debug.WriteLine("�D�ǐݒ�O���[�v�F" + ((int)primeSettingRow[PrimeSettingInfo.COL_PRMSETGROUP]).ToString() + " <- " + wkPrimeSettingWork.PrmSetGroup.ToString());
                            Debug.WriteLine("���F" + wkPrimeSettingWork.GoodsMGroup.ToString() + ", M�F" + wkPrimeSettingWork.PartsMakerCd.ToString() + ", B�F" + wkPrimeSettingWork.TbsPartsCode.ToString());
                        }
                    }

                    dataView = new DataView(PrimeSettingTable);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// �e�[�u���쐬
        /// </summary>
        private DataTable CreateTable(string TableName)
        {
            DataTable table = new DataTable(TableName);

            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PARTSMAKERCD, typeof(int), "���[�J�[�R�[�h"));	//���[�J�[�R�[�h
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PARTSMAKERFULLNAME, typeof(string), "���[�J�["));	//�S�p���[�J�[��
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PARTSMAKERHALFNAME, typeof(string), "Ұ��"));	//���p���[�J�[��
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSCODE, typeof(int), "BL����"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSCDDERIVEDNO, typeof(int), "BL�R�[�h�}��"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSFULLNAME, typeof(string), "�i�ږ�"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSHALFNAME, typeof(string), "�i�ږ�(���p)"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_MIDDLEGENRECODE, typeof(int), "������"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_MIDDLEGENRENAME, typeof(string), "�����ޖ�"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SECRETCODE, typeof(int), "�V�[�N���b�g�R�[�h"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SELECTCODE, typeof(int), "�Z���N�g�R�[�h"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SELECTNAME, typeof(string), "�Z���N�g"));           
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRIMEKINDCODE, typeof(int), "�D�ǎ�ʃR�[�h"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRIMEKINDNAME, typeof(string), "���"));            
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SUPPLIERCD, typeof(int), "�d����R�[�h"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SUPPLIERCDDERIVEDNO, typeof(int), "�d����R�[�h�}��"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SUPPLIERNAME, typeof(string), "�d���於��"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_MAKERDISPORDER, typeof(int), "�\������"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_DISPLAYORDER, typeof(int), "�\����"));
            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRIMEDISPLAYCODE, typeof(int), ""));	//�\���敪

            table.Columns.Add(CreateColumn(COL_CHANGEFLAG, typeof(bool), ""));	//�ύX�t���O
            table.Columns.Add(CreateColumn(COL_CHECKSTATE, typeof(CheckState), ""));	//�`�F�b�N
            table.Columns.Add(CreateColumn(COL_ORIGINAL_CHECKSTATE, typeof(CheckState), ""));	//�`�F�b�N
            table.Columns.Add(CreateColumn(COL_OFFERPRIMESETTING, typeof(object), ""));	//�񋟗D�ǐݒ�N���X
            table.Columns.Add(CreateColumn(COL_USERPRIMESETTING, typeof(object), ""));	//���[�U�[�D�ǐݒ�N���X

            table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRMSETGROUP, typeof(int), "�D�ǐݒ�O���[�v")); // 
            return table;
        }
        /// <summary>
        /// �f�[�^�e�[�u���̗���쐬����
        /// </summary>
        /// <param name="columnName">��</param>
        /// <param name="type">�^</param>
        /// <param name="caption">�L���v�V����</param>
        /// <returns></returns>
        private DataColumn CreateColumn(string columnName, Type type, string caption)
        {
            DataColumn dc = new DataColumn();

            dc.ColumnName = columnName;
            dc.DataType = type;
            dc.Caption = caption;

            return dc;
        }

        #endregion


        #region DataTable����

        // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��18,��19 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �s�ǉ������@�����񓚕i�ڐݒ�}�X�����ꗗ�p
        /// </summary>
        /// <returns></returns>
        public void RowAdd()
        {
            // �V�K�ǉ��s�̒ǉ�
            DataRow newRow = this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST].NewRow();
            AutoAnsItemStWork newRetWork = new AutoAnsItemStWork();
            CopyToDataRowFromAutoAnsItemStWorkNewAdd(ref newRow, newRetWork);
            _dataTableList.Tables[ct_TABLE_AUTOANSITEMST].Rows.Add(newRow);

            // �e�[�u���X�V��C�x���g
            if (AfterTableUpdate != null)
            {
                AfterTableUpdate(this, new EventArgs());
            }
        }
        #region ���\�[�X
        //public int RowAdd()
        //{
        //    int status = 0;

        //    // �V�K�ǉ��s�̒ǉ�
        //    DataRow newRow = this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST].NewRow();
        //    AutoAnsItemStWork newRetWork = new AutoAnsItemStWork();
        //    CopyToDataRowFromAutoAnsItemStWorkNewAdd(ref newRow, newRetWork);
        //    _dataTableList.Tables[ct_TABLE_AUTOANSITEMST].Rows.Add(newRow);

        //    // �e�[�u���X�V��C�x���g
        //    if (AfterTableUpdate != null)
        //    {
        //        AfterTableUpdate(this, new EventArgs());
        //    }

        //    return status;
        //}
        #endregion
        // UPD 2012/11/13 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��18,��19 ---------<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// �s�}�������@�����񓚕i�ڐݒ�}�X�����ꗗ�p
        /// </summary>
        /// <returns></returns>
        public int RowInsert(string filter, string filterBefore, string sectionCode, int customerCode, int  makerCode, int goodsMGroup, int blCode)
        {
            string deleteFilter = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            DataView OfferPrimeSettingDataView = null;
            AutoAnsItemStWork deleteAutoAnsItemStWork = new AutoAnsItemStWork();

            // �ύX�O���͍s�폜
            status = LogicalDeleteFilter(filterBefore, out deleteAutoAnsItemStWork);

            // �D�ǐݒ�}�X�^�擾
            status = GetOfferPrimesettingList(ref OfferPrimeSettingDataView);

            // ������蒊�o
            OfferPrimeSettingDataView.RowFilter = filter;

            // �����l
            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            // ��ʂ����݂��鎞
            // --- DEL 2012/11/22 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��77 --------->>>>>>>>>>>>>>>>>>>>>>>>
            #region del
            //// --- UPD 2012/11/22 �O�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��58 --------->>>>>>>>>>>>>>>>>>>>>>>>
            ////if (OfferPrimeSettingDataView.Count != 0)
            //if (OfferPrimeSettingDataView.Count > 1)
            //// --- UPD 2012/11/22 �O�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��58 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            //{
            //    // �V�K�s�폜 + ���͍s�폜
            //    deleteFilter = string.Format("{0}='' AND {1}=0 AND {2}=0 AND {3}=0 AND {4}=0 AND {5}={6}",
            //                                  ct_COL_SECTIONCODE.ToString(),
            //                                  ct_COL_CUSTOMERCODE.ToString(), 
            //                                  ct_COL_GOODSMGROUP.ToString(),
            //                                  ct_COL_BLGOODSCODE.ToString(), 
            //                                  ct_COL_GOODSMAKERCD.ToString(), 
            //                                  ct_COL_NEWADDROWALLOWSAVE.ToString(), (int)NewAddRowAllowSave.No
            //                                );
            //    status = LogicalDeleteFilter(deleteFilter, out deleteAutoAnsItemStWork);

            //    deleteFilter = string.Format("{0}='{1}' AND {2}={3} AND {4}={5} AND {6}={7} AND {8}={9} AND {10}={11}",
            //                                  ct_COL_SECTIONCODE.ToString(), sectionCode.Trim(),
            //                                  ct_COL_CUSTOMERCODE.ToString(), customerCode,
            //                                  ct_COL_GOODSMGROUP.ToString(), goodsMGroup,
            //                                  ct_COL_BLGOODSCODE.ToString(), blCode,
            //                                  ct_COL_GOODSMAKERCD.ToString(), makerCode,
            //                                  ct_COL_NEWADDROWDIV.ToString(), (int)NewAddRowDiv.New
            //                                );
            //    status = LogicalDeleteFilter(deleteFilter, out deleteAutoAnsItemStWork);

            //    foreach (DataRow dr in OfferPrimeSettingDataView.Table.Select(filter))
            //    {
            //        // �s�ǉ�����
            //        DataRow newRow = this._dataTableList.Tables[ct_TABLE_AUTOANSITEMST].NewRow();
            //        AutoAnsItemStWork newRetWork = new AutoAnsItemStWork();
            //        // �����l�ݒ�
            //        newRetWork.SectionCode = sectionCode;
            //        newRetWork.SectionNm = deleteAutoAnsItemStWork.SectionNm;
            //        newRetWork.CustomerCode = customerCode;
            //        newRetWork.CustomerName = deleteAutoAnsItemStWork.CustomerName;
            //        newRetWork.GoodsMakerCd = makerCode;
            //        newRetWork.MakerName = deleteAutoAnsItemStWork.MakerName;
            //        newRetWork.GoodsMGroup = goodsMGroup;
            //        newRetWork.GoodsMGroupName = deleteAutoAnsItemStWork.GoodsMGroupName;
            //        newRetWork.BLGoodsCode = blCode;
            //        newRetWork.BLGoodsName = deleteAutoAnsItemStWork.BLGoodsName;
            //        newRetWork.PrmSetDtlNo2 = int.Parse(dr[PrimeSettingInfo.COL_PRIMEKINDCODE].ToString());
            //        newRetWork.PrmSetDtlName2 = dr[PrimeSettingInfo.COL_PRIMEKINDNAME].ToString();

            //        CopyToDataRowFromAutoAnsItemStWork(ref newRow, newRetWork);

            //        // �s�}���Ȃ̂œ��͍ς݂̐V�K�ǉ��s�Ƃ���


            //        newRow[ct_COL_NEWADDROWALLOWSAVE] = NewAddRowAllowSave.Yes;
            //        newRow[ct_COL_NEWADDROWDIV] = NewAddRowDiv.New;
            //        // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��36 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //        // newRow[ct_COL_SECTIONCODE_SORT] = GetSortValue(sectionCode); // ���_�R�[�h
            //        // �ҏW���̐V�K�ǉ��s�͉�����Q�Ԗڂɕ\��
            //        newRow[ct_COL_SECTIONCODE_SORT] = "YY"; // ���_�R�[�h
            //        // UPD 2012/11/16 T.Yoshioka 2012/12/12�z�M �V�X�e���e�X�g��Q��36 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            //        newRow[ct_COL_CUSTOMERCODE_SORT] = Int32.MaxValue; // ���Ӑ�R�[�h ���ŉ��s�ɕ\�����邽��MAX�l��ݒ肷��
            //        _dataTableList.Tables[ct_TABLE_AUTOANSITEMST].Rows.Add(newRow);
            //    }
            //    // �V�K���͍s�ǉ�
            //    RowAdd();
            //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //}
            #endregion
            // --- DEL 2012/11/22 �g�� 2012/12/12�z�M�� �V�X�e���e�X�g��Q��77 ---------<<<<<<<<<<<<<<<<<<<<<<


            // �e�[�u���X�V��C�x���g
            if (AfterTableUpdate != null)
            {
                AfterTableUpdate(this, new EventArgs());
            }

            return status;
        }

        #endregion

        #region ���[�e�B���e�B
        /// <summary>
        /// �����l��z�肷��I�u�W�F�N�g�̐����l�ւ̃L���X�g
        /// NULL�ł����0��Ԃ�
        /// </summary>
        /// <param name="target">�L���X�g�Ώ�</param>
        /// <returns>Int�^</returns>
        /// <remarks>
        /// <br>Note        : �L���X�g�Ώۂ�Int�^�ɕϊ����܂��B</br>
        /// </remarks>
        private int IntObjToInt(object target)
        {
            if ((target == DBNull.Value) || (target == null) || (target.ToString() == ""))
            {
                return 0;
            }
            else
            {
                return (int)target;
            }
        }
        #endregion

    }
}
