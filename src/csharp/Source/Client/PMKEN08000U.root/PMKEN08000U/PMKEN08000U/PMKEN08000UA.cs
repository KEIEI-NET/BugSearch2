using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Data;
using System.Diagnostics;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    ///	���i�I��UI����N���X
    /// </summary>
    /// <remarks>
    /// <br>note			:	���i�I���t���[�̐�����s���A���ꂼ��̕��i�I��UI��\�����܂�</br>
    /// <br>Programer		:	30290</br>
    /// <br>Date			:	2008.07.03</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note	    : �t�h�̃p�����[�^�ɃI�[�i�[�t�H�[����ǉ��i�R�����g����)</br>
    /// <br>Programmer	    : 21024�@���X�� ��</br>
    /// <br>Date		    : 2009.02.19</br>
    /// <br></br>
    /// <br>Update Note     : 2009/10/20 �����</br>
    /// <br>                PM.NS-3-A�E�ێ�˗��A</br>
    /// <br>                �W�����i�I���E�C���h�E�̕\�������̒ǉ�</br>
    /// <br>Update Note     : 2009/11/13 �����</br>
    /// <br>                redmine#1268,�\���p�^�[���̏C��</br>
    /// <br>Update Note     : ����� 2009/11/16</br>
    /// <br>                : redmine#1320,�W�����i�I��\���̏C��</br>
    /// <br></br>
    /// <br>Update Note�@�@ : �������ςŁA�Z�b�g�i�����������ꍇ�ɃZ�b�g�q��񂪑I�𕔕i�Ƃ��Ė߂�l�ɂȂ�s��̏C��(MANTIS[0014660])</br>
    /// <br>Programmer      : 21024�@���X�� ��</br>
    /// <br>Date            : 2009/12/01</br>
    /// <br></br>
    /// <br>Update Note�@�@ : BL�R�[�h�������A�I�������i�Ԃ͑I�𕔕i��񂩂�擾����悤�ɏC��</br>
    /// <br>Programmer      : 21024�@���X�� ��</br>
    /// <br>Date            : 2009/12/14</br>
    /// <br></br>
    /// <br>Update Note�@�@ : PM7���[�h��BL�R�[�h�������A���i�I����̊e��E�B���h�E��ESC��������1�i�ڒP�ʂŏ�������悤�ɏC��(MANTIS[0013829])</br>
    /// <br>Programmer      : 21024�@���X�� ��</br>
    /// <br>Date            : 2009/12/16</br>
    /// <br></br>
    /// <br>Update Note�@�@ : �������ςő�֕i��I�����Ă����i�I����ʂɔ��f����Ȃ����ۂ̏C��(MANTIS[0014697])</br>
    /// <br>Programmer      : 21024�@���X�� ��</br>
    /// <br>Date            : 2009/12/18</br>
    /// <br></br>
    /// <br>Update Note�@�@ : �r�b�l�̑g�ݍ���</br>
    /// <br>                  �E���䃂�[�h�ǉ�(SCM�Ή�)</br>
    /// <br>Programmer      : 21024�@���X�� ��</br>
    /// <br>Date            : 2010/02/25</br>
    /// <br></br>
    /// <br>Update Note�@�@ : ���i�I���E�B���h�E�ɕ\������镔�i���X�g���擾�ł��郁�\�b�h��ǉ�</br>
    /// <br>Programmer      : 21024�@���X�� ��</br>
    /// <br>Date            : 2010/03/15</br>
    /// <br></br>
    /// <br>Update Note�@�@ : �D�ǂ̌��������̏ꍇ�ɂ̂݌��������������삷��悤�ɏC��</br>
    /// <br>Programmer      : 22008�@���� ���n</br>
    /// <br>Date            : 2010/04/16</br>
    /// <br></br>
    /// <br>Update Note�@�@ : ���R�����I�v�V�����Ή��@�i�a�k�R�[�h�����ˎ��R�������i�˒񋟗D�ǁ˃Z�b�g���L��ꍇ�A��ʐ���ύX���K�v�ȈבΉ��j</br>
    /// <br>Programmer      : 22018�@��� ���b</br>
    /// <br>Date            : 2010/04/28</br>
    /// <br></br>
    /// <br>Update Note�@�@ : ���ʕ�����</br>
    /// <br>                    �c�b�z�u(������) 2010/04/16 �̑g��</br>
    /// <br>                    ���R���� 2010/04/28 �̑g��</br>
    /// <br>Programmer      : 22018�@��� ���b</br>
    /// <br>Date            : 2010/06/04</br>
    /// <br></br>
    /// <br>Update Note�@�@ : ���ʕ�����</br>
    /// <br>                    �i�Ԍ�����ɔ��`���I������Ɨ�O�������錏�̑Ή�(�e��E�C���h�E�I������Dispose�ǉ�)</br>
    /// <br>Programmer      : 20056 ���n ���</br>
    /// <br>Date            : 2010/07/01</br>
    /// <br></br>
    /// <br>Update Note�@�@ : ���ʕ������Q</br>
    /// <br>                    �������ϔ��s�ŁA����i��(�I�v�V�����Ⴂ)�̏����i�̂ݑΏۂ̏ꍇ�ɁA</br>
    /// <br>                    ���i�I�����u����v�ɐݒ肵�Ă��I���t�h���\������Ȃ����̏C���B</br>
    /// <br>Programmer      : 22018�@��� ���b</br>
    /// <br>Date            : 2010/07/13</br>
    /// <br></br>
    /// <br>Update Note�@�@ : ���i�I��UI�̐�����C��</br>
    /// <br>                  �i�����i�I���Ō����̂���i�Ԃ𕡐��I�����āA�Q���ڂ̌����I����ESC��������ƂP���ڂ̌����I���ɖ߂��Ă��܂����̏C���j</br>
    /// <br>Programmer      : 22018�@��� ���b</br>
    /// <br>Date            : 2010/10/01</br>
    /// <br></br>
    /// <br>Update Note�@�@ : MANTIS:16822 �@�\�ǉ�</br>
    /// <br>                    �D�Ǖi�Ԍ����̏ꍇ�A�����������䕶�����܂܂�Ȃ��Ă��W�����i�I���������s��</br>
    /// <br>Programmer      : 20056 ���n ���</br>
    /// <br>Date            : 2010/12/14</br>
    /// <br></br>
    /// <br>Update Note�@�@ : ��Q�Ή�</br>
    /// <br>                    BL�R�[�h�������s���\���敪�}�X�^�ɊY�����Ȃ��ꍇ�A�W�����i�I�����\������Ȃ����̑Ή�</br>
    /// <br>Programmer      : 20056 ���n ���</br>
    /// <br>Date            : 2011/01/13</br>
    /// <br></br>
    /// <br>Update Note�@�@ : ��Q�Ή�</br>
    /// <br>                    "."�����i�Ԍ����ő�֐�̌������I�������ۂɃG���[�������錏�̏C��</br>
    /// <br>                    (PM.NS�͑�ւ��鎞�͕��i������\������d�l�ׁ̈A���̏ꍇ�͌�����������Ɠ����̏������K�v�ɂȂ�)</br>
    /// <br>Programmer      : 22018 ��� ���b</br>
    /// <br>Date            : 2011/01/27</br>
    /// <br></br>
    /// <br>Update Note�@�@ : ��Q�Ή�</br>
    /// <br>                    2011/01/27���̏C���B�D�Ǖi��"."�����ŕ\���敪�}�X�^�ɓo�^�Ȃ����͕\�����Ȃ��悤�C���B(���̓���)</br>
    /// <br>Programmer      : 22018 ��� ���b</br>
    /// <br>Date            : 2011/02/10</br>
    /// <br></br>
    /// <br>Update Note�@�@ : ��Q�Ή�</br>
    /// <br>                    2010/12/14���̏C���B�a�k�R�[�h�����ŗD�Ǖi��I�����̏������x�����̏C���B</br>
    /// <br>Programmer      : 22018 ��� ���b</br>
    /// <br>Date            : 2011/02/24</br>
    /// <br></br>
    /// <br>Update Note�@�@ : ��Q�Ή�</br>
    /// <br>                    2010/12/14���̏C���B�D�Ǖi�̕i�Ԍ����ŏ������x�����̏C���B(�����������͕K�v�Ȏ�������������)</br>
    /// <br>Programmer      : 22018 ��� ���b</br>
    /// <br>Date            : 2011/02/25</br>
    /// <br></br>
    /// <br>Update Note�@�@ : �D�Ǖi�� AND "."���� AND �\���敪�}�X�^��"�D��"�ɐݒ肳��Ă���ꍇ �͌������������Ȃ��悤�ύX�B</br>
    /// <br>Programmer      : 22018 ��� ���b</br>
    /// <br>Date            : 2011/05/12</br>
    /// <br></br>
    /// <br>Update Note     : 2011/11/21 ����� Redmine#7876�̑Ή�</br>
    /// <br>                  ������i�Ԃ�I��������ł͂Ȃ��̂ŕW�����i�I���E�C���h�̕\�����s��Ȃ��l�ɏC��</br>
    /// <br></br>
    /// <br>Update Note�@�@ : ��Q�Ή�</br>
    /// <br>                    �Ή�No120(#7876)�̃f�O���Ή�</br>
    /// <br>Programmer      : 20056 ���n ���</br>
    /// <br>Date            : 2011/12/16</br>
    /// <br></br>
    /// <br>Update Note     : 2012/04/06 ���N�n��</br>
    /// <br>�Ǘ��ԍ�        : 10801804-00 2012/05/24�z�M��</br>
    /// <br>                  Redmine#29153   �W�����i�I����ʂ��\������Ȃ��ɂ��Ă̏C��</br>
    /// <br>Update Note     : 2012/06/11 gezh</br>
    /// <br>�Ǘ��ԍ�        : 10801804-00</br>
    /// <br>                  Redmine#30392 ����`�[���� �W�����i�I��\���̑Ή�</br>
    /// <br>Update Note     : 2012/06/26 ������</br>
    /// <br>                  Redmine#30595 ����`�[���͕W�����i�I���K�C�h�̏C��</br>
    /// <br></br>
    /// <br>Update Note     : 2015/04/06 30757 ���X�� �M�p</br>
    /// <br>�Ǘ��ԍ�        : 11070149-00</br>
    /// <br>                  �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή�</br>
    /// <br></br>
    /// </remarks>
    public static class UIDisplayControl
    {
        /// <summary>
        /// ���i�I�𐧌䃁�\�b�h
        /// </summary>
        /// <param name="carInfo">�Ԍ^�����f�[�^�Z�b�g</param>
        /// <param name="partsInfo">���i���f�[�^�Z�b�g</param>
        /// <returns>�_�C�A���O�{�b�N�X�̖߂�l</returns>
        /// <remarks>
        /// <br>note			:	</br>
        /// <br>Programer		:	30290</br>
        /// <br>Date			:	2008.07.03</br>
        /// </remarks>
        public static DialogResult ProcessPartsSearch(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet partsInfo)
        {
            DialogResult ret = DialogResult.Cancel;
            int SearchUICntDivCd = partsInfo.SearchCondition.SearchCntSetWork.SearchUICntDivCd;
            if (SearchUICntDivCd == 0)  // PM7������ʐ���
            {
                ret = DisplayControlPM7(owner, carInfo, partsInfo);
            }
            else                         // PM.NS������ʐ���(�{����1�ł����A0�ȊO��1�ƌ��Ȃ�)
            {
                ret = DisplayControlNS(owner, carInfo, partsInfo);
            }
            return ret;
        }

        #region [PM7���I��UI����]
        /// <summary>
        /// ���i�I�𐧌䃁�\�b�h(PM7����)
        /// </summary>
        /// <param name="carInfo">�Ԍ^�����f�[�^�Z�b�g</param>
        /// <param name="partsInfo">���i���f�[�^�Z�b�g</param>
        /// <returns>�_�C�A���O�{�b�N�X�̖߂�l</returns>
        /// <remarks>
        /// <br>note			:	</br>
        /// <br>Programer		:	30290</br>
        /// <br>Date			:	2008.10.06</br>
        /// </remarks>
        private static DialogResult DisplayControlPM7(IWin32Window owner,PMKEN01010E carInfo, PartsInfoDataSet partsInfo)
        {
            DialogResult ret = DialogResult.Cancel;
            SearchFlag flg = partsInfo.SearchCondition.SearchFlg;
            if ((int)flg < 2) // BL������
            {
                ret = BLSearch7(owner, carInfo, partsInfo);
            }
            else // �i�Ԍ�����
            {
                ret = PartsNoSearch7(owner, partsInfo, flg);
            }
            return ret;
        }

        /// <summary>
        /// BL�������̉�ʐ���(PM7������)
        /// </summary>
        /// <param name="carInfo">�ԗ����</param>
        /// <param name="partsInfo">���i���</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note : ����� 2009/10/20</br>
        /// <br>            : �W�����i�̑I�����\�ɂ���B</br>
        /// </remarks>
        private static DialogResult BLSearch7(IWin32Window owner,PMKEN01010E carInfo, PartsInfoDataSet partsInfo)
        {
            string goodsNo = string.Empty;
            PartsInfoDataSet.UsrSetPartsRow[] rowJoinSet;
            List<PartsInfoDataSet.UsrGoodsInfoRow> lstSelected = new List<PartsInfoDataSet.UsrGoodsInfoRow>();
            Process currentProcess = Process.GetCurrentProcess();
            DialogResult retDialog = DialogResult.OK;

            retDialog = ShowPartsUI(owner, carInfo, partsInfo);
            currentProcess.Refresh();

            if (retDialog == DialogResult.Cancel)
                return retDialog;
            // 2009/12/16 >>>
#if false

            //PartsInfoDataSet.UsrGoodsInfoRow[] rows = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
            //partsInfo.UsrGoodsInfo.ResetSelectionState();
            //for (int i = 0; i < rows.Length; i++)
            foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
            {
                PartsInfoDataSet.UsrGoodsInfoRow row = selInfo.RowGoods;
                //string query = string.Format("{0}={1} AND {2}='{3}'",
                //    partsInfo.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, rows[i].GoodsMakerCd,
                //    partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, rows[i].GoodsNo);
                PartsInfoDataSet.PartsInfoRow _partsInfoRow = null;
                PartsInfoDataSet.PartsInfoRow[] childRows = (PartsInfoDataSet.PartsInfoRow[])row.GetChildRows("UsrGoodsInfo_PartsInfo");
                if (childRows.Length > 0)
                {
                    _partsInfoRow = childRows[0];
                }
                string _clgPartsNo;
                string _newPartsNo;
                if (_partsInfoRow != null)
                {
                    _clgPartsNo = _partsInfoRow.ClgPrtsNoWithHyphen;
                    _newPartsNo = _partsInfoRow.NewPrtsNoWithHyphen;
                    // 2009/12/14 >>>
                    //if (_clgPartsNo != _newPartsNo &&
                    //    ((row.NewGoodsNo != _clgPartsNo && row.NewGoodsNo != partsInfo.GoodsNoSel) // �J�^���O�i�ԈȊO�ɑ�ւ����ꍇ
                    //    || partsInfo.GoodsNoSel == _clgPartsNo)) // �J�^���O�i�Ԃɑ�ւ����ꍇ
                    if (_clgPartsNo != _newPartsNo &&
                        ( ( row.NewGoodsNo != _clgPartsNo && row.NewGoodsNo != selInfo.SelectedPartsNo ) // �J�^���O�i�ԈȊO�ɑ�ւ����ꍇ
                        || selInfo.SelectedPartsNo == _clgPartsNo )) // �J�^���O�i�Ԃɑ�ւ����ꍇ
                    // 2009/12/14 <<<
                    { // NewGoodsNo�͏������i�I��UI�ł̑�ւȂǂɂ�鏈���̂��ߎg���B
                        _newPartsNo = _clgPartsNo;
                    }
                }
                else
                {
                    _clgPartsNo = row.GoodsNo;
                    _newPartsNo = row.GoodsNo;
                }
                string query = string.Format("{0}={1} AND ({2}='{3}' OR {4}='{5}')",
                    partsInfo.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, row.GoodsMakerCd,
                    partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, _clgPartsNo,
                    partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, _newPartsNo);
                PartsInfoDataSet.UsrJoinPartsRow[] rowGoodsJoin =
                    (PartsInfoDataSet.UsrJoinPartsRow[])partsInfo.UsrJoinParts.Select(query);

                if (rowGoodsJoin.Length == 0) // �I���������i�̌������i���Ȃ�
                {
                    // �������i�ɐݒ肳��Ă���Z�b�g��񂪂���Ώ�������                    
                    if (row.NewGoodsNo != string.Empty) // ��ւ�����ꍇ�͑�֕i�ԂŃZ�b�g�q����
                        goodsNo = row.NewGoodsNo;
                    else
                        goodsNo = row.GoodsNo;
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, row.GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, goodsNo);
                    rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length == 0) // �I���������i�̃Z�b�g���i���Ȃ�
                    {
                        if (selInfo.IsThereSelection == false) // �I�����ꂽ���i���Ȃ��ꍇ
                            selInfo.Selected = true;
                    }
                    else
                    {
                        partsInfo.SetSrcSelInf = selInfo;
                        retDialog = ShowSetUI(owner, partsInfo, row); // �Z�b�g�I��UI�\��

                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                            return retDialog;
                        }
                        //PartsInfoDataSet.UsrGoodsInfoRow[] rowsSet = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                        //lstSelected.AddRange(rowsSet);
                    }

                    //------------ADD 2009/10/20--------->>>>>
                    partsInfo.UsrGoodsInfo.RowToProcess = row; // ADD 2009/11/30
                    retDialog = ShowPriceUI2(owner, carInfo, partsInfo); // �W�����i�I��UI�\��

                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        return retDialog;
                    }
                    //------------ADD 2009/10/20---------<<<<<
                    continue;
                }
                partsInfo.JoinSrcSelInf = selInfo;
                retDialog = ShowJoinUI(owner, partsInfo, row); // �����I��UI�\��

                if (retDialog == DialogResult.Cancel)
                {
                    partsInfo.RejectChanges();
                    return retDialog;
                }

                if (selInfo.JoinSet)
                {
                    // �������i�ɐݒ肳��Ă���Z�b�g��񂪂���Ώ�������                    
                    if (row.NewGoodsNo != string.Empty) // ��ւ�����ꍇ�͑�֕i�ԂŃZ�b�g�q����
                        goodsNo = row.NewGoodsNo;
                    else
                        goodsNo = row.GoodsNo;
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, row.GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, goodsNo);
                    rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length != 0) // �I�������������i�̃Z�b�g���i������
                    {
                        partsInfo.SetSrcSelInf = selInfo;
                        retDialog = ShowSetUI(owner, partsInfo, row); // �Z�b�g�I��UI�\��

                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                            return retDialog;
                        }
                    }
                }

                //PartsInfoDataSet.UsrGoodsInfoRow[] rowsJoin = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                //partsInfo.UsrGoodsInfo.ResetSelectionState();
                foreach (SelectionInfo selInfo2 in selInfo.ListChildGoods.Values)
                {
                    PartsInfoDataSet.UsrGoodsInfoRow row2 = selInfo2.RowGoods;
                    if (row2.NewGoodsNo != string.Empty) // ��ւ�����ꍇ�͑�֕i�ԂŃZ�b�g�q����
                        goodsNo = row2.NewGoodsNo;
                    else
                        goodsNo = row2.GoodsNo;
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, row2.GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, goodsNo);
                    //query = string.Format("{0}={1} AND {2}='{3}'",
                    //    partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, rowsJoin[j].GoodsMakerCd,
                    //    partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, rowsJoin[j].GoodsNo);
                    rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length == 0) // �I���������i�̃Z�b�g���i���Ȃ�
                    {
                        if (selInfo2.IsThereSelection == false)
                            selInfo2.Selected = true;

                        //------------ADD 2009/11/17--------->>>>>
                        partsInfo.UsrGoodsInfo.RowToProcess = row; // ADD 2009/11/30
                        retDialog = ShowPriceUI(owner, carInfo, partsInfo, row2); // �W�����i�I��UI�\��

                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                            return retDialog;
                        }
                        //------------ADD 2009/11/17---------<<<<<
                        continue;
                    }
                    partsInfo.SetSrcSelInf = selInfo2;
                    retDialog = ShowSetUI(owner, partsInfo, row2); // �Z�b�g�I��UI�\��

                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        return retDialog;
                    }
                    //PartsInfoDataSet.UsrGoodsInfoRow[] rowsSet = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                    //lstSelected.AddRange(rowsSet);

                    //------------ADD 2009/10/20--------->>>>>
                    retDialog = ShowPriceUI(owner, carInfo, partsInfo, row2); // �W�����i�I��UI�\��

                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        return retDialog;
                    }
                    //------------ADD 2009/10/20---------<<<<<
                }
                if (selInfo.IsThereSelection == false) // �I�����ꂽ���i���Ȃ��ꍇ
                    selInfo.Selected = true;
            }

            //for (int i = 0; i < lstSelected.Count; i++)
            //{
            //    lstSelected[i].SelectionState = true;
            //}
            partsInfo.UsrGoodsInfo.AcceptChanges();
