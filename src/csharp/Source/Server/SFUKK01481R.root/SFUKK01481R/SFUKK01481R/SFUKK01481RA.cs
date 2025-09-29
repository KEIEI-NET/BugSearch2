//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :													//
// Program name     :   �����������샊���[�e�B���O						//
//                  :   SFUKK01481R.DLL									//
// Name Space       :   Broadleaf.SFLibrary.Windows.Forms				//
// Programer        :   ���i�@��										//
// Date             :   2005.08.19										//
// Note				:	�����폜�͓����E��������MT�̂ݍX�V���A��������E//
//					:	��MT�̍X�V�͍s��Ȃ��i���؂ōX�V����j		//
//----------------------------------------------------------------------//
// Update Note      :	2006.02.27 ���i�@��								//
//					:	����p�ʓ����Ή�								//
// Update Note      :	2006.03.07 ���i�@��								//
//					:	�ԓ`�쐬���̐Ԉ����쐬�����Ή�					//
//					:	2006.10.18 ���i�@��								//
//					:	�g�����U�N�V�����������x����ύX				//
//                  :   2007.01.31 18322 T.Kimura MA.NS�p�ɕύX         //
//--------------------------------------------------------------------- //
//                  :   2008.03.07 980081 �R�c ���F ���ʊ�Ή�        //
//--------------------------------------------------------------------- //
//                  :   2008.04.25 21112  PM.NS�p�ɕύX                 //
//----------------------------------------------------------------------//
// Update Note �@�@ : �@K2014/05/28 zhujw�@�@�@�@�@�@�@�@�@�@�@�@�@ �@�@//
// �Ǘ��ԍ�    �@�@ : �@11001635-00 ���J�g�\�ʑΉ�                    //
//----------------------------------------------------------------------//
// Update Note �@�@ : �@K2014/06/19 zhujw�@�@�@�@�@�@�@�@�@�@�@�@�@ �@�@//
// �Ǘ��ԍ�    �@�@ : �@11001635-00 RedMine#42902                       //
//                  :   �����̃f�[�^�p�����[�^���g�p����                //
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co,. Ltd					//
//**********************************************************************//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

