//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���o�����ڍ׉��
// �v���O�����T�v   : ���o�����ڍ׉��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����Y
// �� �� ��  2011/08/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/08/24  �C�����e : Redmine #23930�@�\�[�X���r���[���ʑΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI���� �f��
// �� �� ��  2012.07.26  �C�����e : ���o�f�[�^�ɏ]�ƈ��A���[�U�[�K�C�h�A���������ڂɒǉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    ///<summary>
    /// ���o�����ڍ׉��
    /// </summary>
    /// <remarks>
    /// Note       : ���o�����ڍ׉��<br />
    /// Programmer : �����Y<br />
    /// Date       : 2011/08/01<br />
    /// Update     : <br />
    /// </remarks>
    public partial class PMKYO09401UB : Form
    {
        #region �� Constructor ��
        public PMKYO09401UB(SndRcvHisWork sndRcvHisWork, object searchResult)
        {
            InitializeComponent();

            // �ϐ�������
            //�����O�b���h
            detailsTable = new DataTable();
            _searchResult = searchResult;
            _sndRcvHisWork = sndRcvHisWork;

            // �{�^���ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Close"];
        }
        #endregion �� Constructor ��

        #region �� Const Memebers ��
        private const String ENT_CODE = "��ƃR�[�h";
        private const String SECTION = "���_";
        private const String SEND_NO = "���M�ԍ�";
        private const String SEND_NO_DIV = "���M�ԍ��}��";
        private const String GET_DATA_TYPE = "���o�f�[�^";
        private const String GET_START_DATE = "���o�J�n����";
        private const String GET_END_DATE = "���o�I������";
        private const String START_CONDITION1 = "�J�n�����P";
        private const String END_CONDITION1 = "�I�������P";

        private const String START_CONDITION2 = "�J�n�����Q";
        private const String END_CONDITION2 = "�I�������Q";

        private const String START_CONDITION3 = "�J�n�����R";
        private const String END_CONDITION3 = "�I�������R";

        private const String START_CONDITION4 = "�J�n�����S";
        private const String END_CONDITION4 = "�I�������S";

        private const String START_CONDITION5 = "�J�n�����T";
        private const String END_CONDITION5 = "�I�������T";

        private const String START_CONDITION6 = "�J�n�����U";
        private const String END_CONDITION6 = "�I�������U";

        private const String START_CONDITION7 = "�J�n�����V";
        private const String END_CONDITION7 = "�I�������V";

        private const String START_CONDITION8 = "�J�n�����W";
        private const String END_CONDITION8 = "�I�������W";

        private const String START_CONDITION9 = "�J�n�����X";
        private const String END_CONDITION9 = "�I�������X";

        private const String START_CONDITION10 = "�J�n�����P�O";
        private const String END_CONDITION10 = "�I�������P�O";

        private const String CustomerRF = "���Ӑ�}�X�^";
        private const String GoodsURF = "���i�}�X�^";
        private const String StockRF = "�݌Ƀ}�X�^";
        private const String SupplierRF = "�d����}�X�^";
        private const String RateRF = "�|���}�X�^";
        // --- ADD 2012/07/26 ---------->>>>>
        private const String EmployeeDtlRF = "�]�ƈ��ݒ�}�X�^";
        private const String UserGdBdURF = "���[�U�[�K�C�h�}�X�^(�̔��敪)";
        private const String JoinPartsURF = "�����}�X�^";
        // --- ADD 2012/07/26 ----------<<<<<
        #endregion �� Const Memebers ��

        #region �� Private Field ��
        /// <summary>
        /// ���o�����ڍ׃O�b���h
        /// </summary>
        private DataTable detailsTable;
        private object _searchResult;
        private SndRcvHisWork _sndRcvHisWork;
        private string _loginName;
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        #endregion �� Private Field ��

        #region �� Public Method ��

        #endregion �� Public Method ��

        #region �� Event ��
        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">ToolClickEventArgs</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�N���b�N�C�x���g</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // ��ʂ̏I��
                case "ButtonTool_Close":
                    {
                        //��ʕ���B
                        this.Close();
                    }
                    break;
            }
        }

        /// <summary>
        /// ��ʃ��[�h�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note       : ��ʃ��[�h�C�x���g</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void PMKYO09401UB_Load(object sender, EventArgs e)
        {
            this.DataSetColumnConstruction();
            this.ButtonInitialSetting();
            this.SetColumnStyle();

            // �ڍ׏���\������
            this.DetailShow();
        }
        #endregion �� Event ��

        #region �� Private Method ��
        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g����\�z�����ł�</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            this.detailsTable.Columns.Add(ENT_CODE, typeof(string));
            this.detailsTable.Columns.Add(SECTION, typeof(string));
            this.detailsTable.Columns.Add(SEND_NO, typeof(string));
            this.detailsTable.Columns.Add(SEND_NO_DIV, typeof(string));
            this.detailsTable.Columns.Add(GET_DATA_TYPE, typeof(string));
            this.detailsTable.Columns.Add(GET_START_DATE, typeof(string));
            this.detailsTable.Columns.Add(GET_END_DATE, typeof(string));
            this.detailsTable.Columns.Add(START_CONDITION1, typeof(string));
            this.detailsTable.Columns.Add(END_CONDITION1, typeof(string));

            this.detailsTable.Columns.Add(START_CONDITION2, typeof(string));
            this.detailsTable.Columns.Add(END_CONDITION2, typeof(string));

            this.detailsTable.Columns.Add(START_CONDITION3, typeof(string));
            this.detailsTable.Columns.Add(END_CONDITION3, typeof(string));

            this.detailsTable.Columns.Add(START_CONDITION4, typeof(string));
            this.detailsTable.Columns.Add(END_CONDITION4, typeof(string));

            this.detailsTable.Columns.Add(START_CONDITION5, typeof(string));
            this.detailsTable.Columns.Add(END_CONDITION5, typeof(string));

            this.detailsTable.Columns.Add(START_CONDITION6, typeof(string));
            this.detailsTable.Columns.Add(END_CONDITION6, typeof(string));

            this.detailsTable.Columns.Add(START_CONDITION7, typeof(string));
            this.detailsTable.Columns.Add(END_CONDITION7, typeof(string));

            this.detailsTable.Columns.Add(START_CONDITION8, typeof(string));
            this.detailsTable.Columns.Add(END_CONDITION8, typeof(string));

            this.detailsTable.Columns.Add(START_CONDITION9, typeof(string));
            this.detailsTable.Columns.Add(END_CONDITION9, typeof(string));

            this.detailsTable.Columns.Add(START_CONDITION10, typeof(string));
            this.detailsTable.Columns.Add(END_CONDITION10, typeof(string));

            this.uGrid_Details.DataSource = detailsTable;
        }

        /// <summary>
        /// ���R�[�h�̗�̃X�^�C���̐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���R�[�h�̗�̃X�^�C���̐ݒ�</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void SetColumnStyle()
        {

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            // �\�����ݒ�
            Columns[this.detailsTable.Columns[ENT_CODE].ColumnName].Width = 200;
            Columns[this.detailsTable.Columns[SECTION].ColumnName].Width = 150;
            Columns[this.detailsTable.Columns[SEND_NO].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[SEND_NO_DIV].ColumnName].Width = 100;
            // --- DEL 2012/07/26 ---------->>>>>
            //Columns[this.detailsTable.Columns[GET_DATA_TYPE].ColumnName].Width = 110;
            // --- DEL 2012/07/26 ----------<<<<<
            // --- ADD 2012/07/26 ---------->>>>>
            Columns[this.detailsTable.Columns[GET_DATA_TYPE].ColumnName].Width = 250;
            // --- ADD 2012/07/26 ----------<<<<<
            Columns[this.detailsTable.Columns[GET_START_DATE].ColumnName].Width = 200;
            Columns[this.detailsTable.Columns[GET_END_DATE].ColumnName].Width = 200;
            Columns[this.detailsTable.Columns[START_CONDITION1].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[END_CONDITION1].ColumnName].Width = 100;

            Columns[this.detailsTable.Columns[START_CONDITION2].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[END_CONDITION2].ColumnName].Width = 100;

            Columns[this.detailsTable.Columns[START_CONDITION3].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[END_CONDITION3].ColumnName].Width = 100;

            Columns[this.detailsTable.Columns[START_CONDITION4].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[END_CONDITION4].ColumnName].Width = 100;

            Columns[this.detailsTable.Columns[START_CONDITION5].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[END_CONDITION5].ColumnName].Width = 100;

            Columns[this.detailsTable.Columns[START_CONDITION6].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[END_CONDITION6].ColumnName].Width = 100;

            Columns[this.detailsTable.Columns[START_CONDITION7].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[END_CONDITION7].ColumnName].Width = 100;

            Columns[this.detailsTable.Columns[START_CONDITION8].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[END_CONDITION8].ColumnName].Width = 100;

            Columns[this.detailsTable.Columns[START_CONDITION9].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[END_CONDITION9].ColumnName].Width = 100;

            Columns[this.detailsTable.Columns[START_CONDITION10].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[END_CONDITION10].ColumnName].Width = 100;

            // ���͋��ݒ�
            Columns[this.detailsTable.Columns[ENT_CODE].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[SECTION].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[SEND_NO].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[SEND_NO_DIV].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[GET_DATA_TYPE].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[GET_START_DATE].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[GET_END_DATE].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[START_CONDITION1].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_CONDITION1].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            Columns[this.detailsTable.Columns[START_CONDITION2].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_CONDITION2].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            Columns[this.detailsTable.Columns[START_CONDITION3].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_CONDITION3].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            Columns[this.detailsTable.Columns[START_CONDITION4].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_CONDITION4].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            Columns[this.detailsTable.Columns[START_CONDITION5].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_CONDITION5].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            Columns[this.detailsTable.Columns[START_CONDITION6].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_CONDITION6].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            Columns[this.detailsTable.Columns[START_CONDITION7].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_CONDITION7].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            Columns[this.detailsTable.Columns[START_CONDITION8].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_CONDITION8].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            Columns[this.detailsTable.Columns[START_CONDITION9].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_CONDITION9].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            Columns[this.detailsTable.Columns[START_CONDITION10].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_CONDITION10].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

        }

        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈���ł��B</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this._loginName = LoginInfoAcquisition.Employee.Name;
            this.tToolbarsManager1.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager1.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;
        }

        /// <summary>
        /// �ڍ׏���\������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ڍ׏���\������</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void DetailShow()
        {
            int sndRcvHisConsNo = this._sndRcvHisWork.SndRcvHisConsNo;  // ���M�ԍ�
            ArrayList details = new ArrayList();
			SndRcvHisAcs sndRcvHisAcs = new SndRcvHisAcs();// ADD 2011.08.24
            ArrayList resultList = this._searchResult as ArrayList;
            SndRcvHisWork sndRcvHisWork = new SndRcvHisWork();

            for (int i = 0; i < resultList.Count; i++)
            {
				if (resultList[i].GetType() == typeof(SndRcvHisWork))
				{
					SndRcvHisWork work = resultList[i] as SndRcvHisWork;
					if (work.SndRcvHisConsNo == sndRcvHisConsNo)
					{
						if (i <= (resultList.Count - 1))
						{
							if ((resultList[i + 1]).GetType() == typeof(ArrayList))
							{
								i++;
								// Get details
								details = resultList[i] as ArrayList;
							}
						}
						sndRcvHisWork = work;
						break;
					}
				}
            }
            if (details.Count == 0)
            {
                DataRow row = this.detailsTable.NewRow();
                row[this.detailsTable.Columns[ENT_CODE]] = sndRcvHisWork.EnterpriseCode;
				//row[this.detailsTable.Columns[SECTION]] = this.GetSetctionName(sndRcvHisWork.SectionCode.ToString());// DEL 2011.08.24
				row[this.detailsTable.Columns[SECTION]] = sndRcvHisAcs.GetSetctionName(sndRcvHisWork.SectionCode.ToString());// ADD 2011.08.24
                row[this.detailsTable.Columns[SEND_NO]] = sndRcvHisWork.SndRcvHisConsNo;
            }

            foreach (SndRcvEtrWork work in details)
            {
                DataRow row = this.detailsTable.NewRow();
                row[this.detailsTable.Columns[ENT_CODE]] = work.EnterpriseCode;
				//row[this.detailsTable.Columns[SECTION]] = this.GetSetctionName(work.SectionCode.ToString());// DEL 2011.08.24
				row[this.detailsTable.Columns[SECTION]] = sndRcvHisAcs.GetSetctionName(work.SectionCode.ToString());// ADD 2011.08.24
                row[this.detailsTable.Columns[SEND_NO]] = work.SndRcvHisConsNo;
                row[this.detailsTable.Columns[SEND_NO_DIV]] = work.SndRcvHisConsDerivNo;
                if (work.ExtraStartDate > DateTime.MinValue)
                {
					//row[this.detailsTable.Columns[GET_START_DATE]] = this.DateTimeFormatToString(work.ExtraStartDate);// DEL 2011.08.24
					row[this.detailsTable.Columns[GET_START_DATE]] = sndRcvHisAcs.DateTimeFormatToString(work.ExtraStartDate);// ADD 2011.08.24
                }else
                {
                    row[this.detailsTable.Columns[GET_START_DATE]] = "";
                }
                if (work.ExtraEndDate > DateTime.MinValue)
                {
					//row[this.detailsTable.Columns[GET_END_DATE]] = this.DateTimeFormatToString(work.ExtraEndDate);// DEL 2011.08.24
					row[this.detailsTable.Columns[GET_END_DATE]] = sndRcvHisAcs.DateTimeFormatToString(work.ExtraEndDate);// ADD 2011.08.24
                }
                else
                {
                    row[this.detailsTable.Columns[GET_END_DATE]] = "";
                }              
                
                row[this.detailsTable.Columns[START_CONDITION1]] = work.StartCond1;
                row[this.detailsTable.Columns[END_CONDITION1]] = work.EndCond1;
                row[this.detailsTable.Columns[START_CONDITION2]] = work.StartCond2;
                row[this.detailsTable.Columns[END_CONDITION2]] = work.EndCond2;
                row[this.detailsTable.Columns[START_CONDITION3]] = work.StartCond3;
                row[this.detailsTable.Columns[END_CONDITION3]] = work.EndCond3;
                row[this.detailsTable.Columns[START_CONDITION4]] = work.StartCond4;
                row[this.detailsTable.Columns[END_CONDITION4]] = work.EndCond4;
                row[this.detailsTable.Columns[START_CONDITION5]] = work.StartCond5;
                row[this.detailsTable.Columns[END_CONDITION5]] = work.EndCond5;
                row[this.detailsTable.Columns[START_CONDITION6]] = work.StartCond6;
                row[this.detailsTable.Columns[END_CONDITION6]] = work.EndCond6;
                row[this.detailsTable.Columns[START_CONDITION7]] = work.StartCond7;
                row[this.detailsTable.Columns[END_CONDITION7]] = work.EndCond7;
                row[this.detailsTable.Columns[START_CONDITION8]] = work.StartCond8;
                row[this.detailsTable.Columns[END_CONDITION8]] = work.EndCond8;
                row[this.detailsTable.Columns[START_CONDITION9]] = work.StartCond9;
                row[this.detailsTable.Columns[END_CONDITION9]] = work.EndCond9;
                row[this.detailsTable.Columns[START_CONDITION10]] = work.StartCond10;
                row[this.detailsTable.Columns[END_CONDITION10]] = work.EndCond10;

                if ("CustomerRF".Equals(work.FileId))
                {
                    row[this.detailsTable.Columns[GET_DATA_TYPE]] = CustomerRF;
                }
                else if ("GoodsURF".Equals(work.FileId))
                {
                    row[this.detailsTable.Columns[GET_DATA_TYPE]] = GoodsURF;
                }
                else if ("StockRF".Equals(work.FileId))
                {
                    row[this.detailsTable.Columns[GET_DATA_TYPE]] = StockRF;
                }
                else if ("SupplierRF".Equals(work.FileId))
                {
                    row[this.detailsTable.Columns[GET_DATA_TYPE]] = SupplierRF;
                }
                else if ("RateRF".Equals(work.FileId))
                {
                    row[this.detailsTable.Columns[GET_DATA_TYPE]] = RateRF;
                }
                // --- ADD 2012/07/26 ---------->>>>>
                else if ("EmployeeDtlRF".Equals(work.FileId))
                {
                    row[this.detailsTable.Columns[GET_DATA_TYPE]] = EmployeeDtlRF;
                }
                else if ("UserGdBdURF".Equals(work.FileId))
                {
                    row[this.detailsTable.Columns[GET_DATA_TYPE]] = UserGdBdURF;
                }
                else if ("JoinPartsURF".Equals(work.FileId))
                {
                    row[this.detailsTable.Columns[GET_DATA_TYPE]] = JoinPartsURF;
                }
                // --- ADD 2012/07/26 ----------<<<<<

                this.detailsTable.Rows.Add(row);
            }
        }

		// DEL 2011.08.24 --------------->>>>>
		///// <summary>
		///// ���_�����擾
		///// </summary>
		///// <param name="sectionCode"></param>
		///// <returns></returns>
		//private string GetSetctionName(string sectionCode) 
		//{
		//    string sectionName = null;

		//    SecInfoAcs secInfoAcs = new SecInfoAcs();
		//    try
		//    {
		//        foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
		//        {
		//            if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
		//            {
		//                sectionName = secInfoSet.SectionGuideNm.Trim();
		//                break;
		//            }
		//        }
		//    }
		//    catch
		//    {
		//        sectionName = string.Empty;
		//    }

		//    return sectionName;
		//}		

		///// <summary>
		///// DateTime�̓�����String�ɂ���
		///// </summary>
		///// <param name="dateTime">DateTime�̓���</param>
		///// <returns>String�̓���</returns>
		///// <remarks>
		///// <br>Note       : DateTime�̓�����String�ɂ���</br>
		///// <br>Programmer : �����Y</br>
		///// <br>Date       : 2011/08/01</br>
		///// </remarks>
		//private string DateTimeFormatToString(DateTime dateTime)
		//{
		//    string time = null;
		//    time += dateTime.Year + "�N";
		//    time += dateTime.Month + "��";
		//    time += dateTime.Day + "��";
		//    time += dateTime.Hour + "��";
		//    time += dateTime.Minute + "��";
		//    time += dateTime.Second + "�b";

		//    return time;
		//}
		// DEL 2011.08.24 ---------------<<<<<
        #endregion �� Private Method ��
    }
}