//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �Z�b�g�}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �Z�b�g�}�X�^�i�G�N�X�|�[�g�j���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �C �� ��  2009/06/23  �C�����e : PVCS250 �擾�̃f�[�^�s��
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �Z�b�g�}�X�^�i�G�N�X�|�[�g�j�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �Z�b�g�}�X�^�i�G�N�X�|�[�g�j�C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    public class GoodsSetExportAcs
    {
        #region �� Private Member
        private IGoodsSetDB _iGoodsSetDB ;
        private const string PRINTSET_TABLE = "GoodsSetExp";
        #endregion

        # region ��Constracter
        /// <summary>
        /// �Z�b�g�}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Z�b�g�}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X�B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public GoodsSetExportAcs()
        {
            this._iGoodsSetDB = (IGoodsSetDB)MediationGoodsSetDB.GetGoodsSetDB();
        }
        #endregion

        #region �� �Z�b�g�}�X�^��񌟍�
        /// <summary>
        /// �Z�b�g�}�X�^�f�[�^�擾����
        /// </summary>
        /// <param name="condition">��������</param>
        /// <param name="dataTable">�����f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �Z�b�g�}�X�^�f�[�^�擾�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public int Search(GoodsSetExportWork condition, out DataTable dataTable)
        {
            GoodsSetWork goodsSetWork = new GoodsSetWork();
            goodsSetWork.EnterpriseCode = condition.EnterpriseCode;

            int status = 0;
            int checkstatus = 0;
            dataTable = new DataTable(PRINTSET_TABLE);
            // DataTable��Columns��ǉ�����
            CreateDataTable(ref dataTable);

            ArrayList paraList = new ArrayList();
            paraList.Clear();
            object paraobj = goodsSetWork;
            object retobj = paraList;
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
            // ����
            status = this._iGoodsSetDB.Search(out retobj, paraobj, 0, logicalMode);

            paraList = (ArrayList)retobj;
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (GoodsSetWork goodsSetWorkdata in paraList)
                {
                    // ���o����
                    checkstatus = DataCheck(goodsSetWorkdata, condition);
                    if (checkstatus == 0)
                    {
                        //�Z�b�g���N���X�փ����o�R�s�[
                        ConverToDataSetCustomerInf(goodsSetWorkdata, ref dataTable);
                    }
                }
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            return status;
        }
        #endregion

        #region �� Private Methods
                /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("ParentGoodsNoRF", typeof(string));               //  �e���i�ԍ�
            dataTable.Columns.Add("ParentGoodsMakerCdRF", typeof(string));           //  �e���[�J�[�R�[�h
            dataTable.Columns.Add("DisplayOrderRF", typeof(string));                 //  �\������
            dataTable.Columns.Add("SubGoodsNoRF", typeof(string));                  //  �q���i�ԍ�			
            dataTable.Columns.Add("SubGoodsMakerCdRF", typeof(string));              //  �q���i���[�J�[�R�[�h
            dataTable.Columns.Add("CntFlRF", typeof(string));                       //  ���ʁi�����j
            dataTable.Columns.Add("SetSpecialNoteRF", typeof(string));              //  �Z�b�g�K�i�E���L����	
        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="condition">��������</param>
        /// <param name="goodsSetWorkdata">���i�f�[�^</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���o�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private int DataCheck(GoodsSetWork goodsSetWorkdata,GoodsSetExportWork condition)
        {
            int status = 0;
            if (!String.IsNullOrEmpty(condition.GoodsNoSt.Trim()) && !String.IsNullOrEmpty(goodsSetWorkdata.ParentGoodsNo.Trim())
                && condition.GoodsNoSt.Trim().CompareTo(goodsSetWorkdata.ParentGoodsNo.Trim()) == 1)
            {
                status = -1;
                return status;
            }

            if (!String.IsNullOrEmpty(condition.GoodsNoEd.Trim()) && !String.IsNullOrEmpty(goodsSetWorkdata.ParentGoodsNo.Trim())
                && condition.GoodsNoEd.Trim().CompareTo(goodsSetWorkdata.ParentGoodsNo.Trim()) == -1)
            {
                status = -1;
                return status;
            }
            // MODIFY 2009/06/23 --->>>
            // �擾�̃f�[�^�s��
            //if (condition.GoodsMakerCdSt != 0 && goodsSetWorkdata.SubGoodsMakerCd < condition.GoodsMakerCdSt)
            if (condition.GoodsMakerCdSt != 0 && goodsSetWorkdata.ParentGoodsMakerCd < condition.GoodsMakerCdSt)
            // MODIFY 2009/06/23 ---<<<
            {
                status = -1;
                return status;
            }
            // MODIFY 2009/06/23 --->>>
            // �擾�̃f�[�^�s��
            //if (condition.GoodsMakerCdEd != 0 && goodsSetWorkdata.SubGoodsMakerCd > condition.GoodsMakerCdEd)
            if (condition.GoodsMakerCdEd != 0 && goodsSetWorkdata.ParentGoodsMakerCd > condition.GoodsMakerCdEd)
            // MODIFY 2009/06/23 ---<<<
            {
                status = -1;
                return status;
            }

            return status;

        }


        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="goodsSetWorkdata">��������</param>
        /// <param name="dataTable">����</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void ConverToDataSetCustomerInf(GoodsSetWork goodsSetWorkdata, ref DataTable dataTable)
        {
            DataRow dataRow = dataTable.NewRow();
            dataRow["ParentGoodsNoRF"] = GetSubString(goodsSetWorkdata.ParentGoodsNo,24);
            dataRow["ParentGoodsMakerCdRF"] = AppendZero(goodsSetWorkdata.ParentGoodsMakerCd.ToString(),4);
            dataRow["DisplayOrderRF"] = GetSubString(goodsSetWorkdata.DisplayOrder.ToString(),4);
            dataRow["SubGoodsNoRF"] = GetSubString(goodsSetWorkdata.SubGoodsNo,24);
            dataRow["SubGoodsMakerCdRF"] = AppendZero(goodsSetWorkdata.SubGoodsMakerCd.ToString(),4);
            dataRow["CntFlRF"] = goodsSetWorkdata.CntFl.ToString("##0.00");
            dataRow["SetSpecialNoteRF"] = GetSubString(goodsSetWorkdata.SetSpecialNote,40);
            
            dataTable.Rows.Add(dataRow);
        }


        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">��</param>
        /// <remarks>
        /// <br>Note       : AppendZero�s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendZero(string bfString, int maxSize)
        {
            bfString = bfString.Trim();

            StringBuilder tempBuild = new StringBuilder();
            if (bfString != "0")
            {
                if (!String.IsNullOrEmpty(bfString.Trim()) && !bfString.Trim().Equals("0"))
                {
                    for (int i = bfString.Length; i < maxSize; i++)
                    {
                        tempBuild.Append("0");
                    }
                    tempBuild.Append(bfString);
                }
            }
            else
            {
                tempBuild.Append("0");
            }
            return tempBuild.ToString().Trim();
        }

        /// <summary>
        /// GetSubString
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="length">��</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataSet�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string GetSubString(string bfString, int length)
        {
            string afString = "";
            if (bfString.Length > length)
            {
                afString = bfString.Substring(0, length);
            }
            else
            {
                afString = bfString;
            }
            return afString.Trim();
        }
        #endregion
    }
}
