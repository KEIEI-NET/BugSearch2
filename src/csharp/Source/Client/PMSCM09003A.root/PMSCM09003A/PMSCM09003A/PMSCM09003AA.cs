//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : SCM�i�ڐݒ�}�X�^�����e�i���X
// �v���O�����T�v   : SCM�i�ڐݒ�}�X�^�̑�����s���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� ���b
// �� �� ��  2009/05/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H��
// �C �� ��  2009/07/14  �C�����e : �T�[�o�Ή�(LoginInfoAcquisition.Employee.BelongSectionCode�͎g�p�s��)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �C �� ��  2012/04/12  �C�����e : ���x����
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �r�b�l�i�ڐݒ�}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �r�b�l�i�ڐݒ�}�X�^�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2009/05/11</br>
    /// <br></br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class SCMPrtSettingAcs
    {
        #region public const
        //----------------------------------------
        // SCM�i�ڐݒ�}�X�^�萔��`
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
        /// <summary>���i�ԍ�</summary>
        public const string ct_COL_GOODSNO = "GoodsNo";
        /// <summary>�����񓚋敪</summary>
        public const string ct_COL_AUTOANSWERDIV = "AutoAnswerDiv";

        /// <summary>�����񓚋敪(�O��ޔ�)</summary>
        public const string ct_COL_AUTOANSWERDIV_BACKUP = "AutoAnswerDiv_Backup";

        /// <summary>���_����</summary>
        public const string ct_COL_SECTIONNM = "SectionNm";
        /// <summary>���Ӑ於��</summary>
        public const string ct_COL_CUSTOMERNAME = "CustomerName";
        /// <summary>���i�����ޖ���</summary>
        public const string ct_COL_GOODSMGROUPNAME = "GoodsMGroupName";
        /// <summary>BL�O���[�v����</summary>
        public const string ct_COL_BLGROUPNAME = "BLGroupName";
        /// <summary>BL���i�R�[�h����</summary>
        public const string ct_COL_BLGOODSNAME = "BLGoodsName";
        /// <summary>���[�J�[����</summary>
        public const string ct_COL_MAKERNAME = "MakerName";
        /// <summary>���i����</summary>
        public const string ct_COL_GOODSNAME = "GoodsName";
        /// <summary>�d����R�[�h</summary>
        public const string ct_COL_SUPPLIERCD = "SupplierCd";
        /// <summary>�d���旪��</summary>
        public const string ct_COL_SUPPLIERSNM = "SupplierSnm";

        /// <summary>BL�O���[�v�R�[�h</summary>
        public const string ct_COL_BLGROUPCODE = "BLGroupCode";

        # region [�\�[�g�p]
        /// <summary>���_�R�[�h</summary>
        public const string ct_COL_SECTIONCODE_SORT = "SectionCode_Sort";
        /// <summary>���Ӑ�R�[�h</summary>
        public const string ct_COL_CUSTOMERCODE_SORT = "CustomerCode_Sort";
        /// <summary>�d����R�[�h</summary>
        public const string ct_COL_SUPPLIERCD_SORT = "SupplierCd_Sort";
        /// <summary>���i���[�J�[�R�[�h</summary>
        public const string ct_COL_GOODSMAKERCD_SORT = "GoodsMakerCd_Sort";
        /// <summary>���i�����ރR�[�h</summary>
        public const string ct_COL_GOODSMGROUP_SORT = "GoodsMGroup_Sort";
        /// <summary>BL�O���[�v�R�[�h</summary>
        public const string ct_COL_BLGROUPCODE_SORT = "BLGroupCode_Sort";
        /// <summary>BL���i�R�[�h</summary>
        public const string ct_COL_BLGOODSCODE_SORT = "BLGoodsCode_Sort";
        # endregion

        /// <summary>�_���폜��(�\���p)</summary>
        public const string ct_COL_LOGICALDELETEDATE = "LogicalDeleteDate";
        /// <summary>SCM�i�ڐݒ�}�X�^work�I�u�W�F�N�g(�����ێ��p)</summary>
        public const string ct_COL_SCMPRTSETTINGWORKOBJECT = "SCMPrtSettingWorkObject";
        //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public object _SCMPrtSetingWorkList = null; // SCM�i�ڐݒ胊���[�g
        //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<




        // �e�[�u����
        /// <summary>SCM�i�ڐݒ�e�[�u��</summary>
        public const string ct_TABLE_SCMPRTSETTING = "SCMPrtSettingTable";

        #endregion

        #region Private Members
        // ===================================================================================== //
        // �v���C�x�[�g�����o�[
        // ===================================================================================== //
        // �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        private ISCMPrtSettingDB _iSCMPrtSetingDB = null; // SCM�i�ڐݒ胊���[�g

        private DataSet _dataTableList = null;
        private DataView _dataView = null;
        private bool _excludeLogicalDeleteFromView;

        private GoodsAcs _goodsAcs;

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

        #region Construcstor
        /// <summary>
        /// SCM�i�ڐݒ�}�X�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : SCM�i�ڐݒ�}�X�^�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        public SCMPrtSettingAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iSCMPrtSetingDB = (ISCMPrtSettingDB)MediationSCMPrtSettingDB.GetSCMPrtSettingDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iSCMPrtSetingDB = null;
            }

            // �_���폜���O����
            _excludeLogicalDeleteFromView = true;
        }

        /// <summary>
        /// SCM�i�ڐݒ�}�X�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : SCM�i�ڐݒ�}�X�^�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30434 ���</br>
        /// <br>Date       : 2009/07/14</br>
        /// </remarks>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        public SCMPrtSettingAcs(string enterpriseCode, string sectionCode) : this()
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iSCMPrtSetingDB == null)
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
                _dataTableList.Tables[ct_TABLE_SCMPRTSETTING].Clear();
            }
        }

        /// <summary>
        /// �D�揇�ʕt��SCM�i�ڐݒ�}�X�^�������������i�_���폜�܂܂Ȃ��jSCM�i�ڐݒ�}�X�����ȊO�p
        /// </summary>
        /// <param name="paraData"></param>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        public int Search(SCMPrtSettingOrder paraData, out List<SCMPrtSetting> retList, out string message)
        {
            // 1�p����
            SCMPrtSettingOrder searchingByLump = new SCMPrtSettingOrder();
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
            List<SCMPrtSetting> firstSearchedList = null;
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
                    delegate(SCMPrtSetting scmPrtSetting)
                    {
                        return IsPriority1(scmPrtSetting, paraData);
                    }
                );
                if (retList != null && retList.Count > 0)
                {
                    message = string.Format(
                        "�D�揇��1:���Ӑ�(={0})�{���[�J�[(={1})�{�i��(={2}) �Ō�������܂����B",
                        paraData.St_CustomerCode,
                        paraData.St_GoodsMakerCd,
                        paraData.GoodsNo
                    );
                    return status;
                }

                #endregion

                #region �D�揇��2:���Ӑ�{���[�J�[�{BL�R�[�h

                retList = firstSearchedList.FindAll(
                    delegate(SCMPrtSetting scmPrtSetting)
                    {
                        return IsPriority2(scmPrtSetting, paraData);
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
                    delegate(SCMPrtSetting scmPrtSetting)
                    {
                        return IsPriority3(scmPrtSetting, paraData);
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
                    delegate(SCMPrtSetting scmPrtSetting)
                    {
                        return IsPriority4(scmPrtSetting, paraData);
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
                    delegate(SCMPrtSetting scmPrtSetting)
                    {
                        return IsPriority5(scmPrtSetting, paraData);
                    }
                );
                if (retList != null && retList.Count > 0)
                {
                    message = string.Format(
                        "�D�揇��5:���_(={0})�{���[�J�[(={1})�{�i��(={2}) �Ō�������܂����B",
                        paraData.SectionCode,
                        paraData.St_GoodsMakerCd,
                        paraData.GoodsNo
                    );
                    return status;
                }

                #endregion

                #region �D�揇��6:���_�{���[�J�[�{BL�R�[�h

                retList = firstSearchedList.FindAll(
                    delegate(SCMPrtSetting scmPrtSetting)
                    {
                        return IsPriority6(scmPrtSetting, paraData);
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
                    delegate(SCMPrtSetting scmPrtSetting)
                    {
                        return IsPriority7(scmPrtSetting, paraData);
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
                    delegate(SCMPrtSetting scmPrtSetting)
                    {
                        return IsPriority8(scmPrtSetting, paraData);
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
        /// �D�揇��1:���Ӑ�{���[�J�[�{�i�Ԃł��邩���f���܂��B
        /// </summary>
        /// <param name="scmPrtSetting">SCM�i�ڋ�ݒ�</param>
        /// <param name="scmPrtSettingOrder">SCM�i�ڋ�ݒ����</param>
        /// <returns>
        /// <c>true</c> :�D�揇��1�ł��B<br/>
        /// <c>false</c>:�D�揇��1�ł͂���܂���B
        /// </returns>
        private static bool IsPriority1(SCMPrtSetting scmPrtSetting, SCMPrtSettingOrder scmPrtSettingOrder)
        {
            return (
                scmPrtSetting.CustomerCode >= scmPrtSettingOrder.St_CustomerCode
                    &&
                scmPrtSetting.CustomerCode <= scmPrtSettingOrder.Ed_CustomerCode
                    &&
                scmPrtSetting.GoodsMakerCd >= scmPrtSettingOrder.St_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsMakerCd <= scmPrtSettingOrder.Ed_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsNo.Equals(scmPrtSettingOrder.GoodsNo)
            );
        }

        /// <summary>
        /// �D�揇��2:���Ӑ�{���[�J�[�{BL�R�[�h�ł��邩���f���܂��B
        /// </summary>
        /// <param name="scmPrtSetting">SCM�i�ڋ�ݒ�</param>
        /// <param name="scmPrtSettingOrder">SCM�i�ڋ�ݒ����</param>
        /// <returns>
        /// <c>true</c> :�D�揇��2�ł��B<br/>
        /// <c>false</c>:�D�揇��2�ł͂���܂���B
        /// </returns>
        private static bool IsPriority2(SCMPrtSetting scmPrtSetting, SCMPrtSettingOrder scmPrtSettingOrder)
        {
            return (
                scmPrtSetting.CustomerCode >= scmPrtSettingOrder.St_CustomerCode
                    &&
                scmPrtSetting.CustomerCode <= scmPrtSettingOrder.Ed_CustomerCode
                    &&
                scmPrtSetting.GoodsMakerCd >= scmPrtSettingOrder.St_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsMakerCd <= scmPrtSettingOrder.Ed_GoodsMakerCd
                    &&
                scmPrtSetting.BLGoodsCode >= scmPrtSettingOrder.St_BLGoodsCode
                    &&
                scmPrtSetting.BLGoodsCode <= scmPrtSettingOrder.Ed_BLGoodsCode
            );
        }

        /// <summary>
        /// �D�揇��3:���Ӑ�{���[�J�[�{�����ރR�[�h�ł��邩���f���܂��B
        /// </summary>
        /// <param name="scmPrtSetting">SCM�i�ڋ�ݒ�</param>
        /// <param name="scmPrtSettingOrder">SCM�i�ڋ�ݒ����</param>
        /// <returns>
        /// <c>true</c> :�D�揇��3�ł��B<br/>
        /// <c>false</c>:�D�揇��3�ł͂���܂���B
        /// </returns>
        private static bool IsPriority3(SCMPrtSetting scmPrtSetting, SCMPrtSettingOrder scmPrtSettingOrder)
        {
            return (
                scmPrtSetting.CustomerCode >= scmPrtSettingOrder.St_CustomerCode
                    &&
                scmPrtSetting.CustomerCode <= scmPrtSettingOrder.Ed_CustomerCode
                    &&
                scmPrtSetting.GoodsMakerCd >= scmPrtSettingOrder.St_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsMakerCd <= scmPrtSettingOrder.Ed_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsMGroup >= scmPrtSettingOrder.St_GoodsMGroup
                    &&
                scmPrtSetting.GoodsMGroup <= scmPrtSettingOrder.Ed_GoodsMGroup
            );
        }

        /// <summary>
        /// �D�揇��4:���Ӑ�{���[�J�[�ł��邩���f���܂��B
        /// </summary>
        /// <param name="scmPrtSetting">SCM�i�ڋ�ݒ�</param>
        /// <param name="scmPrtSettingOrder">SCM�i�ڋ�ݒ����</param>
        /// <returns>
        /// <c>true</c> :�D�揇��4�ł��B<br/>
        /// <c>false</c>:�D�揇��4�ł͂���܂���B
        /// </returns>
        private static bool IsPriority4(SCMPrtSetting scmPrtSetting, SCMPrtSettingOrder scmPrtSettingOrder)
        {
            if (
                scmPrtSetting.CustomerCode >= scmPrtSettingOrder.St_CustomerCode
                    &&
                scmPrtSetting.CustomerCode <= scmPrtSettingOrder.Ed_CustomerCode
                    &&
                scmPrtSetting.GoodsMakerCd >= scmPrtSettingOrder.St_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsMakerCd <= scmPrtSettingOrder.Ed_GoodsMakerCd
            )
            {
                return scmPrtSetting.GoodsMGroup.Equals(0) && scmPrtSetting.BLGoodsCode.Equals(0) && string.IsNullOrEmpty(scmPrtSetting.GoodsNo.Trim());
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// �D�揇��5:���_�{���[�J�[�{�i�Ԃł��邩���f���܂��B
        /// </summary>
        /// <param name="scmPrtSetting">SCM�i�ڋ�ݒ�</param>
        /// <param name="scmPrtSettingOrder">SCM�i�ڋ�ݒ����</param>
        /// <returns>
        /// <c>true</c> :�D�揇��5�ł��B<br/>
        /// <c>false</c>:�D�揇��5�ł͂���܂���B
        /// </returns>
        private static bool IsPriority5(SCMPrtSetting scmPrtSetting, SCMPrtSettingOrder scmPrtSettingOrder)
        {
            return (
                scmPrtSetting.SectionCode.Trim().Equals(scmPrtSettingOrder.SectionCode.Trim())
                    &&
                scmPrtSetting.GoodsMakerCd >= scmPrtSettingOrder.St_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsMakerCd <= scmPrtSettingOrder.Ed_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsNo.Equals(scmPrtSettingOrder.GoodsNo)
            );
        }

        /// <summary>
        /// �D�揇��6:���_�{���[�J�[�{BL�R�[�h�ł��邩���f���܂��B
        /// </summary>
        /// <param name="scmPrtSetting">SCM�i�ڋ�ݒ�</param>
        /// <param name="scmPrtSettingOrder">SCM�i�ڋ�ݒ����</param>
        /// <returns>
        /// <c>true</c> :�D�揇��6�ł��B<br/>
        /// <c>false</c>:�D�揇��6�ł͂���܂���B
        /// </returns>
        private static bool IsPriority6(SCMPrtSetting scmPrtSetting, SCMPrtSettingOrder scmPrtSettingOrder)
        {
            return (
                scmPrtSetting.SectionCode.Trim().Equals(scmPrtSettingOrder.SectionCode.Trim())
                    &&
                scmPrtSetting.GoodsMakerCd >= scmPrtSettingOrder.St_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsMakerCd <= scmPrtSettingOrder.Ed_GoodsMakerCd
                    &&
                scmPrtSetting.BLGoodsCode >= scmPrtSettingOrder.St_BLGoodsCode
                    &&
                scmPrtSetting.BLGoodsCode <= scmPrtSettingOrder.Ed_BLGoodsCode
            );
        }

        /// <summary>
        /// �D�揇��7:���_�{���[�J�[�{�����ރR�[�h�ł��邩���f���܂��B
        /// </summary>
        /// <param name="scmPrtSetting">SCM�i�ڋ�ݒ�</param>
        /// <param name="scmPrtSettingOrder">SCM�i�ڋ�ݒ����</param>
        /// <returns>
        /// <c>true</c> :�D�揇��7�ł��B<br/>
        /// <c>false</c>:�D�揇��7�ł͂���܂���B
        /// </returns>
        private static bool IsPriority7(SCMPrtSetting scmPrtSetting, SCMPrtSettingOrder scmPrtSettingOrder)
        {
            return (
                scmPrtSetting.SectionCode.Trim().Equals(scmPrtSettingOrder.SectionCode.Trim())
                    &&
                scmPrtSetting.GoodsMakerCd >= scmPrtSettingOrder.St_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsMakerCd <= scmPrtSettingOrder.Ed_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsMGroup >= scmPrtSettingOrder.St_GoodsMGroup
                    &&
                scmPrtSetting.GoodsMGroup <= scmPrtSettingOrder.Ed_GoodsMGroup
            );
        }

        /// <summary>
        /// �D�揇��8:���_�{���[�J�[�ł��邩���f���܂��B
        /// </summary>
        /// <param name="scmPrtSetting">SCM�i�ڋ�ݒ�</param>
        /// <param name="scmPrtSettingOrder">SCM�i�ڋ�ݒ����</param>
        /// <returns>
        /// <c>true</c> :�D�揇��8�ł��B<br/>
        /// <c>false</c>:�D�揇��8�ł͂���܂���B
        /// </returns>
        private static bool IsPriority8(SCMPrtSetting scmPrtSetting, SCMPrtSettingOrder scmPrtSettingOrder)
        {
            if (
                scmPrtSetting.SectionCode.Trim().Equals(scmPrtSettingOrder.SectionCode.Trim())
                    &&
                scmPrtSetting.GoodsMakerCd >= scmPrtSettingOrder.St_GoodsMakerCd
                    &&
                scmPrtSetting.GoodsMakerCd <= scmPrtSettingOrder.Ed_GoodsMakerCd
            )
            {
                return scmPrtSetting.GoodsMGroup.Equals(0) && scmPrtSetting.BLGoodsCode.Equals(0) && string.IsNullOrEmpty(scmPrtSetting.GoodsNo.Trim());
            }
            else
            {
                return false;
            }
        }

        #endregion // �D�揇�ʂ̔��f

        /// <summary>
        /// SCM�i�ڐݒ�}�X�^�������������i�_���폜�܂܂Ȃ��jSCM�i�ڐݒ�}�X�����ȊO�p
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="scmPrtSettingList">SCM�i�ڐݒ�I�u�W�F�N�g���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SCM�i�ڐݒ�}�X�^���X�g�̏����Ɉ�v�����f�[�^���������܂��B�_���폜�f�[�^�͒��o�ΏۊO</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2009.02.11</br>
        /// </remarks>
        private int SearchSimply( SCMPrtSettingOrder paraData, out List<SCMPrtSetting> retList, out string message )
        {
            //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //�p�����[�^�̎d����R�[�h��0�̏ꍇ�͏��i�}�X�^�A�N�Z�X�N���X�͓ǂݍ��܂Ȃ�
            if (paraData.St_SupplierCd != 0 || paraData.Ed_SupplierCd != 0)
            {
            //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                if (_goodsAcs == null)
              {
                  string msg;
                  _goodsAcs = new GoodsAcs(SectionCode);
                  _goodsAcs.SearchInitial( paraData.EnterpriseCode, SectionCode.Trim(), out msg );
              }
            //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            }
            //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // ����
            ArrayList retWorkList;
            int status = this.SearchProc( paraData, out retWorkList, ConstantManagement.LogicalMode.GetData0, out message );

            // ���ʊi�[
            retList = new List<SCMPrtSetting>();
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retWorkList != null )
            {
                foreach ( object obj in retWorkList )
                {
                    if ( obj is SCMPrtSettingWork )
                    {
                        SCMPrtSettingWork retWork = (obj as SCMPrtSettingWork);

                        //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //�p�����[�^�̎d����R�[�h��0�̏ꍇ�͏��i�}�X�^�A�N�Z�X�N���X�͓ǂݍ��܂Ȃ�
                        if (paraData.St_SupplierCd != 0 || paraData.Ed_SupplierCd != 0)
                        {
                        //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            // ���i�Ǘ������d������擾
                            GoodsUnitData goodsUnitData = GetGoodsMngInfo( retWork );
                             
                            // �d����͈͔���
                            if ( goodsUnitData.SupplierCd < paraData.St_SupplierCd ||
                                 (goodsUnitData.SupplierCd > paraData.Ed_SupplierCd && paraData.Ed_SupplierCd != 0) )
                            {
                                continue;
                            }
                            // �l���Z�b�g
                            SCMPrtSetting scmPrtSetting = CopyToSCMPrtSettingFromSCMPrtSettingWork(retWork);
                            if (goodsUnitData != null)
                            {
                                scmPrtSetting.SupplierCd = goodsUnitData.SupplierCd;
                                scmPrtSetting.SupplierSnm = goodsUnitData.SupplierSnm;
                            }
                            retList.Add(scmPrtSetting);
                        //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        }
                        else
                        {
                            // �l���Z�b�g
                            SCMPrtSetting scmPrtSetting = CopyToSCMPrtSettingFromSCMPrtSettingWork(retWork);
                            retList.Add(scmPrtSetting);
                        }
                        //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
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
            _goodsAcs = null;
            this.Clear();
        }

        /// <summary>
        /// SCM�i�ڐݒ�}�X�^�������������i�_���폜�܂܂Ȃ��jSCM�i�ڐݒ�}�X�����p
        /// </summary>
        /// <param name="paraData"></param>
        /// <param name="retList"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int Search( SCMPrtSettingOrder paraData, out string message )
        {
            if ( _goodsAcs == null )
            {
                string msg;
                _goodsAcs = new GoodsAcs(SectionCode);
                _goodsAcs.SearchInitial( paraData.EnterpriseCode, SectionCode.Trim(), out msg );
            }

            // ������/�N���A
            this.Clear();

            // ����
            ArrayList retWorkList;
            int status = SearchProc( paraData, out retWorkList, ConstantManagement.LogicalMode.GetDataAll, out message );

            // ���ʊi�[
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retWorkList != null )
            {
                foreach ( object obj in retWorkList )
                {
                    if ( obj is SCMPrtSettingWork )
                    {
                        SCMPrtSettingWork retWork = (obj as SCMPrtSettingWork);

                        // �A�N�Z�X�N���X����DataTable�ɒǉ�
                        DataRow row = this._dataTableList.Tables[ct_TABLE_SCMPRTSETTING].NewRow();

                        // ���i�Ǘ������d������擾
                        GoodsUnitData goodsUnitData = GetGoodsMngInfo( retWork );

                        // �d����͈͔���
                        if ( goodsUnitData.SupplierCd < paraData.St_SupplierCd ||
                             (goodsUnitData.SupplierCd > paraData.Ed_SupplierCd && paraData.Ed_SupplierCd != 0) )
                        {
                            continue;
                        }

                        // �l���Z�b�g
                        CopyToDataRowFromSCMPrtSettingWork( ref row, retWork, goodsUnitData );
                        _dataTableList.Tables[ct_TABLE_SCMPRTSETTING].Rows.Add( row );
                    }
                }
            }
            if ( _dataTableList.Tables[ct_TABLE_SCMPRTSETTING].Rows.Count == 0 )
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }


            // �e�[�u���X�V��C�x���g
            if ( AfterTableUpdate != null )
            {
                AfterTableUpdate( this, new EventArgs() );
            }

            return status;
        }

        /// <summary>
        /// �}�X�����������R�[�h�擾����
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks>SCM�i�ڐݒ�}�X�����Ŏg�p����ꍇ�iDataTable�Ɍ��ʊi�[�ς݂̏ꍇ�j�̂ݑΉ����܂�</remarks>
        public SCMPrtSetting GetRecordForMaintenance( Guid guid )
        {
            SCMPrtSettingWork scmPrtSettingWork = null;

            if ( _dataTableList != null )
            {
                DataView view = new DataView( this._dataTableList.Tables[ct_TABLE_SCMPRTSETTING] );
                view.RowFilter = string.Format( "{0}='{1}'", ct_COL_FILEHEADERGUID, guid );

                if ( view.Count > 0 )
                {
                    scmPrtSettingWork = CopyToSCMPrtSettingWorkFromDataRow( view[0].Row );
                }
            }

            // �Y�������Ȃ��f�[�^
            if ( scmPrtSettingWork == null )
            {
                scmPrtSettingWork = new SCMPrtSettingWork();
            }

            return this.CopyToSCMPrtSettingFromSCMPrtSettingWork( scmPrtSettingWork );
        }
        /// <summary>
        /// �}�X�����������R�[�h�擾����
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks>SCM�i�ڐݒ�}�X�����Ŏg�p����ꍇ�iDataTable�Ɍ��ʊi�[�ς݂̏ꍇ�j�̂ݑΉ����܂�</remarks>
        public DataRow GetRowForMaintenance( Guid guid )
        {
            DataRow row = null;
            if ( _dataTableList != null )
            {
                DataView view = new DataView( this._dataTableList.Tables[ct_TABLE_SCMPRTSETTING] );
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
        /// ���i�Ǘ����擾����
        /// </summary>
        /// <param name="scmPrtSettngWork"></param>
        /// <returns></returns>
        private GoodsUnitData GetGoodsMngInfo( SCMPrtSettingWork scmPrtSettngWork )
        {
            GoodsUnitData goodsUnitData;

            if (_goodsAcs == null)
            {
                string msg;
                _goodsAcs = new GoodsAcs(SectionCode);
                _goodsAcs.SearchInitial(scmPrtSettngWork.EnterpriseCode, SectionCode.Trim(), out msg);
            }

            goodsUnitData = new GoodsUnitData();

            goodsUnitData.EnterpriseCode = scmPrtSettngWork.EnterpriseCode.Trim();
            goodsUnitData.SectionCode = scmPrtSettngWork.SectionCode.Trim();
            goodsUnitData.GoodsMakerCd = scmPrtSettngWork.GoodsMakerCd;
            goodsUnitData.GoodsMGroup = scmPrtSettngWork.GoodsMGroup;
            goodsUnitData.BLGoodsCode = scmPrtSettngWork.BLGoodsCode;
            goodsUnitData.GoodsNo = scmPrtSettngWork.GoodsNo.Trim();

            _goodsAcs.GetGoodsMngInfo(ref goodsUnitData);
            if (goodsUnitData.SupplierCd == 0)
            {
                goodsUnitData.EnterpriseCode = scmPrtSettngWork.EnterpriseCode.Trim();
                goodsUnitData.SectionCode = "00";
                goodsUnitData.GoodsMakerCd = scmPrtSettngWork.GoodsMakerCd;
                goodsUnitData.GoodsMGroup = scmPrtSettngWork.GoodsMGroup;
                goodsUnitData.BLGoodsCode = scmPrtSettngWork.BLGoodsCode;
                goodsUnitData.GoodsNo = scmPrtSettngWork.GoodsNo.Trim();

                _goodsAcs.GetGoodsMngInfo(ref goodsUnitData);
            }

            return goodsUnitData;
        }
        #endregion

        #region Write �������ݏ���
        /// <summary>
        /// �������ݏ���
        /// </summary>
        /// <param name="scmPrtSettingList">�ۑ��f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �������ݏ������s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        public int Write(ref ArrayList scmPrtSettingList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // �f�[�^�������[�v
                ArrayList paraSCMPrtSettingList = new ArrayList();
                SCMPrtSettingWork scmPrtSettingWork = null;

                for ( int i = 0; i < scmPrtSettingList.Count; i++ )
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    scmPrtSettingWork = CopyToSCMPrtSettingWorkFromSCMPrtSetting( (SCMPrtSetting)scmPrtSettingList[i] );
                    paraSCMPrtSettingList.Add( scmPrtSettingWork );
                }

                object paraObj = (object)paraSCMPrtSettingList;

                // �������ݏ���
                status = this._iSCMPrtSetingDB.Write( ref paraObj );

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // ����X�V

                    // DataTable���g�p���Ă���ꍇ�̂ݏ����������s��
                    if ( _dataTableList != null )
                    {
                        UpdateDataTable( paraObj );
                    }
                }
                else
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
                this._iSCMPrtSetingDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        /// <summary>
        /// �X�V�����̎擾�i����DataTable���j
        /// </summary>
        /// <returns></returns>
        public int GetUpdateCountFromTable()
        {
            if ( _dataTableList != null )
            {
                DataView view = new DataView( _dataTableList.Tables[ct_TABLE_SCMPRTSETTING] );
                view.RowFilter = string.Format( "{0}<>{1}", ct_COL_AUTOANSWERDIV, ct_COL_AUTOANSWERDIV_BACKUP );

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
                ArrayList paraSCMPrtSettingList = new ArrayList();
                foreach ( DataRow row in _dataTableList.Tables[ct_TABLE_SCMPRTSETTING].Rows )
                {
                    // �ύX�L���`�F�b�N
                    if ( (int)row[ct_COL_AUTOANSWERDIV] == (int)row[ct_COL_AUTOANSWERDIV_BACKUP] )
                    {
                        // �ύX�\�ȍ��ڂ�Search���ƕς��Ȃ��̂őΏۊO�ɂ���
                        continue;
                    }

                    SCMPrtSettingWork scmPrtSettingWork = CopyToSCMPrtSettingWorkFromDataRow( row );
                    paraSCMPrtSettingList.Add( scmPrtSettingWork );
                }
                // �ύX�L���`�F�b�N
                if ( paraSCMPrtSettingList.Count == 0 )
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    message = "�X�V�Ώۂ̃f�[�^�����݂��܂���";
                    return status;
                }

                object paraObj = (object)paraSCMPrtSettingList;


                // �������ݏ���
                status = this._iSCMPrtSetingDB.Write( ref paraObj );

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // ����X�V

                    // DataTable���g�p���Ă���ꍇ�̂ݏ����������s��
                    if ( _dataTableList != null )
                    {
                        UpdateDataTable( paraObj );
                    }
                }
                else
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
                this._iSCMPrtSetingDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �����f�[�^�e�[�u��������������
        /// </summary>
        /// <param name="paraObj"></param>
        private void UpdateDataTable( object retObj )
        {
            if ( retObj is ArrayList )
            {
                foreach ( object obj in (retObj as ArrayList) )
                {
                    if ( obj is SCMPrtSettingWork )
                    {
                        SCMPrtSettingWork retWork = (SCMPrtSettingWork)obj;

                        DataRow row = this.GetRowForMaintenance( retWork.FileHeaderGuid );

                        GoodsUnitData goodsUnitData = GetGoodsMngInfo( retWork );

                        if ( row == null )
                        {
                            // �ǉ�
                            row = _dataTableList.Tables[ct_TABLE_SCMPRTSETTING].NewRow();
                            CopyToDataRowFromSCMPrtSettingWork( ref row, retWork, goodsUnitData );
                            _dataTableList.Tables[ct_TABLE_SCMPRTSETTING].Rows.Add( row );
                        }
                        else
                        {
                            // �X�V
                            CopyToDataRowFromSCMPrtSettingWork( ref row, retWork, goodsUnitData );
                        }
                    }
                }
            }
        }
        /// <summary>
        /// �����f�[�^�e�[�u��������������(�����폜��)
        /// </summary>
        /// <param name="retObj"></param>
        private void DeleteFromDataTable( ArrayList scmPrtSettingWorkList )
        {
            foreach ( object obj in scmPrtSettingWorkList )
            {
                if ( obj is SCMPrtSettingWork )
                {
                    SCMPrtSettingWork retWork = (SCMPrtSettingWork)obj;

                    DataRow row = this.GetRowForMaintenance( retWork.FileHeaderGuid );

                    if ( row != null )
                    {
                        // �폜
                        _dataTableList.Tables[ct_TABLE_SCMPRTSETTING].Rows.Remove( row );
                    }
                }
            }
        }
        #endregion

        #region LogicalDelete �_���폜����
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="scmPrtSettingList">�_���폜�f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�������s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList scmPrtSettingList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // �f�[�^�������[�v
                ArrayList paraSCMPrtSettingList = new ArrayList();
                SCMPrtSettingWork scmPrtSettingWork = null;

                for (int i = 0; i < scmPrtSettingList.Count; i++)
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    scmPrtSettingWork = CopyToSCMPrtSettingWorkFromSCMPrtSetting((SCMPrtSetting)scmPrtSettingList[i]);

                    paraSCMPrtSettingList.Add(scmPrtSettingWork);
                }
                object paraObj = (object)paraSCMPrtSettingList;

                // �_���폜����
                status = this._iSCMPrtSetingDB.LogicalDelete( ref paraObj );

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    if ( _dataTableList != null )
                    {
                        UpdateDataTable( paraObj );
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
                this._iSCMPrtSetingDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region Revival ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="scmPrtSettingList">�_���폜�f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i�_���폜�����j���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        public int Revival(ref ArrayList scmPrtSettingList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // �f�[�^�������[�v
                ArrayList paraSCMPrtSettingList = new ArrayList();
                SCMPrtSettingWork scmPrtSettingWork = null;

                for (int i = 0; i < scmPrtSettingList.Count; i++)
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    scmPrtSettingWork = CopyToSCMPrtSettingWorkFromSCMPrtSetting((SCMPrtSetting)scmPrtSettingList[i]);

                    paraSCMPrtSettingList.Add(scmPrtSettingWork);
                }

                object paraObj = (object)paraSCMPrtSettingList;

                // �������ݏ���
                status = this._iSCMPrtSetingDB.RevivalLogicalDelete(ref paraObj);

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    if ( _dataTableList != null )
                    {
                        UpdateDataTable( paraObj );
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
                this._iSCMPrtSetingDB = null;
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
        /// <param name="scmPrtSettingList">�폜�f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �폜�����i�����폜�j���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        public int Delete(ref ArrayList scmPrtSettingList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                byte[] paraSCMPrtSettingWork = null;
                SCMPrtSettingWork scmPrtSettingWork = null;
                ArrayList scmPrtSettingWorkList = new ArrayList();	// ���[�N�N���X�i�[�pArrayList

                // ���[�N�N���X�i�[�pArrayList�֋l�ߑւ�
                for (int i = 0; i < scmPrtSettingList.Count; i++)
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    scmPrtSettingWork = CopyToSCMPrtSettingWorkFromSCMPrtSetting((SCMPrtSetting)scmPrtSettingList[i]);
                    scmPrtSettingWorkList.Add(scmPrtSettingWork);
                }
                // ArrayList����z��𐶐�
                SCMPrtSettingWork[] scmPrtSettingWorks = (SCMPrtSettingWork[])scmPrtSettingWorkList.ToArray(typeof(SCMPrtSettingWork));

                // �V���A���C�Y
                paraSCMPrtSettingWork = XmlByteSerializer.Serialize(scmPrtSettingWorks);

                // �����폜����
                status = this._iSCMPrtSetingDB.Delete(paraSCMPrtSettingWork);

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    if ( _dataTableList != null )
                    {
                        // �e�[�u������폜
                        DeleteFromDataTable( scmPrtSettingWorkList );
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
                this._iSCMPrtSetingDB = null;
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //----------------------------------------------------------------
            // SCM�i�ڐݒ�e�[�u�����`
            //----------------------------------------------------------------
            DataTable scmPrtSettingTable = new DataTable( ct_TABLE_SCMPRTSETTING );


            // �쐬����
            scmPrtSettingTable.Columns.Add( ct_COL_CREATEDATETIME, typeof( DateTime ) );
            // �X�V����
            scmPrtSettingTable.Columns.Add( ct_COL_UPDATEDATETIME, typeof( DateTime ) );
            // ��ƃR�[�h
            scmPrtSettingTable.Columns.Add( ct_COL_ENTERPRISECODE, typeof( string ) );
            // GUID
            scmPrtSettingTable.Columns.Add( ct_COL_FILEHEADERGUID, typeof( Guid ) );
            // �X�V�]�ƈ��R�[�h
            scmPrtSettingTable.Columns.Add( ct_COL_UPDEMPLOYEECODE, typeof( string ) );
            // �X�V�A�Z���u��ID1
            scmPrtSettingTable.Columns.Add( ct_COL_UPDASSEMBLYID1, typeof( string ) );
            // �X�V�A�Z���u��ID2
            scmPrtSettingTable.Columns.Add( ct_COL_UPDASSEMBLYID2, typeof( string ) );
            // �_���폜�敪
            scmPrtSettingTable.Columns.Add( ct_COL_LOGICALDELETECODE, typeof( Int32 ) );
            // ���_�R�[�h
            scmPrtSettingTable.Columns.Add( ct_COL_SECTIONCODE, typeof( string ) );
            // ���Ӑ�R�[�h
            scmPrtSettingTable.Columns.Add( ct_COL_CUSTOMERCODE, typeof( Int32 ) );
            // ���i�����ރR�[�h
            scmPrtSettingTable.Columns.Add( ct_COL_GOODSMGROUP, typeof( Int32 ) );
            // BL���i�R�[�h
            scmPrtSettingTable.Columns.Add( ct_COL_BLGOODSCODE, typeof( Int32 ) );
            // ���i���[�J�[�R�[�h
            scmPrtSettingTable.Columns.Add( ct_COL_GOODSMAKERCD, typeof( Int32 ) );
            // ���i�ԍ�
            scmPrtSettingTable.Columns.Add( ct_COL_GOODSNO, typeof( string ) );
            // �����񓚋敪
            scmPrtSettingTable.Columns.Add( ct_COL_AUTOANSWERDIV, typeof( Int32 ) );

            // �����񓚋敪
            scmPrtSettingTable.Columns.Add( ct_COL_AUTOANSWERDIV_BACKUP, typeof( Int32 ) );

            // ���_����
            scmPrtSettingTable.Columns.Add( ct_COL_SECTIONNM, typeof( string ) );
            // ���Ӑ於��
            scmPrtSettingTable.Columns.Add( ct_COL_CUSTOMERNAME, typeof( string ) );
            // ���i�����ޖ���
            scmPrtSettingTable.Columns.Add( ct_COL_GOODSMGROUPNAME, typeof( string ) );
            // BL�O���[�v����
            scmPrtSettingTable.Columns.Add( ct_COL_BLGROUPNAME, typeof( string ) );
            // BL���i�R�[�h����
            scmPrtSettingTable.Columns.Add( ct_COL_BLGOODSNAME, typeof( string ) );
            // ���[�J�[����
            scmPrtSettingTable.Columns.Add( ct_COL_MAKERNAME, typeof( string ) );
            // ���i����
            scmPrtSettingTable.Columns.Add( ct_COL_GOODSNAME, typeof( string ) );
            // �d����R�[�h
            scmPrtSettingTable.Columns.Add( ct_COL_SUPPLIERCD, typeof( Int32 ) );
            // �d���旪��
            scmPrtSettingTable.Columns.Add( ct_COL_SUPPLIERSNM, typeof( string ) );

            // �O���[�v�R�[�h
            scmPrtSettingTable.Columns.Add( ct_COL_BLGROUPCODE, typeof( Int32 ) );

            # region [�\�[�g�p]
            // ���_�R�[�h
            scmPrtSettingTable.Columns.Add( ct_COL_SECTIONCODE_SORT, typeof( string ) );
            // ���Ӑ�R�[�h
            scmPrtSettingTable.Columns.Add( ct_COL_CUSTOMERCODE_SORT, typeof( Int32 ) );
            // ���i�����ރR�[�h
            scmPrtSettingTable.Columns.Add( ct_COL_GOODSMGROUP_SORT, typeof( Int32 ) );
            // BL���i�R�[�h
            scmPrtSettingTable.Columns.Add( ct_COL_BLGOODSCODE_SORT, typeof( Int32 ) );
            // ���i���[�J�[�R�[�h
            scmPrtSettingTable.Columns.Add( ct_COL_GOODSMAKERCD_SORT, typeof( Int32 ) );
            // �d����R�[�h
            scmPrtSettingTable.Columns.Add( ct_COL_SUPPLIERCD_SORT, typeof( Int32 ) );
            // �O���[�v�R�[�h
            scmPrtSettingTable.Columns.Add( ct_COL_BLGROUPCODE_SORT, typeof( Int32 ) );
            # endregion


            // �_���폜��(�\���p)
            scmPrtSettingTable.Columns.Add( ct_COL_LOGICALDELETEDATE, typeof( string ) );
            // �I�u�W�F�N�g(�����ێ��p)
            scmPrtSettingTable.Columns.Add( ct_COL_SCMPRTSETTINGWORKOBJECT, typeof( SCMPrtSettingWork ) );

            this._dataTableList.Tables.Add(scmPrtSettingTable);

            //----------------------------------------------------------------
            // �f�[�^�r���[����
            //----------------------------------------------------------------
            this._dataView = new DataView( scmPrtSettingTable );
            this._dataView.Sort = string.Format( "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}",
                                                ct_COL_SECTIONCODE_SORT,
                                                ct_COL_CUSTOMERCODE_SORT,
                                                ct_COL_SUPPLIERCD_SORT,
                                                ct_COL_GOODSMAKERCD_SORT,
                                                ct_COL_GOODSMGROUP_SORT,
                                                ct_COL_BLGROUPCODE_SORT,
                                                ct_COL_BLGOODSCODE_SORT,
                                                ct_COL_GOODSNO 
                                                );
        }
        #endregion

        #region �N���X�����o�R�s�[����
        /// <summary>
        /// �N���X�����o�[�R�s�[�����iSCM�i�ڐݒ�N���X��SCM�i�ڐݒ胏�[�N�N���X�j
        /// </summary>
        /// <param name="scmPrtSetting">SCM�i�ڐݒ�N���X</param>
        /// <returns>SCMPrtSettingWork</returns>
        /// <remarks>
        /// <br>Note       : SCM�i�ڐݒ�N���X����SCM�i�ڐݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private SCMPrtSettingWork CopyToSCMPrtSettingWorkFromSCMPrtSetting(SCMPrtSetting scmPrtSetting)
        {
            SCMPrtSettingWork scmPrtSettingWork = new SCMPrtSettingWork();

            scmPrtSettingWork.CreateDateTime = scmPrtSetting.CreateDateTime; // �쐬����
            scmPrtSettingWork.UpdateDateTime = scmPrtSetting.UpdateDateTime; // �X�V����
            scmPrtSettingWork.EnterpriseCode = scmPrtSetting.EnterpriseCode; // ��ƃR�[�h
            scmPrtSettingWork.FileHeaderGuid = scmPrtSetting.FileHeaderGuid; // GUID
            scmPrtSettingWork.UpdEmployeeCode = scmPrtSetting.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            scmPrtSettingWork.UpdAssemblyId1 = scmPrtSetting.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            scmPrtSettingWork.UpdAssemblyId2 = scmPrtSetting.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            scmPrtSettingWork.LogicalDeleteCode = scmPrtSetting.LogicalDeleteCode; // �_���폜�敪
            scmPrtSettingWork.SectionCode = scmPrtSetting.SectionCode; // ���_�R�[�h
            scmPrtSettingWork.CustomerCode = scmPrtSetting.CustomerCode; // ���Ӑ�R�[�h
            scmPrtSettingWork.GoodsMGroup = scmPrtSetting.GoodsMGroup; // ���i�����ރR�[�h
            scmPrtSettingWork.BLGroupCode = scmPrtSetting.BLGroupCode; // BL�O���[�v�R�[�h
            scmPrtSettingWork.BLGoodsCode = scmPrtSetting.BLGoodsCode; // BL���i�R�[�h
            scmPrtSettingWork.GoodsMakerCd = scmPrtSetting.GoodsMakerCd; // ���i���[�J�[�R�[�h
            scmPrtSettingWork.GoodsNo = scmPrtSetting.GoodsNo; // ���i�ԍ�
            scmPrtSettingWork.AutoAnswerDiv = scmPrtSetting.AutoAnswerDiv; // �����񓚋敪
            scmPrtSettingWork.SectionNm = scmPrtSetting.SectionNm; // ���_����
            scmPrtSettingWork.CustomerName = scmPrtSetting.CustomerName; // ���Ӑ於��
            scmPrtSettingWork.GoodsMGroupName = scmPrtSetting.GoodsMGroupName; // ���i�����ޖ���
            scmPrtSettingWork.BLGroupName = scmPrtSetting.BLGroupName; // BL�O���[�v����
            scmPrtSettingWork.BLGoodsName = scmPrtSetting.BLGoodsName; // BL���i�R�[�h����
            scmPrtSettingWork.MakerName = scmPrtSetting.MakerName; // ���[�J�[����
            scmPrtSettingWork.GoodsName = scmPrtSetting.GoodsName; // ���i����
            //scmPrtSettingWork.SupplierCd = scmPrtSetting.SupplierCd; // �d����R�[�h
            //scmPrtSettingWork.SupplierSnm = scmPrtSetting.SupplierSnm; // �d���旪��

            return scmPrtSettingWork;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����iSCM�i�ڐݒ胏�[�N�N���X��SCM�i�ڐݒ�N���X�j
        /// </summary>
        /// <param name="scmPrtSettingWork">SCM�i�ڐݒ胏�[�N�N���X</param>
        /// <returns>SCMPrtSetting</returns>
        /// <remarks>
        /// <br>Note       : SCM�i�ڐݒ胏�[�N�N���X����SCM�i�ڐݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private SCMPrtSetting CopyToSCMPrtSettingFromSCMPrtSettingWork(SCMPrtSettingWork scmPrtSettingWork)
        {
            SCMPrtSetting scmPrtSetting = new SCMPrtSetting();

            scmPrtSetting.CreateDateTime = scmPrtSettingWork.CreateDateTime; // �쐬����
            scmPrtSetting.UpdateDateTime = scmPrtSettingWork.UpdateDateTime; // �X�V����
            scmPrtSetting.EnterpriseCode = scmPrtSettingWork.EnterpriseCode; // ��ƃR�[�h
            scmPrtSetting.FileHeaderGuid = scmPrtSettingWork.FileHeaderGuid; // GUID
            scmPrtSetting.UpdEmployeeCode = scmPrtSettingWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            scmPrtSetting.UpdAssemblyId1 = scmPrtSettingWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            scmPrtSetting.UpdAssemblyId2 = scmPrtSettingWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            scmPrtSetting.LogicalDeleteCode = scmPrtSettingWork.LogicalDeleteCode; // �_���폜�敪
            scmPrtSetting.SectionCode = scmPrtSettingWork.SectionCode; // ���_�R�[�h
            scmPrtSetting.CustomerCode = scmPrtSettingWork.CustomerCode; // ���Ӑ�R�[�h
            scmPrtSetting.GoodsMGroup = scmPrtSettingWork.GoodsMGroup; // ���i�����ރR�[�h
            scmPrtSetting.BLGroupCode = scmPrtSettingWork.BLGroupCode; // BL�O���[�v�R�[�h
            scmPrtSetting.BLGoodsCode = scmPrtSettingWork.BLGoodsCode; // BL���i�R�[�h
            scmPrtSetting.GoodsMakerCd = scmPrtSettingWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
            scmPrtSetting.GoodsNo = scmPrtSettingWork.GoodsNo; // ���i�ԍ�
            scmPrtSetting.AutoAnswerDiv = scmPrtSettingWork.AutoAnswerDiv; // �����񓚋敪
            scmPrtSetting.SectionNm = scmPrtSettingWork.SectionNm; // ���_����
            scmPrtSetting.CustomerName = scmPrtSettingWork.CustomerName; // ���Ӑ於��
            scmPrtSetting.GoodsMGroupName = scmPrtSettingWork.GoodsMGroupName; // ���i�����ޖ���
            scmPrtSetting.BLGroupName = scmPrtSettingWork.BLGroupName; // BL�O���[�v����
            scmPrtSetting.BLGoodsName = scmPrtSettingWork.BLGoodsName; // BL���i�R�[�h����
            scmPrtSetting.MakerName = scmPrtSettingWork.MakerName; // ���[�J�[����
            scmPrtSetting.GoodsName = scmPrtSettingWork.GoodsName; // ���i����
            //scmPrtSetting.SupplierCd = scmPrtSettingWork.SupplierCd; // �d����R�[�h
            //scmPrtSetting.SupplierSnm = scmPrtSettingWork.SupplierSnm; // �d���旪��

            return scmPrtSetting;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����iSCM�i�ڐݒ�N���X��DataRow�j
        /// </summary>
        /// <param name="scmPrtSettingWork">SCM�i�ڐݒ�N���X</param>
        /// <returns>DataRow</returns>
        /// <remarks>
        /// <br>Note       : SCM�i�ڐݒ胏�[�N�N���X����SCM�i�ڐݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void CopyToDataRowFromSCMPrtSettingWork( ref DataRow dr, SCMPrtSettingWork scmPrtSettingWork, GoodsUnitData goodsUnitData )
        {
            # region [dr��scmPrtSetting]
            dr[ct_COL_CREATEDATETIME] = scmPrtSettingWork.CreateDateTime; // �쐬����
            dr[ct_COL_UPDATEDATETIME] = scmPrtSettingWork.UpdateDateTime; // �X�V����
            dr[ct_COL_ENTERPRISECODE] = scmPrtSettingWork.EnterpriseCode; // ��ƃR�[�h
            dr[ct_COL_FILEHEADERGUID] = scmPrtSettingWork.FileHeaderGuid; // GUID
            dr[ct_COL_UPDEMPLOYEECODE] = scmPrtSettingWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            dr[ct_COL_UPDASSEMBLYID1] = scmPrtSettingWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            dr[ct_COL_UPDASSEMBLYID2] = scmPrtSettingWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            dr[ct_COL_LOGICALDELETECODE] = scmPrtSettingWork.LogicalDeleteCode; // �_���폜�敪
            dr[ct_COL_SECTIONCODE] = scmPrtSettingWork.SectionCode; // ���_�R�[�h
            dr[ct_COL_CUSTOMERCODE] = scmPrtSettingWork.CustomerCode; // ���Ӑ�R�[�h
            dr[ct_COL_GOODSMGROUP] = scmPrtSettingWork.GoodsMGroup; // ���i�����ރR�[�h
            dr[ct_COL_BLGOODSCODE] = scmPrtSettingWork.BLGoodsCode; // BL���i�R�[�h
            dr[ct_COL_GOODSMAKERCD] = scmPrtSettingWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
            dr[ct_COL_GOODSNO] = scmPrtSettingWork.GoodsNo; // ���i�ԍ�
            dr[ct_COL_AUTOANSWERDIV] = scmPrtSettingWork.AutoAnswerDiv; // �����񓚋敪
            dr[ct_COL_AUTOANSWERDIV_BACKUP] = scmPrtSettingWork.AutoAnswerDiv; // �����񓚋敪(�O��l�ޔ�)

            // �_���폜��(�\���p)
            if ( scmPrtSettingWork.LogicalDeleteCode == 0 )
            {
                dr[ct_COL_LOGICALDELETEDATE] = string.Empty;
            }
            else
            {
                dr[ct_COL_LOGICALDELETEDATE] = TDateTime.DateTimeToString( "ggYY/MM/DD", scmPrtSettingWork.UpdateDateTime );
            }

            dr[ct_COL_SECTIONNM] = scmPrtSettingWork.SectionNm; // ���_����
            dr[ct_COL_CUSTOMERNAME] = scmPrtSettingWork.CustomerName; // ���Ӑ於��
            dr[ct_COL_GOODSMGROUPNAME] = scmPrtSettingWork.GoodsMGroupName; // ���i�����ޖ���
            dr[ct_COL_BLGROUPNAME] = scmPrtSettingWork.BLGroupName; // BL�O���[�v����
            dr[ct_COL_BLGOODSNAME] = scmPrtSettingWork.BLGoodsName; // BL���i�R�[�h����
            dr[ct_COL_MAKERNAME] = scmPrtSettingWork.MakerName; // ���[�J�[����
            dr[ct_COL_GOODSNAME] = scmPrtSettingWork.GoodsName; // ���i����
            dr[ct_COL_BLGROUPCODE] = scmPrtSettingWork.BLGroupCode; // BL�O���[�v�R�[�h

            // ���i��񂩂�Z�b�g����
            dr[ct_COL_SUPPLIERCD] = goodsUnitData.SupplierCd; // �d����R�[�h
            dr[ct_COL_SUPPLIERSNM] = goodsUnitData.SupplierSnm; // �d���旪��

            // �\�[�g�p�J����
            dr[ct_COL_SECTIONCODE_SORT] = GetSortValue( scmPrtSettingWork.SectionCode ); // ���_�R�[�h
            dr[ct_COL_CUSTOMERCODE_SORT] = GetSortValue( scmPrtSettingWork.CustomerCode ); // ���Ӑ�R�[�h
            dr[ct_COL_SUPPLIERCD_SORT] = GetSortValue( goodsUnitData.SupplierCd ); // �d����R�[�h
            dr[ct_COL_GOODSMAKERCD_SORT] = GetSortValue( scmPrtSettingWork.GoodsMakerCd ); // ���i���[�J�[�R�[�h
            dr[ct_COL_GOODSMGROUP_SORT] = GetSortValue( scmPrtSettingWork.GoodsMGroup ); // ���i�����ރR�[�h
            dr[ct_COL_BLGROUPCODE_SORT] = GetSortValue( scmPrtSettingWork.BLGroupCode ); // BL�O���[�v�R�[�h
            dr[ct_COL_BLGOODSCODE_SORT] = GetSortValue( scmPrtSettingWork.BLGoodsCode ); // BL���i�R�[�h

            // �I�u�W�F�N�g(�����ێ��p)
            dr[ct_COL_SCMPRTSETTINGWORKOBJECT] = scmPrtSettingWork;
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
        /// �N���X�����o�[�R�s�[�����iDataRow��SCM�i�ڐݒ�N���X�j
        /// </summary>
        /// <param name="row"></param>
        /// <returns>SCMPrtSettingWork</returns>
        /// <remarks>
        /// <br>Note       : SCM�i�ڐݒ胏�[�N�N���X����SCM�i�ڐݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private SCMPrtSettingWork CopyToSCMPrtSettingWorkFromDataRow( DataRow row )
        {
            SCMPrtSettingWork scmPrtSettingWork = (SCMPrtSettingWork)row[ct_COL_SCMPRTSETTINGWORKOBJECT];
            
            // ���������\���ڂ̂ݍ����ւ���
            scmPrtSettingWork.AutoAnswerDiv = (int)row[ct_COL_AUTOANSWERDIV];

            return scmPrtSettingWork;
        }

        /// <summary>
        /// ���o�����N���X�����o�[�R�s�[����
        /// </summary>
        /// <param name="paraData"></param>
        /// <returns></returns>
        private SCMPrtSettingOrderWork CopyToSCMPrtSettingOrderWorkFromSCMPrtSettingOrder( SCMPrtSettingOrder paraData )
        {
            SCMPrtSettingOrderWork paraWork = new SCMPrtSettingOrderWork();
            
            # region [paraWork��paraData]
            paraWork.EnterpriseCode = paraData.EnterpriseCode;  // ��ƃR�[�h
            paraWork.SectionCode = paraData.SectionCode;  // ���_�R�[�h
            paraWork.St_CustomerCode = paraData.St_CustomerCode;  // �J�n���Ӑ�R�[�h
            paraWork.Ed_CustomerCode = paraData.Ed_CustomerCode;  // �I�����Ӑ�R�[�h
            //paraWork.St_SupplierCd = paraData.St_SupplierCd;  // �J�n�d����R�[�h
            //paraWork.Ed_SupplierCd = paraData.Ed_SupplierCd;  // �I���d����R�[�h
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
        /// <param name="scmPrtSettingList">SCM�i�ڐݒ�I�u�W�F�N�g���X�g</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : SCM�i�ڐݒ�}�X�^�̕��������������s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private int SearchProc( SCMPrtSettingOrder paraData, out ArrayList retWorkList, ConstantManagement.LogicalMode logicalMode, out string message )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";
            retWorkList = null;

            //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            if (_SCMPrtSetingWorkList != null)
            {
                retWorkList = (ArrayList)_SCMPrtSetingWorkList;
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
            //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                try
                {
                    //ArrayList paraList = new ArrayList();
                    //==========================================
                    // SCM�i�ڐݒ�}�X�^�ǂݍ���
                    //==========================================
                    SCMPrtSettingOrderWork paraWork = CopyToSCMPrtSettingOrderWorkFromSCMPrtSettingOrder(paraData);

                    // �����[�g�߂胊�X�g
                    object scmPrtSettingWorkList = null;
                    // SCM�i�ڐݒ�}�X�^����
                    status = this._iSCMPrtSetingDB.Search(out scmPrtSettingWorkList, paraWork, 0, logicalMode);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        retWorkList = (ArrayList)scmPrtSettingWorkList;
                        //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        _SCMPrtSetingWorkList = (ArrayList)scmPrtSettingWorkList;
                        //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            }
            //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            return status;
        }
        #endregion

        #region Read ��������
        /// <summary>
        /// SCM�i�ڐݒ背�R�[�h�擾����
        /// </summary>
        /// <param name="scmPrtSetting">SCM�i�ڐݒ�f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B
        ///                  scmPrtSetting�N���X�Ɍ����f�[�^��ݒ肵�A���ʂ�scmPrtSetting�N���X�Ɋi�[���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        public int Read(ref SCMPrtSetting scmPrtSetting)
        {
            try
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                // ���o�����p�����[�^
                SCMPrtSettingWork scmPrtSettingWork = CopyToSCMPrtSettingWorkFromSCMPrtSetting( scmPrtSetting );

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize( scmPrtSettingWork );
                status = this._iSCMPrtSetingDB.Read( ref parabyte, 0 );

                if (status == 0)
                {
                    // XML�̓ǂݍ���
                    scmPrtSettingWork = (SCMPrtSettingWork)XmlByteSerializer.Deserialize( parabyte, typeof( SCMPrtSettingWork ) );
                }

                if (status == 0)
                {
                    // �N���X�������o�R�s�[
                    scmPrtSetting = CopyToSCMPrtSettingFromSCMPrtSettingWork( scmPrtSettingWork );
                }

                return status;
            }
            catch (Exception)
            {
                //�ʐM�G���[��-1��߂�
                scmPrtSetting = null;
                //�I�t���C������null���Z�b�g
                this._iSCMPrtSetingDB = null;
                return -1;
            }
        }
        #endregion
    }
}
