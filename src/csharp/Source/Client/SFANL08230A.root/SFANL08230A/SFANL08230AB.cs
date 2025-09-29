using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���R���[�󎚈ʒuDL�f�[�^�Z�b�g����N���X
    /// </summary>
    abstract public class SFANL08230AB : SFANL08230AC
    {

        # region Constructor
		/// <summary>
		/// �󎚈ʒu�_�E�����[�h��ʃA�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note		: ���R���[�󎚈ʒuDL�f�[�^�Z�b�g����N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
        public SFANL08230AB()
        {
            this._dataSet = new DataSet();
        }
        # endregion

        #region Private Members
        /// <summary>
        /// �󎚈ʒu�ݒ���f�[�^�Z�b�g
        /// </summary>
        protected DataSet _dataSet = null;

        /// <summary>
        /// �󎚈ʒu�ݒ�i���[�U�[DB�j�\�[�g���X�g 
        /// </summary>
        protected SortedList _serverPrtPosSet_SortedList = null;

        /// <summary>
        /// �󎚈ʒu�ݒ�i���[�J��XML�j�\�[�g���X�g 
        /// </summary>
        protected SortedList _localPrtPosSet_SortedList = null;


        #endregion

        #region Public Methods

        #region �R���o�[�g�iInt32�j����
        /// <summary>
        /// �R���o�[�g�iInt32�j����
        /// </summary>
        /// <param name="source">�R���o�[�g�Ώ�</param>
        /// <returns>�R���o�[�g����</returns>
        /// <remarks>
        /// <br>Note		: �I�u�W�F�N�g��Int32�^�ɃR���o�[�g���܂��B�R���o�[�g�o���Ȃ��I�u�W�F�N�g�̏ꍇ�͂O��Ԃ��܂��B</br>
        /// <br>Programmer	: 22011 �����@���l</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        public static Int32 ConvertToInt32(object source)
        {
            Int32 dest = 0;
            try
            {
                dest = Convert.ToInt32(source);
            }
            catch
            {
                dest = 0;
            }
            return dest;
        }
        #endregion

        #region �󎚈ʒu�ݒ�����p�L�[������쐬����
        /// <summary>
        /// �󎚈ʒu�ݒ�����p�L�[������쐬����
        /// </summary>
        /// <param name="outputFormFileName">�o�̓t�@�C����</param>
        /// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
        /// <returns>�쐬�����L�[������</returns>
        /// <remarks>
        /// <br>Note		: �󎚈ʒu�ݒ�i���[�J��XML�j�}�X�^�̃\�[�g���X�g���擾���܂��B</br>
        /// <br>Programmer	: 22011 �����@���l</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        public static string MakeKeyForHashtable(string outputFormFileName, int userPrtPprIdDerivNo)
        {
            return string.Format("{0},{1:D3}", outputFormFileName.Trim(), userPrtPprIdDerivNo);
        }
        #endregion

        #endregion

        #region Private Methods

        #region �V�X�e���敪���̎擾����
        /// <summary>
        /// �V�X�e���敪���̎擾����
        /// </summary>
        /// <param name="systemDivCd"></param>
        /// <returns></returns>
        private string GetSystemDivName(int systemDivCd)
        {
            string systemDivName = "���̑�";

            if (systemDivCd == 0) systemDivName = "����";
            else if (systemDivCd == 1) systemDivName = "����";
            else if (systemDivCd == 2) systemDivName = "���";
            else if (systemDivCd == 3) systemDivName = "�Ԕ�";

            return systemDivName;
        }
        #endregion

        #region ���[�g�p�敪���̎擾
        /// <summary>
        /// ���[�g�p�敪���̎擾
        /// </summary>
        /// <param name="printPaperUseDivcd"></param>
        /// <returns></returns>
        private string GetPrintPaperUserDivCdNm(int printPaperUseDivcd)
        {
            switch (printPaperUseDivcd)
            {
                case 1: return "���[";
                case 2: return "�`�[";
                case 3: return "�c�l�ꗗ�\";
                case 4: return "�c�l�͂���";
                default: return "";
            }
        }
        #endregion

        #region ���_�E�����[�h�t���O�擾����
        /// <summary>
        /// ���_�E�����[�h�t���O�擾����
        /// </summary>
        /// <param name="outputFormFileName">�o�̓t�@�C����</param>
        /// <param name="offerPrtPprIdDerivNo">�񋟒��[ID�}�ԍ�</param>
        /// <returns>���_�E�����[�h�t���O(0:�_�E�����[�h�ς�,1:���_�E�����[�h)</returns>
        /// <remarks>
        /// <br>Note		: �w��̒��[�̈󎚈ʒu��񂪃��[�U�[�f�[�^�ɂ��邩�ǂ������`�F�b�N���܂�</br>
        /// <br>Programmer	: 22011 �����@���l</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        private int GetFlag_NoDownLoad(string outputFormFileName, int offerPrtPprIdDerivNo)
        {
            SFANL08230AF userPrtPosSet;

            // �\�[�g���X�g(���[�U�[)���f�[�^���擾
            this.GetUserSFANL08230AF(out userPrtPosSet, outputFormFileName, offerPrtPprIdDerivNo);
            if (userPrtPosSet == null)
            {
                return 1;
            }

            // �����̂��̂������
            if (userPrtPosSet.ExistingDataFlag == 1)
            {
                return 0;
            }
            
            return 1;
        }
        #endregion

        #region �V�K�o�[�W�����t���O�擾����
        /// <summary>
        /// �V�K�o�[�W�����t���O�擾����
        /// </summary>
        /// <param name="outputFormFileName">�o�̓t�@�C����</param>
        /// <param name="offerPrtPprIdDerivNo">���[ID�}�ԍ�</param>
        /// <param name="updateDateTime">�X�V����</param>
        /// <returns>�V�K�o�[�W�����t���O(0:�V�K�o�[�W�����ł͂Ȃ�,1:�V�K�o�[�W�����ł���)</returns>
        /// <remarks>
        /// <br>Note		: �w��̒��[�̃o�[�W���������[�J���t�@�C�������V�������ǂ������`�F�b�N���܂�</br>
        /// <br>Programmer	: 22011 �����@���l</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        private int GetFlag_NewVersion(string outputFormFileName, int offerPrtPprIdDerivNo, DateTime updateDateTime)
        {
            SFANL08230AF userPrtPosSet;

            // �\�[�g���X�g(���[�U�[)���f�[�^���擾
            this.GetUserSFANL08230AF(out userPrtPosSet, outputFormFileName, offerPrtPprIdDerivNo);
            if (userPrtPosSet == null)
            {
                return 1;
            }
            // �󎚉\�o�[�W����
            if (userPrtPosSet.UpdateDateTime < updateDateTime)
            {
                return 1;
            }

            return 0;
        }
        #endregion
  
        #endregion

        #region Protected Methods

        #region �󎚈ʒu�i�񋟁j�f�[�^�e�[�u����������
        /// <summary>
        /// �󎚈ʒu�i�񋟁j�f�[�^�e�[�u����������
        /// </summary>
        /// <param name="ds">�f�[�^�Z�b�g</param>
        /// <remarks>
        /// <br>Note		: �󎚈ʒu�i�񋟁j�f�[�^�e�[�u���𐶐����ĕԂ��܂�</br>
        /// <br>Programmer	: 22011 �����@���l</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        protected void SetDataTable_Offer(ref DataSet ds)
        {
            DataTable dt = null;

            if (ds.Tables.Contains(TABLE_OFFER))
            {
                dt = ds.Tables[TABLE_OFFER];
                dt.Rows.Clear();
            }
            else
            {
                dt = new DataTable(TABLE_OFFER);
                dt.Columns.Add(COL_OFFER_SELECT, typeof(Int32));
                dt.Columns.Add(COL_OFFER_KEY, typeof(string));
                dt.Columns.Add(COL_OFFER_OUTPUTFORMFILENAME, typeof(string));
                dt.Columns.Add(COL_OFFER_DISPLAYNAME, typeof(string));
                dt.Columns.Add(COL_OFFER_USERPRTPPRIDDERIVNO, typeof(Int32));
                dt.Columns.Add(COL_OFFER_PRTPPRUSERDERIVNOCMT, typeof(string));
                dt.Columns.Add(COL_OFFER_PRINTPAPERUSEDIVCD, typeof(Int32));
                dt.Columns.Add(COL_OFFER_PRINTPAPERUSEDIVCDNM, typeof(string));
                dt.Columns.Add(COL_OFFER_TAKEINIMAGEGROUPCD, typeof(Guid));
                dt.Columns.Add(COL_OFFER_FREEPRTPPRITEMGRPCD, typeof(Int32));
                dt.Columns.Add(COL_OFFER_UPDATETIMESTR, typeof(string));
                dt.Columns.Add(COL_OFFER_UPDATETIME, typeof(DateTime));
                dt.Columns.Add(COL_OFFER_SYSTEMDIVCD, typeof(Int32));
                dt.Columns.Add(COL_OFFER_SYSTEMDIVNAME, typeof(string));
                dt.Columns.Add(COL_OFFER_OPTIONCODE, typeof(string));
                dt.Columns.Add(COL_OFFER_OPTIONNAME, typeof(string));
                dt.Columns.Add(COL_OFFER_NO_DOWNLOAD, typeof(Int32));
                dt.Columns.Add(COL_OFFER_NEW_VERSION, typeof(Int32));

                dt.Columns[COL_OFFER_SELECT].Caption = "�I��";
                dt.Columns[COL_OFFER_KEY].Caption = "KEY";
                dt.Columns[COL_OFFER_OUTPUTFORMFILENAME].Caption = "�o�̓t�@�C����";
                dt.Columns[COL_OFFER_DISPLAYNAME].Caption = "���[����";
                dt.Columns[COL_OFFER_USERPRTPPRIDDERIVNO].Caption = "���[�U�[���[ID�}�ԍ�";
                dt.Columns[COL_OFFER_PRTPPRUSERDERIVNOCMT].Caption = "�R�����g";
                dt.Columns[COL_OFFER_FREEPRTPPRITEMGRPCD].Caption = "�󎚍��ڃO���[�v�R�[�h";
                dt.Columns[COL_OFFER_UPDATETIMESTR].Caption = "�T�[�o�[�X�V����";
                dt.Columns[COL_OFFER_UPDATETIME].Caption = "�T�[�o�[�X�V����";
                dt.Columns[COL_OFFER_SYSTEMDIVCD].Caption = "�V�X�e���敪";
                dt.Columns[COL_OFFER_SYSTEMDIVNAME].Caption = "�V�X�e��";
                dt.Columns[COL_OFFER_OPTIONCODE].Caption = "�I�v�V�����R�[�h";
                dt.Columns[COL_OFFER_OPTIONNAME].Caption = "�I�v�V��������";
                dt.Columns[COL_OFFER_NO_DOWNLOAD].Caption = "���_�E�����[�h";
                dt.Columns[COL_OFFER_NEW_VERSION].Caption = "�V�o�[�W����";
                dt.Columns[COL_OFFER_PRINTPAPERUSEDIVCD].Caption = "���[�g�p�敪�R�[�h";
                dt.Columns[COL_OFFER_PRINTPAPERUSEDIVCDNM].Caption = "���[�g�p�敪";
                dt.Columns[COL_OFFER_TAKEINIMAGEGROUPCD].Caption = "�捞�摜�R�[�h";
                ds.Tables.Add(dt);
            }

            if (dt != null)
            {
                if (this._serverPrtPosSet_SortedList != null)
                {
                    if (this._serverPrtPosSet_SortedList.Count > 0)
                    {
                        foreach (SFANL08230AF offerPrtPosSet in this._serverPrtPosSet_SortedList.Values)
                        {
                            string offerKey = MakeKeyForHashtable(offerPrtPosSet.OutputFormFileName, offerPrtPosSet.UserPrtPprIdDerivNo);

                            DataRow dr = dt.NewRow();
                            dr[COL_OFFER_SELECT] = offerPrtPosSet.UpdateFlag;
                            dr[COL_OFFER_KEY] = offerKey;
                            dr[COL_OFFER_OUTPUTFORMFILENAME] = offerPrtPosSet.OutputFormFileName;
                            dr[COL_OFFER_USERPRTPPRIDDERIVNO] = offerPrtPosSet.UserPrtPprIdDerivNo;
                            dr[COL_OFFER_DISPLAYNAME] = offerPrtPosSet.DisplayName;
                            dr[COL_OFFER_PRTPPRUSERDERIVNOCMT] = offerPrtPosSet.PrtPprUserDerivNoCmt;
                            dr[COL_OFFER_FREEPRTPPRITEMGRPCD] = offerPrtPosSet.FreePrtPprItemGrpCd;
                            dr[COL_OFFER_UPDATETIMESTR] = offerPrtPosSet.UpdateDateTime.ToString("yyyy.MM.dd HH:mm:ss");
                            dr[COL_OFFER_UPDATETIME] = offerPrtPosSet.UpdateDateTime;
                            dr[COL_OFFER_SYSTEMDIVCD] = offerPrtPosSet.DataInputSystem;
                            dr[COL_OFFER_SYSTEMDIVNAME] = this.GetSystemDivName(offerPrtPosSet.DataInputSystem);
                            dr[COL_OFFER_OPTIONCODE] = offerPrtPosSet.OptionCode;
                            dr[COL_OFFER_OPTIONNAME] = string.Empty;
                            dr[COL_OFFER_NO_DOWNLOAD] = this.GetFlag_NoDownLoad(offerPrtPosSet.OutputFormFileName, offerPrtPosSet.UserPrtPprIdDerivNo);
                            dr[COL_OFFER_NEW_VERSION] = this.GetFlag_NewVersion(offerPrtPosSet.OutputFormFileName, offerPrtPosSet.UserPrtPprIdDerivNo,
                                offerPrtPosSet.UpdateDateTime);
                            dr[COL_OFFER_PRINTPAPERUSEDIVCD] = offerPrtPosSet.PrintPaperUseDivcd;
                            dr[COL_OFFER_PRINTPAPERUSEDIVCDNM] = GetPrintPaperUserDivCdNm(offerPrtPosSet.PrintPaperUseDivcd);
                            dr[COL_OFFER_TAKEINIMAGEGROUPCD] = offerPrtPosSet.TakeInImageGroupCd;
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }
        }
        #endregion

        #region �󎚈ʒu�i���[�U�[�j�f�[�^�e�[�u����������
        /// <summary>
        /// �󎚈ʒu�i���[�U�[�j�f�[�^�e�[�u����������
        /// </summary>
        /// <param name="ds">�f�[�^�Z�b�g</param>
        /// <remarks>
        /// <br>Note		: �󎚈ʒu�i���[�U�[�j�f�[�^�e�[�u���𐶐����ĕԂ��܂�</br>
        /// <br>Programmer	: 22011 �����@���l</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        protected void SetDataTable_User(ref DataSet ds)
        {
            DataTable dt = null;

            if (ds.Tables.Contains(TABLE_USER))
            {
                dt = ds.Tables[TABLE_USER];
                dt.Rows.Clear();
            }
            else
            {
                dt = new DataTable(TABLE_USER);
                dt.Columns.Add(COL_USER_SELECT_UPDATE, typeof(Int32));
                dt.Columns.Add(COL_USER_EXISTFLG, typeof(Int32));
                dt.Columns.Add(COL_USER_UPDATEFLG, typeof(Int32));
                dt.Columns.Add(COL_USER_STATUS, typeof(string));
                dt.Columns.Add(COL_USER_KEY, typeof(string));
                dt.Columns.Add(COL_USER_OUTPUTFORMFILENAME, typeof(string));
                dt.Columns.Add(COL_USER_DISPLAYNAME, typeof(string));
                dt.Columns.Add(COL_USER_USERPRTPPRIDDERIVNO, typeof(Int32));
                dt.Columns.Add(COL_USER_PRTPPRUSERDERIVNOCMT, typeof(string));
                dt.Columns.Add(COL_USER_PRINTPAPERUSEDIVCD, typeof(Int32));
                dt.Columns.Add(COL_USER_PRINTPAPERUSEDIVCDNM, typeof(string));
                dt.Columns.Add(COL_USER_FREEPRTPPRITEMGRPCD, typeof(Int32));
                dt.Columns.Add(COL_USER_UPDATETIME, typeof(string));
                dt.Columns.Add(COL_USER_SYSTEMDIVCD, typeof(Int32));
                dt.Columns.Add(COL_USER_SYSTEMDIVNAME, typeof(string));
                dt.Columns.Add(COL_USER_OPTIONCODE, typeof(string));
                dt.Columns.Add(COL_USER_OPTIONNAME, typeof(string));
                
                dt.Columns[COL_USER_SELECT_UPDATE].Caption = "�㏑��";
                dt.Columns[COL_USER_EXISTFLG].Caption = "����";
                dt.Columns[COL_USER_UPDATEFLG].Caption = "�V�K";
                dt.Columns[COL_USER_STATUS].Caption = "���";
                dt.Columns[COL_USER_KEY].Caption = "KEY";
                dt.Columns[COL_USER_OUTPUTFORMFILENAME].Caption = "�o�̓t�@�C����";
                dt.Columns[COL_USER_DISPLAYNAME].Caption = "���[����";
                dt.Columns[COL_USER_USERPRTPPRIDDERIVNO].Caption = "���[�U�[���[ID�}�ԍ�";
                dt.Columns[COL_USER_PRTPPRUSERDERIVNOCMT].Caption = "�R�����g";
                dt.Columns[COL_USER_FREEPRTPPRITEMGRPCD].Caption = "�󎚍��ڃO���[�v�R�[�h";
                dt.Columns[COL_USER_UPDATETIME].Caption = "�T�[�o�[�X�V����";
                dt.Columns[COL_USER_SYSTEMDIVCD].Caption = "�V�X�e���敪";
                dt.Columns[COL_USER_SYSTEMDIVNAME].Caption = "�V�X�e��";
                dt.Columns[COL_USER_OPTIONCODE].Caption = "�I�v�V�����R�[�h";
                dt.Columns[COL_USER_OPTIONNAME].Caption = "�I�v�V��������";
                dt.Columns[COL_USER_PRINTPAPERUSEDIVCD].Caption = "���[�g�p�敪�R�[�h";
                dt.Columns[COL_USER_PRINTPAPERUSEDIVCDNM].Caption = "���[�g�p�敪";
                

                ds.Tables.Add(dt);
            }

            if (dt != null)
            {
                if (this._localPrtPosSet_SortedList != null)
                {
                    if (this._localPrtPosSet_SortedList.Count > 0)
                    {
                        foreach (SFANL08230AF userPrtPosSet in this._localPrtPosSet_SortedList.Values)
                        {
                            DataRow dr = dt.NewRow();
                            this.SetDataRow_UserPrtPosSet(ref dr, userPrtPosSet);
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }
        }
        #endregion

        #region �󎚈ʒu�ݒ� �f�[�^�s�擾����
        /// <summary>
        /// �󎚈ʒu�ݒ�i���[�J��XML�j�f�[�^�s�擾����
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <remarks>
        /// <br>Note		: �w�肵���L�[���󎚈ʒu�ݒ�i���[�J��XML�j�f�[�^�e�[�u���̍s���擾���܂�</br>
        /// <br>Programmer	: 22011 �����@���l</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        protected DataRow GetDataRow_User(string key)
        {
            DataRow dataRow = null;
            DataTable dt = this._dataSet.Tables[TABLE_USER];
            DataRow[] drs = dt.Select(COL_USER_KEY + "='" + key + "'");
            if (drs.Length > 0)
            {
                dataRow = drs[0];
            }
            return dataRow;
        }

        /// <summary>
        /// �󎚈ʒu�ݒ�i���[�U�[DB�j�f�[�^�s�擾����
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <remarks>
        /// <br>Note		: �w�肵���L�[���󎚈ʒu�ݒ�i���[�U�[DB�j�f�[�^�e�[�u���̍s���擾���܂�</br>
        /// <br>Programmer	: 22011 �����@���l</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        protected DataRow GetDataRow_Offer(string key)
        {
            DataRow dataRow = null;
            DataTable dt = this._dataSet.Tables[TABLE_OFFER];
            DataRow[] drs = dt.Select(COL_OFFER_KEY + "='" + key + "'");
            if (drs.Length > 0)
            {
                dataRow = drs[0];
            }
            return dataRow;
        }
            #endregion

        #region �󎚈ʒu�ݒ�i���[�U�[DB�j�\�[�g���X�g�擾����
        /// <summary>
        /// �󎚈ʒu�ݒ�i���[�U�[DB�j�\�[�g���X�g�擾����
        /// </summary>
        /// <param name="list"></param>
        /// <returns>�\�[�g���X�g</returns>
        /// <remarks>
        /// <br>Note		: �󎚈ʒu�ݒ�i���[�U�[DB�j�}�X�^�̃\�[�g���X�g���擾���܂��B</br>
        /// <br>Programmer	: 22011 �����@���l</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        protected SortedList MakeSortedList_OfferPrtPosSet(ArrayList list)
        {
            SortedList sortedList = new SortedList();

            foreach (SFANL08230AF offerPrtPosSet in list)
            {
                string key = MakeKeyForHashtable(offerPrtPosSet.OutputFormFileName, offerPrtPosSet.UserPrtPprIdDerivNo);
                sortedList.Add(key, offerPrtPosSet);
            }

            return sortedList;
        }
        #endregion

        #region �󎚈ʒu�i���[�U�[�j�f�[�^�e�[�u���s���e�Z�b�g����
        /// <summary>
        /// �󎚈ʒu�i���[�U�[�j�f�[�^�e�[�u���s���e�Z�b�g����
        /// </summary>
        /// <param name="dr">�X�V�Ώۍs</param>
        /// <param name="userPrtPosSet">�ǉ��Ώۂ̈󎚈ʒu�_�E�����[�h��ʃf�[�^�N���X�i���[�U�[�j</param>
        /// <remarks>
        /// <br>Note		: �󎚈ʒu�i�񋟁j�f�[�^�e�[�u���𐶐����ĕԂ��܂�</br>
        /// <br>Programmer	: 22011 �����@���l</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        protected void SetDataRow_UserPrtPosSet(ref DataRow dr, SFANL08230AF userPrtPosSet)
        {
            string status = string.Empty;

            if (userPrtPosSet.ExistingDataFlag == 1)
            {
                if (userPrtPosSet.UpdateFlag == UPDATEFLG_UPDATE)
                {
                    status = "�㏑��";
                }
                else
                {
                    status = "����";
                }
            }
            else
            {
                status = "�V�K";
            }

            if (userPrtPosSet.UpdateFlag == UPDATEFLG_NONE)
            {
                dr[COL_USER_SELECT_UPDATE] = 0;
            }
            else if (userPrtPosSet.UpdateFlag == UPDATEFLG_UPDATE)
            {
                dr[COL_USER_SELECT_UPDATE] = 1;
            }
            dr[COL_USER_UPDATEFLG] = userPrtPosSet.UpdateFlag;
            dr[COL_USER_EXISTFLG] = userPrtPosSet.ExistingDataFlag;

            dr[COL_USER_STATUS] = status;
            dr[COL_USER_KEY] = userPrtPosSet.KeyNo;
            dr[COL_USER_OUTPUTFORMFILENAME] = userPrtPosSet.OutputFormFileName;
            dr[COL_USER_USERPRTPPRIDDERIVNO] = userPrtPosSet.UserPrtPprIdDerivNo;
            dr[COL_USER_DISPLAYNAME] = userPrtPosSet.DisplayName;
            dr[COL_USER_PRTPPRUSERDERIVNOCMT] = userPrtPosSet.PrtPprUserDerivNoCmt;
            dr[COL_USER_FREEPRTPPRITEMGRPCD] = userPrtPosSet.FreePrtPprItemGrpCd;
            dr[COL_USER_UPDATETIME] = userPrtPosSet.UpdateDateTime.ToString("yyyy.MM.dd HH:mm:ss");
            dr[COL_USER_SYSTEMDIVCD] = userPrtPosSet.DataInputSystem;
            dr[COL_USER_SYSTEMDIVNAME] = this.GetSystemDivName(userPrtPosSet.DataInputSystem);
            dr[COL_USER_OPTIONCODE] = userPrtPosSet.OptionCode;
            dr[COL_USER_OPTIONNAME] = string.Empty;
            dr[COL_USER_PRINTPAPERUSEDIVCD] = userPrtPosSet.PrintPaperUseDivcd;
            dr[COL_USER_PRINTPAPERUSEDIVCDNM] = GetPrintPaperUserDivCdNm(userPrtPosSet.PrintPaperUseDivcd);
        }
        #endregion

        #region �󎚈ʒu�_�E�����[�h��ʃf�[�^�N���X�i���[�U�[�j�擾����
        /// <summary>
        /// �󎚈ʒu�_�E�����[�h��ʃf�[�^�N���X�i���[�U�[�j�擾����
        /// </summary>
        /// <param name="userSFANL08230AF">�擾�����󎚈ʒu�_�E�����[�h��ʃf�[�^�N���X</param>
        /// <param name="outputFormFileName">�o�̓t�@�C����</param>
        /// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
        /// <returns>�擾�����󎚈ʒu�_�E�����[�h��ʃf�[�^�N���X</returns>
        /// <remarks>
        /// <br>Note		: �w�肵���p�����[�^���\�[�g���X�g����󎚈ʒu�_�E�����[�h�f�[�^�N���X�i���[�U�[�j���擾���܂��B
        ///					  ���݂��Ȃ��ꍇ��null���Ԃ�܂�</br>
        /// <br>Programmer	: 22011 �����@���l</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        protected void GetUserSFANL08230AF(out SFANL08230AF userSFANL08230AF,string outputFormFileName, int userPrtPprIdDerivNo)
        {
            userSFANL08230AF = null;
            //�L���b�V���ɑ��݂��邩
            if (this._localPrtPosSet_SortedList.Contains(MakeKeyForHashtable(outputFormFileName ,userPrtPprIdDerivNo)))
            {
                userSFANL08230AF = (SFANL08230AF)_localPrtPosSet_SortedList[MakeKeyForHashtable(outputFormFileName ,userPrtPprIdDerivNo)];
            }
        }
        #endregion

        #region �󎚈ʒu�ݒ�i���[�J��XML�j�f�[�^�e�[�u���ǉ�����
        /// <summary>
        /// �󎚈ʒu�ݒ�i���[�J��XML�j�f�[�^�e�[�u���ǉ�����
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <param name="userPrtPosSet">�ǉ��Ώۂ̈󎚈ʒu�ݒ�i���[�J��XML�j</param>
        /// <remarks>
        /// <br>Note		: �󎚈ʒu�ݒ�i���[�J��XML�j�f�[�^�e�[�u���ɐV�����󎚈ʒu�ݒ�i���[�J��XML�j����ǉ����܂��B
        ///					  ���ɃL�[�����݂���ꍇ�͍X�V���܂�</br>
        /// <br>Programmer	: 22011 �����@���l</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        protected void AddUserDataTable(string key, SFANL08230AF userPrtPosSet)
        {
            DataRow dr = this.GetDataRow_User(key);

            if (dr == null)
            {
                DataTable dt = this._dataSet.Tables[TABLE_USER];
                dr = dt.NewRow();
                this.SetDataRow_UserPrtPosSet(ref dr, userPrtPosSet);
                dt.Rows.Add(dr);
            }
            else
            {
                this.SetDataRow_UserPrtPosSet(ref dr, userPrtPosSet);
            }
        }
        #endregion

        #endregion
    }
}
