using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller 
{
	/// <summary>
	/// �󎚈ʒu�_�E�����[�h��ʃA�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �󎚈ʒu�_�E�����[�h��ʃN���X�̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer	: 22011 �����@���l</br>
	/// <br>Date		: 2007.05.14</br>
	/// </remarks>
    public class DownLoadPrtPosAcs : SFANL08230AB
	{
		# region Constructor
		/// <summary>
		/// �󎚈ʒu�_�E�����[�h��ʃA�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note		: �󎚈ʒu�_�E�����[�h��ʃA�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public DownLoadPrtPosAcs()
		{
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			this._userPrtPosSetDBAcs = new SFANL08230AE();
            this._localPrtPosSetDBAcs = new FrePrtPosLocalAcs();    //���R���[�󎚈ʒu���[�J��XML�A�N�Z�X�N���X
            this._frePrtPSetAcs = new FrePrtPSetAcs();           //���R���[�󎚈ʒuDB�A�N�Z�X�N���X
        }
		# endregion

		#region Private Members
		// �󎚈ʒu�ݒ�(���[�U�[DB)�A�N�Z�X�N���X
		private SFANL08230AE  _userPrtPosSetDBAcs = null;
        // �󎚈ʒu�ݒ�(���[�J��XML)�A�N�Z�X�N���X
        private FrePrtPosLocalAcs _localPrtPosSetDBAcs = null;
        // �󎚈ʒu�ݒ�(���[�U�[DB)I/O���C�g�p�A�N�Z�X�N���X
        private FrePrtPSetAcs _frePrtPSetAcs = null;

        // ��ƃR�[�h
		private string _enterpriseCode = null;
		#endregion
		
		#region Public Methods

        #region �Ǘ����[�J���󎚈ʒu�f�[�^�폜����
        /// <summary>
        /// �Ǘ��������[�J���󎚈ʒu�f�[�^���폜���܂�
        /// </summary>
        /// <returns></returns>
        public int DeleteLonelyLocalData(out bool msgdiv,out string errmsg)
        {
            msgdiv = false;
            errmsg = string.Empty;
            int status = 0;
            List<string> delLs = new List<string>();

            // ���[�J���f�[�^�폜
            foreach (SFANL08230AF userPrtPosSet in this._localPrtPosSet_SortedList.Values)
            {
                string offerKey = MakeKeyForHashtable(userPrtPosSet.OutputFormFileName, userPrtPosSet.UserPrtPprIdDerivNo);
                if (!_serverPrtPosSet_SortedList.Contains(offerKey))
                {
                    status = _localPrtPosSetDBAcs.DeleteLocalFrePrtPSet(userPrtPosSet.EnterpriseCode, userPrtPosSet.OutputFormFileName, userPrtPosSet.UserPrtPprIdDerivNo);
                    if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                    {
                        msgdiv = true;
                        errmsg = _localPrtPosSetDBAcs.ErrorMessage;
                        return status;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        delLs.Add(offerKey);
                    }
                }
            }
            // �������L���b�V���폜
            foreach (string delkey in delLs)
            {
                _localPrtPosSet_SortedList.Remove(delkey);
            }

            return status;
        }
        #endregion

        #region �󎚈ʒu�ݒ�DB�擾����
        /// <summary>
		/// �󎚈ʒu�ݒ�DB�擾����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �󎚈ʒu�ݒ�DB���擾���܂�</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public int ReadDBData(out string errmsg)
		{
			int status;
			
			// �󎚈ʒu�ݒ�(���[�U�[DB)�c�a�Ǎ���
			ArrayList offerList;
			status = this.ReadDBData_OfferPrtPosSet(out offerList, out errmsg);
			if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
				(status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
				(status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_ERROR))
			{
			}
			else
			{
				return status;
			}

			// �󎚈ʒu�ݒ�(���[�J��XML)�c�a�Ǎ���
			ArrayList userList;
			status = this.ReadLocalFrePrtPSet(out userList, out errmsg);
			if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
				(status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
				(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
			{
			}
			else
			{
				return status;
			}
			
			this._serverPrtPosSet_SortedList	= this.MakeSortedList_OfferPrtPosSet(offerList);
			this._localPrtPosSet_SortedList		= this.MakeSortedList_UserPrtPosSet(userList);
			
			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        #endregion

        #region �󎚈ʒu�ݒ�DB�X�V����
        /// <summary>
		/// �󎚈ʒu�ݒ�DB�X�V����
		/// </summary>
		/// <param name="errmsg">�G���[���b�Z�[�W</param>
		/// <param name="downLoadCount">�_�E�����[�h����</param>
		/// <param name="updateCount">�㏑������</param>
		/// <remarks>
		/// <br>Note		: ���[�J���󎚈ʒu�ݒ�DB���X�V���܂�</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public int WriteDBData(out string errmsg, out int downLoadCount, out int updateCount)
		{
			errmsg = string.Empty;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			downLoadCount			= 0;
			updateCount				= 0;

            FrePrtPSet frePrtPSet = null;
            List<FrePprECnd> frePprECndLs = null;
            List<FrePprSrtO> frePprSrtOLs = null;
            string msgBuf = string.Empty;
            try
            {
                foreach (DictionaryEntry de in this._localPrtPosSet_SortedList)
                {
                    SFANL08230AF downLoadPrtPosSet = (SFANL08230AF)de.Value;
                    if (downLoadPrtPosSet.UpdateFlag == UPDATEFLG_NONE) { continue; }
                    frePrtPSet = null;

                    // ���[�J���f�[�^�Ǎ���(�w�i�摜�擾�L��)
                    status = this.ReadDB_UserFrePrtPSetWork(out frePrtPSet, out frePprECndLs, out frePprSrtOLs, downLoadPrtPosSet, out msgBuf);


                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        if (errmsg != string.Empty) errmsg += "\n";
                        errmsg += "[" + downLoadPrtPosSet.DisplayName + "," + downLoadPrtPosSet.PrtPprUserDerivNoCmt + "]��������܂���\n" + "���łɑ��[�����폜����Ă��܂�";
                        continue;
                    }

                    // ���[�J���X�V(�w�i�摜�X�V�L��)
                    status = this._localPrtPosSetDBAcs.WriteLocalFrePrtPSet(frePrtPSet, frePprECndLs, frePprSrtOLs);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        downLoadCount++;
                        if (downLoadPrtPosSet.UpdateFlag == UPDATEFLG_UPDATE)
                        {
                            updateCount++;
                        }

                        // �󎚈ʒu�_�E�����[�h��ʃf�[�^�N���X(���[�J��XML)�̍X�V
                        this.CopyToOfferPrtPosSetFromFrePrtPSet(ref downLoadPrtPosSet, frePrtPSet);
                        downLoadPrtPosSet.UpdateFlag = UPDATEFLG_NONE;
                        downLoadPrtPosSet.ExistingDataFlag = 1;

                        // �󎚈ʒu�_�E�����[�h��ʃf�[�^�N���X(���[�U�[DB)�̍X�V
                        string offerKey = MakeKeyForHashtable(frePrtPSet.OutputFormFileName, frePrtPSet.UserPrtPprIdDerivNo);
                        SFANL08230AF offerSFANL08230AF = (SFANL08230AF)this._serverPrtPosSet_SortedList[offerKey];
                        offerSFANL08230AF.UpdateFlag = UPDATEFLG_NONE;
                    }
                    else
                    {
                        errmsg += msgBuf +"\n";
                    }
                }
            }
            catch (Exception ex)
            {
                errmsg = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
			finally
			{
                if (errmsg != string.Empty) status = status = (Int32)ConstantManagement.DB_Status.ctDB_ERROR;
				this.SetDataTable_User(ref this._dataSet);
				this.SetDataTable_Offer(ref this._dataSet);
			}
			return status;
        }
        #endregion

        #region �󎚈ʒu�ݒ�Static�擾����
        /// <summary>
		/// �󎚈ʒu�ݒ�Static�擾����
		/// </summary>
		/// <param name="ds">�f�[�^�Z�b�g</param>
		/// <returns>�X�e�[�^�X(0:����)</returns>
		/// <remarks>
		/// <br>Note		: �󎚈ʒu�ݒ��Static�����擾���܂�</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public void ReadStaticData(out DataSet ds)
		{
			this.SetDataTable_User(ref this._dataSet);
			this.SetDataTable_Offer(ref this._dataSet);
			ds = this._dataSet;
        }
        #endregion

        #region �󎚈ʒu�ݒ�(���[�J��XML)�_�E�����[�h�x�����݊m�F����
        /// <summary>
		/// �󎚈ʒu�ݒ�(���[�J��XML)�_�E�����[�h�x�����݊m�F����
		/// </summary>
		/// <param name="msg">���b�Z�[�W</param>
		/// <returns>�`�F�b�N����[true:�x������,false:�x���Ȃ�]</returns>
		/// <remarks>
		/// <br>Note		: �󎚈ʒu�ݒ�(���[�J��XML)�Ɍx������ׂ��f�[�^�����݂��邩�ǂ����m�F���܂�</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public bool ExistsWarningData(out string msg)
		{
			msg = string.Empty;

			bool warningUpdate = false;
			bool warningMerge = false;

            foreach (SFANL08230AF user in this._localPrtPosSet_SortedList.Values)
            {
                // �X�V�Ȃ��̏ꍇ
                if (user.UpdateFlag == UPDATEFLG_NONE)
                {
                    continue;
                }

                // �V�K�ǉ��̏ꍇ
                if (user.ExistingDataFlag == 0)
                {
                    continue;
                }

                // ���[�J���f�[�^�̎擾
                string offerKey = MakeKeyForHashtable(user.OutputFormFileName, user.UserPrtPprIdDerivNo);

                if (!this._serverPrtPosSet_SortedList.Contains(offerKey))
                {
                    continue;
                }

                SFANL08230AF offer = (SFANL08230AF)this._serverPrtPosSet_SortedList[offerKey];

                // �㏑��
                if (user.UpdateFlag == UPDATEFLG_UPDATE)
                {
                    // �󎚈ʒu�o�[�W����
                    if (user.PrintPositionVer >= offer.PrintPositionVer)
                    {
                        warningUpdate = true;
                    }
                }

                if ((warningUpdate) && (warningMerge)) break;
            }
			if (warningUpdate)
			{
				msg += "���łɈ󎚈ʒu�o�[�W�������ŐV�ɂȂ��Ă���f�[�^������܂��B\n\r";
            }
            if ((warningUpdate) || (warningMerge))
			{
				msg += "\n\r���̂܂܍X�V���Ă���낵���ł����H";
				return true;
			}
			return false;
        }
        #endregion

        #region �󎚈ʒu�ݒ�(���[�J��XML)���݃`�F�b�N����
        /// <summary>
		/// �󎚈ʒu�ݒ�(���[�J��XML)���݃`�F�b�N����
		/// </summary>
		/// <param name="outputFormFileName">�o�̓t�@�C����</param>
		/// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
		/// <param name="prtPprUserDerivNoCmt">���[���[�U�[�}�ԃR�����g</param>
		/// <returns>�`�F�b�N����[0:�d���Ȃ�,1:�d������(���[�U�[���[ID�}�ԍ�),2:�d������(���[���[�U�[�}�ԃR�����g)]</returns>
		/// <remarks>
		/// <br>Note		: �w�肵���L�[�̃f�[�^����ʏ�̃��[�J�����X�g�ɑ��݂��邩�𔻒肵�܂�</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public int ExistsUserPrtPosSet(string outputFormFileName, int userPrtPprIdDerivNo, string prtPprUserDerivNoCmt)
		{
            if (this._localPrtPosSet_SortedList.Contains(MakeKeyForHashtable(outputFormFileName, userPrtPprIdDerivNo)))
            {
                return 1;
            }
            else
            {
                // ���[���[�U�[�}�ԃR�����g
                foreach (SFANL08230AF userPrtPosSet in _localPrtPosSet_SortedList.Values)
                {
                    if (userPrtPosSet.PrtPprUserDerivNoCmt == prtPprUserDerivNoCmt)
                    {
                        return 2;
                    }
                }
            }
			return 0;
        }
        #endregion

        #region �󎚈ʒu�ݒ�(���[�J��)�I������
        /// <summary>
		/// �󎚈ʒu�ݒ�(���[�J��)�I������
		/// </summary>
		/// <param name="keys">�Ώۂ̈󎚈ʒu�ݒ����KEY�̔z��</param>
		/// <param name="update">�㏑��(0:�I���Ȃ�,1:�I������)</param>
		/// <remarks>
		/// <br>Note		: �󎚈ʒu�ݒ�(���[�J��XML)��I���E�I�������������̔��f�������s���܂�</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public void ChangeSelect_User(string[] keys, int update)
		{
			for (int ix = 0; ix < keys.Length; ix++)
			{
				string userKey = keys[ix];

				DataRow dr = this.GetDataRow_User(userKey);
				if (dr == null)
				{
					continue;
				}

				SFANL08230AF userPrtPosSet;
				string outputFormFileName	= (string)dr[COL_USER_OUTPUTFORMFILENAME].ToString();
                int userPrtPprIdDerivNo		= ConvertToInt32(dr[COL_USER_USERPRTPPRIDDERIVNO]);

				// �\�[�g���X�g(���[�J��)���f�[�^���擾
				this.GetUserSFANL08230AF(out userPrtPosSet, outputFormFileName, userPrtPprIdDerivNo);
				if (userPrtPosSet == null)
				{
					continue;
				}

				if (update == 1)
				{
					if (userPrtPosSet.ExistingDataFlag == 0)
					{
						continue;
					}
					userPrtPosSet.UpdateFlag = UPDATEFLG_UPDATE;
					this.AddUserDataTable(userKey, userPrtPosSet);
				}
                else
                {
					if (userPrtPosSet.ExistingDataFlag == 0)
					{
						_localPrtPosSet_SortedList.Remove(MakeKeyForHashtable(userPrtPosSet.OutputFormFileName,userPrtPosSet.UserPrtPprIdDerivNo));
						this._dataSet.Tables[TABLE_USER].Rows.Remove(dr);
					}
					else
					{
						userPrtPosSet.UpdateFlag = UPDATEFLG_NONE;
						this.AddUserDataTable(userKey, userPrtPosSet);
					}
				}
            }
            // �������烍�[�J���f�[�^�̑I����Ԃ𑀍�

			// �\�[�g���X�g(���[�J���f�[�^)������
			foreach (DictionaryEntry de in this._serverPrtPosSet_SortedList)
			{
				SFANL08230AF offer = (SFANL08230AF)de.Value;
                string offerKey = offer.KeyNo;
				SFANL08230AF userPrtPosSet;

				// �\�[�g���X�g(���[�J��)���f�[�^���擾
				this.GetUserSFANL08230AF(out userPrtPosSet, offer.OutputFormFileName, offer.UserPrtPprIdDerivNo);

				bool isHit = false;

                if (userPrtPosSet != null)
                {
                    // �I������Ă�����̂����邩����
                    if (userPrtPosSet.UpdateFlag != UPDATEFLG_NONE)
                    {
                        isHit = true;
                    }
                }

				if (isHit)
				{
					offer.UpdateFlag = UPDATEFLG_UPDATE;
				}
				else
				{
					offer.UpdateFlag = UPDATEFLG_NONE;
				}

				// ���[�J���f�[�^�e�[�u������
				DataRow offerDataRow = GetDataRow_Offer(offerKey);
				if (offerDataRow != null)
				{
					if (isHit)
					{
						offerDataRow[COL_OFFER_SELECT] = 1;
					}
					else
					{
						offerDataRow[COL_OFFER_SELECT] = 0;
					}
				}

			}
        }
        #endregion

        #region �󎚈ʒu�ݒ�(���[�U�[DB)�I������
        /// <summary>
		/// �󎚈ʒu�ݒ�(���[�U�[DB)�I������
		/// </summary>
		/// <param name="keys">�Ώۂ̈󎚈ʒu�ݒ����KEY�̔z��</param>
		/// <param name="isSelect">�I��L��</param>
		/// <remarks>
		/// <br>Note		: �󎚈ʒu�ݒ�(���[�U�[DB)��I���E�I�������������̔��f�������s���܂�</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public void ChangeSelect_Offer(string[] keys, bool isSelect)
		{
			for (int ix = 0; ix < keys.Length; ix++)
			{
				string offerKey = keys[ix];

				// ���[�J���f�[�^�\�[�g���X�g�ɖ����ꍇ
				if (!this._serverPrtPosSet_SortedList.Contains(offerKey))
				{
					continue;
				}

				SFANL08230AF offerPrtPosSet = (SFANL08230AF)this._serverPrtPosSet_SortedList[offerKey];

				// ���[�J���f�[�^�e�[�u���ɖ����ꍇ
				DataRow offerDataRow = GetDataRow_Offer(offerKey);
				if (offerDataRow == null)
				{
					continue;
				}

				if (isSelect)
				{
					offerPrtPosSet.UpdateFlag = UPDATEFLG_UPDATE;
					offerDataRow[COL_OFFER_SELECT] = 1;
				}
				else
				{
					offerPrtPosSet.UpdateFlag = UPDATEFLG_NONE;
					offerDataRow[COL_OFFER_SELECT] = 0;
				}


				// ���[�J���f�[�^�ɔ��f
				SFANL08230AF userPrtPosSet;

				// �\�[�g���X�g(���[�J��)���f�[�^���擾
				this.GetUserSFANL08230AF(out userPrtPosSet, offerPrtPosSet.OutputFormFileName, offerPrtPosSet.UserPrtPprIdDerivNo);

				// �V�K�ǉ�
                if (userPrtPosSet == null)
                {
                    if (isSelect)
                    {
                        if (!_localPrtPosSet_SortedList.Contains(MakeKeyForHashtable(offerPrtPosSet.OutputFormFileName, 0)))
                        {
                            SFANL08230AF user = offerPrtPosSet.Clone();
                            user.UpdateFlag = UPDATEFLG_UPDATE;
                            user.ExistingDataFlag = 0;
                            user.KeyNo = MakeKeyForHashtable(user.OutputFormFileName, user.UserPrtPprIdDerivNo);
                            if (!this._localPrtPosSet_SortedList.Contains(MakeKeyForHashtable(offerPrtPosSet.OutputFormFileName, user.UserPrtPprIdDerivNo)))
                            {
                                this._localPrtPosSet_SortedList.Add(MakeKeyForHashtable(offerPrtPosSet.OutputFormFileName, offerPrtPosSet.UserPrtPprIdDerivNo), user);
                            }
                            this.AddUserDataTable(user.KeyNo, user);
                        }
                    }
                }
                // �X�V
                else
                {
                    if (isSelect)
                    {
                        userPrtPosSet.UpdateFlag = UPDATEFLG_UPDATE;
                        this.AddUserDataTable(userPrtPosSet.KeyNo, userPrtPosSet);
                    }
                    else
                    {
                        if (userPrtPosSet.ExistingDataFlag == 0)
                        {
                            DataTable dt = this._dataSet.Tables[TABLE_USER];
                            DataRow dr = this.GetDataRow_User(userPrtPosSet.KeyNo);
                            dt.Rows.Remove(dr);

                            _localPrtPosSet_SortedList.Remove(MakeKeyForHashtable(userPrtPosSet.OutputFormFileName, userPrtPosSet.UserPrtPprIdDerivNo));
                        }
                        else
                        {
                            userPrtPosSet.UpdateFlag = UPDATEFLG_NONE;
                            this.AddUserDataTable(userPrtPosSet.KeyNo, userPrtPosSet);
                        }
                    }
                }
			}
        }
        #endregion

        #region �󎚈ʒu�ݒ�(���[�U�[DB)�����[�U�[�}�Ԓǉ�����
        /// <summary>
		/// �󎚈ʒu�ݒ�(���[�U�[DB)�����[�U�[�}�Ԓǉ�����
		/// </summary>
		/// <param name="offerKey">�ǉ��Ώۂ̈󎚈ʒu�ݒ����KEY</param>
		/// <param name="userComment">���[�U�[�R�����g</param>
		/// <remarks>
		/// <br>Note		: �󎚈ʒu�ݒ�(���[�U�[DB)��ǉ��I���������̔��f�������s���܂�</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public void AddCustomUserFromOffer(string offerKey, string userComment)
		{
			// ���[�J���f�[�^�\�[�g���X�g�ɑ��݂���ꍇ
			if (this._serverPrtPosSet_SortedList.Contains(offerKey))
			{
				SFANL08230AF offerPrtPosSet = (SFANL08230AF)this._serverPrtPosSet_SortedList[offerKey];

				// ���[�J���f�[�^�e�[�u���ɑ��݂��Ȃ��ꍇ
				DataRow offerDataRow = GetDataRow_Offer(offerKey);
				if (offerDataRow == null)
				{
					return;
				}

				offerPrtPosSet.UpdateFlag = UPDATEFLG_UPDATE;
				offerDataRow[COL_OFFER_SELECT] = 1;


				// ���[�J���f�[�^�ɔ��f
                SFANL08230AF userPrtPosSet;

				// �\�[�g���X�g(���[�J��)���f�[�^���擾
				this.GetUserSFANL08230AF(out userPrtPosSet, offerPrtPosSet.OutputFormFileName, offerPrtPosSet.UserPrtPprIdDerivNo);

				// ���[�U�[�}�ԍ̔Ԃƃ��[�U�[�R�����g�쐬���s��
				int userDerivNo		= 1;

				// ���꒠�[�����݂���ꍇ
                if (userPrtPosSet != null)
				{
					userDerivNo = this.Set_UserPrtPprIdDerivNo(_localPrtPosSet_SortedList, userDerivNo);
					userComment = this.Set_UserComment(_localPrtPosSet_SortedList, userComment);
				}

				// ���[�J���f�[�^���x�[�X�Ƃ���
				userPrtPosSet = offerPrtPosSet.Clone();

				userPrtPosSet.UserPrtPprIdDerivNo	= userDerivNo;
				userPrtPosSet.PrtPprUserDerivNoCmt	= userComment;
				userPrtPosSet.UpdateFlag			= UPDATEFLG_UPDATE;
				userPrtPosSet.ExistingDataFlag		= 0;
				userPrtPosSet.KeyNo					= MakeKeyForHashtable(userPrtPosSet.OutputFormFileName, userPrtPosSet.UserPrtPprIdDerivNo);

                if (!this._localPrtPosSet_SortedList.Contains(MakeKeyForHashtable(offerPrtPosSet.OutputFormFileName,offerPrtPosSet.UserPrtPprIdDerivNo)))
				{
                    this._localPrtPosSet_SortedList.Add(MakeKeyForHashtable(offerPrtPosSet.OutputFormFileName ,offerPrtPosSet.UserPrtPprIdDerivNo), userPrtPosSet);
                    this.AddUserDataTable(userPrtPosSet.KeyNo, userPrtPosSet);
                }
			}
        }
        #endregion

        #region �R���o�[�g�idouble�j����
        /// <summary>
		/// �R���o�[�g�idouble�j����
		/// </summary>
		/// <param name="source">�R���o�[�g�Ώ�</param>
		/// <returns>�R���o�[�g����</returns>
		/// <remarks>
		/// <br>Note		: �I�u�W�F�N�g��double�^�ɃR���o�[�g���܂��B�R���o�[�g�o���Ȃ��I�u�W�F�N�g�̏ꍇ�͂O��Ԃ��܂��B</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public static double ConvertToDouble(object source)
		{
			double dest = 0;
			try
			{
				dest = Convert.ToDouble(source);
			}
			catch
			{
				dest = 0;
			}
			return dest;
        }
        #endregion

        #region �R���o�[�g�idouble�j���� + 1
        /// <summary>
		/// �R���o�[�g�idouble�j����
		/// </summary>
		/// <param name="dest">�R���o�[�g����</param>
		/// <param name="source">�R���o�[�g�Ώ�</param>
		/// <returns>true:���� false:���s</returns>
		/// <remarks>
		/// <br>Note		: �I�u�W�F�N�g��double�^�ɃR���o�[�g���܂��B</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public static bool ConvertToDouble(ref double dest, object source)
		{
			dest = 0;
			try
			{
				dest = Convert.ToDouble(source);
			}
			catch
			{
				return false;
			}
			return true;
        }
        #endregion

        #region �R���o�[�g�iInt32�j����
        /// <summary>
		/// �R���o�[�g�iInt32�j����
		/// </summary>
		/// <param name="dest">�R���o�[�g����</param>
		/// <param name="source">�R���o�[�g�Ώ�</param>
		/// <returns>true:���� false:���s</returns>
		/// <remarks>
		/// <br>Note		: �I�u�W�F�N�g��Int32�^�ɃR���o�[�g���܂��B</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public static bool ConvertToInt32(ref Int32 dest, object source)
		{
			dest = 0;
			try
			{
				dest = Convert.ToInt32(source);
			}
			catch
			{
				return false;
			}
			return true;
        }
        #endregion

        #region �R���o�[�g�iInt64�j����
        /// <summary>
		/// �R���o�[�g�iInt64�j����
		/// </summary>
		/// <param name="source">�R���o�[�g�Ώ�</param>
		/// <returns>�R���o�[�g����</returns>
		/// <remarks>
		/// <br>Note		: �I�u�W�F�N�g��Int64�^�ɃR���o�[�g���܂��B�R���o�[�g�o���Ȃ��I�u�W�F�N�g�̏ꍇ�͂O��Ԃ��܂��B</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public static Int64 ConvertToInt64(object source)
		{
			Int64 dest = 0;
			try
			{
				dest = Convert.ToInt64(source);
			}
			catch
			{
				dest = 0;
			}
			return dest;
        }
        #endregion

        #region �R���o�[�g�iInt64�j���� + 1
        /// <summary>
		/// �R���o�[�g�iInt64�j����
		/// </summary>
		/// <param name="dest">�R���o�[�g����</param>
		/// <param name="source">�R���o�[�g�Ώ�</param>
		/// <returns>true:���� false:���s</returns>
		/// <remarks>
		/// <br>Note		: �I�u�W�F�N�g��Int64�^�ɃR���o�[�g���܂��B</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		public static bool ConvertToInt64(ref Int64 dest, object source)
		{
			dest = 0;
			try
			{
				dest = Convert.ToInt64(source);
			}
			catch
			{
				return false;
			}
			return true;
        }
        #endregion

        #region�@�T�[�o�[���L���b�V���폜����
        /// <summary>
        /// �T�[�o�[���̃L���b�V������w�肵���L�[�̃f�[�^���폜���܂�
        /// </summary>
        /// <param name="key"></param>
        public void DeleteOfferCash(string key)
        {
            if (_serverPrtPosSet_SortedList.Contains(key))
            {
                _serverPrtPosSet_SortedList.Remove(key);
            }
        }
        #endregion

        #endregion

        #region Private Methods

        #region �󎚈ʒu�ݒ�(���[�U�[DB)�c�a�Ǎ��ݏ���
        /// <summary>
        /// �󎚈ʒu�ݒ�(���[�U�[DB)�c�a�Ǎ��ݏ���
		/// </summary>
		/// <param name="offerPrtPosSetList">�擾�����󎚈ʒu�ݒ�N���X���X�g�i���[�J���f�[�^���j</param>
		/// <param name="errmsg">�G���[���b�Z�[�W</param>
		/// <returns>�쐬�����L�[������</returns>
		/// <remarks>
		/// <br>Note		: �󎚈ʒu�ݒ�(���[�U�[DB)�c�a��Ǎ��݂܂��B</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		private int ReadDBData_OfferPrtPosSet(out ArrayList offerPrtPosSetList, out string errmsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			offerPrtPosSetList = new ArrayList();

			// ���[�J���f�[�^
			FrePrtPSetWork[] frePrtPSetWorks;
			status = this._userPrtPosSetDBAcs.Search(_enterpriseCode, string.Empty, out frePrtPSetWorks, 0, ConstantManagement.LogicalMode.GetData0, out errmsg);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				for (int ix = 0; ix < frePrtPSetWorks.Length; ix++)
				{
					SFANL08230AF offerPrtPosSet = new SFANL08230AF();
					this.CopyToOfferPrtPosSetFromWork(ref offerPrtPosSet, frePrtPSetWorks[ix]);
					offerPrtPosSetList.Add(offerPrtPosSet);
				}
			}

			return status;
        }
        #endregion

        /// <summary>
		/// �󎚈ʒu�ݒ�(���[�J��XML)�c�a�Ǎ��ݏ���
		/// </summary>
		/// <param name="userPrtPosSetList">�擾�����󎚈ʒu�ݒ�N���X���X�g�i���[�U�[���j</param>
		/// <param name="errmsg">�G���[���b�Z�[�W</param>
		/// <returns>�쐬�����L�[������</returns>
		/// <remarks>
		/// <br>Note		: �󎚈ʒu�ݒ�(���[�J��XML)�c�a��Ǎ��݂܂��B</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		private int ReadLocalFrePrtPSet(out ArrayList userPrtPosSetList, out string errmsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errmsg = "";

			userPrtPosSetList = new ArrayList();
			
            List<FrePrtPSet> frePrtPSetList = new List<FrePrtPSet>();
            List<FrePprECnd> frePprECndList = new List<FrePprECnd>();
            List<FrePprSrtO> frePprSrtOList = new List<FrePprSrtO>();

            status = this._localPrtPosSetDBAcs.SearchLocalFrePrtPSet(_enterpriseCode, 0,out frePrtPSetList, out frePprECndList, out frePprSrtOList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                foreach(FrePrtPSet frePrtPosSet in frePrtPSetList) 
                {
                    
                    SFANL08230AF userPrtPosSet = new SFANL08230AF();
                    this.CopyToOfferPrtPosSetFromFrePrtPSet(ref userPrtPosSet, frePrtPosSet);
                    userPrtPosSetList.Add(userPrtPosSet);
                }
			}

			return status;
		}
		
		/// <summary>
		/// ���[�U�[�}�ԍ̔ԏ���
		/// </summary>
		/// <param name="sortedList">���[�U�[���X�g</param>
		/// <param name="defaultNo">�����l</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[�}�ԍ̔Ԃ��s���܂�</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		private int Set_UserPrtPprIdDerivNo(SortedList sortedList, int defaultNo)
		{
			int no = defaultNo;

			while (true)
			{
				bool isHit = false;
                foreach (SFANL08230AF user in sortedList.Values)
				{
					if (user.UserPrtPprIdDerivNo == no)
					{
						isHit = true;
						break;
					}
				}

				if (!isHit)	break;

				no++;
			}

			return no;
		}
		
		/// <summary>
		/// ���[�U�[�R�����g�쐬����
		/// </summary>
		/// <param name="sortedList">���[�U�[���X�g</param>
		/// <param name="defaultCmt">�R�����g�����l</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[�R�����g�쐬���s���܂�</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		private string Set_UserComment(SortedList sortedList, string defaultCmt)
		{
			int no = 0;
			string comment;

			// �R�����g�����l���ݒ肳��Ă���ꍇ
			if (defaultCmt.Trim() != string.Empty)
			{
				comment = defaultCmt;
			}
			else
			{
				no++;
				comment = "���[�J��" + no.ToString();
			}

			while (true)
			{
				bool isHit = false;

                foreach (SFANL08230AF user in sortedList.Values)
				{
					if (user.PrtPprUserDerivNoCmt == comment)
					{
						isHit = true;
						break;
					}
				}

				if (!isHit)	break;

				no++;

				if (defaultCmt.Trim() != string.Empty)
				{
					comment = defaultCmt + no.ToString();
				}
				else
				{
					comment = "���[�J��" + no.ToString();
				}
			}

			return comment;
		}
        
        /// <summary>
        ///  �󎚈ʒu�ݒ�f�[�^(���[�J��XML)�Ǎ��ݏ���
        /// </summary>
        /// <param name="userFrePrtPSet">�󎚈ʒu�ݒ�f�[�^</param>
        /// <param name="frePprECndLs">���o����</param>
        /// <param name="frePprSrtOLs">�\�[�g��</param>
        /// <param name="errmsg">�G���[���b�Z�[�W</param>
        /// <param name="downLoadPrtPosSet">�󎚈ʒu�_�E�����[�h��ʃf�[�^�N���X</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: �󎚈ʒu�ݒ�f�[�^(���[�J��XML)�̂c�a�Ǎ��ݏ������s���܂�</br>
        /// <br>Programmer	: 22011 �����@���l</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        private int ReadDB_UserFrePrtPSetWork(out FrePrtPSet userFrePrtPSet, out List<FrePprECnd> frePprECndLs, out List<FrePprSrtO> frePprSrtOLs, SFANL08230AF downLoadPrtPosSet, out string errmsg)
		{
            int status = 0;
            errmsg = "";

            // �L�[�݂̂�ݒ�
			userFrePrtPSet = new FrePrtPSet();
            userFrePrtPSet.EnterpriseCode       = downLoadPrtPosSet.EnterpriseCode;
            userFrePrtPSet.OutputFormFileName   = downLoadPrtPosSet.OutputFormFileName;
            userFrePrtPSet.UserPrtPprIdDerivNo  = downLoadPrtPosSet.UserPrtPprIdDerivNo;

            //DB����Ǎ�
            status = _frePrtPSetAcs.ReadDBFrePrtPSet(ref userFrePrtPSet, out frePprECndLs, out frePprSrtOLs);

			if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)||
				(status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
			{
			}
			else
			{
                errmsg = _frePrtPSetAcs.ErrorMessage;
				throw new DownLoadPrtPosException(errmsg, status);
			}

			return status;
        }

		/// <summary>
		/// �󎚈ʒu�ݒ�(���[�J��XML)�\�[�g���X�g�쐬����
		/// </summary>
		/// <param name="list"></param>
		/// <returns>�\�[�g���X�g</returns>
		/// <remarks>
		/// <br>Note		: �󎚈ʒu�ݒ�(���[�J��XML)�}�X�^�̃\�[�g���X�g���擾���܂��B</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		private SortedList MakeSortedList_UserPrtPosSet(ArrayList list)
		{
			SortedList sortedList = new SortedList();
			
			foreach (SFANL08230AF userPrtPosSet in list)
			{
                // �o�̓t�@�C���������X�g�ɑ��݂��Ȃ��ꍇ�쐬
                if (!sortedList.Contains(MakeKeyForHashtable(userPrtPosSet.OutputFormFileName,userPrtPosSet.UserPrtPprIdDerivNo)))
				{
                    sortedList.Add(MakeKeyForHashtable(userPrtPosSet.OutputFormFileName,userPrtPosSet.UserPrtPprIdDerivNo), userPrtPosSet);
				}
			}
			
			return sortedList;
        }

        
        /// <summary>
		/// �󎚈ʒu�ݒ�N���X(���[�U�[DB)���󎚈ʒu�_�E�����[�h��ʃf�[�^�N���X��������
		/// </summary>
		/// <param name="target">������̈󎚈ʒu�_�E�����[�h��ʃf�[�^�N���X</param>
		/// <param name="source">�������̈󎚈ʒu�ݒ�N���X(���[�U�[DB)</param>
		/// <remarks>
		/// <br>Note		: �󎚈ʒu�ݒ�N���X(���[�U�[DB)�̓��e���󎚈ʒu�_�E�����[�h��ʃf�[�^�N���X�ɕ������܂�</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		private void CopyToOfferPrtPosSetFromWork(ref SFANL08230AF target, FrePrtPSetWork source)
        {
            target.CreateDateTime = source.CreateDateTime;
            target.UpdateDateTime = source.UpdateDateTime;
            target.EnterpriseCode = source.EnterpriseCode;
            target.FileHeaderGuid = source.FileHeaderGuid;
            target.UpdEmployeeCode = source.UpdEmployeeCode;
            target.UpdAssemblyId1 = source.UpdAssemblyId1;
            target.UpdAssemblyId2 = source.UpdAssemblyId2;
            target.LogicalDeleteCode = source.LogicalDeleteCode;
            target.OutputFormFileName = source.OutputFormFileName;
            target.UserPrtPprIdDerivNo = source.UserPrtPprIdDerivNo;
            target.PrintPaperUseDivcd = source.PrintPaperUseDivcd;
            target.PrintPaperDivCd = source.PrintPaperDivCd;
            target.ExtractionPgId = source.ExtractionPgId;
            target.ExtractionPgClassId = source.ExtractionPgClassId;
            target.OutputPgId = source.OutputPgId;
            target.OutputPgClassId = source.OutputPgClassId;
            target.OutConfimationMsg = source.OutConfimationMsg;
            target.DisplayName = source.DisplayName;
            target.PrtPprUserDerivNoCmt = source.PrtPprUserDerivNoCmt;
            target.PrintPositionVer = source.PrintPositionVer;
            target.MergeablePrintPosVer = source.MergeablePrintPosVer;
            target.DataInputSystem = source.DataInputSystem;
            target.OptionCode = source.OptionCode;
            target.FreePrtPprItemGrpCd = source.FreePrtPprItemGrpCd;
            target.PrtPprBgImageRowPos = source.PrtPprBgImageRowPos;
            target.PrtPprBgImageColPos = source.PrtPprBgImageColPos;
            target.TakeInImageGroupCd = source.TakeInImageGroupCd;
            target.PrintPosClassData = source.PrintPosClassData;
            target.FreePrtPprSpPrpseCd = source.FreePrtPprSpPrpseCd;
            target.TakeInImageGroupCd = source.TakeInImageGroupCd;
            target.KeyNo = MakeKeyForHashtable(target.OutputFormFileName, target.UserPrtPprIdDerivNo);
            target.UpdateFlag = UPDATEFLG_NONE;
            target.ExistingDataFlag = 1;
        }

        /// <summary>
        /// �󎚈ʒu�ݒ�N���X���󎚈ʒu�ݒ胏�[�N�N���X 
        /// </summary>
        /// <param name="target">�󎚈ʒu�ݒ胏�[�N�N���X</param>
        /// <param name="source">�󎚈ʒu�ݒ�N���X</param>
        /// <param name="enterpriseCode"></param>
        private void CopyToFrePrtPSetWorkFromFrePrtPSet(ref FrePrtPSetWork target, FrePrtPSet source, string enterpriseCode)
        {
            target.CreateDateTime = source.CreateDateTime;
            target.UpdateDateTime = source.UpdateDateTime;
            target.EnterpriseCode = source.EnterpriseCode;
            target.FileHeaderGuid = source.FileHeaderGuid;
            target.UpdEmployeeCode = source.UpdEmployeeCode;
            target.UpdAssemblyId1 = source.UpdAssemblyId1;
            target.UpdAssemblyId2 = source.UpdAssemblyId2;
            target.LogicalDeleteCode = source.LogicalDeleteCode;
            target.OutputFormFileName = source.OutputFormFileName;
            target.UserPrtPprIdDerivNo = source.UserPrtPprIdDerivNo;
            target.PrintPaperUseDivcd = source.PrintPaperUseDivcd;
            target.PrintPaperDivCd = source.PrintPaperDivCd;
            target.ExtractionPgId = source.ExtractionPgId;
            target.ExtractionPgClassId = source.ExtractionPgClassId;
            target.OutputPgId = source.OutputPgId;
            target.OutputPgClassId = source.OutputPgClassId;
            target.OutConfimationMsg = source.OutConfimationMsg;
            target.DisplayName = source.DisplayName;
            target.PrtPprUserDerivNoCmt = source.PrtPprUserDerivNoCmt;
            target.PrintPositionVer = source.PrintPositionVer;
            target.MergeablePrintPosVer = source.MergeablePrintPosVer;
            target.DataInputSystem = source.DataInputSystem;
            target.OptionCode = source.OptionCode;
            target.FreePrtPprItemGrpCd = source.FreePrtPprItemGrpCd;
            target.FormFeedLineCount = source.FormFeedLineCount;
            target.EdgeCharProcDivCd = source.EdgeCharProcDivCd;
            target.PrtPprBgImageRowPos = source.PrtPprBgImageRowPos;
            target.PrtPprBgImageColPos = source.PrtPprBgImageColPos;
            target.TakeInImageGroupCd = source.TakeInImageGroupCd;
            target.FreePrtPprSpPrpseCd = source.FreePrtPprSpPrpseCd;
            target.PrintPosClassData = source.PrintPosClassData;

        }

        /// <summary>
        /// �󎚈ʒu�ݒ�N���X(���[�U�[DB)���󎚈ʒu�_�E�����[�h��ʃf�[�^�N���X��������
        /// </summary>
        /// <param name="target">������̈󎚈ʒu�_�E�����[�h��ʃf�[�^�N���X</param>
        /// <param name="source">�������̈󎚈ʒu�ݒ�N���X(���[�U�[DB)</param>
        /// <remarks>
        /// <br>Note		: �󎚈ʒu�ݒ�N���X(���[�U�[DB)�̓��e���󎚈ʒu�_�E�����[�h��ʃf�[�^�N���X�ɕ������܂�</br>
        /// <br>Programmer	: 22011 �����@���l</br>
        /// <br>Date		: 2007.05.14</br>
        /// </remarks>
        private void CopyToOfferPrtPosSetFromFrePrtPSet(ref SFANL08230AF target, FrePrtPSet source)
        {
            target.CreateDateTime = source.CreateDateTime;
            target.UpdateDateTime = source.UpdateDateTime;
            target.EnterpriseCode = source.EnterpriseCode;
            target.FileHeaderGuid = new Guid();
            target.UpdEmployeeCode = source.UpdEmployeeCode;
            target.UpdAssemblyId1 = source.UpdAssemblyId1;
            target.UpdAssemblyId2 = source.UpdAssemblyId2;
            target.LogicalDeleteCode = source.LogicalDeleteCode;
            target.OutputFormFileName = source.OutputFormFileName;
            target.UserPrtPprIdDerivNo = source.UserPrtPprIdDerivNo;
            target.PrintPaperUseDivcd = source.PrintPaperUseDivcd;
            target.PrintPaperDivCd = source.PrintPaperDivCd;
            target.ExtractionPgId = source.ExtractionPgId;
            target.ExtractionPgClassId = source.ExtractionPgClassId;
            target.OutputPgId = source.OutputPgId;
            target.OutputPgClassId = source.OutputPgClassId;
            target.OutConfimationMsg = source.OutConfimationMsg;
            target.DisplayName = source.DisplayName;
            target.PrtPprUserDerivNoCmt = source.PrtPprUserDerivNoCmt;
            target.PrintPositionVer = source.PrintPositionVer;
            target.MergeablePrintPosVer = source.MergeablePrintPosVer;
            target.DataInputSystem = source.DataInputSystem;
            target.OptionCode = source.OptionCode;
            target.FreePrtPprItemGrpCd = source.FreePrtPprItemGrpCd;
            target.PrtPprBgImageRowPos = source.PrtPprBgImageRowPos;
            target.PrtPprBgImageColPos = source.PrtPprBgImageColPos;
            target.PrintPosClassData = source.PrintPosClassData;
            target.TakeInImageGroupCd = source.TakeInImageGroupCd;
            target.FreePrtPprSpPrpseCd = source.FreePrtPprSpPrpseCd;
            target.KeyNo = MakeKeyForHashtable(target.OutputFormFileName, target.UserPrtPprIdDerivNo);
            target.UpdateFlag = UPDATEFLG_NONE;
            target.ExistingDataFlag = 1;
        }
        # endregion

        # region Private Class
        /// <summary>
		/// �󎚈ʒu�_�E�����[�h��ʃA�N�Z�X��O�����N���X
		/// </summary>
		/// <remarks>
		/// <br>Note		: �󎚈ʒu�_�E�����[�h��ʃA�N�Z�X�N���X�̗�O�����N���X�ł��B</br>
		/// <br>Programmer	: 22011 �����@���l</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		private class DownLoadPrtPosException : ApplicationException
		{
			/// <summary>
			/// �󎚈ʒu�_�E�����[�h��ʃA�N�Z�X��O�����N���X�R���X�g���N�^
			/// </summary>
			/// <remarks>
			/// <br>Note		: �g�p���郁���o�̏��������s���܂��B</br>
			/// <br>Programmer	: 22011 �����@���l</br>
			/// <br>Date		: 2007.05.14</br>
			/// </remarks>
			public DownLoadPrtPosException(string message, int status): base(message)
			{
				_status = status;
			}

			/// <summary>�X�e�[�^�X</summary>
			private int _status;
		
			/// <summary>
			/// �X�e�[�^�X
			/// </summary>
			/// <returns>�X�e�[�^�X</returns>
			/// <remarks>
			/// <br>Note		: �X�e�[�^�X���擾���܂��B</br>
			/// <br>Programmer	: 22011 �����@���l</br>
			/// <br>Date		: 2007.05.14</br>
			/// </remarks>
			public int Status
			{
				get {return _status;}
			}
		}
		# endregion
	}
}