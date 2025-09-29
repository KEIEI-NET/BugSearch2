using System;
using System.Collections.Generic;
using System.Text;
using DataDynamics.ActiveReports;
using System.Reflection;
using System.Windows.Forms;
using System.Collections;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using System.IO;
using Broadleaf.Application.Remoting.ParamData;
using System.Data;
using Broadleaf.Library.Text;
using Broadleaf.Library.Globarization;
//using Broadleaf.Application.Controller;
using System.Text.RegularExpressions;
using System.Drawing;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 自由帳票共通制御部品
	/// </summary>
	/// <remarks>
	/// <br>Note       : 自由帳票で使用する共通部品です。</br>
    /// <br>Programmer : 30015　橋本　裕毅</br>
    /// <br>Date       : 2007.04.27</br>
    /// <br>-------------------------------------------</br>
    /// <br>UpdateNote : 2008.05.21 鈴木 正臣</br>
    /// <br>           : PM.NS向け変更。DM関連機能の削除。</br>
	/// </remarks>
    public class SFANL08132CG
    {
		/// <summary>
		/// 自由帳票共通制御部品コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 自由帳票共通制御部品の新しいインスタンスを初期化します。</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.05.07</br>
		/// </remarks>
		public SFANL08132CG()
        {
		}

		#region Const
		private const string COL_ExtraHeader_ClassId 	= "Broadleaf.Drawing.Printing.ListCommon_ExtraHeader";
		private const string COL_ExtraFooter_ClassId 	= "Broadleaf.Drawing.Printing.ListCommon_ExtraFooter";
		private const string COL_MngOfMacro				= "SFANL08132C_MngOfMacro.xml";
		#endregion

		#region ☆☆　帳票、伝票、DM一覧表、案内文以外のはがき　☆☆
		/// <summary>
		/// 既存レイアウトコンバート処理
		/// </summary>
        /// <param name="outputFormFileName">初回の出力ファイル名</param>
        /// <param name="outputFileClassId">初回の出力ファイルクラスID</param>
        /// <param name="listItemSet">印字項目設定ワークリストクラス</param>
        /// <param name="listSchmCv">スキーマコンバートリストクラス</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ActiveReportクラス</returns>
		/// <remarks>
		/// <br>Note       : 既存のレポートレイアウトスキーマを自由帳票用にコンバートします。</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.05.07</br>
		/// </remarks>
		public ActiveReport3 CvtExistingLayout(string outputFormFileName, string outputFileClassId, List<PrtItemSetWork> listItemSet, List<FPprSchmCvWork> listSchmCv, out string message)
        {
            Assembly assm = null;
            ActiveReport3 wkrpt = null;
            message = String.Empty;
			List<DataDynamics.ActiveReports.TextBox> textBoxList = new List<DataDynamics.ActiveReports.TextBox>();
            try
            {
                try
                {
					if (!string.IsNullOrEmpty(outputFormFileName))
					{
						// ファイルパス取得処理
						string filePath = this.CreateFilePath(outputFormFileName);

						if (!string.IsNullOrEmpty(filePath))
						{
							// 指定されたパスよりアセンブリを取得します。
							assm = Assembly.LoadFrom(filePath);
						}
					}
                }
                catch (FileNotFoundException ex)
                {
                    message = ex.Message;
                    return wkrpt;
                }

				if (assm != null)
				{
					// インスタンスを作成します。
					Object wkObj = assm.CreateInstance(outputFileClassId);
					// 紐づくActiveReportをインスタンス化します。
					wkrpt = wkObj as ActiveReport3;

					if (wkrpt != null)
					{
						for (int ix = 0; ix < wkrpt.Sections.Count; ix++)
						{
							Section section = wkrpt.Sections[ix];

							textBoxList.Clear();
							// SectionがGroupHeaderならDataFieldを置き換える
							// --- sectionのコンバート --------------------------------------------------------------------------
							if (section is GroupHeader)
							{
								if (!string.IsNullOrEmpty(((GroupHeader)section).DataField))
								{
									PrtItemSetWork prtItemSetWork = null;
									FPprSchmCvWork fPprSchmCvWork = null;
									if(this.CheckFreConv(wkrpt, section.Name, listSchmCv, out fPprSchmCvWork))
									{
										// 印字項目ワーククラス作成処理
										prtItemSetWork = this.CreatePrtItemSetWork(fPprSchmCvWork.FreePrtPaperItemCd, listItemSet);
										if (prtItemSetWork != null)
										{
											((GroupHeader)section).DataField = FrePrtSettingController.CreateDataField(prtItemSetWork);
										}
									}
								}
							}

							for (int iy = 0; iy < section.Controls.Count; iy++)
							{
								//Sectionに所属するControlを取得します。
								ARControl control = section.Controls[iy];
								control.Visible = true;

								// 印字項目コードが0の場合、レポート上から削除
								// サブレポートコントロールか判断します。
								if (control.GetType().Equals(typeof(SubReport)))
								{
									if (wkObj != null)
									{
										FPprSchmCvWork fPprSchmCvWork = null;
										if(this.CheckFreConv(wkrpt, control.Name, listSchmCv, out fPprSchmCvWork))
										{
											ActiveReport3 ar;
											if (fPprSchmCvWork.OutputFileClassId != COL_ExtraHeader_ClassId)
											{
												// 再度既存のデータのコンバート処理を走らせます。
												ar = this.CvtExistingLayout(fPprSchmCvWork.OutputFormFileName, fPprSchmCvWork.OutputFileClassId, listItemSet, listSchmCv, out message);
												if (ar != null)
												{
													SubReport subReport = (SubReport)control;

													// サブレポート情報展開処理
													ArrayList wkList = DevelopsSubReport(subReport, ar);
													// 配置調整処理
													if(wkList != null) this.AdjustControls(wkList, subReport, ar, ref section);

													iy--;
												}
											}
											else
											{
												// 共通のヘッダーだったら、テキストボックスに変える
												DataDynamics.ActiveReports.TextBox aRControl = new DataDynamics.ActiveReports.TextBox();
												// プロパティ追加処理(TextBox)
												this.AdditionOfNewExtraTextProp(ref aRControl, control);
												section.Controls.Add(aRControl);
											}
											
											section.Controls.Remove(control);
										}
									}
								}
								else
								{
									PrtItemSetWork prtItemSetWork = null;
									// レポートのコントロールがスキーマコンバートのアクティブレポートコントロール名称が等しい場合にコンバートします。
									FPprSchmCvWork fPprSchmCvWork = listSchmCv.Find(
										delegate(FPprSchmCvWork wkFPprSchmCvWork)
										{
											if (control.Name.Trim() == wkFPprSchmCvWork.ActiveReportCtrlNm.Trim())
												return true;
											else
												return false;
										}
									);
									if (fPprSchmCvWork != null)
									{
										// 印字項目設定ワーククラスリストから、印字項目コードが等しいクラスを取得します。
										if (wkrpt.GetType().Name.Trim() == fPprSchmCvWork.ActiveReportClassId.Trim())
										{
											if (fPprSchmCvWork.FreePrtPaperItemCd != 0)
											{
												// カンマ編集有無区分のフラグが立っていたらOutputFormatに入れる
												if (control.GetType().Equals(typeof(DataDynamics.ActiveReports.TextBox)))
												{
												    // OutputFormat設定処理
												    ((DataDynamics.ActiveReports.TextBox)control).OutputFormat = this.CreateOutputFormat(control, fPprSchmCvWork);
												}

												if (fPprSchmCvWork.FreePrtPaperItemCd != 0)
												{
													// 印字項目ワーククラス作成処理
													prtItemSetWork = this.CreatePrtItemSetWork(fPprSchmCvWork.FreePrtPaperItemCd, listItemSet);
													if (prtItemSetWork != null)
													{
														// キャッチボール対応
														// コンバートデータと実コントロールが異なる場合、印字項目設定側の内容に変換する
														// レポートコントロール区分で判断する
														switch (prtItemSetWork.ReportControlCode)
														{
															case 1: // TextBox
																{
																	// controlがLabelかPictureだったらTextBoxに変える
																	if ((control.GetType().Name.Trim() == "Label") ||
																		(control.GetType().Name.Trim() == "Picture"))
																	{
																		DataDynamics.ActiveReports.TextBox newTextBox = new DataDynamics.ActiveReports.TextBox();

																		// プロパティ追加処理
																		this.AdditionOfNewTextProp(ref newTextBox, control, prtItemSetWork, fPprSchmCvWork, listItemSet);

																		// ページ番号
																		if (prtItemSetWork.FreePrtPaperItemCd == 20)
																		{
																			((DataDynamics.ActiveReports.TextBox)newTextBox).SummaryType = SummaryType.PageCount;
																			((DataDynamics.ActiveReports.TextBox)newTextBox).SummaryRunning = SummaryRunning.All;
																		}
																		// 総ページ番号
																		if (prtItemSetWork.FreePrtPaperItemCd == 21)
																		{
																			((DataDynamics.ActiveReports.TextBox)newTextBox).SummaryType = SummaryType.PageCount;
																		}

																		if (!textBoxList.Contains(newTextBox))
																		{
																			textBoxList.Add(newTextBox);
																		}

																		section.Controls.Remove(control);
																		iy--;
																	}
																	else
																	{
																		// --- controlのコンバート --------------------------------------------------------------------------
																		if (fPprSchmCvWork.InitKitFreePprItemCd != 0)
																		{
																			// 印字項目ワーククラス作成処理
																			PrtItemSetWork wkPrtItemSetWork = this.CreatePrtItemSetWork(fPprSchmCvWork.InitKitFreePprItemCd, listItemSet);
																			if (wkPrtItemSetWork != null)
																			{
																				control.DataField = FrePrtSettingController.CreateDataField(wkPrtItemSetWork);
																			}
																		}
																		else
																		{
																			control.DataField = FrePrtSettingController.CreateDataField(prtItemSetWork);
																		}

																		// Tag設定処理
																		control.Tag = this.SetTag(control, prtItemSetWork);

																		// controlがバーコードの場合はコードに応じてバーコードの種類を設定する
																		if (control.GetType().Equals(typeof(Barcode)))
																		{
																			((Barcode)control).Style = this.SetBarCodeStyle(control, prtItemSetWork);
																		}

																		// ページ番号
																		if (prtItemSetWork.FreePrtPaperItemCd == 20)
																		{
																			((DataDynamics.ActiveReports.TextBox)control).SummaryType = SummaryType.PageCount;
																			((DataDynamics.ActiveReports.TextBox)control).SummaryRunning = SummaryRunning.All;
																		}
																		// 総ページ番号
																		if (prtItemSetWork.FreePrtPaperItemCd == 21)
																		{
																			((DataDynamics.ActiveReports.TextBox)control).SummaryType = SummaryType.PageCount;
																		}

																		// 品管障害対応(No.001005-01)
																		// Footer_SubReportのコントロール名はXX埋めする
																		if (control.GetType().Equals(typeof(DataDynamics.ActiveReports.TextBox)))
																		{
																			if ((control.Name == "FootMsg1") || 
																				(control.Name == "FootMsg2"))
																			{
																				((DataDynamics.ActiveReports.TextBox)control).Text = this.ArrangeControls(control);
																			}
																		}
																	}
																}
																break;
															case 2: // Label
																{
																	DataDynamics.ActiveReports.Label label = new DataDynamics.ActiveReports.Label();

																	this.AdditionOfNewLabelProp(ref label, control);

																	section.Controls.Add(label);
																	section.Controls.Remove(control);
																	iy--;

																}
																break;
															default:
																{
																	control.DataField = FrePrtSettingController.CreateDataField(prtItemSetWork);
																	// Tag設定処理
																	control.Tag = this.SetTag(control, prtItemSetWork);
																}
																break;
														}

													}
												}
												else
												{
													// 固定文字(TextBox)の場合
													if (control.GetType().Equals(typeof(DataDynamics.ActiveReports.TextBox)))
													{
														// 共通のヘッダーだったら、テキストボックスに変える
														DataDynamics.ActiveReports.Label aRControl = new DataDynamics.ActiveReports.Label();
														// プロパティ追加処理(Label)
														this.AdditionOfNewLabelProp(ref aRControl, control);

														section.Controls.Add(aRControl);
														section.Controls.Remove(control);
														iy--;
													}
													else control.Tag = this.SetTag(control, null);
												}
											}
											else
											{
												iy--;
												section.Controls.Remove(control);
											}
										}
									}
									else
									{
										// 固定文字(TextBox)の場合
									    if (control.GetType().Equals(typeof(DataDynamics.ActiveReports.TextBox)))
									    {
											// 共通のヘッダーだったら、テキストボックスに変える
											DataDynamics.ActiveReports.Label aRControl = new DataDynamics.ActiveReports.Label();
											// プロパティ追加処理(Label)
											this.AdditionOfNewLabelProp(ref aRControl, control);

											section.Controls.Add(aRControl);
											section.Controls.Remove(control);
											iy--;
									    }
										else	control.Tag = this.SetTag(control, null); // Tag設定処理

									}
								}
							}

							if (textBoxList.Count != 0)
							{
								foreach (DataDynamics.ActiveReports.TextBox text in textBoxList)
								{
									section.Controls.Add(text);
								}
							}
						}
					}
				}
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return wkrpt;
		}

		#endregion

		#region ☆☆　案内文はがき　☆☆
        //// *** マクロコンバート ****************************************************************
        ////
        //// ①:TextBoxとLabelの基本的なプロパティの設定を行います。
        //// ②:TextBoxとLabelの位置を取得します。
        //// ③:出来上がったTextBoxとLabelをSectionに追加し、元の案内文コントロールは削除します。
        ////
        //// ex.「お客様のお車(#SSSSSSSSSS)は」→「お客様のお車(マーチ)は」
        ////		 「お客様のお車(           )は」→ Label
        ////		  				マーチ			→ TextBox
        //// *************************************************************************************
        ///// <summary>
        ///// 既存レイアウトコンバート処理(DMはがき案内文対応)
        ///// </summary>
        ///// <param name="outputFormFileName">初回の出力ファイル名</param>
        ///// <param name="outputFileClassId">初回の出力ファイルクラスID</param>
        ///// <param name="listItemSet">印字項目設定ワークリストクラス</param>
        ///// <param name="listSchmCv">スキーマコンバートリストクラス</param>
        ///// <param name="listDmGuideSnt">DM案内文設定List</param>
        ///// <param name="effectiveMacroSign">有効マクロ文字</param>
        ///// <param name="specialConvtUseDivCd">特種マクロコンバート区分(1:特種マクロコンバート有,2:フォントのみ)</param>
        ///// <param name="message">エラーメッセージ</param>
        ///// <returns>ActiveReportクラス</returns>
        ///// <remarks>
        ///// <br>Note       : 既存のDMはがきのレポートレイアウトスキーマを自由帳票用にコンバートします。(DM用)</br>
        ///// <br>Programmer : 30015　橋本　裕毅</br>
        ///// <br>Date       : 2007.09.21</br>
        ///// </remarks>
        //public ActiveReport CvtExistingDMGuidanceLayout(string outputFormFileName, string outputFileClassId, List<PrtItemSetWork> listItemSet, List<FPprSchmCvWork> listSchmCv, List<DmGuideSnt> listDmGuideSnt, string effectiveMacroSign, int specialConvtUseDivCd, out string message)
        //{
        //    Assembly assm = null;
        //    ActiveReport wkrpt = null;
        //    message = String.Empty;
        //    float height = 0;
        //    List<DataDynamics.ActiveReports.TextBox> textList = new List<DataDynamics.ActiveReports.TextBox>(); // textリスト
        //    List<DataDynamics.ActiveReports.Label> labelList = new List<DataDynamics.ActiveReports.Label>(); // labelリスト

        //    try
        //    {
        //        List<MngOfMacroSign> mngOfMacroSignList = new List<MngOfMacroSign>(); // マクロ文字List
        //        // XMLファイルを読み取り、DataFieldとTagを設定します。
        //        MngOfMacroSign[] mngOfMacroSigns = (MngOfMacroSign[])XmlByteSerializer.Deserialize(COL_MngOfMacro, typeof(MngOfMacroSign[]));
        //        mngOfMacroSignList.AddRange(mngOfMacroSigns);

        //        try
        //        {
        //            if (!string.IsNullOrEmpty(outputFormFileName))
        //            {
        //                // ファイルパス取得処理
        //                string filePath = this.CreateFilePath(outputFormFileName);

        //                if (!string.IsNullOrEmpty(filePath))
        //                {
        //                    // 指定されたパスよりアセンブリを取得します。
        //                    assm = Assembly.LoadFrom(filePath);
        //                }
        //            }
        //        }
        //        catch (FileNotFoundException ex)
        //        {
        //            message = ex.Message;
        //            return wkrpt;
        //        }

        //        if (assm != null)
        //        {
        //            // インスタンスを作成します。
        //            Object wkObj = assm.CreateInstance(outputFileClassId);
        //            // 紐づくActiveReportをインスタンス化します。
        //            wkrpt = wkObj as ActiveReport;

        //            if (wkrpt != null)
        //            {
        //                for (int ix = 0; ix < wkrpt.Sections.Count; ix++)
        //                {
        //                    Section section = wkrpt.Sections[ix];

        //                    // 案内文のLocationの位置計算の際に必要
        //                    height = section.Height;

        //                    for (int iy = 0; iy < section.Controls.Count; iy++)
        //                    {
        //                        //SectionはDetailのみ
        //                        //Sectionに所属するControlを取得します。
        //                        ARControl control = section.Controls[iy];
        //                        control.Visible = true;

        //                        // サブレポートコントロールか判断します。
        //                        if (control.GetType().Equals(typeof(SubReport)))
        //                        {
        //                            if (wkObj != null)
        //                            {
        //                                FPprSchmCvWork fPprSchmCvWork = null;
        //                                if(this.CheckFreConv(wkrpt, control.Name, listSchmCv, out fPprSchmCvWork))
        //                                {
        //                                    ActiveReport ar;
        //                                    if (fPprSchmCvWork.OutputFileClassId != COL_ExtraHeader_ClassId)
        //                                    {
        //                                        // 再度既存のデータのコンバート処理を走らせます。
        //                                        ar = this.CvtExistingDMGuidanceLayout(fPprSchmCvWork.OutputFormFileName, fPprSchmCvWork.OutputFileClassId, listItemSet, listSchmCv, listDmGuideSnt, effectiveMacroSign, specialConvtUseDivCd, out message);
        //                                        if (ar != null)
        //                                        {
        //                                            SubReport subReport = (SubReport)control;
        //                                            // サブレポート情報展開処理
        //                                            ArrayList wkList = DevelopsSubReport(subReport, ar);
        //                                            // 配置調整処理
        //                                            if(wkList != null) this.AdjustControls(wkList, subReport, ar, ref section);

        //                                            iy--;
        //                                        }
        //                                    }
        //                                    else
        //                                    {
        //                                        // 共通のヘッダーだったら、テキストボックスに変える
        //                                        DataDynamics.ActiveReports.TextBox aRControl = new DataDynamics.ActiveReports.TextBox();
        //                                        // プロパティ追加処理(TextBox)
        //                                        this.AdditionOfNewExtraTextProp(ref aRControl, control);
        //                                        section.Controls.Add(aRControl);
        //                                    }
        //                                    section.Controls.Remove(control);
        //                                }
        //                            }
        //                        }
        //                        else
        //                        {
        //                            PrtItemSetWork prtItemSetWork = null;
        //                            // レポートのコントロールがスキーマコンバートのアクティブレポートコントロール名称が等しい場合にコンバートします。
        //                            FPprSchmCvWork fPprSchmCvWork = listSchmCv.Find(
        //                                delegate(FPprSchmCvWork wkFPprSchmCvWork)
        //                                {
        //                                    if (control.Name.Trim() == wkFPprSchmCvWork.ActiveReportCtrlNm.Trim())
        //                                        return true;
        //                                    else
        //                                        return false;
        //                                }
        //                            );
        //                            if (fPprSchmCvWork != null)
        //                            {
        //                                // 印字項目設定ワーククラスリストから、印字項目コードが等しいクラスを取得します。
        //                                if (wkrpt.GetType().Name.Trim() == fPprSchmCvWork.ActiveReportClassId.Trim())
        //                                {
        //                                    // カンマ編集有無区分のフラグが立っていたらOutputFormatに入れる
        //                                    if (control.GetType().Equals(typeof(DataDynamics.ActiveReports.TextBox)))
        //                                    {
        //                                        // OutputFormat設定処理
        //                                        ((DataDynamics.ActiveReports.TextBox)control).OutputFormat = this.CreateOutputFormat(control, fPprSchmCvWork);
        //                                    }

        //                                    if (fPprSchmCvWork.FreePrtPaperItemCd != 0)
        //                                    {
        //                                        prtItemSetWork = listItemSet.Find(
        //                                            delegate(PrtItemSetWork wkPrtItemSetWork)
        //                                            {
        //                                                if (wkPrtItemSetWork.FreePrtPaperItemCd == fPprSchmCvWork.FreePrtPaperItemCd)
        //                                                    return true;
        //                                                else
        //                                                    return false;
        //                                            }
        //                                        );
        //                                        if (prtItemSetWork != null)
        //                                        {
        //                                            // --- controlのコンバート --------------------------------------------------------------------------
        //                                            if (fPprSchmCvWork.InitKitFreePprItemCd != 0)
        //                                            {
        //                                                // 印字項目ワーククラス作成処理
        //                                                PrtItemSetWork wkPrtItemSetWork = this.CreatePrtItemSetWork(fPprSchmCvWork.InitKitFreePprItemCd, listItemSet);
        //                                                if (wkPrtItemSetWork != null)
        //                                                {
        //                                                    control.DataField = FrePrtSettingController.CreateDataField(wkPrtItemSetWork);
        //                                                }
        //                                            }
        //                                            else
        //                                            {
        //                                                control.DataField = FrePrtSettingController.CreateDataField(prtItemSetWork);
        //                                            }
													
        //                                            // Tag設定処理
        //                                            control.Tag = this.SetTag(control, prtItemSetWork);

        //                                            // controlがバーコードの場合はコードに応じてバーコードの種類を設定する
        //                                            if (control.GetType().Equals(typeof(Barcode)))
        //                                            {
        //                                                ((Barcode)control).Style = this.SetBarCodeStyle(control, prtItemSetWork);
        //                                            }

        //                                            // 特種マクロコンバート区分がフォントのみ
        //                                            if (specialConvtUseDivCd == 2)
        //                                            {
        //                                                // 案内文設定取得処理
        //                                                DmGuideSnt dmGuideSnt = this.GetDmGuideSnt(control, listDmGuideSnt);
        //                                                if (dmGuideSnt != null)
        //                                                {
        //                                                    if (dmGuideSnt.DmGuidance != "")
        //                                                    {
        //                                                        ((DataDynamics.ActiveReports.TextBox)control).CanShrink = true;
        //                                                        ((DataDynamics.ActiveReports.TextBox)control).CanGrow = true;
        //                                                        ((DataDynamics.ActiveReports.TextBox)control).ForeColor = this.SetColor(dmGuideSnt);
        //                                                        ((DataDynamics.ActiveReports.TextBox)control).Font = this.SetFont(dmGuideSnt);
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        iy--;
        //                                                        section.Controls.Remove(control);
        //                                                    }
        //                                                }
        //                                            }
        //                                        }
        //                                        else
        //                                        {
        //                                            // 固定文字(TextBox)の場合
        //                                            if (control.GetType().Equals(typeof(DataDynamics.ActiveReports.TextBox)))
        //                                            {
        //                                                // 共通のヘッダーだったら、テキストボックスに変える
        //                                                DataDynamics.ActiveReports.Label aRControl = new DataDynamics.ActiveReports.Label();
        //                                                // プロパティ追加処理(Label)
        //                                                this.AdditionOfNewLabelProp(ref aRControl, control);

        //                                                section.Controls.Add(aRControl);
        //                                                section.Controls.Remove(control);
        //                                                iy--;
        //                                            }
        //                                            else	control.Tag = this.SetTag(control, null); // Tag設定処理
        //                                        }
        //                                    }
        //                                    else
        //                                    {
        //                                        // 案内文設定取得処理
        //                                        DmGuideSnt dmGuideSnt = this.GetDmGuideSnt(control, listDmGuideSnt);
        //                                        if (dmGuideSnt != null)
        //                                        {
        //                                            if (dmGuideSnt.DmGuidance != "")
        //                                            {
        //                                                if (specialConvtUseDivCd == 1)
        //                                                {
        //                                                    string guidance = dmGuideSnt.DmGuidance; // 案内文
        //                                                    // マクロ文字のコンバートを行う
        //                                                    ConvertDMMacro(guidance, effectiveMacroSign, (DataDynamics.ActiveReports.TextBox)control, dmGuideSnt, mngOfMacroSignList, ref textList, ref labelList);
        //                                                }
        //                                            }
        //                                        }
        //                                        iy--;
        //                                        section.Controls.Remove(control);
        //                                    }
        //                                }
        //                            }
        //                            else
        //                            {
        //                                // 固定文字(TextBox)の場合
        //                                if (control.GetType().Equals(typeof(DataDynamics.ActiveReports.TextBox)))
        //                                {
        //                                    // 共通のヘッダーだったら、テキストボックスに変える
        //                                    DataDynamics.ActiveReports.Label aRControl = new DataDynamics.ActiveReports.Label();
        //                                    // プロパティ追加処理(Label)
        //                                    this.AdditionOfNewLabelProp(ref aRControl, control);

        //                                    section.Controls.Add(aRControl);
        //                                    section.Controls.Remove(control);
        //                                    iy--;
        //                                }
        //                                else	control.Tag = this.SetTag(control, null); // Tag設定処理
        //                            }
        //                        }
        //                    }

        //                    // 特種マクロコンバート有の時のみ
        //                    if (specialConvtUseDivCd == 1)
        //                    {
        //                        // Sectionに追加
        //                        if (labelList.Count != 0)
        //                        {
        //                            foreach (DataDynamics.ActiveReports.Label label in labelList)
        //                            {
        //                                if (label != null)
        //                                {
        //                                    if (label.Tag != null)
        //                                    {
        //                                        section.Controls.Add(label);
        //                                    }
        //                                }
        //                            }
        //                        }

        //                        if (textList.Count != 0)
        //                        {
        //                            foreach (DataDynamics.ActiveReports.TextBox textBox in textList)
        //                            {
        //                                if (textBox != null)
        //                                {
        //                                    if (textBox.Tag != null)
        //                                    {
        //                                        section.Controls.Add(textBox);
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        message = ex.Message;
        //    }
        //    return wkrpt;
        //}

        ///// <summary>
        ///// マクロコンバート処理
        ///// </summary>
        ///// <param name="dmGuidance">コンバート対象のDM案内文</param>
        ///// <param name="dmMacroSign">使用可能なマクロ文字</param>
        ///// <param name="guidanceTextBox">レポート上の案内文コントロール</param>
        ///// <param name="dmGuideSnt">DM案内文マスタ</param>
        ///// <param name="mngOfMacroSignList">マクロ文字管理リスト</param>
        ///// <param name="textBoxList">結果TextBoxList</param>
        ///// <param name="labelList">結果LabelList</param>
        ///// <remarks>
        ///// <br>Note       : 与えられたDM案内文からcontrolを生成します。</br>
        ///// <br>Programmer : 30015　橋本　裕毅</br>
        ///// <br>Date       : 2007.09.27</br>
        ///// </remarks>
        //private void ConvertDMMacro(string dmGuidance, string dmMacroSign, DataDynamics.ActiveReports.TextBox guidanceTextBox, DmGuideSnt dmGuideSnt, List<MngOfMacroSign> mngOfMacroSignList, ref List<DataDynamics.ActiveReports.TextBox> textBoxList, ref List<DataDynamics.ActiveReports.Label> labelList)
        //{
        //    if (!string.IsNullOrEmpty(dmGuidance))
        //    {
        //        DataDynamics.ActiveReports.Label literalLabel = null;

        //        string chgedGuidance = dmGuidance;	// DM案内文
        //        int sharpIndex; // 「#」の位置
        //        int macroLength = 0;
        //        string macroSign;

        //        // 「#」の位置を取得する
        //        sharpIndex = chgedGuidance.IndexOf("#");
        //        if (sharpIndex < 0)
        //        {
        //            // #がない(→文字のみ)ということなので、Labelを作成する。
        //            this.CreateLabel("", chgedGuidance, guidanceTextBox, dmGuideSnt, out literalLabel);
        //            labelList.Add(literalLabel);
        //            return;
        //        }
        //        else
        //        {
        //            bool sharpExist = true; // #フラグ

        //            while (sharpExist == true)
        //            {
        //                DataDynamics.ActiveReports.TextBox convertTextBox = null;
        //                macroLength = 0;	// 初期化

        //                // マクロ文字を取得する
        //                macroSign = chgedGuidance.Substring(sharpIndex + 1, 1);

        //                // 指定されている文字列が、有効マクロ文字かどうか判断する
        //                if (dmMacroSign.IndexOf(macroSign) < 0)
        //                {
        //                    convertTextBox = null;
        //                    literalLabel = null;
        //                    return;
        //                }

        //                // マクロの文字数を取得する
        //                for (int ix = sharpIndex + 1; ix < chgedGuidance.Length; ix++)
        //                {
        //                    if (chgedGuidance.Substring(ix, 1) == macroSign)
        //                        macroLength++;
        //                    else
        //                        break;
        //                }

        //                // マクロ文字列を取得する
        //                string macroString = chgedGuidance.Substring(sharpIndex, macroLength + 1);

        //                if (macroSign == "J")
        //                {
        //                    // []付きマクロ編集
        //                    chgedGuidance = BracketHeadEdit(chgedGuidance, macroSign, sharpIndex);

        //                    // 元のコントロールの位置コピーします。
        //                    this.CreateLabel(macroSign, chgedGuidance, guidanceTextBox, dmGuideSnt, out literalLabel);
        //                }
        //                else
        //                {
        //                    // プロパティ設定
        //                    // 数字のマクロ文字の場合はtrue
        //                    bool numberFlag = this.CreateProperty(chgedGuidance, macroSign, dmGuideSnt, guidanceTextBox, mngOfMacroSignList, out convertTextBox, out literalLabel);
        //                    //this.CreateProperty(chgedGuidance, macroSign, dmGuideSnt, guidanceTextBox, mngOfMacroSignList, out convertTextBox, out literalLabel);

        //                    // convertTextBoxのwidth取得
        //                    System.Windows.Forms.TextBox cnvText = new System.Windows.Forms.TextBox(); // 移動用コントロール
        //                    cnvText.Text = macroString;
        //                    cnvText.Font = new Font(dmGuideSnt.DmGuidanceFontName, dmGuideSnt.DmGuidanceFontSize);

        //                    convertTextBox.Width = (float)(FrePrtSettingController.GetStringWidth(cnvText) / 96.0f);

        //                    // テキストボックス内をXで埋める
        //                    convertTextBox.Text = macroString;
        //                    convertTextBox.Text = this.ArrangeControls(convertTextBox);

        //                    // マクロ文字の位置にテキストボックスを配置する
        //                    // 最初の文字から#の1個前までの文字列取得します。
        //                    if (numberFlag)
        //                    {
        //                        // 数字のマクロ文字の場合は、#の位置を再取得します。
        //                        sharpIndex = literalLabel.Text.IndexOf("#");
        //                    }
        //                    //string beforeSharpStr = chgedGuidance.Substring(0, sharpIndex);
        //                    string beforeSharpStr = literalLabel.Text.Substring(0, sharpIndex);

        //                    // マクロテキストボックス移動用
        //                    cnvText.Text = beforeSharpStr;
        //                    cnvText.Font = new Font(dmGuideSnt.DmGuidanceFontName, dmGuideSnt.DmGuidanceFontSize);
        //                    // レポートコントロールピクセル幅算出
        //                    float moveDistance = (float)(FrePrtSettingController.GetStringWidth(cnvText) / 96.0f);
        //                    convertTextBox.Left += moveDistance;

        //                    // 正規表現を用いリテラルに存在する、マクロ文字をスペースに置き換える
        //                    Regex regex = new Regex("#" + macroSign + "+");
        //                    Match match = regex.Match(chgedGuidance);
        //                    string matchStr = match.Value;
        //                    string spaceStr = string.Empty.PadLeft(macroLength + 1, Convert.ToChar(" "));
        //                    literalLabel.Text = Regex.Replace(literalLabel.Text, matchStr, spaceStr);
        //                    //literalLabel.Text = Regex.Replace(chgedGuidance, matchStr, spaceStr);
        //                }
        //                // マクロ文字記号を削除する
        //                chgedGuidance = literalLabel.Text;
        //                // *************************************************************************************

        //                // もうマクロ文字がないか、確認する
        //                sharpIndex = chgedGuidance.IndexOf("#");
						
        //                textBoxList.Add(convertTextBox);
        //                if (sharpIndex < 0)
        //                {
        //                    sharpExist = false;
        //                    labelList.Add(literalLabel);
        //                }
        //            }
        //        }
        //    }

        //}

		/// <summary>
		/// []付きマクロ項目編集処理
		/// </summary>
		/// <param name="chgedGuidance">DM案内文</param>
		/// <param name="macroSign">マクロ文字</param>
		/// <param name="sharpIndex">「#」のIndex</param>
		/// <returns>印字用文字列</returns>
		/// <br>Note       : 適用される案内文の編集形式に合わせた印字用文字列を返します。</br>
		/// <br>Programmer : 30015　橋本　裕毅</br>
		/// <br>Date       : 2007.09.27</br>
		private string BracketHeadEdit (string chgedGuidance, string macroSign, int sharpIndex)
		{
		    // EX1:「ABC#J[DEF]GHI」
		    // EX2:「ABC#J[DEFGHI」
		    string betweenMacroSign;	// EX1:「DEF」/ EX2:「DEFGHI」

		    // "]"のIndex
		    int closeBracketIndex = chgedGuidance.IndexOf("]", 0);

		    // "]"がある場合
		    if (closeBracketIndex >= 0)
		    {
		        // マクロ文字"[]"間文字列
		        betweenMacroSign = chgedGuidance.Substring(sharpIndex + 3, closeBracketIndex - sharpIndex - 3);
		    }
		    else	
		    {
		        // マクロ文字"[]"間文字列
		        betweenMacroSign = chgedGuidance.Substring(sharpIndex + 3);
		    }
			
			chgedGuidance = betweenMacroSign;

		    return chgedGuidance;
		}

        ///// <summary>
        ///// TextBoxデータ作成処理
        ///// </summary>
        ///// <param name="chgedGuidance">案内文</param>
        ///// <param name="macrosign">マクロ文字</param>
        ///// <param name="dmGuideSnt">案内文マスタ</param>
        ///// <param name="guidanceTextBox">レポート上の案内文コントロール</param>
        ///// <param name="mngOfMacroSignList">マクロ管理マスタ</param>
        ///// <param name="convertTextBox">結果TextBox</param>
        ///// <param name="literalLabel">結果Label</param>
        ///// <returns>true:マクロ文字が数字,false:それ以外</returns>
        ///// <remarks>
        ///// <br>Note       : Label,TextBoxのプロパティを設定します。</br>
        ///// <br>Programmer : 30015　橋本　裕毅</br>
        ///// <br>Date       : 2007.09.27</br>
        ///// </remarks>
        //private bool CreateProperty(string chgedGuidance,string macrosign, DmGuideSnt dmGuideSnt, DataDynamics.ActiveReports.TextBox guidanceTextBox, List<MngOfMacroSign> mngOfMacroSignList, out DataDynamics.ActiveReports.TextBox convertTextBox, out DataDynamics.ActiveReports.Label literalLabel)
        ////private void CreateProperty(string chgedGuidance,string macrosign, DmGuideSnt dmGuideSnt, DataDynamics.ActiveReports.TextBox guidanceTextBox, List<MngOfMacroSign> mngOfMacroSignList, out DataDynamics.ActiveReports.TextBox convertTextBox, out DataDynamics.ActiveReports.Label literalLabel)
        //{
        //    convertTextBox = new DataDynamics.ActiveReports.TextBox();
        //    #region ☆Label☆
			
        //    // 元のコントロールの位置コピーします。
        //    bool numberFlag = this.CreateLabel(macrosign, chgedGuidance, guidanceTextBox, dmGuideSnt, out literalLabel);
        //    //this.CreateLabel(macrosign, chgedGuidance, guidanceTextBox, dmGuideSnt, out literalLabel);
        //    #endregion

        //    #region ☆TextBox
        //    // マクロ部分はTextBoxに変換します。
        //    // マクロ文字に値する、DataFieldとTagを取得
        //    MngOfMacroSign mngOfMacroSign = mngOfMacroSignList.Find(
        //        delegate(MngOfMacroSign wkMngOfMacroSign)
        //        {
        //            if(macrosign == wkMngOfMacroSign.MacroSign)
        //                return true;
        //            else 
        //                return false;
        //        }
        //    );
        //    if (mngOfMacroSign != null)
        //    {
        //        // DataField
        //        convertTextBox.DataField	=	mngOfMacroSign.InfoOfDataField;
        //        // Tag
        //        convertTextBox.Tag			=	mngOfMacroSign.InfoOfTag;
        //    }

        //    convertTextBox.ForeColor = this.SetColor(dmGuideSnt);
        //    convertTextBox.Font = this.SetFont(dmGuideSnt);

        //    // 一時的に同じにしておく(GetARControlByteLengthメソッドで位置合わせを行うため)
        //    convertTextBox.CanGrow = true;
        //    convertTextBox.CanShrink = true;
        //    convertTextBox.Top = literalLabel.Top;
        //    convertTextBox.Left = literalLabel.Left;
        //    convertTextBox.Height = literalLabel.Height;
        //    convertTextBox.Visible = true;
        //    #endregion
			
        //    return numberFlag;
        //}

        ///// <summary>
        ///// Label作成処理
        ///// </summary>
        ///// <param name="macroSign">マクロ文字</param>
        ///// <param name="chgedGuidance">案内文</param>
        ///// <param name="gudanceTextBox">レポート上の案内文コントロール</param>
        ///// <param name="dmGuideSnt">案内文マスタ</param>
        ///// <param name="literalLabel">結果Label</param>
        ///// <returns>true:マクロ文字が数字,false:それ以外</returns>
        ///// <remarks>
        ///// <br>Note       : Labelのプロパティをセットします。</br>
        ///// <br>Programmer : 30015　橋本　裕毅</br>
        ///// <br>Date       : 2007.09.27</br>
        ///// </remarks>
        //private bool CreateLabel(string macroSign, string chgedGuidance, DataDynamics.ActiveReports.TextBox gudanceTextBox, DmGuideSnt dmGuideSnt, out DataDynamics.ActiveReports.Label literalLabel)
        //{
        //    bool numberFlag = false;
        //    literalLabel = new DataDynamics.ActiveReports.Label();
        //    string beforeLabelText = "";
        //    switch (macroSign)
        //    {
        //        case "1":
        //            {
        //                beforeLabelText = "シュレッダーダスト料金：";
        //            }
        //            break;
        //        case "2":
        //            {
        //                beforeLabelText = "エアバッグ料金　　　　：";
        //            }
        //            break;
        //        case "3":
        //            {
        //                beforeLabelText = "フロン類料金　　　　　：";
        //            }
        //            break;
        //        case "4":
        //            {
        //                beforeLabelText = "資金管理料金　　　　　：";
        //            }
        //            break;
        //        case "5":
        //            {
        //                beforeLabelText = "情報管理料金　　　　　：";
        //            }
        //            break;
        //        case "6":
        //            {
        //                beforeLabelText = "リサイクル料金合計　　：";
        //            }
        //            break;
        //        case "7":
        //            {
        //                beforeLabelText = "フロン券移管金額　　　：";
        //            }
        //            break;
        //    }

        //    if (beforeLabelText != "")
        //    {
        //        literalLabel.Text = beforeLabelText + chgedGuidance;
        //        numberFlag = true;
        //    }
        //    else
        //    {
        //        literalLabel.Text = chgedGuidance;
        //    }
        //    literalLabel.Tag		= "10,0,0,0,0";
        //    literalLabel.Top		= gudanceTextBox.Top;
        //    literalLabel.Left		= gudanceTextBox.Left;
        //    literalLabel.Height		= gudanceTextBox.Height;
        //    literalLabel.Width		= gudanceTextBox.Width;
        //    literalLabel.Font		= this.SetFont(dmGuideSnt);
        //    literalLabel.ForeColor	= this.SetColor(dmGuideSnt);
        //    literalLabel.MultiLine	= gudanceTextBox.MultiLine;
        //    literalLabel.BackColor	= gudanceTextBox.BackColor;
        //    literalLabel.Visible	= true;

        //    return numberFlag;
        //}

		#region 2007.12.21 Del
		///// <summary>
		///// Label作成処理
		///// </summary>
		///// <param name="chgedGuidance">案内文</param>
		///// <param name="gudanceTextBox">レポート上の案内文コントロール</param>
		///// <param name="dmGuideSnt">案内文マスタ</param>
		///// <param name="literalLabel">結果Label</param>
		///// <remarks>
		///// <br>Note       : Labelのプロパティをセットします。</br>
		///// <br>Programmer : 30015　橋本　裕毅</br>
		///// <br>Date       : 2007.09.27</br>
		///// </remarks>
		//private void CreateLabel(string chgedGuidance, DataDynamics.ActiveReports.TextBox gudanceTextBox, DmGuideSnt dmGuideSnt, out DataDynamics.ActiveReports.Label literalLabel)
		//{
		//    literalLabel = new DataDynamics.ActiveReports.Label();
		//    literalLabel.Text		= chgedGuidance;
		//    literalLabel.Tag		= "10,0,0,0,0";
		//    literalLabel.Top		= gudanceTextBox.Top;
		//    literalLabel.Left		= gudanceTextBox.Left;
		//    literalLabel.Height		= gudanceTextBox.Height;
		//    literalLabel.Width		= gudanceTextBox.Width;
		//    literalLabel.Font		= this.SetFont(dmGuideSnt);
		//    literalLabel.ForeColor	= this.SetColor(dmGuideSnt);
		//    literalLabel.Visible	= true;
		//}
		#endregion

		/// <summary>
        /// マクロコントロールX埋め処理
        /// </summary>
		/// <param name="control">マクロコントロール</param>
		/// <returns></returns>
        /// <remarks>
        /// <br>Note       : マクロ文字の位置にテキストボックスを配置します。</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.11.13</br>
        /// </remarks>
		private string ArrangeControls(DataDynamics.ActiveReports.ARControl control)
		{
			int result = 0;
            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
			Graphics graphics = null;
			int controlWidth;
			int stringWidth;
			string wkStr = ""; // X埋め済み文字列
			try
			{
				graphics = textBox.CreateGraphics();

				// レポートコントロールフォント取得
				Font controlFont = ((DataDynamics.ActiveReports.TextBox)control).Font;

				// レポートコントロールピクセル幅算出（96ppiで換算）
				// コントロールのWidth
				controlWidth = Convert.ToInt32(control.Width * 96.0f);
				// 文字列のWidth
				stringWidth = Convert.ToInt32(graphics.MeasureString(string.Empty.PadLeft(result++, 'X'), controlFont).Width);

				// 文字列の幅がコントロールの幅を超えるまで繰り返す
				while (stringWidth < controlWidth)
				{
					// X埋め
					wkStr = string.Empty.PadLeft(result++, 'X');
					stringWidth = Convert.ToInt32(graphics.MeasureString(wkStr, controlFont).Width);
				}
			}
			finally
			{
				graphics.Dispose();
			}

			return wkStr;
		}
		#endregion

		#region ☆☆　コンバート共通　☆☆
		/// <summary>
		/// ファイルパス作成処理
		/// </summary>
		/// <param name="outputFormFileName">出力ファイル名称</param>
		/// <returns>ファイルパス</returns>
		/// <remarks>
		/// <br>Note		: 拡張子が付いているものと付いていないものでファイルパスを分けます。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.09.06</br>
		/// </remarks>
		private string CreateFilePath(string outputFormFileName)
		{
			string filePath = string.Empty;

			FileInfo fi = new FileInfo(outputFormFileName);
			if (string.IsNullOrEmpty(fi.Extension))
			{
				filePath = outputFormFileName + ".dll";
			}
			else
			{
				filePath = outputFormFileName;
			}
			return filePath;
		}

		/// <summary>
		/// 印字項目作成処理
		/// </summary>
		/// <param name="freePrtPaperItemCd">印字項目コード</param>
		/// <param name="prtItemSetWorkList">印字項目ワークリスト</param>
		/// <returns>印字項目ワーククラス</returns>
		/// <remarks>
		/// <br>Note		: 印字項目ワークリストを作成します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.09.06</br>
		/// </remarks>
		private PrtItemSetWork CreatePrtItemSetWork(int freePrtPaperItemCd, List<PrtItemSetWork> prtItemSetWorkList)
		{
			PrtItemSetWork prtItemSetWork = prtItemSetWorkList.Find(
				delegate(PrtItemSetWork pisw)
				{
					if(pisw.FreePrtPaperItemCd == freePrtPaperItemCd)
						return true;
					else 
						return false;
				}
			);

			return prtItemSetWork;
		}
			

		/// <summary>
        /// サブレポート情報展開処理
        /// </summary>
        /// <param name="subRpt">SubReportクラス</param>
        /// <param name="rpt">ActiveReportクラス</param>
        /// <returns>ArrayListクラス</returns>
        /// <br>Note       : サブレポートが存在した時にサブレポートの情報を展開します。</br>
        /// <br>Programmer : 30015　橋本　裕毅</br>
        /// <br>Date       : 2007.05.07</br>
        private ArrayList DevelopsSubReport(SubReport subRpt, ActiveReport3 rpt)
        {
            ArrayList retList = new ArrayList();
			float[] secHeight = new float[rpt.Sections.Count];

			for (int i = 0; i != rpt.Sections.Count; i++)
			{
				float maxBottomCtrlHeight = 0;
				secHeight[i] += rpt.Sections[i].Height;

				// 品管障害対応(No.001022-01)
				if (rpt.Sections[i].CanShrink)
				{
				    float maxButtomControlHeight = 0;
				    // SubReport内の最下部のコントロールのボトムのHeightを取得　←Sectionの高さ
				    foreach (ARControl control in rpt.Sections[i].Controls)
				    {
				        float wkfloat = control.Top + control.Height;
				        if(maxButtomControlHeight < wkfloat)
				            maxButtomControlHeight = wkfloat;
				    }
					
				    rpt.Sections[i].Height = maxButtomControlHeight;
				}

				// SectionがDetailの場合はそのままListに追加
				if (rpt.Sections[i].GetType().Name.Equals("Detail"))
				{
					for (int ix = 0; ix != rpt.Sections[rpt.Sections[i].Name].Controls.Count; ix++)
					{
						// SectionのDetailの開始位置にサブレポートの位置を追加します。
						rpt.Sections[rpt.Sections[i].Name].Controls[ix].Top += subRpt.Top;
						rpt.Sections[rpt.Sections[i].Name].Controls[ix].Left += subRpt.Left;
						rpt.Sections[rpt.Sections[i].Name].Controls[ix].Visible = true;

						retList.Add(rpt.Sections[rpt.Sections[i].Name].Controls[ix]);
					}
				}
				else
				{
					if (rpt.Sections[i].Height != 0)
					{
						if (retList.Count == 0)
						{
							for (int ix = 0; ix != rpt.Sections[rpt.Sections[i].Name].Controls.Count; ix++)
							{
								// SectionのDetailの開始位置にサブレポートの位置を追加します。
								rpt.Sections[rpt.Sections[i].Name].Controls[ix].Top += subRpt.Top;
								rpt.Sections[rpt.Sections[i].Name].Controls[ix].Left += subRpt.Left;
								rpt.Sections[rpt.Sections[i].Name].Controls[ix].Visible = true;

								retList.Add(rpt.Sections[rpt.Sections[i].Name].Controls[ix]);
							}
						}
						else
						{
							foreach (ARControl ctrl in retList)
							{
								// コントロールの位置と高さより、最大値を取得します。
								maxBottomCtrlHeight = Math.Max(maxBottomCtrlHeight, ctrl.Top + ctrl.Height);
							}

							// Controlの最下部とSectionの高さの差分を足してやる
							for (int ix = 0; ix != rpt.Sections[rpt.Sections[i].Name].Controls.Count; ix++)
							{
								if (subRpt.CanShrink)
								{
									rpt.Sections[rpt.Sections[i].Name].Controls[ix].Top += maxBottomCtrlHeight;
								}
								else
								{
									rpt.Sections[rpt.Sections[i].Name].Controls[ix].Top += subRpt.Top;
								}
								//rpt.Sections[rpt.Sections[i].Name].Controls[ix].Left += maxBottomCtrlHeight;
								rpt.Sections[rpt.Sections[i].Name].Controls[ix].Left += subRpt.Left;
								rpt.Sections[rpt.Sections[i].Name].Controls[ix].Visible = true;

								retList.Add(rpt.Sections[rpt.Sections[i].Name].Controls[ix]);
							}
						}
					}
				}
			}

			return retList;
		}

		/// <summary>
        /// 配置調整処理
        /// </summary>
		/// <param name="wkList">ArrayListクラス</param>
		/// <param name="subReport">サブレポート</param>
		/// <param name="ar">ActiveReportクラス</param>
		/// <param name="section">対象となるSection</param>
        /// <br>Note       : SectionやControlの配置を調整します。</br>
        /// <br>Programmer : 30015　橋本　裕毅</br>
        /// <br>Date       : 2007.11.15</br>
		private void AdjustControls(ArrayList wkList, SubReport subReport, ActiveReport3 ar, ref Section section)
		{
			// ----------------------------------------
			// ARControl関連の処理
			//-----------------------------------------
			float bindRptHeight = 0; // レポートの高さ
			for (int iz = 0; iz < ar.Sections.Count; iz++)
			{
				// Sectionの高さを追加します。
				bindRptHeight += ar.Sections[iz].Height;
			}

			// コントロールの移動
			// 移動させるARControlを取得します。
			float baseBottomPoint = subReport.Top + subReport.Height;

			List<ARControl> targetList = new List<ARControl>();
			foreach (ARControl ctrl in section.Controls)
			{
				// 対象となるコントロールのTopが基準となるサブレポートの高さより下にある場合
				if (ctrl.Top >= baseBottomPoint) targetList.Add(ctrl);
			}

			if (targetList.Count > 0)
			{
				// バインドするレポートがサブレポートより高い場合
				if (subReport.Height < bindRptHeight)
				{
					// SubReportのCanGrowがtrueの場合のみ対応
					if (subReport.CanGrow)
					{
						foreach (ARControl moveCtrl in targetList)
						{
							// バインドするレポートから元のサブレポートの高さを引いた差分だけ移動します。
							moveCtrl.Top += (bindRptHeight - subReport.Height);
						}

					}
				}
				// サブレポートがバインドするレポートより低い場合
				else if (subReport.Height > bindRptHeight)
				{
					// SubReportのCanShrinkがtrueの場合のみ対応
					if (subReport.CanShrink)
					{
						foreach (ARControl moveCtrl in targetList)
						{
							// バインドするレポートから元のサブレポートの高さを引いた差分だけ移動します。
							moveCtrl.Top -= (subReport.Height - bindRptHeight);
						}
					}
				}
			}
			// サブレポートのあった位置にコントロールをコピーします。
			section.Controls.AddRange((ARControl[])wkList.ToArray(typeof(ARControl)));

			// ----------------------------------------
			// Section関連の処理
			//-----------------------------------------

			// Sectinの高さ調整
			float maxBottomCtrlHeight = 0;
			foreach (ARControl ctrl in section.Controls)
			{
			    // コントロールの位置と高さより、最大値を取得します。
			    maxBottomCtrlHeight = Math.Max(maxBottomCtrlHeight, ctrl.Top + ctrl.Height);
			}
			// コントロールの最大値が既存のセクションの高さより大きい場合
			if (section.Height < maxBottomCtrlHeight)
			{
				// SectionのCanGrowがtrueの場合のみ対応
				if (section.CanGrow)
				{
					section.Height = maxBottomCtrlHeight;
				}
			}
		}

		/// <summary>
        /// プロパティ追加処理(TextBox)
        /// </summary>
		/// <param name="text">TextBox</param>
		/// <param name="control">Control</param>
        /// <br>Note       : 抽出条件のプロパティを追加します。</br>
        /// <br>Programmer : 30015　橋本　裕毅</br>
        /// <br>Date       : 2007.11.15</br>
		private void AdditionOfNewExtraTextProp(ref DataDynamics.ActiveReports.TextBox text, ARControl control)
		{
			text.DataField	= "";
			text.Text		= "抽出条件";
			text.Tag		= "7,0,0,0,0";
			text.Top		= control.Top;
			text.Left		= control.Left;
			text.Height		= control.Height;
			text.Width		= control.Width;
			text.CanShrink	= true;
			text.Visible	= true;
			text.Font		= new System.Drawing.Font("ＭＳ 明朝", 8);
		}

		/// <summary>
        /// プロパティ追加処理(TextBox)
        /// </summary>
		/// <param name="text">TextBox</param>
		/// <param name="control">Control</param>
		/// <param name="prtItemSetWork">印字項目ワーククラス</param>
		/// <param name="fPprSchmCvWork">スキーマコンバートワーククラス</param>
		/// <param name="listPrtItemSetWork">印字項目ワークリスト</param>
        /// <br>Note       : TextBoxのプロパティを追加します。</br>
        /// <br>Programmer : 30015　橋本　裕毅</br>
        /// <br>Date       : 2007.11.26</br>
		private void AdditionOfNewTextProp(ref DataDynamics.ActiveReports.TextBox text, ARControl control, PrtItemSetWork prtItemSetWork, FPprSchmCvWork fPprSchmCvWork, List<PrtItemSetWork> listPrtItemSetWork)
		{
			if (fPprSchmCvWork.InitKitFreePprItemCd != 0)
			{
				// 印字項目ワーククラス作成処理
				PrtItemSetWork wkPrtItemSetWork = this.CreatePrtItemSetWork(fPprSchmCvWork.InitKitFreePprItemCd, listPrtItemSetWork);
				if (wkPrtItemSetWork != null)
				{
					text.DataField = FrePrtSettingController.CreateDataField(wkPrtItemSetWork);
				}
			}
			else
			{
				text.DataField	= FrePrtSettingController.CreateDataField(prtItemSetWork);
			}
			text.Height 	= control.Height;
			text.Left		= control.Left;
			text.Location	= control.Location;
			text.Name		= control.Name;
			text.Size		= control.Size;
			text.Tag 		= this.SetTag(control, prtItemSetWork);
			text.Top 		= control.Top;
			text.Visible	= true;
			text.Width		= control.Width;
			text.OutputFormat = this.CreateOutputFormat(control, fPprSchmCvWork);

			if (control.GetType().Equals(typeof(DataDynamics.ActiveReports.Label)))
			{
				text.Alignment	= ((DataDynamics.ActiveReports.Label)control).Alignment;
				text.BackColor	= ((DataDynamics.ActiveReports.Label)control).BackColor;
				text.ClassName	= ((DataDynamics.ActiveReports.Label)control).ClassName;
				text.Font		= ((DataDynamics.ActiveReports.Label)control).Font;
				text.ForeColor	= ((DataDynamics.ActiveReports.Label)control).ForeColor;
				text.HyperLink	= ((DataDynamics.ActiveReports.Label)control).HyperLink;
				text.MultiLine	= ((DataDynamics.ActiveReports.Label)control).MultiLine;
				text.RightToLeft = ((DataDynamics.ActiveReports.Label)control).RightToLeft;
				text.Style		= ((DataDynamics.ActiveReports.Label)control).Style;
				text.Text		= ((DataDynamics.ActiveReports.Label)control).Text;
				text.VerticalAlignment	= ((DataDynamics.ActiveReports.Label)control).VerticalAlignment;
				text.WordWrap	= ((DataDynamics.ActiveReports.Label)control).WordWrap;
				
				#region 品管対応(障害No：001013-01)
				// 枠線
				text.Border.BottomColor	= ((DataDynamics.ActiveReports.Label)control).Border.BottomColor;
				text.Border.BottomStyle	= ((DataDynamics.ActiveReports.Label)control).Border.BottomStyle;
				text.Border.Color		= ((DataDynamics.ActiveReports.Label)control).Border.Color;
				text.Border.LeftColor	= ((DataDynamics.ActiveReports.Label)control).Border.LeftColor;
				text.Border.LeftStyle	= ((DataDynamics.ActiveReports.Label)control).Border.LeftStyle;
				text.Border.RightColor	= ((DataDynamics.ActiveReports.Label)control).Border.RightColor;
				text.Border.RightStyle	= ((DataDynamics.ActiveReports.Label)control).Border.RightStyle;
				text.Border.Shadow		= ((DataDynamics.ActiveReports.Label)control).Border.Shadow;
				text.Border.Style		= ((DataDynamics.ActiveReports.Label)control).Border.Style;
				text.Border.TopColor	= ((DataDynamics.ActiveReports.Label)control).Border.TopColor;
				text.Border.TopStyle	= ((DataDynamics.ActiveReports.Label)control).Border.TopStyle;
				#endregion
			}
		}

		/// <summary>
        /// プロパティ追加処理(Label)
        /// </summary>
		/// <param name="label">Label</param>
		/// <param name="control">Control</param>
        /// <br>Note       : Labelのプロパティを追加します。</br>
        /// <br>Programmer : 30015　橋本　裕毅</br>
        /// <br>Date       : 2007.11.15</br>
		private void AdditionOfNewLabelProp(ref DataDynamics.ActiveReports.Label label, ARControl control)
		{
			label.Alignment	= ((DataDynamics.ActiveReports.TextBox)control).Alignment;
			label.BackColor = ((DataDynamics.ActiveReports.TextBox)control).BackColor;
			label.ClassName = ((DataDynamics.ActiveReports.TextBox)control).ClassName;
			label.DataField = "";
			label.Font		= ((DataDynamics.ActiveReports.TextBox)control).Font;
			label.ForeColor = ((DataDynamics.ActiveReports.TextBox)control).ForeColor;
			label.Height	= ((DataDynamics.ActiveReports.TextBox)control).Height;
			label.HyperLink = ((DataDynamics.ActiveReports.TextBox)control).HyperLink;
			label.Left		= ((DataDynamics.ActiveReports.TextBox)control).Left;
			label.Location	= ((DataDynamics.ActiveReports.TextBox)control).Location;
			label.MultiLine	= ((DataDynamics.ActiveReports.TextBox)control).MultiLine;
			label.RightToLeft	= ((DataDynamics.ActiveReports.TextBox)control).RightToLeft;
			label.Size		= ((DataDynamics.ActiveReports.TextBox)control).Size;
			label.Style		= ((DataDynamics.ActiveReports.TextBox)control).Style;
			label.Tag 		= this.SetTag(control, null);
			label.Text		= ((DataDynamics.ActiveReports.TextBox)control).Text;
			label.Top 		= ((DataDynamics.ActiveReports.TextBox)control).Top;
			label.VerticalAlignment	= ((DataDynamics.ActiveReports.TextBox)control).VerticalAlignment;
			label.Visible	= true;
			label.Width		= ((DataDynamics.ActiveReports.TextBox)control).Width;
			label.WordWrap	= ((DataDynamics.ActiveReports.TextBox)control).WordWrap;

			#region 品管対応(障害No：001013-01)
			// 枠線
			label.Border.BottomColor	= ((DataDynamics.ActiveReports.TextBox)control).Border.BottomColor;
			label.Border.BottomStyle	= ((DataDynamics.ActiveReports.TextBox)control).Border.BottomStyle;
			label.Border.Color			= ((DataDynamics.ActiveReports.TextBox)control).Border.Color;
			label.Border.LeftColor		= ((DataDynamics.ActiveReports.TextBox)control).Border.LeftColor;
			label.Border.LeftStyle		= ((DataDynamics.ActiveReports.TextBox)control).Border.LeftStyle;
			label.Border.RightColor		= ((DataDynamics.ActiveReports.TextBox)control).Border.RightColor;
			label.Border.RightStyle		= ((DataDynamics.ActiveReports.TextBox)control).Border.RightStyle;
			label.Border.Shadow			= ((DataDynamics.ActiveReports.TextBox)control).Border.Shadow;
			label.Border.Style			= ((DataDynamics.ActiveReports.TextBox)control).Border.Style;
			label.Border.TopColor		= ((DataDynamics.ActiveReports.TextBox)control).Border.TopColor;
			label.Border.TopStyle		= ((DataDynamics.ActiveReports.TextBox)control).Border.TopStyle;
			#endregion
		}

		/// <summary>
        /// Tag設定処理
        /// </summary>
		/// <param name="control">Control</param>
		/// <param name="prtItemSetWork">印字項目設定ワーククラス</param>
		/// <returns>Tagプロパティ</returns>
        /// <br>Note       : Tagのプロパティを追加します。</br>
        /// <br>Programmer : 30015　橋本　裕毅</br>
        /// <br>Date       : 2007.11.15</br>
		private object SetTag(ARControl control, PrtItemSetWork prtItemSetWork)
		{
			object obj = null;
			if (prtItemSetWork != null)
			{
				obj = FrePrtSettingController.GetARControlTagInfo(prtItemSetWork);
			}
			else
			{
				// 固定文字（Label）の場合
				if (control.GetType().Equals(typeof(DataDynamics.ActiveReports.Label)))
				{
					obj = "10,0,0,0,0";
				}
				// 画像(Picture)の場合
				else if (control.GetType().Equals(typeof(DataDynamics.ActiveReports.Picture)))
				{
					obj = "11,0,0,0,0";
				}
				// 枠線(Shape)の場合
				else if (control.GetType().Equals(typeof(DataDynamics.ActiveReports.Shape)))
				{
					obj = "12,0,0,0,0";
				}
				// 直線(Line)の場合
				else if (control.GetType().Equals(typeof(DataDynamics.ActiveReports.Line)))
				{
					obj = "13,0,0,0,0";
				}
			}

			return obj;
		}

		/// <summary>
        /// OutputFormat設定処理
        /// </summary>
		/// <param name="control">control</param>
		/// <param name="fPprSchmCvWork">スキーマコンバートワーククラス</param>
		/// <returns>OutputFormatプロパティ</returns>
        /// <br>Note       : OutputFormatのプロパティを追加します。</br>
        /// <br>Programmer : 30015　橋本　裕毅</br>
        /// <br>Date       : 2007.11.15</br>
		private string CreateOutputFormat(ARControl control, FPprSchmCvWork fPprSchmCvWork)
		{
			string outputFormat = string.Empty;
			switch (fPprSchmCvWork.CommaEditExistCd)
			{
				// #,###
				case 1:
					{
						outputFormat = "#,###";
						break;
					}
				// #,##0
				case 2:
					{
						outputFormat = "#,##0";
						break;
					}
				// 0.0
				case 3:
					{
						outputFormat = "0.0";
						break;
					}
				// 0.00
				case 4:
					{
						outputFormat = "0.00";
						break;
					}
				// \#,##0
				case 5:
					{
						outputFormat = @"\\#,##0";
						break;
					}
				// \#,##0-
				case 6:
					{
						outputFormat = @"\\#,##0-";
						break;
					}
				// なし
				default:
					{
						outputFormat = string.Empty;
						break;
					}
			}
			
			return outputFormat;
		}

		/// <summary>
        /// BarCodeStyle設定処理
        /// </summary>
		/// <param name="control">Control</param>
		/// <param name="prtItemSetWork">印字項目設定ワーククラス</param>
		/// <returns>BarCodeStyle</returns>
        /// <br>Note       : Tagのプロパティを追加します。</br>
        /// <br>Programmer : 30015　橋本　裕毅</br>
        /// <br>Date       : 2007.12.3</br>
		public BarCodeStyle SetBarCodeStyle(ARControl control, PrtItemSetWork prtItemSetWork)
		{
			BarCodeStyle barcode = BarCodeStyle.None;

			switch (prtItemSetWork.BarCodeStyle)
			{
				case 1:
					barcode = BarCodeStyle.Code_128_A;
					break;
				case 2:
					barcode = BarCodeStyle.JapanesePostal;
					break;
				case 3:
					barcode = BarCodeStyle.QRCode;
					break;
			}
			return barcode;
		}

        ///// <summary>
        ///// カラー設定処理
        ///// </summary>
        ///// <param name="dmGuideSnt">案内文設定</param>
        ///// <returns>Color</returns>
        ///// <br>Note       : カラーを設定します。</br>
        ///// <br>Programmer : 30015　橋本　裕毅</br>
        ///// <br>Date       : 2007.12.01</br>
        //private Color SetColor(DmGuideSnt dmGuideSnt)
        //{
        //    // ForeColor
        //    // フォントカラーが設定されている場合
        //    if (dmGuideSnt.DmGuidanceFontColor != 0)
        //    {
        //        // 指定されたフォントカラーを設定
        //        return Color.FromArgb(dmGuideSnt.DmGuidanceFontColor);
        //    }
        //    else
        //    {
        //        // 黒を設定
        //        return Color.Black;
        //    }
        //}

        ///// <summary>
        ///// Font設定処理
        ///// </summary>
        ///// <param name="dmGuideSnt">案内文設定</param>
        ///// <returns>Font</returns>
        ///// <br>Note       : フォントを設定します。</br>
        ///// <br>Programmer : 30015　橋本　裕毅</br>
        ///// <br>Date       : 2007.12.01</br>
        //private Font SetFont(DmGuideSnt dmGuideSnt)
        //{
        //    FontStyle style = FontStyle.Regular;

        //    // 太字・斜体の設定
        //    if (dmGuideSnt.DmGuidanceBoldCode == 1 &
        //        dmGuideSnt.DmGuidanceItalicCode == 2)
        //    {
        //        style = FontStyle.Bold | FontStyle.Italic;
        //    }
        //    else if (dmGuideSnt.DmGuidanceBoldCode == 0 &
        //        dmGuideSnt.DmGuidanceItalicCode == 2)
        //    {
        //        style = System.Drawing.FontStyle.Italic;
        //    }
        //    else if (dmGuideSnt.DmGuidanceBoldCode == 1 &
        //        dmGuideSnt.DmGuidanceItalicCode == 0)
        //    {
        //        style = System.Drawing.FontStyle.Bold;
        //    }

        //    return new System.Drawing.Font(
        //            dmGuideSnt.DmGuidanceFontName,
        //            dmGuideSnt.DmGuidanceFontSize,
        //            style);
        //}

		/// <summary>
        /// コンバート対象チェック処理
        /// </summary>
		/// <param name="wkrpt"></param>
		/// <param name="name"></param>
		/// <param name="listSchmCv"></param>
		/// <param name="fPprSchmCvWork"></param>
        /// <returns>true:,false:</returns>
        /// <br>Note       : コンバートワーククラスを受け取り、クラスIDを比較した上で結果を返します。</br>
        /// <br>Programmer : 30015　橋本　裕毅</br>
        /// <br>Date       : 2007.09.12</br>
		private bool CheckFreConv(ActiveReport3 wkrpt, string name, List<FPprSchmCvWork> listSchmCv, out FPprSchmCvWork fPprSchmCvWork)
		{
			bool flag = false;

			fPprSchmCvWork = listSchmCv.Find(
				delegate(FPprSchmCvWork wkFPprSchmCvWork)
				{
					if (name.Trim() == wkFPprSchmCvWork.ActiveReportCtrlNm.Trim())
						return true;
					else
						return false;
				}
			);
			if (fPprSchmCvWork != null)
			{
				if (wkrpt.GetType().Name.Trim() == fPprSchmCvWork.ActiveReportClassId.Trim())
				{
					return true;
				}

			}
			return flag;
		}

        ///// <summary>
        ///// 案内文取得処理
        ///// </summary>
        ///// <param name="control">案内文コントロール</param>
        ///// <param name="listDmGuideSnt">案内文リスト</param>
        ///// <returns>true:,false:</returns>
        ///// <br>Note       : 表示順位などから対象となる案内文マスタを取得します。</br>
        ///// <br>Programmer : 30015　橋本　裕毅</br>
        ///// <br>Date       : 2007.12.01</br>
        //private DmGuideSnt GetDmGuideSnt(ARControl control, List<DmGuideSnt> listDmGuideSnt)
        //{
        //    DmGuideSnt dmGuideSnt = null;
        //    if (listDmGuideSnt.Count != 0)
        //    {
        //        if (control.Name.Contains("DmGuidance"))
        //        {
        //            if (control.GetType().Equals(typeof(DataDynamics.ActiveReports.TextBox)))
        //            {

        //                string dmguidanceClone = control.Name.Clone().ToString();
        //                string wkDmguidanceClone = dmguidanceClone.Remove(0, 10);
        //                int wkDetailDisplayOrder = int.Parse(wkDmguidanceClone);

        //                // 取得した数字とDM案内文マスタの明細表示順位が等しいものを取得します。
        //                dmGuideSnt = listDmGuideSnt.Find(
        //                    delegate(DmGuideSnt wkDmGuideSnt)
        //                    {
        //                        if (wkDetailDisplayOrder == wkDmGuideSnt.DetailDisplayOrder)
        //                            return true;
        //                        else
        //                            return false;
        //                    }
        //                );
        //            }
        //        }
        //    }

        //    return dmGuideSnt;
        //}


		#endregion

		#region ☆☆　コンバート以外 ☆☆
		/// <summary>
		/// 自由帳票印字項目パラメータクラス生成処理
		/// </summary>
		/// <param name="rpt">ActiveReportクラス</param>
		/// <param name="listPrtItemSetWork">印字項目設定ワークリスト</param>
		/// <param name="frePprSrtOList">自由帳票ソート順位リスト</param>
        /// <returns>自由帳票印字項目ワークパラメータリスト</returns>
		/// <remarks>
		/// <br>Note       : 与えられたActiveReportクラスと印字項目設定ワークリストより自由帳票印字項目パラメータクラスを生成します。</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.07.23</br>
		/// </remarks>
////////////////////////////////////////////// 2007.10.12 TERASAKA DEL STA //
//		public List<FrePrtItmSetPrmWork> CreateFrePrtItmSetPrm(ActiveReport rpt, List<PrtItemSetWork> listPrtItemSetWork)
// 2007.10.12 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2007.10.12 TERASAKA ADD STA //
		public List<FrePrtItmSetPrmWork> CreateFrePrtItmSetPrm(ActiveReport3 rpt, List<PrtItemSetWork> listPrtItemSetWork, List<FrePprSrtO> frePprSrtOList)
// 2007.10.12 TERASAKA ADD END //////////////////////////////////////////////
		{
			List<FrePrtItmSetPrmWork> listFrePrtItmSetPrm = new List<FrePrtItmSetPrmWork>(); // 返す用リスト
			List<PrtItemSetWork> rptPrtItemSetWork = new List<PrtItemSetWork>(); // ソート順位が0の場合の印字項目設定ワークリスト
			List<PrtItemSetWork> sortPrtItemSetWork = new List<PrtItemSetWork>(); // ソート順位が0以外の場合の印字項目設定ワークリスト
			FrePrtItmSetPrmWork wkFrePrtItmSetPrmWork = null;

			try
			{
				if (rpt != null && listFrePrtItmSetPrm != null)
				{
					// ソート順位が0かそれ以外のもので、それぞれキャッシュの生成
					foreach (PrtItemSetWork wkPrtItemSetWork in listPrtItemSetWork)
					{
						// パラメータ生成対象はファイル名とDD名称が必ず入っていること
						if ((!string.IsNullOrEmpty(wkPrtItemSetWork.FileNm)) && (!string.IsNullOrEmpty(wkPrtItemSetWork.DDName)))
						{
////////////////////////////////////////////// 2007.10.12 TERASAKA DEL STA //
//							if (wkPrtItemSetWork.SortingOrder == 0)
//							{
//								// ActiveReportに存在する項目で必ず必要
//								rptPrtItemSetWork.Add(wkPrtItemSetWork);
//							}
//							else
//							{
//								// ソートの際に必要
//								sortPrtItemSetWork.Add(wkPrtItemSetWork);
//							}
// 2007.10.12 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2007.10.12 TERASAKA ADD STA //
							bool isSortTarget = frePprSrtOList.Exists(
									delegate(FrePprSrtO wkFrePprSrtO)
									{
										if (wkFrePprSrtO.SortingOrderCode == wkPrtItemSetWork.FreePrtPaperItemCd &&
											wkFrePprSrtO.SortingOrderDivCd != 0)
											return true;
										else
											return false;
									}
								);
							if (isSortTarget)
								// ソートの際に必要
								sortPrtItemSetWork.Add(wkPrtItemSetWork);
							else
								// ActiveReportに存在する項目で必ず必要
								rptPrtItemSetWork.Add(wkPrtItemSetWork);
// 2007.10.12 TERASAKA ADD END //////////////////////////////////////////////
						}
					}

					for (int ix = 0; ix < rpt.Sections.Count; ix++)
					{
						Section section = rpt.Sections[ix]; // Sectionを取得します。

						// GroupHeaderの場合を取得します。
						if (section is GroupHeader)
						{
							string sectionDataField = ((GroupHeader)section).DataField;

							if (!string.IsNullOrEmpty(sectionDataField))
							{
								// ソート順位が0の場合の印字項目設定ワークリストに共通するPrtItemSetWorkを取得
								PrtItemSetWork prtItemSetWork = listPrtItemSetWork.Find(
								    delegate(PrtItemSetWork wkPrtItemSetWork)
								    {
								        string wkFileNmDDNm = wkPrtItemSetWork.FileNm + "." + wkPrtItemSetWork.DDName;
										
								        // コントロールのDataFieldが印字項目設定のファイル名称.DD名称と等しい値が存在する
								        if (wkFileNmDDNm == sectionDataField)
								            return true;
								        else
								            return false;
								    }
								);

								if (prtItemSetWork != null)
								{
								    // 自由帳票印字項目パラメータクラス代入処理
								    this.MakeFrePrtItmSetPrmWorkListProc(prtItemSetWork, out wkFrePrtItmSetPrmWork);

								    listFrePrtItmSetPrm.Add(wkFrePrtItmSetPrmWork);
								}
							}
						}

						for (int iy = 0; iy < section.Controls.Count; iy++)
						{
							ARControl control = section.Controls[iy]; // Controlを取得します。

							string controlDataField = control.DataField;
							// DataFieldが設定されている場合
							if (!string.IsNullOrEmpty(controlDataField))
							{
								// ソート順位が0の場合の印字項目設定ワークリストに共通するPrtItemSetWorkを取得
								PrtItemSetWork prtItemSetWork = listPrtItemSetWork.Find(
								    delegate(PrtItemSetWork wkPrtItemSetWork)
								    {
								        string wkFileNmDDNm = wkPrtItemSetWork.FileNm + "." + wkPrtItemSetWork.DDName;
										
								        // コントロールのDataFieldが印字項目設定のファイル名称.DD名称と等しい値が存在する
								        if (wkFileNmDDNm == controlDataField)
								            return true;
								        else
								            return false;
								    }
								);

								if (prtItemSetWork != null)
								{
								    // 自由帳票印字項目パラメータクラス代入処理
								    this.MakeFrePrtItmSetPrmWorkListProc(prtItemSetWork, out wkFrePrtItmSetPrmWork);
									
									// 既に追加されていたら省く
									FrePrtItmSetPrmWork frePrt = listFrePrtItmSetPrm.Find(
										delegate(FrePrtItmSetPrmWork tempFrePrtItmSetPrmWork)
										{
											if ((tempFrePrtItmSetPrmWork.FileNm == wkFrePrtItmSetPrmWork.FileNm) && 
												(tempFrePrtItmSetPrmWork.DDName == wkFrePrtItmSetPrmWork.DDName))
												return true;
											else
												return false;
										}
									);
									if (frePrt == null)
									{
										listFrePrtItmSetPrm.Add(wkFrePrtItmSetPrmWork);
									}
								}
							}
						}
					}

					// ソートの際に必要なパラメータをAdd
					foreach(PrtItemSetWork _sortPrtItemSetWork in sortPrtItemSetWork)
					{
						// 自由帳票印字項目パラメータクラス代入処理
						this.MakeFrePrtItmSetPrmWorkListProc(_sortPrtItemSetWork, out wkFrePrtItmSetPrmWork);

						// 既に追加されていたら省く
						FrePrtItmSetPrmWork frePrt = listFrePrtItmSetPrm.Find(
							delegate(FrePrtItmSetPrmWork tempFrePrtItmSetPrmWork)
							{
								if ((tempFrePrtItmSetPrmWork.FileNm == wkFrePrtItmSetPrmWork.FileNm) && 
									(tempFrePrtItmSetPrmWork.DDName == wkFrePrtItmSetPrmWork.DDName))
									return true;
								else
									return false;
							}
						);
						if (frePrt == null)
						{
							listFrePrtItmSetPrm.Add(wkFrePrtItmSetPrmWork);
						}

					}
				}
				else
				{
					listFrePrtItmSetPrm = null;
				}
			}
			catch (Exception)
			{
				listFrePrtItmSetPrm = null;
			}
			return listFrePrtItmSetPrm;
		}

		/// <summary>
		/// 自由帳票印字項目パラメータクラス代入処理
		/// </summary>
		/// <param name="wkPrtItemSetWork">自由帳票印字項目ワーククラス</param>
		/// <param name="wkFrePrtItmSetPrmWork">自由帳票印字項目パラメータクラスリスト</param>
		/// <remarks>
		/// <br>Note       : 与えられた自由帳票印字項目ワーククラスを自由帳票印字項目パラメータクラスをに代入し、リストに追加します。</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.07.23</br>
		/// </remarks>
		private void MakeFrePrtItmSetPrmWorkListProc(PrtItemSetWork wkPrtItemSetWork, out FrePrtItmSetPrmWork wkFrePrtItmSetPrmWork)
		{
			wkFrePrtItmSetPrmWork = new FrePrtItmSetPrmWork();

			wkFrePrtItmSetPrmWork.FileNm	= wkPrtItemSetWork.FileNm;		// ファイル名
			wkFrePrtItmSetPrmWork.DDName    = wkPrtItemSetWork.DDName;		// DD名称
			wkFrePrtItmSetPrmWork.DDCharCnt = wkPrtItemSetWork.DDCharCnt;   // DD桁数

			// 暗号化フラグ
			if (wkPrtItemSetWork.CipherFlg.Equals(0))
			{
				wkFrePrtItmSetPrmWork.CipherFlg = 0; // 暗号化無
			}
			else
			{
				wkFrePrtItmSetPrmWork.CipherFlg = 1; // 暗号化有
			}

			// 抽出対象フラグ
			if (wkPrtItemSetWork.ExtractionItdedFlg.Equals(0))
			{
			    wkFrePrtItmSetPrmWork.ExtractionItdedFlg = 0; // 抽出非対称
			}
			else
			{
			    wkFrePrtItmSetPrmWork.ExtractionItdedFlg = 1; // 抽出対象
			}

		}

		/// <summary>
		/// Select文抽出項目生成処理（暗号化対応）
		/// </summary>
		/// <param name="paraList">自由帳票印字項目ワークパラメータリスト</param>
		/// <param name="selectLetter">テーブル名</param>
		/// <param name="listEncryption">暗号化対応DD名称のリスト</param>
        /// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 作成した自由帳票のレイアウトよりSELECT文を生成します。</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.05.07</br>
		/// </remarks>
		public int CreateSelectEncryption(List<FrePrtItmSetPrmWork> paraList, out string selectLetter, out List<string> listEncryption)
		{
			int status = 0;
			selectLetter = String.Empty;
			string targetString = String.Empty;

			listEncryption = new List<string>(); // 暗号化されたパラメータを格納します。

			StringBuilder sb = new StringBuilder();
			try
			{
				foreach (FrePrtItmSetPrmWork wkPara in paraList)
				{
					// 対象となるのは抽出対象フラグが対象の場合のみ
					if (wkPara.ExtractionItdedFlg.Equals(1))
					{
						if (sb.Length > 0)
						{
							sb.Append(',');
						}

						// 暗号化フラグが暗号化無の場合
						if (wkPara.CipherFlg.Equals(0))
						{
							targetString = CreateDataField(wkPara);
						}
						else
						{
							string wkStr = listEncryption.Find(
								delegate(string wkFileNm)
								{
									if(wkFileNm == wkPara.FileNm)
										return true;
									else
										return false;
								}
							);
							if (string.IsNullOrEmpty(wkStr))
							{
								listEncryption.Add(wkPara.FileNm);
							}
							targetString = string.Format("Cast( DecryptByKey({0}) AS NVARCHAR({2}) ) AS {1}", CreateDataField(wkPara), wkPara.DDName, wkPara.DDCharCnt);
						}
						sb.Append(targetString);
					}

				}

				if (sb != null)
				{
					selectLetter = sb.ToString();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				status = -1;
			}
			return status;
		}

		/// <summary>
		/// データフィールドデータ作成処理
		/// </summary>
		/// <param name="frePrtItmSetPrmWork">自由帳票印字項目ワークパラメータ</param>
		/// <returns>データフィールドデータ</returns>
		/// <remarks>
		/// <br>Note		: 印字項目設定マスタを元にデータフィールドに</br>
		/// <br>			: 設定するデータを作成します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2008.01.07</br>
		/// </remarks>
		public static string CreateDataField(FrePrtItmSetPrmWork frePrtItmSetPrmWork)
		{
			if (frePrtItmSetPrmWork == null) return string.Empty;

			if (!string.IsNullOrEmpty(frePrtItmSetPrmWork.FileNm) &&
				!string.IsNullOrEmpty(frePrtItmSetPrmWork.DDName))
				return frePrtItmSetPrmWork.FileNm + "." + frePrtItmSetPrmWork.DDName;
			else if (!string.IsNullOrEmpty(frePrtItmSetPrmWork.FileNm))
				return frePrtItmSetPrmWork.FileNm;
			else if (!string.IsNullOrEmpty(frePrtItmSetPrmWork.DDName))
				return frePrtItmSetPrmWork.DDName;
			else
				return string.Empty;
		}
		#endregion
	}

}
