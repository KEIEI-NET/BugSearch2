using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using Broadleaf.Library.Text;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;

using DataDynamics.ActiveReports;

// ADD 2024/08/01 �c������ ���[ID���O�o�͑Ή� ----->>>>>
using Broadleaf.Library.Diagnostics;
using System.Diagnostics;
using Broadleaf.Application.Controller;
// ADD 2024/08/01 �c������ ���[ID���O�o�͑Ή� -----<<<<<

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// ���R���[���ʐ���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�S�̂Ŏg�p���鋤�ʏ����N���X�ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.08.21</br>
	/// <br>Note		: ���[ID���O�o�͑Ή�</br>
	/// <br>Programmer	: 32427 �c������</br>
	/// <br>UpdateDate	: 2024.08.01</br>
	/// </remarks>
	public class FrePrtSettingController
	{

        // ADD 2024/08/01 �c������ ���[ID���O�o�͑Ή� ----->>>>>
        private static OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
        // ADD 2024/08/01 �c������ ���[ID���O�o�͑Ή� -----<<<<<

		#region PublicMethod(static)
		/// <summary>
		/// �󎚈ʒu�ݒ�f�[�^�Í�������
		/// </summary>
		/// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�}�X�^</param>
		/// <remarks>
		/// <br>Note		: ���R���[�󎚈ʒu�ݒ�}�X�^�̈󎚈ʒu�ݒ�f�[�^���Í������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.08.21</br>
		/// </remarks>
		public static void EncryptPrintPosClassData(FrePrtPSet frePrtPSet)
		{
			if (frePrtPSet != null)
			{
				string[] key = CreateEncryptKey(frePrtPSet);
				if (frePrtPSet.PrintPosClassData != null && frePrtPSet.PrintPosClassData.Length > 0)
					frePrtPSet.PrintPosClassData = UserSettingController.EncryptionBytes(frePrtPSet.PrintPosClassData, key);
			}
		}
		/// <summary>
		/// �󎚈ʒu�ݒ�f�[�^����������
		/// </summary>
		/// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�}�X�^</param>
		/// <remarks>
		/// <br>Note		: ���R���[�󎚈ʒu�ݒ�}�X�^�̈󎚈ʒu�ݒ�f�[�^�𕜍������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.08.21</br>
		/// </remarks>
		public static void DecryptPrintPosClassData(FrePrtPSet frePrtPSet)
		{
			if (frePrtPSet != null)
			{
				string[] key = CreateEncryptKey(frePrtPSet);
				if (frePrtPSet.PrintPosClassData != null && frePrtPSet.PrintPosClassData.Length > 0)
					frePrtPSet.PrintPosClassData = UserSettingController.DecryptionBytes(frePrtPSet.PrintPosClassData, key);
			}
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/04 ADD
        /// <summary>
        /// �󎚈ʒu�ݒ�f�[�^�Í�������
        /// </summary>
        /// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�}�X�^</param>
        /// <remarks>
        /// <br>Note         : ���R���[�󎚈ʒu�ݒ�}�X�^�̈󎚈ʒu�ݒ�f�[�^���Í������܂��B</br>
        /// <br>Programmer   : 22018 ��� ���b</br>
        /// <br>Date         : 2008.06.04</br>
        /// </remarks>
        public static void EncryptPrintPosClassData( FrePrtPSetWork frePrtPSet )
        {
            if ( frePrtPSet != null )
            {
                string[] key = CreateEncryptKey( frePrtPSet );
                if ( frePrtPSet.PrintPosClassData != null && frePrtPSet.PrintPosClassData.Length > 0 )
                    frePrtPSet.PrintPosClassData = UserSettingController.EncryptionBytes( frePrtPSet.PrintPosClassData, key );
            }
        }
        /// <summary>
        /// �󎚈ʒu�ݒ�f�[�^����������
        /// </summary>
        /// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�}�X�^</param>
        /// <remarks>
        /// <br>Note         : ���R���[�󎚈ʒu�ݒ�}�X�^�̈󎚈ʒu�ݒ�f�[�^�𕜍������܂��B</br>
        /// <br>Programmer   : 22018 ��� ���b</br>
        /// <br>Date         : 2008.06.04</br>
        /// <br>Note         : ���[ID���O�o�͑Ή�</br>
        /// <br>Programmer   : 32427 �c������</br>
        /// <br>UpdateDate   : 2024.08.01</br>
        /// </remarks>
        public static void DecryptPrintPosClassData( FrePrtPSetWork frePrtPSet )
        {
            // ADD 2024/08/01 �c������ ���[ID���O�o�͑Ή� ----->>>>>
            // ���[ID�𑀍엚�����O�ɏo�͂���i����Ɏg�p����钠�[ID���o�͂��邽�߂����APKG�Ή��Ƃ��������ߒ��[�f�[�^����������邱�̃��\�b�h�ɂđ�p����j
            try
            {
                string msg = string.Format("{0}:{1}", frePrtPSet.FreePrtPprSpPrpseCd, frePrtPSet.OutputFormFileName);
                WriteOperationLog(frePrtPSet, 1, msg); // 1:���[�o��
            }
            catch
            {
                //�������p�������邽�߁A��������
            }
            // ADD 2024/08/01 �c������ ���[ID���O�o�͑Ή� -----<<<<<

            if (frePrtPSet != null)
            {
                string[] key = CreateEncryptKey( frePrtPSet );
                if ( frePrtPSet.PrintPosClassData != null && frePrtPSet.PrintPosClassData.Length > 0 )
                    frePrtPSet.PrintPosClassData = UserSettingController.DecryptionBytes( frePrtPSet.PrintPosClassData, key );
            }
        }
        
        // ADD 2024/08/01 �c������ ���[ID���O�o�͑Ή� ----->>>>>
        /// <summary>
        /// ���엚�����O�o��
        /// </summary>
        /// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�}�X�^</param>
        /// <param name="opecode">�I�y���[�V�����R�[�h</param>
        /// <param name="msg">�o�̓��b�Z�[�W</param>
        /// <remarks>
        /// <br>Note         : ���[ID���O�o�͑Ή�</br>
        /// <br>Programmer   : 32427 �c������</br>
        /// <br>Date         : 2024.08.01</br>
        /// </remarks>
         private static void WriteOperationLog(FrePrtPSetWork frePrtPSet, int opecode, string msg)
        {
            //�`�[�����ʂ�������(���v�F50,���ׁF60,�`�[���v�F70)�A�̎���(80)�̏ꍇ�Ƀ��O�o�͂���
            if (frePrtPSet.FreePrtPprSpPrpseCd == 50 || frePrtPSet.FreePrtPprSpPrpseCd == 60 || frePrtPSet.FreePrtPprSpPrpseCd == 70 || frePrtPSet.FreePrtPprSpPrpseCd == 80)
            {
                operationHistoryLog.WriteOperationLog(null, DateTime.Now, (LogDataKind)0,�@//LogDataKind 0:���엚�����O
                    "SFANL08132CI", "���R���[��������", "", opecode, (int)0, msg, string.Empty); //
            }
        }
        // ADD 2024/08/01 �c������ ���[ID���O�o�͑Ή� -----<<<<<
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/04 ADD

		/// <summary>
		/// �[�������i�l�̌ܓ��j
		/// </summary>
		/// <param name="dValue">�l</param>
		/// <param name="iDigits">�ŏ�������</param>
		/// <returns>��������</returns>
		/// <remarks>
		/// <br>Note		: �w�茅���ɂȂ�悤�ɒ[���������s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.08.21</br>
		/// </remarks>
		public static double ToHalfAdjust(double dValue, int iDigits)
		{
			double dCoef = Math.Pow(10, iDigits);

			if (dValue > 0)
				return Math.Floor((dValue * dCoef) + 0.5) / dCoef;
			else
				return Math.Ceiling((dValue * dCoef) - 0.5) / dCoef;
		}

		/// <summary>
		/// ARControl�^�O���擾����
		/// </summary>
		/// <param name="prtItemSet">�󎚍��ڐݒ�</param>
		/// <returns>Tag���</returns>
		/// <remarks>
		/// <br>Note		: ActiveReport�I�u�W�F�N�g��Tag�����󎚍��ڐݒ���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.08.21</br>
		/// </remarks>
		public static string GetARControlTagInfo(PrtItemSetWork prtItemSet)
		{
			return string.Format("{0},{1},{2},{3},{4}"
				, prtItemSet.FreePrtPaperItemCd
				, prtItemSet.PrintPageCtrlDivCd
				, prtItemSet.GroupSuppressCd
				, prtItemSet.DtlColorChangeCd
				, prtItemSet.HeightAdjustDivCd);
		}

		/// <summary>
		/// �󎚍��ڐݒ�擾����
		/// </summary>
		/// <param name="aRControl">ActiveReport�I�u�W�F�N�g</param>
		/// <param name="prtItemSetList">�󎚍��ڐݒ�LIST</param>
		/// <returns>�󎚍��ڐݒ�}�X�^</returns>
		/// <remarks>
		/// <br>Note		: ActiveReport�I�u�W�F�N�g��Tag����Key�Ɉ󎚍��ڐݒ���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.08.21</br>
		/// </remarks>
		public static PrtItemSetWork GetPrtItemSet(ARControl aRControl, List<PrtItemSetWork> prtItemSetList)
		{
			PrtItemSetWork prtItemSetWork = null;

			if (aRControl != null && aRControl.Tag != null && prtItemSetList != null && prtItemSetList.Count > 0)
			{
				string[] keyArray = aRControl.Tag.ToString().Split(',');

				if (keyArray.Length > 0)
				{
					// ���R���[���ڃR�[�h
					int freePrtPaperItemCd = TStrConv.StrToIntDef(keyArray[0], 0);
					// �󎚍��ڐݒ�LIST���Key����v����f�[�^���擾
					prtItemSetWork = prtItemSetList.Find(
						delegate(PrtItemSetWork wkPrtItemSetWork)
						{
							if (wkPrtItemSetWork.FreePrtPaperItemCd == freePrtPaperItemCd)
								return true;
							else
								return false;
						}
					);

					if (prtItemSetWork != null)
					{
						if (keyArray.Length > 1)
							prtItemSetWork.PrintPageCtrlDivCd = TStrConv.StrToIntDef(keyArray[1], 0);
						if (keyArray.Length > 2)
							prtItemSetWork.GroupSuppressCd = TStrConv.StrToIntDef(keyArray[2], 0);
						if (keyArray.Length > 3)
							prtItemSetWork.DtlColorChangeCd = TStrConv.StrToIntDef(keyArray[3], 0);
						if (keyArray.Length > 4)
							prtItemSetWork.HeightAdjustDivCd = TStrConv.StrToIntDef(keyArray[4], 0);
					}
				}
			}

			return prtItemSetWork;
		}

		/// <summary>
		/// �f�[�^�t�B�[���h�f�[�^�쐬����
		/// </summary>
		/// <param name="prtItemSetWork">�󎚍��ڐݒ�}�X�^</param>
		/// <returns>�f�[�^�t�B�[���h�f�[�^</returns>
		/// <remarks>
		/// <br>Note		: �󎚍��ڐݒ�}�X�^�����Ƀf�[�^�t�B�[���h��</br>
		/// <br>			: �ݒ肷��f�[�^���쐬���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public static string CreateDataField(PrtItemSetWork prtItemSetWork)
		{
			if (prtItemSetWork == null) return string.Empty;

			if (!string.IsNullOrEmpty(prtItemSetWork.FileNm) &&
				!string.IsNullOrEmpty(prtItemSetWork.DDName))
				return prtItemSetWork.FileNm + "." + prtItemSetWork.DDName;
			else if (!string.IsNullOrEmpty(prtItemSetWork.FileNm))
				return prtItemSetWork.FileNm;
			else if (!string.IsNullOrEmpty(prtItemSetWork.DDName))
				return prtItemSetWork.DDName;
			else
				return string.Empty;
		}

		/// <summary>
		/// �����񕝎擾����
		/// </summary>
		/// <param name="control">�ΏۃR���g���[��</param>
		/// <returns>������̕�</returns>
		/// <remarks>
		/// <br>Note		: Control��Text�̃T�C�Y���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.07.05</br>
		/// </remarks>
		public static int GetStringWidth(Control control)
		{
			int textWidth = 0;

			Graphics graphics = null;
			try
			{
				graphics = control.CreateGraphics();
				SizeF sizeF = graphics.MeasureString(control.Text, control.Font);

				textWidth = (int)sizeF.Width;
			}
			finally
			{
				graphics.Dispose();
			}

			return textWidth;
		}
		#endregion

		#region InternalMethod(static)
		/// <summary>
		/// �t�H���g�T�C�Y��������
		/// </summary>
		/// <param name="control">�ΏۃR���g���[��</param>
		/// <param name="baseFontSize">��t�H���g�T�C�Y</param>
		/// <remarks>
		/// <br>Note		: Control��Text����s�Ɏ��܂�悤��Font�T�C�Y�𒲐����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.07.05</br>
		/// </remarks>
		internal static void AdjustControlFontSize(Control control, float baseFontSize)
		{
			control.Font = new Font(control.Font.Name, baseFontSize, control.Font.Style);
			control.Font = PrintCommonLibrary.AdjustFontForHorizontal(control.Font, control.Width, control.Text);
		}
		#endregion

		#region PrivateMethod(static)
		/// <summary>
		/// �Í����L�[�쐬����
		/// </summary>
		/// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�}�X�^</param>
		/// <remarks>
		/// <br>Note		: ���R���[�󎚈ʒu�ݒ�}�X�^�̈󎚈ʒu�ݒ�f�[�^�p�Í����L�[���쐬���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.08.21</br>
		/// </remarks>
		private static string[] CreateEncryptKey(FrePrtPSet frePrtPSet)
		{
			if (frePrtPSet != null)
				return new string[] { frePrtPSet.OutputFormFileName + frePrtPSet.UserPrtPprIdDerivNo, "0ecb06d9-4f46-4274-a4cb-d358f0357482" };
			else
				throw new Exception("���R���[�󎚈ʒu�ݒ�}�X�^�����݂��܂���B");
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/04 ADD
        /// <summary>
        /// �Í����L�[�쐬����
        /// </summary>
        /// <param name="frePrtPSet">���R���[�󎚈ʒu�ݒ�}�X�^</param>
        /// <remarks>
        /// <br>Note         : ���R���[�󎚈ʒu�ݒ�}�X�^�̈󎚈ʒu�ݒ�f�[�^�p�Í����L�[���쐬���܂��B</br>
        /// <br>               ( FrePrtPSet�p���\�b�h�Ɠ���GUID���Z�b�g����K�v���L��܂��B )</br>
        /// <br>Programmer   : 22018 ��� ���b</br>
        /// <br>Date         : 2008.06.04</br>
        /// </remarks>
        private static string[] CreateEncryptKey( FrePrtPSetWork frePrtPSet )
        {
            if ( frePrtPSet != null )
                return new string[] { frePrtPSet.OutputFormFileName + frePrtPSet.UserPrtPprIdDerivNo, "0ecb06d9-4f46-4274-a4cb-d358f0357482" };
            else
                throw new Exception( "���R���[�󎚈ʒu�ݒ�}�X�^�����݂��܂���B" );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/04 ADD
		#endregion
	}
}