#endif
            retDialog = BLSearch7WinCtrlProc_AfterPrtSel(owner, carInfo, partsInfo);
            // 2009/12/16 <<<
            return retDialog;
        }
#if  DEF20081024
        private static DialogResult BLSearch7(PMKEN01010E carInfo, PartsInfoDataSet partsInfo)
        {
            List<PartsInfoDataSet.UsrGoodsInfoRow> lstSelected = new List<PartsInfoDataSet.UsrGoodsInfoRow>();
            Process currentProcess = Process.GetCurrentProcess();
            DialogResult retDialog = DialogResult.OK;

            retDialog = ShowPartsUI(carInfo, partsInfo);
            currentProcess.Refresh();

            if (retDialog == DialogResult.Cancel)
                return retDialog;

            PartsInfoDataSet.UsrGoodsInfoRow[] rows = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
            partsInfo.UsrGoodsInfo.ResetSelectionState();
            for (int i = 0; i < rows.Length; i++)
            {
                string query = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfo.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, rows[i].GoodsMakerCd,
                    partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, rows[i].GoodsNo);
                PartsInfoDataSet.UsrJoinPartsRow[] rowGoodsJoin =
                    (PartsInfoDataSet.UsrJoinPartsRow[])partsInfo.UsrJoinParts.Select(query);

                if (rowGoodsJoin.Length == 0) // �I���������i�̌������i���Ȃ�
                {
                    // �������i�ɐݒ肳��Ă���Z�b�g��񂪂���Ώ�������
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, rows[i].GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, rows[i].GoodsNo);
                    PartsInfoDataSet.UsrSetPartsRow[] rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length == 0) // �I���������i�̃Z�b�g���i���Ȃ�
                    {
                        lstSelected.Add(rows[i]);
                    }
                    else
                    {
                        retDialog = ShowSetUI(partsInfo, rows[i]); // �Z�b�g�I��UI�\��

                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                            return retDialog;
                        }
                        PartsInfoDataSet.UsrGoodsInfoRow[] rowsSet = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                        lstSelected.AddRange(rowsSet);
                    }
                    continue;
                }

                retDialog = ShowJoinUI(partsInfo, rows[i]); // �����I��UI�\��

                if (retDialog == DialogResult.Cancel)
                {
                    partsInfo.RejectChanges();
                    return retDialog;
                }

                PartsInfoDataSet.UsrGoodsInfoRow[] rowsJoin = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                partsInfo.UsrGoodsInfo.ResetSelectionState();
                for (int j = 0; j < rowsJoin.Length; j++)
                {
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, rowsJoin[j].GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, rowsJoin[j].GoodsNo);
                    PartsInfoDataSet.UsrSetPartsRow[] rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length == 0) // �I���������i�̃Z�b�g���i���Ȃ�
                    {
                        lstSelected.Add(rowsJoin[j]);
                        continue;
                    }

                    retDialog = ShowSetUI(partsInfo, rowsJoin[j]); // �Z�b�g�I��UI�\��

                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        return retDialog;
                    }
                    PartsInfoDataSet.UsrGoodsInfoRow[] rowsSet = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                    lstSelected.AddRange(rowsSet);
                }

            }

            for (int i = 0; i < lstSelected.Count; i++)
            {
                lstSelected[i].SelectionState = true;
            }
            partsInfo.UsrGoodsInfo.AcceptChanges();

            return retDialog;
        }
#endif

        // 2009/12/16 Add >>>
        /// <summary>
        /// PM7���[�h��BL�R�[�h�����ŁA���i�I����̃E�B���h�E������s���܂��B
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="carInfo">�ԗ����</param>
        /// <param name="partsInfo">���i���</param>
        /// <returns></returns>
        private static DialogResult BLSearch7WinCtrlProc_AfterPrtSel(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet partsInfo)
        {
            string goodsNo = string.Empty;
            PartsInfoDataSet.UsrSetPartsRow[] rowJoinSet;
            DialogResult retDialog = DialogResult.Cancel;
            bool isCancel = false;

            foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
            {
                // --- DEL m.suzuki 2010/04/28 ---------->>>>>
                //if (selInfo.IsThereSelection || selInfo.Selected)
                //{
                //    retDialog = DialogResult.OK;
                //    continue;
                //}
                // --- DEL m.suzuki 2010/04/28 ----------<<<<<
                // --- ADD m.suzuki 2010/10/01 ---------->>>>>
                if ( (selInfo.IsThereSelection || selInfo.Selected) && !selInfo.ExtractSetParent )
                {
                    retDialog = DialogResult.OK;
                    continue;
                }
                // --- ADD m.suzuki 2010/10/01 ----------<<<<<

                PartsInfoDataSet.UsrGoodsInfoRow row = selInfo.RowGoods;
                PartsInfoDataSet.PartsInfoRow _partsInfoRow = null;
                PartsInfoDataSet.PartsInfoRow[] childRows = (PartsInfoDataSet.PartsInfoRow[])row.GetChildRows("UsrGoodsInfo_PartsInfo");
                if (childRows.Length > 0)
                {
                    _partsInfoRow = childRows[0];
                }
                string _clgPartsNo;
                string _newPartsNo;
                if (_partsInfoRow != null)
                {
                    _clgPartsNo = _partsInfoRow.ClgPrtsNoWithHyphen;
                    _newPartsNo = _partsInfoRow.NewPrtsNoWithHyphen;
                    if (_clgPartsNo != _newPartsNo &&
                        ( ( row.NewGoodsNo != _clgPartsNo && row.NewGoodsNo != selInfo.SelectedPartsNo ) // �J�^���O�i�ԈȊO�ɑ�ւ����ꍇ
                        || selInfo.SelectedPartsNo == _clgPartsNo )) // �J�^���O�i�Ԃɑ�ւ����ꍇ
                    { // NewGoodsNo�͏������i�I��UI�ł̑�ւȂǂɂ�鏈���̂��ߎg���B
                        _newPartsNo = _clgPartsNo;
                    }
                }
                else
                {
                    _clgPartsNo = row.GoodsNo;
                    _newPartsNo = row.GoodsNo;
                }
                string query = string.Format("{0}={1} AND ({2}='{3}' OR {4}='{5}')",
                    partsInfo.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, row.GoodsMakerCd,
                    partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, _clgPartsNo,
                    partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, _newPartsNo);
                PartsInfoDataSet.UsrJoinPartsRow[] rowGoodsJoin =
                    (PartsInfoDataSet.UsrJoinPartsRow[])partsInfo.UsrJoinParts.Select(query);

                if (rowGoodsJoin.Length == 0) // �I���������i�̌������i���Ȃ�
                {
                    // �������i�ɐݒ肳��Ă���Z�b�g��񂪂���Ώ�������                    
                    if (row.NewGoodsNo != string.Empty) // ��ւ�����ꍇ�͑�֕i�ԂŃZ�b�g�q����
                        goodsNo = row.NewGoodsNo;
                    else
                        goodsNo = row.GoodsNo;
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, row.GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, goodsNo);
                    rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length == 0) // �I���������i�̃Z�b�g���i���Ȃ�
                    {
                        if (selInfo.IsThereSelection == false) // �I�����ꂽ���i���Ȃ��ꍇ
                            selInfo.Selected = true;
                    }
                    else
                    {
                        partsInfo.SetSrcSelInf = selInfo;
                        retDialog = ShowSetUI(owner, partsInfo, row); // �Z�b�g�I��UI�\��

                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                            // �I�𕔕i��񂩂�폜����
                            partsInfo.RemoveSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key);
                            partsInfo.AcceptChanges();
                            isCancel = true;
                            retDialog = BLSearch7WinCtrlProc_AfterPrtSel(owner, carInfo, partsInfo);
                            break;
                        }
                    }

                    partsInfo.UsrGoodsInfo.RowToProcess = row;
                    retDialog = ShowPriceUI2(owner, carInfo, partsInfo); // �W�����i�I��UI�\��

                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        // �I�𕔕i��񂩂�폜����
                        partsInfo.RemoveSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key);
                        partsInfo.AcceptChanges();
                        isCancel = true;

                        retDialog = BLSearch7WinCtrlProc_AfterPrtSel(owner, carInfo, partsInfo);
                        break;
                    }
                    continue;
                }
                partsInfo.JoinSrcSelInf = selInfo;
                retDialog = ShowJoinUI(owner, partsInfo, row); // �����I��UI�\��

                if (retDialog == DialogResult.Cancel)
                {
                    partsInfo.RejectChanges();

                    // �I�𕔕i��񂩂�폜����
                    partsInfo.RemoveSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key);
                    partsInfo.AcceptChanges();
                    isCancel = true;
                    retDialog = BLSearch7WinCtrlProc_AfterPrtSel(owner, carInfo, partsInfo);
                    break;
                }

                if (selInfo.JoinSet)
                {
                    // �������i�ɐݒ肳��Ă���Z�b�g��񂪂���Ώ�������                    
                    if (row.NewGoodsNo != string.Empty) // ��ւ�����ꍇ�͑�֕i�ԂŃZ�b�g�q����
                        goodsNo = row.NewGoodsNo;
                    else
                        goodsNo = row.GoodsNo;
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, row.GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, goodsNo);
                    rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length != 0) // �I�������������i�̃Z�b�g���i������
                    {
                        partsInfo.SetSrcSelInf = selInfo;
                        retDialog = ShowSetUI(owner, partsInfo, row); // �Z�b�g�I��UI�\��

                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                            // �I�𕔕i��񂩂�폜����
                            partsInfo.RemoveSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key);
                            partsInfo.AcceptChanges();
                            isCancel = true;
                            retDialog = BLSearch7WinCtrlProc_AfterPrtSel(owner, carInfo, partsInfo);
                            break;
                        }
                    }
                }

                if (selInfo.ListChildGoods != null && selInfo.ListChildGoods.Count > 0)
                {
                    retDialog = BLSearch7WinCtrlProc_AfterJoinSel(owner, carInfo, partsInfo, row, selInfo);
                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        // �I�𕔕i��񂩂�폜����
                        partsInfo.RemoveSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key);
                        partsInfo.AcceptChanges();
                        isCancel = true;
                        retDialog = BLSearch7WinCtrlProc_AfterPrtSel(owner, carInfo, partsInfo);
                        break;
                    }
                }

                if (selInfo.IsThereSelection == false) // �I�����ꂽ���i���Ȃ��ꍇ
                    selInfo.Selected = true;
            }

            partsInfo.UsrGoodsInfo.AcceptChanges();

            // �L�����Z��������������������A���I����񂪉����Ȃ�
            if (isCancel && partsInfo.ListSelectionInfo.Keys.Count == 0)
            {
                retDialog = DialogResult.Cancel;
            }

            return retDialog;
        }

        /// <summary>
        /// PM7���[�h��BL�R�[�h�����ŁA�����I����̃E�B���h�E������s���܂��B
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="carInfo"></param>
        /// <param name="partsInfo"></param>
        /// <param name="selInfo"></param>
        /// <returns></returns>
        private static DialogResult BLSearch7WinCtrlProc_AfterJoinSel(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet partsInfo, PartsInfoDataSet.UsrGoodsInfoRow row, SelectionInfo selInfo)
        {
            string goodsNo = string.Empty;
            DialogResult retDialog = DialogResult.Cancel;
            bool isCancel = false;
            string query;
            PartsInfoDataSet.UsrSetPartsRow[] rowJoinSet;
            foreach (SelectionInfo selInfo2 in selInfo.ListChildGoods.Values)
            {
                // ���ɑI�����ꂽ�f�[�^������ꍇ�͔�΂��i�ċA�ɂ���ĕ�����Ă΂��ׁj
                if (selInfo2.IsThereSelection || selInfo2.Selected)
                {
                    retDialog = DialogResult.OK;
                    continue;
                }

                PartsInfoDataSet.UsrGoodsInfoRow row2 = selInfo2.RowGoods;
                if (row2.NewGoodsNo != string.Empty) // ��ւ�����ꍇ�͑�֕i�ԂŃZ�b�g�q����
                    goodsNo = row2.NewGoodsNo;
                else
                    goodsNo = row2.GoodsNo;
                query = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, row2.GoodsMakerCd,
                    partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, goodsNo);

                rowJoinSet =
                    (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                if (rowJoinSet.Length == 0) // �I���������i�̃Z�b�g���i���Ȃ�
                {
                    if (selInfo2.IsThereSelection == false)
                        selInfo2.Selected = true;

                    partsInfo.UsrGoodsInfo.RowToProcess = row;
                    retDialog = ShowPriceUI(owner, carInfo, partsInfo, row2); // �W�����i�I��UI�\��

                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        partsInfo.RemoveSelectionInfo(selInfo.ListChildGoods, selInfo2.Key);
                        partsInfo.AcceptChanges();
                        isCancel = true;
                        retDialog = BLSearch7WinCtrlProc_AfterJoinSel(owner, carInfo, partsInfo, row, selInfo);
                        break;
                    }
                    continue;
                }
                partsInfo.SetSrcSelInf = selInfo2;
                retDialog = ShowSetUI(owner, partsInfo, row2); // �Z�b�g�I��UI�\��

                if (retDialog == DialogResult.Cancel)
                {
                    partsInfo.RejectChanges();
                    partsInfo.RemoveSelectionInfo(selInfo.ListChildGoods, selInfo2.Key);
                    partsInfo.AcceptChanges();
                    isCancel = true;
                    retDialog = BLSearch7WinCtrlProc_AfterJoinSel(owner, carInfo, partsInfo, row, selInfo);
                    break;
                }
                partsInfo.UsrGoodsInfo.RowToProcess = row; //ADD ������ on 2012/06/26 for Redmine#30595
                retDialog = ShowPriceUI(owner, carInfo, partsInfo, row2); // �W�����i�I��UI�\��

                if (retDialog == DialogResult.Cancel)
                {
                    partsInfo.RejectChanges();
                    partsInfo.RemoveSelectionInfo(selInfo.ListChildGoods, selInfo2.Key);
                    partsInfo.AcceptChanges();
                    isCancel = true;
                    retDialog = BLSearch7WinCtrlProc_AfterJoinSel(owner, carInfo, partsInfo, row, selInfo);
                    break;
                }
            }

            // �L�����Z��������������������A���I����񂪉����Ȃ�
            if (isCancel && selInfo.ListChildGoods.Keys.Count == 0)
            {
                retDialog = DialogResult.Cancel;
            }

            return retDialog;
        }
        // 2009/12/16 Add <<<

        /// <summary>
        /// �i�Ԍ������̉�ʐ���(PM7������)
        /// </summary>
        /// <param name="partsInfo">���i���</param>
        /// <param name="flg">�����t���O(���S��v�����E�����܂������Ȃ�)</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note : ����� 2009/10/20</br>
        /// <br>            : �W�����i�̑I�����\�ɂ���B</br>
        /// </remarks>
        private static DialogResult PartsNoSearch7(IWin32Window owner, PartsInfoDataSet partsInfo, SearchFlag flg)
        {
            PartsInfoDataSet.UsrSetPartsRow[] rowJoinSet;
            List<PartsInfoDataSet.UsrGoodsInfoRow> lstSelected = new List<PartsInfoDataSet.UsrGoodsInfoRow>();
            Process currentProcess = Process.GetCurrentProcess();
            DialogResult retDialog = DialogResult.OK;

            retDialog = ShowSamePartsNoUI(owner, partsInfo, flg);
            currentProcess.Refresh();

            if (retDialog == DialogResult.Cancel)
                return retDialog;

            //PartsInfoDataSet.UsrGoodsInfoRow[] rows = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
            //partsInfo.UsrGoodsInfo.ResetSelectionState();
            //for (int i = 0; i < rows.Length; i++)
            foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
            {
                PartsInfoDataSet.UsrGoodsInfoRow row = selInfo.RowGoods;
                string query = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfo.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, row.GoodsMakerCd,
                    partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, row.GoodsNo);
                PartsInfoDataSet.UsrJoinPartsRow[] rowGoodsJoin =
                    (PartsInfoDataSet.UsrJoinPartsRow[])partsInfo.UsrJoinParts.Select(query);

                if (rowGoodsJoin.Length == 0) // �I���������i�̌������i���Ȃ�
                {
                    // �������i�ɐݒ肳��Ă���Z�b�g��񂪂���Ώ�������
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, row.GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, row.GoodsNo);
                    rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length == 0) // �I���������i�̃Z�b�g���i���Ȃ�
                    {
                        if (selInfo.IsThereSelection == false) // �I�����ꂽ���i���Ȃ��ꍇ
                            selInfo.Selected = true;
                    }
                    else
                    {
                        partsInfo.SetSrcSelInf = selInfo;
                        retDialog = ShowSetUI(owner, partsInfo, row); // �Z�b�g�I��UI�\��

                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                            return retDialog;
                        }
                        //PartsInfoDataSet.UsrGoodsInfoRow[] rowsSet = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                        //lstSelected.AddRange(rowsSet);
                    }

                    //------------ADD 2009/10/20--------->>>>>
                    retDialog = ShowPriceUI2(owner, partsInfo.SearchCarInfo, partsInfo); // �W�����i�I��UI�\��

                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        return retDialog;
                    }
                    //------------ADD 2009/10/20---------<<<<<
                    continue;
                }
                partsInfo.JoinSrcSelInf = selInfo;
                retDialog = ShowJoinUI(owner, partsInfo, row); // �����I��UI�\��

                if (retDialog == DialogResult.Cancel)
                {
                    partsInfo.RejectChanges();
                    return retDialog;
                }

                if (selInfo.JoinSet)
                {
                    // �������i�ɐݒ肳��Ă���Z�b�g��񂪂���Ώ�������
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, row.GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, row.GoodsNo);
                    rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length != 0) // �I�������������i�̃Z�b�g���i������                
                    {
                        partsInfo.SetSrcSelInf = selInfo;
                        retDialog = ShowSetUI(owner, partsInfo, row); // �Z�b�g�I��UI�\��

                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                            return retDialog;
                        }
                    }
                }

                //PartsInfoDataSet.UsrGoodsInfoRow[] rowsJoin = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                //partsInfo.UsrGoodsInfo.ResetSelectionState();
                //for (int j = 0; j < rowsJoin.Length; j++)
                foreach (SelectionInfo selInfo2 in selInfo.ListChildGoods.Values)
                {
                    PartsInfoDataSet.UsrGoodsInfoRow row2 = selInfo2.RowGoods;
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, row2.GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, row2.GoodsNo);
                    rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length == 0) // �I���������i�̃Z�b�g���i���Ȃ�
                    {
                        if (selInfo2.IsThereSelection == false)
                            selInfo2.Selected = true;

                        //------------ADD 2009/11/17--------->>>>>
                        retDialog = ShowPriceUI(owner, partsInfo.SearchCarInfo, partsInfo, row2); // �W�����i�I��UI�\��

                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                            return retDialog;
                        }
                        //------------ADD 2009/11/17---------<<<<<

                        continue;
                    }
                    partsInfo.SetSrcSelInf = selInfo2;
                    retDialog = ShowSetUI(owner, partsInfo, row2); // �Z�b�g�I��UI�\��

                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        return retDialog;
                    }
                    //PartsInfoDataSet.UsrGoodsInfoRow[] rowsSet = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                    //lstSelected.AddRange(rowsSet);

                    //------------ADD 2009/10/20--------->>>>>
                    partsInfo.UsrGoodsInfo.RowToProcess = row; //ADD ������ on 2012/06/26 for Redmine#30595
                    retDialog = ShowPriceUI(owner, partsInfo.SearchCarInfo, partsInfo, row2); // �W�����i�I��UI�\��

                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        return retDialog;
                    }
                    //------------ADD 2009/10/20---------<<<<<
                }

                if (selInfo.IsThereSelection == false) // �I�����ꂽ���i���Ȃ��ꍇ
                    selInfo.Selected = true;

            }

            //for (int i = 0; i < lstSelected.Count; i++)
            //{
            //    lstSelected[i].SelectionState = true;
            //}
            partsInfo.UsrGoodsInfo.AcceptChanges();

            return retDialog;
        }
