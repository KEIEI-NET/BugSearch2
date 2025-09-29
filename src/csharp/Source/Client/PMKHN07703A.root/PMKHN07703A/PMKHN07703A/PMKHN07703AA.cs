//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����f�[�^�e�L�X�g�o�́i�s�l�x�j
// �v���O�����T�v   : ����f�[�^�e�L�X�g�o�́i�s�l�x�j�@�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10805731-00 �쐬�S�� : ���N�n��
// �� �� ��  2011/10/31  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10805731-00 �쐬�S�� : ���N�n�� 							
// �C �� ��  2012/11/21  �C�����e : Redmine#33560
//                                  �@�sN0.�͖��ׂ̍sN0.�����̂܂܃Z�b�g����d�l�ύX
//                                  �A���ʂ͂P�O�O�{�ŃZ�b�g����d�l�ύX					
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10805731-00 �쐬�S�� : ���N�n�� 							
// �C �� ��  2012/11/27  �C�����e : �������M�̒ǉ��d�l�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10805731-00 �쐬�S�� : ���N�n�� 							
// �C �� ��  2013/01/15  �C�����e : �������M�̒ǉ����b�Z�[�W�ɂ��Ă̎d�l�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11000127-00 �쐬�S�� : 30757 ���X�؁@�M�p 							
// �C �� ��  2015/01/26  �C�����e : https�v���g�R�����M���R�}���h�����M����Ȃ�
//                                  �s�����
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.Data;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Security.Cryptography;
//---ADD�@30757 ���X�؁@�M�p�@2015/01/26 Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍� ---------------->>>>>
using Microsoft.Win32;
//---ADD�@30757 ���X�؁@�M�p�@2015/01/26 Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍� ----------------<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    ///  ����f�[�^�e�L�X�g�o�́i�s�l�x�j �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����f�[�^�e�L�X�g�o�́i�s�l�x�j �A�N�Z�X�N���X</br>										
    /// <br>Programmer : ���N�n��</br>										
    /// <br>Date       : 2012/10/31</br>										
    /// <br>�Ǘ��ԍ�   : 10805731-00</br>
    /// <br>Update Note: 2012/11/21 ���N�n��</br>
    /// <br>�Ǘ��ԍ�   : 10805731-00</br>
    /// <br>             Redmine#33560</br>
    /// <br>             �@�sN0.�͖��ׂ̍sN0.�����̂܂܃Z�b�g����d�l�ύX</br>
    /// <br>             �A���ʂ͂P�O�O�{�ŃZ�b�g����d�l�ύX</br>
    /// <br>Update Note: 2012/11/27 ���N�n��</br>
    /// <br>�Ǘ��ԍ�   : 10805731-00</br>
    /// <br>             �������M�̒ǉ��d�l�ύX</br>
    /// <br>Update Note: 2013/01/15 ���N�n��</br>
    /// <br>�Ǘ��ԍ�   : 10805731-00</br>
    /// <br>             �������M�̒ǉ����b�Z�[�W�ɂ��Ă̎d�l�ύX</br>
    /// <br>Update Note: 2015/01/26 30757 ���X�؁@�M�p</br>
    /// <br>�Ǘ��ԍ�   : 11000127-00</br>
    /// <br>             Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍�</br>
    /// </remarks>
    public class SalesSliptextAcs
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members

        private static SalesSliptextAcs _salesSliptextAcs = null;
        private ISalesSliptextResultDB _salesSliptextResultDB = null;
        private List<SalesSliptextResultWork> _salesSliptextListResult = null;
        private const string ct_RmotError = "�����[�g �T�[�o�[�ɐڑ��ł��܂���B";
        //�o�̓e�L�X�g�e�[�u��
        private DataTable _salesSliptextCsv = null;
        //---ADD�@���N�n���@2012/11/27 ---------------->>>>>
        //�ڑ��}�X�^�̏�����
        private ConnectInfoWorkAcs _connectInfoWorkAcs = null;
        //---DEL�@30757 ���X�؁@�M�p�@2015/01/26 Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍� ---------------->>>>>
        //HttpWebRequest request = null;
        //---DEL�@30757 ���X�؁@�M�p�@2015/01/26 Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍� ----------------<<<<<
        //---ADD�@���N�n���@2012/11/27 ----------------<<<<<
        # endregion

        //---ADD�@���N�n���@2012/11/27 ---------------->>>>>
        private const string STRING_BOUNDARY = "-----------------------------7d21cef303f8";
        private const string STRING_CHANGE_ROW = "\r\n";        
        private const int    ERROR_SUCCESS = 0;
        //�C�����Œ�̎d����u215700�v
        private const int    SUPPLIERCD = 215700;
        #region API��`
        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool InternetGetConnectedState(out int lpdwFlags, int dwReserved);

        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int InternetAttemptConnect(int dwReserved);
        //---ADD�@���N�n���@2012/11/27 ----------------<<<<<
        #endregion

        //---ADD�@30757 ���X�؁@�M�p�@2015/01/26 Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍� ---------------->>>>>
        #region Delphi5�̃��N�G�X�g���\�b�h�Ăяo��
        /// <summary>
        /// Http����M����
        /// </summary>
        /// <param name="addres1">�ڑ���A�h���X�̃h���C������</param>
        /// <param name="addres2">�ڑ���A�h���X�̃h���C���ȍ~</param>
        /// <param name="usrname">���[�U�[ID</param>
        /// <param name="password">�p�X���[�h</param>
        /// <param name="filepath">���MXML�̊i�[��</param>
        /// <param name="filename">�t�@�C����</param>
        /// <param name="ssl">�v���g�R��[0:HTTP 1:HTTPS]</param>
        /// <param name="usercode">��ƃR�[�h</param>
        /// <param name="timeout">�^�C���A�E�g����</param>
        /// <param name="errcode">�G���[�敪</param>
        /// <remarks>
        /// <br>Note       : Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍�</br>										
        /// <br>Programmer : 30757 ���X�؁@�M�p</br>										
        /// <br>Date       : 2015/01/26</br>										
        /// <br>�Ǘ��ԍ�   : 11000127-0</br>
        /// </remarks>
        /// <returns></returns>
        [DllImport("PMPP9901.dll")]
        public extern static Int16 xPMPP9901(
              string addres1         //----�ڑ���A�h���X�̃h���C���������Z�b�g
            , string addres2         //----�ڑ���A�h���X�̃h���C���ȉ��̕������Z�b�g
            , string usrname         //----�ڑ�����ۂ̃��[�U�[ID���Z�b�g
            , string password        //----�ڑ�����ۂ̃p�X���[�h���Z�b�g
            , string filepath        //----���MXML�̊i�[����Z�b�g
            , string filename        //----���MXML�̃t�@�C�������Z�b�g
            , Int16 ssl                //----�v���g�R��[0:HTTP 1:HTTPS]
            , string usercode        //----BL�Ǘ��̃��[�U�[�R�[�h���Z�b�g(��ƃR�[�h)
            , int timeout            //----�^�C�����Ԃ̒l���Z�b�g
            , ref Int16 errcode        //----�G���[�敪
            );
        #endregion
        //---ADD�@30757 ���X�؁@�M�p�@2015/01/26 Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍� ----------------<<<<<

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�t�H���g�R���X�g���N�^</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>Update Note: 2012/11/27 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>             �������M�̒ǉ��d�l�ύX</br>
        /// </remarks>
        private SalesSliptextAcs()
        {
            this._salesSliptextResultDB = (ISalesSliptextResultDB)MediationSalesSliptextResultDB.GetSalesSliptextResultDB();
            //�o�̓e�L�X�g�e�[�u��������
            this._salesSliptextCsv = new DataTable();
            //---ADD�@���N�n���@2012/11/27 ---------------->>>>>
            //�ڑ��}�X�^�̏�����
            this._connectInfoWorkAcs = new ConnectInfoWorkAcs();
            //---ADD�@���N�n���@2012/11/27 ----------------<<<<<
            //�o�̓e�L�X�g�쐬
            CreateDataTable();
        }

        /// <summary>
        /// �A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�A�N�Z�X�N���X �C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : �A�N�Z�X�N���X �C���X�^���X�擾����</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        public static SalesSliptextAcs GetInstance()
        {
            if (_salesSliptextAcs == null)
            {
                _salesSliptextAcs = new SalesSliptextAcs();
            }

            return _salesSliptextAcs;
        }

        #endregion

        // ===================================================================================== //
        // ����
        // ===================================================================================== //
        # region ��Propertity

        /// <summary>
        /// �o�̓e�L�X�g�e�[�u��
        /// </summary>
        public DataTable SalesSliptextCsv
        {
            get { return _salesSliptextCsv; }
        }

        #endregion


        // ===================================================================================== //
        // �����������\�b�h
        // ===================================================================================== //
        # region ��Search Methods
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="salesSliptextCndtn">��������</param>
        /// <param name="tmy_id">TMY-ID</param>
        /// <param name="resultCount">���o�`�[����</param>
        /// <param name="message">�G���[���b�Z�b�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��������</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        public int SearchData(SalesSliptextCndtn salesSliptextCndtn, string tmy_id, ref int resultCount, ref string message)
        {
            return SearchDataProc(salesSliptextCndtn, tmy_id, ref resultCount, ref message);
        }
        # endregion 

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region ��Private Methods
        /// <summary>
        /// ��������Proc
        /// </summary>
        /// <param name="salesSliptextCndtn">��������</param>
        /// <param name="tmy_id">TMY-ID</param>
        /// <param name="resultCount">���o�`�[����</param>
        /// <param name="message">�G���[���b�Z�b�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��������Proc</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>Update Note: 2012/11/21 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>             Redmine#33560</br>
        /// <br>             �@�sN0.�͖��ׂ̍sN0.�����̂܂܃Z�b�g����d�l�ύX</br>
        /// <br>             �A���ʂ͂P�O�O�{�ŃZ�b�g����d�l�ύX</br>
        /// </remarks>
        private int SearchDataProc(SalesSliptextCndtn salesSliptextCndtn, string tmy_id, ref int resultCount, ref string message)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            string rtMessage = string.Empty;
            //int salesDetailindex = 0;//DEL�@���N�n���@2012/11/21 Redmine33560
            double shipmentCntHiyagu = 0;//ADD�@���N�n���@2012/11/21 Redmine33560
            try
            {
                ArrayList salesSliptextList = null;
                this._salesSliptextListResult = new List<SalesSliptextResultWork>();

                // UI�f�[�^�N���X�����[�N
                SalesSliptextCndtnWork cndtnWork = CopyToSalesSliptextCndtnWorkFromSalesSliptextCndtn(salesSliptextCndtn);
                object salesSliptextResultWork = null;
                
                status = this._salesSliptextResultDB.Search(out salesSliptextResultWork, (object)cndtnWork, out rtMessage);
                salesSliptextList = salesSliptextResultWork as ArrayList;
                //�����f�[�^������̏ꍇ�A�l���Z�b�g����
                if (salesSliptextList != null && salesSliptextList.Count > 0)
                {
                    resultCount = 1;
                    if (this._salesSliptextCsv != null && this._salesSliptextCsv.Rows.Count > 0)
                    {
                        this._salesSliptextCsv.Rows.Clear();
                    }
                    else
                    {
                        //�Ȃ��B
                    } 
                    foreach (SalesSliptextResultWork resultWork in salesSliptextList)
                    {
                        this._salesSliptextListResult.Add(resultWork);
                    }
                    for (int index = 0; index < this._salesSliptextListResult.Count; index++)
                    {
                        //�`�[����擾�����ް����̔�
                        if (index > 0 && this._salesSliptextListResult[index - 1].SalesSlipNum != this._salesSliptextListResult[index].SalesSlipNum)
                        {
                            //salesDetailindex = 0;//DEL�@���N�n���@2012/11/21 Redmine33560
                            resultCount++;
                        }
                        else
                        {
                            //�Ȃ��B
                        } 
                        //salesDetailindex++;//DEL�@���N�n���@2012/11/21 Redmine33560
                        DataRow dr = this._salesSliptextCsv.NewRow();
                        // �f�[�^�敪
                        dr["DATADIV"] = "01";
                        // TMY-ID
                        dr["TMYID"] = SubStringOfByte(tmy_id,7);
                        // ���Ӑ溰��
                        dr["CUSTOMERCODE"] = this._salesSliptextListResult[index].CustomerCode.ToString("00000000");
                        // ������t
                        dr["SALESDATE"] = this._salesSliptextListResult[index].SalesDate.ToString();
                        // ����`�[�ԍ�
                        dr["SALESSLIPNUM"] = this._salesSliptextListResult[index].SalesSlipNum;
                        // ����s�ԍ�
                        //dr["SALESROWNO"] = SubStringOfByte(salesDetailindex.ToString(),2);//DEL�@���N�n���@2012/11/21 Redmine33560
                        dr["SALESROWNO"] = SubStringOfByte(this._salesSliptextListResult[index].SalesRowNo.ToString(), 2);//ADD�@���N�n���@2012/11/21 Redmine33560
                        // ���i�ԍ�
                        dr["GOODSNO"] = SubStringOfByte(this._salesSliptextListResult[index].GoodsNo,20);
                        // ���i���[�J�[�R�[�h
                        dr["GOODSMAKERCD"] = this._salesSliptextListResult[index].GoodsMakerCd.ToString();
                        // BL���i�R�[�h
                        if (this._salesSliptextListResult[index].BLGoodsCode != 0)
                        {
                           
                            dr["BLGOODSCODE"] = this._salesSliptextListResult[index].BLGoodsCode.ToString("00000");
                        }
                        else
                        {
                            dr["BLGOODSCODE"] = DBNull.Value;
                        }
                        // �o�א�
                        //dr["SHIPMENTCNT"] = SubStringOfByte(this._salesSliptextListResult[index].ShipmentCnt.ToString(),8);//DEL�@���N�n���@2012/11/21 Redmine33560
                        //---ADD�@���N�n���@2012/11/21 Redmine33560--------------------->>>>>
                        shipmentCntHiyagu = this._salesSliptextListResult[index].ShipmentCnt * 100;
                        dr["SHIPMENTCNT"] = SubStringOfByte(shipmentCntHiyagu.ToString(), 8);
                        //---ADD�@���N�n���@2012/11/21 Redmine33560---------------------<<<<<
                        // �d����R�[�h
                        if (this._salesSliptextListResult[index].SupplierCd >= 215700 && this._salesSliptextListResult[index].SupplierCd <= 215799)
                        {

                            dr["SUPPLIERCD"] = this._salesSliptextListResult[index].SupplierCd.ToString();
                        }
                        else
                        {
                            dr["SUPPLIERCD"] = DBNull.Value;
                        }
                        this._salesSliptextCsv.Rows.Add(dr);
                    }

                }
                else
                {
                    //�Ȃ��B
                } 
            }
            catch (Exception ex)
            {
                ex.ToString();
                message = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            else if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            else
            { 
               //�Ȃ��B
            }
            
            return status;
        }

        #region[������@�o�C�g���w��؂蔲��]
        /// <summary>
        /// ������@�o�C�g���w��؂蔲��
        /// </summary>
        /// <param name="orgString">���̕�����</param>
        /// <param name="byteCount">�o�C�g��</param>
        /// <returns>�w��o�C�g���Ő؂蔲����������</returns>
        /// <remarks>
        /// <br>Note       : ������@�o�C�g���w��؂蔲��</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        protected static string SubStringOfByte(string orgString, int byteCount)
        {
            if (byteCount <= 0)
            {
                return string.Empty;
            }
            else
            {
                //�Ȃ��B
            }

            Encoding encoding = Encoding.GetEncoding("Shift_JIS");

            string resultString = string.Empty;

            int count;

            for (int i = orgString.Length; i >= 0; i--)
            {
                // �u�������v�����炷
                resultString = orgString.Substring(0, i);

                // �o�C�g�����擾���Ĕ���
                count = encoding.GetByteCount(resultString);
                if (count <= byteCount)
                {
                    break;
                }
                else
                {
                    //�Ȃ��B
                }
            }

            // �I�[�̋󔒂͍폜
            return resultString;

        }
        #endregion

        /// <summary>
        /// �o�̓e�L�X�g�e�[�u���쐬
        /// </summary>
        /// <remarks>
        /// <br>Note       : �o�̓e�L�X�g�e�[�u���쐬</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private void CreateDataTable()
        {
            // �X�L�[�}�ݒ�
            this._salesSliptextCsv = new DataTable("salesSliptextCsv");

            // �f�[�^�敪
            this._salesSliptextCsv.Columns.Add("DATADIV", typeof(string));
            this._salesSliptextCsv.Columns["DATADIV"].DefaultValue = "";

            // TMY-ID
            this._salesSliptextCsv.Columns.Add("TMYID", typeof(string));
            this._salesSliptextCsv.Columns["TMYID"].DefaultValue = "";

            // ���Ӑ溰��
            this._salesSliptextCsv.Columns.Add("CUSTOMERCODE", typeof(string));
            this._salesSliptextCsv.Columns["CUSTOMERCODE"].DefaultValue = "";

            // ������t
            this._salesSliptextCsv.Columns.Add("SALESDATE", typeof(Int32));
            this._salesSliptextCsv.Columns["SALESDATE"].DefaultValue = 0;

            // ����`�[�ԍ�
            this._salesSliptextCsv.Columns.Add("SALESSLIPNUM", typeof(Int32));
            this._salesSliptextCsv.Columns["SALESSLIPNUM"].DefaultValue = 0;

            // ����s�ԍ�
            this._salesSliptextCsv.Columns.Add("SALESROWNO", typeof(Int32));
            this._salesSliptextCsv.Columns["SALESROWNO"].DefaultValue = 0; 

            // ���i�ԍ�
            this._salesSliptextCsv.Columns.Add("GOODSNO", typeof(string));
            this._salesSliptextCsv.Columns["GOODSNO"].DefaultValue = "";

            // ���i���[�J�[�R�[�h
            this._salesSliptextCsv.Columns.Add("GOODSMAKERCD", typeof(string));
            this._salesSliptextCsv.Columns["GOODSMAKERCD"].DefaultValue = "";

            // BL���i�R�[�h
            this._salesSliptextCsv.Columns.Add("BLGOODSCODE", typeof(string));
            this._salesSliptextCsv.Columns["BLGOODSCODE"].DefaultValue = "";

            // �o�א�
            this._salesSliptextCsv.Columns.Add("SHIPMENTCNT", typeof(Int32));
            this._salesSliptextCsv.Columns["SHIPMENTCNT"].DefaultValue = 0;

            // �d����R�[�h
            this._salesSliptextCsv.Columns.Add("SUPPLIERCD", typeof(Int32));
            this._salesSliptextCsv.Columns["SUPPLIERCD"].DefaultValue = 0;  
        }

    �@�@
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i����f�[�^�e�L�X�g�o�́iTMY)�����N���X�˔���f�[�^�e�L�X�g�o�́iTMY)�������[�N�N���X�j
        /// </summary>
        /// <param name="cndtn">����f�[�^�e�L�X�g�o�́iTMY)����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o�[�R�s�[�����i����f�[�^�e�L�X�g�o�́iTMY)�����N���X�˔���f�[�^�e�L�X�g�o�́iTMY)�������[�N�N���X�j</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private SalesSliptextCndtnWork CopyToSalesSliptextCndtnWorkFromSalesSliptextCndtn(SalesSliptextCndtn cndtn)
        {
            SalesSliptextCndtnWork cndtnWork = new SalesSliptextCndtnWork();

            cndtnWork.CarMngNo1 = cndtn.CarMngNo1;                 //���q�Ǘ��R�[�h
            cndtnWork.CustAnalysCode1 = cndtn.CustAnalysCode1;     //���Ӑ敪�̓R�[�h1
            cndtnWork.CustAnalysCode2 = cndtn.CustAnalysCode2;     //���Ӑ敪�̓R�[�h2
            cndtnWork.CustAnalysCode3 = cndtn.CustAnalysCode3;     //���Ӑ敪�̓R�[�h3
            cndtnWork.CustAnalysCode4 = cndtn.CustAnalysCode4;     //���Ӑ敪�̓R�[�h4
            cndtnWork.CustAnalysCode5 = cndtn.CustAnalysCode5;     //���Ӑ敪�̓R�[�h5 
            cndtnWork.CustAnalysCode6 = cndtn.CustAnalysCode6;     //���Ӑ敪�̓R�[�h6
            cndtnWork.EnterpriseCode = cndtn.EnterpriseCode;       //��ƃR�[�h
            cndtnWork.PartySaleSlipNum = cndtn.PartySaleSlipNum;   //�����`�[�ԍ�
            cndtnWork.SalesDateEd = cndtn.SalesDateEd;             //�Ώۓ��̏I����
            cndtnWork.SalesDateSt = cndtn.SalesDateSt;             //�Ώۓ��̊J�n��
            cndtnWork.SlipNote = cndtn.SlipNote;                   //�`�[���l
            cndtnWork.SlipNote2 = cndtn.SlipNote2;                 //�`�[���l�Q
            cndtnWork.SlipNote3 = cndtn.SlipNote3;                 //�`�[���l�R
            cndtnWork.SupplierCd = cndtn.SupplierCd;               //�d����R�[�h

            return cndtnWork;
        }

        # region �������M�̒ǉ�
        //---ADD�@���N�n���@2012/11/27 ---------------->>>>>
        /// <summary>
        /// Web�T�[�o�Ƒ���M���܂��B
        /// </summary>
        /// <param name="salesSliptextCndtn">����</param>
        /// <param name="xmlfileDir">�p�X</param>
        /// <param name="fileNamepara">�t�@�C����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : Web�T�[�o�Ƒ���M���܂��B</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/11/27</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>             �������M�̒ǉ��d�l�ύX</br>
        /// <br>Update Note: 2013/01/15 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br>             �������M�̒ǉ����b�Z�[�W�ɂ��Ă̎d�l�ύX</br>
        /// <br>Update Note: 2015/01/26 30757 ���X�؁@�M�p</br>
        /// <br>�Ǘ��ԍ�   : 11000127-00</br>
        /// <br>             Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍�</br>
        /// </remarks>
        public int SendAndReceive(SalesSliptextCndtn salesSliptextCndtn, string xmlfileDir, string fileNamepara)
        {
            //---ADD�@30757 ���X�؁@�M�p�@2015/01/26 Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍� ---------------->>>>>
            LogFile logger = new LogFile(true);
            Int16 errorCode = 0;
            Int16 errorKbn = 0;
            //---ADD�@30757 ���X�؁@�M�p�@2015/01/26 Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍� ----------------<<<<<
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            string fileName = xmlfileDir + "\\" + fileNamepara + ".XML";
            ConnectInfoWork connectInfoWork = null;
            connectInfoWork = null;
            try
            {
                status = this._connectInfoWorkAcs.Read(out connectInfoWork, salesSliptextCndtn.EnterpriseCode, SUPPLIERCD);
            }
            catch (Exception ex)
            {
                ex.ToString();
                status = -1;
                //---ADD�@30757 ���X�؁@�M�p�@2015/01/26 Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍� ---------------->>>>>
                logger.WriteErrorLog("SendAndReceive", "�ڑ�����̎擾�Ɏ��s���܂����B", ex);
                //---ADD�@30757 ���X�؁@�M�p�@2015/01/26 Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍� ----------------<<<<<
                return status;
            }

            //if (connectInfoWork == null)//DEL�@���N�n���@2013/01/15 Redmine34342
            if (connectInfoWork == null || status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)//ADD�@���N�n���@2013/01/15 Redmine34342
            {
                status = -1;
                //---ADD�@30757 ���X�؁@�M�p�@2015/01/26 Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍� ---------------->>>>>
                logger.WriteErrorLog("SendAndReceive", "�ڑ�����̎擾�Ɏ��s���܂����B", null);
                //---ADD�@30757 ���X�؁@�M�p�@2015/01/26 Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍� ----------------<<<<<
                return status;
            }

            //---ADD�@30757 ���X�؁@�M�p�@2015/01/26 Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍� ---------------->>>>>
            try
            {
                errorKbn = xPMPP9901(
                      connectInfoWork.OrderUrl          //---�h���C��
                    , connectInfoWork.StockCheckUrl     //---�h���C���ȍ~�̃A�h���X
                    , connectInfoWork.ConnectUserId     //---�ڑ���̔F��ID
                    , connectInfoWork.ConnectPassword   //---�ڑ���̔F�؃p�X���[�h
                    , xmlfileDir                        //---����MXML�̃t�@�C���p�X
                    , fileNamepara                      //---����MXML�̃t�@�C����
                    , Convert.ToInt16(connectInfoWork.DaihatsuOrdreDiv)  //---�v���g�R��
                    , connectInfoWork.EnterpriseCode    //---��ƃR�[�h
                    , connectInfoWork.LoginTimeoutVal   //---�^�C���A�E�g
                    , ref errorCode                     //---�G���[�R�[�h
                    );

                if (0 != errorKbn)
                {
                    string errorMes = "�\�����ʃG���[���������܂����B";
                    status = -1;
                    if (1 >= errorKbn)
                    {
                        switch (errorCode)
                        {

                            case -3:
                                errorMes = string.Format("�f�[�^���M�Ώۃt�@�C���I�[�v�������ŃG���[���������܂���(AssignFile)({0})", fileNamepara);
                                break;
                            case -2:
                                errorMes = string.Format("�f�[�^���M�Ώۃt�@�C��������܂���(AssignFile)({0})", fileNamepara);
                                break;
                            case -1:
                                errorMes = "�f�[�^����M�ŗ\�����ʃG���[���������܂����B";
                                break;
                            case 1:
                                errorMes = "����I�[�v���G���[(InternetAttemptConnect)";
                                break;
                            case 2:
                                errorMes = "����I�[�v���G���[(InternetOpen)";
                                break;
                            case 3:
                                errorMes = "����I�[�v���G���[(InternetConnect)";
                                break;
                            case 4:
                                errorMes = "����I�[�v���G���[(HttpOpenRequest)";
                                break;
                            case 5:
                                errorMes = "����I�[�v���G���[(InternetSetOption)";
                                break;
                        }
                    }
                    else if (2 == errorKbn)
                    {
                        errorMes = "�f�[�^���M�G���[(SendRequest)";
                    }
                    else if (3 == errorKbn || 4 == errorKbn)
                    {
                        errorMes = "�f�[�^����M�G���[(HttpQueryInfo)";
                    }

                    logger.WriteErrorLog(
                          "xPMPP9901"
                        , string.Format("{0}�i�敪:{1} �G���[�R�[�h:{2}�j", errorMes, errorKbn, errorCode)
                        , null);
                }
            }
            catch (Exception ex)
            {
                status = -1;
                logger.WriteErrorLog("xPMPP9901", "����f�[�^�̑���M�Ɏ��s���܂����B", ex);
                return status;
            }
            //---ADD�@30757 ���X�؁@�M�p�@2015/01/26 Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍� ----------------<<<<<

            //---DEL�@30757 ���X�؁@�M�p�@2015/01/26 Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍� ---------------->>>>>
            //string myString = ""; ;
            //string content = "";
            //string fileRecStream = "";
            //string errorMessage = "";

            //// ����I�[�v������
            //if (RequestOpen(connectInfoWork))
            //{
            //    HttpWebResponse response = null;
            //    try
            //    {
            //        // ���M�d���f�[�^��XML�t�@�C���ɕϊ�����
            //        content = ConvertUoeSndHedToXML(connectInfoWork, fileName);
            //
            //
            //        myString += STRING_BOUNDARY;
            //        myString += STRING_CHANGE_ROW;
            //        myString += "Content-Disposition: form-data; name=\"xml_data\"; ";
            //        myString += "filename=\"" + fileName + "\"";
            //        myString += STRING_CHANGE_ROW;
            //        myString += STRING_CHANGE_ROW;
            //
            //        myString = myString + content + STRING_CHANGE_ROW + STRING_BOUNDARY + "--" + STRING_CHANGE_ROW;
            //
            //        byte[] body = Encoding.ASCII.GetBytes(myString);
            //
            //        using (Stream reqStream = request.GetRequestStream())
            //        {
            //            reqStream.Write(body, 0, body.Length);
            //            reqStream.Close();
            //        }
            //        
            //        using (response = (HttpWebResponse)request.GetResponse())
            //        {
            //        
            //            Stream revStream = response.GetResponseStream();
            //            StreamReader sr = new StreamReader(revStream, Encoding.GetEncoding(932));
            //            fileRecStream = sr.ReadToEnd();
            //        
            //        }
            //    }
            //    catch (WebException ex)
            //    {
            //        errorMessage = ex.Message;
            //        status = -1;
            //        return status;
            //    }
            //    response.Close();
            //    try
            //    {
            //        //Rec�t�@�C���쐬
            //
            //        if (fileRecStream == string.Empty)
            //        {
            //            status = -1;
            //            errorMessage = "�ް���M���ɴװ������(��M�t�@�C�����e������܂���) ";
            //            return status;
            //        }
            //
            //        //�t�@�C������ TMY-ID�{YYYYMM�{"RECV.XML"�Ƃ���B�iYYYYMM�͉�ʎw�肳�ꂽ�N��(�Ώۓ��t�̔N��)�j
            //        string fileRecName = xmlfileDir + "\\" + fileNamepara + "RECV.XML";
            //
            //        FileStream file = new FileStream(fileRecName, FileMode.Create);
            //
            //        file.Write(Encoding.UTF8.GetBytes(fileRecStream), 0, Encoding.UTF8.GetByteCount(fileRecStream));
            //        file.Close();
            //
            //    }
            //    catch (Exception ex)
            //    {
            //        ex.ToString();
            //        status = -1;
            //        return status;
            //    }
            //}
            //else
            //{
            //    status = -1;
            //    return status;
            //}
            //---DEL�@30757 ���X�؁@�M�p�@2015/01/26 Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍� ----------------<<<<<
            return status;
        }

        //---DEL�@30757 ���X�؁@�M�p�@2015/01/26 Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍� ---------------->>>>>
        ///// <summary>
        ///// ����I�[�v������
        ///// </summary>
        ///// <param name="connectInfo">����</param>
        ///// <returns>�X�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note       : ����I�[�v������</br>										
        ///// <br>Programmer : ���N�n��</br>										
        ///// <br>Date       : 2012/11/27</br>										
        ///// <br>�Ǘ��ԍ�   : 10805731-00</br>
        ///// <br>             �������M�̒ǉ��d�l�ύX</br>
        ///// </remarks>
        //private bool RequestOpen(ConnectInfoWork connectInfo)
        //{
        //    bool isConnected;
        //    int flags;
        //    isConnected = InternetGetConnectedState(out flags, 0);

        //    if (InternetAttemptConnect(0) != ERROR_SUCCESS || isConnected == false)
        //    {
        //        // ������I�[�y���G���[
        //        return false;
        //    }
        //    string httpHead = "";

        //    //HTTP/HTTPS �v���g�R��  
        //    if (connectInfo.DaihatsuOrdreDiv == 0)
        //    {
        //        httpHead = "http://";
        //    }
        //    else
        //    {
        //        httpHead = "https://";
        //    }
        //    //�ڑ�����}�X�^�̔�����z�敪�i�_�C�n�c�j�{�ڑ�����}�X�^�̔���URL�{�ڑ�����}�X�^�̍݌Ɋm�FURL
        //    request = (HttpWebRequest)HttpWebRequest.Create(httpHead + connectInfo.OrderUrl + connectInfo.StockCheckUrl);
        //    request.Method = "POST";
        //    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.0.3705; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        //    return true;
        //}

        ///// <summary>
        ///// ���M�d���f�[�^��Web�T�[�r�X�p�p�����[�^�ɕϊ�����
        ///// </summary>
        ///// <param name="connectInfo">����</param>
        ///// <param name="fileName">�t�@�C����</param>
        ///// <returns>�X�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note       : ���M�d���f�[�^��Web�T�[�r�X�p�p�����[�^�ɕϊ�����</br>										
        ///// <br>Programmer : ���N�n��</br>										
        ///// <br>Date       : 2012/11/27</br>										
        ///// <br>�Ǘ��ԍ�   : 10805731-00</br>
        ///// <br>             �������M�̒ǉ��d�l�ύX</br>
        ///// </remarks>
        //private string ConvertUoeSndHedToXML(ConnectInfoWork connectInfo, string fileName)
        //{
        //    // �w�b�_���ǉ�
        //    HeaderMake(connectInfo);
        //    string xmlFileString = "";
        //    xmlFileString = fileChange(fileName);
            
        //    return xmlFileString;
        //}

        ///// <summary>
        ///// �t�@�C����ύX
        ///// </summary>
        ///// <param name="fileName">�t�@�C����</param>
        ///// <returns>�X�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note       : �t�@�C����ύX</br>										
        ///// <br>Programmer : ���N�n��</br>										
        ///// <br>Date       : 2012/11/27</br>										
        ///// <br>�Ǘ��ԍ�   : 10805731-00</br>
        ///// <br>             �������M�̒ǉ��d�l�ύX</br>
        ///// </remarks>
        //private string fileChange(string fileName)
        //{
        //    //�t�@�C���֑��M
        //    string fileString = "";
        //    try
        //    {
        //        FileStream file = new FileStream(fileName, FileMode.Open);
        //        byte[] byDate = new byte[file.Length];
        //        char[] charDate = new char[file.Length];
        //        file.Read(byDate, 0, (int)file.Length);
        //        Decoder d = Encoding.UTF8.GetDecoder();
        //        d.GetChars(byDate, 0, byDate.Length, charDate, 0);
        //        for (int i = 0; i < charDate.Length; i++)
        //        {
        //            fileString = fileString + charDate[i];
        //        }
        //        file.Close();
        //    }
        //    catch (Exception)
        //    {
        //        fileString = "";
        //    }
        //    return fileString;
        //}

        
        ///// <summary>
        ///// �w�b�_���ǉ�
        ///// </summary>
        ///// <param name="connectInfo">����</param>
        ///// <remarks>
        ///// <br>Note       :  �w�b�_���ǉ�</br>										
        ///// <br>Programmer : ���N�n��</br>										
        ///// <br>Date       : 2012/11/27</br>										
        ///// <br>�Ǘ��ԍ�   : 10805731-00</br>
        ///// <br>             �������M�̒ǉ��d�l�ύX</br>
        ///// </remarks>
        //private void HeaderMake(ConnectInfoWork connectInfo)
        //{
        //    request.Accept = "*/*";
        //    request.Headers.Add("Accept-Language", "ja");
        //    //WSSE�F�ؗp�̕���������
        //    string wsse = CreateWSSEToken(connectInfo.ConnectUserId, connectInfo.ConnectPassword);

        //    request.Headers.Add("X-WSSE: " + wsse);

        //    request.ContentType = "multipart/form-data; boundary=" + STRING_BOUNDARY.Substring(2);
        //    request.KeepAlive = true;
        //    //�ڑ�����}�X�^�̃��O�C���^�C���A�E�g
        //    if (connectInfo.LoginTimeoutVal != 0)
        //    {
        //        request.Timeout = connectInfo.LoginTimeoutVal * 1000;
        //    }
        //}

        ///// <summary>
        ///// 16�i���\�L��SHA-1���b�Z�[�W�_�C�W�F�X�g�𐶐����܂��B
        ///// </summary>
        ///// <param name="source">source</param>
        ///// <returns>�X�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note       : 16�i���\�L��SHA-1���b�Z�[�W�_�C�W�F�X�g�𐶐����܂��B</br>										
        ///// <br>Programmer : ���N�n��</br>										
        ///// <br>Date       : 2012/11/27</br>										
        ///// <br>�Ǘ��ԍ�   : 10805731-00</br>
        ///// <br>             �������M�̒ǉ��d�l�ύX</br>
        ///// </remarks>
        //private string GetDigest(string source)
        //{
        //    SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
        //    StringBuilder answer = new StringBuilder();
        //    foreach (Byte b in sha1.ComputeHash(Encoding.UTF8.GetBytes(source)))
        //    {
        //        if (b < 16)
        //        {
        //            answer.Append("0");
        //        }
        //        answer.Append(Convert.ToString(b, 16));
        //    }
        //    return answer.ToString();
        //}

        ///// <summary>
        ///// Nonce�𐶐����܂��B
        ///// Nonce�͐��x�̍����[������������𗘗p���Ă��������B
        ///// </summary>
        ///// <returns>�X�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note       : Nonce�𐶐����܂��B</br>										
        ///// <br>Programmer : ���N�n��</br>										
        ///// <br>Date       : 2012/11/27</br>										
        ///// <br>�Ǘ��ԍ�   : 10805731-00</br>
        ///// <br>             �������M�̒ǉ��d�l�ύX</br>
        ///// </remarks>
        //private string CreateNonce()
        //{
        //    Random r = new Random();
        //    double d1 = r.NextDouble();
        //    double d2 = d1 * d1;
        //    return GetDigest(d2.ToString());
        //}

        ///// <summary>
        ///// Nonce�𐶐����܂��B
        ///// Nonce�͐��x�̍����[������������𗘗p���Ă��������B
        ///// </summary>
        ///// <param name="userName">userName</param>
        ///// <param name="password">password</param>
        ///// <returns>�X�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note       : Nonce�𐶐����܂��B</br>										
        ///// <br>Programmer : ���N�n��</br>										
        ///// <br>Date       : 2012/11/27</br>										
        ///// <br>�Ǘ��ԍ�   : 10805731-00</br>
        ///// <br>             �������M�̒ǉ��d�l�ύX</br>
        ///// </remarks>
        //private string CreateWSSEToken(string userName, string password)
        //{
        //    StringBuilder wsseToken = new StringBuilder();
        //    string nonce = CreateNonce();
        //    string created = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffffZ");
        //    string passwordDigest = Convert.ToBase64String(Encoding.UTF8.GetBytes(GetDigest(String.Format("{0}{1}{2}", nonce, created, password))));

        //    //Username Token�̕�����𐶐����� 
        //    wsseToken.Append("UsernameToken ");
        //    wsseToken.AppendFormat("Username=\"{0}\", ", userName);
        //    wsseToken.AppendFormat("PasswordDigest=\"{0}\", ", passwordDigest);
        //    wsseToken.AppendFormat("Nonce=\"{0}\", ", nonce);
        //    wsseToken.AppendFormat("Created=\"{0}\" ", created);

        //    return wsseToken.ToString();
        //}
        //---DEL�@30757 ���X�؁@�M�p�@2015/01/26 Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍� ----------------<<<<<
        //---ADD�@���N�n���@2012/11/27 ----------------<<<<<

        //---ADD�@30757 ���X�؁@�M�p�@2015/01/26 Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍� ---------------->>>>>
        /// <summary>
        /// ���O�L�^�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : [InstallDirectory]\Log\PMKHN07703A_yyyyMMdd_HHmmss.log ���쐬���܂��B</br>										
        /// <br>Programmer : 30757 ���X�؁@�M�p</br>										
        /// <br>Date       : 2015/01/19</br>										
        /// <br>�Ǘ��ԍ�   : 11000127-00</br>
        /// <br>             Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍�</br>
        /// </remarks>
        public class LogFile
        {
            const string _logFileNameFormat = @"PMKHN07703A_{0:yyyyMMdd_HHmmss}.log";

            private bool _errorFlg = false;
            private string _folderPath = string.Empty;
            private string _fileName = string.Empty;

            /// <summary>
            /// �G���[�t���O���擾���܂��B
            /// </summary>
            /// <remarks>
            /// �G���[���O���P��ł��L�^���ꂽ�ꍇ�� True ��Ԃ��B
            /// </remarks>
            public bool ErrorFlg
            {
                get { return this._errorFlg; }
            }

            /// <summary>
            /// ���O�t�@�C���̃t�@�C�������擾���܂��B
            /// </summary>
            /// <remarks>
            /// ���O�t�@�C���̃t�@�C�������t���p�X�Ŏ擾���܂��B
            /// </remarks>
            public string FileName
            {
                get { return this._fileName; }
            }

            /// <summary>
            /// ���O�L�^�N���X �R���X�g���N�^
            /// </summary>
            /// <param name="clientMode">True: �N���C�A���g���[�h, False: �T�[�o�[���[�h</param>
            public LogFile(bool clientMode)
            {
                string keyPath = "";

                if (clientMode)
                {
                    // �N���C���A���g
                    keyPath = @String.Format(@"SOFTWARE\Broadleaf\Product\Partsman");
                }

                else
                {
                    // �T�[�o�[
                    keyPath = @String.Format(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
                }

                RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath);

                try
                {
                    if (key.GetValue("InstallDirectory") != null)
                    {
                        this._folderPath = (string)key.GetValue("InstallDirectory");
                    }
                    else
                    {
                        // �擾�ł��Ȃ������ꍇ�́A�ی��Ƃ��ăA�Z���u�����z�u����Ă���t�H���_���̗p����
                        this._folderPath = System.AppDomain.CurrentDomain.BaseDirectory;
                    }

                    this._folderPath = Path.Combine(this._folderPath, "Log");
                }
                finally
                {
                    key.Close();
                }
            }

            /// <summary>
            /// �G���[���O�o��
            /// </summary>
            /// <param name="method">���\�b�h��</param>
            /// <param name="Msg">�G���[�e�L�X�g</param>
            /// <param name="ex">��O�I�u�W�F�N�g</param>
            public void WriteErrorLog(string method, string Msg, Exception ex)
            {
                this._errorFlg = true;

                string exceptionMsg = "����";
                if (ex != null)
                    exceptionMsg = ex.Message;
                string msg = string.Format("Msg:{0} Exception.Msg:{1}", Msg, exceptionMsg);
                WriteLog(method, msg);
            }

            /// <summary>
            /// ���O�o��
            /// </summary>
            /// <param name="method">���\�b�h��</param>
            /// <param name="Msg">�o�̓e�L�X�g</param>
            public void WriteLog(string method, string Msg)
            {
                string msg = string.Format("Method:{0} {1}", method, Msg);
                Write(msg);
            }

            /// <summary>
            /// ��O���O�o��
            /// </summary>
            /// <param name="ex">��O�I�u�W�F�N�g</param>
            /// <param name="text">�o�̓e�L�X�g</param>
            public void Write(Exception ex, string text)
            {
                this._errorFlg = true;

                string exceptionMsg = "����";
                if (ex != null)
                    exceptionMsg = ex.Message;

                if (string.IsNullOrEmpty(text))
                {
                    this.Write(exceptionMsg);
                }
                else
                {
                    this.Write(string.Format("{0} ({1})", exceptionMsg, text));
                }
            }

            /// <summary>
            /// ���O�o��
            /// </summary>
            /// <param name="text">�o�̓e�L�X�g</param>
            public void Write(string text)
            {
                string contents = string.Empty;

                if (string.IsNullOrEmpty(this._fileName))
                {
                    this._fileName = System.IO.Path.Combine(this._folderPath, string.Format(_logFileNameFormat, DateTime.Now));
                }

                contents = string.Format("[{0:HH:mm:ss}] {1}" + Environment.NewLine, DateTime.Now, text);

                if (!System.IO.Directory.Exists(this._folderPath))
                {
                    // ���O�t�H���_�����݂��Ȃ��ꍇ�͍쐬����
                    System.IO.Directory.CreateDirectory(this._folderPath);
                }

                // ���O�̒ǋL
                System.IO.File.AppendAllText(this._fileName, contents);
            }
        }
        //---ADD�@30757 ���X�؁@�M�p�@2015/01/26 Https�v���g�R�����M���R�}���h�����M����Ȃ��s��΍� ----------------<<<<<<
        # endregion 
     # endregion
    }
}