using System.Collections.Generic; //  ADD zhujw K2014/05/28 ���J�g�\�ʑΉ�
using System.Text;//  ADD zhujw K2014/05/28 ���J�g�\�ʑΉ�

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �����������쏈�������[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : �w�蓾�Ӑ�E�󒍔ԍ��̓��������f�[�^�̍폜����������s���N���X�ł��B</br>
	/// <br>Programmer : 95089 ���i�@��</br>
	/// <br>Date       : 2005.08.9</br>
	/// <br></br>
	/// <br>Update Note: 2007.01.31 18322 T.Kimura MA.NS�p�ɕύX</br>
	/// </remarks>
	[Serializable]
	public class ControlDepsitAlwDB : RemoteDB, IControlDepsitAlwDB
	{
		/// <summary>
		/// �����X�VDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.02</br>
		/// </remarks>
		public ControlDepsitAlwDB() :
			base( "SFUKK01346D", "Broadleaf.Application.Remoting.ParamData.DepositAlwWork", "DEPOSITALWRF")
		{
			Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
			Debug.WriteLine("ControlDepsitAlwDB�R���X�g���N�^");
		}

        // --- ADD zhujw K2014/05/28 ���J�g�\�ʑΉ� ------->>>>> 
        #region Search
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔�����������f�[�^�e�L�X�g�̑S�Ė߂鏈���i�_���폜�����j
        /// </summary>
        /// <param name="controlKaToDepsitAlwResultWork">��������</param>
        /// <param name="controlKaToDepsitAlwCndtnWork">�����p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ��ƃR�[�h�̔�����������f�[�^LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer  : zhujw</br>
        /// <br>Date        : K2014/05/28</br>
        /// </remarks>
        public int Search(out object controlKaToDepsitAlwResultWork, object controlKaToDepsitAlwCndtnWork)
        {
            SqlConnection sqlConnection = null;
            controlKaToDepsitAlwResultWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection(true);

                return SearchProc(out controlKaToDepsitAlwResultWork, controlKaToDepsitAlwCndtnWork, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ControlKaToDepsitAlwDB.Search");
                controlKaToDepsitAlwResultWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (null != sqlConnection)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔�����������f�[�^�e�L�X�g��S�Ė߂鏈��
        /// </summary>
        /// <param name="controlKaToDepsitAlwResultWork">��������</param>
        /// <param name="controlKaToDepsitAlwCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer  : zhujw</br>
        /// <br>Date        : K2014/05/28</br>
        /// </remarks>
        private int SearchProc(out object controlKaToDepsitAlwResultWork, object controlKaToDepsitAlwCndtnWork, ref SqlConnection sqlConnection)
        {
            //ControlKaToDepsitAlwCndtnWork cndtnWork = controlKaToDepsitAlwCndtnWork as ControlKaToDepsitAlwCndtnWork;// DEL zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p����

            DepositAlwWork cndtnWork = controlKaToDepsitAlwCndtnWork as DepositAlwWork;// ADD zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p����

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            controlKaToDepsitAlwResultWork = null;
            ArrayList al = new ArrayList();   //���o����

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                StringBuilder sb = new StringBuilder();
                sb.Append(" SELECT ").Append(Environment.NewLine);
                sb.Append(" MIN(C.DEPOSITROWNORF) AS DEPOSITROWNORF,").Append(Environment.NewLine);                 // �������׃f�[�^.�s�ԍ�
                sb.Append(" A.SALESSLIPNUMRF,").Append(Environment.NewLine);                                        // ���������}�X�^.����`�[�ԍ�
                sb.Append(" A.RECONCILEDATERF,").Append(Environment.NewLine);                                       // ���������}�X�^.�����ݓ�
                sb.Append(" B.CREATEDATETIMERF AS BUPDATEDATETIMERF,").Append(Environment.NewLine);                 // �����}�X�^.�쐬����
                sb.Append(" B.FEEDEPOSITRF AS FEEDEPOSITRF,").Append(Environment.NewLine);                          // �����}�X�^.�萔�������z
                sb.Append(" B.DISCOUNTDEPOSITRF AS DISCOUNTDEPOSITRF,").Append(Environment.NewLine);                // �����}�X�^.�l�������z
                sb.Append(" A.DEPOSITAGENTNMRF,").Append(Environment.NewLine);                                      // ���������}�X�^.�����S���Җ���
                sb.Append(" C.UPDATEDATETIMERF AS CUPDATEDATETIMERF,").Append(Environment.NewLine);                 // �������׃f�[�^.�X�V����
                sb.Append(" D.MONEYKINDNAMERF").Append(Environment.NewLine);                                        // ���z��ʃ}�X�^�i���[�U�[�o�^�j.���햼��
                // ���������}�X�^
                sb.Append(" FROM DEPOSITALWRF A WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                // �����}�X�^
                sb.Append(" LEFT JOIN DEPSITMAINRF  B WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sb.Append(" ON  A.ENTERPRISECODERF = B.ENTERPRISECODERF ").Append(Environment.NewLine);
                sb.Append(" AND B.ACPTANODRSTATUSRF = 30").Append(Environment.NewLine);
                sb.Append(" AND A.DEPOSITSLIPNORF = B.DEPOSITSLIPNORF").Append(Environment.NewLine);
                sb.Append(" AND B.LOGICALDELETECODERF = 0").Append(Environment.NewLine);
                // �������׃f�[�^
                sb.Append(" LEFT JOIN DEPSITDTLRF C WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sb.Append(" ON B.ENTERPRISECODERF = C.ENTERPRISECODERF ").Append(Environment.NewLine);
                sb.Append(" AND C.ACPTANODRSTATUSRF = 30").Append(Environment.NewLine);
                sb.Append(" AND C.LOGICALDELETECODERF = 0").Append(Environment.NewLine);
                sb.Append(" AND B.DEPOSITSLIPNORF = C.DEPOSITSLIPNORF ").Append(Environment.NewLine);
                // ���z��ʃ}�X�^�i���[�U�[�o�^�j
                sb.Append(" LEFT JOIN MONEYKINDURF D WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sb.Append(" ON C.ENTERPRISECODERF = D.ENTERPRISECODERF ").Append(Environment.NewLine);
                sb.Append(" AND D.PRICESTCODERF = 0").Append(Environment.NewLine);
                sb.Append(" AND C.MONEYKINDCODERF = D.MONEYKINDCODERF").Append(Environment.NewLine);
                //��������
                sb.Append(MakeWhereString(ref sqlCommand, cndtnWork));
                sb.Append(" GROUP BY  A.SALESSLIPNUMRF,A.RECONCILEDATERF, B.CREATEDATETIMERF, B.FEEDEPOSITRF, B.DISCOUNTDEPOSITRF, A.DEPOSITAGENTNMRF, C.UPDATEDATETIMERF, D.MONEYKINDNAMERF").Append(Environment.NewLine);
                //�\�[�g
                sb.Append(" ORDER BY SALESSLIPNUMRF,DEPOSITROWNORF ");

                sqlCommand.CommandText = sb.ToString();

                // �N�G�����s���̃^�C���A�E�g���Ԃ�10���ɐݒ肷��
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                myReader = sqlCommand.ExecuteReader();
                //Dictionary<string, ControlKaToDepsitAlwWork> newData = new Dictionary<string, ControlKaToDepsitAlwWork>(); // DEL zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p����
                Dictionary<string, DepositAlwWork> newData = new Dictionary<string, DepositAlwWork>(); // ADD zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p����

                while (myReader.Read())
                {
                    string moneyKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));                // ���햼��
                    #region ���o����-�l�Z�b�g
                    // --- ADD zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� ------->>>>> 
                    DepositAlwWork controlKaToDepsitAlwWork = new DepositAlwWork();

                    //�f�[�^���ʎ擾���e�i�[
                    controlKaToDepsitAlwWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));                  // ����`�[�ԍ�
                    controlKaToDepsitAlwWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));              // �����S���Җ���
                    controlKaToDepsitAlwWork.ReconcileDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RECONCILEDATERF"));  // ������
                    controlKaToDepsitAlwWork.CustomerName = moneyKindName;                                                                                 // ���Ӑ於->���햼��
                    controlKaToDepsitAlwWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("BUPDATEDATETIMERF")); // �����쐬����
                    controlKaToDepsitAlwWork.CreateDateTime = DateTime.Now;
                    controlKaToDepsitAlwWork.AcptAnOdrStatus = 0;
                    controlKaToDepsitAlwWork.AddUpSecCode = string.Empty;
                    controlKaToDepsitAlwWork.CustomerName2 = string.Empty;
                    controlKaToDepsitAlwWork.DebitNoteOffSetCd = 0;
                    controlKaToDepsitAlwWork.DepositAgentCode = string.Empty;
                    controlKaToDepsitAlwWork.DepositAllowance = 0;
                    controlKaToDepsitAlwWork.DepositSlipNo = 0;
                    controlKaToDepsitAlwWork.EnterpriseCode = string.Empty;
                    controlKaToDepsitAlwWork.FileHeaderGuid = Guid.NewGuid();
                    controlKaToDepsitAlwWork.InputDepositSecCd = string.Empty;
                    controlKaToDepsitAlwWork.LogicalDeleteCode = 0;
                    controlKaToDepsitAlwWork.ReconcileAddUpDate = DateTime.Now;
                    controlKaToDepsitAlwWork.UpdAssemblyId1 = string.Empty;
                    controlKaToDepsitAlwWork.UpdAssemblyId2 = string.Empty;
                    controlKaToDepsitAlwWork.UpdEmployeeCode = string.Empty;

                    if (newData.ContainsKey(controlKaToDepsitAlwWork.SalesSlipNum))
                    {
                        string dataKey = controlKaToDepsitAlwWork.SalesSlipNum;
                        if (controlKaToDepsitAlwWork.UpdateDateTime > newData[dataKey].UpdateDateTime)
                        {
                            newData[dataKey].SalesSlipNum = controlKaToDepsitAlwWork.SalesSlipNum;// ����`�[�ԍ�
                            newData[dataKey].DepositAgentNm = controlKaToDepsitAlwWork.DepositAgentNm;// �����S���Җ���
                            newData[dataKey].CustomerName = controlKaToDepsitAlwWork.CustomerName;// ���Ӑ於->���햼��
                            newData[dataKey].ReconcileDate = controlKaToDepsitAlwWork.ReconcileDate;// ������
                            newData[dataKey].UpdateDateTime = controlKaToDepsitAlwWork.UpdateDateTime;// �����쐬����
                            newData[dataKey].CreateDateTime = DateTime.Now;
                            newData[dataKey].AcptAnOdrStatus = 0;
                            newData[dataKey].AddUpSecCode = string.Empty;
                            newData[dataKey].CustomerName2 = string.Empty;
                            newData[dataKey].DebitNoteOffSetCd = 0;
                            newData[dataKey].DepositAgentCode = string.Empty;
                            newData[dataKey].DepositAllowance = 0;
                            newData[dataKey].DepositSlipNo = 0;
                            newData[dataKey].EnterpriseCode = string.Empty;
                            newData[dataKey].FileHeaderGuid = Guid.NewGuid();
                            newData[dataKey].InputDepositSecCd = string.Empty;
                            newData[dataKey].LogicalDeleteCode = 0;
                            newData[dataKey].ReconcileAddUpDate = DateTime.Now;
                            newData[dataKey].UpdAssemblyId1 = string.Empty;
                            newData[dataKey].UpdAssemblyId2 = string.Empty;
                            newData[dataKey].UpdEmployeeCode = string.Empty;
                        }
                    }
                    else
                    {
                            newData.Add(controlKaToDepsitAlwWork.SalesSlipNum, controlKaToDepsitAlwWork);
                    }
                    // --- ADD zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� -------<<<<<

                    // --- DEL zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� ------->>>>> 
                    //ControlKaToDepsitAlwWork controlKaToDepsitAlwWork = new ControlKaToDepsitAlwWork();

                    //�f�[�^���ʎ擾���e�i�[
                    //controlKaToDepsitAlwWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));                  // ����`�[�ԍ�
                    //controlKaToDepsitAlwWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));              // �����S���Җ���
                    //controlKaToDepsitAlwWork.ReconcileDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECONCILEDATERF"));                 // ������
                    //controlKaToDepsitAlwWork.MoneyKindName = moneyKindName;                                                                                 // ���햼��
                    //controlKaToDepsitAlwWork.UpdateDateTime1 = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("BUPDATEDATETIMERF")); // �����X�V����
                    //controlKaToDepsitAlwWork.UpdateDateTime2 = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CUPDATEDATETIMERF")); // �������׍X�V����
                    //controlKaToDepsitAlwWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEDEPOSITRF"));                       // �萔�������z
                    //controlKaToDepsitAlwWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTDEPOSITRF"));             // �l�������z

                    //if (newData.ContainsKey(controlKaToDepsitAlwWork.SalesSlipNum))
                    //{
                    //    string dataKey = controlKaToDepsitAlwWork.SalesSlipNum;
                    //    if (controlKaToDepsitAlwWork.UpdateDateTime1 > newData[dataKey].UpdateDateTime1)
                    //    {
                    //        newData[dataKey].DiscountDeposit = controlKaToDepsitAlwWork.DiscountDeposit;
                    //        newData[dataKey].DepositAgentNm = controlKaToDepsitAlwWork.DepositAgentNm;
                    //        newData[dataKey].FeeDeposit = controlKaToDepsitAlwWork.FeeDeposit;
                    //        newData[dataKey].MoneyKindName = controlKaToDepsitAlwWork.MoneyKindName;
                    //        newData[dataKey].ReconcileDate = controlKaToDepsitAlwWork.ReconcileDate;
                    //        newData[dataKey].SalesSlipNum = controlKaToDepsitAlwWork.SalesSlipNum;
                    //        newData[dataKey].UpdateDateTime1 = controlKaToDepsitAlwWork.UpdateDateTime1;
                    //        newData[dataKey].UpdateDateTime2 = controlKaToDepsitAlwWork.UpdateDateTime2;
                    //    }
                    //}
                    //else
                    //{
                    //        newData.Add(controlKaToDepsitAlwWork.SalesSlipNum, controlKaToDepsitAlwWork);
                    //}
                    // --- DEL zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� -------<<<<<
                    #endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                // --- DEL zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� ------->>>>>
                //foreach (ControlKaToDepsitAlwWork work in newData.Values)
                //{
                //    al.Add(work);
                //}
                // --- DEL zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� -------<<<<<

                // --- ADD zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� ------->>>>>
                foreach (DepositAlwWork work in newData.Values)
                {
                    al.Add(work);
                }
                // --- ADD zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� -------<<<<<

                if (al.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ControlKaToDepsitAlwDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (null != myReader && !myReader.IsClosed)
                {
                    myReader.Close();
                }

                if (null != sqlCommand)
                {
                    sqlCommand.Dispose();
                }
            }

            controlKaToDepsitAlwResultWork = al;

            return status;
        }
        #endregion

        #region MakeWhereString
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="cndtnWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Programmer  : zhujw</br>
        /// <br>Date        : K2014/05/28</br>
        /// </remarks>
        //private string MakeWhereString(ref SqlCommand sqlCommand, ControlKaToDepsitAlwCndtnWork cndtnWork) // DEL zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p����
        private string MakeWhereString(ref SqlCommand sqlCommand, DepositAlwWork cndtnWork) // ADD zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p����
        {
            #region WHERE���쐬
            string[] salesSlipNum = cndtnWork.SalesSlipNum.Split(';');// ADD zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� 
            
            StringBuilder retstring = new StringBuilder(" WHERE ");

            //���������}�X�^.��ƃR�[�h
            retstring.Append(" A.ENTERPRISECODERF=@ENTERPRISECODERF").Append(Environment.NewLine);
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODERF", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

            //���������}�X�^.�ԓ`���E�敪
            retstring.Append(" AND A.DEBITNOTEOFFSETCDRF = 0").Append(Environment.NewLine);

            //���������}�X�^.�_���폜�敪
            retstring.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODERF").Append(Environment.NewLine);
            SqlParameter paraALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODERF", SqlDbType.Int);
            paraALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //���������}�X�^.���Ӑ�R�[�h
            retstring.Append(" AND A.CUSTOMERCODERF=@CUSTOMERCODE").Append(Environment.NewLine);
            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(cndtnWork.CustomerCode);

            //���������}�X�^.�󒍃X�e�[�^�X
            retstring.Append(" AND A.ACPTANODRSTATUSRF=30 ").Append(Environment.NewLine);

            // --- DEL zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� ------->>>>>
            ////���������}�X�^.����`�[�ԍ�
            //if (!string.IsNullOrEmpty(cndtnWork.SalesSlipNumSt))
            //{
            //    retstring.Append(" AND A.SALESSLIPNUMRF>=@SALESSLIPNUMST").Append(Environment.NewLine);
            //    SqlParameter paraSalesSlipNumSt = sqlCommand.Parameters.Add("@SALESSLIPNUMST", SqlDbType.Int);
            //    paraSalesSlipNumSt.Value = SqlDataMediator.SqlSetString(cndtnWork.SalesSlipNumSt);
            //}

            ////���������}�X�^.����`�[�ԍ�
            //if (!string.IsNullOrEmpty(cndtnWork.SalesSlipNumEd))
            //{
            //    retstring.Append(" AND A.SALESSLIPNUMRF<=@SALESSLIPNUMED").Append(Environment.NewLine);
            //    SqlParameter paraSalesSlipNumEd = sqlCommand.Parameters.Add("@SALESSLIPNUMED", SqlDbType.Int);
            //    paraSalesSlipNumEd.Value = SqlDataMediator.SqlSetString(cndtnWork.SalesSlipNumEd);
            //}
            // --- DEL zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� -------<<<<<

            // --- ADD zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� ------->>>>>
            //���������}�X�^.����`�[�ԍ�
            if (!string.IsNullOrEmpty(salesSlipNum[0]))
            {
                retstring.Append(" AND A.SALESSLIPNUMRF>=@SALESSLIPNUMST").Append(Environment.NewLine);
                SqlParameter paraSalesSlipNumSt = sqlCommand.Parameters.Add("@SALESSLIPNUMST", SqlDbType.NChar);
                paraSalesSlipNumSt.Value = SqlDataMediator.SqlSetString(salesSlipNum[0]);
            }

            //���������}�X�^.����`�[�ԍ�
            if (!string.IsNullOrEmpty(salesSlipNum[1]))
            {
                retstring.Append(" AND A.SALESSLIPNUMRF<=@SALESSLIPNUMED").Append(Environment.NewLine);
                SqlParameter paraSalesSlipNumEd = sqlCommand.Parameters.Add("@SALESSLIPNUMED", SqlDbType.NChar);
                paraSalesSlipNumEd.Value = SqlDataMediator.SqlSetString(salesSlipNum[1]);
            }
            // --- ADD zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� -------<<<<<
            #endregion
            return retstring.ToString();
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ����� false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer  : zhujw</br>
        /// <br>Date        : K2014/05/28</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            //SqlConnection����
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            //SqlConnection�ڑ�
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            //SqlConnection�Ԃ�
            return retSqlConnection;
        }
        #endregion  //�R�l�N�V������������
        // --- ADD zhujw K2014/05/28 ���J�g�\�ʑΉ� -------<<<<<

		/// <summary>
		/// ���������폜
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="CustomerCode">���Ӑ�R�[�h</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="SalesSlipNum">����`�[�ԍ�</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�����Ӑ�R�[�h�E�󒍔ԍ��Ɉ������Ă����������MT���폜���A����MT�̈����z�����Z�X�V���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 �R�c ���F ���ʊ�Ή�</br>
        /// </remarks>
        // �� 2008.03.07 980081 c
        //public int DeleteDB(string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo)
        public int DeleteDB(string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum)
        // �� 2008.03.07 980081 c
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			try 
			{	
			�@�@//���[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				//DB�ڑ��E�g�����U�N�V�����J�n
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();
				sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

				// ���������폜����
                // �� 2008.03.07 980081 c
                //status = DeleteDepositAllowanceMain(EnterpriseCode, CustomerCode, AcceptAnOrderNo, ref sqlConnection, ref sqlTransaction);
                status = DeleteDepositAllowanceMain(EnterpriseCode, CustomerCode, AcptAnOdrStatus, SalesSlipNum, ref sqlConnection, ref sqlTransaction);
                // �� 2008.03.07 980081 c

				if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					sqlTransaction.Commit();
				else
					sqlTransaction.Rollback();

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
		/// �����������擾
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="CustomerCode">���Ӑ�R�[�h</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="SalesSlipNum">����`�[�ԍ�</param>
        /// <param name="depositAlwWorkListByte">�����������z��</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�����Ӑ�R�[�h�E�󒍔ԍ��Ɉ������Ă����������MT���擾���Ԃ��܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 �R�c ���F ���ʊ�Ή�</br>
        /// </remarks>
        // �� 2008.03.07 980081 c
        //public int ReadDB(string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, out byte[] depositAlwWorkListByte)
        public int ReadDB(string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum, out byte[] depositAlwWorkListByte)
        // �� 2008.03.07 980081 c
		{
			DepositAlwWork[] depositAlwWorkList = null;

            // �� 2008.03.07 980081 c
            //int status = ReadDB(EnterpriseCode, CustomerCode, AcceptAnOrderNo, out depositAlwWorkList);
            int status = ReadDB(EnterpriseCode, CustomerCode, AcptAnOdrStatus, SalesSlipNum, out depositAlwWorkList);
            // �� 2008.03.07 980081 c

			// XML�֕ϊ����A������̃o�C�i����
			depositAlwWorkListByte = XmlByteSerializer.Serialize(depositAlwWorkList);

			return status;
		}


		/// <summary>
		/// �����������擾
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="CustomerCode">���Ӑ�R�[�h(������R�[�h)</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="SalesSlipNum">����`�[�ԍ�</param>
        /// <param name="depositAlwWorkList">�����������z��</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�����Ӑ�R�[�h�E�󒍔ԍ��Ɉ������Ă����������MT���擾���Ԃ��܂�</br>
		/// <br>           : �����[�g�A�N�Z�X�ȊO�ŁA���ڎQ�ƌďo������ꍇ�͂�������g�p���鎖</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 �R�c ���F ���ʊ�Ή�</br>
        /// </remarks>
        // �� 2008.03.07 980081 c
        //public int ReadDB(string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, out DepositAlwWork[] depositAlwWorkList)
        public int ReadDB(string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum, out DepositAlwWork[] depositAlwWorkList)
        // �� 2008.03.07 980081 c
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;


			depositAlwWorkList = null;

			try 
			{	
			�@�@//���[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				//DB�ڑ��E�g�����U�N�V�����J�n
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();
				sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

				// ���������擾����
                // �� 2008.03.07 980081 c
                //status = ReadDepositAlwWorkRec(EnterpriseCode, CustomerCode, AcceptAnOrderNo, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);
                status = ReadDepositAlwWorkRec(EnterpriseCode, CustomerCode, AcptAnOdrStatus, SalesSlipNum, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);
                // �� 2008.03.07 980081 c

				if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					sqlTransaction.Commit();
				else
					sqlTransaction.Rollback();

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
		/// �����������݃`�F�b�N����(�󒍓`�[�X�V���p)
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="SalesSlipNum">����`�[�ԍ�</param>
        /// <param name="BfCustomerCodeList">�X�V�O���Ӑ�R�[�h�z��</param>
		/// <param name="AfCustomerCodeList">�X�V�㓾�Ӑ�R�[�h�z��</param>
		/// <param name="NgCustomerCodeList">���������链�Ӑ�R�[�h�z��</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �󒍔ԍ��ƍX�V�O������A�X�V�㐿������w�肷�邱�Ƃœ�����������Ă��链�Ӑ�R�[�h��z��ŕԂ��܂�/br>
		///	               : �󒍓`�[�X�V���Ƀ`�F�b�N���āA���������鐿���悪����ꍇ�`�F�b�N�G���[�Ƃ��܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.09.01</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 �R�c ���F ���ʊ�Ή�</br>
        /// </remarks>
        // �� 2008.03.07 980081 c
        //public int CheckDepositAllowance(string EnterpriseCode, int AcceptAnOrderNo, int[] BfCustomerCodeList, int[] AfCustomerCodeList, out int[] NgCustomerCodeList)
        public int CheckDepositAllowance(string EnterpriseCode, int AcptAnOdrStatus, string SalesSlipNum, int[] BfCustomerCodeList, int[] AfCustomerCodeList, out int[] NgCustomerCodeList)
        // �� 2008.03.07 980081 c
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			NgCustomerCodeList = null;

			try 
			{	
			�@�@//���[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				//DB�ڑ��E�g�����U�N�V�����J�n
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();
				sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

				// ���������`�F�b�N����
                // �� 2008.03.07 980081 c
                //status = CheckDepositAllowance(EnterpriseCode, AcceptAnOrderNo, BfCustomerCodeList, AfCustomerCodeList, out NgCustomerCodeList, ref sqlConnection, ref sqlTransaction);
                status = CheckDepositAllowance(EnterpriseCode, AcptAnOdrStatus, SalesSlipNum, BfCustomerCodeList, AfCustomerCodeList, out NgCustomerCodeList, ref sqlConnection, ref sqlTransaction);
                // �� 2008.03.07 980081 c

				if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					sqlTransaction.Commit();
				else
					sqlTransaction.Rollback();

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
		/// ���������`�F�b�N����
		/// </summary>
		/// <param name="mode">�ԍ����������擾�敪 0:�J�E���g���� 1:�J�E���g���Ȃ�</param>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="CustomerCode">���Ӑ�R�[�h</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="SalesSlipNum">����`�[�ԍ�</param>
        /// <param name="count">����������</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�����Ӑ�R�[�h�E�󒍔ԍ��Ɉ������Ă���������������擾���Ԃ��܂�</br>
		///	<br>           : mode��1���w�肷�邱�ƂŁA�ԓ����E���E�ςݍ������ւ̈������𖢃J�E���g�ɂ��邱�Ƃ��ł��܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 �R�c ���F ���ʊ�Ή�</br>
        /// </remarks>
        // �� 2008.03.07 980081 c
        //public int GetCountDB(int mode, string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, out int count)
        public int GetCountDB(int mode, string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum, out int count)
        // �� 2008.03.07 980081 c
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			count = 0;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;
		
			try 
			{	
			�@�@//���[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				//DB�ڑ��E�g�����U�N�V�����J�n
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();
				sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

				// �����������擾����
                // �� 2008.03.07 980081 c
                //status = GetCountDepositAlwWorkRec(mode, EnterpriseCode, CustomerCode, AcceptAnOrderNo, out count, ref sqlConnection, ref sqlTransaction);
                status = GetCountDepositAlwWorkRec(mode, EnterpriseCode, CustomerCode, AcptAnOdrStatus, SalesSlipNum, out count, ref sqlConnection, ref sqlTransaction);
                // �� 2008.03.07 980081 c

				if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					sqlTransaction.Commit();
				else
					sqlTransaction.Rollback();

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
		/// �����������݃`�F�b�N����(�󒍓`�[�X�V���p)
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="SalesSlipNum">����`�[�ԍ�</param>
        /// <param name="BfCustomerCodeList">�X�V�O���Ӑ�R�[�h�z��</param>
		/// <param name="AfCustomerCodeList">�X�V�㓾�Ӑ�R�[�h�z��</param>
		/// <param name="NgCustomerCodeList">���������链�Ӑ�R�[�h�z��</param>
		/// <param name="sqlConnection">�ȸ��ݏ��</param>
		/// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �󒍔ԍ��ƍX�V�O������A�X�V�㐿������w�肷�邱�Ƃœ�����������Ă��链�Ӑ�R�[�h��z��ŕԂ��܂�/br>
		///	               : �󒍓`�[�X�V���Ƀ`�F�b�N���āA���������鐿���悪����ꍇ�`�F�b�N�G���[�Ƃ��܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.09.01</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 �R�c ���F ���ʊ�Ή�</br>
        /// </remarks>
        // �� 2008.03.07 980081 c
        //public int CheckDepositAllowance(string EnterpriseCode, int AcceptAnOrderNo, int[] BfCustomerCodeList, int[] AfCustomerCodeList, out int[] NgCustomerCodeList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        public int CheckDepositAllowance(string EnterpriseCode, int AcptAnOdrStatus, string SalesSlipNum, int[] BfCustomerCodeList, int[] AfCustomerCodeList, out int[] NgCustomerCodeList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        // �� 2008.03.07 980081 c
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			int count = 0;
			ArrayList CustomerCodeList = new ArrayList();
			ArrayList NgCustomerCodeArrayList = new ArrayList();

			bool hitflg;


			// �X�V�O���X�V��ɍ폜����链�Ӑ���m��
			for(int ix=0; ix < BfCustomerCodeList.Length; ix++)
			{
				hitflg = false;

				// �X�V�㓾�Ӑ悪����ꍇ(�`�[�폜�E�ԓ`���s���ȊO)
				if(AfCustomerCodeList != null && AfCustomerCodeList.Length != 0)
				{
					// �X�V�㓾�Ӑ悪���݂��邩�`�F�b�N
					for(int iy = 0; iy < AfCustomerCodeList.Length; iy++)
					{
						if (BfCustomerCodeList[ix] ==  AfCustomerCodeList[iy])
						{
							hitflg = true;
						}
					}
				}

				// �����悪�폜�����ꍇ�A�`�F�b�N�ΏۂƂ���
				if(hitflg == false && BfCustomerCodeList[ix] != 0)
				{
					CustomerCodeList.Add(BfCustomerCodeList[ix]);
				}
			}
	

			try 
			{	

				foreach(int CustomerCode in CustomerCodeList)
				{
					// �����������擾����(�ԁE���E�ςݍ��͖���)
                    // �� 2008.03.07 980081 c
                    //status = GetCountDepositAlwWorkRec(1, EnterpriseCode, CustomerCode, AcceptAnOrderNo, out count, ref sqlConnection, ref sqlTransaction);
                    status = GetCountDepositAlwWorkRec(1, EnterpriseCode, CustomerCode, AcptAnOdrStatus, SalesSlipNum, out count, ref sqlConnection, ref sqlTransaction);
                    // �� 2008.03.07 980081 c

					if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;

					// ����������ꍇ�ARETURN�l�ɓ��Ӑ�R�[�h��ǉ�����
					if (count > 0)
					{
						NgCustomerCodeArrayList.Add(CustomerCode);
					}
				
				}

			}
			catch (SqlException ex) 
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			NgCustomerCodeList = (int[])NgCustomerCodeArrayList.ToArray(typeof(int));

			return status;
		}


		/// <summary>
		/// ���������폜�������C��
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="CustomerCode">���Ӑ�R�[�h</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="SalesSlipNum">����`�[�ԍ�</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
		/// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
		/// <returns></returns>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�����Ӑ�R�[�h�E�󒍔ԍ��Ɉ������Ă����������MT���폜���A����MT�̈����z�����Z�X�V���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 �R�c ���F ���ʊ�Ή�</br>
        /// </remarks>
        // �� 2008.03.07 980081 c
        //public int DeleteDepositAllowanceMain(string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        public int DeleteDepositAllowanceMain(string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        // �� 2008.03.07 980081 c
		{
			//			DepsitMainWork depsitMainWork = null;
			DepositAlwWork[] depositAlwWorkList = null;

			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			// ���������}�X�^�Ǎ���
            // �� 2008.03.07 980081 c
            //status = ReadDepositAlwWorkRec(EnterpriseCode, CustomerCode, AcceptAnOrderNo, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);
            status = ReadDepositAlwWorkRec(EnterpriseCode, CustomerCode, AcptAnOdrStatus, SalesSlipNum, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);
            // �� 2008.03.07 980081 c

			if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{

				// �����������X�V
				for(int ix=0; ix < depositAlwWorkList.Length; ix++)
				{
					DepositAlwWork depositAlwWork = (DepositAlwWork)depositAlwWorkList[ix];

					// �����}�X�^�̈����z�X�V(�����}�X�^�z�����Z�X�V)
					status = UpdateDepsitMainRec(ref depositAlwWork,  ref sqlConnection, ref sqlTransaction);
					if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						return status;
					}

					// �����}�X�^�폜
					status = DeleteDepositAlwWorkRec(depositAlwWork, ref sqlConnection, ref sqlTransaction);
					if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						return status;
					}

				}

			}

			return status;
		}

		/// <summary>
		/// ���������}�X�^�����擾���܂�
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="CustomerCode">���Ӑ�R�[�h(������R�[�h)</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="SalesSlipNum">����`�[�ԍ�</param>
        /// <param name="depositAlwWorkList">�����������</param>
		/// <param name="sqlConnection">�ȸ��ݏ��</param>
		/// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���������}�X�^���𓾈Ӑ�R�[�h�E�󒍔ԍ������Ƀf�[�^�擾���s���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br> 
		/// <br>Date       : 2005.08.18</br>
        /// <br>Update Note: 2007.01.31 18322 T.Kimura MA.NS�p�ɕύX</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 �R�c ���F ���ʊ�Ή�</br>
        /// </remarks>
        // �� 2008.03.07 980081 c
        //public int ReadDepositAlwWorkRec(string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, out DepositAlwWork[] depositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        public int ReadDepositAlwWorkRec(string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum, out DepositAlwWork[] depositAlwWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        // �� 2008.03.07 980081 c
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
	
			SqlDataReader myReader = null;

			ArrayList depositAlwWorkArrayList = new ArrayList();

			try 
			{
                // �� 20070131 18322 c MA.NS�p�ɕύX
                #region SF ���������}�X�^ SELECT��
                ////Select�R�}���h�̐���
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, ADDUPSECCODERF, ACCEPTANORDERNORF, DEPOSITSLIPNORF, DEPOSITKINDCODERF, DEPOSITINPUTDATERF, DEPOSITALLOWANCERF, RECONCILEDATERF, RECONCILEADDUPDATERF, DEBITNOTEOFFSETCDRF, DEPOSITCDRF, CREDITORLOANCDRF "
				//		  +",ACPODRDEPOSITALWCRF, VARCOSTDEPOALWCRF "			// 20060227 Ins
				//		  +"FROM DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO", sqlConnection, sqlTransaction))
                #endregion

                #region MA.NS ���������}�X�^���� SELECT��
                // �� 2008.03.07 980081 d
                //string selectSql = "SELECT CREATEDATETIMERF"
                //                 +       ",UPDATEDATETIMERF"
                //                 +       ",ENTERPRISECODERF"
                //                 +       ",FILEHEADERGUIDRF"
                //                 +       ",UPDEMPLOYEECODERF"
                //                 +       ",UPDASSEMBLYID1RF"
                //                 +       ",UPDASSEMBLYID2RF"
                //                 +       ",LOGICALDELETECODERF"
                //                 +       ",INPUTDEPOSITSECCDRF"
                //                 +       ",ADDUPSECCODERF"
                //                 +       ",RECONCILEDATERF"
                //                 +       ",RECONCILEADDUPDATERF"
                //                 +       ",DEPOSITSLIPNORF"
                //                 +       ",DEPOSITKINDCODERF"
                //                 +       ",DEPOSITKINDNAMERF"
                //                 +       ",DEPOSITALLOWANCERF"
                //                 +       ",DEPOSITAGENTCODERF"
                //                 +       ",DEPOSITAGENTNMRF"
                //                 +       ",CUSTOMERCODERF"
                //                 +       ",CUSTOMERNAMERF"
                //                 +       ",CUSTOMERNAME2RF"
                //                 +       ",ACCEPTANORDERNORF"
                //                 +       ",SERVICESLIPCDRF"
                //                 +       ",DEBITNOTEOFFSETCDRF"
                //                 +       ",DEPOSITCDRF"
                //                 +       ",CREDITORLOANCDRF"
                //                 +  " FROM DEPOSITALWRF"
                //                 + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                //                 +   " AND CUSTOMERCODERF=@FINDCUSTOMERCODE"
                //                 +   " AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO"
                //                 ;
                // �� 2008.03.07 980081 d
                #endregion
                // �� 2008.03.07 980081 a
                string selectSql = "SELECT * FROM DEPOSITALWRF"
                                 + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                                 + " AND CUSTOMERCODERF=@FINDCUSTOMERCODE"
                                 + " AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPNUMRF=@FINDSALESSLIPNUM"
                                 ;
                // �� 2008.03.07 980081 a

                using(SqlCommand sqlCommand = new SqlCommand(selectSql, sqlConnection, sqlTransaction))
                // �� 20070131 18322 c
				{

					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode		= sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    // �� 2008.03.07 980081 c
					//SqlParameter findParaAcceptAnOrderNo	= sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                    SqlParameter findParaAcptAnOdrStatus    = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findParaSalesSlipNum       = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                    // �� 2008.03.07 980081 c
					SqlParameter findParaCustomerCode		= sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value	= SqlDataMediator.SqlSetString(EnterpriseCode);
                    // �� 2008.03.07 980081 c
					//findParaAcceptAnOrderNo.Value	= SqlDataMediator.SqlSetInt32(AcceptAnOrderNo);
                    findParaAcptAnOdrStatus.Value   = SqlDataMediator.SqlSetInt32(AcptAnOdrStatus);
                    findParaSalesSlipNum.Value      = SqlDataMediator.SqlSetString(SalesSlipNum);
                    // �� 2008.03.07 980081 c
					findParaCustomerCode.Value	  	= SqlDataMediator.SqlSetInt32(CustomerCode);

					myReader = sqlCommand.ExecuteReader();
					while(myReader.Read())
					{
						DepositAlwWork depositAlwWork = new DepositAlwWork();

						#region �N���X�֑��
                        // �� 20070131 18322 c MA.NS�p�ɕύX
                        #region SF ���������}�X�^���[�N��SELECT�f�[�^�i�S�ăR�����g�A�E�g�j
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
						//// 20060227 Ins Start >>����p�ʓ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
						//depositAlwWork.AcpOdrDepositAlwc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("ACPODRDEPOSITALWCRF"));
						//depositAlwWork.VarCostDepoAlwc = SqlDataMediator.SqlGetInt64(myReader,myReader.GetOrdinal("VARCOSTDEPOALWCRF"));
						//// 20060227 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        #endregion

                        # region --- DEL 2008/04/25 M.Kubota ---
                        # if false
                        // �쐬����
                        depositAlwWork.CreateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
                        // �X�V����
                        depositAlwWork.UpdateDateTime     = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
                        // ��ƃR�[�h
                        depositAlwWork.EnterpriseCode     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
                        // GUID
                        depositAlwWork.FileHeaderGuid     = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        // �X�V�]�ƈ��R�[�h
                        depositAlwWork.UpdEmployeeCode    = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        // �X�V�A�Z���u��ID1
                        depositAlwWork.UpdAssemblyId1     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        // �X�V�A�Z���u��ID2
                        depositAlwWork.UpdAssemblyId2     = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        // �_���폜�敪
                        depositAlwWork.LogicalDeleteCode  = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
                        // �������͋��_�R�[�h
                        depositAlwWork.InputDepositSecCd  = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
                        // �v�㋒�_�R�[�h
                        depositAlwWork.AddUpSecCode       = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        // �����ݓ�
                        depositAlwWork.ReconcileDate      = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal("RECONCILEDATERF"));
                        // �����݌v���
                        depositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal("RECONCILEADDUPDATERF"));
                        // �����`�[�ԍ�
                        depositAlwWork.DepositSlipNo      = SqlDataMediator.SqlGetInt32 ( myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
                        // ��������R�[�h
                        depositAlwWork.DepositKindCode    = SqlDataMediator.SqlGetInt32 ( myReader, myReader.GetOrdinal("DEPOSITKINDCODERF"));
                        // �������햼��
                        depositAlwWork.DepositKindName    = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal("DEPOSITKINDNAMERF"));
                        // ���������z
                        depositAlwWork.DepositAllowance   = SqlDataMediator.SqlGetInt64 ( myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"));
                        // �����S���҃R�[�h
                        depositAlwWork.DepositAgentCode   = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
                        // �����S���Җ���
                        depositAlwWork.DepositAgentNm     = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
                        // ���Ӑ�R�[�h
                        depositAlwWork.CustomerCode       = SqlDataMediator.SqlGetInt32 ( myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        // ���Ӑ於��
                        depositAlwWork.CustomerName       = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                        // ���Ӑ於��2
                        depositAlwWork.CustomerName2      = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                        // �� 2008.03.07 980081 d
                        //// �󒍔ԍ�
                        //depositAlwWork.AcceptAnOrderNo    = SqlDataMediator.SqlGetInt32 ( myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                        //// �T�[�r�X�`�[�敪
                        //depositAlwWork.ServiceSlipCd      = SqlDataMediator.SqlGetInt32 ( myReader, myReader.GetOrdinal("SERVICESLIPCDRF"));
                        // �� 2008.03.07 980081 d
                        // �ԓ`���E�敪
                        depositAlwWork.DebitNoteOffSetCd  = SqlDataMediator.SqlGetInt32 ( myReader, myReader.GetOrdinal("DEBITNOTEOFFSETCDRF"));
                        // �a����敪
                        depositAlwWork.DepositCd          = SqlDataMediator.SqlGetInt32 ( myReader, myReader.GetOrdinal("DEPOSITCDRF"));
                        // �� 2008.03.07 980081 d
                        //// �N���W�b�g�^���[���敪
                        //depositAlwWork.CreditOrLoanCd     = SqlDataMediator.SqlGetInt32 ( myReader, myReader.GetOrdinal("CREDITORLOANCDRF"));
                        // �� 2008.03.07 980081 d
                        // �� 20070131 18322 c
                        // �� 2008.03.07 980081 a
                        depositAlwWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                        depositAlwWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                        // �� 2008.03.07 980081 a
                        # endif
                        # endregion

                        //--- ADD 2008/04/25 M.Kubota --->>>
                        depositAlwWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        depositAlwWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        depositAlwWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        depositAlwWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        depositAlwWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        depositAlwWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        depositAlwWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        depositAlwWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        depositAlwWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
                        depositAlwWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        depositAlwWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                        depositAlwWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                        depositAlwWork.ReconcileDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RECONCILEDATERF"));
                        depositAlwWork.ReconcileAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RECONCILEADDUPDATERF"));
                        depositAlwWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
                        depositAlwWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"));
                        depositAlwWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
                        depositAlwWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
                        depositAlwWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        depositAlwWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                        depositAlwWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                        depositAlwWork.DebitNoteOffSetCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEOFFSETCDRF"));
                        //--- ADD 2008/04/25 M.Kubota ---<<<
                        #endregion

                        depositAlwWorkArrayList.Add(depositAlwWork);

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
	

			depositAlwWorkList =  (DepositAlwWork[])depositAlwWorkArrayList.ToArray(typeof(DepositAlwWork));

			return status;
		}

        /// <summary>
        /// �������������݂��邩�`�F�b�N���܂�
        /// </summary>
        /// <param name="mode">�ԍ����������擾�敪 0:�J�E���g���� 1:�J�E���g���Ȃ�</param>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="CustomerCode">���Ӑ�R�[�h</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="SalesSlipNum">����`�[�ԍ�</param>
        /// <param name="count">����������</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ����������񐔂𓾈Ӑ�R�[�h�E�󒍔ԍ������Ƀf�[�^�擾���s���܂�</br>
        /// <br>Programmer : 95089 ���i�@��</br>
        /// <br>Date       : 2005.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 �R�c ���F ���ʊ�Ή�</br>
        /// </remarks>
        public int GetCountDepositAlwWorkRec(int mode, string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum, out int count, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.GetCountDepositAlwWorkRecProc(mode, EnterpriseCode, CustomerCode, AcptAnOdrStatus, SalesSlipNum, out count, ref sqlConnection, ref sqlTransaction);
        }

		/// <summary>
		/// �������������݂��邩�`�F�b�N���܂�
		/// </summary>
		/// <param name="mode">�ԍ����������擾�敪 0:�J�E���g���� 1:�J�E���g���Ȃ�</param>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="CustomerCode">���Ӑ�R�[�h</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="SalesSlipNum">����`�[�ԍ�</param>
        /// <param name="count">����������</param>
		/// <param name="sqlConnection">�ȸ��ݏ��</param>
		/// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ����������񐔂𓾈Ӑ�R�[�h�E�󒍔ԍ������Ƀf�[�^�擾���s���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 �R�c ���F ���ʊ�Ή�</br>
        /// </remarks>
        // �� 2008.03.07 980081 c
        //public int GetCountDepositAlwWorkRec(int mode, string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, out int count, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        private int GetCountDepositAlwWorkRecProc(int mode, string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum, out int count, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        // �� 2008.03.07 980081 c
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			count = 0;
	
			SqlDataReader myReader = null;

			ArrayList depositAlwWorkArrayList = new ArrayList();

			try 
			{
                // �� 2008.03.07 980081 c
                //string selectText = "SELECT COUNT(*) FROM DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO";
                //string selectText = "SELECT COUNT(*) FROM DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPNUMRF=@FINDSALESSLIPNUM";  //DEL 2008/04/25 M.Kubota
                string selectText = "SELECT COUNT(DEPOSITALWRF.ENTERPRISECODERF) FROM DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPNUMRF=@FINDSALESSLIPNUM";  //ADD 2008/04/25 M.Kubota
                // �� 2008.03.07 980081 c

				if (mode != 0)
				{
					// �ԓ`�ւ̈����A���E�ςݍ��ւ̈����𖢃J�E���g�Ƃ���
					selectText += " AND DEBITNOTEOFFSETCDRF=0";
				}

				//Select�R�}���h�̐���
				using(SqlCommand sqlCommand = new SqlCommand(selectText, sqlConnection, sqlTransaction))
				{

					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode		= sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    // �� 2008.03.07 980081 c
					//SqlParameter findParaAcceptAnOrderNo	= sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                    SqlParameter findParaAcptAnOdrStatus    = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findParaSalesSlipNum       = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                    // �� 2008.03.07 980081 c
					SqlParameter findParaCustomerCode		= sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value	= SqlDataMediator.SqlSetString(EnterpriseCode);
					// �� 2008.03.07 980081 c
                    //findParaAcceptAnOrderNo.Value	= SqlDataMediator.SqlSetInt32(AcceptAnOrderNo);
                    findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(AcptAnOdrStatus);
                    findParaSalesSlipNum.Value = SqlDataMediator.SqlSetString(SalesSlipNum);
                    // �� 2008.03.07 980081 c
					findParaCustomerCode.Value		= SqlDataMediator.SqlSetInt32(CustomerCode);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						count =SqlDataMediator.SqlGetInt32(myReader, 0);

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

			return status;
		}

		/// <summary>
		/// �����}�X�^�����擾���܂�
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="DepositSlipNo">�����ԍ�</param>
		/// <param name="depsitMainWork">�������</param>
		/// <param name="sqlConnection">�ȸ��ݏ��</param>
		/// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �����}�X�^��������ԍ������Ƀf�[�^�擾���s���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		private int ReadDepsitMainWorkRec(string EnterpriseCode, int DepositSlipNo, out DepsitMainWork depsitMainWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
	
			SqlDataReader myReader = null;

			depsitMainWork = new DepsitMainWork();

			try 
			{
			    // �� 20070131 18322 c MA.NS�p�ɕύX
                #region SF �����}�X�^ SELECT��
				////Select�R�}���h�̐���
				//using(SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DEPOSITDEBITNOTECDRF, DEPOSITSLIPNORF, DEPOSITKINDCODERF, CUSTOMERCODERF, DEPOSITCDRF, DEPOSITTOTALRF, OUTLINERF, ACCEPTANORDERSALESNORF, INPUTDEPOSITSECCDRF, DEPOSITDATERF, ADDUPSECCODERF, ADDUPADATERF, UPDATESECCDRF, DEPOSITKINDNAMERF, DEPOSITALLOWANCERF, DEPOSITALWCBLNCERF, DEPOSITAGENTCODERF, DEPOSITKINDDIVCDRF, FEEDEPOSITRF, DISCOUNTDEPOSITRF, CREDITORLOANCDRF, CREDITCOMPANYCODERF, DEPOSITRF, DRAFTDRAWINGDATERF, DRAFTPAYTIMELIMITRF, DEBITNOTELINKDEPONORF, LASTRECONCILEADDUPDTRF, AUTODEPOSITCDRF "
				//		  +", ACPODRDEPOSITRF, ACPODRCHARGEDEPOSITRF, ACPODRDISDEPOSITRF, VARIOUSCOSTDEPOSITRF, VARCOSTCHARGEDEPOSITRF, VARCOSTDISDEPOSITRF, ACPODRDEPOSITALWCRF, ACPODRDEPOALWCBLNCERF, VARCOSTDEPOALWCRF, VARCOSTDEPOALWCBLNCERF " // ����p�ʓ������ڂ̒ǉ� 20060227 Ins
				//		  +"FROM DEPSITMAINRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO", sqlConnection, sqlTransaction))
                #endregion

                // �� 2008.03.07 980081 c
                #region �����}�X�^ SELECT��(�R�����g�A�E�g)
                //string selectSql = "SELECT CREATEDATETIMERF"
                //                 +       ",UPDATEDATETIMERF"
                //                 +       ",ENTERPRISECODERF"
                //                 +       ",FILEHEADERGUIDRF"
                //                 +       ",UPDEMPLOYEECODERF"
                //                 +       ",UPDASSEMBLYID1RF"
                //                 +       ",UPDASSEMBLYID2RF"
                //                 +       ",LOGICALDELETECODERF"
                //                 +       ",DEPOSITDEBITNOTECDRF"
                //                 +       ",DEPOSITSLIPNORF"
                //                 +       ",ACCEPTANORDERNORF"
                //                 +       ",SERVICESLIPCDRF"
                //                 +       ",INPUTDEPOSITSECCDRF"
                //                 +       ",ADDUPSECCODERF"
                //                 +       ",UPDATESECCDRF"
                //                 +       ",DEPOSITDATERF"
                //                 +       ",ADDUPADATERF"
                //                 +       ",DEPOSITKINDCODERF"
                //                 +       ",DEPOSITKINDNAMERF"
                //                 +       ",DEPOSITKINDDIVCDRF"
                //                 +       ",DEPOSITTOTALRF"
                //                 +       ",DEPOSITRF"
                //                 +       ",FEEDEPOSITRF"
                //                 +       ",DISCOUNTDEPOSITRF"
                //                 +       ",REBATEDEPOSITRF"
                //                 +       ",AUTODEPOSITCDRF"
                //                 +       ",DEPOSITCDRF"
                //                 +       ",CREDITORLOANCDRF"
                //                 +       ",CREDITCOMPANYCODERF"
                //                 +       ",DRAFTDRAWINGDATERF"
                //                 +       ",DRAFTPAYTIMELIMITRF"
                //                 +       ",DEPOSITALLOWANCERF"
                //                 +       ",DEPOSITALWCBLNCERF"
                //                 +       ",DEBITNOTELINKDEPONORF"
                //                 +       ",LASTRECONCILEADDUPDTRF"
                //                 +       ",DEPOSITAGENTCODERF"
                //                 +       ",DEPOSITAGENTNMRF"
                //                 +       ",CUSTOMERCODERF"
                //                 +       ",CUSTOMERNAMERF"
                //                 +       ",CUSTOMERNAME2RF"
                //                 +       ",OUTLINERF"
                //                 +   "FROM DEPSITMAINRF"
                //                 + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                //                 +   " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                //                 ;
                #endregion
                string selectSql = "SELECT * FROM DEPSITMAINRF"
                                 + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                                 + " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                                 ;
                // �� 2008.03.07 980081 c

                using(SqlCommand sqlCommand = new SqlCommand(selectSql, sqlConnection, sqlTransaction))
                // �� 20070131 18322 c
				{

					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(EnterpriseCode);
					findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(DepositSlipNo);

					myReader = sqlCommand.ExecuteReader();
					if(myReader.Read())
					{
						#region �N���X�֑��(�R�����g�A�E�g)
                        # region --- DEL 2008/04/25 M.Kubota ---
                        # if false
                        // �� 20070131 18322 c MA.NS�p�ɕύX
                        #region SF �����}�X�^���[�N��SELECT�f�[�^�i�S�ăR�����g�A�E�g�j
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
						//// 20060227 Ins Start >>>>>>>>>
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
						//// 20060227 Ins End <<<<<<<<<<<
                        #endregion

                        //// �쐬����
                        //depsitMainWork.CreateDateTime        = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
                        //// �X�V����
                        //depsitMainWork.UpdateDateTime        = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
                        //// ��ƃR�[�h
                        //depsitMainWork.EnterpriseCode        = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
                        //// GUID
                        //depsitMainWork.FileHeaderGuid        = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        //// �X�V�]�ƈ��R�[�h
                        //depsitMainWork.UpdEmployeeCode       = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        //// �X�V�A�Z���u��ID1
                        //depsitMainWork.UpdAssemblyId1        = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        //// �X�V�A�Z���u��ID2
                        //depsitMainWork.UpdAssemblyId2        = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        //// �_���폜�敪
                        //depsitMainWork.LogicalDeleteCode     = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
                        //// �����ԍ��敪
                        //depsitMainWork.DepositDebitNoteCd    = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));
                        //// �����`�[�ԍ�
                        //depsitMainWork.DepositSlipNo         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
                        //// �󒍔ԍ�
                        //depsitMainWork.AcceptAnOrderNo       = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                        //// �T�[�r�X�`�[�敪
                        //depsitMainWork.ServiceSlipCd         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SERVICESLIPCDRF"));
                        //// �������͋��_�R�[�h
                        //depsitMainWork.InputDepositSecCd     = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
                        //// �v�㋒�_�R�[�h
                        //depsitMainWork.AddUpSecCode          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        //// �X�V���_�R�[�h
                        //depsitMainWork.UpdateSecCd           = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                        //// �������t
                        //depsitMainWork.DepositDate           = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));
                        //// �v����t
                        //depsitMainWork.AddUpADate            = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                        //// ��������R�[�h
                        //depsitMainWork.DepositKindCode       = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITKINDCODERF"));
                        //// �������햼��
                        //depsitMainWork.DepositKindName       = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITKINDNAMERF"));
                        //// ��������敪
                        //depsitMainWork.DepositKindDivCd      = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITKINDDIVCDRF"));
                        //// �����v
                        //depsitMainWork.DepositTotal          = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITTOTALRF"));
                        //// �������z
                        //depsitMainWork.Deposit               = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
                        //// �萔�������z
                        //depsitMainWork.FeeDeposit            = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEDEPOSITRF"));
                        //// �l�������z
                        //depsitMainWork.DiscountDeposit       = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTDEPOSITRF"));
                        //// ���x�[�g�����z
                        //depsitMainWork.RebateDeposit         = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("REBATEDEPOSITRF"));
                        //// ���������敪
                        //depsitMainWork.AutoDepositCd         = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
                        //// �a����敪
                        //depsitMainWork.DepositCd             = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITCDRF"));
                        //// �N���W�b�g�^���[���敪
                        //depsitMainWork.CreditOrLoanCd        = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITORLOANCDRF"));
                        //// �N���W�b�g��ЃR�[�h
                        //depsitMainWork.CreditCompanyCode     = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CREDITCOMPANYCODERF"));
                        //// ��`�U�o��
                        //depsitMainWork.DraftDrawingDate      = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                        //// ��`�x������
                        //depsitMainWork.DraftPayTimeLimit     = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
                        //// ���������z
                        //depsitMainWork.DepositAllowance      = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"));
                        //// ���������c��
                        //depsitMainWork.DepositAlwcBlnce      = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
                        //// �ԍ������A���ԍ�
                        //depsitMainWork.DebitNoteLinkDepoNo   = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKDEPONORF"));
                        //// �ŏI�������݌v���
                        //depsitMainWork.LastReconcileAddUpDt  = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));
                        //// �����S���҃R�[�h
                        //depsitMainWork.DepositAgentCode      = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
                        //// �����S���Җ���
                        //depsitMainWork.DepositAgentNm        = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
                        //// ���Ӑ�R�[�h
                        //depsitMainWork.CustomerCode          = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        //// ���Ӑ於��
                        //depsitMainWork.CustomerName          = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                        //// ���Ӑ於��2
                        //depsitMainWork.CustomerName2         = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                        //// �`�[�E�v
                        //depsitMainWork.Outline               = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                        //// �� 20070131 18322 c
                        
                        // �� 2008.03.07 980081 a
                        depsitMainWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        depsitMainWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        depsitMainWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        depsitMainWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        depsitMainWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        depsitMainWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        depsitMainWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        depsitMainWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        depsitMainWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                        depsitMainWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));
                        depsitMainWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
                        depsitMainWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                        depsitMainWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));
                        depsitMainWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                        depsitMainWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                        depsitMainWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                        depsitMainWork.MinSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MINSECTIONCODERF"));
                        depsitMainWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));
                        depsitMainWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                        depsitMainWork.DepositKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITKINDCODERF"));
                        depsitMainWork.DepositKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITKINDNAMERF"));
                        depsitMainWork.DepositKindDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITKINDDIVCDRF"));
                        depsitMainWork.DepositTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITTOTALRF"));
                        depsitMainWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
                        depsitMainWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEDEPOSITRF"));
                        depsitMainWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTDEPOSITRF"));
                        depsitMainWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
                        depsitMainWork.DepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITCDRF"));
                        depsitMainWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));
                        depsitMainWork.DraftPayTimeLimit = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTPAYTIMELIMITRF"));
                        depsitMainWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));
                        depsitMainWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));
                        depsitMainWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
                        depsitMainWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));
                        depsitMainWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));
                        depsitMainWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"));
                        depsitMainWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
                        depsitMainWork.DebitNoteLinkDepoNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKDEPONORF"));
                        depsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));
                        depsitMainWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));
                        depsitMainWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
                        depsitMainWork.DepositInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTCDRF"));
                        depsitMainWork.DepositInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTNMRF"));
                        depsitMainWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        depsitMainWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                        depsitMainWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                        depsitMainWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                        depsitMainWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                        depsitMainWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
                        depsitMainWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
                        depsitMainWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
                        depsitMainWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                        depsitMainWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));
                        depsitMainWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));
                        depsitMainWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                        depsitMainWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                        // �� 2008.03.07 980081 a
                        # endif
                        # endregion

                        //--- DEL 2008/04/25 M.Kubota --->>>
                        depsitMainWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));                 // �쐬����
                        depsitMainWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));                 // �X�V����
                        depsitMainWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));                            // ��ƃR�[�h
                        depsitMainWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                              // GUID
                        depsitMainWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));                          // �X�V�]�ƈ��R�[�h
                        depsitMainWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));                            // �X�V�A�Z���u��ID1
                        depsitMainWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));                            // �X�V�A�Z���u��ID2
                        depsitMainWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));                       // �_���폜�敪
                        depsitMainWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));                           // �󒍃X�e�[�^�X
                        depsitMainWork.DepositDebitNoteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));                     // �����ԍ��敪
                        depsitMainWork.DepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));                               // �����`�[�ԍ�
                        depsitMainWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));                                // ����`�[�ԍ�
                        depsitMainWork.InputDepositSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTDEPOSITSECCDRF"));                      // �������͋��_�R�[�h
                        depsitMainWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));                                // �v�㋒�_�R�[�h
                        depsitMainWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));                                  // �X�V���_�R�[�h
                        depsitMainWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));                             // ����R�[�h
                        depsitMainWork.DepositDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));                    // �������t
                        depsitMainWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));                      // �v����t
                        depsitMainWork.DepositTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITTOTALRF"));                                 // �����v
                        depsitMainWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));                                           // �������z
                        depsitMainWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEDEPOSITRF"));                                     // �萔�������z
                        depsitMainWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTDEPOSITRF"));                           // �l�������z
                        depsitMainWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));                               // ���������敪
                        depsitMainWork.DraftDrawingDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DRAFTDRAWINGDATERF"));          // ��`�U�o��
                        depsitMainWork.DraftKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTKINDRF"));                                       // ��`���
                        depsitMainWork.DraftKindName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTKINDNAMERF"));                              // ��`��ޖ���
                        depsitMainWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));                                   // ��`�敪
                        depsitMainWork.DraftDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTDIVIDENAMERF"));                          // ��`�敪����
                        depsitMainWork.DraftNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DRAFTNORF"));                                          // ��`�ԍ�
                        depsitMainWork.DepositAllowance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCERF"));                         // ���������z
                        depsitMainWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));                         // ���������c��
                        depsitMainWork.DebitNoteLinkDepoNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTELINKDEPONORF"));                   // �ԍ������A���ԍ�
                        depsitMainWork.LastReconcileAddUpDt = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTRECONCILEADDUPDTRF"));  // �ŏI�������݌v���
                        depsitMainWork.DepositAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTCODERF"));                        // �����S���҃R�[�h
                        depsitMainWork.DepositAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));                            // �����S���Җ���
                        depsitMainWork.DepositInputAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTCDRF"));                  // �������͎҃R�[�h
                        depsitMainWork.DepositInputAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTNMRF"));                  // �������͎Җ���
                        depsitMainWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));                                 // ���Ӑ�R�[�h
                        depsitMainWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));                                // ���Ӑ於��
                        depsitMainWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));                              // ���Ӑ於��2
                        depsitMainWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));                                  // ���Ӑ旪��
                        depsitMainWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));                                       // ������R�[�h
                        depsitMainWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));                                      // �����於��
                        depsitMainWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));                                    // �����於��2
                        depsitMainWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));                                        // �����旪��
                        depsitMainWork.Outline = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));                                          // �`�[�E�v
                        depsitMainWork.BankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BANKCODERF"));                                         // ��s�R�[�h
                        depsitMainWork.BankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BANKNAMERF"));                                        // ��s����
                        //--- ADD 2008/04/25 M.Kubota --->>>
                        # endregion
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
		/// <br>Date       : 2005.08.18</br>
		/// </remarks>
		private int DeleteDepositAlwWorkRec(DepositAlwWork depositAlwWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			SqlDataReader myReader = null;

			//Select�R�}���h�̐���
			try			
			{
                // �� 2008.03.07 980081 c
                //using (SqlCommand sqlCommand = new SqlCommand("DELETE DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ACCEPTANORDERNORF=@FINDACCEPTANORDERNO AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO AND RECONCILEADDUPDATERF=@FINDRECONCILEADDUPDATE", sqlConnection, sqlTransaction))
                using (SqlCommand sqlCommand = new SqlCommand("DELETE DEPOSITALWRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPNUMRF=@FINDSALESSLIPNUM AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO AND RECONCILEADDUPDATERF=@FINDRECONCILEADDUPDATE", sqlConnection, sqlTransaction))
                // �� 2008.03.07 980081 c
				{

					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    // �� 2008.03.07 980081 c
					//SqlParameter findParaAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                    SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findParaSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                    // �� 2008.03.07 980081 c
					SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
					SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);
					SqlParameter findParaReconcileAddUpDate = sqlCommand.Parameters.Add("@FINDRECONCILEADDUPDATE", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
					// �� 2008.03.07 980081 c
                    //findParaAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
                    findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcptAnOdrStatus);
                    findParaSalesSlipNum.Value = SqlDataMediator.SqlSetString(depositAlwWork.SalesSlipNum);
                    // �� 2008.03.07 980081 c
					findParaCustomerCode.Value  = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
					findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
					findParaReconcileAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileAddUpDate);

					int count = sqlCommand.ExecuteNonQuery();

					// �X�V�����������ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					if(count == 0)
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
				if(myReader != null && !myReader.IsClosed)myReader.Close();
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader != null && !myReader.IsClosed)myReader.Close();

			return status;
		}

		/// <summary>
		/// �����}�X�^���̈����z�����Z�E�X�V���܂�
		/// </summary>
		/// <param name="depositAlwWork">���Z��������������</param>
		/// <param name="sqlConnection">�ȸ��ݏ��</param>
		/// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �����œn���ꂽ�����������ɊY����������}�X�^�ɑ΂��Ĉ����z�����Z���čX�V���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.18</br>
		/// </remarks>
		private int UpdateDepsitMainRec(ref DepositAlwWork depositAlwWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			SqlDataReader myReader = null;

			// Update�R�}���h�̐���
			try			
			{
                // �� 20070131 18322 c MA.NS�p�ɕύX
                #region SF�����z�̍��z�X�V�Ɣ���󒍔ԍ��̏����i�S�ăR�����g�A�E�g�j
                //// �������z�̍��z�X�V�Ɣ���󒍔ԍ��̏������s��(�a����E���������̈������͎󒍔ԍ��������Ă����)
				//string updateText = "UPDATE DEPSITMAINRF SET UPDATEDATETIMERF=@UPDATEDATETIME, UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2,  ACCEPTANORDERSALESNORF=0, DEPOSITALLOWANCERF=DEPOSITALLOWANCERF - @DF_DEPOSITALLOWANCE, DEPOSITALWCBLNCERF=DEPOSITALWCBLNCERF + @DF_DEPOSITALLOWANCE "
				//	+",ACPODRDEPOSITALWCRF=ACPODRDEPOSITALWCRF - @DF_ACPODRDEPOSITALWC, ACPODRDEPOALWCBLNCERF=ACPODRDEPOALWCBLNCERF + @DF_ACPODRDEPOSITALWC "	// 20060227 Ins �󒍈���
				//	+",VARCOSTDEPOALWCRF=VARCOSTDEPOALWCRF - @DF_VARCOSTDEPOALWC, VARCOSTDEPOALWCBLNCERF=VARCOSTDEPOALWCBLNCERF + @DF_VARCOSTDEPOALWC "			// 20060227 Ins ����p����
				//	+"WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO";
                #endregion

                // �� �����z�̍��z�X�V
                string updateText = "UPDATE DEPSITMAINRF"
                                  +   " SET UPDATEDATETIMERF=@UPDATEDATETIME"
                                  +       ",UPDEMPLOYEECODERF=@UPDEMPLOYEECODE"
                                  +       ",UPDASSEMBLYID1RF=@UPDASSEMBLYID1"
                                  +       ",UPDASSEMBLYID2RF=@UPDASSEMBLYID2"
                                  +       ",DEPOSITALLOWANCERF=DEPOSITALLOWANCERF - @DF_DEPOSITALLOWANCE"
                                  +       ",DEPOSITALWCBLNCERF=DEPOSITALWCBLNCERF + @DF_DEPOSITALLOWANCE"
                                  + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE"
                                  +   " AND DEPOSITSLIPNORF=@FINDDEPOSITSLIPNO"
                                  ; 
                // �� 20070131 18322 c
				using(SqlCommand sqlCommand = new SqlCommand(updateText, sqlConnection,sqlTransaction))
				{
					//Prameter�I�u�W�F�N�g�̍쐬
					SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					SqlParameter findParaDepositSlipNo = sqlCommand.Parameters.Add("@FINDDEPOSITSLIPNO", SqlDbType.Int);

					//Parameter�I�u�W�F�N�g�֒l�ݒ�
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
					findParaDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);

					#region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
					//Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
					SqlParameter paraUpdateDateTime			= sqlCommand.Parameters.Add("@UPDATEDATETIME",			SqlDbType.BigInt);	// �X�V��
					SqlParameter paraUpdEmployeeCode		= sqlCommand.Parameters.Add("@UPDEMPLOYEECODE",			SqlDbType.NChar);
					SqlParameter paraUpdAssemblyId1			= sqlCommand.Parameters.Add("@UPDASSEMBLYID1",			SqlDbType.NVarChar);
					SqlParameter paraUpdAssemblyId2			= sqlCommand.Parameters.Add("@UPDASSEMBLYID2",			SqlDbType.NVarChar);

					SqlParameter paraDF_DepositAllowance	= sqlCommand.Parameters.Add("@DF_DEPOSITALLOWANCE",		SqlDbType.BigInt);	// �������z
                    // �� 20070131 18322 c MA.NS�p�ɕύX
					//// 20020627 Ins Start >> ����p�ʓ����Ή�>>>>>>>>>>>>
					//SqlParameter paraDF_AcpOdrDepositAlwc	= sqlCommand.Parameters.Add("@DF_ACPODRDEPOSITALWC",	SqlDbType.BigInt);	// �󒍈������z
					//SqlParameter paraDF_VarCostDepoAlwc		= sqlCommand.Parameters.Add("@DF_VARCOSTDEPOALWC",		SqlDbType.BigInt);	// ����p�������z
					//// 20020627 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    //�@��20070131 18322 c

					#endregion

					#region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)

					// ���X�V�w�b�_����ݒ� 
					object obj = (object)this;
					FileHeader fileHeader = new FileHeader(obj);
					paraUpdateDateTime.Value		= SqlDataMediator.SqlSetDateTimeFromTicks(fileHeader.NewFileHeaderDateTime());			// �X�V��
					paraUpdEmployeeCode.Value		= SqlDataMediator.SqlSetString(fileHeader.UpdEmployeeCode);								// �X�V�]�ƈ��R�[�h
					paraUpdAssemblyId1.Value		= SqlDataMediator.SqlSetString(fileHeader.UpdAssemblyId1);								// �X�V�A�Z���u��ID1
					paraUpdAssemblyId2.Value		= SqlDataMediator.SqlSetString(fileHeader.GetUpdAssemblyID(this));						// �X�V�A�Z���u��ID2

					// ���ύX����ݒ� 
					// �������z
					paraDF_DepositAllowance.Value	= SqlDataMediator.SqlSetInt64(depositAlwWork.DepositAllowance);	// �������z

                    // �� 20070131 18322 c MA.NS�p�ɕύX
					//// 20020620 Ins Start >> ����p�ʓ����Ή�>>>>>>>>>>>>
					//paraDF_AcpOdrDepositAlwc.Value	= SqlDataMediator.SqlSetInt64(depositAlwWork.AcpOdrDepositAlwc);// �󒍈������z
					//paraDF_VarCostDepoAlwc.Value	= SqlDataMediator.SqlSetInt64(depositAlwWork.VarCostDepoAlwc);	// ����p�������z
					///// 20020620 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    // ��20070131 18322 c
					#endregion

					int count = sqlCommand.ExecuteNonQuery();

					// �X�V�����������ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					if(count == 0)
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
				if(myReader != null && !myReader.IsClosed)myReader.Close();
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader != null && !myReader.IsClosed)myReader.Close();

			return status;
		}


		/// <summary>
		/// ���ԓ`�쐬�����������ԍ쐬����
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="CustomerCode">���Ӑ�R�[�h</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="SalesSlipNum">����`�[�ԍ�</param>
        /// <param name="depositAgentCode">�����S���҃R�[�h</param>
		/// <param name="depositAgentNm">�����S���Җ�</param>
		/// <param name="akaAddUpADate">�ԓ`�v���</param>
        /// <param name="NewSalesSlipNum">�ԓ`����`�[�ԍ�</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�����Ӑ�R�[�h�E�󒍔ԍ��Ɉ������Ă����������MT����Ԏ󒍂ɑ΂���Ԉ����쐬���A����MT�̈����z�����Z�X�V���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2006.03.07</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 �R�c ���F ���ʊ�Ή�</br>
        /// </remarks>
        // �� 2008.03.07 980081 c
		// �� 20070131 18322 c MA.NS�p�ɕύX
        ////public int CreateRedDepositAllowance(string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, int NewAcceptAnOrderNo)
		//public int CreateRedDepositAllowance( string   EnterpriseCode
        //                                    , int      CustomerCode
        //                                    , int      AcceptAnOrderNo
        //                                    , string   depositAgentCode
        //                                    , string   depositAgentNm
        //                                    , DateTime akaAddUpADate
        //                                    , int      NewAcceptAnOrderNo)
        //// �� 20070131 18322 c
		public int CreateRedDepositAllowance( string   EnterpriseCode
                                            , int      CustomerCode
                                            , int      AcptAnOdrStatus
                                            , string   SalesSlipNum
                                            , string   depositAgentCode
                                            , string   depositAgentNm
                                            , DateTime akaAddUpADate
                                            , string   NewSalesSlipNum)
        // �� 2008.03.07 980081 c
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			try 
			{	
			�@�@//���[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				//DB�ڑ��E�g�����U�N�V�����J�n
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();
				sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // �� 2008.03.07 980081 c
                //// �� 20070131 18322 c MA.NS�p�ɕύX
				////// ���ԓ`�쐬�����������ԍ쐬����
				////status = CreateRedDepositAllowanceMain(EnterpriseCode, CustomerCode, AcceptAnOrderNo, NewAcceptAnOrderNo, ref sqlConnection,ref sqlTransaction);
				//// ���ԓ`�쐬�����������ԍ쐬����
				//status = CreateRedDepositAllowanceMain( EnterpriseCode
                //                                      , CustomerCode
                //                                      , AcceptAnOrderNo
                //                                      , depositAgentCode
                //                                      , depositAgentNm
                //                                      , akaAddUpADate
                //                                      , NewAcceptAnOrderNo
                //                                      , ref sqlConnection
                //                                      , ref sqlTransaction);
                //// �� 20070131 18322 c
                status = CreateRedDepositAllowanceMain(EnterpriseCode
                                                      , CustomerCode
                                                      , AcptAnOdrStatus
                                                      , SalesSlipNum
                                                      , depositAgentCode
                                                      , depositAgentNm
                                                      , akaAddUpADate
                                                      , NewSalesSlipNum
                                                      , ref sqlConnection
                                                      , ref sqlTransaction);
                // �� 2008.03.07 980081 c

				if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					sqlTransaction.Commit();
				else
					sqlTransaction.Rollback();

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
		/// ���ԓ`�쐬�����������ԍ쐬�������C��
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="CustomerCode">���Ӑ�R�[�h</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="SalesSlipNum">����`�[�ԍ�</param>
        /// <param name="depositAgentCode">�����S���҃R�[�h</param>
        /// <param name="depositAgentNm">�����S���Җ�</param>
        /// <param name="akaAddUpADate">�ԓ`�v���</param>
        /// <param name="NewSalesSlipNum">�ԓ`����`�[�ԍ�</param>
        /// <param name="sqlConnection">�ȸ��ݏ��</param>
		/// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
		/// <returns></returns>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�����Ӑ�R�[�h�E�󒍔ԍ��Ɉ������Ă����������MT����Ԏ󒍂ɑ΂���Ԉ����쐬���A����MT�̈����z�����Z�X�V���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2006.03.07</br>
        /// <br>Update Note: 2007.01.31 18322 c MA.NS�p�ɕύX</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 �R�c ���F ���ʊ�Ή�</br>
        /// </remarks>
        // �� 2008.03.07 980081 c
		//// �� 20070131 18322 c
        ////public int CreateRedDepositAllowanceMain(string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, int NewAcceptAnOrderNo, ref SqlConnection sqlConnection,ref SqlTransaction sqlTransaction)
        //
        //public int CreateRedDepositAllowanceMain(     string         EnterpriseCode
        //                                        ,     int            CustomerCode
        //                                        ,     int            AcceptAnOrderNo
        //                                        ,     string         depositAgentCode
        //                                        ,     string         depositAgentNm
        //                                        ,     DateTime       akaAddUpADate
        //                                        ,     int            NewAcceptAnOrderNo
        //                                        , ref SqlConnection  sqlConnection
        //                                        , ref SqlTransaction sqlTransaction)
        //// ��
        public int CreateRedDepositAllowanceMain(     string         EnterpriseCode
                                                ,     int            CustomerCode
                                                ,     int            AcptAnOdrStatus
                                                ,     string         SalesSlipNum
                                                ,     string         depositAgentCode
                                                ,     string         depositAgentNm
                                                ,     DateTime       akaAddUpADate
                                                ,     string         NewSalesSlipNum
                                                , ref SqlConnection sqlConnection
                                                , ref SqlTransaction sqlTransaction)
        // �� 2008.03.07 980081 c
		{
			//			DepsitMainWork depsitMainWork = null;
			DepositAlwWork[] depositAlwWorkList = null;

			DepositAlwWork Red_depositAlwWork;

			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			// ���������}�X�^�Ǎ���
            // �� 2008.03.07 980081 c
            //status = ReadDepositAlwWorkRec(EnterpriseCode, CustomerCode, AcceptAnOrderNo, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);
            status = ReadDepositAlwWorkRec(EnterpriseCode, CustomerCode, AcptAnOdrStatus, SalesSlipNum, out depositAlwWorkList, ref sqlConnection, ref sqlTransaction);
            // �� 2008.03.07 980081 c

			if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{

				// �����������X�V
				for(int ix=0; ix < depositAlwWorkList.Length; ix++)
				{
					DepositAlwWork depositAlwWork = (DepositAlwWork)depositAlwWorkList[ix];

					// �����}�X�^�̈����z�X�V(�����}�X�^�z�����Z�X�V)
					status = UpdateDepsitMainRec(ref depositAlwWork,  ref sqlConnection, ref sqlTransaction);
					if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						return status;
					}

                    // �� 2008.03.07 980081 c
                    //// �� 20070131 18322 c MA.NS�p�ɕύX
                    ////// �������������f�[�^�����ɐԓ����������쐬
					////Red_depositAlwWork = CreateRedDepositAlwWork(NewAcceptAnOrderNo, depositAlwWork);
                    //// �������������f�[�^�����ɐԓ����������쐬
                    //Red_depositAlwWork = CreateRedDepositAlwWork( NewAcceptAnOrderNo
                    //                                            , depositAgentCode
                    //                                            , depositAgentNm
                    //                                            , akaAddUpADate
                    //                                            , depositAlwWork
                    //                                            );
                    //// �� 20070131 18322 c
                    Red_depositAlwWork = CreateRedDepositAlwWork( AcptAnOdrStatus
                                                                , NewSalesSlipNum
                                                                , depositAgentCode
                                                                , depositAgentNm
                                                                , akaAddUpADate
                                                                , depositAlwWork
                                                                );
                    // �� 2008.03.07 980081 c

					// �����}�X�^�ԍ쐬
					status = InsertDepositAlwWorkRec(ref Red_depositAlwWork, ref sqlConnection, ref sqlTransaction);
					if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						return status;
					}

				}

			}

			return status;
		}

		/// <summary>
		/// �ԓ���������񐶐�����
		/// </summary>
        /// <param name="NewAcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="NewSalesSlipNum">����`�[�ԍ�</param>
        /// <param name="depositAgentCode">�����S���҃R�[�h</param>
        /// <param name="depositAgentNm">�����S���Җ�</param>
        /// <param name="akaAddUpADate">�ԓ`�v���</param>
		/// <param name="depositAlwWork">���������������</param>
		/// <returns>�ԓ����������</returns>
		/// <remarks>
		/// <br>Note       : ���������}�X�^��񂩂�Ԉ��������쐬���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2006.03.07</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 �R�c ���F ���ʊ�Ή�</br>
        /// </remarks>
        // �� 2008.03.07 980081 c
        //// �� 20070131 18322 c MA.NS�p�ɕύX 
		////private DepositAlwWork CreateRedDepositAlwWork(int NewAcceptAnOrderNo, DepositAlwWork depositAlwWork)
		//private DepositAlwWork CreateRedDepositAlwWork( int            NewAcceptAnOrderNo
        //                                              , string         depositAgentCode
        //                                              , string         depositAgentNm
        //                                              , DateTime       akaAddUpADate
        //                                              , DepositAlwWork depositAlwWork)
        //// �� 20070131 18322 c
		private DepositAlwWork CreateRedDepositAlwWork( int            NewAcptAnOdrStatus
                                                      , string         NewSalesSlipNum
                                                      , string         depositAgentCode
                                                      , string         depositAgentNm
                                                      , DateTime       akaAddUpADate
                                                      , DepositAlwWork depositAlwWork)
        // �� 2008.03.07 980081 c
		{
			DepositAlwWork newDepositAlwWork = new DepositAlwWork();

            # region --- DEL 2008/04/25 M.Kubota ---
            # if false
            // �� 20070131 18322 c MA.NS�p�ɕύX
            #region SF �Ԉ������쐬�i�S�ăR�����g�A�E�g�j
            ////				newDepositAlwWork.CreateDateTime = depositAlwWorkList.CreateDateTime;
			////				newDepositAlwWork.UpdateDateTime = depositAlwWorkList.UpdateDateTime;
			//newDepositAlwWork.EnterpriseCode = depositAlwWork.EnterpriseCode;
			////				newDepositAlwWork.FileHeaderGuid = depositAlwWorkList.FileHeaderGuid;
			////newDepositAlwWork.UpdEmployeeCode = UpdateSecCd;											// �X�V�]�ƈ��R�[�h<-�����S���҃R�[�h ???
			////				newDepositAlwWork.UpdAssemblyId1 = depositAlwWorkList.UpdAssemblyId1;
			////				newDepositAlwWork.UpdAssemblyId2 = depositAlwWorkList.UpdAssemblyId2;
			//newDepositAlwWork.LogicalDeleteCode = 0;
			//newDepositAlwWork.CustomerCode = depositAlwWork.CustomerCode;
			//newDepositAlwWork.AddUpSecCode = depositAlwWork.AddUpSecCode;
			//newDepositAlwWork.AcceptAnOrderNo = NewAcceptAnOrderNo;										// �󒍔ԍ����Ԏ󒍔ԍ�
			//newDepositAlwWork.DepositSlipNo = depositAlwWork.DepositSlipNo;								// �����`�[�ԍ�
			//newDepositAlwWork.DepositKindCode = depositAlwWork.DepositKindCode;
			//newDepositAlwWork.DepositInputDate = depositAlwWork.DepositInputDate;						// �������͓��t
			//newDepositAlwWork.DepositAllowance = depositAlwWork.DepositAllowance * -1;					// �����z
			//newDepositAlwWork.ReconcileDate = DateTime.Now;												// �����ݓ����V�X�e�����t
			//newDepositAlwWork.ReconcileAddUpDate = depositAlwWork.DepositInputDate;						// �����݌v����������v���
			//newDepositAlwWork.DebitNoteOffSetCd = depositAlwWork.DebitNoteOffSetCd;						// �ԓ`���E�敪
			//newDepositAlwWork.DepositCd = depositAlwWork.DepositCd;										// �a����敪���p�����[�^�l
			//newDepositAlwWork.CreditOrLoanCd = depositAlwWork.CreditOrLoanCd;
			//// 20060220 Ins Start >>����p�ʓ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			//newDepositAlwWork.AcpOdrDepositAlwc = depositAlwWork.AcpOdrDepositAlwc * -1;				// �󒍈����z
			//newDepositAlwWork.VarCostDepoAlwc	= depositAlwWork.VarCostDepoAlwc * -1;					// ����p�����z
			//// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            #endregion

            // ��ƃR�[�h
            newDepositAlwWork.EnterpriseCode      = depositAlwWork.EnterpriseCode;
            // �_���폜�敪
            newDepositAlwWork.LogicalDeleteCode   = 0;
            
            // �������͋��_�R�[�h
            newDepositAlwWork.InputDepositSecCd   = depositAlwWork.InputDepositSecCd ;
            // �v�㋒�_�R�[�h
            newDepositAlwWork.AddUpSecCode        = depositAlwWork.AddUpSecCode      ;
            // �����ݓ�
            newDepositAlwWork.ReconcileDate       = DateTime.Now                     ;
            // �����݌v���(�ԓ`�v���)
            newDepositAlwWork.ReconcileAddUpDate = akaAddUpADate;
            // �����`�[�ԍ�
            newDepositAlwWork.DepositSlipNo       = depositAlwWork.DepositSlipNo     ;
            // ��������R�[�h
            newDepositAlwWork.DepositKindCode     = depositAlwWork.DepositKindCode   ;
            // �������햼��
            newDepositAlwWork.DepositKindName     = depositAlwWork.DepositKindName   ;
            // ���������z
            newDepositAlwWork.DepositAllowance    = depositAlwWork.DepositAllowance * -1;
            // �����S���҃R�[�h
            newDepositAlwWork.DepositAgentCode    = depositAgentCode  ;
            // �����S���Җ���
            newDepositAlwWork.DepositAgentNm      = depositAgentNm    ;
            // ���Ӑ�R�[�h
            newDepositAlwWork.CustomerCode        = depositAlwWork.CustomerCode      ;
            // ���Ӑ於��
            newDepositAlwWork.CustomerName        = depositAlwWork.CustomerName      ;
            // ���Ӑ於��2
            newDepositAlwWork.CustomerName2       = depositAlwWork.CustomerName2     ;
            // �� 2008.03.07 980081 d
            //// �󒍔ԍ�
            //newDepositAlwWork.AcceptAnOrderNo     = depositAlwWork.AcceptAnOrderNo   ;
            //// �T�[�r�X�`�[�敪
            //newDepositAlwWork.ServiceSlipCd       = depositAlwWork.ServiceSlipCd   ;
            // �� 2008.03.07 980081 d
            // �ԓ`���E�敪
            newDepositAlwWork.DebitNoteOffSetCd   = depositAlwWork.DebitNoteOffSetCd ;
            // �a����敪
            newDepositAlwWork.DepositCd           = depositAlwWork.DepositCd         ;
            // �� 2008.03.07 980081 d
            //// �N���W�b�g�^���[���敪
            //newDepositAlwWork.CreditOrLoanCd      = depositAlwWork.CreditOrLoanCd    ;
            // �� 2008.03.07 980081 d
            // �� 20070131 18322 c
            // �� 2008.03.07 980081 a
            newDepositAlwWork.AcptAnOdrStatus = depositAlwWork.AcptAnOdrStatus;
            newDepositAlwWork.SalesSlipNum    = NewSalesSlipNum;
            // �� 2008.03.07 980081 a
            # endif
            # endregion

            //--- ADD 2008/04/25 M.Kubota --->>>
            newDepositAlwWork.EnterpriseCode = depositAlwWork.EnterpriseCode;
            newDepositAlwWork.LogicalDeleteCode = 0;
            newDepositAlwWork.InputDepositSecCd = depositAlwWork.InputDepositSecCd;
            newDepositAlwWork.AddUpSecCode = depositAlwWork.AddUpSecCode;
            newDepositAlwWork.AcptAnOdrStatus = depositAlwWork.AcptAnOdrStatus;
            newDepositAlwWork.SalesSlipNum = NewSalesSlipNum;
            newDepositAlwWork.ReconcileDate = DateTime.Now;
            newDepositAlwWork.ReconcileAddUpDate = akaAddUpADate;
            newDepositAlwWork.DepositSlipNo = depositAlwWork.DepositSlipNo;
            newDepositAlwWork.DepositAllowance = depositAlwWork.DepositAllowance * -1;
            newDepositAlwWork.DepositAgentCode = depositAgentCode;
            newDepositAlwWork.DepositAgentNm = depositAgentNm;
            newDepositAlwWork.CustomerCode = depositAlwWork.CustomerCode;
            newDepositAlwWork.CustomerName = depositAlwWork.CustomerName;
            newDepositAlwWork.CustomerName2 = depositAlwWork.CustomerName2;
            newDepositAlwWork.DebitNoteOffSetCd = depositAlwWork.DebitNoteOffSetCd;
            //--- ADD 2008/04/25 M.Kubota ---<<<

			return newDepositAlwWork;
		}

		/// <summary>
		/// ���������}�X�^�����X�V���܂�
		/// ������̐ԓ`�쐬���A�{���`�̓��������ɑ΂���Ԉ����i�}�C�i�X�����j��ԓ`�ɑ΂��č쐬���܂��B
		/// </summary>
		/// <param name="depositAlwWork">�����������</param>
		/// <param name="sqlConnection">�ȸ��ݏ��</param>
		/// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���������}�X�^���̍X�V���s���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2006.03.07</br>
		/// </remarks>
		private int InsertDepositAlwWorkRec(ref DepositAlwWork depositAlwWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			SqlDataReader myReader = null;

			//Select�R�}���h�̐���
			try			
			{
                // �� 20070131 18322 c MA.NS�p�ɕύX
                #region SF ���������}�X�^ INSERT���i�R�����g�A�E�g�j
                ////�V�K�쐬����SQL���𐶐�
				//string insertText = "INSERT INTO DEPOSITALWRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CUSTOMERCODERF, ADDUPSECCODERF, ACCEPTANORDERNORF, DEPOSITSLIPNORF, DEPOSITKINDCODERF, DEPOSITINPUTDATERF, DEPOSITALLOWANCERF, RECONCILEDATERF, RECONCILEADDUPDATERF, DEBITNOTEOFFSETCDRF, DEPOSITCDRF, CREDITORLOANCDRF "
				//					+", ACPODRDEPOSITALWCRF, VARCOSTDEPOALWCRF "	
				//					+") VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @CUSTOMERCODE, @ADDUPSECCODE, @ACCEPTANORDERNO, @DEPOSITSLIPNO, @DEPOSITKINDCODE, @DEPOSITINPUTDATE, @DEPOSITALLOWANCE, @RECONCILEDATE, @RECONCILEADDUPDATE, @DEBITNOTEOFFSETCD, @DEPOSITCD, @CREDITORLOANCD"
				//					+", @ACPODRDEPOSITALWC, @VARCOSTDEPOALWC"		
				//					+")";
                #endregion

                #region MA.NS ���������}�X�^ INSERT��(�R�����g�A�E�g)
                //string insertText = "INSERT INTO DEPOSITALWRF("
                //                  +                  " CREATEDATETIMERF"
                //                  +                  ",UPDATEDATETIMERF"
                //                  +                  ",ENTERPRISECODERF"
                //                  +                  ",FILEHEADERGUIDRF"
                //                  +                  ",UPDEMPLOYEECODERF"
                //                  +                  ",UPDASSEMBLYID1RF"
                //                  +                  ",UPDASSEMBLYID2RF"
                //                  +                  ",LOGICALDELETECODERF"
                //                  +                  ",INPUTDEPOSITSECCDRF"
                //                  +                  ",ADDUPSECCODERF"
                //                  +                  ",RECONCILEDATERF"
                //                  +                  ",RECONCILEADDUPDATERF"
                //                  +                  ",DEPOSITSLIPNORF"
                //                  +                  ",DEPOSITKINDCODERF"
                //                  +                  ",DEPOSITKINDNAMERF"
                //                  +                  ",DEPOSITALLOWANCERF"
                //                  +                  ",DEPOSITAGENTCODERF"
                //                  +                  ",DEPOSITAGENTNMRF"
                //                  +                  ",CUSTOMERCODERF"
                //                  +                  ",CUSTOMERNAMERF"
                //                  +                  ",CUSTOMERNAME2RF"
                //                  +                  ",ACCEPTANORDERNORF"
                //                  +                  ",SERVICESLIPCDRF"
                //                  +                  ",DEBITNOTEOFFSETCDRF"
                //                  +                  ",DEPOSITCDRF"
                //                  +                  ",CREDITORLOANCDRF"
                //                  +         ") VALUES ("
                //                  +                  " @CREATEDATETIME"
                //                  +                  ",@UPDATEDATETIME"
                //                  +                  ",@ENTERPRISECODE"
                //                  +                  ",@FILEHEADERGUID"
                //                  +                  ",@UPDEMPLOYEECODE"
                //                  +                  ",@UPDASSEMBLYID1"
                //                  +                  ",@UPDASSEMBLYID2"
                //                  +                  ",@LOGICALDELETECODE"
                //                  +                  ",@INPUTDEPOSITSECCD"
                //                  +                  ",@ADDUPSECCODE"
                //                  +                  ",@RECONCILEDATE"
                //                  +                  ",@RECONCILEADDUPDATE"
                //                  +                  ",@DEPOSITSLIPNO"
                //                  +                  ",@DEPOSITKINDCODE"
                //                  +                  ",@DEPOSITKINDNAME"
                //                  +                  ",@DEPOSITALLOWANCE"
                //                  +                  ",@DEPOSITAGENTCODE"
                //                  +                  ",@DEPOSITAGENTNM"
                //                  +                  ",@CUSTOMERCODE"
                //                  +                  ",@CUSTOMERNAME"
                //                  +                  ",@CUSTOMERNAME2"
                //                  +                  ",@ACCEPTANORDERNO"
                //                  +                  ",@SERVICESLIPCD"
                //                  +                  ",@DEBITNOTEOFFSETCD"
                //                  +                  ",@DEPOSITCD"
                //                  +                  ",@CREDITORLOANCD"
                //                  + ")";
                #endregion
                // �� 20070131 18322 c
                // �� 2008.03.07 980081 a
                //string insertText = "INSERT INTO DEPOSITALWRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, INPUTDEPOSITSECCDRF, ADDUPSECCODERF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, RECONCILEDATERF, RECONCILEADDUPDATERF, DEPOSITSLIPNORF, DEPOSITKINDCODERF, DEPOSITKINDNAMERF, DEPOSITALLOWANCERF, DEPOSITAGENTCODERF, DEPOSITAGENTNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, DEBITNOTEOFFSETCDRF, DEPOSITCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @INPUTDEPOSITSECCD, @ADDUPSECCODE, @ACPTANODRSTATUS, @SALESSLIPNUM, @RECONCILEDATE, @RECONCILEADDUPDATE, @DEPOSITSLIPNO, @DEPOSITKINDCODE, @DEPOSITKINDNAME, @DEPOSITALLOWANCE, @DEPOSITAGENTCODE, @DEPOSITAGENTNM, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERNAME2, @DEBITNOTEOFFSETCD, @DEPOSITCD)";  //DEL 2008/04/25 M.Kubota

                # region [INSERT��]
                //--- ADD 2008/04/25 M.Kubota --->>>
                string insertText = string.Empty;
                insertText += "INSERT INTO DEPOSITALWRF" + Environment.NewLine;
                insertText += "(" + Environment.NewLine;
                insertText += "  CREATEDATETIMERF" + Environment.NewLine;
                insertText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                insertText += " ,ENTERPRISECODERF" + Environment.NewLine;
                insertText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                insertText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                insertText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                insertText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                insertText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                insertText += " ,INPUTDEPOSITSECCDRF" + Environment.NewLine;
                insertText += " ,ADDUPSECCODERF" + Environment.NewLine;
                insertText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                insertText += " ,SALESSLIPNUMRF" + Environment.NewLine;
                insertText += " ,RECONCILEDATERF" + Environment.NewLine;
                insertText += " ,RECONCILEADDUPDATERF" + Environment.NewLine;
                insertText += " ,DEPOSITSLIPNORF" + Environment.NewLine;
                insertText += " ,DEPOSITALLOWANCERF" + Environment.NewLine;
                insertText += " ,DEPOSITAGENTCODERF" + Environment.NewLine;
                insertText += " ,DEPOSITAGENTNMRF" + Environment.NewLine;
                insertText += " ,CUSTOMERCODERF" + Environment.NewLine;
                insertText += " ,CUSTOMERNAMERF" + Environment.NewLine;
                insertText += " ,CUSTOMERNAME2RF" + Environment.NewLine;
                insertText += " ,DEBITNOTEOFFSETCDRF" + Environment.NewLine;
                insertText += ")" + Environment.NewLine;
                insertText += "VALUES" + Environment.NewLine;
                insertText += "(" + Environment.NewLine;
                insertText += "  @CREATEDATETIME" + Environment.NewLine;
                insertText += " ,@UPDATEDATETIME" + Environment.NewLine;
                insertText += " ,@ENTERPRISECODE" + Environment.NewLine;
                insertText += " ,@FILEHEADERGUID" + Environment.NewLine;
                insertText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                insertText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                insertText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                insertText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                insertText += " ,@INPUTDEPOSITSECCD" + Environment.NewLine;
                insertText += " ,@ADDUPSECCODE" + Environment.NewLine;
                insertText += " ,@ACPTANODRSTATUS" + Environment.NewLine;
                insertText += " ,@SALESSLIPNUM" + Environment.NewLine;
                insertText += " ,@RECONCILEDATE" + Environment.NewLine;
                insertText += " ,@RECONCILEADDUPDATE" + Environment.NewLine;
                insertText += " ,@DEPOSITSLIPNO" + Environment.NewLine;
                insertText += " ,@DEPOSITALLOWANCE" + Environment.NewLine;
                insertText += " ,@DEPOSITAGENTCODE" + Environment.NewLine;
                insertText += " ,@DEPOSITAGENTNM" + Environment.NewLine;
                insertText += " ,@CUSTOMERCODE" + Environment.NewLine;
                insertText += " ,@CUSTOMERNAME" + Environment.NewLine;
                insertText += " ,@CUSTOMERNAME2" + Environment.NewLine;
                insertText += " ,@DEBITNOTEOFFSETCD" + Environment.NewLine;
                insertText += ")" + Environment.NewLine;
                //--- ADD 2008/04/25 M.Kubota ---<<<
                # endregion                
                
                // �� 2008.03.07 980081 a

				using(SqlCommand sqlCommand = new SqlCommand(insertText, sqlConnection,sqlTransaction))
				{			
					//�o�^�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)depositAlwWork;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetInsertHeader(ref flhd,obj);

					if(myReader != null && !myReader.IsClosed)myReader.Close();

                    // �� 20070131 18322 c MA.NS�p�ɕύX
                    #region SF Parameter�I�u�W�F�N�g�̐ݒ�(�X�V�p)�i�S�ăR�����g�A�E�g�j
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
					//SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
					//SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
					//SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
					//SqlParameter paraDepositSlipNo = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
					//SqlParameter paraDepositKindCode = sqlCommand.Parameters.Add("@DEPOSITKINDCODE", SqlDbType.Int);
					//SqlParameter paraDepositInputDate = sqlCommand.Parameters.Add("@DEPOSITINPUTDATE", SqlDbType.Int);
					//SqlParameter paraDepositAllowance = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE", SqlDbType.BigInt);
					//SqlParameter paraReconcileDate = sqlCommand.Parameters.Add("@RECONCILEDATE", SqlDbType.Int);
					//SqlParameter paraReconcileAddUpDate = sqlCommand.Parameters.Add("@RECONCILEADDUPDATE", SqlDbType.Int);
					//SqlParameter paraDebitNoteOffSetCd = sqlCommand.Parameters.Add("@DEBITNOTEOFFSETCD", SqlDbType.Int);
					//SqlParameter paraDepositCd = sqlCommand.Parameters.Add("@DEPOSITCD", SqlDbType.Int);
					//SqlParameter paraCreditOrLoanCd = sqlCommand.Parameters.Add("@CREDITORLOANCD", SqlDbType.Int);					
					//// 20060220 Ins Start >>����p�ʓ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
					//SqlParameter paraAcpOdrDepositAlwc = sqlCommand.Parameters.Add("@ACPODRDEPOSITALWC", SqlDbType.BigInt);
					//SqlParameter paraVarCostDepoAlwc = sqlCommand.Parameters.Add("@VARCOSTDEPOALWC", SqlDbType.BigInt);
					//// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
					//#endregion
					//
					//#region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
					//paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.CreateDateTime);
					//paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.UpdateDateTime);
					//paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
					//paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depositAlwWork.FileHeaderGuid);
					//paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdEmployeeCode);
					//paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId1);
					//paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId2);
					//paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.LogicalDeleteCode);
					//paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
					//paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);
					//paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
					//paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
					//paraDepositKindCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositKindCode);
					//paraDepositInputDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.DepositInputDate);
					//paraDepositAllowance.Value = SqlDataMediator.SqlSetInt64(depositAlwWork.DepositAllowance);
					//paraReconcileDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileDate);
					//paraReconcileAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileAddUpDate);
					//paraDebitNoteOffSetCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DebitNoteOffSetCd);
					//paraDepositCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositCd);
					//paraCreditOrLoanCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CreditOrLoanCd);
					//// 20060220 Ins Start >>����p�ʓ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
					//paraAcpOdrDepositAlwc.Value = SqlDataMediator.SqlSetInt64(depositAlwWork.AcpOdrDepositAlwc);
					//paraVarCostDepoAlwc.Value = SqlDataMediator.SqlSetInt64(depositAlwWork.VarCostDepoAlwc);
					//// 20060220 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
					//#endregion
                    #endregion

                    # region --- DEL 2008/04/25 M.Kubota ---
                    # if false
                    #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    // �쐬����
                    SqlParameter paraCreateDateTime     = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    // �X�V����
                    SqlParameter paraUpdateDateTime     = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    // ��ƃR�[�h
                    SqlParameter paraEnterpriseCode     = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    // GUID
                    SqlParameter paraFileHeaderGuid     = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    // �X�V�]�ƈ��R�[�h
                    SqlParameter paraUpdEmployeeCode    = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    // �X�V�A�Z���u��ID1
                    SqlParameter paraUpdAssemblyId1     = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    // �X�V�A�Z���u��ID2
                    SqlParameter paraUpdAssemblyId2     = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    // �_���폜�敪
                    SqlParameter paraLogicalDeleteCode  = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    // �������͋��_�R�[�h
                    SqlParameter paraInputDepositSecCd  = sqlCommand.Parameters.Add("@INPUTDEPOSITSECCD", SqlDbType.NChar);
                    // �v�㋒�_�R�[�h
                    SqlParameter paraAddUpSecCode       = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    // �����ݓ�
                    SqlParameter paraReconcileDate      = sqlCommand.Parameters.Add("@RECONCILEDATE", SqlDbType.Int);
                    // �����݌v���
                    SqlParameter paraReconcileAddUpDate = sqlCommand.Parameters.Add("@RECONCILEADDUPDATE", SqlDbType.Int);
                    // �����`�[�ԍ�
                    SqlParameter paraDepositSlipNo      = sqlCommand.Parameters.Add("@DEPOSITSLIPNO", SqlDbType.Int);
                    // ��������R�[�h
                    SqlParameter paraDepositKindCode    = sqlCommand.Parameters.Add("@DEPOSITKINDCODE", SqlDbType.Int);
                    // �������햼��
                    SqlParameter paraDepositKindName    = sqlCommand.Parameters.Add("@DEPOSITKINDNAME", SqlDbType.NVarChar);
                    // ���������z
                    SqlParameter paraDepositAllowance   = sqlCommand.Parameters.Add("@DEPOSITALLOWANCE", SqlDbType.BigInt);
                    // �����S���҃R�[�h
                    SqlParameter paraDepositAgentCode   = sqlCommand.Parameters.Add("@DEPOSITAGENTCODE", SqlDbType.NChar);
                    // �����S���Җ���
                    SqlParameter paraDepositAgentNm     = sqlCommand.Parameters.Add("@DEPOSITAGENTNM", SqlDbType.NVarChar);
                    // ���Ӑ�R�[�h
                    SqlParameter paraCustomerCode       = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    // ���Ӑ於��
                    SqlParameter paraCustomerName       = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                    // ���Ӑ於��2
                    SqlParameter paraCustomerName2      = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                    // �� 2008.03.07 980081 d
                    //// �󒍔ԍ�
                    //SqlParameter paraAcceptAnOrderNo    = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
                    //// �T�[�r�X�`�[�敪
                    //SqlParameter paraServiceSlipCd      = sqlCommand.Parameters.Add("@SERVICESLIPCD", SqlDbType.Int);
                    // �� 2008.03.07 980081 d
                    // �ԓ`���E�敪
                    SqlParameter paraDebitNoteOffSetCd  = sqlCommand.Parameters.Add("@DEBITNOTEOFFSETCD", SqlDbType.Int);
                    // �a����敪
                    SqlParameter paraDepositCd          = sqlCommand.Parameters.Add("@DEPOSITCD", SqlDbType.Int);
                    // �� 2008.03.07 980081 d
                    //// �N���W�b�g�^���[���敪
                    //SqlParameter paraCreditOrLoanCd     = sqlCommand.Parameters.Add("@CREDITORLOANCD", SqlDbType.Int);
                    // �� 2008.03.07 980081 d
                    // �� 2008.03.07 980081 a
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                    // �� 2008.03.07 980081 a
#endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    // �쐬����
                    paraCreateDateTime.Value     = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.CreateDateTime);
                    // �X�V����
                    paraUpdateDateTime.Value     = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.UpdateDateTime);
                    // ��ƃR�[�h
                    paraEnterpriseCode.Value     = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
                    // GUID
                    paraFileHeaderGuid.Value     = SqlDataMediator.SqlSetGuid(depositAlwWork.FileHeaderGuid);
                    // �X�V�]�ƈ��R�[�h
                    paraUpdEmployeeCode.Value    = SqlDataMediator.SqlSetString(depositAlwWork.UpdEmployeeCode);
                    // �X�V�A�Z���u��ID1
                    paraUpdAssemblyId1.Value     = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId1);
                    // �X�V�A�Z���u��ID2
                    paraUpdAssemblyId2.Value     = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId2);
                    // �_���폜�敪
                    paraLogicalDeleteCode.Value  = SqlDataMediator.SqlSetInt32(depositAlwWork.LogicalDeleteCode);
                    // �������͋��_�R�[�h
                    paraInputDepositSecCd.Value  = SqlDataMediator.SqlSetString(depositAlwWork.InputDepositSecCd);
                    // �v�㋒�_�R�[�h
                    paraAddUpSecCode.Value       = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);
                    // �����ݓ�
                    paraReconcileDate.Value      = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileDate);
                    // �����݌v���
                    paraReconcileAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileAddUpDate);
                    // �����`�[�ԍ�
                    paraDepositSlipNo.Value      = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
                    // ��������R�[�h
                    paraDepositKindCode.Value    = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositKindCode);
                    // �������햼��
                    paraDepositKindName.Value    = SqlDataMediator.SqlSetString(depositAlwWork.DepositKindName);
                    // ���������z
                    paraDepositAllowance.Value   = SqlDataMediator.SqlSetInt64(depositAlwWork.DepositAllowance);
                    // �����S���҃R�[�h
                    paraDepositAgentCode.Value   = SqlDataMediator.SqlSetString(depositAlwWork.DepositAgentCode);
                    // �����S���Җ���
                    paraDepositAgentNm.Value     = SqlDataMediator.SqlSetString(depositAlwWork.DepositAgentNm);
                    // ���Ӑ�R�[�h
                    paraCustomerCode.Value       = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
                    // ���Ӑ於��
                    paraCustomerName.Value       = SqlDataMediator.SqlSetString(depositAlwWork.CustomerName);
                    // ���Ӑ於��2
                    paraCustomerName2.Value      = SqlDataMediator.SqlSetString(depositAlwWork.CustomerName2);
                    // �� 2008.03.07 980081 d
                    //// �󒍔ԍ�
                    //paraAcceptAnOrderNo.Value    = SqlDataMediator.SqlSetInt32(depositAlwWork.AcceptAnOrderNo);
                    //// �T�[�r�X�`�[�敪
                    //paraServiceSlipCd.Value      = SqlDataMediator.SqlSetInt32(depositAlwWork.ServiceSlipCd);
                    // �� 2008.03.07 980081 d
                    // �ԓ`���E�敪
                    paraDebitNoteOffSetCd.Value  = SqlDataMediator.SqlSetInt32(depositAlwWork.DebitNoteOffSetCd);
                    // �a����敪
                    paraDepositCd.Value          = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositCd);
                    // �� 2008.03.07 980081 d
                    //// �N���W�b�g�^���[���敪
                    //paraCreditOrLoanCd.Value     = SqlDataMediator.SqlSetInt32(depositAlwWork.CreditOrLoanCd);
                    // �� 2008.03.07 980081 d
                    // �� 2008.03.07 980081 a
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcptAnOdrStatus);
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(depositAlwWork.SalesSlipNum);
                    // �� 2008.03.07 980081 a
                    #endregion
                    // �� 20070131 18322 c