#if old
        private static DialogResult PartsNoSearch7(PartsInfoDataSet partsInfo, SearchFlag flg)
        {
            List<PartsInfoDataSet.UsrGoodsInfoRow> lstSelected = new List<PartsInfoDataSet.UsrGoodsInfoRow>();
            Process currentProcess = Process.GetCurrentProcess();
            DialogResult retDialog = DialogResult.OK;

            retDialog = ShowSamePartsNoUI(partsInfo, flg);
            currentProcess.Refresh();

            if (retDialog == DialogResult.Cancel)
                return retDialog;

            PartsInfoDataSet.UsrGoodsInfoRow[] rows = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
            partsInfo.UsrGoodsInfo.ResetSelectionState();
            for (int i = 0; i < rows.Length; i++)
            {
                string query = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfo.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, rows[i].GoodsMakerCd,
                    partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, rows[i].GoodsNo);
                PartsInfoDataSet.UsrJoinPartsRow[] rowGoodsJoin =
                    (PartsInfoDataSet.UsrJoinPartsRow[])partsInfo.UsrJoinParts.Select(query);

                if (rowGoodsJoin.Length == 0) // �I���������i�̌������i���Ȃ�
                {
                    // �������i�ɐݒ肳��Ă���Z�b�g��񂪂���Ώ�������
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, rows[i].GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, rows[i].GoodsNo);
                    PartsInfoDataSet.UsrSetPartsRow[] rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length == 0) // �I���������i�̃Z�b�g���i���Ȃ�
                    {
                        lstSelected.Add(rows[i]);
                    }
                    else
                    {
                        retDialog = ShowSetUI(partsInfo, rows[i]); // �Z�b�g�I��UI�\��

                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                            return retDialog;
                        }
                        PartsInfoDataSet.UsrGoodsInfoRow[] rowsSet = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                        lstSelected.AddRange(rowsSet);
                    }
                    continue;
                }

                retDialog = ShowJoinUI(partsInfo, rows[i]); // �����I��UI�\��

                if (retDialog == DialogResult.Cancel)
                {
                    partsInfo.RejectChanges();
                    return retDialog;
                }

                PartsInfoDataSet.UsrGoodsInfoRow[] rowsJoin = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                partsInfo.UsrGoodsInfo.ResetSelectionState();
                for (int j = 0; j < rowsJoin.Length; j++)
                {
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, rowsJoin[j].GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, rowsJoin[j].GoodsNo);
                    PartsInfoDataSet.UsrSetPartsRow[] rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length == 0) // �I���������i�̃Z�b�g���i���Ȃ�
                    {
                        lstSelected.Add(rowsJoin[j]);
                        continue;
                    }

                    retDialog = ShowSetUI(partsInfo, rowsJoin[j]); // �Z�b�g�I��UI�\��

                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        return retDialog;
                    }
                    PartsInfoDataSet.UsrGoodsInfoRow[] rowsSet = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                    lstSelected.AddRange(rowsSet);
                }

            }

            for (int i = 0; i < lstSelected.Count; i++)
            {
                lstSelected[i].SelectionState = true;
            }
            partsInfo.UsrGoodsInfo.AcceptChanges();

            return retDialog;
        }
