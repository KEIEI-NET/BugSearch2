//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE���ɍX�VDB�����[�g�I�u�W�F�N�g
//                  :   PMUOE01205R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112�@�v�ۓc
// Date             :   2008.10.17
//----------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22008 ����
// �� �� ��  2009/08/24  �C�����e : E-Parts�Ή��ɔ������o���\�b�h�ǉ�
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/11/15  �C�����e : 1��16���z�M���ARedmine#31980 PM.NS��Q�ꗗNo.829�̑Ή�
//                                : �݌ɓ��ɍX�V�̌��P���́A�񓚃f�[�^�̌��P����PM�̌��P���ƈقȂ�ꍇ���F�ɕς��@�\�����邪
//                                : ���i�}�X�^�̌�����ς��Ă��A�F�ʂ͕ω����Ȃ��B
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2013/01/18  �C�����e : 1��16���z�M���ARedmine#31980 PM.NS��Q�ꗗNo.829�̑Ή�
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00 �쐬�S�� : 杍^
// �C �� ��  2020/06/17  �C�����e : PMKOBETSU-4005 �d�a�d�΍�
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common; // ADD 2020/06/18 杍^ PMKOBETSU-4005

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// UOE���ɍX�VDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE���ɍX�V�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc</br>
    /// <br>Date       : 2008.10.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>Update Note: 2012/11/15 wangf </br>
    /// <br>           : 10801804-00�A1��16���z�M���A10801804-00�ARedmine#31980 PM.NS��Q�ꗗNo.829�̑Ή�</br>
    /// <br>           : �݌ɓ��ɍX�V�̌��P���́A�񓚃f�[�^�̌��P����PM�̌��P���ƈقȂ�ꍇ���F�ɕς��@�\�����邪</br>
    /// <br>           : ���i�}�X�^�̌�����ς��Ă��A�F�ʂ͕ω����Ȃ��B</br>
	/// <br>Update Note: 2013/01/18 wangf </br>
	/// <br>           : 10801804-00�A1��16���z�M���ARedmine#31980 PM.NS��Q�ꗗNo.829�̑Ή�</br>
    /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2020/06/18</br>
    /// </remarks>
    [Serializable]
    public class UOEStockUpdateDB : RemoteWithAppLockDB, IUOEStockUpdateDB
    {
        # region [�g�p���郊���[�g]

        # region [����E�d�����䃊���[�g]
        private IOWriteControlDB _ioWriteCtrDb = null;

        private IOWriteControlDB ioWriteCtrDb
        {
            get
            {
                if (this._ioWriteCtrDb == null)
                {
                    this._ioWriteCtrDb = new IOWriteControlDB();
                }

                return this._ioWriteCtrDb;
            }
        }
        # endregion

        # region [�݌ɒ����f�[�^�����[�g]
        private StockAdjustDB _stcAdjustDb = null;

        private StockAdjustDB stcAdjustDb
        {
            get
            {
                if (this._stcAdjustDb == null)
                {
                    this._stcAdjustDb = new StockAdjustDB();
                }

                return this._stcAdjustDb;
            }
        }
        # endregion

        # endregion

        /// <summary>
        /// UOE���ɍX�VDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        /// </remarks>
        public UOEStockUpdateDB() : base("PMUOE01207D", "Broadleaf.Application.Remoting.ParamData.UOEStockUpdateWork", "UOESTOCKUPDATERF")
        {

        }

        # region [Search]

        /// <summary>
        /// �d���`�[�f�[�^ �L�[����
        /// </summary>
        private struct StockSlipKey
        {
            public string EnterpriseCode;
            public int SupplierFormal;
            public int SupplierSlipNo;

            public StockSlipKey(string enterprisecode, int supplierformal, int supplierslipno)
            {
                EnterpriseCode = enterprisecode;
                SupplierFormal = supplierformal;
                SupplierSlipNo = supplierslipno;
            }
        }

        /// <summary>
        /// UOE���ɍX�V���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeStcUpdSearchObj">���������ƂȂ� UOEStockUpdSearchWork ���w�肵�܂��B</param>
        /// <param name="uoeStcUpdDataList">�������ʂ��i�[ CustomSerializeArrayList ���w�肵�܂��B</param>
        /// <param name="readMode">�����敪(���g�p)</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���������ɍ��v����UOE�����f�[�^�A�d���f�[�^�A�d�����׃f�[�^���������܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        public int Search(object uoeStcUpdSearchObj, ref object uoeStcUpdDataList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                # region [�p�����[�^�`�F�b�N]

                UOEStockUpdSearchWork uoeStcUpdSearch = uoeStcUpdSearchObj as UOEStockUpdSearchWork;

                if (uoeStcUpdSearch == null)
                {
                    errmsg += ": uoeStcUpdSearchObj ���������ݒ肳��Ă��܂���";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                ArrayList uoeStcUpdDataArray = uoeStcUpdDataList as ArrayList;

                if (uoeStcUpdDataArray == null)
                {
                    errmsg += ": uoeStcUpdDataList ���������ݒ肳��Ă��܂���";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # endregion

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(uoeStcUpdSearch, ref uoeStcUpdDataArray, readMode, logicalMode, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// UOE���ɍX�V���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeStcUpdSearch">���������ƂȂ� UOEStockUpdSearchWork ���w�肵�܂��B</param>
        /// <param name="uoeStcUpdDataList">�������ʂ��i�[ CustomSerializeArrayList ���w�肵�܂��B</param>
        /// <param name="readMode">�����敪(���g�p)</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���������ɍ��v����UOE�����f�[�^�A�d���f�[�^�A�d�����׃f�[�^���������܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        public int Search(UOEStockUpdSearchWork uoeStcUpdSearch, ref ArrayList uoeStcUpdDataList, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                # region [�p�����[�^�`�F�b�N]

                string orgErrmsg = errmsg;

                if (uoeStcUpdSearch == null)
                    errmsg += ": uoeStcUpdSearch ���������ݒ肳��Ă��܂���";

                if (uoeStcUpdDataList == null)
                    errmsg += ": uoeStcUpdDataList ���������ݒ肳��Ă��܂���";

                if (sqlConnection == null)
                    errmsg += ": sqlConnection ���������ݒ肳��Ă��܂���";

                if (orgErrmsg != errmsg)
                {
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # endregion

                status = this.SearchProc(uoeStcUpdSearch, ref uoeStcUpdDataList, readMode, logicalMode, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        /// <summary>
        /// UOE���ɍX�V���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeStcUpdSearch">UOE���ɍX�V�����i�[���� ArrayList</param>
        /// <param name="uoeStcUpdDataList">��������</param>
        /// <param name="readMode">�����敪(���g�p)</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE���ɍX�V�̃L�[�l����v����A�S�Ă�UOE���ɍX�V��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        /// <br>Update Note: 2012/11/15 wangf </br>
        /// <br>           : 10801804-00�A1��16���z�M���ARedmine#31980 PM.NS��Q�ꗗNo.829�̑Ή�</br>
        /// <br>           : �݌ɓ��ɍX�V�̌��P���́A�񓚃f�[�^�̌��P����PM�̌��P���ƈقȂ�ꍇ���F�ɕς��@�\�����邪</br>
        /// <br>           : ���i�}�X�^�̌�����ς��Ă��A�F�ʂ͕ω����Ȃ��B</br>
		/// <br>Update Note: 2013/01/18 wangf </br>
		/// <br>           : 10801804-00�A1��16���z�M���ARedmine#31980 PM.NS��Q�ꗗNo.829�̑Ή�</br>
        /// <br>Update Note: PMKOBETSU-4005 �d�a�d�΍�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/06/18</br>
        private int SearchProc(UOEStockUpdSearchWork uoeStcUpdSearch, ref ArrayList uoeStcUpdDataList, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList uoeOdrDtlList = new ArrayList();
            ArrayList stcSlpList = new ArrayList();
            ArrayList stcDtlList = new ArrayList();
            
            //List<StockSlipKey> stcSlpKeyList = new List<StockSlipKey>();
            Dictionary<string, StockSlipReadWork> slipReadDic = new Dictionary<string, StockSlipReadWork>(); //�d���f�[�^���o�p�����[�^
            Dictionary<string, Guid> dtlGuidDic = new Dictionary<string, Guid>();  //�֘A���׃t�@�C���f�t�h�c�i�[

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [UOE�����f�[�^]
                # region [SELECT��]
                sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                # region [UOE�����f�[�^]
                sqlText += "  UOEDTL.CREATEDATETIMERF AS UOE_CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UPDATEDATETIMERF AS UOE_UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ENTERPRISECODERF AS UOE_ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.FILEHEADERGUIDRF AS UOE_FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UPDEMPLOYEECODERF AS UOE_UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UPDASSEMBLYID1RF AS UOE_UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UPDASSEMBLYID2RF AS UOE_UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.LOGICALDELETECODERF AS UOE_LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SYSTEMDIVCDRF AS UOE_SYSTEMDIVCDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOESALESORDERNORF AS UOE_UOESALESORDERNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOESALESORDERROWNORF AS UOE_UOESALESORDERROWNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SENDTERMINALNORF AS UOE_SENDTERMINALNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOESUPPLIERCDRF AS UOE_UOESUPPLIERCDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOESUPPLIERNAMERF AS UOE_UOESUPPLIERNAMERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.COMMASSEMBLYIDRF AS UOE_COMMASSEMBLYIDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ONLINENORF AS UOE_ONLINENORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ONLINEROWNORF AS UOE_ONLINEROWNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SALESDATERF AS UOE_SALESDATERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.INPUTDAYRF AS UOE_INPUTDAYRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.DATAUPDATEDATETIMERF AS UOE_DATAUPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOEKINDRF AS UOE_UOEKINDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SALESSLIPNUMRF AS UOE_SALESSLIPNUMRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ACPTANODRSTATUSRF AS UOE_ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SALESSLIPDTLNUMRF AS UOE_SALESSLIPDTLNUMRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SECTIONCODERF AS UOE_SECTIONCODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SUBSECTIONCODERF AS UOE_SUBSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.CUSTOMERCODERF AS UOE_CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.CUSTOMERSNMRF AS UOE_CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.CASHREGISTERNORF AS UOE_CASHREGISTERNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.COMMONSEQNORF AS UOE_COMMONSEQNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SUPPLIERFORMALRF AS UOE_SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SUPPLIERSLIPNORF AS UOE_SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.STOCKSLIPDTLNUMRF AS UOE_STOCKSLIPDTLNUMRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOCODERF AS UOE_BOCODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOEDELIGOODSDIVRF AS UOE_UOEDELIGOODSDIVRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.DELIVEREDGOODSDIVNMRF AS UOE_DELIVEREDGOODSDIVNMRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.FOLLOWDELIGOODSDIVRF AS UOE_FOLLOWDELIGOODSDIVRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.FOLLOWDELIGOODSDIVNMRF AS UOE_FOLLOWDELIGOODSDIVNMRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOERESVDSECTIONRF AS UOE_UOERESVDSECTIONRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOERESVDSECTIONNMRF AS UOE_UOERESVDSECTIONNMRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.EMPLOYEECODERF AS UOE_EMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.EMPLOYEENAMERF AS UOE_EMPLOYEENAMERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.GOODSMAKERCDRF AS UOE_GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAKERNAMERF AS UOE_MAKERNAMERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.GOODSNORF AS UOE_GOODSNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.GOODSNONONEHYPHENRF AS UOE_GOODSNONONEHYPHENRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.GOODSNAMERF AS UOE_GOODSNAMERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.WAREHOUSECODERF AS UOE_WAREHOUSECODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.WAREHOUSENAMERF AS UOE_WAREHOUSENAMERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.WAREHOUSESHELFNORF AS UOE_WAREHOUSESHELFNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ACCEPTANORDERCNTRF AS UOE_ACCEPTANORDERCNTRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.LISTPRICERF AS UOE_LISTPRICERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SALESUNITCOSTRF AS UOE_SALESUNITCOSTRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SUPPLIERCDRF AS UOE_SUPPLIERCDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SUPPLIERSNMRF AS UOE_SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOEREMARK1RF AS UOE_UOEREMARK1RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOEREMARK2RF AS UOE_UOEREMARK2RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.RECEIVEDATERF AS UOE_RECEIVEDATERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.RECEIVETIMERF AS UOE_RECEIVETIMERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ANSWERMAKERCDRF AS UOE_ANSWERMAKERCDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ANSWERPARTSNORF AS UOE_ANSWERPARTSNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ANSWERPARTSNAMERF AS UOE_ANSWERPARTSNAMERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SUBSTPARTSNORF AS UOE_SUBSTPARTSNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOESECTOUTGOODSCNTRF AS UOE_UOESECTOUTGOODSCNTRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOSHIPMENTCNT1RF AS UOE_BOSHIPMENTCNT1RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOSHIPMENTCNT2RF AS UOE_BOSHIPMENTCNT2RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOSHIPMENTCNT3RF AS UOE_BOSHIPMENTCNT3RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAKERFOLLOWCNTRF AS UOE_MAKERFOLLOWCNTRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.NONSHIPMENTCNTRF AS UOE_NONSHIPMENTCNTRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOESECTSTOCKCNTRF AS UOE_UOESECTSTOCKCNTRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOSTOCKCOUNT1RF AS UOE_BOSTOCKCOUNT1RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOSTOCKCOUNT2RF AS UOE_BOSTOCKCOUNT2RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOSTOCKCOUNT3RF AS UOE_BOSTOCKCOUNT3RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOESECTIONSLIPNORF AS UOE_UOESECTIONSLIPNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOSLIPNO1RF AS UOE_BOSLIPNO1RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOSLIPNO2RF AS UOE_BOSLIPNO2RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOSLIPNO3RF AS UOE_BOSLIPNO3RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.EOALWCCOUNTRF AS UOE_EOALWCCOUNTRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOMANAGEMENTNORF AS UOE_BOMANAGEMENTNORF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ANSWERLISTPRICERF AS UOE_ANSWERLISTPRICERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ANSWERSALESUNITCOSTRF AS UOE_ANSWERSALESUNITCOSTRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOESUBSTMARKRF AS UOE_UOESUBSTMARKRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOESTOCKMARKRF AS UOE_UOESTOCKMARKRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.PARTSLAYERCDRF AS UOE_PARTSLAYERCDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESHIPSECTCD1RF AS UOE_MAZDAUOESHIPSECTCD1RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESHIPSECTCD2RF AS UOE_MAZDAUOESHIPSECTCD2RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESHIPSECTCD3RF AS UOE_MAZDAUOESHIPSECTCD3RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESECTCD1RF AS UOE_MAZDAUOESECTCD1RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESECTCD2RF AS UOE_MAZDAUOESECTCD2RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESECTCD3RF AS UOE_MAZDAUOESECTCD3RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESECTCD4RF AS UOE_MAZDAUOESECTCD4RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESECTCD5RF AS UOE_MAZDAUOESECTCD5RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESECTCD6RF AS UOE_MAZDAUOESECTCD6RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESECTCD7RF AS UOE_MAZDAUOESECTCD7RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT1RF AS UOE_MAZDAUOESTOCKCNT1RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT2RF AS UOE_MAZDAUOESTOCKCNT2RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT3RF AS UOE_MAZDAUOESTOCKCNT3RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT4RF AS UOE_MAZDAUOESTOCKCNT4RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT5RF AS UOE_MAZDAUOESTOCKCNT5RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT6RF AS UOE_MAZDAUOESTOCKCNT6RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT7RF AS UOE_MAZDAUOESTOCKCNT7RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOEDISTRIBUTIONCDRF AS UOE_UOEDISTRIBUTIONCDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOEOTHERCDRF AS UOE_UOEOTHERCDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOEHMCDRF AS UOE_UOEHMCDRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.BOCOUNTRF AS UOE_BOCOUNTRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOEMARKCODERF AS UOE_UOEMARKCODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.SOURCESHIPMENTRF AS UOE_SOURCESHIPMENTRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ITEMCODERF AS UOE_ITEMCODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.UOECHECKCODERF AS UOE_UOECHECKCODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.HEADERRORMASSAGERF AS UOE_HEADERRORMASSAGERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.LINEERRORMASSAGERF AS UOE_LINEERRORMASSAGERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.DATASENDCODERF AS UOE_DATASENDCODERF" + Environment.NewLine;
                sqlText += " ,UOEDTL.DATARECOVERDIVRF AS UOE_DATARECOVERDIVRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ENTERUPDDIVSECRF AS UOE_ENTERUPDDIVSECRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ENTERUPDDIVBO1RF AS UOE_ENTERUPDDIVBO1RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ENTERUPDDIVBO2RF AS UOE_ENTERUPDDIVBO2RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ENTERUPDDIVBO3RF AS UOE_ENTERUPDDIVBO3RF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ENTERUPDDIVMAKERRF AS UOE_ENTERUPDDIVMAKERRF" + Environment.NewLine;
                sqlText += " ,UOEDTL.ENTERUPDDIVEORF AS UOE_ENTERUPDDIVEORF" + Environment.NewLine;
                // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
                sqlText += " ,UNION_GOODSPRICEURF.GOODSPRICEU_SALESUNITCOSTRF AS UOE_GOODSPRICEU_SALESUNITCOSTRF" + Environment.NewLine;
                sqlText += " ,UNION_GOODSPRICEURF.GOODSPRICEU_PRICESTARTDATERF AS UOE_GOODSPRICEU_PRICESTARTDATERF" + Environment.NewLine;
                sqlText += " ,UNION_GOODSPRICEURF.GOODSPRICEU_STOCKRATERF AS UOE_GOODSPRICEU_STOCKRATERF" + Environment.NewLine;
                sqlText += " ,UNION_GOODSPRICEURF.GOODSPRICEU_LISTPRICERF AS UOE_GOODSPRICEU_LISTPRICERF" + Environment.NewLine;

                sqlText += "  ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
                sqlText += "  ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                sqlText += "  ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
                // ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<
                # endregion
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  UOEORDERDTLRF AS UOEDTL" + Environment.NewLine;
                // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
                #region ���i�}�X�^�֘A
                sqlText += "LEFT JOIN (" + Environment.NewLine;
                sqlText += "  SELECT" + Environment.NewLine;
                sqlText += "      MAX_GOODSPRICEURF.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "      ,MAX_GOODSPRICEURF.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "      ,MAX_GOODSPRICEURF.GOODSNORF" + Environment.NewLine;
                sqlText += "      ,MAX_GOODSPRICEURF.SALESUNITCOSTRF  AS GOODSPRICEU_SALESUNITCOSTRF" + Environment.NewLine;
                sqlText += "      ,MAX_GOODSPRICEURF.PRICESTARTDATERF AS GOODSPRICEU_PRICESTARTDATERF" + Environment.NewLine;
                sqlText += "      ,MAX_GOODSPRICEURF.STOCKRATERF AS GOODSPRICEU_STOCKRATERF" + Environment.NewLine;
                sqlText += "      ,MAX_GOODSPRICEURF.LISTPRICERF AS GOODSPRICEU_LISTPRICERF" + Environment.NewLine;
                sqlText += "  FROM GOODSPRICEURF AS MAX_GOODSPRICEURF" + Environment.NewLine;
                sqlText += "  WHERE MAX_GOODSPRICEURF.PRICESTARTDATERF IN (" + Environment.NewLine;
                sqlText += "      SELECT TOP 1 PRICESTARTDATERF AS MAX_PRICESTARTDATERF " + Environment.NewLine;
                sqlText += "      FROM GOODSPRICEURF" + Environment.NewLine;
                sqlText += "      WHERE PRICESTARTDATERF <= @PRICESTARTDATERF" + Environment.NewLine;
                sqlText += "      AND LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "      AND MAX_GOODSPRICEURF.GOODSMAKERCDRF = GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "      AND MAX_GOODSPRICEURF.GOODSNORF = GOODSNORF" + Environment.NewLine;
                sqlText += "      ORDER BY PRICESTARTDATERF DESC)" + Environment.NewLine;
                sqlText += "      AND MAX_GOODSPRICEURF.ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                sqlText += "      AND MAX_GOODSPRICEURF.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += "  ) AS UNION_GOODSPRICEURF" + Environment.NewLine;
                sqlText += "ON UOEDTL.ENTERPRISECODERF = UNION_GOODSPRICEURF.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "AND UOEDTL.GOODSMAKERCDRF = UNION_GOODSPRICEURF.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "AND UOEDTL.GOODSNORF = UNION_GOODSPRICEURF.GOODSNORF" + Environment.NewLine;

                SqlParameter findPriceStartDate = sqlCommand.Parameters.Add("@PRICESTARTDATERF", SqlDbType.Int);
                findPriceStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(DateTime.Now);
                #endregion

                #region ���i�}�X�^�֘A
                sqlText += " LEFT JOIN GOODSURF AS GOODS" + Environment.NewLine;
                sqlText += " ON UOEDTL.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND UOEDTL.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND UOEDTL.GOODSNORF=GOODS.GOODSNORF" + Environment.NewLine;
                sqlText += " AND UOEDTL.LOGICALDELETECODERF=GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                #endregion

                // ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<
                # region [WHERE��]
                sqlText += "WHERE" + Environment.NewLine;

                // ��ƃR�[�h
                sqlText += "  UOEDTL.ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeStcUpdSearch.EnterpriseCode);

                // �����敪
                if (uoeStcUpdSearch.ProcDiv == 0)
                {
                    // �݌Ɉꊇ
                    sqlText += "  AND UOEDTL.SYSTEMDIVCDRF = 3" + Environment.NewLine;
                }
                else
                {
                    // �݌Ɉꊇ�ȊO(����́E����)
                    // 2009/02/20 MANTIS 11720>>>>>>>>>>>>>>>>>>>>>>>>
                    // �����͓`���̃f�[�^����M����̂ŁA1:�`�������o�ΏۂƂ���B
                    //sqlText += "  AND UOEDTL.SYSTEMDIVCDRF IN (0, 2)" + Environment.NewLine;
                    sqlText += "  AND UOEDTL.SYSTEMDIVCDRF IN (0, 1, 2)" + Environment.NewLine;
                    // 2009/02/20 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }

                // ���_�R�[�h
                sqlText += "  AND UOEDTL.SECTIONCODERF = @SECTIONCODE" + Environment.NewLine;
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                findSectionCode.Value = SqlDataMediator.SqlSetString(uoeStcUpdSearch.SectionCode);

                if (string.IsNullOrEmpty(uoeStcUpdSearch.SlipNo))
                {
                    // UOE������R�[�h�ōi�荞��
                    sqlText += "  AND UOEDTL.UOESUPPLIERCDRF = @UOESUPPLIERCD" + Environment.NewLine;

                    SqlParameter findUOESupplierCd = sqlCommand.Parameters.Add("@UOESUPPLIERCD", SqlDbType.Int);
                    findUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeStcUpdSearch.UOESupplierCd);
                }
                else
                {
                    // �[�i���ԍ��ōi�荞��
                    sqlText += "  AND (UOEDTL.UOESECTIONSLIPNORF = @SLIPNO OR" + Environment.NewLine;
                    sqlText += "       UOEDTL.BOSLIPNO1RF = @SLIPNO OR" + Environment.NewLine;
                    sqlText += "       UOEDTL.BOSLIPNO2RF = @SLIPNO OR" + Environment.NewLine;
                    sqlText += "       UOEDTL.BOSLIPNO3RF = @SLIPNO)" + Environment.NewLine;

                    SqlParameter findSlipNo = sqlCommand.Parameters.Add("@SLIPNO", SqlDbType.NChar);
                    findSlipNo.Value = SqlDataMediator.SqlSetString(uoeStcUpdSearch.SlipNo);
                }
                sqlText += "  AND UOEDTL.DATASENDCODERF = 9" + Environment.NewLine;
                sqlText += "  AND UOEDTL.DATARECOVERDIVRF = 9" + Environment.NewLine;
                sqlText += "  AND (UOEDTL.ENTERUPDDIVSECRF = 0 OR" + Environment.NewLine;
                sqlText += "       UOEDTL.ENTERUPDDIVBO1RF = 0 OR" + Environment.NewLine;
                sqlText += "       UOEDTL.ENTERUPDDIVBO2RF = 0 OR" + Environment.NewLine;
                sqlText += "       UOEDTL.ENTERUPDDIVBO3RF = 0 OR" + Environment.NewLine;
                sqlText += "       UOEDTL.ENTERUPDDIVMAKERRF = 0 OR" + Environment.NewLine;
                sqlText += "       UOEDTL.ENTERUPDDIVEORF = 0)" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;

                // �_���폜�敪
                string wkstring = "";
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
                }

                if (wkstring != "")
                {
                    sqlText += wkstring;
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                # endregion
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif
                //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
                // �ϊ����Ăяo��
                ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

                // �ϊ���񏉊���
                convertDoubleRelease.ReleaseInitLib();
                //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
                try
                {
                    myReader = sqlCommand.ExecuteReader();



                    while (myReader.Read())
                    {
                        // ���׊֘A�t��GUID���쐬
                        Guid newDtlRelationGuid = Guid.NewGuid();

                        // UOE�����f�[�^�̎擾
                        UOEOrderDtlWork uoeOdrDtlWrk = new UOEOrderDtlWork();
                        this.CopyToUOEOrderDtlWorkFromReader(ref myReader, ref uoeOdrDtlWrk);
                        // ------------ADD wangf 2013/01/18 FOR Redmine#31980--------->>>>
                        // �����P���i���i�}�X�^���j
                        uoeOdrDtlWrk.GoodspriceuSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UOE_GOODSPRICEU_SALESUNITCOSTRF"));
                        uoeOdrDtlWrk.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOE_GOODSPRICEU_PRICESTARTDATERF"));
                        uoeOdrDtlWrk.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UOE_GOODSPRICEU_STOCKRATERF"));
                        //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
                        //uoeOdrDtlWrk.PriceListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UOE_GOODSPRICEU_LISTPRICERF"));
                        convertDoubleRelease.EnterpriseCode = uoeOdrDtlWrk.EnterpriseCode;
                        convertDoubleRelease.GoodsMakerCd = uoeOdrDtlWrk.GoodsMakerCd;
                        convertDoubleRelease.GoodsNo = uoeOdrDtlWrk.GoodsNo;
                        convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UOE_GOODSPRICEU_LISTPRICERF"));

                        // �ϊ��������s
                        convertDoubleRelease.ReleaseProc();

                        uoeOdrDtlWrk.PriceListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
                        //----- UPD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
                        uoeOdrDtlWrk.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));            // ���i�|�������N
                        uoeOdrDtlWrk.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));         // BL���i�R�[�h
                        uoeOdrDtlWrk.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));         // �ېŋ敪
                        // ------------ADD wangf 2013/01/18 FOR Redmine#31980---------<<<<
                        uoeOdrDtlWrk.DtlRelationGuid = newDtlRelationGuid;
                        uoeOdrDtlList.Add(uoeOdrDtlWrk);

                        // �d���f�[�^���o���X�g�쐬
                        if (!slipReadDic.ContainsKey(CreateKeySlipDic(uoeOdrDtlWrk)))
                        {
                            slipReadDic.Add(CreateKeySlipDic(uoeOdrDtlWrk),CopyToStockSlipReadFromUoeOrderDtl(uoeOdrDtlWrk));
                        }

                        //���׊֘A�f�t�h�c�i�[���X�g
                        if (!dtlGuidDic.ContainsKey(CreateKeyGuidDic(uoeOdrDtlWrk.EnterpriseCode,uoeOdrDtlWrk.SupplierFormal,uoeOdrDtlWrk.StockSlipDtlNum)))
                        {
                            dtlGuidDic.Add(CreateKeyGuidDic(uoeOdrDtlWrk.EnterpriseCode, uoeOdrDtlWrk.SupplierFormal, uoeOdrDtlWrk.StockSlipDtlNum), uoeOdrDtlWrk.DtlRelationGuid);
                        }

                    }
                }
                finally
                {
                    if (myReader != null && !myReader.IsClosed)
                    {
                        myReader.Close();
                        myReader.Dispose();
                    }
                    //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ---------->>>>>
                    // ���
                    convertDoubleRelease.Dispose();
                    //----- ADD 2020/06/18 杍^ PMKOBETSU-4005 ----------<<<<<
                }

                // �d���f�[�^�̓Ǎ���

                if (slipReadDic.Count > 0)
                {
                    StockSlipDB stockSlipDB = new StockSlipDB();

                    foreach (StockSlipReadWork StcSlipKey in slipReadDic.Values)
                    {
                        // �d���f�[�^�̃L�[���ڂɖ��ݒ�̍��ڂ��P�ł��L��΁A���Ӗ��Ȍ������s��Ȃ�
                        if (string.IsNullOrEmpty(StcSlipKey.EnterpriseCode) ||
                            StcSlipKey.SupplierFormal == 0 ||
                            StcSlipKey.SupplierSlipNo == 0)
                            continue;

                        CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                        CustomSerializeArrayList retList = new CustomSerializeArrayList();
                        
                        paraList.Add(StcSlipKey);

                        stockSlipDB.Read(ref paraList, ref retList, 0 ,ref sqlConnection, ref sqlTransaction);

                        //�d���f�[�^�Z�b�g
                        StockSlipWork stockSlipWork = ListUtils.Find(retList,typeof(StockSlipWork),ListUtils.FindType.Class) as StockSlipWork;
                        stcSlpList.Add(stockSlipWork);

                        //�d�����׃f�[�^�Z�b�g
                        ArrayList stockDetailList = ListUtils.Find(retList, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                        foreach (StockDetailWork stockDetailWork in stockDetailList)
                        {
                            if (dtlGuidDic.ContainsKey(CreateKeyGuidDic(stockDetailWork.EnterpriseCode, stockDetailWork.SupplierFormal, stockDetailWork.StockSlipDtlNum)))
                            {
                                //�t�n�d�����f�[�^�̖��׊֘A�f�t�h�c���d�����׃f�[�^�ɃZ�b�g
                                stockDetailWork.DtlRelationGuid = (Guid)(dtlGuidDic[CreateKeyGuidDic(stockDetailWork.EnterpriseCode, stockDetailWork.SupplierFormal, stockDetailWork.StockSlipDtlNum)]);
                            }
                        }

                        stcDtlList.AddRange(stockDetailList);

                    }
                }
                # endregion


                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                if (ListUtils.IsEmpty(uoeOdrDtlList))
                {
# if DEBUG
                    errmsg += ": �Y������UOE�����f�[�^���L��܂���.";
                    this.WriteErrorLog(errmsg, status);
# endif
                }
                else if (ListUtils.IsEmpty(stcSlpList))
                {
# if DEBUG
                    errmsg += ": �Y������d���f�[�^���L��܂���.";
                    this.WriteErrorLog(errmsg, status);
# endif
                }
                else if (ListUtils.IsEmpty(stcDtlList))
                {
# if DEBUG
                    errmsg += ": �Y������d�����׃f�[�^���L��܂���.";
                    this.WriteErrorLog(errmsg, status);
# endif
                }
                else
                {
                    uoeStcUpdDataList.Add(uoeOdrDtlList);
                    uoeStcUpdDataList.Add(stcSlpList);
                    uoeStcUpdDataList.Add(stcDtlList);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = this.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                this.WriteErrorLog(ex, errmsg, status);
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

        private string CreateKeySlipDic(UOEOrderDtlWork work)
        {
            return work.EnterpriseCode + "-" + work.SupplierFormal.ToString() + "-" + work.SupplierSlipNo.ToString();
        }

        private string CreateKeyGuidDic(string enterpriseCode, Int32 supplierFormal, Int64 stockSlipDtlNum)
        {
            return enterpriseCode + "-" + supplierFormal.ToString() + "-" + stockSlipDtlNum.ToString();
        }

        private StockSlipReadWork CopyToStockSlipReadFromUoeOrderDtl(UOEOrderDtlWork uoeOrderDtlWork)
        {
            StockSlipReadWork work = new StockSlipReadWork();
            work.EnterpriseCode = uoeOrderDtlWork.EnterpriseCode;
            work.SupplierFormal = uoeOrderDtlWork.SupplierFormal;
            work.SupplierSlipNo = uoeOrderDtlWork.SupplierSlipNo;

            return work;
        }

        # endregion

        #region[SearchAllPartySlip]
        // -- ADD 2009/08/24 --------------------------------------------------------->>>>>

        /// <summary>
        /// UOE���ɍX�V���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeStcUpdSearchObj">���������ƂȂ� UOEStockUpdSearchWork ���w�肵�܂��B</param>
        /// <param name="uoeStcUpdDataList">�������ʂ��i�[ CustomSerializeArrayList ���w�肵�܂��B</param>
        /// <param name="readMode">�����敪(���g�p)</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���������ɍ��v����UOE�����f�[�^�A�d���f�[�^�A�d�����׃f�[�^���������܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        public int SearchAllPartySlip(object uoeStcUpdSearchObj, ref object uoeStcUpdDataList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                # region [�p�����[�^�`�F�b�N]

                ArrayList uoeStcUpdSearchList = uoeStcUpdSearchObj as ArrayList;
                
                if (uoeStcUpdSearchList == null)
                {
                    errmsg += ": uoeStcUpdSearchObj ���������ݒ肳��Ă��܂���";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                ArrayList uoeStcUpdDataArray = uoeStcUpdDataList as ArrayList;

                if (uoeStcUpdDataArray == null)
                {
                    errmsg += ": uoeStcUpdDataList ���������ݒ肳��Ă��܂���";
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # endregion

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.SearchAllPartySlip(uoeStcUpdSearchList, ref uoeStcUpdDataArray, readMode, logicalMode, sqlConnection, sqlTransaction);

                uoeStcUpdDataList  = uoeStcUpdDataArray;

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// UOE���ɍX�V���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeStcUpdSearchList">���������ƂȂ� UOEStockUpdSearchWork��ArrayList ���w�肵�܂��B</param>
        /// <param name="uoeStcUpdDataList">�������ʂ��i�[ CustomSerializeArrayList ���w�肵�܂��B</param>
        /// <param name="readMode">�����敪(���g�p)</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���������ɍ��v����UOE�����f�[�^�A�d���f�[�^�A�d�����׃f�[�^���������܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        public int SearchAllPartySlip(ArrayList uoeStcUpdSearchList, ref ArrayList uoeStcUpdDataList, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            try
            {
                # region [�p�����[�^�`�F�b�N]

                string orgErrmsg = errmsg;

                if (uoeStcUpdSearchList == null)
                    errmsg += ": uoeStcUpdSearch ���������ݒ肳��Ă��܂���";

                if (uoeStcUpdDataList == null)
                    errmsg += ": uoeStcUpdDataList ���������ݒ肳��Ă��܂���";

                if (sqlConnection == null)
                    errmsg += ": sqlConnection ���������ݒ肳��Ă��܂���";

                if (orgErrmsg != errmsg)
                {
                    base.WriteErrorLog(errmsg, status);
                    return status;
                }

                # endregion

                status = this.SearchAllPartySlipProc(uoeStcUpdSearchList, ref uoeStcUpdDataList, readMode, logicalMode, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        /// <summary>
        /// UOE���ɍX�V���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeStcUpdSearchList">�������� ArrayList</param>
        /// <param name="uoeStcUpdDataList">���o���� ArrayList</param>
        /// <param name="readMode">�����敪(���g�p)</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE���ɍX�V�̃L�[�l����v����A�S�Ă�UOE���ɍX�V��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        private int SearchAllPartySlipProc(ArrayList uoeStcUpdSearchList, ref ArrayList uoeStcUpdDataList, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList uoeOdrDtlList = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                foreach (UOEStockUpdSearchWork uoeStcUpdSearch in uoeStcUpdSearchList)
                {
                    sqlCommand.Parameters.Clear();

                    # region [UOE�����f�[�^]
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  UOEDTL.CREATEDATETIMERF AS UOE_CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UPDATEDATETIMERF AS UOE_UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ENTERPRISECODERF AS UOE_ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.FILEHEADERGUIDRF AS UOE_FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UPDEMPLOYEECODERF AS UOE_UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UPDASSEMBLYID1RF AS UOE_UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UPDASSEMBLYID2RF AS UOE_UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.LOGICALDELETECODERF AS UOE_LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SYSTEMDIVCDRF AS UOE_SYSTEMDIVCDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOESALESORDERNORF AS UOE_UOESALESORDERNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOESALESORDERROWNORF AS UOE_UOESALESORDERROWNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SENDTERMINALNORF AS UOE_SENDTERMINALNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOESUPPLIERCDRF AS UOE_UOESUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOESUPPLIERNAMERF AS UOE_UOESUPPLIERNAMERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.COMMASSEMBLYIDRF AS UOE_COMMASSEMBLYIDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ONLINENORF AS UOE_ONLINENORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ONLINEROWNORF AS UOE_ONLINEROWNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SALESDATERF AS UOE_SALESDATERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.INPUTDAYRF AS UOE_INPUTDAYRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.DATAUPDATEDATETIMERF AS UOE_DATAUPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOEKINDRF AS UOE_UOEKINDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SALESSLIPNUMRF AS UOE_SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ACPTANODRSTATUSRF AS UOE_ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SALESSLIPDTLNUMRF AS UOE_SALESSLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SECTIONCODERF AS UOE_SECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SUBSECTIONCODERF AS UOE_SUBSECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.CUSTOMERCODERF AS UOE_CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.CUSTOMERSNMRF AS UOE_CUSTOMERSNMRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.CASHREGISTERNORF AS UOE_CASHREGISTERNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.COMMONSEQNORF AS UOE_COMMONSEQNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SUPPLIERFORMALRF AS UOE_SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SUPPLIERSLIPNORF AS UOE_SUPPLIERSLIPNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.STOCKSLIPDTLNUMRF AS UOE_STOCKSLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOCODERF AS UOE_BOCODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOEDELIGOODSDIVRF AS UOE_UOEDELIGOODSDIVRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.DELIVEREDGOODSDIVNMRF AS UOE_DELIVEREDGOODSDIVNMRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.FOLLOWDELIGOODSDIVRF AS UOE_FOLLOWDELIGOODSDIVRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.FOLLOWDELIGOODSDIVNMRF AS UOE_FOLLOWDELIGOODSDIVNMRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOERESVDSECTIONRF AS UOE_UOERESVDSECTIONRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOERESVDSECTIONNMRF AS UOE_UOERESVDSECTIONNMRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.EMPLOYEECODERF AS UOE_EMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.EMPLOYEENAMERF AS UOE_EMPLOYEENAMERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.GOODSMAKERCDRF AS UOE_GOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAKERNAMERF AS UOE_MAKERNAMERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.GOODSNORF AS UOE_GOODSNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.GOODSNONONEHYPHENRF AS UOE_GOODSNONONEHYPHENRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.GOODSNAMERF AS UOE_GOODSNAMERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.WAREHOUSECODERF AS UOE_WAREHOUSECODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.WAREHOUSENAMERF AS UOE_WAREHOUSENAMERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.WAREHOUSESHELFNORF AS UOE_WAREHOUSESHELFNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ACCEPTANORDERCNTRF AS UOE_ACCEPTANORDERCNTRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.LISTPRICERF AS UOE_LISTPRICERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SALESUNITCOSTRF AS UOE_SALESUNITCOSTRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SUPPLIERCDRF AS UOE_SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SUPPLIERSNMRF AS UOE_SUPPLIERSNMRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOEREMARK1RF AS UOE_UOEREMARK1RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOEREMARK2RF AS UOE_UOEREMARK2RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.RECEIVEDATERF AS UOE_RECEIVEDATERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.RECEIVETIMERF AS UOE_RECEIVETIMERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ANSWERMAKERCDRF AS UOE_ANSWERMAKERCDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ANSWERPARTSNORF AS UOE_ANSWERPARTSNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ANSWERPARTSNAMERF AS UOE_ANSWERPARTSNAMERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SUBSTPARTSNORF AS UOE_SUBSTPARTSNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOESECTOUTGOODSCNTRF AS UOE_UOESECTOUTGOODSCNTRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOSHIPMENTCNT1RF AS UOE_BOSHIPMENTCNT1RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOSHIPMENTCNT2RF AS UOE_BOSHIPMENTCNT2RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOSHIPMENTCNT3RF AS UOE_BOSHIPMENTCNT3RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAKERFOLLOWCNTRF AS UOE_MAKERFOLLOWCNTRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.NONSHIPMENTCNTRF AS UOE_NONSHIPMENTCNTRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOESECTSTOCKCNTRF AS UOE_UOESECTSTOCKCNTRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOSTOCKCOUNT1RF AS UOE_BOSTOCKCOUNT1RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOSTOCKCOUNT2RF AS UOE_BOSTOCKCOUNT2RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOSTOCKCOUNT3RF AS UOE_BOSTOCKCOUNT3RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOESECTIONSLIPNORF AS UOE_UOESECTIONSLIPNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOSLIPNO1RF AS UOE_BOSLIPNO1RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOSLIPNO2RF AS UOE_BOSLIPNO2RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOSLIPNO3RF AS UOE_BOSLIPNO3RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.EOALWCCOUNTRF AS UOE_EOALWCCOUNTRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOMANAGEMENTNORF AS UOE_BOMANAGEMENTNORF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ANSWERLISTPRICERF AS UOE_ANSWERLISTPRICERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ANSWERSALESUNITCOSTRF AS UOE_ANSWERSALESUNITCOSTRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOESUBSTMARKRF AS UOE_UOESUBSTMARKRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOESTOCKMARKRF AS UOE_UOESTOCKMARKRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.PARTSLAYERCDRF AS UOE_PARTSLAYERCDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESHIPSECTCD1RF AS UOE_MAZDAUOESHIPSECTCD1RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESHIPSECTCD2RF AS UOE_MAZDAUOESHIPSECTCD2RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESHIPSECTCD3RF AS UOE_MAZDAUOESHIPSECTCD3RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESECTCD1RF AS UOE_MAZDAUOESECTCD1RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESECTCD2RF AS UOE_MAZDAUOESECTCD2RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESECTCD3RF AS UOE_MAZDAUOESECTCD3RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESECTCD4RF AS UOE_MAZDAUOESECTCD4RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESECTCD5RF AS UOE_MAZDAUOESECTCD5RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESECTCD6RF AS UOE_MAZDAUOESECTCD6RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESECTCD7RF AS UOE_MAZDAUOESECTCD7RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT1RF AS UOE_MAZDAUOESTOCKCNT1RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT2RF AS UOE_MAZDAUOESTOCKCNT2RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT3RF AS UOE_MAZDAUOESTOCKCNT3RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT4RF AS UOE_MAZDAUOESTOCKCNT4RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT5RF AS UOE_MAZDAUOESTOCKCNT5RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT6RF AS UOE_MAZDAUOESTOCKCNT6RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.MAZDAUOESTOCKCNT7RF AS UOE_MAZDAUOESTOCKCNT7RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOEDISTRIBUTIONCDRF AS UOE_UOEDISTRIBUTIONCDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOEOTHERCDRF AS UOE_UOEOTHERCDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOEHMCDRF AS UOE_UOEHMCDRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.BOCOUNTRF AS UOE_BOCOUNTRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOEMARKCODERF AS UOE_UOEMARKCODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.SOURCESHIPMENTRF AS UOE_SOURCESHIPMENTRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ITEMCODERF AS UOE_ITEMCODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.UOECHECKCODERF AS UOE_UOECHECKCODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.HEADERRORMASSAGERF AS UOE_HEADERRORMASSAGERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.LINEERRORMASSAGERF AS UOE_LINEERRORMASSAGERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.DATASENDCODERF AS UOE_DATASENDCODERF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.DATARECOVERDIVRF AS UOE_DATARECOVERDIVRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ENTERUPDDIVSECRF AS UOE_ENTERUPDDIVSECRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ENTERUPDDIVBO1RF AS UOE_ENTERUPDDIVBO1RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ENTERUPDDIVBO2RF AS UOE_ENTERUPDDIVBO2RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ENTERUPDDIVBO3RF AS UOE_ENTERUPDDIVBO3RF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ENTERUPDDIVMAKERRF AS UOE_ENTERUPDDIVMAKERRF" + Environment.NewLine;
                    sqlText += " ,UOEDTL.ENTERUPDDIVEORF AS UOE_ENTERUPDDIVEORF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  UOEORDERDTLRF AS UOEDTL" + Environment.NewLine;
                    # region [WHERE��]
                    sqlText += "WHERE" + Environment.NewLine;

                    // ��ƃR�[�h
                    sqlText += "  UOEDTL.ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeStcUpdSearch.EnterpriseCode);

                    // ���_�R�[�h
                    sqlText += "  AND UOEDTL.SECTIONCODERF = @SECTIONCODE" + Environment.NewLine;
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findSectionCode.Value = SqlDataMediator.SqlSetString(uoeStcUpdSearch.SectionCode);

                    if (uoeStcUpdSearch.UOESupplierCd != 0)
                    {
                        // UOE������R�[�h�ōi�荞��
                        sqlText += "  AND UOEDTL.UOESUPPLIERCDRF = @UOESUPPLIERCD" + Environment.NewLine;

                        SqlParameter findUOESupplierCd = sqlCommand.Parameters.Add("@UOESUPPLIERCD", SqlDbType.Int);
                        findUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeStcUpdSearch.UOESupplierCd);
                    }

                    // �[�i���ԍ��ōi�荞��
                    sqlText += "  AND (UOEDTL.UOESECTIONSLIPNORF = @SLIPNO OR" + Environment.NewLine;
                    sqlText += "       UOEDTL.BOSLIPNO1RF = @SLIPNO OR" + Environment.NewLine;
                    sqlText += "       UOEDTL.BOSLIPNO2RF = @SLIPNO OR" + Environment.NewLine;
                    sqlText += "       UOEDTL.BOSLIPNO3RF = @SLIPNO)" + Environment.NewLine;

                    SqlParameter findSlipNo = sqlCommand.Parameters.Add("@SLIPNO", SqlDbType.NChar);
                    findSlipNo.Value = SqlDataMediator.SqlSetString(uoeStcUpdSearch.SlipNo);

                    sqlCommand.CommandText = sqlText;

                    // �_���폜�敪
                    string wkstring = "";
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
                    }

                    if (wkstring != "")
                    {
                        sqlText += wkstring;
                        SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif
                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        // UOE�����f�[�^�̎擾
                        UOEOrderDtlWork uoeOdrDtlWrk = new UOEOrderDtlWork();
                        this.CopyToUOEOrderDtlWorkFromReader(ref myReader, ref uoeOdrDtlWrk);

                        uoeOdrDtlList.Add(uoeOdrDtlWrk);

                    }
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                }
                # endregion


                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                if (ListUtils.IsEmpty(uoeOdrDtlList))
                {
# if DEBUG
                    errmsg += ": �Y������UOE�����f�[�^���L��܂���.";
                    this.WriteErrorLog(errmsg, status);
# endif
                }
                else
                {

                    uoeStcUpdDataList = uoeOdrDtlList;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = this.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                this.WriteErrorLog(ex, errmsg, status);
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
        // -- ADD 2009/08/24 ---------------------------------------------------------<<<<<

        #endregion

        # region [Write]
        /// <summary>
        /// �d���f�[�^ ���� �݌ɒ����f�[�^�̓o�^���s���܂��B
        /// </summary>
        /// <param name="uoeStockUpdateList">�o�^�Ώۂ̃f�[�^���i�[����Ă��� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d���f�[�^ ���� �݌ɒ����f�[�^�̓o�^���s���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        public int Write(ref object uoeStockUpdateList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = uoeStockUpdateList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                #region I/Owriter�����Ō����Ă���̂ō폜
                //// �V�X�e�����b�N
                //Dictionary<string, string> dic = new Dictionary<string, string>();
                //string enterpriseCode = string.Empty;
                //ArrayList infoList = new ArrayList();

                //foreach (object item in paraList)
                //{
                //    if (item is ArrayList)
                //    {
                //        object obj = ListUtils.Find((item as ArrayList), typeof(StockDetailWork), ListUtils.FindType.Array);
                        
                //        ArrayList stockDtlList = obj as ArrayList;

                //        if (stockDtlList != null)
                //        {
                //            StockDetailWork stockDtlWork = stockDtlList[0] as StockDetailWork;

                //            foreach (StockDetailWork stDtlWork in stockDtlList)
                //            {
                //                if (dic.ContainsKey(stDtlWork.WarehouseCode) == false)
                //                {
                //                    dic.Add(stDtlWork.WarehouseCode, stDtlWork.WarehouseCode);
                //                }
                //                enterpriseCode = stDtlWork.EnterpriseCode;
                //            }
                //        }
                //    }
                //}

                //ShareCheckInfo info = new ShareCheckInfo();

                //if (dic != null && dic.Count != 0)
                //{
                //    foreach (string wareCd in dic.Keys)
                //    {
                //        info.Keys.Add(enterpriseCode, ShareCheckType.WareHouse, "", wareCd);
                //        infoList.Add(info);
                //    }
                //    int st = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);
                //    if (st != 0) return st;
                //}
                #endregion

                // write���s
                status = this.Write(ref paraList, ref sqlConnection, ref sqlTransaction);

                #region I/Owriter�����Ō����Ă���̂ō폜
                //// �V�X�e�����b�N����
                //if (dic != null && dic.Count != 0)
                //{
                //    foreach (ShareCheckInfo Linfo in infoList)
                //    {
                //        int st = this.ShareCheck(Linfo, LockControl.Release, sqlConnection, sqlTransaction);
                //        if (st != 0) return st;
                //    }
                //}
                #endregion
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �d���f�[�^ ���� �݌ɒ����f�[�^�̓o�^���s���܂��B
        /// </summary>
        /// <param name="uoeStockUpdateList">�o�^�Ώۂ̃f�[�^���i�[����Ă��� CustomSerializeArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d���f�[�^ ���� �݌ɒ����f�[�^�̓o�^���s���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        public int Write(ref ArrayList uoeStockUpdateList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref uoeStockUpdateList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// UOE���ɍX�V����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeStockUpdateList">�ǉ��E�X�V����UOE���ɍX�V�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeStockUpdateList �Ɋi�[����Ă���UOE���ɍX�V����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        private int WriteProc(ref ArrayList uoeStockUpdateList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            // CustomSerializeArrayList
            // ��
            // ��IOWriteCtrlOptWork         [����E�d������f�[�^]
            // ��
            // ��CustomSerializeArrayList   [��֌��i�ԍX�V�p�����f�[�^�Q]
            // ����StockSlipWork            [�d���f�[�^(�d���`��=2:����)]
            // ����ArrayList
            // ��  ��StockDetailWork        [�d�����׃f�[�^(����)]
            // ��
            // ��CustomSerializeArrayList   [�����v�コ�ꂽ�d���f�[�^�Q]
            // ����StockSlipWork            [�d���f�[�^(�d���`��=0:�d��)]
            // ����ArrayList
            // ������StockDetailWork        [�d�����׃f�[�^(����)]
            // ����ArrayList
            // ��  ��SlipDetailAddInfoWork  [�`�[���גǉ����(����)]
            // ��
            // ��CustomSerializeArrayList   [�݌ɒ����f�[�^(1�`�[��)]
            //   ��ArrayList
            //   ����StockAdjustWork        [�݌ɒ����f�[�^(�K��1����)]
            //   ��ArrayList
            //     ��StockAdjustDtlWork     [�݌ɒ������׃f�[�^(����)]
            
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());

            # region [�p�����[�^�[�`�F�b�N]

            if (ListUtils.IsEmpty(uoeStockUpdateList))
            {
                errmsg += "�o�^�p�����[�^�[���s���ł�.";
                this.WriteErrorLog(errmsg, status);
                return status;
            }

            if (sqlConnection == null)
            {
                errmsg += "�f�[�^�x�[�X�ڑ���񂪖��ݒ�ł�.";
                this.WriteErrorLog(errmsg, status);
                return status;
            }

            if (sqlTransaction == null)
            {
                errmsg += "�g�����U�N�V������񂪖��ݒ�ł�.";
                this.WriteErrorLog(errmsg, status);
                return status;
            }

            # endregion

            # region [�����E�d���EUOE�����f�[�^�̏�����]

            // �����E�d���E�����{�d����UOE�����̑g�ݍ��킹�����œo�^����
            // ��UOE�����f�[�^���X�V����֌W��A�K�����s����
            string retMsg = string.Empty;
            string retItemInfo = string.Empty;
            SqlEncryptInfo sqlEncryptInfo = null;

            status = this.ioWriteCtrDb.WriteProc(ref uoeStockUpdateList, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

            # endregion

            # region [2009/02/13 DEL]
            //���d������̃����[�g���ō݌ɒ����f�[�^���쐬���Ă���̂ŁA���L�����͕s�v

            # region [�݌ɒ����f�[�^�̏�����]

            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    // �݌ɒ����f�[�^�̏�����
            //    foreach (object item in uoeStockUpdateList)
            //    {
            //        if (item is ArrayList)
            //        {
            //            object obj = ListUtils.Find((item as ArrayList), typeof(StockAdjustWork), ListUtils.FindType.Array);

            //            if (obj != null)
            //            {
            //                // �݌ɒ��������[�g�͂P�`�[�����������ł��Ȃ��ׁA�����ŕʂ̃R���N�V�����ɕ����Ă����B
            //                obj = item;
            //                status = this.stcAdjustDb.Write(ref obj, out retMsg, ref sqlConnection, ref sqlTransaction);

            //                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //                {
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion

            #endregion [2009/02/13 DEL]

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retMsg = (string.IsNullOrEmpty(retMsg)) ? "��" : retMsg;
                retItemInfo = (string.IsNullOrEmpty(retItemInfo)) ? "��" : retItemInfo;

                errmsg += string.Format(": {0} / {1}", retMsg, retItemInfo);
                this.WriteErrorLog(errmsg, status);
            }

            return status;
        }
        # endregion

        # region [�N���X�i�[����]

        /// <summary>
        /// �N���X�i�[���� Reader �� UOEOrderDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>UOEOrderDtlWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        /// </remarks>
        private UOEOrderDtlWork CopyToUOEOrderDtlWorkFromReader(ref SqlDataReader myReader)
        {
            UOEOrderDtlWork uoeOdrDtlWrk = new UOEOrderDtlWork();

            this.CopyToUOEOrderDtlWorkFromReader(ref myReader, ref uoeOdrDtlWrk);

            return uoeOdrDtlWrk;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� UOEOrderDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="uoeOdrDtlWrk">UOEOrderDtlWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        /// <br>Update Note: 2012/11/15 wangf </br>
        /// <br>           : 10801804-00�A1��16���z�M���ARedmine#31980 PM.NS��Q�ꗗNo.829�̑Ή�</br>
        /// <br>           : �݌ɓ��ɍX�V�̌��P���́A�񓚃f�[�^�̌��P����PM�̌��P���ƈقȂ�ꍇ���F�ɕς��@�\�����邪</br>
        /// <br>           : ���i�}�X�^�̌�����ς��Ă��A�F�ʂ͕ω����Ȃ��B</br>
		/// <br>Update Note: 2013/01/18 wangf </br>
		/// <br>           : 10801804-00�A1��16���z�M���ARedmine#31980 PM.NS��Q�ꗗNo.829�̑Ή�</br>
        /// </remarks>
        private void CopyToUOEOrderDtlWorkFromReader(ref SqlDataReader myReader, ref UOEOrderDtlWork uoeOdrDtlWrk)
        {
            if (myReader != null && uoeOdrDtlWrk != null)
            {
                # region �N���X�֊i�[
                uoeOdrDtlWrk.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UOE_CREATEDATETIMERF"));   // �쐬����
                uoeOdrDtlWrk.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UOE_UPDATEDATETIMERF"));   // �X�V����
                uoeOdrDtlWrk.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_ENTERPRISECODERF"));              // ��ƃR�[�h
                uoeOdrDtlWrk.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("UOE_FILEHEADERGUIDRF"));                // GUID
                uoeOdrDtlWrk.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UPDEMPLOYEECODERF"));            // �X�V�]�ƈ��R�[�h
                uoeOdrDtlWrk.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UPDASSEMBLYID1RF"));              // �X�V�A�Z���u��ID1
                uoeOdrDtlWrk.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UPDASSEMBLYID2RF"));              // �X�V�A�Z���u��ID2
                uoeOdrDtlWrk.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_LOGICALDELETECODERF"));         // �_���폜�敪
                uoeOdrDtlWrk.SystemDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_SYSTEMDIVCDRF"));                     // �V�X�e���敪
                uoeOdrDtlWrk.UOESalesOrderNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_UOESALESORDERNORF"));             // UOE�����ԍ�
                uoeOdrDtlWrk.UOESalesOrderRowNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_UOESALESORDERROWNORF"));       // UOE�����s�ԍ�
                uoeOdrDtlWrk.SendTerminalNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_SENDTERMINALNORF"));               // ���M�[���ԍ�
                uoeOdrDtlWrk.UOESupplierCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_UOESUPPLIERCDRF"));                 // UOE������R�[�h
                uoeOdrDtlWrk.UOESupplierName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOESUPPLIERNAMERF"));            // UOE�����於��
                uoeOdrDtlWrk.CommAssemblyId = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_COMMASSEMBLYIDRF"));              // �ʐM�A�Z���u��ID
                uoeOdrDtlWrk.OnlineNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_ONLINENORF"));                           // �I�����C���ԍ�
                uoeOdrDtlWrk.OnlineRowNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_ONLINEROWNORF"));                     // �I�����C���s�ԍ�
                uoeOdrDtlWrk.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("UOE_SALESDATERF"));          // ������t
                uoeOdrDtlWrk.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("UOE_INPUTDAYRF"));            // ���͓�
                uoeOdrDtlWrk.DataUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UOE_DATAUPDATEDATETIMERF"));       // �f�[�^�X�V����
                
                uoeOdrDtlWrk.UOEKind = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_UOEKINDRF"));                             // UOE���
                uoeOdrDtlWrk.SalesSlipNum = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_SALESSLIPNUMRF"));                  // ����`�[�ԍ�
                uoeOdrDtlWrk.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_ACPTANODRSTATUSRF"));             // �󒍃X�e�[�^�X
                uoeOdrDtlWrk.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("UOE_SALESSLIPDTLNUMRF"));             // ���㖾�גʔ�
                uoeOdrDtlWrk.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_SECTIONCODERF"));                    // ���_�R�[�h
                uoeOdrDtlWrk.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_SUBSECTIONCODERF"));               // ����R�[�h
                uoeOdrDtlWrk.CustomerCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_CUSTOMERCODERF"));                   // ���Ӑ�R�[�h
                uoeOdrDtlWrk.CustomerSnm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_CUSTOMERSNMRF"));                    // ���Ӑ旪��
                uoeOdrDtlWrk.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_CASHREGISTERNORF"));               // ���W�ԍ�
                uoeOdrDtlWrk.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("UOE_COMMONSEQNORF"));                     // ���ʒʔ�
                uoeOdrDtlWrk.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_SUPPLIERFORMALRF"));               // �d���`��
                uoeOdrDtlWrk.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_SUPPLIERSLIPNORF"));               // �d���`�[�ԍ�
                uoeOdrDtlWrk.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("UOE_STOCKSLIPDTLNUMRF"));             // �d�����גʔ�
                uoeOdrDtlWrk.BoCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_BOCODERF"));                              // BO�敪
                uoeOdrDtlWrk.UOEDeliGoodsDiv = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOE_UOEDELIGOODSDIVRF"));           // UOE�[�i�敪
                uoeOdrDtlWrk.DeliveredGoodsDivNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_DELIVEREDGOODSDIVNMRF"));    // �[�i�敪����
                uoeOdrDtlWrk.FollowDeliGoodsDiv = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_FOLLOWDELIGOODSDIVRF"));      // �t�H���[�[�i�敪
                uoeOdrDtlWrk.FollowDeliGoodsDivNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_FOLLOWDELIGOODSDIVNMRF"));  // �t�H���[�[�i�敪����
                uoeOdrDtlWrk.UOEResvdSection = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOERESVDSECTIONRF"));            // UOE�w�苒�_
                uoeOdrDtlWrk.UOEResvdSectionNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOERESVDSECTIONNMRF"));        // UOE�w�苒�_����
                uoeOdrDtlWrk.EmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_EMPLOYEECODERF"));                  // �]�ƈ��R�[�h
                uoeOdrDtlWrk.EmployeeName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_EMPLOYEENAMERF"));                  // �]�ƈ�����
                uoeOdrDtlWrk.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_GOODSMAKERCDRF"));                   // ���i���[�J�[�R�[�h
                uoeOdrDtlWrk.MakerName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAKERNAMERF"));                        // ���[�J�[����
                uoeOdrDtlWrk.GoodsNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_GOODSNORF"));                            // ���i�ԍ�
                uoeOdrDtlWrk.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_GOODSNONONEHYPHENRF"));        // �n�C�t�������i�ԍ�
                uoeOdrDtlWrk.GoodsName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_GOODSNAMERF"));                        // ���i����
                uoeOdrDtlWrk.WarehouseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_WAREHOUSECODERF"));                // �q�ɃR�[�h
                uoeOdrDtlWrk.WarehouseName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_WAREHOUSENAMERF"));                // �q�ɖ���
                uoeOdrDtlWrk.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_WAREHOUSESHELFNORF"));          // �q�ɒI��
                uoeOdrDtlWrk.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("UOE_ACCEPTANORDERCNTRF"));          // �󒍐���
                uoeOdrDtlWrk.ListPrice = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("UOE_LISTPRICERF"));                        // �艿�i�����j
                uoeOdrDtlWrk.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("UOE_SALESUNITCOSTRF"));                // �����P��
                uoeOdrDtlWrk.SupplierCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_SUPPLIERCDRF"));                       // �d����R�[�h
                uoeOdrDtlWrk.SupplierSnm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_SUPPLIERSNMRF"));                    // �d���旪��
                uoeOdrDtlWrk.UoeRemark1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOEREMARK1RF"));                      // �t�n�d���}�[�N�P
                uoeOdrDtlWrk.UoeRemark2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOEREMARK2RF"));                      // �t�n�d���}�[�N�Q
                uoeOdrDtlWrk.ReceiveDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UOE_RECEIVEDATERF"));     // ��M���t
                uoeOdrDtlWrk.ReceiveTime = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_RECEIVETIMERF"));                     // ��M����
                uoeOdrDtlWrk.AnswerMakerCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_ANSWERMAKERCDRF"));                 // �񓚃��[�J�[�R�[�h
                uoeOdrDtlWrk.AnswerPartsNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_ANSWERPARTSNORF"));                // �񓚕i��
                uoeOdrDtlWrk.AnswerPartsName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_ANSWERPARTSNAMERF"));            // �񓚕i��
                uoeOdrDtlWrk.SubstPartsNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_SUBSTPARTSNORF"));                  // ��֕i��
                uoeOdrDtlWrk.UOESectOutGoodsCnt = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_UOESECTOUTGOODSCNTRF"));       // UOE���_�o�ɐ�
                uoeOdrDtlWrk.BOShipmentCnt1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_BOSHIPMENTCNT1RF"));               // BO�o�ɐ�1
                uoeOdrDtlWrk.BOShipmentCnt2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_BOSHIPMENTCNT2RF"));               // BO�o�ɐ�2
                uoeOdrDtlWrk.BOShipmentCnt3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_BOSHIPMENTCNT3RF"));               // BO�o�ɐ�3
                uoeOdrDtlWrk.MakerFollowCnt = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_MAKERFOLLOWCNTRF"));               // ���[�J�[�t�H���[��
                uoeOdrDtlWrk.NonShipmentCnt = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_NONSHIPMENTCNTRF"));               // ���o�ɐ�
                uoeOdrDtlWrk.UOESectStockCnt = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_UOESECTSTOCKCNTRF"));             // UOE���_�݌ɐ�
                uoeOdrDtlWrk.BOStockCount1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_BOSTOCKCOUNT1RF"));                 // BO�݌ɐ�1
                uoeOdrDtlWrk.BOStockCount2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_BOSTOCKCOUNT2RF"));                 // BO�݌ɐ�2
                uoeOdrDtlWrk.BOStockCount3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_BOSTOCKCOUNT3RF"));                 // BO�݌ɐ�3
                uoeOdrDtlWrk.UOESectionSlipNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOESECTIONSLIPNORF"));          // UOE���_�`�[�ԍ�
                uoeOdrDtlWrk.BOSlipNo1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_BOSLIPNO1RF"));                        // BO�`�[�ԍ��P
                uoeOdrDtlWrk.BOSlipNo2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_BOSLIPNO2RF"));                        // BO�`�[�ԍ��Q
                uoeOdrDtlWrk.BOSlipNo3 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_BOSLIPNO3RF"));                        // BO�`�[�ԍ��R
                uoeOdrDtlWrk.EOAlwcCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_EOALWCCOUNTRF"));                     // EO������
                uoeOdrDtlWrk.BOManagementNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_BOMANAGEMENTNORF"));              // BO�Ǘ��ԍ�
                uoeOdrDtlWrk.AnswerListPrice = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("UOE_ANSWERLISTPRICERF"));            // �񓚒艿
                uoeOdrDtlWrk.AnswerSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("UOE_ANSWERSALESUNITCOSTRF"));    // �񓚌����P��
                uoeOdrDtlWrk.UOESubstMark = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOESUBSTMARKRF"));                  // UOE��փ}�[�N
                uoeOdrDtlWrk.UOEStockMark = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOESTOCKMARKRF"));                  // UOE�݌Ƀ}�[�N
                uoeOdrDtlWrk.PartsLayerCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_PARTSLAYERCDRF"));                  // �w�ʃR�[�h
                uoeOdrDtlWrk.MazdaUOEShipSectCd1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAZDAUOESHIPSECTCD1RF"));    // UOE�o�׋��_�R�[�h�P�i�}�c�_�j
                uoeOdrDtlWrk.MazdaUOEShipSectCd2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAZDAUOESHIPSECTCD2RF"));    // UOE�o�׋��_�R�[�h�Q�i�}�c�_�j
                uoeOdrDtlWrk.MazdaUOEShipSectCd3 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAZDAUOESHIPSECTCD3RF"));    // UOE�o�׋��_�R�[�h�R�i�}�c�_�j
                uoeOdrDtlWrk.MazdaUOESectCd1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAZDAUOESECTCD1RF"));            // UOE���_�R�[�h�P�i�}�c�_�j
                uoeOdrDtlWrk.MazdaUOESectCd2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAZDAUOESECTCD2RF"));            // UOE���_�R�[�h�Q�i�}�c�_�j
                uoeOdrDtlWrk.MazdaUOESectCd3 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAZDAUOESECTCD3RF"));            // UOE���_�R�[�h�R�i�}�c�_�j
                uoeOdrDtlWrk.MazdaUOESectCd4 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAZDAUOESECTCD4RF"));            // UOE���_�R�[�h�S�i�}�c�_�j
                uoeOdrDtlWrk.MazdaUOESectCd5 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAZDAUOESECTCD5RF"));            // UOE���_�R�[�h�T�i�}�c�_�j
                uoeOdrDtlWrk.MazdaUOESectCd6 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAZDAUOESECTCD6RF"));            // UOE���_�R�[�h�U�i�}�c�_�j
                uoeOdrDtlWrk.MazdaUOESectCd7 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_MAZDAUOESECTCD7RF"));            // UOE���_�R�[�h�V�i�}�c�_�j
                uoeOdrDtlWrk.MazdaUOEStockCnt1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_MAZDAUOESTOCKCNT1RF"));         // UOE�݌ɐ��P�i�}�c�_�j
                uoeOdrDtlWrk.MazdaUOEStockCnt2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_MAZDAUOESTOCKCNT2RF"));         // UOE�݌ɐ��Q�i�}�c�_�j
                uoeOdrDtlWrk.MazdaUOEStockCnt3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_MAZDAUOESTOCKCNT3RF"));         // UOE�݌ɐ��R�i�}�c�_�j
                uoeOdrDtlWrk.MazdaUOEStockCnt4 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_MAZDAUOESTOCKCNT4RF"));         // UOE�݌ɐ��S�i�}�c�_�j
                uoeOdrDtlWrk.MazdaUOEStockCnt5 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_MAZDAUOESTOCKCNT5RF"));         // UOE�݌ɐ��T�i�}�c�_�j
                uoeOdrDtlWrk.MazdaUOEStockCnt6 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_MAZDAUOESTOCKCNT6RF"));         // UOE�݌ɐ��U�i�}�c�_�j
                uoeOdrDtlWrk.MazdaUOEStockCnt7 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_MAZDAUOESTOCKCNT7RF"));         // UOE�݌ɐ��V�i�}�c�_�j
                uoeOdrDtlWrk.UOEDistributionCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOEDISTRIBUTIONCDRF"));        // UOE���R�[�h
                uoeOdrDtlWrk.UOEOtherCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOEOTHERCDRF"));                      // UOE���R�[�h
                uoeOdrDtlWrk.UOEHMCd = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOEHMCDRF"));                            // UOE�g�l�R�[�h
                uoeOdrDtlWrk.BOCount = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_BOCOUNTRF"));                             // �a�n��
                uoeOdrDtlWrk.UOEMarkCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOEMARKCODERF"));                    // UOE�}�[�N�R�[�h
                uoeOdrDtlWrk.SourceShipment = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_SOURCESHIPMENTRF"));              // �o�׌�
                uoeOdrDtlWrk.ItemCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_ITEMCODERF"));                          // �A�C�e���R�[�h
                uoeOdrDtlWrk.UOECheckCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_UOECHECKCODERF"));                  // UOE�`�F�b�N�R�[�h
                uoeOdrDtlWrk.HeadErrorMassage = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_HEADERRORMASSAGERF"));          // �w�b�h�G���[���b�Z�[�W
                uoeOdrDtlWrk.LineErrorMassage = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UOE_LINEERRORMASSAGERF"));          // ���C���G���[���b�Z�[�W
                uoeOdrDtlWrk.DataSendCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_DATASENDCODERF"));                   // �f�[�^���M�敪
                uoeOdrDtlWrk.DataRecoverDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_DATARECOVERDIVRF"));               // �f�[�^�����敪
                uoeOdrDtlWrk.EnterUpdDivSec = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_ENTERUPDDIVSECRF"));               // ���ɍX�V�敪�i���_�j
                uoeOdrDtlWrk.EnterUpdDivBO1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_ENTERUPDDIVBO1RF"));               // ���ɍX�V�敪�iBO1�j
                uoeOdrDtlWrk.EnterUpdDivBO2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_ENTERUPDDIVBO2RF"));               // ���ɍX�V�敪�iBO2�j
                uoeOdrDtlWrk.EnterUpdDivBO3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_ENTERUPDDIVBO3RF"));               // ���ɍX�V�敪�iBO3�j
                uoeOdrDtlWrk.EnterUpdDivMaker = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_ENTERUPDDIVMAKERRF"));           // ���ɍX�V�敪�iҰ���j
                uoeOdrDtlWrk.EnterUpdDivEO = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("UOE_ENTERUPDDIVEORF"));                 // ���ɍX�V�敪�iEO�j
				// ------------DEL wangf 2013/01/18 FOR Redmine#31980--------->>>>
                //// ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
                //// �����P���i���i�}�X�^���j
                //uoeOdrDtlWrk.GoodspriceuSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UOE_GOODSPRICEU_SALESUNITCOSTRF"));
                //uoeOdrDtlWrk.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOE_GOODSPRICEU_PRICESTARTDATERF"));
                //uoeOdrDtlWrk.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UOE_GOODSPRICEU_STOCKRATERF"));
                //uoeOdrDtlWrk.PriceListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("UOE_GOODSPRICEU_LISTPRICERF"));

                //uoeOdrDtlWrk.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));            // ���i�|�������N
                //uoeOdrDtlWrk.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));         // BL���i�R�[�h
                //uoeOdrDtlWrk.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));         // �ېŋ敪
                //// ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<
				// ------------DEL wangf 2013/01/18 FOR Redmine#31980---------<<<<
                # endregion
            }
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� StockDetailWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockDetailWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        /// </remarks>
        private StockDetailWork CopyToStockDetailWorkFromReader(ref SqlDataReader myReader)
        {
            StockDetailWork stcDtlWrk = new StockDetailWork();

            this.CopyToStockDetailWorkFromReader(ref myReader, ref stcDtlWrk);

            return stcDtlWrk;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� StockDetailWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="stcDtlWrk">StockDetailWork �I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        /// </remarks>
        private void CopyToStockDetailWorkFromReader(ref SqlDataReader myReader, ref StockDetailWork stcDtlWrk)
        {
            if (myReader != null && stcDtlWrk != null)
            {
                # region �N���X�֊i�[
                stcDtlWrk.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("STC_CREATEDATETIMERF"));               // �쐬����
                stcDtlWrk.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("STC_UPDATEDATETIMERF"));               // �X�V����
                stcDtlWrk.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_ENTERPRISECODERF"));                          // ��ƃR�[�h
                stcDtlWrk.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("STC_FILEHEADERGUIDRF"));                            // GUID
                stcDtlWrk.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_UPDEMPLOYEECODERF"));                        // �X�V�]�ƈ��R�[�h
                stcDtlWrk.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_UPDASSEMBLYID1RF"));                          // �X�V�A�Z���u��ID1
                stcDtlWrk.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_UPDASSEMBLYID2RF"));                          // �X�V�A�Z���u��ID2
                stcDtlWrk.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_LOGICALDELETECODERF"));                     // �_���폜�敪
                stcDtlWrk.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_ACCEPTANORDERNORF"));                         // �󒍔ԍ�
                stcDtlWrk.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_SUPPLIERFORMALRF"));                           // �d���`��
                stcDtlWrk.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_SUPPLIERSLIPNORF"));                           // �d���`�[�ԍ�
                stcDtlWrk.StockRowNo = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_STOCKROWNORF"));                                   // �d���s�ԍ�
                stcDtlWrk.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_SECTIONCODERF"));                                // ���_�R�[�h
                stcDtlWrk.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_SUBSECTIONCODERF"));                           // ����R�[�h
                stcDtlWrk.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("STC_COMMONSEQNORF"));                                 // ���ʒʔ�
                stcDtlWrk.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("STC_STOCKSLIPDTLNUMRF"));                         // �d�����גʔ�
                stcDtlWrk.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_SUPPLIERFORMALSRCRF"));                     // �d���`���i���j
                stcDtlWrk.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("STC_STOCKSLIPDTLNUMSRCRF"));                   // �d�����גʔԁi���j
                stcDtlWrk.AcptAnOdrStatusSync = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_ACPTANODRSTATUSSYNCRF"));                 // �󒍃X�e�[�^�X�i�����j
                stcDtlWrk.SalesSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("STC_SALESSLIPDTLNUMSYNCRF"));                 // ���㖾�גʔԁi�����j
                stcDtlWrk.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_STOCKSLIPCDDTLRF"));                           // �d���`�[�敪�i���ׁj
                stcDtlWrk.StockInputCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_STOCKINPUTCODERF"));                          // �d�����͎҃R�[�h
                stcDtlWrk.StockInputName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_STOCKINPUTNAMERF"));                          // �d�����͎Җ���
                stcDtlWrk.StockAgentCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_STOCKAGENTCODERF"));                          // �d���S���҃R�[�h
                stcDtlWrk.StockAgentName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_STOCKAGENTNAMERF"));                          // �d���S���Җ���
                stcDtlWrk.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_GOODSKINDCODERF"));                             // ���i����
                stcDtlWrk.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_GOODSMAKERCDRF"));                               // ���i���[�J�[�R�[�h
                stcDtlWrk.MakerName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_MAKERNAMERF"));                                    // ���[�J�[����
                stcDtlWrk.MakerKanaName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_MAKERKANANAMERF"));                            // ���[�J�[�J�i����
                stcDtlWrk.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_CMPLTMAKERKANANAMERF"));                  // ���[�J�[�J�i���́i�ꎮ�j
                stcDtlWrk.GoodsNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_GOODSNORF"));                                        // ���i�ԍ�
                stcDtlWrk.GoodsName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_GOODSNAMERF"));                                    // ���i����
                stcDtlWrk.GoodsNameKana = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_GOODSNAMEKANARF"));                            // ���i���̃J�i
                stcDtlWrk.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_GOODSLGROUPRF"));                                 // ���i�啪�ރR�[�h
                stcDtlWrk.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_GOODSLGROUPNAMERF"));                        // ���i�啪�ޖ���
                stcDtlWrk.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_GOODSMGROUPRF"));                                 // ���i�����ރR�[�h
                stcDtlWrk.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_GOODSMGROUPNAMERF"));                        // ���i�����ޖ���
                stcDtlWrk.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_BLGROUPCODERF"));                                 // BL�O���[�v�R�[�h
                stcDtlWrk.BLGroupName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_BLGROUPNAMERF"));                                // BL�O���[�v�R�[�h����
                stcDtlWrk.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_BLGOODSCODERF"));                                 // BL���i�R�[�h
                stcDtlWrk.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_BLGOODSFULLNAMERF"));                        // BL���i�R�[�h���́i�S�p�j
                stcDtlWrk.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_ENTERPRISEGANRECODERF"));                 // ���Е��ރR�[�h
                stcDtlWrk.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_ENTERPRISEGANRENAMERF"));                // ���Е��ޖ���
                stcDtlWrk.WarehouseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_WAREHOUSECODERF"));                            // �q�ɃR�[�h
                stcDtlWrk.WarehouseName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_WAREHOUSENAMERF"));                            // �q�ɖ���
                stcDtlWrk.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_WAREHOUSESHELFNORF"));                      // �q�ɒI��
                stcDtlWrk.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_STOCKORDERDIVCDRF"));                         // �d���݌Ɏ�񂹋敪
                stcDtlWrk.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_OPENPRICEDIVRF"));                               // �I�[�v�����i�敪
                stcDtlWrk.GoodsRateRank = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_GOODSRATERANKRF"));                            // ���i�|�������N
                stcDtlWrk.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_CUSTRATEGRPCODERF"));                         // ���Ӑ�|���O���[�v�R�[�h
                stcDtlWrk.SuppRateGrpCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_SUPPRATEGRPCODERF"));                         // �d����|���O���[�v�R�[�h
                stcDtlWrk.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_LISTPRICETAXEXCFLRF"));                    // �艿�i�Ŕ��C�����j
                stcDtlWrk.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_LISTPRICETAXINCFLRF"));                    // �艿�i�ō��C�����j
                stcDtlWrk.StockRate = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_STOCKRATERF"));                                    // �d����
                stcDtlWrk.RateSectStckUnPrc = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_RATESECTSTCKUNPRCRF"));                    // �|���ݒ苒�_�i�d���P���j
                stcDtlWrk.RateDivStckUnPrc = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_RATEDIVSTCKUNPRCRF"));                      // �|���ݒ�敪�i�d���P���j
                stcDtlWrk.UnPrcCalcCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_UNPRCCALCCDSTCKUNPRCRF"));               // �P���Z�o�敪�i�d���P���j
                stcDtlWrk.PriceCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_PRICECDSTCKUNPRCRF"));                       // ���i�敪�i�d���P���j
                stcDtlWrk.StdUnPrcStckUnPrc = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_STDUNPRCSTCKUNPRCRF"));                    // ��P���i�d���P���j
                stcDtlWrk.FracProcUnitStcUnPrc = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_FRACPROCUNITSTCUNPRCRF"));              // �[�������P�ʁi�d���P���j
                stcDtlWrk.FracProcStckUnPrc = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_FRACPROCSTCKUNPRCRF"));                     // �[�������i�d���P���j
                stcDtlWrk.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_STOCKUNITPRICEFLRF"));                      // �d���P���i�Ŕ��C�����j
                stcDtlWrk.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_STOCKUNITTAXPRICEFLRF"));                // �d���P���i�ō��C�����j
                stcDtlWrk.StockUnitChngDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_STOCKUNITCHNGDIVRF"));                       // �d���P���ύX�敪
                stcDtlWrk.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_BFSTOCKUNITPRICEFLRF"));                  // �ύX�O�d���P���i�����j
                stcDtlWrk.BfListPrice = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_BFLISTPRICERF"));                                // �ύX�O�艿
                stcDtlWrk.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_RATEBLGOODSCODERF"));                         // BL���i�R�[�h�i�|���j
                stcDtlWrk.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_RATEBLGOODSNAMERF"));                        // BL���i�R�[�h���́i�|���j
                stcDtlWrk.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_RATEGOODSRATEGRPCDRF"));                   // ���i�|���O���[�v�R�[�h�i�|���j
                stcDtlWrk.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_RATEGOODSRATEGRPNMRF"));                  // ���i�|���O���[�v���́i�|���j
                stcDtlWrk.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_RATEBLGROUPCODERF"));                         // BL�O���[�v�R�[�h�i�|���j
                stcDtlWrk.RateBLGroupName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_RATEBLGROUPNAMERF"));                        // BL�O���[�v���́i�|���j
                stcDtlWrk.StockCount = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_STOCKCOUNTRF"));                                  // �d����
                stcDtlWrk.OrderCnt = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_ORDERCNTRF"));                                      // ��������
                stcDtlWrk.OrderAdjustCnt = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_ORDERADJUSTCNTRF"));                          // ����������
                stcDtlWrk.OrderRemainCnt = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("STC_ORDERREMAINCNTRF"));                          // �����c��
                stcDtlWrk.RemainCntUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("STC_REMAINCNTUPDDATERF"));        // �c���X�V��
                stcDtlWrk.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("STC_STOCKPRICETAXEXCRF"));                       // �d�����z�i�Ŕ����j
                stcDtlWrk.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("STC_STOCKPRICETAXINCRF"));                       // �d�����z�i�ō��݁j
                stcDtlWrk.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_STOCKGOODSCDRF"));                               // �d�����i�敪
                stcDtlWrk.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("STC_STOCKPRICECONSTAXRF"));                     // �d�����z����Ŋz
                stcDtlWrk.TaxationCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_TAXATIONCODERF"));                               // �ېŋ敪
                stcDtlWrk.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_STOCKDTISLIPNOTE1RF"));                    // �d���`�[���ה��l1
                stcDtlWrk.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_SALESCUSTOMERCODERF"));                     // �̔���R�[�h
                stcDtlWrk.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_SALESCUSTOMERSNMRF"));                      // �̔��旪��
                stcDtlWrk.SlipMemo1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_SLIPMEMO1RF"));                                    // �`�[�����P
                stcDtlWrk.SlipMemo2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_SLIPMEMO2RF"));                                    // �`�[�����Q
                stcDtlWrk.SlipMemo3 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_SLIPMEMO3RF"));                                    // �`�[�����R
                stcDtlWrk.InsideMemo1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_INSIDEMEMO1RF"));                                // �Г������P
                stcDtlWrk.InsideMemo2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_INSIDEMEMO2RF"));                                // �Г������Q
                stcDtlWrk.InsideMemo3 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_INSIDEMEMO3RF"));                                // �Г������R
                stcDtlWrk.SupplierCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_SUPPLIERCDRF"));                                   // �d����R�[�h
                stcDtlWrk.SupplierSnm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_SUPPLIERSNMRF"));                                // �d���旪��
                stcDtlWrk.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_ADDRESSEECODERF"));                             // �[�i��R�[�h
                stcDtlWrk.AddresseeName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_ADDRESSEENAMERF"));                            // �[�i�於��
                stcDtlWrk.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_DIRECTSENDINGCDRF"));                         // �����敪
                stcDtlWrk.OrderNumber = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("STC_ORDERNUMBERRF"));                                // �����ԍ�
                stcDtlWrk.WayToOrder = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_WAYTOORDERRF"));                                   // �������@
                stcDtlWrk.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("STC_DELIGDSCMPLTDUEDATERF"));  // �[�i�����\���
                stcDtlWrk.ExpectDeliveryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("STC_EXPECTDELIVERYDATERF"));    // ��]�[��
                stcDtlWrk.OrderDataCreateDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_ORDERDATACREATEDIVRF"));                   // �����f�[�^�쐬�敪
                stcDtlWrk.OrderDataCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader,myReader.GetOrdinal("STC_ORDERDATACREATEDATERF"));  // �����f�[�^�쐬��
                stcDtlWrk.OrderFormIssuedDiv = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("STC_ORDERFORMISSUEDDIVRF"));                   // ���������s�ϋ敪
                # endregion
            }
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� StockDetailWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockDetailWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        /// </remarks>
        private StockSlipWork CopyToStockSlipWorkFromReader(ref SqlDataReader myReader)
        {
            StockSlipWork stcSlpWrk = new StockSlipWork();

            this.CopyToStockSlipWorkFromReader(ref myReader, ref stcSlpWrk);

            return stcSlpWrk;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� StockDetailWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="stcSlpWrk">StockDetailWork �I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.10.17</br>
        /// </remarks>
        private void CopyToStockSlipWorkFromReader(ref SqlDataReader myReader, ref StockSlipWork stcSlpWrk)
        {
            if (myReader != null && stcSlpWrk != null)
            {
                # region �N���X�֊i�[
                stcSlpWrk.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));             // �쐬����
                stcSlpWrk.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));             // �X�V����
                stcSlpWrk.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));                        // ��ƃR�[�h
                stcSlpWrk.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                          // GUID
                stcSlpWrk.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));                      // �X�V�]�ƈ��R�[�h
                stcSlpWrk.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));                        // �X�V�A�Z���u��ID1
                stcSlpWrk.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));                        // �X�V�A�Z���u��ID2
                stcSlpWrk.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));                   // �_���폜�敪
                stcSlpWrk.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));                         // �d���`��
                stcSlpWrk.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));                         // �d���`�[�ԍ�
                stcSlpWrk.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));                              // ���_�R�[�h
                stcSlpWrk.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));                         // ����R�[�h
                stcSlpWrk.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));                             // �ԓ`�敪
                stcSlpWrk.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));               // �ԍ��A���d���`�[�ԍ�
                stcSlpWrk.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));                         // �d���`�[�敪
                stcSlpWrk.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));                             // �d�����i�敪
                stcSlpWrk.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));                               // ���|�敪
                stcSlpWrk.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));                        // �d�����_�R�[�h
                stcSlpWrk.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));              // �d���v�㋒�_�R�[�h
                stcSlpWrk.StockSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPUPDATECDRF"));                   // �d���`�[�X�V�敪
                stcSlpWrk.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));                      // ���͓�
                stcSlpWrk.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));        // ���ד�
                stcSlpWrk.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));                    // �d����
                stcSlpWrk.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));        // �d���v����t
                stcSlpWrk.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));                       // �����敪
                stcSlpWrk.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));                                   // �x����R�[�h
                stcSlpWrk.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));                                    // �x���旪��
                stcSlpWrk.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));                                 // �d����R�[�h
                stcSlpWrk.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));                              // �d���於1
                stcSlpWrk.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));                              // �d���於2
                stcSlpWrk.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));                              // �d���旪��
                stcSlpWrk.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));                     // �Ǝ�R�[�h
                stcSlpWrk.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));                    // �Ǝ햼��
                stcSlpWrk.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));                           // �̔��G���A�R�[�h
                stcSlpWrk.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));                          // �̔��G���A����
                stcSlpWrk.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));                        // �d�����͎҃R�[�h
                stcSlpWrk.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));                        // �d�����͎Җ���
                stcSlpWrk.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));                        // �d���S���҃R�[�h
                stcSlpWrk.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));                        // �d���S���Җ���
                stcSlpWrk.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));               // �d���摍�z�\�����@�敪
                stcSlpWrk.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));                 // ���z�\���|���K�p�敪
                stcSlpWrk.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));                       // �d�����z���v
                stcSlpWrk.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));                     // �d�����z���v
                stcSlpWrk.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));                 // �d�����z�v�i�ō��݁j
                stcSlpWrk.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));                 // �d�����z�v�i�Ŕ����j
                stcSlpWrk.StockNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKNETPRICERF"));                           // �d���������z
                stcSlpWrk.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));                   // �d�����z����Ŋz
                stcSlpWrk.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCOUTTAXRF"));                   // �d���O�őΏۊz���v
                stcSlpWrk.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCINTAXRF"));                     // �d�����őΏۊz���v
                stcSlpWrk.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));                 // �d����ېőΏۊz���v
                stcSlpWrk.StockOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAXRF"));                               // �d�����z����Ŋz�i�O�Łj
                stcSlpWrk.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRCCONSTAXINCLURF"));               // �d�����z����Ŋz�i���Łj
                stcSlpWrk.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXEXCRF"));                     // �d���l�����z�v�i�Ŕ����j
                stcSlpWrk.ItdedStockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISOUTTAXRF"));               // �d���l���O�őΏۊz���v
                stcSlpWrk.ItdedStockDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISINTAXRF"));                 // �d���l�����őΏۊz���v
                stcSlpWrk.ItdedStockDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISTAXFRERF"));               // �d���l����ېőΏۊz���v
                stcSlpWrk.StockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKDISOUTTAXRF"));                         // �d���l������Ŋz�i�O�Łj
                stcSlpWrk.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));                 // �d���l������Ŋz�i���Łj
                stcSlpWrk.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));                                   // ����Œ����z
                stcSlpWrk.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));                           // �c�������z
                stcSlpWrk.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));                           // �d�������œ]�ŕ����R�[�h
                stcSlpWrk.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));              // �d�������Őŗ�
                stcSlpWrk.AccPayConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCPAYCONSTAXRF"));                           // ���|�����
                stcSlpWrk.StockFractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKFRACTIONPROCCDRF"));               // �d���[�������敪
                stcSlpWrk.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));                               // �����x���敪
                stcSlpWrk.AutoPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYSLIPNUMRF"));                         // �����x���`�[�ԍ�
                stcSlpWrk.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));                   // �ԕi���R�R�[�h
                stcSlpWrk.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));                        // �ԕi���R
                stcSlpWrk.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));                    // �����`�[�ԍ�
                stcSlpWrk.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));                  // �d���`�[���l1
                stcSlpWrk.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));                  // �d���`�[���l2
                stcSlpWrk.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));                         // ���׍s��
                stcSlpWrk.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));                // �d�c�h���M��
                stcSlpWrk.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));            // �d�c�h�捞��
                stcSlpWrk.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));                                // �t�n�d���}�[�N�P
                stcSlpWrk.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));                                // �t�n�d���}�[�N�Q
                stcSlpWrk.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));                         // �`�[���s�敪
                stcSlpWrk.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));                   // �`�[���s�ϋ敪
                stcSlpWrk.StockSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKSLIPPRINTDATERF"));  // �d���`�[���s��
                stcSlpWrk.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));                  // �`�[����ݒ�p���[ID
                stcSlpWrk.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPADDRESSDIVRF"));                         // �`�[�Z���敪
                stcSlpWrk.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));                           // �[�i��R�[�h
                stcSlpWrk.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));                          // �[�i�於��
                stcSlpWrk.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));                        // �[�i�於��2
                stcSlpWrk.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEPOSTNORF"));                      // �[�i��X�֔ԍ�
                stcSlpWrk.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR1RF"));                        // �[�i��Z��1(�s���{���s��S�E�����E��)
                stcSlpWrk.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR3RF"));                        // �[�i��Z��3(�Ԓn)
                stcSlpWrk.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR4RF"));                        // �[�i��Z��4(�A�p�[�g����)
                stcSlpWrk.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEETELNORF"));                        // �[�i��d�b�ԍ�
                stcSlpWrk.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEFAXNORF"));                        // �[�i��FAX�ԍ�
                stcSlpWrk.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIRECTSENDINGCDRF"));                       // �����敪
                # endregion
            }
        }

        # endregion
    }
}
