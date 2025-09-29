using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �o�׏��i�D�ǑΉ��\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : �o�׏��i�D�ǑΉ��\�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer   : 30452 ��� �r��</br>
    /// <br>Date         : 2008.11.14</br>
    /// <br>Update Note  : 2008.12.12 30452 ��� �r��</br>
    /// <br>              �E2�߂̗D�Ǖi���̑e�����v�Z���̃f�[�^�擾�����C���B</br>
    /// <br>Update Note  : 2008.12.16 30452 ��� �r��</br>
    /// <br>              �E���i�}�X�^�������ʂ̃`�F�b�N���A��ƃR�[�h�̏������폜�B</br>
    /// <br>Update Note  : 2008.12.17 30452 ��� �r��</br>
    /// <br>              �E���i�}�X�^�����������C���B</br>
    /// <br>Update Note  : 2009.01.13 30452 ��� �r��</br>
    /// <br>              �E��Q�Ή�9687�i�D�Ǖi��񌟍����A���i�A���f�[�^�s�����ݒ菈����ǉ��j</br>
    /// <br>Update Note  : 2009.01.13 30452 ��� �r��</br>
    /// <br>              �E��Q�Ή�9544�i�����[�g��苒�_���X�g�ɂȂ����_�R�[�h���Ԃ�ꍇ�A</br>
    /// <br>              �@����ΏۂƂ���悤�C���B�擾�o���Ȃ����ڂ͋󔒂ɂ���B�j</br>
    /// <br>Update Note  : 2009.01.15 30452 ��� �r��</br>
    /// <br>              �E��Q�Ή�10088�i���v�Z�Ńv���X�ɂȂ�悤�␳���Ă����������폜�j</br>
    /// <br>Update Note  : 2009.01.15 30452 ��� �r��</br>
    /// <br>              �E��Q�Ή�10098�i�݌Ƀ��X�gindex�擾���A���_�R�[�h�̏������폜�j</br>
    /// <br>Update Note  : 2009.02.13 30452 ��� �r��</br>
    /// <br>              �E��Q�Ή�11281�i���i�}�X�^�ɑ��݂��Ȃ��ꍇ���󎚑ΏۂƂ���悤�C���j</br>
    /// <br>Update Note  : 2009.02.16 30452 ��� �r��</br>
    /// <br>              �E��Q�Ή�11530�i���x�A�b�v�Ή��j</br>
    /// <br>Update Note  : 2009.02.18 30452 ��� �r��</br>
    /// <br>              �E��Q�Ή�11281�i�����i���̕s�����擾�����ǉ��j</br>
    /// <br>Update Note  : 2009/02/21 30452 ��� �r��</br>
    /// <br>              �E��Q�Ή�11281�i�O���[�v�R�[�h�̓����[�g���o���ʂ��擾����悤�C���j</br>
    /// <br>Update Note  : 2012/04/09 ������</br>
    /// <br>              �E2012/05/24�z�M�� Redmine#29336 �o�׏��i�D�ǑΉ��\ ������ɃG���[���\������� ��Q�Ή��̏C��</br>
    /// <br>Update Note  : 2014/12/16 ����</br>
    /// <br>�Ǘ��ԍ�     : 11070263-00</br>
    /// <br>             :�E�����Y�ƗlSeiken�i�ԕύX</br>
    /// <br>Update Note  : 2015/03/05 ����</br>
    /// <br>�Ǘ��ԍ�     : 11070263-00</br>
    /// <br>             :�E�����Y�ƗlSeiken�i�ԕύX �V�X�e����Q�̑Ή�(�i�ԕ\��)</br>
    /// <br>Update Note  : 2015/04/07 ���R</br>
    /// <br>�Ǘ��ԍ�     : 11070263-00</br>
    /// <br>             :�E�����Y�ƗlSeiken�i�ԕύX �V�X�e����Q��57���i�\���s���̑Ή�</br>
    /// <br>Update Note  : 2015/04/13 ���V��</br>
    /// <br>�Ǘ��ԍ�     : 11070263-00</br>
    /// <br>             : Redmine#45436NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�</br>
    /// </remarks>
    public class ShipGdsPrimeListAsc
    {
        #region �� �R���X�g���N�^
		/// <summary>
        /// �o�׏��i�D�ǑΉ��\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �o�׏��i�D�ǑΉ��\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.14</br>
		/// </remarks>
		public ShipGdsPrimeListAsc()
		{
            this._iShipGdsPrimeListResultWorkDB = (IShipGdsPrimeListResultWorkDB)MediationShipGdsPrimeListResultWorkDB.GetShipGdsPrimeListResultWorkDB();

            string enterpriseCode = LoginInfoAcquisition.EnterpriseCode.TrimEnd(); // ADD 2009/02/16
            string loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd(); // ADD 2009/02/16
            string msg;

            this._goodsAcs = new GoodsAcs(); // ���i�}�X�^
            this._goodsAcs.SearchInitial(enterpriseCode, loginSectionCode, out msg); // ADD 2009/02/16
            //this._joinPartsUAcs = new JoinPartsUAcs(); // �����}�X�^
		}

		/// <summary>
        /// �o�׏��i�D�ǑΉ��\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �o�׏��i�D�ǑΉ��\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.14</br>
		/// </remarks>
        static ShipGdsPrimeListAsc()
		{
            stc_Employee		= null;
			stc_PrtOutSet		= null;					// ���[�o�͐ݒ�f�[�^�N���X
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// ���[�o�͐ݒ�A�N�Z�X�N���X

            stc_SecInfoAcs      = new SecInfoAcs(1);    // ���_�A�N�Z�X�N���X
            stc_SectionDic      = new Dictionary<string,SecInfoSet>();  // ���_Dictionary

            // ���O�C�����_�擾
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }

            // ���_Dictionary����
            SecInfoSet[] secInfoSetList = stc_SecInfoAcs.SecInfoSetList;

            foreach ( SecInfoSet secInfoSet in secInfoSetList )
            {
                // �����łȂ����
                if ( !stc_SectionDic.ContainsKey( secInfoSet.SectionCode ) )
                {
                    // �ǉ�
                    stc_SectionDic.Add( secInfoSet.SectionCode, secInfoSet );
                }
            }
        }
		#endregion

        #region �� Static�ϐ�
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			// ���[�o�͐ݒ�f�[�^�N���X
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// ���[�o�͐ݒ�A�N�Z�X�N���X

        private static SecInfoAcs stc_SecInfoAcs;               // ���_�A�N�Z�X�N���X
        private static Dictionary<string, SecInfoSet> stc_SectionDic;   // ���_Dictionary
        #endregion

        #region �� Private�ϐ�
        IShipGdsPrimeListResultWorkDB _iShipGdsPrimeListResultWorkDB;

        private DataTable _shipGdsPrimeListDt; // �����[�g���o���ʕێ�DataTable
        private DataTable _printDt; // ���DataTable
        private DataView _printDv;	// ���DataView

        private GoodsAcs _goodsAcs; // ���i�}�X�^
        #endregion

        #region �� Public�v���p�e�B
        /// <summary>
        /// ����f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataView ShipGdsPrimeListDataView
        {
            get { return this._printDv; }
        }
        #endregion

        #region �� Public���\�b�h
        /// <summary>
        /// �f�[�^�擾
        /// </summary>
        /// <param name="salesRsltListCndtn">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������f�[�^���擾����B</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.14</br>
        /// </remarks>
        public int SearchMain(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn, out string errMsg)
        {
            return this.SearchProc(shipGdsPrimeListCndtn, out errMsg);
        }

        /// <summary>
        /// ���[�o�͐ݒ�Ǎ�
        /// </summary>
        /// <param name="retPrtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";

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
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

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

        #region �� Private���\�b�h

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        private int SearchProc(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            // �����i���擾(�����[�g�����A���i�}�X�^����)
            status = this.SearchPureGoodsProc(shipGdsPrimeListCndtn, ref errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            // �D�Ǖi���擾(�����[�g�����A���i�}�X�^����)
            this.GetPartsInfo(shipGdsPrimeListCndtn);

            // --- ADD 2009/01/08 -------------------------------->>>>>
            // ����(������z�A�e���z�A�݌ɐ��ʁA��񐔗ʁA���i)�̂Ȃ��i�Ԃ�����
            this.RemoveNoResultGoodsRow();

            if (this._shipGdsPrimeListDt.Rows.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }
            // --- ADD 2009/01/08 --------------------------------<<<<<

            // ���ʕt�ݒ� (�����敪�����f)
            this.SetOrder(shipGdsPrimeListCndtn, ref errMsg);
            
            if (this._shipGdsPrimeListDt.Rows.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // �t�B���^�A�\�[�g���� (���ʃt�B���^�A������\�[�g)
            this.FilterAndSort(shipGdsPrimeListCndtn);

            // ���[�󎚗p�e�[�u���쐬
            this.MakePrintTable(shipGdsPrimeListCndtn);

            // DataView�쐬
            this._printDv = new DataView(this._printDt, "", "", DataViewRowState.CurrentRows);

            return status;
        }

        /// <summary>
        /// �f�[�^�擾
        /// </summary>
        /// <param name="salesRsltListCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������f�[�^���擾����B</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.14</br>
        /// </remarks>
        private int SearchPureGoodsProc(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn, ref string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMHNB02145EA.CreateDataTable(ref this._shipGdsPrimeListDt);

                ShipGdsPrimeListCndtnWork shipGdsPrimeListCndtnWork = new ShipGdsPrimeListCndtnWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.DevListCndtn(shipGdsPrimeListCndtn, out shipGdsPrimeListCndtnWork, ref errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retWorkList = null;

                // �����[�g����(�����i)
                status = this._iShipGdsPrimeListResultWorkDB.Search(out retWorkList, shipGdsPrimeListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                // �e�X�g�p
                //status = this.testProcPure(out retWorkList);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DevListData(shipGdsPrimeListCndtn, (ArrayList)retWorkList, ref errMsg);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "�o�׏��i�D�ǑΉ��\�f�[�^�̎擾�Ɏ��s���܂����B";
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="salesRsltListCndtn">UI���o�����N���X</param>
        /// <param name="salesRsltListCndtnWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       �@: ��ʒ��o�����������[�g���o�����֓W�J����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.14</br>
        /// <br>Update Note  : 2014/12/16 ����</br>
        /// <br>�Ǘ��ԍ�     : 11070263-00</br>
        /// <br>             :�E�����Y�ƗlSeiken�i�ԕύX</br>
        /// </remarks>
        private int DevListCndtn(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn, out ShipGdsPrimeListCndtnWork shipGdsPrimeListCndtnWork, ref string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            shipGdsPrimeListCndtnWork = new ShipGdsPrimeListCndtnWork();
            try
            {
                shipGdsPrimeListCndtnWork.EnterpriseCode = shipGdsPrimeListCndtn.EnterpriseCode;  // ��ƃR�[�h

                // ���o�����p�����[�^�Z�b�g
                if (shipGdsPrimeListCndtn.SectionCodes.Length != 0)
                {
                    if (shipGdsPrimeListCndtn.IsSelectAllSection)
                    {
                        // �S�Ђ̎�
                        shipGdsPrimeListCndtnWork.SectionCodes = null;
                    }
                    else
                    {
                        shipGdsPrimeListCndtnWork.SectionCodes = shipGdsPrimeListCndtn.SectionCodes;
                    }
                }
                else
                {
                    shipGdsPrimeListCndtnWork.SectionCodes = null;
                }

                if (shipGdsPrimeListCndtn.PrintType == ShipGdsPrimeListCndtn.PrintTypeState.Month)
                {
                    shipGdsPrimeListCndtnWork.St_AddUpYearMonth = shipGdsPrimeListCndtn.St_AddUpYearMonth; // �J�n�Ώ۔N��
                    shipGdsPrimeListCndtnWork.Ed_AddUpYearMonth = shipGdsPrimeListCndtn.Ed_AddUpYearMonth; // �I���Ώ۔N��
                }
                else
                {
                    shipGdsPrimeListCndtnWork.St_AddUpYearMonth = shipGdsPrimeListCndtn.St_AnnualAddUpYearMonth; // �J�n�Ώ۔N��
                    shipGdsPrimeListCndtnWork.Ed_AddUpYearMonth = shipGdsPrimeListCndtn.Ed_AnnualAddUpYearMonth; // �I���Ώ۔N��
                }
                
                //------ ADD START 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------>>>>>
                shipGdsPrimeListCndtnWork.GoodsNoTtlDiv = (int)shipGdsPrimeListCndtn.GoodsNoTtlDiv; // �i�ԏW�v�敪
                if (shipGdsPrimeListCndtnWork.GoodsNoTtlDiv == 1)
                {
                    shipGdsPrimeListCndtnWork.GoodsNoShowDiv = (int)shipGdsPrimeListCndtn.GoodsNoShowDiv; // �i�ԕ\���敪
                }
                //------ ADD END 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------<<<<<
                
                shipGdsPrimeListCndtnWork.St_GoodsMakerCd = shipGdsPrimeListCndtn.St_GoodsMakerCd; // �J�n���[�J�[�R�[�h
                if (shipGdsPrimeListCndtn.Ed_GoodsMakerCd == 0) shipGdsPrimeListCndtnWork.Ed_GoodsMakerCd = 99;
                else shipGdsPrimeListCndtnWork.Ed_GoodsMakerCd = shipGdsPrimeListCndtn.Ed_GoodsMakerCd; // �I�����[�J�[�R�[�h
                
                shipGdsPrimeListCndtnWork.St_GoodsLGroup = shipGdsPrimeListCndtn.St_GoodsLGroup; // �J�n���i�啪�ރR�[�h
                if (shipGdsPrimeListCndtn.Ed_GoodsLGroup == 0) shipGdsPrimeListCndtnWork.Ed_GoodsLGroup = 9999;
                else shipGdsPrimeListCndtnWork.Ed_GoodsLGroup = shipGdsPrimeListCndtn.Ed_GoodsLGroup; // �I�����i�啪�ރR�[�h

                shipGdsPrimeListCndtnWork.St_GoodsMGroup = shipGdsPrimeListCndtn.St_GoodsMGroup; // �J�n���i�����ރR�[�h
                if (shipGdsPrimeListCndtn.Ed_GoodsMGroup == 0) shipGdsPrimeListCndtnWork.Ed_GoodsMGroup = 9999;
                else shipGdsPrimeListCndtnWork.Ed_GoodsMGroup = shipGdsPrimeListCndtn.Ed_GoodsMGroup; // �I�����i�����ރR�[�h
                
                shipGdsPrimeListCndtnWork.St_BLGroupCode = shipGdsPrimeListCndtn.St_BLGroupCode; // �J�n�O���[�v�R�[�h
                if (shipGdsPrimeListCndtn.Ed_BLGroupCode == 0) shipGdsPrimeListCndtnWork.Ed_BLGroupCode = 99999;
                else shipGdsPrimeListCndtnWork.Ed_BLGroupCode = shipGdsPrimeListCndtn.Ed_BLGroupCode; // �I���O���[�v�R�[�h

                shipGdsPrimeListCndtnWork.St_BLGoodsCode = shipGdsPrimeListCndtn.St_BLGoodsCode; // �J�n�a�k�R�[�h
                if (shipGdsPrimeListCndtn.Ed_BLGoodsCode == 0) shipGdsPrimeListCndtnWork.Ed_BLGoodsCode = 99999;
                else shipGdsPrimeListCndtnWork.Ed_BLGoodsCode = shipGdsPrimeListCndtn.Ed_BLGoodsCode; // �I���a�k�R�[�h

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// �擾�f�[�^�W�J����
        /// </summary>
        /// <param name="salesRsltListCndtn">UI���o�����N���X</param>
        /// <param name="resultWork">�擾�f�[�^</param>
        /// <remarks>
        /// <br>Note       �@: �����[�g���o���ʂ𒠕[�󎚗pDataTable�֓W�J����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.14</br>
        /// </remarks>
        private void DevListData(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn, ArrayList resultWork, ref string errMsg)
        {
            // �����[�g���o���ʂ������[�g���o���ʗpDataTable(PMHNB02145EA)�ɓW�J
            DataRow dr;

            foreach (ShipGdsPrimeListResultWork shipGdsPrimeListResultWork in resultWork)
            {
                dr = this._shipGdsPrimeListDt.NewRow();

                dr[PMHNB02145EA.ct_Col_EnterpriseCode] = shipGdsPrimeListResultWork.EnterpriseCode; // ��ƃR�[�h
                dr[PMHNB02145EA.ct_Col_AddUpSecCode] = shipGdsPrimeListResultWork.AddUpSecCode; // �v�㋒�_�R�[�h
                dr[PMHNB02145EA.ct_Col_SectionGuideSnm] = shipGdsPrimeListResultWork.SectionGuideSnm; // ���_�K�C�h����
                dr[PMHNB02145EA.ct_Col_GoodsMakerCd] = shipGdsPrimeListResultWork.GoodsMakerCd; // ���[�J�[�R�[�h
                dr[PMHNB02145EA.ct_Col_GoodsNo] = shipGdsPrimeListResultWork.GoodsNo; // ���i�ԍ�
                dr[PMHNB02145EA.ct_Col_St_SalesTimes] = shipGdsPrimeListResultWork.St_SalesTimes; // �����(�݌�)
                dr[PMHNB02145EA.ct_Col_St_TotalSalesCount] = shipGdsPrimeListResultWork.St_TotalSalesCount; // ���㐔�v(�݌�)
                dr[PMHNB02145EA.ct_Col_St_SalesMoney] = shipGdsPrimeListResultWork.St_SalesMoney; // ������z(�݌�)
                dr[PMHNB02145EA.ct_Col_St_SalesRetGoodsPrice] = shipGdsPrimeListResultWork.St_SalesRetGoodsPrice; // �ԕi�z(�݌�)
                dr[PMHNB02145EA.ct_Col_St_DiscountPrice] = shipGdsPrimeListResultWork.St_DiscountPrice; // �l�����z(�݌�)
                dr[PMHNB02145EA.ct_Col_St_GrossProfit] = shipGdsPrimeListResultWork.St_GrossProfit; // �e�����z(�݌�)
                dr[PMHNB02145EA.ct_Col_Or_SalesTimes] = shipGdsPrimeListResultWork.Or_SalesTimes; // �����(���)
                dr[PMHNB02145EA.ct_Col_Or_TotalSalesCount] = shipGdsPrimeListResultWork.Or_TotalSalesCount; // ���㐔�v(���)
                dr[PMHNB02145EA.ct_Col_Or_SalesMoney] = shipGdsPrimeListResultWork.Or_SalesMoney; // ������z(���)
                dr[PMHNB02145EA.ct_Col_Or_SalesRetGoodsPrice] = shipGdsPrimeListResultWork.Or_SalesRetGoodsPrice; // �ԕi�z(���)
                dr[PMHNB02145EA.ct_Col_Or_DiscountPrice] = shipGdsPrimeListResultWork.Or_DiscountPrice; // �l�����z(���)
                dr[PMHNB02145EA.ct_Col_Or_GrossProfit] = shipGdsPrimeListResultWork.Or_GrossProfit; // �e�����z(���)
                dr[PMHNB02145EA.ct_Col_BLGroupCode] = shipGdsPrimeListResultWork.BLGroupCode; // BL�O���[�v�R�[�h // ADD 2009/02/13

                dr[PMHNB02145EA.ct_Col_Sum_TotalSalesCount] = shipGdsPrimeListResultWork.St_TotalSalesCount 
                                                                + shipGdsPrimeListResultWork.Or_TotalSalesCount; // ���㐔�v(�݌�+���)

                // --- DEL 2009/02/16 -------------------------------->>>>>
                //List<GoodsUnitData> goodsUnitDataList;

                //// ���i���擾
                //int status =this.GetGoodsUnitDataList(shipGdsPrimeListResultWork, out goodsUnitDataList, out errMsg);

                //// --- DEL 2009/02/13 -------------------------------->>>>>
                ////if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                ////    || goodsUnitDataList.Count == 0)
                ////{
                ////    // 0���̏ꍇ�A�󎚑Ώۂɂ��Ȃ�
                ////    continue;
                ////}
                //// --- DEL 2009/02/13 -------------------------------->>>>>

                //if (goodsUnitDataList.Count != 0) // ADD 2009/02/13
                //{

                //    GoodsUnitData goodsUnitData = goodsUnitDataList[0];
                //    dr[PMHNB02145EA.ct_Col_GoodsMakerName] = goodsUnitData.MakerShortName; // ���[�J�[����
                //    dr[PMHNB02145EA.ct_Col_GoodsMGroup] = goodsUnitData.GoodsMGroup; // ���i�����ރR�[�h
                //    dr[PMHNB02145EA.ct_Col_GoodsMGroupName] = goodsUnitData.GoodsMGroupName; // ���i�����ޖ���
                //    dr[PMHNB02145EA.ct_Col_BLGroupCode] = goodsUnitData.BLGroupCode; // BL�O���[�v�R�[�h
                //    dr[PMHNB02145EA.ct_Col_BLGroupCodeName] = goodsUnitData.BLGroupName; // BL�O���[�v�R�[�h����
                //    dr[PMHNB02145EA.ct_Col_SuplierCode] = goodsUnitData.SupplierCd; // �d����R�[�h(�����i�ł͎g�p���Ȃ�)
                //    dr[PMHNB02145EA.ct_Col_GoodsName] = goodsUnitData.GoodsNameKana; // �i��

                //    // �݌Ƀ��X�g��Index����
                //    int index = GetStockListIndex(shipGdsPrimeListResultWork, goodsUnitData);

                //    if (index != -1)
                //    {
                //        dr[PMHNB02145EA.ct_Col_WarehouseShelfNo] = goodsUnitData.StockList[index].WarehouseShelfNo; // �I��
                //        dr[PMHNB02145EA.ct_Col_SupplierStock] = goodsUnitData.StockList[index].SupplierStock; // ���݌Ɂi�d���݌ɐ��j
                //    }
                //    else
                //    {
                //        // �݌Ƀ��X�g��0���̏ꍇ�A�\���͍s���B�i�I�Ԃƌ��݌ɂ̓J���j
                //    }

                //    // ���i���̃C���f�b�N�X���擾
                //    index = GetGoodsPriceListIndex(goodsUnitData.GoodsPriceList);

                //    if (index != -1)
                //    {
                //        dr[PMHNB02145EA.ct_Col_ListPrice] = goodsUnitData.GoodsPriceList[index].ListPrice; // ���i
                //    }
                //    else
                //    {
                //        // ���i���X�g��0���̏ꍇ�A�\���͍s���B�i���i�̓J���j
                //    }
                //}
                // --- DEL 2009/02/16 -------------------------------->>>>>

                this._shipGdsPrimeListDt.Rows.Add(dr);
            }
        }

        // --- DEL 2009/02/16 -------------------------------->>>>>
        ///// <summary>
        ///// ���i���擾����
        ///// </summary>
        ///// <param name="shipGdsPrimeListResultWork"></param>
        ///// <param name="goodsUnitDataList"></param>
        ///// <param name="errMsg"></param>
        ///// <returns></returns>
        //private int GetGoodsUnitDataList(ShipGdsPrimeListResultWork shipGdsPrimeListResultWork, out List<GoodsUnitData> goodsUnitDataList, out string errMsg)
        //{
        //    GoodsCndtn goodsCndtn = new GoodsCndtn();

        //    goodsCndtn.EnterpriseCode = shipGdsPrimeListResultWork.EnterpriseCode;
        //    goodsCndtn.GoodsNo = shipGdsPrimeListResultWork.GoodsNo;
        //    goodsCndtn.GoodsMakerCd = shipGdsPrimeListResultWork.GoodsMakerCd;

        //    int status = _goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtn, false, out goodsUnitDataList, out errMsg);

        //    return status;
        //}
        // --- DEL 2009/02/16 --------------------------------<<<<<

        /// <summary>
        /// �����ɍ��v����݌Ƀ��X�g��index���擾����
        /// </summary>
        /// <returns></returns>
        private int GetStockListIndex(string enterpriseCode, string sectionCode , GoodsUnitData goodsUnitData)
        {
            // --- ADD 2009/01/13 -------------------------------->>>>>
            // ���_�}�X�^�ɍ��v���鋒�_�R�[�h�������ꍇ�A�Y���Ȃ�(-1)��Ԃ�
            if (!stc_SectionDic.ContainsKey(sectionCode))
            {
                return -1;
            }
            // --- ADD 2009/01/13 --------------------------------<<<<<

            // ���_�}�X�^�f�[�^�̎擾
            SecInfoSet secInfoSet = stc_SectionDic[sectionCode];

            // ���_�q�ɃR�[�h(�D�揇)
            string SectWarehouseCd1 = secInfoSet.SectWarehouseCd1;
            string SectWarehouseCd2 = secInfoSet.SectWarehouseCd2;
            string SectWarehouseCd3 = secInfoSet.SectWarehouseCd3;

            int index;

            // �݌Ƀ��X�g�̃C���f�b�N�X���擾
            index = this.CheckStockList(enterpriseCode, sectionCode ,goodsUnitData, goodsUnitData.StockList, SectWarehouseCd1);

            if (index == -1)
            {
                index = this.CheckStockList(enterpriseCode, sectionCode ,goodsUnitData, goodsUnitData.StockList, SectWarehouseCd2);

                if (index == -1)
                {
                    index = this.CheckStockList(enterpriseCode, sectionCode ,goodsUnitData, goodsUnitData.StockList, SectWarehouseCd3);

                }
            }

            return index;
        }

        /// <summary>
        /// �����ɍ��v����݌Ƀ��X�g��index���擾����
        /// </summary>
        /// <returns></returns>
        private int GetStockListIndex(ShipGdsPrimeListResultWork shipGdsPrimeListResultWork, GoodsUnitData goodsUnitData)
        {
            // --- ADD 2009/01/13 -------------------------------->>>>>
            // ���_�}�X�^�ɍ��v���鋒�_�R�[�h�������ꍇ�A�Y���Ȃ�(-1)��Ԃ�
            if (!stc_SectionDic.ContainsKey(shipGdsPrimeListResultWork.AddUpSecCode))
            {
                return -1;
            }
            // --- ADD 2009/01/13 --------------------------------<<<<<

            // ���_�}�X�^�f�[�^�̎擾
            SecInfoSet secInfoSet = stc_SectionDic[shipGdsPrimeListResultWork.AddUpSecCode];

            // ���_�q�ɃR�[�h(�D�揇)
            string SectWarehouseCd1 = secInfoSet.SectWarehouseCd1;
            string SectWarehouseCd2 = secInfoSet.SectWarehouseCd2;
            string SectWarehouseCd3 = secInfoSet.SectWarehouseCd3;

            int index;

            // �݌Ƀ��X�g�̃C���f�b�N�X���擾
            index = this.CheckStockList(shipGdsPrimeListResultWork, goodsUnitData.StockList, SectWarehouseCd1);

            if (index == -1)
            {
                index = this.CheckStockList(shipGdsPrimeListResultWork, goodsUnitData.StockList, SectWarehouseCd2);

                if (index == -1)
                {
                    index = this.CheckStockList(shipGdsPrimeListResultWork, goodsUnitData.StockList, SectWarehouseCd3);

                }
            }

            return index;
        }

        /// <summary>
        /// �q�ɋ��_�R�[�h�ɍ��v����Stock���X�gIndex����������
        /// </summary>
        /// <param name="shipGdsPrimeListResultWork"></param>
        /// <param name="stockList"></param>
        /// <param name="SectWarehouseCd"></param>
        /// <returns></returns>
        private int CheckStockList(string enterpriseCode, string sectionCode, GoodsUnitData goodsUnitData, List<Stock> stockList, string SectWarehouseCd)
        {
            Stock stock;
            int index = -1;

            for (int i = 0; i < stockList.Count; i++)
            {
                stock = stockList[i];

                if (stock.EnterpriseCode.Trim() == enterpriseCode.Trim()
                    //&& stock.SectionCode.Trim() == sectionCode.Trim() // DEL 2009/01/15
                        && stock.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                        && stock.GoodsNo.Trim() == goodsUnitData.GoodsNo.Trim()
                        && stock.WarehouseCode.Trim() == SectWarehouseCd.Trim())
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        /// <summary>
        /// �q�ɋ��_�R�[�h�ɍ��v����Stock���X�gIndex����������
        /// </summary>
        /// <param name="shipGdsPrimeListResultWork"></param>
        /// <param name="stockList"></param>
        /// <param name="SectWarehouseCd"></param>
        /// <returns></returns>
        private int CheckStockList(ShipGdsPrimeListResultWork shipGdsPrimeListResultWork, List<Stock> stockList, string SectWarehouseCd)
        {
            Stock stock;
            int index = -1;

            for (int i = 0; i < stockList.Count; i++)
            {
                stock = stockList[i];

                if (stock.EnterpriseCode.Trim() == shipGdsPrimeListResultWork.EnterpriseCode.Trim()
                    //&& stock.SectionCode.Trim() == shipGdsPrimeListResultWork.AddUpSecCode.Trim() // DEL 2009/01/15
                        && stock.GoodsMakerCd == shipGdsPrimeListResultWork.GoodsMakerCd
                        && stock.GoodsNo.Trim() == shipGdsPrimeListResultWork.GoodsNo.Trim()
                        && stock.WarehouseCode.Trim() == SectWarehouseCd.Trim())
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        /// <summary>
        /// �V�X�e�����t�ɍ��v���鉿�i���X�g��index���擾����
        /// </summary>
        /// <br>Update Note  : 2015/04/07 ���R</br>
        /// <br>�Ǘ��ԍ�     : 11070263-00</br>
        /// <br>             : �����Y�ƗlSeiken�i�ԕύX �V�X�e����Q��57���i�\���s���̑Ή�</br>
        /// <returns></returns>
        private int GetGoodsPriceListIndex(List<GoodsPrice> goodsPriceList)
        {
            // ���i���̎擾
            List<DateTime> priceStartDateList = new List<DateTime>();
            

            // �J�n�����X�g�̍쐬
            foreach (GoodsPrice goodsPrice in goodsPriceList)
            {
                priceStartDateList.Add(goodsPrice.PriceStartDate);
            }

            // ���t���Ƀ\�[�g
            priceStartDateList.Sort();

            int index = -1;
            if (priceStartDateList.Count == 0)
            {
            }
            else if (priceStartDateList.Count == 1)
            {
                if (priceStartDateList[0] <= DateTime.Now)
                {
                    index = 0;
                }
            }
            else
            {
                for (int i = 1; i < priceStartDateList.Count; i++)
                {
                    if (priceStartDateList[i - 1] <= DateTime.Now
                        && priceStartDateList[i] >= DateTime.Now)
                    {
                        //index = i;     // DEL 2015/04/07 ���R �����Y�ƗlSeiken�i�ԕύX �V�X�e����Q��57���i�\���s���̑Ή�
                        index = i - 1;   // ADD 2015/04/07 ���R �����Y�ƗlSeiken�i�ԕύX �V�X�e����Q��57���i�\���s���̑Ή�
                        break;
                    }
                }

                // �ő�̓��t�����ݓ������O
                if (priceStartDateList[priceStartDateList.Count - 1] <= DateTime.Now)
                {
                    index = priceStartDateList.Count - 1;
                }

                // --- ADD 2015/04/07 ���R �����Y�ƗlSeiken�i�ԕύX �V�X�e����Q��57���i�\���s���̑Ή�-->>>>>
                if (index >= 0)
                {
                    GoodsPrice goodsPrice = new GoodsPrice();
                    DateTime priceStartDate = priceStartDateList[index];
                    for (int newIndex = 0; newIndex < goodsPriceList.Count; newIndex++)
                    {
                        goodsPrice = goodsPriceList[newIndex];
                        if (priceStartDate.Equals(goodsPrice.PriceStartDate))
                        {
                            index = newIndex;
                            break;
                        }
                    }
                }
                // --- ADD 2015/04/07 ���R �����Y�ƗlSeiken�i�ԕύX �V�X�e����Q��57���i�\���s���̑Ή�--<<<<<
            }

            return index;
        }

        /// <summary>
        /// �D�Ǖi���擾����
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <remarks>
        /// <br>Update Note  : 2014/12/16 ����</br>
        /// <br>�Ǘ��ԍ�     : 11070263-00</br>
        /// <br>             :�E�����Y�ƗlSeiken�i�ԕύX</br>
        /// <br>Update Note  : 2015/03/05 ����</br>
        /// <br>�Ǘ��ԍ�     : 11070263-00</br>
        /// <br>             :�E�����Y�ƗlSeiken�i�ԕύX �V�X�e����Q�Ή�(�i�ԕ\��)</br>
        /// </remarks>
        private void GetPartsInfo(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn)
        {
            GoodsCndtn goodsCndtn = new GoodsCndtn(); // ADD 2009/02/16

            ShipGdsPrmListCndtnPartnerWork shipGdsPrmListCndtnPartnerWork = new ShipGdsPrmListCndtnPartnerWork(); // ADD 2009/02/16

            // �����i1�����ɏ���
            foreach (DataRow dr in this._shipGdsPrimeListDt.Rows)
            {
                // ���i���擾
                //GoodsCndtn goodsCndtn = new GoodsCndtn(); // DEL 2009/02/16

                goodsCndtn.EnterpriseCode = dr[PMHNB02145EA.ct_Col_EnterpriseCode].ToString();
                goodsCndtn.SectionCode = dr[PMHNB02145EA.ct_Col_AddUpSecCode].ToString(); // ADD 2008/12/17
                goodsCndtn.GoodsNo = dr[PMHNB02145EA.ct_Col_GoodsNo].ToString();
                goodsCndtn.GoodsMakerCd = (int)dr[PMHNB02145EA.ct_Col_GoodsMakerCd];
                goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.Search; // ADD 2008/12/17

                goodsCndtn.IsSettingSupplier = 1; // ADD 2009/02/16
                goodsCndtn.IsSettingVariousMst = 1; // ADD 2009/02/16

                PartsInfoDataSet partsInfoDataSet;
                List<GoodsUnitData> GoodsUnitDataList;
                string msg;

                // ���i�}�X�^����(�����i����)
                this._goodsAcs.SearchPartsFromGoodsNoWholeWord(goodsCndtn, false, out partsInfoDataSet, out GoodsUnitDataList, out msg);

                // --- ADD 2009/02/16 -------------------------------->>>>>
                if (GoodsUnitDataList == null || GoodsUnitDataList.Count == 0)
                {
                    // �ȍ~�̏����擾���Ȃ�
                    continue;
                }

                // �e���擾
                this._goodsAcs.GetGoodsUnitDataListFromPartsInfoDataSet(partsInfoDataSet, goodsCndtn.GoodsMakerCd, goodsCndtn.GoodsNo, GoodsAcs.GoodsKind.Parent, out GoodsUnitDataList);

                if (GoodsUnitDataList == null || GoodsUnitDataList.Count == 0)
                {
                    continue;
                }

                // --- ADD 2009.02.18 -------------------------------->>>>>
                GoodsUnitData parentGoodsUnitData = GoodsUnitDataList[0];
 
                // ���i�A���f�[�^�s�����ݒ菈���ďo��
                this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref parentGoodsUnitData, 1);
                // --- ADD 2009.02.18 --------------------------------<<<<<

                //this.SetParentInfo(GoodsUnitDataList[0], dr); // DEL 2009.02.18
                this.SetParentInfo(parentGoodsUnitData, dr); // ADD 2009.02.18

                // --- ADD 2009/02/16 --------------------------------<<<<<

                // �����q�f�[�^�݂̂���o��
                this._goodsAcs.GetGoodsUnitDataListFromPartsInfoDataSet(partsInfoDataSet, goodsCndtn.GoodsMakerCd, goodsCndtn.GoodsNo, GoodsAcs.GoodsKind.ChildJoin, out GoodsUnitDataList); // ADD 2008/12/17

                // �e�X�g�p
                //this.testProcGoods(out GoodsUnitDataList);

                // ���[�󎚑ΏۗD�Ǖi ��񃊃X�g
                List<GoodsUnitData> printGoodsUnitDataList = new List<GoodsUnitData>();
                ArrayList printShipGdsPrimeListResultList = new ArrayList();

                // �����W�v�f�[�^���擾
                for (int i = 0; i < GoodsUnitDataList.Count; i++)
                {
                    GoodsUnitData goodsUnitData = GoodsUnitDataList[i];

                    // --- DEL 2008/12/17 -------------------------------->>>>>
                    //if (
                    //    //goodsCndtn.EnterpriseCode == goodsUnitData.EnterpriseCode // DEL 2008/12/16
                    //    goodsCndtn.GoodsNo == goodsUnitData.GoodsNo
                    //    && goodsCndtn.GoodsMakerCd == goodsUnitData.GoodsMakerCd)
                    //{
                    //    // �����i�͏���
                    //    continue;
                    //}
                    // --- DEL 2008/12/17 --------------------------------<<<<<
                    
                    //ShipGdsPrmListCndtnPartnerWork shipGdsPrmListCndtnPartnerWork = new ShipGdsPrmListCndtnPartnerWork(); // DEL 2009/02/16

                    // ���o�����W�J  --------------------------------------------------------------
                    int status = this.DevPartnerListCndtn(shipGdsPrimeListCndtn, dr[PMHNB02145EA.ct_Col_AddUpSecCode].ToString(), goodsUnitData,
                                                          ref shipGdsPrmListCndtnPartnerWork);

                    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        continue;
                    }

                    ArrayList shipGdsPrmListCndtnPartnerWorkList = new ArrayList();
                    shipGdsPrmListCndtnPartnerWorkList.Add(shipGdsPrmListCndtnPartnerWork);

                    object retWorkList = null;

                    // �����[�g����(�D�Ǖi)
                    status = this._iShipGdsPrimeListResultWorkDB.SearchPartner(out retWorkList, shipGdsPrmListCndtnPartnerWorkList, 0, ConstantManagement.LogicalMode.GetData0);

                    // �e�X�g�p
                    //this.testProcParts(out retWorkList);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                        || ((ArrayList)retWorkList).Count == 0)
                    {
                        continue;
                    }
                    //------ DEL START 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------>>>>>
                    // �V�����i���m�肵����A���i�A���f�[�^���擾����B
                    //// --- ADD 2009/01/13 -------------------------------->>>>>
                    //// ���i�A���f�[�^�s�����ݒ菈���ďo��
                    ////this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData); // DEL 2009/02/16
                    //this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData, 1); // ADD 2009/02/16
                    //// --- ADD 2009/01/13 --------------------------------<<<<<
                    //------ DEL END 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------<<<<<
                    string shipGoodsNo = string.Empty;
                    ArrayList resultList = retWorkList as ArrayList;
                    string tempGoodsNo = string.Empty; //ADD 2015/03/05 ���� FOR �����Y�ƗlSeiken�i�ԕύX�̃V�X�e����Q�Ή�(�i�Ԃ̕\��)
                    ShipGdsPrimeListResultWork shipGdsPrimeListResultWork = new ShipGdsPrimeListResultWork();
                    for (int j = 0; j < resultList.Count; j++)
                    {
                        shipGdsPrimeListResultWork = resultList[j] as ShipGdsPrimeListResultWork;
                    }
                    //------ ADD START 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------>>>>>
                    // �i�ԏW�v�敪�́u���Z�v���i�ԕ\���敪���u���i�ԁv�ꍇ
                    if ((shipGdsPrimeListCndtn.GoodsNoTtlDiv == ShipGdsPrimeListCndtn.GoodsNoTtlDivState.Together) &&
                        (shipGdsPrimeListCndtn.GoodsNoShowDiv == ShipGdsPrimeListCndtn.GoodsNoShowDivState.OldGoodsNo))
                    {
                        GoodsCndtn goodsCndtnChg = new GoodsCndtn();
                        List<GoodsUnitData> GoodsUnitDataListChg;
                        goodsCndtnChg.EnterpriseCode = shipGdsPrimeListCndtn.EnterpriseCode;
                        //goodsCndtnChg.SectionCode = dr[PMHNB02145EA.ct_Col_AddUpSecCode].ToString();
                        goodsCndtnChg.GoodsNo = shipGdsPrimeListResultWork.OldGoodsNo;
                        // ���i�ԕ\���̏ꍇ�A���i�Ԃ��ꎞ�ޔ����܂��B
                        tempGoodsNo = shipGdsPrimeListResultWork.OldGoodsNo;//ADD 2015/03/05 ���� FOR �����Y�ƗlSeiken�i�ԕύX(�i�Ԃ̕\��)
                        goodsCndtnChg.GoodsMakerCd = shipGdsPrimeListResultWork.GoodsMakerCd;
                        //goodsCndtnChg.LogicalMode = (int)ConstantManagement.LogicalMode.GetData01;
                        goodsCndtnChg.IsSettingSupplier = 1;
                        goodsCndtnChg.IsSettingVariousMst = 1;
                        //this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnChg, false, out GoodsUnitDataListChg, out msg); // DEL 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�
                        //----- ADD 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�------>>>>>
                        goodsCndtnChg.GoodsKindCode = 9;
                        this._goodsAcs.Search(goodsCndtnChg, out GoodsUnitDataListChg, out msg);
                        //----- ADD 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�------<<<<<
                        if (GoodsUnitDataListChg == null || GoodsUnitDataListChg.Count == 0)
                        {
                            // �����i�̍݌ɏ�񂪂Ȃ����߁A�V���i���g�p���܂��B
                            goodsCndtnChg.GoodsNo = shipGdsPrimeListResultWork.GoodsNo;
                            //this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnChg, false, out GoodsUnitDataListChg, out msg); // DEL 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�
                            this._goodsAcs.Search(goodsCndtnChg, out GoodsUnitDataListChg, out msg); // ADD 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�
                            if (GoodsUnitDataListChg == null || GoodsUnitDataListChg.Count == 0)
                            {
                                // �V���i���Ȃ����߁A�����̂܂ܐV���i���g�p���܂��B
                            }
                            else
                            {
                                // �V���i�����邽�߁A�V���i���g�p���܂��B
                                goodsUnitData = GoodsUnitDataListChg[0];
                            }                           
                        }
                        else
                        {
                            // �����i�����邽�߁A�����i���g�p���܂��B
                            goodsUnitData = GoodsUnitDataListChg[0];
                        }
                    }
                    // �i�ԏW�v�敪�́u���Z�v���i�ԕ\���敪���u�V�i�ԁv�ꍇ
                    else if ((shipGdsPrimeListCndtn.GoodsNoTtlDiv == ShipGdsPrimeListCndtn.GoodsNoTtlDivState.Together) &&
                        (shipGdsPrimeListCndtn.GoodsNoShowDiv == ShipGdsPrimeListCndtn.GoodsNoShowDivState.NewGoodsNo))
                    {
                        GoodsCndtn goodsCndtnChg = new GoodsCndtn();
                        List<GoodsUnitData> GoodsUnitDataListChg;
                        goodsCndtnChg.EnterpriseCode = shipGdsPrimeListCndtn.EnterpriseCode;
                        //goodsCndtnChg.SectionCode = dr[PMHNB02145EA.ct_Col_AddUpSecCode].ToString();
                        goodsCndtnChg.GoodsNo = shipGdsPrimeListResultWork.GoodsNo;
                        // �V�i�ԕ\���̏ꍇ�A�V�i�Ԃ��ꎞ�ޔ����܂��B
                        tempGoodsNo = shipGdsPrimeListResultWork.GoodsNo;//ADD 2015/03/05 ���� FOR �����Y�ƗlSeiken�i�ԕύX(�i�Ԃ̕\��)
                        goodsCndtnChg.GoodsMakerCd = shipGdsPrimeListResultWork.GoodsMakerCd;
                        //goodsCndtnChg.LogicalMode = (int)ConstantManagement.LogicalMode.GetData01;
                        goodsCndtnChg.IsSettingSupplier = 1;
                        goodsCndtnChg.IsSettingVariousMst = 1;
                        //this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnChg, false, out GoodsUnitDataListChg, out msg);// DEL 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�
                        //----- ADD 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�------>>>>>
                        goodsCndtnChg.GoodsKindCode = 9;
                        this._goodsAcs.Search(goodsCndtnChg, out GoodsUnitDataListChg, out msg);
                        //----- ADD 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�------<<<<<
                        if (GoodsUnitDataListChg == null || GoodsUnitDataListChg.Count == 0)
                        {
                            // �V���i�̍݌ɏ�񂪂Ȃ����߁A���V���i���g�p���܂��B
                            goodsCndtnChg.GoodsNo = shipGdsPrimeListResultWork.OldGoodsNo;
                            //this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnChg, false, out GoodsUnitDataListChg, out msg); // DEL 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�
                            this._goodsAcs.Search(goodsCndtnChg, out GoodsUnitDataListChg, out msg); // ADD 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�
                            if (GoodsUnitDataListChg == null || GoodsUnitDataListChg.Count == 0)
                            {
                                // �����i���Ȃ����߁A�����̂܂܂��g�p���܂��B
                            }
                            else
                            {
                                // �����i�����݂̏ꍇ�A�����i���g�p���܂��B
                                goodsUnitData = GoodsUnitDataListChg[0];
                            }
                        }
                        else
                        {
                            // �V���i�����݂̏ꍇ�A�����̂܂ܐV���i���g�p���܂��B
                            goodsUnitData = GoodsUnitDataListChg[0];
                        }
                    }
                    else
                    {
                        // �i�ԏW�v�敪�́u�ʁX�v�̏ꍇ�A�����̂܂܂ŏ������܂��B
                    }

                    // ���i�A���f�[�^�s�����ݒ菈���ďo��
                    this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData, 1);

                    //------ ADD START 2015/03/05 ���� �����Y�ƗlSeiken�i�ԕύX(�i�Ԃ̕\��) ------>>>>>
                    // �i�ԏW�v�敪�́u���Z�v
                    if (shipGdsPrimeListCndtn.GoodsNoTtlDiv == ShipGdsPrimeListCndtn.GoodsNoTtlDivState.Together) 
                    {
                        if (!tempGoodsNo.Equals(goodsUnitData.GoodsNo))
                        {
                            // �ꎞ�ޔ������i�Ԃ����i�}�X�^�ɐ؂�ւ����܂��B
                            goodsUnitData.GoodsNo = tempGoodsNo;
                            // �q�ɏ����擾���邽�߂ɁA�q�ɏ��̏��i�ԍ����؂�ւ����܂��B
                            if (goodsUnitData.StockList != null && goodsUnitData.StockList.Count > 0)
                            {
                                foreach (Stock stock in goodsUnitData.StockList)
                                {
                                    stock.GoodsNo = tempGoodsNo;
                                }
                            }
                        }
                    }
                    else
                    {
                        // �i�ԏW�v�敪�́u�ʁX�v�̏ꍇ�A�����̂܂܂ŏ������܂��B
                    }
                    //------ ADD END 2015/03/05 ���� FOR �����Y�ƗlSeiken�i�ԕύX(�i�Ԃ̕\��) ------<<<<<
                    //------ ADD END 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------<<<<<

                    // �����f�[�^�܂Ő���Ɏ擾�o�����ꍇ�̂݁A�󎚗p�f�[�^�ɕۑ�
                    printGoodsUnitDataList.Add(goodsUnitData);
                    printShipGdsPrimeListResultList.Add(((ArrayList)retWorkList)[0]);
                }

                // �D�Ǖi����ۑ�
                dr[PMHNB02145EA.ct_Col_PartsCount] = printGoodsUnitDataList.Count;
                dr[PMHNB02145EA.ct_Col_GoodsUnitDataList] = printGoodsUnitDataList;
                dr[PMHNB02145EA.ct_Col_ShipGdsPrimeListResultList] = printShipGdsPrimeListResultList;
            }
        }

        // --- ADD 2009/02/16 -------------------------------->>>>>
        /// <summary>
        /// �����i���ݒ�
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="dr"></param>
        private void SetParentInfo(GoodsUnitData goodsUnitData, DataRow dr)
        {
            dr[PMHNB02145EA.ct_Col_GoodsMakerName] = goodsUnitData.MakerShortName; // ���[�J�[����
            dr[PMHNB02145EA.ct_Col_GoodsMGroup] = goodsUnitData.GoodsMGroup; // ���i�����ރR�[�h
            dr[PMHNB02145EA.ct_Col_GoodsMGroupName] = goodsUnitData.GoodsMGroupName; // ���i�����ޖ���
            //dr[PMHNB02145EA.ct_Col_BLGroupCode] = goodsUnitData.BLGroupCode; // BL�O���[�v�R�[�h // DEL 2009/02/21
            //dr[PMHNB02145EA.ct_Col_BLGroupCodeName] = goodsUnitData.BLGroupName; // BL�O���[�v�R�[�h���� // DEL 2009/02/21
            // --- ADD 2009/02/21 -------------------------------->>>>>
            if (dr[PMHNB02145EA.ct_Col_BLGroupCode] == null
                || dr[PMHNB02145EA.ct_Col_BLGroupCode].ToString() == string.Empty
                || (int)dr[PMHNB02145EA.ct_Col_BLGroupCode] == 0)
            {
                dr[PMHNB02145EA.ct_Col_BLGroupCode] = goodsUnitData.BLGroupCode; // BL�O���[�v�R�[�h
                dr[PMHNB02145EA.ct_Col_BLGroupCodeName] = goodsUnitData.BLGroupName; // BL�O���[�v�R�[�h����
            }
            // --- ADD 2009/02/21 --------------------------------<<<<<
            dr[PMHNB02145EA.ct_Col_SuplierCode] = goodsUnitData.SupplierCd; // �d����R�[�h(�����i�ł͎g�p���Ȃ�)
            dr[PMHNB02145EA.ct_Col_GoodsName] = goodsUnitData.GoodsNameKana; // �i��

            // �݌Ƀ��X�g��Index����
            int index = GetStockListIndex(dr[PMHNB02145EA.ct_Col_EnterpriseCode].ToString()
                                                         , dr[PMHNB02145EA.ct_Col_AddUpSecCode].ToString()
                                                         , goodsUnitData);
            if (index != -1)
            {
                dr[PMHNB02145EA.ct_Col_WarehouseShelfNo] = goodsUnitData.StockList[index].WarehouseShelfNo; // �I��
                dr[PMHNB02145EA.ct_Col_SupplierStock] = goodsUnitData.StockList[index].SupplierStock; // ���݌Ɂi�d���݌ɐ��j
            }
            else
            {
                // �݌Ƀ��X�g��0���̏ꍇ�A�\���͍s���B�i�I�Ԃƌ��݌ɂ̓J���j
            }

            // ���i���̃C���f�b�N�X���擾
            index = GetGoodsPriceListIndex(goodsUnitData.GoodsPriceList);

            if (index != -1)
            {
                dr[PMHNB02145EA.ct_Col_ListPrice] = goodsUnitData.GoodsPriceList[index].ListPrice; // ���i
            }
            else
            {
                // ���i���X�g��0���̏ꍇ�A�\���͍s���B�i���i�̓J���j
            }
        }
        // --- ADD 2009/02/16 --------------------------------<<<<<

        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="salesRsltListCndtn">UI���o�����N���X</param>
        /// <param name="salesRsltListCndtnWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       �@: ��ʒ��o�����������[�g���o�����֓W�J����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.14</br>
        /// <br>Update Note  : 2014/12/16 ����</br>
        /// <br>�Ǘ��ԍ�     : 11070263-00</br>
        /// <br>             :�E�����Y�ƗlSeiken�i�ԕύX</br>
        /// </remarks>
        private int DevPartnerListCndtn(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn, string sectionCode, GoodsUnitData goodsUnitData,
            ref ShipGdsPrmListCndtnPartnerWork shipGdsPrmListCndtnPartnerWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //shipGdsPrmListCndtnPartnerWork = new ShipGdsPrmListCndtnPartnerWork(); // DEL 2009/02/16

            try
            {
                // ���o�������ݒ�
                shipGdsPrmListCndtnPartnerWork.EnterpriseCode = shipGdsPrimeListCndtn.EnterpriseCode;  // ��ƃR�[�h
                shipGdsPrmListCndtnPartnerWork.St_AddUpYearMonth = shipGdsPrimeListCndtn.St_AddUpYearMonth; // �J�n�Ώ۔N��
                shipGdsPrmListCndtnPartnerWork.Ed_AddUpYearMonth = shipGdsPrimeListCndtn.Ed_AddUpYearMonth; // �I���Ώ۔N��
                //------ ADD START 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------>>>>>
                shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv = (int)shipGdsPrimeListCndtn.GoodsNoTtlDiv; // �i�ԏW�v�敪
                if (shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv == 1)
                {
                    shipGdsPrmListCndtnPartnerWork.GoodsNoShowDiv = (int)shipGdsPrimeListCndtn.GoodsNoShowDiv; // �i�ԕ\���敪
                }
                //------ ADD END 2014/12/16 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------<<<<<

                // �D�Ǐ��i���1���ݒ�
                shipGdsPrmListCndtnPartnerWork.SectionCode = sectionCode; // ���_�R�[�h
                shipGdsPrmListCndtnPartnerWork.GoodsMakerCd = goodsUnitData.GoodsMakerCd; // ���[�J�[�R�[�h
                shipGdsPrmListCndtnPartnerWork.GoodsNo = goodsUnitData.GoodsNo; // �i�ԃR�[�h
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        // --- ADD 2009/01/08 -------------------------------->>>>>
        /// <summary>
        /// �����у��R�[�h���O����
        /// </summary>
        /// <remarks>
        /// <br>Note       �@: �����i�ԁA�D�Ǖi�ԑS�ĂɎ��т��������R�[�h�����O����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2009.01.08</br>
        /// </remarks>
        private void RemoveNoResultGoodsRow()
        {
            DataTable tmpTable = this._shipGdsPrimeListDt.Copy();
            this._shipGdsPrimeListDt.Clear();

            foreach (DataRow dr in tmpTable.Rows)
            {
                // ���їL���t���O(true:����)
                bool existResultFlg = false;

                #region �����i�`�F�b�N
                if (
                    (Int64)dr[PMHNB02145EA.ct_Col_St_SalesMoney]
                    + (Int64)dr[PMHNB02145EA.ct_Col_St_SalesRetGoodsPrice]
                    + (Int64)dr[PMHNB02145EA.ct_Col_St_DiscountPrice]
                    + (Int64)dr[PMHNB02145EA.ct_Col_Or_SalesMoney]
                    + (Int64)dr[PMHNB02145EA.ct_Col_Or_SalesRetGoodsPrice]
                    + (Int64)dr[PMHNB02145EA.ct_Col_Or_DiscountPrice]
                    != 0)
                {
                    // ������z����
                    existResultFlg = true;
                }

                if (!existResultFlg
                    &&
                    (Int64)dr[PMHNB02145EA.ct_Col_St_GrossProfit]
                    + (Int64)dr[PMHNB02145EA.ct_Col_Or_GrossProfit]
                    != 0
                    )
                {
                    // �e���z����
                    existResultFlg = true;
                }

                if (!existResultFlg
                    &&
                    (double)dr[PMHNB02145EA.ct_Col_St_TotalSalesCount] != 0)
                {
                    // ���㐔�v�i�݌Ɂj����
                    existResultFlg = true;
                }

                if (!existResultFlg
                    &&
                    (double)dr[PMHNB02145EA.ct_Col_Or_TotalSalesCount] != 0)
                {
                    // ���㐔�v�i���j����
                    existResultFlg = true;
                }

                // --- ADD 2009/03/13 -------------------------------->>>>>
                if (!existResultFlg
                    &&
                    (double)dr[PMHNB02145EA.ct_Col_ListPrice] != 0)
                {
                    // ���i����
                    existResultFlg = true;
                }
                // --- ADD 2009/03/13 --------------------------------<<<<<
                #endregion

                #region �D�Ǖi�`�F�b�N

                if (!existResultFlg
                    && dr[PMHNB02145EA.ct_Col_ShipGdsPrimeListResultList] != null
                    && ((ArrayList)dr[PMHNB02145EA.ct_Col_ShipGdsPrimeListResultList]).Count != 0)
                {
                    // �����i�̎��т��������D�Ǖi�����݂���ꍇ�A�D�Ǖi�̎��у`�F�b�N
                    //foreach (ShipGdsPrimeListResultWork shipGdsPrimeListResultWork in (ArrayList)(dr[PMHNB02145EA.ct_Col_ShipGdsPrimeListResultList])) // DEL 2009/03/13
                    for (int i = 0; i < ((ArrayList)(dr[PMHNB02145EA.ct_Col_ShipGdsPrimeListResultList])).Count; i++) // ADD 2009/03/13
                    {
                        ShipGdsPrimeListResultWork shipGdsPrimeListResultWork = (ShipGdsPrimeListResultWork)((ArrayList)(dr[PMHNB02145EA.ct_Col_ShipGdsPrimeListResultList]))[i]; // ADD 2009/03/13
                        //GoodsUnitData goodsUnitData = (GoodsUnitData)((ArrayList)dr[PMHNB02145EA.ct_Col_GoodsUnitDataList])[i]; // DEL ������ 2012/04/09 Redmine#29336
                        GoodsUnitData goodsUnitData = ((List<GoodsUnitData>)(dr[PMHNB02145EA.ct_Col_GoodsUnitDataList]))[i];  //ADD ������ 2012/04/09 Redmine#29336

                        if (
                            shipGdsPrimeListResultWork.St_SalesMoney
                            + shipGdsPrimeListResultWork.St_SalesRetGoodsPrice
                            + shipGdsPrimeListResultWork.St_DiscountPrice
                            + shipGdsPrimeListResultWork.Or_SalesMoney
                            + shipGdsPrimeListResultWork.Or_SalesRetGoodsPrice
                            + shipGdsPrimeListResultWork.Or_DiscountPrice
                            != 0
                            )
                        {
                            // ������z����
                            existResultFlg = true;
                            break;
                        }

                        if (!existResultFlg
                            &&
                            shipGdsPrimeListResultWork.St_GrossProfit
                            + shipGdsPrimeListResultWork.Or_GrossProfit
                            != 0
                            )
                        {
                            // �e���z����
                            existResultFlg = true;
                            break;
                        }

                        if (!existResultFlg
                            &&
                            shipGdsPrimeListResultWork.St_TotalSalesCount != 0)
                        {
                            // ���㐔�v�i�݌Ɂj����
                            existResultFlg = true;
                            break;
                        }

                        if (!existResultFlg
                            &&
                            shipGdsPrimeListResultWork.Or_TotalSalesCount != 0)
                        {
                            // ���㐔�v�i���j����
                            existResultFlg = true;
                            break;
                        }

                        // --- ADD 2009/03/13 -------------------------------->>>>>
                        // ���i���̃C���f�b�N�X���擾
                        int index = GetGoodsPriceListIndex(goodsUnitData.GoodsPriceList);

                        double price = 0;
                        if (index != -1)
                        {
                            price = goodsUnitData.GoodsPriceList[index].ListPrice; // ���i
                        }

                        if (!existResultFlg
                            &&
                            price != 0)
                        {
                            // ���i����
                            existResultFlg = true;
                            break;
                        }
                        // --- ADD 2009/03/13 --------------------------------<<<<<
                    }
                }
                #endregion

                if (existResultFlg)
                {
                    // ���т�����ꍇ�͈󎚑ΏۂƂ���
                    this._shipGdsPrimeListDt.ImportRow(dr);
                }
            }
        }
        // --- ADD 2009/01/08 --------------------------------<<<<<

        /// <summary>
        /// ���ʂ̐ݒ���s��
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn">���o����</param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        private void SetOrder(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn, ref string errMsg)
        {
            string savAddUpSecCode = ""; // ���_�R�[�h
            string savCode = ""; // ���ʕt�Ŏw�肵���P��(���[�J�[�A���i�����ށA�O���[�v�R�[�h) 
            int orderNo = 0; // ����
            int orderNoPls = 0; // ���ʉ��Z�l
            double savTotls = -1;  
            double nowTotls = 0;

            DataTable tmpTable = this._shipGdsPrimeListDt.Copy();
            this._shipGdsPrimeListDt.Clear();

            // �����敪�𔽉f
            // ���ʕt�ݒ菇�ɕ��ёւ�
            DataRow[] sortedDrList = tmpTable.Select(this.GetFilterStringForOrder(shipGdsPrimeListCndtn), this.GetSortStringForOrder(shipGdsPrimeListCndtn));

            for (int i = 0; i < sortedDrList.Length; i++)
            {
                DataRow dr = sortedDrList[i];

                //���_-�w�肵���P�ʖ�
                string tmpAddUpSecCode = (string)dr[PMHNB02145EA.ct_Col_AddUpSecCode];

                string tmpCode;
                if (shipGdsPrimeListCndtn.RankSection == ShipGdsPrimeListCndtn.RankSectionState.Maker)
                {
                    tmpCode = dr[PMHNB02145EA.ct_Col_GoodsMakerCd].ToString();
                }
                else if (shipGdsPrimeListCndtn.RankSection == ShipGdsPrimeListCndtn.RankSectionState.GoodsMGroup)
                {
                    tmpCode = (string)dr[PMHNB02145EA.ct_Col_GoodsMGroup].ToString();
                }
                else
                {
                    tmpCode = (string)dr[PMHNB02145EA.ct_Col_BLGroupCode].ToString();
                }

                // ���_�Ǝw�肵���P�ʂ̂��Âꂩ���قȂ�ꍇ�A���ʕt����������
                if (savAddUpSecCode.Trim() != tmpAddUpSecCode.Trim()
                    || savCode.Trim() != tmpCode.Trim())
                {
                    savAddUpSecCode = tmpAddUpSecCode;
                    savCode = tmpCode;
                    orderNo = 0;
                    orderNoPls = 0;
                    savTotls = -1;
                }

                nowTotls = (double)dr[PMHNB02145EA.ct_Col_Sum_TotalSalesCount];

                if (savTotls == nowTotls)
                {
                    orderNoPls++;
                }
                else
                {
                    // ���ʂ͍ő�l�ȏ���U��
                    savTotls = nowTotls;
                    orderNo += orderNoPls;
                    orderNoPls = 0;
                }

                if (orderNoPls == 0)
                {
                    orderNo++;
                }

                dr[PMHNB02145EA.ct_Col_Order] = orderNo;

                this._shipGdsPrimeListDt.ImportRow(dr);
            }
        }

        /// <summary>
        /// ���ʕt�p�t�B���^������쐬
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <returns></returns>
        private string GetFilterStringForOrder(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn)
        {
            if (shipGdsPrimeListCndtn.ComvDiv == ShipGdsPrimeListCndtn.ComvDivState.Combine)
            {
                return PMHNB02145EA.ct_Col_PartsCount + " > 0";
            }
            else if (shipGdsPrimeListCndtn.ComvDiv == ShipGdsPrimeListCndtn.ComvDivState.NotCombine)
            {
                return PMHNB02145EA.ct_Col_PartsCount + " = 0";
            }
            else // �S��
            {
                // �t�B���^�Ȃ�
                return "";
            }
        }

        /// <summary>
        /// ���ʕt�p�\�[�g������쐬
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <returns></returns>
        private string GetSortStringForOrder(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn)
        {
            StringBuilder sb = new StringBuilder();

            // ���_ + ���ʕt�Ŏw�肵���P�� + ���㐔�v(�݌�+���)��(���or����)�Ń\�[�g
            sb.Append(PMHNB02145EA.ct_Col_AddUpSecCode);
            sb.Append(", ");

            switch (shipGdsPrimeListCndtn.RankSection)
            {
                case ShipGdsPrimeListCndtn.RankSectionState.Maker:
                    {
                        sb.Append(PMHNB02145EA.ct_Col_GoodsMakerCd);
                        break;
                    }
                case ShipGdsPrimeListCndtn.RankSectionState.BLGroupCode:
                    {
                        sb.Append(PMHNB02145EA.ct_Col_BLGroupCode);
                        break;
                    }
                case ShipGdsPrimeListCndtn.RankSectionState.GoodsMGroup:
                    {
                        sb.Append(PMHNB02145EA.ct_Col_GoodsMGroup);
                        break;
                    }
            }

            sb.Append(", ");
            sb.Append(PMHNB02145EA.ct_Col_Sum_TotalSalesCount);

            if (shipGdsPrimeListCndtn.RankHighLow == ShipGdsPrimeListCndtn.RankHighLowState.High)
            {
                sb.Append(" DESC");
            }
            else
            {
                sb.Append(" ASC");
            }

            return sb.ToString();
        }

        /// <summary>
        /// �t�B���^�A�\�[�g�������s��
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn">���o����</param>
        private void FilterAndSort(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn)
        {
            DataTable tmpTable = this._shipGdsPrimeListDt.Copy();
            this._shipGdsPrimeListDt.Clear();

            DataRow[] drList = tmpTable.Select(this.GetFilterString(shipGdsPrimeListCndtn), this.GetSortString(shipGdsPrimeListCndtn));

            foreach(DataRow dr in drList)
            {
                this._shipGdsPrimeListDt.ImportRow(dr);
            }
        }

        /// <summary>
        /// �t�B���^��������擾����
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <returns></returns>
        private string GetFilterString(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn)
        {
            return PMHNB02145EA.ct_Col_Order + " <=" + shipGdsPrimeListCndtn.RankOrderMax;
        }

        /// <summary>
        /// �\�[�g��������擾����
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <returns></returns>
        private string GetSortString(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn)
        {
            StringBuilder sb = new StringBuilder();

            // ���_ + ���ʕt�Ŏw�肵���P�� + ���� + �i�ԂŃ\�[�g
            sb.Append(PMHNB02145EA.ct_Col_AddUpSecCode);
            sb.Append(", ");

            switch (shipGdsPrimeListCndtn.RankSection)
            {
                case ShipGdsPrimeListCndtn.RankSectionState.Maker:
                    {
                        sb.Append(PMHNB02145EA.ct_Col_GoodsMakerCd);
                        break;
                    }
                case ShipGdsPrimeListCndtn.RankSectionState.BLGroupCode:
                    {
                        sb.Append(PMHNB02145EA.ct_Col_BLGroupCode);
                        break;
                    }
                case ShipGdsPrimeListCndtn.RankSectionState.GoodsMGroup:
                    {
                        sb.Append(PMHNB02145EA.ct_Col_GoodsMGroup);
                        break;
                    }
            }
            sb.Append(", ");

            sb.Append(PMHNB02145EA.ct_Col_Order);
            sb.Append(", ");

            sb.Append(PMHNB02145EA.ct_Col_GoodsNo);

            return sb.ToString();
        }

        /// <summary>
        /// ���[�󎚗p�e�[�u����1�s�f�[�^���쐬����
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn">���o����</param>
        private void MakePrintTable(ShipGdsPrimeListCndtn shipGdsPrimeListCndtn)
        {
            // ���[�󎚗p�e�[�u���쐬
            PMHNB02145EB.CreateDataTable(ref this._printDt);

            // ���[�󎚗p�e�[�u���ɒǉ�����1�s���(PMHNB02145EB)
            DataRow printRow;

            foreach (DataRow dr in this._shipGdsPrimeListDt.Rows)
            {
                if ((Int32)dr[PMHNB02145EA.ct_Col_PartsCount] == 0)
                {
                    if (shipGdsPrimeListCndtn.ComvDiv == ShipGdsPrimeListCndtn.ComvDivState.All
                    || shipGdsPrimeListCndtn.ComvDiv == ShipGdsPrimeListCndtn.ComvDivState.NotCombine)
                    {
                        // 1�s�̂ݍ쐬
                        printRow = this._printDt.NewRow();

                        #region �����i���
                        // �����i���ݒ�
                        printRow[PMHNB02145EB.ct_Col_RowNumber] = 0; // �s�ԍ�
                        printRow[PMHNB02145EB.ct_Col_AddUpSecCode] = dr[PMHNB02145EA.ct_Col_AddUpSecCode]; // ���_�R�[�h
                        printRow[PMHNB02145EB.ct_Col_SectionGuideSnm] = dr[PMHNB02145EA.ct_Col_SectionGuideSnm]; // ���_����
                        printRow[PMHNB02145EB.ct_Col_Pure_WarehouseShelfNo] = dr[PMHNB02145EA.ct_Col_WarehouseShelfNo]; // �I��
                        printRow[PMHNB02145EB.ct_Col_Pure_MakerCode] = dr[PMHNB02145EA.ct_Col_GoodsMakerCd]; // ���[�J�[�R�[�h
                        printRow[PMHNB02145EB.ct_Col_Pure_GoodsMakerName] = dr[PMHNB02145EA.ct_Col_GoodsMakerName]; // ���[�J�[����
                        printRow[PMHNB02145EB.ct_Col_Pure_GoodsMGroup] = dr[PMHNB02145EA.ct_Col_GoodsMGroup]; // ���i�����ރR�[�h
                        printRow[PMHNB02145EB.ct_Col_Pure_GoodsMGroupName] = dr[PMHNB02145EA.ct_Col_GoodsMGroupName]; // ���i�����ޖ���
                        printRow[PMHNB02145EB.ct_Col_Pure_BLGroupCode] = dr[PMHNB02145EA.ct_Col_BLGroupCode]; // �O���[�v�R�[�h
                        printRow[PMHNB02145EB.ct_Col_Pure_BLGroupCodeName] = dr[PMHNB02145EA.ct_Col_BLGroupCodeName]; // �O���[�v�R�[�h����
                        printRow[PMHNB02145EB.ct_Col_Pure_GoodsNo] = dr[PMHNB02145EA.ct_Col_GoodsNo]; // �i��
                        printRow[PMHNB02145EB.ct_Col_Pure_GoodsName] = dr[PMHNB02145EA.ct_Col_GoodsName]; // �i��
                        printRow[PMHNB02145EB.ct_Col_Pure_GoodsPrice] = dr[PMHNB02145EA.ct_Col_ListPrice]; // ���i
                        printRow[PMHNB02145EB.ct_Col_Pure_SupplierStock] = dr[PMHNB02145EA.ct_Col_SupplierStock]; // ���݌�(�d���݌ɐ�)
                        printRow[PMHNB02145EB.ct_Col_Pure_StockTotalSalesCount] = dr[PMHNB02145EA.ct_Col_St_TotalSalesCount]; // ���㐔�v(�݌�)
                        printRow[PMHNB02145EB.ct_Col_Pure_OrderTotalSalesCount] = dr[PMHNB02145EA.ct_Col_Or_TotalSalesCount]; // ���㐔�v(���)

                        printRow[PMHNB02145EB.ct_Col_Pure_StockTotalSalesCountSum] = dr[PMHNB02145EA.ct_Col_St_TotalSalesCount];
                        printRow[PMHNB02145EB.ct_Col_Pure_OrderTotalSalesCountSum] = dr[PMHNB02145EA.ct_Col_Or_TotalSalesCount];

                        // �e�����v�Z
                        Int64 pureSalesMoneySum = (Int64)dr[PMHNB02145EA.ct_Col_St_SalesMoney] + (Int64)dr[PMHNB02145EA.ct_Col_St_SalesRetGoodsPrice] + (Int64)dr[PMHNB02145EA.ct_Col_St_DiscountPrice]
                                                 + (Int64)dr[PMHNB02145EA.ct_Col_Or_SalesMoney] + (Int64)dr[PMHNB02145EA.ct_Col_Or_SalesRetGoodsPrice] + (Int64)dr[PMHNB02145EA.ct_Col_Or_DiscountPrice];

                        Int64 grossProfitSum = (Int64)dr[PMHNB02145EA.ct_Col_St_GrossProfit] + (Int64)dr[PMHNB02145EA.ct_Col_Or_GrossProfit];

                        printRow[PMHNB02145EB.ct_Col_Pure_GrossProfitRate] = this.GetRatio(grossProfitSum, pureSalesMoneySum);

                        // 1�s�Ɋ܂܂��D�Ǖi��
                        printRow[PMHNB02145EB.ct_Col_PartsCount] = 0;

                        #endregion

                        this._printDt.Rows.Add(printRow);
                    }
                }
                else
                {
                    if (shipGdsPrimeListCndtn.ComvDiv == ShipGdsPrimeListCndtn.ComvDivState.All
                    || shipGdsPrimeListCndtn.ComvDiv == ShipGdsPrimeListCndtn.ComvDivState.Combine)
                    {
                        // �D�Ǖi��� ���[�󎚍s�쐬
                        for (int i = 0; i < (Int32)dr[PMHNB02145EA.ct_Col_PartsCount]; i = i + 2)
                        {
                            printRow = this._printDt.NewRow();

                            #region �����i���
                            // �����i���ݒ�
                            printRow[PMHNB02145EB.ct_Col_RowNumber] = i; // �s�ԍ�
                            printRow[PMHNB02145EB.ct_Col_AddUpSecCode] = dr[PMHNB02145EA.ct_Col_AddUpSecCode]; // ���_�R�[�h
                            printRow[PMHNB02145EB.ct_Col_SectionGuideSnm] = dr[PMHNB02145EA.ct_Col_SectionGuideSnm]; // ���_����
                            printRow[PMHNB02145EB.ct_Col_Pure_WarehouseShelfNo] = dr[PMHNB02145EA.ct_Col_WarehouseShelfNo]; // �I��
                            printRow[PMHNB02145EB.ct_Col_Pure_MakerCode] = dr[PMHNB02145EA.ct_Col_GoodsMakerCd]; // ���[�J�[�R�[�h
                            printRow[PMHNB02145EB.ct_Col_Pure_GoodsMakerName] = dr[PMHNB02145EA.ct_Col_GoodsMakerName]; // ���[�J�[����
                            printRow[PMHNB02145EB.ct_Col_Pure_GoodsMGroup] = dr[PMHNB02145EA.ct_Col_GoodsMGroup]; // ���i�����ރR�[�h
                            printRow[PMHNB02145EB.ct_Col_Pure_GoodsMGroupName] = dr[PMHNB02145EA.ct_Col_GoodsMGroupName]; // ���i�����ޖ���
                            printRow[PMHNB02145EB.ct_Col_Pure_BLGroupCode] = dr[PMHNB02145EA.ct_Col_BLGroupCode]; // �O���[�v�R�[�h
                            printRow[PMHNB02145EB.ct_Col_Pure_BLGroupCodeName] = dr[PMHNB02145EA.ct_Col_BLGroupCodeName]; // �O���[�v�R�[�h����
                            printRow[PMHNB02145EB.ct_Col_Pure_GoodsNo] = dr[PMHNB02145EA.ct_Col_GoodsNo]; // �i��
                            printRow[PMHNB02145EB.ct_Col_Pure_GoodsName] = dr[PMHNB02145EA.ct_Col_GoodsName]; // �i��
                            printRow[PMHNB02145EB.ct_Col_Pure_GoodsPrice] = dr[PMHNB02145EA.ct_Col_ListPrice]; // ���i
                            printRow[PMHNB02145EB.ct_Col_Pure_SupplierStock] = dr[PMHNB02145EA.ct_Col_SupplierStock]; // ���݌�(�d���݌ɐ�)
                            printRow[PMHNB02145EB.ct_Col_Pure_StockTotalSalesCount] = dr[PMHNB02145EA.ct_Col_St_TotalSalesCount]; // ���㐔�v(�݌�)
                            printRow[PMHNB02145EB.ct_Col_Pure_OrderTotalSalesCount] = dr[PMHNB02145EA.ct_Col_Or_TotalSalesCount]; // ���㐔�v(���)

                            // �e�����v�Z
                            Int64 pureSalesMoneySum = (Int64)dr[PMHNB02145EA.ct_Col_St_SalesMoney] + (Int64)dr[PMHNB02145EA.ct_Col_St_SalesRetGoodsPrice] + (Int64)dr[PMHNB02145EA.ct_Col_St_DiscountPrice]
                                                     + (Int64)dr[PMHNB02145EA.ct_Col_Or_SalesMoney] + (Int64)dr[PMHNB02145EA.ct_Col_Or_SalesRetGoodsPrice] + (Int64)dr[PMHNB02145EA.ct_Col_Or_DiscountPrice];

                            Int64 grossProfitSum = (Int64)dr[PMHNB02145EA.ct_Col_St_GrossProfit] + (Int64)dr[PMHNB02145EA.ct_Col_Or_GrossProfit];

                            printRow[PMHNB02145EB.ct_Col_Pure_GrossProfitRate] = this.GetRatio(grossProfitSum, pureSalesMoneySum);

                            if (i == 0)
                            {
                                // ������1�s�ڂł���΁A�v�󎚗p���㐔�v��ݒ�
                                printRow[PMHNB02145EB.ct_Col_Pure_StockTotalSalesCountSum] = dr[PMHNB02145EA.ct_Col_St_TotalSalesCount];
                                printRow[PMHNB02145EB.ct_Col_Pure_OrderTotalSalesCountSum] = dr[PMHNB02145EA.ct_Col_Or_TotalSalesCount];
                            }
                            #endregion

                            #region �D�Ǖi���1
                            // �D�Ǖi���i���1
                            GoodsUnitData goodsUnitData = ((List<GoodsUnitData>)(dr[PMHNB02145EA.ct_Col_GoodsUnitDataList]))[i];

                            printRow[PMHNB02145EB.ct_Col_Parts1_GoodsNo] = goodsUnitData.GoodsNo; // �i��
                            printRow[PMHNB02145EB.ct_Col_Parts1_MakerCode] = goodsUnitData.GoodsMakerCd; // ���[�J�[�R�[�h
                            printRow[PMHNB02145EB.ct_Col_Parts1_BLGroupCode] = goodsUnitData.BLGroupCode; // BL�O���[�v�R�[�h
                            printRow[PMHNB02145EB.ct_Col_Parts1_SuplierCode] = goodsUnitData.SupplierCd; // �d����R�[�h

                            // �݌Ƀ��X�g��Index����
                            int index = GetStockListIndex(dr[PMHNB02145EA.ct_Col_EnterpriseCode].ToString()
                                                         , dr[PMHNB02145EA.ct_Col_AddUpSecCode].ToString()
                                                         , goodsUnitData);

                            if (index != -1)
                            {
                                printRow[PMHNB02145EB.ct_Col_Parts1_WarehouseShelfNo] = goodsUnitData.StockList[index].WarehouseShelfNo; // �I��
                                printRow[PMHNB02145EB.ct_Col_Parts1_SupplierStock] = goodsUnitData.StockList[index].SupplierStock; // ���݌Ɂi�d���݌ɐ��j
                            }
                            
                            // ���i���̃C���f�b�N�X���擾
                            index = GetGoodsPriceListIndex(goodsUnitData.GoodsPriceList);

                            if (index != -1)
                            {
                                printRow[PMHNB02145EB.ct_Col_Parts1_GoodsPrice] = goodsUnitData.GoodsPriceList[index].ListPrice; // ���i
                            }

                            // �D�Ǖi�����W�v�f�[�^���1
                            ShipGdsPrimeListResultWork shipGdsPrimeListResultWork = (ShipGdsPrimeListResultWork)((ArrayList)dr[PMHNB02145EA.ct_Col_ShipGdsPrimeListResultList])[i];

                            printRow[PMHNB02145EB.ct_Col_Parts1_StockTotalSalesCount] = shipGdsPrimeListResultWork.St_TotalSalesCount;
                            printRow[PMHNB02145EB.ct_Col_Parts1_OrderTotalSalesCount] = shipGdsPrimeListResultWork.Or_TotalSalesCount;
                            printRow[PMHNB02145EB.ct_Col_Parts_StockTotalSalesCountSum] = (double)printRow[PMHNB02145EB.ct_Col_Parts_StockTotalSalesCountSum] + shipGdsPrimeListResultWork.St_TotalSalesCount;
                            printRow[PMHNB02145EB.ct_Col_Parts_OrderTotalSalesCountSum] = (double)printRow[PMHNB02145EB.ct_Col_Parts_OrderTotalSalesCountSum] + shipGdsPrimeListResultWork.Or_TotalSalesCount;

                            // �e�����v�Z
                            pureSalesMoneySum = shipGdsPrimeListResultWork.St_SalesMoney + shipGdsPrimeListResultWork.St_SalesRetGoodsPrice + shipGdsPrimeListResultWork.St_DiscountPrice
                                                     + shipGdsPrimeListResultWork.Or_SalesMoney + shipGdsPrimeListResultWork.Or_SalesRetGoodsPrice + shipGdsPrimeListResultWork.Or_DiscountPrice;

                            grossProfitSum = shipGdsPrimeListResultWork.St_GrossProfit + shipGdsPrimeListResultWork.Or_GrossProfit;

                            printRow[PMHNB02145EB.ct_Col_Parts1_GrossProfitRate] = this.GetRatio(grossProfitSum, pureSalesMoneySum); // �e���� 

                            // 1�s�Ɋ܂܂��D�Ǖi�� (2����ꍇ�͏㏑��)
                            printRow[PMHNB02145EB.ct_Col_PartsCount] = 1;
                            #endregion

                            #region �D�Ǖi���2
                            // �D�Ǖi���2�ݒ�
                            if (i + 1 < (Int32)dr[PMHNB02145EA.ct_Col_PartsCount])
                            {
                                goodsUnitData = ((List<GoodsUnitData>)(dr[PMHNB02145EA.ct_Col_GoodsUnitDataList]))[i + 1];

                                printRow[PMHNB02145EB.ct_Col_Parts2_GoodsNo] = goodsUnitData.GoodsNo; // �i��
                                printRow[PMHNB02145EB.ct_Col_Parts2_MakerCode] = goodsUnitData.GoodsMakerCd; // ���[�J�[�R�[�h
                                printRow[PMHNB02145EB.ct_Col_Parts2_BLGroupCode] = goodsUnitData.BLGroupCode; // BL�O���[�v�R�[�h
                                printRow[PMHNB02145EB.ct_Col_Parts2_SuplierCode] = goodsUnitData.SupplierCd; // �d����R�[�h

                                // �݌Ƀ��X�g��Index����
                                index = GetStockListIndex(dr[PMHNB02145EA.ct_Col_EnterpriseCode].ToString()
                                                         , dr[PMHNB02145EA.ct_Col_AddUpSecCode].ToString()
                                                         , goodsUnitData);

                                if (index != -1)
                                {
                                    printRow[PMHNB02145EB.ct_Col_Parts2_WarehouseShelfNo] = goodsUnitData.StockList[index].WarehouseShelfNo; // �I��
                                    printRow[PMHNB02145EB.ct_Col_Parts2_SupplierStock] = goodsUnitData.StockList[index].SupplierStock; // ���݌Ɂi�d���݌ɐ��j
                                }

                                // ���i���̃C���f�b�N�X���擾
                                index = GetGoodsPriceListIndex(goodsUnitData.GoodsPriceList);

                                if (index != -1)
                                {
                                    printRow[PMHNB02145EB.ct_Col_Parts2_GoodsPrice] = goodsUnitData.GoodsPriceList[index].ListPrice; // ���i
                                }

                                // �D�Ǖi�����W�v�f�[�^���2
                                //shipGdsPrimeListResultWork = (ShipGdsPrimeListResultWork)((ArrayList)dr[PMHNB02145EA.ct_Col_ShipGdsPrimeListResultList])[i]; // DEL 2008/12/09
                                shipGdsPrimeListResultWork = (ShipGdsPrimeListResultWork)((ArrayList)dr[PMHNB02145EA.ct_Col_ShipGdsPrimeListResultList])[i + 1]; // ADD 2008/12/12

                                printRow[PMHNB02145EB.ct_Col_Parts2_StockTotalSalesCount] = shipGdsPrimeListResultWork.St_TotalSalesCount;
                                printRow[PMHNB02145EB.ct_Col_Parts2_OrderTotalSalesCount] = shipGdsPrimeListResultWork.Or_TotalSalesCount;
                                printRow[PMHNB02145EB.ct_Col_Parts_StockTotalSalesCountSum] = (double)printRow[PMHNB02145EB.ct_Col_Parts_StockTotalSalesCountSum] + shipGdsPrimeListResultWork.St_TotalSalesCount;
                                printRow[PMHNB02145EB.ct_Col_Parts_OrderTotalSalesCountSum] = (double)printRow[PMHNB02145EB.ct_Col_Parts_OrderTotalSalesCountSum] + shipGdsPrimeListResultWork.Or_TotalSalesCount;

                                // �e�����v�Z
                                pureSalesMoneySum = shipGdsPrimeListResultWork.St_SalesMoney + shipGdsPrimeListResultWork.St_SalesRetGoodsPrice + shipGdsPrimeListResultWork.St_DiscountPrice
                                                         + shipGdsPrimeListResultWork.Or_SalesMoney + shipGdsPrimeListResultWork.Or_SalesRetGoodsPrice + shipGdsPrimeListResultWork.Or_DiscountPrice;

                                grossProfitSum = shipGdsPrimeListResultWork.St_GrossProfit + shipGdsPrimeListResultWork.Or_GrossProfit;

                                printRow[PMHNB02145EB.ct_Col_Parts2_GrossProfitRate] = this.GetRatio(grossProfitSum, pureSalesMoneySum); // �e���� 
                                
                                // 1�s�Ɋ܂܂��D�Ǖi��
                                printRow[PMHNB02145EB.ct_Col_PartsCount] = 2;
                            }
                            #endregion

                            this._printDt.Rows.Add(printRow);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ���擾����
        /// </summary>
        /// <param name="numerator">���q</param>
        /// <param name="denominator">����</param>
        private double GetRatio(Int64 num, Int64 den)
        {
            decimal workRate;

            decimal numerator = Convert.ToDecimal(num);
            decimal denominator = Convert.ToDecimal(den);

            if (denominator == 0)
            {
                workRate = 0.00M;
            }
            else
            {
                workRate = (numerator / denominator) * 100;
            }
            //if (workRate < 0) workRate = workRate * -1; // DEL 2009/01/15

            return Convert.ToDouble(workRate);
        }

        #endregion

        #region �e�X�g�f�[�^
        /// <summary>
        /// �e�X�g�f�[�^(�����i����)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int testProcPure(out object obj)
        {
            ArrayList paramlist = new ArrayList();

            ShipGdsPrimeListResultWork param = new ShipGdsPrimeListResultWork();

            param.EnterpriseCode = "0101150842020000"; // ��ƃR�[�h
            param.AddUpSecCode = "01    "; // �v�㋒�_�R�[�h
            param.SectionGuideSnm = "���_1"; // ���_�K�C�h����
            param.GoodsMakerCd = 1; // ���[�J�[�R�[�h
            param.GoodsNo = "90915-10003"; // ���i�ԍ�
            param.St_SalesTimes = 10000; // �����(�݌�)
            param.St_TotalSalesCount = 10000; // ���㐔�v(�݌�)
            param.St_SalesMoney = 10000; // ������z(�݌�)
            param.St_SalesRetGoodsPrice = 10000; // �ԕi�z(�݌�)
            param.St_DiscountPrice = 10000; // �l�����z(�݌�)
            param.St_GrossProfit = 10000; // �e�����z(�݌�)
            param.Or_SalesTimes = 10000; // �����(���)
            param.Or_TotalSalesCount = 10000; // ���㐔�v(���)
            param.Or_SalesMoney = 10000; // ������z(���)
            param.Or_SalesRetGoodsPrice = 10000; // �ԕi�z(���)
            param.Or_DiscountPrice = 10000; // �l�����z(���)
            param.Or_GrossProfit = 10000; // �e�����z(���)

            paramlist.Add(param);

            obj = (object)paramlist;

            return 0;
        }


        /// <summary>
        /// �e�X�g�f�[�^(���i�}�X�^����)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int testProcGoods(out List<GoodsUnitData> goodsUnitDataList)
        {
            goodsUnitDataList = new List<GoodsUnitData>();

            GoodsUnitData goods1 = new GoodsUnitData();

            goods1.EnterpriseCode = "0101150842020000"; // ��ƃR�[�h
            goods1.SectionCode = "01    "; // �v�㋒�_�R�[�h
            goods1.GoodsMakerCd = 2; // ���[�J�[�R�[�h
            goods1.GoodsNo = "test2"; // ���i�ԍ�
            goods1.SupplierCd = 2;

            goods1.StockList = new List<Stock>();
            goods1.GoodsPriceList = new List<GoodsPrice>();

            goodsUnitDataList.Add(goods1);

            GoodsUnitData goods2 = new GoodsUnitData();

            goods2.EnterpriseCode = "0101150842020000"; // ��ƃR�[�h
            goods2.SectionCode = "01    "; // �v�㋒�_�R�[�h
            goods2.GoodsMakerCd = 3; // ���[�J�[�R�[�h
            goods2.GoodsNo = "test3"; // ���i�ԍ�
            goods2.SupplierCd = 3;

            goods2.StockList = new List<Stock>();
            goods2.GoodsPriceList = new List<GoodsPrice>();

            goodsUnitDataList.Add(goods2);

            GoodsUnitData goods3 = new GoodsUnitData();

            goods3.EnterpriseCode = "0101150842020000"; // ��ƃR�[�h
            goods3.SectionCode = "01    "; // �v�㋒�_�R�[�h
            goods3.GoodsMakerCd = 4; // ���[�J�[�R�[�h
            goods3.GoodsNo = "test4"; // ���i�ԍ�
            goods3.SupplierCd = 4;

            goods3.StockList = new List<Stock>();
            goods3.GoodsPriceList = new List<GoodsPrice>();

            goodsUnitDataList.Add(goods3); 

            return 0;
        }

        /// <summary>
        /// �e�X�g�f�[�^(�D�Ǖi����)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int testProcParts(out object obj)
        {
            ArrayList paramlist = new ArrayList();

            ShipGdsPrimeListResultWork param = new ShipGdsPrimeListResultWork();

            param.EnterpriseCode = "0101150842020000"; // ��ƃR�[�h
            param.AddUpSecCode = "01    "; // �v�㋒�_�R�[�h
            param.SectionGuideSnm = "���_1"; // ���_�K�C�h����
            param.GoodsMakerCd = 2; // ���[�J�[�R�[�h
            param.GoodsNo = "test1"; // ���i�ԍ�
            param.St_SalesTimes = 20000; // �����(�݌�)
            param.St_TotalSalesCount = 20000; // ���㐔�v(�݌�)
            param.St_SalesMoney = 20000; // ������z(�݌�)
            param.St_SalesRetGoodsPrice = 20000; // �ԕi�z(�݌�)
            param.St_DiscountPrice = 20000; // �l�����z(�݌�)
            param.St_GrossProfit = 20000; // �e�����z(�݌�)
            param.Or_SalesTimes = 20000; // �����(���)
            param.Or_TotalSalesCount = 20000; // ���㐔�v(���)
            param.Or_SalesMoney = 20000; // ������z(���)
            param.Or_SalesRetGoodsPrice = 20000; // �ԕi�z(���)
            param.Or_DiscountPrice = 20000; // �l�����z(���)
            param.Or_GrossProfit = 20000; // �e�����z(���)

            paramlist.Add(param);

            obj = (object)paramlist;

            return 0;
        }
        #endregion
    }
}
