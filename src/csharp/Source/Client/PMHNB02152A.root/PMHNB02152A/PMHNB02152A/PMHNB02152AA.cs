using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �o�׏��i�D�ǑΉ��\2�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : �o�׏��i�D�ǑΉ��\2�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer   : 30452 ��� �r��</br>
    /// <br>Date         : 2008.11.25</br>
    /// <br>Update Note  : 2008.12.09 30452 ��� �r��</br>
    /// <br>              �E�����i�������ꍇ�����v�l���Z�b�g����悤�C���B(�t�B���^�����p)</br>
    /// <br>Update Note  : 2009.01.13 30452 ��� �r��</br>
    /// <br>              �E��Q�Ή�9687�i�D�Ǖi��񌟍����A���i�A���f�[�^�s�����ݒ菈����ǉ��j</br>
    /// <br>Update Note  : 2009.01.13 30452 ��� �r��</br>
    /// <br>              �E��Q�Ή�9544�i�����[�g��苒�_���X�g�ɂȂ����_�R�[�h���Ԃ�ꍇ�A</br>
    /// <br>              �@����ΏۂƂ���悤�C���B�擾�o���Ȃ����ڂ͋󔒂ɂ���B�j</br>
    /// <br>Update Note  : 2009.01.15 30452 ��� �r��</br>
    /// <br>              �E��Q�Ή�10098�i�݌Ƀ��X�gindex�擾���A���_�R�[�h�̏������폜�j</br>
    /// <br>Update Note  : 2009.02.13 30452 ��� �r��</br>
    /// <br>              �E��Q�Ή�11281�i���i�}�X�^�ɑ��݂��Ȃ��ꍇ���󎚑ΏۂƂ���悤�C���j</br>
    /// <br>Update Note  : 2009.02.17 30452 ��� �r��</br>
    /// <br>              �E��Q�Ή�11531�i���x�A�b�v�Ή��j</br>
    /// <br>Update Note  : 2009/02/27 30452 ��� �r��</br>
    /// <br>              �E��Q�Ή�12036�i�O���[�v�R�[�h�̓����[�g���o���ʂ��擾����悤�C���j</br>
    /// <br>Update Note  : 2014/12/30 ������</br>
    /// <br>�Ǘ��ԍ�     : 11070263-00</br>
    /// <br>             :�E�����Y�ƗlSeiken�i�ԕύX</br>
    /// <br>Update Note  : 2015/03/05 ����</br>
    /// <br>�Ǘ��ԍ�     : 11070263-00</br>
    /// <br>             :�E�����Y�ƗlSeiken�i�ԕύX �V�X�e����Q�̑Ή�(�i�ԕ\��)</br>
    /// <br>Update Note  : 2015/04/02 ����</br>
    /// <br>�Ǘ��ԍ�     : 11070263-00</br>
    /// <br>             :�E�����Y�ƗlSeiken�i�ԕύX �V�X�e����Q�̑Ή�(�d����̕⑫�̔��f)</br>
    /// <br>Update Note  : 2015/04/10 ���V��</br>
    /// <br>�Ǘ��ԍ�     : 11070263-00</br>
    /// <br>             :�u�o�͋敪�v���L���ɂȂ��Ă���Ή�</br>
    /// <br>Update Note  : 2015/04/13 ���V��</br>
    /// <br>�Ǘ��ԍ�     : 11070263-00</br>
    /// <br>             : Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�</br>
    /// </remarks>
    public class ShipGdsPrimeListAsc2
    {
        #region �� �R���X�g���N�^
		/// <summary>
        /// �o�׏��i�D�ǑΉ��\2�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �o�׏��i�D�ǑΉ��\2�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.25</br>
		/// </remarks>
		public ShipGdsPrimeListAsc2()
		{
            this._iShipGdsPrimeListResultWorkDB = (IShipGdsPrimeListResultWorkDB)MediationShipGdsPrimeListResultWorkDB.GetShipGdsPrimeListResultWorkDB();

            string enterpriseCode = LoginInfoAcquisition.EnterpriseCode.TrimEnd(); // ADD 2009/02/17
            string loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd(); // ADD 2009/02/17
            string msg;

            this._goodsAcs = new GoodsAcs(); // ���i�}�X�^
            this._goodsAcs.SearchInitial(enterpriseCode, loginSectionCode, out msg); // ADD 2009/02/17
            //this._joinPartsUAcs = new JoinPartsUAcs(); // �����}�X�^ // DEL 2009/02/17
		}

		/// <summary>
        /// �o�׏��i�D�ǑΉ��\2�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �o�׏��i�D�ǑΉ��\2�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008.11.25</br>
		/// </remarks>
        static ShipGdsPrimeListAsc2()
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
        //private JoinPartsUAcs _joinPartsUAcs; // �����}�X�^ // DEL 2009/02/17
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
        /// <br>Date         : 2008.11.25</br>
        /// </remarks>
        public int SearchMain(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn2, out string errMsg)
        {
            return this.SearchProc(shipGdsPrimeListCndtn2, out errMsg);
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
        private int SearchProc(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn2, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            // ���������擾(�����[�g�����A���i�}�X�^����)
            status = this.SearchMainInfo(shipGdsPrimeListCndtn2, ref errMsg);
            if (this._shipGdsPrimeListDt.Rows.Count == 0)
            {
                // ��ʎw��̏��i0���̏ꍇ�G���[�B
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // ��������擾(�����[�g�����A���i�}�X�^����)
            this.SearchSubInfo(shipGdsPrimeListCndtn2, ref errMsg);

            // ���[�󎚗p�e�[�u���쐬
            this.MakePrintTable(shipGdsPrimeListCndtn2);
            if (this._printDt.Rows.Count == 0)
            {
                // �󎚑Ώ�0�s�̏ꍇ�G���[�B
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // DataView�쐬
            this._printDv = new DataView(this._printDt, this.GetFilterString(shipGdsPrimeListCndtn2), this.GetSortString(), DataViewRowState.CurrentRows);

            if (this._printDv.Count == 0)
            {
                // �󎚑Ώ�0�s�̏ꍇ�G���[�B
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

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
        /// <br>Date         : 2008.11.25</br>
        /// </remarks>
        private int SearchMainInfo(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn2, ref string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMHNB02155EA.CreateDataTable(ref this._shipGdsPrimeListDt);

                ShipGdsPrimeListCndtnWork shipGdsPrimeListCndtnWork = new ShipGdsPrimeListCndtnWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.DevListCndtn(shipGdsPrimeListCndtn2, out shipGdsPrimeListCndtnWork, ref errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retWorkList = null;

                status = this._iShipGdsPrimeListResultWorkDB.Search(out retWorkList, shipGdsPrimeListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                // �e�X�g�p
                //status = this.testProcMain(out retWorkList);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DevListData(shipGdsPrimeListCndtn2, (ArrayList)retWorkList, ref errMsg);
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
        /// <br>Date         : 2008.11.25</br>
        /// <br>Update Note  : 2014/12/30 ������</br>
        /// <br>�Ǘ��ԍ�     : 11070263-00</br>
        /// <br>             :�E�����Y�ƗlSeiken�i�ԕύX</br>
        /// </remarks>
        private int DevListCndtn(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn, out ShipGdsPrimeListCndtnWork shipGdsPrimeListCndtnWork, ref string errMsg)
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

                if (shipGdsPrimeListCndtn.PrintType == ShipGdsPrimeListCndtn2.PrintTypeState.Month)
                {
                    shipGdsPrimeListCndtnWork.St_AddUpYearMonth = shipGdsPrimeListCndtn.St_AddUpYearMonth; // �J�n�Ώ۔N��
                    shipGdsPrimeListCndtnWork.Ed_AddUpYearMonth = shipGdsPrimeListCndtn.Ed_AddUpYearMonth; // �I���Ώ۔N��
                }
                else
                {
                    shipGdsPrimeListCndtnWork.St_AddUpYearMonth = shipGdsPrimeListCndtn.St_AnnualAddUpYearMonth; // �J�n�Ώ۔N��
                    shipGdsPrimeListCndtnWork.Ed_AddUpYearMonth = shipGdsPrimeListCndtn.Ed_AnnualAddUpYearMonth; // �I���Ώ۔N��
                }

                // �J�n���[�J�[�R�[�h
                if (shipGdsPrimeListCndtn.St_GoodsMakerCd == 0)
                {
                    if (shipGdsPrimeListCndtn.ExtractDiv == ShipGdsPrimeListCndtn2.ExtractDivState.Pure)
                    {
                        shipGdsPrimeListCndtnWork.St_GoodsMakerCd = 0;
                    }
                    else
                    {
                        shipGdsPrimeListCndtnWork.St_GoodsMakerCd = 100;
                    }
                }
                else
                {
                    shipGdsPrimeListCndtnWork.St_GoodsMakerCd = shipGdsPrimeListCndtn.St_GoodsMakerCd;
                }

                // �I�����[�J�[�R�[�h
                if (shipGdsPrimeListCndtn.Ed_GoodsMakerCd == 0)
                {
                    if (shipGdsPrimeListCndtn.ExtractDiv == ShipGdsPrimeListCndtn2.ExtractDivState.Pure)
                    {
                        shipGdsPrimeListCndtnWork.Ed_GoodsMakerCd = 99;
                    }
                    else
                    {
                        shipGdsPrimeListCndtnWork.Ed_GoodsMakerCd = 9999;
                    }
                }
                else
                {
                    shipGdsPrimeListCndtnWork.Ed_GoodsMakerCd = shipGdsPrimeListCndtn.Ed_GoodsMakerCd;
                }

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

                shipGdsPrimeListCndtnWork.ShipCount = shipGdsPrimeListCndtn.ShipCount; // �o�׉�

                //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                shipGdsPrimeListCndtnWork.GoodsNoTtlDiv = (int)shipGdsPrimeListCndtn.GoodsNoTtlDiv; // �i�ԏW�v�敪
                if (shipGdsPrimeListCndtnWork.GoodsNoTtlDiv == 1)
                {
                    shipGdsPrimeListCndtnWork.GoodsNoShowDiv = (int)shipGdsPrimeListCndtn.GoodsNoShowDiv; // �i�ԕ\���敪
                }
                //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
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
        /// <br>Date         : 2008.11.25</br>
        /// <br>Update Note  : 2014/12/30 ������</br>
        /// <br>�Ǘ��ԍ�     : 11070263-00</br>
        /// <br>             :�E�����Y�ƗlSeiken�i�ԕύX</br>
        /// <br>Update Note  : 2015/03/05 ����</br>
        /// <br>�Ǘ��ԍ�     : 11070263-00</br>
        /// <br>             :�E�����Y�ƗlSeiken�i�ԕύX �V�X�e����Q�Ή�(�i�ԕ\��)</br>
        /// <br>Update Note  : 2015/04/10 ���V��</br>
        /// <br>�Ǘ��ԍ�     : 11070263-00</br>
        /// <br>             :�u�o�͋敪�v���L���ɂȂ��Ă���Ή�</br>
        /// </remarks>
        private void DevListData(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn, ArrayList resultWork, ref string errMsg)
        {
            // �����[�g���o���ʂ������[�g���o���ʗpDataTable(PMHNB02155EA)�ɓW�J
            DataRow dr;

            GoodsCndtn goodsCndtn = new GoodsCndtn(); // ADD 2009/02/17
            bool stockFlag = false;  // ADD 2015/04/10 ���V�� �u�o�͋敪�v���L���ɂȂ��Ă���Ή�
            foreach (ShipGdsPrimeListResultWork shipGdsPrimeListResultWork in resultWork)
            {
                stockFlag = false;  // ADD 2015/04/10 ���V�� �u�o�͋敪�v���L���ɂȂ��Ă���Ή�
                dr = this._shipGdsPrimeListDt.NewRow();

                dr[PMHNB02155EA.ct_Col_EnterpriseCode] = shipGdsPrimeListResultWork.EnterpriseCode; // ��ƃR�[�h
                dr[PMHNB02155EA.ct_Col_AddUpSecCode] = shipGdsPrimeListResultWork.AddUpSecCode; // �v�㋒�_�R�[�h
                dr[PMHNB02155EA.ct_Col_SectionGuideSnm] = shipGdsPrimeListResultWork.SectionGuideSnm; // ���_�K�C�h����
                dr[PMHNB02155EA.ct_Col_GoodsMakerCd] = shipGdsPrimeListResultWork.GoodsMakerCd; // ���[�J�[�R�[�h
                //dr[PMHNB02155EA.ct_Col_GoodsNo] = shipGdsPrimeListResultWork.GoodsNo; // ���i�ԍ�  // DEL  2014/12/30 ������ FOR Redmine#44209����
                dr[PMHNB02155EA.ct_Col_St_SalesTimes] = shipGdsPrimeListResultWork.St_SalesTimes; // �����(�݌�)
                dr[PMHNB02155EA.ct_Col_St_TotalSalesCount] = shipGdsPrimeListResultWork.St_TotalSalesCount; // ���㐔�v(�݌�)
                dr[PMHNB02155EA.ct_Col_St_SalesMoney] = shipGdsPrimeListResultWork.St_SalesMoney; // ������z(�݌�)
                dr[PMHNB02155EA.ct_Col_St_SalesRetGoodsPrice] = shipGdsPrimeListResultWork.St_SalesRetGoodsPrice; // �ԕi�z(�݌�)
                dr[PMHNB02155EA.ct_Col_St_DiscountPrice] = shipGdsPrimeListResultWork.St_DiscountPrice; // �l�����z(�݌�)
                dr[PMHNB02155EA.ct_Col_St_GrossProfit] = shipGdsPrimeListResultWork.St_GrossProfit; // �e�����z(�݌�)
                dr[PMHNB02155EA.ct_Col_Or_SalesTimes] = shipGdsPrimeListResultWork.Or_SalesTimes; // �����(���)
                dr[PMHNB02155EA.ct_Col_Or_TotalSalesCount] = shipGdsPrimeListResultWork.Or_TotalSalesCount; // ���㐔�v(���)
                dr[PMHNB02155EA.ct_Col_Or_SalesMoney] = shipGdsPrimeListResultWork.Or_SalesMoney; // ������z(���)
                dr[PMHNB02155EA.ct_Col_Or_SalesRetGoodsPrice] = shipGdsPrimeListResultWork.Or_SalesRetGoodsPrice; // �ԕi�z(���)
                dr[PMHNB02155EA.ct_Col_Or_DiscountPrice] = shipGdsPrimeListResultWork.Or_DiscountPrice; // �l�����z(���)
                dr[PMHNB02155EA.ct_Col_Or_GrossProfit] = shipGdsPrimeListResultWork.Or_GrossProfit; // �e�����z(���)
                dr[PMHNB02155EA.ct_Col_BLGroupCode] = shipGdsPrimeListResultWork.BLGroupCode; // �O���[�v�R�[�h // ADD 2009/02/13

                List<GoodsUnitData> goodsUnitDataList;
                //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                // �i�ԏW�v�敪�́u���Z�v���i�ԕ\���敪���u���i�ԁv�ꍇ
                int status;
                string disGoodsNo = string.Empty; //ADD 2015/03/05 ���� FOR �����Y�ƗlSeiken�i�ԕύX�̃V�X�e����Q�Ή�(�i�Ԃ̕\��)
                if ((shipGdsPrimeListCndtn.GoodsNoTtlDiv == ShipGdsPrimeListCndtn2.GoodsNoTtlDivState.Total) &&
                    (shipGdsPrimeListCndtn.GoodsNoShowDiv == ShipGdsPrimeListCndtn2.GoodsNoShowDivState.Old))
                {
                    goodsCndtn.EnterpriseCode = shipGdsPrimeListResultWork.EnterpriseCode;
                    goodsCndtn.GoodsNo = shipGdsPrimeListResultWork.OldGoodsNo;
                    // ���i�ԕ\���̏ꍇ�A���i�Ԃ��ꎞ�ޔ����܂��B
                    disGoodsNo = shipGdsPrimeListResultWork.OldGoodsNo;//ADD 2015/03/05 ���� FOR �����Y�ƗlSeiken�i�ԕύX(�i�Ԃ̕\��)
                    goodsCndtn.GoodsMakerCd = shipGdsPrimeListResultWork.GoodsMakerCd;
                    // �i�ԕ\���敪���u���i�ԁv�ꍇ�A���i�}�X�^�����B
                    //status = this.GetGoodsUnitDataList(shipGdsPrimeListResultWork, goodsCndtn, out goodsUnitDataList, out errMsg); // DEL 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�
                    //----- ADD 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�------>>>>>
                    goodsCndtn.IsSettingSupplier = 1;
                    goodsCndtn.IsSettingVariousMst = 1;
                    goodsCndtn.GoodsKindCode = 9;
                    this._goodsAcs.Search(goodsCndtn, out goodsUnitDataList, out errMsg);
                    //----- ADD 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�------<<<<<
                    if (goodsUnitDataList == null || goodsUnitDataList.Count == 0)
                    {
                        //  �����i�}�X�^�����݂��Ȃ��ꍇ�A�V�i�Ԃ̏��i�}�X�^�����B
                        goodsCndtn.GoodsNo = shipGdsPrimeListResultWork.GoodsNo;
                        //status = this.GetGoodsUnitDataList(shipGdsPrimeListResultWork, goodsCndtn, out goodsUnitDataList, out errMsg); // DEL 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�            
                        //----- ADD 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�------>>>>>
                        this._goodsAcs.Search(goodsCndtn, out goodsUnitDataList, out errMsg);
                        if (goodsUnitDataList == null || goodsUnitDataList.Count == 0)
                        {
                            // �V���i���Ȃ����߁A�񋟕��f�[�^���擾���܂��B
                            status = this.GetGoodsUnitDataList(shipGdsPrimeListResultWork, goodsCndtn, out goodsUnitDataList, out errMsg);
                        }
                        //----- ADD 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�------<<<<<
                    }
                    else
                    {
                        // �������Ȃ�
                    }
                }
                else if ((shipGdsPrimeListCndtn.GoodsNoTtlDiv == ShipGdsPrimeListCndtn2.GoodsNoTtlDivState.Total) &&
                    (shipGdsPrimeListCndtn.GoodsNoShowDiv == ShipGdsPrimeListCndtn2.GoodsNoShowDivState.New))
                {
                    goodsCndtn.EnterpriseCode = shipGdsPrimeListResultWork.EnterpriseCode;
                    goodsCndtn.GoodsNo = shipGdsPrimeListResultWork.GoodsNo;
                    // �V�i�ԕ\���̏ꍇ�A�V�i�Ԃ��ꎞ�ޔ����܂��B
                    disGoodsNo = shipGdsPrimeListResultWork.GoodsNo;//ADD 2015/03/05 ���� FOR �����Y�ƗlSeiken�i�ԕύX(�i�Ԃ̕\��)
                    goodsCndtn.GoodsMakerCd = shipGdsPrimeListResultWork.GoodsMakerCd;
                    // �i�ԕ\���敪���u�V�i�ԁv�ꍇ�A���i�}�X�^�����B
                    //status = this.GetGoodsUnitDataList(shipGdsPrimeListResultWork, goodsCndtn, out goodsUnitDataList, out errMsg); // DEL 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�
                    //----- ADD 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�------>>>>>
                    goodsCndtn.IsSettingSupplier = 1;
                    goodsCndtn.IsSettingVariousMst = 1;
                    goodsCndtn.GoodsKindCode = 9;
                    this._goodsAcs.Search(goodsCndtn, out goodsUnitDataList, out errMsg);
                    //----- ADD 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�------<<<<<
                    if (goodsUnitDataList == null || goodsUnitDataList.Count == 0)
                    {
                        //  �V���i�}�X�^�����݂��Ȃ��ꍇ�A���i�Ԃ̏��i�}�X�^�����B
                        goodsCndtn.GoodsNo = shipGdsPrimeListResultWork.OldGoodsNo;
                        //status = this.GetGoodsUnitDataList(shipGdsPrimeListResultWork, goodsCndtn, out goodsUnitDataList, out errMsg); // DEL 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�            
                        //----- ADD 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�------>>>>>
                        this._goodsAcs.Search(goodsCndtn, out goodsUnitDataList, out errMsg);
                        if (goodsUnitDataList == null || goodsUnitDataList.Count == 0)
                        {
                            // �V���i���Ȃ����߁A�񋟕��f�[�^���擾���܂��B
                            goodsCndtn.GoodsNo = shipGdsPrimeListResultWork.GoodsNo;
                            status = this.GetGoodsUnitDataList(shipGdsPrimeListResultWork, goodsCndtn, out goodsUnitDataList, out errMsg);
                        }
                        //----- ADD 2015/04/13 ���V�� Redmine#45436 NO.74 �i�ԏW�v�敪�u���Z�v�i�ԕ\���敪�u���i�ԁv�ŏo�͂���ƁA�I�Ԃ��擾����Ȃ��Ή�------<<<<<
                    }
                    else
                    {
                        // �������Ȃ�
                    }
                }
                else
                {
                    goodsCndtn.EnterpriseCode = shipGdsPrimeListResultWork.EnterpriseCode;
                    goodsCndtn.GoodsNo = shipGdsPrimeListResultWork.GoodsNo;
                    goodsCndtn.GoodsMakerCd = shipGdsPrimeListResultWork.GoodsMakerCd;
                    // ���i���擾
                    status = this.GetGoodsUnitDataList(shipGdsPrimeListResultWork, goodsCndtn, out goodsUnitDataList, out errMsg);
                }
                //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<
                //------ DEL START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                // ���i���擾
                //int status = this.GetGoodsUnitDataList(shipGdsPrimeListResultWork, goodsCndtn, out goodsUnitDataList, out errMsg);
                //------ DEL START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>

                // �e�X�g�p
                //int status = this.testProcMainGoods(out goodsUnitDataList);

                // --- DEL 2009/02/13 -------------------------------->>>>>
                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                //    || goodsUnitDataList.Count == 0)
                //{
                //    // 0���̏ꍇ�A�󎚑Ώۂɂ��Ȃ�
                //    continue;
                //}
                // --- DEL 2009/02/13 --------------------------------<<<<<

                //if (goodsUnitDataList.Count != 0)                                 //DEL 2014/12/30 ������ FOR Redmine#44209����
                if (goodsUnitDataList != null && goodsUnitDataList.Count != 0)      //ADD 2014/12/30 ������ FOR Redmine#44209����
                {
                    GoodsUnitData goodsUnitData = goodsUnitDataList[0];
                    // ADD 2015/04/10 ���V�� �u�o�͋敪�v���L���ɂȂ��Ă���Ή� ----->>>>>
                    if (goodsUnitData.StockList != null && goodsUnitData.StockList.Count > 0)
                    {
                        stockFlag = true;
                    }
                    // ADD 2015/04/10 ���V�� �u�o�͋敪�v���L���ɂȂ��Ă���Ή� -----<<<<<

                    //dr[PMHNB02155EA.ct_Col_GoodsNo] = goodsUnitData.GoodsNo;          //ADD 2014/12/30 ������ FOR Redmine#44209���� //DEL 2015/03/05 ���� �����Y�ƗlSeiken�i�ԕύX(�i�Ԃ̕\��)
                    //------ ADD START 2015/03/05 ���� �����Y�ƗlSeiken�i�ԕύX(�i�Ԃ̕\��) ------>>>>>
                    // �i�ԏW�v�敪�́u���Z�v
                    if (shipGdsPrimeListCndtn.GoodsNoTtlDiv == ShipGdsPrimeListCndtn2.GoodsNoTtlDivState.Total)
                    {
                        // �ꎞ�ޔ������i�Ԃ����i�}�X�^�ɐ؂�ւ����܂��B
                        dr[PMHNB02155EA.ct_Col_GoodsNo] = disGoodsNo;�@// ���i�ԍ��\���p
                        dr[PMHNB02155EA.ct_Col_OldGoodsNo] = goodsUnitData.GoodsNo; // ���i�ԍ������p
                    }
                    else
                    {
                        // �i�ԏW�v�敪�́u�ʁX�v�̏ꍇ
                        dr[PMHNB02155EA.ct_Col_GoodsNo] = goodsUnitData.GoodsNo;// ���i�ԍ��\���p
                        dr[PMHNB02155EA.ct_Col_OldGoodsNo] = goodsUnitData.GoodsNo; // ���i�ԍ������p
                    }
                    //------ ADD END 2015/03/05 ���� FOR �����Y�ƗlSeiken�i�ԕύX(�i�Ԃ̕\��) ------<<<<<
                    //dr[PMHNB02155EA.ct_Col_BLGroupCode] = goodsUnitData.BLGroupCode; // BL�O���[�v�R�[�h // DEL 2009/02/27
                    dr[PMHNB02155EA.ct_Col_GoodsName] = goodsUnitData.GoodsNameKana; // �i��
                    dr[PMHNB02155EA.ct_Col_GoodsLGroup] = goodsUnitData.GoodsLGroup; // ���i�啪��
                    dr[PMHNB02155EA.ct_Col_GoodsMGroup] = goodsUnitData.GoodsMGroup; // ���i������
                    if (shipGdsPrimeListResultWork.BLGroupCode == 0) // ADD 2009/02/27
                    {
                        dr[PMHNB02155EA.ct_Col_BLGroupCode] = goodsUnitData.BLGroupCode; // �O���[�v�R�[�h
                    }

                    // �݌Ƀ��X�g��Index����
                    //int index = GetStockListIndex(shipGdsPrimeListResultWork, goodsUnitData); //DEL 2015/03/05 ���� �����Y�ƗlSeiken�i�ԕύX(�i�Ԃ̕\��)
                    //------ ADD START 2015/03/05 ���� �����Y�ƗlSeiken�i�ԕύX(�i�Ԃ̕\��) ------>>>>>
                    int index = GetStockListIndex(dr[PMHNB02155EA.ct_Col_EnterpriseCode].ToString()
                                                         , dr[PMHNB02155EA.ct_Col_AddUpSecCode].ToString()
                                                         , goodsUnitData);
                    //------ ADD END 2015/03/05 ���� FOR �����Y�ƗlSeiken�i�ԕύX(�i�Ԃ̕\��) ------<<<<<

                    if (index != -1)
                    {
                        dr[PMHNB02155EA.ct_Col_WarehouseShelfNo] = goodsUnitData.StockList[index].WarehouseShelfNo; // �I��
                    }
                    else
                    {
                        // �݌Ƀ��X�g��0���̏ꍇ�A�\���͍s���B�i�I�Ԃ�string.empty�j
                    }
                }
                //------ ADD START 2015/03/05 ���� �����Y�ƗlSeiken�i�ԕύX(�i�Ԃ̕\��) ------>>>>>
                // ���i��񂪑��݂��Ȃ��ꍇ�A���т̕i�Ԃ�\�����܂��B
                else
                {
                    // �i�ԏW�v�敪�́u���Z�v
                    if (shipGdsPrimeListCndtn.GoodsNoTtlDiv == ShipGdsPrimeListCndtn2.GoodsNoTtlDivState.Total)
                    {
                        // �ꎞ�ޔ������i�Ԃ����i�}�X�^�ɐ؂�ւ����܂��B
                        dr[PMHNB02155EA.ct_Col_GoodsNo] = disGoodsNo;�@// ���i�ԍ��\���p
                        dr[PMHNB02155EA.ct_Col_OldGoodsNo] = disGoodsNo; // ���i�ԍ������p
                    }
                    else
                    {
                        // �i�ԏW�v�敪�́u�ʁX�v�̏ꍇ
                        dr[PMHNB02155EA.ct_Col_GoodsNo] = shipGdsPrimeListResultWork.GoodsNo;// ���i�ԍ��\���p
                        dr[PMHNB02155EA.ct_Col_OldGoodsNo] = shipGdsPrimeListResultWork.GoodsNo; // ���i�ԍ������p
                    }
                }
                //------ ADD END 2015/03/05 ���� FOR �����Y�ƗlSeiken�i�ԕύX(�i�Ԃ̕\��) ------<<<<<

                dr[PMHNB02155EA.ct_Col_StockYNFlag] = stockFlag;// ADD 2015/04/10 ���V�� �u�o�͋敪�v���L���ɂȂ��Ă���Ή�
                this._shipGdsPrimeListDt.Rows.Add(dr);
            }
        }

        /// <summary>
        /// ���i���擾����
        /// </summary>
        /// <param name="shipGdsPrimeListResultWork"></param>
        /// <param name="goodsUnitDataList"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <br>Update Note  : 2014/12/30 ������</br>
        /// <br>�Ǘ��ԍ�     : 11070263-00</br>
        /// <br>             :�E�����Y�ƗlSeiken�i�ԕύX</br>
        private int GetGoodsUnitDataList(ShipGdsPrimeListResultWork shipGdsPrimeListResultWork, GoodsCndtn goodsCndtn,
            out List<GoodsUnitData> goodsUnitDataList, out string errMsg)
        {
            //GoodsCndtn goodsCndtn = new GoodsCndtn(); // DEL 2009/02/17
            //------ DEL START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
            //goodsCndtn.EnterpriseCode = shipGdsPrimeListResultWork.EnterpriseCode;
            //goodsCndtn.GoodsNo = shipGdsPrimeListResultWork.GoodsNo;
            //goodsCndtn.GoodsMakerCd = shipGdsPrimeListResultWork.GoodsMakerCd;
            //------ DEL START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>

            goodsCndtn.IsSettingSupplier = 1; // ADD 2009/02/17
            goodsCndtn.IsSettingVariousMst = 1; // ADD 2009/02/17

            int status = _goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtn, false, out goodsUnitDataList, out errMsg);

            return status;
        }

        /// <summary>
        /// �����ɍ��v����݌Ƀ��X�g��index���擾����
        /// </summary>
        /// <returns></returns>
        private int GetStockListIndex(ShipGdsPrimeListResultWork shipGdsPrimeListResultWork, GoodsUnitData goodsUnitData)
        {
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

        // <summary>
        /// ��������擾
        /// </summary>
        /// <param name="salesRsltListCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       �@: ������̏����擾����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.25</br>
        /// <br>Update Note  : 2014/12/30 ������</br>
        /// <br>�Ǘ��ԍ�     : 11070263-00</br>
        /// <br>             :�E�����Y�ƗlSeiken�i�ԕύX</br>
        /// <br>Update Note  : 2015/03/05 ����</br>
        /// <br>�Ǘ��ԍ�     : 11070263-00</br>
        /// <br>             :�E�����Y�ƗlSeiken�i�ԕύX �V�X�e����Q�Ή�(�i�ԕ\��)</br>
        /// <br>Update Note  : 2015/04/02 ����</br>
        /// <br>�Ǘ��ԍ�     : 11070263-00</br>
        /// <br>             :�E�����Y�ƗlSeiken�i�ԕύX �V�X�e����Q�̑Ή�(�d����̕⑫�̔��f)</br>
        /// <br>Update Note  : 2015/04/10 ���V��</br>
        /// <br>�Ǘ��ԍ�     : 11070263-00</br>
        /// <br>             :�u�o�͋敪�v���L���ɂȂ��Ă���Ή�</br>
        /// </remarks>
        private void SearchSubInfo(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn2, ref string errMsg)
        {
            GoodsCndtn goodsCndtn = new GoodsCndtn(); // ADD 2009/02/17
            ShipGdsPrmListCndtnPartnerWork shipGdsPrmListCndtnPartnerWork = new ShipGdsPrmListCndtnPartnerWork(); // ADD 2009/02/17
            bool stockFlag = false; // ADD 2015/04/10 ���V�� �u�o�͋敪�v���L���ɂȂ��Ă���Ή�

            // ������1�����ɏ���
            foreach (DataRow dr in this._shipGdsPrimeListDt.Rows)
            {
                stockFlag = false; // ADD 2015/04/10 ���V�� �u�o�͋敪�v���L���ɂȂ��Ă���Ή�
                // ���i���擾
                //GoodsCndtn goodsCndtn = new GoodsCndtn(); // DEL 2009/02/17

                goodsCndtn.EnterpriseCode = dr[PMHNB02155EA.ct_Col_EnterpriseCode].ToString();
                //goodsCndtn.GoodsNo = dr[PMHNB02155EA.ct_Col_GoodsNo].ToString(); //DEL 2015/03/05 ���� FOR �����Y�ƗlSeiken�i�ԕύX(�i�Ԃ̕\��)
                goodsCndtn.GoodsNo = dr[PMHNB02155EA.ct_Col_OldGoodsNo].ToString();//ADD 2015/03/05 ���� FOR �����Y�ƗlSeiken�i�ԕύX(�i�Ԃ̕\��)
                goodsCndtn.GoodsMakerCd = (int)dr[PMHNB02155EA.ct_Col_GoodsMakerCd];

                goodsCndtn.IsSettingSupplier = 1; // ADD 2009/02/17
                goodsCndtn.IsSettingVariousMst = 1; // ADD 2009/02/17
                
                PartsInfoDataSet partsInfoDataSet;
                List<GoodsUnitData> GoodsUnitDataList;
                string msg;

                if (shipGdsPrimeListCndtn2.ExtractDiv == ShipGdsPrimeListCndtn2.ExtractDivState.Pure)
                {
                    // �����i����D�Ǖi�̌����̏ꍇ�A���_�R�[�h�ƌ��������敪��ǉ�
                    goodsCndtn.SectionCode = dr[PMHNB02155EA.ct_Col_AddUpSecCode].ToString();
                    goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.Search;

                    // ���i�}�X�^����(�����i����D�Ǖi����)
                    this._goodsAcs.SearchPartsFromGoodsNoWholeWord(goodsCndtn, false, out partsInfoDataSet, out GoodsUnitDataList, out msg);

                    // �����q�f�[�^�݂̂���o��
                    this._goodsAcs.GetGoodsUnitDataListFromPartsInfoDataSet(partsInfoDataSet,
                        goodsCndtn.GoodsMakerCd, goodsCndtn.GoodsNo, GoodsAcs.GoodsKind.ChildJoin, out GoodsUnitDataList);

                    // �e�X�g�p
                    //this.testProcSubGoods(out GoodsUnitDataList);
                }
                else
                {
                    // ���i�}�X�^����(�D�Ǖi���珃���i����)
                    this._goodsAcs.SearchPartsForSrcParts(goodsCndtn, out partsInfoDataSet, out GoodsUnitDataList, out msg);

                    // �e�X�g�p
                    //this.testProcSubGoods(out GoodsUnitDataList);
                }

                // ���[�󎚑Ώی����i ��񃊃X�g
                List<GoodsUnitData> printGoodsUnitDataList = new List<GoodsUnitData>();
                ArrayList printShipGdsPrimeListResultList = new ArrayList();

                // ���i�ʔ��㌎���W�v�f�[�^���擾
                for (int i = 0; i < GoodsUnitDataList.Count; i++)
                {
                    GoodsUnitData goodsUnitData = GoodsUnitDataList[i];

                    //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                    int joinDispOrder = 0;
                    if (shipGdsPrimeListCndtn2.GoodsNoTtlDiv == ShipGdsPrimeListCndtn2.GoodsNoTtlDivState.Total)
                    {
                        joinDispOrder = goodsUnitData.JoinDispOrder; // �����\������
                    }
                    //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<

                    //ShipGdsPrmListCndtnPartnerWork shipGdsPrmListCndtnPartnerWork = new ShipGdsPrmListCndtnPartnerWork(); // DEL 2009/02/17

                    // ���o�����W�J  --------------------------------------------------------------
                    int status = this.DevPartnerListCndtn(shipGdsPrimeListCndtn2, dr[PMHNB02155EA.ct_Col_AddUpSecCode].ToString(), goodsUnitData,
                                                          ref shipGdsPrmListCndtnPartnerWork);

                    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        continue;
                    }

                    ArrayList shipGdsPrmListCndtnPartnerWorkList = new ArrayList();
                    shipGdsPrmListCndtnPartnerWorkList.Add(shipGdsPrmListCndtnPartnerWork);

                    object retWorkList = null;

                    // �����[�g����(������)
                    status = this._iShipGdsPrimeListResultWorkDB.SearchPartner(out retWorkList, shipGdsPrmListCndtnPartnerWorkList, 0, ConstantManagement.LogicalMode.GetData0);

                    // �e�X�g�p
                    //this.testProcSub(out retWorkList);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                        || ((ArrayList)retWorkList).Count == 0)
                    {
                        continue;
                    }

                    //------ DEL START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                    // �V�����i���m�肵����A���i�A���f�[�^���擾����B
                    //// --- ADD 2009/01/13 -------------------------------->>>>>
                    //if (shipGdsPrimeListCndtn2.ExtractDiv == ShipGdsPrimeListCndtn2.ExtractDivState.Pure)
                    //{
                    //    // ���i�A���f�[�^�s�����ݒ菈���ďo��
                    //    //this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData); // DEL 2009/02/17
                    //    this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData, 1); // ADD 2009/02/17
                    //}
                    //// --- ADD 2009/01/13 --------------------------------<<<<<
                    //------ DEL END 2014/12/30 ���� FOR Redmine#44209�����Y�ƗlSeiken�i�ԕύX ------<<<<<
                    string shipGoodsNo = string.Empty;
                    ArrayList resultList = retWorkList as ArrayList;
                    string tempGoodsNo = string.Empty; //ADD 2015/03/05 ���� FOR �����Y�ƗlSeiken�i�ԕύX�̃V�X�e����Q�Ή�(�i�Ԃ̕\��)
                    ShipGdsPrimeListResultWork shipGdsPrimeListResultWork = new ShipGdsPrimeListResultWork();
                    for (int j = 0; j < resultList.Count; j++)
                    {
                        shipGdsPrimeListResultWork = resultList[j] as ShipGdsPrimeListResultWork;
                    }
                    //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                    // �i�ԏW�v�敪�́u���Z�v���i�ԕ\���敪���u���i�ԁv�ꍇ
                    if ((shipGdsPrimeListCndtn2.GoodsNoTtlDiv == ShipGdsPrimeListCndtn2.GoodsNoTtlDivState.Total) &&
                        (shipGdsPrimeListCndtn2.GoodsNoShowDiv == ShipGdsPrimeListCndtn2.GoodsNoShowDivState.Old))
                    {
                        GoodsCndtn goodsCndtnChg = new GoodsCndtn();
                        List<GoodsUnitData> GoodsUnitDataListChg;
                        goodsCndtnChg.EnterpriseCode = shipGdsPrimeListCndtn2.EnterpriseCode;
                        //goodsCndtnChg.SectionCode = dr[PMHNB02155EA.ct_Col_AddUpSecCode].ToString();
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
                    else if ((shipGdsPrimeListCndtn2.GoodsNoTtlDiv == ShipGdsPrimeListCndtn2.GoodsNoTtlDivState.Total) &&
                        (shipGdsPrimeListCndtn2.GoodsNoShowDiv == ShipGdsPrimeListCndtn2.GoodsNoShowDivState.New))
                    {
                        GoodsCndtn goodsCndtnChg = new GoodsCndtn();
                        List<GoodsUnitData> GoodsUnitDataListChg;
                        goodsCndtnChg.EnterpriseCode = shipGdsPrimeListCndtn2.EnterpriseCode;
                        //goodsCndtnChg.SectionCode = dr[PMHNB02155EA.ct_Col_AddUpSecCode].ToString();
                        goodsCndtnChg.GoodsNo = shipGdsPrimeListResultWork.GoodsNo;
                        // �V�i�ԕ\���̏ꍇ�A�V�i�Ԃ��ꎞ�ޔ����܂��B
                        tempGoodsNo = shipGdsPrimeListResultWork.GoodsNo;//ADD 2015/03/05 ���� FOR �����Y�ƗlSeiken�i�ԕύX(�i�Ԃ̕\��)
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

                    if (shipGdsPrimeListCndtn2.GoodsNoTtlDiv == ShipGdsPrimeListCndtn2.GoodsNoTtlDivState.Total)
                    {
                        goodsUnitData.JoinDispOrder = joinDispOrder; // �����\������
                    }

                    //------ ADD START 2015/04/02 ���� �����Y�ƗlSeiken�i�ԕύX(�d����̕⑫�̔��f) ------>>>>>
                    if (shipGdsPrimeListCndtn2.ExtractDiv == ShipGdsPrimeListCndtn2.ExtractDivState.Pure)
                    {
                        //------ ADD END 2015/04/02 ���� �����Y�ƗlSeiken�i�ԕύX(�d����̕⑫�̔��f) ------<<<<<
                        // ���i�A���f�[�^�s�����ݒ菈���ďo��
                        this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData, 1);
                    }// ADD 2015/04/02 ���� �����Y�ƗlSeiken�i�ԕύX(�d����̕⑫�̔��f)
                    //------ ADD START 2015/03/05 ���� �����Y�ƗlSeiken�i�ԕύX(�i�Ԃ̕\��) ------>>>>>
                    // �i�ԏW�v�敪�́u���Z�v
                    if (shipGdsPrimeListCndtn2.GoodsNoTtlDiv == ShipGdsPrimeListCndtn2.GoodsNoTtlDivState.Total)
                    {
                        // �ꎞ�ޔ������i�Ԃ����i�}�X�^�ɐ؂�ւ����܂��B
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
                    //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<

                    // �����f�[�^�܂Ő���Ɏ擾�o�����ꍇ�̂݁A�󎚗p�f�[�^�ɕۑ�
                    // ADD 2015/04/10 ���V�� �u�o�͋敪�v���L���ɂȂ��Ă���Ή� ----->>>>>
                    // �݌ɕi�̔��f
                    if (goodsUnitData.StockList != null && goodsUnitData.StockList.Count > 0)
                    {
                        stockFlag = true;
                    }
                    // ADD 2015/04/10 ���V�� �u�o�͋敪�v���L���ɂȂ��Ă���Ή� -----<<<<<
                    printGoodsUnitDataList.Add(goodsUnitData);
                    printShipGdsPrimeListResultList.Add(((ArrayList)retWorkList)[0]);
                }

                // �����i����ۑ�
                // ADD 2015/04/10 ���V�� �u�o�͋敪�v���L���ɂȂ��Ă���Ή� ----->>>>>
                if (stockFlag == true)
                {
                    dr[PMHNB02155EA.ct_Col_StockYNFlag] = stockFlag;
                }
                // ADD 2015/04/10 ���V�� �u�o�͋敪�v���L���ɂȂ��Ă���Ή� -----<<<<<
                dr[PMHNB02155EA.ct_Col_PartsCount] = printGoodsUnitDataList.Count;
                dr[PMHNB02155EA.ct_Col_GoodsUnitDataList] = printGoodsUnitDataList;
                dr[PMHNB02155EA.ct_Col_ShipGdsPrimeListResultList] = printShipGdsPrimeListResultList;
            }
        }

        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <param name="sectionCode"></param>
        /// <param name="goodsUnitData"></param>
        /// <param name="shipGdsPrmListCndtnPartnerWork"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       �@: ��ʒ��o�����������[�g���o�����֓W�J����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.25</br>
        /// <br>Update Note  : 2014/12/30 ������</br>
        /// <br>�Ǘ��ԍ�     : 11070263-00</br>
        /// <br>             :�E�����Y�ƗlSeiken�i�ԕύX</br>
        /// </remarks>
        private int DevPartnerListCndtn(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn, string sectionCode, GoodsUnitData goodsUnitData,
            ref ShipGdsPrmListCndtnPartnerWork shipGdsPrmListCndtnPartnerWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //shipGdsPrmListCndtnPartnerWork = new ShipGdsPrmListCndtnPartnerWork(); // DEL 2009/02/17

            try
            {
                // ���o�������ݒ�
                shipGdsPrmListCndtnPartnerWork.EnterpriseCode = shipGdsPrimeListCndtn.EnterpriseCode;  // ��ƃR�[�h
                shipGdsPrmListCndtnPartnerWork.St_AddUpYearMonth = shipGdsPrimeListCndtn.St_AddUpYearMonth; // �J�n�Ώ۔N��
                shipGdsPrmListCndtnPartnerWork.Ed_AddUpYearMonth = shipGdsPrimeListCndtn.Ed_AddUpYearMonth; // �I���Ώ۔N��
                //------ ADD START 2014/12/30 ������ FOR Redmine#44209���� ------>>>>>
                shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv = (int)shipGdsPrimeListCndtn.GoodsNoTtlDiv; // �i�ԏW�v�敪
                if (shipGdsPrmListCndtnPartnerWork.GoodsNoTtlDiv == 1)
                {
                    shipGdsPrmListCndtnPartnerWork.GoodsNoShowDiv = (int)shipGdsPrimeListCndtn.GoodsNoShowDiv; // �i�ԕ\���敪
                }
                //------ ADD END 2014/12/30 ������ FOR Redmine#44209���� ------<<<<<

                // �������i�����ݒ�
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

        /// <summary>
        /// �擾�����i�f�[�^�W�J����
        /// </summary>
        /// <param name="salesRsltListCndtn">UI���o�����N���X</param>
        /// <param name="resultWork">�擾�f�[�^</param>
        /// <remarks>
        /// <br>Note       �@: �����[�g���o���ʂ𒠕[�󎚗pDataTable�֓W�J����</br>
        /// <br>Programmer   : 30452 ��� �r��</br>
        /// <br>Date         : 2008.11.25</br>
        /// </remarks>
        private void DevPartnerListData(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn, ArrayList resultWork1, DataRow workDr, ref string errMsg)
        {
            foreach (ShipGdsPrimeListResultWork shipGdsPrimeListResultWork in resultWork1)
            {
                DataRow printDr = this._printDt.NewRow();


            }
        }

        /// <summary>
        /// ���[�󎚗p�e�[�u����1�s�f�[�^���쐬����
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn">���o����</param>
        private void MakePrintTable(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn)
        {
            // ���[�󎚗p�e�[�u���쐬
            PMHNB02155EB.CreateDataTable(ref this._printDt);

            // ���[�󎚗p�e�[�u���ɒǉ�����1�s���(PMHNB02155EB)
            DataRow printRow;

            // �����(�݌�)���v�l�ێ�Dic
            // Key:���������L�[�AValue:����񐔂̍��v
            Dictionary<int, int> stockSalesTimesDic = new Dictionary<int, int>();
            // �����(���)���v�l�ێ�Dic
            Dictionary<int, int> orderSalesTimesDic = new Dictionary<int, int>();
            // �����(���v)���v�l�ێ�Dic
            Dictionary<int, int> sumSalesTimesDic = new Dictionary<int, int>();

            for (int j = 0; j < this._shipGdsPrimeListDt.Rows.Count; j++ )
            {
                DataRow dr = this._shipGdsPrimeListDt.Rows[j];

                if ((Int32)dr[PMHNB02155EA.ct_Col_PartsCount] == 0)
                {
                    // DEL 2015/04/10 ���V�� �u�o�͋敪�v���L���ɂȂ��Ă���Ή� ----->>>>>
                    //if (shipGdsPrimeListCndtn.OutputDiv == ShipGdsPrimeListCndtn2.OutputDivState.All
                    //|| shipGdsPrimeListCndtn.OutputDiv == ShipGdsPrimeListCndtn2.OutputDivState.Order)
                    // DEL 2015/04/10 ���V�� �u�o�͋敪�v���L���ɂȂ��Ă���Ή� -----<<<<<
                    // ADD 2015/04/10 ���V�� �u�o�͋敪�v���L���ɂȂ��Ă���Ή� ----->>>>>
                    if (shipGdsPrimeListCndtn.OutputDiv == ShipGdsPrimeListCndtn2.OutputDivState.All
                        || (shipGdsPrimeListCndtn.OutputDiv == ShipGdsPrimeListCndtn2.OutputDivState.Order && !(bool)dr[PMHNB02155EA.ct_Col_StockYNFlag])
                        || (shipGdsPrimeListCndtn.OutputDiv == ShipGdsPrimeListCndtn2.OutputDivState.Stock && (bool)dr[PMHNB02155EA.ct_Col_StockYNFlag]))
                    // ADD 2015/04/10 ���V�� �u�o�͋敪�v���L���ɂȂ��Ă���Ή� -----<<<<<
                    {
                        // 1�s�̂ݍ쐬
                        printRow = this._printDt.NewRow();

                        printRow[PMHNB02155EB.ct_Col_SubInfoCount] = 0; // ��������(���[�E��)�̗L��
                        printRow[PMHNB02155EB.ct_Col_AddUpSecCode] = dr[PMHNB02155EA.ct_Col_AddUpSecCode]; // ���_�R�[�h
                        printRow[PMHNB02155EB.ct_Col_SectionGuideSnm] = dr[PMHNB02155EA.ct_Col_SectionGuideSnm]; // ���_����
                        printRow[PMHNB02155EB.ct_Col_Main_WarehouseShelfNo] = dr[PMHNB02155EA.ct_Col_WarehouseShelfNo]; // �I��
                        printRow[PMHNB02155EB.ct_Col_Main_BLGroupCode] = dr[PMHNB02155EA.ct_Col_BLGroupCode]; // �O���[�v�R�[�h
                        printRow[PMHNB02155EB.ct_Col_Main_GoodsNo] = dr[PMHNB02155EA.ct_Col_GoodsNo]; // �i��
                        printRow[PMHNB02155EB.ct_Col_Main_GoodsName] = dr[PMHNB02155EA.ct_Col_GoodsName]; // �i��
                        printRow[PMHNB02155EB.ct_Col_Main_St_SalesTimes] = dr[PMHNB02155EA.ct_Col_St_SalesTimes]; // �����(�݌�)
                        printRow[PMHNB02155EB.ct_Col_Main_Or_SalesTimes] = dr[PMHNB02155EA.ct_Col_Or_SalesTimes]; // �����(���)
                        printRow[PMHNB02155EB.ct_Col_Main_Sum_SalesTimes] = (int)dr[PMHNB02155EA.ct_Col_St_SalesTimes]
                                                                               + (int)dr[PMHNB02155EA.ct_Col_Or_SalesTimes]; // �����(���v)

                        // �����׃L�[
                        printRow[PMHNB02155EB.ct_Col_DetailUnitKey] = j;

                        // �\�[�g�p����
                        printRow[PMHNB02155EB.ct_Col_Sort_GoodsMakerCd] = dr[PMHNB02155EA.ct_Col_GoodsMakerCd]; // ���[�J�[�R�[�h
                        printRow[PMHNB02155EB.ct_Col_Sort_GoodsLGroup] = dr[PMHNB02155EA.ct_Col_GoodsLGroup]; // ���i�啪�ރR�[�h
                        printRow[PMHNB02155EB.ct_Col_Sort_GoodsMGroup] = dr[PMHNB02155EA.ct_Col_GoodsMGroup]; // ���i�����ރR�[�h
                        printRow[PMHNB02155EB.ct_Col_Sort_BLGroupCode] = dr[PMHNB02155EA.ct_Col_BLGroupCode]; // �O���[�v�R�[�h

                        // --- ADD 2008/12/25 -------------------------------->>>>>
                        // �t�B���^�p����(���v�l)
                        printRow[PMHNB02155EB.ct_Col_SubTotal_St_SalesTimes] = dr[PMHNB02155EA.ct_Col_St_SalesTimes];
                        printRow[PMHNB02155EB.ct_Col_SubTotal_Or_SalesTimes] = dr[PMHNB02155EA.ct_Col_Or_SalesTimes];
                        printRow[PMHNB02155EB.ct_Col_SubTotal_Sum_SalesTimes] = (int)dr[PMHNB02155EA.ct_Col_St_SalesTimes]
                                                                               + (int)dr[PMHNB02155EA.ct_Col_Or_SalesTimes];
                        // --- ADD 2008/12/25 --------------------------------<<<<<

                        this._printDt.Rows.Add(printRow);
                    }
                }
                else
                {
                    // DEL 2015/04/10 ���V�� �u�o�͋敪�v���L���ɂȂ��Ă���Ή� ----->>>>>
                    //if (shipGdsPrimeListCndtn.OutputDiv == ShipGdsPrimeListCndtn2.OutputDivState.All
                    //|| shipGdsPrimeListCndtn.OutputDiv == ShipGdsPrimeListCndtn2.OutputDivState.Stock)
                    // DEL 2015/04/10 ���V�� �u�o�͋敪�v���L���ɂȂ��Ă���Ή� -----<<<<<
                    // ADD 2015/04/10 ���V�� �u�o�͋敪�v���L���ɂȂ��Ă���Ή� ----->>>>>
                    if (shipGdsPrimeListCndtn.OutputDiv == ShipGdsPrimeListCndtn2.OutputDivState.All
                        || (shipGdsPrimeListCndtn.OutputDiv == ShipGdsPrimeListCndtn2.OutputDivState.Order && !(bool)dr[PMHNB02155EA.ct_Col_StockYNFlag])
                        || (shipGdsPrimeListCndtn.OutputDiv == ShipGdsPrimeListCndtn2.OutputDivState.Stock && (bool)dr[PMHNB02155EA.ct_Col_StockYNFlag]))
                    // ADD 2015/04/10 ���V�� �u�o�͋敪�v���L���ɂȂ��Ă���Ή� -----<<<<<
                    {
                        // �����i��� ���[�󎚍s�쐬
                        for (int i = 0; i < (Int32)dr[PMHNB02155EA.ct_Col_PartsCount]; i++)
                        {
                            printRow = this._printDt.NewRow();

                            #region ���������
                            printRow[PMHNB02155EB.ct_Col_SubInfoCount] = 1; // ��������(���[�E��)�̗L��
                            printRow[PMHNB02155EB.ct_Col_AddUpSecCode] = dr[PMHNB02155EA.ct_Col_AddUpSecCode]; // ���_�R�[�h
                            printRow[PMHNB02155EB.ct_Col_SectionGuideSnm] = dr[PMHNB02155EA.ct_Col_SectionGuideSnm]; // ���_����
                            printRow[PMHNB02155EB.ct_Col_Main_WarehouseShelfNo] = dr[PMHNB02155EA.ct_Col_WarehouseShelfNo]; // �I��
                            printRow[PMHNB02155EB.ct_Col_Main_BLGroupCode] = dr[PMHNB02155EA.ct_Col_BLGroupCode]; // �O���[�v�R�[�h
                            printRow[PMHNB02155EB.ct_Col_Main_GoodsNo] = dr[PMHNB02155EA.ct_Col_GoodsNo]; // �i��
                            printRow[PMHNB02155EB.ct_Col_Main_GoodsName] = dr[PMHNB02155EA.ct_Col_GoodsName]; // �i��
                            printRow[PMHNB02155EB.ct_Col_Main_St_SalesTimes] = dr[PMHNB02155EA.ct_Col_St_SalesTimes]; // �����(�݌�)
                            printRow[PMHNB02155EB.ct_Col_Main_Or_SalesTimes] = dr[PMHNB02155EA.ct_Col_Or_SalesTimes]; // �����(���)
                            printRow[PMHNB02155EB.ct_Col_Main_Sum_SalesTimes] = (int)dr[PMHNB02155EA.ct_Col_St_SalesTimes]
                                                                                   + (int)dr[PMHNB02155EA.ct_Col_Or_SalesTimes]; // �����(���v)

                            // �����ׁi���������j�L�[
                            printRow[PMHNB02155EB.ct_Col_DetailUnitKey] = j;

                            // �\�[�g�p����
                            printRow[PMHNB02155EB.ct_Col_Sort_GoodsMakerCd] = dr[PMHNB02155EA.ct_Col_GoodsMakerCd]; // ���[�J�[�R�[�h
                            printRow[PMHNB02155EB.ct_Col_Sort_GoodsLGroup] = dr[PMHNB02155EA.ct_Col_GoodsLGroup]; // ���i�啪�ރR�[�h
                            printRow[PMHNB02155EB.ct_Col_Sort_GoodsMGroup] = dr[PMHNB02155EA.ct_Col_GoodsMGroup]; // ���i�����ރR�[�h
                            printRow[PMHNB02155EB.ct_Col_Sort_BLGroupCode] = dr[PMHNB02155EA.ct_Col_BLGroupCode]; // �O���[�v�R�[�h
                            #endregion

                            #region ��������

                            GoodsUnitData goodsUnitData = ((List<GoodsUnitData>)(dr[PMHNB02155EA.ct_Col_GoodsUnitDataList]))[i];

                            printRow[PMHNB02155EB.ct_Col_Sub_DisplayOrder] = goodsUnitData.JoinDispOrder; // �����\������
                            printRow[PMHNB02155EB.ct_Col_Sub_GoodsNo] = goodsUnitData.GoodsNo; // �i��
                            printRow[PMHNB02155EB.ct_Col_Sub_MakerCode] = goodsUnitData.GoodsMakerCd; // ���[�J�[�R�[�h
                            printRow[PMHNB02155EB.ct_Col_Sub_SuplierCode] = goodsUnitData.SupplierCd; // �d����R�[�h

                            // �݌Ƀ��X�g��Index����
                            int index = GetStockListIndex(dr[PMHNB02155EA.ct_Col_EnterpriseCode].ToString()
                                                         , dr[PMHNB02155EA.ct_Col_AddUpSecCode].ToString()
                                                         , goodsUnitData);

                            if (index != -1)
                            {
                                printRow[PMHNB02155EB.ct_Col_Sub_WarehouseShelfNo] = goodsUnitData.StockList[index].WarehouseShelfNo; // �I��
                            }

                            // �����i�����W�v�f�[�^���
                            ShipGdsPrimeListResultWork shipGdsPrimeListResultWork = (ShipGdsPrimeListResultWork)((ArrayList)dr[PMHNB02155EA.ct_Col_ShipGdsPrimeListResultList])[i];

                            printRow[PMHNB02155EB.ct_Col_Sub_St_SalesTimes] = shipGdsPrimeListResultWork.St_SalesTimes; // �����(�݌�)
                            printRow[PMHNB02155EB.ct_Col_Sub_Or_SalesTimes] = shipGdsPrimeListResultWork.Or_SalesTimes; // �����(���)
                            printRow[PMHNB02155EB.ct_Col_Sub_Sum_SalesTimes] = shipGdsPrimeListResultWork.St_SalesTimes + shipGdsPrimeListResultWork.Or_SalesTimes; // �����(���v)

                            // �����׌v�̎擾
                            if (stockSalesTimesDic.ContainsKey(j))
                            {
                                // �����ׂ�Dic������ꍇ�͒ǉ�
                                stockSalesTimesDic[j] += shipGdsPrimeListResultWork.St_SalesTimes;
                                orderSalesTimesDic[j] += shipGdsPrimeListResultWork.Or_SalesTimes;
                                sumSalesTimesDic[j] += shipGdsPrimeListResultWork.St_SalesTimes + shipGdsPrimeListResultWork.Or_SalesTimes;
                            }
                            else
                            {
                                // �����ׂ�Dic���Ȃ��ꍇ�͐V�K
                                stockSalesTimesDic.Add(j, shipGdsPrimeListResultWork.St_SalesTimes);
                                orderSalesTimesDic.Add(j, shipGdsPrimeListResultWork.Or_SalesTimes);
                                sumSalesTimesDic.Add(j, shipGdsPrimeListResultWork.St_SalesTimes + shipGdsPrimeListResultWork.Or_SalesTimes);
                            }

                            #endregion

                            this._printDt.Rows.Add(printRow);
                        }
                    }
                }
            }

            // ������̍��v�l�i�I�ԁA�݌ɁA���j�ݒ�
            foreach (DataRow dr in this._printDt.Rows)
            {
                if (stockSalesTimesDic.ContainsKey((int)dr[PMHNB02155EB.ct_Col_DetailUnitKey]))
                {
                    // �������̔��㐔�v + ������̔��㐔�v
                    // ������(��������)�̍s�ɂ͓������v�l��ݒ�A���[���ŕ\��������s���B
                    dr[PMHNB02155EB.ct_Col_SubTotal_St_SalesTimes] = (int)dr[PMHNB02155EB.ct_Col_Main_St_SalesTimes] + stockSalesTimesDic[(int)dr[PMHNB02155EB.ct_Col_DetailUnitKey]];
                    dr[PMHNB02155EB.ct_Col_SubTotal_Or_SalesTimes] = (int)dr[PMHNB02155EB.ct_Col_Main_Or_SalesTimes] + orderSalesTimesDic[(int)dr[PMHNB02155EB.ct_Col_DetailUnitKey]];
                    dr[PMHNB02155EB.ct_Col_SubTotal_Sum_SalesTimes] =(int)dr[PMHNB02155EB.ct_Col_Main_Sum_SalesTimes] +  sumSalesTimesDic[(int)dr[PMHNB02155EB.ct_Col_DetailUnitKey]];
                }
            }
        }

        /// <summary>
        /// �����ɍ��v����݌Ƀ��X�g��index���擾����
        /// </summary>
        /// <returns></returns>
        private int GetStockListIndex(string enterpriseCode, string sectionCode, GoodsUnitData goodsUnitData)
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
            index = this.CheckStockList(enterpriseCode, sectionCode, goodsUnitData, goodsUnitData.StockList, SectWarehouseCd1);

            if (index == -1)
            {
                index = this.CheckStockList(enterpriseCode, sectionCode, goodsUnitData, goodsUnitData.StockList, SectWarehouseCd2);

                if (index == -1)
                {
                    index = this.CheckStockList(enterpriseCode, sectionCode, goodsUnitData, goodsUnitData.StockList, SectWarehouseCd3);

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
        /// �t�B���^��������擾����
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <returns></returns>
        private string GetFilterString(ShipGdsPrimeListCndtn2 shipGdsPrimeListCndtn2)
        {
            // �o�׉񐔂ɂ��t�B���^��������쐬����
            StringBuilder filterSb = new StringBuilder();

            // ������
            filterSb.Append(PMHNB02155EB.ct_Col_SubTotal_Sum_SalesTimes);
            filterSb.Append(" >= ");
            filterSb.Append(shipGdsPrimeListCndtn2.ShipCount);

            return filterSb.ToString();
        }

        /// <summary>
        /// �\�[�g��������擾����
        /// </summary>
        /// <param name="shipGdsPrimeListCndtn"></param>
        /// <returns></returns>
        private string GetSortString()
        {
            // �������F���_ - ���[�J�[ - ���i�啪��- ���i������ - �O���[�v�R�[�h - �i�� ��
            // ������F���� - �d���� - ���[�J�[ - �i�� ��
            StringBuilder sortSb = new StringBuilder();

            // ������
            sortSb.Append(PMHNB02155EB.ct_Col_AddUpSecCode);
            sortSb.Append(", ");
            sortSb.Append(PMHNB02155EB.ct_Col_Sort_GoodsMakerCd);
            sortSb.Append(", ");
            sortSb.Append(PMHNB02155EB.ct_Col_Sort_GoodsLGroup);
            sortSb.Append(", ");
            sortSb.Append(PMHNB02155EB.ct_Col_Sort_GoodsMGroup);
            sortSb.Append(", ");
            sortSb.Append(PMHNB02155EB.ct_Col_Sort_BLGroupCode);
            sortSb.Append(", ");
            sortSb.Append(PMHNB02155EB.ct_Col_Main_GoodsNo);
            sortSb.Append(", ");

            // ������
            sortSb.Append(PMHNB02155EB.ct_Col_Sub_DisplayOrder);
            sortSb.Append(", ");
            sortSb.Append(PMHNB02155EB.ct_Col_Sub_SuplierCode);
            sortSb.Append(", ");
            sortSb.Append(PMHNB02155EB.ct_Col_Sub_MakerCode);
            sortSb.Append(", ");
            sortSb.Append(PMHNB02155EB.ct_Col_Sub_GoodsNo);

            return sortSb.ToString();
        }
        #endregion

        #region �e�X�g�f�[�^
        /// <summary>
        /// �e�X�g�f�[�^(�����i����)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int testProcMain(out object obj)
        {
            ArrayList paramlist = new ArrayList();

            ShipGdsPrimeListResultWork param = new ShipGdsPrimeListResultWork();

            param.EnterpriseCode = "0101150842020000"; // ��ƃR�[�h
            param.AddUpSecCode = "01    "; // �v�㋒�_�R�[�h
            param.SectionGuideSnm = "���_1"; // ���_�K�C�h����
            param.GoodsMakerCd = 1111; // ���[�J�[�R�[�h
            param.GoodsNo = "123456789012345678901234"; // ���i�ԍ�
            param.St_SalesTimes = 1000000; // �����(�݌�)
            param.St_TotalSalesCount = 1000000; // ���㐔�v(�݌�)
            param.St_SalesMoney = 1000000; // ������z(�݌�)
            param.St_SalesRetGoodsPrice = 1000000; // �ԕi�z(�݌�)
            param.St_DiscountPrice = 1000000; // �l�����z(�݌�)
            param.St_GrossProfit = 1000000; // �e�����z(�݌�)
            param.Or_SalesTimes = 1000000; // �����(���)
            param.Or_TotalSalesCount = 1000000; // ���㐔�v(���)
            param.Or_SalesMoney = 1000000; // ������z(���)
            param.Or_SalesRetGoodsPrice = 1000000; // �ԕi�z(���)
            param.Or_DiscountPrice = 1000000; // �l�����z(���)
            param.Or_GrossProfit = 1000000; // �e�����z(���)

            paramlist.Add(param);

            obj = (object)paramlist;

            return 0;
        }

        /// <summary>
        /// �e�X�g�f�[�^(���i�}�X�^����)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int testProcMainGoods(out List<GoodsUnitData> goodsUnitDataList)
        {
            goodsUnitDataList = new List<GoodsUnitData>();

            GoodsUnitData goods1 = new GoodsUnitData();

            goods1.EnterpriseCode = "0101150842020000"; // ��ƃR�[�h
            goods1.SectionCode = "01    "; // �v�㋒�_�R�[�h
            goods1.GoodsMakerCd = 1111; // ���[�J�[�R�[�h
            goods1.GoodsNo = "123456789012345678901234"; // ���i�ԍ�
            goods1.GoodsNameKana = "12345678901234567890";
            goods1.SupplierCd = 1;

            goods1.StockList = new List<Stock>();
            goods1.GoodsPriceList = new List<GoodsPrice>();

            goodsUnitDataList.Add(goods1);

            return 0;
        }

        /// <summary>
        /// �e�X�g�f�[�^(���i�}�X�^����)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int testProcSubGoods(out List<GoodsUnitData> goodsUnitDataList)
        {
            goodsUnitDataList = new List<GoodsUnitData>();

            GoodsUnitData goods1 = new GoodsUnitData();

            goods1.EnterpriseCode = "0101150842020000"; // ��ƃR�[�h
            goods1.SectionCode = "01    "; // �v�㋒�_�R�[�h
            goods1.GoodsMakerCd = 2222; // ���[�J�[�R�[�h
            goods1.GoodsNo = "111111111122222222224444"; // ���i�ԍ�
            goods1.SupplierCd = 2;

            goods1.StockList = new List<Stock>();
            goods1.GoodsPriceList = new List<GoodsPrice>();

            goodsUnitDataList.Add(goods1);

            GoodsUnitData goods2 = new GoodsUnitData();

            goods2.EnterpriseCode = "0101150842020000"; // ��ƃR�[�h
            goods2.SectionCode = "01    "; // �v�㋒�_�R�[�h
            goods2.GoodsMakerCd = 3333; // ���[�J�[�R�[�h
            goods2.GoodsNo = "333333333344444444445555"; // ���i�ԍ�
            goods2.SupplierCd = 3;

            goods2.StockList = new List<Stock>();
            goods2.GoodsPriceList = new List<GoodsPrice>();

            goodsUnitDataList.Add(goods2);

            GoodsUnitData goods3 = new GoodsUnitData();

            goods3.EnterpriseCode = "0101150842020000"; // ��ƃR�[�h
            goods3.SectionCode = "01    "; // �v�㋒�_�R�[�h
            goods3.GoodsMakerCd = 4444; // ���[�J�[�R�[�h
            goods3.GoodsNo = "666666666677777777778888"; // ���i�ԍ�
            goods3.SupplierCd = 4;

            goods3.StockList = new List<Stock>();
            goods3.GoodsPriceList = new List<GoodsPrice>();

            goodsUnitDataList.Add(goods3);

            return 0;
        }

        /// <summary>
        /// �e�X�g�f�[�^(�����i����)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private int testProcSub(out object obj)
        {
            ArrayList paramlist = new ArrayList();

            ShipGdsPrimeListResultWork param = new ShipGdsPrimeListResultWork();

            param.EnterpriseCode = "0101150842020000"; // ��ƃR�[�h
            param.AddUpSecCode = "01    "; // �v�㋒�_�R�[�h
            param.SectionGuideSnm = "���_1"; // ���_�K�C�h����
            param.GoodsMakerCd = 5555; // ���[�J�[�R�[�h
            param.GoodsNo = "999999999988888888887777"; // ���i�ԍ�
            param.St_SalesTimes = 2000000; // �����(�݌�)
            param.St_TotalSalesCount = 2000000; // ���㐔�v(�݌�)
            param.St_SalesMoney = 2000000; // ������z(�݌�)
            param.St_SalesRetGoodsPrice = 2000000; // �ԕi�z(�݌�)
            param.St_DiscountPrice = 2000000; // �l�����z(�݌�)
            param.St_GrossProfit = 2000000; // �e�����z(�݌�)
            param.Or_SalesTimes = 2000000; // �����(���)
            param.Or_TotalSalesCount = 2000000; // ���㐔�v(���)
            param.Or_SalesMoney = 2000000; // ������z(���)
            param.Or_SalesRetGoodsPrice = 2000000; // �ԕi�z(���)
            param.Or_DiscountPrice = 2000000; // �l�����z(���)
            param.Or_GrossProfit = 2000000; // �e�����z(���)

            paramlist.Add(param);

            obj = (object)paramlist;

            return 0;
        }
        #endregion
    }
}
