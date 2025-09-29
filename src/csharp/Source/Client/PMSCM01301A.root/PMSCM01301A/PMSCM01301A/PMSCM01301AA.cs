//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : BLP���Аݒ�}�X�^�q�Ɉڍs
// �v���O�����T�v   : BLP���Аݒ�}�X�^�q�Ɉڍs�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �O�ˁ@�L��
// �� �� ��  2012/12/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g���@�F��
// �C �� ��  2013/01/07  �C�����e : 1/16�z�M�V�X�e����Q��44�A��45 �Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using System.Runtime.Remoting;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller.Util;
using System.Configuration;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// BLP���Аݒ�}�X�^�q�Ɉڍs�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLP���Аݒ�}�X�^�q�Ɉڍs�t�h�N���X</br>
    /// <br>Programmer : �O�ˁ@�L��</br>
    /// <br>Date	   : 2012/12/14</br>
    /// </remarks>  
    public class PccCmpnyStAcs
    {
        /// <summary>
        /// �����[�g�I�u�W�F�N�g�C���^�[�t�F�C�X
        /// </summary>
        private IPccCmpnyStDB _IPccCmpnyStDB;       // BLP���Аݒ�}�X�^
        private CustomerInfoAcs _customerInfoAcs;   // ���Ӑ�}�X�^
        private PosTerminalMgAcs _posTerminalMgAcs; // POS�[���Ǘ��}�X�^
        private SCMTtlStAcs _scmTtlStAcs;           // SCM�S�̐ݒ�
        private WarehouseAcs _warehouseAcs;         // �q�Ƀ}�X�^
        private SecInfoSetAcs _secInfoSetAcs;       // ���_�ݒ�
        private ScmEpScCntAcs _scmEpScCntAcs;	    // SCM��Ƌ��_�A���A�N�Z�X�N���X

        //���Ӑ�
        private Hashtable _customerInfoTable;
        private const string CUSTOMEMPTY_BASE = "�x�[�X�ݒ�";
        private const string CONFIG_FILE = "PMSCM01300U.exe.config";
        private const string RUN_IKO = "RunIko";

        #region �� Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// </remarks>
        public PccCmpnyStAcs()
        {
            this._IPccCmpnyStDB = MediationPccCmpnyStDB.GetPccCmpnyStDB();      // BLP���Аݒ�}�X�^
            this._customerInfoAcs = new CustomerInfoAcs();                      // ���Ӑ�}�X�^
            this._posTerminalMgAcs = new PosTerminalMgAcs();                    // POS�[���Ǘ��}�X�^
            this._scmTtlStAcs = new SCMTtlStAcs();                              // SCM�S�̐ݒ�
            this._warehouseAcs = new WarehouseAcs();                            // �q�Ƀ}�X�^
            this._secInfoSetAcs = new SecInfoSetAcs();                          // ���_�ݒ�
            this._scmEpScCntAcs = new ScmEpScCntAcs();                          // SCM�A�����Ƌ��_�f�[�^

            this._customerInfoTable = new Hashtable();                          // ���Ӑ�}�X�^
        }
        #endregion �� Constructor

        /// <summary>
        /// BLP���Аݒ�}�X�^�q�Ɉڍs��������
        /// </summary>
        /// <param name="parsePccCmpnySt">�����p�����[�^</param>
        /// <param name="batch">�o�b�`����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : BLP���Аݒ�}�X�^�q�Ɉڍs��������</br>
        /// <br>Programmer : �O�ˁ@�L��</br>
        /// <br>Date       : 2012/12/14</br>
        /// </remarks>
        public int Search(PccCmpnySt parsePccCmpnySt, bool batch)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            PosTerminalMg _posTerminalMg = null;                            // POS�[���Ǘ��}�X�^
            SCMTtlSt _scmTtlSt = null;                                      // SCM�S�̐ݒ�
            List<CustomerInfo> customerInfoList = null;                     // ���Ӑ�}�X�^
            PccCmpnyStWork parsePccCmpnyStWork = null;                      // BLP���Аݒ�}�X�^
            List<PccCmpnySt> pccCmpnyStList = new List<PccCmpnySt>();       // BLP���Аݒ�}�X�^
            Object objPccCmpnyStWorkList = null;                            // BLP���Аݒ�}�X�^
            ArrayList pccCmpnyStWorkResultList = null;                      // BLP���Аݒ�}�X�^
            ArrayList WarehouseList = null;                                 // �q�Ƀ}�X�^
            ArrayList secInfoSets = null;                                   // ���_�ݒ�
            List<ScmEpScCnt> scmEpScCntList;                                // SCM�A�����Ƌ��_�f�[�^

            if (parsePccCmpnySt == null) return -1; // �p�����[�^���ݒ�
            // �o�b�`��������
            if (batch)
            {
                // ���[���̒[���ԍ����擾
                status = this._posTerminalMgAcs.Search(out _posTerminalMg, parsePccCmpnySt.InqOtherEpCd);
                
                // SCM�S�̐ݒ�擾
                this._scmTtlStAcs.Read(out _scmTtlSt, parsePccCmpnySt.InqOtherEpCd, parsePccCmpnySt.InqOtherSecCd.Trim());
                if (_scmTtlSt == null) this._scmTtlStAcs.Read(out _scmTtlSt, parsePccCmpnySt.InqOtherEpCd, "00");
                
                // ��M�[������
                if (_posTerminalMg.CashRegisterNo != _scmTtlSt.CashRegisterNo) return -2; // ���[������M�����[���ł͂Ȃ��ꍇ���s���Ȃ�

                // �ŏ��̂P��̂ݎ��s
                if (ConfigurationManager.AppSettings[RUN_IKO] != null)
                {
                    if (ConfigurationManager.AppSettings[RUN_IKO].Equals("1")) return -3; //�Q��ڈȍ~
                }
            }

            try
            {
                EasyLogger.Write(DateTime.Now + "�F�q�Ɉڍs�����J�n��������");

                // ���Ӑ�}�X�^�擾
                if (this._customerInfoAcs.Search(parsePccCmpnySt.InqOtherEpCd, true, true, out customerInfoList) != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return -4; // ���Ӑ�}�X�^�擾���s
                foreach (CustomerInfo customerInfo in customerInfoList)
                {
                    this._customerInfoTable.Add(customerInfo.CustomerCode, customerInfo.CustomerSnm);
                }

                // BLP���Аݒ�}�X�^�擾
                pccCmpnyStList.Add(parsePccCmpnySt);
                this.CopyCmpnyStToWork(out pccCmpnyStWorkResultList, pccCmpnyStList);
                parsePccCmpnyStWork = pccCmpnyStWorkResultList[0] as PccCmpnyStWork;
                parsePccCmpnyStWork.InqOtherSecCd = ""; // �S���_�擾
                status = _IPccCmpnyStDB.Search(out objPccCmpnyStWorkList, parsePccCmpnyStWork, 0, ConstantManagement.LogicalMode.GetData01);

                // ���ʂ�߂�
                pccCmpnyStWorkResultList = objPccCmpnyStWorkList as ArrayList;
                if (pccCmpnyStWorkResultList != null) this.CopyWorkToCmpnySt(pccCmpnyStWorkResultList, out pccCmpnyStList);

                // �q�Ƀ}�X�^�擾
                if (this._warehouseAcs.Search(out WarehouseList, parsePccCmpnySt.InqOtherEpCd) != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return -5; // �q�Ƀ}�X�^�擾���s
                
                // ���_�ݒ�擾
                if (this._secInfoSetAcs.Search(out secInfoSets, parsePccCmpnySt.InqOtherEpCd) != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return -6; // ���_�ݒ�擾���s

                // SCM�A�����Ƌ��_�f�[�^�擾
                bool msgDiv;
                string errMsg;
                if (this._scmEpScCntAcs.SearchCnectOriginalEpFromSc(parsePccCmpnySt.InqOtherEpCd, ConstantManagement.LogicalMode.GetData0, out scmEpScCntList, out msgDiv, out errMsg) != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return -7; // SCM�A�����Ƌ��_�f�[�^�擾���s
                foreach (ScmEpScCnt scmEpScCnt in scmEpScCntList)
                {
                    List<PccCmpnySt> pccCmpnyStWriteList = new List<PccCmpnySt>();
                    bool insertFlg = true;  // BLP���Аݒ�}�X�^�ɓo�^���邩�̔���t���O

                    if (pccCmpnyStList != null)
                    {
                        foreach (PccCmpnySt pccCmpnySt in pccCmpnyStList)
                        {
                            // BLP���Аݒ�}�X�^�ɓo�^����Ă��邩����
                            if (pccCmpnySt.InqOtherEpCd == scmEpScCnt.CnectOtherEpCd
                                && pccCmpnySt.InqOtherSecCd == scmEpScCnt.CnectOtherSecCd
                                && pccCmpnySt.InqOriginalEpCd.Trim() == scmEpScCnt.CnectOriginalEpCd.Trim() //@@@@20230303
                                && pccCmpnySt.InqOriginalSecCd == scmEpScCnt.CnectOriginalSecCd)
                            {
                                if (pccCmpnySt.LogicalDeleteCode == 0)
                                {
                                    // ���ɓo�^��
                                    insertFlg = false;
                                    break;
                                }
                                else
                                {
                                    // �_���폜����Ă�
                                    pccCmpnySt.LogicalDeleteCode = 0;
                                    pccCmpnyStWriteList.Add(pccCmpnySt);
                                    break;
                                }
                            }
                        }
                    }

                    if (!insertFlg) continue;  // �o�^��

                    if (pccCmpnyStWriteList.Count == 0)
                    {
                        // �V�K�o�^�̏ꍇ
                        PccCmpnySt pccCmpnySt = new PccCmpnySt();
                        pccCmpnySt.InqOtherEpCd = scmEpScCnt.CnectOtherEpCd;
                        pccCmpnySt.InqOtherSecCd = scmEpScCnt.CnectOtherSecCd;
                        pccCmpnySt.InqOriginalEpCd = scmEpScCnt.CnectOriginalEpCd.Trim();//@@@@20230303
                        pccCmpnySt.InqOriginalSecCd = scmEpScCnt.CnectOriginalSecCd;
                        // ADD 2013/01/07 T.Yoshioka 2013/01/16�z�M �V�X�e���e�X�g��Q��45 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        pccCmpnySt.StckStComment1 = "�݌ɂ���";
                        pccCmpnySt.StckStComment2 = "�݌ɂȂ�";
                        pccCmpnySt.StckStComment3 = "�݌ɕs��";
                        // ADD 2013/01/07 T.Yoshioka 2013/01/16�z�M �V�X�e���e�X�g��Q��45 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        pccCmpnyStWriteList.Add(pccCmpnySt);
                    }

                    // �Y�����Ӑ��T��
                    foreach (CustomerInfo customerInfo in customerInfoList)
                    {
                        if (pccCmpnyStWriteList[0].InqOtherEpCd == customerInfo.EnterpriseCode
                            // DEL 2013/01/07 T.Yoshioka 2013/01/16�z�M �V�X�e���e�X�g��Q��44 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            // && pccCmpnyStWriteList[0].InqOtherSecCd == customerInfo.MngSectionCode
                            // DEL 2013/01/07 T.Yoshioka 2013/01/16�z�M �V�X�e���e�X�g��Q��44 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                            && pccCmpnyStWriteList[0].InqOriginalEpCd.Trim() == customerInfo.CustomerEpCode.Trim() //@@@@20230303
                            && pccCmpnyStWriteList[0].InqOriginalSecCd == customerInfo.CustomerSecCode)
                        {
                            pccCmpnyStWriteList[0].PccCompanyCode = customerInfo.CustomerCode;

                            // �ϑ��q��
                            pccCmpnyStWriteList[0].PccWarehouseCd = "";
                            foreach (Warehouse warehouse in WarehouseList)
                            {
                                if (warehouse.WarehouseCode == customerInfo.CustWarehouseCd
                                    && warehouse.CustomerCode == customerInfo.CustomerCode)
                                {
                                    // �q�Ƀ}�X�^�ɑ��݂��āA���Ӑ�R�[�h����v����ꍇ�A�ϑ��q��
                                    pccCmpnyStWriteList[0].PccWarehouseCd = warehouse.WarehouseCode;
                                    break;
                                }
                            }

                            // �Q�Ƒq��
                            pccCmpnyStWriteList[0].PccPriWarehouseCd1 = "";
                            pccCmpnyStWriteList[0].PccPriWarehouseCd2 = "";
                            pccCmpnyStWriteList[0].PccPriWarehouseCd3 = "";
                            foreach (SecInfoSet secInfoSet in secInfoSets)
                            {
                                // UPD 2013/01/07 T.Yoshioka 2013/01/16�z�M �V�X�e���e�X�g��Q��44 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                                // if (secInfoSet.SectionCode == customerInfo.MngSectionCode)
                                if (secInfoSet.SectionCode == pccCmpnyStWriteList[0].InqOtherSecCd)
                                // UPD 2013/01/07 T.Yoshioka 2013/01/16�z�M �V�X�e���e�X�g��Q��44 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                                {
                                    pccCmpnyStWriteList[0].PccPriWarehouseCd1 = secInfoSet.SectWarehouseCd1;
                                    pccCmpnyStWriteList[0].PccPriWarehouseCd2 = secInfoSet.SectWarehouseCd2;
                                    pccCmpnyStWriteList[0].PccPriWarehouseCd3 = secInfoSet.SectWarehouseCd3;
                                    break;
                                }
                            }
                            break;
                        }
                    }

                    if (pccCmpnyStWriteList[0].PccCompanyCode == 0) continue; //�Y�����Ӑ�Ȃ�

                    // �o�^
                    status = this.Write(ref pccCmpnyStWriteList);
                    EasyLogger.Write("status:" + status + " " + LogTextMake(pccCmpnyStWriteList[0]));
                }

            }
            catch (RemotingException)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            finally
            {
                EasyLogger.Write(DateTime.Now + "�F�q�Ɉڍs�����I����������");
            }

            // config��������
            System.Configuration.ExeConfigurationFileMap file = new System.Configuration.ExeConfigurationFileMap();

            file.ExeConfigFilename = CONFIG_FILE;
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(file, System.Configuration.ConfigurationUserLevel.None);
            System.Configuration.AppSettingsSection appSettingSection = (System.Configuration.AppSettingsSection)config.GetSection("appSettings");
            if (appSettingSection.Settings[RUN_IKO] == null)
            {
                appSettingSection.Settings.Add(RUN_IKO, "1");
            } else 
            {
                appSettingSection.Settings[RUN_IKO].Value = "1";
            }
            config.Save(ConfigurationSaveMode.Modified);

            return status;
        }

        #region Private Method
        /// <summary>
        /// BLP���Аݒ�}�X�^���O�o�͗p�e�L�X�g�ҏW
        /// </summary>
        /// <param name="pccCmpnySt">PCC���Аݒ�f�[�^</param>
        /// <returns>�ҏW�㕶����</returns>
        /// <remarks>
        /// <br>Note       : �N���X���b�r�u�ɕҏW</br>
        /// <br>Programmer : �O�ˁ@�L��</br>
        /// <br>Date       : 2012/12/14</br>
        /// </remarks>
        private string LogTextMake(PccCmpnySt pccCmpnySt)
        {
            StringBuilder logText = new System.Text.StringBuilder();
            const String DELIMITER = ",";

            logText.Append(pccCmpnySt.CreateDateTime);          //�쐬����
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.UpdateDateTime);          //�X�V����
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.LogicalDeleteCode);       //�_���폜�敪
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.InqOriginalEpCd.Trim());         //�⍇������ƃR�[�h//@@@@20230303
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.InqOriginalSecCd);        //�⍇�������_�R�[�h
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.InqOtherEpCd);            //�⍇�����ƃR�[�h
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.InqOtherSecCd);           //�⍇���拒�_�R�[�h
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccCompanyCode);          //PCC���ЃR�[�h
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccCompanyName);          //PCC���Ж���
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccWarehouseCd);          //PCC�q�ɃR�[�h
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccPriWarehouseCd1);      //PCC�D��q�ɃR�[�h1
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccPriWarehouseCd2);      //PCC�D��q�ɃR�[�h2
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccPriWarehouseCd3);      //PCC�D��q�ɃR�[�h3
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.GoodsNoDspDiv);           //�i�ԕ\���敪
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.GoodsNoDspDivName);       //�i�ԕ\������
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.ListPrcDspDiv);           //�W�����i�\���敪
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.ListPrcDspDivName);       //�W�����i�\������
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.CostDspDiv);              //�d�؉��i�\���敪
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.CostDspDivName);          //�d�؉��i�\������
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.ShelfDspDiv);             //�I�ԕ\���敪
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.ShelfDspDivName);         //�I�ԕ\������
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.StockDspDiv);             //�݌ɕ\���敪
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.StockDspDivName);         //�݌ɕ\������
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.CommentDspDiv);           //�R�����g�\���敪
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.CommentDspDivName);       //�R�����g�\������
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.SpmtCntDspDiv);           //�o�א��\���敪
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.SpmtCntDspDivName);       //�o�א��\������
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.AcptCntDspDiv);           //�󒍐��\���敪
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.AcptCntDspDivName);       //�󒍐��\������
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PrtSelGdNoDspDiv);        //���i�I��i�ԕ\���敪
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PrtSelGdNoDspDivName);    //���i�I��i�ԕ\������
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PrtSelLsPrDspDiv);        //���i�I��W�����i�\���敪
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PrtSelLsPrDspDivName);    //���i�I��W�����i�\������
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PrtSelSelfDspDiv);        //���i�I��I�ԕ\���敪
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PrtSelSelfDspDivName);    //���i�I��I�ԕ\������
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PrtSelStckDspDiv);        //���i�I���݌ɕ\���敪
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PrtSelStckDspDivName);    //���i�I���݌ɕ\������
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.StckStMark1);             //�݌ɏ󋵃}�[�N1
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.StckStMark2);             //�݌ɏ󋵃}�[�N2
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.StckStMark3);             //�݌ɏ󋵃}�[�N3
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplName1);            //PCC�����於��1
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplName2);            //PCC�����於��2
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplKana);             //PCC������J�i����
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplSnm);              //PCC�����旪��
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplPostNo);           //PCC������X�֔ԍ�
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplAddr1);            //PCC������Z��1
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplAddr2);            //PCC������Z��2
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplAddr3);            //PCC������Z��3
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplTelNo1);           //PCC������d�b�ԍ�1
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplTelNo2);           //PCC������d�b�ԍ�2
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSuplFaxNo);            //PCC������FAX�ԍ�
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSlipPrtDiv);           //�`�[���s�敪�iPCC�j
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSlipPrtDivName);       //�`�[���s���́iPCC�j
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSlipRePrtDiv);         //�`�[�Ĕ��s�敪
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PccSlipRePrtDivName);     //�`�[�Ĕ��s����
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PrtSelPrmDspDiv);         //���i�I��D�Ǖ\���敪
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.PrtSelPrmDspDivName);     //���i�I��D�Ǖ\������
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.StckStDspDiv);            //�݌ɏ󋵕\���敪
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.StckStDspDivName);        //�݌ɏ󋵕\������
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.StckStComment1);          //�݌ɃR�����g1
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.StckStComment2);          //�݌ɃR�����g2
            logText.Append(DELIMITER);
            logText.Append(pccCmpnySt.StckStComment3);          //�݌ɃR�����g3
            return logText.ToString();
        }

        /// <summary>
        /// BLP���Аݒ�}�X�^�q�Ɉڍs�o�^�A�X�V����
        /// </summary>
        /// <param name="pccCmpnyStList">PCC���Аݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : BLP���Аݒ�}�X�^�q�Ɉڍs�o�^�A�X�V�����B</br>
        /// <br>Programmer : �O�ˁ@�L��</br>
        /// <br>Date       : 2012/12/14</br>
        /// </remarks>
        private int Write(ref List<PccCmpnySt> pccCmpnyStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccCmpnyStWorkList = null;
            ArrayList pccCmpnyStWorkResultList = null;

            try
            {
                if (pccCmpnyStList != null)
                {
                    this.CopyCmpnyStToWork(out pccCmpnyStWorkResultList, pccCmpnyStList);
                    objPccCmpnyStWorkList = pccCmpnyStWorkResultList as object;
                }

                //BLP���Аݒ�}�X�^�q�Ɉڍs�o�^�A�X�V����
                status = _IPccCmpnyStDB.Write(ref objPccCmpnyStWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //���ʂ�߂�
                pccCmpnyStWorkResultList = objPccCmpnyStWorkList as ArrayList;

                if (pccCmpnyStWorkResultList != null)
                {
                    this.CopyWorkToCmpnySt(pccCmpnyStWorkResultList, out pccCmpnyStList);
                }

            }
            catch (RemotingException)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// BLP���Аݒ�}�X�^�]������
        /// </summary>
        /// <param name="pccCmpnyStWorkList">BLP���Аݒ胏�[�N���X�g</param>
        /// <param name="pccCmpnyStList">BLP���Аݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : BLP���Аݒ�}�X�^�]������</br>
        /// <br>Programmer : �O�ˁ@�L��</br>
        /// <br>Date       : 2012/12/14</br>
        /// </remarks>
        private void CopyWorkToCmpnySt(ArrayList pccCmpnyStWorkList, out List<PccCmpnySt> pccCmpnyStList)
        {
            pccCmpnyStList = null;
            if (pccCmpnyStWorkList == null || pccCmpnyStWorkList.Count == 0)
            {
                return;
            }
            else
            {
                pccCmpnyStList = new List<PccCmpnySt>();
                foreach (PccCmpnyStWork wkPccCmpnyStWork in pccCmpnyStWorkList)
                {
                    PccCmpnySt pccCmpnySt = new PccCmpnySt();
                    //�쐬����
                    pccCmpnySt.CreateDateTime = wkPccCmpnyStWork.CreateDateTime;
                    //�X�V����
                    pccCmpnySt.UpdateDateTime = wkPccCmpnyStWork.UpdateDateTime;
                    //�_���폜�敪
                    pccCmpnySt.LogicalDeleteCode = wkPccCmpnyStWork.LogicalDeleteCode;
                    //�⍇������ƃR�[�h
                    pccCmpnySt.InqOriginalEpCd = wkPccCmpnyStWork.InqOriginalEpCd.Trim();//@@@@20230303
                    //�⍇�������_�R�[�h
                    pccCmpnySt.InqOriginalSecCd = wkPccCmpnyStWork.InqOriginalSecCd;
                    //�⍇�����ƃR�[�h
                    pccCmpnySt.InqOtherEpCd = wkPccCmpnyStWork.InqOtherEpCd;
                    //�⍇���拒�_�R�[�h
                    pccCmpnySt.InqOtherSecCd = wkPccCmpnyStWork.InqOtherSecCd;
                    //PCC���ЃR�[�h
                    pccCmpnySt.PccCompanyCode = wkPccCmpnyStWork.PccCompanyCode;
                    //PCC���Ж���
                    string pccCompanyName = string.Empty;
                    if (this._customerInfoTable != null && this._customerInfoTable.ContainsKey(wkPccCmpnyStWork.PccCompanyCode))
                    {
                        pccCompanyName = this._customerInfoTable[wkPccCmpnyStWork.PccCompanyCode] as string;

                    }
                    pccCmpnySt.PccCompanyName = pccCompanyName;
                    //PCC�q�ɃR�[�h
                    pccCmpnySt.PccWarehouseCd = wkPccCmpnyStWork.PccWarehouseCd;
                    //PCC�D��q�ɃR�[�h1
                    pccCmpnySt.PccPriWarehouseCd1 = wkPccCmpnyStWork.PccPriWarehouseCd1;
                    //PCC�D��q�ɃR�[�h2
                    pccCmpnySt.PccPriWarehouseCd2 = wkPccCmpnyStWork.PccPriWarehouseCd2;
                    //PCC�D��q�ɃR�[�h3
                    pccCmpnySt.PccPriWarehouseCd3 = wkPccCmpnyStWork.PccPriWarehouseCd3;
                    //�i�ԕ\���敪
                    pccCmpnySt.GoodsNoDspDiv = wkPccCmpnyStWork.GoodsNoDspDiv;
                    //�i�ԕ\������
                    pccCmpnySt.GoodsNoDspDivName = getNameFromDiv(wkPccCmpnyStWork.GoodsNoDspDiv, 0);
                    //�W�����i�\���敪
                    pccCmpnySt.ListPrcDspDiv = wkPccCmpnyStWork.ListPrcDspDiv;
                    //�W�����i�\������
                    pccCmpnySt.ListPrcDspDivName = getNameFromDiv(wkPccCmpnyStWork.ListPrcDspDiv, 0);
                    //�d�؉��i�\���敪
                    pccCmpnySt.CostDspDiv = wkPccCmpnyStWork.CostDspDiv;
                    //�d�؉��i�\������
                    pccCmpnySt.CostDspDivName =  getNameFromDiv(wkPccCmpnyStWork.CostDspDiv, 0);
                    //�I�ԕ\���敪
                    pccCmpnySt.ShelfDspDiv = wkPccCmpnyStWork.ShelfDspDiv;
                    //�I�ԕ\������
                    pccCmpnySt.ShelfDspDivName =  getNameFromDiv(wkPccCmpnyStWork.ShelfDspDiv, 0);
                    //�݌ɕ\���敪
                    pccCmpnySt.StockDspDiv = wkPccCmpnyStWork.StockDspDiv;
                    //�݌ɕ\������
                    pccCmpnySt.StockDspDivName =  getNameFromDiv(wkPccCmpnyStWork.StockDspDiv, 0);
                    //�R�����g�\���敪
                    pccCmpnySt.CommentDspDiv = wkPccCmpnyStWork.CommentDspDiv;
                    //�R�����g�\������
                    pccCmpnySt.CommentDspDivName =  getNameFromDiv(wkPccCmpnyStWork.CommentDspDiv, 0);
                    //�o�א��\���敪
                    pccCmpnySt.SpmtCntDspDiv = wkPccCmpnyStWork.SpmtCntDspDiv;
                    //�o�א��\������
                    pccCmpnySt.SpmtCntDspDivName =  getNameFromDiv(wkPccCmpnyStWork.SpmtCntDspDiv, 0);
                    //�󒍐��\���敪
                    pccCmpnySt.AcptCntDspDiv = wkPccCmpnyStWork.AcptCntDspDiv;
                    //�󒍐��\������
                    pccCmpnySt.AcptCntDspDivName =  getNameFromDiv(wkPccCmpnyStWork.AcptCntDspDiv, 0);
                    //���i�I��i�ԕ\���敪
                    pccCmpnySt.PrtSelGdNoDspDiv = wkPccCmpnyStWork.PrtSelGdNoDspDiv;
                    //���i�I��i�ԕ\������
                    pccCmpnySt.PrtSelGdNoDspDivName =  getNameFromDiv(wkPccCmpnyStWork.PrtSelGdNoDspDiv, 0);
                    //���i�I��W�����i�\���敪
                    pccCmpnySt.PrtSelLsPrDspDiv = wkPccCmpnyStWork.PrtSelLsPrDspDiv;
                    //���i�I��W�����i�\������
                    pccCmpnySt.PrtSelLsPrDspDivName =  getNameFromDiv(wkPccCmpnyStWork.PrtSelLsPrDspDiv, 0);
                    //���i�I��I�ԕ\���敪
                    pccCmpnySt.PrtSelSelfDspDiv = wkPccCmpnyStWork.PrtSelSelfDspDiv;
                    //���i�I��I�ԕ\������
                    pccCmpnySt.PrtSelSelfDspDivName =  getNameFromDiv(wkPccCmpnyStWork.PrtSelSelfDspDiv, 0);
                    //���i�I���݌ɕ\���敪
                    pccCmpnySt.PrtSelStckDspDiv = wkPccCmpnyStWork.PrtSelStckDspDiv;
                    //���i�I���݌ɕ\������
                    pccCmpnySt.PrtSelStckDspDivName = getNameFromDiv(wkPccCmpnyStWork.PrtSelStckDspDiv, 0);
                    //�݌ɏ󋵃}�[�N1
                    pccCmpnySt.StckStMark1 = wkPccCmpnyStWork.StckStMark1;
                    //�݌ɏ󋵃}�[�N2
                    pccCmpnySt.StckStMark2 = wkPccCmpnyStWork.StckStMark2;
                    //�݌ɏ󋵃}�[�N3
                    pccCmpnySt.StckStMark3 = wkPccCmpnyStWork.StckStMark3;
                    //PCC�����於��1
                    pccCmpnySt.PccSuplName1 = wkPccCmpnyStWork.PccSuplName1;
                    //PCC�����於��2
                    pccCmpnySt.PccSuplName2 = wkPccCmpnyStWork.PccSuplName2;
                    //PCC������J�i����
                    pccCmpnySt.PccSuplKana = wkPccCmpnyStWork.PccSuplKana;
                    //PCC�����旪��
                    pccCmpnySt.PccSuplSnm = wkPccCmpnyStWork.PccSuplSnm;
                    //PCC������X�֔ԍ�
                    pccCmpnySt.PccSuplPostNo = wkPccCmpnyStWork.PccSuplPostNo;
                    //PCC������Z��1
                    pccCmpnySt.PccSuplAddr1 = wkPccCmpnyStWork.PccSuplAddr1;
                    //PCC������Z��2
                    pccCmpnySt.PccSuplAddr2 = wkPccCmpnyStWork.PccSuplAddr2;
                    //PCC������Z��3
                    pccCmpnySt.PccSuplAddr3 = wkPccCmpnyStWork.PccSuplAddr3;
                    //PCC������d�b�ԍ�1
                    pccCmpnySt.PccSuplTelNo1 = wkPccCmpnyStWork.PccSuplTelNo1;
                    //PCC������d�b�ԍ�2
                    pccCmpnySt.PccSuplTelNo2 = wkPccCmpnyStWork.PccSuplTelNo2;
                    //PCC������FAX�ԍ�
                    pccCmpnySt.PccSuplFaxNo = wkPccCmpnyStWork.PccSuplFaxNo;
                    //�`�[���s�敪�iPCC�j
                    pccCmpnySt.PccSlipPrtDiv = wkPccCmpnyStWork.PccSlipPrtDiv;
                    //�`�[���s���́iPCC�j
                    pccCmpnySt.PccSlipPrtDivName = getNameFromDiv(wkPccCmpnyStWork.PccSlipPrtDiv, 1);
                    //�`�[�Ĕ��s�敪
                    pccCmpnySt.PccSlipRePrtDiv = wkPccCmpnyStWork.PccSlipRePrtDiv;
                    //�`�[�Ĕ��s����
                    pccCmpnySt.PccSlipRePrtDivName = getNameFromDiv(wkPccCmpnyStWork.PccSlipRePrtDiv, 4);
                    //���i�I��D�Ǖ\���敪
                    pccCmpnySt.PrtSelPrmDspDiv = wkPccCmpnyStWork.PrtSelPrmDspDiv;
                    //���i�I��D�Ǖ\������
                    pccCmpnySt.PrtSelPrmDspDivName = getNameFromDiv(wkPccCmpnyStWork.PrtSelPrmDspDiv, 2);
                    //�݌ɏ󋵕\���敪
                    pccCmpnySt.StckStDspDiv = wkPccCmpnyStWork.StckStDspDiv;
                    //�݌ɏ󋵕\������
                    pccCmpnySt.StckStDspDivName = getNameFromDiv(wkPccCmpnyStWork.StckStDspDiv, 3);
                    //�݌ɃR�����g1
                    pccCmpnySt.StckStComment1 = wkPccCmpnyStWork.StckStComment1;
                    //�݌ɃR�����g2
                    pccCmpnySt.StckStComment2 = wkPccCmpnyStWork.StckStComment2;
                    //�݌ɃR�����g3
                    pccCmpnySt.StckStComment3 = wkPccCmpnyStWork.StckStComment3;

                    pccCmpnyStList.Add(pccCmpnySt);
                }
            }
        }

        /// <summary>
        /// BLP���Аݒ�}�X�^�]������
        /// </summary>
        /// <param name="pccCmpnyStWorkList">BLP���Аݒ胏�[�N���X�g</param>
        /// <param name="pccCmpnyStList">BLP���Аݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : BLP���Аݒ�}�X�^�]������</br>
        /// <br>Programmer : �O�ˁ@�L��</br>
        /// <br>Date       : 2012/12/14</br>
        /// </remarks>
        private void CopyCmpnyStToWork(out ArrayList pccCmpnyStWorkList, List<PccCmpnySt> pccCmpnyStList)
        {
            pccCmpnyStWorkList = null;
            if (pccCmpnyStList == null || pccCmpnyStList.Count == 0)
            {
                return;
            }
            else
            {
                pccCmpnyStWorkList = new ArrayList();
                foreach (PccCmpnySt pccCmpnySt in pccCmpnyStList)
                {
                    PccCmpnyStWork wkPccCmpnyStWork = new PccCmpnyStWork();
                    //�쐬����
                    wkPccCmpnyStWork.CreateDateTime = pccCmpnySt.CreateDateTime;
                    //�X�V����
                    wkPccCmpnyStWork.UpdateDateTime = pccCmpnySt.UpdateDateTime;
                    //�_���폜�敪
                    wkPccCmpnyStWork.LogicalDeleteCode = pccCmpnySt.LogicalDeleteCode;
                    //�⍇������ƃR�[�h
                    wkPccCmpnyStWork.InqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
                    //�⍇�������_�R�[�h
                    wkPccCmpnyStWork.InqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
                    //�⍇�����ƃR�[�h
                    wkPccCmpnyStWork.InqOtherEpCd = pccCmpnySt.InqOtherEpCd;
                    //�⍇���拒�_�R�[�h
                    wkPccCmpnyStWork.InqOtherSecCd = pccCmpnySt.InqOtherSecCd;
                    //PCC���ЃR�[�h
                    wkPccCmpnyStWork.PccCompanyCode = pccCmpnySt.PccCompanyCode;
                    //PCC�q�ɃR�[�h
                    wkPccCmpnyStWork.PccWarehouseCd = pccCmpnySt.PccWarehouseCd;
                    //PCC�D��q�ɃR�[�h1
                    wkPccCmpnyStWork.PccPriWarehouseCd1 = pccCmpnySt.PccPriWarehouseCd1;
                    //PCC�D��q�ɃR�[�h2
                    wkPccCmpnyStWork.PccPriWarehouseCd2 = pccCmpnySt.PccPriWarehouseCd2;
                    //PCC�D��q�ɃR�[�h3
                    wkPccCmpnyStWork.PccPriWarehouseCd3 = pccCmpnySt.PccPriWarehouseCd3;
                    //�i�ԕ\���敪
                    wkPccCmpnyStWork.GoodsNoDspDiv = pccCmpnySt.GoodsNoDspDiv;
                    //�W�����i�\���敪
                    wkPccCmpnyStWork.ListPrcDspDiv = pccCmpnySt.ListPrcDspDiv;
                    //�d�؉��i�\���敪
                    wkPccCmpnyStWork.CostDspDiv = pccCmpnySt.CostDspDiv;
                    //�I�ԕ\���敪
                    wkPccCmpnyStWork.ShelfDspDiv = pccCmpnySt.ShelfDspDiv;
                    //�݌ɕ\���敪
                    wkPccCmpnyStWork.StockDspDiv = pccCmpnySt.StockDspDiv;
                    //�R�����g�\���敪
                    wkPccCmpnyStWork.CommentDspDiv = pccCmpnySt.CommentDspDiv;
                    //�o�א��\���敪
                    wkPccCmpnyStWork.SpmtCntDspDiv = pccCmpnySt.SpmtCntDspDiv;
                    //�󒍐��\���敪
                    wkPccCmpnyStWork.AcptCntDspDiv = pccCmpnySt.AcptCntDspDiv;
                    //���i�I��i�ԕ\���敪
                    wkPccCmpnyStWork.PrtSelGdNoDspDiv = pccCmpnySt.PrtSelGdNoDspDiv;
                    //���i�I��W�����i�\���敪
                    wkPccCmpnyStWork.PrtSelLsPrDspDiv = pccCmpnySt.PrtSelLsPrDspDiv;
                    //���i�I��I�ԕ\���敪
                    wkPccCmpnyStWork.PrtSelSelfDspDiv = pccCmpnySt.PrtSelSelfDspDiv;
                    //���i�I���݌ɕ\���敪
                    wkPccCmpnyStWork.PrtSelStckDspDiv = pccCmpnySt.PrtSelStckDspDiv;
                    //�݌ɏ󋵃}�[�N1
                    wkPccCmpnyStWork.StckStMark1 = pccCmpnySt.StckStMark1;
                    //�݌ɏ󋵃}�[�N2
                    wkPccCmpnyStWork.StckStMark2 = pccCmpnySt.StckStMark2;
                    //�݌ɏ󋵃}�[�N3
                    wkPccCmpnyStWork.StckStMark3 = pccCmpnySt.StckStMark3;
                    //PCC�����於��1
                    wkPccCmpnyStWork.PccSuplName1 = pccCmpnySt.PccSuplName1;
                    //PCC�����於��2
                    wkPccCmpnyStWork.PccSuplName2 = pccCmpnySt.PccSuplName2;
                    //PCC������J�i����
                    wkPccCmpnyStWork.PccSuplKana = pccCmpnySt.PccSuplKana;
                    //PCC�����旪��
                    wkPccCmpnyStWork.PccSuplSnm = pccCmpnySt.PccSuplSnm;
                    //PCC������X�֔ԍ�
                    wkPccCmpnyStWork.PccSuplPostNo = pccCmpnySt.PccSuplPostNo;
                    //PCC������Z��1
                    wkPccCmpnyStWork.PccSuplAddr1 = pccCmpnySt.PccSuplAddr1;
                    //PCC������Z��2
                    wkPccCmpnyStWork.PccSuplAddr2 = pccCmpnySt.PccSuplAddr2;
                    //PCC������Z��3
                    wkPccCmpnyStWork.PccSuplAddr3 = pccCmpnySt.PccSuplAddr3;
                    //PCC������d�b�ԍ�1
                    wkPccCmpnyStWork.PccSuplTelNo1 = pccCmpnySt.PccSuplTelNo1;
                    //PCC������d�b�ԍ�2
                    wkPccCmpnyStWork.PccSuplTelNo2 = pccCmpnySt.PccSuplTelNo2;
                    //PCC������FAX�ԍ�
                    wkPccCmpnyStWork.PccSuplFaxNo = pccCmpnySt.PccSuplFaxNo;
                    //�`�[���s�敪�iPCC�j
                    wkPccCmpnyStWork.PccSlipPrtDiv = pccCmpnySt.PccSlipPrtDiv;
                    //�`�[�Ĕ��s�敪
                    wkPccCmpnyStWork.PccSlipRePrtDiv = pccCmpnySt.PccSlipRePrtDiv;
                    //���i�I��D�Ǖ\���敪
                    wkPccCmpnyStWork.PrtSelPrmDspDiv = pccCmpnySt.PrtSelPrmDspDiv;
                    //�݌ɏ󋵕\���敪
                    wkPccCmpnyStWork.StckStDspDiv = pccCmpnySt.StckStDspDiv;
                    //�݌ɃR�����g1
                    wkPccCmpnyStWork.StckStComment1 = pccCmpnySt.StckStComment1;
                    //�݌ɃR�����g2
                    wkPccCmpnyStWork.StckStComment2 = pccCmpnySt.StckStComment2;
                    //�݌ɃR�����g3
                    wkPccCmpnyStWork.StckStComment3 = pccCmpnySt.StckStComment3;

                    pccCmpnyStWorkList.Add(wkPccCmpnyStWork);
                }
            }

        }

        /// <summary>
        /// �敪���疼�̂̎擾����
        /// </summary>
        /// <param name="div">�敪</param>
        /// <param name="kind">���(1:�`�[���s�敪�iPCC�j;2:���i�I��D�Ǖ\���敪;3:�݌ɏ󋵕\���敪;4:�`�[�Ĕ��s�敪0:���̑�;)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �敪���疼�̂̎擾�������s���B</br>
        /// <br>Programmer : �O�ˁ@�L��</br>
        /// <br>Date       : 2012/12/14</br>
        /// </remarks>
        private string getNameFromDiv(int div, int kind)
        {
            string name = string.Empty;
            switch (kind)
            {
                case 0:
                    {
                        switch (div)
                        {
                            case 0:
                                {
                                    name = "����";
                                    break;
                                }
                            case 1:
                                {
                                    name = "���Ȃ�";
                                    break;
                                }
                        }
                      
                        break;
                    }
                //�`�[���s�敪�iPCC�j
                case 1:
                    {
                        switch (kind)
                        {
                            case 0:
                                {
                                    name = "���Ȃ�";
                                    break;
                                }
                            case 1:
                                {
                                    name = "��";
                                    break;
                                }
                            case 2:
                                {
                                    name = "�Ӱ�";
                                    break;
                                }
                            case 3:
                                {
                                    name = "����";
                                    break;
                                }
                        }
                        break;
                    }
                //���i�I��D�Ǖ\���敪
                case 2:
                    {
                        switch (kind)
                        {
                            case 0:
                                {
                                    name = "�S��";
                                    break;
                                }
                            case 1:
                                {
                                    name = "���ЗD��݌�";
                                    break;
                                }
                            case 2:
                                {
                                    name = "���Ѝ݌�";
                                    break;
                                }
                        }
                        break;
                    }
                case 3:
                    {
                        //�݌ɏ󋵕\���敪
                        switch (div)
                        {
                            case 0:
                                {
                                    name = "�}�[�N";
                                    break;
                                }
                            case 1:
                                {
                                    name = "���݌ɐ�";
                                    break;
                                }
                        }

                        break;
                    }
                case 4:
                    {
                        switch (div)
                        {
                            case 0:
                                {
                                    name = "����";
                                    break;
                                }
                            case 1:
                                {
                                    name = "���Ȃ�";
                                    break;
                                }
                        }

                        break;
                    }

            }
            return name;
        }
        #endregion

    }

}
