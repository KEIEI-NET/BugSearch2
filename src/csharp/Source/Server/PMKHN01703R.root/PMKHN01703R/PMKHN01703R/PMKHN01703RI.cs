//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ݏo�ϊ�����
// �v���O�����T�v   : �����𖞂������f�[�^��i�ԕϊ�����
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : �i�N
// �� �� ��  2015/01/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/02/26  �C�����e : Redmine#44209 ���b�Z�[�W�̕����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/04/17  �C�����e : Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/04/29  �C�����e : ���X�g��NULL�A��count�͔��f����Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;
//using Broadleaf.Application.LocalAccess; // DEL 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �ݏo�ϊ�����DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ݏo�ϊ������̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �i�N</br>
    /// <br>Date       : 2015/01/26</br>
    /// </remarks>
    [Serializable]
    public class ShipmentChangeDB : RemoteDB
    {
        /// <summary>
        /// �ݏo�ϊ�����DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        public ShipmentChangeDB()
        {
            // �i�ԕϊ���������
            if (this._iGoodsNoChgCommonDB == null)
            {
                this._iGoodsNoChgCommonDB = new GoodsNoChgCommonDB();
            }
            // �݌Ɏ󕥗��������[�g
            if (this._stockAcPayHistDB == null)
            {
                this._stockAcPayHistDB = new StockAcPayHistDB();
            }
            // �d����}�X�^�����[�g
            if (this._supplierDB == null)
            {
                this._supplierDB = new SupplierDB();
            }
            // ���Ӑ�}�X�^�����[�g
            if (this._customerDB == null)
            {
                this._customerDB = new CustomerDB();
            }
        }

        #region [OtherRemote]
        private StockAcPayHistDB _stockAcPayHistDB;    //�݌Ɏ󕥗��������[�g
        private GoodsNoChgCommonDB _iGoodsNoChgCommonDB;
        private SupplierDB _supplierDB; // �d����}�X�^�����[�g
        private CustomerDB _customerDB; //���Ӑ�}�X�^�����[�g
        #endregion

        #region [�ݏo�ϊ�����]

        #region �ݏo�f�[�^��������
        /// <summary>
        /// �w�肳�ꂽ�����̔��㖾�׃f�[�^�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="resultWorkList">��������</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : �w�肳�ꂽ������e-JIBAI�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        private int SearchSalesDetailProc(out ArrayList resultWorkList, string enterPriseCode)
        {
            // �R�l�N�V��������
            SqlConnection sqlConnection = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            resultWorkList = new ArrayList();
            ShipmentChangeWork shipmentChangeWork = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = _iGoodsNoChgCommonDB.CreateSqlConnection(true);

                #region SQL�쐬
                string command = string.Empty;
                command = " SELECT " + Environment.NewLine;
                command += " SALDTL.UPDATEDATETIMERF " + Environment.NewLine; �@�@�@�@// �X�V����
                command += " ,GDSCHG.CHGSRCGOODSNORF " + Environment.NewLine; �@�@�@�@// �ϊ��O���i�ԍ�
                command += " ,GDSCHG.GOODSMAKERCDRF " + Environment.NewLine;  �@�@�@�@// ���i���[�J�[�R�[�h
                command += " ,GDSCHG.CHGDESTGOODSNORF " + Environment.NewLine;�@�@�@�@// �ϊ��㏤�i�ԍ�
                command += " ,SALDTL.ACPTANODRSTATUSRF " + Environment.NewLine; �@�@�@�@// �󒍃X�e�[�^�X
                command += " ,SALDTL.SALESSLIPNUMRF " + Environment.NewLine; �@�@�@�@// ����`�[�ԍ�
                command += " ,SALDTL.SALESROWNORF " + Environment.NewLine; �@�@�@�@// ����s�ԍ�
                command += " ,SALDTL.SALESSLIPDTLNUMRF " + Environment.NewLine; �@�@�@�@// ���㖾�גʔ�
                command += " ,SALDTL.MAKERNAMERF " + Environment.NewLine; �@�@�@�@// ���[�J�[����
                command += " ,SALDTL.GOODSNAMERF " + Environment.NewLine; �@�@�@�@// ���i����
                command += " ,SALDTL.BLGOODSCODERF " + Environment.NewLine; �@�@�@�@// BL���i�R�[�h
                command += " ,SALDTL.BLGOODSFULLNAMERF " + Environment.NewLine; �@�@�@�@// BL���i�R�[�h����
                command += " ,SALDTL.ACPTANODRREMAINCNTRF " + Environment.NewLine; �@�@�@�@// �󒍎c��
                command += " ,SALDTL.OPENPRICEDIVRF " + Environment.NewLine; �@�@�@�@// �I�[�v�����i�敪
                command += " ,SALDTL.LISTPRICETAXEXCFLRF " + Environment.NewLine; �@�@�@�@// �艿�i�Ŕ��C�����j
                command += " ,SALDTL.SALESUNITCOSTRF " + Environment.NewLine; �@�@�@�@// �����P��
                command += " ,SALDTL.SALESUNPRCTAXEXCFLRF " + Environment.NewLine; �@�@�@�@// ����P���i�Ŕ��C�����j
                command += " ,SALDTL.SUPPLIERCDRF " + Environment.NewLine; �@�@�@�@// �d����R�[�h

                command += " ,SALSEC.CUSTOMERCODERF " + Environment.NewLine; �@�@�@�@// ���Ӑ�R�[�h
                command += " ,SALSEC.CUSTOMERSNMRF " + Environment.NewLine; �@�@�@�@// ���Ӑ旪��
                command += " ,SALSEC.RESULTSADDUPSECCDRF " + Environment.NewLine; �@�@�@�@// ���_�R�[�h
                command += " ,SALSEC.SECTIONGUIDENMRF  " + Environment.NewLine;           // ���_�K�C�h����

                command += " ,SALDTL.WAREHOUSECODERF " + Environment.NewLine; �@�@�@�@// �q�ɃR�[�h
                command += " ,SALDTL.WAREHOUSENAMERF " + Environment.NewLine; �@�@�@�@// �q�ɖ���
                command += " ,SALDTL.WAREHOUSESHELFNORF " + Environment.NewLine; �@�@�@�@// �q�ɒI��

                command += " ,STKNEW.WAREHOUSECODERF AS WAREHOUSECODENEWRF " + Environment.NewLine;  // �q�ɃR�[�h(�V�i��)
                command += " ,STKNEW.SUPPLIERSTOCKRF " + Environment.NewLine; �@�@�@�@// �d���݌ɐ�(�V�i��)
                command += " ,STKNEW.ACPODRCOUNTRF " + Environment.NewLine; �@�@�@�@// �󒍐�(�V�i��)
                command += " ,STKNEW.SALESORDERCOUNTRF " + Environment.NewLine; �@�@�@�@// ������(�V�i��)
                command += " ,STKNEW.MOVINGSUPLISTOCKRF " + Environment.NewLine; �@�@�@�@//�ړ����d���݌ɐ�(�V�i��)
                command += " ,STKNEW.SHIPMENTCNTRF AS SHIPMENTCNTNOADDRF " + Environment.NewLine; �@�@�@�@// �o�א��i���v��j(�V�i��)
                command += " ,STKNEW.ARRIVALCNTRF " + Environment.NewLine; �@�@�@�@// ���א��i���v��j(�V�i��)
                command += " ,STKNEW.SHIPMENTPOSCNTRF " + Environment.NewLine; �@�@�@�@// �o�׉\��(�V�i��)
                command += " ,STKOLD.WAREHOUSECODERF AS WAREHOUSECODEOLDRF " + Environment.NewLine;  // �q�ɃR�[�h(���i��)
                command += " ,STKOLD.SHIPMENTCNTRF AS SHIPMENTCNTNOADDOLDRF " + Environment.NewLine; �@�@�@�@// �o�א��i���v��j(���i��)
                command += " ,STKOLD.SHIPMENTPOSCNTRF AS SHIPMENTPOSCNTOLDRF " + Environment.NewLine; �@�@�@�@// �o�׉\��(���i��)

                command += " FROM SALESDETAILRF SALDTL WITH (READUNCOMMITTED) " + Environment.NewLine;
                command += " INNER JOIN GOODSNOCHANGERF GDSCHG WITH (READUNCOMMITTED) " + Environment.NewLine;
                command += "  ON GDSCHG.ENTERPRISECODERF = SALDTL.ENTERPRISECODERF " + Environment.NewLine;
                command += "  AND GDSCHG.CHGSRCGOODSNORF = SALDTL.GOODSNORF " + Environment.NewLine;
                command += "  AND GDSCHG.GOODSMAKERCDRF = SALDTL.GOODSMAKERCDRF " + Environment.NewLine;

                command += " INNER JOIN " + Environment.NewLine;
                command += "   (SELECT " + Environment.NewLine;
                command += "      SALS.ENTERPRISECODERF " + Environment.NewLine;
                command += "     ,SALS.ACPTANODRSTATUSRF " + Environment.NewLine;
                command += "     ,SALS.SALESSLIPNUMRF " + Environment.NewLine;
                command += "     ,SALS.CUSTOMERCODERF " + Environment.NewLine;     // ���Ӑ�R�[�h
                command += "     ,SALS.CUSTOMERSNMRF " + Environment.NewLine;        // ���Ӑ旪��
                command += "     ,SALS.RESULTSADDUPSECCDRF " + Environment.NewLine;       // ���_�R�[�h
                command += "     ,SECINF.SECTIONGUIDENMRF " + Environment.NewLine;     // ���_�K�C�h����
                command += "    FROM SALESSLIPRF SALS WITH (READUNCOMMITTED) " + Environment.NewLine;
                command += "    LEFT JOIN SECINFOSETRF SECINF WITH (READUNCOMMITTED) " + Environment.NewLine;
                command += "     ON SECINF.ENTERPRISECODERF = SALS.ENTERPRISECODERF " + Environment.NewLine;
                command += "     AND SECINF.SECTIONCODERF = SALS.RESULTSADDUPSECCDRF ) AS SALSEC" + Environment.NewLine;
                command += "  ON SALSEC.ENTERPRISECODERF = SALDTL.ENTERPRISECODERF " + Environment.NewLine;
                command += "  AND SALSEC.ACPTANODRSTATUSRF = SALDTL.ACPTANODRSTATUSRF " + Environment.NewLine;
                command += "  AND SALSEC.SALESSLIPNUMRF = SALDTL.SALESSLIPNUMRF " + Environment.NewLine;

                command += "  LEFT JOIN STOCKRF STKOLD WITH (READUNCOMMITTED)  " + Environment.NewLine;
                command += "  ON STKOLD.ENTERPRISECODERF = SALDTL.ENTERPRISECODERF " + Environment.NewLine;
                command += "  AND STKOLD.WAREHOUSECODERF = SALDTL.WAREHOUSECODERF " + Environment.NewLine;
                command += "  AND STKOLD.GOODSMAKERCDRF = SALDTL.GOODSMAKERCDRF " + Environment.NewLine;
                command += "  AND STKOLD.GOODSNORF = GDSCHG.CHGSRCGOODSNORF " + Environment.NewLine;

                command += "  LEFT JOIN STOCKRF STKNEW WITH (READUNCOMMITTED)  " + Environment.NewLine;
                command += "  ON STKNEW.ENTERPRISECODERF = SALDTL.ENTERPRISECODERF " + Environment.NewLine;
                command += "  AND STKNEW.WAREHOUSECODERF = SALDTL.WAREHOUSECODERF " + Environment.NewLine;
                command += "  AND STKNEW.GOODSMAKERCDRF = SALDTL.GOODSMAKERCDRF " + Environment.NewLine;
                command += "  AND STKNEW.GOODSNORF = GDSCHG.CHGDESTGOODSNORF " + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(command, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, enterPriseCode);
                // �N�G�����s���̃^�C���A�E�g���Ԃ�10���ɐݒ肷��
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // �N���X�i�[����
                    CopyToWorkFromReader(ref myReader, out shipmentChangeWork);
                    resultWorkList.Add(shipmentChangeWork);
                }

                if (resultWorkList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        #endregion

        #region �ݏo�f�[�^�ϊ�����
        /// <summary>
        /// �w�肳�ꂽ�����̑ݏo�ϊ������B
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑ݏo�ϊ������B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        public int ShipmentChange(GoodsChangeAllCndWorkWork CndWork, out object sucObjectList, out object errObjectList, out int readCnt)
        {
            // �R�l�N�V����
            SqlConnection sqlConnection = null;
            // �g�����U�N�V����
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //�ϊ��Ώۂ̑ݏo�f�[�^
            ArrayList changeList = new ArrayList();

            // �����ȓo�^����f�[�^
            sucObjectList = null;
            ArrayList sucResultList = new ArrayList();

            // ���s�ȓo�^����f�[�^
            errObjectList = null;
            ArrayList errResultList = new ArrayList();

            // �Ώی���
            readCnt = 0;

            try
            {
                // �R�l�N�V��������
                sqlConnection = _iGoodsNoChgCommonDB.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = _iGoodsNoChgCommonDB.CreateTransaction(ref sqlConnection);

                // �ݏo�f�[�^��������
                status = this.SearchSalesDetailProc(out changeList, CndWork.EnterpriseCode);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    return status;
                }

                readCnt = changeList.Count;

                status = this.ShipmentChangeProc(CndWork, changeList,out sucResultList, out errResultList, ref sqlConnection, ref sqlTransaction);

                // �߂��郊�X�g
                sucObjectList = (object)sucResultList;
                errObjectList = (object)errResultList;

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
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ShipmentChangeDB.shipmentChange");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
            return status;
        }

        #region �ݏo�f�[�^�X�V����
        /// <summary>
        /// �w�肳�ꂽ�����̑ݏo�f�[�^�X�V
        /// </summary>
        /// <param name="cndWork">CndWork</param>
        /// <param name="changeList">�Ώۂ̑ݏo�f�[�^</param>
        /// <param name="sucResultList">sucessList</param>
        /// <param name="errResultList">errorList</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        private int ShipmentChangeProc(GoodsChangeAllCndWorkWork cndWork, ArrayList changeList,out ArrayList sucResultList, out ArrayList errResultList,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �����ȓo�^����f�[�^
            sucResultList = new ArrayList();

            // ���s�ȓo�^����f�[�^
            errResultList = new ArrayList();

            ArrayList shipmentChangeWorkList = null;

            Dictionary<string, ArrayList> changeDic = new Dictionary<string, ArrayList>();

            try
            {

                // �`�[�ԍ��悤��Dictionary���쐬����
                foreach (ShipmentChangeWork shipmentChangeWork in changeList)
                {
                    string key = shipmentChangeWork.SalesSlipNum;
                    if (!changeDic.ContainsKey(key))
                    {
                        shipmentChangeWorkList = new ArrayList();
                        shipmentChangeWorkList.Add(shipmentChangeWork);
                        changeDic.Add(key, shipmentChangeWorkList);
                    }
                    else
                    {
                        changeDic[key].Add(shipmentChangeWork);
                    }
                }

                foreach (string key in changeDic.Keys)
                {
                    ArrayList shipmentChangelist = new ArrayList();
                    shipmentChangelist = changeDic[key];

                    sqlTransaction.Save("shipmentSavePoint");
                    // �ݏo�f�[�^�X�V����
                    status = ShipmentChangeProcProc(ref shipmentChangelist, cndWork.EnterpriseCode, ref sqlConnection, ref sqlTransaction);

                    // �݌ɒ����f�[�^�̓o�^����
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = WriteToStockAcPayHist(shipmentChangelist, cndWork, ref sqlConnection, ref sqlTransaction);
                    }

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �������b�Z�[�W�o�^
                        foreach (ShipmentChangeWork successWork in shipmentChangelist)
                        {
                            sucResultList.Add(successWork);
                        }
                    }
                    else
                    {
                        foreach (ShipmentChangeWork errWork in shipmentChangelist)
                        {
                            errResultList.Add(errWork);
                        }
                        sqlTransaction.Rollback("shipmentSavePoint");
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex, "ShipmentChangeDB.ShipmentChangeProc");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̑ݏo�f�[�^�X�V����
        /// </summary>
        /// <param name="shipmentChangeList">�Ώۂ̑ݏo�f�[�^</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        private int ShipmentChangeProcProc(ref ArrayList shipmentChangeList, string enterPriseCode, 
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                string errMsg = string.Empty;
                //�ݏo�f�[�^�X�V����
                foreach (ShipmentChangeWork shipmentChangeWork in shipmentChangeList)
                {
                    status = this.ChangeSalesDetailProc(shipmentChangeWork, enterPriseCode, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                        || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                    {
                        //errMsg = "�r���G���[�A�i�Ԃ̕ύX�Ɏ��s���܂���"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        errMsg = GoodsNoChgCommonDB.RENTUPDATEFAIL; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        break;
                    }
                    else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //errMsg = "�o�^�G���[�A�i�Ԃ̕ύX�Ɏ��s���܂���"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        errMsg = GoodsNoChgCommonDB.RENTEXCEPTIONMSG; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                        break;
                    }
                }

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (ShipmentChangeWork shipmentChangeWork in shipmentChangeList)
                    {
                        shipmentChangeWork.Message = errMsg;
                    }
                }

                return status;

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ShipmentChangeDB.ShipmentChangeProcProc");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
        }

        /// <summary>
        /// �ݏo�f�[�^�X�V����(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="shipmentChangeWork">�ݏo�f�[�^�X�V���I�u�W�F�N�g</param>
        /// <param name="enterPriseCode">enterPriseCode</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note        : �ݏo�f�[�^�X�V����(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        private int ChangeSalesDetailProc(ShipmentChangeWork shipmentChangeWork, string enterPriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string command = string.Empty;

            command = " SELECT " + Environment.NewLine;
            command += " UPDATEDATETIMERF, ENTERPRISECODERF, ACPTANODRSTATUSRF, SALESSLIPDTLNUMRF, LOGICALDELETECODERF FROM SALESDETAILRF WITH (READUNCOMMITTED)" + Environment.NewLine;
            command += "WHERE" + Environment.NewLine;
            command += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            command += " AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS" + Environment.NewLine;
            command += " AND SALESSLIPDTLNUMRF=@FINDSALESSLIPDTLNUM" + Environment.NewLine;

            try
            {
                sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findParaSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUM", SqlDbType.BigInt);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(shipmentChangeWork.AcptAnOdrStatus);
                findParaSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(shipmentChangeWork.SalesSlipDtlNum);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != shipmentChangeWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        return status;
                    }

                    // �ݏo�f�[�^�X�V����
                    string sqlTxt = "";
                    sqlTxt += " UPDATE SALESDETAILRF SET " + Environment.NewLine;
                    sqlTxt += "   GOODSNORF=@GOODSNORF " + Environment.NewLine;
                    sqlTxt += "   ,PRTGOODSNORF=@PRTGOODSNORF " + Environment.NewLine; // ADD �i�N 2015/03/02 ����p�i�ԕϊ��̑Ή�
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                    sqlTxt += "   AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlTxt += "   AND SALESSLIPDTLNUMRF=@FINDSALESSLIPDTLNUM" + Environment.NewLine;

                    sqlCommand.CommandText = sqlTxt;
                    //KEY�R�}���h���Đݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                    findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(shipmentChangeWork.AcptAnOdrStatus);
                    findParaSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(shipmentChangeWork.SalesSlipDtlNum);

                    //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNORF", SqlDbType.NChar);
                    SqlParameter paraPrtGoodsNo = sqlCommand.Parameters.Add("@PRTGOODSNORF", SqlDbType.NChar); // ADD �i�N 2015/03/02 ����p�i�ԕϊ��̑Ή�

                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(shipmentChangeWork.NewGoodsNo);
                    paraPrtGoodsNo.Value = SqlDataMediator.SqlSetString(shipmentChangeWork.NewGoodsNo); // ADD �i�N 2015/03/02 ����p�i�ԕϊ��̑Ή�
                }
                else
                {
                    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    return status;
                }

                if (myReader.IsClosed == false) myReader.Close();
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        #region �݌ɒ����f�[�^�̓o�^����
        /// <summary>
        /// �݌ɒ����f�[�^�̓o�^����(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="shipmentChangelist">�f�[�^���I�u�W�F�N�g</param>
        /// <param name="cndWork">�������[�N</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note        : �݌ɒ����f�[�^�̓o�^����(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>Note        : Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�</br>
        /// <br>Programmer  : ���V��</br>
        /// <br>Date        : 2015/04/17</br>
        /// <br>Note        : ���X�g��NULL�A��count�͔��f����Ή�</br>
        /// <br>Programmer  : ���V��</br>
        /// <br>Date        : 2015/04/29</br>
        private int WriteToStockAcPayHist(ArrayList shipmentChangelist, GoodsChangeAllCndWorkWork cndWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList stockAcPayHistWorkList = new ArrayList();

            // ������z�����敪�}�X�^�ǂݍ���
            List<SalesProcMoneyWork> salesProcMoneyList = new List<SalesProcMoneyWork>();
            status = getSalesProcMoneyList(cndWork, out salesProcMoneyList);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                return status;
            }

            // �d�����z�����敪�}�X�^�ǂݍ���
            List<StockProcMoneyWork> stockProcMoneyList = new List<StockProcMoneyWork>();
            status = getStockProcMoneyList(cndWork, out stockProcMoneyList);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                return status;
            }
            for (int i = 0; i < shipmentChangelist.Count; i++)
            {

                //ShipmentChangeWork work = (ShipmentChangeWork)shipmentChangelist[i];// DEL 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�
                //----- ADD 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�------>>>>>
                ShipmentChangeWork work = null;
                if (shipmentChangelist != null && shipmentChangelist.Count > 0)
                {
                    work = (ShipmentChangeWork)shipmentChangelist[i];
                }
                //----- ADD 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�------<<<<<
                //�q�ɃR�[�h�����݂���ꍇ
                if (!string.IsNullOrEmpty(work.WarehouseCode))
                {
                    #region �󕥗����f�[�^��ǉ��쐬����
                    StockAcPayHistWork counterStockAcPayHistWork = new StockAcPayHistWork();

                    //�o�^�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)counterStockAcPayHistWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                    counterStockAcPayHistWork.IoGoodsDay = DateTime.Today; // ���o�ד�
                    counterStockAcPayHistWork.AddUpADate = DateTime.MinValue; ;  //�v����t
                    counterStockAcPayHistWork.AcPaySlipCd = 22; //�󕥌��`�[�敪
                    counterStockAcPayHistWork.AcPaySlipNum = work.SalesSlipNum; //�󕥌��`�[�ԍ�
                    counterStockAcPayHistWork.AcPaySlipRowNo = work.SalesRowNo; //�󕥌��s�ԍ�
                    counterStockAcPayHistWork.AcPayHistDateTime = DateTime.Now.Ticks; //�󕥗����쐬����
                    counterStockAcPayHistWork.AcPayTransCd = 10; //�󕥌�����敪
                    counterStockAcPayHistWork.InputSectionCd = cndWork.LoginSectionCode; //���͋��_�R�[�h
                    counterStockAcPayHistWork.InputSectionGuidNm = cndWork.LoginSectionNm; //���͋��_�K�C�h����
                    counterStockAcPayHistWork.InputAgenCd = cndWork.LoginEmpleeCode; //���͒S���҃R�[�h
                    counterStockAcPayHistWork.InputAgenNm = cndWork.LoginEmpleeName; //���͒S���Җ���
                    counterStockAcPayHistWork.MoveStatus = 0; //�ړ����
                    counterStockAcPayHistWork.CustSlipNo = null; //�����`�[�ԍ�
                    counterStockAcPayHistWork.SlipDtlNum = work.SalesSlipDtlNum; //���גʔ�
                    counterStockAcPayHistWork.AcPayNote = null; //�󕥔��l
                    counterStockAcPayHistWork.GoodsMakerCd = work.MakerCode; //���i���[�J�[�R�[�h
                    counterStockAcPayHistWork.MakerName = work.MakerName; //���[�J�[����
                    counterStockAcPayHistWork.GoodsNo = work.NewGoodsNo; //���i�ԍ�
                    counterStockAcPayHistWork.GoodsName = work.GoodsName; //���i����
                    counterStockAcPayHistWork.BLGoodsCode = work.BLGoodsCode; //BL���i�R�[�h
                    counterStockAcPayHistWork.BLGoodsFullName = work.BLGoodsFullName; //BL���i�R�[�h����
                    counterStockAcPayHistWork.SectionCode = work.SectionCode; //���_�R�[�h
                    counterStockAcPayHistWork.SectionGuideNm = work.SectionGuideNm; //���_�K�C�h����
                    counterStockAcPayHistWork.WarehouseCode = work.WarehouseCode; //�q�ɃR�[�h
                    counterStockAcPayHistWork.WarehouseName = work.WarehouseName; //�q�ɖ���
                    counterStockAcPayHistWork.ShelfNo = work.WarehouseShelfNo; //�I��
                    counterStockAcPayHistWork.BfSectionCode = null; //�ړ������_�R�[�h
                    counterStockAcPayHistWork.BfSectionGuideNm = null; //�ړ������_�K�C�h����
                    counterStockAcPayHistWork.BfEnterWarehCode = null; //�ړ����q�ɃR�[�h
                    counterStockAcPayHistWork.BfEnterWarehName = null; //�ړ����q�ɖ���
                    counterStockAcPayHistWork.BfShelfNo = null; //�ړ����I��
                    counterStockAcPayHistWork.AfSectionCode = null; //�ړ��拒�_�R�[�h
                    counterStockAcPayHistWork.AfSectionGuideNm = null; //�ړ��拒�_�K�C�h����
                    counterStockAcPayHistWork.AfEnterWarehCode = null; //�ړ���q�ɃR�[�h
                    counterStockAcPayHistWork.AfEnterWarehName = null;//�ړ���q�ɖ���
                    counterStockAcPayHistWork.AfShelfNo = null; //�ړ���I��
                    counterStockAcPayHistWork.CustomerCode = work.CustomerCode; //���Ӑ�R�[�h
                    counterStockAcPayHistWork.CustomerSnm = work.CustomerSnm; //���Ӑ旪��
                    counterStockAcPayHistWork.SupplierCd = 0; //�d����R�[�h
                    counterStockAcPayHistWork.SupplierSnm = null; //�d���旪��
                    counterStockAcPayHistWork.ArrivalCnt = 0; //���א�
                    counterStockAcPayHistWork.ShipmentCnt = work.ShipmentCnt;//�o�א�
                    counterStockAcPayHistWork.OpenPriceDiv = work.OpenPriceDiv; //�I�[�v�����i�敪
                    counterStockAcPayHistWork.ListPriceTaxExcFl = work.ListPriceTaxExcFl; //�艿�i�Ŕ��C�����j
                    counterStockAcPayHistWork.StockUnitPriceFl = work.SalesUnitCost; //�d���P���i�Ŕ��C�����j
                    counterStockAcPayHistWork.SalesUnPrcTaxExcFl = work.SalesUnPrcTaxExcFl; //����P���i�Ŕ��C�����j
                    counterStockAcPayHistWork.SupplierStock = work.SupplierStock; //�d���݌ɐ�
                    counterStockAcPayHistWork.AcpOdrCount = work.AcpOdrCount; //�󒍐�
                    counterStockAcPayHistWork.SalesOrderCount = work.SalesOrderCount; //������
                    counterStockAcPayHistWork.MovingSupliStock = work.MovingSupliStock; //�ړ����d���݌ɐ�
                    counterStockAcPayHistWork.NonAddUpShipmCnt = work.ShipmentNoAddCnt; //�o�א��i���v��j
                    counterStockAcPayHistWork.NonAddUpArrGdsCnt = work.ArrivalCnt; //���א��i���v��j
                    counterStockAcPayHistWork.ShipmentPosCnt = work.ShipmentPosCnt; //�o�׉\��
                    counterStockAcPayHistWork.PresentStockCnt = work.ShipmentPosCnt; //���݌ɐ���

                    //���i�Čv�Z
                    this.calculatePrice(cndWork, stockProcMoneyList, salesProcMoneyList, ref work, ref sqlConnection, ref sqlTransaction);
                    counterStockAcPayHistWork.SalesMoney = work.SalesMoneyTaxExc;
                    counterStockAcPayHistWork.StockPrice = work.Cost;

                    stockAcPayHistWorkList.Add(counterStockAcPayHistWork);
                    #endregion
                }
            }

            // �`�[�ԍ����Ɏ󕥗����f�[�^��o�^����
            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
            try
            {
            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                status = _stockAcPayHistDB.WriteStockAcPayHistProc(ref stockAcPayHistWorkList, ref sqlConnection, ref sqlTransaction);
            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "WriteStockAcPayHistProc");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<

            string errMsg = string.Empty;
            // �G���[���O�Z�b�g
            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
            {
                //errMsg = "�r���G���[�A�݌Ɏ󕥗����f�[�^�̓o�^�Ɏ��s���܂���"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                errMsg = GoodsNoChgCommonDB.RENTUPDATEFAIL; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
            }
            else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //errMsg = "�o�^�G���[�A�݌Ɏ󕥗����f�[�^�̓o�^�Ɏ��s���܂���"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
                errMsg = GoodsNoChgCommonDB.RENTEXCEPTIONMSG; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
            }
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (ShipmentChangeWork errWork in shipmentChangelist)
                {
                    errWork.Message = errMsg;
                }
            }

            return status;
        }
        #endregion

        #endregion

        #region WHERE���������񐶐�

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="enterPriseCode">��ƃR�[�h</param>
        /// <returns>Where����������</returns>
        /// <br>Note        : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, string enterPriseCode)
        {
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "SALDTL.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);

            //�_���폜�敪
            retstring += "AND GDSCHG.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
            retstring += "AND SALDTL.LOGICALDELETECODERF=@FINDLOGICALDELETECODE2 ";
            SqlParameter paraLogicalDeleteCode2 = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE2", SqlDbType.Int);
            paraLogicalDeleteCode2.Value = SqlDataMediator.SqlSetInt32(0);

            //�󒍃X�e�[�^�X
            retstring += "AND SALDTL.ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS ";
            SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
            paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(40);

            // �󒍎c��
            retstring += "AND (SALDTL.ACPTANODRREMAINCNTRF > 0 OR  SALDTL.ACPTANODRREMAINCNTRF < 0) ";

            retstring += " ORDER BY SALDTL.GOODSMAKERCDRF, SALDTL.GOODSNORF ";
            return retstring;
        }

        #endregion

        #region �N���X�i�[����
        /// <summary>
        /// �N���X�i�[���� Reader �� ShipmentChangeWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="shipmentChangeWork">ShipmentChangeWork</param>
        /// <returns>RateWork</returns>
        /// <remarks>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        private void CopyToWorkFromReader(ref SqlDataReader myReader, out ShipmentChangeWork shipmentChangeWork)
        {
            shipmentChangeWork = new ShipmentChangeWork();
            #region �N���X�֊i�[
            shipmentChangeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF")); // �X�V����
            shipmentChangeWork.NewGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF")); // �ϊ��㏤�i�ԍ� 
            shipmentChangeWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF")); // ���i���[�J�[�R�[�h
            shipmentChangeWork.OldGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF")); // ���i�ԍ�
            shipmentChangeWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF")); // �󒍃X�e�[�^�X
            shipmentChangeWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF")); // ����`�[�ԍ�
            shipmentChangeWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF")); // ����s�ԍ�
            shipmentChangeWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF")); // ���㖾�גʔ�
            shipmentChangeWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF")); // ���[�J�[����
            shipmentChangeWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF")); // ���i����
            shipmentChangeWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF")); // BL���i�R�[�h
            shipmentChangeWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF")); // BL���i�R�[�h����
            shipmentChangeWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF")); // �󒍎c��
            shipmentChangeWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF")); // �I�[�v�����i�敪
            shipmentChangeWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF")); // �艿�i�Ŕ��C�����j
            shipmentChangeWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF")); // �����P��
            shipmentChangeWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF")); // ����P���i�Ŕ��C�����j
            shipmentChangeWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF")); // �d����R�[�h
            shipmentChangeWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF")); // ���Ӑ�R�[�h
            shipmentChangeWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF")); // ���Ӑ旪��
            shipmentChangeWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF")); // �q�ɃR�[�h
            shipmentChangeWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF")); // �q�ɖ���
            shipmentChangeWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF")); // �q�ɒI��
            shipmentChangeWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF")); // ���_�R�[�h
            shipmentChangeWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF")); // ���_�K�C�h����
            string WarehouseCodeNew = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODENEWRF")); // �q�ɃR�[�h
            string WarehouseCodeOld = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODEOLDRF")); // �q�ɃR�[�h
            if (!string.IsNullOrEmpty(WarehouseCodeNew))
            {
                shipmentChangeWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF")); // �d���݌ɐ�(�V�i��)
                shipmentChangeWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF")); // �󒍐�(�V�i��)
                shipmentChangeWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF")); // ������(�V�i��)
                shipmentChangeWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF")); // �ړ����d���݌ɐ�(�V�i��)
                shipmentChangeWork.ShipmentNoAddCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTNOADDRF")); // �o�א��i���v��j(�V�i��)
                shipmentChangeWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF")); // ���א��i���v��j(�V�i��)
                shipmentChangeWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF")); // �o�׉\��(�V�i��)
            }
            else if (!string.IsNullOrEmpty(WarehouseCodeOld))
            {
                shipmentChangeWork.ShipmentNoAddCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTNOADDOLDRF")); // �o�א��i���v��j(�����i)
                shipmentChangeWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTOLDRF")); // �o�׉\��(�����i)
                shipmentChangeWork.SupplierStock = shipmentChangeWork.ShipmentNoAddCnt + shipmentChangeWork.ShipmentPosCnt;
            }
            else
            {
                //�Ȃ�
            }
            #endregion
        }
        #endregion

        #region ���i�Čv�Z
        /// <summary>
        /// ���i�Čv�Z����
        /// </summary>
        /// <param name="cndtn">�������[�N</param>
        /// <param name="_stockProcMoneyList">�d�����z�����敪�f�[�^</param>
        /// <param name="_salesProcMoneyList">������z�����敪�f�[�^</param>
        /// <param name="work">�󕥗����f�[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : ���i�Čv�Z����</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private void calculatePrice(GoodsChangeAllCndWorkWork cndtn, List<StockProcMoneyWork> _stockProcMoneyList, List<SalesProcMoneyWork> _salesProcMoneyList, ref ShipmentChangeWork work, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int salesProcCd = 0;
            double salesProcUnit = 0;
            int costProcCd = 0;
            double costProcUnit = 0;
            long afterSales = 0;
            long afterCost = 0;

            double salesUnitCost = work.SalesUnitCost * work.ShipmentCnt; //�������z
            double salesUnPrcTaxExcFl = work.SalesUnPrcTaxExcFl * work.ShipmentCnt; //������z

            // ������z�[�������R�[�h
            int salesFrcProcCd = this.GetSalesFractionProcCd(cndtn.EnterpriseCode, work.CustomerCode);
            // �������z�[�������R�[�h
            int costFrcProcCd = this.GetCostFractionProcCd(cndtn.EnterpriseCode, work.SupplierCd, ref sqlConnection, ref sqlTransaction);

            // ������z�[�������P�ʁA�[�������敪�擾
            this.GetSalesFractionProcInfo(0, salesFrcProcCd, (double)salesUnPrcTaxExcFl, _salesProcMoneyList, out salesProcUnit, out salesProcCd);

            // �������z�[�������P�ʁA�[�������敪�擾
            this.GetStockFractionProcInfo(0, costFrcProcCd, (double)salesUnitCost, _stockProcMoneyList, out costProcUnit, out costProcCd);

            // ������z�[������
            FractionCalculate.FracCalcMoney(salesUnPrcTaxExcFl, salesProcUnit, salesProcCd, out afterSales);
            // �������z�[������
            FractionCalculate.FracCalcMoney(salesUnitCost, costProcUnit, costProcCd, out afterCost);

            work.SalesMoneyTaxExc = afterSales;
            work.Cost = afterCost;
        }

        #region ������z
        /// <summary>
        /// ������z�����敪�}�X�^�ǂݍ���
        /// </summary>
        /// <param name="cndtn">�ݏo�f�[�^</param>
        /// <param name="salesProcMoneyList"></param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : ���z�����敪�}�X�^�ǂݍ���</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private int getSalesProcMoneyList(GoodsChangeAllCndWorkWork cndtn, out List<SalesProcMoneyWork> salesProcMoneyList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            salesProcMoneyList = new List<SalesProcMoneyWork>();

            SalesProcMoneyDB salesProcMoneyDB = new SalesProcMoneyDB();

            SalesProcMoneyWork paraWork = new SalesProcMoneyWork();
            paraWork.EnterpriseCode = cndtn.EnterpriseCode;
            paraWork.FracProcMoneyDiv = -1;
            paraWork.FractionProcCode = -1;

            ArrayList paraList = new ArrayList();
            paraList.Add(paraWork);
            object paraObj = paraList;

            object retobj = null;

            status = salesProcMoneyDB.Search(out retobj, paraObj, 0, 0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList list = retobj as ArrayList;

                salesProcMoneyList.AddRange((SalesProcMoneyWork[])list.ToArray(typeof(SalesProcMoneyWork)));

                salesProcMoneyList.Sort(new SalesProcMoneyComparer());
            }
            return status;
        }

        /// <summary>
        /// ������z�����敪�ݒ�}�X�^���A�Ώۋ��z�ɊY������[�������P�ʁA�[�������R�[�h���擾���܂��B
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="price">�Ώۋ��z</param>
        /// <param name="_salesProcMoneyList">������z�����敪�ݒ�}�X�^</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        /// <remarks>
        /// <br>Note       : ���z�����敪�}�X�^�ǂݍ���</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private void GetSalesFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double price, List<SalesProcMoneyWork> _salesProcMoneyList, out double fractionProcUnit, out int fractionProcCd)
        {
            fractionProcUnit = 1;   // �P���ȊO��1�~�P��
            fractionProcCd = 1;     // �؎̂�

            if (_salesProcMoneyList == null || _salesProcMoneyList.Count == 0) return;

            List<SalesProcMoneyWork> salesProcMoneyList = _salesProcMoneyList.FindAll(
                                        delegate(SalesProcMoneyWork salesProcMoney)
                                        {
                                            if ((salesProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                                                (salesProcMoney.FractionProcCode == fractionProcCode) &&
                                                (salesProcMoney.UpperLimitPrice >= price))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });
            if (salesProcMoneyList != null && salesProcMoneyList.Count > 0)
            {
                fractionProcUnit = salesProcMoneyList[0].FractionProcUnit;
                fractionProcCd = salesProcMoneyList[0].FractionProcCd;
            }
        }

        /// <summary>
        /// ������z�����敪�}�X�^�f�[�^��r�N���X(�[�������Ώۋ��z(����)�A�[�������R�[�h(����)�A������z(����))
        /// </summary>
        /// <remarks></remarks>
        private class SalesProcMoneyComparer : Comparer<SalesProcMoneyWork>
        {

            public override int Compare(SalesProcMoneyWork x, SalesProcMoneyWork y)
            {
                int result = x.FracProcMoneyDiv.CompareTo(y.FracProcMoneyDiv);
                if (result != 0) return result;

                result = x.FractionProcCode.CompareTo(y.FractionProcCode);
                if (result != 0) return result;

                result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }

        /// <summary>
        /// ������z�[�������R�[�h���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="customerCode">�d����R�[�h</param>
        /// <remarks>
        /// <br>Note       : ������z�[�������R�[�h���擾���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>Note       : Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/04/17</br>
        /// </remarks>
        private int GetSalesFractionProcCd(string enterpriseCode, int customerCode)
        {
            int salesFrcProcCd = 0;
            CustomerWork customerWork = new CustomerWork();
            customerWork.EnterpriseCode = enterpriseCode;
            customerWork.CustomerCode = customerCode;

            CustomSerializeArrayList paraCustomerArray = new CustomSerializeArrayList();
            paraCustomerArray.Add(customerWork);
            object paraList = paraCustomerArray;

            //int status = _customerDB.Read(0, ref paraList); // DEL 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�
            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = _customerDB.Read(0, ref paraList);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "Read");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                CustomSerializeArrayList retCustomerArrayList = paraList as CustomSerializeArrayList;
                foreach (object obj in retCustomerArrayList)
                {
                    if (obj is CustomerWork)
                    {
                        customerWork = (CustomerWork)obj;
                        salesFrcProcCd = customerWork.SalesMoneyFrcProcCd;
                    }
                }
            }

            return salesFrcProcCd;
        }
        #endregion

        #region �������z
        /// <summary>
        /// �d�����z�����敪�}�X�^�ǂݍ���
        /// </summary>
        /// <param name="cndtn">�ݏo�f�[�^</param>
        /// <param name="stockProcMoneyList"></param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : ���z�����敪�}�X�^�ǂݍ���</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private int getStockProcMoneyList(GoodsChangeAllCndWorkWork cndtn, out List<StockProcMoneyWork> stockProcMoneyList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            stockProcMoneyList = new List<StockProcMoneyWork>();

            StockProcMoneyDB stockProcMoneyDB = new StockProcMoneyDB();

            StockProcMoneyWork paraWork = new StockProcMoneyWork();
            paraWork.EnterpriseCode = cndtn.EnterpriseCode;
            paraWork.FracProcMoneyDiv = -1;
            paraWork.FractionProcCode = -1;

            ArrayList paraList = new ArrayList();
            paraList.Add(paraWork);

            object retobj = null;

            status = stockProcMoneyDB.Search(out retobj, paraList, 0, 0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList list = retobj as ArrayList;

                stockProcMoneyList.AddRange((StockProcMoneyWork[])list.ToArray(typeof(StockProcMoneyWork)));

                stockProcMoneyList.Sort(new StockProcMoneyComparer());
            }
            return status;
        }

        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^���A�Ώۋ��z�ɊY������[�������P�ʁA�[�������R�[�h���擾���܂��B
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="price">�Ώۋ��z</param>
        /// <param name="_stockProcMoneyList">�d�����z�����敪�ݒ�}�X�^</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        /// <remarks>
        /// <br>Note       : ���z�����敪�}�X�^�ǂݍ���</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private void GetStockFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double price, List<StockProcMoneyWork> _stockProcMoneyList, out double fractionProcUnit, out int fractionProcCd)
        {
            fractionProcUnit = 1;   // �P���ȊO��1�~�P��
            fractionProcCd = 1;     // �؎̂�

            if (_stockProcMoneyList == null || _stockProcMoneyList.Count == 0) return;

            List<StockProcMoneyWork> stockProcMoneyList = _stockProcMoneyList.FindAll(
                                        delegate(StockProcMoneyWork stockProcMoney)
                                        {
                                            if ((stockProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                                                (stockProcMoney.FractionProcCode == fractionProcCode) &&
                                                (stockProcMoney.UpperLimitPrice >= price))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });
            if (stockProcMoneyList != null && stockProcMoneyList.Count > 0)
            {
                fractionProcUnit = stockProcMoneyList[0].FractionProcUnit;
                fractionProcCd = stockProcMoneyList[0].FractionProcCd;
            }
        }

        /// <summary>
        /// �d�����z�����敪�}�X�^�f�[�^��r�N���X(�[�������Ώۋ��z(����)�A�[�������R�[�h(����)�A������z(����))
        /// </summary>
        /// <remarks></remarks>
        private class StockProcMoneyComparer : Comparer<StockProcMoneyWork> 
        {

            public override int Compare(StockProcMoneyWork x, StockProcMoneyWork y)
            {
                int result = x.FracProcMoneyDiv.CompareTo(y.FracProcMoneyDiv);
                if (result != 0) return result;

                result = x.FractionProcCode.CompareTo(y.FractionProcCode);
                if (result != 0) return result;

                result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }

        /// <summary>
        /// �������z�[�������R�[�h���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <remarks>
        /// <br>Note       : �������z�[�������R�[�h���擾���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>Note       : Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/04/17</br>
        /// </remarks>
        private int GetCostFractionProcCd(string enterpriseCode, int supplierCd, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int costFrcProcCd = 0;
            if (supplierCd != 0)
            {
                SupplierWork supplierWork = new SupplierWork();
                supplierWork.EnterpriseCode = enterpriseCode;
                supplierWork.SupplierCd = supplierCd;

                //int status = _supplierDB.Read(ref supplierWork, 0, ref sqlConnection, ref sqlTransaction); // DEL 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�
                //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------>>>>>
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                try
                {
                    status = _supplierDB.Read(ref supplierWork, 0, ref sqlConnection, ref sqlTransaction);
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "Read");
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                //----- ADD 2015/04/17 ���V�� Redmine#45436 ���i���g�p���ă}�X�^�̍폜/�o�^�����s���Ă���ӏ����O�L���b�`����Ή�------<<<<<
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    costFrcProcCd = supplierWork.StockMoneyFrcProcCd;
                }
            }
            return costFrcProcCd;
        }
        #endregion
        
        #endregion

        #endregion

    }
}
