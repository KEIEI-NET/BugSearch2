using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Text;
using System.Runtime.Serialization.Formatters.Binary;  // Add 2010/04/27
using System.IO;  // Add 2010/04/27

using System.Threading;  // ADD 杍^ 2014/09/01 FOR Redmine#43289

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �������σt�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������ς̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2008.05.21</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.07.15 22018 ��� ���b MANTIS[0013805] �ԑ�ԍ��͈̔̓`�F�b�N���ꕔ�C��(�͈�:1�`x�Ȃ����:000�c0�������Ȃ�)</br>
    /// <br>2009/09/08 20056 ���n ��� MANTIS[0014250] TBO�������Ɍ����������p�����[�^�Ƃ��ăZ�b�g����(�������ς�TBO��������ƃG���[�ƂȂ�Ή�)</br>
    /// <br>2009/10/15 22018 ��� ���b MANTIS[0014360] ���o�\�t�@�\�̏C���ɔ����ύX�B�i�t���^���Œ�ԍ����[�����܂ޏꍇ�̑Ή��j</br>
    /// <br></br>
    /// <br>Update Note: 2009/09/08�A       ���痈</br>
    /// <br>             PM.NS-2-A�E���q�Ǘ�</br>
    /// <br>             ���q�Ǘ��@�\�̒ǉ�</br>
    /// <br>Update Note: 2009/10/22 ����</br>
    /// <br>           : Redmine#779�̑Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2009/10/22�A ������</br>
    /// <br>             PM.NS-3-A�EPM.NS�ێ�˗��A</br>
    /// <br>             �ێ�˗��A�̒ǉ�</br>
    /// <br></br>
    /// <br>Update Note: 2009/11/05 ������</br>
    /// <br>             PM.NS-3-A�EPM.NS�ێ�˗��A</br>
    /// <br>             Redmine#1087�A#1134�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2009/11/25�@21024 ���X�� ��</br>
    /// <br>             �̔��敪�R�[�h�A�̔��敪���̂��Z�b�g����悤�ɏC��(MANTIS[0014689])</br>
    /// <br></br>
    /// <br>Update Note: 2009/12/17 ���n ��� �ێ�˗��B�Ή�</br>
    /// <br>             �i�Ԍ����ABL���ތ������ɔ������ݒ莞�敪��ݒ肷��悤�ɕύX����</br>
    /// <br>Update Note: 2010/04/27 gaoyh</br>
    /// <br>             �󒍃}�X�^�i�ԗ��j���R�����^���Œ�ԍ��z��̒ǉ��Ή�</br>
    /// <br>Update Note: 2010/05/20 gaoyh</br>
    /// <br>             #7653 ���R�����^���Œ�ԍ��z��̒ǉ��Ή�</br>
    /// <br>Update Note: 2010/05/21 22018 ��ؐ��b</br>
    /// <br>             ���R�����^���Œ�ԍ��̏������C��</br>
    /// <br>Update Note: 2011/02/14 14489 �{�w�C��</br>
    /// <br>             �C���ďo���̓`�[���ʂɂ��G���[�C��</br>
    /// <br>Update Note: 2011/02/14 yangmj</br>
    /// <br>             �p�i���͎��̔����v�Z�ŃG���[�������錏�̏C��</br>
    /// <br>Update Note: 2011/02/14 ������</br>
    /// <br>             �f�[�^�o�^���̎ԑ�ԍ��͈̓Z�b�g�̏C��</br>
    /// <br>Update Note: 2011/03/28 ������</br>
    /// <br>             Redmine #20177�̑Ή�</br>
    /// <br>Update Note: 2011/07/26 ����</br>
    /// <br>             �������ψ�����̕s��̑Ή�</br>
    /// <br>Update Note: 2012/08/20 30744 ���� ����q</br>
    /// <br>           : 2012/09/12�z�M �V�X�e���e�X�g��QNo.8�Ή�</br>
    /// <br>Update Note: 2012/09/07 �e�c�@���V </br>
    /// <br>             �J���[�E�g�����̑��݃`�F�b�N���O���A�}�X�^�ɑ��݂��Ȃ��R�[�h�����͉\�ɂ���悤�ɏC��</br>
    /// <br>Update Note: 2012/09/11 �e�c�@���V </br>
    /// <br>             �J���[�E�g�����̑��݃`�F�b�N���O���A�}�X�^�ɑ��݂��Ȃ��R�[�h�����͉\�ɂ���悤�ɏC��</br>
    /// <br>Update Note: 2012/09/12 �e�c�@���V </br>
    /// <br>             �J���[�E�g�����̑��݃`�F�b�N���O���A�}�X�^�ɑ��݂��Ȃ��R�[�h�����͉\�ɂ���悤�ɏC��</br>
    /// <br>Update Note: 2012/09/13 30744 ���� ����q</br>
    /// <br>           : 2012/09/19�z�M SCM��Q��125�Ή�</br>
    /// <br>           :                ���L����40���ȏ�J�b�g�Ή�</br>
    /// <br>Update Note: 2012/10/25 �{�{ ����</br>
    /// <br>           : ��Q�Ή� �S�Ĉ󎚎��ɗD�Ǖi�C�����ׂɗD�Ǖi�̕i������</br>
    /// <br>Update Note: 2012/12/27 �{�{ ����</br>
    /// <br>           : ��Q�Ή� �����i�����󔒂̏ꍇ�ɗD�Ǖi�i������</br>
    /// <br>Update Note: 2013/02/20 杍^</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00�A2013/03/13�z�M��</br>
    /// <br>             Redmine#34434 No.1180 ���݌ɐ����O�̂Ƃ��݌ɐ����󔒂ŕ\�������̑Ή�</br>
    /// <br>Update Note: 2013/03/08 �e�c ���V</br>
    /// <br>             ���q���ɂ���Č������Ȃ����BL�R�[�h�����ł��Ȃ����Ƃ������Q�̏C��</br>
    /// <br>Update Note: 2013/03/10 杍^</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>           : redmine#34994�A�������ϔ��s�@���݌ɐ����O�̂Ƃ��݌ɐ����O�ŕ\���̑Ή�</br>
    /// <br>Update Note: 2013/03/21 FSI���� ���T</br>
    /// <br>�Ǘ��ԍ�   : 10900269-00</br>
    /// <br>             SPK�ԑ�ԍ�������Ή�</br>   
    /// <br>Update Note: 2013/12/16 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 10904597-00</br>
    /// <br>           : �����艿�󎚑Ή�</br>
    /// <br>Update Note: 2014/09/01 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11070184-00�@SCM��Q�Ή� ��190�@RedMine#43289</br>
    /// <br>         �@: SF����⍇���̎��q���E���l�𔄏�`�[���͂ɕ\������</br>
    /// </remarks>
    public partial class EstimateInputAcs
    {
        // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- >>>
        /// <summary>�ԗ�����\���p</summary>
        private const string PGID_XML = "PMMIT01010U";
        //Thread���A�ԗ����SOLT��
        private const string CARINFOSOLT = "CARINFOSOLT";
        private LocalDataStoreSlot carInfoSolt = null;
        // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- <<<

        // ===================================================================================== //
        // ���q���
        // ===================================================================================== //
        #region �����q���
        /// <summary>
        /// ���q��񑶍݃`�F�b�N
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <returns>true:���݂��� false:���݂��Ȃ�</returns>
        public bool ExistCarInfo( int salesRowNo )
        {
            bool ret = false;

            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._salesSlip.SalesSlipNum.PadLeft(9, '0'), salesRowNo);

            if (row != null)
            {
                // ���荀�ځF���q��񋤒ʃL�[
                if (row.CarRelationGuid != Guid.Empty)
                {
                    //ret = ( this.GetSearchCarInfo(row.CarRelationGuid) == null );
                    ret = true;
                }
            }

            return ret;
        }

        /// <summary>
        /// ���q��񑶍݃`�F�b�N
        /// </summary>
        /// <returns>true:���݂��� false:���݂��Ȃ�</returns>
        public bool ExistCarInfo()
        {
            bool ret = false;

            foreach (EstimateInputDataSet.EstimateDetailRow salesDetailRow in this._estimateDetailDataTable)
            {
                // ���荀�ځF���q��񋤒ʃL�[
                if (salesDetailRow.CarRelationGuid != Guid.Empty)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        /// ���q���e�[�u���s�ǉ�
        /// </summary>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <returns>�ǉ��������q���s�I�u�W�F�N�g</returns>
        private EstimateInputDataSet.CarInfoRow AddCarInfoRow( string salesSlipNum, int salesRowNo )
        {
            // ���q��񋤒ʃL�[����
            Guid carRelationGuid = Guid.NewGuid();

            // ���q���f�[�^�s�I�u�W�F�N�g����
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.NewCarInfoRow();
            this.ClearCarInfoRow(ref carInfoRow);

            // ���㖾�׃f�[�^�s�I�u�W�F�N�g�擾
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(salesSlipNum, salesRowNo);
            salesDetailRow.CarRelationGuid = carRelationGuid; // ���q��񋤒ʃL�[�Z�b�g

            // �L�[�Z�b�g
            carInfoRow.CarRelationGuid = carRelationGuid;
            carInfoRow.FullModelFixedNoAry = new Int32[0];
            carInfoRow.FreeSrchMdlFxdNoAry = new string[0]; // ADD 2010/04/27
            this._carInfoDataTable.AddCarInfoRow(carInfoRow);

            return carInfoRow;
        }

        /// <summary>
        /// �ԗ����e�[�u���̃N���A
        /// </summary>
        /// <param name="tempCarMngCode">�ԗ��Ǘ��ԍ�</param>
        /// <remarks>
        /// <br>Note       : �ԗ����e�[�u���N���A���������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/09/08�A</br>
        /// </remarks>
        public void ClearCarInfo(string tempCarMngCode)
        {
            foreach (EstimateInputDataSet.EstimateDetailRow salesDetailRow in this._estimateDetailDataTable)
            {
                // �ԗ����s�I�u�W�F�N�g�擾
                EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(salesDetailRow.CarRelationGuid);
                if (carInfoRow == null) return;

                this.ClearCarInfoRow(ref carInfoRow);

                carInfoRow.CarMngCode = tempCarMngCode;
            }
        }

        /// <summary>
        /// ���q���e�[�u���̃N���A
        /// </summary>
        /// <param name="salesRowNoList">�N���A�Ώ۔���s�ԍ����X�g</param>
        public void ClearCarInfoRow( List<int> salesRowNoList )
        {
            // �w�蔄��s�ԍ����X�g��ΏۂƂ��ăN���A
            foreach (int salesRowNo in salesRowNoList)
            {
                this.ClearCarInfoRow(salesRowNo);
            }
        }

        /// <summary>
        /// ���ʓ`�[�p�̎��q���e�[�u���𐶐����܂��B
        /// </summary>
        /// <br>Update Note: 2009/09/08 ���痈 ���q�Ǘ��@�\�Ή�</br>
        public void CreateSlipCopyCarInfo()
        {
            // --- UPD 2009/09/08 ---------->>>>>
            bool clearflag = false;
            if (this._estimateInputInitDataAcs.GetSalesTtlSt() != null &&
                    this._estimateInputInitDataAcs.GetSalesTtlSt().CarMngNoDispDiv == 1)
            {
                if (this._estimateInputInitDataAcs.Opt_CarMng)
                {
                    clearflag = false;
                }
                else
                {
                    clearflag = true;
                }
            }
            else
            {
                clearflag = true;
            }
            foreach (EstimateInputDataSet.CarInfoRow row in this._carInfoDataTable)
            {
                row.AcceptAnOrderNo = 0;

                if (clearflag == true)
                {
                    // �ԗ��Ǘ��ԍ�
                    row.CarMngNo = 0;
                    // �ԗ����s����
                    row.Mileage = 0;
                    // ���q���l
                    row.CarNote = string.Empty;
                    // ���^�������ԍ�
                    row.NumberPlate1Code = 0;
                    // ���^�����ǖ���
                    row.NumberPlate1Name = string.Empty;
                    // �ԗ��o�^�ԍ��i��ʁj
                    row.NumberPlate2 = string.Empty;
                    // �ԗ��o�^�ԍ��i�J�i�j
                    row.NumberPlate3 = string.Empty;
                    // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                    row.NumberPlate4 = 0;

                    if (this._estimateInputInitDataAcs.GetSalesTtlSt() == null ||
                        this._estimateInputInitDataAcs.GetSalesTtlSt().CarMngNoDispDiv == 0)
                    {
                        row.CarMngCode = string.Empty;
                    }
                }
            }

            // --- UPD 2009/09/08 ----------<<<<<
        }


        /// <summary>
        /// ���q���e�[�u���̎󒍔ԍ����N���A���܂��B
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        public void ClearCarInfoRowClearAcceptAnOrderNo(int salesRowNo)
        {
            // ���㖾�׍s�I�u�W�F�N�g�擾
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (salesDetailRow == null) return;

            // ���q���s�I�u�W�F�N�g�擾
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(salesDetailRow.CarRelationGuid);
            if (carInfoRow == null) return;

            carInfoRow.AcceptAnOrderNo = 0;
        }

        /// <summary>
        /// ���q���e�[�u���̃N���A
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        public void ClearCarInfoRow(int salesRowNo)
        {
            // ���㖾�׍s�I�u�W�F�N�g�擾
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (salesDetailRow == null) return;

            // ���q���s�I�u�W�F�N�g�擾
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(salesDetailRow.CarRelationGuid);
            if (carInfoRow == null) return;

            this.ClearCarInfoRow(ref carInfoRow);
        }

        /// <summary>
        /// �������q���̃N���A
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        public void ClearCarInfo(int salesRowNo)
        {
            // ���㖾�׍s�I�u�W�F�N�g�擾
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (salesDetailRow == null) return;

            // ���q���s�I�u�W�F�N�g�擾
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(salesDetailRow.CarRelationGuid);
            if (carInfoRow == null) return;

            this.ClearCarInfo(ref carInfoRow);
        }

        // ------- ADD 2011/02/14 --------- >>>>
        /// <summary>
        /// �������q���̃N���A
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        public void ClearCarInfoForModelCode(int salesRowNo)
        {
            // ���㖾�׍s�I�u�W�F�N�g�擾
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (salesDetailRow == null) return;

            // ���q���s�I�u�W�F�N�g�擾
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(salesDetailRow.CarRelationGuid);
            if (carInfoRow == null) return;

            this.ClearCarInfoForModelCode(ref carInfoRow);
        }

        /// <summary>
        /// ���Y�N���̃N���A
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        public void ClearCarInfoForProduceTypeOfYear(int salesRowNo)
        {
            // ���㖾�׍s�I�u�W�F�N�g�擾
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (salesDetailRow == null) return;

            // ���q���s�I�u�W�F�N�g�擾
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(salesDetailRow.CarRelationGuid);
            if (carInfoRow == null) return;

            this.ClearCarInfoForProduceTypeOfYear(ref carInfoRow);
        }
        // ------- ADD 2011/02/14 --------- <<<<

        /// <summary>
        /// ���q���e�[�u���̃N���A
        /// </summary>
        /// <param name="carRelationGuid">���q���A��GUID</param>
        private void ClearCarInfoRow( Guid carRelationGuid )
        {
            // ���q���s�I�u�W�F�N�g�擾
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
            if (carInfoRow == null) return;

            this.ClearCarInfoRow(ref carInfoRow);
        }

        /// <summary>
        /// ���q���e�[�u���̃N���A
        /// </summary>
        /// <param name="carInfoRow">����s�ԍ�</param>
        /// <br>Update Note: 2009/09/08�A       ���痈</br>
        ///	<br>		   : ���q���l�Ǝ��q�ǉ����P�Ǝ��q�ǉ����Q��ǉ�����</br>
        public void ClearCarInfoRow( ref EstimateInputDataSet.CarInfoRow carInfoRow )
        {
            if (carInfoRow == null) return;

            //carInfoRow.CarRelationGuid = Guid.Empty;            // ���q��񋤒ʃL�[
            carInfoRow.CustomerCode = 0;                        // ���Ӑ�R�[�h
            carInfoRow.CarMngNo = 0;                            // ���q�Ǘ��ԍ�
            carInfoRow.CarMngCode = string.Empty;               // ���q�Ǘ��R�[�h
            carInfoRow.NumberPlate1Code = 0;                    // ���^�������ԍ�
            carInfoRow.NumberPlate1Name = string.Empty;         // ���^�����ǖ���
            carInfoRow.NumberPlate2 = string.Empty;             // ���q�o�^�ԍ��i��ʁj
            carInfoRow.NumberPlate3 = string.Empty;             // ���q�o�^�ԍ��i�J�i�j
            carInfoRow.NumberPlate4 = 0;                        // ���q�o�^�ԍ��i�v���[�g�ԍ��j
            carInfoRow.EntryDate = DateTime.MinValue;           // �o�^�N����
            // --- UPD 2009/10/22 ----->>>>>
            //carInfoRow.FirstEntryDate = DateTime.MinValue;      // ���N�x
            carInfoRow.FirstEntryDate = 0;
            // --- UPD 2009/10/22 -----<<<<<
            carInfoRow.MakerCode = 0;                           // ���[�J�[�R�[�h
            carInfoRow.MakerFullName = string.Empty;            // ���[�J�[�S�p����
            carInfoRow.ModelCode = 0;                           // �Ԏ�R�[�h
            carInfoRow.ModelSubCode = 0;                        // �Ԏ�T�u�R�[�h
            carInfoRow.ModelFullName = string.Empty;            // �Ԏ�S�p����
            carInfoRow.SystematicCode = 0;                      // �n���R�[�h
            carInfoRow.SystematicName = string.Empty;           // �n������
            carInfoRow.ProduceTypeOfYearCd = 0;                 // ���Y�N���R�[�h
            carInfoRow.ProduceTypeOfYearNm = string.Empty;      // ���Y�N������
            carInfoRow.StProduceTypeOfYear = DateTime.MinValue; // �J�n���Y�N��
            carInfoRow.EdProduceTypeOfYear = DateTime.MinValue; // �I�����Y�N��
            carInfoRow.DoorCount = 0;                           // �h�A��
            carInfoRow.BodyNameCode = 0;                        // �{�f�B�[���R�[�h
            carInfoRow.BodyName = string.Empty;                 // �{�f�B�[����
            carInfoRow.ExhaustGasSign = string.Empty;           // �r�K�X�L��
            carInfoRow.SeriesModel = string.Empty;              // �V���[�Y�^��
            carInfoRow.CategorySignModel = string.Empty;        // �^���i�ޕʋL���j
            carInfoRow.FullModel = string.Empty;                // �^���i�t���^�j
            carInfoRow.ModelDesignationNo = 0;                  // �^���w��ԍ�
            carInfoRow.CategoryNo = 0;                          // �ޕʔԍ�
            carInfoRow.FrameModel = string.Empty;               // �ԑ�^��
            carInfoRow.FrameNo = string.Empty;                  // �ԑ�ԍ�
            carInfoRow.SearchFrameNo = 0;                       // �ԑ�ԍ��i�����p�j
            carInfoRow.StProduceFrameNo = 0;                    // ���Y�ԑ�ԍ��J�n
            carInfoRow.EdProduceFrameNo = 0;                    // ���Y�ԑ�ԍ��I��
            carInfoRow.ModelGradeNm = string.Empty;             // �^���O���[�h����
            carInfoRow.EngineModelNm = string.Empty;            // �G���W���^������
            carInfoRow.EngineDisplaceNm = string.Empty;         // �r�C�ʖ���
            carInfoRow.EDivNm = string.Empty;                   // E�敪����
            carInfoRow.TransmissionNm = string.Empty;           // �~�b�V��������
            carInfoRow.ShiftNm = string.Empty;                  // �V�t�g����
            carInfoRow.WheelDriveMethodNm = string.Empty;       // �쓮��������
            carInfoRow.AddiCarSpec1 = string.Empty;             // �ǉ�����1
            carInfoRow.AddiCarSpec2 = string.Empty;             // �ǉ�����2
            carInfoRow.AddiCarSpec3 = string.Empty;             // �ǉ�����3
            carInfoRow.AddiCarSpec4 = string.Empty;             // �ǉ�����4
            carInfoRow.AddiCarSpec5 = string.Empty;             // �ǉ�����5
            carInfoRow.AddiCarSpec6 = string.Empty;             // �ǉ�����6
            carInfoRow.AddiCarSpecTitle1 = string.Empty;        // �ǉ������^�C�g��1
            carInfoRow.AddiCarSpecTitle2 = string.Empty;        // �ǉ������^�C�g��2
            carInfoRow.AddiCarSpecTitle3 = string.Empty;        // �ǉ������^�C�g��3
            carInfoRow.AddiCarSpecTitle4 = string.Empty;        // �ǉ������^�C�g��4
            carInfoRow.AddiCarSpecTitle5 = string.Empty;        // �ǉ������^�C�g��5
            carInfoRow.AddiCarSpecTitle6 = string.Empty;        // �ǉ������^�C�g��6
            carInfoRow.RelevanceModel = string.Empty;           // �֘A�^��
            carInfoRow.SubCarNmCd = 0;                          // �T�u�Ԗ��R�[�h
            carInfoRow.ModelGradeSname = string.Empty;          // �^���O���[�h����
            carInfoRow.BlockIllustrationCd = 0;                 // �u���b�N�C���X�g�R�[�h
            carInfoRow.ThreeDIllustNo = 0;                      // 3D�C���X�gNo
            carInfoRow.PartsDataOfferFlag = 0;                  // ���i�f�[�^�񋟃t���O
            carInfoRow.InspectMaturityDate = DateTime.MinValue; // �Ԍ�������
            carInfoRow.LTimeCiMatDate = DateTime.MinValue;      // �O��Ԍ�������
            carInfoRow.CarInspectYear = 0;                      // �Ԍ�����
            carInfoRow.Mileage = 0;                             // ���q���s����
            carInfoRow.CarNo = string.Empty;                    // ����
            // --- UPD 2009/09/08�A ---------->>>>>
            //carInfoRow.FullModelFixedNoAry = null;              // �t���^���Œ�ԍ��z��
            carInfoRow.FullModelFixedNoAry = new Int32[0];        // �t���^���Œ�ԍ��z��
            carInfoRow.FreeSrchMdlFxdNoAry = new string[0];        // ���R�����^���Œ�ԍ��z�� // ADD 2010/04/27
            // --- UPD 2009/09/08�A ---------->>>>>
            carInfoRow.ProduceTypeOfYearInput = 0;              // �N��
            carInfoRow.ColorCode = string.Empty;                // �J���[�R�[�h
            carInfoRow.ColorName1 = string.Empty;               // �J���[����
            carInfoRow.TrimCode = string.Empty;                 // �g�����R�[�h
            carInfoRow.TrimName = string.Empty;                 // �g��������
            carInfoRow.AcceptAnOrderNo = 0;                     // �󒍔ԍ�
            // --- ADD 2009/09/08�A ---------->>>>>
            carInfoRow.CarNote = string.Empty;                     // ���q���l
            carInfoRow.CarAddInfo1 = string.Empty;                     // ���q�ǉ����P
            carInfoRow.CarAddInfo2 = string.Empty;                     // ���q�ǉ����Q
            // PMNS:���Y/�O�ԋ敪�N���A
            // --- ADD 2013/03/21 ---------->>>>>
            carInfoRow.DomesticForeignCode = 0;                 // ���Y/�O�ԋ敪
            // --- ADD 2013/03/21 ----------<<<<<

            try
            {
                // ������Ԃł�CarRelationGuid��Get���ɗ�O�������Ă��܂��̂�Catch����B
                if (carInfoRow.CarRelationGuid != null)
                {
                    // �J���[�E�g�����E�����̏�����
                    this.SelectColorInfo(carInfoRow.CarRelationGuid, string.Empty); // �J���[��� ������
                    this.SelectTrimInfo(carInfoRow.CarRelationGuid, string.Empty); // �g������� ������
                    this.SelectEquipInfo(carInfoRow.CarRelationGuid, new byte[0]); // ������� ������
                }
            }
            catch
            {
                carInfoRow.CarRelationGuid = Guid.Empty;
            }
            // --- ADD 2009/09/08�A ---------->>>>>
        }

        /// <summary>
        /// ���q���e�[�u���̃N���A
        /// </summary>
        /// <param name="carInfoRow">����s�ԍ�</param>
        /// <br>Update Note: 2011/03/28 ������</br>
        /// <br>             Redmine #20177�̑Ή�</br>
        public void ClearCarInfo(ref EstimateInputDataSet.CarInfoRow carInfoRow)
        {
            if (carInfoRow == null) return;

            //carInfoRow.CarRelationGuid = Guid.Empty;            // ���q��񋤒ʃL�[
            //carInfoRow.CustomerCode = 0;                        // ���Ӑ�R�[�h
            // UPD 2011/02/14 --- >>>>
            //carInfoRow.CarMngNo = 0;                            // ���q�Ǘ��ԍ�
            //carInfoRow.CarMngCode = string.Empty;               // ���q�Ǘ��R�[�h
            carInfoRow.CarMngNo = 0;                            // ���q�Ǘ��ԍ�
            carInfoRow.CarMngCode = string.Empty;               // ���q�Ǘ��R�[�h
            // UPD 2011/02/14 --- <<<<
            //carInfoRow.NumberPlate1Code = 0;                    // ���^�������ԍ�
            //carInfoRow.NumberPlate1Name = string.Empty;         // ���^�����ǖ���
            //carInfoRow.NumberPlate2 = string.Empty;             // ���q�o�^�ԍ��i��ʁj
            //carInfoRow.NumberPlate3 = string.Empty;             // ���q�o�^�ԍ��i�J�i�j
            //carInfoRow.NumberPlate4 = 0;                        // ���q�o�^�ԍ��i�v���[�g�ԍ��j
            carInfoRow.EntryDate = DateTime.MinValue;           // �o�^�N����
            // ---UPD 2009/10/22 ----->>>>>
            //carInfoRow.FirstEntryDate = DateTime.MinValue;      // ���N�x
            carInfoRow.FirstEntryDate = 0;      // ���N�x
            // ---UPD 2009/10/22 -----<<<<<
            carInfoRow.MakerCode = 0;                           // ���[�J�[�R�[�h
            carInfoRow.MakerFullName = string.Empty;            // ���[�J�[�S�p����
            carInfoRow.ModelCode = 0;                           // �Ԏ�R�[�h
            carInfoRow.ModelSubCode = 0;                        // �Ԏ�T�u�R�[�h
            carInfoRow.ModelFullName = string.Empty;            // �Ԏ�S�p����
            //carInfoRow.SystematicCode = 0;                      // �n���R�[�h
            //carInfoRow.SystematicName = string.Empty;           // �n������
            // UPD 2011/02/14 --- >>>>
            carInfoRow.ProduceTypeOfYearCd = 0;                 // ���Y�N���R�[�h
            carInfoRow.ProduceTypeOfYearNm = string.Empty;      // ���Y�N������
            carInfoRow.StProduceTypeOfYear = DateTime.MinValue; // �J�n���Y�N��
            carInfoRow.EdProduceTypeOfYear = DateTime.MinValue; // �I�����Y�N��
            // UPD 2011/02/14 --- <<<<
            carInfoRow.DoorCount = 0;                           // �h�A��
            carInfoRow.BodyNameCode = 0;                        // �{�f�B�[���R�[�h
            carInfoRow.BodyName = string.Empty;                 // �{�f�B�[����
            carInfoRow.ExhaustGasSign = string.Empty;           // �r�K�X�L��
            carInfoRow.SeriesModel = string.Empty;              // �V���[�Y�^��
            carInfoRow.CategorySignModel = string.Empty;        // �^���i�ޕʋL���j
            carInfoRow.FullModel = string.Empty;                // �^���i�t���^�j
            carInfoRow.ModelDesignationNo = 0;                  // �^���w��ԍ�
            carInfoRow.CategoryNo = 0;                          // �ޕʔԍ�
            carInfoRow.FrameModel = string.Empty;               // �ԑ�^��
            carInfoRow.FrameNo = string.Empty;                  // �ԑ�ԍ�
            carInfoRow.SearchFrameNo = 0;                       // �ԑ�ԍ��i�����p�j
            carInfoRow.StProduceFrameNo = 0;                    // ���Y�ԑ�ԍ��J�n
            carInfoRow.EdProduceFrameNo = 0;                    // ���Y�ԑ�ԍ��I��
            carInfoRow.ModelGradeNm = string.Empty;             // �^���O���[�h����
            carInfoRow.EngineModelNm = string.Empty;            // �G���W���^������
            carInfoRow.EngineDisplaceNm = string.Empty;         // �r�C�ʖ���
            carInfoRow.EDivNm = string.Empty;                   // E�敪����
            carInfoRow.TransmissionNm = string.Empty;           // �~�b�V��������
            carInfoRow.ShiftNm = string.Empty;                  // �V�t�g����
            carInfoRow.WheelDriveMethodNm = string.Empty;       // �쓮��������
            carInfoRow.AddiCarSpec1 = string.Empty;             // �ǉ�����1
            carInfoRow.AddiCarSpec2 = string.Empty;             // �ǉ�����2
            carInfoRow.AddiCarSpec3 = string.Empty;             // �ǉ�����3
            carInfoRow.AddiCarSpec4 = string.Empty;             // �ǉ�����4
            carInfoRow.AddiCarSpec5 = string.Empty;             // �ǉ�����5
            carInfoRow.AddiCarSpec6 = string.Empty;             // �ǉ�����6
            carInfoRow.AddiCarSpecTitle1 = string.Empty;        // �ǉ������^�C�g��1
            carInfoRow.AddiCarSpecTitle2 = string.Empty;        // �ǉ������^�C�g��2
            carInfoRow.AddiCarSpecTitle3 = string.Empty;        // �ǉ������^�C�g��3
            carInfoRow.AddiCarSpecTitle4 = string.Empty;        // �ǉ������^�C�g��4
            carInfoRow.AddiCarSpecTitle5 = string.Empty;        // �ǉ������^�C�g��5
            carInfoRow.AddiCarSpecTitle6 = string.Empty;        // �ǉ������^�C�g��6
            carInfoRow.RelevanceModel = string.Empty;           // �֘A�^��
            carInfoRow.SubCarNmCd = 0;                          // �T�u�Ԗ��R�[�h
            carInfoRow.ModelGradeSname = string.Empty;          // �^���O���[�h����
            carInfoRow.BlockIllustrationCd = 0;                 // �u���b�N�C���X�g�R�[�h
            carInfoRow.ThreeDIllustNo = 0;                      // 3D�C���X�gNo
            carInfoRow.PartsDataOfferFlag = 0;                  // ���i�f�[�^�񋟃t���O
            carInfoRow.InspectMaturityDate = DateTime.MinValue; // �Ԍ�������
            carInfoRow.LTimeCiMatDate = DateTime.MinValue;      // �O��Ԍ�������
            carInfoRow.CarInspectYear = 0;                      // �Ԍ�����
            carInfoRow.Mileage = 0;                             // ���q���s����
            carInfoRow.CarNo = string.Empty;                    // ����
            // ---UPD 2011/03/28------------->>>>>
            //carInfoRow.FullModelFixedNoAry = null;              // �t���^���Œ�ԍ��z��
            //carInfoRow.FreeSrchMdlFxdNoAry = null;              // ���R�����^���Œ�ԍ��z�� // ADD 2010/04/27
            carInfoRow.FullModelFixedNoAry = new Int32[0];        // �t���^���Œ�ԍ��z��
            carInfoRow.FreeSrchMdlFxdNoAry = new string[0];        // ���R�����^���Œ�ԍ��z��
            // ---UPD 2011/03/28-------------<<<<<
            carInfoRow.ProduceTypeOfYearInput = 0;              // �N��
            carInfoRow.ColorCode = string.Empty;                // �J���[�R�[�h
            carInfoRow.ColorName1 = string.Empty;               // �J���[����
            carInfoRow.TrimCode = string.Empty;                 // �g�����R�[�h
            carInfoRow.TrimName = string.Empty;                 // �g��������
            carInfoRow.AcceptAnOrderNo = 0;                     // �󒍔ԍ�
            // PMNS:���Y/�O�ԋ敪�N���A
            // --- ADD 2013/03/21 ---------->>>>>
            carInfoRow.DomesticForeignCode = 0;                 // ���Y/�O�ԋ敪
            // --- ADD 2013/03/21 ----------<<<<<
            // ---ADD 2011/03/28------------->>>>>
            if (_carInfoDictionary.ContainsKey(carInfoRow.CarRelationGuid))
            {
                _carInfoDictionary.Remove(carInfoRow.CarRelationGuid);
            }
            // ---ADD 2011/03/28-------------<<<<<
        }

        /// <summary>
        /// ���q���e�[�u���̃N���A
        /// </summary>
        /// <param name="carInfoRow">����s�ԍ�</param>
        /// <br>Update Note: 2011/03/28 ������</br>
        /// <br>             Redmine #20177�̑Ή�</br>
        public void ClearCarInfoForModelCode(ref EstimateInputDataSet.CarInfoRow carInfoRow)
        {
            if (carInfoRow == null) return;

            carInfoRow.CarMngNo = 0;                            // ���q�Ǘ��ԍ�
            carInfoRow.CarMngCode = string.Empty;               // ���q�Ǘ��R�[�h
            carInfoRow.EntryDate = DateTime.MinValue;           // �o�^�N����
            carInfoRow.FirstEntryDate = 0;                      // ���N�x
            carInfoRow.ProduceTypeOfYearCd = 0;                 // ���Y�N���R�[�h
            carInfoRow.ProduceTypeOfYearNm = string.Empty;      // ���Y�N������
            carInfoRow.StProduceTypeOfYear = DateTime.MinValue; // �J�n���Y�N��
            carInfoRow.EdProduceTypeOfYear = DateTime.MinValue; // �I�����Y�N��
            carInfoRow.DoorCount = 0;                           // �h�A��
            carInfoRow.BodyNameCode = 0;                        // �{�f�B�[���R�[�h
            carInfoRow.BodyName = string.Empty;                 // �{�f�B�[����
            carInfoRow.ExhaustGasSign = string.Empty;           // �r�K�X�L��
            carInfoRow.SeriesModel = string.Empty;              // �V���[�Y�^��
            carInfoRow.CategorySignModel = string.Empty;        // �^���i�ޕʋL���j
            carInfoRow.FullModel = string.Empty;                // �^���i�t���^�j
            carInfoRow.ModelDesignationNo = 0;                  // �^���w��ԍ�
            carInfoRow.CategoryNo = 0;                          // �ޕʔԍ�
            carInfoRow.FrameModel = string.Empty;               // �ԑ�^��
            carInfoRow.FrameNo = string.Empty;                  // �ԑ�ԍ�
            carInfoRow.SearchFrameNo = 0;                       // �ԑ�ԍ��i�����p�j
            carInfoRow.StProduceFrameNo = 0;                    // ���Y�ԑ�ԍ��J�n
            carInfoRow.EdProduceFrameNo = 0;                    // ���Y�ԑ�ԍ��I��
            carInfoRow.ModelGradeNm = string.Empty;             // �^���O���[�h����
            carInfoRow.EngineModelNm = string.Empty;            // �G���W���^������
            carInfoRow.EngineDisplaceNm = string.Empty;         // �r�C�ʖ���
            carInfoRow.EDivNm = string.Empty;                   // E�敪����
            carInfoRow.TransmissionNm = string.Empty;           // �~�b�V��������
            carInfoRow.ShiftNm = string.Empty;                  // �V�t�g����
            carInfoRow.WheelDriveMethodNm = string.Empty;       // �쓮��������
            carInfoRow.AddiCarSpec1 = string.Empty;             // �ǉ�����1
            carInfoRow.AddiCarSpec2 = string.Empty;             // �ǉ�����2
            carInfoRow.AddiCarSpec3 = string.Empty;             // �ǉ�����3
            carInfoRow.AddiCarSpec4 = string.Empty;             // �ǉ�����4
            carInfoRow.AddiCarSpec5 = string.Empty;             // �ǉ�����5
            carInfoRow.AddiCarSpec6 = string.Empty;             // �ǉ�����6
            carInfoRow.AddiCarSpecTitle1 = string.Empty;        // �ǉ������^�C�g��1
            carInfoRow.AddiCarSpecTitle2 = string.Empty;        // �ǉ������^�C�g��2
            carInfoRow.AddiCarSpecTitle3 = string.Empty;        // �ǉ������^�C�g��3
            carInfoRow.AddiCarSpecTitle4 = string.Empty;        // �ǉ������^�C�g��4
            carInfoRow.AddiCarSpecTitle5 = string.Empty;        // �ǉ������^�C�g��5
            carInfoRow.AddiCarSpecTitle6 = string.Empty;        // �ǉ������^�C�g��6
            carInfoRow.RelevanceModel = string.Empty;           // �֘A�^��
            carInfoRow.SubCarNmCd = 0;                          // �T�u�Ԗ��R�[�h
            carInfoRow.ModelGradeSname = string.Empty;          // �^���O���[�h����
            carInfoRow.BlockIllustrationCd = 0;                 // �u���b�N�C���X�g�R�[�h
            carInfoRow.ThreeDIllustNo = 0;                      // 3D�C���X�gNo
            carInfoRow.PartsDataOfferFlag = 0;                  // ���i�f�[�^�񋟃t���O
            carInfoRow.InspectMaturityDate = DateTime.MinValue; // �Ԍ�������
            carInfoRow.LTimeCiMatDate = DateTime.MinValue;      // �O��Ԍ�������
            carInfoRow.CarInspectYear = 0;                      // �Ԍ�����
            carInfoRow.Mileage = 0;                             // ���q���s����
            carInfoRow.CarNo = string.Empty;                    // ����
            // ---UPD 2011/03/28--------------->>>>>
            //carInfoRow.FullModelFixedNoAry = null;              // �t���^���Œ�ԍ��z��
            //carInfoRow.FreeSrchMdlFxdNoAry = null;              // ���R�����^���Œ�ԍ��z�� // ADD 2010/04/27
            carInfoRow.FullModelFixedNoAry = new Int32[0];        // �t���^���Œ�ԍ��z��
            carInfoRow.FreeSrchMdlFxdNoAry = new string[0];        // ���R�����^���Œ�ԍ��z��
            // ---UPD 2011/03/28---------------<<<<<
            carInfoRow.ProduceTypeOfYearInput = 0;              // �N��
            carInfoRow.ColorCode = string.Empty;                // �J���[�R�[�h
            carInfoRow.ColorName1 = string.Empty;               // �J���[����
            carInfoRow.TrimCode = string.Empty;                 // �g�����R�[�h
            carInfoRow.TrimName = string.Empty;                 // �g��������
            carInfoRow.AcceptAnOrderNo = 0;                     // �󒍔ԍ�
            // PMNS:���Y/�O�ԋ敪�N���A
            // --- ADD 2013/03/21 ---------->>>>>
            carInfoRow.DomesticForeignCode = 0;                 // ���Y/�O�ԋ敪
            // --- ADD 2013/03/21 ----------<<<<<
            // ---ADD 2011/03/28------------->>>>>
            if (_carInfoDictionary.ContainsKey(carInfoRow.CarRelationGuid))
            {
                _carInfoDictionary.Remove(carInfoRow.CarRelationGuid);
            }
            // ---ADD 2011/03/28-------------<<<<<
        }

        /// <summary>
        /// ���q���e�[�u���̐��Y�N���N���A
        /// </summary>
        /// <param name="carInfoRow">����s�ԍ�</param>
        public void ClearCarInfoForProduceTypeOfYear(ref EstimateInputDataSet.CarInfoRow carInfoRow)
        {
            if (carInfoRow == null) return;

            carInfoRow.ProduceTypeOfYearInput = 0;
        }

        /// <summary>
        /// ���q���e�[�u���̃J���[���N���A
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        public void ClearCarInfoRowForColorInfo( Guid carRelationGuid )
        {
            // ���q���s�I�u�W�F�N�g�擾
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
            if (carInfoRow != null)
            {
                carInfoRow.ColorCode = string.Empty; // �J���[�R�[�h
                carInfoRow.ColorName1 = string.Empty; // �J���[����
            }
        }

        /// <summary>
        /// ���q���e�[�u���̃g�������N���A
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        public void ClearCarInfoRowForTrimInfo( Guid carRelationGuid )
        {
            // ���q���s�I�u�W�F�N�g�擾
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
            if (carInfoRow != null)
            {
                carInfoRow.TrimCode = string.Empty; // �g�����R�[�h
                carInfoRow.TrimName = string.Empty; // �g��������
            }
        }

        /// <summary>
        /// ���q���e�[�u���s�폜
        /// </summary>
        /// <param name="selectedSalesRowNoList">�I�𔄏㖾�׍s�ԍ����X�g</param>
        public void DeleteCarInfoRow( List<int> selectedSalesRowNoList )
        {
            foreach (int salesRowNo in selectedSalesRowNoList)
            {
                // ���㖾�׍s�I�u�W�F�N�g�擾
                EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
                this.DeleteCarInfoRow(salesDetailRow.CarRelationGuid);
            }
        }

        /// <summary>
        /// ���q���e�[�u���s�폜
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        public void DeleteCarInfoRow( Guid carRelationGuid )
        {
            // ���q���s�I�u�W�F�N�g�擾
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
            if (carInfoRow == null) return;
            this._carInfoDataTable.RemoveCarInfoRow(carInfoRow);
        }

        /// <summary>
        /// �Ώۍs�̎��q���s�I�u�W�F�N�g���擾
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="getCarInfoMode">���q���擾���[�h</param>
        /// <returns>���q���s�I�u�W�F�N�g</returns>
        public EstimateInputDataSet.CarInfoRow GetCarInfoRow(int salesRowNo, EstimateInputAcs.GetCarInfoMode getCarInfoMode)
        {
            return this.GetCarInfoRow(null, salesRowNo, getCarInfoMode);
        }

        /// <summary>
        /// �Ώۍs�̎��q���s�I�u�W�F�N�g���擾
        /// </summary>
        /// <param name="baseSalesSlip">����������f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="getCarInfoMode">���q���擾���[�h</param>
        /// <returns>���q���s�I�u�W�F�N�g</returns>
        public EstimateInputDataSet.CarInfoRow GetCarInfoRow(SalesSlip baseSalesSlip, int salesRowNo, EstimateInputAcs.GetCarInfoMode getCarInfoMode)
        {
            // ���㖾�׃f�[�^�s�I�u�W�F�N�g�擾
            string slipNum = this._currentSalesSlipNum;

            if (baseSalesSlip != null)
            {
                slipNum = baseSalesSlip.SalesSlipNum;
            }

            // ���㖾�׃f�[�^�s�I�u�W�F�N�g�擾
            //EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(slipNum, salesRowNo);
            EstimateInputDataSet.CarInfoRow carInfoRow = null;


            if (salesDetailRow != null)
            {
                // ���q���f�[�^�s�I�u�W�F�N�g�擾
                carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(salesDetailRow.CarRelationGuid);

                switch (getCarInfoMode)
                {
                    //--------------------------------------------------------------------------
                    // �V�K�o�^���[�h
                    //--------------------------------------------------------------------------
                    //      �w����q��񂪑��݂��Ȃ��ꍇ�A�V�K�s�ǉ�����B
                    //--------------------------------------------------------------------------
                    case GetCarInfoMode.NewInsertMode:
                        if (carInfoRow == null)
                        {
                            carInfoRow = this.AddCarInfoRow(slipNum, salesRowNo);
                        }
                        break;
                    //--------------------------------------------------------------------------
                    // �����C�����[�h�i�V�K�ǉ��Ȃ��j
                    //--------------------------------------------------------------------------
                    //      �w����q��񂪑��݂��Ȃ��ꍇ�A�O����q�����擾�B
                    //      ���㖾�׍s�I�u�W�F�N�g�̎��q���ʃL�[�Z�b�g�Ȃ��B
                    //--------------------------------------------------------------------------
                    case GetCarInfoMode.ExistGetMode:
                        if (carInfoRow == null)
                        {
                            carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(this._beforeCarRelationGuid);
                        }
                        break;
                    //--------------------------------------------------------------------------
                    // ���q���ύX���[�h(�V�K�ǉ��Ȃ�)
                    //--------------------------------------------------------------------------
                    //      �w����q��񂪑��݂��Ȃ��A���ד��͂���̏ꍇ�A�O����q�����擾�B
                    //      ���㖾�׍s�I�u�W�F�N�g�̎��q���ʃL�[�Z�b�g����B
                    //--------------------------------------------------------------------------
                    case GetCarInfoMode.CarInfoChangeMode:
                        if (carInfoRow == null)
                        {
                            if (this.ExistDetailInput(salesRowNo) == true)
                            {
                                salesDetailRow.CarRelationGuid = this._beforeCarRelationGuid;
                                carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(salesDetailRow.CarRelationGuid);
                            }
                        }
                        break;
                }
            }
            return carInfoRow;
        }

        /// <summary>
        /// ���q���e�[�u���s�̌^���w��ԍ�����їޕʋ敪�ԍ��Z�b�g
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="modelDesignationNo">�^���w��ԍ�</param>
        /// <param name="categoryNo">�ޕʋ敪�ԍ�</param>
        public void SettingCarInfoRowFromCategoryNoAndDesignationNo( int salesRowNo, Guid carRelationGuid, int modelDesignationNo, int categoryNo )
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, EstimateInputAcs.GetCarInfoMode.ExistGetMode);
            if (carInfoRow != null)
            {
                carInfoRow.ModelDesignationNo = modelDesignationNo; // �^���w��ԍ�
                carInfoRow.CategoryNo = categoryNo; // �ޕʋ敪�ԍ�
            }
        }


        /// <summary>
        /// ���q���e�[�u���s�̌^���Z�b�g
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="fullModel">�^��</param>
        public void SettingCarInfoRowFromFullModel( int salesRowNo, Guid carRelationGuid, string fullModel )
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, GetCarInfoMode.ExistGetMode);
            if (carInfoRow != null)
            {
                carInfoRow.FullModel = fullModel;
            }
        }

        /// <summary>
        /// ���q���e�[�u���s�̃G���W���^���Z�b�g
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="engineModelNm">�G���W���^��</param>
        public void SettingCarInfoRowFromEngineModelNm( int salesRowNo, string engineModelNm )
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, GetCarInfoMode.ExistGetMode);

            if (carInfoRow != null)
            {
                carInfoRow.EngineModelNm = engineModelNm;
            }
        }

        /// <summary>
        /// ���q���e�[�u���s�̔N���Z�b�g
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="firstEntryDate">�N��</param>
        public void SettingCarInfoRowFromFirstEntryDate( int salesRowNo, int firstEntryDate )
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, GetCarInfoMode.ExistGetMode);

            if (carInfoRow != null)
            {
                if (firstEntryDate != 0)
                {
                    carInfoRow.ProduceTypeOfYearInput = firstEntryDate / 100;
                }
                else
                {
                    carInfoRow.ProduceTypeOfYearInput = 0;
                }
            }
        }

        /// <summary>
        /// ���q���e�[�u���s�̎ԑ�ԍ��Z�b�g
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="frameNo">�ԑ�ԍ�</param>
        public void SettingCarInfoRowFromFrameNo(int salesRowNo, Guid carRelationGuid, string frameNo)
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, GetCarInfoMode.ExistGetMode);
            if (carInfoRow != null)
            {
                carInfoRow.FrameNo = frameNo;
                // --- DEL 2013/03/21 ---------->>>>>
                //carInfoRow.SearchFrameNo = TStrConv.StrToIntDef(frameNo.Trim(), 0);
                // --- DEL 2013/03/21 ----------<<<<<
                // --- ADD 2013/03/21 ---------->>>>>
                // PMNS:�ԑ�ԍ�(�����p)�ݒ�
                // ���Y/�O�ԋ敪���O��(2)�̏ꍇ�͎ԑ�ԍ�(�����p)��0���Z�b�g����
                if (carInfoRow.DomesticForeignCode == 2)
                {
                    carInfoRow.SearchFrameNo = 0;
                }
                else
                {
                carInfoRow.SearchFrameNo = TStrConv.StrToIntDef(frameNo.Trim(), 0);
            }
                // --- ADD 2013/03/21 ----------<<<<<
            }
        }

        /// <summary>
        /// ���q���e�[�u���s�̎Ԏ���Z�b�g(�J�[���[�J�[�A�Ԏ�R�[�h�A�Ԏ�T�u�R�[�h)
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="makerCode">�J�[���[�J�[�R�[�h</param>
        /// <param name="makerFullName">���[�J�[�S�p����</param>
        /// <param name="makerHalfName">���[�J�[���p����</param>
        /// <param name="modelCode">�Ԏ�R�[�h</param>
        /// <param name="modelSubCode">�Ԏ�T�u�R�[�h</param>
        /// <param name="modelFullName">�Ԏ�S�p����</param>
        /// <param name="modelHalfName">�Ԏ피�p����</param>
        public void SettingCarInfoRowFromModelInfo(int salesRowNo, int makerCode, string makerFullName, string makerHalfName, int modelCode, int modelSubCode, string modelFullName, string modelHalfName)
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, GetCarInfoMode.ExistGetMode);
            if (carInfoRow != null)
            {
                carInfoRow.MakerCode = makerCode;
                carInfoRow.MakerFullName = makerFullName;
                carInfoRow.MakerHalfName = makerHalfName;
                carInfoRow.ModelCode = modelCode;
                carInfoRow.ModelSubCode = modelSubCode;
                carInfoRow.ModelFullName = modelFullName;
                carInfoRow.ModelHalfName = modelHalfName;

                if (( modelCode == 0 ) && ( modelSubCode == 0 ))
                {
                    carInfoRow.ModelFullName = makerFullName;
                    carInfoRow.ModelHalfName = makerHalfName;
                }
            }
        }


        /// <summary>
        /// ���q���e�[�u���s�̎Ԏ���Z�b�g(�Ԏ�}�X�^)
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="modelNameU">�Ԏ�}�X�^�I�u�W�F�N�g</param>
        public void SettingCarInfoRowFromModelInfo( int salesRowNo, ModelNameU modelNameU )
        {
            string makerName, makerKanaName;
            this._estimateInputInitDataAcs.GetName_FromMaker(modelNameU.MakerCode, out makerName, out makerKanaName);
            this.SettingCarInfoRowFromModelInfo(salesRowNo, modelNameU.MakerCode, makerName, makerKanaName, modelNameU.ModelCode, modelNameU.ModelSubCode, modelNameU.ModelFullName, modelNameU.ModelHalfName);

            //EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, GetCarInfoMode.ExistGetMode);
            //if (carInfoRow != null)
            //{
            //    carInfoRow.MakerCode = modelNameU.MakerCode;
            //    carInfoRow.MakerFullName = makerName;
            //    carInfoRow.MakerHalfName = makerKanaName;
            //    carInfoRow.ModelCode = modelNameU.ModelCode;
            //    carInfoRow.ModelSubCode = modelNameU.ModelSubCode;
            //    carInfoRow.ModelFullName = modelNameU.ModelFullName;
            //    carInfoRow.ModelHalfName = modelNameU.ModelHalfName;
            //}
        }

        /// <summary>
        /// ���q���e�[�u���s�̃J�[���[�J�[���Z�b�g
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="makerCode">�J�[���[�J�[�R�[�h</param>
        /// <param name="makerFullName">���[�J�[�S�p����</param>
        /// <param name="makerHalfName">���[�J�[���p����</param>
        public void SettingCarInfoRowFromMakerInfo(int salesRowNo, int makerCode, string makerFullName, string makerHalfName)
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, GetCarInfoMode.ExistGetMode);
            if (carInfoRow != null)
            {
                carInfoRow.MakerCode = makerCode;
                carInfoRow.MakerFullName = makerFullName;
                carInfoRow.MakerHalfName = makerHalfName;
            }
        }

        /// <summary>
        /// ���q���e�[�u���s�̃J���[���Z�b�g
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="colorInfoRow">�J���[���s�I�u�W�F�N�g</param>
        private void SettingCarInfoRowFromColorInfo( Guid carRelationGuid, PMKEN01010E.ColorCdInfoRow colorInfoRow )
        {
            // ���q���s�I�u�W�F�N�g�擾
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
            if (carInfoRow != null)
            {
                carInfoRow.ColorCode = colorInfoRow.ColorCode; // �J���[�R�[�h
                carInfoRow.ColorName1 = colorInfoRow.ColorName1; // �J���[����
            }
        }

        // --- ADD 2012/09/07 Y.Wakita ---------->>>>>
        /// <summary>
        /// �ԗ����e�[�u���s�̃J���[���Z�b�g
        /// </summary>
        /// <param name="carRelationGuid">�ԗ���񋤒ʃL�[</param>
        /// <param name="colorCode">�J���[�R�[�h</param>
        private bool SettingCarInfoRowFromColorCode(Guid carRelationGuid, string colorCode)
        {
            bool ret = false;
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            // �ԗ����s�I�u�W�F�N�g�擾
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
            if (carInfoRow != null)
            {
                CarMangInputExtraInfo selectedInfo;
                status = SearchCarManagement(carInfoRow, out selectedInfo);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (selectedInfo.ColorCode == colorCode)
                    {
                        carInfoRow.ColorCode = colorCode;   // �J���[�R�[�h
                        ret = true;
                    }
                }
                // --- DEL 2012/09/11 Y.Wakita ---------->>>>>
                //else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                //{
                //    if (carInfoRow.CarMngCode != "")
                //    {
                //        carInfoRow.ColorCode = colorCode;   // �J���[�R�[�h
                //        ret = true;
                //    }
                //}
                // --- DEL 2012/09/11 Y.Wakita ----------<<<<<
            }
            return ret;
        }
        // --- ADD 2012/09/07 Y.Wakita ----------<<<<<

        /// <summary>
        /// ���q���e�[�u���s�̃g�������Z�b�g
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="trimInfoRow">�g�������s�I�u�W�F�N�g</param>
        private void SettingCarInfoRowFromTrimInfo( Guid carRelationGuid, PMKEN01010E.TrimCdInfoRow trimInfoRow )
        {
            // ���q���s�I�u�W�F�N�g�擾
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
            if (carInfoRow != null)
            {
                carInfoRow.TrimCode = trimInfoRow.TrimCode; // �g�����R�[�h
                carInfoRow.TrimName = trimInfoRow.TrimName; // �g��������
            }
        }

        /// <summary>
        /// ���q���e�[�u���s�̑������Z�b�g
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        private void SettingCarInfoRowFromTrimInfo( Guid carRelationGuid )
        {
            // �ݒ�p�������f�[�^�e�[�u��
            PMKEN01010E.CEqpDefDspInfoDataTable equipInfoDataTableForSave = new PMKEN01010E.CEqpDefDspInfoDataTable();

            // ���q���s�I�u�W�F�N�g�擾
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);

            // �������f�[�^�e�[�u���擾
            PMKEN01010E.CEqpDefDspInfoDataTable equipInfoDataTable = this._cEqpDspInfoDic[carRelationGuid];

            if (carInfoRow != null)
            {
                foreach (PMKEN01010E.CEqpDefDspInfoRow equipInfoRow in equipInfoDataTable)
                {
                    if (equipInfoRow.SelectionState == true)
                    {
                        PMKEN01010E.CEqpDefDspInfoRow newEquipInfoRow = equipInfoDataTableForSave.NewCEqpDefDspInfoRow();
                        newEquipInfoRow = equipInfoRow;
                    }
                }
                //carInfoRow.CategoryObjAry = equipInfoDataTableForSave.Clone(); // �����I�u�W�F�N�g�z��
            }
        }

        // --- ADD 2012/09/07 Y.Wakita ---------->>>>>
        /// <summary>
        /// �ԗ����e�[�u���s�̃g�������Z�b�g
        /// </summary>
        /// <param name="carRelationGuid">�ԗ���񋤒ʃL�[</param>
        /// <param name="colorInfoRow">�J���[���s�I�u�W�F�N�g</param>
        private bool SettingCarInfoRowFromTrimCode(Guid carRelationGuid, string trimCode)
        {
            bool ret = false;
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            // �ԗ����s�I�u�W�F�N�g�擾
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
            if (carInfoRow != null)
            {
                CarMangInputExtraInfo selectedInfo;
                status = SearchCarManagement(carInfoRow, out selectedInfo);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (selectedInfo.TrimCode == trimCode)
                    {
                        carInfoRow.TrimCode = trimCode; // �g�����R�[�h
                        ret = true;
                    }
                }
                // --- DEL 2012/09/11 Y.Wakita ---------->>>>>
                //else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                //{
                //    if (carInfoRow.CarMngCode != "")
                //    {
                //        carInfoRow.TrimCode = trimCode; // �g�����R�[�h
                //        ret = true;
                //    }
                //}
                // --- DEL 2012/09/11 Y.Wakita ----------<<<<<
            }
            return ret;
        }
        // --- ADD 2012/09/07 Y.Wakita ----------<<<<<

        /// <summary>
        /// ���q���e�[�u���s�̔N���Z�b�g
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="firstEntryDate">�N��</param>
        public void SettingCarInfoRowFromFirstEntryDate( Guid carRelationGuid, int firstEntryDate )
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
            if (carInfoRow != null)
            {
                carInfoRow.ProduceTypeOfYearInput = firstEntryDate;
            }
        }

        /// <summary>
        /// ���q���e�[�u���s�̎ԑ�ԍ��Z�b�g
        /// </summary>
        /// <param name="salesRowNo">�s�ԍ�</param>
        /// <param name="frameNo">�ԑ�ԍ�</param>
        public void SettingCarInfoRowFromFrameNo(int salesRowNo, string frameNo)
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, GetCarInfoMode.ExistGetMode);
            if (carInfoRow != null)
            {
                //carInfoRow.ProduceFrameNoInput = produceFrameNo;
                carInfoRow.FrameNo = frameNo;
                // --- DEL 2013/03/21 ---------->>>>>
                //carInfoRow.SearchFrameNo = TStrConv.StrToIntDef(frameNo.Trim(), 0);
                // --- DEL 2013/03/21 ----------<<<<<
                // --- ADD 2013/03/21 ---------->>>>>
                // PMNS:�ԑ�ԍ�(�����p)�ݒ�
                // ���Y/�O�ԋ敪���O��(2)�̏ꍇ�͎ԑ�ԍ�(�����p)��0���Z�b�g����
                if (carInfoRow.DomesticForeignCode == 2)
                {
                    carInfoRow.SearchFrameNo = 0;
                }
                else
                {
                carInfoRow.SearchFrameNo = TStrConv.StrToIntDef(frameNo.Trim(), 0);
            }
                // --- ADD 2013/03/21 ----------<<<<<
            }
        }

        /// <summary>
        /// ���q���e�[�u���s�̊Ǘ��ԍ��Z�b�g
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="carMngCode">�Ǘ��ԍ�</param>
        public void SettingCarInfoRowFromCarMngCode(int salesRowNo, string carMngCode)
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, GetCarInfoMode.ExistGetMode);
            if (carInfoRow != null)
            {
                carInfoRow.CarMngCode= carMngCode;
                // --- ADD 2009/10/16 ------>>>>>
                if (string.Empty.Equals(carMngCode))
                {
                    carInfoRow.Mileage = 0;
                    carInfoRow.CarNote = string.Empty;
                    carInfoRow.CarMngNo = 0;
                    carInfoRow.NumberPlate1Code = 0;
                    carInfoRow.NumberPlate1Name = string.Empty;
                    carInfoRow.NumberPlate2 = string.Empty;
                    carInfoRow.NumberPlate3 = string.Empty;
                    carInfoRow.NumberPlate4 = 0;
                }
                // --- ADD 2009/10/16 ------<<<<<
            }
        }

        /// <summary>
        /// ���㖾�׃f�[�^�e�[�u���̎��q���L�[�Z�b�g
        /// </summary>
        /// <param name="salesDetailRow">���㖾�׍s�I�u�W�F�N�g</param>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        public void SettingSalesDetailCarRelationGuid( ref EstimateInputDataSet.EstimateDetailRow salesDetailRow, Guid carRelationGuid )
        {
            if (salesDetailRow != null)
            {
                salesDetailRow.CarRelationGuid = carRelationGuid;
            }
        }

        /// <summary>
        /// ���㖾�׃f�[�^�e�[�u���̎��q���L�[�N���A
        /// </summary>
        /// <param name="selectedSalesRowNoList">���㖾�׃f�[�^�e�[�u���I���s�ԍ����X�g</param>
        public void ClearSalesDetailCarInfoRow( List<int> selectedSalesRowNoList )
        {
            foreach (int salesRowNo in selectedSalesRowNoList)
            {
                this.ClearSalesDetailCarInfoRow(salesRowNo);
            }
        }

        /// <summary>
        /// ���㖾�׃f�[�^�e�[�u���̎��q���L�[�N���A
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        public void ClearSalesDetailCarInfoRow( int salesRowNo )
        {
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (salesDetailRow == null) return;
            salesDetailRow.CarRelationGuid = Guid.Empty;
        }

        /// <summary>
        /// ���㖾�׃f�[�^�e�[�u���̎��q���L�[�N���A
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        public void ClearSalesDetailCarInfoRow( Guid carRelationGuid )
        {
            EstimateInputDataSet.EstimateDetailRow[] rows = (EstimateInputDataSet.EstimateDetailRow[])this._estimateDetailDataTable.Select(string.Format("{0}={1}", this._estimateDetailDataTable.CarRelationGuidColumn.ColumnName, carRelationGuid));

            foreach (EstimateInputDataSet.EstimateDetailRow row in rows)
            {
                row.CarRelationGuid = Guid.Empty;
            }
        }

        /// <summary>
        /// �������q�����f�B�N�V���i���ɃL���b�V�����܂��B
        /// </summary>
        /// <param name="carRelationGuid"></param>
        /// <param name="carInfo"></param>
        private void CacheSearchCarInfo( Guid carRelationGuid, PMKEN01010E carInfo )
        {
            if (this._carInfoDictionary.ContainsKey(carRelationGuid))
            {
                this._carInfoDictionary[carRelationGuid] = carInfo;
            }
            else
            {
                this._carInfoDictionary.Add(carRelationGuid, carInfo);
            }
        }

        /// <summary>
        /// �w��s�̌������q�����擾���܂��B
        /// </summary>
        /// <param name="salesRowNo"></param>
        /// <returns></returns>
        public PMKEN01010E GetSearchCarInfo( int salesRowNo )
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (( row != null ) && ( row.CarRelationGuid != Guid.Empty ))
            {
                return this.GetSearchCarInfo(row.CarRelationGuid);
            }
            else
            {
                return this.GetSearchCarInfo(this._beforeCarRelationGuid);
            }
        }

        /// <summary>
        /// �w��s�̌������q�����擾���܂��B
        /// </summary>
        /// <param name="salesRowNo"></param>
        /// <returns>�ԗ��������ʃf�[�^�Z�b�g</returns>
        /// <remarks>
        /// <br>Note       : �w��s�̌������q�����擾���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009/11/05</br>
        /// </remarks>
        public PMKEN01010E GetSearchCarInfoNew(int salesRowNo)
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if ((row != null) && (row.CarRelationGuid != Guid.Empty))
            {
                return this.GetSearchCarInfoNew(row.CarRelationGuid);
            }
            else
            {
                return this.GetSearchCarInfoNew(this._beforeCarRelationGuid);
            }
        }

        /// <summary>
        /// �ԗ����e�[�u���擾����(�ԗ����Dictionary���擾)
        /// </summary>
        /// <param name="carRelationGuid">�ԗ���񋤒ʃL�[</param>
        /// <returns>�ԗ��������ʃf�[�^�Z�b�g</returns>
        /// <remarks>
        /// <br>Note       : �w��s�̌������q�����擾���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009/11/05</br>
        /// </remarks>
        private PMKEN01010E GetSearchCarInfoNew(Guid carRelationGuid)
        {
            PMKEN01010E carInfoDataSet = new PMKEN01010E();
            if (this._carInfoDictionary.ContainsKey(carRelationGuid))
            {
                carInfoDataSet = this._carInfoDictionary[carRelationGuid];
                EstimateInputDataSet.CarInfoRow row = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
                if (row != null)
                {
                    carInfoDataSet.CarModelInfoSummarized[0].MakerCode = row.MakerCode;
                }
                else
                {
                    carInfoDataSet = null;
                }
            }
            else
            {
                carInfoDataSet = null;
 
            }
            return carInfoDataSet;
        }

        /// <summary>
        /// �w�肳��Ď��q�A��GUID�̌������q�����擾���܂��B
        /// </summary>
        /// <param name="carRelationGuid"></param>
        /// <returns></returns>
        private PMKEN01010E GetSearchCarInfo( Guid carRelationGuid )
        {
            return ( this._carInfoDictionary.ContainsKey(carRelationGuid) ) ? this._carInfoDictionary[carRelationGuid] : null;
        }

        /// <summary>
        /// ���q���L���b�V���i���q������񂩂�L���b�V���j
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="searchCarInfo">���q�������ʃN���X</param>
        public void CacheCarInfo( int salesRowNo, PMKEN01010E searchCarInfo )
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, EstimateInputAcs.GetCarInfoMode.ExistGetMode);
            EstimateInputDataSet.EstimateDetailRow estimateDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            this.CacheCarInfo(ref carInfoRow, estimateDetailRow, searchCarInfo);
        }

        /// <summary>
        /// �ԗ����L���b�V���i�ԗ��������{���o�\�t��񂩂�L���b�V���j
        /// </summary>
        /// <param name="salesRowNo"></param>
        /// <param name="searchCarInfo"></param>
        /// <param name="salesSlipHeaderCopyData"></param>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/09/08�A</br>
        public void CacheCarInfoForSlipHeaderCopy(int salesRowNo, PMKEN01010E searchCarInfo, SalesSlipHeaderCopyData salesSlipHeaderCopyData)
        {
            //----------------------------------------
            // �W���̃L���b�V������
            //----------------------------------------
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(salesRowNo, EstimateInputAcs.GetCarInfoMode.NewInsertMode);
            EstimateInputDataSet.EstimateDetailRow estimateDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
                this.CacheCarInfo(ref carInfoRow, estimateDetailRow, searchCarInfo);


            //----------------------------------------
            // ���o�\�t�p�̃L���b�V������
            //----------------------------------------
            carInfoRow.CarMngCode = salesSlipHeaderCopyData.CarMngCode; // ���q�Ǘ��ԍ�
            carInfoRow.ModelDesignationNo = salesSlipHeaderCopyData.ModelDesignationNo; // �^���w��ԍ�
            carInfoRow.CategoryNo = salesSlipHeaderCopyData.CategoryNo; // �ޕʔԍ�
            // --- ADD 2009/10/22 ----->>>>>
            //carInfoRow.FirstEntryDate = TDateTime.LongDateToDateTime(salesSlipHeaderCopyData.FirstEntryDate); // �N��
            carInfoRow.FirstEntryDate = salesSlipHeaderCopyData.FirstEntryDate;
            //carInfoRow.ProduceTypeOfYearInput = salesSlipHeaderCopyData.FirstEntryDate / 100; // ���N�x
            carInfoRow.ProduceTypeOfYearInput = salesSlipHeaderCopyData.FirstEntryDate;
            // --- ADD 2009/10/22 -----<<<<<
            carInfoRow.FrameNo = salesSlipHeaderCopyData.FrameNo; // �ԑ�ԍ�

            // --- ADD 2009/09/08�A ---------->>>>>
            carInfoRow.CarMngNo = salesSlipHeaderCopyData.CarMngNo; // �ԗ��Ǘ��ԍ�
            carInfoRow.NumberPlate1Code = salesSlipHeaderCopyData.NumberPlate1Code; //���^�������ԍ�
            carInfoRow.NumberPlate1Name = salesSlipHeaderCopyData.NumberPlate1Name; //���^�����ǖ���
            carInfoRow.NumberPlate2 = salesSlipHeaderCopyData.NumberPlate2; //�ԗ��o�^�ԍ��i��ʁj
            carInfoRow.NumberPlate3 = salesSlipHeaderCopyData.NumberPlate3; //�ԗ��o�^�ԍ��i�J�i�j
            carInfoRow.NumberPlate4 = salesSlipHeaderCopyData.NumberPlate4; //�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            carInfoRow.Mileage = salesSlipHeaderCopyData.Mileage; //�ԗ����s����
            carInfoRow.CarNote = salesSlipHeaderCopyData.CarNote; //���q���l
            // �t���^��
            carInfoRow.FullModel = salesSlipHeaderCopyData.FullModel;
            // �G���W���^��
            carInfoRow.EngineModelNm = salesSlipHeaderCopyData.EngineModelNm;
            carInfoRow.MakerCode = salesSlipHeaderCopyData.MakerCode; // �Ԏ탁�[�J�[�R�[�h
            carInfoRow.ModelCode = salesSlipHeaderCopyData.ModelCode; // �Ԏ�R�[�h
            carInfoRow.ModelSubCode = salesSlipHeaderCopyData.ModelSubCode; // �Ԏ�T�u�R�[�h
            carInfoRow.ModelFullName = salesSlipHeaderCopyData.ModelFullName; // �Ԏ�S�p����
            // --- ADD 2009/09/08�A ----------<<<<<

            // PMNS:���Y/�O�ԋ敪�Z�b�g
            // --- ADD 2013/03/21 ---------->>>>>
            carInfoRow.DomesticForeignCode = salesSlipHeaderCopyData.DomesticForeignCode; // ���Y/�O�ԋ敪
            // --- ADD 2013/03/21 ----------<<<<<

            try
            {
                // --- DEL 2013/03/21 ---------->>>>>
                //carInfoRow.SearchFrameNo = Int32.Parse(carInfoRow.FrameNo);
                // --- DEL 2013/03/21 ----------<<<<<
                // --- ADD 2013/03/21 ---------->>>>>
                // PMNS:�ԑ�ԍ�(�����p)�ݒ�
                // ���Y/�O�ԋ敪���O��(2)�̏ꍇ�͎ԑ�ԍ�(�����p)��0���Z�b�g����
                if (carInfoRow.DomesticForeignCode == 2)
                {
                    carInfoRow.SearchFrameNo = 0;
                }
                else
                {
                carInfoRow.SearchFrameNo = Int32.Parse(carInfoRow.FrameNo);
            }
                // --- ADD 2013/03/21 ----------<<<<<
            }
            catch
            {
                carInfoRow.SearchFrameNo = 0;
            }

            this.SelectColorInfo(estimateDetailRow.CarRelationGuid, salesSlipHeaderCopyData.ColorCode); // �J���[���
            this.SelectTrimInfo(estimateDetailRow.CarRelationGuid, salesSlipHeaderCopyData.TrimCode); // �g�������
            this.SelectEquipInfo(estimateDetailRow.CarRelationGuid, salesSlipHeaderCopyData.CategoryObjAry); // �������
        }

        /// <summary>
        /// ���q���L���b�V���i���q������񂩂�L���b�V���j
        /// </summary>
        /// <param name="carInfoRow">���q���s�I�u�W�F�N�g</param>
        /// <param name="salesDetailRow">���㖾�׍s�I�u�W�F�N�g</param>
        /// <param name="searchCarInfo">���q�������ʃN���X</param>
        /// <br>Update Note: 2011/02/14 ������</br>
        /// <br>             �f�[�^�o�^���̎ԑ�ԍ��͈̓Z�b�g�̏C��</br>
        private void CacheCarInfo( ref EstimateInputDataSet.CarInfoRow carInfoRow, EstimateInputDataSet.EstimateDetailRow salesDetailRow, PMKEN01010E searchCarInfo )
        {
            PMKEN01010E.CarModelUIDataTable carModelUIDataTable = searchCarInfo.CarModelUIData; // �t�h�p�^�����e�[�u��
            PMKEN01010E.CarModelInfoDataTable carModelInfoDataTable = searchCarInfo.CarModelInfoSummarized; // �^�����v��e�[�u��
             // --- UPD 2009/10/16 ---------->>>>>
            if (carModelInfoDataTable != null && carModelInfoDataTable.Count > 0)
            {
                carInfoRow.CarRelationGuid = salesDetailRow.CarRelationGuid; // ���q��񋤒ʃL�[
                //carInfoRow.CustomerCode = carModelInfoDataTable[0].CustomerCode; // ���Ӑ�R�[�h
                //carInfoRow.CarMngNo = carModelInfoDataTable[0].CarMngNo; // ���q�Ǘ��ԍ�
                //carInfoRow.CarMngCode = carModelInfoDataTable[0].CarMngCode; // ���q�Ǘ��R�[�h
                //carInfoRow.NumberPlate1Code = carModelInfoDataTable[0].NumberPlate1Code; // ���^�������ԍ�
                //carInfoRow.NumberPlate1Name = carModelInfoDataTable[0].NumberPlate1Name; // ���^�����ǖ���
                //carInfoRow.NumberPlate2 = carModelInfoDataTable[0].NumberPlate2; // ���q�o�^�ԍ��i��ʁj
                //carInfoRow.NumberPlate3 = carModelInfoDataTable[0].NumberPlate3; // ���q�o�^�ԍ��i�J�i�j
                //carInfoRow.NumberPlate4 = carModelInfoDataTable[0].NumberPlate4; // ���q�o�^�ԍ��i�v���[�g�ԍ��j
                //carInfoRow.EntryDate = carModelInfoDataTable[0].EntryDate; // �o�^�N����
                //carInfoRow.FirstEntryDate = carModelInfoDataTable[0].FirstEntryDate; // ���N�x
                carInfoRow.MakerCode = carModelInfoDataTable[0].MakerCode; // ���[�J�[�R�[�h
                carInfoRow.MakerFullName = carModelInfoDataTable[0].MakerFullName; // ���[�J�[�S�p����
                carInfoRow.MakerHalfName = carModelInfoDataTable[0].MakerHalfName; // ���[�J�[���p����
                carInfoRow.ModelCode = carModelInfoDataTable[0].ModelCode; // �Ԏ�R�[�h
                carInfoRow.ModelSubCode = carModelInfoDataTable[0].ModelSubCode; // �Ԏ�T�u�R�[�h
                carInfoRow.ModelFullName = carModelInfoDataTable[0].ModelFullName; // �Ԏ�S�p����
                carInfoRow.ModelHalfName = carModelInfoDataTable[0].ModelHalfName; // �Ԏ피�p����
                carInfoRow.SystematicCode = carModelInfoDataTable[0].SystematicCode; // �n���R�[�h
                carInfoRow.SystematicName = carModelInfoDataTable[0].SystematicName; // �n������
                carInfoRow.ProduceTypeOfYearCd = carModelInfoDataTable[0].ProduceTypeOfYearCd; // ���Y�N���R�[�h
                carInfoRow.ProduceTypeOfYearNm = carModelInfoDataTable[0].ProduceTypeOfYearNm; // ���Y�N������
                DateTime sdt;
                DateTime edt;
                int iyy = carModelInfoDataTable[0].StProduceTypeOfYear / 100;
                int imm = carModelInfoDataTable[0].StProduceTypeOfYear % 100;
                if ((iyy == 9999) || (imm == 99))
                {
                    sdt = DateTime.MinValue;
                }
                else
                {
                    sdt = new DateTime(iyy, imm, 1);
                }
                iyy = carModelInfoDataTable[0].EdProduceTypeOfYear / 100;
                imm = carModelInfoDataTable[0].EdProduceTypeOfYear % 100;
                if ((iyy == 9999) || (imm == 99))
                {
                    edt = DateTime.MinValue;
                }
                else
                {
                    edt = new DateTime(iyy, imm, 1);
                }
                carInfoRow.StProduceTypeOfYear = sdt; // �J�n���Y�N��
                carInfoRow.EdProduceTypeOfYear = edt; // �I�����Y�N��
                carInfoRow.ProduceTypeOfYearInput = carModelUIDataTable[0].ProduceTypeOfYearInput; // ���Y�N������
                carInfoRow.DoorCount = carModelInfoDataTable[0].DoorCount; // �h�A��
                carInfoRow.BodyNameCode = carModelInfoDataTable[0].BodyNameCode; // �{�f�B�[���R�[�h
                carInfoRow.BodyName = carModelInfoDataTable[0].BodyName; // �{�f�B�[����
                carInfoRow.ExhaustGasSign = carModelInfoDataTable[0].ExhaustGasSign; // �r�K�X�L��
                carInfoRow.SeriesModel = carModelInfoDataTable[0].SeriesModel; // �V���[�Y�^��
                carInfoRow.CategorySignModel = carModelInfoDataTable[0].CategorySignModel; // �^���i�ޕʋL���j
                carInfoRow.FullModel = carModelInfoDataTable[0].FullModel; // �^���i�t���^�j
                carInfoRow.ModelDesignationNo = carModelUIDataTable[0].ModelDesignationNo; // �^���w��ԍ�
                carInfoRow.CategoryNo = carModelUIDataTable[0].CategoryNo; // �ޕʔԍ�
                carInfoRow.FrameModel = carModelInfoDataTable[0].FrameModel; // �ԑ�^��
                //carInfoRow.FrameNo = carModelInfoDataTable[0].FrameNo; // �ԑ�ԍ�
                //carInfoRow.SearchFrameNo = carModelInfoDataTable[0].SearchFrameNo; // �ԑ�ԍ��i�����p�j
                carInfoRow.FrameNo = carModelUIDataTable[0].FrameNo; // �ԑ�ԍ�
                carInfoRow.SearchFrameNo = carModelUIDataTable[0].SearchFrameNo; // �ԑ�ԍ��i�����p�j
                carInfoRow.StProduceFrameNo = carModelInfoDataTable[0].StProduceFrameNo; // ���Y�ԑ�ԍ��J�n
                carInfoRow.EdProduceFrameNo = carModelInfoDataTable[0].EdProduceFrameNo; // ���Y�ԑ�ԍ��I��
                //carInfoRow.ProduceFrameNoInput = carModelUIDataTable[0].ProduceFrameNoInput; // ���Y�ԑ�ԍ�����
                carInfoRow.ModelGradeNm = carModelInfoDataTable[0].ModelGradeNm; // �^���O���[�h����
                carInfoRow.EngineModelNm = carModelInfoDataTable[0].EngineModelNm; // �G���W���^������
                carInfoRow.EngineDisplaceNm = carModelInfoDataTable[0].EngineDisplaceNm; // �r�C�ʖ���
                carInfoRow.EDivNm = carModelInfoDataTable[0].EDivNm; // E�敪����
                carInfoRow.TransmissionNm = carModelInfoDataTable[0].TransmissionNm; // �~�b�V��������
                carInfoRow.ShiftNm = carModelInfoDataTable[0].ShiftNm; // �V�t�g����
                carInfoRow.WheelDriveMethodNm = carModelInfoDataTable[0].WheelDriveMethodNm; // �쓮��������
                carInfoRow.AddiCarSpec1 = carModelInfoDataTable[0].AddiCarSpec1; // �ǉ�����1
                carInfoRow.AddiCarSpec2 = carModelInfoDataTable[0].AddiCarSpec2; // �ǉ�����2
                carInfoRow.AddiCarSpec3 = carModelInfoDataTable[0].AddiCarSpec3; // �ǉ�����3
                carInfoRow.AddiCarSpec4 = carModelInfoDataTable[0].AddiCarSpec4; // �ǉ�����4
                carInfoRow.AddiCarSpec5 = carModelInfoDataTable[0].AddiCarSpec5; // �ǉ�����5
                carInfoRow.AddiCarSpec6 = carModelInfoDataTable[0].AddiCarSpec6; // �ǉ�����6
                carInfoRow.AddiCarSpecTitle1 = carModelInfoDataTable[0].AddiCarSpecTitle1; // �ǉ������^�C�g��1
                carInfoRow.AddiCarSpecTitle2 = carModelInfoDataTable[0].AddiCarSpecTitle2; // �ǉ������^�C�g��2
                carInfoRow.AddiCarSpecTitle3 = carModelInfoDataTable[0].AddiCarSpecTitle3; // �ǉ������^�C�g��3
                carInfoRow.AddiCarSpecTitle4 = carModelInfoDataTable[0].AddiCarSpecTitle4; // �ǉ������^�C�g��4
                carInfoRow.AddiCarSpecTitle5 = carModelInfoDataTable[0].AddiCarSpecTitle5; // �ǉ������^�C�g��5
                carInfoRow.AddiCarSpecTitle6 = carModelInfoDataTable[0].AddiCarSpecTitle6; // �ǉ������^�C�g��6
                carInfoRow.RelevanceModel = carModelInfoDataTable[0].RelevanceModel; // �֘A�^��
                carInfoRow.SubCarNmCd = carModelInfoDataTable[0].SubCarNmCd; // �T�u�Ԗ��R�[�h
                carInfoRow.ModelGradeSname = carModelInfoDataTable[0].ModelGradeSname; // �^���O���[�h����
                carInfoRow.BlockIllustrationCd = carModelInfoDataTable[0].BlockIllustrationCd; // �u���b�N�C���X�g�R�[�h
                carInfoRow.ThreeDIllustNo = carModelInfoDataTable[0].ThreeDIllustNo; // 3D�C���X�gNo
                carInfoRow.PartsDataOfferFlag = carModelInfoDataTable[0].PartsDataOfferFlag; // ���i�f�[�^�񋟃t���O
                //carInfoRow.InspectMaturityDate = carModelInfoDataTable[0].InspectMaturityDate; // �Ԍ�������
                //carInfoRow.LTimeCiMatDate = carModelInfoDataTable[0].LTimeCiMatDate; // �O��Ԍ�������
                //carInfoRow.CarInspectYear = carModelInfoDataTable[0].CarInspectYear; // �Ԍ�����
                //carInfoRow.Mileage = carModelInfoDataTable[0].Mileage; // ���q���s����
                //carInfoRow.CarNo = carModelInfoDataTable[0].CarNo; // ����
                // --- ADD 2013/03/21 ---------->>>>>
                // PMNS:���Y/�O�ԋ敪�Z�b�g
                carInfoRow.DomesticForeignCode = carModelInfoDataTable[0].DomesticForeignCode;
                // --- ADD 2013/03/21 ----------<<<<<
            }
            // --- UPD 2009/10/16 ----------<<<<<
            // --- UPD 2010/05/20 ---------->>>>>
            //carInfoRow.FullModelFixedNoAry = this._carSearchController.GetFullModelFixedNoArray(carModelInfoDataTable); // �t���^���Œ�ԍ��z��
            int[] tmp = new int[0];
            string[] tmp2 = new string[0];
            // ---UPD 2011/02/14--------------->>>>>
            //this._carSearchController.GetFullModelFixedNoArrayWithFreeSrchMdlFxdNo(carModelInfoDataTable, out tmp, out tmp2);
            this._carSearchController.GetFullModelFixedNoArrayWithFreeSrchMdlFxdNo(searchCarInfo.CarModelInfo, out tmp, out tmp2);
            // ---UPD 2011/02/14---------------<<<<<
            carInfoRow.FullModelFixedNoAry = tmp;
            carInfoRow.FreeSrchMdlFxdNoAry = tmp2;
            // --- UPD 2010/05/20 ---------->>>>>

            //carInfoRow.ProduceFrameNoInput = carModelInfoDataTable[0].ProduceFrameNoInput; // �ԑ�ԍ�
            //carInfoRow.ProduceTypeOfYearInput = carModelInfoDataTable[0].ProduceTypeOfYearInput; // �N��
            //carInfoRow.ColorCode; // �J���[�R�[�h
            //carInfoRow.ColorName1; // �J���[����
            //carInfoRow.TrimCode; // �g�����R�[�h
            //carInfoRow.TrimName; // �g��������

            this.CacheColorInfo(salesDetailRow.SalesSlipNum, salesDetailRow.SalesRowNo, searchCarInfo.ColorCdInfo);                         // �J���[���
            this.CacheTrimInfo(salesDetailRow.SalesSlipNum, salesDetailRow.SalesRowNo, searchCarInfo.TrimCdInfo);                           // �g�������
            this.CacheEquipInfo(salesDetailRow.SalesSlipNum, salesDetailRow.SalesRowNo, searchCarInfo.CEqpDefDspInfo);                      // �������

            carInfoRow.AcceptAnOrderNo = 0; // �󒍔ԍ�


            // ���q���Dictionary�L���b�V��
            if (this._carInfoDictionary.ContainsKey(carInfoRow.CarRelationGuid))
            {
                this._carInfoDictionary.Remove(carInfoRow.CarRelationGuid);
            }
            this._carInfoDictionary.Add(carInfoRow.CarRelationGuid, searchCarInfo);
        }

        /// <summary>
        /// ���q���L���b�V���i�󒍃}�X�^�i���q�j����L���b�V���j
        /// </summary>
        /// <param name="salesRowNo">�ݒ�Ώۍs�ԍ�</param>
        /// <param name="salesDetail">���㖾�׃I�u�W�F�N�g���X�g</param>
        /// <param name="acceptOdrCarList">�󒍃}�X�^�i���q�j�I�u�W�F�N�g���X�g</param>
        /// <br>Note       : �C���ďo���̓`�[���ʂɂ��G���[�C��</br>
        /// <br>Programmer : �{�w�C��</br>
        /// <br>Date       : 2011/02/14</br>
        /// <remarks>Call:���בI��</remarks>
        public void CacheCarInfo(int salesRowNo, SalesDetail salesDetail, List<AcceptOdrCar> acceptOdrCarList)
        {
            SalesSlip baseSalesSlip = null;

            if (acceptOdrCarList != null)
            {
                AcceptOdrCar acceptOdrCar;
                // --- UPD 2011/02/14 ----------------->>>>>>>>>>>>>
                //EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(ctDefaultSalesSlipNum, salesRowNo);
                EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
                // --- UPD 2011/02/14 -----------------<<<<<<<<<<<<<
                acceptOdrCar = this.GetAcceptOdrCar(salesDetail.AcceptAnOrderNo, acceptOdrCarList);
                if (this._carRelationDic.ContainsKey(salesDetail.AcceptAnOrderNo))
                {
                    salesDetailRow.CarRelationGuid = this._carRelationDic[salesDetail.AcceptAnOrderNo];
                }
                else
                {
                    if (acceptOdrCar != null)
                    {
                        this.CacheCarInfo(salesRowNo, null, salesDetail, acceptOdrCar);
                        salesDetailRow.CarRelationGuid = this._carRelationDic[acceptOdrCar.AcceptAnOrderNo];
                    }
                }
            }
        }


        /// <summary>
        /// ���q���L���b�V���i�󒍃}�X�^�i���q�j����L���b�V���j
        /// </summary>
        /// <param name="salesDetail">���㖾�׃I�u�W�F�N�g���X�g</param>
        /// <param name="acceptOdrCarList">�󒍃}�X�^�i���q�j�I�u�W�F�N�g���X�g</param>
        /// <remarks>Call:���בI����</remarks>
        public void CacheCarInfo(SalesDetail salesDetail, List<AcceptOdrCar> acceptOdrCarList)
        {
            SalesSlip baseSalesSlip = null;

            if (acceptOdrCarList != null)
            {
                AcceptOdrCar acceptOdrCar;

                acceptOdrCar = this.GetAcceptOdrCar(salesDetail.AcceptAnOrderNo, acceptOdrCarList);
                if (this._carRelationDic.ContainsKey(salesDetail.AcceptAnOrderNo))
                {
                    EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(salesDetail.SalesSlipNum, salesDetail.SalesRowNo);
                    salesDetailRow.CarRelationGuid = this._carRelationDic[salesDetail.AcceptAnOrderNo];
                }
                else
                {
                    if (acceptOdrCar != null) this.CacheCarInfo(baseSalesSlip, salesDetail, acceptOdrCar);
                }
            }
        }

        /// <summary>
        /// ���q���L���b�V���i�󒍃}�X�^�i���q�j����L���b�V���j
        /// </summary>
        /// <param name="baseSalesSlip">����������f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesDetailList">���㖾�׃I�u�W�F�N�g���X�g</param>
        /// <param name="acceptOdrCarList">�󒍃}�X�^�i���q�j�I�u�W�F�N�g���X�g</param>
        public void CacheCarInfo(SalesSlip baseSalesSlip, List<SalesDetail> salesDetailList, List<AcceptOdrCar> acceptOdrCarList)
        {
            if (acceptOdrCarList != null)
            {
                AcceptOdrCar acceptOdrCar;
                foreach (SalesDetail salesDetail in salesDetailList)
                {
                    acceptOdrCar = this.GetAcceptOdrCar(salesDetail.AcceptAnOrderNo, acceptOdrCarList);
                    if (this._carRelationDic.ContainsKey(salesDetail.AcceptAnOrderNo))
                    {
                        EstimateInputDataSet.EstimateDetailRow estimateDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(salesDetail.SalesSlipNum, salesDetail.SalesRowNo);

                        estimateDetailRow.CarRelationGuid = this._carRelationDic[salesDetail.AcceptAnOrderNo];
                    }
                    else
                    {
                        if (acceptOdrCar != null) this.CacheCarInfo(baseSalesSlip, salesDetail, acceptOdrCar);
                    }
                }
            }
        }

        /// <summary>
        /// ���q���L���b�V���i�󒍃}�X�^�i���q�j����L���b�V���j
        /// </summary>
        /// <param name="baseSalesSlip">����������f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesDetail">���㖾�׃f�[�^�I�u�W�F�N�g</param>
        /// <param name="acceptOdrCar">�󒍃}�X�^�i���q�j�I�u�W�F�N�g</param>
        public void CacheCarInfo(SalesSlip baseSalesSlip, SalesDetail salesDetail, AcceptOdrCar acceptOdrCar)
        {
            this.CacheCarInfo(salesDetail.SalesRowNo, baseSalesSlip, salesDetail, acceptOdrCar);
        }

        /// <summary>
        /// ���q���L���b�V���i�󒍃}�X�^�i���q�j����L���b�V���j
        /// </summary>
        /// <param name="salesRowNo">�ݒ�Ώۍs�ԍ�</param>
        /// <param name="baseSalesSlip">����������f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesDetail">���㖾�׃I�u�W�F�N�g</param>
        /// <param name="acceptOdrCar">�󒍃}�X�^�i���q�j�I�u�W�F�N�g</param>
        /// <br>Update Note: 2009/09/08�A       ���痈</br>
        ///	<br>		   : ���q���l��ǉ�����</br>
        ///	<br>Update Note: 2011/02/15 杍^</br>
        ///	<br>		   : �C���ďo���̂s�a�n�������\�ɏC��</br>
        public void CacheCarInfo(int salesRowNo, SalesSlip baseSalesSlip, SalesDetail salesDetail, AcceptOdrCar acceptOdrCar)
        {
            EstimateInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow(baseSalesSlip, salesRowNo, EstimateInputAcs.GetCarInfoMode.NewInsertMode);

            string slipNum = this._currentSalesSlipNum;
            if (baseSalesSlip != null) slipNum = baseSalesSlip.SalesSlipNum;
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(slipNum, salesRowNo);
            
            // ���q�Č���
            PMKEN01010E carInfoDataset = new PMKEN01010E();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/15 UPD
            //CarSearchResultReport result = this.SearchCar(acceptOdrCar.FullModelFixedNoAry, acceptOdrCar.ModelDesignationNo, acceptOdrCar.CategoryNo, ref carInfoDataset);

            CarSearchCondition carSearchCond = new CarSearchCondition();

            carSearchCond.CarModel.FullModel = acceptOdrCar.FullModel;
            carSearchCond.MakerCode = acceptOdrCar.MakerCode;
            carSearchCond.ModelCode = acceptOdrCar.ModelCode;
            carSearchCond.ModelSubCode = acceptOdrCar.ModelSubCode;

            // ---- ADD 2011/02/15 ------- >>>>
            carSearchCond.ModelDesignationNo = acceptOdrCar.ModelDesignationNo;
            carSearchCond.CategoryNo = acceptOdrCar.CategoryNo;
            // ---- ADD 2011/02/15 ------- <<<<

            //CarSearchResultReport result = this.SearchCar( acceptOdrCar.FullModelFixedNoAry, carSearchCond, ref carInfoDataset ); // DEL 2010/05/20
            CarSearchResultReport result = this._carSearchController.SearchByFullModelFixedNo(acceptOdrCar.FullModelFixedNoAry, acceptOdrCar.FreeSrchMdlFxdNoAry, carSearchCond, ref carInfoDataset); // ADD 2010/05/20
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/15 UPD
            if ((result != CarSearchResultReport.retError) && (result != CarSearchResultReport.retFailed))
            {
                // --- ADD 杍^ 2014/09/01 Redmine#43289---------->>>>>
                if (carInfoDataset.CarModelUIData != null)
                {
                    carInfoDataset.CarModelUIData[0].ProduceTypeOfYearInput = acceptOdrCar.FirstEntryDate;
                    carInfoDataset.CarModelUIData[0].ModelDesignationNo = acceptOdrCar.ModelDesignationNo;
                    carInfoDataset.CarModelUIData[0].CategoryNo = acceptOdrCar.CategoryNo;
                    carInfoDataset.CarModelUIData[0].FrameNo = acceptOdrCar.FrameNo;
                }
                // --- ADD 杍^ 2014/09/01 Redmine#43289----------<<<<<

                this.CacheCarInfo(ref carInfoRow, salesDetailRow, carInfoDataset);
            }
            carInfoRow.CarRelationGuid = salesDetailRow.CarRelationGuid; // ���q��񋤒ʃL�[
            //carInfoRow.CustomerCode = acceptOdrCar.CustomerCode; // ���Ӑ�R�[�h
            carInfoRow.CarMngNo = acceptOdrCar.CarMngNo; // �ԗ��Ǘ��ԍ�
            carInfoRow.CarMngCode = acceptOdrCar.CarMngCode; // ���q�Ǘ��R�[�h
            carInfoRow.NumberPlate1Code = acceptOdrCar.NumberPlate1Code; // ���^�������ԍ�
            carInfoRow.NumberPlate1Name = acceptOdrCar.NumberPlate1Name; // ���^�����ǖ���
            carInfoRow.NumberPlate2 = acceptOdrCar.NumberPlate2; // �ԗ��o�^�ԍ��i��ʁj
            carInfoRow.NumberPlate3 = acceptOdrCar.NumberPlate3; // �ԗ��o�^�ԍ��i�J�i�j
            carInfoRow.NumberPlate4 = acceptOdrCar.NumberPlate4; // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            //carInfoRow.EntryDate = acceptOdrCar.EntryDate; // �o�^�N����
            carInfoRow.ProduceTypeOfYearInput = 0; // ���N�x
            // --- UPD 2009/10/22 ----->>>>>
            //if (acceptOdrCar.FirstEntryDate != DateTime.MinValue)
            //{
            //    int iyy = acceptOdrCar.FirstEntryDate.Year * 100;
            //    int imm = acceptOdrCar.FirstEntryDate.Month;
            //    carInfoRow.ProduceTypeOfYearInput = iyy + imm; // ���N�x
            //}

            if(acceptOdrCar.FirstEntryDate != 0 )
            {
                carInfoRow.ProduceTypeOfYearInput = acceptOdrCar.FirstEntryDate;
            }
            // --- UPD 2009/10/22 -----<<<<<
            carInfoRow.MakerCode = acceptOdrCar.MakerCode; // ���[�J�[�R�[�h
            carInfoRow.MakerFullName = acceptOdrCar.MakerFullName; // ���[�J�[�S�p����
            carInfoRow.MakerHalfName = acceptOdrCar.MakerHalfName; // ���[�J�[���p����
            carInfoRow.ModelCode = acceptOdrCar.ModelCode; // �Ԏ�R�[�h
            carInfoRow.ModelSubCode = acceptOdrCar.ModelSubCode; // �Ԏ�T�u�R�[�h
            carInfoRow.ModelFullName = acceptOdrCar.ModelFullName; // �Ԏ�S�p����
            carInfoRow.ModelHalfName = acceptOdrCar.ModelHalfName; // �Ԏ피�p����
            //carInfoRow.SystematicCode = acceptOdrCar.SystematicCode; // �n���R�[�h
            //carInfoRow.SystematicName = acceptOdrCar.SystematicName; // �n������
            //carInfoRow.ProduceTypeOfYearCd = acceptOdrCar.ProduceTypeOfYearCd; // ���Y�N���R�[�h
            //carInfoRow.ProduceTypeOfYearNm = acceptOdrCar.ProduceTypeOfYearNm; // ���Y�N������
            //carInfoRow.StProduceTypeOfYear = acceptOdrCar.StProduceTypeOfYear; // �J�n���Y�N��
            //carInfoRow.EdProduceTypeOfYear = acceptOdrCar.EdProduceTypeOfYear; // �I�����Y�N��
            //carInfoRow.DoorCount = acceptOdrCar.DoorCount; // �h�A��
            //carInfoRow.BodyNameCode = acceptOdrCar.BodyNameCode; // �{�f�B�[���R�[�h
            //carInfoRow.BodyName = acceptOdrCar.BodyName; // �{�f�B�[����
            carInfoRow.ExhaustGasSign = acceptOdrCar.ExhaustGasSign; // �r�K�X�L��
            carInfoRow.SeriesModel = acceptOdrCar.SeriesModel; // �V���[�Y�^��
            carInfoRow.CategorySignModel = acceptOdrCar.CategorySignModel; // �^���i�ޕʋL���j
            carInfoRow.FullModel = acceptOdrCar.FullModel; // �^���i�t���^�j
            carInfoRow.ModelDesignationNo = acceptOdrCar.ModelDesignationNo; // �^���w��ԍ�
            carInfoRow.CategoryNo = acceptOdrCar.CategoryNo; // �ޕʔԍ�
            carInfoRow.FrameModel = acceptOdrCar.FrameModel; // �ԑ�^��
            carInfoRow.FrameNo = acceptOdrCar.FrameNo; // �ԑ�ԍ�
            //carInfoRow.ProduceFrameNoInput = TStrConv.StrToIntDef(acceptOdrCar.FrameNo, 0); // �ԑ�ԍ�
            carInfoRow.SearchFrameNo = acceptOdrCar.SearchFrameNo; // �ԑ�ԍ��i�����p�j
            //carInfoRow.StProduceFrameNo = acceptOdrCar.StProduceFrameNo; // ���Y�ԑ�ԍ��J�n
            //carInfoRow.EdProduceFrameNo = acceptOdrCar.EdProduceFrameNo; // ���Y�ԑ�ԍ��I��
            //carInfoRow.ModelGradeNm = acceptOdrCar.ModelGradeNm; // �^���O���[�h����
            carInfoRow.EngineModelNm = acceptOdrCar.EngineModelNm; // �G���W���^������
            //carInfoRow.EngineDisplaceNm = acceptOdrCar.EngineDisplaceNm; // �r�C�ʖ���
            //carInfoRow.EDivNm = acceptOdrCar.EDivNm; // E�敪����
            //carInfoRow.TransmissionNm = acceptOdrCar.TransmissionNm; // �~�b�V��������
            //carInfoRow.ShiftNm = acceptOdrCar.ShiftNm; // �V�t�g����
            //carInfoRow.WheelDriveMethodNm = acceptOdrCar.WheelDriveMethodNm; // �쓮��������
            //carInfoRow.AddiCarSpec1 = acceptOdrCar.AddiCarSpec1; // �ǉ�����1
            //carInfoRow.AddiCarSpec2 = acceptOdrCar.AddiCarSpec2; // �ǉ�����2
            //carInfoRow.AddiCarSpec3 = acceptOdrCar.AddiCarSpec3; // �ǉ�����3
            //carInfoRow.AddiCarSpec4 = acceptOdrCar.AddiCarSpec4; // �ǉ�����4
            //carInfoRow.AddiCarSpec5 = acceptOdrCar.AddiCarSpec5; // �ǉ�����5
            //carInfoRow.AddiCarSpec6 = acceptOdrCar.AddiCarSpec6; // �ǉ�����6
            //carInfoRow.AddiCarSpecTitle1 = acceptOdrCar.AddiCarSpecTitle1; // �ǉ������^�C�g��1
            //carInfoRow.AddiCarSpecTitle2 = acceptOdrCar.AddiCarSpecTitle2; // �ǉ������^�C�g��2
            //carInfoRow.AddiCarSpecTitle3 = acceptOdrCar.AddiCarSpecTitle3; // �ǉ������^�C�g��3
            //carInfoRow.AddiCarSpecTitle4 = acceptOdrCar.AddiCarSpecTitle4; // �ǉ������^�C�g��4
            //carInfoRow.AddiCarSpecTitle5 = acceptOdrCar.AddiCarSpecTitle5; // �ǉ������^�C�g��5
            //carInfoRow.AddiCarSpecTitle6 = acceptOdrCar.AddiCarSpecTitle6; // �ǉ������^�C�g��6
            carInfoRow.RelevanceModel = acceptOdrCar.RelevanceModel; // �֘A�^��
            carInfoRow.SubCarNmCd = acceptOdrCar.SubCarNmCd; // �T�u�Ԗ��R�[�h
            carInfoRow.ModelGradeSname = acceptOdrCar.ModelGradeSname; // �^���O���[�h����
            //carInfoRow.BlockIllustrationCd = acceptOdrCar.BlockIllustrationCd; // �u���b�N�C���X�g�R�[�h
            //carInfoRow.ThreeDIllustNo = acceptOdrCar.ThreeDIllustNo; // 3D�C���X�gNo
            //carInfoRow.PartsDataOfferFlag = acceptOdrCar.PartsDataOfferFlag; // ���i�f�[�^�񋟃t���O
            //carInfoRow.InspectMaturityDate = acceptOdrCar.InspectMaturityDate; // �Ԍ�������
            //carInfoRow.LTimeCiMatDate = acceptOdrCar.LTimeCiMatDate; // �O��Ԍ�������
            //carInfoRow.CarInspectYear = acceptOdrCar.CarInspectYear; // �Ԍ�����
            carInfoRow.Mileage = acceptOdrCar.Mileage; // �ԗ����s����
            //carInfoRow.CarNo = acceptOdrCar.CarNo; // ����
            carInfoRow.FullModelFixedNoAry = acceptOdrCar.FullModelFixedNoAry; // �t���^���Œ�ԍ��z��
            carInfoRow.FreeSrchMdlFxdNoAry = acceptOdrCar.FreeSrchMdlFxdNoAry; // ���R�����^���Œ�ԍ��z�� // ADD 2010/04/27
            //carInfoRow.ProduceFrameNoInput = acceptOdrCar.ProduceFrameNoInput; // �ԑ�ԍ�
            //carInfoRow.ProduceTypeOfYearInput = acceptOdrCar.ProduceTypeOfYearInput; // �N��
            carInfoRow.ColorCode = acceptOdrCar.ColorCode; // �J���[�R�[�h
            carInfoRow.ColorName1 = acceptOdrCar.ColorName1; // �J���[����
            carInfoRow.TrimCode = acceptOdrCar.TrimCode; // �g�����R�[�h
            carInfoRow.TrimName = acceptOdrCar.TrimName; // �g��������

            // --- ADD 2009/09/08�A ---------->>>>>
            carInfoRow.CarNote = acceptOdrCar.CarNote; // ���q���l
            // --- ADD 2009/09/08�A ----------<<<<<

            // --- UPD 2012/09/11 Y.Wakita ---------->>>>>
            //this.SelectColorInfo(salesDetailRow.CarRelationGuid, acceptOdrCar.ColorCode); // �J���[���
            //this.SelectTrimInfo(salesDetailRow.CarRelationGuid, acceptOdrCar.TrimCode); // �g�������
            this.SelectColorInfo2(salesDetailRow.CarRelationGuid, acceptOdrCar.ColorCode); // �J���[���
            this.SelectTrimInfo2(salesDetailRow.CarRelationGuid, acceptOdrCar.TrimCode); // �g�������
            // --- UPD 2012/09/11 Y.Wakita ----------<<<<<
            this.SelectEquipInfo(salesDetailRow.CarRelationGuid, acceptOdrCar.CategoryObjAry); // �������

            carInfoRow.AcceptAnOrderNo = acceptOdrCar.AcceptAnOrderNo; // �󒍔ԍ�

            this._carRelationDic[acceptOdrCar.AcceptAnOrderNo] = carInfoRow.CarRelationGuid; // �ԗ��A�����
            // --- ADD 2013/03/21 ---------->>>>>
            // PMNS:���Y/�O�ԋ敪�Z�b�g
            carInfoRow.DomesticForeignCode = acceptOdrCar.DomesticForeignCode;
            // --- ADD 2013/03/21 ----------<<<<<
        }


        /// <summary>
        /// ���o�\�t���N���X���[�N�L���b�V���i�ԗ��Ǘ�����L���b�V���j
        /// </summary>
        /// <param name="carMangInputExtraInfo">�ԗ��Ǘ�</param>
        /// <returns>SalesSlipHeaderCopyData</returns>
        /// <remarks>
        /// <br>Note       : ���o�\�t���N���X���L���b�V�����܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/09/08�A</br>
        /// </remarks>
        public SalesSlipHeaderCopyData CacheCarInfo(CarMangInputExtraInfo carMangInputExtraInfo)
        {
            SalesSlipHeaderCopyData salesSlipHeaderCopyData = new SalesSlipHeaderCopyData();
            // �ԗ��Ǘ��ԍ�
            salesSlipHeaderCopyData.CarMngNo = carMangInputExtraInfo.CarMngNo;
            // �ԗ����s����
            salesSlipHeaderCopyData.Mileage = carMangInputExtraInfo.Mileage;
            // ���q���l
            salesSlipHeaderCopyData.CarNote = carMangInputExtraInfo.CarNote;
            // ���^�������ԍ�
            salesSlipHeaderCopyData.NumberPlate1Code = carMangInputExtraInfo.NumberPlate1Code;
            // ���^�����ǖ���
            salesSlipHeaderCopyData.NumberPlate1Name = carMangInputExtraInfo.NumberPlate1Name;
            // �ԗ��o�^�ԍ��i��ʁj
            salesSlipHeaderCopyData.NumberPlate2 = carMangInputExtraInfo.NumberPlate2;
            // �ԗ��o�^�ԍ��i�J�i�j
            salesSlipHeaderCopyData.NumberPlate3 = carMangInputExtraInfo.NumberPlate3;
            // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            salesSlipHeaderCopyData.NumberPlate4 = carMangInputExtraInfo.NumberPlate4;
            // ���q�Ǘ��ԍ�
            salesSlipHeaderCopyData.CarMngCode = carMangInputExtraInfo.CarMngCode;
            // �^���w��ԍ�
            salesSlipHeaderCopyData.ModelDesignationNo = carMangInputExtraInfo.ModelDesignationNo;
            // �ޕʔԍ�
            salesSlipHeaderCopyData.CategoryNo = carMangInputExtraInfo.CategoryNo;
            // �N��
            // --- ADD 2009/10/22 ----->>>>>
            //salesSlipHeaderCopyData.FirstEntryDate = GetLongDateFromObject(carMangInputExtraInfo.ProduceTypeOfYearInput);
            salesSlipHeaderCopyData.FirstEntryDate = carMangInputExtraInfo.ProduceTypeOfYearInput;
            // --- ADD 2009/10/22 -----<<<<<
            // �ԑ�ԍ�
            salesSlipHeaderCopyData.FrameNo = carMangInputExtraInfo.FrameNo;
            // �J���[���
            salesSlipHeaderCopyData.ColorCode = carMangInputExtraInfo.ColorCode;
            // �g�������
            salesSlipHeaderCopyData.TrimCode = carMangInputExtraInfo.TrimCode;
            // �������
            salesSlipHeaderCopyData.CategoryObjAry = carMangInputExtraInfo.CategoryObjAry;
            // �t���^���Œ�ԍ��z��
            salesSlipHeaderCopyData.FullModelFixedNoAry = carMangInputExtraInfo.FullModelFixedNoAry;
            // ���R�����^���Œ�ԍ��z��
            salesSlipHeaderCopyData.FreeSrchMdlFxdNoAry = carMangInputExtraInfo.FreeSrchMdlFxdNoAry; // ADD 2010/04/27
            // ���Ӑ�R�[�h
            salesSlipHeaderCopyData.CustomerCode = carMangInputExtraInfo.CustomerCode;
            // ���^�������ԍ�
            salesSlipHeaderCopyData.NumberPlate1Code = carMangInputExtraInfo.NumberPlate1Code;
            // ���^�����ǖ���
            salesSlipHeaderCopyData.NumberPlate1Name = carMangInputExtraInfo.NumberPlate1Name;
            // �ԗ��o�^�ԍ��i��ʁj
            salesSlipHeaderCopyData.NumberPlate2 = carMangInputExtraInfo.NumberPlate2;
            // �ԗ��o�^�ԍ��i�J�i�j
            salesSlipHeaderCopyData.NumberPlate3 = carMangInputExtraInfo.NumberPlate3;
            // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            salesSlipHeaderCopyData.NumberPlate4 = carMangInputExtraInfo.NumberPlate4;
            // �ԗ����s����
            salesSlipHeaderCopyData.Mileage = carMangInputExtraInfo.Mileage;
            // ���q���l
            salesSlipHeaderCopyData.CarNote = carMangInputExtraInfo.CarNote;
            // �ԗ��Ǘ��ԍ�
            salesSlipHeaderCopyData.CarMngNo = carMangInputExtraInfo.CarMngNo;
            // �^���i�t���^�j
            salesSlipHeaderCopyData.FullModel = carMangInputExtraInfo.FullModel;
            // �G���W��
            salesSlipHeaderCopyData.EngineModelNm = carMangInputExtraInfo.EngineModelNm;
            // --- ADD 2009/09/08�A ---------->>>>>
            salesSlipHeaderCopyData.MakerCode = carMangInputExtraInfo.MakerCode; // �Ԏ탁�[�J�[�R�[�h
            salesSlipHeaderCopyData.ModelCode = carMangInputExtraInfo.ModelCode; // �Ԏ�R�[�h
            salesSlipHeaderCopyData.ModelSubCode = carMangInputExtraInfo.ModelSubCode; // �Ԏ�T�u�R�[�h
            salesSlipHeaderCopyData.ModelFullName = carMangInputExtraInfo.ModelFullName; // �Ԏ�S�p����
            // --- ADD 2009/09/08�A ---------->>>>>

            // PMNS:���Y/�O�ԋ敪�Z�b�g
            // --- ADD 2013/03/21 ---------->>>>>
            salesSlipHeaderCopyData.DomesticForeignCode = carMangInputExtraInfo.DomesticForeignCode; // ���Y/�O�ԋ敪
            // --- ADD 2013/03/21 ----------<<<<<

            return salesSlipHeaderCopyData;

        }

        /// <summary>
        /// �I�u�W�F�N�g����̓��tLongDate�擾����
        /// </summary>
        /// <param name="targetInt"></param>
        /// <returns>LongDate</returns>
        /// <remarks>
        /// <br>Note       : ���tLongDate���������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/09/08�A</br>
        /// </remarks>
        private int GetLongDateFromObject(int targetInt)
        {
            if (targetInt == 0)
            {
                return 0;
            }
            else
            {
                try
                {
                    DateTime time = DateTime.ParseExact(targetInt.ToString(), "yyyyMM", null);
                    return TDateTime.DateTimeToLongDate(time);
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// �󒍃}�X�^�i���q�j�I�u�W�F�N�g���X�g����ΏۃI�u�W�F�N�g���擾
        /// </summary>
        /// <param name="acceptAnOrderNo">�󒍔ԍ�</param>
        /// <param name="acceptOdrCarList">�󒍃}�X�^�i���q�j���X�g</param>
        /// <returns>�󒍃}�X�^�i���q�j�I�u�W�F�N�g</returns>
        private AcceptOdrCar GetAcceptOdrCar( int acceptAnOrderNo, List<AcceptOdrCar> acceptOdrCarList )
        {
            foreach (AcceptOdrCar acceptOdrCar in acceptOdrCarList)
            {
                if (acceptAnOrderNo == acceptOdrCar.AcceptAnOrderNo)
                {
                    return acceptOdrCar;
                }
            }
            return null;
        }

        /// <summary>
        /// �������ݒ菈��(���q���s�I�u�W�F�N�g���������s�I�u�W�F�N�g)
        /// </summary>
        /// <param name="carSpecRow">�������s�I�u�W�F�N�g</param>
        /// <param name="carInfoRow">���q���s�I�u�W�F�N�g</param>
        public void SetCarSpecFromCarInfoRow( ref EstimateInputDataSet.CarSpecRow carSpecRow, EstimateInputDataSet.CarInfoRow carInfoRow )
        {
            if (carInfoRow == null) return;

            carSpecRow.ModelGradeNm = carInfoRow.ModelGradeNm;                     // �O���[�h
            carSpecRow.BodyName = carInfoRow.BodyName;                             // �{�f�B
            carSpecRow.DoorCount = carInfoRow.DoorCount;                           // �h�A
            carSpecRow.EDivNm = carInfoRow.EDivNm;                                 // �d�敪
            carSpecRow.EngineDisplaceNm = carInfoRow.EngineDisplaceNm;             // �r�C��
            carSpecRow.EngineModelNm = carInfoRow.EngineModelNm;                   // �G���W��
            carSpecRow.ShiftNm = carInfoRow.ShiftNm;                               // �V�t�g
            carSpecRow.TransmissionNm = carInfoRow.TransmissionNm;                 // �~�b�V����
            carSpecRow.WheelDriveMethodNm = carInfoRow.WheelDriveMethodNm;         // �쓮����
            carSpecRow.AddiCarSpec1 = carInfoRow.AddiCarSpec1;                     // �ǉ������P
            carSpecRow.AddiCarSpec2 = carInfoRow.AddiCarSpec2;                     // �ǉ������Q 
            carSpecRow.AddiCarSpec3 = carInfoRow.AddiCarSpec3;                     // �ǉ������R
            carSpecRow.AddiCarSpec4 = carInfoRow.AddiCarSpec4;                     // �ǉ������S
            carSpecRow.AddiCarSpec5 = carInfoRow.AddiCarSpec5;                     // �ǉ������T
            carSpecRow.AddiCarSpec6 = carInfoRow.AddiCarSpec6;                     // �ǉ������U
        }

        #region ���J���[���

        /// <summary>
        /// �J���[���L���b�V��
        /// </summary>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="colorCdInfoDataTable">�J���[���f�[�^�e�[�u��</param>
        private void CacheColorInfo(string salesSlipNum, int salesRowNo, PMKEN01010E.ColorCdInfoDataTable colorCdInfoDataTable)
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(salesSlipNum, salesRowNo);
            if (this._colorInfoDic.ContainsKey(row.CarRelationGuid)) this._colorInfoDic.Remove(row.CarRelationGuid);
            this._colorInfoDic.Add(row.CarRelationGuid, colorCdInfoDataTable);
        }

        /// <summary>
        /// �J���[���擾����
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <returns>�J���[���f�[�^�e�[�u��</returns>
        public PMKEN01010E.ColorCdInfoDataTable GetColorInfo( int salesRowNo )
        {
            PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable = null;
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (salesDetailRow != null)
            {
                colorInfoDataTable = this.GetColorInfo(salesDetailRow.CarRelationGuid);
            }
            return colorInfoDataTable;
        }

        /// <summary>
        /// �J���[���擾����
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <returns>�J���[���f�[�^�e�[�u��</returns>
        public PMKEN01010E.ColorCdInfoDataTable GetColorInfo( Guid carRelationGuid )
        {
            PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable = null;
            if (this._colorInfoDic.ContainsKey(carRelationGuid))
            {
                colorInfoDataTable = this._colorInfoDic[carRelationGuid];
            }
            return colorInfoDataTable;
        }

        /// <summary>
        /// �I���J���[���擾����
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <returns>�J���[���s�I�u�W�F�N�g</returns>
        public PMKEN01010E.ColorCdInfoRow GetSelectColorInfo( int salesRowNo )
        {
            PMKEN01010E.ColorCdInfoRow colorInfoRow = null;
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (salesDetailRow != null)
            {
                colorInfoRow = this.GetSelectColorInfo(salesDetailRow.CarRelationGuid);
            }
            return colorInfoRow;
        }

        /// <summary>
        /// �I���J���[���擾����
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <returns>�J���[���s�I�u�W�F�N�g</returns>
        public PMKEN01010E.ColorCdInfoRow GetSelectColorInfo( Guid carRelationGuid )
        {
            PMKEN01010E.ColorCdInfoRow colorInfoRow = null;
            if (this._colorInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable = this._colorInfoDic[carRelationGuid];
                PMKEN01010E.ColorCdInfoRow[] rows = (PMKEN01010E.ColorCdInfoRow[])colorInfoDataTable.Select(string.Format("{0}={1}", colorInfoDataTable.SelectionStateColumn.ColumnName, true));
                if (rows.Length > 0) colorInfoRow = rows[0];
            }
            return colorInfoRow;
        }

        /// <summary>
        /// �J���[���I������
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="colorCode">�J���[�R�[�h</param>
        /// <returns>true:�Y�����萳��I�� false:�Y���Ȃ�</returns>
        public bool SelectColorInfo( Guid carRelationGuid, string colorCode )
        {
            bool ret = false;
            if (this._colorInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable = this._colorInfoDic[carRelationGuid];
                ret = this.SelectColorInfo(carRelationGuid, colorInfoDataTable, colorCode);
            }
            return ret;
        }

        /// <summary>
        /// �J���[���I������
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="colorInfoDataTable">�J���[���f�[�^�e�[�u��</param>
        /// <param name="colorCode">�J���[�R�[�h</param>
        /// <returns>true:�Y�����萳��I�� false:�Y���Ȃ�</returns>
        private bool SelectColorInfo( Guid carRelationGuid, PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable, string colorCode )
        {
            bool ret = false;
            this.SettingColorInfoAllState(colorInfoDataTable, false);   // �S���בI������
            this.ClearCarInfoRowForColorInfo(carRelationGuid);
            if (colorCode != string.Empty)
            {
                PMKEN01010E.ColorCdInfoRow[] rows = (PMKEN01010E.ColorCdInfoRow[])colorInfoDataTable.Select(string.Format("{0}='{1}'", colorInfoDataTable.ColorCodeColumn.ColumnName, colorCode));
                if (rows.Length > 0)
                {
                    PMKEN01010E.ColorCdInfoRow colorInfoRow = rows[0];
                    colorInfoRow.SelectionState = true;
                    this.SettingCarInfoRowFromColorInfo(carRelationGuid, colorInfoRow);
                    ret = true;
                }
                // --- ADD 2012/09/07 Y.Wakita ---------->>>>>
                else
                {
                    ret = this.SettingCarInfoRowFromColorCode(carRelationGuid, colorCode);
                }
                // --- ADD 2012/09/07 Y.Wakita ----------<<<<<
            }
            return ret;
        }

        // --- ADD 2012/09/11 Y.Wakita ---------->>>>>
        /// <summary>
        /// �J���[���I������
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="colorCode">�J���[�R�[�h</param>
        /// <returns>true:�Y�����萳��I�� false:�Y���Ȃ�</returns>
        public bool SelectColorInfo2(Guid carRelationGuid, string colorCode)
        {
            bool ret = false;
            if (this._colorInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable = this._colorInfoDic[carRelationGuid];
                ret = this.SelectColorInfo2(carRelationGuid, colorInfoDataTable, colorCode);
            }
            return ret;
        }

        /// <summary>
        /// �J���[���I������
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="colorInfoDataTable">�J���[���f�[�^�e�[�u��</param>
        /// <param name="colorCode">�J���[�R�[�h</param>
        /// <returns>true:�Y�����萳��I�� false:�Y���Ȃ�</returns>
        private bool SelectColorInfo2(Guid carRelationGuid, PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable, string colorCode)
        {
            bool ret = false;
            this.SettingColorInfoAllState(colorInfoDataTable, false);   // �S���בI������
            this.ClearCarInfoRowForColorInfo(carRelationGuid);
            if (colorCode != string.Empty)
            {
                PMKEN01010E.ColorCdInfoRow[] rows = (PMKEN01010E.ColorCdInfoRow[])colorInfoDataTable.Select(string.Format("{0}='{1}'", colorInfoDataTable.ColorCodeColumn.ColumnName, colorCode));
                if (rows.Length > 0)
                {
                    PMKEN01010E.ColorCdInfoRow colorInfoRow = rows[0];
                    colorInfoRow.SelectionState = true;
                    this.SettingCarInfoRowFromColorInfo(carRelationGuid, colorInfoRow);
                    ret = true;
                }
                else
                {
                    // �ԗ����s�I�u�W�F�N�g�擾
                    EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
                    if (carInfoRow != null)
                    {
                        carInfoRow.ColorCode = colorCode;   // �J���[�R�[�h
                        ret = true;
                    }
                }
            }
            return ret;
        }
        // --- ADD 2012/09/11 Y.Wakita ----------<<<<<

        /// <summary>
        /// �J���[���S���בI���^��������
        /// </summary>
        /// <param name="colorInfoDataTable">�J���[���f�[�^�e�[�u��</param>
        /// <param name="state">�I�����</param>
        public void SettingColorInfoAllState( PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable, bool state )
        {
            foreach (PMKEN01010E.ColorCdInfoRow colorInfoRow in colorInfoDataTable)
            {
                colorInfoRow.SelectionState = state;
            }
        }

        #endregion

        #region ���g�������

        /// <summary>
        /// �g�������L���b�V��
        /// </summary>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="trimCdInfoDataTable">�g�������f�[�^�e�[�u��</param>
        private void CacheTrimInfo(string salesSlipNum, int salesRowNo, PMKEN01010E.TrimCdInfoDataTable trimCdInfoDataTable)
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(salesSlipNum, salesRowNo);
            if (this._trimInfoDic.ContainsKey(row.CarRelationGuid)) this._trimInfoDic.Remove(row.CarRelationGuid);
            this._trimInfoDic.Add(row.CarRelationGuid, trimCdInfoDataTable);
        }

        /// <summary>
        /// �g�������擾����
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <returns>�g�������f�[�^�e�[�u��</returns>
        public PMKEN01010E.TrimCdInfoDataTable GetTrimInfo( int salesRowNo )
        {
            PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable = null;
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (salesDetailRow != null)
            {
                trimInfoDataTable = this.GetTrimInfo(salesDetailRow.CarRelationGuid);
            }
            return trimInfoDataTable;
        }

        /// <summary>
        /// �g�������擾����
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <returns>�g�������f�[�^�e�[�u��</returns>
        public PMKEN01010E.TrimCdInfoDataTable GetTrimInfo( Guid carRelationGuid )
        {
            PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable = null;
            if (this._trimInfoDic.ContainsKey(carRelationGuid))
            {
                trimInfoDataTable = this._trimInfoDic[carRelationGuid];
            }
            return trimInfoDataTable;
        }

        /// <summary>
        /// �I���g�������擾����
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <returns>�g�������s�I�u�W�F�N�g</returns>
        public PMKEN01010E.TrimCdInfoRow GetSelectTrimInfo( int salesRowNo )
        {
            PMKEN01010E.TrimCdInfoRow trimInfoRow = null;
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (salesDetailRow != null)
            {
                trimInfoRow = this.GetSelectTrimInfo(salesDetailRow.CarRelationGuid);
            }
            return trimInfoRow;
        }

        /// <summary>
        /// �I���g�������擾����
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <returns>�g�������s�I�u�W�F�N�g</returns>
        public PMKEN01010E.TrimCdInfoRow GetSelectTrimInfo( Guid carRelationGuid )
        {
            PMKEN01010E.TrimCdInfoRow trimInfoRow = null;
            if (this._trimInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable = this._trimInfoDic[carRelationGuid];
                PMKEN01010E.TrimCdInfoRow[] rows = (PMKEN01010E.TrimCdInfoRow[])trimInfoDataTable.Select(string.Format("{0}={1}", trimInfoDataTable.SelectionStateColumn.ColumnName, true));
                if (rows.Length > 0) trimInfoRow = rows[0];
            }
            return trimInfoRow;
        }

        /// <summary>
        /// �g�������I������
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="trimCode">�g�����R�[�h</param>
        /// <returns>true:�Y�����萳��I�� false:�Y���Ȃ�</returns>
        public bool SelectTrimInfo( Guid carRelationGuid, string trimCode )
        {
            bool ret = false;
            if (this._trimInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable = this._trimInfoDic[carRelationGuid];
                ret = this.SelectTrimInfo(carRelationGuid, trimInfoDataTable, trimCode);
            }
            return ret;
        }

        /// <summary>
        /// �g�������I������
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="trimInfoDataTable">�g�������f�[�^�e�[�u��</param>
        /// <param name="trimCode">�g�����R�[�h</param>
        /// <returns>true:�Y�����萳��I�� false:�Y���Ȃ�</returns>
        public bool SelectTrimInfo( Guid carRelationGuid, PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable, string trimCode )
        {
            bool ret = false;
            this.SettingTrimInfoAllState(trimInfoDataTable, false); // �S���בI������
            this.ClearCarInfoRowForTrimInfo(carRelationGuid);
            if (trimCode != string.Empty)
            {
                PMKEN01010E.TrimCdInfoRow[] rows = (PMKEN01010E.TrimCdInfoRow[])trimInfoDataTable.Select(string.Format("{0}='{1}'", trimInfoDataTable.TrimCodeColumn.ColumnName, trimCode));
                if (rows.Length > 0)
                {
                    PMKEN01010E.TrimCdInfoRow trimInfoRow = rows[0];
                    trimInfoRow.SelectionState = true;
                    this.SettingCarInfoRowFromTrimInfo(carRelationGuid, trimInfoRow);
                    ret = true;
                }
                // --- ADD 2012/09/07 Y.Wakita ---------->>>>>
                else
                {
                    ret = this.SettingCarInfoRowFromTrimCode(carRelationGuid, trimCode);
                }
                // --- ADD 2012/09/07 Y.Wakita ----------<<<<<
            }
            return ret;
        }

        // --- ADD 2012/09/11 Y.Wakita ---------->>>>>
        /// <summary>
        /// �g�������I������
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="trimCode">�g�����R�[�h</param>
        /// <returns>true:�Y�����萳��I�� false:�Y���Ȃ�</returns>
        public bool SelectTrimInfo2(Guid carRelationGuid, string trimCode)
        {
            bool ret = false;
            if (this._trimInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable = this._trimInfoDic[carRelationGuid];
                ret = this.SelectTrimInfo2(carRelationGuid, trimInfoDataTable, trimCode);
            }
            return ret;
        }

        /// <summary>
        /// �g�������I������
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="trimInfoDataTable">�g�������f�[�^�e�[�u��</param>
        /// <param name="trimCode">�g�����R�[�h</param>
        /// <returns>true:�Y�����萳��I�� false:�Y���Ȃ�</returns>
        public bool SelectTrimInfo2(Guid carRelationGuid, PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable, string trimCode)
        {
            bool ret = false;
            this.SettingTrimInfoAllState(trimInfoDataTable, false); // �S���בI������
            this.ClearCarInfoRowForTrimInfo(carRelationGuid);
            if (trimCode != string.Empty)
            {
                PMKEN01010E.TrimCdInfoRow[] rows = (PMKEN01010E.TrimCdInfoRow[])trimInfoDataTable.Select(string.Format("{0}='{1}'", trimInfoDataTable.TrimCodeColumn.ColumnName, trimCode));
                if (rows.Length > 0)
                {
                    PMKEN01010E.TrimCdInfoRow trimInfoRow = rows[0];
                    trimInfoRow.SelectionState = true;
                    this.SettingCarInfoRowFromTrimInfo(carRelationGuid, trimInfoRow);
                    ret = true;
                }
                else
                {
                    // �ԗ����s�I�u�W�F�N�g�擾
                    EstimateInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
                    if (carInfoRow != null)
                    {
                        carInfoRow.TrimCode = trimCode; // �g�����R�[�h
                        ret = true;
                    }
                }
            }
            return ret;
        }
        // --- ADD 2012/09/11 Y.Wakita ----------<<<<<

        /// <summary>
        /// �g�������S���בI���^��������
        /// </summary>
        /// <param name="trimInfoDataTable">�g�������f�[�^�e�[�u��</param>
        /// <param name="state">�I�����</param>
        public void SettingTrimInfoAllState( PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable, bool state )
        {
            foreach (PMKEN01010E.TrimCdInfoRow trimInfoRow in trimInfoDataTable)
            {
                trimInfoRow.SelectionState = state;
            }
        }

        #endregion

        #region ���������

        /// <summary>
        /// �������L���b�V��
        /// </summary>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="cEqpDefDspInfoDataTable">�������f�[�^�e�[�u��</param>
        private void CacheEquipInfo(string salesSlipNum, int salesRowNo, PMKEN01010E.CEqpDefDspInfoDataTable cEqpDefDspInfoDataTable)
        {
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(salesSlipNum, salesRowNo);
            if (this._cEqpDspInfoDic.ContainsKey(row.CarRelationGuid)) this._cEqpDspInfoDic.Remove(row.CarRelationGuid);
            this._cEqpDspInfoDic.Add(row.CarRelationGuid, cEqpDefDspInfoDataTable);
        }

        /// <summary>
        /// �������擾����
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <returns>�������f�[�^�e�[�u��</returns>
        public PMKEN01010E.CEqpDefDspInfoDataTable GetEquipInfo( int salesRowNo )
        {
            PMKEN01010E.CEqpDefDspInfoDataTable equipInfoDataTable = null;
            EstimateInputDataSet.EstimateDetailRow salesDetailRow = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (salesDetailRow != null)
            {
                equipInfoDataTable = this.GetEquipInfo(salesDetailRow.CarRelationGuid);
            }
            return equipInfoDataTable;
        }

        /// <summary>
        /// �������擾����
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <returns>�������f�[�^�e�[�u��</returns>
        public PMKEN01010E.CEqpDefDspInfoDataTable GetEquipInfo( Guid carRelationGuid )
        {
            PMKEN01010E.CEqpDefDspInfoDataTable equipInfoDataTable = null;
            if (this._cEqpDspInfoDic.ContainsKey(carRelationGuid))
            {
                equipInfoDataTable = this._cEqpDspInfoDic[carRelationGuid];
            }
            return equipInfoDataTable;
        }

        /// <summary>
        /// �������s�I�u�W�F�N�g�z��擾
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <returns>�������o�C�g�z��</returns>
        private byte[] GetEquipInfoRows( Guid carRelationGuid )
        {
            byte[] equipInfoRows = new byte[0];
            if (this._cEqpDspInfoDic.ContainsKey(carRelationGuid))
            {
                // �������f�[�^�e�[�u���擾
                PMKEN01010E.CEqpDefDspInfoDataTable equipInfoDataTable = this._cEqpDspInfoDic[carRelationGuid];

                if (equipInfoDataTable != null)
                {
                    // �������o�C�g�z��
                    equipInfoRows = equipInfoDataTable.GetByteArray(true);
                }
            }
            return equipInfoRows;
        }

        /// <summary>
        /// �������I������
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="key">�����L�[</param>
        /// <param name="selectedIndex">�I���ʒu</param>
        /// <returns></returns>
        public bool SelectEquipInfo( Guid carRelationGuid, string key, int selectedIndex )
        {
            bool ret = false;
            if (this._cEqpDspInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.CEqpDefDspInfoDataTable eqpDspInfoDataTable = this._cEqpDspInfoDic[carRelationGuid];
                ret = this.SelectEquipInfo(carRelationGuid, eqpDspInfoDataTable, key, selectedIndex);
            }
            return ret;
        }

        /// <summary>
        /// �������I������
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="categoryObjAry">�������z��</param>
        /// <br>Update Note: 2009/09/08�A       ���痈</br>
        ///	<br>		   : �������I�����������C����</br>
        private void SelectEquipInfo(Guid carRelationGuid, byte[] categoryObjAry)
        {
            if (( this._cEqpDspInfoDic.ContainsKey(carRelationGuid) ) && ( categoryObjAry != null ) && ( categoryObjAry.Length > 0 ))
            {
                PMKEN01010E.CEqpDefDspInfoDataTable eqpDspInfoDataTable = this._cEqpDspInfoDic[carRelationGuid];
                // --- UPD 2009/09/08�A -------------->>>
                // --- DEL 2009/09/08�A -------------->>>
                //eqpDspInfoDataTable.SetTableFromByteArray(categoryObjAry);
                // --- DEL 2009/09/08�A --------------<<<
                if (categoryObjAry.Length > 0)
                {
                    // �w��̑�����I����Ԃɂ���
                    eqpDspInfoDataTable.SetTableFromByteArray(categoryObjAry);
                }
                else
                {
                    // �S�ĉ���
                    foreach (PMKEN01010E.CEqpDefDspInfoRow row in eqpDspInfoDataTable.Rows)
                    {
                        row.SelectionState = false;
                    }
                }
                // --- UPD 2009/09/08�A --------------<<<
            }
        }

        /// <summary>
        /// �������I������
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="eqpDspInfoDataTable">�������f�[�^�e�[�u</param>
        /// <param name="key">�����L�[</param>
        /// <param name="selectedIndex">�I���ʒu</param>
        /// <returns></returns>
        private bool SelectEquipInfo( Guid carRelationGuid, PMKEN01010E.CEqpDefDspInfoDataTable eqpDspInfoDataTable, string key, int selectedIndex )
        {
            bool ret = false;

            PMKEN01010E.CEqpDefDspInfoRow[] rows = (PMKEN01010E.CEqpDefDspInfoRow[])eqpDspInfoDataTable.Select(string.Format("{0}='{1}'", eqpDspInfoDataTable.EquipmentGenreNmColumn.ColumnName, key));

            if (rows.Length > 0)
            {
                this.SettingEquipInfoAllState(eqpDspInfoDataTable, key, false);
                PMKEN01010E.CEqpDefDspInfoRow equipInfoRow = rows[selectedIndex];
                equipInfoRow.SelectionState = true;
                ret = true;
            }
            return ret;
        }


        /// <summary>
        ///  �������Ώۑ������בI���^��������
        /// </summary>
        /// <param name="equipInfoDataTable">�������f�[�^�e�[�u��</param>
        /// <param name="key">�������L�[</param>
        /// <param name="state">�I�����</param>
        public void SettingEquipInfoAllState( PMKEN01010E.CEqpDefDspInfoDataTable equipInfoDataTable, string key, bool state )
        {
            PMKEN01010E.CEqpDefDspInfoRow[] rows = (PMKEN01010E.CEqpDefDspInfoRow[])equipInfoDataTable.Select(string.Format("{0}='{1}'", equipInfoDataTable.EquipmentGenreNmColumn.ColumnName, key));

            foreach (PMKEN01010E.CEqpDefDspInfoRow row in rows)
            {
                row.SelectionState = state;
            }
        }

        #endregion

        #region ���Ԏ���
        /// <summary>
        /// �Ԏ햼�̎擾����
        /// </summary>
        /// <param name="makerCode">�J�[���[�J�[�R�[�h</param>
        /// <param name="modelCode">�Ԏ�R�[�h</param>
        /// <param name="modelSubCode">�Ԏ�T�u�R�[�h</param>
        /// <param name="modelFullName">�Ԏ햼��</param>
        /// <param name="modelHalfName">�Ԏ피�p����</param>
        public bool GetModelName(int makerCode, int modelCode, int modelSubCode, out string modelFullName, out string modelHalfName)
        {
            modelFullName = string.Empty;
            modelHalfName = string.Empty;
            ModelNameU modelNameU = new ModelNameU();
            modelNameU = this.GetModelInfo(makerCode, modelCode, modelSubCode);

            if (modelNameU != null)
            {
                modelFullName = modelNameU.ModelFullName;
                modelHalfName = modelNameU.ModelHalfName;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// �Ԏ���擾����
        /// </summary>
        /// <param name="makerCode">�J�[���[�J�[�R�[�h</param>
        /// <param name="modelCode">�Ԏ�R�[�h</param>
        /// <param name="modelSubCode">�Ԏ�T�u�R�[�h</param>
        /// <returns></returns>
        public ModelNameU GetModelInfo( int makerCode, int modelCode, int modelSubCode )
        {
            ModelNameU modelNameU = null;

            if (( modelCode == 0 ) && ( modelSubCode == 0 )) return modelNameU;

            if (_modelNameUAcs == null) _modelNameUAcs = new ModelNameUAcs();
            int status = this._modelNameUAcs.Read(out modelNameU, this._enterpriseCode, makerCode, modelCode, modelSubCode);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) modelNameU = null;

            return modelNameU;
        }
        #endregion

        /// <summary>
        /// ���q�Ǘ����[�N�I�u�W�F�N�g���X�g�����q���e�[�u������擾
        /// </summary>
        /// <param name="carManagementWorkList">���q�Ǘ����[�N�I�u�W�F�N�g���X�g</param>
        private void GetCurrentCarManagementWorkList( out ArrayList carManagementWorkList )
        {
            //------------------------------------------------------------------------------------
            // ���X�g�\��
            //------------------------------------------------------------------------------------
            // ArrayList                    ���q��񃊃X�g
            //      --CarManagementWork     ���q�Ǘ����[�N�I�u�W�F�N�g
            //------------------------------------------------------------------------------------
            carManagementWorkList = null;
            if (( this._carInfoDataTable != null ) && ( this._carInfoDataTable.Count != 0 ))
            {
                //-----------------------------------------------------
                // ���q��񃊃X�g�擾
                //-----------------------------------------------------
                this.GetCarManagementWorkListFromCarInfoTable(this._carInfoDataTable, out carManagementWorkList);
            }
        }

        /// <summary>
        /// ���q�Ǘ����[�N�I�u�W�F�N�g���X�g�擾����
        /// </summary>
        /// <param name="carInfoDataTable">���q���e�[�u��</param>
        /// <param name="carManagementWorkList">���q�Ǘ����[�N�I�u�W�F�N�g���X�g</param>
        private void GetCarManagementWorkListFromCarInfoTable( EstimateInputDataSet.CarInfoDataTable carInfoDataTable, out ArrayList carManagementWorkList )
        {
            carManagementWorkList = new ArrayList();

            foreach (EstimateInputDataSet.CarInfoRow carInfoRow in carInfoDataTable)
            {
                CarManagementWork carManagementWork = this.GetParamDataFromCarInfoRow(carInfoRow);
                CarManagementWork clearCarManagementWork = new CarManagementWork();
                ArrayList differentList = carManagementWork.Compare(clearCarManagementWork);

                if (differentList.Count > 3)
                {
                    if (carManagementWork != null) carManagementWorkList.Add(carManagementWork);
                }
            }
        }

        /// <summary>
        /// ���q�Ǘ����[�N�I�u�W�F�N�g�擾����
        /// </summary>
        /// <param name="carManagementWork"></param>
        /// <param name="CarRelationGuid"></param>
        /// <param name="carManagementWorkList"></param>
        private void GetCarManagementWorkFromCarManagementWorkList( out CarManagementWork carManagementWork, Guid CarRelationGuid, ArrayList carManagementWorkList )
        {
            carManagementWork = null;

            if (( carManagementWorkList == null ) || ( carManagementWorkList.Count == 0 )) return;

            foreach (CarManagementWork cManagementWork in carManagementWorkList)
            {
                if (cManagementWork.CarRelationGuid == CarRelationGuid)
                {
                    carManagementWork = cManagementWork;
                    return;
                }
            }
            return;
        }

        /// <summary>
        /// ���q�Ǘ����[�N�I�u�W�F�N�g�����q���s�I�u�W�F�N�g����擾
        /// </summary>
        /// <param name="carInfoRow">���q���s�I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Update Note: 2009/09/08�A       ���痈</br>
        ///	<br>		   : ���q���l�Ǝ��q�ǉ����P�Ǝ��q�ǉ����Q��ǉ�����</br>
        private CarManagementWork GetParamDataFromCarInfoRow( EstimateInputDataSet.CarInfoRow carInfoRow )
        {
            CarManagementWork carManagementWork = new CarManagementWork();

            carManagementWork.EnterpriseCode = this._enterpriseCode;                // ��ƃR�[�h
            carManagementWork.CustomerCode = this._salesSlip.CustomerCode;          // ���Ӑ�R�[�h
            // --- UPD 2009/09/08�A -------------->>>
            //carManagementWork.CarMngNo = carInfoRow.CarMngNo;                       // �ԗ��Ǘ��ԍ�
            CustomerInfo customerInfo = null;
            int customerstatus = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            if (this._salesSlip.CustomerCode == 0)
            {
                customerInfo = new CustomerInfo();
            }
            else
            {
                customerstatus = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, this._salesSlip.CustomerCode, true, false, out customerInfo);
            }
            if (customerInfo.CarMngDivCd == 0 || customerInfo.CarMngDivCd == 3)
            {
                carManagementWork.CarMngNo = 0;
            }
            else
            {
                carManagementWork.CarMngNo = carInfoRow.CarMngNo;                       // �ԗ��Ǘ��ԍ�
            }
            // --- UPD 2009/09/08�A --------------<<<
            carManagementWork.CarMngCode = carInfoRow.CarMngCode;                   // ���q�Ǘ��R�[�h
            carManagementWork.NumberPlate1Code = carInfoRow.NumberPlate1Code;       // ���^�������ԍ�
            carManagementWork.NumberPlate1Name = carInfoRow.NumberPlate1Name;       // ���^�����ǖ���
            carManagementWork.NumberPlate2 = carInfoRow.NumberPlate2;               // �ԗ��o�^�ԍ��i��ʁj
            carManagementWork.NumberPlate3 = carInfoRow.NumberPlate3;               // �ԗ��o�^�ԍ��i�J�i�j
            carManagementWork.NumberPlate4 = carInfoRow.NumberPlate4;               // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            carManagementWork.EntryDate = carInfoRow.EntryDate;                     // �o�^�N����
            //int iyy = carInfoRow.ProduceTypeOfYearInput / 100;
            //int imm = carInfoRow.ProduceTypeOfYearInput % 100;
            //DateTime produceTypeOfYearInput = DateTime.MinValue;
            //if (( iyy != 0 ) && ( imm != 0 )) produceTypeOfYearInput = new DateTime(iyy, imm, 1);
            carManagementWork.FirstEntryDate = carInfoRow.ProduceTypeOfYearInput;   // ���N�x
            carManagementWork.MakerCode = carInfoRow.MakerCode;                     // ���[�J�[�R�[�h
            carManagementWork.MakerFullName = carInfoRow.MakerFullName;             // ���[�J�[�S�p����
            carManagementWork.MakerHalfName = carInfoRow.MakerHalfName;             // ���[�J�[���p����
            carManagementWork.ModelCode = carInfoRow.ModelCode;                     // �Ԏ�R�[�h
            carManagementWork.ModelSubCode = carInfoRow.ModelSubCode;               // �Ԏ�T�u�R�[�h
            carManagementWork.ModelFullName = carInfoRow.ModelFullName;             // �Ԏ�S�p����
            carManagementWork.ModelHalfName = carInfoRow.ModelHalfName;             // �Ԏ피�p����
            carManagementWork.SystematicCode = carInfoRow.SystematicCode;           // �n���R�[�h
            carManagementWork.SystematicName = carInfoRow.SystematicName;           // �n������
            carManagementWork.ProduceTypeOfYearCd = carInfoRow.ProduceTypeOfYearCd; // ���Y�N���R�[�h
            carManagementWork.ProduceTypeOfYearNm = carInfoRow.ProduceTypeOfYearNm; // ���Y�N������
            carManagementWork.StProduceTypeOfYear = carInfoRow.StProduceTypeOfYear; // �J�n���Y�N��
            carManagementWork.EdProduceTypeOfYear = carInfoRow.EdProduceTypeOfYear; // �I�����Y�N��
            carManagementWork.DoorCount = carInfoRow.DoorCount;                     // �h�A��
            carManagementWork.BodyNameCode = carInfoRow.BodyNameCode;               // �{�f�B�[���R�[�h
            carManagementWork.BodyName = carInfoRow.BodyName;                       // �{�f�B�[����
            carManagementWork.ExhaustGasSign = carInfoRow.ExhaustGasSign;           // �r�K�X�L��
            carManagementWork.SeriesModel = carInfoRow.SeriesModel;                 // �V���[�Y�^��
            carManagementWork.CategorySignModel = carInfoRow.CategorySignModel;     // �^���i�ޕʋL���j
            carManagementWork.FullModel = carInfoRow.FullModel;                     // �^���i�t���^�j
            carManagementWork.ModelDesignationNo = carInfoRow.ModelDesignationNo;   // �^���w��ԍ�
            carManagementWork.CategoryNo = carInfoRow.CategoryNo;                   // �ޕʔԍ�
            carManagementWork.FrameModel = carInfoRow.FrameModel;                   // �ԑ�^��
            //carManagementWork.FrameNo = ( carInfoRow.ProduceFrameNoInput == 0 ) ? string.Empty : carInfoRow.ProduceFrameNoInput.ToString();  // �ԑ�ԍ�
            carManagementWork.FrameNo = carInfoRow.FrameNo;                         // �ԑ�ԍ�
            carManagementWork.SearchFrameNo = carInfoRow.SearchFrameNo;             // �ԑ�ԍ��i�����p�j
            carManagementWork.StProduceFrameNo = carInfoRow.StProduceFrameNo;       // ���Y�ԑ�ԍ��J�n
            carManagementWork.EdProduceFrameNo = carInfoRow.EdProduceFrameNo;       // ���Y�ԑ�ԍ��I��
            carManagementWork.ModelGradeNm = carInfoRow.ModelGradeNm;               // �^���O���[�h����
            carManagementWork.EngineModelNm = carInfoRow.EngineModelNm;             // �G���W���^������
            carManagementWork.EngineDisplaceNm = carInfoRow.EngineDisplaceNm;       // �r�C�ʖ���
            carManagementWork.EDivNm = carInfoRow.EDivNm;                           // E�敪����
            carManagementWork.TransmissionNm = carInfoRow.TransmissionNm;           // �~�b�V��������
            carManagementWork.ShiftNm = carInfoRow.ShiftNm;                         // �V�t�g����
            carManagementWork.WheelDriveMethodNm = carInfoRow.WheelDriveMethodNm;   // �쓮��������
            carManagementWork.AddiCarSpec1 = carInfoRow.AddiCarSpec1;               // �ǉ�����1
            carManagementWork.AddiCarSpec2 = carInfoRow.AddiCarSpec2;               // �ǉ�����2
            carManagementWork.AddiCarSpec3 = carInfoRow.AddiCarSpec3;               // �ǉ�����3
            carManagementWork.AddiCarSpec4 = carInfoRow.AddiCarSpec4;               // �ǉ�����4
            carManagementWork.AddiCarSpec5 = carInfoRow.AddiCarSpec5;               // �ǉ�����5
            carManagementWork.AddiCarSpec6 = carInfoRow.AddiCarSpec6;               // �ǉ�����6
            carManagementWork.AddiCarSpecTitle1 = carInfoRow.AddiCarSpecTitle1;     // �ǉ������^�C�g��1
            carManagementWork.AddiCarSpecTitle2 = carInfoRow.AddiCarSpecTitle2;     // �ǉ������^�C�g��2
            carManagementWork.AddiCarSpecTitle3 = carInfoRow.AddiCarSpecTitle3;     // �ǉ������^�C�g��3
            carManagementWork.AddiCarSpecTitle4 = carInfoRow.AddiCarSpecTitle4;     // �ǉ������^�C�g��4
            carManagementWork.AddiCarSpecTitle5 = carInfoRow.AddiCarSpecTitle5;     // �ǉ������^�C�g��5
            carManagementWork.AddiCarSpecTitle6 = carInfoRow.AddiCarSpecTitle6;     // �ǉ������^�C�g��6
            carManagementWork.RelevanceModel = carInfoRow.RelevanceModel;           // �֘A�^��
            carManagementWork.SubCarNmCd = carInfoRow.SubCarNmCd;                   // �T�u�Ԗ��R�[�h
            carManagementWork.ModelGradeSname = carInfoRow.ModelGradeSname;         // �^���O���[�h����
            carManagementWork.BlockIllustrationCd = carInfoRow.BlockIllustrationCd; // �u���b�N�C���X�g�R�[�h
            carManagementWork.ThreeDIllustNo = carInfoRow.ThreeDIllustNo;           // 3D�C���X�gNo
            carManagementWork.PartsDataOfferFlag = carInfoRow.PartsDataOfferFlag;   // ���i�f�[�^�񋟃t���O
            carManagementWork.InspectMaturityDate = carInfoRow.InspectMaturityDate; // �Ԍ�������
            carManagementWork.LTimeCiMatDate = carInfoRow.LTimeCiMatDate;           // �O��Ԍ�������
            carManagementWork.CarInspectYear = carInfoRow.CarInspectYear;           // �Ԍ�����
            carManagementWork.Mileage = carInfoRow.Mileage;                         // �ԗ����s����
            carManagementWork.CarNo = carInfoRow.CarNo;                             // ����
            carManagementWork.FullModelFixedNoAry = carInfoRow.FullModelFixedNoAry; // �t���^���Œ�ԍ��z��
            // ----- ADD 2010/04/27 ----------------->>>>>
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            formatter.Serialize(ms, carInfoRow.FreeSrchMdlFxdNoAry);
            carManagementWork.FreeSrchMdlFxdNoAry = ms.GetBuffer(); // ���R�����^���Œ�ԍ��z��
            ms.Close();
            // ----- ADD 2010/04/27 -----------------<<<<<
            carManagementWork.ColorCode = carInfoRow.ColorCode;                     // �J���[�R�[�h
            carManagementWork.ColorName1 = carInfoRow.ColorName1;                   // �J���[����
            carManagementWork.TrimCode = carInfoRow.TrimCode;                       // �g�����R�[�h
            carManagementWork.TrimName = carInfoRow.TrimName;                       // �g��������
            carManagementWork.CategoryObjAry = this.GetEquipInfoRows(carInfoRow.CarRelationGuid); // �����I�u�W�F�N�g�z��
            carManagementWork.CarRelationGuid = carInfoRow.CarRelationGuid;         // �ԗ���񋤒ʃL�[

            // --- ADD 2009/09/08�A ---------->>>>>
            carManagementWork.CarAddInfo1 = carInfoRow.CarAddInfo1;         // ���q�ǉ����P
            carManagementWork.CarAddInfo2 = carInfoRow.CarAddInfo2;         // ���q�ǉ����Q
            carManagementWork.CarNote = carInfoRow.CarNote;         // ���q���l
            // --- ADD 2009/09/08�A ---------->>>>>

            // --- ADD 2013/03/21 ---------->>>>>
            // PMNS:���Y/�O�ԋ敪�Z�b�g
            carManagementWork.DomesticForeignCode = carInfoRow.DomesticForeignCode;
            // --- ADD 2013/03/21 ----------<<<<<

            return carManagementWork;
        }

        /// <summary>
        /// ���q���e�[�u���擾����(���q���Dictionary���擾)
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <returns>���q�������ʃf�[�^�Z�b�g</returns>
        public PMKEN01010E GetCarInfoFromDic( int salesRowNo )
        {
            PMKEN01010E carInfoDataSet = null;
            EstimateInputDataSet.EstimateDetailRow row = this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (row != null)
            {
                carInfoDataSet = this.GetCarInfoFromDic(row.CarRelationGuid);
            }
            return carInfoDataSet;
        }

        /// <summary>
        /// ���q���e�[�u���擾����(���q���Dictionary���擾)
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <returns>���q�������ʃf�[�^�Z�b�g</returns>
        private PMKEN01010E GetCarInfoFromDic( Guid carRelationGuid )
        {
            PMKEN01010E carInfoDataSet = null;
            if (this._carInfoDictionary.ContainsKey(carRelationGuid))
            {
                carInfoDataSet = this._carInfoDictionary[carRelationGuid];
            }
            return carInfoDataSet;
        }

        /// <summary>
        /// ���q�����f�[�^�e�[�u���N���ݒ菈��
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="firstEntryDate">�N��</param>
        public void SettingCarModelUIDataFromFirstEntryDate( Guid carRelationGuid, int firstEntryDate )
        {
            if (this._carInfoDictionary.ContainsKey(carRelationGuid))
            {
                this._carInfoDictionary[carRelationGuid].CarModelUIData[0].ProduceTypeOfYearInput = firstEntryDate / 100;
            }
        }

        /// <summary>
        /// ���q�����f�[�^�e�[�u���ԑ�ԍ��ݒ菈��
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="frameNo">�ԑ�ԍ�</param>
        public void SettingCarModelUIDataFromProduceFrameNo(Guid carRelationGuid, string frameNo)
        {
            if (this._carInfoDictionary.ContainsKey(carRelationGuid))
            {
                // ---UPD 2009/10/22 ----->>>>>
                if (this._carInfoDictionary[carRelationGuid].CarModelUIData.Count != 0)
                {
                    //this._carInfoDictionary[carRelationGuid].CarModelUIData[0].ProduceFrameNoInput = produceFrameNo;
                    this._carInfoDictionary[carRelationGuid].CarModelUIData[0].FrameNo = frameNo;
                    // --- DEL 2013/03/21 ---------->>>>>
                    //this._carInfoDictionary[carRelationGuid].CarModelUIData[0].SearchFrameNo = TStrConv.StrToIntDef(frameNo.Trim(), 0);
                    // --- DEL 2013/03/21 ----------<<<<<
                    // --- ADD 2013/03/21 ---------->>>>>
                    // PMNS:�ԑ�ԍ�(�����p)�ݒ�
                    // ���Y/�O�ԋ敪���O��(2)�̏ꍇ�͎ԑ�ԍ�(�����p)��0���Z�b�g����
                    if (this._carInfoDictionary[carRelationGuid].CarModelUIData[0].DomesticForeignCode == 2)
                    {
                        this._carInfoDictionary[carRelationGuid].CarModelUIData[0].SearchFrameNo = 0;
                    }
                    else
                    {
                    this._carInfoDictionary[carRelationGuid].CarModelUIData[0].SearchFrameNo = TStrConv.StrToIntDef(frameNo.Trim(), 0);
                }
                    // --- ADD 2013/03/21 ----------<<<<<
                }
                // ---UPD 2009/10/22 -----<<<<<
            }
        }

        /// <summary>
        /// �Ώ۔N���擾����(�ԑ�ԍ����擾)
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="frameNo">�ԑ�ԍ�</param>
        /// <returns>�N��(int)</returns>
        public int GetProduceTypeOfYear( Guid carRelationGuid, int frameNo )
        {
            return this.GetProduceTypeOfYearProc(carRelationGuid, frameNo);
        }

        /// <summary>
        /// �Ώ۔N���擾����(�ԑ�ԍ����擾)
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="frameNo">�ԑ�ԍ�</param>
        /// <returns>�N��(int)</returns>
        private int GetProduceTypeOfYearProc( Guid carRelationGuid, int frameNo )
        {
            int retDateTime = 0;
            PMKEN01010E carInfoDataSet = this.GetCarInfoFromDic(carRelationGuid);
            if (carInfoDataSet != null)
            {
                string filter = string.Format("{0}<={1} AND {2}>={3}",
                    carInfoDataSet.PrdTypYearInfo.StProduceFrameNoColumn.ColumnName, frameNo,
                    carInfoDataSet.PrdTypYearInfo.EdProduceFrameNoColumn.ColumnName, frameNo);
                PMKEN01010E.PrdTypYearInfoRow[] row = (PMKEN01010E.PrdTypYearInfoRow[])carInfoDataSet.PrdTypYearInfo.Select(filter);
                if (row.Length > 0) retDateTime = row[0].ProduceTypeOfYear;
            }
            return retDateTime * 100;
        }

        /// <summary>
        /// ���Y�N���͈̓`�F�b�N
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="firstEntryDate">�N��</param>
        /// <returns>true:�͈͓� false:�͈͊O</returns>
        public bool CheckProduceTypeOfYearRange( Guid carRelationGuid, int firstEntryDate )
        {
            bool ret = true;

            if (firstEntryDate != 0)
            {
                firstEntryDate = firstEntryDate / 100 * 100;
                int fyy = firstEntryDate / 10000;
                int fmm = firstEntryDate / 100 % 100;

                EstimateInputDataSet.CarInfoRow row = this._carInfoDataTable.FindByCarRelationGuid(carRelationGuid);
                int styy = row.StProduceTypeOfYear.Year;
                int stmm = row.StProduceTypeOfYear.Month;
                int edyy = row.EdProduceTypeOfYear.Year;
                int edmm = row.EdProduceTypeOfYear.Month;
                int st = 0;
                int ed = 0;
                if (fmm != 0)
                {
                    // �N���Ń`�F�b�N
                    st = styy * 10000 + stmm * 100;
                    ed = edyy * 10000 + edmm * 100;
                }
                else
                {
                    // �N�݂̂Ń`�F�b�N
                    st = styy * 10000;
                    ed = edyy * 10000;
                }

                if (row.StProduceTypeOfYear != DateTime.MinValue) if (firstEntryDate < st) ret = false;

                if (row.EdProduceTypeOfYear != DateTime.MinValue) if (firstEntryDate > ed) ret = false;
            }
            return ret;
        }

        // 2009.06.18 Add >>>
        /// <summary>
        /// �ԑ�ԍ��͈̓`�F�b�N
        /// </summary>
        /// <param name="carRelationGuid">�ԗ���񋤒ʃL�[</param>
        /// <param name="inputFrameNo">�ԑ�ԍ����͕�����</param>
        /// <param name="searchFrameNo">�ԑ�ԍ�</param>
        /// <returns>True:�͈͓��AFalse:�͈͊O</returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 DEL
        //public bool CheckProduceFrameNo(Guid carRelationGuid, int searchFrameNo)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.15 ADD
        public bool CheckProduceFrameNo( Guid carRelationGuid, string inputFrameNo, int searchFrameNo )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.15 ADD
        {
            bool ret = true;

            EstimateInputDataSet.CarInfoRow row = this._carInfoDataTable.FindByCarRelationGuid( carRelationGuid );

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.14 DEL
            //if (row != null && searchFrameNo != 0)
            //{
            //    if (( row.StProduceFrameNo != 0 && row.StProduceFrameNo > searchFrameNo ) ||
            //        ( row.EdProduceFrameNo != 0 && row.EdProduceFrameNo < searchFrameNo )) ret = false;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.14 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.14 ADD
            if ( row != null )
            {
                if ( searchFrameNo != 0 || !string.IsNullOrEmpty( inputFrameNo ) )
                {
                    if ( (row.StProduceFrameNo != 0 && row.StProduceFrameNo > searchFrameNo) ||
                        (row.EdProduceFrameNo != 0 && row.EdProduceFrameNo < searchFrameNo) ) ret = false;
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.14 ADD

            return ret;
        }
        // 2009.06.18 Add <<<

        /// <summary>
        /// ���q����(���q�������o������茟��)
        /// </summary>
        /// <param name="carSearchCondition">���q�������o����</param>
        /// <param name="carInfoDataSet">���q�����f�[�^�Z�b�g</param>
        /// <returns>CarSearchResultReport</returns>
        public CarSearchResultReport SearchCar( CarSearchCondition carSearchCondition, ref PMKEN01010E carInfoDataSet )
        {
            return this._carSearchController.Search(carSearchCondition, ref carInfoDataSet);
        }

        /// <summary>
        /// ���q����(�t���^���Œ�ԍ���茟��)
        /// </summary>
        /// <param name="fullModelFixedNo">�t���^���Œ�ԍ��z��</param>
        /// <param name="modelDesignationNo">�^���w��ԍ�(���ݒ��)</param>
        /// <param name="categoryNo">�ޕʋ敪�ԍ�(���ݒ��)</param>
        /// <param name="carInfoDataSet">���q�����f�[�^�Z�b�g</param>
        /// <returns>CarSearchResultReport</returns>
        /// <remarks>�^���w��ԍ�����їޕʋ敪�ԍ��́A�ޕʌ����ɂ��t���^���Œ�ԍ��z��̏ꍇ�̂ݕK�{</remarks>
        // --- UPD m.suzuki 2010/05/21 ---------->>>>>
        //public CarSearchResultReport SearchCar( int[] fullModelFixedNo, int modelDesignationNo, int categoryNo, ref PMKEN01010E carInfoDataSet )
        public CarSearchResultReport SearchCar(int[] fullModelFixedNo, string[] freeSrchMdlFxdNo, int modelDesignationNo, int categoryNo, ref PMKEN01010E carInfoDataSet)
        // --- UPD m.suzuki 2010/05/21 ----------<<<<<
        {
            CarSearchResultReport ret = CarSearchResultReport.retFailed;
            // --- UPD m.suzuki 2010/05/21 ---------->>>>>
            //if (fullModelFixedNo.Length != 0)
            if (fullModelFixedNo.Length != 0 || freeSrchMdlFxdNo.Length != 0)
            // --- UPD m.suzuki 2010/05/21 ----------<<<<<
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/15 UPD
                //ret = this._carSearchController.SearchByFullModelFixedNo(fullModelFixedNo, modelDesignationNo, categoryNo, ref carInfoDataSet);

                CarSearchCondition carSearchCond = new CarSearchCondition();
                carSearchCond.ModelDesignationNo = modelDesignationNo;
                carSearchCond.CategoryNo = categoryNo;
                // --- UPD m.suzuki 2010/05/21 ---------->>>>>
                //ret = this._carSearchController.SearchByFullModelFixedNo( fullModelFixedNo, carSearchCond, ref carInfoDataSet );
                ret = this._carSearchController.SearchByFullModelFixedNo(fullModelFixedNo, freeSrchMdlFxdNo, carSearchCond, ref carInfoDataSet);
                // --- UPD m.suzuki 2010/05/21 ----------<<<<<
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/15 UPD
            }
            return ret;
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/15 ADD
        /// <summary>
        /// ���q����(�t���^���Œ�ԍ���茟��)
        /// </summary>
        /// <param name="fullModelFixedNo">�t���^���Œ�ԍ��z��</param>
        /// <param name="carSearchCond">���q���������N���X</param>
        /// <param name="carInfoDataSet">���q�����f�[�^�Z�b�g</param>
        /// <returns>CarSearchResultReport</returns>
        /// <remarks>�^���w��ԍ�����їޕʋ敪�ԍ��́A�ޕʌ����ɂ��t���^���Œ�ԍ��z��̏ꍇ�̂ݕK�{</remarks>
        // --- UPD m.suzuki 2010/05/21 ---------->>>>>
        //public CarSearchResultReport SearchCar( int[] fullModelFixedNo, CarSearchCondition carSearchCond, ref PMKEN01010E carInfoDataSet )
        public CarSearchResultReport SearchCar(int[] fullModelFixedNo, string[] freeSrchMdlFxdNo, CarSearchCondition carSearchCond, ref PMKEN01010E carInfoDataSet)
        // --- UPD m.suzuki 2010/05/21 ----------<<<<<
        {
            CarSearchResultReport ret = CarSearchResultReport.retFailed;
            // --- UPD m.suzuki 2010/05/21 ---------->>>>>
            //if ( fullModelFixedNo.Length != 0 )
            if (fullModelFixedNo.Length != 0 || freeSrchMdlFxdNo.Length != 0)
            // --- UPD m.suzuki 2010/05/21 ----------<<<<<
            {
                // --- UPD m.suzuki 2010/05/21 ---------->>>>>
                //ret = this._carSearchController.SearchByFullModelFixedNo( fullModelFixedNo, carSearchCond, ref carInfoDataSet );
                ret = this._carSearchController.SearchByFullModelFixedNo(fullModelFixedNo, freeSrchMdlFxdNo, carSearchCond, ref carInfoDataSet);
                // --- UPD m.suzuki 2010/05/21 ----------<<<<<
            }
            return ret;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/15 ADD

        // --- ADD 2013/03/21 ---------->>>>>
        /// <summary>
        /// �n���h���ʒu�`�F�b�N
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <param name="vinCode">VIN�R�[�h</param>
        /// <returns>true:��v false:�s��v</returns>
        public bool CheckHandlePosition(Guid carRelationGuid, string vinCode)
        {
            // �L���b�V���̗L�����`�F�b�N
            if (this._carInfoDictionary.ContainsKey(carRelationGuid))
            {
                try
                {
                    // VIN�R�[�h����n���h���ʒu���擾(�E/���n���h���ȊO�̏ꍇ�̓`�F�b�N���s��Ȃ�)
                    HandleInfoCdRet posVin = this._carSearchController.GetHandlePositionFromVinCode(vinCode);
                    if (posVin != HandleInfoCdRet.PositionRight && posVin != HandleInfoCdRet.PositionLeft)
                        return true;

                    // �^�������őI������Ă��邷�ׂĂ̍s���r����
                    int pos = this._carInfoDictionary[carRelationGuid].CarModelInfo.HandleInfoCdColumn.Ordinal;
                    int state = this._carInfoDictionary[carRelationGuid].CarModelInfo.SelectionStateColumn.Ordinal;
                    foreach (DataRow row in this._carInfoDictionary[carRelationGuid].CarModelInfo.Rows)
                    {
                        // �I������Ă��Ȃ��s�̓X�L�b�v����
                        if ((bool)row[state] != true)
                            continue;

                        // �E/���n���h���ȊO��1���ł��������ꍇ�͏����𒆒f���A�ʒu�̃`�F�b�N���s��Ȃ�
                        HandleInfoCdRet posKind = (HandleInfoCdRet)row[pos];
                        if (posKind != HandleInfoCdRet.PositionRight && posKind != HandleInfoCdRet.PositionLeft)
                            return true;

                        // �n���h���ʒu���r����
                        if (posKind == posVin)
                        {
                            // 1���ł��n���h���ʒu����v���Ă���ꍇ�A��v�Ƃ���
                            return true;
                        }
                    }

                    // ���ׂĂ̍s�̃n���h���ʒu���قȂ�ꍇ�A�s��v�Ƃ���
                    return false;
                }
                catch
                {
                    // ��O�����������ꍇ�̓`�F�b�N���s��Ȃ�
                }
            }

            return true;
        }
        // --- ADD 2013/03/21 ----------<<<<<
        #endregion

        // ===================================================================================== //
        // �D�Ǖ��i���
        // ===================================================================================== //
        #region ���D�Ǖ��i���

        /// <summary>
        /// �D�Ǐ��I������
        /// </summary>
        /// <param name="primeRelationGuid">�D�Ǐ��A��GUID</param>
        /// <param name="joinDispOrder">�����\������</param>
        /// <returns>true:�Y�����萳��I�� false:�Y���Ȃ�</returns>
        public bool SelectPrimeInfo( Guid primeRelationGuid, int joinDispOrder )
        {
            return  this.SelectPrimeInfo(this._primeInfoDataTable, primeRelationGuid, joinDispOrder);
        }

        /// <summary>
        /// �D�Ǐ��I������
        /// </summary>
        /// <param name="primeInfoDataTable">�D�Ǐ��f�[�^�e�[�u��</param>
        /// <param name="primeRelationGuid">�D�Ǐ��A��GUID</param>
        /// <param name="joinDispOrder">�����\������</param>
        /// <returns>true:�Y�����萳��I�� false:�Y���Ȃ�</returns>
        private bool SelectPrimeInfo( EstimateInputDataSet.PrimeInfoDataTable primeInfoDataTable, Guid primeRelationGuid, int joinDispOrder )
        {
            bool ret = false;

            if (primeRelationGuid != Guid.Empty)
            {
                this.SettingPrimeInfoAllState(primeInfoDataTable, primeRelationGuid, false);   // �S���בI������

                EstimateInputDataSet.PrimeInfoRow row = primeInfoDataTable.FindByPrimeInfoRelationGuidJoinDispOrder(primeRelationGuid, joinDispOrder);

                if (row!=null)
                {
                    row.SelectionState = true;
                    ret = true;
                }
            }
            
            return ret;
        }


        /// <summary>
        /// �D�Ǐ�񖾍בI���^��������
        /// </summary>
        /// <param name="primeInfoDataTable">�D�Ǐ��f�[�^�e�[�u��</param>
        /// <param name="primeRelationGuid">�D�Ǐ��A��GUID</param>
        /// <param name="state">�I�����</param>
        private void SettingPrimeInfoAllState( EstimateInputDataSet.PrimeInfoDataTable primeInfoDataTable,Guid primeRelationGuid, bool state )
        {
            EstimateInputDataSet.PrimeInfoRow[] primeInfoRowArray = (EstimateInputDataSet.PrimeInfoRow[])primeInfoDataTable.Select(string.Format("{0}='{1}'", primeInfoDataTable.PrimeInfoRelationGuidColumn.ColumnName, primeRelationGuid));
            if (( primeInfoRowArray != null ) && ( primeInfoRowArray.Length > 0 ))
            {
                foreach (EstimateInputDataSet.PrimeInfoRow row in primeInfoRowArray)
                {
                    row.SelectionState = false;
                }
            }
        }

        /// <summary>
        /// �D�ǃf�[�^�̃f�[�^�e�[�u������
        /// </summary>
        /// <param name="primeInfoRelationGuid">�D�Ǐ��A��GUID</param>
        /// <param name="goodsSearchDiv">���i�����敪</param>
        /// <param name="genuinePartsRet"></param>
        /// <param name="partsInfoLinkGuid">���i��񃊃��NGUID</param>
        /// <param name="partsInfoDataSet">���i�����f�[�^�Z�b�g</param>
        /// <param name="warehouseCodeArray">�q�ɔz��</param>
        /// <param name="searchBLGoodsCode">����BL���i�R�[�h</param>
        /// <br>Note       : �p�i���͎��̔����v�Z�ŃG���[�������錏�̏C��</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/02/14</br>
        /// <br>Update Note: 2013/02/20 杍^</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A2013/03/13�z�M��</br>
        /// <br>             Redmine#34434 No.1180 ���݌ɐ����O�̂Ƃ��݌ɐ����󔒂ŕ\�������̑Ή�</br>
        private void MakePrimeInfoTable( Guid primeInfoRelationGuid, GoodsSearchDiv goodsSearchDiv, GenuinePartsRet genuinePartsRet, Guid partsInfoLinkGuid, PartsInfoDataSet partsInfoDataSet , string[] warehouseCodeArray,int searchBLGoodsCode )
        {
            EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "START");
                
            this._primeInfoDataTable.BeginLoadData();

            this.DeletePrimeInfoRow(primeInfoRelationGuid);

            int dispOrder = 1;
            int firstJoinDispOrder = 0;

            // ����pBL�R�[�h�̌���
            // BL�R�[�h�����A����pBL���i�R�[�h�敪�u�����v�ABL�R�[�h�L��
            int prtBLGoodsCode = 0;
            string prtBLGoodsName = string.Empty;
            if (( goodsSearchDiv == GoodsSearchDiv.BLPartsSearch ) &&
                ( this._estimateInputInitDataAcs.GetSalesTtlSt().PrtBLGoodsCodeDiv == 1 ) &&
                ( searchBLGoodsCode > 0 ))
            {
                prtBLGoodsCode = searchBLGoodsCode;
                string blGoodsHalfName;
                this._estimateInputInitDataAcs.GetName_FromBLGoods(searchBLGoodsCode, out prtBLGoodsName, out blGoodsHalfName);
            }

            EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "�����擾 START");
            List<GoodsUnitData> goodsUnitDataList = partsInfoDataSet.GetGoodsList(genuinePartsRet.PrimePartsList);
            //List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(false, this._estimateInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd).ToArray(typeof(GoodsUnitData)));
            EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "�����擾 END" + goodsUnitDataList.Count.ToString());

            EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "�s���ݒ� START");
            this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true);
            EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "�s���ݒ� END");

            EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "�P���v�Z START");
            List<UnitPriceCalcRet> unitPriceCalcRetList = this.CalculateSalesRelevanceUnitPrice(goodsUnitDataList);
            EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "�P���v�Z END" + goodsUnitDataList.Count.ToString());

            foreach (PrimePartsRet primePartsRet in genuinePartsRet.PrimePartsList)
            {
                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1�W�J START");

                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1�W�J ���i�m�� START");
                GoodsUnitData goodsUnitData = null;
                if (goodsUnitDataList != null)
                {
                    // --- UPD 2011/02/14---------->>>>>
                    //foreach ( GoodsUnitData goodsUnitDataWk in goodsUnitDataList )
                    //{
                    //    if ( (goodsUnitDataWk.GoodsNo == primePartsRet.GoodsNo) &&
                    //        (goodsUnitDataWk.GoodsMakerCd == primePartsRet.GoodsMakerCd) )
                    //    {
                    //        goodsUnitData = goodsUnitDataWk;
                    //    }
                    //}
                    goodsUnitData = goodsUnitDataList.Find(
                            delegate(GoodsUnitData goodsUnitDataWk)
                            {
                                return ((goodsUnitDataWk.GoodsNo == primePartsRet.GoodsNo) &&
                                        (goodsUnitDataWk.GoodsMakerCd == primePartsRet.GoodsMakerCd));
                            }
                        );
                    // --- UPD 2011/02/14----------<<<<<
                }
                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1�W�J ���i�m�� END");

                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1�W�J �v���p�e�B�R�s�[ START");
                //if (goodsUnitData == null) goodsUnitData = (GoodsUnitData)DBAndXMLDataMergeParts.CopyPropertyInClass(primePartsRet, typeof(GoodsUnitData));
                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1�W�J �v���p�e�B�R�s�[ END");

                //EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1�W�J �s���ݒ� START");
                //this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitData, true);
                //EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1�W�J �s���ݒ� END");

                EstimateInputDataSet.PrimeInfoRow row = this._primeInfoDataTable.NewPrimeInfoRow();

                row.PrimeInfoRelationGuid = primeInfoRelationGuid;
                row.JoinDispOrder = dispOrder;
                row.JoinSrcPartsNoNoneH = primePartsRet.JoinSourPartsNoNoneH;
                row.JoinSrcPartsNoWithH = primePartsRet.JoinSourPartsNoWithH;
                row.JoinSourceMakerCode = primePartsRet.JoinSourceMakerCode;
                row.JoinSpecialNote = primePartsRet.JoinSpecialNote;

                // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                row.PrmSetDtlName2 = primePartsRet.PrmSetDtlName2;
                // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                row.GoodsNo = goodsUnitData.GoodsNo;                                // �i��
                row.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                      // ���[�J�[�R�[�h
                row.MakerName = goodsUnitData.MakerName;                            // ���[�J�[����
                row.MakerKanaName = goodsUnitData.MakerKanaName;                    // ���[�J�[���̃J�i
                row.GoodsName = goodsUnitData.GoodsName;                            // �i��
                row.GoodsNameKana = goodsUnitData.GoodsNameKana;                    // �i���J�i
                row.GoodsKindCode = goodsUnitData.GoodsKindCode;                    // ���i����
                row.GoodsLGroup = goodsUnitData.GoodsLGroup;                        // ���i�啪�ޖ���
                row.GoodsLGroupName = goodsUnitData.GoodsLGroupName;                // ���i�啪�ރR�[�h
                row.GoodsMGroup = goodsUnitData.GoodsMGroup;                        // ���i�����ރR�[�h
                row.GoodsMGroupName = goodsUnitData.GoodsMGroupName;                // ���i�����ޖ���
                row.BLGroupCode = goodsUnitData.BLGroupCode;                        // BL�O���[�v�R�[�h
                row.BLGroupName = goodsUnitData.BLGroupName;                        // BL�O���[�v�R�[�h����
                row.BLGoodsCode = goodsUnitData.BLGoodsCode;                        // BL���i�R�[�h
                row.BLGoodsFullName = goodsUnitData.BLGoodsFullName;                // BL���i�R�[�h���́i�S�p�j
                row.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;        // ���Е��ރR�[�h
                row.EnterpriseGanreName = goodsUnitData.EnterpriseGanreName;        // ���Е��ޖ���
                row.GoodsRateRank = goodsUnitData.GoodsRateRank;                    // ���i�|�������N
                row.RateBLGoodsCode = goodsUnitData.BLGoodsCode;                    // BL���i�R�[�h�i�|���j
                row.RateBLGoodsName = goodsUnitData.BLGoodsFullName;                // BL���i�R�[�h���́i�|���j
                row.RateGoodsRateGrpCd = goodsUnitData.GoodsRateGrpCode;            // ���i�|���O���[�v�R�[�h�i�|���j
                row.RateGoodsRateGrpNm = goodsUnitData.GoodsRateGrpName;            // ���i�|���O���[�v���́i�|���j
                row.RateBLGroupCode = goodsUnitData.BLGroupCode;                    // BL�O���[�v�R�[�h�i�|���j
                row.RateBLGroupName = goodsUnitData.BLGroupName;                    // BL�O���[�v���́i�|���j
                row.TaxationDivCd = goodsUnitData.TaxationDivCd;                    // �ېŋ敪
                // 2009/11/25 Add >>>
                row.SalesCode = goodsUnitData.SalesCode;                            // �̔��敪�R�[�h
                row.SalesCdNm = goodsUnitData.SalesCodeName;                        // �̔��敪����
                // 2009/11/25 Add <<<

                row.SupplierCd = goodsUnitData.SupplierCd;                          // �d����R�[�h
                row.SupplierSnm = goodsUnitData.SupplierSnm;                        // �d���於��

                row.PrtBLGoodsCode = ( prtBLGoodsCode == 0 ) ? goodsUnitData.BLGoodsCode : prtBLGoodsCode;
                row.PrtBLGoodsName = ( prtBLGoodsCode == 0 ) ? goodsUnitData.BLGoodsFullName : prtBLGoodsName;

                row.ShipmentCnt = partsInfoDataSet.GetJoinQty(primePartsRet.JoinSourceMakerCode, primePartsRet.JoinSourPartsNoWithH, row.GoodsMakerCd, row.GoodsNo);

                row.PartsInfoLinkGuid = partsInfoLinkGuid;
                row.DtlRelationGuid = Guid.NewGuid();
                row.UOEOrderGuid = Guid.Empty;

                row.ExistSetInfo = partsInfoDataSet.UsrSetParts.SetExist(row.GoodsMakerCd, row.GoodsNo);

                row.GoodsSearchDivCd = (int)goodsSearchDiv;

                // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                GoodsPrice goodsPrice = this._estimateInputInitDataAcs.GetGoodsPrice(this._salesSlip.SalesDate, goodsUnitData);
                if (goodsPrice != null) row.OpenPriceDiv = goodsPrice.OpenPriceDiv; // �I�[�v�����i�敪
                // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // ADD 2012/08/20 2012/09/12�z�M �V�X�e���e�X�g��Q��8�Ή� ------------------------>>>>>
                row.GoodsSpecialNote = primePartsRet.GoodsSpecialNote;
                // ADD 2012/08/20 2012/09/12�z�M �V�X�e���e�X�g��Q��8�Ή� ------------------------<<<<<
                // ADD 2012/09/13 2012/09/19�z�M SCM��Q�ꗗ��125�Ή� ------------------------------>>>>>
                if (primePartsRet.GoodsSpecialNote.Length > 40) row.GoodsSpecialNote = primePartsRet.GoodsSpecialNote.Substring(0, 40);
                // ADD 2012/09/13 2012/09/19�z�M SCM��Q�ꗗ��125�Ή� ------------------------------<<<<<

                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1�W�J �P�����ݒ� START");
                // �P�����ݒ�
                this.PrimeInfoRowPriceInfoSettingFromUnitPriceCalcRetList(row, unitPriceCalcRetList, false, false, true, true);
                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1�W�J �P�����ݒ� END");

                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1�W�J �݌� START");
                if (( goodsUnitData.StockList != null ) &&
                    ( goodsUnitData.StockList.Count > 0 ))
                {
                    this.CacheStockInfo(goodsUnitData.StockList);

                    if (( warehouseCodeArray != null ) && ( warehouseCodeArray.Length > 0 ))
                    {
                        Stock stock = this._estimateInputInitDataAcs.GetStockFromGoodsUnitData(goodsUnitData, warehouseCodeArray);
                        if (stock != null)
                        {
                            row.WarehouseCode = stock.WarehouseCode.Trim();
                            row.WarehouseName = stock.WarehouseName;
                            row.WarehouseShelfNo = stock.WarehouseShelfNo;
                            //row.ShipmentPosCnt = stock.ShipmentPosCnt;   // DEL 2013/02/20 tanh Redmine#34434 No.1180 

                            // ADD 2013/02/20 tanh Redmine#34434 No.1180 ---- >>>>>>>>>>>>
                            if (string.IsNullOrEmpty(stock.WarehouseCode.Trim()))
                            {
                                row.ShipmentPosCnt = string.Empty;
                            }
                            else
                            {
                                row.ShipmentPosCnt = stock.ShipmentPosCnt.ToString("N");
                            }
                            // ADD 2013/02/20 tanh Redmine#34434 No.1180 ---- <<<<<<<<<<<<
                        }
                    }
                }
                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1�W�J �݌� END");

                this.CalculateCost(row);

                this._primeInfoDataTable.AddPrimeInfoRow(row);

                if (firstJoinDispOrder == 0) firstJoinDispOrder = dispOrder;

                dispOrder++;

                // ���i�����L���b�V��
                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1�W�J �L���b�V��START");
                this.CacheGoodsUnitData(goodsUnitData);
                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1�W�J �L���b�V��END");

                EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "1�W�J END");
            }

            this._primeInfoDataTable.EndLoadData();
            // 1�s�ڂ�I��
            this.SelectPrimeInfo(primeInfoRelationGuid, firstJoinDispOrder);
            EstimateInputInitDataAcs.LogWrite("EstimateInputAcs", "MakePrimeInfoTable", "END");
        }

        /// <summary>
        /// PrimeInfoRelationGuid���Ώ�GUID�̗D�ǃf�[�^���폜���܂��B
        /// </summary>
        /// <param name="primeInfoRelationGuid">�D�Ǐ��A��GUID</param>
        private void DeletePrimeInfoRow( Guid primeInfoRelationGuid )
        {
            if (this._primeInfoControlView == null)
            {
                this._primeInfoControlView = new DataView(this._primeInfoDataTable);
            }

            this._primeInfoControlView.RowFilter = string.Format("{0}='{1}'", this._primeInfoDataTable.PrimeInfoRelationGuidColumn.ColumnName, primeInfoRelationGuid.ToString());

            // �Ώ�GUID�̗D�Ǐ�񂪑��݂���ꍇ�͍폜
            if (this._primeInfoControlView.Count > 0)
            {
                while (this._primeInfoControlView.Count > 0)
                {
                    this._primeInfoControlView.Delete(0);
                }
            }
        }

        /// <summary>
        /// �D�Ǐ��f�[�^�e�[�u��ColumnChanged�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrimeInfoTableDataTable_ColumnChanged( object sender, DataColumnChangeEventArgs e )
        {
            if (e.Column.ColumnName == this._primeInfoDataTable.SelectionStateColumn.ColumnName)
            {
                if (e.ProposedValue is bool)
                {
                    if ((bool)e.ProposedValue == true)
                    {
                        EstimateInputDataSet.PrimeInfoRow row = (EstimateInputDataSet.PrimeInfoRow)e.Row;

                        EstimateInputDataSet.EstimateDetailRow[] estimateDetailRows = (EstimateInputDataSet.EstimateDetailRow[])this._estimateDetailDataTable.Select(string.Format("{0}='{1}'", this._estimateDetailDataTable.PrimeInfoRelationGuidColumn.ColumnName, row.PrimeInfoRelationGuid));

                        if (( estimateDetailRows != null ) && ( estimateDetailRows.Length > 0 ))
                        {
                            this.SettingEstimateDetailRowFromPrimeInfoRow(ref estimateDetailRows[0], row);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �D�Ǖ��i�A��Guid�̑I������Ă���D�Ǖ��i�����擾���܂��B
        /// </summary>
        /// <param name="primeRelationGuid"></param>
        /// <returns></returns>
        private EstimateInputDataSet.PrimeInfoRow GetSelectedPrimeInfoRow( Guid primeRelationGuid )
        {
            EstimateInputDataSet.PrimeInfoRow[] rows = this.SelectPrimeInfoRows(string.Format("{0}='{1}' AND {2}={3}", this._primeInfoDataTable.PrimeInfoRelationGuidColumn.ColumnName, primeRelationGuid, this._primeInfoDataTable.SelectionStateColumn.ColumnName, true), this._primeInfoDataTable);

            return ( rows != null && rows.Length > 0 ) ? rows[0] : null;
        }

        /// <summary>
        /// �w�肵���D�Ǖ��i�A��Guid�̗D�Ǖ��i�s���X�g���擾���܂��B
        /// </summary>
        /// <param name="primeRelationGuid"></param>
        /// <returns></returns>
        private EstimateInputDataSet.PrimeInfoRow[] GetPrimeInfoRows(Guid primeRelationGuid)
        {
            EstimateInputDataSet.PrimeInfoRow[] rows = this.SelectPrimeInfoRows(string.Format("{0}='{1}'", this._primeInfoDataTable.PrimeInfoRelationGuidColumn.ColumnName, primeRelationGuid), this._primeInfoDataTable);

            return rows;
        }

        /// <summary>
        /// �w�肵���t�B���^��������g�p���ėD�Ǐ��f�[�^�e�[�u���̑I�����s���A�Y������D�Ǐ��s�I�u�W�F�N�g�z����擾���܂��B
        /// </summary>
        /// <param name="filterExpression">�t�B���^�������邽�߂̊�ƂȂ镶����</param>
        /// <param name="primeInfoDataTable">�D�Ǐ��f�[�^�e�[�u���I�u�W�F�N�g</param>
        /// <returns>���ϖ��׍s�I�u�W�F�N�g�z��</returns>
        public EstimateInputDataSet.PrimeInfoRow[] SelectPrimeInfoRows(string filterExpression, EstimateInputDataSet.PrimeInfoDataTable primeInfoDataTable)
        {
            EstimateInputDataSet.PrimeInfoRow[] primInfoRowArray = null;

            try
            {
                DataRow[] rowArray = primeInfoDataTable.Select(filterExpression);

                if (rowArray != null)
                {
                    primInfoRowArray = (EstimateInputDataSet.PrimeInfoRow[])rowArray;
                }
            }
            catch { }

            return primInfoRowArray;
        }


        /// <summary>
        /// �D�Ǐ��f�[�^�s�I�u�W�F�N�g���猩�ϖ��׃f�[�^�s�I�u�W�F�N�g��ݒ肵�܂��B
        /// </summary>
        /// <param name="estimateDetailRow"></param>
        /// <param name="primeInfoRow"></param>
        /// <remarks>
        /// <br>Update Note : 2011/07/26 ����</br>
        /// <br>              �������ψ�����̕s��̑Ή�</br>
        /// <br>Update Note: 2013/02/20 杍^</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A2013/03/13�z�M��</br>
        /// <br>             Redmine#34434 No.1180 ���݌ɐ����O�̂Ƃ��݌ɐ����󔒂ŕ\�������̑Ή�</br>
        /// </remarks>
        private void SettingEstimateDetailRowFromPrimeInfoRow( ref EstimateInputDataSet.EstimateDetailRow estimateDetailRow, EstimateInputDataSet.PrimeInfoRow primeInfoRow )
        {
            if (primeInfoRow != null)
            {
                estimateDetailRow.GoodsKindCode_Prime = primeInfoRow.GoodsKindCode;                     // ���i����
                estimateDetailRow.GoodsSearchDivCd_Prime = primeInfoRow.GoodsSearchDivCd;               // ���i�����敪
                estimateDetailRow.GoodsMakerCd_Prime = primeInfoRow.GoodsMakerCd;                       // ���i���[�J�[�R�[�h
                estimateDetailRow.MakerName_Prime = primeInfoRow.MakerName;                             // ���[�J�[����
                estimateDetailRow.MakerKanaName_Prime = primeInfoRow.MakerKanaName;                     // ���[�J�[�J�i����
                estimateDetailRow.GoodsNo_Prime = primeInfoRow.GoodsNo;                                 // ���i�ԍ�
                estimateDetailRow.GoodsName_Prime = primeInfoRow.GoodsName;                             // ���i����
                estimateDetailRow.GoodsNameKana_Prime = primeInfoRow.GoodsNameKana;                     // ���i���̃J�i
                estimateDetailRow.GoodsLGroup_Prime = primeInfoRow.GoodsLGroup;                         // ���i�啪�ރR�[�h
                estimateDetailRow.GoodsLGroupName_Prime = primeInfoRow.GoodsLGroupName;                 // ���i�啪�ޖ���
                estimateDetailRow.GoodsMGroup_Prime = primeInfoRow.GoodsMGroup;                         // ���i�����ރR�[�h
                estimateDetailRow.GoodsMGroupName_Prime = primeInfoRow.GoodsMGroupName;                 // ���i�����ޖ���
                estimateDetailRow.BLGroupCode_Prime = primeInfoRow.BLGroupCode;                         // BL�O���[�v�R�[�h
                estimateDetailRow.BLGroupName_Prime = primeInfoRow.BLGroupName;                         // BL�O���[�v�R�[�h����
                estimateDetailRow.BLGoodsCode_Prime = primeInfoRow.BLGoodsCode;                         // BL���i�R�[�h
                estimateDetailRow.BLGoodsFullName_Prime = primeInfoRow.BLGoodsFullName;                 // BL���i�R�[�h���́i�S�p�j
                estimateDetailRow.EnterpriseGanreCode_Prime = primeInfoRow.EnterpriseGanreCode;         // ���Е��ރR�[�h
                estimateDetailRow.EnterpriseGanreName_Prime = primeInfoRow.EnterpriseGanreName;         // ���Е��ޖ���
                estimateDetailRow.WarehouseCode_Prime = primeInfoRow.WarehouseCode;                     // �q�ɃR�[�h
                estimateDetailRow.WarehouseName_Prime = primeInfoRow.WarehouseName;                     // �q�ɖ���
                estimateDetailRow.WarehouseShelfNo_Prime = primeInfoRow.WarehouseShelfNo;               // �q�ɒI��
                estimateDetailRow.SalesOrderDivCd_Prime = primeInfoRow.SalesOrderDivCd;                 // ����݌Ɏ�񂹋敪
                estimateDetailRow.OpenPriceDiv_Prime = primeInfoRow.OpenPriceDiv;                       // �I�[�v�����i�敪
                estimateDetailRow.GoodsRateRank_Prime = primeInfoRow.GoodsRateRank;                     // ���i�|�������N
                //estimateDetailRow.CustRateGrpCode_Prime = primeInfoRow.CustRateGrpCode;                 // ���Ӑ�|���O���[�v�R�[�h // DEL 2011/07/26
                estimateDetailRow.ListPriceRate_Prime = primeInfoRow.ListPriceRate;                     // �艿��
                estimateDetailRow.RateSectPriceUnPrc_Prime = primeInfoRow.RateSectPriceUnPrc;           // �|���ݒ苒�_�i�艿�j
                estimateDetailRow.RateDivLPrice_Prime = primeInfoRow.RateDivLPrice;                     // �|���ݒ�敪�i�艿�j
                estimateDetailRow.UnPrcCalcCdLPrice_Prime = primeInfoRow.UnPrcCalcCdLPrice;             // �P���Z�o�敪�i�艿�j
                estimateDetailRow.PriceCdLPrice_Prime = primeInfoRow.PriceCdLPrice;                     // ���i�敪�i�艿�j
                estimateDetailRow.StdUnPrcLPrice_Prime = primeInfoRow.StdUnPrcLPrice;                   // ��P���i�艿�j
                estimateDetailRow.FracProcUnitLPrice_Prime = primeInfoRow.FracProcUnitLPrice;           // �[�������P�ʁi�艿�j
                estimateDetailRow.FracProcLPrice_Prime = primeInfoRow.FracProcLPrice;                   // �[�������i�艿�j
                estimateDetailRow.ListPriceTaxIncFl_Prime = primeInfoRow.ListPriceTaxIncFl;             // �艿�i�ō��C�����j
                estimateDetailRow.ListPriceTaxExcFl_Prime = primeInfoRow.ListPriceTaxExcFl;             // �艿�i�Ŕ��C�����j
                estimateDetailRow.ListPriceChngCd_Prime = primeInfoRow.ListPriceChngCd;                 // �艿�ύX�敪
                estimateDetailRow.SalesRate_Prime = primeInfoRow.SalesRate;                             // ������
                estimateDetailRow.RateSectSalUnPrc_Prime = primeInfoRow.RateSectSalUnPrc;               // �|���ݒ苒�_�i����P���j
                estimateDetailRow.RateDivSalUnPrc_Prime = primeInfoRow.RateDivSalUnPrc;                 // �|���ݒ�敪�i����P���j
                estimateDetailRow.UnPrcCalcCdSalUnPrc_Prime = primeInfoRow.UnPrcCalcCdSalUnPrc;         // �P���Z�o�敪�i����P���j
                estimateDetailRow.PriceCdSalUnPrc_Prime = primeInfoRow.PriceCdSalUnPrc;                 // ���i�敪�i����P���j
                estimateDetailRow.StdUnPrcSalUnPrc_Prime = primeInfoRow.StdUnPrcSalUnPrc;               // ��P���i����P���j
                estimateDetailRow.FracProcUnitSalUnPrc_Prime = primeInfoRow.FracProcUnitSalUnPrc;       // �[�������P�ʁi����P���j
                estimateDetailRow.FracProcSalUnPrc_Prime = primeInfoRow.FracProcSalUnPrc;               // �[�������i����P���j
                estimateDetailRow.SalesUnPrcTaxIncFl_Prime = primeInfoRow.SalesUnPrcTaxIncFl;           // ����P���i�ō��C�����j
                estimateDetailRow.SalesUnPrcTaxExcFl_Prime = primeInfoRow.SalesUnPrcTaxExcFl;           // ����P���i�Ŕ��C�����j
                estimateDetailRow.SalesUnPrcChngCd_Prime = primeInfoRow.SalesUnPrcChngCd;               // ����P���ύX�敪
                estimateDetailRow.CostRate_Prime = primeInfoRow.CostRate;                               // ������
                estimateDetailRow.RateSectCstUnPrc_Prime = primeInfoRow.RateSectCstUnPrc;               // �|���ݒ苒�_�i�����P���j
                estimateDetailRow.RateDivUnCst_Prime = primeInfoRow.RateDivUnCst;                       // �|���ݒ�敪�i�����P���j
                estimateDetailRow.UnPrcCalcCdUnCst_Prime = primeInfoRow.UnPrcCalcCdUnCst;               // �P���Z�o�敪�i�����P���j
                estimateDetailRow.PriceCdUnCst_Prime = primeInfoRow.PriceCdUnCst;                       // ���i�敪�i�����P���j
                estimateDetailRow.StdUnPrcUnCst_Prime = primeInfoRow.StdUnPrcUnCst;                     // ��P���i�����P���j
                estimateDetailRow.FracProcUnitUnCst_Prime = primeInfoRow.FracProcUnitUnCst;             // �[�������P�ʁi�����P���j
                estimateDetailRow.FracProcUnCst_Prime = primeInfoRow.FracProcUnCst;                     // �[�������i�����P���j
                estimateDetailRow.SalesUnitCost_Prime = primeInfoRow.SalesUnitCost;                     // �����P��
                estimateDetailRow.SalesUnitCostChngDiv_Prime = primeInfoRow.SalesUnitCostChngDiv;       // �����P���ύX�敪
                estimateDetailRow.RateBLGoodsCode_Prime = primeInfoRow.RateBLGoodsCode;                 // BL���i�R�[�h�i�|���j
                estimateDetailRow.RateBLGoodsName_Prime = primeInfoRow.RateBLGoodsName;                 // BL���i�R�[�h���́i�|���j
                estimateDetailRow.RateGoodsRateGrpCd_Prime = primeInfoRow.RateGoodsRateGrpCd;           // ���i�|���O���[�v�R�[�h�i�|���j
                estimateDetailRow.RateGoodsRateGrpNm_Prime = primeInfoRow.RateGoodsRateGrpNm;           // ���i�|���O���[�v���́i�|���j
                estimateDetailRow.RateBLGroupCode_Prime = primeInfoRow.RateBLGroupCode;                 // BL�O���[�v�R�[�h�i�|���j
                estimateDetailRow.RateBLGroupName_Prime = primeInfoRow.RateBLGroupName;                 // BL�O���[�v���́i�|���j
                estimateDetailRow.PrtBLGoodsCode_Prime = primeInfoRow.PrtBLGoodsCode;                   // BL���i�R�[�h�i����j
                estimateDetailRow.PrtBLGoodsName_Prime = primeInfoRow.PrtBLGoodsName;                   // BL���i�R�[�h���́i����j
                estimateDetailRow.SalesCode_Prime = primeInfoRow.SalesCode;                             // �̔��敪�R�[�h
                estimateDetailRow.SalesCdNm_Prime = primeInfoRow.SalesCdNm;                             // �̔��敪����
                estimateDetailRow.WorkManHour_Prime = primeInfoRow.WorkManHour;                         // ��ƍH��
                estimateDetailRow.ShipmentCnt_Prime = primeInfoRow.ShipmentCnt;                         // �o�א�
                estimateDetailRow.AcceptAnOrderCnt_Prime = primeInfoRow.AcceptAnOrderCnt;               // �󒍐���
                estimateDetailRow.AcptAnOdrAdjustCnt_Prime = primeInfoRow.AcptAnOdrAdjustCnt;           // �󒍒�����
                estimateDetailRow.AcptAnOdrRemainCnt_Prime = primeInfoRow.AcptAnOdrRemainCnt;           // �󒍎c��
                estimateDetailRow.RemainCntUpdDate_Prime = primeInfoRow.RemainCntUpdDate;               // �c���X�V��
                estimateDetailRow.SalesMoneyTaxInc_Prime = primeInfoRow.SalesMoneyTaxInc;               // ������z�i�ō��݁j
                estimateDetailRow.SalesMoneyTaxExc_Prime = primeInfoRow.SalesMoneyTaxExc;               // ������z�i�Ŕ����j
                estimateDetailRow.Cost_Prime = primeInfoRow.Cost;                                       // ����
                estimateDetailRow.GrsProfitChkDiv_Prime = primeInfoRow.GrsProfitChkDiv;                 // �e���`�F�b�N�敪
                estimateDetailRow.SalesGoodsCd_Prime = primeInfoRow.SalesGoodsCd;                       // ���㏤�i�敪
                estimateDetailRow.SalesPriceConsTax_Prime = primeInfoRow.SalesPriceConsTax;             // ������z����Ŋz
                estimateDetailRow.TaxationDivCd_Prime = primeInfoRow.TaxationDivCd;                     // �ېŋ敪
                estimateDetailRow.PartySlipNumDtl_Prime = primeInfoRow.PartySlipNumDtl;                 // �����`�[�ԍ��i���ׁj
                estimateDetailRow.DtlNote_Prime = primeInfoRow.DtlNote;                                 // ���ה��l
                estimateDetailRow.SupplierCd_Prime = primeInfoRow.SupplierCd;                           // �d����R�[�h
                estimateDetailRow.SupplierSnm_Prime = primeInfoRow.SupplierSnm;                         // �d���旪��
                estimateDetailRow.OrderNumber_Prime = primeInfoRow.OrderNumber;                         // �����ԍ�
                estimateDetailRow.WayToOrder_Prime = primeInfoRow.WayToOrder;                           // �������@
                estimateDetailRow.SlipMemo1_Prime = primeInfoRow.SlipMemo1;                             // �`�[�����P
                estimateDetailRow.SlipMemo2_Prime = primeInfoRow.SlipMemo2;                             // �`�[�����Q
                estimateDetailRow.SlipMemo3_Prime = primeInfoRow.SlipMemo3;                             // �`�[�����R
                estimateDetailRow.InsideMemo1_Prime = primeInfoRow.InsideMemo1;                         // �Г������P
                estimateDetailRow.InsideMemo2_Prime = primeInfoRow.InsideMemo2;                         // �Г������Q
                estimateDetailRow.InsideMemo3_Prime = primeInfoRow.InsideMemo3;                         // �Г������R
                estimateDetailRow.BfListPrice_Prime = primeInfoRow.BfListPrice;                         // �ύX�O�艿
                estimateDetailRow.BfSalesUnitPrice_Prime = primeInfoRow.BfSalesUnitPrice;               // �ύX�O����
                estimateDetailRow.BfUnitCost_Prime = primeInfoRow.BfUnitCost;                           // �ύX�O����
                // --- DEL 2013/12/16 Y.Wakita ---------->>>>>
                //estimateDetailRow.CmpltSalesRowNo_Prime = primeInfoRow.CmpltSalesRowNo;                 // �ꎮ���הԍ�
                //estimateDetailRow.CmpltGoodsMakerCd_Prime = primeInfoRow.CmpltGoodsMakerCd;             // ���[�J�[�R�[�h�i�ꎮ�j
                //estimateDetailRow.CmpltMakerName_Prime = primeInfoRow.CmpltMakerName;                   // ���[�J�[���́i�ꎮ�j
                //estimateDetailRow.CmpltMakerKanaName_Prime = primeInfoRow.CmpltMakerKanaName;           // ���[�J�[�J�i���́i�ꎮ�j
                //estimateDetailRow.CmpltGoodsName_Prime = primeInfoRow.CmpltGoodsName;                   // ���i���́i�ꎮ�j
                //estimateDetailRow.CmpltShipmentCnt_Prime = primeInfoRow.CmpltShipmentCnt;               // ���ʁi�ꎮ�j
                //estimateDetailRow.CmpltSalesUnPrcFl_Prime = primeInfoRow.CmpltSalesUnPrcFl;             // ����P���i�ꎮ�j
                //estimateDetailRow.CmpltSalesMoney_Prime = primeInfoRow.CmpltSalesMoney;                 // ������z�i�ꎮ�j
                //estimateDetailRow.CmpltSalesUnitCost_Prime = primeInfoRow.CmpltSalesUnitCost;           // �����P���i�ꎮ�j
                //estimateDetailRow.CmpltCost_Prime = primeInfoRow.CmpltCost;                             // �������z�i�ꎮ�j
                //estimateDetailRow.CmpltPartySalSlNum_Prime = primeInfoRow.CmpltPartySalSlNum;           // �����`�[�ԍ��i�ꎮ�j
                //estimateDetailRow.CmpltNote_Prime = primeInfoRow.CmpltNote;                             // �ꎮ���l
                // --- DEL 2013/12/16 Y.Wakita ----------<<<<<
                estimateDetailRow.PrtGoodsNo_Prime = primeInfoRow.PrtGoodsNo;                           // ����p�i��
                estimateDetailRow.PrtMakerCode_Prime = primeInfoRow.PrtMakerCode;                       // ����p���[�J�[�R�[�h
                estimateDetailRow.PrtMakerName_Prime = primeInfoRow.PrtMakerName;                       // ����p���[�J�[����

                estimateDetailRow.UOEOrderGuid_Prime = primeInfoRow.UOEOrderGuid;
                estimateDetailRow.DtlRelationGuid_Prime = primeInfoRow.DtlRelationGuid;
                //estimateDetailRow.ShipmentPosCnt_Prime = primeInfoRow.ShipmentPosCnt; // DEL 2013/02/20 tanh Redmine#34434 No.1180 

                // -----DEL 杍^ Redmine#34994 2013/03/10------ >>>>>
                // ADD 2013/02/20 tanh Redmine#34434 No.1180 ---- >>>>>>>>>>>>
                //if (!string.IsNullOrEmpty(primeInfoRow.ShipmentPosCnt))
                //{
                    //estimateDetailRow.ShipmentPosCnt_Prime = double.Parse(primeInfoRow.ShipmentPosCnt);
                    
                //}
                //else
                //{
                    //estimateDetailRow.ShipmentPosCnt_Prime = 0;
                //}
                // ADD 2013/02/20 tanh Redmine#34434 No.1180 ---- <<<<<<<<<<<<
                // -----DEL 杍^ Redmine#34994 2013/03/10------ <<<<<

                estimateDetailRow.ShipmentPosCnt_Prime = primeInfoRow.ShipmentPosCnt; // ADD 杍^ Redmine#34994 2013/03/10

                estimateDetailRow.JoinSourPartsNoWithH = primeInfoRow.JoinSrcPartsNoWithH;
                estimateDetailRow.JoinDispOrder = primeInfoRow.JoinDispOrder;
                estimateDetailRow.ListPriceDisplay_Prime = primeInfoRow.ListPriceDisplay;
                estimateDetailRow.PartsInfoLinkGuid_Prime = primeInfoRow.PartsInfoLinkGuid;
                estimateDetailRow.ExistSetInfo_Prime = primeInfoRow.ExistSetInfo;
                // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                estimateDetailRow.PrmSetDtlName2_Prime = primeInfoRow.PrmSetDtlName2;
                // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2012/08/20 2012/09/12�z�M �V�X�e���e�X�g��Q��8�Ή� ------------------------>>>>>
                estimateDetailRow.SpecialNote_Prime = primeInfoRow.GoodsSpecialNote;
                // ADD 2012/08/20 2012/09/12�z�M �V�X�e���e�X�g��Q��8�Ή� ------------------------<<<<<

                if (this.PimeInfoSelectChanged != null)
                {
                    this.PimeInfoSelectChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// ���ϖ��׃f�[�^�s�I�u�W�F�N�g����D�Ǐ��f�[�^�s�I�u�W�F�N�g��ݒ肵�܂��B
        /// </summary>
        /// <param name="salesRowNo"></param>
        public void SettingPrimeInfoRowFromEstimateDetailRow( int salesRowNo )
        {
            this.SettingPrimeInfoRowFromEstimateDetailRow(this._estimateDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo));
        }
        /// <summary>
        /// ���ϖ��׃f�[�^�s�I�u�W�F�N�g����D�Ǐ��f�[�^�s�I�u�W�F�N�g��ݒ肵�܂��B
        /// </summary>
        /// <param name="estimateDetailRow"></param>
        private void SettingPrimeInfoRowFromEstimateDetailRow( EstimateInputDataSet.EstimateDetailRow estimateDetailRow )
        {
            if (estimateDetailRow == null) return;

            if (estimateDetailRow.PrimeInfoRelationGuid != Guid.Empty)
            {
                EstimateInputDataSet.PrimeInfoRow primeInfoRow = this.GetSelectedPrimeInfoRow(estimateDetailRow.PrimeInfoRelationGuid);

                if (primeInfoRow != null)
                {
                    this.SettingPrimeInfoRowFromEstimateDetailRow(ref primeInfoRow, estimateDetailRow);
                }
            }
        }

        /// <summary>
        /// ���ϖ��׃f�[�^�s�I�u�W�F�N�g����D�Ǐ��f�[�^�s�I�u�W�F�N�g��ݒ肵�܂��B
        /// </summary>
        /// <param name="primeInfoRow">�D�Ǐ��f�[�^�s</param>
        /// <param name="estimateDetailRow">���ϖ��׃f�[�^�s</param>
        /// <br>Update Note: 2013/02/20 杍^</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A2013/03/13�z�M��</br>
        /// <br>             Redmine#34434 No.1180 ���݌ɐ����O�̂Ƃ��݌ɐ����󔒂ŕ\�������̑Ή�</br>
        private void SettingPrimeInfoRowFromEstimateDetailRow( ref EstimateInputDataSet.PrimeInfoRow primeInfoRow, EstimateInputDataSet.EstimateDetailRow estimateDetailRow )
        {
            if (primeInfoRow != null)
            {
                primeInfoRow.GoodsKindCode = estimateDetailRow.GoodsKindCode_Prime;                     // ���i����
                primeInfoRow.GoodsSearchDivCd = estimateDetailRow.GoodsSearchDivCd_Prime;               // ���i�����敪
                primeInfoRow.GoodsMakerCd = estimateDetailRow.GoodsMakerCd_Prime;                       // ���i���[�J�[�R�[�h
                primeInfoRow.MakerName = estimateDetailRow.MakerName_Prime;                             // ���[�J�[����
                primeInfoRow.MakerKanaName = estimateDetailRow.MakerKanaName_Prime;                     // ���[�J�[�J�i����
                primeInfoRow.GoodsNo = estimateDetailRow.GoodsNo_Prime;                                 // ���i�ԍ�
                primeInfoRow.GoodsName = estimateDetailRow.GoodsName_Prime;                             // ���i����
                primeInfoRow.GoodsNameKana = estimateDetailRow.GoodsNameKana_Prime;                     // ���i���̃J�i
                primeInfoRow.GoodsLGroup = estimateDetailRow.GoodsLGroup_Prime;                         // ���i�啪�ރR�[�h
                primeInfoRow.GoodsLGroupName = estimateDetailRow.GoodsLGroupName_Prime;                 // ���i�啪�ޖ���
                primeInfoRow.GoodsMGroup = estimateDetailRow.GoodsMGroup_Prime;                         // ���i�����ރR�[�h
                primeInfoRow.GoodsMGroupName = estimateDetailRow.GoodsMGroupName_Prime;                 // ���i�����ޖ���
                primeInfoRow.BLGroupCode = estimateDetailRow.BLGroupCode_Prime;                         // BL�O���[�v�R�[�h
                primeInfoRow.BLGroupName = estimateDetailRow.BLGroupName_Prime;                         // BL�O���[�v�R�[�h����
                primeInfoRow.BLGoodsCode = estimateDetailRow.BLGoodsCode_Prime;                         // BL���i�R�[�h
                primeInfoRow.BLGoodsFullName = estimateDetailRow.BLGoodsFullName_Prime;                 // BL���i�R�[�h���́i�S�p�j
                primeInfoRow.EnterpriseGanreCode = estimateDetailRow.EnterpriseGanreCode_Prime;         // ���Е��ރR�[�h
                primeInfoRow.EnterpriseGanreName = estimateDetailRow.EnterpriseGanreName_Prime;         // ���Е��ޖ���
                primeInfoRow.WarehouseCode = estimateDetailRow.WarehouseCode_Prime;                     // �q�ɃR�[�h
                primeInfoRow.WarehouseName = estimateDetailRow.WarehouseName_Prime;                     // �q�ɖ���
                primeInfoRow.WarehouseShelfNo = estimateDetailRow.WarehouseShelfNo_Prime;               // �q�ɒI��
                primeInfoRow.SalesOrderDivCd = estimateDetailRow.SalesOrderDivCd_Prime;                 // ����݌Ɏ�񂹋敪
                primeInfoRow.OpenPriceDiv = estimateDetailRow.OpenPriceDiv_Prime;                       // �I�[�v�����i�敪
                primeInfoRow.GoodsRateRank = estimateDetailRow.GoodsRateRank_Prime;                     // ���i�|�������N
                primeInfoRow.CustRateGrpCode = estimateDetailRow.CustRateGrpCode_Prime;                 // ���Ӑ�|���O���[�v�R�[�h
                primeInfoRow.ListPriceRate = estimateDetailRow.ListPriceRate_Prime;                     // �艿��
                primeInfoRow.RateSectPriceUnPrc = estimateDetailRow.RateSectPriceUnPrc_Prime;           // �|���ݒ苒�_�i�艿�j
                primeInfoRow.RateDivLPrice = estimateDetailRow.RateDivLPrice_Prime;                     // �|���ݒ�敪�i�艿�j
                primeInfoRow.UnPrcCalcCdLPrice = estimateDetailRow.UnPrcCalcCdLPrice_Prime;             // �P���Z�o�敪�i�艿�j
                primeInfoRow.PriceCdLPrice = estimateDetailRow.PriceCdLPrice_Prime;                     // ���i�敪�i�艿�j
                primeInfoRow.StdUnPrcLPrice = estimateDetailRow.StdUnPrcLPrice_Prime;                   // ��P���i�艿�j
                primeInfoRow.FracProcUnitLPrice = estimateDetailRow.FracProcUnitLPrice_Prime;           // �[�������P�ʁi�艿�j
                primeInfoRow.FracProcLPrice = estimateDetailRow.FracProcLPrice_Prime;                   // �[�������i�艿�j
                primeInfoRow.ListPriceTaxIncFl = estimateDetailRow.ListPriceTaxIncFl_Prime;             // �艿�i�ō��C�����j
                primeInfoRow.ListPriceTaxExcFl = estimateDetailRow.ListPriceTaxExcFl_Prime;             // �艿�i�Ŕ��C�����j
                primeInfoRow.ListPriceChngCd = estimateDetailRow.ListPriceChngCd_Prime;                 // �艿�ύX�敪
                primeInfoRow.SalesRate = estimateDetailRow.SalesRate_Prime;                             // ������
                primeInfoRow.RateSectSalUnPrc = estimateDetailRow.RateSectSalUnPrc_Prime;               // �|���ݒ苒�_�i����P���j
                primeInfoRow.RateDivSalUnPrc = estimateDetailRow.RateDivSalUnPrc_Prime;                 // �|���ݒ�敪�i����P���j
                primeInfoRow.UnPrcCalcCdSalUnPrc = estimateDetailRow.UnPrcCalcCdSalUnPrc_Prime;         // �P���Z�o�敪�i����P���j
                primeInfoRow.PriceCdSalUnPrc = estimateDetailRow.PriceCdSalUnPrc_Prime;                 // ���i�敪�i����P���j
                primeInfoRow.StdUnPrcSalUnPrc = estimateDetailRow.StdUnPrcSalUnPrc_Prime;               // ��P���i����P���j
                primeInfoRow.FracProcUnitSalUnPrc = estimateDetailRow.FracProcUnitSalUnPrc_Prime;       // �[�������P�ʁi����P���j
                primeInfoRow.FracProcSalUnPrc = estimateDetailRow.FracProcSalUnPrc_Prime;               // �[�������i����P���j
                primeInfoRow.SalesUnPrcTaxIncFl = estimateDetailRow.SalesUnPrcTaxIncFl_Prime;           // ����P���i�ō��C�����j
                primeInfoRow.SalesUnPrcTaxExcFl = estimateDetailRow.SalesUnPrcTaxExcFl_Prime;           // ����P���i�Ŕ��C�����j
                primeInfoRow.SalesUnPrcChngCd = estimateDetailRow.SalesUnPrcChngCd_Prime;               // ����P���ύX�敪
                primeInfoRow.CostRate = estimateDetailRow.CostRate_Prime;                               // ������
                primeInfoRow.RateSectCstUnPrc = estimateDetailRow.RateSectCstUnPrc_Prime;               // �|���ݒ苒�_�i�����P���j
                primeInfoRow.RateDivUnCst = estimateDetailRow.RateDivUnCst_Prime;                       // �|���ݒ�敪�i�����P���j
                primeInfoRow.UnPrcCalcCdUnCst = estimateDetailRow.UnPrcCalcCdUnCst_Prime;               // �P���Z�o�敪�i�����P���j
                primeInfoRow.PriceCdUnCst = estimateDetailRow.PriceCdUnCst_Prime;                       // ���i�敪�i�����P���j
                primeInfoRow.StdUnPrcUnCst = estimateDetailRow.StdUnPrcUnCst_Prime;                     // ��P���i�����P���j
                primeInfoRow.FracProcUnitUnCst = estimateDetailRow.FracProcUnitUnCst_Prime;             // �[�������P�ʁi�����P���j
                primeInfoRow.FracProcUnCst = estimateDetailRow.FracProcUnCst_Prime;                     // �[�������i�����P���j
                primeInfoRow.SalesUnitCost = estimateDetailRow.SalesUnitCost_Prime;                     // �����P��
                primeInfoRow.SalesUnitCostChngDiv = estimateDetailRow.SalesUnitCostChngDiv_Prime;       // �����P���ύX�敪
                primeInfoRow.RateBLGoodsCode = estimateDetailRow.RateBLGoodsCode_Prime;                 // BL���i�R�[�h�i�|���j
                primeInfoRow.RateBLGoodsName = estimateDetailRow.RateBLGoodsName_Prime;                 // BL���i�R�[�h���́i�|���j
                primeInfoRow.RateGoodsRateGrpCd = estimateDetailRow.RateGoodsRateGrpCd_Prime;           // ���i�|���O���[�v�R�[�h�i�|���j
                primeInfoRow.RateGoodsRateGrpNm = estimateDetailRow.RateGoodsRateGrpNm_Prime;           // ���i�|���O���[�v���́i�|���j
                primeInfoRow.RateBLGroupCode = estimateDetailRow.RateBLGroupCode_Prime;                 // BL�O���[�v�R�[�h�i�|���j
                primeInfoRow.RateBLGroupName = estimateDetailRow.RateBLGroupName_Prime;                 // BL�O���[�v���́i�|���j
                primeInfoRow.PrtBLGoodsCode = estimateDetailRow.PrtBLGoodsCode_Prime;                   // BL���i�R�[�h�i����j
                primeInfoRow.PrtBLGoodsName = estimateDetailRow.PrtBLGoodsName_Prime;                   // BL���i�R�[�h���́i����j
                primeInfoRow.SalesCode = estimateDetailRow.SalesCode_Prime;                             // �̔��敪�R�[�h
                primeInfoRow.SalesCdNm = estimateDetailRow.SalesCdNm_Prime;                             // �̔��敪����
                primeInfoRow.WorkManHour = estimateDetailRow.WorkManHour_Prime;                         // ��ƍH��
                primeInfoRow.ShipmentCnt = estimateDetailRow.ShipmentCnt_Prime;                         // �o�א�
                primeInfoRow.AcceptAnOrderCnt = estimateDetailRow.AcceptAnOrderCnt_Prime;               // �󒍐���
                primeInfoRow.AcptAnOdrAdjustCnt = estimateDetailRow.AcptAnOdrAdjustCnt_Prime;           // �󒍒�����
                primeInfoRow.AcptAnOdrRemainCnt = estimateDetailRow.AcptAnOdrRemainCnt_Prime;           // �󒍎c��
                primeInfoRow.RemainCntUpdDate = estimateDetailRow.RemainCntUpdDate_Prime;               // �c���X�V��
                primeInfoRow.SalesMoneyTaxInc = estimateDetailRow.SalesMoneyTaxInc_Prime;               // ������z�i�ō��݁j
                primeInfoRow.SalesMoneyTaxExc = estimateDetailRow.SalesMoneyTaxExc_Prime;               // ������z�i�Ŕ����j
                primeInfoRow.Cost = estimateDetailRow.Cost_Prime;                                       // ����
                primeInfoRow.GrsProfitChkDiv = estimateDetailRow.GrsProfitChkDiv_Prime;                 // �e���`�F�b�N�敪
                primeInfoRow.SalesGoodsCd = estimateDetailRow.SalesGoodsCd_Prime;                       // ���㏤�i�敪
                primeInfoRow.SalesPriceConsTax = estimateDetailRow.SalesPriceConsTax_Prime;             // ������z����Ŋz
                primeInfoRow.TaxationDivCd = estimateDetailRow.TaxationDivCd_Prime;                     // �ېŋ敪
                primeInfoRow.PartySlipNumDtl = estimateDetailRow.PartySlipNumDtl_Prime;                 // �����`�[�ԍ��i���ׁj
                primeInfoRow.DtlNote = estimateDetailRow.DtlNote_Prime;                                 // ���ה��l
                primeInfoRow.SupplierCd = estimateDetailRow.SupplierCd_Prime;                           // �d����R�[�h
                primeInfoRow.SupplierSnm = estimateDetailRow.SupplierSnm_Prime;                         // �d���旪��
                primeInfoRow.OrderNumber = estimateDetailRow.OrderNumber_Prime;                         // �����ԍ�
                primeInfoRow.WayToOrder = estimateDetailRow.WayToOrder_Prime;                           // �������@
                primeInfoRow.SlipMemo1 = estimateDetailRow.SlipMemo1_Prime;                             // �`�[�����P
                primeInfoRow.SlipMemo2 = estimateDetailRow.SlipMemo2_Prime;                             // �`�[�����Q
                primeInfoRow.SlipMemo3 = estimateDetailRow.SlipMemo3_Prime;                             // �`�[�����R
                primeInfoRow.InsideMemo1 = estimateDetailRow.InsideMemo1_Prime;                         // �Г������P
                primeInfoRow.InsideMemo2 = estimateDetailRow.InsideMemo2_Prime;                         // �Г������Q
                primeInfoRow.InsideMemo3 = estimateDetailRow.InsideMemo3_Prime;                         // �Г������R
                primeInfoRow.BfListPrice = estimateDetailRow.BfListPrice_Prime;                         // �ύX�O�艿
                primeInfoRow.BfSalesUnitPrice = estimateDetailRow.BfSalesUnitPrice_Prime;               // �ύX�O����
                primeInfoRow.BfUnitCost = estimateDetailRow.BfUnitCost_Prime;                           // �ύX�O����
                primeInfoRow.CmpltSalesRowNo = estimateDetailRow.CmpltSalesRowNo_Prime;                 // �ꎮ���הԍ�
                primeInfoRow.CmpltGoodsMakerCd = estimateDetailRow.CmpltGoodsMakerCd_Prime;             // ���[�J�[�R�[�h�i�ꎮ�j
                primeInfoRow.CmpltMakerName = estimateDetailRow.CmpltMakerName_Prime;                   // ���[�J�[���́i�ꎮ�j
                primeInfoRow.CmpltMakerKanaName = estimateDetailRow.CmpltMakerKanaName_Prime;           // ���[�J�[�J�i���́i�ꎮ�j
                primeInfoRow.CmpltGoodsName = estimateDetailRow.CmpltGoodsName_Prime;                   // ���i���́i�ꎮ�j
                primeInfoRow.CmpltShipmentCnt = estimateDetailRow.CmpltShipmentCnt_Prime;               // ���ʁi�ꎮ�j
                primeInfoRow.CmpltSalesUnPrcFl = estimateDetailRow.CmpltSalesUnPrcFl_Prime;             // ����P���i�ꎮ�j
                primeInfoRow.CmpltSalesMoney = estimateDetailRow.CmpltSalesMoney_Prime;                 // ������z�i�ꎮ�j
                primeInfoRow.CmpltSalesUnitCost = estimateDetailRow.CmpltSalesUnitCost_Prime;           // �����P���i�ꎮ�j
                primeInfoRow.CmpltCost = estimateDetailRow.CmpltCost_Prime;                             // �������z�i�ꎮ�j
                primeInfoRow.CmpltPartySalSlNum = estimateDetailRow.CmpltPartySalSlNum_Prime;           // �����`�[�ԍ��i�ꎮ�j
                primeInfoRow.CmpltNote = estimateDetailRow.CmpltNote_Prime;                             // �ꎮ���l
                primeInfoRow.PrtGoodsNo = estimateDetailRow.PrtGoodsNo_Prime;                           // ����p�i��
                primeInfoRow.PrtMakerCode = estimateDetailRow.PrtMakerCode_Prime;                       // ����p���[�J�[�R�[�h
                primeInfoRow.PrtMakerName = estimateDetailRow.PrtMakerName_Prime;                       // ����p���[�J�[����

                primeInfoRow.UOEOrderGuid = estimateDetailRow.UOEOrderGuid_Prime;
                primeInfoRow.DtlRelationGuid = estimateDetailRow.DtlRelationGuid_Prime;
                //primeInfoRow.ShipmentPosCnt = estimateDetailRow.ShipmentPosCnt_Prime;  // DEL 2013/02/20 tanh Redmine#34434 No.1180 

                // ADD 2013/02/20 tanh Redmine#34434 No.1180 ---- >>>>>>>>>>>>
                if (string.IsNullOrEmpty(primeInfoRow.WarehouseCode.Trim()))
                {
                    primeInfoRow.ShipmentPosCnt = string.Empty;
                }
                else
                {
                    //primeInfoRow.ShipmentPosCnt = estimateDetailRow.ShipmentPosCnt_Prime.ToString("N");// DEL 杍^ Redmine#34994 2013/03/10
                    primeInfoRow.ShipmentPosCnt = estimateDetailRow.ShipmentPosCnt_Prime;// ADD 杍^ Redmine#34994 2013/03/10
                }
                // ADD 2013/02/20 tanh Redmine#34434 No.1180 ---- <<<<<<<<<<<<

                primeInfoRow.PartsInfoLinkGuid = estimateDetailRow.PartsInfoLinkGuid_Prime;
                primeInfoRow.ExistSetInfo = estimateDetailRow.ExistSetInfo_Prime;
                primeInfoRow.ListPriceDisplay = estimateDetailRow.ListPriceDisplay_Prime;
                // 2009.03.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                primeInfoRow.PrmSetDtlName2 = estimateDetailRow.PrmSetDtlName2_Prime;
                // 2009.03.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
        }

        #endregion

        // ===================================================================================== //
        // ���i����
        // ===================================================================================== //
        #region �����i����

        /// <summary>
        /// ���i�����i�i�Ԍ����j
        /// </summary>
        /// <param name="owner">�I�[�i�[�t�H�[��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="joinSearchDivType">���������^�C�v</param>
        /// <param name="partsInfoDataSet">���i�����f�[�^�Z�b�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="unitPriceCalcRetList">�P���Z�o���ʃ��X�g</param>
        /// <param name="carInfo">���q��������</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2009/11/05 ������</br>
        /// <br>             Redmine#1087�Ή�</br>
        /// </remarks>
        public int SearchPartsFromGoodsNo(IWin32Window owner, string enterpriseCode, string sectionCode, int goodsMakerCode, string goodsNo, GoodsCndtn.JoinSearchDivType joinSearchDivType, out List<GoodsUnitData> goodsUnitDataList, out PartsInfoDataSet partsInfoDataSet, out List<UnitPriceCalcRet> unitPriceCalcRetList, PMKEN01010E carInfo)
        {
            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromGoodsNo", "START");

            //-----------------------------------------------------------------------------
            // ������
            //-----------------------------------------------------------------------------
            string msg;

            unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            //----------ADD 2009/11/05-------->>>>>
            partsInfoDataSet = new PartsInfoDataSet();
            goodsUnitDataList = new List<GoodsUnitData>();
            //----------ADD 2009/11/05--------<<<<<
            //-----------------------------------------------------------------------------
            // ���o�����ݒ�
            //-----------------------------------------------------------------------------
            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = enterpriseCode;
            cndtn.SectionCode = sectionCode;
            cndtn.GoodsMakerCd = goodsMakerCode;
            cndtn.GoodsNo = goodsNo;
            cndtn.JoinSearchDiv = (int)joinSearchDivType;
            cndtn.IsSettingSupplier = 1;
            //----------ADD 2009/11/05-------->>>>>
            cndtn.SearchCarInfo = carInfo;
            //----------ADD 2009/11/05--------<<<<<

            this.SetCommonSerachCndtn(ref cndtn);

            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromGoodsNo", "���i���� START");
            //-----------------------------------------------------------------------------
            // ���i����
            //-----------------------------------------------------------------------------
            int status = this._estimateInputInitDataAcs.SearchParts(owner, cndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);
            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromGoodsNo", "���i���� END");

            // �������ʂ��[���̏ꍇ�͋����I�ɊY���f�[�^����
            if (( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL ) && ( ( goodsUnitDataList == null ) || ( goodsUnitDataList.Count == 0 ) ))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            switch ((ConstantManagement.MethodResult)status)
            {
                case ConstantManagement.MethodResult.ctFNC_CANCEL: // �I�𖳂�
                    break;
                case ConstantManagement.MethodResult.ctFNC_NORMAL: // �ʏ폈��
                    //CalculateUnitPriceForSearch
                    //CalcPriceForSearch

                    //EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromGoodsNo", "���i�A���f�[�^�s�����ݒ�@ START");
                    //this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList);
                    //EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromGoodsNo", "���i�A���f�[�^�s�����ݒ�@ END");

                    ////-----------------------------------------------------------------------------
                    //// �P�����擾
                    ////-----------------------------------------------------------------------------
                    //EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromGoodsNo", "�P���Z�o START");
                    //unitPriceCalcRetList = this.CalculateSalesRelevanceUnitPrice(goodsUnitDataList);
                    //EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromGoodsNo", "�P���Z�o START");

                    ////-----------------------------------------------------------------------------
                    //// �P�����𕔕i�����f�[�^�Z�b�g�֔��f
                    ////-----------------------------------------------------------------------------
                    //EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromGoodsNo", "�P�����𕔕i�����f�[�^�Z�b�g�֔��f START");
                    //if (( unitPriceCalcRetList != null ) && ( unitPriceCalcRetList.Count != 0 )) partsInfoDataSet.SetUnitPriceInfo(unitPriceCalcRetList);
                    //EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromGoodsNo", "�P�����𕔕i�����f�[�^�Z�b�g�֔��f END");

                    // �P���Z�o�f���Q�[�g�ǉ�
                    if (partsInfoDataSet.CalculateGoodsPrice == null)
                    {
                        partsInfoDataSet.CalculateGoodsPrice += new PartsInfoDataSet.CalculateGoodsPriceCallback(this.CalculateUnitPriceForSearch);
                    }
                    // ���i�v�Z�f���Q�[�g�ǉ�
                    if (partsInfoDataSet.CalculatePrice == null)
                    {
                        partsInfoDataSet.CalculatePrice += new PartsInfoDataSet.CalculatePriceCallback(CalcPriceForSearch);
                    }

                    // �D��q�ɂ̃Z�b�g
                    partsInfoDataSet.ListPriorWarehouse = this.GetSearchWarehouseList();
                    // TODO:�i���\���敪�̃Z�b�g
                    // DEL 2010/05/17 �i���\���Ή� ---------->>>>>
                    //partsInfoDataSet.PartsNameDspDivCd = this._estimateInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd;
                    // DEL 2010/05/17 �i���\���Ή� ----------<<<<<
                    // ADD 2010/05/17 �i���\���Ή� ---------->>>>>
                    partsInfoDataSet.SetPartsNameDisplayPattern(this._estimateInputInitDataAcs.GetSalesTtlSt());

                    // BL���i���
                    if (partsInfoDataSet.GetBLGoodsInfo == null)
                    {
                        partsInfoDataSet.GetBLGoodsInfo += new PartsInfoDataSet.GetBLGoodsInfoCallBack(this.GetBLGoodsInfo);
                    }
                    // ADD 2010/05/17 �i���\���Ή� ----------<<<<<

                    // ���i�K�p���̃Z�b�g
                    partsInfoDataSet.PriceApplyDate = this._salesSlip.SalesDate;

                    // 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // �������ݒ莞�敪
                    partsInfoDataSet.UnPrcNonSettingDiv = this._estimateInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv;
                    // 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // �ԗ����␳
                    #region �ԗ����␳
                    // --- ADD 杍^ 2014/09/01 ---------->>>>>
                    this.SetCarInfoToThread(cndtn);
                    // --- ADD 杍^ 2014/09/01 ----------<<<<<
                    #endregion

                    //-----------------------------------------------------------------------------
                    // ���i�I�𐧌�N��
                    //-----------------------------------------------------------------------------
                    //UIDisplayControl.CalcUnitPriceEvent += new UIDisplayControl.CalcUnitPriceEventHandler(this.CalculateUnitPrice);
                    EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromGoodsNo", "���i�I�𐧌�UI START");
                    DialogResult retDialog = UIDisplayControl.SearchEstimatePNo(owner, partsInfoDataSet, 0);
                    EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromGoodsNo", "���i�I�𐧌�UI END");

                    switch (retDialog)
                    {
                        case DialogResult.Abort:
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                        case DialogResult.Cancel:
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                        case DialogResult.Ignore:
                            break;
                        case DialogResult.No:
                            break;
                        case DialogResult.None:
                            break;
                        case DialogResult.OK:
                        case DialogResult.Yes:
                            //-----------------------------------------------------------------------------
                            // ���i�����f�[�^�Z�b�g����I�����̏��i�A���f�[�^�I�u�W�F�N�g���擾
                            //-----------------------------------------------------------------------------
                            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromGoodsNo", "���i���X�g�擾 START");
                            goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(true, this._estimateInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd).ToArray(typeof(GoodsUnitData)));
                            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromGoodsNo", "���i���X�g�擾 END");

                            this.CalculateUnitPriceForSearch(goodsUnitDataList, out unitPriceCalcRetList);

                            //-----------------------------------------------------------------------------
                            // ���i�A���f�[�^�s�����ݒ�
                            //-----------------------------------------------------------------------------
                            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromGoodsNo", "���i�A���f�[�^�s�����ݒ� START");
                            this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true);
                            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromGoodsNo", "���i�A���f�[�^�s�����ݒ� END");

                            //-----------------------------------------------------------------------------
                            // �P�����擾
                            //-----------------------------------------------------------------------------
                            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromGoodsNo", "�P���Z�o START");
                            unitPriceCalcRetList = this.CalculateSalesRelevanceUnitPrice(goodsUnitDataList);
                            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromGoodsNo", "�P���Z�o END");

                            break;
                        case DialogResult.Retry:
                            break;
                    }


                    break;
                case ConstantManagement.MethodResult.ctFNC_NO_RETURN: // �Y���f�[�^����
                    break;
            }

            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromGoodsNo", "END");
            return status;
        }

        ///// <summary>
        ///// �P���Z�o�����i���i�I��UI�̃f���Q�[�g�Ɏg�p)
        ///// </summary>
        ///// <param name="list">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        //private void CalculateUnitPrice(ref PartsInfoDataSet partsInfoDataSet, List<PartsInfoDataSet.GoodsPrimaryKey> goodsPrimaryKeyList)
        //{
        //    if (goodsPrimaryKeyList == null) return;

        //    List<GoodsUnitData> goodsUnitDataList = partsInfoDataSet.GetGoodsList(goodsPrimaryKeyList);
        //    List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
        //    this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList);

        //    //-----------------------------------------------------------------------------
        //    // �P�����擾
        //    //-----------------------------------------------------------------------------
        //    unitPriceCalcRetList = this.CalculateSalesRelevanceUnitPrice(goodsUnitDataList);

        //    // �f�[�^�Z�b�g�ɉ��i���f
        //    if (( unitPriceCalcRetList != null ) && ( unitPriceCalcRetList.Count != 0 )) partsInfoDataSet.SetUnitPriceInfo(unitPriceCalcRetList);
        //}

        /// <summary>
        /// BL�R�[�h����
        /// </summary>
        /// <param name="owner">�I�[�i�[�t�H�[��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <param name="searchCarInfo">�������q</param>
        /// <param name="partsSelectFlg">���i�I��L���t���O</param>
        /// <param name="goodsUnitDataList">���i���I�u�W�F�N�g���X�g</param>
        /// <param name="partsInfoDataSet">�������i�f�[�^�Z�b�g</param>
        /// <param name="unitPriceCalcRetList"></param>
        /// <returns>ConstantManagement.MethodResult(-3:���q��񖳂�)</returns>
        public int SearchPartsFromBLCode(IWin32Window owner, string enterpriseCode, string sectionCode, int blGoodsCode, PMKEN01010E searchCarInfo, int partsSelectFlg, out List<GoodsUnitData> goodsUnitDataList, out PartsInfoDataSet partsInfoDataSet, out List<UnitPriceCalcRet> unitPriceCalcRetList )
        {
            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromBLCode", "�J�n");

            //-----------------------------------------------------------------------------
            // ������
            //-----------------------------------------------------------------------------
            string msg;
            goodsUnitDataList= new List<GoodsUnitData>();
            partsInfoDataSet = new PartsInfoDataSet();
            unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            if (searchCarInfo == null)
            {
                return -3;
            }

            unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            //-----------------------------------------------------------------------------
            // ���o�����ݒ�
            //-----------------------------------------------------------------------------
            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = enterpriseCode;
            cndtn.SectionCode = sectionCode;
            cndtn.BLGoodsCode = blGoodsCode;
            cndtn.SearchCarInfo = searchCarInfo;
            cndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.Search;
            cndtn.IsSettingSupplier = 1;
            cndtn.SearchCarInfo = searchCarInfo;

            this.SetCommonSerachCndtn(ref cndtn);

            // --- ADD 2013/03/08 Y.Wakita ---------->>>>>
            if (cndtn.SearchCarInfo.CarModelUIData[0].ProduceTypeOfYearInput > 0)
            {
                if ((cndtn.SearchCarInfo.CarModelUIData[0].ProduceTypeOfYearInput % 100) == 0)
                {
                    cndtn.SearchCarInfo.CarModelUIData[0].ProduceTypeOfYearInput = 0;
                }
            }
            // --- ADD 2013/03/08 Y.Wakita ----------<<<<<

            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromBLCode", "���i���� START"); 
            //-----------------------------------------------------------------------------
            // ���i����
            //-----------------------------------------------------------------------------
            int status = this._estimateInputInitDataAcs.BLPartsSearch(owner, cndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);

            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromBLCode", "���i���� END");

            // �������ʂ��[���̏ꍇ�͋����I�ɊY���f�[�^����
            if (( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL ) && ( ( goodsUnitDataList == null ) || ( goodsUnitDataList.Count == 0 ) ))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            switch ((ConstantManagement.MethodResult)status)
            {
                case ConstantManagement.MethodResult.ctFNC_CANCEL: // �I�𖳂�
                    break;
                case ConstantManagement.MethodResult.ctFNC_NORMAL: // �ʏ폈��

                    //EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromBLCode", "���i�A���f�[�^�s�����ݒ�@ START");
                    //this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList);
                    //EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromBLCode", "���i�A���f�[�^�s�����ݒ�@ END");

                    ////-----------------------------------------------------------------------------
                    //// �P�����擾
                    ////-----------------------------------------------------------------------------
                    //EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromBLCode", "�P���Z�o START");
                    //unitPriceCalcRetList = this.CalculateSalesRelevanceUnitPrice(goodsUnitDataList);
                    //EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromBLCode", "�P���Z�o END");


                    ////-----------------------------------------------------------------------------
                    //// �P�����𕔕i�����f�[�^�Z�b�g�֔��f
                    ////-----------------------------------------------------------------------------
                    //EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromBLCode", "�P�����𕔕i�����f�[�^�Z�b�g�֔��f START");
                    //if (( unitPriceCalcRetList != null ) && ( unitPriceCalcRetList.Count != 0 )) partsInfoDataSet.SetUnitPriceInfo(unitPriceCalcRetList);
                    //EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromBLCode", "�P�����𕔕i�����f�[�^�Z�b�g�֔��f END");

                    // �P���Z�o�f���Q�[�g�ǉ�
                    if (partsInfoDataSet.CalculateGoodsPrice == null)
                    {
                        partsInfoDataSet.CalculateGoodsPrice += new PartsInfoDataSet.CalculateGoodsPriceCallback(this.CalculateUnitPriceForSearch);
                    }
                    // ���i�v�Z�f���Q�[�g�ǉ�
                    if (partsInfoDataSet.CalculatePrice == null)
                    {
                        partsInfoDataSet.CalculatePrice += new PartsInfoDataSet.CalculatePriceCallback(CalcPriceForSearch);
                    }


                    // �D��q�ɂ̃Z�b�g
                    partsInfoDataSet.ListPriorWarehouse = this.GetSearchWarehouseList();
                    // TODO:�i���\���敪�̃Z�b�g
                    // DEL 2010/05/17 �i���\���Ή� ---------->>>>>
                    //partsInfoDataSet.PartsNameDspDivCd = this._estimateInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd;
                    // DEL 2010/05/17 �i���\���Ή� ----------<<<<<
                    // ADD 2010/05/17 �i���\���Ή� ---------->>>>>
                    partsInfoDataSet.SetPartsNameDisplayPattern(this._estimateInputInitDataAcs.GetSalesTtlSt());

                    // BL���i���
                    if (partsInfoDataSet.GetBLGoodsInfo == null)
                    {
                        partsInfoDataSet.GetBLGoodsInfo += new PartsInfoDataSet.GetBLGoodsInfoCallBack(this.GetBLGoodsInfo);
                    }
                    // ADD 2010/05/17 �i���\���Ή� ----------<<<<<
                    // ���i�K�p���̃Z�b�g
                    partsInfoDataSet.PriceApplyDate = this._salesSlip.SalesDate;

                    // 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // �������ݒ莞�敪
                    partsInfoDataSet.UnPrcNonSettingDiv = this._estimateInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv;
                    // 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // �ԗ����␳
                    #region �ԗ����␳
                    // --- ADD 杍^ 2014/09/01 ---------->>>>>
                    this.SetCarInfoToThread(cndtn);
                    // --- ADD 杍^ 2014/09/01 ----------<<<<<
                    #endregion

                    //-----------------------------------------------------------------------------
                    // ���i�I�𐧌�N��
                    //-----------------------------------------------------------------------------
                    EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromBLCode", "���i�I�𐧌�UI START");
                    DialogResult retDialog = UIDisplayControl.SearchEstimateBL(owner, searchCarInfo, partsInfoDataSet, partsSelectFlg);
                    EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromBLCode", "���i�I�𐧌�UI END");

                    switch (retDialog)
                    {
                        case DialogResult.Abort:
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                        case DialogResult.Cancel:
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                        case DialogResult.Ignore:
                            break;
                        case DialogResult.No:
                            break;
                        case DialogResult.None:
                            break;case DialogResult.OK:
                        case DialogResult.Yes:

                            //List<g> genuinePartsRetWorkList = partsInfoDataSet.GetSelectedGenuineParts();

                            //-----------------------------------------------------------------------------
                            // ���i�����f�[�^�Z�b�g����I�����̏��i�A���f�[�^�I�u�W�F�N�g���擾
                            //-----------------------------------------------------------------------------
                            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromBLCode", "���i���X�g�擾 START");
                            goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(true, this._estimateInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd).ToArray(typeof(GoodsUnitData)));
                            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromBLCode", "���i���X�g�擾 END");

                            //-----------------------------------------------------------------------------
                            // ���i�A���f�[�^�s�����ݒ�
                            //-----------------------------------------------------------------------------
                            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromBLCode", "���i�A���f�[�^�s�����ݒ� START");
                            this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true);
                            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromBLCode", "���i�A���f�[�^�s�����ݒ� END");

                            //-----------------------------------------------------------------------------
                            // �P�����擾
                            //-----------------------------------------------------------------------------
                            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromBLCode", "�P���Z�o START");
                            unitPriceCalcRetList = this.CalculateSalesRelevanceUnitPrice(goodsUnitDataList);
                            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromBLCode", "�P���Z�o END");

                            break;
                        case DialogResult.Retry:
                            break;
                    }


                    break;
                case ConstantManagement.MethodResult.ctFNC_NO_RETURN: // �Y���f�[�^����

                    break;
            }

            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "SearchPartsFromBLCode", "�I��"); 

            return status;
        }

        /// <summary>
        /// TBO����
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="carInfo">�������q</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^���X�g</param>
        /// <param name="partsInfoDataSet">�������i�f�[�^�Z�b�g</param>
        /// <param name="unitPriceCalcRetList">�|���Z�o���ʃ��X�g</param>
        /// <returns></returns>
        public int SearchTBO(IWin32Window owner, string enterpriseCode, string sectionCode, PMKEN01010E carInfo,out List<GoodsUnitData> goodsUnitDataList,out PartsInfoDataSet partsInfoDataSet,out List<UnitPriceCalcRet> unitPriceCalcRetList )
        {
            if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();

            //-----------------------------------------------------------------------------
            // ������
            //-----------------------------------------------------------------------------
            string msg;
            unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            //-----------------------------------------------------------------------------
            // ���o�����ݒ�
            //-----------------------------------------------------------------------------
            GoodsCndtn cndtn = new GoodsCndtn();
            this.SetCommonSerachCndtn(ref cndtn); // 2009/09/08 ADD
            cndtn.EnterpriseCode = enterpriseCode;
            cndtn.SectionCode = sectionCode;
            cndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
            cndtn.ListPriorWarehouse = this.GetSearchWarehouseList();

            cndtn.CustomerCode = this._salesSlip.CustomerCode;
            cndtn.CustRateGrpCode = this._salesSlip.CustRateGrpCode;
            cndtn.PriceApplyDate = this._salesSlip.SalesDate;                           
            cndtn.SalesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
            cndtn.TaxRate = this._salesSlip.ConsTaxRate;
            cndtn.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd;
            cndtn.TtlAmntDspRateDivCd = this._estimateInputInitDataAcs.GetAllDefSet().TtlAmntDspRateDivCd;
            cndtn.SalesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            cndtn.IsSettingSupplier = 1;

            cndtn.SearchCarInfo = carInfo;

            //-----------------------------------------------------------------------------
            // TBO����
            //-----------------------------------------------------------------------------
            int status = this._estimateInputInitDataAcs.SearchTBO(owner, cndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);

            // �������ʂ��[���̏ꍇ�͋����I�ɊY���f�[�^����
            if (( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL ) && ( ( goodsUnitDataList == null ) || ( goodsUnitDataList.Count == 0 ) ))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            switch ((ConstantManagement.MethodResult)status)
            {
                case ConstantManagement.MethodResult.ctFNC_CANCEL: // �I�𖳂�
                    break;
                case ConstantManagement.MethodResult.ctFNC_NORMAL: // �ʏ폈��

                    ////-------------------------------------------------------------------------
                    //// ���i�A���f�[�^�s�����ݒ�
                    ////-------------------------------------------------------------------------
                    this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true);

                    //-----------------------------------------------------------------------------
                    // �P�����擾
                    //-----------------------------------------------------------------------------
                    unitPriceCalcRetList = this.CalculateSalesRelevanceUnitPrice(goodsUnitDataList);

                    //-----------------------------------------------------------------------------
                    // �P�����𕔕i�����f�[�^�Z�b�g�֔��f
                    //-----------------------------------------------------------------------------
                    if (( unitPriceCalcRetList != null ) && ( unitPriceCalcRetList.Count != 0 )) partsInfoDataSet.SetUnitPriceInfo(unitPriceCalcRetList);

                    ////-----------------------------------------------------------------------------
                    //// ���i�����f�[�^�Z�b�g����I�����̏��i�A���f�[�^�I�u�W�F�N�g���擾
                    ////-----------------------------------------------------------------------------
                    //goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(true).ToArray(typeof(GoodsUnitData)));

                    break;
                case ConstantManagement.MethodResult.ctFNC_NO_RETURN: // �Y���f�[�^����
                    break;
            }
            return status;
        }

        //----------DEL 2009/11/05--------->>>>>
        ///// <summary>
        ///// �W�����i�擾
        ///// </summary>
        ///// <param name="partsInfoDataSet">���i�������ʃf�[�^�Z�b�g(������)</param>
        ///// <remarks>
        ///// <br>Note       : �W�����i���擾����</br>
        ///// <br>Programmer : ������</br>
        ///// <br>Date       : 2009/10/22�A</br>
        ///// <br>Update Note: 2009/11/05 ������</br>
        ///// <br>             Redmine#1087�A#1134�Ή�</br>
        ///// </remarks>
        //public void CalculateUnitPriceForSearchProc( ref PartsInfoDataSet partsInfoDataSet)
        //{
        //    //----------UPD 2009/11/05--------->>>>>
        //    // ���i�K�p���̃Z�b�g
        //    partsInfoDataSet.PriceApplyDate = this._salesSlip.SalesDate;
        //    // ���i�v�Z�f���Q�[�g�ǉ�
        //    if (partsInfoDataSet.CalculatePrice == null)
        //    {
        //        partsInfoDataSet.CalculatePrice += new PartsInfoDataSet.CalculatePriceCallback(CalcPriceForSearch);
        //    }
        //    List<PartsInfoDataSet.GoodsPrimaryKey> goodsPrimaryKeyList = new List<PartsInfoDataSet.GoodsPrimaryKey>();
        //    for (int i = 0; i < partsInfoDataSet.UsrGoodsInfo.Count; i++)
        //    {
        //        goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(partsInfoDataSet.UsrGoodsInfo[i].GoodsNo, partsInfoDataSet.UsrGoodsInfo[i].GoodsMakerCd));
        //    partsInfoDataSet.SettingDefaultListPrice(goodsPrimaryKeyList);
        //    }
        //    //----------UPD 2009/11/05---------<<<<<

        //}
        //----------DEL 2009/11/05---------<<<<<

        /// <summary>
        /// �����p�̒P���Z�o
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        /// <param name="unitPriceCalcRetList"></param>
        private void CalculateUnitPriceForSearch(List<GoodsUnitData> goodsUnitDataList, out List<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "CalculateUnitPriceForSearch", "���i�A���f�[�^�s�����ݒ� START");
            this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, false);
            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "CalculateUnitPriceForSearch", "���i�A���f�[�^�s�����ݒ� END");

            //-----------------------------------------------------------------------------
            // �P�����擾
            //-----------------------------------------------------------------------------
            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "CalculateUnitPriceForSearch", "�P���Z�o START");
            unitPriceCalcRetList = this.CalculateSalesRelevanceUnitPrice(goodsUnitDataList);
            EstimateInputInitDataAcs.LogWrite("�|EstimateInputAcs", "CalculateUnitPriceForSearch", "�P���Z�o END");
        }

        /// <summary>
        /// �����p�̉��i�v�Z
        /// </summary>
        /// <param name="taxationCode"></param>
        /// <param name="unitPrice"></param>
        /// <param name="priceTaxExc"></param>
        /// <param name="priceTaxInc"></param>
        private void CalcPriceForSearch(int taxationCode, double unitPrice, out double priceTaxExc, out double priceTaxInc)
        {
            if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();

            priceTaxExc = unitPrice;
            priceTaxInc = unitPrice;
            // ����Œ[�������R�[�h
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);

            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._estimateInputInitDataAcs.GetSalesFractionProcInfo(EstimateInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);


            // �ېŋ敪�u��ېŁv�A�]�ŕ����F��ې�
            if (( taxationCode == (int)CalculateTax.TaxationCode.TaxNone ))
            {
                priceTaxExc = unitPrice;
                priceTaxInc = unitPrice;
            }
            // �ېŋ敪���u�ېŁi���Łj�v�̏ꍇ
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                priceTaxExc = unitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, unitPrice);
                //priceTaxInc = ( this._salesSlip.ConsTaxLayMethod == 9 ) ? unitPrice : priceTaxExc;
                priceTaxInc = unitPrice;
            }
            // �ېŋ敪���u�ېŁv�̏ꍇ
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                priceTaxExc = unitPrice;
                //priceTaxInc = ( this._salesSlip.ConsTaxLayMethod == 9 ) ? targetPrice : unitPrice + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, unitPrice);
                priceTaxInc = unitPrice + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, unitPrice);
            }
        }

        /// <summary>
        /// �i�Ԍ���(���i���ꊇ�擾)
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesDetailList">���㖾�׃f�[�^���X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^���X�g</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns></returns>
        public int SearchPartsFromGoodsNoNonVariousSearchWholeWord( SalesSlip salesSlip, List<SalesDetail> salesDetailList, out List<GoodsUnitData> goodsUnitDataList, out String msg )
        {
            //-----------------------------------------------------------------------------
            // ��������
            //-----------------------------------------------------------------------------
            List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();

            //-----------------------------------------------------------------------------
            // ���i���������I�u�W�F�N�g���X�g�擾
            //-----------------------------------------------------------------------------
            this.GetGoodsCndtnList(salesSlip, salesDetailList, out goodsCndtnList);

            return this.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataList, out msg); ;
        }

        /// <summary>
        /// �i�Ԍ���(���i���ꊇ�擾)
        /// </summary>
        /// <param name="goodsCndtnList">���i�����������X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^���X�g</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns></returns>
        public int SearchPartsFromGoodsNoNonVariousSearchWholeWord(List<GoodsCndtn> goodsCndtnList, out List<GoodsUnitData> goodsUnitDataList, out String msg)
        {
            //-----------------------------------------------------------------------------
            // ��������
            //-----------------------------------------------------------------------------
            goodsUnitDataList = new List<GoodsUnitData>();
            List<List<GoodsUnitData>> goodsUnitDataListList = new List<List<GoodsUnitData>>();

            //-----------------------------------------------------------------------------
            // �i�Ԍ���(���i���ꊇ�擾)
            //-----------------------------------------------------------------------------
            int status = this._estimateInputInitDataAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out msg);

            switch ((ConstantManagement.MethodResult)status)
            {
                case ConstantManagement.MethodResult.ctFNC_NORMAL: // �ʏ폈��

                    foreach (List<GoodsUnitData> goodsUnitDataListWk in goodsUnitDataListList)
                    {
                        if (( goodsUnitDataListWk != null ) && ( goodsUnitDataListWk.Count > 0 ))
                        {
                            goodsUnitDataList.Add(goodsUnitDataListWk[0]);
                        }
                    }
                    break;
                default:
                    break;
            }

            return status;
        }

        /// <summary>
        /// �������i�f�[�^�Z�b�g���A�I���������i�̏����擾���܂��B
        /// </summary>
        /// <param name="partsInfoDataSet">�������i�f�[�^�Z�b�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="unitPriceCalcRetList">�P���Z�o���ʃ��X�g</param>
        public void GetSelectedDataFromPartsInfoSet( PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out List<UnitPriceCalcRet> unitPriceCalcRetList )
        {
            //-----------------------------------------------------------------------------
            // ���i�����f�[�^�Z�b�g����I�����̏��i�A���f�[�^�I�u�W�F�N�g���擾
            //-----------------------------------------------------------------------------
            goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(true, this._estimateInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd).ToArray(typeof(GoodsUnitData)));

            //-------------------------------------------------------------------------
            // ���i�A���f�[�^�s�����ݒ�
            //-------------------------------------------------------------------------
            this._estimateInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true);

            //-----------------------------------------------------------------------------
            // �P�����擾
            //-----------------------------------------------------------------------------
            unitPriceCalcRetList = this.CalculateSalesRelevanceUnitPrice(goodsUnitDataList);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="goodsCndtnList">���i�����������X�g</param>
        /// <param name="goodsInfoDictionary"></param>
        /// <returns></returns>
        public int JoinPartsSearch(List<GoodsCndtn> goodsCndtnList, out Dictionary<GoodsUnitData, PartsInfoDataSet> goodsInfoDictionary)
        {
            goodsInfoDictionary = null;

            List<PartsInfoDataSet> partsInfoDataSetListWk;

            List<List<GoodsUnitData>> goodsUnitDataListList;
            string msg;
            int status = this._estimateInputInitDataAcs.SearchPartsFromGoodsNoWholeWord(goodsCndtnList, out partsInfoDataSetListWk, out goodsUnitDataListList, out msg);

            switch ((ConstantManagement.MethodResult)status)
            {
                case ConstantManagement.MethodResult.ctFNC_NORMAL: // �ʏ폈��

                    if (( goodsUnitDataListList != null ) && ( goodsUnitDataListList.Count > 0 ))
                    {
                        goodsInfoDictionary = new Dictionary<GoodsUnitData, PartsInfoDataSet>();
                        foreach (GoodsCndtn goodsCndtn in goodsCndtnList)
                        {
                            for (int i = 0; i < goodsUnitDataListList.Count; i++)
                            {
                                // ���������ƈ�v���A�f�[�^�Z�b�g������f�[�^�̂ݎ擾����
                                if (( goodsCndtn.GoodsNo == goodsUnitDataListList[i][0].GoodsNo ) &&
                                    ( goodsCndtn.GoodsMakerCd == goodsUnitDataListList[i][0].GoodsMakerCd ))
                                {
                                    if (i < partsInfoDataSetListWk.Count)
                                    {
                                        goodsInfoDictionary.Add(goodsUnitDataListList[i][0], partsInfoDataSetListWk[i]);
                                    }
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

            return status;
        }

        /// <summary>
        /// ���i���������I�u�W�F�N�g���X�g�擾����
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesDetailList">���㖾�׃f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="goodsCndtnList">���i���������I�u�W�F�N�g���X�g</param>
        private void GetGoodsCndtnList(SalesSlip salesSlip, List<SalesDetail> salesDetailList, out List<GoodsCndtn> goodsCndtnList)
        {
            goodsCndtnList = new List<GoodsCndtn>();
            List<GoodsCndtn> retGoodsCndtnList = new List<GoodsCndtn>();

            foreach (SalesDetail salesDetail in salesDetailList)
            {
                if (( salesDetail.GoodsMakerCd == 0 ) || ( string.IsNullOrEmpty(salesDetail.GoodsNo) )) continue;

                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = this._enterpriseCode;
                goodsCndtn.SectionCode = salesSlip.ResultsAddUpSecCd;
                goodsCndtn.GoodsMakerCd = salesDetail.GoodsMakerCd;
                goodsCndtn.GoodsNo = salesDetail.GoodsNo;
                goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
                goodsCndtn.IsSettingSupplier = 1;
                goodsCndtn.ListPriorWarehouse = this.GetSearchWarehouseList();

                retGoodsCndtnList.Add(goodsCndtn);
            }

            goodsCndtnList = retGoodsCndtnList;
        }

        /// <summary>
        /// ���i���������I�u�W�F�N�g���X�g�擾����
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        /// <param name="estimateDetailRows">�������ϖ��׍s���X�g</param>
        /// <param name="joinSearchDivType">���������^�C�v</param>
        /// <param name="goodsCndtnList">���i���������I�u�W�F�N�g���X�g</param>
        public void GetGoodsCndtnList(SalesSlip salesSlip, EstimateInputDataSet.EstimateDetailRow[] estimateDetailRows, GoodsCndtn.JoinSearchDivType joinSearchDivType, out List<GoodsCndtn> goodsCndtnList)
        {
            goodsCndtnList = new List<GoodsCndtn>();
            List<GoodsCndtn> retGoodsCndtnList = new List<GoodsCndtn>();

            List<GoodsInfoKey> goodsInfoKeyList = new List<GoodsInfoKey>();
            foreach (EstimateInputDataSet.EstimateDetailRow row in estimateDetailRows)
            {
                if (( row.GoodsMakerCd == 0 ) || ( string.IsNullOrEmpty(row.GoodsNo) )) continue;

                if (goodsInfoKeyList.Contains(new GoodsInfoKey(row.GoodsNo, row.GoodsMakerCd))) continue;

                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = this._enterpriseCode;
                goodsCndtn.SectionCode = salesSlip.ResultsAddUpSecCd;
                goodsCndtn.GoodsMakerCd = row.GoodsMakerCd;
                goodsCndtn.GoodsNo = row.GoodsNo;
                goodsCndtn.JoinSearchDiv = (int)joinSearchDivType;
                goodsCndtn.IsSettingSupplier = 1;                   // �d�����Read���Ȃ�

                retGoodsCndtnList.Add(goodsCndtn);
                goodsInfoKeyList.Add(new GoodsInfoKey(row.GoodsNo, row.GoodsMakerCd));
            }

            goodsCndtnList = retGoodsCndtnList;
        }

        /// <summary>
        /// ��������̋��ʏ���ݒ肵�܂��B
        /// </summary>
        /// <param name="goodsCndtn">���i��������</param>
        private void SetCommonSerachCndtn(ref GoodsCndtn goodsCndtn)
        {
            if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();

            goodsCndtn.SubstCondDivCd = this._estimateInputInitDataAcs.GetSalesTtlSt().SubstCondDivCd;
            goodsCndtn.PrmSubstCondDivCd = this._estimateInputInitDataAcs.GetSalesTtlSt().PrmSubstCondDivCd;
            goodsCndtn.SubstApplyDivCd = this._estimateInputInitDataAcs.GetSalesTtlSt().SubstApplyDivCd;
            goodsCndtn.PartsSearchPriDivCd = this._estimateInputInitDataAcs.GetSalesTtlSt().PartsSearchPriDivCd;
            goodsCndtn.JoinInitDispDiv = this._estimateInputInitDataAcs.GetSalesTtlSt().JoinInitDispDiv;
            goodsCndtn.EraNameDispCd1 = this._estimateInputInitDataAcs.GetAllDefSet().EraNameDispCd1;
            goodsCndtn.ListPriorWarehouse = this.GetSearchWarehouseList();
            goodsCndtn.SearchUICntDivCd = 1;

            goodsCndtn.CustomerCode = this._salesSlip.CustomerCode;
            goodsCndtn.CustRateGrpCode = this._salesSlip.CustRateGrpCode;
            goodsCndtn.PriceApplyDate = this._salesSlip.SalesDate;
            goodsCndtn.SalesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
            goodsCndtn.TaxRate = this._salesSlip.ConsTaxRate;
            goodsCndtn.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd;
            goodsCndtn.TtlAmntDspRateDivCd = this._estimateInputInitDataAcs.GetAllDefSet().TtlAmntDspRateDivCd;
            goodsCndtn.SalesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
        }


        /// <summary>
        /// �����p�q�ɃR�[�h���X�g���擾���܂��B
        /// </summary>
        /// <returns>�q�ɃR�[�h���X�g</returns>
        public List<string> GetSearchWarehouseList()
        {
            List<string> warehouseList = new List<string>();
            SecInfoSet secInfoSet = this._estimateInputInitDataAcs.GetSecInfo(this._salesSlip.ResultsAddUpSecCd);

            if (secInfoSet != null)
            {
                if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd1.Trim())) warehouseList.Add(secInfoSet.SectWarehouseCd1.Trim());
                if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd2.Trim())) warehouseList.Add(secInfoSet.SectWarehouseCd2.Trim());
                if (!string.IsNullOrEmpty(secInfoSet.SectWarehouseCd3.Trim())) warehouseList.Add(secInfoSet.SectWarehouseCd3.Trim());
            }

            return warehouseList;
        }

        #endregion

        // ===================================================================================== //
        // ����֘A
        // ===================================================================================== //
        #region ������֘A

        /// <summary>
        /// ����p�f�[�^���擾���܂��B
        /// </summary>
        /// <param name="allPrintCount">�������(�S�āj</param>
        /// <param name="purePartsPrintCount">�������(�����̂݁j</param>
        /// <param name="primePartsPrintCount">�������(�D�ǂ̂݁j</param>
        /// <param name="selectedPartsPrintCount">�������(�I�𕪂̂݁j</param>
        /// <returns>����f�[�^</returns>
        public EstFmPrintCndtn GetPrintData(int allPrintCount, int purePartsPrintCount, int primePartsPrintCount, int selectedPartsPrintCount)
        {
            // ����f�[�^�̎擾
            EstFmPrintCndtn.EstFmUnitData allPrintData = null;
            EstFmPrintCndtn.EstFmUnitData purePartsPrintData = null;
            EstFmPrintCndtn.EstFmUnitData primePartsPrintData = null;
            EstFmPrintCndtn.EstFmUnitData selectedPartsPrintData = null;

            List<EstFmPrintCndtn.EstFmUnitData> estFmUnitDataList = new List<EstFmPrintCndtn.EstFmUnitData>();

            if (allPrintCount > 0)
            {
                allPrintData = this.GetPrintData(DataGetMode.All, allPrintCount);
            }
            if (purePartsPrintCount > 0)
            {
                purePartsPrintData = this.GetPrintData(DataGetMode.PurePartsOnly, purePartsPrintCount); 
            }
            if (primePartsPrintCount > 0)
            {
                primePartsPrintData = this.GetPrintData(DataGetMode.PrimePartsOnly, primePartsPrintCount);
            }
            if (selectedPartsPrintCount > 0)
            {
                selectedPartsPrintData = this.GetPrintData(DataGetMode.SelectedPartsOnly, selectedPartsPrintCount);
            }

            if (allPrintData != null) estFmUnitDataList.Add(allPrintData);
            if (purePartsPrintData != null) estFmUnitDataList.Add(purePartsPrintData);
            if (primePartsPrintData != null) estFmUnitDataList.Add(primePartsPrintData);
            if (selectedPartsPrintData != null) estFmUnitDataList.Add(selectedPartsPrintData);

            if (estFmUnitDataList.Count == 0) return null;

            EstFmPrintCndtn estFmPrintCndtn = new EstFmPrintCndtn();
            estFmPrintCndtn.EnterpriseCode = this._enterpriseCode;
            estFmPrintCndtn.EstFmUnitDataList = estFmUnitDataList;

            // ���Ϗ����l�ݒ�}�X�^�̕␳
            EstimateDefSet estimateDefSet = this._estimateInputInitDataAcs.GetEstimateDefSet().Clone();
            estimateDefSet.PartsNoPrtCd = this._salesSlip.PartsNoPrtCd;
            estimateDefSet.ListPricePrintDiv = this._salesSlip.ListPricePrintDiv;

            estFmPrintCndtn.EstimateDefSet = estimateDefSet;

            return estFmPrintCndtn;

        }

        /// <summary>
        /// ����I�����Ă���f�[�^�����݂��邩�`�F�b�N���܂��B
        /// </summary>
        /// <returns>True:����f�[�^�L��</returns>
        public bool ExistPrintTargetData(int purePartsPrintCount, int primePartsPrintCount, int selectedPartsPrintCount, out List<string> targetList)
        {
            bool ret = true;
            targetList = new List<string>();

            EstimateInputDataSet.EstimateDetailRow[] rows = null;
            if (purePartsPrintCount > 0)
            {
                rows = this.SelectEstimateDetailRows(string.Format("{0}<>''", this._estimateDetailDataTable.GoodsNoColumn.ColumnName), this._estimateDetailDataTable);
                if (( rows == null ) || ( rows.Length == 0 ))
                {
                    ret = false;

                    targetList.Add("�����̂�");
                }
            }

            if (primePartsPrintCount > 0)
            {
                rows = this.SelectEstimateDetailRows(string.Format("{0}<>''", this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName), this._estimateDetailDataTable);
                if (( rows == null ) || ( rows.Length == 0 ))
                {
                    ret = false;

                    targetList.Add("�D�ǂ̂�");
                }
            }

            if (selectedPartsPrintCount > 0)
            {
                rows = this.SelectEstimateDetailRows(string.Format("({0}<>'' AND {1}='true') OR ({2}<>'' AND {3}='true' )", this._estimateDetailDataTable.GoodsNoColumn.ColumnName, this._estimateDetailDataTable.PrintSelectColumn.ColumnName, this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName), this._estimateDetailDataTable);
                if (( rows == null ) || ( rows.Length == 0 ))
                {
                    ret = false;

                    targetList.Add("�I�𕪂̂�");
                }
            }

            return ret;
        }

        /// <summary>
        /// ����p�f�[�^���擾���܂��B
        /// </summary>
        /// <param name="dataGetMode">�f�[�^�擾���[�h</param>
        /// <param name="printCount">�������</param>
        private EstFmPrintCndtn.EstFmUnitData GetPrintData(DataGetMode dataGetMode, int printCount)
        {
            EstFmPrintCndtn.EstFmUnitData estFmUnitData = null;

            SalesSlip salesSlip = this._salesSlip.Clone();
            List<SalesDetail> salesDetailList;
            ArrayList carManagementWorkList = new ArrayList();   // ���q�Ǘ����[�N�I�u�W�F�N�g���X�g
            Dictionary<int, Dictionary<string, object>> detailAddInfoDictionary;
            this.GetCurrentCarManagementWorkList(out carManagementWorkList); // ���q�Ǘ����[�N�I�u�W�F�N�g���X�g�擾
            CarManagementWork carManagementWork = new CarManagementWork();

            FrePEstFmHead frePEstFmHead = null;                     // ���Ϗ��w�b�_
            List<FrePEstFmDetail> frePEstFmDetailList = null;       // ���Ϗ����׃��X�g

            switch (dataGetMode)
            {

                case DataGetMode.All:                               // �S��
                    // ���׃��X�g���擾����
                    this.GetCurrentData(dataGetMode, ref salesSlip, out salesDetailList, out detailAddInfoDictionary);

                    // �������i�̍��v���z���v�Z����
                    SalesSlip salesSlip_PureParts = this._salesSlip.Clone();
                    List<SalesDetail> salesDetailList_PureParts;
                    Dictionary<int, Dictionary<string, object>> detailAddInfoDictionary_PureParts;
                    this.GetCurrentData(DataGetMode.PurePartsOnly, ref salesSlip_PureParts, out salesDetailList_PureParts, out detailAddInfoDictionary_PureParts);

                    // �D�Ǖ��i�̍��v���z���v�Z����
                    SalesSlip salesSlip_PrimeParts = this._salesSlip.Clone();
                    List<SalesDetail> salesDetailList_PrimeParts;
                    Dictionary<int, Dictionary<string, object>> detailAddInfoDictionary_PrimeParts;
                    this.GetCurrentData(DataGetMode.PrimePartsOnly, ref salesSlip_PrimeParts, out salesDetailList_PrimeParts, out detailAddInfoDictionary_PrimeParts);

                    if (( salesDetailList != null ) && ( salesDetailList.Count > 0 ))
                    {
                        // ���q���̌���
                        foreach (CarManagementWork carManagementWorkWk in carManagementWorkList)
                        {
                            if (carManagementWorkWk.CarRelationGuid == salesDetailList[0].CarRelationGuid)
                            {
                                carManagementWork = carManagementWorkWk;
                                break;
                            }
                        }
                        // ���Ϗ��w�b�_
                        frePEstFmHead = this.CreateFrePEstFmHead(salesSlip_PureParts, salesSlip_PrimeParts, carManagementWork);

                        // ���Ϗ����׃��X�g�̐���
                        SortedDictionary<int, SortedDictionary<int, SalesDetail>> detailDictionary = new SortedDictionary<int, SortedDictionary<int, SalesDetail>>();

                        // ����s�������E�D�ǂɐU�蕪����
                        foreach (SalesDetail salesDetail in salesDetailList)
                        {
                            SortedDictionary<int, SalesDetail> rowInfoDictionary;
                            if (detailDictionary.ContainsKey(salesDetail.SalesRowNo))
                            {
                                rowInfoDictionary = detailDictionary[salesDetail.SalesRowNo];
                                if (rowInfoDictionary.ContainsKey(salesDetail.SalesRowDerivNo))
                                {
                                    rowInfoDictionary[salesDetail.SalesRowDerivNo] = salesDetail;
                                }
                                else
                                {
                                    rowInfoDictionary.Add(salesDetail.SalesRowDerivNo, salesDetail);
                                }
                            }
                            else
                            {
                                rowInfoDictionary = new SortedDictionary<int, SalesDetail>();
                                rowInfoDictionary.Add(salesDetail.SalesRowDerivNo, salesDetail);
                                detailDictionary.Add(salesDetail.SalesRowNo, rowInfoDictionary);
                            }
                        }

                        frePEstFmDetailList = new List<FrePEstFmDetail>();
                        foreach (int salesRowNo in detailDictionary.Keys)
                        {
                            SortedDictionary<int, SalesDetail> rowInfoDictionary = detailDictionary[salesRowNo];

                            frePEstFmDetailList.Add(this.CreateFrePEstFmDetail(salesSlip_PureParts,
                                                                               ( rowInfoDictionary.ContainsKey((int)SalesRowDerivNo.PureParts) ) ? rowInfoDictionary[(int)SalesRowDerivNo.PureParts] : null,
                                                                               ( rowInfoDictionary.ContainsKey((int)SalesRowDerivNo.PrimeParts) ) ? rowInfoDictionary[(int)SalesRowDerivNo.PrimeParts] : null,
                                                                               ( detailAddInfoDictionary.ContainsKey(salesRowNo) ) ? detailAddInfoDictionary[salesRowNo] : null));
                        }
                        // --- ADD 2012/10/25 T.Miyamoto ------------------------------>>>>>
                        foreach (FrePEstFmDetail frePEstFmDetail in frePEstFmDetailList)
                        {
                            // --- UPD 2012/12/27 T.Miyamoto ------------------------------>>>>>
                            //if (frePEstFmDetail.DPURE_BLGOODSCODERF == 0 && frePEstFmDetail.DPRIM_BLGOODSCODERF != 0)
                            if (frePEstFmDetail.DPURE_GOODSNAMEKANARF == "")
                            // --- UPD 2012/12/27 T.Miyamoto ------------------------------<<<<<
                            {
                                frePEstFmDetail.DPURE_BLGOODSCODERF = frePEstFmDetail.DPRIM_BLGOODSCODERF;
                                frePEstFmDetail.DPURE_GOODSNAMEKANARF = frePEstFmDetail.DPRIM_GOODSNAMEKANARF;
                            }
                        }
                        // --- ADD 2012/10/25 T.Miyamoto ------------------------------<<<<<

                        // �s�ԍ��̍ĕt��
                        int rowNo = 1;
                        foreach (FrePEstFmDetail frePEstFmDetail in frePEstFmDetailList)
                        {
                            frePEstFmDetail.SALESDETAILRF_SALESROWNORF = rowNo;
                            rowNo++;
                        }
                    }

                    break;
                case DataGetMode.PurePartsOnly:                     // �����̂�
                case DataGetMode.PrimePartsOnly:                    // �D�ǂ̂�
                case DataGetMode.SelectedPartsOnly:                 // �I�𕪂̂�
                    // ���v���z���v�Z���ꂽ����f�[�^���擾����B
                    this.GetCurrentData(dataGetMode, ref salesSlip, out salesDetailList, out detailAddInfoDictionary);

                    if (( salesDetailList != null ) && ( salesDetailList.Count > 0 ))
                    {
                        // ���q���̌���
                        foreach(CarManagementWork carManagementWorkWk in carManagementWorkList)
                        {
                            if (carManagementWorkWk.CarRelationGuid ==  salesDetailList[0].CarRelationGuid)
                            {
                                carManagementWork = carManagementWorkWk;
                                break;
                            }
                        }
                        // ���Ϗ��w�b�_
                        frePEstFmHead = this.CreateFrePEstFmHead(salesSlip, null, carManagementWork);

                        // ���Ϗ����׃��X�g�̐���
                        frePEstFmDetailList = new List<FrePEstFmDetail>();
                        foreach (SalesDetail salesDetail in salesDetailList)
                        {
                            frePEstFmDetailList.Add(this.CreateFrePEstFmDetail(salesSlip, salesDetail, null, ( detailAddInfoDictionary.ContainsKey(salesDetail.SalesRowNo) ) ? detailAddInfoDictionary[salesDetail.SalesRowNo] : null));
                        }

                        // �s�ԍ��̍ĕt��
                        int rowNo = 1;
                        foreach(FrePEstFmDetail frePEstFmDetail in frePEstFmDetailList)
                        {
                            frePEstFmDetail.SALESDETAILRF_SALESROWNORF = rowNo;
                            rowNo++;
                        }
                    }

                    break;
            }

            
            if (( frePEstFmHead != null ) && ( frePEstFmDetailList != null ))
            {
                switch (dataGetMode)
                {
                    case DataGetMode.All:
                        frePEstFmHead.HADD_ESTFMDIVRF = EstFmDivState.All;
                        break;
                    case DataGetMode.PurePartsOnly:
                        frePEstFmHead.HADD_ESTFMDIVRF = EstFmDivState.Pure;
                        break;
                    case DataGetMode.PrimePartsOnly:
                        frePEstFmHead.HADD_ESTFMDIVRF = EstFmDivState.Prime;
                        break;
                    case DataGetMode.SelectedPartsOnly:
                        frePEstFmHead.HADD_ESTFMDIVRF = EstFmDivState.Selection;
                        break;
                }

                estFmUnitData = new EstFmPrintCndtn.EstFmUnitData();
                estFmUnitData.PrintCount = printCount;
                estFmUnitData.FrePEstFmHead = frePEstFmHead;
                estFmUnitData.FrePEstFmDetailList = frePEstFmDetailList;

            }

            return estFmUnitData;
        }

        /// <summary>
        /// ���R���[���Ϗ��w�b�_�f�[�^�I�u�W�F�N�g�𐶐����܂��B
        /// </summary>
        /// <param name="basicSalesSlip">������f�[�^</param>
        /// <param name="primePartsSalesSlip">�D�ǔ���f�[�^�i�D�ǋ��z�̃Z�b�g�ɂ̂ݎg�p�j</param>
        /// <param name="carManagementWork">�󒍃}�X�^�i���q�j</param>
        /// <returns>���R���[���Ϗ��w�b�_�f�[�^�I�u�W�F�N�g</returns>
        private FrePEstFmHead CreateFrePEstFmHead(SalesSlip basicSalesSlip, SalesSlip primePartsSalesSlip, CarManagementWork carManagementWork)
        {
            FrePEstFmHead frePEstFmHead = new FrePEstFmHead();

            #region ������f�[�^����Z�b�g���鍀��

            frePEstFmHead.SALESSLIPRF_SALESSLIPNUMRF = basicSalesSlip.SalesSlipNum;                     // ����`�[�ԍ�
            frePEstFmHead.SALESSLIPRF_SECTIONCODERF = basicSalesSlip.ResultsAddUpSecCd;                 // ���_�R�[�h
            frePEstFmHead.SALESSLIPRF_SALESDATERF = basicSalesSlip.SalesDate;                           // �����
            frePEstFmHead.SALESSLIPRF_ESTIMATEFORMNORF = basicSalesSlip.EstimateFormNo;                 // ���Ϗ��ԍ�
            frePEstFmHead.SALESSLIPRF_ESTIMATEDIVIDERF = basicSalesSlip.EstimateDivide;                 // ���ϋ敪
            frePEstFmHead.SALESSLIPRF_SALESINPUTCODERF = basicSalesSlip.SalesInputCode;                 // ������͎҃R�[�h
            frePEstFmHead.SALESSLIPRF_SALESINPUTNAMERF = basicSalesSlip.SalesInputName;                 // ������͎Җ���
            frePEstFmHead.SALESSLIPRF_FRONTEMPLOYEECDRF = basicSalesSlip.FrontEmployeeCd;               // ��t�]�ƈ��R�[�h
            frePEstFmHead.SALESSLIPRF_FRONTEMPLOYEENMRF = basicSalesSlip.FrontEmployeeNm;               // ��t�]�ƈ�����
            frePEstFmHead.SALESSLIPRF_SALESEMPLOYEECDRF = basicSalesSlip.SalesEmployeeCd;               // �̔��]�ƈ��R�[�h
            frePEstFmHead.SALESSLIPRF_SALESEMPLOYEENMRF = basicSalesSlip.SalesEmployeeNm;               // �̔��]�ƈ�����
            frePEstFmHead.SALESSLIPRF_CONSTAXLAYMETHODRF = basicSalesSlip.ConsTaxLayMethod;             // ����œ]�ŕ���
            frePEstFmHead.SALESSLIPRF_CUSTOMERCODERF = basicSalesSlip.CustomerCode;                     // ���Ӑ�R�[�h
            frePEstFmHead.SALESSLIPRF_CUSTOMERNAMERF = basicSalesSlip.CustomerName;                     // ���Ӑ於��
            frePEstFmHead.SALESSLIPRF_CUSTOMERNAME2RF = basicSalesSlip.CustomerName2;                   // ���Ӑ於��2
            frePEstFmHead.SALESSLIPRF_CUSTOMERSNMRF = basicSalesSlip.CustomerSnm;                       // ���Ӑ旪��
            frePEstFmHead.SALESSLIPRF_HONORIFICTITLERF = basicSalesSlip.HonorificTitle;                 // ���Ӑ�h��
            frePEstFmHead.SALESSLIPRF_SALESSLIPPRINTDATERF = basicSalesSlip.SalesSlipPrintDate;         // ����`�[���s��
            frePEstFmHead.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF = basicSalesSlip.TotalAmountDispWayCd;     // ���z�\���敪

            frePEstFmHead.HEST_ESTIMATETITLE1RF = basicSalesSlip.EstimateTitle1;                        // ���σ^�C�g���P
            frePEstFmHead.HEST_ESTIMATENOTE1RF = basicSalesSlip.EstimateNote1;                          // ���ϔ��l�P
            frePEstFmHead.HEST_ESTIMATENOTE2RF = basicSalesSlip.EstimateNote2;                          // ���ϔ��l�Q
            frePEstFmHead.HEST_ESTIMATENOTE3RF = basicSalesSlip.EstimateNote3;                          // ���ϔ��l�R
            frePEstFmHead.HEST_ESTIMATEVALIDITYLIMITRF = basicSalesSlip.EstimateValidityDate;           // ���ϗL������

            frePEstFmHead.HPURE_SALESTOTALTAXINCRF = basicSalesSlip.SalesTotalTaxInc;                   // ��������`�[���v�i�ō��݁j
            frePEstFmHead.HPURE_SALESTOTALTAXEXCRF = basicSalesSlip.SalesTotalTaxExc;                   // ��������`�[���v�i�Ŕ����j
            frePEstFmHead.HPURE_SALESSUBTOTALTAXINCRF = basicSalesSlip.SalesSubtotalTaxInc;             // �������㏬�v�i�ō��݁j
            frePEstFmHead.HPURE_SALESSUBTOTALTAXEXCRF = basicSalesSlip.SalesSubtotalTaxExc;             // �������㏬�v�i�Ŕ����j
            frePEstFmHead.HPURE_SALESSUBTOTALTAXRF = basicSalesSlip.SalesSubtotalTax;                   // �������㏬�v�i�Łj

            #endregion

            #region �D�ǔ���f�[�^����Z�b�g���鍀��

            if (primePartsSalesSlip != null)
            {
                frePEstFmHead.HPRIME_SALESTOTALTAXINCRF = primePartsSalesSlip.SalesTotalTaxInc;         // �D�ǔ���`�[���v�i�ō��݁j
                frePEstFmHead.HPRIME_SALESTOTALTAXEXCRF = primePartsSalesSlip.SalesTotalTaxExc;         // �D�ǔ���`�[���v�i�Ŕ����j
                frePEstFmHead.HPRIME_SALESSUBTOTALTAXINCRF = primePartsSalesSlip.SalesSubtotalTaxInc;   // �D�ǔ��㏬�v�i�ō��݁j
                frePEstFmHead.HPRIME_SALESSUBTOTALTAXEXCRF = primePartsSalesSlip.SalesSubtotalTaxExc;   // �D�ǔ��㏬�v�i�Ŕ����j
                frePEstFmHead.HPRIME_SALESSUBTOTALTAXRF = primePartsSalesSlip.SalesSubtotalTax;         // �D�ǔ��㏬�v�i�Łj
            }

            #endregion

            #region �󒍃}�X�^�i���q�j����Z�b�g���鍀��

            if (carManagementWork != null)
            {
                frePEstFmHead.HADD_CARMNGNORF = carManagementWork.CarMngNo;                         // ���q�Ǘ��ԍ�
                frePEstFmHead.HADD_CARMNGCODERF = carManagementWork.CarMngCode;                     // ���q�Ǘ��R�[�h
                frePEstFmHead.HADD_NUMBERPLATE1CODERF = carManagementWork.NumberPlate1Code;         // ���^�������ԍ�
                frePEstFmHead.HADD_NUMBERPLATE1NAMERF = carManagementWork.NumberPlate1Name;         // ���^�����ǖ���
                frePEstFmHead.HADD_NUMBERPLATE2RF = carManagementWork.NumberPlate2;                 // ���q�o�^�ԍ��i��ʁj
                frePEstFmHead.HADD_NUMBERPLATE3RF = carManagementWork.NumberPlate3;                 // ���q�o�^�ԍ��i�J�i�j
                frePEstFmHead.HADD_NUMBERPLATE4RF = carManagementWork.NumberPlate4;                 // ���q�o�^�ԍ��i�v���[�g�ԍ��j
                frePEstFmHead.HADD_FIRSTENTRYDATERF = carManagementWork.FirstEntryDate;             // ���N�x
                frePEstFmHead.HADD_MAKERCODERF = carManagementWork.MakerCode;                       // ���[�J�[�R�[�h
                frePEstFmHead.HADD_MAKERFULLNAMERF = carManagementWork.MakerFullName;               // ���[�J�[�S�p����
                frePEstFmHead.HADD_MAKERHALFNAMERF = carManagementWork.MakerHalfName;               // ���[�J�[���p����
                frePEstFmHead.HADD_MODELCODERF = carManagementWork.ModelCode;                       // �Ԏ�R�[�h
                frePEstFmHead.HADD_MODELSUBCODERF = carManagementWork.ModelSubCode;                 // �Ԏ�T�u�R�[�h
                frePEstFmHead.HADD_MODELFULLNAMERF = carManagementWork.ModelFullName;               // �Ԏ�S�p����
                frePEstFmHead.HADD_MODELHALFNAMERF = carManagementWork.ModelHalfName;               // �Ԏ피�p����
                frePEstFmHead.HADD_EXHAUSTGASSIGNRF = carManagementWork.ExhaustGasSign;             // �r�K�X�L��
                frePEstFmHead.HADD_SERIESMODELRF = carManagementWork.SeriesModel;                   // �V���[�Y�^��
                frePEstFmHead.HADD_CATEGORYSIGNMODELRF = carManagementWork.CategorySignModel;       // �^���i�ޕʋL���j
                frePEstFmHead.HADD_FULLMODELRF = carManagementWork.FullModel;                       // �^���i�t���^�j
                frePEstFmHead.HADD_MODELDESIGNATIONNORF = carManagementWork.ModelDesignationNo;     // �^���w��ԍ�
                frePEstFmHead.HADD_CATEGORYNORF = carManagementWork.CategoryNo;                     // �ޕʔԍ�
                frePEstFmHead.HADD_FRAMEMODELRF = carManagementWork.FrameModel;                     // �ԑ�^��
                frePEstFmHead.HADD_FRAMENORF = carManagementWork.FrameNo;                           // �ԑ�ԍ�
                frePEstFmHead.HADD_SEARCHFRAMENORF = carManagementWork.SearchFrameNo;               // �ԑ�ԍ��i�����p�j
                frePEstFmHead.HADD_ENGINEMODELNMRF = carManagementWork.EngineModelNm;               // �G���W���^������
                frePEstFmHead.HADD_RELEVANCEMODELRF = carManagementWork.RelevanceModel;             // �֘A�^��
                frePEstFmHead.HADD_SUBCARNMCDRF = carManagementWork.SubCarNmCd;                     // �T�u�Ԗ��R�[�h
                frePEstFmHead.HADD_MODELGRADESNAMERF = carManagementWork.ModelGradeSname;           // �^���O���[�h����
                frePEstFmHead.HADD_COLORCODERF = carManagementWork.ColorCode;                       // �J���[�R�[�h
                frePEstFmHead.HADD_COLORNAME1RF = carManagementWork.ColorName1;                     // �J���[����1
                frePEstFmHead.HADD_TRIMCODERF = carManagementWork.TrimCode;                         // �g�����R�[�h
                frePEstFmHead.HADD_TRIMNAMERF = carManagementWork.TrimName;                         // �g��������
                frePEstFmHead.HADD_MILEAGERF = carManagementWork.Mileage;                           // ���q���s����
                frePEstFmHead.HADD_SYSTEMATICCODERF = carManagementWork.SystematicCode;             // �n���R�[�h
                frePEstFmHead.HADD_SYSTEMATICNAMERF = carManagementWork.SystematicName;             // �n������
                frePEstFmHead.HADD_STPRODUCETYPEOFYEARRF = carManagementWork.StProduceTypeOfYear;   // �J�n���Y�N��
                frePEstFmHead.HADD_EDPRODUCETYPEOFYEARRF = carManagementWork.EdProduceTypeOfYear;   // �I�����Y�N��
                frePEstFmHead.HADD_DOORCOUNTRF = carManagementWork.DoorCount;                       // �h�A��
                frePEstFmHead.HADD_BODYNAMECODERF = carManagementWork.BodyNameCode;                 // �{�f�B�[���R�[�h
                frePEstFmHead.HADD_BODYNAMERF = carManagementWork.BodyName;                         // �{�f�B�[����
                frePEstFmHead.HADD_STPRODUCEFRAMENORF = carManagementWork.StProduceFrameNo;         // ���Y�ԑ�ԍ��J�n
                frePEstFmHead.HADD_EDPRODUCEFRAMENORF = carManagementWork.EdProduceFrameNo;         // ���Y�ԑ�ԍ��I��
                frePEstFmHead.HADD_ENGINEMODELRF = carManagementWork.EngineModel;                   // �����@�^���i�G���W���j
                frePEstFmHead.HADD_MODELGRADENMRF = carManagementWork.ModelGradeNm;                 // �^���O���[�h����
                frePEstFmHead.HADD_ENGINEDISPLACENMRF = carManagementWork.EngineDisplaceNm;         // �r�C�ʖ���
                frePEstFmHead.HADD_EDIVNMRF = carManagementWork.EDivNm;                             // E�敪����
                frePEstFmHead.HADD_TRANSMISSIONNMRF = carManagementWork.TransmissionNm;             // �~�b�V��������
                frePEstFmHead.HADD_SHIFTNMRF = carManagementWork.ShiftNm;                           // �V�t�g����
                frePEstFmHead.HADD_WHEELDRIVEMETHODNMRF = carManagementWork.WheelDriveMethodNm;     // �쓮��������
                frePEstFmHead.HADD_ADDICARSPEC1RF = carManagementWork.AddiCarSpec1;                 // �ǉ�����1
                frePEstFmHead.HADD_ADDICARSPEC2RF = carManagementWork.AddiCarSpec2;                 // �ǉ�����2
                frePEstFmHead.HADD_ADDICARSPEC3RF = carManagementWork.AddiCarSpec3;                 // �ǉ�����3
                frePEstFmHead.HADD_ADDICARSPEC4RF = carManagementWork.AddiCarSpec4;                 // �ǉ�����4
                frePEstFmHead.HADD_ADDICARSPEC5RF = carManagementWork.AddiCarSpec5;                 // �ǉ�����5
                frePEstFmHead.HADD_ADDICARSPEC6RF = carManagementWork.AddiCarSpec6;                 // �ǉ�����6
                frePEstFmHead.HADD_ADDICARSPECTITLE1RF = carManagementWork.AddiCarSpecTitle1;       // �ǉ������^�C�g��1
                frePEstFmHead.HADD_ADDICARSPECTITLE2RF = carManagementWork.AddiCarSpecTitle2;       // �ǉ������^�C�g��2
                frePEstFmHead.HADD_ADDICARSPECTITLE3RF = carManagementWork.AddiCarSpecTitle3;       // �ǉ������^�C�g��3
                frePEstFmHead.HADD_ADDICARSPECTITLE4RF = carManagementWork.AddiCarSpecTitle4;       // �ǉ������^�C�g��4
                frePEstFmHead.HADD_ADDICARSPECTITLE5RF = carManagementWork.AddiCarSpecTitle5;       // �ǉ������^�C�g��5
                frePEstFmHead.HADD_ADDICARSPECTITLE6RF = carManagementWork.AddiCarSpecTitle6;       // �ǉ������^�C�g��6

            }

            #endregion

            return frePEstFmHead;
        }

        /// <summary>
        /// ���R���[���Ϗ����׃f�[�^�I�u�W�F�N�g�𐶐����܂��B
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <param name="salesDetail_PurePasts">���㖾�׃f�[�^(�������)</param>
        /// <param name="salesDetail_PrimePasts">���㖾�׃f�[�^(�D�Ǐ��)</param>
        /// <param name="detailAddInfo">���גǉ����</param>
        /// <returns>���R���[���Ϗ����׃f�[�^�I�u�W�F�N�g</returns>
        private FrePEstFmDetail CreateFrePEstFmDetail(SalesSlip salesSlip, SalesDetail salesDetail_PurePasts, SalesDetail salesDetail_PrimePasts, Dictionary<string, object> detailAddInfo)
        {
            FrePEstFmDetail frePEstFmDetail = new FrePEstFmDetail();

            #region �w�b�_����Z�b�g���鍀��

            frePEstFmDetail.SALESDETAILRF_SALESSLIPNUMRF = salesSlip.SalesSlipNum;                      // ����`�[�ԍ�

            #endregion

            #region �������i����

            if (salesDetail_PurePasts != null)
            {
                frePEstFmDetail.SALESDETAILRF_SALESROWNORF = salesDetail_PurePasts.SalesRowNo;          // ����s�ԍ�
                frePEstFmDetail.DPURE_GOODSMAKERCDRF = salesDetail_PurePasts.GoodsMakerCd;              // �������[�J�[�R�[�h
                frePEstFmDetail.DPURE_MAKERNAMERF = salesDetail_PurePasts.MakerName;                    // �������[�J�[����
                frePEstFmDetail.DPURE_MAKERKANANAMERF = salesDetail_PurePasts.MakerKanaName;            // �������[�J�[�J�i����
                frePEstFmDetail.DPURE_GOODSNAMERF = salesDetail_PurePasts.GoodsName;                    // �������i����
                frePEstFmDetail.DPURE_GOODSNAMEKANARF= salesDetail_PurePasts.GoodsNameKana;             // �������i���́i�J�i�j
                frePEstFmDetail.DPURE_GOODSNORF = salesDetail_PurePasts.GoodsNo;                        // �������i�ԍ�
                frePEstFmDetail.DPURE_SALESUNPRCTAXEXCFLRF = salesDetail_PurePasts.SalesUnPrcTaxExcFl;  // ��������P���i�Ŕ����j
                frePEstFmDetail.DPURE_SALESUNPRCTAXINCFLRF = salesDetail_PurePasts.SalesUnPrcTaxIncFl;  // ��������P���i�ō��݁j
                frePEstFmDetail.DPURE_LISTPRICETAXEXCFLRF = salesDetail_PurePasts.ListPriceTaxExcFl;    // �����艿�i�Ŕ����j
                frePEstFmDetail.DPURE_LISTPRICETAXINCFLRF = salesDetail_PurePasts.ListPriceTaxIncFl;    // �����艿�i�ō��݁j
                frePEstFmDetail.DPURE_SALESMONEYTAXEXCRF = salesDetail_PurePasts.SalesMoneyTaxExc;      // ����������z�i�Ŕ����j
                frePEstFmDetail.DPURE_SALESMONEYTAXINCRF = salesDetail_PurePasts.SalesMoneyTaxInc;      // ����������z�i�ō��݁j
                frePEstFmDetail.DPURE_SHIPMENTCNTRF = salesDetail_PurePasts.ShipmentCnt;                // �����o�א�
                frePEstFmDetail.DPURE_BLGOODSCODERF = salesDetail_PurePasts.BLGoodsCode;                // ����BL�R�[�h
                frePEstFmDetail.DPURE_TAXATIONDIVCDRF = salesDetail_PurePasts.TaxationDivCd;            // �����ېŋ敪
            }

            #endregion

            #region �D�Ǖ��i

            if (salesDetail_PrimePasts != null)
            {
                frePEstFmDetail.DPRIM_GOODSMAKERCDRF = salesDetail_PrimePasts.GoodsMakerCd;             // �D�ǃ��[�J�[�R�[�h
                frePEstFmDetail.DPRIM_MAKERNAMERF = salesDetail_PrimePasts.MakerName;                   // �D�ǃ��[�J�[����
                frePEstFmDetail.DPRIM_MAKERKANANAMERF = salesDetail_PrimePasts.MakerKanaName;           // �D�ǃ��[�J�[�J�i����
                frePEstFmDetail.DPRIM_GOODSNAMERF = salesDetail_PrimePasts.GoodsName;                   // �D�Ǐ��i����
                frePEstFmDetail.DPRIM_GOODSNAMEKANARF = salesDetail_PrimePasts.GoodsNameKana;           // �D�Ǐ��i���̃J�i
                frePEstFmDetail.DPRIM_GOODSNORF = salesDetail_PrimePasts.GoodsNo;                       // �D�Ǐ��i�ԍ�
                frePEstFmDetail.DPRIM_SALESUNPRCTAXEXCFLRF = salesDetail_PrimePasts.SalesUnPrcTaxExcFl; // �D�ǔ���P���i�Ŕ����j
                frePEstFmDetail.DPRIM_SALESUNPRCTAXINCFLRF = salesDetail_PrimePasts.SalesUnPrcTaxIncFl; // �D�ǔ���P���i�ō��݁j
                frePEstFmDetail.DPRIM_LISTPRICETAXEXCFLRF = salesDetail_PrimePasts.ListPriceTaxExcFl;   // �D�ǒ艿�i�Ŕ����j
                frePEstFmDetail.DPRIM_LISTPRICETAXINCFLRF = salesDetail_PrimePasts.ListPriceTaxIncFl;   // �D�ǒ艿�i�ō��݁j
                frePEstFmDetail.DPRIM_SALESMONEYTAXEXCRF = salesDetail_PrimePasts.SalesMoneyTaxExc;     // �D�ǔ�����z�i�Ŕ����j
                frePEstFmDetail.DPRIM_SALESMONEYTAXINCRF = salesDetail_PrimePasts.SalesMoneyTaxInc;     // �D�ǔ�����z�i�ō��݁j
                frePEstFmDetail.DPRIM_SHIPMENTCNTRF = salesDetail_PrimePasts.ShipmentCnt;               // �D�Ǐo�א�
                frePEstFmDetail.DPRIM_BLGOODSCODERF = salesDetail_PrimePasts.BLGoodsCode;               // �D��BL�R�[�h
                frePEstFmDetail.DPRIM_TAXATIONDIVCDRF = salesDetail_PrimePasts.TaxationDivCd;           // �D�ǉېŋ敪

                //frePEstFmDetail.DADD_PRIMEXISTSRF = 1;
            }

            #endregion

            if (detailAddInfo != null)
            {
                if (detailAddInfo.ContainsKey(this._estimateDetailDataTable.SpecialNoteColumn.ColumnName))
                {
                    frePEstFmDetail.DADD_SPECIALNOTE = (string)detailAddInfo[this._estimateDetailDataTable.SpecialNoteColumn.ColumnName];
                }
            }
       
            return frePEstFmDetail;
        }

        #endregion

        // ===================================================================================== //
        // �����I���֘A
        // ===================================================================================== //
        #region �������I���֘A

        /// <summary>
        /// �����I�������f�[�^�ɔ��f���܂��B
        /// </summary>
        /// <param name="uoeOrderDataTable"></param>
        /// <param name="uoeOrderDetailDataTable"></param>
        public void ReflectionOrderSelectInfo(EstimateInputDataSet.UOEOrderDataTable uoeOrderDataTable, EstimateInputDataSet.UOEOrderDetailDataTable uoeOrderDetailDataTable)
        {
            try
            {
                this._estimateDetailDataTable.BeginLoadData();
                this._primeInfoDataTable.BeginLoadData();
                this._uoeOrderDataTable.BeginLoadData();
                this._uoeOrderDetailDataTable.BeginLoadData();

                #region �������̉���


                EstimateInputDataSet.EstimateDetailRow[] estimateDetailRows = this.SelectEstimateDetailRows(string.Format("{0}<>'{1}' OR {2}<>'{3}'", this._estimateDetailDataTable.UOEOrderGuidColumn.ColumnName, Guid.Empty, this._estimateDetailDataTable.UOEOrderGuid_PrimeColumn.ColumnName, Guid.Empty), _estimateDetailDataTable);

                if (( estimateDetailRows != null ) && ( estimateDetailRows.Length > 0 ))
                {
                    foreach (EstimateInputDataSet.EstimateDetailRow estimateDetailRow in estimateDetailRows)
                    {
                        estimateDetailRow.UOEOrderGuid = Guid.Empty;
                        estimateDetailRow.UOEOrderGuid_Prime = Guid.Empty;
                    }
                }

                EstimateInputDataSet.PrimeInfoRow[] primeInfoRows = this.SelectPrimeInfoRows(string.Format("{0}<>'{1}'", this._primeInfoDataTable.UOEOrderGuidColumn.ColumnName, Guid.Empty), this._primeInfoDataTable);

                if (( primeInfoRows != null ) && ( primeInfoRows.Length > 0 ))
                {
                    foreach (EstimateInputDataSet.PrimeInfoRow primeInfoRow in primeInfoRows)
                    {
                        primeInfoRow.UOEOrderGuid = Guid.Empty;
                    }
                }

                #endregion

                
                this._uoeOrderDataTable.Rows.Clear();
                this._uoeOrderDataTable = (EstimateInputDataSet.UOEOrderDataTable)uoeOrderDataTable.Copy();
                this._uoeOrderDetailDataTable.Rows.Clear();
                this._uoeOrderDetailDataTable = (EstimateInputDataSet.UOEOrderDetailDataTable)uoeOrderDetailDataTable.Copy();

                foreach (EstimateInputDataSet.UOEOrderDetailRow uoeOrderDetailRow in this._uoeOrderDetailDataTable.Rows)
                {
                    estimateDetailRows = this.SelectEstimateDetailRows(string.Format("{0}='{1}'", this._estimateDetailDataTable.DtlRelationGuidColumn.ColumnName, uoeOrderDetailRow.DtlRelationGuid), this._estimateDetailDataTable);
                    if (( estimateDetailRows != null ) && ( estimateDetailRows.Length > 0 ))
                    {
                        foreach (EstimateInputDataSet.EstimateDetailRow estimateDetailRow in estimateDetailRows)
                        {
                            estimateDetailRow.UOEOrderGuid = uoeOrderDetailRow.OrderGuid;
                        }
                    }
                    else
                    {
                        estimateDetailRows = this.SelectEstimateDetailRows(string.Format("{0}='{1}'", this._estimateDetailDataTable.DtlRelationGuid_PrimeColumn.ColumnName, uoeOrderDetailRow.DtlRelationGuid), this._estimateDetailDataTable);
                        if (( estimateDetailRows != null ) && ( estimateDetailRows.Length > 0 ))
                        {
                            foreach (EstimateInputDataSet.EstimateDetailRow estimateDetailRow in estimateDetailRows)
                            {
                                estimateDetailRow.UOEOrderGuid_Prime = uoeOrderDetailRow.OrderGuid;
                            }
                        }


                        primeInfoRows = this.SelectPrimeInfoRows(string.Format("{0}='{1}'", this._primeInfoDataTable.DtlRelationGuidColumn.ColumnName, uoeOrderDetailRow.DtlRelationGuid), this._primeInfoDataTable);

                        if (( primeInfoRows != null ) && ( primeInfoRows.Length > 0 ))
                        {
                            foreach (EstimateInputDataSet.PrimeInfoRow primeInfoRow in primeInfoRows)
                            {
                                primeInfoRow.UOEOrderGuid = uoeOrderDetailRow.OrderGuid;
                            }
                        }
                    }
                }
            }
            finally
            {
                this._estimateDetailDataTable.EndLoadData();
                this._primeInfoDataTable.EndLoadData();
                this._uoeOrderDataTable.EndLoadData();
                this._uoeOrderDetailDataTable.EndLoadData();
            }
        }

        /// <summary>
        /// �����I�𖾍׃f�[�^�폜����
        /// </summary>
        /// <param name="dtlRelationGuid">���טA���f�t�h�c</param>
        /// <param name="uoeOrderGuid">�t�n�d�����f�t�h�c</param>
        private void DeleteUOEOrderDetail(Guid dtlRelationGuid,out Guid uoeOrderGuid)
        {
            uoeOrderGuid=Guid.Empty;
            EstimateInputDataSet.UOEOrderDetailRow uoeOrderDetailRow = this._uoeOrderDetailDataTable.FindByDtlRelationGuid(dtlRelationGuid);

            if (uoeOrderDetailRow != null)
            {
                this._uoeOrderDetailDataTable.RemoveUOEOrderDetailRow(uoeOrderDetailRow);
                uoeOrderGuid = uoeOrderDetailRow.OrderGuid;
            }
        }

        /// <summary>
        /// �����I���f�[�^�폜����
        /// </summary>
        /// <param name="uoeOrderGuid"></param>
        private void DeleteUOEOrder(Guid uoeOrderGuid)
        {
            uoeOrderGuid = Guid.Empty;
            EstimateInputDataSet.UOEOrderRow uoeOrderRow = this._uoeOrderDataTable.FindByOrderGuid(uoeOrderGuid);

            if (uoeOrderRow != null)
            {
                this._uoeOrderDataTable.RemoveUOEOrderRow(uoeOrderRow);
            }
        }

        /// <summary>
        /// �����I�������폜���܂��B
        /// </summary>
        /// <param name="dtlRelationGuid"></param>
        private void DeleteOrderSelectInfo(Guid dtlRelationGuid)
        {
            Guid orderGuid;
            this.DeleteUOEOrderDetail(dtlRelationGuid, out orderGuid);

            if (orderGuid != Guid.Empty)
            {
                EstimateInputDataSet.UOEOrderDetailRow[] uoeOrderDetailRows = (EstimateInputDataSet.UOEOrderDetailRow[])this._uoeOrderDetailDataTable.Select(string.Format("{0}='{1}'", this._uoeOrderDetailDataTable.OrderGuidColumn.ColumnName, orderGuid));

                if (( uoeOrderDetailRows == null ) || ( uoeOrderDetailRows.Length == 0 ))
                {
                    this.DeleteUOEOrder(orderGuid);
                }
            }
        }

        #endregion

        // ADD 2010/05/17 �i���\���Ή� ---------->>>>>
        /// <summary>
        /// BL���i�����擾���܂��B
        /// </summary>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <returns>BL���i���</returns>
        private BLGoodsCdUMnt GetBLGoodsInfo(int blGoodsCode)
        {
            return this._estimateInputInitDataAcs.GetBLGoodsCdUMntFromCache(blGoodsCode);
        }
        // ADD 2010/05/17 �i���\���Ή� ----------<<<<<

        // --- ADD 2012/09/07 Y.Wakita ---------->>>>>
        /// <summary>
        /// ���q���擾
        /// </summary>
        /// <param name="carInfoRow">�ԗ����s�I�u�W�F�N�g</param>
        /// <param name="selectedInfo">�C�x���g�p�����[�^�N���X</param>
        public int SearchCarManagement(EstimateInputDataSet.CarInfoRow carInfoRow, out CarMangInputExtraInfo selectedInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            selectedInfo = new CarMangInputExtraInfo();
            try
            {
                string errMsg = string.Empty;

                // --- ADD 2012/09/12 Y.Wakita ---------->>>>>
                if (carInfoRow.CustomerCode == 0)
                {
                    SalesSlip salesSlip = this._salesSlip.Clone();
                    carInfoRow.CustomerCode = salesSlip.CustomerCode;
                }
                // --- ADD 2012/09/12 Y.Wakita ----------<<<<<

                // ���Ӑ�R�[�h
                selectedInfo.CustomerCode = carInfoRow.CustomerCode;
                // ���q�Ǘ��ԍ�
                selectedInfo.CarMngNo = carInfoRow.CarMngNo;
                // �Ǘ��ԍ�
                selectedInfo.CarMngCode = carInfoRow.CarMngCode;
                // ���q���l
                selectedInfo.CarNote = carInfoRow.CarNote;

                // ���q�Ǘ��}�X�^�̌���
                status = CarMngInputAcs.GetInstance().ReadDB(ref selectedInfo, 0, out errMsg);
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        // --- ADD 2012/09/07 Y.Wakita ----------<<<<<

        // --- ADD 杍^ 2014/09/01 ---------->>>>>
        /// <summary>
        /// �ԗ����THREAD�ɐݒ肵�܂��B
        /// </summary>
        /// <returns></returns>
        public void SetCarInfoToThread(GoodsCndtn cndtn)
        {
            // TLS�p�̕ϐ�
            CarInfoThreadData carInfoThreadData = new CarInfoThreadData();

            // �ԗ����
            if (cndtn != null && cndtn.SearchCarInfo != null)
            {
                if (cndtn.SearchCarInfo.CarModelUIData.Count > 0)
                {
                    // �ޕ�(PM�̏��)
                    carInfoThreadData.ModelDesignationNo = cndtn.SearchCarInfo.CarModelUIData[0].ModelDesignationNo;
                    // �ԍ�(PM�̏��)
                    carInfoThreadData.CategoryNo = cndtn.SearchCarInfo.CarModelUIData[0].CategoryNo;
                    // �ԑ�ԍ�(PM�̏��)
                    carInfoThreadData.FrameNo = cndtn.SearchCarInfo.CarModelUIData[0].FrameNo;
                    // ���Y�^�O�ԋ敪(PM�̏��)���q�Ǘ��}�X�^�u1:���Y,2:�O�ԁv
                    carInfoThreadData.FrameNoKubun = cndtn.SearchCarInfo.CarModelUIData[0].DomesticForeignCode;
                    // �N��(PM�̏��)
                    carInfoThreadData.FirstEntryDate = cndtn.SearchCarInfo.CarModelUIData[0].ProduceTypeOfYearInput;
                }

                if (cndtn.SearchCarInfo.CarModelInfoSummarized.Count > 0)
                {
                    PMKEN01010E.CarModelInfoRow[] row = (PMKEN01010E.CarModelInfoRow[])cndtn.SearchCarInfo.CarModelInfoSummarized.Select("SelectionState = true", "", DataViewRowState.CurrentRows);
                    if (row.Length > 0)
                    {
                        // ���[�J�[(PM�̏��)
                        carInfoThreadData.MakerCode = row[0].MakerCode;
                        // �Ԏ�(PM�̏��)(PM�̏��)
                        carInfoThreadData.ModelCode = row[0].ModelCode;
                        // �Ԏ�T�u�R�[�h(PM�̏��)
                        carInfoThreadData.ModelSubCode = row[0].ModelSubCode;
                        // �Ԏ햼(PM�̏��)
                        carInfoThreadData.ModelFullName = row[0].ModelFullName;
                        // �^��(PM�̏��)
                        carInfoThreadData.FullModel = row[0].FullModel;
                    }
                }
            }

            // �N���敪(PM�̏��)�S�̏����l�ݒ�}�X�^�́u0:����@1:�a��i�N���j�v
            carInfoThreadData.FirstEntryDateKubun = this._estimateInputInitDataAcs.GetAllDefSet().EraNameDispCd1;
            // ���l(PM�̏��)
            carInfoThreadData.Note = this._salesSlip.SlipNote;
            // XML�t�@�C���ۑ��p
            carInfoThreadData.Pgid = PGID_XML;

            // SOLT���g���O�ɁAFREE���������s���܂��B
            Thread.FreeNamedDataSlot(CARINFOSOLT);
            carInfoSolt = Thread.AllocateNamedDataSlot(CARINFOSOLT);
            Thread.SetData(carInfoSolt, carInfoThreadData);
        }
        // --- ADD 杍^ 2014/09/01 ----------<<<<<
    }
}
