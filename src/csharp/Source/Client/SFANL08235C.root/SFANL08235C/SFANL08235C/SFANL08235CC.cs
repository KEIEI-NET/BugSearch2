using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// ����p�f�[�^�����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���R���[���o�����N���X�����Ɉ���p���o����������𐶐����܂�</br>
    /// <br>            : ���R���[�\�[�g���ʃ}�X�^�����Ƀ\�[�g�p������𐶐����܂�</br>
    /// <br>Programmer	: 22011 ���� ���l</br>
    /// <br>Date		: 2007.07.03</br>
    /// <br>UpdateNote	: 2007.12.12 22011 Kashihara �`�[�ԍ����[�����߂ɂ��郍�W�b�N��ǉ�</br>
    /// </remarks>
    public class SFANL08235CC : SFANL08235CA
    {
        #region private const
        // -- ���o�����敪 ------------------------
        /// <summary>���o�����敪�F�g�p�s��</summary>
        private const Int32 CT_EXTCNDDIV_NUSE = 0;
        /// <summary>���o�����敪�F���l�^</summary>
        private const Int32 CT_EXTCNDDIV_NMRC = 1;
        /// <summary>���o�����敪�F������</summary>
        private const Int32 CT_EXTCNDDIV_STRG = 3;
        /// <summary>���o�����敪�F���t</summary>
        private const Int32 CT_EXTCNDDIV_DATE = 4;
        /// <summary>���o�����敪�F�R���{�{�b�N�X</summary>
        private const Int32 CT_EXTCNDDIV_CMBB = 5;
        /// <summary>���o�����敪�F�`�F�b�N�{�b�N�X</summary>
        private const Int32 CT_EXTCNDDIV_CHKB = 6;        
        #endregion

        #region public methods

        #region ���o����������쐬
        /// <summary>
        /// ���o����������쐬
        /// </summary>
        /// <param name="frePprECndList">���R���[���o�����N���X�̃��X�g</param>
        /// <param name="frePExCndDList">���R���[���o�������׃N���X�̃��X�g</param>
        /// <param name="frePrtDataSet">���R���[����p�f�[�^�Z�b�g</param>
        /// <returns>�X�e�[�^�X ����:0</returns>
        public int GeneratExtractionCnd(List<FrePprECnd> frePprECndList, List<FrePExCndD> frePExCndDList,ref DataSet frePrtDataSet)
        {
            // �f�[�^�e�[�u���̍쐬
            GenerateFrePprPrintExtr_DT(ref frePrtDataSet);
            // ���R���[���o����
            if (frePprECndList != null)
            {
                foreach (FrePprECnd frePprEcnd in frePprECndList)
                {
                    // �����敪���g�p�s�̏ꍇ�̓R���e�B�j���[
                    if (frePprEcnd.ExtraConditionDivCd == CT_EXTCNDDIV_NUSE) continue;

                    String extCndStr = "";  // ���o����������

                    switch (frePprEcnd.ExtraConditionDivCd)
                    {
                        case CT_EXTCNDDIV_NMRC: //���l
                            {
                                //2007.12.12 ADD ----START
                                if (frePprEcnd.DDName.EndsWith("SLIPNORF", true, null))
                                {
                                    extCndStr = GetConditionStr_NumericRangeZeroPad(frePprEcnd.ExtraConditionTitle, frePprEcnd.StExtraNumCode, frePprEcnd.EdExtraNumCode, frePprEcnd.InputCharCnt, frePprEcnd.ExtraConditionTypeCd);
                                    break;
                                }
                                else
                                {
                                    extCndStr = GetConditionStr_NumericRange(frePprEcnd.ExtraConditionTitle, frePprEcnd.StExtraNumCode, frePprEcnd.EdExtraNumCode, frePprEcnd.InputCharCnt, frePprEcnd.ExtraConditionTypeCd);
                                    break;
                                }
                                //extCndStr = GetConditionStr_NumericRange(frePprEcnd.ExtraConditionTitle, frePprEcnd.StExtraNumCode, frePprEcnd.EdExtraNumCode, frePprEcnd.InputCharCnt);
                                //break;
                                //2007.12.12 ADD ----END
                            }
                        case CT_EXTCNDDIV_STRG: //�����^
                            {
                                extCndStr = GetConditionStr_StringRange(frePprEcnd.ExtraConditionTitle, frePprEcnd.StExtraCharCode, frePprEcnd.EdExtraCharCode, frePprEcnd.ExtraConditionTypeCd);
                                break;
                            }
                        case CT_EXTCNDDIV_DATE: //���t�^
                            {
                                DateTime strDate = new DateTime();
                                DateTime endDate = new DateTime();
                                // DateTime���o
                                FrePprEcndToDateTime(frePprEcnd, ref strDate, ref endDate);
                                extCndStr = GetConditionStr_DateRange(frePprEcnd.ExtraConditionTitle, strDate, endDate, frePprEcnd.ExtraConditionTypeCd);
                                break;
                            }
                        case
                            CT_EXTCNDDIV_CMBB: //�R���{�{�b�N�X
                            {
                                extCndStr = (frePprEcnd.ExtraConditionTitle + "�F " + GetDtlTitle(frePprEcnd.ExtraCondDetailGrpCd, (int)frePprEcnd.StExtraNumCode, frePExCndDList));
                                break;
                            }
                        case
                            CT_EXTCNDDIV_CHKB: //�`�F�b�N�{�b�N�X
                            {
                                extCndStr = GetConditionStr_CheckBoxChecked(frePprEcnd, frePExCndDList);
                                break;
                            }
                    }

                    //�f�[�^�e�[�u���ɒǉ�
                    if (extCndStr == string.Empty) continue;
                    DataRow dr = frePrtDataSet.Tables[CT_FREPPRPRINT_EXTR_DT].NewRow();
                    dr[CT_EXTRACTCONDS] = extCndStr;
                    frePrtDataSet.Tables[CT_FREPPRPRINT_EXTR_DT].Rows.Add(dr);
                }
            }
            return 0;
        }

        /// <summary>
        /// ���o����������쐬
        /// </summary>
        /// <param name="extCondStrList">���o����������̃��X�g</param>
        /// <param name="frePrtDataSet"></param>
        /// <returns>�X�e�[�^�X ����:0</returns>
        public int GeneratExtractionCnd(List<string> extCondStrList, ref DataSet frePrtDataSet)
        {
            // �f�[�^�e�[�u���̍쐬
            GenerateFrePprPrintExtr_DT(ref frePrtDataSet);
            // ���R���[���o����
            if (extCondStrList != null)
            {
                foreach (string extCndStr in extCondStrList)
                {
                    //�f�[�^�e�[�u���ɒǉ�
                    DataRow dr = frePrtDataSet.Tables[CT_FREPPRPRINT_EXTR_DT].NewRow();
                    dr[CT_EXTRACTCONDS] = extCndStr;
                    frePrtDataSet.Tables[CT_FREPPRPRINT_EXTR_DT].Rows.Add(dr);
                }
            }
            return 0;
        }
        #endregion

        #region �\�[�g�p������쐬
        /// <summary>
        /// DataTable�̃\�[�g�p��������쐬���܂�(����p�f�[�^�e�[�u���y�ђl���쐬���܂�)
        /// </summary>
        /// <param name="frePprSrtOLs">���R���[�\�[�g����</param>
        /// <param name="sortOder">�\�[�g���ʗp�̕�����</param>
        /// <param name="frePrtDataSet">���R���[����p�f�[�^�Z�b�g</param>
        /// <returns>�X�e�[�^�X</returns>
        public int GeneratSortOrderStr(List<FrePprSrtO> frePprSrtOLs, out string sortOder, ref DataSet frePrtDataSet)
        {
            sortOder = "";
            StringBuilder sb = new StringBuilder();
            int count = 0;
            
            // �f�[�^�e�[�u���̍쐬
            GenerateFrePprPrintSrtO_DT(ref frePrtDataSet);

            try
            {
                // �\�[�g���ʃ}�X�^����\�[�g�p��������쐬
                if (frePprSrtOLs != null)
                {
                    foreach (FrePprSrtO frePprSrt in frePprSrtOLs)
                    {
                        //�敪���u�g�p���Ȃ��v�̏ꍇ�R���e�B�j���[
                        if (frePprSrt.SortingOrderDivCd == 0)
                        {
                            continue;
                        }

                        count++;

                        if (!string.IsNullOrEmpty(frePprSrt.FileNm) && !string.IsNullOrEmpty(frePprSrt.DDName))
                        {
                            if(sb.Length != 0) sb.Append(", ");
                            sb.Append(frePprSrt.FileNm + "." + frePprSrt.DDName);
                        }
                        else if (!string.IsNullOrEmpty(frePprSrt.FileNm))
                        {
                            if (sb.Length != 0) sb.Append(", ");
                            sb.Append(frePprSrt.FileNm);
                        }
                        else if (!string.IsNullOrEmpty(frePprSrt.DDName))
                        {
                            if (sb.Length != 0) sb.Append(", ");
                            sb.Append(frePprSrt.DDName);
                        }
                        else
                            continue;

                        if (frePprSrt.SortingOrderDivCd == 1)
                        {
                            sb.Append(" ASC");
                        }
                        else if (frePprSrt.SortingOrderDivCd == 2)
                        {
                            sb.Append(" DESC");
                        }


                        if (count <= 5)
                        {
                            //�f�[�^�e�[�u���ɒǉ�
                            DataRow dr = frePrtDataSet.Tables[CT_FREPPRPRINT_SRTO_DT].Rows[0];
                            dr[CT_SORTODER + count.ToString()] = frePprSrt.FreePrtPaperItemNm + "��";
                        }
                    }
                }
            }
            catch
            {
                return -1;
            }

            sortOder = sb.ToString();
            return 0;
        }

        /// <summary>
        /// DataTable�̃\�[�g�p��������쐬���܂�(����p�f�[�^�e�[�u���y�ђl���쐬���܂�)
        /// </summary>
        /// <param name="SrtOdrStrLs">���R���[�\�[�g����</param>
        /// <param name="frePrtDataSet">���R���[����p�f�[�^�Z�b�g</param>
        /// <returns>�X�e�[�^�X</returns>
        public int GeneratSortOrderStr(List<string> SrtOdrStrLs, ref DataSet frePrtDataSet)
        {
            int count = 0;

            // �f�[�^�e�[�u���̍쐬
            GenerateFrePprPrintSrtO_DT(ref frePrtDataSet);

            try
            {
                // �\�[�g���ʃ}�X�^����\�[�g�p��������쐬
                if (SrtOdrStrLs != null)
                {
                    foreach (string frePprSrt in SrtOdrStrLs)
                    {
                        count++;
                        if (count <= 5)
                        {
                            //�f�[�^�e�[�u���ɒǉ�
                            DataRow dr = frePrtDataSet.Tables[CT_FREPPRPRINT_SRTO_DT].Rows[0];
                            dr[CT_SORTODER + count.ToString()] = frePprSrt;
                        }
                    }
                }
            }
            catch
            {
                return -1;
            }
            return 0;
        }
        #endregion

        #region ���|�[�g�t�b�^�f�[�^�쐬
        /// <summary>
        /// DataTable�̃\�[�g�p��������쐬���܂�(����p�f�[�^�e�[�u���y�ђl���쐬���܂�)
        /// </summary>
        /// <param name="frePrtDataSet">���R���[����p�f�[�^�Z�b�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int GeneratPrintRepFooter(ref DataSet frePrtDataSet, out string message)
        {
            int status = 0;
            PrtOutSet prtoutset = null;

            // �f�[�^�e�[�u���̍쐬
            GenerateFrePprPrintPFtr_DT(ref frePrtDataSet);
            status = ReadPrtOutSet(out prtoutset,out message);

            //�f�[�^�e�[�u���ɒǉ�
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                DataRow dr = frePrtDataSet.Tables[CT_FREPPRPRINT_PFTR_DT].NewRow();
                if (prtoutset.FooterPrintOutCode == 0)
                {
                    dr[CT_PRINTFOOTER1] = prtoutset.PrintFooter1;
                    dr[CT_PRINTFOOTER2] = prtoutset.PrintFooter2;
                }
                frePrtDataSet.Tables[CT_FREPPRPRINT_PFTR_DT].Rows.Add(dr);
            }

            return status;
        }

        #endregion

        #region ������C���f�[�^�e�[�u���č\�z
        /// <summary>
        /// ������C���f�[�^�e�[�u���č\�z����(DefaultView�̓��e��DataTable���č\�z)
        /// </summary>
        /// <param name="printDataSet"></param>
        public void MainDataTableReConstruction(ref DataSet printDataSet)
        {
            DataTable bufDT = new DataTable();
            bufDT = printDataSet.Tables[SFANL08235CD.CT_FREPPRPRINT_MAIN_DT].Clone();
            bufDT.Clear();

            foreach (DataRowView drv in printDataSet.Tables[SFANL08235CD.CT_FREPPRPRINT_MAIN_DT].DefaultView)
            {
                bufDT.ImportRow(drv.Row);
            }
            printDataSet.Tables.Remove(SFANL08235CD.CT_FREPPRPRINT_MAIN_DT);
            printDataSet.Tables.Add(bufDT);            
        }
        #endregion

        #endregion

        #region private methods

        #region ���o�͈͕�����쐬(string)
        /// <summary>
		/// ���o�͈͕�����쐬(string)
		/// </summary>
		/// <returns>�쐬������</returns>
        private string GetConditionStr_StringRange(string title, string startString, string endString, int extraConditionTypeCd)
		{
			string result = string.Empty;
			if ((startString != "") || (endString != ""))
			{
                if ((startString != null) || (endString != null))
                {
                    string start = "�s�n�o";
                    string end = "�d�m�c";
                    if (startString != "") start = startString;
                    if (endString != "") end = endString;
                    if (startString != "" || endString != "")
                    {
                        //��v���B���̂Ƃ��̓X�^�[�g��������
                        if ((extraConditionTypeCd == 0) || (extraConditionTypeCd == 2))
                            result = title + "�F "+ start;
                        else
                            result = String.Format(title + "�F {0} �` {1}", start, end);
                    }
                }
			}
			return result;
        }
        #endregion

        #region ���o�͈͕�����쐬(���l�[������)
        //2007.12.12 ADD ----START
        /// <summary>
        /// ���o�͈͕�����쐬(���l�[������)
        /// </summary>
        /// <returns>�쐬������</returns>
        private string GetConditionStr_NumericRangeZeroPad(string title, Int64 startInt, Int64 endInt, int inputCharCnt, int extraConditionTypeCd)
        {
            string start = string.Empty;
            string end = string.Empty;
            double maxValue = 0;
            // �ő�l���擾
            maxValue = (Math.Pow(10, inputCharCnt) - 1);


            if (startInt != 0)
                start = TStrUtils.PadZeroLeft(startInt.ToString(), inputCharCnt);
            if ((endInt != 0) && (endInt != maxValue))
                end = TStrUtils.PadZeroLeft(endInt.ToString(), inputCharCnt);

            string rengeStr = GetConditionStr_StringRange(title, start, end, extraConditionTypeCd);
            if (rengeStr != "")
                return (rengeStr);
            else
                return string.Empty;
        }
        //2007.12.12 ADD ----END
        #endregion

        #region ���o�͈͕�����쐬(���l)
        /// <summary>
		/// ���o�͈͕�����쐬(���l)
		/// </summary>
		/// <returns>�쐬������</returns>
        private string GetConditionStr_NumericRange(string title, Int64 startInt, Int64 endInt, int inputCharCnt, int extraConditionTypeCd)
		{
            string rengeStr = EditCodeRange(startInt, endInt, inputCharCnt, extraConditionTypeCd);
            if (rengeStr != "")
                return (title + "�F " + rengeStr);
            else
                return string.Empty;
        }
        #endregion

        #region ���o�͈͕�����쐬(���t)
        /// <summary>
		/// ���o�͈͕�����쐬(���t)
		/// </summary>
		/// <returns>�쐬������</returns>
        private string GetConditionStr_DateRange(string title, DateTime startDateTime, DateTime endDateTime, int extraConditionTypeCd)
		{
            string result = "";
            int status;
            // �Ώۊ���
            int yy = 0;
            int mm = 0;
            int dd = 0;
            string strGengo = "";

            if ((startDateTime == DateTime.MinValue) && (endDateTime == DateTime.MinValue))
                return result;
            
            //�J�n�Ώ۔N����
            if (startDateTime == DateTime.MinValue)
            {
                result = title + "�F �s�n�o";
            }
            else
            {
                status = TDateTime.SplitDate("GGYYMMDD", startDateTime,
                    ref strGengo,
                    ref yy,
                    ref mm,
                    ref dd);
                if (status == 0)
                {
                    result = String.Format(title + "�F {0}{1,2}�N{2,2}��{3,2}��", strGengo, yy, mm, dd);
                }
            }

            //�����^�C�v����v�A����v�̎��̓X�^�[�g�����̂�
            if ((extraConditionTypeCd == 0) || (extraConditionTypeCd == 5))
                return result;

            //�I���Ώ۔N����
            if (endDateTime == DateTime.MinValue)
            {
                result += " �` �d�m�c";
            }
            else
            {
                status = TDateTime.SplitDate("GGYYMMDD", endDateTime,
                    ref strGengo,
                    ref yy,
                    ref mm,
                    ref dd);
                if (status == 0)
                {
                    result += String.Format(" �` {0}{1,2}�N{2,2}��{3,2}��", strGengo, yy, mm, dd);
                }
            }
			return result;
        }
        #endregion

        #region ���o������쐬(�`�F�b�N�{�b�N�X)
        /// <summary>
		/// ���o�͈͕�����쐬(�`�F�b�N�{�b�N�X)
		/// </summary>
		/// <returns>�쐬������</returns>
        private string GetConditionStr_CheckBoxChecked(FrePprECnd frePprECnd, List<FrePExCndD> frePExCndDLs)
        {
            StringBuilder result = new StringBuilder();
            Boolean dotFlg = false;        // '�E'�ǉ��̃t���O(true:�ǉ��K�v)
            int selectCnt = 0;             // �`�F�b�N����Ă��錏��
            int detailCnt = 0;             // �L���Ȗ��ׂ̐�

            detailCnt = (frePExCndDLs.FindAll(delegate(FrePExCndD frePExCndD)
                        {
                            if ((frePExCndD.ExtraCondDetailCode != -1) && (frePExCndD.ExtraCondDetailGrpCd == frePprECnd.ExtraCondDetailGrpCd))
                            { return true; }
                            else
                            {
                                return false;
                            }
                         })).Count;

            AppendCheckedTitle(frePprECnd.ExtraCondDetailGrpCd, frePprECnd.CheckItemCode1, frePExCndDLs, ref result, ref dotFlg, ref selectCnt);
            AppendCheckedTitle(frePprECnd.ExtraCondDetailGrpCd, frePprECnd.CheckItemCode2, frePExCndDLs, ref result, ref dotFlg, ref selectCnt);
            AppendCheckedTitle(frePprECnd.ExtraCondDetailGrpCd, frePprECnd.CheckItemCode3, frePExCndDLs, ref result, ref dotFlg, ref selectCnt);
            AppendCheckedTitle(frePprECnd.ExtraCondDetailGrpCd, frePprECnd.CheckItemCode4, frePExCndDLs, ref result, ref dotFlg, ref selectCnt);
            AppendCheckedTitle(frePprECnd.ExtraCondDetailGrpCd, frePprECnd.CheckItemCode5, frePExCndDLs, ref result, ref dotFlg, ref selectCnt);
            AppendCheckedTitle(frePprECnd.ExtraCondDetailGrpCd, frePprECnd.CheckItemCode6, frePExCndDLs, ref result, ref dotFlg, ref selectCnt);
            AppendCheckedTitle(frePprECnd.ExtraCondDetailGrpCd, frePprECnd.CheckItemCode7, frePExCndDLs, ref result, ref dotFlg, ref selectCnt);
            AppendCheckedTitle(frePprECnd.ExtraCondDetailGrpCd, frePprECnd.CheckItemCode8, frePExCndDLs, ref result, ref dotFlg, ref selectCnt);
            AppendCheckedTitle(frePprECnd.ExtraCondDetailGrpCd, frePprECnd.CheckItemCode9, frePExCndDLs, ref result, ref dotFlg, ref selectCnt);
            AppendCheckedTitle(frePprECnd.ExtraCondDetailGrpCd, frePprECnd.CheckItemCode10, frePExCndDLs, ref result, ref dotFlg, ref selectCnt);

            //�L���Ȗ��א��ƃ`�F�b�N���������Ƃ��͑S�����o�Ȃ̂ň󎚂��Ȃ�
            if ((result.Length != 0) && (detailCnt != selectCnt))
                return frePprECnd.ExtraConditionTitle + "�F " + result.ToString();
            else
                return string.Empty;
        }

        /// <summary>
        /// ���o�������׎擾
        /// </summary>
        /// <param name="groupCd"></param>
        /// <param name="checkItemCode"></param>
        /// <param name="frePExCndDLs"></param>
        /// <param name="sb"></param>
        /// <param name="dotFlg"></param>
        /// <param name="selectCnt"></param>
        private void AppendCheckedTitle(int groupCd, int checkItemCode, List<FrePExCndD> frePExCndDLs, ref StringBuilder sb, ref bool dotFlg, ref int selectCnt)
        {
            if (checkItemCode == -1)
            {
                return;
            }

            string title = string.Empty;
            title = GetDtlTitle(groupCd, checkItemCode, frePExCndDLs);
            if (title != string.Empty)
            {
                selectCnt++;
                if (dotFlg)
                {
                    sb.Append("�");
                }
                sb.Append(title);
                dotFlg = true;
            }
        }
        #endregion

        #region ���o����������ҏW
        /// <summary>
        /// ���o����������ҏW(�R�[�h�͈̔�)
        /// </summary>
        private string EditCodeRange(Int64 startCd, Int64 endCd, int inputCharCnt, int extraConditionTypeCd)
        {
            string startValue = string.Empty;
            string endValue = string.Empty;
            double maxValue = 0;
            // �ő�l���擾
            maxValue = (Math.Pow(10, inputCharCnt) - 1);

            if (startCd == 0)
                startValue = "�s�n�o";
            else
                startValue = startCd.ToString();

            if ((endCd == 0) || (endCd == maxValue))
                endValue = "�d�m�c";
            else
                endValue = endCd.ToString();

            if (startCd != 0 || endCd != 0)
            {
                //�����^�C�v����v�̂Ƃ��̓X�^�[�g�̂�
                if (extraConditionTypeCd == 0)
                    return startValue.ToString();
                else
                    return String.Format("{0} �` {1}", startValue, endValue);
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// ���R���[���o�������ׂ���w�肳�ꂽ�R�[�h�̖��̂��擾���܂�
        /// </summary>
        /// <param name="groupCd">���o�����O���[�v�R�[�h</param>
        /// <param name="detailCd">���o�������׃R�[�h</param>
        /// <param name="frePExCndDLs"></param>
        /// <returns></returns>
        private string GetDtlTitle(int groupCd, int detailCd, List<FrePExCndD> frePExCndDLs)
        {
            string result = string.Empty;
            if (frePExCndDLs != null)
            {
                FrePExCndD exCndD = null;
                exCndD = frePExCndDLs.Find(delegate(FrePExCndD frePExCndD)
                         {
                             if ((frePExCndD.ExtraCondDetailCode == detailCd) && (frePExCndD.ExtraCondDetailGrpCd == groupCd))
                                 return true;
                             else
                                 return false;
                         });

                if (exCndD != null)
                    result = exCndD.ExtraCondDetailName;
            }
            return result;
        }
        #endregion

        #region ���o�����N���X��DateTime���o
        /// <summary>
        /// ���o�����N���X����DateTime�𐶐����܂�
        /// </summary>
        /// <param name="frePprECnd">���R���[���o����</param>
        /// <param name="startDateTime">�J�n���t</param>
        /// <param name="endDateTime">�I�����t</param>
        /// <returns>�X�e�[�^�X�F ����:0</returns>
        private int FrePprEcndToDateTime(FrePprECnd frePprECnd, ref DateTime startDateTime, ref DateTime endDateTime)
        {
            //�����敪�����t�łȂ���ΏI��
            if (frePprECnd.ExtraConditionDivCd != CT_EXTCNDDIV_DATE)
            {
                return -1;
            }
           
            try
            {
                // �J�n���t
                startDateTime = TDateTime.LongDateToDateTime(frePprECnd.StartExtraDate);
                // �I�����t
                endDateTime = TDateTime.LongDateToDateTime(frePprECnd.EndExtraDate);
                return 0;
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region ���[�o�͐ݒ�Ǎ�
        /// <summary>
        /// ���[�o�͐ݒ�Ǎ�
        /// </summary>
        /// <param name="prtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        private int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            prtOutSet = null;
            message = "";
            PrtOutSetAcs prtOutSetAcs = new PrtOutSetAcs();
            string mySectionCode = "";

            try
            {
                // ���O�C�����_�擾
                Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
                if (loginEmployee != null)
                {
                    mySectionCode = loginEmployee.BelongSectionCode;
                }

                status = prtOutSetAcs.Read(out prtOutSet, LoginInfoAcquisition.EnterpriseCode, mySectionCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        prtOutSet = new PrtOutSet();
                        break;
                    default:
                        prtOutSet = new PrtOutSet();
                        message = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂����B";
                        break;
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return status;
        }
        #endregion

        #endregion
    }
}
