//**********************************************************************//
// System           :   PM.NS
// Sub System       :
// Program name     :   �����X�V���������[�e�B���O
//                  :   SFUKK01362R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programer        :   ���i�@��
// Date             :   2005.08.11
//----------------------------------------------------------------------//
// Update Note      :
// 2006.02.20 toku  : ����p�ʓ����Ή�
// 2006.10.18 toku	: �g�����U�N�V�����������x����ύX
// =====================================================================
// 2007.01.23 �ؑ�  : MA.NS�p�ɕύX
// 2007.03.27 �ؑ�  : ���Ӑ搿��(���|)���z�}�X�^�̍X�V�͏���������
//                    �s���悤�ɕύX���ꂽ�ׁA�X�V�������폜
// 2007.05.14 �ؑ�  : �T�[�r�X�`�[�敪������}�X�^�E���������}�X�^�ɒǉ�
//----------------------------------------------------------------------//
// 2007.10.12 �R�c  : DC.NS�p�ɕύX
// 2007.12.10 �R�c  : EdiTakeInDate(EDI�捞��)��Int32��DateTime�ɕύX
// 2008.01.11 �R�c  : �_���폜�@�\��ǉ�(LogicalDelete)
// 2008.03.17 �R�c  : ���������V�X�e�����t�œo�^����
//----------------------------------------------------------------------//
// 2008.04.25 21112 : PM.NS�p�ɕύX
//----------------------------------------------------------------------//
// 2009.05.01 22008 : �_���폜�f�[�^�Ή�
//----------------------------------------------------------------------//
// 2010/08/18 22018 ��ؐ��b : �������b�N�Ή�
//----------------------------------------------------------------------//
// 2010/12/20 �����: PM.NS��Q���ǑΉ�(12����)	
//                    �@�`�[�폜���ɓ���̏����Ŕ�������G���[���C������B
//                    �A�ԓ`�̓������׃f�[�^���쐬����B
//----------------------------------------------------------------------//
// 2011/02/24 22008 �������n : �����g���R��̏C���i2010/09/28 20056 : �_���폜�f�[�^�Ή��j
//----------------------------------------------------------------------//
// 2011/07/28 qijh: ���M�ς݂̃`�F�b�N���@��ǉ�
//----------------------------------------------------------------------//
// 2011/11/10 ����  Redmine#26228�@���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------//
// 2011/12/15 tianjw  Redmine#27390 ���_�Ǘ�/������̃`�F�b�N
//----------------------------------------------------------------------//
// Update Note      : 2012/02/06 �c����
// �Ǘ��ԍ�         : 10707327-00 2012/03/28�z�M��
//                    Redmine#28288 ���M�σf�[�^�C������̑Ή�
//----------------------------------------------------------------------//
// Update Note      : 2012/08/10 �e�c ���V 
//                    ���_�Ǘ� ���M�σf�[�^�`�F�b�N�s��Ή�
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/10/17  �C�����e : Redmine#32870�A2012/11/14�z�M�� PM.NS��Q�ꗗNo.1516 �����`�[����/���|�c�����قȂ�̑Ή��B
//                                : �����`�[�ۑ�����֘A�̓��Ӑ�i�ϓ����j�̌��ݔ��|�c���̒l�̑Ή��B
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/10/29  �C�����e : Redmine#32870�A2012/11/14�z�M�� PM.NS��Q�ꗗNo.1516 �����`�[����/���|�c�����قȂ�̍đΉ��B
//                                : �����`�[�ۑ�����֘A�̓��Ӑ�i�ϓ����j�̌��ݔ��|�c���̒l�̍đΉ��B
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/11/06  �C�����e : Redmine#32870�A2012/11/14�z�M�� PM.NS��Q�ꗗNo.1516 �����`�[����/���|�c�����قȂ�̍đΉ��B
//                                : �����`�[�ۑ�����֘A�̓��Ӑ�i�ϓ����j�̌��ݔ��|�c���̒l�̍đΉ��B
//                                : �������v�̓}�C�i�X�l��ݒ肷��΁A���ݔ��|�c���̍X�V�̑Ή��B
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : zhuhh
// �C �� ��  2013/01/10  �C�����e : 2013/03/13�z�M�� Redmine #34123
//                                  ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11600006-00 �쐬�S�� : �c����
// �C �� ��  2020/08/28  �C�����e : PMKOBETSU-4076 �^�C���A�E�g�ݒ�
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co,. Ltd
//**********************************************************************//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
//using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Diagnostics;  //ADD 2008/04/25 M.Kubota
using Broadleaf.Application.Common;  // ADD 2011/07/28 qijh SCM�Ή� - ���_�Ǘ�(10704767-00)
// --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
using Microsoft.Win32;
using System.Xml;
using System.IO;
// --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �����X�VDB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : �����f�[�^�̍X�V������s���N���X�ł��B</br>
	/// <br>Programmer : 95089 ���i�@��</br>
	/// <br>Date       : 2005.08.02</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// <br>		   : 2006.02.20 toku ����p�ʓ����Ή�</br>
    /// <br>Update Note : 2010.05.06 gejun</br>
    /// <br>              M1007A-�x����`�f�[�^�X�V�ǉ�</br>
    /// <br>Update Note : 2010/08/18 22018 ��� ���b</br>
    /// <br>              �������b�N�Ή�</br>
    /// <br>Update Note : 2010/12/20 ����� PM.NS��Q���ǑΉ�(12����)</br>
    /// <br>              �@�`�[�폜���ɓ���̏����Ŕ�������G���[���C������B</br>
    /// <br>              �A�ԓ`�̓������׃f�[�^���쐬����B</br>>
    /// <br>Update Note : 2011/12/15 tianjw</br>
    /// <br>              Redmine#27390 ���_�Ǘ�/������̃`�F�b�N</br>
    /// <br>Update Note : 2012/02/06 �c����</br>
    /// <br>�Ǘ��ԍ�    : 10707327-00 2012/03/28�z�M��</br>
    /// <br>              Redmine#28288 ���M�σf�[�^�C������̑Ή�</br>
    /// <br>Update Note : 2012/08/10  �e�c ���V</br>
    /// <br>            : ���_�Ǘ� ���M�σf�[�^�`�F�b�N�s��Ή�</br>
    /// <br>Update Note : 2012/10/17 wangf</br>
    /// <br>            : 10801804-00�ARedmine#32870�A2012/11/14�z�M�� PM.NS��Q�ꗗNo.1516 �����`�[����/���|�c�����قȂ�̑Ή��B</br>
    /// <br>            : �����`�[�ۑ�����֘A�̓��Ӑ�i�ϓ����j�̌��ݔ��|�c���̒l�̑Ή��B</br>
    /// <br>Update Note : 2012/10/29 wangf</br>
    /// <br>            : 10801804-00�ARedmine#32870�A2012/11/14�z�M�� PM.NS��Q�ꗗNo.1516 �����`�[����/���|�c�����قȂ�̍đΉ��B</br>
    /// <br>            : �����`�[�ۑ�����֘A�̓��Ӑ�i�ϓ����j�̌��ݔ��|�c���̒l�̍đΉ��B</br>
    /// <br>Update Note : 2012/11/06 wangf</br>
    /// <br>            : 10801804-00�ARedmine#32870�A2012/11/14�z�M�� PM.NS��Q�ꗗNo.1516 �����`�[����/���|�c�����قȂ�̍đΉ��B</br>
    /// <br>            : �����`�[�ۑ�����֘A�̓��Ӑ�i�ϓ����j�̌��ݔ��|�c���̒l�̍đΉ��B</br>
    /// <br>            : �������v�̓}�C�i�X�l��ݒ肷��΁A���ݔ��|�c���̍X�V�̑Ή��B</br>
    /// <br>UpdateNote  : 2013/01/10 zhuhh</br>
    /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
    /// <br>            : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
    /// <br>Update Note : 2020/08/28 �c����</br>
    /// <br>�Ǘ��ԍ�    : 11600006-00</br>
    /// <br>             PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br>
    /// </remarks>
	[Serializable]
	//public class DepsitMainDB : RemoteDB, IDepsitMainDB           //DEL 2008/04/25 M.Kubota
    public class DepsitMainDB : RemoteWithAppLockDB, IDepsitMainDB  //ADD 2008/04/25 M.Kubota
	{
//		private string _connectionText;		//�R�l�N�V����������i�[�p

        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>> 
        // �`�[�X�V�^�C���A�E�g���Ԑݒ�t�@�C��
        private const string XML_FILE_NAME = "DbCommandTimeoutSet.xml";
        // XML�t�@�C�����������̃f�t�H���g�l
        private const int DB_COMMAND_TIMEOUT = 120;
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<

		/// <summary>
		/// �����X�VDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.02</br>
		/// </remarks>
		public DepsitMainDB() :
			base( "SFUKK01343D", "Broadleaf.Application.Remoting.ParamData.DepsitMainWork", "DEPSITMAINRF")
		{
			Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
			Debug.WriteLine("DepsitMainDB�R���X�g���N�^");
//			_connectionText = SqlConnectionInfo.GetConnectionInfo(ConctInfoDivision.DB_USER);
        }

        private CustomerChangeDB _customerChangeDB = null;

        /// <summary>
        /// ���Ӑ�}�X�^(�ϓ����)�����[�g �v���p�e�B
        /// </summary>
        private CustomerChangeDB CustomerChangeDb
        {
            get
            {
                if (this._customerChangeDB == null)
                {
                    this._customerChangeDB = new CustomerChangeDB();
                }

                return this._customerChangeDB;
            }
        }

        // ADD 2011/07/28 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
        /// <summary>
        /// ���M�σ`�F�b�N���s�̃X�e�[�^�X
        /// </summary>
        public const int STATUS_CHK_SEND_ERR = -1001;

        private SecMngSndRcvDB _SecMngSndRcvDB = null;
        /// <summary>
        /// ���_�Ǘ�����M�Ώېݒ�}�X�^�����[�g�v���p�e�B
        /// </summary>
        private SecMngSndRcvDB ScMngSndRcvDB
        {
            get
            {
                if (this._SecMngSndRcvDB == null)
                    this._SecMngSndRcvDB = new SecMngSndRcvDB();
                return this._SecMngSndRcvDB;
            }
        }

        private SecMngSetDB _SecMngSetDB = null;
        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^�����[�g�v���p�e�B
        /// </summary>
        private SecMngSetDB ScMngSetDB
        {
            get
            {
                if (this._SecMngSetDB == null)
                    this._SecMngSetDB = new SecMngSetDB();
                return this._SecMngSetDB;
            }
        }
        // ADD 2011/07/28 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<
 
        # region [��������]

        /// <summary>
		/// �����X�V����
		/// </summary>
		/// <param name="depsitDataWorkByte">������񃏁[�N</param>
		/// <param name="depositAlwWorkListByte">����������񃏁[�N</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������E���������������Ƀf�[�^�X�V���s���܂�</br>
		/// <br>           : �����ԍ������̎��A�V�K�����쐬�Ƃ��܂�</br>
		/// <br>           : �_���폜�𗧂Ă��ꍇ�A�폜�������s���܂�</br>
		/// <br>           : ���������̍폜���s���ꍇ�͍폜�������������R�[�h�̂ݘ_���폜�𗧂Ă܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		public int Write(ref byte[] depsitDataWorkByte, ref byte[] depositAlwWorkListByte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// �`�[�X�V�r�����䕔�i

            try
            {
                //--- DEL 2008/04/25 M.Kubota --->>>
                //���[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;
                //--- DEL 2008/04/25 M.Kubota ---<<<

                // XML�̓ǂݍ���
                //DepsitMainWork depsitMainWork = (DepsitMainWork)XmlByteSerializer.Deserialize(depsitDataWorkByte,typeof(DepsitMainWork));  //DEL 2008/04/25 M.Kubota
                //--- ADD 2008/04/25 M.Kubota --->>>
                DepsitDataWork depsitDataWork = (DepsitDataWork)XmlByteSerializer.Deserialize(depsitDataWorkByte, typeof(DepsitDataWork));

                // �����f�[�^������}�X�^�f�[�^�Ɠ������׃f�[�^�ɕ���
                DepsitMainWork depsitMainWork = null;
                DepsitDtlWork[] depsitDtlWorkArray = null;
                DepsitDataUtil.Division(depsitDataWork, out depsitMainWork, out depsitDtlWorkArray);
                //--- ADD 2008/04/25 M.Kubota ---<<<
                
                DepositAlwWork[] depositAlwWorkArray = (DepositAlwWork[])XmlByteSerializer.Deserialize(depositAlwWorkListByte, typeof(DepositAlwWork[]));

                //SQL�ڑ�
                //--- DEL 2008/04/25 M.Kubota --->>>
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();
                //sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // �X�V�����b�N����
                //int[] CustomerCodeList = { depsitMainWork.CustomerCode };
                //status = controlExclusiveOrderAccess.LockDB(depsitMainWork.EnterpriseCode, CustomerCodeList, null);	// ���Ӑ�ʃ��b�N��������
                //--- DEL 2008/04/25 M.Kubota ---<<<

                //--- ADD 2008/04/25 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    return status;
                }

                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                if (sqlConnection != null && sqlTransaction != null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                //--- ADD 2008/04/25 M.Kubota ---<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // --- UPD m.suzuki 2010/08/18 ---------->>>>>
                    ////�V�X�e�����b�N(���_) //2009/1/27 Add sakurai
                    //int st = 0; // ���b�N�p�X�e�[�^�X
                    //ShareCheckInfo info = new ShareCheckInfo();
                    //info.Keys.Add(depsitDataWork.EnterpriseCode, ShareCheckType.Section, depsitDataWork.AddUpSecCode, "");
                    //st = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                    //if (st != 0) return st;

                    // �������b�N�i�`�[���j
                    int st = 0; // ���b�N�p�X�e�[�^�X
                    ShareCheckInfo info = new ShareCheckInfo();
                    int customerTotalDay = GetCustomerTotalDay( depsitDataWork.EnterpriseCode, depsitDataWork.CustomerCode, ref sqlConnection, ref sqlTransaction );
                    info.Keys.Add( new ShareCheckKey( depsitDataWork.EnterpriseCode, ShareCheckType.AddUpSlip, depsitDataWork.AddUpSecCode, "", customerTotalDay, ToLongDate( depsitDataWork.AddUpADate ) ) );
                    // ���b�N
                    st = this.ShareCheck( info, LockControl.Locke, sqlConnection, sqlTransaction );
                    if ( st != 0 ) return st;
                    // --- UPD m.suzuki 2010/08/18 ----------<<<<<

                    // �����}�X�^�X�V����
                    //status = WriteDepsitMainWork(ref depsitMainWork, ref depositAlwWorkArray, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota
                    status = Write(ref depsitMainWork, ref depsitDtlWorkArray, ref depositAlwWorkArray, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //�V�X�e�����b�N���� //2009/1/27 Add sakurai
                        st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                        if(st != 0) return st;
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        sqlTransaction.Commit();
                    else
                        sqlTransaction.Rollback();
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XML�֕ϊ����A������̃o�C�i����
                    //depsitDataWorkByte = XmlByteSerializer.Serialize(depsitMainWork);  //DEL 2008/04/25 M.Kubota
                    
                    //--- ADD 2008/04/25 M.Kubota --->>>
                    // �����}�X�^�f�[�^�Ɠ������׃f�[�^������f�[�^�ɍ���
                    DepsitDataUtil.Union(out depsitDataWork, depsitMainWork, depsitDtlWorkArray);
                    depsitDataWorkByte = XmlByteSerializer.Serialize(depsitDataWork);
                    //--- ADD 2008/04/25 M.Kuboat ---<<<
                    
                    depositAlwWorkListByte = XmlByteSerializer.Serialize(depositAlwWorkArray);
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/25 M.Kubota

                //--- ADD 2008/04/25 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/04/25 M.Kubota --->>>
            }
            //--- ADD 2008/04/25 M.Kubota --->>>
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            //--- ADD 2008/04/25 M.Kubota ---<<<
			finally
			{
				// �X�V�����b�N����
				//controlExclusiveOrderAccess.UnlockDB();  //DEL 2008/04/25 M.Kubota
			}

			if(sqlConnection != null)
			{
                sqlConnection.Close();
				sqlConnection.Dispose();
			}

			return status;
        }

        // --- ADD m.suzuki 2010/08/18 ---------->>>>>
        /// <summary>
        /// ���Ӑ�̒���(DD)���擾
        /// </summary>
        /// <param name="customerCode"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int GetCustomerTotalDay( string enterpriseCode, int customerCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int totalDay = 99;

            try
            {
                CustomerDB customerDB = new CustomerDB();
                if ( customerDB != null )
                {
                    int status = customerDB.GetCustomerTotalDay( enterpriseCode, customerCode, ref totalDay, ref sqlConnection, ref sqlTransaction );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    {
                        totalDay = 99;
                    }
                }
            }
            catch
            {
                totalDay = 99;
            }

            return totalDay;
        }
        /// <summary>
        /// ���t�ϊ�����
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private int ToLongDate( DateTime dateTime )
        {
            try
            {
                return (dateTime.Year * 10000 + dateTime.Month * 100 + dateTime.Day);
            }
            catch
            {
                return 0;
            }
        }
        // --- ADD m.suzuki 2010/08/18 ----------<<<<<

        // --------------- ADD START 2010.05.06 gejun FOR M1007A-M1007A-�x����`�f�[�^�X�V�ǉ�------->>>>
        /// <summary>
        /// �����A��`�X�V����
        /// </summary>
        /// <param name="depsitDataWorkByte">������񃏁[�N</param>
        /// <param name="depositAlwWorkListByte">����������񃏁[�N</param>
        /// <param name="rcvDraftDataUpdWorkByte">��`�f�[�^���[�N�i�X�V�p�j</param>
        /// <param name="rcvDraftDataDelWorkByte">��`�f�[�^���[�N�i�폜�p�j</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �������E�����������E��`�f�[�^���Ƀf�[�^�X�V���s���܂�</br>
        /// <br>           : �����ԍ������̎��A�V�K�����E��`�f�[�^�쐬�Ƃ��܂�</br>
        /// <br>           : �_���폜�𗧂Ă��ꍇ�A�폜�������s���܂�</br>
        /// <br>           : ���������̍폜���s���ꍇ�͍폜�������������R�[�h�̂ݘ_���폜�𗧂Ă܂�</br>
        /// <br>           : ��`�f�[�^�̍X�V�A�폜�������s��</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.05.06</br>
        /// </remarks>
        public int WriteWithDraftData(ref byte[] depsitDataWorkByte, ref byte[] depositAlwWorkListByte, byte[] rcvDraftDataUpdWorkByte, byte[] rcvDraftDataDelWorkByte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            bool commitFlg = true;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            // �`�[�X�V�r�����䕔�i
            ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();

            try
            {
                DepsitDataWork depsitDataWork = (DepsitDataWork)XmlByteSerializer.Deserialize(depsitDataWorkByte, typeof(DepsitDataWork));

                // �����f�[�^������}�X�^�f�[�^�Ɠ������׃f�[�^�ɕ���
                DepsitMainWork depsitMainWork = null;
                DepsitDtlWork[] depsitDtlWorkArray = null;
                DepsitDataUtil.Division(depsitDataWork, out depsitMainWork, out depsitDtlWorkArray);

                DepositAlwWork[] depositAlwWorkArray = (DepositAlwWork[])XmlByteSerializer.Deserialize(depositAlwWorkListByte, typeof(DepositAlwWork[]));


                RcvDraftDataWork rcvDraftDataUpdWork = new RcvDraftDataWork();
                if (rcvDraftDataUpdWorkByte != null)
                    rcvDraftDataUpdWork = XmlByteSerializer.Deserialize(rcvDraftDataUpdWorkByte, typeof(RcvDraftDataWork)) as RcvDraftDataWork;
                else
                    rcvDraftDataUpdWork = null;

                RcvDraftDataWork rcvDraftDataDelWork = new RcvDraftDataWork();
                if (rcvDraftDataDelWorkByte != null)
                    rcvDraftDataDelWork = XmlByteSerializer.Deserialize(rcvDraftDataDelWorkByte, typeof(RcvDraftDataWork)) as RcvDraftDataWork;
                else
                    rcvDraftDataDelWork = null;

                //SQL�ڑ�
                sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    return status;
                }

                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                if (sqlConnection != null && sqlTransaction != null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //�V�X�e�����b�N(���_)
                    int st = 0; // ���b�N�p�X�e�[�^�X
                    ShareCheckInfo info = new ShareCheckInfo();
                    info.Keys.Add(depsitDataWork.EnterpriseCode, ShareCheckType.Section, depsitDataWork.AddUpSecCode, "");

                    if (depsitMainWork != null && depsitMainWork.UpdateSecCd != "")
                    {
                        st = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                        if (st != 0) return st;

                        // �����}�X�^�X�V����
                        status = Write(ref depsitMainWork, ref depsitDtlWorkArray, ref depositAlwWorkArray, ref sqlConnection, ref sqlTransaction);
                        // ADD 2011/07/28 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
                        if (STATUS_CHK_SEND_ERR == status)
                        {
                            sqlTransaction.Rollback();
                            if (sqlConnection != null)
                            {
                                sqlConnection.Close();
                                sqlConnection.Dispose();
                            }
                            return status;
                        }
                        // ADD 2011/07/28 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            //�V�X�e�����b�N����
                            st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                            if (st != 0) return st;
                        }

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                           commitFlg = false;
                    }

                    if (rcvDraftDataUpdWork != null)
                    {
                        if (rcvDraftDataUpdWork.DepositRowNo != 0 && depsitMainWork != null && depsitMainWork.DepositSlipNo != 0)
                        {
                            // �x���`�[�ԍ�
                            rcvDraftDataUpdWork.DepositSlipNo = depsitMainWork.DepositSlipNo;
                            // �x���X�e�[�^�X
                            rcvDraftDataUpdWork.AcptAnOdrStatus = depsitMainWork.AcptAnOdrStatus;
                            // �x�����t
                            rcvDraftDataUpdWork.DepositDate = depsitMainWork.DepositDate;
                        }

                        st = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                        if (st != 0) return st;

                        // ��`�f�[�^�X�V����
                        status = WriteDraftProc(rcvDraftDataUpdWork, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            //�V�X�e�����b�N����
                            st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                            if (st != 0) return st;
                        }

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            commitFlg = false;
                    }

                    if (rcvDraftDataDelWork != null)
                    {
                        st = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                        if (st != 0) return st;

                        // ��`�f�[�^�폜����
                        status = DeleteDraftProc(rcvDraftDataDelWork, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            //�V�X�e�����b�N����
                            st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                            if (st != 0) return st;
                        }

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            commitFlg = false;
                    }


                    if (commitFlg)
                        sqlTransaction.Commit();
                    else
                        sqlTransaction.Rollback();
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �����}�X�^�f�[�^�Ɠ������׃f�[�^������f�[�^�ɍ���
                    DepsitDataUtil.Union(out depsitDataWork, depsitMainWork, depsitDtlWorkArray);
                    depsitDataWorkByte = XmlByteSerializer.Serialize(depsitDataWork);

                    depositAlwWorkListByte = XmlByteSerializer.Serialize(depositAlwWorkArray);
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
            }

            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            return status;
        }
        // --------------- ADD END 2010.05.06 gejun FOR M1007A-M1007A-�x����`�f�[�^�X�V�ǉ�------->>>>

        /// <summary>
        /// �����ꊇ�쐬�����i�󒍎w��^�j
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="createDepsitMainWorkListByte">�����X�V�f�[�^�p�����[�^(�󒍎w��^)</param>
        /// <param name="depositSlipNoList">�X�V���������f�[�^�̓����ԍ��z��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ꊇ�쐬�p�p�����[�^����w��󒍂ւ̈����X�V�E�����V�K�쐬�������s���܂�</br>
        /// <br>           : �󒍎w��^��p�ł���A�V�K�����E�����̂ݍs���܂�</br>
        /// <br>Programmer : 95089 ���i�@��</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        public int Write(string EnterpriseCode, byte[] createDepsitMainWorkListByte, out int[] depositSlipNoList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            depositSlipNoList = null;

            //ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// �`�[�X�V�r�����䕔�i  //DEL 2008/04/25 M.Kubota

            try
            {
                //���[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                //--- DEL 2008/04/25 M.Kubota --->>>
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;
                //--- DEL 2008/04/25 M.Kubota ---<<<

                // XML�̓ǂݍ���
                CreateDepsitMainWork[] createDepsitMainWorkList = (CreateDepsitMainWork[])XmlByteSerializer.Deserialize(createDepsitMainWorkListByte, typeof(CreateDepsitMainWork[]));

                //SQL�ڑ�
                //--- DEL 2008/04/25 M.Kubota --->>>
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();
                //sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                //--- DEL 2008/04/25 M.Kubota ---<<<

                //--- ADD 2008/04/25 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    return status;
                }

                sqlTransaction = this.CreateTransaction(ref sqlConnection);
                //--- ADD 2008/04/25 M.Kubota ---<<<

                //�V�X�e�����b�N(���_) //2009/1/27 Add sakurai
                ShareCheckInfo info = new ShareCheckInfo();
                info.Keys.Add(EnterpriseCode, ShareCheckType.Section, createDepsitMainWorkList[0].AddUpSecCode, "");
                status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                if (status == 0) return status;
                 // �X�V���������ԍ��i�[���X�g�̍쐬
                ArrayList depositSlipNoListAr = new ArrayList();

                for (int ix = 0; ix < createDepsitMainWorkList.Length; ix++)
                {
                    CreateDepsitMainWork createDepsitMainWork = createDepsitMainWorkList[ix];

                    // �� 20070123 18322 c MA.NS�p�ɕύX
                    #region SF �����}�X�^�E���������}�X�^�����i�S�ăR�����g�A�E�g�j
                    //// �������̐���
                    //DepsitMainWork depsitMainWork = new DepsitMainWork();
                    //
                    //depsitMainWork.EnterpriseCode = EnterpriseCode;
                    //depsitMainWork.DepositDebitNoteCd = 0;
                    //depsitMainWork.DepositKindCode = createDepsitMainWork.DepositKindCode;
                    //depsitMainWork.CustomerCode = createDepsitMainWork.CustomerCode;
                    //depsitMainWork.DepositCd = createDepsitMainWork.DepositCd;
                    //depsitMainWork.DepositTotal = createDepsitMainWork.Deposit + createDepsitMainWork.FeeDeposit + createDepsitMainWork.DiscountDeposit;
                    //depsitMainWork.Outline = createDepsitMainWork.Outline;
                    //depsitMainWork.InputDepositSecCd = createDepsitMainWork.InputDepositSecCd;
                    //depsitMainWork.DepositDate = createDepsitMainWork.DepositDate;
                    //depsitMainWork.AddUpSecCode = createDepsitMainWork.AddUpSecCode;
                    //depsitMainWork.AddUpADate = createDepsitMainWork.AddUpADate;
                    //depsitMainWork.UpdateSecCd = createDepsitMainWork.UpdateSecCd;
                    //depsitMainWork.DepositKindName = createDepsitMainWork.DepositKindName;
                    //depsitMainWork.DepositAllowance = createDepsitMainWork.Deposit + createDepsitMainWork.FeeDeposit + createDepsitMainWork.DiscountDeposit;
                    //depsitMainWork.DepositAlwcBlnce = 0;
                    //depsitMainWork.DepositAgentCode = createDepsitMainWork.DepositAgentCode;
                    //depsitMainWork.DepositKindDivCd = createDepsitMainWork.DepositKindDivCd;
                    //depsitMainWork.FeeDeposit = createDepsitMainWork.FeeDeposit;
                    //depsitMainWork.DiscountDeposit = createDepsitMainWork.DiscountDeposit;
                    //depsitMainWork.CreditOrLoanCd = createDepsitMainWork.CreditOrLoanCd;
                    //depsitMainWork.CreditCompanyCode = createDepsitMainWork.CreditCompanyCode;
                    //depsitMainWork.Deposit = createDepsitMainWork.Deposit;
                    //depsitMainWork.DraftDrawingDate = createDepsitMainWork.DraftDrawingDate;
                    //depsitMainWork.DraftPayTimeLimit = createDepsitMainWork.DraftPayTimeLimit;
                    //depsitMainWork.LastReconcileAddUpDt = createDepsitMainWork.AddUpADate;			// �������ݓ��������v���
                    //
                    //// 20060220 Ins Start >> ����p�ʓ����Ή� >>>>>>>>>>>>>
                    //depsitMainWork.AcpOdrDeposit = createDepsitMainWork.AcpOdrDeposit;				// �󒍓������z
                    //depsitMainWork.AcpOdrChargeDeposit = createDepsitMainWork.AcpOdrChargeDeposit;	// �󒍎萔�������z
                    //depsitMainWork.AcpOdrDisDeposit = createDepsitMainWork.AcpOdrDisDeposit;		// �󒍒l�������z
                    //depsitMainWork.VariousCostDeposit = createDepsitMainWork.VariousCostDeposit;	// ����p�������z
                    //depsitMainWork.VarCostChargeDeposit = createDepsitMainWork.VarCostChargeDeposit;// ����p�萔�������z
                    //depsitMainWork.VarCostDisDeposit = createDepsitMainWork.VarCostDisDeposit;		// ����p�l�������z
                    //depsitMainWork.AcpOdrDepositAlwc = createDepsitMainWork.AcpOdrDeposit + createDepsitMainWork.AcpOdrChargeDeposit + createDepsitMainWork.AcpOdrDisDeposit;// �󒍓��������z
                    //depsitMainWork.AcpOdrDepoAlwcBlnce = 0;											// �󒍓��������c��
                    //depsitMainWork.VarCostDepoAlwc = createDepsitMainWork.VariousCostDeposit + createDepsitMainWork.VarCostChargeDeposit + createDepsitMainWork.VarCostDisDeposit;	// ����p���������z
                    //depsitMainWork.VarCostDepoAlwcBlnce = 0;										// ����p���������c��
                    //// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    //
                    //// �����������̐���
                    //DepositAlwWork depositAlwWork = new DepositAlwWork();
                    //
                    //depositAlwWork.EnterpriseCode = EnterpriseCode;
                    //depositAlwWork.CustomerCode = createDepsitMainWork.CustomerCode;
                    //depositAlwWork.AddUpSecCode = createDepsitMainWork.AddUpSecCode;
                    //depositAlwWork.AcceptAnOrderNo = createDepsitMainWork.AcceptAnOrderNo;
                    //depositAlwWork.DepositKindCode = createDepsitMainWork.DepositKindCode;
                    //depositAlwWork.DepositInputDate = createDepsitMainWork.DepositDate;				// �������͓���������
                    //depositAlwWork.DepositAllowance = createDepsitMainWork.Deposit + createDepsitMainWork.FeeDeposit + createDepsitMainWork.DiscountDeposit;
                    //depositAlwWork.ReconcileDate = DateTime.Now;									// �������ݓ����V�X�e�����t
                    //depositAlwWork.ReconcileAddUpDate = createDepsitMainWork.AddUpADate;			// �������ݓ��v����������v���
                    //depositAlwWork.DebitNoteOffSetCd = 0;
                    //depositAlwWork.DepositCd = createDepsitMainWork.DepositCd;
                    //depositAlwWork.CreditOrLoanCd = createDepsitMainWork.CreditOrLoanCd;
                    //// 20060220 Ins Start >> ����p�ʓ����Ή� >>>>>>>>>>>>>
                    //depositAlwWork.AcpOdrDepositAlwc = createDepsitMainWork.AcpOdrDeposit + createDepsitMainWork.AcpOdrChargeDeposit + createDepsitMainWork.AcpOdrDisDeposit;		// �󒍓��������z
                    //depositAlwWork.VarCostDepoAlwc = createDepsitMainWork.VariousCostDeposit + createDepsitMainWork.VarCostChargeDeposit + createDepsitMainWork.VarCostDisDeposit;	// ����p���������z
                    //// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    #endregion

                    # region [�����}�X�^]
                    // �������̐���
                    DepsitMainWork depsitMainWork = new DepsitMainWork();
                    # region --- DEL 2008/04/25 M.Kubota ---
# if false
                    // ��ƃR�[�h
                    depsitMainWork.EnterpriseCode = EnterpriseCode;
                    // �����ԍ��敪(0:���`�Œ�)
                    depsitMainWork.DepositDebitNoteCd = 0;
                    // �����`�[�ԍ�
                    depsitMainWork.DepositSlipNo = 0;
                    // �� 2007.10.12 980081 d
                    //// �󒍔ԍ�
                    //depsitMainWork.AcceptAnOrderNo = createDepsitMainWork.AcceptAnOrderNo;
                    //// �T�[�r�X�`�[�敪
                    //depsitMainWork.ServiceSlipCd = createDepsitMainWork.ServiceSlipCd;
                    // �� 2007.10.12 980081 d
                    // �������͋��_�R�[�h
                    depsitMainWork.InputDepositSecCd = createDepsitMainWork.InputDepositSecCd;
                    // �v�㋒�_�R�[�h
                    depsitMainWork.AddUpSecCode = createDepsitMainWork.AddUpSecCode;
                    // �X�V���_�R�[�h
                    depsitMainWork.UpdateSecCd = createDepsitMainWork.UpdateSecCd;
                    // �������t
                    // �� 2008.03.17 980081 c
                    //depsitMainWork.DepositDate = createDepsitMainWork.DepositDate;
                    depsitMainWork.DepositDate = DateTime.Now;
                    // �� 2008.03.17 980081 c
                    // �v����t
                    depsitMainWork.AddUpADate = createDepsitMainWork.AddUpADate;
                    // ��������R�[�h
                    depsitMainWork.DepositKindCode = createDepsitMainWork.DepositKindCode;
                    // �������햼��
                    depsitMainWork.DepositKindName = createDepsitMainWork.DepositKindName;
                    // ��������敪
                    depsitMainWork.DepositKindDivCd = createDepsitMainWork.DepositKindDivCd;
                    // �����v
                    depsitMainWork.DepositTotal = createDepsitMainWork.DepositTotal;
                    // �������z
                    depsitMainWork.Deposit = createDepsitMainWork.Deposit;
                    // �萔�������z
                    depsitMainWork.FeeDeposit = createDepsitMainWork.FeeDeposit;
                    // �l�������z
                    depsitMainWork.DiscountDeposit = createDepsitMainWork.DiscountDeposit;
                    // �� 2007.10.12 980081 d
                    //// ���x�[�g�����z
                    //depsitMainWork.RebateDeposit   = createDepsitMainWork.RebateDeposit;
                    // �� 2007.10.12 980081 d
                    // ���������敪
                    depsitMainWork.AutoDepositCd = createDepsitMainWork.AutoDepositCd;
                    // �a����敪
                    depsitMainWork.DepositCd = createDepsitMainWork.DepositCd;
                    // �� 2007.10.12 980081 d
                    //// �N���W�b�g�^���[���敪
                    //depsitMainWork.CreditOrLoanCd = createDepsitMainWork.CreditOrLoanCd;
                    //// �N���W�b�g��ЃR�[�h
                    //depsitMainWork.CreditCompanyCode = createDepsitMainWork.CreditCompanyCode;
                    // �� 2007.10.12 980081 d
                    // ��`�U�o��
                    depsitMainWork.DraftDrawingDate = createDepsitMainWork.DraftDrawingDate;
                    // ��`�x������
                    depsitMainWork.DraftPayTimeLimit = createDepsitMainWork.DraftPayTimeLimit;
                    // ���������z
                    depsitMainWork.DepositAllowance = createDepsitMainWork.DepositTotal;
                    // ���������c��
                    depsitMainWork.DepositAlwcBlnce = 0;
                    // �ԍ������A���ԍ�
                    depsitMainWork.DebitNoteLinkDepoNo = 0;
                    // �ŏI�������݌v����i�������ݓ��������v����j
                    depsitMainWork.LastReconcileAddUpDt = createDepsitMainWork.AddUpADate;
                    // �����S���҃R�[�h
                    depsitMainWork.DepositAgentCode = createDepsitMainWork.DepositAgentCode;
                    // �����S���Җ���
                    depsitMainWork.DepositAgentNm = createDepsitMainWork.DepositAgentNm;
                    // ���Ӑ�R�[�h
                    depsitMainWork.CustomerCode = createDepsitMainWork.CustomerCode;
                    // ���Ӑ於��
                    depsitMainWork.CustomerName = createDepsitMainWork.CustomerName;
                    // ���Ӑ於��2
                    depsitMainWork.CustomerName2 = createDepsitMainWork.CustomerName2;
                    // �`�[�E�v
                    depsitMainWork.Outline = createDepsitMainWork.Outline;
                    // �� 2007.10.12 980081 a
                    depsitMainWork.AcptAnOdrStatus = createDepsitMainWork.AcptAnOdrStatus;
                    depsitMainWork.SalesSlipNum = createDepsitMainWork.SalesSlipNum;
                    depsitMainWork.SubSectionCode = createDepsitMainWork.SubSectionCode;
                    depsitMainWork.MinSectionCode = createDepsitMainWork.MinSectionCode;
                    depsitMainWork.DraftKind = createDepsitMainWork.DraftKind;
                    depsitMainWork.DraftKindName = createDepsitMainWork.DraftKindName;
                    depsitMainWork.DraftDivide = createDepsitMainWork.DraftDivide;
                    depsitMainWork.DraftDivideName = createDepsitMainWork.DraftDivideName;
                    depsitMainWork.DraftNo = createDepsitMainWork.DraftNo;
                    depsitMainWork.DepositInputAgentCd = createDepsitMainWork.DepositInputAgentCd;
                    depsitMainWork.DepositInputAgentNm = createDepsitMainWork.DepositInputAgentNm;
                    depsitMainWork.CustomerSnm = createDepsitMainWork.CustomerSnm;
                    depsitMainWork.ClaimCode = createDepsitMainWork.ClaimCode;
                    depsitMainWork.ClaimName = createDepsitMainWork.ClaimName;
                    depsitMainWork.ClaimName2 = createDepsitMainWork.ClaimName2;
                    depsitMainWork.ClaimSnm = createDepsitMainWork.ClaimSnm;
                    depsitMainWork.BankCode = createDepsitMainWork.BankCode;
                    depsitMainWork.BankName = createDepsitMainWork.BankName;
                    depsitMainWork.EdiSendDate = createDepsitMainWork.EdiSendDate;
                    depsitMainWork.EdiTakeInDate = createDepsitMainWork.EdiTakeInDate;
                    // �� 2007.10.12 980081 a
# endif
                    # endregion

                    //--- ADD 2008/04/25 M.Kubota --->>>
                    depsitMainWork.EnterpriseCode = EnterpriseCode;                                 // ��ƃR�[�h
                    depsitMainWork.LogicalDeleteCode = 0;                                           // �_���폜�敪
                    depsitMainWork.AcptAnOdrStatus = createDepsitMainWork.AcptAnOdrStatus;          // �󒍃X�e�[�^�X
                    depsitMainWork.DepositDebitNoteCd = 0;                                          // �����ԍ��敪
                    depsitMainWork.InputDepositSecCd = createDepsitMainWork.InputDepositSecCd;      // �������͋��_�R�[�h
                    depsitMainWork.AddUpSecCode = createDepsitMainWork.AddUpSecCode;                // �v�㋒�_�R�[�h
                    depsitMainWork.UpdateSecCd = createDepsitMainWork.UpdateSecCd;                  // �X�V���_�R�[�h
                    depsitMainWork.SubSectionCode = createDepsitMainWork.SubSectionCode;            // ����R�[�h
                    depsitMainWork.InputDay = createDepsitMainWork.InputDay;                        // ���͓��t  //ADD 2009/03/25
                    depsitMainWork.DepositDate = createDepsitMainWork.DepositDate;                  // �������t
                    depsitMainWork.AddUpADate = createDepsitMainWork.AddUpADate;                    // �v����t
                    depsitMainWork.DepositTotal = createDepsitMainWork.DepositTotal;                // �����v
                    depsitMainWork.Deposit = createDepsitMainWork.Deposit;                          // �������z
                    depsitMainWork.FeeDeposit = createDepsitMainWork.FeeDeposit;                    // �萔�������z
                    depsitMainWork.DiscountDeposit = createDepsitMainWork.DiscountDeposit;          // �l�������z
                    depsitMainWork.AutoDepositCd = createDepsitMainWork.AutoDepositCd;              // ���������敪
                    depsitMainWork.DraftDrawingDate = createDepsitMainWork.DraftDrawingDate;        // ��`�U�o��
                    depsitMainWork.DraftKind = createDepsitMainWork.DraftKind;                      // ��`���
                    depsitMainWork.DraftKindName = createDepsitMainWork.DraftKindName;              // ��`��ޖ���
                    depsitMainWork.DraftDivide = createDepsitMainWork.DraftDivide;                  // ��`�敪
                    depsitMainWork.DraftDivideName = createDepsitMainWork.DraftDivideName;          // ��`�敪����
                    depsitMainWork.DraftNo = createDepsitMainWork.DraftNo;                          // ��`�ԍ�
                    depsitMainWork.DepositAllowance = createDepsitMainWork.DepositTotal;            // ���������z
                    depsitMainWork.DepositAlwcBlnce = 0;                                            // ���������c��
                    depsitMainWork.DebitNoteLinkDepoNo = 0;                                         // �ԍ������A���ԍ�
                    depsitMainWork.LastReconcileAddUpDt = createDepsitMainWork.AddUpADate;          // �ŏI�������݌v���
                    depsitMainWork.DepositAgentCode = createDepsitMainWork.DepositAgentCode;        // �����S���҃R�[�h
                    depsitMainWork.DepositAgentNm = createDepsitMainWork.DepositAgentNm;            // �����S���Җ���
                    depsitMainWork.DepositInputAgentCd = createDepsitMainWork.DepositInputAgentCd;  // �������͎҃R�[�h
                    depsitMainWork.DepositInputAgentNm = createDepsitMainWork.DepositInputAgentNm;  // �������͎Җ���
                    depsitMainWork.CustomerCode = createDepsitMainWork.CustomerCode;                // ���Ӑ�R�[�h
                    depsitMainWork.CustomerName = createDepsitMainWork.CustomerName;                // ���Ӑ於��
                    depsitMainWork.CustomerName2 = createDepsitMainWork.CustomerName2;              // ���Ӑ於��2
                    depsitMainWork.CustomerSnm = createDepsitMainWork.CustomerSnm;                  // ���Ӑ旪��
                    depsitMainWork.ClaimCode = createDepsitMainWork.ClaimCode;                      // ������R�[�h
                    depsitMainWork.ClaimName = createDepsitMainWork.ClaimName;                      // �����於��
                    depsitMainWork.ClaimName2 = createDepsitMainWork.ClaimName2;                    // �����於��2
                    depsitMainWork.ClaimSnm = createDepsitMainWork.ClaimSnm;                        // �����旪��
                    depsitMainWork.Outline = createDepsitMainWork.Outline;                          // �`�[�E�v
                    depsitMainWork.BankCode = createDepsitMainWork.BankCode;                        // ��s�R�[�h
                    depsitMainWork.BankName = createDepsitMainWork.BankName;                        // ��s����
                    //--- ADD 2008/04/25 M.Kubota ---<<<
                    # endregion

                    # region [�������׃f�[�^]
                    //--- ADD 2008/04/25 M.Kubota --->>>
                    DepsitDtlWork[] depsitDtlWorkArray = new DepsitDtlWork[1];
                    depsitDtlWorkArray[0] = new DepsitDtlWork();
                    depsitDtlWorkArray[0].EnterpriseCode = EnterpriseCode;                         // ��ƃR�[�h
                    depsitDtlWorkArray[0].LogicalDeleteCode = 0;                                   // �_���폜�敪
                    depsitDtlWorkArray[0].AcptAnOdrStatus = createDepsitMainWork.AcptAnOdrStatus;  // �󒍃X�e�[�^�X
                    depsitDtlWorkArray[0].DepositRowNo = createDepsitMainWork.DepositRowNo;        // �����s�ԍ�
                    depsitDtlWorkArray[0].MoneyKindCode = createDepsitMainWork.MoneyKindCode;      // ����R�[�h
                    depsitDtlWorkArray[0].MoneyKindName = createDepsitMainWork.MoneyKindName;      // ���햼��
                    depsitDtlWorkArray[0].MoneyKindDiv = createDepsitMainWork.MoneyKindDiv;        // ����敪
                    depsitDtlWorkArray[0].Deposit = createDepsitMainWork.Deposit;                  // �������z
                    depsitDtlWorkArray[0].ValidityTerm = createDepsitMainWork.ValidityTerm;        // �L������
                    //--- ADD 2008/04/25 M.Kubota ---<<<
                    # endregion

                    # region [���������}�X�^]
                    // �����������̐���
                    DepositAlwWork depositAlwWork = new DepositAlwWork();
                    # region --- DEL 2008/04/25 M.Kubota ---
# if false
                    // ��ƃR�[�h
                    depositAlwWork.EnterpriseCode = EnterpriseCode;
                    // �������͋��_�R�[�h
                    depositAlwWork.InputDepositSecCd = createDepsitMainWork.InputDepositSecCd;
                    // �v�㋒�_�R�[�h
                    depositAlwWork.AddUpSecCode = createDepsitMainWork.AddUpSecCode;
                    // �����ݓ��i�������ݓ����V�X�e�����t�j
                    depositAlwWork.ReconcileDate = DateTime.Now;
                    // �����݌v����i�������ݓ��v����������v����j
                    depositAlwWork.ReconcileAddUpDate = createDepsitMainWork.AddUpADate;
                    // �����`�[�ԍ�

                    // ��������R�[�h
                    depositAlwWork.DepositKindCode = createDepsitMainWork.DepositKindCode;
                    // �������햼��
                    depositAlwWork.DepositKindName = createDepsitMainWork.DepositKindName;
                    // ���������z
                    depositAlwWork.DepositAllowance = createDepsitMainWork.DepositTotal;
                    // �����S���҃R�[�h
                    depositAlwWork.DepositAgentCode = createDepsitMainWork.DepositAgentCode;
                    // �����S���Җ���
                    depositAlwWork.DepositAgentNm = createDepsitMainWork.DepositAgentNm;
                    // ���Ӑ�R�[�h
                    depositAlwWork.CustomerCode = createDepsitMainWork.CustomerCode;
                    // ���Ӑ於��
                    depositAlwWork.CustomerName = createDepsitMainWork.CustomerName;
                    // ���Ӑ於��2
                    depositAlwWork.CustomerName2 = createDepsitMainWork.CustomerName2;
                    // �� 2007.10.12 980081 d
                    //// �󒍔ԍ�
                    //depositAlwWork.AcceptAnOrderNo    = createDepsitMainWork.AcceptAnOrderNo;
                    //// �T�[�r�X�`�[�敪
                    //depositAlwWork.ServiceSlipCd      = createDepsitMainWork.ServiceSlipCd;
                    // �� 2007.10.12 980081 d
                    // �ԓ`���E�敪("0:���`"�Œ�)
                    depositAlwWork.DebitNoteOffSetCd = 0;
                    // �a����敪
                    depositAlwWork.DepositCd = createDepsitMainWork.DepositCd;
                    // �� 2007.10.12 980081 d
                    //// �N���W�b�g�^���[���敪
                    //depositAlwWork.CreditOrLoanCd     = createDepsitMainWork.CreditOrLoanCd;
                    // �� 2007.10.12 980081 d
                    // �� 2007.10.12 980081
                    depositAlwWork.AcptAnOdrStatus = createDepsitMainWork.AcptAnOdrStatus;
                    depositAlwWork.SalesSlipNum = createDepsitMainWork.SalesSlipNum;
                    // �� 2007.10.12 980081
# endif
                    # endregion

                    //--- ADD 2008/04/25 M.Kubota --->>>
                    depositAlwWork.EnterpriseCode = EnterpriseCode;                             // ��ƃR�[�h
                    depositAlwWork.LogicalDeleteCode = 0;                                       // �_���폜�敪
                    depositAlwWork.InputDepositSecCd = createDepsitMainWork.InputDepositSecCd;  // �������͋��_�R�[�h
                    depositAlwWork.AddUpSecCode = createDepsitMainWork.AddUpSecCode;            // �v�㋒�_�R�[�h
                    depositAlwWork.AcptAnOdrStatus = createDepsitMainWork.AcptAnOdrStatus;      // �󒍃X�e�[�^�X
                    depositAlwWork.SalesSlipNum = createDepsitMainWork.SalesSlipNum;            // ����`�[�ԍ�
                    depositAlwWork.ReconcileDate = DateTime.Now;                                // �����ݓ�
                    depositAlwWork.ReconcileAddUpDate = createDepsitMainWork.AddUpADate;        // �����݌v���
                    depositAlwWork.DepositAllowance = createDepsitMainWork.DepositTotal;        // ���������z
                    depositAlwWork.DepositAgentCode = createDepsitMainWork.DepositAgentCode;    // �����S���҃R�[�h
                    depositAlwWork.DepositAgentNm = createDepsitMainWork.DepositAgentNm;        // �����S���Җ���
                    //depositAlwWork.CustomerCode = createDepsitMainWork.CustomerCode;          // ���Ӑ�R�[�h
                    //depositAlwWork.CustomerName = createDepsitMainWork.CustomerName;          // ���Ӑ於��
                    //depositAlwWork.CustomerName2 = createDepsitMainWork.CustomerName2;        // ���Ӑ於��2
                    depositAlwWork.CustomerCode = createDepsitMainWork.ClaimCode;               // ���Ӑ�R�[�h(������)
                    depositAlwWork.CustomerName = createDepsitMainWork.ClaimName;               // ���Ӑ於��(������)
                    depositAlwWork.CustomerName2 = createDepsitMainWork.ClaimName2;             // ���Ӑ於��2(������)
                    depositAlwWork.DebitNoteOffSetCd = 0;                                       // �ԓ`���E�敪
                    //--- ADD 2008/04/25 M.Kubota ---<<<
                    # endregion
                    // �� 20070123 18322 c

                    ArrayList ar = new ArrayList();
                    ar.Add(depositAlwWork);
                    DepositAlwWork[] depositAlwWorkList = (DepositAlwWork[])ar.ToArray(typeof(DepositAlwWork));

                    //--- DEL 2008/04/25 M.Kubota --->>>
                    // �X�V�����b�N����(�P�����ɔr���������s��)
                    //int[] CustomerCodeList = { depsitMainWork.CustomerCode };
                    //status = controlExclusiveOrderAccess.LockDB(EnterpriseCode, CustomerCodeList, null);	// ���Ӑ�ʃ��b�N��������

                    //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //{
                    //    break;
                    //}
                    //--- DEL 2008/04/25 M.Kubota ---<<<

                    // �����}�X�^�X�V����
                    //status = WriteDepsitMainWork(ref depsitMainWork, ref depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota
                    status = this.Write(ref depsitMainWork, ref depsitDtlWorkArray, ref depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota

                    // �X�V�����b�N����
                    //controlExclusiveOrderAccess.UnlockDB();  //DEL 2008/04/25 M.Kubota

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        break;
                    }

                    // �X�V���������ԍ����擾
                    depositSlipNoListAr.Add(depsitMainWork.DepositSlipNo);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    sqlTransaction.Commit();
                else
                    sqlTransaction.Rollback();

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    depositSlipNoList = (int[])depositSlipNoListAr.ToArray(typeof(int));
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    //�V�X�e�����b�N���� //2009/1/27 Add sakurai
                    status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/25 M.Kubota

                //--- ADD 2008/04/25 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/04/25 M.Kubota ---<<<
            }
            //-- ADD 2008/04/25 M.Kubota --->>>
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            //-- ADD 2008/04/25 M.Kubota ---<<<

            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            return status;
        }


        /// <summary>
        /// �����X�V�������C��
        /// </summary>
        /// <param name="depsitMainWork">������񃏁[�N</param>
        /// <param name="depsitDtlWorkArray">�������׏�񃏁[�N</param>
        /// <param name="depositAlwWorkArray">����������񃏁[�N</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns></returns>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �������E���������������Ƀf�[�^�X�V���s���܂�</br>
        /// <br>           : �����ԍ������̎��A�V�K�����쐬�Ƃ��܂�</br>
        /// <br>           : �_���폜�𗧂Ă��ꍇ�A�폜�������s���܂�(�����݂̂̍폜�\)</br>
        /// <br>Programmer : 95089 ���i�@��</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        # region --- DEL 2008/04/25 M.Kubota --->>>
        # if false
        public int Write(ref DepsitMainWork depsitMainWork, ref DepositAlwWork[] depositAlwWorkArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            int depositSlipNo = 0;
            DepsitMainWork bf_depsitMainWork = null;		// �X�V�O�����`�[���
            bool mode_new = false;							// �V�K�������[�h

            Int64 Total_DepositAllowance = 0;
            Int64 Total_bf_DepositAllowance = 0;

            // �V�K�����쐬��
            if (depsitMainWork.DepositSlipNo == 0)
            {
                mode_new = true;							// �V�K�������[�h

                // �����`�[�ԍ��̍̔�(�ԍ��Ǘ���͍X�V���_����擾����)
                status = CreateDepositSlipNoProc(depsitMainWork.EnterpriseCode, depsitMainWork.UpdateSecCd, out depositSlipNo, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // �̔Ԃ��������ԍ���������E�������ɃZ�b�g
                depsitMainWork.DepositSlipNo = depositSlipNo;

                foreach (DepositAlwWork depositAlwWork in depositAlwWorkArray)
                {
                    depositAlwWork.DepositSlipNo = depositSlipNo;

                    // �� 20070131 18322 a MA.NS�p�ɐݒ�
                    // �� 2007.10.12 980081 c
                    //if ((depositAlwWork.AcceptAnOrderNo == depsitMainWork.AcceptAnOrderNo) &&
                    //    (depositAlwWork.CustomerCode == depsitMainWork.CustomerCode))
                    if ((depositAlwWork.AcptAnOdrStatus == depsitMainWork.AcptAnOdrStatus) &&
                        (depositAlwWork.SalesSlipNum == depsitMainWork.SalesSlipNum) &&
                        (depositAlwWork.CustomerCode == depsitMainWork.CustomerCode))
                    // �� 2007.10.12 980081 c
                    {
                        depositAlwWork.CustomerName = depsitMainWork.CustomerName;
                        depositAlwWork.CustomerName2 = depsitMainWork.CustomerName2;
                    }
                    // �� 20070131 18322 a
                }
            }
            // �����C����
            else
            {
                // �X�V�O�������擾
                status = ReadDepsitMainWorkRec(depsitMainWork.EnterpriseCode, depsitMainWork.DepositSlipNo, out bf_depsitMainWork, ref sqlConnection, ref sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
            }

            ArrayList updAcceptOdrWorkList = new ArrayList();

            // �����������X�V
            for (int ix = 0; ix < depositAlwWorkArray.Length; ix++)
            {
                Int64 bf_DepositAllowance;			// �X�V�O�����z
                // �� 20070124 18322 d MA.NS�p�ɕύX
                //Int64 bf_AcpOdrDepositAlwc;			// �X�V�O�󒍈����z 20060220 Ins
                //Int64 bf_VarCostDepoAlwc;			// �X�V�O����p�����z 20060220 Ins
                // �� 20070124 18322 d
                int bf_DepositCd;					// �X�V�O�a����敪
                // �� 2007.10.12 980081 d
                //int bf_CreditOrLoanCd;				// �X�V�O�N���W�b�g�^���[���敪
                // �� 2007.10.12 980081 d

                DepositAlwWork depositAlwWork = (DepositAlwWork)depositAlwWorkArray[ix];

                // �� 20070124 18322 d MA.NS�p�ɕύX
                //UpdAcceptOdrWork updAcceptOdrWork = new UpdAcceptOdrWork();
                //updAcceptOdrWork.AcceptAnOrderNo = 0;
                // �� 20070124 18322 d

                // �� 20070124 18322 d MA.NS�p�ɕύX
        #region SF ������󒍓`�[�̓Ǎ��݁i�S�ăR�����g�A�E�g�j
                //// ����c(�󒍔ԍ�=0)�̎��ȊO
                //if(depositAlwWork.AcceptAnOrderNo != 0)
                //{
                //  // ������󒍓`�[�̓Ǎ���
                //	status = ReadAcceptOdrWorkRec(depositAlwWork.EnterpriseCode, depositAlwWork.AcceptAnOrderNo, ref updAcceptOdrWork, ref sqlConnection, ref sqlTransaction);
                //	if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                //	{
                //		if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //		{
                //			return status;
                //		}
                //  
                //		updAcceptOdrWorkList.Add(updAcceptOdrWork);
                //	}
                //	// �����z�v��f�[�^�����͎󒍃f�[�^���������߁A�󒍂������Ă�����Ƃ���
                //	else
                //	{
                //		updAcceptOdrWork.AcceptAnOrderNo = 0;
                //	}
                //}
        #endregion
                // �� 20070124 18322 d

                // �����폜�w�莞(�_���폜�敪���P)
                if (depositAlwWork.LogicalDeleteCode == 1)
                {
                    depositAlwWork.DepositAllowance = 0;		// ���������z���O�ɂ���

                    // �� 20070123 18322 d MA.NS�p�ɕύX
                    //depositAlwWork.AcpOdrDepositAlwc = 0;		// �󒍓��������z���O�ɂ��� 20060220 Ins
                    //depositAlwWork.VarCostDepoAlwc   = 0;		// ����p���������z���O�ɂ��� 20060220 Ins
                    // �� 20070123 18322 d
                }

                // ���������������l�s�̍X�V���ɍX�V�O�������z���擾���Ă����A��������X�V���Ɉ����z�̍��z�X�V���s��

                // �� 20070124 18322 c MA.NS�p�ɕύX
        #region SF �����i�S�ăR�����g�A�E�g�j
                //// �����}�X�^�X�V (�폜�w�莞�͕����폜�����)
                //status = WriteDepositAlwWork(ref depositAlwWork, out bf_DepositAllowance, out bf_AcpOdrDepositAlwc, out bf_VarCostDepoAlwc, out bf_DepositCd, out bf_CreditOrLoanCd, ref sqlConnection, ref sqlTransaction);	// 20060220 Chg �X�V�O�󒍈����E����p�������Ă̒ǉ�
                //if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //	return status;
                //}
                //
                //// ��������}�X�^�̈����z�X�V
                //status = UpdateDmdSalesRec(ref depositAlwWork, bf_DepositAllowance, bf_AcpOdrDepositAlwc, bf_VarCostDepoAlwc, bf_DepositCd, bf_CreditOrLoanCd, depsitMainWork.CreditOrLoanCd , ref sqlConnection, ref sqlTransaction);	// 20060220 Chg �X�V�O�󒍈����E����p�������Ă̒ǉ�
                //if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //	return status;
                //}
                //
                //// ����c(�󒍔ԍ�=0) or �󒍃f�[�^�����݂��Ȃ�(�����z�v��f�[�^��)���ȊO
                //if (depositAlwWork.AcceptAnOrderNo != 0 && updAcceptOdrWork.AcceptAnOrderNo != 0)
                //{
                //	// �X�V�p�󒍃��[�N�ւ̈����z�����Z����
                //	status = CalcAcceptOdrWorkRec(depositAlwWork.CustomerCode, depositAlwWork, ref updAcceptOdrWork, bf_DepositAllowance, bf_DepositCd, bf_CreditOrLoanCd);
                //	if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //	{
                //		return status;
                //	}
                //
                //	// �󒍃}�X�^�̈����z�X�V
                //	status = WriteAcceptOdrWorkRec(ref updAcceptOdrWork, ref sqlConnection, ref sqlTransaction);
                //	if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //	{
                //		return status;
                //	}
                //}
        #endregion

                // �����}�X�^�X�V (�폜�w�莞�͕����폜�����)
                status = WriteDepositAlwWork(ref depositAlwWork, out bf_DepositAllowance, out bf_DepositCd, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // ��������}�X�^�̈����z�X�V
                status = UpdateSalesSlipRec(ref depositAlwWork, bf_DepositAllowance, bf_DepositCd, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
                // �� 20070124 18322 c

                // �V�����z
                Total_DepositAllowance += depositAlwWork.DepositAllowance;
                // �������z
                Total_bf_DepositAllowance += bf_DepositAllowance;
            }

            // �����z�����Z
            //			depsitMainWork.DepositAllowance = depsitMainWork.DepositAllowance  + Total_DepositAllowance - Total_bf_DepositAllowance;
            // �����f�[�^�X�V
            status = WriteDepsitMainWork(mode_new, ref depsitMainWork, ref sqlConnection, ref sqlTransaction);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            // �� 20070327 18322 d ���Ӑ搿��(���|)���z�}�X�^�͏���������
            //                     �X�V����悤�ɂȂ����ׁA�폜
        #region ���Ӑ搿��(���|)���z�}�X�^�X�V�����i�S�ăR�����g�A�E�g�j
            //// ���z�}�X�^�X�V >>>>>>>>
            //UpdateCustAccDmdRec updateCustAccDmdRec = new UpdateCustAccDmdRec();
            //
            //CustAccUpdatePara bf_custAccUpdatePara = new CustAccUpdatePara();                        // ���z���Z���R�[�h
            //CustAccUpdatePara af_custAccUpdatePara = new CustAccUpdatePara();                        // ���z���Z���R�[�h
            //
            //ArrayList custAccUpdateParas = new ArrayList();                                    		// ���z�}�X�^�X�V���i�p�����[�^
            //
            //// �ǉ����R�[�h
            //if(depsitMainWork.LogicalDeleteCode == 0)                                                	// �폜���ȊO
            //{
            //	af_custAccUpdatePara.AddDel = 0;                                                		// �ǉ��폜�敪:�ǉ��O
            //	af_custAccUpdatePara.AddUpADate            = depsitMainWork.AddUpADate;            		// �v����t
            //	af_custAccUpdatePara.DemandAddUpSecCd	= depsitMainWork.AddUpSecCode;            		// �����v�㋒�_�R�[�h
            //	if(depsitMainWork.DepositCd == 1)                                                		// �a������̏ꍇ
            //	{
            //		af_custAccUpdatePara.FeeDeposit2		= depsitMainWork.FeeDeposit;            	// �a����萔�������z
            //		af_custAccUpdatePara.DiscountDeposit2	= depsitMainWork.DiscountDeposit;            // �a����l�������z
            //		af_custAccUpdatePara.Deposit2            = depsitMainWork.Deposit;            		// �a����������z(�l���E�萔�����������z)
            //        // �� 20070124 18322 a MA.NS�p�ɕύX
            //        // �a������x�[�g�����z
            //        af_custAccUpdatePara.RebateDeposit2     = depsitMainWork.RebateDeposit;
            //        // �� 20070124 18322 a
            //
            //        // �� 20070123 18322 d MA.NS�p�ɕύX
            //        #region SF ����p�ʓ����Ή��i�S�ăR�����g�A�E�g�j
            //        //// 20060220 Ins Start >>����p�ʓ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //		//// �󒍓����z
            //		//af_custAccUpdatePara.AcpOdrChargeDeposit2= depsitMainWork.AcpOdrChargeDeposit;		// �a����萔�������z
            //		//af_custAccUpdatePara.AcpOdrDisDeposit2	= depsitMainWork.AcpOdrDisDeposit;            // �a����l�������z
            //		//af_custAccUpdatePara.AcpOdrDeposit2		= depsitMainWork.AcpOdrDeposit;            	// �a����������z(�l���E�萔�����������z)
            //		//// ����p�����z
            //		//af_custAccUpdatePara.VarCostChargeDeposit2= depsitMainWork.VarCostChargeDeposit;	// �a�������p�萔�������z
            //		//af_custAccUpdatePara.VarCostDisDeposit2	= depsitMainWork.VarCostDisDeposit;            // �a�������p�l�������z
            //		//af_custAccUpdatePara.VariousCostDeposit2= depsitMainWork.VariousCostDeposit;		// �a�������p�������z(�l���E�萔�����������z)
            //        //// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            //        #endregion
            //        // �� 20070123 18322 d
            //	}
            //	else
            //	{
            //		af_custAccUpdatePara.FeeDeposit            = depsitMainWork.FeeDeposit;            	// �萔�������z
            //		af_custAccUpdatePara.DiscountDeposit	= depsitMainWork.DiscountDeposit;            // �l�������z
            //		af_custAccUpdatePara.Deposit            = depsitMainWork.Deposit;            		// �������z
            //        // �� 20070124 18322 a MA.NS�p�ɕύX
            //        // ���x�[�g�����z
            //        af_custAccUpdatePara.RebateDeposit      = depsitMainWork.RebateDeposit;
            //        // �� 20070124 18322 a
            //
            //        // �� 20070123 18322 d NA.NS�p�ɕύX
            //        #region SF ����p�ʓ����Ή��i�S�ăR�����g�A�E�g�j
            //        //// 20060220 Ins Start >>����p�ʓ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //		//// �󒍓����z
            //		//af_custAccUpdatePara.AcpOdrChargeDeposit= depsitMainWork.AcpOdrChargeDeposit;		// �萔�������z
            //		//af_custAccUpdatePara.AcpOdrDisDeposit	= depsitMainWork.AcpOdrDisDeposit;            // �l�������z
            //		//af_custAccUpdatePara.AcpOdrDeposit		= depsitMainWork.AcpOdrDeposit;            	// �������z(�l���E�萔�����������z)
            //		//// ����p�����z
            //		//af_custAccUpdatePara.VarCostChargeDeposit= depsitMainWork.VarCostChargeDeposit;		// ����p�萔�������z
            //		//af_custAccUpdatePara.VarCostDisDeposit	= depsitMainWork.VarCostDisDeposit;            // ����p�l�������z
            //		//af_custAccUpdatePara.VariousCostDeposit	= depsitMainWork.VariousCostDeposit;		// ����p�������z(�l���E�萔�����������z)
            //        //// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            //        #endregion
            //        // �� 20070123 18322 d
            //	}
            //
            //	custAccUpdateParas.Add(af_custAccUpdatePara);                                    		// �p�����[�^�ǉ�
            //}
            //
            //// �폜���R�[�h
            //if(mode_new == false)                                                            		// �����C�������폜���R�[�h���ǉ�
            //{
            //	bf_custAccUpdatePara.AddDel = 1;                                                	// �ǉ��폜�敪:�폜�P
            //	bf_custAccUpdatePara.AddUpADate            = bf_depsitMainWork.AddUpADate;            	// �v����t
            //	bf_custAccUpdatePara.DemandAddUpSecCd	= bf_depsitMainWork.AddUpSecCode;            // �����v�㋒�_�R�[�h
            //	if(bf_depsitMainWork.DepositCd == 1)                                                // �a������̏ꍇ
            //	{
            //		bf_custAccUpdatePara.FeeDeposit2		= bf_depsitMainWork.FeeDeposit;            // �a����萔�������z
            //		bf_custAccUpdatePara.DiscountDeposit2	= bf_depsitMainWork.DiscountDeposit;	// �a����l�������z
            //		bf_custAccUpdatePara.Deposit2            = bf_depsitMainWork.Deposit;            // �a����������z(�l���E�萔�����������z)
            //        // �� 20070124 18322 a MA.NS�p�ɕύX
            //        // �a������x�[�g�����z
            //        bf_custAccUpdatePara.RebateDeposit2     = bf_depsitMainWork.RebateDeposit;
            //        // �� 20070124 18322 a
            //
            //        // �� 20070124 18322 d MA.NS�p�ɕύX
            //        #region SF ����p�ʓ����Ή��i�S�ăR�����g�A�E�g�j
            //        //// 20060220 Ins Start >>����p�ʓ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //		//// �󒍓����z
            //		//bf_custAccUpdatePara.AcpOdrChargeDeposit2= bf_depsitMainWork.AcpOdrChargeDeposit;	// �a����萔�������z
            //		//bf_custAccUpdatePara.AcpOdrDisDeposit2	= bf_depsitMainWork.AcpOdrDisDeposit;		// �a����l�������z
            //		//bf_custAccUpdatePara.AcpOdrDeposit2		= bf_depsitMainWork.AcpOdrDeposit;            // �a����������z(�l���E�萔�����������z)
            //		//// ����p�����z
            //		//bf_custAccUpdatePara.VarCostChargeDeposit2= bf_depsitMainWork.VarCostChargeDeposit;	// �a�������p�萔�������z
            //		//bf_custAccUpdatePara.VarCostDisDeposit2	= bf_depsitMainWork.VarCostDisDeposit;		// �a�������p�l�������z
            //		//bf_custAccUpdatePara.VariousCostDeposit2= bf_depsitMainWork.VariousCostDeposit;		// �a�������p�������z(�l���E�萔�����������z)
            //        //// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            //        #endregion
            //        // �� 20070124 18322 d
            //    }
            //	else
            //	{
            //		bf_custAccUpdatePara.FeeDeposit            = bf_depsitMainWork.FeeDeposit;            // �萔�������z
            //		bf_custAccUpdatePara.DiscountDeposit	= bf_depsitMainWork.DiscountDeposit;	// �l�������z
            //		bf_custAccUpdatePara.Deposit            = bf_depsitMainWork.Deposit;            // �������z
            //
            //        // �� 20070124 18322 a MA.NS�p�ɕύX
            //        // ���x�[�g�����z
            //        bf_custAccUpdatePara.RebateDeposit      = bf_depsitMainWork.RebateDeposit;
            //        // �� 20070124 18322 a
            //
            //        // �� 20070124 18322 d MA.NS�p�ɕύX
            //        #region SF ����p�ʓ����Ή��i�S�ăR�����g�A�E�g�j
            //        //// 20060220 Ins Start >>����p�ʓ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //		//// �󒍓����z
            //		//bf_custAccUpdatePara.AcpOdrChargeDeposit= bf_depsitMainWork.AcpOdrChargeDeposit;	// �萔�������z
            //		//bf_custAccUpdatePara.AcpOdrDisDeposit	= bf_depsitMainWork.AcpOdrDisDeposit;		// �l�������z
            //		//bf_custAccUpdatePara.AcpOdrDeposit		= bf_depsitMainWork.AcpOdrDeposit;            // �������z(�l���E�萔�����������z)
            //		//// ����p�����z
            //		//bf_custAccUpdatePara.VarCostChargeDeposit= bf_depsitMainWork.VarCostChargeDeposit;	// ����p�萔�������z
            //		//bf_custAccUpdatePara.VarCostDisDeposit	= bf_depsitMainWork.VarCostDisDeposit;		// ����p�l�������z
            //		//bf_custAccUpdatePara.VariousCostDeposit	= bf_depsitMainWork.VariousCostDeposit;		// ����p�������z(�l���E�萔�����������z)
            //        //// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            //        #endregion
            //        // �� 20070124 18322 d
            //	}
            //
            //	custAccUpdateParas.Add(bf_custAccUpdatePara);                                    	// �p�����[�^�ǉ�
            //}
            //
            //CustAccUpdatePara[] CustAccUpdateParasArray =  (CustAccUpdatePara[])custAccUpdateParas.ToArray(typeof(CustAccUpdatePara));
            //
            //// �� 20070131 18322 c MA.NS�p�ɕύX
            ////// ���z�}�X�^�X�V����
            ////status = updateCustAccDmdRec.Write(depsitMainWork.EnterpriseCode, depsitMainWork.CustomerCode, CustAccUpdateParasArray, ref sqlConnection, ref sqlTransaction);
            //
            //// ���z�}�X�^�X�V����(������̓��Ӑ搿�����z�E���|���z�}�X�^���쐬)
            //status = updateCustAccDmdRec.Write(     depsitMainWork.EnterpriseCode
            //                                  ,     depsitMainWork.CustomerCode 
            //                                  ,     CustAccUpdateParasArray
            //                                  , ref sqlConnection
            //                                  , ref sqlTransaction);
            //// �� 20070131 18322 c
        #endregion
            // �� 20070327 18322 d

            return status;
        }
        # endif
        # endregion
        //--- ADD 2008/04/25 M.Kubota --->>>            
        public int Write(ref DepsitMainWork depsitMainWork, ref DepsitDtlWork[] depsitDtlWorkArray, ref DepositAlwWork[] depositAlwWorkArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2008/04/25 M.Kubota
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            # region [�p�����[�^�`�F�b�N]

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            if (depsitMainWork == null)
            {
                errmsg += ": �����}�X�^�f�[�^�����ݒ�ł�.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            if (sqlConnection == null)
            {
                errmsg += ": DB�ڑ��I�u�W�F�N�g�����ݒ�ł�.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            if (sqlTransaction == null)
            {
                errmsg += ": �g�����U�N�V�����I�u�W�F�N�g�����ݒ�ł�.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            # endregion

            string resName = this.GetResourceName(depsitMainWork.EnterpriseCode);
            status = this.Lock(resName, sqlConnection, sqlTransaction);

            try
            {
                status = this.WriteInitial(ref depsitMainWork, ref depsitDtlWorkArray, ref depositAlwWorkArray, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.WriteProc(ref depsitMainWork, ref depsitDtlWorkArray, ref depositAlwWorkArray, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                this.Release(resName, sqlConnection, sqlTransaction);
            }

            return status;
        }
        
        /// <summary>
        /// �����f�[�^�����ݏ�������
        /// </summary>
        /// <param name="depsitMainWork">�����}�X�^�f�[�^</param>
        /// <param name="depsitDtlWorkArray">�������׃f�[�^�̔z��</param>
        /// <param name="depositAlwWorkArray">���������}�X�^�f�[�^�̔z��</param>
        /// <param name="sqlConnection">DB�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        public int WriteInitial(ref DepsitMainWork depsitMainWork, ref DepsitDtlWork[] depsitDtlWorkArray, ref DepositAlwWork[] depositAlwWorkArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            # region [�p�����[�^�`�F�b�N]

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            if (depsitMainWork == null)
            {
                errmsg += ": �����}�X�^�f�[�^�����ݒ�ł�.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            if (sqlConnection == null)
            {
                errmsg += ": DB�ڑ��I�u�W�F�N�g�����ݒ�ł�.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            if (sqlTransaction == null)
            {
                errmsg += ": �g�����U�N�V�����I�u�W�F�N�g�����ݒ�ł�.";
                base.WriteErrorLog(errmsg, status);
                return status;
            }

            # endregion

            if (depsitMainWork != null)
            {
                # region [�����}�X�^ ������������]
                // �����`�[�ԍ��̍̔�
                if (depsitMainWork.DepositSlipNo == 0)
                {
                    // �����`�[�ԍ��̍̔�(�ԍ��Ǘ���͍X�V���_����擾����)
                    int depositSlipNo = 0;
                    status = this.CreateDepositSlipNoProc(depsitMainWork.EnterpriseCode, depsitMainWork.UpdateSecCd, out depositSlipNo, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        depsitMainWork.DepositSlipNo = depositSlipNo;
                    }
                    else
                    {
                        // �����`�[�ԍ��̍̔ԂɎ��s�����ꍇ�͏I��
                        return status;
                    }
                }
                # endregion

                # region [�������׃f�[�^ ������������]
                // �������׃f�[�^
                if (depsitDtlWorkArray != null && depsitDtlWorkArray.Length > 0)
                {
                    foreach (DepsitDtlWork depsitDtlWork in depsitDtlWorkArray)
                    {
                        depsitDtlWork.AcptAnOdrStatus = depsitMainWork.AcptAnOdrStatus;  // �󒍃X�e�[�^�X
                        depsitDtlWork.DepositSlipNo = depsitMainWork.DepositSlipNo;      // �����`�[�ԍ�
                    }
                }
                # endregion

                # region [���������}�X�^�f�[�^ ������������]
                // ���������}�X�^�f�[�^
                if (depositAlwWorkArray != null && depositAlwWorkArray.Length > 0)
                {
                    foreach (DepositAlwWork depositAlwWork in depositAlwWorkArray)
                    {
                        depositAlwWork.DepositSlipNo = depsitMainWork.DepositSlipNo;     // �����`�[�ԍ�

                        if (depositAlwWork.LogicalDeleteCode == 1)
                        {
                            depositAlwWork.DepositAllowance = 0;		// ���������z���O�ɂ���
                        }

                        if ((depositAlwWork.AcptAnOdrStatus == depsitMainWork.AcptAnOdrStatus) &&
                            (depositAlwWork.SalesSlipNum == depsitMainWork.SalesSlipNum) &&
                            (depositAlwWork.CustomerCode == depsitMainWork.ClaimCode))
                        {
                            depositAlwWork.CustomerName = depsitMainWork.ClaimName;
                            depositAlwWork.CustomerName2 = depsitMainWork.ClaimName2;
                        }
                    }
                }
                # endregion

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                errmsg += ": �����}�X�^�f�[�^�����ݒ�ł�.";
                base.WriteErrorLog(errmsg, status);
            }

            return status;
        }

        /// <summary>
        /// �����f�[�^�����ݏ���
        /// </summary>
        /// <param name="depsitMainWork">�����}�X�^�f�[�^</param>
        /// <param name="depsitDtlWorkArray">�������׃f�[�^�̔z��</param>
        /// <param name="depositAlwWorkArray">���������}�X�^�f�[�^�̔z��</param>
        /// <param name="sqlConnection">DB�ڑ��I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">�g�����U�N�V�����I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2012/10/17 wangf </br>
        /// <br>           : 10801804-00�ARedmine#32870�A2012/11/14�z�M�� PM.NS��Q�ꗗNo.1516 �����`�[����/���|�c�����قȂ�̑Ή��B</br>
        /// <br>           : �����`�[�ۑ�����֘A�̓��Ӑ�i�ϓ����j�̌��ݔ��|�c���̒l�̑Ή��B</br>
        /// <br>Update Note: 2012/10/29 wangf </br>
        /// <br>           : 10801804-00�ARedmine#32870�A2012/11/14�z�M�� PM.NS��Q�ꗗNo.1516 �����`�[����/���|�c�����قȂ�̍đΉ��B</br>
        /// <br>           : �����`�[�ۑ�����֘A�̓��Ӑ�i�ϓ����j�̌��ݔ��|�c���̒l�̍đΉ��B</br>
        /// <br>Update Note: 2012/11/06 wangf </br>
        /// <br>           : 10801804-00�ARedmine#32870�A2012/11/14�z�M�� PM.NS��Q�ꗗNo.1516 �����`�[����/���|�c�����قȂ�̍đΉ��B</br>
        /// <br>           : �����`�[�ۑ�����֘A�̓��Ӑ�i�ϓ����j�̌��ݔ��|�c���̒l�̍đΉ��B</br>
        /// <br>           : �������v�̓}�C�i�X�l��ݒ肷��΁A���ݔ��|�c���̍X�V�̑Ή��B</br>
        public int WriteProc(ref DepsitMainWork depsitMainWork, ref DepsitDtlWork[] depsitDtlWorkArray, ref DepositAlwWork[] depositAlwWorkArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (depsitMainWork != null)
            {
                if (depositAlwWorkArray != null)
                {
                    // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
                    int dbCommandTimeout = DB_COMMAND_TIMEOUT; // �R�}���h�^�C���A�E�g�i�b�j
                    this.GetXmlInfo(ref dbCommandTimeout);
                    // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
                    // �����������X�V
                    for (int ix = 0; ix < depositAlwWorkArray.Length; ix++)
                    {
                        Int64 bf_DepositAllowance;			// �X�V�O�����z
                        //int bf_DepositCd;					// �X�V�O�a����敪  //DEL 2008/04/25 M.Kubota

                        DepositAlwWork depositAlwWork = (DepositAlwWork)depositAlwWorkArray[ix];

                        // ���������������l�s�̍X�V���ɍX�V�O�������z���擾���Ă����A��������X�V���Ɉ����z�̍��z�X�V���s��

                        // �����}�X�^�X�V (�폜�w�莞�͕����폜�����)
                        //status = WriteDepositAlwWork(ref depositAlwWork, out bf_DepositAllowance, out bf_DepositCd, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota
                        // --- UPD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
                        //status = WriteDepositAlwWork(ref depositAlwWork, out bf_DepositAllowance, ref sqlConnection, ref sqlTransaction);                      //ADD 2008/04/25 M.Kubota
                        status = WriteDepositAlwWork(ref depositAlwWork, out bf_DepositAllowance, ref sqlConnection, ref sqlTransaction, dbCommandTimeout); 
                        // --- UPD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }

                        // ��������}�X�^�̈����z�X�V
                        //status = UpdateSalesSlipRec(ref depositAlwWork, bf_DepositAllowance, bf_DepositCd, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota
                        status = UpdateSalesSlipRec(ref depositAlwWork, bf_DepositAllowance, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }
                    }
                }
                // ------------ADD wangf 2012/10/17 FOR Redmine#32870--------->>>>
                // �����f�[�^�͍X�V�ۑ����V�K�ۑ����̔��fFLG
                bool flg = false;
                DepsitMainWork depsitMainWorkTmp;
                status = this.ReadDepsitMain(depsitMainWork.EnterpriseCode, depsitMainWork.DepositSlipNo, depsitMainWork.AcptAnOdrStatus, out depsitMainWorkTmp, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���݂���΁A�X�V�ۑ�
                    flg = true;
                }
                // ------------ADD wangf 2012/10/17 FOR Redmine#32870---------<<<<

                // �����f�[�^�o�^�E�X�V
                //status = WriteDepsitMainWork(mode_new, ref depsitMainWork, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota
                status = WriteDepsitMainWork(ref depsitMainWork, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // �������׃f�[�^�o�^�E�X�V
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && depsitDtlWorkArray != null)
                {
                    status = this.WriteDepositDtlWork(ref depsitMainWork, ref depsitDtlWorkArray, ref sqlConnection, ref sqlTransaction);
                }

                // �ʏ�����̏ꍇ�ɂ̂݁A���Ӑ�}�X�^(�ϓ����)�̔��|�c�����X�V����A�܂������̍X�V�����̏ꍇ�͍X�V���Ȃ�
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && depsitMainWork.AutoDepositCd == 0 && depsitMainWork.DepositDebitNoteCd != 2)
                {
                    if (depsitMainWork.DepositDebitNoteCd == 1 && depsitMainWork.LogicalDeleteCode == 1)
                    {
                        // �ԓ`�̍폜�̏ꍇ�́A���̒�����Ɍ��������`�̓o�^����������̂�
                        // �Q�d�Ɍ��Z�������s����̂�h���ړI�Ŕ��|�c���̍X�V���s��Ȃ�
                        // ------------ADD wangf 2012/10/29 FOR Redmine#32870--------->>>>
                        // �����ƍ��`�X�V�����s����ƁA���|�c���̍X�V���s��Ȃ��̂���
                        // �ԓ`�̍폜�̏ꍇ�͔��|�c���͕K���v�Z���܂�
                        CustomerChangeWork cstChgWrk = new CustomerChangeWork();
                        cstChgWrk.EnterpriseCode = depsitMainWork.EnterpriseCode;
                        cstChgWrk.CustomerCode = depsitMainWork.ClaimCode;

                        // ------------DEL wangf 2012/11/06 FOR Redmine#32870--------->>>>
                        //status = this.CustomerChangeDb.PrsntAccRecBalanceUpdateProc(ref cstChgWrk, -(System.Math.Abs(depsitMainWork.DepositTotal)), ref sqlConnection, ref sqlTransaction);
                        // ------------DEL wangf 2012/11/06 FOR Redmine#32870---------<<<<
                        // ------------ADD wangf 2012/11/06 FOR Redmine#32870--------->>>>
                        // �ԓ`�̍폜�̏ꍇ
                        // ���|�c�������|�c��+�������v
                        status = this.CustomerChangeDb.PrsntAccRecBalanceUpdateProc(ref cstChgWrk, depsitMainWork.DepositTotal, ref sqlConnection, ref sqlTransaction);
                        // ------------ADD wangf 2012/11/06 FOR Redmine#32870---------<<<<
                        // ------------ADD wangf 2012/10/29 FOR Redmine#32870---------<<<<
                    }
                    else
                    {
                        CustomerChangeWork cstChgWrk = new CustomerChangeWork();
                        cstChgWrk.EnterpriseCode = depsitMainWork.EnterpriseCode;
                        cstChgWrk.CustomerCode = depsitMainWork.ClaimCode;

                        // ------------DEL wangf 2012/11/06 FOR Redmine#32870--------->>>>                        
                        // �������z�������Ĕ��|�c���������Z����
                        // �ʏ�E����(���|�c�����Z)�E�ԓ`(���|�c�����Z)�ŕ�����������
                        //int sign = (depsitMainWork.DepositDebitNoteCd != 1) ? -1 : 1;

                        // �o�^(���|�c�����Z)�E�폜(���|�c�����Z)�ŕ�����ς���
                        //sign *= (depsitMainWork.LogicalDeleteCode == 0) ? 1 : -1;
                        // ------------DEL wangf 2012/11/06 FOR Redmine#32870---------<<<<
                        // ------------ADD wangf 2012/11/06 FOR Redmine#32870--------->>>>
                        // �ԓ`�o�^�̏ꍇ
                        // ���|�c�������|�c��-�������v
                        // �ʏ�E�����o�^�̏ꍇ
                        // ���|�c�������|�c��-�������v
                        // �ʏ�E�����폜�̏ꍇ
                        // ���|�c�������|�c��+�������v
                        // �������v�͐�Βl���g�p���Ȃ��Ȃ��āA�������g�̕������܂݂܂���
                        // �ʏ�E�����E�ԓ`�͓o�^����ƁA���|�c�����Z
                        // �ʏ�E�����폜�̏ꍇ�A���|�c�����Z
                        int sign = (depsitMainWork.LogicalDeleteCode == 0) ? -1 : 1;
                        // ------------ADD wangf 2012/11/06 FOR Redmine#32870---------<<<<

                        // ------------DEL wangf 2012/10/17 FOR Redmine#32870--------->>>>
                        // depsitMainWork.Deposit�͒l���E�萔�����������z�̂����ŁA�l���E�萔���͌v�Z�͔͈͈ȊO
                        // �u�����v�E�l���E�萔�����܂ށv�Ƃ��Ă�depsitMainWork.DepositTotal���g�p������A���Ȃ��Ǝv���܂��B
                        //Int64 differenceValue = System.Math.Abs(depsitMainWork.Deposit) * sign;
                        // ------------DEL wangf 2012/10/17 FOR Redmine#32870---------<<<<
                        // ------------ADD wangf 2012/10/17 FOR Redmine#32870--------->>>>
                        //Int64 depositTotal = System.Math.Abs(depsitMainWork.DepositTotal) * sign; // DEL wangf 2012/11/06 FOR Redmine#32870
                        // ------------ADD wangf 2012/11/06 FOR Redmine#32870--------->>>>
                        // ��Βl�g�p���Ȃ��A�������g�̕������܂�Ōv�Z���܂�
                        Int64 depositTotal = depsitMainWork.DepositTotal * sign;
                        // ------------ADD wangf 2012/11/06 FOR Redmine#32870---------<<<<
                        // ���z�́u�����v�E�l���E�萔�����܂ށv�������������A�V�K�ۑ��Ȃ�A���̏����������s���܂��B
                        Int64 differenceValue = depositTotal;
                        // �X�V�ۑ�����΁A�f�[�^�x�[�X�ɑ��݂����w�肳��链�Ӑ�̌��ݔ��|�c�����X�V����
                        // ���z = �����v�E�l���E�萔�����܂� - ���ݔ��|�c��
                        if (flg && depsitMainWork.LogicalDeleteCode != 1)
                        {
                            differenceValue -= sign * depsitMainWorkTmp.DepositTotal;
                        }
                        // ------------ADD wangf 2012/10/17 FOR Redmine#32870---------<<<<

                        status = this.CustomerChangeDb.PrsntAccRecBalanceUpdateProc(ref cstChgWrk, differenceValue, ref sqlConnection, ref sqlTransaction);
                    }
                }
            }

            return status;
        }

        //--- ADD 2008/04/25 M.Kubota ---<<<

        /// <summary>
        /// �����}�X�^�����X�V���܂�
        /// </summary>
        /// <param name="depsitMainWork">�����}�X�^���</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���������X�V���܂�</br>
        /// <br>Programmer : 95089 ���i�@��</br>
        /// <br>Date       : 2005.08.04</br>
        /// <br>Update Note: 2011/07/28 qijh</br>
        /// <br>             SCM�Ή� - ���_�Ǘ�(10704767-00)</br>
        /// 
        //private int WriteDepsitMainWork(bool mode_new, ref DepsitMainWork depsitMainWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //DEL 2008/04/25 M.Kubota
        private int WriteDepsitMainWork(ref DepsitMainWork depsitMainWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2008/04/25 M.Kubota
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlCommand sqlCommand = null;  //ADD 2008/04/25 M.Kubota
            SqlDataReader myReader = null;
            //string updateText;     //DEL 2008/04/25 M.Kubota
            bool deleteSql = false;  //ADD 2008/04/25 M.Kubota

            // �X�V���t���擾
            //DateTime Upd_UpdateDateTime = depsitMainWork.UpdateDateTime;  // DEL 2008/04/25 M.Kubota

            //Select�R�}���h�̐���
            try
            {
                //--- ADD 2008/04/25 M.Kubota --->>>
                # region [SELECT��]
                string sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  DEPMAIN.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,DEPMAIN.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  DEPSITMAINRF AS DEPMAIN" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  DEPMAIN.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND DEPMAIN.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                sqlText += "  AND DEPMAIN.DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;
                # endregion

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.EnterpriseCode);   // ��ƃR�[�h
                findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.AcptAnOdrStatus);  // �󒍃X�e�[�^�X
                findDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositSlipNo);      // �����`�[�ԍ�

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����

                    if (_updateDateTime != depsitMainWork.UpdateDateTime)
                    {
                        if (depsitMainWork.UpdateDateTime == DateTime.MinValue)
                        {
                            //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                        }
                        else
                        {
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        }

                        return status;
                    }
                    // ADD 2011/07/28 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
                    // �����f�[�^���X�V����O�ɁA���M�ς݂̃`�F�b�N���s��
                    if (!CheckDepsitMainSending(depsitMainWork))
                    {
                        // �`�F�b�NNG
                        if (myReader != null)
                        {
                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }
                            myReader.Dispose();
                        }
                        return STATUS_CHK_SEND_ERR;
                    }
                    // ADD 2011/07/28 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<

                    //if (depsitMainWork.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData1) // DEL 2009/05/01
                    if (depsitMainWork.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData3) // ADD 2009/05/01
                    {
                        // �_���폜�敪�� 3 �̏ꍇ�͍폜�������s��
                        # region [DELETE��]
                        sqlText = string.Empty;
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  DEPSITMAINRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += "  AND DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;
                        # endregion

                        deleteSql = true;
                    }
                    else
                    {
                        // �_���폜�敪�� 0 �̏ꍇ�͍X�V�������s��
                        # region [UPDATE��]
                        sqlText = string.Empty;
                        sqlText += "UPDATE DEPSITMAINRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,ACPTANODRSTATUSRF = @ACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += " ,DEPOSITDEBITNOTECDRF = @DEPOSITDEBITNOTECD" + Environment.NewLine;
                        sqlText += " ,DEPOSITSLIPNORF = @DEPOSITSLIPNO" + Environment.NewLine;
                        sqlText += " ,SALESSLIPNUMRF = @SALESSLIPNUM" + Environment.NewLine;
                        sqlText += " ,INPUTDEPOSITSECCDRF = @INPUTDEPOSITSECCD" + Environment.NewLine;
                        sqlText += " ,ADDUPSECCODERF = @ADDUPSECCODE" + Environment.NewLine;
                        sqlText += " ,UPDATESECCDRF = @UPDATESECCD" + Environment.NewLine;
                        sqlText += " ,SUBSECTIONCODERF = @SUBSECTIONCODE" + Environment.NewLine;
                        sqlText += " ,INPUTDAYRF = @INPUTDAY" + Environment.NewLine;
                        sqlText += " ,DEPOSITDATERF = @DEPOSITDATE" + Environment.NewLine;
                        sqlText += " ,ADDUPADATERF = @ADDUPADATE" + Environment.NewLine;
                        sqlText += " ,DEPOSITTOTALRF = @DEPOSITTOTAL" + Environment.NewLine;
                        sqlText += " ,DEPOSITRF = @DEPOSIT" + Environment.NewLine;
                        sqlText += " ,FEEDEPOSITRF = @FEEDEPOSIT" + Environment.NewLine;
                        sqlText += " ,DISCOUNTDEPOSITRF = @DISCOUNTDEPOSIT" + Environment.NewLine;
                        sqlText += " ,AUTODEPOSITCDRF = @AUTODEPOSITCD" + Environment.NewLine;
                        sqlText += " ,DRAFTDRAWINGDATERF = @DRAFTDRAWINGDATE" + Environment.NewLine;
                        sqlText += " ,DRAFTKINDRF = @DRAFTKIND" + Environment.NewLine;
                        sqlText += " ,DRAFTKINDNAMERF = @DRAFTKINDNAME" + Environment.NewLine;
                        sqlText += " ,DRAFTDIVIDERF = @DRAFTDIVIDE" + Environment.NewLine;
                        sqlText += " ,DRAFTDIVIDENAMERF = @DRAFTDIVIDENAME" + Environment.NewLine;
                        sqlText += " ,DRAFTNORF = @DRAFTNO" + Environment.NewLine;
                        sqlText += " ,DEPOSITALLOWANCERF = @DEPOSITALLOWANCE" + Environment.NewLine;
                        sqlText += " ,DEPOSITALWCBLNCERF = @DEPOSITALWCBLNCE" + Environment.NewLine;
                        sqlText += " ,DEBITNOTELINKDEPONORF = @DEBITNOTELINKDEPONO" + Environment.NewLine;
                        sqlText += " ,LASTRECONCILEADDUPDTRF = @LASTRECONCILEADDUPDT" + Environment.NewLine;
                        sqlText += " ,DEPOSITAGENTCODERF = @DEPOSITAGENTCODE" + Environment.NewLine;
                        sqlText += " ,DEPOSITAGENTNMRF = @DEPOSITAGENTNM" + Environment.NewLine;
                        sqlText += " ,DEPOSITINPUTAGENTCDRF = @DEPOSITINPUTAGENTCD" + Environment.NewLine;
                        sqlText += " ,DEPOSITINPUTAGENTNMRF = @DEPOSITINPUTAGENTNM" + Environment.NewLine;
                        sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                        sqlText += " ,CUSTOMERNAMERF = @CUSTOMERNAME" + Environment.NewLine;
                        sqlText += " ,CUSTOMERNAME2RF = @CUSTOMERNAME2" + Environment.NewLine;
                        sqlText += " ,CUSTOMERSNMRF = @CUSTOMERSNM" + Environment.NewLine;
                        sqlText += " ,CLAIMCODERF = @CLAIMCODE" + Environment.NewLine;
                        sqlText += " ,CLAIMNAMERF = @CLAIMNAME" + Environment.NewLine;
                        sqlText += " ,CLAIMNAME2RF = @CLAIMNAME2" + Environment.NewLine;
                        sqlText += " ,CLAIMSNMRF = @CLAIMSNM" + Environment.NewLine;
                        sqlText += " ,OUTLINERF = @OUTLINE" + Environment.NewLine;
                        sqlText += " ,BANKCODERF = @BANKCODE" + Environment.NewLine;
                        sqlText += " ,BANKNAMERF = @BANKNAME" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += "  AND DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;
                        # endregion

                        //�X�V�w�b�_����ݒ�
                        int logicalDeleteCode = depsitMainWork.LogicalDeleteCode; // 2009/05/01
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)depsitMainWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                        depsitMainWork.LogicalDeleteCode = logicalDeleteCode;  // 2009/05/01
                    }

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.EnterpriseCode);   // ��ƃR�[�h
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.AcptAnOdrStatus);  // �󒍃X�e�[�^�X
                    findDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositSlipNo);      // �����`�[�ԍ�
                }
                else
                {
                    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    if (depsitMainWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        return status;
                    }

                    # region [INSERT��]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO DEPSITMAINRF" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += " ,DEPOSITDEBITNOTECDRF" + Environment.NewLine;
                    sqlText += " ,DEPOSITSLIPNORF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += " ,INPUTDEPOSITSECCDRF" + Environment.NewLine;
                    sqlText += " ,ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += " ,UPDATESECCDRF" + Environment.NewLine;
                    sqlText += " ,SUBSECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,INPUTDAYRF" + Environment.NewLine;
                    sqlText += " ,DEPOSITDATERF" + Environment.NewLine;
                    sqlText += " ,ADDUPADATERF" + Environment.NewLine;
                    sqlText += " ,DEPOSITTOTALRF" + Environment.NewLine;
                    sqlText += " ,DEPOSITRF" + Environment.NewLine;
                    sqlText += " ,FEEDEPOSITRF" + Environment.NewLine;
                    sqlText += " ,DISCOUNTDEPOSITRF" + Environment.NewLine;
                    sqlText += " ,AUTODEPOSITCDRF" + Environment.NewLine;
                    sqlText += " ,DRAFTDRAWINGDATERF" + Environment.NewLine;
                    sqlText += " ,DRAFTKINDRF" + Environment.NewLine;
                    sqlText += " ,DRAFTKINDNAMERF" + Environment.NewLine;
                    sqlText += " ,DRAFTDIVIDERF" + Environment.NewLine;
                    sqlText += " ,DRAFTDIVIDENAMERF" + Environment.NewLine;
                    sqlText += " ,DRAFTNORF" + Environment.NewLine;
                    sqlText += " ,DEPOSITALLOWANCERF" + Environment.NewLine;
                    sqlText += " ,DEPOSITALWCBLNCERF" + Environment.NewLine;
                    sqlText += " ,DEBITNOTELINKDEPONORF" + Environment.NewLine;
                    sqlText += " ,LASTRECONCILEADDUPDTRF" + Environment.NewLine;
                    sqlText += " ,DEPOSITAGENTCODERF" + Environment.NewLine;
                    sqlText += " ,DEPOSITAGENTNMRF" + Environment.NewLine;
                    sqlText += " ,DEPOSITINPUTAGENTCDRF" + Environment.NewLine;
                    sqlText += " ,DEPOSITINPUTAGENTNMRF" + Environment.NewLine;
                    sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += " ,CUSTOMERNAMERF" + Environment.NewLine;
                    sqlText += " ,CUSTOMERNAME2RF" + Environment.NewLine;
                    sqlText += " ,CUSTOMERSNMRF" + Environment.NewLine;
                    sqlText += " ,CLAIMCODERF" + Environment.NewLine;
                    sqlText += " ,CLAIMNAMERF" + Environment.NewLine;
                    sqlText += " ,CLAIMNAME2RF" + Environment.NewLine;
                    sqlText += " ,CLAIMSNMRF" + Environment.NewLine;
                    sqlText += " ,OUTLINERF" + Environment.NewLine;
                    sqlText += " ,BANKCODERF" + Environment.NewLine;
                    sqlText += " ,BANKNAMERF" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;
                    sqlText += "VALUES" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " ,@ACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += " ,@DEPOSITDEBITNOTECD" + Environment.NewLine;
                    sqlText += " ,@DEPOSITSLIPNO" + Environment.NewLine;
                    sqlText += " ,@SALESSLIPNUM" + Environment.NewLine;
                    sqlText += " ,@INPUTDEPOSITSECCD" + Environment.NewLine;
                    sqlText += " ,@ADDUPSECCODE" + Environment.NewLine;
                    sqlText += " ,@UPDATESECCD" + Environment.NewLine;
                    sqlText += " ,@SUBSECTIONCODE" + Environment.NewLine;
                    sqlText += " ,@INPUTDAY" + Environment.NewLine;
                    sqlText += " ,@DEPOSITDATE" + Environment.NewLine;
                    sqlText += " ,@ADDUPADATE" + Environment.NewLine;
                    sqlText += " ,@DEPOSITTOTAL" + Environment.NewLine;
                    sqlText += " ,@DEPOSIT" + Environment.NewLine;
                    sqlText += " ,@FEEDEPOSIT" + Environment.NewLine;
                    sqlText += " ,@DISCOUNTDEPOSIT" + Environment.NewLine;
                    sqlText += " ,@AUTODEPOSITCD" + Environment.NewLine;
                    sqlText += " ,@DRAFTDRAWINGDATE" + Environment.NewLine;
                    sqlText += " ,@DRAFTKIND" + Environment.NewLine;
                    sqlText += " ,@DRAFTKINDNAME" + Environment.NewLine;
                    sqlText += " ,@DRAFTDIVIDE" + Environment.NewLine;
                    sqlText += " ,@DRAFTDIVIDENAME" + Environment.NewLine;
                    sqlText += " ,@DRAFTNO" + Environment.NewLine;
                    sqlText += " ,@DEPOSITALLOWANCE" + Environment.NewLine;
                    sqlText += " ,@DEPOSITALWCBLNCE" + Environment.NewLine;
                    sqlText += " ,@DEBITNOTELINKDEPONO" + Environment.NewLine;
                    sqlText += " ,@LASTRECONCILEADDUPDT" + Environment.NewLine;
                    sqlText += " ,@DEPOSITAGENTCODE" + Environment.NewLine;
                    sqlText += " ,@DEPOSITAGENTNM" + Environment.NewLine;
                    sqlText += " ,@DEPOSITINPUTAGENTCD" + Environment.NewLine;
                    sqlText += " ,@DEPOSITINPUTAGENTNM" + Environment.NewLine;
                    sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                    sqlText += " ,@CUSTOMERNAME" + Environment.NewLine;
                    sqlText += " ,@CUSTOMERNAME2" + Environment.NewLine;
                    sqlText += " ,@CUSTOMERSNM" + Environment.NewLine;
                    sqlText += " ,@CLAIMCODE" + Environment.NewLine;
                    sqlText += " ,@CLAIMNAME" + Environment.NewLine;
                    sqlText += " ,@CLAIMNAME2" + Environment.NewLine;
                    sqlText += " ,@CLAIMSNM" + Environment.NewLine;
                    sqlText += " ,@OUTLINE" + Environment.NewLine;
                    sqlText += " ,@BANKCODE" + Environment.NewLine;
                    sqlText += " ,@BANKNAME" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;
                    # endregion

                    //�o�^�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)depsitMainWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }

                sqlCommand.CommandText = sqlText;

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }

                if (!deleteSql)  // �ǉ��E�X�V�̍ۂɂ̂݃p�����[�^��ݒ肷��
                {
                    # region Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraDepositDebitNoteCd = sqlCommand.Parameters.Add("@DEPOSITDEBITNOTECD", SqlDbType.Int);
                    SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                    SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                    SqlParameter paraInputDepositSecCd = sqlCommand.Parameters.Add("@INPUTDEPOSITSECCD", SqlDbType.NChar);
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                    SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                    SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                    SqlParameter paraDepositDate = sqlCommand.Parameters.Add("@DEPOSITDATE", SqlDbType.Int);
                    SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                    SqlParameter paraDepositTotal = sqlCommand.Parameters.Add("@DEPOSITTOTAL", SqlDbType.BigInt);
                    SqlParameter paraDeposit = sqlCommand.Parameters.Add("@DEPOSIT", SqlDbType.BigInt);
                    SqlParameter paraFeeDeposit = sqlCommand.Parameters.Add("@FEEDEPOSIT", SqlDbType.BigInt);
                    SqlParameter paraDiscountDeposit = sqlCommand.Parameters.Add("@DISCOUNTDEPOSIT", SqlDbType.BigInt);
                    SqlParameter paraAutoDepositCd = sqlCommand.Parameters.Add("@AUTODEPOSITCD", SqlDbType.Int);
                    SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                    SqlParameter paraDraftKind = sqlCommand.Parameters.Add("@DRAFTKIND", SqlDbType.Int);
                    SqlParameter paraDraftKindName = sqlCommand.Parameters.Add("@DRAFTKINDNAME", SqlDbType.NChar);
                    SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
                    SqlParameter paraDraftDivideName = sqlCommand.Parameters.Add("@DRAFTDIVIDENAME", SqlDbType.NChar);
                    SqlParameter paraDraftNo = sqlCommand.Parameters.Add("@DRAFTNO", SqlDbType.NChar);
                    SqlParameter paraDepositAllowance = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE", SqlDbType.BigInt);
                    SqlParameter paraDepositAlwcBlnce = sqlCommand.Parameters.Add("@DEPOSITALWCBLNCE", SqlDbType.BigInt);
                    SqlParameter paraDebitNoteLinkDepoNo = sqlCommand.Parameters.Add("@DEBITNOTELINKDEPONO", SqlDbType.Int);
                    SqlParameter paraLastReconcileAddUpDt = sqlCommand.Parameters.Add("@LASTRECONCILEADDUPDT", SqlDbType.Int);
                    SqlParameter paraDepositAgentCode = sqlCommand.Parameters.Add("@DEPOSITAGENTCODE", SqlDbType.NChar);
                    SqlParameter paraDepositAgentNm = sqlCommand.Parameters.Add("@DEPOSITAGENTNM", SqlDbType.NVarChar);
                    SqlParameter paraDepositInputAgentCd = sqlCommand.Parameters.Add("@DEPOSITINPUTAGENTCD", SqlDbType.NChar);
                    SqlParameter paraDepositInputAgentNm = sqlCommand.Parameters.Add("@DEPOSITINPUTAGENTNM", SqlDbType.NVarChar);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                    SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                    SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                    SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                    SqlParameter paraClaimName = sqlCommand.Parameters.Add("@CLAIMNAME", SqlDbType.NVarChar);
                    SqlParameter paraClaimName2 = sqlCommand.Parameters.Add("@CLAIMNAME2", SqlDbType.NVarChar);
                    SqlParameter paraClaimSnm = sqlCommand.Parameters.Add("@CLAIMSNM", SqlDbType.NVarChar);
                    SqlParameter paraOutline = sqlCommand.Parameters.Add("@OUTLINE", SqlDbType.NVarChar);
                    SqlParameter paraBankCode = sqlCommand.Parameters.Add("@BANKCODE", SqlDbType.Int);
                    SqlParameter paraBankName = sqlCommand.Parameters.Add("@BANKNAME", SqlDbType.NVarChar);
                    # endregion

                    # region Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitMainWork.CreateDateTime);                  // �쐬����
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitMainWork.UpdateDateTime);                  // �X�V����
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.EnterpriseCode);                             // ��ƃR�[�h
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depsitMainWork.FileHeaderGuid);                               // GUID
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdEmployeeCode);                           // �X�V�]�ƈ��R�[�h
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdAssemblyId1);                             // �X�V�A�Z���u��ID1
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdAssemblyId2);                             // �X�V�A�Z���u��ID2
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.LogicalDeleteCode);                        // �_���폜�敪
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.AcptAnOdrStatus);                            // �󒍃X�e�[�^�X
                    paraDepositDebitNoteCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositDebitNoteCd);                      // �����ԍ��敪
                    paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositSlipNo);                                // �����`�[�ԍ�
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(depsitMainWork.SalesSlipNum);                                 // ����`�[�ԍ�
                    paraInputDepositSecCd.Value = SqlDataMediator.SqlSetString(depsitMainWork.InputDepositSecCd);                       // �������͋��_�R�[�h
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.AddUpSecCode);                                 // �v�㋒�_�R�[�h
                    paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdateSecCd);                                   // �X�V���_�R�[�h
                    paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.SubSectionCode);                              // ����R�[�h
                    paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.InputDay);                           // ���͓��t  //ADD 2009/03/25
                    paraDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.DepositDate);                     // �������t
                    paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.AddUpADate);                       // �v����t
                    paraDepositTotal.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositTotal);                                  // �����v
                    paraDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.Deposit);                                            // �������z
                    paraFeeDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.FeeDeposit);                                      // �萔�������z
                    paraDiscountDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DiscountDeposit);                            // �l�������z
                    paraAutoDepositCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.AutoDepositCd);                                // ���������敪
                    paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.DraftDrawingDate);           // ��`�U�o��
                    paraDraftKind.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DraftKind);                                        // ��`���
                    paraDraftKindName.Value = SqlDataMediator.SqlSetString(depsitMainWork.DraftKindName);                               // ��`��ޖ���
                    paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DraftDivide);                                    // ��`�敪
                    paraDraftDivideName.Value = SqlDataMediator.SqlSetString(depsitMainWork.DraftDivideName);                           // ��`�敪����
                    paraDraftNo.Value = SqlDataMediator.SqlSetString(depsitMainWork.DraftNo);                                           // ��`�ԍ�
                    paraDepositAllowance.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositAllowance);                          // ���������z
                    paraDepositAlwcBlnce.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositAlwcBlnce);                          // ���������c��
                    paraDebitNoteLinkDepoNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DebitNoteLinkDepoNo);                    // �ԍ������A���ԍ�
                    paraLastReconcileAddUpDt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.LastReconcileAddUpDt);   // �ŏI�������݌v���
                    paraDepositAgentCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositAgentCode);                         // �����S���҃R�[�h
                    paraDepositAgentNm.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositAgentNm);                             // �����S���Җ���
                    paraDepositInputAgentCd.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositInputAgentCd);                   // �������͎҃R�[�h
                    paraDepositInputAgentNm.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositInputAgentNm);                   // �������͎Җ���
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.CustomerCode);                                  // ���Ӑ�R�[�h
                    paraCustomerName.Value = SqlDataMediator.SqlSetString(depsitMainWork.CustomerName);                                 // ���Ӑ於��
                    paraCustomerName2.Value = SqlDataMediator.SqlSetString(depsitMainWork.CustomerName2);                               // ���Ӑ於��2
                    paraCustomerSnm.Value = SqlDataMediator.SqlSetString(depsitMainWork.CustomerSnm);                                   // ���Ӑ旪��
                    paraClaimCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.ClaimCode);                                        // ������R�[�h
                    paraClaimName.Value = SqlDataMediator.SqlSetString(depsitMainWork.ClaimName);                                       // �����於��
                    paraClaimName2.Value = SqlDataMediator.SqlSetString(depsitMainWork.ClaimName2);                                     // �����於��2
                    paraClaimSnm.Value = SqlDataMediator.SqlSetString(depsitMainWork.ClaimSnm);                                         // �����旪��
                    paraOutline.Value = SqlDataMediator.SqlSetString(depsitMainWork.Outline);                                           // �`�[�E�v
                    paraBankCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.BankCode);                                          // ��s�R�[�h
                    paraBankName.Value = SqlDataMediator.SqlSetString(depsitMainWork.BankName);                                         // ��s����
                    # endregion
                }

                int count = sqlCommand.ExecuteNonQuery();

                if (count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                }
                //--- ADD 2008/04/25 M.Kubota ---<<<

                # region --- DEL 2008/04/25 M.Kubota ---
                # if false
                // �ύX�ӏ����傫������̂ł�����폜
                if (mode_new == true)
                {
                    // �� 20070124 18322 c MA.NS�p�ɕύX
                    #region SF �����}�X�^INSERT���i�R�����g�A�E�g�j
                    ////�V�K�쐬����SQL���𐶐�
                    //updateText = "INSERT INTO DEPSITMAINRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DEPOSITDEBITNOTECDRF, DEPOSITSLIPNORF, DEPOSITKINDCODERF, CUSTOMERCODERF, DEPOSITCDRF, DEPOSITTOTALRF, OUTLINERF, ACCEPTANORDERSALESNORF, INPUTDEPOSITSECCDRF, DEPOSITDATERF, ADDUPSECCODERF, ADDUPADATERF, UPDATESECCDRF, DEPOSITKINDNAMERF, DEPOSITALLOWANCERF, DEPOSITALWCBLNCERF, DEPOSITAGENTCODERF, DEPOSITKINDDIVCDRF, FEEDEPOSITRF, DISCOUNTDEPOSITRF, CREDITORLOANCDRF, CREDITCOMPANYCODERF, DEPOSITRF, DRAFTDRAWINGDATERF, DRAFTPAYTIMELIMITRF, DEBITNOTELINKDEPONORF, LASTRECONCILEADDUPDTRF, AUTODEPOSITCDRF"
                    //	+ ", ACPODRDEPOSITRF, ACPODRCHARGEDEPOSITRF, ACPODRDISDEPOSITRF, VARIOUSCOSTDEPOSITRF, VARCOSTCHARGEDEPOSITRF, VARCOSTDISDEPOSITRF, ACPODRDEPOSITALWCRF, ACPODRDEPOALWCBLNCERF, VARCOSTDEPOALWCRF, VARCOSTDEPOALWCBLNCERF" // 20060220 Ins
                    //	+ ") VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @DEPOSITDEBITNOTECD, @DEPOSITSLIPNO, @DEPOSITKINDCODE, @CUSTOMERCODE, @DEPOSITCD, @DEPOSITTOTAL, @OUTLINE, @ACCEPTANORDERSALESNO, @INPUTDEPOSITSECCD, @DEPOSITDATE, @ADDUPSECCODE, @ADDUPADATE, @UPDATESECCD, @DEPOSITKINDNAME, @DEPOSITALLOWANCE, @DEPOSITALWCBLNCE, @DEPOSITAGENTCODE, @DEPOSITKINDDIVCD, @FEEDEPOSIT, @DISCOUNTDEPOSIT, @CREDITORLOANCD, @CREDITCOMPANYCODE, @DEPOSIT, @DRAFTDRAWINGDATE, @DRAFTPAYTIMELIMIT, @DEBITNOTELINKDEPONO, @LASTRECONCILEADDUPDT, @AUTODEPOSITCD"
                    //	+ ", @ACPODRDEPOSIT, @ACPODRCHARGEDEPOSIT, @ACPODRDISDEPOSIT, @VARIOUSCOSTDEPOSIT, @VARCOSTCHARGEDEPOSIT, @VARCOSTDISDEPOSIT, @ACPODRDEPOSITALWC, @ACPODRDEPOALWCBLNCE, @VARCOSTDEPOALWC, @VARCOSTDEPOALWCBLNCE"	// 20060220 Ins
                    //	+ ")";
                    #endregion

                    #region �����}�X�^INSERT��
                    // �� 2007.10.12 980081 c
                    #region �����C�A�E�g(�R�����g�A�E�g)
                    //updateText = "INSERT INTO DEPSITMAINRF ("
                    //                 + " CREATEDATETIMERF"
                    //                 + ",UPDATEDATETIMERF"
                    //                 + ",ENTERPRISECODERF"
                    //                 + ",FILEHEADERGUIDRF"
                    //                 + ",UPDEMPLOYEECODERF"
                    //                 + ",UPDASSEMBLYID1RF"
                    //                 + ",UPDASSEMBLYID2RF"
                    //                 + ",LOGICALDELETECODERF"
                    //                 + ",DEPOSITDEBITNOTECDRF"
                    //                 + ",DEPOSITSLIPNORF"
                    //                 + ",ACCEPTANORDERNORF"
                    //                 + ",SERVICESLIPCDRF"
                    //                 + ",INPUTDEPOSITSECCDRF"
                    //                 + ",ADDUPSECCODERF"
                    //                 + ",UPDATESECCDRF"
                    //                 + ",DEPOSITDATERF"
                    //                 + ",ADDUPADATERF"
                    //                 + ",DEPOSITKINDCODERF"
                    //                 + ",DEPOSITKINDNAMERF"
                    //                 + ",DEPOSITKINDDIVCDRF"
                    //                 + ",DEPOSITTOTALRF"
                    //                 + ",DEPOSITRF"
                    //                 + ",FEEDEPOSITRF"
                    //                 + ",DISCOUNTDEPOSITRF"
                    //                 + ",REBATEDEPOSITRF"
                    //                 + ",AUTODEPOSITCDRF"
                    //                 + ",DEPOSITCDRF"
                    //                 + ",CREDITORLOANCDRF"
                    //                 + ",CREDITCOMPANYCODERF"
                    //                 + ",DRAFTDRAWINGDATERF"
                    //                 + ",DRAFTPAYTIMELIMITRF"
                    //                 + ",DEPOSITALLOWANCERF"
                    //                 + ",DEPOSITALWCBLNCERF"
                    //                 + ",DEBITNOTELINKDEPONORF"
                    //                 + ",LASTRECONCILEADDUPDTRF"
                    //                 + ",DEPOSITAGENTCODERF"
                    //                 + ",DEPOSITAGENTNMRF"
                    //                 + ",CUSTOMERCODERF"
                    //                 + ",CUSTOMERNAMERF"
                    //                 + ",CUSTOMERNAME2RF"
                    //                 + ",OUTLINERF"
                    //           + ") VALUES ("
                    //                 + " @CREATEDATETIME"
                    //                 + ",@UPDATEDATETIME"
                    //                 + ",@ENTERPRISECODE"
                    //                 + ",@FILEHEADERGUID"
                    //                 + ",@UPDEMPLOYEECODE"
                    //                 + ",@UPDASSEMBLYID1"
                    //                 + ",@UPDASSEMBLYID2"
                    //                 + ",@LOGICALDELETECODE"
                    //                 + ",@DEPOSITDEBITNOTECD"
                    //                 + ",@DEPOSITSLIPNO"
                    //                 + ",@ACCEPTANORDERNO"
                    //                 + ",@SERVICESLIPCD"
                    //                 + ",@INPUTDEPOSITSECCD"
                    //                 + ",@ADDUPSECCODE"
                    //                 + ",@UPDATESECCD"
                    //                 + ",@DEPOSITDATE"
                    //                 + ",@ADDUPADATE"
                    //                 + ",@DEPOSITKINDCODE"
                    //                 + ",@DEPOSITKINDNAME"
                    //                 + ",@DEPOSITKINDDIVCD"
                    //                 + ",@DEPOSITTOTAL"
                    //                 + ",@DEPOSIT"
                    //                 + ",@FEEDEPOSIT"
                    //                 + ",@DISCOUNTDEPOSIT"
                    //                 + ",@REBATEDEPOSIT"
                    //                 + ",@AUTODEPOSITCD"
                    //                 + ",@DEPOSITCD"
                    //                 + ",@CREDITORLOANCD"
                    //                 + ",@CREDITCOMPANYCODE"
                    //                 + ",@DRAFTDRAWINGDATE"
                    //                 + ",@DRAFTPAYTIMELIMIT"
                    //                 + ",@DEPOSITALLOWANCE"
                    //                 + ",@DEPOSITALWCBLNCE"
                    //                 + ",@DEBITNOTELINKDEPONO"
                    //                 + ",@LASTRECONCILEADDUPDT"
                    //                 + ",@DEPOSITAGENTCODE"
                    //                 + ",@DEPOSITAGENTNM"
                    //                 + ",@CUSTOMERCODE"
                    //                 + ",@CUSTOMERNAME"
                    //                 + ",@CUSTOMERNAME2"
                    //                 + ",@OUTLINE"
                    //           + ")";
                    #endregion
                    updateText = "INSERT INTO DEPSITMAINRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACPTANODRSTATUSRF, DEPOSITDEBITNOTECDRF, DEPOSITSLIPNORF, SALESSLIPNUMRF, INPUTDEPOSITSECCDRF, ADDUPSECCODERF, UPDATESECCDRF, SUBSECTIONCODERF, MINSECTIONCODERF, DEPOSITDATERF, ADDUPADATERF, DEPOSITKINDCODERF, DEPOSITKINDNAMERF, DEPOSITKINDDIVCDRF, DEPOSITTOTALRF, DEPOSITRF, FEEDEPOSITRF, DISCOUNTDEPOSITRF, AUTODEPOSITCDRF, DEPOSITCDRF, DRAFTDRAWINGDATERF, DRAFTPAYTIMELIMITRF, DRAFTKINDRF, DRAFTKINDNAMERF, DRAFTDIVIDERF, DRAFTDIVIDENAMERF, DRAFTNORF, DEPOSITALLOWANCERF, DEPOSITALWCBLNCERF, DEBITNOTELINKDEPONORF, LASTRECONCILEADDUPDTRF, DEPOSITAGENTCODERF, DEPOSITAGENTNMRF, DEPOSITINPUTAGENTCDRF, DEPOSITINPUTAGENTNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, CLAIMCODERF, CLAIMNAMERF, CLAIMNAME2RF, CLAIMSNMRF, OUTLINERF, BANKCODERF, BANKNAMERF, EDISENDDATERF, EDITAKEINDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACPTANODRSTATUS, @DEPOSITDEBITNOTECD, @DEPOSITSLIPNO, @SALESSLIPNUM, @INPUTDEPOSITSECCD, @ADDUPSECCODE, @UPDATESECCD, @SUBSECTIONCODE, @MINSECTIONCODE, @DEPOSITDATE, @ADDUPADATE, @DEPOSITKINDCODE, @DEPOSITKINDNAME, @DEPOSITKINDDIVCD, @DEPOSITTOTAL, @DEPOSIT, @FEEDEPOSIT, @DISCOUNTDEPOSIT, @AUTODEPOSITCD, @DEPOSITCD, @DRAFTDRAWINGDATE, @DRAFTPAYTIMELIMIT, @DRAFTKIND, @DRAFTKINDNAME, @DRAFTDIVIDE, @DRAFTDIVIDENAME, @DRAFTNO, @DEPOSITALLOWANCE, @DEPOSITALWCBLNCE, @DEBITNOTELINKDEPONO, @LASTRECONCILEADDUPDT, @DEPOSITAGENTCODE, @DEPOSITAGENTNM, @DEPOSITINPUTAGENTCD, @DEPOSITINPUTAGENTNM, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERNAME2, @CUSTOMERSNM, @CLAIMCODE, @CLAIMNAME, @CLAIMNAME2, @CLAIMSNM, @OUTLINE, @BANKCODE, @BANKNAME, @EDISENDDATE, @EDITAKEINDATE)";
                    // �� 2007.10.12 980081
                    #endregion
                    // �� 20070124 18322 c

                    //�o�^�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)depsitMainWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }
                else
                {
                    if (depsitMainWork.LogicalDeleteCode == 0)		// �_���폜�敪�������Ă��Ȃ��ꍇ�͒ʏ�X�V���s
                    {
                        // �� 20070124 18322 c MA.NS�p�ɕύX
                        #region SF �����}�X�^ UPDATE���i�S�ăR�����g�A�E�g�j
                        //// �X�V�����X�V�����L�[�ɕt�����čX�V�i���t�r�������j
                        //updateText = "UPDATE DEPSITMAINRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , DEPOSITDEBITNOTECDRF=@DEPOSITDEBITNOTECD , DEPOSITSLIPNORF=@DEPOSITSLIPNO , DEPOSITKINDCODERF=@DEPOSITKINDCODE , CUSTOMERCODERF=@CUSTOMERCODE , DEPOSITCDRF=@DEPOSITCD , DEPOSITTOTALRF=@DEPOSITTOTAL , OUTLINERF=@OUTLINE , ACCEPTANORDERSALESNORF=@ACCEPTANORDERSALESNO , INPUTDEPOSITSECCDRF=@INPUTDEPOSITSECCD , DEPOSITDATERF=@DEPOSITDATE , ADDUPSECCODERF=@ADDUPSECCODE , ADDUPADATERF=@ADDUPADATE , UPDATESECCDRF=@UPDATESECCD , DEPOSITKINDNAMERF=@DEPOSITKINDNAME , DEPOSITALLOWANCERF=@DEPOSITALLOWANCE , DEPOSITALWCBLNCERF=@DEPOSITALWCBLNCE , DEPOSITAGENTCODERF=@DEPOSITAGENTCODE , DEPOSITKINDDIVCDRF=@DEPOSITKINDDIVCD , FEEDEPOSITRF=@FEEDEPOSIT , DISCOUNTDEPOSITRF=@DISCOUNTDEPOSIT , CREDITORLOANCDRF=@CREDITORLOANCD , CREDITCOMPANYCODERF=@CREDITCOMPANYCODE , DEPOSITRF=@DEPOSIT , DRAFTDRAWINGDATERF=@DRAFTDRAWINGDATE , DRAFTPAYTIMELIMITRF=@DRAFTPAYTIMELIMIT , DEBITNOTELINKDEPONORF=@DEBITNOTELINKDEPONO , LASTRECONCILEADDUPDTRF=@LASTRECONCILEADDUPDT, AUTODEPOSITCDRF=@AUTODEPOSITCD "
                        //	+", ACPODRDEPOSITRF=@ACPODRDEPOSIT , ACPODRCHARGEDEPOSITRF=@ACPODRCHARGEDEPOSIT , ACPODRDISDEPOSITRF=@ACPODRDISDEPOSIT , VARIOUSCOSTDEPOSITRF=@VARIOUSCOSTDEPOSIT , VARCOSTCHARGEDEPOSITRF=@VARCOSTCHARGEDEPOSIT , VARCOSTDISDEPOSITRF=@VARCOSTDISDEPOSIT , ACPODRDEPOSITALWCRF=@ACPODRDEPOSITALWC , ACPODRDEPOALWCBLNCERF=@ACPODRDEPOALWCBLNCE , VARCOSTDEPOALWCRF=@VARCOSTDEPOALWC , VARCOSTDEPOALWCBLNCERF=@VARCOSTDEPOALWCBLNCE " // 20060220 Ins
                        //	+"WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO";
                        #endregion

                        #region �����}�X�^ UPDATE��
                        // �X�V�����X�V�����L�[�ɕt�����čX�V�i���t�r�������j
                        // �� 2007.10.12 980081 d
                        #region �����C�A�E�g(�R�����g�A�E�g)
                        //updateText = "UPDATE DEPSITMAINRF"
                        //             + " SET UPDATEDATETIMERF=@UPDATEDATETIME"
                        //             +     ",ENTERPRISECODERF=@ENTERPRISECODE"
                        //             +     ",FILEHEADERGUIDRF=@FILEHEADERGUID"
                        //             +     ",UPDEMPLOYEECODERF=@UPDEMPLOYEECODE"
                        //             +     ",UPDASSEMBLYID1RF=@UPDASSEMBLYID1"
                        //             +     ",UPDASSEMBLYID2RF=@UPDASSEMBLYID2"
                        //             +     ",LOGICALDELETECODERF=@LOGICALDELETECODE"
                        //             +     ",DEPOSITDEBITNOTECDRF=@DEPOSITDEBITNOTECD"
                        //             +     ",DEPOSITSLIPNORF=@DEPOSITSLIPNO"
                        //             +     ",ACCEPTANORDERNORF=@ACCEPTANORDERNO"
                        //             +     ",SERVICESLIPCDRF=@SERVICESLIPCD"
                        //             +     ",INPUTDEPOSITSECCDRF=@INPUTDEPOSITSECCD"
                        //             +     ",ADDUPSECCODERF=@ADDUPSECCODE"
                        //             +     ",UPDATESECCDRF=@UPDATESECCD"
                        //             +     ",DEPOSITDATERF=@DEPOSITDATE"
                        //             +     ",ADDUPADATERF=@ADDUPADATE"
                        //             +     ",DEPOSITKINDCODERF=@DEPOSITKINDCODE"
                        //             +     ",DEPOSITKINDNAMERF=@DEPOSITKINDNAME"
                        //             +     ",DEPOSITKINDDIVCDRF=@DEPOSITKINDDIVCD"
                        //             +     ",DEPOSITTOTALRF=@DEPOSITTOTAL"
                        //             +     ",DEPOSITRF=@DEPOSIT"
                        //             +     ",FEEDEPOSITRF=@FEEDEPOSIT"
                        //             +     ",DISCOUNTDEPOSITRF=@DISCOUNTDEPOSIT"
                        //             +     ",REBATEDEPOSITRF=@REBATEDEPOSIT"
                        //             +     ",AUTODEPOSITCDRF=@AUTODEPOSITCD"
                        //             +     ",DEPOSITCDRF=@DEPOSITCD"
                        //             +     ",CREDITORLOANCDRF=@CREDITORLOANCD"
                        //             +     ",CREDITCOMPANYCODERF=@CREDITCOMPANYCODE"
                        //             +     ",DRAFTDRAWINGDATERF=@DRAFTDRAWINGDATE"
                        //             +     ",DRAFTPAYTIMELIMITRF=@DRAFTPAYTIMELIMIT"
                        //             +     ",DEPOSITALLOWANCERF=@DEPOSITALLOWANCE"
                        //             +     ",DEPOSITALWCBLNCERF=@DEPOSITALWCBLNCE"
                        //             +     ",DEBITNOTELINKDEPONORF=@DEBITNOTELINKDEPONO"
                        //             +     ",LASTRECONCILEADDUPDTRF=@LASTRECONCILEADDUPDT"
                        //             +     ",DEPOSITAGENTCODERF=@DEPOSITAGENTCODE"
                        //             +     ",DEPOSITAGENTNMRF=@DEPOSITAGENTNM"
                        //             +     ",CUSTOMERCODERF=@CUSTOMERCODE"
                        //             +     ",CUSTOMERNAMERF=@CUSTOMERNAME"
                        //             +     ",CUSTOMERNAME2RF=@CUSTOMERNAME2"
                        //             +     ",OUTLINERF=@OUTLINE"
                        //           + " WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME"
                        //             + " AND ENTERPRISECODERF=@FINDENTERPRISECODE"
                        //             + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                        //             ;
                        #endregion
                        updateText = "UPDATE DEPSITMAINRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , ACPTANODRSTATUSRF=@ACPTANODRSTATUS , DEPOSITDEBITNOTECDRF=@DEPOSITDEBITNOTECD , DEPOSITSLIPNORF=@DEPOSITSLIPNO , SALESSLIPNUMRF=@SALESSLIPNUM , INPUTDEPOSITSECCDRF=@INPUTDEPOSITSECCD , ADDUPSECCODERF=@ADDUPSECCODE , UPDATESECCDRF=@UPDATESECCD , SUBSECTIONCODERF=@SUBSECTIONCODE , MINSECTIONCODERF=@MINSECTIONCODE , DEPOSITDATERF=@DEPOSITDATE , ADDUPADATERF=@ADDUPADATE , DEPOSITKINDCODERF=@DEPOSITKINDCODE , DEPOSITKINDNAMERF=@DEPOSITKINDNAME , DEPOSITKINDDIVCDRF=@DEPOSITKINDDIVCD , DEPOSITTOTALRF=@DEPOSITTOTAL , DEPOSITRF=@DEPOSIT , FEEDEPOSITRF=@FEEDEPOSIT , DISCOUNTDEPOSITRF=@DISCOUNTDEPOSIT , AUTODEPOSITCDRF=@AUTODEPOSITCD , DEPOSITCDRF=@DEPOSITCD , DRAFTDRAWINGDATERF=@DRAFTDRAWINGDATE , DRAFTPAYTIMELIMITRF=@DRAFTPAYTIMELIMIT , DRAFTKINDRF=@DRAFTKIND , DRAFTKINDNAMERF=@DRAFTKINDNAME , DRAFTDIVIDERF=@DRAFTDIVIDE , DRAFTDIVIDENAMERF=@DRAFTDIVIDENAME , DRAFTNORF=@DRAFTNO , DEPOSITALLOWANCERF=@DEPOSITALLOWANCE , DEPOSITALWCBLNCERF=@DEPOSITALWCBLNCE , DEBITNOTELINKDEPONORF=@DEBITNOTELINKDEPONO , LASTRECONCILEADDUPDTRF=@LASTRECONCILEADDUPDT , DEPOSITAGENTCODERF=@DEPOSITAGENTCODE , DEPOSITAGENTNMRF=@DEPOSITAGENTNM , DEPOSITINPUTAGENTCDRF=@DEPOSITINPUTAGENTCD , DEPOSITINPUTAGENTNMRF=@DEPOSITINPUTAGENTNM , CUSTOMERCODERF=@CUSTOMERCODE , CUSTOMERNAMERF=@CUSTOMERNAME , CUSTOMERNAME2RF=@CUSTOMERNAME2 , CUSTOMERSNMRF=@CUSTOMERSNM , CLAIMCODERF=@CLAIMCODE , CLAIMNAMERF=@CLAIMNAME , CLAIMNAME2RF=@CLAIMNAME2 , CLAIMSNMRF=@CLAIMSNM , OUTLINERF=@OUTLINE , BANKCODERF=@BANKCODE , BANKNAMERF=@BANKNAME , EDISENDDATERF=@EDISENDDATE , EDITAKEINDATERF=@EDITAKEINDATE"
                                   + " WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME"
                                     + " AND ENTERPRISECODERF=@FINDENTERPRISECODE"
                                     + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                                     ;
                        // �� 2007.10.12 980081 d
                        #endregion
                        // �� 20070124 18322 c

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)depsitMainWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);

                    }
                    else											// �_���폜�敪�������Ă���ꍇ�͍폜�������s
                    {
                        // �X�V�����X�V�����L�[�ɕt�����č폜�i���t�r�������j
                        updateText = "DELETE DEPSITMAINRF "
                            + "WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO";
                    }

                }

                using (SqlCommand sqlCommand = new SqlCommand(updateText, sqlConnection, sqlTransaction))
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaUpdateDateTime = sqlCommand.Parameters.Add("@FINDUPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(Upd_UpdateDateTime);
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.EnterpriseCode);
                    findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositSlipNo);

                    // �� 200701224 18322 c MA.NS�p�ɕύX
                    #region SF Parameter�I�u�W�F�N�g�ݒ�i�S�ăR�����g�A�E�g�j
                    //#region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    ////Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    //SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    //SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    //SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    //SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    //SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    //SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    //SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    //SqlParameter paraDepositDebitNoteCd = sqlCommand.Parameters.Add("@DEPOSITDEBITNOTECD", SqlDbType.Int);
                    //SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                    //SqlParameter paraDepositKindCode = sqlCommand.Parameters.Add("@DEPOSITKINDCODE", SqlDbType.Int);
                    //SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    //SqlParameter paraDepositCd = sqlCommand.Parameters.Add("@DEPOSITCD", SqlDbType.Int);
                    //SqlParameter paraDepositTotal = sqlCommand.Parameters.Add("@DEPOSITTOTAL", SqlDbType.BigInt);
                    //SqlParameter paraOutline = sqlCommand.Parameters.Add("@OUTLINE", SqlDbType.NVarChar);
                    //SqlParameter paraAcceptAnOrderSalesNo = sqlCommand.Parameters.Add("@ACCEPTANORDERSALESNO", SqlDbType.Int);
                    //SqlParameter paraInputDepositSecCd = sqlCommand.Parameters.Add("@INPUTDEPOSITSECCD", SqlDbType.NChar);
                    //SqlParameter paraDepositDate = sqlCommand.Parameters.Add("@DEPOSITDATE", SqlDbType.Int);
                    //SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    //SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                    //SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                    //SqlParameter paraDepositKindName = sqlCommand.Parameters.Add("@DEPOSITKINDNAME", SqlDbType.NVarChar);
                    //SqlParameter paraDepositAllowance = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE", SqlDbType.BigInt);
                    //SqlParameter paraDepositAlwcBlnce = sqlCommand.Parameters.Add("@DEPOSITALWCBLNCE", SqlDbType.BigInt);
                    //SqlParameter paraDepositAgentCode = sqlCommand.Parameters.Add("@DEPOSITAGENTCODE", SqlDbType.NChar);
                    //SqlParameter paraDepositKindDivCd = sqlCommand.Parameters.Add("@DEPOSITKINDDIVCD", SqlDbType.Int);
                    //SqlParameter paraFeeDeposit = sqlCommand.Parameters.Add("@FEEDEPOSIT", SqlDbType.BigInt);
                    //SqlParameter paraDiscountDeposit = sqlCommand.Parameters.Add("@DISCOUNTDEPOSIT", SqlDbType.BigInt);
                    //SqlParameter paraCreditOrLoanCd = sqlCommand.Parameters.Add("@CREDITORLOANCD", SqlDbType.Int);
                    //SqlParameter paraCreditCompanyCode = sqlCommand.Parameters.Add("@CREDITCOMPANYCODE", SqlDbType.NChar);
                    //SqlParameter paraDeposit = sqlCommand.Parameters.Add("@DEPOSIT", SqlDbType.BigInt);
                    //SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                    //SqlParameter paraDraftPayTimeLimit = sqlCommand.Parameters.Add("@DRAFTPAYTIMELIMIT", SqlDbType.Int);
                    //SqlParameter paraDebitNoteLinkDepoNo = sqlCommand.Parameters.Add("@DEBITNOTELINKDEPONO", SqlDbType.Int);
                    //SqlParameter paraLastReconcileAddUpDt = sqlCommand.Parameters.Add("@LASTRECONCILEADDUPDT", SqlDbType.Int);
                    //SqlParameter parAutoDepositCd = sqlCommand.Parameters.Add("@AUTODEPOSITCD", SqlDbType.Int);
                    //// 20060217 Ins Start >>>>>>>>>>>>>>>>>
                    //SqlParameter paraAcpOdrDeposit = sqlCommand.Parameters.Add("@ACPODRDEPOSIT", SqlDbType.BigInt);
                    //SqlParameter paraAcpOdrChargeDeposit = sqlCommand.Parameters.Add("@ACPODRCHARGEDEPOSIT", SqlDbType.BigInt);
                    //SqlParameter paraAcpOdrDisDeposit = sqlCommand.Parameters.Add("@ACPODRDISDEPOSIT", SqlDbType.BigInt);
                    //SqlParameter paraVariousCostDeposit = sqlCommand.Parameters.Add("@VARIOUSCOSTDEPOSIT", SqlDbType.BigInt);
                    //SqlParameter paraVarCostChargeDeposit = sqlCommand.Parameters.Add("@VARCOSTCHARGEDEPOSIT", SqlDbType.BigInt);
                    //SqlParameter paraVarCostDisDeposit = sqlCommand.Parameters.Add("@VARCOSTDISDEPOSIT", SqlDbType.BigInt);
                    //SqlParameter paraAcpOdrDepositAlwc = sqlCommand.Parameters.Add("@ACPODRDEPOSITALWC", SqlDbType.BigInt);
                    //SqlParameter paraAcpOdrDepoAlwcBlnce = sqlCommand.Parameters.Add("@ACPODRDEPOALWCBLNCE", SqlDbType.BigInt);
                    //SqlParameter paraVarCostDepoAlwc = sqlCommand.Parameters.Add("@VARCOSTDEPOALWC", SqlDbType.BigInt);
                    //SqlParameter paraVarCostDepoAlwcBlnce = sqlCommand.Parameters.Add("@VARCOSTDEPOALWCBLNCE", SqlDbType.BigInt);
                    //// 20060217 Ins End <<<<<<<<<<<<<<<<<<<
                    //#endregion
                    //
                    //#region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    //paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitMainWork.CreateDateTime);
                    //paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitMainWork.UpdateDateTime);
                    //paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.EnterpriseCode);
                    //paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depsitMainWork.FileHeaderGuid);
                    //paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdEmployeeCode);
                    //paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdAssemblyId1);
                    //paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdAssemblyId2);
                    //paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.LogicalDeleteCode);
                    //paraDepositDebitNoteCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositDebitNoteCd);
                    //paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositSlipNo);
                    //paraDepositKindCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositKindCode);
                    //paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.CustomerCode);
                    //paraDepositCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositCd);
                    //paraDepositTotal.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositTotal);
                    //paraOutline.Value = SqlDataMediator.SqlSetString(depsitMainWork.Outline);
                    //paraAcceptAnOrderSalesNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.AcceptAnOrderSalesNo);
                    //paraInputDepositSecCd.Value = SqlDataMediator.SqlSetString(depsitMainWork.InputDepositSecCd);
                    //paraDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.DepositDate);
                    //paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.AddUpSecCode);
                    //paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.AddUpADate);
                    //paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdateSecCd);
                    //paraDepositKindName.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositKindName);
                    //paraDepositAllowance.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositAllowance);
                    //paraDepositAlwcBlnce.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositAlwcBlnce);
                    //paraDepositAgentCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositAgentCode);
                    //paraDepositKindDivCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositKindDivCd);
                    //paraFeeDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.FeeDeposit);
                    //paraDiscountDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DiscountDeposit);
                    //paraCreditOrLoanCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.CreditOrLoanCd);
                    //paraCreditCompanyCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.CreditCompanyCode);
                    //paraDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.Deposit);
                    //paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.DraftDrawingDate);
                    //paraDraftPayTimeLimit.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.DraftPayTimeLimit);
                    //paraDebitNoteLinkDepoNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DebitNoteLinkDepoNo);
                    //paraLastReconcileAddUpDt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.LastReconcileAddUpDt);
                    //parAutoDepositCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.AutoDepositCd);
                    //// 20060217 Ins Start >>>>>>>>>>>>>>>>>
                    //paraAcpOdrDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.AcpOdrDeposit);
                    //paraAcpOdrChargeDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.AcpOdrChargeDeposit);
                    //paraAcpOdrDisDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.AcpOdrDisDeposit);
                    //paraVariousCostDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.VariousCostDeposit);
                    //paraVarCostChargeDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.VarCostChargeDeposit);
                    //paraVarCostDisDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.VarCostDisDeposit);
                    //paraAcpOdrDepositAlwc.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.AcpOdrDepositAlwc);
                    //paraAcpOdrDepoAlwcBlnce.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.AcpOdrDepoAlwcBlnce);
                    //paraVarCostDepoAlwc.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.VarCostDepoAlwc);
                    //paraVarCostDepoAlwcBlnce.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.VarCostDepoAlwcBlnce);
                    //// 20060217 Ins End <<<<<<<<<<<<<<<<<<<
                    //#endregion
                    #endregion

                    #region �����}�X�^ Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    // �쐬����
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    // �X�V����
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    // ��ƃR�[�h
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    // GUID
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    // �X�V�]�ƈ��R�[�h
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    // �X�V�A�Z���u��ID1
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    // �X�V�A�Z���u��ID2
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    // �_���폜�敪
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    // �����ԍ��敪
                    SqlParameter paraDepositDebitNoteCd = sqlCommand.Parameters.Add("@DEPOSITDEBITNOTECD", SqlDbType.Int);
                    // �����`�[�ԍ�
                    SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                    // �� 2007.10.12 980081 a
                    //// �󒍔ԍ�
                    //SqlParameter paraAcceptAnOrderNo       = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
                    //// �T�[�r�X�`�[�敪
                    //SqlParameter paraServiceSlipCd         = sqlCommand.Parameters.Add("@SERVICESLIPCD", SqlDbType.Int);
                    // �� 2007.10.12 980081 a
                    // �������͋��_�R�[�h
                    SqlParameter paraInputDepositSecCd = sqlCommand.Parameters.Add("@INPUTDEPOSITSECCD", SqlDbType.NChar);
                    // �v�㋒�_�R�[�h
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    // �X�V���_�R�[�h
                    SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                    // �������t
                    SqlParameter paraDepositDate = sqlCommand.Parameters.Add("@DEPOSITDATE", SqlDbType.Int);
                    // �v����t
                    SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                    // ��������R�[�h
                    SqlParameter paraDepositKindCode = sqlCommand.Parameters.Add("@DEPOSITKINDCODE", SqlDbType.Int);
                    // �������햼��
                    SqlParameter paraDepositKindName = sqlCommand.Parameters.Add("@DEPOSITKINDNAME", SqlDbType.NVarChar);
                    // ��������敪
                    SqlParameter paraDepositKindDivCd = sqlCommand.Parameters.Add("@DEPOSITKINDDIVCD", SqlDbType.Int);
                    // �����v
                    SqlParameter paraDepositTotal = sqlCommand.Parameters.Add("@DEPOSITTOTAL", SqlDbType.BigInt);
                    // �������z
                    SqlParameter paraDeposit = sqlCommand.Parameters.Add("@DEPOSIT", SqlDbType.BigInt);
                    // �萔�������z
                    SqlParameter paraFeeDeposit = sqlCommand.Parameters.Add("@FEEDEPOSIT", SqlDbType.BigInt);
                    // �l�������z
                    SqlParameter paraDiscountDeposit = sqlCommand.Parameters.Add("@DISCOUNTDEPOSIT", SqlDbType.BigInt);
                    // �� 2007.10.12 980081 d
                    //// ���x�[�g�����z
                    //SqlParameter paraRebateDeposit         = sqlCommand.Parameters.Add("@REBATEDEPOSIT", SqlDbType.BigInt);
                    // �� 2007.10.12 980081 d
                    // ���������敪
                    SqlParameter paraAutoDepositCd = sqlCommand.Parameters.Add("@AUTODEPOSITCD", SqlDbType.Int);
                    // �a����敪
                    SqlParameter paraDepositCd = sqlCommand.Parameters.Add("@DEPOSITCD", SqlDbType.Int);
                    // �� 2007.10.12 980081 d
                    //// �N���W�b�g�^���[���敪
                    //SqlParameter paraCreditOrLoanCd        = sqlCommand.Parameters.Add("@CREDITORLOANCD", SqlDbType.Int);
                    //// �N���W�b�g��ЃR�[�h
                    //SqlParameter paraCreditCompanyCode     = sqlCommand.Parameters.Add("@CREDITCOMPANYCODE", SqlDbType.NChar);
                    // �� 2007.10.12 980081 d
                    // ��`�U�o��
                    SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                    // ��`�x������
                    SqlParameter paraDraftPayTimeLimit = sqlCommand.Parameters.Add("@DRAFTPAYTIMELIMIT", SqlDbType.Int);
                    // ���������z
                    SqlParameter paraDepositAllowance = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE", SqlDbType.BigInt);
                    // ���������c��
                    SqlParameter paraDepositAlwcBlnce = sqlCommand.Parameters.Add("@DEPOSITALWCBLNCE", SqlDbType.BigInt);
                    // �ԍ������A���ԍ�
                    SqlParameter paraDebitNoteLinkDepoNo = sqlCommand.Parameters.Add("@DEBITNOTELINKDEPONO", SqlDbType.Int);
                    // �ŏI�������݌v���
                    SqlParameter paraLastReconcileAddUpDt = sqlCommand.Parameters.Add("@LASTRECONCILEADDUPDT", SqlDbType.Int);
                    // �����S���҃R�[�h
                    SqlParameter paraDepositAgentCode = sqlCommand.Parameters.Add("@DEPOSITAGENTCODE", SqlDbType.NChar);
                    // �����S���Җ���
                    SqlParameter paraDepositAgentNm = sqlCommand.Parameters.Add("@DEPOSITAGENTNM", SqlDbType.NVarChar);
                    // ���Ӑ�R�[�h
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    // ���Ӑ於��
                    SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                    // ���Ӑ於��2
                    SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                    // �`�[�E�v
                    SqlParameter paraOutline = sqlCommand.Parameters.Add("@OUTLINE", SqlDbType.NVarChar);
                    // �� 2007.10.12 980081 a
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                    SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                    SqlParameter paraMinSectionCode = sqlCommand.Parameters.Add("@MINSECTIONCODE", SqlDbType.Int);
                    SqlParameter paraDraftKind = sqlCommand.Parameters.Add("@DRAFTKIND", SqlDbType.Int);
                    SqlParameter paraDraftKindName = sqlCommand.Parameters.Add("@DRAFTKINDNAME", SqlDbType.NChar);
                    SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
                    SqlParameter paraDraftDivideName = sqlCommand.Parameters.Add("@DRAFTDIVIDENAME", SqlDbType.NChar);
                    SqlParameter paraDraftNo = sqlCommand.Parameters.Add("@DRAFTNO", SqlDbType.NChar);
                    SqlParameter paraDepositInputAgentCd = sqlCommand.Parameters.Add("@DEPOSITINPUTAGENTCD", SqlDbType.NChar);
                    SqlParameter paraDepositInputAgentNm = sqlCommand.Parameters.Add("@DEPOSITINPUTAGENTNM", SqlDbType.NVarChar);
                    SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                    SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                    SqlParameter paraClaimName = sqlCommand.Parameters.Add("@CLAIMNAME", SqlDbType.NVarChar);
                    SqlParameter paraClaimName2 = sqlCommand.Parameters.Add("@CLAIMNAME2", SqlDbType.NVarChar);
                    SqlParameter paraClaimSnm = sqlCommand.Parameters.Add("@CLAIMSNM", SqlDbType.NVarChar);
                    SqlParameter paraBankCode = sqlCommand.Parameters.Add("@BANKCODE", SqlDbType.Int);
                    SqlParameter paraBankName = sqlCommand.Parameters.Add("@BANKNAME", SqlDbType.NVarChar);
                    SqlParameter paraEdiSendDate = sqlCommand.Parameters.Add("@EDISENDDATE", SqlDbType.Int);
                    SqlParameter paraEdiTakeInDate = sqlCommand.Parameters.Add("@EDITAKEINDATE", SqlDbType.Int);
                    // �� 2007.10.12 980081 a
                    #endregion

                    #region �����}�X�^ Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    // �쐬����
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitMainWork.CreateDateTime);
                    // �X�V����
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitMainWork.UpdateDateTime);
                    // ��ƃR�[�h
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.EnterpriseCode);
                    // GUID
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depsitMainWork.FileHeaderGuid);
                    // �X�V�]�ƈ��R�[�h
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdEmployeeCode);
                    // �X�V�A�Z���u��ID1
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdAssemblyId1);
                    // �X�V�A�Z���u��ID2
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdAssemblyId2);
                    // �_���폜�敪
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.LogicalDeleteCode);
                    // �����ԍ��敪
                    paraDepositDebitNoteCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositDebitNoteCd);
                    // �����`�[�ԍ�
                    paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositSlipNo);
                    // �� 2007.10.12 980081 d
                    //// �󒍔ԍ�
                    //paraAcceptAnOrderNo.Value      = SqlDataMediator.SqlSetInt32(depsitMainWork.AcceptAnOrderNo);
                    //// �T�[�r�X�`�[�敪
                    //paraServiceSlipCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.ServiceSlipCd);
                    // �� 2007.10.12 980081 d
                    // �������͋��_�R�[�h
                    paraInputDepositSecCd.Value = SqlDataMediator.SqlSetString(depsitMainWork.InputDepositSecCd);
                    // �v�㋒�_�R�[�h
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.AddUpSecCode);
                    // �X�V���_�R�[�h
                    paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdateSecCd);
                    // �������t
                    // �� 2008.03.17 980081 c
                    //paraDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.DepositDate);
                    paraDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.Now);
                    // �� 2008.03.17 980081 c
                    // �v����t
                    paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.AddUpADate);
                    // ��������R�[�h
                    paraDepositKindCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositKindCode);
                    // �������햼��
                    paraDepositKindName.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositKindName);
                    // ��������敪
                    paraDepositKindDivCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositKindDivCd);
                    // �����v
                    paraDepositTotal.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositTotal);
                    // �������z
                    paraDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.Deposit);
                    // �萔�������z
                    paraFeeDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.FeeDeposit);
                    // �l�������z
                    paraDiscountDeposit.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DiscountDeposit);
                    // �� 2007.10.12 980081 d
                    //// ���x�[�g�����z
                    //paraRebateDeposit.Value        = SqlDataMediator.SqlSetInt64(depsitMainWork.RebateDeposit);
                    // �� 2007.10.12 980081 d
                    // ���������敪
                    paraAutoDepositCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.AutoDepositCd);
                    // �a����敪
                    paraDepositCd.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositCd);
                    // �� 2007.10.12 980081 d
                    //// �N���W�b�g�^���[���敪
                    //paraCreditOrLoanCd.Value       = SqlDataMediator.SqlSetInt32(depsitMainWork.CreditOrLoanCd);
                    //// �N���W�b�g��ЃR�[�h
                    //paraCreditCompanyCode.Value    = SqlDataMediator.SqlSetString(depsitMainWork.CreditCompanyCode);
                    // �� 2007.10.12 980081 d
                    // ��`�U�o��
                    paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.DraftDrawingDate);
                    // ��`�x������
                    paraDraftPayTimeLimit.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.DraftPayTimeLimit);
                    // ���������z
                    paraDepositAllowance.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositAllowance);
                    // ���������c��
                    paraDepositAlwcBlnce.Value = SqlDataMediator.SqlSetInt64(depsitMainWork.DepositAlwcBlnce);
                    // �ԍ������A���ԍ�
                    paraDebitNoteLinkDepoNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DebitNoteLinkDepoNo);
                    // �ŏI�������݌v���
                    paraLastReconcileAddUpDt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.LastReconcileAddUpDt);
                    // �����S���҃R�[�h
                    paraDepositAgentCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositAgentCode);
                    // �����S���Җ���
                    paraDepositAgentNm.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositAgentNm);
                    // ���Ӑ�R�[�h
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.CustomerCode);
                    // ���Ӑ於��
                    paraCustomerName.Value = SqlDataMediator.SqlSetString(depsitMainWork.CustomerName);
                    // ���Ӑ於��2
                    paraCustomerName2.Value = SqlDataMediator.SqlSetString(depsitMainWork.CustomerName2);
                    // �`�[�E�v
                    paraOutline.Value = SqlDataMediator.SqlSetString(depsitMainWork.Outline);
                    // �� 2007.10.12 980081 a
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.AcptAnOdrStatus);
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(depsitMainWork.SalesSlipNum);
                    paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.SubSectionCode);
                    paraMinSectionCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.MinSectionCode);
                    paraDraftKind.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DraftKind);
                    paraDraftKindName.Value = SqlDataMediator.SqlSetString(depsitMainWork.DraftKindName);
                    paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DraftDivide);
                    paraDraftDivideName.Value = SqlDataMediator.SqlSetString(depsitMainWork.DraftDivideName);
                    paraDraftNo.Value = SqlDataMediator.SqlSetString(depsitMainWork.DraftNo);
                    paraDepositInputAgentCd.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositInputAgentCd);
                    paraDepositInputAgentNm.Value = SqlDataMediator.SqlSetString(depsitMainWork.DepositInputAgentNm);
                    paraCustomerSnm.Value = SqlDataMediator.SqlSetString(depsitMainWork.CustomerSnm);
                    paraClaimCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.ClaimCode);
                    paraClaimName.Value = SqlDataMediator.SqlSetString(depsitMainWork.ClaimName);
                    paraClaimName2.Value = SqlDataMediator.SqlSetString(depsitMainWork.ClaimName2);
                    paraClaimSnm.Value = SqlDataMediator.SqlSetString(depsitMainWork.ClaimSnm);
                    paraBankCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.BankCode);
                    paraBankName.Value = SqlDataMediator.SqlSetString(depsitMainWork.BankName);
                    paraEdiSendDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.EdiSendDate);
                    // �� 2007.12.10 980081 c
                    //paraEdiTakeInDate.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.EdiTakeInDate);
                    paraEdiTakeInDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitMainWork.EdiTakeInDate);
                    // �� 2007.12.10 980081 c
                    // �� 2007.10.12 980081 a
                    #endregion
                    // �� 20070124 18322 c

                    int count = sqlCommand.ExecuteNonQuery();

                    // �X�V�����������ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    if (count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                }
                # endif
                # endregion
            }
            catch (SqlException ex)
            {
                //--- DEL 2008/04/258 M.Kubota --- >>>
                //if (myReader != null && !myReader.IsClosed) myReader.Close();
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);
                //--- DEL 2008/04/25 M.Kubota --- <<<
                //--- ADD 2008/04/25 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/04/25 M.Kubota ---<<<
            }
            //--- ADD 2008/04/25 M.Kubota --->>>
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            //--- ADD 2008/04/25 M.Kubota ---<<<

            //if (myReader != null && !myReader.IsClosed) myReader.Close();  //DEL 2008/04/25 M.Kubota

            return status;
        }

        /// <summary>
        /// ���������}�X�^�����X�V���܂�
        /// </summary>
        /// <param name="depositAlwWork">�����������</param>
        /// <param name="bf_DepositAllowance">�X�V�O�����z</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <param name="dbCommandTimeout">�R�}���h�^�C���A�E�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���������}�X�^���̍X�V���s���܂�</br>
        /// <br>           : �X�V���ɍX�V�O����ǂݍ��݁A�����z�E�a������敪�E�N���W�b�g�敪�̎擾���s���܂�</br>
        /// <br>           : ���X�V�O���͔���f�[�^�X�V���ɕK�v�ƂȂ邽��</br>
        /// <br>Programmer : 18322 T.Kimura </br>
        /// <br>Date       : 2007.01.24</br>
        /// <br>Update Note: 2020/08/28 �c����</br>
        /// <br>             PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br>
        /// </remarks>
        //private int WriteDepositAlwWork(ref DepositAlwWork depositAlwWork, out Int64 bf_DepositAllowance, out int bf_DepositCd, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //DEL 2008/04/25 M.Kubota
        // --- UPD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
        //private int WriteDepositAlwWork(ref DepositAlwWork depositAlwWork, out Int64 bf_DepositAllowance, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2008/04/25 M.Kubota
        private int WriteDepositAlwWork(ref DepositAlwWork depositAlwWork, out Int64 bf_DepositAllowance, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, int dbCommandTimeout)
        // --- UPD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            bf_DepositAllowance = 0;
            //bf_DepositCd = 0;  //DEL 2008/04/25 M.Kubota
            // �� 2007.10.12 980081 d
            //bf_CreditOrLoanCd = 0;
            // �� 2007.10.12 980081 d

            bool deleteSql = false;
            //Select�R�}���h�̐���
            try
            {
                string selectSql = "SELECT UPDATEDATETIMERF"                        // �X�V����
                                 + ", ENTERPRISECODERF"                        // ��ƃR�[�h
                                 + ", DEPOSITALLOWANCERF"                      // ���������z
                    //+ ", DEPOSITCDRF"                             // �a����敪  //DEL 2008/04/25 M.Kubota
                    // �� 2007.10.12 980081 d
                    //+      ", CREDITORLOANCDRF"                        // �N���W�b�g�^���[���敪
                    // �� 2007.10.12 980081 d
                                 + " FROM DEPOSITALWRF"
                                 + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"    // ��ƃR�[�h
                    // �� 2007.10.12 980081 c
                    //+ " AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO"  // �󒍔ԍ�
                                 + " AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS"  // �󒍃X�e�[�^�X
                                 + " AND SALESSLIPNUMRF=@FINDSALESSLIPNUM"        // ����`�[�ԍ�
                    // �� 2007.10.12 980081 c
                                 + " AND CUSTOMERCODERF=@FINDCUSTOMERCODE"        // ���Ӑ�R�[�h
                                 + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"      // �����`�[�ԍ�
                                 + " AND ADDUPSECCODERF=@FINDADDUPSECCODE"        // �v�㋒�_�R�[�h
                                 ;
                using (SqlCommand sqlCommand = new SqlCommand(selectSql, sqlConnection, sqlTransaction))
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    // �� 2007.10.12 980081 c
                    //SqlParameter findParaAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                    SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findParaSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                    // �� 2007.10.12 980081 c
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
                    //                    SqlParameter findParaReconcileDate = sqlCommand.Parameters.Add("@FINDRECONCILEADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
                    // �� 2007.10.12 980081 c
                    //findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
                    findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcptAnOdrStatus);
                    findParaSalesSlipNum.Value = SqlDataMediator.SqlSetString(depositAlwWork.SalesSlipNum);
                    // �� 2007.10.12 980081 c
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
                    findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
                    //                    findParaReconcileDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileDate);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);

                    sqlCommand.CommandTimeout = dbCommandTimeout; // ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή�
                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != depositAlwWork.UpdateDateTime)
                        {
                            //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (depositAlwWork.UpdateDateTime == DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }
                            sqlCommand.Cancel();
                            if (myReader != null && !myReader.IsClosed) myReader.Close();
                            return status;
                        }

                        // �X�V�O�����z�A�X�V�O�a����敪�A�N���W�b�g�敪�擾
                        bf_DepositAllowance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"));        // �����z
                        //bf_DepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITCDRF"));                // �a������敪
                        // �� 2007.10.12 980081 d
                        //bf_CreditOrLoanCd   = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CREDITORLOANCDRF"));        // �N���W�b�g�^���[���敪
                        // �� 2007.10.12 980081 d

                        if (depositAlwWork.LogicalDeleteCode == 0)
                        {
                            // �_���폜�敪�������Ă��Ȃ��ꍇ�͒ʏ�X�V���s
                            # region --- DEL 2008/04/25 M.Kubota --->>>
                            // �� 2007.10.12 980081 c
                            #region �����C�A�E�g(�R�����g�A�E�g)
                            //sqlCommand.CommandText =
                            //         "UPDATE DEPOSITALWRF"
                            //         + " SET UPDATEDATETIMERF=@UPDATEDATETIME"
                            //             + ",ENTERPRISECODERF=@ENTERPRISECODE"
                            //             + ",FILEHEADERGUIDRF=@FILEHEADERGUID"
                            //             + ",UPDEMPLOYEECODERF=@UPDEMPLOYEECODE"
                            //             + ",UPDASSEMBLYID1RF=@UPDASSEMBLYID1"
                            //             + ",UPDASSEMBLYID2RF=@UPDASSEMBLYID2"
                            //             + ",LOGICALDELETECODERF=@LOGICALDELETECODE"
                            //             + ",INPUTDEPOSITSECCDRF=@INPUTDEPOSITSECCD"
                            //             + ",ADDUPSECCODERF=@ADDUPSECCODE"
                            //             + ",RECONCILEDATERF=@RECONCILEDATE"
                            //             + ",RECONCILEADDUPDATERF=@RECONCILEADDUPDATE"
                            //             + ",DEPOSITSLIPNORF=@DEPOSITSLIPNO"
                            //             + ",DEPOSITKINDCODERF=@DEPOSITKINDCODE"
                            //             + ",DEPOSITKINDNAMERF=@DEPOSITKINDNAME"
                            //             + ",DEPOSITALLOWANCERF=@DEPOSITALLOWANCE"
                            //             + ",DEPOSITAGENTCODERF=@DEPOSITAGENTCODE"
                            //             + ",DEPOSITAGENTNMRF=@DEPOSITAGENTNM"
                            //             + ",CUSTOMERCODERF=@CUSTOMERCODE"
                            //             + ",CUSTOMERNAMERF=@CUSTOMERNAME"
                            //             + ",CUSTOMERNAME2RF=@CUSTOMERNAME2"
                            //             + ",ACCEPTANORDERNORF=@ACCEPTANORDERNO"
                            //             + ",SERVICESLIPCDRF=@SERVICESLIPCD"
                            //             + ",DEBITNOTEOFFSETCDRF=@DEBITNOTEOFFSETCD"
                            //             + ",DEPOSITCDRF=@DEPOSITCD"
                            //             + ",CREDITORLOANCDRF=@CREDITORLOANCD"
                            //       + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                            //          + " AND CUSTOMERCODERF=@FINDCUSTOMERCODE"
                            //          + " AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO"
                            //          + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                            //          + " AND ADDUPSECCODERF=@ADDUPSECCODE"
                            //          ;
                            #endregion
                            //sqlCommand.CommandText =
                            //         "UPDATE DEPOSITALWRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , INPUTDEPOSITSECCDRF=@INPUTDEPOSITSECCD , ADDUPSECCODERF=@ADDUPSECCODE , RECONCILEDATERF=@RECONCILEDATE , RECONCILEADDUPDATERF=@RECONCILEADDUPDATE , DEPOSITSLIPNORF=@DEPOSITSLIPNO , DEPOSITKINDCODERF=@DEPOSITKINDCODE , DEPOSITKINDNAMERF=@DEPOSITKINDNAME , DEPOSITALLOWANCERF=@DEPOSITALLOWANCE , DEPOSITAGENTCODERF=@DEPOSITAGENTCODE , DEPOSITAGENTNMRF=@DEPOSITAGENTNM , CUSTOMERCODERF=@CUSTOMERCODE , CUSTOMERNAMERF=@CUSTOMERNAME , CUSTOMERNAME2RF=@CUSTOMERNAME2 , DEBITNOTEOFFSETCDRF=@DEBITNOTEOFFSETCD , DEPOSITCDRF=@DEPOSITCD , ACPTANODRSTATUSRF=@ACPTANODRSTATUS , SALESSLIPNUMRF=@SALESSLIPNUM"
                            //       + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                            //          + " AND CUSTOMERCODERF=@FINDCUSTOMERCODE"
                            //          + " AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS"
                            //          + " AND SALESSLIPNUMRF=@FINDSALESSLIPNUM"
                            //          + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                            //          + " AND ADDUPSECCODERF=@ADDUPSECCODE"
                            //          ;
                            // �� 2007.10.12 980081 c
                            # endregion

                            # region [UPDATE��]
                            //--- ADD 2008/04/25 M.Kubota --->>>
                            string sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  DEPOSITALWRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,INPUTDEPOSITSECCDRF = @INPUTDEPOSITSECCD" + Environment.NewLine;
                            sqlText += " ,ADDUPSECCODERF = @ADDUPSECCODE" + Environment.NewLine;
                            sqlText += " ,ACPTANODRSTATUSRF = @ACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += " ,SALESSLIPNUMRF = @SALESSLIPNUM" + Environment.NewLine;
                            sqlText += " ,RECONCILEDATERF = @RECONCILEDATE" + Environment.NewLine;
                            sqlText += " ,RECONCILEADDUPDATERF = @RECONCILEADDUPDATE" + Environment.NewLine;
                            sqlText += " ,DEPOSITSLIPNORF = @DEPOSITSLIPNO" + Environment.NewLine;
                            sqlText += " ,DEPOSITALLOWANCERF = @DEPOSITALLOWANCE" + Environment.NewLine;
                            sqlText += " ,DEPOSITAGENTCODERF = @DEPOSITAGENTCODE" + Environment.NewLine;
                            sqlText += " ,DEPOSITAGENTNMRF = @DEPOSITAGENTNM" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERNAMERF = @CUSTOMERNAME" + Environment.NewLine;
                            sqlText += " ,CUSTOMERNAME2RF = @CUSTOMERNAME2" + Environment.NewLine;
                            sqlText += " ,DEBITNOTEOFFSETCDRF = @DEBITNOTEOFFSETCD" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  AND SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                            sqlText += "  AND DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            //--- ADD 2008/04/25 M.Kubota ---<<<
                            # endregion

                            // �X�V�w�b�_����ݒ�
                            //--- ADD 2008/04/25 M.Kubota --->>>
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)depositAlwWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                            //--- ADD 2008/04/25 M.Kubota ---<<<
                        }
                        else
                        {
                            // �_���폜�敪�������Ă���ꍇ�͍폜�������s
                            # region --- DEL 2008/04/25 M.Kubota ---
                            // �� 2007.10.12 980081 c
                            //sqlCommand.CommandText = "DELETE DEPOSITALWRF"
                            //                       + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                            //                       + " AND CUSTOMERCODERF=@FINDCUSTOMERCODE"
                            //                       + " AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO"
                            //                       + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                            //                       + " AND ADDUPSECCODERF=@ADDUPSECCODE";
                            //sqlCommand.CommandText = "DELETE DEPOSITALWRF"
                            //                       + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                            //                       + " AND CUSTOMERCODERF=@FINDCUSTOMERCODE"
                            //                       + " AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS"
                            //                       + " AND SALESSLIPNUMRF=@FINDSALESSLIPNUM"
                            //                       + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                            //                       + " AND ADDUPSECCODERF=@ADDUPSECCODE";
                            // �� 2007.10.12 980081 c
                            # endregion

                            //this.ReadDataToDepositAlw(ref depositAlwWork, myReader);  //ADD 2008/04/25 M.Kubota

                            # region [DELETE��]
                            //--- ADD 2008/04/25 M.Kubota --->>>
                            string sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  DEPOSITALWRF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  AND SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                            sqlText += "  AND DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            //--- ADD 2008/04/25 M.Kubota ---<<<
                            # endregion

                            deleteSql = true;  //ADD 2008/04/25 M.Kubota
                        }

                        // KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
                        // �� 2007.10.12 980081 c
                        //findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
                        findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcptAnOdrStatus);
                        findParaSalesSlipNum.Value = SqlDataMediator.SqlSetString(depositAlwWork.SalesSlipNum);
                        // �� 2007.10.12 980081 c
                        //findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);  //DEL 2008/04/25 M.Kubota
                        findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
                        // ????�������݌v������ǂ����邩�H
                        //findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode); //DEL 2008/04/25 M.Kubota

                        // �X�V�w�b�_����ݒ�
                        //--- DEL 2008/04/25 M.Kubota --->>>
                        //object obj = (object)this;
                        //IFileHeader flhd = (IFileHeader)depositAlwWork;
                        //FileHeader fileHeader = new FileHeader(obj);
                        //fileHeader.SetUpdateHeader(ref flhd, obj);
                        //--- DEL 2008/04/25 M.Kubota ---<<<
                    }
                    else
                    {
                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���
                        // �ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (depositAlwWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader != null && !myReader.IsClosed) myReader.Close();
                            return status;
                        }

                        # region --- DEL 2008/04/25 M.Kubota ---
                        // �� 2007.10.12 980081 c
                        #region �����C�A�E�g(�R�����g�A�E�g)
                        //sqlCommand.CommandText =
                        //      "INSERT INTO DEPOSITALWRF("
                        //            + " CREATEDATETIMERF"
                        //            + ",UPDATEDATETIMERF"
                        //            + ",ENTERPRISECODERF"
                        //            + ",FILEHEADERGUIDRF"
                        //            + ",UPDEMPLOYEECODERF"
                        //            + ",UPDASSEMBLYID1RF"
                        //            + ",UPDASSEMBLYID2RF"
                        //            + ",LOGICALDELETECODERF"
                        //            + ",INPUTDEPOSITSECCDRF"
                        //            + ",ADDUPSECCODERF"
                        //            + ",RECONCILEDATERF"
                        //            + ",RECONCILEADDUPDATERF"
                        //            + ",DEPOSITSLIPNORF"
                        //            + ",DEPOSITKINDCODERF"
                        //            + ",DEPOSITKINDNAMERF"
                        //            + ",DEPOSITALLOWANCERF"
                        //            + ",DEPOSITAGENTCODERF"
                        //            + ",DEPOSITAGENTNMRF"
                        //            + ",CUSTOMERCODERF"
                        //            + ",CUSTOMERNAMERF"
                        //            + ",CUSTOMERNAME2RF"
                        //            + ",ACCEPTANORDERNORF"
                        //            + ",SERVICESLIPCDRF"
                        //            + ",DEBITNOTEOFFSETCDRF"
                        //            + ",DEPOSITCDRF"
                        //            + ",CREDITORLOANCDRF"
                        //    + ") VALUES ("
                        //            + " @CREATEDATETIME"
                        //            + ",@UPDATEDATETIME"
                        //            + ",@ENTERPRISECODE"
                        //            + ",@FILEHEADERGUID"
                        //            + ",@UPDEMPLOYEECODE"
                        //            + ",@UPDASSEMBLYID1"
                        //            + ",@UPDASSEMBLYID2"
                        //            + ",@LOGICALDELETECODE"
                        //            + ",@INPUTDEPOSITSECCD"
                        //            + ",@ADDUPSECCODE"
                        //            + ",@RECONCILEDATE"
                        //            + ",@RECONCILEADDUPDATE"
                        //            + ",@DEPOSITSLIPNO"
                        //            + ",@DEPOSITKINDCODE"
                        //            + ",@DEPOSITKINDNAME"
                        //            + ",@DEPOSITALLOWANCE"
                        //            + ",@DEPOSITAGENTCODE"
                        //            + ",@DEPOSITAGENTNM"
                        //            + ",@CUSTOMERCODE"
                        //            + ",@CUSTOMERNAME"
                        //            + ",@CUSTOMERNAME2"
                        //            + ",@ACCEPTANORDERNO"
                        //            + ",@SERVICESLIPCD"
                        //            + ",@DEBITNOTEOFFSETCD"
                        //            + ",@DEPOSITCD"
                        //            + ",@CREDITORLOANCD"
                        //    + ")";
                        #endregion
                        //sqlCommand.CommandText =
                        //      "INSERT INTO DEPOSITALWRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, INPUTDEPOSITSECCDRF, ADDUPSECCODERF, RECONCILEDATERF, RECONCILEADDUPDATERF, DEPOSITSLIPNORF, DEPOSITKINDCODERF, DEPOSITKINDNAMERF, DEPOSITALLOWANCERF, DEPOSITAGENTCODERF, DEPOSITAGENTNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, DEBITNOTEOFFSETCDRF, DEPOSITCDRF, ACPTANODRSTATUSRF, SALESSLIPNUMRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @INPUTDEPOSITSECCD, @ADDUPSECCODE, @RECONCILEDATE, @RECONCILEADDUPDATE, @DEPOSITSLIPNO, @DEPOSITKINDCODE, @DEPOSITKINDNAME, @DEPOSITALLOWANCE, @DEPOSITAGENTCODE, @DEPOSITAGENTNM, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERNAME2, @DEBITNOTEOFFSETCD, @DEPOSITCD, @ACPTANODRSTATUS, @SALESSLIPNUM)";
                        // �� 2007.10.12 980081 c
                        # endregion

                        # region [INSERT��]
                        //--- ADD 2008/04/25 M.Kubota --->>>
                        string sqlText = string.Empty;
                        sqlText += "INSERT INTO DEPOSITALWRF" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " ,INPUTDEPOSITSECCDRF" + Environment.NewLine;
                        sqlText += " ,ADDUPSECCODERF" + Environment.NewLine;
                        sqlText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                        sqlText += " ,SALESSLIPNUMRF" + Environment.NewLine;
                        sqlText += " ,RECONCILEDATERF" + Environment.NewLine;
                        sqlText += " ,RECONCILEADDUPDATERF" + Environment.NewLine;
                        sqlText += " ,DEPOSITSLIPNORF" + Environment.NewLine;
                        sqlText += " ,DEPOSITALLOWANCERF" + Environment.NewLine;
                        sqlText += " ,DEPOSITAGENTCODERF" + Environment.NewLine;
                        sqlText += " ,DEPOSITAGENTNMRF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERNAMERF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERNAME2RF" + Environment.NewLine;
                        sqlText += " ,DEBITNOTEOFFSETCDRF" + Environment.NewLine;
                        sqlText += ")" + Environment.NewLine;
                        sqlText += "VALUES" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,@INPUTDEPOSITSECCD" + Environment.NewLine;
                        sqlText += " ,@ADDUPSECCODE" + Environment.NewLine;
                        sqlText += " ,@ACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += " ,@SALESSLIPNUM" + Environment.NewLine;
                        sqlText += " ,@RECONCILEDATE" + Environment.NewLine;
                        sqlText += " ,@RECONCILEADDUPDATE" + Environment.NewLine;
                        sqlText += " ,@DEPOSITSLIPNO" + Environment.NewLine;
                        sqlText += " ,@DEPOSITALLOWANCE" + Environment.NewLine;
                        sqlText += " ,@DEPOSITAGENTCODE" + Environment.NewLine;
                        sqlText += " ,@DEPOSITAGENTNM" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERNAME" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERNAME2" + Environment.NewLine;
                        sqlText += " ,@DEBITNOTEOFFSETCD" + Environment.NewLine;
                        sqlText += ")" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        //--- ADD 2008/04/25 M.Kubota ---<<<
                        # endregion

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)depositAlwWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
                    if (myReader != null && !myReader.IsClosed) myReader.Close();

                    if (!deleteSql)  //ADD 2008/04/25 M.Kubota
                    {
                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        # region --- DEL 2008/04/25 M.Kubota --->>>
# if false
                    // �쐬����
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    // �X�V����
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    // ��ƃR�[�h
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    // GUID
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    // �X�V�]�ƈ��R�[�h
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    // �X�V�A�Z���u��ID1
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    // �X�V�A�Z���u��ID2
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    // �_���폜�敪
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    // �������͋��_�R�[�h
                    SqlParameter paraInputDepositSecCd = sqlCommand.Parameters.Add("@INPUTDEPOSITSECCD", SqlDbType.NChar);
                    // �v�㋒�_�R�[�h
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    // �����ݓ�
                    SqlParameter paraReconcileDate = sqlCommand.Parameters.Add("@RECONCILEDATE", SqlDbType.Int);
                    // �����݌v���
                    SqlParameter paraReconcileAddUpDate = sqlCommand.Parameters.Add("@RECONCILEADDUPDATE", SqlDbType.Int);
                    // �����`�[�ԍ�
                    SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                    // ��������R�[�h
                    SqlParameter paraDepositKindCode = sqlCommand.Parameters.Add("@DEPOSITKINDCODE", SqlDbType.Int);
                    // �������햼��
                    SqlParameter paraDepositKindName = sqlCommand.Parameters.Add("@DEPOSITKINDNAME", SqlDbType.NVarChar);
                    // ���������z
                    SqlParameter paraDepositAllowance = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE", SqlDbType.BigInt);
                    // �����S���҃R�[�h
                    SqlParameter paraDepositAgentCode = sqlCommand.Parameters.Add("@DEPOSITAGENTCODE", SqlDbType.NChar);
                    // �����S���Җ���
                    SqlParameter paraDepositAgentNm = sqlCommand.Parameters.Add("@DEPOSITAGENTNM", SqlDbType.NVarChar);
                    // ���Ӑ�R�[�h
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    // ���Ӑ於��
                    SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                    // ���Ӑ於��2
                    SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                    // �� 2007.10.12 980081 d
                    //// �󒍔ԍ�
                    //SqlParameter paraAcceptAnOrderNo    = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
                    //// �T�[�r�X�`�[�敪
                    //SqlParameter paraServiceSlipCd      = sqlCommand.Parameters.Add("@SERVICESLIPCD", SqlDbType.Int);
                    // �� 2007.10.12 980081 d
                    // �ԓ`���E�敪
                    SqlParameter paraDebitNoteOffSetCd = sqlCommand.Parameters.Add("@DEBITNOTEOFFSETCD", SqlDbType.Int);
                    // �a����敪
                    SqlParameter paraDepositCd = sqlCommand.Parameters.Add("@DEPOSITCD", SqlDbType.Int);
                    // �� 2007.10.12 980081 d
                    //// �N���W�b�g�^���[���敪
                    //SqlParameter paraCreditOrLoanCd     = sqlCommand.Parameters.Add("@CREDITORLOANCD", SqlDbType.Int);
                    // �� 2007.10.12 980081 d
                    // �� 2007.10.12 980081 a
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                    // �� 2007.10.12 980081 a
# endif
                    # endregion

                        //--- ADD 2008/04/25 M.Kubota --->>>
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraInputDepositSecCd = sqlCommand.Parameters.Add("@INPUTDEPOSITSECCD", SqlDbType.NChar);
                        SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                        SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                        SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                        SqlParameter paraReconcileDate = sqlCommand.Parameters.Add("@RECONCILEDATE", SqlDbType.Int);
                        SqlParameter paraReconcileAddUpDate = sqlCommand.Parameters.Add("@RECONCILEADDUPDATE", SqlDbType.Int);
                        SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                        SqlParameter paraDepositAllowance = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE", SqlDbType.BigInt);
                        SqlParameter paraDepositAgentCode = sqlCommand.Parameters.Add("@DEPOSITAGENTCODE", SqlDbType.NChar);
                        SqlParameter paraDepositAgentNm = sqlCommand.Parameters.Add("@DEPOSITAGENTNM", SqlDbType.NVarChar);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                        SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                        SqlParameter paraDebitNoteOffSetCd = sqlCommand.Parameters.Add("@DEBITNOTEOFFSETCD", SqlDbType.Int);
                        //--- ADD 2008/04/25 M.Kubota ---<<<
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        # region --- DEL 2008/04/25 M.Kubota ---
# if fasle
                    // �쐬����
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.CreateDateTime);
                    // �X�V����
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.UpdateDateTime);
                    // ��ƃR�[�h
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
                    // GUID
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depositAlwWork.FileHeaderGuid);
                    // �X�V�]�ƈ��R�[�h
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdEmployeeCode);
                    // �X�V�A�Z���u��ID1
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId1);
                    // �X�V�A�Z���u��ID2
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId2);
                    // �_���폜�敪
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.LogicalDeleteCode);
                    // �������͋��_�R�[�h
                    paraInputDepositSecCd.Value = SqlDataMediator.SqlSetString(depositAlwWork.InputDepositSecCd);
                    // �v�㋒�_�R�[�h
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);
                    // �����ݓ�
                    paraReconcileDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileDate);
                    // �����݌v���
                    paraReconcileAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileAddUpDate);
                    // �����`�[�ԍ�
                    paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
                    // ��������R�[�h
                    paraDepositKindCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositKindCode);
                    // �������햼��
                    paraDepositKindName.Value = SqlDataMediator.SqlSetString(depositAlwWork.DepositKindName);
                    // ���������z
                    paraDepositAllowance.Value = SqlDataMediator.SqlSetInt64(depositAlwWork.DepositAllowance);
                    // �����S���҃R�[�h
                    paraDepositAgentCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.DepositAgentCode);
                    // �����S���Җ���
                    paraDepositAgentNm.Value = SqlDataMediator.SqlSetString(depositAlwWork.DepositAgentNm);
                    // ���Ӑ�R�[�h
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
                    // ���Ӑ於��
                    paraCustomerName.Value = SqlDataMediator.SqlSetString(depositAlwWork.CustomerName);
                    // ���Ӑ於��2
                    paraCustomerName2.Value = SqlDataMediator.SqlSetString(depositAlwWork.CustomerName2);
                    // �� 2007.10.12 980081 d
                    //// �󒍔ԍ�
                    //paraAcceptAnOrderNo.Value      = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
                    //// �T�[�r�X�`�[�敪
                    //paraServiceSlipCd.Value        = SqlDataMediator.SqlSetInt32(depositAlwWork.ServiceSlipCd);
                    // �� 2007.10.12 980081 d
                    // �ԓ`���E�敪
                    paraDebitNoteOffSetCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DebitNoteOffSetCd);
                    // �a����敪
                    paraDepositCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositCd);
                    // �� 2007.10.12 980081 d
                    //// �N���W�b�g�^���[���敪
                    //paraCreditOrLoanCd.Value       = SqlDataMediator.SqlSetInt32(depositAlwWork.CreditOrLoanCd);
                    // �� 2007.10.12 980081 d
                    // �� 2007.10.12 980081 a
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcptAnOdrStatus);
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(depositAlwWork.SalesSlipNum);
                    // �� 2007.10.12 980081 a
# endif
                    # endregion

                        //--- ADD 2008/04/25 M.Kubota --->>>
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.CreateDateTime);              // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.UpdateDateTime);              // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);                         // ��ƃR�[�h
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depositAlwWork.FileHeaderGuid);                           // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdEmployeeCode);                       // �X�V�]�ƈ��R�[�h
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId1);                         // �X�V�A�Z���u��ID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId2);                         // �X�V�A�Z���u��ID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.LogicalDeleteCode);                    // �_���폜�敪
                        paraInputDepositSecCd.Value = SqlDataMediator.SqlSetString(depositAlwWork.InputDepositSecCd);                   // �������͋��_�R�[�h
                        paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);                             // �v�㋒�_�R�[�h
                        paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcptAnOdrStatus);                        // �󒍃X�e�[�^�X
                        paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(depositAlwWork.SalesSlipNum);                             // ����`�[�ԍ�
                        paraReconcileDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileDate);             // �����ݓ�
                        paraReconcileAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileAddUpDate);   // �����݌v���
                        paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);                            // �����`�[�ԍ�
                        paraDepositAllowance.Value = SqlDataMediator.SqlSetInt64(depositAlwWork.DepositAllowance);                      // ���������z
                        paraDepositAgentCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.DepositAgentCode);                     // �����S���҃R�[�h
                        paraDepositAgentNm.Value = SqlDataMediator.SqlSetString(depositAlwWork.DepositAgentNm);                         // �����S���Җ���
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);                              // ���Ӑ�R�[�h
                        paraCustomerName.Value = SqlDataMediator.SqlSetString(depositAlwWork.CustomerName);                             // ���Ӑ於��
                        paraCustomerName2.Value = SqlDataMediator.SqlSetString(depositAlwWork.CustomerName2);                           // ���Ӑ於��2
                        paraDebitNoteOffSetCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DebitNoteOffSetCd);                    // �ԓ`���E�敪
                        //--- ADD 2008/04/25 M.Kubota ---<<<
                        #endregion
                    }

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //--- DEL 2008/04/25 M.Kubota --->>>
                //if (myReader != null && !myReader.IsClosed) myReader.Close();
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);
                //--- DEL 2008/04/25 M.Kubota ---<<<

                //--- ADD 2008/04/25 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/04/25 M.Kubota ---<<<
            }
            //--- ADD 2008/04/25 M.Kubota --->>>
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }
            //--- ADD 2008/04/25 M.Kubota ---<<<

            //if (myReader != null && !myReader.IsClosed) myReader.Close();  //DEL 2008/04/25 M.Kubota

            return status;
        }
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
        #region �ݒ�t�@�C���擾
        /// <summary>
        /// �ݒ�t�@�C���擾
        /// </summary>
        /// <param name="dbCommandTimeout">�^�C���A�E�g����</param>
        /// <remarks>
        /// <br>Note         : �ݒ�t�@�C���擾�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private void GetXmlInfo(ref int dbCommandTimeout)
        {
            // �����l�ݒ�
            string fileName = this.InitializeXmlSettings();

            if (fileName != string.Empty)
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            //�^�C���A�E�g���Ԃ��擾
                            if (reader.IsStartElement("DbCommandTimeout")) dbCommandTimeout = reader.ReadElementContentAsInt();
                        }
                    }
                }
                catch
                {
                    base.WriteErrorLog(null, "�ݒ�t�@�C���擾�G���[");
                }
            }

        }
        #endregion // �ݒ�t�@�C���擾

        #region XML�t�@�C������
        /// <summary>
        /// XML�t�@�C�����擾
        /// </summary>
        /// <returns>XML�t�@�C����</returns>
        /// <remarks>
        /// <br>Note         : XML���擾�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // �J�����g�f�B���N�g���擾
                homeDir = this.GetCurrentDirectory();

                // �f�B���N�g������XML�t�@�C������A��
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // �t�@�C�������݂��Ȃ��ꍇ�͋󔒂ɂ���
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipDB.InitializeXmlSettings:" + ex.Message);
            }
            return path;
        }
        #endregion //XML�t�@�C������

        #region �J�����g�t�H���_
        /// <summary>
        /// �J�����g�t�H���_�擾
        /// </summary>
        /// <returns>XML�t�@�C����</returns>
        /// <remarks>
        /// <br>Note         : �J�����g�t�H���_�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML�i�[�f�B���N�g���擾
            try
            {
                // dll�i�[�p�X�������f�B���N�g���Ƃ���
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(); // �����́u\�v�͏�ɂȂ�

                // ���W�X�g�������USER_AP�̃L�[�����擾
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // ���W�X�g�������擾�ł��Ȃ��ꍇ�͏����f�B���N�g�� // �^�p�゠�肦�Ȃ��P�[�X
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // �擾�f�B���N�g�������݂��Ȃ��ꍇ�͏����f�B���N�g����ݒ�
                // �^�p�゠�肦�Ȃ��P�[�X
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch (Exception ex)
            {
                //USER_AP��LOG�t�H���_�Ƀ��O�o��
                base.WriteErrorLog(ex, "SalesSlipDB.GetCurrentDirectory:" + ex.Message);
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }
            return homeDir;
        }
        #endregion // �J�����g�t�H���_
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<

        /// <summary>
        /// 
        /// </summary>
        /// <param name="depsitMainWrk"></param>
        /// <param name="depsitDtlWrkArray"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int WriteDepositDtlWork(ref DepsitMainWork depsitMainWrk, ref DepsitDtlWork[] depsitDtlWrkArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            SqlDataReader sqlDataReader = null;

            try
            {
                # region [DELETE��]
                string sqlText = string.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  DEPSITDTLRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                sqlText += "  AND DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;
                # endregion

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
                
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWrk.EnterpriseCode);   // ��ƃR�[�h
                findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depsitMainWrk.AcptAnOdrStatus);  // �󒍃X�e�[�^�X
                findDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWrk.DepositSlipNo);      // �����`�[�ԍ�

                sqlCommand.ExecuteNonQuery();

                // 2009/05/01 >>>>>>>>>>>>>>>>>>>>>>
                //if (depsitMainWrk.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData0) 
                if ((depsitMainWrk.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData0) ||
                    (depsitMainWrk.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData1))
                // 2009/05/01 <<<<<<<<<<<<<<<<<<<<<<
                {
                    sqlCommand.Parameters.Clear();

                    # region [INSERT��]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO DEPSITDTLRF" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += " ,DEPOSITSLIPNORF" + Environment.NewLine;
                    sqlText += " ,DEPOSITROWNORF" + Environment.NewLine;
                    sqlText += " ,MONEYKINDCODERF" + Environment.NewLine;
                    sqlText += " ,MONEYKINDNAMERF" + Environment.NewLine;
                    sqlText += " ,MONEYKINDDIVRF" + Environment.NewLine;
                    sqlText += " ,DEPOSITRF" + Environment.NewLine;
                    sqlText += " ,VALIDITYTERMRF" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;
                    sqlText += "VALUES" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " ,@ACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += " ,@DEPOSITSLIPNO" + Environment.NewLine;
                    sqlText += " ,@DEPOSITROWNO" + Environment.NewLine;
                    sqlText += " ,@MONEYKINDCODE" + Environment.NewLine;
                    sqlText += " ,@MONEYKINDNAME" + Environment.NewLine;
                    sqlText += " ,@MONEYKINDDIV" + Environment.NewLine;
                    sqlText += " ,@DEPOSIT" + Environment.NewLine;
                    sqlText += " ,@VALIDITYTERM" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    # region Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                    SqlParameter paraDepositRowNo = sqlCommand.Parameters.Add("@DEPOSITROWNO", SqlDbType.Int);
                    SqlParameter paraMoneyKindCode = sqlCommand.Parameters.Add("@MONEYKINDCODE", SqlDbType.Int);
                    SqlParameter paraMoneyKindName = sqlCommand.Parameters.Add("@MONEYKINDNAME", SqlDbType.NVarChar);
                    SqlParameter paraMoneyKindDiv = sqlCommand.Parameters.Add("@MONEYKINDDIV", SqlDbType.Int);
                    SqlParameter paraDeposit = sqlCommand.Parameters.Add("@DEPOSIT", SqlDbType.BigInt);
                    SqlParameter paraValidityTerm = sqlCommand.Parameters.Add("@VALIDITYTERM", SqlDbType.Int);
                    # endregion

                    foreach (DepsitDtlWork depsitDtlWork in depsitDtlWrkArray)
                    {
                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)depsitDtlWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                        depsitDtlWork.LogicalDeleteCode = depsitMainWrk.LogicalDeleteCode;  // ADD 2009/05/01 �`�[�̘_���폜�敪���Z�b�g
                        
                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitDtlWork.CreateDateTime);   // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitDtlWork.UpdateDateTime);   // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitDtlWork.EnterpriseCode);              // ��ƃR�[�h
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depsitDtlWork.FileHeaderGuid);                // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitDtlWork.UpdEmployeeCode);            // �X�V�]�ƈ��R�[�h
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depsitDtlWork.UpdAssemblyId1);              // �X�V�A�Z���u��ID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depsitDtlWork.UpdAssemblyId2);              // �X�V�A�Z���u��ID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depsitDtlWork.LogicalDeleteCode);         // �_���폜�敪
                        paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depsitDtlWork.AcptAnOdrStatus);             // �󒍃X�e�[�^�X
                        paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitDtlWork.DepositSlipNo);                 // �����`�[�ԍ�
                        paraDepositRowNo.Value = SqlDataMediator.SqlSetInt32(depsitDtlWork.DepositRowNo);                   // �����s�ԍ�
                        paraMoneyKindCode.Value = SqlDataMediator.SqlSetInt32(depsitDtlWork.MoneyKindCode);                 // ����R�[�h
                        paraMoneyKindName.Value = SqlDataMediator.SqlSetString(depsitDtlWork.MoneyKindName);                // ���햼��
                        paraMoneyKindDiv.Value = SqlDataMediator.SqlSetInt32(depsitDtlWork.MoneyKindDiv);                   // ����敪
                        paraDeposit.Value = SqlDataMediator.SqlSetInt64(depsitDtlWork.Deposit);                             // �������z
                        paraValidityTerm.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depsitDtlWork.ValidityTerm);    // �L������
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlDataReader != null)
                {
                    if (!sqlDataReader.IsClosed)
                    {
                        sqlDataReader.Close();
                    }
                    sqlDataReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        
        /// <summary>
        /// �����`�[�ԍ����̔Ԃ��ĕԂ��܂�
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="SectionCode">���_�R�[�h(�̔Ԋ���_)</param>
        /// <param name="depositSlipNo">�����`�[�ԍ�</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����`�[�ԍ����̔Ԃ��ĕԂ��܂�</br>
        /// <br>Programmer : 95089 ���i�@��</br>
        /// <br>Date       : 2005.08.03</br>
        /// </remarks>	
        private int CreateDepositSlipNoProc(string EnterpriseCode, string SectionCode, out int depositSlipNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            /*
                        int status;

                        // �����`�[�ԍ��̍ŏI�l���擾
                        status = GetMaxDepositSlipNoProc(out depositSlipNo, EnterpriseCode, ref sqlConnection,ref sqlTransaction);
                        if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �C���N�������g
                            depositSlipNo++;
                        }
            */
            //�߂�l������
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            depositSlipNo = 0;
            //string retMsg = "";  //DEL 2008/04/25 M.Kubota

            //NumberNumbering numberNumbering = new NumberNumbering();  //DEL 2008/04/25 M.Kubota
            NumberingManager numberingManager = new NumberingManager(); //ADD 2008/04/25 M.Kubota  

            //�ԍ��͈͕����[�v
            Int32 loopCnt = 1;
            while (loopCnt <= 999999999)
            {
                //string no;  //DEL 2008/04/25 M.Kubota
                long no;      //ADD 2008/04/25 M.Kubota

                //Int32 ptnCd;  //DEL 2008/04/25 M.Kubota
                //�ԍ��̔�
                //status = numberNumbering.Numbering(EnterpriseCode, SectionCode, 3, new string[0], out no, out ptnCd, out retMsg);  //DEL 2008/04/25 M.Kubota

                status = numberingManager.GetSerialNumber(EnterpriseCode, SectionCode, SerialNumberCode.DepositSlipNo, out no);  //ADD 2008/04/25 M.Kubota

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                    //�ԍ��𐔒l�^�ɕϊ�
                    Int32 wkDepositSlipNo = System.Convert.ToInt32(no);  // Int32 �� Int64 �ŕϊ�
                    SqlDataReader myReader = null;

                    //�����󂫔ԃ`�F�b�N
                    try
                    {
                        # region [SELECT��]
                        //--- ADD 2008/04/25 M.Kubota --->>>
                        string sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  DEP.DEPOSITSLIPNORF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  DEPSITMAINRF AS DEP" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  DEP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND DEP.DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;
                        //--- ADD 2008/04/25 M.Kubota ---<<<
                        # endregion
                        
                        //Select�R�}���h�̐���
                        //using (SqlCommand sqlCommand = new SqlCommand("SELECT DEPOSITSLIPNORF FROM DEPSITMAINRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO", sqlConnection, sqlTransaction))  //DEL 2008/04/25 M.Kubota
                        using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))  //ADD 2008/04/25 M.Kubota
                        {
                            //Prameter�I�u�W�F�N�g�̍쐬
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

                            //Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
                            findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(wkDepositSlipNo);

                            myReader = sqlCommand.ExecuteReader();
                            //�f�[�^�����̏ꍇ�ɂ͖߂�l���Z�b�g
                            if (!myReader.Read())
                            {
                                depositSlipNo = wkDepositSlipNo;
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        //���N���X�ɗ�O��n���ď������Ă��炤
                        //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/25 M.Kubota
                        //--- ADD 2008/04/25 M.Kubota --->>>
                        string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                        status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                        //--- ADD 2008/04/25 M.Kubota ---<<<
                    }
                    finally
                    {
                        //if (myReader != null && !myReader.IsClosed) myReader.Close();  //DEL 2008/04/25 M.Kubota
                        //--- ADD 2008/04/25 M.Kubota --->>>
                        if (myReader != null)
                        {
                            if (!myReader.IsClosed)
                                myReader.Close();
                            myReader.Dispose();
                        }
                        //--- ADD 2008/04/25 M.Kubota ---<<<
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) break;
                }
                //�̔Ԃł��Ȃ������ꍇ�ɂ͏������f�B
                else break;

                //����ԍ�������ꍇ�ɂ̓��[�v�J�E���^���C���N�������g���č̔�
                loopCnt++;
            }

            //�S�����[�v���Ă��擾�o���Ȃ��ꍇ
            if (loopCnt == 999999999 && status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                //retMsg = "�����ԍ��ɋ󂫔ԍ�������܂���B�폜�\�ȓ����`�[���폜���Ă��������B";  //DEL 2008/04/25 M.Kubota
            }

            //�G���[�ł��X�e�[�^�X�y�у��b�Z�[�W�͂��̂܂ܖ߂�
            return status;
        }

        /// <summary>
        /// ����f�[�^���̈����z�E�����c�����X�V���܂�
        /// </summary>
        /// <param name="depositAlwWork">�����������</param>
        /// <param name="bf_DepositAllowance">�X�V�O���������z</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����������ƁA�X�V�O�������E�N���W�b�g���[���敪�ɂ�蔄��f�[�^���X�V���܂�</br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.01.24</br>
        /// <br>Update Note: 2020/08/28 �c����</br>
        /// <br>             PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br>
        /// </remarks>    
        //private int UpdateSalesSlipRec(ref DepositAlwWork depositAlwWork, Int64 bf_DepositAllowance, int bf_DepositCd, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //DEL 2008/04/25 M.Kubota
        private int UpdateSalesSlipRec(ref DepositAlwWork depositAlwWork, Int64 bf_DepositAllowance, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2008/04/25 M.Kubota
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            int dbCommandTimeout = DB_COMMAND_TIMEOUT; // �R�}���h�^�C���A�E�g�i�b�j//ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� 
            // Update�R�}���h�̐���
            try
            {
                string updateSql = "UPDATE SALESSLIPRF"
                                 + " SET UPDATEDATETIMERF=@UPDATEDATETIME"
                                 + ",UPDEMPLOYEECODERF=@UPDEMPLOYEECODE"
                                 + ",UPDASSEMBLYID1RF=@UPDASSEMBLYID1"
                                 + ",UPDASSEMBLYID2RF=@UPDASSEMBLYID2"
                                 + ",DEPOSITALLOWANCETTLRF=DEPOSITALLOWANCETTLRF+@DF_DEPOSITALLOWANCETTL"  // �����������v�z
                                 //+ ",MNYDEPOALLOWANCETTLRF=MNYDEPOALLOWANCETTLRF+@DF_MNYDEPOALLOWANCETTL"  // �a����������v�z  //DEL 2008/04/25 M.Kubota
                                 + ",DEPOSITALWCBLNCERF=DEPOSITALWCBLNCERF-@DF_DEPOSITALLOWANCETTL"        // ���������c��
                                 + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                    // �� 2007.10.12 980081 c
                    //+ " AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO"
                                 + " AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS"
                                 + " AND SALESSLIPNUMRF=@FINDSALESSLIPNUM"
                    // �� 2007.10.12 980081 c
                                 + " AND CLAIMCODERF=@FINDCLAIMCODE"
                                 ;

                using (SqlCommand sqlCommand = new SqlCommand(updateSql, sqlConnection, sqlTransaction))
                {
                    //--------------------------------
                    // ���������̃I�u�W�F�N�g�ݒ�
                    //--------------------------------
                    #region ���������ݒ�
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    // �� 2007.10.12 980081 c
                    //SqlParameter findParaAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                    SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findParaSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                    // �� 2007.10.12 980081 c
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
                    // �� 2007.10.12 980081 c
                    //findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
                    findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcptAnOdrStatus);
                    findParaSalesSlipNum.Value = SqlDataMediator.SqlSetString(depositAlwWork.SalesSlipNum);
                    // �� 2007.10.12 980081 c
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
                    #endregion

                    //--------------------------------
                    // �ݒ荀�ڂ̃I�u�W�F�N�g�ݒ�
                    //--------------------------------
                    #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);    // �X�V��
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);

                    // �������z
                    SqlParameter paraDF_DepositAllowance = sqlCommand.Parameters.Add("@DF_DEPOSITALLOWANCETTL", SqlDbType.BigInt);
                    // �a����������z
                    //SqlParameter paraDF_MnyOnDepoAllowance = sqlCommand.Parameters.Add("@DF_MNYDEPOALLOWANCETTL", SqlDbType.BigInt);  //DEL 2008/04/25 M.Kubota
                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    // �����������v�z
                    //     ��������.���������z - �ҏW�O.�����������v�z
                    Int64 df_DepositAllowanceTtl = depositAlwWork.DepositAllowance - bf_DepositAllowance;

                    //--- DEL 2008/04/25 M.Kubota --->>>
                    // �a����������z
                    //Int64 df_MnyOnDepoAllowance = 0;
                    //if (bf_DepositCd == 1)
                    //{
                    //    // �ҏW�O���a����̎��́A�a����������v�z����ҏW�O�̗a���������
                    //    df_MnyOnDepoAllowance -= bf_DepositAllowance;
                    //}

                    //if (depositAlwWork.DepositCd == 1)
                    //{
                    //    // ���񂪗a����̎��́A�a����������v�z�ɍ���̗a��������Z
                    //    df_MnyOnDepoAllowance += depositAlwWork.DepositAllowance;
                    //}
                    //--- DEL 2008/04/25 M.Kubota ---<<<

                    // ���X�V�w�b�_����ݒ� 
                    object obj = (object)this;
                    FileHeader fileHeader = new FileHeader(obj);
                    // �X�V��
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(fileHeader.NewFileHeaderDateTime());
                    // �X�V�]�ƈ��R�[�h
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(fileHeader.UpdEmployeeCode);
                    // �X�V�A�Z���u��ID1
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(fileHeader.UpdAssemblyId1);
                    // �X�V�A�Z���u��ID2
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(fileHeader.GetUpdAssemblyID(this));

                    // ���ύX����ݒ� 
                    // �������z
                    paraDF_DepositAllowance.Value = SqlDataMediator.SqlSetInt64(df_DepositAllowanceTtl);
                    // �a����������z
                    //paraDF_MnyOnDepoAllowance.Value = SqlDataMediator.SqlSetInt64(df_MnyOnDepoAllowance);  //DEL 2008/04/25 M.Kubota

                    #endregion

                    // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
                    this.GetXmlInfo(ref dbCommandTimeout);
                    sqlCommand.CommandTimeout = dbCommandTimeout;
                    // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
                    int count = sqlCommand.ExecuteNonQuery();

                    // �X�V�����������ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    if (count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                }

            }
            catch (SqlException ex)
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }

            if (myReader != null && !myReader.IsClosed) myReader.Close();

            return status;
        }

        // ADD 2011/07/28 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
        /// <summary>
        /// �����f�[�^�̑��M�ς݂̃`�F�b�N
        /// </summary>
        /// <param name="depsitMainWork">������񃏁[�N</param>
        /// <returns>true: �`�F�b�NOK�Afalse�F�`�F�b�NNG</returns>
        /// <br>Update Note : 2011/12/15 tianjw</br>
        /// <br>              Redmine#27390 ���_�Ǘ�/������̃`�F�b�N</br>
        /// <br>Update Note : 2012/02/06 �c����</br>
        /// <br>�Ǘ��ԍ�    : 10707327-00 2012/03/28�z�M��</br>
        /// <br>              Redmine#28288 ���M�σf�[�^�C������̑Ή�</br>
        /// <br>Update Note : 2012/08/10  �e�c ���V</br>
        /// <br>            : ���_�Ǘ� ���M�σf�[�^�`�F�b�N�s��Ή�</br>
        private bool CheckDepsitMainSending(DepsitMainWork depsitMainWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // �`�F�b�N���s�����ǂ��������L�̂悤�ɔ��f����(�A�`�B)
            // �A���_�Ǘ�����M�Ώۃ}�X�^�ɓ����f�[�^�̋��_�Ǘ����M�敪���u1:���M����v----------->
            SecMngSndRcvWork secMngSndRcvWork = new SecMngSndRcvWork();
            secMngSndRcvWork.EnterpriseCode = depsitMainWork.EnterpriseCode;
            object outSecMngSndRcvList = null;

            // ���_�Ǘ�����M�Ώۃ}�X�^�����擾
            status = this.ScMngSndRcvDB.Search(out outSecMngSndRcvList, secMngSndRcvWork, 0, ConstantManagement.LogicalMode.GetData0);
            ArrayList secMngSndRcvList = outSecMngSndRcvList as ArrayList;

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || null == secMngSndRcvList || secMngSndRcvList.Count == 0)
                // �O���̏ꍇ�A�`�F�b�NOK
                return true;

            bool isHaveObj = false;
            foreach (SecMngSndRcvWork resultSecMngSndRcvWork in secMngSndRcvList)
            {
                if (string.Equals("DepsitMainRF", resultSecMngSndRcvWork.FileId, StringComparison.OrdinalIgnoreCase)
                    && resultSecMngSndRcvWork.SecMngSendDiv == 1
                    && resultSecMngSndRcvWork.LogicalDeleteCode == 0
                    )
                {
                    isHaveObj = true;
                    break;
                }
            }
            if (!isHaveObj)
                // �O���̏ꍇ�A�`�F�b�NOK
                return true;
            // �A���_�Ǘ�����M�Ώۃ}�X�^�ɓ����f�[�^�̋��_�Ǘ����M�敪���u1:���M����v-----------<


            // �B���_�Ǘ��ݒ�}�X�^�ɉ��L�̏��ɓ����郌�R�[�h�����݂��� ------------------------>>
            // ��ʁ�0:�f�[�^
            // ��M�󋵁�0:���M
            // ���M�Ώۋ��_���X�V��������f�[�^�̌v�㋒�_�R�[�h
            // ���M�σf�[�^�C���敪���C���s��
            object outSecMngSetList = null;
            SecMngSetWork paraSecMngSetWork = new SecMngSetWork();
            paraSecMngSetWork.EnterpriseCode = depsitMainWork.EnterpriseCode;

            // ���_�Ǘ��ݒ�}�X�^�����擾
            status = this.ScMngSetDB.Search(out outSecMngSetList, paraSecMngSetWork, 0, ConstantManagement.LogicalMode.GetData0);
            ArrayList secMngSetList = outSecMngSetList as ArrayList;


            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || null == secMngSetList || secMngSetList.Count == 0)
                // �O���̏ꍇ�A�`�F�b�NOK
                return true;

            isHaveObj = false;
            // �����v�㋒�_�R�[�h
            string addUpSecCode = depsitMainWork.AddUpSecCode;
            if (null != addUpSecCode)
                addUpSecCode = addUpSecCode.Trim();
            DateTime maxSyncExecDate = DateTime.MinValue; // ���_�Ǘ��ݒ�}�X�^�̑��M���s��
            int sndFinDataEdDiv = -1; //ADD by �����@2011/11/10
            foreach (SecMngSetWork resultSecMngSetWork in secMngSetList)
            {
                if (resultSecMngSetWork.Kind == 0 && resultSecMngSetWork.ReceiveCondition == 0
                    // ��ʁ�0:�f�[�^ && ��M�󋵁�0:���M
                    && resultSecMngSetWork.SectionCode.Trim() == addUpSecCode
                    // ���M�Ώۋ��_���X�V��������f�[�^�̌v�㋒�_�R�[�h
                     && (resultSecMngSetWork.SndFinDataEdDiv == 1 || resultSecMngSetWork.SndFinDataEdDiv == 2) //ADD by �����@2011/11/10
                    //&& resultSecMngSetWork.SndFinDataEdDiv == 1 //DEL by �����@2011/11/10
                    // ���M�σf�[�^�C���敪���C���s��
                    && resultSecMngSetWork.LogicalDeleteCode == 0
                    )
                {
                    isHaveObj = true;
                    if (resultSecMngSetWork.SyncExecDate.CompareTo(maxSyncExecDate) > 0)
                    //ADD by �����@2011/11/10 start---->>>>>>    
                    {
                        sndFinDataEdDiv = resultSecMngSetWork.SndFinDataEdDiv;
                        //ADD by �����@2011/11/10 end  ----<<<<<<   
                        maxSyncExecDate = resultSecMngSetWork.SyncExecDate;
                    }//ADD by �����@2011/11/10
                }
            }
            if (!isHaveObj)
                // �O���̏ꍇ�A�`�F�b�NOK
                return true;
            // �B���_�Ǘ��ݒ�}�X�^�ɉ��L�̏��ɓ����郌�R�[�h�����݂��� ------------------------<<


            // �`�F�b�N���� -------------------------------------->>>
            //ADD by �����@2011/11/10 start---->>>>>>
            if ((sndFinDataEdDiv == 1 && depsitMainWork.UpdateDateTime.CompareTo(maxSyncExecDate) <= 0) ||
                //(sndFinDataEdDiv == 2 && depsitMainWork.DepositDate.CompareTo(maxSyncExecDate) <= 0)) // DEL 2011/12/15
                //(sndFinDataEdDiv == 2 && depsitMainWork.PreDepositDate.CompareTo(maxSyncExecDate) <= 0)) // ADD 2011/12/15 // DEL 2012/02/06 �c���� Redmine#28288
                //(sndFinDataEdDiv == 2 && depsitMainWork.PreDepositDate.CompareTo(maxSyncExecDate) <= 0 && depsitMainWork.UpdateDateTime.CompareTo(maxSyncExecDate) <= 0)) // ADD 2012/02/06 �c���� Redmine#28288 DEL 2012/08/10 Y.Wakita
                (sndFinDataEdDiv == 2 && depsitMainWork.PreDepositDate.CompareTo(maxSyncExecDate) <= 0 && depsitMainWork.UpdateDateTime.ToString("HHmmss").CompareTo(maxSyncExecDate.ToString("HHmmss")) <= 0)) // ADD 2012/08/10 Y.Wakita
            //ADD by �����@2011/11/10 end  ----<<<<<<
            //if (depsitMainWork.UpdateDateTime.CompareTo(maxSyncExecDate) <= 0) //DEL by �����@2011/11/10
            {
                // �`�F�b�NNG
                // ���M�ς݂̃f�[�^���X�V�ł��Ȃ��A�G���[���b�Z�[�W�����O�ɏo��
                System.Text.StringBuilder errMessage = new System.Text.StringBuilder();
                errMessage.Append(NSDebug.GetExecutingMethodName(new StackFrame()));
                errMessage.Append(": ���M�ς݂̃f�[�^�ׁ̈A�X�V�ł��܂���B");
                base.WriteErrorLog(errMessage.ToString(), (int)ConstantManagement.DB_Status.ctDB_ERROR);
                return false;
            }
            else
            {
                // �`�F�b�NOK
                return true;
            }
            // �`�F�b�N���� --------------------------------------<<<
        }
        // ADD 2011/07/28 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<

        # endregion

        # region [�Ǎ�����]

        /// <summary>
		/// �����Ǎ�����
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
		/// <param name="depsitDataWorkByte">�������</param>
		/// <param name="depositAlwWorkListByte">�����������</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������E����������������ԍ������Ƀf�[�^�擾���s���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		public int Read(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out byte[] depsitDataWorkByte, out byte[] depositAlwWorkListByte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/04/25 M.Kubota

            DepsitDataWork depsitDataWork = new DepsitDataWork();    //ADD 2008/04/25 M.Kubota  
			//DepsitMainWork depsitMainWork = new DepsitMainWork();  //DEL 2008/04/25 M.Kubota
            DepositAlwWork[] depositAlwWorkList;
			ArrayList depositAlwWorkArrayList = new ArrayList();
			depositAlwWorkList =  (DepositAlwWork[])depositAlwWorkArrayList.ToArray(typeof(DepositAlwWork));
		
			depsitDataWorkByte = null;
			depositAlwWorkListByte = null;

            try
            {
                //-- DEL 2008/04/25 M.Kubota --->>>
                //���[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;

                ////SQL�ڑ�
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();
                //sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                //--- DEL 2008/04/25 M.Kubota ---<<<

                //--- ADD 2008/04/25 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);
                if (sqlConnection == null)
                {
                    return status;
                }
                //--- ADD 2008/04/25 M.Kubota ---<<<

                // �����Ǎ��ݏ���
                //status = ReadDepsitMainWork(EnterpriseCode, DepositSlipNo, out depsitMainWork, out depositAlwWorkList, ref sqlConnection,ref sqlTransaction);         //DEL 2008/04/25 M.Kubota
                status = this.Read(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out depsitDataWork, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

                //--- DEL 2008/04/25 M.Kubota --->>>
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    sqlTransaction.Commit();
                //else
                //    sqlTransaction.Rollback();
                //--- DEL 2008/04/25 M.Kubota ---<<<

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/25 M.Kubota
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            //--- ADD 2008/04/25 M.Kubota --->>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            //--- ADD 2008/04/25 M.Kubota ---<<<

			if(sqlConnection != null)
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}

			// XML�֕ϊ����A������̃o�C�i����
			//depsitDataWorkByte = XmlByteSerializer.Serialize(depsitMainWork);  //DEL 2008/04/25 M.Kubota
            depsitDataWorkByte = XmlByteSerializer.Serialize(depsitDataWork);    //ADD 2008/04/25 M.Kubota
			depositAlwWorkListByte = XmlByteSerializer.Serialize(depositAlwWorkList);

			return status;
        }

        /// <summary>
        /// �����Ǎ��������C��
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="depsitDataWork">�������</param>
        /// <param name="depositAlwWorkList">�����������</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �������E����������������ԍ������Ƀf�[�^�擾���s���܂�</br>
        /// <br>Programmer : 95089 ���i�@��</br>
        /// <br>Date       : 2005.08.11</br>
        /// <br>Update Note: 2010/12/20 ����� PM.NS��Q���ǑΉ�(12����)</br>
        /// <br>             �����l���܂��͓����萔���ɂ̂݋��z�����͂���Ă���`�[���폜���ɃG���[�������Ȃ��悤�C������B</br>
        /// </remarks>
        //public int ReadDepsitMainWork(string EnterpriseCode, int DepositSlipNo, out DepsitMainWork depsitMainWork, out DepositAlwWork[] depositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //DEL 2008/04/25 M.Kubota
        public int Read(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out DepsitDataWork depsitDataWork, out DepositAlwWork[] depositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)                  //ADD 2008/04/25 M.Kubota
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //depsitMainWork = new DepsitMainWork();  //DEL 2008/04/25 M.Kubota
            depsitDataWork = null;                    //ADD 2008/04/25 M.Kubota
            DepsitMainWork depsitMainWork = new DepsitMainWork();  //ADD 2008/04/25 M.Kubota
            DepsitDtlWork[] depsitDtlArray = null;                 //ADD 2008/04/25 M.Kubota

            ArrayList depositAlwWorkArrayList = new ArrayList();
            depositAlwWorkList = (DepositAlwWork[])depositAlwWorkArrayList.ToArray(typeof(DepositAlwWork));

            // �����}�X�^�Ǎ�����
            //status = ReadDepsitMainWorkRec(EnterpriseCode, DepositSlipNo, out depsitMainWork, ref sqlConnection, ref sqlTransaction);                 //DEL 2008/04/25 M.Kubota
            status = ReadDepsitMain(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out depsitMainWork, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota
            
            //--- ADD 2008/04/25 M.Kubota --->>>
            // �������׃f�[�^�Ǎ�����
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = this.ReadDepsitDtl(depsitMainWork, out depsitDtlArray, ref sqlConnection, ref sqlTransaction);

                // --- ADD 2010/12/20 ---------->>>>>
                // �������׃f�[�^�͑��݂��Ȃ��Ă��G���[�Ƃ��Ȃ�
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // --- ADD 2010/12/20  ----------<<<<<

                // �����}�X�^�f�[�^�Ɠ������׃f�[�^����������
                // �� depsitMainWork �̒l�� depsitDataWork �Ɉڂ����R�ŁA�������ׂ̓ǂݍ��݌��ʂɊւ�炸�����������s���B
                DepsitDataUtil.Union(out depsitDataWork, depsitMainWork, depsitDtlArray);
            }
            //--- ADD 2008/04/25 M.Kubota ---<<<
            
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �����������Ǎ��ݏ���
                //status = ReadDepositAlwWorkRec(EnterpriseCode, DepositSlipNo, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);          //DEL 2008/04/25 M.Kubota
                status = ReadDepositAlw(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota
                
                // �����͑��݂��Ȃ��Ă��G���[�Ƃ��Ȃ�
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }

            return status;
        }

        /// <summary>
        /// �����}�X�^�����擾���܂�
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="depsitMainWork">�������</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����}�X�^��������ԍ������Ƀf�[�^�擾���s���܂�</br>
        /// <br>Programmer : 95089 ���i�@��</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        //private int ReadDepsitMainWorkRec(string EnterpriseCode, int DepositSlipNo, out DepsitMainWork depsitMainWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //DEL 2008/04/25 M.Kubota
        private int ReadDepsitMain(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out DepsitMainWork depsitMainWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2008/04/25 M.Kubota
        {
            //int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;   //DEL 2008/04/25 M.Kubota
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;         //ADD 2008/04/25 M.Kubota
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/04/25 M.Kubota

            SqlDataReader myReader = null;

            depsitMainWork = new DepsitMainWork();

            try
            {
                // �� 20070124 18322 c MA.NS�p�ɕύX
                #region SF �����}�X�^ SELECT���i�R�����g�A�E�g�j
                ////Select�R�}���h�̐���
                //using(SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DEPOSITDEBITNOTECDRF, DEPOSITSLIPNORF, DEPOSITKINDCODERF, CUSTOMERCODERF, DEPOSITCDRF, DEPOSITTOTALRF, OUTLINERF, ACCEPTANORDERSALESNORF, INPUTDEPOSITSECCDRF, DEPOSITDATERF, ADDUPSECCODERF, ADDUPADATERF, UPDATESECCDRF, DEPOSITKINDNAMERF, DEPOSITALLOWANCERF, DEPOSITALWCBLNCERF, DEPOSITAGENTCODERF, DEPOSITKINDDIVCDRF, FEEDEPOSITRF, DISCOUNTDEPOSITRF, CREDITORLOANCDRF, CREDITCOMPANYCODERF, DEPOSITRF, DRAFTDRAWINGDATERF, DRAFTPAYTIMELIMITRF, DEBITNOTELINKDEPONORF, LASTRECONCILEADDUPDTRF, AUTODEPOSITCDRF "
                //		  +", ACPODRDEPOSITRF, ACPODRCHARGEDEPOSITRF, ACPODRDISDEPOSITRF, VARIOUSCOSTDEPOSITRF, VARCOSTCHARGEDEPOSITRF, VARCOSTDISDEPOSITRF, ACPODRDEPOSITALWCRF, ACPODRDEPOALWCBLNCERF, VARCOSTDEPOALWCRF, VARCOSTDEPOALWCBLNCERF " // ����p�ʓ������ڂ̒ǉ� 20060220 Ins
                //		  +"FROM DEPSITMAINRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO", sqlConnection, sqlTransaction))
                #endregion

                #region �����}�X�^ SELECT��
                # region --- DEL 2008/04/25 M.Kubota ---
                // �� 2007.10.12 980081 c
                #region �����C�A�E�g(�R�����g�A�E�g)
                //string selectSql = "SELECT CREATEDATETIMERF"
                //                 + ",UPDATEDATETIMERF"
                //                 + ",ENTERPRISECODERF"
                //                 + ",FILEHEADERGUIDRF"
                //                 + ",UPDEMPLOYEECODERF"
                //                 + ",UPDASSEMBLYID1RF"
                //                 + ",UPDASSEMBLYID2RF"
                //                 + ",LOGICALDELETECODERF"
                //                 + ",DEPOSITDEBITNOTECDRF"
                //                 + ",DEPOSITSLIPNORF"
                //                 + ",ACCEPTANORDERNORF"
                //                 + ",SERVICESLIPCDRF"
                //                 + ",INPUTDEPOSITSECCDRF"
                //                 + ",ADDUPSECCODERF"
                //                 + ",UPDATESECCDRF"
                //                 + ",DEPOSITDATERF"
                //                 + ",ADDUPADATERF"
                //                 + ",DEPOSITKINDCODERF"
                //                 + ",DEPOSITKINDNAMERF"
                //                 + ",DEPOSITKINDDIVCDRF"
                //                 + ",DEPOSITTOTALRF"
                //                 + ",DEPOSITRF"
                //                 + ",FEEDEPOSITRF"
                //                 + ",DISCOUNTDEPOSITRF"
                //                 + ",REBATEDEPOSITRF"
                //                 + ",AUTODEPOSITCDRF"
                //                 + ",DEPOSITCDRF"
                //                 + ",CREDITORLOANCDRF"
                //                 + ",CREDITCOMPANYCODERF"
                //                 + ",DRAFTDRAWINGDATERF"
                //                 + ",DRAFTPAYTIMELIMITRF"
                //                 + ",DEPOSITALLOWANCERF"
                //                 + ",DEPOSITALWCBLNCERF"
                //                 + ",DEBITNOTELINKDEPONORF"
                //                 + ",LASTRECONCILEADDUPDTRF"
                //                 + ",DEPOSITAGENTCODERF"
                //                 + ",DEPOSITAGENTNMRF"
                //                 + ",CUSTOMERCODERF"
                //                 + ",CUSTOMERNAMERF"
                //                 + ",CUSTOMERNAME2RF"
                //                 + ",OUTLINERF"
                //                 + " FROM DEPSITMAINRF"
                //                 + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                //                 + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                //                 ;
                #endregion
                //string selectSql = "SELECT CREATEDATETIMERF"
                //                       + ",UPDATEDATETIMERF"
                //                       + ",ENTERPRISECODERF"
                //                       + ",FILEHEADERGUIDRF"
                //                       + ",UPDEMPLOYEECODERF"
                //                       + ",UPDASSEMBLYID1RF"
                //                       + ",UPDASSEMBLYID2RF"
                //                       + ",LOGICALDELETECODERF"
                //                       + ",ACPTANODRSTATUSRF"
                //                       + ",DEPOSITDEBITNOTECDRF"
                //                       + ",DEPOSITSLIPNORF"
                //                       + ",SALESSLIPNUMRF"
                //                       + ",INPUTDEPOSITSECCDRF"
                //                       + ",ADDUPSECCODERF"
                //                       + ",UPDATESECCDRF"
                //                       + ",SUBSECTIONCODERF"
                //                       + ",MINSECTIONCODERF"
                //                       + ",DEPOSITDATERF"
                //                       + ",ADDUPADATERF"
                //                       + ",DEPOSITKINDCODERF"
                //                       + ",DEPOSITKINDNAMERF"
                //                       + ",DEPOSITKINDDIVCDRF"
                //                       + ",DEPOSITTOTALRF"
                //                       + ",DEPOSITRF"
                //                       + ",FEEDEPOSITRF"
                //                       + ",DISCOUNTDEPOSITRF"
                //                       + ",AUTODEPOSITCDRF"
                //                       + ",DEPOSITCDRF"
                //                       + ",DRAFTDRAWINGDATERF"
                //                       + ",DRAFTPAYTIMELIMITRF"
                //                       + ",DRAFTKINDRF"
                //                       + ",DRAFTKINDNAMERF"
                //                       + ",DRAFTDIVIDERF"
                //                       + ",DRAFTDIVIDENAMERF"
                //                       + ",DRAFTNORF"
                //                       + ",DEPOSITALLOWANCERF"
                //                       + ",DEPOSITALWCBLNCERF"
                //                       + ",DEBITNOTELINKDEPONORF"
                //                       + ",LASTRECONCILEADDUPDTRF"
                //                       + ",DEPOSITAGENTCODERF"
                //                       + ",DEPOSITAGENTNMRF"
                //                       + ",DEPOSITINPUTAGENTCDRF"
                //                       + ",DEPOSITINPUTAGENTNMRF"
                //                       + ",CUSTOMERCODERF"
                //                       + ",CUSTOMERNAMERF"
                //                       + ",CUSTOMERNAME2RF"
                //                       + ",CUSTOMERSNMRF"
                //                       + ",CLAIMCODERF"
                //                       + ",CLAIMNAMERF"
                //                       + ",CLAIMNAME2RF"
                //                       + ",CLAIMSNMRF"
                //                       + ",OUTLINERF"
                //                       + ",BANKCODERF"
                //                       + ",BANKNAMERF"
                //                       + ",EDISENDDATERF"
                //                       + ",EDITAKEINDATERF"
                //                 + " FROM DEPSITMAINRF"
                //                 + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                //                 + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                //                 ;
                // �� 2007.10.12 980081 c
                #endregion
                //--- ADD 2008/04/25 M.Kubota --->>>
                string selectSql = string.Empty;
                selectSql += "SELECT" + Environment.NewLine;
                selectSql += "  DEP.CREATEDATETIMERF" + Environment.NewLine;
                selectSql += " ,DEP.UPDATEDATETIMERF" + Environment.NewLine;
                selectSql += " ,DEP.ENTERPRISECODERF" + Environment.NewLine;
                selectSql += " ,DEP.FILEHEADERGUIDRF" + Environment.NewLine;
                selectSql += " ,DEP.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectSql += " ,DEP.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectSql += " ,DEP.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectSql += " ,DEP.LOGICALDELETECODERF" + Environment.NewLine;
                selectSql += " ,DEP.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectSql += " ,DEP.DEPOSITDEBITNOTECDRF" + Environment.NewLine;
                selectSql += " ,DEP.DEPOSITSLIPNORF" + Environment.NewLine;
                selectSql += " ,DEP.SALESSLIPNUMRF" + Environment.NewLine;
                selectSql += " ,DEP.INPUTDEPOSITSECCDRF" + Environment.NewLine;
                selectSql += " ,DEP.ADDUPSECCODERF" + Environment.NewLine;
                selectSql += " ,DEP.UPDATESECCDRF" + Environment.NewLine;
                selectSql += " ,DEP.SUBSECTIONCODERF" + Environment.NewLine;
                selectSql += " ,DEP.INPUTDAYRF" + Environment.NewLine;  // ADD 2009/03/25
                selectSql += " ,DEP.DEPOSITDATERF" + Environment.NewLine;
                selectSql += " ,DEP.ADDUPADATERF" + Environment.NewLine;
                selectSql += " ,DEP.DEPOSITTOTALRF" + Environment.NewLine;
                selectSql += " ,DEP.DEPOSITRF" + Environment.NewLine;
                selectSql += " ,DEP.FEEDEPOSITRF" + Environment.NewLine;
                selectSql += " ,DEP.DISCOUNTDEPOSITRF" + Environment.NewLine;
                selectSql += " ,DEP.AUTODEPOSITCDRF" + Environment.NewLine;
                selectSql += " ,DEP.DRAFTDRAWINGDATERF" + Environment.NewLine;
                selectSql += " ,DEP.DRAFTKINDRF" + Environment.NewLine;
                selectSql += " ,DEP.DRAFTKINDNAMERF" + Environment.NewLine;
                selectSql += " ,DEP.DRAFTDIVIDERF" + Environment.NewLine;
                selectSql += " ,DEP.DRAFTDIVIDENAMERF" + Environment.NewLine;
                selectSql += " ,DEP.DRAFTNORF" + Environment.NewLine;
                selectSql += " ,DEP.DEPOSITALLOWANCERF" + Environment.NewLine;
                selectSql += " ,DEP.DEPOSITALWCBLNCERF" + Environment.NewLine;
                selectSql += " ,DEP.DEBITNOTELINKDEPONORF" + Environment.NewLine;
                selectSql += " ,DEP.LASTRECONCILEADDUPDTRF" + Environment.NewLine;
                selectSql += " ,DEP.DEPOSITAGENTCODERF" + Environment.NewLine;
                selectSql += " ,DEP.DEPOSITAGENTNMRF" + Environment.NewLine;
                selectSql += " ,DEP.DEPOSITINPUTAGENTCDRF" + Environment.NewLine;
                selectSql += " ,DEP.DEPOSITINPUTAGENTNMRF" + Environment.NewLine;
                selectSql += " ,DEP.CUSTOMERCODERF" + Environment.NewLine;
                selectSql += " ,DEP.CUSTOMERNAMERF" + Environment.NewLine;
                selectSql += " ,DEP.CUSTOMERNAME2RF" + Environment.NewLine;
                selectSql += " ,DEP.CUSTOMERSNMRF" + Environment.NewLine;
                selectSql += " ,DEP.CLAIMCODERF" + Environment.NewLine;
                selectSql += " ,DEP.CLAIMNAMERF" + Environment.NewLine;
                selectSql += " ,DEP.CLAIMNAME2RF" + Environment.NewLine;
                selectSql += " ,DEP.CLAIMSNMRF" + Environment.NewLine;
                selectSql += " ,DEP.OUTLINERF" + Environment.NewLine;
                selectSql += " ,DEP.BANKCODERF" + Environment.NewLine;
                selectSql += " ,DEP.BANKNAMERF" + Environment.NewLine;
                selectSql += "FROM" + Environment.NewLine;
                selectSql += "  DEPSITMAINRF AS DEP" + Environment.NewLine;
                selectSql += "WHERE" + Environment.NewLine;
                selectSql += "  DEP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                selectSql += "  AND DEP.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                selectSql += "  AND DEP.DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;
                //--- ADD 2008/04/25 M.Kubota ---<<<
                #endregion

                using (SqlCommand sqlCommand = new SqlCommand(selectSql, sqlConnection, sqlTransaction))
                // �� 20070124 18322 c
                {
                    # region --- DEL 2008/04/25 M.Kubota ---
                    //Prameter�I�u�W�F�N�g�̍쐬
                    //SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    //SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    //findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
                    //findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(DepositSlipNo);
                    # endregion

                    //--- ADD 2008/04/25 M.Kubota --->>>
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(AcptAnOdrStatus);
                    findDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(DepositSlipNo);

                    #if DEBUG
                    Console.Clear();
                    Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
                    #endif
                    //--- ADD 2008/04/25 M.Kubota ---<<<

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        # region --- DEL 2008/04/25 M.Kubota ---
# if false
                        // �� 20070124 18322 c MA.NS�p�ɕύX
                        #region �N���X�֑��
                        //depsitMainWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
                        //depsitMainWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
                        //depsitMainWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
                        //depsitMainWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        //depsitMainWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        //depsitMainWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        //depsitMainWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        //depsitMainWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
                        //depsitMainWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));
                        //depsitMainWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSLIPNORF"));
                        //depsitMainWork.DepositKindCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITKINDCODERF"));
                        //depsitMainWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERCODERF"));
                        //depsitMainWork.DepositCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITCDRF"));
                        //depsitMainWork.DepositTotal = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITTOTALRF"));
                        //depsitMainWork.Outline = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("OUTLINERF"));
                        //depsitMainWork.AcceptAnOrderSalesNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACCEPTANORDERSALESNORF"));
                        //depsitMainWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
                        //depsitMainWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("DEPOSITDATERF"));
                        //depsitMainWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDUPSECCODERF"));
                        //depsitMainWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ADDUPADATERF"));
                        //depsitMainWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDATESECCDRF"));
                        //depsitMainWork.DepositKindName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("DEPOSITKINDNAMERF"));
                        //depsitMainWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCERF"));
                        //depsitMainWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
                        //depsitMainWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("DEPOSITAGENTCODERF"));
                        //depsitMainWork.DepositKindDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITKINDDIVCDRF"));
                        //depsitMainWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("FEEDEPOSITRF"));
                        //depsitMainWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DISCOUNTDEPOSITRF"));
                        //depsitMainWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CREDITORLOANCDRF"));
                        //depsitMainWork.CreditCompanyCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("CREDITCOMPANYCODERF"));
                        //depsitMainWork.Deposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITRF"));
                        //depsitMainWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                        //depsitMainWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
                        //depsitMainWork.DebitNoteLinkDepoNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEBITNOTELINKDEPONORF"));
                        //depsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));
                        //depsitMainWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("AUTODEPOSITCDRF"));
                        //// 20060217 Ins Start >>>>>>>>>
                        //depsitMainWork.AcpOdrDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRDEPOSITRF"));
                        //depsitMainWork.AcpOdrChargeDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRCHARGEDEPOSITRF"));
                        //depsitMainWork.AcpOdrDisDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRDISDEPOSITRF"));
                        //depsitMainWork.VariousCostDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARIOUSCOSTDEPOSITRF"));
                        //depsitMainWork.VarCostChargeDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCOSTCHARGEDEPOSITRF"));
                        //depsitMainWork.VarCostDisDeposit = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCOSTDISDEPOSITRF"));
                        //depsitMainWork.AcpOdrDepositAlwc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRDEPOSITALWCRF"));
                        //depsitMainWork.AcpOdrDepoAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRDEPOALWCBLNCERF"));
                        //depsitMainWork.VarCostDepoAlwc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCOSTDEPOALWCRF"));
                        //depsitMainWork.VarCostDepoAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCOSTDEPOALWCBLNCERF"));
                        //// 20060217 Ins End <<<<<<<<<<<
                        #endregion

                        #region SQL�����f�[�^������}�X�^���[�N�֐ݒ�
                        // �쐬����
                        depsitMainWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        // �X�V����
                        depsitMainWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        // ��ƃR�[�h
                        depsitMainWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        // GUID
                        depsitMainWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        // �X�V�]�ƈ��R�[�h
                        depsitMainWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        // �X�V�A�Z���u��ID1
                        depsitMainWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        // �X�V�A�Z���u��ID2
                        depsitMainWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        // �_���폜�敪
                        depsitMainWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        // �����ԍ��敪
                        depsitMainWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));
                        // �����`�[�ԍ�
                        depsitMainWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
                        // �� 2007.10.12 980081 d
                        //// �󒍔ԍ�
                        //depsitMainWork.AcceptAnOrderNo       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACCEPTANORDERNORF"));
                        //// �T�[�r�X�`�[�敪
                        //depsitMainWork.ServiceSlipCd         = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SERVICESLIPCDRF"));
                        // �� 2007.10.12 980081 d
                        // �������͋��_�R�[�h
                        depsitMainWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
                        // �v�㋒�_�R�[�h
                        depsitMainWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        // �X�V���_�R�[�h
                        depsitMainWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                        // �������t
                        depsitMainWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));
                        // �v����t
                        depsitMainWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                        // ��������R�[�h
                        depsitMainWork.DepositKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITKINDCODERF"));
                        // �������햼��
                        depsitMainWork.DepositKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITKINDNAMERF"));
                        // ��������敪
                        depsitMainWork.DepositKindDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITKINDDIVCDRF"));
                        // �����v
                        depsitMainWork.DepositTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITTOTALRF"));
                        // �������z
                        depsitMainWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
                        // �萔�������z
                        depsitMainWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEDEPOSITRF"));
                        // �l�������z
                        depsitMainWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTDEPOSITRF"));
                        // �� 2007.10.12 980081 d
                        //// ���x�[�g�����z
                        //depsitMainWork.RebateDeposit         = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("REBATEDEPOSITRF"));
                        // �� 2007.10.12 980081 d
                        // ���������敪
                        depsitMainWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
                        // �a����敪
                        depsitMainWork.DepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITCDRF"));
                        // �� 2007.10.12 980081 d
                        //// �N���W�b�g�^���[���敪
                        //depsitMainWork.CreditOrLoanCd        = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CREDITORLOANCDRF"));
                        //// �N���W�b�g��ЃR�[�h
                        //depsitMainWork.CreditCompanyCode     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("CREDITCOMPANYCODERF"));
                        // �� 2007.10.12 980081 d
                        // ��`�U�o��
                        depsitMainWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                        // ��`�x������
                        depsitMainWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
                        // ���������z
                        depsitMainWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"));
                        // ���������c��
                        depsitMainWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
                        // �ԍ������A���ԍ�
                        depsitMainWork.DebitNoteLinkDepoNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKDEPONORF"));
                        // �ŏI�������݌v���
                        depsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));
                        // �����S���҃R�[�h
                        depsitMainWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
                        // �����S���Җ���
                        depsitMainWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
                        // ���Ӑ�R�[�h
                        depsitMainWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        // ���Ӑ於��
                        depsitMainWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                        // ���Ӑ於��2
                        depsitMainWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                        // �`�[�E�v
                        depsitMainWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                        // �� 2007.10.12 980081 a
                        depsitMainWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                        depsitMainWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                        depsitMainWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                        depsitMainWork.MinSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MINSECTIONCODERF"));
                        depsitMainWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                        depsitMainWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                        depsitMainWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                        depsitMainWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                        depsitMainWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                        depsitMainWork.DepositInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTCDRF"));
                        depsitMainWork.DepositInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTNMRF"));
                        depsitMainWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                        depsitMainWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                        depsitMainWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
                        depsitMainWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
                        depsitMainWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
                        depsitMainWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                        depsitMainWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
                        depsitMainWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                        // �� 2007.12.10 980081 c
                        //depsitMainWork.EdiTakeInDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                        depsitMainWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                        // �� 2007.12.10 980081 c
                        // �� 2007.10.12 980081 a
                        #endregion
                        // �� 20070124 18322 c
# endif
                        # endregion

                        this.ReadDataToDepsitMain(ref depsitMainWork, myReader);  //ADD 2008/04/25 M.Kubota
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    //--- ADD 2008/04/25 M.Kubota --->>>
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    //--- ADD 2008/04/25 M.Kubota ---<<<
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);                   //DEL 2008/04/25 M.Kubota
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);  //ADD 2008/04/25 M.Kubota
            }
            //--- ADD 2008/04/25 M.Kubota --->>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }
            }
            //--- ADD 2008/04/25 M.Kubota ---<<<

            //if (myReader != null && !myReader.IsClosed) myReader.Close();  //DEL 2008/04/25 M.Kubota

            return status;
        }

        /// <summary>
        /// ���������}�X�^�����擾���܂�
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="depositAlwWorkList">�����������</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���������}�X�^��������ԍ������Ƀf�[�^�擾���s���܂�</br>
        /// <br>Programmer : 95089 ���i�@��</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        //private int ReadDepositAlwWorkRec(string EnterpriseCode, int DepositSlipNo, out DepositAlwWork[] depositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)                  //DEL 2008/04/25 M.Kubota
        private int ReadDepositAlw(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out DepositAlwWork[] depositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2008/04/25 M.Kubota
        {
            //int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  //DEL 2008/04/25 M.Kubota
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;        //ADD 2008/04/25 M.Kubota
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame()); //ADD 2008/04/25 M.Kubota
            depositAlwWorkList = new DepositAlwWork[0];                       //ADD 2008/04/25 M.Kubota

            SqlDataReader myReader = null;

            ArrayList depositAlwWorkArrayList = new ArrayList();

            try
            {
                # region --- DEL 2008/04/25 M.Kubota ---
# if false
                // �� 20070124 18322 c MA.NS�p�ɕύX
                #region SF ���������}�X�^ SELECT���i�R�����g�A�E�g�j
                ////Select�R�}���h�̐���
                //using(SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, ADDUPSECCODERF, ACCEPTANORDERNORF, DEPOSITSLIPNORF, DEPOSITKINDCODERF, DEPOSITINPUTDATERF, DEPOSITALLOWANCERF, RECONCILEDATERF, RECONCILEADDUPDATERF, DEBITNOTEOFFSETCDRF, DEPOSITCDRF, CREDITORLOANCDRF "
                //		  +",ACPODRDEPOSITALWCRF, VARCOSTDEPOALWCRF "			// 20060220 Ins
                //		  +"FROM DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO", sqlConnection, sqlTransaction))
                #endregion

                #region ���������}�X�^ SELECT��
                // �� 2007.10.12 980081 c
                #region �����C�A�E�g(�R�����g�A�E�g)
                //string selectSql = "SELECT CREATEDATETIMERF"
                //                       + ",UPDATEDATETIMERF"
                //                       + ",ENTERPRISECODERF"
                //                       + ",FILEHEADERGUIDRF"
                //                       + ",UPDEMPLOYEECODERF"
                //                       + ",UPDASSEMBLYID1RF"
                //                       + ",UPDASSEMBLYID2RF"
                //                       + ",LOGICALDELETECODERF"
                //                       + ",INPUTDEPOSITSECCDRF"
                //                       + ",ADDUPSECCODERF"
                //                       + ",RECONCILEDATERF"
                //                       + ",RECONCILEADDUPDATERF"
                //                       + ",DEPOSITSLIPNORF"
                //                       + ",DEPOSITKINDCODERF"
                //                       + ",DEPOSITKINDNAMERF"
                //                       + ",DEPOSITALLOWANCERF"
                //                       + ",DEPOSITAGENTCODERF"
                //                       + ",DEPOSITAGENTNMRF"
                //                       + ",CUSTOMERCODERF"
                //                       + ",CUSTOMERNAMERF"
                //                       + ",CUSTOMERNAME2RF"
                //                       + ",ACCEPTANORDERNORF"
                //                       + ",SERVICESLIPCDRF"
                //                       + ",DEBITNOTEOFFSETCDRF"
                //                       + ",DEPOSITCDRF"
                //                       + ",CREDITORLOANCDRF"
                //                 +  " FROM DEPOSITALWRF"
                //                 + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                //                 +   " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                //                 ;
                #endregion
                string selectSql = "SELECT CREATEDATETIMERF"
                                       + ",UPDATEDATETIMERF"
                                       + ",ENTERPRISECODERF"
                                       + ",FILEHEADERGUIDRF"
                                       + ",UPDEMPLOYEECODERF"
                                       + ",UPDASSEMBLYID1RF"
                                       + ",UPDASSEMBLYID2RF"
                                       + ",LOGICALDELETECODERF"
                                       + ",INPUTDEPOSITSECCDRF"
                                       + ",ADDUPSECCODERF"
                                       + ",RECONCILEDATERF"
                                       + ",RECONCILEADDUPDATERF"
                                       + ",DEPOSITSLIPNORF"
                                       + ",DEPOSITKINDCODERF"
                                       + ",DEPOSITKINDNAMERF"
                                       + ",DEPOSITALLOWANCERF"
                                       + ",DEPOSITAGENTCODERF"
                                       + ",DEPOSITAGENTNMRF"
                                       + ",CUSTOMERCODERF"
                                       + ",CUSTOMERNAMERF"
                                       + ",CUSTOMERNAME2RF"
                                       + ",DEBITNOTEOFFSETCDRF"
                                       + ",DEPOSITCDRF"
                                       + ",ACPTANODRSTATUSRF"
                                       + ",SALESSLIPNUMRF"
                                 + " FROM DEPOSITALWRF"
                                 + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                                 + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                                 ;
                // �� 2007.10.12 980081 c
                #endregion
# endif
                # endregion

                # region [SELECT��]
                //--- ADD 2008/04/25 M.Kubota --->>>
                string selectSql = string.Empty;
                selectSql += "SELECT" + Environment.NewLine;
                selectSql += "  ALW.CREATEDATETIMERF" + Environment.NewLine;
                selectSql += " ,ALW.UPDATEDATETIMERF" + Environment.NewLine;
                selectSql += " ,ALW.ENTERPRISECODERF" + Environment.NewLine;
                selectSql += " ,ALW.FILEHEADERGUIDRF" + Environment.NewLine;
                selectSql += " ,ALW.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectSql += " ,ALW.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectSql += " ,ALW.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectSql += " ,ALW.LOGICALDELETECODERF" + Environment.NewLine;
                selectSql += " ,ALW.INPUTDEPOSITSECCDRF" + Environment.NewLine;
                selectSql += " ,ALW.ADDUPSECCODERF" + Environment.NewLine;
                selectSql += " ,ALW.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectSql += " ,ALW.SALESSLIPNUMRF" + Environment.NewLine;
                selectSql += " ,ALW.RECONCILEDATERF" + Environment.NewLine;
                selectSql += " ,ALW.RECONCILEADDUPDATERF" + Environment.NewLine;
                selectSql += " ,ALW.DEPOSITSLIPNORF" + Environment.NewLine;
                selectSql += " ,ALW.DEPOSITALLOWANCERF" + Environment.NewLine;
                selectSql += " ,ALW.DEPOSITAGENTCODERF" + Environment.NewLine;
                selectSql += " ,ALW.DEPOSITAGENTNMRF" + Environment.NewLine;
                selectSql += " ,ALW.CUSTOMERCODERF" + Environment.NewLine;
                selectSql += " ,ALW.CUSTOMERNAMERF" + Environment.NewLine;
                selectSql += " ,ALW.CUSTOMERNAME2RF" + Environment.NewLine;
                selectSql += " ,ALW.DEBITNOTEOFFSETCDRF" + Environment.NewLine;
                selectSql += "FROM" + Environment.NewLine;
                selectSql += "  DEPOSITALWRF AS ALW" + Environment.NewLine;
                selectSql += "WHERE" + Environment.NewLine;
                selectSql += "  ALW.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                selectSql += "  AND ALW.DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;

                // �󒍃X�e�[�^�X���ݒ肳��Ă���ꍇ�ɂ̂ݍi���ݏ����ɒǉ�����B
                // ���������C���ɂ���󒍃X�e�[�^�X�Ɠ��������ɂ���󒍃X�e�[�^�X�ł͈Ӗ����قȂ�A
                // �@�O�҂͎����������ɑ΂ƂȂ锄�`�̎󒍃X�e�[�^�X�݂̂��ݒ肳��A��҂͈����Ώ�
                // �@�̔��`�̎󒍃X�e�[�^�X���ݒ肳��Ă���B
                if (AcptAnOdrStatus != 0)
                {
                    selectSql += "  AND ALW.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                }

                //--- ADD 2008/04/25 M.Kubota ---<<<
                # endregion

                using (SqlCommand sqlCommand = new SqlCommand(selectSql, sqlConnection, sqlTransaction))
                // �� 20070124 18322 c
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
                    
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
                    findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(DepositSlipNo);

                    //--- ADD 2008/04/25 M.Kubota --->>>
                    if (AcptAnOdrStatus != 0)
                    {
                        SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                        findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(AcptAnOdrStatus);
                    }
                    //--- ADD 2008/04/25 M.Kubota ---<<<

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        # region --- DEL 2008/04/25 M.Kubota ---
# if false
                        DepositAlwWork depositAlwWork = new DepositAlwWork();

                        // �� 20070124 18322 c NA.NS�p�ɕύX
                        #region SF SQL�f�[�^����������}�X�^���[�N�֐ݒ�i�S�ăR�����g�A�E�g�j
                        //depositAlwWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
                        //depositAlwWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
                        //depositAlwWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
                        //depositAlwWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        //depositAlwWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        //depositAlwWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        //depositAlwWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        //depositAlwWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
                        //depositAlwWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERCODERF"));
                        //depositAlwWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ADDUPSECCODERF"));
                        //depositAlwWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACCEPTANORDERNORF"));
                        //depositAlwWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSLIPNORF"));
                        //depositAlwWork.DepositKindCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITKINDCODERF"));
                        //depositAlwWork.DepositInputDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("DEPOSITINPUTDATERF"));
                        //depositAlwWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCERF"));
                        //depositAlwWork.ReconcileDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("RECONCILEDATERF"));
                        //depositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("RECONCILEADDUPDATERF"));
                        //depositAlwWork.DebitNoteOffSetCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEBITNOTEOFFSETCDRF"));
                        //depositAlwWork.DepositCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITCDRF"));
                        //depositAlwWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CREDITORLOANCDRF"));
                        //// 20060220 Ins Start >>����p�ʓ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //depositAlwWork.AcpOdrDepositAlwc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRDEPOSITALWCRF"));
                        //depositAlwWork.VarCostDepoAlwc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCOSTDEPOALWCRF"));
                        //// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        #endregion

                        #region SQL�f�[�^����������}�X�^���[�N�֐ݒ�
                        // �쐬����
                        depositAlwWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        // �X�V����
                        depositAlwWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        // ��ƃR�[�h
                        depositAlwWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        // GUID
                        depositAlwWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        // �X�V�]�ƈ��R�[�h
                        depositAlwWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        // �X�V�A�Z���u��ID1
                        depositAlwWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        // �X�V�A�Z���u��ID2
                        depositAlwWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        // �_���폜�敪
                        depositAlwWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        // �������͋��_�R�[�h
                        depositAlwWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
                        // �v�㋒�_�R�[�h
                        depositAlwWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        // �����ݓ�
                        depositAlwWork.ReconcileDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RECONCILEDATERF"));
                        // �����݌v���
                        depositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RECONCILEADDUPDATERF"));
                        // �����`�[�ԍ�
                        depositAlwWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
                        // ��������R�[�h
                        depositAlwWork.DepositKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITKINDCODERF"));
                        // �������햼��
                        depositAlwWork.DepositKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITKINDNAMERF"));
                        // ���������z
                        depositAlwWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"));
                        // �����S���҃R�[�h
                        depositAlwWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
                        // �����S���Җ���
                        depositAlwWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
                        // ���Ӑ�R�[�h
                        depositAlwWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        // ���Ӑ於��
                        depositAlwWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                        // ���Ӑ於��2
                        depositAlwWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                        // �� 2007.10.12 980081 d
                        //// �󒍔ԍ�
                        //depositAlwWork.AcceptAnOrderNo     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACCEPTANORDERNORF"));
                        //// �T�[�r�X�`�[�敪
                        //depositAlwWork.ServiceSlipCd       = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SERVICESLIPCDRF"));
                        // �� 2007.10.12 980081 
                        // �ԓ`���E�敪
                        depositAlwWork.DebitNoteOffSetCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEOFFSETCDRF"));
                        // �a����敪
                        depositAlwWork.DepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITCDRF"));
                        // �� 2007.10.12 980081 d
                        //// �N���W�b�g�^���[���敪
                        //depositAlwWork.CreditOrLoanCd      = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CREDITORLOANCDRF"));
                        // �� 2007.10.12 980081 d
                        // �� 2007.10.12 980081 a
                        depositAlwWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                        depositAlwWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                        // �� 2007.10.12 980081 a
                        #endregion
                        // �� 20070124 18322 c
        
                        depositAlwWorkArrayList.Add(depositAlwWork);                        

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
# endif
                        # endregion

                        depositAlwWorkArrayList.Add(this.ReadDataToDepositAlw(myReader));  //ADD 2008/04/25 M.Kubota
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/25 M.Kubota
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);  //ADD 2008/04/25 M.Kubota
            }
            //--- ADD 2008/04/25 M.Kubota --->>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }

                if (ListUtils.IsNotEmpty(depositAlwWorkArrayList))
                {
                    depositAlwWorkList = (DepositAlwWork[])depositAlwWorkArrayList.ToArray(typeof(DepositAlwWork));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            //--- ADD 2008/04/25 M.Kubota ---<<<

            //--- DEL 2008/04/25 M.Kubota --->>>
            //if (myReader != null && !myReader.IsClosed) myReader.Close();
            //depositAlwWorkList = (DepositAlwWork[])depositAlwWorkArrayList.ToArray(typeof(DepositAlwWork));
            //--- DEL 2008/04/25 M.Kubota ---<<<

            return status;
        }

        //--- ADD 2008/04/25 M.Kubota --->>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="depsitMainWork"></param>
        /// <param name="depsitDtlArray"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        private int ReadDepsitDtl(DepsitMainWork depsitMainWork, out DepsitDtlWork[] depsitDtlArray, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            depsitDtlArray = new DepsitDtlWork[0];

            SqlCommand sqlCommand = null;
            SqlDataReader sqlDataReader = null;

            ArrayList depsitDtlList = new ArrayList();

            try
            {
                # region [SELECT��]
                //--- ADD 2008/04/25 M.Kubota --->>>
                string sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  DTL.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,DTL.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,DTL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,DTL.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,DTL.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,DTL.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,DTL.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,DTL.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,DTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += " ,DTL.DEPOSITSLIPNORF" + Environment.NewLine;
                sqlText += " ,DTL.DEPOSITROWNORF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDCODERF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDNAMERF" + Environment.NewLine;
                sqlText += " ,DTL.MONEYKINDDIVRF" + Environment.NewLine;
                sqlText += " ,DTL.DEPOSITRF" + Environment.NewLine;
                sqlText += " ,DTL.VALIDITYTERMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  DEPSITDTLRF AS DTL" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  DTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND DTL.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                sqlText += "  AND DTL.DEPOSITSLIPNORF = @FINDDEPOSITSLIPNO" + Environment.NewLine;
                //--- ADD 2008/04/25 M.Kubota ---<<<
                # endregion

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.EnterpriseCode);
                findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.AcptAnOdrStatus);

                if (depsitMainWork.DepositDebitNoteCd != 1)
                {
                    // 0:��, 2:�����̏ꍇ
                    findDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositSlipNo);
                }
                else
                {
                    // 1:�� �̏ꍇ
                    findDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DebitNoteLinkDepoNo); 
                }
                
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    DepsitDtlWork redDtlWork = this.ReadDataToDepsitDtl(sqlDataReader);

                    if (depsitMainWork.DepositDebitNoteCd == 1)
                    {
                        // 1:�� �̏ꍇ
                        redDtlWork.DepositSlipNo = depsitMainWork.DepositSlipNo;
                        redDtlWork.Deposit = redDtlWork.Deposit * -1;
                    }
                    
                    depsitDtlList.Add(redDtlWork);
                }

                if (depsitDtlList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    depsitDtlArray = (DepsitDtlWork[])depsitDtlList.ToArray(typeof(DepsitDtlWork));
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlDataReader != null)
                {
                    if (!sqlDataReader.IsClosed)
                    {
                        sqlDataReader.Close();
                    }

                    sqlDataReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlDataReader"></param>
        /// <returns></returns>
        private DepsitMainWork ReadDataToDepsitMain(SqlDataReader sqlDataReader)
        {
            DepsitMainWork depsitMainWork = new DepsitMainWork();
            this.ReadDataToDepsitMain(ref depsitMainWork, sqlDataReader);
            return depsitMainWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="depsitMainWork"></param>
        /// <param name="sqlDataReader"></param>
        /// <remarks>
        /// <br>Update Note: 2011/12/21 tianjw</br>
        /// <br>             Redmine#27390 ���_�Ǘ�/������̃`�F�b�N</br>
        /// </remarks>
        private void ReadDataToDepsitMain(ref DepsitMainWork depsitMainWork, SqlDataReader sqlDataReader)
        {
            # region [�����}�X�^ �Ǎ����ʊi�[]
            depsitMainWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("CREATEDATETIMERF"));                  // �쐬����
            depsitMainWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("UPDATEDATETIMERF"));                  // �X�V����
            depsitMainWork.EnterpriseCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ENTERPRISECODERF"));                             // ��ƃR�[�h
            depsitMainWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(sqlDataReader, sqlDataReader.GetOrdinal("FILEHEADERGUIDRF"));                               // GUID
            depsitMainWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDEMPLOYEECODERF"));                           // �X�V�]�ƈ��R�[�h
            depsitMainWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID1RF"));                             // �X�V�A�Z���u��ID1
            depsitMainWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID2RF"));                             // �X�V�A�Z���u��ID2
            depsitMainWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("LOGICALDELETECODERF"));                        // �_���폜�敪
            depsitMainWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("ACPTANODRSTATUSRF"));                            // �󒍃X�e�[�^�X
            depsitMainWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));                      // �����ԍ��敪
            depsitMainWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITSLIPNORF"));                                // �����`�[�ԍ�
            depsitMainWork.SalesSlipNum = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("SALESSLIPNUMRF"));                                 // ����`�[�ԍ�
            depsitMainWork.InputDepositSecCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("INPUTDEPOSITSECCDRF"));                       // �������͋��_�R�[�h
            depsitMainWork.AddUpSecCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ADDUPSECCODERF"));                                 // �v�㋒�_�R�[�h
            depsitMainWork.UpdateSecCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDATESECCDRF"));                                   // �X�V���_�R�[�h
            depsitMainWork.SubSectionCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SUBSECTIONCODERF"));                              // ����R�[�h
            depsitMainWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("INPUTDAYRF"));                           // ���͓��t  //ADD 2009/03/25
            depsitMainWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITDATERF"));                     // �������t
            depsitMainWork.PreDepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITDATERF"));                  // �������t // ADD 2011/12/21
            depsitMainWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("ADDUPADATERF"));                       // �v����t
            depsitMainWork.DepositTotal = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITTOTALRF"));                                  // �����v
            depsitMainWork.Deposit = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITRF"));                                            // �������z
            depsitMainWork.FeeDeposit = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("FEEDEPOSITRF"));                                      // �萔�������z
            depsitMainWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DISCOUNTDEPOSITRF"));                            // �l�������z
            depsitMainWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("AUTODEPOSITCDRF"));                                // ���������敪
            depsitMainWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTDRAWINGDATERF"));           // ��`�U�o��
            depsitMainWork.DraftKind = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTKINDRF"));                                        // ��`���
            depsitMainWork.DraftKindName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTKINDNAMERF"));                               // ��`��ޖ���
            depsitMainWork.DraftDivide = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTDIVIDERF"));                                    // ��`�敪
            depsitMainWork.DraftDivideName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTDIVIDENAMERF"));                           // ��`�敪����
            depsitMainWork.DraftNo = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DRAFTNORF"));                                           // ��`�ԍ�
            depsitMainWork.DepositAllowance = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITALLOWANCERF"));                          // ���������z
            depsitMainWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITALWCBLNCERF"));                          // ���������c��
            depsitMainWork.DebitNoteLinkDepoNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DEBITNOTELINKDEPONORF"));                    // �ԍ������A���ԍ�
            depsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));   // �ŏI�������݌v���
            depsitMainWork.DepositAgentCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITAGENTCODERF"));                         // �����S���҃R�[�h
            depsitMainWork.DepositAgentNm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITAGENTNMRF"));                             // �����S���Җ���
            depsitMainWork.DepositInputAgentCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITINPUTAGENTCDRF"));                   // �������͎҃R�[�h
            depsitMainWork.DepositInputAgentNm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITINPUTAGENTNMRF"));                   // �������͎Җ���
            depsitMainWork.CustomerCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("CUSTOMERCODERF"));                                  // ���Ӑ�R�[�h
            depsitMainWork.CustomerName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("CUSTOMERNAMERF"));                                 // ���Ӑ於��
            depsitMainWork.CustomerName2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("CUSTOMERNAME2RF"));                               // ���Ӑ於��2
            depsitMainWork.CustomerSnm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("CUSTOMERSNMRF"));                                   // ���Ӑ旪��
            depsitMainWork.ClaimCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("CLAIMCODERF"));                                        // ������R�[�h
            depsitMainWork.ClaimName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("CLAIMNAMERF"));                                       // �����於��
            depsitMainWork.ClaimName2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("CLAIMNAME2RF"));                                     // �����於��2
            depsitMainWork.ClaimSnm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("CLAIMSNMRF"));                                         // �����旪��
            depsitMainWork.Outline = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("OUTLINERF"));                                           // �`�[�E�v
            depsitMainWork.BankCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("BANKCODERF"));                                          // ��s�R�[�h
            depsitMainWork.BankName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("BANKNAMERF"));                                         // ��s����
            # endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlDataReader"></param>
        /// <returns></returns>
        private DepsitDtlWork ReadDataToDepsitDtl(SqlDataReader sqlDataReader)
        {
            DepsitDtlWork depsitDtlWork = new DepsitDtlWork();
            this.ReadDataToDepsitDtl(ref depsitDtlWork, sqlDataReader);
            return depsitDtlWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="depsitDtlWork"></param>
        /// <param name="sqlDataReader"></param>
        private void ReadDataToDepsitDtl(ref DepsitDtlWork depsitDtlWork, SqlDataReader sqlDataReader)
        {
            # region [�������׃f�[�^ �Ǎ����ʊi�[]
            depsitDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
            depsitDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("UPDATEDATETIMERF"));  // �X�V����
            depsitDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ENTERPRISECODERF"));             // ��ƃR�[�h
            depsitDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(sqlDataReader, sqlDataReader.GetOrdinal("FILEHEADERGUIDRF"));               // GUID
            depsitDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDEMPLOYEECODERF"));           // �X�V�]�ƈ��R�[�h
            depsitDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID1RF"));             // �X�V�A�Z���u��ID1
            depsitDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID2RF"));             // �X�V�A�Z���u��ID2
            depsitDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("LOGICALDELETECODERF"));        // �_���폜�敪
            depsitDtlWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("ACPTANODRSTATUSRF"));            // �󒍃X�e�[�^�X
            depsitDtlWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITSLIPNORF"));                // �����`�[�ԍ�
            depsitDtlWork.DepositRowNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITROWNORF"));                  // �����s�ԍ�
            depsitDtlWork.MoneyKindCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("MONEYKINDCODERF"));                // ����R�[�h
            depsitDtlWork.MoneyKindName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("MONEYKINDNAMERF"));               // ���햼��
            depsitDtlWork.MoneyKindDiv = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("MONEYKINDDIVRF"));                  // ����敪
            depsitDtlWork.Deposit = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITRF"));                            // �������z
            depsitDtlWork.ValidityTerm = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("VALIDITYTERMRF"));   // �L������
            # endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlDataReader"></param>
        /// <returns></returns>
        private DepositAlwWork ReadDataToDepositAlw(SqlDataReader sqlDataReader)
        {
            DepositAlwWork depositAlwWork = new DepositAlwWork();
            this.ReadDataToDepositAlw(ref depositAlwWork, sqlDataReader);
            return depositAlwWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="depositAlwWork"></param>
        /// <param name="sqlDataReader"></param>
        /// <returns></returns>
        private void ReadDataToDepositAlw(ref DepositAlwWork depositAlwWork, SqlDataReader sqlDataReader)
        {
            # region [���������}�X�^ �Ǎ����ʊi�[]
            depositAlwWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("CREATEDATETIMERF"));             // �쐬����
            depositAlwWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("UPDATEDATETIMERF"));             // �X�V����
            depositAlwWork.EnterpriseCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ENTERPRISECODERF"));                        // ��ƃR�[�h
            depositAlwWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(sqlDataReader, sqlDataReader.GetOrdinal("FILEHEADERGUIDRF"));                          // GUID
            depositAlwWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDEMPLOYEECODERF"));                      // �X�V�]�ƈ��R�[�h
            depositAlwWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID1RF"));                        // �X�V�A�Z���u��ID1
            depositAlwWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID2RF"));                        // �X�V�A�Z���u��ID2
            depositAlwWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("LOGICALDELETECODERF"));                   // �_���폜�敪
            depositAlwWork.InputDepositSecCd = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("INPUTDEPOSITSECCDRF"));                  // �������͋��_�R�[�h
            depositAlwWork.AddUpSecCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ADDUPSECCODERF"));                            // �v�㋒�_�R�[�h
            depositAlwWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("ACPTANODRSTATUSRF"));                       // �󒍃X�e�[�^�X
            depositAlwWork.SalesSlipNum = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("SALESSLIPNUMRF"));                            // ����`�[�ԍ�
            depositAlwWork.ReconcileDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("RECONCILEDATERF"));            // �����ݓ�
            depositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(sqlDataReader, sqlDataReader.GetOrdinal("RECONCILEADDUPDATERF"));  // �����݌v���
            depositAlwWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITSLIPNORF"));                           // �����`�[�ԍ�
            depositAlwWork.DepositAllowance = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITALLOWANCERF"));                     // ���������z
            depositAlwWork.DepositAgentCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITAGENTCODERF"));                    // �����S���҃R�[�h
            depositAlwWork.DepositAgentNm = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("DEPOSITAGENTNMRF"));                        // �����S���Җ���
            depositAlwWork.CustomerCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("CUSTOMERCODERF"));                             // ���Ӑ�R�[�h
            depositAlwWork.CustomerName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("CUSTOMERNAMERF"));                            // ���Ӑ於��
            depositAlwWork.CustomerName2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("CUSTOMERNAME2RF"));                          // ���Ӑ於��2
            depositAlwWork.DebitNoteOffSetCd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("DEBITNOTEOFFSETCDRF"));                   // �ԓ`���E�敪
            # endregion
        }
        //--- ADD 2008/04/25 M.Kubota ---<<<

        # endregion

        # region [�_���폜����]

        // �� 2008.01.11 980081 a
        /// <summary>
        /// �����_���폜����
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肵�������ԍ��̓������E�����������_���폜���s���܂�</br>
        /// <br>           : ���������f�[�^�̍폜�Ɏg�p���܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.11</br>
        /// </remarks>
        //public int LogicalDelete(string EnterpriseCode, int DepositSlipNo)  //DEL 2008/04/25 M.Kubota
        public int LogicalDelete(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus)  //ADD 2008/04/25 M.Kubota
        {
            byte[] depsitMainWorkByte;
            byte[] depositAlwWorkListByte;

            //int status = LogicalDelete(EnterpriseCode, DepositSlipNo, out depsitMainWorkByte, out depositAlwWorkListByte);  //DEL 2008/04/25 M.Kubota
            int status = LogicalDelete(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out depsitMainWorkByte, out depositAlwWorkListByte);    //ADD 2008/04/25 M.Kubota

            return status;
        }

        /// <summary>
        /// �����_���폜����
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肵�������ԍ��̓������E�����������_���폜���s���܂�</br>
        /// <br>           : ���������f�[�^�̍폜�Ɏg�p���܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.11</br>
        /// </remarks>
        //public int LogicalDelete(string EnterpriseCode, int DepositSlipNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)                     //DEL 2008/04/25 M.Kubota
        public int LogicalDelete(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2008/04/25 M.Kubota
        {
            byte[] depsitMainWorkByte;
            byte[] depositAlwWorkListByte;

            //int status = LogicalDelete(EnterpriseCode, DepositSlipNo, out depsitMainWorkByte, out depositAlwWorkListByte, ref sqlConnection, ref sqlTransaction);  //DEL 20008/04/25 M.Kubota
            int status = LogicalDelete(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out depsitMainWorkByte, out depositAlwWorkListByte, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

            return status;
        }

        /// <summary>
        /// �����_���폜����
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="RetDepsitMainWorkByte">�X�V�����f�[�^(�ԍ폜���̌������R�[�h)</param>
        /// <param name="RetDepositAlwWorkListByte">�X�V���������f�[�^(�ԍ폜���̌����������R�[�h)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肵�������ԍ��̓������E�����������_���폜���s���܂�</br>
        /// <br>           : ���������f�[�^�̍폜�Ɏg�p���܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.11</br>
        /// </remarks>
        //public int LogicalDelete(string EnterpriseCode, int DepositSlipNo, out byte[] RetDepsitMainWorkByte, out byte[] RetDepositAlwWorkListByte)  //DEL 2008/04/25 M.Kubota
        public int LogicalDelete(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out byte[] RetDepsitMainWorkByte, out byte[] RetDepositAlwWorkListByte)  //ADD 2008/04/25 M.Kubota
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            # region --- DEL 2008/04/25 M.Kubota ---
            # if false

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            
            DepsitMainWork depsitMainWork = null;
            DepositAlwWork[] depositAlwWorkList = null;

            RetDepsitMainWorkByte = null;
            RetDepositAlwWorkListByte = null;

            ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// �`�[�X�V�r�����䕔�i

            try
            {
                //���[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL�ڑ�
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // �����Ǎ��ݏ���
                //status = ReadDepsitMainWork(EnterpriseCode, DepositSlipNo, out depsitMainWork, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Rollback();
                    sqlConnection.Close();
                    sqlConnection.Dispose();

                    return status;
                }

                // �������E�敪���Q(���E�ςݍ�)�̏ꍇ�̓G���[
                if (depsitMainWork.DepositDebitNoteCd == 2)
                {
                    // UI�d�l��A�����X�V���ɔ�������\�������邽�߁A�r���G���[�ŕԂ�
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    return status;
                }

                //--- DEL 2008/04/25 M.Kubota --->>>
                // �X�V�����b�N����
                //int[] CustomerCodeList = { depsitMainWork.CustomerCode };
                //status = controlExclusiveOrderAccess.LockDB(EnterpriseCode, CustomerCodeList, null);	// ���Ӑ�ʃ��b�N��������
                //--- DEL 2008/04/25 M.Kubota ---<<<

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Rollback();
                    sqlConnection.Close();
                    sqlConnection.Dispose();

                    return status;
                }

                // �_���폜�𗧂Ă�
                if (depsitMainWork != null)
                    depsitMainWork.LogicalDeleteCode = 1;
                if (depositAlwWorkList != null)
                {
                    foreach (DepositAlwWork rec in depositAlwWorkList)
                    {
                        rec.LogicalDeleteCode = 1;
                    }
                }

                // �����}�X�^�X�V����
                status = LogicalDeleteDepsitMainWork(ref depsitMainWork, ref sqlConnection, ref sqlTransaction);

                // �ԓ����̍폜�̏ꍇ�A�����̓����E�������̍X�V���s��(�ԑ��E�̋敪�֘A���N���A����)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && depsitMainWork.DepositDebitNoteCd == 1)
                {
                    // ���������Ǎ��ݏ���(�ԑ��E����Ă��������`�[)
                    //status = ReadDepsitMainWork(EnterpriseCode, depsitMainWork.DebitNoteLinkDepoNo, out depsitMainWork, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota

                    // �X�V�]�ƈ��R�[�h ???
                    //				depsitMainWork.UpdEmployeeCode = UpdEmployeeCode;
                    // �����ԍ��敪���N���A
                    depsitMainWork.DepositDebitNoteCd = 0;
                    // ���������̐ԍ��A���ԍ����N���A
                    depsitMainWork.DebitNoteLinkDepoNo = 0;

                    if (depositAlwWorkList != null)
                    {
                        for (int ix = 0; ix < depositAlwWorkList.Length; ix++)
                        {
                            // �X�V�]�ƈ��R�[�h ???
                            //						depositAlwWorkArray[ix].UpdEmployeeCode = UpdEmployeeCode;
                            // �ԓ`���E�敪���N���A
                            depositAlwWorkList[ix].DebitNoteOffSetCd = 0;
                        }
                    }

                    // ���������}�X�^�X�V����
                    status = LogicalDeleteDepsitMainWork(ref depsitMainWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // XML�֕ϊ����A������̃o�C�i����
                        RetDepsitMainWorkByte = XmlByteSerializer.Serialize(depsitMainWork);
                        RetDepositAlwWorkListByte = XmlByteSerializer.Serialize(depositAlwWorkList);
                    }
                }


                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    sqlTransaction.Commit();
                else
                    sqlTransaction.Rollback();

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {

                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                // �X�V�����b�N����
                //controlExclusiveOrderAccess.UnlockDB();  //DEL 2008/04/25 M.Kubota
            }

            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
# endif
            # endregion

            //--- ADD 2008/04/25 M.Kubota --->>>
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            RetDepsitMainWorkByte = null;
            RetDepositAlwWorkListByte = null;

            SqlConnection sqlConnection = this.CreateSqlConnection(true);
            SqlTransaction sqlTransaction = this.CreateTransaction(ref sqlConnection);

            try
            {
                status = this.LogicalDelete(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out RetDepsitMainWorkByte, out RetDepositAlwWorkListByte, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Commit();
                }
                else
                {
                    sqlTransaction.Rollback();
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            //--- ADD 2008/04/25 M.Kubota ---<<<

            return status;
        }

        /// <summary>
        /// �����_���폜����
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="RetDepsitMainWorkByte">�X�V�����f�[�^(�ԍ폜���̌������R�[�h)</param>
        /// <param name="RetDepositAlwWorkListByte">�X�V���������f�[�^(�ԍ폜���̌����������R�[�h)</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肵�������ԍ��̓������E�����������_���폜���s���܂�</br>
        /// <br>           : ���������f�[�^�̍폜�Ɏg�p���܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.11</br>
        /// </remarks>
        //public int LogicalDelete(string EnterpriseCode, int DepositSlipNo, out byte[] RetDepsitMainWorkByte, out byte[] RetDepositAlwWorkListByte, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //DEL 2008/04/25 M.Kubota
        public int LogicalDelete(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out byte[] RetDepsitMainWorkByte, out byte[] RetDepositAlwWorkListByte, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2008/04/25 M.Kubota
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            DepsitMainWork depsitMainWork = null;
            DepositAlwWork[] depositAlwWorkList = null;

            DepsitDataWork depsitDataWork = null;      //ADD 2008/04/25 M.Kubota
            DepsitDtlWork[] depsitDtlWorkList = null;  //ADD 2008/04/25 M.Kubota

            RetDepsitMainWorkByte = null;
            RetDepositAlwWorkListByte = null;

            //ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// �`�[�X�V�r�����䕔�i  //DEL 2008/04/25 M.Kubota

            try
            {
                // �����Ǎ��ݏ���
                //status = ReadDepsitMainWork(EnterpriseCode, DepositSlipNo, out depsitMainWork, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota
                status = this.Read(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out depsitDataWork, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //ADD 2009/05/01

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //>>>2010/09/28
                // �����f�[�^������}�X�^�Ɠ������ׂɕ�������
                DepsitDataUtil.Division(depsitDataWork, out depsitMainWork, out depsitDtlWorkList);
                //<<<2010/09/28

                // �������E�敪���Q(���E�ςݍ�)�̏ꍇ�̓G���[
                if (depsitMainWork.DepositDebitNoteCd == 2)
                {
                    // UI�d�l��A�����X�V���ɔ�������\�������邽�߁A�r���G���[�ŕԂ�
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    return status;
                }

                //--- DEL 2008/04/25 M.Kubota --->>>
                // �X�V�����b�N����
                //int[] CustomerCodeList = { depsitMainWork.CustomerCode };
                //status = controlExclusiveOrderAccess.LockDB(EnterpriseCode, CustomerCodeList, null);	// ���Ӑ�ʃ��b�N��������
                //--- DEL 2008/04/25 M.Kubota ---<<<

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // �_���폜�𗧂Ă�
                if (depsitMainWork != null)
                    depsitMainWork.LogicalDeleteCode = 1;
                if (depositAlwWorkList != null)
                {
                    foreach (DepositAlwWork rec in depositAlwWorkList)
                    {
                        rec.LogicalDeleteCode = 1;
                    }
                }

                // �����}�X�^�X�V����
                status = LogicalDeleteDepsitMainWork(ref depsitMainWork, ref sqlConnection, ref sqlTransaction);

                // �ԓ����̍폜�̏ꍇ�A�����̓����E�������̍X�V���s��(�ԑ��E�̋敪�֘A���N���A����)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && depsitMainWork.DepositDebitNoteCd == 1)
                {
                    // ���������Ǎ��ݏ���(�ԑ��E����Ă��������`�[)
                    //status = ReadDepsitMainWork(EnterpriseCode, depsitMainWork.DebitNoteLinkDepoNo, out depsitMainWork, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota

                    // �X�V�]�ƈ��R�[�h ???
                    //				depsitMainWork.UpdEmployeeCode = UpdEmployeeCode;
                    // �����ԍ��敪���N���A
                    depsitMainWork.DepositDebitNoteCd = 0;
                    // ���������̐ԍ��A���ԍ����N���A
                    depsitMainWork.DebitNoteLinkDepoNo = 0;

                    if (depositAlwWorkList != null)
                    {
                        for (int ix = 0; ix < depositAlwWorkList.Length; ix++)
                        {
                            // �X�V�]�ƈ��R�[�h ???
                            //						depositAlwWorkArray[ix].UpdEmployeeCode = UpdEmployeeCode;
                            // �ԓ`���E�敪���N���A
                            depositAlwWorkList[ix].DebitNoteOffSetCd = 0;
                        }
                    }

                    // ���������}�X�^�X�V����
                    status = LogicalDeleteDepsitMainWork(ref depsitMainWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // XML�֕ϊ����A������̃o�C�i����
                        RetDepsitMainWorkByte = XmlByteSerializer.Serialize(depsitMainWork);
                        RetDepositAlwWorkListByte = XmlByteSerializer.Serialize(depositAlwWorkList);
                    }
                }

                // �_���폜�ɂ����链�Ӑ�}�X�^(�ϓ����)�̔��|�c���X�V�����ɂ��Ắc
                // �P.�_���폜�ƕ����폜�������[�g���Ŕ��f�o���Ȃ�
                // �Q.�_���폜�͓������͂���͎g�p����Ă��Ȃ�
                // �Ȃǂ̗��R�ɂ��A�����_�ł͔�Ή��Ƃ��Ă����B

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                // �X�V�����b�N����
                //controlExclusiveOrderAccess.UnlockDB();  //DEL 2008/04/25 M.Kubota
            }

            return status;
        }

        /// <summary>
        /// �����}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="depsitMainWork">�����}�X�^���</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���������X�V���܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.11</br>
        /// 
        private int LogicalDeleteDepsitMainWork(ref DepsitMainWork depsitMainWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            string updateText;

            // �X�V���t���擾
            DateTime Upd_UpdateDateTime = depsitMainWork.UpdateDateTime;

            //Select�R�}���h�̐���
            try
            {
                // ADD 2011/07/28 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) --------->>>>>>>
                // �����f�[�^���X�V����O�ɁA���M�ς݂̃`�F�b�N���s��
                if (!CheckDepsitMainSending(depsitMainWork))
                {
                    // �`�F�b�NNG
                    return STATUS_CHK_SEND_ERR;
                }
                // ADD 2011/07/28 qijh SCM�Ή� - ���_�Ǘ�(10704767-00) ---------<<<<<<<

                #region �����}�X�^ UPDATE��
                // �X�V�����X�V�����L�[�ɕt�����čX�V�i���t�r�������j
                updateText = "UPDATE DEPSITMAINRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE"
                           + " WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME"
                             + " AND ENTERPRISECODERF=@FINDENTERPRISECODE"
                             + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                             ;
                #endregion

                //�X�V�w�b�_����ݒ�
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)depsitMainWork;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);

                using (SqlCommand sqlCommand = new SqlCommand(updateText, sqlConnection, sqlTransaction))
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaUpdateDateTime = sqlCommand.Parameters.Add("@FINDUPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(Upd_UpdateDateTime);
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.EnterpriseCode);
                    findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.DepositSlipNo);


                    #region �����}�X�^ Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    // �쐬����
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    // �X�V����
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    // ��ƃR�[�h
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    // GUID
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    // �X�V�]�ƈ��R�[�h
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    // �X�V�A�Z���u��ID1
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    // �X�V�A�Z���u��ID2
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    // �_���폜�敪
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    #endregion

                    #region �����}�X�^ Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    // �쐬����
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitMainWork.CreateDateTime);
                    // �X�V����
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depsitMainWork.UpdateDateTime);
                    // ��ƃR�[�h
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.EnterpriseCode);
                    // GUID
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depsitMainWork.FileHeaderGuid);
                    // �X�V�]�ƈ��R�[�h
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdEmployeeCode);
                    // �X�V�A�Z���u��ID1
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdAssemblyId1);
                    // �X�V�A�Z���u��ID2
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depsitMainWork.UpdAssemblyId2);
                    // �_���폜�敪
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depsitMainWork.LogicalDeleteCode);
                    #endregion

                    int count = sqlCommand.ExecuteNonQuery();

                    // �X�V�����������ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    if (count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/25 M.Kubota
                //--- ADD 2008/04/25 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/04/25 M.Kubota ---<<<
            }

            if (myReader != null && !myReader.IsClosed) myReader.Close();

            return status;
        }
        // �� 2008.01.11 980081 a

        # endregion

        # region [�폜����]
        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肵�������ԍ��̓������E�����������폜���s���܂�</br>
        /// <br>Programmer : 95089 ���i�@��</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        //public int Delete(string EnterpriseCode, int DepositSlipNo)                     //DEL 2008/04/25 M.Kubota
        public int Delete(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus)  //ADD 2008/04/25 M.Kubota
        {
            byte[] depsitMainWorkByte;
            byte[] depositAlwWorkListByte;

            //int status = Delete(EnterpriseCode, DepositSlipNo, out depsitMainWorkByte, out depositAlwWorkListByte);                 //DEL 2008/04/25 M.Kubota
            int status = Delete(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out depsitMainWorkByte, out depositAlwWorkListByte);  //ADD 2008/04/25 M.Kubota

            return status;
        }

        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="RetDepsitDataWorkByte">�X�V�����f�[�^(�ԍ폜���̌������R�[�h)</param>
        /// <param name="RetDepositAlwWorkListByte">�X�V���������f�[�^(�ԍ폜���̌����������R�[�h)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肵�������ԍ��̓������E�����������폜���s���܂�</br>
        /// <br>Programmer : 95089 ���i�@��</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        public int Delete(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out byte[] RetDepsitDataWorkByte, out byte[] RetDepositAlwWorkListByte)  //ADD 2008/04/25 M.Kubota
        {
            return DeleteProc(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out RetDepsitDataWorkByte, out RetDepositAlwWorkListByte);
        }

        /// <summary>
		/// �����폜����
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
		/// <param name="RetDepsitDataWorkByte">�X�V�����f�[�^(�ԍ폜���̌������R�[�h)</param>
		/// <param name="RetDepositAlwWorkListByte">�X�V���������f�[�^(�ԍ폜���̌����������R�[�h)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�������ԍ��̓������E�����������폜���s���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		//public int Delete(string EnterpriseCode, int DepositSlipNo, out byte[] RetDepsitMainWorkByte, out byte[] RetDepositAlwWorkListByte)                     //DEL 2008/04/25 M.Kubota
        private int DeleteProc(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out byte[] RetDepsitDataWorkByte, out byte[] RetDepositAlwWorkListByte)  //ADD 2008/04/25 M.Kubota
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			DepsitMainWork depsitMainWork = null;
            DepositAlwWork[] depositAlwWorkList = null;

            DepsitDataWork depsitDataWork = null;      //ADD 2008/04/25 M.Kubota
            DepsitDtlWork[] depsitDtlWorkList = null;  //ADD 2008/04/25 M.Kubota

			//RetDepsitMainWorkByte = null;  //DEL 2008/04/25 M.Kubota
            RetDepsitDataWorkByte = null;    //ADD 2008/04/25 M.Kubota
			RetDepositAlwWorkListByte = null;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/04/25 M.Kubota

			//ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// �`�[�X�V�r�����䕔�i  //DEL 2008/04/25 M.Kubota

            try
            {
                //���[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                //--- DEL 2008/04/25 M.Kubota --->>>
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;

                //SQL�ڑ�
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();
                //sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                //--- DEL 2008/04/25 M.Kubota ---<<<

                //--- ADD 2008/04/25 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);
                if (sqlConnection == null)
                {
                    return status;
                }

                sqlTransaction = this.CreateTransaction(ref sqlConnection);
                //--- ADD 2008/04/25 M.Kubota ---<<<

                // �����Ǎ��ݏ���
                //status = ReadDepsitMainWork(EnterpriseCode, DepositSlipNo, out depsitMainWork, out depositAlwWorkList, ref sqlConnection,ref sqlTransaction);         //DEL 2008/04/25 M.Kubota
                status = this.Read(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out depsitDataWork, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Rollback();
                    sqlConnection.Close();
                    sqlConnection.Dispose();

                    return status;
                }

                //�V�X�e�����b�N(���_) //2009/1/27 Add sakurai
                int st = 0;
                ShareCheckInfo info = new ShareCheckInfo();
                info.Keys.Add(depsitDataWork.EnterpriseCode, ShareCheckType.Section, depsitDataWork.AddUpSecCode, "");
                st = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                if (st != 0) return st;

                // �����f�[�^������}�X�^�Ɠ������ׂɕ�������
                DepsitDataUtil.Division(depsitDataWork, out depsitMainWork, out depsitDtlWorkList);  //ADD 2008/04/25 M.Kubota

                // �������E�敪���Q(���E�ςݍ�)�̏ꍇ�̓G���[
                if (depsitMainWork.DepositDebitNoteCd == 2)
                {
                    //					base.WriteErrorLog(null,"�v���O�����G���[�B�ԓ������ꂽ�`�[�̍폜�͍s���܂���");
                    // UI�d�l��A�����X�V���ɔ�������\�������邽�߁A�r���G���[�ŕԂ�
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    return status;
                }

                //--- DEL 2008/04/25 M.Kubota --->>>
                // �X�V�����b�N����
                //int[] CustomerCodeList = { depsitMainWork.CustomerCode };
                //status = controlExclusiveOrderAccess.LockDB(EnterpriseCode, CustomerCodeList, null);	// ���Ӑ�ʃ��b�N��������

                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    sqlTransaction.Rollback();
                //    sqlConnection.Close();
                //    sqlConnection.Dispose();

                //    return status;
                //}
                //--- DEL 2008/04/25 M.Kubota ---<<<

                // �_���폜�𗧂Ă�i�X�V���������ŕ����폜�����E�����X�V���������s�����j
                if (depsitMainWork != null)
                    depsitMainWork.LogicalDeleteCode = 1;
                if (depositAlwWorkList != null)
                {
                    foreach (DepositAlwWork rec in depositAlwWorkList)
                    {
                        rec.LogicalDeleteCode = 1;
                    }
                }

                // �����}�X�^�X�V����
                //status = WriteDepsitMainWork(ref depsitMainWork, ref depositAlwWorkList, ref sqlConnection,ref sqlTransaction);               //DEL 2008/04/25 M.Kubota
                status = this.Write(ref depsitMainWork, ref depsitDtlWorkList, ref depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

                // �ԓ����̍폜�̏ꍇ�A�����̓����E�������̍X�V���s��(�ԑ��E�̋敪�֘A���N���A����)
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && depsitMainWork.DepositDebitNoteCd == 1)
                {
                    // ���������Ǎ��ݏ���(�ԑ��E����Ă��������`�[)
                    //status = ReadDepsitMainWork(EnterpriseCode, depsitMainWork.DebitNoteLinkDepoNo, out depsitMainWork, out depositAlwWorkList, ref sqlConnection,ref sqlTransaction);  //DEL 2008/04/25 M.Kubota
                    status = this.Read(EnterpriseCode, depsitMainWork.DebitNoteLinkDepoNo, depsitMainWork.AcptAnOdrStatus, out depsitDataWork, out depositAlwWorkList, ref sqlConnection,ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

                    // �����f�[�^������}�X�^�Ɠ������ׂɕ�������
                    DepsitDataUtil.Division(depsitDataWork, out depsitMainWork, out depsitDtlWorkList);  //ADD 2008/04/25 M.Kubota

                    // �X�V�]�ƈ��R�[�h ???
                    //				depsitMainWork.UpdEmployeeCode = UpdEmployeeCode;
                    // �����ԍ��敪���N���A
                    depsitMainWork.DepositDebitNoteCd = 0;
                    // ���������̐ԍ��A���ԍ����N���A
                    depsitMainWork.DebitNoteLinkDepoNo = 0;

                    if (depositAlwWorkList != null)
                    {
                        for (int ix = 0; ix < depositAlwWorkList.Length; ix++)
                        {
                            // �X�V�]�ƈ��R�[�h ???
                            //						depositAlwWorkArray[ix].UpdEmployeeCode = UpdEmployeeCode;
                            // �ԓ`���E�敪���N���A
                            depositAlwWorkList[ix].DebitNoteOffSetCd = 0;
                        }
                    }

                    // ���������}�X�^�X�V����
                    //status = WriteDepsitMainWork(ref depsitMainWork, ref depositAlwWorkList, ref sqlConnection,ref sqlTransaction);               //DEL 2008/04/25 M.Kubota
                    status = this.Write(ref depsitMainWork, ref depsitDtlWorkList, ref depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // XML�֕ϊ����A������̃o�C�i����
                        //RetDepsitMainWorkByte = XmlByteSerializer.Serialize(depsitMainWork);  //DEL 2008/04/25 M.Kubota
                        //--- ADD 2008/04/25 M.Kubota --->>>
                        DepsitDataUtil.Union(out depsitDataWork, depsitMainWork, depsitDtlWorkList);
                        RetDepsitDataWorkByte = XmlByteSerializer.Serialize(depsitDataWork);
                        //--- ADD 2008/04/25 M.Kubota ---<<<
                        RetDepositAlwWorkListByte = XmlByteSerializer.Serialize(depositAlwWorkList);
                    }
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    //�V�X�e�����b�N���� //2009/1/27 Add sakurai
                    status = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    sqlTransaction.Commit();
                else
                    sqlTransaction.Rollback();

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);
                base.WriteSQLErrorLog(ex, errmsg, ex.Number);  //DEL 2008/04/25 M.Kubota
            }
            //--- ADD 2008/04/25 M.Kubota --->>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            //--- ADD 2008/04/25 M.Kubota ---<<<
			finally
			{
				// �X�V�����b�N����
				//controlExclusiveOrderAccess.UnlockDB();  //DEL 2008/04/25 M.Kubota

                //--- ADD 2008/04/25 M.Kubota --->>>
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                //--- ADD 2008/04/25 M.Kubota ---<<<
			}

            //--- DEL 2008/04/25 M.Kubota --->>>
            //if(sqlConnection != null)
            //{
            //    sqlConnection.Close();
            //    sqlConnection.Dispose();
            //}
            //--- DEL 2008/04/25 M.Kubota ---<<<

			return status;
        }

        /// <summary>
        /// ���������}�X�^�����폜���܂�
        /// </summary>
        /// <param name="depositAlwWork">�����������</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���������}�X�^���̍폜���s���܂�</br>
        /// <br>Programmer : 95089 ���i�@��</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        public int DeleteDepositAlwWorkRec(ref DepositAlwWork depositAlwWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteDepositAlwWorkRecProc(ref depositAlwWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���������}�X�^�����폜���܂�
        /// </summary>
        /// <param name="depositAlwWork">�����������</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���������}�X�^���̍폜���s���܂�</br>
        /// <br>Programmer : 95089 ���i�@��</br>
        /// <br>Date       : 2005.08.11</br>
        /// </remarks>
        private int DeleteDepositAlwWorkRecProc(ref DepositAlwWork depositAlwWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;

            //Select�R�}���h�̐���
            try
            {
                // �� 20070124 18322 c MA.NS�p�ɕύX
                #region SF ���������}�X�^ DELETE���i�S�ăR�����g�A�E�g�j
                //using(SqlCommand sqlCommand = new SqlCommand("DELETE FROM DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO  AND ADDUPSECCODERF=@ADDUPSECCODE", sqlConnection,sqlTransaction))
                //{
                //
                //	//Prameter�I�u�W�F�N�g�̍쐬
                //	SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                //	SqlParameter findParaAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                //	SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                //	SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
                //	SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                //
                //	//Parameter�I�u�W�F�N�g�֒l�ݒ�
                //	findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
                //	findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
                //	findParaCustomerCode.Value  = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
                //	findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
                //	findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);
                //
                //	sqlCommand.ExecuteNonQuery();
                //}
                #endregion

                string deleteSql = "DELETE FROM DEPOSITALWRF"
                                      + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                    // �� 2007.10.12 980081 c
                    //+ " AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO"
                                        + " AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS"
                                        + " AND SALESSLIPNUMRF=@FINDSALESSLIPNUM"
                    // �� 2007.10.12 980081 c
                                        + " AND CUSTOMERCODERF=@FINDCUSTOMERCODE"
                                        + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                                        + " AND ADDUPSECCODERF=@ADDUPSECCODE"
                                 ;
                using (SqlCommand sqlCommand = new SqlCommand(deleteSql, sqlConnection, sqlTransaction))
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    // �� 2007.10.12 980081 c
                    //SqlParameter findParaAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                    SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findParaSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                    // �� 2007.10.12 980081 c
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
                    // �� 2007.10.12 980081 c
                    //findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
                    findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcptAnOdrStatus);
                    findParaSalesSlipNum.Value = SqlDataMediator.SqlSetString(depositAlwWork.SalesSlipNum);
                    // �� 2007.10.12 980081 c
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
                    findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);

                    sqlCommand.ExecuteNonQuery();
                }
                // �� 20070124 18322 c

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/25 M.Kubota
                //--- ADD 2008/04/25 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/04/25 M.Kubota ---<<<
            }

            if (myReader != null && !myReader.IsClosed) myReader.Close();

            return status;
        }

        # endregion

        # region [�ԓ`����]

        /// <summary>
		/// �ԓ����쐬����
		/// </summary>
		/// <param name="mode">0:�ԓ����쐬 1:�ԓ����E�V�������쐬</param>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="UpdateSecCd">�X�V���_�R�[�h</param>
		/// <param name="DepositAgentCode">�����S���҃R�[�h</param>
		/// <param name="DepositAgentNm">�����S���Җ�</param>
		/// <param name="AddUpADate">�v���</param>
		/// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�������ԍ��̐ԓ����쐬�������s���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.26</br>
        /// <br></br>
        /// <br>Update Note: 2007.01.24 18322 T.Kimura MA.NS�p�ɕύX</br>
        /// <br></br>
		/// </remarks>
        // �� 20070124 18322 c MA.NS�p�ɕύX
		//public int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, int DepositSlipNo )
		//public int RedCreate(int mode, string EnterpriseCode, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo )                    //DEL 2008/04/25 M.Kubota
        public int RedCreate(int mode, string EnterpriseCode, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, int AcptAnOdrStatus)  //ADD 2008/04/25 M.Kubota
        // �� 20070124 18322 c
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());  //ADD 2008/04/25 M.Kubota

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

            try
            {
                //--- DEL 2008/04/25 M.Kubota --->>>
                //���[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;

                //SQL�ڑ�
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();
                //sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                //--- DEL 2008/04/25 M.Kubota ---<<<
                //--- ADD 2008/04/25 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);
                if (sqlConnection == null)
                {
                    return status;
                }

                sqlTransaction = this.CreateTransaction(ref sqlConnection);
                //--- ADD 2008/04/25 M.Kubota ---<<<

                // �� 20070124 18322 c MA.NS�p�ɕύX
                // // �ԓ`�쐬����
                //status = RedCreateProc(mode, EnterpriseCode, DepositCd, UpdateSecCd, DepositAgentCode, AddUpADate, DepositSlipNo , ref sqlConnection, ref sqlTransaction);

                // �ԓ`�쐬����
                //status = RedCreateProc(mode, EnterpriseCode, DepositCd, UpdateSecCd, DepositAgentCode, DepositAgentNm, AddUpADate, DepositSlipNo, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota
                status = RedCreateProc(mode, EnterpriseCode, UpdateSecCd, DepositAgentCode, DepositAgentNm, AddUpADate, DepositSlipNo, AcptAnOdrStatus, ref sqlConnection, ref sqlTransaction);               //ADD 2008/04/25 M.Kubota
                // �� 20070124 18322 c

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    sqlTransaction.Commit();
                else
                    sqlTransaction.Rollback();

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/25 M.Kubota
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);  //ADD 2008/04/25 M.Kubota
            }
            //--- ADD 2008/04/25 M.Kubota --->>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            //--- ADD 2008/04/25 M.Kubota ---<<

            //--- DEL 2008/04/2 M.Kubota --->>>
            //if(sqlConnection != null)
            //{
            //    sqlConnection.Close();
            //    sqlConnection.Dispose();
            //}
            //--- DEL 2008/04/2 M.Kubota ---<<<

			return status;
		}

		/// <summary>
		/// �ԓ����쐬����
		/// </summary>
		/// <param name="mode">0:�ԓ����쐬 1:�ԓ����E�V�������쐬</param>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="UpdateSecCd">�X�V���_�R�[�h</param>
		/// <param name="DepositAgentCode">�����S���҃R�[�h</param>
		/// <param name="DepositAgentNm">�����S���Җ�</param>
		/// <param name="AddUpADate">�v���</param>
		/// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
		/// <param name="RetDepsitDataWorkListByte">�X�V����MT���R�[�h</param>
		/// <param name="RetDepositAlwWorkListByte">�X�V��������MT���R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�������ԍ��̐ԓ����쐬�������s���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.26</br>
        /// <br></br>
        /// <br>Update Note: 2007.01.24 18322 T.Kimura MA.NS�p�ɕύX</br>
        /// <br></br>
		/// </remarks>
        // �� 20070124 18322 c MA.NS�p�ɕύX
		//public int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, int DepositSlipNo, out byte[] RetDepsitDataWorkListByte, out byte[] RetDepositAlwWorkListByte )
		//public int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, out byte[] RetDepsitMainWorkListByte, out byte[] RetDepositAlwWorkListByte )  //DEL 2008/04/25 M.Kubota
        public int RedCreate(int mode, string EnterpriseCode, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, int AcptAnOdrStatus, out byte[] RetDepsitDataWorkListByte, out byte[] RetDepositAlwWorkListByte)                    //ADD 2008/04/25 M.Kubota
        // �� 20070124 18322 c
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			//DepsitMainWork[] RetDepsitMainWorkList = null;  //DEL 2008/04/25 M.Kubota
            DepsitDataWork[] RetDepsitDataWorkList = null;    //ADD 2008/04/25 M.Kubota
			DepositAlwWork[] RetDepositAlwWorkList = null; 

			//RetDepsitMainWorkListByte = null;  //DEL 2008/04/25 M.Kubota
            RetDepsitDataWorkListByte = null;    //ADD 2008/04/25 M.Kubota
            RetDepositAlwWorkListByte = null;

			try 
			{	
				//--- DEL 2008/04/25 M.Kubota --->>>
                //���[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                //SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                //string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                //if (connectionText == null || connectionText == "") return status;

				//SQL�ڑ�
                //sqlConnection = new SqlConnection(connectionText);
                //sqlConnection.Open();
                //sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                //--- DEL 2008/04/25 M.Kubota ---<<<
                //--- ADD 2008/04/25 M.Kubota --->>>
                sqlConnection = this.CreateSqlConnection(true);

                if (sqlConnection == null)
                {
                    return status;
                }

                sqlTransaction = this.CreateTransaction(ref sqlConnection);
                //--- ADD 2008/04/25 M.Kubota ---<<<

                // �� 20070124 18322 c MA.NS�p�ɕύX
				//// �ԓ`�쐬����
				//status = RedCreateProc(mode, EnterpriseCode, DepositCd, UpdateSecCd, DepositAgentCode, AddUpADate, DepositSlipNo ,  out RetDepsitMainWorkList, out RetDepositAlwWorkList ,ref sqlConnection, ref sqlTransaction);

				// �ԓ`�쐬����
                //--- DEL 2008/04/25 M.Kubota --->>>
                //status = RedCreateProc(     mode
                //                      ,     EnterpriseCode
                //                      ,     DepositCd
                //                      ,     UpdateSecCd
                //                      ,     DepositAgentCode
                //                      ,     DepositAgentNm
                //                      ,     AddUpADate
                //                      ,     DepositSlipNo
                //                      , out RetDepsitMainWorkList
                //                      , out RetDepositAlwWorkList
                //                      , ref sqlConnection
                //                      , ref sqlTransaction);
                // �� 20070124 18322 c
                //--- DEL 2008/04/25 M.Kubota ---<<<

                status = RedCreateProc(mode, EnterpriseCode, UpdateSecCd, DepositAgentCode, DepositAgentNm, AddUpADate, DepositSlipNo, AcptAnOdrStatus, out RetDepsitDataWorkList, out RetDepositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

				if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					sqlTransaction.Commit();

					// XML�֕ϊ����A������̃o�C�i����
					//RetDepsitMainWorkListByte = XmlByteSerializer.Serialize(RetDepsitMainWorkList);  //DEL 2008/04/25 M.Kubota
                    RetDepsitDataWorkListByte = XmlByteSerializer.Serialize(RetDepsitDataWorkList);
					RetDepositAlwWorkListByte = XmlByteSerializer.Serialize(RetDepositAlwWorkList);
				}
				else
				{
					sqlTransaction.Rollback();
				}

			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(sqlConnection != null)
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}

			return status;
        }

        /// <summary>
        /// �ԓ����쐬����
        /// </summary>
        /// <param name="mode">0:�ԓ����쐬 1:�ԓ����E�V�������쐬</param>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="UpdateSecCd">�X�V���_�R�[�h</param>
        /// <param name="DepositAgentCode">�����S���҃R�[�h</param>
        /// <param name="DepositAgentNm">�����S���Җ�</param>
        /// <param name="AddUpADate">�v���</param>
        /// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍔ԍ�</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肵�������ԍ��̓������E�����������폜���s���܂�</br>
        /// <br>Programmer : 95089 ���i�@��</br>
        /// <br>Date       : 2005.08.26</br>
        /// <br></br>
        /// <br>Update Note: 2007.01.24 18322 T.Kimura MA.NS�p�ɕύX</br>
        /// <br></br>
        /// </remarks>
        // �� 20070124 18322 c MA.NS�p�ɕύX
        //public int RedCreateProc(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, int DepositSlipNo, ref SqlConnection sqlConnection,ref SqlTransaction sqlTransaction)
        //public int RedCreateProc(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //DEL 2008/04/25 M.Kubota
        public int RedCreateProc(int mode, string EnterpriseCode, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, int AcptAnOdrStatus, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)                   //ADD 2008/04/25 M.Kubota
        // �� 20070124 18322 c
        {
            //DepsitMainWork[] RetDepsitMainWorkList = null;  //DEL 2008/04/25 M.Kubota
            DepsitDataWork[] RetDepsitDataWorkList = null;    //ADD 2008/04/25 M.Kubota
            DepositAlwWork[] RetDepositAlwWorkList = null;

            // �� 20070124 18322 c MA.NS�p�ɕύX
            //int status = RedCreateProc(mode, EnterpriseCode, DepositCd, UpdateSecCd, DepositAgentCode, AddUpADate, DepositSlipNo, out RetDepsitMainWorkList, out RetDepositAlwWorkList, ref sqlConnection,ref sqlTransaction);

            int status = RedCreateProc(mode
                                      , EnterpriseCode
                                      //, DepositCd                  //DEL 2008/04/25 M.Kubota
                                      , UpdateSecCd
                                      , DepositAgentCode
                                      , DepositAgentNm
                                      , AddUpADate
                                      , DepositSlipNo
                                      , AcptAnOdrStatus              //ADD 2008/04/25 M.Kubota
                                      //, out RetDepsitMainWorkList  //DEL 2008/04/25 M.Kubota
                                      , out RetDepsitDataWorkList    //ADD 2008/04/25 M.Kubota
                                      , out RetDepositAlwWorkList
                                      , ref sqlConnection
                                      , ref sqlTransaction);
            // �� 20070124 18322 c

            return status;
        }

        // �� 20070124 18322 c MA.NS�p�ɕύX
        /// <summary>
        /// �ԓ����쐬����
        /// </summary>
        /// <param name="mode">0:�ԓ����쐬 1:�ԓ����E�V�������쐬</param>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="UpdateSecCd">�X�V���_�R�[�h</param>
        /// <param name="DepositAgentCode">�����S���҃R�[�h</param>
        /// <param name="DepositAgentNm">�����S���Җ�</param>
        /// <param name="AddUpADate">�v���</param>
        /// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="RetDepsitDataWorkList">�X�V����MT���R�[�h</param>
        /// <param name="RetDepositAlwWorkList">�X�V��������MT���R�[�h</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���p�����[�^�Őԓ����`�[�̍쐬���s���܂�</br>
        /// <br>Note       : ���ԓ����쐬���A�a����������ʏ�ԓ����̍쐬���s���܂�(�����`�������ē����̍X�V���Ɏg�p)</br>
        /// <br>Programmer : 95089 ���i�@��</br>
        /// <br>Date       : 2005.08.26</br>
        /// <br>Update Note: 2010/12/20 ����� PM.NS��Q���ǑΉ�(12����)
        /// <br>             �ԓ`�̓������׃f�[�^���쐬����B</br>
        /// </remarks>
        //public int RedCreateProc(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, int DepositSlipNo, out DepsitMainWork[] RetDepsitMainWorkList, out DepositAlwWork[] RetDepositAlwWorkList, ref SqlConnection sqlConnection,ref SqlTransaction sqlTransaction)
        //public int RedCreateProc(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, out DepsitMainWork[] RetDepsitMainWorkList, out DepositAlwWork[] RetDepositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //DEL 2008/04/25 M.Kubota
        public int RedCreateProc(int mode, string EnterpriseCode, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, int AcptAnOdrStatus, out DepsitDataWork[] RetDepsitDataWorkList, out DepositAlwWork[] RetDepositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)  //ADD 2008/04/25 M.Kubota
        // �� 20070124 18322 c
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            DepsitMainWork depsitMainWork = null;
            DepositAlwWork[] depositAlwWorkList = null;
            DepsitDataWork depsitDataWork = null;      //ADD 2008/04/25 M.Kubota
            DepsitDtlWork[] depsitDtlWorkList = null;  //ADD 2008/04/25 M.Kubota
            
            //RetDepsitMainWorkList = null;  //DEL 2008/04/25 M.Kubota
            RetDepsitDataWorkList = null;    //ADD 2008/04/25 M.Kubota
            RetDepositAlwWorkList = null;

            //ControlExclusiveOrderAccess controlExclusiveOrderAccess = new ControlExclusiveOrderAccess();	// �`�[�X�V�r�����䕔�i  //DEL 2008/04/25 M.Kubota

            try
            {
                // ���������Ǎ��ݏ���
                //status = ReadDepsitMainWork(EnterpriseCode, DepositSlipNo, out depsitMainWork, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);        //DEL 2008/04/25 M.Kubota
                status = this.Read(EnterpriseCode, DepositSlipNo, AcptAnOdrStatus, out depsitDataWork, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                DepsitDataUtil.Division(depsitDataWork, out depsitMainWork, out depsitDtlWorkList);  //ADD 2008/04/25 M.Kubota

                //--- DEL 2008/04/25 M.Kubota --->>>
                // �X�V�����b�N����
                //int[] CustomerCodeList = { depsitMainWork.CustomerCode };
                //status = controlExclusiveOrderAccess.LockDB(depsitMainWork.EnterpriseCode, CustomerCodeList, null);	// ���Ӑ�ʃ��b�N��������
                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    return status;
                //}
                //--- DEL 2008/04/25 M.Kubota ---<<<

                // ?????????
                // �����Őԓ`�`�F�b�N�I�I�I�I�I�I>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                if (depsitMainWork.DepositDebitNoteCd != 0)
                {
                    // �Ǎ��ݓ����f�[�^�̓����ԍ��敪���O�F���@�ȊO�̂Ƃ��A�r���G���[��Ԃ�
                    // (�ԓ����E���E�ςݍ������̐ԓ��������͕s�I�E�E���[���X�V�\��������̂Ŕr���G���[)
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    return status;
                }
                // <<<<<<<<<<<<<<<<<<<<<

                ArrayList ar = new ArrayList();
                DepositAlwWork[] Red_depositAlwWorkList = (DepositAlwWork[])ar.ToArray(typeof(DepositAlwWork));

                // �� 20070124 18322 c MA.NS�p�ɕύX
                //// ���������f�[�^�����ɐԓ������쐬
                //DepsitMainWork Red_depsitMainWork = CreateRedDepsitProc(DepositCd, UpdateSecCd, DepositAgentCode, AddUpADate,  depsitMainWork);

                // ���������f�[�^�����ɐԓ������쐬
                //--- DEL 2008/04/258 M.Kubota --->>>
                //DepsitMainWork Red_depsitMainWork = CreateRedDepsitProc(DepositCd
                //                                                       , UpdateSecCd
                //                                                       , DepositAgentCode
                //                                                       , DepositAgentNm
                //                                                       , AddUpADate
                //                                                       , depsitMainWork);
                // �� 20070124 18322 c
                //--- DEL 2008/04/258 M.Kubota ---<<<

                DepsitMainWork Red_depsitMainWork = CreateRedDepsitProc(UpdateSecCd, DepositAgentCode, DepositAgentNm, AddUpADate, depsitMainWork);  //ADD 2008/04/25 M.Kubota

                // �����Ɉ����f�[�^������ꍇ
                if (depositAlwWorkList != null && depositAlwWorkList.Length > 0)
                {
                    Red_depsitMainWork.LastReconcileAddUpDt = AddUpADate;							// �ŏI�������݌v������v���

                    // �� 20070124 18322 c MA.NS�p�ɕύX
                    //// �������������f�[�^�����ɐԓ����������쐬
                    //Red_depositAlwWorkList = CreateRedDepositAlwWorkProc(DepositCd, UpdateSecCd, DepositAgentCode, AddUpADate, depositAlwWorkArray);

                    // �������������f�[�^�����ɐԓ����������쐬
                    //--- DEL 2008/04/25 M.Kubota --->>>
                    //Red_depositAlwWorkList = CreateRedDepositAlwWorkProc(DepositCd
                    //                                                    , UpdateSecCd
                    //                                                    , DepositAgentCode
                    //                                                    , DepositAgentNm
                    //                                                    , AddUpADate
                    //                                                    , depositAlwWorkList);
                    // �� 20070124 18322 c
                    //--- DEL 2008/04/25 M.Kubota ---<<<

                    Red_depositAlwWorkList = CreateRedDepositAlwWorkProc(UpdateSecCd, DepositAgentCode, DepositAgentNm, AddUpADate, depositAlwWorkList);  //ADD 2008/04/25 M.Kubota
                }
                else
                {
                    Red_depsitMainWork.LastReconcileAddUpDt = DateTime.MinValue;					// �ŏI�������݌v���������
                }

                // �ԓ����f�[�^�̍X�V����
                //status = WriteDepsitMainWork(ref Red_depsitMainWork, ref Red_depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota

                //--- ADD 2008/04/25 M.Kubota --->>>
                DepsitDtlWork[] Red_depsitDtlWorkList = null;

                // --- ADD 2010/12/20 ---------->>>>>
                // �ԓ`�̓������׃f�[�^���쐬����B
                Red_depsitDtlWorkList = this.CreateRedDepsitDtlWork(Red_depsitMainWork.DepositSlipNo, depsitDtlWorkList);
                // --- ADD 2010/12/20  ----------<<<<<

                status = this.Write(ref Red_depsitMainWork, ref Red_depsitDtlWorkList, ref Red_depositAlwWorkList, ref sqlConnection, ref sqlTransaction);

                // �ԓ`�̓������ׂ�UI���ŕ\���p�Ɏg�p����ׂɍ쐬����ADB�ɂ͐ԓ`���ׂ͓o�^���Ȃ�
                Red_depsitDtlWorkList = this.CreateRedDepsitDtlWork(Red_depsitMainWork.DepositSlipNo, depsitDtlWorkList); 
                //--- ADD 2008/04/25 M.Kubota ---<<<

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                # region --- pending 2008/04/25 M.Kubota ---
                # if false
                DepsitMainWork Black_depsitMainWork = null;
                DepsitDtlWork[] Black_depsitDtlWorkList = null;  //ADD 2008/04/25 M.Kubota
                DepositAlwWork[] Black_depositAlwWorkList = null;

                // �V���쐬���[�h��
                if (mode == 1)
                {
                    ArrayList ar2 = new ArrayList();
                    Black_depositAlwWorkList = (DepositAlwWork[])ar2.ToArray(typeof(DepositAlwWork));

                    // �� 20070124 18322 c MA.NS�p�ɕύX
                    //// ���������f�[�^�����ɐV���������쐬
                    //Black_depsitMainWork = CreateNewBlackDepsitProc(UpdateSecCd, DepositAgentCode, AddUpADate,  depsitMainWork);

                    // ���������f�[�^�����ɐV���������쐬
                    Black_depsitMainWork = CreateNewBlackDepsitProc(UpdateSecCd
                                                                   , DepositAgentCode
                                                                   , DepositAgentNm
                                                                   , AddUpADate
                                                                   , depsitMainWork);
                    // �� 20070124 18322 c

                    // �V�������f�[�^�̍X�V����
                    //status = WriteDepsitMainWork(ref Black_depsitMainWork, ref Black_depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //DEL 2008/04/25 M.Kubota
                    //status = this.Write(ref 
                }
                # endif
                # endregion

                // �����̓����E�������̕ύX

                // �X�V�]�ƈ��R�[�h ???
                //				depsitMainWork.UpdEmployeeCode = UpdEmployeeCode;
                // �����ԍ��敪��2:���E�ςݍ����Z�b�g
                depsitMainWork.DepositDebitNoteCd = 2;

                // ���������̐ԍ��A���ԍ��ɓ����ԍ�������
                depsitMainWork.DebitNoteLinkDepoNo = Red_depsitMainWork.DepositSlipNo;

                if (depositAlwWorkList != null)
                {
                    for (int ix = 0; ix < depositAlwWorkList.Length; ix++)
                    {
                        // �X�V�]�ƈ��R�[�h ???
                        //						depositAlwWorkArray[ix].UpdEmployeeCode = UpdEmployeeCode;
                        // �ԓ`���E�敪��2:���E�ςݍ����Z�b�g
                        depositAlwWorkList[ix].DebitNoteOffSetCd = 2;
                    }
                }

                // ���������}�X�^�X�V����
                //status = WriteDepsitMainWork(ref depsitMainWork, ref depositAlwWorkList, ref sqlConnection, ref sqlTransaction);              //DEL 2008/04/25 M.Kubota
                status = this.Write(ref depsitMainWork, ref depsitDtlWorkList, ref depositAlwWorkList, ref sqlConnection, ref sqlTransaction);  //ADD 2008/04/25 M.Kubota

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �߂�l�Ƃ��čX�V�f�[�^��Ԃ�
                    //ArrayList RetDepsitMainWorkArrayList = new ArrayList();  //DEL 2008/04/25 M.Kubota
                    ArrayList RetDepsitDataWorkArrayList = new ArrayList();    //ADD 2008/04/25 M.Kubota
                    ArrayList RetDepositAlwWorkArrayList = new ArrayList();

                    //--- DEL 2008/04/25 M.Kubota --->>>
                    //if (depsitMainWork != null && depsitMainWork.DepositSlipNo != 0)
                    //{
                    //    RetDepsitMainWorkArrayList.Add(depsitMainWork);
                    //}
                    //if (Red_depsitMainWork != null && Red_depsitMainWork.DepositSlipNo != 0)
                    //{
                    //    RetDepsitMainWorkArrayList.Add(Red_depsitMainWork);
                    //}
                    //if (Black_depsitMainWork != null && Black_depsitMainWork.DepositSlipNo != 0)
                    //{
                    //    RetDepsitMainWorkArrayList.Add(Black_depsitMainWork);
                    //}
                    //--- DEL 2008/04/25 M.Kubota ---<<<

                    //--- ADD 2008/04/25 M.Kubota --->>>
                    DepsitDataUtil.Union(out depsitDataWork, depsitMainWork, depsitDtlWorkList);

                    if (depsitDataWork != null && depsitDataWork.DepositSlipNo != 0)
                    {
                        RetDepsitDataWorkArrayList.Add(depsitDataWork);
                    }

                    DepsitDataWork Red_depsitDataWork = null;
                    DepsitDataUtil.Union(out Red_depsitDataWork, Red_depsitMainWork, Red_depsitDtlWorkList);

                    if (Red_depsitDataWork != null && Red_depsitDataWork.DepositSlipNo != 0)
                    {
                        RetDepsitDataWorkArrayList.Add(Red_depsitDataWork);
                    }
                    //--- ADD 2008/04/25 M.Kubota ---<<<

                    if (depositAlwWorkList != null && depositAlwWorkList.Length != 0)
                    {
                        foreach (DepositAlwWork rec in depositAlwWorkList)
                        {
                            RetDepositAlwWorkArrayList.Add(rec);

                        }
                    }
                    if (Red_depositAlwWorkList != null && Red_depositAlwWorkList.Length != 0)
                    {
                        foreach (DepositAlwWork rec in Red_depositAlwWorkList)
                        {
                            RetDepositAlwWorkArrayList.Add(rec);

                        }
                    }
                    //--- DEL 2008/04/25 M.Kubota --->>>
                    //if (Black_depositAlwWorkList != null && Black_depositAlwWorkList.Length != 0)
                    //{
                    //    foreach (DepositAlwWork rec in Black_depositAlwWorkList)
                    //    {
                    //        RetDepositAlwWorkArrayList.Add(rec);
                    //    }
                    //}
                    //--- DEL 2008/04/25 M.Kubota ---<<<

                    //RetDepsitMainWorkList = (DepsitMainWork[])RetDepsitMainWorkArrayList.ToArray(typeof(DepsitMainWork));  //DEL 2008/04/25 M.Kubota
                    RetDepsitDataWorkList = (DepsitDataWork[])RetDepsitDataWorkArrayList.ToArray(typeof(DepsitDataWork));    //ADD 2008/04/25 M.Kubota
                    RetDepositAlwWorkList = (DepositAlwWork[])RetDepositAlwWorkArrayList.ToArray(typeof(DepositAlwWork));
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);  //DEL 2008/04/25 M.Kubota
                //--- ADD 2008/04/25 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/04/25 M.Kubota ---<<<
            }
            finally
            {
                // �X�V�����b�N����
                //controlExclusiveOrderAccess.UnlockDB();  //DEL 2008/04/25 M.Kubota
            }

            return status;
        }

        /// <summary>
        /// �ԓ�����񐶐�����
        /// </summary>
        /// <param name="updateSecCd">�X�V���_</param>
        /// <param name="depositAgentCode">�ԓ����S���҃R�[�h</param>
        /// <param name="depositAgentNm">�ԓ����S���Җ���</param>
        /// <param name="addUpADate">�ԓ����v���</param>
        /// <param name="depsitMainWork">�����������</param>
        /// <returns>�ԓ������</returns>
        //--- DEL 2008/04/25 M.Kubota --->>>
        //public DepsitMainWork CreateRedDepsitProc(int depositCd
        //                                         , string updateSecCd
        //                                         , string depositAgentCode
        //                                         , string depositAgentNm
        //                                         , DateTime addUpADate
        //                                         , DepsitMainWork depsitMainWork)
        //--- DEL 2008/04/25 M.Kubota ---<<<
        private DepsitMainWork CreateRedDepsitProc(string updateSecCd, string depositAgentCode, string depositAgentNm, DateTime addUpADate, DepsitMainWork depsitMainWork)  //ADD 2008/04/25 M.Kubota
        {
            DepsitMainWork newDepsitMainWork = new DepsitMainWork();

            # region --- DEL 2008/04/25 M.Kubota ---
            # if false
            // ��ƃR�[�h
            newDepsitMainWork.EnterpriseCode = depsitMainWork.EnterpriseCode;
            // �X�V�]�ƈ��R�[�h<-�����S���҃R�[�h ???
            newDepsitMainWork.UpdEmployeeCode = depositAgentCode;
            // �X�V�A�Z���u��ID1
            newDepsitMainWork.UpdAssemblyId1 = depsitMainWork.UpdAssemblyId1;
            // �X�V�A�Z���u��ID2
            newDepsitMainWork.UpdAssemblyId2 = depsitMainWork.UpdAssemblyId2;
            // �_���폜�敪
            newDepsitMainWork.LogicalDeleteCode = 0;
            // �ԍ��敪���P�F��
            newDepsitMainWork.DepositDebitNoteCd = 1;
            // �����ԍ�
            newDepsitMainWork.DepositSlipNo = 0;
            // �� 2007.10.12 980081 d
            //// �󒍔ԍ�
            //newDepsitMainWork.AcceptAnOrderNo = depsitMainWork.AcceptAnOrderNo;
            //// �T�[�r�X�`�[�敪
            //newDepsitMainWork.ServiceSlipCd = depsitMainWork.ServiceSlipCd;
            // �� 2007.10.12 980081 d
            // �������͋��_�R�[�h
            newDepsitMainWork.InputDepositSecCd = depsitMainWork.InputDepositSecCd;
            // �v�㋒�_�R�[�h
            newDepsitMainWork.AddUpSecCode = depsitMainWork.AddUpSecCode;
            // �X�V���_�R�[�h???
            newDepsitMainWork.UpdateSecCd = updateSecCd;
            // �������t???
            // �� 2008.03.17 980081 c
            //newDepsitMainWork.DepositDate = addUpADate;
            newDepsitMainWork.DepositDate = DateTime.Now;
            // �� 2008.03.17 980081 c
            // �v����t???
            newDepsitMainWork.AddUpADate = addUpADate;
            // ��������R�[�h
            newDepsitMainWork.DepositKindCode = depsitMainWork.DepositKindCode;
            // �������햼��
            newDepsitMainWork.DepositKindName = depsitMainWork.DepositKindName;
            // ��������敪
            newDepsitMainWork.DepositKindDivCd = depsitMainWork.DepositKindDivCd;
            // �����v
            newDepsitMainWork.DepositTotal = depsitMainWork.DepositTotal * -1;
            // �������z
            newDepsitMainWork.Deposit = depsitMainWork.Deposit * -1;
            // �萔�������z
            newDepsitMainWork.FeeDeposit = depsitMainWork.FeeDeposit * -1;
            // �l�������z
            newDepsitMainWork.DiscountDeposit = depsitMainWork.DiscountDeposit * -1;
            // �� 2007.10.12 980081 d
            //// ���x�[�g�����z
            //newDepsitMainWork.RebateDeposit = depsitMainWork.RebateDeposit * -1;
            // �� 2007.10.12 980081 d
            // ���������敪
            newDepsitMainWork.AutoDepositCd = depsitMainWork.AutoDepositCd;
            // �a����敪
            newDepsitMainWork.DepositCd = depositCd;
            // �� 2007.10.12 980081 d
            //// �N���W�b�g�^���[���敪
            //newDepsitMainWork.CreditOrLoanCd = depsitMainWork.CreditOrLoanCd;
            //// �N���W�b�g��ЃR�[�h
            //newDepsitMainWork.CreditCompanyCode = depsitMainWork.CreditCompanyCode;
            // �� 2007.10.12 980081 d
            // ��`�U�o��
            newDepsitMainWork.DraftDrawingDate = depsitMainWork.DraftDrawingDate;
            // ��`�x������
            newDepsitMainWork.DraftPayTimeLimit = depsitMainWork.DraftPayTimeLimit;
            // ���������z
            newDepsitMainWork.DepositAllowance = depsitMainWork.DepositAllowance * -1;
            // ���������c��
            newDepsitMainWork.DepositAlwcBlnce = depsitMainWork.DepositAlwcBlnce * -1;
            // �ԍ������A���ԍ��i�����������ԍ����Z�b�g�j
            newDepsitMainWork.DebitNoteLinkDepoNo = depsitMainWork.DepositSlipNo;
            // �ŏI�������݌v����i����U�����j
            newDepsitMainWork.LastReconcileAddUpDt = DateTime.MinValue;
            // �����S���҃R�[�h???
            newDepsitMainWork.DepositAgentCode = depositAgentCode;
            // �����S���Җ���
            newDepsitMainWork.DepositAgentNm = depositAgentNm;
            // ���Ӑ�R�[�h
            newDepsitMainWork.CustomerCode = depsitMainWork.CustomerCode;
            // ���Ӑ於��
            newDepsitMainWork.CustomerName = depsitMainWork.CustomerName;
            // ���Ӑ於��2
            newDepsitMainWork.CustomerName2 = depsitMainWork.CustomerName2;
            // �`�[�E�v
            newDepsitMainWork.Outline = depsitMainWork.Outline;
            // �� 2007.10.12 980081 a
            newDepsitMainWork.AcptAnOdrStatus = depsitMainWork.AcptAnOdrStatus;
            newDepsitMainWork.SalesSlipNum = depsitMainWork.SalesSlipNum;
            newDepsitMainWork.SubSectionCode = depsitMainWork.SubSectionCode;
            newDepsitMainWork.MinSectionCode = depsitMainWork.MinSectionCode;
            newDepsitMainWork.DraftKind = depsitMainWork.DraftKind;
            newDepsitMainWork.DraftKindName = depsitMainWork.DraftKindName;
            newDepsitMainWork.DraftDivide = depsitMainWork.DraftDivide;
            newDepsitMainWork.DraftDivideName = depsitMainWork.DraftDivideName;
            newDepsitMainWork.DraftNo = depsitMainWork.DraftNo;
            newDepsitMainWork.DepositInputAgentCd = depsitMainWork.DepositInputAgentCd;
            newDepsitMainWork.DepositInputAgentNm = depsitMainWork.DepositInputAgentNm;
            newDepsitMainWork.CustomerSnm = depsitMainWork.CustomerSnm;
            newDepsitMainWork.ClaimCode = depsitMainWork.ClaimCode;
            newDepsitMainWork.ClaimName = depsitMainWork.ClaimName;
            newDepsitMainWork.ClaimName2 = depsitMainWork.ClaimName2;
            newDepsitMainWork.ClaimSnm = depsitMainWork.ClaimSnm;
            newDepsitMainWork.BankCode = depsitMainWork.BankCode;
            newDepsitMainWork.BankName = depsitMainWork.BankName;
            newDepsitMainWork.EdiSendDate = depsitMainWork.EdiSendDate;
            newDepsitMainWork.EdiTakeInDate = depsitMainWork.EdiTakeInDate;
            // �� 2007.10.12 980081 a
            # endif
            # endregion

            //--- ADD 2008/04/25 M.Kubota --->>>
            newDepsitMainWork.EnterpriseCode = depsitMainWork.EnterpriseCode;                    // ��ƃR�[�h
            newDepsitMainWork.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;  // �_���폜�敪
            newDepsitMainWork.AcptAnOdrStatus = depsitMainWork.AcptAnOdrStatus;                  // �󒍃X�e�[�^�X
            newDepsitMainWork.DepositDebitNoteCd = 1;                                            // �����ԍ��敪 1:�ԓ`
            newDepsitMainWork.DepositSlipNo = 0;                                                 // �����`�[�ԍ� ����ɍ̔Ԃ����
            newDepsitMainWork.SalesSlipNum = depsitMainWork.SalesSlipNum;                        // ����`�[�ԍ�
            newDepsitMainWork.InputDepositSecCd = depsitMainWork.InputDepositSecCd;              // �������͋��_�R�[�h
            newDepsitMainWork.AddUpSecCode = depsitMainWork.AddUpSecCode;                        // �v�㋒�_�R�[�h
            newDepsitMainWork.UpdateSecCd = updateSecCd;                                         // �X�V���_�R�[�h
            newDepsitMainWork.SubSectionCode = depsitMainWork.SubSectionCode;                    // ����R�[�h
            newDepsitMainWork.InputDay = DateTime.Now;                                          // ���͓��t  //ADD 2009/03/25
            // --- UPD 2010/12/20 ---------->>>>>
            //newDepsitMainWork.DepositDate = DateTime.Now;                                        // �������t
            newDepsitMainWork.DepositDate = addUpADate;                                        // �������t
            // --- UPD 2010/12/20  ----------<<<<<
            newDepsitMainWork.AddUpADate = addUpADate;                                           // �v����t
            newDepsitMainWork.DepositTotal = depsitMainWork.DepositTotal * -1;                   // �����v
            newDepsitMainWork.Deposit = depsitMainWork.Deposit * -1;                             // �������z
            newDepsitMainWork.FeeDeposit = depsitMainWork.FeeDeposit * -1;                       // �萔�������z
            newDepsitMainWork.DiscountDeposit = depsitMainWork.DiscountDeposit * -1;             // �l�������z
            newDepsitMainWork.AutoDepositCd = depsitMainWork.AutoDepositCd;                      // ���������敪
            newDepsitMainWork.DraftDrawingDate = depsitMainWork.DraftDrawingDate;                // ��`�U�o��
            newDepsitMainWork.DraftKind = depsitMainWork.DraftKind;                              // ��`���
            newDepsitMainWork.DraftKindName = depsitMainWork.DraftKindName;                      // ��`��ޖ���
            newDepsitMainWork.DraftDivide = depsitMainWork.DraftDivide;                          // ��`�敪
            newDepsitMainWork.DraftDivideName = depsitMainWork.DraftDivideName;                  // ��`�敪����
            newDepsitMainWork.DraftNo = depsitMainWork.DraftNo;                                  // ��`�ԍ�
            newDepsitMainWork.DepositAllowance = depsitMainWork.DepositAllowance * -1;           // ���������z
            newDepsitMainWork.DepositAlwcBlnce = depsitMainWork.DepositAlwcBlnce * -1;           // ���������c��
            newDepsitMainWork.DebitNoteLinkDepoNo = depsitMainWork.DepositSlipNo;                // �ԍ������A���ԍ�
            newDepsitMainWork.LastReconcileAddUpDt = DateTime.MinValue;                          // �ŏI�������݌v���
            newDepsitMainWork.DepositAgentCode = depositAgentCode;                               // �����S���҃R�[�h
            newDepsitMainWork.DepositAgentNm = depositAgentNm;                                   // �����S���Җ���
            newDepsitMainWork.DepositInputAgentCd = depsitMainWork.DepositInputAgentCd;          // �������͎҃R�[�h
            newDepsitMainWork.DepositInputAgentNm = depsitMainWork.DepositInputAgentNm;          // �������͎Җ���
            newDepsitMainWork.CustomerCode = depsitMainWork.CustomerCode;                        // ���Ӑ�R�[�h
            newDepsitMainWork.CustomerName = depsitMainWork.CustomerName;                        // ���Ӑ於��
            newDepsitMainWork.CustomerName2 = depsitMainWork.CustomerName2;                      // ���Ӑ於��2
            newDepsitMainWork.CustomerSnm = depsitMainWork.CustomerSnm;                          // ���Ӑ旪��
            newDepsitMainWork.ClaimCode = depsitMainWork.ClaimCode;                              // ������R�[�h
            newDepsitMainWork.ClaimName = depsitMainWork.ClaimName;                              // �����於��
            newDepsitMainWork.ClaimName2 = depsitMainWork.ClaimName2;                            // �����於��2
            newDepsitMainWork.ClaimSnm = depsitMainWork.ClaimSnm;                                // �����旪��
            newDepsitMainWork.Outline = depsitMainWork.Outline;                                  // �`�[�E�v
            newDepsitMainWork.BankCode = depsitMainWork.BankCode;                                // ��s�R�[�h
            newDepsitMainWork.BankName = depsitMainWork.BankName;                                // ��s����
            //--- ADD 2008/04/25 M.Kubota ---<<<

            return newDepsitMainWork;
        }

        /// <summary>
        /// �ԓ���������񐶐�����
        /// </summary>
        /// <param name="updateSecCd">�X�V���_</param>
        /// <param name="depositAgentCode">�ԓ����S���҃R�[�h</param>
        /// <param name="depositAgentNm">�ԓ����S���Җ���</param>
        /// <param name="addUpADate">�ԓ����v���</param>
        /// <param name="depositAlwWorkList">���������������</param>
        /// <returns>�ԓ����������</returns>
        //--- DEL 2008/04/25 M.Kubota --->>>
        //private DepositAlwWork[] CreateRedDepositAlwWorkProc(int depositCd
        //                                                    , string updateSecCd
        //                                                    , string depositAgentCode
        //                                                    , string depositAgentNm
        //                                                    , DateTime addUpADate
        //                                                    , DepositAlwWork[] depositAlwWorkList)
        //--- DEL 2008/04/25 M.Kubota ---<<<
        private DepositAlwWork[] CreateRedDepositAlwWorkProc(string updateSecCd, string depositAgentCode, string depositAgentNm, DateTime addUpADate, DepositAlwWork[] depositAlwWorkList)  //ADD 2008/04/25 M.Kubota
        {
            ArrayList newDepositAlwWorkList = new ArrayList();

            for (int ix = 0; ix < depositAlwWorkList.Length; ix++)
            {
                DepositAlwWork newDepositAlwWork = new DepositAlwWork();

                # region --- DEL 2008/04/25 M.Kubota ---
                # if false
                // ��ƃR�[�h
                newDepositAlwWork.EnterpriseCode = depositAlwWorkList[ix].EnterpriseCode;

                // �X�V�]�ƈ��R�[�h<-�����S���҃R�[�h ???
                newDepositAlwWork.UpdEmployeeCode = depositAgentCode;

                // �_���폜�敪
                newDepositAlwWork.LogicalDeleteCode = 0;

                // �������͋��_�R�[�h
                newDepositAlwWork.InputDepositSecCd = depositAlwWorkList[ix].InputDepositSecCd;

                // �v�㋒�_�R�[�h
                newDepositAlwWork.AddUpSecCode = depositAlwWorkList[ix].AddUpSecCode;

                // �����ݓ����V�X�e�����t
                newDepositAlwWork.ReconcileDate = DateTime.Now;

                // �����݌v����������v���
                newDepositAlwWork.ReconcileAddUpDate = addUpADate;

                // �����`�[�ԍ�
                newDepositAlwWork.DepositSlipNo = 0;

                // ��������R�[�h
                newDepositAlwWork.DepositKindCode = depositAlwWorkList[ix].DepositKindCode;

                // �������햼��
                newDepositAlwWork.DepositKindName = depositAlwWorkList[ix].DepositKindName;

                // ���������z
                newDepositAlwWork.DepositAllowance = depositAlwWorkList[ix].DepositAllowance * -1;

                // �����S���҃R�[�h
                newDepositAlwWork.DepositAgentCode = depositAgentCode;

                // �����S���Җ���
                newDepositAlwWork.DepositAgentNm = depositAgentNm;

                // ���Ӑ�R�[�h
                newDepositAlwWork.CustomerCode = depositAlwWorkList[ix].CustomerCode;

                // ���Ӑ於��
                newDepositAlwWork.CustomerName = depositAlwWorkList[ix].CustomerName;

                // ���Ӑ於��2
                newDepositAlwWork.CustomerName2 = depositAlwWorkList[ix].CustomerName2;

                // �� 2007.10.12 980081 d
                //// �󒍔ԍ�
                //newDepositAlwWork.AcceptAnOrderNo = depositAlwWorkArray[ix].AcceptAnOrderNo;
                //
                //// �T�[�r�X�`�[�敪
                //newDepositAlwWork.ServiceSlipCd = depositAlwWorkArray[ix].ServiceSlipCd;
                // �� 2007.10.12 980081 d

                // �ԓ`���E�敪 1:��
                newDepositAlwWork.DebitNoteOffSetCd = 1;

                // �a����敪���p�����[�^�l
                newDepositAlwWork.DepositCd = depositCd;

                // �� 2007.10.12 980081 d
                //// �N���W�b�g�^���[���敪
                //newDepositAlwWork.CreditOrLoanCd = depositAlwWorkArray[ix].CreditOrLoanCd;
                // �� 2007.10.12 980081 d
                // �� 2007.10.12 980081 a
                newDepositAlwWork.AcptAnOdrStatus = depositAlwWorkList[ix].AcptAnOdrStatus;
                newDepositAlwWork.SalesSlipNum = depositAlwWorkList[ix].SalesSlipNum;
                // �� 2007.10.12 980081 a
                # endif
                # endregion

                //--- ADD 2008/04/25 M.Kubota --->>>
                newDepositAlwWork.EnterpriseCode = depositAlwWorkList[ix].EnterpriseCode;            // ��ƃR�[�h
                newDepositAlwWork.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;  // �_���폜�敪
                newDepositAlwWork.InputDepositSecCd = depositAlwWorkList[ix].InputDepositSecCd;      // �������͋��_�R�[�h
                newDepositAlwWork.AddUpSecCode = depositAlwWorkList[ix].AddUpSecCode;                // �v�㋒�_�R�[�h
                newDepositAlwWork.AcptAnOdrStatus = depositAlwWorkList[ix].AcptAnOdrStatus;          // �󒍃X�e�[�^�X
                newDepositAlwWork.SalesSlipNum = depositAlwWorkList[ix].SalesSlipNum;                // ����`�[�ԍ�
                newDepositAlwWork.ReconcileDate = DateTime.Now;                                      // �����ݓ�
                newDepositAlwWork.ReconcileAddUpDate = addUpADate;                                   // �����݌v���
                newDepositAlwWork.DepositSlipNo = 0;                                                 // �����`�[�ԍ�
                newDepositAlwWork.DepositAllowance = depositAlwWorkList[ix].DepositAllowance * -1;   // ���������z
                newDepositAlwWork.DepositAgentCode = depositAgentCode;                               // �����S���҃R�[�h
                newDepositAlwWork.DepositAgentNm = depositAgentNm;                                   // �����S���Җ���
                newDepositAlwWork.CustomerCode = depositAlwWorkList[ix].CustomerCode;              // ���Ӑ�R�[�h
                newDepositAlwWork.CustomerName = depositAlwWorkList[ix].CustomerName;              // ���Ӑ於��
                newDepositAlwWork.CustomerName2 = depositAlwWorkList[ix].CustomerName2;            // ���Ӑ於��2
                newDepositAlwWork.DebitNoteOffSetCd = 1;                                             // �ԓ`���E�敪
                //--- ADD 2008/04/25 M.Kubota ---<<<

                newDepositAlwWorkList.Add(newDepositAlwWork);
            }

            return (DepositAlwWork[])newDepositAlwWorkList.ToArray(typeof(DepositAlwWork));
        }

        /// <summary>
        /// �V��������񐶐�����
        /// </summary>
        /// <param name="updateSecCd">�X�V���_</param>
        /// <param name="depositAgentCode">�����S���҃R�[�h</param>
        /// <param name="depositAgentNm">�����S���Җ�</param>
        /// <param name="addUpADate">�����v���</param>
        /// <param name="depsitMainWork">�����������</param>
        /// <returns>�V���������</returns>
        private DepsitMainWork CreateNewBlackDepsitProc(string updateSecCd
                                                      , string depositAgentCode
                                                      , string depositAgentNm
                                                      , DateTime addUpADate
                                                      , DepsitMainWork depsitMainWork)
        {
            DepsitMainWork newDepsitMainWork = new DepsitMainWork();

            # region --- DEL 2008/04/25 M.Kubota ---
            # if false
            // ��ƃR�[�h
            newDepsitMainWork.EnterpriseCode = depsitMainWork.EnterpriseCode;

            // �X�V�]�ƈ��R�[�h<-�����S���҃R�[�h ???
            newDepsitMainWork.UpdEmployeeCode = updateSecCd;

            // �X�V�A�Z���u��ID1
            newDepsitMainWork.UpdAssemblyId1 = depsitMainWork.UpdAssemblyId1;

            // �X�V�A�Z���u��ID2
            newDepsitMainWork.UpdAssemblyId2 = depsitMainWork.UpdAssemblyId2;

            // �_���폜�敪
            newDepsitMainWork.LogicalDeleteCode = 0;

            // �����ԍ��敪  �O�F��
            newDepsitMainWork.DepositDebitNoteCd = 0;

            // �����`�[�ԍ�
            newDepsitMainWork.DepositSlipNo = 0;

            // �� 2007.10.12 980081 d
            //// ����`�[�ԍ�
            //newDepsitMainWork.AcceptAnOrderNo = depsitMainWork.AcceptAnOrderNo;
            //
            //// �T�[�r�X�`�[�敪
            //newDepsitMainWork.ServiceSlipCd = depsitMainWork.ServiceSlipCd;
            // �� 2007.10.12 980081 d

            // �������͋��_�R�[�h
            newDepsitMainWork.InputDepositSecCd = depsitMainWork.InputDepositSecCd;

            // �v�㋒�_�R�[�h
            newDepsitMainWork.AddUpSecCode = depsitMainWork.AddUpSecCode;

            // �X�V���_�R�[�h <- �X�V���_�R�[�h???
            newDepsitMainWork.UpdateSecCd = updateSecCd;

            // �������t <- �������t???
            // �� 2008.03.17 980081 c
            //newDepsitMainWork.DepositDate = addUpADate;
            newDepsitMainWork.DepositDate = DateTime.Now;
            // �� 2008.03.17 980081 c

            // �v����t <- �v����t???
            newDepsitMainWork.AddUpADate = addUpADate;

            // ��������R�[�h
            newDepsitMainWork.DepositKindCode = depsitMainWork.DepositKindCode;

            // �������햼��
            newDepsitMainWork.DepositKindName = depsitMainWork.DepositKindName;

            // ��������敪
            newDepsitMainWork.DepositKindDivCd = depsitMainWork.DepositKindDivCd;

            // �����v
            newDepsitMainWork.DepositTotal = depsitMainWork.DepositTotal;

            // �������z
            newDepsitMainWork.Deposit = depsitMainWork.Deposit;

            // �萔�������z
            newDepsitMainWork.FeeDeposit = depsitMainWork.FeeDeposit;

            // �l�������z
            newDepsitMainWork.DiscountDeposit = depsitMainWork.DiscountDeposit;

            // �� 2007.10.12 980081 d
            //// ���x�[�g�����z
            //newDepsitMainWork.RebateDeposit = depsitMainWork.RebateDeposit;
            // �� 2007.10.12 980081 d

            // ���������敪
            newDepsitMainWork.AutoDepositCd = depsitMainWork.AutoDepositCd;

            // �a����敪
            newDepsitMainWork.DepositCd = depsitMainWork.DepositCd;

            // �� 2007.10.12 980081 d
            //// �N���W�b�g�^���[���敪
            //newDepsitMainWork.CreditOrLoanCd = depsitMainWork.CreditOrLoanCd;
            //
            //// �N���W�b�g��ЃR�[�h
            //newDepsitMainWork.CreditCompanyCode = depsitMainWork.CreditCompanyCode;
            // �� 2007.10.12 980081 d

            // ��`�U�o��
            newDepsitMainWork.DraftDrawingDate = depsitMainWork.DraftDrawingDate;

            // ��`�x������
            newDepsitMainWork.DraftPayTimeLimit = depsitMainWork.DraftPayTimeLimit;

            // ���������z
            newDepsitMainWork.DepositAllowance = depsitMainWork.DepositAllowance;

            // ���������c��
            newDepsitMainWork.DepositAlwcBlnce = depsitMainWork.DepositAlwcBlnce;

            // �ԍ������A���ԍ� (�Ȃ�)
            newDepsitMainWork.DebitNoteLinkDepoNo = 0;

            // �ŏI�������݌v��� ����U����
            newDepsitMainWork.LastReconcileAddUpDt = DateTime.MinValue;

            // �����S���҃R�[�h??
            newDepsitMainWork.DepositAgentCode = depositAgentCode;

            // �����S���Җ���
            newDepsitMainWork.DepositAgentNm = depositAgentNm;

            // ���Ӑ�R�[�h
            newDepsitMainWork.CustomerCode = depsitMainWork.CustomerCode;

            // ���Ӑ於��
            newDepsitMainWork.CustomerName = depsitMainWork.CustomerName;

            // ���Ӑ於��2
            newDepsitMainWork.CustomerName2 = depsitMainWork.CustomerName2;

            // �`�[�E�v
            newDepsitMainWork.Outline = depsitMainWork.Outline;
            // �� 2007.10.12 980081 a
            newDepsitMainWork.AcptAnOdrStatus = depsitMainWork.AcptAnOdrStatus;
            newDepsitMainWork.SalesSlipNum = depsitMainWork.SalesSlipNum;
            newDepsitMainWork.SubSectionCode = depsitMainWork.SubSectionCode;
            newDepsitMainWork.MinSectionCode = depsitMainWork.MinSectionCode;
            newDepsitMainWork.DraftKind = depsitMainWork.DraftKind;
            newDepsitMainWork.DraftKindName = depsitMainWork.DraftKindName;
            newDepsitMainWork.DraftDivide = depsitMainWork.DraftDivide;
            newDepsitMainWork.DraftDivideName = depsitMainWork.DraftDivideName;
            newDepsitMainWork.DraftNo = depsitMainWork.DraftNo;
            newDepsitMainWork.DepositInputAgentCd = depsitMainWork.DepositInputAgentCd;
            newDepsitMainWork.DepositInputAgentNm = depsitMainWork.DepositInputAgentNm;
            newDepsitMainWork.CustomerSnm = depsitMainWork.CustomerSnm;
            newDepsitMainWork.ClaimCode = depsitMainWork.ClaimCode;
            newDepsitMainWork.ClaimName = depsitMainWork.ClaimName;
            newDepsitMainWork.ClaimName2 = depsitMainWork.ClaimName2;
            newDepsitMainWork.ClaimSnm = depsitMainWork.ClaimSnm;
            newDepsitMainWork.BankCode = depsitMainWork.BankCode;
            newDepsitMainWork.BankName = depsitMainWork.BankName;
            newDepsitMainWork.EdiSendDate = depsitMainWork.EdiSendDate;
            newDepsitMainWork.EdiTakeInDate = depsitMainWork.EdiTakeInDate;
            // �� 2007.10.12 980081 a
            # endif
            # endregion

            //--- ADD 2008/04/25 M.Kubota --->>>
            newDepsitMainWork.EnterpriseCode = depsitMainWork.EnterpriseCode;                    // ��ƃR�[�h
            newDepsitMainWork.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;  // �_���폜�敪
            newDepsitMainWork.AcptAnOdrStatus = depsitMainWork.AcptAnOdrStatus;                  // �󒍃X�e�[�^�X
            newDepsitMainWork.DepositDebitNoteCd = 0;                                            // �����ԍ��敪 0:���`
            newDepsitMainWork.DepositSlipNo = 0;                                                 // �����`�[�ԍ� ����ɍ̔Ԃ����
            newDepsitMainWork.SalesSlipNum = depsitMainWork.SalesSlipNum;                        // ����`�[�ԍ�
            newDepsitMainWork.InputDepositSecCd = depsitMainWork.InputDepositSecCd;              // �������͋��_�R�[�h
            newDepsitMainWork.AddUpSecCode = depsitMainWork.AddUpSecCode;                        // �v�㋒�_�R�[�h
            newDepsitMainWork.UpdateSecCd = updateSecCd;                                         // �X�V���_�R�[�h
            newDepsitMainWork.SubSectionCode = depsitMainWork.SubSectionCode;                    // ����R�[�h
            newDepsitMainWork.InputDay = DateTime.Now;                                          // ���͓��t  //ADD 2009/03/25
            newDepsitMainWork.DepositDate = DateTime.Now;                                       // �������t
            newDepsitMainWork.AddUpADate = addUpADate;                                           // �v����t
            newDepsitMainWork.DepositTotal = depsitMainWork.DepositTotal;                        // �����v
            newDepsitMainWork.Deposit = depsitMainWork.Deposit;                                  // �������z
            newDepsitMainWork.FeeDeposit = depsitMainWork.FeeDeposit;                            // �萔�������z
            newDepsitMainWork.DiscountDeposit = depsitMainWork.DiscountDeposit;                  // �l�������z
            newDepsitMainWork.AutoDepositCd = depsitMainWork.AutoDepositCd;                      // ���������敪
            newDepsitMainWork.DraftDrawingDate = depsitMainWork.DraftDrawingDate;                // ��`�U�o��
            newDepsitMainWork.DraftKind = depsitMainWork.DraftKind;                              // ��`���
            newDepsitMainWork.DraftKindName = depsitMainWork.DraftKindName;                      // ��`��ޖ���
            newDepsitMainWork.DraftDivide = depsitMainWork.DraftDivide;                          // ��`�敪
            newDepsitMainWork.DraftDivideName = depsitMainWork.DraftDivideName;                  // ��`�敪����
            newDepsitMainWork.DraftNo = depsitMainWork.DraftNo;                                  // ��`�ԍ�
            newDepsitMainWork.DepositAllowance = depsitMainWork.DepositAllowance;                // ���������z
            newDepsitMainWork.DepositAlwcBlnce = depsitMainWork.DepositAlwcBlnce;                // ���������c��
            newDepsitMainWork.DebitNoteLinkDepoNo = 0;                                           // �ԍ������A���ԍ�
            newDepsitMainWork.LastReconcileAddUpDt = DateTime.MinValue;                          // �ŏI�������݌v���
            newDepsitMainWork.DepositAgentCode = depositAgentCode;                               // �����S���҃R�[�h
            newDepsitMainWork.DepositAgentNm = depositAgentNm;                                   // �����S���Җ���
            newDepsitMainWork.DepositInputAgentCd = depsitMainWork.DepositInputAgentCd;          // �������͎҃R�[�h
            newDepsitMainWork.DepositInputAgentNm = depsitMainWork.DepositInputAgentNm;          // �������͎Җ���
            //newDepsitMainWork.CustomerCode = depsitMainWork.CustomerCode;                      // ���Ӑ�R�[�h
            //newDepsitMainWork.CustomerName = depsitMainWork.CustomerName;                      // ���Ӑ於��
            //newDepsitMainWork.CustomerName2 = depsitMainWork.CustomerName2;                    // ���Ӑ於��2
            //newDepsitMainWork.CustomerSnm = depsitMainWork.CustomerSnm;                        // ���Ӑ旪��
            newDepsitMainWork.CustomerCode = depsitMainWork.ClaimCode;                           // ���Ӑ�R�[�h
            newDepsitMainWork.CustomerName = depsitMainWork.ClaimName;                           // ���Ӑ於��
            newDepsitMainWork.CustomerName2 = depsitMainWork.ClaimName2;                         // ���Ӑ於��2
            newDepsitMainWork.CustomerSnm = depsitMainWork.ClaimSnm;                             // ���Ӑ旪��            
            newDepsitMainWork.ClaimCode = depsitMainWork.ClaimCode;                              // ������R�[�h
            newDepsitMainWork.ClaimName = depsitMainWork.ClaimName;                              // �����於��
            newDepsitMainWork.ClaimName2 = depsitMainWork.ClaimName2;                            // �����於��2
            newDepsitMainWork.ClaimSnm = depsitMainWork.ClaimSnm;                                // �����旪��
            newDepsitMainWork.Outline = depsitMainWork.Outline;                                  // �`�[�E�v
            newDepsitMainWork.BankCode = depsitMainWork.BankCode;                                // ��s�R�[�h
            newDepsitMainWork.BankName = depsitMainWork.BankName;                                // ��s����
            //--- ADD 2008/04/25 M.Kubota ---<<<

            return newDepsitMainWork;
        }

        //--- ADD 2008/04/25 M.Kubota --->>>
        private DepsitDtlWork[] CreateRedDepsitDtlWork(int redDepositSlipNo, DepsitDtlWork[] depsitDtlWork)
        {
            ArrayList RedDepsitDtlArray = new ArrayList();

            foreach (DepsitDtlWork dtl in depsitDtlWork)
            {
                DepsitDtlWork addDtl = new DepsitDtlWork();

                addDtl.CreateDateTime = dtl.CreateDateTime;        // �쐬����
                addDtl.UpdateDateTime = dtl.UpdateDateTime;        // �X�V����
                addDtl.EnterpriseCode = dtl.EnterpriseCode;        // ��ƃR�[�h
                addDtl.FileHeaderGuid = dtl.FileHeaderGuid;        // GUID
                addDtl.UpdEmployeeCode = dtl.UpdEmployeeCode;      // �X�V�]�ƈ��R�[�h
                addDtl.UpdAssemblyId1 = dtl.UpdAssemblyId1;        // �X�V�A�Z���u��ID1
                addDtl.UpdAssemblyId2 = dtl.UpdAssemblyId2;        // �X�V�A�Z���u��ID2
                addDtl.LogicalDeleteCode = dtl.LogicalDeleteCode;  // �_���폜�敪
                addDtl.AcptAnOdrStatus = dtl.AcptAnOdrStatus;      // �󒍃X�e�[�^�X
                addDtl.DepositSlipNo = redDepositSlipNo;           // �����`�[�ԍ�
                addDtl.DepositRowNo = dtl.DepositRowNo;            // �����s�ԍ�
                addDtl.MoneyKindCode = dtl.MoneyKindCode;          // ����R�[�h
                addDtl.MoneyKindName = dtl.MoneyKindName;          // ���햼��
                addDtl.MoneyKindDiv = dtl.MoneyKindDiv;            // ����敪
                addDtl.Deposit = dtl.Deposit * -1;                 // �������z
                addDtl.ValidityTerm = dtl.ValidityTerm;            // �L������

                RedDepsitDtlArray.Add(addDtl);
            }

            return (DepsitDtlWork[])RedDepsitDtlArray.ToArray(typeof(DepsitDtlWork));
        }
        //--- ADD 2008/04/25 M.Kubota ---<<<
        # endregion

        // --------------- ADD START 2010.05.06 gejun FOR M1007A-M1007A-�x����`�f�[�^�X�V�ǉ�------->>>>
        #region[����`]

        #region[�폜]

        /// <summary>
        /// ����`�f�[�^�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="rcvDraftDataWork">����`�f�[�^�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ����`�f�[�^�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.05.06</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        private int DeleteDraftProc(RcvDraftDataWork rcvDraftDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;
            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                # region [SELECT��]
                sqlText = string.Empty;
                sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "FROM RCVDRAFTDATARF WITH (READUNCOMMITTED)" + Environment.NewLine;
                //sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO" + Environment.NewLine;// DEL zhuhh 2013/01/10 for Redmine #34123
                sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine;// ADD zhuhh 2013/01/10 for Redmine #34123
                sqlCommand.CommandText = sqlText;
                # endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaRcvDraftNo = sqlCommand.Parameters.Add("@FINDRCVDRAFTNO", SqlDbType.NVarChar);
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                SqlParameter findParaBankAndBranchCd = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD", SqlDbType.Int);
                SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<


                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;
                findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != rcvDraftDataWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        return status;
                    }

                    // �f�[�^�͑S�č폜
                    # region [DELETE��]
                    sqlText = string.Empty;
                    //sqlText += "DELETE FROM RCVDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO";// DEL zhuhh 2013/01/10 for Redmine #34123
                    sqlText += "DELETE FROM RCVDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE";// ADD zhuhh 2013/01/10 for Redmine #34123
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                    findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;
                    findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<
                }
                else
                {
                    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    sqlCommand.Cancel();
                    return status;
                }
                if (myReader.IsClosed == false) myReader.Close();

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DeleteProc");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [�X�V�A�o�^]
        /// <summary>
        /// ����`�f�[�^�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <remarks>
        /// <param name="rcvDraftDataWork">����`�f�[�^�}�X�^���</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����`�f�[�^�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.05.06</br>
        /// <br>UpdateNote : 2013/01/10 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^���o����l�ɂ���</br>
        /// </remarks>
        private int WriteDraftProc(RcvDraftDataWork rcvDraftDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList ayList = new ArrayList();

            try
            {
                string sqlText = string.Empty;

                using (sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    # region [SELECT��]
                    sqlText = string.Empty;
                    sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM RCVDRAFTDATARF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    //sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO" + Environment.NewLine;// DEL zhuhh 2013/01/10 for Redmine #34123
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine; // ADD zhuhh 2013/01/10 for Redmine #34123
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaRcvDraftNo = sqlCommand.Parameters.Add("@FINDRCVDRAFTNO", SqlDbType.NVarChar);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    SqlParameter findParaBankAndBranchCd = sqlCommand.Parameters.Add("@FINDBANKANDBRANCHCD", SqlDbType.Int);
                    SqlParameter findParaDraftDrawingDate = sqlCommand.Parameters.Add("@FINDDRAFTDRAWINGDATE", SqlDbType.Int);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                    findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                    findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;
                    findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                    // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        DateTime comUpDateTime = rcvDraftDataWork.UpdateDateTime;

                        // �r���`�F�b�N
                        if (_updateDateTime != comUpDateTime)
                        {
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }
                            return status;
                        }
                        # region [UPDATE��]
                        sqlText = string.Empty;
                        sqlText += "UPDATE RCVDRAFTDATARF " + Environment.NewLine;
                        sqlText += "SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , RCVDRAFTNORF=@RCVDRAFTNO , DRAFTKINDCDRF=@DRAFTKINDCD , DRAFTDIVIDERF=@DRAFTDIVIDE , DEPOSITRF=@DEPOSIT , BANKANDBRANCHCDRF=@BANKANDBRANCHCD , BANKANDBRANCHNMRF=@BANKANDBRANCHNM , SECTIONCODERF=@SECTIONCODE , ADDUPSECCODERF=@ADDUPSECCODE , CUSTOMERCODERF=@CUSTOMERCODE , CUSTOMERNAMERF=@CUSTOMERNAME , CUSTOMERNAME2RF=@CUSTOMERNAME2 , CUSTOMERSNMRF=@CUSTOMERSNM , PROCDATERF=@PROCDATE , DRAFTDRAWINGDATERF=@DRAFTDRAWINGDATE , VALIDITYTERMRF=@VALIDITYTERM , DRAFTSTMNTDATERF=@DRAFTSTMNTDATE , OUTLINE1RF=@OUTLINE1 , OUTLINE2RF=@OUTLINE2 , ACPTANODRSTATUSRF=@ACPTANODRSTATUS , DEPOSITSLIPNORF=@DEPOSITSLIPNO , DEPOSITROWNORF=@DEPOSITROWNO , DEPOSITDATERF=@DEPOSITDATE " + Environment.NewLine;
                        //sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO";// DEL zhuhh 2013/01/10 for Redmine #34123
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RCVDRAFTNORF=@FINDRCVDRAFTNO AND BANKANDBRANCHCDRF=@FINDBANKANDBRANCHCD AND DRAFTDRAWINGDATERF=@FINDDRAFTDRAWINGDATE" + Environment.NewLine; // ADD zhuhh 2013/01/10 for Redmine #34123
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = rcvDraftDataWork.EnterpriseCode;
                        findParaRcvDraftNo.Value = rcvDraftDataWork.RcvDraftNo;
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 ----->>>>>
                        findParaBankAndBranchCd.Value = rcvDraftDataWork.BankAndBranchCd;
                        findParaDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                        // ----- ADD zhuhh 2013/01/10 for Redmine #34123 -----<<<<<

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)rcvDraftDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (rcvDraftDataWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

                        //�@��ʂ̃f�[�^�Ainsert����
                        # region [INSERT��]
                        sqlText = string.Empty;
                        sqlText = "INSERT INTO RCVDRAFTDATARF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, RCVDRAFTNORF, DRAFTKINDCDRF, DRAFTDIVIDERF, DEPOSITRF, BANKANDBRANCHCDRF, BANKANDBRANCHNMRF, SECTIONCODERF, ADDUPSECCODERF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, PROCDATERF, DRAFTDRAWINGDATERF, VALIDITYTERMRF, DRAFTSTMNTDATERF, OUTLINE1RF, OUTLINE2RF, ACPTANODRSTATUSRF, DEPOSITSLIPNORF, DEPOSITROWNORF, DEPOSITDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @RCVDRAFTNO, @DRAFTKINDCD, @DRAFTDIVIDE, @DEPOSIT, @BANKANDBRANCHCD, @BANKANDBRANCHNM, @SECTIONCODE, @ADDUPSECCODE, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERNAME2, @CUSTOMERSNM, @PROCDATE, @DRAFTDRAWINGDATE, @VALIDITYTERM, @DRAFTSTMNTDATE, @OUTLINE1, @OUTLINE2, @ACPTANODRSTATUS, @DEPOSITSLIPNO, @DEPOSITROWNO, @DEPOSITDATE)";
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)rcvDraftDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if (myReader.IsClosed == false) myReader.Close();

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraRcvDraftNo = sqlCommand.Parameters.Add("@RCVDRAFTNO", SqlDbType.NVarChar);
                    SqlParameter paraDraftKindCd = sqlCommand.Parameters.Add("@DRAFTKINDCD", SqlDbType.Int);
                    SqlParameter paraDraftDivide = sqlCommand.Parameters.Add("@DRAFTDIVIDE", SqlDbType.Int);
                    SqlParameter paraDeposit = sqlCommand.Parameters.Add("@DEPOSIT", SqlDbType.BigInt);
                    SqlParameter paraBankAndBranchCd = sqlCommand.Parameters.Add("@BANKANDBRANCHCD", SqlDbType.Int);
                    SqlParameter paraBankAndBranchNm = sqlCommand.Parameters.Add("@BANKANDBRANCHNM", SqlDbType.NVarChar);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                    SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                    SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                    SqlParameter paraProcDate = sqlCommand.Parameters.Add("@PROCDATE", SqlDbType.Int);
                    SqlParameter paraDraftDrawingDate = sqlCommand.Parameters.Add("@DRAFTDRAWINGDATE", SqlDbType.Int);
                    SqlParameter paraValidityTerm = sqlCommand.Parameters.Add("@VALIDITYTERM", SqlDbType.Int);
                    SqlParameter paraDraftStmntDate = sqlCommand.Parameters.Add("@DRAFTSTMNTDATE", SqlDbType.Int);
                    SqlParameter paraOutline1 = sqlCommand.Parameters.Add("@OUTLINE1", SqlDbType.NVarChar);
                    SqlParameter paraOutline2 = sqlCommand.Parameters.Add("@OUTLINE2", SqlDbType.NVarChar);
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                    SqlParameter paraDepositRowNo = sqlCommand.Parameters.Add("@DEPOSITROWNO", SqlDbType.Int);
                    SqlParameter paraDepositDate = sqlCommand.Parameters.Add("@DEPOSITDATE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rcvDraftDataWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rcvDraftDataWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(rcvDraftDataWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.LogicalDeleteCode);
                    paraRcvDraftNo.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.RcvDraftNo);
                    paraDraftKindCd.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DraftKindCd);
                    paraDraftDivide.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DraftDivide);
                    paraDeposit.Value = SqlDataMediator.SqlSetInt64(rcvDraftDataWork.Deposit);
                    paraBankAndBranchCd.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.BankAndBranchCd);
                    paraBankAndBranchNm.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.BankAndBranchNm);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.SectionCode);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.AddUpSecCode);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.CustomerCode);
                    paraCustomerName.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.CustomerName);
                    paraCustomerName2.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.CustomerName2);
                    paraCustomerSnm.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.CustomerSnm);
                    paraProcDate.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.ProcDate);
                    paraDraftDrawingDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DraftDrawingDate);
                    paraValidityTerm.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.ValidityTerm);
                    paraDraftStmntDate.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DraftStmntDate);
                    paraOutline1.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.Outline1);
                    paraOutline2.Value = SqlDataMediator.SqlSetString(rcvDraftDataWork.Outline2);
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.AcptAnOdrStatus);
                    paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DepositSlipNo);
                    paraDepositRowNo.Value = SqlDataMediator.SqlSetInt32(rcvDraftDataWork.DepositRowNo);
                    paraDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(rcvDraftDataWork.DepositDate);

                    sqlCommand.ExecuteNonQuery();

                    ayList.Add(rcvDraftDataWork);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "RcvDraftDatatDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "RcvDraftDatatDB.Write" + status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }

        #endregion

        #endregion
        // --------------- ADD END 2010.05.06 gejun FOR M1007A-M1007A-�x����`�f�[�^�X�V�ǉ�------->>>>
        # region ---DEL 2008/04/25 M.Kubota --- [�R�����g�A�E�g���ꂽ�\�[�X�̈�]
# if false
        //--- DEL 2008/04/25 M.Kubota --->>> [���g�p�̈�]
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̓����`�[�ԍ��ő�l��߂��܂�
		/// </summary>
		/// <param name="DepositSlipNo">�����`�[�ԍ�</param>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="sqlConnection">�ȸ��ݏ��</param>
		/// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍ő�����`�[�ԍ���߂��܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.03</br>
		/// </remarks>
		private int GetMaxDepositSlipNoProc(out int DepositSlipNo,string EnterpriseCode, ref SqlConnection sqlConnection,ref SqlTransaction sqlTransaction)
		{

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int wkDepositSlipNo = 0;
			SqlDataReader myReader = null;

			try 
			{			
				//Select�R�}���h�̐���
				using(SqlCommand sqlCommand = new SqlCommand("SELECT MAX(DEPOSITSLIPNORF) DEPOSITSLIPNORF FROM DEPSITMAINRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection, sqlTransaction))
				{

					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						wkDepositSlipNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITSLIPNORF"));

						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader != null && !myReader.IsClosed)myReader.Close();

			DepositSlipNo = wkDepositSlipNo;

			return status;
        }
        //--- DEL 2008/04/25 M.Kubota ---<<<
        
        // �� 20070124 18322 c MA.NS�p�ɕύX
        #region SF ���������}�X�^�����X�V���܂��i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// ���������}�X�^�����X�V���܂�
		///// </summary>
		///// <param name="depositAlwWork">�����������</param>
		///// <param name="bf_DepositAllowance">�X�V�O�����z</param>
		///// <param name="bf_AcpOdrDepositAlwc">�X�V�O�󒍓��������z</param>
		///// <param name="bf_VarCostDepoAlwc">�X�V�O����p���������z</param>
		///// <param name="bf_DepositCd">�X�V�O�a����敪</param>
		///// <param name="bf_CreditOrLoanCd">�X�V�O�N���W�b�g�^���[���敪</param>
		///// <param name="sqlConnection">�ȸ��ݏ��</param>
		///// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
		///// <returns>STATUS</returns>
		///// <remarks>
		///// <br>Note       : ���������}�X�^���̍X�V���s���܂�</br>
		///// <br>           : �X�V���ɍX�V�O����ǂݍ��݁A�����z�E�a������敪�E�N���W�b�g�敪�̎擾���s���܂�</br>
		///// <br>           : ���X�V�O���͐�������l�s�X�V���ɕK�v�ƂȂ邽��</br>
		///// <br>Programmer : 95089 ���i�@��</br>
		///// <br>Date       : 2005.08.11</br>
		///// </remarks>
		//private int WriteDepositAlwWorkRec(ref DepositAlwWork depositAlwWork, out Int64 bf_DepositAllowance, out Int64 bf_AcpOdrDepositAlwc, out Int64 bf_VarCostDepoAlwc, out int bf_DepositCd,  out int bf_CreditOrLoanCd, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		//
		//	SqlDataReader myReader = null;
		//
		//	bf_DepositAllowance = 0;
		//	bf_DepositCd = 0;
		//	bf_CreditOrLoanCd = 0;
		//	bf_AcpOdrDepositAlwc = 0;			// 20060220 Ins
		//	bf_VarCostDepoAlwc = 0;				// 20060220 Ins
		//
		//	//Select�R�}���h�̐���
		//	try			
		//	{
		//		using(SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, DEPOSITALLOWANCERF, DEPOSITCDRF, CREDITORLOANCDRF, ACPODRDEPOSITALWCRF, VARCOSTDEPOALWCRF FROM DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO AND ADDUPSECCODERF=@FINDADDUPSECCODE", sqlConnection,sqlTransaction))	// 20060220 Chg �󒍈����E����p�����z�̒ǉ�
		//		{
		//
		//			//Prameter�I�u�W�F�N�g�̍쐬
		//			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//			SqlParameter findParaAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
		//			SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
		//			SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
		//			//					SqlParameter findParaReconcileDate = sqlCommand.Parameters.Add("@FINDRECONCILEADDUPDATE", SqlDbType.Int);
		//			SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
		//
		//			//Parameter�I�u�W�F�N�g�֒l�ݒ�
		//			findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
		//			findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
		//			findParaCustomerCode.Value  = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
		//			findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
		//			//					findParaReconcileDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileDate);
		//			findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);
		//
		//			myReader = sqlCommand.ExecuteReader();
		//			if(myReader.Read())
		//			{
		//				//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
		//				DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
		//				if (_updateDateTime != depositAlwWork.UpdateDateTime)
		//				{
		//					//�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
		//					if (depositAlwWork.UpdateDateTime == DateTime.MinValue)	status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
		//						//�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
		//					else												status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
		//					sqlCommand.Cancel();
		//					if(myReader != null && !myReader.IsClosed)myReader.Close();
		//					return status;
		//				}
		//
		//				// �X�V�O�����z�A�X�V�O�a����敪�A�N���W�b�g�敪�擾
		//				bf_DepositAllowance = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCERF"));		// �����z
		//				bf_DepositCd		= SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEPOSITCDRF"));				// �a������敪
		//				bf_CreditOrLoanCd	= SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CREDITORLOANCDRF"));		// �N���W�b�g�^���[���敪
		//				// 20060220 Ins Start >>>>>>>>>>>>>>
		//				bf_AcpOdrDepositAlwc= SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRDEPOSITALWCRF"));		// �󒍈����z
		//				bf_VarCostDepoAlwc	= SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCOSTDEPOALWCRF"));		// ����p�����z
		//				// 20060220 Ins End <<<<<<<<<<<<<<<
		//
		//
		//				if(depositAlwWork.LogicalDeleteCode == 0)		// �_���폜�敪�������Ă��Ȃ��ꍇ�͒ʏ�X�V���s
		//				{
        //                    sqlCommand.CommandText = "UPDATE DEPOSITALWRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , CUSTOMERCODERF=@CUSTOMERCODE , ADDUPSECCODERF=@ADDUPSECCODE , ACCEPTANORDERNORF=@ACCEPTANORDERNO , DEPOSITSLIPNORF=@DEPOSITSLIPNO , DEPOSITKINDCODERF=@DEPOSITKINDCODE , DEPOSITINPUTDATERF=@DEPOSITINPUTDATE , DEPOSITALLOWANCERF=@DEPOSITALLOWANCE , RECONCILEDATERF=@RECONCILEDATE , RECONCILEADDUPDATERF=@RECONCILEADDUPDATE , DEBITNOTEOFFSETCDRF=@DEBITNOTEOFFSETCD , DEPOSITCDRF=@DEPOSITCD, CREDITORLOANCDRF=@CREDITORLOANCD "
		//						+", ACPODRDEPOSITALWCRF=@ACPODRDEPOSITALWC , VARCOSTDEPOALWCRF=@VARCOSTDEPOALWC "		// 200960220 Ins
        //                    	+"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO AND ADDUPSECCODERF=@ADDUPSECCODE";
		//				}
		//				else											// �_���폜�敪�������Ă���ꍇ�͍폜�������s
		//				{
		//					sqlCommand.CommandText = "DELETE DEPOSITALWRF "
		//						+"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO AND ADDUPSECCODERF=@ADDUPSECCODE";
		//				}
		//
		//				//KEY�R�}���h���Đݒ�
		//				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
		//				findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
		//				findParaCustomerCode.Value  = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
		//				findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
		//					// ????�������݌v������ǂ����邩�H
//		//				SqlParameter findParaReconcileDate = sqlCommand.Parameters.Add("@FINDRECONCILEADDUPDATE", SqlDbType.Int);
//		//				findParaReconcileDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileDate);
		//				findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);
		//
		//				//�X�V�w�b�_����ݒ�
		//				object obj = (object)this;
		//				IFileHeader flhd = (IFileHeader)depositAlwWork;
		//				FileHeader fileHeader = new FileHeader(obj);
		//				fileHeader.SetUpdateHeader(ref flhd,obj);
		//			}
		//			else
		//			{
		//				//����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
		//				if (depositAlwWork.UpdateDateTime > DateTime.MinValue)
		//				{
		//					status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
		//					sqlCommand.Cancel();
		//					if(myReader != null && !myReader.IsClosed)myReader.Close();
		//					return status;
		//				}
		//
        //                //�V�K�쐬����SQL���𐶐�
		//				sqlCommand.CommandText = "INSERT INTO DEPOSITALWRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, ADDUPSECCODERF, ACCEPTANORDERNORF, DEPOSITSLIPNORF, DEPOSITKINDCODERF, DEPOSITINPUTDATERF, DEPOSITALLOWANCERF, RECONCILEDATERF, RECONCILEADDUPDATERF, DEBITNOTEOFFSETCDRF, DEPOSITCDRF, CREDITORLOANCDRF "
		//					+", ACPODRDEPOSITALWCRF, VARCOSTDEPOALWCRF "	// 20060220 Ins
		//					+") VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @CUSTOMERCODE, @ADDUPSECCODE, @ACCEPTANORDERNO, @DEPOSITSLIPNO, @DEPOSITKINDCODE, @DEPOSITINPUTDATE, @DEPOSITALLOWANCE, @RECONCILEDATE, @RECONCILEADDUPDATE, @DEBITNOTEOFFSETCD, @DEPOSITCD, @CREDITORLOANCD"
		//					+", @ACPODRDEPOSITALWC, @VARCOSTDEPOALWC"		// 20060220 Ins
		//					+")";
		//				
		//				//�o�^�w�b�_����ݒ�
		//				object obj = (object)this;
		//				IFileHeader flhd = (IFileHeader)depositAlwWork;
		//				FileHeader fileHeader = new FileHeader(obj);
		//				fileHeader.SetInsertHeader(ref flhd,obj);
		//			}
		//			if(myReader != null && !myReader.IsClosed)myReader.Close();
		//
        //            #region SF ���������}�X�^ Parameter�I�u�W�F�N�g�̐ݒ�i�S�ăR�����g�A�E�g�j
        //            //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
		//			SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
		//			SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
		//			SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		//			SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
		//			SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
		//			SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
		//			SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
		//			SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
		//			SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
		//			SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
		//			SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
		//			SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
		//			SqlParameter paraDepositKindCode = sqlCommand.Parameters.Add("@DEPOSITKINDCODE", SqlDbType.Int);
		//			SqlParameter paraDepositInputDate = sqlCommand.Parameters.Add("@DEPOSITINPUTDATE", SqlDbType.Int);
		//			SqlParameter paraDepositAllowance = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE", SqlDbType.BigInt);
		//			SqlParameter paraReconcileDate = sqlCommand.Parameters.Add("@RECONCILEDATE", SqlDbType.Int);
		//			SqlParameter paraReconcileAddUpDate = sqlCommand.Parameters.Add("@RECONCILEADDUPDATE", SqlDbType.Int);
		//			SqlParameter paraDebitNoteOffSetCd = sqlCommand.Parameters.Add("@DEBITNOTEOFFSETCD", SqlDbType.Int);
		//			SqlParameter paraDepositCd = sqlCommand.Parameters.Add("@DEPOSITCD", SqlDbType.Int);
		//			SqlParameter paraCreditOrLoanCd = sqlCommand.Parameters.Add("@CREDITORLOANCD", SqlDbType.Int);					
		//			// 20060220 Ins Start >>����p�ʓ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		//			SqlParameter paraAcpOdrDepositAlwc = sqlCommand.Parameters.Add("@ACPODRDEPOSITALWC", SqlDbType.BigInt);
		//			SqlParameter paraVarCostDepoAlwc = sqlCommand.Parameters.Add("@VARCOSTDEPOALWC", SqlDbType.BigInt);
		//			// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		//			#endregion
		//			
		//			#region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
		//			paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.CreateDateTime);
		//			paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.UpdateDateTime);
		//			paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
		//			paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depositAlwWork.FileHeaderGuid);
		//			paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdEmployeeCode);
		//			paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId1);
		//			paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId2);
		//			paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.LogicalDeleteCode);
		//			paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
		//			paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);
		//			paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
		//			paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
		//			paraDepositKindCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositKindCode);
		//			paraDepositInputDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.DepositInputDate);
		//			paraDepositAllowance.Value = SqlDataMediator.SqlSetInt64(depositAlwWork.DepositAllowance);
		//			paraReconcileDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileDate);
		//			paraReconcileAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileAddUpDate);
		//			paraDebitNoteOffSetCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DebitNoteOffSetCd);
		//			paraDepositCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositCd);
		//			paraCreditOrLoanCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CreditOrLoanCd);
		//			// 20060220 Ins Start >>����p�ʓ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		//			paraAcpOdrDepositAlwc.Value = SqlDataMediator.SqlSetInt64(depositAlwWork.AcpOdrDepositAlwc);
		//			paraVarCostDepoAlwc.Value = SqlDataMediator.SqlSetInt64(depositAlwWork.VarCostDepoAlwc);
		//			// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		//			#endregion
		//
        //            sqlCommand.ExecuteNonQuery();
		//		}
		//
		//		status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//	}
		//	catch (SqlException ex) 
		//	{
		//		if(myReader != null && !myReader.IsClosed)myReader.Close();
		//		//���N���X�ɗ�O��n���ď������Ă��炤
		//		status = base.WriteSQLErrorLog(ex);
		//	}
		//
		//	if(myReader != null && !myReader.IsClosed)myReader.Close();
		//
		//	return status;
        //}
        #endregion
        // �� 20070124 18322 c

        // �� 20070518 18322 d ����Ȃ��̂ō폜
        #region ��������Ǎ������i�e�X�g�p�F���j �폜
        ///// <summary>
		///// ��������Ǎ������i�e�X�g�p�F���j
		///// </summary>
		///// <param name="EnterpriseCode"></param>
		///// <param name="DepositSlipNo"></param>
		///// <param name="depsitDataWorkByte"></param>
		///// <param name="depositAlwWorkListByte"></param>
		///// <returns></returns>
		//public int ReadDmdSalesRec(string EnterpriseCode, int ClaimCode, out byte[] dmdSalesWorkListByte)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //
		//	SqlConnection sqlConnection = null;
		//	SqlTransaction sqlTransaction = null;
        //
        //    // �� 20070123 18322 c MA.NS�p�ɕύX
		//	//DmdSalesWork[] DmdSalesWorkList = null;
        //
        //    // ��������f�[�^�i����f�[�^�j
		//	SalesSlipWork[] DmdSalesWorkList = null;
        //    // �� 20070123 18322 c
        //
		//	dmdSalesWorkListByte = null;
        //
		//	try 
		//	{	
		//		//���[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
		//		SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
		//		string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
		//		if (connectionText == null || connectionText == "") return status;
        //
		//		//SQL�ڑ�
		//		sqlConnection = new SqlConnection(connectionText);
		//		sqlConnection.Open();
		//		sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
        //
		//		// �����Ǎ��ݏ���
		//		status = ReadDmdSalesWorkRec(EnterpriseCode, ClaimCode, out DmdSalesWorkList, ref sqlConnection, ref sqlTransaction);
        //
		//		if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//			sqlTransaction.Commit();
		//		else
		//			sqlTransaction.Rollback();
        //
		//	}
		//	catch (SqlException ex) 
		//	{
		//		//���N���X�ɗ�O��n���ď������Ă��炤
		//		status = base.WriteSQLErrorLog(ex);
		//	}
        //
		//	if(sqlConnection != null)
		//	{
		//		sqlConnection.Close();
		//		sqlConnection.Dispose();
		//	}
        //
		//	// XML�֕ϊ����A������̃o�C�i����
		//	dmdSalesWorkListByte = XmlByteSerializer.Serialize(DmdSalesWorkList);
        //
		//	return status;
        //}
        #endregion
        // �� 20070518 18322 d

        // �� 20070124 18322 c MA.NS�p�ɕύX
        #region SF ��������}�X�^���̈����z���X�V�iMA.NS�ł͐�������͖����ׁA�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// ��������}�X�^���̈����z���X�V���܂�
		///// </summary>
		///// <param name="depositAlwWork">�����������</param>
		///// <param name="bf_DepositAllowance">�X�V�O���������z</param>
		///// <param name="bf_AcpOdrDepositAlwc">�X�V�O�󒍓��������z</param>
		///// <param name="bf_VarCostDepoAlwc">�X�V�O����p���������z</param>
		///// <param name="bf_DepositCd">�X�V�O�a����敪</param>
		///// <param name="bf_CreditOrLoanCd">�X�V�O�N���W�b�g�^���[���敪</param>
		///// <param name="af_CreditOrLoanCd">�X�V��N���W�b�g�^���[���敪</param>
		///// <param name="sqlConnection">�ȸ��ݏ��</param>
		///// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
		///// <returns>STATUS</returns>
		///// <remarks>
		///// <br>Note       : �����������ƁA�X�V�O�������E�N���W�b�g���[���敪�ɂ�萿������l�s���X�V���܂�</br>
		///// <br>Programmer : 95089 ���i�@��</br>
		///// <br>Date       : 2005.08.03</br>
		///// </remarks>	
		//private int UpdateDmdSalesRec(ref DepositAlwWork depositAlwWork, Int64 bf_DepositAllowance, Int64 bf_AcpOdrDepositAlwc, Int64 bf_VarCostDepoAlwc , int bf_DepositCd, int bf_CreditOrLoanCd, int af_CreditOrLoanCd, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		//
		//	SqlDataReader myReader = null;
		//
		//	// Update�R�}���h�̐���
		//	try			
		//	{
        //        //				string updateText = "UPDATE DMDSALESRF  SET UPDATEDATETIMERF=@UPDATEDATETIME , DEPOSITALLOWANCE=DEPOSITALLOWANCE + DF_DEPOSITALLOWANCE "
		//		string updateText = "UPDATE DMDSALESRF  SET UPDATEDATETIMERF=@UPDATEDATETIME, UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2, DEPOSITALLOWANCERF=DEPOSITALLOWANCERF + @DF_DEPOSITALLOWANCE, DEPOSITALWCBLNCERF=DEPOSITALWCBLNCERF - @DF_DEPOSITALLOWANCE, MNYONDEPOALLOWANCERF = MNYONDEPOALLOWANCERF + @DF_MNYONDEPOALLOWANCE "
		//			+",CREDITALLOWANCERF=CREDITALLOWANCERF + @DF_CREDITALLOWANCE, CREDITALWCBLNCERF=CREDITALWCBLNCERF - @DF_CREDITALLOWANCE "					// 20060220 Ins �N���W�b�g����
		//			+",ACPODRDEPOSITALWCRF=ACPODRDEPOSITALWCRF + @DF_ACPODRDEPOSITALWC, ACPODRDEPOALWCBLNCERF=ACPODRDEPOALWCBLNCERF - @DF_ACPODRDEPOSITALWC "	// 20060220 Ins �󒍈���
		//			+",VARCOSTDEPOALWCRF=VARCOSTDEPOALWCRF + @DF_VARCOSTDEPOALWC, VARCOSTDEPOALWCBLNCERF=VARCOSTDEPOALWCBLNCERF - @DF_VARCOSTDEPOALWC "			// 20060220 Ins ����p����
		//			+"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO AND CLAIMCODERF=@FINDCLAIMCODE";
		//
		//		using(SqlCommand sqlCommand = new SqlCommand(updateText, sqlConnection,sqlTransaction))
		//		{
		//			//Prameter�I�u�W�F�N�g�̍쐬
		//			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//			SqlParameter findParaAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
		//			SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
		//
		//			//Parameter�I�u�W�F�N�g�֒l�ݒ�
		//			findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
		//			findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);	
		//			findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
		//
		//			#region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
		//			//Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
		//			SqlParameter paraUpdateDateTime			= sqlCommand.Parameters.Add("@UPDATEDATETIME",			SqlDbType.BigInt);	// �X�V��
		//			SqlParameter paraUpdEmployeeCode		= sqlCommand.Parameters.Add("@UPDEMPLOYEECODE",			SqlDbType.NChar);
		//			SqlParameter paraUpdAssemblyId1			= sqlCommand.Parameters.Add("@UPDASSEMBLYID1",			SqlDbType.NVarChar);
		//			SqlParameter paraUpdAssemblyId2			= sqlCommand.Parameters.Add("@UPDASSEMBLYID2",			SqlDbType.NVarChar);
		//
		//			SqlParameter paraDF_DepositAllowance	= sqlCommand.Parameters.Add("@DF_DEPOSITALLOWANCE",		SqlDbType.BigInt);	// �������z
		//			SqlParameter paraDF_MnyOnDepoAllowance	= sqlCommand.Parameters.Add("@DF_MNYONDEPOALLOWANCE",	SqlDbType.BigInt);	// �a����������z
		//			SqlParameter paraDF_CreditAllowance		= sqlCommand.Parameters.Add("@DF_CREDITALLOWANCE",		SqlDbType.BigInt);	// �N���W�b�g�������z
		//			// 20020620 Ins Start >> ����p�ʓ����Ή�>>>>>>>>>>>>
		//			SqlParameter paraDF_AcpOdrDepositAlwc	= sqlCommand.Parameters.Add("@DF_ACPODRDEPOSITALWC",	SqlDbType.BigInt);	// �󒍈������z
		//			SqlParameter paraDF_VarCostDepoAlwc		= sqlCommand.Parameters.Add("@DF_VARCOSTDEPOALWC",		SqlDbType.BigInt);	// ����p�������z
		//			// 20020620 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		//
		//			#endregion
		//
		//			#region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
		//
		//			//�a����������z
		//			Int64 df_MnyOnDepoAllowance = 0;
		//
		//			if (bf_DepositCd == 1)
		//			{
		//				df_MnyOnDepoAllowance -= bf_DepositAllowance;
		//			}
		//			if(depositAlwWork.DepositCd == 1)
		//			{
		//				df_MnyOnDepoAllowance += depositAlwWork.DepositAllowance;
		//			}
		//
		//			paraDF_MnyOnDepoAllowance.Value = SqlDataMediator.SqlSetInt64(df_MnyOnDepoAllowance);
		//			
		//			// �N���W�b�g�������z
		//			Int64 df_CreditAllowance = 0;
		//
		//			if (bf_CreditOrLoanCd > 0)
		//			{
		//				df_CreditAllowance -= bf_DepositAllowance;
		//			}
		//			if(af_CreditOrLoanCd > 0)
		//			{
		//				df_CreditAllowance += depositAlwWork.DepositAllowance;
		//			}
		//
		//			paraDF_CreditAllowance.Value = SqlDataMediator.SqlSetInt64(df_CreditAllowance);
		//
		//
		//			// ���X�V�w�b�_����ݒ� 
		//			object obj = (object)this;
		//			FileHeader fileHeader = new FileHeader(obj);
		//			paraUpdateDateTime.Value		= SqlDataMediator.SqlSetDateTimeFromTicks(fileHeader.NewFileHeaderDateTime());			// �X�V��
		//			paraUpdEmployeeCode.Value		= SqlDataMediator.SqlSetString(fileHeader.UpdEmployeeCode);								// �X�V�]�ƈ��R�[�h
		//			paraUpdAssemblyId1.Value		= SqlDataMediator.SqlSetString(fileHeader.UpdAssemblyId1);								// �X�V�A�Z���u��ID1
		//			paraUpdAssemblyId2.Value		= SqlDataMediator.SqlSetString(fileHeader.GetUpdAssemblyID(this));						// �X�V�A�Z���u��ID2
		//			// ���ύX����ݒ� 
		//			paraDF_DepositAllowance.Value	= SqlDataMediator.SqlSetInt64(depositAlwWork.DepositAllowance - bf_DepositAllowance);	// �������z
		//			paraDF_MnyOnDepoAllowance.Value = SqlDataMediator.SqlSetInt64(df_MnyOnDepoAllowance);									// �a����������z
		//			paraDF_CreditAllowance.Value	= SqlDataMediator.SqlSetInt64(df_CreditAllowance);										// �N���W�b�g�������z
		//			// 20020620 Ins Start >> ����p�ʓ����Ή�>>>>>>>>>>>>
		//			paraDF_AcpOdrDepositAlwc.Value	= SqlDataMediator.SqlSetInt64(depositAlwWork.AcpOdrDepositAlwc - bf_AcpOdrDepositAlwc);	// �󒍈������z
		//			paraDF_VarCostDepoAlwc.Value	= SqlDataMediator.SqlSetInt64(depositAlwWork.VarCostDepoAlwc - bf_VarCostDepoAlwc);		// ����p�������z
		//			// 20020620 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		//			#endregion
		//
		//			int count = sqlCommand.ExecuteNonQuery();
		//
		//			// �X�V�����������ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
		//			if(count == 0)
		//			{
		//				status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
		//
		//			}
		//			else
		//			{
		//				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//			}
		//
		//		}
		//	
		//	}
		//	catch (SqlException ex) 
		//	{
		//		if(myReader != null && !myReader.IsClosed)myReader.Close();
		//		//���N���X�ɗ�O��n���ď������Ă��炤
		//		status = base.WriteSQLErrorLog(ex);
		//	}
		//
		//	if(myReader != null && !myReader.IsClosed)myReader.Close();
		//
		//	return status;
		//}
        #endregion
        // �� 20070124 18322 c

        // �� 20070123 18322 d MA.NS�ł͎󒍃}�X�^�͎g�p���Ȃ��̂ō폜
        #region SF �󒍃}�X�^�����擾���܂��i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// �󒍃}�X�^�����擾���܂�
		///// </summary>
		///// <param name="EnterpriseCode">��ƃR�[�h</param>
		///// <param name="AcceptAnOrderNo">�󒍔ԍ�</param>
		///// <param name="updAcceptOdrWork">�󒍏�񃏁[�N�i�X�V���ɕK�v���̂݁j</param>
		///// <param name="sqlConnection">�ȸ��ݏ��</param>
		///// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
		///// <returns>STATUS</returns>
		///// <remarks>
		///// <br>Note       : �󒍔ԍ�����󒍏����擾���܂��i�Œ���K�v�ȏ��݂̂��p�N���X�Ɏ擾�j</br>
		///// <br>Programmer : 95089 ���i�@��</br>
		///// <br>Date       : 2005.08.11</br>
		///// </remarks>
		//private int ReadAcceptOdrWorkRec(string EnterpriseCode, int AcceptAnOrderNo, ref UpdAcceptOdrWork updAcceptOdrWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		//
		//	SqlDataReader myReader = null;
		//
		//	updAcceptOdrWork = new UpdAcceptOdrWork();
		//
		//	try 
		//	{			
		//		//Select�R�}���h�̐���
		//		using(SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, DEPOSITALLOWANCETTLRF, MNYDEPOALLOWANCETTLRF, DEMANDPRORATACDRF, CLAIM1CODERF, CLAIM2CODERF, CLAIM3CODERF, CLAIM4CODERF, CLAIM5CODERF, DEPOSITALLOWANCE1RF, MNYONDEPOALLOWANCE1RF, DEPOSITALLOWANCE2RF, MNYONDEPOALLOWANCE2RF, DEPOSITALLOWANCE3RF, MNYONDEPOALLOWANCE3RF, DEPOSITALLOWANCE4RF, MNYONDEPOALLOWANCE4RF, DEPOSITALLOWANCE5RF, MNYONDEPOALLOWANCE5RF "
		//				  +"FROM ACCEPTODRRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO", sqlConnection, sqlTransaction))
		//		{
		//
		//			// �K�v���ڂ̂ݓǂݍ���
		//
		//			//Prameter�I�u�W�F�N�g�̍쐬
		//			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//			SqlParameter findParaAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
		//
		//			//Parameter�I�u�W�F�N�g�֒l�ݒ�
		//			findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
		//			findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(AcceptAnOrderNo);
		//
		//			myReader = sqlCommand.ExecuteReader();
		//			if(myReader.Read())
		//			{
		//
		//				#region �N���X�֑��
		//				updAcceptOdrWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
		//				updAcceptOdrWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
		//				updAcceptOdrWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
		//				updAcceptOdrWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
		//				updAcceptOdrWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
		//				updAcceptOdrWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
		//				updAcceptOdrWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
		//				updAcceptOdrWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
		//				updAcceptOdrWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACCEPTANORDERNORF"));
		//				updAcceptOdrWork.DepositAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCETTLRF"));
		//				updAcceptOdrWork.MnyDepoAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("MNYDEPOALLOWANCETTLRF"));
		//				updAcceptOdrWork.DemandProRataCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEMANDPRORATACDRF"));
		//				updAcceptOdrWork.Claim1Code = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CLAIM1CODERF"));
		//				updAcceptOdrWork.Claim2Code = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CLAIM2CODERF"));
		//				updAcceptOdrWork.Claim3Code = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CLAIM3CODERF"));
		//				updAcceptOdrWork.Claim4Code = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CLAIM4CODERF"));
		//				updAcceptOdrWork.Claim5Code = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CLAIM5CODERF"));
		//				updAcceptOdrWork.DepositAllowance1 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCE1RF"));
		//				updAcceptOdrWork.MnyOnDepoAllowance1 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("MNYONDEPOALLOWANCE1RF"));
		//				updAcceptOdrWork.DepositAllowance2 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCE2RF"));
		//				updAcceptOdrWork.MnyOnDepoAllowance2 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("MNYONDEPOALLOWANCE2RF"));
		//				updAcceptOdrWork.DepositAllowance3 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCE3RF"));
		//				updAcceptOdrWork.MnyOnDepoAllowance3 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("MNYONDEPOALLOWANCE3RF"));
		//				updAcceptOdrWork.DepositAllowance4 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCE4RF"));
		//				updAcceptOdrWork.MnyOnDepoAllowance4 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("MNYONDEPOALLOWANCE4RF"));
		//				updAcceptOdrWork.DepositAllowance5 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCE5RF"));
		//				updAcceptOdrWork.MnyOnDepoAllowance5 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("MNYONDEPOALLOWANCE5RF"));
		//				#endregion
		//
		//				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//			}
		//		}
		//	}
		//	catch (SqlException ex) 
		//	{
		//		//���N���X�ɗ�O��n���ď������Ă��炤
		//		status = base.WriteSQLErrorLog(ex);
		//	}
		//
		//	 if(myReader != null && !myReader.IsClosed)myReader.Close();
		//
		//	return status;
        //}
        #endregion
        // �� 20070124 18322 d

        // �� 20070124 18322 d MA.NS�ł͎󒍃}�X�^�͎g�p���Ȃ��̂ō폜
        #region SF �󒍃}�X�^���i�������j���X�V�E�X�V�p�󒍃��[�N�����z�v�Z�����́AMA.NS�ł͎g�p���Ȃ��̂ō폜�i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// �󒍃}�X�^���i�������j���X�V���܂�
		///// </summary>
		///// <param name="updAcceptOdrWork">�󒍏�񃏁[�N�i�X�V���ɕK�v���̂݁j</param>
		///// <param name="sqlConnection"></param>
		///// <param name="sqlTransaction"></param>
		///// <param name="sqlConnection">�ȸ��ݏ��</param>
		///// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
		///// <returns>STATUS</returns>
		///// <remarks>
		///// <br>Note       : �󒍏�񒆁A�������݂̂��X�V���܂��j</br>
		///// <br>Programmer : 95089 ���i�@��</br>
		///// <br>Date       : 2005.08.11</br>
		///// </remarks>
		//private int WriteAcceptOdrWorkRec(ref UpdAcceptOdrWork updAcceptOdrWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		//
		//	SqlDataReader myReader = null;
		//
		//	// Update�R�}���h�̐���
		//	try			
		//	{
		//		// �X�V�����X�V�����L�[�ɕt�����čX�V�i���t�r�������j
		//		string updateText = "UPDATE ACCEPTODRRF SET UPDATEDATETIMERF=@UPDATEDATETIME , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , ACCEPTANORDERNORF=@ACCEPTANORDERNO , DEPOSITALLOWANCETTLRF=@DEPOSITALLOWANCETTL , MNYDEPOALLOWANCETTLRF=@MNYDEPOALLOWANCETTL , DEPOSITALLOWANCE1RF=@DEPOSITALLOWANCE1 , MNYONDEPOALLOWANCE1RF=@MNYONDEPOALLOWANCE1 , DEPOSITALLOWANCE2RF=@DEPOSITALLOWANCE2 , MNYONDEPOALLOWANCE2RF=@MNYONDEPOALLOWANCE2 , DEPOSITALLOWANCE3RF=@DEPOSITALLOWANCE3 , MNYONDEPOALLOWANCE3RF=@MNYONDEPOALLOWANCE3 , DEPOSITALLOWANCE4RF=@DEPOSITALLOWANCE4 , MNYONDEPOALLOWANCE4RF=@MNYONDEPOALLOWANCE4 , DEPOSITALLOWANCE5RF=@DEPOSITALLOWANCE5 , MNYONDEPOALLOWANCE5RF=@MNYONDEPOALLOWANCE5, EXCLUSIVEDEPOALWDATERF=@EXCLUSIVEDEPOALWDATE "
		//			+"WHERE UPDATEDATETIMERF=@FINDUPDATEDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO";
		//
		//		using(SqlCommand sqlCommand = new SqlCommand(updateText, sqlConnection,sqlTransaction))
		//		{
		//			//Prameter�I�u�W�F�N�g�̍쐬
		//			//Parameter�I�u�W�F�N�g�̍쐬(�����p)
		//			SqlParameter findParaUpdateDateTime = sqlCommand.Parameters.Add("@FINDUPDATEDATETIME", SqlDbType.BigInt);
		//			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//			SqlParameter findParaAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
		//
		//			//Parameter�I�u�W�F�N�g�֒l�ݒ�
		//			findParaUpdateDateTime.Value	= SqlDataMediator.SqlSetDateTimeFromTicks(updAcceptOdrWork.UpdateDateTime);
		//			findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(updAcceptOdrWork.EnterpriseCode);
		//			findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(updAcceptOdrWork.AcceptAnOrderNo);	
		//
		//			//�X�V�w�b�_����ݒ�
		//			object obj = (object)this;
		//			IFileHeader flhd = (IFileHeader)updAcceptOdrWork;
		//			FileHeader fileHeader = new FileHeader(obj);
		//			fileHeader.SetUpdateHeader(ref flhd,obj);
		//
		//			// �r���p���t�̐ݒ�(�r���p���������X�V�� �� �X�V��)
		//			updAcceptOdrWork.ExclusiveDepoAlwDate = updAcceptOdrWork.UpdateDateTime;
		//
		//			#region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
		//
		//			SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
		//			SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
		//			SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
		//			SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
		//			SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
		//			SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
		//			SqlParameter paraDepositAllowanceTtl = sqlCommand.Parameters.Add("@DEPOSITALLOWANCETTL", SqlDbType.BigInt);
		//			SqlParameter paraMnyDepoAllowanceTtl = sqlCommand.Parameters.Add("@MNYDEPOALLOWANCETTL", SqlDbType.BigInt);
		//			SqlParameter paraDepositAllowance1 = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE1", SqlDbType.BigInt);
		//			SqlParameter paraMnyOnDepoAllowance1 = sqlCommand.Parameters.Add("@MNYONDEPOALLOWANCE1", SqlDbType.BigInt);
		//			SqlParameter paraDepositAllowance2 = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE2", SqlDbType.BigInt);
		//			SqlParameter paraMnyOnDepoAllowance2 = sqlCommand.Parameters.Add("@MNYONDEPOALLOWANCE2", SqlDbType.BigInt);
		//			SqlParameter paraDepositAllowance3 = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE3", SqlDbType.BigInt);
		//			SqlParameter paraMnyOnDepoAllowance3 = sqlCommand.Parameters.Add("@MNYONDEPOALLOWANCE3", SqlDbType.BigInt);
		//			SqlParameter paraDepositAllowance4 = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE4", SqlDbType.BigInt);
		//			SqlParameter paraMnyOnDepoAllowance4 = sqlCommand.Parameters.Add("@MNYONDEPOALLOWANCE4", SqlDbType.BigInt);
		//			SqlParameter paraDepositAllowance5 = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE5", SqlDbType.BigInt);
		//			SqlParameter paraMnyOnDepoAllowance5 = sqlCommand.Parameters.Add("@MNYONDEPOALLOWANCE5", SqlDbType.BigInt);
		//			SqlParameter paraExclusiveDepoAlwDate = sqlCommand.Parameters.Add("@EXCLUSIVEDEPOALWDATE", SqlDbType.BigInt);
		//			#endregion
		//
		//			#region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
		//			paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(updAcceptOdrWork.UpdateDateTime);
		//			paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(updAcceptOdrWork.FileHeaderGuid);
		//			paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(updAcceptOdrWork.UpdEmployeeCode);
		//			paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(updAcceptOdrWork.UpdAssemblyId1);
		//			paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(updAcceptOdrWork.UpdAssemblyId2);
		//			paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(updAcceptOdrWork.AcceptAnOrderNo);
		//			paraDepositAllowanceTtl.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.DepositAllowanceTtl);
		//			paraMnyDepoAllowanceTtl.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.MnyDepoAllowanceTtl);
		//			paraDepositAllowance1.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.DepositAllowance1);
		//			paraMnyOnDepoAllowance1.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.MnyOnDepoAllowance1);
		//			paraDepositAllowance2.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.DepositAllowance2);
		//			paraMnyOnDepoAllowance2.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.MnyOnDepoAllowance2);
		//			paraDepositAllowance3.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.DepositAllowance3);
		//			paraMnyOnDepoAllowance3.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.MnyOnDepoAllowance3);
		//			paraDepositAllowance4.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.DepositAllowance4);
		//			paraMnyOnDepoAllowance4.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.MnyOnDepoAllowance4);
		//			paraDepositAllowance5.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.DepositAllowance5);
		//			paraMnyOnDepoAllowance5.Value = SqlDataMediator.SqlSetInt64(updAcceptOdrWork.MnyOnDepoAllowance5);
		//			paraExclusiveDepoAlwDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(updAcceptOdrWork.ExclusiveDepoAlwDate);
		//			#endregion
		//
		//			int count = sqlCommand.ExecuteNonQuery();
		//
		//			// �X�V���F�X�V�����������ꍇ�͑�PG�ł̍X�V�^�폜����Ă���Ӗ��Ŕr����߂�
		//			if(count == 0)
		//			{
		//				status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
		//
		//			}
		//			else
		//			{
		//				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//			}
		//
		//		}
		//	
		//	}
		//	catch (SqlException ex) 
		//	{
		//		if(myReader != null && !myReader.IsClosed)myReader.Close();
		//		//���N���X�ɗ�O��n���ď������Ă��炤
		//		status = base.WriteSQLErrorLog(ex);
		//	}
		//
		//	if(myReader != null && !myReader.IsClosed)myReader.Close();
		//
		//	return status;
		//}
		//
		///// <summary>
		///// �X�V�p�󒍃��[�N�����z�v�Z����
		///// </summary>
		///// <param name="CustomerCode">���Ӑ�R�[�h</param>
		///// <param name="depositAlwWork">�����������</param>
		///// <param name="updAcceptOdrWork">�󒍏�񃏁[�N</param>
		///// <param name="bf_DepositAllowance">�X�V�O�����z</param>
		///// <param name="bf_DepositCd">�X�V�O�a����敪</param>
		///// <param name="bf_CreditOrLoanCd">�X�V�O�N���W�b�g�^���[���敪</param>
		///// <returns>STATUS</returns>
		///// <remarks>
		///// <br>Note       : ���������}�X�^��񓙂���󒍏�񃏁[�N�̈����z���v�Z���܂�</br>
		///// <br>           : (�����悪�ǂ̈ʒu�ɂ��邩�Z�肵�Čv�Z)</br>
		///// <br>Programmer : 95089 ���i�@��</br>
		///// <br>Date       : 2005.08.11</br>
		///// </remarks>	
		//private int CalcAcceptOdrWorkRec(int CustomerCode, DepositAlwWork depositAlwWork, ref UpdAcceptOdrWork updAcceptOdrWork, Int64 bf_DepositAllowance, int bf_DepositCd, int bf_CreditOrLoanCd)
		//{
		//	Int64 DepositAllowance = 0;			// ���������z(�������)
		//	Int64 MnyOnDepoAllowance = 0;		// �a��������z(�������)
		//
		//	if(CustomerCode == updAcceptOdrWork.Claim1Code)
		//	{
		//		DepositAllowance = updAcceptOdrWork.DepositAllowance1;
		//		MnyOnDepoAllowance = updAcceptOdrWork.MnyOnDepoAllowance1;
		//	}
		//	else if(CustomerCode == updAcceptOdrWork.Claim2Code)
		//	{
		//		DepositAllowance = updAcceptOdrWork.DepositAllowance2;
		//		MnyOnDepoAllowance = updAcceptOdrWork.MnyOnDepoAllowance2;
		//	}
		//	else if(CustomerCode == updAcceptOdrWork.Claim3Code)
		//	{
		//		DepositAllowance = updAcceptOdrWork.DepositAllowance3;
		//		MnyOnDepoAllowance = updAcceptOdrWork.MnyOnDepoAllowance3;
		//	}
		//	else if(CustomerCode == updAcceptOdrWork.Claim4Code)
		//	{
		//		DepositAllowance = updAcceptOdrWork.DepositAllowance4;
		//		MnyOnDepoAllowance = updAcceptOdrWork.MnyOnDepoAllowance4;
		//	}
		//	else if(CustomerCode == updAcceptOdrWork.Claim5Code)
		//	{
		//		DepositAllowance = updAcceptOdrWork.DepositAllowance5;
		//		MnyOnDepoAllowance = updAcceptOdrWork.MnyOnDepoAllowance5;
		//	}
		//	else
		//	{
		//		// �����悪�����ꍇ�͔r����Ԃ�
		//		return (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
		//	}
		//
		//	// ���������z�v�Z
		//	DepositAllowance					 = DepositAllowance - bf_DepositAllowance + depositAlwWork.DepositAllowance;
		//	updAcceptOdrWork.DepositAllowanceTtl = updAcceptOdrWork.DepositAllowanceTtl - bf_DepositAllowance + depositAlwWork.DepositAllowance;
		//
		//	//�a��������z�v�Z
		//	if (bf_DepositCd == 1)
		//	{
		//		MnyOnDepoAllowance					 -= bf_DepositAllowance;
		//		updAcceptOdrWork.MnyDepoAllowanceTtl -= bf_DepositAllowance;
		//	}
		//	if(depositAlwWork.DepositCd == 1)
		//	{
		//		MnyOnDepoAllowance					 += depositAlwWork.DepositAllowance;
		//		updAcceptOdrWork.MnyDepoAllowanceTtl += depositAlwWork.DepositAllowance;
		//	}
		//
		//	// ������ʈ����z�Z�b�g
		//	if(CustomerCode == updAcceptOdrWork.Claim1Code)
		//	{
		//		updAcceptOdrWork.DepositAllowance1 = DepositAllowance;
		//		updAcceptOdrWork.MnyOnDepoAllowance1 = MnyOnDepoAllowance;
		//	}
		//	else if(CustomerCode == updAcceptOdrWork.Claim2Code)
		//	{
		//		updAcceptOdrWork.DepositAllowance2 = DepositAllowance;
		//		updAcceptOdrWork.MnyOnDepoAllowance2 = MnyOnDepoAllowance;
		//	}
		//	else if(CustomerCode == updAcceptOdrWork.Claim3Code)
		//	{
		//		updAcceptOdrWork.DepositAllowance3 = DepositAllowance;
		//		updAcceptOdrWork.MnyOnDepoAllowance3 = MnyOnDepoAllowance;
		//	}
		//	else if(CustomerCode == updAcceptOdrWork.Claim4Code)
		//	{
		//		updAcceptOdrWork.DepositAllowance4 = DepositAllowance;
		//		updAcceptOdrWork.MnyOnDepoAllowance4 = MnyOnDepoAllowance;
		//	}
		//	else if(CustomerCode == updAcceptOdrWork.Claim5Code)
		//	{
		//		updAcceptOdrWork.DepositAllowance5 = DepositAllowance;
		//		updAcceptOdrWork.MnyOnDepoAllowance5 = MnyOnDepoAllowance;
		//	}
		//
		//	return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //}
        #endregion
        // �� 20070124 18322 d

        // �� 20070124 18322 c MA.NS�p�ɕύX
        #region SF �ԓ�����񐶐������i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// �ԓ�����񐶐�����
		///// </summary>
		///// <param name="DepositCd">�a����敪</param>
		///// <param name="UpdateSecCd">�X�V���_</param>
		///// <param name="DepositAgentCode">�ԓ����S����</param>
		///// <param name="AddUpADate">�ԓ����v���</param>
		///// <param name="depsitMainWork">�����������</param>
		///// <returns>�ԓ������</returns>
		//public DepsitMainWork CreateRedDepsitProc(int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, DepsitMainWork depsitMainWork)
		//{
		//	DepsitMainWork newDepsitMainWork = new DepsitMainWork();
		//
        //    //			newDepsitMainWork.CreateDateTime = depsitMainWork.CreateDateTime;
		//	//			newDepsitMainWork.UpdateDateTime = depsitMainWork.UpdateDateTime;
		//	newDepsitMainWork.EnterpriseCode = depsitMainWork.EnterpriseCode;
		//	//			newDepsitMainWork.FileHeaderGuid = depsitMainWork.FileHeaderGuid;
		//	newDepsitMainWork.UpdEmployeeCode = DepositAgentCode;							// �X�V�]�ƈ��R�[�h<-�����S���҃R�[�h ???
		//	newDepsitMainWork.UpdAssemblyId1 = depsitMainWork.UpdAssemblyId1;
		//	newDepsitMainWork.UpdAssemblyId2 = depsitMainWork.UpdAssemblyId2;
		//	newDepsitMainWork.LogicalDeleteCode = 0;
		//	newDepsitMainWork.DepositDebitNoteCd = 1;										// �ԍ��敪���P�F��
		//	newDepsitMainWork.DepositSlipNo = 0;											// �����ԍ�
		//	newDepsitMainWork.DepositKindCode = depsitMainWork.DepositKindCode;				// ����R�[�h
		//	newDepsitMainWork.CustomerCode = depsitMainWork.CustomerCode;					// ���Ӑ�R�[�h
		//	newDepsitMainWork.DepositCd = DepositCd;										// �a����敪
		//	newDepsitMainWork.DepositTotal = depsitMainWork.DepositTotal * -1;				// �����v
		//	newDepsitMainWork.Outline = depsitMainWork.Outline;								// �E�v
		//	newDepsitMainWork.AcceptAnOrderSalesNo = depsitMainWork.AcceptAnOrderSalesNo;	// ���グ�󒍔ԍ�
		//	newDepsitMainWork.InputDepositSecCd = depsitMainWork.InputDepositSecCd;			// �������͋��_
		//	newDepsitMainWork.DepositDate = AddUpADate;										// �������t???
		//	newDepsitMainWork.AddUpSecCode = depsitMainWork.AddUpSecCode;					// �v�㋒�_�R�[�h
		//	newDepsitMainWork.AddUpADate = AddUpADate;										// �v����t???
		//	newDepsitMainWork.UpdateSecCd = UpdateSecCd;									// �X�V���_�R�[�h???
		//	newDepsitMainWork.DepositKindName = depsitMainWork.DepositKindName;				// �������햼��
		//	newDepsitMainWork.DepositAllowance = depsitMainWork.DepositAllowance * -1;		// ���������z
		//	newDepsitMainWork.DepositAlwcBlnce = depsitMainWork.DepositAlwcBlnce * -1;		// ���������c�z
		//	newDepsitMainWork.DepositAgentCode = DepositAgentCode;							// �����S���҃R�[�h�H�H
		//	newDepsitMainWork.DepositKindDivCd = depsitMainWork.DepositKindDivCd;			// ��������敪
		//	newDepsitMainWork.FeeDeposit = depsitMainWork.FeeDeposit * -1;					// �萔�������z
		//	newDepsitMainWork.DiscountDeposit = depsitMainWork.DiscountDeposit * -1;		// �l�������z
		//	newDepsitMainWork.CreditOrLoanCd = depsitMainWork.CreditOrLoanCd;				// �N���W�b�g�^���[���敪
		//	newDepsitMainWork.CreditCompanyCode = depsitMainWork.CreditCompanyCode;			// �N���W�b�g��ЃR�[�h
		//	newDepsitMainWork.Deposit = depsitMainWork.Deposit * -1;						// �������z
		//	newDepsitMainWork.DraftDrawingDate = depsitMainWork.DraftDrawingDate;			// ��`�U�o��
		//	newDepsitMainWork.DraftPayTimeLimit = depsitMainWork.DraftPayTimeLimit;			// ��`�x������
		//	newDepsitMainWork.DebitNoteLinkDepoNo = depsitMainWork.DepositSlipNo;			// �ԍ������A���ԍ��@(���������ԍ����Z�b�g)
		//	newDepsitMainWork.LastReconcileAddUpDt = DateTime.MinValue;						// �ŏI�������݌`�������U����
		//	newDepsitMainWork.AutoDepositCd = depsitMainWork.AutoDepositCd;					// ���������敪
		//	// 20060220 Ins Start >>>>>>>>>>>>>>>
		//	newDepsitMainWork.AcpOdrDeposit = depsitMainWork.AcpOdrDeposit * -1;			// �󒍓������z
		//	newDepsitMainWork.AcpOdrChargeDeposit = depsitMainWork.AcpOdrChargeDeposit * -1;// �󒍎萔�������z
		//	newDepsitMainWork.AcpOdrDisDeposit = depsitMainWork.AcpOdrDisDeposit * -1;		// �󒍒l�������z
		//	newDepsitMainWork.VariousCostDeposit = depsitMainWork.VariousCostDeposit * - 1; // ����p�������z
		//	newDepsitMainWork.VarCostChargeDeposit = depsitMainWork.VarCostChargeDeposit * -1;	// ����p�萔�������z
		//	newDepsitMainWork.VarCostDisDeposit = depsitMainWork.VarCostDisDeposit * -1;	// ����p�l�������z
		//	newDepsitMainWork.AcpOdrDepositAlwc = depsitMainWork.AcpOdrDepositAlwc * -1;	// �󒍓��������z
		//	newDepsitMainWork.AcpOdrDepoAlwcBlnce = depsitMainWork.AcpOdrDepoAlwcBlnce * -1;// �󒍓��������c��
		//	newDepsitMainWork.VarCostDepoAlwc = depsitMainWork.VarCostDepoAlwc * -1;		// ����p���������z
		//	newDepsitMainWork.VarCostDepoAlwcBlnce = depsitMainWork.VarCostDepoAlwcBlnce * -1; // ����p���������c��
        //    // 20060220 Ins End <<<<<<<<<<<<<<<<
		//
        //    return newDepsitMainWork;
        //}
        #endregion
        // �� 20070124 18322 c

        // �� 20070124 18322 c MA.NS�p�ɕύX
        #region SF �ԓ���������񐶐������i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// �ԓ���������񐶐�����
		///// </summary>
		///// <param name="DepositCd">�a����敪</param>
		///// <param name="UpdateSecCd">�X�V���_</param>
		///// <param name="DepositAgentCode">�ԓ����S����</param>
		///// <param name="AddUpADate">�ԓ����v���</param>
		///// <param name="depositAlwWorkList">���������������</param>
		///// <returns>�ԓ����������</returns>
		//DepositAlwWork[] CreateRedDepositAlwWorkProc(int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, DepositAlwWork[] depositAlwWorkList)
		//{
		//	ArrayList newDepositAlwWorkList = new ArrayList();
		//	
		//	for(int ix=0; ix < depositAlwWorkList.Length; ix++)
		//	{
		//		DepositAlwWork newDepositAlwWork = new DepositAlwWork();
		//		//				newDepositAlwWork.CreateDateTime = depositAlwWorkList[ix].CreateDateTime;
		//		//				newDepositAlwWork.UpdateDateTime = depositAlwWorkList[ix].UpdateDateTime;
		//		newDepositAlwWork.EnterpriseCode = depositAlwWorkList[ix].EnterpriseCode;
		//		//				newDepositAlwWork.FileHeaderGuid = depositAlwWorkList[ix].FileHeaderGuid;
		//		newDepositAlwWork.UpdEmployeeCode = DepositAgentCode;										// �X�V�]�ƈ��R�[�h<-�����S���҃R�[�h ???
		//		//				newDepositAlwWork.UpdAssemblyId1 = depositAlwWorkList[ix].UpdAssemblyId1;
		//		//				newDepositAlwWork.UpdAssemblyId2 = depositAlwWorkList[ix].UpdAssemblyId2;
		//		newDepositAlwWork.LogicalDeleteCode = 0;
		//		newDepositAlwWork.CustomerCode = depositAlwWorkList[ix].CustomerCode;
		//		newDepositAlwWork.AddUpSecCode = depositAlwWorkList[ix].AddUpSecCode;
		//		newDepositAlwWork.AcceptAnOrderNo = depositAlwWorkList[ix].AcceptAnOrderNo;
		//		newDepositAlwWork.DepositSlipNo = 0;														// �����`�[�ԍ�
		//		newDepositAlwWork.DepositKindCode = depositAlwWorkList[ix].DepositKindCode;
		//		newDepositAlwWork.DepositInputDate = AddUpADate;											// �������͓��t
		//		newDepositAlwWork.DepositAllowance = depositAlwWorkList[ix].DepositAllowance * -1;			// �����z
		//		newDepositAlwWork.ReconcileDate = DateTime.Now;												// �����ݓ����V�X�e�����t
		//		newDepositAlwWork.ReconcileAddUpDate = AddUpADate;											// �����݌v����������v���
		//		newDepositAlwWork.DebitNoteOffSetCd = 1;													// �ԓ`���E�敪 1:��
		//		newDepositAlwWork.DepositCd = DepositCd;													// �a����敪���p�����[�^�l
		//		newDepositAlwWork.CreditOrLoanCd = depositAlwWorkList[ix].CreditOrLoanCd;
		//		// 20060220 Ins Start >>����p�ʓ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		//		newDepositAlwWork.AcpOdrDepositAlwc = depositAlwWorkList[ix].AcpOdrDepositAlwc * -1;		// �󒍈����z
		//		newDepositAlwWork.VarCostDepoAlwc	= depositAlwWorkList[ix].VarCostDepoAlwc * -1;			// ����p�����z
		//		// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		//
		//
		//		newDepositAlwWorkList.Add(newDepositAlwWork);
		//	}
		//
		//	return (DepositAlwWork[])newDepositAlwWorkList.ToArray(typeof(DepositAlwWork));
        //}
        #endregion
        // �� 20070124 18322 c

        // �� 20070124 18322 c MA.NS�p�ɕύX
        #region SF �V��������񐶐������i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// �V��������񐶐�����
		///// </summary>
		///// <param name="UpdateSecCd">�X�V���_</param>
		///// <param name="DepositAgentCode">�����S����</param>
		///// <param name="AddUpADate">�����v���</param>
		///// <param name="depsitMainWork">�����������</param>
		///// <returns>�V���������</returns>
		//public DepsitMainWork CreateNewBlackDepsitProc(string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, DepsitMainWork depsitMainWork)
		//{
		//	DepsitMainWork newDepsitMainWork = new DepsitMainWork();
		//
		//	//			newDepsitMainWork.CreateDateTime = depsitMainWork.CreateDateTime;
		//	//			newDepsitMainWork.UpdateDateTime = depsitMainWork.UpdateDateTime;
		//	newDepsitMainWork.EnterpriseCode = depsitMainWork.EnterpriseCode;
		//	//			newDepsitMainWork.FileHeaderGuid = depsitMainWork.FileHeaderGuid;
		//	newDepsitMainWork.UpdEmployeeCode = UpdateSecCd;								// �X�V�]�ƈ��R�[�h<-�����S���҃R�[�h ???
		//	newDepsitMainWork.UpdAssemblyId1 = depsitMainWork.UpdAssemblyId1;
		//	newDepsitMainWork.UpdAssemblyId2 = depsitMainWork.UpdAssemblyId2;
		//	newDepsitMainWork.LogicalDeleteCode = 0;
		//	newDepsitMainWork.DepositDebitNoteCd = 0;										// �ԍ��敪���O�F��
		//	newDepsitMainWork.DepositSlipNo = 0;											// �����ԍ�
		//	newDepsitMainWork.DepositKindCode = depsitMainWork.DepositKindCode;				// ����R�[�h
		//	newDepsitMainWork.CustomerCode = depsitMainWork.CustomerCode;					// ���Ӑ�R�[�h
		//	newDepsitMainWork.DepositCd = depsitMainWork.DepositCd;							// �a����敪
		//	newDepsitMainWork.DepositTotal = depsitMainWork.DepositTotal;					// �����v
		//	newDepsitMainWork.Outline = depsitMainWork.Outline;								// �E�v
		//	newDepsitMainWork.AcceptAnOrderSalesNo = depsitMainWork.AcceptAnOrderSalesNo;	// ���グ�󒍔ԍ�
		//	newDepsitMainWork.InputDepositSecCd = depsitMainWork.InputDepositSecCd;			// �������͋��_
		//	newDepsitMainWork.DepositDate = AddUpADate;										// �������t???
		//	newDepsitMainWork.AddUpSecCode = depsitMainWork.AddUpSecCode;					// �v�㋒�_�R�[�h
		//	newDepsitMainWork.AddUpADate = AddUpADate;										// �v����t???
		//	newDepsitMainWork.UpdateSecCd = UpdateSecCd;									// �X�V���_�R�[�h???
		//	newDepsitMainWork.DepositKindName = depsitMainWork.DepositKindName;				// �������햼��
		//	newDepsitMainWork.DepositAllowance = depsitMainWork.DepositAllowance;			// ���������z
		//	newDepsitMainWork.DepositAlwcBlnce = depsitMainWork.DepositAlwcBlnce;			// ���������c�z
		//	newDepsitMainWork.DepositAgentCode = DepositAgentCode;							// �����S���҃R�[�h�H�H
		//	newDepsitMainWork.DepositKindDivCd = depsitMainWork.DepositKindDivCd;			// ��������敪
		//	newDepsitMainWork.FeeDeposit = depsitMainWork.FeeDeposit;						// �萔�������z
		//	newDepsitMainWork.DiscountDeposit = depsitMainWork.DiscountDeposit;				// �l�������z
		//	newDepsitMainWork.CreditOrLoanCd = depsitMainWork.CreditOrLoanCd;				// �N���W�b�g�^���[���敪
		//	newDepsitMainWork.CreditCompanyCode = depsitMainWork.CreditCompanyCode;			// �N���W�b�g��ЃR�[�h
		//	newDepsitMainWork.Deposit = depsitMainWork.Deposit;								// �������z
		//	newDepsitMainWork.DraftDrawingDate = depsitMainWork.DraftDrawingDate;			// ��`�U�o��
		//	newDepsitMainWork.DraftPayTimeLimit = depsitMainWork.DraftPayTimeLimit;			// ��`�x������
		//	newDepsitMainWork.DebitNoteLinkDepoNo = 0;										// �ԍ������A���ԍ��@(�Ȃ�)
		//	newDepsitMainWork.LastReconcileAddUpDt = DateTime.MinValue;						// �ŏI�������݌`��� ����U����
		//	newDepsitMainWork.AutoDepositCd = depsitMainWork.AutoDepositCd;					// ���������敪
		//	// 20060220 Ins Start >>>>>>>>>>>>>>>
		//	newDepsitMainWork.AcpOdrDeposit = depsitMainWork.AcpOdrDeposit;					// �󒍓������z
		//	newDepsitMainWork.AcpOdrChargeDeposit = depsitMainWork.AcpOdrChargeDeposit;		// �󒍎萔�������z
		//	newDepsitMainWork.AcpOdrDisDeposit = depsitMainWork.AcpOdrDisDeposit;			// �󒍒l�������z
		//	newDepsitMainWork.VariousCostDeposit = depsitMainWork.VariousCostDeposit;		// ����p�������z
		//	newDepsitMainWork.VarCostChargeDeposit = depsitMainWork.VarCostChargeDeposit;	// ����p�萔�������z
		//	newDepsitMainWork.VarCostDisDeposit = depsitMainWork.VarCostDisDeposit;			// ����p�l�������z
		//	newDepsitMainWork.AcpOdrDepositAlwc = depsitMainWork.AcpOdrDepositAlwc;			// �󒍓��������z
		//	newDepsitMainWork.AcpOdrDepoAlwcBlnce = depsitMainWork.AcpOdrDepoAlwcBlnce;		// �󒍓��������c��
		//	newDepsitMainWork.VarCostDepoAlwc = depsitMainWork.VarCostDepoAlwc;				// ����p���������z
		//	newDepsitMainWork.VarCostDepoAlwcBlnce = depsitMainWork.VarCostDepoAlwcBlnce;	// ����p���������c��
		//	// 20060220 Ins End <<<<<<<<<<<<<<<<
		//
		//
		//	return newDepsitMainWork;
        //}
        #endregion
        // �� 20070124 18322 c

        // �� 20070518 18322 d ����Ȃ��̂ō폜
        #region ��������}�X�^�����擾���܂�(�e�X�g�p�����W�b�N) �폜
        ///// <summary>
        ///// ��������}�X�^�����擾���܂�(�e�X�g�p�����W�b�N)
        ///// </summary>
        ///// <param name="EnterpriseCode">��ƃR�[�h</param>
        ///// <param name="ClaimCode">������R�[�h</param>
        ///// <param name="salesSlipWorkList">����f�[�^�i��������f�[�^�j</param>
        ///// <param name="sqlConnection">�R�l�N�V�������</param>
        ///// <param name="sqlTransaction">�g�����U�N�V�������</param>
        ///// <returns>�V���������</returns>
        //// �� 20070123 18322 c MA.NS�p�ɕύX�iMA.NS�ł́A��������f�[�^�̕ς��ɔ���f�[�^���g�p�j
		////private int ReadDmdSalesWorkRec(string EnterpriseCode, int ClaimCode, out DmdSalesWork[] DmdSalesWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //
		//private int ReadDmdSalesWorkRec(string EnterpriseCode, int ClaimCode, out SalesSlipWork[] salesSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //// �� 20070123 18322 c
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
	    //
		//	SqlDataReader myReader = null;
        //
        //    ArrayList dmdSalesWorkArrayList = new ArrayList();
        //
		//	try 
		//	{
        //        // �� 20070126 18322 c MA.NS�p�ɕύX
        //        #region SF ��������}�X�^ SELECT���i�R�����g�A�E�g�j
        //        ////Select�R�}���h�̐���
		//		//using(SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, SLIPNORF, DEBITNOTEDIVRF, CUSTOMERCODERF, CARMNGNORF, CLAIMCODERF, ADDUPADATERF, ACCEPTANORDERSALESRF, ACPTANODRDISCOUNTTTLRF, ACCEPTANORDERCONSTAXRF, TOTALVARIOUSCOSTRF, VARCSTTAXTOTALRF, VARCSTTAXFREETOTALRF, VARCST1RF, VARCST2RF, VARCST3RF, VARCST4RF, VARCST5RF, VARCST6RF, VARCST7RF, VARCST8RF, VARCST9RF, VARCST10RF, VARCST11RF, VARCST12RF, VARCST13RF, VARCST14RF, VARCST15RF, VARCST16RF, VARCST17RF, VARCST18RF, VARCST19RF, VARCST20RF, VARCSTDIV1RF, VARCSTDIV2RF, VARCSTDIV3RF, VARCSTDIV4RF, VARCSTDIV5RF, VARCSTDIV6RF, VARCSTDIV7RF, VARCSTDIV8RF, VARCSTDIV9RF, VARCSTDIV10RF, VARCSTDIV11RF, VARCSTDIV12RF, VARCSTDIV13RF, VARCSTDIV14RF, VARCSTDIV15RF, VARCSTDIV16RF, VARCSTDIV17RF, VARCSTDIV18RF, VARCSTDIV19RF, VARCSTDIV20RF, VARCSTCONSTAXRF, DEPOSITALLOWANCERF, DEPOSITALWCBLNCERF, DATAINPUTSYSTEMRF, DEMANDADDUPSECCDRF, RESULTSADDUPSECCDRF, UPDATESECCDRF, ACCEPTANORDERDATERF, CARDELIEXPECTEDDATERF, SALESEMPLOYEECDRF, SALESDIVRF, SALESNAMERF, DEBITNLNKACPTANODRRF, DEMANDPRORATACDRF, LASTRECONCILEDATERF, NUMBERPLATE1CODERF, NUMBERPLATE1NAMERF, NUMBERPLATE2RF, NUMBERPLATE3RF, NUMBERPLATE4RF, MAKERNAMERF, MODELNAMERF, DEMANDABLESALESNOTERF, CREDITORLOANCDRF, CREDITCOMPANYCODERF, CREDITSALESRF, CREDITALLOWANCERF, CREDITALWCBLNCERF, CORPORATEDIVCODERF, AACOUNTRF, MNYONDEPOALLOWANCERF, ACPTANODRSTATUSRF, LASTRECONCILEADDUPDTRF, CARINSPECTORGECDRF, GRADENAMERF "
		//		//		  +"FROM DMDSALESRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CLAIMCODERF=@FINDCLAIMCODE", sqlConnection, sqlTransaction))
        //        #endregion
        //
        //        #region ����f�[�^ SELECT��
        //        string selectSql = "SELECT CREATEDATETIMERF"
        //                         +       ",UPDATEDATETIMERF"
        //                         +       ",ENTERPRISECODERF"
        //                         +       ",FILEHEADERGUIDRF"
        //                         +       ",UPDEMPLOYEECODERF"
        //                         +       ",UPDASSEMBLYID1RF"
        //                         +       ",UPDASSEMBLYID2RF"
        //                         +       ",LOGICALDELETECODERF"
        //                         +       ",ACCEPTANORDERNORF"
        //                         +       ",ACPTANODRSTATUSRF"
        //                         +       ",SALESSLIPNUMRF"
        //                         +       ",ACPTANODRSLIPNUMRF"
        //                         +       ",ESTIMATESLIPNORF"
        //                         +       ",DEBITNOTEDIVRF"
        //                         +       ",DEBITNLNKACPTANODRRF"
        //                         +       ",SALESSLIPCDRF"
        //                         +       ",SALESFORMALRF"
        //                         +       ",SALESINPSECCDRF"
        //                         +       ",DEMANDADDUPSECCDRF"
        //                         +       ",RESULTSADDUPSECCDRF"
        //                         +       ",UPDATESECCDRF"
        //                         +       ",SEARCHSLIPDATERF"
        //                         +       ",ESTIMATEDATERF"
        //                         +       ",ACCEPTANORDERDATERF"
        //                         +       ",DELIGDSCMPLTDUEDATERF"
        //                         +       ",SHIPMENTDAYRF"
        //                         +       ",SALESDATERF"
        //                         +       ",ADDUPADATERF"
        //                         +       ",FRONTEMPLOYEECDRF"
        //                         +       ",FRONTEMPLOYEENMRF"
        //                         +       ",SALESEMPLOYEECDRF"
        //                         +       ",SALESEMPLOYEENMRF"
        //                         +       ",WAYTOORDERRF"
        //                         +       ",SALESSUBTOTALRF"
        //                         +       ",SALSUBTTLSUBTOOUTTAXRF"
        //                         +       ",SALSUBTTLSUBTOINTAXRF"
        //                         +       ",SALSUBTTLSUBTOTAXFRERF"
        //                         +       ",SALSUBTOTALOUTTAXRF"
        //                         +       ",SALSUBTOTALINTAXRF"
        //                         +       ",TOTALDISCOUNTRF"
        //                         +       ",TOTALDISSUBTOOUTTAXRF"
        //                         +       ",TOTALDISSUBTOINTAXRF"
        //                         +       ",TOTALDISSUBTOTAXFREERF"
        //                         +       ",TOTALDISCOUNTOUTTAXRF"
        //                         +       ",TOTALDISCOUNTINTAXRF"
        //                         +       ",TOTALCARRIERDISCOUNTRF"
        //                         +       ",TTLCDISSUBTOOUTTAXRF"
        //                         +       ",TTLCDISSUBTOINTAXRF"
        //                         +       ",TTLCDISSUBTOTAXFREERF"
        //                         +       ",TTLCDISCOUNTOUTTAXRF"
        //                         +       ",TTLCDISCOUNTINTAXRF"
        //                         +       ",TOTALSTDISCOUNTRF"
        //                         +       ",TTLSTDISSUBTOOUTTAXRF"
        //                         +       ",TTLSTDISSUBTOINTAXRF"
        //                         +       ",TTLSTDISSUBTOTAXFREERF"
        //                         +       ",TTLSTDISCOUNTOUTTAXRF"
        //                         +       ",TTLSTDISCOUNTINTAXRF"
        //                         +       ",TTLSTCARRDISCOUNTRF"
        //                         +       ",TTLSTCDISSUBTOOUTTAXRF"
        //                         +       ",TTLSTCDISSUBTOINTAXRF"
        //                         +       ",TTLSTCDISSUBTOTAXFRERF"
        //                         +       ",TTLSTCDISCOUNTOUTTAXRF"
        //                         +       ",TTLSTCDISCOUNTINTAXRF"
        //                         +       ",TOTALSALESMONEYRF"
        //                         +       ",TTLITDEDSALESOUTTAXRF"
        //                         +       ",TTLITDEDSALESINTAXRF"
        //                         +       ",TTLITDEDSALESTAXFREERF"
        //                         +       ",TOTALSALESOUTTAXRF"
        //                         +       ",TOTALSALESINTAXRF"
        //                         +       ",TOTALCOSTRF"
        //                         +       ",TTLITDEDCOSTOUTTAXRF"
        //                         +       ",TTLITDEDCOSTINTAXRF"
        //                         +       ",TTLITDEDTAXFREERF"
        //                         +       ",TOTALCOSTOUTERTAXRF"
        //                         +       ",TOTALCOSTINNERTAXRF"
        //                         +       ",TTLINCENTIVERECVRF"
        //                         +       ",TTLITDINCRECVOUTTAXRF"
        //                         +       ",TTLITDINCRECVINTAXRF"
        //                         +       ",TTLITDINCRECVTAXFREERF"
        //                         +       ",TOTALINCRECVOUTTAXRF"
        //                         +       ",TOTALINCRECVINTAXRF"
        //                         +       ",TTLINCENTIVEDTBTRF"
        //                         +       ",TTLITDINCDTBTOUTTAXRF"
        //                         +       ",TTLITDINCDTBTINTAXRF"
        //                         +       ",TTLITDINCDTBTTAXFREERF"
        //                         +       ",TOTALINCDTBTOUTTAXRF"
        //                         +       ",TOTALINCDTBTINTAXRF"
        //                         +       ",CONSTAXLAYMETHODRF"
        //                         +       ",CONSTAXRATERF"
        //                         +       ",FRACTIONPROCCDRF"
        //                         +       ",ACCRECDIVCDRF"
        //                         +       ",AUTODEPOSITCDRF"
        //                         +       ",DEMANDABLETTLRF"
        //                         +       ",DEPOSITALLOWANCETTLRF"
        //                         +       ",MNYDEPOALLOWANCETTLRF"
        //                         +       ",DEPOSITALWCBLNCERF"
        //                         +       ",CLAIMCODERF"
        //                         +       ",CLAIMNAME1RF"
        //                         +       ",CLAIMNAME2RF"
        //                         +       ",CUSTOMERCODERF"
        //                         +       ",CUSTOMERNAMERF"
        //                         +       ",CUSTOMERNAME2RF"
        //                         +       ",HONORIFICTITLERF"
        //                         +       ",KANARF"
        //                         +       ",SEXCODERF"
        //                         +       ",CORPORATEDIVCODERF"
        //                         +       ",GENERATIONCODERF"
        //                         +       ",CLIENTELECODERF"
        //                         +       ",RETGOODSREASONRF"
        //                         +       ",ADDRESSEECODERF"
        //                         +       ",ADDRESSEENAMERF"
        //                         +       ",ADDRESSEENAME2RF"
        //                         +       ",ADDRESSEEADDR1RF"
        //                         +       ",ADDRESSEEADDR2RF"
        //                         +       ",ADDRESSEEADDR3RF"
        //                         +       ",ADDRESSEEADDR4RF"
        //                         +       ",ADDRESSEETELNORF"
        //                         +       ",PARTYSALESLIPNUMRF"
        //                         +       ",SLIPNOTERF"
        //                         +  " FROM SALESSLIPRF"
        //                         + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
        //                         +   " AND CLAIMCODERF=@FINDCLAIMCODE"
        //                         ;
        //        #endregion
        //        using (SqlCommand sqlCommand = new SqlCommand(selectSql, sqlConnection, sqlTransaction))
        //        // �� 20070126 18322 c
		//		{
        //
		//			//Prameter�I�u�W�F�N�g�̍쐬
		//			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//			SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
        //
		//			//Parameter�I�u�W�F�N�g�֒l�ݒ�
		//			findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
		//			findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(ClaimCode);
        //
		//			myReader = sqlCommand.ExecuteReader();
		//			while(myReader.Read())
		//			{
        //                // �� 20070123 18322 c MA.NS�p�ɕύX
        //                #region SF ��������f�[�^��SQL�f�[�^�����i�S�ăR�����g�A�E�g�j
        //                //DmdSalesWork dmdSalesWork = new DmdSalesWork();
        //                //
		//				//#region �N���X�֑��
		//				//dmdSalesWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
		//				//dmdSalesWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
		//				//dmdSalesWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
		//				//dmdSalesWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
		//				//dmdSalesWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
		//				//dmdSalesWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
		//				//dmdSalesWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
		//				//dmdSalesWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
		//				//dmdSalesWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACCEPTANORDERNORF"));
		//				//dmdSalesWork.SlipNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SLIPNORF"));
		//				//dmdSalesWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEBITNOTEDIVRF"));
		//				//dmdSalesWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERCODERF"));
		//				//dmdSalesWork.CarMngNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CARMNGNORF"));
		//				//dmdSalesWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CLAIMCODERF"));
		//				//dmdSalesWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ADDUPADATERF"));
		//				//dmdSalesWork.AcceptAnOrderSales = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACCEPTANORDERSALESRF"));
		//				//dmdSalesWork.AcptAnOdrDiscountTtl = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPTANODRDISCOUNTTTLRF"));
		//				//dmdSalesWork.AcceptAnOrderConsTax = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACCEPTANORDERCONSTAXRF"));
		//				//dmdSalesWork.TotalVariousCost = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("TOTALVARIOUSCOSTRF"));
		//				//dmdSalesWork.VarCstTaxTotal = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTTAXTOTALRF"));
		//				//dmdSalesWork.VarCstTaxFreeTotal = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTTAXFREETOTALRF"));
		//				//dmdSalesWork.VarCst1 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST1RF"));
		//				//dmdSalesWork.VarCst2 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST2RF"));
		//				//dmdSalesWork.VarCst3 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST3RF"));
		//				//dmdSalesWork.VarCst4 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST4RF"));
		//				//dmdSalesWork.VarCst5 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST5RF"));
		//				//dmdSalesWork.VarCst6 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST6RF"));
		//				//dmdSalesWork.VarCst7 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST7RF"));
		//				//dmdSalesWork.VarCst8 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST8RF"));
		//				//dmdSalesWork.VarCst9 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST9RF"));
		//				//dmdSalesWork.VarCst10 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST10RF"));
		//				//dmdSalesWork.VarCst11 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST11RF"));
		//				//dmdSalesWork.VarCst12 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST12RF"));
		//				//dmdSalesWork.VarCst13 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST13RF"));
		//				//dmdSalesWork.VarCst14 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST14RF"));
		//				//dmdSalesWork.VarCst15 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST15RF"));
		//				//dmdSalesWork.VarCst16 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST16RF"));
		//				//dmdSalesWork.VarCst17 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST17RF"));
		//				//dmdSalesWork.VarCst18 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST18RF"));
		//				//dmdSalesWork.VarCst19 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST19RF"));
		//				//dmdSalesWork.VarCst20 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCST20RF"));
		//				//dmdSalesWork.VarCstDiv1 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV1RF"));
		//				//dmdSalesWork.VarCstDiv2 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV2RF"));
		//				//dmdSalesWork.VarCstDiv3 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV3RF"));
		//				//dmdSalesWork.VarCstDiv4 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV4RF"));
		//				//dmdSalesWork.VarCstDiv5 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV5RF"));
		//				//dmdSalesWork.VarCstDiv6 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV6RF"));
		//				//dmdSalesWork.VarCstDiv7 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV7RF"));
		//				//dmdSalesWork.VarCstDiv8 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV8RF"));
		//				//dmdSalesWork.VarCstDiv9 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV9RF"));
		//				//dmdSalesWork.VarCstDiv10 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV10RF"));
		//				//dmdSalesWork.VarCstDiv11 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV11RF"));
		//				//dmdSalesWork.VarCstDiv12 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV12RF"));
		//				//dmdSalesWork.VarCstDiv13 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV13RF"));
		//				//dmdSalesWork.VarCstDiv14 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV14RF"));
		//				//dmdSalesWork.VarCstDiv15 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV15RF"));
		//				//dmdSalesWork.VarCstDiv16 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV16RF"));
		//				//dmdSalesWork.VarCstDiv17 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV17RF"));
		//				//dmdSalesWork.VarCstDiv18 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV18RF"));
		//				//dmdSalesWork.VarCstDiv19 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV19RF"));
		//				//dmdSalesWork.VarCstDiv20 = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTDIV20RF"));
		//				//dmdSalesWork.VarCstConsTax = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCSTCONSTAXRF"));
		//				//dmdSalesWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALLOWANCERF"));
		//				//dmdSalesWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
		//				//dmdSalesWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
		//				//dmdSalesWork.DemandAddUpSecCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
		//				//dmdSalesWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
		//				//dmdSalesWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDATESECCDRF"));
		//				//dmdSalesWork.AcceptAnOrderDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ACCEPTANORDERDATERF"));
		//				//dmdSalesWork.CarDeliExpectedDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("CARDELIEXPECTEDDATERF"));
		//				//dmdSalesWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SALESEMPLOYEECDRF"));
		//				//dmdSalesWork.SalesDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SALESDIVRF"));
		//				//dmdSalesWork.SalesName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SALESNAMERF"));
		//				//dmdSalesWork.DebitNLnkAcptAnOdr = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEBITNLNKACPTANODRRF"));
		//				//dmdSalesWork.DemandProRataCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("DEMANDPRORATACDRF"));
		//				//dmdSalesWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERPLATE1CODERF"));
		//				//dmdSalesWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NUMBERPLATE1NAMERF"));
		//				//dmdSalesWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NUMBERPLATE2RF"));
		//				//dmdSalesWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("NUMBERPLATE3RF"));
		//				//dmdSalesWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("NUMBERPLATE4RF"));
		//				//dmdSalesWork.MakerName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MAKERNAMERF"));
		//				//dmdSalesWork.ModelName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MODELNAMERF"));
		//				//dmdSalesWork.DemandableSalesNote = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("DEMANDABLESALESNOTERF"));
		//				//dmdSalesWork.CreditOrLoanCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CREDITORLOANCDRF"));
		//				//dmdSalesWork.CreditCompanyCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("CREDITCOMPANYCODERF"));
		//				//dmdSalesWork.CreditSales = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("CREDITSALESRF"));
		//				//dmdSalesWork.CreditAllowance = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("CREDITALLOWANCERF"));
		//				//dmdSalesWork.CreditAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("CREDITALWCBLNCERF"));
		//				//dmdSalesWork.CorporateDivCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CORPORATEDIVCODERF"));
		//				//dmdSalesWork.AaCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("AACOUNTRF"));
		//				//dmdSalesWork.MnyOnDepoAllowance = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("MNYONDEPOALLOWANCERF"));
		//				//dmdSalesWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ACPTANODRSTATUSRF"));
		//				//dmdSalesWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));
		//				//dmdSalesWork.CarInspectOrGeCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CARINSPECTORGECDRF"));
		//				//dmdSalesWork.GradeName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("GRADENAMERF"));
		//				//#endregion
        //                //
		//				//dmdSalesWorkArrayList.Add(dmdSalesWork);
        //                #endregion
        //
        //                #region MA.NS ����f�[�^��SQL�f�[�^��ݒ�
        //                SalesSlipWork salesSlipWork = new SalesSlipWork();
        //
        //                // �쐬����
        //                salesSlipWork.CreateDateTime            = SqlDataMediator.SqlGetDateTimeFromTicks   (myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
        //                // �X�V����
        //                salesSlipWork.UpdateDateTime            = SqlDataMediator.SqlGetDateTimeFromTicks   (myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
        //                // ��ƃR�[�h
        //                salesSlipWork.EnterpriseCode            = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("ENTERPRISECODERF" ));
        //                // GUID
        //                salesSlipWork.FileHeaderGuid            = SqlDataMediator.SqlGetGuid                (myReader,myReader.GetOrdinal("FILEHEADERGUIDRF" ));
        //                // �X�V�]�ƈ��R�[�h
        //                salesSlipWork.UpdEmployeeCode           = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
        //                // �X�V�A�Z���u��ID1
        //                salesSlipWork.UpdAssemblyId1            = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF" ));
        //                // �X�V�A�Z���u��ID2
        //                salesSlipWork.UpdAssemblyId2            = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF" ));
        //                // �_���폜�敪
        //                salesSlipWork.LogicalDeleteCode         = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
        //                // �󒍔ԍ�
        //                salesSlipWork.AcceptAnOrderNo           = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("ACCEPTANORDERNORF"));
        //                // �󒍃X�e�[�^�X
        //                salesSlipWork.AcptAnOdrStatus           = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("ACPTANODRSTATUSRF"));
        //                // ����`�[�ԍ�
        //                salesSlipWork.SalesSlipNum              = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("SALESSLIPNUMRF"));
        //                // �󒍓`�[�ԍ�
        //                salesSlipWork.AcptAnOdrSlipNum          = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("ACPTANODRSLIPNUMRF"));
        //                // ���ϓ`�[�ԍ�
        //                salesSlipWork.EstimateSlipNo            = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("ESTIMATESLIPNORF"));
        //                // �ԓ`�敪
        //                salesSlipWork.DebitNoteDiv              = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("DEBITNOTEDIVRF"));
        //                // �ԍ��A���󒍔ԍ�
        //                salesSlipWork.DebitNLnkAcptAnOdr        = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("DEBITNLNKACPTANODRRF"));
        //                // ����`�[�敪
        //                salesSlipWork.SalesSlipCd               = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("SALESSLIPCDRF"));
        //                // ����`��
        //                salesSlipWork.SalesFormal               = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("SALESFORMALRF"));
        //                // ������͋��_�R�[�h
        //                salesSlipWork.SalesInpSecCd             = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("SALESINPSECCDRF"));
        //                // �����v�㋒�_�R�[�h
        //                salesSlipWork.DemandAddUpSecCd          = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
        //                // ���ьv�㋒�_�R�[�h
        //                salesSlipWork.ResultsAddUpSecCd         = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
        //                // �X�V���_�R�[�h
        //                salesSlipWork.UpdateSecCd               = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("UPDATESECCDRF"));
        //                // �`�[�������t
        //                salesSlipWork.SearchSlipDate            = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("SEARCHSLIPDATERF"));
        //                // ���ϓ��t
        //                salesSlipWork.EstimateDate              = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ESTIMATEDATERF"));
        //                // �󒍓�
        //                salesSlipWork.AcceptAnOrderDate         = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ACCEPTANORDERDATERF"));
        //                // �[�i�����\���
        //                salesSlipWork.DeliGdsCmpltDueDate       = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));
        //                // �o�ד��t
        //                salesSlipWork.ShipmentDay               = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("SHIPMENTDAYRF"));
        //                // ������t
        //                salesSlipWork.SalesDate                 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("SALESDATERF"));
        //                // �v����t
        //                salesSlipWork.AddUpADate                = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("ADDUPADATERF"));
        //                // ��t�]�ƈ��R�[�h
        //                salesSlipWork.FrontEmployeeCd           = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
        //                // ��t�]�ƈ�����
        //                salesSlipWork.FrontEmployeeNm           = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
        //                // �̔��]�ƈ��R�[�h
        //                salesSlipWork.SalesEmployeeCd           = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("SALESEMPLOYEECDRF"));
        //                // �̔��]�ƈ�����
        //                salesSlipWork.SalesEmployeeNm           = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("SALESEMPLOYEENMRF"));
        //                // �������@
        //                salesSlipWork.WayToOrder                = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("WAYTOORDERRF"));
        //                // ���㏬�v
        //                salesSlipWork.SalesSubtotal             = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("SALESSUBTOTALRF"));
        //                // ���㏬�v�O�őΏۊz
        //                salesSlipWork.SalSubttlSubToOutTax      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("SALSUBTTLSUBTOOUTTAXRF"));
        //                // ���㏬�v�O�őΏۊz
        //                salesSlipWork.SalSubttlSubToOutTax      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("SALSUBTTLSUBTOOUTTAXRF"));
        //                // ���㏬�v���őΏۊz
        //                salesSlipWork.SalSubttlSubToInTax       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("SALSUBTTLSUBTOINTAXRF"));
        //                // ���㏬�v��ېőΏۊz
        //                salesSlipWork.SalSubttlSubToTaxFre      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("SALSUBTTLSUBTOTAXFRERF"));
        //                // ���㏬�v�O�Ŋz
        //                salesSlipWork.SalSubtotalOutTax         = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("SALSUBTOTALOUTTAXRF"));
        //                // ���㏬�v���Ŋz
        //                salesSlipWork.SalSubtotalInTax          = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("SALSUBTOTALINTAXRF"));
        //                // ���v���Ж��גl���z
        //                salesSlipWork.TotalDiscount             = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALDISCOUNTRF"));
        //                // ���v���Ж��גl���O�őΏۊz
        //                salesSlipWork.TotalDisSubToOutTax       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALDISSUBTOOUTTAXRF"));
        //                // ���v���Ж��גl�����őΏۊz
        //                salesSlipWork.TotalDisSubToInTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALDISSUBTOINTAXRF"));
        //                // ���v���Ж��גl����ېőΏۊz
        //                salesSlipWork.TotalDisSubToTaxFree      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALDISSUBTOTAXFREERF"));
        //                // ���v���Ж��גl���O�Ŋz
        //                salesSlipWork.TotalDiscountOutTax       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALDISCOUNTOUTTAXRF"));
        //                // ���v���Ж��גl�����Ŋz
        //                salesSlipWork.TotalDiscountInTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALDISCOUNTINTAXRF"));
        //                // ���v�L�����A���גl���z
        //                salesSlipWork.TotalCarrierDiscount      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALCARRIERDISCOUNTRF"));
        //                // ���v�L�����A���גl���O�őΏۊz
        //                salesSlipWork.TtlCDisSubToOutTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLCDISSUBTOOUTTAXRF"));
        //                // ���v�L�����A���גl�����őΏۊz
        //                salesSlipWork.TtlCDisSubToInTax         = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLCDISSUBTOINTAXRF"));
        //                // ���v�L�����A���גl����ېőΏۊz
        //                salesSlipWork.TtlCDisSubToTaxFree       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLCDISSUBTOTAXFREERF"));
        //                // ���v�L�����A���גl���O�Ŋz
        //                salesSlipWork.TtlCDiscountOutTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLCDISCOUNTOUTTAXRF"));
        //                // ���v�L�����A���גl�����Ŋz
        //                salesSlipWork.TtlCDiscountInTax         = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLCDISCOUNTINTAXRF"));
        //                // ���v���Џ��v�l��
        //                salesSlipWork.TotalStDiscount           = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALSTDISCOUNTRF"));
        //                // ���v���Џ��v�l���O�őΏۊz
        //                salesSlipWork.TtlStDisSubToOutTax       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTDISSUBTOOUTTAXRF"));
        //                // ���v���Џ��v�l�����őΏۊz
        //                salesSlipWork.TtlStDisSubToInTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTDISSUBTOINTAXRF"));
        //                // ���v���Џ��v�l����ېőΏۊz
        //                salesSlipWork.TtlStDisSubToTaxFree      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTDISSUBTOINTAXRF"));
        //                // ���v���Џ��v�l���O�Ŋz
        //                salesSlipWork.TtlStDiscountOutTax       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTDISCOUNTOUTTAXRF"));
        //                // ���v���Џ��v�l�����Ŋz
        //                salesSlipWork.TtlStDiscountInTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTDISCOUNTINTAXRF"));
        //                // ���v�L�����A���v�l��
        //                salesSlipWork.TtlStCarrDiscount         = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTCARRDISCOUNTRF"));
        //                // ���v�L�����A���v�l���O�őΏۊz
        //                salesSlipWork.TtlStCDisSubToOutTax      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTCDISSUBTOOUTTAXRF"));
        //                // ���v�L�����A���v�l�����őΏۊz
        //                salesSlipWork.TtlStCDisSubToInTax       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTCDISSUBTOINTAXRF"));
        //                // ���v�L�����A���v�l����ېőΏۊz
        //                salesSlipWork.TtlStCDisSubToTaxFre      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTCDISSUBTOTAXFRERF"));
        //                // ���v�L�����A���v�l���O�Ŋz
        //                salesSlipWork.TtlStCDiscountOutTax      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTCDISCOUNTOUTTAXRF"));
        //                // ���v�L�����A���v�l�����Ŋz
        //                salesSlipWork.TtlStCDiscountInTax       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLSTCDISCOUNTINTAXRF"));
        //                // ���v������z
        //                salesSlipWork.TotalSalesMoney           = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALSALESMONEYRF"));
        //                // ���v����O�őΏۊz
        //                salesSlipWork.TtlItdedSalesOutTax       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDEDSALESOUTTAXRF"));
        //                // ���v������őΏۊz
        //                salesSlipWork.TtlItdedSalesInTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDEDSALESINTAXRF"));
        //                // ���v�����ېőΏۊz
        //                salesSlipWork.TtlItdedSalesTaxFree      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDEDSALESTAXFREERF"));
        //                // ���v����O�Ŋz
        //                salesSlipWork.TotalSalesOutTax          = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALSALESOUTTAXRF"));
        //                // ���v������Ŋz
        //                salesSlipWork.TotalSalesInTax           = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALSALESINTAXRF"));
        //                // �������v
        //                salesSlipWork.TotalCost                 = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALCOSTRF"));
        //                // ���v�����O�őΏۊz
        //                salesSlipWork.TtlItdedCostOutTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDEDCOSTOUTTAXRF"));
        //                // ���v�������őΏۊz
        //                salesSlipWork.TtlItdedCostInTax         = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDEDCOSTINTAXRF"));
        //                // ���v������ېőΏۊz
        //                salesSlipWork.TtlItdedTaxFree           = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDEDTAXFREERF"));
        //                // ���v�����O�Ŋz
        //                salesSlipWork.TotalCostOuterTax         = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALCOSTOUTERTAXRF"));
        //                // ���v�������Ŋz
        //                salesSlipWork.TotalCostInnerTax         = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALCOSTINNERTAXRF"));
        //                // ���C���Z���e�B�u�z���v
        //                salesSlipWork.TtlIncentiveRecv          = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLINCENTIVERECVRF"));
        //                // ���C���Z���e�B�u�O�őΏۊz���v
        //                salesSlipWork.TtlItdIncRecvOutTax       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDINCRECVOUTTAXRF"));
        //                // ���C���Z���e�B�u���őΏۊz���v
        //                salesSlipWork.TtlItdIncRecvInTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDINCRECVINTAXRF"));
        //                // ���C���Z���e�B�u��ېőΏۊz���v
        //                salesSlipWork.TtlItdIncRecvTaxFree      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDINCRECVTAXFREERF"));
        //                // ���C���Z���e�B�u�O�Ŋz���v
        //                salesSlipWork.TotalIncRecvOutTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALINCRECVOUTTAXRF"));
        //                // ���C���Z���e�B�u���Ŋz���v
        //                salesSlipWork.TotalIncRecvInTax         = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALINCRECVINTAXRF"));
        //                // �x���C���Z���e�B�u�z���v
        //                salesSlipWork.TtlIncentiveDtbt          = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLINCENTIVEDTBTRF"));
        //                // �x���C���Z���e�B�u�O�őΏۊz���v
        //                salesSlipWork.TtlItdIncDtbtOutTax       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDINCDTBTOUTTAXRF"));
        //                // �x���C���Z���e�B�u���őΏۊz���v
        //                salesSlipWork.TtlItdIncDtbtInTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDINCDTBTINTAXRF"));
        //                // �x���C���Z���e�B�u��ېőΏۊz���v
        //                salesSlipWork.TtlItdIncDtbtTaxFree      = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TTLITDINCDTBTTAXFREERF"));
        //                // �x���C���Z���e�B�u�O�Ŋz���v
        //                salesSlipWork.TotalIncDtbtOutTax        = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALINCDTBTOUTTAXRF"));
        //                // �x���C���Z���e�B�u���Ŋz���v
        //                salesSlipWork.TotalIncDtbtInTax         = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("TOTALINCDTBTINTAXRF"));
        //                // ����œ]�ŕ���
        //                salesSlipWork.ConsTaxLayMethod          = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
        //                // ����Őŗ�
        //                salesSlipWork.ConsTaxRate               = SqlDataMediator.SqlGetDouble              (myReader,myReader.GetOrdinal("CONSTAXRATERF"));
        //                // �[�������敪
        //                salesSlipWork.FractionProcCd            = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("FRACTIONPROCCDRF"));
        //                // ���|�敪
        //                salesSlipWork.AccRecDivCd               = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("ACCRECDIVCDRF"));
        //                // ���������敪
        //                salesSlipWork.AutoDepositCd             = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("AUTODEPOSITCDRF"));
        //                // �������v�z
        //                salesSlipWork.DemandableTtl             = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("DEMANDABLETTLRF"));
        //                // �����������v�z
        //                salesSlipWork.DepositAllowanceTtl       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("DEPOSITALLOWANCETTLRF"));
        //                // �a����������v�z
        //                salesSlipWork.MnyDepoAllowanceTtl       = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("MNYDEPOALLOWANCETTLRF"));
        //                // ���������c��
        //                salesSlipWork.DepositAlwcBlnce          = SqlDataMediator.SqlGetInt64               (myReader,myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
        //                // ������R�[�h
        //                salesSlipWork.ClaimCode                 = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("CLAIMCODERF"));
        //                // �����於��1
        //                salesSlipWork.ClaimName1                = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("CLAIMNAME1RF"));
        //                // �����於��2
        //                salesSlipWork.ClaimName2                = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("CLAIMNAME2RF"));
        //                // ���Ӑ�R�[�h
        //                salesSlipWork.CustomerCode              = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("CUSTOMERCODERF"));
        //                // ���Ӑ於��
        //                salesSlipWork.CustomerName              = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("CUSTOMERNAMERF"));
        //                // ���Ӑ於��2
        //                salesSlipWork.CustomerName2             = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("CUSTOMERNAME2RF"));
        //                // �h��
        //                salesSlipWork.HonorificTitle            = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("HONORIFICTITLERF"));
        //                // �J�i
        //                salesSlipWork.Kana                      = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("KANARF"));
        //                // ���ʃR�[�h
        //                salesSlipWork.SexCode                   = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("SEXCODERF"));
        //                // �l�E�@�l�敪
        //                salesSlipWork.CorporateDivCode          = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("CORPORATEDIVCODERF"));
        //                // �N��R�[�h
        //                salesSlipWork.GenerationCode            = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("GENERATIONCODERF"));
        //                // �q�w�R�[�h
        //                salesSlipWork.ClienteleCode             = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("CLIENTELECODERF"));
        //                // �ԕi���R
        //                salesSlipWork.RetGoodsReason            = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("RETGOODSREASONRF"));
        //                // �[�i��R�[�h
        //                salesSlipWork.AddresseeCode             = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("ADDRESSEECODERF"));
        //                // �[�i�於��
        //                salesSlipWork.AddresseeName             = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("ADDRESSEENAMERF"));
        //                // �[�i�於��2
        //                salesSlipWork.AddresseeName2            = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("ADDRESSEENAME2RF"));
        //                // �[�i��Z��1(�s���{���s��S�E�����E��)
        //                salesSlipWork.AddresseeAddr1            = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("ADDRESSEEADDR1RF"));
        //                // �[�i��Z��2(����)
        //                salesSlipWork.AddresseeAddr2            = SqlDataMediator.SqlGetInt32               (myReader,myReader.GetOrdinal("ADDRESSEEADDR2RF"));
        //                // �[�i��Z��3(�Ԓn)
        //                salesSlipWork.AddresseeAddr3            = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("ADDRESSEEADDR3RF"));
        //                // �[�i��Z��4(�A�p�[�g����)
        //                salesSlipWork.AddresseeAddr4            = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("ADDRESSEEADDR4RF"));
        //                // �[�i��d�b�ԍ�
        //                salesSlipWork.AddresseeTelNo            = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("ADDRESSEETELNORF"));
        //                // �����`�[�ԍ�
        //                salesSlipWork.PartySaleSlipNum          = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
        //                // �`�[���l
        //                salesSlipWork.SlipNote                  = SqlDataMediator.SqlGetString              (myReader,myReader.GetOrdinal("SLIPNOTERF"));
		//
        //                dmdSalesWorkArrayList.Add(salesSlipWork);
        //                #endregion
        //                // �� 20070123 18322 c
        //
		//				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//			}
		//		}
        //
		//	}
		//	catch (SqlException ex) 
		//	{
		//		//���N���X�ɗ�O��n���ď������Ă��炤
		//		status = base.WriteSQLErrorLog(ex);
		//	}
        //
		//	if(myReader != null && !myReader.IsClosed)myReader.Close();
	    //
        //    // �� 20070124 18322 c MA.NS�p�ɕύX
		//	//DmdSalesWorkList =  (DmdSalesWork[])dmdSalesWorkArrayList.ToArray(typeof(DmdSalesWork));
		//
		//	salesSlipWorkList =  (SalesSlipWork[])dmdSalesWorkArrayList.ToArray(typeof(SalesSlipWork));
        //    // �� 20070124 18322 c
        //
		//	return status;
        //}
        #endregion
        // �� 20070518 18322 d

        // �� 20070124 18322 c MA.NS�p�ɕύX
        #region SF �����X�V�p�󒍃��[�N�N���X�iMA.NS�ł͎g�p���Ȃ��̂ō폜�j
        ///// public class name:   UpdAcceptOdrWork
	    ///// <summary>
	    /////                      �����X�V�p�󒍃��[�N
	    ///// </summary>
	    ///// <remarks>
	    ///// <br>note             :   �����X�V�p�󒍃��[�N�w�b�_�t�@�C��</br>
	    ///// <br>Programmer       :   ��������</br>
	    ///// <br>Date             :   2005/8/8</br>
	    ///// <br>Genarated Date   :   2005/08/06  (CSharp File Generated Date)</br>
	    ///// <br>Update Note      :   </br>
	    ///// </remarks>
	    //public class UpdAcceptOdrWork : IFileHeader
	    //{
	    //	/// <summary>�쐬����</summary>
	    //	/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
	    //	private DateTime _createDateTime;
	    //
	    //	/// <summary>�X�V����</summary>
	    //	/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
	    //	private DateTime _updateDateTime;
	    //
	    //	/// <summary>��ƃR�[�h</summary>
	    //	/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
	    //	private string _enterpriseCode = "";
	    //
	    //	/// <summary>GUID</summary>
	    //	/// <remarks>���ʃt�@�C���w�b�_</remarks>
	    //	private Guid _fileHeaderGuid;
	    //
	    //	/// <summary>�X�V�]�ƈ��R�[�h</summary>
	    //	/// <remarks>���ʃt�@�C���w�b�_</remarks>
	    //	private string _updEmployeeCode = "";
	    //
	    //	/// <summary>�X�V�A�Z���u��ID1</summary>
	    //	/// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
	    //	private string _updAssemblyId1 = "";
	    //
	    //	/// <summary>�X�V�A�Z���u��ID2</summary>
	    //	/// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
	    //	private string _updAssemblyId2 = "";
	    //
	    //	/// <summary>�_���폜�敪</summary>
	    //	/// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
	    //	private Int32 _logicalDeleteCode;
	    //
	    //	/// <summary>�󒍔ԍ�</summary>
	    //	private Int32 _acceptAnOrderNo;
	    //
	    //	/// <summary>�����������v�z</summary>
	    //	/// <remarks>�a����������v�z���܂�</remarks>
	    //	private Int64 _depositAllowanceTtl;
	    //
	    //	/// <summary>�a����������v�z</summary>
	    //	private Int64 _mnyDepoAllowanceTtl;
	    //
	    //	/// <summary>�������敪</summary>
	    //	/// <remarks>0:������,1:�������L��</remarks>
	    //	private Int32 _demandProRataCd;
	    //
	    //	/// <summary>������@�R�[�h</summary>
	    //	private Int32 _claim1Code;
	    //
	    //	/// <summary>������A�R�[�h</summary>
	    //	/// <remarks>�iSF�͵�߼�݁j</remarks>
	    //	private Int32 _claim2Code;
	    //
	    //	/// <summary>������B�R�[�h</summary>
	    //	/// <remarks>�iSF�͵�߼�݁j</remarks>
	    //	private Int32 _claim3Code;
	    //
	    //	/// <summary>������C�R�[�h</summary>
	    //	/// <remarks>�iSF�͵�߼�݁j</remarks>
	    //	private Int32 _claim4Code;
	    //
	    //	/// <summary>������D�R�[�h</summary>
	    //	/// <remarks>�iSF�͵�߼�݁j</remarks>
	    //	private Int32 _claim5Code;
	    //
	    //	/// <summary>���������z1</summary>
	    //	/// <remarks>�a��������z1���܂�</remarks>
	    //	private Int64 _depositAllowance1;
	    //
	    //	/// <summary>�a��������z1</summary>
	    //	private Int64 _mnyOnDepoAllowance1;
	    //
	    //	/// <summary>���������z2</summary>
	    //	/// <remarks>�a��������z2���܂�</remarks>
	    //	private Int64 _depositAllowance2;
	    //
	    //	/// <summary>�a��������z2</summary>
	    //	private Int64 _mnyOnDepoAllowance2;
	    //
	    //	/// <summary>���������z3</summary>
	    //	/// <remarks>�a��������z3���܂�</remarks>
	    //	private Int64 _depositAllowance3;
	    //
	    //	/// <summary>�a��������z3</summary>
	    //	private Int64 _mnyOnDepoAllowance3;
	    //
	    //	/// <summary>���������z4</summary>
	    //	/// <remarks>�a��������z4���܂�</remarks>
	    //	private Int64 _depositAllowance4;
	    //
	    //	/// <summary>�a��������z4</summary>
	    //	private Int64 _mnyOnDepoAllowance4;
	    //
	    //	/// <summary>���������z5</summary>
	    //	/// <remarks>�a��������z5���܂�</remarks>
	    //	private Int64 _depositAllowance5;
	    //
	    //	/// <summary>�a��������z5</summary>
	    //	private Int64 _mnyOnDepoAllowance5;
	    //
	    //	/// <summary>�r���p���������X�V��</summary>
	    //	/// <remarks>DateTime:���x��100�i�m�b</remarks>
	    //	private DateTime _exclusiveDepoAlwDate;
	    //
	    //	/// public propaty name  :  CreateDateTime
	    //	/// <summary>�쐬�����v���p�e�B</summary>
	    //	/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   �쐬�����v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public DateTime CreateDateTime
	    //	{
	    //		get{return _createDateTime;}
	    //		set{_createDateTime = value;}
	    //	}
	    //
	    //	/// public propaty name  :  UpdateDateTime
	    //	/// <summary>�X�V�����v���p�e�B</summary>
	    //	/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   �X�V�����v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public DateTime UpdateDateTime
	    //	{
	    //		get{return _updateDateTime;}
	    //		set{_updateDateTime = value;}
	    //	}
	    //
	    //	/// public propaty name  :  EnterpriseCode
	    //	/// <summary>��ƃR�[�h�v���p�e�B</summary>
	    //	/// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public string EnterpriseCode
	    //	{
	    //		get{return _enterpriseCode;}
	    //		set{_enterpriseCode = value;}
	    //	}
	    //
	    //	/// public propaty name  :  FileHeaderGuid
	    //	/// <summary>GUID�v���p�e�B</summary>
	    //	/// <value>���ʃt�@�C���w�b�_</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   GUID�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Guid FileHeaderGuid
	    //	{
	    //		get{return _fileHeaderGuid;}
	    //		set{_fileHeaderGuid = value;}
	    //	}
	    //
	    //	/// public propaty name  :  UpdEmployeeCode
	    //	/// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
	    //	/// <value>���ʃt�@�C���w�b�_</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public string UpdEmployeeCode
	    //	{
	    //		get{return _updEmployeeCode;}
	    //		set{_updEmployeeCode = value;}
	    //	}
	    //
	    //	/// public propaty name  :  UpdAssemblyId1
	    //	/// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
	    //	/// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public string UpdAssemblyId1
	    //	{
	    //		get{return _updAssemblyId1;}
	    //		set{_updAssemblyId1 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  UpdAssemblyId2
	    //	/// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
	    //	/// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public string UpdAssemblyId2
	    //	{
	    //		get{return _updAssemblyId2;}
	    //		set{_updAssemblyId2 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  LogicalDeleteCode
	    //	/// <summary>�_���폜�敪�v���p�e�B</summary>
	    //	/// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   �_���폜�敪�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Int32 LogicalDeleteCode
	    //	{
	    //		get{return _logicalDeleteCode;}
	    //		set{_logicalDeleteCode = value;}
	    //	}
	    //
	    //	/// public propaty name  :  AcceptAnOrderNo
	    //	/// <summary>�󒍔ԍ��v���p�e�B</summary>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   �󒍔ԍ��v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Int32 AcceptAnOrderNo
	    //	{
	    //		get{return _acceptAnOrderNo;}
	    //		set{_acceptAnOrderNo = value;}
	    //	}
	    //
	    //	/// public propaty name  :  DepositAllowanceTtl
	    //	/// <summary>�����������v�z�v���p�e�B</summary>
	    //	/// <value>�a����������v�z���܂�</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   �����������v�z�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Int64 DepositAllowanceTtl
	    //	{
	    //		get{return _depositAllowanceTtl;}
	    //		set{_depositAllowanceTtl = value;}
	    //	}
	    //
	    //	/// public propaty name  :  MnyDepoAllowanceTtl
	    //	/// <summary>�a����������v�z�v���p�e�B</summary>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   �a����������v�z�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Int64 MnyDepoAllowanceTtl
	    //	{
	    //		get{return _mnyDepoAllowanceTtl;}
	    //		set{_mnyDepoAllowanceTtl = value;}
	    //	}
	    //
	    //	/// public propaty name  :  DemandProRataCd
	    //	/// <summary>�������敪�v���p�e�B</summary>
	    //	/// <value>0:������,1:�������L��</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   �������敪�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Int32 DemandProRataCd
	    //	{
	    //		get{return _demandProRataCd;}
	    //		set{_demandProRataCd = value;}
	    //	}
	    //
	    //	/// public propaty name  :  Claim1Code
	    //	/// <summary>������@�R�[�h�v���p�e�B</summary>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   ������@�R�[�h�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Int32 Claim1Code
	    //	{
	    //		get{return _claim1Code;}
	    //		set{_claim1Code = value;}
	    //	}
	    //
	    //	/// public propaty name  :  Claim2Code
	    //	/// <summary>������A�R�[�h�v���p�e�B</summary>
	    //	/// <value>�iSF�͵�߼�݁j</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   ������A�R�[�h�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Int32 Claim2Code
	    //	{
	    //		get{return _claim2Code;}
	    //		set{_claim2Code = value;}
	    //	}
	    //
	    //	/// public propaty name  :  Claim3Code
	    //	/// <summary>������B�R�[�h�v���p�e�B</summary>
	    //	/// <value>�iSF�͵�߼�݁j</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   ������B�R�[�h�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Int32 Claim3Code
	    //	{
	    //		get{return _claim3Code;}
	    //		set{_claim3Code = value;}
	    //	}
	    //
	    //	/// public propaty name  :  Claim4Code
	    //	/// <summary>������C�R�[�h�v���p�e�B</summary>
	    //	/// <value>�iSF�͵�߼�݁j</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   ������C�R�[�h�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Int32 Claim4Code
	    //	{
	    //		get{return _claim4Code;}
	    //		set{_claim4Code = value;}
	    //	}
	    //
	    //	/// public propaty name  :  Claim5Code
	    //	/// <summary>������D�R�[�h�v���p�e�B</summary>
	    //	/// <value>�iSF�͵�߼�݁j</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   ������D�R�[�h�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Int32 Claim5Code
	    //	{
	    //		get{return _claim5Code;}
	    //		set{_claim5Code = value;}
	    //	}
	    //
	    //	/// public propaty name  :  DepositAllowance1
	    //	/// <summary>���������z1�v���p�e�B</summary>
	    //	/// <value>�a��������z1���܂�</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   ���������z1�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Int64 DepositAllowance1
	    //	{
	    //		get{return _depositAllowance1;}
	    //		set{_depositAllowance1 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  MnyOnDepoAllowance1
	    //	/// <summary>�a��������z1�v���p�e�B</summary>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   �a��������z1�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Int64 MnyOnDepoAllowance1
	    //	{
	    //		get{return _mnyOnDepoAllowance1;}
	    //		set{_mnyOnDepoAllowance1 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  DepositAllowance2
	    //	/// <summary>���������z2�v���p�e�B</summary>
	    //	/// <value>�a��������z2���܂�</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   ���������z2�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Int64 DepositAllowance2
	    //	{
	    //		get{return _depositAllowance2;}
	    //		set{_depositAllowance2 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  MnyOnDepoAllowance2
	    //	/// <summary>�a��������z2�v���p�e�B</summary>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   �a��������z2�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Int64 MnyOnDepoAllowance2
	    //	{
	    //		get{return _mnyOnDepoAllowance2;}
	    //		set{_mnyOnDepoAllowance2 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  DepositAllowance3
	    //	/// <summary>���������z3�v���p�e�B</summary>
	    //	/// <value>�a��������z3���܂�</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   ���������z3�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Int64 DepositAllowance3
	    //	{
	    //		get{return _depositAllowance3;}
	    //		set{_depositAllowance3 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  MnyOnDepoAllowance3
	    //	/// <summary>�a��������z3�v���p�e�B</summary>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   �a��������z3�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Int64 MnyOnDepoAllowance3
	    //	{
	    //		get{return _mnyOnDepoAllowance3;}
	    //		set{_mnyOnDepoAllowance3 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  DepositAllowance4
	    //	/// <summary>���������z4�v���p�e�B</summary>
	    //	/// <value>�a��������z4���܂�</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   ���������z4�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Int64 DepositAllowance4
	    //	{
	    //		get{return _depositAllowance4;}
	    //		set{_depositAllowance4 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  MnyOnDepoAllowance4
	    //	/// <summary>�a��������z4�v���p�e�B</summary>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   �a��������z4�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Int64 MnyOnDepoAllowance4
	    //	{
	    //		get{return _mnyOnDepoAllowance4;}
	    //		set{_mnyOnDepoAllowance4 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  DepositAllowance5
	    //	/// <summary>���������z5�v���p�e�B</summary>
	    //	/// <value>�a��������z5���܂�</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   ���������z5�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Int64 DepositAllowance5
	    //	{
	    //		get{return _depositAllowance5;}
	    //		set{_depositAllowance5 = value;}
	    //	}
	    //
	    //	/// public propaty name  :  MnyOnDepoAllowance5
	    //	/// <summary>�a��������z5�v���p�e�B</summary>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   �a��������z5�v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public Int64 MnyOnDepoAllowance5
	    //	{
	    //		get{return _mnyOnDepoAllowance5;}
	    //		set{_mnyOnDepoAllowance5 = value;}
	    //	}
	    //
	    //
	    //	/// public propaty name  :  ExclusiveDepoAlwDate
	    //	/// <summary>�r���p���������X�V���v���p�e�B</summary>
	    //	/// <value>DateTime:���x��100�i�m�b</value>
	    //	/// ----------------------------------------------------------------------
	    //	/// <remarks>
	    //	/// <br>note             :   �r���p���������X�V���v���p�e�B</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public DateTime ExclusiveDepoAlwDate
	    //	{
	    //		get{return _exclusiveDepoAlwDate;}
	    //		set{_exclusiveDepoAlwDate = value;}
	    //	}
	    //
	    //	/// <summary>
	    //	/// �����X�V�p�󒍃��[�N�R���X�g���N�^
	    //	/// </summary>
	    //	/// <returns>UpdAcceptOdrWork�N���X�̃C���X�^���X</returns>
	    //	/// <remarks>
	    //	/// <br>Note�@�@�@�@�@�@ :   UpdAcceptOdrWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
	    //	/// <br>Programer        :   ��������</br>
	    //	/// </remarks>
	    //	public UpdAcceptOdrWork()
	    //	{
	    //	}
	    //
        //}
        #endregion
        // �� 20070124 18322 c

# endif
        # endregion
    }

    #region MA.NS ���������X�V�p���ハ�[�N�N���X
    /// public class name:   UpdSalesForPayDrawWork
    /// <summary>
    ///                      ���������X�V�p����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���������X�V�p����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   �ؑ� ����</br>
    /// <br>Genarated Date   :   2007/02/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class UpdSalesForPayDrawWork : IFileHeader
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>����`�[���</summary>
        /// <remarks>10:����,20:����,21:���،v��,30:�ϑ�,31:�ϑ��v��,50:����,60:��,70:�\��</remarks>
        private Int32 _salesSlipKind;

        /// <summary>����`�[�ԍ�</summary>
        private string _saleSlipNum = "";

        /// <summary>����`�[�敪</summary>
        /// <remarks>0:����,1:�ԕi,2:�l��</remarks>
        private Int32 _salesSlipCd;

        /// <summary>�ԓ`�敪</summary>
        /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>�������v�z</summary>
        /// <remarks>�`�[�S�̂̐������v�i�N���W�b�g�萔���͊܂܂Ȃ��j</remarks>
        private Int64 _demandableTtl;

        /// <summary>�����������v�z</summary>
        /// <remarks>�a����������v�z���܂�</remarks>
        private Int64 _depositAllowanceTtl;

        /// <summary>�a����������v�z</summary>
        private Int64 _mnyDepoAllowanceTtl;

        /// <summary>���������c��</summary>
        private Int64 _depositAlwcBlnce;

        /// <summary>������R�[�h</summary>
        private Int32 _claimCode;


        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SalesSlipKind
        /// <summary>����`�[��ʃv���p�e�B</summary>
        /// <value>10:����,20:����,21:���،v��,30:�ϑ�,31:�ϑ��v��,50:����,60:��,70:�\��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipKind
        {
            get { return _salesSlipKind; }
            set { _salesSlipKind = value; }
        }

        /// public propaty name  :  SaleSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SaleSlipNum
        {
            get { return _saleSlipNum; }
            set { _saleSlipNum = value; }
        }

        /// public propaty name  :  SalesSlipCd
        /// <summary>����`�[�敪�v���p�e�B</summary>
        /// <value>0:����,1:�ԕi,2:�l��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }

        /// public propaty name  :  DebitNoteDiv
        /// <summary>�ԓ`�敪�v���p�e�B</summary>
        /// <value>0:���`,1:�ԓ`,2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԓ`�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  DemandableTtl
        /// <summary>�������v�z�v���p�e�B</summary>
        /// <value>�`�[�S�̂̐������v�i�N���W�b�g�萔���͊܂܂Ȃ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DemandableTtl
        {
            get { return _demandableTtl; }
            set { _demandableTtl = value; }
        }

        /// public propaty name  :  DepositAllowanceTtl
        /// <summary>�����������v�z�v���p�e�B</summary>
        /// <value>�a����������v�z���܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������v�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DepositAllowanceTtl
        {
            get { return _depositAllowanceTtl; }
            set { _depositAllowanceTtl = value; }
        }

        /// public propaty name  :  MnyDepoAllowanceTtl
        /// <summary>�a����������v�z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a����������v�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MnyDepoAllowanceTtl
        {
            get { return _mnyDepoAllowanceTtl; }
            set { _mnyDepoAllowanceTtl = value; }
        }

        /// public propaty name  :  DepositAlwcBlnce
        /// <summary>���������c���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DepositAlwcBlnce
        {
            get { return _depositAlwcBlnce; }
            set { _depositAlwcBlnce = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }


        /// <summary>
        /// ���������X�V�p����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>UpdSalesForPayDrawWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UpdSalesForPayDrawWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UpdSalesForPayDrawWork()
        {
        }

    }
    #endregion
}
