using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using DataDynamics.ActiveReports;
using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// ���R���[���|�[�g���[�e�B���e�B�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���R���[�̃A�N�e�B�u���|�[�g�֘A�̃��[�e�B���e�B�N���X�ł�</br>
    /// <br>Programmer	: 22011 ���� ���l</br>
    /// <br>Date		: 2007.08.08</br>
    /// <br>UpdateNote	: 2007.11.29 22024 ���� �_�u</br>
	/// <br>			:  1.PaperKind�ݒ胁�\�b�h��ǉ�</br>
    /// </remarks>
    public class SFANL08235CE : SFANL08235CD
    {
        //================================================================================
        //  public methods
        //================================================================================
        #region public methods
        
        #region �����o�͗p�̃e�L�X�g�{�b�N�X�̃v���p�e�B�𐮂��܂�
        /// <summary>
        /// �����o�͗p�̃e�L�X�g�{�b�N�X�̃v���p�e�B�𐮂��܂�
        /// </summary>
        /// <param name="trgtTextBox">�ΏۃR���g���[���{�b�N�X</param>
        /// <param name="printDataSet">����p�f�[�^�Z�b�g</param>
        /// <returns>����F0�@�ُ�F-1</returns>
        static public int SetExrCndTextBox(ref TextBox trgtTextBox, DataSet printDataSet)
        {
            StringCollection extrCondsStr = new StringCollection();
            StringBuilder sb = new StringBuilder();
            int status = 0;
            int maxLength = 0;

            //�v���p�e�B�ݒ�
            trgtTextBox.MultiLine = true;
            trgtTextBox.CanGrow = false;
            try
            {
                maxLength = GetARControlByteLength(trgtTextBox);
                // ���o�������擾
                foreach (DataRow dr in printDataSet.Tables[CT_FREPPRPRINT_EXTR_DT].Rows)
                {
                    EditCondition(ref extrCondsStr, (string)dr[CT_EXTRACTCONDS], maxLength);
                }
                foreach (string area in extrCondsStr)
                {
                    sb.Append(area + "\n");
                }
                trgtTextBox.Text = sb.ToString();
            }
            catch
            {
                status = -1;
            }

            return status;
        }
        #endregion

        #region �X�N���v�g�Ŏg�p����DLL��ǂݍ��݂܂�
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rpt"></param>
        static public void AddScriptReference(ref ActiveReport3 rpt)
        {
            rpt.AddScriptReference("SFCMN00001U.dll");
            rpt.AddScriptReference("SFCMN00002C.dll");
            rpt.AddScriptReference("SFANL08235C.dll");
            rpt.AddScriptReference("SFCMN00297C.dll");
        }
        #endregion

        #region �w�i�摜������(Overlay)�������|�[�g��Ԃ��܂�
        /// <summary>
        /// �w�i�摜������(Overlay)�������|�[�g��Ԃ��܂�
        /// </summary>
        /// <param name="prtRpt">����p���|�[�g</param>
        /// <param name="bgImage">�w�i�摜</param>
        /// <param name="prtPprBgImageRowPos">�w�i�摜�c�ʒu</param>
        /// <param name="prtPprBgImageColPos">�w�i�摜���ʒu</param>
        /// <returns></returns>
        static public ActiveReport3 OverlayImage(ActiveReport3 prtRpt, Bitmap bgImage, double prtPprBgImageRowPos, double prtPprBgImageColPos)
        {
            prtRpt.Run();
            // �w�i�摜�p�̃��|�[�g�쐬
            if (bgImage != null)
            {
                BackImgReport overlayForm = new BackImgReport();
                int pagecnt = prtRpt.Document.Pages.Count;
                DataTable dt = new DataTable("Table1");
                dt.Columns.Add("pict", typeof(System.Drawing.Image));

                //�w�i�p���|�[�g�̃T�C�Y����
                //overlayForm.SetRprSize(prtRpt.PageSettings, prtPprBgImageRowPos, prtPprBgImageColPos);
                overlayForm.SetRprSize(prtRpt, prtPprBgImageRowPos, prtPprBgImageColPos);


                //�w�i�Z�b�g
                for (int j = 0; j < pagecnt; j++)
                {
                    DataRow dr = dt.NewRow();
                    dr["pict"] = bgImage;
                    dt.Rows.Add(dr);
                }
                overlayForm.DataSource = dt;
                overlayForm.Run(false);

                if ((prtRpt.Document.Pages.Count > 0) && (overlayForm.Document.Pages.Count > 0))
                {
                    for (int j = 0; j < pagecnt; j++)
                    {
                        //�I�[�o�[���C�Ŕw�i�摜���Z�b�g
                        overlayForm.Document.Pages[j].Overlay(prtRpt.Document.Pages[j]);
                    }
                }
                return (ActiveReport3)overlayForm;
            }
            else
            {
                return prtRpt;
            }
        }
        #endregion

////////////////////////////////////////////// 2007.11.29 TERASAKA ADD STA //
		#region �v�����^�ɐݒ肳��Ă���PaperKind��ݒ肵�܂�
		/// <summary>
		/// �L���p���ݒ菈��
		/// </summary>
		/// <param name="rpt">�A�N�e�B�u���|�[�g�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note		: �v�����^�̗p���ݒ肪�K�؂����f���A�s�K�؂ȏꍇ�͐ݒ���J�X�^���p���ɂ��܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.29</br>
		/// </remarks>
		static public void SetValidPaperKind(ActiveReport3 rpt)
		{
			bool isValidPaperKind = false;

			foreach (System.Drawing.Printing.PaperSize paperSize in rpt.Document.Printer.PaperSizes)
			{
				if (paperSize.Kind == rpt.PageSettings.PaperKind)
				{
					isValidPaperKind = true;
					break;
				}
			}

			if (!isValidPaperKind)
				rpt.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
		}
		#endregion
// 2007.11.29 TERASAKA ADD END //////////////////////////////////////////////
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
        # region [DataView�ɐݒ肷��\�[�g��������𐶐����܂�]
        /// <summary>
        /// �\�[�g������擾����
        /// </summary>
        /// <param name="frePprSrtOWorkList"></param>
        /// <returns></returns>
        public static string GetSortString( List<FrePprSrtOWork> frePprSrtOWorkList )
        {
            return GetSortStringProc( frePprSrtOWorkList );
        }
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
        #endregion


        //================================================================================
        //  private methods
        //================================================================================
        #region private methods

        #region ���o����������ҏW
        /// <summary>
        /// ���o����������ҏW
        /// </summary>
        /// <param name="editArea">�i�[�G���A</param>
        /// <param name="target">�Ώە�����</param>
        /// <param name="maxStringLength">�R���g���[���ɕ\������V�t�g�W�X�̕�����</param>
        static private void EditCondition(ref StringCollection editArea, string target, int maxStringLength)
        {
            bool isEdit = false;

            // �ҏW�Ώە����o�C�g���Z�o
            int targetByte = TStrConv.SizeCountSJIS(target);
            for (int i = 0; i < editArea.Count; i++)
            {
                int areaByte = 0;

                // �i�[�G���A�̃o�C�g���Z�o
                if (editArea[i] != null)
                {
                    areaByte = TStrConv.SizeCountSJIS(editArea[i]);
                }

                if ((areaByte + targetByte + 2) <= maxStringLength)
                {
                    isEdit = true;

                    // �S�p�X�y�[�X��}��
                    if (editArea[i] != null) editArea[i] += CT_ITEM_INTERVAL;

                    editArea[i] += target;
                    break;
                }
            }
            // �V�K�ҏW�G���A�쐬
            if (!isEdit)
            {
                editArea.Add(target);
            }
        }
        #endregion

        #region GetARControlByteLength ���|�[�g�R���g���[���o�C�g�����O�X�擾����
        /// <summary>
        /// ���|�[�g�R���g���[���o�C�g�����O�X�擾����
        /// </summary>
        /// <param name="control">�擾�Ώۃ��|�[�g�R���g���[���i�e�L�X�g�{�b�N�X�E���x���̂ݑΏہj</param>
        /// <returns>�擾�Ώۃ��|�[�g�R���g���[���̃o�C�g�����O�X</returns>
        /// <remarks>
        /// <br>Note       : �擾�Ώۃ��|�[�g�R���g���[���ɓ���ő啶����(�o�C�g�����O�X)���擾���܂��B</br>
        /// <br>Programmer : 22011 �����@���l</br>
        /// <br>Date       : 2007.08.08</br>
        /// </remarks>
        static private int GetARControlByteLength(DataDynamics.ActiveReports.ARControl control)
        {
            int result = 0;
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            Graphics graphics = label.CreateGraphics();

            // ���|�[�g�R���g���[���t�H���g�擾
            Font controlFont;

            if (control is DataDynamics.ActiveReports.TextBox)
            {
                controlFont = ((DataDynamics.ActiveReports.TextBox)control).Font;
            }
            else if (control is DataDynamics.ActiveReports.Label)
            {
                controlFont = ((DataDynamics.ActiveReports.Label)control).Font;
            }
            else
            {
                return result;
            }

            // ���|�[�g�R���g���[���s�N�Z�����Z�o�i96ppi�Ŋ��Z�j
            int controlWidth = Convert.ToInt32(control.Width * 96.0f);
            int stringWidth = Convert.ToInt32(graphics.MeasureString(string.Empty.PadRight(result++, 'X'), controlFont).Width);

            // ������̕���������܂ŌJ��Ԃ�
            while (stringWidth < controlWidth)
            {
                stringWidth = Convert.ToInt32(graphics.MeasureString(string.Empty.PadRight(result++, 'X'), controlFont).Width);
            }

            return TStrConv.SizeCountSJIS(string.Empty.PadRight(--result, 'X'));
        }
        #endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/22 ADD
        # region [�\�[�g�����񐶐�����]
        /// <summary>
        /// �\�[�g�����񐶐�����
        /// </summary>
        /// <param name="frePprSrtOWorkList"></param>
        /// <returns></returns>
        private static string GetSortStringProc( List<FrePprSrtOWork> frePprSrtOWorkList )
        {
            string sortString = string.Empty;
            frePprSrtOWorkList.Sort( new FrePprSrtOWorkComparer() );

            foreach ( FrePprSrtOWork srtO in frePprSrtOWorkList )
            {
                if ( srtO.LogicalDeleteCode != 0 ) continue;

                string sortWay;
                switch ( srtO.SortingOrderDivCd )
                {
                    // 0:�\�[�g��
                    default:
                    case 0:
                        // �����ڂ�
                        continue;
                    // 1:����
                    case 1: sortWay = "ASC"; break;
                    // 2:�~��
                    case 2: sortWay = "DESC"; break;
                }

                // 2���ڈȏ�
                if ( sortString != string.Empty )
                {
                    sortString += ", ";
                }

                // �\�[�g������ǉ�
                sortString += string.Format( "{0}.{1} {2}",
                                                srtO.FileNm.ToUpper(),
                                                srtO.DDName.ToUpper(),
                                                sortWay );
            }

            return sortString;
        }
        # region [�\�[�g���ʐݒ��r�N���X(�\�[�g�p)]
        /// <summary>
        /// �\�[�g���ʐݒ��r�N���X(�\�[�g�p)
        /// </summary>
        private class FrePprSrtOWorkComparer : IComparer<FrePprSrtOWork>
        {
            public int Compare( FrePprSrtOWork x, FrePprSrtOWork y )
            {
                return x.SortingOrder.CompareTo( y.SortingOrder );
            }
        }
        # endregion
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/22 ADD
        #endregion
        
    }
}