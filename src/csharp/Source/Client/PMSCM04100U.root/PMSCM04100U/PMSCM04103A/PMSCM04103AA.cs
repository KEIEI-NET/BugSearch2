//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : SCM����񓚗����Ɖ�
// �v���O�����T�v   : SCM����񓚗����Ɖ�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �� �� ��  2009/05/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 20056 ���n ���
// �� �� ��  2010/04/28  �C�����e : �݌ɋ敪�\�����@�C��
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using System.Globalization;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// SCM����񓚗����Ɖ�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM�󒍃f�[�^�ASCM�󒍖��׃f�[�^�����̎擾���s���B</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2009.05.27</br>
    /// <br></br>
    /// <br>Update Note : 2010/04/28 ���n ��� </br>
    /// <br>              �݌ɋ敪�\�����@�C��</br>
    /// <br></br>
    public class SCMAnsHistInquiryAsc
    {
        #region ��private�ϐ�
        private static SCMAnsHistInquiryAsc _scmAnsHistInquiryAsc; // ����񓚗����Ɖ�A�N�Z�X�N���X

        private ISCMAnsHistDB _iSCMAnsHistDB; // �����[�gDB

        // �����[�g���o���ʕێ��pDataTable
        private SCMAcOdrDataDataSet.SCMAnsHistInquiryDataTable _scmAnsHistInquiryDataTable;

        #endregion

        #region ���R���X�g���N�^
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SCMAnsHistInquiryAsc()
        {
            this._iSCMAnsHistDB = (ISCMAnsHistDB)MediationSCMAnsHistDB.GetSCMAnsHistDB();

            this._scmAnsHistInquiryDataTable = new SCMAcOdrDataDataSet.SCMAnsHistInquiryDataTable();
        }

        /// <summary>
        /// �C���X�^���X�擾����
        /// </summary>
        /// <returns>�C���X�^���X</returns>
        public static SCMAnsHistInquiryAsc GetInstance()
        {
            if (_scmAnsHistInquiryAsc == null)
            {
                _scmAnsHistInquiryAsc = new SCMAnsHistInquiryAsc();
            }

            return _scmAnsHistInquiryAsc;
        }
        #endregion

        #region ��public �v���p�e�B
        /// <summary>
        /// SCM����񓚗����Ɖ���[�g���o���ʃe�[�u��
        /// </summary>
        public SCMAcOdrDataDataSet.SCMAnsHistInquiryDataTable SCMAnsHistInquiryDataTable
        {
            get { return _scmAnsHistInquiryDataTable; }
        }

        #endregion

        #region ��public���\�b�h
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="scmAnsHistInquiryInfo"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public int Search(SCMAnsHistInquiryInfo scmAnsHistInquiryInfo, out string errMsg)
        {
            // ������
            this._scmAnsHistInquiryDataTable.Clear();

            errMsg = string.Empty;

            // �����[�g���o�����쐬
            SCMAnsHistOrderWork scmAnsHistOrderWork;
            this.SetSCMAnsHistOrderWork(scmAnsHistInquiryInfo, out scmAnsHistOrderWork);

            int status;
            object retArray = new ArrayList();

            // �e�X�g�f�[�^
            //status = this.GetTestData(out retArray, scmAnsHistOrderWork);
            
            try
            {
                status = this._iSCMAnsHistDB.Search(out retArray, scmAnsHistOrderWork, 0, ConstantManagement.LogicalMode.GetData0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                status = 1000;
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && ((ArrayList)retArray).Count != 0)
            {
                this.ExpandRetArray((ArrayList)retArray);
            }
            else if (
                (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && ((ArrayList)retArray).Count == 0)
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND
                || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                // �Y���Ȃ�
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                errMsg = "���������ɊY������f�[�^�����݂��܂���";
            }
            else
            {
                errMsg = "���������ŃG���[���������܂���";
            }

            return status;
        }
        #endregion

        #region ��private���\�b�h

        /// <summary>
        /// �����[�g���o�����쐬
        /// </summary>
        /// <param name="scmInquiryOrder">UI��ʃf�[�^�ێ��N���X</param>
        /// <param name="scmInquiryOrderWork">�����[�g���o����</param>
        private void SetSCMAnsHistOrderWork(SCMAnsHistInquiryInfo scmAnsHistInquiryInfo, out SCMAnsHistOrderWork scmAnsHistOrderWork)
        {
            scmAnsHistOrderWork = new SCMAnsHistOrderWork();

            scmAnsHistOrderWork.AnswerDivCd = new int[5] { 0, 10, 20, 30, 99 }; // TODO:�񓚋敪

            scmAnsHistOrderWork.St_InquiryDate = scmAnsHistInquiryInfo.St_InquiryDate; // �⍇����(�J�n)
            scmAnsHistOrderWork.Ed_InquiryDate = scmAnsHistInquiryInfo.Ed_InquiryDate; // �⍇����(�I��)

            scmAnsHistOrderWork.InqOtherEpCd = scmAnsHistInquiryInfo.InqOtherEpCd; // �⍇�����ƃR�[�h
            // �⍇���拒�_�R�[�h
            if (scmAnsHistInquiryInfo.InqOtherSecCd == "00")
            {
                scmAnsHistOrderWork.InqOtherSecCd = string.Empty;
            }
            else
            {
                scmAnsHistOrderWork.InqOtherSecCd = scmAnsHistInquiryInfo.InqOtherSecCd;
            }

            scmAnsHistOrderWork.St_CustomerCode = scmAnsHistInquiryInfo.St_CustomerCode; // ���Ӑ�R�[�h(�J�n)
            scmAnsHistOrderWork.Ed_CustomerCode = scmAnsHistInquiryInfo.Ed_CustomerCode; // ���Ӑ�R�[�h(�I��)

            scmAnsHistOrderWork.AwnserMethod = scmAnsHistInquiryInfo.AwnserMethod; // �񓚕��@
            scmAnsHistOrderWork.AcptAnOdrStatus = scmAnsHistInquiryInfo.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            scmAnsHistOrderWork.St_SalesSlipNum = scmAnsHistInquiryInfo.St_SalesSlipNum; // �`�[�ԍ�(�J�n)
            scmAnsHistOrderWork.Ed_SalesSlipNum = scmAnsHistInquiryInfo.Ed_SalesSlipNum; // �`�[�ԍ�(�I��)

            scmAnsHistOrderWork.InqOrdDivCd = scmAnsHistInquiryInfo.InqOrdDivCd; // �⍇���E�������

            scmAnsHistOrderWork.St_InquiryNumber = scmAnsHistInquiryInfo.St_InquiryNumber; // �⍇���ԍ�(�J�n)
            scmAnsHistOrderWork.Ed_InquiryNumber = scmAnsHistInquiryInfo.Ed_InquiryNumber; // �⍇���ԍ�(�I��)

            scmAnsHistOrderWork.NumberPlate4 = scmAnsHistInquiryInfo.NumberPlate4; // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j

            // �^��(�t��)�͞B����������
            if (scmAnsHistInquiryInfo.FullModel != null
                && scmAnsHistInquiryInfo.FullModel.Length > 0)
            {
                int fullModelSearchType = GetSearchType(scmAnsHistInquiryInfo.FullModel);

                if (fullModelSearchType == 0)
                {
                    scmAnsHistOrderWork.FullModel = scmAnsHistInquiryInfo.FullModel;
                }
                else
                {
                    // ���S��v�ȊO��"*"���폜
                    scmAnsHistOrderWork.FullModel = scmAnsHistInquiryInfo.FullModel.Replace("*", "");
                }

                scmAnsHistOrderWork.SerchTypeModelCd = fullModelSearchType;
            }
            else
            {
                scmAnsHistOrderWork.FullModel = string.Empty;
                scmAnsHistOrderWork.SerchTypeModelCd = 0;
            }

            scmAnsHistOrderWork.CarMakerCode = scmAnsHistInquiryInfo.CarMakerCode; // ���[�J�[�R�[�h(�ԗ����)
            scmAnsHistOrderWork.ModelCode = scmAnsHistInquiryInfo.ModelCode; // �Ԏ�R�[�h
            scmAnsHistOrderWork.ModelSubCode = scmAnsHistInquiryInfo.ModelSubCode; // �Ԏ�T�u�R�[�h
            scmAnsHistOrderWork.GoodsMakerCd = scmAnsHistInquiryInfo.DetailMakerCode; // ���[�J�[�R�[�h
            scmAnsHistOrderWork.BLGoodsCode = scmAnsHistInquiryInfo.BLGoodsCode; // BL���i�R�[�h

            // �i�Ԃ͞B����������
            if (scmAnsHistInquiryInfo.GoodsNo != null
                && scmAnsHistInquiryInfo.GoodsNo.Length > 0)
            {
                int goodsNoSearchType = GetSearchType(scmAnsHistInquiryInfo.GoodsNo);

                if (goodsNoSearchType == 0)
                {
                    scmAnsHistOrderWork.GoodsNo = scmAnsHistInquiryInfo.GoodsNo;
                }
                else
                {
                    // ���S��v�ȊO��"*"���폜
                    scmAnsHistOrderWork.GoodsNo = scmAnsHistInquiryInfo.GoodsNo.Replace("*", "");
                }

                scmAnsHistOrderWork.SerchTypeGoodsNo = goodsNoSearchType;
            }
            else
            {
                scmAnsHistOrderWork.GoodsNo = string.Empty;
                scmAnsHistOrderWork.SerchTypeGoodsNo = 0;
            }

            // �����i�Ԃ͞B����������
            if (scmAnsHistInquiryInfo.PureGoodsNo != null
                && scmAnsHistInquiryInfo.PureGoodsNo.Length > 0)
            {
                int pureGoodsNoSearchType = GetSearchType(scmAnsHistInquiryInfo.PureGoodsNo);

                if (pureGoodsNoSearchType == 0)
                {
                    scmAnsHistOrderWork.PureGoodsNo = scmAnsHistInquiryInfo.PureGoodsNo;
                }
                else
                {
                    // ���S��v�ȊO��"*"���폜
                    scmAnsHistOrderWork.PureGoodsNo = scmAnsHistInquiryInfo.PureGoodsNo.Replace("*", "");
                }

                scmAnsHistOrderWork.SerchTypePureGoodsNo = pureGoodsNoSearchType;
            }
            else
            {

                scmAnsHistOrderWork.PureGoodsNo = string.Empty;
                scmAnsHistOrderWork.SerchTypePureGoodsNo = 0;
            }

        }

        /// <summary>
        /// �����[�g���o���ʓW�J
        /// </summary>
        /// <param name="retArray"></param>
        private void ExpandRetArray(ArrayList retArray)
        {
            foreach (SCMAnsHistResultWork scmAnsHistResultWork in retArray)
            {
                // SCM����񓚗����e�[�u���ɓW�J
                this.SetSCMAnsHistInquiryDataTable(scmAnsHistResultWork);
            }

            // �\�[�g
            this.SortSCMAnsHistInquiryDataTable();

            // �\�[�g��ɍs�ԍ���ݒ�
            int rowNumber = 1;
            foreach (DataRow dr in this._scmAnsHistInquiryDataTable.Rows)
            {
                dr[this._scmAnsHistInquiryDataTable.RowNumberColumn.ColumnName] = rowNumber;
                rowNumber++;
            }
        }

        /// <summary>
        /// �����[�g���o���ʂ̓W�J����
        /// </summary>
        /// <param name="scmInquiryResultWork"></param>
        private void SetSCMAnsHistInquiryDataTable(SCMAnsHistResultWork scmAnsHistResultWork)
        {
            DataRow row = this._scmAnsHistInquiryDataTable.NewRow();

            #region SCM�󒍃f�[�^
            // ���_
            row[SCMAnsHistInquiryDataTable.InqOtherSecCdColumn.ColumnName] = scmAnsHistResultWork.InqOtherSecCd; 
            // ���_��
            row[SCMAnsHistInquiryDataTable.InqOtherSecNmColumn.ColumnName] = scmAnsHistResultWork.SectionGuidNm; 

            // �⍇���ԍ�
            row[SCMAnsHistInquiryDataTable.InquiryNumberColumn.ColumnName] = scmAnsHistResultWork.InquiryNumber;
            // ���Ӑ�
            row[SCMAnsHistInquiryDataTable.CustomerCodeColumn.ColumnName] = scmAnsHistResultWork.CustomerCode;
            // ���Ӑ於
            row[SCMAnsHistInquiryDataTable.CustomerNameColumn.ColumnName] = scmAnsHistResultWork.CustomerName;     
            // �X�V����
            row[SCMAnsHistInquiryDataTable.UpdateDateColumn.ColumnName] = scmAnsHistResultWork.UpdateDate;
            row[SCMAnsHistInquiryDataTable.UpdateTimeColumn.ColumnName] = scmAnsHistResultWork.UpdateTime;
            string updateTime = Convert.ToString(scmAnsHistResultWork.UpdateTime);
            row[SCMAnsHistInquiryDataTable.UpdateDateTimeForDispColumn.ColumnName]
                = scmAnsHistResultWork.UpdateDate.ToString("yyyy/MM/dd")
                + " "
                + updateTime.PadLeft(9, '0').Substring(0, 2) + ":" // ��
                + updateTime.PadLeft(9, '0').Substring(2, 2);// +":" // ��
                //+ updateTime.PadLeft(9, '0').Substring(4, 2) + "." // �b
                //+ updateTime.PadLeft(9, '0').Substring(6, 3); // �~���b

            // �񓚋敪
            row[SCMAnsHistInquiryDataTable.AnswerDivCdColumn.ColumnName] = scmAnsHistResultWork.AnswerDivCd;
            // �񓚋敪��
            row[SCMAnsHistInquiryDataTable.AnswerDivNmColumn.ColumnName] = GetAnswerDivName(scmAnsHistResultWork.AnswerDivCd);
            // �m���
            row[SCMAnsHistInquiryDataTable.JudgementDateColumn.ColumnName] = scmAnsHistResultWork.JudgementDate;

            if (scmAnsHistResultWork.JudgementDate >= 10000000)
            {
                string JudgementDate = Convert.ToString(scmAnsHistResultWork.JudgementDate);

                row[SCMAnsHistInquiryDataTable.JudgementDateForDispColumn.ColumnName]
                    = JudgementDate.Substring(0, 4) + "/" // �N
                    + JudgementDate.Substring(4, 2) + "/" // ��
                    + JudgementDate.Substring(6, 2);  // ��
            }

            // �⍇���E�������l
            row[SCMAnsHistInquiryDataTable.InqOrdNoteColumn.ColumnName] = scmAnsHistResultWork.InqOrdNote;
            // �⍇���]�ƈ��R�[�h
            row[SCMAnsHistInquiryDataTable.InqEmployeeCdColumn.ColumnName] = scmAnsHistResultWork.InqEmployeeCd;
            // �⍇���]�ƈ�����
            row[SCMAnsHistInquiryDataTable.InqEmployeeNmColumn.ColumnName] = scmAnsHistResultWork.InqEmployeeNm;
            // �񓚏]�ƈ��R�[�h
            row[SCMAnsHistInquiryDataTable.AnsEmployeeCdColumn.ColumnName] = scmAnsHistResultWork.AnsEmployeeCd;
            // �񓚏]�ƈ�����
            row[SCMAnsHistInquiryDataTable.AnsEmployeeNmColumn.ColumnName] = scmAnsHistResultWork.AnsEmployeeNm;
            // �⍇����
            row[SCMAnsHistInquiryDataTable.InquiryDateColumn.ColumnName] = scmAnsHistResultWork.InquiryDate;

            if (scmAnsHistResultWork.InquiryDate != 0)
            {
                string inquiryDate = Convert.ToString(scmAnsHistResultWork.InquiryDate);

                row[SCMAnsHistInquiryDataTable.InquiryDateForDispColumn.ColumnName]
                    = inquiryDate.Substring(0, 4) + "/" // �N
                    + inquiryDate.Substring(4, 2) + "/" // ��
                    + inquiryDate.Substring(6, 2);  // ��
            }

            // ����`�[���v�i�ō��݁j
            row[SCMAnsHistInquiryDataTable.SalesTotalTaxIncColumn.ColumnName] = scmAnsHistResultWork.SalesTotalTaxInc;
            // ���㏬�v�i�Łj
            row[SCMAnsHistInquiryDataTable.SalesSubtotalTaxColumn.ColumnName] = scmAnsHistResultWork.SalesSubtotalTax;
            // �┭�E�񓚎��
            row[SCMAnsHistInquiryDataTable.InqOrdAnsDivCdColumn.ColumnName] = scmAnsHistResultWork.InqOrdAnsDivCd;
            row[SCMAnsHistInquiryDataTable.InqOrdAnsDivNmColumn.ColumnName] = GetInqOrdAnsDivCdName(scmAnsHistResultWork.InqOrdAnsDivCd);

            // ��M����(datetime.ticks)
            row[SCMAnsHistInquiryDataTable.ReceiveDateTimeColumn.ColumnName] = scmAnsHistResultWork.ReceiveDateTime;
            DateTime receiveDate = new DateTime(scmAnsHistResultWork.ReceiveDateTime);
            if (scmAnsHistResultWork.ReceiveDateTime != 0)
            {
                row[SCMAnsHistInquiryDataTable.ReceiveDateTimeForDispColumn.ColumnName] = receiveDate.ToString("yyyy/MM/dd HH:mm:ss");
            }
            else
            {
                row[SCMAnsHistInquiryDataTable.ReceiveDateTimeForDispColumn.ColumnName] = "";
            }
            #endregion

            #region SCM�󒍃f�[�^(�ԗ����)
            // ���^�������ԍ�
            row[SCMAnsHistInquiryDataTable.NumberPlate1CodeColumn.ColumnName] = scmAnsHistResultWork.NumberPlate1Code;
            // ���^�����ǖ���
            row[SCMAnsHistInquiryDataTable.NumberPlate1NameColumn.ColumnName] = scmAnsHistResultWork.NumberPlate1Name;
            // �ԗ��o�^�ԍ�(���)
            row[SCMAnsHistInquiryDataTable.NumberPlate2Column.ColumnName] = scmAnsHistResultWork.NumberPlate2;
            // �ԗ��o�^�ԍ�(�J�i)
            row[SCMAnsHistInquiryDataTable.NumberPlate3Column.ColumnName] = scmAnsHistResultWork.NumberPlate3;
            // �ԗ��o�^�ԍ�(�v���[�g�ԍ�)
            row[SCMAnsHistInquiryDataTable.NumberPlate4Column.ColumnName] = scmAnsHistResultWork.NumberPlate4;
            // �^���w��ԍ�
            row[SCMAnsHistInquiryDataTable.ModelDesignationNoColumn.ColumnName] = scmAnsHistResultWork.ModelDesignationNo;
            // �ޕʔԍ�
            row[SCMAnsHistInquiryDataTable.CategoryNoColumn.ColumnName] = scmAnsHistResultWork.CategoryNo;
            // ���[�J�[
            row[SCMAnsHistInquiryDataTable.MakerCodeCarColumn.ColumnName] = scmAnsHistResultWork.MakerCode;
            // ���[�J�[��
            row[SCMAnsHistInquiryDataTable.MakerNameCarColumn.ColumnName] = scmAnsHistResultWork.CarMakerName;
            // �Ԏ�R�[�h
            row[SCMAnsHistInquiryDataTable.ModelCodeColumn.ColumnName] = scmAnsHistResultWork.ModelCode;
            // �Ԏ�T�u�R�[�h
            row[SCMAnsHistInquiryDataTable.ModelSubCodeColumn.ColumnName] = scmAnsHistResultWork.ModelSubCode;
            // �Ԏ햼
            row[SCMAnsHistInquiryDataTable.ModelNameColumn.ColumnName] = scmAnsHistResultWork.ModelName;
            // �Ԍ��،^��
            row[SCMAnsHistInquiryDataTable.CarInspectCertModelColumn.ColumnName] = scmAnsHistResultWork.CarInspectCertModel;
            // �^��(�t���^)
            row[SCMAnsHistInquiryDataTable.FullModelColumn.ColumnName] = scmAnsHistResultWork.FullModel;
            // �ԑ�ԍ�
            row[SCMAnsHistInquiryDataTable.FrameNoColumn.ColumnName] = scmAnsHistResultWork.FrameNo;
            // �ԑ�^��
            row[SCMAnsHistInquiryDataTable.FrameModelColumn.ColumnName] = scmAnsHistResultWork.FrameModel;
            // �V���V�[No
            row[SCMAnsHistInquiryDataTable.ChassisNoColumn.ColumnName] = scmAnsHistResultWork.ChassisNo;
            // �ԗ��ŗL�ԍ�
            row[SCMAnsHistInquiryDataTable.CarProperNoColumn.ColumnName] = scmAnsHistResultWork.CarProperNo;
            // ���Y�N��
            row[SCMAnsHistInquiryDataTable.ProduceTypeOfYearNumColumn.ColumnName] = scmAnsHistResultWork.ProduceTypeOfYearNum;
            if (scmAnsHistResultWork.ProduceTypeOfYearNum >= 100000)
            {
                string yyyymm   = scmAnsHistResultWork.ProduceTypeOfYearNum.ToString();
                string yyyy     = yyyymm.Substring(0, 4);
                string mm       = yyyymm.Substring(4, 2);
                if (int.Parse(mm) >= 1 && int.Parse(mm) <= 12)
                {
                    DateTime produceTypeOfYear = new DateTime(int.Parse(yyyy), int.Parse(mm), 1);
                    CultureInfo culture = new CultureInfo("ja-JP", true);
                    culture.DateTimeFormat.Calendar = new JapaneseCalendar();

                    row[SCMAnsHistInquiryDataTable.ProduceTypeOfYearStringColumn.ColumnName] = produceTypeOfYear.ToString("ggyy�NMM��", culture);
                }
            }

            // �R�����g
            row[SCMAnsHistInquiryDataTable.CommentColumn.ColumnName] = scmAnsHistResultWork.Comment;
            // ���y�A�J���[�R�[�h
            row[SCMAnsHistInquiryDataTable.RpColorCodeColumn.ColumnName] = scmAnsHistResultWork.RpColorCode;
            // �J���[����1
            row[SCMAnsHistInquiryDataTable.ColorName1Column.ColumnName] = scmAnsHistResultWork.ColorName1;
            // �g�����R�[�h
            row[SCMAnsHistInquiryDataTable.TrimCodeColumn.ColumnName] = scmAnsHistResultWork.TrimCode;
            // �g��������
            row[SCMAnsHistInquiryDataTable.TrimNameColumn.ColumnName] = scmAnsHistResultWork.TrimName;
            // �ԗ����s����
            row[SCMAnsHistInquiryDataTable.MileageColumn.ColumnName] = scmAnsHistResultWork.Mileage;
            // �����I�u�W�F�N�g
            row[SCMAnsHistInquiryDataTable.EquipObjColumn.ColumnName] = Encoding.Unicode.GetString(scmAnsHistResultWork.EquipObj);

            // �ޕ�
            row[SCMAnsHistInquiryDataTable.ModelCategoryColumn.ColumnName] = GetModelCategoryText(scmAnsHistResultWork);

            // �v���[�gNo
            row[SCMAnsHistInquiryDataTable.PlateNoColumn.ColumnName] = GetPlateNoText(scmAnsHistResultWork);

            #endregion

            #region SCM�󒍖��׃f�[�^
            // �⍇���s�ԍ�
            row[SCMAnsHistInquiryDataTable.InqRowNumberColumn.ColumnName] = scmAnsHistResultWork.InqRowNumber;
            // �⍇���s�ԍ��}��
            row[SCMAnsHistInquiryDataTable.InqRowNumDerivedNoColumn.ColumnName] = scmAnsHistResultWork.InqRowNumDerivedNo;
            // ���i���
            row[SCMAnsHistInquiryDataTable.GoodsDivCdColumn.ColumnName] = scmAnsHistResultWork.GoodsDivCd;
            row[SCMAnsHistInquiryDataTable.GoodsDivNameColumn.ColumnName] = GetGoodsDivName(scmAnsHistResultWork.GoodsDivCd);

            // ���T�C�N�����i���
            row[SCMAnsHistInquiryDataTable.RecyclePrtKindCodeColumn.ColumnName] = scmAnsHistResultWork.RecyclePrtKindCode;
            // ���T�C�N�����i��ʖ���
            row[SCMAnsHistInquiryDataTable.RecyclePrtKindNameColumn.ColumnName] = scmAnsHistResultWork.RecyclePrtKindName;
            // �[�i�敪
            row[SCMAnsHistInquiryDataTable.DeliveredGoodsDivColumn.ColumnName] = scmAnsHistResultWork.DeliveredGoodsDiv;
            row[SCMAnsHistInquiryDataTable.DeliveredGoodsDivNameColumn.ColumnName] = GetDeliveredGoodsDivName(scmAnsHistResultWork.DeliveredGoodsDiv);
            // �戵�敪
            row[SCMAnsHistInquiryDataTable.HandleDivCodeColumn.ColumnName] = scmAnsHistResultWork.HandleDivCode;
            row[SCMAnsHistInquiryDataTable.HandleDivCodeNameColumn.ColumnName] = GetHandleDivName(scmAnsHistResultWork.HandleDivCode);
            // ���i�`��
            row[SCMAnsHistInquiryDataTable.GoodsShapeColumn.ColumnName] = scmAnsHistResultWork.GoodsShape;
            row[SCMAnsHistInquiryDataTable.GoodsShapeNameColumn.ColumnName] = GetGoodsShapeName(scmAnsHistResultWork.GoodsShape);
            // �[�i�m�F�敪
            row[SCMAnsHistInquiryDataTable.DelivrdGdsConfCdColumn.ColumnName] = scmAnsHistResultWork.DelivrdGdsConfCd;
            row[SCMAnsHistInquiryDataTable.DelivrdGdsConfNmColumn.ColumnName] = GetDelivrdGdsConfCdName(scmAnsHistResultWork.DelivrdGdsConfCd);
            // �[�i�����\���
            row[SCMAnsHistInquiryDataTable.DeliGdsCmpltDueDateColumn.ColumnName] = scmAnsHistResultWork.DeliGdsCmpltDueDate;
            row[SCMAnsHistInquiryDataTable.DeliGdsCmpltDueDateForDispColumn.ColumnName] = scmAnsHistResultWork.DeliGdsCmpltDueDate.ToString("yyyy/MM/dd");
            // �񓚔[��
            row[SCMAnsHistInquiryDataTable.AnswerDeliveryDateColumn.ColumnName] = scmAnsHistResultWork.AnswerDeliveryDate;
            // BL���i�R�[�h
            row[SCMAnsHistInquiryDataTable.BLGoodsCodeColumn.ColumnName] = scmAnsHistResultWork.BLGoodsCode;
            // BL���i�R�[�h�}��
            row[SCMAnsHistInquiryDataTable.BLGoodsDrCodeColumn.ColumnName] = scmAnsHistResultWork.BLGoodsDrCode;
            // ������
            row[SCMAnsHistInquiryDataTable.SalesOrderCountColumn.ColumnName] = scmAnsHistResultWork.SalesOrderCount;
            // �[�i��
            row[SCMAnsHistInquiryDataTable.DeliveredGoodsCountColumn.ColumnName] = scmAnsHistResultWork.DeliveredGoodsCount;
            // ���i�ԍ�
            row[SCMAnsHistInquiryDataTable.GoodsNoColumn.ColumnName] = scmAnsHistResultWork.GoodsNo;
            // HACK:�┭���i��
            // row[SCMAnsHistInquiryDataTable.InqGoodsNameColumn.ColumnName] = scmAnsHistResultWork.InqGoodsName;
            // HACK:�񓚏��i��(�J�i)
            //row[SCMAnsHistInquiryDataTable.AnsGoodsNameColumn.ColumnName] = scmAnsHistResultWork.AnsGoodsName;
            // ���[�J�[
            row[SCMAnsHistInquiryDataTable.GoodsMakerCdColumn.ColumnName] = scmAnsHistResultWork.GoodsMakerCd;
            // ���[�J�[��
            row[SCMAnsHistInquiryDataTable.GoodsMakerNmColumn.ColumnName] = scmAnsHistResultWork.MakerName;
            // �������i���[�J�[
            row[SCMAnsHistInquiryDataTable.PureGoodsMakerCdColumn.ColumnName] = scmAnsHistResultWork.PureGoodsMakerCd;
            // �������i���[�J�[��
            row[SCMAnsHistInquiryDataTable.PureGoodsMakerNmColumn.ColumnName] = scmAnsHistResultWork.PureMakerName;
            // HACK:�┭�������i�ԍ�
            //row[SCMAnsHistInquiryDataTable.InqPureGoodsNoColumn.ColumnName] = scmAnsHistResultWork.InqPureGoodsNo;
            // HACK:�┭�������i��
            //row[SCMAnsHistInquiryDataTable.InqPureGoodsNameColumn.ColumnName] = scmAnsHistResultWork.InqPureGoodsName;
            // HACK:�񓚏������i�ԍ�
            //row[SCMAnsHistInquiryDataTable.AnsPureGoodsNoColumn.ColumnName] = scmAnsHistResultWork.AnsPureGoodsNo;
            // HACK:�񓚏������i��
            //row[SCMAnsHistInquiryDataTable.AnsPureGoodsNameColumn.ColumnName] = scmAnsHistResultWork.AnsPureGoodsName;
            // �艿
            row[SCMAnsHistInquiryDataTable.ListPriceColumn.ColumnName] = scmAnsHistResultWork.ListPrice;
            // �P��
            row[SCMAnsHistInquiryDataTable.UnitPriceColumn.ColumnName] = scmAnsHistResultWork.UnitPrice;
            // ���i�⑫���
            row[SCMAnsHistInquiryDataTable.GoodsAddInfoColumn.ColumnName] = scmAnsHistResultWork.GoodsAddInfo;
            // �e���z
            row[SCMAnsHistInquiryDataTable.RoughRrofitColumn.ColumnName] = scmAnsHistResultWork.RoughRrofit;
            // �e����
            row[SCMAnsHistInquiryDataTable.RoughRateColumn.ColumnName] = scmAnsHistResultWork.RoughRate;
            // �񓚊���
            row[SCMAnsHistInquiryDataTable.AnswerLimitDateColumn.ColumnName] = scmAnsHistResultWork.AnswerLimitDate;
            if (scmAnsHistResultWork.AnswerLimitDate != 0)
            {
                string answerLimitDate = Convert.ToString(scmAnsHistResultWork.AnswerLimitDate);
                row[SCMAnsHistInquiryDataTable.AnswerLimitDateForDispColumn.ColumnName]
                    = answerLimitDate.Substring(0, 4) + "/" // �N
                    + answerLimitDate.Substring(4, 2) + "/" // ��
                    + answerLimitDate.Substring(6, 2);  // ��
            }
            // ���l(����)
            row[SCMAnsHistInquiryDataTable.CommentDtlColumn.ColumnName] = scmAnsHistResultWork.CommentDtl;
            // �I��
            row[SCMAnsHistInquiryDataTable.ShelfNoColumn.ColumnName] = scmAnsHistResultWork.ShelfNo;
            // �ǉ��敪
            row[SCMAnsHistInquiryDataTable.AdditionalDivCdColumn.ColumnName] = scmAnsHistResultWork.AdditionalDivCd;
            // �����敪
            row[SCMAnsHistInquiryDataTable.CorrectDivCDColumn.ColumnName] = scmAnsHistResultWork.CorrectDivCD;
            // �󒍃X�e�[�^�X
            row[SCMAnsHistInquiryDataTable.AcptAnOdrStatusColumn.ColumnName] = scmAnsHistResultWork.AcptAnOdrStatus;
            row[SCMAnsHistInquiryDataTable.AcptAnOdrStatusNameColumn.ColumnName] = GetAcptAnOdrStatusName(scmAnsHistResultWork.AcptAnOdrStatus);
            // ����`�[�ԍ�
            row[SCMAnsHistInquiryDataTable.SalesSlipNumColumn.ColumnName] = scmAnsHistResultWork.SalesSlipNum;
            // ����s�ԍ�
            row[SCMAnsHistInquiryDataTable.SalesRowNoColumn.ColumnName] = scmAnsHistResultWork.SalesRowNo;
            // �⍇���E�������
            row[SCMAnsHistInquiryDataTable.InqOrdDivCdColumn.ColumnName] = scmAnsHistResultWork.InqOrdDivCd;
            row[SCMAnsHistInquiryDataTable.InqOrdDivNmColumn.ColumnName] = GetInqOrdDivCdName(scmAnsHistResultWork.InqOrdDivCd);
            // �񓚍쐬�敪0:����, 1:�蓮�iWeb�j, 2:�蓮�i���̑��j
            row[SCMAnsHistInquiryDataTable.AnswerCreateDivColumn.ColumnName] = scmAnsHistResultWork.AnswerCreateDiv;
            row[SCMAnsHistInquiryDataTable.AnswerCreateDivNmColumn.ColumnName] = GetAnswerCreateDivName(scmAnsHistResultWork.AnswerCreateDiv);
            // �݌ɋ敪
            row[SCMAnsHistInquiryDataTable.StockDivColumn.ColumnName] = scmAnsHistResultWork.StockDiv;
            row[SCMAnsHistInquiryDataTable.StockDivNameColumn.ColumnName] = GetStockDivName(scmAnsHistResultWork.StockDiv);
            // �\������
            row[SCMAnsHistInquiryDataTable.DisplayOrderColumn.ColumnName] = scmAnsHistResultWork.DisplayOrder;
            #endregion

            #region ���㖾�׃f�[�^
            // �L�����y�[���R�[�h
            row[SCMAnsHistInquiryDataTable.CampaignCodeColumn.ColumnName] = scmAnsHistResultWork.CampaignCode;
            // �L�����y�[������
            row[SCMAnsHistInquiryDataTable.CampaignNameColumn.ColumnName] = scmAnsHistResultWork.CampaignName;
            #endregion

            this._scmAnsHistInquiryDataTable.Rows.Add(row);
        }

        /// <summary>
        /// �ޕʂ̃e�L�X�g���擾���܂��B
        /// </summary>
        /// <param name="scmAnsHistResultWork"></param>
        /// <returns>�^���w��ԍ� + �ޕʔԍ�</returns>
        private static string GetModelCategoryText(SCMAnsHistResultWork scmAnsHistResultWork)
        {
            return scmAnsHistResultWork.ModelDesignationNo.ToString("00000")
                    + "-" +
                    scmAnsHistResultWork.CategoryNo.ToString("0000");
        }

        /// <summary>
        /// �v���[�gNo�̃e�L�X�g���擾���܂��B
        /// </summary>
        /// <param name="scmAnsHistResultWork"></param>
        /// <returns>
        /// �S���ڂ�A�����ĕ\������
        /// �w�w�w�w  999  �w  9999
        /// ��F�D�y 300 �� 3100
        /// ���^���������� + �ԗ��o�^�ԍ��i��ʁj+�ԗ��o�^�ԍ��i�J�i�j�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
        /// �����Ԃ͔��p�X�y�[�X
        /// </returns>
        private static string GetPlateNoText(SCMAnsHistResultWork scmAnsHistResultWork)
        {
            const char DELIM = ' ';

            StringBuilder text = new StringBuilder();
            {
                text.Append(scmAnsHistResultWork.NumberPlate1Name.Trim()).Append(DELIM);
                text.Append(scmAnsHistResultWork.NumberPlate2.Trim()).Append(DELIM);
                text.Append(scmAnsHistResultWork.NumberPlate3.Trim()).Append(DELIM);
                if (scmAnsHistResultWork.NumberPlate4 != 0) text.Append(scmAnsHistResultWork.NumberPlate4.ToString("0000"));
            }
            return text.ToString().Trim().Equals("0") ? string.Empty : text.ToString();
        }

        /// <summary>
        /// �L�[�ɂ��\�[�g���s��
        /// </summary>
        private void SortSCMAnsHistInquiryDataTable()
        {
            // �\�[�g����������̍쐬
            // �������\������̂ōX�V�������܂�
            StringBuilder sortSb = new StringBuilder();
            sortSb.Append(this._scmAnsHistInquiryDataTable.InqOtherEpCdColumn.ColumnName); // ����
            sortSb.Append(", ");
            sortSb.Append(this._scmAnsHistInquiryDataTable.InqOtherSecCdColumn.ColumnName); // �拒�_
            sortSb.Append(", ");
            sortSb.Append(this._scmAnsHistInquiryDataTable.CustomerCodeColumn.ColumnName);�@// ���Ӑ�
            sortSb.Append(", ");
            sortSb.Append(this._scmAnsHistInquiryDataTable.InquiryNumberColumn.ColumnName); // �⍇���ԍ�
            sortSb.Append(", ");
            sortSb.Append(this._scmAnsHistInquiryDataTable.InqRowNumberColumn.ColumnName);// �s�ԍ�
            sortSb.Append(", ");
            sortSb.Append(this._scmAnsHistInquiryDataTable.InqRowNumDerivedNoColumn.ColumnName);// �s�ԍ��}��
            sortSb.Append(", ");
            sortSb.Append(this._scmAnsHistInquiryDataTable.InqOrdDivCdColumn.ColumnName);// �⍇���E�������
            sortSb.Append(", ");
            sortSb.Append(this._scmAnsHistInquiryDataTable.UpdateDateColumn.ColumnName);// �X�V�N����
            sortSb.Append(", ");
            sortSb.Append(this._scmAnsHistInquiryDataTable.UpdateTimeColumn.ColumnName);// �X�V�����b�~���b

            DataView dv = new DataView(this._scmAnsHistInquiryDataTable.Copy());
            dv.Sort = sortSb.ToString();

            this._scmAnsHistInquiryDataTable.Clear();

            foreach (DataRowView drv in dv)
            {
                this._scmAnsHistInquiryDataTable.ImportRow(drv.Row);
            }
        }

        #region �����^�C�v�擾
        /// <summary>
        /// �����^�C�v�擾
        /// </summary>
        /// <param name="targetStr"></param>
        /// <returns>0:���S��v,1:�O����v����,2:�����v����,3:�B������</returns>
        private int GetSearchType(string targetStr)
        {
            if (targetStr.StartsWith("*") && targetStr.EndsWith("*"))
            {
                // �B������
                return 3;
            }
            else if (targetStr.StartsWith("*"))
            {
                // �����v����
                return 2;
            }
            else if (targetStr.EndsWith("*"))
            {
                // �O����v����
                return 1;
            }
            else
            {
                // ���̑��͊��S��v����
                return 0;
            }
        }
        #endregion

        #region ���̎擾����
        /// <summary>
        /// �񓚕��@�̖��̎擾
        /// </summary>
        /// <param name="awnserMethod"></param>
        /// <returns></returns>
        private static string GetAnswerDivName(int answerDivCd)
        {
            string answerDivCdName;

            switch (answerDivCd)
            {
                case 0:
                    {
                        answerDivCdName = "����";
                        break;
                    }
                case 1:
                    {
                        answerDivCdName = "�񓚒�";
                        break;
                    }
                case 10:
                    {
                        answerDivCdName = "�ꕔ��";
                        break;
                    }
                case 20:
                    {
                        answerDivCdName = "�񓚊���";
                        break;
                    }
                case 30:
                    {
                        answerDivCdName = "���F";
                        break;
                    }
                case 99:
                    {
                        answerDivCdName = "�L�����Z��";
                        break;
                    }
                default:
                    {
                        answerDivCdName = string.Empty;
                        break;
                    }
            }

            return answerDivCdName;
        }

        /// <summary>
        /// �┭�E�񓚎�ʂ̖��̎擾
        /// </summary>
        /// <param name="inqOrdAnsDivCd"></param>
        /// <returns></returns>
        private static string GetInqOrdAnsDivCdName(int inqOrdAnsDivCd)
        {
            string inqOrdAnsDivCdName;

            switch (inqOrdAnsDivCd)
            {
                case 1:
                    {
                        inqOrdAnsDivCdName = "�⍇���E����";
                        break;
                    }
                case 2:
                    {
                        inqOrdAnsDivCdName = "��";
                        break;
                    }
                default:
                    {
                        inqOrdAnsDivCdName = string.Empty;
                        break;
                    }
            }

            return inqOrdAnsDivCdName;
        }

        /// <summary>
        /// ���i��ʂ̖��̎擾
        /// </summary>
        /// <param name="goodsDivCd"></param>
        /// <returns></returns>
        private static string GetGoodsDivName(int goodsDivCd)
        {
            string goodsDivName;

            switch (goodsDivCd)
            {
                case 0:
                    {
                        goodsDivName = "�������i";
                        break;
                    }
                case 1:
                    {
                        goodsDivName = "�D�Ǖ��i";
                        break;
                    }
                case 2:
                    {
                        goodsDivName = "���T�C�N�����i";
                        break;
                    }
                case 3:
                    {
                        goodsDivName = "���ϑ���";
                        break;
                    }
                default:
                    {
                        goodsDivName = string.Empty;
                        break;
                    }
            }

            return goodsDivName;
        }

        /// <summary>
        /// �[�i�敪�̖��̎擾
        /// </summary>
        /// <param name="inqOrdAnsDivCd"></param>
        /// <returns></returns>
        private static string GetDeliveredGoodsDivName(int deliveredGoodsDiv)
        {
            string deliveredGoodsDivName;

            switch (deliveredGoodsDiv)
            {
                case 0:
                    {
                        deliveredGoodsDivName = "�z��";
                        break;
                    }
                case 1:
                    {
                        deliveredGoodsDivName = "����";
                        break;
                    }
                default:
                    {
                        deliveredGoodsDivName = string.Empty;
                        break;
                    }
            }

            return deliveredGoodsDivName;
        }

        /// <summary>
        /// �戵�敪�̖��̎擾
        /// </summary>
        /// <param name="inqOrdAnsDivCd"></param>
        /// <returns></returns>
        private static string GetHandleDivName(int handleDivCode)
        {
            string handleDivName;

            switch (handleDivCode)
            {
                case 0:
                    {
                        handleDivName = "�戵�i";
                        break;
                    }
                case 1:
                    {
                        handleDivName = "�[���m�F��";
                        break;
                    }
                case 2:
                    {
                        handleDivName = "���戵�i";
                        break;
                    }
                default:
                    {
                        handleDivName = string.Empty;
                        break;
                    }
            }

            return handleDivName;
        }

        /// <summary>
        /// ���i�`�Ԃ̖��̎擾
        /// </summary>
        /// <param name="inqOrdAnsDivCd"></param>
        /// <returns></returns>
        private static string GetGoodsShapeName(int goodsShape)
        {
            string goodsShapeName;

            switch (goodsShape)
            {
                case 1:
                    {
                        goodsShapeName = "���i";
                        break;
                    }
                case 2:
                    {
                        goodsShapeName = "�p�i";
                        break;
                    }
                default:
                    {
                        goodsShapeName = string.Empty;
                        break;
                    }
            }

            return goodsShapeName;
        }

        /// <summary>
        /// �[�i�m�F�敪�̖��̎擾
        /// </summary>
        /// <param name="inqOrdAnsDivCd"></param>
        /// <returns></returns>
        private static string GetDelivrdGdsConfCdName(int delivrdGdsConfCd)
        {
            string delivrdGdsConfName;

            switch (delivrdGdsConfCd)
            {
                case 0:
                    {
                        delivrdGdsConfName = "���m�F";
                        break;
                    }
                case 1:
                    {
                        delivrdGdsConfName = "�m�F";
                        break;
                    }
                default:
                    {
                        delivrdGdsConfName = string.Empty;
                        break;
                    }
            }

            return delivrdGdsConfName;
        }

        /// <summary>
        /// �񓚕��@�̖��̎擾
        /// </summary>
        /// <param name="awnserMethod"></param>
        /// <returns></returns>
        private static string GetAnswerMethodName(int awnserMethod)
        {
            string answerMethodName;

            switch (awnserMethod)
            {
                case 0:
                    {
                        answerMethodName = "����";
                        break;
                    }
                case 1:
                    {
                        answerMethodName = "�蓮";
                        break;
                    }
                default:
                    {
                        answerMethodName = string.Empty;
                        break;
                    }
            }

            return answerMethodName;
        }

        /// <summary>
        /// ������ʂ̖��̎擾
        /// </summary>
        /// <param name="inqOrdDivCd"></param>
        /// <returns></returns>
        private static string GetInqOrdDivCdName(int inqOrdDivCd)
        {
            string inqOrdDivCdName;

            switch (inqOrdDivCd)
            {
                case 1:
                    {
                        inqOrdDivCdName = "����";
                        break;
                    }
                case 2:
                    {
                        inqOrdDivCdName = "��";
                        break;
                    }
                default:
                    {
                        inqOrdDivCdName = string.Empty;
                        break;
                    }
            }

            return inqOrdDivCdName;
        }

        /// <summary>
        /// �񓚍쐬�敪���̎擾
        /// </summary>
        /// <param name="answerCreateDiv"></param>
        /// <returns>0:����, 1:�蓮�iWeb�j, 2:�蓮�i���̑��j</returns>
        private static string GetAnswerCreateDivName(int answerCreateDiv)
        {
            string retString = string.Empty;

            switch (answerCreateDiv)
            {
                case 0:
                    retString = "����";
                    break;
                case 1:
                    retString = "�蓮(Web)";
                    break;
                case 2:
                    retString = "�蓮(���̑�)";
                    break;
            }

            return retString;
        }

        /// <summary>
        /// �󒍃X�e�[�^�X�̖��̎擾
        /// </summary>
        /// <param name="inqOrdDivCd"></param>
        /// <returns></returns>
        private static string GetAcptAnOdrStatusName(int acptAnOdrStatus)
        {
            string acptAnOdrStatusName;

            switch (acptAnOdrStatus)
            {
                case 10:
                    {
                        acptAnOdrStatusName = "����";
                        break;
                    }
                case 20:
                    {
                        acptAnOdrStatusName = "��";
                        break;
                    }
                case 30:
                    {
                        acptAnOdrStatusName = "����";
                        break;
                    }
                default:
                    {
                        acptAnOdrStatusName = string.Empty;
                        break;
                    }
            }

            return acptAnOdrStatusName;
        }

        /// <summary>
        /// �݌ɋ敪���̂̎擾
        /// </summary>
        /// <param name="stockDiv"></param>
        /// <returns></returns>
        private static string GetStockDivName(int stockDiv)
        {
            string stockDivName;

            switch (stockDiv)
            {
                //case 0: // 2010/04/28
                case 1: // 2010/04/28
                    {
                        stockDivName = "�ϑ��݌�";
                        break;
                    }
                //case 1: // 2010/04/28
                case 2: // 2010/04/28
                    {
                        stockDivName = "���Ӑ�݌�";
                        break;
                    }
                //case 2: // 2010/04/28
                case 3: // 2010/04/28
                    {
                        stockDivName = "�D��q��";
                        break;
                    }
                //case 3: // 2010/04/28
                case 4: // 2010/04/28
                    {
                        stockDivName = "���Ѝ݌�";
                        break;
                    }
                //case 4: // 2010/04/28
                case 0: // 2010/04/28
                    {
                        stockDivName = "��݌�";
                        break;
                    }
                default:
                    {
                        stockDivName = string.Empty;
                        break;
                    }
            }

            return stockDivName;
        }
        #endregion
        #endregion

        #region ���e�X�g�f�[�^
        //private int GetTestData(out object ret, SCMAnsHistOrderWork scmAnsHistOrderWork)
        //{
        //    ret = new CustomSerializeArrayList();

        //    SCMAnsHistResultWork testData1 = new SCMAnsHistResultWork();

        //    #region SCM�󒍃f�[�^
        //    // ���_
        //    testData1.InqOtherSecCd = "01";
        //    // ���_��
        //    testData1.SectionGuidNm = "�e�X�g���_01";

        //    // �⍇���ԍ�
        //    testData1.InquiryNumber = 1000000000;
        //    // ���Ӑ�
        //    testData1.CustomerCode = 555;
        //    // ���Ӑ於
        //    testData1.CustomerName = "�e�X�g���Ӑ�555";
        //    // �X�V����
        //    testData1.UpdateDate = DateTime.Now;
        //    testData1.UpdateTime = 101100000;

        //    // �񓚋敪
        //    testData1.AnswerDivCd = 0;
        //    // �m���
        //    testData1.JudgementDate = 20090605;

        //    // �⍇���E�������l
        //    testData1.InqOrdNote = "�������l";
        //    // �⍇���]�ƈ��R�[�h
        //    testData1.InqEmployeeCd = "1111";
        //    // �⍇���]�ƈ�����
        //    testData1.InqEmployeeNm = "��]1111";
        //    // �񓚏]�ƈ��R�[�h
        //    testData1.AnsEmployeeCd = "2222";
        //    // �񓚏]�ƈ�����
        //    testData1.AnsEmployeeNm = "��]2222";
        //    // �⍇����
        //    testData1.InquiryDate = 20090605;

        //    // ����`�[���v�i�ō��݁j
        //    testData1.SalesTotalTaxInc = 10500;
        //    // ���㏬�v�i�Łj
        //    testData1.SalesSubtotalTax = 500;
        //    // �┭�E�񓚎��
        //    testData1.InqOrdAnsDivCd = 1;

        //    // ��M����
        //    testData1.ReceiveDateTime = DateTime.Now.Ticks;

        //    #endregion

        //    #region SCM�󒍃f�[�^(�ԗ����)
        //    // ���^�������ԍ�
        //    testData1.NumberPlate1Code = 15;
        //    // ���^�����ǖ���
        //    testData1.NumberPlate1Name = "���^15";
        //    // �ԗ��o�^�ԍ�(���)
        //    testData1.NumberPlate2 = "���";
        //    // �ԗ��o�^�ԍ�(�J�i)
        //    testData1.NumberPlate3 = "�J�i";
        //    // �ԗ��o�^�ԍ�(�v���[�g�ԍ�)
        //    testData1.NumberPlate4 = 1;
        //    // �^���w��ԍ�
        //    testData1.ModelDesignationNo = 2;
        //    // �ޕʔԍ�
        //    testData1.CategoryNo = 3;
        //    // ���[�J�[
        //    testData1.MakerCode = 1;
        //    // ���[�J�[��
        //    testData1.CarMakerName = "�ԗ����[�J�[1";
        //    // �Ԏ�R�[�h
        //    testData1.ModelCode = 1;
        //    // �Ԏ�T�u�R�[�h
        //    testData1.ModelSubCode = 2;
        //    // �Ԏ햼
        //    testData1.ModelName = "�V���V��";
        //    // �Ԍ��،^��
        //    testData1.CarInspectCertModel = "�Ԍ��،^��";
        //    // �^��(�t���^)
        //    testData1.FullModel = "�^���t��";
        //    // �ԑ�ԍ�
        //    testData1.FrameNo = "157";
        //    // �ԑ�^��
        //    testData1.FrameModel = "�ԑ�157";
        //    // �V���V�[No
        //    testData1.ChassisNo = "1";
        //    // �ԗ��ŗL�ԍ�
        //    testData1.CarProperNo = 666;
        //    // ���Y�N��
        //    testData1.ProduceTypeOfYearNum = 200906;
        //    // �R�����g
        //    testData1.Comment = "�e�X�g�R�����g";
        //    // ���y�A�J���[�R�[�h
        //    testData1.RpColorCode = "���y�A";
        //    // �J���[����1
        //    testData1.ColorName1 = "�t���J���[";
        //    // �g�����R�[�h
        //    testData1.TrimCode = "1";
        //    // �g��������
        //    testData1.TrimName = "�r�N�g���[��";
        //    // �ԗ����s����
        //    testData1.Mileage = 99999;
        //    //// �����I�u�W�F�N�g
        //    //testData1.EquipObj = System.Text.Encoding.Unicode.GetBytes("����");

        //    #endregion

        //    #region SCM�󒍖��׃f�[�^
        //    // �⍇���s�ԍ�
        //    testData1.InqRowNumber = 1;
        //    // �⍇���s�ԍ��}��
        //    testData1.InqRowNumDerivedNo = 1;
        //    // ���i���
        //    testData1.GoodsDivCd = 0; // ����

        //    // ���T�C�N�����i���
        //    testData1.RecyclePrtKindCode = 1;
        //    // ���T�C�N�����i��ʖ���
        //    testData1.RecyclePrtKindName = "�肳������";
        //    // �[�i�敪
        //    testData1.DeliveredGoodsDiv = 0; // �z��
        //    // �戵�敪
        //    testData1.HandleDivCode = 0; // �戵
        //    // ���i�`��
        //    testData1.GoodsShape = 1; // ���i
        //    // �[�i�m�F�敪
        //    testData1.DelivrdGdsConfCd = 1; // �m�F
        //    // �[�i�����\���
        //    testData1.DeliGdsCmpltDueDate = DateTime.Now;
        //    // �񓚔[��
        //    testData1.AnswerDeliveryDate = "�񓚔[����";
        //    // BL���i�R�[�h
        //    testData1.BLGoodsCode = 1;
        //    // BL���i�R�[�h�}��
        //    testData1.BLGoodsDrCode = 0;
        //    // ������
        //    testData1.SalesOrderCount = 10;
        //    // �[�i��
        //    testData1.DeliveredGoodsCount = 10;
        //    // ���i�ԍ�
        //    testData1.GoodsNo = "UENOTEST1";
        //    // ���i��(�J�i)
        //    testData1.GoodsName = "���i�J�i";
        //    // ���[�J�[
        //    testData1.GoodsMakerCd = 2;
        //    // ���[�J�[��
        //    testData1.MakerName = "���׃��[�J�[";
        //    // �������i���[�J�[
        //    testData1.PureGoodsMakerCd = 99;
        //    // �������i���[�J�[��
        //    testData1.PureMakerName = "�������[�J�[";
        //    // �������i�ԍ�
        //    testData1.PureGoodsNo = "pure1";
        //    // �������i��
        //    testData1.PureGoodsName = "�����i��";
        //    // �艿
        //    testData1.ListPrice = 10000;
        //    // �P��
        //    testData1.UnitPrice = 10000;
        //    // ���i�⑫���
        //    testData1.GoodsAddInfo = "�ق���";
        //    // �e���z
        //    testData1.RoughRrofit = 22;
        //    // �e����
        //    testData1.RoughRate = 12.95;
        //    // �񓚊���
        //    testData1.AnswerLimitDate = 20091010;

        //    // ���l(����)
        //    testData1.CommentDtl = "���l����";
        //    // �I��
        //    testData1.ShelfNo = "�I��1";
        //    // �ǉ��敪
        //    testData1.AdditionalDivCd = 0;
        //    // �����敪
        //    testData1.CorrectDivCD = 0;
        //    // �󒍃X�e�[�^�X
        //    testData1.AcptAnOdrStatus = 10; // ����
        //    // ����`�[�ԍ�
        //    testData1.SalesSlipNum = "00000001";
        //    // ����s�ԍ�
        //    testData1.SalesRowNo = 1;
        //    // �⍇���E�������
        //    testData1.InqOrdDivCd = 1; // ����
        //    // �݌ɋ敪
        //    testData1.StockDiv = 0;
        //    // �\������
        //    testData1.DisplayOrder = 1;
        //    #endregion

        //    #region ���㖾�׃f�[�^
        //    // �L�����y�[���R�[�h
        //    testData1.CampaignCode = 33;
        //    // �L�����y�[������
        //    testData1.CampaignName = "�L�����ؖ���";
        //    //// �L�����y�[�������z
        //    //testData1.DisplayOrder;
        //    //// �L�����y�[��������
        //    //testData1.ra;
        //    #endregion

        //    ((CustomSerializeArrayList)ret).Add(testData1);


        //    SCMAnsHistResultWork testData2 = new SCMAnsHistResultWork();

        //    #region SCM�󒍃f�[�^
        //    // ���_
        //    testData2.InqOtherSecCd = "01";
        //    // ���_��
        //    testData2.SectionGuidNm = "�e�X�g���_01";

        //    // �⍇���ԍ�
        //    testData2.InquiryNumber = 100;
        //    // ���Ӑ�
        //    testData2.CustomerCode = 555;
        //    // ���Ӑ於
        //    testData2.CustomerName = "�e�X�g���Ӑ�555";
        //    // �X�V����
        //    testData2.UpdateDate = DateTime.Now;
        //    testData2.UpdateTime = 101100000;

        //    // �񓚋敪
        //    testData2.AnswerDivCd = 0;
        //    // �m���
        //    testData2.JudgementDate = 20090605;

        //    // �⍇���E�������l
        //    testData2.InqOrdNote = "�������l";
        //    // �⍇���]�ƈ��R�[�h
        //    testData2.InqEmployeeCd = "1111";
        //    // �⍇���]�ƈ�����
        //    testData2.InqEmployeeNm = "��]1111";
        //    // �񓚏]�ƈ��R�[�h
        //    testData2.AnsEmployeeCd = "2222";
        //    // �񓚏]�ƈ�����
        //    testData2.AnsEmployeeNm = "��]2222";
        //    // �⍇����
        //    testData2.InquiryDate = 20090605;

        //    // ����`�[���v�i�ō��݁j
        //    testData2.SalesTotalTaxInc = 10500;
        //    // ���㏬�v�i�Łj
        //    testData2.SalesSubtotalTax = 500;
        //    // �┭�E�񓚎��
        //    testData2.InqOrdAnsDivCd = 1;

        //    // ��M����
        //    testData2.ReceiveDateTime = DateTime.Now.Ticks;

        //    #endregion

        //    #region SCM�󒍃f�[�^(�ԗ����)
        //    // ���^�������ԍ�
        //    testData2.NumberPlate1Code = 15;
        //    // ���^�����ǖ���
        //    testData2.NumberPlate1Name = "���^15";
        //    // �ԗ��o�^�ԍ�(���)
        //    testData2.NumberPlate2 = "���";
        //    // �ԗ��o�^�ԍ�(�J�i)
        //    testData2.NumberPlate3 = "�J�i";
        //    // �ԗ��o�^�ԍ�(�v���[�g�ԍ�)
        //    testData2.NumberPlate4 = 1;
        //    // �^���w��ԍ�
        //    testData2.ModelDesignationNo = 2;
        //    // �ޕʔԍ�
        //    testData2.CategoryNo = 3;
        //    // ���[�J�[
        //    testData2.MakerCode = 1;
        //    // ���[�J�[��
        //    testData2.CarMakerName = "�ԗ����[�J�[1";
        //    // �Ԏ�R�[�h
        //    testData2.ModelCode = 1;
        //    // �Ԏ�T�u�R�[�h
        //    testData2.ModelSubCode = 2;
        //    // �Ԏ햼
        //    testData2.ModelName = "�V���V��";
        //    // �Ԍ��،^��
        //    testData2.CarInspectCertModel = "�Ԍ��،^��";
        //    // �^��(�t���^)
        //    testData2.FullModel = "�^���t��";
        //    // �ԑ�ԍ�
        //    testData2.FrameNo = "157";
        //    // �ԑ�^��
        //    testData2.FrameModel = "�ԑ�157";
        //    // �V���V�[No
        //    testData2.ChassisNo = "1";
        //    // �ԗ��ŗL�ԍ�
        //    testData2.CarProperNo = 666;
        //    // ���Y�N��
        //    testData2.ProduceTypeOfYearNum = 200906;
        //    // �R�����g
        //    testData2.Comment = "�e�X�g�R�����g";
        //    // ���y�A�J���[�R�[�h
        //    testData2.RpColorCode = "���y�A";
        //    // �J���[����1
        //    testData2.ColorName1 = "�t���J���[";
        //    // �g�����R�[�h
        //    testData2.TrimCode = "1";
        //    // �g��������
        //    testData2.TrimName = "�r�N�g���[��";
        //    // �ԗ����s����
        //    testData2.Mileage = 99999;
        //    //// �����I�u�W�F�N�g
        //    //testData2.EquipObj = System.Text.Encoding.Unicode.GetBytes("�������������^�Ȃ̂�");

        //    #endregion

        //    #region SCM�󒍖��׃f�[�^
        //    // �⍇���s�ԍ�
        //    testData2.InqRowNumber = 1;
        //    // �⍇���s�ԍ��}��
        //    testData2.InqRowNumDerivedNo = 1;
        //    // ���i���
        //    testData2.GoodsDivCd = 0; // ����

        //    // ���T�C�N�����i���
        //    testData2.RecyclePrtKindCode = 1;
        //    // ���T�C�N�����i��ʖ���
        //    testData2.RecyclePrtKindName = "�肳������";
        //    // �[�i�敪
        //    testData2.DeliveredGoodsDiv = 0; // �z��
        //    // �戵�敪
        //    testData2.HandleDivCode = 0; // �戵
        //    // ���i�`��
        //    testData2.GoodsShape = 1; // ���i
        //    // �[�i�m�F�敪
        //    testData2.DelivrdGdsConfCd = 1; // �m�F
        //    // �[�i�����\���
        //    testData2.DeliGdsCmpltDueDate = DateTime.Now;
        //    // �񓚔[��
        //    testData2.AnswerDeliveryDate = "�񓚔[����";
        //    // BL���i�R�[�h
        //    testData2.BLGoodsCode = 1;
        //    // BL���i�R�[�h�}��
        //    testData2.BLGoodsDrCode = 0;
        //    // ������
        //    testData2.SalesOrderCount = 10;
        //    // �[�i��
        //    testData2.DeliveredGoodsCount = 10;
        //    // ���i�ԍ�
        //    testData2.GoodsNo = "UENOTEST1";
        //    // ���i��(�J�i)
        //    testData2.GoodsName = "���i�J�i";
        //    // ���[�J�[
        //    testData2.GoodsMakerCd = 2;
        //    // ���[�J�[��
        //    testData2.MakerName = "���׃��[�J�[";
        //    // �������i���[�J�[
        //    testData2.PureGoodsMakerCd = 99;
        //    // �������i���[�J�[��
        //    testData2.PureMakerName = "�������[�J�[";
        //    // �������i�ԍ�
        //    testData2.PureGoodsNo = "pure1";
        //    // �������i��
        //    testData2.PureGoodsName = "�����i��";
        //    // �艿
        //    testData2.ListPrice = 10000;
        //    // �P��
        //    testData2.UnitPrice = 10000;
        //    // ���i�⑫���
        //    testData2.GoodsAddInfo = "�ق���";
        //    // �e���z
        //    testData2.RoughRrofit = 22;
        //    // �e����
        //    testData2.RoughRate = 12.95;
        //    // �񓚊���
        //    testData2.AnswerLimitDate = 20091010;

        //    // ���l(����)
        //    testData2.CommentDtl = "���l����";
        //    // �I��
        //    testData2.ShelfNo = "�I��1";
        //    // �ǉ��敪
        //    testData2.AdditionalDivCd = 0;
        //    // �����敪
        //    testData2.CorrectDivCD = 0;
        //    // �󒍃X�e�[�^�X
        //    testData2.AcptAnOdrStatus = 10; // ����
        //    // ����`�[�ԍ�
        //    testData2.SalesSlipNum = "00000001";
        //    // ����s�ԍ�
        //    testData2.SalesRowNo = 1;
        //    // �⍇���E�������
        //    testData2.InqOrdDivCd = 1; // ����
        //    // �݌ɋ敪
        //    testData2.StockDiv = 0;
        //    // �\������
        //    testData2.DisplayOrder = 1;
        //    #endregion

        //    #region ���㖾�׃f�[�^
        //    // �L�����y�[���R�[�h
        //    testData2.CampaignCode = 33;
        //    // �L�����y�[������
        //    testData2.CampaignName = "�L�����ؖ���";
        //    //// �L�����y�[�������z
        //    //testData2.DisplayOrder;
        //    //// �L�����y�[��������
        //    //testData2.ra;
        //    #endregion

        //    ((CustomSerializeArrayList)ret).Add(testData2);

        //    return 0;
        //}
        #endregion
    }
}
