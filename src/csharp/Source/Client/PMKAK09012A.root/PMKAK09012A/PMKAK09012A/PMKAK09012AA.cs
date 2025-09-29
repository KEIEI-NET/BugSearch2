//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���摍���}�X�^�ꗗ�\�A�N�Z�X�N���X
// �v���O�����T�v   : �d���摍���}�X�^�ꗗ�\�Ŏg�p����f�[�^���擾����
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�             �쐬�S�� : FSI�����@�v
// �� �� ��  2012/09/07 �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �d���摍���}�X�^�ꗗ�\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���摍���}�X�^�ꗗ�\�Ŏg�p����f�[�^���擾����</br>
    /// <br>Programmer : FSI�����@�v</br>
    /// <br>Date       : 2012/09/07</br>
    /// </remarks>
    public class SumSuppStPrintAcs
    {
        #region �� Constructor
		/// <summary>
		/// �d���摍���}�X�^�ꗗ�\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �d���摍���}�X�^�ꗗ�\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date	   : 2012/09/07</br>
        /// </remarks>
        public SumSuppStPrintAcs()
		{
            this._iSumSuppStResultDB = (ISumSuppStPrintResultDB)MediationSumSuppStPrintResultDB.GetSumSuppStPrintResultDB();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._secInfoSetAcs = new SecInfoSetAcs();
            this._supplierAcs = new SupplierAcs();

            // �L���b�V��������
            DeleteAllFromCacheForSecInfoSet();
            DeleteAllFromCacheForSupplier();
		}

        #endregion �� Constructor

        #region �� Private Member
        // �d���摍���}�X�^�ꗗ�\�C���^�t�F�[�X
        private ISumSuppStPrintResultDB _iSumSuppStResultDB;

        // ���_���ݒ�}�X�^�A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs;

        // �d����}�X�^�A�N�Z�X�N���X
        private SupplierAcs _supplierAcs;

        // DataSet�I�u�W�F�N�g
        private DataSet _dataSet;

        // ��ƃR�[�h
        private string _enterpriseCode;

        // static���[�J���L���b�V��
        private static Dictionary<string, SecInfoSet> _secInfoSetDic;  // ���_���ݒ�}�X�^
        private static Dictionary<int, Supplier> _supplierDic;         // �d����}�X�^

        #endregion �� Private Member

        #region �� Public Property
        /// <summary>
        /// �f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataSet DataSet
        {
            get { return this._dataSet; }
        }
        #endregion �� Public Property

        #region �� Public Method
        #region �� �o�̓f�[�^�擾
        #region �� �d���摍���}�X�^�ꗗ�\�f�[�^�擾
        /// <summary>
        /// �d���摍���}�X�^�ꗗ�\�f�[�^�擾
        /// </summary>
        /// <param name="sumSuppStPrintParaWork">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������d���摍���}�X�^�ꗗ�\�f�[�^���擾����B</br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date	   : 2012/09/07</br>
        /// </remarks>
        public int SearchSumSuppStPrintProcMain(SumSuppStPrintUIParaWork sumSuppStPrintParaWork, out string errMsg)
        {
            return this.SearchSumSuppStPrintProc(sumSuppStPrintParaWork, out errMsg);
        }
        #endregion
        #endregion �� �o�̓f�[�^�擾
        #endregion �� Public Method

        #region �� Private Method
        #region �� ���[�f�[�^�擾
        #region �� �f�[�^�擾
        /// <summary>
        /// �f�[�^�擾
        /// </summary>
        /// <param name="sumSuppStPrintParaWork"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������d���摍���}�X�^�ꗗ�\�f�[�^���擾����B</br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date	   : 2012/09/07</br>
        /// </remarks>
        private int SearchSumSuppStPrintProc(SumSuppStPrintUIParaWork sumSuppStPrintParaWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            ArrayList sumSuppStList = null;

            try
            {
                #region [�d����}�X�^�i�����ݒ�j����]

                // DataTable���쐬
                PMKAK09015EA.CreateDataTable(ref _dataSet);

                // R�N���X�ւ̒��o������ݒ�
                SumSuppStPrintParaWork sumSuppStParaWork = new SumSuppStPrintParaWork();
                status = this.SetCondInfo(ref sumSuppStPrintParaWork, out sumSuppStParaWork, out errMsg);

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // R�N���X��Search���\�b�h�R�[���p�ɐ��`
                object retList = null;
                object paraWorkRef = sumSuppStParaWork;

                // Search���\�b�h�R�[��
                status = _iSumSuppStResultDB.Search(out retList, paraWorkRef);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        sumSuppStList = (ArrayList)retList;
                        if (sumSuppStList.Count <= 0 )
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        retList = null;
                        break;

                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "�d�������}�X�^�ꗗ�̏o�̓f�[�^�̎擾�Ɏ��s���܂����B";
                        break;
                }

                #endregion

                #region [���̕ҏW�̂��߂̃f�[�^������DataSet�ւ̃f�[�^�W�J]

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    #region [���_���ݒ�}�X�^�f�[�^�擾]

                    // ���_���ݒ�}�X�^�S������
                    ArrayList wkRetList = new ArrayList();
                    status = this._secInfoSetAcs.Search(out wkRetList, this._enterpriseCode);

                    // �������ʔ���
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            if (wkRetList != null)
                            {
                                foreach (SecInfoSet wkLineupWork in wkRetList)
                                {
                                    // �擾�������_���ݒ�}�X�^����S���L���b�V��
                                    UpdateCacheForSecInfoSet(wkLineupWork);
                                }
                            }

                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                        break;
                    default:
                        return status;
                    }

                    #endregion

                    #region [�d����}�X�^�f�[�^�擾]

                    // �d����}�X�^�S������
                    wkRetList = new ArrayList();
                    status = this._supplierAcs.Search(out wkRetList, this._enterpriseCode);

                    // �������ʔ���
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            if (wkRetList != null)
                            {
                                foreach (Supplier wkLineupWork in wkRetList)
                                {
                                    // �擾�����d����}�X�^����S���L���b�V��
                                    UpdateCacheForSupplier(wkLineupWork);
                                }
                            }

                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                            status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                            break;
                        default:
                            return status;
                    }

                    #endregion
                        
                    #region [DatSet�ւ̃f�[�^�W�J�A�����ɖ��̕ҏW]

                    if(status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        ConverToDataSet(_dataSet.Tables[PMKAK09015EA.ct_Tbl_SumSuppStReportData], sumSuppStList);
                    }
                        
                    #endregion
                }

                #endregion

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            finally
            {
                // �L���b�V���͏�����
                DeleteAllFromCacheForSecInfoSet();
                DeleteAllFromCacheForSupplier();
            }
            return status;
        }
        #endregion
        #endregion �� ���[�f�[�^�擾

        #region �� �f�[�^�W�J����

        #region �� ���o�����W�J����
        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="sumSuppStPrintUIParaWork">UI���o�����N���X</param>
        /// <param name="sumSuppStPrintParaWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���o�����W�J�������s��</br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date	   : 2012/09/07</br>
        /// </remarks>
        private int SetCondInfo(ref SumSuppStPrintUIParaWork sumSuppStPrintUIParaWork, out SumSuppStPrintParaWork sumSuppStPrintParaWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            sumSuppStPrintParaWork = new SumSuppStPrintParaWork();

            try
            {
                // ��ƃR�[�h
                sumSuppStPrintParaWork.EnterpriseCode = sumSuppStPrintUIParaWork.EnterpriseCode;

                // �������_�R�[�h�J�n
                sumSuppStPrintParaWork.SectionCodeSt = sumSuppStPrintUIParaWork.SumSectionCodeSt;

                // �������_�R�[�h�I��
                sumSuppStPrintParaWork.SectionCodeEd = sumSuppStPrintUIParaWork.SumSectionCodeEd;

                // �����d����R�[�h�J�n
                sumSuppStPrintParaWork.SupplierCodeSt = sumSuppStPrintUIParaWork.SumSupplierCdSt;

                // �����d����R�[�h�I��
                sumSuppStPrintParaWork.SupplierCodeEd = sumSuppStPrintUIParaWork.SumSupplierCdEd;

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region ���L���b�V�����䏈��

        /// <summary>
        /// �L���b�V���X�V�����i���_���ݒ�}�X�^�j
        /// </summary>
        /// <param name="cashData"></param>
        /// <remarks>
        /// <br>�L���b�V���֋��_���f�[�^���������݂܂��B</br>
        /// <br>Programmer : FSI���� �v</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private void UpdateCacheForSecInfoSet(SecInfoSet cashData)
        {
            // static�f�B�N�V���i����������ΐ���
            if (_secInfoSetDic == null)
            {
                _secInfoSetDic = new Dictionary<string, SecInfoSet>();
            }

            // �����Ȃ�΍폜
            if (_secInfoSetDic.ContainsKey(cashData.SectionCode))
            {
                _secInfoSetDic.Remove(cashData.SectionCode);
            }
            // �ǉ�
            _secInfoSetDic.Add(cashData.SectionCode, cashData);
        }

        /// <summary>
        /// �L���b�V���Ǎ������i���_���ݒ�}�X�^�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>�L���b�V�����狒�_���f�[�^��ǂݍ��݂܂��B</br>
        /// <br>Programmer : FSI���� �v</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private SecInfoSet GetFromCacheForSecInfoSet(string sectionCode)
        {
            if (_secInfoSetDic != null)
            {
                // �L���b�V������擾
                if (_secInfoSetDic.ContainsKey(sectionCode))
                {
                    return _secInfoSetDic[sectionCode];
                }
            }

            return null;
        }

        /// <summary>
        /// �L���b�V���S�폜�����i���_���ݒ�}�X�^�j
        /// </summary>
        /// <remarks>
        /// <br>�L���b�V�������������邱�ƂŃf�[�^�����ׂč폜���܂��B</br>
        /// <br>Programmer : FSI���� �v</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        public void DeleteAllFromCacheForSecInfoSet()
        {
            _secInfoSetDic = new Dictionary<string, SecInfoSet>();
        }

        /// <summary>
        /// �L���b�V���X�V�����i�d����}�X�^�j
        /// </summary>
        /// <param name="cashData"></param>
        /// <remarks>
        /// <br>�L���b�V���֋��_���f�[�^���������݂܂��B</br>
        /// <br>Programmer : FSI���� �v</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private void UpdateCacheForSupplier(Supplier cashData)
        {
            // static�f�B�N�V���i����������ΐ���
            if (_supplierDic == null)
            {
                _supplierDic = new Dictionary<int, Supplier>();
            }

            // �����Ȃ�΍폜
            if (_supplierDic.ContainsKey(cashData.SupplierCd))
            {
                _supplierDic.Remove(cashData.SupplierCd);
            }
            // �ǉ�
            _supplierDic.Add(cashData.SupplierCd, cashData);
        }

        /// <summary>
        /// �L���b�V���Ǎ������i�d����}�X�^�j
        /// </summary>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>�L���b�V�����狒�_���f�[�^��ǂݍ��݂܂��B</br>
        /// <br>Programmer : FSI���� �v</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private Supplier GetFromCacheForSupplier(int supplierCode)
        {
            if (_supplierDic != null)
            {
                // �L���b�V������擾
                if (_supplierDic.ContainsKey(supplierCode))
                {
                    return _supplierDic[supplierCode];
                }
            }

            return null;
        }

        /// <summary>
        /// �L���b�V���S�폜�����i���_���ݒ�}�X�^�j
        /// </summary>
        /// <remarks>
        /// <br>�L���b�V�������������邱�ƂŃf�[�^�����ׂč폜���܂��B</br>
        /// <br>Programmer : FSI���� �v</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        public void DeleteAllFromCacheForSupplier()
        {
            _supplierDic = new Dictionary<int, Supplier>();
        }

        #endregion

        #region �� �擾�f�[�^�W�J����
        /// <summary>
        /// DataTable�Ƀf�[�^��ݒ菈��
        /// </summary>
        /// <param name="dataTable">���[�pDataTable</param>
        /// <param name="retList">������񃊃X�g</param>
        /// <remarks>
        /// <br>Note       : DataTable�Ƀf�[�^��ݒ菈�����s��</br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/09/07</br>
        /// </remarks>
        private void ConverToDataSet(DataTable dataTable, ArrayList retList)
        {
            DataRow dr = null;
            SumSuppStPrintResultWork rsltInfo = null;
            SecInfoSet secInfoSet = null;
            Supplier supplier = null;

            for (int cnt = 0; cnt < retList.Count; cnt++)
            {
                rsltInfo = (SumSuppStPrintResultWork)retList[cnt];

                dr = dataTable.NewRow();

                // �������_�R�[�h
                dr[PMKAK09015EA.ct_Col_SumSectionCd] = rsltInfo.SumSectionCd;

                // �������_��
                // �L���b�V������Y������f�[�^���擾
                secInfoSet = GetFromCacheForSecInfoSet(rsltInfo.SumSectionCd);
                if (secInfoSet == null)
                {
                    // �f�[�^���擾�ł��Ȃ������ꍇ�́A�󔒂�ݒ�
                    dr[PMKAK09015EA.ct_Col_SumSectionGuideSnm] = string.Empty;
                }
                else
                {
                    // �f�[�^���擾�ł����̂ŗ��̂�ݒ�
                    dr[PMKAK09015EA.ct_Col_SumSectionGuideSnm] = secInfoSet.SectionGuideSnm;
                }

                // �����d����R�[�h
                dr[PMKAK09015EA.ct_Col_SumSupplierCd] = rsltInfo.SumSupplierCd;

                // �����d���於
                // �L���b�V������Y������f�[�^���擾
                supplier = GetFromCacheForSupplier(rsltInfo.SumSupplierCd);
                if (supplier == null)
                {
                    // �f�[�^���擾�ł��Ȃ������ꍇ�́A�󔒂�ݒ�
                    dr[PMKAK09015EA.ct_Col_SumSupplierNm1] = string.Empty;
                    dr[PMKAK09015EA.ct_Col_SumSupplierNm2] = string.Empty;
                }
                else
                {
                    // �f�[�^���擾�ł����̂Ŗ��̂P�A���̂Q��ݒ�
                    dr[PMKAK09015EA.ct_Col_SumSupplierNm1] = supplier.SupplierNm1;
                    dr[PMKAK09015EA.ct_Col_SumSupplierNm2] = supplier.SupplierNm2;
                }

                // ���_�R�[�h
                dr[PMKAK09015EA.ct_Col_SectionCd] = rsltInfo.SectionCode;

                // ���_��
                // �L���b�V������Y������f�[�^���擾
                secInfoSet = GetFromCacheForSecInfoSet(rsltInfo.SectionCode);
                if (secInfoSet == null)
                {
                    // �f�[�^���擾�ł��Ȃ������ꍇ�́A�󔒂�ݒ�
                    dr[PMKAK09015EA.ct_Col_SectionGuideSnm] = string.Empty;
                }
                else
                {
                    // �f�[�^���擾�ł����̂ŗ��̂�ݒ�
                    dr[PMKAK09015EA.ct_Col_SectionGuideSnm] = secInfoSet.SectionGuideSnm;
                }

                // �d����R�[�h
                dr[PMKAK09015EA.ct_Col_SupplierCd] = rsltInfo.SupplierCode;

                // �d���於
                // �L���b�V������Y������f�[�^���擾
                supplier = GetFromCacheForSupplier(rsltInfo.SupplierCode);
                if (supplier == null)
                {
                    // �f�[�^���擾�ł��Ȃ������ꍇ�́A�󔒂�ݒ�
                    dr[PMKAK09015EA.ct_Col_SupplierNm1] = string.Empty;
                    dr[PMKAK09015EA.ct_Col_SupplierNm2] = string.Empty;
                }
                else
                {
                    // �f�[�^���擾�ł����̂Ŗ��̂P�A���̂Q��ݒ�
                    dr[PMKAK09015EA.ct_Col_SupplierNm1] = supplier.SupplierNm1;
                    dr[PMKAK09015EA.ct_Col_SupplierNm2] = supplier.SupplierNm2;
                }

                dataTable.Rows.Add(dr);
            }
        }
        #endregion

        #endregion �� �f�[�^�W�J����

        #endregion �� Private Method
    }
}
