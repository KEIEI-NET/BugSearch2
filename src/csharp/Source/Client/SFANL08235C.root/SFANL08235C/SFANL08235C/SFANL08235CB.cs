using System;
using System.IO;
using System.Text;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;

using DataDynamics.ActiveReports;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// ���R���[�_�~�[�f�[�^���|�[�g�����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���R���[�̃��|�[�g�N���X�����Ƀv���r���[����p�_�~�[�f�[�^�𐶐����܂�</br>
    /// <br>Programmer	: 22011 ���� ���l</br>
    /// <br>Date		: 2007.07.03</br>
    /// <br>UpdateNote	: </br>
    /// </remarks>
    public class SFANL08235CB
    {
        #region private const
        private const string CT_NOIMAGE = "NoPhoto";
        #endregion

        #region private member
        List<PrtItemSetWork> _prtItemSetLS = new List<PrtItemSetWork>();
        #endregion

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        public SFANL08235CB()
        {
        }


        #region public methods
        
        /// <summary>
        /// �_�~�[�f�[�^��������s���܂�
        /// </summary>
        /// <param name="prtItemSetLs">�󎚍��ڐݒ�̃��X�g</param>
        /// <param name="frePrtPset">�󎚈ʒu�ݒ�</param>
        /// <param name="createRowCnt">������R�[�h����</param>
        /// <param name="bgImage"></param>
        /// <param name="rpt"></param>
        /// <returns>����I��:0</returns>
        public int CreateDummyDataReport(List<PrtItemSetWork> prtItemSetLs, FrePrtPSet frePrtPset, Int32 createRowCnt, Bitmap bgImage, out ActiveReport3 rpt)
        {
            // �O���[�o���̈�Ɋm��
            _prtItemSetLS = prtItemSetLs;
            // �_�~�[�f�[�^����p�̃��|�[�g����
            return GenerateDummyPrintReport(frePrtPset, createRowCnt, out rpt);
        }

        #endregion

        #region private methods

        /// <summary>
        /// �_�~�[�f�[�^����p��ActiveReport�N���X�𐶐����܂�
        /// </summary>
        /// <param name="frePrtPset">�󎚈ʒu�ݒ�f�[�^�N���X</param>
        /// <param name="createRowCnt">������R�[�h����</param>
        /// <param name="rpt">�_�~�[�f�[�^���背�|�[�g</param>
        /// <returns>����I��:0</returns>
        private int GenerateDummyPrintReport(FrePrtPSet frePrtPset, Int32 createRowCnt, out ActiveReport3 rpt)
        {
            try
            {
                //�e�[�u���Z�b�g
                DataSet frePprDataSet = new DataSet();
                frePprDataSet.Tables.Add(SFANL08235CD.CT_FREPPRPRINT_MAIN_DT);  // ������C��
                frePprDataSet.Tables.Add(SFANL08235CD.CT_FREPPRPRINT_EXTR_DT);  // ���o����
                frePprDataSet.Tables.Add(SFANL08235CD.CT_FREPPRPRINT_PFTR_DT);  // �t�b�^�[
                frePprDataSet.Tables.Add(SFANL08235CD.CT_FREPPRPRINT_SRTO_DT);  // �\�[�g��

                #region ������C���f�[�^
                DataTable dt = frePprDataSet.Tables[SFANL08235CD.CT_FREPPRPRINT_MAIN_DT];
                // �󎚈ʒu�ݒ肩�烌�|�[�g�����o��
                MemoryStream mst1 = new MemoryStream(frePrtPset.PrintPosClassData);
                rpt = new ActiveReport3();
                rpt.LoadLayout(mst1);

                // ������ ����p�X�L�[�}(DataTable)�쐬 ������
                // -- ���|�[�g���DataField����쐬
                if (rpt != null)
                {
                    // ���|�[�g�̃Z�N�V������{��
                    foreach (Section section in rpt.Sections)
                    {
                        // section��DataField�ǉ�
                        //�O���[�v�w�b�_��������
                        if (section is GroupHeader)
                        {
                            AddColumns(ref dt, ((GroupHeader)section).DataField);
                        }
                        // �Z�N�V�������̃R���g���[����{��
                        foreach (ARControl control in section.Controls)
                        {
                            AddColumns(ref dt, control.DataField);
                        }
                    }
                }

                // ������ ����p�_�~�[�f�[�^�쐬 ������
                PrtItemSetWork prtItem = null;
                
                DataRow dr = dt.NewRow();
                foreach (DataColumn column in dt.Columns)
                {
                    prtItem = _prtItemSetLS.Find(delegate(PrtItemSetWork piSet) { return FrePrtSettingController.CreateDataField(piSet) == column.Caption; });
                    if (prtItem != null)
                    {
                        if (prtItem.ReportControlCode == 3)
                        {
                            // �摜
                            dr[column.Caption] = GenerateDummyDataForImage();
                        }
                        else if (prtItem.ReportControlCode == 6)
                        {
                            // �o�[�R�[�h�̎��͐��l
                            Random rnd = new Random();
                            dr[column.Caption] = rnd.Next(999999999);
                        }
                        else
                        {
                            dr[column.Caption] = prtItem.FreePrtPaperItemNm;
                        }
                    }
                    else
                    {
                        dr[column.Caption] = string.Empty;
                    }
                }
                dt.Rows.Add(dr);
                // createRowCnt�Ŏw�肳�ꂽ�������_�~�[�f�[�^���쐬
                for (int roopCnt = 1; roopCnt < createRowCnt; roopCnt++)
                {
                    DataRow copyDr = dt.NewRow();
                    copyDr.ItemArray = dr.ItemArray;
                    dt.Rows.Add(copyDr);
                }
                #endregion

                #region ���o����
                dt = frePprDataSet.Tables[SFANL08235CD.CT_FREPPRPRINT_EXTR_DT];
                AddColumns(ref dt, SFANL08235CD.CT_EXTRACTCONDS);
                dr = dt.NewRow();
                dr[SFANL08235CD.CT_EXTRACTCONDS] = "���o����";
                dt.Rows.Add(dr);
                #endregion

                #region �t�b�^�[������
                dt = frePprDataSet.Tables[SFANL08235CD.CT_FREPPRPRINT_PFTR_DT];
                AddColumns(ref dt, SFANL08235CD.CT_PRINTFOOTER1);
                AddColumns(ref dt, SFANL08235CD.CT_PRINTFOOTER2);
                dr = dt.NewRow();
                dr[SFANL08235CD.CT_PRINTFOOTER1] = "���[�t�b�^�[����";
                dr[SFANL08235CD.CT_PRINTFOOTER2] = "���[�t�b�^�[���E";
                dt.Rows.Add(dr);
                #endregion

                #region �\�[�g��
                dt = frePprDataSet.Tables[SFANL08235CD.CT_FREPPRPRINT_SRTO_DT];
                AddColumns(ref dt, SFANL08235CD.CT_SORTODER1);
                AddColumns(ref dt, SFANL08235CD.CT_SORTODER2);
                AddColumns(ref dt, SFANL08235CD.CT_SORTODER3);
                AddColumns(ref dt, SFANL08235CD.CT_SORTODER4);
                AddColumns(ref dt, SFANL08235CD.CT_SORTODER5);
                
                dr = dt.NewRow();
                dr[SFANL08235CD.CT_SORTODER1] = "�\�[�g���P";
                dr[SFANL08235CD.CT_SORTODER2] = "�\�[�g���Q";
                dr[SFANL08235CD.CT_SORTODER3] = "�\�[�g���R";
                dr[SFANL08235CD.CT_SORTODER4] = "�\�[�g���S";
                dr[SFANL08235CD.CT_SORTODER5] = "�\�[�g���T";
                dt.Rows.Add(dr);
                #endregion

                rpt.DataSource = frePprDataSet;
                rpt.DataMember = SFANL08235CD.CT_FREPPRPRINT_MAIN_DT;

                // �X�N���v�g�Ŏg�p�ł���悤�ɎQ�Ƃ�ǉ�
                SFANL08235CE.AddScriptReference(ref rpt);
                //rpt.Run();
            }
            catch
            {
                rpt = null;
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// �f�[�^�e�[�u���ɃJ������ǉ����܂�(�J�������̏d���`�F�b�N�L��)
        /// </summary>
        /// <param name="dt">�ǉ��Ώۂ�DataTable</param>
        /// <param name="addColumnNm">�ǉ�����J��������</param>
        private void AddColumns(ref DataTable dt, string addColumnNm)
        {
            if (!string.IsNullOrEmpty(addColumnNm))
            {
                // ���݂��Ȃ���΃J�����ǉ�
                if (!dt.Columns.Contains(addColumnNm))
                {
                    dt.Columns.Add(addColumnNm, typeof(object));
                    dt.Columns[addColumnNm].DefaultValue = DBNull.Value;
                }
            }
        }

        #region �C���[�W�^�_�~�[�f�[�^����
        /// <summary>
        /// �C���[�W�^�̃_�~�[�f�[�^�𐶐����܂�
        /// </summary>
        /// <returns>�C���[�W�^�̃_�~�[�f�[�^</returns>
        private Bitmap GenerateDummyDataForImage()
        {
            return Broadleaf.Application.Common.Properties.Resources.NoPhoto;
        }
        #endregion

        #endregion
    }
}