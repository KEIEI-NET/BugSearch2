//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : �|���}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  ********-** �쐬�S�� : FSI���� �f��
// �� �� ��  2013/06/12  �C�����e : �T�|�[�g�c�[���Ή��A�V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30521 �{�R�@�M�� 
// �C �� ��  2013.10.28  �C�����e : �|�����}�X�^�C���|�[�g�E�G�N�X�|�[�g�@�\�ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : K.Miura
// �C �� ��  2015/10/14   �C�����e : �N���X���d���̂��ߕύX 
//                                   StockMasWork �� RateTextWork
//                                   IStockMasDB �� IRateTextDB
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : ���V�@���M
// �C �� ��  2015/10/14   �C�����e : �N���X���d���̂��ߕύX 
//                                   MediationStockMasDB �� MediationRateTextDB
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using System.Runtime.InteropServices;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data;
using System.Text.RegularExpressions;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����}�X�^�i�C���|�[�g�j�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer : FSI���� �f��</br>
    /// <br>Date       : 2013/06/12</br>
    /// <br></br>
    /// </remarks>
    public class DepsitMainRfImportAcs
    {
        #region �� Constructor
        /// <summary>
        /// �|���}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public DepsitMainRfImportAcs()
        {
            #region Del 2013.10.28 T.MOTOYAMA
            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA DEL STA
            //// �|��DB���
            //this._DepsitMainAcs = MediationRateDB.GetRateDB();
            // 2013.10.28 T.MOTOYAMA DEL END ///////////////////////////////////////////////////////////////////
            #endregion
// --- CHG  2015/10/14 ���V�@���M --- >>>>
//          this._IStockMasDB = MediationStockMasDB.GetStockMasDB();  // Add 2013.10.28 T.MOTOYAMA
            this._IRateTextDB = MediationRateTextDB.GetRateTextDB();
// --- CHG  2015/10/14 ���V�@���M --- <<<<

            // ��ƃR�[�h
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        }

        /// <summary>
        /// �|���}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�i�C���|�[�g�j�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        static DepsitMainRfImportAcs()
        {

        }
        #endregion �� Constructor

        #region �� Static Member
        private static PrtOutSet stc_PrtOutSet;			            // ���[�o�͐ݒ�f�[�^�N���X
        private static PrtOutSetAcs stc_PrtOutSetAcs;	            // ���[�o�͐ݒ�A�N�Z�X�N���X

        /// <summary>
        /// ����f�[�^
        /// </summary>
        public static DataTable _printDataTable = null;

        #endregion �� Static Member

        #region �� Private Member

        private string _enterpriseCode;

        #region Del 2013.10.28 T.MOTOYAMA
        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA DEL STA
        //// �|���A�N�Z�X�N���X
        //private IRateDB _DepsitMainAcs;
        // 2013.10.28 T.MOTOYAMA DEL END ///////////////////////////////////////////////////////////////////
        #endregion

        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
        // �|���}�X�^�C���|�[�g�G�N�X�|�[�g�N���X
// --- CHG  2015/10/14 K.Miura --- >>>>
//        private IStockMasDB _IStockMasDB;
          private IRateTextDB _IRateTextDB;
// --- CHG  2015/10/14 K.Miura --- <<<<
        // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

        // CSV�f�[�^�̗�ԍ��Ɨ�
        private enum CSVColumnIndex
        {

            SectionCode = 0,          // ���_�R�[�h
            UnitRateSetDivCd = 1,     //�P���|���ݒ�敪
            UnitPriceKind = 2,        //�P�����
            RateSettingDivide = 3,    //�|���ݒ�敪
            RateMngGoodsCd = 4,       //�|���ݒ�敪(���i)
            RateMngGoodsNm = 5,       //�|���ݒ薼��(���i)
            RateMngCustCd = 6,        //�|���ݒ�敪(���Ӑ�)
            RateMngCustNm = 7,        //�|���ݒ薼��(���Ӑ�)
            GoodsMakerCd = 8,         //���i���[�J�[�R�[�h
            GoodsNo = 9,              //���i�ԍ�
            GoodsRateRank = 10,       //���i�|�������N
            GoodsRateGrpCode = 11,    //���i�|���O���[�v�R�[�h
            BLGroupCode = 12,         //BL�O���[�v�R�[�h
            BLGoodsCode = 13,         //BL���i�R�[�h
            CustomerCode = 14,        //���Ӑ�R�[�h
            CustRateGrpCode = 15,     //���Ӑ�|���O���[�v�R�[�h
            SupplierCd = 16,          //�d����R�[�h
            LotCount = 17,            //���b�g��
            PriceFl = 18,             //���i(����)
            RateVal = 19,             //�|��
            UpRate = 20,              //UP��
            GrsProfitSecureRate = 21, //�e���m�ۗ�
            UnPrcFracProcUnit = 22,   //�P���[�������P��
            UnPrcFracProcDiv = 23,    //�P���[�������敪

        }

        #endregion �� Private Member

        #region �� Const Member

        #endregion �� Const Member

        #region �� Public Method
        #region �� �e�L�X�g�̎捞�`�F�b�N����
        /// <summary>
        /// �e�L�X�g�̎捞�`�F�b�N����
        /// </summary>
        /// <param name="csvDataList">CSV�t�@�C���̓��e�f�[�^���X�g</param>
        /// <param name="checkOKArrList">�`�F�b�NOK�̃f�[�^���X�g</param>
        /// <param name="ReadCnt">Read����CSV�f�[�^�̍s��</param>
        /// <param name="ErrCnt">Read�������ʃG���[�����݂���CSV�f�[�^�̍s��</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁFtrue:�G���[����;false:�G���[�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�̎捞�`�F�b�N�������s���܂�</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        //public bool ImportCheck(object csvDataList, out List<string[]> checkOKArrList, out Int32 ReadCnt, out Int32 ErrCnt)                  // Del 2013.10.28 T.MOTOYAMA
        public bool ImportCheck(object csvDataList, out List<string[]> checkOKArrList, out Int32 ReadCnt, out Int32 ErrCnt, out string errMsg) // Add 2013.10.28 T.MOTOYAMA
        {
            // �G���[�t���O
            bool errFlg = false;
            // �G���[�s���X�g
            List<string[]> errList = new List<string[]>();
            // CSV�f�[�^
            List<string[]> lineStrList = (List<string[]>)csvDataList;
            // DB�֎捞����`�F�b�NOK�̃f�[�^���X�g
            checkOKArrList = new List<string[]>();

            int rowIndex = 0;
            // �G���[����������
            ErrCnt = 0;

            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
            // �G���[���b�Z�[�W
            errMsg = String.Empty;
            ReadCnt = 0;
            // ���ڍs�`�F�b�N�p�t���O
            bool CheckImportWorkflg = false;
            // ���_��񃊃X�g
            ArrayList secInfoList = new ArrayList();
            // ���_���N���X
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            // ��ƃR�[�h
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
            
            // �s�z�񃊃X�g���J��Ԃ��A�捞�`�F�b�N���s��
            for (rowIndex = 0; rowIndex <= lineStrList.Count - 1; rowIndex++)
            {
                // 1�s�f�[�^
                string[] strArr = lineStrList[rowIndex];

                bool errFlgSecCode = false;
                bool errFlgDate = false;
                bool errFlgDeposit = false;

                // msg�ϐ��ɂ�1�s�̃`�F�b�N���ɔ��������G���[���S�ď������
                string msg = string.Empty;

                ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //                
                // �@�f�[�^���s�����`�F�b�N����
                // �|���f�[�^
                RateWork depsitDataWork = new RateWork();
                int errRecord = 0;
                
                try
                {                    
                    if (rowIndex == 0)
                    {
                        // 1�s�ڂ����ڍs�ɂȂ��Ă��邩�`�F�b�N
                        CheckImportWorkflg = CheckImportWork(strArr);

                        if (CheckImportWorkflg == true)
                        {
                            continue;
                        }
                    }
                    
                    // �f�[�^�ϊ������Ŏ��s�����ꍇ�A���̍s���捞�Ώۂ���O��
                    depsitDataWork = CopyToDepsitDataWorkFromImportWork(strArr);
                }
                catch
                {
                    // 1�s�ڂ����ڍs����Ȃ��ꍇ
                    if (CheckImportWorkflg == false)
                        errRecord = rowIndex + 1;
                    // 1�s�ڂ����ڍs�̏ꍇ�A���̍s�̓J�E���g����O��
                    else
                        errRecord = rowIndex;
                    
                    errMsg = errRecord + "�s�ڂ̃f�[�^���s���ł��B";
                    errFlg = true;
                    ErrCnt = 1;
                    return errFlg;    
                }

                // �A���_�R�[�h�����������`�F�b�N����
                if (secInfoList.Count == 0)
                {
                    try
                    {
                        // ���_�f�[�^�擾
                        int status = secInfoSetAcs.Search(out secInfoList, this._enterpriseCode);
                    }
                    catch
                    {
                        errMsg = "���_���̎擾�Ɏ��s���܂����B";
                        errFlg = true;
                        return errFlg;
                    }
                }
                
                // CSV�̋��_�R�[�h
                string sectionCode = string.Format(strArr[(int)CSVColumnIndex.SectionCode]);

                // ���_�R�[�h�̃`�F�b�N���s��
                foreach (SecInfoSet secInfoSet in secInfoList)
                {
                    if (sectionCode != "00")
                    {
                        // ���ꋒ�_�R�[�h�����݂���Ζ�薳��
                        if (sectionCode == secInfoSet.SectionCode.Trim())
                        {
                            errFlg = false;
                            break;
                        }
                        else
                        {
                            errFlg = true;
                        }
                    }                    
                }

                // ���_�R�[�h���s��v�̏ꍇ
                if (errFlg == true)
                {
                    // 1�s�ڂ����ڍs����Ȃ��ꍇ
                    if (CheckImportWorkflg == false)
                        errRecord = rowIndex + 1;
                    // 1�s�ڂ����ڍs�̏ꍇ�A���̍s�̓J�E���g����O��
                    else
                        errRecord = rowIndex;

                    // ���_�R�[�h�����݂��Ȃ��ꍇ�A���b�Z�[�W�Ƃ��ĕ\������
                    errMsg = "���_�R�[�h�F" + sectionCode + " �͌��݂̊�Ƃɑ��݂��܂���B" + "\r\n"
                           + errRecord + " �s�ڂ̋��_�R�[�h���m�F���ĉ������B";                           
                    ErrCnt = 1;
                    return errFlg;
                }                                
                // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

                // ���Y�s�ɃG���[���ڂ��Ȃ��ꍇ�A�uDB�Ɏ捞�f�[�^���X�g�v�ɒu��
                if (errFlgSecCode == false &&
                    errFlgDate == false &&
                    errFlgDeposit == false)
                {
                    checkOKArrList.Add(strArr);
                }
                else
                {
                    ErrCnt++;

                    // �G���[�s��Length �� �� + 1
                    string[] errArr = new string[strArr.Length + 1];

                    // �s�f�[�^���G���[�s�ɃR�s�[����
                    strArr.CopyTo(errArr, 0);

                    // �G���[���b�Z�[�W���Ō��ɒu��
                    errArr[errArr.Length - 1] = msg;

                    errList.Add(errArr);
                }
            }

            // �`�F�b�N�I�����A�G���[�f�[�^������Έ���f�[�^���쐬����
            if (errList.Count > 0)
            {
                errFlg = true;

                PMKHN09824EA.CreatePrintDataTable(ref _printDataTable);

                foreach (string[] errStrs in errList)
                {

                    DataRow dr = _printDataTable.NewRow();
                    _printDataTable.Rows.Add(dr);

                }
            }
            
            // ReadCnt = rowIndex;       // Del 2013.10.28 T.MOTOYAMA

            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
            // ���ڍs�����݂���ꍇ�A�ǂݍ��ݍs����J�E���g��1����
            if (CheckImportWorkflg == true)
                ReadCnt = rowIndex - 1;
            else
                ReadCnt = rowIndex;
            // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

            return errFlg;
        }

        #region CSV���ڍs�`�F�b�N
        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
        /// <summary>
        /// ��s�ڂ����ڍs���`�F�b�N����
        /// </summary>
        /// <param name="csvRowData">CSV�f�[�^1�s</param>
        /// <returns>�`�F�b�N����(true:��肠��Afalse:���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note       : ��荞��CSV��1�s�ڂ����ڍs���`�F�b�N����</br>
        /// <br>Programmer : 30521 T.MOTOYAMA</br>
        /// <br>Date       : 2013.10.28</br>
        /// </remarks>
        private bool CheckImportWork(string[] csvRowData)
        {
            bool checkflg = false;

            // �e���ڍs�̖��̂������Ă��邩���f����(�S���͌��Ȃ��Ă��������E�E�E)
            if ("���_�R�[�h" == string.Format(csvRowData[(int)CSVColumnIndex.SectionCode]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("�P���|���ݒ�敪" == string.Format(csvRowData[(int)CSVColumnIndex.UnitRateSetDivCd]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("�P�����" == string.Format(csvRowData[(int)CSVColumnIndex.UnitPriceKind]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("�|���ݒ�敪" == string.Format(csvRowData[(int)CSVColumnIndex.RateSettingDivide]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("�|���ݒ�敪(���i)" == string.Format(csvRowData[(int)CSVColumnIndex.RateMngGoodsCd]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("�|���ݒ�敪(���Ӑ�)" == string.Format(csvRowData[(int)CSVColumnIndex.RateMngCustCd]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("�|���ݒ薼��(���Ӑ�)" == string.Format(csvRowData[(int)CSVColumnIndex.RateMngCustNm]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("���i���[�J�[�R�[�h" == string.Format(csvRowData[(int)CSVColumnIndex.GoodsMakerCd]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("���i�ԍ�" == string.Format(csvRowData[(int)CSVColumnIndex.GoodsNo]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("���i�|�������N" == string.Format(csvRowData[(int)CSVColumnIndex.GoodsRateRank]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("���i�|���O���[�v�R�[�h" == string.Format(csvRowData[(int)CSVColumnIndex.GoodsRateGrpCode]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("�|���ݒ薼��(���i)" == string.Format(csvRowData[(int)CSVColumnIndex.RateMngGoodsNm]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("�|���ݒ薼��(���i)" == string.Format(csvRowData[(int)CSVColumnIndex.RateMngGoodsNm]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("BL�O���[�v�R�[�h" == string.Format(csvRowData[(int)CSVColumnIndex.BLGroupCode]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("BL���i�R�[�h" == string.Format(csvRowData[(int)CSVColumnIndex.BLGoodsCode]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("���Ӑ�R�[�h" == string.Format(csvRowData[(int)CSVColumnIndex.CustomerCode]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("���Ӑ�|���O���[�v�R�[�h" == string.Format(csvRowData[(int)CSVColumnIndex.CustRateGrpCode]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("�d����R�[�h" == string.Format(csvRowData[(int)CSVColumnIndex.SupplierCd]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("���b�g��" == string.Format(csvRowData[(int)CSVColumnIndex.LotCount]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("���i(����)" == string.Format(csvRowData[(int)CSVColumnIndex.PriceFl]))
            {
                checkflg = true;
                return checkflg;
            }
           
            if ("�|��" == string.Format(csvRowData[(int)CSVColumnIndex.RateVal]))
            {
                checkflg = true;
                return checkflg;
            }
            
            if ("UP��" == string.Format(csvRowData[(int)CSVColumnIndex.UpRate]))
            {
                checkflg = true;
                return checkflg;
            }

            if ("�e���m�ۗ�" == string.Format(csvRowData[(int)CSVColumnIndex.GrsProfitSecureRate]))
            {
                checkflg = true;
                return checkflg;
            }

            if ("�P���[�������P��" == string.Format(csvRowData[(int)CSVColumnIndex.UnPrcFracProcUnit]))
            {
                checkflg = true;
                return checkflg;
            }

            if ("�P���[�������敪" == string.Format(csvRowData[(int)CSVColumnIndex.UnPrcFracProcDiv]))
            {
                checkflg = true;
                return checkflg;
            }

            return checkflg;
        }
        // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////        
        #endregion CSV���ڍs�`�F�b�N

        #endregion �� �e�L�X�g�̎捞�`�F�b�N����

        #region �� ���[�o�͐ݒ�擾����
        /// <summary>
        /// ���[�o�͐ݒ�Ǎ�
        /// </summary>
        /// <param name="retPrtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note        : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
        /// <br>Programmer	: FSI���� �f��</br>
        /// <br>Date        : 2013/06/12</br>
        /// <br></br>
        /// </remarks>
        public static int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = string.Empty;

            try
            {
                // �f�[�^�͓Ǎ��ς݂��H
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    if (stc_PrtOutSetAcs == null)
                        stc_PrtOutSetAcs = new PrtOutSetAcs();

                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #endregion �� Public Method

        #region �� Private Method

        #region �� �C���|�[�g����

        #region Del 2013.10.28 T.MOTOYAMA
        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA DEL STA
        ///// <summary>
        ///// �C���|�[�g����
        ///// </summary>
        ///// <param name="importWorkTbl">�C���|�[�g���[�N</param>
        ///// <param name="addCnt">�ǉ�����</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>Status</returns>
        ///// <remarks>
        ///// <br>Note       : �|���}�X�^�i�C���|�[�g�j�������s���B(U�N���X����R�[�������)</br>
        ///// <br>Programmer : FSI���� �f��</br>
        ///// <br>Date       : 2013/06/12</br>
        ///// </remarks>
        //public int Import(DepsitMainRfImportWorkTbl importWorkTbl, out Int32 addCnt, out string errMsg)
        //{
        //    return this.ImportProc(importWorkTbl, out addCnt, out errMsg);
        //}
        // 2013.10.28 T.MOTOYAMA DEL END ///////////////////////////////////////////////////////////////////
        #endregion

        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
        /// <summary>
        /// �C���|�[�g����
        /// </summary>
        /// <param name="importWorkTbl">�C���|�[�g���[�N</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="errCnt">�G���[����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="writestatus">�X�V�����@1:�ǉ��@2:�X�V�@3:�ǉ��{�X�V</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�i�C���|�[�g�j�������s���B(U�N���X����R�[�������)</br>
        /// <br>Programmer : 30521 T.MOTOYAMA</br>
        /// <br>Date       : 2013.10.28</br>
        /// </remarks>
        public int Import(DepsitMainRfImportWorkTbl importWorkTbl, int writestatus, out Int32 addCnt, out Int32 errCnt, out string errMsg)
        {
            return this.ImportProc(importWorkTbl, writestatus, out addCnt, out errCnt, out errMsg);
        }
        // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// �C���|�[�g����
        /// </summary>
        /// <param name="importWorkTbl">�C���|�[�g���[�N</param>
        /// <param name="writestatus">�X�V�����@1:�ǉ��@2:�X�V�@3:�ǉ��{�X�V</param>    // Add 2013.10.28 T.MOTOYAMA
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="errCnt">�G���[����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �����}�X�^�i�C���|�[�g�j�������s���B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        // private int ImportProc(DepsitMainRfImportWorkTbl importWorkTbl, out Int32 addCnt, out string errMsg)   // Del 2013.10.28 T.MOTOYAMA
        private int ImportProc(DepsitMainRfImportWorkTbl importWorkTbl, int writestatus, out Int32 addCnt, out Int32 errCnt, out string errMsg)  // Add 2013.10.28 T.MOTOYAMA
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            addCnt = 0;
            errCnt = 0;

            if (importWorkTbl == null || importWorkTbl.CsvDataInfoList.Count == 0)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = "importWorkTbl�Ƀf�[�^������܂���";
                return status;
            }

            // �|���f�[�^
            // ����Import�����ł͎g�p���Ȃ��ׁA��f�[�^(0�����z��)�����
            // ���[�v�̊O�Œ�`���Ďg���܂킷
            DepositAlwWork[] depositAlwWorkList = CopyToDepositAlwWork();

            // CSV�t�@�C��1�s�ɑ΂��ăf�[�^�쐬���s��Write���R�[��
            foreach (string[] csvRowData in importWorkTbl.CsvDataInfoList)
            {
                // �|���f�[�^
                RateWork depsitDataWork = new RateWork();
                depsitDataWork = CopyToDepsitDataWorkFromImportWork(csvRowData);

                object rateWork = depsitDataWork;

                try
                {
                    #region Del 2013.10.28 T.MOTOYAMA
                    ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA DEL STR //
                    //// DB��Write�v������
                    //status = _DepsitMainAcs.Write(ref rateWork);
                    // 2013.10.28 T.MOTOYAMA DEL END /////////////////////////////////////////////////////////////////////
                    #endregion

                    ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
                    // DB��Write�v������
                    status = _IRateTextDB.Write(ref rateWork, writestatus);
                    // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////                    

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        addCnt++;
                    }
                    ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
                    else
                    {
                        errMsg = "�s���f�[�^������ׁA�ꕔ�̃f�[�^�̎捞������Ă��܂���B";
                        errCnt++;
                    }
                    // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
                                        
                    #region Del 2013.10.28
                    ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA DEL STA
                    //else
                    //{
                    //    break;
                    //}
                    // 2013.10.28 T.MOTOYAMA DEL END ///////////////////////////////////////////////////////////////////                    
                    #endregion
                }
                catch (Exception ex)
                {
                    errMsg = ex.Message;
                    break;
                }
            }
            return status;
        }
        #endregion �� �C���|�[�g����

        #region �� �f�[�^�쐬�ϊ�����
        /// <summary>
        /// �C���|�[�g���[�N���|���}�X�^���[�N�փR�s�[���s��
        /// </summary>
        /// <param name="csvRowData">CSV�f�[�^1�s</param>
        /// <returns>�R�s�[���s����DepsitDataWork��Ԃ�</returns>
        /// <remarks>
        /// <br>Note       : �C���|�[�g���[�N���|���}�X�^���[�N�փR�s�[���s��</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private RateWork CopyToDepsitDataWorkFromImportWork(string[] csvRowData)
        {
            RateWork depsitDataWork = new RateWork();

            depsitDataWork.EnterpriseCode = this._enterpriseCode;                     // ��ƃR�[�h

            depsitDataWork.SectionCode = string.Format(csvRowData[(int)CSVColumnIndex.SectionCode]);//���_�R�[�h
            depsitDataWork.UnitRateSetDivCd = string.Format(csvRowData[(int)CSVColumnIndex.UnitRateSetDivCd]);//�P���|���ݒ�敪
            depsitDataWork.UnitPriceKind = string.Format(csvRowData[(int)CSVColumnIndex.UnitPriceKind]);//�P�����
            depsitDataWork.RateSettingDivide = string.Format(csvRowData[(int)CSVColumnIndex.RateSettingDivide]);//�|���ݒ�敪
            depsitDataWork.RateMngGoodsCd = string.Format(csvRowData[(int)CSVColumnIndex.RateMngGoodsCd]);//�|���ݒ�敪�i���i�j
            depsitDataWork.RateMngGoodsNm = string.Format(csvRowData[(int)CSVColumnIndex.RateMngGoodsNm]);//�|���ݒ薼�́i���i�j
            depsitDataWork.RateMngCustCd = string.Format(csvRowData[(int)CSVColumnIndex.RateMngCustCd]);//�|���ݒ�敪�i���Ӑ�j
            depsitDataWork.RateMngCustNm = string.Format(csvRowData[(int)CSVColumnIndex.RateMngCustNm]);//�|���ݒ薼�́i���Ӑ�j
            depsitDataWork.GoodsMakerCd = int.Parse(csvRowData[(int)CSVColumnIndex.GoodsMakerCd]);//���i���[�J�[�R�[�h
            depsitDataWork.GoodsNo = string.Format(csvRowData[(int)CSVColumnIndex.GoodsNo]);//���i�ԍ�
            depsitDataWork.GoodsRateRank = string.Format(csvRowData[(int)CSVColumnIndex.GoodsRateRank]);//���i�|�������N
            depsitDataWork.GoodsRateGrpCode = int.Parse(csvRowData[(int)CSVColumnIndex.GoodsRateGrpCode]);//���i�|���O���[�v�R�[�h
            depsitDataWork.BLGroupCode = int.Parse(csvRowData[(int)CSVColumnIndex.BLGroupCode]);//BL�O���[�v�R�[�h
            depsitDataWork.BLGoodsCode = int.Parse(csvRowData[(int)CSVColumnIndex.BLGoodsCode]);//BL���i�R�[�h
            depsitDataWork.CustomerCode = int.Parse(csvRowData[(int)CSVColumnIndex.CustomerCode]);//���Ӑ�R�[�h
            depsitDataWork.CustRateGrpCode = int.Parse(csvRowData[(int)CSVColumnIndex.CustRateGrpCode]);//���Ӑ�|���O���[�v�R�[�h
            depsitDataWork.SupplierCd = int.Parse(csvRowData[(int)CSVColumnIndex.SupplierCd]);//�d����R�[�h
            depsitDataWork.LotCount = double.Parse(csvRowData[(int)CSVColumnIndex.LotCount]);//���b�g��
            depsitDataWork.PriceFl = double.Parse(csvRowData[(int)CSVColumnIndex.PriceFl]);//���i�i�����j
            depsitDataWork.RateVal = double.Parse(csvRowData[(int)CSVColumnIndex.RateVal]);//�|��
            depsitDataWork.UpRate = double.Parse(csvRowData[(int)CSVColumnIndex.UpRate]);//UP��
            depsitDataWork.GrsProfitSecureRate = double.Parse(csvRowData[(int)CSVColumnIndex.GrsProfitSecureRate]);//�e���m�ۗ�
            depsitDataWork.UnPrcFracProcUnit = double.Parse(csvRowData[(int)CSVColumnIndex.UnPrcFracProcUnit]);//�P���[�������P��
            depsitDataWork.UnPrcFracProcDiv = int.Parse(csvRowData[(int)CSVColumnIndex.UnPrcFracProcDiv]);//�P���[�������敪

            return depsitDataWork;
        }

        /// <summary>
        /// DepositAlwWork�̋�f�[�^�쐬����
        /// </summary>
        /// <returns>DepositAlwWork�̋�f�[�^1�����z��</returns>
        /// <remarks>
        /// <br>Note       : DepositAlwWork�̋�f�[�^�쐬���s��</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private DepositAlwWork[] CopyToDepositAlwWork()
        {
            // �����̃f�[�^�͎g�p���Ȃ��̂ŋ�z���Ԃ�
            DepositAlwWork[] depositAlwWork = new DepositAlwWork[0];

            return depositAlwWork;
        }

        #endregion �� �f�[�^�쐬�ϊ�����

        #endregion �� Private Method

    }
}