# endif
                    # endregion

                    //--- ADD 2008/04/25 M.Kubota --->>>
                    //Prameter�I�u�W�F�N�g�̍쐬
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

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(depositAlwWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(depositAlwWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(depositAlwWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.LogicalDeleteCode);
                    paraInputDepositSecCd.Value = SqlDataMediator.SqlSetString(depositAlwWork.InputDepositSecCd);
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.AddUpSecCode);
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.AcptAnOdrStatus);
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(depositAlwWork.SalesSlipNum);
                    paraReconcileDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileDate);
                    paraReconcileAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(depositAlwWork.ReconcileAddUpDate);
                    paraDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DepositSlipNo);
                    paraDepositAllowance.Value = SqlDataMediator.SqlSetInt64(depositAlwWork.DepositAllowance);
                    paraDepositAgentCode.Value = SqlDataMediator.SqlSetString(depositAlwWork.DepositAgentCode);
                    paraDepositAgentNm.Value = SqlDataMediator.SqlSetString(depositAlwWork.DepositAgentNm);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.CustomerCode);
                    paraCustomerName.Value = SqlDataMediator.SqlSetString(depositAlwWork.CustomerName);
                    paraCustomerName2.Value = SqlDataMediator.SqlSetString(depositAlwWork.CustomerName2);
                    paraDebitNoteOffSetCd.Value = SqlDataMediator.SqlSetInt32(depositAlwWork.DebitNoteOffSetCd);
                    //--- ADD 2008/04/25 M.Kubota ---<<<

                    sqlCommand.ExecuteNonQuery();
				}

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex) 
			{
				if(myReader != null && !myReader.IsClosed)myReader.Close();
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}

			if(myReader != null && !myReader.IsClosed)myReader.Close();

			return status;
		}


	}
}
