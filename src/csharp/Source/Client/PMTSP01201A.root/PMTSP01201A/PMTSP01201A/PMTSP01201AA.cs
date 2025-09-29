//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : TSP.NS�f�[�^�쐬���i�A�N�Z�X�N���X
// �v���O�����T�v   : TSP.NS�f�[�^�쐬���i�A�N�Z�X�N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670305-00 �쐬�S�� : ���O
// �� �� ��  2020/11/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670305-00 �쐬�S�� : ������
// �� �� ��  2020/12/21  �C�����e : PMKOBETSU-4097 TSP�C�����C���@�\�ǉ��Ή�
//----------------------------------------------------------------------------//

using System;

using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Windows.Forms;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Security.Cryptography;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// TSP.NS�f�[�^�쐬���i�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : TSP.NS�f�[�^�쐬���i�A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2020/11/20</br>
    /// <br>Update Note: 2020/12/21 ������</br>
    /// <br>�Ǘ��ԍ�   : 11670305-00</br>
    /// <br>           : PMKOBETSU-4097 TSP�C�����C���@�\�ǉ��Ή�</br>
    /// </remarks>
    public class WriteTspSdRvDataAcs
    {
        # region
        /// <summary>�ݒ�XML�t�@�C����</summary>
        private const string XML_FILE_NAME = "TspSend_UserSetting.XML";
        /// <summary>TSP�`�[�t�@�C����</summary>
        private const string TspSdRvDtName = "TspSdRvDt{0}.XML";
        /// <summary>TSP���׃t�@�C����</summary>
        private const string TspSdRvDtlName = "TspSdRvDtl{0}.XML";
        // �p�X�ݒ�
        private TspSndPathInfo PathData;
        // ���M�f�[�^�t�@�C���p�X
        private string TspTrashPath;
        // ���M�f�[�^�t�@�C���p�X
        private string TspSendPath;
        // �ꎞ̧���߽
        private string TspTmpPath;
        // TSP�`�[�t�@�C��
        private TspSdRvDt TspSdRvDt;
        // TSP���׃t�@�C��
        private List<TspSdRvDtl> TspSdRvDtlList = new List<TspSdRvDtl>();
        // �ʐM��
        private int TspCommCountTemp = 0;
        // ���ʒʔԂ��̔�
        private ITspSdRvDataDB TspSdRvDataDB;
        # endregion

        # region [�R���X�g���N�^]
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^�ł��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        public WriteTspSdRvDataAcs()
        {
            this.TspSdRvDataDB = (ITspSdRvDataDB)MediationTspSdRvDataDB.GetTspSdRvDataDB();
        }
        # endregion

        # region
        /// <summary>
        /// XMĻ�يǗ�̫��ނ̃p�X���擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : XMĻ�يǗ�̫��ނ̃p�X���擾����B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool XmlRead()
        {
            PathData = new TspSndPathInfo();
            if (UserSettingController.ExistUserSetting(Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            {
                try
                {
                    PathData = UserSettingController.DeserializeUserSetting<TspSndPathInfo>(Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
                    return true;
                }
                catch (Exception ex)
                {
                    LogWrite("XmlRead()", ex.ToString());
                    return false;
                }
            }
            else
            {
                LogWrite("XmlRead()", "�ݒ�t�@�C�����݂��Ȃ��A�������~����B");
                return false;
            }
        }

        /// <summary>
        /// �폜�̏ꍇ�A���M�f�[�^�ړ�����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <returns>true:�����Afalse:���s</returns>
        /// <remarks>
        /// <br>Note       : XMĻ�يǗ�̫��ނ̃p�X���擾����B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        public bool MoveTspSdRvData(int customerCode, string salesSlipNum)
        {
            try
            {
                // XML���p�X���擾����
                if (!this.XmlRead()) return false;
                // ̫��ލ쐬
                if (!CreateDirMain(customerCode, salesSlipNum,0)) return false;
                
                // ���M�f�[�^�ړ�����
                if (!DeleteProc()) return false;

                // TSP���׃f�[�^�폜����
                TspDtlWork paraTspDtlWork = new TspDtlWork();
                paraTspDtlWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;;
                paraTspDtlWork.AcptAnOdrStatus = 30;
                paraTspDtlWork.SalesSlipNum = salesSlipNum;
                int status = TspSdRvDataDB.Delete((object)paraTspDtlWork);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    LogWrite("MoveTspSdRvData()", "TSP���׃f�[�^�폜�����Ɏ��s���܂����B");
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogWrite("MoveTspSdRvData()", ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// ̧�ق̍쐬
        /// </summary>
        /// <param name="paraList">����`�[���</param>
        /// <param name="tspMode">0:�폜�A1:�V�K�A2:�X�V</param>
        /// <param name="tspCprtStList">TSP�A�g�}�X�^�ݒ���</param>
        /// <returns>true:�����Afalse:���s</returns>
        /// <remarks>
        /// <br>Note       : XMĻ�يǗ�̫��ނ̃p�X���擾����B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// <br>Update Note: 2020/12/21 ������</br>
        /// <br>�Ǘ��ԍ�   : 11670305-00</br>
        /// <br>           : PMKOBETSU-4097 TSP�C�����C���@�\�ǉ��Ή�</br>
        /// </remarks>
        // ---UPD ������ 2020/12/21 PMKOBETSU-4097�̑Ή� ------>>>>
        //public bool GetTspSdRvData(CustomSerializeArrayList paraList, int tspMode, ArrayList tspCprtStList)
        public bool GetTspSdRvData(CustomSerializeArrayList paraList, int tspMode, ArrayList tspCprtStList, out bool dataFlg)
        // ---UPD ������ 2020/11/20 PMKOBETSU-4097�̑Ή� ------<<<<
        {
            dataFlg = false;// ADD ������ 2020/12/21 PMKOBETSU-4097�̑Ή� 
            try
            {
                if (paraList.Count > 0)
                {
                    // XML���p�X���擾����
                    if (!this.XmlRead()) return false;
                    for (int i = 0; i < paraList.Count; i++)
                    {
                        SalesSlipWork salesSlip = new SalesSlipWork();
                        ArrayList salesDetailList = new ArrayList();
                        AddUpOrgSalesDetailWork addUpOrgDetailWork = new AddUpOrgSalesDetailWork();
                        ArrayList acceptOdrCarList = new ArrayList();
                        bool tspFlg = false;
                        int acceptAnOrderNo = 0;
                        AcceptOdrCarWork acceptOdrCarWork = new AcceptOdrCarWork();
                        if ((object)paraList[i] is CustomSerializeArrayList)
                        {
                            CustomSerializeArrayList list = (CustomSerializeArrayList)paraList[i];
                            foreach (object obj in list)
                            {
                                if (obj is SalesSlipWork)
                                {
                                    salesSlip = (SalesSlipWork)obj;
                                    if (salesSlip.AcptAnOdrStatus != 30)
                                    {
                                        break;
                                    }
                                }
                                else if (obj is ArrayList && ((ArrayList)obj).Count > 0)
                                {
                                    ArrayList al = (ArrayList)obj;
                                    if (al[0] is AcceptOdrCarWork)
                                    {
                                        acceptOdrCarList = (ArrayList)obj;
                                    }
                                    else if (al[0] is AddUpOrgSalesDetailWork)
                                    {
                                        addUpOrgDetailWork = (AddUpOrgSalesDetailWork)((ArrayList)obj)[0];
                                    }
                                    else if (al[0] is SalesDetailWork)
                                    {
                                        salesDetailList = (ArrayList)obj;
                                        foreach (SalesDetailWork salesDetail in salesDetailList)
                                        {
                                            // �l��/���߂͖���
                                            if (salesDetail.SalesSlipCdDtl == 0 || salesDetail.SalesSlipCdDtl == 1)
                                            {
                                                tspFlg = true;
                                            }
                                            if (salesDetail.SalesRowNo == 1)
                                            {
                                                acceptAnOrderNo = salesDetail.AcceptAnOrderNo;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        // ---UPD ������ 2020/12/21 PMKOBETSU-4097�̑Ή� ------>>>>
                        //if (salesSlip.AcptAnOdrStatus == 30 && salesDetailList.Count > 0 && !salesSlip.PartySaleSlipNum.Equals(string.Empty))
                        if (salesSlip.AcptAnOdrStatus == 30 && salesDetailList.Count > 0 && !salesSlip.PartySaleSlipNum.Equals(string.Empty) && tspFlg)
                        // ---UPD ������ 2020/12/21 PMKOBETSU-4097�̑Ή� ------<<<<
                        {
                            // ---DEL ������ 2020/12/21 PMKOBETSU-4097�̑Ή� ------>>>>
                            ////TSP���M�f�[�^�Ȃ�
                            //if (!tspFlg)
                            //{
                            //    LogWrite("GetTspSdRvData()", "TSP���M�f�[�^���Ȃ��B");
                            //    return false;
                            //}
                            // ---DEL ������ 2020/12/21 PMKOBETSU-4097�̑Ή� ------<<<<
                            string sfEnterpriseCode = string.Empty;
                            bool tspCustomerCode = false;
                            // ���Ӑ�R�[�h���ݒ肷��̔��f
                            foreach (TspCprtStWork tspWork in tspCprtStList)
                            {
                                if (tspWork.CustomerCode != salesSlip.CustomerCode)
                                {
                                    continue;
                                }
                                tspCustomerCode = true;
                                sfEnterpriseCode = tspWork.SendEnterpriseCode;

                            }
                            // ���Ӑ�R�[�h���ݒ肷��̏ꍇ
                            if (tspCustomerCode)
                            {
                                int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                long commonSeqNo = 0;
                                // 1:�V�K
                                if (tspMode == 1)
                                {
                                    status = this.TspSdRvDataDB.GetTspCommonSeqNo(salesSlip.EnterpriseCode, salesSlip.SectionCode, out commonSeqNo);
                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        LogWrite("GetTspSdRvData()", "TSP�I�����C���ԍ��̔Ԃ̏����Ɏ��s���܂����B");
                                        return false;
                                    }
                                }
                                // �X�V
                                else if (tspMode == 2)
                                {
                                    object tspDtlWorkList;
                                    TspDtlWork paraTspDtlWork = new TspDtlWork();
                                    paraTspDtlWork.EnterpriseCode = salesSlip.EnterpriseCode;
                                    paraTspDtlWork.AcptAnOdrStatus = salesSlip.AcptAnOdrStatus;
                                    paraTspDtlWork.SalesSlipNum = salesSlip.SalesSlipNum;
                                    status = this.TspSdRvDataDB.Search(paraTspDtlWork, out tspDtlWorkList);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        status = this.TspSdRvDataDB.GetTspCommonSeqNo(salesSlip.EnterpriseCode, salesSlip.SectionCode, out commonSeqNo);
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            LogWrite("GetTspSdRvData()", "TSP�I�����C���ԍ��̔Ԃ̏����Ɏ��s���܂����B");
                                            return false;
                                        }
                                    }
                                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        foreach (TspDtlWork tspDtlWork in (ArrayList)tspDtlWorkList)
                                        {
                                            commonSeqNo = tspDtlWork.TspOnlineNo;// TSP�ʐM�ԍ�
                                        }
                                    }
                                    else
                                    {
                                        LogWrite("GetTspSdRvData()", "TSP���׃f�[�^�擾�����Ɏ��s���܂����B");
                                        return false;
                                    }
                                }

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    foreach (AcceptOdrCarWork acceptOdrCar in acceptOdrCarList)
                                    {
                                        if (acceptOdrCar.AcceptAnOrderNo == acceptAnOrderNo)
                                        {
                                            acceptOdrCarWork = acceptOdrCar;
                                        }
                                    }
                                    // �X�V�Ώۃ`�F�b�N����
                                    if (!CheckProc(salesDetailList)) return false;
                                    // ̫��ލ쐬
                                    if (!CreateDirMain(salesSlip.CustomerCode, salesSlip.SalesSlipNum, tspMode)) return false;
                                    // �ʐM�񐔂̌���
                                    this.TspCommCountTemp = 0;
                                    for (int j = 0; j < 100; j++)
                                    {
                                        if (this.TspCommCountTemp == 99) break;
                                        string xmlName = Path.Combine(this.TspSendPath, string.Format(TspSdRvDtName, this.TspCommCountTemp.ToString().PadLeft(2, '0')));
                                        if (!File.Exists(xmlName))
                                        {
                                            break;
                                        }
                                        this.TspCommCountTemp++;
                                    }
                                    // ���M�f�[�^�쐬����
                                    if (salesSlip.LogicalDeleteCode != 1)
                                    { 
                                        // TSP���׃f�[�^�o�^����
                                        if (!WriteTspDtl(salesDetailList, commonSeqNo)) return false;
                                        // TSP�`�[̧�ق̍쐬
                                        if (!GetTspSdRvDt(salesSlip, acceptOdrCarWork, addUpOrgDetailWork, commonSeqNo, sfEnterpriseCode)) return false;
                                        // TSP����̧�ق̍쐬
                                        if (!GetTspSdRvDtl(salesSlip, salesDetailList, addUpOrgDetailWork, commonSeqNo, sfEnterpriseCode)) return false;
                                        // TSP�`�[�t�@�C���V���A���C�Y����(�ꎞ)
                                        if (!this.Serialize()) return false;
                                        // TSP�`�[�t�@�C���V���A���C�Y����(�ꎞ)
                                        if (!this.SerializeDtl()) return false;
                                        // �t�@�C���Í���
                                        if (!Encrypt()) return false;
                                    }
                                    // ���M�f�[�^�폜����
                                    else
                                    {
                                        if (!DeleteProc()) return false;
                                    }
                                    dataFlg = true;// ADD ������ 2020/12/21 PMKOBETSU-4097�̑Ή�
                                }
                                else
                                {
                                    LogWrite("GetTspSdRvData()", "TSP�I�����C���ԍ��̔Ԃ����s���܂����B");
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogWrite("GetTspSdRvData()", ex.ToString());
                return false;
            }

            return true;
            
        }

        /// <summary>
        ///  TSP���׃f�[�^�o�^����
        /// </summary>
        /// <param name="salesDetailList">����`�[���׃f�[�^</param>
        /// <param name="commonSeqNo">TSP�I�����C���ԍ�</param>
        /// <returns></returns>
        private bool WriteTspDtl(ArrayList salesDetailList, long commonSeqNo)
        {
            ArrayList tspDtlList = new ArrayList();
            object tspDtlObj;
            foreach (SalesDetailWork salesDetail in salesDetailList)
            {
                // TSP���׃f�[�^�쐬
                TspDtlWork tspDtl = new TspDtlWork();
                tspDtl.EnterpriseCode = salesDetail.EnterpriseCode;
                tspDtl.SalesSlipNum = salesDetail.SalesSlipNum;
                tspDtl.SalesSlipDtlNum = salesDetail.SalesSlipDtlNum;
                tspDtl.AcptAnOdrStatus = salesDetail.AcptAnOdrStatus;
                tspDtl.TspOnlineNo = Convert.ToInt32(commonSeqNo);
                tspDtl.TspOnlineRowNo = salesDetail.SalesRowNo;
                tspDtlList.Add(tspDtl);
            }
            tspDtlObj = (object)tspDtlList;
            // TSP���׃f�[�^�o�^
            int status = TspSdRvDataDB.Write(ref tspDtlObj);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                LogWrite("WriteTspDtl()", "TSP���׃f�[�^�o�^�����Ɏ��s���܂����B");
                return false;
            }
            return true;
        }

        /// <summary>
        /// �X�V�Ώۃ`�F�b�N����
        /// </summary>
        /// <param name="salesDetailList">����`�[���׃f�[�^</param>
        /// <returns>true:�����Afalse:���s</returns>
        /// <remarks>
        /// <br>Note       : �X�V�Ώۃ`�F�b�N�������s���B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool CheckProc(ArrayList salesDetailList)
        {
            try
            {
                foreach (SalesDetailWork salesDetail in salesDetailList)
                {
                    // �s�l��/���߂͖���
                    if (salesDetail.SalesSlipCdDtl == 2 || salesDetail.SalesSlipCdDtl == 3)
                    {
                        continue;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogWrite("CheckProc()", ex.ToString());
                return false;
            }
            return false;
        }

        /// <summary>
        /// ̫��ލ쐬
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="mode">0:�폜�A1:�V�K�A2:�X�V</param>
        /// <returns>true:�����Afalse:���s</returns>
        /// <remarks>
        /// <br>Note       : XMĻ�يǗ�̫��ނ��쐬����B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool CreateDirMain(int customerCode, string salesSlipNum, int mode)
        {
            try
            {
                // TSP-SEND̫��ނ̍쐬
                if (this.PathData.TspSndPath.Trim().Equals(string.Empty) || this.PathData.TspSndTmpPath.Trim().Equals(string.Empty))
                    return false;
                this.TspSendPath = Path.Combine(this.PathData.TspSndPath.Trim(), "TSP-SEND");
                if (!CreateDir(this.TspSendPath)) return false;

                // �폜�p�p̫��ނ̍쐬�@ TSP-SEND\TRASH
                this.TspTrashPath = Path.Combine(this.TspSendPath, "TRASH");
                if (!CreateDir(this.TspTrashPath)) return false;
                //---<< ���M�p̫��ނ̍쐬 >>---//
                // ���M�p̫��ނ̍쐬�@ TSP-SEND\(���Ӑ�)
                this.TspSendPath = Path.Combine(this.TspSendPath, customerCode.ToString().PadLeft(8, '0'));
                if (!CreateDir(this.TspSendPath)) return false;

                // �폜�p̫��ނ̍쐬
                if (mode == 0 || mode == 1)
                {
                    // �폜�p̫��ނ̍쐬�A TSP-SEND\TRASH\(���Ӑ�)
                    this.TspTrashPath = Path.Combine(this.TspTrashPath, customerCode.ToString().PadLeft(8, '0'));
                    if (!CreateDir(this.TspTrashPath)) return false;

                    // �폜�p̫��ނ̍쐬�B TSP-SEND\TRASH\(���Ӑ�)\(�`�[�ԍ�)
                    this.TspTrashPath = Path.Combine(this.TspTrashPath, salesSlipNum.ToString().PadLeft(9, '0'));
                }

                // ���M�p̫��ނ̍쐬�A TSP-SEND\(���Ӑ�)\(�`�[�ԍ�)
                this.TspSendPath = Path.Combine(this.TspSendPath, salesSlipNum.ToString().PadLeft(9, '0'));

                // �V�K�쐬����̫��ނ���U�폜����
                if (mode == 1)
                {
                    if (!DeleteDir(this.TspTrashPath)) return false;
                    if (!DeleteDir(this.TspSendPath)) return false;
                    if (!CreateDir(this.TspSendPath)) return false;
                }
                else
                {
                    // ̫��ލ쐬
                    if (!CreateDir(this.TspSendPath)) return false;
                    if (this.TspTrashPath != string.Empty && !CreateDir(this.TspTrashPath)) return false;
                }

                // �ꎞ̧���߽
                this.TspTmpPath = this.PathData.TspSndTmpPath;
                if (!CreateDir(this.TspTmpPath)) return false;
            }
            catch (Exception ex)
            {
                LogWrite("CreateDirMain()", "�t�H���_�p�X�F" + this.TspSendPath + "," + ex.ToString());
                return false;
            }

            return true;
            
        }

        /// <summary>
        /// ̫��ލ쐬
        /// </summary>
        /// <param name="sPath">�p�X</param>
        /// <returns>true:�����Afalse:���s</returns>
        /// <remarks>
        /// <br>Note       : XMĻ�يǗ�̫��ނ��쐬����B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool CreateDir(string sPath)
        {
            if (!Directory.Exists(sPath))
            {
                try
                {
                    Directory.CreateDirectory(sPath);
                }
                catch(Exception ex)
                {
                    LogWrite("CreateDir()", "�t�H���_�p�X" + sPath + "," + ex.ToString());
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// ̫��ލ폜
        /// </summary>
        /// <param name="sPath">�p�X</param>
        /// <returns>true:�����Afalse:���s</returns>
        /// <remarks>
        /// <br>Note       : XMĻ�يǗ�̫��ނ��폜����B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool DeleteDir(string sPath)
        {
            DirectoryInfo dir = new DirectoryInfo(sPath);
            try
            {
                if (dir.Exists)
                {
                    DirectoryInfo[] childs = dir.GetDirectories();
                    foreach (DirectoryInfo child in childs)
                    {
                        child.Delete(true);
                    }
                    dir.Delete(true);
                }
            }
            catch (Exception ex)
            {
                LogWrite("DeleteDir()", "�t�H���_�p�X" + sPath + "," + ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// TSP�`�[̧�ق̍쐬
        /// </summary>
        /// <param name="salesSlip">����`�[�f�[�^</param>
        /// <param name="acceptOdrCarWork">�󒍃}�X�^�i�ԗ��j</param>
        /// <param name="addUpOrgDetailWork"> �v�㌳���׃f�[�^</param>
        /// <param name="commonSeqNo">TSP�I�����C���ԍ�</param>
        /// <param name="sfEnterpriseCode">��ƃR�[�h</param>
        /// <remarks>
        /// <br>Note       : TSP�`�[̧�ق��쐬����B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool GetTspSdRvDt(SalesSlipWork salesSlip, AcceptOdrCarWork acceptOdrCarWork, AddUpOrgSalesDetailWork addUpOrgDetailWork, long commonSeqNo, string sfEnterpriseCode)
        {
            try
            {
                this.TspSdRvDt = new TspSdRvDt();
                this.TspSdRvDt.CreateDateTime = "0001-01-01T00:00:00";// �쐬����
                this.TspSdRvDt.UpdateDateTime = "0001-01-01T00:00:00"; // �X�V����
                this.TspSdRvDt.EnterpriseCode = EditItem(sfEnterpriseCode.Trim());// ��ƃR�[�h
                this.TspSdRvDt.EnterpriseName = string.Empty;// ��Ɩ�
                this.TspSdRvDt.FileHeaderGuid = "00000000-0000-0000-0000-000000000000";// GUID
                this.TspSdRvDt.UpdEmployeeCode = string.Empty;// �X�V�]�ƈ��R�[�h
                this.TspSdRvDt.UpdEmployeeName = string.Empty;// �X�V�]�ƈ���
                this.TspSdRvDt.UpdAssemblyId1 = string.Empty;// �X�V�A�Z���u��ID1
                this.TspSdRvDt.UpdAssemblyId2 = string.Empty;// �X�V�A�Z���u��ID2
                this.TspSdRvDt.LogicalDeleteCode = 0;// �_���폜�敪
                if (salesSlip.EnterpriseCode.Length >= 9)
                {
                    this.TspSdRvDt.PmEnterpriseCode = EditItem(sfEnterpriseCode.Trim().Substring(sfEnterpriseCode.Trim().Length - 9));// SF��ƃR�[�h�̉�9��
                }
                else
                {
                    this.TspSdRvDt.PmEnterpriseCode = EditItem(sfEnterpriseCode.Trim());// SF��ƃR�[�h
                }

                this.TspSdRvDt.TspCommNo = Convert.ToInt32(commonSeqNo);// TSP�ʐM�ԍ�
                this.TspSdRvDt.TspCommCount = this.TspCommCountTemp;// TSP�ʐM��
                this.TspSdRvDt.OrderContentsDivCd = 0;// �������e�敪 
                // �w�����ԍ��i������j
                string slipNo = salesSlip.PartySaleSlipNum.TrimStart('0');
                if (slipNo.Length > 9)
                {
                    this.TspSdRvDt.InstSlipNoStr = EditItem(slipNo.Substring(0, 9));
                }
                else
                {
                    this.TspSdRvDt.InstSlipNoStr = EditItem(slipNo);
                }
                this.TspSdRvDt.AcceptAnOrderNo = 0;// �󒍔ԍ�
                this.TspSdRvDt.DataInputSystem = 0;// �f�[�^���̓V�X�e��
                this.TspSdRvDt.DataInputSystemName = string.Empty;// �f�[�^���̓V�X�e����
                this.TspSdRvDt.SlipNo = string.Empty;// �`�[�ԍ�
                this.TspSdRvDt.SlipKind = 0;// �`�[���
                this.TspSdRvDt.CommConditionDivCd = 0;// �ʐM��ԋ敪
                this.TspSdRvDt.NumberPlate1Code = 0;// ���^�������ԍ�
                this.TspSdRvDt.NumberPlate1Name = string.Empty;// ���^�����ǖ���
                this.TspSdRvDt.NumberPlate2 = string.Empty;// �ԗ��o�^�ԍ��i��ʁj
                this.TspSdRvDt.NumberPlate3 = string.Empty;// �ԗ��o�^�ԍ��i�J�i�j
                this.TspSdRvDt.NumberPlate4 = 0;// �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                this.TspSdRvDt.ModelDesignationNo = acceptOdrCarWork.ModelDesignationNo;// �^���w��ԍ�
                this.TspSdRvDt.CategoryNo = acceptOdrCarWork.CategoryNo;// �ޕʔԍ�
                this.TspSdRvDt.MakerCode = acceptOdrCarWork.MakerCode;// ���[�J�[�R�[�h
                this.TspSdRvDt.ModelCode = acceptOdrCarWork.ModelCode;// �Ԏ�R�[�h
                this.TspSdRvDt.ModelSubCode = acceptOdrCarWork.ModelSubCode;// �Ԏ�T�u�R�[�h
                this.TspSdRvDt.ModelName = EditItem(acceptOdrCarWork.ModelFullName);// �Ԏ햼
                this.TspSdRvDt.CarInspectCertModel = string.Empty;// �Ԍ��،^��
                this.TspSdRvDt.FullModel = EditItem(acceptOdrCarWork.FullModel);// �^���i�t���^�j
                // �ԑ�ԍ�
                int retFrameNo;
                if (Int32.TryParse(acceptOdrCarWork.FrameNo, out retFrameNo))
                {
                    this.TspSdRvDt.FrameNo = retFrameNo;
                }
                else
                {
                    this.TspSdRvDt.FrameNo = 0;
                }
                this.TspSdRvDt.FrameModel = string.Empty;// �ԑ�^��
                this.TspSdRvDt.ChassisNo = string.Empty;// �V���V�[No
                this.TspSdRvDt.CarProperNo = 0;// �ԗ��ŗL�ԍ�
                this.TspSdRvDt.ProduceTypeOfYearNum = acceptOdrCarWork.FirstEntryDate;// ���Y�N���iNUM�^�C�v�j
                this.TspSdRvDt.SalesOrderDate = "0001-01-01T00:00:00";// ������
                this.TspSdRvDt.SalesOrderEmployeeCd = string.Empty;// �����ҏ]�ƈ��R�[�h
                this.TspSdRvDt.SalesOrderEmployeeNm = string.Empty;// �����ҏ]�ƈ�����
                this.TspSdRvDt.SalesOrderComment = string.Empty;// �������R�����g
                this.TspSdRvDt.OrderSideSystemVerCd = 0;// �������V�X�e���o�[�W�����敪
                this.TspSdRvDt.TspAnswerDataMngNo = 0;// TSP�񓚃f�[�^�Ǘ��ԍ�
                this.TspSdRvDt.TspSlipType = 0;// TSP�`�[�^�C�v
                this.TspSdRvDt.AcceptAnOrderDate = salesSlip.SalesDate.ToString("yyyy-MM-dd'T'00:00:00");// �󒍓�
                // PM�`�[�ԍ�
                int retSalesSlipNum;
                if (Int32.TryParse(salesSlip.SalesSlipNum, out retSalesSlipNum))
                {
                    this.TspSdRvDt.PmSlipNo = retSalesSlipNum;
                }
                else
                {
                    this.TspSdRvDt.PmSlipNo = 0;
                }
                this.TspSdRvDt.AcceptAnOrderNm = salesSlip.FrontEmployeeNm;// �󒍎Җ�
                this.TspSdRvDt.TspTotalSlipPrice = salesSlip.SalesTotalTaxExc;// TSP�`�[���v���z
                this.TspSdRvDt.PmComment = salesSlip.SlipNote + salesSlip.SlipNote2 + salesSlip.SlipNote3;// PM�R�����g
                this.TspSdRvDt.PmVersion = "8.10.1.0";// PM�o�[�W����
                this.TspSdRvDt.PmSendDate = DateTime.UtcNow.ToString("yyyy-MM-dd'T'00:00:00");// PM���M��
                // PM�`�[���
                if (salesSlip.SalesSlipCd == 0)
                {
                    // ����f�[�^.����`�[�敪���u0�F����v�̏ꍇ�A�u10:����v���Z�b�g
                    this.TspSdRvDt.PmSlipKind = 10;
                }
                else if (salesSlip.SalesSlipCd == 1)
                {
                    // ����f�[�^.����`�[�敪���u1�F�ԕi�v�̏ꍇ�A�u20:�ԕi�v���Z�b�g
                    this.TspSdRvDt.PmSlipKind = 20;
                }
                // PM�����`�[�ԍ�
                if (addUpOrgDetailWork != null && addUpOrgDetailWork.SalesSlipNum != string.Empty && addUpOrgDetailWork.AcptAnOdrStatus == 30)
                {
                    this.TspSdRvDt.PmOriginalSlipNo = Convert.ToInt32(addUpOrgDetailWork.SalesSlipNum);
                }
                else
                {
                    this.TspSdRvDt.PmOriginalSlipNo = 0;
                }
            }
            catch (Exception ex)
            {
                LogWrite("GetTspSdRvDt()", "����`�[�ԍ��F" + salesSlip.SalesSlipNum + "," + ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// TSP����̧�ق̍쐬
        /// </summary>
        /// <param name="salesSlip">����`�[�f�[�^</param>
        /// <param name="salesDetailList">���㖾�׃f�[�^</param>
        /// <param name="addUpOrgDetailWork"> �v�㌳���׃f�[�^</param>
        /// <param name="commonSeqNo">TSP�I�����C���ԍ�</param>
        /// <param name="sfEnterpriseCode">��ƃR�[�h</param>
        /// <remarks>
        /// <br>Note       : TSP����̧�ق��쐬����B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool GetTspSdRvDtl(SalesSlipWork salesSlip, ArrayList salesDetailList, AddUpOrgSalesDetailWork addUpOrgDetailWork, long commonSeqNo, string sfEnterpriseCode)
        {
            try
            {
                this.TspSdRvDtlList.Clear();
                foreach (SalesDetailWork salesDetail in salesDetailList)
                {
                    TspSdRvDtl tspSdRvDtl = new TspSdRvDtl();
                    tspSdRvDtl.CreateDateTime = "0001-01-01T00:00:00";// �쐬����
                    tspSdRvDtl.UpdateDateTime = "0001-01-01T00:00:00"; // �X�V����
                    tspSdRvDtl.EnterpriseCode = EditItem(sfEnterpriseCode.Trim()); // ��ƃR�[�h
                    tspSdRvDtl.EnterpriseName = string.Empty;// ��Ɩ�
                    tspSdRvDtl.FileHeaderGuid = "00000000-0000-0000-0000-000000000000";// GUID
                    tspSdRvDtl.UpdEmployeeCode = string.Empty;// �X�V�]�ƈ��R�[�h
                    tspSdRvDtl.UpdEmployeeName = string.Empty;// �X�V�]�ƈ���
                    tspSdRvDtl.UpdAssemblyId1 = string.Empty;// �X�V�A�Z���u��ID1
                    tspSdRvDtl.UpdAssemblyId2 = string.Empty;// �X�V�A�Z���u��ID2
                    tspSdRvDtl.LogicalDeleteCode = 0;// �_���폜�敪
                    if (salesSlip.EnterpriseCode.Length >= 9)
                    {
                        tspSdRvDtl.PmEnterpriseCode = EditItem(sfEnterpriseCode.Trim().Substring(sfEnterpriseCode.Trim().Length - 9));// SF��ƃR�[�h�̉�9��
                    }
                    else
                    {
                        tspSdRvDtl.PmEnterpriseCode = EditItem(sfEnterpriseCode.Trim());// SF��ƃR�[�h
                    }

                    tspSdRvDtl.TspCommNo = Convert.ToInt32(commonSeqNo);// TSP�ʐM�ԍ�
                    tspSdRvDtl.TspCommCount = this.TspCommCountTemp;// TSP�ʐM��
                    tspSdRvDtl.TspCommRowNo = salesDetail.SalesRowNo;// TSP�ʐM�s�ԍ�(TSP�I�����C���s�ԍ�)
                    tspSdRvDtl.DeliveredGoodsDiv = salesSlip.DeliveredGoodsDiv;// �[�i�敪
                    tspSdRvDtl.HandleDivCode = 0;// �戵�敪
                    //  �i��
                    if (salesDetail.GoodsNo == string.Empty)
                    {
                        tspSdRvDtl.PartsShape = 2;// ���i�`��
                    }
                    else
                    {
                        tspSdRvDtl.PartsShape = 1;// ���i�`��
                    }
                    tspSdRvDtl.DelivrdGdsConfCd = 0;// �[�i�m�F�敪
                    tspSdRvDtl.DeliGdsCmpltDueDate = "0001-01-01T00:00:00";// �[�i�����\���
                    tspSdRvDtl.TbsPartsCode = salesDetail.BLGoodsCode;// ���i�R�[�h(�ϊ�����g�p)
                    tspSdRvDtl.PmPartsNameKana = salesDetail.GoodsName;// PM���i��
                    // �������A�[�i��
                    if (salesDetail.ShipmentCnt == 0)
                    {
                        tspSdRvDtl.SalesOrderCount = 1;
                        tspSdRvDtl.DeliveredGoodsCount = 1;
                    }
                    else
                    {
                        if (addUpOrgDetailWork != null && addUpOrgDetailWork.SalesSlipNum != string.Empty 
                            && addUpOrgDetailWork.AcptAnOdrStatus == 30 && salesDetail.ShipmentCnt < 0)
                        {
                            tspSdRvDtl.SalesOrderCount = salesDetail.ShipmentCnt*(-1);
                            tspSdRvDtl.DeliveredGoodsCount = salesDetail.ShipmentCnt * (-1);
                        }
                        else
                        {
                            tspSdRvDtl.SalesOrderCount = salesDetail.ShipmentCnt;
                            tspSdRvDtl.DeliveredGoodsCount = salesDetail.ShipmentCnt;
                        }
                    }
                    tspSdRvDtl.PartsNoWithHyphen = EditItem(salesDetail.GoodsNo);// �n�C�t���t�i��
                    tspSdRvDtl.PmPartsMakerCode = salesDetail.GoodsMakerCd;// // PM���i���[�J�[�R�[�h
                    //---<< �����i�ԁA�������[�J�[�̃Z�b�g >>---//
                    // ����
                    if (salesDetail.GoodsKindCode == 0)
                    {
                        tspSdRvDtl.PurePartsMakerCode = salesDetail.GoodsMakerCd;
                        tspSdRvDtl.PurePrtsNoWithHyphen = EditItem(salesDetail.GoodsNo);
                    }

                    tspSdRvDtl.ListPrice = (long)salesDetail.ListPriceTaxExcFl;// �艿

                    if (salesDetail.ShipmentCnt == 0)
                    {
                        tspSdRvDtl.UnitPrice = salesDetail.SalesMoneyTaxExc;// ������z
                        tspSdRvDtl.PmDtlTakeinDivCd = 1;// PM���׎捞�敪
                    }
                    else
                    {
                        tspSdRvDtl.UnitPrice = (long)salesDetail.SalesUnPrcTaxExcFl;// ����P���i�Ŕ��C�����j
                        tspSdRvDtl.PmDtlTakeinDivCd = 0;// PM���׎捞�敪
                    }
                    TspSdRvDtlList.Add(tspSdRvDtl);
                }
            }
            catch(Exception ex)
            {
                LogWrite("GetTspSdRvDtl()", "����`�[�ԍ��F" + salesSlip.SalesSlipNum + "," + ex.ToString());
                return false;
            }
            return true;

        }

        /// <summary>
        /// ���ڕҏW����(������p)
        /// </summary>
        /// <returns>true:�����Afalse:���s</returns>
        /// <remarks>
        /// <br>Note       : ���ڕҏW����(������p)���s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private string EditItem(string strValue)
        {
            string outValue = string.Empty;
            if (!strValue.Equals(string.Empty))
            {
                // xml�g�p�֎~�����̒u��
                outValue = strValue.Replace("&" ,"&amp;");// & �� &amp;
                outValue = strValue.Replace("<", "&lt;");// < �� &lt;
                outValue = strValue.Replace(">", "&gt;");// > �� &gt;
                outValue = strValue.Replace("'", "&apos;");// ' �� &apos;
                outValue = strValue.Replace("''" ,"&quot;");// " �� &quot;
            }
            return outValue;
        }

        /// <summary>
        /// TSP�`�[�t�@�C���V���A���C�Y����
        /// </summary>
        /// <returns>true:�����Afalse:���s</returns>
        /// <remarks>
        /// <br>Note       : TSP�`�[�t�@�C���̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool Serialize()
        {
            try
            {
                string tspSdRvDt = Path.Combine(this.TspTmpPath, string.Format(TspSdRvDtName, this.TspCommCountTemp.ToString().PadLeft(2, '0')));
                UserSettingController.SerializeUserSetting(this.TspSdRvDt, Path.Combine(this.TspTmpPath, tspSdRvDt));
            }
            catch(Exception ex)
            {
                LogWrite("Serialize()", ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// TSP�`�[�t�@�C���V���A���C�Y����
        /// </summary>
        /// <returns>true:�����Afalse:���s</returns>
        /// <remarks>
        /// <br>Note       : TSP�`�[�t�@�C���̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool SerializeDtl()
        {
            try
            {
                string tspSdRvDt1 = Path.Combine(this.TspTmpPath, string.Format(TspSdRvDtlName, this.TspCommCountTemp.ToString().PadLeft(2, '0')));
                UserSettingController.SerializeUserSetting(this.TspSdRvDtlList, Path.Combine(this.TspTmpPath, tspSdRvDt1));
            }
            catch (Exception ex)
            {
                LogWrite("SerializeDtl()", ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// TSP�`�[�t�@�C����TSP���׃t�@�C���Í���
        /// </summary>
        /// <returns>true:�����Afalse:���s</returns>
        /// <remarks>
        /// <br>Note       : TSP�`�[�t�@�C����TSP���׃t�@�C���Í����������s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool Encrypt()
        {
            try
            {
                // TSP�`�[̧�وÍ���
                string xmlDtName = Path.Combine(this.TspTmpPath, string.Format(TspSdRvDtName, this.TspCommCountTemp.ToString().PadLeft(2, '0')));
                string xmlToDtName = Path.Combine(this.TspSendPath, string.Format(TspSdRvDtName, this.TspCommCountTemp.ToString().PadLeft(2, '0')));
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(TspSdRvDt));
                using (System.IO.FileStream stream = new System.IO.FileStream(xmlDtName, System.IO.FileMode.Create))
                {
                    MemoryStream memstr = new MemoryStream();
                    serializer.Serialize(memstr, TspSdRvDt);
                    byte[] baff = EncryptXML(memstr);
                    stream.Write(baff, 0, baff.Length);
                    stream.Close();
                }

                // TSP����̧�وÍ���
                string xmlDtlName = Path.Combine(this.TspTmpPath, string.Format(TspSdRvDtlName, this.TspCommCountTemp.ToString().PadLeft(2, '0')));
                string xmlToDtlName = Path.Combine(this.TspSendPath, string.Format(TspSdRvDtlName, this.TspCommCountTemp.ToString().PadLeft(2, '0')));
                System.Xml.Serialization.XmlSerializer serializer3 = new System.Xml.Serialization.XmlSerializer(typeof(TspSdRvDtl[]));

                using (System.IO.FileStream stream3 = new System.IO.FileStream(xmlDtlName, System.IO.FileMode.Create))
                {
                    MemoryStream memstr = new MemoryStream();
                    serializer3.Serialize(memstr, TspSdRvDtlList.ToArray());
                    byte[] baffDtl = EncryptXML(memstr);
                    stream3.Write(baffDtl, 0, baffDtl.Length);
                    stream3.Close();
                }
                if (File.Exists(xmlDtName))
                {
                    File.Copy(xmlDtName, xmlToDtName, false);
                    File.Delete(xmlDtName);
                }
                if (File.Exists(xmlDtlName))
                {
                    File.Copy(xmlDtlName, xmlToDtlName, false);
                    File.Delete(xmlDtlName);
                }
            }
            catch (Exception ex)
            {
                LogWrite("Encrypt()", ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// �Í�������
        /// </summary>
        /// <param name="stream"></param>
        /// <remarks>
        /// <br>Note       : �Í����������s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private static byte[] EncryptXML(MemoryStream stream)
        {
            MemoryStream ms = new MemoryStream();
            byte[] byteBuffer = new byte[stream.Length];
            // 3DES�Í���           
            stream.Position = 0;
            stream.Read(byteBuffer, 0, byteBuffer.Length);
            using (TripleDESCryptoServiceProvider des3 = new TripleDESCryptoServiceProvider())
            {
                // �L�[�y�я������x�N�^��ݒ�
                des3.Key = TspXMLDecryptTableResource.Key;
                des3.IV = TspXMLDecryptTableResource.InitVector;
                using (CryptoStream cs = new CryptoStream(ms, des3.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(byteBuffer, 0, byteBuffer.Length);
                    cs.FlushFinalBlock();
                }
            }
            return ms.ToArray();
        }

        /// <summary>
        /// ���M�f�[�^�폜����
        /// </summary>
        /// <returns>true:�����Afalse:���s</returns>
        /// <remarks>
        /// <br>Note       : ���M�f�[�^�폜�������s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool DeleteProc()
        {
            if (!Directory.Exists(this.TspTrashPath)) CreateDir(this.TspTrashPath);
            try
            {
                // �t�H���_���̃t�@�C������荞
                string[] fileList = System.IO.Directory.GetFiles(this.TspSendPath, "*.XML");
                string bakName = string.Empty;
                if (fileList.Length == 0)
                {
                    LogWrite("DeleteProc()", "�폜���t�@�C��������܂���B");
                    return false;
                }
                foreach (string file in fileList)
                {
                    FileInfo info = new FileInfo(file);
                    bakName = Path.Combine(this.TspTrashPath, info.Name);
                    File.Copy(file, bakName);
                }

                DirectoryInfo di = new DirectoryInfo(this.TspSendPath); 
                di.Delete(true); 
            }
            catch(Exception ex)
            {
                LogWrite("DeleteProc()", ex.ToString());
                return false;
            }

            return true;

        }

        /// <summary>
        /// ���O�o�͏���
        /// </summary>
        /// <param name="methodName">���\�b�h��</param>
        /// <param name="pMsg">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �G���[���O�������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private static void LogWrite(string methodName, string pMsg)
        {
            System.IO.FileStream fs;										// �t�@�C���X�g���[��
            System.IO.StreamWriter sw;										// �X�g���[��writer
            // Log�t�H���_�[
            string logFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Log");
            if (!Directory.Exists(logFolderPath))
            {
                // Log�t�H���_�[�����݂��Ȃ��ꍇ�A�쐬����
                Directory.CreateDirectory(logFolderPath);
            }
            // ���O�t�@�C��
            string logFilePath = Path.Combine(logFolderPath, "TSP���M�f�[�^�쐬");
            if (!Directory.Exists(logFilePath))
            {
                // Log�t�H���_�[�����݂��Ȃ��ꍇ�A�쐬����
                Directory.CreateDirectory(logFilePath);
            }
            string logFilePathName = Path.Combine(logFilePath, "PMTSP01201A.Log");
            fs = new FileStream(logFilePathName, FileMode.Append, FileAccess.Write, FileShare.Write);
            sw = new System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding("shift_jis"));
            string log = string.Format("{0},{1},{2}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), methodName, pMsg);
            sw.WriteLine(log);
            if (sw != null)
                sw.Close();
            if (fs != null)
                fs.Close();
        }
        # endregion

    }

    # region [�O��l�ێ�]
    /// <summary>
    /// �O��l�ێ�
    /// </summary>
    public class TspSndPathInfo
    {
        // �p�X
        private string _tspSndPath;

        // �ꎞ�p�X
        private string _tspSndTmpPath;

        /// <summary>
        /// �O��l�ێ��N���X
        /// </summary>
        public TspSndPathInfo()
        {

        }

        /// <summary>
        /// �p�X
        /// </summary>
        public string TspSndPath
        {
            get { return _tspSndPath; }
            set { _tspSndPath = value; }
        }

        /// <summary>
        /// �p�X
        /// </summary>
        public string TspSndTmpPath
        {
            get { return _tspSndTmpPath; }
            set { _tspSndTmpPath = value; }
        }

    }
    #endregion

    # region ����`�[�f�[�^
    /// <summary>
    /// ����`�[�f�[�^
    /// </summary>
    public class TspSdRvDt
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _fileHeaderGuid;

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

        /// <summary>PM��ƃR�[�h</summary>
        /// <remarks>���i���̊�ƃR�[�h</remarks>
        private string _pmEnterpriseCode = "";

        /// <summary>TSP�ʐM�ԍ�</summary>
        /// <remarks>�P���M���ɐU����ԍ�(PM���ɂč̔� or ��������SF���̔ԍ��̔�)</remarks>
        private Int32 _tspCommNo;

        /// <summary>TSP�ʐM��</summary>
        /// <remarks>PM�����P�����ɑ΂��ĉ񓚂��s����</remarks>
        private Int32 _tspCommCount;

        /// <summary>�������e�敪</summary>
        /// <remarks>1:�ʏ픭��,2:���i�₢���킹,3:�݌ɖ₢���킹</remarks>
        private Int32 _orderContentsDivCd;

        /// <summary>�w�����ԍ��i������j</summary>
        /// <remarks>�����^</remarks>
        private string _instSlipNoStr = "";

        /// <summary>�󒍔ԍ�</summary>
        /// <remarks>������(SF�EBK)�̎󒍔ԍ�</remarks>
        private Int32 _acceptAnOrderNo;

        /// <summary>�f�[�^���̓V�X�e��</summary>
        /// <remarks>0:����,1:����,2:���,3:�Ԕ́@�������̃f�[�^���̓V�X�e��</remarks>
        private Int32 _dataInputSystem;

        /// <summary>�`�[�ԍ�</summary>
        private string _slipNo = "";

        /// <summary>�`�[���</summary>
        /// <remarks>10:����,20:�w��,21:���菑,30:�[�i,40:���C</remarks>
        private Int32 _slipKind;

        /// <summary>�ʐM��ԋ敪</summary>
        /// <remarks>0:������,1:���M�ς�,2:������,9:�G���[</remarks>
        private Int32 _commConditionDivCd;

        /// <summary>���^�������ԍ�</summary>
        private Int32 _numberPlate1Code;

        /// <summary>���^�����ǖ���</summary>
        private string _numberPlate1Name = "";

        /// <summary>�ԗ��o�^�ԍ��i��ʁj</summary>
        private string _numberPlate2 = "";

        /// <summary>�ԗ��o�^�ԍ��i�J�i�j</summary>
        private string _numberPlate3 = "";

        /// <summary>�ԗ��o�^�ԍ��i�v���[�g�ԍ��j</summary>
        private Int32 _numberPlate4;

        /// <summary>�^���w��ԍ�</summary>
        private Int32 _modelDesignationNo;

        /// <summary>�ޕʔԍ�</summary>
        private Int32 _categoryNo;

        /// <summary>���[�J�[�R�[�h</summary>
        /// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _makerCode;

        /// <summary>�Ԏ�R�[�h</summary>
        /// <remarks>�Ԗ�����(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _modelCode;

        /// <summary>�Ԏ�T�u�R�[�h</summary>
        /// <remarks>0�`899:�񋟕�,900�`հ�ް�o�^</remarks>
        private Int32 _modelSubCode;

        /// <summary>�Ԏ햼</summary>
        private string _modelName = "";

        /// <summary>�Ԍ��،^��</summary>
        private string _carInspectCertModel = "";

        /// <summary>�^���i�t���^�j</summary>
        /// <remarks>�t���^��(44���p)</remarks>
        private string _fullModel = "";

        /// <summary>�ԑ�ԍ�</summary>
        private Int32 _frameNo;

        /// <summary>�ԑ�^��</summary>
        private string _frameModel = "";

        /// <summary>�V���V�[No</summary>
        private string _chassisNo = "";

        /// <summary>�ԗ��ŗL�ԍ�</summary>
        /// <remarks>���j�[�N�ȌŒ�ԍ�</remarks>
        private Int32 _carProperNo;

        /// <summary>���Y�N���iNUM�^�C�v�j</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _produceTypeOfYearNum;

        /// <summary>������</summary>
        /// <remarks>YYYYMMDD</remarks>
        private string _salesOrderDate;

        /// <summary>�����ҏ]�ƈ��R�[�h</summary>
        /// <remarks>���������]�ƈ��R�[�h</remarks>
        private string _salesOrderEmployeeCd = "";

        /// <summary>�����ҏ]�ƈ�����</summary>
        /// <remarks>���������]�ƈ�����</remarks>
        private string _salesOrderEmployeeNm = "";

        /// <summary>�������R�����g</summary>
        /// <remarks>��������ۂɓ��͂���R�����g</remarks>
        private string _salesOrderComment = "";

        /// <summary>�������V�X�e���o�[�W�����敪</summary>
        /// <remarks>0:SF.NS or BK.NS,1:Pegasus,2:Phoenix</remarks>
        private Int32 _orderSideSystemVerCd;

        /// <summary>TSP�񓚃f�[�^�Ǘ��ԍ�</summary>
        /// <remarks>�������A�ԍ��̔�</remarks>
        private Int32 _tspAnswerDataMngNo;

        /// <summary>TSP�`�[�^�C�v</summary>
        /// <remarks>0:�I�����C��������,1:�d�b������</remarks>
        private Int32 _tspSlipType;

        /// <summary>�󒍓�</summary>
        /// <remarks>YYYYMMDD</remarks>
        private string _acceptAnOrderDate;

        /// <summary>PM�`�[�ԍ�</summary>
        private Int32 _pmSlipNo;

        /// <summary>�󒍎Җ�</summary>
        /// <remarks>�󒍂����]�ƈ�����</remarks>
        private string _acceptAnOrderNm = "";

        /// <summary>TSP�`�[���v���z</summary>
        private Int64 _tspTotalSlipPrice;

        /// <summary>PM�R�����g</summary>
        private string _pmComment = "";

        /// <summary>PM�o�[�W����</summary>
        private string _pmVersion = "";

        /// <summary>PM���M��</summary>
        /// <remarks>PM�������M�������t YYYYMMDD</remarks>
        private string _pmSendDate;

        /// <summary>PM�`�[���</summary>
        /// <remarks>10:����A20:�ԕi</remarks>
        private Int32 _pmSlipKind;

        /// <summary>PM�����`�[�ԍ�</summary>
        /// <remarks>�ԓ`�E�ԕi�̏ꍇ�Ɍ��̍��`�[�ԍ���ݒ�</remarks>
        private Int32 _pmOriginalSlipNo;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�f�[�^���̓V�X�e������</summary>
        /// <remarks>����,����,���,�Ԕ�</remarks>
        private string _dataInputSystemName = "";


        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTime
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
        public string FileHeaderGuid
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

        /// public propaty name  :  PmEnterpriseCode
        /// <summary>PM��ƃR�[�h�v���p�e�B</summary>
        /// <value>���i���̊�ƃR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PmEnterpriseCode
        {
            get { return _pmEnterpriseCode; }
            set { _pmEnterpriseCode = value; }
        }

        /// public propaty name  :  TspCommNo
        /// <summary>TSP�ʐM�ԍ��v���p�e�B</summary>
        /// <value>�P���M���ɐU����ԍ�(PM���ɂč̔� or ��������SF���̔ԍ��̔�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP�ʐM�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TspCommNo
        {
            get { return _tspCommNo; }
            set { _tspCommNo = value; }
        }

        /// public propaty name  :  TspCommCount
        /// <summary>TSP�ʐM�񐔃v���p�e�B</summary>
        /// <value>PM�����P�����ɑ΂��ĉ񓚂��s����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP�ʐM�񐔃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TspCommCount
        {
            get { return _tspCommCount; }
            set { _tspCommCount = value; }
        }

        /// public propaty name  :  OrderContentsDivCd
        /// <summary>�������e�敪�v���p�e�B</summary>
        /// <value>1:�ʏ픭��,2:���i�₢���킹,3:�݌ɖ₢���킹</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������e�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OrderContentsDivCd
        {
            get { return _orderContentsDivCd; }
            set { _orderContentsDivCd = value; }
        }

        /// public propaty name  :  InstSlipNoStr
        /// <summary>�w�����ԍ��i������j�v���p�e�B</summary>
        /// <value>�����^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �w�����ԍ��i������j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InstSlipNoStr
        {
            get { return _instSlipNoStr; }
            set { _instSlipNoStr = value; }
        }

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>�󒍔ԍ��v���p�e�B</summary>
        /// <value>������(SF�EBK)�̎󒍔ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcceptAnOrderNo
        {
            get { return _acceptAnOrderNo; }
            set { _acceptAnOrderNo = value; }
        }

        /// public propaty name  :  DataInputSystem
        /// <summary>�f�[�^���̓V�X�e���v���p�e�B</summary>
        /// <value>0:����,1:����,2:���,3:�Ԕ́@�������̃f�[�^���̓V�X�e��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^���̓V�X�e���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataInputSystem
        {
            get { return _dataInputSystem; }
            set { _dataInputSystem = value; }
        }

        /// public propaty name  :  SlipNo
        /// <summary>�`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNo
        {
            get { return _slipNo; }
            set { _slipNo = value; }
        }

        /// public propaty name  :  SlipKind
        /// <summary>�`�[��ʃv���p�e�B</summary>
        /// <value>10:����,20:�w��,21:���菑,30:�[�i,40:���C</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipKind
        {
            get { return _slipKind; }
            set { _slipKind = value; }
        }

        /// public propaty name  :  CommConditionDivCd
        /// <summary>�ʐM��ԋ敪�v���p�e�B</summary>
        /// <value>0:������,1:���M�ς�,2:������,9:�G���[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ʐM��ԋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CommConditionDivCd
        {
            get { return _commConditionDivCd; }
            set { _commConditionDivCd = value; }
        }

        /// public propaty name  :  NumberPlate1Code
        /// <summary>���^�������ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���^�������ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NumberPlate1Code
        {
            get { return _numberPlate1Code; }
            set { _numberPlate1Code = value; }
        }

        /// public propaty name  :  NumberPlate1Name
        /// <summary>���^�����ǖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���^�����ǖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NumberPlate1Name
        {
            get { return _numberPlate1Name; }
            set { _numberPlate1Name = value; }
        }

        /// public propaty name  :  NumberPlate2
        /// <summary>�ԗ��o�^�ԍ��i��ʁj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��o�^�ԍ��i��ʁj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NumberPlate2
        {
            get { return _numberPlate2; }
            set { _numberPlate2 = value; }
        }

        /// public propaty name  :  NumberPlate3
        /// <summary>�ԗ��o�^�ԍ��i�J�i�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��o�^�ԍ��i�J�i�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NumberPlate3
        {
            get { return _numberPlate3; }
            set { _numberPlate3 = value; }
        }

        /// public propaty name  :  NumberPlate4
        /// <summary>�ԗ��o�^�ԍ��i�v���[�g�ԍ��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��o�^�ԍ��i�v���[�g�ԍ��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NumberPlate4
        {
            get { return _numberPlate4; }
            set { _numberPlate4 = value; }
        }

        /// public propaty name  :  ModelDesignationNo
        /// <summary>�^���w��ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���w��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelDesignationNo
        {
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
        }

        /// public propaty name  :  CategoryNo
        /// <summary>�ޕʔԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ޕʔԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  ModelCode
        /// <summary>�Ԏ�R�[�h�v���p�e�B</summary>
        /// <value>�Ԗ�����(��) 1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelCode
        {
            get { return _modelCode; }
            set { _modelCode = value; }
        }

        /// public propaty name  :  ModelSubCode
        /// <summary>�Ԏ�T�u�R�[�h�v���p�e�B</summary>
        /// <value>0�`899:�񋟕�,900�`հ�ް�o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�T�u�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelSubCode
        {
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
        }

        /// public propaty name  :  ModelName
        /// <summary>�Ԏ햼�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ햼�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelName
        {
            get { return _modelName; }
            set { _modelName = value; }
        }

        /// public propaty name  :  CarInspectCertModel
        /// <summary>�Ԍ��،^���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԍ��،^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarInspectCertModel
        {
            get { return _carInspectCertModel; }
            set { _carInspectCertModel = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>�^���i�t���^�j�v���p�e�B</summary>
        /// <value>�t���^��(44���p)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���i�t���^�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  FrameNo
        /// <summary>�ԑ�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԑ�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FrameNo
        {
            get { return _frameNo; }
            set { _frameNo = value; }
        }

        /// public propaty name  :  FrameModel
        /// <summary>�ԑ�^���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԑ�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrameModel
        {
            get { return _frameModel; }
            set { _frameModel = value; }
        }

        /// public propaty name  :  ChassisNo
        /// <summary>�V���V�[No�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���V�[No�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChassisNo
        {
            get { return _chassisNo; }
            set { _chassisNo = value; }
        }

        /// public propaty name  :  CarProperNo
        /// <summary>�ԗ��ŗL�ԍ��v���p�e�B</summary>
        /// <value>���j�[�N�ȌŒ�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��ŗL�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarProperNo
        {
            get { return _carProperNo; }
            set { _carProperNo = value; }
        }

        /// public propaty name  :  ProduceTypeOfYearNum
        /// <summary>���Y�N���iNUM�^�C�v�j�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Y�N���iNUM�^�C�v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ProduceTypeOfYearNum
        {
            get { return _produceTypeOfYearNum; }
            set { _produceTypeOfYearNum = value; }
        }

        /// public propaty name  :  SalesOrderDate
        /// <summary>�������v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesOrderDate
        {
            get { return _salesOrderDate; }
            set { _salesOrderDate = value; }
        }

        /// public propaty name  :  SalesOrderEmployeeCd
        /// <summary>�����ҏ]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���������]�ƈ��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ҏ]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesOrderEmployeeCd
        {
            get { return _salesOrderEmployeeCd; }
            set { _salesOrderEmployeeCd = value; }
        }

        /// public propaty name  :  SalesOrderEmployeeNm
        /// <summary>�����ҏ]�ƈ����̃v���p�e�B</summary>
        /// <value>���������]�ƈ�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ҏ]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesOrderEmployeeNm
        {
            get { return _salesOrderEmployeeNm; }
            set { _salesOrderEmployeeNm = value; }
        }

        /// public propaty name  :  SalesOrderComment
        /// <summary>�������R�����g�v���p�e�B</summary>
        /// <value>��������ۂɓ��͂���R�����g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������R�����g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesOrderComment
        {
            get { return _salesOrderComment; }
            set { _salesOrderComment = value; }
        }

        /// public propaty name  :  OrderSideSystemVerCd
        /// <summary>�������V�X�e���o�[�W�����敪�v���p�e�B</summary>
        /// <value>0:SF.NS or BK.NS,1:Pegasus,2:Phoenix</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������V�X�e���o�[�W�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OrderSideSystemVerCd
        {
            get { return _orderSideSystemVerCd; }
            set { _orderSideSystemVerCd = value; }
        }

        /// public propaty name  :  TspAnswerDataMngNo
        /// <summary>TSP�񓚃f�[�^�Ǘ��ԍ��v���p�e�B</summary>
        /// <value>�������A�ԍ��̔�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP�񓚃f�[�^�Ǘ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TspAnswerDataMngNo
        {
            get { return _tspAnswerDataMngNo; }
            set { _tspAnswerDataMngNo = value; }
        }

        /// public propaty name  :  TspSlipType
        /// <summary>TSP�`�[�^�C�v�v���p�e�B</summary>
        /// <value>0:�I�����C��������,1:�d�b������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP�`�[�^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TspSlipType
        {
            get { return _tspSlipType; }
            set { _tspSlipType = value; }
        }

        /// public propaty name  :  AcceptAnOrderDate
        /// <summary>�󒍓��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AcceptAnOrderDate
        {
            get { return _acceptAnOrderDate; }
            set { _acceptAnOrderDate = value; }
        }

        /// public propaty name  :  PmSlipNo
        /// <summary>PM�`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM�`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PmSlipNo
        {
            get { return _pmSlipNo; }
            set { _pmSlipNo = value; }
        }

        /// public propaty name  :  AcceptAnOrderNm
        /// <summary>�󒍎Җ��v���p�e�B</summary>
        /// <value>�󒍂����]�ƈ�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍎Җ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AcceptAnOrderNm
        {
            get { return _acceptAnOrderNm; }
            set { _acceptAnOrderNm = value; }
        }

        /// public propaty name  :  TspTotalSlipPrice
        /// <summary>TSP�`�[���v���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP�`�[���v���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TspTotalSlipPrice
        {
            get { return _tspTotalSlipPrice; }
            set { _tspTotalSlipPrice = value; }
        }

        /// public propaty name  :  PmComment
        /// <summary>PM�R�����g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM�R�����g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PmComment
        {
            get { return _pmComment; }
            set { _pmComment = value; }
        }

        /// public propaty name  :  PmVersion
        /// <summary>PM�o�[�W�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM�o�[�W�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PmVersion
        {
            get { return _pmVersion; }
            set { _pmVersion = value; }
        }

        /// public propaty name  :  PmSendDate
        /// <summary>PM���M���v���p�e�B</summary>
        /// <value>PM�������M�������t YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM���M���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PmSendDate
        {
            get { return _pmSendDate; }
            set { _pmSendDate = value; }
        }

        /// public propaty name  :  PmSlipKind
        /// <summary>PM�`�[��ʃv���p�e�B</summary>
        /// <value>10:����A20:�ԕi</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM�`�[��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PmSlipKind
        {
            get { return _pmSlipKind; }
            set { _pmSlipKind = value; }
        }

        /// public propaty name  :  PmOriginalSlipNo
        /// <summary>PM�����`�[�ԍ��v���p�e�B</summary>
        /// <value>�ԓ`�E�ԕi�̏ꍇ�Ɍ��̍��`�[�ԍ���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM�����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PmOriginalSlipNo
        {
            get { return _pmOriginalSlipNo; }
            set { _pmOriginalSlipNo = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        /// public propaty name  :  DataInputSystemName
        /// <summary>�f�[�^���̓V�X�e�����̃v���p�e�B</summary>
        /// <value>����,����,���,�Ԕ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^���̓V�X�e�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DataInputSystemName
        {
            get { return _dataInputSystemName; }
            set { _dataInputSystemName = value; }
        }
    }
    # endregion

    # region ���㖾�׃f�[�^
    /// <summary>
    /// ���㖾�׃f�[�^
    /// </summary>
    public class TspSdRvDtl
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _fileHeaderGuid;

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

        /// <summary>PM��ƃR�[�h</summary>
        /// <remarks>���i���̊�ƃR�[�h</remarks>
        private string _pmEnterpriseCode = "";

        /// <summary>TSP�ʐM�ԍ�</summary>
        /// <remarks>�P���M���ɐU����ԍ�(PM���ɂč̔� or ��������SF���̔ԍ��̔�)</remarks>
        private Int32 _tspCommNo;

        /// <summary>TSP�ʐM��</summary>
        /// <remarks>PM�����P�����ɑ΂��ĉ񓚂��s����</remarks>
        private Int32 _tspCommCount;

        /// <summary>TSP�ʐM�s�ԍ�</summary>
        private Int32 _tspCommRowNo;

        /// <summary>�[�i�敪</summary>
        /// <remarks>0:�z��,1:����</remarks>
        private Int32 _deliveredGoodsDiv;

        /// <summary>�戵�敪</summary>
        /// <remarks>0:��舵���i,1:�[���m�F��,2:����舵���i</remarks>
        private Int32 _handleDivCode;

        /// <summary>���i�`��</summary>
        /// <remarks>1:���i,2:�p�i</remarks>
        private Int32 _partsShape;

        /// <summary>�[�i�m�F�敪</summary>
        /// <remarks>0:���m�F,1:�m�F</remarks>
        private Int32 _delivrdGdsConfCd;

        /// <summary>�[�i�����\���</summary>
        /// <remarks>�[�i�\����t YYYYMMDD</remarks>
        private string _deliGdsCmpltDueDate;

        /// <summary>�����i�R�[�h</summary>
        /// <remarks>1�`99999:�񋟕�,100000�`���[�U�[�o�^�p</remarks>
        private Int32 _tbsPartsCode;

        /// <summary>PM���i���i�J�i�j</summary>
        /// <remarks>PM���̕i��</remarks>
        private string _pmPartsNameKana = "";

        /// <summary>������</summary>
        private Double _salesOrderCount;

        /// <summary>�[�i��</summary>
        private Double _deliveredGoodsCount;

        /// <summary>�n�C�t���t�i��</summary>
        private string _partsNoWithHyphen = "";

        /// <summary>PM���i���[�J�[�R�[�h</summary>
        /// <remarks>PM���̕��i���[�J�[�R�[�h</remarks>
        private Int32 _pmPartsMakerCode;

        /// <summary>�������i���[�J�[�R�[�h</summary>
        private Int32 _purePartsMakerCode;

        /// <summary>�����n�C�t���t�i��</summary>
        /// <remarks>SF�EBK�������́A�`�[���ׂ̃n�C�t���t�i�ԂƂȂ�</remarks>
        private string _purePrtsNoWithHyphen = "";

        /// <summary>�艿</summary>
        private Int64 _listPrice;

        /// <summary>�P��</summary>
        private Int64 _unitPrice;

        /// <summary>PM���׎捞�敪</summary>
        /// <remarks>0:�捞��,1:�捞�s��</remarks>
        private Int32 _pmDtlTakeinDivCd;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTime
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
        public string UpdateDateTime
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
        public string FileHeaderGuid
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

        /// public propaty name  :  PmEnterpriseCode
        /// <summary>PM��ƃR�[�h�v���p�e�B</summary>
        /// <value>���i���̊�ƃR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PmEnterpriseCode
        {
            get { return _pmEnterpriseCode; }
            set { _pmEnterpriseCode = value; }
        }

        /// public propaty name  :  TspCommNo
        /// <summary>TSP�ʐM�ԍ��v���p�e�B</summary>
        /// <value>�P���M���ɐU����ԍ�(PM���ɂč̔� or ��������SF���̔ԍ��̔�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP�ʐM�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TspCommNo
        {
            get { return _tspCommNo; }
            set { _tspCommNo = value; }
        }

        /// public propaty name  :  TspCommCount
        /// <summary>TSP�ʐM�񐔃v���p�e�B</summary>
        /// <value>PM�����P�����ɑ΂��ĉ񓚂��s����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP�ʐM�񐔃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TspCommCount
        {
            get { return _tspCommCount; }
            set { _tspCommCount = value; }
        }

        /// public propaty name  :  TspCommRowNo
        /// <summary>TSP�ʐM�s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP�ʐM�s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TspCommRowNo
        {
            get { return _tspCommRowNo; }
            set { _tspCommRowNo = value; }
        }

        /// public propaty name  :  DeliveredGoodsDiv
        /// <summary>�[�i�敪�v���p�e�B</summary>
        /// <value>0:�z��,1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeliveredGoodsDiv
        {
            get { return _deliveredGoodsDiv; }
            set { _deliveredGoodsDiv = value; }
        }

        /// public propaty name  :  HandleDivCode
        /// <summary>�戵�敪�v���p�e�B</summary>
        /// <value>0:��舵���i,1:�[���m�F��,2:����舵���i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �戵�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HandleDivCode
        {
            get { return _handleDivCode; }
            set { _handleDivCode = value; }
        }

        /// public propaty name  :  PartsShape
        /// <summary>���i�`�ԃv���p�e�B</summary>
        /// <value>1:���i,2:�p�i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�`�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsShape
        {
            get { return _partsShape; }
            set { _partsShape = value; }
        }

        /// public propaty name  :  DelivrdGdsConfCd
        /// <summary>�[�i�m�F�敪�v���p�e�B</summary>
        /// <value>0:���m�F,1:�m�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�m�F�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DelivrdGdsConfCd
        {
            get { return _delivrdGdsConfCd; }
            set { _delivrdGdsConfCd = value; }
        }

        /// public propaty name  :  DeliGdsCmpltDueDate
        /// <summary>�[�i�����\����v���p�e�B</summary>
        /// <value>�[�i�\����t YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�����\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliGdsCmpltDueDate
        {
            get { return _deliGdsCmpltDueDate; }
            set { _deliGdsCmpltDueDate = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>�����i�R�[�h�v���p�e�B</summary>
        /// <value>1�`99999:�񋟕�,100000�`���[�U�[�o�^�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  PmPartsNameKana
        /// <summary>PM���i���i�J�i�j�v���p�e�B</summary>
        /// <value>PM���̕i��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM���i���i�J�i�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PmPartsNameKana
        {
            get { return _pmPartsNameKana; }
            set { _pmPartsNameKana = value; }
        }

        /// public propaty name  :  SalesOrderCount
        /// <summary>�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesOrderCount
        {
            get { return _salesOrderCount; }
            set { _salesOrderCount = value; }
        }

        /// public propaty name  :  DeliveredGoodsCount
        /// <summary>�[�i���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DeliveredGoodsCount
        {
            get { return _deliveredGoodsCount; }
            set { _deliveredGoodsCount = value; }
        }

        /// public propaty name  :  PartsNoWithHyphen
        /// <summary>�n�C�t���t�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t���t�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsNoWithHyphen
        {
            get { return _partsNoWithHyphen; }
            set { _partsNoWithHyphen = value; }
        }

        /// public propaty name  :  PmPartsMakerCode
        /// <summary>PM���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>PM���̕��i���[�J�[�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PmPartsMakerCode
        {
            get { return _pmPartsMakerCode; }
            set { _pmPartsMakerCode = value; }
        }

        /// public propaty name  :  PurePartsMakerCode
        /// <summary>�������i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PurePartsMakerCode
        {
            get { return _purePartsMakerCode; }
            set { _purePartsMakerCode = value; }
        }

        /// public propaty name  :  PurePrtsNoWithHyphen
        /// <summary>�����n�C�t���t�i�ԃv���p�e�B</summary>
        /// <value>SF�EBK�������́A�`�[���ׂ̃n�C�t���t�i�ԂƂȂ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����n�C�t���t�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PurePrtsNoWithHyphen
        {
            get { return _purePrtsNoWithHyphen; }
            set { _purePrtsNoWithHyphen = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>�艿�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  UnitPrice
        /// <summary>�P���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        /// public propaty name  :  PmDtlTakeinDivCd
        /// <summary>PM���׎捞�敪�v���p�e�B</summary>
        /// <value>0:�捞��,1:�捞�s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM���׎捞�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PmDtlTakeinDivCd
        {
            get { return _pmDtlTakeinDivCd; }
            set { _pmDtlTakeinDivCd = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }
    }
    # endregion
}
