//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^�N���A����
// �v���O�����T�v   : �f�[�^�N���A�Ώۂ̒�`
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/06/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : duzg
// �C �� ��  2011/08/19  �C�����e : Redmine#23791�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/26  �C�����e : DC�������O��DC�e�f�[�^�̃N���A������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : Liangsd
// �C �� ��  2011/09/06 �C�����e :  Redmine#23918���_�Ǘ�����PG�ύX�ǉ��˗���ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �f�[�^�N���A�e�[�u����`�X�N���X
    /// </summary>
    /// <remarks>
    /// Note       : �f�[�^�N���A�����ł��B<br />
    /// Programmer : ���w�q<br />
    /// Date       : 2009.06.16<br />
    /// Update Note: 2011.08.19 duzg
    ///            : Redmine#23791
    /// </remarks>
    public class DataClear
    {
        private const string TBL_STOCKADJUST_ID = "STOCKADJUSTRF";
        private const string TBL_STOCKADJUSTDTL_ID = "STOCKADJUSTDTLRF";
        private const string TBL_STOCKMOVE_ID = "STOCKMOVERF";
        private const string TBL_STOCKACPAYHIST_ID = "STOCKACPAYHISTRF";
        private const string TBL_STOCKSLIP_ID = "STOCKSLIPRF";
        private const string TBL_STOCKDETAIL_ID = "STOCKDETAILRF";
        private const string TBL_SALESSLIP_ID = "SALESSLIPRF";
        private const string TBL_SALESDETAIL_ID = "SALESDETAILRF";
        private const string TBL_DEPSITMAIN_ID = "DEPSITMAINRF";
        private const string TBL_DMDCADDUPHIS_ID = "DMDCADDUPHISRF";
        private const string TBL_PAYMENTADDUPHIS_ID = "PAYMENTADDUPHISRF";
        private const string TBL_MONTHLYADDUPHIS_ID = "MONTHLYADDUPHISRF";
        private const string TBL_PAYMENTSLP_ID = "PAYMENTSLPRF";
        private const string TBL_ACCEPTODR_ID = "ACCEPTODRRF";
        private const string TBL_DEPOSITALW_ID = "DEPOSITALWRF";
        private const string TBL_SALESHISTORY_ID = "SALESHISTORYRF";
        private const string TBL_SALESHISTDTL_ID = "SALESHISTDTLRF";
        private const string TBL_STOCKSLIPHIST_ID = "STOCKSLIPHISTRF";
        private const string TBL_STOCKSLHISTDTL_ID = "STOCKSLHISTDTLRF";
        private const string TBL_MTTLSALESSLIP_ID = "MTTLSALESSLIPRF";
        private const string TBL_GOODSMTTLSASLIP_ID = "GOODSMTTLSASLIPRF";
        private const string TBL_MTTLSTOCKSLIP_ID = "MTTLSTOCKSLIPRF";
        private const string TBL_MTTLSALESSTOCKSLIP_ID = "MTTLSALESSTOCKSLIPRF";
        private const string TBL_DEPSITDTL_ID = "DEPSITDTLRF";
        private const string TBL_PAYMENTDTL_ID = "PAYMENTDTLRF";
        private const string TBL_ACCEPTODRCAR_ID = "ACCEPTODRCARRF";
        private const string TBL_UOEORDERDTL_ID = "UOEORDERDTLRF";
        private const string TBL_STOCKCHECKDTL_ID = "STOCKCHECKDTLRF";
        private const string TBL_RETURNUPPERST_ID = "RETURNUPPERSTRF";
        private const string TBL_CUSTDMDPRC_ID = "CUSTDMDPRCRF";
        private const string TBL_CUSTACCREC_ID = "CUSTACCRECRF";
        private const string TBL_SUPLIERPAY_ID = "SUPLIERPAYRF";
        private const string TBL_SUPLACCPAY_ID = "SUPLACCPAYRF";
        private const string TBL_DMDDEPOTOTAL_ID = "DMDDEPOTOTALRF";
        private const string TBL_ACCRECDEPOTOTAL_ID = "ACCRECDEPOTOTALRF";
        private const string TBL_ACCPAYTOTAL_ID = "ACCPAYTOTALRF";
        private const string TBL_ACALCPAYTOTAL_ID = "ACALCPAYTOTALRF";
        private const string TBL_STOCKHISTORY_ID = "STOCKHISTORYRF";
        private const string TBL_NOMNGSET_ID = "NOMNGSETRF";
		// ADD 2011.08.26 ���� ---------->>>>>
		private const string TBL_DCDATAINFO_ID = "DCDATAINFO";
        //private const string TBL_DCMUSTINFO_ID = "DCMUSTINFO";//DEL by Liangsd     2011/09/06
		// ADD 2011.08.26 ���� ----------<<<<<

        // ---------------------- ADD START 2011.08.19 duzg for Redmine#23791 ----------------->>>>>
        // SCM�󒍃f�[�^
        private const string TBL_SCMACODRDATA_ID = "SCMACODRDATARF";
        // SCM�󔭒��f�[�^(�ԗ����)
        private const string TBL_SCMACODRDTCAR_ID = "SCMACODRDTCARRF";
        // SCM�󒍖��׃f�[�^�i�⍇���E�����j
        private const string TBL_SCMACODRDTLIQ_ID = "SCMACODRDTLIQRF";
        // SCM�󒍖��׃f�[�^�i�񓚁j
        private const string TBL_SCMODRDATA_ID = "SCMACODRDTLASRF";
        // ---------------------- ADD END 2011.08.19 duzg for Redmine#23791 -----------------<<<<<
        
        private const string TBL_STOCKADJUST_NM = "�݌ɒ����f�[�^";
        private const string TBL_STOCKADJUSTDTL_NM = "�݌ɒ������׃f�[�^";
        private const string TBL_STOCKMOVE_NM = "�݌Ɉړ��f�[�^";
        private const string TBL_STOCKACPAYHIST_NM = "�݌Ɏ󕥗����f�[�^";
        private const string TBL_STOCKSLIP_NM = "�d���f�[�^";
        private const string TBL_STOCKDETAIL_NM = "�d�����׃f�[�^";
        private const string TBL_SALESSLIP_NM = "����f�[�^";
        private const string TBL_SALESDETAIL_NM = "���㖾�׃f�[�^";
        private const string TBL_DEPSITMAIN_NM = "�����}�X�^";
        private const string TBL_DMDCADDUPHIS_NM = "�������X�V�����}�X�^";
        private const string TBL_PAYMENTADDUPHIS_NM = "�x�����X�V�����}�X�^";
        private const string TBL_MONTHLYADDUPHIS_NM = "�������X�V�����f�[�^";
        private const string TBL_PAYMENTSLP_NM = "�x���`�[�}�X�^";
        private const string TBL_ACCEPTODR_NM = "�󒍃}�X�^";
        private const string TBL_DEPOSITALW_NM = "���������}�X�^";
        private const string TBL_SALESHISTORY_NM = "���㗚���f�[�^";
        private const string TBL_SALESHISTDTL_NM = "���㗚�𖾍׃f�[�^";
        private const string TBL_STOCKSLIPHIST_NM = "�d�������f�[�^";
        private const string TBL_STOCKSLHISTDTL_NM = "�d�����𖾍׃f�[�^";
        private const string TBL_MTTLSALESSLIP_NM = "���㌎���W�v�f�[�^";
        private const string TBL_GOODSMTTLSASLIP_NM = "���i�ʔ��㌎���W�v�f�[�^";
        private const string TBL_MTTLSTOCKSLIP_NM = "�d�������W�v�f�[�^";
        private const string TBL_MTTLSALESSTOCKSLIP_NM = "����d�������W�v�f�[�^";
        private const string TBL_DEPSITDTL_NM = "�������׃f�[�^";
        private const string TBL_PAYMENTDTL_NM = "�x�����׃f�[�^";
        private const string TBL_ACCEPTODRCAR_NM = "����f�[�^�i���q�j";
        private const string TBL_UOEORDERDTL_NM = "UOE�����f�[�^";
        private const string TBL_STOCKCHECKDTL_NM = "�d���`�F�b�N�f�[�^�i���ׁj";
        private const string TBL_RETURNUPPERST_NM = "�ԕi����ݒ�}�X�^";
        private const string TBL_CUSTDMDPRC_NM = "���Ӑ搿�����z�f�[�^";
        private const string TBL_CUSTACCREC_NM = "���Ӑ攄�|���z�f�[�^";
        private const string TBL_SUPLIERPAY_NM = "�d����x�����z�f�[�^";
        private const string TBL_SUPLACCPAY_NM = "�d���攃�|���z�}�X�^";
        private const string TBL_DMDDEPOTOTAL_NM = "���������W�v�f�[�^";
        private const string TBL_ACCRECDEPOTOTAL_NM = "���|�����W�v�f�[�^";
        private const string TBL_ACCPAYTOTAL_NM = "���Z�x���W�v�f�[�^";
        private const string TBL_ACALCPAYTOTAL_NM = "���|�x���W�v�f�[�^";
        private const string TBL_STOCKHISTORY_NM = "�݌ɗ����f�[�^";
        private const string TBL_NOMNGSET_NM = "�ԍ��Ǘ��ݒ�}�X�^";
		// ADD 2011.08.26 ���� ---------->>>>>
		private const string TBL_DCDATAINFO_NM = "���_�Ǘ�����M�f�[�^�iDC�j";
        //private const string TBL_DCMUSTINFO_NM = "���_�Ǘ�����M�}�X�^�iDC�j";//DEL by Liangsd     2011/09/06
		// ADD 2011.08.26 ���� ----------<<<<<
        // ---------------------- ADD START 2011.08.19 duzg for Redmine#23791 ----------------->>>>>
        // SCM�󒍃f�[�^
        private const string TBL_SCMACODRDATA_NM = "SCM�󒍃f�[�^";
        // SCM�󔭒��f�[�^(�ԗ����)
        private const string TBL_SCMACODRDTCAR_NM = "SCM�󔭒��f�[�^(�ԗ����)";
        // SCM�󒍖��׃f�[�^�i�⍇���E�����j
        private const string TBL_SCMACODRDTLIQ_NM = "SCM�󒍖��׃f�[�^�i�⍇���E�����j";
        // SCM�󒍖��׃f�[�^�i�񓚁j
        private const string TBL_SCMODRDATA_NM = "SCM�󒍖��׃f�[�^�i�񓚁j";
        // ---------------------- ADD END 2011.08.19 duzg for Redmine#23791 -----------------<<<<<

        private const Int32 TBL_STOCKADJUST_Code = 0;
        private const Int32 TBL_STOCKADJUSTDTL_Code = 0;
        private const Int32 TBL_STOCKMOVE_Code = 0;
        private const Int32 TBL_STOCKACPAYHIST_Code = 0;
        private const Int32 TBL_STOCKSLIP_Code = 0;
        private const Int32 TBL_STOCKDETAIL_Code = 0;
        private const Int32 TBL_SALESSLIP_Code = 0;
        private const Int32 TBL_SALESDETAIL_Code = 0;
        private const Int32 TBL_DEPSITMAIN_Code = 0;
        private const Int32 TBL_DMDCADDUPHIS_Code = 0;
        private const Int32 TBL_PAYMENTADDUPHIS_Code = 0;
        private const Int32 TBL_MONTHLYADDUPHIS_Code = 0;
        private const Int32 TBL_PAYMENTSLP_Code = 0;
        private const Int32 TBL_ACCEPTODR_Code = 0;
        private const Int32 TBL_DEPOSITALW_Code = 0;
        private const Int32 TBL_SALESHISTORY_Code = 0;
        private const Int32 TBL_SALESHISTDTL_Code = 0;
        private const Int32 TBL_STOCKSLIPHIST_Code = 0;
        private const Int32 TBL_STOCKSLHISTDTL_Code = 0;
        private const Int32 TBL_MTTLSALESSLIP_Code = 0;
        private const Int32 TBL_GOODSMTTLSASLIP_Code = 0;
        private const Int32 TBL_MTTLSTOCKSLIP_Code = 0;
        private const Int32 TBL_MTTLSALESSTOCKSLIP_Code = 0;
        private const Int32 TBL_DEPSITDTL_Code = 0;
        private const Int32 TBL_PAYMENTDTL_Code = 0;
        private const Int32 TBL_ACCEPTODRCAR_Code = 0;
        private const Int32 TBL_UOEORDERDTL_Code = 0;
        private const Int32 TBL_STOCKCHECKDTL_Code = 0;
        private const Int32 TBL_RETURNUPPERST_Code = 0;
        private const Int32 TBL_CUSTDMDPRC_Code = 1;
        private const Int32 TBL_CUSTACCREC_Code = 1;
        private const Int32 TBL_SUPLIERPAY_Code = 1;
        private const Int32 TBL_SUPLACCPAY_Code = 1;
        private const Int32 TBL_DMDDEPOTOTAL_Code = 2;
        private const Int32 TBL_ACCRECDEPOTOTAL_Code = 2;
        private const Int32 TBL_ACCPAYTOTAL_Code = 2;
        private const Int32 TBL_ACALCPAYTOTAL_Code = 2;
        private const Int32 TBL_STOCKHISTORY_Code = 3;
        private const Int32 TBL_NOMNGSET_Code = 4;
		// ADD 2011.08.26 ���� ---------->>>>>
		private const Int32 TBL_DCDATAINFO_Code = 0;
		private const Int32 TBL_DCMUSTINFO_Code = 0;
		// ADD 2011.08.26 ���� ----------<<<<<
        // ---------------------- ADD START 2011.08.19 duzg for Redmine#23791 ----------------->>>>>
        // SCM�󒍃f�[�^
        private const Int32 TBL_SCMACODRDATA_Code = 0;
        // SCM�󔭒��f�[�^(�ԗ����)
        private const Int32 TBL_SCMACODRDTCAR_Code = 0;
        // SCM�󒍖��׃f�[�^�i�⍇���E�����j
        private const Int32 TBL_SCMACODRDTLIQ_Code = 0;
        // SCM�󒍖��׃f�[�^�i�񓚁j
        private const Int32 TBL_SCMODRDATA_Code = 0;
        // ---------------------- ADD END 2011.08.19 duzg for Redmine#23791 -----------------<<<<<

        private const string TBL_CUSTDMDPRC_FileId = "ADDUPYEARMONTHRF";
        private const string TBL_CUSTACCREC_FileId = "ADDUPYEARMONTHRF";
        private const string TBL_SUPLIERPAY_FileId = "ADDUPYEARMONTHRF";
        private const string TBL_SUPLACCPAY_FileId = "ADDUPYEARMONTHRF";
        private const string TBL_DMDDEPOTOTAL_FileId = "ADDUPDATERF";
        private const string TBL_ACCRECDEPOTOTAL_FileId = "ADDUPDATERF";
        private const string TBL_ACCPAYTOTAL_FileId = "ADDUPDATERF";
        private const string TBL_ACALCPAYTOTAL_FileId = "ADDUPDATERF";

        #region �� �N���A�Ώۃf�[�^�̎擾���� ��
        /// <summary>
        /// �N���A�Ώۃf�[�^�̎擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �N���A�Ώۃf�[�^�̎擾�������s���B</br>      
        /// <br>Programmer : ���w�q</br>                                  
        /// <br>Date       : 2009.06.16</br> 
        /// </remarks>
        /// <returns>�N���A�Ώۃf�[�^���X�g</returns>
        public ArrayList GetDataClearList()
        {
            ArrayList dataClearList = new ArrayList();

            // �݌ɒ����f�[�^
            DataClearWork dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_STOCKADJUST_ID;
            dataClearWork.TableNm = TBL_STOCKADJUST_NM;
            dataClearWork.ClearCode = TBL_STOCKADJUST_Code;
            dataClearList.Add(dataClearWork);

            // �݌ɒ������׃f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_STOCKADJUSTDTL_ID;
            dataClearWork.TableNm = TBL_STOCKADJUSTDTL_NM;
            dataClearWork.ClearCode = TBL_STOCKADJUSTDTL_Code;
            dataClearList.Add(dataClearWork);

            // �݌Ɉړ��f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_STOCKMOVE_ID;
            dataClearWork.TableNm = TBL_STOCKMOVE_NM;
            dataClearWork.ClearCode = TBL_STOCKMOVE_Code;
            dataClearList.Add(dataClearWork);

            // �݌Ɏ󕥗����f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_STOCKACPAYHIST_ID;
            dataClearWork.TableNm = TBL_STOCKACPAYHIST_NM;
            dataClearWork.ClearCode = TBL_STOCKACPAYHIST_Code;
            dataClearList.Add(dataClearWork);

            // �d���f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_STOCKSLIP_ID;
            dataClearWork.TableNm = TBL_STOCKSLIP_NM;
            dataClearWork.ClearCode = TBL_STOCKSLIP_Code;
            dataClearList.Add(dataClearWork);

            // �d�����׃f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_STOCKDETAIL_ID;
            dataClearWork.TableNm = TBL_STOCKDETAIL_NM;
            dataClearWork.ClearCode = TBL_STOCKDETAIL_Code;
            dataClearList.Add(dataClearWork);

            // ����f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_SALESSLIP_ID;
            dataClearWork.TableNm = TBL_SALESSLIP_NM;
            dataClearWork.ClearCode = TBL_SALESSLIP_Code;
            dataClearList.Add(dataClearWork);

            // ���㖾�׃f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_SALESDETAIL_ID;
            dataClearWork.TableNm = TBL_SALESDETAIL_NM;
            dataClearWork.ClearCode = TBL_SALESDETAIL_Code;
            dataClearList.Add(dataClearWork);

            // �����}�X�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_DEPSITMAIN_ID;
            dataClearWork.TableNm = TBL_DEPSITMAIN_NM;
            dataClearWork.ClearCode = TBL_DEPSITMAIN_Code;
            dataClearList.Add(dataClearWork);

            // �������X�V�����}�X�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_DMDCADDUPHIS_ID;
            dataClearWork.TableNm = TBL_DMDCADDUPHIS_NM;
            dataClearWork.ClearCode = TBL_DMDCADDUPHIS_Code;
            dataClearList.Add(dataClearWork);

            // �x�����X�V�����}�X�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_PAYMENTADDUPHIS_ID;
            dataClearWork.TableNm = TBL_PAYMENTADDUPHIS_NM;
            dataClearWork.ClearCode = TBL_PAYMENTADDUPHIS_Code;
            dataClearList.Add(dataClearWork);

            // �������X�V�����f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_MONTHLYADDUPHIS_ID;
            dataClearWork.TableNm = TBL_MONTHLYADDUPHIS_NM;
            dataClearWork.ClearCode = TBL_MONTHLYADDUPHIS_Code;
            dataClearList.Add(dataClearWork);

            // �x���`�[�}�X�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_PAYMENTSLP_ID;
            dataClearWork.TableNm = TBL_PAYMENTSLP_NM;
            dataClearWork.ClearCode = TBL_PAYMENTSLP_Code;
            dataClearList.Add(dataClearWork);

            // �󒍃}�X�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_ACCEPTODR_ID;
            dataClearWork.TableNm = TBL_ACCEPTODR_NM;
            dataClearWork.ClearCode = TBL_ACCEPTODR_Code;
            dataClearList.Add(dataClearWork);

            // ���������}�X�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_DEPOSITALW_ID;
            dataClearWork.TableNm = TBL_DEPOSITALW_NM;
            dataClearWork.ClearCode = TBL_DEPOSITALW_Code;
            dataClearList.Add(dataClearWork);

            // ���㗚���f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_SALESHISTORY_ID;
            dataClearWork.TableNm = TBL_SALESHISTORY_NM;
            dataClearWork.ClearCode = TBL_SALESHISTORY_Code;
            dataClearList.Add(dataClearWork);

            // ���㗚�𖾍׃f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_SALESHISTDTL_ID;
            dataClearWork.TableNm = TBL_SALESHISTDTL_NM;
            dataClearWork.ClearCode = TBL_SALESHISTDTL_Code;
            dataClearList.Add(dataClearWork);

            // �d�������f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_STOCKSLIPHIST_ID;
            dataClearWork.TableNm = TBL_STOCKSLIPHIST_NM;
            dataClearWork.ClearCode = TBL_STOCKSLIPHIST_Code;
            dataClearList.Add(dataClearWork);

            // �d�����𖾍׃f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_STOCKSLHISTDTL_ID;
            dataClearWork.TableNm = TBL_STOCKSLHISTDTL_NM;
            dataClearWork.ClearCode = TBL_STOCKSLHISTDTL_Code;
            dataClearList.Add(dataClearWork);

            // ���㌎���W�v�f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_MTTLSALESSLIP_ID;
            dataClearWork.TableNm = TBL_MTTLSALESSLIP_NM;
            dataClearWork.ClearCode = TBL_MTTLSALESSLIP_Code;
            dataClearList.Add(dataClearWork);

            // ���i�ʔ��㌎���W�v�f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_GOODSMTTLSASLIP_ID;
            dataClearWork.TableNm = TBL_GOODSMTTLSASLIP_NM;
            dataClearWork.ClearCode = TBL_GOODSMTTLSASLIP_Code;
            dataClearList.Add(dataClearWork);

            // �d�������W�v�f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_MTTLSTOCKSLIP_ID;
            dataClearWork.TableNm = TBL_MTTLSTOCKSLIP_NM;
            dataClearWork.ClearCode = TBL_MTTLSTOCKSLIP_Code;
            dataClearList.Add(dataClearWork);

            // ����d�������W�v�f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_MTTLSALESSTOCKSLIP_ID;
            dataClearWork.TableNm = TBL_MTTLSALESSTOCKSLIP_NM;
            dataClearWork.ClearCode = TBL_MTTLSALESSTOCKSLIP_Code;
            dataClearList.Add(dataClearWork);

            // �������׃f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_DEPSITDTL_ID;
            dataClearWork.TableNm = TBL_DEPSITDTL_NM;
            dataClearWork.ClearCode = TBL_DEPSITDTL_Code;
            dataClearList.Add(dataClearWork);

            // �x�����׃f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_PAYMENTDTL_ID;
            dataClearWork.TableNm = TBL_PAYMENTDTL_NM;
            dataClearWork.ClearCode = TBL_PAYMENTDTL_Code;
            dataClearList.Add(dataClearWork);

            // ����f�[�^�i���q�j
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_ACCEPTODRCAR_ID;
            dataClearWork.TableNm = TBL_ACCEPTODRCAR_NM;
            dataClearWork.ClearCode = TBL_ACCEPTODRCAR_Code;
            dataClearList.Add(dataClearWork);

            // UOE�����f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_UOEORDERDTL_ID;
            dataClearWork.TableNm = TBL_UOEORDERDTL_NM;
            dataClearWork.ClearCode = TBL_UOEORDERDTL_Code;
            dataClearList.Add(dataClearWork);

            // �d���`�F�b�N�f�[�^�i���ׁj
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_STOCKCHECKDTL_ID;
            dataClearWork.TableNm = TBL_STOCKCHECKDTL_NM;
            dataClearWork.ClearCode = TBL_STOCKCHECKDTL_Code;
            dataClearList.Add(dataClearWork);

            // �ԕi����ݒ�}�X�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_RETURNUPPERST_ID;
            dataClearWork.TableNm = TBL_RETURNUPPERST_NM;
            dataClearWork.ClearCode = TBL_RETURNUPPERST_Code;
            dataClearList.Add(dataClearWork);

            // ���Ӑ搿�����z�f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_CUSTDMDPRC_ID;
            dataClearWork.TableNm = TBL_CUSTDMDPRC_NM;
            dataClearWork.ClearCode = TBL_CUSTDMDPRC_Code;
            dataClearWork.FileId = TBL_CUSTDMDPRC_FileId;
            dataClearList.Add(dataClearWork);

            // ���Ӑ攄�|���z�f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_CUSTACCREC_ID;
            dataClearWork.TableNm = TBL_CUSTACCREC_NM;
            dataClearWork.ClearCode = TBL_CUSTACCREC_Code;
            dataClearWork.FileId = TBL_CUSTACCREC_FileId;
            dataClearList.Add(dataClearWork);

            // �d����x�����z�f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_SUPLIERPAY_ID;
            dataClearWork.TableNm = TBL_SUPLIERPAY_NM;
            dataClearWork.ClearCode = TBL_SUPLIERPAY_Code;
            dataClearWork.FileId = TBL_SUPLIERPAY_FileId;
            dataClearList.Add(dataClearWork);

            // �d���攃�|���z�}�X�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_SUPLACCPAY_ID;
            dataClearWork.TableNm = TBL_SUPLACCPAY_NM;
            dataClearWork.ClearCode = TBL_SUPLACCPAY_Code;
            dataClearWork.FileId = TBL_SUPLACCPAY_FileId;
            dataClearList.Add(dataClearWork);

            // ���������W�v�f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_DMDDEPOTOTAL_ID;
            dataClearWork.TableNm = TBL_DMDDEPOTOTAL_NM;
            dataClearWork.ClearCode = TBL_DMDDEPOTOTAL_Code;
            dataClearWork.FileId = TBL_DMDDEPOTOTAL_FileId;
            dataClearList.Add(dataClearWork);

            // ���|�����W�v�f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_ACCRECDEPOTOTAL_ID;
            dataClearWork.TableNm = TBL_ACCRECDEPOTOTAL_NM;
            dataClearWork.ClearCode = TBL_ACCRECDEPOTOTAL_Code;
            dataClearWork.FileId = TBL_ACCRECDEPOTOTAL_FileId;
            dataClearList.Add(dataClearWork);

            // ���Z�x���W�v�f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_ACCPAYTOTAL_ID;
            dataClearWork.TableNm = TBL_ACCPAYTOTAL_NM;
            dataClearWork.ClearCode = TBL_ACCPAYTOTAL_Code;
            dataClearWork.FileId = TBL_ACCPAYTOTAL_FileId;
            dataClearList.Add(dataClearWork);

            // ���|�x���W�v�f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_ACALCPAYTOTAL_ID;
            dataClearWork.TableNm = TBL_ACALCPAYTOTAL_NM;
            dataClearWork.ClearCode = TBL_ACALCPAYTOTAL_Code;
            dataClearWork.FileId = TBL_ACALCPAYTOTAL_FileId;
            dataClearList.Add(dataClearWork);

            // �݌ɗ����f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_STOCKHISTORY_ID;
            dataClearWork.TableNm = TBL_STOCKHISTORY_NM;
            dataClearWork.ClearCode = TBL_STOCKHISTORY_Code;
            dataClearList.Add(dataClearWork);

            // �ԍ��Ǘ��ݒ�}�X�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_NOMNGSET_ID;
            dataClearWork.TableNm = TBL_NOMNGSET_NM;
            dataClearWork.ClearCode = TBL_NOMNGSET_Code;
            dataClearList.Add(dataClearWork);

            // ---------------------- ADD START 2011.08.19 duzg for Redmine#23791 ----------------->>>>>
            // SCM�󒍃f�[�^
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_SCMACODRDATA_ID;
            dataClearWork.TableNm = TBL_SCMACODRDATA_NM;
            dataClearWork.ClearCode = TBL_SCMACODRDATA_Code;
            dataClearList.Add(dataClearWork);

            // SCM�󔭒��f�[�^(�ԗ����)
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_SCMACODRDTCAR_ID;
            dataClearWork.TableNm = TBL_SCMACODRDTCAR_NM;
            dataClearWork.ClearCode = TBL_SCMACODRDTCAR_Code;
            dataClearList.Add(dataClearWork);

            // SCM�󒍖��׃f�[�^�i�⍇���E�����j
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_SCMACODRDTLIQ_ID;
            dataClearWork.TableNm = TBL_SCMACODRDTLIQ_NM;
            dataClearWork.ClearCode = TBL_SCMACODRDTLIQ_Code;
            dataClearList.Add(dataClearWork);

            // CM�󒍖��׃f�[�^�i�񓚁j
            dataClearWork = new DataClearWork();
            dataClearWork.TableId = TBL_SCMODRDATA_ID;
            dataClearWork.TableNm = TBL_SCMODRDATA_NM;
            dataClearWork.ClearCode = TBL_SCMODRDATA_Code;
            dataClearList.Add(dataClearWork);
            // ---------------------- ADD END   2011.08.19 duzg for Redmine#23791 -----------------<<<<<
			// ADD 2011.08.26 ���� ---------->>>>>
			// ���_�I�v�V�����L���`�F�b�N
			PurchaseStatus ps;
			ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION);

			if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
			{
				//���_�Ǘ�����M�f�[�^�iDC�j
				dataClearWork = new DataClearWork();
				dataClearWork.TableId = TBL_DCDATAINFO_ID;
				dataClearWork.TableNm = TBL_DCDATAINFO_NM;
				dataClearWork.ClearCode = TBL_DCDATAINFO_Code;
				dataClearList.Add(dataClearWork);

                //DEL by Liangsd   2011/09/06----------------->>>>>>>>>>
                ////���_�Ǘ�����M�}�X�^�iDC�j
                //dataClearWork = new DataClearWork();
                //dataClearWork.TableId = TBL_DCMUSTINFO_ID;
                //dataClearWork.TableNm = TBL_DCMUSTINFO_NM;
                //dataClearWork.ClearCode = TBL_DCMUSTINFO_Code;
                //dataClearList.Add(dataClearWork);
                //DEL by Liangsd   2011/09/06-----------------<<<<<<<<<<
			}            
		    // ADD 2011.08.26 ���� ----------<<<<<

            return dataClearList;
        }
        #endregion
    }
}
