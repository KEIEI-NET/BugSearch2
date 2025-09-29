using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// �󎚃f�[�^�쐬�⏕�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �󎚃f�[�^�쐬�⏕���\�b�h�������N���X�ł��B</br>
    /// <br>Programmer	: 22011 ���� ���l</br>
    /// <br>Date		: 2007.08.17</br>
    /// <br>UpdateNote	: </br>
    /// </remarks>
    public class SFANL08235CG
    {
        #region public methods

        #region �f�[�^���̓V�X�e������
        /// <summary>
        /// �f�[�^���̓V�X�e���R�[�h����f�[�^���̓V�X�e�����̂�Ԃ��܂�
        /// </summary>
        /// <param name="dataInputSystem">�f�[�^���̓V�X�e���R�[�h</param>
        /// <returns>�f�[�^���̓V�X�e������</returns>
        public string GetDataInputSystemName(int dataInputSystem)
        {
            switch (dataInputSystem)
            {
                case 0: { return "����"; }
                case 1: { return "����"; }
                case 2: { return "���"; }
                case 3: { return "�Ԕ�"; }
                default : return "����";
            }
        }
        #endregion

        #region �l�E�@�l�敪���̎擾�֐�
        /// <summary>
        /// �l�E�@�l�敪���̎擾�֐�
        /// </summary>
        /// <param name="corpporateDivCode">�@�l�敪�R�[�h</param>
        /// <returns>�l�E�@�l�敪����</returns>
        public string GetCorpporateDivName(int corpporateDivCode)
        {
            string corpporateDivName = "";

            switch (corpporateDivCode)
            {
                case 1:
                    corpporateDivName = "�@�l";
                    break;
                case 2:
                    corpporateDivName = "����@�l";
                    break;
                case 3:
                    corpporateDivName = "�Ǝ�";
                    break;
                case 4:
                    corpporateDivName = "�Ј�";
                    break;
                case 5:
                    corpporateDivName = "�`�`";
                    break;
                default:
                    corpporateDivName = "�l";
                    break;
            }
            return corpporateDivName;
        }
        #endregion

        //#region �o�͗p�o�^�ԍ��쐬�֐�
        ///// <summary>
        ///// �o�͗p�o�^�ԍ��쐬�֐�
        ///// </summary>
        ///// <param name="carMngNo"></param>
        ///// <param name="numberplate1name"></param>
        ///// <param name="numberplate2"></param>
        ///// <param name="numberplate3"></param>
        ///// <param name="numberplate4"></param>
        ///// <returns>�o�͗p�o�^�ԍ�</returns>
        //public string MakeNumberPlate(int carMngNo, string numberplate1name, string numberplate2, string numberplate3, int numberplate4)
        //{
        //    string numberPlate = CarInfoCalculation.GetNumberPlateString(carMngNo, 0, numberplate1name, numberplate2, numberplate3, numberplate4);
        //    return numberPlate;
        //}
        //#endregion

        #region �a��ϊ�����(DataTime -> ����XX�NXX��XX��)
        /// <summary>
        /// �a��ϊ�����(DataTime -> ����XX�NXX��XX��)
        /// </summary>
        /// <param name="dt">�ϊ���DateTime</param>
        /// <returns>�a�����</returns>
        public string DateTimeToJpFormal(DateTime dt)
        {
            string dateTimes = TDateTime.DateTimeToString("GGyymmdd", dt);
            return dateTimes;
        }
        #endregion]

        #region �󒍃X�e�[�^�X�擾
        /// <summary>
        /// �󒍃X�e�[�^�X�擾
        /// </summary>
        /// <param name="AcptAnOdrStatusCd">�󒍃X�e�[�^�X</param>
        /// <returns>�󒍃X�e�[�^�X����</returns>
        public string GetAcptAnOdrStatusName(int AcptAnOdrStatusCd)
        {
            switch (AcptAnOdrStatusCd)
            {
                case 10 : return "����";
                case 20 : return "�w��";
                case 30 : return "�[�i";
                default: return "";
            }
        }
        #endregion

        #region �Ԍ���ʋ敪���̎擾
        /// <summary>
        /// �Ԍ���ʋ敪���̂��擾���܂�
        /// </summary>
        /// <param name="carInspectOrGeCd">�Ԍ���ʋ敪�R�[�h(0:���,1:�Ԍ�,2:�@��)</param>
        /// <returns>�Ԍ���ʋ敪����</returns>
        public string GetCarInspectOrGeNm(int carInspectOrGeCd)
        {
            switch (carInspectOrGeCd)
            {
                case 0: return "���";
                case 1: return "�Ԍ�";
                case 2: return "�@��";
                default: return "";
            }
        }
        #endregion

        #region �[�����C�X�e�[�^�X����
        /// <summary>
        /// �[�����C�X�e�[�^�X���̂�Ԃ��܂��B
        /// </summary>
        /// <param name="carDeliRepairStatus">�[�����C�X�e�[�^�X</param>
        /// <returns>�[�����C�X�e�[�^�X����</returns>
        public string GetCarDeliRepairStatusName(int carDeliRepairStatus)
        {
            switch (carDeliRepairStatus)
            {
                //0:����,10:����,20:��,30:���Z
                case 10: return "����";
                case 20: return "��";
                case 30: return "���Z";
                default: return "";
            }
        }
        #endregion

        #region �݌ɉ��C�敪����
        /// <summary>
        /// �݌ɉ��C�敪���̂�Ԃ��܂��B
        /// </summary>
        /// <param name="stockRepairCd">�݌ɉ��C�敪</param>
        /// <returns>�݌ɉ��C�敪����</returns>
        public string GetStockRepairCdName(int stockRepairCd)
        {
            switch (stockRepairCd)
            {
                //0:�ʏ�,1:�݌ɉ��C
                case 0: return "�ʏ�";
                case 1: return "�݌ɉ��C";
                default: return "";
            }
        }
        #endregion

        #region �֘A��Ћ敪����
        /// <summary>
        /// �֘A��Ћ敪���̂�Ԃ��܂��B
        /// </summary>
        /// <param name="relevanceCompanyCd">�֘A��Ћ敪</param>
        /// <returns>�֘A��Ћ敪����</returns>
        public string GetRelevanceCompanyCdName(int relevanceCompanyCd)
        {
            switch (relevanceCompanyCd)
            {
                //0:�ϑ���,1:�֘A���
                case 0: return "�ϑ���";
                case 1: return "�֘A���";
                default: return "";
            }
        }
        #endregion

        #region �ϑ������敪����
        /// <summary>
        /// �ϑ������敪���̂�Ԃ��܂��B
        /// </summary>
        /// <param name="entrustOrderCd">�ϑ������敪</param>
        /// <returns>�ϑ������敪����</returns>
        public string GetEntrustOrderCdName(int entrustOrderCd)
        {
            switch (entrustOrderCd)
            {
                //0:������,1:������,2:�d����
                case 0: return "������";
                case 1: return "������";
                case 2: return "�d����";
                default: return "";
            }
        }
        #endregion

        #region �O�������敪����
        /// <summary>
        /// �O�������敪���̂�Ԃ��܂��B
        /// </summary>
        /// <param name="oSrcOrderDivCd">�O�������敪</param>
        /// <returns>�O�������敪����</returns>
        public string GetOSrcOrderDivCdName(int oSrcOrderDivCd)
        {
            switch (oSrcOrderDivCd)
            {
                //0:������,1:������,2:�d����
                case 0: return "������";
                case 1: return "������";
                case 2: return "�d����";
                default: return "";
            }
        }
        #endregion

        #region �ԓ`�敪����
        /// <summary>
        /// �ԓ`�敪���̂�Ԃ��܂��B
        /// </summary>
        /// <param name="debitNoteDiv">�ԓ`�敪</param>
        /// <returns>�ԓ`�敪����</returns>
        public string GetDebitNoteDivName(int debitNoteDiv)
        {
            switch (debitNoteDiv)
            {
                //0:���`,1:�ԓ`
                case 0: return "���`";
                case 1: return "�ԓ`";
                default: return "";
            }
        }
        #endregion


        #region �����ԋ敪����
        /// <summary>
        /// �����ԋ敪�����̂�Ԃ��܂��B
        /// </summary>
        /// <param name="customizeCode">�����ԋ敪</param>
        /// <returns>�����ԋ敪����</returns>
        public string GetCustomizeCodeName(int customizeCode)
        {
           if(customizeCode == 1)
           {
               return "��";
           }
           else
           {
               return string.Empty;
           }
        }
        #endregion

        #region ����͋敪����
        /// <summary>
        /// ����͋敪���̂�Ԃ��܂��B
        /// </summary>
        /// <param name="inputDivCd">����͋敪</param>
        /// <returns>����͋敪����</returns>
        public string GetInputDivCdName(int inputDivCd)
        {
            switch (inputDivCd)
            {
                //0:�ڋq�ԗ��L��,1:�����
                case 0: return "�ڋq�ԗ��L��";
                case 1: return "�����";
                default: return "";
            }
        }
        #endregion

        #region ����n���i���o�敪����
        /// <summary>
        /// ����n���i���o�敪���̂�Ԃ��܂��B
        /// </summary>
        /// <param name="cldDstrctPrtsExtraCd">����n���i���o�敪</param>
        /// <returns>����n���i���o�敪����</returns>
        public string GetCldDstrctPrtsExtraCddName(int cldDstrctPrtsExtraCd)
        {
            switch (cldDstrctPrtsExtraCd)
            {
                //0:����n���i���o����,1:����n���i���o���Ȃ�
                case 0: return "����n���i���o����";
                case 1: return "����n���i���o���Ȃ�";
                default: return "";
            }
        }
        #endregion

        #region ���Ƌ敪����
        /// <summary>
        /// ����n���i���o�敪���̂�Ԃ��܂��B
        /// </summary>
        /// <param name="mainWorkDivCode">���Ƌ敪</param>
        /// <returns>���Ƌ敪����</returns>
        public string GetMainWorkDivName(int mainWorkDivCode)
        {
            switch (mainWorkDivCode)
            {
                //0:��ʋ敪,100:�Ԍ��_��,203:�@��3����,206:�@��6����,212:�@��12����,301:�V��1����,306:�V��6����,500:���,510:�y���,
                //700:�Ԕ́i���Îԁj,710:�Ԕ́i�V�ԁj,800:����, 1100:�X�P�W���[���_��, 1206:���[�X����U�����_��
                case 0: return "��ʋ敪";
                case 100: return "�Ԍ��_��";
                case 203: return "�@��3����";
                case 206: return "�@��6����";
                case 212: return "�@��12����";
                case 301: return "�V��1����";
                case 306: return "�V��6����";
                case 500: return "���";
                case 510: return "�y���";
                case 700: return "�Ԕ́i���Îԁj";
                case 710: return "�Ԕ́i�V�ԁj";
                case 800: return "����";
                case 1100: return "�X�P�W���[���_��";
                case 1206: return "���[�X����U�����_��";
                default: return "";
            }
        }
        #endregion

        #region �����Ћ敪����
        /// <summary>
        /// �����Ћ敪���̂�Ԃ��܂��B
        /// </summary>
        /// <param name="trustCompanyDivCd">�����Ћ敪</param>
        /// <returns>�����Ћ敪����</returns>
        public string GetTrustCompanyDivCdName(int trustCompanyDivCd)
        {
            switch (trustCompanyDivCd)
            {
                case 0: return "���";
                case 1: return "������";
                default: return "";
            }
        }
        #endregion

        #region ���i�d����敪
        /// <summary>
        /// ���i�d����敪���̂�Ԃ��܂��B
        /// </summary>
        /// <param name="partsSupplierDivCd">���i�d����敪</param>
        /// <returns>���i�d����敪����</returns>
        public string GetPartsSupplierDivCdName(int partsSupplierDivCd)
        {
            switch (partsSupplierDivCd)
            {
                case 0: return "���i�d����ȊO";
                case 1: return "���i�d����";
                default: return "";
            }
        }
        #endregion

        #region �ԗ��d����敪
        /// <summary>
        /// �ԗ��d����敪���̂�Ԃ��܂��B
        /// </summary>
        /// <param name="carSupplierDivCd">�ԗ��d����敪</param>
        /// <returns>�ԗ��d����敪���� </returns>
        public string GetCarSupplierDivCdName(int carSupplierDivCd)
        {
            switch (carSupplierDivCd)
            {
                case 0: return "�ԗ��d����ȊO";
                case 1: return "�ԗ��d����";
                default: return "";
            }
        }
        #endregion

        #region �O���d����敪
        /// <summary>
        /// �O���d����敪���̂�Ԃ��܂��B
        /// </summary>
        /// <param name="osrcSupplierDivCd">�O���d����敪</param>
        /// <returns>�O���d����敪���� </returns>
        public string GetOsrcSupplierDivCdName(int osrcSupplierDivCd)
        {
            switch (osrcSupplierDivCd)
            {
                case 0: return "�O���d����ȊO";
                case 1: return "�O���d����";
                default: return "";
            }
        }
        #endregion

        #region ����_��ԗ��敪
        /// <summary>
        /// ����_��ԗ��敪���̂�Ԃ��܂��B
        /// </summary>
        /// <param name="trustContCarDivCd">����_��ԗ��敪</param>
        /// <returns>����_��ԗ��敪����</returns>
        public string GetTrustContCarDivCdName(int trustContCarDivCd)
        {
            switch (trustContCarDivCd)
            {
                case 0: return "����_��O";
                case 1: return "����_��ԗ�";
                default: return "";
            }
        }
        #endregion

        #region �A�W���X�^�m�F�X�e�[�^�X
        /// <summary>
        /// �A�W���X�^�m�F�X�e�[�^�X���̂�Ԃ��܂��B
        /// </summary>
        /// <param name="adjusterConfStatus">�A�W���X�^�m�F�X�e�[�^�X</param>
        /// <returns>�A�W���X�^�m�F�X�e�[�^�X����</returns>
        public string GetAdjusterConfStatusName(int adjusterConfStatus)
        {
            switch (adjusterConfStatus)
            {
                //0:���m�F 1:�m�F�� 2:�m�F����
                case 0: return "���m�F";
                case 1: return "�m�F��";
                case 2: return "�m�F����";
                default: return "";
            }
        }
        #endregion



    #endregion
    }
}