#endif
        #endregion

        #region [PM.NS���I��UI����]
        /// <summary>
        /// ���i�I�𐧌䃁�\�b�h(PM.NS����)
        /// </summary>
        /// <param name="carInfo">�Ԍ^�����f�[�^�Z�b�g</param>
        /// <param name="partsInfo">���i���f�[�^�Z�b�g</param>
        /// <returns>�_�C�A���O�{�b�N�X�̖߂�l</returns>
        /// <remarks>
        /// <br>note			:	</br>
        /// <br>Programer		:	30290</br>
        /// <br>Date			:	2008.10.06</br>
        /// </remarks>
        private static DialogResult DisplayControlNS(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet partsInfo)
        {
            DialogResult ret = DialogResult.Cancel;
            SearchFlag flg = partsInfo.SearchCondition.SearchFlg;
            if ((int)flg < 2) // BL������
            {
                ret = BLSearch(owner, carInfo, partsInfo);
            }
            else // �i�Ԍ�����
            {
                ret = PartsNoSearch(owner, partsInfo, flg);
            }
            return ret;
        }

        /// <summary>
        /// BL�������̉�ʐ���
        /// </summary>
        /// <param name="carInfo">�ԗ����</param>
        /// <param name="partsInfo">���i���</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note : ����� 2009/10/20</br>
        /// <br>            : �W�����i�̑I�����\�ɂ���B</br>
        /// <br>Update Note : ����� 2009/11/13</br>
        /// <br>            : redmine#1268,�\���p�^�[���̏C��</br>
        /// <br>Update Note : ����� 2009/11/16</br>
        /// <br>            : redmine#1320,�W�����i�I��\���̏C��</br>
        /// </remarks>
        private static DialogResult BLSearch(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet partsInfo)
        {
            Process currentProcess = Process.GetCurrentProcess();

            int originalPartsFlg = 0; // 0:�����@1:�I���W�i�����i�@2:TBO
            //SelectionFormSb frmSubstParts = null;
            SelectionParts frmClgParts = null;
            SelectionPrimeBLParts frmPrmBLParts = null;
            SelectionFormJ frmJoinParts = null;
            SelectionFormSet frmSetParts = null;
            //SearchFlag flg = partsInfo.SearchCondition.SearchFlg;

            // 2010/02/25 Add >>>
            if (partsInfo.Mode == 1)
            {
                // 2010/03/15 >>>
                //// SCM�����񓚃��[�h
                //if (partsInfo.PartsInfo.Count == 1)
                //{
                //    // �����P�i��
                //    int i = 0;
                //    foreach (PartsInfoDataSet.UsrGoodsInfoRow row in partsInfo.UsrGoodsInfo)
                //    {
                //        //row.SelectionState = true;

                //        SelectionInfo selInfo = new SelectionInfo();
                //        selInfo.Depth = 0;
                //        selInfo.Key = i;
                //        selInfo.RowGoods = row;
                //        selInfo.Selected = true;
                //        partsInfo.AddSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key, ref selInfo);

                //        if (( row.GoodsKindResolved != 2 ) && ( row.GoodsKindResolved != 4 ))
                //        {
                //            string filter = string.Format("{0}={1} AND {2}='{3}' ",
                //                partsInfo.Stock.GoodsMakerCdColumn.ColumnName, row.GoodsMakerCd,
                //                partsInfo.Stock.GoodsNoColumn.ColumnName, row.GoodsNo);
                //            partsInfo.Stock.DefaultView.RowFilter = filter;
                //            if (partsInfo.ListPriorWarehouse != null)
                //            {
                //                for (int k = 0; k < partsInfo.ListPriorWarehouse.Count; k++)
                //                {
                //                    string warehouseCd = partsInfo.ListPriorWarehouse[k].Trim();
                //                    bool breakFlg = false;
                //                    for (int j = 0; j < partsInfo.Stock.DefaultView.Count; j++)
                //                    {
                //                        if (warehouseCd.Equals(partsInfo.Stock.DefaultView[j][partsInfo.Stock.WarehouseCodeColumn.ColumnName]))
                //                        {
                //                            selInfo.WarehouseCode = warehouseCd;
                //                            //return DialogResult.OK;
                //                            breakFlg = true;
                //                            break;
                //                        }
                //                    }
                //                    if (breakFlg) break;
                //                }
                //            }
                //        }

                //        i++;
                //    }

                //    return DialogResult.OK;
                //}
                //else
                //{
                //    // ���������i��
                //    return DialogResult.None;
                //}

                frmClgParts = new SelectionParts(carInfo, partsInfo, 2);

                DialogResult ret = frmClgParts.SelectParts();
                if (ret == DialogResult.OK)
                {
                    SelectionFormJ join = new SelectionFormJ(partsInfo, 1);
                    join.SelectAllJoinParts();
                }
                return ret;
                // 2010/03/15 <<<
            }

            // 2010/02/25 Add <<<

            if (partsInfo.OfrPrimeParts.Count > 0)
            {
                originalPartsFlg = 1;
                frmPrmBLParts = new SelectionPrimeBLParts(partsInfo);
            }
            else if (partsInfo.TBOInfo.Count > 0)
            {
                originalPartsFlg = 2;
            }
            else
            {
                frmClgParts = new SelectionParts(carInfo, partsInfo);
            }

            int cnt = partsInfo.UsrGoodsInfo.Count;

            partsInfo.PartsInfo.DefaultView.RowFilter = string.Empty;
            partsInfo.JoinParts.DefaultView.RowFilter = string.Empty;
            partsInfo.UsrGoodsInfo.DefaultView.RowFilter = string.Empty;

            DialogResult retDialog = DialogResult.OK;
            //if (cnt > 1)
            //{
            partsInfo.UsrGoodsInfo.RowToProcess = partsInfo.UsrGoodsInfo[0];
            if (originalPartsFlg == 1) // �I���W�i�����i����
            {
                retDialog = frmPrmBLParts.ShowDialog(owner);//SelectionPrimeSearchParts.ShowDialog(partsInfo);
            }
            else if (originalPartsFlg == 2) // TBO
            {
                retDialog = SelectionCarInfoJoinParts.ShowDialog(owner, carInfo, partsInfo);
            }
            else // �������i����
            {
                retDialog = frmClgParts.ShowDialog(owner);
            }

            // --- DEL 2009/11/13 ---------->>>>> 
            //// --- ADD 2009/10/20 ---------->>>>> 
            //if (retDialog == DialogResult.OK)
            //{
            //    foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
            //    {
            //        if (selInfo.IsThereSelection == false) // �I�����ꂽ���i���Ȃ��ꍇ
            //            selInfo.Selected = true;
            //    }

            //    retDialog = ShowPriceUI(owner, carInfo, partsInfo);
            //}
            //// --- ADD 2009/10/20 ----------<<<<<
            // --- DEL 2009/11/13 ----------<<<<<

            //}
            //else
            //{
            //    if (cnt == 1)
            //        partsInfo.UsrGoodsInfo[0].SelectionState = true;
            //    return retDialog;
            //}
            currentProcess.Refresh();
            Stack<SelectUIKind> UiDisplayStack = new Stack<SelectUIKind>();
            SelectUIKind oldUI = partsInfo.UIKind;
            UiDisplayStack.Push(SelectUIKind.None);
            if (originalPartsFlg == 0)
            {
                if (frmClgParts.IsDialogShown)
                    UiDisplayStack.Push(SelectUIKind.PartsSelection);
            }
            else
            {
                if (originalPartsFlg == 2 || frmPrmBLParts.IsDialogShown)
                    UiDisplayStack.Push(SelectUIKind.PartsSelection);
            }
            UiDisplayStack.Push(partsInfo.UIKind);

            if (retDialog != DialogResult.Retry) // ���i�I��UI�őI���m��ł���΂��̂܂܏I��
            {
                // --- ADD 2009/11/13 ---------->>>>> 
                foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
                {
                    if (selInfo.IsThereSelection == false) // �I�����ꂽ���i���Ȃ��ꍇ
                        selInfo.Selected = true;
                }
                retDialog = ShowPriceUI2(owner, carInfo, partsInfo);
                // --- ADD 2009/11/13 ----------<<<<<
                return retDialog;
            }

            // ���i�I��UI�w��[���������p]
            SelectUIKind befkind = SelectUIKind.PartsSelection;�@// ADD 2009/11/13

            do
            {
                switch (partsInfo.UIKind)
                {
                    case SelectUIKind.PartsSelection:
                        // --- ADD 2009/11/13 ---------->>>>>
                        // �����I��UI�w��ꍇ
                        if (befkind == SelectUIKind.Join)
                        {
                            foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
                            {
                                if (selInfo.IsThereSelection == false) // �I�����ꂽ���i���Ȃ��ꍇ
                                    selInfo.Selected = true;
                            }
                            retDialog = ShowPriceUI2(owner, carInfo, partsInfo);
                        }
                        // --- ADD 2009/11/13 ----------<<<<<

                        if (originalPartsFlg == 1) // �I���W�i�����i����
                        {
                            retDialog = frmPrmBLParts.ShowDialog(owner); //retDialog = SelectionPrimeSearchParts.ShowDialog(partsInfo);
                        }
                        else if (originalPartsFlg == 2) // TBO
                        {
                            retDialog = SelectionCarInfoJoinParts.ShowDialog(owner, carInfo, partsInfo);
                        }
                        else
                        {
                            retDialog = frmClgParts.ShowDialog(owner);
                        }
                        break;
                    case SelectUIKind.Subst:
                        //if (frmSubstParts == null) frmSubstParts = new SelectionFormSb(partsInfo);
                        //retDialog = frmSubstParts.ShowDialog();
                        retDialog = SelectionSubstParts.ShowDialog(owner, partsInfo);
                        if (retDialog == DialogResult.OK)
                        {
                            if (partsInfo.SubstSrcSelInf != null && partsInfo.SubstSrcSelInf.ListPlrlSubst.Count > 0)
                            {
                                partsInfo.SubstSrcSelInf.RowGoods.NewGoodsNo = partsInfo.SubstSrcSelInf.ListPlrlSubst[0].RowGoods.GoodsNo;
                            }
                            //PartsInfoDataSet.UsrSubstPartsRow substRow = partsInfo.UsrSubstParts.GetSelectedRow(DataViewRowState.ModifiedCurrent);
                            //if (substRow != null)
                            //{
                            //    substRow.SelectionState = false; // �����̏����݂̂̂��߂Ȃ̂ŁA�O�̂��߃N���A����B
                            //    PartsInfoDataSet.UsrGoodsInfoRow goodsInfoRow
                            //        = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(substRow.ChgSrcMakerCd, substRow.ChgSrcGoodsNo);
                            //    if (goodsInfoRow != null)
                            //    {
                            //        goodsInfoRow.NewGoodsNo = substRow.ChgDestGoodsNo;
                            //        //goodsInfoRow.NewMakerCd = substRow.ChgDestMakerCd;
                            //    }
                            //}
                            //else
                            //{
                            //    if (partsInfo.UsrGoodsInfo.RowToProcess.SelectionState) // ��ւƂ��đ�֌��i�Ԃ��I�����ꂽ�ꍇ
                            //    { // �񋟏����̃J�^���O�i�ԂƍŐV�i�Ԃ��قȂ�ꍇ�A�J�^���O�i�Ԃ̕��i��I�Ԃ��߂ɂ��̏������K�v
                            //        partsInfo.UsrGoodsInfo.RowToProcess.NewGoodsNo = partsInfo.UsrGoodsInfo.RowToProcess.GoodsNo;
                            //    } // ��֕i�ԂƂ��Ď������g�̕i�Ԃ�ݒ肵�Ă����A�J�^���O�i�Ԃ��I���ł���悤�ɂ���B
                            //}
                        }
                        break;
                    case SelectUIKind.Join:
                        if (frmJoinParts == null) frmJoinParts = new SelectionFormJ(partsInfo);
                        retDialog = frmJoinParts.ShowDialog(owner);

                        // --- ADD 2009/11/16 ---------->>>>>
                        SelectUIKind dummykind = SelectUIKind.PartsSelection;
                        Stack<SelectUIKind> dummyUiDisplayStack = new Stack<SelectUIKind>();
                        dummyUiDisplayStack = UiDisplayStack;
                        dummykind = dummyUiDisplayStack.Pop();

                        // �����I���ŏI������ꍇ(���i�I����ʖ����̏ꍇ)
                        if (dummyUiDisplayStack.Peek() == SelectUIKind.None)
                        {
                            if (retDialog == DialogResult.OK)
                            {
                                foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
                                {
                                    if (selInfo.IsThereSelection == false) // �I�����ꂽ���i���Ȃ��ꍇ
                                        selInfo.Selected = true;
                                }
                                retDialog = ShowPriceUI2(owner, partsInfo.SearchCarInfo, partsInfo); 
                            }
                        }
                        dummyUiDisplayStack.Push(dummykind);
                        // --- ADD 2009/11/16 ----------<<<<<
                        break;
                    case SelectUIKind.Set:
                        if (frmSetParts == null) frmSetParts = new SelectionFormSet(partsInfo);
                        retDialog = frmSetParts.ShowDialog(owner);
                        break;
                }

                befkind = partsInfo.UIKind;�@// ADD 2009/11/13

                currentProcess.Refresh();
                if (retDialog == DialogResult.Retry)
                {
                    oldUI = partsInfo.UIKind;
                    partsInfo.AcceptChanges();
                }
                //else if (retDialog == DialogResult.Abort) // �~�{�^���ɂ�銮�S�I��(�O�̉�ʂɖ߂炸�A�I���I���Ƃ���)
                //{
                //    retDialog = DialogResult.Cancel;
                //    break;
                //}
                else if (retDialog == DialogResult.Ignore) // �I���m��(�O�̉�ʂɖ߂炸�A�I���I���Ƃ���)
                {
                    retDialog = DialogResult.OK;
                    break;
                }
                else
                {
                    if (UiDisplayStack.Count == 0)
                        break;
                    if (UiDisplayStack.Peek() == oldUI)
                        UiDisplayStack.Pop();
                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        if (partsInfo.UsrGoodsInfo.RowToProcess != null)
                            partsInfo.UsrGoodsInfo.RowToProcess.NewGoodsNo = string.Empty; // ��֊֘A�����N���A����B
                    }
                    else
                    {
                        partsInfo.AcceptChanges();
                    }
                    partsInfo.UIKind = UiDisplayStack.Pop();
                    oldUI = partsInfo.UIKind;
                    partsInfo.UsrGoodsInfo.SetPreviousRowToCurrentRow();
                }
                if (oldUI != SelectUIKind.None)
                    UiDisplayStack.Push(oldUI);
            } while (UiDisplayStack.Count > 0);

            return retDialog;
        }

        /// <summary>
        /// �i�Ԍ������̉�ʐ���
        /// </summary>
        /// <param name="partsInfo">���i���</param>
        /// <param name="flg">�����t���O(���S��v�����E�����܂������Ȃ�)</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note : ����� 2009/10/20</br>
        /// <br>            : �W�����i�̑I�����\�ɂ���B</br>
        /// <br>Update Note : ����� 2009/11/13</br>
        /// <br>            : redmine#1268,�\���p�^�[���̏C��</br>
        /// </remarks>
        private static DialogResult PartsNoSearch(IWin32Window owner, PartsInfoDataSet partsInfo, SearchFlag flg)
        {
            Process currentProcess = Process.GetCurrentProcess();
            SelectionSamePartsNoParts frmSamePartsNo = null;
            //SelectionFormSb frmSubstParts = null;
            SelectionFormJ frmJoinParts = null;
            SelectionFormSet frmSetParts = null;

            // 2010/02/25 Add >>>
            if (partsInfo.Mode == 1)
            {
                // SCM�����񓚃��[�h
                //if (partsInfo.PartsInfo.Count == 1)
                if (checkPureCode(partsInfo))
                {
                    // �����P�i��
                    int i = 0;
                    foreach (PartsInfoDataSet.UsrGoodsInfoRow row in partsInfo.UsrGoodsInfo)
                    {
                        //row.SelectionState = true;

                        SelectionInfo selInfo = new SelectionInfo();
                        selInfo.Depth = 0;
                        selInfo.Key = i;
                        selInfo.RowGoods = row;
                        selInfo.Selected = true;
                        partsInfo.AddSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key, ref selInfo);

                        if ((row.GoodsKindResolved != 2) && (row.GoodsKindResolved != 4))
                        {
                            string filter = string.Format("{0}={1} AND {2}='{3}' ",
                                partsInfo.Stock.GoodsMakerCdColumn.ColumnName, row.GoodsMakerCd,
                                partsInfo.Stock.GoodsNoColumn.ColumnName, row.GoodsNo);
                            partsInfo.Stock.DefaultView.RowFilter = filter;
                            if (partsInfo.ListPriorWarehouse != null)
                            {
                                for (int k = 0; k < partsInfo.ListPriorWarehouse.Count; k++)
                                {
                                    string warehouseCd = partsInfo.ListPriorWarehouse[k].Trim();
                                    bool breakFlg = false;
                                    for (int j = 0; j < partsInfo.Stock.DefaultView.Count; j++)
                                    {
                                        if (warehouseCd.Equals(partsInfo.Stock.DefaultView[j][partsInfo.Stock.WarehouseCodeColumn.ColumnName]))
                                        {
                                            selInfo.WarehouseCode = warehouseCd;
                                            //return DialogResult.OK;
                                            breakFlg = true;
                                            break;
                                        }
                                    }
                                    if (breakFlg) break;
                                }
                            }
                        }

                        i++;
                    }

                    return DialogResult.OK;
                }
                else
                {
                    // ���������i��
                    return DialogResult.None;
                }
            }
            // 2010/02/25 Add <<<

            int cnt = partsInfo.UsrGoodsInfo.Count;

            partsInfo.PartsInfo.DefaultView.RowFilter = string.Empty;
            partsInfo.JoinParts.DefaultView.RowFilter = string.Empty;
            partsInfo.UsrGoodsInfo.DefaultView.RowFilter = string.Empty;

            DialogResult retDialog = DialogResult.OK;
            if (flg == SearchFlag.PartsNoJoinSearch)// || flg == SearchFlag.GoodsAndSetInfo)
            {
                frmSamePartsNo = new SelectionSamePartsNoParts(partsInfo, 1, null);
            }
            else
            {
                frmSamePartsNo = new SelectionSamePartsNoParts(partsInfo, 2, null);
            }
            retDialog = frmSamePartsNo.ShowDialog(owner);

            currentProcess.Refresh();

            Stack<SelectUIKind> UiDisplayStack = new Stack<SelectUIKind>();
            SelectUIKind oldUI = partsInfo.UIKind;
            UiDisplayStack.Push(SelectUIKind.None);
            if (frmSamePartsNo.IsDialogShown)
            {
                UiDisplayStack.Push(SelectUIKind.SamePartsNo);
            }
            UiDisplayStack.Push(partsInfo.UIKind);

            if (retDialog != DialogResult.Retry) // ����i�ԑI��UI�őI���m��ł���΂��̂܂܏I��
            {
                foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
                {
                    if (selInfo.IsThereSelection == false) // �I�����ꂽ���i���Ȃ��ꍇ
                        selInfo.Selected = true;
                }

                retDialog = ShowPriceUI2(owner, partsInfo.SearchCarInfo, partsInfo);
                return retDialog;
            }

            SelectUIKind befkind = partsInfo.UIKind;  // ADD 2009/11/13

            do
            {
                switch (partsInfo.UIKind)
                {
                    case SelectUIKind.SamePartsNo:
                        retDialog = frmSamePartsNo.ShowDialog(owner, retDialog);
                        if (retDialog == DialogResult.OK)
                        {
                            foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
                            {
                                if (selInfo.IsThereSelection == false) // �I�����ꂽ���i���Ȃ��ꍇ
                                    selInfo.Selected = true;
                            }
                        }
                        break;
                    case SelectUIKind.Subst:
                        //if (frmSubstParts == null) frmSubstParts = new SelectionFormSb(partsInfo);
                        //retDialog = frmSubstParts.ShowDialog();
                        retDialog = SelectionSubstParts.ShowDialog(owner, partsInfo);
                        if (retDialog == DialogResult.OK)
                        {
                            if (partsInfo.SubstSrcSelInf != null && partsInfo.SubstSrcSelInf.ListPlrlSubst.Count > 0)
                            {
                                partsInfo.SubstSrcSelInf.RowGoods.NewGoodsNo = partsInfo.SubstSrcSelInf.ListPlrlSubst[0].RowGoods.GoodsNo;
                            }
                            //PartsInfoDataSet.UsrSubstPartsRow substRow = partsInfo.UsrSubstParts.GetSelectedRow(DataViewRowState.ModifiedCurrent);
                            //if (substRow != null)
                            //{
                            //    substRow.SelectionState = false; // �����̏����݂̂̂��߂Ȃ̂ŁA�O�̂��߃N���A����B
                            //    PartsInfoDataSet.UsrGoodsInfoRow goodsInfoRow
                            //        = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(substRow.ChgSrcMakerCd, substRow.ChgSrcGoodsNo);
                            //    if (goodsInfoRow != null)
                            //    {
                            //        goodsInfoRow.NewGoodsNo = substRow.ChgDestGoodsNo;
                            //        //goodsInfoRow.NewMakerCd = substRow.ChgDestMakerCd;
                            //    }
                            //}
                        }
                        break;
                    case SelectUIKind.Join:
                        if (frmJoinParts == null) frmJoinParts = new SelectionFormJ(partsInfo);
                        retDialog = frmJoinParts.ShowDialog(owner);
                        if (frmJoinParts.IsDialogShown == false)
                        {
                            UiDisplayStack.Pop();
                        }

                        // --- ADD 2009/10/20 ---------->>>>> 
                        if (retDialog == DialogResult.OK)
                        {
                            foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
                            {
                                if (selInfo.IsThereSelection == false) // �I�����ꂽ���i���Ȃ��ꍇ
                                    selInfo.Selected = true;
                            }
                            retDialog = ShowPriceUI2(owner, partsInfo.SearchCarInfo, partsInfo);
                        }
                        // --- ADD 2009/10/20 ----------<<<<<

                        break;
                    case SelectUIKind.Set:
                        if (frmSetParts == null) frmSetParts = new SelectionFormSet(partsInfo);
                        retDialog = frmSetParts.ShowDialog(owner);

                        // --- ADD 2009/11/13 ---------->>>>> 
                        Stack<SelectUIKind> dummyUiDisplayStack = new Stack<SelectUIKind>();
                        dummyUiDisplayStack = UiDisplayStack;
                        befkind = dummyUiDisplayStack.Pop();
                        if (befkind == SelectUIKind.Set)
                        {
                            if (dummyUiDisplayStack.Peek() != SelectUIKind.Join)
                            {
                                if (retDialog == DialogResult.OK)
                                {
                                    foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
                                    {
                                        if (selInfo.IsThereSelection == false) // �I�����ꂽ���i���Ȃ��ꍇ
                                            selInfo.Selected = true;
                                    }
                                    retDialog = ShowPriceUI2(owner, partsInfo.SearchCarInfo, partsInfo);
                                }
                            }
                        }
                        dummyUiDisplayStack.Push(befkind);
                        // --- ADD 2009/11/13 ----------<<<<<

                        // --- DEL 2009/11/13 ---------->>>>> 
                        //// --- ADD 2009/10/20 ---------->>>>> 
                        //if (retDialog == DialogResult.OK)
                        //{
                        //    foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
                        //    {
                        //        if (selInfo.IsThereSelection == false) // �I�����ꂽ���i���Ȃ��ꍇ
                        //            selInfo.Selected = true;
                        //    }

                        //    retDialog = ShowPriceUI(owner, partsInfo.SearchCarInfo, partsInfo);
                        //}
                        //// --- ADD 2009/10/20 ----------<<<<<
                        // --- DEL 2009/11/13 ----------<<<<<

                        break;
                }
                currentProcess.Refresh();
                if (retDialog == DialogResult.Retry)
                {
                    oldUI = partsInfo.UIKind;
                    partsInfo.AcceptChanges();
                }
                //else if (retDialog == DialogResult.Abort) // �~�{�^���ɂ�銮�S�I��(�O�̉�ʂɖ߂炸�A�I���I���Ƃ���)
                //{
                //    retDialog = DialogResult.Cancel;
                //    break;
                //}
                else if (retDialog == DialogResult.Ignore) // �I���m��(�O�̉�ʂɖ߂炸�A�I���I���Ƃ���)
                {
                    retDialog = DialogResult.OK;
                    break;
                }
                else
                {
                    if (UiDisplayStack.Count == 0)
                        break;
                    if (UiDisplayStack.Peek() == oldUI)
                        UiDisplayStack.Pop();
                    partsInfo.UIKind = UiDisplayStack.Pop();
                    oldUI = partsInfo.UIKind;
                    partsInfo.UsrGoodsInfo.SetPreviousRowToCurrentRow();
                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                    }
                    else
                    {
                        partsInfo.AcceptChanges();
                    }
                }
                if (oldUI != SelectUIKind.None)
                    UiDisplayStack.Push(oldUI);
            } while (UiDisplayStack.Count > 0);

            return retDialog;

        }

        // 2010/02/25 Add >>>
        /// <summary>
        /// �����P�i�ԃ`�F�b�N
        /// </summary>
        /// <param name="partsInfo"></param>
        private static bool checkPureCode(PartsInfoDataSet partsInfo)
        {
            int count = 0;
            bool ret = false;
            foreach (PartsInfoDataSet.UsrGoodsInfoRow row in partsInfo.UsrGoodsInfo)
            {
                int goodsKind = row.GoodsKind % 2;
                int offerKubun = row.OfferKubun;
                if (( goodsKind == 1 ) && ( ( offerKubun == 1 ) || ( offerKubun == 3 ) ))
                {
                    count++;
                }
            }
            //>>>2011/09/04
            //if (count == 1) ret = true;
            if (partsInfo.AcceptOrOrderKind == 0)
            {
                if (count == 1) ret = true;
            }
            else
            {
                if (count >= 1) ret = true;
            }
            //<<<2011/09/04

            return ret;
        }

        // 2010/02/25 Add <<<
        #endregion

        #region [ �������ϗp���i�I�𐧌䃂�W���[�� ]
        /// <summary>
        /// �������ϗp���i�I�𐧌䃁�\�b�h(BL�R�[�h�̏ꍇ)
        /// </summary>
        /// <param name="carInfo">�Ԍ^�����f�[�^�Z�b�g</param>
        /// <param name="partsInfo">���i���f�[�^�Z�b�g</param>
        /// <param name="flg">�I��UI�\���t���O�@0:�\���@1:��\��</param>
        /// <returns>�_�C�A���O�{�b�N�X�̖߂�l</returns>
        public static DialogResult SearchEstimateBL(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet partsInfo, int flg)
        {
            int originalPartsFlg = 0; // 0:�����@1:�I���W�i�����i�@2:TBO
            //SelectionFormSb frmSubstParts = null;
            SelectionParts frmClgParts = null;
            SelectionPrimeBLParts frmPrmBLParts = null;

            if (partsInfo.OfrPrimeParts.Count > 0)
            {
                originalPartsFlg = 1;
                frmPrmBLParts = new SelectionPrimeBLParts(partsInfo, 1); // �������ϐ�p�̕��i�I��UI(�Z�b�g���\���Ȃ�)
            }
            else if (partsInfo.TBOInfo.Count > 0)
            {
                originalPartsFlg = 2;
            }
            else
            {
                frmClgParts = new SelectionParts(carInfo, partsInfo, 1); // �������ϐ�p�̕��i�I��UI(�������\���Ȃ�)
            }

            // --- UPD m.suzuki 2010/07/13 ---------->>>>>
            //string filter = string.Format("{0}=1 OR {1}=3 OR {2}=7", partsInfo.UsrGoodsInfo.OfferKubunColumn.ColumnName, partsInfo.UsrGoodsInfo.OfferKubunColumn.ColumnName, partsInfo.UsrGoodsInfo.OfferKubunColumn.ColumnName);
            //PartsInfoDataSet.UsrGoodsInfoRow[] rowGoodsInfo = (PartsInfoDataSet.UsrGoodsInfoRow[])partsInfo.UsrGoodsInfo.Select(filter);
            //int cnt = rowGoodsInfo.Length;
            int cnt = partsInfo.PartsInfo.DefaultView.Count;
            // --- UPD m.suzuki 2010/07/13 ----------<<<<<

            partsInfo.PartsInfo.DefaultView.RowFilter = string.Empty;
            partsInfo.JoinParts.DefaultView.RowFilter = string.Empty;
            partsInfo.UsrGoodsInfo.DefaultView.RowFilter = string.Empty;

            DialogResult retDialog = DialogResult.OK;
            if ((flg == 0 && (cnt > 1 || partsInfo.SubstPartsInfo.Count > 0)) || originalPartsFlg == 2) // TBO�̏ꍇ�͕\���t���O����\���ł��\������
            {
                partsInfo.UsrGoodsInfo.RowToProcess = partsInfo.UsrGoodsInfo[0];
                if (originalPartsFlg == 1) // �I���W�i�����i����
                {
                    retDialog = frmPrmBLParts.ShowDialog(owner);//SelectionPrimeSearchParts.ShowDialog(partsInfo);
                }
                else if (originalPartsFlg == 2) // TBO
                {
                    retDialog = SelectionCarInfoJoinParts.ShowDialog(owner, carInfo, partsInfo);
                }
                else // �������i����
                {
                    retDialog = frmClgParts.ShowDialog(owner);
                }
            }
            else
            {
                if (originalPartsFlg == 0) // �������i�̏ꍇ
                {
                    cnt = frmClgParts.PartsInfo.Count;
                    for (int i = 0; i < cnt; i++)
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow rowUGInfo;
                        if (frmClgParts.PartsInfo[i].UsrSubst)
                            rowUGInfo = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(frmClgParts.PartsInfo[i].CatalogPartsMakerCd, frmClgParts.PartsInfo[i].PartsNo);
                        else
                            rowUGInfo = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(frmClgParts.PartsInfo[i].CatalogPartsMakerCd, frmClgParts.PartsInfo[i].JoinSrcPartsNo);

                        SelectionInfo selInfo = new SelectionInfo();
                        selInfo.Key = i;
                        selInfo.Selected = true;
                        selInfo.RowGoods = rowUGInfo;
                        partsInfo.AddSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key, ref selInfo);
                    }
                }
                else
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow rowUGInfo = partsInfo.UsrGoodsInfo[i];
                        if ((rowUGInfo.OfferKubun == 1 || rowUGInfo.OfferKubun == 3 || rowUGInfo.OfferKubun == 7) // �񋟂̏������́E�I���W�i�����i��
                            && (rowUGInfo.GoodsKind & (int)GoodsKind.Parent) == (int)GoodsKind.Parent) // �񋟂̑�ւ͏���
                        {
                            SelectionInfo selInfo = new SelectionInfo();
                            selInfo.Key = i;
                            selInfo.Selected = true;
                            selInfo.RowGoods = rowUGInfo;
                            partsInfo.AddSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key, ref selInfo);
                        }
                    }
                }

                return retDialog;
            }
            Stack<SelectUIKind> UiDisplayStack = new Stack<SelectUIKind>();
            SelectUIKind oldUI = partsInfo.UIKind;
            UiDisplayStack.Push(SelectUIKind.None);
            //UiDisplayStack.Push(SelectUIKind.PartsSelection);
            if (originalPartsFlg != 0 || frmClgParts.IsDialogShown)
            {
                UiDisplayStack.Push(SelectUIKind.PartsSelection);
            }

            UiDisplayStack.Push(partsInfo.UIKind);

            if (retDialog != DialogResult.Retry)
            {
                return retDialog;
            }
            else if (partsInfo.UIKind != SelectUIKind.PartsSelection && partsInfo.UIKind != SelectUIKind.Subst)
            { // ����͏������i1�݂̂Ō������i������ꍇ�B�������ς͌����I��UI�\�����Ȃ����ߑI���I���Ƃ���B
                if (partsInfo.ListSelectionInfo.Count > 0)
                    partsInfo.ListSelectionInfo[0].Selected = true;
                return DialogResult.OK;
            }

            do
            {
                switch (partsInfo.UIKind)
                {
                    case SelectUIKind.PartsSelection:
                        if (originalPartsFlg == 1) // �I���W�i�����i����
                        {
                            retDialog = frmPrmBLParts.ShowDialog(owner); //SelectionPrimeSearchParts.ShowDialog(partsInfo);
                        }
                        else if (originalPartsFlg == 2) // TBO
                        {
                            retDialog = SelectionCarInfoJoinParts.ShowDialog(owner, carInfo, partsInfo);
                        }
                        else
                        {
                            // 2009/12/18 >>>
                            //retDialog = frmClgParts.ShowDialog();
                            retDialog = frmClgParts.ShowDialog(owner);
                            // 2009/12/18 <<<
                        }
                        break;
                    case SelectUIKind.Subst:
                        //if (frmSubstParts == null) frmSubstParts = new SelectionFormSb(partsInfo);
                        //retDialog = frmSubstParts.ShowDialog();
                        retDialog = SelectionSubstParts.ShowDialog(owner, partsInfo);
                        if (retDialog == DialogResult.OK)
                        {
                            if (partsInfo.SubstSrcSelInf != null && partsInfo.SubstSrcSelInf.ListPlrlSubst.Count > 0)
                            {
                                partsInfo.SubstSrcSelInf.RowGoods.NewGoodsNo = partsInfo.SubstSrcSelInf.ListPlrlSubst[0].RowGoods.GoodsNo;
                            }
                            //PartsInfoDataSet.UsrSubstPartsRow substRow = partsInfo.UsrSubstParts.GetSelectedRow(DataViewRowState.CurrentRows);
                            //if (substRow != null)
                            //{
                            //    substRow.SelectionState = false; // �����̏����݂̂̂��߂Ȃ̂ŁA�O�̂��߃N���A����B
                            //    PartsInfoDataSet.UsrGoodsInfoRow goodsInfoRow
                            //        = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(substRow.ChgSrcMakerCd, substRow.ChgSrcGoodsNo);
                            //    if (goodsInfoRow != null)
                            //    {
                            //        goodsInfoRow.NewGoodsNo = substRow.ChgDestGoodsNo;
                            //        //goodsInfoRow.NewMakerCd = substRow.ChgDestMakerCd;
                            //    }
                            //}
                            //else
                            //{
                            //    if (partsInfo.UsrGoodsInfo.RowToProcess.SelectionState) // ��ւƂ��đ�֌��i�Ԃ��I�����ꂽ�ꍇ
                            //    { // �񋟏����̃J�^���O�i�ԂƍŐV�i�Ԃ��قȂ�ꍇ�A�J�^���O�i�Ԃ̕��i��I�Ԃ��߂ɂ��̏������K�v
                            //        partsInfo.UsrGoodsInfo.RowToProcess.NewGoodsNo = partsInfo.UsrGoodsInfo.RowToProcess.GoodsNo;
                            //    } // ��֕i�ԂƂ��Ď������g�̕i�Ԃ�ݒ肵�Ă����A�J�^���O�i�Ԃ��I���ł���悤�ɂ���B
                            //}
                        }
                        break;
                }
                if (retDialog == DialogResult.Retry)
                {
                    oldUI = partsInfo.UIKind;
                    //partsInfo.AcceptChanges();
                }
                //else if (retDialog == DialogResult.Abort)
                //{
                //    retDialog = DialogResult.Cancel;
                //    break;
                //}
                else
                {
                    if (UiDisplayStack.Count == 0)
                        break;
                    if (UiDisplayStack.Peek() == oldUI)
                        UiDisplayStack.Pop();
                    partsInfo.UIKind = UiDisplayStack.Pop();
                    oldUI = partsInfo.UIKind;
                    partsInfo.UsrGoodsInfo.SetPreviousRowToCurrentRow();
                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                    }
                    else
                    {
                        partsInfo.AcceptChanges();
                    }
                }
                if (oldUI != SelectUIKind.None)
                    UiDisplayStack.Push(oldUI);
            } while (UiDisplayStack.Count > 0);

            return retDialog;
        }

        /// <summary>
        /// �������ϗp���i�I�𐧌䃁�\�b�h(�i�Ԃ̏ꍇ)
        /// </summary>
        /// <param name="partsInfo">���i���f�[�^�Z�b�g</param>
        /// <param name="flg">�I��UI�\���t���O�@0:�\���@1:��\��</param>
        /// <returns>�_�C�A���O�{�b�N�X�̖߂�l</returns>
        public static DialogResult SearchEstimatePNo(IWin32Window owner, PartsInfoDataSet partsInfo, int flg)
        {
            SelectionSamePartsNoParts frmSamePartsNo = null;
            string filter = string.Format("{0} = {1}", partsInfo.UsrGoodsInfo.GoodsKindColumn.ColumnName, (int)GoodsKind.Parent);
            PartsInfoDataSet.UsrGoodsInfoRow[] rowsGoodsInfo = (PartsInfoDataSet.UsrGoodsInfoRow[])partsInfo.UsrGoodsInfo.Select(filter);
            int cnt = rowsGoodsInfo.Length;

            partsInfo.PartsInfo.DefaultView.RowFilter = string.Empty;
            partsInfo.JoinParts.DefaultView.RowFilter = string.Empty;
            partsInfo.UsrGoodsInfo.DefaultView.RowFilter = string.Empty;

            DialogResult retDialog = DialogResult.OK;
            if (cnt > 1 && flg == 0)
            {
                frmSamePartsNo = new SelectionSamePartsNoParts(partsInfo, 2, null);
                retDialog = frmSamePartsNo.ShowDialog(owner);
                if (retDialog == DialogResult.OK)
                {
                    foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
                    {
                        if (selInfo.IsThereSelection == false) // �I�����ꂽ���i���Ȃ��ꍇ
                            selInfo.Selected = true;
                    }
                }
            }
            else
            {
                if (cnt == 1)
                {
                    SelectionInfo selInfo = new SelectionInfo();
                    selInfo.Key = 0;
                    selInfo.Selected = true;
                    // 2009/12/01 >>>
                    //selInfo.RowGoods = partsInfo.UsrGoodsInfo[0];
                    selInfo.RowGoods = rowsGoodsInfo[0];
                    // 2009/12/01 <<<
                    partsInfo.AddSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key, ref selInfo);
                    //partsInfo.UsrGoodsInfo[0].SelectionState = true;
                }
                else if (flg == 1)
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow rowUGInfo = rowsGoodsInfo[i];
                        if (rowUGInfo.GoodsKind == (int)GoodsKind.Parent) // �񋟁E���[�U�[�o�^�̕��i
                        {
                            SelectionInfo selInfo = new SelectionInfo();
                            selInfo.Key = i;
                            selInfo.Selected = true;
                            selInfo.RowGoods = rowUGInfo;
                            partsInfo.AddSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key, ref selInfo);
                            //PartsInfoDataSet.PartsInfoRow rowGPInfo =
                            //    partsInfo.PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(rowUGInfo.GoodsMakerCd, rowUGInfo.GoodsNo);
                            //if (rowGPInfo != null && rowGPInfo.ClgPrtsNoWithHyphen != rowGPInfo.NewPrtsNoWithHyphen) //�ŐV�i�ԂƃJ�^���O�i�Ԃ��Ⴄ�ꍇ
                            //{
                            //    PartsInfoDataSet.UsrGoodsInfoRow rowNewGoods =
                            //        partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(rowGPInfo.CatalogPartsMakerCd, rowGPInfo.NewPrtsNoWithHyphen);
                            //    if (rowNewGoods != null)
                            //    {
                            //        rowNewGoods.SelectionState = true;
                            //    }
                            //    else // �����Ă͂����Ȃ��P�[�X�B�f�[�^�̕s�����Ȃǂɂ��s��h�~�̂��߁B
                            //    {
                            //        rowUGInfo.SelectionState = true;
                            //    }
                            //}
                            //else
                            //{
                            //    rowUGInfo.SelectionState = true;
                            //}
                        }
                    }
                }

            }
            return retDialog;
        }

        /// <summary>
        /// �������ϗp�Z�b�g�I��UI���䃁�\�b�h
        /// </summary>
        /// <param name="partsInfo"></param>
        /// <param name="setParentMakerCd"></param>
        /// <param name="setParentGoodsNo"></param>
        /// <returns></returns>
        public static DialogResult SESetUI(IWin32Window owner, PartsInfoDataSet partsInfo, int setParentMakerCd, string setParentGoodsNo)
        {
            PartsInfoDataSet.UsrGoodsInfoRow rowToProcess =
                partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(setParentMakerCd, setParentGoodsNo);
            SelectionInfo selInfo = new SelectionInfo();
            selInfo.Key = 0;
            selInfo.RowGoods = rowToProcess;
            partsInfo.SetSrcSelInf = selInfo;
            partsInfo.AddSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key, ref selInfo);
            return ShowSetUI(owner, partsInfo, rowToProcess);
        }
        #endregion

        #region [ �I��UI�\�����\�b�h(��֑I��UI�\���@�\�t��) ]
        /// <summary>
        /// �������i�I��UI���䃁�\�b�h
        /// </summary>
        /// <param name="carInfo"></param>
        /// <param name="partsInfo"></param>        
        /// <returns></returns>
        private static DialogResult ShowPartsUI(IWin32Window owner,PMKEN01010E carInfo, PartsInfoDataSet partsInfo)
        {
            int originalPartsFlg = 0; // 0:�����@1:�I���W�i�����i�@2:TBO
            SelectionParts frmClgParts = null;
            SelectionPrimeBLParts frmPrmBLParts = null;
            DialogResult retDialog = DialogResult.OK;
            //partsInfo.UsrGoodsInfo.ResetSelectionState();

            if (partsInfo.OfrPrimeParts.Count > 0)
            {
                originalPartsFlg = 1;
                frmPrmBLParts = new SelectionPrimeBLParts(partsInfo);
            }
            else if (partsInfo.TBOInfo.Count > 0)
            {
                originalPartsFlg = 2;
            }
            else
            {
                //if (partsInfo.PartsInfo.Count == 1 && partsInfo.SubstPartsInfo.Count == 0 && partsInfo.DSubstPartsInfo.Count == 0)
                //{
                //    frmClgParts = null;
                //    partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
                //        partsInfo.PartsInfo[0].CatalogPartsMakerCd, partsInfo.PartsInfo[0].ClgPrtsNoWithHyphen).SelectionState = true;
                //    partsInfo.UsrGoodsInfo.AcceptChanges();
                //}
                //else
                //{
                frmClgParts = new SelectionParts(carInfo, partsInfo);
                //}
            }
            partsInfo.UsrGoodsInfo.RowToProcess = partsInfo.UsrGoodsInfo[0];
            if (originalPartsFlg == 1) // �I���W�i�����i����
            {
                retDialog = frmPrmBLParts.ShowDialog(owner);//SelectionPrimeSearchParts.ShowDialog(partsInfo);
            }
            else if (originalPartsFlg == 2) // TBO
            {
                retDialog = SelectionCarInfoJoinParts.ShowDialog(owner, carInfo, partsInfo);
            }
            else // �������i����
            {
                if (frmClgParts != null) // �������i���������͏������i1�Ƒ�֕i������ꍇ
                {
                    retDialog = frmClgParts.ShowDialog(owner); // �������i�I��UI��\������B
                }
            }

            Stack<SelectUIKind> UiDisplayStack = new Stack<SelectUIKind>();
            SelectUIKind oldUI = partsInfo.UIKind;
            UiDisplayStack.Push(SelectUIKind.None);
            UiDisplayStack.Push(SelectUIKind.PartsSelection);
            UiDisplayStack.Push(partsInfo.UIKind);
            if (retDialog == DialogResult.Retry)
            {
                do
                {
                    switch (partsInfo.UIKind)
                    {
                        case SelectUIKind.Subst:
                            retDialog = SelectionSubstParts.ShowDialog(owner, partsInfo);
                            if (retDialog == DialogResult.OK)
                            {
                                if (partsInfo.SubstSrcSelInf != null && partsInfo.SubstSrcSelInf.ListPlrlSubst.Count > 0)
                                {
                                    partsInfo.SubstSrcSelInf.RowGoods.NewGoodsNo = partsInfo.SubstSrcSelInf.ListPlrlSubst[0].RowGoods.GoodsNo;
                                }
                                //PartsInfoDataSet.UsrSubstPartsRow substRow = partsInfo.UsrSubstParts.GetSelectedRow(DataViewRowState.ModifiedCurrent);
                                //if (substRow != null)
                                //{
                                //    substRow.SelectionState = false; // �����̏����݂̂̂��߂Ȃ̂ŁA�O�̂��߃N���A����B
                                //    PartsInfoDataSet.UsrGoodsInfoRow goodsInfoRow
                                //        = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(substRow.ChgSrcMakerCd, substRow.ChgSrcGoodsNo);
                                //    if (goodsInfoRow != null)
                                //    {
                                //        goodsInfoRow.NewGoodsNo = substRow.ChgDestGoodsNo;
                                //        //goodsInfoRow.NewMakerCd = substRow.ChgDestMakerCd;
                                //    }
                                //}
                                //else
                                //{
                                //    if (partsInfo.UsrGoodsInfo.RowToProcess.SelectionState) // ��ւƂ��đ�֌��i�Ԃ��I�����ꂽ�ꍇ
                                //    { // �񋟏����̃J�^���O�i�ԂƍŐV�i�Ԃ��قȂ�ꍇ�A�J�^���O�i�Ԃ̕��i��I�Ԃ��߂ɂ��̏������K�v
                                //        partsInfo.UsrGoodsInfo.RowToProcess.NewGoodsNo = partsInfo.UsrGoodsInfo.RowToProcess.GoodsNo;
                                //    } // ��֕i�ԂƂ��Ď������g�̕i�Ԃ�ݒ肵�Ă����A�J�^���O�i�Ԃ��I���ł���悤�ɂ���B
                                //}
                            }
                            break;
                        case SelectUIKind.PartsSelection:
                            if (originalPartsFlg == 1) // �I���W�i�����i����
                            {
                                retDialog = frmPrmBLParts.ShowDialog(owner);//SelectionPrimeSearchParts.ShowDialog(partsInfo);
                            }
                            else if (originalPartsFlg == 2) // TBO
                            {
                                retDialog = SelectionCarInfoJoinParts.ShowDialog(owner, carInfo, partsInfo);
                            }
                            else
                            {
                                retDialog = frmClgParts.ShowDialog(owner);
                            }
                            break;
                    }
                    if (retDialog == DialogResult.Retry)
                    {
                        oldUI = partsInfo.UIKind;
                        //partsInfo.AcceptChanges();
                    }
                    //else if (retDialog == DialogResult.Abort)
                    //{
                    //    retDialog = DialogResult.Cancel;
                    //    break;
                    //}
                    else
                    {
                        if (UiDisplayStack.Count == 0)
                            break;
                        if (UiDisplayStack.Peek() == oldUI)
                            UiDisplayStack.Pop();
                        partsInfo.UIKind = UiDisplayStack.Pop();
                        oldUI = partsInfo.UIKind;
                        partsInfo.UsrGoodsInfo.SetPreviousRowToCurrentRow();
                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                        }
                        else
                        {
                            partsInfo.AcceptChanges();
                        }
                    }
                    if (oldUI != SelectUIKind.None)
                        UiDisplayStack.Push(oldUI);
                } while (UiDisplayStack.Count > 0);
            }

            //>>>2010/07/01
            if (frmPrmBLParts != null) frmPrmBLParts.Dispose();
            if (frmClgParts != null) frmClgParts.Dispose();
            //<<<2010/07/01

            return retDialog;
        }

        /// <summary>
        /// ����i�ԑI��UI���䃁�\�b�h
        /// </summary>
        /// <param name="partsInfo"></param>    
        /// <param name="flg"></param>
        /// <returns></returns>
        private static DialogResult ShowSamePartsNoUI(IWin32Window owner,PartsInfoDataSet partsInfo, SearchFlag flg)
        {
            DialogResult retDialog = DialogResult.OK;
            //partsInfo.UsrGoodsInfo.ResetSelectionState();
            SelectionSamePartsNoParts frmSamePartsNo = null;

            if (flg == SearchFlag.PartsNoJoinSearch)
            {
                frmSamePartsNo = new SelectionSamePartsNoParts(partsInfo, 1, null);
            }
            else
            {
                frmSamePartsNo = new SelectionSamePartsNoParts(partsInfo, 2, null);
            }
            retDialog = frmSamePartsNo.ShowDialog(owner);

            Stack<SelectUIKind> UiDisplayStack = new Stack<SelectUIKind>();
            SelectUIKind oldUI = partsInfo.UIKind;
            UiDisplayStack.Push(SelectUIKind.None);
            UiDisplayStack.Push(SelectUIKind.SamePartsNo);
            UiDisplayStack.Push(partsInfo.UIKind);

            if (retDialog == DialogResult.Retry)
            {
                do
                {
                    switch (partsInfo.UIKind)
                    {
                        case SelectUIKind.Subst:
                            retDialog = SelectionSubstParts.ShowDialog(owner, partsInfo);
                            if (retDialog == DialogResult.OK)
                            {
                                if (partsInfo.SubstSrcSelInf != null && partsInfo.SubstSrcSelInf.ListPlrlSubst.Count > 0)
                                {
                                    partsInfo.SubstSrcSelInf.RowGoods.NewGoodsNo = partsInfo.SubstSrcSelInf.ListPlrlSubst[0].RowGoods.GoodsNo;
                                }
                                //PartsInfoDataSet.UsrSubstPartsRow substRow = partsInfo.UsrSubstParts.GetSelectedRow(DataViewRowState.ModifiedCurrent);
                                //if (substRow != null)
                                //{
                                //    substRow.SelectionState = false; // �����̏����݂̂̂��߂Ȃ̂ŁA�O�̂��߃N���A����B
                                //    PartsInfoDataSet.UsrGoodsInfoRow goodsInfoRow
                                //        = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(substRow.ChgSrcMakerCd, substRow.ChgSrcGoodsNo);
                                //    if (goodsInfoRow != null)
                                //    {
                                //        goodsInfoRow.NewGoodsNo = substRow.ChgDestGoodsNo;
                                //        //goodsInfoRow.NewMakerCd = substRow.ChgDestMakerCd;
                                //    }
                                //}
                            }
                            break;
                        case SelectUIKind.SamePartsNo:
                            retDialog = frmSamePartsNo.ShowDialog(owner, retDialog);
                            break;
                    }
                    if (retDialog == DialogResult.Retry)
                    {
                        oldUI = partsInfo.UIKind;
                        //partsInfo.AcceptChanges();
                    }
                    //else if (retDialog == DialogResult.Abort)
                    //{
                    //    retDialog = DialogResult.Cancel;
                    //    break;
                    //}
                    else
                    {
                        if (UiDisplayStack.Count == 0)
                            break;
                        if (UiDisplayStack.Peek() == oldUI)
                            UiDisplayStack.Pop();
                        partsInfo.UIKind = UiDisplayStack.Pop();
                        oldUI = partsInfo.UIKind;
                        partsInfo.UsrGoodsInfo.SetPreviousRowToCurrentRow();
                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                        }
                        else
                        {
                            partsInfo.AcceptChanges();
                        }
                    }
                    if (oldUI != SelectUIKind.None)
                        UiDisplayStack.Push(oldUI);
                } while (UiDisplayStack.Count > 0);
            }

            if (frmSamePartsNo != null) frmSamePartsNo.Dispose(); // 2010/07/01

            return retDialog;
        }

        /// <summary>
        /// �����I��UI���䃁�\�b�h
        /// </summary>
        /// <param name="partsInfo"></param>
        /// <param name="rowToProcess"></param>
        /// <returns></returns>
        private static DialogResult ShowJoinUI(IWin32Window owner, PartsInfoDataSet partsInfo, PartsInfoDataSet.UsrGoodsInfoRow rowToProcess)
        {
            //partsInfo.UsrGoodsInfo.ResetSelectionState();
            partsInfo.UsrGoodsInfo.RowToProcess = rowToProcess;
            SelectionFormJ frmJoinParts = new SelectionFormJ(partsInfo);
            DialogResult retDialog = frmJoinParts.ShowDialog(owner);

            Stack<SelectUIKind> UiDisplayStack = new Stack<SelectUIKind>();
            SelectUIKind oldUI = partsInfo.UIKind;
            UiDisplayStack.Push(SelectUIKind.None);
            UiDisplayStack.Push(SelectUIKind.Join);
            UiDisplayStack.Push(partsInfo.UIKind);
            if (retDialog == DialogResult.Retry)
            {
                do
                {
                    switch (partsInfo.UIKind)
                    {
                        case SelectUIKind.Subst:
                            retDialog = SelectionSubstParts.ShowDialog(owner, partsInfo);
                            if (retDialog == DialogResult.OK)
                            {
                                if (partsInfo.SubstSrcSelInf != null && partsInfo.SubstSrcSelInf.ListPlrlSubst.Count > 0)
                                {
                                    partsInfo.SubstSrcSelInf.RowGoods.NewGoodsNo = partsInfo.SubstSrcSelInf.ListPlrlSubst[0].RowGoods.GoodsNo;
                                }
                                //PartsInfoDataSet.UsrSubstPartsRow substRow = partsInfo.UsrSubstParts.GetSelectedRow(DataViewRowState.ModifiedCurrent);
                                //if (substRow != null)
                                //{
                                //    substRow.SelectionState = false; // �����̏����݂̂̂��߂Ȃ̂ŁA�O�̂��߃N���A����B
                                //    PartsInfoDataSet.UsrGoodsInfoRow goodsInfoRow
                                //        = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(substRow.ChgSrcMakerCd, substRow.ChgSrcGoodsNo);
                                //    if (goodsInfoRow != null)
                                //    {
                                //        goodsInfoRow.NewGoodsNo = substRow.ChgDestGoodsNo;
                                //        //goodsInfoRow.NewMakerCd = substRow.ChgDestMakerCd;
                                //    }
                                //}
                            }
                            break;
                        case SelectUIKind.Join:
                            if (frmJoinParts == null) frmJoinParts = new SelectionFormJ(partsInfo);
                            retDialog = frmJoinParts.ShowDialog(owner);
                            break;
                    }
                    if (retDialog == DialogResult.Retry)
                    {
                        oldUI = partsInfo.UIKind;
                        //partsInfo.AcceptChanges();
                    }
                    //else if (retDialog == DialogResult.Abort)
                    //{
                    //    retDialog = DialogResult.Cancel;
                    //    break;
                    //}
                    else
                    {
                        if (UiDisplayStack.Count == 0)
                            break;
                        if (UiDisplayStack.Peek() == oldUI)
                            UiDisplayStack.Pop();
                        partsInfo.UIKind = UiDisplayStack.Pop();
                        oldUI = partsInfo.UIKind;
                        partsInfo.UsrGoodsInfo.SetPreviousRowToCurrentRow();
                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                        }
                        else
                        {
                            partsInfo.AcceptChanges();
                        }
                    }
                    if (oldUI != SelectUIKind.None)
                        UiDisplayStack.Push(oldUI);
                } while (UiDisplayStack.Count > 0);
            }

            if (frmJoinParts != null) frmJoinParts.Dispose(); // 2010/07/01

            return retDialog;
        }

        /// <summary>
        /// �Z�b�g�I��UI���䃁�\�b�h
        /// </summary>
        /// <param name="partsInfo"></param>
        /// <param name="rowToProcess"></param>
        /// <returns></returns>
        private static DialogResult ShowSetUI(IWin32Window owner, PartsInfoDataSet partsInfo, PartsInfoDataSet.UsrGoodsInfoRow rowToProcess)
        {
            //partsInfo.UsrGoodsInfo.ResetSelectionState();
            partsInfo.UsrGoodsInfo.RowToProcess = rowToProcess;
            SelectionFormSet frmSetParts = new SelectionFormSet(partsInfo);
            DialogResult retDialog = frmSetParts.ShowDialog(owner);

            Stack<SelectUIKind> UiDisplayStack = new Stack<SelectUIKind>();
            SelectUIKind oldUI = partsInfo.UIKind;
            UiDisplayStack.Push(SelectUIKind.None);
            UiDisplayStack.Push(SelectUIKind.Set);
            UiDisplayStack.Push(partsInfo.UIKind);
            if (retDialog == DialogResult.Retry)
            {
                do
                {
                    switch (partsInfo.UIKind)
                    {
                        case SelectUIKind.Subst:
                            retDialog = SelectionSubstParts.ShowDialog(owner, partsInfo);
                            if (retDialog == DialogResult.OK)
                            {
                                if (partsInfo.SubstSrcSelInf != null && partsInfo.SubstSrcSelInf.ListPlrlSubst.Count > 0)
                                {
                                    partsInfo.SubstSrcSelInf.RowGoods.NewGoodsNo = partsInfo.SubstSrcSelInf.ListPlrlSubst[0].RowGoods.GoodsNo;
                                }
                                //PartsInfoDataSet.UsrSubstPartsRow substRow = partsInfo.UsrSubstParts.GetSelectedRow(DataViewRowState.ModifiedCurrent);
                                //if (substRow != null)
                                //{
                                //    substRow.SelectionState = false; // �����̏����݂̂̂��߂Ȃ̂ŁA�O�̂��߃N���A����B
                                //    PartsInfoDataSet.UsrGoodsInfoRow goodsInfoRow
                                //        = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(substRow.ChgSrcMakerCd, substRow.ChgSrcGoodsNo);
                                //    if (goodsInfoRow != null)
                                //    {
                                //        goodsInfoRow.NewGoodsNo = substRow.ChgDestGoodsNo;
                                //        //goodsInfoRow.NewMakerCd = substRow.ChgDestMakerCd;
                                //    }
                                //}
                            }
                            break;
                        case SelectUIKind.Set:
                            if (frmSetParts == null) frmSetParts = new SelectionFormSet(partsInfo);
                            retDialog = frmSetParts.ShowDialog(owner);
                            break;
                    }
                    if (retDialog == DialogResult.Retry)
                    {
                        oldUI = partsInfo.UIKind;
                        //partsInfo.AcceptChanges();
                    }
                    //else if (retDialog == DialogResult.Abort)
                    //{
                    //    retDialog = DialogResult.Cancel;
                    //    break;
                    //}
                    else
                    {
                        if (UiDisplayStack.Count == 0)
                            break;
                        if (UiDisplayStack.Peek() == oldUI)
                            UiDisplayStack.Pop();
                        partsInfo.UIKind = UiDisplayStack.Pop();
                        oldUI = partsInfo.UIKind;
                        partsInfo.UsrGoodsInfo.SetPreviousRowToCurrentRow();
                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                        }
                        else
                        {
                            partsInfo.AcceptChanges();
                        }
                    }
                    if (oldUI != SelectUIKind.None)
                        UiDisplayStack.Push(oldUI);
                } while (UiDisplayStack.Count > 0);
            }

            if (frmSetParts != null) frmSetParts.Dispose(); // 2010/07/01

            return retDialog;
        }

        //------------ADD 2009/10/20--------->>>>>
        /// <summary>
        /// �W�����i�I��UI���䃁�\�b�h
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="carInfo">�ԗ��������ʃf�[�^�N���X</param>
        /// <param name="partsInfo">���i�������ʃf�[�^�Z�b�g</param>
        /// <param name="rowToProcess">UsrGoodsInfoRow</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �W�����i�I��UI�\���A���͂��s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/10/20</br>
        /// <br>Update Note: 2011/11/21 ����� Redmine#7876�̑Ή�</br>
        /// <br>             ������i�Ԃ�I��������ł͂Ȃ��̂ŕW�����i�I���E�C���h�̕\�����s��Ȃ��l�ɏC��</br>
        /// <br>Update Note: 2012/04/06 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/05/24�z�M��</br>
        /// <br>             Redmine#29153   �W�����i�I����ʂ��\������Ȃ��ɂ��Ă̏C��</br>
        /// <br>Update Note: 2012/06/11 gezh</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// <br>             Redmine#30392 ����`�[���� �W�����i�I��\���̑Ή�</br>
        /// </remarks>
        //private static DialogResult ShowPriceUI(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet partsInfo) // DEL 2009/11/17
        private static DialogResult ShowPriceUI(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet partsInfo, PartsInfoDataSet.UsrGoodsInfoRow rowToProcess) // ADD 2009/11/17
        {
            DialogResult retDialog = DialogResult.OK;
            //------------DEL 2009/11/17--------->>>>>
            //// �i��
            //string goodsNo = string.Empty;
            //// ���[�J�[�R�[�h
            //int goodsMakerCode = 0;
            //// BL�R�[�h
            //int bLGoodsCode = 0;
            //// �����^�D��
            //int goodsKindCode = 0;
            //------------DEL 2009/11/17---------<<<<<
            // �D�Ǖi�Ԍ���
            bool goodSearch = false;
            // �����I���őI�����ꂽ�D�Ǖi��
            bool partsJoinFlag = true;

            PartsInfoDataSet.UsrGoodsInfoRow usrGoodsInfoRow = null;

            //PartsInfoDataSet.UsrGoodsInfoRow row = partsInfo.UsrGoodsInfo.RowToProcess; // ADD 2009/11/30 //DEL ���N�n�� 2012/04/06 Redmine#29153
            PartsInfoDataSet.UsrGoodsInfoRow row = partsInfo.UsrGoodsInfo.RowToProcess; //ADD ������ on 2012/06/26 for Redmine#30595

            //>>>2011/12/16
            SearchFlag flg = partsInfo.SearchCondition.SearchFlg;
            //<<<2011/12/16

            // �Q�Ƃ���N���X��؂�ւ���
            foreach (SelectionInfo selectionInfo in partsInfo.ListSelectionInfo.Values)
            { 
                //---ADD ������ on 2012/06/26 for Redmine#30595---->>>>>
                if (row.GoodsNo != selectionInfo.RowGoods.GoodsNo)
                {
                    continue;
                }
                //---ADD ������ on 2012/06/26 for Redmine#30595----<<<<<
                //---DEL ���N�n�� 2012/04/06 Redmine#29153---->>>>>
                //------------ADD 2009/11/30--------->>>>>
                //if (row.GoodsNo != selectionInfo.RowGoods.GoodsNo)
                //{
                //    continue;
                //}
                //------------ADD 2009/11/30---------<<<<<
                //---DEL ���N�n�� 2012/04/06 Redmine#29153----<<<<<

                // �D�Ǖi�Ԍ������s�����ꍇ
                //if (selectionInfo.RowGoods.GoodsKindCode == 1)  // DEL 2012/06/11 gezh Redmine#30392
                if (selectionInfo.RowGoods.GoodsMakerCd >= 1000)  // ADD 2012/06/11 gezh Redmine#30392
                {
                    // �����I���őI���Ȃ�
                    if (selectionInfo.ListChildGoods.Count == 0)
                    {
                        //>>>2011/12/16
                        //partsJoinFlag = false;  // ADD 2011/11/21

                        if ((int)flg < 2) // BL������
                        {
                            partsJoinFlag = false;
                        }
                        //<<<2011/12/16

                        // ��đI���Ŏq�i�ԑI���Ȃ�
                        if (selectionInfo.ListChildGoods2.Count == 0)
                        {
                            usrGoodsInfoRow = selectionInfo.RowGoods;
                        }
                    }

                    // �D�Ǖi�Ԍ���
                    goodSearch = true;
                }
                // BL�R�[�h����
                // �����i�Ԍ���
                else
                {
                    // �����I���őI������
                    if (selectionInfo.ListChildGoods.Count != 0)
                    {
                        foreach (SelectionInfo selectionInfo2 in selectionInfo.ListChildGoods.Values)
                        {
                            //if (selectionInfo2.RowGoods.GoodsKindCode == 0)  // DEL 2012/06/11 gezh Redmine#30392
                            if (selectionInfo2.RowGoods.GoodsMakerCd < 1000)  // ADD 2012/06/11 gezh Redmine#30392
                            {
                                partsJoinFlag = false;
                            }

                            // ��đI���Ŏq�i�ԑI���Ȃ�
                            if (selectionInfo2.ListChildGoods.Count == 0)
                            {
                                //------------UPD 2009/11/17--------->>>>>
                                if (rowToProcess.GoodsNo == selectionInfo2.RowGoods.GoodsNo
                                    && rowToProcess.GoodsMakerCd == selectionInfo2.RowGoods.GoodsMakerCd)
                                {
                                    usrGoodsInfoRow = selectionInfo2.RowGoods;
                                    break;
                                }
                                //------------UPD 2009/11/17---------<<<<<
                            }
                            //break; // DEL 2009/11/17 
                        }
                    }
                }
                //break; // DEL 2009/11/30
            }

            // �W�����i�I��UI���䃁�\�b�h
            retDialog = ShowPriceUIProc(owner, carInfo, partsInfo, usrGoodsInfoRow, goodSearch, partsJoinFlag);

            return retDialog;
        }
        //------------ADD 2009/10/20---------<<<<<

        //------------ADD 2009/11/17--------->>>>>
        /// <summary>
        /// �W�����i�I��UI���䃁�\�b�h
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="carInfo">�ԗ��������ʃf�[�^�N���X</param>
        /// <param name="partsInfo">���i�������ʃf�[�^�Z�b�g</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �W�����i�I��UI�\���A���͂��s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/11/17</br>
        /// <br>Update Note: 2011/11/21 ����� Redmine#7876�̑Ή�</br>
        /// <br>             ������i�Ԃ�I��������ł͂Ȃ��̂ŕW�����i�I���E�C���h�̕\�����s��Ȃ��l�ɏC��</br>
        /// <br>Update Note: 2012/04/06 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2012/05/24�z�M��</br>
        /// <br>             Redmine#29153   �W�����i�I����ʂ��\������Ȃ��ɂ��Ă̏C��</br>
        /// <br>Update Note: 2012/06/11 gezh</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// <br>             Redmine#30392 ����`�[���� �W�����i�I��\���̑Ή�</br>
        /// </remarks>
        private static DialogResult ShowPriceUI2(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet partsInfo)
        {
            DialogResult retDialog = DialogResult.OK;
            bool goodSearch = false;
            // �����I���őI�����ꂽ�D�Ǖi��
            bool partsJoinFlag = true;

            PartsInfoDataSet.UsrGoodsInfoRow usrGoodsInfoRow = null;

            //PartsInfoDataSet.UsrGoodsInfoRow row = partsInfo.UsrGoodsInfo.RowToProcess; // ADD 2009/11/30 //DEL ���N�n�� 2012/04/06 Redmine#29153
            PartsInfoDataSet.UsrGoodsInfoRow row = partsInfo.UsrGoodsInfo.RowToProcess; //ADD ������ on 2012/06/26 for Redmine#30595

            //>>>2011/12/16
            SearchFlag flg = partsInfo.SearchCondition.SearchFlg;
            //<<<2011/12/16
            
            // �Q�Ƃ���N���X��؂�ւ���
            foreach (SelectionInfo selectionInfo in partsInfo.ListSelectionInfo.Values)
            {
                //---ADD ������ on 2012/06/26 for Redmine#30595---->>>>>
                if (row.GoodsNo != selectionInfo.RowGoods.GoodsNo)
                {
                    continue;
                }
                //---ADD ������ on 2012/06/26 for Redmine#30595----<<<<<
                //---DEL ���N�n�� 2012/04/06 Redmine#29153---->>>>>
                //------------ADD 2009/11/30--------->>>>>
                //if (row.GoodsNo != selectionInfo.RowGoods.GoodsNo)
                //{
                //    continue;
                //}
                //------------ADD 2009/11/30---------<<<<<
                //---DEL ���N�n�� 2012/04/06 Redmine#29153----<<<<<

                // �D�Ǖi�Ԍ������s�����ꍇ
                //if (selectionInfo.RowGoods.GoodsKindCode == 1)  // DEL 2012/06/11 gezh Redmine#30392
                if (selectionInfo.RowGoods.GoodsMakerCd >= 1000)  // ADD 2012/06/11 gezh Redmine#30392
                {
                    // �����I���őI���Ȃ�
                    if (selectionInfo.ListChildGoods.Count == 0)
                    {
                        //>>>2011/12/16
                        //partsJoinFlag = false;  // ADD 2011/11/21

                        if ((int)flg < 2) // BL������
                        {
                            partsJoinFlag = false;
                        }
                        //<<<2011/12/16

                        // ��đI���Ŏq�i�ԑI���Ȃ�
                        if (selectionInfo.ListChildGoods2.Count == 0)
                        {
                            usrGoodsInfoRow = selectionInfo.RowGoods;
                        }
                    }

                    // �D�Ǖi�Ԍ���
                    goodSearch = true;

                    // �W�����i�I��UI���䃁�\�b�h
                    retDialog = ShowPriceUIProc(owner, carInfo, partsInfo, usrGoodsInfoRow, goodSearch, partsJoinFlag);
                }
                // BL�R�[�h����
                // �����i�Ԍ���
                else
                {
                    // �����I���őI������
                    if (selectionInfo.ListChildGoods.Count != 0)
                    {
                        foreach (SelectionInfo selectionInfo2 in selectionInfo.ListChildGoods.Values)
                        {
                            //if (selectionInfo2.RowGoods.GoodsKindCode == 0)  // DEL 2012/06/11 gezh Redmine#30392
                            if (selectionInfo2.RowGoods.GoodsMakerCd < 1000)  // ADD 2012/06/11 gezh Redmine#30392
                            {
                                partsJoinFlag = false;
                            }

                            // ��đI���Ŏq�i�ԑI���Ȃ�
                            if (selectionInfo2.ListChildGoods.Count == 0)
                            {
                                usrGoodsInfoRow = selectionInfo2.RowGoods;

                                // �W�����i�I��UI���䃁�\�b�h
                                retDialog = ShowPriceUIProc(owner, carInfo, partsInfo, usrGoodsInfoRow, goodSearch, partsJoinFlag);
                            }
                        }
                    }
                }
                break;
            }

            return retDialog;
        }

        //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ---------------->>>>>
        /// <summary>
        /// �I�������i�ԏ�񃊃X�g
        /// </summary>
        private static List<GoodsUnitData> _selectedSrcList = new List<GoodsUnitData>();

        /// <summary>
        /// �I�������i�ԏ�񃊃X�g�̎擾
        /// </summary>
        public static List<GoodsUnitData> SelectedSrcList
        {
            get { return UIDisplayControl._selectedSrcList; }
        }

        /// <summary>
        /// �I�������i�ԏ�񃊃X�g�̃N���A
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή�</br>
        /// <br>Programmer : 30757 ���X�� �M�p</br>
        /// <br>Date       : 2015/04/06</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00</br>
        /// <br></br>
        /// <br>Update Note: </br>
        /// <br>           : </br>
        /// <br></br>
        /// </remarks>
        public static void CrearSelectedSrcList()
        {
            UIDisplayControl._selectedSrcList.Clear();
        }
        //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ----------------<<<<<

        /// <summary>
        /// �W�����i�I��UI���䃁�\�b�h
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="carInfo">�ԗ��������ʃf�[�^�N���X</param>
        /// <param name="partsInfo">���i�������ʃf�[�^�Z�b�g</param>
        /// <param name="goodSearch">goodSearch</param>
        /// <param name="partsJoinFlag">�����I���őI�����ꂽ�D�Ǖi��</param>
        /// <param name="usrGoodsInfoRow">usrGoodsInfoRow</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �W�����i�I��UI�\���A���͂��s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/11/17</br>
        /// <br>Update Note: 2012/06/11 gezh</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// <br>             Redmine#30392 ����`�[���� �W�����i�I��\���̑Ή�</br>
        /// <br>Update Note: 2015/04/06 30757 ���X�� �M�p</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00</br>
        /// <br>             �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή�</br>
        /// </remarks>
        private static DialogResult ShowPriceUIProc(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet partsInfo, PartsInfoDataSet.UsrGoodsInfoRow usrGoodsInfoRow,bool goodSearch, bool partsJoinFlag)
        {
            DialogResult retDialog = DialogResult.OK;

            // �i��
            string goodsNo = string.Empty;
            // ���[�J�[�R�[�h
            int goodsMakerCode = 0;
            // BL�R�[�h
            int bLGoodsCode = 0;
            // �����^�D��
            int goodsKindCode = 0;

            if (usrGoodsInfoRow != null)
            {
                goodsNo = usrGoodsInfoRow.GoodsNo;
                goodsMakerCode = usrGoodsInfoRow.GoodsMakerCd;
                bLGoodsCode = usrGoodsInfoRow.BlGoodsCode;
                goodsKindCode = usrGoodsInfoRow.GoodsKindCode;
            }
            else
            {
                return retDialog;
            }

            bool result = false;

            // --- ADD m.suzuki 2011/02/25 ---------->>>>>
            //----------------------------------------
            // �\���敪�v���Z�X���s�O�`�F�b�N
            //----------------------------------------
            // ���D�敪��1:�D��
            // �\���敪�v���Z�X��1:����
            // �����I���őI�����ꂽ�D�Ǖi�ԈȊO
            //if ( goodsKindCode != 1  // DEL 2012/06/11 gezh Redmine#30392
            if (goodsMakerCode < 1000  // ADD 2012/06/11 gezh Redmine#30392
                || partsInfo.PriceSelectDispDiv != 1
                || !partsJoinFlag )
            {
                return retDialog;
            }

            // �i�Ԍ�������"."�������\���敪�}�X�^���X�g�Ȃ��˕\���敪�v���Z�X���Ȃ��Ɠ����Ɣ��f
            if ( (partsInfo.SearchMethod == 1) &&
                 (partsInfo.SearchCondition.SearchFlg != SearchFlag.PartsNoJoinSearch) &&
                 (partsInfo.PriceSelectDivList == null || partsInfo.PriceSelectDivList.Count == 0) )
            {
                return retDialog;
            }

            //----------------------------------------
            // �\���敪�}�X�^�Q��
            //----------------------------------------
            PartsInfoDataSet.UsrGoodsInfoRow row = null;
            //if ( goodsKindCode == 1 )  // DEL 2012/06/11 gezh Redmine#30392
            if (goodsMakerCode >= 1000)  // ADD 2012/06/11 gezh Redmine#30392
            {
                // ���Ӑ�|���O���[�v�R�[�h�̎擾
                result = partsInfo.SettingCustRateGrpCode( partsInfo.CustRateGrpCodeList,
                            partsInfo.CustomerCode,
                            goodsNo,
                            goodsMakerCode );

                if ( !result )
                {
                    return retDialog;
                }

                int custRateGrpCode = -1;
                row = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( goodsMakerCode, goodsNo );

                if ( row != null )
                {
                    custRateGrpCode = row.CustRateGrpCode;
                }
                // �W�����i�I���敪�̎擾
                result = partsInfo.SettingDisplayDiv( partsInfo.PriceSelectDivList,
                    goodsNo,
                    goodsMakerCode,
                    bLGoodsCode,
                    partsInfo.CustomerCode,
                    custRateGrpCode );

                if ( !result )
                {
                    return retDialog;
                }

                // �i�Ԍ�������"."�������\���敪�ݒ�}�X�^�ɖ��o�^�˕\���敪�v���Z�X���Ȃ��Ɠ����Ɣ��f
                if ( (partsInfo.SearchMethod == 1) &&
                     (partsInfo.SearchCondition.SearchFlg != SearchFlag.PartsNoJoinSearch) &&
                     (row.PriceSelectDiv < 0) )
                {
                    return retDialog;
                }
            }
            // --- ADD m.suzuki 2011/02/25 ----------<<<<<

            // �i�Ԍ�����A�������������s���������������̎擾
            // �i�Ԍ����̏ꍇ
            // --- UPD m.suzuki 2011/05/12 ---------->>>>>
            # region // DEL
            //// --- UPD m.suzuki 2011/02/24 ---------->>>>>
            ////// --- UPD m.suzuki 2011/01/27 ---------->>>>>
            ////////>>>2010/12/14
            ////////// -- UPD 2010/04/16 ----------------------------->>>
            ////////// �D�ǂ̌��������L��̏ꍇ�̂݁A�������������s���悤�ɏC��
            //////////if ((int)partsInfo.SearchCondition.SearchFlg >= 2
            //////////    && goodsKindCode == 1)
            ////////if ( (int)partsInfo.SearchCondition.SearchFlg >= 4
            ////////    && goodsKindCode == 1 )
            ////////// -- UPD 2010/04/16 -----------------------------<<<
            //////
            //////// �������������ł��A�D�Ǖi�Ԍ����̏ꍇ�A�������s��
            //////if (((int)partsInfo.SearchCondition.SearchFlg >= 4 && goodsKindCode == 1) ||
            //////    (usrGoodsInfoRow.OfferKubun == 2) || (usrGoodsInfoRow.OfferKubun == 4))
            ////////<<<2010/12/14
            ////
            ////// �������������ł��A�D�Ǖi�Ԍ����̏ꍇ�A�������s��
            ////// �������������ł��A��ւ���Ȃ��֐�̌�����������ɂ���ׂɁA�������s��
            ////if ( ((int)partsInfo.SearchCondition.SearchFlg >= 4 && goodsKindCode == 1) ||
            ////     (usrGoodsInfoRow.OfferKubun == 2) || (usrGoodsInfoRow.OfferKubun == 4) ||
            ////     (partsInfo.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo && (partsInfo.UsrJoinParts.Count > 0 || partsInfo.JoinParts.Count > 0)) )
            ////// --- UPD m.suzuki 2011/01/27 ----------<<<<<
            //
            //// �������������ł��A�D�Ǖi�Ԍ����̏ꍇ�A�������s��
            //// �������������ł��A��ւ���Ȃ��֐�̌�����������ɂ���ׂɁA�������s��
            //if ( ((int)partsInfo.SearchCondition.SearchFlg >= 4 && goodsKindCode == 1) ||
            //     ((partsInfo.SearchMethod == 1) && ((usrGoodsInfoRow.OfferKubun == 2) || (usrGoodsInfoRow.OfferKubun == 4))) ||
            //     (partsInfo.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo && (partsInfo.UsrJoinParts.Count > 0 || partsInfo.JoinParts.Count > 0)) )
            //// --- UPD m.suzuki 2011/02/24 ----------<<<<<
            # endregion
            // �����������t���O(true:���������������s����)
            bool srcPartsSearchFlag = false;

            if ( partsInfo.SearchMethod == 1 && ((usrGoodsInfoRow.OfferKubun == 2) || (usrGoodsInfoRow.OfferKubun == 4)) )
            {
                // �i�Ԍ����E�D�Ǖi��
                if ( row.PriceSelectDiv == 0 )
                {
                    // �i�Ԍ����E�D�Ǖi�ԁE�\���敪�}�X�^���D�ǁˌ������������Ȃ�
                    srcPartsSearchFlag = false;
                }
                else
                {
                    // ���̑��́A�i�Ԍ����E�D�Ǖi�ԁˌ�������������
                    srcPartsSearchFlag = true;
                }
            }
            //else if ( (int)partsInfo.SearchCondition.SearchFlg >= 4 && goodsKindCode == 1 )  // DEL 2012/06/11 gezh Redmine#30392
            else if ((int)partsInfo.SearchCondition.SearchFlg >= 4 && goodsMakerCode >= 1000)  // ADD 2012/06/11 gezh Redmine#30392
            {
                // ������������("."�t)�ˌ��������������s
                srcPartsSearchFlag = true;
            }
            else if ( partsInfo.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo && (partsInfo.UsrJoinParts.Count > 0 || partsInfo.JoinParts.Count > 0) )
            {
                // ���������Ȃ��ł��A��ւ���̏ꍇ�͑�֐�̌�����������ɂ���ˌ�������������
                srcPartsSearchFlag = true;
            }

            // ��������������
            if ( srcPartsSearchFlag )
            // --- UPD m.suzuki 2011/05/12 ----------<<<<<
            {
                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = partsInfo.SearchCondition.EnterpriseCode;
                goodsCndtn.SectionCode = partsInfo.SearchCondition.SectionCode;
                goodsCndtn.GoodsMakerCd = goodsMakerCode;
                goodsCndtn.GoodsNo = goodsNo;
                // ��������������PartsInfoDataSet�֐ݒ肷��B
                result = partsInfo.SettingSrcPartsInfo(goodsCndtn);

                // �������s�ꍇ
                if (!result)
                {
                    return retDialog;
                }

                // ������������񂪂Ȃ��ꍇ
                if (partsInfo.PartsInfoDataSetSrcParts == null)
                {
                    return retDialog;
                }
            }

            // --- DEL m.suzuki 2011/02/25 ---------->>>>> // �����������̑O�Ɉړ�
            //PartsInfoDataSet.UsrGoodsInfoRow row = null;
            //if (goodsKindCode == 1)
            //{
            //    // ���Ӑ�|���O���[�v�R�[�h�̎擾
            //    result = partsInfo.SettingCustRateGrpCode(partsInfo.CustRateGrpCodeList,
            //                partsInfo.CustomerCode,
            //                goodsNo,
            //                goodsMakerCode);

            //    if (!result)
            //    {
            //        return retDialog;
            //    }

            //    int custRateGrpCode = -1;
            //    row = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(goodsMakerCode, goodsNo);

            //    if (row != null)
            //    {
            //        custRateGrpCode = row.CustRateGrpCode;
            //    }
            //    // �W�����i�I���敪�̎擾
            //    result = partsInfo.SettingDisplayDiv(partsInfo.PriceSelectDivList,
            //        goodsNo,
            //        goodsMakerCode,
            //        bLGoodsCode,
            //        partsInfo.CustomerCode,
            //        custRateGrpCode);

            //    if (!result)
            //    {
            //        return retDialog;
            //    }
            //}
            // --- DEL m.suzuki 2011/02/25 ----------<<<<<

            // �W�����i�I���E�C���h�E�̕\������
            // �m�肵���i�Ԃ��D�ǂ̏ꍇ
            // �艿�ɑ΂���|�����q�b�g���Ă��Ȃ��ꍇ
            // �W�����i�I��\���敪���u����v�̏ꍇ
            // --- UPD m.suzuki 2011/05/12 ---------->>>>>
            //if (goodsKindCode == 1
            //    && partsInfo.PriceSelectDispDiv == 1
            //    && partsJoinFlag)
            //if (goodsKindCode == 1  // DEL 2012/06/11 gezh Redmine#30392
            if (goodsMakerCode >= 1000  // ADD 2012/06/11 gezh Redmine#30392
                && partsInfo.PriceSelectDispDiv == 1
                && partsJoinFlag
                && row.PriceSelectDiv != 0 )
            // --- UPD m.suzuki 2011/05/12 ----------<<<<<
            {
                // �D�Ǖi�Ԍ�����(*1)�ŁA�������܂ތ������s�����ꍇ
                if (goodSearch)
                {
                    //>>>2010/12/14
                    //if ((int)partsInfo.SearchCondition.SearchFlg < 4)
                    //{
                    //    return retDialog;
                    //}

                    // �������������ł��A�D�Ǖi�Ԍ����̏ꍇ�͏I�����Ȃ�
                    if (((int)partsInfo.SearchCondition.SearchFlg < 4) &&
                        (usrGoodsInfoRow.OfferKubun != 2) && (usrGoodsInfoRow.OfferKubun != 4))
                    {
                        return retDialog;
                    }
                    //<<<2010/12/14
                }

                // RateDivLPrice�̒l�́A(*1)�őΏۂƂȂ镔�i���ŎZ�o����эX�V���s���B
                if (partsInfo.CalculateGoodsPrice == null) return retDialog;

                List<PartsInfoDataSet.GoodsPrimaryKey> goodsPrimaryKeyList = new List<PartsInfoDataSet.GoodsPrimaryKey>();

                // ������
                goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(goodsNo, goodsMakerCode));

                // ���i��񂪑��݂���ꍇ�͉��i�v�Z
                if (goodsPrimaryKeyList.Count > 0)
                {
                    partsInfo.SettingGoodsPrice(goodsPrimaryKeyList);
                }

                row = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(goodsMakerCode, goodsNo);

                int priceSelectDiv = -1;
                if (row != null)
                {
                    if (!string.IsNullOrEmpty(row.RateDivLPrice))
                    {
                        return retDialog;
                    }
                    priceSelectDiv = row.PriceSelectDiv;
                }

                // --- UPD m.suzuki 2011/02/10 ---------->>>>>
                # region // DEL
                ////>>>2011/01/13
                //////>>>2010/12/14
                ////// �D�Ǖi�Ԍ������s���A�������������A�\���敪�}�X�^�Y�������̏ꍇ�A�W�����i�E�C���h�E�\������
                ////if (((int)partsInfo.SearchCondition.SearchFlg < 4) &&
                ////    ((usrGoodsInfoRow.OfferKubun == 2) || (usrGoodsInfoRow.OfferKubun == 4)) &&
                ////    (priceSelectDiv == -1))
                ////{
                ////    return retDialog;
                ////}
                //////<<<2010/12/14
                //
                //// �D�Ǖi�Ԍ������s���A�������������A�\���敪�}�X�^�Y�������̏ꍇ�A�W�����i�E�C���h�E�\������
                //if (((int)partsInfo.SearchCondition.SearchFlg >= 2) && // BL�R�[�h�����͔���ΏۊO
                //    // --- ADD m.suzuki 2011/01/27 ---------->>>>>
                //    ((int)partsInfo.SearchCondition.SearchFlg != 3 || (partsInfo.UsrJoinParts.Count == 0 && partsInfo.JoinParts.Count == 0)) &&
                //    // --- ADD m.suzuki 2011/01/27 ----------<<<<<
                //    ((int)partsInfo.SearchCondition.SearchFlg < 4) &&
                //    ((usrGoodsInfoRow.OfferKubun == 2) || (usrGoodsInfoRow.OfferKubun == 4)) &&
                //    (priceSelectDiv == -1))
                //{
                //    return retDialog;
                //}
                ////<<<2011/01/13
                # endregion
                // �D�Ǖi�Ԍ������s���A�������������A�\���敪�}�X�^�Y�������̏ꍇ�A�W�����i�E�C���h�E�\������
                if ( ((int)partsInfo.SearchCondition.SearchFlg >= 2) && // BL�R�[�h�����͔���ΏۊO
                    ((int)partsInfo.SearchCondition.SearchFlg < 4) &&
                    ((usrGoodsInfoRow.OfferKubun == 2) || (usrGoodsInfoRow.OfferKubun == 4)) &&
                    (priceSelectDiv == -1) )
                {
                    return retDialog;
                }
                // --- UPD m.suzuki 2011/02/10 ----------<<<<<

                // �W�����i�I���E�C���h�E�\������
                SelectionListPrice frmSetPrice = new SelectionListPrice(goodsMakerCode, goodsNo, carInfo, partsInfo, priceSelectDiv);
                retDialog = frmSetPrice.ShowDialog(owner);
                //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ---------------->>>>>

                // �W�����i�I���E�C���h�E��[1:�W��]�ȊO���I���i������(����)�i���m��j���ꂽ�ꍇ
                // �I�������i�ԏ�񃊃X�g�ɑΏۂ̗D�Ǖi�̌�����(����)�i����ǉ�����B
                if (!string.IsNullOrEmpty(frmSetPrice.SrcGoodsNo))
                {
                    GoodsUnitData nowGoodsUnitData = new GoodsUnitData();
                    nowGoodsUnitData.BLGoodsCode = usrGoodsInfoRow.BlGoodsCode;
                    nowGoodsUnitData.GoodsNo = usrGoodsInfoRow.GoodsNo;
                    nowGoodsUnitData.GoodsMakerCd = usrGoodsInfoRow.GoodsMakerCd;
                    nowGoodsUnitData.JoinSourceMakerCode = frmSetPrice.SrcGoodsMakerCode;
                    nowGoodsUnitData.JoinSrcPartsNoWithH = (string)frmSetPrice.SrcGoodsNo.Clone();

                    _selectedSrcList.Add(nowGoodsUnitData);
                }
                //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ----------------<<<<<
                frmSetPrice.Dispose(); // 2010/07/01
            }
            else
            {
                return retDialog;
            }

            return retDialog;
        }
        //------------ADD 2009/11/17---------<<<<<
        #endregion
    }
}
