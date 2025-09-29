using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ��փ}�X�^�V���֘A�\���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       :  ��փ}�X�^�V���֘A�̃A�N�Z�X�N���X�ł��B<br />
    /// <br>Programmer : 30452 ��� �r��<br />
    /// <br>Date       : 2008.10.27<br />
    /// <br>Update Note: 2008.12.09 30452 ��� �r��</br>
    /// <br>            �E��֐挟���Ń��[�v����ꍇ�̑Ή���ǉ�</br>
    /// </remarks>
    public class PartsSubstUSearchAcs
    {
        #region ��public�萔
        public const string COL_ORDER_TITLE = "�\������";
        public const string COL_CHGSRCGOODSNO_TITLE = "��֌��i��";
        public const string COL_CHGDESTGOODSNO_TITLE = "��֐�i��";
        public const string COL_MAKERCODE_TITLE = "���[�J�[";
        public const string COL_WAREHOUSECODE_TITLE = "�q��";
        public const string COL_WAREHOUSESHELF_TITLE = "�q�ɒI��";
        public const string COL_DUPLICATIONSHELF1_TITLE = "�d���I1";
        public const string COL_DUPLICATIONSHELF2_TITLE = "�d���I2";
        public const string COL_SHIPMENTPOSCNT_TITLE = "���݌ɐ�";

        public const string TABLE_DESTPARTSSUBST = "DestPartsSubstTable";
        public const string TABLE_SRCPARTSSUBST = "SrcPartsSubstTable";

        #endregion 

        #region ���R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PartsSubstUSearchAcs()
        {
        }
        #endregion

        #region ��public���\�b�h
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="inParam"></param>
        /// <param name="outParam"></param>
        /// <param name="resultDataTable"></param>
        /// <returns></returns>
        public int Search(ArrayList inParam, ref ArrayList outParam, ref DataTable resultDataTable)
        {
            int status = 0;

            PartsSubstUSearchParamWork partsSubstUSearchParamWork = new PartsSubstUSearchParamWork();

            // �����[�g���o�����ݒ�
            partsSubstUSearchParamWork.EnterpriseCode = inParam[0].ToString();
            partsSubstUSearchParamWork.SearchDiv = (Int32)inParam[1];
            partsSubstUSearchParamWork.SectionCode = inParam[2].ToString();
            partsSubstUSearchParamWork.ChgSrcMakerCd = (Int32)inParam[3];
            partsSubstUSearchParamWork.ChgSrcGoodsNo = inParam[4].ToString();

            // ��������object
            object retObj;

            //�����������s
            IPartsSubstDspDB partsSubstDspDB = (IPartsSubstDspDB)MediationPartsSubstDspDB.GetPartsSubstDspDB();
            status = partsSubstDspDB.Search(out retObj, partsSubstUSearchParamWork);

            // �e�X�g�p
            //status = testProc(out retObj);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (((ArrayList)retObj).Count != 0)
                {
                    // �������ʓW�J
                    this.AddRowFromPartsSubstDspDB(retObj, ref outParam, ref resultDataTable, inParam);
                }
                else
                {
                    // 0���̏ꍇ�ANotFound�G���[�Ɠ����ɂ���
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }          

            return status;
        }
        #endregion

        #region ��private���\�b�h
        /// <summary>
        /// �������ʓW�J����
        /// </summary>
        /// <param name="retObj">�����[�g���o����Object</param>
        /// <param name="resultDataSet">���ʕێ��pDataSet</param>
        /// <param name="srcGoodsNo">���o�����̕i��</param>
        private void AddRowFromPartsSubstDspDB(object retObj, ref ArrayList outParam, ref DataTable resultDataTable, ArrayList inParam)
        {
            DataRow row;
            string goodsNo = inParam[4].ToString();
            int searchDiv= (Int32)inParam[1];


            foreach (PartsSubstUSearchResultWork partsSubstUSearchResultWork in (ArrayList)retObj)
            {
                // �O���b�h�\������e�[�u�������擾
                row = resultDataTable.NewRow();

                if (searchDiv == 0)
                {
                    // ��֐�̏ꍇ
                    row[COL_CHGSRCGOODSNO_TITLE] = partsSubstUSearchResultWork.ChgSrcGoodsNo;
                    row[COL_CHGDESTGOODSNO_TITLE] = partsSubstUSearchResultWork.ChgDestGoodsNo;
                    row[COL_MAKERCODE_TITLE] = partsSubstUSearchResultWork.ChgDestMakerCd;
                    if (partsSubstUSearchResultWork.ChgDestWarehouseCode == string.Empty) row[COL_WAREHOUSECODE_TITLE] = string.Empty;
                    else row[COL_WAREHOUSECODE_TITLE] = partsSubstUSearchResultWork.ChgDestWarehouseCode.TrimEnd().PadLeft(4, '0');
                    row[COL_WAREHOUSESHELF_TITLE] = partsSubstUSearchResultWork.ChgDestWarehouseShelfNo;
                    row[COL_DUPLICATIONSHELF1_TITLE] = partsSubstUSearchResultWork.ChgDestDuplicationShelfNo1;
                    row[COL_DUPLICATIONSHELF2_TITLE] = partsSubstUSearchResultWork.ChgDestDuplicationShelfNo2;
                    row[COL_SHIPMENTPOSCNT_TITLE] = partsSubstUSearchResultWork.ChgDestShipmentPosCnt;
                }
                else
                {
                    // ��֌��̏ꍇ
                    row[COL_CHGSRCGOODSNO_TITLE] = partsSubstUSearchResultWork.ChgSrcGoodsNo;
                    row[COL_MAKERCODE_TITLE] = partsSubstUSearchResultWork.ChgSrcMakerCd;
                    if (partsSubstUSearchResultWork.ChgSrcWarehouseCode == string.Empty) row[COL_WAREHOUSECODE_TITLE] = string.Empty;
                    else row[COL_WAREHOUSECODE_TITLE] = partsSubstUSearchResultWork.ChgSrcWarehouseCode.TrimEnd().PadLeft(4, '0');
                    row[COL_WAREHOUSESHELF_TITLE] = partsSubstUSearchResultWork.ChgSrcWarehouseShelfNo;
                    row[COL_DUPLICATIONSHELF1_TITLE] = partsSubstUSearchResultWork.ChgSrcDuplicationShelfNo1;
                    row[COL_DUPLICATIONSHELF2_TITLE] = partsSubstUSearchResultWork.ChgSrcDuplicationShelfNo2;
                    row[COL_SHIPMENTPOSCNT_TITLE] = partsSubstUSearchResultWork.ChgSrcShipmentPosCnt;
                }

                resultDataTable.Rows.Add(row);
            }

            // �\�[�g�����i��֐�̏��ʕt�܂ށj
            if (searchDiv == 0)
            {
                // ��֐�
                string tmpGoodsNo = goodsNo;
                DataRow[] dr;
                DataTable newTable = resultDataTable.Copy();
                resultDataTable.Rows.Clear();
                // ���[�v�`�F�b�N�p
                List<string> loopCheckGoodsNoList = new List<string>(); // ADD 2008/12/12

                // ��֌��i�ԁˑ�֐�i�ԂƂȂ�悤��Select(10�s�܂�)
                for (int i = 0; i < newTable.Rows.Count && i < 10; i++)
                {
                    // �K��1���Y��
                    dr = newTable.Select(COL_CHGSRCGOODSNO_TITLE + " = '" + tmpGoodsNo + "'");

                    // --- ADD 2008/12/12 -------------------------------->>>>>
                    if (loopCheckGoodsNoList.Contains(dr[0][COL_CHGDESTGOODSNO_TITLE].ToString()))
                    {
                        // ������i�Ԃ������̌������i�Ԃɑ��݂���(���[�v����)�ꍇ
                        break;
                    }
                    // --- ADD 2008/12/12 --------------------------------<<<<<
                    
                    // ���ʐݒ�
                    dr[0][COL_ORDER_TITLE] = i + 1;
                    resultDataTable.ImportRow(dr[0]);

                    // �������i�Ԃ�ۑ�
                    loopCheckGoodsNoList.Add(tmpGoodsNo);

                    // ���̌��i�Ԃ�ݒ�
                    tmpGoodsNo = dr[0][COL_CHGDESTGOODSNO_TITLE].ToString();
                }
            }
            else
            {
                // ��֌�
                DataRow[] dr;
                DataTable newTable = resultDataTable.Copy();
                resultDataTable.Rows.Clear();
                
                // ���[�J�[�A�i�ԏ��Ƀ\�[�g
                dr = newTable.Select("", COL_MAKERCODE_TITLE + ", " + COL_CHGSRCGOODSNO_TITLE);

                // �\�[�g����10�s�܂Ŏ擾
                for (int i = 0; i < dr.Length && i < 10; i++ )
                {
                    resultDataTable.ImportRow(dr[i]);
                }
            }

            // �擾���f�[�^�̎擾
            PartsSubstUSearchResultWork work = (PartsSubstUSearchResultWork)((ArrayList)retObj)[0];

            if (searchDiv == 0)
            {
                // ��֐�̏ꍇ�A��֌�����ێ�
                //outParam.Add(work.ChgSrcWarehouseCode.TrimEnd().PadLeft(4, '0')); // DEL 2008/12/25
                outParam.Add(work.ChgSrcWarehouseCode.TrimEnd()); // ADD 2008/12/25
                outParam.Add(work.ChgSrcWarehouseShelfNo);
                outParam.Add(work.ChgSrcDuplicationShelfNo1);
                outParam.Add(work.ChgSrcDuplicationShelfNo2);
                outParam.Add(work.ChgSrcShipmentPosCnt);
            }
            else
            {
                // ��֌��̏ꍇ�A��֐����ێ�
                //outParam.Add(work.ChgDestWarehouseCode.TrimEnd().PadLeft(4, '0')); // DEL 2008/12/25
                outParam.Add(work.ChgDestWarehouseCode.TrimEnd()); // ADD 2008/12/25
                outParam.Add(work.ChgDestWarehouseShelfNo);
                outParam.Add(work.ChgDestDuplicationShelfNo1);
                outParam.Add(work.ChgDestDuplicationShelfNo2);
                outParam.Add(work.ChgDestShipmentPosCnt);
            }
        }

        #endregion

        #region ���e�X�g�p
        private int testProc(out object retObj)
        {
            ArrayList paramlist = new ArrayList();

            PartsSubstUSearchResultWork param1 = new PartsSubstUSearchResultWork();

            param1.EnterpriseCode = "1234567890123456";
            param1.ChgSrcMakerCd = 1234;
            param1.ChgSrcGoodsNo = "123456789012345678901234";
            // �n�C�t�����i�Ԃ͎g�p���Ȃ�
            param1.ChgSrcWarehouseCode = "8888";
            param1.ChgSrcWarehouseShelfNo = "12345678";
            param1.ChgSrcDuplicationShelfNo1 = "12345678";
            param1.ChgSrcDuplicationShelfNo2 = "12345678";
            param1.ChgSrcShipmentPosCnt = 200000;

            param1.ChgDestMakerCd = 4321;
            param1.ChgDestGoodsNo = "432109876543210987654321";
            // �n�C�t�����i�Ԃ͎g�p���Ȃ�
            param1.ChgDestWarehouseCode = "7777";
            param1.ChgDestWarehouseShelfNo = "87654321";
            param1.ChgDestDuplicationShelfNo1 = "87654321";
            param1.ChgDestDuplicationShelfNo2 = "87654321";
            param1.ChgDestShipmentPosCnt = 3000.1;

            paramlist.Add(param1);

            retObj = paramlist;

            return 0;
        }

        #endregion
    }
}
